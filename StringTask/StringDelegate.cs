namespace MainProgram.StringTask;

public delegate void StringOperations(string input);

class StringDelegate
{
    public static void CountVowels(string input)
    {
        int total = 0;
        string vowels = "aeiouAEIOU";

        foreach (char c in input)
        {
            if (vowels.Contains(c))
            {
                total++;
            }
        }

        Console.WriteLine($"\nAmount of vowels in a string: {total}");
    }

    public static void CountConsonants(string input)
    {
        int total = 0;
        string vowels = "aeiouAEIOU";

        foreach (char c in input)
        {
            if (char.IsLetter(c) && !vowels.Contains(c))
            {
                total++;
            }
        }

        Console.WriteLine($"\nAmount of consonants in a string: {total}");
    }

    public static void GetStringLength(string input)
    {
        Console.WriteLine($"\nLength of the string: {input.Length}");
    }
}
