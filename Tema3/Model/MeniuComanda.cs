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
    
    public partial class MeniuComanda
    {
        public int id_meniucomanda { get; set; }
        public Nullable<int> id_meniu { get; set; }
        public Nullable<int> id_comanda { get; set; }
        public Nullable<int> nrBucati { get; set; }
    
        public virtual Comanda Comanda { get; set; }
        public virtual Meniu Meniu { get; set; }
    }
}
