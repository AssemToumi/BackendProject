using System.ComponentModel.DataAnnotations.Schema;
using Prescription.Models.Abstractions;

namespace Prescription.Models.Entities {
    [Table("MS_Patient")]
    public class PatientEntity : AbstractPrescriptionBaseEntity {
        [Column("FIRSTNAME")]
        public string? FirstName { get; set; }

        [Column("LASTNAME")]
        public string? LastName { get; set; }

        [Column("AGE")]
        public int Age { get; set; }
    }
}

