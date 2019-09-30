using KoolVeganBlog.Data;
using KoolVeganBlog.Models;
using Microsoft.EntityFrameworkCore;
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
        //public List<Post> GetPosts(string Category) => _blogContext.Posts
        //    .Where(post => post.Category.ToString().ToLower().Equals(Category.ToLower()))
        //    .ToList();

        public List<Post> GetPosts(string Category)
        {
            Func<Post, bool> InCategory = (post) =>
            {
                return post.Category.ToString().ToLower().Equals(Category.ToLower());
            };

            return _blogContext.Posts.Where(post => InCategory(post)).ToList();
        }

        public void AddPost(Post post)
        {
            post.Created = DateTime.UtcNow;
            post.LastModified = DateTime.UtcNow;
            post.Published = false;
            _blogContext.Posts.Add(post);
        }

        public Post GetPost(int id) => _blogContext.Posts.Include(p => p.MainComments)
            .ThenInclude(mc => mc.SubComments).FirstOrDefault(p => p.Id == id);


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
            //post.LastModified = DateTime.UtcNow;
            //var result = _blogContext.Posts.SingleOrDefault(b => b.Id == post.Id);
            //if (result != null)
            //{
            //    result.Title = post.Title;
            //    result.Body = post.Body;
            //    result.Category = post.Category;
            //    result.Description = post.Description;
            //    result.Tags = post.Tags;
            post.LastModified = DateTime.UtcNow;
            //    result.Image = post.Image;
            //    result.MainComments = post.MainComments;
            //}
            _blogContext.Update(post);
        }


        public async Task<bool> SaveChangesAsync()
        {
            if (await _blogContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void AddSubComment(SubComment comment)
        {
            _blogContext.SubComment.Add(comment);
        }

        public List<Tag> GetTags()
        {
            return _blogContext.Tags.ToList();
        }


        public Tag GetTag(int id) => _blogContext.Tags.FirstOrDefault(p => p.Id == id);

        public void AddTag(Tag tag)
        {
            if (!(_blogContext.Tags.Any(p => p.Name == tag.Name)))
                _blogContext.Tags.Add(tag);

        }

        public void UpdateTag(Tag tag)
        {
            _blogContext.Tags.Update(tag);
        }

        public void RemoveTag(int id)
        {
            _blogContext.Tags.Remove(GetTag(id));
        }

        public bool IsTag(int id)
        {
            return _blogContext.Tags.Any(p => p.Name == GetTag(id).Name);
        }

        public Tag getTagByName(string name)
        {
            return _blogContext.Tags.FirstOrDefault(p => p.Name == name);
        }

    }
}