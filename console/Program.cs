using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using db.Xmls;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            MyXmlReader myXmlReader = new MyXmlReader();

            var list = myXmlReader.procXml(@"C:\All With National Code\");

            WriteToCsv(list);
        }

        public static void WriteToCsv<T>(IEnumerable<T> data)
        {
            var strBuilder = new StringBuilder();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                strBuilder.Append(prop.DisplayName); // header
                strBuilder.Append(",");
            }
            strBuilder.AppendLine();
            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    strBuilder.Append(prop.Converter.ConvertToString(
                        prop.GetValue(item)));
                    strBuilder.Append(",");
                }
                strBuilder.AppendLine();
            }

            File.WriteAllText(@"C:\Users\Sirwan\Desktop\list2.csv", strBuilder.ToString());
        }
    }

    public static class Helper
    {
        public static IDictionary<string, object> ToDictionary(this object data)
        {
            var attr = BindingFlags.Public | BindingFlags.Instance;
            var dict = new Dictionary<string, object>();
            foreach (var property in data.GetType().GetProperties(attr))
            {
                if (property.CanRead)
                {
                    dict.Add(property.Name, property.GetValue(data, null));
                }
            }
            return dict;
        }
    }
}
