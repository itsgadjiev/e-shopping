namespace Catalog.API.Features.Products.CreateProduct;
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResponse>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IDocumentSession _session;

    public CreateProductCommandHandler(IDocumentSession session)
    {
        _session = session;
    }
    public async Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        Product product = new Product()
        {
            Description = command.Description,
            ImageFile = command.ImageFile,
            Name = command.Name,
            Price = command.Price,
            Category = command.Category,
        };

        _session.Store(product);
        await _session.SaveChangesAsync(cancellationToken);

        return new CreateProductResponse(product.Id);
    }
}
