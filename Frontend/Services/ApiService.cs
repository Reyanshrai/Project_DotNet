using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using Frontend.Models;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiService> _logger;

    public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        
        // Ensure the base address is set to your Node.js backend
        _httpClient.BaseAddress = new Uri("http://localhost:3000/");
    }

    // ✅ Register User (Proxy to Node.js)
    public async Task<string> RegisterUser(RegisterViewModel userData)
    {
        try
        {
            _logger.LogInformation("Attempting to register user: {Email}", userData.Email);
            
            var jsonContent = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("users/register", jsonContent);
            
            var responseContent = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Registration response: {StatusCode}, Content: {Content}", 
                response.StatusCode, responseContent);
                
            return responseContent;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error registering user: {Email}", userData.Email);
            throw;
        }
    }

    // ✅ Login User (Proxy to Node.js)
    public async Task<string> LoginUser(LoginViewModel userData)
    {
        try
        {
            _logger.LogInformation("Attempting to login user: {Email}", userData.Email);
            
            // Create data dictionary with fields expected by the backend
            var loginData = new Dictionary<string, string>
            {
                { "email", userData.Email },
                { "password", userData.Password }
            };
            
            var jsonContent = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("users/login", jsonContent);
            
            var responseContent = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Login response: {StatusCode}, Content: {Content}", 
                response.StatusCode, responseContent);
            
            // Parse the response to create an AuthResponse
            if (response.IsSuccessStatusCode)
            {
                dynamic rawResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
                if (rawResponse != null)
                {
                    // Create an AuthResponse manually
                    var authResponse = new AuthResponse
                    {
                        Success = true,
                        Message = "Login successful",
                        Token = rawResponse.token?.ToString(),
                        User = new UserData 
                        {
                            Id = rawResponse._id?.ToString(),
                            Email = rawResponse.email?.ToString(),
                            FirstName = rawResponse.firstname?.ToString(),
                            LastName = rawResponse.lastname?.ToString(),
                            Role = "User"
                        }
                    };
                    
                    return JsonConvert.SerializeObject(authResponse);
                }
            }
            
            // If we couldn't create a successful response, create an error response
            return JsonConvert.SerializeObject(new AuthResponse
            {
                Success = false,
                Error = "Invalid email or password"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error logging in user: {Email}", userData.Email);
            throw;
        }
    }

    // ✅ Admin Login (Proxy to Node.js)
    public async Task<string> LoginAdmin(LoginViewModel userData)
    {
        try
        {
            _logger.LogInformation("Attempting to login admin: {Email}", userData.Email);
            
            // Create data dictionary with fields expected by the backend
            var loginData = new Dictionary<string, string>
            {
                { "email", userData.Email },
                { "password", userData.Password }
            };
            
            var jsonContent = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("admins/login", jsonContent);
            
            var responseContent = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Admin login response: {StatusCode}, Content: {Content}", 
                response.StatusCode, responseContent);
            
            // Parse the response to create an AuthResponse
            if (response.IsSuccessStatusCode)
            {
                dynamic rawResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
                if (rawResponse != null)
                {
                    // Create an AuthResponse manually
                    var authResponse = new AuthResponse
                    {
                        Success = true,
                        Message = "Login successful",
                        Token = rawResponse.token?.ToString(),
                        User = new UserData 
                        {
                            Id = rawResponse._id?.ToString(),
                            Email = rawResponse.email?.ToString(),
                            FirstName = rawResponse.firstname?.ToString() ?? "Admin",
                            LastName = rawResponse.lastname?.ToString() ?? "User",
                            Role = "Admin"
                        }
                    };
                    
                    return JsonConvert.SerializeObject(authResponse);
                }
            }
            
            // If we couldn't create a successful response, create an error response
            return JsonConvert.SerializeObject(new AuthResponse
            {
                Success = false,
                Error = "Invalid email or password"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error logging in admin: {Email}", userData.Email);
            throw;
        }
    }
}
