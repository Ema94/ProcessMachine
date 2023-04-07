using JEA.Components.Core.Mailer;
using JEA.Components.Core.Mailer.Configuration;
using JEA.Components.Mailer.SMTP;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine.Work.Mail
{
    public class MailWork : Work<MailerConfig>
    {
        public override async Task<WorkResult> ExecuteAsync()
        {
            MailerConfig mailerConfig = parameters.Parameter();
            /*
                 REFACTOR this service should delete and use the pricipal service of the API

            */
            IServiceCollection services = new ServiceCollection();

            services.AddTransient(typeof(SmtpMailer));

            var serviceProvider = services.BuildServiceProvider();

            var mailer = serviceProvider.GetService(parameters.Type) as IMailer;

            var mailerResult = await mailer.Send(mailerConfig);

            var workResult = new WorkResult()
            {
                State = JsonConvert.SerializeObject(mailerResult, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            }),

            };

            return workResult;
        }
    }
}
