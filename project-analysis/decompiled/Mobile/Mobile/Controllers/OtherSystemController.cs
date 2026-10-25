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

public class OtherSystemController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> GetShomaranTracingList(int whId, int prdId, string linkAccWhId = "", int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					List<string> list = Enumerable.ToList<string>((IEnumerable<string>)cRMSpEntities.MobspLkShomaranReturnProductTracing(prdId, whId, linkAccWhId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 1;
					for (int i = 0; i < list.Count; i++)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						dropDownItemWithParentId.OrderView = num;
						dropDownItemWithParentId.Title = list[i] ?? "";
						dropDownItemWithParentId.Id = i + 1;
						list2.Add(dropDownItemWithParentId);
						num++;
					}
					data = list2;
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> GetShomaranSefareshCodeList(int whId, int prdId, string linkAccWhId = "", int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					List<string> list = Enumerable.ToList<string>((IEnumerable<string>)cRMSpEntities.MobspLkShomaranReturnProductSefareshCode(prdId, whId, linkAccWhId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 1;
					for (int i = 0; i < list.Count; i++)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						dropDownItemWithParentId.OrderView = num;
						dropDownItemWithParentId.Title = list[i] ?? "";
						dropDownItemWithParentId.Id = i;
						list2.Add(dropDownItemWithParentId);
						num++;
					}
					data = list2;
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
