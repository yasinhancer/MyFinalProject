using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    //hem işlem yapacak, hem de sonucunu bildirecek (sabit mesajlar ile) bir interface yazdım.
    public interface IDataResult<T>:IResult
    {
        T Data { get; } //veritabanından data göndermek için
    }
}