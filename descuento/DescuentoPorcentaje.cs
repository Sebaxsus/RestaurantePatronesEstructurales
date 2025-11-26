using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantePatronesEstructurales.menu;
using RestaurantePatronesEstructurales.usuario;

namespace RestaurantePatronesEstructurales.descuento
{
    public class DescuentoPorcentaje : DescuentoStrategy
    {
        private decimal porcentaje; // 0.10m = 10%
        public DescuentoPorcentaje(decimal porcentaje)
        {
            this.porcentaje = porcentaje;
        }
        public decimal AplicarDescuento(List<MenuItem> items, decimal total, Usuario user)
        {
            return total * (1 - porcentaje);
        }
    }
}
