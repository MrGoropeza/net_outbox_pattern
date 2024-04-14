using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class User
{
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Hash { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool IsVerified { get; set; }

    public virtual UserProfile? UserProfile { get; set; }

    public virtual ICollection<UserRecoveryCode> UserRecoveryCodes { get; set; } = new List<UserRecoveryCode>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
