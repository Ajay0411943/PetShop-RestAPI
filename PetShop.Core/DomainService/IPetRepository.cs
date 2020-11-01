using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
  public  interface IPetRepository
    {
        Pet Create (Pet pet);
        Pet ReadById(int id);
        IEnumerable<Pet> ReadPets();
        Pet Update(Pet updatePet);
        Pet Delete(int id);
       // void InitialiseData();
    }
}
