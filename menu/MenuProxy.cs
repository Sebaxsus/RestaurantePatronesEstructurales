using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantePatronesEstructurales.usuario;

namespace RestaurantePatronesEstructurales.menu
{
    public class MenuProxy
    {
        private MenuCategory realMenu;
        private Autenticador auth;
        public MenuProxy(MenuCategory menu, Autenticador auth)
        {
            this.realMenu = menu;
            this.auth = auth;
        }
        public void Print(Usuario user)
        {
            if (auth.IsAuthenticated(user))
            {
                realMenu.Print();
            }
            else
            {
                Console.WriteLine("Acceso denegado. Autentíquese para ver contenido premium.");
            }
        }
    }
}
