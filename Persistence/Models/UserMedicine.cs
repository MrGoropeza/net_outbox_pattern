using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class UserMedicine
{
    public long UserMedicineId { get; set; }

    public long UserProfileId { get; set; }

    public long MedicineId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Medicine Medicine { get; set; } = null!;

    public virtual UserProfile UserProfile { get; set; } = null!;
}
