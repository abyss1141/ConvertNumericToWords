using ConvertNumericToWords.Models;
using ConvertNumericToWords.Service;
using Microsoft.AspNetCore.Mvc;

namespace ConvertNumericToWords.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConverterService _converterService;

        public HomeController(IConverterService converterService)
        {
            _converterService = converterService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConvertNumeric(string numericValue)
        {
            double value;
            if (double.TryParse(numericValue, out value))
            {
                var response = _converterService.ConvertNumericToWord(value);
                return View("Result", response);
            }
            else
            {
                var response = new ServiceResponse<string>
                {
                    IsSuccess = false,
                    Message = "Invalid numeric value provided"
                };
                return View("Result", response);
            }
        }
    }
}
