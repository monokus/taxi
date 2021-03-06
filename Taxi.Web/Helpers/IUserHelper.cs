﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Web.Data.Entities;
using Taxi.Web.Models;

namespace Taxi.Web.Helpers
{
    public interface IUserHelper
    {
        Task<UserEntity> GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(UserEntity user,string password);
        Task CheckRoleAsync(string rolename);
        Task AddUserToRoleAsync(UserEntity user, string rolename);
        Task<bool> IsUserInRoleAsync(UserEntity user, string rolename);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
    }
}
