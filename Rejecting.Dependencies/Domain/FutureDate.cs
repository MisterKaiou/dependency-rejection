namespace Injecting.Dependencies.Domain;

public struct FutureDate
{
    private readonly DateTime _value;

    public FutureDate(DateTime value)
    {
        if (value < DateTime.Now)
            throw new ArgumentException("Date must be a future date", nameof(value));
        
        _value = value;
    }
    
    public static implicit operator DateTime(FutureDate date) => date._value;
    public static implicit operator FutureDate(DateTime date) => new(date);

    public override string ToString() => _value.ToShortDateString();
}