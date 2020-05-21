using Core.WareHouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Core.Helper
{
    public static class EnumsHelper
    {
        // ref: https://www.codingame.com/playgrounds/2487/c---how-to-display-friendly-names-for-enumerations
        // [Attribute]Display v.s. DisplayName 
        /// <summary>
        /// 取得DisplayAttribute的Name值
        /// </summary>
        /// <param name="enu"></param>
        /// <returns></returns>
        public static string GetName(this Enum enu)
        {
            var attr = GetDisplayAttribute(enu);
            return attr != null ? attr.GetName() : enu.ToString();
        }
        /// <summary>
        /// 取得DisplayAttribute的Description值
        /// </summary>
        /// <param name="enu"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enu)
        {
            var attr = GetDisplayAttribute(enu);
            return attr != null ? attr.GetDescription() : enu.ToString();
        }

        private static DisplayAttribute GetDisplayAttribute(object value)
        {
            Type type = value.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException(string.Format("Type {0} is not an enum", type));
            }

            // Get the enum field.
            var field = type.GetField(value.ToString());
            return field == null ? null : field.GetCustomAttribute<DisplayAttribute>();
        }
    }
}
