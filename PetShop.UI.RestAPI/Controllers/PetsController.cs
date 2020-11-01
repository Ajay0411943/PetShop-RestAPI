using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entity;
using PetShopApp.Core.ApplicationService;

namespace PetShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        IPetService _petService;

        public PetsController(IPetService service)
        {
            _petService = service;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.FindPetById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {

            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("missing Name");
            }
            if (string.IsNullOrEmpty(pet.Color))
            {
                return BadRequest("missing colour");
            }
            if (pet.Price <= 0 || pet.Price.Equals(null))
            {
                return BadRequest("invalid Price input");
            }
            _petService.CreatePet(pet);
            return StatusCode(500, $" Pet {pet.Name} created successfully");

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 0 || id != pet.Id)
            {
                return BadRequest("invalid ID");
            }
            _petService.UpdatePet(pet);
            return StatusCode(500, $"Pet {pet.Name} updated successfully");

        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            _petService.DeletePet(id);
            return StatusCode(500, $" Pet ");
        }
    }
}