
using Be.Medsec.Api.Rest.Medsec.V1.Api;
using Be.Medsec.Api.Rest.Medsec.V1.Model;
using Microsoft.AspNetCore.Mvc;
using Prescription.Facades.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace PrescriptionService.Controllers.V1 {

    /// <summary>
    /// Controller for managing patient-related operations.
    /// </summary>
    public class PatientController : PatientApiController {
        private readonly IPatientFacade _patientFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientController"/> class.
        /// </summary>
        /// <param name="patientFacade">The patient facade to delegate operations to.</param>
        public PatientController(IPatientFacade patientFacade) {
            _patientFacade = patientFacade;
        }

        /// <summary>
        /// Creates a new patient.
        /// </summary>
        /// <param name="patientDTO">The data for the new patient.</param>
        /// <returns>Returns the created patient's information with a status code of 201 (Created).</returns>
        public override async Task<IActionResult> CreatePatient([FromBody] PatientDTO patientDTO) {
            var createdPatientId = await _patientFacade.CreatePatientAsync(patientDTO);
            return CreatedAtAction(nameof(GetPatient), new { patientId = createdPatientId }, null);
        }

        /// <summary>
        /// Deletes a patient by their identifier.
        /// </summary>
        /// <param name="patientId">The identifier of the patient to delete.</param>
        /// <returns>Returns a status code of 204 (No Content) if the patient is successfully deleted; otherwise, returns 404 (Not Found).</returns>
        public override async Task<IActionResult> DeletePatient([FromRoute(Name = "patientId"), Required] int patientId) {
            var result = await _patientFacade.DeletePatientAsync(patientId);
            return result ? NoContent() : NotFound();
        }

        /// <summary>
        /// Retrieves a patient by their identifier.
        /// </summary>
        /// <param name="patientId">The identifier of the patient to retrieve.</param>
        /// <returns>Returns the patient's information with a status code of 200 (OK) if found; otherwise, returns 404 (Not Found).</returns>
        public override async Task<IActionResult> GetPatient([FromRoute(Name = "patientId"), Required] int patientId) {
            var patient = await _patientFacade.GetPatientAsync(patientId);
            return patient != null ? Ok(patient) : NotFound();
        }

        /// <summary>
        /// Retrieves a list of all patients.
        /// </summary>
        /// <returns>Returns a list of patients with a status code of 200 (OK).</returns>
        public override async Task<IActionResult> ListPatients() {
            var patients = await _patientFacade.ListPatientsAsync();
            return Ok(patients);
        }

        /// <summary>
        /// Updates an existing patient by their identifier.
        /// </summary>
        /// <param name="patientId">The identifier of the patient to update.</param>
        /// <param name="patientDTO">The updated data for the patient.</param>
        /// <returns>Returns a status code of 204 (No Content) if the patient is successfully updated; otherwise, returns 404 (Not Found).</returns>
        public override async Task<IActionResult> UpdatePatient([FromRoute(Name = "patientId"), Required] int patientId, [FromBody] PatientDTO patientDTO) {
            var result = await _patientFacade.UpdatePatientAsync(patientId, patientDTO);
            return result ? NoContent() : NotFound();
        }
    }
}
