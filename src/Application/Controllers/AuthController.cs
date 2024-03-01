using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FAMS.src.Application.DTOs;
using FAMS.src.Domain.User;
using FAMS.src.Application.Core.Jwt;
using net03_group02.src.Infrastructure.Repository;
using net03_group02.src.Application.Shared.Handler;
using net03_group02.src.Application.Core.Crypto;
using FAMS.src.Application.Shared.Enum;
using net03_group02.src.Application.Shared.Constant;
using System.Security.Cryptography;

namespace FAMS.src.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService, FAMSContext dbContext)
        {
            _userRepo = new UserRepository(dbContext);
            _jwtService = jwtService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginReq req)
        {
            try
            {
                var user = await _userRepo.GetUserByEmailAsync(req.Email);
                if (user == null)
                {
                    return ErrorResp.NotFound("User not found");
                }

                if (!CryptoService.VerifyPassword(req.Password, user.Password))
                {
                    return ErrorResp.Unauthorized(("Wrong password"));
                }

                Guid sessionId = Guid.NewGuid();

                var accessTk = GenerateAccessTk(user.Id, sessionId, user.RoleId, user.Status);
                var refreshTk = GenerateRefreshTk();
                TokenResp tokenResp = new()
                {
                    AccessToken = accessTk,
                    RefreshToken = refreshTk,
                    AccessTokenExp = DateTimeOffset.UtcNow.AddSeconds(JwtConst.ACCESS_TOKEN_EXP).ToUnixTimeSeconds(),
                    RefreshTokenExp = DateTimeOffset.UtcNow.AddSeconds(JwtConst.REFRESH_TOKEN_EXP).ToUnixTimeSeconds()
                };
                LoginResp resp = new()
                {
                    Message = "Login successfully",
                    Token = tokenResp
                };

                return Ok(resp);
            }
            catch (Exception e)
            {
                return ErrorResp.SomethingWrong(e.Message);
            }
        }
        private string GenerateAccessTk(Guid userId, Guid sessionId, int roleId, UserStatusEnum status)
        {
            return _jwtService.GenerateToken(userId, sessionId, roleId, status, JwtConst.ACCESS_TOKEN_EXP);
        }
        private static string GenerateRefreshTk()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}