using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Allergy
{
    public long AllergyId { get; set; }

    public string Name { get; set; } = null!;

    public string IcdCode { get; set; } = null!;

    public long? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<FamilyPathology> FamilyPathologies { get; set; } = new List<FamilyPathology>();

    public virtual ICollection<UserPathology> UserPathologies { get; set; } = new List<UserPathology>();
}
