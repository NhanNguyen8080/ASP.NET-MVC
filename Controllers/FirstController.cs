using Microsoft.AspNetCore.Mvc;
using MVC01.Services;

namespace MVC01.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;

        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public string Index()
        {
            //this.HttpContext
            //this.Request;
            //this.Response;
            //this.RouteData;

            //this.User;
            //this.ModelState;
            //this.ViewData;
            //this.ViewBag;
            //this.Url;
            //this.TempData;

            //có 6 log lever
            //LogLevel

            _logger.LogInformation("Index action!"); // ~~ console.WriteLine() nhưng nên sử dụng logger
            _logger.LogWarning("Warning");
            _logger.LogError("Error");
            _logger.LogDebug("Debug");
            _logger.LogCritical("Critical");




            return "tôi là index của first";
        }


        public IActionResult Content()
        {
            var content = @" Hello everyone,
                            i'm Nhân
                            Nice to meet you";
            return Content(content, "text/html");
        }

        public IActionResult ReadFileImage()
        {
            string filePath = Path.Combine(Program.ContentRootPath, "Files", "djmie.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/jpg");
        }

        public IActionResult IphonePrice()
        {
            return Json(
                new
                {
                    ProductName = "Iphone15",
                    Price = 1000
                });
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            return LocalRedirect(url);
        }

        public IActionResult Google()
        {
            var url = "https://google.com";
            return Redirect(url);
        }

        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = "My Friend";
            }


            //View() -> Razor Engine, đọc .cshtml (template)
            //View(template) -> đường dẫn tuyệt đối tới .cshtml
            //return View("/MyView/Hello1.cshtml");


            //View(template, model)
            //return View("/MyView/Hello1.cshtml", username); // MyView/Hello1.cshtml

            //Views/First/Hello2.cshtml
            //return View("Hello2", username);


            //Views/{Controller}/{Action}
            //Views/First/HelloView.cshtml  ->  đọc action
            //return View((object)username); 


            //tìm Views/First/Hello3.cshtml kh thấy
            //nó sẽ tìm đường dẫn mình configure ở ngoài program.cs
            return View("Hello3", username);


            //View() & View(model)  => sử dụng phổ biến
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(x => x.Id == id).FirstOrDefault();
            if (product == null)
            {
                //TempData["StatusMessage"] = "The product is not exist!";
                StatusMessage = "The product is not exist!";
                return Redirect(Url.Action("Index", "Home"));
            }

            //model
            //return View(product);

            //ViewData
            //ViewData["title"] = product.Name;
            //ViewData["product"] = product;
            //return View("ViewProduct2");

            //ViewBag
            ViewBag.Product = product;  
            return View("ViewProduct3");
        }




        //    Kiểu trả về                 | Phương thức
        //------------------------------------------------
        //ContentResult               | Content()
        //EmptyResult                 | new EmptyResult()
        //FileResult                  | File()
        //ForbidResult                | Forbid()
        //JsonResult                  | Json()
        //LocalRedirectResult         | LocalRedirect()
        //RedirectResult              | Redirect()
        //RedirectToActionResult      | RedirectToAction()
        //RedirectToPageResult        | RedirectToRoute()
        //RedirectToRouteResult       | RedirectToPage()
        //PartialViewResult           | PartialView()
        //ViewComponentResult         | ViewComponent()
        //StatusCodeResult            | StatusCode()
        //ViewResult                  | View()
    }
}
