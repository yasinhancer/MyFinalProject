using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //bu constructor sayesinde, classa success ve mesaj için gönderdiğim kodu tekrar yazmamak için base diyerek gönderdim
        public DataResult(T data, bool success, string messsage):base(success,messsage)
        {
            Data = data;
        }

        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
