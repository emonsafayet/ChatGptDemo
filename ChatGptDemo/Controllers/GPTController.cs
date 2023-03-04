using ChatGptDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ChatGptDemo.Controllers
{

    [ApiController]
    public class GPTController : ControllerBase
    {  
        [HttpGet]
        [Route("UserChatGPT")]
       
        public async Task<IActionResult> UseChatGPT(string query)
        {
            string OutPutResult = "";
            CompletionRequest completionRequest = new CompletionRequest
            {
                Model = "text-davinci-003", 
                Prompt = query,
                MaxTokens = 120
            };
            CompletionResponse completionResponse = new CompletionResponse();
            using (HttpClient httpClient = new HttpClient())
            {
                using (var httpReq = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/completions"))
                {
                    httpReq.Headers.Add("Authorization", "Bearer {Secret Key}");
                    string requestString = JsonSerializer.Serialize(completionRequest);
                    httpReq.Content = new StringContent(requestString, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage? httpResponse = await httpClient.SendAsync(httpReq))
                    {
                        if (httpResponse is not null)
                        {
                            if (httpResponse.IsSuccessStatusCode)
                            {
                                string responseString = await httpResponse.Content.ReadAsStringAsync();
                                {
                                    if (!string.IsNullOrWhiteSpace(responseString))
                                    {
                                        completionResponse = JsonSerializer.Deserialize<CompletionResponse>(responseString);
                                    }
                                }
                            }
                        }
                        if (completionResponse is not null)
                        {
                            string? completionText = completionResponse.Choices?[0]?.Text;
                            return Ok(completionText);
                            //Console.WriteLine(completionText);
                        }
                    }


                }
            }
            return Ok(OutPutResult);
        }
    }
}
