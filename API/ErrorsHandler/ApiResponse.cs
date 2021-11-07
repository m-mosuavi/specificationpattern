using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ErrorsHandler
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(object statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad request, you have made",
                401 => "Unauthorized",
                404 => "Resource not found",
                500 => "Server Error",
                _ => null
            };
        }
    }
}
