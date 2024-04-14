using Application.Diseases.List;
using AutoMapper;
using Persistence.Models;

namespace Application.Diseases;

public class DiseasesMapper : Profile
{
    public DiseasesMapper()
    {
        CreateMap<Disease, DiseaseResponse>();
    }
}
