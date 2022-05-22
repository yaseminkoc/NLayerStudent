using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                // run sonlandırıcı bir methoddur, request eğer excetion varsa daha ileri gitmeyecek artık geri dönecek
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    //bir hata varsa bana hatayı verecek olan interfaceyi implement ettim ve böylece uygulamada fırlatılan hatayı almış oldum
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                   //Eğer hatanın tipi client side exception ise geriye 400 dön
                    var statusCode = exceptionFeature.Error switch { 
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500 //Eğer bunun dışında bir şeyse 500 dön

                    };
                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                   //normalde controllerde tip dönünde otomatik jsona dönüyor ama burada kendim middleware yazdığım için serialize etmem gerek
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response)); //responsei yazdırıyorum
                });
            });
        }
    }
}
