using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class FormHtmlController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index()
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
			List<CRMspSelectsysForms_Result> list2 = Enumerable.ToList<CRMspSelectsysForms_Result>((IEnumerable<CRMspSelectsysForms_Result>)_db.CRMspSelectsysForms(lCID, result));
			if (list2 != null)
			{
				CRMspSelectsysForms_Result cRMspSelectsysForms_Result = Enumerable.FirstOrDefault<CRMspSelectsysForms_Result>((IEnumerable<CRMspSelectsysForms_Result>)list2, (Func<CRMspSelectsysForms_Result, bool>)((CRMspSelectsysForms_Result x) => x.FormName == "frmLogin"));
				if (cRMspSelectsysForms_Result != null)
				{
					list.Add(new SelectListItem
					{
						Text = cRMspSelectsysForms_Result.FormPersianName,
						Value = cRMspSelectsysForms_Result.ID.ToString()
					});
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.Forms = list;
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetFormHtmlDetails(int formId = 0)
	{
		List<CRMspSelectsysFormHtmlWithFormId_Result> value = new List<CRMspSelectsysFormHtmlWithFormId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (formId != 0)
			{
				List<CRMspSelectsysFormHtmlWithFormId_Result> list = Enumerable.ToList<CRMspSelectsysFormHtmlWithFormId_Result>((IEnumerable<CRMspSelectsysFormHtmlWithFormId_Result>)_dbII.CRMspSelectsysFormHtmlWithFormId(formId, lCID, result));
				if (list != null)
				{
					value = list;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[LoginAuthorize]
	public ActionResult InsertEdit(int formHtmlId = 0, int formId = 0)
	{
		CrmSysFormHtmlLanguageViewModel crmSysFormHtmlLanguageViewModel = new CrmSysFormHtmlLanguageViewModel();
		crmSysFormHtmlLanguageViewModel.FormId = formId;
		crmSysFormHtmlLanguageViewModel.FormDeActive = true;
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectsysForms_Result> list = Enumerable.ToList<CRMspSelectsysForms_Result>((IEnumerable<CRMspSelectsysForms_Result>)_db.CRMspSelectsysForms(currLangID, result));
			if (list != null)
			{
				CRMspSelectsysForms_Result cRMspSelectsysForms_Result = Enumerable.FirstOrDefault<CRMspSelectsysForms_Result>((IEnumerable<CRMspSelectsysForms_Result>)list, (Func<CRMspSelectsysForms_Result, bool>)((CRMspSelectsysForms_Result x) => x.FormName == "frmLogin"));
				if (cRMspSelectsysForms_Result != null)
				{
					text = cRMspSelectsysForms_Result.FormName;
				}
			}
			if (formHtmlId != 0)
			{
				CRMspSelectsysFormHtmlWithId_Result cRMspSelectsysFormHtmlWithId_Result = Enumerable.FirstOrDefault<CRMspSelectsysFormHtmlWithId_Result>((IEnumerable<CRMspSelectsysFormHtmlWithId_Result>)_dbII.CRMspSelectsysFormHtmlWithId(formHtmlId, currLangID, result));
				if (cRMspSelectsysFormHtmlWithId_Result != null)
				{
					crmSysFormHtmlLanguageViewModel.FormHtmlID = cRMspSelectsysFormHtmlWithId_Result.FormHtmlID;
					crmSysFormHtmlLanguageViewModel.FormId = cRMspSelectsysFormHtmlWithId_Result.FormId;
					crmSysFormHtmlLanguageViewModel.FormHTML = cRMspSelectsysFormHtmlWithId_Result.FormHTML;
					crmSysFormHtmlLanguageViewModel.FormHTML_Lang = cRMspSelectsysFormHtmlWithId_Result.FormHTML_Lang;
					crmSysFormHtmlLanguageViewModel.FormCSS = cRMspSelectsysFormHtmlWithId_Result.FormCSS;
					crmSysFormHtmlLanguageViewModel.FormCSS_Lang = cRMspSelectsysFormHtmlWithId_Result.FormCSS_Lang;
					crmSysFormHtmlLanguageViewModel.FormRep = cRMspSelectsysFormHtmlWithId_Result.FormRep;
					crmSysFormHtmlLanguageViewModel.FormRep_Lang = cRMspSelectsysFormHtmlWithId_Result.FormRep_Lang;
					crmSysFormHtmlLanguageViewModel.FormJS = cRMspSelectsysFormHtmlWithId_Result.FormJS;
					crmSysFormHtmlLanguageViewModel.FormJS_Lang = cRMspSelectsysFormHtmlWithId_Result.FormJS_Lang;
					crmSysFormHtmlLanguageViewModel.FormJSTop = cRMspSelectsysFormHtmlWithId_Result.FormJSTop;
					crmSysFormHtmlLanguageViewModel.FormJSTop_Lang = cRMspSelectsysFormHtmlWithId_Result.FormJSTop_Lang;
					crmSysFormHtmlLanguageViewModel.FormDeActive = cRMspSelectsysFormHtmlWithId_Result.FormDeActive;
					crmSysFormHtmlLanguageViewModel.FirstRegisterUserId = cRMspSelectsysFormHtmlWithId_Result.FirstRegisterUserId;
					crmSysFormHtmlLanguageViewModel.FirstRegisterUser = cRMspSelectsysFormHtmlWithId_Result.FirstRegisterUser;
					crmSysFormHtmlLanguageViewModel.FirstRegisterDate = cRMspSelectsysFormHtmlWithId_Result.FirstRegisterDate;
					crmSysFormHtmlLanguageViewModel.FirstRegisterDatePersian = cRMspSelectsysFormHtmlWithId_Result.FirstRegisterDatePersian;
					crmSysFormHtmlLanguageViewModel.Year1 = cRMspSelectsysFormHtmlWithId_Result.Year1;
					crmSysFormHtmlLanguageViewModel.Month1 = cRMspSelectsysFormHtmlWithId_Result.Month1;
					crmSysFormHtmlLanguageViewModel.UserId = cRMspSelectsysFormHtmlWithId_Result.UserId;
					crmSysFormHtmlLanguageViewModel.EditUser = cRMspSelectsysFormHtmlWithId_Result.EditUser;
					crmSysFormHtmlLanguageViewModel.AppType = cRMspSelectsysFormHtmlWithId_Result.AppType;
					if (!string.IsNullOrWhiteSpace(crmSysFormHtmlLanguageViewModel.FormHTML_Lang))
					{
						List<CommonMultiLanguageViewModel> list2 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(crmSysFormHtmlLanguageViewModel.FormHTML_Lang);
						crmSysFormHtmlLanguageViewModel.FormHTML = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == currLangID)).Value;
						crmSysFormHtmlLanguageViewModel.FormHTML_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != currLangID))));
					}
					if (!string.IsNullOrWhiteSpace(crmSysFormHtmlLanguageViewModel.FormCSS_Lang))
					{
						List<CommonMultiLanguageViewModel> list3 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(crmSysFormHtmlLanguageViewModel.FormCSS_Lang);
						crmSysFormHtmlLanguageViewModel.FormCSS = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == currLangID)).Value;
						crmSysFormHtmlLanguageViewModel.FormCSS_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != currLangID))));
					}
					if (!string.IsNullOrWhiteSpace(crmSysFormHtmlLanguageViewModel.FormRep_Lang))
					{
						List<CommonMultiLanguageViewModel> list4 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(crmSysFormHtmlLanguageViewModel.FormRep_Lang);
						crmSysFormHtmlLanguageViewModel.FormRep = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == currLangID)).Value;
						crmSysFormHtmlLanguageViewModel.FormRep_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != currLangID))));
					}
					if (!string.IsNullOrWhiteSpace(crmSysFormHtmlLanguageViewModel.FormJS_Lang))
					{
						List<CommonMultiLanguageViewModel> list5 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(crmSysFormHtmlLanguageViewModel.FormJS_Lang);
						crmSysFormHtmlLanguageViewModel.FormJS = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == currLangID)).Value;
						crmSysFormHtmlLanguageViewModel.FormJS_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != currLangID))));
					}
					if (!string.IsNullOrWhiteSpace(crmSysFormHtmlLanguageViewModel.FormJSTop_Lang))
					{
						List<CommonMultiLanguageViewModel> list6 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(crmSysFormHtmlLanguageViewModel.FormJSTop_Lang);
						crmSysFormHtmlLanguageViewModel.FormJSTop = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == currLangID)).Value;
						crmSysFormHtmlLanguageViewModel.FormJSTop_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != currLangID))));
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.FormName = text;
		return View(crmSysFormHtmlLanguageViewModel);
	}

	[HttpPost]
	[LoginAuthorize]
	public ActionResult InsertEdit(CrmSysFormHtmlLanguageViewModel vm)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (string.IsNullOrWhiteSpace(vm.FormHTML))
			{
				text = text + string.Format(Messages.ErrorEmpty, "HTML") + "\n";
			}
			else
			{
				if (!string.IsNullOrWhiteSpace(vm.FormHTML_Lang))
				{
					list = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(vm.FormHTML_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = vm.FormHTML,
					LanguageId = defLangID
				});
				if (!checkMultiLanguage(vm.FormHTML, list))
				{
					text = text + Messages.CheckFormHtmlLang + "\n";
				}
			}
			if (!string.IsNullOrWhiteSpace(vm.FormCSS_Lang))
			{
				list2 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(vm.FormCSS_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.FormCSS,
				LanguageId = defLangID
			});
			if (!string.IsNullOrWhiteSpace(vm.FormRep_Lang))
			{
				list3 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(vm.FormRep_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.FormRep,
				LanguageId = defLangID
			});
			if (!string.IsNullOrWhiteSpace(vm.FormJS_Lang))
			{
				list4 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(vm.FormJS_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.FormJS,
				LanguageId = defLangID
			});
			if (!string.IsNullOrWhiteSpace(vm.FormJSTop_Lang))
			{
				list5 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(vm.FormJSTop_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.FormJSTop,
				LanguageId = defLangID
			});
			List<CRMspSelectsysForms_Result> list6 = Enumerable.ToList<CRMspSelectsysForms_Result>((IEnumerable<CRMspSelectsysForms_Result>)_db.CRMspSelectsysForms(lCID, defLangID));
			if (list6 != null)
			{
				CRMspSelectsysForms_Result cRMspSelectsysForms_Result = Enumerable.FirstOrDefault<CRMspSelectsysForms_Result>((IEnumerable<CRMspSelectsysForms_Result>)list6, (Func<CRMspSelectsysForms_Result, bool>)((CRMspSelectsysForms_Result x) => x.FormName == "frmLogin"));
				if (cRMspSelectsysForms_Result != null)
				{
					text3 = cRMspSelectsysForms_Result.FormName;
				}
			}
			if (text == "")
			{
				if (vm.FormHtmlID != 0)
				{
					if (Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspUpdatesysFormHtml(vm.FormHtmlID, vm.FormId, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))) : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))) : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))) : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))) : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))) : null, vm.FormDeActive, userId, value2, value3, value, registerDatePersian, appType, lCID, defLangID)).Result == 1)
					{
						text = "";
						text2 = string.Format(Messages.msgSuccessfulySavedValues, "");
					}
					else
					{
						text = Messages.msgErrorOperationFailed;
						text2 = "";
					}
				}
				else if (Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertsysFormHtml(vm.FormId, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))) : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))) : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))) : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))) : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))) : null, vm.FormDeActive, userId, value2, value3, value, registerDatePersian, appType, lCID, defLangID)).Result > 0)
				{
					text = "";
					text2 = string.Format(Messages.msgSuccessfulySavedValues, "");
				}
				else
				{
					text = Messages.msgErrorOperationFailed;
					text2 = "";
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			text = text + "Error: " + ex.Message + "\n";
		}
		base.ViewBag.Error = text;
		base.ViewBag.Successfull = text2;
		base.ViewBag.FormName = text3;
		return View(vm);
	}

	[HttpPost]
	[LoginAuthorize]
	public string Delete(int formHtmlId = 0)
	{
		string result = "";
		try
		{
			if (formHtmlId != 0)
			{
				mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeletesysFormHtml(formHtmlId));
				result = ((mct_II_Result == null || mct_II_Result.Result <= 0) ? "-2" : "1");
			}
			else
			{
				result = "-1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
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
}
