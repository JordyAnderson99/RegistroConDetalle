using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroConDetalle.Entidades{

    public class Suplidores{
        [Key]
        public int SuplidorId { get; set; }
        public string Nombres { get; set; }
    }
}