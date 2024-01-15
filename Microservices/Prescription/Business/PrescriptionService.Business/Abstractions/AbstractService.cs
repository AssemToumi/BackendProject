using Prescription.DataAccess.Abstractions;

namespace Prescription.Business.Abstractions {
    public abstract class AbstractService {
        protected readonly IPrescriptionUnitOfWork PrescriptionUnitOfWork;

        protected AbstractService(IPrescriptionUnitOfWork prescriptionUnitOfWork)
            => PrescriptionUnitOfWork = prescriptionUnitOfWork;
    }
}
