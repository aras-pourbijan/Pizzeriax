namespace Pizzeriax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pizze")]
    public partial class Pizze
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pizze()
        {
            Detagli = new HashSet<Detagli>();
        }

        [Key]
        public int IDpizza { get; set; }

        [Required]
        [StringLength(40)]
        
        public string NomePizza { get; set; }

        public string imgURL { get; set; }

        [Column(TypeName = "money")]
        public decimal prezzo { get; set; }
        [Range(3, 20, ErrorMessage = "Tempo sara` tra 3 e 20 minuti!")]
        public int? Cottura { get; set; }

        public string Ingredienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detagli> Detagli { get; set; }
    }
}
