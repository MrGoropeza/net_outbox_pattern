using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Weekday
{
    public long WeekdayId { get; set; }

    public string Name { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<AlarmItem> AlarmItems { get; set; } = new List<AlarmItem>();
}
