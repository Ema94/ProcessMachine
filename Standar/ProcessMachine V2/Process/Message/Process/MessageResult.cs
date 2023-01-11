using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process.Message
{
    public class MessageResult
    {
        public Standar.Message Message { get; set; }
        public bool Delivered { get; set; }
    }
}
