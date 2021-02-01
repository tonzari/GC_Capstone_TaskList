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

            for (int i = 0; i < burdens.Count; i++)
            {
                PrintBurdenByID(i);
            }
        }

        public void PrintBurdenByID(int index)
        {
            Console.WriteLine($"\tBurden Number:\t{index + 1}");
            Console.WriteLine($"\tDescription:\t{burdens[index].Description}");
            Console.WriteLine($"\tName:\t{burdens[index].TeamMemberName}");
            Console.WriteLine($"\tDue:\t{burdens[index].DueDate}");
            Console.WriteLine($"\tStatus:\t{burdens[index].Status}");
            Console.WriteLine(Environment.NewLine);
        }

        public void EditBurden(int burdenIndex, string teamMemberName, string description, string dueDate)
        {
            burdens[burdenIndex].TeamMemberName = teamMemberName;
            burdens[burdenIndex].Description = description;
            burdens[burdenIndex].DueDate = dueDate;
        }

        public void MarkBurdenComplete(int burdenIndex)
        {
            burdens[burdenIndex].IsCompleted = true;
        }
    }
}
