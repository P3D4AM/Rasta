using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class UserLocationDetailsController : ApiController
{
	[HttpPost]
	public ServiceResult<string> InsertUserMovementTracking(int userId, string latitude, string longitude, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result2 > 0) ? result2 : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (userId == 0)
			{
				ServiceResult<string> result3 = new ServiceResult<string>
				{
					Message = Messages.MobMsgErrorUserNotSelected,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
				cRMEntities?.Dispose();
				return result3;
			}
			if (string.IsNullOrEmpty(latitude))
			{
				ServiceResult<string> result4 = new ServiceResult<string>
				{
					Message = Messages.MobMsgErrorLatitudeNotEntered,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
				cRMEntities?.Dispose();
				return result4;
			}
			if (string.IsNullOrEmpty(longitude))
			{
				ServiceResult<string> result5 = new ServiceResult<string>
				{
					Message = Messages.MobMsgErrorLongitudeNotEntered,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
				cRMEntities?.Dispose();
				return result5;
			}
			cRMEntities = new CRMEntities();
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Mobile.Classes.Configuration.AppType;
			if (cRMEntities.MobspInsertUpdateUserMovementTracking(latitude, longitude, userId, value2, value3, value, registerDatePersian, appType, result) >= 1)
			{
				data = null;
				message = Messages.MobMsgSuccessAction;
				status = ServiceResultStatus.Success;
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorDoneOperation;
				status = ServiceResultStatus.Fail;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<SelectUserMovementTrackingResultViewModel> SelectUserMovementTracking(SelectUserMovementTrackingViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result2 > 0) ? result2 : result);
		baseInfo.SetCulture(culture);
		SelectUserMovementTrackingResultViewModel selectUserMovementTrackingResultViewModel;
		try
		{
			cRMEntities = new CRMEntities();
			selectUserMovementTrackingResultViewModel = new SelectUserMovementTrackingResultViewModel();
			selectUserMovementTrackingResultViewModel.Tracking = new List<MobspSelectUserMovementTracking_Result>();
			selectUserMovementTrackingResultViewModel.Polygon = new List<MobspSelectUserMovementTrackingPolygonWithPolygonUserId_Result>();
			List<MobspSelectUserMovementTracking_Result> list = Enumerable.ToList<MobspSelectUserMovementTracking_Result>((IEnumerable<MobspSelectUserMovementTracking_Result>)cRMEntities.MobspSelectUserMovementTracking(model.UserIds, model.FromDate, toDate: model.ToDate, fromTime: model.FromTime, toTime: model.ToTime, languageID: result, defaultLanguageID: result2));
			if (list != null && Enumerable.Any<MobspSelectUserMovementTracking_Result>((IEnumerable<MobspSelectUserMovementTracking_Result>)list))
			{
				selectUserMovementTrackingResultViewModel.Tracking = list;
			}
			if (model.ShowPolygon)
			{
				List<MobspSelectUserMovementTrackingPolygonWithPolygonUserId_Result> list2 = Enumerable.ToList<MobspSelectUserMovementTrackingPolygonWithPolygonUserId_Result>((IEnumerable<MobspSelectUserMovementTrackingPolygonWithPolygonUserId_Result>)cRMEntities.MobspSelectUserMovementTrackingPolygonWithPolygonUserId(model.UserIds, result, result2));
				if (list2 != null && Enumerable.Any<MobspSelectUserMovementTrackingPolygonWithPolygonUserId_Result>((IEnumerable<MobspSelectUserMovementTrackingPolygonWithPolygonUserId_Result>)list2))
				{
					selectUserMovementTrackingResultViewModel.Polygon = list2;
				}
			}
			message = Messages.MobMsgSuccessAction;
			status = ServiceResultStatus.Success;
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			selectUserMovementTrackingResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<SelectUserMovementTrackingResultViewModel>
		{
			Message = message,
			Data = selectUserMovementTrackingResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> InsertMultiUserMovementTracking(InsertMultiUserMovementTrackingViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result2 > 0) ? result2 : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (model.UserId == 0)
			{
				ServiceResult<string> result3 = new ServiceResult<string>
				{
					Message = Messages.MobMsgErrorUserNotSelected,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
				cRMEntities?.Dispose();
				return result3;
			}
			cRMEntities = new CRMEntities();
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Mobile.Classes.Configuration.AppType;
			foreach (List<UserMovementTrackingRecordViewModel> item in Enumerable.ToList<List<UserMovementTrackingRecordViewModel>>(Enumerable.Select<IGrouping<DateTime, UserMovementTrackingRecordViewModel>, List<UserMovementTrackingRecordViewModel>>(Enumerable.GroupBy<UserMovementTrackingRecordViewModel, DateTime>((IEnumerable<UserMovementTrackingRecordViewModel>)Enumerable.ToList<UserMovementTrackingRecordViewModel>((IEnumerable<UserMovementTrackingRecordViewModel>)JsonConvert.DeserializeObject<List<UserMovementTrackingRecordViewModel>>(model.RecordJson)), (Func<UserMovementTrackingRecordViewModel, DateTime>)((UserMovementTrackingRecordViewModel payment) => payment.dateTime.Date)), (Func<IGrouping<DateTime, UserMovementTrackingRecordViewModel>, List<UserMovementTrackingRecordViewModel>>)((IGrouping<DateTime, UserMovementTrackingRecordViewModel> group) => Enumerable.ToList<UserMovementTrackingRecordViewModel>((IEnumerable<UserMovementTrackingRecordViewModel>)group)))))
			{
				DateTime dateTime = Enumerable.First<UserMovementTrackingRecordViewModel>((IEnumerable<UserMovementTrackingRecordViewModel>)item).dateTime;
				DateTime value3 = dateTime;
				string registerDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
				List<UserMovementTrackingCoordinateViewModel> list = new List<UserMovementTrackingCoordinateViewModel>();
				foreach (UserMovementTrackingRecordViewModel item2 in item)
				{
					UserMovementTrackingCoordinateViewModel userMovementTrackingCoordinateViewModel = new UserMovementTrackingCoordinateViewModel();
					userMovementTrackingCoordinateViewModel.lat = item2.latitude.ToString();
					userMovementTrackingCoordinateViewModel.@long = item2.longitude.ToString();
					userMovementTrackingCoordinateViewModel.time = item2.dateTime.ToString("HH:mm:ss");
					list.Add(userMovementTrackingCoordinateViewModel);
				}
				string coordinateJson = JsonConvert.SerializeObject(list);
				cRMEntities.MobspInsertUpdateMultiUserMovementTracking(coordinateJson, model.UserId, value, value2, value3, registerDatePersian, appType, result);
			}
			message = Messages.MobMsgSuccessAction;
			status = ServiceResultStatus.Success;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
