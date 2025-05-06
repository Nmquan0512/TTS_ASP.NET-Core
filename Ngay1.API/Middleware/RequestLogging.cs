namespace Ngay1.API.Middleware;

public class RequestLogging
{
	private readonly RequestDelegate _next;
	public RequestLogging(RequestDelegate next) => _next = next;

	public async Task Invoke(HttpContext context)
	{
		Console.WriteLine($"[LOG] {context.Request.Method} - {context.Request.Path}");
		await _next(context);
	}
}