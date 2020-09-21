using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Services;
using PetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            try
            {
                return Ok(_ownerService.GetOwners());
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            var ownerId = _ownerService.FindOwnerById(id);
            if (ownerId == null)
            {
                return StatusCode(404, "Id Must Be Above 0");
            }

            try
            {
                return Ok(ownerId);
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
        }

        // POST api/<OwnerController>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.Name))
            {
                return BadRequest("Enter A Name");
            }

            if (string.IsNullOrEmpty(owner.Address))
            {
                return BadRequest("Enter A Address");
            }
            return Ok(_ownerService.CreateOwner(owner));
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            var updateOwner =_ownerService.UpdateOwner(owner);
            if (updateOwner == null)
            {
                return StatusCode(404, "Owner Was Not Found");
            }

            try
            {
                return Ok(updateOwner);
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner = _ownerService.DeleteOwner(id);
            if (owner == null)
            {
                return StatusCode(404, "Owner With Id " + id + "Was Not Found");
            }

            try
            {
                return Ok(owner);
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
        }

        [HttpGet("{name}")]
        [Route("[action]/{name}")]
        public ActionResult<List<Owner>> GetFilteredOwner(string name)
        {
            try
            {
                return Ok(_ownerService.GetAllByName(name));
            }
            catch (Exception)
            {
                return StatusCode(500, "Smth Went Wrong");
            }
        }
    }
}
