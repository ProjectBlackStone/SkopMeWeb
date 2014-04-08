using NHibernate;
using NHibernate.Cfg;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace SkopMe.Repositories
{
    /// <summary>
    /// Base Repository for All repositories.
    /// This class will initialize the Session for hibernate for each Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> where T : new()
    {
        //protected ISession _session = SessionProvider<T>.OpenSession();
        protected ISession _session = GetSession();

        //Define the session factory, this is per database 
        static ISessionFactory _sessionFactory;

        /// <summary> 
        /// Method to create session and manage entities 
        /// </summary> 
        /// <returns></returns> 
        static ISession GetSession()
        {
            if (_sessionFactory == null)
            {
                
                var configuration = new Configuration();
                var data = configuration.Configure
                                    (
                                        HttpContext.Current
                                        .Server.MapPath(@"~/App_Data/Configurations/hibernate.cfg.xml")
                                        //Assembly.GetExecutingAssembly(),
                                        //"SkopMe.Repositories.hibernate.cfg.xml"
                                    );
                configuration.AddDirectory(
                                    new System.IO.DirectoryInfo
                                    (
                                        HttpContext.Current
                                        .Server.MapPath(@"~/App_Data/Configurations/Mappings"))
                                    );
                _sessionFactory = data.BuildSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }


        public T GetByID(int id)
        {
            return _session.Get<T>(id);
        }

        public ICollection<T> GetAll()
        {
            var products = _session
                .CreateCriteria(typeof(T))
                .List<T>();
            return products;
        }

        public void Update(T toUpdate)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Update(toUpdate);
                transaction.Commit();
            }
        }

        public void Add(T toAdd)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Save(toAdd);
                transaction.Commit();
            }
        }

        public void Remove(T toRemove)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(toRemove);
                transaction.Commit();
            }
        }

        public void Dispose()
        {
            _session.Close();
            _session.Dispose();
        }
    }
}
