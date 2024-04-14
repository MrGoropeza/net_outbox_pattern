using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class UserProfile
{
    public long UserProfileId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public string? Phone { get; set; }

    public string? Occupation { get; set; }

    public long UserId { get; set; }

    public long? GenderId { get; set; }

    public long? BloodTypeId { get; set; }

    public long? BloodFactorId { get; set; }

    public long? HealthInsuranceId { get; set; }

    public long? FileId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public long? BirthplaceLocalityId { get; set; }

    public long? ResidencyLocalityId { get; set; }

    public long? BirthplaceCountryId { get; set; }

    public long? BirthplaceStateId { get; set; }

    public long? ResidencyCountryId { get; set; }

    public long? ResidencyStateId { get; set; }

    public string? PhoneCountryId { get; set; }

    public virtual ICollection<Alarm> Alarms { get; set; } = new List<Alarm>();

    public virtual Country? BirthplaceCountry { get; set; }

    public virtual Locality? BirthplaceLocality { get; set; }

    public virtual State? BirthplaceState { get; set; }

    public virtual BloodFactor? BloodFactor { get; set; }

    public virtual BloodType? BloodType { get; set; }

    public virtual ICollection<FamilyPathology> FamilyPathologies { get; set; } = new List<FamilyPathology>();

    public virtual MedicenterFile? File { get; set; }

    public virtual ICollection<Folder> Folders { get; set; } = new List<Folder>();

    public virtual Gender? Gender { get; set; }

    public virtual HealthInsurance? HealthInsurance { get; set; }

    public virtual Country? ResidencyCountry { get; set; }

    public virtual Locality? ResidencyLocality { get; set; }

    public virtual State? ResidencyState { get; set; }

    public virtual ToxicHabit? ToxicHabit { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserHealthMetric> UserHealthMetrics { get; set; } = new List<UserHealthMetric>();

    public virtual ICollection<UserInterest> UserInterests { get; set; } = new List<UserInterest>();

    public virtual ICollection<UserMedicine> UserMedicines { get; set; } = new List<UserMedicine>();

    public virtual ICollection<UserPathology> UserPathologies { get; set; } = new List<UserPathology>();

    public virtual ICollection<UserPost> UserPosts { get; set; } = new List<UserPost>();

    public virtual ICollection<UserStep> UserSteps { get; set; } = new List<UserStep>();
}
