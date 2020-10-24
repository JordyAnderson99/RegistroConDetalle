using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroConDetalle.Entidades{

    public class OrdenesDetalle{
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public double Cantidad  { get; set; }
        public double Costo { get; set; }
        
        [ForeignKey("ProductoId")]

        public Productos productos {get; set;} = new Productos();
    
    }
}