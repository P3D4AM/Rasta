using System;
using System.Web;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class Logs
{
	public static void LogError(Exception ex, string additionalInfo = null)
	{
		try
		{
			Error error = new Error(ex);
			if (!string.IsNullOrWhiteSpace(additionalInfo))
			{
				error.Message = additionalInfo + " - " + error.Message;
			}
			if (HttpContext.Current != null)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
			}
			else
			{
				ErrorLog.GetDefault(null).Log(error);
			}
		}
		catch (Exception)
		{
		}
	}
}
