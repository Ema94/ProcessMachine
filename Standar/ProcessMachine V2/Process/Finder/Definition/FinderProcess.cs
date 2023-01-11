using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process.Finder.Definition
{
    public class FinderManyProcess<TQuery,TObject>:Process<TQuery, FindManyResult<TObject>>
        where TQuery : class
        where TObject : class 
    {
    }

    public class FindManyResult<TObject>
    {
        public bool Success { get; set; }   
        public List<TObject> Result { get; set; }

    }
}
