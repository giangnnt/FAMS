using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using net03_group02.src.Domain.Asessment;
using net03_group02.src.Domain.Classroom;
using net03_group02.src.Domain.RoleBase;
using net03_group02.src.Domain.Syllabus;
using net03_group02.src.Domain.Training;
using net03_group02.src.Domain.User;

#nullable disable

namespace net03_group02.src
{
    public partial class FAMSContext : DbContext
    {
        public FAMSContext()
        {
        }

        public FAMSContext(DbContextOptions<FAMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AsessmentScheme> AsessmentSchemes { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassUser> ClassUsers { get; set; }
        public virtual DbSet<LearningObjective> LearningObjectives { get; set; }
        public virtual DbSet<OutputStandard> OutputStandards { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Syllabus> Syllabuses { get; set; }
        public virtual DbSet<TrainingContent> TrainingContents { get; set; }
        public virtual DbSet<TrainingMaterial> TrainingMaterials { get; set; }
        public virtual DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public virtual DbSet<TrainingProgramSyllabus> TrainingProgramSyllabuses { get; set; }
        public virtual DbSet<TrainingUnit> TrainingUnits { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FAMS;Username=postgres;Password=123456;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassUser>(entity => entity.HasKey(e => new { e.ClassId, e.UserId }));
            modelBuilder.Entity<TrainingProgramSyllabus>(entity => entity.HasKey(e => new { e.SyllabusId, e.TrainingProgramCode }));

        }
    }
}


//     modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

//     modelBuilder.Entity<AsessmentScheme>(entity =>
//     {
//         entity.ToTable("AssesmentScheme");

//         entity.HasKey(e => e.Id);

//         entity.Property(e => e.Id).ValueGeneratedOnAdd();

//         entity.HasOne(d => d.Syllabus)
//             .WithMany(p => p.AsessmentSchemes)
//             .HasForeignKey(d => d.SyllabusId);
//     });

//     modelBuilder.Entity<Class>(entity =>
//     {
//         entity.HasKey(e => e.ClassId)();

//         entity.Property(e => e.ClassName).IsRequired();

//         entity.Property(e => e.FSU).HasColumnName("FSU");

//         entity.Property(e => e.TrainingProgramCode).HasColumnName("TrainingProgramCode");

//         entity.HasOne(d => d.TrainingProgram)
//             .WithMany(p => p.Classes)
//             .HasForeignKey(d => d.TrainingProgramCode);
//     });

//     modelBuilder.Entity<ClassUser>(entity =>
//     {
//         entity.HasKey(e => new { e.ClassId, e.UserId });

//         entity.HasOne(d => d.Class)
//             .WithMany(p => p.ClassUsers)
//             .HasForeignKey(d => d.ClassId);

//         entity.HasOne(d => d.User)
//             .WithMany(p => p.ClassUsers)
//             .HasForeignKey(d => d.UserId);
//     });

//     modelBuilder.Entity<LearningObjective>(entity =>
//     {
//         entity.HasKey(e => e.LearningObjectiveCode);

//         entity.Property(e => e.LearningObjectiveCode).ValueGeneratedNever();

//         entity.Property(e => e.Name).IsRequired();

//         entity.HasOne(d => d.TrainingContent)
//             .WithMany(p => p.LearningObjectives)
//             .HasForeignKey(d => d.TrainingContentId);
//     });

//     modelBuilder.Entity<OutputStandard>(entity =>
//     {
//         entity.ToTable("OutputStandard");

//         entity.Property(e => e.OutputStandardId).ValueGeneratedNever();

//         entity.Property(e => e.Name).IsRequired();
//     });

//     modelBuilder.Entity<Permission>(entity =>
//     {
//         entity.Property(e => e.Name).IsRequired();
//     });

//     modelBuilder.Entity<Role>(entity =>
//     {
//         entity.Property(e => e.Name).IsRequired();
//     });

//     modelBuilder.Entity<Syllabus>(entity =>
//     {
//         entity.HasKey(e => e.SyllabusId);

//         entity.Property(e => e.SyllabusId).ValueGeneratedNever();

//         entity.Property(e => e.TopicCode).IsRequired();

//         entity.Property(e => e.TopicName).IsRequired();

//         entity.Property(e => e.TrainingAudience).IsRequired();

//         entity.HasOne(d => d.CreatedByUser)
//             .WithMany(p => p.Syllabbuses)
//             .HasForeignKey(d => d.CreatedByUser);
//     });

//     modelBuilder.Entity<TrainingContent>(entity =>
//     {
//         entity.Property(e => e.TrainingContentId).ValueGeneratedNever();

//         entity.Property(e => e.ContentName).IsRequired();

//         entity.HasOne(d => d.OutputStandard)
//             .WithMany(p => p.TrainingContents)
//             .HasForeignKey(d => d.OutputStandard);

//         entity.HasOne(d => d.TrainingUnit)
//             .WithMany(p => p.TrainingContents)
//             .HasForeignKey(d => d.UnitCode);
//     });

//     modelBuilder.Entity<TrainingMaterial>(entity =>
//     {

//         entity.HasKey(e => e.MaterialId);

//         entity.Property(e => e.Fileupload);

//         entity.HasOne(d => d.TrainingUnit)
//             .WithMany(p => p.TrainingMaterials)
//             .HasForeignKey(d => d.UnitCode);
//     });

//     modelBuilder.Entity<TrainingProgram>(entity =>
//     {
//         entity.HasKey(e => e.TrainingProgramCode);

//         entity.HasIndex(e => e.UserId, "IX_TrainingPrograms_UserId");

//         entity.Property(e => e.TrainingProgramCode).ValueGeneratedNever();

//         entity.HasOne(d => d.User)
//             .WithMany(p => p.TrainingPrograms)
//             .HasForeignKey(d => d.UserId);
//     });

//     modelBuilder.Entity<TrainingProgramSyllabus>(entity =>
//     {
//         entity.HasKey(e => new { e.SyllabusId, e.TrainingProgramCode });

//         entity.HasOne(d => d.Syllabus)
//             .WithMany(p => p.TrainingProgramSyllabuses)
//             .HasForeignKey(d => d.SyllabusId);

//         entity.HasOne(d => d.TrainingProgram)
//             .WithMany(p => p.TrainingProgramSyllabuses)
//             .HasForeignKey(d => d.TrainingProgramCode)
//             .HasConstraintName("FK_TrainingProgramSyllabuses_TrainingPrograms_TrainingProgramC~");
//     });

//     modelBuilder.Entity<TrainingUnit>(entity =>
//     {
//         entity.HasKey(e => e.UnitCode);

//         entity.Property(e => e.UnitCode).ValueGeneratedNever();

//         entity.HasOne(d => d.Syllabus)
//             .WithMany(p => p.TrainingUnits)
//             .HasForeignKey(d => d.SyllabusId);
//     });

//     modelBuilder.Entity<User>(entity =>
//     {
//         entity.HasIndex(e => e.Roleid, "IX_Users_Roleid");

//         entity.Property(e => e.Id).ValueGeneratedNever();

//         entity.Property(e => e.Email).IsRequired();

//         entity.Property(e => e.Name).IsRequired();

//         entity.Property(e => e.Password).IsRequired();

//         entity.HasOne(d => d.Role)
//             .WithMany(p => p.Users)
//             .HasForeignKey(d => d.Roleid);
//     });

//         OnModelCreatingPartial(modelBuilder);
//     }

//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
// }
