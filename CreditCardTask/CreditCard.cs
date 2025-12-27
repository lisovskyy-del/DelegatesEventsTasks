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

    public CreditCard(int id, string fullName, DateTime expirationDate, string pin, int creditLimit, int balance)
    {
        Id = id;
        FullName = fullName;
        ExpirationDate = expirationDate;
        _pin = pin;
        CreditLimit = creditLimit;
        _balance = balance;
    }

    protected virtual void OnMoneyAdded(MoneyAddedEventArgs e)
    {
        MoneyAdded?.Invoke(this, e);
    }
    protected virtual void OnMoneySpent(MoneySpentEventArgs e)
    {
        MoneySpent?.Invoke(this, e);
    }
    protected virtual void OnCreditStarted(CreditStartedEventArgs e)
    {
        CreditStarted?.Invoke(this, e);
    }
    protected virtual void OnTargetAmountReached(TargetAmountReachedEventArgs e)
    {
        TargetAmountReached?.Invoke(this, e);
    }
    protected virtual void OnPinChanged(PinChangedEventArgs e)
    {
        PinChanged?.Invoke(this, e);
    }

    public void AddMoney(int amount)
    {
        if (amount <= 0)
        {
            throw new Exception("Amount must be positive.");
        }

        CheckIfExpired();

        _balance += amount;

        OnMoneyAdded(new MoneyAddedEventArgs(amount, _balance));
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
            OnTargetAmountReached(new TargetAmountReachedEventArgs(amount, available));
        }

        _balance -= amount;

        OnMoneySpent(new MoneySpentEventArgs(amount, _balance));
    }

    public bool ValidatePin(string pin)
    {
        return !string.IsNullOrWhiteSpace(pin) && (pin.Length == 4) && pin.All(char.IsDigit);
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

    private void CheckIfExpired()
    {
        if (ExpirationDate < DateTime.Today)
        {
            throw new Exception("Card is expired.");
        }
    }
}
