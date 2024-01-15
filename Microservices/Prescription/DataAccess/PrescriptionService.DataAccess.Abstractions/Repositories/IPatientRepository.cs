using Helper;
using Prescription.Models.Entities;

namespace Prescription.DataAccess.Abstractions.Repositories;

public interface IPatientRepository : IAbstractIdentifiableRepository<PatientEntity, int> {
}

