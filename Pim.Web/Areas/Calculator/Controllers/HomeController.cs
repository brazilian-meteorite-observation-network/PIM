using Microsoft.AspNetCore.Mvc;

namespace Pim.Web.Areas.Calculator.Controllers;

[Area("Calculator")]
public class HomeController : Controller
{
    public IActionResult Index() => View();
}