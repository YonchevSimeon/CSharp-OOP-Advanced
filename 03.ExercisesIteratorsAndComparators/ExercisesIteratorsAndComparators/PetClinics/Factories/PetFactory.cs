namespace PetClinics.Factories
{
    using PetClinics.Models;

    public static class PetFactory
    {
        public static Pet CreatePet(string[] args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);
            string kind = args[2];

            Pet pet = new Pet(name, age, kind);

            return pet;
        }
    }
}
