﻿using Authentication.Core.Entities;
using Authentication.Core.Repository;
using Authentication.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Repository
{
    public class AccountRepositoryAsync : BaseRepositoryAsync<Account>, IAccountRepositoryAsync
    {
        public AccountRepositoryAsync(AuthenticationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
