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

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class ItemSpecificationController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int itemSpeId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public WSPreOrderItemSpecificationLanguageViewModel model;

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
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals1;

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

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actPreOrderItemSpecification")]
	public ActionResult Index(int pordItemId, int pordId)
	{
		base.ViewBag.pordItemId = pordItemId;
		base.ViewBag.pordId = pordId;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialPordItemSpecification(int pordItemId = 0)
	{
		base.ViewBag.pordItemId = pordItemId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult PordItemSpecification_Read([DataSourceRequest] DataSourceRequest request, int pordItemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectPreOrderItemSpecificationByItemId_Result> list = new List<WSspSelectPreOrderItemSpecificationByItemId_Result>();
		try
		{
			if (pordItemId > 0)
			{
				List<WSspSelectPreOrderItemSpecificationByItemId_Result> list2 = Enumerable.ToList<WSspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<WSspSelectPreOrderItemSpecificationByItemId_Result>)_db.WSspSelectPreOrderItemSpecificationByItemId(pordItemId, lCID, result));
				list.AddRange(Enumerable.Select<WSspSelectPreOrderItemSpecificationByItemId_Result, WSspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<WSspSelectPreOrderItemSpecificationByItemId_Result>)list2, (Func<WSspSelectPreOrderItemSpecificationByItemId_Result, WSspSelectPreOrderItemSpecificationByItemId_Result>)((WSspSelectPreOrderItemSpecificationByItemId_Result item) => new WSspSelectPreOrderItemSpecificationByItemId_Result
				{
					PreOrderItemSpcflID = item.PreOrderItemSpcflID,
					PreOrderItemId = item.PreOrderItemId,
					Specification = item.Specification,
					SpecificationI = item.SpecificationI,
					SpecificationII = item.SpecificationII
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[DynamicAuthorize(ControllerName = "frmProductSpecification", ActionName = "actDelete")]
	[AjaxOnly]
	public string ProductSpecificationDelete(int prdSepId, int pordId)
	{
		string result = "";
		try
		{
			if (pordId > 0)
			{
				if (PreOrder.IsFixed(pordId))
				{
					return Messages.msgErrorNotActiveProd;
				}
				if (prdSepId > 0)
				{
					if (_dbTbl.WSPreOrderItemSpecification.Find(prdSepId) != null)
					{
						try
						{
							mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSPreOrderItemSpecification(prdSepId)));
							result = ((mct_Result == null || mct_Result.Result <= 0) ? Messages.RedundancyMessage : "1");
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
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	public void SetUserNameDateForItemSpecification(WSPreOrderItemSpecificationLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			string text5 = (model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				WSPreOrderItemSpecificationLanguageViewModel wSPreOrderItemSpecificationLanguageViewModel = model;
				_ = model.UserId;
				wSPreOrderItemSpecificationLanguageViewModel.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[DynamicAuthorize(ControllerName = "frmProductSpecification", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int pordItemId, int itemSpeId)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.itemSpeId = itemSpeId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		WSPreOrderItemSpecificationLanguageViewModel wSPreOrderItemSpecificationLanguageViewModel = new WSPreOrderItemSpecificationLanguageViewModel();
		_ = Financial.Get().Id;
		if (!UserLogin.IsUserAccess("frmProductSpecification", "actEdit"))
		{
			base.ViewBag.Error = Messages.NotAccessToPage;
			return null;
		}
		try
		{
			if (CS_0024_003C_003E8__locals0.itemSpeId > 0)
			{
				DbSet<WSPreOrderItemSpecification> wSPreOrderItemSpecification = _dbTbl.WSPreOrderItemSpecification;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItemSpecification), "c");
				WSPreOrderItemSpecification wSPreOrderItemSpecification2 = Queryable.FirstOrDefault<WSPreOrderItemSpecification>((IQueryable<WSPreOrderItemSpecification>)wSPreOrderItemSpecification, Expression.Lambda<Func<WSPreOrderItemSpecification, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSPreOrderItemSpecification2 != null)
				{
					DbSet<WSPreOrderItemSpecification_Lang> wSPreOrderItemSpecification_Lang = _dbTbl.WSPreOrderItemSpecification_Lang;
					val = Expression.Parameter(typeof(WSPreOrderItemSpecification_Lang), "c");
					List<WSPreOrderItemSpecification_Lang> list = Enumerable.ToList<WSPreOrderItemSpecification_Lang>((IEnumerable<WSPreOrderItemSpecification_Lang>)Queryable.Where<WSPreOrderItemSpecification_Lang>((IQueryable<WSPreOrderItemSpecification_Lang>)wSPreOrderItemSpecification_Lang, Expression.Lambda<Func<WSPreOrderItemSpecification_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderItemSpecification_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderItemSpecification_Lang>)list, (Func<WSPreOrderItemSpecification_Lang, CommonMultiLanguageViewModel>)((WSPreOrderItemSpecification_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.Specification,
						LanguageId = item.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = wSPreOrderItemSpecification2.Specification,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderItemSpecification_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderItemSpecification_Lang>)list, (Func<WSPreOrderItemSpecification_Lang, CommonMultiLanguageViewModel>)((WSPreOrderItemSpecification_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.SpecificationI,
						LanguageId = item.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = wSPreOrderItemSpecification2.SpecificationI,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderItemSpecification_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderItemSpecification_Lang>)list, (Func<WSPreOrderItemSpecification_Lang, CommonMultiLanguageViewModel>)((WSPreOrderItemSpecification_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.SpecificationII,
						LanguageId = item.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = wSPreOrderItemSpecification2.SpecificationII,
						LanguageId = result
					});
					wSPreOrderItemSpecificationLanguageViewModel = new WSPreOrderItemSpecificationLanguageViewModel
					{
						Month1 = wSPreOrderItemSpecification2.Month1,
						LanguageID = wSPreOrderItemSpecification2.LanguageID,
						UserId = wSPreOrderItemSpecification2.UserId,
						FirstRegisterUserId = wSPreOrderItemSpecification2.FirstRegisterUserId,
						FirstRegisterDatePersian = wSPreOrderItemSpecification2.FirstRegisterDatePersian,
						FirstRegisterDate = wSPreOrderItemSpecification2.FirstRegisterDate,
						RegisterDate = wSPreOrderItemSpecification2.RegisterDate,
						RegisterDatePersian = wSPreOrderItemSpecification2.RegisterDatePersian,
						AppType = wSPreOrderItemSpecification2.AppType,
						GUId = wSPreOrderItemSpecification2.GUId,
						FPId = wSPreOrderItemSpecification2.FPId,
						PreOrderItemSpcflID = wSPreOrderItemSpecification2.PreOrderItemSpcflID,
						PreOrderItemId = wSPreOrderItemSpecification2.PreOrderItemId,
						Specification_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						Specification = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						SpecificationI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						SpecificationI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						SpecificationII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						SpecificationII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "")
					};
				}
			}
			else
			{
				wSPreOrderItemSpecificationLanguageViewModel = new WSPreOrderItemSpecificationLanguageViewModel
				{
					PreOrderItemSpcflID = CS_0024_003C_003E8__locals0.itemSpeId,
					PreOrderItemId = pordItemId,
					FPId = Financial.Get().Id,
					GUId = Guid.NewGuid(),
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					AppType = Configuration.AppType,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		SetUserNameDateForItemSpecification(wSPreOrderItemSpecificationLanguageViewModel);
		return View(wSPreOrderItemSpecificationLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductSpecification", ActionName = "actPost")]
	public ActionResult InsertEdit(WSPreOrderItemSpecificationLanguageViewModel model)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Specification_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Specification_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.Specification,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.SpecificationI_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.SpecificationI_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.SpecificationI,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.SpecificationII_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.SpecificationII_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.SpecificationII,
			LanguageId = lCID
		});
		string text = "";
		if (CS_0024_003C_003E8__locals0.model.Specification == null && CS_0024_003C_003E8__locals0.model.Specification == "")
		{
			text = text + Messages.CheckSpecification + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.Specification, list))
		{
			text = text + Messages.CheckSpecificationLang + "<br>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.model);
		}
		try
		{
			if (base.ModelState.IsValid)
			{
				WSPreOrderItemSpecification wSPreOrderItemSpecification = new WSPreOrderItemSpecification();
				if (CS_0024_003C_003E8__locals0.model.PreOrderItemSpcflID > 0)
				{
					DbSet<WSPreOrderItemSpecification> wSPreOrderItemSpecification2 = _dbTbl.WSPreOrderItemSpecification;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItemSpecification), "c");
					wSPreOrderItemSpecification = Queryable.FirstOrDefault<WSPreOrderItemSpecification>((IQueryable<WSPreOrderItemSpecification>)wSPreOrderItemSpecification2, Expression.Lambda<Func<WSPreOrderItemSpecification, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				wSPreOrderItemSpecification.UserId = UserLogin.CurrentUser.UserId;
				wSPreOrderItemSpecification.RegisterDate = DateTime.Now;
				wSPreOrderItemSpecification.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				wSPreOrderItemSpecification.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				wSPreOrderItemSpecification.AppType = Configuration.AppType;
				wSPreOrderItemSpecification.PreOrderItemId = CS_0024_003C_003E8__locals0.model.PreOrderItemId;
				wSPreOrderItemSpecification.Specification = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				wSPreOrderItemSpecification.SpecificationI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				wSPreOrderItemSpecification.SpecificationII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				if (CS_0024_003C_003E8__locals0.model.PreOrderItemSpcflID > 0)
				{
					_dbTbl.Entry(wSPreOrderItemSpecification).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass8_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSPreOrderItemSpecification_Lang> wSPreOrderItemSpecification_Lang = _dbTbl.WSPreOrderItemSpecification_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItemSpecification_Lang), "c");
							WSPreOrderItemSpecification_Lang wSPreOrderItemSpecification_Lang2 = Queryable.FirstOrDefault<WSPreOrderItemSpecification_Lang>((IQueryable<WSPreOrderItemSpecification_Lang>)wSPreOrderItemSpecification_Lang, Expression.Lambda<Func<WSPreOrderItemSpecification_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSPreOrderItemSpecification_Lang2 != null)
							{
								wSPreOrderItemSpecification_Lang2.Specification = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSPreOrderItemSpecification_Lang2.SpecificationI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSPreOrderItemSpecification_Lang2.SpecificationII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSPreOrderItemSpecification_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSPreOrderItemSpecification_Lang2 = new WSPreOrderItemSpecification_Lang();
							wSPreOrderItemSpecification_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							wSPreOrderItemSpecification_Lang2.PreOrderItemSpcflID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.PreOrderItemSpcflID;
							wSPreOrderItemSpecification_Lang2.Specification = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSPreOrderItemSpecification_Lang2.SpecificationI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSPreOrderItemSpecification_Lang2.SpecificationII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.WSPreOrderItemSpecification_Lang.Add(wSPreOrderItemSpecification_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					wSPreOrderItemSpecification.FPId = Financial.Get().Id;
					wSPreOrderItemSpecification.GUId = Guid.NewGuid();
					wSPreOrderItemSpecification.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					wSPreOrderItemSpecification.FirstRegisterDate = DateTime.Now;
					wSPreOrderItemSpecification.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					wSPreOrderItemSpecification.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					wSPreOrderItemSpecification.CId = PreOrder.GetPordItemCId(wSPreOrderItemSpecification.PreOrderItemId);
					_dbTbl.WSPreOrderItemSpecification.Add(wSPreOrderItemSpecification);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSPreOrderItemSpecification_Lang wSPreOrderItemSpecification_Lang3 = new WSPreOrderItemSpecification_Lang();
						wSPreOrderItemSpecification_Lang3.LanguageID = lang.LanguageID;
						wSPreOrderItemSpecification_Lang3.PreOrderItemSpcflID = wSPreOrderItemSpecification.PreOrderItemSpcflID;
						wSPreOrderItemSpecification_Lang3.Specification = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderItemSpecification_Lang3.SpecificationI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderItemSpecification_Lang3.SpecificationII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSPreOrderItemSpecification_Lang.Add(wSPreOrderItemSpecification_Lang3);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.model.UserId = wSPreOrderItemSpecification.UserId;
				CS_0024_003C_003E8__locals0.model.RegisterDate = wSPreOrderItemSpecification.RegisterDate;
				CS_0024_003C_003E8__locals0.model.AppType = wSPreOrderItemSpecification.AppType;
				CS_0024_003C_003E8__locals0.model.FirstRegisterUserId = wSPreOrderItemSpecification.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.model.FirstRegisterDate = wSPreOrderItemSpecification.FirstRegisterDate;
			}
			else
			{
				text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		SetUserNameDateForItemSpecification(CS_0024_003C_003E8__locals0.model);
		return View(CS_0024_003C_003E8__locals0.model);
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
		base.Dispose(disposing);
	}
}
