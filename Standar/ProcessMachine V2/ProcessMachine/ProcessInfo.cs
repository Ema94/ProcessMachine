using Standar.ProcessMachine_V2.Process;

namespace Standar.ProcessMachine_V2.ProcessMachine
{
    public class ProcessExecutionConfig<TResult>
        where TResult : class
    {
        public IProcess<TResult> Process { get; set; }
        public Func<bool> Condition { get; set; }
        public Action<TResult> OnProcess { get; set; }

    }
}