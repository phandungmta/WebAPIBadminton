namespace WebAPIBedminton.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebAPIBedminton.Models;

    public partial class Bill_DetailsDTO
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BillID { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }

        public Bill_DetailsDTO() { }
        public Bill_DetailsDTO(Bill_Details a)
        {
            this.ProductID = a.ProductID;
            this.BillID = a.BillID;
            this.Amount = a.Amount;
            this.Price = a.Price;
        }
        // Ep kieu sang Model
        public Bill_Details toModel()
        {
            return new Bill_Details()
            {
                ProductID = this.ProductID,
                BillID = this.BillID,
                Amount = this.Amount,
                Price = this.Price
            };
        }


    }
}
