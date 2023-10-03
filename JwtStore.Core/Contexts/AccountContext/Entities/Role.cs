using JwtStore.Core.Contexts.SharedContext.Entities;

namespace JwtStore.Core.Contexts.AccountContext.Entities;

public class Role : Entity
{
    public string Name { get; private set; } = string.Empty;
    public List<User> Users { get; private set; } = new();
}
