using Helper;
using Prescription.DataAccess.Abstractions.Repositories;
using Prescription.DataAccess.Contexts;
using Prescription.Models.Entities;

namespace Prescription.DataAccess.Repositories;

[RegisterAsRepository]
public class PatientRepository : AbstractIdentifiableRepository<PatientEntity, int>, IPatientRepository {
    public PatientRepository(PrescriptionDbContext medsecDbContext)
    : base(medsecDbContext) {
    }
}
