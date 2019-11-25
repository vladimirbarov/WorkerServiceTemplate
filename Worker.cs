using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerServiceTemplate
{
    internal class Worker : BackgroundService
    {
        private readonly ILogger _logger;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Worker running at: {DateTime.Now}.");

                await Task.Delay(1000, stoppingToken);
            }
        }

        //
        // Summary:
        //     Triggered when the application host is ready to start the service.
        //
        // Parameters:
        //   cancellationToken:
        //     Indicates that the start process has been aborted.

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Worker started at: {DateTime.Now}.");
            await base.StartAsync(cancellationToken);
        }

        //
        // Summary:
        //     Triggered when the application host is performing a graceful shutdown.
        //
        // Parameters:
        //   cancellationToken:
        //     Indicates that the shutdown process should no longer be graceful.       
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Worker stopped at: {DateTime.Now}.");
            await base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            _logger.LogInformation($"Worker disposed at: {DateTime.Now}.");
            base.Dispose();
        }
    }
}