using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // DAL: DATA ACCESS LAYER >>> veritabanında yapılacak işlemleri içerecek olan interface 
    public interface IProductDal
    {
        //interface metotları default publictir, interface'in kendisi değil.
        List<Product> GetAll(); //GetAll: hepsini getir 
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAllByCategory(int categoryId); //kategoriye göre filtrelemek için yazdım
    }
}