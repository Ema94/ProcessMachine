using JEA.Components.Core.Reader;
using JEA.Components.Core.Reader.CommonReaders.Many;
using JEA.Components.Core.Reader.CommonReaders.One;
using JEA.Components.Readers.EF;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace JEA.Components.ProcessMachine.Work.Read
{
    public class ReadManyWork<TObject,TObjectResult,TQuery> : Work<TQuery>
        where TObjectResult : class
        where TObject : class
        where TQuery : ReaderQuery<TObject, TObjectResult>
    {
        public override async Task<WorkResult> ExecuteAsync()
        {
            TQuery query = parameters.Parameter();
            /*
                REFACTOR this service should delete and use the pricipal service of the API
             
             */
            IServiceCollection services = new ServiceCollection();

            services.AddTransient(typeof(EFReaderMany<TObject>));
            services.AddTransient(typeof(EFReaderConvertMany<TObject, TObjectResult>));

            var serviceProvider = services.BuildServiceProvider();

            IReaderMany<TObject, TObjectResult, TQuery> reader = serviceProvider.GetService(parameters.Type) as IReaderMany<TObject, TObjectResult, TQuery>;

            ReaderManyResult<TObjectResult> result = await reader.ReadAsync(query);

            var workResult =  new WorkResult()
            {
                State = JsonConvert.SerializeObject(result, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            })

            };

            return workResult;
        }
    }
}
