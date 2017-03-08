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

        [TestMethod]
        public void CallingLevenshtein_WithCakeToRake_ShouldReturn1()
        {
            var expected = 1;
            var actual = Distance.Levenshtein("cake", "rake");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithSofiaToSof_ShouldReturn2()
        {
            var expected = 2;
            var actual = Distance.Levenshtein("SOFIA", "SOF");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithKittenToSitting_ShouldReturn3()
        {
            var expected = 3;
            var actual = Distance.Levenshtein("kitten", "sitting");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithGoogleToLookat_ShouldReturn4()
        {
            var expected = 4;
            var actual = Distance.Levenshtein("google", "lookat");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithEmacsToVim_ShouldReturn5()
        {
            var expected = 5;
            var actual = Distance.Levenshtein("emacs", "vim");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithCoffeeToCocoa_ShouldReturn4()
        {
            var expected = 4;
            var actual = Distance.Levenshtein("coffee", "cocoa");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithMunichToMuenchen_ShouldReturn4()
        {
            var expected = 4;
            var actual = Distance.Levenshtein("Munich", "Muenchen");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithRosebudToBudrose_ShouldReturn6()
        {
            var expected = 6;
            var actual = Distance.Levenshtein("rosebud", "budrose");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithDecidedToDecisive_ShouldReturn4()
        {
            var expected = 4;
            var actual = Distance.Levenshtein("decided", "decisive");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallingLevenshtein_WithSimilarToSimile_ShouldReturn2()
        {
            var expected = 2;
            var actual = Distance.Levenshtein("similar", "simile");

            Assert.AreEqual(expected, actual);
        }
    }
}
