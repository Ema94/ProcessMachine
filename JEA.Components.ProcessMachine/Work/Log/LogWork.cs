using JEA.Components.Console.Log;
using JEA.Components.Core.Logger;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine.Work.Log
{
    public class LogWork<TContext> : Work<LoggerInput<TContext>>
        where TContext : class
    {
        public override Task<WorkResult> ExecuteAsync()
        {
            LoggerInput<TContext> logParameters = parameters.Parameter();
            /*
                 REFACTOR this service should delete and use the pricipal service of the API

            */
            IServiceCollection services = new ServiceCollection();

            services.AddTransient(typeof(ConsoleLogger<TContext>));

            var serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService(parameters.Type) as JEA.Components.Core.Logger.ILogger<TContext>;

             logger.Log(logParameters);

            var workResult = new WorkResult()
            {
                State = JsonConvert.SerializeObject(logParameters, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            })

            };

            return Task.FromResult(workResult);
        }
    }
}
