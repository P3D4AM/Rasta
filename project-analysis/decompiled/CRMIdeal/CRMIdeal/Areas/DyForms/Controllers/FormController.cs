using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.General.Text;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Company.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.DyForms.Controllers;

public class FormController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int fileId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public CrmFilesDirectory model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		internal bool _003CEditFile_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFile_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFile_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals1;

		internal bool _003CEditFile_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFile_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFile_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFile_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public CrmDyFormFieldValuesLanguageViewModel model;

		internal bool _003CIndex_003Eb__6(CRMspDySelectFormFields_Result m)
		{
			if (m.FormId == model.WdSubFormId)
			{
				return m.IsRequired.GetValueOrDefault();
			}
			return false;
		}

		internal bool _003CIndex_003Eb__3(CRMspDySelectFormFields_Result m)
		{
			if (m.FormId == model.FormId)
			{
				return m.IsRequired.GetValueOrDefault();
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_2
	{
		public CrmDyFormFieldMasterValues masterVal;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_6
	{
		public mct_CRMspDySelectFormFieldValues_Result val;

		internal bool _003CIndex_003Eb__25(CRMspDySelectForms_Result m)
		{
			return m.FormId == val.FormId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_7
	{
		public CrmDyFormFieldValues valus;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_8
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass7_7 CS_0024_003C_003E8__locals1;

		internal bool _003CIndex_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[LoginAuthorize]
	public ActionResult Index(int formId, string partTitle = "", int position = 1, int? cmpId = null, int? prsId = null, int? prjId = null, int? cnvsId = null, int? mObjId = null, int? dObjId = null, int? subObjId = null, int? mValId = null, int? selWorkflowStepId = null, int dyInPopup = 0, string parentFrameName = "", int tempDataId = 0, int tempDataSysPartIdI = 0, bool fromOtherPartSys = false)
	{
		CrmDyFormFieldValuesLanguageViewModel crmDyFormFieldValuesLanguageViewModel = new CrmDyFormFieldValuesLanguageViewModel();
		string text = "";
		bool flag = false;
		bool flag2 = false;
		int? crmSysPartId = 0;
		int? fOSysPartId = 0;
		base.ViewBag.DyInPopup = dyInPopup;
		base.ViewBag.ParentFrameName = parentFrameName;
		base.ViewBag.TempDataSysPartIdI = tempDataSysPartIdI;
		base.ViewBag.FromOtherPartSys = fromOtherPartSys;
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
			int userId = UserLogin.CurrentUser.UserId;
			string text2 = "";
			string text3 = "";
			if (position == 1)
			{
				text2 = "frmDyDefineForm";
				text3 = "actShowForm";
			}
			if (text2 != "" && text3 != "" && !UserLogin.IsUserAccess(text2, text3, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			List<CRMspDySelectFormUserAccess_Result> list = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)_db.CRMspDySelectFormUserAccess(UserLogin.CurrentUser.UserId, lCID, result, result2));
			bool flag3 = true;
			if (Enumerable.Any<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list))
			{
				if (Enumerable.FirstOrDefault<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list, (Func<CRMspDySelectFormUserAccess_Result, bool>)((CRMspDySelectFormUserAccess_Result m) => m.FormId == formId)) == null)
				{
					flag3 = false;
				}
			}
			else
			{
				flag3 = false;
			}
			if (!flag3)
			{
				base.ViewBag.FlagIsAccess = Messages.NotAccessToPage;
				crmDyFormFieldValuesLanguageViewModel = new CrmDyFormFieldValuesLanguageViewModel
				{
					FormId = 0,
					Position = 1
				};
				return View(crmDyFormFieldValuesLanguageViewModel);
			}
			CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(formId, 0, lCID, result, result2));
			if (cRMspDySelectForms_Result != null)
			{
				flag2 = ((cRMspDySelectForms_Result.WorkflowId.HasValue && cRMspDySelectForms_Result.WorkflowId > 0) ? true : false);
				text = ((!string.IsNullOrEmpty(cRMspDySelectForms_Result.FormName)) ? cRMspDySelectForms_Result.FormName : "");
				flag = cRMspDySelectForms_Result.CrmSysPartId.GetValueOrDefault() == 1 || cRMspDySelectForms_Result.FOSysPartId.GetValueOrDefault() == 100;
				crmSysPartId = cRMspDySelectForms_Result.CrmSysPartId;
				fOSysPartId = cRMspDySelectForms_Result.FOSysPartId;
			}
			DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
			ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
			bool value = Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			string companyName = "";
			CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId.GetValueOrDefault());
			if (companyById != null)
			{
				companyName = companyById.CompanyName ?? "";
			}
			if (fromOtherPartSys && mValId.GetValueOrDefault() == 0 && tempDataId == 0)
			{
				mct_CRMspDySelectFormFieldMasterValues_Result mct_CRMspDySelectFormFieldMasterValues_Result = Enumerable.LastOrDefault<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)_db.mfi_CRMspDySelectFormFieldMasterValues(formId, (cmpId.GetValueOrDefault() == 0) ? null : cmpId, (prsId.GetValueOrDefault() == 0) ? null : prsId, (prjId.GetValueOrDefault() == 0) ? null : prjId, (cnvsId.GetValueOrDefault() == 0) ? null : cnvsId, (mObjId.GetValueOrDefault() == 0) ? null : mObjId, (dObjId.GetValueOrDefault() == 0) ? null : dObjId, (subObjId.GetValueOrDefault() == 0) ? null : subObjId, lCID, result, userId, result2));
				if (mct_CRMspDySelectFormFieldMasterValues_Result != null)
				{
					mValId = mct_CRMspDySelectFormFieldMasterValues_Result.FormFieldMasterValueId.GetValueOrDefault();
				}
			}
			crmDyFormFieldValuesLanguageViewModel = new CrmDyFormFieldValuesLanguageViewModel
			{
				FormId = formId,
				Position = position,
				PartTitle = partTitle,
				CompanyId = cmpId,
				CompanyPersonId = prsId,
				ProjectId = prjId,
				ConversationId = cnvsId,
				MasterObjectId = mObjId,
				DetailObjectId = dObjId,
				SubDetailObjectId = subObjId,
				MasterValueId = mValId.GetValueOrDefault(),
				CountFile = value,
				CrmSysPartId = crmSysPartId,
				FOSysPartId = fOSysPartId,
				CompanyName = companyName,
				TempDataId = tempDataId
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FormName = text;
		base.ViewBag.IsFreeForm = flag;
		base.ViewBag.IsWorkflow = flag2;
		if (flag2)
		{
			crmDyFormFieldValuesLanguageViewModel.SendIntMsgForMultiReferUsers = true;
			crmDyFormFieldValuesLanguageViewModel.SendIntMsgForCheckerUsers = true;
		}
		else
		{
			crmDyFormFieldValuesLanguageViewModel.SendIntMsgForMultiReferUsers = false;
			crmDyFormFieldValuesLanguageViewModel.SendIntMsgForCheckerUsers = false;
		}
		base.ViewBag.SelWorkflowStepId = selWorkflowStepId;
		return View(crmDyFormFieldValuesLanguageViewModel);
	}

	[LoginAuthorize]
	public ActionResult OpenFormMasterValue(int? masterValId = null)
	{
		if (masterValId.GetValueOrDefault() != 0)
		{
			try
			{
				int? formId = null;
				int? position = null;
				int? cmpId = null;
				int? prsId = null;
				int? prjId = null;
				int? cnvsId = null;
				int? mObjId = null;
				int? dObjId = null;
				int? subObjId = null;
				int? mValId = null;
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(masterValId, lCID, result));
					if (cRMspDySelectFormFieldMasterValueWithId_Result != null)
					{
						formId = cRMspDySelectFormFieldMasterValueWithId_Result.FormId;
						position = 0;
						cmpId = cRMspDySelectFormFieldMasterValueWithId_Result.CompanyId;
						prsId = cRMspDySelectFormFieldMasterValueWithId_Result.CompanyPersonId;
						prjId = cRMspDySelectFormFieldMasterValueWithId_Result.ProjectId;
						cnvsId = cRMspDySelectFormFieldMasterValueWithId_Result.ConversationId;
						mObjId = cRMspDySelectFormFieldMasterValueWithId_Result.MasterObjectId;
						dObjId = cRMspDySelectFormFieldMasterValueWithId_Result.DetailObjectId;
						subObjId = cRMspDySelectFormFieldMasterValueWithId_Result.SubDetailObjectId;
						mValId = cRMspDySelectFormFieldMasterValueWithId_Result.FormFieldMasterValueId;
					}
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
				return RedirectToAction("Index", (object)new { formId, position, cmpId, prsId, prjId, cnvsId, mObjId, dObjId, subObjId, mValId });
			}
			catch (Exception ex2)
			{
				Public.InsExceptToElmah(ex2);
			}
		}
		return View("Index");
	}

	[HttpPost]
	[AllowAnonymous]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmDyForm", ActionName = "actPost,actPostSubForm")]
	public ActionResult Index(CrmDyFormFieldValuesLanguageViewModel model, HttpPostedFileBase[] formFileSending)
	{
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_20cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b45: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b58: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.model = model;
		List<CRMspDySelectForms_Result> list = new List<CRMspDySelectForms_Result>();
		List<CRMspDySelectFormFields_Result> list2 = new List<CRMspDySelectFormFields_Result>();
		string text = "";
		bool flag = false;
		DateTime now = DateTime.Now;
		List<IdKeyValueItemViewModel> list3 = new List<IdKeyValueItemViewModel>();
		List<IdKeyValueItemViewModel> list4 = new List<IdKeyValueItemViewModel>();
		bool flag2 = false;
		int? num = null;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.UserLastCId;
		}
		int? fileCId = null;
		if (num.GetValueOrDefault() != 0)
		{
			fileCId = num;
		}
		try
		{
			int result = 0;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short num2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short num3 = short.Parse(Financial.Get().Id.ToString());
			CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(CS_0024_003C_003E8__locals0.model.FormId, 0, currLangID, defLangID, num));
			if (cRMspDySelectForms_Result == null)
			{
				base.ViewBag.Error = Messages.MsgFormNotDefined;
			}
			else
			{
				int.TryParse(cRMspDySelectForms_Result.WorkflowId.ToString(), out result);
				flag2 = result > 0;
				text = ((!string.IsNullOrEmpty(cRMspDySelectForms_Result.FormName)) ? cRMspDySelectForms_Result.FormName : "");
				flag = cRMspDySelectForms_Result.CrmSysPartId.GetValueOrDefault() == 1 || cRMspDySelectForms_Result.FOSysPartId.GetValueOrDefault() == 100;
				List<CRMspDySelectForms_Result> collection = Enumerable.ToList<CRMspDySelectForms_Result>(Enumerable.Where<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(0, CS_0024_003C_003E8__locals0.model.FormId, currLangID, defLangID, num), (Func<CRMspDySelectForms_Result, bool>)((CRMspDySelectForms_Result m) => m.IsActive.GetValueOrDefault())));
				list.Add(cRMspDySelectForms_Result);
				list.AddRange(collection);
				if (Enumerable.Any<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)list))
				{
					foreach (CRMspDySelectForms_Result item in list)
					{
						List<CRMspDySelectFormFields_Result> list5 = Enumerable.ToList<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)_db.CRMspDySelectFormFields(0, item.FormId, null, currLangID, defLangID));
						if (list5 != null && Enumerable.Any<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list5))
						{
							list2.AddRange(list5);
						}
					}
				}
			}
			ParameterExpression val;
			if (CS_0024_003C_003E8__locals0.model.MasterValueId <= 0 && !VersionBuyer.DyForm)
			{
				DbSet<CrmDyFormFieldMasterValues> crmDyFormFieldMasterValues = _dbTbl.CrmDyFormFieldMasterValues;
				val = Expression.Parameter(typeof(CrmDyFormFieldMasterValues), "c");
				if (Queryable.Any<CrmDyFormFieldMasterValues>((IQueryable<CrmDyFormFieldMasterValues>)crmDyFormFieldMasterValues, Expression.Lambda<Func<CrmDyFormFieldMasterValues, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					base.ViewBag.FormName = text;
					base.ViewBag.IsFreeForm = flag;
					base.ViewBag.IsWorkflow = flag2;
					CS_0024_003C_003E8__locals0.model.CanSave = false;
					return View(CS_0024_003C_003E8__locals0.model);
				}
			}
			bool result2 = false;
			bool.TryParse(CS_0024_003C_003E8__locals0.model.CanSave.ToString(), out result2);
			if (result2)
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ValueDetails))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<IdKeyValueItemViewModel>>(CS_0024_003C_003E8__locals0.model.ValueDetails);
				}
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ValueDetails_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<IdKeyValueItemViewModel>>(CS_0024_003C_003E8__locals0.model.ValueDetails_Lang);
				}
				if (DyForm.IsChecked(CS_0024_003C_003E8__locals0.model.MasterValueId))
				{
					base.ModelState.AddModelError("error", Messages.msgFormIsChecked);
				}
				else
				{
					if (CS_0024_003C_003E8__locals0.model.MasterValueId <= 0 || !(CS_0024_003C_003E8__locals0.model.MasterValueDetailId > 0))
					{
						goto IL_0690;
					}
					int result3 = 0;
					int.TryParse(CS_0024_003C_003E8__locals0.model.MasterValueDetailId.ToString(), out result3);
					if (!DyForm.SubFormIsChecked(result3))
					{
						goto IL_0690;
					}
					base.ModelState.AddModelError("error", Messages.msgFormIsChecked);
				}
			}
			goto end_IL_006b;
			IL_090b:
			_003C_003Ec__DisplayClass7_2 _003C_003Ec__DisplayClass7_;
			List<mct_CRMspDySelectFormFieldValues_Result> list6;
			if (!base.ModelState.IsValid)
			{
				base.ModelState.AddModelError("error", Messages.msgErrorRunFunction);
			}
			else
			{
				_003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_2();
				string text3 = "*";
				if (cRMspDySelectForms_Result != null)
				{
					text3 = ((!string.IsNullOrEmpty(cRMspDySelectForms_Result.UploadFileExtension)) ? cRMspDySelectForms_Result.UploadFileExtension : "*");
				}
				if (formFileSending != null)
				{
					HttpPostedFileBase[] array = formFileSending;
					int num4 = 0;
					while (num4 < array.Length)
					{
						HttpPostedFileBase val2 = array[num4];
						val2.ContentType.ToLower();
						string text4 = ((val2.FileName != null) ? Path.GetExtension(val2.FileName).ToLower() : "");
						if (text3 != "*" && !string.IsNullOrEmpty(text3) && text3.IndexOf(text4, StringComparison.Ordinal) < 0)
						{
							base.ModelState.AddModelError("error", string.Format(Messages.msgErrorMessageFileExtension, text3));
						}
						else
						{
							string text5 = (text4 ?? "").ToLower();
							text5 = text5.Replace(".", "");
							if (Configuration.MaliciousFileExtensions.Contains(text5))
							{
								base.ModelState.AddModelError("error", Messages.msgErrorFileIsExecuted);
							}
							else
							{
								int num5 = cRMspDySelectForms_Result.UploadFileMaxSize.GetValueOrDefault() * 1024;
								if (val2.ContentLength <= num5)
								{
									num4++;
									continue;
								}
								string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(val2.ContentLength);
								string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num5);
								string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
								base.ModelState.AddModelError("error", string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2));
							}
						}
						goto end_IL_006b;
					}
				}
				_003C_003Ec__DisplayClass7_.masterVal = new CrmDyFormFieldMasterValues();
				bool flag3 = false;
				if (CS_0024_003C_003E8__locals0.model.MasterValueId > 0)
				{
					DbSet<CrmDyFormFieldMasterValues> crmDyFormFieldMasterValues2 = _dbTbl.CrmDyFormFieldMasterValues;
					val = Expression.Parameter(typeof(CrmDyFormFieldMasterValues), "m");
					_003C_003Ec__DisplayClass7_.masterVal = Queryable.FirstOrDefault<CrmDyFormFieldMasterValues>((IQueryable<CrmDyFormFieldMasterValues>)crmDyFormFieldMasterValues2, Expression.Lambda<Func<CrmDyFormFieldMasterValues, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				if (_003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId > 0)
				{
					if (!CS_0024_003C_003E8__locals0.model.WdSubFormId.HasValue && !CS_0024_003C_003E8__locals0.model.WorkflowStepId.HasValue)
					{
						_003C_003Ec__DisplayClass7_.masterVal.UserId = userId;
						_003C_003Ec__DisplayClass7_.masterVal.RegisterDate = now;
						_003C_003Ec__DisplayClass7_.masterVal.RegisterDatePersian = text2;
						_003C_003Ec__DisplayClass7_.masterVal.Year1 = num3;
						_003C_003Ec__DisplayClass7_.masterVal.Month1 = num2;
						_003C_003Ec__DisplayClass7_.masterVal.AppType = appType;
						_dbTbl.Entry(_003C_003Ec__DisplayClass7_.masterVal).State = EntityState.Modified;
						_dbTbl.SaveChanges();
					}
					if (result == 0)
					{
						_db.CRMspDyInsertUpdateFormFieldMasterValueDetails(2, _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId, _003C_003Ec__DisplayClass7_.masterVal.FormId, userId, now, text2, num3, num2, appType, defLangID);
					}
				}
				else
				{
					flag3 = true;
					_003C_003Ec__DisplayClass7_.masterVal = new CrmDyFormFieldMasterValues
					{
						FormId = CS_0024_003C_003E8__locals0.model.FormId,
						CompanyId = CS_0024_003C_003E8__locals0.model.CompanyId,
						CompanyPersonId = CS_0024_003C_003E8__locals0.model.CompanyPersonId,
						ProjectId = CS_0024_003C_003E8__locals0.model.ProjectId,
						ConversationId = CS_0024_003C_003E8__locals0.model.ConversationId,
						MasterObjectId = CS_0024_003C_003E8__locals0.model.MasterObjectId,
						DetailObjectId = CS_0024_003C_003E8__locals0.model.DetailObjectId,
						SubDetailObjectId = CS_0024_003C_003E8__locals0.model.SubDetailObjectId,
						FirstRegisterUserId = userId,
						FirstRegisterDate = now,
						FirstRegisterDatePersian = text2,
						UserId = userId,
						RegisterDate = now,
						RegisterDatePersian = text2,
						Year1 = num3,
						Month1 = num2,
						GUId = System.Guid.NewGuid(),
						AppType = appType,
						LanguageID = defLangID,
						WorkflowId = ((result > 0) ? new int?(result) : null),
						WorkflowStepId = CS_0024_003C_003E8__locals0.model.WorkflowStepId,
						CId = num
					};
					_dbTbl.CrmDyFormFieldMasterValues.Add(_003C_003Ec__DisplayClass7_.masterVal);
					_dbTbl.SaveChanges();
					if (result == 0 && _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId > 0)
					{
						_db.CRMspDyInsertUpdateFormFieldMasterValueDetails(1, _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId, _003C_003Ec__DisplayClass7_.masterVal.FormId, userId, now, text2, num3, num2, appType, defLangID);
					}
				}
				list6 = new List<mct_CRMspDySelectFormFieldValues_Result>();
				if (_003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId > 0)
				{
					foreach (CRMspDySelectForms_Result item2 in list)
					{
						List<mct_CRMspDySelectFormFieldValues_Result> list7 = Enumerable.ToList<mct_CRMspDySelectFormFieldValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldValues_Result>)_db.mfi_CRMspDySelectFormFieldValues(item2.FormId, _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId, CS_0024_003C_003E8__locals0.model.CompanyId, CS_0024_003C_003E8__locals0.model.CompanyPersonId, CS_0024_003C_003E8__locals0.model.ProjectId, CS_0024_003C_003E8__locals0.model.ConversationId, CS_0024_003C_003E8__locals0.model.MasterObjectId, CS_0024_003C_003E8__locals0.model.DetailObjectId, CS_0024_003C_003E8__locals0.model.SubDetailObjectId, currLangID, defLangID));
						if (list7 != null)
						{
							list6.AddRange(list7);
						}
					}
				}
				if (!Enumerable.Any<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list2))
				{
					goto IL_1805;
				}
				string text6 = "";
				int num6 = 0;
				List<CRMspDySelectFormFields_Result> list8 = new List<CRMspDySelectFormFields_Result>();
				if (!(CS_0024_003C_003E8__locals0.model.WdSubFormId > 0) || !(CS_0024_003C_003E8__locals0.model.WorkflowStepId > 0))
				{
					list8 = ((result <= 0) ? Enumerable.ToList<CRMspDySelectFormFields_Result>(Enumerable.Where<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list2, (Func<CRMspDySelectFormFields_Result, bool>)((CRMspDySelectFormFields_Result m) => m.IsRequired.GetValueOrDefault()))) : Enumerable.ToList<CRMspDySelectFormFields_Result>(Enumerable.Where<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list2, (Func<CRMspDySelectFormFields_Result, bool>)((CRMspDySelectFormFields_Result m) => m.FormId == CS_0024_003C_003E8__locals0.model.FormId && m.IsRequired.GetValueOrDefault()))));
				}
				else
				{
					CRMspDySelectFormWorkflowStepBFCurr_Result wdetail = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepBFCurr_Result>((IEnumerable<CRMspDySelectFormWorkflowStepBFCurr_Result>)_db.CRMspDySelectFormWorkflowStepBFCurr(result, CS_0024_003C_003E8__locals0.model.WorkflowStepId, _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId, CS_0024_003C_003E8__locals0.model.WdSubFormId, currLangID, defLangID));
					list8 = ((wdetail == null) ? Enumerable.ToList<CRMspDySelectFormFields_Result>(Enumerable.Where<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list2, (Func<CRMspDySelectFormFields_Result, bool>)((CRMspDySelectFormFields_Result m) => m.FormId == CS_0024_003C_003E8__locals0.model.WdSubFormId && m.IsRequired.GetValueOrDefault()))) : Enumerable.ToList<CRMspDySelectFormFields_Result>(Enumerable.Where<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list2, (Func<CRMspDySelectFormFields_Result, bool>)((CRMspDySelectFormFields_Result m) => m.FormId == wdetail.SubFormId && m.IsRequired.GetValueOrDefault()))));
				}
				if (!Enumerable.Any<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list8))
				{
					goto IL_1805;
				}
				foreach (IdKeyValueItemViewModel item3 in list3)
				{
					string ids2 = item3.Id ?? "";
					int formId2 = 0;
					int fieldId2 = 0;
					if (ids2 != "")
					{
						string[] array2 = ids2.Split(new char[1] { '_' });
						if (array2 != null)
						{
							formId2 = int.Parse(array2[0]);
							fieldId2 = int.Parse(array2[1]);
						}
					}
					CRMspDySelectFormFields_Result cRMspDySelectFormFields_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list8, (Func<CRMspDySelectFormFields_Result, bool>)((CRMspDySelectFormFields_Result m) => m.FormFieldId == fieldId2));
					if (cRMspDySelectFormFields_Result == null)
					{
						continue;
					}
					if (result == 0)
					{
						CRMspDySelectForms_Result cRMspDySelectForms_Result2 = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)list, (Func<CRMspDySelectForms_Result, bool>)((CRMspDySelectForms_Result m) => m.FormId == formId2));
						if (cRMspDySelectForms_Result2 != null)
						{
							bool flag4 = true;
							bool flag5 = false;
							if (cRMspDySelectForms_Result2.EnableForRollId.HasValue)
							{
								flag4 = cRMspDySelectForms_Result2.EnableForRollId == UserLogin.CurrentUser.RollId || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser);
							}
							else if (!string.IsNullOrEmpty(cRMspDySelectForms_Result2.EnableForUsersId))
							{
								string[] array3 = cRMspDySelectForms_Result2.EnableForUsersId.Split(new char[1] { '|' });
								if (Enumerable.Any<string>((IEnumerable<string>)array3))
								{
									foreach (string item4 in Enumerable.Where<string>((IEnumerable<string>)array3, (Func<string, bool>)((string usr) => !string.IsNullOrEmpty(usr))))
									{
										if (!flag5)
										{
											if (item4 == UserLogin.CurrentUser.UserId.ToString() || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
											{
												flag4 = true;
												flag5 = true;
											}
											else
											{
												flag4 = false;
											}
										}
									}
								}
							}
							if (!flag4)
							{
								continue;
							}
						}
					}
					CRMspDySelectFormFields_Result fld2 = Enumerable.FirstOrDefault<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list2, (Func<CRMspDySelectFormFields_Result, bool>)((CRMspDySelectFormFields_Result m) => m.FormFieldId == fieldId2));
					if (fld2 != null && !string.IsNullOrEmpty(item3.Value) && fld2.FieldTypeId.GetValueOrDefault() == 4)
					{
						item3.Value = item3.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						string formatetdDate = PersianDate.GetFormatetdDate(item3.Value.Replace("/", ""));
						if (currLangID == 1065)
						{
							item3.Value = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd");
						}
						else if (currLangID == 1025)
						{
							item3.Value = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture());
						}
						else
						{
							item3.Value = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture());
						}
					}
					IdKeyValueItemViewModel idKeyValueItemViewModel = Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list4, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == ids2));
					List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
					if (idKeyValueItemViewModel != null)
					{
						if (!string.IsNullOrEmpty(idKeyValueItemViewModel.Value))
						{
							list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(idKeyValueItemViewModel.Value);
						}
					}
					else
					{
						foreach (Languages item5 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != currLangID))))
						{
							string value = "";
							if (fld2 == null)
							{
								continue;
							}
							switch (fld2.FieldTypeId)
							{
							case 2:
							case 4:
							case 5:
								value = item3.Value;
								break;
							case 6:
							case 7:
							case 8:
								if (list6 != null && Enumerable.Any<mct_CRMspDySelectFormFieldValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldValues_Result>)list6))
								{
									mct_CRMspDySelectFormFieldValues_Result mct_CRMspDySelectFormFieldValues_Result = Enumerable.FirstOrDefault<mct_CRMspDySelectFormFieldValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldValues_Result>)list6, (Func<mct_CRMspDySelectFormFieldValues_Result, bool>)((mct_CRMspDySelectFormFieldValues_Result m) => m.FieldId == fld2.FormFieldId));
									if (mct_CRMspDySelectFormFieldValues_Result != null)
									{
										value = Enumerable.FirstOrDefault<CRMspDySelectFormFieldValuesWithId_Result>((IEnumerable<CRMspDySelectFormFieldValuesWithId_Result>)_db.CRMspDySelectFormFieldValuesWithId(mct_CRMspDySelectFormFieldValues_Result.FormFieldValueId, item5.LanguageID, defLangID))?.Value;
									}
								}
								break;
							}
							list9.Add(new CommonMultiLanguageViewModel
							{
								Value = value,
								LanguageId = item5.LanguageID
							});
						}
					}
					list9.Add(new CommonMultiLanguageViewModel
					{
						Value = item3.Value,
						LanguageId = currLangID
					});
					string text7 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : null);
					if (string.IsNullOrEmpty(text7))
					{
						text6 = text6 + string.Format(Messages.ErrorEmpty, cRMspDySelectFormFields_Result.FieldTitle ?? "") + "<br/>";
						num6++;
					}
					else if (!checkMultiLanguage(text7, list9))
					{
						text6 = text6 + text6 + string.Format(Messages.CheckFieldInLang, cRMspDySelectFormFields_Result.FieldTitle ?? "") + "<br>";
						num6++;
					}
				}
				if (num6 <= 0)
				{
					goto IL_1805;
				}
				base.ModelState.AddModelError("error", text6);
				base.ViewBag.Error = text6;
				if (flag3)
				{
					try
					{
						Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDyDeleteFormFieldMasterValue(_003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
			}
			goto end_IL_006b;
			IL_0690:
			if (CS_0024_003C_003E8__locals0.model.WdSubFormId > 0 && CS_0024_003C_003E8__locals0.model.WorkflowStepId > 0)
			{
				CRMspDySelectFormWorkflowStepWithId_Result cRMspDySelectFormWorkflowStepWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepWithId_Result>((IEnumerable<CRMspDySelectFormWorkflowStepWithId_Result>)_db.CRMspDySelectFormWorkflowStepWithId(CS_0024_003C_003E8__locals0.model.WorkflowStepId, currLangID, defLangID, num));
				if (cRMspDySelectFormWorkflowStepWithId_Result == null)
				{
					goto IL_090b;
				}
				string text8 = cRMspDySelectFormWorkflowStepWithId_Result.ReferUserIds ?? "";
				if (string.IsNullOrEmpty(text8))
				{
					goto IL_090b;
				}
				bool flag6 = false;
				string[] array4 = text8.Split(new char[1] { '|' });
				if (array4 != null)
				{
					string[] array5 = array4;
					foreach (string text9 in array5)
					{
						if (!string.IsNullOrEmpty(text9) && int.Parse(text9) == userId)
						{
							flag6 = true;
							break;
						}
					}
				}
				if (flag6 || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
				{
					goto IL_090b;
				}
				string text10 = string.Format(Messages.msgErrorYouNotDyFormReferUsers, cRMspDySelectFormWorkflowStepWithId_Result.SubForm);
				base.ModelState.AddModelError("error", Messages.DyFrmUserNotAccess + "<br>" + text10);
			}
			else
			{
				if (result <= 0 || cRMspDySelectForms_Result == null)
				{
					goto IL_090b;
				}
				bool flag7 = false;
				int? enableForRollId = cRMspDySelectForms_Result.EnableForRollId;
				string text11 = cRMspDySelectForms_Result.EnableForUsersId ?? "";
				if (enableForRollId.HasValue)
				{
					flag7 = enableForRollId == UserLogin.CurrentUser.RollId;
				}
				else if (!string.IsNullOrEmpty(text11))
				{
					string[] array6 = text11.Split(new char[1] { '|' });
					if (array6 != null)
					{
						string[] array5 = array6;
						foreach (string text12 in array5)
						{
							if (!string.IsNullOrEmpty(text12) && int.Parse(text12) == userId)
							{
								flag7 = true;
								break;
							}
						}
					}
				}
				else
				{
					flag7 = true;
				}
				if (flag7 || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
				{
					goto IL_090b;
				}
				string text13 = string.Format(Messages.msgErrorYouNotDyFormReferUsers, cRMspDySelectForms_Result.FormName ?? "");
				base.ModelState.AddModelError("error", Messages.DyFrmUserNotAccess + "<br>" + text13);
			}
			goto end_IL_006b;
			IL_1e42:
			foreach (IdKeyValueItemViewModel item6 in list3)
			{
				string ids = item6.Id ?? "";
				int formId = 0;
				int fieldId = 0;
				if (ids != "")
				{
					string[] array7 = ids.Split(new char[1] { '_' });
					if (array7 != null)
					{
						formId = int.Parse(array7[0]);
						fieldId = int.Parse(array7[1]);
					}
				}
				CRMspDySelectFormFields_Result fld = Enumerable.FirstOrDefault<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list2, (Func<CRMspDySelectFormFields_Result, bool>)((CRMspDySelectFormFields_Result m) => m.FormFieldId == fieldId));
				if (fld != null && !string.IsNullOrEmpty(item6.Value) && fld.FieldTypeId.GetValueOrDefault() == 4)
				{
					item6.Value = item6.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					string formatetdDate2 = PersianDate.GetFormatetdDate(item6.Value.Replace("/", ""));
					if (currLangID == 1065)
					{
						item6.Value = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd");
					}
					else if (currLangID == 1025)
					{
						item6.Value = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture());
					}
					else
					{
						item6.Value = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				IdKeyValueItemViewModel idKeyValueItemViewModel2 = Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list4, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == ids));
				List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
				if (idKeyValueItemViewModel2 != null)
				{
					if (!string.IsNullOrEmpty(idKeyValueItemViewModel2.Value))
					{
						list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(idKeyValueItemViewModel2.Value);
					}
				}
				else
				{
					foreach (Languages item7 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != currLangID))))
					{
						string value2 = "";
						if (fld == null)
						{
							continue;
						}
						switch (fld.FieldTypeId)
						{
						case 2:
						case 4:
						case 5:
							value2 = item6.Value;
							break;
						case 6:
						case 7:
						case 8:
							if (list6 != null && Enumerable.Any<mct_CRMspDySelectFormFieldValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldValues_Result>)list6))
							{
								mct_CRMspDySelectFormFieldValues_Result mct_CRMspDySelectFormFieldValues_Result2 = Enumerable.FirstOrDefault<mct_CRMspDySelectFormFieldValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldValues_Result>)list6, (Func<mct_CRMspDySelectFormFieldValues_Result, bool>)((mct_CRMspDySelectFormFieldValues_Result m) => m.FieldId == fld.FormFieldId));
								if (mct_CRMspDySelectFormFieldValues_Result2 != null)
								{
									value2 = Enumerable.FirstOrDefault<CRMspDySelectFormFieldValuesWithId_Result>((IEnumerable<CRMspDySelectFormFieldValuesWithId_Result>)_db.CRMspDySelectFormFieldValuesWithId(mct_CRMspDySelectFormFieldValues_Result2.FormFieldValueId, item7.LanguageID, defLangID))?.Value;
								}
							}
							break;
						}
						list10.Add(new CommonMultiLanguageViewModel
						{
							Value = value2,
							LanguageId = item7.LanguageID
						});
					}
				}
				list10.Add(new CommonMultiLanguageViewModel
				{
					Value = item6.Value,
					LanguageId = currLangID
				});
				string text14 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : null);
				if (!string.IsNullOrEmpty(text14) && (fld.FieldTypeId.GetValueOrDefault() == 1 || fld.FieldTypeId.GetValueOrDefault() == 3))
				{
					checkMultiLanguage(text14, list10);
				}
				if (_003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId <= 0)
				{
					continue;
				}
				if (list6 != null && list6.Count > 0)
				{
					_003C_003Ec__DisplayClass7_6 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass7_6();
					CS_0024_003C_003E8__locals3.val = Enumerable.FirstOrDefault<mct_CRMspDySelectFormFieldValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldValues_Result>)list6, (Func<mct_CRMspDySelectFormFieldValues_Result, bool>)((mct_CRMspDySelectFormFieldValues_Result m) => m.FormId == formId && m.FieldId == fieldId));
					if (CS_0024_003C_003E8__locals3.val != null)
					{
						_003C_003Ec__DisplayClass7_7 _003C_003Ec__DisplayClass7_2 = new _003C_003Ec__DisplayClass7_7();
						CRMspDySelectForms_Result cRMspDySelectForms_Result3 = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)list, (Func<CRMspDySelectForms_Result, bool>)((CRMspDySelectForms_Result m) => m.FormId == CS_0024_003C_003E8__locals3.val.FormId));
						if (cRMspDySelectForms_Result3 != null)
						{
							bool flag8 = true;
							bool flag9 = false;
							if (result == 0 || (CS_0024_003C_003E8__locals0.model.WorkflowStepId.GetValueOrDefault() == 0 && CS_0024_003C_003E8__locals0.model.WdSubFormId.GetValueOrDefault() == 0 && CS_0024_003C_003E8__locals0.model.FormId == cRMspDySelectForms_Result3.FormId))
							{
								if (cRMspDySelectForms_Result3.EnableForRollId.HasValue)
								{
									flag8 = cRMspDySelectForms_Result3.EnableForRollId == UserLogin.CurrentUser.RollId || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser);
								}
								else if (!string.IsNullOrEmpty(cRMspDySelectForms_Result3.EnableForUsersId))
								{
									string[] array8 = cRMspDySelectForms_Result3.EnableForUsersId.Split(new char[1] { '|' });
									if (Enumerable.Any<string>((IEnumerable<string>)array8))
									{
										foreach (string item8 in Enumerable.Where<string>((IEnumerable<string>)array8, (Func<string, bool>)((string usr) => !string.IsNullOrEmpty(usr))))
										{
											if (!flag9)
											{
												if (item8 == UserLogin.CurrentUser.UserId.ToString() || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
												{
													flag8 = true;
													flag9 = true;
												}
												else
												{
													flag8 = false;
												}
											}
										}
									}
								}
							}
							else if (CS_0024_003C_003E8__locals0.model.WorkflowStepId > 0 && CS_0024_003C_003E8__locals0.model.WdSubFormId > 0 && CS_0024_003C_003E8__locals0.model.WdSubFormId == cRMspDySelectForms_Result3.FormId)
							{
								CRMspDySelectFormWorkflowStepWithId_Result cRMspDySelectFormWorkflowStepWithId_Result2 = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepWithId_Result>((IEnumerable<CRMspDySelectFormWorkflowStepWithId_Result>)_db.CRMspDySelectFormWorkflowStepWithId(CS_0024_003C_003E8__locals0.model.WorkflowStepId, currLangID, defLangID, num));
								if (cRMspDySelectFormWorkflowStepWithId_Result2 != null)
								{
									string text15 = cRMspDySelectFormWorkflowStepWithId_Result2.ReferUserIds ?? "";
									if (!string.IsNullOrEmpty(text15))
									{
										bool flag10 = false;
										string[] array9 = text15.Split(new char[1] { '|' });
										if (array9 != null)
										{
											string[] array5 = array9;
											foreach (string text16 in array5)
											{
												if (!string.IsNullOrEmpty(text16) && int.Parse(text16) == userId)
												{
													flag10 = true;
													break;
												}
											}
										}
										if (!flag10 && !UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
										{
											flag8 = false;
										}
									}
								}
							}
							else
							{
								flag8 = false;
							}
							if (!flag8)
							{
								continue;
							}
						}
						DbSet<CrmDyFormFieldValues> crmDyFormFieldValues = _dbTbl.CrmDyFormFieldValues;
						val = Expression.Parameter(typeof(CrmDyFormFieldValues), "c");
						_003C_003Ec__DisplayClass7_2.valus = Queryable.FirstOrDefault<CrmDyFormFieldValues>((IQueryable<CrmDyFormFieldValues>)crmDyFormFieldValues, Expression.Lambda<Func<CrmDyFormFieldValues, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals3, typeof(_003C_003Ec__DisplayClass7_6)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (_003C_003Ec__DisplayClass7_2.valus == null)
						{
							continue;
						}
						_003C_003Ec__DisplayClass7_2.valus.Value = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass7_2.valus.UserId = userId;
						_003C_003Ec__DisplayClass7_2.valus.RegisterDate = now;
						_003C_003Ec__DisplayClass7_2.valus.RegisterDatePersian = text2;
						_003C_003Ec__DisplayClass7_2.valus.Year1 = num3;
						_003C_003Ec__DisplayClass7_2.valus.Month1 = num2;
						_003C_003Ec__DisplayClass7_2.valus.AppType = appType;
						_dbTbl.Entry(_003C_003Ec__DisplayClass7_2.valus).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						if (_003C_003Ec__DisplayClass7_2.valus.FormFieldValueId <= 0)
						{
							continue;
						}
						using (List<Languages>.Enumerator enumerator4 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
						{
							while (enumerator4.MoveNext())
							{
								_003C_003Ec__DisplayClass7_8 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass7_8();
								CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass7_2;
								CS_0024_003C_003E8__locals4.lang = enumerator4.Current;
								DbSet<CrmDyFormFieldValues_Lang> crmDyFormFieldValues_Lang = _dbTbl.CrmDyFormFieldValues_Lang;
								val = Expression.Parameter(typeof(CrmDyFormFieldValues_Lang), "c");
								CrmDyFormFieldValues_Lang crmDyFormFieldValues_Lang2 = Queryable.FirstOrDefault<CrmDyFormFieldValues_Lang>((IQueryable<CrmDyFormFieldValues_Lang>)crmDyFormFieldValues_Lang, Expression.Lambda<Func<CrmDyFormFieldValues_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals4, typeof(_003C_003Ec__DisplayClass7_8)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals4, typeof(_003C_003Ec__DisplayClass7_8)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmDyFormFieldValues_Lang2 != null)
								{
									crmDyFormFieldValues_Lang2.Value = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmDyFormFieldValues_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmDyFormFieldValues_Lang2 = new CrmDyFormFieldValues_Lang();
								crmDyFormFieldValues_Lang2.LanguageID = CS_0024_003C_003E8__locals4.lang.LanguageID;
								crmDyFormFieldValues_Lang2.FieldValueId = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.valus.FormFieldValueId;
								crmDyFormFieldValues_Lang2.Value = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
								_dbTbl.CrmDyFormFieldValues_Lang.Add(crmDyFormFieldValues_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						continue;
					}
					CrmDyFormFieldValues crmDyFormFieldValues2 = new CrmDyFormFieldValues
					{
						FormId = formId,
						FieldId = fieldId,
						Value = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						IsDeleted = false,
						CompanyId = CS_0024_003C_003E8__locals0.model.CompanyId,
						CompanyPersonId = CS_0024_003C_003E8__locals0.model.CompanyPersonId,
						ProjectId = CS_0024_003C_003E8__locals0.model.ProjectId,
						ConversationId = CS_0024_003C_003E8__locals0.model.ConversationId,
						MasterObjectId = CS_0024_003C_003E8__locals0.model.MasterObjectId,
						DetailObjectId = CS_0024_003C_003E8__locals0.model.DetailObjectId,
						SubDetailObjectId = CS_0024_003C_003E8__locals0.model.SubDetailObjectId,
						MasterValueId = _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId,
						FirstRegisterUserId = userId,
						FirstRegisterDate = now,
						FirstRegisterDatePersian = text2,
						UserId = userId,
						RegisterDate = now,
						RegisterDatePersian = text2,
						Year1 = num3,
						Month1 = num2,
						GUId = System.Guid.NewGuid(),
						AppType = appType,
						LanguageID = defLangID,
						CId = _003C_003Ec__DisplayClass7_.masterVal.CId
					};
					_dbTbl.CrmDyFormFieldValues.Add(crmDyFormFieldValues2);
					_dbTbl.SaveChanges();
					if (crmDyFormFieldValues2.FormFieldValueId > 0 && fld.FieldTypeId.GetValueOrDefault() != 2 && fld.FieldTypeId.GetValueOrDefault() != 4 && fld.FieldTypeId.GetValueOrDefault() != 5)
					{
						foreach (Languages lang2 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
						{
							CrmDyFormFieldValues_Lang crmDyFormFieldValues_Lang3 = new CrmDyFormFieldValues_Lang();
							crmDyFormFieldValues_Lang3.LanguageID = lang2.LanguageID;
							crmDyFormFieldValues_Lang3.FieldValueId = crmDyFormFieldValues2.FormFieldValueId;
							crmDyFormFieldValues_Lang3.Value = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
							_dbTbl.CrmDyFormFieldValues_Lang.Add(crmDyFormFieldValues_Lang3);
							_dbTbl.SaveChanges();
						}
					}
					else
					{
						if (crmDyFormFieldValues2.FormFieldValueId <= 0)
						{
							continue;
						}
						foreach (Languages item9 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
						{
							CrmDyFormFieldValues_Lang crmDyFormFieldValues_Lang4 = new CrmDyFormFieldValues_Lang();
							crmDyFormFieldValues_Lang4.LanguageID = item9.LanguageID;
							crmDyFormFieldValues_Lang4.FieldValueId = crmDyFormFieldValues2.FormFieldValueId;
							crmDyFormFieldValues_Lang4.Value = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_dbTbl.CrmDyFormFieldValues_Lang.Add(crmDyFormFieldValues_Lang4);
							_dbTbl.SaveChanges();
						}
					}
					continue;
				}
				CrmDyFormFieldValues crmDyFormFieldValues3 = new CrmDyFormFieldValues
				{
					FormId = formId,
					FieldId = fieldId,
					Value = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					IsDeleted = false,
					CompanyId = CS_0024_003C_003E8__locals0.model.CompanyId,
					CompanyPersonId = CS_0024_003C_003E8__locals0.model.CompanyPersonId,
					ProjectId = CS_0024_003C_003E8__locals0.model.ProjectId,
					ConversationId = CS_0024_003C_003E8__locals0.model.ConversationId,
					MasterObjectId = CS_0024_003C_003E8__locals0.model.MasterObjectId,
					DetailObjectId = CS_0024_003C_003E8__locals0.model.DetailObjectId,
					SubDetailObjectId = CS_0024_003C_003E8__locals0.model.SubDetailObjectId,
					MasterValueId = _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId,
					FirstRegisterUserId = userId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = text2,
					UserId = userId,
					RegisterDate = now,
					RegisterDatePersian = text2,
					Year1 = num3,
					Month1 = num2,
					GUId = System.Guid.NewGuid(),
					AppType = appType,
					LanguageID = defLangID,
					CId = _003C_003Ec__DisplayClass7_.masterVal.CId
				};
				_dbTbl.CrmDyFormFieldValues.Add(crmDyFormFieldValues3);
				_dbTbl.SaveChanges();
				if (crmDyFormFieldValues3.FormFieldValueId > 0 && fld.FieldTypeId.GetValueOrDefault() != 2 && fld.FieldTypeId.GetValueOrDefault() != 4 && fld.FieldTypeId.GetValueOrDefault() != 5)
				{
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmDyFormFieldValues_Lang crmDyFormFieldValues_Lang5 = new CrmDyFormFieldValues_Lang();
						crmDyFormFieldValues_Lang5.LanguageID = lang.LanguageID;
						crmDyFormFieldValues_Lang5.FieldValueId = crmDyFormFieldValues3.FormFieldValueId;
						crmDyFormFieldValues_Lang5.Value = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmDyFormFieldValues_Lang.Add(crmDyFormFieldValues_Lang5);
						_dbTbl.SaveChanges();
					}
				}
				else
				{
					if (crmDyFormFieldValues3.FormFieldValueId <= 0)
					{
						continue;
					}
					foreach (Languages item10 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmDyFormFieldValues_Lang crmDyFormFieldValues_Lang6 = new CrmDyFormFieldValues_Lang();
						crmDyFormFieldValues_Lang6.LanguageID = item10.LanguageID;
						crmDyFormFieldValues_Lang6.FieldValueId = crmDyFormFieldValues3.FormFieldValueId;
						crmDyFormFieldValues_Lang6.Value = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_dbTbl.CrmDyFormFieldValues_Lang.Add(crmDyFormFieldValues_Lang6);
						_dbTbl.SaveChanges();
					}
				}
			}
			if (_003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId > 0 && formFileSending != null)
			{
				int num7 = 1;
				int num8 = 0;
				HttpPostedFileBase[] array = formFileSending;
				int num4 = 0;
				while (num4 < array.Length)
				{
					HttpPostedFileBase val3 = array[num4];
					string fileName = Path.GetFileName(val3.FileName);
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					string text17 = "";
					text17 = (CS_0024_003C_003E8__locals0.model.CompanyId.HasValue ? CS_0024_003C_003E8__locals0.model.CompanyId.ToString() : (Configuration.DyDirectoryPath + CS_0024_003C_003E8__locals0.model.FormId));
					string folderName = (CS_0024_003C_003E8__locals0.model.CompanyId.HasValue ? CS_0024_003C_003E8__locals0.model.CompanyId.ToString() : CS_0024_003C_003E8__locals0.model.FormId.ToString());
					num8 += 5;
					num7++;
					string docTime = now.ToString("HH:mm:ss");
					CrmFilesDirectory crmFilesDirectory = new CrmFilesDirectory
					{
						FirstRegisterUserId = userId,
						FirstRegisterDate = now,
						FirstRegisterDatePersian = text2,
						LanguageID = defLangID,
						UserId = userId,
						Year1 = num3,
						Month1 = num2,
						GUId = System.Guid.NewGuid(),
						RegisterDate = now,
						RegisterDatePersian = text2,
						DocDateTime = now,
						DocDate = text2,
						DocTime = docTime,
						DocDay = PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(),
						AppType = appType,
						DetailId = CS_0024_003C_003E8__locals0.model.CompanyPersonId,
						FileDirectoryTypeId = -60,
						TypeOprObjectId = _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId,
						TypeOprObjectIdI = _003C_003Ec__DisplayClass7_.masterVal.FormId,
						FolderName = folderName,
						SubDetailId = CS_0024_003C_003E8__locals0.model.ProjectId,
						MasterId = CS_0024_003C_003E8__locals0.model.CompanyId,
						Title = fileName,
						OrderView = num8,
						FileCId = fileCId
					};
					_dbTbl.CrmFilesDirectory.Add(crmFilesDirectory);
					_dbTbl.SaveChanges();
					string[] array10 = fileName.Split(new char[1] { '.' });
					string text18 = Configuration.MainDirectoryPath + text17 + "/";
					string text19 = text18 + (text18.EndsWith("/") ? "" : "/");
					string text20 = text19.Split(new char[1] { '/' })[^2];
					string text21 = text19.Replace(text20 + "/", "");
					bool flag11 = false;
					if (!CS_0024_003C_003E8__locals0.model.CompanyId.HasValue)
					{
						flag11 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.MainDirectoryPath, Configuration.DyDirectoryPath, Configuration.UsePassiveFtp);
						if (!flag11)
						{
							flag11 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.MainDirectoryPath, Configuration.DyDirectoryPath, Configuration.UsePassiveFtp);
						}
					}
					else
					{
						flag11 = true;
					}
					bool flag12 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text21, text20, Configuration.UsePassiveFtp);
					if (!flag12)
					{
						flag12 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text21, text20, Configuration.UsePassiveFtp);
					}
					if (flag12 && flag11)
					{
						string text22 = "";
						text22 = crmFilesDirectory.TypeOprObjectId + "-" + crmFilesDirectory.FileDirectoryID + "." + array10[^1];
						string text23 = "";
						if (facadeFTP.Upload(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text19 + text22, val3, Configuration.UsePassiveFtp))
						{
							text18 = Configuration.PathFtp + text19 + text22;
							text23 = text22;
							text18 = text18.Trim().Replace(Configuration.PathFtp, "");
							crmFilesDirectory.FilePath = text18;
							crmFilesDirectory.FileName = text23;
							crmFilesDirectory.UserId = UserLogin.CurrentUser.UserId;
							crmFilesDirectory.Year1 = num3;
							crmFilesDirectory.Month1 = num2;
							crmFilesDirectory.RegisterDate = now;
							crmFilesDirectory.RegisterDatePersian = text2;
							_dbTbl.Entry(crmFilesDirectory).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							foreach (Languages item11 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
							{
								CrmFilesDirectory_Lang entity = new CrmFilesDirectory_Lang
								{
									LanguageID = item11.LanguageID,
									FileDirectoryID = crmFilesDirectory.FileDirectoryID,
									Title = fileName
								};
								_dbTbl.CrmFilesDirectory_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
							num4++;
							continue;
						}
						Exception e2 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text21 + " ,directoryName: " + text20);
						ErrorSignal.FromCurrentContext().Raise(e2);
						base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
						try
						{
							_dbTbl.CrmFilesDirectory.Remove(crmFilesDirectory);
							_dbTbl.SaveChanges();
						}
						catch (Exception e3)
						{
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.msgErrorCreateFolderInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text21 + " ,directoryName: " + text20);
						ErrorSignal.FromCurrentContext().Raise(e4);
						base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
						try
						{
							_dbTbl.CrmFilesDirectory.Remove(crmFilesDirectory);
							_dbTbl.SaveChanges();
						}
						catch (Exception e5)
						{
							ErrorSignal.FromCurrentContext().Raise(e5);
						}
					}
					goto end_IL_006b;
				}
			}
			if (list6 != null && list6.Count > 0)
			{
				base.TempData["Successfull"] = Messages.frmFormBaseEditSuccessFulMessage;
			}
			else
			{
				base.TempData["Successfull"] = Messages.frmFormBaseInsertSuccessFulMessage;
			}
			CS_0024_003C_003E8__locals0.model.MasterValueId = _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId;
			bool flag13;
			int num9;
			string mainFormReferUserIs;
			if (flag13 || num9 > 0)
			{
				CRMspDySelectFormWorkflowStepWithId_Result cRMspDySelectFormWorkflowStepWithId_Result3 = new CRMspDySelectFormWorkflowStepWithId_Result();
				cRMspDySelectFormWorkflowStepWithId_Result3 = ((num9 <= 0) ? Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepWithId_Result>((IEnumerable<CRMspDySelectFormWorkflowStepWithId_Result>)_db.CRMspDySelectFormWorkflowStepWithId(CS_0024_003C_003E8__locals0.model.WorkflowStepId, currLangID, defLangID, num)) : Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepWithId_Result>((IEnumerable<CRMspDySelectFormWorkflowStepWithId_Result>)_db.CRMspDySelectFormWorkflowStepWithId(num9, currLangID, defLangID, num)));
				if (cRMspDySelectFormWorkflowStepWithId_Result3 != null)
				{
					string referUserIds = cRMspDySelectFormWorkflowStepWithId_Result3.ReferUserIds ?? "";
					string multiReferUserIds = cRMspDySelectFormWorkflowStepWithId_Result3.MultiReferUserIds ?? "";
					string checkerUserIds = cRMspDySelectFormWorkflowStepWithId_Result3.CheckerUserIds ?? "";
					JsonResult jsonResult = SendIntMsg(CS_0024_003C_003E8__locals0.model.FormId, _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId, result, cRMspDySelectFormWorkflowStepWithId_Result3.FormWorkflowStepId, referUserIds, multiReferUserIds, checkerUserIds, CS_0024_003C_003E8__locals0.model.SendIntMsgForMultiReferUsers, CS_0024_003C_003E8__locals0.model.SendIntMsgForCheckerUsers, CS_0024_003C_003E8__locals0.model.MasterValueDetailId.GetValueOrDefault(), num9, mainFormReferUserIs);
					if (jsonResult != null)
					{
						if (jsonResult.Data != null)
						{
							string text24 = new JavaScriptSerializer().Serialize(jsonResult.Data);
							CommonResultViewModel<string> commonResultViewModel = new JavaScriptSerializer().Deserialize<CommonResultViewModel<string>>(text24);
							if (commonResultViewModel.Status != CommonResultStatusViewModel.Success)
							{
								string message = commonResultViewModel.Message;
								base.ModelState.AddModelError("error", message);
								base.ViewBag.Error = message;
							}
						}
						else
						{
							string msgErrorErrorSendingMessages = Messages.msgErrorErrorSendingMessages;
							base.ModelState.AddModelError("error", msgErrorErrorSendingMessages);
							base.ViewBag.Error = msgErrorErrorSendingMessages;
						}
					}
					else
					{
						string msgErrorErrorSendingMessages2 = Messages.msgErrorErrorSendingMessages;
						base.ModelState.AddModelError("error", msgErrorErrorSendingMessages2);
						base.ViewBag.Error = msgErrorErrorSendingMessages2;
					}
				}
			}
			goto end_IL_006b;
			IL_1805:
			flag13 = false;
			num9 = 0;
			mainFormReferUserIs = "";
			if (_003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId <= 0 || result <= 0)
			{
				goto IL_1e42;
			}
			bool flag14 = false;
			CrmDyFormFieldMasterValueDetails crmDyFormFieldMasterValueDetails = new CrmDyFormFieldMasterValueDetails();
			DbSet<CrmDyFormFieldMasterValueDetails> crmDyFormFieldMasterValueDetails2 = _dbTbl.CrmDyFormFieldMasterValueDetails;
			val = Expression.Parameter(typeof(CrmDyFormFieldMasterValueDetails), "m");
			crmDyFormFieldMasterValueDetails = Queryable.FirstOrDefault<CrmDyFormFieldMasterValueDetails>((IQueryable<CrmDyFormFieldMasterValueDetails>)crmDyFormFieldMasterValueDetails2, Expression.Lambda<Func<CrmDyFormFieldMasterValueDetails, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmDyFormFieldMasterValueDetails != null)
			{
				if (!CS_0024_003C_003E8__locals0.model.WdSubFormId.HasValue && !CS_0024_003C_003E8__locals0.model.WorkflowStepId.HasValue)
				{
					crmDyFormFieldMasterValueDetails.UserId = userId;
					crmDyFormFieldMasterValueDetails.RegisterDate = now;
					crmDyFormFieldMasterValueDetails.RegisterDatePersian = text2;
					crmDyFormFieldMasterValueDetails.Year1 = num3;
					crmDyFormFieldMasterValueDetails.Month1 = num2;
					crmDyFormFieldMasterValueDetails.AppType = appType;
					_dbTbl.Entry(crmDyFormFieldMasterValueDetails).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
			}
			else
			{
				flag14 = true;
				crmDyFormFieldMasterValueDetails = new CrmDyFormFieldMasterValueDetails
				{
					FormId = _003C_003Ec__DisplayClass7_.masterVal.FormId,
					MasterValueId = _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId,
					FirstRegisterUserId = userId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = text2,
					UserId = userId,
					RegisterDate = now,
					RegisterDatePersian = text2,
					Year1 = num3,
					Month1 = num2,
					GUId = System.Guid.NewGuid(),
					AppType = appType,
					LanguageID = defLangID,
					CId = _003C_003Ec__DisplayClass7_.masterVal.CId
				};
				_dbTbl.CrmDyFormFieldMasterValueDetails.Add(crmDyFormFieldMasterValueDetails);
				_dbTbl.SaveChanges();
				CRMspDySelectFormWorkflowStepsForMasterValue_Result cRMspDySelectFormWorkflowStepsForMasterValue_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<CRMspDySelectFormWorkflowStepsForMasterValue_Result>)_db.CRMspDySelectFormWorkflowStepsForMasterValue(result, _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId, currLangID, defLangID, num));
				if (cRMspDySelectFormWorkflowStepsForMasterValue_Result != null)
				{
					num9 = cRMspDySelectFormWorkflowStepsForMasterValue_Result.FormWorkflowStepId;
				}
				mainFormReferUserIs = cRMspDySelectForms_Result.ReferUserIds ?? "";
			}
			if (!(CS_0024_003C_003E8__locals0.model.WdSubFormId > 0) || !(CS_0024_003C_003E8__locals0.model.WorkflowStepId > 0))
			{
				goto IL_1e42;
			}
			CRMspDySelectFormWorkflowStepBFCurr_Result cRMspDySelectFormWorkflowStepBFCurr_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepBFCurr_Result>((IEnumerable<CRMspDySelectFormWorkflowStepBFCurr_Result>)_db.CRMspDySelectFormWorkflowStepBFCurr(result, CS_0024_003C_003E8__locals0.model.WorkflowStepId, _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId, CS_0024_003C_003E8__locals0.model.WdSubFormId, currLangID, defLangID));
			if (cRMspDySelectFormWorkflowStepBFCurr_Result == null)
			{
				CrmDyFormFieldMasterValueDetails crmDyFormFieldMasterValueDetails3 = new CrmDyFormFieldMasterValueDetails();
				DbSet<CrmDyFormFieldMasterValueDetails> crmDyFormFieldMasterValueDetails4 = _dbTbl.CrmDyFormFieldMasterValueDetails;
				val = Expression.Parameter(typeof(CrmDyFormFieldMasterValueDetails), "m");
				crmDyFormFieldMasterValueDetails3 = Queryable.FirstOrDefault<CrmDyFormFieldMasterValueDetails>((IQueryable<CrmDyFormFieldMasterValueDetails>)crmDyFormFieldMasterValueDetails4, Expression.Lambda<Func<CrmDyFormFieldMasterValueDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmDyFormFieldMasterValueDetails3 != null)
				{
					crmDyFormFieldMasterValueDetails3.UserId = userId;
					crmDyFormFieldMasterValueDetails3.RegisterDate = now;
					crmDyFormFieldMasterValueDetails3.RegisterDatePersian = text2;
					crmDyFormFieldMasterValueDetails3.Year1 = num3;
					crmDyFormFieldMasterValueDetails3.Month1 = num2;
					crmDyFormFieldMasterValueDetails3.AppType = appType;
					_dbTbl.Entry(crmDyFormFieldMasterValueDetails3).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				else
				{
					flag13 = true;
					crmDyFormFieldMasterValueDetails3 = new CrmDyFormFieldMasterValueDetails
					{
						FormId = CS_0024_003C_003E8__locals0.model.WdSubFormId.GetValueOrDefault(),
						MasterValueId = _003C_003Ec__DisplayClass7_.masterVal.FormFieldMasterValueId,
						FirstRegisterUserId = userId,
						FirstRegisterDate = now,
						FirstRegisterDatePersian = text2,
						UserId = userId,
						RegisterDate = now,
						RegisterDatePersian = text2,
						Year1 = num3,
						Month1 = num2,
						GUId = System.Guid.NewGuid(),
						AppType = appType,
						LanguageID = defLangID,
						CId = _003C_003Ec__DisplayClass7_.masterVal.CId
					};
					_dbTbl.CrmDyFormFieldMasterValueDetails.Add(crmDyFormFieldMasterValueDetails3);
					_dbTbl.SaveChanges();
					CS_0024_003C_003E8__locals0.model.MasterValueDetailId = crmDyFormFieldMasterValueDetails3.FormFieldMasterValueDetailId;
				}
				goto IL_1e42;
			}
			string text25 = string.Format(Messages.msgErrorCheckFormWorkflowDetailBFCurr, cRMspDySelectFormWorkflowStepBFCurr_Result.WorkflowStepTitle ?? "") + "<br>";
			base.ModelState.AddModelError("error", text25);
			base.ViewBag.Error = text25;
			if (flag14)
			{
				try
				{
					_dbTbl.CrmDyFormFieldMasterValueDetails.Remove(crmDyFormFieldMasterValueDetails);
					_dbTbl.SaveChanges();
					_dbTbl.CrmDyFormFieldMasterValues.Remove(_003C_003Ec__DisplayClass7_.masterVal);
					_dbTbl.SaveChanges();
				}
				catch (Exception e6)
				{
					ErrorSignal.FromCurrentContext().Raise(e6);
				}
			}
			end_IL_006b:;
		}
		catch (Exception e7)
		{
			base.ModelState.AddModelError("error", Messages.msgErrorRunFunction);
			ErrorSignal.FromCurrentContext().Raise(e7);
		}
		base.ViewBag.FormName = text;
		base.ViewBag.IsFreeForm = flag;
		base.ViewBag.IsWorkflow = flag2;
		if (flag2)
		{
			CS_0024_003C_003E8__locals0.model.SendIntMsgForMultiReferUsers = true;
			CS_0024_003C_003E8__locals0.model.SendIntMsgForCheckerUsers = true;
		}
		else
		{
			CS_0024_003C_003E8__locals0.model.SendIntMsgForMultiReferUsers = false;
			CS_0024_003C_003E8__locals0.model.SendIntMsgForCheckerUsers = false;
		}
		CS_0024_003C_003E8__locals0.model.CanSave = false;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[HttpPost]
	[AllowAnonymous]
	[ValidateAntiForgeryToken]
	[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
	[DynamicAuthorize(ControllerName = "frmDyForm", ActionName = "actPost,actPostSubForm")]
	public JsonResult InsertEditDyForm(CrmDyFormFieldValuesLanguageViewModel model, HttpPostedFileBase[] formFileSending)
	{
		//IL_29f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_311c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3689: Unknown result type (might be due to invalid IL or missing references)
		//IL_41d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_41e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1769: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b8: Unknown result type (might be due to invalid IL or missing references)
		string data = "";
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		try
		{
			if (model != null)
			{
				if (!string.IsNullOrWhiteSpace(model.ValueDetails))
				{
					model.ValueDetails = model.ValueDetails.Replace("$*", "/");
				}
				if (!string.IsNullOrWhiteSpace(model.ValueDetails_Lang))
				{
					model.ValueDetails_Lang = model.ValueDetails_Lang.Replace("$*", "/");
				}
			}
			int result = 0;
			bool flag = false;
			bool flag2 = false;
			DateTime now = DateTime.Now;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			List<CRMspDySelectFormFieldsByParentFormId_Result> list = new List<CRMspDySelectFormFieldsByParentFormId_Result>();
			List<CRMspDySelectFormAndSubForms_Result> list2 = new List<CRMspDySelectFormAndSubForms_Result>();
			string text3 = "";
			int? num = null;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserLastCId;
			}
			int? centerId = null;
			if (num.GetValueOrDefault() != 0)
			{
				centerId = num;
			}
			if (model.MasterValueId > 0 || VersionBuyer.DyForm)
			{
				goto IL_029f;
			}
			DbSet<CrmDyFormFieldMasterValues> crmDyFormFieldMasterValues = _dbTbl.CrmDyFormFieldMasterValues;
			ParameterExpression val2 = Expression.Parameter(typeof(CrmDyFormFieldMasterValues), "c");
			if (!Queryable.Any<CrmDyFormFieldMasterValues>((IQueryable<CrmDyFormFieldMasterValues>)crmDyFormFieldMasterValues, Expression.Lambda<Func<CrmDyFormFieldMasterValues, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val2, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val2 })))
			{
				goto IL_029f;
			}
			base.ViewBag.Error = "BV|" + Messages.VersionBuy;
			text = "BV|" + Messages.VersionBuy;
			status = CommonResultStatusViewModel.Fail;
			goto end_IL_001b;
			IL_112c:
			List<CRMspDySelectFormFieldValuesByMasterValueId_Result> list3 = new List<CRMspDySelectFormFieldValuesByMasterValueId_Result>();
			int result2;
			if (result2 > 0)
			{
				list3 = Enumerable.ToList<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)_dbI.CRMspDySelectFormFieldValuesByMasterValueId(result2, currLangID, defLangID));
			}
			if (list == null || !Enumerable.Any<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list))
			{
				goto IL_1c07;
			}
			string text4 = "";
			int num2 = 0;
			List<CRMspDySelectFormFieldsByParentFormId_Result> list4 = new List<CRMspDySelectFormFieldsByParentFormId_Result>();
			if (!(model.WdSubFormId > 0) || !(model.WorkflowStepId > 0))
			{
				list4 = ((result <= 0) ? Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.IsRequired.GetValueOrDefault()))) : Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormId == model.FormId && m.IsRequired.GetValueOrDefault()))));
			}
			else
			{
				CRMspDySelectFormWorkflowStepBFCurr_Result wdetail = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepBFCurr_Result>((IEnumerable<CRMspDySelectFormWorkflowStepBFCurr_Result>)_db.CRMspDySelectFormWorkflowStepBFCurr(result, model.WorkflowStepId, result2, model.WdSubFormId, currLangID, defLangID));
				list4 = ((wdetail == null) ? Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormId == model.WdSubFormId && m.IsRequired.GetValueOrDefault()))) : Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormId == wdetail.SubFormId && m.IsRequired.GetValueOrDefault()))));
			}
			if (list4 == null || !Enumerable.Any<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list4))
			{
				goto IL_1c07;
			}
			List<IdKeyValueItemViewModel> list5;
			List<IdKeyValueItemViewModel> list6;
			bool flag5;
			foreach (IdKeyValueItemViewModel obj2 in list5)
			{
				string ids2 = obj2.Id ?? "";
				int formId2 = 0;
				int fieldId2 = 0;
				long fieldRepeatId2 = 0L;
				if (ids2 != "")
				{
					ids2 = ids2.Replace("_Rep", "");
					string[] array = ids2.Split(new char[1] { '_' });
					if (array != null)
					{
						formId2 = int.Parse(array[0]);
						fieldId2 = int.Parse(array[1]);
						if (array.Length > 2)
						{
							fieldRepeatId2 = long.Parse(array[2]);
						}
					}
				}
				CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list4, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == fieldId2));
				if (cRMspDySelectFormFieldsByParentFormId_Result == null)
				{
					continue;
				}
				if (result == 0)
				{
					CRMspDySelectFormAndSubForms_Result cRMspDySelectFormAndSubForms_Result = Enumerable.FirstOrDefault<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list2, (Func<CRMspDySelectFormAndSubForms_Result, bool>)((CRMspDySelectFormAndSubForms_Result m) => m.FormId == formId2));
					if (cRMspDySelectFormAndSubForms_Result != null)
					{
						bool flag3 = true;
						bool flag4 = false;
						if (cRMspDySelectFormAndSubForms_Result.EnableForRollId.HasValue)
						{
							flag3 = cRMspDySelectFormAndSubForms_Result.EnableForRollId == UserLogin.CurrentUser.RollId || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser);
						}
						else if (!string.IsNullOrEmpty(cRMspDySelectFormAndSubForms_Result.EnableForUsersId))
						{
							string[] array2 = cRMspDySelectFormAndSubForms_Result.EnableForUsersId.Split(new char[1] { '|' });
							if (Enumerable.Any<string>((IEnumerable<string>)array2))
							{
								foreach (string item3 in Enumerable.Where<string>((IEnumerable<string>)array2, (Func<string, bool>)((string usr) => !string.IsNullOrEmpty(usr))))
								{
									if (!flag4)
									{
										if (item3 == UserLogin.CurrentUser.UserId.ToString() || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
										{
											flag3 = true;
											flag4 = true;
										}
										else
										{
											flag3 = false;
										}
									}
								}
							}
						}
						if (!flag3)
						{
							continue;
						}
					}
				}
				CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result2 = Enumerable.FirstOrDefault<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == fieldId2));
				if (cRMspDySelectFormFieldsByParentFormId_Result2 != null && !string.IsNullOrWhiteSpace(obj2.Value) && cRMspDySelectFormFieldsByParentFormId_Result2.FieldTypeId.GetValueOrDefault() == 4)
				{
					obj2.Value = obj2.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					string formatetdDate = PersianDate.GetFormatetdDate(obj2.Value.Replace("/", ""));
					if (currLangID == 1065)
					{
						DateTime dateTime = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						obj2.Value = dateTime.ToString("yyyyMMdd");
					}
					else if (currLangID == 1025)
					{
						DateTime dateTime2 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						obj2.Value = dateTime2.ToString("yyyyMMdd", new PersianCulture());
					}
					else
					{
						DateTime dateTime3 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						obj2.Value = dateTime3.ToString("yyyyMMdd", new PersianCulture());
					}
				}
				IdKeyValueItemViewModel idKeyValueItemViewModel = Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list6, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == ids2));
				List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
				if (idKeyValueItemViewModel != null && (cRMspDySelectFormFieldsByParentFormId_Result2.FieldTypeId.GetValueOrDefault() == 1 || cRMspDySelectFormFieldsByParentFormId_Result2.FieldTypeId.GetValueOrDefault() == 3))
				{
					if (!string.IsNullOrWhiteSpace(idKeyValueItemViewModel.Value))
					{
						list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(idKeyValueItemViewModel.Value);
					}
				}
				else
				{
					list7 = new List<CommonMultiLanguageViewModel>();
					foreach (Languages lang4 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != currLangID))))
					{
						string value3 = "";
						if (cRMspDySelectFormFieldsByParentFormId_Result2 == null)
						{
							continue;
						}
						switch (cRMspDySelectFormFieldsByParentFormId_Result2.FieldTypeId)
						{
						case 2:
						case 4:
						case 5:
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
							value3 = obj2.Value;
							break;
						case 6:
						case 7:
						case 8:
							if (list3 != null && Enumerable.Any<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list3))
							{
								CRMspDySelectFormFieldValuesByMasterValueId_Result cRMspDySelectFormFieldValuesByMasterValueId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list3, (Func<CRMspDySelectFormFieldValuesByMasterValueId_Result, bool>)((CRMspDySelectFormFieldValuesByMasterValueId_Result m) => m.FormId == formId2 && m.FieldId == fieldId2 && m.FieldRepeatId.GetValueOrDefault() == fieldRepeatId2));
								if (cRMspDySelectFormFieldValuesByMasterValueId_Result == null)
								{
									break;
								}
								List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
								if (string.IsNullOrWhiteSpace(cRMspDySelectFormFieldValuesByMasterValueId_Result.Value_Lang))
								{
									break;
								}
								list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(cRMspDySelectFormFieldValuesByMasterValueId_Result.Value_Lang);
								if (list8 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8))
								{
									CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == lang4.LanguageID));
									if (commonMultiLanguageViewModel != null)
									{
										value3 = ((commonMultiLanguageViewModel.Value == null) ? null : (commonMultiLanguageViewModel.Value ?? ""));
									}
								}
							}
							else
							{
								if (!flag5 || list4 == null || !string.IsNullOrWhiteSpace(value3))
								{
									break;
								}
								CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result3 = Enumerable.FirstOrDefault<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list4, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result x) => x.FormFieldId == int.Parse(obj2.Id.Split(new char[1] { '_' })[1])));
								if (cRMspDySelectFormFieldsByParentFormId_Result3 == null || string.IsNullOrWhiteSpace(cRMspDySelectFormFieldsByParentFormId_Result3.MultiItems))
								{
									break;
								}
								string[] array3 = cRMspDySelectFormFieldsByParentFormId_Result3.MultiItems.Split(new char[1] { '|' });
								for (int i = 0; i < array3.Length; i++)
								{
									if (!string.IsNullOrWhiteSpace(array3[i]) && array3[i].Split(new char[1] { ':' })[1] == obj2.Value)
									{
										value3 = obj2.Value ?? "";
									}
								}
							}
							break;
						}
						list7.Add(new CommonMultiLanguageViewModel
						{
							Value = value3,
							LanguageId = lang4.LanguageID
						});
					}
				}
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = obj2.Value,
					LanguageId = currLangID
				});
				string text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : null);
				if (string.IsNullOrEmpty(text5))
				{
					text4 = text4 + string.Format(Messages.ErrorEmpty, cRMspDySelectFormFieldsByParentFormId_Result.FieldTitle ?? "") + "<br/>";
					num2++;
				}
				else if (!checkMultiLanguage(text5, list7))
				{
					text4 = text4 + text4 + string.Format(Messages.CheckFieldInLang, cRMspDySelectFormFieldsByParentFormId_Result.FieldTitle ?? "") + "<br>";
					num2++;
				}
			}
			if (num2 <= 0)
			{
				goto IL_1c07;
			}
			base.ModelState.AddModelError("error", text4);
			base.ViewBag.Error = text4;
			text = text4;
			status = CommonResultStatusViewModel.Fail;
			if (flag5)
			{
				try
				{
					Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDyDeleteFormFieldMasterValue(result2));
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			goto end_IL_001b;
			IL_38fb:
			if (result2 > 0 && formFileSending != null)
			{
				int num3 = 1;
				int num4 = 0;
				HttpPostedFileBase[] array4 = formFileSending;
				foreach (HttpPostedFileBase val3 in array4)
				{
					string fileName = Path.GetFileName(val3.FileName);
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					string text6 = "";
					text6 = (model.CompanyId.HasValue ? model.CompanyId.ToString() : (Configuration.DyDirectoryPath + model.FormId));
					string folderName = (model.CompanyId.HasValue ? model.CompanyId.ToString() : model.FormId.ToString());
					num4 += 5;
					num3++;
					string title_Lang = "";
					List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
					foreach (Languages item4 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						list9.Add(new CommonMultiLanguageViewModel
						{
							Value = fileName,
							LanguageId = item4.LanguageID
						});
					}
					if (list9 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9))
					{
						title_Lang = JsonConvert.SerializeObject(list9);
					}
					string docTime = now.ToString("HH:mm:ss");
					int result3 = 0;
					CRMspInsertFilesDirectory_Result cRMspInsertFilesDirectory_Result = Enumerable.FirstOrDefault<CRMspInsertFilesDirectory_Result>((IEnumerable<CRMspInsertFilesDirectory_Result>)_dbI.CRMspInsertFilesDirectory(0, -60, model.CompanyId, model.CompanyPersonId, model.ProjectId, fileName, title_Lang, folderName, "", "", "", userId, value2, value, now, text2, now, text2, PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime, result2, appType, defLangID, num4, model.FormId, null, "", null, null, centerId));
					if (cRMspInsertFilesDirectory_Result != null)
					{
						int.TryParse(cRMspInsertFilesDirectory_Result.FileId.ToString(), out result3);
					}
					if (result3 <= 0)
					{
						continue;
					}
					string[] array5 = fileName.Split(new char[1] { '.' });
					string text7 = Configuration.MainDirectoryPath + text6 + "/";
					string text8 = text7 + (text7.EndsWith("/") ? "" : "/");
					string text9 = text8.Split(new char[1] { '/' })[^2];
					string text10 = text8.Replace(text9 + "/", "");
					string pathFtp = Configuration.PathFtp;
					string userNameFtp = Configuration.UserNameFtp;
					string passwordFtp = Configuration.PasswordFtp;
					bool usePassiveFtp = Configuration.UsePassiveFtp;
					bool flag6 = false;
					if (!model.CompanyId.HasValue)
					{
						flag6 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.DyDirectoryPath, usePassiveFtp);
						if (!flag6)
						{
							flag6 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.DyDirectoryPath, usePassiveFtp);
						}
					}
					else
					{
						flag6 = true;
					}
					bool flag7 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, text9, usePassiveFtp);
					if (!flag7)
					{
						flag7 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, text9, usePassiveFtp);
					}
					if (flag7 && flag6)
					{
						string text11 = "";
						int num5 = result2;
						text11 = num5 + "-" + result3 + "." + array5[^1];
						string text12 = "";
						if (facadeFTP.Upload(pathFtp, userNameFtp, passwordFtp, text8 + text11, val3, usePassiveFtp))
						{
							text7 = pathFtp + text8 + text11;
							text12 = text11;
							text7 = text7.Trim().Replace(pathFtp, "");
							Enumerable.FirstOrDefault<CRMspInsertFilesDirectory_Result>((IEnumerable<CRMspInsertFilesDirectory_Result>)_dbI.CRMspInsertFilesDirectory(result3, -60, model.CompanyId, model.CompanyPersonId, model.ProjectId, fileName, title_Lang, folderName, text12, text7, "", userId, value2, value, now, text2, now, text2, PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime, result2, appType, defLangID, num4, model.FormId, null, "", null, null, centerId));
							continue;
						}
						Exception e2 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text10 + " ,directoryName: " + text9);
						ErrorSignal.FromCurrentContext().Raise(e2);
						base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
						try
						{
							_db.CRMspDeleteCrmFilesDirectory(result3);
						}
						catch (Exception e3)
						{
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
						text = Messages.frmErrorInSendingFile;
						status = CommonResultStatusViewModel.Fail;
					}
					else
					{
						Exception e4 = new Exception(Messages.msgErrorCreateFolderInFtp + " -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text10 + " ,directoryName: " + text9);
						ErrorSignal.FromCurrentContext().Raise(e4);
						base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
						try
						{
							_db.CRMspDeleteCrmFilesDirectory(result3);
						}
						catch (Exception e5)
						{
							ErrorSignal.FromCurrentContext().Raise(e5);
						}
						text = Messages.frmErrorInSendingFile;
						status = CommonResultStatusViewModel.Fail;
					}
					goto end_IL_001b;
				}
			}
			if (list3 != null && list3.Count > 0 && result2 > 0)
			{
				base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				text = Messages.frmFormBaseEditSuccessFulMessage;
			}
			else
			{
				base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				text = Messages.frmFormBaseInsertSuccessFulMessage;
			}
			model.MasterValueId = result2;
			data = result2.ToString();
			status = CommonResultStatusViewModel.Success;
			bool flag8;
			int num6;
			string mainFormReferUserIs;
			if (flag8 || num6 > 0)
			{
				CRMspDySelectFormWorkflowStepWithId_Result cRMspDySelectFormWorkflowStepWithId_Result = new CRMspDySelectFormWorkflowStepWithId_Result();
				cRMspDySelectFormWorkflowStepWithId_Result = ((num6 <= 0) ? Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepWithId_Result>((IEnumerable<CRMspDySelectFormWorkflowStepWithId_Result>)_db.CRMspDySelectFormWorkflowStepWithId(model.WorkflowStepId, currLangID, defLangID, num)) : Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepWithId_Result>((IEnumerable<CRMspDySelectFormWorkflowStepWithId_Result>)_db.CRMspDySelectFormWorkflowStepWithId(num6, currLangID, defLangID, num)));
				if (cRMspDySelectFormWorkflowStepWithId_Result != null)
				{
					string referUserIds = cRMspDySelectFormWorkflowStepWithId_Result.ReferUserIds ?? "";
					string multiReferUserIds = cRMspDySelectFormWorkflowStepWithId_Result.MultiReferUserIds ?? "";
					string checkerUserIds = cRMspDySelectFormWorkflowStepWithId_Result.CheckerUserIds ?? "";
					JsonResult jsonResult = SendIntMsg(model.FormId, result2, result, cRMspDySelectFormWorkflowStepWithId_Result.FormWorkflowStepId, referUserIds, multiReferUserIds, checkerUserIds, model.SendIntMsgForMultiReferUsers, model.SendIntMsgForCheckerUsers, model.MasterValueDetailId.GetValueOrDefault(), num6, mainFormReferUserIs);
					if (jsonResult != null)
					{
						if (jsonResult.Data != null)
						{
							string text13 = new JavaScriptSerializer().Serialize(jsonResult.Data);
							CommonResultViewModel<string> commonResultViewModel = new JavaScriptSerializer().Deserialize<CommonResultViewModel<string>>(text13);
							if (commonResultViewModel.Status != CommonResultStatusViewModel.Success)
							{
								string message = commonResultViewModel.Message;
								base.ModelState.AddModelError("error", message);
								base.ViewBag.Error = message;
								text = message;
								status = CommonResultStatusViewModel.Fail;
							}
						}
						else
						{
							string msgErrorErrorSendingMessages = Messages.msgErrorErrorSendingMessages;
							base.ModelState.AddModelError("error", msgErrorErrorSendingMessages);
							base.ViewBag.Error = msgErrorErrorSendingMessages;
							text = msgErrorErrorSendingMessages;
							status = CommonResultStatusViewModel.Fail;
						}
					}
					else
					{
						string msgErrorErrorSendingMessages2 = Messages.msgErrorErrorSendingMessages;
						base.ModelState.AddModelError("error", msgErrorErrorSendingMessages2);
						base.ViewBag.Error = msgErrorErrorSendingMessages2;
						text = msgErrorErrorSendingMessages2;
						status = CommonResultStatusViewModel.Fail;
					}
				}
			}
			base.ViewBag.FormName = text3;
			base.ViewBag.IsFreeForm = flag2;
			base.ViewBag.IsWorkflow = flag;
			if (flag)
			{
				model.SendIntMsgForMultiReferUsers = true;
				model.SendIntMsgForCheckerUsers = true;
			}
			else
			{
				model.SendIntMsgForMultiReferUsers = false;
				model.SendIntMsgForCheckerUsers = false;
			}
			model.CanSave = false;
			goto end_IL_001b;
			IL_2025:
			List<CRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result> list10 = Enumerable.ToList<CRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>((IEnumerable<CRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>)_dbI.CRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs(3, userId, -65, null, model.FormId, null));
			List<FieldValueViewModel> list11 = new List<FieldValueViewModel>();
			List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
			foreach (IdKeyValueItemViewModel obj in list5)
			{
				string ids = obj.Id ?? "";
				int formId = 0;
				int fieldId = 0;
				long fieldRepeatId = 0L;
				if (ids != "")
				{
					ids = ids.Replace("_Rep", "");
					string[] array6 = ids.Split(new char[1] { '_' });
					if (array6 != null)
					{
						formId = int.Parse(array6[0]);
						fieldId = int.Parse(array6[1]);
						if (array6.Length > 2)
						{
							fieldRepeatId = long.Parse(array6[2]);
						}
					}
				}
				CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result4 = Enumerable.FirstOrDefault<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == fieldId));
				if (cRMspDySelectFormFieldsByParentFormId_Result4 != null && !string.IsNullOrEmpty(obj.Value) && cRMspDySelectFormFieldsByParentFormId_Result4.FieldTypeId.GetValueOrDefault() == 4)
				{
					obj.Value = obj.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					string formatetdDate2 = PersianDate.GetFormatetdDate(obj.Value.Replace("/", ""));
					if (currLangID == 1065)
					{
						DateTime dateTime4 = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						obj.Value = dateTime4.ToString("yyyyMMdd");
					}
					else if (currLangID == 1025)
					{
						DateTime dateTime5 = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						obj.Value = dateTime5.ToString("yyyyMMdd", new PersianCulture());
					}
					else
					{
						DateTime dateTime6 = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						obj.Value = dateTime6.ToString("yyyyMMdd", new PersianCulture());
					}
				}
				if (cRMspDySelectFormFieldsByParentFormId_Result4 != null && list10 != null && Enumerable.Any<CRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>((IEnumerable<CRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>)list10) && !string.IsNullOrWhiteSpace(obj.Value) && cRMspDySelectFormFieldsByParentFormId_Result4.FieldTypeId.GetValueOrDefault() == 12)
				{
					int fileDirectoryTemplateId = 0;
					int.TryParse(obj.Value, out fileDirectoryTemplateId);
					CRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result cRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result = Enumerable.FirstOrDefault<CRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>((IEnumerable<CRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>)list10, (Func<CRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result, bool>)((CRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result m) => m.FileDirectoryTemplateID == fileDirectoryTemplateId));
					if (cRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result != null)
					{
						string docTime2 = now.ToString("HH:mm:ss");
						int result4 = 0;
						FacadeFTP facadeFTP2 = new FacadeFTP(Configuration.FacadeFtp);
						string text14 = "";
						text14 = (model.CompanyId.HasValue ? model.CompanyId.ToString() : (Configuration.DyDirectoryPath + model.FormId));
						string folderName2 = (model.CompanyId.HasValue ? model.CompanyId.ToString() : model.FormId.ToString());
						string title = cRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result.Title;
						string title_Lang2 = "";
						List<CommonMultiLanguageViewModel> list13 = new List<CommonMultiLanguageViewModel>();
						foreach (Languages item5 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
						{
							list13.Add(new CommonMultiLanguageViewModel
							{
								Value = title,
								LanguageId = item5.LanguageID
							});
						}
						if (list13 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13))
						{
							title_Lang2 = JsonConvert.SerializeObject(list13);
						}
						CRMspInsertFilesDirectory_Result cRMspInsertFilesDirectory_Result2 = Enumerable.FirstOrDefault<CRMspInsertFilesDirectory_Result>((IEnumerable<CRMspInsertFilesDirectory_Result>)_dbI.CRMspInsertFilesDirectory(0, -65, model.CompanyId, model.CompanyPersonId, model.ProjectId, title, title_Lang2, folderName2, "", "", "", userId, value2, value, now, text2, now, text2, PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime2, result2, appType, defLangID, null, formId, fieldId, "", null, null, centerId));
						if (cRMspInsertFilesDirectory_Result2 != null)
						{
							int.TryParse(cRMspInsertFilesDirectory_Result2.FileId.ToString(), out result4);
						}
						if (result4 > 0)
						{
							string pathFtp2 = Configuration.PathFtp;
							string userNameFtp2 = Configuration.UserNameFtp;
							string passwordFtp2 = Configuration.PasswordFtp;
							bool usePassiveFtp2 = Configuration.UsePassiveFtp;
							string[] array7 = title.Split(new char[1] { '.' });
							string text15 = Configuration.MainDirectoryPath + text14 + "/";
							string text16 = text15 + (text15.EndsWith("/") ? "" : "/");
							string text17 = text16.Split(new char[1] { '/' })[^2];
							string destination = text16.Replace(text17 + "/", "");
							bool flag9 = false;
							if (!model.CompanyId.HasValue)
							{
								flag9 = facadeFTP2.ExistsDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, Configuration.MainDirectoryPath, Configuration.DyDirectoryPath, usePassiveFtp2);
								if (!flag9)
								{
									flag9 = facadeFTP2.CreateDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, Configuration.MainDirectoryPath, Configuration.DyDirectoryPath, usePassiveFtp2);
								}
							}
							else
							{
								flag9 = true;
							}
							bool flag10 = facadeFTP2.ExistsDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, destination, text17, usePassiveFtp2);
							if (!flag10)
							{
								flag10 = facadeFTP2.CreateDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, destination, text17, usePassiveFtp2);
							}
							if (flag10 && flag9)
							{
								string text18 = "";
								int num7 = result2;
								text18 = num7 + "-" + result4 + "." + array7[^1];
								string text19 = "";
								string copyFromPath = cRMspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result.CopyFromPath;
								if (!string.IsNullOrWhiteSpace(copyFromPath))
								{
									facadeFTP2.UploadFtpFormTable(pathFtp2, userNameFtp2, passwordFtp2, text16 + text18, copyFromPath, usePassiveFtp2);
									text15 = pathFtp2 + text16 + text18;
									text19 = text18;
									text15 = text15.Trim().Replace(pathFtp2, "");
									Enumerable.FirstOrDefault<CRMspInsertFilesDirectory_Result>((IEnumerable<CRMspInsertFilesDirectory_Result>)_dbI.CRMspInsertFilesDirectory(result4, -65, model.CompanyId, model.CompanyPersonId, model.ProjectId, title, title_Lang2, folderName2, text19, text15, "", userId, value2, value, now, text2, now, text2, PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime2, result2, appType, defLangID, null, formId, fieldId, "", null, null, centerId));
									obj.Value = result4.ToString();
								}
								else
								{
									try
									{
										_db.CRMspDeleteCrmFilesDirectory(result4);
									}
									catch (Exception e6)
									{
										ErrorSignal.FromCurrentContext().Raise(e6);
									}
									obj.Value = "";
								}
							}
							else
							{
								try
								{
									_db.CRMspDeleteCrmFilesDirectory(result4);
								}
								catch (Exception e7)
								{
									ErrorSignal.FromCurrentContext().Raise(e7);
								}
								obj.Value = "";
							}
						}
						else
						{
							obj.Value = "";
						}
					}
				}
				IdKeyValueItemViewModel idKeyValueItemViewModel2 = Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list6, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == ids));
				List<CommonMultiLanguageViewModel> list14 = new List<CommonMultiLanguageViewModel>();
				if (idKeyValueItemViewModel2 != null && (cRMspDySelectFormFieldsByParentFormId_Result4.FieldTypeId.GetValueOrDefault() == 1 || cRMspDySelectFormFieldsByParentFormId_Result4.FieldTypeId.GetValueOrDefault() == 3))
				{
					if (!string.IsNullOrEmpty(idKeyValueItemViewModel2.Value))
					{
						list14 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(idKeyValueItemViewModel2.Value);
					}
				}
				else
				{
					list14 = new List<CommonMultiLanguageViewModel>();
					foreach (Languages lang3 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != currLangID))))
					{
						string value4 = "";
						if (cRMspDySelectFormFieldsByParentFormId_Result4 == null)
						{
							continue;
						}
						switch (cRMspDySelectFormFieldsByParentFormId_Result4.FieldTypeId)
						{
						case 2:
						case 4:
						case 5:
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
							value4 = obj.Value;
							break;
						case 6:
						case 7:
						case 8:
							if (list3 != null && Enumerable.Any<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list3))
							{
								CRMspDySelectFormFieldValuesByMasterValueId_Result cRMspDySelectFormFieldValuesByMasterValueId_Result2 = Enumerable.FirstOrDefault<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list3, (Func<CRMspDySelectFormFieldValuesByMasterValueId_Result, bool>)((CRMspDySelectFormFieldValuesByMasterValueId_Result m) => m.FormId == formId && m.FieldId == fieldId && m.FieldRepeatId.GetValueOrDefault() == fieldRepeatId));
								if (cRMspDySelectFormFieldValuesByMasterValueId_Result2 == null)
								{
									break;
								}
								List<CommonMultiLanguageViewModel> list15 = new List<CommonMultiLanguageViewModel>();
								if (string.IsNullOrWhiteSpace(cRMspDySelectFormFieldValuesByMasterValueId_Result2.Value_Lang))
								{
									break;
								}
								list15 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(cRMspDySelectFormFieldValuesByMasterValueId_Result2.Value_Lang);
								if (list15 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15))
								{
									CommonMultiLanguageViewModel commonMultiLanguageViewModel2 = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == lang3.LanguageID));
									if (commonMultiLanguageViewModel2 != null)
									{
										value4 = ((commonMultiLanguageViewModel2.Value == null) ? null : (commonMultiLanguageViewModel2.Value ?? ""));
									}
								}
							}
							else
							{
								if (!flag5 || list == null || !string.IsNullOrWhiteSpace(value4))
								{
									break;
								}
								CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result5 = Enumerable.FirstOrDefault<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result x) => x.FormFieldId == int.Parse(obj.Id.Split(new char[1] { '_' })[1])));
								if (cRMspDySelectFormFieldsByParentFormId_Result5 == null || string.IsNullOrWhiteSpace(cRMspDySelectFormFieldsByParentFormId_Result5.MultiItems))
								{
									break;
								}
								string[] array8 = cRMspDySelectFormFieldsByParentFormId_Result5.MultiItems.Split(new char[1] { '|' });
								for (int k = 0; k < array8.Length; k++)
								{
									if (!string.IsNullOrWhiteSpace(array8[k]) && array8[k].Split(new char[1] { ':' })[1] == obj.Value)
									{
										value4 = obj.Value ?? "";
									}
								}
							}
							break;
						}
						list14.Add(new CommonMultiLanguageViewModel
						{
							Value = value4,
							LanguageId = lang3.LanguageID
						});
					}
				}
				list14.Add(new CommonMultiLanguageViewModel
				{
					Value = obj.Value,
					LanguageId = currLangID
				});
				string text20 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : null);
				if (!string.IsNullOrEmpty(text20) && (cRMspDySelectFormFieldsByParentFormId_Result4.FieldTypeId.GetValueOrDefault() == 1 || cRMspDySelectFormFieldsByParentFormId_Result4.FieldTypeId.GetValueOrDefault() == 3))
				{
					checkMultiLanguage(text20, list14);
				}
				if (result2 <= 0)
				{
					continue;
				}
				string value5 = "";
				if (list3 != null && list3.Count > 0)
				{
					CRMspDySelectFormFieldValuesByMasterValueId_Result val = Enumerable.FirstOrDefault<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list3, (Func<CRMspDySelectFormFieldValuesByMasterValueId_Result, bool>)((CRMspDySelectFormFieldValuesByMasterValueId_Result m) => m.FormId == formId && m.FieldId == fieldId && m.FieldRepeatId.GetValueOrDefault() == fieldRepeatId));
					if (val != null)
					{
						CRMspDySelectFormAndSubForms_Result cRMspDySelectFormAndSubForms_Result2 = Enumerable.FirstOrDefault<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list2, (Func<CRMspDySelectFormAndSubForms_Result, bool>)((CRMspDySelectFormAndSubForms_Result m) => m.FormId == val.FormId));
						if (cRMspDySelectFormAndSubForms_Result2 != null)
						{
							bool flag11 = true;
							bool flag12 = false;
							if (result == 0 || (model.WorkflowStepId.GetValueOrDefault() == 0 && model.WdSubFormId.GetValueOrDefault() == 0 && model.FormId == cRMspDySelectFormAndSubForms_Result2.FormId))
							{
								if (cRMspDySelectFormAndSubForms_Result2.EnableForRollId.HasValue)
								{
									flag11 = cRMspDySelectFormAndSubForms_Result2.EnableForRollId == UserLogin.CurrentUser.RollId || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser);
								}
								else if (!string.IsNullOrWhiteSpace(cRMspDySelectFormAndSubForms_Result2.EnableForUsersId))
								{
									string[] array9 = cRMspDySelectFormAndSubForms_Result2.EnableForUsersId.Split(new char[1] { '|' });
									if (Enumerable.Any<string>((IEnumerable<string>)array9))
									{
										foreach (string item6 in Enumerable.Where<string>((IEnumerable<string>)array9, (Func<string, bool>)((string usr) => !string.IsNullOrEmpty(usr))))
										{
											if (!flag12)
											{
												if (item6 == UserLogin.CurrentUser.UserId.ToString() || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
												{
													flag11 = true;
													flag12 = true;
												}
												else
												{
													flag11 = false;
												}
											}
										}
									}
								}
							}
							else if (model.WorkflowStepId > 0 && model.WdSubFormId > 0 && model.WdSubFormId == cRMspDySelectFormAndSubForms_Result2.FormId)
							{
								CRMspDySelectFormWorkflowStepWithId_Result cRMspDySelectFormWorkflowStepWithId_Result2 = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepWithId_Result>((IEnumerable<CRMspDySelectFormWorkflowStepWithId_Result>)_db.CRMspDySelectFormWorkflowStepWithId(model.WorkflowStepId, currLangID, defLangID, num));
								if (cRMspDySelectFormWorkflowStepWithId_Result2 != null)
								{
									string text21 = cRMspDySelectFormWorkflowStepWithId_Result2.ReferUserIds ?? "";
									if (!string.IsNullOrEmpty(text21))
									{
										bool flag13 = false;
										string[] array10 = text21.Split(new char[1] { '|' });
										if (array10 != null)
										{
											string[] array11 = array10;
											foreach (string text22 in array11)
											{
												if (!string.IsNullOrEmpty(text22) && int.Parse(text22) == userId)
												{
													flag13 = true;
													break;
												}
											}
										}
										if (!flag13 && !UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
										{
											flag11 = false;
										}
									}
								}
							}
							else
							{
								flag11 = false;
							}
							if (!flag11)
							{
								List<CommonMultiLanguageViewModel> list16 = new List<CommonMultiLanguageViewModel>();
								list16.Add(new CommonMultiLanguageViewModel
								{
									Value = (val.Value ?? ""),
									LanguageId = currLangID
								});
								if (!string.IsNullOrWhiteSpace(val.Value_Lang))
								{
									List<CommonMultiLanguageViewModel> collection = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(val.Value_Lang);
									list16.AddRange(collection);
								}
								List<CommonMultiLanguageViewModel> list17 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangID)));
								if (list17 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17))
								{
									JsonConvert.SerializeObject(list17);
								}
								value5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							}
							else
							{
								List<CommonMultiLanguageViewModel> list18 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangID)));
								if (list18 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18))
								{
									JsonConvert.SerializeObject(list18);
								}
								value5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							}
						}
					}
					else
					{
						List<CommonMultiLanguageViewModel> list19 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangID)));
						if (list19 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list19))
						{
							JsonConvert.SerializeObject(list19);
						}
						value5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					}
				}
				else
				{
					List<CommonMultiLanguageViewModel> list20 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangID)));
					if (list20 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list20))
					{
						JsonConvert.SerializeObject(list20);
					}
					value5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				}
				FieldValueViewModel item = new FieldValueViewModel
				{
					FormId = formId,
					FieldId = fieldId,
					FieldRepeatId = fieldRepeatId,
					Value = CRM.General.Text.String.CleanString(value5, allTrue: true)
				};
				list11.Add(item);
				new List<CommonMultiLanguageViewModel>();
				if (list14 == null || !Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14))
				{
					continue;
				}
				foreach (Languages lang2 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
				{
					CommonMultiLanguageViewModel commonMultiLanguageViewModel3 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel3.LanguageId = lang2.LanguageID;
					FieldValueViewModel value6 = new FieldValueViewModel
					{
						FormId = formId,
						FieldId = fieldId,
						FieldRepeatId = fieldRepeatId,
						Value = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) != null) ? CRM.General.Text.String.CleanString(Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value, allTrue: true) : "")
					};
					commonMultiLanguageViewModel3.Value = JsonConvert.SerializeObject(value6);
					list12.Add(commonMultiLanguageViewModel3);
				}
			}
			string value7 = "";
			string valueLang = "";
			if (list11 != null && Enumerable.Any<FieldValueViewModel>((IEnumerable<FieldValueViewModel>)list11))
			{
				value7 = JsonConvert.SerializeObject(Enumerable.ToList<FieldValueViewModel>((IEnumerable<FieldValueViewModel>)list11));
			}
			if (list12 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12))
			{
				List<CommonMultiLanguageViewModel> list21 = new List<CommonMultiLanguageViewModel>();
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
				{
					CommonMultiLanguageViewModel commonMultiLanguageViewModel4 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel4.LanguageId = lang.LanguageID;
					List<FieldValueViewModel> list22 = new List<FieldValueViewModel>();
					List<CommonMultiLanguageViewModel> list23 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == lang.LanguageID)));
					if (list23 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list23))
					{
						foreach (CommonMultiLanguageViewModel item7 in list23)
						{
							if (!string.IsNullOrWhiteSpace(item7.Value))
							{
								FieldValueViewModel fieldValueViewModel = new JavaScriptSerializer().Deserialize<FieldValueViewModel>(item7.Value);
								if (fieldValueViewModel != null)
								{
									FieldValueViewModel item2 = new FieldValueViewModel
									{
										FormId = fieldValueViewModel.FormId,
										FieldId = fieldValueViewModel.FieldId,
										FieldRepeatId = fieldValueViewModel.FieldRepeatId,
										Value = fieldValueViewModel.Value
									};
									list22.Add(item2);
								}
							}
						}
					}
					commonMultiLanguageViewModel4.Value = JsonConvert.SerializeObject(Enumerable.ToList<FieldValueViewModel>((IEnumerable<FieldValueViewModel>)list22));
					list21.Add(commonMultiLanguageViewModel4);
				}
				valueLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list21));
			}
			if (list3 != null && Enumerable.Any<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list3))
			{
				int result5 = 0;
				CRMspDySelectFormFieldValuesByMasterValueId_Result cRMspDySelectFormFieldValuesByMasterValueId_Result3 = Enumerable.FirstOrDefault<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list3);
				if (cRMspDySelectFormFieldValuesByMasterValueId_Result3 != null)
				{
					int.TryParse(cRMspDySelectFormFieldValuesByMasterValueId_Result3.FormFieldValueId.ToString(), out result5);
				}
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDyUpdateFormFieldValues(result5, value7, valueLang, userId, now, text2, value2, value, appType, defLangID));
				int result6 = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result6);
				}
				if (result6 > 0)
				{
					goto IL_38fb;
				}
				data = "";
				text = Messages.msgErrorInSaveInfo;
				status = CommonResultStatusViewModel.Error;
			}
			else
			{
				mct_I_Result mct_I_Result2 = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDyInsertFormFieldValues(result2, model.FormId, null, model.CompanyId, model.CompanyPersonId, model.ProjectId, model.ConversationId, model.MasterObjectId, model.DetailObjectId, model.SubDetailObjectId, value7, valueLang, userId, now, text2, value2, value, appType, defLangID));
				int result7 = 0;
				if (mct_I_Result2 != null)
				{
					int.TryParse(mct_I_Result2.Result.ToString(), out result7);
				}
				if (result7 > 0)
				{
					goto IL_38fb;
				}
				data = "";
				text = Messages.msgErrorInSaveInfo;
				status = CommonResultStatusViewModel.Error;
				_db.CRMspDyDeleteFormFieldMasterValue(result2);
			}
			goto end_IL_001b;
			IL_1c07:
			flag8 = false;
			num6 = 0;
			mainFormReferUserIs = "";
			if (result2 <= 0 || result <= 0)
			{
				goto IL_2025;
			}
			bool flag14 = false;
			CRMspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result cRMspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result = new CRMspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result();
			cRMspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result>)_dbI.CRMspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId(model.FormId, result2));
			CRMspDySelectFormAndSubForms_Result cRMspDySelectFormAndSubForms_Result3;
			if (cRMspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result != null)
			{
				if (!model.WdSubFormId.HasValue && !model.WorkflowStepId.HasValue)
				{
					_dbI.CRMspDyUpdateFormFieldMasterValueDetails(cRMspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result.FormFieldMasterValueDetailId, userId, now, text2, value2, value, appType);
				}
			}
			else
			{
				flag14 = true;
				mct_I_Result mct_I_Result3 = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDyInsertFormFieldMasterValueDetails(result2, model.FormId, userId, now, text2, value2, value, appType, defLangID));
				if (mct_I_Result3 != null)
				{
					int result8 = 0;
					int.TryParse(mct_I_Result3.Result.ToString(), out result8);
				}
				CRMspDySelectFormWorkflowStepsForMasterValue_Result cRMspDySelectFormWorkflowStepsForMasterValue_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<CRMspDySelectFormWorkflowStepsForMasterValue_Result>)_db.CRMspDySelectFormWorkflowStepsForMasterValue(result, result2, currLangID, defLangID, num));
				if (cRMspDySelectFormWorkflowStepsForMasterValue_Result != null)
				{
					num6 = cRMspDySelectFormWorkflowStepsForMasterValue_Result.FormWorkflowStepId;
				}
				mainFormReferUserIs = cRMspDySelectFormAndSubForms_Result3.ReferUserIds ?? "";
			}
			if (!(model.WdSubFormId > 0) || !(model.WorkflowStepId > 0))
			{
				goto IL_2025;
			}
			CRMspDySelectFormWorkflowStepBFCurr_Result cRMspDySelectFormWorkflowStepBFCurr_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepBFCurr_Result>((IEnumerable<CRMspDySelectFormWorkflowStepBFCurr_Result>)_db.CRMspDySelectFormWorkflowStepBFCurr(result, model.WorkflowStepId, result2, model.WdSubFormId, currLangID, defLangID));
			if (cRMspDySelectFormWorkflowStepBFCurr_Result != null)
			{
				string text23 = string.Format(Messages.msgErrorCheckFormWorkflowDetailBFCurr, cRMspDySelectFormWorkflowStepBFCurr_Result.WorkflowStepTitle ?? "") + "<br>";
				base.ModelState.AddModelError("error", text23);
				base.ViewBag.Error = text23;
				text = text23;
				status = CommonResultStatusViewModel.Fail;
				if (flag14)
				{
					try
					{
						_db.CRMspDyDeleteFormFieldMasterValue(result2);
					}
					catch (Exception e8)
					{
						ErrorSignal.FromCurrentContext().Raise(e8);
					}
				}
			}
			else
			{
				CRMspDySelectFormFieldMasterValueDetailWithId_Result cRMspDySelectFormFieldMasterValueDetailWithId_Result = new CRMspDySelectFormFieldMasterValueDetailWithId_Result();
				cRMspDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetailWithId_Result>)_db.CRMspDySelectFormFieldMasterValueDetailWithId(model.MasterValueDetailId, currLangID, defLangID));
				if (cRMspDySelectFormFieldMasterValueDetailWithId_Result != null)
				{
					_dbI.CRMspDyUpdateFormFieldMasterValueDetails(cRMspDySelectFormFieldMasterValueDetailWithId_Result.FormFieldMasterValueDetailId, userId, now, text2, value2, value, appType);
					goto IL_2025;
				}
				flag8 = true;
				mct_I_Result mct_I_Result4 = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDyInsertFormFieldMasterValueDetails(result2, model.WdSubFormId.GetValueOrDefault(), userId, now, text2, value2, value, appType, defLangID));
				if (mct_I_Result4 != null)
				{
					int result9 = 0;
					int.TryParse(mct_I_Result4.Result.ToString(), out result9);
					model.MasterValueDetailId = result9;
					goto IL_2025;
				}
				text = Messages.msgErrorRunFunction;
				status = CommonResultStatusViewModel.Fail;
			}
			goto end_IL_001b;
			IL_05e5:
			if (model.WdSubFormId > 0 && model.WorkflowStepId > 0)
			{
				CRMspDySelectFormWorkflowStepWithId_Result cRMspDySelectFormWorkflowStepWithId_Result3 = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepWithId_Result>((IEnumerable<CRMspDySelectFormWorkflowStepWithId_Result>)_db.CRMspDySelectFormWorkflowStepWithId(model.WorkflowStepId, currLangID, defLangID, num));
				if (cRMspDySelectFormWorkflowStepWithId_Result3 == null)
				{
					goto IL_0888;
				}
				string text24 = cRMspDySelectFormWorkflowStepWithId_Result3.ReferUserIds ?? "";
				if (string.IsNullOrEmpty(text24))
				{
					goto IL_0888;
				}
				bool flag15 = false;
				string[] array12 = text24.Split(new char[1] { '|' });
				if (array12 != null)
				{
					string[] array11 = array12;
					foreach (string text25 in array11)
					{
						if (!string.IsNullOrEmpty(text25) && int.Parse(text25) == userId)
						{
							flag15 = true;
							break;
						}
					}
				}
				if (flag15 || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
				{
					goto IL_0888;
				}
				string text26 = string.Format(Messages.msgErrorYouNotDyFormReferUsers, cRMspDySelectFormWorkflowStepWithId_Result3.SubForm);
				base.ModelState.AddModelError("error", Messages.DyFrmUserNotAccess + "<br>" + text26);
				text = Messages.DyFrmUserNotAccess + "<br>" + text26;
				status = CommonResultStatusViewModel.Fail;
			}
			else
			{
				if (result <= 0 || cRMspDySelectFormAndSubForms_Result3 == null)
				{
					goto IL_0888;
				}
				bool flag16 = false;
				int? enableForRollId = cRMspDySelectFormAndSubForms_Result3.EnableForRollId;
				string text27 = cRMspDySelectFormAndSubForms_Result3.EnableForUsersId ?? "";
				if (enableForRollId.HasValue)
				{
					flag16 = enableForRollId == UserLogin.CurrentUser.RollId;
				}
				else if (!string.IsNullOrEmpty(text27))
				{
					string[] array13 = text27.Split(new char[1] { '|' });
					if (array13 != null)
					{
						string[] array11 = array13;
						foreach (string text28 in array11)
						{
							if (!string.IsNullOrEmpty(text28) && int.Parse(text28) == userId)
							{
								flag16 = true;
								break;
							}
						}
					}
				}
				else
				{
					flag16 = true;
				}
				if (flag16 || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
				{
					goto IL_0888;
				}
				string text29 = string.Format(Messages.msgErrorYouNotDyFormReferUsers, cRMspDySelectFormAndSubForms_Result3.FormName ?? "");
				base.ModelState.AddModelError("error", Messages.DyFrmUserNotAccess + "<br>" + text29);
				text = Messages.DyFrmUserNotAccess + "<br>" + text29;
				status = CommonResultStatusViewModel.Fail;
			}
			goto end_IL_001b;
			IL_029f:
			bool result10 = false;
			bool.TryParse(model.CanSave.ToString(), out result10);
			if (result10)
			{
				list2 = Enumerable.ToList<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)_dbI.CRMspDySelectFormAndSubForms(model.FormId, userId, currLangID, defLangID, num));
				cRMspDySelectFormAndSubForms_Result3 = new CRMspDySelectFormAndSubForms_Result();
				if (list2 != null && Enumerable.Any<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list2))
				{
					cRMspDySelectFormAndSubForms_Result3 = Enumerable.FirstOrDefault<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list2, (Func<CRMspDySelectFormAndSubForms_Result, bool>)((CRMspDySelectFormAndSubForms_Result m) => m.FormId == model.FormId));
					if (cRMspDySelectFormAndSubForms_Result3 != null)
					{
						int.TryParse(cRMspDySelectFormAndSubForms_Result3.WorkflowId.ToString(), out result);
						flag = result > 0;
						text3 = ((!string.IsNullOrEmpty(cRMspDySelectFormAndSubForms_Result3.FormName)) ? cRMspDySelectFormAndSubForms_Result3.FormName : "");
						flag2 = cRMspDySelectFormAndSubForms_Result3.CrmSysPartId.GetValueOrDefault() == 1 || cRMspDySelectFormAndSubForms_Result3.FOSysPartId.GetValueOrDefault() == 100;
						list = Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)_dbI.CRMspDySelectFormFieldsByParentFormId(model.FormId, currLangID, defLangID));
						list5 = new List<IdKeyValueItemViewModel>();
						list6 = new List<IdKeyValueItemViewModel>();
						if (!string.IsNullOrWhiteSpace(model.ValueDetails))
						{
							list5 = new JavaScriptSerializer().Deserialize<List<IdKeyValueItemViewModel>>(model.ValueDetails);
						}
						if (!string.IsNullOrWhiteSpace(model.ValueDetails_Lang))
						{
							list6 = new JavaScriptSerializer().Deserialize<List<IdKeyValueItemViewModel>>(model.ValueDetails_Lang);
						}
						if (DyForm.IsChecked(model.MasterValueId))
						{
							base.ModelState.AddModelError("error", Messages.msgFormIsChecked);
							text = Messages.msgFormIsChecked;
							status = CommonResultStatusViewModel.Fail;
						}
						else
						{
							if (model.MasterValueId <= 0 || !(model.MasterValueDetailId > 0))
							{
								goto IL_05e5;
							}
							int result11 = 0;
							int.TryParse(model.MasterValueDetailId.ToString(), out result11);
							if (!DyForm.SubFormIsChecked(result11))
							{
								goto IL_05e5;
							}
							base.ModelState.AddModelError("error", Messages.msgFormIsChecked);
							text = Messages.msgFormIsChecked;
							status = CommonResultStatusViewModel.Fail;
						}
					}
					else
					{
						base.ViewBag.Error = Messages.MsgFormNotDefined;
						text = Messages.MsgFormNotDefined;
						status = CommonResultStatusViewModel.Fail;
					}
				}
				else
				{
					base.ViewBag.Error = Messages.MsgFormNotDefined;
					text = Messages.MsgFormNotDefined;
					status = CommonResultStatusViewModel.Fail;
				}
			}
			goto end_IL_001b;
			IL_0888:
			if (!base.ModelState.IsValid)
			{
				base.ModelState.AddModelError("error", Messages.msgErrorRunFunction);
				text = Messages.msgErrorRunFunction;
				status = CommonResultStatusViewModel.Fail;
			}
			else
			{
				string text30 = "*";
				if (cRMspDySelectFormAndSubForms_Result3 != null)
				{
					text30 = ((!string.IsNullOrEmpty(cRMspDySelectFormAndSubForms_Result3.UploadFileExtension)) ? cRMspDySelectFormAndSubForms_Result3.UploadFileExtension : "*");
				}
				if (formFileSending != null)
				{
					HttpPostedFileBase[] array4 = formFileSending;
					int j = 0;
					while (j < array4.Length)
					{
						HttpPostedFileBase val4 = array4[j];
						val4.ContentType.ToLower();
						string text31 = ((val4.FileName != null) ? Path.GetExtension(val4.FileName).ToLower() : "");
						if (text30 != "*" && !string.IsNullOrWhiteSpace(text30) && text30.IndexOf(text31, StringComparison.Ordinal) < 0)
						{
							base.ModelState.AddModelError("error", string.Format(Messages.msgErrorMessageFileExtension, text30));
							text = string.Format(Messages.msgErrorMessageFileExtension, text30);
							status = CommonResultStatusViewModel.Fail;
						}
						else
						{
							string text32 = (text31 ?? "").ToLower();
							text32 = text32.Replace(".", "");
							if (Configuration.MaliciousFileExtensions.Contains(text32))
							{
								base.ModelState.AddModelError("error", Messages.msgErrorFileIsExecuted);
								text = Messages.msgErrorFileIsExecuted;
								status = CommonResultStatusViewModel.Fail;
							}
							else
							{
								int num8 = cRMspDySelectFormAndSubForms_Result3.UploadFileMaxSize.GetValueOrDefault() * 1024;
								if (val4.ContentLength <= num8)
								{
									j++;
									continue;
								}
								string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(val4.ContentLength);
								string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num8);
								string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
								base.ModelState.AddModelError("error", string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2));
								text = string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2);
								status = CommonResultStatusViewModel.Fail;
							}
						}
						goto end_IL_001b;
					}
				}
				result2 = 0;
				CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = new CRMspDySelectFormFieldMasterValueWithId_Result();
				flag5 = false;
				if (model.MasterValueId > 0)
				{
					cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(model.MasterValueId, currLangID, defLangID));
					if (cRMspDySelectFormFieldMasterValueWithId_Result != null)
					{
						if (!UserLogin.IsUserAccess("frmDyForm", "actCanChangeSysPartObj", UserLogin.CurrentUser))
						{
							model.CompanyId = cRMspDySelectFormFieldMasterValueWithId_Result.CompanyId;
							model.CompanyPersonId = cRMspDySelectFormFieldMasterValueWithId_Result.CompanyPersonId;
							model.ProjectId = cRMspDySelectFormFieldMasterValueWithId_Result.ProjectId;
							model.ConversationId = cRMspDySelectFormFieldMasterValueWithId_Result.ConversationId;
							model.MasterObjectId = cRMspDySelectFormFieldMasterValueWithId_Result.MasterObjectId;
							model.DetailObjectId = cRMspDySelectFormFieldMasterValueWithId_Result.DetailObjectId;
							model.SubDetailObjectId = cRMspDySelectFormFieldMasterValueWithId_Result.SubDetailObjectId;
						}
						else
						{
							if (!model.CompanyId.HasValue || model.CompanyId == 0)
							{
								model.CompanyId = cRMspDySelectFormFieldMasterValueWithId_Result.CompanyId;
							}
							if (!model.CompanyPersonId.HasValue || model.CompanyPersonId == 0)
							{
								model.CompanyPersonId = cRMspDySelectFormFieldMasterValueWithId_Result.CompanyPersonId;
							}
							if (!model.ProjectId.HasValue || model.ProjectId == 0)
							{
								model.ProjectId = cRMspDySelectFormFieldMasterValueWithId_Result.ProjectId;
							}
							if (!model.ConversationId.HasValue || model.ConversationId == 0)
							{
								model.ConversationId = cRMspDySelectFormFieldMasterValueWithId_Result.ConversationId;
							}
							if (!model.MasterObjectId.HasValue || model.MasterObjectId == 0)
							{
								model.MasterObjectId = cRMspDySelectFormFieldMasterValueWithId_Result.MasterObjectId;
							}
							if (!model.DetailObjectId.HasValue || model.DetailObjectId == 0)
							{
								model.DetailObjectId = cRMspDySelectFormFieldMasterValueWithId_Result.DetailObjectId;
							}
							if (!model.SubDetailObjectId.HasValue || model.SubDetailObjectId == 0)
							{
								model.SubDetailObjectId = cRMspDySelectFormFieldMasterValueWithId_Result.SubDetailObjectId;
							}
						}
					}
				}
				if (!UserLogin.IsUserAccess("frmDyForm", "actCanEditDyFormNumber", UserLogin.CurrentUser))
				{
					model.DyFormNumber = null;
				}
				if (cRMspDySelectFormFieldMasterValueWithId_Result.FormFieldMasterValueId <= 0)
				{
					flag5 = true;
					mct_I_Result mct_I_Result5 = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDyInsertFormFieldMasterValues(model.FormId, model.CompanyId, model.CompanyPersonId, model.ProjectId, model.ConversationId, model.MasterObjectId, model.DetailObjectId, model.SubDetailObjectId, (result > 0) ? new int?(result) : null, model.WorkflowStepId, userId, now, text2, value2, value, appType, defLangID, VersionConfig.CurrentDyFormFieldMasterValuesTableVersion, num));
					if (mct_I_Result5 != null)
					{
						int.TryParse(mct_I_Result5.Result.ToString(), out result2);
					}
					if (result == 0 && result2 > 0)
					{
						_db.CRMspDyInsertUpdateFormFieldMasterValueDetails(1, result2, model.FormId, userId, now, text2, value2, value, appType, defLangID);
					}
					goto IL_112c;
				}
				if (!model.DyFormNumber.HasValue || Enumerable.FirstOrDefault<CRMspDyCheckDuplicateDyFormNumber_Result>((IEnumerable<CRMspDyCheckDuplicateDyFormNumber_Result>)_dbI.CRMspDyCheckDuplicateDyFormNumber(model.DyFormNumber.GetValueOrDefault(), cRMspDySelectFormFieldMasterValueWithId_Result.FormFieldMasterValueId, model.FormId, cRMspDySelectFormFieldMasterValueWithId_Result.CId ?? num.GetValueOrDefault())) == null)
				{
					result2 = cRMspDySelectFormFieldMasterValueWithId_Result.FormFieldMasterValueId;
					if (!model.WdSubFormId.HasValue && !model.WorkflowStepId.HasValue)
					{
						_dbI.CRMspDyUpdateFormFieldMasterValues(result2, model.DyFormNumber, companyId: model.CompanyId, companyPersonId: model.CompanyPersonId, projectId: model.ProjectId, conversationId: model.ConversationId, masterObjectId: model.MasterObjectId, detailObjectId: model.DetailObjectId, subDetailObjectId: model.SubDetailObjectId, userId: userId, registerDate: now, registerDatePersian: text2, year1: value2, month1: value, appType: appType);
					}
					if (result == 0)
					{
						_db.CRMspDyInsertUpdateFormFieldMasterValueDetails(2, result2, model.FormId, userId, now, text2, value2, value, appType, defLangID);
					}
					goto IL_112c;
				}
				text = Messages.DyFormNumberIsRepeated;
				base.ModelState.AddModelError("error", text);
				base.ViewBag.Error = text;
				status = CommonResultStatusViewModel.Fail;
			}
			end_IL_001b:;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			data = "";
			text = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			status = CommonResultStatusViewModel.Error;
		}
		CommonResultViewModel<string> data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = text,
			Status = status
		};
		JsonResult jsonResult2 = Json(data2, JsonRequestBehavior.AllowGet);
		jsonResult2.MaxJsonLength = int.MaxValue;
		return jsonResult2;
	}

	[AjaxOnly]
	public JsonResult GetMasterValue(int formId, int mValId, int? cmpId = null, int? prsId = null, int? prjId = null, int? cnvsId = null, int? mObjId = null, int? dObjId = null, int? subObjId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentMasterValueViewModel currentMasterValueViewModel = new CurrentMasterValueViewModel();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int userId = UserLogin.CurrentUser.UserId;
			List<mct_CRMspDySelectFormFieldMasterValues_Result> list = Enumerable.ToList<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)_db.mfi_CRMspDySelectFormFieldMasterValues(formId, cmpId, prsId, prjId, cnvsId, mObjId, dObjId, subObjId, lCID, result, userId, result2));
			if (Enumerable.Any<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)list))
			{
				currentMasterValueViewModel.IsFind = true;
				currentMasterValueViewModel.Message = "";
				currentMasterValueViewModel.MasterValueNextId = -1;
				currentMasterValueViewModel.MasterValuePreviousId = -1;
				currentMasterValueViewModel.MasterValueFirstId = -1;
				currentMasterValueViewModel.MasterValueLastId = -1;
				if (list.Count == 1)
				{
					currentMasterValueViewModel.MasterValueFirstId = -1;
					currentMasterValueViewModel.MasterValueLastId = -1;
				}
				else
				{
					currentMasterValueViewModel.MasterValueFirstId = Enumerable.FirstOrDefault<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)list).FormFieldMasterValueId.Value;
					currentMasterValueViewModel.MasterValueLastId = Enumerable.LastOrDefault<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)list).FormFieldMasterValueId.Value;
				}
				mct_CRMspDySelectFormFieldMasterValues_Result mct_CRMspDySelectFormFieldMasterValues_Result = ((mValId <= 0) ? Enumerable.LastOrDefault<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)list) : list.Find((mct_CRMspDySelectFormFieldMasterValues_Result c) => c.FormFieldMasterValueId == mValId));
				if (mct_CRMspDySelectFormFieldMasterValues_Result != null)
				{
					mct_CRMspDySelectFormFieldMasterValues_Result.FirstRegisterDatePersian = (mct_CRMspDySelectFormFieldMasterValues_Result.FirstRegisterDate.HasValue ? mct_CRMspDySelectFormFieldMasterValues_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					mct_CRMspDySelectFormFieldMasterValues_Result.RegisterDatePersian = (mct_CRMspDySelectFormFieldMasterValues_Result.RegisterDate.HasValue ? mct_CRMspDySelectFormFieldMasterValues_Result.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					if (string.IsNullOrEmpty(mct_CRMspDySelectFormFieldMasterValues_Result.AppType))
					{
						mct_CRMspDySelectFormFieldMasterValues_Result.AppType = Configuration.AppType;
					}
					mct_CRMspDySelectFormFieldMasterValues_Result.AppType = Configuration.GetAppType(mct_CRMspDySelectFormFieldMasterValues_Result.AppType);
					mct_CRMspDySelectFormFieldMasterValues_Result.CheckedDatePersian = (mct_CRMspDySelectFormFieldMasterValues_Result.CheckedDate.HasValue ? mct_CRMspDySelectFormFieldMasterValues_Result.CheckedDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					currentMasterValueViewModel.MasterValue = mct_CRMspDySelectFormFieldMasterValues_Result;
					currentMasterValueViewModel.FirstRegisterUser = mct_CRMspDySelectFormFieldMasterValues_Result.FirstRegisterUser + " " + mct_CRMspDySelectFormFieldMasterValues_Result.FirstRegisterDatePersian;
					currentMasterValueViewModel.EditUser = mct_CRMspDySelectFormFieldMasterValues_Result.EditUser + " (" + mct_CRMspDySelectFormFieldMasterValues_Result.AppType + ") " + mct_CRMspDySelectFormFieldMasterValues_Result.RegisterDatePersian;
					currentMasterValueViewModel.MasterValueCurrentId = mct_CRMspDySelectFormFieldMasterValues_Result.FormFieldMasterValueId.Value;
					currentMasterValueViewModel.CheckerUser = mct_CRMspDySelectFormFieldMasterValues_Result.CheckerUser + " " + mct_CRMspDySelectFormFieldMasterValues_Result.CheckedDatePersian;
					currentMasterValueViewModel.IsChecked = mct_CRMspDySelectFormFieldMasterValues_Result.IsChecked.HasValue && mct_CRMspDySelectFormFieldMasterValues_Result.IsChecked != false;
					currentMasterValueViewModel.CheckerUserId = mct_CRMspDySelectFormFieldMasterValues_Result.CheckerUserId.GetValueOrDefault();
					if (list.Count == 1)
					{
						currentMasterValueViewModel.MasterValueNextId = -1;
						currentMasterValueViewModel.MasterValuePreviousId = -1;
					}
					else
					{
						mct_CRMspDySelectFormFieldMasterValues_Result next = Lists.GetNext(list, mct_CRMspDySelectFormFieldMasterValues_Result);
						if (next != null)
						{
							currentMasterValueViewModel.MasterValueNextId = next.FormFieldMasterValueId.Value;
						}
						mct_CRMspDySelectFormFieldMasterValues_Result previous = Lists.GetPrevious(list, mct_CRMspDySelectFormFieldMasterValues_Result);
						if (previous != null)
						{
							currentMasterValueViewModel.MasterValuePreviousId = previous.FormFieldMasterValueId.Value;
						}
					}
				}
				else
				{
					currentMasterValueViewModel.IsFind = false;
					currentMasterValueViewModel.Message = Messages.ErrorNotFound;
					currentMasterValueViewModel.MasterValueNextId = -1;
					currentMasterValueViewModel.MasterValuePreviousId = -1;
					currentMasterValueViewModel.MasterValueFirstId = -1;
					currentMasterValueViewModel.MasterValueLastId = -1;
					currentMasterValueViewModel.FirstRegisterUser = "";
					currentMasterValueViewModel.EditUser = "";
					currentMasterValueViewModel.MasterValueCurrentId = -1;
				}
			}
			else
			{
				currentMasterValueViewModel.IsFind = false;
				currentMasterValueViewModel.Message = Messages.ErrorNotFound;
				currentMasterValueViewModel.IsFind = false;
				currentMasterValueViewModel.Message = Messages.ErrorNotFound;
				currentMasterValueViewModel.MasterValueNextId = -1;
				currentMasterValueViewModel.MasterValuePreviousId = -1;
				currentMasterValueViewModel.MasterValueFirstId = -1;
				currentMasterValueViewModel.MasterValueLastId = -1;
				currentMasterValueViewModel.FirstRegisterUser = "";
				currentMasterValueViewModel.EditUser = "";
				currentMasterValueViewModel.MasterValueCurrentId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentMasterValueViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentMasterValueViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentMasterValueViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult _PartialForm(int formId, string partTitle = "", int position = 1, int? cmpId = null, int? prsId = null, int? prjId = null, int? cnvsId = null, int? mObjId = null, int? dObjId = null, int? subObjId = null, int? mValId = null)
	{
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			BaseInfo baseInfo = new BaseInfo();
			new CrmDyFormFieldValuesLanguageViewModel();
			List<CRMspDySelectFormAndSubForms_Result> list = new List<CRMspDySelectFormAndSubForms_Result>();
			List<CRMspDySelectFormFieldsByParentFormId_Result> list2 = new List<CRMspDySelectFormFieldsByParentFormId_Result>();
			string text = "";
			string text2 = "";
			List<CRMspDySelectFormWorkflowStepsForMasterValue_Result> list3 = new List<CRMspDySelectFormWorkflowStepsForMasterValue_Result>();
			int result = 0;
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
				int result3 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
				}
				List<CRMspDySelectFormAndSubForms_Result> list4 = Enumerable.ToList<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)_dbI.CRMspDySelectFormAndSubForms(formId, UserLogin.CurrentUser.UserId, currLangID, result2, result3));
				if (list4 != null && Enumerable.Any<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list4))
				{
					CRMspDySelectFormAndSubForms_Result cRMspDySelectFormAndSubForms_Result = Enumerable.FirstOrDefault<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list4, (Func<CRMspDySelectFormAndSubForms_Result, bool>)((CRMspDySelectFormAndSubForms_Result m) => m.ParentFormId == 0));
					if (cRMspDySelectFormAndSubForms_Result != null)
					{
						int.TryParse(cRMspDySelectFormAndSubForms_Result.WorkflowId.ToString(), out result);
						if (!string.IsNullOrEmpty(cRMspDySelectFormAndSubForms_Result.FormName))
						{
							_ = cRMspDySelectFormAndSubForms_Result.FormName;
						}
					}
					list.AddRange(list4);
					if (Enumerable.Any<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list))
					{
						foreach (CRMspDySelectFormAndSubForms_Result item in list)
						{
							item.FormTitleColor = baseInfo.DelphiCToRgbolor(item.FormTitleColor);
							item.FormBgColor = baseInfo.DelphiCToRgbolor(item.FormBgColor);
						}
					}
					List<CRMspDySelectFormFieldsByParentFormId_Result> list5 = Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)_dbI.CRMspDySelectFormFieldsByParentFormId(formId, currLangID, result2));
					if (list5 != null && Enumerable.Any<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list5))
					{
						foreach (CRMspDySelectFormFieldsByParentFormId_Result item2 in list5)
						{
							item2.ParentFieldColor = baseInfo.DelphiCToRgbolor(item2.ParentFieldColor);
							item2.ParentFieldBgColor = baseInfo.DelphiCToRgbolor(item2.ParentFieldBgColor);
						}
					}
					list2.AddRange(list5);
				}
				List<IdKeyValueItemViewModel> list6 = new List<IdKeyValueItemViewModel>();
				List<IdKeyValueItemViewModel> list7 = new List<IdKeyValueItemViewModel>();
				if (mValId > 0)
				{
					List<CRMspDySelectFormFieldValuesByMasterValueId_Result> list8 = Enumerable.ToList<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)_dbI.CRMspDySelectFormFieldValuesByMasterValueId(mValId, currLangID, result2));
					foreach (CRMspDySelectFormFieldValuesByMasterValueId_Result item3 in list8)
					{
						List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(item3.Value_Lang))
						{
							list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item3.Value_Lang);
						}
						if (list9 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9) && item3.FieldTypeId.GetValueOrDefault() == 4)
						{
							foreach (CommonMultiLanguageViewModel item4 in list9)
							{
								if (string.IsNullOrEmpty(item4.Value))
								{
									continue;
								}
								DateTime dateTime = default(DateTime);
								item4.Value = item4.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
									.Replace(" ", "")
									.Replace("_", "");
								if (currLangID == 1065)
								{
									item4.Value = DateTime.Parse(PersianDate.GetFormatetdDate(item4.Value) + " 00:00:00", new PersianCulture()).ToString("yyyy/MM/dd", new PersianCulture());
									continue;
								}
								dateTime = DateTime.Parse(PersianDate.GetShamsi2Miladi(item4.Value.Replace("/", "")));
								if (currLangID == 1025)
								{
									item4.Value = dateTime.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
								}
								else
								{
									item4.Value = dateTime.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
								}
							}
						}
						if (item3.FieldTypeId.GetValueOrDefault() == 4 && !string.IsNullOrEmpty(item3.Value))
						{
							DateTime dateTime2 = default(DateTime);
							item3.Value = item3.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							if (currLangID == 1065)
							{
								item3.Value = DateTime.Parse(PersianDate.GetFormatetdDate(item3.Value) + " 00:00:00", new PersianCulture()).ToString("yyyy/MM/dd", new PersianCulture());
							}
							else
							{
								dateTime2 = DateTime.Parse(PersianDate.GetShamsi2Miladi(item3.Value.Replace("/", "")));
								if (currLangID == 1025)
								{
									item3.Value = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
								}
								else
								{
									item3.Value = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
								}
							}
						}
						List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
						if (list9 != null && list9.Count > 0)
						{
							list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CommonMultiLanguageViewModel, CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, CommonMultiLanguageViewModel>)((CommonMultiLanguageViewModel item) => new CommonMultiLanguageViewModel
							{
								Value = item.Value,
								LanguageId = item.LanguageId
							})));
						}
						list10.Add(new CommonMultiLanguageViewModel
						{
							Value = item3.Value,
							LanguageId = result2
						});
						foreach (CommonMultiLanguageViewModel item5 in list10)
						{
							IdKeyValueItemViewModel idval2 = new IdKeyValueItemViewModel();
							string key = item3.TypeInWeb ?? "";
							if (item5.LanguageId == result2)
							{
								idval2.Id = item3.FormId + "_" + item3.FieldId;
								idval2.Key = key;
								idval2.Value = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
								list6.Add(idval2);
							}
							else
							{
								idval2.Id = item3.FormId + "_" + item3.FieldId;
								idval2.Key = "hidden";
								idval2.Value = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
								if (Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list7, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == idval2.Id)) == null)
								{
									list7.Add(idval2);
								}
							}
						}
					}
					if (Enumerable.Any<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list8))
					{
						foreach (CRMspDySelectFormFieldsByParentFormId_Result fld in list2)
						{
							if ((fld.ParentFieldId == 0 && !fld.FieldTypeId.HasValue) || !fld.IsActive.GetValueOrDefault() || Enumerable.FirstOrDefault<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list8, (Func<CRMspDySelectFormFieldValuesByMasterValueId_Result, bool>)((CRMspDySelectFormFieldValuesByMasterValueId_Result m) => m.FormId == fld.FormId && m.FieldId == fld.FormFieldId)) != null)
							{
								continue;
							}
							List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Languages, CommonMultiLanguageViewModel>((IEnumerable<Languages>)Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()), (Func<Languages, CommonMultiLanguageViewModel>)((Languages lang) => new CommonMultiLanguageViewModel
							{
								Value = "",
								LanguageId = lang.LanguageID
							})));
							foreach (CommonMultiLanguageViewModel item6 in list11)
							{
								IdKeyValueItemViewModel idval = new IdKeyValueItemViewModel();
								string key2 = fld.TypeInWeb ?? "";
								if (item6.LanguageId == result2)
								{
									idval.Id = fld.FormId + "_" + fld.FormFieldId;
									idval.Key = key2;
									idval.Value = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
									list6.Add(idval);
								}
								else
								{
									idval.Id = fld.FormId + "_" + fld.FormFieldId;
									idval.Key = "hidden";
									idval.Value = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
									if (Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list7, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == idval.Id)) == null)
									{
										list7.Add(idval);
									}
								}
							}
						}
					}
				}
				text = JsonConvert.SerializeObject(Enumerable.ToList<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list6));
				text2 = JsonConvert.SerializeObject(Enumerable.ToList<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list7));
				list3 = Enumerable.ToList<CRMspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<CRMspDySelectFormWorkflowStepsForMasterValue_Result>)_db.CRMspDySelectFormWorkflowStepsForMasterValue(result, mValId, currLangID, result2, result3));
				foreach (CRMspDySelectFormWorkflowStepsForMasterValue_Result item7 in list3)
				{
					item7.FirstRegisterDatePersian = (item7.FirstRegisterDate.HasValue ? item7.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					item7.RegisterDatePersian = (item7.RegisterDate.HasValue ? item7.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					if (string.IsNullOrEmpty(item7.AppType))
					{
						item7.AppType = Configuration.AppType;
					}
					item7.AppType = Configuration.GetAppType(item7.AppType);
					item7.CheckedDatePersian = (item7.CheckedDate.HasValue ? item7.CheckedDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					item7.FirstRegisterUser = item7.FirstRegisterUser ?? "";
					item7.EditUser = item7.EditUser + " (" + item7.AppType + ") " + item7.RegisterDatePersian;
					item7.CheckerUser = item7.CheckerUser ?? "";
					item7.IsChecked = item7.IsChecked.HasValue && item7.IsChecked != false;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			base.ViewBag.Forms = list;
			base.ViewBag.FormFields = list2;
			base.ViewBag.PartTitle = partTitle;
			base.ViewBag.ValueDetails = text;
			base.ViewBag.ValueDetails_Lang = text2;
			base.ViewBag.WorkflowSteps = list3;
			base.ViewBag.WorkflowId = result;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetMasterValueAndInfo(int formId, int? mValId = null, string partTitle = "", int position = 1, int? cmpId = null, int? prsId = null, int? prjId = null, int? cnvsId = null, int? mObjId = null, int? dObjId = null, int? subObjId = null, string sysPartDyFormVal = "", bool loadValBySysPart = false, int tempDataId = 0, bool fromOtherPartSys = false)
	{
		//IL_202a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2064: Unknown result type (might be due to invalid IL or missing references)
		//IL_2085: Unknown result type (might be due to invalid IL or missing references)
		//IL_246f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1009: Unknown result type (might be due to invalid IL or missing references)
		//IL_168d: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentMasterValueViewModel currentMasterValueViewModel = new CurrentMasterValueViewModel();
		currentMasterValueViewModel.Forms = new List<CRMspDySelectFormAndSubForms_Result>();
		currentMasterValueViewModel.MainForm = new CRMspDySelectFormAndSubForms_Result();
		currentMasterValueViewModel.FormFields = new List<CRMspDySelectFormFieldsByParentFormId_Result>();
		currentMasterValueViewModel.WorkflowSteps = new List<CRMspDySelectFormWorkflowStepsForMasterValue_Result>();
		currentMasterValueViewModel.MainFormFiles = new List<CrmFilesDirectoryViewModel>();
		currentMasterValueViewModel.FormFiles = new List<CrmFilesDirectoryViewModel>();
		currentMasterValueViewModel.MainFormDetails = new CRMspDySelectFormFieldMasterValueDetails_Result();
		currentMasterValueViewModel.LastVerificationStep = new WSspSelectVerificationWorkFlowStepLast_Result();
		currentMasterValueViewModel.SysDBObjects = new List<CRMspSelectSysDBObjectsByIds_Result>();
		string text = "";
		currentMasterValueViewModel.FieldValueChangeHistoryList = new List<FieldValueChangeHistoryViewModel>();
		currentMasterValueViewModel.FormName = "";
		currentMasterValueViewModel.PartTitle = partTitle;
		currentMasterValueViewModel.ValueDetails = "";
		currentMasterValueViewModel.ValueDetails_Lang = "";
		currentMasterValueViewModel.WorkflowId = 0;
		int result2 = 0;
		string formName = "";
		currentMasterValueViewModel.LastInsertedWorkflowStepId = 0;
		currentMasterValueViewModel.SystemPartInfo = "";
		currentMasterValueViewModel.SysPart_ValueDetails = "";
		currentMasterValueViewModel.SysPart_ValueDetails_Lang = "";
		try
		{
			BaseInfo baseInfo = new BaseInfo();
			int userId = UserLogin.CurrentUser.UserId;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspDySelectFormAndSubForms_Result> list = Enumerable.ToList<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)_dbI.CRMspDySelectFormAndSubForms(formId, userId, currLangID, result, result3));
			if (list != null && Enumerable.Any<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list))
			{
				CRMspDySelectFormAndSubForms_Result cRMspDySelectFormAndSubForms_Result = Enumerable.FirstOrDefault<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list, (Func<CRMspDySelectFormAndSubForms_Result, bool>)((CRMspDySelectFormAndSubForms_Result m) => m.ParentFormId == 0));
				if (cRMspDySelectFormAndSubForms_Result != null)
				{
					int.TryParse(cRMspDySelectFormAndSubForms_Result.WorkflowId.ToString(), out result2);
					formName = ((!string.IsNullOrEmpty(cRMspDySelectFormAndSubForms_Result.FormName)) ? cRMspDySelectFormAndSubForms_Result.FormName : "");
				}
				currentMasterValueViewModel.MainForm = cRMspDySelectFormAndSubForms_Result;
				currentMasterValueViewModel.Forms.AddRange(list);
				if (Enumerable.Any<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)currentMasterValueViewModel.Forms))
				{
					foreach (CRMspDySelectFormAndSubForms_Result form in currentMasterValueViewModel.Forms)
					{
						form.FormTitleColor = baseInfo.DelphiCToRgbolor(form.FormTitleColor);
						form.FormBgColor = baseInfo.DelphiCToRgbolor(form.FormBgColor);
					}
				}
				List<CRMspDySelectFormFieldsByParentFormId_Result> list2 = Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)_dbI.CRMspDySelectFormFieldsByParentFormId(formId, currLangID, result));
				if (list2 != null && Enumerable.Any<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list2))
				{
					foreach (CRMspDySelectFormFieldsByParentFormId_Result item in list2)
					{
						item.ParentFieldColor = baseInfo.DelphiCToRgbolor(item.ParentFieldColor);
						item.ParentFieldBgColor = baseInfo.DelphiCToRgbolor(item.ParentFieldBgColor);
						int result4 = 0;
						int.TryParse(item.LinkDbObjectId.ToString(), out result4);
						if (result4 != 0)
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += ",";
							}
							text += result4;
						}
					}
				}
				currentMasterValueViewModel.FormFields.AddRange(list2);
			}
			currentMasterValueViewModel.WorkflowId = result2;
			currentMasterValueViewModel.FormName = formName;
			if (!string.IsNullOrWhiteSpace(text))
			{
				currentMasterValueViewModel.SysDBObjects = Enumerable.ToList<CRMspSelectSysDBObjectsByIds_Result>((IEnumerable<CRMspSelectSysDBObjectsByIds_Result>)_dbII.CRMspSelectSysDBObjectsByIds(text, ",", currLangID, result));
				if (currentMasterValueViewModel.SysDBObjects == null)
				{
					currentMasterValueViewModel.SysDBObjects = new List<CRMspSelectSysDBObjectsByIds_Result>();
				}
			}
			currentMasterValueViewModel.MainFormDetails = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueDetails_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetails_Result>)_dbI.CRMspDySelectFormFieldMasterValueDetails(formId, cmpId, prsId, prjId, cnvsId, mObjId, dObjId, subObjId, currLangID, result));
			if (currentMasterValueViewModel.MainFormDetails != null)
			{
				currentMasterValueViewModel.MainFormDetails.cnvsDate = (currentMasterValueViewModel.MainFormDetails.cnvsDateTime.HasValue ? currentMasterValueViewModel.MainFormDetails.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
				currentMasterValueViewModel.MainFormDetails.cnvsDesc = "(" + currentMasterValueViewModel.MainFormDetails.ConversationId + " - " + currentMasterValueViewModel.MainFormDetails.cnvsTopic + " - " + currentMasterValueViewModel.MainFormDetails.cnvsDate + ")";
				currentMasterValueViewModel.MainFormDetails.MasterObjectDate = (currentMasterValueViewModel.MainFormDetails.MasterObjectDateTime.HasValue ? currentMasterValueViewModel.MainFormDetails.MasterObjectDateTime.Value.ToString("yyyy/MM/dd") : "");
				if (!string.IsNullOrEmpty(currentMasterValueViewModel.MainFormDetails.MasterObjectDate))
				{
					currentMasterValueViewModel.MainFormDetails.MasterObjectInfo = "(" + currentMasterValueViewModel.MainFormDetails.MasterObjectInfo + " - " + currentMasterValueViewModel.MainFormDetails.MasterObjectDate + ")";
				}
				else
				{
					currentMasterValueViewModel.MainFormDetails.MasterObjectInfo = currentMasterValueViewModel.MainFormDetails.MasterObjectInfo ?? "";
				}
			}
			else
			{
				currentMasterValueViewModel.MainFormDetails = new CRMspDySelectFormFieldMasterValueDetails_Result();
			}
			if (tempDataId != 0)
			{
				CRMspSelectSysTempData_Result cRMspSelectSysTempData_Result = SysTempData.Select(tempDataId, 0, 0, 0, 0, 0);
				if (cRMspSelectSysTempData_Result != null)
				{
					sysPartDyFormVal = cRMspSelectSysTempData_Result.TempDataValue ?? "";
				}
			}
			if (formId != 0 && tempDataId == 0)
			{
				try
				{
					int userId2 = UserLogin.CurrentUser.UserId;
					_dbI.CRMspDeleteFilesDirectoryTemplateByTypeAndUserAndObjs(3, userId2, null, formId, null);
					string text2 = Configuration.HostTempFilesPath + "/" + Configuration.DyFormFileTmpDirectoryPath + userId2 + "/" + formId + "/";
					string path = base.Server.MapPath(text2);
					if (System.IO.Directory.Exists(path))
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(path);
						FileInfo[] files = directoryInfo.GetFiles();
						for (int i = 0; i < files.Length; i++)
						{
							files[i].Delete();
						}
						DirectoryInfo[] directories = directoryInfo.GetDirectories();
						for (int i = 0; i < directories.Length; i++)
						{
							directories[i].Delete(recursive: true);
						}
						System.IO.Directory.Delete(path);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			List<mct_CRMspDySelectFormFieldMasterValues_Result> list3 = Enumerable.ToList<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)_db.mfi_CRMspDySelectFormFieldMasterValues(formId, (cmpId == 0) ? null : cmpId, (prsId == 0) ? null : prsId, (prjId == 0) ? null : prjId, (cnvsId == 0) ? null : cnvsId, (mObjId == 0) ? null : mObjId, (dObjId == 0) ? null : dObjId, (subObjId == 0) ? null : subObjId, currLangID, result, userId, result3));
			if (mValId.GetValueOrDefault() == 0 && Enumerable.Any<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)list3))
			{
				mct_CRMspDySelectFormFieldMasterValues_Result mct_CRMspDySelectFormFieldMasterValues_Result = Enumerable.LastOrDefault<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)list3);
				if (mct_CRMspDySelectFormFieldMasterValues_Result != null)
				{
					mValId = mct_CRMspDySelectFormFieldMasterValues_Result.FormFieldMasterValueId;
				}
			}
			currentMasterValueViewModel.WorkflowSteps = Enumerable.ToList<CRMspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<CRMspDySelectFormWorkflowStepsForMasterValue_Result>)_db.CRMspDySelectFormWorkflowStepsForMasterValue(result2, mValId, currLangID, result, result3));
			foreach (CRMspDySelectFormWorkflowStepsForMasterValue_Result workflowStep in currentMasterValueViewModel.WorkflowSteps)
			{
				workflowStep.FirstRegisterDatePersian = (workflowStep.FirstRegisterDate.HasValue ? workflowStep.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
				workflowStep.RegisterDatePersian = (workflowStep.RegisterDate.HasValue ? workflowStep.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
				if (string.IsNullOrEmpty(workflowStep.AppType))
				{
					workflowStep.AppType = Configuration.AppType;
				}
				workflowStep.AppType = Configuration.GetAppType(workflowStep.AppType);
				workflowStep.CheckedDatePersian = (workflowStep.CheckedDate.HasValue ? workflowStep.CheckedDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
				workflowStep.FirstRegisterUser = workflowStep.FirstRegisterUser ?? "";
				workflowStep.EditUser = workflowStep.EditUser + " (" + workflowStep.AppType + ") " + workflowStep.RegisterDatePersian;
				workflowStep.CheckerUser = workflowStep.CheckerUser ?? "";
				workflowStep.IsChecked = workflowStep.IsChecked.HasValue && workflowStep.IsChecked != false;
			}
			if (Enumerable.Any<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)list3))
			{
				currentMasterValueViewModel.IsFind = true;
				currentMasterValueViewModel.Message = "";
				currentMasterValueViewModel.MasterValueNextId = -1;
				currentMasterValueViewModel.MasterValuePreviousId = -1;
				currentMasterValueViewModel.MasterValueFirstId = -1;
				currentMasterValueViewModel.MasterValueLastId = -1;
				if (list3.Count == 1)
				{
					currentMasterValueViewModel.MasterValueFirstId = -1;
					currentMasterValueViewModel.MasterValueLastId = -1;
				}
				else
				{
					currentMasterValueViewModel.MasterValueFirstId = Enumerable.FirstOrDefault<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)list3).FormFieldMasterValueId.Value;
					currentMasterValueViewModel.MasterValueLastId = Enumerable.LastOrDefault<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)list3).FormFieldMasterValueId.Value;
				}
				mct_CRMspDySelectFormFieldMasterValues_Result mct_CRMspDySelectFormFieldMasterValues_Result2 = ((!(mValId > 0)) ? Enumerable.LastOrDefault<mct_CRMspDySelectFormFieldMasterValues_Result>((IEnumerable<mct_CRMspDySelectFormFieldMasterValues_Result>)list3) : list3.Find((mct_CRMspDySelectFormFieldMasterValues_Result c) => c.FormFieldMasterValueId == mValId));
				if (mct_CRMspDySelectFormFieldMasterValues_Result2 != null)
				{
					if (DyForm.IsEditAfterFix(mct_CRMspDySelectFormFieldMasterValues_Result2.EditAfterFixInfoJs, mct_CRMspDySelectFormFieldMasterValues_Result2.FormFieldMasterValueId.GetValueOrDefault(), 1))
					{
						mct_CRMspDySelectFormFieldMasterValues_Result2.IsFixed = false;
					}
					mct_CRMspDySelectFormFieldMasterValues_Result2.FirstRegisterDatePersian = (mct_CRMspDySelectFormFieldMasterValues_Result2.FirstRegisterDate.HasValue ? mct_CRMspDySelectFormFieldMasterValues_Result2.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					mct_CRMspDySelectFormFieldMasterValues_Result2.RegisterDatePersian = (mct_CRMspDySelectFormFieldMasterValues_Result2.RegisterDate.HasValue ? mct_CRMspDySelectFormFieldMasterValues_Result2.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					if (string.IsNullOrEmpty(mct_CRMspDySelectFormFieldMasterValues_Result2.AppType))
					{
						mct_CRMspDySelectFormFieldMasterValues_Result2.AppType = Configuration.AppType;
					}
					mct_CRMspDySelectFormFieldMasterValues_Result2.AppType = Configuration.GetAppType(mct_CRMspDySelectFormFieldMasterValues_Result2.AppType);
					mct_CRMspDySelectFormFieldMasterValues_Result2.CheckedDatePersian = (mct_CRMspDySelectFormFieldMasterValues_Result2.CheckedDate.HasValue ? mct_CRMspDySelectFormFieldMasterValues_Result2.CheckedDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					currentMasterValueViewModel.MasterValue = mct_CRMspDySelectFormFieldMasterValues_Result2;
					currentMasterValueViewModel.FirstRegisterUser = mct_CRMspDySelectFormFieldMasterValues_Result2.FirstRegisterUser + " " + mct_CRMspDySelectFormFieldMasterValues_Result2.FirstRegisterDatePersian;
					currentMasterValueViewModel.EditUser = mct_CRMspDySelectFormFieldMasterValues_Result2.EditUser + " (" + mct_CRMspDySelectFormFieldMasterValues_Result2.AppType + ") " + mct_CRMspDySelectFormFieldMasterValues_Result2.RegisterDatePersian;
					currentMasterValueViewModel.MasterValueCurrentId = mct_CRMspDySelectFormFieldMasterValues_Result2.FormFieldMasterValueId.Value;
					currentMasterValueViewModel.CheckerUser = mct_CRMspDySelectFormFieldMasterValues_Result2.CheckerUser + " " + mct_CRMspDySelectFormFieldMasterValues_Result2.CheckedDatePersian;
					currentMasterValueViewModel.IsChecked = mct_CRMspDySelectFormFieldMasterValues_Result2.IsChecked.HasValue && mct_CRMspDySelectFormFieldMasterValues_Result2.IsChecked != false;
					currentMasterValueViewModel.CheckerUserId = mct_CRMspDySelectFormFieldMasterValues_Result2.CheckerUserId.GetValueOrDefault();
					if (currentMasterValueViewModel.MainForm != null)
					{
						int result5 = 0;
						int.TryParse(mct_CRMspDySelectFormFieldMasterValues_Result2.CId.ToString(), out result5);
						if (result5 == 0)
						{
							result5 = result3;
						}
						int printFormatId = 0;
						DyForm.GetFormPrintFormatInCenter(currentMasterValueViewModel.MainForm.FormId, ref printFormatId, result5);
						if (printFormatId != 0)
						{
							currentMasterValueViewModel.MainForm.PrintFormatId = printFormatId;
						}
						else
						{
							currentMasterValueViewModel.MainForm.PrintFormatId = null;
						}
					}
					CRMspDySelectFormFieldMasterValueSysPartInfo_Result cRMspDySelectFormFieldMasterValueSysPartInfo_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueSysPartInfo_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueSysPartInfo_Result>)_dbII.CRMspDySelectFormFieldMasterValueSysPartInfo(mct_CRMspDySelectFormFieldMasterValues_Result2.FormFieldMasterValueId, currLangID, result));
					if (cRMspDySelectFormFieldMasterValueSysPartInfo_Result != null)
					{
						currentMasterValueViewModel.SystemPartInfo = cRMspDySelectFormFieldMasterValueSysPartInfo_Result.CompanyName ?? "";
						if (!string.IsNullOrWhiteSpace(cRMspDySelectFormFieldMasterValueSysPartInfo_Result.CompanyName))
						{
							currentMasterValueViewModel.SystemPartInfo = "<span class='span-cmpInfo-link' onmouseup='GoToCmpInfo();return false;'>" + cRMspDySelectFormFieldMasterValueSysPartInfo_Result.CompanyName + "</span>";
						}
						cRMspDySelectFormFieldMasterValueSysPartInfo_Result.ObjectInfo = cRMspDySelectFormFieldMasterValueSysPartInfo_Result.ObjectInfo ?? cRMspDySelectFormFieldMasterValueSysPartInfo_Result.ObjectPartTitle;
						if (!string.IsNullOrWhiteSpace(cRMspDySelectFormFieldMasterValueSysPartInfo_Result.ObjectInfo))
						{
							if (!string.IsNullOrWhiteSpace(currentMasterValueViewModel.SystemPartInfo))
							{
								currentMasterValueViewModel.SystemPartInfo += "<span class='span-split-link'>  / </span>";
							}
							currentMasterValueViewModel.SystemPartInfo = currentMasterValueViewModel.SystemPartInfo + "<span class='span-partInfo-link' onmouseup='GoToSysPart(1);return false;'>" + cRMspDySelectFormFieldMasterValueSysPartInfo_Result.ObjectInfo + "</span>";
						}
						if (cRMspDySelectFormFieldMasterValueSysPartInfo_Result.ObjectDate != null)
						{
							string text3 = cRMspDySelectFormFieldMasterValueSysPartInfo_Result.ObjectDateTime?.ToString("yyyy/MM/dd");
							if (!string.IsNullOrWhiteSpace(text3))
							{
								if ((cRMspDySelectFormFieldMasterValueSysPartInfo_Result.ObjectPart ?? "") == "Cnvs")
								{
									currentMasterValueViewModel.SystemPartInfo = currentMasterValueViewModel.SystemPartInfo.Replace("{0}", text3 + " - ");
								}
								else
								{
									currentMasterValueViewModel.SystemPartInfo = currentMasterValueViewModel.SystemPartInfo.Replace("{0}", " - " + text3);
								}
							}
						}
					}
					List<IdKeyValueItemViewModel> list4 = new List<IdKeyValueItemViewModel>();
					List<IdKeyValueItemViewModel> list5 = new List<IdKeyValueItemViewModel>();
					if (mct_CRMspDySelectFormFieldMasterValues_Result2.FormFieldMasterValueId > 0)
					{
						List<CRMspDySelectFormFieldValuesByMasterValueId_Result> list6 = Enumerable.ToList<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)_dbI.CRMspDySelectFormFieldValuesByMasterValueId(mct_CRMspDySelectFormFieldMasterValues_Result2.FormFieldMasterValueId, currLangID, result));
						foreach (CRMspDySelectFormFieldValuesByMasterValueId_Result item2 in list6)
						{
							List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
							if (!string.IsNullOrWhiteSpace(item2.Value_Lang))
							{
								List<CommonMultiLanguageViewModel> collection = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item2.Value_Lang);
								list7.AddRange(collection);
								if (list7 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7) && item2.FieldTypeId.GetValueOrDefault() == 4)
								{
									foreach (CommonMultiLanguageViewModel item3 in list7)
									{
										if (string.IsNullOrEmpty(item3.Value))
										{
											continue;
										}
										DateTime dateTime = default(DateTime);
										item3.Value = item3.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
											.Replace(" ", "")
											.Replace("_", "");
										if (currLangID == 1065)
										{
											item3.Value = DateTime.Parse(PersianDate.GetFormatetdDate(item3.Value) + " 00:00:00", new PersianCulture()).ToString("yyyy/MM/dd", new PersianCulture());
											continue;
										}
										dateTime = DateTime.Parse(PersianDate.GetShamsi2Miladi(item3.Value.Replace("/", "")));
										if (currLangID == 1025)
										{
											item3.Value = dateTime.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
										}
										else
										{
											item3.Value = dateTime.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
										}
									}
								}
							}
							if (item2.FieldTypeId.GetValueOrDefault() == 4 && !string.IsNullOrEmpty(item2.Value))
							{
								DateTime dateTime2 = default(DateTime);
								item2.Value = item2.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
									.Replace(" ", "")
									.Replace("_", "");
								if (currLangID == 1065)
								{
									item2.Value = DateTime.Parse(PersianDate.GetFormatetdDate(item2.Value) + " 00:00:00", new PersianCulture()).ToString("yyyy/MM/dd", new PersianCulture());
								}
								else
								{
									dateTime2 = DateTime.Parse(PersianDate.GetShamsi2Miladi(item2.Value.Replace("/", "")));
									if (currLangID == 1025)
									{
										item2.Value = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
									}
									else
									{
										item2.Value = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
									}
								}
							}
							bool value = false;
							if (fromOtherPartSys && tempDataId == 0 && item2.FieldTypeId.GetValueOrDefault() == 12 && !string.IsNullOrWhiteSpace(item2.Value))
							{
								value = true;
							}
							List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
							if (list7 != null && list7.Count > 0)
							{
								list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CommonMultiLanguageViewModel, CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, CommonMultiLanguageViewModel>)((CommonMultiLanguageViewModel item) => new CommonMultiLanguageViewModel
								{
									Value = item.Value.Replace("''", "'"),
									LanguageId = item.LanguageId
								})));
							}
							list8.Add(new CommonMultiLanguageViewModel
							{
								Value = item2.Value.Replace("''", "'"),
								LanguageId = currLangID
							});
							if (item2.FieldTypeId.GetValueOrDefault() == 13 && !string.IsNullOrWhiteSpace(item2.Value))
							{
								byte[] inArray = BaseInfo.HexToByteArray(item2.Value);
								item2.ValueTitle = System.Convert.ToBase64String(inArray);
							}
							foreach (CommonMultiLanguageViewModel item4 in list8)
							{
								IdKeyValueItemViewModel idval3 = new IdKeyValueItemViewModel();
								string text4 = item2.FormId + "_" + item2.FieldId;
								long result6 = 0L;
								long.TryParse(item2.FieldRepeatId.ToString(), out result6);
								if (result6 != 0L)
								{
									text4 = text4 + "_" + result6;
								}
								string key = item2.TypeInWeb ?? "";
								string valueTitle = item2.ValueTitle ?? "";
								if (item4.LanguageId == result)
								{
									idval3.Id = text4;
									idval3.Key = key;
									idval3.ValueTitle = valueTitle;
									idval3.Value = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
									idval3.ParentFieldId = item2.ParentFieldId.GetValueOrDefault();
									idval3.FormId = item2.FormId;
									idval3.IsMainFileField = value;
									list4.Add(idval3);
									list5.Add(new IdKeyValueItemViewModel());
								}
								else
								{
									idval3.Id = text4;
									idval3.Key = "hidden";
									idval3.ValueTitle = valueTitle;
									idval3.ParentFieldId = item2.ParentFieldId.GetValueOrDefault();
									idval3.FormId = item2.FormId;
									idval3.Value = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
									if (Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list5, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == idval3.Id)) == null)
									{
										list5.Add(idval3);
									}
								}
							}
							if (string.IsNullOrWhiteSpace(item2.ChangeHistory))
							{
								continue;
							}
							List<FieldValueChangeHistoryViewModel> list9 = new JavaScriptSerializer().Deserialize<List<FieldValueChangeHistoryViewModel>>(item2.ChangeHistory);
							if (list9 == null || !Enumerable.Any<FieldValueChangeHistoryViewModel>((IEnumerable<FieldValueChangeHistoryViewModel>)list9))
							{
								continue;
							}
							foreach (FieldValueChangeHistoryViewModel item5 in list9)
							{
								item5.TDateStr = (item5.TDate.HasValue ? item5.TDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
							}
							currentMasterValueViewModel.FieldValueChangeHistoryList.AddRange(list9);
						}
						if (Enumerable.Any<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list6))
						{
							foreach (CRMspDySelectFormFieldsByParentFormId_Result fld in currentMasterValueViewModel.FormFields)
							{
								if ((fld.ParentFieldId == 0 && !fld.FieldTypeId.HasValue) || !fld.IsActive.GetValueOrDefault() || Enumerable.FirstOrDefault<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list6, (Func<CRMspDySelectFormFieldValuesByMasterValueId_Result, bool>)((CRMspDySelectFormFieldValuesByMasterValueId_Result m) => m.FormId == fld.FormId && m.FieldId == fld.FormFieldId)) != null)
								{
									continue;
								}
								List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Languages, CommonMultiLanguageViewModel>((IEnumerable<Languages>)Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()), (Func<Languages, CommonMultiLanguageViewModel>)((Languages lang) => new CommonMultiLanguageViewModel
								{
									Value = "",
									LanguageId = lang.LanguageID
								})));
								foreach (CommonMultiLanguageViewModel item6 in list10)
								{
									IdKeyValueItemViewModel idval2 = new IdKeyValueItemViewModel();
									string key2 = fld.TypeInWeb ?? "";
									string valueTitle2 = "";
									idval2.ParentFieldId = fld.ParentFieldId.GetValueOrDefault();
									idval2.FormId = fld.FormId;
									if (item6.LanguageId == result)
									{
										idval2.Id = fld.FormId + "_" + fld.FormFieldId;
										idval2.Key = key2;
										idval2.ValueTitle = valueTitle2;
										idval2.Value = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
										list4.Add(idval2);
										continue;
									}
									idval2.Id = fld.FormId + "_" + fld.FormFieldId;
									idval2.Key = "hidden";
									idval2.ValueTitle = valueTitle2;
									idval2.ParentFieldId = fld.ParentFieldId.GetValueOrDefault();
									idval2.FormId = fld.FormId;
									idval2.Value = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
									if (Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list5, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == idval2.Id)) == null)
									{
										list5.Add(idval2);
									}
								}
							}
						}
					}
					currentMasterValueViewModel.ValueDetails = JsonConvert.SerializeObject(Enumerable.ToList<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list4));
					currentMasterValueViewModel.ValueDetails_Lang = JsonConvert.SerializeObject(Enumerable.ToList<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list5));
					if (mct_CRMspDySelectFormFieldMasterValues_Result2.FormFieldMasterValueId > 0)
					{
						List<CrmFilesDirectoryViewModel> filesList = GetFilesList(0, mct_CRMspDySelectFormFieldMasterValues_Result2.FormFieldMasterValueId.GetValueOrDefault(), cmpId, prsId, prjId);
						if (filesList != null && Enumerable.Any<CrmFilesDirectoryViewModel>((IEnumerable<CrmFilesDirectoryViewModel>)filesList))
						{
							currentMasterValueViewModel.MainFormFiles = Enumerable.ToList<CrmFilesDirectoryViewModel>(Enumerable.Where<CrmFilesDirectoryViewModel>((IEnumerable<CrmFilesDirectoryViewModel>)filesList, (Func<CrmFilesDirectoryViewModel, bool>)((CrmFilesDirectoryViewModel m) => m.TypeOprObjectIdI == formId)));
							if (currentMasterValueViewModel.MainFormFiles == null || !Enumerable.Any<CrmFilesDirectoryViewModel>((IEnumerable<CrmFilesDirectoryViewModel>)currentMasterValueViewModel.MainFormFiles))
							{
								currentMasterValueViewModel.MainFormFiles = new List<CrmFilesDirectoryViewModel>();
							}
							currentMasterValueViewModel.FormFiles = Enumerable.ToList<CrmFilesDirectoryViewModel>(Enumerable.Where<CrmFilesDirectoryViewModel>((IEnumerable<CrmFilesDirectoryViewModel>)filesList, (Func<CrmFilesDirectoryViewModel, bool>)((CrmFilesDirectoryViewModel m) => m.TypeOprObjectIdI != formId)));
							if (currentMasterValueViewModel.FormFiles == null || !Enumerable.Any<CrmFilesDirectoryViewModel>((IEnumerable<CrmFilesDirectoryViewModel>)currentMasterValueViewModel.FormFiles))
							{
								currentMasterValueViewModel.FormFiles = new List<CrmFilesDirectoryViewModel>();
							}
						}
					}
					currentMasterValueViewModel.MainFormDetails = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueDetails_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetails_Result>)_dbI.CRMspDySelectFormFieldMasterValueDetails(formId, mct_CRMspDySelectFormFieldMasterValues_Result2.CompanyId.GetValueOrDefault(), mct_CRMspDySelectFormFieldMasterValues_Result2.CompanyPersonId.GetValueOrDefault(), mct_CRMspDySelectFormFieldMasterValues_Result2.ProjectId.GetValueOrDefault(), mct_CRMspDySelectFormFieldMasterValues_Result2.ConversationId.GetValueOrDefault(), mct_CRMspDySelectFormFieldMasterValues_Result2.MasterObjectId.GetValueOrDefault(), mct_CRMspDySelectFormFieldMasterValues_Result2.DetailObjectId.GetValueOrDefault(), mct_CRMspDySelectFormFieldMasterValues_Result2.SubDetailObjectId.GetValueOrDefault(), currLangID, result));
					if (currentMasterValueViewModel.MainFormDetails != null)
					{
						currentMasterValueViewModel.MainFormDetails.cnvsDate = (currentMasterValueViewModel.MainFormDetails.cnvsDateTime.HasValue ? currentMasterValueViewModel.MainFormDetails.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
						currentMasterValueViewModel.MainFormDetails.cnvsDesc = "(" + currentMasterValueViewModel.MainFormDetails.ConversationId + " - " + currentMasterValueViewModel.MainFormDetails.cnvsTopic + " - " + currentMasterValueViewModel.MainFormDetails.cnvsDate + ")";
						currentMasterValueViewModel.MainFormDetails.MasterObjectDate = (currentMasterValueViewModel.MainFormDetails.MasterObjectDateTime.HasValue ? currentMasterValueViewModel.MainFormDetails.MasterObjectDateTime.Value.ToString("yyyy/MM/dd") : "");
						if (!string.IsNullOrEmpty(currentMasterValueViewModel.MainFormDetails.MasterObjectDate))
						{
							currentMasterValueViewModel.MainFormDetails.MasterObjectInfo = "(" + currentMasterValueViewModel.MainFormDetails.MasterObjectInfo + " - " + currentMasterValueViewModel.MainFormDetails.MasterObjectDate + ")";
						}
						else
						{
							currentMasterValueViewModel.MainFormDetails.MasterObjectInfo = currentMasterValueViewModel.MainFormDetails.MasterObjectInfo ?? "";
						}
					}
					else
					{
						currentMasterValueViewModel.MainFormDetails = new CRMspDySelectFormFieldMasterValueDetails_Result();
					}
					if (mct_CRMspDySelectFormFieldMasterValues_Result2.VerificationWorkFlowId.HasValue)
					{
						currentMasterValueViewModel.LastVerificationStep = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowStepLast_Result>((IEnumerable<WSspSelectVerificationWorkFlowStepLast_Result>)_db.WSspSelectVerificationWorkFlowStepLast(mct_CRMspDySelectFormFieldMasterValues_Result2.FormFieldMasterValueId, 80, mct_CRMspDySelectFormFieldMasterValues_Result2.VerificationWorkFlowId, 0, currLangID, result));
					}
					List<CRMspDySelectFormFieldMasterValueDetailsByMasterValueId_Result> list11 = Enumerable.ToList<CRMspDySelectFormFieldMasterValueDetailsByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetailsByMasterValueId_Result>)_dbII.CRMspDySelectFormFieldMasterValueDetailsByMasterValueId(mct_CRMspDySelectFormFieldMasterValues_Result2.FormFieldMasterValueId, currLangID, result));
					if (list11 != null && Enumerable.Any<CRMspDySelectFormFieldMasterValueDetailsByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetailsByMasterValueId_Result>)list11))
					{
						CRMspDySelectFormFieldMasterValueDetailsByMasterValueId_Result cRMspDySelectFormFieldMasterValueDetailsByMasterValueId_Result = Enumerable.LastOrDefault<CRMspDySelectFormFieldMasterValueDetailsByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetailsByMasterValueId_Result>)list11);
						if (cRMspDySelectFormFieldMasterValueDetailsByMasterValueId_Result != null)
						{
							currentMasterValueViewModel.LastInsertedWorkflowStepId = cRMspDySelectFormFieldMasterValueDetailsByMasterValueId_Result.FormWorkflowStepId.GetValueOrDefault();
						}
					}
					if (list3.Count == 1)
					{
						currentMasterValueViewModel.MasterValueNextId = -1;
						currentMasterValueViewModel.MasterValuePreviousId = -1;
					}
					else
					{
						mct_CRMspDySelectFormFieldMasterValues_Result next = Lists.GetNext(list3, mct_CRMspDySelectFormFieldMasterValues_Result2);
						if (next != null)
						{
							currentMasterValueViewModel.MasterValueNextId = next.FormFieldMasterValueId.Value;
						}
						mct_CRMspDySelectFormFieldMasterValues_Result previous = Lists.GetPrevious(list3, mct_CRMspDySelectFormFieldMasterValues_Result2);
						if (previous != null)
						{
							currentMasterValueViewModel.MasterValuePreviousId = previous.FormFieldMasterValueId.Value;
						}
					}
				}
				else
				{
					currentMasterValueViewModel.IsFind = false;
					currentMasterValueViewModel.Message = Messages.ErrorNotFound;
					currentMasterValueViewModel.MasterValueNextId = -1;
					currentMasterValueViewModel.MasterValuePreviousId = -1;
					currentMasterValueViewModel.MasterValueFirstId = -1;
					currentMasterValueViewModel.MasterValueLastId = -1;
					currentMasterValueViewModel.FirstRegisterUser = "";
					currentMasterValueViewModel.EditUser = "";
					currentMasterValueViewModel.MasterValueCurrentId = -1;
				}
			}
			else
			{
				currentMasterValueViewModel.IsFind = false;
				currentMasterValueViewModel.Message = Messages.ErrorNotFound;
				currentMasterValueViewModel.IsFind = false;
				currentMasterValueViewModel.Message = Messages.ErrorNotFound;
				currentMasterValueViewModel.MasterValueNextId = -1;
				currentMasterValueViewModel.MasterValuePreviousId = -1;
				currentMasterValueViewModel.MasterValueFirstId = -1;
				currentMasterValueViewModel.MasterValueLastId = -1;
				currentMasterValueViewModel.FirstRegisterUser = "";
				currentMasterValueViewModel.EditUser = "";
				currentMasterValueViewModel.MasterValueCurrentId = -1;
			}
			if (loadValBySysPart)
			{
				int masterValueCurrentId = 0;
				List<IdKeyValueItemViewModel> list12 = new List<IdKeyValueItemViewModel>();
				List<IdKeyValueItemViewModel> list13 = new List<IdKeyValueItemViewModel>();
				if (loadValBySysPart && currentMasterValueViewModel.FormFields != null)
				{
					if (!string.IsNullOrWhiteSpace(sysPartDyFormVal) && Enumerable.Any<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)currentMasterValueViewModel.FormFields))
					{
						CrmDyFormFieldValuesLanguageViewModel crmDyFormFieldValuesLanguageViewModel = new JavaScriptSerializer().Deserialize<CrmDyFormFieldValuesLanguageViewModel>(sysPartDyFormVal);
						if (crmDyFormFieldValuesLanguageViewModel != null)
						{
							masterValueCurrentId = crmDyFormFieldValuesLanguageViewModel.MasterValueId;
							List<IdKeyValueItemViewModel> list14 = new List<IdKeyValueItemViewModel>();
							List<IdKeyValueItemViewModel> list15 = new List<IdKeyValueItemViewModel>();
							if (!string.IsNullOrWhiteSpace(crmDyFormFieldValuesLanguageViewModel.ValueDetails))
							{
								list14 = new JavaScriptSerializer().Deserialize<List<IdKeyValueItemViewModel>>(crmDyFormFieldValuesLanguageViewModel.ValueDetails);
							}
							if (!string.IsNullOrWhiteSpace(crmDyFormFieldValuesLanguageViewModel.ValueDetails_Lang))
							{
								list15 = new JavaScriptSerializer().Deserialize<List<IdKeyValueItemViewModel>>(crmDyFormFieldValuesLanguageViewModel.ValueDetails_Lang);
							}
							foreach (IdKeyValueItemViewModel item7 in list14)
							{
								string syspart_ids = item7.Id ?? "";
								int syspart_fieldId = 0;
								if (syspart_ids != "")
								{
									syspart_ids = syspart_ids.Replace("_Rep", "");
									string[] array = syspart_ids.Split(new char[1] { '_' });
									if (array != null)
									{
										int.Parse(array[0]);
										syspart_fieldId = int.Parse(array[1]);
										if (array.Length > 2)
										{
											long.Parse(array[2]);
										}
									}
								}
								CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)currentMasterValueViewModel.FormFields, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == syspart_fieldId));
								if (cRMspDySelectFormFieldsByParentFormId_Result == null)
								{
									continue;
								}
								if (!string.IsNullOrEmpty(item7.Value) && cRMspDySelectFormFieldsByParentFormId_Result.FieldTypeId.GetValueOrDefault() == 4)
								{
									item7.Value = item7.Value.Replace("$*", "/");
								}
								else if (cRMspDySelectFormFieldsByParentFormId_Result.FieldTypeId.GetValueOrDefault() == 9)
								{
									if (!string.IsNullOrWhiteSpace(item7.Value))
									{
										int result7 = 0;
										int.TryParse(item7.Value, out result7);
										if (result7 != 0)
										{
											CRMspSelectCompanyById_Result cRMspSelectCompanyById_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyById_Result>((IEnumerable<CRMspSelectCompanyById_Result>)_db.CRMspSelectCompanyById(result7, currLangID, result, result3));
											if (cRMspSelectCompanyById_Result != null)
											{
												item7.ValueTitle = cRMspSelectCompanyById_Result.CompanyName ?? "";
											}
										}
									}
								}
								else if (cRMspDySelectFormFieldsByParentFormId_Result.FieldTypeId.GetValueOrDefault() == 10)
								{
									if (!string.IsNullOrWhiteSpace(item7.Value))
									{
										int result8 = 0;
										int.TryParse(item7.Value, out result8);
										if (result8 != 0)
										{
											WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(result8, currLangID, result));
											if (wSspSelectProductsWithId_Result != null)
											{
												item7.ValueTitle = wSspSelectProductsWithId_Result.PrdName + " (" + wSspSelectProductsWithId_Result.PrdCode + ")";
											}
										}
									}
								}
								else if (cRMspDySelectFormFieldsByParentFormId_Result.FieldTypeId.GetValueOrDefault() == 11)
								{
									if (!string.IsNullOrWhiteSpace(item7.Value))
									{
										int result9 = 0;
										int.TryParse(item7.Value, out result9);
										if (result9 != 0)
										{
											CRMspSelectUsersById_Result cRMspSelectUsersById_Result = Enumerable.FirstOrDefault<CRMspSelectUsersById_Result>((IEnumerable<CRMspSelectUsersById_Result>)_db.CRMspSelectUsersById(result9, currLangID, result, result3));
											if (cRMspSelectUsersById_Result != null)
											{
												item7.ValueTitle = cRMspSelectUsersById_Result.FullName ?? "";
											}
										}
									}
								}
								else if (cRMspDySelectFormFieldsByParentFormId_Result.FieldTypeId.GetValueOrDefault() == 12)
								{
									if (!string.IsNullOrWhiteSpace(item7.Value))
									{
										int result10 = 0;
										int.TryParse(item7.Value, out result10);
										if (result10 != 0)
										{
											CRMspSelectFilesDirectoryTemplateById_Result cRMspSelectFilesDirectoryTemplateById_Result = Enumerable.FirstOrDefault<CRMspSelectFilesDirectoryTemplateById_Result>((IEnumerable<CRMspSelectFilesDirectoryTemplateById_Result>)_dbI.CRMspSelectFilesDirectoryTemplateById(result10));
											if (cRMspSelectFilesDirectoryTemplateById_Result != null)
											{
												item7.ValueTitle = cRMspSelectFilesDirectoryTemplateById_Result.Title ?? "";
											}
										}
									}
								}
								else if (cRMspDySelectFormFieldsByParentFormId_Result.FieldTypeId.GetValueOrDefault() == 13 && !string.IsNullOrWhiteSpace(item7.Value))
								{
									byte[] inArray2 = BaseInfo.HexToByteArray(item7.Value);
									item7.ValueTitle = System.Convert.ToBase64String(inArray2);
								}
								List<CommonMultiLanguageViewModel> list16 = new List<CommonMultiLanguageViewModel>();
								string text5 = "";
								if (list15 != null && Enumerable.Any<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list15))
								{
									IdKeyValueItemViewModel idKeyValueItemViewModel = Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list15, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == syspart_ids));
									if (idKeyValueItemViewModel != null)
									{
										text5 = idKeyValueItemViewModel.Value ?? "";
									}
								}
								if (!string.IsNullOrWhiteSpace(text5))
								{
									List<CommonMultiLanguageViewModel> collection2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(text5);
									list16.AddRange(collection2);
								}
								List<CommonMultiLanguageViewModel> list17 = new List<CommonMultiLanguageViewModel>();
								if (list16 != null && list16.Count > 0)
								{
									list17 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CommonMultiLanguageViewModel, CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, CommonMultiLanguageViewModel>)((CommonMultiLanguageViewModel item) => new CommonMultiLanguageViewModel
									{
										Value = item.Value.Replace("''", "'"),
										LanguageId = item.LanguageId
									})));
								}
								list17.Add(new CommonMultiLanguageViewModel
								{
									Value = item7.Value.Replace("''", "'"),
									LanguageId = currLangID
								});
								foreach (CommonMultiLanguageViewModel item8 in list17)
								{
									IdKeyValueItemViewModel idval = new IdKeyValueItemViewModel();
									string id = syspart_ids;
									string key3 = cRMspDySelectFormFieldsByParentFormId_Result.TypeInWeb ?? "";
									string valueTitle3 = item7.ValueTitle ?? "";
									if (item8.LanguageId == result)
									{
										idval.Id = id;
										idval.Key = key3;
										idval.ValueTitle = valueTitle3;
										idval.Value = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
										idval.ParentFieldId = cRMspDySelectFormFieldsByParentFormId_Result.ParentFieldId.GetValueOrDefault();
										idval.FormId = cRMspDySelectFormFieldsByParentFormId_Result.FormId;
										list12.Add(idval);
										list13.Add(new IdKeyValueItemViewModel());
									}
									else
									{
										idval.Id = id;
										idval.Key = "hidden";
										idval.ValueTitle = valueTitle3;
										idval.ParentFieldId = cRMspDySelectFormFieldsByParentFormId_Result.ParentFieldId.GetValueOrDefault();
										idval.FormId = cRMspDySelectFormFieldsByParentFormId_Result.FormId;
										idval.Value = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
										if (Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list13, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == idval.Id)) == null)
										{
											list13.Add(idval);
										}
									}
								}
							}
						}
					}
					currentMasterValueViewModel.SysPart_ValueDetails = JsonConvert.SerializeObject(Enumerable.ToList<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list12));
					if (list13 != null)
					{
						if (Enumerable.Any<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list13))
						{
							list13 = Enumerable.ToList<IdKeyValueItemViewModel>(Enumerable.Where<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list13, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => (m.Id ?? "") != "")));
						}
						if (list13 == null)
						{
							list13 = new List<IdKeyValueItemViewModel>();
						}
					}
					currentMasterValueViewModel.SysPart_ValueDetails_Lang = JsonConvert.SerializeObject(Enumerable.ToList<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list13));
					if (fromOtherPartSys && tempDataId == 0)
					{
						currentMasterValueViewModel.SysPart_ValueDetails = currentMasterValueViewModel.ValueDetails;
						currentMasterValueViewModel.SysPart_ValueDetails_Lang = currentMasterValueViewModel.ValueDetails_Lang;
						masterValueCurrentId = currentMasterValueViewModel.MasterValueCurrentId;
					}
					currentMasterValueViewModel.ValueDetails = "";
					currentMasterValueViewModel.ValueDetails_Lang = "";
					currentMasterValueViewModel.IsFind = false;
					currentMasterValueViewModel.MasterValueNextId = -1;
					currentMasterValueViewModel.MasterValuePreviousId = -1;
					currentMasterValueViewModel.MasterValueFirstId = -1;
					currentMasterValueViewModel.MasterValueLastId = -1;
					currentMasterValueViewModel.FirstRegisterUser = "";
					currentMasterValueViewModel.EditUser = "";
					currentMasterValueViewModel.MasterValueCurrentId = masterValueCurrentId;
				}
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentMasterValueViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentMasterValueViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentMasterValueViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetFiles(int formId, int mValId, int? companyId = 0, int? companyPersonId = 0, int? projectId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmFilesDirectoryViewModel> list = new List<CrmFilesDirectoryViewModel>();
		try
		{
			list = GetFilesList(formId, mValId, companyId, companyPersonId, projectId);
			if (list == null || !Enumerable.Any<CrmFilesDirectoryViewModel>((IEnumerable<CrmFilesDirectoryViewModel>)list))
			{
				list = new List<CrmFilesDirectoryViewModel>();
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

	public List<CrmFilesDirectoryViewModel> GetFilesList(int formId, int mValId, int? companyId = 0, int? companyPersonId = 0, int? projectId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmFilesDirectoryViewModel> list = new List<CrmFilesDirectoryViewModel>();
		try
		{
			List<CRMspDySelectFilesDirectory_Result> list2 = Enumerable.ToList<CRMspDySelectFilesDirectory_Result>((IEnumerable<CRMspDySelectFilesDirectory_Result>)_db.CRMspDySelectFilesDirectory(companyId.ToString(), companyPersonId.ToString(), projectId.ToString(), "60", mValId.ToString(), formId.ToString(), "", lCID, result));
			if (list2 != null && Enumerable.Any<CRMspDySelectFilesDirectory_Result>((IEnumerable<CRMspDySelectFilesDirectory_Result>)list2))
			{
				foreach (CRMspDySelectFilesDirectory_Result item in list2)
				{
					CrmFilesDirectoryViewModel crmFilesDirectoryViewModel = new CrmFilesDirectoryViewModel
					{
						FileDirectoryID = item.FileDirectoryID,
						FileDirectoryTypeId = item.FileDirectoryTypeId,
						FileDirectoryTypeIdTitle = (item.FileDirectoryType ?? ""),
						DocTime = item.DocTime,
						Title = item.Title,
						ProjectIdTitle = item.prjTitle,
						FileName = item.FileName,
						OrderView = item.OrderView,
						TypeOprObjectId = item.TypeOprObjectId,
						TypeOprObjectIdI = item.TypeOprObjectIdI,
						TypeOprObjectIdII = item.TypeOprObjectIdII,
						FileDesc = item.FileDesc,
						FileDesc_Lang = item.FileDescLangJson
					};
					if (!string.IsNullOrEmpty(item.DocDay))
					{
						crmFilesDirectoryViewModel.DocDay = DateTimeClass.ConvertNumToDayeOfWeek(int.Parse(item.DocDay));
					}
					DateTime now = DateTime.Now;
					if (item.DocDateTime.HasValue)
					{
						crmFilesDirectoryViewModel.DocDate = DateTime.Parse(item.DocDateTime.ToString()).ToString("dddd - yyyy/MM/dd - HH:mm:ss");
					}
					else if (!string.IsNullOrEmpty(item.DocDate))
					{
						crmFilesDirectoryViewModel.DocDate = crmFilesDirectoryViewModel.DocDay + " - " + PersianDate.GetFormatetdDate(item.DocDate) + " - " + crmFilesDirectoryViewModel.DocTime;
					}
					list.Add(crmFilesDirectoryViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public string EditFile(int fileId, int? orderView = 0, string fileDesc = "", string fileDesc_Lang = "")
	{
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass14_0 _003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_0();
		_003C_003Ec__DisplayClass14_.fileId = fileId;
		string text = "-1";
		try
		{
			_003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass14_1();
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short year = short.Parse(Financial.Get().Id.ToString());
			DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
			ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
			CS_0024_003C_003E8__locals1.model = Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass14_, typeof(_003C_003Ec__DisplayClass14_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (CS_0024_003C_003E8__locals1.model != null)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals1.defLangID);
				if (CS_0024_003C_003E8__locals1.defLangID <= 0)
				{
					CS_0024_003C_003E8__locals1.defLangID = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(fileDesc_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(fileDesc_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = fileDesc,
					LanguageId = lCID
				});
				CS_0024_003C_003E8__locals1.model.UserId = userId;
				CS_0024_003C_003E8__locals1.model.RegisterDate = now;
				CS_0024_003C_003E8__locals1.model.RegisterDatePersian = registerDatePersian;
				CS_0024_003C_003E8__locals1.model.Year1 = year;
				CS_0024_003C_003E8__locals1.model.AppType = appType;
				CS_0024_003C_003E8__locals1.model.OrderView = orderView;
				CS_0024_003C_003E8__locals1.model.FileDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.defLangID)).Value : null);
				_dbTbl.Entry(CS_0024_003C_003E8__locals1.model).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals1.defLangID))).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass14_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_2();
						CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals1;
						CS_0024_003C_003E8__locals0.lang = enumerator.Current;
						DbSet<CrmFilesDirectory_Lang> crmFilesDirectory_Lang = _dbTbl.CrmFilesDirectory_Lang;
						val = Expression.Parameter(typeof(CrmFilesDirectory_Lang), "c");
						CrmFilesDirectory_Lang crmFilesDirectory_Lang2 = Queryable.FirstOrDefault<CrmFilesDirectory_Lang>((IQueryable<CrmFilesDirectory_Lang>)crmFilesDirectory_Lang, Expression.Lambda<Func<CrmFilesDirectory_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass14_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass14_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmFilesDirectory_Lang2 != null)
						{
							crmFilesDirectory_Lang2.FileDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null);
							_dbTbl.Entry(crmFilesDirectory_Lang2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							continue;
						}
						crmFilesDirectory_Lang2 = new CrmFilesDirectory_Lang
						{
							FileDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null),
							LanguageID = CS_0024_003C_003E8__locals0.lang.LanguageID,
							FileDirectoryID = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.model.FileDirectoryID
						};
						_dbTbl.CrmFilesDirectory_Lang.Add(crmFilesDirectory_Lang2);
						_dbTbl.SaveChanges();
					}
				}
				return "1";
			}
			return Messages.msgNotFound;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
	}

	[ValidateAntiForgeryToken]
	public ActionResult ActAddFile(HttpPostedFileBase addFile, int formId, int mValId, int? cmpId = null, int? prsId = null, int? prjId = null, int? orderView = null)
	{
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short month = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short year = short.Parse(Financial.Get().Id.ToString());
			int? num = null;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserLastCId;
			}
			int? fileCId = null;
			if (num.GetValueOrDefault() != 0)
			{
				fileCId = num;
			}
			CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(formId, 0, lCID, defLangID, num));
			CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(mValId, lCID, defLangID));
			if (cRMspDySelectFormFieldMasterValueWithId_Result != null && cRMspDySelectForms_Result != null)
			{
				cmpId = cRMspDySelectFormFieldMasterValueWithId_Result.CompanyId;
				prsId = cRMspDySelectFormFieldMasterValueWithId_Result.CompanyPersonId;
				prjId = cRMspDySelectFormFieldMasterValueWithId_Result.ProjectId;
				if (addFile == null)
				{
					goto IL_028f;
				}
				string text3 = ((!string.IsNullOrEmpty(cRMspDySelectForms_Result.UploadFileExtension)) ? cRMspDySelectForms_Result.UploadFileExtension : "*");
				addFile.ContentType.ToLower();
				string text4 = ((addFile.FileName != null) ? Path.GetExtension(addFile.FileName).ToLower() : "");
				if (text3 != "*" && !string.IsNullOrEmpty(text3) && text3.IndexOf(text4, StringComparison.Ordinal) < 0)
				{
					text += string.Format(Messages.msgErrorMessageFileExtension, text3);
				}
				else
				{
					string text5 = (text4 ?? "").ToLower();
					text5 = text5.Replace(".", "");
					if (Configuration.MaliciousFileExtensions.Contains(text5))
					{
						text += Messages.msgErrorFileIsExecuted;
					}
					else
					{
						int num2 = cRMspDySelectForms_Result.UploadFileMaxSize.GetValueOrDefault() * 1024;
						if (addFile.ContentLength <= num2)
						{
							goto IL_028f;
						}
						string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(addFile.ContentLength);
						string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num2);
						string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
						text += string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2);
					}
				}
			}
			goto end_IL_0006;
			IL_028f:
			CRMspDySelectFilesDirectory_Result cRMspDySelectFilesDirectory_Result = Enumerable.LastOrDefault<CRMspDySelectFilesDirectory_Result>((IEnumerable<CRMspDySelectFilesDirectory_Result>)_db.CRMspDySelectFilesDirectory(cmpId.GetValueOrDefault().ToString(), prsId.GetValueOrDefault().ToString(), prjId.GetValueOrDefault().ToString(), "60", mValId.ToString(), formId.ToString(), "", lCID, defLangID));
			if (cRMspDySelectFilesDirectory_Result != null)
			{
				orderView = ((!cRMspDySelectFilesDirectory_Result.OrderView.HasValue) ? new int?(5) : (cRMspDySelectFilesDirectory_Result.OrderView + 5));
			}
			if (addFile != null)
			{
				string fileName = Path.GetFileName(addFile.FileName);
				FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
				string text6 = "";
				text6 = (cmpId.HasValue ? cmpId.ToString() : (Configuration.DyDirectoryPath + formId));
				string folderName = (cmpId.HasValue ? cmpId.ToString() : formId.ToString());
				string docTime = now.ToString("HH:mm:ss");
				CrmFilesDirectory crmFilesDirectory = new CrmFilesDirectory
				{
					FirstRegisterUserId = userId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = text2,
					LanguageID = defLangID,
					UserId = userId,
					Year1 = year,
					Month1 = month,
					GUId = System.Guid.NewGuid(),
					RegisterDate = now,
					RegisterDatePersian = text2,
					DocDateTime = now,
					DocDate = text2,
					DocTime = docTime,
					DocDay = PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(),
					AppType = appType,
					DetailId = prsId,
					FileDirectoryTypeId = -60,
					TypeOprObjectId = mValId,
					TypeOprObjectIdI = formId,
					FolderName = folderName,
					SubDetailId = prjId,
					MasterId = cmpId,
					Title = fileName,
					OrderView = orderView,
					FileCId = fileCId
				};
				_dbTbl.CrmFilesDirectory.Add(crmFilesDirectory);
				_dbTbl.SaveChanges();
				string[] array = fileName.Split(new char[1] { '.' });
				string text7 = Configuration.MainDirectoryPath + text6 + "/";
				string text8 = text7 + (text7.EndsWith("/") ? "" : "/");
				string text9 = text8.Split(new char[1] { '/' })[^2];
				string text10 = text8.Replace(text9 + "/", "");
				bool flag = false;
				if (!cmpId.HasValue)
				{
					flag = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.MainDirectoryPath, Configuration.DyDirectoryPath, Configuration.UsePassiveFtp);
					if (!flag)
					{
						flag = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.MainDirectoryPath, Configuration.DyDirectoryPath, Configuration.UsePassiveFtp);
					}
				}
				else
				{
					flag = true;
				}
				bool flag2 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text10, text9, Configuration.UsePassiveFtp);
				if (!flag2)
				{
					flag2 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text10, text9, Configuration.UsePassiveFtp);
				}
				if (flag2 && flag)
				{
					string text11 = "";
					text11 = crmFilesDirectory.TypeOprObjectId + "-" + crmFilesDirectory.FileDirectoryID + "." + array[^1];
					string text12 = "";
					if (facadeFTP.Upload(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text8 + text11, addFile, Configuration.UsePassiveFtp))
					{
						text7 = Configuration.PathFtp + text8 + text11;
						text12 = text11;
						text7 = text7.Trim().Replace(Configuration.PathFtp, "");
						crmFilesDirectory.FilePath = text7;
						crmFilesDirectory.FileName = text12;
						crmFilesDirectory.UserId = UserLogin.CurrentUser.UserId;
						crmFilesDirectory.Year1 = year;
						crmFilesDirectory.Month1 = month;
						crmFilesDirectory.RegisterDate = now;
						crmFilesDirectory.RegisterDatePersian = text2;
						_dbTbl.Entry(crmFilesDirectory).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						foreach (Languages item in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
						{
							CrmFilesDirectory_Lang entity = new CrmFilesDirectory_Lang
							{
								LanguageID = item.LanguageID,
								FileDirectoryID = crmFilesDirectory.FileDirectoryID,
								Title = fileName
							};
							_dbTbl.CrmFilesDirectory_Lang.Add(entity);
							_dbTbl.SaveChanges();
						}
					}
					else
					{
						Exception e = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text10 + " ,directoryName: " + text9);
						ErrorSignal.FromCurrentContext().Raise(e);
						base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
						try
						{
							_dbTbl.CrmFilesDirectory.Remove(crmFilesDirectory);
							_dbTbl.SaveChanges();
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
						}
					}
				}
				else
				{
					Exception e3 = new Exception(Messages.msgErrorCreateFolderInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text10 + " ,directoryName: " + text9);
					ErrorSignal.FromCurrentContext().Raise(e3);
					base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
					try
					{
						_dbTbl.CrmFilesDirectory.Remove(crmFilesDirectory);
						_dbTbl.SaveChanges();
					}
					catch (Exception e4)
					{
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
				}
			}
			end_IL_0006:;
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
		return Content(text);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDyForm", ActionName = "actDelete")]
	public string DeleteValue(int mValId)
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
			CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(mValId, lCID, result2));
			if (cRMspDySelectFormFieldMasterValueWithId_Result != null)
			{
				try
				{
					if (DyForm.IsChecked(mValId))
					{
						return Messages.msgFormIsChecked;
					}
					List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory(cRMspDySelectFormFieldMasterValueWithId_Result.CompanyId.HasValue ? cRMspDySelectFormFieldMasterValueWithId_Result.CompanyId.ToString() : "0", cRMspDySelectFormFieldMasterValueWithId_Result.CompanyPersonId.HasValue ? cRMspDySelectFormFieldMasterValueWithId_Result.CompanyPersonId.ToString() : "0", cRMspDySelectFormFieldMasterValueWithId_Result.ProjectId.HasValue ? cRMspDySelectFormFieldMasterValueWithId_Result.ProjectId.ToString() : "0", "60", mValId.ToString(), "0", "0", false);
					if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
					{
						result = Messages.RedundancyMessage;
					}
					else
					{
						DateTime now = DateTime.Now;
						string deletedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						int userId = UserLogin.CurrentUser.UserId;
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDyUpdateToDeleteFormFieldMasterValue(mValId, userId, now, deletedDatePersian));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							result = "";
						}
						else if (mct_Result != null && mct_Result.Result == 0)
						{
							result = Messages.RedundancyMessage;
						}
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
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string CheckDyForm(int mValId, int mode)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmDyForm", "actCheckDyForm", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			if (Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(mValId, lCID, result2)) != null)
			{
				_db.CRMspDyFormCheck(mValId, currentUser.UserId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), mode);
				_dbII.ScorespInsertAndCalcDyFormScores(null, mValId, null, null, userId, value2, value, now, registerDatePersian, appType, lCID, result2, true, null, result3, true);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitFromIsChecked(int mValId, int mode)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmDyForm", "actExitFromIsChecked", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(mValId, lCID, result2)) != null)
			{
				_db.CRMspDyFormCheckExit(mValId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), mode);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDyForm", ActionName = "actGetXmlFile")]
	public ActionResult GetXml(int mValId)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		string text = System.Guid.NewGuid().ToString();
		MemoryStream memoryStream = new MemoryStream();
		XmlWriterSettings val = new XmlWriterSettings();
		val.OmitXmlDeclaration = true;
		val.Indent = true;
		List<FieldValueItemViewModel> list = new List<FieldValueItemViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			DateTime now = DateTime.Now;
			List<CRMspDyPrintForm_Result> list2 = Enumerable.ToList<CRMspDyPrintForm_Result>((IEnumerable<CRMspDyPrintForm_Result>)_db.CRMspDyPrintForm(mValId, UserLogin.CurrentUser.UserId, now.ToString("yyyy/MM/dd"), now.ToString("dddd"), lCID, result));
			foreach (CRMspDyPrintForm_Result item2 in list2)
			{
				if (string.IsNullOrEmpty(item2.FieldValue))
				{
					continue;
				}
				string[] array = item2.FieldValue.Split(new string[1] { "|^,^|" }, StringSplitOptions.None);
				if (array == null)
				{
					continue;
				}
				int num = array.Length;
				for (int i = 0; i < num; i++)
				{
					if (array[i] == null || !(array[i] != ""))
					{
						continue;
					}
					string[] array2 = array[i].Split(new string[1] { "|^:^|" }, StringSplitOptions.None);
					if (array2 == null || !Enumerable.Any<string>((IEnumerable<string>)array2) || Enumerable.Count<string>((IEnumerable<string>)array2) <= 3)
					{
						continue;
					}
					FieldValueItemViewModel fieldValueItemViewModel = new FieldValueItemViewModel
					{
						FormId = item2.FormId,
						CompanyId = item2.CompanyId,
						CompanyPersonId = item2.CompanyPersonId,
						ProjectId = item2.ProjectId,
						ConversationId = item2.ConversationId,
						MasterObjectId = item2.MasterObjectId,
						DetailObjectId = item2.DetailObjectId,
						SubDetailObjectId = item2.SubDetailObjectId,
						MasterValueId = item2.FormFieldMasterValueId,
						FieldTitle = array2[0],
						Value = array2[1],
						FieldType = ((array2[2] != null) ? array2[2].Trim() : array2[2]),
						FieldRepeatId = ((!string.IsNullOrWhiteSpace(array2[3])) ? long.Parse(array2[3].Trim() ?? "0") : 0)
					};
					if (fieldValueItemViewModel.FieldType == "4" && !string.IsNullOrEmpty(fieldValueItemViewModel.Value))
					{
						fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						if (fieldValueItemViewModel.Value != "" && fieldValueItemViewModel.Value != "")
						{
							string formatetdDate = PersianDate.GetFormatetdDate(fieldValueItemViewModel.Value.Replace("/", ""));
							if (lCID == 1065)
							{
								fieldValueItemViewModel.Value = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd");
							}
							else
							{
								DateTime dateTime = DateTime.Parse(PersianDate.GetShamsi2Miladi(fieldValueItemViewModel.Value.Replace("/", "")));
								if (lCID == 1025)
								{
									fieldValueItemViewModel.Value = dateTime.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
								}
								else
								{
									fieldValueItemViewModel.Value = dateTime.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
								}
							}
						}
					}
					else if (fieldValueItemViewModel.FieldType == "8")
					{
						if (fieldValueItemViewModel.Value != "" && fieldValueItemViewModel.Value != "")
						{
							fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.Replace("|", ",");
							fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.TrimEnd(new char[1] { ',' });
						}
						fieldValueItemViewModel.Value.TrimEnd(new char[1] { ',' });
					}
					list.Add(fieldValueItemViewModel);
				}
			}
			if (list != null && Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list))
			{
				bool flag = true;
				XmlWriter val2 = XmlWriter.Create((Stream)memoryStream, val);
				try
				{
					val2.WriteStartDocument();
					val2.WriteStartElement("Container");
					foreach (CRMspDyPrintForm_Result item in list2)
					{
						List<FieldValueItemViewModel> list3 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == item.FormFieldMasterValueId && m.FieldRepeatId == 0)));
						if (list3 == null || !Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list3))
						{
							continue;
						}
						FieldValueItemViewModel fieldValueItemViewModel2 = Enumerable.FirstOrDefault<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list3);
						if (fieldValueItemViewModel2 == null)
						{
							continue;
						}
						if (list2.Count == 1 && flag)
						{
							flag = false;
							val2.WriteStartElement("Row");
							foreach (FieldValueItemViewModel item3 in list3)
							{
								if (!string.IsNullOrEmpty(item3.FieldTitle))
								{
									string text2 = item3.FieldTitle.Trim();
									text2 = text2.Replace(" ", "_");
									text2 = ConvertCharacter.RemoveSpecialCharactersWithoutDot(text2);
									val2.WriteElementString(text2, "");
								}
							}
							val2.WriteElementString("CompanyId", "0");
							val2.WriteElementString("CompanyPersonId", "0");
							val2.WriteElementString("ProjectId", "0");
							val2.WriteElementString("ConversationId", "0");
							val2.WriteElementString("MasterObjectId", "0");
							val2.WriteElementString("DetailObjectId", "0");
							val2.WriteElementString("SubDetailObjectId", "0");
							val2.WriteElementString("MasterValueId", "0");
							val2.WriteEndElement();
						}
						val2.WriteStartElement("Row");
						foreach (FieldValueItemViewModel item4 in list3)
						{
							if (!string.IsNullOrEmpty(item4.FieldTitle))
							{
								string text3 = item4.FieldTitle.Trim();
								text3 = text3.Replace(" ", "_");
								text3 = ConvertCharacter.RemoveSpecialCharactersWithoutDot(text3);
								val2.WriteElementString(text3, item4.Value ?? "");
							}
						}
						val2.WriteElementString("CompanyId", fieldValueItemViewModel2.CompanyId.ToString());
						val2.WriteElementString("CompanyPersonId", fieldValueItemViewModel2.CompanyPersonId.ToString());
						val2.WriteElementString("ProjectId", fieldValueItemViewModel2.ProjectId.ToString());
						val2.WriteElementString("ConversationId", fieldValueItemViewModel2.ConversationId.ToString());
						val2.WriteElementString("MasterObjectId", fieldValueItemViewModel2.MasterObjectId.ToString());
						val2.WriteElementString("DetailObjectId", fieldValueItemViewModel2.DetailObjectId.ToString());
						val2.WriteElementString("SubDetailObjectId", fieldValueItemViewModel2.SubDetailObjectId.ToString());
						val2.WriteElementString("MasterValueId", fieldValueItemViewModel2.MasterValueId.ToString());
						val2.WriteEndElement();
						List<FieldValueItemViewModel> list4 = new List<FieldValueItemViewModel>();
						List<FieldValueItemViewModel> list5 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == item.FormFieldMasterValueId && m.FieldRepeatId != 0)));
						if (list5 == null || !Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list5))
						{
							continue;
						}
						foreach (FieldValueItemViewModel repeateItem in list5)
						{
							FieldValueItemViewModel fieldValueItemViewModel3 = null;
							if (list4 != null && Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list4))
							{
								fieldValueItemViewModel3 = Enumerable.FirstOrDefault<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list4, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == item.FormFieldMasterValueId && m.FieldRepeatId == repeateItem.FieldRepeatId));
							}
							if (fieldValueItemViewModel3 != null)
							{
								continue;
							}
							list3 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == item.FormFieldMasterValueId && m.FieldRepeatId == repeateItem.FieldRepeatId)));
							val2.WriteStartElement("Row");
							foreach (FieldValueItemViewModel item5 in list3)
							{
								if (!string.IsNullOrEmpty(item5.FieldTitle))
								{
									string text4 = item5.FieldTitle.Trim();
									text4 = text4.Replace(" ", "_");
									text4 = ConvertCharacter.RemoveSpecialCharactersWithoutDot(text4);
									val2.WriteElementString(text4, item5.Value ?? "");
								}
							}
							val2.WriteElementString("CompanyId", fieldValueItemViewModel2.CompanyId.ToString());
							val2.WriteElementString("CompanyPersonId", fieldValueItemViewModel2.CompanyPersonId.ToString());
							val2.WriteElementString("ProjectId", fieldValueItemViewModel2.ProjectId.ToString());
							val2.WriteElementString("ConversationId", fieldValueItemViewModel2.ConversationId.ToString());
							val2.WriteElementString("MasterObjectId", fieldValueItemViewModel2.MasterObjectId.ToString());
							val2.WriteElementString("DetailObjectId", fieldValueItemViewModel2.DetailObjectId.ToString());
							val2.WriteElementString("SubDetailObjectId", fieldValueItemViewModel2.SubDetailObjectId.ToString());
							val2.WriteElementString("MasterValueId", fieldValueItemViewModel2.MasterValueId.ToString());
							val2.WriteEndElement();
							list4.Add(repeateItem);
						}
					}
					val2.WriteEndElement();
					val2.WriteEndDocument();
					val2.Flush();
					val2.Close();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				memoryStream.Position = 0L;
				base.TempData[text] = memoryStream.ToArray();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new JsonResult
		{
			Data = new
			{
				FileGuid = text,
				FileName = "DyPrintFormOutput.xml"
			}
		};
	}

	[HttpGet]
	public virtual ActionResult Download(string fileGuid, string fileName)
	{
		if (base.TempData[fileGuid] != null)
		{
			byte[] fileContents = base.TempData[fileGuid] as byte[];
			return File(fileContents, "application/xml", fileName);
		}
		return new EmptyResult();
	}

	[AjaxOnly]
	public string CheckSubForm(int mValId, int mvdId, int workflowStepId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmDyForm", "actCheckSubForm", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(mValId, lCID, result2));
			if (Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetailWithId_Result>)_db.CRMspDySelectFormFieldMasterValueDetailWithId(mvdId, lCID, result2)) != null && cRMspDySelectFormFieldMasterValueWithId_Result != null)
			{
				if (_db.CRMspDySubFormCheck(mValId, mvdId, workflowStepId, currentUser.UserId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture())) > 0)
				{
					DateTime now = DateTime.Now;
					int userId = UserLogin.CurrentUser.UserId;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					string registerTime = now.ToString("HH:mm:ss");
					string formName = DyForm.GetFormName(cRMspDySelectFormFieldMasterValueWithId_Result.FormId, result2, result2);
					string workflowStepTitle = DyForm.GetWorkflowStepTitle(workflowStepId, result2, result2);
					bool flag = true;
					CRMspDySelectFormWorkflowStepNext_Result cRMspDySelectFormWorkflowStepNext_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepNext_Result>((IEnumerable<CRMspDySelectFormWorkflowStepNext_Result>)_db.CRMspDySelectFormWorkflowStepNext(cRMspDySelectFormFieldMasterValueWithId_Result.WorkflowId, workflowStepId, lCID, result2, centerId));
					if (cRMspDySelectFormWorkflowStepNext_Result != null)
					{
						if (!string.IsNullOrEmpty(cRMspDySelectFormWorkflowStepNext_Result.ReferUserIds))
						{
							string text = "";
							string text2 = "";
							string text3 = "";
							foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
							{
								string formName2 = DyForm.GetFormName(cRMspDySelectFormFieldMasterValueWithId_Result.FormId, result2, item.LanguageID);
								string workflowStepTitle2 = DyForm.GetWorkflowStepTitle(workflowStepId, result2, item.LanguageID);
								text = "";
								text2 = "";
								text = string.Format(MyResource.GetResourceString("DyFrmVerifyNextStepRefreUsersMsgSub", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName2);
								text2 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmVerifyNextStepErjaAttention", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), DyForm.GetWorkflowStepTitle(cRMspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, result2, item.LanguageID), formName2, workflowStepTitle2) + "<BR>";
								string[] array = cRMspDySelectFormWorkflowStepNext_Result.ReferUserIds.TrimEnd(new char[1] { '|' }).Split(new char[1] { '|' });
								if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) > 1)
								{
									text2 = text2 + "<BR>" + MyResource.GetResourceString("DyFrmErjaMultiUser", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + DyForm.GetUsersForSendMsg(cRMspDySelectFormFieldMasterValueWithId_Result.FormId, cRMspDySelectFormWorkflowStepNext_Result.ReferUserIds, result2, item.LanguageID, item.LanguageCollation);
								}
								text2 = text2 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								text3 = text3 + "MsgSubj=" + text + "|@#@|MsgBody=" + text2 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
							}
							string workflowStepTitle3 = DyForm.GetWorkflowStepTitle(cRMspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, result2, result2);
							ObjectParameter objectParameter = new ObjectParameter("InsertedIntMsgId", 0);
							_db.CRMspDySendFormInternalMessages(mValId, cRMspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, cRMspDySelectFormWorkflowStepNext_Result.ReferUserIds, text3, formName, workflowStepTitle3, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result2, objectParameter, centerId);
							flag = objectParameter.Value != null && (objectParameter.Value.ToString() ?? "0") != "-1";
						}
					}
					else if (cRMspDySelectFormFieldMasterValueWithId_Result.FirstRegisterUserId > 0)
					{
						string text4 = "";
						string text5 = "";
						string text6 = "";
						foreach (Languages item2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
						{
							string formName3 = DyForm.GetFormName(cRMspDySelectFormFieldMasterValueWithId_Result.FormId, result2, item2.LanguageID);
							DyForm.GetWorkflowStepTitle(workflowStepId, result2, item2.LanguageID);
							text4 = "";
							text5 = "";
							text4 = string.Format(MyResource.GetResourceString("DyFrmVerifyNextStepRefreUsersMsgSub", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName3);
							text5 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmVerifyFirstStepErjaAttention", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName3) + "<BR>";
							text5 = text5 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text6 = text6 + "MsgSubj=" + text4 + "|@#@|MsgBody=" + text5 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
						}
						ObjectParameter objectParameter2 = new ObjectParameter("InsertedIntMsgId", 0);
						_db.CRMspDySendFormInternalMessages(mValId, workflowStepId, cRMspDySelectFormFieldMasterValueWithId_Result.FirstRegisterUserId.ToString(), text6, formName, workflowStepTitle, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result2, objectParameter2, centerId);
						flag = objectParameter2.Value != null && (objectParameter2.Value.ToString() ?? "0") != "-1";
					}
					if (!flag)
					{
						result = Messages.msgErrorErrorSendingMessages;
					}
					CRMspDySelectFormFieldMasterValueDetailWithId_Result cRMspDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetailWithId_Result>)_db.CRMspDySelectFormFieldMasterValueDetailWithId(mvdId, lCID, result2));
					if (cRMspDySelectFormFieldMasterValueDetailWithId_Result != null)
					{
						string text7 = "";
						string text8 = "";
						string text9 = "";
						foreach (Languages item3 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
						{
							string formName4 = DyForm.GetFormName(cRMspDySelectFormFieldMasterValueDetailWithId_Result.FormId, result2, item3.LanguageID);
							string workflowStepTitle4 = DyForm.GetWorkflowStepTitle(workflowStepId, result2, item3.LanguageID);
							text7 = "";
							text8 = "";
							text7 = string.Format(MyResource.GetResourceString("DyFrmVerifyNextStepRefreUsersMsgSub", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName4);
							text8 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmVerifyCurrentStepErjaAttention", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), DyForm.GetWorkflowStepTitle(cRMspDySelectFormFieldMasterValueDetailWithId_Result.WorkflowStepId.GetValueOrDefault(), result2, item3.LanguageID), formName4, workflowStepTitle4) + "<BR>";
							text8 = text8 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text9 = text9 + "MsgSubj=" + text7 + "|@#@|MsgBody=" + text8 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
						}
						string workflowStepTitle5 = DyForm.GetWorkflowStepTitle(cRMspDySelectFormFieldMasterValueDetailWithId_Result.WorkflowStepId.GetValueOrDefault(), result2, result2);
						ObjectParameter insertedIntMsgId = new ObjectParameter("InsertedIntMsgId", 0);
						_db.CRMspDySendFormInternalMessages(mValId, cRMspDySelectFormFieldMasterValueDetailWithId_Result.WorkflowStepId, cRMspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUserId.ToString(), text9, formName, workflowStepTitle5, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result2, insertedIntMsgId, centerId);
					}
					PushNotif.NewIntMsgNotify();
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitSubFormFromIsChecked(int mvdId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmDyForm", "actExitFromIsCheckedSubform", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetailWithId_Result>)_db.CRMspDySelectFormFieldMasterValueDetailWithId(mvdId, lCID, result2)) != null)
			{
				_db.CRMspDySubFormCheckExit(mvdId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult SendIntMsg(int formId, int mValId, int workflowId, int workflowStepId, string referUserIds, string multiReferUserIds, string checkerUserIds, bool sendAutoMsgToMultiReferUsers, bool sendAutoMsgToCheckerUsers, int masterValueDetailId = 0, int firstWorkflowStepId = 0, string mainFormReferUserIs = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string registerTime = now.ToString("HH:mm:ss");
			string formName = DyForm.GetFormName(formId, result, result);
			string workflowStepTitle = DyForm.GetWorkflowStepTitle(workflowStepId, result, result);
			bool flag = true;
			bool flag2 = true;
			bool flag3 = true;
			bool flag4 = true;
			bool flag5 = true;
			CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(mValId, lCID, result));
			if (cRMspDySelectFormFieldMasterValueWithId_Result != null)
			{
				if (cRMspDySelectFormFieldMasterValueWithId_Result.DyFormNumber.HasValue)
				{
					cRMspDySelectFormFieldMasterValueWithId_Result.DyFormNumber.ToString();
				}
				else
				{
					mValId.ToString();
				}
			}
			else
			{
				mValId.ToString();
			}
			bool flag6 = false;
			if (!string.IsNullOrEmpty(mainFormReferUserIs) && firstWorkflowStepId > 0 && flag6)
			{
				if (!string.IsNullOrEmpty(mainFormReferUserIs))
				{
					string[] array = mainFormReferUserIs.Split(new char[1] { '|' });
					if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						string text3 = "";
						string[] array2 = array;
						foreach (string text4 in array2)
						{
							if (!string.IsNullOrEmpty(text4) && int.Parse(text4) != userId)
							{
								text3 = text3 + text4 + "|";
							}
						}
						mainFormReferUserIs = text3;
					}
				}
				if (!string.IsNullOrEmpty(mainFormReferUserIs))
				{
					string text5 = "";
					string text6 = "";
					string text7 = "";
					foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
					{
						string formName2 = DyForm.GetFormName(formId, result, item.LanguageID);
						DyForm.GetWorkflowStepTitle(workflowStepId, result, item.LanguageID);
						text5 = "";
						text6 = "";
						text5 = string.Format(MyResource.GetResourceString("DyFrmRefreUsersMsgSub", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName2);
						text6 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmErjaAttentionForMainForm", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName2) + "<BR>";
						string[] array3 = mainFormReferUserIs.TrimEnd(new char[1] { '|' }).Split(new char[1] { '|' });
						if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) > 1)
						{
							text6 = text6 + "<BR>" + MyResource.GetResourceString("DyFrmErjaMultiUser", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + DyForm.GetUsersForSendMsg(formId, mainFormReferUserIs, result, item.LanguageID, item.LanguageCollation);
						}
						text6 = text6 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text7 = text7 + "MsgSubj=" + text5 + "|@#@|MsgBody=" + text6 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
					}
					ObjectParameter objectParameter = new ObjectParameter("InsertedIntMsgId", 0);
					_db.CRMspDySendFormInternalMessages(mValId, firstWorkflowStepId, mainFormReferUserIs, text7, formName, workflowStepTitle, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter, centerId);
					flag = objectParameter.Value != null && (objectParameter.Value.ToString() ?? "0") != "-1";
				}
			}
			if (!string.IsNullOrEmpty(referUserIds))
			{
				string[] array4 = referUserIds.Split(new char[1] { '|' });
				if (Enumerable.Any<string>((IEnumerable<string>)array4))
				{
					string text8 = "";
					string[] array2 = array4;
					foreach (string text9 in array2)
					{
						if (!string.IsNullOrEmpty(text9) && int.Parse(text9) != userId)
						{
							text8 = text8 + text9 + "|";
						}
					}
					referUserIds = text8;
				}
			}
			if (!string.IsNullOrEmpty(referUserIds) && flag6)
			{
				string text10 = "";
				string text11 = "";
				string text12 = "";
				foreach (Languages item2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
				{
					string formName3 = DyForm.GetFormName(formId, result, item2.LanguageID);
					string workflowStepTitle2 = DyForm.GetWorkflowStepTitle(workflowStepId, result, item2.LanguageID);
					text10 = "";
					text11 = "";
					text10 = string.Format(MyResource.GetResourceString("DyFrmRefreUsersMsgSub", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName3);
					text11 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmErjaAttention", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), workflowStepTitle2, formName3) + "<BR>";
					string[] array5 = referUserIds.TrimEnd(new char[1] { '|' }).Split(new char[1] { '|' });
					if (array5 != null && Enumerable.Count<string>((IEnumerable<string>)array5) > 1)
					{
						text11 = text11 + "<BR>" + MyResource.GetResourceString("DyFrmErjaMultiUser", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + DyForm.GetUsersForSendMsg(formId, referUserIds, result, item2.LanguageID, item2.LanguageCollation);
					}
					text11 = text11 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text12 = text12 + "MsgSubj=" + text10 + "|@#@|MsgBody=" + text11 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
				}
				ObjectParameter objectParameter2 = new ObjectParameter("InsertedIntMsgId", 0);
				_db.CRMspDySendFormInternalMessages(mValId, workflowStepId, referUserIds, text12, formName, workflowStepTitle, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter2, centerId);
				flag2 = objectParameter2.Value != null && (objectParameter2.Value.ToString() ?? "0") != "-1";
			}
			if (!string.IsNullOrEmpty(multiReferUserIds) && sendAutoMsgToMultiReferUsers)
			{
				string text13 = "";
				string text14 = "";
				string text15 = "";
				foreach (Languages item3 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
				{
					string formName4 = DyForm.GetFormName(formId, result, item3.LanguageID);
					text13 = "";
					text14 = "";
					text13 = string.Format(MyResource.GetResourceString("DyFrmErjaRonevesht", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName4) + " " + CRMIdeal.Classes.Helper.Company.GetUserName(userId, result, item3.LanguageID);
					text14 = MyResource.GetResourceString("DyFrmErjaFrom", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":" + formName4;
					text14 = text14 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text15 = text15 + "MsgSubj=" + text13 + "|@#@|MsgBody=" + text14 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
				}
				ObjectParameter objectParameter3 = new ObjectParameter("InsertedIntMsgId", 0);
				_db.CRMspDySendFormInternalMessages(mValId, workflowStepId, multiReferUserIds, text15, formName, workflowStepTitle, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter3, centerId);
				flag3 = objectParameter3.Value != null && (objectParameter3.Value.ToString() ?? "0") != "-1";
			}
			if (firstWorkflowStepId == 0)
			{
				if (!string.IsNullOrEmpty(checkerUserIds) && sendAutoMsgToCheckerUsers)
				{
					string text16 = "";
					string text17 = "";
					string text18 = "";
					foreach (Languages item4 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
					{
						string formName5 = DyForm.GetFormName(formId, result, item4.LanguageID);
						text16 = "";
						text17 = "";
						text16 = string.Format(MyResource.GetResourceString("DyfrmCheckRequestSubject", item4.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly), formName5);
						text17 = MyResource.GetResourceString("DyFrmReqCheckByName", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":" + formName5;
						text17 = text17 + "<BR><BR>" + MyResource.GetResourceString("DyfrmCheckRequestDbClickOnOtherInfo", item4.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						text18 = text18 + "MsgSubj=" + text16 + "|@#@|MsgBody=" + text17 + "|@#@|LangId=" + item4.LanguageID + "|@#@||^#^|";
					}
					ObjectParameter objectParameter4 = new ObjectParameter("InsertedIntMsgId", 0);
					_db.CRMspDySendFormInternalMessages(mValId, workflowStepId, checkerUserIds, text18, formName, workflowStepTitle, 16, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter4, centerId);
					flag4 = objectParameter4.Value != null && (objectParameter4.Value.ToString() ?? "0") != "-1";
				}
				if (string.IsNullOrEmpty(checkerUserIds) && flag6)
				{
					CRMspDySelectFormWorkflowStepNext_Result cRMspDySelectFormWorkflowStepNext_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepNext_Result>((IEnumerable<CRMspDySelectFormWorkflowStepNext_Result>)_db.CRMspDySelectFormWorkflowStepNext(workflowId, workflowStepId, lCID, result, centerId));
					if (cRMspDySelectFormWorkflowStepNext_Result != null)
					{
						if (!string.IsNullOrEmpty(cRMspDySelectFormWorkflowStepNext_Result.ReferUserIds) && flag6)
						{
							string text19 = "";
							string text20 = "";
							string text21 = "";
							foreach (Languages item5 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
							{
								string workflowStepTitle3 = DyForm.GetWorkflowStepTitle(workflowStepId, result, item5.LanguageID);
								string formName6 = DyForm.GetFormName(formId, result, item5.LanguageID);
								text19 = "";
								text20 = "";
								text19 = string.Format(MyResource.GetResourceString("DyFrmNextStepRefreUsersMsgSub", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), workflowStepTitle3, formName6);
								text20 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmNextStepErjaAttention", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), DyForm.GetWorkflowStepTitle(cRMspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, result, item5.LanguageID), formName6, workflowStepTitle3) + "<BR>";
								string[] array6 = cRMspDySelectFormWorkflowStepNext_Result.ReferUserIds.TrimEnd(new char[1] { '|' }).Split(new char[1] { '|' });
								if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) > 1)
								{
									text20 = text20 + "<BR>" + MyResource.GetResourceString("DyFrmErjaMultiUser", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + DyForm.GetUsersForSendMsg(formId, cRMspDySelectFormWorkflowStepNext_Result.ReferUserIds, result, item5.LanguageID, item5.LanguageCollation);
								}
								text20 = text20 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								text21 = text21 + "MsgSubj=" + text19 + "|@#@|MsgBody=" + text20 + "|@#@|LangId=" + item5.LanguageID + "|@#@||^#^|";
							}
							string workflowStepTitle4 = DyForm.GetWorkflowStepTitle(cRMspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, result, result);
							ObjectParameter objectParameter5 = new ObjectParameter("InsertedIntMsgId", 0);
							_db.CRMspDySendFormInternalMessages(mValId, cRMspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, cRMspDySelectFormWorkflowStepNext_Result.ReferUserIds, text21, formName, workflowStepTitle4, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter5, centerId);
							flag5 = objectParameter5.Value != null && (objectParameter5.Value.ToString() ?? "0") != "-1";
						}
					}
					else
					{
						CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result2 = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(mValId, lCID, result));
						if (cRMspDySelectFormFieldMasterValueWithId_Result2.FirstRegisterUserId > 0)
						{
							string text22 = "";
							string text23 = "";
							string text24 = "";
							foreach (Languages item6 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
							{
								string formName7 = DyForm.GetFormName(cRMspDySelectFormFieldMasterValueWithId_Result2.FormId, result, item6.LanguageID);
								string workflowStepTitle5 = DyForm.GetWorkflowStepTitle(workflowStepId, result, item6.LanguageID);
								text22 = "";
								text23 = "";
								text22 = string.Format(MyResource.GetResourceString("DyFrmNextStepRefreUsersMsgSub", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), workflowStepTitle5, formName7);
								text23 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmFirstStepErjaAttention", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName7, workflowStepTitle5, formName7) + "<BR>";
								text23 = text23 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								text24 = text24 + "MsgSubj=" + text22 + "|@#@|MsgBody=" + text23 + "|@#@|LangId=" + item6.LanguageID + "|@#@||^#^|";
							}
							ObjectParameter objectParameter6 = new ObjectParameter("InsertedIntMsgId", 0);
							_db.CRMspDySendFormInternalMessages(mValId, workflowStepId, cRMspDySelectFormFieldMasterValueWithId_Result2.FirstRegisterUserId.ToString(), text24, formName, workflowStepTitle, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter6, centerId);
							flag5 = objectParameter6.Value != null && (objectParameter6.Value.ToString() ?? "0") != "-1";
						}
					}
				}
			}
			if (flag2 && flag3 && flag4 && flag5 && flag)
			{
				PushNotif.NewIntMsgNotify();
				text2 = "";
				text = "ok";
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				text2 = Messages.msgErrorErrorSendingMessages;
				text = "";
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text2 = Messages.msgErrorRunFunction + "<br />" + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			text = "";
		}
		CommonResultViewModel<string> data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
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

	[ValidateAntiForgeryToken]
	public ActionResult ActAddFileInFrmInner(HttpPostedFileBase addFileI, int formId, int mValId, int? cmpId = null, int? prsId = null, int? prjId = null, int? orderView = null)
	{
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short month = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short year = short.Parse(Financial.Get().Id.ToString());
			int? num = null;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserLastCId;
			}
			int? fileCId = null;
			if (num.GetValueOrDefault() != 0)
			{
				fileCId = num;
			}
			CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(formId, 0, lCID, defLangID, num));
			CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(mValId, lCID, defLangID));
			if (cRMspDySelectFormFieldMasterValueWithId_Result != null && cRMspDySelectForms_Result != null)
			{
				cmpId = cRMspDySelectFormFieldMasterValueWithId_Result.CompanyId;
				prsId = cRMspDySelectFormFieldMasterValueWithId_Result.CompanyPersonId;
				prjId = cRMspDySelectFormFieldMasterValueWithId_Result.ProjectId;
				if (addFileI == null)
				{
					goto IL_028f;
				}
				string text3 = ((!string.IsNullOrEmpty(cRMspDySelectForms_Result.UploadFileExtension)) ? cRMspDySelectForms_Result.UploadFileExtension : "*");
				addFileI.ContentType.ToLower();
				string text4 = ((addFileI.FileName != null) ? Path.GetExtension(addFileI.FileName).ToLower() : "");
				if (text3 != "*" && !string.IsNullOrEmpty(text3) && text3.IndexOf(text4, StringComparison.Ordinal) < 0)
				{
					text += string.Format(Messages.msgErrorMessageFileExtension, text3);
				}
				else
				{
					string text5 = (text4 ?? "").ToLower();
					text5 = text5.Replace(".", "");
					if (Configuration.MaliciousFileExtensions.Contains(text5))
					{
						text += Messages.msgErrorFileIsExecuted;
					}
					else
					{
						int num2 = cRMspDySelectForms_Result.UploadFileMaxSize.GetValueOrDefault() * 1024;
						if (addFileI.ContentLength <= num2)
						{
							goto IL_028f;
						}
						string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(addFileI.ContentLength);
						string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num2);
						string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
						text += string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2);
					}
				}
			}
			goto end_IL_0006;
			IL_028f:
			CRMspDySelectFilesDirectory_Result cRMspDySelectFilesDirectory_Result = Enumerable.LastOrDefault<CRMspDySelectFilesDirectory_Result>((IEnumerable<CRMspDySelectFilesDirectory_Result>)_db.CRMspDySelectFilesDirectory(cmpId.GetValueOrDefault().ToString(), prsId.GetValueOrDefault().ToString(), prjId.GetValueOrDefault().ToString(), "60", mValId.ToString(), formId.ToString(), "", lCID, defLangID));
			if (cRMspDySelectFilesDirectory_Result != null)
			{
				orderView = ((!cRMspDySelectFilesDirectory_Result.OrderView.HasValue) ? new int?(5) : (cRMspDySelectFilesDirectory_Result.OrderView + 5));
			}
			if (addFileI != null)
			{
				string fileName = Path.GetFileName(addFileI.FileName);
				FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
				string text6 = "";
				text6 = (cmpId.HasValue ? cmpId.ToString() : (Configuration.DyDirectoryPath + cRMspDySelectFormFieldMasterValueWithId_Result.FormId));
				string folderName = (cmpId.HasValue ? cmpId.ToString() : cRMspDySelectFormFieldMasterValueWithId_Result.FormId.ToString());
				string docTime = now.ToString("HH:mm:ss");
				CrmFilesDirectory crmFilesDirectory = new CrmFilesDirectory
				{
					FirstRegisterUserId = userId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = text2,
					LanguageID = defLangID,
					UserId = userId,
					Year1 = year,
					Month1 = month,
					GUId = System.Guid.NewGuid(),
					RegisterDate = now,
					RegisterDatePersian = text2,
					DocDateTime = now,
					DocDate = text2,
					DocTime = docTime,
					DocDay = PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(),
					AppType = appType,
					DetailId = prsId,
					FileDirectoryTypeId = -60,
					TypeOprObjectId = mValId,
					TypeOprObjectIdI = formId,
					FolderName = folderName,
					SubDetailId = prjId,
					MasterId = cmpId,
					Title = fileName,
					OrderView = orderView,
					FileCId = fileCId
				};
				_dbTbl.CrmFilesDirectory.Add(crmFilesDirectory);
				_dbTbl.SaveChanges();
				string[] array = fileName.Split(new char[1] { '.' });
				string text7 = Configuration.MainDirectoryPath + text6 + "/";
				string text8 = text7 + (text7.EndsWith("/") ? "" : "/");
				string text9 = text8.Split(new char[1] { '/' })[^2];
				string text10 = text8.Replace(text9 + "/", "");
				bool flag = false;
				if (!cmpId.HasValue)
				{
					flag = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.MainDirectoryPath, Configuration.DyDirectoryPath, Configuration.UsePassiveFtp);
					if (!flag)
					{
						flag = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.MainDirectoryPath, Configuration.DyDirectoryPath, Configuration.UsePassiveFtp);
					}
				}
				else
				{
					flag = true;
				}
				bool flag2 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text10, text9, Configuration.UsePassiveFtp);
				if (!flag2)
				{
					flag2 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text10, text9, Configuration.UsePassiveFtp);
				}
				if (flag2 && flag)
				{
					string text11 = "";
					text11 = crmFilesDirectory.TypeOprObjectId + "-" + crmFilesDirectory.FileDirectoryID + "." + array[^1];
					string text12 = "";
					if (facadeFTP.Upload(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text8 + text11, addFileI, Configuration.UsePassiveFtp))
					{
						text7 = Configuration.PathFtp + text8 + text11;
						text12 = text11;
						text7 = text7.Trim().Replace(Configuration.PathFtp, "");
						crmFilesDirectory.FilePath = text7;
						crmFilesDirectory.FileName = text12;
						crmFilesDirectory.UserId = UserLogin.CurrentUser.UserId;
						crmFilesDirectory.Year1 = year;
						crmFilesDirectory.Month1 = month;
						crmFilesDirectory.RegisterDate = now;
						crmFilesDirectory.RegisterDatePersian = text2;
						_dbTbl.Entry(crmFilesDirectory).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						foreach (Languages item in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
						{
							CrmFilesDirectory_Lang entity = new CrmFilesDirectory_Lang
							{
								LanguageID = item.LanguageID,
								FileDirectoryID = crmFilesDirectory.FileDirectoryID,
								Title = fileName
							};
							_dbTbl.CrmFilesDirectory_Lang.Add(entity);
							_dbTbl.SaveChanges();
						}
					}
					else
					{
						Exception e = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text10 + " ,directoryName: " + text9);
						ErrorSignal.FromCurrentContext().Raise(e);
						base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
						try
						{
							_dbTbl.CrmFilesDirectory.Remove(crmFilesDirectory);
							_dbTbl.SaveChanges();
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
						}
					}
				}
				else
				{
					Exception e3 = new Exception(Messages.msgErrorCreateFolderInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text10 + " ,directoryName: " + text9);
					ErrorSignal.FromCurrentContext().Raise(e3);
					base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
					try
					{
						_dbTbl.CrmFilesDirectory.Remove(crmFilesDirectory);
						_dbTbl.SaveChanges();
					}
					catch (Exception e4)
					{
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
				}
			}
			end_IL_0006:;
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
		return Content(text);
	}

	[DynamicAuthorize(ControllerName = "frmDyForm", ActionName = "actCheckRequestSubForm")]
	public ActionResult CheckRequestSubForm()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDyForm", ActionName = "actCheckRequest")]
	public ActionResult CheckRequestMainForm()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult SendIntMsgToChecker(int formId, int mValId, int workflowStepId, string checkerUserIds)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string registerTime = now.ToString("HH:mm:ss");
			string formName = DyForm.GetFormName(formId, result, result);
			string msgAttachRecDescI = "";
			if (workflowStepId != 0)
			{
				msgAttachRecDescI = DyForm.GetWorkflowStepTitle(workflowStepId, result, result);
			}
			bool flag = false;
			if (!string.IsNullOrEmpty(checkerUserIds))
			{
				string text3 = "";
				string text4 = "";
				string text5 = "";
				foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
				{
					string formName2 = DyForm.GetFormName(formId, result, item.LanguageID);
					text3 = "";
					text4 = "";
					text3 = string.Format(MyResource.GetResourceString("DyfrmCheckRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly), formName2);
					text4 = MyResource.GetResourceString("DyFrmReqCheckByName", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":" + formName2;
					text4 = text4 + "<BR><BR>" + MyResource.GetResourceString("DyfrmCheckRequestDbClickOnOtherInfo", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					text5 = text5 + "MsgSubj=" + text3 + "|@#@|MsgBody=" + text4 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
				}
				ObjectParameter objectParameter = new ObjectParameter("InsertedIntMsgId", 0);
				_db.CRMspDySendFormInternalMessages(mValId, workflowStepId, checkerUserIds, text5, formName, msgAttachRecDescI, 16, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter, centerId);
				flag = objectParameter.Value != null && (objectParameter.Value.ToString() ?? "0") != "-1";
			}
			if (flag)
			{
				PushNotif.NewIntMsgNotify();
				text2 = "";
				text = "ok";
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				text2 = Messages.msgErrorErrorSendingMessages;
				text = "";
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text2 = Messages.msgErrorRunFunction + "<br />" + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			text = "";
		}
		CommonResultViewModel<string> data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult SearchProducts(string text = "", int showMode = 0, int prdKind = 0, int companyId = 0, int projectId = 0)
	{
		List<WSspSearchProducts_Result> list = new List<WSspSearchProducts_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<WSspSearchProducts_Result>(Enumerable.Take<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(0, 0, text, text, 0, showMode, lCID, result, prdKind, 0, companyId, projectId, "", null), 800));
				foreach (WSspSearchProducts_Result item in list)
				{
					item.PrdLinkAccPrdCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(2, item.PrdLinkAccPrdCode);
					item.PrdLinkAccPrdIdStr = item.PName + "|" + item.PrdCode + "|" + item.PrdModel + "|" + item.PrdLatinName + "|" + item.PrdBarcode + "|" + item.PrdFirstBarcode + "|" + item.PrdLinkAccPrdCode + "|";
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
	public JsonResult SearchCompany(string text = "", int searchType = 1)
	{
		List<CRMspMainSearchWeb_Result> list = new List<CRMspMainSearchWeb_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(text))
			{
				string searchConditionMode = "";
				if (searchType == 1)
				{
					searchConditionMode = ",1000,1,2,3,8,9,11,12,14,17,20,21,22,";
				}
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				list = Enumerable.ToList<CRMspMainSearchWeb_Result>(Enumerable.Take<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)_dbI.CRMspMainSearchWeb(text, UserLogin.CurrentUser.UserId, searchType, lCID, result, searchConditionMode, result2), 800));
				foreach (CRMspMainSearchWeb_Result item in list)
				{
					item.cnvsDesc = item.cmpNameWithTitle + "|" + item.cmpNumber.GetValueOrDefault() + "|" + item.cmpPreTel + "|" + item.cmpTel + "|" + item.cmpPreTelII + "|" + item.cmpTelII + "|" + item.cmpMobile + "|" + item.cmpFax + "|" + item.cmpAddress + "|" + item.PrsName + "|" + item.prsTel + "|" + item.prsTelII + "|" + item.prsMobile + "|" + item.prsFax + "|" + item.prsNationalCode + "|" + item.cmpNationalCode + "|";
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
	public JsonResult SearchUsers(string text = "")
	{
		List<CRMspDySearchUsers_Result> list = new List<CRMspDySearchUsers_Result>();
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
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<CRMspDySearchUsers_Result>(Enumerable.Take<CRMspDySearchUsers_Result>((IEnumerable<CRMspDySearchUsers_Result>)_dbI.CRMspDySearchUsers(text, lCID, result, result2), 800));
				foreach (CRMspDySearchUsers_Result item in list)
				{
					item.TxtHelp = item.FullName + "|" + item.PersCode + "|" + item.UserName + "|" + item.Tel + "|" + item.Mobile + "|" + item.MobileII + "|" + item.Address + "|" + item.NationalCode + "|" + item.IdentityNumber + "|" + item.InsuranceCode + "|";
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
	public JsonResult SearchCompanyPersons(string text = "", int companyId = 0)
	{
		List<CRMspDySearchCompanyPersons_Result> list = new List<CRMspDySearchCompanyPersons_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<CRMspDySearchCompanyPersons_Result>(Enumerable.Take<CRMspDySearchCompanyPersons_Result>((IEnumerable<CRMspDySearchCompanyPersons_Result>)_dbI.CRMspDySearchCompanyPersons(companyId, text, userId, lCID, result, result2), 800));
				foreach (CRMspDySearchCompanyPersons_Result item in list)
				{
					item.TxtHelp = item.PersonName + "|" + item.prsMobile + "|" + item.prsEmail + "|" + item.prsEmailII + "|" + item.prsNationalCode + "|";
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
	public JsonResult SearchCompanyProjects(string text = "", int companyId = 0)
	{
		List<CRMspDySearchCompanyProjects_Result> list = new List<CRMspDySearchCompanyProjects_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<CRMspDySearchCompanyProjects_Result>(Enumerable.Take<CRMspDySearchCompanyProjects_Result>((IEnumerable<CRMspDySearchCompanyProjects_Result>)_dbI.CRMspDySearchCompanyProjects(companyId, 0, text, userId, lCID, result, result2), 800));
				foreach (CRMspDySearchCompanyProjects_Result item in list)
				{
					item.TxtHelp = item.ProjectTitle + "|";
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
	public JsonResult SearchCompanyConversations(string text = "", int companyId = 0, int projectId = 0)
	{
		List<CRMspDySearchCompanyConversations_Result> list = new List<CRMspDySearchCompanyConversations_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<CRMspDySearchCompanyConversations_Result>(Enumerable.Take<CRMspDySearchCompanyConversations_Result>((IEnumerable<CRMspDySearchCompanyConversations_Result>)_dbI.CRMspDySearchCompanyConversations(companyId, projectId, text, userId, lCID, result, result2), 800));
				foreach (CRMspDySearchCompanyConversations_Result item in list)
				{
					item.TxtHelp = item.cnvsDesc + "|" + item.ConversationId + "|";
					item.cnvsDate = (item.cnvsDateTime.HasValue ? item.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.cnvsDesc = "(" + item.ConversationId + " - " + item.cnvsTopic + " - " + item.cnvsDate + ")";
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
	public JsonResult SearchPreOrders(string text = "", int companyId = 0)
	{
		List<CRMspDySearchPreOrders_Result> list = new List<CRMspDySearchPreOrders_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<CRMspDySearchPreOrders_Result>(Enumerable.Take<CRMspDySearchPreOrders_Result>((IEnumerable<CRMspDySearchPreOrders_Result>)_dbI.CRMspDySearchPreOrders(companyId, text, userId, lCID, result, result2), 800));
				foreach (CRMspDySearchPreOrders_Result item in list)
				{
					item.TxtHelp = item.pordNumber + "|" + item.pordLinkAccPreOrderNumber + "|";
					item.pordDate = (item.pordDateTime.HasValue ? item.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.PordInfo = "(" + item.PordInfo + " - " + item.pordDate + ")";
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
	public JsonResult SearchOrders(string text = "", int companyId = 0)
	{
		List<CRMspDySearchOrders_Result> list = new List<CRMspDySearchOrders_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<CRMspDySearchOrders_Result>(Enumerable.Take<CRMspDySearchOrders_Result>((IEnumerable<CRMspDySearchOrders_Result>)_dbI.CRMspDySearchOrders(companyId, text, userId, lCID, result, result2), 800));
				foreach (CRMspDySearchOrders_Result item in list)
				{
					item.TxtHelp = item.ordNumber + "|" + item.ordLinkAccOrderNumber + "|";
					item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.OrdInfo = "(" + item.OrdInfo + " - " + item.ordDate + ")";
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
	public JsonResult SearchBuyOrders(string text = "", int companyId = 0)
	{
		List<CRMspDySearchBuyOrders_Result> list = new List<CRMspDySearchBuyOrders_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<CRMspDySearchBuyOrders_Result>(Enumerable.Take<CRMspDySearchBuyOrders_Result>((IEnumerable<CRMspDySearchBuyOrders_Result>)_dbI.CRMspDySearchBuyOrders(companyId, text, userId, lCID, result, result2), 800));
				foreach (CRMspDySearchBuyOrders_Result item in list)
				{
					item.TxtHelp = item.bordNumber + "|" + item.bordLinkAccBuyOrderNumber + "|";
					item.bordDate = (item.bordDateTime.HasValue ? item.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.BordInfo = "(" + item.BordInfo + " - " + item.bordDate + ")";
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
	public JsonResult SearchDocs(string text = "", int companyId = 0, int oprType = 0)
	{
		List<CRMspDySearchDocsByType_Result> list = new List<CRMspDySearchDocsByType_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<CRMspDySearchDocsByType_Result>(Enumerable.Take<CRMspDySearchDocsByType_Result>((IEnumerable<CRMspDySearchDocsByType_Result>)_dbI.CRMspDySearchDocsByType(companyId, oprType, text, userId, lCID, result, result2), 800));
				foreach (CRMspDySearchDocsByType_Result item in list)
				{
					item.TxtHelp = item.DocNumber + "|" + item.DocLinkAccDocNumber + "|";
					item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.DocInfo = "(" + item.DocInfo + " - " + item.DocDate + ")";
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
	public JsonResult SearchStockSupplies(string text = "")
	{
		List<CRMspDySearchStockSupplies_Result> list = new List<CRMspDySearchStockSupplies_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<CRMspDySearchStockSupplies_Result>(Enumerable.Take<CRMspDySearchStockSupplies_Result>((IEnumerable<CRMspDySearchStockSupplies_Result>)_dbIII.CRMspDySearchStockSupplies(text, userId, lCID, result, result2), 800));
				foreach (CRMspDySearchStockSupplies_Result item in list)
				{
					item.stsupDate = ((item.stsupDate != null) ? item.stsupDateTime.ToString("yyyy/MM/dd") : "");
					item.StockSupplyInfo = "(" + item.StockSupplyInfo + " - " + item.stsupDate + ")";
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
	public JsonResult SearchLetters(string text = "", int companyId = 0, int letterTypeId = 0)
	{
		List<CRMspDySearchLettersByType_Result> list = new List<CRMspDySearchLettersByType_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<CRMspDySearchLettersByType_Result>(Enumerable.Take<CRMspDySearchLettersByType_Result>((IEnumerable<CRMspDySearchLettersByType_Result>)_dbI.CRMspDySearchLettersByType(companyId, letterTypeId, text, userId, lCID, result, result2), 800));
				foreach (CRMspDySearchLettersByType_Result item in list)
				{
					_ = item.LetterNumber;
					item.TxtHelp = item.LetterNumber + "|" + (item.LetterNumberII.HasValue ? item.LetterNumberII.GetValueOrDefault().ToString() : "") + "|";
					_ = item.LetterDateTime;
					item.LetterDate = item.LetterDateTime.ToString("yyyy/MM/dd");
					item.LetterInfo = "(" + item.LetterInfo + " - " + item.LetterDate + ")";
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
	public JsonResult SearchCmsPages(string text = "")
	{
		List<CRMspDySearchCmsPages_Result> list = new List<CRMspDySearchCmsPages_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = UserLogin.CurrentUser.UserId;
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<CRMspDySearchCmsPages_Result>(Enumerable.Take<CRMspDySearchCmsPages_Result>((IEnumerable<CRMspDySearchCmsPages_Result>)_dbI.CRMspDySearchCmsPages(text, lCID, result), 800));
				foreach (CRMspDySearchCmsPages_Result item in list)
				{
					item.TxtHelp = item.PageName + "|" + item.PageTitle + "|";
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

	[ValidateAntiForgeryToken]
	public ActionResult ActAddFileField(HttpPostedFileBase addFileField, int mainFormId, int formId, int fieldId)
	{
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			CRMspDySelectFormFields_Result cRMspDySelectFormFields_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)_db.CRMspDySelectFormFields(fieldId, 0, 0, lCID, result));
			if (addFileField != null && cRMspDySelectFormFields_Result != null)
			{
				string text2 = ((!string.IsNullOrWhiteSpace(cRMspDySelectFormFields_Result.UploadFileExtension)) ? cRMspDySelectFormFields_Result.UploadFileExtension : "*");
				addFileField.ContentType.ToLower();
				string text3 = ((addFileField.FileName != null) ? Path.GetExtension(addFileField.FileName).ToLower() : "");
				if (text2 != "*" && !string.IsNullOrEmpty(text2) && text2.IndexOf(text3, StringComparison.Ordinal) < 0)
				{
					text += string.Format(Messages.msgErrorMessageFileExtension, text2);
				}
				else
				{
					string text4 = (text3 ?? "").ToLower();
					text4 = text4.Replace(".", "");
					if (Configuration.MaliciousFileExtensions.Contains(text4))
					{
						text += Messages.msgErrorFileIsExecuted;
					}
					else
					{
						int num = cRMspDySelectFormFields_Result.UploadFileMaxSize.GetValueOrDefault() * 1024;
						if (addFileField.ContentLength > num)
						{
							string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(addFileField.ContentLength);
							string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num);
							string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
							text += string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2);
						}
						else
						{
							string text5 = Configuration.HostTempFilesPath + "/" + Configuration.DyFormFileTmpDirectoryPath;
							string text6 = base.Server.MapPath(text5);
							if (!System.IO.Directory.Exists(text6))
							{
								System.IO.Directory.CreateDirectory(text6);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
							}
							string text7 = base.Server.MapPath(text5 + userId + "/");
							if (!System.IO.Directory.Exists(text7))
							{
								System.IO.Directory.CreateDirectory(text7);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
							}
							text7 = base.Server.MapPath(text5 + userId + "/" + mainFormId + "/");
							if (!System.IO.Directory.Exists(text7))
							{
								System.IO.Directory.CreateDirectory(text7);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
							}
							string text8 = Path.GetFileName(addFileField.FileName);
							if (text8 != null && text8.Length < Configuration.FileDirectoryTitleLength)
							{
								string text9 = Path.Combine(text7, text8);
								if (System.IO.File.Exists(text9))
								{
									text8 = DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + text8;
									text9 = Path.Combine(text7, text8);
								}
								addFileField.SaveAs(text9);
								ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
								_dbI.CRMspInsertFilesDirectoryTemplate(text8, text9, userId, 3, -65, null, mainFormId, fieldId, now, registerDatePersian, appType, result, objectParameter);
								int result2 = 0;
								if (objectParameter != null)
								{
									int.TryParse(objectParameter.Value.ToString(), out result2);
								}
								string text10 = "";
								if (result2 != 0)
								{
									text10 = "[{&quot;FileId&quot;:" + result2 + ",&quot;FileName&quot;:&quot;" + text8 + "&quot;}]";
									text = "true|" + text10;
								}
								else
								{
									text = Messages.msgErrorUploadFile;
								}
							}
							else
							{
								text = string.Format(Messages.msgErrorLengthFileName, Configuration.FileDirectoryTitleLength.ToString());
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
		return Content(text);
	}

	public FileResult GetFilePathTmp(int fileId)
	{
		string text = "";
		string contentType = "";
		try
		{
			CRMspSelectFilesDirectoryTemplateById_Result cRMspSelectFilesDirectoryTemplateById_Result = Enumerable.FirstOrDefault<CRMspSelectFilesDirectoryTemplateById_Result>((IEnumerable<CRMspSelectFilesDirectoryTemplateById_Result>)_dbI.CRMspSelectFilesDirectoryTemplateById(fileId));
			if (cRMspSelectFilesDirectoryTemplateById_Result != null)
			{
				text = cRMspSelectFilesDirectoryTemplateById_Result.CopyFromPath ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					contentType = MimeMapping.GetMimeMapping(text);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return File(text, contentType);
	}

	public string DeleteFilePathTmp(int fileId)
	{
		string result = "-1";
		try
		{
			CRMspSelectFilesDirectoryTemplateById_Result cRMspSelectFilesDirectoryTemplateById_Result = Enumerable.FirstOrDefault<CRMspSelectFilesDirectoryTemplateById_Result>((IEnumerable<CRMspSelectFilesDirectoryTemplateById_Result>)_dbI.CRMspSelectFilesDirectoryTemplateById(fileId));
			if (cRMspSelectFilesDirectoryTemplateById_Result != null)
			{
				string text = Configuration.HostTempFilesPath + "/" + Configuration.DyFormFileTmpDirectoryPath;
				base.Server.MapPath(text + UserLogin.CurrentUser.UserId + "/");
				if (!string.IsNullOrWhiteSpace(cRMspSelectFilesDirectoryTemplateById_Result.CopyFromPath) && System.IO.File.Exists(cRMspSelectFilesDirectoryTemplateById_Result.CopyFromPath))
				{
					System.IO.File.Delete(cRMspSelectFilesDirectoryTemplateById_Result.CopyFromPath);
				}
				_dbI.CRMspDeleteFilesDirectoryTemplate(fileId);
				result = Messages.frmDeleteSuccessMessage;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[ValidateAntiForgeryToken]
	public ActionResult ActAddFileDigitalSignature(HttpPostedFileBase addDigiSignFileField, int mainFormId, int formId, int fieldId)
	{
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = UserLogin.CurrentUser.UserId;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			CRMspDySelectFormFields_Result cRMspDySelectFormFields_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)_db.CRMspDySelectFormFields(fieldId, 0, 0, lCID, result));
			if (addDigiSignFileField != null && cRMspDySelectFormFields_Result != null)
			{
				string extensionFileSizeDyFormDigitalSignature = Configuration.ExtensionFileSizeDyFormDigitalSignature;
				addDigiSignFileField.ContentType.ToLower();
				string text2 = ((addDigiSignFileField.FileName != null) ? Path.GetExtension(addDigiSignFileField.FileName).ToLower() : "");
				if (extensionFileSizeDyFormDigitalSignature != "*" && !string.IsNullOrEmpty(extensionFileSizeDyFormDigitalSignature) && extensionFileSizeDyFormDigitalSignature.IndexOf(text2, StringComparison.Ordinal) < 0)
				{
					text += string.Format(Messages.msgErrorMessageFileExtension, extensionFileSizeDyFormDigitalSignature);
				}
				else
				{
					string text3 = (text2 ?? "").ToLower();
					text3 = text3.Replace(".", "");
					if (Configuration.MaliciousFileExtensions.Contains(text3))
					{
						text += Messages.msgErrorFileIsExecuted;
					}
					else
					{
						int maxFileSizeDyFormDigitalSignature = Configuration.MaxFileSizeDyFormDigitalSignature;
						int num = maxFileSizeDyFormDigitalSignature * 1024;
						if (addDigiSignFileField.ContentLength > num)
						{
							string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(addDigiSignFileField.ContentLength);
							string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num);
							string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
							text += string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2);
						}
						else
						{
							byte[] array = ImageManager.CompressHttpPostedFileBase(new ImageManager.ImageParam
							{
								HttpPostedFileBase_Var = addDigiSignFileField,
								MinSizeForCompress = maxFileSizeDyFormDigitalSignature
							});
							string text4 = string.Concat(Enumerable.Select<byte, string>((IEnumerable<byte>)array, (Func<byte, string>)((byte b) => b.ToString("X2"))));
							string text5 = System.Convert.ToBase64String(array);
							string text6 = "[{&quot;FileContent&quot;:&quot;" + text4 + "&quot;,&quot;FileContentImg&quot;:&quot;" + text5 + "&quot;}]";
							text = "true|" + text6;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Content(text);
	}

	public string UpdateSystemPartByLinkDbObject(int formId, int mValId, string itemJson)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			if (!UserLogin.IsUserAccess("frmDyForm", "actCanSendDataInNotVerifyForm", UserLogin.CurrentUser) && !DyForm.IsChecked(mValId))
			{
				result = Messages.msgErrorCanSendDataInNotVerifyForm;
				return result;
			}
			if (!string.IsNullOrWhiteSpace(itemJson))
			{
				List<FieldLinkDbObjectViewModel> list = new List<FieldLinkDbObjectViewModel>();
				list = new JavaScriptSerializer().Deserialize<List<FieldLinkDbObjectViewModel>>(itemJson);
				if (list != null)
				{
					if (Enumerable.Any<FieldLinkDbObjectViewModel>((IEnumerable<FieldLinkDbObjectViewModel>)list))
					{
						int num = 0;
						string text = "";
						List<CRMspDySelectFormFieldsByParentFormId_Result> list2 = Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)_dbI.CRMspDySelectFormFieldsByParentFormId(formId, lCID, defLangID));
						foreach (FieldLinkDbObjectViewModel item in list)
						{
							int num2 = 0;
							int linkDbObjectId = 0;
							if (list2 != null && Enumerable.Any<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list2))
							{
								CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list2, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == item.FFId));
								if (cRMspDySelectFormFieldsByParentFormId_Result != null)
								{
									num2 = cRMspDySelectFormFieldsByParentFormId_Result.FieldTypeId.GetValueOrDefault();
									linkDbObjectId = cRMspDySelectFormFieldsByParentFormId_Result.LinkDbObjectId.GetValueOrDefault();
								}
							}
							string text2 = CheckErrorLinkDbObject(linkDbObjectId, mValId, item.Val ?? "");
							if (!string.IsNullOrWhiteSpace(text2))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text2;
								num++;
							}
							if (!string.IsNullOrWhiteSpace(item.Val) && num2 == 4)
							{
								item.Val = item.Val.Replace("/", "").Replace("-", "").Replace("\\", "")
									.Replace(" ", "")
									.Replace("_", "");
								string formatetdDate = PersianDate.GetFormatetdDate(item.Val.Replace("/", ""));
								switch (lCID)
								{
								case 1065:
								{
									DateTime dateTime3 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
									item.Val = dateTime3.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
									break;
								}
								case 1025:
								{
									DateTime dateTime2 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
									item.Val = dateTime2.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
									break;
								}
								default:
								{
									DateTime dateTime = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
									item.Val = dateTime.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
									break;
								}
								}
							}
							if (!string.IsNullOrWhiteSpace(item.Val_Ln))
							{
								List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
								list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.Val_Ln);
								list3.Add(new CommonMultiLanguageViewModel
								{
									Value = item.Val,
									LanguageId = lCID
								});
								item.Val = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
								item.Val_Ln = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
							}
						}
						if (num != 0)
						{
							result = (string.IsNullOrWhiteSpace(text) ? Messages.ErrorNotFound : text);
						}
						else
						{
							itemJson = JsonConvert.SerializeObject(Enumerable.ToList<FieldLinkDbObjectViewModel>((IEnumerable<FieldLinkDbObjectViewModel>)list));
							ObjectParameter objectParameter = new ObjectParameter("result", 0);
							ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
							_dbII.CRMspDyUpdateSystemPartByLinkDbObject(mValId, itemJson, userId, now, registerDatePersian, value2, value, appType, defLangID, objectParameter, objectParameter2);
							int result2 = 0;
							if (objectParameter != null && objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
							{
								int.TryParse(objectParameter.Value.ToString(), out result2);
							}
							if (result2 == 1)
							{
								result = "1";
							}
							else if (objectParameter2 != null && objectParameter2.Value != null && !string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
							{
								result = objectParameter2.Value.ToString();
							}
						}
					}
					else
					{
						result = Messages.msgNoItemSelected;
					}
				}
				else
				{
					result = Messages.msgNoItemSelected;
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string CheckErrorLinkDbObject(int linkDbObjectId, int mValId, string val)
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
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userLastCId = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
			}
			int result2 = 0;
			int result3 = 0;
			int titleId = 0;
			int cityId = 0;
			int num = 0;
			CompanyInfoController companyInfoController = new CompanyInfoController();
			CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(mValId, lCID, result));
			if (cRMspDySelectFormFieldMasterValueWithId_Result != null)
			{
				int.TryParse(cRMspDySelectFormFieldMasterValueWithId_Result.CompanyId.ToString(), out result2);
				int.TryParse(cRMspDySelectFormFieldMasterValueWithId_Result.CompanyPersonId.ToString(), out result3);
				if (result2 != 0)
				{
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(result2);
					if (companyById != null)
					{
						if (result3 == 0)
						{
							int.TryParse(companyById.cmpMainPersonId.ToString(), out result3);
						}
						_ = companyById.cmpName;
						titleId = companyById.cmpTitleId.GetValueOrDefault();
						cityId = companyById.cmpCityId.GetValueOrDefault();
						num = companyById.cmpKind.GetValueOrDefault();
					}
				}
			}
			if (linkDbObjectId != 0 && !string.IsNullOrWhiteSpace(val))
			{
				CRMspSelectSysDBObjectsByIds_Result cRMspSelectSysDBObjectsByIds_Result = Enumerable.FirstOrDefault<CRMspSelectSysDBObjectsByIds_Result>((IEnumerable<CRMspSelectSysDBObjectsByIds_Result>)_dbII.CRMspSelectSysDBObjectsByIds(linkDbObjectId.ToString(), ",", lCID, result));
				if (cRMspSelectSysDBObjectsByIds_Result != null)
				{
					string text2 = (cRMspSelectSysDBObjectsByIds_Result.DBObjectName ?? "").ToLower();
					string text3 = (cRMspSelectSysDBObjectsByIds_Result.FieldName ?? "").ToLower();
					if (text2 == "crmcompany")
					{
						switch (text3)
						{
						case "cmpname":
						{
							if (!(val != Labels.lblPerson) || !(val != "شخص"))
							{
								break;
							}
							CRMspCheckDuplicateCompanyViewModel cRMspCheckDuplicateCompanyViewModel = CRMIdeal.Classes.Helper.Company.CheckDuplicateCompany(1, result2, val, titleId, cityId, userId);
							if (cRMspCheckDuplicateCompanyViewModel != null)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += string.Format(Messages.CheckcmpNameDuplicate, cRMspCheckDuplicateCompanyViewModel.cmpName, cRMspCheckDuplicateCompanyViewModel.Title, cRMspCheckDuplicateCompanyViewModel.City, cRMspCheckDuplicateCompanyViewModel.cmpNumber);
							}
							break;
						}
						case "cmptel":
						{
							if (val.Substring(0, 2) == "09")
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += Messages.CheckcmpPreTelMobile;
							}
							bool flag = true;
							for (int i = 0; i < val.Length; i++)
							{
								if (!char.IsDigit(val[i]))
								{
									flag = false;
								}
							}
							if (!flag)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += Messages.CheckNrmbercmpTel;
							}
							string text7 = companyInfoController.CantSaveDupTel(val, 1, result2);
							if (!string.IsNullOrWhiteSpace(text7))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text7;
							}
							break;
						}
						case "cmptelii":
						{
							if (val.Substring(0, 2) == "09")
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += Messages.CheckcmpPreTelIIMobile;
							}
							bool flag3 = true;
							for (int k = 0; k < val.Length; k++)
							{
								if (!char.IsDigit(val[k]))
								{
									flag3 = false;
								}
							}
							if (!flag3)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += Messages.CheckNrmbercmpTelII;
							}
							string text11 = companyInfoController.CantSaveDupTel(val, 1, result2);
							if (!string.IsNullOrWhiteSpace(text11))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text11;
							}
							break;
						}
						case "cmpfax":
						{
							bool flag2 = true;
							for (int j = 0; j < val.Length; j++)
							{
								if (!char.IsDigit(val[j]))
								{
									flag2 = false;
								}
							}
							if (!flag2)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += Messages.CheckNrmbercmpFax;
							}
							string text8 = companyInfoController.CantSaveDupFax(val, 1, result2);
							if (!string.IsNullOrWhiteSpace(text8))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text8;
							}
							break;
						}
						case "cmpzipcode":
						{
							string text10 = companyInfoController.CantSaveDupZipCode(val, 1, result2);
							if (!string.IsNullOrWhiteSpace(text10))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text10;
							}
							break;
						}
						case "cmpemail":
						{
							string text12 = companyInfoController.CantSaveDupCmpEmail(val, result2);
							if (!string.IsNullOrWhiteSpace(text12))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text12;
							}
							break;
						}
						case "cmpeconomiccode":
						{
							if (num != 0)
							{
								break;
							}
							string text9 = companyInfoController.CantSaveDupCmpEconomicCode(val, result2);
							if (!string.IsNullOrWhiteSpace(text9))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text9;
							}
							break;
						}
						case "cmpnationalcode":
						{
							string foundedCmpCIds = "";
							int foundedCmpId = 0;
							string text4 = companyInfoController.CantSaveDupCmpNationalCode(ref foundedCmpCIds, ref foundedCmpId, val, result2);
							if (string.IsNullOrWhiteSpace(text4))
							{
								break;
							}
							if (Enumerable.FirstOrDefault<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)foundedCmpCIds.Split(new char[1] { ',' })), (Func<string, bool>)((string x) => x == userLastCId.ToString())) != null || !Center.HaveModule || Center.TotalCnt == 1)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text4;
								break;
							}
							new List<SelectListItem>();
							string text5 = CRMIdeal.Classes.Helper.User.AccessUserToCIds(foundedCmpCIds);
							string text6 = "";
							text6 = (string.IsNullOrWhiteSpace(text5) ? ((result2 == 0) ? string.Format(Messages.msgFoundCompanyInOtherCenterAskToAddUserNoAccess, Center.GetNames(userLastCId.ToString())) : Messages.msgFoundCompanyInOtherCenterUserNoAccess) : ((result2 == 0) ? string.Format(Messages.msgFoundCompanyInOtherCenterAskToAdd, Center.GetNames(text5), Center.GetNames(userLastCId.ToString())) : string.Format(Messages.msgFoundCompanyInOtherCenter, Center.GetNames(text5))));
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += "<br>";
							}
							text += text6;
							break;
						}
						}
					}
					if (text2 == "crmcompanypersons")
					{
						switch (text3)
						{
						case "prsmobile":
						{
							int mobNumLen = CRMIdeal.Classes.Helper.Setting.GetMobNumLen();
							bool mobNumLenNoCheck = CRMIdeal.Classes.Helper.Setting.GetMobNumLenNoCheck();
							if (val.Length != mobNumLen && !mobNumLenNoCheck)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += Messages.CheckprsMobile;
							}
							if (val.Length >= 2 && val.Substring(0, 2) != "09" && !mobNumLenNoCheck)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += Messages.CheckprsMobileFormat;
							}
							string text15 = companyInfoController.CantSaveDupPrsMob(val, result3);
							if (!string.IsNullOrWhiteSpace(text15) && text15.Substring(0, 1) == "1")
							{
								text15 = text15.Substring(1, text15.Length - 1);
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text15;
							}
							long result4 = 0L;
							long.TryParse(val, out result4);
							if (result4 == 0L)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += Messages.CheckprsMobileDigit;
							}
							break;
						}
						case "prstel":
						{
							long result6 = 0L;
							long.TryParse(val, out result6);
							if (result6 == 0L)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += Messages.CheckprsTelDigit;
							}
							string text21 = companyInfoController.CantSaveDupTel(val, 2, result3);
							if (!string.IsNullOrWhiteSpace(text21))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text21;
							}
							break;
						}
						case "prstelii":
						{
							long result5 = 0L;
							long.TryParse(val, out result5);
							if (result5 == 0L)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += Messages.CheckprsTelIIoDigit;
							}
							string text16 = companyInfoController.CantSaveDupTel(val, 2, result3);
							if (!string.IsNullOrWhiteSpace(text16))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text16;
							}
							break;
						}
						case "prsfax":
						{
							long result7 = 0L;
							long.TryParse(val, out result7);
							if (result7 == 0L)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += Messages.CheckprsFaxDigit;
							}
							string text22 = companyInfoController.CantSaveDupFax(val, 2, result3);
							if (!string.IsNullOrWhiteSpace(text22))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text22;
							}
							break;
						}
						case "prszipcode":
						{
							string text14 = companyInfoController.CantSaveDupZipCode(val, 2, result3);
							if (!string.IsNullOrWhiteSpace(text14))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text14;
							}
							break;
						}
						case "prsnationalcode":
						{
							string foundedPrsCIds = "";
							int foundedPrsId = 0;
							int foundedCmpId2 = 0;
							string text17 = companyInfoController.CantSaveDupPrsNationalCode(ref foundedPrsCIds, ref foundedPrsId, val, result3, ref foundedCmpId2);
							if (string.IsNullOrEmpty(text17))
							{
								break;
							}
							if (Enumerable.FirstOrDefault<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)foundedPrsCIds.Split(new char[1] { ',' })), (Func<string, bool>)((string x) => x == userLastCId.ToString())) != null || !Center.HaveModule || Center.TotalCnt == 1)
							{
								if (!string.IsNullOrWhiteSpace(text17))
								{
									if (!string.IsNullOrWhiteSpace(text))
									{
										text += "<br>";
									}
									text += text17;
								}
								break;
							}
							new List<SelectListItem>();
							string text18 = CRMIdeal.Classes.Helper.User.AccessUserToCIds(foundedPrsCIds);
							string text19 = "";
							text19 = (string.IsNullOrWhiteSpace(text18) ? ((result3 == 0) ? string.Format(Messages.msgFoundPersonInOtherCenterAskToAddUserNoAccess, Center.GetNames(userLastCId.ToString())) : Messages.msgFoundPersonInOtherCenterUserNoAccess) : ((result3 == 0) ? string.Format(Messages.msgFoundPersonInOtherCenterAskToAdd, Center.GetNames(text18), Center.GetNames(userLastCId.ToString())) : string.Format(Messages.msgFoundPersonInOtherCenter, Center.GetNames(text18))));
							if (!string.IsNullOrWhiteSpace(text19))
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text19;
							}
							break;
						}
						case "prsemail":
						{
							string text20 = companyInfoController.CantSaveDupPrsEmail(val, result3, 1);
							if (!string.IsNullOrWhiteSpace(text20) && text20.Substring(0, 1) == "1")
							{
								text20 = text20.Substring(1, text20.Length - 1);
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text20;
							}
							break;
						}
						case "prsemailii":
						{
							string text13 = companyInfoController.CantSaveDupPrsEmail(val, result3, 2);
							if (!string.IsNullOrWhiteSpace(text13) && text13.Substring(0, 1) == "1")
							{
								text13 = text13.Substring(1, text13.Length - 1);
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += "<br>";
								}
								text += text13;
							}
							break;
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
		return text;
	}

	public ActionResult SysPartDyForm(int position = 1, int? cmpId = null, int? prsId = null, int? prjId = null, int? cnvsId = null, int? mObjId = null, int? dObjId = null, int? subObjId = null, int? mValId = null, int? workflowStepId = null, int dyInPopup = 0, int crmSysPartId = 0, int foSysPartId = 0, int oprMode = 0, string frameName = "", int sysPartDyFormId = 0, int tempDataId = 0, int tempDataSysPartIdI = 0)
	{
		SelectSysPartDyFormViewModel model = new SelectSysPartDyFormViewModel();
		try
		{
			model = new SelectSysPartDyFormViewModel
			{
				CrmSysPartId = crmSysPartId,
				FoSysPartId = foSysPartId,
				Position = position,
				CompanyId = cmpId,
				CompanyPersonId = prsId,
				ProjectId = prjId,
				ConversationId = cnvsId,
				MasterObjectId = mObjId,
				DetailObjectId = dObjId,
				SubDetailObjectId = subObjId,
				MasterValueId = mValId.GetValueOrDefault(),
				WorkflowStepId = workflowStepId,
				DyInPopup = dyInPopup,
				OprMode = oprMode,
				FrameName = frameName,
				SysPartDyFormId = sysPartDyFormId,
				TempDataId = tempDataId,
				TempDataSysPartIdI = tempDataSysPartIdI
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.IsBuying = VersionBuyer.DyForm;
		return View(model);
	}

	[HttpPost]
	public string GetSysPartDyForms(int crmSysPart, int foSysPart, string selectedId = "")
	{
		string result = "";
		try
		{
			List<CRMspDySelectFormsMenuWithSysPartId_Result> list = DyForm.CreateMenu(crmSysPart, foSysPart);
			if (list != null)
			{
				List<CRMspDySelectFormsMenuWithSysPartId_Result> list2 = new List<CRMspDySelectFormsMenuWithSysPartId_Result>();
				CRMspDySelectFormsMenuWithSysPartId_Result item2 = new CRMspDySelectFormsMenuWithSysPartId_Result
				{
					FormId = -1,
					FormName = Labels.SelectedListDefValue
				};
				list2.Add(item2);
				list2.AddRange(list);
				if (list2 != null && Enumerable.Any<CRMspDySelectFormsMenuWithSysPartId_Result>((IEnumerable<CRMspDySelectFormsMenuWithSysPartId_Result>)list2))
				{
					result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspDySelectFormsMenuWithSysPartId_Result, nComboBoxListItem>((IEnumerable<CRMspDySelectFormsMenuWithSysPartId_Result>)list2, (Func<CRMspDySelectFormsMenuWithSysPartId_Result, nComboBoxListItem>)((CRMspDySelectFormsMenuWithSysPartId_Result item) => new nComboBoxListItem
					{
						Text = item.FormName,
						Value = item.FormId.ToString(),
						Selected = (item.FormId.ToString() == selectedId)
					}))));
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
	[AjaxOnly]
	[AllowAnonymous]
	[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
	public JsonResult InsertEditDyFormInTempData(string dyformVal, int tempDataId = 0, int tempDataSysPartIdI = 0)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edf: Unknown result type (might be due to invalid IL or missing references)
		string data = "";
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		try
		{
			CrmDyFormFieldValuesLanguageViewModel model = new CrmDyFormFieldValuesLanguageViewModel();
			if (!string.IsNullOrWhiteSpace(dyformVal))
			{
				model = new JavaScriptSerializer().Deserialize<CrmDyFormFieldValuesLanguageViewModel>(dyformVal);
			}
			int result;
			int currLangID;
			int? centerId;
			int num;
			int result2;
			List<CRMspDySelectFormFieldsByParentFormId_Result> list;
			List<CRMspDySelectFormAndSubForms_Result> list2;
			if (model != null)
			{
				if (!string.IsNullOrWhiteSpace(model.ValueDetails))
				{
					model.ValueDetails = model.ValueDetails.Replace("$*", "/");
				}
				if (!string.IsNullOrWhiteSpace(model.ValueDetails_Lang))
				{
					model.ValueDetails_Lang = model.ValueDetails_Lang.Replace("$*", "/");
				}
				_ = DateTime.Now;
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out result);
				if (result <= 0)
				{
					result = 1065;
				}
				currLangID = Thread.CurrentThread.CurrentCulture.LCID;
				centerId = null;
				num = 0;
				CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
				if (currentUser != null)
				{
					centerId = currentUser.UserLastCId;
					num = currentUser.UserId;
				}
				result2 = 0;
				list = new List<CRMspDySelectFormFieldsByParentFormId_Result>();
				list2 = new List<CRMspDySelectFormAndSubForms_Result>();
				if (model.MasterValueId > 0 || VersionBuyer.DyForm)
				{
					goto IL_024d;
				}
				DbSet<CrmDyFormFieldMasterValues> crmDyFormFieldMasterValues = _dbTbl.CrmDyFormFieldMasterValues;
				ParameterExpression val = Expression.Parameter(typeof(CrmDyFormFieldMasterValues), "c");
				if (!Queryable.Any<CrmDyFormFieldMasterValues>((IQueryable<CrmDyFormFieldMasterValues>)crmDyFormFieldMasterValues, Expression.Lambda<Func<CrmDyFormFieldMasterValues, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					goto IL_024d;
				}
				base.ViewBag.Error = "BV|" + Messages.VersionBuy;
				text = "BV|" + Messages.VersionBuy;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
			}
			else
			{
				text = Messages.ErrorNotFound;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
			}
			goto end_IL_000e;
			IL_118e:
			int num2 = SysTempData.InsertUpdate(new CrmsysTempDataViewModel
			{
				TempDataId = tempDataId,
				TempDataUserId = num,
				TempDataSysPartIdI = tempDataSysPartIdI,
				TempDataSysPartObjIdI = -1,
				TempDataSysPartIdII = 170,
				TempDataSysPartObjIdII = model.FormId,
				TempDataValue = dyformVal
			});
			if (num2 > 0)
			{
				data = num2.ToString();
				text = Messages.msgInfoTemporarilyRecorded;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				data = "";
				text = Messages.msgErrorRunFunction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			goto end_IL_000e;
			IL_073c:
			int value = 0;
			new CRMspDySelectFormFieldMasterValueWithId_Result();
			bool flag = true;
			if (model.MasterValueId != 0)
			{
				value = 0;
				flag = false;
			}
			if (!UserLogin.IsUserAccess("frmDyForm", "actCanEditDyFormNumber", UserLogin.CurrentUser))
			{
				model.DyFormNumber = null;
			}
			List<CRMspDySelectFormFieldValuesByMasterValueId_Result> list3 = new List<CRMspDySelectFormFieldValuesByMasterValueId_Result>();
			if (list == null || !Enumerable.Any<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list))
			{
				goto IL_118e;
			}
			string text2 = "";
			int num3 = 0;
			List<CRMspDySelectFormFieldsByParentFormId_Result> list4 = new List<CRMspDySelectFormFieldsByParentFormId_Result>();
			if (!(model.WdSubFormId > 0) || !(model.WorkflowStepId > 0))
			{
				list4 = ((result2 <= 0) ? Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.IsRequired.GetValueOrDefault()))) : Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormId == model.FormId && m.IsRequired.GetValueOrDefault()))));
			}
			else
			{
				CRMspDySelectFormWorkflowStepBFCurr_Result wdetail = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepBFCurr_Result>((IEnumerable<CRMspDySelectFormWorkflowStepBFCurr_Result>)_db.CRMspDySelectFormWorkflowStepBFCurr(result2, model.WorkflowStepId, value, model.WdSubFormId, currLangID, result));
				list4 = ((wdetail == null) ? Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormId == model.WdSubFormId && m.IsRequired.GetValueOrDefault()))) : Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormId == wdetail.SubFormId && m.IsRequired.GetValueOrDefault()))));
			}
			if (list4 == null || !Enumerable.Any<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list4))
			{
				goto IL_118e;
			}
			List<IdKeyValueItemViewModel> list5;
			List<IdKeyValueItemViewModel> list6;
			foreach (IdKeyValueItemViewModel obj in list5)
			{
				string ids = obj.Id ?? "";
				int formId = 0;
				int fieldId = 0;
				long fieldRepeatId = 0L;
				if (ids != "")
				{
					ids = ids.Replace("_Rep", "");
					string[] array = ids.Split(new char[1] { '_' });
					if (array != null)
					{
						formId = int.Parse(array[0]);
						fieldId = int.Parse(array[1]);
						if (array.Length > 2)
						{
							fieldRepeatId = long.Parse(array[2]);
						}
					}
				}
				CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list4, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == fieldId));
				if (cRMspDySelectFormFieldsByParentFormId_Result == null)
				{
					continue;
				}
				if (result2 == 0)
				{
					CRMspDySelectFormAndSubForms_Result cRMspDySelectFormAndSubForms_Result = Enumerable.FirstOrDefault<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list2, (Func<CRMspDySelectFormAndSubForms_Result, bool>)((CRMspDySelectFormAndSubForms_Result m) => m.FormId == formId));
					if (cRMspDySelectFormAndSubForms_Result != null)
					{
						bool flag2 = true;
						bool flag3 = false;
						if (cRMspDySelectFormAndSubForms_Result.EnableForRollId.HasValue)
						{
							flag2 = cRMspDySelectFormAndSubForms_Result.EnableForRollId == UserLogin.CurrentUser.RollId || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser);
						}
						else if (!string.IsNullOrEmpty(cRMspDySelectFormAndSubForms_Result.EnableForUsersId))
						{
							string[] array2 = cRMspDySelectFormAndSubForms_Result.EnableForUsersId.Split(new char[1] { '|' });
							if (Enumerable.Any<string>((IEnumerable<string>)array2))
							{
								foreach (string item in Enumerable.Where<string>((IEnumerable<string>)array2, (Func<string, bool>)((string usr) => !string.IsNullOrEmpty(usr))))
								{
									if (!flag3)
									{
										if (item == UserLogin.CurrentUser.UserId.ToString() || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
										{
											flag2 = true;
											flag3 = true;
										}
										else
										{
											flag2 = false;
										}
									}
								}
							}
						}
						if (!flag2)
						{
							continue;
						}
					}
				}
				CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result2 = Enumerable.FirstOrDefault<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == fieldId));
				if (cRMspDySelectFormFieldsByParentFormId_Result2 != null && !string.IsNullOrWhiteSpace(obj.Value) && cRMspDySelectFormFieldsByParentFormId_Result2.FieldTypeId.GetValueOrDefault() == 4)
				{
					obj.Value = obj.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					string formatetdDate = PersianDate.GetFormatetdDate(obj.Value.Replace("/", ""));
					if (currLangID == 1065)
					{
						DateTime dateTime = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						obj.Value = dateTime.ToString("yyyyMMdd");
					}
					else if (currLangID == 1025)
					{
						DateTime dateTime2 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						obj.Value = dateTime2.ToString("yyyyMMdd", new PersianCulture());
					}
					else
					{
						DateTime dateTime3 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						obj.Value = dateTime3.ToString("yyyyMMdd", new PersianCulture());
					}
				}
				IdKeyValueItemViewModel idKeyValueItemViewModel = Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list6, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == ids));
				List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
				if (idKeyValueItemViewModel != null && (cRMspDySelectFormFieldsByParentFormId_Result2.FieldTypeId.GetValueOrDefault() == 1 || cRMspDySelectFormFieldsByParentFormId_Result2.FieldTypeId.GetValueOrDefault() == 3))
				{
					if (!string.IsNullOrWhiteSpace(idKeyValueItemViewModel.Value))
					{
						list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(idKeyValueItemViewModel.Value);
					}
				}
				else
				{
					list7 = new List<CommonMultiLanguageViewModel>();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != currLangID))))
					{
						string value2 = "";
						if (cRMspDySelectFormFieldsByParentFormId_Result2 == null)
						{
							continue;
						}
						switch (cRMspDySelectFormFieldsByParentFormId_Result2.FieldTypeId)
						{
						case 2:
						case 4:
						case 5:
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
							value2 = obj.Value;
							break;
						case 6:
						case 7:
						case 8:
							if (list3 != null && Enumerable.Any<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list3))
							{
								CRMspDySelectFormFieldValuesByMasterValueId_Result cRMspDySelectFormFieldValuesByMasterValueId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<CRMspDySelectFormFieldValuesByMasterValueId_Result>)list3, (Func<CRMspDySelectFormFieldValuesByMasterValueId_Result, bool>)((CRMspDySelectFormFieldValuesByMasterValueId_Result m) => m.FormId == formId && m.FieldId == fieldId && m.FieldRepeatId.GetValueOrDefault() == fieldRepeatId));
								if (cRMspDySelectFormFieldValuesByMasterValueId_Result == null)
								{
									break;
								}
								List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
								if (string.IsNullOrWhiteSpace(cRMspDySelectFormFieldValuesByMasterValueId_Result.Value_Lang))
								{
									break;
								}
								list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(cRMspDySelectFormFieldValuesByMasterValueId_Result.Value_Lang);
								if (list8 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8))
								{
									CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == lang.LanguageID));
									if (commonMultiLanguageViewModel != null)
									{
										value2 = ((commonMultiLanguageViewModel.Value == null) ? null : (commonMultiLanguageViewModel.Value ?? ""));
									}
								}
							}
							else
							{
								if (!flag || list4 == null || !string.IsNullOrWhiteSpace(value2))
								{
									break;
								}
								CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result3 = Enumerable.FirstOrDefault<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)list4, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result x) => x.FormFieldId == int.Parse(obj.Id.Split(new char[1] { '_' })[1])));
								if (cRMspDySelectFormFieldsByParentFormId_Result3 == null || string.IsNullOrWhiteSpace(cRMspDySelectFormFieldsByParentFormId_Result3.MultiItems))
								{
									break;
								}
								string[] array3 = cRMspDySelectFormFieldsByParentFormId_Result3.MultiItems.Split(new char[1] { '|' });
								for (int i = 0; i < array3.Length; i++)
								{
									if (!string.IsNullOrWhiteSpace(array3[i]) && array3[i].Split(new char[1] { ':' })[1] == obj.Value)
									{
										value2 = obj.Value ?? "";
									}
								}
							}
							break;
						}
						list7.Add(new CommonMultiLanguageViewModel
						{
							Value = value2,
							LanguageId = lang.LanguageID
						});
					}
				}
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = obj.Value,
					LanguageId = currLangID
				});
				string text3 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : null);
				if (string.IsNullOrEmpty(text3))
				{
					text2 = text2 + string.Format(Messages.ErrorEmpty, cRMspDySelectFormFieldsByParentFormId_Result.FieldTitle ?? "") + "<br/>";
					num3++;
				}
				else if (!checkMultiLanguage(text3, list7))
				{
					text2 = text2 + text2 + string.Format(Messages.CheckFieldInLang, cRMspDySelectFormFieldsByParentFormId_Result.FieldTitle ?? "") + "<br>";
					num3++;
				}
			}
			if (num3 <= 0)
			{
				goto IL_118e;
			}
			text = text2;
			commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
			goto end_IL_000e;
			IL_024d:
			list2 = Enumerable.ToList<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)_dbI.CRMspDySelectFormAndSubForms(model.FormId, num, currLangID, result, centerId));
			CRMspDySelectFormAndSubForms_Result cRMspDySelectFormAndSubForms_Result2 = new CRMspDySelectFormAndSubForms_Result();
			if (list2 != null && Enumerable.Any<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list2))
			{
				cRMspDySelectFormAndSubForms_Result2 = Enumerable.FirstOrDefault<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list2, (Func<CRMspDySelectFormAndSubForms_Result, bool>)((CRMspDySelectFormAndSubForms_Result m) => m.FormId == model.FormId));
				if (cRMspDySelectFormAndSubForms_Result2 != null)
				{
					int.TryParse(cRMspDySelectFormAndSubForms_Result2.WorkflowId.ToString(), out result2);
					if (!string.IsNullOrEmpty(cRMspDySelectFormAndSubForms_Result2.FormName))
					{
						_ = cRMspDySelectFormAndSubForms_Result2.FormName;
					}
					if (cRMspDySelectFormAndSubForms_Result2.CrmSysPartId.GetValueOrDefault() == 1)
					{
						_ = 1;
					}
					else
						_ = cRMspDySelectFormAndSubForms_Result2.FOSysPartId.GetValueOrDefault() == 100;
					list = Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)_dbI.CRMspDySelectFormFieldsByParentFormId(model.FormId, currLangID, result));
					list5 = new List<IdKeyValueItemViewModel>();
					list6 = new List<IdKeyValueItemViewModel>();
					if (!string.IsNullOrWhiteSpace(model.ValueDetails))
					{
						list5 = new JavaScriptSerializer().Deserialize<List<IdKeyValueItemViewModel>>(model.ValueDetails);
					}
					if (!string.IsNullOrWhiteSpace(model.ValueDetails_Lang))
					{
						list6 = new JavaScriptSerializer().Deserialize<List<IdKeyValueItemViewModel>>(model.ValueDetails_Lang);
					}
					if (model.WdSubFormId > 0 && model.WorkflowStepId > 0)
					{
						CRMspDySelectFormWorkflowStepWithId_Result cRMspDySelectFormWorkflowStepWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepWithId_Result>((IEnumerable<CRMspDySelectFormWorkflowStepWithId_Result>)_db.CRMspDySelectFormWorkflowStepWithId(model.WorkflowStepId, currLangID, result, centerId));
						if (cRMspDySelectFormWorkflowStepWithId_Result == null)
						{
							goto IL_073c;
						}
						string text4 = cRMspDySelectFormWorkflowStepWithId_Result.ReferUserIds ?? "";
						if (string.IsNullOrEmpty(text4))
						{
							goto IL_073c;
						}
						bool flag4 = false;
						string[] array4 = text4.Split(new char[1] { '|' });
						if (array4 != null)
						{
							string[] array5 = array4;
							foreach (string text5 in array5)
							{
								if (!string.IsNullOrEmpty(text5) && int.Parse(text5) == num)
								{
									flag4 = true;
									break;
								}
							}
						}
						if (flag4 || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
						{
							goto IL_073c;
						}
						string text6 = string.Format(Messages.msgErrorYouNotDyFormReferUsers, cRMspDySelectFormWorkflowStepWithId_Result.SubForm);
						base.ModelState.AddModelError("error", Messages.DyFrmUserNotAccess + "<br>" + text6);
						text = Messages.DyFrmUserNotAccess + "<br>" + text6;
						commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
					}
					else
					{
						if (result2 <= 0 || cRMspDySelectFormAndSubForms_Result2 == null)
						{
							goto IL_073c;
						}
						bool flag5 = false;
						int? enableForRollId = cRMspDySelectFormAndSubForms_Result2.EnableForRollId;
						string text7 = cRMspDySelectFormAndSubForms_Result2.EnableForUsersId ?? "";
						if (enableForRollId.HasValue)
						{
							flag5 = enableForRollId == UserLogin.CurrentUser.RollId;
						}
						else if (!string.IsNullOrEmpty(text7))
						{
							string[] array6 = text7.Split(new char[1] { '|' });
							if (array6 != null)
							{
								string[] array5 = array6;
								foreach (string text8 in array5)
								{
									if (!string.IsNullOrEmpty(text8) && int.Parse(text8) == num)
									{
										flag5 = true;
										break;
									}
								}
							}
						}
						else
						{
							flag5 = true;
						}
						if (flag5 || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser))
						{
							goto IL_073c;
						}
						string text9 = string.Format(Messages.msgErrorYouNotDyFormReferUsers, cRMspDySelectFormAndSubForms_Result2.FormName ?? "");
						base.ModelState.AddModelError("error", Messages.DyFrmUserNotAccess + "<br>" + text9);
						text = Messages.DyFrmUserNotAccess + "<br>" + text9;
						commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
					}
				}
				else
				{
					base.ViewBag.Error = Messages.MsgFormNotDefined;
					text = Messages.MsgFormNotDefined;
					commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				}
			}
			else
			{
				base.ViewBag.Error = Messages.MsgFormNotDefined;
				text = Messages.MsgFormNotDefined;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
			}
			end_IL_000e:;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			data = "";
			text = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		CommonResultViewModel<string> data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = text,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data2, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string DeleteDyFormInTempData(int tempDataId = 0)
	{
		string text = "";
		try
		{
			if (tempDataId != 0)
			{
				if (SysTempData.Delete(tempDataId, 0, 0, 0, 0, 0))
				{
					return "1";
				}
				return Messages.msgErrorRunFunction;
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
