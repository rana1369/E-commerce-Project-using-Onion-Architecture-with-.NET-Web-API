﻿using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Infrastructure
{
    public class UserPaymentMethodRepository : Repositoy<UserPaymentMethod, int>, IUserPaymentMethodRepository
    {
        private readonly noonContext noonContext;

        public UserPaymentMethodRepository(noonContext noonContext) : base(noonContext)
        {
            this.noonContext = noonContext;
        }

      

        public async Task<UserPaymentMethod> GetDefualt(string AppUserId)
        {
            return noonContext.UserPaymentMethods.FirstOrDefault(p => p.UserID == AppUserId && p.IsDefault == true);
        }

         public async Task<List<UserPaymentMethod>> GetUserPaymentMethods(string AppUserId)
        {
            return await noonContext.UserPaymentMethods.Where(p => p.UserID == AppUserId).ToListAsync();
        }


       
    }

}
