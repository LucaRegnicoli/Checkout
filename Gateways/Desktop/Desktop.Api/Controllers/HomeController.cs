using Microsoft.AspNetCore.Mvc;

namespace Checkout.Desktop.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet()]
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
