using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShopApp.Core.ApplicationService.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepo;

        public PetService(IPetRepository perReposit)
        {
            _petRepo = perReposit;
        }

        public Pet CreatePet(Pet pe)
        {
            return _petRepo.Create(pe);
        }

        public Pet DeletePet(int id)
        {
            return _petRepo.Delete(id);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadById(id);
        }

        public List<Pet> getAllByType(string chosenType)
        {
            var allPets = GetPets();
            List<Pet> searchedListOfPets = new List<Pet>();
            foreach (var pet in allPets)
            {
                if (pet.Type.Contains(chosenType))
                {
                    searchedListOfPets.Add(pet);
                }
            }
            return searchedListOfPets;
        }

        public List<Pet> getASC()
        {
            return GetPets().OrderBy(o => o.Price).ToList();
        }

        public List<Pet> getCheapest()
        {
            var cheapPets = getASC();
            return cheapPets.Take(5).ToList();
        }

        public List<Pet> getDESC()
        {
            return GetPets().OrderByDescending(o => o.Price).ToList();
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }

       /* public void InitDatabaseData()
        {
            _petRepo.InitialiseData();
        }*/

        public Pet NewPet(string name, string type,  double price, DateTime soldDate, DateTime birthdate, string color)
        {
            var pe = new Pet()
            {
                Name = name,
                Type = type,
                Price = price,
                SoldDate = soldDate,
                Birthdate = birthdate,
                Color = color
            };
            return pe;
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);
            pet.Name = petUpdate.Name;
            pet.Type = petUpdate.Type;
            pet.PreviousOwner = petUpdate.PreviousOwner;
            pet.Price = petUpdate.Price;
            pet.SoldDate = petUpdate.SoldDate;
            pet.Birthdate = petUpdate.Birthdate;
            pet.Color = petUpdate.Color;
            return pet;
        }
    }
}
