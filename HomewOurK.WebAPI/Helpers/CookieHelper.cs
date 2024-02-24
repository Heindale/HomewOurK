using System.Security.Claims;

namespace HomewOurK.WebAPI.Helpers
{
	public static class CookieHelper
	{
		public static string GetEmailByCookie(IHttpContextAccessor httpContextAccessor)
		{
			var httpContext = httpContextAccessor.HttpContext;

			if (httpContext != null)
			{
				var email = httpContext.User.FindFirstValue(ClaimTypes.Email);

				if (email != null)
					return email;
			}
			return "";
		}
	}
}