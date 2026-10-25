using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using CRM.Models;
using CRMIdeal.Classes.Helper;
using Elmah;
using Microsoft.AspNet.SignalR;

namespace CRMIdeal.Hubs;

public class MyHub : Hub
{
	private static readonly object _lock = new object();

	public void send(int userid)
	{
		lock (_lock)
		{
			base.Clients.All.broadcastMessage(DoJob());
		}
	}

	public string DoJob()
	{
		string text = "";
		int result = 0;
		IIdentity identity = base.Context.Request.GetHttpContext().User.Identity;
		if (identity != null)
		{
			int.TryParse(identity.Name, out result);
		}
		if (result > 0)
		{
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
			try
			{
				int num = 0;
				num = User.GetUserLastCId(result, 1065, 1065);
				int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)cRMSpEntities.CRMspIntMsgGetUnReadMessge(result, num)));
				CRMspIntMsgGetUnReadVerify_Result cRMspIntMsgGetUnReadVerify_Result = Enumerable.FirstOrDefault<CRMspIntMsgGetUnReadVerify_Result>((IEnumerable<CRMspIntMsgGetUnReadVerify_Result>)Enumerable.ToList<CRMspIntMsgGetUnReadVerify_Result>((IEnumerable<CRMspIntMsgGetUnReadVerify_Result>)cRMSpEntities.CRMspIntMsgGetUnReadVerify(result, num)));
				int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpIIEntities.CRMspGetUnReadSmsReceiveCnt()).GetValueOrDefault();
				if (num2.HasValue)
				{
					int? num3 = num2;
					text = num3 + "|";
				}
				else
				{
					text = "0|";
				}
				if (cRMspIntMsgGetUnReadVerify_Result != null && cRMspIntMsgGetUnReadVerify_Result.Cnt.HasValue)
				{
					text = text + cRMspIntMsgGetUnReadVerify_Result.Cnt + "|";
					text = text + cRMspIntMsgGetUnReadVerify_Result.msgdTypeId + "|";
					text = text + cRMspIntMsgGetUnReadVerify_Result.InternalMessageID + "|";
				}
				else
				{
					text += "0|0|0|";
				}
				text += valueOrDefault;
				text = text + "|" + result;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMSpEntities.Dispose();
				cRMSpIIEntities.Dispose();
			}
		}
		return text;
	}
}
