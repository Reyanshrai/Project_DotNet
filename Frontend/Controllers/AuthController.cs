using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using Frontend.Models;

namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthApiController : ControllerBase
    {
        private readonly ApiService _apiService;

        public AuthApiController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpPost("users/register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterViewModel userData)
        {
            try
            {
                var result = await _apiService.RegisterUser(userData);
                var response = JsonConvert.DeserializeObject<AuthResponse>(result);
                
                if (response.Success)
                {
                    return Ok(response);
                }
                
                return BadRequest(new { message = response.Message ?? response.Error ?? "Registration failed" });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { message = "Error connecting to backend service", error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Registration failed", error = ex.Message });
            }
        }

        [HttpPost("users/login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginViewModel loginData)
        {
            try
            {
                var result = await _apiService.LoginUser(loginData);
                var response = JsonConvert.DeserializeObject<AuthResponse>(result);
                
                if (response.Success)
                {
                    return Ok(response);
                }
                
                return BadRequest(new { message = response.Message ?? response.Error ?? "Login failed" });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { message = "Error connecting to backend service", error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Login failed", error = ex.Message });
            }
        }

        [HttpPost("admins/login")]
        public async Task<IActionResult> LoginAdmin([FromBody] LoginViewModel loginData)
        {
            try
            {
                var result = await _apiService.LoginAdmin(loginData);
                var response = JsonConvert.DeserializeObject<AuthResponse>(result);
                
                if (response.Success)
                {
                    return Ok(response);
                }
                
                return BadRequest(new { message = response.Message ?? response.Error ?? "Admin login failed" });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { message = "Error connecting to backend service", error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Admin login failed", error = ex.Message });
            }
        }
    }
}
