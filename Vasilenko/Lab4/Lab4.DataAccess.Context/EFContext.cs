using Lab4.DataAccess.Abstraction;
using Labs4.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lab4.DataAccess.Context
{
    public class EFContext : DbContext, IContext
        {
            public EFContext(DbContextOptions<EFContext> options) : base(options) { }

            public DbSet<Post> Posts { get; set; }

            public DbSet<User> Users { get; set; }


            public IQueryable<Post> PostsRepository => this.Posts;

            public IQueryable<User> UsersRepository => this.Users;

            public void Save()
            {
                SaveChanges();
            }

            public void Add<TEntity>(IQueryable<TEntity> repository, TEntity entity)
                where TEntity : class
            {
                (repository as DbSet<TEntity>).Add(entity);
            }

            public void Delete<TEntity>(IQueryable<TEntity> repository, TEntity entity)
                where TEntity : class
            {
                (repository as DbSet<TEntity>).Remove(entity);
            }
        }
}
