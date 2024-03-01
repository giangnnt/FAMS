using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FAMS.src.Domain.Asessment;
using FAMS.src.Domain.Classroom;
using FAMS.src.Domain.RoleBase;
using FAMS.src.Domain.Syllabus;
using FAMS.src.Domain.Training;
using FAMS.src.Domain.User;
using net03_group02.src.Application.Shared.Constant;
using net03_group02.src.Application.Core.Crypto;
using FAMS.src.Application.Shared.Enum;
using net03_group02.src.Application.Shared.Enum;

#nullable disable


public partial class FAMSContext : DbContext
{
    public FAMSContext()
    {

    }
    public FAMSContext(DbContextOptions<FAMSContext> options)
        : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FAMS;Username=postgres;Password=123456");
    }

    public DbSet<Class> Class { get; set; }
    public DbSet<ClassUser> ClassUsers { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Syllabus> Syllabuses { get; set; }
    public DbSet<LearningObjective> LearningObjectives { get; set; }
    public DbSet<TrainingContent> TrainingContents { get; set; }
    public DbSet<TrainingMaterial> TrainingMaterials { get; set; }
    public DbSet<TrainingProgram> TrainingPrograms { get; set; }
    public DbSet<TrainingProgramSyllabus> TrainingProgramSyllabuses { get; set; }
    public DbSet<TrainingUnit> TrainingUnits { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassUser>()
            .HasKey(cu => new { cu.ClassId, cu.UserId });
        modelBuilder.Entity<TrainingProgramSyllabus>()
            .HasKey(cu => new { cu.TopicCode, cu.TrainingProgramCode });
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Gender).HasConversion(
                v => v.ToString(),
                v => (GenderEnum)Enum.Parse(typeof(GenderEnum), v)
            );
            entity.Property(e => e.Status).HasConversion(
                v => v.ToString(),
                v => (UserStatusEnum)Enum.Parse(typeof(UserStatusEnum), v)
            );
            entity.HasData(
                new User
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000012345"),
                    Email = "FAMS@gmail.com",
                    Password = CryptoService.HashPassword("FAMS@@"),
                    Name = "Admin FAMS",
                    RoleId = RoleConst.GetRoleId(RoleConst.ADMIN),
                }
            );
        });
        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(e => e.Status).HasConversion(
                v => v.ToString(),
                v => (ClassStatusEnum)Enum.Parse(typeof(ClassStatusEnum), v)
            );
        });
        modelBuilder.Entity<User>(entity =>
        {

        });
        modelBuilder.Entity<Syllabus>(entity =>
        {
            entity.Property(e => e.Status).HasConversion(
                v => v.ToString(),
                v => (SyllabusStatusEnum)Enum.Parse(typeof(SyllabusStatusEnum), v)
            );
        });
        modelBuilder.Entity<TrainingContent>(entity =>
        {
            entity.Property(e => e.DeliveryType).HasConversion(
                v => v.ToString(),
                v => (TrainingContentDeliveryTypeEnum)Enum.Parse(typeof(TrainingContentDeliveryTypeEnum), v)
            );
            entity.Property(e => e.Method).HasConversion(
                v => v.ToString(),
                v => (TrainingContentMethodEnum)Enum.Parse(typeof(TrainingContentMethodEnum), v)
            );
        });
        modelBuilder.Entity<TrainingProgram>(entity =>
        {
            entity.Property(e => e.Status).HasConversion(
                v => v.ToString(),
                v => (TrainingProgramStatusEnum)Enum.Parse(typeof(TrainingProgramStatusEnum), v)
            );
        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasData(
                new Role { Id = RoleConst.ADMIN_ID, Name = RoleConst.ADMIN, Description = "Admin" }
            );
        });
    }

}
