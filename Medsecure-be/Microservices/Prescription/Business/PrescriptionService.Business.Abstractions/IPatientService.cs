using PrescriptionService.Models.PrescriptionService.Model.Entities;

namespace PrescriptionService.Business.PrescriptionService.Business.Abstractions;

public interface IPatientService
{
    Task<IEnumerable<PatientEntity>> GetAllPatientsAsync();
    Task<PatientEntity> CreatePatientAsync(PatientEntity newPatient);
}