using Newtonsoft.Json;
using WEBAPIMVC.JsonResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIMVC.Interfaces;

namespace WEBAPIMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadingAPIController : ControllerBase
    {
        private readonly ICSVImport _csvImport;
        private readonly IMeterReadingsSqlContext _meterReadingSqlContext;

        public MeterReadingAPIController(IMeterReadingsSqlContext meterReadingSqlContext, ICSVImport CsvImport)
        {
            _csvImport = CsvImport;
            _meterReadingSqlContext = meterReadingSqlContext;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("meter-reading-uploads")]
        public IActionResult Post([FromForm] IFormFile file)
        {

            var meterReadingsObj = _csvImport.ProcessCSVFile(file);

            _meterReadingSqlContext.InsertMeterReadings(meterReadingsObj);

            var obj = new RootObject
            {
                MeterReadingValidationJsonResponse = new MeterReadingValidationJsonResponse()
                {
                    FailedReadings = _meterReadingSqlContext.InvalidEnteries + _csvImport.InvalidEnteries,
                    SuccessfulReadings = _meterReadingSqlContext.ValidEnteries

                }  
            };

            var jsonOutput = JsonConvert.SerializeObject(obj);

            return Ok(jsonOutput);
        }

    }
    
}






