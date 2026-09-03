using System;
using System.Collections.Generic;

namespace Problems
{
    public class LeetCode1_TwoSum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int,int>();
            for (int i=0;i<nums.Length;i++)
            {
                int complement = target - nums[i];
                if (dict.TryGetValue(complement, out int idx))
                    return new [] { idx, i };
                dict[nums[i]] = i;
            }
            return Array.Empty<int>();
        }

        public string Run()
        {
            var nums = new[] {2,7,11,15};
            var res = TwoSum(nums,9);
            return $"[{string.Join(',',res)}]";
        }

        public static string Description => "Given nums and target return indices of two numbers that add to target.";
        public static string Id => "1";
        public static string Name => "TwoSum";
    }
}
