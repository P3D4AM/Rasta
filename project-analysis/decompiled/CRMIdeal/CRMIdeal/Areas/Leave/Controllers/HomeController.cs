using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Leave.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_1
	{
		public WSspSelectVerificationRequestDetails_Result item;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private const int _LeaveTypeId_HourlyLeave = 1;

	private const int _LeaveTypeId_DailyLeave = 2;

	private const int _LeaveTypeId_HourlyMission = 3;

	private const int _LeaveTypeId_DailyMission = 4;

	[LoginAuthorize]
	public ActionResult Index(int lt = 0)
	{
		base.ViewBag.LeaveTypeId = lt;
		base.ViewBag.LeaveTypesList = SelectLeaveType_SelectListItem(lt);
		base.ViewBag.CrmUsersList = GetUsers(UserLogin.CurrentUser.UserId);
		return View();
	}

	[LoginAuthorize]
	public ActionResult InsertEdit(int leaveId = 0, int? leaveTypeId = null)
	{
		CrmLeaveInsertEditLanguageViewModel crmLeaveInsertEditLanguageViewModel = new CrmLeaveInsertEditLanguageViewModel();
		crmLeaveInsertEditLanguageViewModel.LeaveTypeId = leaveTypeId;
		crmLeaveInsertEditLanguageViewModel.RequestUserId = UserLogin.CurrentUser.UserId;
		crmLeaveInsertEditLanguageViewModel.RequestUser = UserLogin.CurrentUser.FullName;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		try
		{
			if (leaveId != 0)
			{
				CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, leaveId, null, null, null, null, lCID, defLangID, null, result));
				if (cRMspSelectLeave_Result != null)
				{
					List<CrmLeave> list = JsonConvert.DeserializeObject<List<CrmLeave>>(cRMspSelectLeave_Result.LeaveLang);
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					list2.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = defLangID,
						Value = cRMspSelectLeave_Result.Reason
					});
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					list3.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = defLangID,
						Value = cRMspSelectLeave_Result.Place
					});
					if (list != null)
					{
						list2.AddRange(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLeave, CommonMultiLanguageViewModel>((IEnumerable<CrmLeave>)list, (Func<CrmLeave, CommonMultiLanguageViewModel>)((CrmLeave x) => new CommonMultiLanguageViewModel
						{
							LanguageId = x.LanguageID.GetValueOrDefault(),
							Value = x.Reason
						}))));
						list3.AddRange(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLeave, CommonMultiLanguageViewModel>((IEnumerable<CrmLeave>)list, (Func<CrmLeave, CommonMultiLanguageViewModel>)((CrmLeave x) => new CommonMultiLanguageViewModel
						{
							LanguageId = x.LanguageID.GetValueOrDefault(),
							Value = x.Place
						}))));
					}
					crmLeaveInsertEditLanguageViewModel.LeaveId = cRMspSelectLeave_Result.LeaveId;
					crmLeaveInsertEditLanguageViewModel.LeaveType = cRMspSelectLeave_Result.LeaveType;
					crmLeaveInsertEditLanguageViewModel.RequestUserId = cRMspSelectLeave_Result.RequestUserId;
					crmLeaveInsertEditLanguageViewModel.ReplaceUserId = cRMspSelectLeave_Result.ReplaceUserId;
					crmLeaveInsertEditLanguageViewModel.ReplaceUser = cRMspSelectLeave_Result.ReplaceUser;
					crmLeaveInsertEditLanguageViewModel.RequestUser = cRMspSelectLeave_Result.RequestUser;
					crmLeaveInsertEditLanguageViewModel.FromTime = cRMspSelectLeave_Result.FromTime;
					crmLeaveInsertEditLanguageViewModel.ToTime = cRMspSelectLeave_Result.ToTime;
					crmLeaveInsertEditLanguageViewModel.HourCount = cRMspSelectLeave_Result.HourCount;
					crmLeaveInsertEditLanguageViewModel.Reason = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == defLangID)).Value;
					crmLeaveInsertEditLanguageViewModel.Reason_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != defLangID))));
					crmLeaveInsertEditLanguageViewModel.KindId = cRMspSelectLeave_Result.KindId;
					crmLeaveInsertEditLanguageViewModel.StayTypeId = cRMspSelectLeave_Result.StayTypeId;
					crmLeaveInsertEditLanguageViewModel.VehicleTypeId = cRMspSelectLeave_Result.VehicleTypeId;
					crmLeaveInsertEditLanguageViewModel.Place = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == defLangID)).Value;
					crmLeaveInsertEditLanguageViewModel.Place_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != defLangID))));
					crmLeaveInsertEditLanguageViewModel.CompanyId = cRMspSelectLeave_Result.CompanyId;
					crmLeaveInsertEditLanguageViewModel.Company = cRMspSelectLeave_Result.Company;
					crmLeaveInsertEditLanguageViewModel.CountryId = cRMspSelectLeave_Result.CountryId;
					crmLeaveInsertEditLanguageViewModel.ProvinceId = cRMspSelectLeave_Result.ProvinceId;
					crmLeaveInsertEditLanguageViewModel.CityId = cRMspSelectLeave_Result.CityId;
					crmLeaveInsertEditLanguageViewModel.PlaceCoordinateLatitude = cRMspSelectLeave_Result.PlaceCoordinateLatitude;
					crmLeaveInsertEditLanguageViewModel.PlaceCoordinateLongitude = cRMspSelectLeave_Result.PlaceCoordinateLongitude;
					crmLeaveInsertEditLanguageViewModel.PlaceCoordinateZoomLevel = cRMspSelectLeave_Result.PlaceCoordinateZoomLevel;
					crmLeaveInsertEditLanguageViewModel.LeaveTypeId = cRMspSelectLeave_Result.LeaveTypeId;
					crmLeaveInsertEditLanguageViewModel.FromDateTime = cRMspSelectLeave_Result.FromDateTime;
					crmLeaveInsertEditLanguageViewModel.FromDate = cRMspSelectLeave_Result.FromDate;
					crmLeaveInsertEditLanguageViewModel.ToDateTime = cRMspSelectLeave_Result.ToDateTime;
					crmLeaveInsertEditLanguageViewModel.ToDate = cRMspSelectLeave_Result.ToDate;
					crmLeaveInsertEditLanguageViewModel.DayCount = cRMspSelectLeave_Result.DayCount;
					crmLeaveInsertEditLanguageViewModel.LeaveStatusId = cRMspSelectLeave_Result.LeaveStatusId;
					crmLeaveInsertEditLanguageViewModel.FromDate = crmLeaveInsertEditLanguageViewModel.FromDateTime?.ToString("yyyy/MM/dd");
					crmLeaveInsertEditLanguageViewModel.ToDate = crmLeaveInsertEditLanguageViewModel.ToDateTime?.ToString("yyyy/MM/dd");
					crmLeaveInsertEditLanguageViewModel.DailyDateTimeInfo = cRMspSelectLeave_Result.DailyDateTimeInfo;
					crmLeaveInsertEditLanguageViewModel.StepGroupId = cRMspSelectLeave_Result.StepGroupId;
					crmLeaveInsertEditLanguageViewModel.ProjectId = cRMspSelectLeave_Result.ProjectId;
					crmLeaveInsertEditLanguageViewModel.CompanyPersonId = cRMspSelectLeave_Result.CompanyPersonId;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.ReplaceUsers = GetReplaceUsers_SelectListItem(crmLeaveInsertEditLanguageViewModel.RequestUserId.GetValueOrDefault(), crmLeaveInsertEditLanguageViewModel.ReplaceUserId.GetValueOrDefault());
		base.ViewBag.LeaveKinds = GetLeaveKinds_SelectListItem(crmLeaveInsertEditLanguageViewModel.KindId.GetValueOrDefault());
		base.ViewBag.LeaveStayTypes = GetLeaveStayType_SelectListItem(crmLeaveInsertEditLanguageViewModel.StayTypeId.GetValueOrDefault());
		base.ViewBag.LeaveVehicleTypes = GetLeaveVehicleType_SelectListItem(crmLeaveInsertEditLanguageViewModel.VehicleTypeId.GetValueOrDefault());
		base.ViewBag.LeaveStepGroups = GetLeaveStepGroup_SelectListItem(crmLeaveInsertEditLanguageViewModel.StepGroupId.GetValueOrDefault());
		base.ViewBag.CountriesListJs = GetCountryJs();
		try
		{
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(crmLeaveInsertEditLanguageViewModel.RequestUserId.GetValueOrDefault());
			if (cRMspSelectUsersById_Result != null)
			{
				crmLeaveInsertEditLanguageViewModel.UserDepartment = cRMspSelectUsersById_Result.Department ?? "";
				crmLeaveInsertEditLanguageViewModel.UserResponsible = cRMspSelectUsersById_Result.ResponsibleUser ?? "";
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		string persianDate_YyyyMmDd = DateTime.Now.ToString("yyyy/MM/01");
		persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
		DateTime value = lCID switch
		{
			1065 => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new PersianCulture()), 
			1025 => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("ar-SA")), 
			_ => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("en-US")), 
		};
		persianDate_YyyyMmDd = DateTime.Parse(DateTime.Now.AddMonths(1).ToString("yyyy/MM/01")).AddDays(-1.0).ToString("yyyy/MM/dd");
		persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
		DateTime value2 = lCID switch
		{
			1065 => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new PersianCulture()), 
			1025 => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("ar-SA")), 
			_ => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("en-US")), 
		};
		persianDate_YyyyMmDd = DateTime.Now.ToString("yyyy/01/01");
		persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
		DateTime value3 = lCID switch
		{
			1065 => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new PersianCulture()), 
			1025 => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("ar-SA")), 
			_ => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("en-US")), 
		};
		persianDate_YyyyMmDd = DateTime.Parse(DateTime.Now.AddYears(1).ToString("yyyy/01/01")).AddDays(-1.0).ToString("yyyy/MM/dd");
		persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
		DateTime value4 = lCID switch
		{
			1065 => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new PersianCulture()), 
			1025 => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("ar-SA")), 
			_ => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("en-US")), 
		};
		CRMspReturnLeaveSummary_Result cRMspReturnLeaveSummary_Result = Enumerable.FirstOrDefault<CRMspReturnLeaveSummary_Result>((IEnumerable<CRMspReturnLeaveSummary_Result>)_dbI.CRMspReturnLeaveSummary(crmLeaveInsertEditLanguageViewModel.LeaveTypeId, crmLeaveInsertEditLanguageViewModel.RequestUserId, value, value2, value3, value4));
		int valueOrDefault = cRMspReturnLeaveSummary_Result.MonthlyDailySum.GetValueOrDefault();
		int valueOrDefault2 = cRMspReturnLeaveSummary_Result.MonthlyHourlySumInMin.GetValueOrDefault();
		_ = cRMspReturnLeaveSummary_Result.MonthlyHourlySumTxt;
		int valueOrDefault3 = cRMspReturnLeaveSummary_Result.YearlyDailySum.GetValueOrDefault();
		int valueOrDefault4 = cRMspReturnLeaveSummary_Result.YearlyHourlySumInMin.GetValueOrDefault();
		_ = cRMspReturnLeaveSummary_Result.YearlyHourlySumTxt;
		cRMspReturnLeaveSummary_Result.TotallyDailySum.GetValueOrDefault();
		cRMspReturnLeaveSummary_Result.TotallyHourlySumInMin.GetValueOrDefault();
		_ = cRMspReturnLeaveSummary_Result.TotallyHourlySumTxt;
		string text = "";
		string text2 = "";
		if (valueOrDefault > 0)
		{
			text = valueOrDefault + " " + Labels.lblDay;
		}
		if (valueOrDefault2 > 0)
		{
			if (!string.IsNullOrEmpty(text))
			{
				text = text + " " + Labels.lblAnd + " ";
			}
			text += DateTimeClass.ConvertMinToHourAndMin(valueOrDefault2);
		}
		base.ViewBag.MonthlyLeaveStr = text;
		if (valueOrDefault3 > 0)
		{
			text2 = valueOrDefault3 + " " + Labels.lblDay;
		}
		if (valueOrDefault4 > 0)
		{
			if (!string.IsNullOrEmpty(text2))
			{
				text2 = text2 + " " + Labels.lblAnd + " ";
			}
			text2 += DateTimeClass.ConvertMinToHourAndMin(valueOrDefault4);
		}
		base.ViewBag.YearlyLeaveStr = text2;
		return View(crmLeaveInsertEditLanguageViewModel);
	}

	[AjaxOnly]
	[HttpPost]
	[LoginAuthorize]
	public JsonResult InsertEdit(string parameters)
	{
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0849: Unknown result type (might be due to invalid IL or missing references)
		//IL_0891: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		int num = 0;
		try
		{
			if (!VersionBuyer.Leave)
			{
				DbSet<CrmLeave> crmLeave = _dbTbl.CrmLeave;
				ParameterExpression val = Expression.Parameter(typeof(CrmLeave), "c");
				if (Queryable.Any<CrmLeave>((IQueryable<CrmLeave>)crmLeave, Expression.Lambda<Func<CrmLeave, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)5, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					commonReturnResultViewModel.Message = string.Format(Messages.VersionBuyWithCount, 5);
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
			}
			if (!string.IsNullOrEmpty(parameters))
			{
				DateTime dateTime = default(DateTime);
				string text = "";
				CrmHourlyMissionInsertEditLanguageViewModel crmHourlyMissionInsertEditLanguageViewModel = new JavaScriptSerializer().Deserialize<CrmHourlyMissionInsertEditLanguageViewModel>(parameters);
				if (crmHourlyMissionInsertEditLanguageViewModel.LeaveTypeId.GetValueOrDefault() == 1 || crmHourlyMissionInsertEditLanguageViewModel.LeaveTypeId.GetValueOrDefault() == 3)
				{
					if (string.IsNullOrEmpty(crmHourlyMissionInsertEditLanguageViewModel.RequestDate))
					{
						commonReturnResultViewModel.Message = Messages.msgErrorLeaveRequestDateNotEntered;
						commonReturnResultViewModel.IsDone = false;
						num++;
					}
					if (string.IsNullOrEmpty(crmHourlyMissionInsertEditLanguageViewModel.FromTime))
					{
						commonReturnResultViewModel.Message = Messages.msgErrorLeaveFromTimeNotEntered;
						commonReturnResultViewModel.IsDone = false;
						num++;
					}
					if (string.IsNullOrEmpty(crmHourlyMissionInsertEditLanguageViewModel.ToTime))
					{
						commonReturnResultViewModel.Message = Messages.msgErrorLeaveToTimeNotEntered;
						commonReturnResultViewModel.IsDone = false;
						num++;
					}
					try
					{
						string text2 = "00:00:00";
						if (!string.IsNullOrEmpty(crmHourlyMissionInsertEditLanguageViewModel.RequestDate))
						{
							text2 = crmHourlyMissionInsertEditLanguageViewModel.FromTime + ":00";
						}
						text = PersianDate.GetFormatetdDate(crmHourlyMissionInsertEditLanguageViewModel.RequestDate.Replace("/", ""));
						dateTime = lCID switch
						{
							1065 => DateTime.Parse(text + " " + text2, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text2, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text2, new CultureInfo("en-US")), 
						};
						crmHourlyMissionInsertEditLanguageViewModel.FromDateTime = dateTime;
						crmHourlyMissionInsertEditLanguageViewModel.FromDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						commonReturnResultViewModel.Message = Messages.ErrorFormatTime;
						commonReturnResultViewModel.IsDone = false;
						num++;
					}
					try
					{
						string text3 = "00:00:00";
						if (!string.IsNullOrEmpty(crmHourlyMissionInsertEditLanguageViewModel.RequestDate))
						{
							text3 = crmHourlyMissionInsertEditLanguageViewModel.ToTime + ":00";
						}
						text = PersianDate.GetFormatetdDate(crmHourlyMissionInsertEditLanguageViewModel.RequestDate.Replace("/", ""));
						dateTime = lCID switch
						{
							1065 => DateTime.Parse(text + " " + text3, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text3, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text3, new CultureInfo("en-US")), 
						};
						crmHourlyMissionInsertEditLanguageViewModel.ToDateTime = dateTime;
						crmHourlyMissionInsertEditLanguageViewModel.ToDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						commonReturnResultViewModel.Message = Messages.ErrorFormatTime;
						commonReturnResultViewModel.IsDone = false;
						num++;
					}
					TimeSpan? timeSpan = crmHourlyMissionInsertEditLanguageViewModel.ToDateTime - crmHourlyMissionInsertEditLanguageViewModel.FromDateTime;
					crmHourlyMissionInsertEditLanguageViewModel.HourCount = timeSpan?.Hours.ToString("00") + ":" + timeSpan?.Minutes.ToString("00");
				}
				else if (crmHourlyMissionInsertEditLanguageViewModel.LeaveTypeId.GetValueOrDefault() == 2 || crmHourlyMissionInsertEditLanguageViewModel.LeaveTypeId.GetValueOrDefault() == 4)
				{
					if (string.IsNullOrEmpty(crmHourlyMissionInsertEditLanguageViewModel.FromDate))
					{
						commonReturnResultViewModel.Message = Messages.msgErrorLeaveFromTimeNotEntered;
						commonReturnResultViewModel.IsDone = false;
						num++;
					}
					if (string.IsNullOrEmpty(crmHourlyMissionInsertEditLanguageViewModel.ToDate))
					{
						commonReturnResultViewModel.Message = Messages.msgErrorLeaveToTimeNotEntered;
						commonReturnResultViewModel.IsDone = false;
						num++;
					}
					try
					{
						string text4 = "00:00:00";
						text = PersianDate.GetFormatetdDate(crmHourlyMissionInsertEditLanguageViewModel.FromDate.Replace("/", ""));
						dateTime = lCID switch
						{
							1065 => DateTime.Parse(text + " " + text4, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text4, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text4, new CultureInfo("en-US")), 
						};
						crmHourlyMissionInsertEditLanguageViewModel.FromDateTime = dateTime;
						crmHourlyMissionInsertEditLanguageViewModel.FromDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
						commonReturnResultViewModel.Message = Messages.ErrorFormatTime;
						commonReturnResultViewModel.IsDone = false;
						num++;
					}
					try
					{
						string text5 = "23:59:59";
						text = PersianDate.GetFormatetdDate(crmHourlyMissionInsertEditLanguageViewModel.ToDate.Replace("/", ""));
						dateTime = lCID switch
						{
							1065 => DateTime.Parse(text + " " + text5, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text5, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text5, new CultureInfo("en-US")), 
						};
						crmHourlyMissionInsertEditLanguageViewModel.ToDateTime = dateTime;
						crmHourlyMissionInsertEditLanguageViewModel.ToDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e4)
					{
						ErrorSignal.FromCurrentContext().Raise(e4);
						commonReturnResultViewModel.Message = Messages.ErrorFormatTime;
						commonReturnResultViewModel.IsDone = false;
						num++;
					}
					crmHourlyMissionInsertEditLanguageViewModel.DayCount = (crmHourlyMissionInsertEditLanguageViewModel.ToDateTime.Value - crmHourlyMissionInsertEditLanguageViewModel.FromDateTime.Value).Days + 1;
				}
				else
				{
					commonReturnResultViewModel.Message = Messages.msgErrorLeaveTypeNotFound;
					commonReturnResultViewModel.IsDone = false;
					num++;
				}
				if ((crmHourlyMissionInsertEditLanguageViewModel.LeaveTypeId.GetValueOrDefault() == 2 || crmHourlyMissionInsertEditLanguageViewModel.LeaveTypeId.GetValueOrDefault() == 4) && crmHourlyMissionInsertEditLanguageViewModel.FromDateTime.Value.Date > crmHourlyMissionInsertEditLanguageViewModel.ToDateTime.Value.Date)
				{
					commonReturnResultViewModel.Message = Messages.MsgStartDateCanNotBeAfterToDate;
					commonReturnResultViewModel.IsDone = false;
					num++;
				}
				if (!string.IsNullOrWhiteSpace(commonReturnResultViewModel.Message))
				{
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				if (crmHourlyMissionInsertEditLanguageViewModel.ProjectId <= 0)
				{
					crmHourlyMissionInsertEditLanguageViewModel.ProjectId = null;
				}
				if (crmHourlyMissionInsertEditLanguageViewModel.CompanyPersonId <= 0)
				{
					crmHourlyMissionInsertEditLanguageViewModel.CompanyPersonId = null;
				}
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(crmHourlyMissionInsertEditLanguageViewModel.Reason_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(crmHourlyMissionInsertEditLanguageViewModel.Reason_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = crmHourlyMissionInsertEditLanguageViewModel.Reason,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(crmHourlyMissionInsertEditLanguageViewModel.Reason_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(crmHourlyMissionInsertEditLanguageViewModel.Reason_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmHourlyMissionInsertEditLanguageViewModel.Place,
					LanguageId = lCID
				});
				crmHourlyMissionInsertEditLanguageViewModel.Reason = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				crmHourlyMissionInsertEditLanguageViewModel.Place = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				List<LeaveMultiLanguageViewModel> list3 = new List<LeaveMultiLanguageViewModel>();
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
				{
					LeaveMultiLanguageViewModel leaveMultiLanguageViewModel = new LeaveMultiLanguageViewModel();
					leaveMultiLanguageViewModel.LanguageId = lang.LanguageID;
					leaveMultiLanguageViewModel.Reason = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
					leaveMultiLanguageViewModel.Place = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
					list3.Add(leaveMultiLanguageViewModel);
				}
				crmHourlyMissionInsertEditLanguageViewModel.MsgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list3));
				if (crmHourlyMissionInsertEditLanguageViewModel.LeaveId != 0)
				{
					crmHourlyMissionInsertEditLanguageViewModel.LeaveStatusId = 1;
				}
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				short value = short.Parse(now.ToString("yyyy", new PersianCulture()));
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				now.ToString("HH:mm:ss");
				string appType = Configuration.AppType;
				ObjectParameter objectParameter = new ObjectParameter("Result", -1);
				Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspInsertUpdateLeave(crmHourlyMissionInsertEditLanguageViewModel.LeaveId, crmHourlyMissionInsertEditLanguageViewModel.LeaveTypeId, crmHourlyMissionInsertEditLanguageViewModel.RequestUserId, crmHourlyMissionInsertEditLanguageViewModel.ReplaceUserId, crmHourlyMissionInsertEditLanguageViewModel.FromDateTime, crmHourlyMissionInsertEditLanguageViewModel.FromDate, crmHourlyMissionInsertEditLanguageViewModel.ToDateTime, crmHourlyMissionInsertEditLanguageViewModel.ToDate, crmHourlyMissionInsertEditLanguageViewModel.DayCount, crmHourlyMissionInsertEditLanguageViewModel.FromTime, crmHourlyMissionInsertEditLanguageViewModel.ToTime, crmHourlyMissionInsertEditLanguageViewModel.HourCount, crmHourlyMissionInsertEditLanguageViewModel.Reason, null, crmHourlyMissionInsertEditLanguageViewModel.KindId, crmHourlyMissionInsertEditLanguageViewModel.Place, crmHourlyMissionInsertEditLanguageViewModel.PlaceCoordinateLatitude, crmHourlyMissionInsertEditLanguageViewModel.PlaceCoordinateLongitude, crmHourlyMissionInsertEditLanguageViewModel.PlaceCoordinateZoomLevel, crmHourlyMissionInsertEditLanguageViewModel.CompanyId, crmHourlyMissionInsertEditLanguageViewModel.CountryId, crmHourlyMissionInsertEditLanguageViewModel.ProvinceId, crmHourlyMissionInsertEditLanguageViewModel.CityId, crmHourlyMissionInsertEditLanguageViewModel.VehicleTypeId, crmHourlyMissionInsertEditLanguageViewModel.StayTypeId, crmHourlyMissionInsertEditLanguageViewModel.LeaveStatusId, null, crmHourlyMissionInsertEditLanguageViewModel.MsgLangValue, userId, value, value2, value3, registerDatePersian, appType, lCID, defLangID, objectParameter, crmHourlyMissionInsertEditLanguageViewModel.DailyDateTimeInfo, crmHourlyMissionInsertEditLanguageViewModel.StepGroupId, crmHourlyMissionInsertEditLanguageViewModel.ProjectId, crmHourlyMissionInsertEditLanguageViewModel.CompanyPersonId));
				if (crmHourlyMissionInsertEditLanguageViewModel.LeaveTypeId.GetValueOrDefault() == 4 && !string.IsNullOrWhiteSpace(crmHourlyMissionInsertEditLanguageViewModel.DailyDateTimeInfo))
				{
					foreach (CrmLeaveDailyDateTimeInfoViewModel item in JsonConvert.DeserializeObject<List<CrmLeaveDailyDateTimeInfoViewModel>>(crmHourlyMissionInsertEditLanguageViewModel.DailyDateTimeInfo))
					{
						_ = item;
					}
				}
				if (objectParameter != null)
				{
					if (objectParameter.Value.ToString() == "-1")
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
					}
					else if (objectParameter.Value.ToString() == "-2")
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.frmRecordDuplicate;
					}
					else
					{
						commonReturnResultViewModel.MessageExtra = objectParameter.Value.ToString();
						commonReturnResultViewModel.IsDone = true;
						commonReturnResultViewModel.Message = Messages.msgSuccessAction;
					}
				}
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgSendParameterNotEntered;
			}
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[LoginAuthorize]
	public ActionResult Details(int leaveId = 0, int? position = 1, int? msgId = 0, int objectType = 0, string formName = "", bool startWorkflow = false)
	{
		base.ViewBag.Position = position.GetValueOrDefault(1);
		base.ViewBag.MsgId = msgId.GetValueOrDefault();
		CrmLeaveDetailsViewModel detailById = GetDetailById(leaveId);
		base.ViewBag.LeaveTypesList = SelectLeaveType_SelectListItem();
		base.ViewBag.CrmUsersList = GetUsers();
		base.ViewBag.FormName = formName;
		base.ViewBag.ObjectType = objectType;
		base.ViewBag.StartWorkflow = startWorkflow;
		int num = int.Parse(detailById.FromDateTime?.ToString("dd")) - 1;
		int num2 = int.Parse(detailById.ToDateTime?.ToString("dd")) + 1;
		string fDate = detailById.FromDateTime?.AddDays(-1 * num).ToString("yyyy/MM/dd");
		string tDate = detailById.ToDateTime?.AddMonths(1).AddDays(-1 * num2).ToString("yyyy/MM/dd");
		base.ViewBag.CalendareDates = GetCalendareDates(fDate, tDate);
		return View(detailById);
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectCalendarEvents_Result> GetCalendareDates(string fDate = "", string tDate = "")
	{
		List<CRMspSelectCalendarEvents_Result> result = new List<CRMspSelectCalendarEvents_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
			{
				DateTime value = default(DateTime);
				if (!string.IsNullOrWhiteSpace(fDate))
				{
					fDate = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					value = lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
					};
				}
				DateTime value2 = default(DateTime);
				if (!string.IsNullOrWhiteSpace(tDate))
				{
					tDate = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					value2 = lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 00:00:00"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
					};
				}
				List<CRMspSelectCalendarEvents_Result> list = Enumerable.ToList<CRMspSelectCalendarEvents_Result>((IEnumerable<CRMspSelectCalendarEvents_Result>)_dbII.CRMspSelectCalendarEvents(value, value2, lCID, result2));
				if (list != null)
				{
					result = list;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetLeave(string date = "")
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			DateTime value = DateTime.Parse(date);
			List<CRMspSelectLeave_Result> list = Enumerable.ToList<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(-1, 0, 0, -1, value, value, lCID, result2, null, result3));
			if (list != null)
			{
				list = Enumerable.ToList<CRMspSelectLeave_Result>(Enumerable.Where<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)list, (Func<CRMspSelectLeave_Result, bool>)((CRMspSelectLeave_Result x) => x.VerifierUserId.GetValueOrDefault() != 0)));
				foreach (CRMspSelectLeave_Result item in list)
				{
					item.FromDate = item.FromDateTime?.ToString("yyyy/MM/dd");
					item.ToDate = item.ToDateTime?.ToString("yyyy/MM/dd");
				}
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> GetReplaceUsers_SelectListItem(int userId = 0, int selectedId = 0)
	{
		List<CRMspSelectAlternativeUsers_Result> list = new List<CRMspSelectAlternativeUsers_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectAlternativeUsers_Result> list2 = Enumerable.ToList<CRMspSelectAlternativeUsers_Result>((IEnumerable<CRMspSelectAlternativeUsers_Result>)_dbI.CRMspSelectAlternativeUsers(userId, lCID, result));
			if (list2 != null)
			{
				list = list2;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectAlternativeUsers_Result, SelectListItem>((IEnumerable<CRMspSelectAlternativeUsers_Result>)list, (Func<CRMspSelectAlternativeUsers_Result, SelectListItem>)((CRMspSelectAlternativeUsers_Result x) => new SelectListItem
		{
			Text = x.FullName,
			Value = x.UserId.ToString(),
			Selected = (x.UserId == selectedId)
		})));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> GetLeaveKinds_SelectListItem(int selectedId = 0)
	{
		List<CRMspSelectLeaveKinds_Result> list = new List<CRMspSelectLeaveKinds_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectLeaveKinds_Result> list2 = Enumerable.ToList<CRMspSelectLeaveKinds_Result>((IEnumerable<CRMspSelectLeaveKinds_Result>)_dbI.CRMspSelectLeaveKinds(lCID, result));
			if (list2 != null)
			{
				list = list2;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectLeaveKinds_Result, SelectListItem>((IEnumerable<CRMspSelectLeaveKinds_Result>)list, (Func<CRMspSelectLeaveKinds_Result, SelectListItem>)((CRMspSelectLeaveKinds_Result x) => new SelectListItem
		{
			Text = x.LeaveKind,
			Value = x.LeaveKindID.ToString(),
			Selected = (x.LeaveKindID == selectedId)
		})));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> GetLeaveStayType_SelectListItem(int selectedId = 0)
	{
		List<CRMspSelectLeaveStayType_Result> list = new List<CRMspSelectLeaveStayType_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectLeaveStayType_Result> list2 = Enumerable.ToList<CRMspSelectLeaveStayType_Result>((IEnumerable<CRMspSelectLeaveStayType_Result>)_dbI.CRMspSelectLeaveStayType(lCID, result));
			if (list2 != null)
			{
				list = list2;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectLeaveStayType_Result, SelectListItem>((IEnumerable<CRMspSelectLeaveStayType_Result>)list, (Func<CRMspSelectLeaveStayType_Result, SelectListItem>)((CRMspSelectLeaveStayType_Result x) => new SelectListItem
		{
			Text = x.LeaveStayType,
			Value = x.LeaveStayTypeID.ToString(),
			Selected = (x.LeaveStayTypeID == selectedId)
		})));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> GetLeaveVehicleType_SelectListItem(int selectedId = 0)
	{
		List<CRMspSelectLeaveVehicleType_Result> list = new List<CRMspSelectLeaveVehicleType_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectLeaveVehicleType_Result> list2 = Enumerable.ToList<CRMspSelectLeaveVehicleType_Result>((IEnumerable<CRMspSelectLeaveVehicleType_Result>)_dbI.CRMspSelectLeaveVehicleType(lCID, result));
			if (list2 != null)
			{
				list = list2;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectLeaveVehicleType_Result, SelectListItem>((IEnumerable<CRMspSelectLeaveVehicleType_Result>)list, (Func<CRMspSelectLeaveVehicleType_Result, SelectListItem>)((CRMspSelectLeaveVehicleType_Result x) => new SelectListItem
		{
			Text = x.LeaveVehicleType,
			Value = x.LeavdVehicleTypeID.ToString(),
			Selected = (x.LeavdVehicleTypeID == selectedId)
		})));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> GetLeaveStepGroup_SelectListItem(int selectedId = 0)
	{
		List<CRMspSelectLeaveStepGroups_Result> list = new List<CRMspSelectLeaveStepGroups_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectLeaveStepGroups_Result> list2 = Enumerable.ToList<CRMspSelectLeaveStepGroups_Result>((IEnumerable<CRMspSelectLeaveStepGroups_Result>)_dbII.CRMspSelectLeaveStepGroups(lCID, result));
			if (list2 != null)
			{
				list = list2;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectLeaveStepGroups_Result, SelectListItem>((IEnumerable<CRMspSelectLeaveStepGroups_Result>)list, (Func<CRMspSelectLeaveStepGroups_Result, SelectListItem>)((CRMspSelectLeaveStepGroups_Result x) => new SelectListItem
		{
			Text = x.lsgTitle,
			Value = x.LeaveStepGroupID.ToString(),
			Selected = (x.LeaveStepGroupID == selectedId)
		})));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCountryJs()
	{
		List<CRMspSelectCountry_Result> list = new List<CRMspSelectCountry_Result>();
		try
		{
			List<CRMspSelectCountry_Result> list2 = Enumerable.ToList<CRMspSelectCountry_Result>((IEnumerable<CRMspSelectCountry_Result>)_db.CRMspSelectCountry(Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID));
			if (list2 != null)
			{
				list = list2;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectCountry_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectCountry_Result>)list, (Func<CRMspSelectCountry_Result, CrmDroupDownItem>)((CRMspSelectCountry_Result country) => new CrmDroupDownItem
		{
			text = country.Country,
			value = country.CountryID.ToString()
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetProvinceJs(int id)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		return JsonConvert.SerializeObject(Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectCompanyProvince_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectCompanyProvince_Result>)Enumerable.ToList<CRMspSelectCompanyProvince_Result>((IEnumerable<CRMspSelectCompanyProvince_Result>)_db.CRMspSelectCompanyProvince(UserLogin.CurrentUser.UserId, id, lCID, result, result2)), (Func<CRMspSelectCompanyProvince_Result, CrmDroupDownItem>)((CRMspSelectCompanyProvince_Result province) => new CrmDroupDownItem
		{
			text = province.Province,
			value = province.ProvinceID.ToString()
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCityJs(int id)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		return JsonConvert.SerializeObject(Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectCompanyCity_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectCompanyCity_Result>)Enumerable.ToList<CRMspSelectCompanyCity_Result>((IEnumerable<CRMspSelectCompanyCity_Result>)_db.CRMspSelectCompanyCity(UserLogin.CurrentUser.UserId, id, lCID, result, result2)), (Func<CRMspSelectCompanyCity_Result, CrmDroupDownItem>)((CRMspSelectCompanyCity_Result city) => new CrmDroupDownItem
		{
			text = city.City,
			value = city.CityID.ToString()
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string SearchCityJs(string val = "")
	{
		List<CRMspSearchCity_Result> value = new List<CRMspSearchCity_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			_ = Configuration.AppType;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSearchCity_Result> list = Enumerable.ToList<CRMspSearchCity_Result>((IEnumerable<CRMspSearchCity_Result>)_db.CRMspSearchCity(userId, val, 0, lCID, result, result2));
			if (list != null)
			{
				value = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> GetUsers(int currUserId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 29, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.All,
				Value = "-1",
				Selected = false
			});
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = (item.UserName ?? ""),
				Value = item.LinkedUserId.ToString(),
				Selected = (item.LinkedUserId == currUserId)
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectLeaveWithPaging_Result> SelectLeaves(int crmUserId = 0, int leaveTypeId = 0, string fDate = "", string tDate = "", int pageNumber = 1, int pageSize = 50)
	{
		List<CRMspSelectLeaveWithPaging_Result> result = new List<CRMspSelectLeaveWithPaging_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			DateTime? fDateTime = null;
			if (!string.IsNullOrWhiteSpace(fDate))
			{
				fDate = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				fDateTime = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			DateTime? tDateTime = null;
			if (!string.IsNullOrWhiteSpace(tDate))
			{
				tDate = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				tDateTime = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			List<CRMspSelectLeaveWithPaging_Result> list = Enumerable.ToList<CRMspSelectLeaveWithPaging_Result>((IEnumerable<CRMspSelectLeaveWithPaging_Result>)_dbIII.CRMspSelectLeaveWithPaging(crmUserId, null, leaveTypeId, UserLogin.CurrentUser.UserId, fDateTime, tDateTime, lCID, result2, null, result3, pageNumber, pageSize));
			if (list != null)
			{
				foreach (CRMspSelectLeaveWithPaging_Result item in list)
				{
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
					item.ReplaceUserVerifiedDatePersian = item.ReplaceUserVerifiedDate?.ToString("yyyy/MM/dd HH:mm");
					item.CanceledDatePersian = item.CanceledDate?.ToString("yyyy/MM/dd HH:mm");
					item.VerifiedRegisterDatePersian = item.VerifiedRegisterDate?.ToString("yyyy/MM/dd HH:mm");
					string text = "yyyy/MM/dd HH:mm";
					text = ((item.LeaveTypeId.GetValueOrDefault() != 1 && item.LeaveTypeId.GetValueOrDefault() != 3) ? "yyyy/MM/dd" : "HH:mm");
					item.FromDate = item.FromDateTime?.ToString(text);
					item.FromDateI = item.FromDateTime?.ToString("yyyy/MM/dd");
					item.ToDate = item.ToDateTime?.ToString(text);
					if (item.IsCanceled.GetValueOrDefault())
					{
						item.LeaveStatus = Labels.lblCanceledBy + " " + item.CancelerUser + " " + Labels.lblAt + " " + item.CanceledDatePersian;
					}
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectLeavesJs(int crmUserId = 0, int leaveTypeId = 0, string fDate = "", string tDate = "", int pageNumber = 1, int pageSize = 50)
	{
		return JsonConvert.SerializeObject(SelectLeaves(crmUserId, leaveTypeId, fDate, tDate, pageNumber, pageSize));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectLeaveType_Result> SelectLeaveType()
	{
		List<CRMspSelectLeaveType_Result> result = new List<CRMspSelectLeaveType_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectLeaveType_Result> list = Enumerable.ToList<CRMspSelectLeaveType_Result>((IEnumerable<CRMspSelectLeaveType_Result>)_dbI.CRMspSelectLeaveType(lCID, result2));
			if (list != null)
			{
				foreach (CRMspSelectLeaveType_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> SelectLeaveType_SelectListItem(int selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectLeaveType_Result> list2 = SelectLeaveType();
		string formName = "frmMain";
		foreach (CRMspSelectLeaveType_Result item in list2)
		{
			CRMspSelectLeaveType_Result cRMspSelectLeaveType_Result = null;
			if (item.LeaveTypeID == 1)
			{
				if (UserLogin.IsUserAccess(formName, "acthrHourlyLeave", UserLogin.CurrentUser))
				{
					cRMspSelectLeaveType_Result = item;
				}
			}
			else if (item.LeaveTypeID == 2)
			{
				if (UserLogin.IsUserAccess(formName, "acthrDailyLeave", UserLogin.CurrentUser))
				{
					cRMspSelectLeaveType_Result = item;
				}
			}
			else if (item.LeaveTypeID == 3)
			{
				if (UserLogin.IsUserAccess(formName, "acthrHourlyMission", UserLogin.CurrentUser))
				{
					cRMspSelectLeaveType_Result = item;
				}
			}
			else if (item.LeaveTypeID == 4 && UserLogin.IsUserAccess(formName, "acthrDailyMission", UserLogin.CurrentUser))
			{
				cRMspSelectLeaveType_Result = item;
			}
			if (cRMspSelectLeaveType_Result != null)
			{
				list.Add(new SelectListItem
				{
					Text = cRMspSelectLeaveType_Result.LeaveType,
					Value = cRMspSelectLeaveType_Result.LeaveTypeID.ToString(),
					Selected = (cRMspSelectLeaveType_Result.LeaveTypeID == selectedId)
				});
			}
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public CRMspSelectLeave_Result SelectLeaveWithId(int leaveId = 0)
	{
		CRMspSelectLeave_Result result = new CRMspSelectLeave_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, leaveId, null, UserLogin.CurrentUser.UserId, null, null, lCID, result2, null, result3));
			if (cRMspSelectLeave_Result != null)
			{
				cRMspSelectLeave_Result.RegisterDatePersian = cRMspSelectLeave_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				cRMspSelectLeave_Result.FirstRegisterDatePersian = cRMspSelectLeave_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				cRMspSelectLeave_Result.ReplaceUserVerifiedDatePersian = cRMspSelectLeave_Result.ReplaceUserVerifiedDate?.ToString("yyyy/MM/dd HH:mm");
				cRMspSelectLeave_Result.CanceledDatePersian = cRMspSelectLeave_Result.CanceledDate?.ToString("yyyy/MM/dd HH:mm");
				cRMspSelectLeave_Result.VerifiedRegisterDatePersian = cRMspSelectLeave_Result.VerifiedRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				string text = "yyyy/MM/dd HH:mm";
				text = ((cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() != 1 && cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() != 3) ? "yyyy/MM/dd" : "HH:mm");
				cRMspSelectLeave_Result.FromDate = cRMspSelectLeave_Result.FromDateTime?.ToString(text);
				cRMspSelectLeave_Result.ToDate = cRMspSelectLeave_Result.ToDateTime?.ToString(text);
				result = cRMspSelectLeave_Result;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public CrmLeaveDetailsViewModel GetDetailById(int leaveId = 0)
	{
		//IL_085b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0913: Unknown result type (might be due to invalid IL or missing references)
		CrmLeaveDetailsViewModel crmLeaveDetailsViewModel = new CrmLeaveDetailsViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = DateTime.Now;
			int value = 0;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (leaveId > 0)
			{
				CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, leaveId, null, null, null, null, currLangID, result, null, result2));
				if (cRMspSelectLeave_Result != null)
				{
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(cRMspSelectLeave_Result.RequestUserId.GetValueOrDefault());
					if (cRMspSelectUsersById_Result != null)
					{
						value = cRMspSelectUsersById_Result.UserId;
						crmLeaveDetailsViewModel.UserDepartment = cRMspSelectUsersById_Result.Department ?? "";
						crmLeaveDetailsViewModel.UserResponsible = cRMspSelectUsersById_Result.ResponsibleUser ?? "";
					}
					crmLeaveDetailsViewModel.LeaveId = cRMspSelectLeave_Result.LeaveId;
					crmLeaveDetailsViewModel.LeaveTypeId = cRMspSelectLeave_Result.LeaveTypeId;
					crmLeaveDetailsViewModel.LeaveType = cRMspSelectLeave_Result.LeaveType;
					crmLeaveDetailsViewModel.RequestDate = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("yyyy/MM/dd"));
					crmLeaveDetailsViewModel.RequestDateTime = cRMspSelectLeave_Result.FromDateTime;
					crmLeaveDetailsViewModel.FromTime = cRMspSelectLeave_Result.FromTime;
					crmLeaveDetailsViewModel.ToTime = cRMspSelectLeave_Result.ToTime;
					crmLeaveDetailsViewModel.HourCount = cRMspSelectLeave_Result.HourCount;
					crmLeaveDetailsViewModel.DayCount = cRMspSelectLeave_Result.DayCount;
					crmLeaveDetailsViewModel.ReplaceUserId = cRMspSelectLeave_Result.ReplaceUserId;
					crmLeaveDetailsViewModel.ReplaceUser = cRMspSelectLeave_Result.ReplaceUser;
					crmLeaveDetailsViewModel.RequestUserId = cRMspSelectLeave_Result.RequestUserId;
					crmLeaveDetailsViewModel.RequestUser = cRMspSelectLeave_Result.RequestUser;
					crmLeaveDetailsViewModel.LeaveStatusId = cRMspSelectLeave_Result.LeaveStatusId;
					crmLeaveDetailsViewModel.LeaveStatus = cRMspSelectLeave_Result.LeaveStatus;
					crmLeaveDetailsViewModel.VerifierUserId = cRMspSelectLeave_Result.VerifierUserId;
					crmLeaveDetailsViewModel.VerifierUser = cRMspSelectLeave_Result.VerifierUser;
					crmLeaveDetailsViewModel.FirstRegisterDate = cRMspSelectLeave_Result.FirstRegisterDate;
					crmLeaveDetailsViewModel.CompanyId = cRMspSelectLeave_Result.CompanyId;
					crmLeaveDetailsViewModel.Company = cRMspSelectLeave_Result.Company;
					crmLeaveDetailsViewModel.CountryId = cRMspSelectLeave_Result.CountryId;
					crmLeaveDetailsViewModel.Country = cRMspSelectLeave_Result.Country;
					crmLeaveDetailsViewModel.ProvinceId = cRMspSelectLeave_Result.ProvinceId;
					crmLeaveDetailsViewModel.Province = cRMspSelectLeave_Result.Province;
					crmLeaveDetailsViewModel.CityId = cRMspSelectLeave_Result.CityId;
					crmLeaveDetailsViewModel.City = cRMspSelectLeave_Result.City;
					crmLeaveDetailsViewModel.VehicleTypeId = cRMspSelectLeave_Result.VehicleTypeId;
					crmLeaveDetailsViewModel.VehicleType = cRMspSelectLeave_Result.VehicleType;
					crmLeaveDetailsViewModel.StayTypeId = cRMspSelectLeave_Result.StayTypeId;
					crmLeaveDetailsViewModel.StayType = cRMspSelectLeave_Result.StayType;
					crmLeaveDetailsViewModel.KindId = cRMspSelectLeave_Result.KindId;
					crmLeaveDetailsViewModel.Kind = cRMspSelectLeave_Result.Kind;
					crmLeaveDetailsViewModel.Description = cRMspSelectLeave_Result.Description;
					crmLeaveDetailsViewModel.PlaceCoordinateLatitude = cRMspSelectLeave_Result.PlaceCoordinateLatitude;
					crmLeaveDetailsViewModel.PlaceCoordinateLongitude = cRMspSelectLeave_Result.PlaceCoordinateLongitude;
					crmLeaveDetailsViewModel.PlaceCoordinateZoomLevel = cRMspSelectLeave_Result.PlaceCoordinateZoomLevel;
					crmLeaveDetailsViewModel.FirstRegisterDatePersian = (cRMspSelectLeave_Result.FirstRegisterDate.HasValue ? cRMspSelectLeave_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					crmLeaveDetailsViewModel.RegisterDate = cRMspSelectLeave_Result.RegisterDate;
					_ = cRMspSelectLeave_Result.RegisterDate;
					crmLeaveDetailsViewModel.RegisterDatePersian = cRMspSelectLeave_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					crmLeaveDetailsViewModel.FirstRegisterUserId = cRMspSelectLeave_Result.FirstRegisterUserId;
					crmLeaveDetailsViewModel.UserId = cRMspSelectLeave_Result.UserId;
					crmLeaveDetailsViewModel.EditUser = cRMspSelectLeave_Result.EditUser;
					crmLeaveDetailsViewModel.FirstRegisterUser = cRMspSelectLeave_Result.FirstRegisterUser;
					crmLeaveDetailsViewModel.StepGroup = cRMspSelectLeave_Result.StepGroup;
					if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 2 || cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 1)
					{
						crmLeaveDetailsViewModel.VerificationWorkFlowId = cRMspSelectLeave_Result.VerificationWorkFlowId ?? cRMspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId;
					}
					else if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 4 || cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 3)
					{
						crmLeaveDetailsViewModel.VerificationWorkFlowId = cRMspSelectLeave_Result.VerificationWorkFlowId ?? cRMspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId;
					}
					crmLeaveDetailsViewModel.LeaveVerificationWorkFlowId = cRMspSelectLeave_Result.VerificationWorkFlowId;
					crmLeaveDetailsViewModel.ReplaceUserIsVerified = cRMspSelectLeave_Result.ReplaceUserIsVerified;
					crmLeaveDetailsViewModel.FromDateTime = cRMspSelectLeave_Result.FromDateTime;
					crmLeaveDetailsViewModel.FromDate = cRMspSelectLeave_Result.FromDateTime?.ToString("yyyy/MM/dd");
					crmLeaveDetailsViewModel.ToDateTime = cRMspSelectLeave_Result.ToDateTime;
					crmLeaveDetailsViewModel.ToDate = cRMspSelectLeave_Result.ToDateTime?.ToString("yyyy/MM/dd");
					if (!string.IsNullOrEmpty(cRMspSelectLeave_Result.Country) && !string.IsNullOrEmpty(cRMspSelectLeave_Result.Province) && !string.IsNullOrEmpty(cRMspSelectLeave_Result.City))
					{
						crmLeaveDetailsViewModel.CityFullName = cRMspSelectLeave_Result.Country + " - " + cRMspSelectLeave_Result.Province + " - " + cRMspSelectLeave_Result.City;
					}
					else if (!string.IsNullOrEmpty(cRMspSelectLeave_Result.Country) || !string.IsNullOrEmpty(cRMspSelectLeave_Result.Province) || !string.IsNullOrEmpty(cRMspSelectLeave_Result.City))
					{
						crmLeaveDetailsViewModel.CityFullName = cRMspSelectLeave_Result.Country + " - " + cRMspSelectLeave_Result.Province + " - " + cRMspSelectLeave_Result.City;
					}
					if (cRMspSelectLeave_Result.LeaveStatusId.GetValueOrDefault(1) == 1)
					{
						crmLeaveDetailsViewModel.LeaveStatusStr = cRMspSelectLeave_Result.LeaveStatus ?? "";
					}
					else if (cRMspSelectLeave_Result.LeaveStatusId.GetValueOrDefault(1) == 2)
					{
						crmLeaveDetailsViewModel.LeaveStatusStr = cRMspSelectLeave_Result.LeaveStatus ?? "";
					}
					else if (cRMspSelectLeave_Result.LeaveStatusId.GetValueOrDefault(1) == 3)
					{
						crmLeaveDetailsViewModel.LeaveStatusStr = cRMspSelectLeave_Result.LeaveStatus ?? "";
					}
					crmLeaveDetailsViewModel.IsCanceled = cRMspSelectLeave_Result.IsCanceled;
					crmLeaveDetailsViewModel.CancelerUserId = cRMspSelectLeave_Result.CancelerUserId;
					crmLeaveDetailsViewModel.CancelerUser = cRMspSelectLeave_Result.CancelerUser ?? "";
					crmLeaveDetailsViewModel.CanceledDatePersian = (cRMspSelectLeave_Result.CanceledDate.HasValue ? cRMspSelectLeave_Result.CanceledDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					if (crmLeaveDetailsViewModel.IsCanceled.GetValueOrDefault())
					{
						crmLeaveDetailsViewModel.LeaveCancelStr = Labels.lblCanceledBy + " " + crmLeaveDetailsViewModel.CancelerUser + " " + Labels.lblAt + " " + crmLeaveDetailsViewModel.CanceledDatePersian;
					}
					crmLeaveDetailsViewModel.VerifiedRegisterDate = cRMspSelectLeave_Result.VerifiedRegisterDate;
					crmLeaveDetailsViewModel.VerifiedRegisterDatePersian = cRMspSelectLeave_Result.VerifiedRegisterDate?.ToString("yyyy/MM/dd HH:mm");
					string text = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd"));
					string text2 = DateTimeClass.DateDifferenceInDayText(cRMspSelectLeave_Result.FromDateTime, DateTime.Now, false);
					crmLeaveDetailsViewModel.RequestDateTimeStr = string.Format(Messages.HourlyRequestFullDateTimeForUserStrHtml, text2, text, crmLeaveDetailsViewModel.FromTime ?? "", crmLeaveDetailsViewModel.ToTime ?? "", crmLeaveDetailsViewModel.HourCount ?? "", crmLeaveDetailsViewModel.RequestUser ?? "", crmLeaveDetailsViewModel.UserDepartment);
					List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(cRMspSelectLeave_Result.LeaveLang))
					{
						List<CrmLeave_LangViewModel> list2 = new JavaScriptSerializer().Deserialize<List<CrmLeave_LangViewModel>>(cRMspSelectLeave_Result.LeaveLang);
						if (list2 != null && Enumerable.Any<CrmLeave_LangViewModel>((IEnumerable<CrmLeave_LangViewModel>)list2))
						{
							foreach (CrmLeave_LangViewModel item in list2)
							{
								list.Add(new CommonMultiLanguageViewModel
								{
									Value = item.Reason,
									LanguageId = item.LanguageID
								});
							}
						}
					}
					crmLeaveDetailsViewModel.Reason = cRMspSelectLeave_Result.Reason;
					crmLeaveDetailsViewModel.Reason_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(cRMspSelectLeave_Result.LeaveLang))
					{
						List<CrmLeave_LangViewModel> list4 = new JavaScriptSerializer().Deserialize<List<CrmLeave_LangViewModel>>(cRMspSelectLeave_Result.LeaveLang);
						if (list4 != null && Enumerable.Any<CrmLeave_LangViewModel>((IEnumerable<CrmLeave_LangViewModel>)list4))
						{
							foreach (CrmLeave_LangViewModel item2 in list4)
							{
								list3.Add(new CommonMultiLanguageViewModel
								{
									Value = item2.Place,
									LanguageId = item2.LanguageID
								});
							}
						}
					}
					crmLeaveDetailsViewModel.Place = cRMspSelectLeave_Result.Place;
					crmLeaveDetailsViewModel.Place_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					if (!string.IsNullOrEmpty(crmLeaveDetailsViewModel.CityFullName))
					{
						crmLeaveDetailsViewModel.Place = crmLeaveDetailsViewModel.CityFullName + "\n" + crmLeaveDetailsViewModel.Place;
					}
					string persianDate_YyyyMmDd = DateTime.Now.ToString("yyyy/MM/01");
					persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
					DateTime dateTime = ((currLangID == 1065) ? DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new PersianCulture()) : ((currLangID != 1025) ? DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("en-US")) : DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("ar-SA"))));
					DateTime value2 = dateTime;
					persianDate_YyyyMmDd = DateTime.Parse(DateTime.Now.AddMonths(1).ToString("yyyy/MM/01")).AddDays(-1.0).ToString("yyyy/MM/dd");
					persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
					dateTime = ((currLangID == 1065) ? DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new PersianCulture()) : ((currLangID != 1025) ? DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("en-US")) : DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("ar-SA"))));
					DateTime value3 = dateTime;
					persianDate_YyyyMmDd = DateTime.Now.ToString("yyyy/01/01");
					persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
					dateTime = ((currLangID == 1065) ? DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new PersianCulture()) : ((currLangID != 1025) ? DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("en-US")) : DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("ar-SA"))));
					DateTime value4 = dateTime;
					persianDate_YyyyMmDd = DateTime.Parse(DateTime.Now.AddYears(1).ToString("yyyy/01/01")).AddDays(-1.0).ToString("yyyy/MM/dd");
					persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
					dateTime = ((currLangID == 1065) ? DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new PersianCulture()) : ((currLangID != 1025) ? DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("en-US")) : DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("ar-SA"))));
					DateTime value5 = dateTime;
					CRMspReturnLeaveSummary_Result cRMspReturnLeaveSummary_Result = Enumerable.FirstOrDefault<CRMspReturnLeaveSummary_Result>((IEnumerable<CRMspReturnLeaveSummary_Result>)_dbI.CRMspReturnLeaveSummary(crmLeaveDetailsViewModel.LeaveTypeId, value, value2, value3, value4, value5));
					crmLeaveDetailsViewModel.MonthlyDailySum = cRMspReturnLeaveSummary_Result.MonthlyDailySum.GetValueOrDefault();
					crmLeaveDetailsViewModel.MonthlyHourlySumInMin = cRMspReturnLeaveSummary_Result.MonthlyHourlySumInMin.GetValueOrDefault();
					crmLeaveDetailsViewModel.MonthlyHourlySumTxt = cRMspReturnLeaveSummary_Result.MonthlyHourlySumTxt;
					crmLeaveDetailsViewModel.YearlyDailySum = cRMspReturnLeaveSummary_Result.YearlyDailySum.GetValueOrDefault();
					crmLeaveDetailsViewModel.YearlyHourlySumInMin = cRMspReturnLeaveSummary_Result.YearlyHourlySumInMin.GetValueOrDefault();
					crmLeaveDetailsViewModel.YealyHourlySumTxt = cRMspReturnLeaveSummary_Result.YearlyHourlySumTxt;
					crmLeaveDetailsViewModel.TotallyDailySum = cRMspReturnLeaveSummary_Result.TotallyDailySum.GetValueOrDefault();
					crmLeaveDetailsViewModel.TotallyHourlySumInMin = cRMspReturnLeaveSummary_Result.TotallyHourlySumInMin.GetValueOrDefault();
					crmLeaveDetailsViewModel.TotallyHourlySumTxt = cRMspReturnLeaveSummary_Result.TotallyHourlySumTxt;
					if (crmLeaveDetailsViewModel.MonthlyDailySum > 0)
					{
						crmLeaveDetailsViewModel.MonthlyLeaveStr = crmLeaveDetailsViewModel.MonthlyDailySum + " " + Labels.lblDay;
					}
					if (crmLeaveDetailsViewModel.MonthlyHourlySumInMin > 0)
					{
						if (!string.IsNullOrEmpty(crmLeaveDetailsViewModel.MonthlyLeaveStr))
						{
							crmLeaveDetailsViewModel.MonthlyLeaveStr = crmLeaveDetailsViewModel.MonthlyLeaveStr + " " + Labels.lblAnd + " ";
						}
						crmLeaveDetailsViewModel.MonthlyLeaveStr += DateTimeClass.ConvertMinToHourAndMin(crmLeaveDetailsViewModel.MonthlyHourlySumInMin);
					}
					if (crmLeaveDetailsViewModel.YearlyDailySum > 0)
					{
						crmLeaveDetailsViewModel.YearlyLeaveStr = crmLeaveDetailsViewModel.YearlyDailySum + " " + Labels.lblDay;
					}
					if (crmLeaveDetailsViewModel.YearlyHourlySumInMin > 0)
					{
						if (!string.IsNullOrEmpty(crmLeaveDetailsViewModel.YearlyLeaveStr))
						{
							crmLeaveDetailsViewModel.YearlyLeaveStr = crmLeaveDetailsViewModel.YearlyLeaveStr + " " + Labels.lblAnd + " ";
						}
						crmLeaveDetailsViewModel.YearlyLeaveStr += DateTimeClass.ConvertMinToHourAndMin(crmLeaveDetailsViewModel.YearlyHourlySumInMin);
					}
					if (crmLeaveDetailsViewModel.TotallyDailySum > 0)
					{
						crmLeaveDetailsViewModel.TotallyLeaveStr = crmLeaveDetailsViewModel.TotallyDailySum + " " + Labels.lblDay;
					}
					if (crmLeaveDetailsViewModel.TotallyHourlySumInMin > 0)
					{
						if (!string.IsNullOrEmpty(crmLeaveDetailsViewModel.TotallyLeaveStr))
						{
							crmLeaveDetailsViewModel.TotallyLeaveStr = crmLeaveDetailsViewModel.TotallyLeaveStr + " " + Labels.lblAnd + " ";
						}
						crmLeaveDetailsViewModel.TotallyLeaveStr += DateTimeClass.ConvertMinToHourAndMin(crmLeaveDetailsViewModel.TotallyHourlySumInMin);
					}
					crmLeaveDetailsViewModel.VerificationWorkFlowItem = new WSspSelectVerificationWorkFlowWithId_Result();
					if (crmLeaveDetailsViewModel.VerificationWorkFlowId.GetValueOrDefault() != 0)
					{
						WSspSelectVerificationWorkFlowWithId_Result wSspSelectVerificationWorkFlowWithId_Result = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowWithId_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithId_Result>)_db.WSspSelectVerificationWorkFlowWithId(crmLeaveDetailsViewModel.VerificationWorkFlowId, currLangID, result));
						if (wSspSelectVerificationWorkFlowWithId_Result != null)
						{
							crmLeaveDetailsViewModel.VerificationWorkFlowItem = wSspSelectVerificationWorkFlowWithId_Result;
						}
					}
					crmLeaveDetailsViewModel.VerificationWorkFlowStepsList = new List<WSspSelectVerificationWorkFlowSteps_Result>();
					if (crmLeaveDetailsViewModel.VerificationWorkFlowId.GetValueOrDefault() != 0)
					{
						List<WSspSelectVerificationWorkFlowSteps_Result> list5 = Enumerable.ToList<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)_db.WSspSelectVerificationWorkFlowSteps(crmLeaveDetailsViewModel.VerificationWorkFlowId, currLangID, result));
						if (list5 != null)
						{
							crmLeaveDetailsViewModel.VerificationWorkFlowStepsList = list5;
						}
					}
					crmLeaveDetailsViewModel.VerificationRequestItem = new WSspSelectVerificationRequests_Result();
					if (crmLeaveDetailsViewModel.VerificationWorkFlowId.GetValueOrDefault() != 0)
					{
						WSspSelectVerificationRequests_Result wSspSelectVerificationRequests_Result = Enumerable.FirstOrDefault<WSspSelectVerificationRequests_Result>((IEnumerable<WSspSelectVerificationRequests_Result>)_db.WSspSelectVerificationRequests(0, crmLeaveDetailsViewModel.LeaveId, 100, currLangID, result));
						if (wSspSelectVerificationRequests_Result != null)
						{
							crmLeaveDetailsViewModel.VerificationRequestItem = wSspSelectVerificationRequests_Result;
						}
					}
					crmLeaveDetailsViewModel.VerificationRequestDetailsList = new List<WSspSelectVerificationRequestDetails_Result>();
					if (crmLeaveDetailsViewModel.VerificationWorkFlowId.GetValueOrDefault() != 0)
					{
						List<WSspSelectVerificationRequestDetails_Result> list6 = ListVerificationRequestDetails(crmLeaveDetailsViewModel.VerificationRequestItem.VerificationRequestId, crmLeaveDetailsViewModel.VerificationRequestItem.VerificationWorkFlowId);
						if (list6 != null)
						{
							crmLeaveDetailsViewModel.VerificationRequestDetailsList = list6;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return crmLeaveDetailsViewModel;
	}

	public List<WSspSelectVerificationRequestDetails_Result> ListVerificationRequestDetails(int vReqId, int workflowId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectVerificationRequestDetails_Result> list = new List<WSspSelectVerificationRequestDetails_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<WSspSelectVerificationRequestDetails_Result>((IEnumerable<WSspSelectVerificationRequestDetails_Result>)_db.WSspSelectVerificationRequestDetails(0, vReqId, workflowId, currLangID, result, result2));
			using List<WSspSelectVerificationRequestDetails_Result>.Enumerator enumerator = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass31_1 _003C_003Ec__DisplayClass31_ = new _003C_003Ec__DisplayClass31_1();
				_003C_003Ec__DisplayClass31_.item = enumerator.Current;
				_003C_003Ec__DisplayClass31_.item.AppType = (_003C_003Ec__DisplayClass31_.item.VerifyDateTime.HasValue ? _003C_003Ec__DisplayClass31_.item.VerifyDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				if (_003C_003Ec__DisplayClass31_.item.VerificationRequestDetailId.HasValue && _003C_003Ec__DisplayClass31_.item.VerificationRequestDetailId > 0)
				{
					DbSet<WSVerificationRequestDetails_Lang> wSVerificationRequestDetails_Lang = _dbTbl.WSVerificationRequestDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(WSVerificationRequestDetails_Lang), "c");
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationRequestDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationRequestDetails_Lang>)Enumerable.ToList<WSVerificationRequestDetails_Lang>((IEnumerable<WSVerificationRequestDetails_Lang>)Queryable.Where<WSVerificationRequestDetails_Lang>((IQueryable<WSVerificationRequestDetails_Lang>)wSVerificationRequestDetails_Lang, Expression.Lambda<Func<WSVerificationRequestDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass31_, typeof(_003C_003Ec__DisplayClass31_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<WSVerificationRequestDetails_Lang, CommonMultiLanguageViewModel>)((WSVerificationRequestDetails_Lang item1) => new CommonMultiLanguageViewModel
					{
						Value = item1.VerifyText,
						LanguageId = item1.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass31_.item.VerifyText,
						LanguageId = result
					});
					_003C_003Ec__DisplayClass31_.item.VerifyText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					_003C_003Ec__DisplayClass31_.item.EditUser = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				}
				else
				{
					DbSet<WSVerificationWorkFlowSteps_Lang> wSVerificationWorkFlowSteps_Lang = _dbTbl.WSVerificationWorkFlowSteps_Lang;
					ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlowSteps_Lang), "c");
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationWorkFlowSteps_Lang>)Enumerable.ToList<WSVerificationWorkFlowSteps_Lang>((IEnumerable<WSVerificationWorkFlowSteps_Lang>)Queryable.Where<WSVerificationWorkFlowSteps_Lang>((IQueryable<WSVerificationWorkFlowSteps_Lang>)wSVerificationWorkFlowSteps_Lang, Expression.Lambda<Func<WSVerificationWorkFlowSteps_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass31_, typeof(_003C_003Ec__DisplayClass31_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>)((WSVerificationWorkFlowSteps_Lang item1) => new CommonMultiLanguageViewModel
					{
						Value = item1.VerifyText,
						LanguageId = item1.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass31_.item.VerifyText,
						LanguageId = result
					});
					_003C_003Ec__DisplayClass31_.item.VerifyText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					_003C_003Ec__DisplayClass31_.item.EditUser = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetOtherLeavesData(string fDate = "", string tDate = "", int leaveTypeId = 0, int crmUserId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime dateTime = default(DateTime);
			if (!string.IsNullOrWhiteSpace(fDate))
			{
				fDate = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				dateTime = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			DateTime value = default(DateTime);
			if (!string.IsNullOrWhiteSpace(tDate))
			{
				tDate = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			List<CommonWithIdStrViewModel> list2 = new List<CommonWithIdStrViewModel>();
			DateTime dateTime2 = dateTime;
			while (dateTime2.Date <= value.Date)
			{
				list2.Add(new CommonWithIdStrViewModel
				{
					Id = dateTime2.ToString("yyyy-MM-dd"),
					Extra = dateTime2.ToString("yyyy/MM/dd"),
					Name = dateTime2.ToString("dddd")
				});
				dateTime2 = dateTime2.AddDays(1.0);
			}
			list.Add(new SelectListItem
			{
				Text = "Dates",
				Value = JsonConvert.SerializeObject(list2)
			});
			List<CRMspSelectLeave_Result> list3 = Enumerable.ToList<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(crmUserId, 0, leaveTypeId, UserLogin.CurrentUser.UserId, dateTime, value, lCID, result, 2, result2));
			if (list3 != null)
			{
				foreach (CRMspSelectLeave_Result item in list3)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.CanceledDatePersian = item.CanceledDate?.ToString("yyyy/MM/dd HH:mm");
					item.FromDate = item.FromDateTime?.ToString("yyyy/MM/dd HH:mm");
					item.ToDate = item.ToDateTime?.ToString("yyyy/MM/dd HH:mm");
					item.VerifiedRegisterDatePersian = item.VerifiedRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				}
				list.Add(new SelectListItem
				{
					Text = "Data",
					Value = JsonConvert.SerializeObject(list3)
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetDatesBetween(string fDate = "", string tDate = "")
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			DateTime? dateTime = DateTimeClass.GetDateFromPersian(fDate);
			DateTime? dateFromPersian = DateTimeClass.GetDateFromPersian(tDate);
			CultureInfo cultureInfo = new CultureInfo("en-US");
			if (dateTime.HasValue && dateFromPersian.HasValue)
			{
				while (dateTime < dateFromPersian)
				{
					list.Add(new SelectListItem
					{
						Text = dateTime?.ToString("yyyy/MM/dd"),
						Value = dateTime?.ToString("yyyy/MM/dd", cultureInfo)
					});
					dateTime = dateTime?.AddDays(1.0);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	public ActionResult MissionLocation(string lat = "", string lng = "", int? zoom = 0, int? mode = 1)
	{
		try
		{
			base.ViewBag.Latitude = lat;
			base.ViewBag.Longitude = lng;
			base.ViewBag.ZoomLevel = zoom;
			base.ViewBag.Mode = mode;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	public ActionResult Terms(int leaveTypeId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			CRMspSelectLeaveTypeById_Result cRMspSelectLeaveTypeById_Result = Enumerable.FirstOrDefault<CRMspSelectLeaveTypeById_Result>((IEnumerable<CRMspSelectLeaveTypeById_Result>)_dbI.CRMspSelectLeaveTypeById(leaveTypeId, lCID, result));
			if (cRMspSelectLeaveTypeById_Result != null)
			{
				base.ViewBag.TermsText = cRMspSelectLeaveTypeById_Result.TermText ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	[AjaxOnly]
	public JsonResult CheckBeforeVerifyRequest(int leaveId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		int num = 0;
		try
		{
			CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, leaveId, null, null, null, null, lCID, result, null, result2));
			if (cRMspSelectLeave_Result != null)
			{
				CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(cRMspSelectLeave_Result.RequestUserId.GetValueOrDefault());
				if ((cRMspSelectUsersById_Result?.DepartmentId).GetValueOrDefault() == 0)
				{
					commonReturnResultViewModel.Message = Messages.msgDepartmentNotDefinedForRequestUser;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				CRMspSelectUserDepartmentById_Result cRMspSelectUserDepartmentById_Result = Enumerable.FirstOrDefault<CRMspSelectUserDepartmentById_Result>((IEnumerable<CRMspSelectUserDepartmentById_Result>)_dbI.CRMspSelectUserDepartmentById(cRMspSelectUsersById_Result.DepartmentId, lCID, result));
				if (cRMspSelectUserDepartmentById_Result != null)
				{
					bool flag = false;
					if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
					{
						if (cRMspSelectLeave_Result.VerificationWorkFlowId.GetValueOrDefault() == 0 && cRMspSelectUserDepartmentById_Result.LeaveVerificationWorkFlowId.GetValueOrDefault() == 0)
						{
							flag = true;
						}
					}
					else if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2 && cRMspSelectLeave_Result.VerificationWorkFlowId.GetValueOrDefault() == 0 && cRMspSelectUserDepartmentById_Result.MissionVerificationWorkFlowId.GetValueOrDefault() == 0)
					{
						flag = true;
					}
					if (flag)
					{
						commonReturnResultViewModel.Message = Messages.msgVerificationWorkFlowNotDefinedForDepartment;
						commonReturnResultViewModel.IsDone = false;
						num++;
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
					commonReturnResultViewModel.IsDone = true;
					commonReturnResultViewModel.Message = Messages.msgSuccessAction;
				}
				else
				{
					commonReturnResultViewModel.Message = Messages.ErrorNotFound;
					commonReturnResultViewModel.IsDone = false;
					num++;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult ExitVerify(int leaveId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		try
		{
			_dbI.CRMspLeaveVerifyExit(leaveId);
			commonReturnResultViewModel.IsDone = true;
			commonReturnResultViewModel.Message = Messages.msgSuccessAction;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult LeaveCancel(int leaveId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		try
		{
			DateTime now = DateTime.Now;
			_ = UserLogin.CurrentUser.UserId;
			DateTime value = now;
			string canceledRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			CRMSpIEntities dbI = _dbI;
			int? leaveId2 = leaveId;
			CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)dbI.CRMspSelectLeave(null, leaveId2, null, null, null, null, lCID, defLangID, null, result));
			if (cRMspSelectLeave_Result != null)
			{
				_dbI.CRMspLeaveCancel(leaveId, UserLogin.CurrentUser.UserId, value, canceledRegisterDatePersian);
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				foreach (Languages item3 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					string resourceString = MyResource.GetResourceString("CancelRequest", item3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					string format = "";
					if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault(1) == 1)
					{
						format = MyResource.GetResourceString("msgLeaveCanceledWithNumber", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					}
					else if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault(1) == 2)
					{
						format = MyResource.GetResourceString("msgMissionCanceledWithNumber", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					}
					format = string.Format(format, cRMspSelectLeave_Result.LeaveId);
					CommonMultiLanguageViewModel item = new CommonMultiLanguageViewModel
					{
						Value = resourceString,
						LanguageId = item3.LanguageID
					};
					list.Add(item);
					CommonMultiLanguageViewModel item2 = new CommonMultiLanguageViewModel
					{
						Value = format,
						LanguageId = item3.LanguageID
					};
					list2.Add(item2);
				}
				string subject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				string message = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				int userId = UserLogin.CurrentUser.UserId;
				int result2 = 0;
				int.TryParse(cRMspSelectLeave_Result.RequestUserId.ToString(), out result2);
				int value2 = 0;
				int msgTypeId = 0;
				if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
				{
					msgTypeId = 6;
					value2 = (cRMspSelectLeave_Result.VerificationWorkFlowId ?? cRMspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId).GetValueOrDefault();
				}
				else if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2)
				{
					msgTypeId = 7;
					value2 = (cRMspSelectLeave_Result.VerificationWorkFlowId ?? cRMspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId).GetValueOrDefault();
				}
				SendMessage(userId, result2, msgTypeId, subject, message, list2, cRMspSelectLeave_Result.LeaveId, value2, list);
				commonReturnResultViewModel.IsDone = true;
				commonReturnResultViewModel.Message = Messages.msgSuccessAction;
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string ReturnLeaveType(int leaveId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "-1";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (leaveId > 0)
			{
				CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, leaveId, null, null, null, null, lCID, result, null, result2));
				if (cRMspSelectLeave_Result != null)
				{
					return cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault().ToString();
				}
				return "-1";
			}
			return "-1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	public bool SendMessage(int fromUserId, int toUserId, int msgTypeId, string subject, string message, List<CommonMultiLanguageViewModel> msglist, int objectId, int? workflowStepId = null, List<CommonMultiLanguageViewModel> sublist = null)
	{
		bool result = true;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string msgdSendTime = now.ToString("HH:mm:ss");
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedID", 0);
			_db.CRMspInternalMessageSendSingle(null, subject, message, msgTypeId, fromUserId, toUserId, text, msgdSendTime, now, null, null, objectId, null, null, userId, value2, value, now, text, appType, objectParameter, defLangID, workflowStepId, null, centerId);
			int num = (int)objectParameter.Value;
			foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
			{
				string msgBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)msglist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)msglist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				string msgSubject = subject;
				if (sublist != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist))
				{
					msgSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : subject);
				}
				CrmInternalMessage_Lang entity = new CrmInternalMessage_Lang
				{
					LanguageID = lang.LanguageID,
					InternalMessageID = num,
					msgBody = msgBody,
					msgSubject = msgSubject
				};
				_dbTbl.CrmInternalMessage_Lang.Add(entity);
				_dbTbl.SaveChanges();
			}
			if (num <= 0)
			{
				result = false;
			}
			PushNotif.NewIntMsgNotify();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = false;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult RefreshDetails(int leaveId = 0)
	{
		CrmLeaveDetailsViewModel detailById = GetDetailById(leaveId);
		JsonResult jsonResult = Json(detailById, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult DeleteLeave(int leaveId = 0)
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		int num = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspDeleteLeave(leaveId)).GetValueOrDefault() == 1)
			{
				commonReturnResultViewModel.IsDone = true;
				commonReturnResultViewModel.Message = Messages.msgSuccessAction;
			}
			else
			{
				num++;
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetTodayLeavesList(string reqDate = "")
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CultureInfo cultureInfo = new CultureInfo(lCID);
			int userId = UserLogin.CurrentUser.UserId;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			DateTime value = DateTime.Now;
			if (!string.IsNullOrEmpty(reqDate))
			{
				reqDate = PersianDate.GetFormatetdDate(reqDate.Replace("/", ""));
				value = lCID switch
				{
					1065 => DateTime.Parse(reqDate + " 00:00:00", new PersianCulture()), 
					1025 => DateTime.Parse(reqDate + " 00:00:00", new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(reqDate + " 00:00:00", new CultureInfo("en-US")), 
				};
			}
			List<CRMspSelectLeave_Result> list = Enumerable.ToList<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, null, null, userId, value, value, lCID, result2, null, result3));
			if (list != null)
			{
				list = Enumerable.ToList<CRMspSelectLeave_Result>(Enumerable.Where<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)list, (Func<CRMspSelectLeave_Result, bool>)((CRMspSelectLeave_Result x) => x.VerifierUserId.GetValueOrDefault() != 0 && !x.IsCanceled.GetValueOrDefault() && (!x.ReplaceUserId.HasValue || x.ReplaceUserIsVerified.GetValueOrDefault()))));
				foreach (CRMspSelectLeave_Result item in list)
				{
					item.CanceledDatePersian = item.CanceledDate?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
					item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm", cultureInfo);
					item.ReplaceUserVerifiedDatePersian = item.ReplaceUserVerifiedDate?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
					item.FromDate = item.FromDateTime?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
					item.FromDateI = item.FromDateTime?.ToString("yyyy/MM/dd", cultureInfo);
					item.ToDate = item.ToDateTime?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
					item.VerifiedRegisterDatePersian = item.VerifiedRegisterDate?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
				}
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult ExecuteLeave(int leaveId, int leaveTypeId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		try
		{
			commonReturnResultViewModel = ActExecuteLeave(leaveId, leaveTypeId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public CommonReturnResultViewModel ActExecuteLeave(int leaveId, int leaveTypeId, string requestUserIds = "", DateTime? fromLeaveDate = null, DateTime? toLeaveDate = null, int currUserId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		try
		{
			string arg = "";
			switch (leaveTypeId)
			{
			case 1:
			case 2:
				arg = Labels.lblLeave;
				break;
			case 3:
			case 4:
				arg = Labels.lblMission;
				break;
			case -1:
				arg = Labels.LeavesAndMissionsBrefoeNowAllUser;
				break;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			int value4 = -3;
			if (UserLogin.CurrentUser != null)
			{
				value4 = UserLogin.CurrentUser.UserId;
			}
			if (currUserId != 0)
			{
				value4 = currUserId;
			}
			ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
			Enumerable.FirstOrDefault<mct_III_Result>((IEnumerable<mct_III_Result>)_dbIII.CRMspExecuteLeave(leaveId, value4, value, registerDatePersian, value2, value3, appType, lCID, result, objectParameter, requestUserIds, fromLeaveDate, toLeaveDate));
			int result2 = 0;
			if (objectParameter != null && objectParameter.Value != null)
			{
				int.TryParse(objectParameter.Value.ToString(), out result2);
			}
			switch (result2)
			{
			case 1:
				commonReturnResultViewModel.IsDone = true;
				commonReturnResultViewModel.Message = string.Format(Messages.msgLeaveExecute, arg);
				break;
			case -1:
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorExecLeaveBeforeVerify, arg);
				break;
			case -2:
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorExecLeaveCanceled, arg);
				break;
			case -3:
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorLeaveAlreadyExecute, arg);
				break;
			default:
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorNotEexcuteLeave, arg);
				break;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		return commonReturnResultViewModel;
	}

	[AjaxOnly]
	public JsonResult ExecuteLeaveBeforeNowAllUser()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		try
		{
			DateTime now = DateTime.Now;
			commonReturnResultViewModel = ActExecuteLeave(0, -1, "", now, now);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}
}
