using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleAppWithDIAndLogger
{
    public interface IGreetingService
    {
        void Execute();
    }

    public class GreetingService : IGreetingService
    {
        private readonly ILogger<GreetingService> logger;
        private readonly IConfiguration configuration;

        public GreetingService(ILogger<GreetingService> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        public void Execute()
        {
            var developer = configuration.GetValue<string>("Developer");

            logger.LogInformation($"Hi {developer}. The time is: {DateTime.Now.ToShortTimeString()}");
        }
    }
}
