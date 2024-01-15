
using Be.Medsec.Api.Rest.Medsec.V1.Model;
using Microsoft.AspNetCore.Mvc;
using PrescriptionService.Business.PrescriptionService.Facades.Abstractions;
using PrescriptionService.Controllers.V1.Abstractions;
public class PatientController : PatientApiController {
    private readonly IPatientFacade _PatientFacade;

    public PatientController(IPatientFacade PatientFacade)
        => _PatientFacade = PatientFacade;

    public override async Task<IActionResult> GetAllPatients()
    => Ok(await _PatientFacade.GetAllPatientsAsync());

    public override async Task<IActionResult> CreatePatient([FromBody] PatientDTO newPatient)
     => Ok(await _PatientFacade.CreatePatientAsync(newPatient));
}