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
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var query = _userService.GetAll();
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var query = _userService.GetById(id);
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpGet("GetByFirstName")]
        public IActionResult GetByFirstName(string firstName)
        {
            var query = _userService.GetByFirstName(firstName);
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpGet("GetByLastName")]
        public IActionResult GetByLastName(string lastName)
        {
            var query = _userService.GetByLastName(lastName);
            if (query.Success)
            {
                return Ok(query);
            }
            return BadRequest(query);
        }

        [HttpPost("Add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
