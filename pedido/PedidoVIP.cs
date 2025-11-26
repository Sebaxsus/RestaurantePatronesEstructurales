using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantePatronesEstructurales.menu;
using RestaurantePatronesEstructurales.descuento;
using RestaurantePatronesEstructurales.pedido;

namespace RestaurantePatronesEstructurales.usuario
{
    public class PedidoVIP : PedidoTemplate
    {
        public PedidoVIP(List<MenuItem> items, DescuentoStrategy d, Usuario cliente)
            : base(items, d, cliente) { }
        protected override void SeleccionarItems()
        {
            Console.WriteLine("Items seleccionados (VIP): prioridad en cocina y atención.");
            foreach (var i in Items) Console.WriteLine($" * {i.Nombre}");
        }
        protected override void ProcesarPago(decimal total)
        {
            Console.WriteLine($"Procesando pago VIP (confirmación en 1 click): {total:C}");
        }
        protected override void Confirmar()
        {
            Console.WriteLine("Pedido VIP confirmado. Envío prioritario y bebida gratis (demo).");
        }
    }
}
