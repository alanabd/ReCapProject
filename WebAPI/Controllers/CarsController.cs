using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarServices _carServices;

        public CarsController(ICarServices carServices)
        {
            _carServices = carServices;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            
            var result = _carServices.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);

            }
            else
            {
                return BadRequest(result.Message);
            }
            
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {

            var result = _carServices.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result.Data);

            }
            else
            {
                return BadRequest(result.Message);
            }

        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carServices.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
