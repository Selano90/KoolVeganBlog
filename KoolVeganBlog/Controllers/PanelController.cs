using KoolVeganBlog.Data.FileManager;
using KoolVeganBlog.Models;
using KoolVeganBlog.Repositories;
using KoolVeganBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KoolVeganBlog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IBlogRepository _repo;
        private IFileManager _fileManager;

        public PanelController(IBlogRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Wanna read our posts ?";
            var posts = _repo.GetPosts();
            return View(posts);
        }

        public ActionResult Post(int id)
        {
            ViewBag.Message = "Wanna read this post ?";

            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Message = "Wanna get a post ?";
            if (id == null)
                return View(new PostViewModel());
            else
            {
                var post = _repo.GetPost((int)id);
                string tags = "";

                foreach (PostTag tg in post.PostTags)
                {
                    tags = tags + ", " + tg.Tag.Name;
                }


                return View(new PostViewModel
                {
                    Title = post.Title,
                    Id = post.Id,
                    Body = post.Body,
                    Created = post.Created,
                    LastModified = post.LastModified,
                    Category = post.Category,
                    //Author = post.Author,
                    Tags = tags,
                    Published = post.Published,
                    CurrentImage = post.Image,
                    Description = post.Description,

                });
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(PostViewModel postvm)
        {
            ViewBag.Message = "Wanna create a post ?";


            var post = new Post
            {
                Title = postvm.Title,
                Id = postvm.Id,
                Body = postvm.Body,
                LastModified = DateTime.Now,
                Category = postvm.Category,
                //Author = postvm.Author,
                //Tags = postvm.Tags,
                Published = postvm.Published,
                Description = postvm.Description
            };

            List<string> _tags = Regex.Split(postvm.Tags, @"[ ,;]+").ToList();

            foreach (string t in _tags)
            {
                var tag = new Tag { Name = t };
                _repo.AddTag(tag);
            }

            if (postvm.Image == null)
                post.Image = postvm.CurrentImage;
            else
            {
                if (!string.IsNullOrEmpty(postvm.CurrentImage))
                    _fileManager.RemoveImage(postvm.CurrentImage);
                post.Image = await _fileManager.SaveImage(postvm.Image);

            }
            if (post.Id > 0)
            {
                _repo.UpdatePost(post);
            }
            else
            {
                post.Created = DateTime.Now;
                foreach (string t in _tags)
                {
                    var tag = new Tag { Name = t };
                    post.PostTags.Add(
                        new PostTag()
                        {
                            TagId = tag.Id
                        }
                        );
                }
                _repo.AddPost(post);

            }

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);

        }

        [HttpGet]
        public async Task<ActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
