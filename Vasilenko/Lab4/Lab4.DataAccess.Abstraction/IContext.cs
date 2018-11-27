using Labs4.DataAccess.Entity;
using System;
using System.Linq;

namespace Lab4.DataAccess.Abstraction
{
    public interface IContext : IDisposable
    {
        IQueryable<Post> PostsRepository { get; }

        IQueryable<User> UsersRepository { get; }


        void Save();

        void Add<TEntity>(IQueryable<TEntity> repository, TEntity entity)
            where TEntity : class;

        void Delete<TEntity>(IQueryable<TEntity> repository, TEntity entity)
            where TEntity : class;

    }

}
