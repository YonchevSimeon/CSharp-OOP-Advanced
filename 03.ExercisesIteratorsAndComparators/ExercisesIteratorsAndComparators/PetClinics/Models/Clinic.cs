namespace PetClinics.Models
{
    using System;
    using System.Linq;

    public class Clinic
    {
        public Clinic(string name, int roomsCount)
        {
            this.Name = name;

            if(roomsCount % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            this.Rooms = new Room[roomsCount];
            this.GetRooms();
        }

        public string Name { get; private set; }

        public Room[] Rooms { get; private set; }

        public int CentralRoom => this.Rooms.Length / 2;

        public bool Add(Pet pet)
        {
            if (!HasEmptyRooms())
            {
                return false;
            }

            if(this.Rooms[this.CentralRoom].Pet == null)
            {

                this.Rooms[this.CentralRoom].SetPet(pet);

                return true;
            }

            for (int room = 0; room < this.Rooms.Length; room++)
            {
                int leftRoom = this.CentralRoom - room;
                int rightRoom = this.CentralRoom + room;
                
                if(leftRoom >= 0 && this.Rooms[leftRoom].Pet == null)
                {
                    this.Rooms[leftRoom].SetPet(pet);

                    return true;
                }
                else if(rightRoom < this.Rooms.Length && this.Rooms[rightRoom].Pet == null )
                {
                    this.Rooms[rightRoom].SetPet(pet);

                    return true;
                }
            }

            return false;
        }

        public bool Release()
        {
            for (int room = this.CentralRoom; room < this.Rooms.Length; room++)
            {
                if(this.Rooms[room].Pet != null)
                {
                    this.Rooms[room] = new Room();

                    return true;
                }
            }

            for (int room = 0; room < this.CentralRoom; room++)
            {
                if(this.Rooms[room].Pet != null)
                {
                    this.Rooms[room] = new Room();

                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.Rooms.Any(r => r.Pet == null);
        }

        public void Print()
        {
            foreach (Room room in this.Rooms)
            {
                Console.WriteLine(room);
            }
        }

        public void Print(int room)
        {
            Console.WriteLine(this.Rooms[room].ToString());
        }

        private void GetRooms()
        {
            for (int index = 0; index < this.Rooms.Length; index++)
            {
                this.Rooms[index] = new Room();
            }
        }
    }
}
