using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CRMIdeal.Classes.Helper.TspApi;

public class JsonHelper
{
	public static Dictionary<string, object> DeserializeAndFlatten(string json)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		JToken token = JToken.ReadFrom(new JsonTextReader(new StringReader(json)));
		FillDictionaryFromJToken(dictionary, token, "");
		return dictionary;
	}

	private static void FillDictionaryFromJToken(Dictionary<string, object> dict, JToken token, string prefix)
	{
		switch (token.Type)
		{
		case JTokenType.Object:
		{
			foreach (JProperty item in token.Children<JProperty>())
			{
				FillDictionaryFromJToken(dict, item.Value, Join(prefix, item.Name));
			}
			break;
		}
		case JTokenType.Array:
		{
			int num = 0;
			{
				foreach (JToken item2 in token.Children())
				{
					FillDictionaryFromJToken(dict, item2, Join(prefix, num.ToString()));
					num++;
				}
				break;
			}
		}
		default:
			dict.Add(prefix, ((JValue)token).Value);
			break;
		}
	}

	private static string Join(string prefix, string name)
	{
		if (!string.IsNullOrEmpty(prefix))
		{
			return prefix + "." + name;
		}
		return name;
	}
}
