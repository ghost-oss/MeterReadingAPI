using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WEBAPIMVC.Models;

namespace WEBAPIMVC.ValidationHelpers
{
    public class ValidationHelper
    {

        public bool IsValidLength(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return value.Length < 6;
        }

        public bool IsParseableValue(string value)
        {
            var number = 0;
            return int.TryParse(value, out number);
        }

        public string PrefixValueIfRequired(string value)
        {
            return value.PadLeft(5,'0');
        }

        public bool DoesMeterEntryExist(DbSet<Meter_Readings> dbMeterReadings, Meter_Readings reading)
        {
            return dbMeterReadings.Any(x => x.AccountID == reading.AccountID && x.MeterReadingDateTime == reading.MeterReadingDateTime && x.MeterValue == reading.MeterValue);
        }

        public bool AccountExists(List<int> existingAccountIds, Meter_Readings reading )
        {
           return existingAccountIds.Contains(reading.AccountID);
        }
    }
}
