using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Core.DataAccess.EntityFramework
{
    class SingletonContext<TContext> where TContext : DbContext, new()
    {

        private static TContext context;
        private SingletonContext()
        {            
            //SingletonPattern
        }
        internal static TContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new TContext();
                }
                return context;
            }
        }
    }
}
