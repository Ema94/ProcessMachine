using JEA.Components.Core.Reader;
using JEA.Components.Core.Reader.CommonReaders.One;
using JEA.Components.ProcessMachine.Work.Log;
using JEA.Components.Readers.EF;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace JEA.Components.ProcessMachine.Work.Read
{
    public class ReadWork<TObject, TObjectResult, TQuery> : Work<TQuery>
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

            services.AddTransient(typeof(EFReaderOne<TObject>));
            services.AddTransient(typeof(EFReaderConvertOne<TObject, TObjectResult>));

            var serviceProvider = services.BuildServiceProvider();

            IReaderOne<TObject, TObjectResult, TQuery>? readerOne = serviceProvider.GetService(parameters.Type) as IReaderOne<TObject, TObjectResult, TQuery>;

            ReaderOneResult<TObjectResult> result = await readerOne.ReadAsync(query);

            var workResult = new WorkResult()
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
