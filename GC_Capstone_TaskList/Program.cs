using System;

namespace GC_Capstone_TaskList
{
    // GC Capston - Task List
    // I'm calling them Burdens. Hehe. 
    // Antonio Manzari

    class Program
    {
        //initialize
        public static BurdenLog OurBurdens = new BurdenLog();
        public static bool userWantsToContinue = true;
        public static string userInput;

        static void Main(string[] args)
        {
            InitDumbyData();
            PrintWelcomeMessage();
            do
            {
                AccessTaskManager();
            } while (userWantsToContinue);

            ExitApp();
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to The Burden Manager!");
        }

        private static void AccessTaskManager()
        {
            OurBurdens.PrintBurdens();
            CheckUserWantsToContinue();

        }

        private static void CheckUserWantsToContinue()
        {
            // Prompt user to continue/quit
            Console.WriteLine("Continue? (y/n):");
            userInput = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            if (userInput.Equals("n"))
            {
                userWantsToContinue = false;
            }
        }

        private static void ExitApp()
        {
            Console.WriteLine("Thanks! Your burdens will follow you even if you quit this app!!!");
            Console.WriteLine("Exiting application...");
        }

        #region TESTS
        private static void TestCreationOfBurdenLog()
        {
            Console.WriteLine($"There are {OurBurdens.Burdens.Count} burdens to fulfill.");

            foreach (Burden burden in OurBurdens.Burdens)
            {
                Console.WriteLine($"Burden: {burden.Description}");
                Console.WriteLine($"Name: {burden.TeamMemberName}");
                Console.WriteLine($"Due: {burden.DueDate}");
                Console.WriteLine($"Status: {burden.Status}");
            }

            OurBurdens.DeleteBurden(1);

            Console.WriteLine($"There are {OurBurdens.Burdens.Count} burdens to fulfill.");

            foreach (Burden burden in OurBurdens.Burdens)
            {
                Console.WriteLine($"Burden: {burden.Description}");
                Console.WriteLine($"Name: {burden.TeamMemberName}");
                Console.WriteLine($"Due: {burden.DueDate}");
                Console.WriteLine($"Status: {burden.Status}");
            }

        }

        private static void InitDumbyData()
        {
            OurBurdens.AddBurden(new Burden("Antonio Manzari", "Clean the bathroom", "12/14/2021"));
            OurBurdens.AddBurden(new Burden("Jim", "eat raccoon", "12/01/2021"));
            OurBurdens.AddBurden(new Burden("Neesha", "jump 5 times", "12/07/2021"));
        }
        #endregion
    }
}
