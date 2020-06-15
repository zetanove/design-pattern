using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonThreadSafe
    {
        private static SingletonThreadSafe theInstance = null;
        private static readonly object objSync = new object();

        SingletonThreadSafe()
        {
        }

        public static SingletonThreadSafe GetInstance()
        {

            lock (objSync)
            {
                if (theInstance == null)
                {
                    theInstance = new SingletonThreadSafe();
                }
                return theInstance;
            }

        }

    }
}
