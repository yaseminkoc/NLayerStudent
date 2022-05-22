using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _services;
        private readonly ISchoolService _schoolService;

        public StudentsController(IStudentService services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
           return View(await _services.GetStudentsWithSchool());
        }

        public async Task<IActionResult> Save()
        {

        }
    }
}
