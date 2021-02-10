using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessResult : Result
    {
        //burada başarılı sonuç için oluşturdum, base'e (RESULT) true (success old. için) ve mesajı gönderdim
        public SuccessResult(string message) : base(true, message)
        {

        }

        public SuccessResult() : base(true) //bu metot sayesinde de, mesajsız olarak success vermiş oldum
        {

        }
    }
}
