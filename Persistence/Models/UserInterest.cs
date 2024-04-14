using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class UserInterest
{
    public long UserInterestId { get; set; }

    public long UserProfileId { get; set; }

    public long InterestId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Interest Interest { get; set; } = null!;

    public virtual UserProfile UserProfile { get; set; } = null!;
}
