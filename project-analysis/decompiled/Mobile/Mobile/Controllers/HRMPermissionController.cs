using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using Mobile.Cache;
using Mobile.Cache.Setting;
using Mobile.Cache.User;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class HRMPermissionController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HrmPermissionViewModel>> GetPermissionsByFormName(string formName, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HrmPermissionViewModel> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					if (!string.IsNullOrEmpty(formName))
					{
						Info.Update(token2.userId, true);
						Permissions.Update(token2.userId);
						Manager.UpdateAllSettingCach();
						List<HrmPermissionViewModel> list = new List<HrmPermissionViewModel>();
						HrmPermissionViewModel hrmPermissionViewModel = new HrmPermissionViewModel();
						Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
						dictionary = Enumerable.ToDictionary<MobspSelectUserRollPermission_Result, string, bool>(Enumerable.Where<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)Permissions.Get(token2.userId, cId), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result c) => c.FormName == formName)), (Func<MobspSelectUserRollPermission_Result, string>)((MobspSelectUserRollPermission_Result item) => item.ActionName), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result item) => true));
						hrmPermissionViewModel = new HrmPermissionViewModel
						{
							FormName = formName,
							ActionName = dictionary
						};
						list.Add(hrmPermissionViewModel);
						data = list;
						message = Messages.HrmMobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorParamHaveNotCorrectlyInitialized;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HrmPermissionViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
