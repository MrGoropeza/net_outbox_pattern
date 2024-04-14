using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Folder
{
    public long FolderId { get; set; }

    public string Name { get; set; } = null!;

    public long UserProfileId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<UserPost> UserPosts { get; set; } = new List<UserPost>();

    public virtual UserProfile UserProfile { get; set; } = null!;
}
