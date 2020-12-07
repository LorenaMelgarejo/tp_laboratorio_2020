using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas
    {
        #region Atributos

        private DateTime fecha;
        private List<Producto> producto;
        private List<Cliente> clientes;
        private int cant;
        private double total;

        #endregion

        #region Constructores

        public Ventas(DateTime fecha, List<Producto> producto, List<Cliente> clientes, int cant, int total)
        {
            this.Fecha = fecha;
            this.producto = producto;
            this.clientes = clientes;
            this.Cant = cant;
            this.total = total;
        }

        #endregion

        #region Propiedades

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public List<Producto> Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public List<Cliente> Clientes
        {
            get { return clientes; }
            set { clientes = value; }
        }

        public int Cant
        {
            get { return cant; }
            set {cant = value;}
        }

        public double Total
        {
            get { return this.ImporteTotal(); }
            //set { total = value; }
        }

        #endregion

        #region Métodos

        public double ImporteTotal()
        {
            //double total = 0;
            foreach (Producto item in this.producto)
            {
                total += item.Precio;
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------Detalle De la Compra----------\n");
            sb.AppendLine("Nombre: " + this.clientes);
            sb.AppendLine("\n ***Productos***\n ");
            foreach (Producto item in this.producto)
            {
                sb.AppendLine("\n " + item.ToString());
            }
            sb.AppendLine("Importe Total: " + this.Total);
            return sb.ToString();
        }

            #endregion

    }
}
