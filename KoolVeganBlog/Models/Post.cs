using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KoolVeganBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Content")]
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public Category Category { get; set; }
        //public Author Author { get; set; }
        //public List<Tag> Tags { get; set; }
        public string Tags { get; set; }
        public bool Published { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<MainComment> MainComments { get; set; }
    }

    public enum Category
    {
        Veganism = 1,
        Animals,
        Planet,
        Recipes,
        Media,
        Events

    }
}