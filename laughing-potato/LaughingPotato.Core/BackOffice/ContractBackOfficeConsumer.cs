using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace LaughingPotato.Core.BackOffice;

public class ContractBackOfficeConsumer : IConsumer<string>
{
    private readonly IContractPublisher _contractPublisher;
    private readonly ILogger _logger;

    public ContractBackOfficeConsumer(
        IContractPublisher contractPublisher,
        ILogger<ContractBackOfficeConsumer> logger)
    {
        _contractPublisher = contractPublisher;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<string> context)
    {
        var message = context.Message;

        using var memory = new MemoryStream();
        await using var writer = new StreamWriter(memory);
        await writer.WriteAsync(message);
        await writer.FlushAsync();
        memory.Position = 0;

        using var reader = new StreamReader(memory);
        using var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.GetCultureInfo("RU-ru"))
        {
            Delimiter = ";"
        });
        csvReader.Context.RegisterClassMap<ContractBackOfficeMap>();
        var counter = 0;
        foreach (var record in csvReader.GetRecords<ContractBackOffice>())
        {
            _contractPublisher.Send(record);
            counter++;
        }
        _logger.LogInformation("Published {Count} records", counter);
        
        await Task.CompletedTask;
    }
}