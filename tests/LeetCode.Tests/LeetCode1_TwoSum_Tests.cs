using NUnit.Framework;
using Problems;

namespace LeetCode.Tests
{
    public class LeetCode1_TwoSum_Tests
    {
        [Test]
        public void Example1_ReturnsExpectedIndices()
        {
            var sut = new LeetCode1_TwoSum();
            var res = sut.TwoSum(new[] {2,7,11,15}, 9);
            Assert.AreEqual(2, res.Length); // two indices
            Assert.AreEqual(0, res[0]);
            Assert.AreEqual(1, res[1]);
        }
    }
}
