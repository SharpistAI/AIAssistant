using Newtonsoft.Json;

namespace AIAssistant.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AzureExtensionsContext
    {
        [JsonProperty("requestContentFilterResults")]
        public object RequestContentFilterResults { get; set; }

        [JsonProperty("responseContentFilterResults")]
        public object ResponseContentFilterResults { get; set; }

        [JsonProperty("citations")]
        public List<Citation> Citations { get; set; }

        [JsonProperty("intent")]
        public string Intent { get; set; }
    }

    public class Citation
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("url")]
        public object Url { get; set; }

        [JsonProperty("filepath")]
        public object Filepath { get; set; }

        [JsonProperty("chunkId")]
        public string ChunkId { get; set; }
    }

    public class Role
    {
    }

    public class Root
    {

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("toolCalls")]
        public List<object> ToolCalls { get; set; }

        [JsonProperty("functionCall")]
        public object FunctionCall { get; set; }

        [JsonProperty("azureExtensionsContext")]
        public AzureExtensionsContext AzureExtensionsContext { get; set; }
    }


}
