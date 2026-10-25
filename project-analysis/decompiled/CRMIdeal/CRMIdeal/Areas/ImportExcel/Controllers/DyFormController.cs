using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.ImportExcel.Controllers;

public class DyFormController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index(int? formId = null)
	{
		base.ViewBag.AllFormFields = JsonConvert.SerializeObject(GetAllFields(formId, true));
		return View(GetForm(formId));
	}

	[HttpPost]
	[LoginAuthorize]
	public string ImportExcelToCrm(int formId, string rec = "")
	{
		string result = "";
		try
		{
			rec = rec.ClearHiddenCharacters();
			rec = rec.ArabicToPersian();
			rec = rec.PersianToEnglish();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			CRMspDyImportFormFromExcel_Result cRMspDyImportFormFromExcel_Result = Enumerable.FirstOrDefault<CRMspDyImportFormFromExcel_Result>((IEnumerable<CRMspDyImportFormFromExcel_Result>)_dbII.CRMspDyImportFormFromExcel(formId, rec, VersionConfig.CurrentDyFormFieldMasterValuesTableVersion, result3, userId, value, registerDatePersian, value2, value3, appType, lCID, result2));
			if (cRMspDyImportFormFromExcel_Result != null)
			{
				if (!string.IsNullOrWhiteSpace(cRMspDyImportFormFromExcel_Result.Message))
				{
					result = cRMspDyImportFormFromExcel_Result.Message.Replace("|", " - ");
					result = result.Replace("CmpNotFound", Messages.CompanyNotFound);
					result = result.Replace("PrsNotFound", Messages.PersonNotFound);
					result = result.Replace("PrjNotFound", Messages.msgErrorProjectNotDefine);
					result = result.Replace("CnvsNotFound", Messages.msgConversationNotFound);
					result = result.Replace("PordNotFound", Messages.msgErrorPreOrderNotFound);
					result = result.Replace("OrdNotFound", Messages.msgErrorOrderNotFound);
					result = result.Replace("BordNotFound", Messages.msgErrorBuyOrderNotFound);
					result = result.Replace("StockSupplyNotFound", Messages.msgErrorStockSupplyNotFound);
					result = result.Replace("SLetterNotFound", Messages.msgErrorLetterNotFound);
					result = result.Replace("RLetterNotFound", Messages.msgErrorLetterNotFound);
					result = result.Replace("DocNotFound", Messages.msgErrorDocNotFound);
					result = result.Replace("DraftNotFound", Messages.msgErrorDraftNotFound);
					result = result.Replace("MovementNotFound", Messages.msgErrorMovementNotFound);
					result = result.Replace("PrdNotFound", Messages.msgErrorPrdIdNotFound);
					result = result.Replace("PageNotFound", Messages.msgErrorCmsPageNotFound);
					result = result.Replace("UserNotFound", Messages.msgErrorUserNotFound);
				}
			}
			else
			{
				result = Messages.MsgErrorDoneOperation;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.MsgErrorDoneOperation;
		}
		return result;
	}

	[LoginAuthorize]
	public ActionResult DownloadSample(int? formId = 0)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string viewName = "";
		try
		{
			List<CRMspDySelectFormFieldsByParentFormId_Result> allFields = GetAllFields(formId, true);
			if (Enumerable.Any<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)allFields))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OrderImportExcelPropertiesTitle);
				for (int i = 0; i < allFields.Count; i++)
				{
					CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result = allFields[i];
					int col = i + 1;
					ExcelRange excelRange = excelWorksheet.Cells[1, col];
					excelRange.Value = cRMspDySelectFormFieldsByParentFormId_Result.FieldTitle;
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Font.Color.SetColor(CRMIdeal.Classes.Helper.ImportExcel._ImportExcel_Head_ForeColor);
					if (cRMspDySelectFormFieldsByParentFormId_Result.IsRequired.GetValueOrDefault())
					{
						excelRange.Style.Fill.BackgroundColor.SetColor(CRMIdeal.Classes.Helper.ImportExcel._ImportExcel_Head_BackColor_Required);
					}
					else
					{
						excelRange.Style.Fill.BackgroundColor.SetColor(CRMIdeal.Classes.Helper.ImportExcel._ImportExcel_Head_BackColor);
					}
				}
				excelPackage.Workbook.Properties.Title = Labels.OrderImportExcelPropertiesTitle;
				excelPackage.SaveAs(base.Response.OutputStream);
				base.Response.Buffer = true;
				base.Response.AddHeader("content-disposition", "attachment; filename=CRM-Ideal.xls");
				base.Response.ContentType = "application/ms-excel";
				base.Response.Charset = "";
				base.Response.Flush();
				base.Response.End();
			}
			else
			{
				viewName = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.Column);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(viewName);
	}

	[HttpPost]
	[LoginAuthorize]
	public CRMspDySelectForms_Result GetForm(int? formId = null, int? parentFormId = null)
	{
		CRMspDySelectForms_Result result = new CRMspDySelectForms_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(formId, parentFormId, lCID, result2, result3));
			if (cRMspDySelectForms_Result != null)
			{
				result = cRMspDySelectForms_Result;
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
	public List<CRMspDySelectFormFieldsByParentFormId_Result> GetAllFields(int? formId = 0, bool? forExcelHead = false)
	{
		List<CRMspDySelectFormFieldsByParentFormId_Result> res = new List<CRMspDySelectFormFieldsByParentFormId_Result>();
		CRMspDySelectForms_Result form = GetForm(formId);
		List<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel> dyFormStaticFields = CRMIdeal.Classes.Helper.ImportExcel.DyForm.GetDyFormStaticFields();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		if (dyFormStaticFields != null)
		{
			List<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel> list = Enumerable.ToList<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>(Enumerable.Where<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>((IEnumerable<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>)dyFormStaticFields, (Func<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel, bool>)((CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel x) => x.SysPartId == form.CrmSysPartId || x.SysPartId == -1)));
			if (list != null)
			{
				foreach (CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel item in list)
				{
					string[] array = item.SysPartIds.Split(new char[1] { ',' });
					foreach (string f2 in array)
					{
						list = Enumerable.ToList<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>(Enumerable.Where<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>((IEnumerable<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>)dyFormStaticFields, (Func<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel, bool>)((CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel x) => x.SysPartId == int.Parse(f2))));
						res.AddRange(Enumerable.Select<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel, CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>)Enumerable.ToList<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>(Enumerable.Where<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>((IEnumerable<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>)list, (Func<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel, bool>)((CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel w) => Enumerable.FirstOrDefault<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)res, (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result r) => r.FieldTitle == w.FieldTitle + "-" + w.FieldTypeTitle + "-" + w.FieldName)) == null))), (Func<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel, CRMspDySelectFormFieldsByParentFormId_Result>)((CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel x) => new CRMspDySelectFormFieldsByParentFormId_Result
						{
							FormId = formId.GetValueOrDefault(),
							FieldTypeId = x.FieldTypeId,
							FieldTitle = x.FieldTitle + "-" + x.FieldTypeTitle + "-" + x.FieldName,
							IsRequired = ((!x.IsRequired.HasValue) ? new bool?(true) : x.IsRequired),
							StrLength = x.FieldMaxLen,
							FieldType = x.FieldTypeTitle,
							TypeInWeb = x.FieldType,
							AppType = x.FieldName,
							IsActive = true
						})));
					}
				}
			}
		}
		List<CRMspDySelectFormFieldsByParentFormId_Result> list2 = Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)_dbI.CRMspDySelectFormFieldsByParentFormId(formId, lCID, result));
		if (list2 != null)
		{
			foreach (CRMspDySelectFormFieldsByParentFormId_Result f in list2)
			{
				if (f.TypeInWeb == "cmp" || f.TypeInWeb == "prd" || f.TypeInWeb == "user")
				{
					if (dyFormStaticFields == null)
					{
						continue;
					}
					List<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel> list3 = new List<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>();
					if (f.TypeInWeb == "cmp")
					{
						list3.AddRange(Enumerable.ToList<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>(Enumerable.Where<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>((IEnumerable<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>)dyFormStaticFields, (Func<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel, bool>)((CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel x) => x.SysPartId == 10))));
					}
					else if (f.TypeInWeb == "prd")
					{
						list3.AddRange(Enumerable.ToList<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>(Enumerable.Where<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>((IEnumerable<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>)dyFormStaticFields, (Func<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel, bool>)((CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel x) => x.SysPartId == 70))));
					}
					else if (f.TypeInWeb == "user")
					{
						list3.AddRange(Enumerable.ToList<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>(Enumerable.Where<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>((IEnumerable<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>)dyFormStaticFields, (Func<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel, bool>)((CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel x) => x.SysPartId == 140))));
					}
					res.AddRange(Enumerable.Select<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel, CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel>)list3, (Func<CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel, CRMspDySelectFormFieldsByParentFormId_Result>)((CRMIdeal.Classes.Helper.ImportExcel.DyForm.DyFormStaticFieldsViewModel x) => new CRMspDySelectFormFieldsByParentFormId_Result
					{
						FormFieldId = f.FormFieldId,
						FormId = formId.GetValueOrDefault(),
						FieldTypeId = x.FieldTypeId,
						FieldTitle = x.FieldTitle + "-" + x.FieldTypeTitle + "-" + x.FieldName + "-" + f.FormFieldId,
						IsRequired = true,
						StrLength = x.FieldMaxLen,
						FieldType = x.FieldTypeTitle,
						TypeInWeb = x.FieldType,
						AppType = x.FieldName,
						IsActive = true
					})));
				}
				else
				{
					f.AppType = "";
					CRMspDySelectFormFieldsByParentFormId_Result cRMspDySelectFormFieldsByParentFormId_Result = f;
					cRMspDySelectFormFieldsByParentFormId_Result.FieldTitle = cRMspDySelectFormFieldsByParentFormId_Result.FieldTitle + "-" + f.FieldType;
					res.Add(f);
				}
			}
		}
		return res;
	}
}
