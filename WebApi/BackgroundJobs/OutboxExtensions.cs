using Persistence.Models;
using Quartz;
using WebApi.BackgroundJobs;

namespace WebApi.Outbox;

public static class OutboxExtensions
{
    public static async Task ScheduleOutboxMessages(
        this IEnumerable<OutboxMessage> outboxMessages,
        IScheduler scheduler,
        CancellationToken cancellationToken = default
    )
    {
        var jobs = outboxMessages
            .Select(
                r =>
                    JobBuilder
                        .Create<OutboxJob>()
                        .WithIdentity(name: r.OutboxMessageId.ToString(), group: r.Type)
                        .Build()
            )
            .ToList();

        foreach (var job in jobs)
        {
            if (await scheduler.CheckExists(job.Key, cancellationToken))
            {
                continue;
            }

            await scheduler.ScheduleJob(
                job,
                TriggerBuilder.Create().StartNow().Build(),
                cancellationToken
            );
        }
    }
}
