using System;
using WEBAPIMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration;

namespace WEBAPIMVC.Mappers
{
    public class MeterReadingsClassMap : ClassMap<Meter_Readings>
    {
        public MeterReadingsClassMap()
        {
            Map(m => m.AccountID).Name("AccountId");
            Map(m => m.MeterReadingDateTimeString).Name("MeterReadingDateTime");
            Map(m => m.MeterValue).Name("MeterReadValue");
        }
    }
}
