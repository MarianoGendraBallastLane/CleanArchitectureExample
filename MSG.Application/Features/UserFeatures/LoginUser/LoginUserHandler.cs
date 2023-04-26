using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MSG.Application.Repositories;
using MSG.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MSG.Application.Features.UserFeatures.LoginUser;

public sealed class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public LoginUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var response = new LoginUserResponse();

        var user = _mapper.Map<User>(request);

        var existingEntity = await _userRepository.GetByEmail(user.Email, cancellationToken);

        if (existingEntity != null)
        {
            var isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, existingEntity.PasswordHash);
            if (isValidPassword)
            {
                response.Token = CreateToken(existingEntity);
            }
        }

        return response;
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var securityToken = new JwtSecurityToken(
            null, 
            null, 
            claims, 
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return jwt;
    }
}