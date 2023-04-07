using JEA.Components.Core.Validator.Config;
using JEA.Components.ProcessMachine.Process;

namespace JEA.Components.ProcessMachine
{
    public class ProcessContrat<TContext>
        where TContext : class
    {
        public ValidatorConfig<TContext> Rules { get; set; }
        public Func<IWorksProcess,IWorksProcess> worksProcess { get; set; }
        public bool RuleIsblock { get; set; }
    }
}