using Core.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
  public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
    }
}
