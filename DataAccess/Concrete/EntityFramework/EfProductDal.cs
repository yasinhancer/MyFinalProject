﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet : buraya eklenebilir paketler
    //MicrosoftEntityFramework paketini yükledim 
    public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal 
        //oluşturduğumuz base'i istediğim şekilde düzenletip inherit ettim
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //join operasyonu yazıyoruz
                var result = from p in context.Products //equals yazılır eşittir yerine
                    join c in context.Categories
                        on p.CategoryId equals c.CategoryId
                    select new ProductDetailDto
                    {
                        ProductId = p.ProductId, ProductName = p.ProductName,
                        CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock
                    };
                return result.ToList();
            }
        }
    }
}
