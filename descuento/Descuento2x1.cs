using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantePatronesEstructurales.menu;
using RestaurantePatronesEstructurales.usuario;

namespace RestaurantePatronesEstructurales.descuento
{
    public class Descuento2x1 : DescuentoStrategy
    {
        // Aplica "2x1" por cada par de items con mismo nombre (hoja simple)
        public decimal AplicarDescuento(List<MenuItem> items, decimal total, Usuario user)
        {
            var groups = items.GroupBy(i => i.Nombre);
            decimal discount = 0;
            foreach (var g in groups)
            {
                int count = g.Count();
                int free = count / 2;
                if (free > 0)
                {
                    decimal priceSingle = g.First().GetPrice();
                    discount += free * priceSingle;
                }
            }
            return total - discount;
        }
    }
}
