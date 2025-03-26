using System;
using Newtonsoft.Json;

namespace Frontend.Models
{
    public class AuthResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("user")]
        public UserData? User { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }
    }

    public class UserData
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("role")]
        public string? Role { get; set; }
    }
} 