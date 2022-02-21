using System;
using Json.Net;
using WEBAPIMVC.JsonResponses;
using Newtonsoft.Json;

namespace WEBAPIMVC.JsonResponses
{
    public class RootObject
    {
        [JsonProperty("MeterReadingValidationJsonResponse")]
        public  MeterReadingValidationJsonResponse  MeterReadingValidationJsonResponse { get; set; }
    }
}
