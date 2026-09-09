using NUnit.Framework;
using Problems;
using System.Collections.Generic;

namespace LeetCode.Tests
{
    public class LeetCode2_AddTwoNumbers_Tests
    {
        private ListNode FromArray(int[] arr)
        {
            if (arr == null || arr.Length == 0) return null;
            var head = new ListNode(arr[0]);
            var cur = head;
            for (int i = 1; i < arr.Length; i++)
            {
                cur.next = new ListNode(arr[i]);
                cur = cur.next;
            }
            return head;
        }

        private int[] ToArray(ListNode node)
        {
            var vals = new List<int>();
            var cur = node;
            while (cur != null)
            {
                vals.Add(cur.val);
                cur = cur.next;
            }
            return vals.ToArray();
        }

        [Test]
        public void Example1_AddsTwoNumbers_ReturnsExpectedList()
        {
            var s = new Solution();
            var l1 = FromArray(new[] { 2, 4, 3 });
            var l2 = FromArray(new[] { 5, 6, 4 });
            var res = s.AddTwoNumbers(l1, l2);
            Assert.AreEqual(new[] { 7, 0, 8 }, ToArray(res));
        }

        [Test]
        public void CarryCreatesNewNode_ReturnsExpectedList()
        {
            var s = new Solution();
            var l1 = FromArray(new[] { 9, 9 });
            var l2 = FromArray(new[] { 1 });
            var res = s.AddTwoNumbers(l1, l2);
            Assert.AreEqual(new[] { 0, 0, 1 }, ToArray(res));
        }
    }
}
