namespace BlazorApp1.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Student)
                .WithMany(s => s.Registrations)
                .HasForeignKey(r => r.Student_Id);
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Courses)
                .WithMany(c => c.Registrations)
                .HasForeignKey(r => r.Course_Id);
                

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> AllCourses { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
