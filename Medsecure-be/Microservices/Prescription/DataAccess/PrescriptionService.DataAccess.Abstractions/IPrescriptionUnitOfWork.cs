using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Abstractions.Repositories;

namespace PrescriptionService.DataAccess.PrescriptionService.DataAccess.Abstractions;

public interface IPrescriptionUnitOfWork
{
    IPatientRepository PatientRepository { get; }
    Task<int> SaveChangesAsync();
}