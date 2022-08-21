using Core.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
 public class EfCustomerDal:EfRepository<Customer,EfContext>,ICustomerDal
    {
    }
}
