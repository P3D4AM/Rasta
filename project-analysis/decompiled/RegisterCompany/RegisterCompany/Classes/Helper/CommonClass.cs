using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using RegisterCompany.Models;

namespace RegisterCompany.Classes.Helper;

public class CommonClass
{
	public string ConvertMd5(string input)
	{
		byte[] bytes = Encoding.Default.GetBytes(input);
		return Enumerable.Aggregate<byte, string>((IEnumerable<byte>)new MD5CryptoServiceProvider().ComputeHash(bytes), "", (Func<string, byte, string>)((string current, byte b) => current + b.ToString("X2")));
	}

	public string ConvertNameToDayNum(string dayName)
	{
		return dayName switch
		{
			"Saturday" => "7", 
			"Sunday" => "1", 
			"Monday" => "2", 
			"Tuesday" => "3", 
			"Wednesday" => "4", 
			"Thursday" => "5", 
			"Friday" => "6", 
			_ => dayName ?? "", 
		};
	}

	public static string GetUserName(int userId, int defLangId, int currLangId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispSelectUsers_Result apispSelectUsers_Result = Enumerable.FirstOrDefault<ApispSelectUsers_Result>((IEnumerable<ApispSelectUsers_Result>)cRMEntities.ApispSelectUsers(userId, currLangId, defLangId));
			if (apispSelectUsers_Result != null)
			{
				result = ((!string.IsNullOrEmpty(apispSelectUsers_Result.FullName)) ? apispSelectUsers_Result.FullName : "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}
}
