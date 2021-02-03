using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet : buraya eklenebilir paketler
    //MicrosoftEntityFramework paketini yükledim 
    public class EfProductDal : IProductDal
    {
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //ternary operator'ü hatırla: xxx ? 1:2 >>> xxx sonucu evet ise 1.kodu hayır ise 2. kodu çalıştır
                //bu kod sayesinde, filtre girilmezse tüm veriyi, girilirse filtrelenmiş veriyi geri döndürecek
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //singleordefault tabloyu dolaşacak ve filtreyi uygulayacak, filtrelenmişleri geri döndürecek
                return context.Set<Product>().SingleOrDefault(filter); 
            }
        }
         
        public void Add(Product entity)
        {
            //direkt newlemek yerine, hem daha performanslı bir geliştirme oluyor
            //hem de işi bitince hemen bellekten siliniyor.
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //referansı yakala ve değişkene ata
                addedEntity.State = EntityState.Added; //atadığım değişkeni ekle (güncelleme vb. işlemler de yapılabiliyor.)
                context.SaveChanges(); //değişiklikleri kaydet
            }   
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //referansı yakala ve değişkene ata
                updatedEntity.State = EntityState.Modified; //atadığım değişkeni ekle (güncelleme vb. işlemler de yapılabiliyor.)
                context.SaveChanges(); //değişiklikleri kaydet
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
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
