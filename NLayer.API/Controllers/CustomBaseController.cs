using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")] //burada action demediğimiz için controller kısmında isteği methodun tipine
    //ve parametresine göre eşleştiriyor
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]  //endpoint olmadığını belirtmek için
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            }
            return new ObjectResult(response) { 
                StatusCode = response.StatusCode
            };

        }
    }
}
