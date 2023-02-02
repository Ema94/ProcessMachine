using Microsoft.EntityFrameworkCore;
using Standar.ProcessMachine_V2;
using Standar.ProcessMachine_V2.Process.Finder.Implementations.EntityFramework;
using Standar.ProcessMachine_V2.Process.Manipulator;
using Standar.ProcessMachine_V2.Process.Manipulator.Implementation;
using Standar.ProcessMachine_V2.Process.Message;
using Standar.ProcessMachine_V2.Process.Message.Implementations.Configuration;
using Standar.ProcessMachine_V2.ProcessMachine;
using Standar.ProcessMachine_V2.ProcessMachine.Process;

namespace Standar.ProcessMachine_V2.Service.Implementations
{
    public class RandomMessageService : ServiceConfiguration<RandomMessageServiceConfig, Standar.Response>
    {

        public override async Task<Standar.Response> ExecuteAsync()
        {
            IProcessMachine processMachine = new Standar.ProcessMachine_V2.ProcessMachine.ProcessMachine();
            List<Standar.Message> messages = new List<Standar.Message>();   
            Standar.Response response = new Standar.Response();
          
            DbMensajesContext dbCtxw = new DbMensajesContext();

            await processMachine.FindProcess<Standar.Message, Standar.Message>((builder) =>
            {
                builder.configurable = Configuration.query;
            

                builder.ExecutionCondition = () => true;

                builder.OnProcess = (result) =>
                {
                    messages =  result.Result;
                    Console.WriteLine("Inicio del Proceso");
                };
                return builder;
            });


            processMachine.RandomMessage((process) =>
            {
                process.parameters = new Standar.ProcessMachine_V2.Process.Message.RandomMessageConfig()
                {
                    MessageResult = messages
                };
                process.ExecutionCondition = () => true;
                process.OnProcess = (result) => {

                    response.Value = result.Message.Value;
                    response.Date = DateTime.Now;
                };
                return process;
            });

           await processMachine.ManipulateProcess<Response>((builder) =>
            {
                builder.ExecutionCondition = () => !string.IsNullOrEmpty(response.Value);
                builder.configurable = (config) => config.AddContext(dbCtxw).AddObjectToEdit(response).AddAction(ActionTypes.Add);
                builder.OnProcess = (result) =>
                {
                    Console.WriteLine("Fin Del Proceso");
                };
                return builder;
            });

            return response;
        }

    }
}
public class RandomMessageServiceConfig
{
    public Func<IConfigurable<EntityFrameworkFinderConfig<Standar.Message,Standar.Message>>, IConfigurable<EntityFrameworkFinderConfig<Standar.Message, Standar.Message>>> query { get; set; }
}