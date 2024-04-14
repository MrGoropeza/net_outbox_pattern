using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Document
{
    public long DocumentId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsFeatured { get; set; }

    public long FolderId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Comment { get; set; }

    public DateTime? StudyDate { get; set; }

    public long? DiseaseId { get; set; }

    public long? AllergyId { get; set; }

    public virtual Allergy? Allergy { get; set; }

    public virtual Disease? Disease { get; set; }

    public virtual Folder Folder { get; set; } = null!;

    public virtual ICollection<MedicenterFile> MedicenterFiles { get; set; } = new List<MedicenterFile>();

    public virtual ICollection<UserPost> UserPosts { get; set; } = new List<UserPost>();
}
