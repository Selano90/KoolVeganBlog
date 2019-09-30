using KoolVeganBlog.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace KoolVeganBlog.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Content")]
        public string Body { get; set; }
        public string CurrentImage { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
        public string Tags { get; set; }
        public bool Published { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
    }
}
