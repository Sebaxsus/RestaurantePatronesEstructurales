using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePatronesEstructurales.usuario
{
    public class Autenticador
    {
        private HashSet<string> sesiones = new HashSet<string>();
        // Simple: autenticamos por nombre+password en memoria (demo)
        public bool Login(Usuario u, string password)
        {
            // Demo: contraseña = "pass" o si es VIP "vip"
            if ((u.IsVip && password == "vip") || (!u.IsVip && password == "pass"))
            {
                sesiones.Add(u.Nombre);
                return true;
            }
            return false;
        }
        public bool IsAuthenticated(Usuario u) => sesiones.Contains(u.Nombre);
    }
}
