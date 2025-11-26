using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePatronesEstructurales.menu
{
    public class MenuCategory : MenuComponent
    {
        private List<MenuComponent> children = new List<MenuComponent>();
        public MenuCategory(string nombre)
        {
            Nombre = nombre;
        }
        public override void Add(MenuComponent c) => children.Add(c);
        public override void Remove(MenuComponent c) => children.Remove(c);
        public override MenuComponent GetChild(int i) => children[i];
        public override decimal GetPrice() => children.Sum(c => c.GetPrice());
        public override void Print(int depth = 0)
        {
            Console.WriteLine(new string(' ', depth * 2) + $"> {Nombre}");
            foreach (var c in children) c.Print(depth + 1);
        }
        public IReadOnlyList<MenuComponent> Children => children.AsReadOnly();
    }
}
