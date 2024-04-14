using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Application.Validators;
using Persistence.Models;

namespace Application.Diseases.List;

public record ListDiseasesRequest()
{
    [Range(1, int.MaxValue), DefaultValue(1)]
    public int Page { get; init; }

    [Range(0, int.MaxValue), DefaultValue(10)]
    public int PageSize { get; init; }

    [AllowedValuesFromProperties(typeof(Disease))]
    [DefaultValue(nameof(Disease.Name))]
    public string? OrderBy { get; init; } = nameof(Disease.Name);

    public bool? OrderByDescending { get; init; }
}

public record ListDiseasesResponse(IEnumerable<DiseaseResponse> Diseases, long Count);

public record DiseaseResponse(long DiseaseId, string Name, string IcdCode);
