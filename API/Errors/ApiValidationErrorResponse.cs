using System.Collections.Generic;

namespace API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
            // TODO
        }
        public IEnumerable<string> Errors { get; set; }
    }
}