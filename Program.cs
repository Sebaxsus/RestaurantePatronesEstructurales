using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantePatronesEstructurales.usuario;
using RestaurantePatronesEstructurales.descuento;
using RestaurantePatronesEstructurales.menu;
using RestaurantePatronesEstructurales.pedido;

namespace RestaurantePatronesEstructurales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Usuarios
            var userAnon = new Usuario("anon", false);
            var userVip = new Usuario("juan", true);

            var auth = new Autenticador();
            auth.Login(userVip, "vip"); // autenticamos vip

            // Construcción de menú compuesto
            var root = new MenuCategory("Menu Principal");
            var bebidas = new MenuCategory("Bebidas");
            var gaseosas = new MenuCategory("Gaseosas");
            var coca = new MenuItem("Coca-Cola", 2.50m);
            var pepsi = new MenuItem("Pepsi", 2.00m);
            var cafe = new MenuItem("Café", 1.50m);
            gaseosas.Add(coca); gaseosas.Add(pepsi);
            bebidas.Add(gaseosas); bebidas.Add(cafe);

            var comidas = new MenuCategory("Comidas");
            var hamburguesa = new MenuItem("Hamburguesa", 5.00m);
            var papas = new MenuItem("Papas", 2.00m);
            comidas.Add(hamburguesa); comidas.Add(papas);

            // Menú premium (solo autenticados)
            var premium = new MenuCategory("Premium");
            premium.Add(new MenuItem("Trufa Especial", 15.00m));
            root.Add(bebidas); root.Add(comidas); root.Add(premium);

            // Proxy para menú premium
            var menuProxy = new MenuProxy(premium, auth);

            Console.WriteLine("=== Menú público (completo excepto premium) ===");
            root.Print();

            Console.WriteLine("\n=== Intento ver premium como anónimo ===");
            menuProxy.Print(userAnon); // debe denegar

            Console.WriteLine("\n=== Ver premium como VIP autenticado ===");
            menuProxy.Print(userVip); // debe mostrar

            // Selección de items para pedido
            var seleccion = new List<MenuItem> { coca, coca, hamburguesa, papas };

            // Estrategias de descuento
            DescuentoStrategy sinDescuento = null;
            DescuentoStrategy desc10 = new DescuentoPorcentaje(0.10m);
            DescuentoStrategy dosx1 = new Descuento2x1();
            DescuentoStrategy combo = new DescuentoCombo(new List<string> { "Hamburguesa", "Papas" }, 1.00m);

            Console.WriteLine("\n=== Pedido estándar sin descuento ===");
            var pedido1 = new PedidoEstandar(seleccion, sinDescuento, userAnon);
            pedido1.ProcesarPedido();

            Console.WriteLine("\n=== Pedido estándar con 2x1 (ejemplo) ===");
            var pedido2 = new PedidoEstandar(seleccion, dosx1, userAnon);
            pedido2.ProcesarPedido();

            Console.WriteLine("\n=== Pedido VIP con 10% descuento ===");
            var pedidoVip = new PedidoVIP(seleccion, desc10, userVip);
            pedidoVip.ProcesarPedido();

            Console.WriteLine("\n=== Cambiando estrategia en runtime a Combo ===");
            // demo de intercambio en runtime
            pedidoVip = new PedidoVIP(seleccion, combo, userVip);
            pedidoVip.ProcesarPedido();

            Console.WriteLine("\nFin demo.");

            Console.ReadKey();
        }
    }
}
