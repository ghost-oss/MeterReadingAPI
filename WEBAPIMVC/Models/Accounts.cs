using System;
using System.ComponentModel.DataAnnotations;

namespace WEBAPIMVC.Models
{
    public class Accounts
    {
        [Key]
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
