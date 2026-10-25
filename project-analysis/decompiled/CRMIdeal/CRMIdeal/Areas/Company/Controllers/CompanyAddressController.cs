using System;
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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Company.Controllers;

public class CompanyAddressController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public CrmCompanyAddressesLocationViewModel model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int id;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public CrmCompanyAddressesLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__17;

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

		internal bool _003CInsertEdit_003Eb__7(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public CrmCompanyAddresses model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

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
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actCmpAddMoreAddress")]
	public ActionResult Index(int cmpId)
	{
		base.ViewBag.CmpId = cmpId;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialCompanyAddress(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyAddresses_Result> model = new List<CRMspSelectCompanyAddresses_Result>();
		try
		{
			model = Enumerable.ToList<CRMspSelectCompanyAddresses_Result>((IEnumerable<CRMspSelectCompanyAddresses_Result>)_dbI.CRMspSelectCompanyAddresses(cmpId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(model);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCompanyAddress", ActionName = "actDelete")]
	public string ActDelete(int addressId)
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
			if (!UserLogin.IsUserAccess("frmCompanyAddress", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (addressId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteCompanyAddress(addressId));
					if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						result = "1";
					}
					else if (mct_I_Result != null && mct_I_Result.Result == 0)
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

	public void SetCmpAddRegisterInfo(CrmCompanyAddressesLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
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
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.LName)) ? cRMspSelectUsersById_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.FName)) ? (" " + cRMspSelectUsersById_Result.FName) : "");
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
			if (cRMspSelectUsersById_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.LName)) ? cRMspSelectUsersById_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.FName)) ? (" " + cRMspSelectUsersById_Result2.FName) : "");
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

	[DynamicAuthorize(ControllerName = "frmCompanyAddress", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int cmpId, int id = 0)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmCompanyAddressesLanguageViewModel crmCompanyAddressesLanguageViewModel = new CrmCompanyAddressesLanguageViewModel();
		GetCompanyAddressType();
		if (CS_0024_003C_003E8__locals0.id > 0)
		{
			if (!UserLogin.IsUserAccess("frmCompanyAddress", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<CrmCompanyAddresses_Lang> crmCompanyAddresses_Lang = _dbTbl.CrmCompanyAddresses_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmCompanyAddresses_Lang), "c");
			List<CrmCompanyAddresses_Lang> list = Enumerable.ToList<CrmCompanyAddresses_Lang>((IEnumerable<CrmCompanyAddresses_Lang>)Queryable.Where<CrmCompanyAddresses_Lang>((IQueryable<CrmCompanyAddresses_Lang>)crmCompanyAddresses_Lang, Expression.Lambda<Func<CrmCompanyAddresses_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<CrmCompanyAddresses> crmCompanyAddresses = _dbTbl.CrmCompanyAddresses;
			val = Expression.Parameter(typeof(CrmCompanyAddresses), "c");
			CrmCompanyAddresses crmCompanyAddresses2 = Queryable.FirstOrDefault<CrmCompanyAddresses>((IQueryable<CrmCompanyAddresses>)crmCompanyAddresses, Expression.Lambda<Func<CrmCompanyAddresses, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCompanyAddresses2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyAddresses_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyAddresses_Lang>)list, (Func<CrmCompanyAddresses_Lang, CommonMultiLanguageViewModel>)((CrmCompanyAddresses_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CompanyAddress,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCompanyAddresses2.CompanyAddress,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyAddresses_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyAddresses_Lang>)list, (Func<CrmCompanyAddresses_Lang, CommonMultiLanguageViewModel>)((CrmCompanyAddresses_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.cmpaddDesc,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCompanyAddresses2.cmpaddDesc,
				LanguageId = result
			});
			crmCompanyAddressesLanguageViewModel = new CrmCompanyAddressesLanguageViewModel
			{
				CompanyAddressId = crmCompanyAddresses2.CompanyAddressId,
				cmpaddCompanyId = crmCompanyAddresses2.cmpaddCompanyId,
				cmpaddCityId = crmCompanyAddresses2.cmpaddCityId,
				CompanyAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				CompanyAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				cmpaddDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				cmpaddDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				cmpaddZipCode = crmCompanyAddresses2.cmpaddZipCode,
				cmpaddPostBox = crmCompanyAddresses2.cmpaddPostBox,
				cmpaddCoordinateLatitude = crmCompanyAddresses2.cmpaddCoordinateLatitude,
				cmpaddCoordinateLongitude = crmCompanyAddresses2.cmpaddCoordinateLongitude,
				cmpaddCoordinateLastDate = crmCompanyAddresses2.cmpaddCoordinateLastDate,
				cmpaddCoordinateLastDatePersian = crmCompanyAddresses2.cmpaddCoordinateLastDatePersian,
				cmpaddCoordinateZoomLevel = crmCompanyAddresses2.cmpaddCoordinateZoomLevel,
				cmpaddCoordinateLastUserId = crmCompanyAddresses2.cmpaddCoordinateLastUserId,
				FirstRegisterUserId = crmCompanyAddresses2.FirstRegisterUserId,
				FirstRegisterDate = crmCompanyAddresses2.FirstRegisterDate,
				FirstRegisterDatePersian = crmCompanyAddresses2.FirstRegisterDatePersian,
				UserId = crmCompanyAddresses2.UserId,
				Year1 = crmCompanyAddresses2.Year1,
				Month1 = crmCompanyAddresses2.Month1,
				RegisterDate = crmCompanyAddresses2.RegisterDate,
				RegisterDatePersian = crmCompanyAddresses2.RegisterDatePersian,
				GUId = crmCompanyAddresses2.GUId,
				AppType = crmCompanyAddresses2.AppType,
				LanguageID = crmCompanyAddresses2.LanguageID,
				cmpaddTypeId = crmCompanyAddresses2.cmpaddTypeId
			};
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmCompanyAddress", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			crmCompanyAddressesLanguageViewModel = new CrmCompanyAddressesLanguageViewModel
			{
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDate = now,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				cmpaddCompanyId = cmpId
			};
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetCmpAddRegisterInfo(crmCompanyAddressesLanguageViewModel, ref firstRegInfo, ref regInfo);
		crmCompanyAddressesLanguageViewModel.FirstRegisterUser = firstRegInfo;
		crmCompanyAddressesLanguageViewModel.EditUser = regInfo;
		return View(crmCompanyAddressesLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCompanyAddressDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmCompanyAddressesLanguageViewModel vm, HttpPostedFileBase[] fileSending)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetCompanyAddressType();
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CompanyAddress_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.CompanyAddress_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.CompanyAddress,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.cmpaddDesc_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.cmpaddDesc_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.cmpaddDesc,
			LanguageId = lCID
		});
		try
		{
			string text = "";
			if (CS_0024_003C_003E8__locals0.vm.CompanyAddress == null && CS_0024_003C_003E8__locals0.vm.CompanyAddress == "")
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.cmpaddCompanyAddress) + "<br/>";
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.CompanyAddress, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.cmpaddCompanyAddress) + "<br>";
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
				short month = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short year = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass9_.model = new CrmCompanyAddresses();
				if (CS_0024_003C_003E8__locals0.vm.CompanyAddressId > 0)
				{
					DbSet<CrmCompanyAddresses> crmCompanyAddresses = _dbTbl.CrmCompanyAddresses;
					ParameterExpression val = Expression.Parameter(typeof(CrmCompanyAddresses), "c");
					_003C_003Ec__DisplayClass9_.model = Queryable.FirstOrDefault<CrmCompanyAddresses>((IQueryable<CrmCompanyAddresses>)crmCompanyAddresses, Expression.Lambda<Func<CrmCompanyAddresses, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass9_.model.cmpaddCompanyId = CS_0024_003C_003E8__locals0.vm.cmpaddCompanyId;
				_003C_003Ec__DisplayClass9_.model.cmpaddCityId = CS_0024_003C_003E8__locals0.vm.cmpaddCityId;
				_003C_003Ec__DisplayClass9_.model.CompanyAddress = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.cmpaddDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.cmpaddZipCode = CS_0024_003C_003E8__locals0.vm.cmpaddZipCode;
				_003C_003Ec__DisplayClass9_.model.cmpaddPostBox = CS_0024_003C_003E8__locals0.vm.cmpaddPostBox;
				if (((_003C_003Ec__DisplayClass9_.model.cmpaddCoordinateLatitude ?? "") != (CS_0024_003C_003E8__locals0.vm.cmpaddCoordinateLatitude ?? "") && (_003C_003Ec__DisplayClass9_.model.cmpaddCoordinateLongitude ?? "") != (CS_0024_003C_003E8__locals0.vm.cmpaddCoordinateLongitude ?? "")) || _003C_003Ec__DisplayClass9_.model.cmpaddCoordinateZoomLevel.GetValueOrDefault() != CS_0024_003C_003E8__locals0.vm.cmpaddCoordinateZoomLevel.GetValueOrDefault())
				{
					_003C_003Ec__DisplayClass9_.model.cmpaddCoordinateLatitude = CS_0024_003C_003E8__locals0.vm.cmpaddCoordinateLatitude;
					_003C_003Ec__DisplayClass9_.model.cmpaddCoordinateLongitude = CS_0024_003C_003E8__locals0.vm.cmpaddCoordinateLongitude;
					_003C_003Ec__DisplayClass9_.model.cmpaddCoordinateZoomLevel = CS_0024_003C_003E8__locals0.vm.cmpaddCoordinateZoomLevel;
					_003C_003Ec__DisplayClass9_.model.cmpaddCoordinateLastUserId = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass9_.model.cmpaddCoordinateLatitude)) ? new int?(userId) : null);
					_003C_003Ec__DisplayClass9_.model.cmpaddCoordinateLastDate = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass9_.model.cmpaddCoordinateLatitude)) ? new DateTime?(dateTime) : null);
					_003C_003Ec__DisplayClass9_.model.cmpaddCoordinateLastDatePersian = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass9_.model.cmpaddCoordinateLatitude)) ? text2 : null);
				}
				_003C_003Ec__DisplayClass9_.model.UserId = userId;
				_003C_003Ec__DisplayClass9_.model.Year1 = year;
				_003C_003Ec__DisplayClass9_.model.Month1 = month;
				_003C_003Ec__DisplayClass9_.model.RegisterDate = dateTime;
				_003C_003Ec__DisplayClass9_.model.RegisterDatePersian = text2;
				_003C_003Ec__DisplayClass9_.model.AppType = appType;
				_003C_003Ec__DisplayClass9_.model.cmpaddTypeId = CS_0024_003C_003E8__locals0.vm.cmpaddTypeId;
				if (_003C_003Ec__DisplayClass9_.model.CompanyAddressId > 0)
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
							DbSet<CrmCompanyAddresses_Lang> crmCompanyAddresses_Lang = _dbTbl.CrmCompanyAddresses_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCompanyAddresses_Lang), "c");
							CrmCompanyAddresses_Lang crmCompanyAddresses_Lang2 = Queryable.FirstOrDefault<CrmCompanyAddresses_Lang>((IQueryable<CrmCompanyAddresses_Lang>)crmCompanyAddresses_Lang, Expression.Lambda<Func<CrmCompanyAddresses_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCompanyAddresses_Lang2 != null)
							{
								crmCompanyAddresses_Lang2.CompanyAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCompanyAddresses_Lang2.cmpaddDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCompanyAddresses_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCompanyAddresses_Lang2 = new CrmCompanyAddresses_Lang();
							crmCompanyAddresses_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmCompanyAddresses_Lang2.CompanyAddressId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.CompanyAddressId;
							crmCompanyAddresses_Lang2.CompanyAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCompanyAddresses_Lang2.cmpaddDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmCompanyAddresses_Lang.Add(crmCompanyAddresses_Lang2);
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
					_dbTbl.CrmCompanyAddresses.Add(_003C_003Ec__DisplayClass9_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					if (_003C_003Ec__DisplayClass9_.model.CompanyAddressId <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmCompanyAddresses_Lang crmCompanyAddresses_Lang3 = new CrmCompanyAddresses_Lang();
							crmCompanyAddresses_Lang3.LanguageID = lang.LanguageID;
							crmCompanyAddresses_Lang3.CompanyAddressId = _003C_003Ec__DisplayClass9_.model.CompanyAddressId;
							crmCompanyAddresses_Lang3.CompanyAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							crmCompanyAddresses_Lang3.cmpaddDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.CrmCompanyAddresses_Lang.Add(crmCompanyAddresses_Lang3);
							_dbTbl.SaveChanges();
						}
						CS_0024_003C_003E8__locals0.vm.CompanyAddressId = _003C_003Ec__DisplayClass9_.model.CompanyAddressId;
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass9_.model.UserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass9_.model.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass9_.model.RegisterDate;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass9_.model.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.AppType = _003C_003Ec__DisplayClass9_.model.AppType;
				string firstRegInfo = "";
				string regInfo = "";
				SetCmpAddRegisterInfo(CS_0024_003C_003E8__locals0.vm, ref firstRegInfo, ref regInfo);
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = firstRegInfo;
				CS_0024_003C_003E8__locals0.vm.EditUser = regInfo;
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

	public JsonResult GetCompanyCity(string value, int? cityId = 0)
	{
		List<mct_CRMspSelectUserAccessCompanyCity_Result> list = new List<mct_CRMspSelectUserAccessCompanyCity_Result>();
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
			list = Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)_db.mfi_CRMspSelectUserAccessCompanyCity(UserLogin.CurrentUser.UserId, value, lCID, result, result2));
			if (list != null && Enumerable.Any<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list))
			{
				list = ((!string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, 600)) : ((cityId.HasValue && cityId != 0 && string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Where<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, (Func<mct_CRMspSelectUserAccessCompanyCity_Result, bool>)((mct_CRMspSelectUserAccessCompanyCity_Result m) => m.CityID == cityId)), 600)) : ((!cityId.HasValue || cityId == 0) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, 600)) : Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Where<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, (Func<mct_CRMspSelectUserAccessCompanyCity_Result, bool>)((mct_CRMspSelectUserAccessCompanyCity_Result m) => m.CityID == cityId)), 600)))));
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult EditLocation(int cmpId, int addressId)
	{
		CrmCompanyAddressesLocationViewModel crmCompanyAddressesLocationViewModel = new CrmCompanyAddressesLocationViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string companyNameWithTitle = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cmpId);
			if (companyNameWithTitle == "")
			{
				base.ViewBag.Error = Messages.prsErrorNotFindCompany;
			}
			if (companyNameWithTitle != "")
			{
				crmCompanyAddressesLocationViewModel.CompanyName = companyNameWithTitle;
			}
			CRMspSelectCompanyAddressesById_Result cRMspSelectCompanyAddressesById_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyAddressesById_Result>((IEnumerable<CRMspSelectCompanyAddressesById_Result>)_dbI.CRMspSelectCompanyAddressesById(addressId, lCID, result));
			if (cRMspSelectCompanyAddressesById_Result != null)
			{
				crmCompanyAddressesLocationViewModel.CompanyAddressId = addressId;
				crmCompanyAddressesLocationViewModel.cmpaddCoordinateLatitude = cRMspSelectCompanyAddressesById_Result.cmpaddCoordinateLatitude;
				crmCompanyAddressesLocationViewModel.cmpaddCoordinateLongitude = cRMspSelectCompanyAddressesById_Result.cmpaddCoordinateLongitude;
				crmCompanyAddressesLocationViewModel.cmpaddCoordinateZoomLevel = cRMspSelectCompanyAddressesById_Result.cmpaddCoordinateZoomLevel;
				crmCompanyAddressesLocationViewModel.cmpaddCoordinateLastDatePersian = string.Format((!string.IsNullOrEmpty(cRMspSelectCompanyAddressesById_Result.cmpaddCoordinateLastUser)) ? (cRMspSelectCompanyAddressesById_Result.cmpaddCoordinateLastUser + "({0})") : "{0}", cRMspSelectCompanyAddressesById_Result.cmpaddCoordinateLastDate.HasValue ? cRMspSelectCompanyAddressesById_Result.cmpaddCoordinateLastDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				crmCompanyAddressesLocationViewModel.CompanyAddress = cRMspSelectCompanyAddressesById_Result.CompanyAddressFull ?? "";
			}
			if (addressId == 0 || (addressId > 0 && string.IsNullOrEmpty(crmCompanyAddressesLocationViewModel.cmpaddCoordinateLatitude)))
			{
				crmCompanyAddressesLocationViewModel.CompanyAddressId = addressId;
				crmCompanyAddressesLocationViewModel.cmpaddCoordinateLastDatePersian = "";
				List<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result> list = Enumerable.ToList<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>)_dbIII.CRMspSelectCompanyQuickRegisterDefSettingUserAccess((short)2, UserLogin.CurrentUser.UserId, lCID, result));
				int? defaultSetting = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.CRMspSelectCompanyQuickRegisterDefSettingIsDefUserAccess((short)2, UserLogin.CurrentUser.UserId, lCID, result));
				if (defaultSetting.HasValue && defaultSetting.Value > 0)
				{
					CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result cRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>)list, (Func<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result, bool>)((CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result s) => s.CompanyQuickRegisterDefSettingId == defaultSetting.Value));
					crmCompanyAddressesLocationViewModel.cmpaddCoordinateLatitude = cRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result?.cmpLocationLat;
					crmCompanyAddressesLocationViewModel.cmpaddCoordinateLongitude = cRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result?.cmpLocationLong;
					crmCompanyAddressesLocationViewModel.cmpaddCoordinateZoomLevel = Convert.ToInt32(cRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result?.cmpLocationZoom);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		return View(crmCompanyAddressesLocationViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult EditLocation(CrmCompanyAddressesLocationViewModel model)
	{
		_003C_003Ec__DisplayClass12_0 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_0();
		_003C_003Ec__DisplayClass12_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			if (string.IsNullOrEmpty(_003C_003Ec__DisplayClass12_.model.cmpaddCoordinateLatitude))
			{
				num++;
				text = text + string.Format(Messages.ErrorEmpty, Labels.cmpaddCoordinateLatitude) + "</br>";
			}
			if (string.IsNullOrEmpty(_003C_003Ec__DisplayClass12_.model.cmpaddCoordinateLongitude))
			{
				num++;
				text = text + string.Format(Messages.ErrorEmpty, Labels.cmpaddCoordinateLongitude) + "</br>";
			}
			if (base.ModelState.IsValid)
			{
				if (num == 0)
				{
					DbSet<CrmCompanyAddresses> crmCompanyAddresses = _dbTbl.CrmCompanyAddresses;
					ParameterExpression val = Expression.Parameter(typeof(CrmCompanyAddresses), "m");
					if (Queryable.FirstOrDefault<CrmCompanyAddresses>((IQueryable<CrmCompanyAddresses>)crmCompanyAddresses, Expression.Lambda<Func<CrmCompanyAddresses, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass12_, typeof(_003C_003Ec__DisplayClass12_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
					{
						DateTime now = DateTime.Now;
						string coordinateLastDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_dbI.CRMspUpdateCompanyAddressesCoordinate(_003C_003Ec__DisplayClass12_.model.CompanyAddressId, _003C_003Ec__DisplayClass12_.model.cmpaddCoordinateLatitude, _003C_003Ec__DisplayClass12_.model.cmpaddCoordinateLongitude, _003C_003Ec__DisplayClass12_.model.cmpaddCoordinateZoomLevel, now, coordinateLastDatePersian, UserLogin.CurrentUser.UserId);
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
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
		return View(_003C_003Ec__DisplayClass12_.model);
	}

	[AjaxOnly]
	public JsonResult GetCompanyAddressType()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyAddressType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyAddressType_Result>)Enumerable.ToList<CRMspSelectCompanyAddressType_Result>((IEnumerable<CRMspSelectCompanyAddressType_Result>)_dbI.CRMspSelectCompanyAddressType(lCID, result)), (Func<CRMspSelectCompanyAddressType_Result, SelectListItem>)((CRMspSelectCompanyAddressType_Result item) => new SelectListItem
			{
				Text = (item.CompanyAddressTypeName ?? ""),
				Value = item.CompanyAddressTypeId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CompanyAddressTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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

	public ActionResult SelectCompanyAddress(int cmpId, int position = 0)
	{
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.CmpName = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cmpId);
		base.ViewBag.Position = position;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialSelectCompanyAddress(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyAddresses_Result> model = new List<CRMspSelectCompanyAddresses_Result>();
		try
		{
			model = Enumerable.ToList<CRMspSelectCompanyAddresses_Result>((IEnumerable<CRMspSelectCompanyAddresses_Result>)_dbI.CRMspSelectCompanyAddresses(cmpId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(model);
	}

	public ActionResult ShowLocation(string lat = "", string lng = "", int? zoom = 0)
	{
		try
		{
			base.ViewBag.Latitude = lat;
			base.ViewBag.Longitude = lng;
			base.ViewBag.ZoomLevel = zoom;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
