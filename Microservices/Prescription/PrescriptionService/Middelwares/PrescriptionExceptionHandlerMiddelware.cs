using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using Helper; 

namespace PrescriptionService.Middlewares {
    public class PrescriptionExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware {
        public PrescriptionExceptionHandlerMiddleware(RequestDelegate next, ILogger<PrescriptionExceptionHandlerMiddleware> logger)
            : base(next, logger) {
        }

        public override HttpStatusCode GetHttpStatusCode(Exception exception) {
            HttpStatusCode statusCode = exception switch {
                DbUpdateConcurrencyException _ => HttpStatusCode.Conflict,
                _ => base.GetHttpStatusCode(exception)
            };

            return statusCode;
        }
    }
}
