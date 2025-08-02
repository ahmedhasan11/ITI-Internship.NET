using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_D1_Project.Data;
using MVC_D1_Project.Models;

namespace MVC_D1_Project.Controllers;

public class HomeController : Controller
{
    //private readonly ILogger<HomeController> _logger;
    //public HomeController(ILogger<HomeController> logger)
    //{
    //    _logger = logger;
    //}



    private readonly IRepository<Movie> _MovieRepository;
    public HomeController(IRepository<Movie> movierepo)
    {
        _MovieRepository = movierepo;
    }
    public IActionResult Index()
    {
        var MovList=_MovieRepository.GetAll().ToList();

        return View(MovList);
    }

    public IActionResult Details(int id)
    {
        var movie = _MovieRepository.GetById(id);
        return View(movie);
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
