using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPIMVC.Models
{
    public class Meter_Readings
    {
        [Key]
        public Guid Id { get; set; }

        [Column("accountID")]
        public int AccountID { get; set; }

        [Column(TypeName = "MeterValue")]
        public string MeterValue { get; set; }

        [Column(TypeName = "MeterReadingDateTime")]
        public DateTime MeterReadingDateTime { get; set; }

        [NotMapped]
        public string MeterReadingDateTimeString { get; set; }
    }
}
