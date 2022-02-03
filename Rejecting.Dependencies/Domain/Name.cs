namespace Injecting.Dependencies.Domain;

public struct Name
{
    private readonly string _value;

    public Name(string value)
    {
        if (value.Length < 1)
            throw new ArgumentException("Name way too short.", nameof(value));

        _value = value ?? throw new ArgumentException("Name must not be null.", nameof(value));
    }

    public static implicit operator string(Name name) => name._value;
    public static implicit operator Name(string name) => new(name);

    public override string ToString() => _value;
}