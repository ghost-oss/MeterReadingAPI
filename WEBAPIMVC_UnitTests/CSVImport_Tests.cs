using Moq;
using Microsoft.AspNetCore.Http;
using WEBAPIMVC.FileImportHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Text;
using System;

namespace WEBAPIMVC_UnitTests
{
    [TestClass]
    public class CSVImport_Tests
    {

        [TestMethod]
        public void ProcessCSVFile_FromImport_ShouldCountCSVFilesCorrectly()
        {
            //Arrange
            var csvImport = new CSVImport();
            var csvFileMock = new Mock<IFormFile>();

            var fileName = "test.csv";

            var csvContent = new StringBuilder();
            csvContent.AppendLine("AccountId,MeterReadingDateTime,MeterReadValue");
            csvContent.AppendLine("3212,22/04/2019 09:24,8987");
            csvContent.AppendLine("2312,22/04/2019 09:24,1234");
            csvContent.AppendLine("1134,22/04/2019 09:24,3092");

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            streamWriter.Write(csvContent);
            streamWriter.Flush();
            memoryStream.Position = 0;

            csvFileMock.Setup(x => x.OpenReadStream()).Returns(memoryStream);
            csvFileMock.Setup(x => x.FileName).Returns(fileName);
            csvFileMock.Setup(x => x.Length).Returns(memoryStream.Length);

            var fileObj = csvFileMock.Object;
            var expecedTotalReadings = 3;

            //Act
            var csvTotalReadings = csvImport.ProcessCSVFile(fileObj);

            //Assert
            Assert.AreEqual(expecedTotalReadings, csvTotalReadings.Count());
        }

        [TestMethod]
        public void ProcessCSVFile_FromImport_ShouldFormatStringDateToDateTime()
        {
            //Arrange
            var csvImport = new CSVImport();
            var csvFileMock = new Mock<IFormFile>();
            var expectedDateFormat = new DateTime(2021, 12, 25, 10, 30,0);
            var fileName = "test.csv";

            var csvContent = new StringBuilder();
            csvContent.AppendLine("AccountId,MeterReadingDateTime,MeterReadValue");
            var test = expectedDateFormat.ToString();
            csvContent.AppendLine("3212,25/12/2021 10:30,8987");

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            streamWriter.Write(csvContent);
            streamWriter.Flush();
            memoryStream.Position = 0;

            csvFileMock.Setup(x => x.OpenReadStream()).Returns(memoryStream);
            csvFileMock.Setup(x => x.FileName).Returns(fileName);
            csvFileMock.Setup(x => x.Length).Returns(memoryStream.Length);

            var fileObj = csvFileMock.Object;

            //Act
            var csvTotalReadings = csvImport.ProcessCSVFile(fileObj);

            //Assert
            Assert.AreEqual(expectedDateFormat, csvTotalReadings[0].MeterReadingDateTime);
        }

        
    }
}

