using System.Diagnostics;
using System.Text.Json.Serialization;

namespace ChatGptDemo.Models
{
    [DebuggerDisplay("Text = {Text}")]
    public class ChatGPTChoice
    {
        [JsonPropertyName("text")]
        public string? Text
        {
            get;
            set;
        }
    }
}
