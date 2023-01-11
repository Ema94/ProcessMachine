using Standar.ProcessMachine_V2.Process.Message.Implementations.Configuration;
using Standar.ProcessMachine_V2.Service;
using Standar.ProcessMachine_V2.Service.Implementations;

RandomMessage_Result ctx = new RandomMessage_Result();
IServiceConfiguration<RandomMessageServiceConfig,RandomMessage_Result> service = new RandomMessageService();

service.Configure((configurator) =>
{
    configurator.messages = (builder) => builder.AddRandomMessage("Hola").AddRandomMessage("Chau");
    return configurator;
});

ctx = await service.ExecuteAsync();


 Console.WriteLine(ctx.Message);

