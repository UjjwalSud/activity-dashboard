using System.Security.Claims;

namespace activity_dashboard.Server.Architecture.Middleware
{
    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Extract the JWT token from the Authorization header
            string jwtToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var usernameClaim = context.User.FindFirst(ClaimTypes.Name)?.Value;
            var roleClaim = context.User.FindFirst(ClaimTypes.Role)?.Value;

            // You can now use 'jwtToken' as needed, for example, validate it or store it in the HttpContext.Items

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class JwtTokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtTokenMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtTokenMiddleware>();
        }
    }
}
