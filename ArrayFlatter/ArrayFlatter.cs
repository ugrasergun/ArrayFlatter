using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayFlatter
{
    public class ArrayFlatter
    {
        public static int[] FlatArray(object[] nestedArray)
        {
            if (nestedArray == null)
                return null;
            List<int> flatArray = new List<int>();
            foreach (var nestedItem in nestedArray)
            {
                if (nestedItem is int)
                {
                    flatArray.Add((int)nestedItem);
                }
                else if (nestedItem is object[])
                {
                    flatArray.AddRange(FlatArray((object[])nestedItem));
                }
                else
                {
                    throw new ArgumentException("Non-integer value in array!");
                }
            }
            return flatArray.ToArray();
        }
    }
}
