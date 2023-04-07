using JEA.Components.Core.Writer;
using JEA.Components.Writers.EF;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine.Work.Write
{
    public class WriteWork<TObject,TConfig> : Work<TConfig>
        where TObject : class
        where TConfig : WriterInput<TObject>
    {
        public override async Task<WorkResult> ExecuteAsync()
        {
            TConfig configuration = parameters.Parameter();
            /*
                 REFACTOR this service should delete and use the pricipal service of the API

            */
            IServiceCollection services = new ServiceCollection();

            services.AddTransient(typeof(EFWriter<TObject>));
            
            var serviceProvider = services.BuildServiceProvider();

            IWriter<TObject,TConfig> write = serviceProvider.GetService(parameters.Type) as IWriter<TObject, TConfig>;

           var writeResult =  await write.WriteAsync(configuration);

            var workResult = new WorkResult()
            {
                State = JsonConvert.SerializeObject(writeResult, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            })

            };

            return workResult;
        }
    }
}
