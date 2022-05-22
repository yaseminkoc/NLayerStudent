using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        //eğer herhangi bir filtere takılmayacaksa next ile request yoluna devam edecek
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke(); // eğer null ise bu id ile herhangi bir karşılaştırma yapmayacağım için devam et diyorum
                return;
            }
            //eğer id varsa da:
            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);//idnin olup olmadığını kontrol et
            if (anyEntity)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404,$"{typeof(T).Name}({id}) not found"));
            
        }
    }
}
