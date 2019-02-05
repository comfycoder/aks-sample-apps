using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SampleWebConfigurable.Models;

namespace SampleWebConfigurable.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _hostingEnv;

        public HomeController(
            IConfiguration config,
            IHostingEnvironment hostingEnv)
        {
            _config = config;
            _hostingEnv = hostingEnv;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel();

            viewModel.EnvironmentName = _hostingEnv.EnvironmentName;
            viewModel.HostName = System.Net.Dns.GetHostName();
            viewModel.MySetting = _config["MySetting"];
            viewModel.MySecret = "<NOT FOUND>";

            var mySecret = "";

            if (System.IO.File.Exists(viewModel.MySecretFile))
            {
                mySecret = System.IO.File.ReadAllText(viewModel.MySecretFile);
            }
            else
            {
                if (_hostingEnv.EnvironmentName.Equals("Development"))
                {
                    mySecret = _config["MySecret"];
                }
            }

            viewModel.MySecret = mySecret;

            return View(viewModel);
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
