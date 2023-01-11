using Microsoft.EntityFrameworkCore;
using Standar.ProcessMachine_V2;
using Standar.ProcessMachine_V2.Process.Finder.Implementations.EntityFramework;
using Standar.ProcessMachine_V2.Process.Message;
using Standar.ProcessMachine_V2.Process.Message.Implementations.Configuration;
using Standar.ProcessMachine_V2.ProcessMachine;
using Standar.ProcessMachine_V2.ProcessMachine.Process;

namespace Standar.ProcessMachine_V2.Service.Implementations
{
    public class RandomMessageService : ServiceConfiguration<RandomMessageServiceConfig, RandomMessage_Result>
    {

        public override async Task<RandomMessage_Result> ExecuteAsync()
        {
            IProcessMachine processMachine = new Standar.ProcessMachine_V2.ProcessMachine.ProcessMachine();
            RandomMessage_Result ctx = new RandomMessage_Result();
            List<Standar.Message> messages = new List<Standar.Message>();   
            Standar.Response response = new Standar.Response();
            DbMensajesContext dbCtx = new DbMensajesContext();

            await processMachine.FindProcess<Standar.Message, Standar.Message>((builder) =>
            {
                builder.configurable = 
                (config) => config.AddContext(dbCtx).AddQuery((query) => query.AsQueryable());

                builder.ExecutionCondition = () => true;

                builder.OnProcess = (result) =>
                {
                    messages =  result.Result;
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
                    ctx.Message = response.Value;
                };
                return process;
            });

            return ctx;
        }

    }
}
public class RandomMessageServiceConfig
{
    public Func<IConfigurable<RandomMessageConfig>, IConfigurable<RandomMessageConfig>> messages { get; set; }
}