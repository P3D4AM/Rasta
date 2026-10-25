using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes.Common;
using CRMIdeal.Hubs;
using Newtonsoft.Json;

namespace CRMIdeal.Controllers;

public class MainParamController : Controller
{
	private const string _TAD_QRCode = "tadQRCode";

	private const string _TAD_QRCodeExit = "tadQRCodeExit";

	public AdvanceResultItemViewModel Check(ParamViewModel p)
	{
		AdvanceResultItemViewModel advanceResultItemViewModel = new AdvanceResultItemViewModel();
		if (p != null)
		{
			if (p.KeyName == "tadQRCode")
			{
				ChatHub.SendData(p.KeyName, JsonConvert.SerializeObject(p));
				advanceResultItemViewModel.Status = CommonResultStatusViewModel.Success;
			}
			else if (p.KeyName == "tadQRCodeExit")
			{
				LoginUserSmartTimeAttendanceViewModel loginUserSmartTimeAttendanceViewModel = null;
				if (p.SUId.GetValueOrDefault() != 0 && p.GUId.GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(p.KeyValue))
				{
					loginUserSmartTimeAttendanceViewModel = UserLoginSmartTimeAttendance.Get(p.GUId.GetValueOrDefault());
				}
				if (loginUserSmartTimeAttendanceViewModel != null && p.GUId.GetValueOrDefault() != 0)
				{
					string text = SysSeting.Get().LoginAuthUrl ?? "";
					if (!string.IsNullOrWhiteSpace(text) && !text.Contains(p.SDomain))
					{
						advanceResultItemViewModel.Errors.Add(Messages.MobMsgErrorNotInLoginAuthUrl);
						return advanceResultItemViewModel;
					}
					string text2 = loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceMainQRCode ?? "";
					if (text2.Trim() != "" && text2 == p.KeyValue)
					{
						UserLoginSmartTimeAttendance.Update(p.GUId.GetValueOrDefault(), "", "true", JsonConvert.SerializeObject(p));
						advanceResultItemViewModel.Status = CommonResultStatusViewModel.Success;
					}
					else
					{
						advanceResultItemViewModel.Errors.Add(Messages.MsgErrorDoneOperationTryAgain);
					}
				}
			}
		}
		else
		{
			advanceResultItemViewModel.Errors.Add(Messages.msgErrorOperationNotFound);
			Public.InsTextToElmah("Cheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeck|External Request|Data:" + JsonConvert.SerializeObject(p) + "|pp:" + base.Request.UserHostAddress);
		}
		return advanceResultItemViewModel;
	}
}
