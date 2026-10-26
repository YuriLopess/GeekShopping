using System;

namespace GeekShopping.Web.Utils;

public static class HttpClientExtensions
{
    public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
    {
        if(!response.IsSuccessStatusCode) throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

        return await response.Content.ReadFromJsonAsync<T>()
            ?? throw new ApplicationException("The API returned an empty response");
    }
}
