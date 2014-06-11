using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using RibbonAndTree.Models;

namespace RibbonAndTree.Utils
{
    public class TreeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = value as Node;
            if (item != null)
            {
                return item.Owner.Where(i => i.ParentId == item.Id);
            }
            
            var items = value as IEnumerable<Node>;
            if (items != null)
            {
                return items.Where(i => i.ParentId == 0);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
