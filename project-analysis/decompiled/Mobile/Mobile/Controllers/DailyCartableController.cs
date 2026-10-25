using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class DailyCartableController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItem>> Tree(string date, bool? isShowTicket, int? ln = null, int? cId = null)
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
			if (!UserLogin.IsUserAccess("frmMain", "actcDaily", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<DropDownItem>>
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
					DateTime now = DateTime.Now;
					DateTime now2 = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(date))
						{
							ServiceResult<List<DropDownItem>> result3 = new ServiceResult<List<DropDownItem>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						date = date.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<DropDownItem>> result4 = new ServiceResult<List<DropDownItem>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					try
					{
						if (string.IsNullOrEmpty(date))
						{
							ServiceResult<List<DropDownItem>> result5 = new ServiceResult<List<DropDownItem>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result5;
						}
						date = date.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now2 = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 23:59:59"));
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<List<DropDownItem>> result6 = new ServiceResult<List<DropDownItem>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result6;
					}
					string mobAllUsers = Labels.MobAllUsers;
					List<MobspUserTreeDailyCartable_Result> list = Enumerable.ToList<MobspUserTreeDailyCartable_Result>((IEnumerable<MobspUserTreeDailyCartable_Result>)cRMEntities.MobspUserTreeDailyCartable(token2.userId, 2, now, now2, mobAllUsers, result, result2, isShowTicket, cId));
					List<DropDownItem> list2 = new List<DropDownItem>();
					foreach (MobspUserTreeDailyCartable_Result item in list)
					{
						DropDownItem dropDownItem = new DropDownItem();
						int result7 = 0;
						int.TryParse(item.KeyId.ToString(), out result7);
						dropDownItem.Id = result7;
						dropDownItem.Title = item.KeyName;
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
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
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
	public ServiceResult<List<MobspResultsDailyCartable_Result>> Result(string date, int? usId, bool? isShowTicket, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspResultsDailyCartable_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcDaily", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspResultsDailyCartable_Result>>
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
					DateTime now = DateTime.Now;
					DateTime now2 = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(date))
						{
							ServiceResult<List<MobspResultsDailyCartable_Result>> result3 = new ServiceResult<List<MobspResultsDailyCartable_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						date = date.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspResultsDailyCartable_Result>> result4 = new ServiceResult<List<MobspResultsDailyCartable_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					try
					{
						if (string.IsNullOrEmpty(date))
						{
							ServiceResult<List<MobspResultsDailyCartable_Result>> result5 = new ServiceResult<List<MobspResultsDailyCartable_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result5;
						}
						date = date.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now2 = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 23:59:59"));
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<List<MobspResultsDailyCartable_Result>> result6 = new ServiceResult<List<MobspResultsDailyCartable_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result6;
					}
					if (usId == 0)
					{
						ServiceResult<List<MobspResultsDailyCartable_Result>> result7 = new ServiceResult<List<MobspResultsDailyCartable_Result>>
						{
							Message = Messages.MobMsgErrorUserNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result7;
					}
					data = Enumerable.ToList<MobspResultsDailyCartable_Result>((IEnumerable<MobspResultsDailyCartable_Result>)cRMEntities.MobspResultsDailyCartable(now, now2, token2.userId, result, result2, pageNumber, pageSize, usId, isShowTicket, cId));
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
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspResultsDailyCartable_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
