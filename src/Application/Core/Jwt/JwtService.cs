using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAMS.src.Application.Shared.Enum;

namespace FAMS.src.Application.Core.Jwt
{
    public interface IJwtService
    {
        string GenerateToken(Guid userId, Guid sessionId, int roleId, UserStatusEnum status, int exp);
        Payload? ValidateToken(string token);
    }
    public class JwtService : IJwtService
    {
        private readonly byte[] _key;
        private readonly JwtSecurityTokenHandler _handler;
        public JwtService()
        {
            var SecretKey = Environment.GetEnvironmentVariable("SecretKey") ?? "TtgphUjM(.[2m.Z,lD&,5!el};}CNoY0";
            _key = Encoding.ASCII.GetBytes(SecretKey);
            _handler = new JwtSecurityTokenHandler();
        }

        public string GenerateToken(Guid userId, Guid sessionId, int roleId, UserStatusEnum status, int exp)
        {
            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SecretKey") ?? "TtgphUjM(.[2m.Z,lD&,5!el};}CNoY0");
            throw new NotImplementedException();
        }

        public Payload? ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}