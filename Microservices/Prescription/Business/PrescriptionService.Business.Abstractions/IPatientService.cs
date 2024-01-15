using Prescription.Models.Entities;

namespace Prescription.Business.Abstractions;

public interface IPatientService {
    Task<IEnumerable<PatientEntity>> GetAllPatientsAsync();
    Task<PatientEntity> GetPatientAsync(int patientId);
    Task<PatientEntity> CreatePatientAsync(PatientEntity newPatient);
    Task<bool> UpdatePatientAsync(int patientId, PatientEntity updatedPatient);
    Task<bool> DeletePatientAsync(int patientId);
}