using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //aşağıda birden fazla opsiyon sunduk, bu sayede istenilen şekilde kullanılanilir
        public SuccessDataResult(T data,string message):base(data,true,message) //bilgilendirici mesajlı başarılı sonuç
        {
            
        }

        public SuccessDataResult(T data):base(data,true) //mesajsız başarılı sonuç (sadece data veren)
        {
            
        }

        public SuccessDataResult(string message):base(default,true,message) //sadece veren
        {
            
        }

        public SuccessDataResult():base(default,true) //hiçbirşey vermeyen, default tipi kullanan
        {
            
        }
    }
}
