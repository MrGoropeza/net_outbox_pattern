using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class AlarmItem
{
    public long AlarmItemId { get; set; }

    public DateTimeOffset Time { get; set; }

    public long AlarmId { get; set; }

    public long WeekdayId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Alarm Alarm { get; set; } = null!;

    public virtual Weekday Weekday { get; set; } = null!;
}
