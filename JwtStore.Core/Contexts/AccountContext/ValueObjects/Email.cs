using System.Text.RegularExpressions;
using JwtStore.Core.Contexts.SharedContext.Extensions;
using JwtStore.Core.Contexts.SharedContext.ValueObjects;

namespace JwtStore.Core.Contexts.AccountContext.ValueObjects;

public partial class Email : ValueObject
{
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    public Email(string address)
    {
        if (string.IsNullOrEmpty(address))
            throw new Exception("E-mail inválido");

        Address = address.Trim().ToLower();

        if (Address.Length < 5)
            throw new Exception("E-mail Inválido");

        if (!EmailRegex().IsMatch(Address))
            throw new Exception("E-mail Inválido");
    }

    public string Address { get; }
    public string Hash => Address.ToBase64(); // Gravatar.com
    public Verification Verification { get; private set; } = new();

    public void ResendVerification()
        => Verification = new Verification();

    public static implicit operator string(Email email)
        => email.ToString();

    public static implicit operator Email(string address)
        => new Email(address);

    public override string ToString()
        => Address.Trim().ToLower();

    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();
}
