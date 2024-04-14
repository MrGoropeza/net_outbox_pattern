using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Persistence.Models;
using Quartz;
using WebApi.Outbox;

namespace WebApi.BackgroundJobs;

public class OutboxDbContextInterceptor(ISchedulerFactory schedulerFactory) : SaveChangesInterceptor
{
    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default
    )
    {
        DbContext? dbContext = eventData.Context;

        if (dbContext is null)
        {
            return await base.SavedChangesAsync(eventData, result, cancellationToken);
        }

        var scheduler = await schedulerFactory.GetScheduler(cancellationToken);

        await dbContext.ChangeTracker
            .Entries<OutboxMessage>()
            .Where(
                r =>
                    r.State == EntityState.Unchanged
                    && r.Entity.ProcessedAt == null
                    && r.Entity.DeletedAt == null
            )
            .Select(r => r.Entity)
            .ScheduleOutboxMessages(scheduler, cancellationToken);

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }
}
