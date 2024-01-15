using Helper;
using AutoMapper;
using Be.Medsec.Api.Rest.Medsec.V1.Model;
using Prescription.Business.Abstractions;
using Prescription.Facades.Base;
using Prescription.Facades.Abstractions;
using Prescription.Models.Entities;

namespace Prescription.Facades {
    [RegisterAsFacade]
    public class PatientFacade : AbstractFacade, IPatientFacade {
        private readonly IPatientService _patientService;

        public PatientFacade(IMapper mapper, IPatientService patientService)
            : base(mapper) {
            _patientService = patientService;
        }

        public async Task<int> CreatePatientAsync(PatientDTO patientDTO) {
            var patientEntity = Mapper.Map<PatientEntity>(patientDTO);
            var createdPatientEntity = await _patientService.CreatePatientAsync(patientEntity);

            // Assuming that createdPatientEntity has a property for the new patient ID
            return createdPatientEntity.Id;
        }

        public async Task<bool> DeletePatientAsync(int patientId) {
            return await _patientService.DeletePatientAsync(patientId);
        }

        public async Task<PatientFullDataDTO> GetPatientAsync(int patientId) {
            var patientEntity = await _patientService.GetPatientAsync(patientId);
            return Mapper.Map<PatientFullDataDTO>(patientEntity);
        }

        public async Task<IEnumerable<PatientFullDataDTO>> ListPatientsAsync() {
            var patients = await _patientService.GetAllPatientsAsync();
            return Mapper.Map<IEnumerable<PatientFullDataDTO>>(patients);
        }

        public async Task<bool> UpdatePatientAsync(int patientId, PatientDTO patientDTO) {
            var patientEntity = Mapper.Map<PatientEntity>(patientDTO);
            return await _patientService.UpdatePatientAsync(patientId, patientEntity);
        }
    }
}
