using Helper;
using Prescription.Business.Abstractions;
using Prescription.DataAccess.Abstractions;
using Prescription.Models.Entities;

namespace Prescription.Business {
    [RegisterAsService]
    public class PatientService : AbstractService, IPatientService {
        public PatientService(IPrescriptionUnitOfWork prescriptionUnitOfWork)
            : base(prescriptionUnitOfWork) {
        }

        public async Task<IEnumerable<PatientEntity>> GetAllPatientsAsync() {
            return await PrescriptionUnitOfWork.PatientRepository.GetAllAsync();
        }

        public async Task<PatientEntity> GetPatientAsync(int patientId) {
            return await PrescriptionUnitOfWork.PatientRepository.GetByIdAsync(patientId);
        }

        public async Task<PatientEntity> CreatePatientAsync(PatientEntity newPatient) {
            if (newPatient == null) {
                throw new ArgumentNullException(nameof(newPatient));
            }

            // Add the new Patient to the database
            await PrescriptionUnitOfWork.PatientRepository.AddAsync(newPatient);
            await PrescriptionUnitOfWork.SaveChangesAsync(); // Save changes to the database

            return newPatient;
        }

        public async Task<bool> UpdatePatientAsync(int patientId, PatientEntity updatedPatient) {
            if (updatedPatient == null) {
                throw new ArgumentNullException(nameof(updatedPatient));
            }

            // Retrieve the existing patient
            var existingPatient = await PrescriptionUnitOfWork.PatientRepository.GetByIdAsync(patientId);
            if (existingPatient == null) {
                return false; // Patient not found
            }

            // Update patient properties
            existingPatient.FirstName = updatedPatient.FirstName; // Replace with actual properties
            existingPatient.LastName = updatedPatient.LastName; // Replace with actual properties

            // Save changes to the database
            await PrescriptionUnitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePatientAsync(int patientId) {
            var patientToDelete = await PrescriptionUnitOfWork.PatientRepository.GetByIdAsync(patientId);

            if (patientToDelete == null) {
                return false; // Patient not found
            }

            // Delete the patient from the database
            PrescriptionUnitOfWork.PatientRepository.Delete(patientToDelete);
            await PrescriptionUnitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
