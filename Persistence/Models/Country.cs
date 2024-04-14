using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Country
{
    public long CountryId { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneCode { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<State> States { get; set; } = new List<State>();

    public virtual ICollection<UserProfile> UserProfileBirthplaceCountries { get; set; } = new List<UserProfile>();

    public virtual ICollection<UserProfile> UserProfileResidencyCountries { get; set; } = new List<UserProfile>();
}
