namespace Problems
{
    // Description: Find the combined median of two sorted arrays
    // Category: Binary Search
    // Implementation: 
    //      Attempt 1:
    //          Iterate through both arrays
    //          Push min of both to stack and increment that arrays index
    //          When stack size is big enough, stop
    //          Pop last number (or last two for even number of total numbers)
    //          Calculate median of popped
    //          Problem:
    //              I believe Time Complexity is O((m+n)/2) which is effectively O(m+n)
    //              Solution requests O(log(min(m, n))
    //              Need a binary search
    public class LeetCode4_MedianOfTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {


            /* what indices we care about for a given total array length
             [1] = 0
             [2] = 0, 1
             [3] = 1
             [4] = 1, 2
            */
            var stack = new Stack<int>();
            int nums1Index = 0;
            int nums2Index = 0;
            var totalLength = nums1.Length + nums2.Length;
            var isOdd = totalLength % 2 == 1;

            var midLength = totalLength / 2;

            while ((isOdd && stack.Count < midLength) || stack.Count < midLength + 1)
            {
                if (nums1Index >= nums1.Length)
                {
                    stack.Push(nums2[nums2Index]);
                    nums2Index++;
                    continue;
                }
                if (nums2Index >= nums2.Length)
                {
                    stack.Push(nums1[nums1Index]);
                    nums1Index++;
                    continue;
                }
                if (nums1[nums1Index] < nums2[nums2Index])
                {
                    stack.Push(nums1[nums1Index]);
                    nums1Index++;
                }
                else
                {
                    stack.Push(nums2[nums2Index]);
                    nums2Index++;
                }
            }

            if (isOdd)
            {
                return (double)stack.Pop();
            }

            var median1 = (double)stack.Pop();
            var median2 = (double)stack.Pop();
            return (median1 + median2) / 2.0d;
        }

        public string Run()
        {
            var nums1 = new int[] { 1, 2 };
            var nums2 = new int[] { 3, 4 };
            var res = FindMedianSortedArrays(nums1, nums2);
            return res.ToString();
        }

        public static string Description => "Return the median of the two sorted arrays.";
        public static string Id => "4";
        public static string Name => "MedianOfTwoSortedArrays";
    }
}
