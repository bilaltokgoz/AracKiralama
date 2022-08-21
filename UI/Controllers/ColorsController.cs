using Business.Absrtact;
using Core.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorBusiness colorBusiness;
        public ColorsController(IColorBusiness colorBusiness)
        {
            this.colorBusiness = colorBusiness;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            IDataResult<Color>color= colorBusiness.Get(id);
            return Ok(color.Data);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           IDataResult<List<Color>>colors= colorBusiness.GetList();
            return Ok(colors.Data);
        }
        [HttpGet]
        public IActionResult Add(Color color)
        {
           IResult result= colorBusiness.Add(color);
            if (result.Success==true)
            {
                return Ok("success");

            }
            else { return BadRequest(result.Message); }
        }
    }
}
