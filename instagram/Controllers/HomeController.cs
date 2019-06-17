using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using instagram.Models;
using MongoDB.Driver;
using instagram.Repository;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace instagram.Controllers
{
    public class HomeController : Controller
    {
        private PostRepository _repository;
        private IHostingEnvironment _env;
        public HomeController(IHostingEnvironment env)
        {
            _repository = new PostRepository();
            _env = env;
        }

        public IActionResult Feed()
        {
            return View(_repository.GetList().OrderByDescending(x=>x.CreatedAt));
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Post post)
        {
            var file = Request.Form.Files[0];

            var toImage = file.OpenReadStream();
            System.Drawing.Image image = new System.Drawing.Bitmap(toImage);
            var webRoot = _env.WebRootPath;
            var path = System.IO.Path.Combine(webRoot, "images");
            Utils.Save(image, path, file.FileName);
                       
            post.Image = file.FileName;
            _repository.Created(post);

            return RedirectToAction("Feed");
        }



    }
}
