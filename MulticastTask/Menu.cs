using System.ComponentModel.Design;

namespace MainProgram.MulticastTask;
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
        MulticastDelegate multicast = Multicast.PrintInput;
        multicast += Multicast.WriteToFile;

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
                        while (true)
                        {
                            Console.WriteLine("\n1. Do string operations (print input, write to file)");
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
                                    multicast(text);
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
                else
                {
                    Console.WriteLine("\nInvalid choice! Enter a nmber between 0-1!");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input! Enter a number!");
            }
        }
    }
}
