using Core.Concrete;
using Entities.Concrete;
using Entities.DTOs;

using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete
{
 public class EfCarDal:EfRepository<Car,EfContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (EfContext context = new EfContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {

                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }

        }
    }
}
