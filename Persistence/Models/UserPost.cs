using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class UserPost
{
    public long UserPostId { get; set; }

    public bool IsEnabled { get; set; }

    public string? Comment { get; set; }

    public long UserProfileId { get; set; }

    public long PostTypeId { get; set; }

    public long PostShareTypeId { get; set; }

    public long? DocumentId { get; set; }

    public long? FolderId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public long Views { get; set; }

    public DateTime? LastSeen { get; set; }

    public Guid PostUuid { get; set; }

    public string? Name { get; set; }

    public long? HealthMetricId { get; set; }

    public virtual ICollection<Diagnostic> Diagnostics { get; set; } = new List<Diagnostic>();

    public virtual Document? Document { get; set; }

    public virtual Folder? Folder { get; set; }

    public virtual PostShareType PostShareType { get; set; } = null!;

    public virtual PostType PostType { get; set; } = null!;

    public virtual UserProfile UserProfile { get; set; } = null!;
}
