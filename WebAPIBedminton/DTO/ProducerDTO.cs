namespace WebAPIBedminton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

 
    public partial class ProducerDTO
    {
        public ProducerDTO()
        {
           
        }

        public int ID { get; set; }


        public string Name { get; set; }

    
        public string Images { get; set; }

        public ProducerDTO(Producer obj)
        {
            this.ID = obj.ID;
            this.Name = obj.Name;
            this.Images = obj.Images;
        }
        public Producer toModel()
        {
            return new Producer()
            {
                ID = this.ID,
                Name = this.Name,
                Images = this.Images

            };
        }


    }
}
