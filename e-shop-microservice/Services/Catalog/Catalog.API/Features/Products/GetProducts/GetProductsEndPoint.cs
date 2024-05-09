namespace Catalog.API.Features.Products.GetProducts;

//public record GetProductsQuery();

public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.Map("/products", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery());

            var response = result.Adapt<GetProductsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
}
