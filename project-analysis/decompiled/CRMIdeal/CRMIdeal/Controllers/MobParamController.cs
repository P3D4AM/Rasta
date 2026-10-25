using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.TimeAttendance.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Controllers;

[MobParamAuthorize]
public class MobParamController : Controller
{
	private int _UserId;

	public int UserId
	{
		get
		{
			if (_UserId == 0)
			{
				_UserId = CRMIdeal.Classes.Helper.Mobile.CheckToken(CRMIdeal.Classes.Helper.Mobile.GetToken());
			}
			return _UserId;
		}
	}

	[HttpPost]
	public string Check(MobParamViewModel model)
	{
		_ = base.Request.UserHostAddress;
		CRMSpIEntities cRMSpIEntities = null;
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			int value = ((!model.Ln.HasValue) ? new int?(0) : model.Ln).Value;
			cRMSpIEntities = new CRMSpIEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int culture = ((value > 0) ? value : result);
			new BaseInfo().SetCulture(culture);
			string text = "";
			if (Enumerable.Contains<string>((IEnumerable<string>)base.Request.Headers.AllKeys, "token"))
			{
				text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.Headers.GetValues("token"));
			}
			if (text != "")
			{
				string text2 = "";
				text2 = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.Headers.GetValues("imeiCode"));
				string text3 = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.Headers.GetValues("appName"));
				if ((text2 ?? "") != "" && (text3 ?? "") != "" && !CRMIdeal.Classes.Helper.User.CheckUserImeiCode(UserId, text2, text3))
				{
					return JsonConvert.SerializeObject(new ServiceResult<string>
					{
						Message = Messages.MobMsgUserImeiNotPreDefined,
						Data = "",
						Status = ServiceResultStatus.Fail
					});
				}
				bool flag = true;
				double result2 = 0.0;
				bool flag2 = false;
				bool flag3 = false;
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null && model.Mode.GetValueOrDefault() == 0)
				{
					flag2 = cRMspSelectCrmsysSetting_Result.CheckLocForScanQR.GetValueOrDefault();
					flag3 = cRMspSelectCrmsysSetting_Result.CheckLocForScanQRInMission.GetValueOrDefault();
					if (flag2 || flag3)
					{
						flag = false;
						result2 = cRMspSelectCrmsysSetting_Result.UserLoginAccessDistance.GetValueOrDefault();
						if (!model.Lat.HasValue && !model.Lng.HasValue)
						{
							return JsonConvert.SerializeObject(new ServiceResult<string>
							{
								Message = Messages.msgErrorGettingCurrentLocation,
								Data = "changeMode",
								Status = ServiceResultStatus.Fail
							});
						}
						if (flag2)
						{
							double result3 = 0.0;
							double result4 = 0.0;
							CRMspLoadUserLoginInfoViewModel cRMspLoadUserLoginInfoViewModel = Info.Get(UserId);
							if (cRMspLoadUserLoginInfoViewModel != null)
							{
								List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
								if (cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocationType.GetValueOrDefault() == 2 && (cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocations ?? "") != "")
								{
									list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocations);
								}
								else if (cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocationType.GetValueOrDefault() != 2 && (cRMspSelectCrmsysSetting_Result.CoLocations ?? "") != "")
								{
									list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(cRMspSelectCrmsysSetting_Result.CoLocations);
								}
								foreach (Dictionary<string, string> item in list)
								{
									double.TryParse(item["lat"], out result3);
									double.TryParse(item["lng"], out result4);
									double.TryParse(item["AccessDistance"], out result2);
									if (result3 != 0.0 && result4 != 0.0)
									{
										if (Public.GetDistance(result4, result3, model.Lng.GetValueOrDefault(), model.Lat.GetValueOrDefault()) <= result2)
										{
											flag = true;
										}
									}
									else
									{
										message = Messages.MsgCoLocationNotDefined;
										data = "";
										status = ServiceResultStatus.Fail;
									}
								}
							}
						}
						if (!flag && flag3)
						{
							foreach (CRMspSelectSmartTimeAttendanceMission_Result item2 in Enumerable.ToList<CRMspSelectSmartTimeAttendanceMission_Result>((IEnumerable<CRMspSelectSmartTimeAttendanceMission_Result>)cRMSpIEntities.CRMspSelectSmartTimeAttendanceMission(UserId)))
							{
								double result5 = 0.0;
								double result6 = 0.0;
								double.TryParse(item2.PlaceCoordinateLatitude, out result5);
								double.TryParse(item2.PlaceCoordinateLongitude, out result6);
								if (result5 != 0.0 && result6 != 0.0 && Public.GetDistance(result6, result5, model.Lng.GetValueOrDefault(), model.Lat.GetValueOrDefault()) <= result2)
								{
									flag = true;
									break;
								}
							}
						}
					}
				}
				if (flag)
				{
					MobParamViewModel mobParamViewModel = JsonConvert.DeserializeObject<MobParamViewModel>(XorCipher.DecryptByPrivateKey(model.Value));
					mobParamViewModel.ST = model.ST;
					mobParamViewModel.SIP = base.Request.UserHostAddress;
					mobParamViewModel.SRDT = model.SRDT;
					mobParamViewModel.SSDT = DateTime.Now;
					mobParamViewModel.SUId = model.SUId;
					mobParamViewModel.CId = model.CId;
					mobParamViewModel.Lat = model.Lat;
					mobParamViewModel.Lng = model.Lng;
					mobParamViewModel.Zoom = model.Zoom;
					mobParamViewModel.Mode = model.Mode;
					data = JsonConvert.SerializeObject(new MainParamController().Check(mobParamViewModel));
					message = Messages.msgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = ((flag2 && !flag3) ? string.Format(Messages.msgNotInCompanyAreaToScanQrCode, result2) : ((!(!flag2 && flag3)) ? string.Format(Messages.msgNotInCompanyOrMissionAreaToScanQrCode, result2) : string.Format(Messages.msgNotInMissionAreaToScanQrCode, result2)));
					data = "changeMode";
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				message = Messages.msgErrorAccessingToken;
				data = "";
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.msgErrorRunFunction;
			data = "";
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return JsonConvert.SerializeObject(new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		});
	}

	[HttpPost]
	public string CheckWithOutScan(MobParamViewModel model)
	{
		_ = base.Request.UserHostAddress;
		CRMSpIEntities cRMSpIEntities = null;
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			int value = ((!model.Ln.HasValue) ? new int?(0) : model.Ln).Value;
			cRMSpIEntities = new CRMSpIEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int culture = ((value > 0) ? value : result);
			new BaseInfo().SetCulture(culture);
			string text = "";
			if (Enumerable.Contains<string>((IEnumerable<string>)base.Request.Headers.AllKeys, "token"))
			{
				text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.Headers.GetValues("token"));
			}
			if (text != "")
			{
				string text2 = "";
				text2 = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.Headers.GetValues("imeiCode"));
				string text3 = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.Headers.GetValues("appName"));
				if ((text2 ?? "") != "" && (text3 ?? "") != "" && !CRMIdeal.Classes.Helper.User.CheckUserImeiCode(UserId, text2, text3))
				{
					return JsonConvert.SerializeObject(new ServiceResult<string>
					{
						Message = Messages.MobMsgUserImeiNotPreDefined,
						Data = "",
						Status = ServiceResultStatus.Fail
					});
				}
				bool flag = true;
				double result2 = 0.0;
				bool flag2 = false;
				bool flag3 = false;
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null && model.Mode.GetValueOrDefault() == 0)
				{
					flag2 = cRMspSelectCrmsysSetting_Result.CheckLocForScanQR.GetValueOrDefault();
					flag3 = cRMspSelectCrmsysSetting_Result.CheckLocForScanQRInMission.GetValueOrDefault();
					if (flag2 || flag3)
					{
						flag = false;
						result2 = cRMspSelectCrmsysSetting_Result.UserLoginAccessDistance.GetValueOrDefault();
						if (!model.Lat.HasValue && !model.Lng.HasValue)
						{
							return JsonConvert.SerializeObject(new ServiceResult<string>
							{
								Message = Messages.msgErrorGettingCurrentLocation,
								Data = "changeMode",
								Status = ServiceResultStatus.Fail
							});
						}
						if (flag2)
						{
							double result3 = 0.0;
							double result4 = 0.0;
							CRMspLoadUserLoginInfoViewModel cRMspLoadUserLoginInfoViewModel = Info.Get(UserId);
							if (cRMspLoadUserLoginInfoViewModel != null)
							{
								List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
								if (cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocationType.GetValueOrDefault() == 2 && (cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocations ?? "") != "")
								{
									list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocations);
								}
								else if (cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocationType.GetValueOrDefault() != 2 && (cRMspSelectCrmsysSetting_Result.CoLocations ?? "") != "")
								{
									list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(cRMspSelectCrmsysSetting_Result.CoLocations);
								}
								foreach (Dictionary<string, string> item in list)
								{
									double.TryParse(item["lat"], out result3);
									double.TryParse(item["lng"], out result4);
									double.TryParse(item["AccessDistance"], out result2);
									if (result3 != 0.0 && result4 != 0.0)
									{
										if (Public.GetDistance(result4, result3, model.Lng.GetValueOrDefault(), model.Lat.GetValueOrDefault()) <= result2)
										{
											flag = true;
										}
									}
									else
									{
										message = Messages.MsgCoLocationNotDefined;
										data = "";
										status = ServiceResultStatus.Fail;
									}
								}
							}
						}
						if (!flag && flag3)
						{
							foreach (CRMspSelectSmartTimeAttendanceMission_Result item2 in Enumerable.ToList<CRMspSelectSmartTimeAttendanceMission_Result>((IEnumerable<CRMspSelectSmartTimeAttendanceMission_Result>)cRMSpIEntities.CRMspSelectSmartTimeAttendanceMission(UserId)))
							{
								double result5 = 0.0;
								double result6 = 0.0;
								double.TryParse(item2.PlaceCoordinateLatitude, out result5);
								double.TryParse(item2.PlaceCoordinateLongitude, out result6);
								if (result5 != 0.0 && result6 != 0.0 && Public.GetDistance(result6, result5, model.Lng.GetValueOrDefault(), model.Lat.GetValueOrDefault()) <= result2)
								{
									flag = true;
									break;
								}
							}
						}
					}
				}
				if (flag)
				{
					data = ((!model.IsEntry.GetValueOrDefault()) ? new CRMIdeal.Areas.TimeAttendance.Controllers.HomeController().LogTimeAttendanceExit(model.ShiftWorkingTimeId, model.LeaveId, model.LeaveStepIds, model.SIP, model.SUId, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), model.AddLeavesIds, model.AppType, model.Lat, model.Lng, zoom: null, isTemp: (model.Mode.GetValueOrDefault() == 0) ? null : new bool?(true)) : new CRMIdeal.Areas.TimeAttendance.Controllers.HomeController().LogTimeAttendanceEntry(model.ShiftWorkingTimeId, model.LeaveId, model.LeaveStepIds, model.SIP, model.SUId, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), model.AddLeavesIds, model.AppType, model.ClearTimeAttendanceIds, model.Lat, model.Lng, zoom: null, isTemp: (model.Mode.GetValueOrDefault() == 0) ? null : new bool?(true)));
					message = Messages.msgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = ((flag2 && !flag3) ? string.Format(Messages.msgNotInCompanyAreaToScanQrCode, result2) : ((!(!flag2 && flag3)) ? string.Format(Messages.msgNotInCompanyOrMissionAreaToScanQrCode, result2) : string.Format(Messages.msgNotInMissionAreaToScanQrCode, result2)));
					data = "changeMode";
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				message = Messages.msgErrorAccessingToken;
				data = "";
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.msgErrorRunFunction;
			data = "";
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return JsonConvert.SerializeObject(new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		});
	}
}
