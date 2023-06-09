﻿using EmployeeTrackingApp.Application.Models;
using EmployeeTrackingApp.Application.Responses;
using EmployeeTrackingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginModel loginModel);
        Task<LoginResponse> RefreshTokenAsync(string refreshToken, Guid userId);
        Task RegisterAsync(UserModel userModel);
        void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);
        bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt);
        string GenerateToken(User user);

    }
}
