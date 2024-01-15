

using Be.Medsec.Api.Rest.Medsec.V1.Model;

namespace PrescriptionService.Business.PrescriptionService.Facades.Abstractions;

public interface IPatientFacade
{
    Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
    Task<PatientDTO> CreatePatientAsync(PatientDTO newPatient);
}