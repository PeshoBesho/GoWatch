using GoWatch.Data.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Data.Repositories.Abstractions
{
    public interface ICrudRepository<T> where T : BaseEntity
    {
        //Crud operations with the DB


        //Add
        public Task AddAsync(T entity);
        public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);

        //GetAll
        public Task<IEnumerable<T>> GetAllAsync();

        //GetById
        public Task<T> GetByIdAsync(int id);

        //Update
        public Task UpdateAsync(T entity);

        //Delete
        public Task DeleteByIdAsync(int id);
    }
}
