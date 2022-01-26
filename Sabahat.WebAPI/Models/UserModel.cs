using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sabahat.WebAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Vorname muss Buchstaben enthalten")]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Nachname muss Buchstaben enthalten")]
        public string LastName { get; set; }
        [RegularExpression("[0-9]{1,20}", ErrorMessage = "Postleitzahl muss eine Zahl sein.")]
        public string ZipCode { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Stadt muss Buchstaben enthalten")]
        public string City { get; set; }
        public string JobLevel { get; set; }

    }
}