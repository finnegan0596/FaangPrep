namespace Problems
{
    // Description: return indices of the two numbers in nums such that they add up to target.
    // Category: Pointers (ish), Hash Table
    // Implementation:
    // Use a dictionary to store the numbers and their indices.
    // While building dictionary, for each number, check if the complement (target - current number) exists in the dictionary.
    // If it does, return the indices.
    public class LeetCode1_TwoSum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.TryGetValue(complement, out int idx))
                    return new[] { idx, i };
                dict[nums[i]] = i;
            }
            return Array.Empty<int>();
        }

        public string Run()
        {
            var nums = new int[] { 3, 2, 4 };
            var res = TwoSum(nums, 6);
            return $"[{string.Join(',',res)}]";
        }

        public static string Description => "Given nums and target return indices of two numbers that add to target.";
        public static string Id => "1";
        public static string Name => "TwoSum";
    }
}
