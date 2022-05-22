using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
  
    public class SchoolsController : CustomBaseController
    {
        private readonly ISchoolService _schoolService;

        public SchoolsController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet("[action]/{schoolId}")]
        //api/schools/GetSingleSchoolByIdWithStudents/2
        public async Task<IActionResult> GetSingleSchoolByIdWithStudents(int schoolId)
        {
            return CreateActionResult(await _schoolService.GetSingleSchoolByIdWithStudentsAsync(schoolId));
        }
    }
}
