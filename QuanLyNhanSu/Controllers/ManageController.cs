using Microsoft.AspNetCore.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public String Welcome()
        {
            return "Welcome to employee manage system";
        }
    }
}
