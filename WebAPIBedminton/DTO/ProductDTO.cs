namespace WebAPIBedminton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class ProductDTO
    {
 
        public ProductDTO()
        {
           
        }

        public int ID { get; set; }

     
        public string Name { get; set; }

        public int ProducerID { get; set; }

        public int CategoryID { get; set; }
    
        public int Price { get; set; }

   
        public string IMG { get; set; }

        public int Quantity { get; set; }

    
        public string Description { get; set; }

        public int TopHot { get; set; }

        public int NewProduct { get; set; }

        public string Active { get; set; }

        public ProductDTO(Product obj)
        {
            this.ID = obj.ID;
            this.Name = obj.Name;
            this.ProducerID = obj.ProducerID;
            this.CategoryID = obj.CategoryID;
            this.Price = obj.Price;
            this.IMG = obj.IMG;
            this.Quantity = obj.Quantity;
            this.Description = obj.Description;
            this.TopHot = obj.TopHot;
            this.NewProduct = obj.NewProduct;
            this.Active = obj.Active;
        }

        public Product toModel()
        {
            return new Product()
            {
                ID = this.ID,
                Name = this.Name,
                ProducerID = this.ProducerID,
                CategoryID = this.CategoryID,
                Price = this.Price,
                IMG = this.IMG,
                Quantity = this.Quantity,
                Description = this.Description,
                TopHot = this.TopHot,
                NewProduct = this.NewProduct,
                Active = this.Active,
            };
        }

     
    }
}
