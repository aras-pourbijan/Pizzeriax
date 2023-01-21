namespace Pizzeriax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Detagli")]
    public partial class Detagli
    {
        [Key]
        public int IDdetaglio { get; set; }

        public int IDpizza { get; set; }

        public int IDordine { get; set; }

        public int quantita { get; set; }

        public virtual Ordini Ordini { get; set; }

        public virtual Pizze Pizze { get; set; }
    }
}
