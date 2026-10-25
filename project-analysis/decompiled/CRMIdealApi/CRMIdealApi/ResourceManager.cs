using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using CRM.General.Utilities;
using CRMIdealApi.Resources;
using Elmah;

namespace CRMIdealApi;

public class ResourceManager
{
	public string Def_Collation = "fa-IR";

	public string Per_Collation = "fa-IR";

	public string TypeLbl = "Labels";

	public string TypeMsg = "Messages";

	public static List<ResourceManagerData> Generate(List<ResourceManagerData> data, string rsName = "", string rsCollation = "fa-IR", string rsType = "")
	{
		if (data == null)
		{
			data = new List<ResourceManagerData>();
		}
		data.Add(new ResourceManagerData
		{
			RsName = rsName,
			RsCollation = rsCollation,
			RsType = rsType
		});
		return data;
	}

	public string Get(string rsName = "", string rsCollation = "fa-IR", string rsType = "")
	{
		string result = "";
		if (!string.IsNullOrWhiteSpace(rsName) && !string.IsNullOrWhiteSpace(rsCollation) && !string.IsNullOrWhiteSpace(rsType))
		{
			try
			{
				Assembly assembly = null;
				if (rsType == TypeLbl)
				{
					assembly = typeof(Labels).GetTypeInfo().Assembly;
				}
				else if (rsType == TypeMsg)
				{
					assembly = typeof(Messages).GetTypeInfo().Assembly;
				}
				result = MyResource.GetResourceString(rsName.Trim(), rsCollation.Trim(), "CRMIdealApi.Resources." + rsType.Trim(), assembly);
			}
			catch (Exception)
			{
				result = "";
			}
		}
		return result;
	}

	public string GetWithFormat(List<ResourceManagerData> data)
	{
		string text = "";
		try
		{
			if (data != null)
			{
				text = Get(data[0].RsName, data[0].RsCollation, data[0].RsType);
				if (data.Count > 1)
				{
					for (int i = 1; i < data.Count; i++)
					{
						string newValue = Get(data[i].RsName, data[i].RsCollation, data[i].RsType);
						text = text.Replace("{" + (i - 1) + "}", newValue);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public string GetII(string rsName = "", string rsCollation = "fa-IR", string rsType = "", string rsNameI = "", string rsCollationI = "fa-IR", string rsTypeI = "")
	{
		string format = Get(rsName, rsCollation, rsType);
		string arg = Get(rsNameI, rsCollationI ?? rsCollation, rsTypeI ?? rsType);
		return string.Format(format, arg);
	}

	public static string GetMessage(string keyName, int langId)
	{
		string result = keyName;
		try
		{
			result = Messages.ResourceManager.GetString(keyName, new CultureInfo(langId));
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static string GetLabel(string keyName, int langId)
	{
		string result = keyName;
		try
		{
			result = Labels.ResourceManager.GetString(keyName, new CultureInfo(langId));
		}
		catch (Exception)
		{
		}
		return result;
	}
}
