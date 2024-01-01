using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Medication
    {
        [Key]
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<Order> Orders { get; set; }
    }
}
