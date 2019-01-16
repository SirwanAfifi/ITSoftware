using System.Collections.Generic;
using System.Linq;
using cmp;

namespace db.Xmls
{
    public class computerSource
    {
        public static List<Cmp> Load()
        {
            MyXmlReader myXmlReader = new MyXmlReader();
            return myXmlReader.procXml(@"C:\All With National Code\").ToList();
        }
    }
}
