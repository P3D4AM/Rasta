using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class UserLocationCartableController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItem>> Tree(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItem> data = null;
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
					string mobAllUsers = Labels.MobAllUsers;
					List<MobspUserTreeLocationCartable_Result> list = Enumerable.ToList<MobspUserTreeLocationCartable_Result>((IEnumerable<MobspUserTreeLocationCartable_Result>)cRMEntities.MobspUserTreeLocationCartable(token2.userId, 19, mobAllUsers, result, result2));
					List<DropDownItem> list2 = new List<DropDownItem>();
					foreach (MobspUserTreeLocationCartable_Result item in list)
					{
						DropDownItem dropDownItem = new DropDownItem();
						int result3 = 0;
						int.TryParse(item.KeyId.ToString(), out result3);
						dropDownItem.Id = result3;
						dropDownItem.Title = item.KeyName;
						int orderView = 0;
						dropDownItem.OrderView = orderView;
						list2.Add(dropDownItem);
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
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
		return new ServiceResult<List<DropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspResultsUserLocationCartable_Result>> Result(int usId, int lastHour = 0, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspResultsUserLocationCartable_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcUserLocation", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspResultsUserLocationCartable_Result>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					if (usId == 0)
					{
						ServiceResult<List<MobspResultsUserLocationCartable_Result>> result3 = new ServiceResult<List<MobspResultsUserLocationCartable_Result>>
						{
							Message = Messages.MobMsgErrorUserNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					List<MobspResultsUserLocationCartable_Result> list = ((usId != -1) ? Enumerable.ToList<MobspResultsUserLocationCartable_Result>(Enumerable.Where<MobspResultsUserLocationCartable_Result>((IEnumerable<MobspResultsUserLocationCartable_Result>)cRMEntities.MobspResultsUserLocationCartable(token2.userId, lastHour, result, result2), (Func<MobspResultsUserLocationCartable_Result, bool>)((MobspResultsUserLocationCartable_Result m) => m.UserId == usId))) : Enumerable.ToList<MobspResultsUserLocationCartable_Result>((IEnumerable<MobspResultsUserLocationCartable_Result>)cRMEntities.MobspResultsUserLocationCartable(token2.userId, lastHour, result, result2)));
					data = list;
					message = "";
					status = ServiceResultStatus.Success;
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
		return new ServiceResult<List<MobspResultsUserLocationCartable_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
