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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var query = _rentalService.GetAll();
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var query = _rentalService.GetById(id);
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpGet("GetByCustomerId")]
        public IActionResult GetByCustomerId(int id)
        {
            var query = _rentalService.GetByCustomerId(id);
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpGet("GetByCarId")]
        public IActionResult GetByCarId(int id)
        {
            var query = _rentalService.GetByCarId(id);
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpPost("Add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
