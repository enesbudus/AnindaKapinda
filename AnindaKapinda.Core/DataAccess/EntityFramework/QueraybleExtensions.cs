using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Core.DataAccess.EntityFramework
{

    public static class QueryableExtensions
    {
        //Biz bir tablo çekerken örneğin kullanıcılar tablosu onun navigation property tablosunuda çekmek istersek burdan faydalanıyoruz.
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                        (current, include) => current.Include(include)
                    );
            }

            return query;
        }
    }
}
