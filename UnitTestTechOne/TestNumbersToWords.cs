using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechOneAssessment.Controllers;
using TechOneAssessment.Models;

namespace UnitTestTechOne
{
    [TestClass]
    public class TestNumbersToWords
    {
        [TestMethod]
        public void TestConvertToWords()
        {
            string words = NumbersToWords.ConvertToWords(10);

            Assert.AreEqual(words, " ten dollars ");
        }

        [TestMethod]
        public void TestDecimals()
        {
            string words = NumbersToWords.ConvertToWords(10.98);

            Assert.AreEqual(words, " ten dollars and ninety eight cents");
        }

        [TestMethod]
        public void TestClassValidationLower()
        {
            string words = NumbersToWords.ConvertToWords(-12);

            Assert.AreEqual(words, "Invalid Number");
        }

        [TestMethod]
        public void TestClassValidationUpper()
        {
            string words = NumbersToWords.ConvertToWords(1000000000000001);

            Assert.AreEqual(words, "Invalid Number");
        }
    }
}
