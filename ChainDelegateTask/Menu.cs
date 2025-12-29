namespace MainProgram.ChainDelegateTask;

class Menu
{
    static int IntInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            Console.WriteLine("\nInvalid input. Please enter a number.");
        }
    }

    public static void Run()
    {
        ChainDelegate checkPositive = Chain.IsPositive;
        ChainDelegate checkEven = Chain.IsEven;
        ChainDelegate checkLessThan100 = Chain.IsLessThan100;

        Chain.nextAfterPositive = checkEven;
        Chain.nextAfterEven = checkLessThan100;

        while (true)
        {
            Console.WriteLine("\n1. Input a number");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int userChoice))
            {
                if (userChoice == 0)
                {
                    Console.WriteLine("\nExitting..");
                    break;
                }
                else if (userChoice == 1)
                {
                    int number = IntInput("\nEnter a number: ");

                    while (true)
                    {
                        Console.WriteLine("\n1. Do number operations (check if positive, even, less than 100)");
                        Console.WriteLine("0. Exit");
                        Console.Write("Your choice: ");
                        string? choice = Console.ReadLine();

                        if (int.TryParse(choice, out int elementChoice))
                        {
                            if (elementChoice == 0)
                            {
                                Console.WriteLine("\nExitting...");
                                break;
                            }
                            else if (elementChoice == 1)
                            {
                                checkPositive(number);
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid choice! Enter a number between 0-1!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input! Enter a number!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid choice! Enter a number between 0-1!");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input! Enter a number!");
            }
        }
    }
}
