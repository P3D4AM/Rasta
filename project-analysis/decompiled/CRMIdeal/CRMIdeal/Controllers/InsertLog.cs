using System;
using System.Globalization;
using System.IO;
using System.Web.Hosting;
using CRM.General.IO;

namespace CRMIdeal.Controllers;

public class InsertLog
{
	public static void InsTextToLog(string text = "")
	{
		if (!string.IsNullOrWhiteSpace(text))
		{
			string text2 = HostingEnvironment.MapPath("/App_Data/IVRLogs/");
			string path = text2 + DateTime.Now.ToString("yyyyMMdd", new CultureInfo("en-US")) + ".log";
			if (!System.IO.Directory.Exists(text2))
			{
				System.IO.Directory.CreateDirectory(text2);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
			}
			if (System.IO.Directory.Exists(text2))
			{
				System.IO.File.AppendAllText(path, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US")) + "]\t" + text + Environment.NewLine);
			}
		}
	}

	public static void InsExceptToLog(Exception ex = null)
	{
		if (ex != null)
		{
			InsTextToLog(ex.Message);
		}
	}
}
