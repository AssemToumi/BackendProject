using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Abstractions;

namespace PrescriptionService.Business.PrescriptionService.Business.Abstractions
{
    public abstract class AbstractService
    {
        protected readonly IPrescriptionUnitOfWork PrescriptionUnitOfWork;

        protected AbstractService(IPrescriptionUnitOfWork PrescriptionUnitOfWork)
            => PrescriptionUnitOfWork = PrescriptionUnitOfWork;
    }
}
