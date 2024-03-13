using Entity;
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
            foreach(UsersEntity usuario in GetUsers())
            {
                if (usuario.Email == user.Email) throw new Exception("El email ya esta registrado");
            }
            usersDAL.Alta(user);
        }

        public UsersEntity Validar(UsersEntity user)
        {
            foreach(UsersEntity usuario in GetUsers())
            {
                if(usuario.Email==user.Email && usuario.Pass==user.Pass) return usuario;
            }
            throw new Exception("el email o la contraseña son incorrectos");
        }
    }
}
