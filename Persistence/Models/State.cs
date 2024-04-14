using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class State
{
    public long StateId { get; set; }

    public string Name { get; set; } = null!;

    public long CountryId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Locality> Localities { get; set; } = new List<Locality>();

    public virtual ICollection<UserProfile> UserProfileBirthplaceStates { get; set; } = new List<UserProfile>();

    public virtual ICollection<UserProfile> UserProfileResidencyStates { get; set; } = new List<UserProfile>();
}
