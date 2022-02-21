using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using WEBAPIMVC.ValidationHelpers;
using WEBAPIMVC.Models;
using WEBAPIMVC.Interfaces;

namespace WEBAPIMVC.Data
{
    public class MeterReadingsSqlContext : IMeterReadingsSqlContext
    {
        public int InvalidEnteries { get; set; }
        public int ValidEnteries { get; set; }
        public ValidationHelper ValidationHelper { get; set; }
        private readonly MyDbContext dbContext;

        public MeterReadingsSqlContext(MyDbContext context)
        {
            dbContext = context;
            ValidationHelper = new ValidationHelper();
        }

        public void InsertMeterReadings(List<Meter_Readings> meterReadings)
        {
            using (dbContext)
            {
                var existingAccountIds = dbContext.Accounts.Select(x => x.AccountId).ToList();

                foreach (var reading in meterReadings)
                {
                    if (ValidationHelper.AccountExists(existingAccountIds,reading) && !ValidationHelper.DoesMeterEntryExist(dbContext.Meter_Readings,reading))
                    {
                        try
                        {
                            dbContext.Meter_Readings.Add(reading);
                            ValidEnteries += 1;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            InvalidEnteries += 1;
                        }

                    }
                    else
                    {
                        InvalidEnteries += 1;
                    }

                }

                dbContext.SaveChanges();
            }
        }

    }
}

