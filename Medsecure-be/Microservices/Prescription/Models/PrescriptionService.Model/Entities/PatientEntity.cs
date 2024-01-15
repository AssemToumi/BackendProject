using System.ComponentModel.DataAnnotations.Schema;
using PrescriptionService.Models.PrescriptionService.Model.Abstractions;

namespace PrescriptionService.Models.PrescriptionService.Model.Entities
{
    [Table("MS_Patient")]
    public class PatientEntity : AbstractPrescriptionBaseEntity
    {
        [Column("NAME")]
        public string Name { get; set; }
    }
}

