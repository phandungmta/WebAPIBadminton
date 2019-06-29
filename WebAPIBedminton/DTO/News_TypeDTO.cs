namespace WebAPIBedminton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebAPIBedminton.Models;

    public partial class News_TypeDTO
    {
     
        public News_TypeDTO()
        {
            
        }

        public int ID { get; set; }

     
        public string Name { get; set; }

        public int Active { get; set; }

        public News_TypeDTO(News_Type obj)
        {
            this.ID = obj.ID;
            this.Name = obj.Name;
            this.Active = obj.Active;
        }

        public News_Type toModel()
        {
                return new News_Type()
                 {
                   ID = this.ID,
                   Name = this.Name,
                   Active = this.Active,
                };
            
        }


    }
}
