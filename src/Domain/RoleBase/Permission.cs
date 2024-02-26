using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace net03_group02.src.Domain.RoleBase;
public class Permission
{
    [Key]
    public string Permissionid { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public List<Role> Roles { get; } = new();
}
