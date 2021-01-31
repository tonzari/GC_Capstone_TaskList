using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Capstone_TaskList
{
    class BurdenLog
    {
        private List<Burden> burdens; // initialized in contructor
        public List<Burden> Burdens { get => burdens; set => burdens = value; }

        public BurdenLog()
        {
            burdens = new List<Burden>();
        }

        public void AddBurden(Burden burden)
        {
            Burdens.Add(burden);
        }

        public void DeleteBurden(int burdenIndex)
        {
            burdens.RemoveAt(burdenIndex);
        }

        public void PrintBurdens()
        {
            Console.WriteLine($"There are {burdens.Count} burdens to fulfill.");
            Console.WriteLine(Environment.NewLine);

            foreach (Burden burden in burdens)
            {
                Console.WriteLine($"\tBurden:\t{burden.Description}");
                Console.WriteLine($"\tName:\t{burden.TeamMemberName}");
                Console.WriteLine($"\tDue:\t{burden.DueDate}");
                Console.WriteLine($"\tStatus:\t{burden.Status}");
                Console.WriteLine(Environment.NewLine);
            }
        }

        public void EditBurden()
        {

        }

        public void MarkBurdenComplete()
        {

        }
    }
}
