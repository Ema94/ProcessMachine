using JEA.Components.ProcessMachine.Work;
namespace JEA.Components.ProcessMachine.Process
{
    public class WorksProcess : IWorksProcess
    {
        List<WorkProcessContext> _contracts;

        public WorksProcess()
        {
            _contracts = new List<WorkProcessContext>();
        }

        public void AddContext(WorkProcessContext context)
        {
            _contracts.Add(context);
        }

        public async Task Execute()
        {
            foreach (var contract in _contracts)
            {
                WorkResult workResult = new WorkResult();
                IWork work = contract.Work;
                if (contract.ExecutionType == Work.WorksTypes.Async)
                {

                    workResult = await work.ExecuteAsync();

                }
                else
                {
                    workResult = work.Execute();
                }

                if (contract.OnExecute != null)
                {
                    contract.OnExecute(workResult);
                }

            }
        }
    }
}
