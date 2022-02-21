using WEBAPIMVC.JsonResponses;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace WEBAPIMVC_UnitTests
{
    [TestClass]
    public class MeterReadingValidationJsonResult_Tests
    {
        [TestMethod]
        public void Confirm_Serialize_Then_Desirialize_MeterReadingValidationResults()
        {
            //Arrange
            var expectedSuccessfulReadings = 5;
            var expectedFailedReadings = 3;

            var rootObj = new RootObject()
            {
                MeterReadingValidationJsonResponse = new MeterReadingValidationJsonResponse
                {
                    SuccessfulReadings = 5,
                    FailedReadings = 3
                    
                }
            };

            //Act
            var json = JsonConvert.SerializeObject(rootObj);
            var rootDeserializedObj = JsonConvert.DeserializeObject<RootObject>(json);

            //Assert
            Assert.AreEqual(expectedSuccessfulReadings, rootDeserializedObj.MeterReadingValidationJsonResponse.SuccessfulReadings);
            Assert.AreEqual(expectedFailedReadings, rootDeserializedObj.MeterReadingValidationJsonResponse.FailedReadings);

        }

    }
}
