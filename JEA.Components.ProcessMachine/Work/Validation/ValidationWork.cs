using JEA.Components.Core.Validator;
using JEA.Components.Core.Validator.Config;
using JEA.Components.Validators.Fluent;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace JEA.Components.ProcessMachine.Work.Validation
{
    public class ValidationWork<TObject,TValidation> : Work<TValidation>
        where TObject : class
        where TValidation : ValidatorConfig<TObject>
    {
        public override WorkResult Execute()
        {
            TValidation validations = parameters.Parameter();
            /*
                 REFACTOR this service should delete and use the pricipal service of the API

            */
            IServiceCollection services = new ServiceCollection();

            services.AddTransient(typeof(Validator<TObject>));
            services.AddTransient(typeof(ParallelValidatior<TObject>));

            var serviceProvider = services.BuildServiceProvider();

            var validator = serviceProvider.GetService(parameters.Type) as IValidator<TObject>;
            var validationResult = validator.Validate(validations);

            var workResult =  new WorkResult()
            {
                State = JsonConvert.SerializeObject(validationResult, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            })

            };

            return workResult;

        }
    }
}
