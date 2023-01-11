using Standar.ProcessMachine_V2.Process;
using Standar.ProcessMachine_V2.Process.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2
{
    public class MessageProcess<TConfiguration> : Process<TConfiguration, MessageResult>
        where TConfiguration : class
    {
    }
}
