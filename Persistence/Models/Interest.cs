using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Interest
{
    public long InterestId { get; set; }

    public string Name { get; set; } = null!;

    public long? FileId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual MedicenterFile? File { get; set; }

    public virtual ICollection<HealthTip> HealthTips { get; set; } = new List<HealthTip>();

    public virtual ICollection<UserInterest> UserInterests { get; set; } = new List<UserInterest>();
}
