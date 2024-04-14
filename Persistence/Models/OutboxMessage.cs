using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class OutboxMessage
{
    public long OutboxMessageId { get; set; }

    public string Type { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? Error { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
