using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile projedeki class'ları ilişkilendirme
    public class NorthwindContext : DbContext
    {
        //bu metot, projenin hangi veritabanı ile ilişkili olduğunu belirteceğimiz yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sql server kullanacağımızı belirttik ve parantez içinde nasıl bağlanacağımızı, db'nin adını vs belirttik
            //NOT: @ dışarı yazılmalıdır ki o da tarif olarak algılanmasın
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true"); 

        }

        //prop kullanarak, hangi tabloya bizim hangi class'ımızın bağlanacağını yazıyoruz, aşağıdaki şekilde
        public DbSet<Product> Products { get; set; } //benim product'ımı, veritabanındaki products'a bağla
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
