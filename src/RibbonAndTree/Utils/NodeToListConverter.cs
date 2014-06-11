using System;
using Catel.Windows.Data.Converters;
using RibbonAndTree.Models;

namespace RibbonAndTree.Utils
{
    class NodeToListConverter : ValueConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter)
        {
            var node = value as Node;

            if (node == null || node.Data == null) return null;

            return node.Data;
        }
    }
}
