using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Centers.Controllers;

public class LinkedController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCenterLinked")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult LoadLinkedTypeTree()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkedType_Result> list = new List<CRMspSelectLinkedType_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectLinkedType_Result>((IEnumerable<CRMspSelectLinkedType_Result>)_db.CRMspSelectLinkedType(lCID, result));
			if (list == null)
			{
				list = new List<CRMspSelectLinkedType_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string GetCenterTree()
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
			List<CRMspSelectCentersTree_Result> list = Enumerable.ToList<CRMspSelectCentersTree_Result>((IEnumerable<CRMspSelectCentersTree_Result>)_dbII.CRMspSelectCentersTree(lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string GetUnLinkedCentersTree(int linkedTypeId, int cId)
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
			List<CRMspSelectUnLinkedCentersForLinkedType_Result> list = Enumerable.ToList<CRMspSelectUnLinkedCentersForLinkedType_Result>((IEnumerable<CRMspSelectUnLinkedCentersForLinkedType_Result>)_dbII.CRMspSelectUnLinkedCentersForLinkedType(cId, linkedTypeId, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string GetLinkedCentersTree(int linkedTypeId, int cId)
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
			List<CRMspSelectLinkedCentersForLinkedType_Result> list = Enumerable.ToList<CRMspSelectLinkedCentersForLinkedType_Result>((IEnumerable<CRMspSelectLinkedCentersForLinkedType_Result>)_dbII.CRMspSelectLinkedCentersForLinkedType(cId, linkedTypeId, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string ActAssign(int linkedTypeId, int cId, string linkedCIds, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCenterLinked", "actAssign", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertCenterLinkedForCenters(linkedTypeId, cId, linkedCIds, userId, value3, value2, value, registerDatePersian, appType, result2));
			if (mct_II_Result != null)
			{
				int result3 = 0;
				int.TryParse(mct_II_Result.Result.ToString(), out result3);
				if (result3 == 0)
				{
					return Messages.msgErrorRunFunction;
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertCenterLinkedForCenters(23, cId, linkedCIds, userId, value3, value2, value, registerDatePersian, appType, result2));
					if (mct_II_Result != null)
					{
						int result4 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result4);
						if (result4 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertCenterLinkedForCenters(24, cId, linkedCIds, userId, value3, value2, value, registerDatePersian, appType, result2));
					if (mct_II_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertCenterLinkedForCenters(25, cId, linkedCIds, userId, value3, value2, value, registerDatePersian, appType, result2));
					if (mct_II_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result6);
						if (result6 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionCnvsInfo + ")";
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string ActRemove(int linkedTypeId, int cId, string linkedCIds, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCenterLinked", "actRemove", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteCenterLinkedForCenters(linkedTypeId, cId, linkedCIds));
			if (mct_II_Result != null)
			{
				int result3 = 0;
				int.TryParse(mct_II_Result.Result.ToString(), out result3);
				if (result3 == 0)
				{
					return Messages.msgErrorRunFunction;
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteCenterLinkedForCenters(23, cId, linkedCIds));
					if (mct_II_Result != null)
					{
						int result4 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result4);
						if (result4 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteCenterLinkedForCenters(24, cId, linkedCIds));
					if (mct_II_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteCenterLinkedForCenters(25, cId, linkedCIds));
					if (mct_II_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result6);
						if (result6 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionCnvsInfo + ")";
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string ActAssignAll(int linkedTypeId, int cId, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCenterLinked", "actAssignAll", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertCenterLinkedForCentersAll(linkedTypeId, cId, userId, value3, value2, value, registerDatePersian, appType, result2));
			if (mct_II_Result != null)
			{
				int result3 = 0;
				int.TryParse(mct_II_Result.Result.ToString(), out result3);
				if (result3 == 0)
				{
					return Messages.msgErrorRunFunction;
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertCenterLinkedForCentersAll(23, cId, userId, value3, value2, value, registerDatePersian, appType, result2));
					if (mct_II_Result != null)
					{
						int result4 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result4);
						if (result4 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertCenterLinkedForCentersAll(24, cId, userId, value3, value2, value, registerDatePersian, appType, result2));
					if (mct_II_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertCenterLinkedForCentersAll(25, cId, userId, value3, value2, value, registerDatePersian, appType, result2));
					if (mct_II_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result6);
						if (result6 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionCnvsInfo + ")";
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string ActRemoveAll(int linkedTypeId, int cId, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCenterLinked", "actRemoveAll", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteCenterLinkedForCentersAll(linkedTypeId, cId));
			if (mct_II_Result != null)
			{
				int result3 = 0;
				int.TryParse(mct_II_Result.Result.ToString(), out result3);
				if (result3 == 0)
				{
					return Messages.msgErrorRunFunction;
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteCenterLinkedForCentersAll(23, cId));
					if (mct_II_Result != null)
					{
						int result4 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result4);
						if (result4 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteCenterLinkedForCentersAll(24, cId));
					if (mct_II_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteCenterLinkedForCentersAll(25, cId));
					if (mct_II_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_II_Result.Result.ToString(), out result6);
						if (result6 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionCnvsInfo + ")";
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
