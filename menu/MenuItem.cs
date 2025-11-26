using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePatronesEstructurales.menu
{
    public class MenuItem : MenuComponent
    {
        private decimal precio;
        public MenuItem(string nombre, decimal precio)
        {
            Nombre = nombre;
            this.precio = precio;
        }
        public override decimal GetPrice() => precio;
        public override void Print(int depth = 0)
        {
            Console.WriteLine(new string(' ', depth * 2) + $"- {Nombre}: {precio:C}");
        }
    }
}
