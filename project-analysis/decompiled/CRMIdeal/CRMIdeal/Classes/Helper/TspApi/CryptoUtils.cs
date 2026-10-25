using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper.TspApi;

public class CryptoUtils
{
	public static byte[] StringToByteArray(string hex)
	{
		return Enumerable.ToArray<byte>(Enumerable.Select<int, byte>(Enumerable.Where<int>(Enumerable.Range(0, hex.Length), (Func<int, bool>)((int x) => x % 2 == 0)), (Func<int, byte>)((int x) => Convert.ToByte(hex.Substring(x, 2), 16))));
	}

	public static string NormalJson(object obj, Dictionary<string, string> header)
	{
		if (obj == null && header == null)
		{
			throw new AccessViolationException();
		}
		Dictionary<string, object> dictionary = null;
		if (obj != null)
		{
			if (obj.GetType() == typeof(string))
			{
				obj = ((!obj.ToString().Trim().StartsWith("[")) ? JsonConvert.DeserializeObject<object>((string)obj) : ToList<object>((string)obj));
			}
			dictionary = ((!obj.GetType().IsGenericType || !(obj.GetType().GetGenericTypeDefinition() == typeof(List<>))) ? ToDictionary<object>(obj) : ToDictionary<object>(new PacketsWrapper((IList)obj)));
		}
		if (dictionary == null && header != null)
		{
			dictionary = new Dictionary<string, object>();
			foreach (KeyValuePair<string, string> item in header)
			{
				dictionary.Add(item.Key, item.Value.ToString());
			}
		}
		if (dictionary != null && header != null)
		{
			foreach (KeyValuePair<string, string> item2 in header)
			{
				dictionary.Add(item2.Key, item2.Value);
			}
		}
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		dictionary2 = JsonHelper.DeserializeAndFlatten(JsonConvert.SerializeObject(dictionary));
		StringBuilder stringBuilder = new StringBuilder();
		HashSet<string> val = new HashSet<string>((IEnumerable<string>)dictionary2.Keys);
		if (val == null || !Enumerable.Any<string>((IEnumerable<string>)val))
		{
			return null;
		}
		foreach (string item3 in Enumerable.ToList<string>((IEnumerable<string>)Enumerable.OrderBy<string, string>((IEnumerable<string>)val, (Func<string, string>)((string x) => x))))
		{
			string text;
			if (dictionary2.TryGetValue(item3, out var value))
			{
				if (value != null)
				{
					text = ((!value.Equals(true) && !value.Equals(false) && !value.ToString().Equals("False") && !value.ToString().Equals("True")) ? value.ToString() : value.ToString().ToLower());
					text = ((text != null && !text.Equals("")) ? text.Replace("#", "##") : "#");
				}
				else
				{
					text = "#";
				}
			}
			else
			{
				text = "#";
			}
			stringBuilder.Append(text).Append('#');
		}
		return stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
	}

	private static string getKey(string rootKey, string myKey)
	{
		if (rootKey != null)
		{
			return rootKey + "." + myKey;
		}
		return myKey;
	}

	public static Dictionary<string, TValue> ToDictionary<TValue>(object obj)
	{
		return JsonConvert.DeserializeObject<Dictionary<string, TValue>>(JsonConvert.SerializeObject(obj));
	}

	public static List<Dictionary<string, object>> ToList<TValue>(string obj)
	{
		return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(obj);
	}
}
