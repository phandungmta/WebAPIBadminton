namespace WebAPIBedminton.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebAPIBedminton.Models;


    public partial class BillDTO
    {
        
       
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int? AccountID { get; set; }

       
        public string Fullname { get; set; }

  
        public string Phonenumber { get; set; }

     
        public string Address { get; set; }

        public string Email { get; set; }

    
        public string TotalPrice { get; set; }

        public string Status { get; set; }

        public BillDTO() { }
       
        public BillDTO(Bill a)
        {
            this.Date = a.Date; this.AccountID = a.AccountID; this.Fullname = a.Fullname; this.Phonenumber = a.Phonenumber;
            this.Address = a.Address; this.Email = a.Email; this.TotalPrice = a.TotalPrice; this.Address = a.Address; this.Status = a.Status; 
        }
        // Ep kieu sang Model
        public Bill toModel()
        {
            return new Bill()
            {
                ID = this.ID,
                Date = this.Date,
                AccountID = this.AccountID,
                Fullname = this.Fullname,
                Phonenumber = this.Phonenumber,               
                Email = this.Email,
                Address = this.Address,
                TotalPrice = this.TotalPrice,
                Status = this.Status
            };
        }

    }
}
