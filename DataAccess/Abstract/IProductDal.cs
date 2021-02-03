using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // DAL: DATA ACCESS LAYER >>> veritabanında yapılacak işlemleri içerecek olan interface 
    //interface metotları default publictir, interface'in kendisi değil.
    //IEntityRepository sayesinde tüm metotları, Product tipine göre yapılandırıyorum
    public interface IProductDal : IEntityRepository<Product> 
    {
    }
}