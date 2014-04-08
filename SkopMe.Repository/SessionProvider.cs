using NHibernate;
using NHibernate.Cfg;

namespace SkopMe.Repositories
{
    /// <summary>
    /// Class to initialize the Session provider for Hibernate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SessionProvider<T> where T : new()
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(T).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
