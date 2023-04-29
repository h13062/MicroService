﻿using Authentication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.Service
{
    public interface IRoleServiceAsync
    {
        Task<int> AddRoleAsync(RoleRequestModel model);
        Task<int> UpdateRoleAsync(RoleRequestModel model);
        Task<int> DeleteRoleAsync(int id);
        Task<IEnumerable<RoleResponseModel>> GetAllRoles();
        Task<RoleResponseModel> GetRoleByIdAsync(int id);
    }
}
