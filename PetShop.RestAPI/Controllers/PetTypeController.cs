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
        public ActionResult<IEnumerable<PetType>> Get()
        {
            try
            {
                return _petTypeService.GetPetTypes();
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wront");
            }
        }

        // GET api/<PetTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id)
        {
            if (id < 1)
            {
                return StatusCode(404, "id must be above 0");
            }

            try
            {
                return Ok(_petTypeService.FindPetTypeById(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Not Found");
            }
        }

        // POST api/<PetTyperController>
        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType petType)
        {
            if (string.IsNullOrEmpty(petType.Type))
            {
                return BadRequest("Enter IndPut");
            }

            try
            {
                return Ok(_petTypeService.CreatePetType(petType));
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
        }

        // PUT api/<PetTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType petType)
        {
            var updatePetType =_petTypeService.UpdatePetType(petType);
            if (updatePetType == null)
            {
                return StatusCode(404, "PetType Not Found");
            }

            try
            {
                return Ok(updatePetType);
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
        }

        // DELETE api/<PetTypeController>/5
        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            var petType =_petTypeService.DeletePetType(id);
            if (petType == null)
            {
                return StatusCode(404, "PetType Id" + id + "Was not found");
            }

            try
            {
                return Ok(petType);
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
        }

        [HttpGet("{type}")]
        [Route("[action]/{type}")]
        public ActionResult<List<PetType>> GetFilteredType(string type)
        {
            try
            {
                return Ok(_petTypeService.GetAllByType(type));
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
        }
    }
}
