namespace Problems
{
    // Description: Find the length of the longest substring of unique letters
    // Category: Sliding Window
    // Implementation:
    //      First attempt:
    //          Nested loop using Dictionary for uniqueness but not storing indexes.
    //          On a repeat incremented start by 1
    //          Works but slow (bottom 5% of submitted solutions)
    //      Current attempt:
    //          No nesting. Only progress the end.
    //          Instead of incrementing start,
    //          it is now always the character after the last known repeat.
    //          The dictionary stores a "last seen" index for a character.
    //          Therefore (end - start + 1) is always a valid unique substring length.
    //          If that breaks the previous length, update the maxLength
    // Gotcha:
    //      First attempt was a sliding window, but incremented the start when it should have eliminated the start.
    public class LeetCode3_LengthOfLongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            int start = 0;
            int maxLength = 0;
            var table = new Dictionary<char, int>();

            for (int end = 0; end < s.Length; end++)
            {
                var selectedChar = s[end];
                if (table.ContainsKey(selectedChar))
                {
                    start = Math.Max(table[selectedChar] + 1, start);

                }

                table[selectedChar] = end;
                maxLength = Math.Max(maxLength, end - start + 1);


            }
            return maxLength;
        }

        public string Run()
        {
            var result = LengthOfLongestSubstring("abcad");
            return result.ToString();
        }

        public static string Description => "Given a string s, find the length of the longest substring without repeating characters.";
        public static string Id => "3";
        public static string Name => "LengthOfLongestSubstring";
    }
}
