using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace PetShop.UI.RestAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class LogInUserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public LogInUserController(IUserServices userService)
        {
            _userService = userService;
        }
        // GET: api/LogInUser

        // POST: api/LogInUser
        [HttpPost]
        public IActionResult Post([FromBody] JObject data)
        {
            try
            {
                var validatedUser = _userService.ValidateUser(new Tuple<string, string>(data["username"].ToString(), 
                                                                data["password"].ToString()));
                return Ok(new
                {
                    Token = validatedUser.Item1,
                    Username = validatedUser.Item2
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Administration, User")]
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            try
            {
                return Ok(_userService.GetAllUsers());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/LogInUser/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
