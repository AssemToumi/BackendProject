using Microsoft.AspNetCore.Mvc;
using Helper;
using Be.Medsec.Api.Rest.Medsec.V1.Model;

namespace PrescriptionService.Controllers.V1.Abstractions
{
    [ApiController]
    public abstract class PatientApiController : ControllerBase
    {
        [HttpGet]
        [Route("/api/v1/Patients")]
        [ProducesResponseType(typeof(List<PatientDTO>), StatusCodes.Status200OK)]
        public abstract Task<IActionResult> GetAllPatients();


        [HttpPost]
        [Route("/api/v1/Patients")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public abstract Task<IActionResult> CreatePatient([FromBody] PatientDTO newPatient);
    }
}