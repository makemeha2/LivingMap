using LivingMapAPI.DTOs;
using LivingMapAPI.DTOs.OAuth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
//using System.Text.Json;

namespace LivingMapAPI.Controllers
{

    [ApiController]
    [Route("api/oauth")]
    public class OAuthClientController : Controller
    {
        private readonly IConfiguration _configuration;

        public OAuthClientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("google/userInfo")]
        public async Task<IActionResult> GetGoogleUserInfo([FromBody]string code)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();

                var redirectUri = "https://localhost:5173";
                var tokenUrl = "https://oauth2.googleapis.com/token";

                var parameters = new Dictionary<string, string>
                {
                    { "code", code },
                    { "client_id", _configuration["GOOGLE:CLIENT_ID"] ?? string.Empty },
                    { "client_secret", _configuration["GOOGLE:CLIENT_SECRET"]  ?? string.Empty },
                    { "redirect_uri", redirectUri },
                    { "grant_type", "authorization_code" }
                };

                // 토큰 가져오기
                var response = await _httpClient.PostAsync(tokenUrl, new FormUrlEncodedContent(parameters));
                var tokenResponse = await response.Content.ReadAsStringAsync();
                var parsedObject = JsonConvert.DeserializeObject<GoogleTokenResponse>(tokenResponse);
                var accessToken = parsedObject?.AccessToken;

                // 유저 정보 가져오기
                var userInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var userInfoResponse = await _httpClient.GetAsync(userInfoUrl);
                var userInfo = JsonConvert.DeserializeObject<GoogleUserInfoResponse>(await userInfoResponse.Content.ReadAsStringAsync());

                // 유저 정보 반환
                if (userInfo != null && userInfo.Error == null)
                {
                    return Ok(ResponseInfo<GoogleUserInfoResponse>.CreateSuccess(userInfo));
                }
                else
                {
                    if (userInfo?.Error != null)
                    {
                        return Ok(ResponseInfo<object>.CreateFailure(userInfo?.Error.Message));
                    }
                    else
                    {
                        return Ok(ResponseInfo<object>.CreateFailure("Failed to get user info"));
                    }
                }
            }
            catch(Exception ex)
            {
                return Ok(ResponseInfo<object>.CreateFailure(ex.Message));
            }
        }
    }
}
