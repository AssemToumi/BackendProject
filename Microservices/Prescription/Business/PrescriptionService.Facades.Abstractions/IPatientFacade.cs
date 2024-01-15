
using Be.Medsec.Api.Rest.Medsec.V1.Model;

namespace Prescription.Facades.Abstractions;

public interface IPatientFacade {
    Task<int> CreatePatientAsync(PatientDTO patientDTO);
    Task<bool> DeletePatientAsync(int patientId);
    Task<PatientFullDataDTO> GetPatientAsync(int patientId);
    Task<IEnumerable<PatientFullDataDTO>> ListPatientsAsync();
    Task<bool> UpdatePatientAsync(int patientId, PatientDTO patientDTO);
}