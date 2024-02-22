using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using net03_group02.src.Domain.Asessment;
using net03_group02.src.Domain.Classroom;
using net03_group02.src.Domain.RoleBase;
using net03_group02.src.Domain.Syllabus;
using net03_group02.src.Domain.Training;
using net03_group02.src.Domain.User;

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
            .HasKey(cu => new { cu.TopicCode, cu.TrainingProgramCode});
    }
}
