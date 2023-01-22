namespace Pizzeriax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

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
        [Display(Name = "Nome Utente")]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [StringLength(20)]
        public string tel { get; set; }

        [StringLength(60)]
        [Display(Name = "Nome e Cognome")]
        public string Nome { get; set; }
        [Display(Name = "Amministratore?")]
        public bool? IsAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini { get; set; }



        public static bool Autenticated(string username, string password)
        {
            Model1 DB = new Model1();

            var u = DB.users.Where(users => users.username == username && users.password == password).FirstOrDefault();
            if (u != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
