using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DataLib
{
    public class Repository<T> : IRepository<T>, IDisposable
        where T : class
    {
        private HomeMediaDBContext m_dbContext;
        private DbSet<T> m_dbSet;


        /// <summary>
        /// Default Constractor
        /// </summary>
        public Repository()
        {
            m_dbContext = new HomeMediaDBContext();
            m_dbSet = m_dbContext.Set<T>();
        }


        /// <summary>
        /// Return Entity for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return m_dbSet.Find(id);
        }
        /// <summary>
        /// Add new Entity
        /// </summary>
        /// <param name="oneObject"></param>
        /// <returns></returns>
        public bool Insert(T oneObject)
        {
            bool OK;
            try
            {
                m_dbSet.Add(oneObject);
                this.Save();
                OK = true;
            }
            catch (Exception)
            {
                //Just for test It tack long time and than get Ex????? 
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                OK = false;
            }
            return OK;
        }
        /// <summary>
        /// Update Assignment3
        /// Return IQuerable collection according to Lambda Expression.
        /// This methos using Func<> delegation type, take T as parameter and return bool.
        /// I used func<> and not Action<> because i need to return typ- IQuerable list.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> Select(Expression<Func<T, bool>> predicate)
        {
            return m_dbSet.Where(predicate);
        }
        /// <summary>
        /// Return a Iquerablecollection for DbSet
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Select()
        {
            return m_dbSet;
        }
        /// <summary>
        /// Delete Selected Entity
        /// </summary>
        /// <param name="oneObject"></param>
        /// <returns></returns>
        public bool Delete(T oneObject)
        {
            bool Ok;
            try
            {
                m_dbSet.Remove(oneObject);
                this.Save();
                Ok = true;
            }
            catch (Exception)
            {
                Ok = false;
            }
            return Ok;
        }
        /// <summary>
        /// Delete Entity for a given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            bool OK;
            object obj = m_dbSet.Find(id);
            try
            {
                Delete((T)obj);
                OK = true;
            }
            catch (Exception)
            {
                OK = false;
            }
            return OK;
        }

        /// <summary>
        /// Save Db Change
        /// </summary>
        public void Save()
        {
            m_dbContext.SaveChanges();
        }

        /// <summary>
        /// Dispose Resource.
        /// </summary>
        public void Dispose()
        {
            if (m_dbContext != null)
                m_dbContext.Dispose();
        }
    }
}
