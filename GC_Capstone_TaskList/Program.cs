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
                AccessBurdenManager();
            } while (userWantsToContinue);

            ExitApp();
        }

        private static void AccessBurdenManager()
        {
            PrintMainMenu();
            
            userNumber = GetAndValidateUserNumber();
            
            Console.WriteLine(Environment.NewLine);

            switch (userNumber)
            {
                case 1:
                    AccessListPage();
                    break;
                case 2:
                    AccessAddPage();
                    break;
                case 3:
                    AccessEditPage();
                    break;
                case 4:
                    Console.WriteLine("You chose DELETE");
                    //OurBurdens.DeleteBurden();
                    break;
                case 5:
                    Console.WriteLine("You chose MARK TASK COMPLETE");
                    break;
                default:
                    Console.WriteLine($"Sorry, an error has occured. Unexpected value: {userNumber}");
                    break;
            }
            
            CheckUserWantsToContinue();
        }

        #region METHODS

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to The Burden Manager!");
            Console.WriteLine("");
        }

        private static void PrintMainMenu()
        {
            maxChoiceRange = 5;
            Console.WriteLine("- - - - - - - - - - - - - ");
            Console.WriteLine("  M A I N   M E N U");
            Console.WriteLine("- - - - - - - - - - - - - ");
            Console.WriteLine("\t1.\tList all Burdens");
            Console.WriteLine("\t2.\tAdd a Burden");
            Console.WriteLine("\t3.\tEdit a Burden");
            Console.WriteLine("\t4.\tDelete a Burden");
            Console.WriteLine("\t5.\tMark Burden Complete");
            Console.WriteLine("\t6.\tQuit");
            Console.WriteLine("\nWhat would you like to do? Enter a number and press enter:");
        }

        private static void AccessListPage()
        {
            Console.WriteLine($"There are {OurBurdens.Burdens.Count} burdens to fulfill.");
            Console.WriteLine(Environment.NewLine);
            OurBurdens.PrintAllBurdens();
        }

        private static void AccessAddPage()
        {
            Console.WriteLine("- - - - - - - - - - - - - ");
            Console.WriteLine("  A D D  A  B U R D E N");
            Console.WriteLine("- - - - - - - - - - - - - ");

            Console.Write("\tEnter Burden Holder's Name: ");
            string newMemberName = Console.ReadLine();

            Console.Write("\tEnter a Description: ");
            string newDescription = Console.ReadLine();

            Console.Write("\tEnter a Due Date (MM/DD/YYYY): ");
            string newDueDate = Console.ReadLine();

            OurBurdens.AddBurden(new Burden(newMemberName, newDescription, newDueDate));
        }

        private static void AccessEditPage()
        {
            maxChoiceRange = OurBurdens.Burdens.Count;

            Console.WriteLine("- - - - - - - - - - - - - ");
            Console.WriteLine("  E D I T  A  B U R D E N");
            Console.WriteLine("- - - - - - - - - - - - - ");

            Console.WriteLine("");
            OurBurdens.PrintAllBurdens(1);
            Console.WriteLine("");

            Console.Write("\n\tTo edit a Burden, please enter its Burden Number:  ");
            userNumber = GetAndValidateUserNumber();

            Console.WriteLine($"\n\tSee current entry for Burden {userNumber} below:\n");
            OurBurdens.PrintBurdenByID(userNumber - 1);

            Console.WriteLine($"\n\tPlease re-enter the details now: \n");

            Console.Write("\tEnter Burden Holder's Name: ");
            string newMemberName = Console.ReadLine();

            Console.Write("\tEnter a Description: ");
            string newDescription = Console.ReadLine();

            Console.Write("\tEnter a Due Date (MM/DD/YYYY): ");
            string newDueDate = Console.ReadLine();

            OurBurdens.EditBurden(userNumber - 1, newMemberName, newDescription, newDueDate);
        }

        private static int GetAndValidateUserNumber()
        {
            // First checks if input is a number
            // Then checks if the number is within the current max range
            // The range updates each time a new menu is accessed. 

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
            Console.WriteLine(Environment.NewLine);

            Console.Write("Ok! Go back to the main menu? Enter y or n: ");
           
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

        #endregion

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
