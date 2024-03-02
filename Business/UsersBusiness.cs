﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UsersBusiness
    {
        UsersDAL usersDAL= new UsersDAL();

        public List<UsersEntity> GetUsers()
        {
            return usersDAL.Get();
        }

        public void Actualizar(UsersEntity user)
        {
            usersDAL.Modificar(user);
        }
        public void AltaUser(UsersEntity user)
        {
            usersDAL.Alta(user);
        }
    }
}