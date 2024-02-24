using Hotel.ATR.Portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.ATR.Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            User user = new User();
            user.email ="ok@ok.kz";


            _logger.LogError( "У пользователя {email} возникла ошибка {errorMessage} , " +
                "{action} , {controller}" , user.email , "Ошибка пользователя" , "Index" , "Home" );

            Stopwatch sw = new Stopwatch();
            _logger.LogInformation("Обращаемся к сервису");

            sw.Start();

            Thread.Sleep(1000);
            ///TODO обращение к чужому сервису
            sw.Stop();

            _logger.LogInformation("Сервис отработал {ElapsedMilliseconds}", sw.ElapsedMilliseconds);

            _logger.LogInformation("logging Information");
            _logger.LogCritical("Logging critical");
            _logger.LogWarning("Logging LogWarning");
            _logger.LogDebug("Logging LogDebug");


         
            return View();
        }
        public IActionResult Contact()
        {
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

    }
}