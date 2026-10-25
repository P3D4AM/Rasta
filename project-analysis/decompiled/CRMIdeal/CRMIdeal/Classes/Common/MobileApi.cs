using System;
using CRM.General.Security;
using CRM.Models;
using Elmah;

namespace CRMIdeal.Classes.Common;

public class MobileApi
{
	public MobileApiTokenViewModel GetToken(string token)
	{
		try
		{
			token = CodeDecode.DeCodding(token);
			string[] array = token.Split(new char[1] { '|' });
			int.TryParse(array[3], out var result);
			int.TryParse(array[1], out var result2);
			return new MobileApiTokenViewModel
			{
				RollId = result,
				userId = result2,
				currentDateTime = array[7],
				extra = array[5]
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return null;
		}
	}

	public bool CheckExtra(string extra)
	{
		if (string.IsNullOrEmpty(extra))
		{
			return false;
		}
		return true;
	}
}
