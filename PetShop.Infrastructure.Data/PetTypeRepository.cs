using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data
{
    public class PetTypeRepository : IPetTypeRepository
    {
        static int id = 1;
        static List<PetType> _petTypes = new List<PetType>();
        public PetType Create(PetType petType)
        {
            petType.Id = id++;
            _petTypes.Add(petType);
            return petType;
        }

        public PetType ReadById(int id)
        {
            return DataInitializer.PetTypes.Select(p => new PetType()
            {
                Id = p.Id,
                Type = p.Type
            }).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<PetType> ReadPetTypes()
        {
            return _petTypes;
        }

        public PetType Update(PetType petTypeUpdate)
        {
            var petTypeDB = this.ReadById(petTypeUpdate.Id);
            if (petTypeDB != null)
            {
                petTypeDB.Type = petTypeUpdate.Type;
            }
            return null;
        }

        public IEnumerable<PetType> ReadPetType()
        {
            return _petTypes;
        }

        public PetType Delete(int id)
        {
            var petTypeFound = this.ReadById(id);
            if (petTypeFound != null)
            {
                _petTypes.Remove(petTypeFound);
                return petTypeFound;
            }

            return null;
        }
    }
}
