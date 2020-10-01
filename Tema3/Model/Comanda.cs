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
    
    public partial class Comanda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comanda()
        {
            this.MeniuComandas = new HashSet<MeniuComanda>();
            this.PreparatComandas = new HashSet<PreparatComanda>();
            this.StatusulComenziis = new HashSet<StatusulComenzii>();
        }
    
        public int id_comanda { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<int> id_status { get; set; }
        public Nullable<int> id_cont { get; set; }
        public Nullable<double> pret { get; set; }
        public Nullable<System.DateTime> timp { get; set; }
    
        public virtual Cont Cont { get; set; }
        public virtual StatusComanda StatusComanda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeniuComanda> MeniuComandas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PreparatComanda> PreparatComandas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatusulComenzii> StatusulComenziis { get; set; }
    }
}
