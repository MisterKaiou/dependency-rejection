namespace Injecting.Dependencies.Domain;

public struct TableNumber
{
    private readonly byte _value;

    public TableNumber(byte value)
    {
        _value = value;
    }

    public static implicit operator byte(TableNumber n) => n._value;
    public static implicit operator TableNumber(byte b) => new(b);

    public override string ToString() => _value.ToString();
}