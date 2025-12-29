namespace MainProgram.ChainDelegateTask;

public delegate void ChainDelegate(int number);

class Chain
{
    public static ChainDelegate? nextAfterPositive;
    public static ChainDelegate? nextAfterEven;

    public static void IsPositive(int number)
    {
        if (number > 0)
        {
            Console.WriteLine("\nNumber is positive.");
            nextAfterPositive?.Invoke(number);
        }
        else
        {
            Console.WriteLine("\nNumber is not positive. Stop.");
        }
    }

    public static void IsEven(int number)
    {
        if (number % 2 == 0)
        {
            Console.WriteLine("\nNumber is even.");
            nextAfterEven?.Invoke(number);
        }
        else
        {
            Console.WriteLine("\nNumber is not even. Stop.");
        }
    }

    public static void IsLessThan100(int number)
    {
        if (number < 100)
        {
            Console.WriteLine("\nNumber is less than 100.");
            Console.WriteLine("\nAll checks passed.");
        }
        else
        {
            Console.WriteLine("\nNumber is bigger than 100. Stop.");
        }
    }
}
