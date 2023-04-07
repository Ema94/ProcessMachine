using JEA.Components.Core.Validator;
using JEA.Components.ProcessMachine.Process;
using JEA.Components.Validators.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine
{
    public class ProcessMachine<TObjectContext> : IProcessMachine<TObjectContext>
        where TObjectContext : class
    {
        private readonly IValidator<TObjectContext> _validator;
        public ProcessMachine()
        {
            // I choise a static validator but tanks to abstraction and encapsulation. I can rewite this if i need
            _validator = new Validator<TObjectContext>();
        }

        public async Task<ProcessMachineContext<TObjectContext>> RunProcess(ProcessMachineContext<TObjectContext> processContext)
        {
            //I can improve this with some component oriented to flush choises.
            processContext.State = ProcessMachineStates.Start;
            if(processContext.Processes == null)
            {
                processContext.State = ProcessMachineStates.Error;
                return processContext;
            }
            if (!processContext.Processes.Any())
            {
                processContext.State = ProcessMachineStates.Error;
                return processContext;
            }

            processContext.State = ProcessMachineStates.Running;

            foreach (var process in processContext.Processes)
            {
                IWorksProcess workProcess = process.worksProcess(new WorksProcess());

                if (processContext.State == ProcessMachineStates.Error || processContext.State == ProcessMachineStates.PartialyEnd)
                {
                    return processContext;
                }

                if(process.Rules != null)
                {
                    var validationResult = _validator.Validate(process.Rules);

                    if (!validationResult.IsValid && process.RuleIsblock)
                    {
                        processContext.State = ProcessMachineStates.Error;
                        processContext.LogMessages.Add("-------------ERROR-----------");
                        processContext.LogMessages.AddRange(validationResult.Details.Select(x => x.Message));
                        return processContext;
                    }

                    if (validationResult.IsValid)
                    {
                        await workProcess.Execute();
                    }
                }
                else
                {
                    await workProcess.Execute();
                }
            
             
            }

            processContext.State = ProcessMachineStates.End;
            return processContext;
        }
    }
}
