using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Diagnostic
{
    public long DiagnosticId { get; set; }

    public long UserPostId { get; set; }

    public string CreatorName { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual UserPost UserPost { get; set; } = null!;
}
