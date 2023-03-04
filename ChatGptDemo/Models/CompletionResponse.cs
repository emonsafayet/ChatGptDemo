using static ChatGptDemo.Controllers.GPTController;
using System.Text.Json.Serialization;

namespace ChatGptDemo.Models
{

    public class CompletionResponse
    {
        [JsonPropertyName("choices")]
        public List<ChatGPTChoice>? Choices
        {
            get;
            set;
        }
        [JsonPropertyName("usage")]
        public ChatGPTUsage? Usage
        {
            get;
            set;
        }
    }
}
