//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Unos_sporta
{
    using System;
    using System.Collections.Generic;
    
    public partial class natjecanje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public natjecanje()
        {
            this.natjecanje_ucenik = new HashSet<natjecanje_ucenik>();
        }
    
        public int id_natjecanja { get; set; }
        public string opis { get; set; }
        public string razina_natjecanja { get; set; }
        public string mjesto_odrzavanja { get; set; }
        public System.DateTime datum_vrijeme { get; set; }
        public int id_sporta { get; set; }
    
        public virtual sport sport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<natjecanje_ucenik> natjecanje_ucenik { get; set; }
    }
}
