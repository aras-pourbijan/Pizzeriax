namespace Pizzeriax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordini()
        {
            Detagli = new HashSet<Detagli>();
        }

        [Key]
        public int IDordine { get; set; }

        [Column(TypeName = "date")]
        public DateTime DaraOrdine { get; set; }

        public int IDpizza { get; set; }

        public int IDuser { get; set; }

        [StringLength(200)]
        public string Indirizzo { get; set; }

        [StringLength(200)]
        public string Nota { get; set; }

        public bool? IsForLunch { get; set; }

        public bool? evaso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detagli> Detagli { get; set; }

        public virtual users users { get; set; }
    }
}
