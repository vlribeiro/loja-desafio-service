using LojaDesafio.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Business.Infrastructure
{
    public class BusinessFactory
    {
        //Singleton
        private static BusinessFactory _instance;

        private BusinessFactory() { }

        public static BusinessFactory GetInstance()
        {
            if (_instance == null)
                _instance = new BusinessFactory();
            return _instance;
        }

        public GenericBusiness<T> Get<T>() where T : class
        {
            try
            {
                var boType = typeof(T);
                Context context = new Context();

                var bo = (GenericBusiness<T>)this.Get<T>(context);

                return bo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenericBusiness<T> Get<T>(Context context) where T : class
        {
            GenericBusiness<T> business;
            try
            {
                var nameSpace = typeof(GenericBusiness<T>).Namespace;
                Type bussinessType = Type.GetType(String.Format("{0}.{1}Business, {0}", nameSpace, typeof(T).Name), true);
                business = (GenericBusiness<T>)Activator.CreateInstance(bussinessType, new object[] { context });
            }
            catch (System.TypeLoadException)
            {
                business = (GenericBusiness<T>)Activator.CreateInstance(typeof(GenericBusiness<T>), new object[] { context });
            }
            return business;
        }
    }
}
