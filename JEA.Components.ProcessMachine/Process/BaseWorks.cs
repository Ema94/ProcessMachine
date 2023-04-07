using JEA.Components.Core.Logger;
using JEA.Components.Core.Mailer.Configuration;
using JEA.Components.Core.Reader;
using JEA.Components.Core.Validator.Config;
using JEA.Components.Core.Writer;
using JEA.Components.ProcessMachine.Work;
using JEA.Components.ProcessMachine.Work.Log;
using JEA.Components.ProcessMachine.Work.Mail;
using JEA.Components.ProcessMachine.Work.Read;
using JEA.Components.ProcessMachine.Work.Validation;
using JEA.Components.ProcessMachine.Work.Write;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JEA.Components.ProcessMachine.Process
{
    public static class BaseWorks
    {
        public static IWorksProcess AddReadWork<TObject, TObjectResult, TQuery>(this IWorksProcess process, PrametrizeWorkContext<TQuery> readContext)
        where TObjectResult : class
        where TObject : class
        where TQuery : ReaderQuery<TObject, TObjectResult>
        {
            IParametrizeWork<TQuery> Work = new ReadWork<TObject, TObjectResult, TQuery>();
            Work.SetParameter(readContext);
            process.AddContext(new WorkProcessContext()
            {
                Work =  Work,
                ExecutionType = WorksTypes.Async,
                OnExecute = readContext.OnExecute
            });
            return process;
        }

        public static IWorksProcess AddReadManyWork<TObject, TObjectResult, TQuery>(this IWorksProcess process, PrametrizeWorkContext<TQuery> readContext)
        where TObjectResult : class
        where TObject : class
        where TQuery : ReaderQuery<TObject, TObjectResult>
        {
            IParametrizeWork<TQuery> Work = new ReadManyWork<TObject, TObjectResult, TQuery>();
            Work.SetParameter(readContext);
            process.AddContext(new WorkProcessContext()
            {
                Work = Work,
                ExecutionType = WorksTypes.Async,
                OnExecute = readContext.OnExecute
            });
            return process;
        }

        public static IWorksProcess AddWriteWork<TObject, TConfig>(this IWorksProcess process, PrametrizeWorkContext<TConfig> readContext)
        where TObject : class
        where TConfig : WriterInput<TObject>
        {
            IParametrizeWork<TConfig> Work = new WriteWork<TObject, TConfig>();
            Work.SetParameter(readContext);
            process.AddContext(new WorkProcessContext()
            {
                Work = Work,
                ExecutionType = WorksTypes.Async,
                OnExecute = readContext.OnExecute
            });
            return process;
        }

        public static IWorksProcess AddValidationWork<TObject, TValidation>(this IWorksProcess process, PrametrizeWorkContext<TValidation> validationContext)
        where TObject : class
        where TValidation : ValidatorConfig<TObject>
        {
            IParametrizeWork<TValidation> Work = new ValidationWork<TObject, TValidation>();
            PrametrizeWorkContext<TValidation> context = new PrametrizeWorkContext<TValidation>();
            Work.SetParameter(validationContext);
            process.AddContext(new WorkProcessContext()
            {
                Work = Work,
                ExecutionType = WorksTypes.Async,
                OnExecute = validationContext.OnExecute
            });
            return process;
        }

        public static IWorksProcess AddMailWork(this IWorksProcess process, PrametrizeWorkContext<MailerConfig> mailContext)
        {
            IParametrizeWork<MailerConfig> Work = new MailWork();
            Work.SetParameter(mailContext);
            process.AddContext(new WorkProcessContext()
            {
                Work = Work,
                ExecutionType = WorksTypes.Async,
                OnExecute = mailContext.OnExecute
            });
            return process;
        }


        public static IWorksProcess AddLogWork<TContext>(this IWorksProcess process, PrametrizeWorkContext<LoggerInput<TContext>> logContext)
            where TContext : class
        {
            IParametrizeWork<LoggerInput<TContext>> Work = new LogWork<TContext>();
            PrametrizeWorkContext<LoggerInput<TContext>> context = new PrametrizeWorkContext<LoggerInput<TContext>>();
            Work.SetParameter(logContext);
            process.AddContext(new WorkProcessContext()
            {
                Work = Work,
                ExecutionType = WorksTypes.Async,
                OnExecute = logContext.OnExecute
            });
            return process;
        }


    }
}
