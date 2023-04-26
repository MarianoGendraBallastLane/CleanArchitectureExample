using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSG.Application.Features.UserFeatures.LoginUser;

namespace MSG.WebApi.Controllers;

[ApiController]
[Route("authorization")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<LoginUserResponse>> Login(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        if (response.Token == string.Empty)
            return BadRequest("Invalid Login");

        return Ok(response);
    }
}