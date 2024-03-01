using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FAMS.src.Application.Shared.Constant;

namespace FAMS.src.Application.DTOs;
public class LoginReq
{
        [Required]
        [StringLength(30)]
        [RegularExpression(RegexConst.EMAIL, ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
}
public class LoginResp
{
        public string Message { get; set; } = null!;
        public TokenResp Token { get; set; } = null!;
}
public class TokenResp
{
        public string AccessToken { get; set; } = null!;
        public long AccessTokenExp { get; set; }
        public string RefreshToken { get; set; } = null!;
        public long RefreshTokenExp { get; set; }
}
