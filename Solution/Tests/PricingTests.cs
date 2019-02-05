using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PricingTests
    {
        private const string A = "A";
        private const string B = "B";
        private const string C = "C";
        private const string D = "D";


        private static int getPrice(string item)
        {
            return -1;
        }

        private static int getPrice(params string[] items)
        {
            return -1;
        }

        [TestMethod]
        public void TestIndividualItems()
        {
            Assert.AreEqual(getPrice("A"), 50, "Price for a single A is wrong");
            Assert.AreEqual(getPrice("B"), 30, "Price for a single B is wrong");
            Assert.AreEqual(getPrice("C"), 20, "Price for a single C is wrong");
            Assert.AreEqual(getPrice("D"), 15, "Price for a single D is wrong");
        }

        [TestMethod]
        public void TestSeriesOfItems()
        {
            Assert.AreEqual(getPrice(A, B, C, D), 115, "Wrong total for A, B, C, D");
            Assert.AreEqual(getPrice(A, A, C, D), 135, "Wrong total for A, A, C, D");
            Assert.AreEqual(getPrice(A, B, B, D), 125, "Wrong total for A, B, B, D");
            Assert.AreEqual(getPrice(A, B, C, C), 120, "Wrong total for A, B, C, C");
        }

        [TestMethod]
        public void TestSpecialPrices()
        {
            Assert.AreEqual(getPrice(A, A, A), 130, "Wrong total for A, A, A");
            Assert.AreEqual(getPrice(B, B), 45, "Wrong total for B, B");
            Assert.AreEqual(getPrice(A, B, C, A, D, A, C), 130 + 30 + (20 * 2) + 15, "Wrong total for A, B, C, A, D, A, C");
            Assert.AreEqual(getPrice(A, B, C, A, D, A, B, C), 130 + 45 + (20 * 2) + 15, "Wrong total for A, B, C, A, D, A, B, C");
        }

        [TestMethod]
        public void TestMixedPrices()
        {
            Assert.AreEqual(getPrice(A, A, A, B, A), 130 + 30 + 50, "Wrong total for A, A, A, B, A");
            Assert.AreEqual(getPrice(B, B, C, B), 45 + 20 + 30, "Wrong total for B, B, C, B");

            Assert.AreEqual(getPrice(A, A, A, B, A, C, A, D, A, C), 130 + 30 + 130 + 20 + 15 + 20, "Wrong total for A, A, A, B, A, C, A, D, A, C");
            Assert.AreEqual(getPrice(B, B, A, B, B, D, B), 45 + 50 + 45 + 15 + 30, "Wrong total for B, B, A, B, B, D, B");

            Assert.AreEqual(getPrice(B, B, A, C, A, D, A), 45 + 130 + 20 + 15, "Wrong total for B, B, A, C, A, D, A");

        }

    }
}

/*
SKU Unit Price Special Price
A   50	        3 for 130
B	30	        2 for 45
C	20	
D	15	
*/
