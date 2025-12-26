namespace MainProgram.MethodsTask;

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
        Action showTime = Utils.ShowCurrentTime;
        Action showDate = Utils.ShowCurrentDate;
        Action showDay = Utils.ShowCurrentDay;

        Func<double, double, double> calculateTriangle = Utils.TriangleArea;
        Func<double, double, double> calculateRectangle = Utils.RectangleArea;

        while (true)
        {
            Console.WriteLine("\n1. Show current time");
            Console.WriteLine("2. Show current date");
            Console.WriteLine("3. Show current day");
            Console.WriteLine("4. Calculate area of triangle");
            Console.WriteLine("5. Calculate area of rectangle");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice:");
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
                    showTime();
                }
                else if (userChoice == 2)
                {
                    showDate();
                }
                else if (userChoice == 3)
                {
                    showDay();
                }
                else if (userChoice == 4)
                {
                    int a = IntInput("\nEnter a number: ");
                    int b = IntInput("\nEnter a number: ");

                    if (a < 0 || b < 0)
                    {
                        Console.WriteLine("\nError! One or both numbers are less than 0!");
                        break;
                    }

                    Console.WriteLine(calculateTriangle(a, b));
                }
                else if (userChoice == 5)
                {

                    int a = IntInput("\nEnter a number: ");
                    int b = IntInput("\nEnter a number: ");

                    if (a < 0 || b < 0)
                    {
                        Console.WriteLine("\nError! One or both numbers are less than 0!");
                        break;
                    }

                    Console.WriteLine(calculateRectangle(a, b));
                }
                else
                {
                    Console.WriteLine("\nInvalid choice! Enter a number between 0-5!");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input! Enter a number!");
            }
        }
    }
}
