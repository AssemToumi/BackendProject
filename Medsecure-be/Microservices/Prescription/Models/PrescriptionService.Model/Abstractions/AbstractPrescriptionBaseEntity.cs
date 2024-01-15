using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Helper;

namespace PrescriptionService.Models.PrescriptionService.Model.Abstractions;

public abstract class AbstractPrescriptionBaseEntity : IIdentifiable<int>, ITrackable, IByOptimisticLockProtected
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CREATOR_ID")]
    public long CreatorId { get; set; }

    [Column("CREATION_DATE")]
    public DateTime CreationDate { get; set; }

    [Column("MODIFICATOR_ID")]
    public long ModificatorId { get; set; }

    [Column("MODIFICATION_DATE")]
    public DateTime ModificationDate { get; set; }

    [ConcurrencyCheck]
    [Column("ROW_VERSION")]
    public int RowVersion { get; set; }
}
