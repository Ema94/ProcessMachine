using Standar;
using Standar.ProcessMachine_V2.Process.Finder.Implementations.EntityFramework;
using Standar.ProcessMachine_V2.Process.Message.Implementations.Configuration;
using Standar.ProcessMachine_V2.Service;
using Standar.ProcessMachine_V2.Service.Implementations;

Standar.Response ctx = new Standar.Response();
IServiceConfiguration<RandomMessageServiceConfig,Standar.Response> service = new RandomMessageService();
DbMensajesContext dbCtx = new DbMensajesContext();

service.Configure((configurator) =>
{
    configurator.query = (config) => config.AddContext(dbCtx)
                            .AddQuery((query) => query.AsQueryable());
    return configurator;
});

ctx = await service.ExecuteAsync();


 Console.WriteLine($"La respuesta fue:{ctx.Value} - Fecha:{ctx.Date}");

