namespace Pizzeriax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            Ordini = new HashSet<Ordini>();
        }

        [Key]
        public int IDuser { get; set; }

        [Required]
        [StringLength(40)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [StringLength(20)]
        public string tel { get; set; }

        [StringLength(60)]
        public string Nome { get; set; }

        public bool? IsAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini { get; set; }
    }
}
