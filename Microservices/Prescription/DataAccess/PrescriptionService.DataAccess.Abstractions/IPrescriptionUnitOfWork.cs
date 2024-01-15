using Prescription.DataAccess.Abstractions.Repositories;

namespace Prescription.DataAccess.Abstractions;

public interface IPrescriptionUnitOfWork {
    IPatientRepository PatientRepository { get; }
    Task<int> SaveChangesAsync();
}