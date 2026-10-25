using System;
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
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.Setting.Controllers;

public class NumRefSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public CrmNumRefSettingViewModel vm;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSettingNumR")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult GetNumRefSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CrmNumRefSettingViewModel data = new CrmNumRefSettingViewModel();
		try
		{
			CrmNumRefSetting crmNumRefSetting = Queryable.FirstOrDefault<CrmNumRefSetting>((IQueryable<CrmNumRefSetting>)_dbTbl.CrmNumRefSetting);
			if (crmNumRefSetting != null)
			{
				data = new CrmNumRefSettingViewModel
				{
					NumRefSettingId = crmNumRefSetting.NumRefSettingId,
					prjNumRefFormula = crmNumRefSetting.prjNumRefFormula,
					pordNumRefFormula = crmNumRefSetting.pordNumRefFormula,
					ordNumRefFormula = crmNumRefSetting.ordNumRefFormula,
					bordNumRefFormula = crmNumRefSetting.bordNumRefFormula,
					DocNumRefFormula = crmNumRefSetting.DocNumRefFormula,
					ctshNumRefFormula = crmNumRefSetting.ctshNumRefFormula,
					FileDirectoryNumRefFormula = crmNumRefSetting.FileDirectoryNumRefFormula
				};
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
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmNumRSetting", ActionName = "actPost")]
	public string InsertEdit(string strObj)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmNumRSetting", "actPost", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (string.IsNullOrEmpty(strObj))
			{
				return Messages.ErrorNotFound;
			}
			_003C_003Ec__DisplayClass4_.vm = new JavaScriptSerializer().Deserialize<CrmNumRefSettingViewModel>(strObj);
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short num = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short num2 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (_003C_003Ec__DisplayClass4_.vm.Mode == 1)
			{
				CrmNumRefSetting crmNumRefSetting = new CrmNumRefSetting();
				if (_003C_003Ec__DisplayClass4_.vm.NumRefSettingId > 0)
				{
					DbSet<CrmNumRefSetting> crmNumRefSetting2 = _dbTbl.CrmNumRefSetting;
					ParameterExpression val = Expression.Parameter(typeof(CrmNumRefSetting), "c");
					crmNumRefSetting = Queryable.FirstOrDefault<CrmNumRefSetting>((IQueryable<CrmNumRefSetting>)crmNumRefSetting2, Expression.Lambda<Func<CrmNumRefSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				crmNumRefSetting.prjNumRefFormula = _003C_003Ec__DisplayClass4_.vm.prjNumRefFormula;
				crmNumRefSetting.pordNumRefFormula = _003C_003Ec__DisplayClass4_.vm.pordNumRefFormula;
				crmNumRefSetting.ordNumRefFormula = _003C_003Ec__DisplayClass4_.vm.ordNumRefFormula;
				crmNumRefSetting.bordNumRefFormula = _003C_003Ec__DisplayClass4_.vm.bordNumRefFormula;
				crmNumRefSetting.DocNumRefFormula = _003C_003Ec__DisplayClass4_.vm.DocNumRefFormula;
				crmNumRefSetting.ctshNumRefFormula = _003C_003Ec__DisplayClass4_.vm.ctshNumRefFormula;
				crmNumRefSetting.FileDirectoryNumRefFormula = _003C_003Ec__DisplayClass4_.vm.FileDirectoryNumRefFormula;
				crmNumRefSetting.UserId = userId;
				crmNumRefSetting.Year1 = num2;
				crmNumRefSetting.Month1 = num;
				crmNumRefSetting.RegisterDate = dateTime;
				crmNumRefSetting.RegisterDatePersian = text;
				crmNumRefSetting.AppType = appType;
				if (crmNumRefSetting.NumRefSettingId > 0)
				{
					_dbTbl.Entry(crmNumRefSetting).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				}
				else
				{
					crmNumRefSetting.FirstRegisterUserId = userId;
					crmNumRefSetting.FirstRegisterDate = dateTime;
					crmNumRefSetting.FirstRegisterDatePersian = text;
					crmNumRefSetting.GUId = Guid.NewGuid();
					crmNumRefSetting.LanguageID = result2;
					_dbTbl.CrmNumRefSetting.Add(crmNumRefSetting);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				}
			}
			else if (_003C_003Ec__DisplayClass4_.vm.Mode == 2)
			{
				CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
				if (crmsysSetting == null)
				{
					return Messages.ErrorNotFound;
				}
				crmsysSetting.IsActivePrjNumRByAllPrj = _003C_003Ec__DisplayClass4_.vm.IsActivePrjNumRByAllPrj;
				crmsysSetting.IsActivePrjNumRByCmpPrj = _003C_003Ec__DisplayClass4_.vm.IsActivePrjNumRByCmpPrj;
				crmsysSetting.IsActivePordNumberByType = _003C_003Ec__DisplayClass4_.vm.IsActivePordNumberByType;
				crmsysSetting.AppType = appType;
				crmsysSetting.Year1 = num2;
				crmsysSetting.Month1 = num;
				crmsysSetting.RegisterDate = dateTime;
				_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				SysSeting.Update();
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysSetting");
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetNumRSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CrmNumRefSettingViewModel data = new CrmNumRefSettingViewModel();
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				data = new CrmNumRefSettingViewModel
				{
					IsActivePordNumberByType = cRMspSelectCrmsysSetting_Result.IsActivePordNumberByType,
					IsActivePrjNumRByAllPrj = cRMspSelectCrmsysSetting_Result.IsActivePrjNumRByAllPrj,
					IsActivePrjNumRByCmpPrj = cRMspSelectCrmsysSetting_Result.IsActivePrjNumRByCmpPrj
				};
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
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
