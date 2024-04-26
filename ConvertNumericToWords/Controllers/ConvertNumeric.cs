using Microsoft.AspNetCore.Mvc;

namespace ConvertNumericToWords.Controllers
{
    public class ConvertNumeric : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
