using System;

namespace SimpleServer.Models.Api
{
    public class CreatePersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public bool Verified { get; set; }
        public string Email { get; set; }
        public byte Age { get; set; }
    }

    public class CreatePersonResponse
    {
        public int Id { get; set; }
    }
}
