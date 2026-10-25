using System;
using System.Collections;
using System.Collections.Generic;
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
using CRM.General.Utilities;
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

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class DiscountsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public WSPreOrderDiscountsLanguageViewModel vm;

		public int defLangID;

		internal bool _003CInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel m)
		{
			return m.LanguageId != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel m)
		{
			return m.LanguageId != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int pordDisId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int pordDisId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public List<WSspSelectPreOrderDiscounts_Result> ListPreOrderDiscounts(int pordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectPreOrderDiscounts_Result> list = new List<WSspSelectPreOrderDiscounts_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectPreOrderDiscounts_Result>((IEnumerable<WSspSelectPreOrderDiscounts_Result>)_dbII.WSspSelectPreOrderDiscounts(pordId, lCID, result));
			foreach (WSspSelectPreOrderDiscounts_Result item in list)
			{
				_ = item.FirstRegisterDate;
				item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd");
				item.pordDisPrdName += ((!string.IsNullOrWhiteSpace(item.pordDisPrdCode)) ? (" (" + item.pordDisPrdCode + ")") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult PreOrderDiscounts_Read([DataSourceRequest] DataSourceRequest request, int pordId)
	{
		return Json(((IEnumerable)ListPreOrderDiscounts(pordId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actDeleteDis")]
	public string ActDelete(int pordId, int pordDisId)
	{
		_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_0();
		_003C_003Ec__DisplayClass6_.pordDisId = pordDisId;
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass6_.pordDisId > 0)
			{
				if (PreOrder.IsFixed(pordId))
				{
					return Messages.msgErrorNotActiveProd;
				}
				if (PreOrder.IsSentToLinkAccByAction(pordId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				}
				DbSet<WSPreOrderDiscounts> wSPreOrderDiscounts = _dbTbl.WSPreOrderDiscounts;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrderDiscounts), "m");
				if (Queryable.FirstOrDefault<WSPreOrderDiscounts>((IQueryable<WSPreOrderDiscounts>)wSPreOrderDiscounts, Expression.Lambda<Func<WSPreOrderDiscounts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass6_, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeletePreOrderDiscount(_003C_003Ec__DisplayClass6_.pordDisId));
						int result2 = 0;
						if (mct_II_Result != null)
						{
							int.TryParse(mct_II_Result.Result.ToString(), out result2);
						}
						if (result2 > 0)
						{
							WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
							if (wSspSelectPreOrderWithId_Result != null && wSspSelectPreOrderWithId_Result.pordReferUserId.GetValueOrDefault() != 0)
							{
								Info.Update(wSspSelectPreOrderWithId_Result.pordReferUserId.GetValueOrDefault(), true);
							}
							return "1";
						}
						return Messages.RedundancyMessage;
					}
					catch (DbEntityValidationException e)
					{
						ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
						return Messages.msgErrorRunFunction;
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
					}
				}
				return Messages.ErrorNotFound;
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actDeleteDisAll")]
	public string ActDeleteAll(int pordId)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (PreOrder.IsFixed(pordId))
			{
				return Messages.msgErrorNotActiveProd;
			}
			if (PreOrder.IsSentToLinkAccByAction(pordId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			try
			{
				mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeletePreOrderDiscountAll(pordId));
				int result2 = 0;
				if (mct_II_Result != null)
				{
					int.TryParse(mct_II_Result.Result.ToString(), out result2);
				}
				if (result2 > 0)
				{
					WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
					if (wSspSelectPreOrderWithId_Result != null && wSspSelectPreOrderWithId_Result.pordReferUserId.GetValueOrDefault() != 0)
					{
						Info.Update(wSspSelectPreOrderWithId_Result.pordReferUserId.GetValueOrDefault(), true);
					}
					return "1";
				}
				return Messages.RedundancyMessage;
			}
			catch (DbEntityValidationException e)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
				return Messages.msgErrorRunFunction;
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	public void SetRegisterInfo(WSPreOrderDiscountsLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (model == null)
			{
				return;
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId);
			if (cRMspSelectUsersById_Result != null)
			{
				firstRegInfo = cRMspSelectUsersById_Result.FullName ?? "";
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
			if (cRMspSelectUsersById_Result2 != null)
			{
				regInfo = cRMspSelectUsersById_Result2.FullName ?? "";
				_ = model.RegisterDate;
				string text2 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(model.AppType))
				{
					model.AppType = Configuration.AppType;
				}
				string text3 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
				regInfo = regInfo + " (" + text3 + ")" + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actInsertDis,actEditDis")]
	public ActionResult InsertEdit(int pordId, int pordDisId = 0)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.pordDisId = pordDisId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		GetDiscountStrategies(pordId, CS_0024_003C_003E8__locals0.pordDisId);
		WSPreOrderDiscountsLanguageViewModel wSPreOrderDiscountsLanguageViewModel = new WSPreOrderDiscountsLanguageViewModel();
		try
		{
			DateTime now = DateTime.Now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			WSPreOrderDiscounts wSPreOrderDiscounts = new WSPreOrderDiscounts();
			if (CS_0024_003C_003E8__locals0.pordDisId == 0)
			{
				if (!UserLogin.IsUserAccess("frmPreOrder", "actInsertDis", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				base.ViewBag.IsBuying = VersionBuyer.DiscountStrategy;
				wSPreOrderDiscountsLanguageViewModel = new WSPreOrderDiscountsLanguageViewModel
				{
					PreOrderDiscountId = 0,
					pordDisPreOrderId = pordId,
					FirstRegisterUserId = userId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = text,
					UserId = userId,
					RegisterDate = now,
					RegisterDatePersian = text
				};
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmPreOrder", "actEditDis", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<WSPreOrderDiscounts> wSPreOrderDiscounts2 = _dbTbl.WSPreOrderDiscounts;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrderDiscounts), "m");
				wSPreOrderDiscounts = Queryable.FirstOrDefault<WSPreOrderDiscounts>((IQueryable<WSPreOrderDiscounts>)wSPreOrderDiscounts2, Expression.Lambda<Func<WSPreOrderDiscounts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				DbSet<WSPreOrderDiscounts_Lang> wSPreOrderDiscounts_Lang = _dbTbl.WSPreOrderDiscounts_Lang;
				val = Expression.Parameter(typeof(WSPreOrderDiscounts_Lang), "c");
				List<WSPreOrderDiscounts_Lang> list = Enumerable.ToList<WSPreOrderDiscounts_Lang>((IEnumerable<WSPreOrderDiscounts_Lang>)Queryable.Where<WSPreOrderDiscounts_Lang>((IQueryable<WSPreOrderDiscounts_Lang>)wSPreOrderDiscounts_Lang, Expression.Lambda<Func<WSPreOrderDiscounts_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				if (wSPreOrderDiscounts != null)
				{
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDiscounts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDiscounts_Lang>)list, (Func<WSPreOrderDiscounts_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDiscounts_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.pordDisTitle,
						LanguageId = item.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = wSPreOrderDiscounts.pordDisTitle,
						LanguageId = result
					});
					wSPreOrderDiscountsLanguageViewModel = new WSPreOrderDiscountsLanguageViewModel
					{
						PreOrderDiscountId = wSPreOrderDiscounts.PreOrderDiscountId,
						pordDisPreOrderId = wSPreOrderDiscounts.pordDisPreOrderId,
						pordDisDiscountStrategyId = wSPreOrderDiscounts.pordDisDiscountStrategyId,
						pordDisTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						pordDisTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						pordDisAmount = wSPreOrderDiscounts.pordDisAmount,
						pordDisPercent = wSPreOrderDiscounts.pordDisPercent,
						FirstRegisterUserId = wSPreOrderDiscounts.FirstRegisterUserId,
						FirstRegisterDate = wSPreOrderDiscounts.FirstRegisterDate,
						FirstRegisterDatePersian = wSPreOrderDiscounts.FirstRegisterDatePersian,
						UserId = wSPreOrderDiscounts.UserId,
						RegisterDate = wSPreOrderDiscounts.RegisterDate,
						RegisterDatePersian = wSPreOrderDiscounts.RegisterDatePersian,
						AppType = wSPreOrderDiscounts.AppType,
						pordDisPrdId = wSPreOrderDiscounts.pordDisPrdId
					};
					int result2 = 0;
					int.TryParse(wSPreOrderDiscountsLanguageViewModel.pordDisPrdId.ToString(), out result2);
					if (result2 != 0)
					{
						WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(result2, CS_0024_003C_003E8__locals0.currLangID, result));
						if (wSspSelectProductsWithId_Result != null)
						{
							wSPreOrderDiscountsLanguageViewModel.pordDisPrdName = wSspSelectProductsWithId_Result.PrdName + " (" + wSspSelectProductsWithId_Result.PrdCode + ")";
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetRegisterInfo(wSPreOrderDiscountsLanguageViewModel, ref firstRegInfo, ref regInfo);
		wSPreOrderDiscountsLanguageViewModel.FirstRegisterUser = firstRegInfo;
		wSPreOrderDiscountsLanguageViewModel.EditUser = regInfo;
		return View(wSPreOrderDiscountsLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actInsertDis,actEditDis")]
	public ActionResult InsertEdit(WSPreOrderDiscountsLanguageViewModel vm)
	{
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetDiscountStrategies(CS_0024_003C_003E8__locals0.vm.pordDisPreOrderId, CS_0024_003C_003E8__locals0.vm.PreOrderDiscountId);
		try
		{
			if (base.ModelState.IsValid)
			{
				if (CS_0024_003C_003E8__locals0.vm.PreOrderDiscountId == 0 && !VersionBuyer.DiscountStrategy)
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuyWithoutCount;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				if (PreOrder.IsFixed(CS_0024_003C_003E8__locals0.vm.pordDisPreOrderId))
				{
					base.ViewBag.Error = Messages.msgErrorNotActiveProd;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				if (PreOrder.IsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.vm.pordDisPreOrderId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.pordDisTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordDisTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.vm.pordDisTitle,
					LanguageId = lCID
				});
				if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.pordDisTitle))
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.OrderPaymentTypeTitle) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.pordDisTitle, list))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.pordDisTitle) + "<br>";
					num++;
				}
				if (num == 0)
				{
					try
					{
						int result = 0;
						string text2 = "";
						long result2 = 0L;
						WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(CS_0024_003C_003E8__locals0.vm.pordDisPreOrderId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						if (wSspSelectPreOrderWithId_Result != null)
						{
							int.TryParse(wSspSelectPreOrderWithId_Result.pordReferUserId.ToString(), out result);
							text2 = wSspSelectPreOrderWithId_Result.pordReferUser ?? "";
							long.TryParse(wSspSelectPreOrderWithId_Result.pordNumber.ToString(), out result2);
						}
						WSPreOrderDiscounts wSPreOrderDiscounts = new WSPreOrderDiscounts();
						if (CS_0024_003C_003E8__locals0.vm.PreOrderDiscountId > 0)
						{
							DbSet<WSPreOrderDiscounts> wSPreOrderDiscounts2 = _dbTbl.WSPreOrderDiscounts;
							ParameterExpression val = Expression.Parameter(typeof(WSPreOrderDiscounts), "m");
							wSPreOrderDiscounts = Queryable.FirstOrDefault<WSPreOrderDiscounts>((IQueryable<WSPreOrderDiscounts>)wSPreOrderDiscounts2, Expression.Lambda<Func<WSPreOrderDiscounts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						}
						DateTime now = DateTime.Now;
						DateTime dateTime = now;
						string text3 = now.ToString("yyyyMMdd", new PersianCulture());
						short month = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType = Configuration.AppType;
						int id = Financial.Get().Id;
						int userId = UserLogin.CurrentUser.UserId;
						short value = short.Parse(Financial.Get().Id.ToString());
						wSPreOrderDiscounts.UserId = userId;
						wSPreOrderDiscounts.RegisterDate = dateTime;
						wSPreOrderDiscounts.RegisterDatePersian = text3;
						wSPreOrderDiscounts.Month1 = month;
						wSPreOrderDiscounts.AppType = appType;
						wSPreOrderDiscounts.pordDisTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						string pordDisTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
						wSPreOrderDiscounts.pordDisPreOrderId = CS_0024_003C_003E8__locals0.vm.pordDisPreOrderId;
						wSPreOrderDiscounts.pordDisDiscountStrategyId = CS_0024_003C_003E8__locals0.vm.pordDisDiscountStrategyId;
						wSPreOrderDiscounts.pordDisPercent = CS_0024_003C_003E8__locals0.vm.pordDisPercent;
						wSPreOrderDiscounts.pordDisPrdId = CS_0024_003C_003E8__locals0.vm.pordDisPrdId;
						decimal result3 = default(decimal);
						decimal.TryParse(wSPreOrderDiscounts.pordDisAmount.ToString(), out result3);
						WSspReturnPreOrderDiscountAmount_Result wSspReturnPreOrderDiscountAmount_Result = Enumerable.FirstOrDefault<WSspReturnPreOrderDiscountAmount_Result>((IEnumerable<WSspReturnPreOrderDiscountAmount_Result>)_dbII.WSspReturnPreOrderDiscountAmount(wSPreOrderDiscounts.pordDisPreOrderId, CS_0024_003C_003E8__locals0.vm.pordDisDiscountStrategyId, CS_0024_003C_003E8__locals0.vm.pordDisPercent, dateTime, wSPreOrderDiscounts.pordDisPrdId));
						decimal result4 = default(decimal);
						bool result5 = false;
						int result6 = 0;
						decimal result7 = default(decimal);
						decimal result8 = default(decimal);
						if (wSspReturnPreOrderDiscountAmount_Result != null)
						{
							CS_0024_003C_003E8__locals0.vm.pordDisAmount = wSspReturnPreOrderDiscountAmount_Result.pordDisAmount;
							wSPreOrderDiscounts.pordDisAmount = CS_0024_003C_003E8__locals0.vm.pordDisAmount;
							decimal.TryParse(wSspReturnPreOrderDiscountAmount_Result.RemainDisAmount.ToString(), out result4);
							bool.TryParse(wSspReturnPreOrderDiscountAmount_Result.MnBgIsReturn.ToString(), out result5);
							int.TryParse(wSspReturnPreOrderDiscountAmount_Result.MnBgExpireDay.ToString(), out result6);
							decimal.TryParse(wSspReturnPreOrderDiscountAmount_Result.SumPriceAmount.ToString(), out result7);
							decimal.TryParse(wSspReturnPreOrderDiscountAmount_Result.SumDisAmount.ToString(), out result8);
						}
						if (result7 == 0m)
						{
							text = text + string.Format(Messages.msgErrorNotSaveDisBySumPriceZero, Labels.lblPOrd) + "<br/>";
							num++;
						}
						int result9 = 0;
						if (wSPreOrderDiscounts.pordDisDiscountStrategyId.GetValueOrDefault() != 0)
						{
							WSspSelectDiscountStrategyById_Result wSspSelectDiscountStrategyById_Result = Enumerable.FirstOrDefault<WSspSelectDiscountStrategyById_Result>((IEnumerable<WSspSelectDiscountStrategyById_Result>)_dbII.WSspSelectDiscountStrategyById(wSPreOrderDiscounts.pordDisDiscountStrategyId.GetValueOrDefault(), lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (wSspSelectDiscountStrategyById_Result != null)
							{
								int.TryParse(wSspSelectDiscountStrategyById_Result.DisStDiscountStrategyTypeId.ToString(), out result9);
								if ((result9 == 4 || result9 == 5) && wSPreOrderDiscounts.pordDisAmount.GetValueOrDefault() != result3)
								{
									CRMspReturnUserMoneyBagRemain_Result cRMspReturnUserMoneyBagRemain_Result = Enumerable.FirstOrDefault<CRMspReturnUserMoneyBagRemain_Result>((IEnumerable<CRMspReturnUserMoneyBagRemain_Result>)_dbII.CRMspReturnUserMoneyBagRemain(result, wSPreOrderDiscounts.PreOrderDiscountId, 0, dateTime));
									decimal result10 = default(decimal);
									decimal result11 = default(decimal);
									decimal result12 = default(decimal);
									if (cRMspReturnUserMoneyBagRemain_Result != null)
									{
										decimal.TryParse(cRMspReturnUserMoneyBagRemain_Result.SumUserMoneyBagAmount.ToString(), out result10);
										decimal.TryParse(cRMspReturnUserMoneyBagRemain_Result.SumUserMoneyBagReturnDisAmount.ToString(), out result11);
										decimal.TryParse(cRMspReturnUserMoneyBagRemain_Result.SumUserMoneyBagSpendDiscountAmount.ToString(), out result12);
									}
									if (result9 == 4 && result12 < wSPreOrderDiscounts.pordDisAmount.GetValueOrDefault())
									{
										text = text + string.Format(Messages.msgErrorNotSaveDisByNoEnoughUserMoneyBag, text2 ?? "", "(" + Labels.lblSpendDiscount + ")") + "<br/>";
										num++;
									}
									if (result9 == 5 && result11 < wSPreOrderDiscounts.pordDisAmount.GetValueOrDefault())
									{
										text = text + string.Format(Messages.msgErrorNotSaveDisByNoEnoughUserMoneyBag, text2 ?? "", "(" + Labels.lblReturnfromDiscountSys + ")") + "<br/>";
										num++;
									}
								}
							}
						}
						if (num == 0)
						{
							ObjectParameter objectParameter = new ObjectParameter("PordDisId", typeof(int));
							if (wSPreOrderDiscounts.PreOrderDiscountId > 0)
							{
								mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspInsertUpdatePreOrderDiscount(wSPreOrderDiscounts.PreOrderDiscountId, wSPreOrderDiscounts.pordDisPreOrderId, wSPreOrderDiscounts.pordDisDiscountStrategyId, wSPreOrderDiscounts.pordDisTitle, pordDisTitle_Lang, wSPreOrderDiscounts.pordDisAmount, wSPreOrderDiscounts.pordDisPercent, wSPreOrderDiscounts.pordDisPrdId, CS_0024_003C_003E8__locals0.vm.pordDisPrdJson ?? "", wSPreOrderDiscounts.UserId, wSPreOrderDiscounts.FPId, wSPreOrderDiscounts.Month1, wSPreOrderDiscounts.RegisterDate, wSPreOrderDiscounts.RegisterDatePersian, wSPreOrderDiscounts.AppType, CS_0024_003C_003E8__locals0.defLangID, objectParameter));
								int result13 = 0;
								if (mct_II_Result != null)
								{
									int.TryParse(mct_II_Result.Result.ToString(), out result13);
								}
								if (result13 == 1)
								{
									if (result9 == 4 || result9 == 5)
									{
										string uMnBgDesc = "";
										string uMnBgDesc_Lang = "";
										List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
										foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
										{
											CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
											commonMultiLanguageViewModel.LanguageId = item.LanguageID;
											string arg = MyResource.GetResourceString("lblPOrd", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " (" + result2 + ")";
											commonMultiLanguageViewModel.Value = string.Format(MyResource.GetResourceString("UMnBgDescINUsageOtherPartSys", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly), arg);
											list2.Add(commonMultiLanguageViewModel);
										}
										if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
										{
											uMnBgDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
											uMnBgDesc_Lang = "";
											if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
											{
												uMnBgDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
											}
										}
										mct_II_Result mct_II_Result2 = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspInsertUpdateUserMoneyBagByPordDisId(wSPreOrderDiscounts.PreOrderDiscountId, dateTime, text3, uMnBgDesc, uMnBgDesc_Lang, userId, value, short.Parse(now.ToString("MM", new PersianCulture())), now, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, CS_0024_003C_003E8__locals0.defLangID));
										int result14 = 0;
										if (mct_II_Result2 != null)
										{
											int.TryParse(mct_II_Result2.Result.ToString(), out result14);
										}
										if (result14 != 1)
										{
											base.ViewBag.Successfull = Messages.msgErrorSaveUserMnBgByDiscount;
										}
										else
										{
											base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
										}
										if (result != 0)
										{
											Info.Update(result, true);
										}
									}
									else
									{
										base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
									}
								}
								else
								{
									text = Messages.msgErrorRunFunction;
								}
								CS_0024_003C_003E8__locals0.vm.PreOrderDiscountId = wSPreOrderDiscounts.PreOrderDiscountId;
							}
							else
							{
								wSPreOrderDiscounts.FPId = id;
								wSPreOrderDiscounts.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
								wSPreOrderDiscounts.FirstRegisterDate = dateTime;
								wSPreOrderDiscounts.FirstRegisterDatePersian = text3;
								wSPreOrderDiscounts.FirstRegisterUserId = userId;
								wSPreOrderDiscounts.GUId = System.Guid.NewGuid();
								mct_II_Result mct_II_Result3 = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspInsertUpdatePreOrderDiscount(0, wSPreOrderDiscounts.pordDisPreOrderId, wSPreOrderDiscounts.pordDisDiscountStrategyId, wSPreOrderDiscounts.pordDisTitle, pordDisTitle_Lang, wSPreOrderDiscounts.pordDisAmount, wSPreOrderDiscounts.pordDisPercent, wSPreOrderDiscounts.pordDisPrdId, CS_0024_003C_003E8__locals0.vm.pordDisPrdJson ?? "", wSPreOrderDiscounts.UserId, wSPreOrderDiscounts.FPId, wSPreOrderDiscounts.Month1, wSPreOrderDiscounts.RegisterDate, wSPreOrderDiscounts.RegisterDatePersian, wSPreOrderDiscounts.AppType, CS_0024_003C_003E8__locals0.defLangID, objectParameter));
								int result15 = 0;
								if (mct_II_Result3 != null)
								{
									int.TryParse(mct_II_Result3.Result.ToString(), out result15);
								}
								int result16 = 0;
								if (objectParameter != null && objectParameter.Value != null)
								{
									int.TryParse(objectParameter.Value.ToString(), out result16);
								}
								if (result15 == 1)
								{
									if (result9 == 4 || result9 == 5)
									{
										string uMnBgDesc2 = "";
										string uMnBgDesc_Lang2 = "";
										List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
										foreach (Languages item2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
										{
											CommonMultiLanguageViewModel commonMultiLanguageViewModel2 = new CommonMultiLanguageViewModel();
											commonMultiLanguageViewModel2.LanguageId = item2.LanguageID;
											string arg2 = MyResource.GetResourceString("lblPOrd", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " (" + result2 + ")";
											commonMultiLanguageViewModel2.Value = string.Format(MyResource.GetResourceString("UMnBgDescINUsageOtherPartSys", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly), arg2);
											list3.Add(commonMultiLanguageViewModel2);
										}
										if (list3 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
										{
											uMnBgDesc2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
											uMnBgDesc_Lang2 = "";
											if (list3 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
											{
												uMnBgDesc_Lang2 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
											}
										}
										mct_II_Result mct_II_Result4 = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspInsertUpdateUserMoneyBagByPordDisId(result16, dateTime, text3, uMnBgDesc2, uMnBgDesc_Lang2, userId, value, short.Parse(now.ToString("MM", new PersianCulture())), now, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, CS_0024_003C_003E8__locals0.defLangID));
										int result17 = 0;
										if (mct_II_Result4 != null)
										{
											int.TryParse(mct_II_Result4.Result.ToString(), out result17);
										}
										if (result17 != 1)
										{
											base.ViewBag.Successfull = Messages.msgErrorSaveUserMnBgByDiscount;
										}
										else
										{
											base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
										}
										if (result != 0)
										{
											Info.Update(result, true);
										}
									}
									else
									{
										base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
									}
								}
								else
								{
									text = Messages.msgErrorRunFunction;
								}
								wSPreOrderDiscounts.PreOrderDiscountId = result16;
								CS_0024_003C_003E8__locals0.vm.PreOrderDiscountId = wSPreOrderDiscounts.PreOrderDiscountId;
							}
						}
						CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = wSPreOrderDiscounts.FirstRegisterUserId;
						CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = wSPreOrderDiscounts.FirstRegisterDate;
						CS_0024_003C_003E8__locals0.vm.UserId = wSPreOrderDiscounts.UserId;
						CS_0024_003C_003E8__locals0.vm.RegisterDate = wSPreOrderDiscounts.RegisterDate;
						CS_0024_003C_003E8__locals0.vm.AppType = wSPreOrderDiscounts.AppType;
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						text = Messages.msgErrorRunFunction;
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetRegisterInfo(CS_0024_003C_003E8__locals0.vm, ref firstRegInfo, ref regInfo);
		CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = firstRegInfo;
		CS_0024_003C_003E8__locals0.vm.EditUser = regInfo;
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public string CalcAndUpdateDis(int pordId, bool clearDiscount = false)
	{
		string text = "";
		_ = UserLogin.CurrentUser;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)_dbII.WSspReturnPreOrderDiscountSumDisAmount(pordId)).GetValueOrDefault() > 0m || clearDiscount)
			{
				if (PreOrder.IsFixed(pordId))
				{
					return Messages.msgErrorNotActiveProd;
				}
				if (PreOrder.IsSentToLinkAccByAction(pordId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				_dbII.WSspDistributeDiscountStrategyToPreOrderItems(pordId, false, userId, id, value2, value, registerDatePersian, appType, result, objectParameter);
				if (int.Parse(objectParameter.Value.ToString()) > 0)
				{
					return "";
				}
				return Messages.msgErrorRunFunction;
			}
			return string.Format(Messages.msgErrorIsNotSpecified, Labels.pordDisAmount);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public JsonResult GetDiscountStrategies(int pordId, int pordDisId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			List<WSspSelectPreOrderDiscountStrategy_Result> list3 = Enumerable.ToList<WSspSelectPreOrderDiscountStrategy_Result>((IEnumerable<WSspSelectPreOrderDiscountStrategy_Result>)_dbII.WSspSelectPreOrderDiscountStrategy(pordId, pordDisId, now, lCID, result));
			if (list3 != null && Enumerable.Any<WSspSelectPreOrderDiscountStrategy_Result>((IEnumerable<WSspSelectPreOrderDiscountStrategy_Result>)list3))
			{
				List<WSspSelectPreOrderDiscountStrategy_Result> list4 = new List<WSspSelectPreOrderDiscountStrategy_Result>();
				foreach (WSspSelectPreOrderDiscountStrategy_Result item2 in list3)
				{
					bool flag = false;
					if (list4 != null && Enumerable.Any<WSspSelectPreOrderDiscountStrategy_Result>((IEnumerable<WSspSelectPreOrderDiscountStrategy_Result>)list4))
					{
						WSspSelectPreOrderDiscountStrategy_Result wSspSelectPreOrderDiscountStrategy_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderDiscountStrategy_Result>((IEnumerable<WSspSelectPreOrderDiscountStrategy_Result>)list4, (Func<WSspSelectPreOrderDiscountStrategy_Result, bool>)((WSspSelectPreOrderDiscountStrategy_Result m) => m.DiscountStrategyId == item2.DiscountStrategyId));
						if (wSspSelectPreOrderDiscountStrategy_Result == null)
						{
							flag = true;
						}
						else if (wSspSelectPreOrderDiscountStrategy_Result.DiscountStrategyId == 0)
						{
							flag = true;
						}
					}
					else
					{
						flag = true;
					}
					if (flag)
					{
						list4.Add(item2);
					}
				}
				list.AddRange(Enumerable.Select<WSspSelectPreOrderDiscountStrategy_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderDiscountStrategy_Result>)list4, (Func<WSspSelectPreOrderDiscountStrategy_Result, SelectListItem>)((WSspSelectPreOrderDiscountStrategy_Result item) => new SelectListItem
				{
					Text = item.DisStTitle,
					Value = item.DiscountStrategyId.ToString(),
					Selected = false
				})));
				list2.AddRange(Enumerable.Select<WSspSelectPreOrderDiscountStrategy_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderDiscountStrategy_Result>)list4, (Func<WSspSelectPreOrderDiscountStrategy_Result, SelectListItem>)((WSspSelectPreOrderDiscountStrategy_Result item) => new SelectListItem
				{
					Text = item.DisPer.GetValueOrDefault().ToString(),
					Value = item.DiscountStrategyId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DiscountStrategyList = list;
		base.ViewBag.PerDiscountStrategyList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDiscountStrategyById(int pordId, int disStId = 0, int pordDisId = 0)
	{
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		List<WSspSelectPreOrderDiscountStrategyById_Result> list = new List<WSspSelectPreOrderDiscountStrategyById_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			list = Enumerable.ToList<WSspSelectPreOrderDiscountStrategyById_Result>((IEnumerable<WSspSelectPreOrderDiscountStrategyById_Result>)_dbII.WSspSelectPreOrderDiscountStrategyById(pordId, disStId, now, currLangID, result, pordDisId));
			if (list == null)
			{
				list = new List<WSspSelectPreOrderDiscountStrategyById_Result>();
			}
			else if (Enumerable.Any<WSspSelectPreOrderDiscountStrategyById_Result>((IEnumerable<WSspSelectPreOrderDiscountStrategyById_Result>)list))
			{
				foreach (WSspSelectPreOrderDiscountStrategyById_Result item in list)
				{
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = item.DisStTitle,
						LanguageId = currLangID
					});
					if (!string.IsNullOrWhiteSpace(item.DisStTitle_Lang))
					{
						List<CommonMultiLanguageViewModel> list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.DisStTitle_Lang);
						if (list3 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
						{
							list2.AddRange(list3);
						}
					}
					if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
					{
						item.DisStTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
						item.DisStTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					}
				}
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

	[AjaxOnly]
	public JsonResult ShowUserMoneyBag(int pordId, int pordDisId = 0)
	{
		CRMspReturnUserMoneyBagRemain_Result cRMspReturnUserMoneyBagRemain_Result = new CRMspReturnUserMoneyBagRemain_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int result2 = 0;
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				int.TryParse(wSspSelectPreOrderWithId_Result.pordReferUserId.ToString(), out result2);
				_ = wSspSelectPreOrderWithId_Result.pordReferUser;
			}
			cRMspReturnUserMoneyBagRemain_Result = Enumerable.FirstOrDefault<CRMspReturnUserMoneyBagRemain_Result>((IEnumerable<CRMspReturnUserMoneyBagRemain_Result>)_dbII.CRMspReturnUserMoneyBagRemain(result2, pordDisId, 0, now));
			if (cRMspReturnUserMoneyBagRemain_Result == null)
			{
				cRMspReturnUserMoneyBagRemain_Result = new CRMspReturnUserMoneyBagRemain_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(cRMspReturnUserMoneyBagRemain_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
