using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace model
{
    public static class Exts
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
        {
            var c = new ObservableCollection<T>();
            foreach (var e in coll)
                c.Add(e);
            return c;
        }
    }
}
