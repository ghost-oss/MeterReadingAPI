using System;
using Json.Net;
using Newtonsoft.Json;

namespace WEBAPIMVC.JsonResponses
{
    public class MeterReadingValidationJsonResponse
    {
        [JsonProperty("successfulReadings")]
        public int SuccessfulReadings { get; set; }

        [JsonProperty("failedReadings")]
        public int FailedReadings { get; set; }

        public MeterReadingValidationJsonResponse()
        {
        }
    }
}
