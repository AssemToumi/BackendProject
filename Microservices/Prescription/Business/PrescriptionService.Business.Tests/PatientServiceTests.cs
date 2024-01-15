using Moq;
using Prescription.DataAccess.Abstractions;
using Prescription.DataAccess.Abstractions.Repositories;
using Prescription.Models.Entities;
using Xunit;

namespace Prescription.Business.Tests {
    public class PatientServiceTests {
        [Fact]
        public async Task CreatePatientAsync_ValidPatient_ReturnsPatient() {
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