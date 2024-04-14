using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class MedicenterFile
{
    public long FileId { get; set; }

    public string MimeType { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public long? DocumentId { get; set; }

    public decimal? FileSize { get; set; }

    public string CdnFileName { get; set; } = null!;

    public virtual Document? Document { get; set; }

    public virtual ICollection<Interest> Interests { get; set; } = new List<Interest>();

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
}
