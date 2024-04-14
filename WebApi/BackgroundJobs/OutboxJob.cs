using Application.Users.SignUp;
using Newtonsoft.Json;
using Persistence;
using Quartz;

namespace WebApi.BackgroundJobs;

[DisallowConcurrentExecution]
public class OutboxJob(OutboxDbContext dbContext) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var jobKey = context.JobDetail.Key;

        var outboxMessage = dbContext.OutboxMessages.FirstOrDefault(
            x => x.OutboxMessageId == long.Parse(jobKey.Name)
        );

        if (outboxMessage is null)
            return;

        SignUpRequest? content = JsonConvert.DeserializeObject<SignUpRequest>(
            outboxMessage.Content
        );

        if (content is null)
            return;

        await Task.Delay(10 * 1000);

        Console.WriteLine($"Sended welcome email to '{content.Email}'.");
        outboxMessage.ProcessedAt = DateTime.UtcNow;

        dbContext.OutboxMessages.Update(outboxMessage);

        await dbContext.SaveChangesAsync();
    }
}
