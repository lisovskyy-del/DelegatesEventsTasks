namespace MainProgram;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nChoose task: \n");
            Console.WriteLine("1. Array");
            Console.WriteLine("2. Methods");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int userChoice))
            {
                if (userChoice == 0)
                {
                    Console.WriteLine("\nExitting...");
                    return;
                }
                else if (userChoice == 1)
                {
                    ArrayOperationsTask.Menu.Run();
                }
                else if (userChoice == 2)
                {
                    MethodsTask.Menu.Run();
                }
                else
                {
                    Console.WriteLine("\nInvalid choice! Enter a number between 0-6!");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input! Enter a number!");
            }
        }
    }
}