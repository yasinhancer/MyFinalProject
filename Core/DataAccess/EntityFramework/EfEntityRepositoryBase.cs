using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework //burayı her yerde kullanabilmek için TEntity ve TContext adlı değişkenlere atadım
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity: class,IEntity,new() //referans tip olmalı, IEntity'yi imp. etmeli, newlenebilir olmalı(soyut)
        where TContext: DbContext,new()    //TContext bir tür DbContext olmalı,newlenebilir olmalı(Northwind context gibi..)
    { 
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //ternary operator'ü hatırla: xxx ? 1:2 >>> xxx sonucu evet ise 1.kodu hayır ise 2. kodu çalıştır
                //bu kod sayesinde, filtre girilmezse tüm veriyi, girilirse filtrelenmiş veriyi geri döndürecek
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                //singleordefault tabloyu dolaşacak ve filtreyi uygulayacak, filtrelenmişleri geri döndürecek
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Add(TEntity entity)
        {
            //direkt newlemek yerine, hem daha performanslı bir geliştirme oluyor
            //hem de işi bitince hemen bellekten siliniyor.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //referansı yakala ve değişkene ata
                addedEntity.State = EntityState.Added; //atadığım değişkeni ekle (güncelleme vb. işlemler de yapılabiliyor.)
                context.SaveChanges(); //değişiklikleri kaydet
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //referansı yakala ve değişkene ata
                updatedEntity.State = EntityState.Modified; //atadığım değişkeni ekle (güncelleme vb. işlemler de yapılabiliyor.)
                context.SaveChanges(); //değişiklikleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //referansı yakala ve değişkene ata
                deletedEntity.State = EntityState.Deleted; //atadığım değişkeni ekle (güncelleme vb. işlemler de yapılabiliyor.)
                context.SaveChanges(); //değişiklikleri kaydet

                //burada, silinecek veriyi deletedEntity yani silinecek varlık adında bir değişkene atadık
                //daha sonra bu değişken hakkında işlem yaptık (.Deleted), b
                //u sayede gerçekten db'den silinmiş oldu

            }
        }
    }
}
