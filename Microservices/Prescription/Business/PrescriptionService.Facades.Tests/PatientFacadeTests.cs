global using Xunit;
using AutoMapper;
using Be.Medsec.Api.Rest.Medsec.V1.Model;
using Moq;
using Prescription.Business.Abstractions;
using Prescription.Models.Entities;

namespace Prescription.Facades.Tests {
    public class PatientFacadeTests {
        [Fact]
        public async Task GetAllPatientsAsync_ReturnsExpectedResult() {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var PatientServiceMock = new Mock<IPatientService>();

            // Set up the facade with mocked dependencies
            var facade = new PatientFacade(mapperMock.Object, PatientServiceMock.Object);

            // Mock the behavior of the PatientService to return the expected result
            PatientServiceMock.Setup(s => s.GetAllPatientsAsync()).ReturnsAsync(ExpectedPatientStockEntities());

            // Define test data
            var expectedPatients = new List<PatientEntity>();
            var expectedPatientDTOs = new List<PatientDTO>(); // Adjust the type as needed

            // Mock the mapping behavior
            mapperMock.Setup(m => m.Map<IEnumerable<PatientDTO>>(expectedPatients))
                      .Returns(expectedPatientDTOs);

            // Act
            var result = await facade.ListPatientsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<PatientDTO>>(result);
        }

        private static IEnumerable<PatientEntity> ExpectedPatientStockEntities() {
            return new List<PatientEntity>
            {
                new PatientEntity
                {
                    Id = 1,
                    FirstName = "n"
                },
                new PatientEntity
                {
                    Id = 2,
                    FirstName = "m",
                },
            };
        }


        [Fact]
        public async Task CreatePatientAsyncReturnsExpectedResult() {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var PatientServiceMock = new Mock<IPatientService>();

            // Set up the facade with mocked dependencies
            var facade = new PatientFacade(mapperMock.Object, PatientServiceMock.Object);

            // Define test data
            var newPatientDTO = new PatientDTO {
                FirstName = "GeneDrinks",
            };

            var expectedPatientEntity = new PatientEntity {
                Id = 1,
                FirstName = "GeneDrinks",
            };

            // Mock the behavior of the PatientService to return the expected result
            PatientServiceMock.Setup(s => s.CreatePatientAsync(It.IsAny<PatientEntity>()))
                                .ReturnsAsync(expectedPatientEntity);

            // Mock the mapping behavior
            mapperMock.Setup(m => m.Map<PatientEntity>(newPatientDTO))
                      .Returns(expectedPatientEntity);

            mapperMock.Setup(m => m.Map<PatientDTO>(expectedPatientEntity))
                      .Returns(newPatientDTO);

            // Act
            var result = await facade.CreatePatientAsync(newPatientDTO);

            // Assert
            Assert.NotNull(result);
        }
    }
}