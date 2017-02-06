using InkHeart.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InkHeart.DALFactory
{
  public  class StaticDalFactory
    {
        public static string assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
        public static IUserDal GetUserDal()
        {

            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserDal") as IUserDal;
            
        }
        public static IBookDal GetBookDal()
        {

            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".BookDal") as IBookDal;
           
        }


    }
}
