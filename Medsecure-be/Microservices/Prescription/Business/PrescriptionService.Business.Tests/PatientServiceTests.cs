using Moq;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Abstractions;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Abstractions.Repositories;
using PrescriptionService.Models.PrescriptionService.Model.Entities;
using Xunit;

namespace PrescriptionService.Business.PrescriptionService.Business.Tests {
    public class PatientServiceTests
    {
        [Fact]
        public async Task CreatePatientAsync_ValidPatient_ReturnsPatient()
        {
            // Arrange
            var PatientRepositoryMock = new Mock<IPatientRepository>();
            var unitOfWorkMock = new Mock<IPrescriptionUnitOfWork>();
            unitOfWorkMock.Setup(u => u.PatientRepository).Returns(PatientRepositoryMock.Object);

            var PatientService = new PatientService(unitOfWorkMock.Object);
            var newPatient = new PatientEntity();

            // Act
            var result = await PatientService.CreatePatientAsync(newPatient);

            // Assert
            Assert.NotNull(result);
            Assert.Same(newPatient, result);
        }
    }
}