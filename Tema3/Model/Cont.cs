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
    
    public partial class Cont
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cont()
        {
            this.Comandas = new HashSet<Comanda>();
            this.DetaliiConts = new HashSet<DetaliiCont>();
        }
    
        public int id_cont { get; set; }
        public string email { get; set; }
        public string parola { get; set; }
        public string statut { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comanda> Comandas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetaliiCont> DetaliiConts { get; set; }
    }
}