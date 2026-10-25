using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Accounts.Controllers;

public class UserPositionsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int posId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public UserPositionsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__9;

		public Func<Languages, bool> _003C_003E9__23;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__23(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public UserPositions model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineUserPositions")]
	public ActionResult Index()
	{
		return View();
	}

	public List<TreeViewItemModel> GetUserPositionNodeTree(List<CRMspSelectUserPositionTree_Result> lstPositions, int? posId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectUserPositionTree_Result> list2 = Enumerable.ToList<CRMspSelectUserPositionTree_Result>(Enumerable.Where<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)lstPositions, (Func<CRMspSelectUserPositionTree_Result, bool>)((CRMspSelectUserPositionTree_Result m) => m.ParentId == posId)));
			if (Enumerable.Any<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list2))
			{
				foreach (CRMspSelectUserPositionTree_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.PositionId.ToString()));
					treeViewItemModel.Id = item.PositionId.ToString();
					treeViewItemModel.Text = item.PositionNameWithCode;
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> userPositionNodeTree = GetUserPositionNodeTree(lstPositions, item.PositionId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(userPositionNodeTree);
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<TreeViewItemModel> GetUserPositionTree(int posId = 0)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectUserPositionTree_Result> list2 = Enumerable.ToList<CRMspSelectUserPositionTree_Result>(Enumerable.Where<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)_db.CRMspSelectUserPositionTree(lCID, result), (Func<CRMspSelectUserPositionTree_Result, bool>)((CRMspSelectUserPositionTree_Result m) => m.PositionId != posId)));
			if (Enumerable.Any<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list2))
			{
				List<CRMspSelectUserPositionTree_Result> list3 = Enumerable.ToList<CRMspSelectUserPositionTree_Result>(Enumerable.Where<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list2, (Func<CRMspSelectUserPositionTree_Result, bool>)((CRMspSelectUserPositionTree_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list3))
				{
					foreach (CRMspSelectUserPositionTree_Result item in list3)
					{
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.PositionId.ToString()));
						treeViewItemModel.Id = item.PositionId.ToString();
						treeViewItemModel.Text = item.PositionNameWithCode;
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> userPositionNodeTree = GetUserPositionNodeTree(list2, item.PositionId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(userPositionNodeTree);
						list.Add(treeViewItemModel);
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialUserPositionsTree(int posId = 0)
	{
		try
		{
			List<TreeViewItemModel> userPositionTree = GetUserPositionTree(posId);
			base.ViewBag.PositionsTree = userPositionTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetUserPositionInfo(int posId)
	{
		CRMspSelectUserPositionsById_Result cRMspSelectUserPositionsById_Result = new CRMspSelectUserPositionsById_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMspSelectUserPositionsById_Result = Enumerable.FirstOrDefault<CRMspSelectUserPositionsById_Result>((IEnumerable<CRMspSelectUserPositionsById_Result>)_db.CRMspSelectUserPositionsById(posId, lCID, result));
			if (cRMspSelectUserPositionsById_Result != null)
			{
				if (string.IsNullOrEmpty(cRMspSelectUserPositionsById_Result.AppType))
				{
					cRMspSelectUserPositionsById_Result.AppType = Configuration.AppType;
				}
				cRMspSelectUserPositionsById_Result.AppType = " (" + Labels.AppType + ":" + Configuration.GetAppType(cRMspSelectUserPositionsById_Result.AppType) + ")";
				CRMspSelectUserPositionsById_Result cRMspSelectUserPositionsById_Result2 = cRMspSelectUserPositionsById_Result;
				_ = cRMspSelectUserPositionsById_Result.FirstRegisterDate;
				cRMspSelectUserPositionsById_Result2.FirstRegisterDatePersian = cRMspSelectUserPositionsById_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspSelectUserPositionsById_Result.FirstRegisterUser = cRMspSelectUserPositionsById_Result.FirstRegisterUser + " (" + cRMspSelectUserPositionsById_Result.FirstRegisterDatePersian + ")";
				CRMspSelectUserPositionsById_Result cRMspSelectUserPositionsById_Result3 = cRMspSelectUserPositionsById_Result;
				_ = cRMspSelectUserPositionsById_Result.RegisterDate;
				cRMspSelectUserPositionsById_Result3.RegisterDatePersian = cRMspSelectUserPositionsById_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspSelectUserPositionsById_Result.EditUser = cRMspSelectUserPositionsById_Result.EditUser + cRMspSelectUserPositionsById_Result.AppType + " (" + cRMspSelectUserPositionsById_Result.RegisterDatePersian + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(cRMspSelectUserPositionsById_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult Users_Read([DataSourceRequest] DataSourceRequest request, int posId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectUsersByPositionId_Result> enumerable = new List<CRMspSelectUsersByPositionId_Result>();
		try
		{
			enumerable = Enumerable.ToList<CRMspSelectUsersByPositionId_Result>((IEnumerable<CRMspSelectUsersByPositionId_Result>)_db.CRMspSelectUsersByPositionId(posId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmManageUserPositions", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int posId = 0)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.posId = posId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		UserPositionsLanguageViewModel userPositionsLanguageViewModel = new UserPositionsLanguageViewModel();
		if (CS_0024_003C_003E8__locals0.posId > 0)
		{
			if (!UserLogin.IsUserAccess("frmManageUserPositions", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<UserPositions_Lang> userPositions_Lang = _dbTbl.UserPositions_Lang;
			ParameterExpression val = Expression.Parameter(typeof(UserPositions_Lang), "c");
			List<UserPositions_Lang> list = Enumerable.ToList<UserPositions_Lang>((IEnumerable<UserPositions_Lang>)Queryable.Where<UserPositions_Lang>((IQueryable<UserPositions_Lang>)userPositions_Lang, Expression.Lambda<Func<UserPositions_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<UserPositions> userPositions = _dbTbl.UserPositions;
			val = Expression.Parameter(typeof(UserPositions), "c");
			UserPositions userPositions2 = Queryable.FirstOrDefault<UserPositions>((IQueryable<UserPositions>)userPositions, Expression.Lambda<Func<UserPositions, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (userPositions2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<UserPositions_Lang, CommonMultiLanguageViewModel>((IEnumerable<UserPositions_Lang>)list, (Func<UserPositions_Lang, CommonMultiLanguageViewModel>)((UserPositions_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.PositionName,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = userPositions2.PositionName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<UserPositions_Lang, CommonMultiLanguageViewModel>((IEnumerable<UserPositions_Lang>)list, (Func<UserPositions_Lang, CommonMultiLanguageViewModel>)((UserPositions_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.PositionManager,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = userPositions2.PositionManager,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<UserPositions_Lang, CommonMultiLanguageViewModel>((IEnumerable<UserPositions_Lang>)list, (Func<UserPositions_Lang, CommonMultiLanguageViewModel>)((UserPositions_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.PositionAddress,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = userPositions2.PositionAddress,
				LanguageId = result
			});
			userPositionsLanguageViewModel = new UserPositionsLanguageViewModel
			{
				PositionId = userPositions2.PositionId,
				ParentId = userPositions2.ParentId,
				PositionName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				PositionName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				PositionCode = userPositions2.PositionCode,
				PositionManager = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				PositionManager_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				PositionAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				PositionAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				PositionTel = userPositions2.PositionTel,
				PositionEmail = userPositions2.PositionEmail,
				OrderView = userPositions2.OrderView,
				FirstRegisterUserId = userPositions2.FirstRegisterUserId,
				FirstRegisterDate = userPositions2.FirstRegisterDate,
				FirstRegisterDatePersian = userPositions2.FirstRegisterDatePersian,
				UserId = userPositions2.UserId,
				Year1 = userPositions2.Year1,
				Month1 = userPositions2.Month1,
				RegisterDate = userPositions2.RegisterDate,
				RegisterDatePersian = userPositions2.RegisterDatePersian,
				GUId = userPositions2.GUId,
				AppType = userPositions2.AppType,
				LanguageID = userPositions2.LanguageID
			};
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmManageUserPositions", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			userPositionsLanguageViewModel = new UserPositionsLanguageViewModel
			{
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDate = now,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture())
			};
			base.ViewBag.IsBuying = VersionBuyer.UserPosition;
		}
		return View(userPositionsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmManageUserPositionsDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(UserPositionsLanguageViewModel vm, HttpPostedFileBase[] fileSending)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PositionName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PositionName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.PositionName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PositionManager_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PositionManager_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.PositionManager,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PositionAddress_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PositionAddress_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.PositionAddress,
			LanguageId = lCID
		});
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (CS_0024_003C_003E8__locals0.vm.PositionId <= 0 && !VersionBuyer.UserPosition)
			{
				base.ViewBag.Error = "BV|" + Messages.VersionBuyWithoutCount;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			string text = "";
			if (CS_0024_003C_003E8__locals0.vm.PositionName == null && CS_0024_003C_003E8__locals0.vm.PositionName == "")
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.UserPositionName) + "<br/>";
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.PositionName, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.UserPositionName) + "<br>";
			}
			if (CS_0024_003C_003E8__locals0.vm.ParentId == 0)
			{
				CRMspSelectUserPositionsByParentId_Result cRMspSelectUserPositionsByParentId_Result = Enumerable.FirstOrDefault<CRMspSelectUserPositionsByParentId_Result>((IEnumerable<CRMspSelectUserPositionsByParentId_Result>)_db.CRMspSelectUserPositionsByParentId(0, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectUserPositionsByParentId_Result != null && cRMspSelectUserPositionsByParentId_Result.PositionId != CS_0024_003C_003E8__locals0.vm.PositionId)
				{
					text = text + string.Format(Messages.msgErrorHasSpecifiedMainUserPosition, cRMspSelectUserPositionsByParentId_Result.PositionNameWithCode ?? "") + "<br>";
				}
			}
			if (text != "")
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass9_1 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_1();
				DateTime now = DateTime.Now;
				DateTime dateTime = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				short num = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short num2 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass9_.model = new UserPositions();
				if (CS_0024_003C_003E8__locals0.vm.PositionId > 0)
				{
					DbSet<UserPositions> userPositions = _dbTbl.UserPositions;
					ParameterExpression val = Expression.Parameter(typeof(UserPositions), "c");
					_003C_003Ec__DisplayClass9_.model = Queryable.FirstOrDefault<UserPositions>((IQueryable<UserPositions>)userPositions, Expression.Lambda<Func<UserPositions, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass9_.model.ParentId = CS_0024_003C_003E8__locals0.vm.ParentId;
				_003C_003Ec__DisplayClass9_.model.PositionName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.PositionCode = CS_0024_003C_003E8__locals0.vm.PositionCode;
				_003C_003Ec__DisplayClass9_.model.PositionManager = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.PositionAddress = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.PositionTel = CS_0024_003C_003E8__locals0.vm.PositionTel;
				_003C_003Ec__DisplayClass9_.model.PositionEmail = CS_0024_003C_003E8__locals0.vm.PositionEmail;
				_003C_003Ec__DisplayClass9_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				_003C_003Ec__DisplayClass9_.model.UserId = userId;
				_003C_003Ec__DisplayClass9_.model.Year1 = num2;
				_003C_003Ec__DisplayClass9_.model.Month1 = num;
				_003C_003Ec__DisplayClass9_.model.RegisterDate = dateTime;
				_003C_003Ec__DisplayClass9_.model.RegisterDatePersian = text2;
				_003C_003Ec__DisplayClass9_.model.AppType = appType;
				if (_003C_003Ec__DisplayClass9_.model.PositionId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass9_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass9_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass9_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass9_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<UserPositions_Lang> userPositions_Lang = _dbTbl.UserPositions_Lang;
							ParameterExpression val = Expression.Parameter(typeof(UserPositions_Lang), "c");
							UserPositions_Lang userPositions_Lang2 = Queryable.FirstOrDefault<UserPositions_Lang>((IQueryable<UserPositions_Lang>)userPositions_Lang, Expression.Lambda<Func<UserPositions_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (userPositions_Lang2 != null)
							{
								userPositions_Lang2.PositionName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								userPositions_Lang2.PositionManager = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								userPositions_Lang2.PositionAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(userPositions_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							userPositions_Lang2 = new UserPositions_Lang();
							userPositions_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							userPositions_Lang2.PositionId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.PositionId;
							userPositions_Lang2.PositionName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							userPositions_Lang2.PositionManager = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							userPositions_Lang2.PositionAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.UserPositions_Lang.Add(userPositions_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass9_.model.FirstRegisterUserId = userId;
					_003C_003Ec__DisplayClass9_.model.FirstRegisterDate = dateTime;
					_003C_003Ec__DisplayClass9_.model.FirstRegisterDatePersian = text2;
					_003C_003Ec__DisplayClass9_.model.GUId = Guid.NewGuid();
					_003C_003Ec__DisplayClass9_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_dbTbl.UserPositions.Add(_003C_003Ec__DisplayClass9_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					if (_003C_003Ec__DisplayClass9_.model.PositionId <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							UserPositions_Lang userPositions_Lang3 = new UserPositions_Lang();
							userPositions_Lang3.LanguageID = lang.LanguageID;
							userPositions_Lang3.PositionId = _003C_003Ec__DisplayClass9_.model.PositionId;
							userPositions_Lang3.PositionName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							userPositions_Lang3.PositionManager = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							userPositions_Lang3.PositionAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.UserPositions_Lang.Add(userPositions_Lang3);
							_dbTbl.SaveChanges();
						}
						_db.CRMspInsertLinkedUserPositionsForParents(_003C_003Ec__DisplayClass9_.model.PositionId, userId, num2, num, dateTime, text2, appType, CS_0024_003C_003E8__locals0.defLangID, centerId);
						CS_0024_003C_003E8__locals0.vm.PositionId = _003C_003Ec__DisplayClass9_.model.PositionId;
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmManageUserPositions", ActionName = "actDelete")]
	public string ActDelete(int posId)
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
			if (!UserLogin.IsUserAccess("frmManageUserPositions", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (posId > 0)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteUserPositions(posId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "1";
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmManageUserPositions", ActionName = "actAddUser")]
	public ActionResult SearchUsers()
	{
		GetUserDepartments();
		GetResponsibles();
		GetRolls();
		return View();
	}

	[AjaxOnly]
	public ActionResult SearchUsers_Read([DataSourceRequest] DataSourceRequest request, string val = "", string fromPersCode = "0", string toPersCode = "0", string persCodes = "0", string departmentId = "0", string responsibleUserId = "0", string rollId = "0")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspUserPositionSearchUsers_Result> enumerable = new List<CRMspUserPositionSearchUsers_Result>();
		try
		{
			val = ((!string.IsNullOrEmpty(val)) ? val : "");
			fromPersCode = ((!string.IsNullOrEmpty(fromPersCode)) ? fromPersCode : "0");
			toPersCode = ((!string.IsNullOrEmpty(toPersCode)) ? toPersCode : "0");
			persCodes = ((!string.IsNullOrEmpty(persCodes)) ? persCodes : "0");
			departmentId = ((!string.IsNullOrEmpty(departmentId)) ? departmentId : "0");
			responsibleUserId = ((!string.IsNullOrEmpty(responsibleUserId)) ? responsibleUserId : "0");
			rollId = ((!string.IsNullOrEmpty(rollId)) ? rollId : "0");
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			enumerable = Enumerable.ToList<CRMspUserPositionSearchUsers_Result>(Enumerable.Where<CRMspUserPositionSearchUsers_Result>((IEnumerable<CRMspUserPositionSearchUsers_Result>)_db.CRMspUserPositionSearchUsers(val, fromPersCode, toPersCode, persCodes, departmentId, responsibleUserId, rollId, lCID, result, centerId), (Func<CRMspUserPositionSearchUsers_Result, bool>)((CRMspUserPositionSearchUsers_Result m) => m.UserId > 0)));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetUserDepartments()
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
			List<CRMspSelectUserDepartments_Result> list2 = Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)_db.CRMspSelectUserDepartments(lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectUserDepartments_Result>)list2, (Func<CRMspSelectUserDepartments_Result, SelectListItem>)((CRMspSelectUserDepartments_Result item) => new SelectListItem
			{
				Text = item.Department,
				Value = item.DepartmentID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserDepartment = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetResponsibles()
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.FName + " " + item.LName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserResponsible = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetRolls()
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
			List<CRMspSelectsysRolls_Result> list2 = Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)_db.CRMspSelectsysRolls(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectsysRolls_Result, SelectListItem>((IEnumerable<CRMspSelectsysRolls_Result>)list2, (Func<CRMspSelectsysRolls_Result, SelectListItem>)((CRMspSelectsysRolls_Result item) => new SelectListItem
			{
				Text = (item.RollName ?? ""),
				Value = item.ID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserRolls = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string UpdateUsersPosition(string actionName, int mode, int? crmUserId = null, int? posId = null, string crmUserIds = null)
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
			if (!UserLogin.IsUserAccess("frmManageUserPositions", actionName, UserLogin.CurrentUser))
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			_db.CRMspUpdateUsersPositionId(mode, crmUserId, posId, crmUserIds, userId, value, registerDatePersian, value2, appType, centerId);
			if (mode != 3 && mode != 4)
			{
				if (crmUserId.HasValue)
				{
					_db.CRMspInsertLinkedUserPositionsByUserId(crmUserId, posId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId);
				}
				else if (!string.IsNullOrEmpty(crmUserIds) && posId.HasValue)
				{
					_db.CRMspInsertLinkedUserPositionsByUserIds(crmUserIds, posId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId);
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmManageUserPositions", ActionName = "actTransferUsers")]
	public ActionResult TransferUsersToOtherPosition()
	{
		return View();
	}

	[AjaxOnly]
	public string TransferUsersToAnotherPosition(int oldPosId, int posId, string crmUserIds)
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
			if (!UserLogin.IsUserAccess("frmManageUserPositions", "actTransferUsers", UserLogin.CurrentUser))
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			_db.CRMspTransferUsersToAnotherPosition(oldPosId, posId, crmUserIds, userId, value, registerDatePersian, value2, appType, centerId);
			if (!string.IsNullOrEmpty(crmUserIds))
			{
				_db.CRMspInsertLinkedUserPositionsByUserIds(crmUserIds, posId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId);
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actuLinkedUserPositions")]
	public ActionResult Linked()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			foreach (CRMspSelectLinkedType_Result item in Enumerable.ToList<CRMspSelectLinkedType_Result>((IEnumerable<CRMspSelectLinkedType_Result>)_db.CRMspSelectLinkedType(lCID, result)))
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.LinkedTypeId + "|" + item.TypeOrder));
				treeViewItemModel.Id = item.LinkedTypeId + "|" + item.TypeOrder;
				treeViewItemModel.Text = item.LinkTypeName;
				treeViewItemModel.ImageUrl = "";
				treeViewItemModel.Items = null;
				list.Add(treeViewItemModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkedTypeTree = list;
		return View();
	}

	public List<TreeViewItemModel> GetUnLinkedUserPositionNodeTree(List<CRMspSelectUnLinkedUserPositionsForLinkedType_Result> lstPositions, int? posId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectUnLinkedUserPositionsForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>(Enumerable.Where<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>)lstPositions, (Func<CRMspSelectUnLinkedUserPositionsForLinkedType_Result, bool>)((CRMspSelectUnLinkedUserPositionsForLinkedType_Result m) => m.ParentId == posId)));
			if (Enumerable.Any<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>)list2))
			{
				foreach (CRMspSelectUnLinkedUserPositionsForLinkedType_Result item in list2)
				{
					int valueOrDefault = item.IsLinkedUserPosition.GetValueOrDefault();
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.PositionId.ToString()));
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("isLinkedPos", valueOrDefault.ToString()));
					treeViewItemModel.Id = item.PositionId.ToString();
					treeViewItemModel.Text = item.PositionNameWithCode;
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> unLinkedUserPositionNodeTree = GetUnLinkedUserPositionNodeTree(lstPositions, item.PositionId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(unLinkedUserPositionNodeTree);
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<TreeViewItemModel> GetUnLinkedUserPositionTree(int posId, int linkedTypeId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
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
			List<CRMspSelectUnLinkedUserPositionsForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>)_db.CRMspSelectUnLinkedUserPositionsForLinkedType(posId, linkedTypeId, lCID, result, result2));
			if (Enumerable.Any<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>)list2))
			{
				List<CRMspSelectUnLinkedUserPositionsForLinkedType_Result> list3 = Enumerable.ToList<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>(Enumerable.Where<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>)list2, (Func<CRMspSelectUnLinkedUserPositionsForLinkedType_Result, bool>)((CRMspSelectUnLinkedUserPositionsForLinkedType_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectUnLinkedUserPositionsForLinkedType_Result>)list3))
				{
					foreach (CRMspSelectUnLinkedUserPositionsForLinkedType_Result item in list3)
					{
						int valueOrDefault = item.IsLinkedUserPosition.GetValueOrDefault();
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.PositionId.ToString()));
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("isLinkedPos", valueOrDefault.ToString()));
						treeViewItemModel.Id = item.PositionId.ToString();
						treeViewItemModel.Text = item.PositionNameWithCode;
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> unLinkedUserPositionNodeTree = GetUnLinkedUserPositionNodeTree(list2, item.PositionId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(unLinkedUserPositionNodeTree);
						list.Add(treeViewItemModel);
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialUnLinkedUserPositionsTree(int posId, int linkedTypeId)
	{
		try
		{
			List<TreeViewItemModel> unLinkedUserPositionTree = GetUnLinkedUserPositionTree(posId, linkedTypeId);
			base.ViewBag.UnLinkedUserPositionsTree = unLinkedUserPositionTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	public List<TreeViewItemModel> GetLinkedUserPositionNodeTree(List<CRMspSelectLinkedUserPositionsForLinkedType_Result> lstPositions, int? posId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectLinkedUserPositionsForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectLinkedUserPositionsForLinkedType_Result>(Enumerable.Where<CRMspSelectLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectLinkedUserPositionsForLinkedType_Result>)lstPositions, (Func<CRMspSelectLinkedUserPositionsForLinkedType_Result, bool>)((CRMspSelectLinkedUserPositionsForLinkedType_Result m) => m.ParentId == posId)));
			if (Enumerable.Any<CRMspSelectLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectLinkedUserPositionsForLinkedType_Result>)list2))
			{
				foreach (CRMspSelectLinkedUserPositionsForLinkedType_Result item in list2)
				{
					int valueOrDefault = item.IsLinkedUserPosition.GetValueOrDefault();
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.PositionId.ToString()));
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("isLinkedPos", valueOrDefault.ToString()));
					treeViewItemModel.Id = item.PositionId.ToString();
					treeViewItemModel.Text = item.PositionNameWithCode;
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> linkedUserPositionNodeTree = GetLinkedUserPositionNodeTree(lstPositions, item.PositionId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(linkedUserPositionNodeTree);
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<TreeViewItemModel> GetLinkedUserPositionTree(int posId, int linkedTypeId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
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
			List<CRMspSelectLinkedUserPositionsForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectLinkedUserPositionsForLinkedType_Result>)_db.CRMspSelectLinkedUserPositionsForLinkedType(posId, linkedTypeId, lCID, result, result2));
			if (Enumerable.Any<CRMspSelectLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectLinkedUserPositionsForLinkedType_Result>)list2))
			{
				List<CRMspSelectLinkedUserPositionsForLinkedType_Result> list3 = Enumerable.ToList<CRMspSelectLinkedUserPositionsForLinkedType_Result>(Enumerable.Where<CRMspSelectLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectLinkedUserPositionsForLinkedType_Result>)list2, (Func<CRMspSelectLinkedUserPositionsForLinkedType_Result, bool>)((CRMspSelectLinkedUserPositionsForLinkedType_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspSelectLinkedUserPositionsForLinkedType_Result>((IEnumerable<CRMspSelectLinkedUserPositionsForLinkedType_Result>)list3))
				{
					foreach (CRMspSelectLinkedUserPositionsForLinkedType_Result item in list3)
					{
						int valueOrDefault = item.IsLinkedUserPosition.GetValueOrDefault();
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.PositionId.ToString()));
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("isLinkedPos", valueOrDefault.ToString()));
						treeViewItemModel.Id = item.PositionId.ToString();
						treeViewItemModel.Text = item.PositionNameWithCode;
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> linkedUserPositionNodeTree = GetLinkedUserPositionNodeTree(list2, item.PositionId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(linkedUserPositionNodeTree);
						list.Add(treeViewItemModel);
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialLinkedUserPositionsTree(int posId, int linkedTypeId)
	{
		try
		{
			List<TreeViewItemModel> linkedUserPositionTree = GetLinkedUserPositionTree(posId, linkedTypeId);
			base.ViewBag.LinkedUserPositionsTree = linkedUserPositionTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public string ActAssign(int linkedTypeId, int posId, string linkedPositionIds, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
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
			if (!UserLogin.IsUserAccess("frmLinkedUserPositions", "actAssign", UserLogin.CurrentUser))
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedUserPositionsForPositions(linkedTypeId, posId, linkedPositionIds, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
			if (mct_Result != null)
			{
				int result3 = 0;
				int.TryParse(mct_Result.Result.ToString(), out result3);
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
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedUserPositionsForPositions(23, posId, linkedPositionIds, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result4 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result4);
						if (result4 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedUserPositionsForPositions(24, posId, linkedPositionIds, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedUserPositionsForPositions(25, posId, linkedPositionIds, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result6);
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
	public string ActRemove(int linkedTypeId, int posId, string linkedPositionIds, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
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
			if (!UserLogin.IsUserAccess("frmLinkedUserPositions", "actRemove", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedUserPositionsForPositions(linkedTypeId, posId, linkedPositionIds, result3));
			if (mct_Result != null)
			{
				int result4 = 0;
				int.TryParse(mct_Result.Result.ToString(), out result4);
				if (result4 == 0)
				{
					return Messages.msgErrorRunFunction;
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedUserPositionsForPositions(23, posId, linkedPositionIds, result3));
					if (mct_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedUserPositionsForPositions(24, posId, linkedPositionIds, result3));
					if (mct_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result6);
						if (result6 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedUserPositionsForPositions(25, posId, linkedPositionIds, result3));
					if (mct_Result != null)
					{
						int result7 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result7);
						if (result7 == 0)
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
	public string ActAssignAll(int linkedTypeId, int posId, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
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
			if (!UserLogin.IsUserAccess("frmLinkedUserPositions", "actAssignAll", UserLogin.CurrentUser))
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedUserPositionsForPositionAll(linkedTypeId, posId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
			if (mct_Result != null)
			{
				int result3 = 0;
				int.TryParse(mct_Result.Result.ToString(), out result3);
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
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedUserPositionsForPositionAll(23, posId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result4 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result4);
						if (result4 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedUserPositionsForPositionAll(24, posId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedUserPositionsForPositionAll(25, posId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result6);
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
	public string ActRemoveAll(int linkedTypeId, int posId, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
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
			if (!UserLogin.IsUserAccess("frmLinkedUserPositions", "actRemoveAll", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedUserPositionsForPositionAll(linkedTypeId, posId, result3));
			if (mct_Result != null)
			{
				int result4 = 0;
				int.TryParse(mct_Result.Result.ToString(), out result4);
				if (result4 == 0)
				{
					return Messages.msgErrorRunFunction;
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedUserPositionsForPositionAll(23, posId, result3));
					if (mct_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedUserPositionsForPositionAll(24, posId, result3));
					if (mct_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result6);
						if (result6 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedUserPositionPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedUserPositionsForPositionAll(25, posId, result3));
					if (mct_Result != null)
					{
						int result7 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result7);
						if (result7 == 0)
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
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
