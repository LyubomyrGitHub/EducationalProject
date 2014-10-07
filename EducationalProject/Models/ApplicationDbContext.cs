using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EducationalProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<TestInProgres> TestsInProgres { get; set; }
        public DbSet<TestResults> TestsResults { get; set; }
        public DbSet<TestHistory> TestHistory { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionWithVariants> QuestionWithVariants { get; set; }
        public DbSet<VariantAnswer> VariantAnswers { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookSection> BookSections { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .HasKey(x => x.TestId)
                .HasMany(e => e.Questions)
                .WithOptional(s => s.Test)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<QuestionWithVariants>()
                .HasKey(x => x.QuestionWithVariantsId)
                .HasMany(e => e.VariantAnswers)
                .WithOptional(s => s.QuestionWithVariants)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Book>()
                .HasRequired<BookSection>(s => s.BookSection)
                .WithMany(s => s.BookList)
                .HasForeignKey(s => s.BookSectionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}