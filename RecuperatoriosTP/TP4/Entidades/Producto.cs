using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {

        #region ATRIBUTOS

        private int id;
        private string marca;
        private string descripcion;
        private string codigo;
        private double precio;
        private int cantidad;
        private ECategoria categoria;
        #endregion

        #region PROPIEDADES

        public int IdProducto
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        public string Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        public ECategoria Categoria
        {
            get { return this.categoria; }
            set { this.categoria = value; }
        }

        #endregion

        #region CONSTRUCTORES

        public Producto()
        { }

        /// <summary>
        /// Inicializa los atributos id,código,marca, precio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codigo"></param>
        /// <param name="marca"></param>
        /// <param name="precio"></param>
        
        public Producto(int id,string codigo,string marca,double precio):this()
        {
            this.id = id;
            this.codigo = codigo;
            this.marca = marca;
            this.precio = precio;
        }

        /// <summary>
        /// Inicializa los atributos Cantidad,categoría,descripción
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codigo"></param>
        /// <param name="marca"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        /// <param name="categoria"></param>
        /// <param name="descripcion"></param>

        public Producto(int id, string codigo, string marca, double precio,int cantidad,ECategoria categoria, string descripcion) : this()
        {
            this.cantidad = cantidad;
            this.categoria = categoria;
            this.descripcion = descripcion;
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Mostrara los datos de Producto
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id: " + this.id);
            sb.AppendLine("Código: " + this.codigo);
            sb.AppendLine("Categoria: " + this.categoria);
            sb.AppendLine("Marca: " + this.marca);
            sb.AppendLine("Precio: " + this.precio);
            sb.AppendLine("Cantidad: " + this.cantidad);
            sb.AppendLine("Descripción: " + this.descripcion);

            return sb.ToString();
        }

        #endregion

        #region OPERADORES

        /// <summary>
        /// Dos productos serán iguales si tienen el mismo id,código y marca
        /// </summary>
        /// <param name="prodUno"></param>
        /// <param name="prodDos"></param>
        /// <returns></returns>

        public static bool operator ==(Producto prodUno, Producto prodDos)
        {
            if (prodUno.id == prodDos.id && prodUno.codigo == prodDos.codigo && prodUno.marca == prodDos.marca)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Producto prodUno, Producto prodDos)
        {
            return !(prodUno == prodDos);
        }


        #endregion

    }

}
