using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainServices
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);
        Owner ReadById(int id);
        IEnumerable<Owner> ReadOwners();
        Owner Update(Owner petUpdate);
        Owner Delete(int id);
    }
}

