# Copilot Instructions

## Project Guidelines
- For future LeetCode scaffolding, obtain the LeetCode problem ID, problem name, exact expected method signature, and examples from the official LeetCode problem instructions. Do not infer a method signature from the problem ID alone.
- Create source files at `src/LeetCode/Problems/LeetCode{Id}_{Name}.cs` using the `Problems` namespace and existing class naming convention.
- Add only blank problem-solving comment labels: `// Description:`, `// Category:`, and `// Implementation:`. Do not add algorithm hints, categories, solution descriptions, or implementation notes.
- Add the requested public LeetCode method with a body limited to `throw new NotImplementedException();`.
- Add a public `Run()` method that invokes the expected LeetCode method using one official example and formats the result appropriately.
- Add public static string properties: `Description` populated with the problem description, `Id` populated with the problem ID, and `Name` populated with the problem name.
- Create NUnit test files at `tests/LeetCode.Tests/LeetCode{Id}_{Name}_Tests.cs` using the `LeetCode.Tests` namespace, `using NUnit.Framework;`, and `using Problems;`.
- Generate NUnit test methods for every official LeetCode example, but do not add extra edge-case tests.
- Build the solution after creating LeetCode scaffolding.
