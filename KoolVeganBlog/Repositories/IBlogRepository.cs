using KoolVeganBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoolVeganBlog.Repositories
{
    public interface IBlogRepository
    {
        List<Post> GetPosts();
        Post GetPost(int id);
        void AddPost(Post post);
        void UpdatePostContent(Post post);
        void UpdatePostTitle(Post post);
        void RemovePost(int id);
        void UpdatePost(Post post);

        Task<bool> SaveChangesAsync();
        void UpdatePostCategory(Post post);
    }
}
