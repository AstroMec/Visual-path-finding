using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAssessement
{
    public static class PyFunct
    {
        /// <summary>
        /// This is the same as python's enumerate function. 
        /// </summary>
        /// <param name="item">This is the input list with items of type T.</param>
        /// <param name="start">This is the value at which the python enumeration will start.</param>
        /// <returns>It returns a list of tuples that have their enumeration index and the value itself.</returns>
        public static List<(int, T)> PyEnumerate<T>(T[] item, int start = 0)
        {
            List<(int, T)> to_ret = new List<(int, T)>();

            int index = 0;

            for(int i = start; index < item.Length; i++)
            {
                to_ret.Add((i, item[index]));
                index++;
            }

            return to_ret;
        }
    }
}
