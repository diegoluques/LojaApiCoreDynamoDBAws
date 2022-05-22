using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace CadastroApiCore.API.Pipeline
{
    public static class ExceptionHandlerConfiguration
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async ctx =>
                {
                    var errorApp = ctx.Features.Get<IExceptionHandlerFeature>();
                    var ex = errorApp?.Error;

                    ctx.Response.ContentType = "application/json";
                    ctx.Response.StatusCode = GetStatusCode(ex);
                    var message = ex?.Message;

                    var strJson = $@"{{ ""sucess"": false, ""message"": ""{message}"", ""message_type"": ""error"" }}";
                    await ctx.Response.WriteAsync(strJson);
                });
            });
        }

        private static int GetStatusCode(Exception ex)
        {
            if (ex is AmazonServiceException)
                return (int)((AmazonServiceException)ex).StatusCode;

            return (int)HttpStatusCode.InternalServerError;
        }

    }
}
