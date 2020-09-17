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
        public IEnumerable<Pet> Get()
        {
            return _petService.GetPets();
        }

        // GET api/<PetShopController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PetShopController>
        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
            _petService.CreatePet(pet);
        }

        // PUT api/<PetShopController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet pet)
        {
          _petService.UpdatePet(pet);
        }

        // DELETE api/<PetShopController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePet(id);
        }
    }
}
