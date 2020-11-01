using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SQLData.Repositories
{
   public class PetRepository : IPetRepository
    {
        public PetShopContext _ctx;
        static int id = 1;
        public PetRepository(PetShopContext context)
        {
            _ctx = context;
        }
        public Pet Create(Pet pe)
        {
            pe.Id = id++;
            _ctx.Pets.Add(pe);
            return pe;
        }

        public Pet Delete(int id)
        {
            var petFound = this.ReadById(id);
            if (petFound != null)
            {
                _ctx.Pets.Remove(petFound);
                return petFound;
            }
            return null;
        }

        /*public void InitialiseData()
        {
            _pets = FakeDB.InitData();
            IDAfterInit();
        }*/
       /* private void IDAfterInit()
        {
            id = FakeDB.getID();
        }*/

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in _ctx.Pets)
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
            foreach (var pet in _ctx.Pets)
            {
                if (updatePet.Id == pet.Id)
                {
                    // _ctx.Pets.Remove(pet);
                    // _ctx.Pets.Update(updatePet.Id - 1, updatePet);
                    var entityEntry = _ctx.Update(pet);
                    _ctx.SaveChanges();
                    return entityEntry.Entity;
                }
            }
            return updatePet;

        }
    }
}
