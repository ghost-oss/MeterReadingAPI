using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WEBAPIMVC.Models
{
    public class Accounts
    {
        [Key]
        public int AccountId { get; set; }
        [Column(TypeName = "firstname")]
        public string FirstName { get; set; }
        [Column(TypeName = "lastname")]
        public string LastName { get; set; }
    }
}
