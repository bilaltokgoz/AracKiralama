using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Absrtact
{
   public interface IBrandBusiness
    {
        IDataResult<Brand> Get(int id);
        IDataResult<Brand> Get(string name);
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand brand);   
        IResult Delete(Brand brand);
    }
}
