using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class ToxicHabit
{
    public long ToxicHabitId { get; set; }

    public bool Alcoholism { get; set; }

    public bool Smoking { get; set; }

    public bool DrugAddiction { get; set; }

    public long UserProfileId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual UserProfile UserProfile { get; set; } = null!;
}
