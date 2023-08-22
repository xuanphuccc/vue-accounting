using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class AttributeGetter
    {
        /// <summary>
        /// Lấy giá trị của thuộc tính DisplayName để hiển thị
        /// </summary>
        /// <param name="property">PropertyInfo</param>
        /// <returns>Tên hiển thị</returns>
        /// CreatedBy: txphuc (23/07/2023)
        public static string GetDisplayNameAttribute(PropertyInfo property)
        {
            var atts = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);

            if (atts.Length > 0)
            {
                // Ép kiểu phần tử đầu tiên về DisplayNameAttribute
                //var displayNameAttribute = atts.FirstOrDefault() as DisplayNameAttribute;
                if (atts.FirstOrDefault() is DisplayNameAttribute displayNameAttribute)
                {
                    return displayNameAttribute.DisplayName;
                }
                else
                {
                    return property.Name;
                }
            }

            return property.Name;
        }

        /// <summary>
        /// Lấy giá trị của thuộc tính Display để hiển thị đa ngôn ngữ
        /// </summary>
        /// <param name="property">PropertyInfo</param>
        /// <returns>Tên hiển thị theo ngôn ngữ</returns>
        /// CreatedBy: txphuc (23/07/2023)
        public static string GetDisplayAttribute(PropertyInfo property)
        {
            var atts = property.GetCustomAttributes(typeof(DisplayAttribute), true);

            if (atts.Length > 0)
            {
                // Ép kiểu phần tử đầu tiên về DisplayAttribute
                if (atts.FirstOrDefault() is DisplayAttribute displayNameAttribute)
                {
                    // Lấy ra giá trị của Name
                    var displayName = displayNameAttribute.GetName();

                    if (displayName != null)
                    {
                        return displayName;
                    }
                }
            }

            return property.Name;
        }
    }
}
