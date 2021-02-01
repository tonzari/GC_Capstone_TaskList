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
        public static int availableOptions; // Keeps track of highest user number choice allowed in each menu

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
            
            Console.WriteLine(" ");

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
                    AccessDeletePage();
                    break;
                case 5:
                    AccessMarkCompletePage();
                    break;
                case 6:
                    ExitApp();
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
            availableOptions = 6;
            Console.WriteLine("- - - - - - - - - - - - - ");
            Console.WriteLine("  M A I N   M E N U");
            Console.WriteLine("- - - - - - - - - - - - - ");
            Console.WriteLine("\t1.\tList all Burdens");
            Console.WriteLine("\t2.\tAdd a Burden");
            Console.WriteLine("\t3.\tEdit a Burden");
            Console.WriteLine("\t4.\tDelete a Burden");
            Console.WriteLine("\t5.\tMark Burden Complete");
            Console.WriteLine("\t6.\tQuit");
            Console.WriteLine($"\n\tYour team is carrying {OurBurdens.Burdens.Count} Burdens.");
            Console.WriteLine("\tWhat would you like to do? Enter a number and press enter:");
        }

        private static void AccessListPage()
        {
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
            availableOptions = OurBurdens.Burdens.Count;

            Console.WriteLine("- - - - - - - - - - - - - ");
            Console.WriteLine("  E D I T  A  B U R D E N");
            Console.WriteLine("- - - - - - - - - - - - - ");

            Console.WriteLine("");
            OurBurdens.PrintAllBurdens(1);
            Console.WriteLine("");

            if (availableOptions == 0)
            {
                return;
            }
            else
            {
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
        }

        private static void AccessDeletePage()
        {
            availableOptions = OurBurdens.Burdens.Count;

            Console.WriteLine("- - - - - - - - - - - - - - - -");
            Console.WriteLine("  D E L E T E  A  B U R D E N");
            Console.WriteLine("- - - - - - - - - - - - - - - -");

            Console.WriteLine("");
            OurBurdens.PrintAllBurdens(1);
            Console.WriteLine("");

            if (availableOptions == 0)
            {
                return;
            }
            else
            {
                Console.Write("\n\tTo delete a Burden, please enter its Burden Number:  ");
                userNumber = GetAndValidateUserNumber();

                Console.WriteLine($"\n\tSee current entry for Burden {userNumber} below:\n");
                OurBurdens.PrintBurdenByID(userNumber - 1);

                Console.Write($"\n\tAre you sure want to delete this Burden? Enter y or n: ");

                userInput = GetAndValidateYesOrNo();

                if (userInput.Equals("y"))
                {
                    OurBurdens.DeleteBurden(userNumber - 1);
                }
                else if (userInput.Equals("n"))
                {
                    return;
                }
            }
        }

        private static void AccessMarkCompletePage()
        {
            availableOptions = OurBurdens.Burdens.Count;

            Console.WriteLine("- - - - - - - - - - - - - - -");
            Console.WriteLine("  M A R K  C O M P L E T E ");
            Console.WriteLine("- - - - - - - - - - - - - - -");

            Console.WriteLine("");
            OurBurdens.PrintAllBurdens(1);
            Console.WriteLine("");

            if (availableOptions == 0)
            {
                return;
            }
            else
            {
                Console.Write("\n\tTo mark a Burden complete, please enter its Burden Number:  ");
                userNumber = GetAndValidateUserNumber();

                Console.WriteLine($"\n\tSee current entry for Burden {userNumber} below:\n");
                OurBurdens.PrintBurdenByID(userNumber - 1);

                Console.Write($"\n\tAre you sure want to mark this Burden complete? Enter y or n: ");

                userInput = GetAndValidateYesOrNo();

                if (userInput.Equals("y"))
                {
                    OurBurdens.MarkBurdenComplete(userNumber - 1);
                }
                else if (userInput.Equals("n"))
                {
                    return;
                }
            }
        }

        private static int GetAndValidateUserNumber()
        {
            // First checks if input is a number
            // Then checks if the number is within the current max range
            // The range updates each time a new menu is accessed. 

            userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out int result) && result >= 1 && result <= availableOptions)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please Try again: ");
                return GetAndValidateUserNumber();
            }
            
        }

        private static string GetAndValidateYesOrNo()
        {
            userInput = Console.ReadLine();

            if (userInput.Equals("y"))
            {
                return "y";
            }
            else if (userInput.Equals("n"))
            {
                return "n";
            }
            else
            {
                Console.WriteLine("\tInvalid input. Please enter: y or n");
                return GetAndValidateYesOrNo();
            }
        }

        private static void CheckUserWantsToContinue()
        {
            // Prompt user to continue/quit
            Console.WriteLine(Environment.NewLine);

            Console.Write("\tOk! Go back to the main menu? Enter y or n: ");
           
            userInput = Console.ReadLine();
            
            Console.WriteLine("");
            
            if (userInput.Equals("y"))
            {
                userWantsToContinue = true;
            }
            else if (userInput.Equals("n"))
            {
                userWantsToContinue = false;
            }
            else
            {
                Console.WriteLine("\tInvalid input. Please enter: y or n");
                CheckUserWantsToContinue();
            }
        }

        private static void ExitApp()
        {
            Console.WriteLine("Thanks! Your burdens will follow you even if you quit this app!!!");
            Console.WriteLine("Exiting application...");
            System.Environment.Exit(1);
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
