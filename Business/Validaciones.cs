using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Validaciones
    {
        public static bool EsAdmin(UsersEntity user)
        {
            if (user == null || user.admin == false)
            {
                return false;
            }
            return true;
        }
    }
}
