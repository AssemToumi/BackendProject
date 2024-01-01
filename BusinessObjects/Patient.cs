using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Patient

    {
        [Key]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientCountry { get; set; }
        public string PatientCity { get; set; }
        public string PatientZipCode { get; set; }
    }
}
