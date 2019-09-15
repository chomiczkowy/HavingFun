using HavingFun.Common;
using HavingFun.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HavingFun.API.Common
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, LoggerHelper logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Guid errorGuid = Guid.NewGuid();

                        logger.Error($"ERROR ({errorGuid}): {contextFeature.Error}");

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Id = errorGuid,
                            Message = "Internal Server Error."
                        }));
                    }
                });
            });
        }
    }
}
