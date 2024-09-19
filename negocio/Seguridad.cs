using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Usuario usuario = user != null ? user as Usuario : null;
            if (usuario != null && usuario.Id != 0)
                return true;
            return false;
        }
        public static bool esAdmin(object user)
        {
            Usuario usuario = user != null ? user as Usuario : null;
            if (user == null || (int)usuario.TipoUsuario != 1)
                return false;
            return true;
        }
    }
}
