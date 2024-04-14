using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Alarm
{
    public long AlarmId { get; set; }

    public bool IsEnabled { get; set; }

    public string? AppointmentReason { get; set; }

    public string? AppointmentComment { get; set; }

    public decimal? AppointmentLat { get; set; }

    public decimal? AppointmentLong { get; set; }

    public string? AppointmentAddress { get; set; }

    public long UserProfileId { get; set; }

    public long AlarmTypeId { get; set; }

    public long? MedicineId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<AlarmItem> AlarmItems { get; set; } = new List<AlarmItem>();

    public virtual AlarmType AlarmType { get; set; } = null!;

    public virtual Medicine? Medicine { get; set; }

    public virtual UserProfile UserProfile { get; set; } = null!;
}
