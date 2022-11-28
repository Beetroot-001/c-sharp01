using System;

namespace SimpleServer.Models.Api
{
    public class UpdatePersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Verified { get; set; }
        public string Email { get; set; }
        public byte? Age { get; set; }
    }

    public class UpdatePersonResponse
    {
        public string[] UpdatedFields { get; set; }
    }

    public class UpdatePersonInternalServerResponse
    {
        public string Message { get; set; }
    }
}
