﻿using InkHeart.IBLL;
using InkHeart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkHeart.BLL
{
   public class UserService:BaseService<User>,IUserService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.UserDal;
        }
    }
}
