using Business.Absrtact;
using Business.Concrete;
using Core.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandBusiness brandBusiness;
        public BrandsController(BrandBusiness brandBusiness)
        {
            this.brandBusiness = brandBusiness;   
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
           IDataResult<Brand>brand= brandBusiness.Get(id);
            return Ok(brand.Data);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           IDataResult<List<Brand>>brands= brandBusiness.GetAll();
            return Ok(brands.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            IResult result = brandBusiness.Add(new Brand());
            if (result.Success==true)
            {
                return Ok("success");
            }
            else { return BadRequest(result.Message); }

        }
    }
}
