namespace MainProgram.CreditCardTask;

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

    static DateTime DateTimeInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (DateTime.TryParse(input, out DateTime result))
            {
                return result;
            }

            Console.WriteLine("\nInvalid date. Please enter a valid date (e.g. 01.01.2026).");
        }
    }

    static CreditCard CreditCardInput()
    {
        int id = IntInput("Enter ID: ");
        string fullName = StringInput("Enter full name: ");
        DateTime expirationDate = DateTimeInput("Enter expiration date: ");
        string pin = StringInput("Enter PIN: ");
        int creditLimit = IntInput("Enter credit limit: ");
        int balance = IntInput("Enter balance: ");
        int targetAmount = IntInput("Enter target amount: ");

        return new CreditCard(id, fullName, expirationDate, pin, creditLimit, balance, targetAmount);
    }

    static void CreditCard_MoneyAdded(object? sender, MoneyAddedEventArgs e)
    {
        Console.WriteLine($"\nAdded: {e.Amount}. Balance: {e.Balance}");
    }

    static void CreditCard_MoneySpent(object? sender, MoneySpentEventArgs e)
    {
        Console.WriteLine($"\nSpent {e.Amount}. Balance: {e.Balance}");
    }

    static void CreditCard_TargetAmountReached(object? sender, TargetAmountReachedEventArgs e)
    {
        Console.WriteLine($"\nTarget {e.Target} reached. Balance: {e.Balance}");
    }

    static void CreditCard_CreditStarted(object? sender, CreditStartedEventArgs e)
    {
        Console.WriteLine($"\nCredit started. Debt: {e.Debt}, Available credit: {e.AvailableCredit}");
    }

    static void CreditCard_PinChanged(object? sender, PinChangedEventArgs e)
    {
        Console.WriteLine($"\nPIN changed at {e.ChangeTime}");
    }

    public static void Run()
    {
        CreditCard? creditCard = null;

        while (true)
        {
            try
            {
                Console.WriteLine("\n1. Create a credit card");
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
                        creditCard = CreditCardInput();

                        creditCard.MoneyAdded += CreditCard_MoneyAdded;
                        creditCard.MoneySpent += CreditCard_MoneySpent;
                        creditCard.TargetAmountReached += CreditCard_TargetAmountReached;
                        creditCard.CreditStarted += CreditCard_CreditStarted;
                        creditCard.PinChanged += CreditCard_PinChanged;

                        if (creditCard != null)
                        {
                            while (true)
                            {
                                Console.WriteLine("\n1. Add money");
                                Console.WriteLine("2. Spend money");
                                Console.WriteLine("3. Change PIN");
                                Console.WriteLine("4. Output");
                                Console.Write("Your choice: ");
                                string? cardInput = Console.ReadLine();

                                if (int.TryParse(cardInput, out int cardChoice))
                                {
                                    if (cardChoice == 0)
                                    {
                                        Console.WriteLine("\nExitting...");
                                        break;
                                    }
                                    else if (cardChoice == 1)
                                    {
                                        int amount = IntInput("Enter amount: ");

                                        creditCard.AddMoney(amount);
                                    }
                                    else if (cardChoice == 2)
                                    {
                                        int amount = IntInput("Enter amount: ");

                                        creditCard.SpendMoney(amount);
                                    }
                                    else if (cardChoice == 3)
                                    {
                                        string oldPin = StringInput("\nEnter old pin: ");
                                        string newPin = StringInput("Enter new pin: ");

                                        creditCard.ChangePin(oldPin, newPin);
                                    }
                                    else if (cardChoice == 4)
                                    {
                                        Console.WriteLine($"\nInfo:\n{creditCard.Output()}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid choice! Enter a number between 0-4!");
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
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return;
            }
        }
    }
}
