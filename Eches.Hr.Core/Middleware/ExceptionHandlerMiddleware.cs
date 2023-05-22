using Eches.Hr.Core.Exceptions;
using Eches.Hr.SharedKernal.Exceptions;
using Eches.Hr.Core.ViewModel.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace Eches.Hr.Core
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ServerException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case BadRequest e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case UnsafeQueryStringException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case RefreshTokenInvalidException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    case Unauthorized e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    case Forbidden e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;
                    case NotFound e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case PolicyViolationException e:
                        // not found error
                        response.StatusCode = 445;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                _logger.LogError("{0} - {1} - {2}", error.GetType(), error.Message, error.StackTrace);


                var result = JsonConvert.SerializeObject(new ErrorResponseViewModel
                {
                    TraceId = context.TraceIdentifier,
                    Code = response.StatusCode,
                    Message = response.StatusCode == 500 ? "An unexpected error occured while processing your request." : error.Message,
                    Succeeded = false,
                    Payload = response.StatusCode == 500 ? null : error.Data,
                }, new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });


                await response.WriteAsync(result);
            }
        }
    }
}
