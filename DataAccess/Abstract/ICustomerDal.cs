using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //repository sayesinde, istediğim tipte veriyi rahatça, sistemime entegre edebiliyorum.
    public interface ICustomerDal : IEntityRepository<Customer> 
    {

    }
}
