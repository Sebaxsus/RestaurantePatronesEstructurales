using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantePatronesEstructurales.menu;
using RestaurantePatronesEstructurales.usuario;

namespace RestaurantePatronesEstructurales.descuento
{
    public interface DescuentoStrategy
    {
        decimal AplicarDescuento(List<MenuItem> items, decimal total, Usuario user);
    }
}
