using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePatronesEstructurales.usuario
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public bool IsVip { get; set; } = false;
        public Usuario(string nombre, bool vip = false) { Nombre = nombre; IsVip = vip; }
    }
}
