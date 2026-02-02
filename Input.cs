namespace Labb3_SQL_ORM
{
    internal class Input
    {
        // Method for getting input int from user
        internal static int GetUserChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Error: Invalid input, please try again.");
            }

            return choice;
        }

        internal static int GetIndex(int maxIndex)
        {
            int index = GetUserChoice();
            while (index > maxIndex)
            {
                Console.WriteLine("Error: Invalid index, please try again.");
                index = GetUserChoice();
            }

            return index - 1;
        }

        // Method for getting bool based on GetUserChoice
        internal static bool GetYesOrNoChoice()
        {
            int choice = GetUserChoice();

            if (choice == 1)
            {
                return true;
            }

            return false;
        }

        internal static string GetUserString()
        {
            string? input = Console.ReadLine();

            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Error: Invalid input, please try again.");
                input = Console.ReadLine();
            }

            return input;
        }

        internal static string[] GetFirstAndLastName()
        {
            string[] name = GetUserString().Split(' ');

            while (name.Length < 2)
            {
                Console.WriteLine("Error: Invalid name, please try again.");
                name = GetUserString().Split(' ');
            }

            string firstName = char.ToUpper(name[0][0]) + name[0].Substring(1);
            string lastName = char.ToUpper(name[1][0]) + name[1].Substring(1);

            return [firstName, lastName];
        }
    }
}
