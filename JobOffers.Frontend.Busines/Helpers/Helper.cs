using System.IdentityModel.Tokens.Jwt;

namespace JobOffers.Frontend.Busines.Helpers
{
    public class Helper
    {
        public static string? DecryptToken(string? token)
        {
            if (token == null) return null;
            var handler = new JwtSecurityTokenHandler();
            var tokenResponse = handler.ReadJwtToken(token);
            return tokenResponse.Claims.FirstOrDefault(c => c.Type == "user")?.Value;
        }
    }
}
