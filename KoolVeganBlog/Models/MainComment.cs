using System.Collections.Generic;

namespace KoolVeganBlog.Models
{
    public class MainComment : Comment
    {
        public List<SubComment> SubComments { get; set; }
    }
}
