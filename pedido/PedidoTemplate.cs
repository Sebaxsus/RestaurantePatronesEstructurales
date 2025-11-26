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
    public abstract class PedidoTemplate
    {
        protected List<MenuItem> Items;
        protected DescuentoStrategy Descuento;
        protected Usuario Cliente;
        public PedidoTemplate(List<MenuItem> items, DescuentoStrategy d, Usuario cliente)
        {
            Items = items;
            Descuento = d;
            Cliente = cliente;
        }
        // Template Method
        public void ProcesarPedido()
        {
            SeleccionarItems();
            decimal total = CalcularTotal(Cliente);
            ProcesarPago(total);
            Confirmar();
        }
        protected abstract void SeleccionarItems();
        protected virtual decimal CalcularTotal(Usuario user)
        {
            var subtotal = Items.Sum(i => i.GetPrice());
            return Descuento != null ? Descuento.AplicarDescuento(Items, subtotal, user) : subtotal;
        }
        protected abstract void ProcesarPago(decimal total);
        protected abstract void Confirmar();
    }
}
