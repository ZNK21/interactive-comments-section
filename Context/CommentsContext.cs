using interactive_comments_section.Entities;
using Microsoft.EntityFrameworkCore;

namespace interactive_comments_section.Context {
    public class CommentsContext : DbContext {
        public CommentsContext(DbContextOptions options) : base(options) { }
        public DbSet <View_All> View_All { get; set; }
    }
}
