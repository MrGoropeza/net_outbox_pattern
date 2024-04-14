using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class FamilyPathology
{
    public long FamilyPathologyId { get; set; }

    public bool IsCurrentDiagnosis { get; set; }

    public DateTime? DiagnosisInitialDate { get; set; }

    public DateTime? DiagnosisEndDate { get; set; }

    public long FamilyTypeId { get; set; }

    public long? DiseaseId { get; set; }

    public long? AllergyId { get; set; }

    public long UserProfileId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Allergy? Allergy { get; set; }

    public virtual Disease? Disease { get; set; }

    public virtual FamilyType FamilyType { get; set; } = null!;

    public virtual UserProfile UserProfile { get; set; } = null!;
}
