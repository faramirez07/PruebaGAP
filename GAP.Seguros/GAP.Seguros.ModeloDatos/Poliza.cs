//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GAP.Seguros.ModeloDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Poliza
    {
        public int IdPoliza { get; set; }
        public string TipoPoliza { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Inicio { get; set; }
        public int Duracion { get; set; }
        public decimal Precio { get; set; }
        public string TipoRiesgo { get; set; }
        public bool Activo { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    }
}