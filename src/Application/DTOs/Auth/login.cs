using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using net03_group02.src.Application.Shared.Constant;

namespace net03_group02.src.Application.DTOs;
public class LoginReq
{
        [Required]
        [StringLength(30)]
        [RegularExpression(RegexConst.EMAIL, ErrorMessage = "Invalid email address")]
        public string Email {get; set;} = null!;
        [Required]
        public string Password {get; set;} = null!;
}