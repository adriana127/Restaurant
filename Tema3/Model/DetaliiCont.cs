//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tema3.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetaliiCont
    {
        public int id_detalii { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string adresa { get; set; }
        public string telefon { get; set; }
        public Nullable<int> id_cont { get; set; }
    
        public virtual Cont Cont { get; set; }
    }
}
