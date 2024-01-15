using Helper;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Abstractions.Repositories;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Contexts;
using PrescriptionService.Models.PrescriptionService.Model.Entities;

namespace PrescriptionService.DataAccess.PrescriptionService.DataAccess.Repositories;

[RegisterAsRepository]
public class PatientRepository : AbstractIdentifiableRepository<PatientEntity, int>, IPatientRepository
{
    public PatientRepository(PrescriptionDbContext medsecDbContext)
    : base(medsecDbContext)
    {
    }
}
