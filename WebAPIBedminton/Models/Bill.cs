namespace WebAPIBedminton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            Bill_Details = new HashSet<Bill_Details>();
        }

        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int? AccountID { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Phonenumber { get; set; }

        [Required]
        public string Address { get; set; }

        public string Email { get; set; }

        [Required]
        public string TotalPrice { get; set; }

        [Required]
        public string Status { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill_Details> Bill_Details { get; set; }
    }
}
