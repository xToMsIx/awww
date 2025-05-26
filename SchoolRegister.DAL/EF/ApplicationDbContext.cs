using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectGroup> SubjectGroups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(); // lazy loading włączony
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dziedziczenie użytkowników z dyskryminatorem
            modelBuilder.Entity<User>()
                .ToTable("AspNetUsers")
                .HasDiscriminator<int>("UserType")
                .HasValue<User>((int)RoleValue.User)
                .HasValue<Student>((int)RoleValue.Student)
                .HasValue<Parent>((int)RoleValue.Parent)
                .HasValue<Teacher>((int)RoleValue.Teacher);

            // Konfiguracja klucza złożonego dla SubjectGroup
            modelBuilder.Entity<SubjectGroup>()
                .HasKey(sg => new { sg.SubjectId, sg.GroupId });

            // Konfiguracja relacji SubjectGroup ↔ Subject
            modelBuilder.Entity<SubjectGroup>()
                .HasOne(sg => sg.Subject)
                .WithMany(s => s.SubjectGroups)
                .HasForeignKey(sg => sg.SubjectId);

            // Konfiguracja relacji SubjectGroup ↔ Group
            modelBuilder.Entity<SubjectGroup>()
                .HasOne(sg => sg.Group)
                .WithMany(g => g.SubjectGroups)
                .HasForeignKey(sg => sg.GroupId);
        }
    }
}
