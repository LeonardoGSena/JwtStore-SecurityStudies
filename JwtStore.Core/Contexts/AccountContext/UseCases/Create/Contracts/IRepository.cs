namespace JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts;

public interface IRepository
{
    private readonly IRepository _repository;
    private readonly IService _service;

    public IRepository(IRepository repository, IService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {

    }
}
