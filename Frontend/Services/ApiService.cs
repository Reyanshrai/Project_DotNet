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
            
            // Create a dictionary with the exact field names expected by the backend
            var userDataDict = new Dictionary<string, string>
            {
                { "firstname", userData.FirstName },
                { "lastname", userData.LastName },
                { "email", userData.Email },
                { "password", userData.Password },
                { "dateOfBirth", userData.Dob },
                { "mobileNumber", userData.Mobile },
                { "gender", userData.Gender }
            };
            
            var json = JsonConvert.SerializeObject(userDataDict);
            _logger.LogInformation("Serialized user data: {Json}", json);
            
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
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
            
            // Create a dictionary with the exact field names expected by the backend
            var loginDataDict = new Dictionary<string, string>
            {
                { "email", userData.Email },
                { "password", userData.Password }
            };
            
            var json = JsonConvert.SerializeObject(loginDataDict);
            _logger.LogInformation("Serialized login data: {Json}", json);
            
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("users/login", jsonContent);
            
            var responseContent = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Login response: {StatusCode}, Content: {Content}", 
                response.StatusCode, responseContent);
                
            return responseContent;
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
            
            // Create a dictionary with the exact field names expected by the backend
            var loginDataDict = new Dictionary<string, string>
            {
                { "email", userData.Email },
                { "password", userData.Password }
            };
            
            var json = JsonConvert.SerializeObject(loginDataDict);
            _logger.LogInformation("Serialized admin login data: {Json}", json);
            
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("admins/login", jsonContent);
            
            var responseContent = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Admin login response: {StatusCode}, Content: {Content}", 
                response.StatusCode, responseContent);
                
            return responseContent;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error logging in admin: {Email}", userData.Email);
            throw;
        }
    }
}
