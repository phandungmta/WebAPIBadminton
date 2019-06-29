namespace WebAPIBedminton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public int ProducerID { get; set; }

        public int CategoryID { get; set; }

        public int Price { get; set; }

        [Required]
        public string IMG { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Description { get; set; }

        public int TopHot { get; set; }

        public int NewProduct { get; set; }

        public string Active { get; set; }

        public virtual Category Category { get; set; }

        public virtual Producer Producer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
