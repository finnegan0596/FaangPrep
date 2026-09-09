using NUnit.Framework;
using Problems;

namespace LeetCode.Tests
{
    public class LeetCode3_LengthOfLongestSubstring_Tests
    {
        [Test]
        public void Example1_Abcabcbb_Returns3()
        {
            var sut = new LeetCode3_LengthOfLongestSubstring();

            var result = sut.LengthOfLongestSubstring("abcabcbb");

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Example2_Bbbbb_Returns1()
        {
            var sut = new LeetCode3_LengthOfLongestSubstring();

            var result = sut.LengthOfLongestSubstring("bbbbb");

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Example3_Pwwkew_Returns3()
        {
            var sut = new LeetCode3_LengthOfLongestSubstring();

            var result = sut.LengthOfLongestSubstring("pwwkew");

            Assert.That(result, Is.EqualTo(3));
        }
    }
}
