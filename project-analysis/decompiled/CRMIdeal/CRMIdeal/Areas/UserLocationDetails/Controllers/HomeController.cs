using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.UserLocationDetails.Controllers;

public class HomeController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	public ActionResult Index()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcUserLocationShowMovement")]
	public ActionResult ShowMovement(int userId = 0, string userIds = "")
	{
		base.ViewBag.UsersListJs = SelectUserForLinkedTypeJs(userId, userIds);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineUserMovementTrackingPolygon")]
	public ActionResult DefinePolygon(int userId = 0, string userIds = "")
	{
		base.ViewBag.PolygonsJs = SelectUserMovementTrackingPolygonJs(userIds);
		base.ViewBag.UsersListJs = SelectUserForLinkedTypeJs(userId, userIds);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDefineUserMovementTrackingPolygon", ActionName = "actInsert")]
	public ActionResult DefinePolygonInsertEdit(int id = 0, int userId = 0)
	{
		base.ViewBag.PolygonsListJs = SelectUserMovementTrackingPolygonJs();
		CRMspSelectUserMovementTrackingPolygonWithId_Result cRMspSelectUserMovementTrackingPolygonWithId_Result = SelectUserMovementTrackingPolygonWithId(id);
		if (cRMspSelectUserMovementTrackingPolygonWithId_Result.UserMovementTrackingPolygonId <= 0 && userId != 0)
		{
			cRMspSelectUserMovementTrackingPolygonWithId_Result.PolygonUserId = userId;
		}
		base.ViewBag.UsersListJs = SelectUserForLinkedType(cRMspSelectUserMovementTrackingPolygonWithId_Result.PolygonUserId);
		return View(cRMspSelectUserMovementTrackingPolygonWithId_Result);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineUserMovementTrackingPolygon", ActionName = "actInsert")]
	public ActionResult DefinePolygonInsertEdit(CRMspSelectUserMovementTrackingPolygonWithId_Result model)
	{
		string text = "";
		string text2 = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text3 = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("Result", 0);
			if (model.UserMovementTrackingPolygonId > 0)
			{
				_dbI.CRMspUpdateUserMovementTrackingPolygon(model.UserMovementTrackingPolygonId, model.PolygonUserId, model.PolygonPoints, model.PolygonCenter, model.PolygonZoomLevel, model.PolygonColor, userId, value2, value3, value, text3, appType, lCID, objectParameter);
				if (objectParameter == null)
				{
					text = Messages.msgErrorOperationFailed;
				}
				else if (int.Parse(objectParameter.Value.ToString()) <= 0)
				{
					text = ((int.Parse(objectParameter.Value.ToString()) != -2) ? Messages.msgErrorOperationFailed : Messages.frmRecordDuplicate);
				}
				else
				{
					text2 = Messages.msgOperationCompleted;
				}
			}
			else
			{
				_dbI.CRMspInsertUserMovementTrackingPolygon(model.PolygonUserId, model.PolygonPoints, model.PolygonCenter, model.PolygonZoomLevel, model.PolygonColor, userId, value, text3, userId, value2, value3, value, text3, appType, lCID, objectParameter);
				if (objectParameter == null)
				{
					text = Messages.msgErrorOperationFailed;
				}
				else if (int.Parse(objectParameter.Value.ToString()) <= 0)
				{
					text = ((int.Parse(objectParameter.Value.ToString()) != -2) ? Messages.msgErrorOperationFailed : Messages.frmRecordDuplicate);
				}
				else
				{
					text2 = Messages.msgOperationCompleted;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.Successfull = text2;
		base.ViewBag.Error = text;
		base.ViewBag.PolygonsListJs = SelectUserMovementTrackingPolygon();
		base.ViewBag.UsersListJs = SelectUserForLinkedType(model.PolygonUserId);
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineUserMovementTrackingPolygon", ActionName = "actDelete")]
	public string DeletePolygon(int id = 0)
	{
		string result = "";
		try
		{
			if (id != 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteUserMovementTrackingPolygon(id));
				result = ((mct_I_Result == null || mct_I_Result.Result <= 0) ? "-2" : SelectUserMovementTrackingPolygonJs());
			}
			else
			{
				result = "0";
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
	public List<CRMspSelectUserMovementTracking_Result> SelectUserMovementTracking(string userIds = "", string fDate = "", string fTime = "", string tDate = "", string tTime = "")
	{
		List<CRMspSelectUserMovementTracking_Result> result = new List<CRMspSelectUserMovementTracking_Result>();
		try
		{
			if (string.IsNullOrWhiteSpace(userIds))
			{
				return result;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			try
			{
				if (!string.IsNullOrWhiteSpace(fDate))
				{
					string text = "";
					text = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			try
			{
				if (!string.IsNullOrWhiteSpace(tDate))
				{
					string text2 = "";
					text2 = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					value2 = lCID switch
					{
						1065 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception ex2)
			{
				Public.InsExceptToElmah(ex2);
			}
			List<CRMspSelectUserMovementTracking_Result> list = Enumerable.ToList<CRMspSelectUserMovementTracking_Result>((IEnumerable<CRMspSelectUserMovementTracking_Result>)_dbI.CRMspSelectUserMovementTracking(userIds, value, fTime, value2, tTime, lCID, result2));
			if (list != null)
			{
				foreach (CRMspSelectUserMovementTracking_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.FirstRegisterDatePersian))
					{
						switch (lCID)
						{
						case 1065:
							item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd", new PersianCulture());
							break;
						case 1025:
							item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
							break;
						default:
							item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
							break;
						}
					}
				}
				result = list;
			}
		}
		catch (Exception ex3)
		{
			Public.InsExceptToElmah(ex3);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectUserMovementTrackingJs(string userIds = "", string fDate = "", string fTime = "", string tDate = "", string tTime = "")
	{
		return JsonConvert.SerializeObject(SelectUserMovementTracking(userIds, fDate, fTime, tDate, tTime));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> SelectUserForLinkedType(int selectedId = 0, string selectedIds = "")
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 19, lCID, result, result2));
			if (list2 != null)
			{
				List<string> usLst = new List<string>();
				if (!string.IsNullOrWhiteSpace(selectedIds))
				{
					usLst = Enumerable.ToList<string>(Enumerable.Where<string>((IEnumerable<string>)selectedIds.Split(new char[1] { ',' }), (Func<string, bool>)((string x) => !string.IsNullOrWhiteSpace(x))));
				}
				list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result x) => new SelectListItem
				{
					Text = (x.UserName ?? ""),
					Value = x.LinkedUserId.ToString(),
					Selected = ((selectedId == x.LinkedUserId || Enumerable.FirstOrDefault<string>((IEnumerable<string>)usLst, (Func<string, bool>)((string s) => s == x.LinkedUserId.ToString())) != null) ? true : false)
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectUserForLinkedTypeJs(int selectedId = 0, string selectedIds = "")
	{
		return JsonConvert.SerializeObject(SelectUserForLinkedType(selectedId, selectedIds));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectUserMovementTrackingPolygon_Result> SelectUserMovementTrackingPolygon(string userIds = "")
	{
		List<CRMspSelectUserMovementTrackingPolygon_Result> result = new List<CRMspSelectUserMovementTrackingPolygon_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectUserMovementTrackingPolygon_Result> list = Enumerable.ToList<CRMspSelectUserMovementTrackingPolygon_Result>((IEnumerable<CRMspSelectUserMovementTrackingPolygon_Result>)_dbI.CRMspSelectUserMovementTrackingPolygon(userIds, lCID, result2));
			if (list != null)
			{
				try
				{
					foreach (CRMspSelectUserMovementTrackingPolygon_Result item in list)
					{
						if (!string.IsNullOrWhiteSpace(item.FirstRegisterDatePersian))
						{
							switch (lCID)
							{
							case 1065:
								item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd", new PersianCulture());
								break;
							case 1025:
								item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
								break;
							default:
								item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
								break;
							}
						}
					}
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	public string SelectUserMovementTrackingPolygonJs(string userIds = "")
	{
		return JsonConvert.SerializeObject(SelectUserMovementTrackingPolygon(userIds));
	}

	public CRMspSelectUserMovementTrackingPolygonWithId_Result SelectUserMovementTrackingPolygonWithId(int id = 0)
	{
		CRMspSelectUserMovementTrackingPolygonWithId_Result result = new CRMspSelectUserMovementTrackingPolygonWithId_Result();
		try
		{
			if (id > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				CRMspSelectUserMovementTrackingPolygonWithId_Result cRMspSelectUserMovementTrackingPolygonWithId_Result = Enumerable.FirstOrDefault<CRMspSelectUserMovementTrackingPolygonWithId_Result>((IEnumerable<CRMspSelectUserMovementTrackingPolygonWithId_Result>)_dbI.CRMspSelectUserMovementTrackingPolygonWithId(id, lCID, result2));
				if (cRMspSelectUserMovementTrackingPolygonWithId_Result != null)
				{
					if (!string.IsNullOrWhiteSpace(cRMspSelectUserMovementTrackingPolygonWithId_Result.FirstRegisterDatePersian))
					{
						switch (lCID)
						{
						case 1065:
							cRMspSelectUserMovementTrackingPolygonWithId_Result.FirstRegisterDatePersian = cRMspSelectUserMovementTrackingPolygonWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd", new PersianCulture());
							break;
						case 1025:
							cRMspSelectUserMovementTrackingPolygonWithId_Result.FirstRegisterDatePersian = cRMspSelectUserMovementTrackingPolygonWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
							break;
						default:
							cRMspSelectUserMovementTrackingPolygonWithId_Result.FirstRegisterDatePersian = cRMspSelectUserMovementTrackingPolygonWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
							break;
						}
					}
					result = cRMspSelectUserMovementTrackingPolygonWithId_Result;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}
}
