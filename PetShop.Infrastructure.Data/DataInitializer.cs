using System;
using System.Collections.Generic;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data
{
    public class DataInitializer
    {
        private readonly IPetRepository _petRepo;
        private readonly IOwnerRepository _ownerRepo;
        private readonly IPetTypeRepository _petTypeRepo;

        public static readonly List<Pet> Pets = new List<Pet>();

        public static readonly List<PetType> PetTypes = new List<PetType>();

        public DataInitializer(IPetRepository petRepository, IOwnerRepository ownerRepository, IPetTypeRepository petTypeRepository )
        {
            _petRepo = petRepository;
            _ownerRepo = ownerRepository;
            _petTypeRepo = petTypeRepository;
        }

        public void InitData()
        {
            /*var address = new Address()
            {
                StreetName = "smurf"
            };
           address = _addressRepo.AddAddress(address);
*/

            var petType1 = new PetType
            {
                Type = "Doggos"
            };
            PetTypes.Add(petType1);

            var pet1 = new Pet
            {
                Name = "John",
                Type = "Dog", 
                BirthDate = new DateTime(2020, 10, 10),
                SoldDate = new DateTime(2020, 10, 10),
                Color = "green",
                PreviousOwner = "gert",
                Price = 434
            };
            Pets.Add(pet1);

            var owner1 = new Owner
            {
                Name = "tiltert",
                Address = "eart"
            };

            _ownerRepo.Create(owner1);
            _petTypeRepo.Create(petType1);
            _petRepo.Create(pet1);
        }
    }
}