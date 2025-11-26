using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePatronesEstructurales.menu
{
    public abstract class MenuComponent
    {
        public string Nombre { get; protected set; }
        public virtual void Add(MenuComponent c) => throw new NotImplementedException();
        public virtual void Remove(MenuComponent c) => throw new NotImplementedException();
        public virtual MenuComponent GetChild(int i) => throw new NotImplementedException();
        public abstract decimal GetPrice();
        public abstract void Print(int depth = 0);
    }
}
