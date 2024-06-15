using CommonLibrary;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SignInService.Models;
using SignInService.Queries;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SignInService.JWToken;

public class JwtUtils : IJwtUtils
{
    private readonly ISender _sender;
    public JwtUtils(ISender sender)
    {
        _sender=sender;
    }

    public string GenerateJwtToken(Guid id)
    {
        // generate token that is valid for 15 minutes
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(ConfigHelper.GetAppSettings().Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", id.ToString()) }), //TODO : Is this correct code or should we changes this.
            Expires = DateTime.UtcNow.AddMinutes(20), // set to desired limit 
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public RefreshToken GenerateRefreshToken(string ipAddress)
    {
        var refreshToken = new RefreshToken
        {
            Token = getUniqueToken(),
            // token is valid for 7 days
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow,
            CreatedByIp = ipAddress
        };

        return refreshToken;

        string getUniqueToken()
        {
            // token is a cryptographically strong random sequence of values
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

            // ensure token is unique by checking against db
            var tokenIsUnique = _sender.Send(new CheckIfNewTokenIsUniqueQuery(token));

            if (!Convert.ToBoolean(tokenIsUnique.Result))
                return getUniqueToken();
            return token;
        }
    }
}