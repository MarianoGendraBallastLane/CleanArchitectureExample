using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSG.Application.Common.Exceptions;
using MSG.Application.Features.ProductFeatures.CreateProduct;
using MSG.Application.Features.ProductFeatures.DeleteProduct;
using MSG.Application.Features.ProductFeatures.GetAllProduct;
using MSG.Application.Features.ProductFeatures.UpdateProduct;

namespace MSG.WebApi.Controllers;

[ApiController]
[Route("Product")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllProductResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllProductRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<CreateProductResponse>> Create(CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut, Authorize]
    public async Task<ActionResult<UpdateProductResponse>> Create(UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        var updateResult = await _mediator.Send(request, cancellationToken);

        if (updateResult == null)
            throw new NotFoundException("Product Not Updated");

        return Ok(updateResult);
    }

    [HttpDelete, Authorize]
    public async Task<ActionResult> Delete(DeleteProductRequest request,
        CancellationToken cancellationToken)
    {
        var deleteAction = await _mediator.Send(request, cancellationToken);

        if (!deleteAction.Deleted)
            throw new NotFoundException(deleteAction.Result);

        return Ok();
    }
}