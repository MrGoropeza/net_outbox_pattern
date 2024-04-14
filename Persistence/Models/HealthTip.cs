using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class HealthTip
{
    public long HealthTipId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public long InterestId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Interest Interest { get; set; } = null!;
}
