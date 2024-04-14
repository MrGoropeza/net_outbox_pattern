using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Locality
{
    public long LocalityId { get; set; }

    public string Name { get; set; } = null!;

    public long StateId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual State State { get; set; } = null!;

    public virtual ICollection<UserProfile> UserProfileBirthplaceLocalities { get; set; } = new List<UserProfile>();

    public virtual ICollection<UserProfile> UserProfileResidencyLocalities { get; set; } = new List<UserProfile>();
}
