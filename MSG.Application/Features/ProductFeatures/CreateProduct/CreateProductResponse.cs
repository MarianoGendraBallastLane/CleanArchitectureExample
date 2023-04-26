namespace MSG.Application.Features.ProductFeatures.CreateProduct;

public sealed record CreateProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; } = 0;
}