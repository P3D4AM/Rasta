using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes.Common;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class UserTasks
{
	[LoginAuthorize]
	public static async Task<string> SendReminderToUserOutlook(string mode = "", UserTasksLanguageViewModel model = null, string jsData = "", string value = "")
	{
		string result = "";
		try
		{
			string iPAddress = Info.Get().IPAddress;
			if (string.IsNullOrWhiteSpace(mode))
			{
				return Messages.msgErrorOperationFailed;
			}
			if (string.IsNullOrWhiteSpace(iPAddress))
			{
				return Messages.msgErrorFieldRequired + "[User/IpAddress]";
			}
			if (model == null && string.IsNullOrWhiteSpace(jsData) && string.IsNullOrWhiteSpace(value))
			{
				return Messages.msgErrorJsonDeserialize;
			}
			if (string.IsNullOrWhiteSpace(jsData) && model != null)
			{
				jsData = JsonConvert.SerializeObject(model);
			}
			if (string.IsNullOrWhiteSpace(jsData) && !string.IsNullOrWhiteSpace(value))
			{
				jsData = value;
			}
			SelectListItem value2 = new SelectListItem
			{
				Text = mode,
				Value = CodeDecode.CoddingUTF8(jsData)
			};
			UdpClient val = new UdpClient();
			IPEndPoint val2 = new IPEndPoint(IPAddress.Parse(iPAddress), 8764);
			byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value2));
			val.Send(bytes, bytes.Length, val2);
			val.Dispose();
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = "Error: " + ex.Message;
		}
		return result;
	}
}
