using NUnit.Framework;
using Problems;

namespace LeetCode.Tests
{
    public class LeetCode4_MedianOfTwoSortedArrays_Tests
    {
        [Test]
        public void Example1_ReturnsMedian2()
        {
            var sut = new LeetCode4_MedianOfTwoSortedArrays();
            var res = sut.FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2 });
            Assert.AreEqual(2.0, res, 1e-9);
        }

        [Test]
        public void Example2_ReturnsMedian2Point5()
        {
            var sut = new LeetCode4_MedianOfTwoSortedArrays();
            var res = sut.FindMedianSortedArrays(new[] { 1, 2 }, new[] { 3, 4 });
            Assert.AreEqual(2.5, res, 1e-9);
        }
    }
}
