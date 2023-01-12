using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process.Manipulator
{
    public class ManipulatorProcess<TConfig, TObject> : Process<TConfig, ManipulatorResult<TObject>>
        where TConfig : class
        where TObject : class, new()
    {
    }

    public enum ActionTypes
    {
        Add = 1,
        Update=2,
        Delete = 3
    }

    public class ManipulatorResult<TObject>
    {
        public TObject Object { get; set; }
        public ActionTypes ActionType { get; set; }
        public bool Success { get; set; }
    }
}
