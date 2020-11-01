using PetShop.Core.Entity;
using PetShopApp.Core.ApplicationService;
using System;
using System.Collections.Generic;

namespace PetShop
{
    #region Comments

    /* -- UI -- 
        Console.WriteLine
        Console.Readline
        dkd
    */
    //-- Infrastructue --
    // EF - Static List - Text File

    // --- Test --
    // Unit test for Core

    /*--- CORE -- 
        Customer - Entity - Core.Entity
        Domain Service - Repository / UOW - Core
        Application Service - Service - Core
    */
    #endregion

    public class Printer : IPrinter
    {
        #region Service area

        readonly IPetService _PetService;
        #endregion

        public Printer(IPetService petService)
        {
            _PetService = petService;
            _PetService.InitDatabaseData();
        }

        #region UI

        public void StartUI()
        {
            string[] menuItems = {
                "List All Pets",
                "Add Pet",
                "Delete Pet",
                "Edit Pet",
                "Search by Type",
                "Sort Pets by price",
                "Get 5 cheapest pets",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _PetService.GetPets();
                        ListPets(pets);
                        break;
                    case 2:
                        var name = AskQuestion("Name: ");
                        var type = AskQuestion("Type: ");
                        var previousOwner = AskQuestion("PreviousOwner: ");
                        var price = AskQuestion("Price: ");
                        var soldDate = AskQuestion("Sold date: ");
                        var birthdate = AskQuestion("Birth date: ");
                        var color = AskQuestion("Color: ");

                        var pet = _PetService.NewPet(name, type, previousOwner, Convert.ToDouble(price), 
                                            Convert.ToDateTime(soldDate), Convert.ToDateTime(birthdate), color);
                        _PetService.CreatePet(pet);
                        break;
                    case 3:
                        var idForDelete = PrintFindPetId();
                        _PetService.DeletePet(idForDelete);
                        break;
                    case 4:
                        var idForEdit = PrintFindPetId();
                        var petToEdit = _PetService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name);
                        var newName = AskQuestion("Name: ");
                        var newType = AskQuestion("Type: ");
                        var newPreviousOwner = AskQuestion("PreviousOwner: ");
                        var newPrice = AskQuestion("Price: ");
                        var newSoldDate = AskQuestion("Sold date: ");
                        var newBirthdate = AskQuestion("Birth date: ");
                        var newColor = AskQuestion("Color: ");
                        _PetService.UpdatePet(new Pet()
                        {
                            Id = idForEdit,
                            Name = newName,
                            Type = newType,
                            PreviousOwner = newPreviousOwner,
                            Price = Convert.ToDouble(newPrice),
                            SoldDate = Convert.ToDateTime(newSoldDate),
                            Birthdate = Convert.ToDateTime(newBirthdate),
                            Color = newColor
                        });
                        break;
                    case 5:
                        var chosenType = AskQuestion("Insert type: ");
                        var specifiedTypes = _PetService.getAllByType(chosenType);
                        if (specifiedTypes != null)
                        {
                            ListPets(specifiedTypes);
                        }
                        else
                        {
                            Console.WriteLine("No such type");
                        }
                        break;
                    case 6:
                        var choice = AskQuestion("ASC or DESC: ");
                        if (choice.Contains("ASC"))
                        {
                            ListPets(_PetService.getASC());
                        }
                        else
                        {
                            ListPets(_PetService.getDESC());
                        }
                        break;
                    case 7:
                        ListPets(_PetService.getCheapest());
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }

        int PrintFindPetId()
        {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} Name: {pet.Name} " +
                                $" Type: { pet.Type} " +
                                $" Previous owner: {pet.PreviousOwner} " +
                                $" Price: {pet.Price}" +
                                $" Sold Date: {pet.SoldDate} " +
                                $" Birth Date: {pet.Birthdate} " +
                                $" Color: {pet.Color} "
                                );
            }
            Console.WriteLine("\n");

        }

        int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 8)
            {
                Console.WriteLine("Please select a number between 1-8");
            }

            return selection;
        }
        #endregion

    }

}
