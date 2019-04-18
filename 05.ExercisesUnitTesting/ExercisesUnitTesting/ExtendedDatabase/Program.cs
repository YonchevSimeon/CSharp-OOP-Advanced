using ExtendedDatabase.Models;
using ExtendedDatabase.Models.Interfaces;
using System;

namespace ExtendedDatabase
{
    
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase db = new Database();

            string a = null;

            try
            {
                db.FindBy(a);
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
