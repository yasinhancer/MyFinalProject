using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //mesajlar sabit olduğundan ve newlemekle uğraşmamak için başına static ekledim.
    //static sayesinde yaşam ömrü boyunca tek bir instance ile kullanılır, newlemeye gerek kalmaz
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz!";
    }
}