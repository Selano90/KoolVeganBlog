using KoolVeganBlog.Data.FileManager;
using KoolVeganBlog.Models;
using KoolVeganBlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            return View();
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

        public ActionResult Posts()
        {
            ViewBag.Message = "Wanna read our posts ?";
            var posts = _repo.GetPosts();
            return View(posts);
        }

        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }

    }
}
