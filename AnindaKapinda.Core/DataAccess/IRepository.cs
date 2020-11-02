using AnindaKapinda.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Core.DataAccess
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        //Repostitory patern Veri erişim ile ilgili bir patern'dir.İşlemlerin temellerinin bulunacağı Interface'Dir.IRepostiroy 5 temel işlemi bulunduran interface'dir.Generic tip olarak yarattık.
        //Tentity (Employee,Customer,Order diye gelen modeller)
        int Add(TEntity entity);
        int Delete(TEntity entity);
        int Update(TEntity entity);

        /// <summary>
        /// Func delege'si  bir metot veriyoruz demektir.Bu metot'da lambda ile verilir.Linq bu lambda ile verilen ifadeyi parçalayıp gerekli yeri parametre gerekli yeri işlem olarak okur.Linq lambda'da (i=>i.employeeID)bu ifade ağacı haline gelmesini karşılar.
        /// TEntity göre bir parametre alıp lamdada gövdesini biz yazarak bool ile true dönmesini sağladık.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);//Bir tane id'si veya kullanıcıya şu olan employee,order getir denilidiğinde.Bir sürü get byID veya get byUser için ayrı ayrı metot yazmak yerine bir tane Get metodu ile bütün bu Get metotlarımı karşılayan metot yazmalıyım.Ozaman lambda'ya göre bir parametre alınmalı context.where(i=>i.employeeID==id) gibi bir yapı kuralım.İhtiyaca uygun  parametreyi verebilmek için.

        /// <summary>
        /// GetAll'dada gene bir filtreye göre geri dönüş olacağı için Parametreli verdik.List<TEntity> kullanmak yerine daha uygun Icollection kullandık. İlk değeri null yaparak Parametreyi opsiyonel yaptık.Eğer filtre yoksa bütün liste gelir, filtre varsa id'ye kullanıcı özelliklerine göre filtreleme yapılabilir.
        /// </summary>
        /// <returns></returns>
        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

    }
}
