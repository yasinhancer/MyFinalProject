﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    //iş kodları
    //KURAL: BİR İŞ SINIFI BAŞKA BİR İŞ SINIFINI NEWLEMEZ, BUNUN YERİNE DEPENDENCY INJECTION YAPARIZ
    public class ProductManager : IProductService
    {
        //DEPENDENCY INJECTION
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        
        public List<Product> GetAll()
        {
            

            return _productDal.GetAll();
        }
    }
}