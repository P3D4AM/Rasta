using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Controllers;

public class SmsAPIController : ApiController
{
	[HttpPost]
	public CommonResultViewModel<List<SmsspGetSMSTankInfo_Result>> GetSMSTankInfo(ApiGetSmsTankInfoViewModel model)
	{
		CRMSpIIEntities cRMSpIIEntities = null;
		List<SmsspGetSMSTankInfo_Result> data = null;
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Fail;
		try
		{
			cRMSpIIEntities = new CRMSpIIEntities();
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result == null)
			{
				return new CommonResultViewModel<List<SmsspGetSMSTankInfo_Result>>
				{
					Message = Messages.errorInReadingSetting,
					Data = null,
					Status = CommonResultStatusViewModel.Error
				};
			}
			int.TryParse(cRMspSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<Languages> list = Language.Get();
			string culture = "fa-IR";
			Languages languages = Enumerable.FirstOrDefault<Languages>((IEnumerable<Languages>)list, (Func<Languages, bool>)((Languages m) => m.LanguageID == currLangId));
			if (languages != null)
			{
				culture = languages.LanguageCollation;
			}
			if (!string.IsNullOrWhiteSpace(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrWhiteSpace(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			if (Enumerable.FirstOrDefault<CRMspReturnUserByUserNameAndPassword_Result>((IEnumerable<CRMspReturnUserByUserNameAndPassword_Result>)cRMSpIIEntities.CRMspReturnUserByUserNameAndPassword(model.UserName, model.Password, currLangId, result)) == null)
			{
				return new CommonResultViewModel<List<SmsspGetSMSTankInfo_Result>>
				{
					Message = MyResource.GetResourceString("msgErrorCheckUsernamePassword", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = CommonResultStatusViewModel.Error
				};
			}
			if (!model.FromDate.HasValue || !model.ToDate.HasValue)
			{
				return new CommonResultViewModel<List<SmsspGetSMSTankInfo_Result>>
				{
					Message = string.Format(MyResource.GetResourceString("msgErrorIsNotSpecified", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Date", culture, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)),
					Data = null,
					Status = CommonResultStatusViewModel.Error
				};
			}
			List<SmsspGetSMSTankInfo_Result> list2 = Enumerable.ToList<SmsspGetSMSTankInfo_Result>((IEnumerable<SmsspGetSMSTankInfo_Result>)cRMSpIIEntities.SmsspGetSMSTankInfo(model.FromDate, model.ToDate, currLangId, result));
			if (list2 != null)
			{
				message = MyResource.GetResourceString("msgSuccessAction", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = CommonResultStatusViewModel.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = CommonResultStatusViewModel.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.msgErrorRunFunction + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = CommonResultStatusViewModel.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return new CommonResultViewModel<List<SmsspGetSMSTankInfo_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public CommonResultViewModel<bool> UpdateSmsSendDetailRefId(ApiUpdateSmsSendDetailRefIdViewModel model)
	{
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		CRMSpEntities cRMSpEntities = null;
		CRMSpIIEntities cRMSpIIEntities = null;
		bool data = false;
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Fail;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			cRMSpIIEntities = new CRMSpIIEntities();
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result == null)
			{
				return new CommonResultViewModel<bool>
				{
					Message = Messages.errorInReadingSetting,
					Data = false,
					Status = CommonResultStatusViewModel.Error
				};
			}
			int.TryParse(cRMspSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<Languages> list = Language.Get();
			string culture = "fa-IR";
			Languages languages = Enumerable.FirstOrDefault<Languages>((IEnumerable<Languages>)list, (Func<Languages, bool>)((Languages m) => m.LanguageID == currLangId));
			if (languages != null)
			{
				culture = languages.LanguageCollation;
			}
			int result2 = 0;
			if (!string.IsNullOrWhiteSpace(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrWhiteSpace(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			CRMspReturnUserByUserNameAndPassword_Result cRMspReturnUserByUserNameAndPassword_Result = Enumerable.FirstOrDefault<CRMspReturnUserByUserNameAndPassword_Result>((IEnumerable<CRMspReturnUserByUserNameAndPassword_Result>)cRMSpIIEntities.CRMspReturnUserByUserNameAndPassword(model.UserName, model.Password, currLangId, result));
			if (cRMspReturnUserByUserNameAndPassword_Result == null)
			{
				return new CommonResultViewModel<bool>
				{
					Message = MyResource.GetResourceString("msgErrorCheckUsernamePassword", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = false,
					Status = CommonResultStatusViewModel.Error
				};
			}
			int.TryParse(cRMspReturnUserByUserNameAndPassword_Result.UserId.ToString(), out result2);
			if (result2 == 0)
			{
				return new CommonResultViewModel<bool>
				{
					Message = MyResource.GetResourceString("msgErrorCheckUsernamePassword", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = false,
					Status = CommonResultStatusViewModel.Error
				};
			}
			if (string.IsNullOrWhiteSpace(model.DetailsJsonFormat))
			{
				return new CommonResultViewModel<bool>
				{
					Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = false,
					Status = CommonResultStatusViewModel.Error
				};
			}
			List<ApiSmsSendDetailRefIdViewModel> list2 = new JavaScriptSerializer().Deserialize<List<ApiSmsSendDetailRefIdViewModel>>(model.DetailsJsonFormat);
			string text = "";
			if (list2 != null && Enumerable.Any<ApiSmsSendDetailRefIdViewModel>((IEnumerable<ApiSmsSendDetailRefIdViewModel>)list2))
			{
				foreach (ApiSmsSendDetailRefIdViewModel item in list2)
				{
					int smsSendDetailId = item.SmsSendDetailId;
					long refId = item.RefId;
					if (smsSendDetailId != 0)
					{
						text = text + smsSendDetailId + "," + refId + "|";
					}
				}
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				return new CommonResultViewModel<bool>
				{
					Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = false,
					Status = CommonResultStatusViewModel.Error
				};
			}
			string appType = CRMIdeal.Classes.Common.Configuration.AppType;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string statusChangeDate = now.ToString("yyyyMMdd", new PersianCulture());
			string statusChangeTime = now.ToString("HH:mm:ss");
			cRMSpEntities.SmsspUpdateSendedDetailStatusAndRefId(text, 0, statusChangeDate, statusChangeTime, appType, value);
			message = MyResource.GetResourceString("msgSuccessAction", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			status = CommonResultStatusViewModel.Success;
			data = true;
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.msgErrorRunFunction + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			data = false;
			status = CommonResultStatusViewModel.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIIEntities?.Dispose();
		}
		return new CommonResultViewModel<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
