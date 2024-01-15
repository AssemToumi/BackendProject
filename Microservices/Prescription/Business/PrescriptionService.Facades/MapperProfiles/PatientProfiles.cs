using AutoMapper;
using Be.Medsec.Api.Rest.Medsec.V1.Model;
using Prescription.Models.Entities;

namespace Prescription.Facades.MapperProfiles;

public class PatientProfiles : Profile {
    public PatientProfiles() {
        CreateMap<PatientEntity, PatientFullDataDTO>()
             .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.Id)); // Include Patient Id for GET

        CreateMap<PatientDTO, PatientEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore Patient Id for POST
    }
}
