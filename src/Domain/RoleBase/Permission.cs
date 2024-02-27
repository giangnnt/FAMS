using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FAMS.src.Domain.RoleBase;
public class Permission
{
    [Key]
    public string Permissionid { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public List<Role> Roles { get; } = new();
}
