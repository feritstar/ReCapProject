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
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var query = _colorService.GetAll();
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var query = _colorService.GetById(id);
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpPost("Add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
