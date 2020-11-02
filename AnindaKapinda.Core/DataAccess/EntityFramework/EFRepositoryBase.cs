using AnindaKapinda.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Core.DataAccess.EntityFramework
{
    //EFRespository Gelen tip IRepository'e gitmesi lazım o yüzden ikisinin Generic Tipi aynı olmalı
    //Bu bir core yapı olduğu için bütün projelere göre uyum sağlaması gerektiği için TContext göndererek her türlü veritabanını gönderebilir.Başka projelerde bu yapıyı kullanabiliriz.
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext, new()
    {
        TContext context;
        

        DbSet<TEntity> entities;//Burda daha modellerimiz oluşmadığı için Set metotunu kullanmamız gerekir.İlgili entity tipi ne ise onun metotlarını döndürür.
        public EFRepositoryBase()
        {
            //context = new TContext();Bunu böyle yapmamalıyız.Update gibi işlemlerde hata ile karşılaşırız.

            //Singleton metot yaparak tek bir instance olarak almamızı sağladı.
            context = SingletonContext<TContext>.Context;

            entities = context.Set<TEntity>();
        }

        public int Add(TEntity entity)
        {
            try
            {
                entities.Add(entity);
                return context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Delete(TEntity entity)
        {
            entities.Remove(entity);
            return context.SaveChanges();
        }
        
        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes != null)
            {
                return entities.IncludeMultiple(includes).SingleOrDefault(filter);
            }
            else
            {
                return entities.SingleOrDefault(filter);
            }
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            
            if (filter != null && includes != null)
            {
                return entities.IncludeMultiple(includes).Where(filter).ToList();//Hem bir filtre parametresi hemde yanında navigation property(bağımlı tablo) gelmesi istenirse bu if'e girmiştir. 
            }
            else if (filter != null)
            {
                return entities.Where(filter).ToList();
            }
            else if (includes != null)
            {
                return entities.IncludeMultiple(includes).ToList();
            }
            else
            {
                return entities.ToList();
            }
        }

        public int Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
