global using Xunit;
using Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Prescription.DataAccess.Contexts;

namespace Prescription.DataAccess.Tests {
    public class PrescriptionUnitOfWorkTests {
        [Fact]
        public async Task SaveChangesAsync_ShouldCallDbContextSaveChangesAsync() {
            // Arrange
            var options = new DbContextOptionsBuilder<PrescriptionSqlServerDbContext>()
                .UseMsSqlServerProvider("Server=MSCNUR1888004;Database=PrescriptionDB;Trusted_Connection=True;MultipleActiveResultSets=true");

            var dbContextMock = new Mock<PrescriptionSqlServerDbContext>(options);


            var brewRepositoryMock = new Mock<IServiceProvider>();

            dbContextMock.Setup(d => d.SaveChangesAsync(default)).ReturnsAsync(1); // Simulate a successful save

            var unitOfWork = new PrescriptionUnitOfWork(dbContextMock.Object, brewRepositoryMock.Object);

            // Act
            await unitOfWork.SaveChangesAsync();

            // Assert
            dbContextMock.Verify(d => d.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public void Dispose_ShouldDisposeDbContext() {
            // Arrange
            var options = new DbContextOptionsBuilder<PrescriptionDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContextMock = new Mock<PrescriptionDbContext>(options);
            var brewRepositoryMock = new Mock<IServiceProvider>();

            var unitOfWork = new PrescriptionUnitOfWork(dbContextMock.Object, brewRepositoryMock.Object);

            // Act
            unitOfWork.Dispose();

            // Assert
            dbContextMock.Verify(d => d.Dispose(), Times.Once);
        }

    }
}