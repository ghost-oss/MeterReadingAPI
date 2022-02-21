using System.Collections.Generic;
using WEBAPIMVC.Models;

namespace WEBAPIMVC.Interfaces
{
    public interface IMeterReadingsSqlContext
    {
        void InsertMeterReadings(List<Meter_Readings> meterReadings);
        public int InvalidEnteries { get; set; }
        public int ValidEnteries { get; set; }
    }
}