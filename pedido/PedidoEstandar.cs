using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantePatronesEstructurales.menu;
using RestaurantePatronesEstructurales.descuento;
using RestaurantePatronesEstructurales.usuario;

namespace RestaurantePatronesEstructurales.pedido
{
    public class PedidoEstandar : PedidoTemplate
    {
        public PedidoEstandar(List<MenuItem> items, DescuentoStrategy d, Usuario cliente)
            : base(items, d, cliente) { }
        protected override void SeleccionarItems()
        {
            Console.WriteLine("Items seleccionados (estándar):");
            foreach (var i in Items) Console.WriteLine($" - {i.Nombre}");
        }
        protected override void ProcesarPago(decimal total)
        {
            Console.WriteLine($"Procesando pago estándar: {total:C}");
        }
        protected override void Confirmar()
        {
            Console.WriteLine("Pedido estándar confirmado. Gracias por su compra.");
        }
    }
}
