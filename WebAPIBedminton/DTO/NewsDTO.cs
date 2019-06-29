namespace WebAPIBedminton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NewsDTO
    {
        public int ID { get; set; }

     
        public string Title { get; set; }

        public int IsPublic { get; set; }

     
        public string Content { get; set; }

        public string Author { get; set; }

       
        public DateTime CreatedDate { get; set; }

        public int NewsTypeID { get; set; }


        public NewsDTO() { }
        public NewsDTO( News obj)
        {
            this.ID = obj.ID;
            this.Title = obj.Title;
            this.NewsTypeID = obj.NewsTypeID;
            this.IsPublic = obj.IsPublic;
            this.Content = obj.Content;
            this.Author = obj.Author;
            this.CreatedDate = obj.CreatedDate;
        }

        public News toModel()
        {
            return new News()
            {
                ID = this.ID,
                Title = this.Title,
                NewsTypeID = this.NewsTypeID,
                IsPublic = this.IsPublic,
                Content = this.Content,
                Author = this.Author,
                CreatedDate = this.CreatedDate

            };
        }



    }
}
