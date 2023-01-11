using Microsoft.EntityFrameworkCore;
using Standar.ProcessMachine_V2.Process.Finder.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process.Finder.Implementations.EntityFramework
{
    public class EntityFrameworkFinderMany<TIn, TObject> : FinderManyProcess<EntityFrameworkFinderConfig<TIn, TObject>, TObject>
        where TIn : class
        where TObject : class
    {
        public override async Task<FindManyResult<TObject>> ExecuteAsync()
        {
            EntityFrameworkFinderConfig<TIn, TObject> config = configuration.AsConfigurable();
            DbSet<TIn> set = config.context.Set<TIn>();
            IQueryable<TObject> result = config.contextQuery(set.AsQueryable());
            return new FindManyResult<TObject>()
            {
                Result = await result.ToListAsync(),
                Success = true

            };
        }
    }


    public class EntityFrameworkFinderConfig<TIn, TObject>
       where TIn : class
       where TObject: class
    {
        public DbContext context { get; set; }
        public Func<IQueryable<TIn>, IQueryable<TObject>> contextQuery { get; set; }

    }
}
