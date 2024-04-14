using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class UserHealthMetric
{
    public long UserHealthMetricId { get; set; }

    public decimal Value { get; set; }

    public decimal? Value2 { get; set; }

    public long HealthMetricId { get; set; }

    public long HealthMetricUnitId { get; set; }

    public long UserProfileId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual HealthMetric HealthMetric { get; set; } = null!;

    public virtual HealthMetricUnit HealthMetricUnit { get; set; } = null!;

    public virtual UserProfile UserProfile { get; set; } = null!;
}
