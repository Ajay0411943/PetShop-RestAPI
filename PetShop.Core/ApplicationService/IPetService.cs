using PetShop.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        //Create
        Pet CreatePet(Pet pe);
        //Read
        Pet FindPetById(int id);
        List<Pet> GetPets();
        //Update
        Pet UpdatePet(Pet petUpdate);

        //Delete
        Pet DeletePet(int id);
        Pet NewPet(string name, string type, double price, DateTime soldDate, DateTime birthdate, string color);
        List<Pet> getASC();
        List<Pet> getDESC();
        List<Pet> getCheapest();
        List<Pet> getAllByType(string chosenType);
       // void InitDatabaseData();
    }
}
