using Microsoft.EntityFrameworkCore;
using Persistence;
using Quartz;
using WebApi.Outbox;

namespace WebApi.BackgroundJobs;

[DisallowConcurrentExecution]
public class OutboxStartupJob(OutboxDbContext dbContext, ISchedulerFactory schedulerFactory) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var scheduler = await schedulerFactory.GetScheduler(context.CancellationToken);

        var outboxMessages = await dbContext.OutboxMessages
            .Where(r => r.ProcessedAt == null && r.DeletedAt == null)
            .ToListAsync(context.CancellationToken);

        await outboxMessages.ScheduleOutboxMessages(scheduler, context.CancellationToken);
    }
}
