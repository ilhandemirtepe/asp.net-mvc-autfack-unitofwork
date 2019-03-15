using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutofacExample.Services
{
    public partial interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> expression);

        T GetById(object id);

        bool Insert(T entity);

        bool Insert(IEnumerable<T> entities);

        bool Update(T entity);

        bool Update(IEnumerable<T> entities);

        bool UpdateNotSave(T entity);

        bool Delete(object id);

        bool Delete(T entity);

        bool Delete(IEnumerable<T> entities);

        long Count(Expression<Func<T, bool>> expression);

        int CountInt(Expression<Func<T, bool>> expression);

        void Save();
    }
}
