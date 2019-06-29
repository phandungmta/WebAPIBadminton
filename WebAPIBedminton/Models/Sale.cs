namespace WebAPIBedminton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        public int ID { get; set; }

        public int? Discount { get; set; }

        [Column(TypeName = "date")]
        public DateTime Begin { get; set; }

        [Column(TypeName = "date")]
        public DateTime End { get; set; }

        public int? ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
