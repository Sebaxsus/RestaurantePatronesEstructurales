using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantePatronesEstructurales.menu;
using RestaurantePatronesEstructurales.usuario;

namespace RestaurantePatronesEstructurales.descuento
{
    public class DescuentoCombo : DescuentoStrategy
    {
        private List<string> comboItems;
        private decimal descuentoFijo; // valor fijo descontado por combo
        public DescuentoCombo(List<string> comboItems, decimal descuentoFijo)
        {
            this.comboItems = comboItems;
            this.descuentoFijo = descuentoFijo;
        }
        public decimal AplicarDescuento(List<MenuItem> items, decimal total, Usuario user)
        {
            var names = items.Select(i => i.Nombre).ToList();
            // comprobar si todos los elementos del combo están presentes al menos una vez
            bool tieneCombo = comboItems.All(ci => names.Contains(ci));
            if (tieneCombo) return total - descuentoFijo;
            return total;
        }
    }
}
