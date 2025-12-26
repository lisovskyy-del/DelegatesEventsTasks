namespace MainProgram.ArrayOperationsTask;

public class Menu
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

    static Array ArrayInput()
    {
        int capacity = IntInput("\nEnter capacity for array: ");
        return new Array(capacity);
    }

    public static void Run()
    {
        Array? array = null;

        FilteredArray filteredArray = Array.ShowEven;
        filteredArray += Array.ShowOdd;
        filteredArray += Array.ShowPrime;
        filteredArray += Array.ShowFibonacci;

        while (true)
        {
            Console.WriteLine("\n1. Create an array");
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
                    array = ArrayInput();

                    if (array != null)
                    {
                        while (true)
                        {
                            Console.WriteLine("\n1. Add elements into array");
                            Console.WriteLine("2. Proceed further");
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
                                    int number = IntInput("\nEnter a number: ");
                                    array.Add(number);
                                }
                                else if (elementChoice == 2)
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("\n1. Perform operations with array (show even, show odd, etc.)");
                                        Console.WriteLine("0. Exit");
                                        Console.Write("Your choice: ");
                                        string? arrayInput = Console.ReadLine();

                                        if (int.TryParse(arrayInput, out int arrayChoice))
                                        {
                                            if (arrayChoice == 0)
                                            {
                                                Console.WriteLine("\nExitting...");
                                                break;
                                            }
                                            else if (arrayChoice == 1)
                                            {
                                                if (array != null)
                                                {
                                                    filteredArray(array);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nError! Array is empty!");
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
                                else
                                {
                                    Console.WriteLine("\nInvalid choice! Enter a number between 0-2!");
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