using Helper;
using PrescriptionService.Models.PrescriptionService.Model.Entities;

namespace PrescriptionService.DataAccess.PrescriptionService.DataAccess.Abstractions.Repositories;

public interface IPatientRepository : IAbstractIdentifiableRepository<PatientEntity, int>
{
}

