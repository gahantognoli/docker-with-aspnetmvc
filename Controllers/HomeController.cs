using Microsoft.AspNetCore.Mvc;
using mvc1.Models;

namespace mvc1.Controllers;

public class HomeController : Controller
{
    private readonly IRepository _repository;
    private string _message;

    public HomeController(IRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _message = $"Docker - {configuration["HOSTNAME"]}";
    }

    public IActionResult Index()
    {
        ViewBag.Message = _message;
        return View(_repository.Produtos);
    }
}
