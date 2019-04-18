namespace PetClinics.Models
{
    using System;

    public class Room
    {
        public Pet Pet { get; private set; }

        public void SetPet(Pet pet)
        {
            this.Pet = pet;
        }

        public override string ToString()
        {
            if(this.Pet == null)
            {
                return "Room empty";
            }
            else
            {
                return this.Pet.ToString();
            }
        }
    }
}
