namespace WebAPIBedminton.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebAPIBedminton.Models;

   
    public partial class AccountDTO
    {    

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public string Sex { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Permission { get; set; }

        public string Active { get; set; }


        public AccountDTO() { }
        public AccountDTO(string username, string pass,string fullname, DateTime birthday, string sex,string phone,string email,string address, string permission, string active)
        {
            this.Username = username; this.Password = pass; this.Fullname = fullname; this.Birthday = birthday;
            this.Sex = sex; this.PhoneNumber = phone; this.Email = email;this.Address = address; this.Permission = permission;this.Active = active;
        }
        public AccountDTO(Account a)
        {
            this.Username = a.Username;
            this.Password = a.Password;
            this.Fullname = a.Fullname;
            this.Birthday = a.Birthday; 
            this.Sex = a.Sex;
            this.PhoneNumber = a.PhoneNumber;
            this.Email = a.Email;
            this.Address = a.Address; 
            this.Permission = a.Permission;
            this.Active = a.Active;
        }
        // Ep kieu sang Model
        public Account toModel()
        {
            return new Account()
            {
                ID = this.ID,
                Username = this.Username,
                Password = this.Password,
                Fullname = this.Fullname,
                Birthday = this.Birthday,
                Sex = this.Sex,
                PhoneNumber = this.PhoneNumber,
                Email = this.Email,
                Address = this.Address,
                Permission = this.Permission,
                Active = this.Active
            };
        }


    }
}
