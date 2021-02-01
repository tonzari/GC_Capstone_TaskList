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

        ///<summary>
        ///Prints all burderns. Optional: choose simple or detailed list style type by passing in an int:
        ///1. Simple
        ///2. Detailed (default)
        ///</summary>
        public void PrintAllBurdens(int listStyleType = 2)
        {
            if (burdens.Count == 0)
            {
                Console.WriteLine("There are no Burdens! Lucky you!");
            }
            else
            {
                if (listStyleType == 1)
                {
                    for (int i = 0; i < burdens.Count; i++)
                    {
                        Console.WriteLine($"\t{i + 1}.\t{burdens[i].Description}");
                    }
                }
                if (listStyleType == 2)
                {
                    for (int i = 0; i < burdens.Count; i++)
                    {
                        PrintBurdenByID(i);
                    }
                }
            }
        }

        public void PrintBurdenByID(int index)
        {
            Console.WriteLine($"\tBurden Number:\t{index + 1}");
            Console.WriteLine($"\tDescription:\t{burdens[index].Description}");
            Console.WriteLine($"\tName:\t{burdens[index].TeamMemberName}");
            Console.WriteLine($"\tDue:\t{burdens[index].DueDate}");
            Console.WriteLine($"\tStatus:\t{burdens[index].Status}");
            Console.WriteLine("");
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
