using System;
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
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(product.ProductName); //ürünlerimi sorunsuz bir şekilde listeledim...
            }
            Console.ReadLine();
        }
    }
}
