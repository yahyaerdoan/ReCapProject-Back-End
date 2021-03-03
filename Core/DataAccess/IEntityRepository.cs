using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Generic constraint (kısıtlama)
    // class : referans tip
    // IEntity: IEntity olabilir veya IEntity iplemente eden bir nesne olabilir
    // new() : new'lenebilir olmalı (IEntity new'lenemez)

    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null); // Burda null kullanmamızın sebebi filtre vermediğimizde de veriyi getirecek.
        T Get(Expression<Func<T, bool>> filter); // Tek bir data ve detaylı bilgi getirmek için kullanırız. Filtre detay için gereklidir.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);



        //Aşağıdaki metotlara ihtiyacımız kalmadı sebebi ise yukarıda kullandığımız Linq.Expressions; metodudur. Bu ne işe yarar 
        // Buna delege de deniyor. lamdalı veri yazmamızı sağlar ayrı ayrı metotlar yazmamıza gerek kalmaz 
        // Filtreli metodu kısa yoldan yazmamızı sağlar.



        //List<T> GetAllByBrand();
        //List<T> GetByBrandId();
        //List<T> GetAllDescription();
        //List<T> GetById(int brandId);
        //List<T> GetAllByBrand(string brand);
       
    }
}
