using Labb3_SQL_ORM.Models;

namespace Labb3_SQL_ORM
{
    internal class Application
    {
        private static bool stopRunning = false;

        // Initial launch method, runs the application on a loop
        internal static void Launch()
        {
            while (!stopRunning)
            {
                RunApplication();
            }
        }

        // Main method for running the application
        private static void RunApplication()
        {
            DisplayMenuText();
            int userChoice = Input.GetUserChoice();
            stopRunning = ChooseMenuOption(userChoice);

            if (!stopRunning)
            {
                EndOfMenuReached();
            }
        }

        // Method for displaying all the initial menu text
        private static void DisplayMenuText()
        {
            Console.WriteLine("1. Fetch Students\n" +
                "2. Fetch Students of Class\n" +
                "3. Add new Employee\n" +
                "4. Exit Application");
        }

        // Method for handling all the different menu options
        private static bool ChooseMenuOption(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    FetchStudents();
                    break;
                case 2:
                    FetchStudents(chooseFromClass: true);
                    break;
                case 3:
                    AddEmployee();
                    break;
                case 4:
                    return true;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            return false;
        }

        // Method to clear the menu once the user has reached the end of the loop
        private static void EndOfMenuReached()
        {
            Console.Write("\nPlease press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        // Menu method for fetching students
        private static void FetchStudents(bool chooseFromClass = false)
        {
            Console.WriteLine("How do you want to sort the student list?\n" +
                "1. By First Name\n" +
                "2. By Last Name");

            bool nameSort = Input.GetYesOrNoChoice();

            Console.WriteLine("Do you want to sort ascending or descending?\n" +
                "1. Ascending\n" +
                "2. Descending");

            bool orderSort = Input.GetYesOrNoChoice();

            if (!chooseFromClass)
            {
                DataHandler.FetchStudents(nameSort, orderSort);
            }
            else
            {
                FetchStudentsInClass(nameSort, orderSort);
            }
        }

        // Menu method for fetching students from a specific class
        private static void FetchStudentsInClass(bool sortByFirstName, bool ascending)
        {
            Console.WriteLine("Which class do you want to search?");

            var classes = DataHandler.FetchClasses();

            for (int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {classes[i].ClassName}");
            }

            int index = Input.GetIndex(classes.Count);

            DataHandler.FetchStudentsInClass(classes[index].ClassName, sortByFirstName, ascending);
        }

        // Menu method for adding a new employee to the database
        private static void AddEmployee()
        {
            Console.Write("Enter a name for the new employee: ");

            string[] name = Input.GetFirstAndLastName();

            Console.WriteLine("What job does the employee have?\n" +
                "1. Administrator\n" +
                "2. Teacher");

            bool isAdmin = Input.GetYesOrNoChoice();

            DataHandler.AddEmployee(name[0], name[1], isAdmin);
        }
    }
}
