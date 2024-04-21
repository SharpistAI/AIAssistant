using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace AIAssistant
{
    public class AiClient
    {
        public async Task<string> GetResponseAsync(string documentName,string keyword, string questionType)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"http://172.178.40.71:8080/api/assistant/Getquestions?documentName={documentName}&keyword={keyword}&questionType={questionType}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> EvaluateAnswerAsync(string documentName,string keyword,string question, string userAnswer)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"http://172.178.40.71:8080/api/assistant/Getquestions?documentName={documentName}&keyword={keyword}$question={question}&userAnswer={userAnswer}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
