using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Reader
{
    public class ReaderQuery<TObject,TResult>
       where TObject : class
       where TResult : class
    {
        public IEnumerable<Expression<Func<TObject, object>>> Include { get; set; }
        public Expression<Func<TObject, bool>> Where { get; set; }
        public Expression<Func<TObject, TResult>> Select { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
