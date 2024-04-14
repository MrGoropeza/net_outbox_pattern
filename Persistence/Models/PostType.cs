using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class PostType
{
    public long PostTypeId { get; set; }

    public string Name { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<UserPost> UserPosts { get; set; } = new List<UserPost>();
}
