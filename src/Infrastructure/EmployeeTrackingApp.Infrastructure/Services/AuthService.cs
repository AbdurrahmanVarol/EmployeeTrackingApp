
using EmployeeTrackingApp.Application.Features.Commands.UserCommands.CreateUser;
using EmployeeTrackingApp.Application.Features.Queries.UserQueries.GetUserByUserName;
using EmployeeTrackingApp.Application.Interfaces.Services;
using EmployeeTrackingApp.Application.Models;
using EmployeeTrackingApp.Application.Responses;
using EmployeeTrackingApp.Domain.Entities;
using EmployeeTrackingApp.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        //IOptions<StartDto> asd
        public AuthService(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = Convert.ToBase64String(hmac.Key);
            passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public string GenerateToken(User user)
        {
            var key = _configuration.GetSection("JWT:Key").Value;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creadentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,((int)user.UserRole).ToString())
            };
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,
                expires: DateTime.Now.AddDays(5),
                notBefore: DateTime.Now,
                signingCredentials: creadentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);


            return token;
        }

        public async Task<LoginResponse> Login(LoginModel loginModel)
        {
            var user = await _mediator.Send(new GetUserByUserNameQuery { UserName = loginModel.UserName });

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (!VerifyPasswordHash(loginModel.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException("Kullanııc Bilgileri Doğrulanamadı");
            }

            var token = GenerateToken(user);
            var response = new LoginResponse
            {
                Token = token,
                UserRole = user.UserRole
            };
            return response;
        }

        public async Task Register(UserModel userModel)
        {
            string passwordHash = string.Empty;
            string passwordSalt = string.Empty;

            CreatePasswordHash(userModel.Password, out passwordHash, out passwordSalt);
            var createUserCommand = new CreateUserCommand
            {
                DeparmentId = userModel.DeparmentId,
                UserName = userModel.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };
            await _mediator.Send(createUserCommand);
        }

        public bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(Convert.FromBase64String(passwordSalt));

            var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

            return passwordHash.Equals(computedHash);

        }
    }
}
