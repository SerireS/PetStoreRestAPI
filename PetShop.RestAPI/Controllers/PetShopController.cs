using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetShopController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetShopController(IPetService petService)
        {
            _petService = petService;
        }
        // GET: api/<PetShopController>
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            var petList = _petService.GetPets();
            if (petList.Count == 0)
            {
                return NoContent();
            }

            try
            {
                return Ok(petList);
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
        }

        // GET api/<PetShopController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            var petId = _petService.FindPetById(id);
            if (petId == null)
            {
                return StatusCode(404, "Id Must Be Above 0");
            }
            try
            {
                return Ok(petId);
            }
            catch (Exception)
            {
               return StatusCode(500, "Smth Went Wrong");
            }
        }

        // POST api/<PetShopController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("Enter PetName");
            }

            if (string.IsNullOrEmpty(pet.Color))
            {
                return BadRequest("Enter PetColor");
            }
            return Ok(_petService.CreatePet(pet));
        }

        // PUT api/<PetShopController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
          var updatePet = _petService.UpdatePet(pet);
          if (updatePet == null)
          {
              return StatusCode(404, "Pet Was Not Found");
          }

          try
          {
              return Ok(updatePet);
          }
          catch (Exception)
          {
              return StatusCode(500, "Smth Went Wrong");
          }
        }

        // DELETE api/<PetShopController>/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var petId = _petService.DeletePet(id);
            if (petId == null)
            {
                StatusCode(404, "Id Must Be Above 0");
            }

            try
            {
                return Ok(petId);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
        }

        [HttpGet("{type}")]
        [Route("[action]/{type}")]
        public ActionResult<List<Pet>> GetFiltered(string type)
        {
            try
            { 
                return Ok(_petService.GetAllByType(type));
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
            
        }
    }
}
