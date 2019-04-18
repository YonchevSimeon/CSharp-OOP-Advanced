namespace PetClinics.Factories
{
    using PetClinics.Models;

    public static class ClinicFactory
    {
        public static Clinic CreateClinic(string[] args)
        {
            string name = args[0];
            int numberOfRooms = int.Parse(args[1]);

            Clinic clinic = new Clinic(name, numberOfRooms);

            return clinic;
        }
    }
}
