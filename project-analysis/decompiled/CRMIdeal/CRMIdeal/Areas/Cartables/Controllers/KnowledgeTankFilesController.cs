using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Cartables.Controllers;

public class KnowledgeTankFilesController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int knlgId;

		public CRMspKnlgSearch_Result knlg;

		internal bool _003C_PartialKnlgInfo_003Eb__0(CRMspKnlgSearch_Result c)
		{
			return c.KnowledgeTankId == knlgId;
		}
	}

	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmFileDataEntry", ActionName = "actSelKnowledgeTankFiles")]
	public ActionResult Index(string type = "")
	{
		base.ViewBag.Type = type;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgInfo(int knlgId, string txtSearch, int mode)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.knlgId = knlgId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspKnlgSearchViewModel cRMspKnlgSearchViewModel = new CRMspKnlgSearchViewModel();
		CS_0024_003C_003E8__locals0.knlg = null;
		try
		{
			int? rollId = UserLogin.CurrentUser.RollId;
			List<CRMspKnlgSearch_Result> list = Enumerable.ToList<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)db.CRMspKnlgSearch(txtSearch, rollId, mode, lCID, result));
			CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)list, (Func<CRMspKnlgSearch_Result, bool>)((CRMspKnlgSearch_Result c) => c.KnowledgeTankId == CS_0024_003C_003E8__locals0.knlgId));
			if (CS_0024_003C_003E8__locals0.knlg == null)
			{
				CS_0024_003C_003E8__locals0.knlg = new CRMspKnlgSearch_Result();
				CS_0024_003C_003E8__locals0.knlg.RegisterDate = DateTime.Now;
				CS_0024_003C_003E8__locals0.knlg.KnowledgeTankId = 0;
			}
			cRMspKnlgSearchViewModel.KnowledgeTankId = CS_0024_003C_003E8__locals0.knlg.KnowledgeTankId;
			cRMspKnlgSearchViewModel.knlgTitle = CS_0024_003C_003E8__locals0.knlg.knlgTitle;
			cRMspKnlgSearchViewModel.knlgSigns = CS_0024_003C_003E8__locals0.knlg.knlgSigns;
			cRMspKnlgSearchViewModel.knlgKnowledge = CS_0024_003C_003E8__locals0.knlg.knlgKnowledge;
			cRMspKnlgSearchViewModel.knlgPriorityId = CS_0024_003C_003E8__locals0.knlg.knlgPriorityId;
			cRMspKnlgSearchViewModel.knowledgeTankPriorityTitle = CS_0024_003C_003E8__locals0.knlg.knowledgeTankPriorityTitle ?? "";
			cRMspKnlgSearchViewModel.knlgGroupId = CS_0024_003C_003E8__locals0.knlg.knlgGroupId;
			cRMspKnlgSearchViewModel.knowledgeTankGroupTitle = CS_0024_003C_003E8__locals0.knlg.knowledgeTankGroupTitle ?? "";
			cRMspKnlgSearchViewModel.FirstRegisterDate = CS_0024_003C_003E8__locals0.knlg.FirstRegisterDate;
			cRMspKnlgSearchViewModel.FirstRegisterDatePersian = CS_0024_003C_003E8__locals0.knlg.FirstRegisterDatePersian;
			cRMspKnlgSearchViewModel.FirstRegisterDatePersian = DateTimeClass.ConvertDateWOSlashToSlash(cRMspKnlgSearchViewModel.FirstRegisterDatePersian);
			cRMspKnlgSearchViewModel.UserId = CS_0024_003C_003E8__locals0.knlg.UserId;
			DbSet<Users> users = _dbTbl.Users;
			ParameterExpression val = Expression.Parameter(typeof(Users), "c");
			Queryable.FirstOrDefault<Users>((IQueryable<Users>)users, Expression.Lambda<Func<Users, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			cRMspKnlgSearchViewModel.EditedUser = CS_0024_003C_003E8__locals0.knlg.EditedUser ?? "";
			cRMspKnlgSearchViewModel.RegisterUser = CS_0024_003C_003E8__locals0.knlg.RegisterUser ?? "";
			cRMspKnlgSearchViewModel.RegisterDate = CS_0024_003C_003E8__locals0.knlg.RegisterDate;
			cRMspKnlgSearchViewModel.RegisterDatePersian = CS_0024_003C_003E8__locals0.knlg.RegisterDatePersian;
			cRMspKnlgSearchViewModel.RegisterDatePersian = DateTimeClass.ConvertDateWOSlashToSlash(cRMspKnlgSearchViewModel.RegisterDatePersian);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(cRMspKnlgSearchViewModel);
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgShowFiles(int knlgId)
	{
		base.ViewBag.KnlgId = knlgId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgPreviewShowFilse_Read([DataSourceRequest] DataSourceRequest request, int knlgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			if (knlgId != 0)
			{
				list = Files.SelectFilesDirectory("0", "0", "0", "40", knlgId.ToString(), "0", "0", false);
				if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
				{
					foreach (CRMspSelectFilesDirectory_Result item in list)
					{
						if (item.DocDateTime.HasValue)
						{
							DateTime.TryParse(item.DocDateTime.ToString(), out var result2);
							item.DocDate = result2.ToString("yyyy/MM/dd");
						}
						else if (!string.IsNullOrEmpty(item.DocDate))
						{
							if (lCID != 1065)
							{
								item.DocDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.DocDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
							}
							else
							{
								item.DocDate = PersianDate.GetFormatetdDate(item.DocDate.Replace("/", ""));
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult KnlgSearch(string txtSearch, int mode)
	{
		List<CRMspKnlgSearch_Result> list = new List<CRMspKnlgSearch_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? rollId = UserLogin.CurrentUser.RollId;
			list = Enumerable.ToList<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)db.CRMspKnlgSearch(txtSearch, rollId, mode, lCID, result));
			foreach (CRMspKnlgSearch_Result item in list)
			{
				_ = item.FirstRegisterDate;
				item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyyMMdd");
				_ = item.RegisterDate;
				item.RegisterDatePersian = item.RegisterDate.ToString("yyyyMMdd");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		dbI.Dispose();
		base.Dispose(disposing);
	}
}
