using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PWDataGrid
{
    public static class IEnumerableExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            ObservableCollection<T> collection = new ObservableCollection<T>();

            foreach (T item in source)
            {
                collection.Add(item);
            }

            return collection;

        }

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source != null && source.Any())
            {
                return true;
            }

            return false;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null || !source.Any())
            {
                return true;
            }

            return false;
        }
    }
}
