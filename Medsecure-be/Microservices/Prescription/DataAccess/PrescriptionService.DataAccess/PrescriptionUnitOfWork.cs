
using Microsoft.Extensions.DependencyInjection;
using Helper;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Abstractions;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Contexts;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Abstractions.Repositories;

namespace PrescriptionService.DataAccess.PrescriptionService.DataAccess;

[RegisterAsService(ServiceLifetime.Scoped)]
public class PrescriptionUnitOfWork : IPrescriptionUnitOfWork, IDisposable
{
    private readonly PrescriptionDbContext _medsecDbContext;
    private bool _disposed;

    public PrescriptionUnitOfWork(PrescriptionDbContext medbacDbContext, IServiceProvider serviceProvider)
    {
        _medsecDbContext = medbacDbContext;
        PatientRepository = serviceProvider.GetRequiredService<IPatientRepository>();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
   
    public IPatientRepository PatientRepository { get; }

    public async Task<int> SaveChangesAsync()
        => await _medsecDbContext.SaveChangesAsync();

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _medsecDbContext.Dispose();
            }
        }

        _disposed = true;
    }

}
