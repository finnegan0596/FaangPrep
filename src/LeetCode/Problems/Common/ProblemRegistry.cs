using System;
using System.Linq;
using System.Reflection;

namespace Problems.Common
{
    public class ProblemInfo
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public Func<string> Run { get; init; }
        public Type ProblemType { get; init; }
    }

    public static class ProblemRegistry
    {
        private static ProblemInfo[] _cache;

        public static ProblemInfo[] GetAllProblems()
        {
            if (_cache != null) return _cache;
            var asm = Assembly.GetExecutingAssembly();
            var types = asm.GetTypes().Where(t => t.IsClass && t.Name.StartsWith("LeetCode")).OrderBy(t => t.Name);
            var list = types.Select(t =>
            {
                string id = GetStaticString(t, "Id") ?? ExtractIdFromName(t.Name);
                string name = GetStaticString(t, "Name") ?? t.Name;
                string desc = GetStaticString(t, "Description") ?? string.Empty;
                Func<string> runner = CreateRunner(t);
                return new ProblemInfo { Id = id, Name = name, Description = desc, Run = runner, ProblemType = t };
            }).ToArray();
            _cache = list;
            return _cache;
        }

        private static string GetStaticString(Type t, string memberName)
        {
            var prop = t.GetProperty(memberName, BindingFlags.Public | BindingFlags.Static);
            if (prop != null && prop.PropertyType == typeof(string)) return (string)prop.GetValue(null);
            var field = t.GetField(memberName, BindingFlags.Public | BindingFlags.Static);
            if (field != null && field.FieldType == typeof(string)) return (string)field.GetValue(null);
            return null;
        }

        private static string ExtractIdFromName(string name)
        {
            // name expected LeetCode{Id}_...
            var prefix = "LeetCode";
            if (!name.StartsWith(prefix)) return name;
            var rest = name.Substring(prefix.Length);
            var parts = rest.Split('_');
            return parts.Length > 0 ? parts[0] : rest;
        }

        private static Func<string> CreateRunner(Type t)
        {
            // Prefer static Run() returning string
            var staticRun = t.GetMethod("Run", BindingFlags.Public | BindingFlags.Static, Type.DefaultBinder, Type.EmptyTypes, null);
            if (staticRun != null && staticRun.ReturnType == typeof(string))
            {
                return () => (string)staticRun.Invoke(null, null);
            }

            // Otherwise prefer instance Run() returning string
            var instRun = t.GetMethod("Run", BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, Type.EmptyTypes, null);
            if (instRun != null && instRun.ReturnType == typeof(string))
            {
                return () =>
                {
                    var inst = Activator.CreateInstance(t);
                    return (string)instRun.Invoke(inst, null);
                };
            }

            // Fallback: try to find a method named Solve or similar and format a message
            return () => $"No runnable entrypoint found for {t.FullName}. Add a public static string Run() or public string Run().";
        }
    }
}
