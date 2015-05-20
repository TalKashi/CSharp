using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class MyUtils
    {
        public static string ListToString<T>(List<T> i_List)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (T item in i_List)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
