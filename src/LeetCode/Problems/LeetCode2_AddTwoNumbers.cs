namespace Problems
{
    // Description: return sum of two numbers represented in reverse order in a linkedlist,
    // as a total represented in reverse order in a linked list
    // Category: LinkedList (not really one of the listed topics in techinterview article)
    // Implementation:
    // First attempt used strings, big integers and math.pow but was inefficient
    // More efficient, simply add two numbers and insert total into node.
    // Then, if necessary, simply carry the one two the following node
    // Keep going until there are no more nodes or carried 1s

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry = 0)
        {

            var total = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            carry = total / 10;
            total = total % 10;

            var node = new ListNode(total);

            if (carry == 0 && l1?.next == null && l2?.next == null)
            {
                return node;
            }

            node.next = AddTwoNumbers(l1?.next, l2?.next, carry);
            return node;
        }
    }

    public class LeetCode2_AddTwoNumbers
    {
        // Constructs a linked list from an array of digits (head is least-significant digit per LeetCode problem)
        private ListNode FromArray(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return null;
            }

            var head = new ListNode(arr[0]);
            var cur = head;
            for (int i = 1; i < arr.Length; i++)
            {
                cur.next = new ListNode(arr[i]);
                cur = cur.next;
            }
            return head;
        }

        // Converts result linked list to readable string like [1,2,3]
        private string ToArrayString(ListNode node)
        {
            var vals = new List<int>();
            var cur = node;
            while (cur != null)
            {
                vals.Add(cur.val);
                cur = cur.next;
            }
            return $"[{string.Join(',', vals)}]";
        }

        public string Run()
        {
            var a = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            var b = new int[] { 5, 6, 4 };

            var s = new Solution();
            var l1 = FromArray(a);
            var l2 = FromArray(b);
            var res = s.AddTwoNumbers(l1, l2);
            return ToArrayString(res);
        }

        public static string Description => "Add two numbers represented by linked lists (digits reversed).";
        public static string Id => "2";
        public static string Name => "AddTwoNumbers";
    }
}
