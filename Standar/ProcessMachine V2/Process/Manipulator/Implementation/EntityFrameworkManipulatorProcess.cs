using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process.Manipulator.Implementation
{
    public class EntityFrameworkManipulatorProcess<TObject>
        : Manipulator.ManipulatorProcess<EntityFrameworkManipulatorProcessConfig<TObject>, TObject>
        where TObject : class, new()
    {
        public override async Task<ManipulatorResult<TObject>> ExecuteAsync()
        {
            EntityFrameworkManipulatorProcessConfig<TObject> config = configuration.AsConfigurable();
            DbSet<TObject> set = config.Context.Set<TObject>();
            if (config.objectToEdit == null)
            {
                config.objectToEdit = await config.FindObjectQuery(set.AsQueryable()).FirstAsync();
            }

            TObject obj = config.objectToEdit;
        
            if(obj != null)
            {
                if(config.OnFindedObject != null)
                {
                    obj = config.OnFindedObject(obj);
                }

                await set.AddAsync(obj);
                await config.Context.SaveChangesAsync();
            }

            return new ManipulatorResult<TObject>()
            {
                Object = obj,
                ActionType = config.action,
                Success = true
            };
        }
    }


    public class EntityFrameworkManipulatorProcessConfig<TObject>
    {
       public DbContext Context { get; set; }
       public Func<IQueryable<TObject>, IQueryable<TObject>> FindObjectQuery { get; set; }
       public Func<TObject, TObject> OnFindedObject { get; set; }
        public TObject objectToEdit { get; set; }
       public ActionTypes action { get; set; }
    }
}
