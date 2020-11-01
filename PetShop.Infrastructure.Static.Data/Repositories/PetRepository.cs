using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PetShopApp.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        static int id = 1;
        private static List<Pet> _pets = FakeDB.allPets;
        public Pet Create(Pet pe)
        {
            pe.Id = id++;
            _pets.Add(pe);
            return pe;
        }

        public Pet Delete(int id)
        {
            var petFound = this.ReadById(id);
            if (petFound != null)
            {
                _pets.Remove(petFound);
                return petFound;
            }
            return null;
        }

        /*public void InitialiseData()
        {
            _pets = FakeDB.InitData();
            IDAfterInit();
        }*/
        private void IDAfterInit()
        {
            id = FakeDB.getID();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _pets;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet Update(Pet updatePet)
        {
            foreach (var pet in _pets)
            {
                if (updatePet.Id == pet.Id)
                {
                    _pets.Remove(pet);
                    _pets.Insert(updatePet.Id - 1, updatePet);
                }
            }
            return updatePet;   

        }
    }

  
}
