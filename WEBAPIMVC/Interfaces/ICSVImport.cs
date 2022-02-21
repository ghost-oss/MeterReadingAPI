using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using WEBAPIMVC.Models;

namespace WEBAPIMVC.Interfaces
{
    public interface ICSVImport
    {
        int InvalidEnteries { get; set; }
        List<Meter_Readings> ProcessCSVFile(IFormFile file);
    }
}