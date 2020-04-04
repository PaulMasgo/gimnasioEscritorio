using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaClases
{
    public class Estado
    {
        public int idEstado { get; set; }
        public decimal talla { get; set; }
        public decimal peso { get; set; }
        public string observaciones { get; set; }
        public decimal pecho { get; set; }
        public decimal biceps { get; set; }
        public decimal cintura { get; set; }
        public decimal triceps { get; set; }
        public decimal pantorrilla { get; set; }
        public Cliente cliente { get; set; }
        public DateTime fecha { get; set; }


        public Estado(int Id,decimal Talla,decimal Peso,string Observaciones,decimal Pecho,decimal Biceps,decimal Cintura,decimal Triceps,decimal Pantorilla,Cliente Cliente,DateTime Fecha )
        {
            this.idEstado = Id;
            this.talla = Talla;
            this.peso = Peso;
            this.observaciones = Observaciones;
            this.pecho = Pecho;
            this.biceps = Biceps;
            this.cintura = Cintura;
            this.triceps = Triceps;
            this.pantorrilla = Pantorilla;
            this.cliente = Cliente;
            this.fecha = Fecha;
        }

        public Estado(int Id, decimal Talla, decimal Peso, string Observaciones, decimal Pecho, decimal Biceps, decimal Cintura, decimal Triceps, decimal Pantorilla, DateTime Fecha)
        {
            this.idEstado = Id;
            this.talla = Talla;
            this.peso = Peso;
            this.observaciones = Observaciones;
            this.pecho = Pecho;
            this.biceps = Biceps;
            this.cintura = Cintura;
            this.triceps = Triceps;
            this.pantorrilla = Pantorilla;
            this.fecha = Fecha;
        }

    }
}
