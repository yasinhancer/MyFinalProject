﻿using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    //S(O)LID - Open Closed Principle
    //AMACIMIZ PnP'YE UYGUN KOD YAZMAK
    //PnP: Plug and Play = yeni herhangi birşey eklemek istediğinde, mevcut kodlarına dokunmayacak, rahatlıkla sistemine entegre edebileceksin. 
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();

            //CategoryTest();


            Console.ReadLine();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName); //ürünlerimi sorunsuz bir şekilde listeledim...
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
