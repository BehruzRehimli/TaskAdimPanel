using HomeworkPustok.DAL;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkPustok.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly PustokDbContext _context;

        public SliderController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var datas=_context.Sliders.ToList();
            return View(datas);
        }
    }
}
