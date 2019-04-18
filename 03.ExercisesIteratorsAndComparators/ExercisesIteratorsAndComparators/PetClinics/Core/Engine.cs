namespace PetClinics.Core
{
    using PetClinics.Factories;
    using PetClinics.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<Pet> pets;
        private List<Clinic> clinics;


        public Engine()
        {
            this.pets = new List<Pet>();
            this.clinics = new List<Clinic>();
        }
        

        public void Run()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            string[] inputArgs;

            for (int curr = 0; curr < numberOfCommands; curr++)
            {
                inputArgs = Console.ReadLine().Split();

                string command = inputArgs[0];

                switch (command)
                {
                    case "Create":
                        string type = inputArgs[1];

                        string[] createArgs = inputArgs.Skip(2).ToArray();

                        if(type == "Pet")
                        {
                            Pet pet = PetFactory.CreatePet(createArgs);
                            pets.Add(pet);
                        }
                        else if(type == "Clinic")
                        {
                            try
                            {
                                Clinic clinic = ClinicFactory.CreateClinic(createArgs);
                                clinics.Add(clinic);
                            }
                            catch(ArgumentException ae)
                            {
                                Console.WriteLine(ae.Message);
                            }
                        }

                        break;

                    case "Add":
                        string addPetName = inputArgs[1];
                        string addClinicName = inputArgs[2];

                        Pet addPet = pets.First(p => p.Name == addPetName);
                        Clinic addClinic = clinics.First(c => c.Name == addClinicName);

                        Console.WriteLine(addClinic.Add(addPet));
                        break;

                    case "Release":
                        string releaseClinicName = inputArgs[1];

                        Clinic releaseClinic = clinics.First(c => c.Name == releaseClinicName);

                        Console.WriteLine(releaseClinic.Release());
                        break;

                    case "HasEmptyRooms":
                        string hasEmptyRoomsClinicName = inputArgs[1];

                        Clinic hasEmptyRoomsClinic = clinics.First(c => c.Name == hasEmptyRoomsClinicName);

                        Console.WriteLine(hasEmptyRoomsClinic.HasEmptyRooms());
                        break;

                    case "Print":
                        string printClinicName = inputArgs[1];

                        Clinic printClinic = clinics.First(c => c.Name == printClinicName);

                        if(inputArgs.Length == 2)
                        {
                            printClinic.Print();
                        }
                        else if(inputArgs.Length > 2)
                        {
                            int room = int.Parse(inputArgs[2]);

                            printClinic.Print(room - 1);
                        }
                        break;
                }
            }
        }
    }
}
