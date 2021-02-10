using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        //get: read only, ancak constructor içinde set edilebilir, aşağıda yaptığım gibi
        public Result(bool success, string message):this(success) //sondaki kod sayesinde,
                                                                  //ben result girerken 2 parametre yollarsam
                                                                  //aşağıdaki de çalışır, tek parametre yollarsam
                                                                  //sadece bu metot çalışır.
        {
            Message = message; //burada vermek istediğim mesajı aşağıdaki Message değişkenine atadım        
        }
        public Result(bool success)
        {
            Success = success;
        }
        //aşağıtya set yazmayıp da bu şekilde constructor vasıtasıyla set ettirmemin sebebi,
        //kod doğruluğunu artırmaktır.her halükarda yukarıya yazdığım şey Message değişkenine atanacak 
        public bool Success { get; }
        public string Message { get; }
    }
}