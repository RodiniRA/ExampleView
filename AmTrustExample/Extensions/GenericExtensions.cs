using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace AmTrustExample.Extensions
{
    public static class GenericExtensions
    {

        public static string GetDescription<TEnum>(this TEnum enumerationValue) where TEnum : IComparable, IFormattable, IConvertible //where TEnum : struct //
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum || !type.IsValueType)
            {
                throw new ArgumentException(@"EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0 && attrs.FirstOrDefault(t => t.GetType() == typeof(DescriptionAttribute)) != null)
                {
                    //Pull out the description value. Throws an exception if there is more than one.
                    return ((DescriptionAttribute)attrs.Single(t => t.GetType() == typeof(DescriptionAttribute))).Description;
                }
            }

            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }

        public static T GetParentOfType<T>(this DependencyObject element) where T : DependencyObject
        {
            Type type = typeof(T);
            if (element == null) return null;
            DependencyObject parent = VisualTreeHelper.GetParent(element);
            if (parent == null && ((FrameworkElement)element).Parent is DependencyObject) parent = ((FrameworkElement)element).Parent;
            if (parent == null) return null;
            else if (parent.GetType() == type || parent.GetType().IsSubclassOf(type)) return parent as T;
            return GetParentOfType<T>(parent);
        }
    }
}
