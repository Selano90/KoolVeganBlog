using KoolVeganBlog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KoolVeganBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<MainComment> MainComments { get; set; }
        public virtual DbSet<SubComment> SubComment { get; set; }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostTag>().HasKey(pt => new { pt.PostId, pt.TagId });
            modelBuilder.Entity<PostTag>().HasOne(pt => pt.Post).WithMany(pt => pt.PostTags)
                .HasForeignKey(p => p.PostId);
            modelBuilder.Entity<PostTag>().HasOne(pt => pt.Tag).WithMany(pt => pt.PostTags)
                .HasForeignKey(p => p.TagId);
        }
    }
}

