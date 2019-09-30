using KoolVeganBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoolVeganBlog.Repositories
{
    public interface IBlogRepository
    {

        //Post
        List<Post> GetPosts();
        List<Post> GetPosts(string Category);
        Post GetPost(int id);
        void AddPost(Post post);
        void UpdatePostContent(Post post);
        void UpdatePostTitle(Post post);
        void RemovePost(int id);
        void UpdatePost(Post post);
        void UpdatePostCategory(Post post);

        //Comments
        void AddSubComment(SubComment comment);

        //Tags
        List<Tag> GetTags();
        Tag GetTag(int id);
        void AddTag(Tag tag);
        void UpdateTag(Tag tag);
        void RemoveTag(int id);
        bool IsTag(int id);
        Tag getTagByName(string name);


        //Save
        Task<bool> SaveChangesAsync();
    }
}
