using Hotel.ATR.Portal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.ATR.Portal.Controllers
{
    public class RoomController : Controller
    {
        private IWebHostEnvironment webHost;
        private readonly ILogger<RoomController>_logger;


        public IActionResult index(int id) {
            _logger.LogInformation("logging Information");
            _logger.LogCritical("Logging critical");
            _logger.LogWarning("Logging LogWarning");
            _logger.LogDebug("Logging LogDebug");
            
            ViewBag.Id = id;
            TempData["id"] = id;

            return View();
        
        }
        public RoomController(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
        }

        public IActionResult Index(int page, int counter)
        {

            var user = new User() { email = "ok@ok.kz", name = "yevgenyi" };
            ViewBag.User = user;
            ViewData["user"] = user;
            TempData["user"] = user;
            return View(user);

        }


        public IActionResult RoomList()
        {
            return View();
        }
        public IActionResult RoomDetails()
        {
            return View();
        }

        /// <summary>
        ///1.string email
        ///2.User user
        ///3.Request.Form
        /// </summary>
        [HttpPost]
        public IActionResult SubscribeNewsLetter(IFormFile userFile)
        {
            var req = Request.Form["email"];

            string path = Path.Combine(webHost.WebRootPath, userFile.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                userFile.CopyTo(stream);
            }

            //return View("Index");
            return RedirectToAction("Index");
            //return View("~/Views/Home/Index.cshtml");
        }
    }
}
