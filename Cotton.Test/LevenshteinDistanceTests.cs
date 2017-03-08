namespace Cotton.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cotton.Engine;

    [TestClass]
    public class LevenshteinDistanceTests
    {
        [TestMethod]
        public void CallingLevenshtein_WithEmptyStringToEmptyString_ShouldReturn0()
        {
            var expected = 0;
            var actual = Distance.Levenshtein(string.Empty, string.Empty);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithEmptyStringToAbc_ShouldReturn3()
        {
            var expected = 3;
            var actual = Distance.Levenshtein(string.Empty, "abc");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithAbcToEmptyString_ShouldReturn3()
        {
            var expected = 3;
            var actual = Distance.Levenshtein("abc", string.Empty);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithHomeToHome_ShouldReturn0()
        {
            var expected = 0;
            var actual = Distance.Levenshtein("home", "home");

            Assert.AreEqual(expected, actual);
        }
    }
}
