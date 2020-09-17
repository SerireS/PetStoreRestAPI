using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationServices.Services
{
    public class PetTypeService : IPetTypeService
    {
        private readonly IPetTypeRepository _petTypeRepo;
        private readonly IPetRepository _petRepo;

        public PetTypeService(IPetTypeRepository petTypeRepository, IPetRepository petRepository)
        {
            _petTypeRepo = petTypeRepository;
            _petRepo = petRepository;
        }

        public PetType NewPetType(string type)
        {
            var petType = new PetType()
            {
                Type = type
            };
            return petType;
        }

        public PetType CreatePetType(PetType petType)
        {
            return _petTypeRepo.Create(petType);
        }

        public List<PetType> GetPetTypes()
        {
            return _petTypeRepo.ReadPetType().ToList();
        }

        public PetType FindPetByIdIncludeType(int id)
        {
            var petType = _petTypeRepo.ReadById(id);
            petType.Pets = _petRepo.ReadPets().Where(pet => pet.Type.Id == petType.Id).ToList();
            return petType;
        }

        public PetType FindPetTypeById(int id)
        {
            return _petTypeRepo.ReadById(id);
        }

        public PetType UpdatePetType(PetType updatePetType)
        {
            var petType = FindPetTypeById(updatePetType.Id);
            petType.Type = updatePetType.Type;
            return petType;
        }

        public PetType DeletePetType(int id)
        {
            return _petTypeRepo.Delete(id);
        }
    }
}
