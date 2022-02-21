using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using WEBAPIMVC.Mappers;
using WEBAPIMVC.Models;
using WEBAPIMVC.Interfaces;
using WEBAPIMVC.ValidationHelpers;

namespace WEBAPIMVC.FileImportHelper
{
    public class CSVImport : ICSVImport
    {
        public int InvalidEnteries { get; set; }
        public ValidationHelper _validationHelper { get; set; }

        public CSVImport()
        {
            _validationHelper = new ValidationHelper();
        }

        public List<Meter_Readings> ProcessCSVFile(IFormFile file)
        {
            var meterReadings = new List<Meter_Readings>();

            using (var csvReader = new CsvReader(new StreamReader(file.OpenReadStream()), CultureInfo.InvariantCulture))
            {
                while (csvReader.Read())
                {
                    try
                    {
                        csvReader.Context.RegisterClassMap<MeterReadingsClassMap>();
                        var meterRecord = csvReader.GetRecord<Meter_Readings>();

                        if(_validationHelper.IsParseableValue(meterRecord.MeterValue) && _validationHelper.IsValidLength(meterRecord.MeterValue))
                        {
                            meterRecord.MeterValue = _validationHelper.PrefixValueIfRequired(meterRecord.MeterValue);
                            this.ConvertCsvReadingDateFormat(meterRecord);

                            meterReadings.Add(meterRecord);
                        }
                        else
                        {

                            InvalidEnteries += 1;
                        }

                    }
                    catch (CsvHelperException e)
                    {
                        Console.WriteLine(e.Message);
                        InvalidEnteries += 1;
                    }
                }
            }

            return meterReadings;
        }

        private void ConvertCsvReadingDateFormat(Meter_Readings reading)
        {
            reading.MeterReadingDateTime = DateTime.ParseExact(reading.MeterReadingDateTimeString, "dd/MM/yyyy HH:m", CultureInfo.InvariantCulture);
            reading.Id = Guid.NewGuid();
        }

    }
}
