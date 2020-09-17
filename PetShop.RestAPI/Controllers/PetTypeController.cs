using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entity;

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypeController : ControllerBase
    {
        private readonly IPetTypeService _petTypeService;

        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }

        // GET: api/<PetTypeController>
        [HttpGet]
        public IEnumerable<PetType> Get()
        {
            return _petTypeService.GetPetTypes();
        }

        // GET api/<PetTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id)
        {
            if (id < 1)
            {
                return StatusCode(500, "id must be above 0");
            }

            if (id != null)
            {
                return _petTypeService.FindPetByIdIncludeType(id);
            }

            return StatusCode(404, "Not Found");
        }

        // POST api/<PetTyperController>
        [HttpPost]
        public void Post([FromBody] PetType petType)
        {
            _petTypeService.CreatePetType(petType);
        }

        // PUT api/<PetTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PetType petType)
        {
            _petTypeService.UpdatePetType(petType);
        }

        // DELETE api/<PetTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petTypeService.DeletePetType(id);
        }
    }
}
