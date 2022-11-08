using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace PR6.Classes
{
    static class MethodForExportToPDF
    {
        /// <summary>
        /// Интерфейс предназначенный для возвращения элемента, который нужно извлечь
        /// </summary>
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
       where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        /// <summary>
        /// Интерфейс, предназначенный для извлечения элементов из childitem, в нашем случае из конкретных строк DataGrid
        /// </summary>
        /// <param name="obj">Параметр, из которого будут извлекаться данные, допустим, строка DataGrid row</param>
        /// <returns></returns>
        public static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }
            return null;
        }
    }
}
