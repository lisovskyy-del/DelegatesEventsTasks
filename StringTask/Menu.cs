namespace MainProgram.StringTask;

class Menu
{
    static string StringInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (input != null)
            {
                return input;
            }
            Console.WriteLine("\nInvalid input. Please enter a string.");
        }
    }

    public static void Run()
    {
        StringOperations stringOperations = String.CountVowels;
        stringOperations += String.CountConsonants;
        stringOperations += String.GetStringLength;

        while (true)
        {
            Console.WriteLine("\n1. Enter a string");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int userChoice))
            {
                if (userChoice == 0)
                {
                    Console.WriteLine("\nExitting...");
                    break;
                }
                else if (userChoice == 1)
                {
                    string text = StringInput("\nEnter a string: ");

                    if (text != null)
                    {
                        Console.WriteLine("\n1. Do string operations (count vowels, consonants, get length)");
                        Console.WriteLine("0. Exit");
                        Console.Write("Your choice: ");
                        string? textInput = Console.ReadLine();

                        if (int.TryParse(textInput, out int textChoice))
                        {
                            if (textChoice == 0)
                            {
                                Console.WriteLine("\nExitting...");
                                break;
                            }
                            else if (textChoice == 1)
                            {
                                stringOperations(text);
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
