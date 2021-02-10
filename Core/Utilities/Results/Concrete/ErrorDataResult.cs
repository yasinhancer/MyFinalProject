using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //aşağıda birden fazla opsiyon sunduk, bu sayede istenilen şekilde kullanılanilir
        public ErrorDataResult(T data, string message) : base(data, false, message) //bilgilendirici mesajlı başarılı sonuç
        {

        }

        public ErrorDataResult(T data) : base(data, false) //mesajsız başarılı sonuç (sadece data veren)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message) //sadece veren
        {

        }

        public ErrorDataResult() : base(default, false) //hiçbirşey vermeyen, default tipi kullanan
        {

        }
    }
}