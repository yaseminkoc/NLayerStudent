using Microsoft.AspNetCore.Mvc.Filters;

namespace NLayer.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : class
    {
        //eğer herhangi bir filtere takılmayacaksa next ile request yoluna devam edecek
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
