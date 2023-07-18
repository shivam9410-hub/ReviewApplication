using Microsoft.EntityFrameworkCore;
using myreviewapplication.Models;

namespace myreviewapplication
{
    public class MyDbContext :DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<User>Users { get; set; }   
        public DbSet<Product>Products { get; set; }
        public DbSet<Comment>Comments { get; set; }     
    }
}
