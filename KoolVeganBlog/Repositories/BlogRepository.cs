using KoolVeganBlog.Data;
using KoolVeganBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KoolVeganBlog.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private ApplicationDbContext _blogContext;

        public BlogRepository(ApplicationDbContext blogContext)
        {
            _blogContext = blogContext;
        }

        public List<Post> GetPosts() => _blogContext.Posts.ToList();

        public void AddPost(Post post)
        {
            post.Created = DateTime.UtcNow;
            post.LastModified = DateTime.UtcNow;
            post.Published = false;
            _blogContext.Posts.Add(post);
        }

        public Post GetPost(int id) => _blogContext.Posts.FirstOrDefault(p => p.Id == id);


        public void RemovePost(int id) => _blogContext.Posts.Remove(GetPost(id));

        public void UpdatePostContent(Post post)
        {
            var result = _blogContext.Posts.SingleOrDefault(b => b.Id == post.Id);
            if (result != null)
            {
                result.Body = post.Body;
                result.LastModified = DateTime.UtcNow;
            }
        }

        public void UpdatePostTitle(Post post)
        {
            var result = _blogContext.Posts.SingleOrDefault(b => b.Id == post.Id);
            if (result != null)
            {
                result.Title = post.Title;
                result.LastModified = DateTime.UtcNow;
            }
        }

        public void UpdatePostCategory(Post post)
        {
            var result = _blogContext.Posts.SingleOrDefault(b => b.Id == post.Id);
            if (result != null)
            {
                result.Category = post.Category;
                result.LastModified = DateTime.UtcNow;
            }
        }

        public void UpdatePost(Post post)
        {
            post.LastModified = DateTime.UtcNow;
            var result = _blogContext.Posts.SingleOrDefault(b => b.Id == post.Id);
            if (result != null)
            {
                result.Title = post.Title;
                result.Body = post.Body;
                result.Category = post.Category;
                result.LastModified = DateTime.UtcNow;
            }
            //_blogContext.Update(post);
        }


        public async Task<bool> SaveChangesAsync()
        {
            if (await _blogContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}