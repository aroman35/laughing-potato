using System.Collections.Concurrent;
using LaughingPotato.Core.BackOffice;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LaughingPotato.Core.Microservices;

public class ContractPublisher : BackgroundService, IContractPublisher
{
    private readonly ILogger _logger;
    private readonly ConcurrentQueue<ContractBackOffice> _queue;

    public ContractPublisher(ILogger logger)
    {
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }

    public void Send(ContractBackOffice message)
    {
        throw new NotImplementedException();
    }
}