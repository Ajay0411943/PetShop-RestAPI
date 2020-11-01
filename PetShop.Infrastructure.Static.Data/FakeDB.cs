using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShopApp.Infrastructure.Data
{
    public static class FakeDB
    {

        public static List<Pet> allPets = new List<Pet>();
        public static List<Owner> allOwner = new List<Owner>();
        static int id = 1;
        public static void InitData()
        {
            var owner1 = new Owner()
            {
                Id = 1,
                FirstName = "Mate",
                LastName = "Bishop",
                Address = "Wolf of wall streets",
                Email = "matebis@gmail.com",
                PhoneNumber = "+4555353701",
                pet = allPets.Where(p => p.Id == 1 || p.Id == 2).ToList()
            };
            var owner2 = new Owner()
            {
                Id = 2, FirstName = "Greg", LastName = "Nedas", Address = "Turbine Avenue 21, Serbia", Email = "gregNedas@pornmail.com",
                PhoneNumber = "+45111000222", pet = allPets.Where(p => p.Id == 3 || p.Id == 4).ToList()
                };
            allOwner.Add(owner1);
            allOwner.Add(owner2);
            var pet1 = new Pet()
            {
                Id = id++, Name = "Maroon", PreviousOwner = owner1, Type = "Dog", Price = 10000000000000000000,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "White and grey"
            };
            allPets.Add(pet1);

            var pet2 = new Pet()
            {
                Id = id++,
                Name = "Bruno", PreviousOwner = owner1, Type = "Dog", Price = 24000,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "Hybrid"
            };
            allPets.Add(pet2);

            var pet3 = new Pet()
            {
                Id = id++,
                Name = "SnoopDog", PreviousOwner = owner2, Type = "Goat", Price = 50,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "Black"
            };
            allPets.Add(pet3);

            var pet4 = new Pet()
            {
                Id = id++,
                Name = "Max", PreviousOwner = owner2, Type = "Cat", Price = 100,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "Orange"
            };

            allPets.Add(pet4);
            var pet5 = new Pet()
            {
                Id = id++,
                Name = "Pumpkin", PreviousOwner = owner1, Type = "Frog", Price = 2000,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "white"
            };

            allPets.Add(pet5);
            var pet6 = new Pet()
            {
                Id = id++,
                Name = "Kelly", PreviousOwner = owner2, Type = "Cat", Price = 450,
                SoldDate = DateTime.Now, Birthdate = DateTime.Now,
                Color = "Hazel"
            };

            allPets.Add(pet6);
        }
        public static int getID()
        {
            return id;
        }
    }
}

