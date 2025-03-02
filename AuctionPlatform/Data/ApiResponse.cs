using System.Net;

namespace AuctionPlatform.Data
{
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indicates whether the operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The HTTP status code of the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// The actual data being returned.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// An optional message describing the result or error.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the ApiResponse class with success.
        /// </summary>
        /// <param name="data">The data to return.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        public ApiResponse(T data, HttpStatusCode statusCode)
        {
            Success = true;
            Data = data;
            StatusCode = statusCode;
            Message = null; // No message for successful responses by default.
        }

        /// <summary>
        /// Initializes a new instance of the ApiResponse class with an error.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        public ApiResponse(string errorMessage, HttpStatusCode statusCode)
        {
            Success = false;
            Data = default; // No data for error responses.
            StatusCode = statusCode;
            Message = errorMessage;
        }
    }
}
