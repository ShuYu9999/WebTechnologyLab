namespace Lab_1.Extensions;

public static class RequestExtensions
{
    public static bool IsAjaxRequest(this HttpRequest request)
    {
        return request.Headers.XRequestedWith.Equals("XMLHttpRequest");
    }
}