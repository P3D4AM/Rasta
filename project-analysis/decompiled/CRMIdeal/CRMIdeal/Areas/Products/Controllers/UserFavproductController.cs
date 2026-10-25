using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
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

namespace CRMIdeal.Areas.Products.Controllers;

public class UserFavproductController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int userFavproductItemId;

		public bool curentCheckedr;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int userFavPrdItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public WSspSelectUserFavproductsByUserId_Result item;

		internal bool _003CGetUserFavproductsByUserId_003Eb__9(CRMspSelectUsers_Result c)
		{
			return c.UserId == item.FirstRegisterUserId;
		}

		internal bool _003CGetUserFavproductsByUserId_003Eb__10(CRMspSelectUsers_Result c)
		{
			return c.UserId == item.UserId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int userFavId;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__19;

		internal bool _003CUserFavInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__19(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals1;

		internal bool _003CUserFavInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserFavInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	public ActionResult Index(int position, int masterId, int mode)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmPreOrder";
			text2 = "actMyFavproduct";
			break;
		case 2:
			text = "frmOrder";
			text2 = "actMyFavproduct";
			break;
		case 3:
			text = "frmBuyOrder";
			text2 = "actMyFavproduct";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.masterId = masterId;
		base.ViewBag.mode = mode;
		base.ViewBag.ParentName = text;
		GetPrdPriceGroup(mode);
		GetFavPrdPriceGroup();
		WSUserFavproductsLanguageViewModel model = new WSUserFavproductsLanguageViewModel();
		return View(model);
	}

	public ActionResult TransferToOtherUser(int userFavId)
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
		List<CRMspSelectUserForLinkedType_Result> list = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 2, lCID, result, result2));
		List<SelectListItem> list2 = new List<SelectListItem>();
		list2.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
		{
			Text = item.UserName,
			Value = item.LinkedUserId.ToString(),
			Selected = false
		})));
		base.ViewBag.UserList = list2;
		base.ViewBag.userFavId = userFavId;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialUserFavproduct(int favId = 0)
	{
		base.ViewBag.favId = favId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult UserFavproduct_Read([DataSourceRequest] DataSourceRequest request, int favId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectUserFavproductItems_Result> list = new List<WSspSelectUserFavproductItems_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectUserFavproductItems_Result>((IEnumerable<WSspSelectUserFavproductItems_Result>)_db.WSspSelectUserFavproductItems(favId, lCID, result));
			List<CommonMultiSelectorViewModel> list2 = new List<CommonMultiSelectorViewModel>();
			if (list != null && Enumerable.Any<WSspSelectUserFavproductItems_Result>((IEnumerable<WSspSelectUserFavproductItems_Result>)list))
			{
				foreach (WSspSelectUserFavproductItems_Result item2 in list)
				{
					CommonMultiSelectorViewModel item = new CommonMultiSelectorViewModel
					{
						Id = item2.UserFavproductItemId,
						Selected = item2.Selector.GetValueOrDefault()
					};
					list2.Add(item);
				}
			}
			if (list2 != null && Enumerable.Any<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)list2))
			{
				string text = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)list2));
				if (!string.IsNullOrWhiteSpace(text))
				{
					foreach (WSspSelectUserFavproductItems_Result item3 in list)
					{
						item3.AppType = text;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public JsonResult GetUserFavproductsByUserId()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonDroupDownItemViewModel> list = new List<CommonDroupDownItemViewModel>();
		try
		{
			List<WSspSelectUserFavproductsByUserId_Result> list2 = Enumerable.ToList<WSspSelectUserFavproductsByUserId_Result>((IEnumerable<WSspSelectUserFavproductsByUserId_Result>)_db.WSspSelectUserFavproductsByUserId(UserLogin.CurrentUser.UserId, result, result));
			List<CRMspSelectUsers_Result> list3 = CRMIdeal.Classes.Helper.User.SelectUsers(0);
			using List<WSspSelectUserFavproductsByUserId_Result>.Enumerator enumerator = list2.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass7_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass7_1();
				CS_0024_003C_003E8__locals1.item = enumerator.Current;
				DbSet<WSUserFavproducts_Lang> wSUserFavproducts_Lang = _dbTbl.WSUserFavproducts_Lang;
				ParameterExpression val = Expression.Parameter(typeof(WSUserFavproducts_Lang), "c");
				List<WSUserFavproducts_Lang> list4 = Enumerable.ToList<WSUserFavproducts_Lang>((IEnumerable<WSUserFavproducts_Lang>)Queryable.Where<WSUserFavproducts_Lang>((IQueryable<WSUserFavproducts_Lang>)wSUserFavproducts_Lang, Expression.Lambda<Func<WSUserFavproducts_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSUserFavproducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSUserFavproducts_Lang>)list4, (Func<WSUserFavproducts_Lang, CommonMultiLanguageViewModel>)((WSUserFavproducts_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.FavprdTitle,
					LanguageId = myitem.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals1.item.FavprdTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSUserFavproducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSUserFavproducts_Lang>)list4, (Func<WSUserFavproducts_Lang, CommonMultiLanguageViewModel>)((WSUserFavproducts_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.FavprdDesc,
					LanguageId = myitem.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals1.item.FavprdDesc,
					LanguageId = result
				});
				string text = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				string text2 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				string text3 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				string text4 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.item.AppType))
				{
					CS_0024_003C_003E8__locals1.item.AppType = Configuration.AppType;
				}
				CS_0024_003C_003E8__locals1.item.AppType = Configuration.GetAppType(CS_0024_003C_003E8__locals1.item.AppType);
				string text5 = CS_0024_003C_003E8__locals1.item.FirstRegisterUser ?? "";
				string text6 = CS_0024_003C_003E8__locals1.item.EditUser ?? "";
				if (result != currLangID && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list3))
				{
					CS_0024_003C_003E8__locals1.item.FirstRegisterUserId = CS_0024_003C_003E8__locals1.item.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
					CRMspSelectUsers_Result cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list3, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId == CS_0024_003C_003E8__locals1.item.FirstRegisterUserId));
					text5 = ((cRMspSelectUsers_Result != null) ? (cRMspSelectUsers_Result.LName + ((cRMspSelectUsers_Result.FName != null) ? (" " + cRMspSelectUsers_Result.FName) : "")) : "");
					WSspSelectUserFavproductsByUserId_Result item = CS_0024_003C_003E8__locals1.item;
					_ = CS_0024_003C_003E8__locals1.item.UserId;
					item.UserId = CS_0024_003C_003E8__locals1.item.UserId;
					CRMspSelectUsers_Result cRMspSelectUsers_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list3, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId == CS_0024_003C_003E8__locals1.item.UserId));
					text6 = ((cRMspSelectUsers_Result2 != null) ? (cRMspSelectUsers_Result2.LName + ((cRMspSelectUsers_Result2.FName != null) ? (" " + cRMspSelectUsers_Result2.FName) : "")) : "");
				}
				string text7 = (CS_0024_003C_003E8__locals1.item.FirstRegisterDate.HasValue ? CS_0024_003C_003E8__locals1.item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				CS_0024_003C_003E8__locals1.item.FirstRegisterUser = Labels.frmFirstRegisterUser + ":" + text5 + " (" + text7 + ")";
				_ = CS_0024_003C_003E8__locals1.item.RegisterDate;
				string text8 = CS_0024_003C_003E8__locals1.item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				CS_0024_003C_003E8__locals1.item.EditUser = Labels.frmRegisterUser + ":" + text6 + " (" + Labels.AppType + ":" + CS_0024_003C_003E8__locals1.item.AppType + ")  (" + text8 + ")";
				string text9 = ((!CS_0024_003C_003E8__locals1.item.FavprdInActive.HasValue || CS_0024_003C_003E8__locals1.item.FavprdInActive == false) ? "false" : "true");
				string text10 = ((!CS_0024_003C_003E8__locals1.item.FavprdUseInIssueQuick.HasValue || CS_0024_003C_003E8__locals1.item.FavprdUseInIssueQuick == false) ? "false" : "true");
				string text11 = ((CS_0024_003C_003E8__locals1.item.OrderView.HasValue && CS_0024_003C_003E8__locals1.item.OrderView > 0) ? CS_0024_003C_003E8__locals1.item.OrderView.ToString() : "");
				list.Add(new CommonDroupDownItemViewModel
				{
					Text = text + "|" + text3 + "|" + text2 + "|" + text4 + "|" + CS_0024_003C_003E8__locals1.item.FirstRegisterUser + "|" + CS_0024_003C_003E8__locals1.item.EditUser + "|0|" + text9 + "|" + text10 + "|" + text11,
					Value = CS_0024_003C_003E8__locals1.item.UserFavproductId.ToString()
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string UserFavDelete(int userFavId)
	{
		string result = "";
		try
		{
			if (userFavId > 0)
			{
				if (_dbTbl.WSUserFavproducts.Find(userFavId) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSUserFavproducts(userFavId)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							result = "1";
						}
						else if (mct_Result != null && mct_Result.Result == 0)
						{
							result = Messages.RedundancyMessage;
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSUserFavproducts", UserLogin.CurrentUser.UserId);
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
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string UserFavInsertEdit(string userFavTitle, string userFavDesc, int userFavId, string userFavTitleLang, string userFavDescLang, bool favprdInActive, bool favprdUseInIssueQuick)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.userFavId = userFavId;
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(userFavTitleLang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userFavTitleLang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = userFavTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(userFavDescLang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userFavDescLang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = userFavDesc,
				LanguageId = lCID
			});
			string text2 = "";
			if (userFavTitle == "")
			{
				text2 = text2 + Messages.CheckTitle + "<br/>";
			}
			else if (!checkMultiLanguage(userFavTitle, list))
			{
				text2 = text2 + Messages.CheckTitleLang + "<br>";
			}
			if (text2 != "")
			{
				return text2;
			}
			WSUserFavproducts wSUserFavproducts = new WSUserFavproducts();
			if (CS_0024_003C_003E8__locals0.userFavId > 0)
			{
				DbSet<WSUserFavproducts> wSUserFavproducts2 = _dbTbl.WSUserFavproducts;
				ParameterExpression val = Expression.Parameter(typeof(WSUserFavproducts), "c");
				wSUserFavproducts = Queryable.FirstOrDefault<WSUserFavproducts>((IQueryable<WSUserFavproducts>)wSUserFavproducts2, Expression.Lambda<Func<WSUserFavproducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSUserFavproducts != null)
				{
					wSUserFavproducts.FavprdTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSUserFavproducts.FavprdDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSUserFavproducts.UserId = UserLogin.CurrentUser.UserId;
					wSUserFavproducts.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					wSUserFavproducts.RegisterDate = DateTime.Now;
					wSUserFavproducts.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					wSUserFavproducts.AppType = Configuration.AppType;
					wSUserFavproducts.FavprdInActive = favprdInActive;
					wSUserFavproducts.FavprdUseInIssueQuick = favprdUseInIssueQuick;
					_dbTbl.Entry(wSUserFavproducts).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass9_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSUserFavproducts_Lang> wSUserFavproducts_Lang = _dbTbl.WSUserFavproducts_Lang;
							val = Expression.Parameter(typeof(WSUserFavproducts_Lang), "c");
							WSUserFavproducts_Lang wSUserFavproducts_Lang2 = Queryable.FirstOrDefault<WSUserFavproducts_Lang>((IQueryable<WSUserFavproducts_Lang>)wSUserFavproducts_Lang, Expression.Lambda<Func<WSUserFavproducts_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSUserFavproducts_Lang2 != null)
							{
								wSUserFavproducts_Lang2.FavprdTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSUserFavproducts_Lang2.FavprdDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSUserFavproducts_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSUserFavproducts_Lang2 = new WSUserFavproducts_Lang();
							wSUserFavproducts_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							wSUserFavproducts_Lang2.UserFavproductId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.userFavId;
							wSUserFavproducts_Lang2.FavprdTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSUserFavproducts_Lang2.FavprdDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.WSUserFavproducts_Lang.Add(wSUserFavproducts_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSUserFavproducts", UserLogin.CurrentUser.UserId);
					return "1";
				}
				return Messages.ErrorNotFound;
			}
			wSUserFavproducts = new WSUserFavproducts
			{
				FavprdTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null),
				FavprdDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null),
				UserId = UserLogin.CurrentUser.UserId,
				Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture())),
				RegisterDate = DateTime.Now,
				RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()),
				GUId = Guid.NewGuid(),
				AppType = Configuration.AppType,
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = DateTime.Now,
				FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()),
				LanguageID = CS_0024_003C_003E8__locals0.defLangID,
				FavprdInActive = favprdInActive,
				FavprdUseInIssueQuick = favprdUseInIssueQuick
			};
			_dbTbl.WSUserFavproducts.Add(wSUserFavproducts);
			_dbTbl.SaveChanges();
			foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
			{
				WSUserFavproducts_Lang wSUserFavproducts_Lang3 = new WSUserFavproducts_Lang();
				wSUserFavproducts_Lang3.LanguageID = lang.LanguageID;
				wSUserFavproducts_Lang3.UserFavproductId = wSUserFavproducts.UserFavproductId;
				wSUserFavproducts_Lang3.FavprdTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
				wSUserFavproducts_Lang3.FavprdDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
				_dbTbl.WSUserFavproducts_Lang.Add(wSUserFavproducts_Lang3);
				_dbTbl.SaveChanges();
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSUserFavproducts", UserLogin.CurrentUser.UserId);
			return "1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
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
	public string SelectForInsertInMaster(string parentName, int masterId, int userFavId, int? priceGroupId, bool? addLinkedPrd, string selectedUserFavproductItemIds)
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
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (userFavId > 0 && masterId > 0)
			{
				if (!string.IsNullOrWhiteSpace(selectedUserFavproductItemIds))
				{
					List<WSspSelectUserFavproductItems_Result> list = Enumerable.ToList<WSspSelectUserFavproductItems_Result>((IEnumerable<WSspSelectUserFavproductItems_Result>)_db.WSspSelectUserFavproductItems(userFavId, lCID, result2));
					string text = "";
					if (list != null)
					{
						foreach (WSspSelectUserFavproductItems_Result item in list)
						{
							if (text != "")
							{
								text += ",";
							}
							text += item.UserFavproductItemId;
						}
					}
					ObjectParameter errorMessage = new ObjectParameter("errorMessage", "");
					_dbI.WSspUpdateUserFavProductItemsSelector(selectedUserFavproductItemIds, userFavId, errorMessage);
					if (text != selectedUserFavproductItemIds)
					{
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSUserFavproductItems", UserLogin.CurrentUser.UserId);
					}
				}
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				switch (parentName)
				{
				case "frmPreOrder":
				{
					if (PreOrder.IsFixed(masterId))
					{
						return "0|" + Messages.msgErrorNotActiveProd;
					}
					if (PreOrder.IsSentToLinkAccByAction(masterId))
					{
						return "0|" + string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					}
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspInsertPreOrderItemFromUserFav(userFavId, masterId, UserLogin.CurrentUser.UserId, Financial.Get().Id, value, registerDatePersian, Configuration.AppType, priceGroupId, result2, addLinkedPrd, centerId));
					result = ((mct_Result != null && mct_Result.Result > 0) ? ((!PreOrder.CalcAndSetPreOrderAmounts(masterId)) ? ("0|" + Messages.msgErrorInCalculation) : ("1|" + Messages.frmFormBaseInsertSuccessFulMessage)) : ((mct_Result == null || mct_Result.Result != 0) ? ("0|" + Messages.msgErrorDupProductInList) : ("0|" + Messages.msgErrorRunFunction)));
					break;
				}
				case "frmOrder":
				{
					if (Order.IsFixed(masterId))
					{
						return "0|" + Messages.msgErrorNotActiveProd;
					}
					if (Order.IsSentToLinkAccByAction(masterId))
					{
						return "0|" + string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					}
					mct_Result mct_Result2 = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspInsertOrderItemFromUserFav(userFavId, masterId, UserLogin.CurrentUser.UserId, Financial.Get().Id, value, registerDatePersian, Configuration.AppType, priceGroupId, result2, addLinkedPrd, centerId));
					result = ((mct_Result2 != null && mct_Result2.Result > 0) ? ((!Order.CalcAndSetOrderAmounts(masterId)) ? ("0|" + Messages.msgErrorInCalculation) : ("1|" + Messages.frmFormBaseInsertSuccessFulMessage)) : ((mct_Result2 == null || mct_Result2.Result != 0) ? ("0|" + Messages.msgErrorDupProductInList) : ("0|" + Messages.msgErrorRunFunction)));
					break;
				}
				case "frmBuyOrder":
				{
					if (BuyOrder.IsFixed(masterId))
					{
						return "0|" + Messages.msgErrorNotActiveProd;
					}
					if (BuyOrder.IsSentToLinkAccByAction(masterId))
					{
						return "0|" + string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					}
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspInsertBuyOrderItemFromUserFav(userFavId, masterId, UserLogin.CurrentUser.UserId, Financial.Get().Id, value, registerDatePersian, Configuration.AppType, priceGroupId, result2, addLinkedPrd, centerId));
					result = ((mct_I_Result != null && mct_I_Result.Result > 0) ? ((!BuyOrder.CalcAndSetOrderAmounts(masterId)) ? ("0|" + Messages.msgErrorInCalculation) : ("1|" + Messages.frmFormBaseInsertSuccessFulMessage)) : ((mct_I_Result == null || mct_I_Result.Result != 0) ? ("0|" + Messages.msgErrorDupProductInList) : ("0|" + Messages.msgErrorRunFunction)));
					break;
				}
				}
			}
			else
			{
				result = "0|" + Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "0|" + Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string TransferUserFavProduct(int userFavId, int userId)
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
			if (userFavId > 0 && userId != 0 && userId != UserLogin.CurrentUser.UserId)
			{
				DateTime now = DateTime.Now;
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspTransferUserFavProduct(userFavId, userId, UserLogin.CurrentUser.UserId, Financial.Get().Id, short.Parse(now.ToString("MM", new PersianCulture())), now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, result2));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					result = "1|" + Messages.frmFormBaseInsertSuccessFulMessage;
				}
				else if (mct_Result != null && mct_Result.Result == 0)
				{
					result = "0|" + Messages.msgErrorRunFunction;
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSUserFavproducts", userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSUserFavproductItems", userId);
			}
			else
			{
				result = "0|" + Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "0|" + Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string UserFavproductItemsChangeSelector(int userFavproductItemId, bool curentCheckedr)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_.userFavproductItemId = userFavproductItemId;
		_003C_003Ec__DisplayClass13_.curentCheckedr = curentCheckedr;
		string result = "";
		try
		{
			DbSet<WSUserFavproductItems> wSUserFavproductItems = _dbTbl.WSUserFavproductItems;
			ParameterExpression val = Expression.Parameter(typeof(WSUserFavproductItems), "c");
			WSUserFavproductItems wSUserFavproductItems2 = Queryable.FirstOrDefault<WSUserFavproductItems>((IQueryable<WSUserFavproductItems>)wSUserFavproductItems, Expression.Lambda<Func<WSUserFavproductItems, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.OrElse((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Not((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), typeof(bool?))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)(bool?)null, typeof(bool?))))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSUserFavproductItems2 != null)
			{
				wSUserFavproductItems2.Selector = _003C_003Ec__DisplayClass13_.curentCheckedr;
				_dbTbl.Entry(wSUserFavproductItems2).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSUserFavproductItems", UserLogin.CurrentUser.UserId);
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			result = Messages.frmErrorMessage + "<br/ >" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			result = Messages.frmErrorMessage + "<br/ >" + ex2.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string UserFavProductItemDelete(int userFavPrdItemId)
	{
		_003C_003Ec__DisplayClass14_0 _003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_0();
		_003C_003Ec__DisplayClass14_.userFavPrdItemId = userFavPrdItemId;
		string result = "";
		try
		{
			if (_003C_003Ec__DisplayClass14_.userFavPrdItemId > 0)
			{
				DbSet<WSUserFavproductItems> wSUserFavproductItems = _dbTbl.WSUserFavproductItems;
				ParameterExpression val = Expression.Parameter(typeof(WSUserFavproductItems), "c");
				if (Queryable.FirstOrDefault<WSUserFavproductItems>((IQueryable<WSUserFavproductItems>)wSUserFavproductItems, Expression.Lambda<Func<WSUserFavproductItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass14_, typeof(_003C_003Ec__DisplayClass14_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSUserFavproductItems(_003C_003Ec__DisplayClass14_.userFavPrdItemId)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							result = "1";
						}
						else if (mct_Result != null && mct_Result.Result == 0)
						{
							result = Messages.RedundancyMessage;
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSUserFavproductItems", UserLogin.CurrentUser.UserId);
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
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	public void GetPrdPriceGroup(int type)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (type == 1)
			{
				List<WSspSelectProductCostGroup_Result> list2 = Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result));
				list.AddRange(Enumerable.Select<WSspSelectProductCostGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductCostGroup_Result>)list2, (Func<WSspSelectProductCostGroup_Result, SelectListItem>)((WSspSelectProductCostGroup_Result item) => new SelectListItem
				{
					Text = item.ProductCostGroupName,
					Value = item.ProductCostGroupID.ToString(),
					Selected = false
				})));
			}
			else
			{
				List<WSspSelectProductPriceGroup_Result> list3 = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
				SelectListItem item2 = new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = "0",
					Selected = false
				};
				list.Add(item2);
				list.AddRange(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)list3, (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result item) => new SelectListItem
				{
					Text = item.ProductPriceGroupName,
					Value = item.ProductPriceGroupID.ToString(),
					Selected = false
				})));
			}
			base.ViewBag.PriceGroupList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void GetFavPrdPriceGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectProductPriceGroup_Result> list2 = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)list2, (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result item) => new SelectListItem
			{
				Text = item.ProductPriceGroupName,
				Value = item.ProductPriceGroupID.ToString(),
				Selected = false
			})));
			base.ViewBag.FavPrdPriceGroupList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
