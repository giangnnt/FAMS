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
