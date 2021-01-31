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
        public static int userNumber;
        public static int maxChoiceRange; // Keeps track of highest user number choice allowed in each menu

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
            PrintMainMenu();
            
            userNumber = GetAndValidateUserNumber();

            switch (userNumber)
            {
                case 1:
                    OurBurdens.PrintBurdens();
                    break;
                case 2:
                    Console.WriteLine("You chose ADD");
                    //OurBurdens.AddBurden();
                    break;
                case 3:
                    Console.WriteLine("You chose EDIT");
                    //OurBurdens.EditBurden();
                    break;
                case 4:
                    Console.WriteLine("You chose DELETE");
                    //OurBurdens.DeleteBurden();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine($"Sorry, an error has occured. Unexpected value: {userNumber}");
                    break;
            }
            

            CheckUserWantsToContinue();
        }

        private static void PrintMainMenu()
        {
            maxChoiceRange = 5;

            Console.WriteLine("1. List Burdens");
            Console.WriteLine("2. Add a Burden");
            Console.WriteLine("3. Edit a Burden");
            Console.WriteLine("4. Delete a Burden");
            Console.WriteLine("5. Quit");
            Console.WriteLine("\nWhat would you like to do?");
        }

        private static int GetAndValidateUserNumber()
        {
            userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out int result) && result >= 1 && result <= maxChoiceRange)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please Try again: ");
                return GetAndValidateUserNumber();
            }
            
        }

        private static void CheckUserWantsToContinue()
        {
            // Prompt user to continue/quit
            Console.WriteLine("Are you sure want to quit? (y/n):");
            userInput = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            if (userInput.Equals("y"))
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
