using System.Net;

namespace AspStudio_Boilerplate.Infrastructure.Entities.Api
{
    public class ApiResponse
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }

        public ApiResponse(HttpStatusCode status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}