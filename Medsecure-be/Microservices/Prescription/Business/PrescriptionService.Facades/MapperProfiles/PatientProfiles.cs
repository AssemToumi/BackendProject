using AutoMapper;
using Be.Medsec.Api.Rest.Medsec.V1.Model;
using PrescriptionService.Models.PrescriptionService.Model.Entities;

namespace PrescriptionService.Business.PrescriptionService.Facades.MapperProfiles;

public class PatientProfiles : Profile
{
    public PatientProfiles()
    {
        CreateMap<PatientEntity, PatientDTO>();
        //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)); // Include Patient Id for GET

        CreateMap<PatientDTO, PatientEntity>();
            //.ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore Patient Id for POST
    }
}
