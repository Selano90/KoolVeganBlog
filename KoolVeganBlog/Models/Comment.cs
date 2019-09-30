using System;

namespace KoolVeganBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        //public Author Author { get; set; }
    }
}