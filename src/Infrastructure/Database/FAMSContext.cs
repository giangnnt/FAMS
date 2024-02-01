using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FAMS.Models
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
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Permissionrole> Permissionroles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Syllabus> Syllabi { get; set; }
        public virtual DbSet<TrainingContent> TrainingContents { get; set; }
        public virtual DbSet<TrainingMaterial> TrainingMaterials { get; set; }
        public virtual DbSet<TrainingProgramSyllabus> TrainingProgramSyllabi { get; set; }
        public virtual DbSet<TrainingUnit> TrainingUnits { get; set; }
        public virtual DbSet<Trainingprogram> Trainingprograms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FAMS;Username=postgres;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<AsessmentScheme>(entity =>
            {
                entity.ToTable("AsessmentScheme");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Assigment).HasColumnName("assigment");

                entity.Property(e => e.Final).HasColumnName("final");

                entity.Property(e => e.Finalpratical).HasColumnName("finalpratical");

                entity.Property(e => e.Finaltheory).HasColumnName("finaltheory");

                entity.Property(e => e.Gpa).HasColumnName("gpa");

                entity.Property(e => e.Quiz).HasColumnName("quiz");

                entity.Property(e => e.Topiccode)
                    .HasMaxLength(50)
                    .HasColumnName("topiccode");

                entity.HasOne(d => d.TopiccodeNavigation)
                    .WithMany(p => p.AsessmentSchemes)
                    .HasForeignKey(d => d.Topiccode)
                    .HasConstraintName("AsessmentScheme_topiccode_fkey");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.Property(e => e.Classid)
                    .ValueGeneratedNever()
                    .HasColumnName("classid");

                entity.Property(e => e.Classcode)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("classcode");

                entity.Property(e => e.Classname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("classname");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Duration)
                    .HasMaxLength(30)
                    .HasColumnName("duration");

                entity.Property(e => e.Enddate)
                    .HasColumnType("date")
                    .HasColumnName("enddate");

                entity.Property(e => e.Fsu)
                    .HasMaxLength(50)
                    .HasColumnName("fsu");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.Modifiedat).HasColumnName("modifiedat");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Startdate)
                    .HasColumnType("date")
                    .HasColumnName("startdate");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.Trainprogramcode)
                    .HasMaxLength(30)
                    .HasColumnName("trainprogramcode");

                entity.HasOne(d => d.CreatedbyNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.Createdby)
                    .HasConstraintName("class_createdby_fkey");

                entity.HasOne(d => d.TrainprogramcodeNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.Trainprogramcode)
                    .HasConstraintName("class_trainprogramcode_fkey");
            });

            modelBuilder.Entity<ClassUser>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Classid })
                    .HasName("ClassUser_pkey");

                entity.ToTable("ClassUser");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Classid).HasColumnName("classid");

                entity.Property(e => e.Usertype)
                    .HasMaxLength(50)
                    .HasColumnName("usertype");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassUsers)
                    .HasForeignKey(d => d.Classid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClassUser_classid_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ClassUsers)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClassUser_userid_fkey");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permissions");

                entity.Property(e => e.Permissionid)
                    .HasMaxLength(10)
                    .HasColumnName("permissionid");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Permissionrole>(entity =>
            {
                entity.HasKey(e => new { e.Permissionid, e.Roleid })
                    .HasName("permissionrole_pkey");

                entity.ToTable("permissionrole");

                entity.Property(e => e.Permissionid)
                    .HasMaxLength(10)
                    .HasColumnName("permissionid");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Permissionroles)
                    .HasForeignKey(d => d.Permissionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("permissionrole_permissionid_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permissionroles)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("permissionrole_roleid_fkey");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Syllabus>(entity =>
            {
                entity.HasKey(e => e.Topiccode)
                    .HasName("syllabus_pkey");

                entity.ToTable("syllabus");

                entity.Property(e => e.Topiccode)
                    .HasMaxLength(30)
                    .HasColumnName("topiccode");

                entity.Property(e => e.Courseobjective).HasColumnName("courseobjective");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Deliveryprinciple).HasColumnName("deliveryprinciple");

                entity.Property(e => e.Level)
                    .HasMaxLength(30)
                    .HasColumnName("level");

                entity.Property(e => e.Modifiedat).HasColumnName("modifiedat");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Technicalrequirement)
                    .HasMaxLength(255)
                    .HasColumnName("technicalrequirement");

                entity.Property(e => e.Timelocation)
                    .HasMaxLength(30)
                    .HasColumnName("timelocation");

                entity.Property(e => e.Topicname)
                    .HasMaxLength(30)
                    .HasColumnName("topicname");

                entity.Property(e => e.Trainingaudience)
                    .HasMaxLength(50)
                    .HasColumnName("trainingaudience");

                entity.Property(e => e.Version)
                    .HasMaxLength(30)
                    .HasColumnName("version");

                entity.HasOne(d => d.CreatedbyNavigation)
                    .WithMany(p => p.Syllabi)
                    .HasForeignKey(d => d.Createdby)
                    .HasConstraintName("syllabus_createdby_fkey");
            });

            modelBuilder.Entity<TrainingContent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TrainingContent");

                entity.HasIndex(e => e.Unitcode, "TrainingContent_unitcode_key")
                    .IsUnique();

                entity.Property(e => e.Contentname)
                    .HasMaxLength(50)
                    .HasColumnName("contentname");

                entity.Property(e => e.Deliverytype)
                    .HasMaxLength(50)
                    .HasColumnName("deliverytype");

                entity.Property(e => e.Method).HasColumnName("method");

                entity.Property(e => e.Outputstandard)
                    .HasMaxLength(10)
                    .HasColumnName("outputstandard");

                entity.Property(e => e.Trainingtime).HasColumnName("trainingtime");

                entity.Property(e => e.Unitcode)
                    .HasMaxLength(25)
                    .HasColumnName("unitcode");

                entity.HasOne(d => d.UnitcodeNavigation)
                    .WithOne()
                    .HasForeignKey<TrainingContent>(d => d.Unitcode)
                    .HasConstraintName("TrainingContent_unitcode_fkey");
            });

            modelBuilder.Entity<TrainingMaterial>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TrainingMaterial");

                entity.HasIndex(e => e.Unitcode, "TrainingMaterial_unitcode_key")
                    .IsUnique();

                entity.Property(e => e.Fileupload).HasColumnName("fileupload");

                entity.Property(e => e.Unitcode)
                    .HasMaxLength(25)
                    .HasColumnName("unitcode");

                entity.HasOne(d => d.UnitcodeNavigation)
                    .WithOne()
                    .HasForeignKey<TrainingMaterial>(d => d.Unitcode)
                    .HasConstraintName("TrainingMaterial_unitcode_fkey");
            });

            modelBuilder.Entity<TrainingProgramSyllabus>(entity =>
            {
                entity.HasKey(e => new { e.Topiccode, e.Trainingprogramcode })
                    .HasName("TrainingProgramSyllabus_pkey");

                entity.ToTable("TrainingProgramSyllabus");

                entity.Property(e => e.Topiccode)
                    .HasMaxLength(50)
                    .HasColumnName("topiccode");

                entity.Property(e => e.Trainingprogramcode)
                    .HasMaxLength(50)
                    .HasColumnName("trainingprogramcode");

                entity.Property(e => e.Sequence)
                    .HasMaxLength(50)
                    .HasColumnName("sequence");

                entity.HasOne(d => d.TopiccodeNavigation)
                    .WithMany(p => p.TrainingProgramSyllabi)
                    .HasForeignKey(d => d.Topiccode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TrainingProgramSyllabus_topiccode_fkey");

                entity.HasOne(d => d.TrainingprogramcodeNavigation)
                    .WithMany(p => p.TrainingProgramSyllabi)
                    .HasForeignKey(d => d.Trainingprogramcode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TrainingProgramSyllabus_trainingprogramcode_fkey");
            });

            modelBuilder.Entity<TrainingUnit>(entity =>
            {
                entity.HasKey(e => e.Unitcode)
                    .HasName("TrainingUnit_pkey");

                entity.ToTable("TrainingUnit");

                entity.HasIndex(e => e.Topiccode, "TrainingUnit_topiccode_key")
                    .IsUnique();

                entity.Property(e => e.Unitcode)
                    .HasMaxLength(25)
                    .HasColumnName("unitcode");

                entity.Property(e => e.Daynumber).HasColumnName("daynumber");

                entity.Property(e => e.Topiccode)
                    .HasMaxLength(50)
                    .HasColumnName("topiccode");

                entity.Property(e => e.Unitname)
                    .HasMaxLength(50)
                    .HasColumnName("unitname");

                entity.HasOne(d => d.TopiccodeNavigation)
                    .WithOne(p => p.TrainingUnit)
                    .HasForeignKey<TrainingUnit>(d => d.Topiccode)
                    .HasConstraintName("TrainingUnit_topiccode_fkey");
            });

            modelBuilder.Entity<Trainingprogram>(entity =>
            {
                entity.HasKey(e => e.Trainingprogramcode)
                    .HasName("trainingprogram_pkey");

                entity.ToTable("trainingprogram");

                entity.Property(e => e.Trainingprogramcode)
                    .HasMaxLength(30)
                    .HasColumnName("trainingprogramcode");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Duration)
                    .HasMaxLength(30)
                    .HasColumnName("duration");

                entity.Property(e => e.Modifiedat).HasColumnName("modifiedat");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.Topiccode)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("topiccode");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trainingprograms)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("trainingprogram_userid_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(30)
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.Updateat).HasColumnName("updateat");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("users_roleid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
