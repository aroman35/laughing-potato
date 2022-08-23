using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using LaughingPotato.Core;
using LaughingPotato.Core.BackOffice;
using MassTransit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Shouldly;
using Xunit;

namespace LaughingPotato.UnitTests;

public class BackOfficeModelTests
{
    [Fact]
    public void MappingTest()
    {
        using var dataReader = TestDataProvider.OpenDataStream();
        using var csvReader = new CsvReader(dataReader, new CsvConfiguration(CultureInfo.GetCultureInfo("RU-ru"))
        {
            Delimiter = ";"
        });
        csvReader.Context.RegisterClassMap<ContractBackOfficeMap>();
        Should.NotThrow(() => csvReader.GetRecords<ContractBackOffice>().ToArray());
    }

    [Fact]
    public void TestTest()
    {
        var receivedData = TestDataProvider.OpenAsString();
        using var memory = new MemoryStream();
        using var writer = new StreamWriter(memory);
        writer.Write(receivedData);
        writer.Flush();
        memory.Position = 0;
        using var reader = new StreamReader(memory);
        
        using var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.GetCultureInfo("RU-ru"))
        {
            Delimiter = ";"
        });
        csvReader.Context.RegisterClassMap<ContractBackOfficeMap>();
        Should.NotThrow(() => csvReader.GetRecords<ContractBackOffice>().ToArray());
    }

    [Fact]
    public async Task ConsumerTest()
    {
        var message = TestDataProvider.OpenAsString();
        var contextMock = new Mock<ConsumeContext<string>>();
        contextMock.Setup(x => x.Message).Returns(message);
        var context = contextMock.Object;
        var logger = new Logger<ContractBackOfficeConsumer>(new NullLoggerFactory());
        var contractPublisherMock = new Mock<IContractPublisher>();
        var messagesPublished = 0;
        contractPublisherMock.Setup(x => x.Send(It.IsAny<ContractBackOffice>())).Callback(() => messagesPublished++);

        var consumer = new ContractBackOfficeConsumer(contractPublisherMock.Object, logger);
        await consumer.Consume(context);
        messagesPublished.ShouldBe(8121);
    }
}

public static class TestDataProvider
{
    private const string TestDataFileName = "test-data.csv";
    
    public static TextReader OpenDataStream()
    {
        return new StreamReader(TestDataFileName);
    }

    public static string OpenAsString()
    {
        return File.ReadAllText(TestDataFileName);
    }
}