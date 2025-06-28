using System.Security.Claims;

namespace SmartHotelBooking.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return userIdClaim != null ? int.Parse(userIdClaim) : throw new Exception("User ID not found in token");
        }

        public static string GetUserEmail(this ClaimsPrincipal user)
        {
            return user?.FindFirst(ClaimTypes.Email)?.Value ?? throw new Exception("Email not found in token");
        }
    }
}
