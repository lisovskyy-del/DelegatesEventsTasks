using System.Net.NetworkInformation;

namespace MainProgram.CreditCardTask;

public class MoneyAddedEventArgs : EventArgs
{
    public int Amount { get; }
    public int Balance { get; }

    public MoneyAddedEventArgs(int amount, int balance)
    {
        Amount = amount;
        Balance = balance;
    }
}

public class MoneySpentEventArgs : EventArgs
{
    public int Amount { get; }
    public int Balance { get; }

    public MoneySpentEventArgs(int amount, int balance)
    {
        Amount = amount;
        Balance = balance;
    }
}

public class CreditStartedEventArgs : EventArgs
{
    public int Debt { get; }
    public int AvailableCredit { get; }

    public CreditStartedEventArgs(int debt, int availableCredit)
    {
        Debt = debt;
        AvailableCredit = availableCredit;
    }
}

public class TargetAmountReachedEventArgs : EventArgs
{
    public int Balance { get; }
    public int Target { get; }

    public TargetAmountReachedEventArgs(int balance, int target)
    {
        Balance = balance;
        Target = target;
    }
}

public class PinChangedEventArgs : EventArgs
{
    public DateTime ChangeTime { get; }

    public PinChangedEventArgs(DateTime changeTime)
    {
        ChangeTime = changeTime;
    }
}

class CreditCard
{
    private string _pin;
    private int _balance;
    private int _targetAmount;

    public int TargetAmount
    {
        get { return _targetAmount; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("Target must be positive.");
            }

            _targetAmount = value;
        }
    }

    public int Id { get; }
    public string FullName { get; }
    public DateTime ExpirationDate { get; }
    public int CreditLimit { get; }

    public int Balance => _balance;

    public event EventHandler<MoneyAddedEventArgs>? MoneyAdded;
    public event EventHandler<MoneySpentEventArgs>? MoneySpent;
    public event EventHandler<CreditStartedEventArgs>? CreditStarted;
    public event EventHandler<TargetAmountReachedEventArgs>? TargetAmountReached;
    public event EventHandler<PinChangedEventArgs>? PinChanged;

    public CreditCard(int id, string fullName, DateTime expirationDate, string pin, int creditLimit, int balance, int targetAmount)
    {
        if (id <= 0)
        {
            throw new Exception("ID must be positive.");
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new Exception("Full name cannot be empty.");
        }

        if (expirationDate <= DateTime.Today)
        {
            throw new Exception("Expiration date must be in the future.");
        }

        if (!ValidatePin(pin))
        {
            throw new Exception("PIN must contain exactly 4 digits.");
        }

        if (creditLimit < 0)
        {
            throw new Exception("Credit limit cannot be negative.");
        }

        if (balance < -creditLimit)
        {
            throw new Exception("Balance cannot be less than credit limit.");
        }

        Id = id;
        FullName = fullName;
        ExpirationDate = expirationDate;
        _pin = pin;
        CreditLimit = creditLimit;
        _balance = balance;
        _targetAmount = targetAmount;
    }

    public void AddMoney(int amount)
    {
        if (amount <= 0)
        {
            throw new Exception("Amount must be positive.");
        }

        CheckIfExpired();

        _balance += amount;

        if (Balance > TargetAmount)
        {
            OnTargetAmountReached(new TargetAmountReachedEventArgs (Balance, TargetAmount));
        }

        OnMoneyAdded(new MoneyAddedEventArgs(amount, _balance));
    }

    private void CheckIfExpired()
    {
        if (ExpirationDate < DateTime.Today)
        {
            throw new Exception("Card is expired.");
        }
    }

    protected virtual void OnMoneyAdded(MoneyAddedEventArgs e)
    {
        MoneyAdded?.Invoke(this, e);
    }

    public void SpendMoney(int amount)
    {
        if (amount <= 0)
        {
            throw new Exception("Amount must be positive.");
        }

        CheckIfExpired();

        int available = _balance + CreditLimit;

        if (amount > available)
        {
            throw new Exception("Not enough funds including credit limit.");
        }

        _balance -= amount;

        if (_balance < 0)
        {
            int debt = -_balance;
            int availableCredit = CreditLimit - debt;

            OnCreditStarted(new CreditStartedEventArgs(debt, availableCredit));
        }

        OnMoneySpent(new MoneySpentEventArgs(amount, _balance));
    }

    protected virtual void OnMoneySpent(MoneySpentEventArgs e)
    {
        MoneySpent?.Invoke(this, e);
    }

    protected virtual void OnTargetAmountReached(TargetAmountReachedEventArgs e)
    {
        TargetAmountReached?.Invoke(this, e);
    }

    protected virtual void OnCreditStarted(CreditStartedEventArgs e)
    {
        CreditStarted?.Invoke(this, e);
    }

    public void ChangePin(string oldPin, string newPin)
    {
        if (_pin != oldPin)
        {
            throw new Exception("Incorrect old PIN.");
        }

        if (!ValidatePin(newPin))
        {
            throw new Exception("New PIN is invalid.");
        }

        _pin = newPin;

        OnPinChanged(new PinChangedEventArgs(DateTime.Now));
    }
    protected virtual void OnPinChanged(PinChangedEventArgs e)
    {
        PinChanged?.Invoke(this, e);
    }

    public static bool ValidatePin(string pin)
    {
        return !string.IsNullOrWhiteSpace(pin) && (pin.Length == 4) && pin.All(char.IsDigit);
    }

    public string Output()
    {
        return $"\nID: {Id}" +
            $"\nFull Name: {FullName}" +
            $"\nExpiration Date: {ExpirationDate}" +
            $"\nPIN: {_pin}" +
            $"\nCredit Limit: {CreditLimit}" +
            $"\nBalance: {Balance}" +
            $"\nTarget Amount: {TargetAmount}";
    }
}
