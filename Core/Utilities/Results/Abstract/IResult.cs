using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } //get: okunabilir, set koymadım ve bu sayede yazma yok, sadece okunabilir 
        string Message { get; }
    }
}
