using Helper;
using AutoMapper;
using PrescriptionService.Business.PrescriptionService.Business.Abstractions;
using PrescriptionService.Business.PrescriptionService.Facades.Abstractions;
using PrescriptionService.Business.PrescriptionService.Facades.Base;
using PrescriptionService.Models.PrescriptionService.Model.Entities;
using Be.Medsec.Api.Rest.Medsec.V1.Model;

namespace PrescriptionService.Business.PrescriptionService.Facades;

[RegisterAsFacade]
public class PatientFacade : AbstractFacade, IPatientFacade {
    private readonly IPatientService _PatientsService;

    public PatientFacade(IMapper mapper, IPatientService Patientservice)
        : base(mapper)
    {
        _PatientsService = Patientservice;
    }

    public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync()
    {
        var Patients = await _PatientsService.GetAllPatientsAsync();
        return Mapper.Map<IEnumerable<PatientDTO>>(Patients);
    }
    public async Task<PatientDTO> CreatePatientAsync(PatientDTO newPatient)
    {
        var PatientEntity = Mapper.Map<PatientEntity>(newPatient);
        var createdPatientEntity = await _PatientsService.CreatePatientAsync(PatientEntity);

        var PatientDTO = Mapper.Map<PatientDTO>(createdPatientEntity);
        return PatientDTO;
    }
}