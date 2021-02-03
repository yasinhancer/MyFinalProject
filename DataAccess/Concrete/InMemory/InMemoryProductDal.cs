using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private List<Product> _products;
        
        public InMemoryProductDal() //constructor
        {
            //Oracle,SQL Server, Postgres, MongoDB gibi veritabanlarından gelecek
            _products = new List<Product>
            {
                new Product {ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product {ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product {ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product {ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product {ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1},
            };
        }
        
        public void Add(Product product)
        {
            _products.Add(product);
        }
        
        public void Delete(Product product)
        {
            //1. YOL
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId) //benim gönderdiğim ile o anki product id eşit ise sil
            //    {
            //        productToDelete = p; //burada geçici olarak silinecek olan ürünü atadım
            //    }
            //}

            //_products.Remove(productToDelete); //silinecek olan ürünü buraya gönderdim ve sildim.

            //HATALI KULLANIM
            //_products.Remove(product); //bu kod bu şekilde çalışmaz, çünkü referans tipler, referans no üzerinden çalışacak

            //2. YOL, KOLAY YOLDAN YAPMA
            //LINQ - Language Integrated Query
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //p: tek tek dolaşırken verdiğim takma isim
            _products.Remove(productToDelete);
            //SingleOrDefault genelde Id sözkonusu olan aramalarda kullanılır, tıpkı üstteki döngümüz gibi listeyi dolaşır.
            //1. yola göre, LINQ Kullanarak tek satırda yazmış olduk. 
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //alttaki kod da LINQ yapısındadır ve yine her elemanı tek tek gezecek, tıpkı foreach gibi...
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //p:takma ismim
            //where içindeki şarta uyan bütün elemanları yeni bir liste haline getirir, return onu geri döndürür
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün ıd'sine sahip listedeki ürünü bul ve onu productToUpdate değişkenine ata
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            //üstteki kodlarım sayesinde de, geçici olarak güncellemmek üzere atadığım ürünümü, güncelliyorum.
        }

        public List<Product> GetAll()
        {
            return _products; //tümünü döndürdüm, getall olduğu için
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
