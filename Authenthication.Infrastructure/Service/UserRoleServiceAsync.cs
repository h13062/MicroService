using Authentication.Core.Entities;
using Authentication.Core.Exceptions;
using Authentication.Core.Models;
using Authentication.Core.Repository;
using Authentication.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Service
{
    public class UserRoleServiceAsync : IUserRoleServiceAsync
    {
        private readonly IUserRoleRepositoryAsync repository;
        public UserRoleServiceAsync(IUserRoleRepositoryAsync repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddUserRoleAsync(UserRoleRequestModel model)
        {
            UserRole var = new();
            if (model != null)
            {
                var = new UserRole
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    RoleId = model.RoleId,
                };

            }
            return await repository.InsertAsync(var);

        }

        public async Task<int> DeleteUserRoleAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserRoleResponseModel>> GetAllUserRoles()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new UserRoleResponseModel
            {
                Id = x.Id,
                UserId = x.UserId,
                RoleId = x.RoleId,
            });
        }
        public async Task<UserRoleResponseModel> GetUserRoleByIdAsync(int id)
        {
            var var = await repository.GetByIdAsync(id);
            if (var != null)
            {
                return new UserRoleResponseModel
                {
                    Id = var.Id,
                    UserId = var.UserId,
                    RoleId = var.RoleId,
                };
            }
            throw new NotFoundException();
        }
        public async Task<int> UpdateUserRoleAsync(UserRoleRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.Id);
            if (existing == null)
            {
                throw new Exception("UserRole does not exist");
            }
            if (model != null)
            {
                UserRole var = new UserRole
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    RoleId = model.RoleId,
                };
                return await repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
