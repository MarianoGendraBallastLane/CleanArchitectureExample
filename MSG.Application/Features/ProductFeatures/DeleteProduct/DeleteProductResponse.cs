namespace MSG.Application.Features.ProductFeatures.DeleteProduct;

public sealed record DeleteProductResponse
{
    public bool Deleted { get; set; }
    public string Result { get; set; } = string.Empty;
}