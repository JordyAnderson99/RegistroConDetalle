using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroConDetalle.Entidades{

    public class Productos{
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public double Inventario{ get; set; }

    }
}