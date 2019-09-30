using KoolVeganBlog.Data.FileManager;
using KoolVeganBlog.Models;
using KoolVeganBlog.Repositories;
using KoolVeganBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace KoolVeganBlog.Controllers
{
    public class HomeController : Controller
    {
        private IFileManager _fileManager;
        private IBlogRepository _repo;

        public HomeController(IBlogRepository repo, IFileManager fileManager)
        {
            _fileManager = fileManager;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var posts = _repo.GetPosts();
            return View(posts);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Who are we ?";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "How to reach us ?";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Post(int id)
        {
            ViewBag.Message = "Wanna read this post ?";

            var post = _repo.GetPost(id);
            return View(post);
        }

        public ActionResult Posts(string category)
        {
            ViewBag.Message = "Wanna read our posts ?";
            var posts = string.IsNullOrEmpty(category) ? _repo.GetPosts() : _repo.GetPosts(category);
            return View(posts);
        }

        [HttpGet("/Image/{image}")]
        [ResponseCache(CacheProfileName = "Monthly")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel cvm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Post", new { id = cvm.PostId });

            var post = _repo.GetPost(cvm.PostId);
            if (cvm.MainCommentId == 0)
            {
                post.MainComments = post.MainComments ?? new List<MainComment>();
                post.MainComments.Add(new MainComment
                {
                    Message = cvm.Message,
                    Created = DateTime.Now,
                });

                _repo.UpdatePost(post);

            }
            else
            {
                var comment = new SubComment
                {
                    MainCommentId = cvm.MainCommentId,
                    Message = cvm.Message,
                    Created = DateTime.Now,
                };
                _repo.AddSubComment(comment);
            }

            await _repo.SaveChangesAsync();

            return RedirectToAction("Post", new { id = cvm.PostId });
        }

    }
}
