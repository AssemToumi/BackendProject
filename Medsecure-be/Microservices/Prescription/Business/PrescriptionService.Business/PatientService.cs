using Helper;
using PrescriptionService.Business.PrescriptionService.Business.Abstractions;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Abstractions;
using PrescriptionService.Models.PrescriptionService.Model.Entities;

namespace PrescriptionService.Business.PrescriptionService.Business;

[RegisterAsService]
public class PatientService : AbstractService, IPatientService
{
    public PatientService(IPrescriptionUnitOfWork PrescriptionUnitOfWork)
        : base(PrescriptionUnitOfWork)
    {
    }

    public async Task<IEnumerable<PatientEntity>> GetAllPatientsAsync()
        => await PrescriptionUnitOfWork.PatientRepository.GetAllAsync();

    public async Task<PatientEntity> CreatePatientAsync(PatientEntity newPatient)
    {
        if (newPatient == null)
        {
            throw new ArgumentNullException(nameof(newPatient));
        }
        // Add the new Patient to the database
        await PrescriptionUnitOfWork.PatientRepository.AddAsync(newPatient);
        await PrescriptionUnitOfWork.SaveChangesAsync(); // Save changes to the database

        return newPatient;
    }
}
