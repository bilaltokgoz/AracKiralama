using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Absrtact
{
   public interface ICarBusiness
    {
        public IDataResult< Car> Get(int id);
        public IDataResult<List<Car>> GetAll();
       public IDataResult< List<Car> > GetAllByBrandId(int brandId);
        public IDataResult<List<CarDetailDto>> GetCarDetails();
        public IResult Add(Car car);
    }
}
