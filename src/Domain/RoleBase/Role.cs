using System;
using System.Collections.Generic;


namespace FAMS.src.Domain.RoleBase;

using System.ComponentModel.DataAnnotations;
using FAMS.src.Domain.User;
public class Role
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public List<Permission> Permissions { get; } = new();
    public List<User> Users { get; } = new();
}
