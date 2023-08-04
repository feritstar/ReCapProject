using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var query = _carService.GetAll();
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpGet("GetCarsByColorId")]
        public IActionResult GetCarsByColorId(int id)
        {
            var query = _carService.GetCarsByColorId(id);
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpGet("GetCarsByBrandId")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var query = _carService.GetCarsByBrandId(id);
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpPost("Add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
