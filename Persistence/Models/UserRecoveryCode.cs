using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class UserRecoveryCode
{
    public long UserRecoveryCodeId { get; set; }

    public string Code { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public long UserId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public long? CodeTypeId { get; set; }

    public virtual CodeType? CodeType { get; set; }

    public virtual User User { get; set; } = null!;
}
