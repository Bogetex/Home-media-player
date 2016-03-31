/// Method from IRepository project package
/// I Install package to project and update the method than uninstall it.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public interface IRepository<T> where T:class
    {
        bool Delete(T oneObject);

        //long Delete(IQueryable<T> objects);

        //bool DeleteAll();

        //bool Exists(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        //T GetSingle(Expression<Func<T, bool>> predicate);

        bool Insert(T oneObject);

        //IQueryable<T> Insert(IQueryable<T> objects);

        //bool InsertOrUpdate(T oneObject);

        //IQueryable<T> InsertOrUpdate(IEnumerable<T> objects);

        IQueryable<T> Select(Expression<Func<T, bool>> predicate);

        IQueryable<T> Select();

        void Save();

    }
}
