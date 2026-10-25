using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CRM.General.Utilities;

public static class PropertiesMapper
{
	public static void Copy(object source, object target, string[] excludedProperties = null)
	{
		Type type = source.GetType();
		Type type2 = target.GetType();
		PropertyInfo[] properties = type.GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (excludedProperties != null && Enumerable.Contains<string>((IEnumerable<string>)excludedProperties, propertyInfo.Name))
			{
				continue;
			}
			Type propertyType = propertyInfo.PropertyType;
			if (!propertyType.IsArray && (Enumerable.Contains<string>((IEnumerable<string>)new string[3] { "System.String", "System.Guid", "System.DateTime" }, propertyType.FullName) || propertyType.IsValueType))
			{
				PropertyInfo property = type2.GetProperty(propertyInfo.Name);
				if (property != null && property.CanWrite)
				{
					object value = propertyInfo.GetValue(source, null);
					property.SetValue(target, value, null);
				}
			}
		}
	}
}
