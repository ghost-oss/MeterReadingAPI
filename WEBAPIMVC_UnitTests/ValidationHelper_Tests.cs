using Microsoft.VisualStudio.TestTools.UnitTesting;
using WEBAPIMVC.ValidationHelpers;
using WEBAPIMVC.Models;
using System;
using System.Collections.Generic;

namespace WEBAPIMVC_UnitTests
{
    [TestClass]
    public class ValidationHelper_Tests
    {
        private ValidationHelper _validationHelper { get; set; }

        public ValidationHelper_Tests()
        {
            _validationHelper = new ValidationHelper();
        }

        [TestMethod]
        [DataRow("123")]
        [DataRow("2123")]
        [DataRow("21233")]
        [DataRow("0")]
        public void IsValidLength_ValidLengthValues_ShouldReturnTrue(string value)
        {
            Assert.IsTrue(_validationHelper.IsValidLength(value));
        }

        [TestMethod]
        [DataRow(" ")]
        [DataRow("2123213")]
        [DataRow("")]
        public void IsValidLength_InvalidLengthValues_ShouldReturnFalse(string value)
        {
            Assert.IsFalse(_validationHelper.IsValidLength(value));
        }


        [TestMethod]
        [DataRow("9999")]
        [DataRow("2321")]
        [DataRow("0")]
        public void IsParasable_Integers_ShouldReturnTrue(string value)
        {
            Assert.IsTrue(_validationHelper.IsParseableValue(value));
        }


        [TestMethod]
        [DataRow("-212312")]
        [DataRow("Void")]
        [DataRow("v")]
        public void IsParasable_NotIntegers_ShouldReturnFalse(string value)
        {
            Assert.IsFalse(_validationHelper.IsParseableValue(value));
        }

        [TestMethod]
        public void PrefixValueIfRequired_ValuesLessThanFivesChars_ShouldInsertPadding()
        {
            var beforePaddedValue = "52";
            var expected = "00052";

            var afterPaddedValue = _validationHelper.PrefixValueIfRequired(beforePaddedValue);

            Assert.AreEqual(expected,afterPaddedValue);
        }

        [TestMethod]
        public void PrefixValueIfRequired_ValuesWhichIsFiveChars_ShoulNotInsertPadding()
        {
            var beforePaddedValue = "52938";
            var expected = "52938";

            var afterPaddedValue = _validationHelper.PrefixValueIfRequired(beforePaddedValue);

            Assert.AreEqual(expected, afterPaddedValue);
        }

        [TestMethod]
        public void AccountExists_ValidAccount_ShouldReturnTrue()
        {
            var existingAccountIds = new List<int>() { 2532, 2231, 4492 };

            var dateTimeOfReading = new DateTime(2021,12,25,10,30,50);
            var reading = new Meter_Readings() { AccountID = 2532, MeterReadingDateTime = dateTimeOfReading, MeterValue = "9999" };

            var result = _validationHelper.AccountExists(existingAccountIds, reading);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void AccountExists_InvalidAccount_ShouldReturnFalse()
        {
            var existingAccountIds = new List<int>() { 2532, 2231, 4492 };

            var dateTimeOfReading = new DateTime(2021, 12, 25, 10, 30, 50);
            var reading = new Meter_Readings() { AccountID = 1232, MeterReadingDateTime = dateTimeOfReading, MeterValue = "9999" };

            var result = _validationHelper.AccountExists(existingAccountIds, reading);

            Assert.IsFalse(result);

        }

    }
}
