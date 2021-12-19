using MediatR;
using System.Data;
using System.Reflection;
using beng.UsersService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace beng.UsersService.Application.Common;

public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> _logger;
    private readonly AppDbContext _db;
    private readonly IRequestHandler<TRequest, TResponse> _outerHandler;

    public TransactionBehaviour(
        ILogger<TransactionBehaviour<TRequest, TResponse>> logger,
        AppDbContext db,
        IRequestHandler<TRequest, TResponse> outerHandler)
    {
        _logger = logger;
        _db = db;
        _outerHandler = outerHandler;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var transactionAttr = _outerHandler
            .GetType()
            ?.GetTypeInfo()
            ?.GetDeclaredMethod(nameof(_outerHandler.Handle))
            ?.GetCustomAttributes(typeof(TransactionAttribute), true);

        if (transactionAttr is {Length: < 1}) return await next();

        var strategy = _db.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction =
                await _db.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

            var response = await next();
            
            await transaction.CommitAsync(cancellationToken);
            
            return response;
        });
    }
}