using Business.Absrtact;
using Core.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UI.Controllers
{
   //[Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarBusiness carBusiness;
        public CarsController(ICarBusiness carBusiness)
        {
            this.carBusiness = carBusiness;
        }
        [HttpGet]
        public IActionResult Add(Car car)
        {
           IResult result= carBusiness.Add(car);
            if (result.Success==true)
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
         IDataResult<Car> dataResult = carBusiness.Get(id);
            return Ok(dataResult.Data) ;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           IDataResult< List<Car>> cars =carBusiness.GetAll();
            return Ok(cars);
        }
        [HttpGet]
        public IActionResult GetAllByCategoryId(int id)
        {
            IDataResult<List<Car>> dataResult = carBusiness.GetAllByBrandId(id);
            return Ok(dataResult.Data);
        }
    }
}
