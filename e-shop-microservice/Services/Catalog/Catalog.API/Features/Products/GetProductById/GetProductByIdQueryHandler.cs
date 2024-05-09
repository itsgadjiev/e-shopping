
using Catalog.API.Exceptions;

namespace Catalog.API.Features.Products.GetProductById;

public record GetProductIdQuery(Guid id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);

internal class GetProductByIdQueryHandler
    (IDocumentSession documentSession,ILoggerFactory loggerFactory)
    : IQueryHandler<GetProductIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductIdQuery query, CancellationToken cancellationToken)
    {
        loggerFactory.CreateLogger<GetProductByIdQueryHandler>().LogInformation("GetProductByIdQueryHandler {@Query}", query);

        var product = await documentSession.LoadAsync<Product>(query.id,cancellationToken);

        if (product == null)
            throw new NotFoundException("Product not Found ");

        return new GetProductByIdResult(product);
    }
}
