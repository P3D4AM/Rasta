using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.General.Security;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class Mobile
{
	public static string GetToken()
	{
		try
		{
			return Enumerable.FirstOrDefault<string>((IEnumerable<string>)HttpContext.Current.Request.Headers.GetValues("token")) ?? "";
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static int CheckToken(string token)
	{
		int result = 0;
		if (string.IsNullOrWhiteSpace(token))
		{
			return 0;
		}
		try
		{
			token = CodeDecode.DeCodding(token);
			string[] array = token.Split(new char[1] { '|' });
			int.TryParse(array[3], out var _);
			int.TryParse(array[1], out var result3);
			result = result3;
			return result;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return result;
		}
	}
}
