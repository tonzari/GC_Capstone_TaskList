using System;

namespace GC_Capstone_TaskList
{
    // GC Capston - Task List
    // I'm calling them Burdens. Hehe. 
    // Antonio Manzari

    class Program
    {
        //init some dumby data
        public static BurdenLog OurBurdens = new BurdenLog();


        static void Main(string[] args)
        {

            OurBurdens.AddBurden(new Burden("Antonio Manzari", "Clean the bathroom", "12/14/2021"));

            Console.WriteLine($"There are {OurBurdens.Burdens.Count} burdens to fulfill.");

            foreach (Burden burden in OurBurdens.Burdens)
            {
                Console.WriteLine($"Burden: {burden.Description}");
                Console.WriteLine($"Name: {burden.TeamMemberName}");
                Console.WriteLine($"Due: {burden.DueDate}");
            }



        }
    }
}
