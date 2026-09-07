namespace Problems
{
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
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var total = getListNodeTotal(l1) + getListNodeTotal(l2);
            return getListNodeFromTotal(total);
        }

        private System.Numerics.BigInteger getListNodeTotal(ListNode l1, int power = 0)
        {
            var val = new System.Numerics.BigInteger(l1.val);
            var mult = System.Numerics.BigInteger.Pow(
                new System.Numerics.BigInteger(10),
                power);

            var total = val * mult;

            if (l1.next == null)
            {
                return total;
            }

            total += getListNodeTotal(l1.next, power + 1);
            return total;
        }

        private ListNode getListNodeFromTotal(System.Numerics.BigInteger total)
        {
            var numberString = total.ToString();
            return getListNodeFromTotalString(numberString);
        }

        private ListNode getListNodeFromTotalString(string total)
        {
            var lastChar = total.Last();
            var last = int.Parse(lastChar.ToString());

            var node = new ListNode(last);

            if (total.Length == 1)
            {
                return node;
            }

            var substr = total.Substring(0, total.Length - 1);

            node.next = getListNodeFromTotalString(substr!);

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
