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
        public IEnumerable<Owner> Get()
        {
            return _ownerService.GetOwners();
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return _ownerService.FindOwnerById(id);
        }

        // POST api/<OwnerController>
        [HttpPost]
        public void Post([FromBody] Owner owner)
        {
            _ownerService.CreateOwner(owner);
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Owner owner)
        {
            _ownerService.UpdateOwner(owner);
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerService.DeleteOwner(id);
        }

        [HttpGet("{name}")]
        [Route("[action]/{name}")]
        public ActionResult<List<Owner>> GetFilteredOwner(string name)
        {
            return _ownerService.GetAllByName(name);
        }
    }
}
