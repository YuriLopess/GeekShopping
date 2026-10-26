namespace GeekShopping.Web.Utils;

public static class HttpClientExtensions
{
    public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

        return await response.Content.ReadFromJsonAsync<T>()
            ?? throw new ApplicationException("The API returned null");
    }

    public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
    {
        return httpClient.PostAsJsonAsync(url, data);
    }

    public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
    {
        return httpClient.PutAsJsonAsync(url, data);
    }
}
