using Azure.Search.Documents;
using Azure;
using Azure.Search.Documents.Models;
using System.Text;

namespace AIAssistant
{
    public class SearchService
    {
        public static async Task SearchHotels(string searchQuery)
        {
            // Replace with your search service details
            string endpoint = "https://your-search-service-name.search.windows.net";
            string apiKey = "your-access-key";
            string indexName = "your-index-name";

            // Create a SearchClient
            SearchClient searchClient = new SearchClient(new Uri(endpoint), indexName, new AzureKeyCredential(apiKey));

            // Build the search options
            var searchOptions = new SearchOptions
            {
                Filter = $"freetext(content)~='{searchQuery}'", // Filter for documents containing "hotels" in the name field
            };

            // Send the search request asynchronously
            try
            {
                var results = await searchClient.SearchAsync<SearchDocument>("*", searchOptions);
                foreach (var result in results.Value.Facets) {
                    await Console.Out.WriteLineAsync(result.Value.ToString());
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
