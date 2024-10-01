using Microsoft.AspNetCore.Mvc;
using mvc1.Models;

namespace mvc1.Controllers;

public class HomeController : Controller
{
    private readonly IRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private string _message;

    public HomeController(IRepository repository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
        var hostname = _httpContextAccessor.HttpContext?.Request.Host.Value ?? "";
        _message = $"Docker - {hostname}";
    }

    public IActionResult Index()
    {
        ViewBag.Message = _message;
        return View(_repository.Produtos);
    }
}
