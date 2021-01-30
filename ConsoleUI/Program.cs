using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    //AMACIMIZ PnP'YE UYGUN KOD YAZMAK
    //PnP: Plug and Play = yeni herhangi birşey eklemek istediğinde, mevcut kodlarına dookunmayacak, rahatlıkla sistemine entegre edebileceksin. 
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName); //ürünlerimi sorunsuz bir şekilde listeledim...
            }
        }
    }
}
