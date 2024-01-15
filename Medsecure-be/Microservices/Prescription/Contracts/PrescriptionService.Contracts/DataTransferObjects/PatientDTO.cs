using System.Runtime.Serialization;

namespace PrescriptionService.Contracts.PrescriptionService.Contracts.DataTransferObjects
{
    [DataContract]
    public class PatientDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
