namespace WebAPIBedminton.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebAPIBedminton.Models;

  
    public partial class CategoryDTO
    {

        public int ID { get; set; }

 
        public string Name { get; set; }

        public CategoryDTO() { }
        public CategoryDTO(Category a)
        {
            this.Name = a.Name;

        }
        // Ep kieu sang Model
        public Category toModel()
        {
            return new Category()
            {
                ID = this.ID,
                Name = this.Name
            };
        }
    }
}
