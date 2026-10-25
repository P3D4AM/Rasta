using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO.FTP;
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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Cartables.Controllers;

public class ConversationQuickViewController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public int defSettingId;

		public int currLangID;

		internal bool _003CGetDefSettingById_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefSettingById_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefSettingById_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefSettingById_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefSettingById_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefSettingById_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefSettingById_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefSettingById_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefSettingById_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int prjId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int cnvsReferUserId;

		public int cnvsId;

		internal bool _003CSetCnvsRemindOk_003Eb__0(CRMspSelectUserForLinkedType_Result model)
		{
			return model.LinkedUserId == cnvsReferUserId;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[LoginAuthorize]
	public ActionResult Index(int cmpId, int prjId, int cnvsId, string nameGrid)
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_.prjId = prjId;
		DateTime now = DateTime.Now;
		CrmConversationLanguageViewModel crmConversationLanguageViewModel = new CrmConversationLanguageViewModel();
		crmConversationLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
		crmConversationLanguageViewModel.cnvsUserId = UserLogin.CurrentUser.UserId;
		crmConversationLanguageViewModel.cnvsReferUserId = UserLogin.CurrentUser.UserId;
		crmConversationLanguageViewModel.cnvsFirstRegisterUserId = UserLogin.CurrentUser.UserId;
		crmConversationLanguageViewModel.Year1 = short.Parse(Financial.Get().Id.ToString());
		crmConversationLanguageViewModel.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
		crmConversationLanguageViewModel.RegisterDate = now;
		crmConversationLanguageViewModel.RegisterDatePersian = now.ToString("yyyyMMdd");
		crmConversationLanguageViewModel.FirstRegisterDate = now;
		crmConversationLanguageViewModel.cnvsFirstRegisterDate = now.ToString("yyyyMMdd");
		crmConversationLanguageViewModel.cnvsDate = now.ToString("yyyyMMdd");
		crmConversationLanguageViewModel.cnvsTime = now.ToString("HH:mm:ss");
		try
		{
			DbSet<CrmProjects> crmProjects = _dbTbl.CrmProjects;
			ParameterExpression val = Expression.Parameter(typeof(CrmProjects), "m");
			CrmProjects crmProjects2 = Queryable.FirstOrDefault<CrmProjects>((IQueryable<CrmProjects>)crmProjects, Expression.Lambda<Func<CrmProjects, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass3_, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmProjects2 != null)
			{
				if (crmProjects2.prjIsTicket.HasValue && crmProjects2.prjIsTicket.GetValueOrDefault())
				{
					crmConversationLanguageViewModel.cnvsIsTicket = true;
					crmConversationLanguageViewModel.cnvsFOCmpCanSee = true;
				}
				if (crmProjects2.prjFOCmpCanSee.HasValue && crmProjects2.prjFOCmpCanSee.GetValueOrDefault())
				{
					crmConversationLanguageViewModel.prjFOCmpCanSee = true;
				}
			}
			if (UserLogin.IsUserAccess("frmDefineConversation", "actDefSelectFOCmpCanSee", UserLogin.CurrentUser) && crmConversationLanguageViewModel.prjFOCmpCanSee.GetValueOrDefault())
			{
				crmConversationLanguageViewModel.cnvsFOCmpCanSee = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		crmConversationLanguageViewModel.AppTypeHelp = Configuration.AppType;
		crmConversationLanguageViewModel.cnvsFirstRegisterDateTime = now;
		crmConversationLanguageViewModel.cnvsDay = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
		crmConversationLanguageViewModel.cnvsCompanyId = cmpId;
		crmConversationLanguageViewModel.cnvsProjectId = _003C_003Ec__DisplayClass3_.prjId;
		crmConversationLanguageViewModel.AppType = "";
		crmConversationLanguageViewModel.cnvsDoingHour = 0;
		crmConversationLanguageViewModel.cnvsDoingMin = 0;
		ConversationFullcombo_lang(cmpId, _003C_003Ec__DisplayClass3_.prjId);
		ConversationSetUserNameDate_lang(crmConversationLanguageViewModel);
		ComboBoxCnvsReferToUser_Lang(UserLogin.CurrentUser.UserId, cmpId);
		ComboBoxTypeFile_Lang();
		listDays();
		GetCompanyQuickRegisterDefSettingForCnvs(_003C_003Ec__DisplayClass3_.prjId);
		try
		{
			_dbI.CRMspDeleteFilesDirectoryTemplateByTypeAndUser(2, UserLogin.CurrentUser.UserId);
			string text = Configuration.HostTempFilesPath + "/" + Configuration.CnvsDirectoryPath;
			string path = base.Server.MapPath(text + UserLogin.CurrentUser.UserId + "/");
			if (Directory.Exists(path))
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
				Directory.Delete(path);
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		base.ViewBag.cmpId = cmpId;
		base.ViewBag.prjId = _003C_003Ec__DisplayClass3_.prjId;
		base.ViewBag.nameGrid = nameGrid;
		return View(crmConversationLanguageViewModel);
	}

	[AjaxOnly]
	[LoginAuthorize]
	public JsonResult GetInfo(int cmpId, int prjId)
	{
		CRMspSelectCompanyConversationsByProjectViewModel cRMspSelectCompanyConversationsByProjectViewModel = new CRMspSelectCompanyConversationsByProjectViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
			if (companyById != null)
			{
				string text = companyById.cmpCountry ?? "";
				if (!string.IsNullOrWhiteSpace(companyById.cmpProvince))
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += " - ";
					}
					text += companyById.cmpProvince;
				}
				if (!string.IsNullOrWhiteSpace(companyById.cmpCity))
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += " - ";
					}
					text += companyById.cmpCity;
				}
				if (!string.IsNullOrWhiteSpace(companyById.cmpAddress))
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += " - ";
					}
					text += companyById.cmpAddress;
				}
				cRMspSelectCompanyConversationsByProjectViewModel.CmpAddress = text;
				cRMspSelectCompanyConversationsByProjectViewModel.CmpSpecialPoint = companyById.cmpSpecialPoint;
				DateTime now = DateTime.Now;
				string currentDate = now.ToString("yyyyMMdd");
				string currentTime = now.ToString("HH:mm:ss");
				List<SelectListItem> list = listDays();
				string dayId = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == dayId));
				cRMspSelectCompanyConversationsByProjectViewModel.CurrentDay = selectListItem.Text;
				cRMspSelectCompanyConversationsByProjectViewModel.CurrentDate = currentDate;
				cRMspSelectCompanyConversationsByProjectViewModel.CurrentTime = currentTime;
			}
			cRMspSelectCompanyConversationsByProjectViewModel.IsFind = true;
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			cRMspSelectCompanyConversationsByProjectViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			cRMspSelectCompanyConversationsByProjectViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		return Json(cRMspSelectCompanyConversationsByProjectViewModel, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetConversationList(int cmpId, int prjId, int pageSize = 0, int lastRowNumber = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyConversationsByProject_Result> list = new List<CRMspSelectCompanyConversationsByProject_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<CRMspSelectCompanyConversationsByProject_Result>((IEnumerable<CRMspSelectCompanyConversationsByProject_Result>)_db.CRMspSelectCompanyConversationsByProject(cmpId, prjId, languageID: lCID, defaultLanguageID: result, userId: UserLogin.CurrentUser.UserId, centerId: result2, pageSize: pageSize, lastRowNumber: lastRowNumber));
			foreach (CRMspSelectCompanyConversationsByProject_Result item in list)
			{
				if (item.cnvsDateTime.HasValue)
				{
					DateTime.TryParse(item.cnvsDateTime.ToString(), out var result3);
					item.cnvsDate = result3.ToString("yyyyMMdd");
				}
				else if (!string.IsNullOrEmpty(item.cnvsDate))
				{
					if (lCID != 1065)
					{
						item.cnvsDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyyMMdd");
					}
					else
					{
						item.cnvsDate = item.cnvsDate.Replace("/", "");
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
		return JsonConvert.SerializeObject(list);
	}

	[AjaxOnly]
	public string SetCnvsRemindOk(int cnvsId, int cnvsReferUserId, bool cnvsRemindOk)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.cnvsReferUserId = cnvsReferUserId;
		CS_0024_003C_003E8__locals0.cnvsId = cnvsId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int value = 9;
		string text = "0";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (CS_0024_003C_003E8__locals0.cnvsReferUserId != 0 && CS_0024_003C_003E8__locals0.cnvsId > 0)
			{
				if (CS_0024_003C_003E8__locals0.cnvsReferUserId != UserLogin.CurrentUser.UserId && Enumerable.FirstOrDefault<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, value, lCID, result, result2), (Func<CRMspSelectUserForLinkedType_Result, bool>)((CRMspSelectUserForLinkedType_Result model) => model.LinkedUserId == CS_0024_003C_003E8__locals0.cnvsReferUserId)) == null)
				{
					text = "-1";
				}
				if (text == "-1")
				{
					return Messages.msgErrorUserCanNotcnvsEditaion;
				}
				DbSet<CrmConversation> crmConversation = _dbTbl.CrmConversation;
				ParameterExpression val = Expression.Parameter(typeof(CrmConversation), "model");
				CrmConversation crmConversation2 = Queryable.FirstOrDefault<CrmConversation>((IQueryable<CrmConversation>)crmConversation, Expression.Lambda<Func<CrmConversation, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmConversation2 != null)
				{
					int valueOrDefault = crmConversation2.cnvsProjectId.GetValueOrDefault();
					if (cnvsRemindOk)
					{
						string text2 = CRMIdeal.Classes.Helper.Company.CheckCnvsRemindOkByPrjPrdHNotDone(valueOrDefault);
						if (!string.IsNullOrWhiteSpace(text2))
						{
							return text2 + "<br>";
						}
					}
					DateTime now = DateTime.Now;
					crmConversation2.cnvsRemindOk = cnvsRemindOk;
					crmConversation2.UserId = UserLogin.CurrentUser.UserId;
					crmConversation2.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmConversation2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					crmConversation2.AppType = Configuration.AppType;
					crmConversation2.RegisterDate = now;
					crmConversation2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_dbTbl.Entry(crmConversation2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					return "1";
				}
				return Messages.ErrorNotFindRecord;
			}
			return Messages.msgErrorNotSelectItem;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return ex.Message;
		}
	}

	public List<CRMspSelectConversationTopics_Result> SelectConversationTopics()
	{
		List<CRMspSelectConversationTopics_Result> list = new List<CRMspSelectConversationTopics_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)_db.CRMspSelectConversationTopics(lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ConversationTopicslist = list;
		return list;
	}

	public List<SelectListItem> ConversationTopicsSelectListItem()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectConversationTopics_Result> list2 = SelectConversationTopics();
		if (list2 != null)
		{
			list.AddRange(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list2, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result x) => new SelectListItem
			{
				Text = x.Topic,
				Value = x.ConversationTopicsID.ToString()
			})));
		}
		base.ViewBag.ConversationTopicslist = list;
		return list;
	}

	public List<SelectListItem> PersonsSelectListItem(int cmpid = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectCompanyPersons_Result> list2 = CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpid);
			if (list2 != null && Enumerable.Any<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list2))
			{
				list2 = Enumerable.ToList<CRMspSelectCompanyPersons_Result>(Enumerable.Where<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list2, (Func<CRMspSelectCompanyPersons_Result, bool>)((CRMspSelectCompanyPersons_Result c) => !c.prsWorkingOut.HasValue || c.prsWorkingOut == false)));
			}
			if (list2 != null && Enumerable.Any<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list2))
			{
				foreach (CRMspSelectCompanyPersons_Result item in list2)
				{
					string text = item.prsDepartment ?? "";
					string text2 = item.prsTitle ?? "";
					string text3 = item.prsJob ?? "";
					list.Add(new SelectListItem
					{
						Text = ((!string.IsNullOrEmpty(text2)) ? text2 : "") + ((!string.IsNullOrEmpty(item.prsFName)) ? (" " + item.prsFName) : "") + ((!string.IsNullOrEmpty(item.prsLName)) ? (" " + item.prsLName) : "") + ((!string.IsNullOrEmpty(text3)) ? (" |" + Labels.PrsJob + ": " + text3) : "") + ((!string.IsNullOrEmpty(text)) ? (" |" + Labels.PrsDepartment + ": " + text) : ""),
						Value = item.CompanyPersonID.ToString(),
						Selected = false
					});
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpPersonlist = list;
		return list;
	}

	public List<SelectListItem> ConversationStatus(int prjid = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		new CommonSelectListItemsViewModel
		{
			ListI = new List<SelectListItem>(),
			ListII = new List<SelectListItem>()
		};
		new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(prjid, lCID, result));
			if (cRMspSelectCrmProjectsById_Result != null)
			{
				foreach (CRMspSelectActiveConversationStatus_Result item in Enumerable.ToList<CRMspSelectActiveConversationStatus_Result>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)_dbI.CRMspSelectActiveConversationStatus(cRMspSelectCrmProjectsById_Result.prjcnvsStatusGroupId, lCID, result)))
				{
					if (item.StatusDesc == null)
					{
						item.StatusDesc = "";
					}
					list.Add(new SelectListItem
					{
						Text = ((!string.IsNullOrEmpty(item.Status)) ? item.Status : "") + (item.ProgressPercent.HasValue ? (" |" + Labels.cnvsPercentStatus + ": " + item.ProgressPercent) : "") + ((!string.IsNullOrEmpty(item.StatusDesc)) ? (" |" + Labels.cnvsDescStatus + ": " + item.StatusDesc) : ""),
						Value = item.ConversationStatusID.ToString(),
						Selected = false
					});
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsStatuslist = list;
		return list;
	}

	public List<CRMspSelectConversationPriority_Result> SelectConversationPriority()
	{
		List<CRMspSelectConversationPriority_Result> result = new List<CRMspSelectConversationPriority_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectConversationPriority_Result>((IEnumerable<CRMspSelectConversationPriority_Result>)_db.CRMspSelectConversationPriority(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> ConversationPrioritySelectListItem()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectConversationPriority_Result> list2 = SelectConversationPriority();
		if (list2 != null)
		{
			list.AddRange(Enumerable.Select<CRMspSelectConversationPriority_Result, SelectListItem>((IEnumerable<CRMspSelectConversationPriority_Result>)list2, (Func<CRMspSelectConversationPriority_Result, SelectListItem>)((CRMspSelectConversationPriority_Result x) => new SelectListItem
			{
				Text = x.Priority,
				Value = x.ConversationPriorityID.ToString()
			})));
		}
		base.ViewBag.ConversationPrioritylist = list;
		return list;
	}

	[HttpPost]
	public string ConversationInsert(string jsModel = "")
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_39cd: Unknown result type (might be due to invalid IL or missing references)
		if (!UserLogin.IsUserAccess("frmDefineConversation", "actPost", UserLogin.CurrentUser))
		{
			return Messages.NotAccessToPage;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmConversationLanguageViewModel crmConversationLanguageViewModel = new CrmConversationLanguageViewModel();
		if (!string.IsNullOrWhiteSpace(jsModel))
		{
			List<CrmConversationLanguageViewModel> list = new JavaScriptSerializer().Deserialize<List<CrmConversationLanguageViewModel>>(jsModel);
			if (list != null)
			{
				crmConversationLanguageViewModel = Enumerable.FirstOrDefault<CrmConversationLanguageViewModel>((IEnumerable<CrmConversationLanguageViewModel>)list);
			}
		}
		DateTime value = (crmConversationLanguageViewModel.RegisterDate = DateTime.Now);
		crmConversationLanguageViewModel.RegisterDatePersian = value.ToString("yyyyMMdd", new PersianCulture());
		crmConversationLanguageViewModel.FirstRegisterDate = value;
		crmConversationLanguageViewModel.cnvsFirstRegisterDate = value.ToString("yyyyMMdd", new PersianCulture());
		crmConversationLanguageViewModel.Year1 = short.Parse(Financial.Get().Id.ToString());
		short value2 = short.Parse(value.ToString("yyyy", new PersianCulture()));
		crmConversationLanguageViewModel.Month1 = short.Parse(value.ToString("MM", new PersianCulture()));
		crmConversationLanguageViewModel.GUId = System.Guid.NewGuid();
		crmConversationLanguageViewModel.AppTypeHelp = Configuration.AppType;
		string appType = Configuration.AppType;
		crmConversationLanguageViewModel.cnvsFirstRegisterDateTime = value;
		int userId = UserLogin.CurrentUser.UserId;
		List<SelectListItem> list2 = new List<SelectListItem>();
		_ = DateTime.Now;
		_ = crmConversationLanguageViewModel.AppType;
		int countError = 0;
		crmConversationLanguageViewModel.cnvsProjectId.GetValueOrDefault();
		GetCompanyQuickRegisterDefSettingForCnvs(crmConversationLanguageViewModel.cnvsProjectId.GetValueOrDefault());
		try
		{
			int? num = null;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserLastCId;
			}
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsSubject_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(crmConversationLanguageViewModel.cnvsSubject_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmConversationLanguageViewModel.cnvsSubject,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsDesc_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(crmConversationLanguageViewModel.cnvsDesc_Lang);
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmConversationLanguageViewModel.cnvsDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsReferDesc_Lang))
				{
					list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(crmConversationLanguageViewModel.cnvsReferDesc_Lang);
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = crmConversationLanguageViewModel.cnvsReferDesc,
					LanguageId = lCID
				});
				bool result = false;
				bool.TryParse(crmConversationLanguageViewModel.IsCloseTicket.ToString(), out result);
				if (result)
				{
					string text = CRMIdeal.Classes.Helper.Company.CheckPrjIsFinishedByPrjPrdHNotDone(crmConversationLanguageViewModel.cnvsProjectId.GetValueOrDefault(), isTicket: true);
					if (!string.IsNullOrWhiteSpace(text))
					{
						countError++;
						list2.Add(new SelectListItem
						{
							Value = "3",
							Text = text + "<br>"
						});
						return JsonConvert.SerializeObject(list2);
					}
				}
				if (crmConversationLanguageViewModel.cnvsDoingTimeFromHour.HasValue || crmConversationLanguageViewModel.cnvsDoingTimeFromMin.HasValue)
				{
					crmConversationLanguageViewModel.cnvsDoingTimeFromHour = crmConversationLanguageViewModel.cnvsDoingTimeFromHour.GetValueOrDefault();
					crmConversationLanguageViewModel.cnvsDoingTimeFromMin = crmConversationLanguageViewModel.cnvsDoingTimeFromMin.GetValueOrDefault();
					string s = ((crmConversationLanguageViewModel.cnvsDoingTimeFromHour <= 9) ? ("0" + crmConversationLanguageViewModel.cnvsDoingTimeFromHour) : crmConversationLanguageViewModel.cnvsDoingTimeFromHour.ToString()) + ":" + ((crmConversationLanguageViewModel.cnvsDoingTimeFromMin <= 9) ? ("0" + crmConversationLanguageViewModel.cnvsDoingTimeFromMin) : crmConversationLanguageViewModel.cnvsDoingTimeFromMin.ToString()) + ":00";
					crmConversationLanguageViewModel.cnvsDoingTimeFrom = TimeSpan.Parse(s);
				}
				if (!crmConversationLanguageViewModel.cnvsDoingTimeFromHour.HasValue && !crmConversationLanguageViewModel.cnvsDoingTimeFromMin.HasValue)
				{
					crmConversationLanguageViewModel.cnvsDoingTimeFrom = null;
				}
				if (crmConversationLanguageViewModel.cnvsDoingTimeToHour.HasValue || crmConversationLanguageViewModel.cnvsDoingTimeToMin.HasValue)
				{
					crmConversationLanguageViewModel.cnvsDoingTimeToHour = crmConversationLanguageViewModel.cnvsDoingTimeToHour.GetValueOrDefault();
					crmConversationLanguageViewModel.cnvsDoingTimeToMin = crmConversationLanguageViewModel.cnvsDoingTimeToMin.GetValueOrDefault();
					string s2 = ((crmConversationLanguageViewModel.cnvsDoingTimeToHour <= 9) ? ("0" + crmConversationLanguageViewModel.cnvsDoingTimeToHour) : crmConversationLanguageViewModel.cnvsDoingTimeToHour.ToString()) + ":" + ((crmConversationLanguageViewModel.cnvsDoingTimeToMin <= 9) ? ("0" + crmConversationLanguageViewModel.cnvsDoingTimeToMin) : crmConversationLanguageViewModel.cnvsDoingTimeToMin.ToString()) + ":00";
					crmConversationLanguageViewModel.cnvsDoingTimeTo = TimeSpan.Parse(s2);
				}
				if (!crmConversationLanguageViewModel.cnvsDoingTimeToHour.HasValue && !crmConversationLanguageViewModel.cnvsDoingTimeToMin.HasValue)
				{
					crmConversationLanguageViewModel.cnvsDoingTimeTo = null;
				}
				if (!crmConversationLanguageViewModel.cnvsDoingTimeTo.HasValue && UserLogin.IsUserAccess("frmDefineConversation", "actAutoSetCnvsDoingTimeTo", UserLogin.CurrentUser))
				{
					DateTime now2 = DateTime.Now;
					string s3 = now2.ToString("HH:mm");
					crmConversationLanguageViewModel.cnvsDoingTimeTo = TimeSpan.Parse(s3);
					crmConversationLanguageViewModel.cnvsDoingTimeToHour = int.Parse(now2.ToString("HH"));
					crmConversationLanguageViewModel.cnvsDoingTimeToMin = int.Parse(now2.ToString("mm"));
				}
				CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(crmConversationLanguageViewModel.cnvsPersonId, lCID, defLangID));
				if (cRMspSelectCompanyPersonsByID_Result == null || cRMspSelectCompanyPersonsByID_Result.prsCompanyId != crmConversationLanguageViewModel.cnvsCompanyId)
				{
					countError++;
					list2.Add(new SelectListItem
					{
						Value = "0",
						Text = Messages.msgErrorPersonNotFoundForContact + "<br>"
					});
					return JsonConvert.SerializeObject(list2);
				}
				if (crmConversationLanguageViewModel.cnvsDoingTimeFrom.HasValue && crmConversationLanguageViewModel.cnvsDoingTimeTo.HasValue)
				{
					if (crmConversationLanguageViewModel.cnvsDoingTimeTo >= crmConversationLanguageViewModel.cnvsDoingTimeFrom)
					{
						string text2 = (crmConversationLanguageViewModel.cnvsDoingTimeTo - crmConversationLanguageViewModel.cnvsDoingTimeFrom).ToString();
						if (!string.IsNullOrWhiteSpace(text2))
						{
							string[] array = text2.Split(new char[1] { ':' });
							if (array != null && array.Length > 2)
							{
								crmConversationLanguageViewModel.cnvsDoingHour = int.Parse(array[0]);
								crmConversationLanguageViewModel.cnvsDoingMin = int.Parse(array[1]);
							}
						}
					}
					else
					{
						string text3 = string.Format(Messages.msgErrorItemNotBeforeOther, Labels.cnvsDoingTimeTo, Labels.cnvsDoingTimeFrom);
						if (!string.IsNullOrWhiteSpace(text3))
						{
							countError++;
							list2.Add(new SelectListItem
							{
								Value = "3",
								Text = text3 + "<br>"
							});
							return JsonConvert.SerializeObject(list2);
						}
					}
				}
				string text4 = ChkBeforeSubmitConversation_Lang(crmConversationLanguageViewModel, list4, ref countError);
				if (!string.IsNullOrWhiteSpace(text4))
				{
					list2.Add(new SelectListItem
					{
						Value = "1",
						Text = text4
					});
				}
				if (UserLogin.IsUserAccess("frmCompanyI", "actNotCanAddNewCnvsForArchivePrj", UserLogin.CurrentUser))
				{
					CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(crmConversationLanguageViewModel.cnvsProjectId, lCID, defLangID));
					if (cRMspSelectCrmProjectsById_Result != null && cRMspSelectCrmProjectsById_Result.prjIsFinished.GetValueOrDefault())
					{
						countError++;
						list2.Add(new SelectListItem
						{
							Value = "1",
							Text = Messages.msgErrorNotCanAddNewCnvsForArchivePrj
						});
					}
				}
				CRMspSelectCompanyConversationLastStatus_Result cRMspSelectCompanyConversationLastStatus_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyConversationLastStatus_Result>((IEnumerable<CRMspSelectCompanyConversationLastStatus_Result>)_db.CRMspSelectCompanyConversationLastStatus(crmConversationLanguageViewModel.cnvsCompanyId, crmConversationLanguageViewModel.cnvsProjectId, lCID, defLangID));
				if (countError == 0)
				{
					Languages languages = Enumerable.FirstOrDefault<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID == defLangID)));
					string culture = ((languages != null && !string.IsNullOrEmpty(languages.LanguageCollation)) ? languages.LanguageCollation : "fa-IR");
					int value3 = 7;
					DateTime.TryParse(PersianDate.GetFormatetdDate(crmConversationLanguageViewModel.cnvsDate.Replace("/", "")) + " " + crmConversationLanguageViewModel.cnvsTime, out var result2);
					crmConversationLanguageViewModel.cnvsDateTime = result2;
					DateTime result3 = DateTime.Now;
					if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsRemindDate))
					{
						DateTime.TryParse(PersianDate.GetFormatetdDate(crmConversationLanguageViewModel.cnvsRemindDate.Replace("/", "")) + " 00:00:00", out result3);
						crmConversationLanguageViewModel.cnvsRemindDateTime = result3;
						crmConversationLanguageViewModel.cnvsRemindDate = result3.ToString("yyyyMMdd", new PersianCulture());
					}
					DateTime result4 = DateTime.Now;
					if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsRemindDateForAllarm))
					{
						string text5 = ((!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsRemindTime)) ? crmConversationLanguageViewModel.cnvsRemindTime : "00:00:00");
						DateTime.TryParse(PersianDate.GetFormatetdDate(crmConversationLanguageViewModel.cnvsRemindDateForAllarm.Replace("/", "")) + " " + text5, out result4);
						crmConversationLanguageViewModel.cnvsRemindDateTimeForAllarm = result4;
					}
					if (crmConversationLanguageViewModel.cnvsDoingHour > 0 || crmConversationLanguageViewModel.cnvsDoingMin > 0)
					{
						long value4 = DateTimeClass.ConvertHourAndMinToSec(crmConversationLanguageViewModel.cnvsDoingHour.GetValueOrDefault(), crmConversationLanguageViewModel.cnvsDoingMin.GetValueOrDefault());
						crmConversationLanguageViewModel.cnvsDoingTimeSec = value4;
					}
					if (!crmConversationLanguageViewModel.cnvsIsCopy.GetValueOrDefault() && (crmConversationLanguageViewModel.cnvsDoingHour > 0 || crmConversationLanguageViewModel.cnvsDoingMin > 0))
					{
						long value5 = DateTimeClass.ConvertHourAndMinToSec(crmConversationLanguageViewModel.cnvsDoingHour.GetValueOrDefault(), crmConversationLanguageViewModel.cnvsDoingMin.GetValueOrDefault());
						crmConversationLanguageViewModel.cnvsDoingTimeSec = value5;
					}
					if (crmConversationLanguageViewModel.cnvsDoingHour <= 0 && crmConversationLanguageViewModel.cnvsDoingMin <= 0)
					{
						crmConversationLanguageViewModel.cnvsDoingTimeSec = null;
					}
					if (!string.IsNullOrWhiteSpace(crmConversationLanguageViewModel.cnvsKnowledgeTankIds))
					{
						if (crmConversationLanguageViewModel.cnvsKnowledgeTankIds.EndsWith(","))
						{
							crmConversationLanguageViewModel.cnvsKnowledgeTankIds = crmConversationLanguageViewModel.cnvsKnowledgeTankIds.TrimEnd(new char[1] { ',' });
						}
						if (crmConversationLanguageViewModel.cnvsKnowledgeTankIds.StartsWith(","))
						{
							crmConversationLanguageViewModel.cnvsKnowledgeTankIds = crmConversationLanguageViewModel.cnvsKnowledgeTankIds.TrimStart(new char[1] { ',' });
						}
						if (crmConversationLanguageViewModel.cnvsKnowledgeTankIds == "-1")
						{
							crmConversationLanguageViewModel.cnvsKnowledgeTankIds = "";
						}
					}
					string[] array2 = null;
					string cnvsMultiReferUserIds = "";
					if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.AppType))
					{
						array2 = crmConversationLanguageViewModel.AppType.Split(new char[1] { '^' });
						if (array2.Length == 2)
						{
							_ = " : " + array2[1] + "\r\n";
							cnvsMultiReferUserIds = array2[0];
						}
					}
					string text6 = "";
					string text7 = "";
					string jsNeedSendErjaAllarm_Lang = "";
					string text8 = "";
					bool value6 = false;
					string needErjaIntmsgSubject = "";
					string needErjaIntmsgBody = "";
					List<CrmInternalMessage_Lang> list6 = new List<CrmInternalMessage_Lang>();
					if (crmConversationLanguageViewModel.cnvsReferUserId != UserLogin.CurrentUser.UserId)
					{
						value6 = true;
						needErjaIntmsgSubject = MyResource.GetResourceString("ConversationErjaFrom", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + CRMIdeal.Classes.Helper.Company.GetUserName(UserLogin.CurrentUser.UserId, defLangID, defLangID);
						string text9 = "";
						if (array2 != null)
						{
							List<CRMspSelectUserForCnvsReferToMultilUser_Result> list7 = Enumerable.ToList<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)_db.CRMspSelectUserForCnvsReferToMultilUser(UserLogin.CurrentUser.UserId, value3, crmConversationLanguageViewModel.cnvsReferUserId, crmConversationLanguageViewModel.cnvsCompanyId, defLangID, defLangID, num));
							string[] array3 = array2[0].Split(new char[1] { '|' });
							foreach (string obj in array3)
							{
								int iid6 = 0;
								int.TryParse(obj.Trim(), out iid6);
								if (iid6 <= 0)
								{
									continue;
								}
								CRMspSelectUserForCnvsReferToMultilUser_Result cRMspSelectUserForCnvsReferToMultilUser_Result = Enumerable.FirstOrDefault<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)list7, (Func<CRMspSelectUserForCnvsReferToMultilUser_Result, bool>)((CRMspSelectUserForCnvsReferToMultilUser_Result c) => c.LinkedUserId == iid6));
								if (cRMspSelectUserForCnvsReferToMultilUser_Result != null)
								{
									if (text9 != "")
									{
										text9 += ", ";
									}
									string text10 = "";
									if (cRMspSelectUserForCnvsReferToMultilUser_Result.cmpAccess == -100)
									{
										text10 = string.Format(" ({0})", MyResource.GetResourceString("CnvsComboReferUserCmpNotAccess", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly));
									}
									text9 = text9 + ((cRMspSelectUserForCnvsReferToMultilUser_Result.UserName != "" && cRMspSelectUserForCnvsReferToMultilUser_Result.UserName != "") ? cRMspSelectUserForCnvsReferToMultilUser_Result.UserName : "") + text10;
								}
							}
						}
						needErjaIntmsgBody = MyResource.GetResourceString("ConversationErjaInConnection", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCompanyName(crmConversationLanguageViewModel.cnvsCompanyId, defLangID, defLangID) + "\r\n" + MyResource.GetResourceString("ConversationErjaPerson", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpPersonName(defLangID, defLangID, crmConversationLanguageViewModel.cnvsPersonId) + "\r\n" + MyResource.GetResourceString("ConversationErjaProject", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpProjectTitle(defLangID, defLangID, crmConversationLanguageViewModel.cnvsProjectId);
						if (!string.IsNullOrEmpty(text9))
						{
							needErjaIntmsgBody = needErjaIntmsgBody + "\r\n" + MyResource.GetResourceString("ConversationErjaMultiUser", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : " + text9;
						}
						needErjaIntmsgBody = needErjaIntmsgBody + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaConversationDescription", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + crmConversationLanguageViewModel.cnvsDesc;
						if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsReferDesc))
						{
							needErjaIntmsgBody = needErjaIntmsgBody + "\r\n" + MyResource.GetResourceString("ConversationErjaReferDescription", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + crmConversationLanguageViewModel.cnvsReferDesc;
						}
						needErjaIntmsgBody = needErjaIntmsgBody + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaDetails", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						foreach (Languages lang4 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
						{
							string text11 = "";
							if (array2 != null)
							{
								List<CRMspSelectUserForCnvsReferToMultilUser_Result> list8 = Enumerable.ToList<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)_db.CRMspSelectUserForCnvsReferToMultilUser(UserLogin.CurrentUser.UserId, value3, crmConversationLanguageViewModel.cnvsReferUserId, crmConversationLanguageViewModel.cnvsCompanyId, lang4.LanguageID, defLangID, num));
								string[] array3 = array2[0].Split(new char[1] { '|' });
								foreach (string obj2 in array3)
								{
									int iid5 = 0;
									int.TryParse(obj2.Trim(), out iid5);
									if (iid5 <= 0)
									{
										continue;
									}
									CRMspSelectUserForCnvsReferToMultilUser_Result cRMspSelectUserForCnvsReferToMultilUser_Result2 = Enumerable.FirstOrDefault<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)list8, (Func<CRMspSelectUserForCnvsReferToMultilUser_Result, bool>)((CRMspSelectUserForCnvsReferToMultilUser_Result c) => c.LinkedUserId == iid5));
									if (cRMspSelectUserForCnvsReferToMultilUser_Result2 != null)
									{
										if (text11 != "")
										{
											text11 += ", ";
										}
										string text12 = "";
										if (cRMspSelectUserForCnvsReferToMultilUser_Result2.cmpAccess == -100)
										{
											text12 = string.Format(" ({0})", MyResource.GetResourceString("CnvsComboReferUserCmpNotAccess", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly));
										}
										text11 = text11 + ((cRMspSelectUserForCnvsReferToMultilUser_Result2.UserName != "" && cRMspSelectUserForCnvsReferToMultilUser_Result2.UserName != "") ? cRMspSelectUserForCnvsReferToMultilUser_Result2.UserName : "") + text12;
									}
								}
							}
							string text13 = MyResource.GetResourceString("ConversationErjaInConnection", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCompanyName(crmConversationLanguageViewModel.cnvsCompanyId, defLangID, lang4.LanguageID) + "\r\n" + MyResource.GetResourceString("ConversationErjaPerson", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpPersonName(defLangID, lang4.LanguageID, crmConversationLanguageViewModel.cnvsPersonId) + "\r\n" + MyResource.GetResourceString("ConversationErjaProject", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpProjectTitle(defLangID, lang4.LanguageID, crmConversationLanguageViewModel.cnvsProjectId) + "\r\n" + MyResource.GetResourceString("ConversationErjaMultiUser", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : " + text11 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaConversationDescription", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)).Value : null);
							if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsReferDesc))
							{
								text13 = text13 + "\r\n" + MyResource.GetResourceString("ConversationErjaReferDescription", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)).Value : null);
							}
							text13 = text13 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaDetails", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							list6.Add(new CrmInternalMessage_Lang
							{
								LanguageID = lang4.LanguageID,
								msgSubject = MyResource.GetResourceString("ConversationErjaFrom", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + CRMIdeal.Classes.Helper.Company.GetUserName(UserLogin.CurrentUser.UserId, defLangID, lang4.LanguageID),
								msgBody = text13
							});
						}
						text8 = JsonConvert.SerializeObject(list6);
					}
					bool value7 = false;
					string needSendErjaAllarmIntmsgSubject = "";
					string needSendErjaAllarmIntmsgBody = "";
					List<CrmInternalMessage_Lang> list9 = new List<CrmInternalMessage_Lang>();
					int num2 = 0;
					if (cRMspSelectCompanyConversationLastStatus_Result != null)
					{
						bool valueOrDefault = Enumerable.FirstOrDefault<bool?>((IEnumerable<bool?>)Enumerable.ToList<bool?>((IEnumerable<bool?>)_db.CRMspSelectDisableReceiveCNVSInfoAllarmStatus(cRMspSelectCompanyConversationLastStatus_Result.cnvsReferUserId))).GetValueOrDefault();
						if (cRMspSelectCompanyConversationLastStatus_Result.cnvsReferUserId != crmConversationLanguageViewModel.cnvsReferUserId && cRMspSelectCompanyConversationLastStatus_Result.cnvsReferUserId != crmConversationLanguageViewModel.cnvsUserId && !valueOrDefault)
						{
							value7 = true;
							num2 = cRMspSelectCompanyConversationLastStatus_Result.cnvsReferUserId.GetValueOrDefault();
							string text14 = "";
							if (array2 != null)
							{
								List<CRMspSelectUserForCnvsReferToMultilUser_Result> list10 = Enumerable.ToList<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)_db.CRMspSelectUserForCnvsReferToMultilUser(UserLogin.CurrentUser.UserId, value3, crmConversationLanguageViewModel.cnvsReferUserId, crmConversationLanguageViewModel.cnvsCompanyId, defLangID, defLangID, num));
								string[] array3 = array2[0].Split(new char[1] { '|' });
								foreach (string obj3 in array3)
								{
									int iid4 = 0;
									int.TryParse(obj3.Trim(), out iid4);
									if (iid4 <= 0)
									{
										continue;
									}
									CRMspSelectUserForCnvsReferToMultilUser_Result cRMspSelectUserForCnvsReferToMultilUser_Result3 = Enumerable.FirstOrDefault<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)list10, (Func<CRMspSelectUserForCnvsReferToMultilUser_Result, bool>)((CRMspSelectUserForCnvsReferToMultilUser_Result c) => c.LinkedUserId == iid4));
									if (cRMspSelectUserForCnvsReferToMultilUser_Result3 != null)
									{
										if (text14 != "")
										{
											text14 += ", ";
										}
										string text15 = "";
										if (cRMspSelectUserForCnvsReferToMultilUser_Result3.cmpAccess == -100)
										{
											text15 = string.Format(" ({0})", MyResource.GetResourceString("CnvsComboReferUserCmpNotAccess", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly));
										}
										text14 = text14 + ((cRMspSelectUserForCnvsReferToMultilUser_Result3.UserName != "" && cRMspSelectUserForCnvsReferToMultilUser_Result3.UserName != "") ? cRMspSelectUserForCnvsReferToMultilUser_Result3.UserName : "") + text15;
									}
								}
							}
							needSendErjaAllarmIntmsgSubject = MyResource.GetResourceString("ConversationErjaNotice", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + CRMIdeal.Classes.Helper.Company.GetUserName(UserLogin.CurrentUser.UserId, defLangID, defLangID);
							needSendErjaAllarmIntmsgBody = "**" + MyResource.GetResourceString("ConversationErjaAutomatically", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaAttention", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ConversationErjaInConnection", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCompanyName(crmConversationLanguageViewModel.cnvsCompanyId, defLangID, defLangID) + "\r\n" + MyResource.GetResourceString("ConversationErjaPerson", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpPersonName(defLangID, defLangID, crmConversationLanguageViewModel.cnvsPersonId) + "\r\n" + MyResource.GetResourceString("ConversationErjaProject", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpProjectTitle(defLangID, defLangID, crmConversationLanguageViewModel.cnvsProjectId) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaLastNegotiator", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("ConversationErjaTransmitter", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ConversationErjaMultiUser", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : " + text14 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaConversationDescription", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n" + crmConversationLanguageViewModel.cnvsDesc;
							if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsReferDesc))
							{
								needSendErjaAllarmIntmsgBody = needSendErjaAllarmIntmsgBody + "\r\n" + MyResource.GetResourceString("ConversationErjaReferDescription", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + crmConversationLanguageViewModel.cnvsReferDesc;
							}
							needSendErjaAllarmIntmsgBody = needSendErjaAllarmIntmsgBody + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaDetails", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							foreach (Languages lang3 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
							{
								string text16 = "";
								if (array2 != null)
								{
									List<CRMspSelectUserForCnvsReferToMultilUser_Result> list11 = Enumerable.ToList<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)_db.CRMspSelectUserForCnvsReferToMultilUser(UserLogin.CurrentUser.UserId, value3, crmConversationLanguageViewModel.cnvsReferUserId, crmConversationLanguageViewModel.cnvsCompanyId, lang3.LanguageID, defLangID, num));
									string[] array3 = array2[0].Split(new char[1] { '|' });
									foreach (string obj4 in array3)
									{
										int iid3 = 0;
										int.TryParse(obj4.Trim(), out iid3);
										if (iid3 <= 0)
										{
											continue;
										}
										CRMspSelectUserForCnvsReferToMultilUser_Result cRMspSelectUserForCnvsReferToMultilUser_Result4 = Enumerable.FirstOrDefault<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)list11, (Func<CRMspSelectUserForCnvsReferToMultilUser_Result, bool>)((CRMspSelectUserForCnvsReferToMultilUser_Result c) => c.LinkedUserId == iid3));
										if (cRMspSelectUserForCnvsReferToMultilUser_Result4 != null)
										{
											if (text16 != "")
											{
												text16 += ", ";
											}
											string text17 = "";
											if (cRMspSelectUserForCnvsReferToMultilUser_Result4.cmpAccess == -100)
											{
												text17 = string.Format(" ({0})", MyResource.GetResourceString("CnvsComboReferUserCmpNotAccess", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly));
											}
											text16 = text16 + ((cRMspSelectUserForCnvsReferToMultilUser_Result4.UserName != "" && cRMspSelectUserForCnvsReferToMultilUser_Result4.UserName != "") ? cRMspSelectUserForCnvsReferToMultilUser_Result4.UserName : "") + text17;
										}
									}
								}
								string text18 = "";
								text18 = "**" + MyResource.GetResourceString("ConversationErjaAutomatically", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaAttention", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ConversationErjaInConnection", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCompanyName(crmConversationLanguageViewModel.cnvsCompanyId, defLangID, lang3.LanguageID) + "\r\n" + MyResource.GetResourceString("ConversationErjaPerson", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpPersonName(defLangID, lang3.LanguageID, crmConversationLanguageViewModel.cnvsPersonId) + "\r\n" + MyResource.GetResourceString("ConversationErjaProject", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpProjectTitle(defLangID, lang3.LanguageID, crmConversationLanguageViewModel.cnvsProjectId) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaLastNegotiator", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("ConversationErjaTransmitter", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ConversationErjaMultiUser", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : " + text16 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaConversationDescription", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n" + ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)).Value : null);
								if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsReferDesc))
								{
									text18 = text18 + "\r\n" + MyResource.GetResourceString("ConversationErjaReferDescription", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)).Value : null);
								}
								text18 = text18 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaDetails", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								list9.Add(new CrmInternalMessage_Lang
								{
									LanguageID = lang3.LanguageID,
									msgSubject = MyResource.GetResourceString("ConversationErjaNotice", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + CRMIdeal.Classes.Helper.Company.GetUserName(UserLogin.CurrentUser.UserId, defLangID, lang3.LanguageID),
									msgBody = text18
								});
							}
							jsNeedSendErjaAllarm_Lang = JsonConvert.SerializeObject(list9);
						}
					}
					bool value8 = false;
					string needErjaMultiIntmsgSubject = "";
					string needErjaMultiIntmsgBody = "";
					List<CrmInternalMessage_Lang> list12 = new List<CrmInternalMessage_Lang>();
					if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.AppType))
					{
						value8 = true;
						string text19 = "";
						if (array2 != null)
						{
							List<CRMspSelectUserForCnvsReferToMultilUser_Result> list13 = Enumerable.ToList<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)_db.CRMspSelectUserForCnvsReferToMultilUser(UserLogin.CurrentUser.UserId, value3, crmConversationLanguageViewModel.cnvsReferUserId, crmConversationLanguageViewModel.cnvsCompanyId, defLangID, defLangID, num));
							string[] array3 = array2[0].Split(new char[1] { '|' });
							foreach (string obj5 in array3)
							{
								int iid2 = 0;
								int.TryParse(obj5.Trim(), out iid2);
								if (iid2 <= 0)
								{
									continue;
								}
								CRMspSelectUserForCnvsReferToMultilUser_Result cRMspSelectUserForCnvsReferToMultilUser_Result5 = Enumerable.FirstOrDefault<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)list13, (Func<CRMspSelectUserForCnvsReferToMultilUser_Result, bool>)((CRMspSelectUserForCnvsReferToMultilUser_Result c) => c.LinkedUserId == iid2));
								if (cRMspSelectUserForCnvsReferToMultilUser_Result5 != null)
								{
									if (text19 != "")
									{
										text19 += ", ";
									}
									string text20 = "";
									if (cRMspSelectUserForCnvsReferToMultilUser_Result5.cmpAccess == -100)
									{
										text20 = string.Format(" ({0})", MyResource.GetResourceString("CnvsComboReferUserCmpNotAccess", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly));
									}
									text19 = text19 + ((cRMspSelectUserForCnvsReferToMultilUser_Result5.UserName != "" && cRMspSelectUserForCnvsReferToMultilUser_Result5.UserName != "") ? cRMspSelectUserForCnvsReferToMultilUser_Result5.UserName : "") + text20;
								}
							}
						}
						needErjaMultiIntmsgSubject = MyResource.GetResourceString("ConversationErjaRonevesht", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + CRMIdeal.Classes.Helper.Company.GetUserName(UserLogin.CurrentUser.UserId, defLangID, defLangID);
						needErjaMultiIntmsgBody = MyResource.GetResourceString("ConversationErjaInConnection", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCompanyName(crmConversationLanguageViewModel.cnvsCompanyId, defLangID, defLangID) + " \r\n" + MyResource.GetResourceString("ConversationErjaPerson", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpPersonName(defLangID, defLangID, crmConversationLanguageViewModel.cnvsPersonId) + " \r\n" + MyResource.GetResourceString("ConversationErjaProject", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpProjectTitle(defLangID, defLangID, crmConversationLanguageViewModel.cnvsProjectId) + "\r\n" + MyResource.GetResourceString("ConversationErjaMultiUser", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : " + text19 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaConversationDescription", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n" + crmConversationLanguageViewModel.cnvsDesc;
						if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsReferDesc))
						{
							needErjaMultiIntmsgBody = needErjaMultiIntmsgBody + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaReferDescription", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + crmConversationLanguageViewModel.cnvsReferDesc;
						}
						needErjaMultiIntmsgBody = needErjaMultiIntmsgBody + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaDetails", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						foreach (Languages lang2 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
						{
							string text21 = "";
							if (array2 != null)
							{
								List<CRMspSelectUserForCnvsReferToMultilUser_Result> list14 = Enumerable.ToList<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)_db.CRMspSelectUserForCnvsReferToMultilUser(UserLogin.CurrentUser.UserId, value3, crmConversationLanguageViewModel.cnvsReferUserId, crmConversationLanguageViewModel.cnvsCompanyId, lang2.LanguageID, defLangID, num));
								string[] array3 = array2[0].Split(new char[1] { '|' });
								foreach (string obj6 in array3)
								{
									int iid = 0;
									int.TryParse(obj6.Trim(), out iid);
									if (iid <= 0)
									{
										continue;
									}
									CRMspSelectUserForCnvsReferToMultilUser_Result cRMspSelectUserForCnvsReferToMultilUser_Result6 = Enumerable.FirstOrDefault<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)list14, (Func<CRMspSelectUserForCnvsReferToMultilUser_Result, bool>)((CRMspSelectUserForCnvsReferToMultilUser_Result c) => c.LinkedUserId == iid));
									if (cRMspSelectUserForCnvsReferToMultilUser_Result6 != null)
									{
										if (text21 != "")
										{
											text21 += ", ";
										}
										string text22 = "";
										if (cRMspSelectUserForCnvsReferToMultilUser_Result6.cmpAccess == -100)
										{
											text22 = string.Format(" ({0})", MyResource.GetResourceString("CnvsComboReferUserCmpNotAccess", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly));
										}
										text21 = text21 + ((cRMspSelectUserForCnvsReferToMultilUser_Result6.UserName != "" && cRMspSelectUserForCnvsReferToMultilUser_Result6.UserName != "") ? cRMspSelectUserForCnvsReferToMultilUser_Result6.UserName : "") + text22;
									}
								}
							}
							string text23 = MyResource.GetResourceString("ConversationErjaInConnection", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCompanyName(crmConversationLanguageViewModel.cnvsCompanyId, defLangID, lang2.LanguageID) + " \r\n" + MyResource.GetResourceString("ConversationErjaPerson", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpPersonName(defLangID, lang2.LanguageID, crmConversationLanguageViewModel.cnvsPersonId) + " \r\n" + MyResource.GetResourceString("ConversationErjaProject", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpProjectTitle(defLangID, lang2.LanguageID, crmConversationLanguageViewModel.cnvsProjectId) + "\r\n" + MyResource.GetResourceString("ConversationErjaMultiUser", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : " + text21 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaConversationDescription", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n" + ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
							if (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsReferDesc))
							{
								text23 = text23 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaReferDescription", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
							}
							text23 = text23 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaDetails", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							list12.Add(new CrmInternalMessage_Lang
							{
								LanguageID = lang2.LanguageID,
								msgSubject = MyResource.GetResourceString("ConversationErjaRonevesht", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + CRMIdeal.Classes.Helper.Company.GetUserName(UserLogin.CurrentUser.UserId, defLangID, lang2.LanguageID),
								msgBody = text23
							});
						}
						array2 = crmConversationLanguageViewModel.AppType.Split(new char[1] { '^' });
						if (array2.Length == 2)
						{
							new List<CrmInternalMessage_Lang>();
							text7 = JsonConvert.SerializeObject(list12);
						}
					}
					List<CrmConversation_Lang> list15 = new List<CrmConversation_Lang>();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						list15.Add(new CrmConversation_Lang
						{
							LanguageID = lang.LanguageID,
							cnvsSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							cnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							cnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						});
					}
					text6 = JsonConvert.SerializeObject(list15);
					try
					{
						CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result2 = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(crmConversationLanguageViewModel.cnvsProjectId, lCID, defLangID));
						if (cRMspSelectCrmProjectsById_Result2 != null)
						{
							if (cRMspSelectCrmProjectsById_Result2.prjIsTicket.HasValue && cRMspSelectCrmProjectsById_Result2.prjIsTicket.GetValueOrDefault())
							{
								crmConversationLanguageViewModel.cnvsIsTicket = true;
								crmConversationLanguageViewModel.cnvsFOCmpCanSee = true;
							}
							if (cRMspSelectCrmProjectsById_Result2.prjFOCmpCanSee.HasValue && cRMspSelectCrmProjectsById_Result2.prjFOCmpCanSee.GetValueOrDefault())
							{
								crmConversationLanguageViewModel.prjFOCmpCanSee = true;
							}
						}
						if (UserLogin.IsUserAccess("frmDefineConversation", "actDefSelectFOCmpCanSee", UserLogin.CurrentUser) && crmConversationLanguageViewModel.prjFOCmpCanSee.GetValueOrDefault())
						{
							crmConversationLanguageViewModel.cnvsFOCmpCanSee = true;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					bool result5 = false;
					bool.TryParse(crmConversationLanguageViewModel.cnvsIsTicket.ToString(), out result5);
					if (result5)
					{
						value7 = false;
					}
					string conversationErjaShow = Messages.ConversationErjaShow;
					string currTime = value.ToString("HH:mm:ss");
					ObjectParameter objectParameter = new ObjectParameter("ConversationInsertedId", 0);
					_dbI.CRMspAddConversation(crmConversationLanguageViewModel.ConversationID, crmConversationLanguageViewModel.cnvsProjectId, crmConversationLanguageViewModel.cnvsCompanyId, crmConversationLanguageViewModel.cnvsPersonId, (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsDate)) ? DateTime.Parse(PersianDate.GetFormatetdDate(crmConversationLanguageViewModel.cnvsDate.Replace("/", ""))).ToString("yyyyMMdd", new PersianCulture()) : null, crmConversationLanguageViewModel.cnvsTime, crmConversationLanguageViewModel.cnvsDateTime, crmConversationLanguageViewModel.cnvsTopicId, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, crmConversationLanguageViewModel.cnvsReferUserId, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, crmConversationLanguageViewModel.cnvsStatusId, crmConversationLanguageViewModel.cnvsPriorityId, (!string.IsNullOrWhiteSpace(crmConversationLanguageViewModel.cnvsRemindDate)) ? crmConversationLanguageViewModel.cnvsRemindDate : null, (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsRemindTime)) ? crmConversationLanguageViewModel.cnvsRemindTime : null, crmConversationLanguageViewModel.cnvsRemindDateTime, crmConversationLanguageViewModel.cnvsRemindOk, crmConversationLanguageViewModel.cnvsIsBookMark, (!string.IsNullOrEmpty(crmConversationLanguageViewModel.cnvsRemindDateForAllarm)) ? DateTime.Parse(PersianDate.GetFormatetdDate(crmConversationLanguageViewModel.cnvsRemindDateForAllarm.Replace("/", ""))).ToString("yyyyMMdd", new PersianCulture()) : null, crmConversationLanguageViewModel.cnvsRemindDateTimeForAllarm, "", crmConversationLanguageViewModel.cnvsFOCmpCanSee, crmConversationLanguageViewModel.cnvsIsTicket, "", "", null, "", false, crmConversationLanguageViewModel.cnvsDoingTime, crmConversationLanguageViewModel.cnvsIsCopy.GetValueOrDefault(), currTime, text6 ?? "", (array2 != null && array2.Length != 0) ? array2[0].Replace("|", ",") : "", value8, needErjaMultiIntmsgSubject, needErjaMultiIntmsgBody, conversationErjaShow, text7 ?? "", value6, needErjaIntmsgSubject, needErjaIntmsgBody, conversationErjaShow, text8 ?? "", (num2 != 0) ? new int?(num2) : null, value7, needSendErjaAllarmIntmsgSubject, needSendErjaAllarmIntmsgBody, conversationErjaShow, jsNeedSendErjaAllarm_Lang, "", crmConversationLanguageViewModel.CallHistoryIds, userId, crmConversationLanguageViewModel.cnvsUserId, crmConversationLanguageViewModel.RegisterDate, crmConversationLanguageViewModel.RegisterDatePersian, crmConversationLanguageViewModel.Year1, value2, crmConversationLanguageViewModel.Month1, appType, lCID, defLangID, objectParameter, crmConversationLanguageViewModel.cnvsDoingTimeSec, crmConversationLanguageViewModel.cnvsStatusResultId, crmConversationLanguageViewModel.cnvsDoingTimeFrom, crmConversationLanguageViewModel.cnvsDoingTimeTo, crmConversationLanguageViewModel.cnvsKnowledgeTankIds, crmConversationLanguageViewModel.cnvsIsCopyRemindDate.GetValueOrDefault(), crmConversationLanguageViewModel.cnvsIsCopyRemindDateForAllarm.GetValueOrDefault(), num);
					int? centerId = CRMIdeal.Classes.Helper.Company.GetPrjCId(crmConversationLanguageViewModel.cnvsProjectId.GetValueOrDefault());
					if (centerId.GetValueOrDefault() == 0)
					{
						centerId = num;
					}
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "0" || objectParameter.Value.ToString() == "-1")
						{
							list2.Add(new SelectListItem
							{
								Value = "2",
								Text = Messages.msgErrorRunFunction
							});
							crmConversationLanguageViewModel.ConversationID = 0;
						}
						else
						{
							crmConversationLanguageViewModel.ConversationID = int.Parse(objectParameter.Value.ToString());
							list2.Add(new SelectListItem
							{
								Value = "Id",
								Text = crmConversationLanguageViewModel.ConversationID.ToString()
							});
						}
					}
					if (crmConversationLanguageViewModel.ConversationID > 0)
					{
						if (crmConversationLanguageViewModel.ConversationID > 0)
						{
							List<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result> list16 = Enumerable.ToList<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result>((IEnumerable<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result>)_dbI.CRMspSelectFilesDirectoryTemplateByTypeAndUser(2, userId));
							string pathFtp = Configuration.PathFtp;
							string userNameFtp = Configuration.UserNameFtp;
							string passwordFtp = Configuration.PasswordFtp;
							bool usePassiveFtp = Configuration.UsePassiveFtp;
							int? fileCId = null;
							if (num.GetValueOrDefault() != 0)
							{
								fileCId = num;
							}
							foreach (CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result item in list16)
							{
								DateTime now3 = DateTime.Now;
								CrmFilesDirectory crmFilesDirectory = new CrmFilesDirectory
								{
									UserId = userId,
									FirstRegisterUserId = userId,
									Year1 = crmConversationLanguageViewModel.Year1,
									Month1 = short.Parse(now3.ToString("MM", new PersianCulture())),
									GUId = System.Guid.NewGuid(),
									RegisterDate = now3,
									RegisterDatePersian = now3.ToString("yyyyMMdd", new PersianCulture()),
									FirstRegisterDate = now3,
									FirstRegisterDatePersian = now3.ToString("yyyyMMdd", new PersianCulture()),
									DocDateTime = now3,
									DocTime = now3.ToString("HH:mm:ss"),
									DocDay = PersianDate.GetNumberWeekOfDay(now3.ToString("yyyy/MM/dd", new PersianCulture())).ToString(),
									DocDate = now3.ToString("yyyyMMdd", new PersianCulture()),
									Title = item.Title,
									TypeOprObjectId = crmConversationLanguageViewModel.ConversationID,
									FileDirectoryTypeId = item.FileDirectoryTypeId,
									MasterId = crmConversationLanguageViewModel.cnvsCompanyId,
									DetailId = crmConversationLanguageViewModel.cnvsPersonId,
									SubDetailId = crmConversationLanguageViewModel.cnvsProjectId,
									FolderName = crmConversationLanguageViewModel.cnvsCompanyId.ToString(),
									LanguageID = defLangID,
									FilePath = "",
									FileName = "",
									AppType = appType,
									FileCId = fileCId
								};
								_dbTbl.CrmFilesDirectory.Add(crmFilesDirectory);
								_dbTbl.SaveChanges();
								if (crmFilesDirectory.FileDirectoryID <= 0)
								{
									continue;
								}
								FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
								string mainDirectoryPath = Configuration.MainDirectoryPath;
								string directoryName = crmConversationLanguageViewModel.cnvsCompanyId.ToString();
								bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, directoryName, usePassiveFtp);
								if (!flag)
								{
									flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, directoryName, usePassiveFtp);
								}
								if (flag)
								{
									string text24 = "";
									string text25 = "";
									mainDirectoryPath = mainDirectoryPath + crmConversationLanguageViewModel.cnvsCompanyId + "/";
									string[] array4 = item.CopyFromPath.Split(new char[1] { '.' });
									text24 = crmConversationLanguageViewModel.cnvsCompanyId + "-" + crmFilesDirectory.FileDirectoryID + "." + array4[^1];
									mainDirectoryPath += text24;
									text25 = item.CopyFromPath;
									if (text25 != "")
									{
										facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, text25, usePassiveFtp);
									}
									crmFilesDirectory.FilePath = mainDirectoryPath;
									crmFilesDirectory.FileName = text24;
									crmFilesDirectory.AppType = appType;
									_dbTbl.Entry(crmFilesDirectory).State = EntityState.Modified;
									_dbTbl.SaveChanges();
								}
							}
							try
							{
								_dbI.CRMspDeleteFilesDirectoryTemplateByTypeAndUser(2, UserLogin.CurrentUser.UserId);
								string text26 = Configuration.HostTempFilesPath + "/" + Configuration.CnvsDirectoryPath;
								string path = base.Server.MapPath(text26 + UserLogin.CurrentUser.UserId + "/");
								if (Directory.Exists(path))
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
									Directory.Delete(path);
								}
							}
							catch (Exception e2)
							{
								ErrorSignal.FromCurrentContext().Raise(e2);
							}
						}
						string text27 = "";
						if (crmConversationLanguageViewModel.cnvsStatusResultId.HasValue)
						{
							int conversationID = crmConversationLanguageViewModel.ConversationID;
							CRMspSelectConversationStatusResultById_Result cRMspSelectConversationStatusResultById_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusResultById_Result>((IEnumerable<CRMspSelectConversationStatusResultById_Result>)_dbI.CRMspSelectConversationStatusResultById(crmConversationLanguageViewModel.cnvsStatusResultId, lCID, defLangID));
							if (cRMspSelectConversationStatusResultById_Result == null)
							{
								base.ViewBag.SuccessfullConversationInsert = Messages.cnvsConversationInsertSuccessFulMessage;
							}
							else
							{
								DateTime now4 = DateTime.Now;
								DateTime value9 = now4;
								string registerDatePersian = now4.ToString("yyyyMMdd", new PersianCulture());
								short value10 = short.Parse(now4.ToString("MM", new PersianCulture()));
								string appType2 = Configuration.AppType;
								short value11 = short.Parse(Financial.Get().Id.ToString());
								int userId2 = UserLogin.CurrentUser.UserId;
								string conversationErjaShow2 = Messages.ConversationErjaShow;
								bool result6 = false;
								bool.TryParse(cRMspSelectConversationStatusResultById_Result.EventPolicyActive.ToString(), out result6);
								string text28 = "";
								string surveyMainExtrenalLinkLogin = "";
								string surveyMainExtrenalLink = "";
								Uri url = base.HttpContext.Request.Url;
								string text29 = url.Scheme + "://" + url.Authority;
								if (text29.EndsWith("/"))
								{
									text29 = text29.TrimEnd(new char[1] { '/' });
								}
								text29 += "/Survey/Home/SurveyAnswerValues";
								text28 = text29;
								string text30 = "";
								CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
								string text31 = "";
								string text32 = "";
								if (cRMspSelectCrmsysSetting_Result != null)
								{
									text31 = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
									text32 = cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
								}
								if (!string.IsNullOrWhiteSpace(text31))
								{
									text30 = text31.Trim();
									if (!text30.Contains("http"))
									{
										text30 = url.Scheme + "://" + text30;
									}
									if (text30.EndsWith("/"))
									{
										text30 = text30.TrimEnd(new char[1] { '/' });
									}
									text30 += "/Survey/Home";
									surveyMainExtrenalLinkLogin = text30;
								}
								if (!string.IsNullOrWhiteSpace(text32))
								{
									text30 = text32.Trim();
									if (!text30.Contains("http"))
									{
										text30 = url.Scheme + "://" + text30;
									}
									if (text30.EndsWith("/"))
									{
										text30 = text30.TrimEnd(new char[1] { '/' });
									}
									text30 += "/Survey/Register/Index";
									surveyMainExtrenalLink = text30;
								}
								int maxFOCount = Configuration.MaxFOCount;
								ObjectParameter objectParameter2 = new ObjectParameter("ResultJson", "");
								_dbI.CRMspCnvsStatusResultEventExecute(conversationID, cnvsMultiReferUserIds, null, false, text28, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, conversationErjaShow2, "", userId2, value11, value10, value9, registerDatePersian, appType2, lCID, defLangID, objectParameter2, centerId, maxFOCount);
								string text33 = "";
								if (objectParameter2 != null && objectParameter2.Value != null && !string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
								{
									List<CRMspRunCnvsStatusResultEventPolicyViewModel> list17 = new JavaScriptSerializer().Deserialize<List<CRMspRunCnvsStatusResultEventPolicyViewModel>>(objectParameter2.Value.ToString());
									if (list17 != null && Enumerable.Any<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list17) && Enumerable.FirstOrDefault<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list17, (Func<CRMspRunCnvsStatusResultEventPolicyViewModel, bool>)((CRMspRunCnvsStatusResultEventPolicyViewModel m) => m.EventPolicyTypeId.GetValueOrDefault() == 14 && (m.EventPolicyShortText ?? "") == "FOCountModule")) != null)
									{
										string companyNameWithTitle = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(crmConversationLanguageViewModel.cnvsCompanyId);
										text27 = "<br>" + string.Format(Messages.msgLackCapacityCmpFoNotActive, companyNameWithTitle);
										list17 = Enumerable.ToList<CRMspRunCnvsStatusResultEventPolicyViewModel>(Enumerable.Where<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list17, (Func<CRMspRunCnvsStatusResultEventPolicyViewModel, bool>)((CRMspRunCnvsStatusResultEventPolicyViewModel m) => m.EventPolicyTypeId.GetValueOrDefault() != 14 && (m.EventPolicyShortText ?? "") != "FOCountModule")));
										list2.Add(new SelectListItem
										{
											Value = "6",
											Text = Messages.cnvsConversationInsertSuccessFulMessage + text27
										});
									}
									if (list17 != null && Enumerable.Any<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list17))
									{
										CRMspRunCnvsStatusResultEventPolicyViewModel cRMspRunCnvsStatusResultEventPolicyViewModel = Enumerable.FirstOrDefault<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list17, (Func<CRMspRunCnvsStatusResultEventPolicyViewModel, bool>)((CRMspRunCnvsStatusResultEventPolicyViewModel m) => (m.MessageError ?? "") != ""));
										if (cRMspRunCnvsStatusResultEventPolicyViewModel != null)
										{
											text33 = cRMspRunCnvsStatusResultEventPolicyViewModel.MessageError ?? "";
										}
									}
								}
								if (!string.IsNullOrWhiteSpace(text33))
								{
									list2.Add(new SelectListItem
									{
										Value = "6",
										Text = Messages.msgErrorRunFunction + "<br>" + text33
									});
								}
							}
						}
						Alarms.Update(crmConversationLanguageViewModel.UserId);
						Alarms.Update(crmConversationLanguageViewModel.cnvsReferUserId);
						Alarms.Update(userId);
						string text34 = "";
						try
						{
							foreach (CRMspLoadRemindingTask_Result item2 in Alarms.Get(userId))
							{
								if (text34.Trim() != "")
								{
									text34 += "@";
								}
								text34 = text34 + item2.Type + "|" + item2.UserTaskId + "|" + item2.UserTaskTitle + "|" + item2.UserTaskTime + "|" + item2.UserTaskDatePersian + "|" + item2.UserTaskRemindTime + "|" + item2.UserTaskRemindDate + "|" + item2.Val1 + "|" + item2.Val2 + "|" + item2.Val3 + "|" + item2.UserTaskDate.ToString() + "|" + item2.UserTaskRemindDateTime.ToString() + "|" + ((item2.IsRecurringTask != false) ? 1 : 0);
							}
						}
						catch (Exception ex)
						{
							ErrorSignal.FromCurrentContext().Raise(ex);
							list2.Add(new SelectListItem
							{
								Value = "8",
								Text = ex.Message
							});
						}
						if (!string.IsNullOrWhiteSpace(text34))
						{
							list2.Add(new SelectListItem
							{
								Value = "7",
								Text = text34
							});
						}
						if (crmConversationLanguageViewModel.IsCloseTicket)
						{
							int userId3 = UserLogin.CurrentUser.UserId;
							DateTime now5 = DateTime.Now;
							DateTime value12 = now5;
							string registerDatePersian2 = now5.ToString("yyyyMMdd", new PersianCulture());
							short value13 = short.Parse(now5.ToString("MM", new PersianCulture()));
							short value14 = short.Parse(Financial.Get().Id.ToString());
							string appType3 = Configuration.AppType;
							_dbI.CRMspCloseTicket(crmConversationLanguageViewModel.cnvsProjectId, userId3, value14, value13, value12, registerDatePersian2, appType3, num);
						}
						bool result7 = false;
						bool.TryParse(crmConversationLanguageViewModel.cnvsIsTicket.ToString(), out result7);
						if (result7 && crmConversationLanguageViewModel.ConversationID > 0)
						{
							int userId4 = UserLogin.CurrentUser.UserId;
							DateTime now6 = DateTime.Now;
							DateTime value15 = now6;
							string registerDatePersian3 = now6.ToString("yyyyMMdd", new PersianCulture());
							short value16 = short.Parse(now6.ToString("MM", new PersianCulture()));
							short value17 = short.Parse(Financial.Get().Id.ToString());
							string appType4 = Configuration.AppType;
							_dbI.CRMspCalcAndUpdateTicketDoingDuration(crmConversationLanguageViewModel.ConversationID, userId4, value17, value16, value15, registerDatePersian3, appType4);
						}
						if (UserLogin.IsUserAccess("frmDefineConversation", "actCanChangePrjTicketStop", UserLogin.CurrentUser) && result7 && crmConversationLanguageViewModel.ConversationID > 0)
						{
							int userId5 = UserLogin.CurrentUser.UserId;
							DateTime now7 = DateTime.Now;
							string prjTicketStopRegisterDatePersian = now7.ToString("yyyyMMdd", new PersianCulture());
							string appType5 = Configuration.AppType;
							_dbI.CRMspUpdateProjectTicketStop(crmConversationLanguageViewModel.cnvsProjectId, crmConversationLanguageViewModel.prjTicketStop, userId5, now7, prjTicketStopRegisterDatePersian, appType5);
						}
						bool valueOrDefault2 = crmConversationLanguageViewModel.cnvsIsTicket.GetValueOrDefault();
						bool valueOrDefault3 = crmConversationLanguageViewModel.cnvsFOCmpCanSee.GetValueOrDefault();
						if (valueOrDefault2 && valueOrDefault3)
						{
							CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result3 = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(crmConversationLanguageViewModel.cnvsProjectId, lCID, defLangID));
							if (cRMspSelectCrmProjectsById_Result3 != null)
							{
								int result8 = 0;
								int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspGetUnReadTicketWithCmpId(crmConversationLanguageViewModel.cnvsCompanyId));
								if (num3.HasValue)
								{
									int.TryParse(num3.ToString(), out result8);
								}
								string body = cRMspSelectCrmProjectsById_Result3.ProjectTitle ?? "";
								Dictionary<string, string> dictionary = new Dictionary<string, string>();
								dictionary.Add("UnReadTicketCnt", result8.ToString());
								dictionary.Add("cnvsId", crmConversationLanguageViewModel.ConversationID.ToString());
								dictionary.Add("prjId", crmConversationLanguageViewModel.cnvsProjectId.ToString());
								PushNotif.NewTicketNotify(crmConversationLanguageViewModel.cnvsCompanyId, Labels.CnvsSendNotifNewTicket, body, dictionary);
							}
						}
						string errorMsg = "";
						if (!CRMIdeal.Classes.Helper.OtherSystems.SendCmpToLinkAccByShpIsActive(crmConversationLanguageViewModel.cnvsCompanyId, num.GetValueOrDefault(), ref errorMsg))
						{
							int result9 = 0;
							string text35 = "";
							CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result2 = SysSeting.Get();
							if (cRMspSelectCrmsysSetting_Result2 != null)
							{
								int.TryParse(cRMspSelectCrmsysSetting_Result2.LinkAccSystemId.ToString(), out result9);
							}
							text35 = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
							list2.Add(new SelectListItem
							{
								Value = "6",
								Text = Messages.cnvsConversationInsertSuccessFulMessage + "<br>" + string.Format(Messages.msgErrorSendCmpToOtherSystem, text35) + "<br>" + errorMsg
							});
						}
						PushNotif.NewIntMsgNotify();
					}
				}
			}
			else
			{
				list2.Add(new SelectListItem
				{
					Value = "3",
					Text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)))
				});
			}
		}
		catch (DbEntityValidationException e3)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e3);
			list2.Add(new SelectListItem
			{
				Value = "4",
				Text = Messages.frmErrorMessage
			});
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			list2.Add(new SelectListItem
			{
				Value = "5",
				Text = Messages.frmErrorMessage
			});
		}
		return JsonConvert.SerializeObject(list2);
	}

	[AjaxOnly]
	public JsonResult GetCompanyQuickRegisterDefSettingForCnvs(int projectId)
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
			List<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result> list2 = Enumerable.ToList<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result>)_dbI.CRMspSelectCompanyQuickRegisterDefSettingForCnvs(projectId, lCID, result, UserLogin.CurrentUser.UserId));
			int selectedSettingId = Enumerable.FirstOrDefault<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result>)list2, (Func<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result, bool>)((CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result s) => s.IsDefaultForConversation.HasValue && s.IsDefaultForConversation.GetValueOrDefault()))?.CompanyQuickRegisterDefSettingId ?? 0;
			if (selectedSettingId == 0)
			{
				selectedSettingId = Enumerable.FirstOrDefault<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result>)list2, (Func<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result, bool>)((CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result s) => s.IsDefaultForCmpInfo.HasValue && s.IsDefaultForCmpInfo.GetValueOrDefault()))?.CompanyQuickRegisterDefSettingId ?? 0;
			}
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result>)list2, (Func<CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result, SelectListItem>)((CRMspSelectCompanyQuickRegisterDefSettingForCnvs_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.CompanyQuickRegisterDefSettingId.ToString(),
				Selected = (item.CompanyQuickRegisterDefSettingId == selectedSettingId)
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpDefSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult SelectCompanyQuickRegisterDefSettingForCnvs(int defSettingId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CrmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel data = new CrmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel();
		try
		{
			data = GetDefSettingById(defSettingId);
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

	public CrmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel GetDefSettingById(int defSettingId)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0.defSettingId = defSettingId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel crmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel = new CrmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel();
		try
		{
			DbSet<CrmCompanyQuickRegisterDefSetting> crmCompanyQuickRegisterDefSetting = _dbTbl.CrmCompanyQuickRegisterDefSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting), "c");
			CrmCompanyQuickRegisterDefSetting crmCompanyQuickRegisterDefSetting2 = Queryable.FirstOrDefault<CrmCompanyQuickRegisterDefSetting>((IQueryable<CrmCompanyQuickRegisterDefSetting>)crmCompanyQuickRegisterDefSetting, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass16_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCompanyQuickRegisterDefSetting2 != null)
			{
				DbSet<CrmCompanyQuickRegisterDefSetting_Lang> crmCompanyQuickRegisterDefSetting_Lang = _dbTbl.CrmCompanyQuickRegisterDefSetting_Lang;
				val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting_Lang), "c");
				List<CrmCompanyQuickRegisterDefSetting_Lang> list = Enumerable.ToList<CrmCompanyQuickRegisterDefSetting_Lang>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)Queryable.Where<CrmCompanyQuickRegisterDefSetting_Lang>((IQueryable<CrmCompanyQuickRegisterDefSetting_Lang>)crmCompanyQuickRegisterDefSetting_Lang, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass16_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.SettingTitle,
					LanguageId = myitem.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.SettingTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cnvsDesc,
					LanguageId = myitem.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cnvsDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cnvsReferDesc,
					LanguageId = myitem.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cnvsReferDesc,
					LanguageId = result
				});
				DateTime now = DateTime.Now;
				crmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel = new CrmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel
				{
					CompanyQuickRegisterDefSettingId = crmCompanyQuickRegisterDefSetting2.CompanyQuickRegisterDefSettingId,
					cnvsTopicId = crmCompanyQuickRegisterDefSetting2.cnvsTopicId,
					cnvsStatusId = crmCompanyQuickRegisterDefSetting2.cnvsStatusId,
					cnvsPriorityId = crmCompanyQuickRegisterDefSetting2.cnvsPriorityId,
					cnvsRemindDateIncDay = crmCompanyQuickRegisterDefSetting2.cnvsRemindDateIncDay,
					cnvsRemindDate = "",
					cnvsRemindTime = crmCompanyQuickRegisterDefSetting2.cnvsRemindTime,
					cnvsRemindDateForAllarmIncDay = crmCompanyQuickRegisterDefSetting2.cnvsRemindDateForAllarmIncDay,
					cnvsRemindDateForAllarm = "",
					cnvsFOCmpCanSee = (crmCompanyQuickRegisterDefSetting2.cnvsFOCmpCanSee.HasValue && crmCompanyQuickRegisterDefSetting2.cnvsFOCmpCanSee.GetValueOrDefault()),
					IsDefault = crmCompanyQuickRegisterDefSetting2.IsDefault,
					SettingTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cnvsDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cnvsReferDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "")
				};
				if (crmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel != null)
				{
					if (crmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel.cnvsRemindDateIncDay.HasValue)
					{
						int result2 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel.cnvsRemindDateIncDay.ToString(), out result2);
						crmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel.cnvsRemindDate = now.AddDays(result2).ToString("yyyy/MM/dd");
					}
					if (crmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel.cnvsRemindDateForAllarmIncDay.HasValue)
					{
						int result3 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel.cnvsRemindDateForAllarmIncDay.ToString(), out result3);
						crmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel.cnvsRemindDateForAllarm = now.AddDays(result3).ToString("yyyy/MM/dd");
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
		return crmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel;
	}

	[AjaxOnly]
	public JsonResult SetCnvsTicket(int cmpId, int prjId, int mode = 1)
	{
		CrmConversationLanguageViewModel crmConversationLanguageViewModel = new CrmConversationLanguageViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			bool result2 = false;
			bool result3 = false;
			CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(prjId, lCID, result));
			if (cRMspSelectCrmProjectsById_Result != null)
			{
				bool.TryParse(cRMspSelectCrmProjectsById_Result.prjIsTicket.ToString(), out result2);
				bool.TryParse(cRMspSelectCrmProjectsById_Result.prjFOCmpCanSee.ToString(), out result3);
			}
			switch (mode)
			{
			case 1:
				if (result2)
				{
					crmConversationLanguageViewModel.cnvsIsTicket = true;
					crmConversationLanguageViewModel.cnvsFOCmpCanSee = true;
				}
				if (result3)
				{
					crmConversationLanguageViewModel.prjFOCmpCanSee = true;
				}
				if (UserLogin.IsUserAccess("frmDefineConversation", "actDefSelectFOCmpCanSee", UserLogin.CurrentUser) && crmConversationLanguageViewModel.prjFOCmpCanSee.GetValueOrDefault())
				{
					crmConversationLanguageViewModel.cnvsFOCmpCanSee = true;
				}
				break;
			case 2:
				if (result3)
				{
					crmConversationLanguageViewModel.prjFOCmpCanSee = true;
				}
				break;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(crmConversationLanguageViewModel, JsonRequestBehavior.AllowGet);
	}

	public void ComboBoxCnvsReferToUser_Lang(int userId, int cmpId)
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
		List<SelectListItem> list = Enumerable.ToList<SelectListItem>(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspSelectUserForCnvsReferToUser_Result>)Enumerable.ToList<CRMspSelectUserForCnvsReferToUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToUser_Result>)_db.CRMspSelectUserForCnvsReferToUser(userId, 7, cmpId, lCID, result, result2)), (CRMspSelectUserForCnvsReferToUser_Result item) => new
		{
			item = item,
			text = ((item.cmpAccess == -100) ? $" ({Messages.CnvsComboReferUserCmpNotAccess})" : "")
		}), _003C_003Eh__TransparentIdentifier0 => new SelectListItem
		{
			Text = _003C_003Eh__TransparentIdentifier0.item.UserName + _003C_003Eh__TransparentIdentifier0.text,
			Value = _003C_003Eh__TransparentIdentifier0.item.LinkedUserId.ToString(),
			Selected = false
		}));
		base.ViewBag.ListCnvsReferUser = list;
	}

	public string ChkBeforeSubmitConversation_Lang(CrmConversationLanguageViewModel conversation, List<CommonMultiLanguageViewModel> listModelObj_cnvsDesc_Lang, ref int countError)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		if (string.IsNullOrEmpty(conversation.cnvsDate))
		{
			countError++;
			text = text + Messages.CheckEmptycnvsDate + "<br>";
		}
		if (string.IsNullOrEmpty(conversation.cnvsDay))
		{
			countError++;
			text = text + Messages.CheckEmptycnvsDay + "<br>";
		}
		if (string.IsNullOrEmpty(conversation.cnvsTime))
		{
			countError++;
			text = text + Messages.CheckEmptycnvsTime + "<br>";
		}
		if (string.IsNullOrEmpty(conversation.cnvsDesc))
		{
			countError++;
			text = text + Messages.CheckEmptycnvsDesc + "<br>";
		}
		else if (!checkMultiLanguage(conversation.cnvsDesc, listModelObj_cnvsDesc_Lang))
		{
			text = text + Messages.CheckcnvsDescLang + "<br>";
			countError++;
		}
		if (!conversation.cnvsTopicId.HasValue)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsTopicId + "<br>";
		}
		if (!conversation.cnvsPersonId.HasValue)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsPersonId + "<br>";
		}
		if (!conversation.cnvsUserId.HasValue)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsUserId + "<br>";
		}
		if (!conversation.cnvsReferUserId.HasValue)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsReferUserId + "<br>";
		}
		if (!conversation.cnvsStatusId.HasValue)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsStatusId + "<br>";
		}
		else
		{
			CRMspSelectConversationForcedStatusBFCurr_Result cRMspSelectConversationForcedStatusBFCurr_Result = Enumerable.FirstOrDefault<CRMspSelectConversationForcedStatusBFCurr_Result>((IEnumerable<CRMspSelectConversationForcedStatusBFCurr_Result>)_db.CRMspSelectConversationForcedStatusBFCurr(conversation.cnvsStatusId, conversation.cnvsProjectId, lCID, result, conversation.ConversationID));
			if (cRMspSelectConversationForcedStatusBFCurr_Result != null)
			{
				string arg = ((!string.IsNullOrEmpty(cRMspSelectConversationForcedStatusBFCurr_Result.Status)) ? cRMspSelectConversationForcedStatusBFCurr_Result.Status : "");
				countError++;
				text = text + string.Format(Messages.CheckForcedStatusBFCurr, arg) + "<br>";
			}
		}
		if (!string.IsNullOrEmpty(conversation.cnvsDate) && !DateTime.TryParse(DateTimeClass.ConvertDateWOSlashToSlash(conversation.cnvsDate), out var _))
		{
			countError++;
			text = text + Messages.CheckFormatcnvsDate + "<br>";
		}
		if (!string.IsNullOrEmpty(conversation.cnvsRemindDate) && !DateTime.TryParse(DateTimeClass.ConvertDateWOSlashToSlash(conversation.cnvsRemindDate), out var _))
		{
			countError++;
			text = text + Messages.CheckFormatcnvsRemindDate + "<br>";
		}
		if (!string.IsNullOrEmpty(conversation.cnvsRemindDateForAllarm) && !DateTime.TryParse(DateTimeClass.ConvertDateWOSlashToSlash(conversation.cnvsRemindDateForAllarm), out var _))
		{
			countError++;
			text = text + Messages.CheckFormatcnvsRemindDateForAllarm + "<br>";
		}
		if (!string.IsNullOrEmpty(conversation.cnvsTime) && conversation.cnvsTime.Length < 5)
		{
			countError++;
			text = text + Messages.CheckFormatcnvsTime + "<br>";
		}
		if (!string.IsNullOrEmpty(conversation.cnvsRemindTime) && conversation.cnvsRemindTime.Length < 5)
		{
			countError++;
			text = text + Messages.CheckFormatcnvsRemindTime + "<br>";
		}
		if (!string.IsNullOrEmpty(conversation.cnvsRemindDateForAllarm) && string.IsNullOrEmpty(conversation.cnvsRemindTime))
		{
			countError++;
			text = text + Messages.CheckAlarmcnvsRemindDateForAllarm + "<br>";
		}
		if (!string.IsNullOrEmpty(conversation.cnvsRemindTime) && string.IsNullOrEmpty(conversation.cnvsRemindDateForAllarm))
		{
			countError++;
			text = text + Messages.CheckAlarmcnvsRemindTime + "<br>";
		}
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		if (cRMspSelectCrmsysSetting_Result != null && cRMspSelectCrmsysSetting_Result.MustFullcnvsRemindDate.HasValue && cRMspSelectCrmsysSetting_Result.MustFullcnvsRemindDate != false && string.IsNullOrEmpty(conversation.cnvsRemindDate))
		{
			text = text + Messages.CheckmustFullCnvsRemindDate + "<br>";
			countError++;
		}
		if (!string.IsNullOrEmpty(conversation.cnvsRemindDate))
		{
			string strB = DateTime.Now.ToString("yyyyMMdd");
			DateTimeClass.ConvertDateWOSlashToSlash(conversation.cnvsRemindDate);
			if (string.Compare(conversation.cnvsRemindDate, strB) < -1)
			{
				countError++;
				text = text + Messages.CheckBeforecnvsRemindDate + "<br>";
			}
		}
		if (countError > 0)
		{
			return text;
		}
		if (conversation.ConversationID == 0 && !string.IsNullOrWhiteSpace(conversation.cnvsRemindDateForAllarm) && !string.IsNullOrWhiteSpace(conversation.cnvsRemindTime))
		{
			string strB2 = DateTime.Now.ToString("yyyyMMdd");
			string text2 = conversation.cnvsRemindDateForAllarm.Replace("/", "");
			if (string.Compare(text2, strB2) <= -1)
			{
				countError++;
				return text + Messages.msgErrorBeforecnvsRemindDateForAllarm + "<br>";
			}
			if (string.Compare(text2, strB2) == 0)
			{
				strB2 = DateTime.Now.ToString("yyyyMMddHHmm");
				text2 += conversation.cnvsRemindTime;
				text2 = text2.Replace(":", "");
				if (string.Compare(text2, strB2) <= -1)
				{
					countError++;
					return text + Messages.msgErrorBeforecnvsRemindTime + "<br>";
				}
			}
		}
		int userId = UserLogin.CurrentUser.UserId;
		int result5 = 0;
		int.TryParse(conversation.cnvsStatusResultId.ToString(), out result5);
		if (result5 == 0)
		{
			countError++;
			return text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsStatusResultId) + "<br>";
		}
		CRMspSelectConversationStatusResultById_Result cRMspSelectConversationStatusResultById_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusResultById_Result>((IEnumerable<CRMspSelectConversationStatusResultById_Result>)_dbI.CRMspSelectConversationStatusResultById(result5, lCID, result));
		if (cRMspSelectConversationStatusResultById_Result == null)
		{
			countError++;
			return text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsStatusResultId) + "<br>";
		}
		bool result6 = false;
		bool.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsRemindDateNotNull.ToString(), out result6);
		if (result6 && string.IsNullOrWhiteSpace(conversation.cnvsRemindDate))
		{
			countError++;
			return text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsRemindDate) + "<br>";
		}
		bool result7 = false;
		bool.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsRemindDateForAllarmNotNull.ToString(), out result7);
		if (result7)
		{
			if (string.IsNullOrWhiteSpace(conversation.cnvsRemindDateForAllarm))
			{
				countError++;
				return text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsRemindDateForAllarm) + "<br>";
			}
			if (string.IsNullOrWhiteSpace(conversation.cnvsRemindTime))
			{
				countError++;
				return text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsRemindTime) + "<br>";
			}
		}
		bool result8 = false;
		bool.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsDoingTimeNotNull.ToString(), out result8);
		if (result8 && string.IsNullOrWhiteSpace(((conversation.cnvsDoingHour.GetValueOrDefault(-1) == -1) ? "" : conversation.cnvsDoingHour.ToString()) + ((conversation.cnvsDoingMin.GetValueOrDefault(-1) == -1) ? "" : conversation.cnvsDoingMin.ToString())))
		{
			countError++;
			return text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsDoingTime) + "<br>";
		}
		string text3 = cRMspSelectConversationStatusResultById_Result.StatusResultUsedUserIds ?? "";
		if (!string.IsNullOrWhiteSpace(text3))
		{
			string[] array = text3.Split(new char[1] { '|' });
			if (array != null && array.Length != 0)
			{
				bool flag = false;
				string[] array2 = array;
				foreach (string s in array2)
				{
					int result9 = 0;
					int.TryParse(s, out result9);
					if (result9 != 0 && result9 == userId)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					countError++;
					return text + Messages.msgErrorCanNotSaveCnvsInResult + "<br>";
				}
			}
		}
		bool result10 = false;
		bool.TryParse(cRMspSelectConversationStatusResultById_Result.NeedDyFormChecked.ToString(), out result10);
		if (result10)
		{
			int result11 = 0;
			int.TryParse(cRMspSelectConversationStatusResultById_Result.NeedDyFormCheckedFormId.ToString(), out result11);
			if (result11 != 0)
			{
				CRMspCnvsStatusResultNeedDyFormChecked_Result cRMspCnvsStatusResultNeedDyFormChecked_Result = Enumerable.FirstOrDefault<CRMspCnvsStatusResultNeedDyFormChecked_Result>((IEnumerable<CRMspCnvsStatusResultNeedDyFormChecked_Result>)_dbI.CRMspCnvsStatusResultNeedDyFormChecked(result11, conversation.cnvsCompanyId, conversation.cnvsPersonId, conversation.cnvsProjectId, conversation.ConversationID, lCID, result));
				if (cRMspCnvsStatusResultNeedDyFormChecked_Result == null)
				{
					countError++;
					return text + string.Format(Messages.msgErrorNotSaveCnvsBeforeInsertDyFormFromCmp, cRMspSelectConversationStatusResultById_Result.NeedDyFormCheckedForm ?? "") + "<br>";
				}
				bool result12 = false;
				bool.TryParse(cRMspCnvsStatusResultNeedDyFormChecked_Result.IsChecked.ToString(), out result12);
				if (!result12)
				{
					countError++;
					return text + string.Format(Messages.msgErrorNotSaveCnvsBeforeDyFormChecked, cRMspCnvsStatusResultNeedDyFormChecked_Result.FormName ?? "", cRMspCnvsStatusResultNeedDyFormChecked_Result.DyFormNumber.GetValueOrDefault().ToString()) + "<br>";
				}
			}
		}
		bool result13 = false;
		bool.TryParse(cRMspSelectConversationStatusResultById_Result.NoCnvsDup.ToString(), out result13);
		if (result13)
		{
			CRMspCnvsStatusResultNoCnvsDup_Result cRMspCnvsStatusResultNoCnvsDup_Result = Enumerable.FirstOrDefault<CRMspCnvsStatusResultNoCnvsDup_Result>((IEnumerable<CRMspCnvsStatusResultNoCnvsDup_Result>)_dbI.CRMspCnvsStatusResultNoCnvsDup(conversation.cnvsCompanyId, conversation.cnvsProjectId, conversation.cnvsStatusResultId, conversation.ConversationID, lCID, result));
			if (cRMspCnvsStatusResultNoCnvsDup_Result != null)
			{
				cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDate = (cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDateTime.HasValue ? cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
				countError++;
				return text + string.Format(Messages.msgErrorNoDupCnvsInStatusResult, cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDate, cRMspCnvsStatusResultNoCnvsDup_Result.cnvsStatus ?? "", cRMspCnvsStatusResultNoCnvsDup_Result.cnvsStatusResult ?? "") + "<br>";
			}
		}
		int result14 = 0;
		int.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsCountLimit.ToString(), out result14);
		if (result14 > 0)
		{
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnCnvsStatusResultCnvsCount(conversation.cnvsCompanyId, conversation.cnvsProjectId, conversation.cnvsStatusResultId, conversation.ConversationID));
			int result15 = 0;
			int.TryParse(num.ToString(), out result15);
			result15++;
			if (result14 < result15)
			{
				countError++;
				return text + string.Format(Messages.msgErrorCnvsCountLimitInStatusResult, cRMspSelectConversationStatusResultById_Result.ResultTitle ?? "", result14.ToString()) + "<br>";
			}
		}
		long result16 = 0L;
		long.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsDoingTimeLimit.ToString(), out result16);
		if (result16 > 0)
		{
			long? num2 = Enumerable.FirstOrDefault<long?>((IEnumerable<long?>)_dbI.CRMspReturnCnvsStatusResultCnvsSumDoingTime(conversation.cnvsCompanyId, conversation.cnvsProjectId, conversation.cnvsStatusResultId, conversation.ConversationID));
			long result17 = 0L;
			long.TryParse(num2.ToString(), out result17);
			long result18 = 0L;
			long.TryParse(conversation.cnvsDoingTimeSec.ToString(), out result18);
			if ((conversation.cnvsDoingHour > 0 || conversation.cnvsDoingMin > 0) && result18 == 0L)
			{
				result18 = DateTimeClass.ConvertHourAndMinToSec(conversation.cnvsDoingHour.GetValueOrDefault(), conversation.cnvsDoingMin.GetValueOrDefault());
			}
			result17 += result18;
			result16 *= 60;
			if (result16 < result17)
			{
				long.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsDoingTimeLimit.ToString(), out result16);
				countError++;
				return text + string.Format(Messages.msgErrorCnvsDoingTimeLimitInStatusResult, cRMspSelectConversationStatusResultById_Result.ResultTitle ?? "", result16.ToString()) + "<br>";
			}
		}
		int result19 = 0;
		int.TryParse(conversation.cnvsStatusId.ToString(), out result19);
		if (result19 == 0)
		{
			countError++;
			return text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsStatusId) + "<br>";
		}
		CRMspSelectConversationStatusById_Result cRMspSelectConversationStatusById_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusById_Result>((IEnumerable<CRMspSelectConversationStatusById_Result>)_db.CRMspSelectConversationStatusById(result19, lCID, result));
		if (cRMspSelectConversationStatusById_Result == null)
		{
			countError++;
			return text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsStatusId) + "<br>";
		}
		bool result20 = false;
		bool.TryParse(cRMspSelectConversationStatusById_Result.GroupNoRegCnvsOlderStatus.ToString(), out result20);
		bool result21 = false;
		bool.TryParse(cRMspSelectConversationStatusById_Result.NoRegCnvsOlderStatus.ToString(), out result21);
		if (result20)
		{
			CRMspSelectConversationStatusNextCurr_Result cRMspSelectConversationStatusNextCurr_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusNextCurr_Result>((IEnumerable<CRMspSelectConversationStatusNextCurr_Result>)_dbI.CRMspSelectConversationStatusNextCurr(result19, conversation.cnvsProjectId, conversation.ConversationID, lCID, result));
			if (cRMspSelectConversationStatusNextCurr_Result != null)
			{
				countError++;
				return text + string.Format(Messages.msgErrorNoRegCnvsOlderStatus, cRMspSelectConversationStatusNextCurr_Result.Status ?? "") + "<br>";
			}
		}
		else if (result21)
		{
			CRMspSelectConversationStatusNextCurr_Result cRMspSelectConversationStatusNextCurr_Result2 = Enumerable.FirstOrDefault<CRMspSelectConversationStatusNextCurr_Result>((IEnumerable<CRMspSelectConversationStatusNextCurr_Result>)_dbI.CRMspSelectConversationStatusNextCurr(result19, conversation.cnvsProjectId, conversation.ConversationID, lCID, result));
			if (cRMspSelectConversationStatusNextCurr_Result2 != null)
			{
				countError++;
				return text + string.Format(Messages.msgErrorNoRegCnvsOlderStatus, cRMspSelectConversationStatusNextCurr_Result2.Status ?? "") + "<br>";
			}
		}
		string text4 = cRMspSelectConversationStatusById_Result.StatusUsedUserIds ?? "";
		if (!string.IsNullOrWhiteSpace(text4))
		{
			string[] array3 = text4.Split(new char[1] { '|' });
			if (array3 != null && array3.Length != 0)
			{
				bool flag2 = false;
				string[] array2 = array3;
				foreach (string s2 in array2)
				{
					int result22 = 0;
					int.TryParse(s2, out result22);
					if (result22 != 0 && result22 == userId)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					countError++;
					return text + Messages.msgErrorCanNotSaveCnvsInStatus + "<br>";
				}
			}
		}
		int result23 = 0;
		int.TryParse(cRMspSelectConversationStatusById_Result.CnvsCountLimit.ToString(), out result23);
		if (result23 > 0)
		{
			int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnCnvsStatusCnvsCount(conversation.cnvsCompanyId, conversation.cnvsProjectId, conversation.cnvsStatusId, conversation.ConversationID));
			int result24 = 0;
			int.TryParse(num3.ToString(), out result24);
			result24++;
			if (result23 < result24)
			{
				countError++;
				return text + string.Format(Messages.msgErrorCnvsCountLimitInStatus, cRMspSelectConversationStatusById_Result.Status ?? "", result23.ToString()) + "<br>";
			}
		}
		long result25 = 0L;
		long.TryParse(cRMspSelectConversationStatusById_Result.CnvsDoingTimeLimit.ToString(), out result25);
		if (result25 > 0)
		{
			long? num4 = Enumerable.FirstOrDefault<long?>((IEnumerable<long?>)_dbI.CRMspReturnCnvsStatusCnvsSumDoingTime(conversation.cnvsCompanyId, conversation.cnvsProjectId, conversation.cnvsStatusId, conversation.ConversationID));
			long result26 = 0L;
			long.TryParse(num4.ToString(), out result26);
			long result27 = 0L;
			long.TryParse(conversation.cnvsDoingTimeSec.ToString(), out result27);
			if ((conversation.cnvsDoingHour > 0 || conversation.cnvsDoingMin > 0) && result27 == 0L)
			{
				result27 = DateTimeClass.ConvertHourAndMinToSec(conversation.cnvsDoingHour.GetValueOrDefault(), conversation.cnvsDoingMin.GetValueOrDefault());
			}
			result26 += result27;
			result25 *= 60;
			if (result25 < result26)
			{
				long.TryParse(cRMspSelectConversationStatusById_Result.CnvsDoingTimeLimit.ToString(), out result25);
				countError++;
				return text + string.Format(Messages.msgErrorCnvsDoingTimeLimitInStatus, cRMspSelectConversationStatusById_Result.Status ?? "", result25.ToString()) + "<br>";
			}
		}
		string text5 = conversation.cnvsRemindDate ?? "";
		if ((conversation.cnvsUserId != conversation.cnvsReferUserId || !string.IsNullOrEmpty(conversation.AppType) || UserLogin.CurrentUser.UserId != conversation.cnvsReferUserId) && text5 == "" && !UserLogin.IsUserAccess("frmDefineConversation", "actCnvsReferUserWithoutRemindDate", UserLogin.CurrentUser))
		{
			text = text + Messages.cnvsErrorNotMatchUserIdReferID + "<br>";
			countError++;
		}
		if (conversation.ConversationID > 0)
		{
			if (lCID != 1065)
			{
				if (!string.IsNullOrEmpty(conversation.cnvsDate))
				{
					conversation.cnvsDate = DateTime.Parse(PersianDate.GetFormatetdDate(conversation.cnvsDate.Replace("/", ""))).ToString("yyyyMMdd", new PersianCulture());
				}
				if (!string.IsNullOrEmpty(conversation.cnvsRemindDate))
				{
					conversation.cnvsRemindDate = DateTime.Parse(PersianDate.GetFormatetdDate(conversation.cnvsRemindDate.Replace("/", ""))).ToString("yyyyMMdd", new PersianCulture());
				}
				if (!string.IsNullOrEmpty(conversation.cnvsRemindDateForAllarm))
				{
					conversation.cnvsRemindDateForAllarm = DateTime.Parse(PersianDate.GetFormatetdDate(conversation.cnvsRemindDateForAllarm.Replace("/", ""))).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
			CrmConversation crmConversation = cRMTabelEntities.CrmConversation.Find(conversation.ConversationID);
			if (crmConversation != null)
			{
				if (!UserLogin.IsUserAccess("frmDefineConversation", "actCanEditRemindDate", UserLogin.CurrentUser) && !string.IsNullOrEmpty(crmConversation.cnvsRemindDate) && !string.IsNullOrEmpty(conversation.cnvsRemindDate) && crmConversation.cnvsRemindDate != conversation.cnvsRemindDate)
				{
					text = text + Messages.CheckNotcnvsRemindDate + "<br>";
					countError++;
				}
				if (!UserLogin.IsUserAccess("frmDefineConversation", "actCanEditAllarmDate", UserLogin.CurrentUser) && !string.IsNullOrEmpty(crmConversation.cnvsRemindDateForAllarm) && !string.IsNullOrEmpty(conversation.cnvsRemindDateForAllarm) && crmConversation.cnvsRemindDateForAllarm != conversation.cnvsRemindDateForAllarm)
				{
					text = text + Messages.CheckNotcnvsRemindDateForAllarm + "<br>";
					countError++;
				}
				if (!UserLogin.IsUserAccess("frmDefineConversation", "actCanEditcnvsDate", UserLogin.CurrentUser) && !string.IsNullOrEmpty(crmConversation.cnvsDate) && !string.IsNullOrEmpty(conversation.cnvsDate) && crmConversation.cnvsDate != conversation.cnvsDate)
				{
					text = text + Messages.CheckNotcnvsDate + "<br>";
					countError++;
				}
				if (!UserLogin.IsUserAccess("frmDefineConversation", "actCanEditcnvsTime", UserLogin.CurrentUser) && !string.IsNullOrEmpty(crmConversation.cnvsTime) && !string.IsNullOrEmpty(conversation.cnvsTime) && crmConversation.cnvsTime != conversation.cnvsTime)
				{
					text = text + Messages.CheckNotcnvsTime + "<br>";
					countError++;
				}
			}
			cRMTabelEntities.Dispose();
		}
		return text;
	}

	private void ComboBoxTypeFile_Lang()
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
			List<CRMspSelectFileDirectoryTypeByOprId_Result> list2 = Enumerable.ToList<CRMspSelectFileDirectoryTypeByOprId_Result>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)_db.CRMspSelectFileDirectoryTypeByOprId(2, lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "",
				Selected = true
			});
			list.AddRange(Enumerable.Select<CRMspSelectFileDirectoryTypeByOprId_Result, SelectListItem>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)list2, (Func<CRMspSelectFileDirectoryTypeByOprId_Result, SelectListItem>)((CRMspSelectFileDirectoryTypeByOprId_Result item) => new SelectListItem
			{
				Text = item.FileDirectoryType,
				Value = item.FileDirectoryTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsTypeFilelist = list;
	}

	public bool ConversationInfoProject_Lang(int id, int? prjid)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		bool result2 = false;
		CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(id);
		if (companyById == null)
		{
			base.ViewBag.Error = Messages.cnvsNotSelectCmpName;
		}
		else
		{
			base.ViewBag.cnvsCompanyName = companyById.CompanyName ?? companyById.cmpName;
			base.ViewBag.cnvsCompanyId = companyById.CompanyID;
			CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(prjid, lCID, result));
			if (cRMspSelectCrmProjectsById_Result != null)
			{
				base.ViewBag.cnvsProjectTitle = cRMspSelectCrmProjectsById_Result.prjTitle + ((!string.IsNullOrEmpty(cRMspSelectCrmProjectsById_Result.prjPostFix)) ? (" " + cRMspSelectCrmProjectsById_Result.prjPostFix) : "");
				base.ViewBag.cnvsProjectId = cRMspSelectCrmProjectsById_Result.ProjectID;
				base.ViewBag.cnvsGupStatus = cRMspSelectCrmProjectsById_Result.prjcnvsStatusGroupId;
				result2 = true;
				CRMspSelectCompanyConversationLastStatus_Result cRMspSelectCompanyConversationLastStatus_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyConversationLastStatus_Result>((IEnumerable<CRMspSelectCompanyConversationLastStatus_Result>)_db.CRMspSelectCompanyConversationLastStatus(companyById.CompanyID, cRMspSelectCrmProjectsById_Result.ProjectID, lCID, result));
				if (cRMspSelectCompanyConversationLastStatus_Result != null)
				{
					base.ViewBag.cnvsLastStatus = cRMspSelectCompanyConversationLastStatus_Result.Status;
					base.ViewBag.cnvsLastUser = cRMspSelectCompanyConversationLastStatus_Result.cnvsUser;
					base.ViewBag.cnvsLastReferUser = cRMspSelectCompanyConversationLastStatus_Result.cnvsReferUser;
				}
			}
			else
			{
				result2 = false;
			}
		}
		return result2;
	}

	public void ConversationSetUserNameDate_lang(CrmConversationLanguageViewModel conversation)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = (conversation.cnvsFirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
		_ = conversation.UserId;
		List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text + "," + conversation.UserId);
		if (list != null)
		{
			list = new List<CRMspSelectUsersByIds_Result>();
		}
		CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == conversation.cnvsFirstRegisterUserId));
		base.ViewBag.FirstRegisterUserIdTitle = Labels.cnvsFirstRegisterUserId + ": " + ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
		string cnvsFirstRegisterDate = conversation.cnvsFirstRegisterDate;
		cnvsFirstRegisterDate = (conversation.cnvsFirstRegisterDateTime.HasValue ? conversation.cnvsFirstRegisterDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
		base.ViewBag.ImportDate = Labels.cnvsFirstRegisterDate + ": " + cnvsFirstRegisterDate;
		CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == conversation.UserId));
		string text2 = Labels.cnvsEditUserId + ": " + ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
		string registerDatePersian = conversation.RegisterDatePersian;
		_ = conversation.RegisterDate;
		registerDatePersian = conversation.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
		base.ViewBag.RegisterDateStr = Labels.cnvsRegisterDatePersian + ": " + registerDatePersian;
		if (string.IsNullOrEmpty(conversation.AppTypeHelp))
		{
			conversation.AppTypeHelp = Configuration.AppType;
		}
		string text3 = Labels.AppType + ": " + Configuration.GetAppType(conversation.AppTypeHelp);
		base.ViewBag.AppType = text3;
		base.ViewBag.UserIdTitle = text2 + " (" + text3 + ")";
	}

	private void ConversationFullcombo_lang(int cmpid, int? prjid)
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
		List<SelectListItem> list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)_db.CRMspSelectConversationTopics(lCID, result)), (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
		{
			Text = item.Topic,
			Value = item.ConversationTopicsID.ToString(),
			Selected = false
		})));
		base.ViewBag.ConversationTopicslist = list;
		List<SelectListItem> list2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyPersons_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPersons_Result>)CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpid), (Func<CRMspSelectCompanyPersons_Result, SelectListItem>)((CRMspSelectCompanyPersons_Result item) => new SelectListItem
		{
			Text = item.prsFName + " " + item.prsLName,
			Value = item.CompanyPersonID.ToString(),
			Selected = false
		})));
		base.ViewBag.CompanyPersonslist = list2;
		List<SelectListItem> list3 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)Enumerable.ToList<CRMspSelectActiveConversationStatus_Result>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)_dbI.CRMspSelectActiveConversationStatus(0, lCID, result)), (Func<CRMspSelectActiveConversationStatus_Result, SelectListItem>)((CRMspSelectActiveConversationStatus_Result item) => new SelectListItem
		{
			Text = item.Status,
			Value = item.ConversationStatusID.ToString(),
			Selected = false
		})));
		base.ViewBag.ConversationStatuslist = list3;
		List<SelectListItem> list4 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationPriority_Result, SelectListItem>((IEnumerable<CRMspSelectConversationPriority_Result>)Enumerable.ToList<CRMspSelectConversationPriority_Result>((IEnumerable<CRMspSelectConversationPriority_Result>)_db.CRMspSelectConversationPriority(lCID, result)), (Func<CRMspSelectConversationPriority_Result, SelectListItem>)((CRMspSelectConversationPriority_Result item) => new SelectListItem
		{
			Text = item.Priority,
			Value = item.ConversationPriorityID.ToString(),
			Selected = false
		})));
		base.ViewBag.ConversationPrioritylist = list4;
		List<CRMspSelectCrmProjectBycmpAndUser_Result> list5 = Enumerable.ToList<CRMspSelectCrmProjectBycmpAndUser_Result>((IEnumerable<CRMspSelectCrmProjectBycmpAndUser_Result>)_db.CRMspSelectCrmProjectBycmpAndUser(cmpid, UserLogin.CurrentUser.UserId, lCID, result, result2));
		List<SelectListItem> list6 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCrmProjectBycmpAndUser_Result, SelectListItem>((IEnumerable<CRMspSelectCrmProjectBycmpAndUser_Result>)list5, (Func<CRMspSelectCrmProjectBycmpAndUser_Result, SelectListItem>)((CRMspSelectCrmProjectBycmpAndUser_Result item) => new SelectListItem
		{
			Text = item.prjTitle,
			Value = item.ProjectID.ToString(),
			Selected = false
		})));
		base.ViewBag.Projectslist = list6;
		List<CRMspSelectCompanyPersons_Result> list7 = CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpid);
		if (list7 != null && Enumerable.Any<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list7))
		{
			list7 = Enumerable.ToList<CRMspSelectCompanyPersons_Result>(Enumerable.Where<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list7, (Func<CRMspSelectCompanyPersons_Result, bool>)((CRMspSelectCompanyPersons_Result c) => !c.prsWorkingOut.HasValue || c.prsWorkingOut == false)));
		}
		List<SelectListItem> list8 = new List<SelectListItem>();
		if (list7 != null && Enumerable.Any<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list7))
		{
			foreach (CRMspSelectCompanyPersons_Result item in list7)
			{
				list8.Add(new SelectListItem
				{
					Text = ((!string.IsNullOrEmpty(item.prsLName)) ? item.prsLName : "") + ((!string.IsNullOrEmpty(item.prsFName)) ? (" | " + item.prsFName) : "") + ((!string.IsNullOrEmpty(item.prsTitle)) ? (" | " + item.prsTitle) : "") + ((!string.IsNullOrEmpty(item.prsJob)) ? (" | " + Labels.PrsJob + ": " + item.prsJob) : "") + ((!string.IsNullOrEmpty(item.prsDepartment)) ? (" | " + Labels.PrsDepartment + ": " + item.prsDepartment) : ""),
					Value = item.CompanyPersonID.ToString(),
					Selected = false
				});
			}
		}
		base.ViewBag.CmpPersonlist = list8;
		CRMspSelectCrmProjectBycmpAndUser_Result cRMspSelectCrmProjectBycmpAndUser_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectBycmpAndUser_Result>((IEnumerable<CRMspSelectCrmProjectBycmpAndUser_Result>)list5, (Func<CRMspSelectCrmProjectBycmpAndUser_Result, bool>)((CRMspSelectCrmProjectBycmpAndUser_Result c) => c.ProjectID == prjid));
		List<SelectListItem> list9 = new List<SelectListItem>();
		List<SelectListItem> list10 = new List<SelectListItem>();
		if (cRMspSelectCrmProjectBycmpAndUser_Result != null)
		{
			List<CRMspSelectActiveConversationStatus_Result> list11 = Enumerable.ToList<CRMspSelectActiveConversationStatus_Result>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)_dbI.CRMspSelectActiveConversationStatus(cRMspSelectCrmProjectBycmpAndUser_Result.prjcnvsStatusGroupId, lCID, result));
			foreach (CRMspSelectActiveConversationStatus_Result item2 in list11)
			{
				if (item2.StatusDesc == null)
				{
					item2.StatusDesc = "";
				}
				list9.Add(new SelectListItem
				{
					Text = ((!string.IsNullOrEmpty(item2.Status)) ? item2.Status : "") + (item2.ProgressPercent.HasValue ? (" |" + Labels.cnvsPercentStatus + ": " + item2.ProgressPercent) : "") + ((!string.IsNullOrEmpty(item2.StatusDesc)) ? (" |" + Labels.cnvsDescStatus + ": " + item2.StatusDesc) : ""),
					Value = item2.ConversationStatusID.ToString(),
					Selected = false
				});
			}
			if (list11 != null)
			{
				list10 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)list11, (Func<CRMspSelectActiveConversationStatus_Result, SelectListItem>)((CRMspSelectActiveConversationStatus_Result item) => new SelectListItem
				{
					Text = item.ProgressPercent.ToString(),
					Value = item.ConversationStatusID.ToString(),
					Selected = false
				})));
			}
		}
		base.ViewBag.CnvsStatuslist = list9;
		base.ViewBag.CnvsStatusProgresslist = list10;
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

	public List<SelectListItem> listDays()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		list.Add(new SelectListItem
		{
			Text = Labels.Saturday,
			Value = "7",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Sunday,
			Value = "1",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Monday,
			Value = "2",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Tuesday,
			Value = "3",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Wednesday,
			Value = "4",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Thursday,
			Value = "5",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Friday,
			Value = "6",
			Selected = false
		});
		base.ViewBag.Dayslist = list;
		return list;
	}

	private void FileTypes()
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
			List<CRMspSelectFileDirectoryTypeByOprId_Result> list2 = Enumerable.ToList<CRMspSelectFileDirectoryTypeByOprId_Result>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)_db.CRMspSelectFileDirectoryTypeByOprId(2, lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "",
				Selected = true
			});
			list.AddRange(Enumerable.Select<CRMspSelectFileDirectoryTypeByOprId_Result, SelectListItem>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)list2, (Func<CRMspSelectFileDirectoryTypeByOprId_Result, SelectListItem>)((CRMspSelectFileDirectoryTypeByOprId_Result item) => new SelectListItem
			{
				Text = item.FileDirectoryType,
				Value = item.FileDirectoryTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsTypeFilelist = list;
	}

	public JsonResult SelectCombosQuickView(int cmpId, int prjId, int mode = 1)
	{
		ConversationQuickViewModel conversationQuickViewModel = new ConversationQuickViewModel();
		conversationQuickViewModel.CmpPerson = new List<SelectListItem>();
		conversationQuickViewModel.CnvsStatus = new List<SelectListItem>();
		conversationQuickViewModel.CnvsTicket = new CrmConversationLanguageViewModel();
		conversationQuickViewModel.CnvsStatusProgress = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyPersons_Result> list = CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpId);
			if (list != null && Enumerable.Any<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list))
			{
				list = Enumerable.ToList<CRMspSelectCompanyPersons_Result>(Enumerable.Where<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list, (Func<CRMspSelectCompanyPersons_Result, bool>)((CRMspSelectCompanyPersons_Result c) => !c.prsWorkingOut.HasValue || c.prsWorkingOut == false)));
			}
			if (list != null && Enumerable.Any<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list))
			{
				conversationQuickViewModel.CmpPerson = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyPersons_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPersons_Result>)list, (Func<CRMspSelectCompanyPersons_Result, SelectListItem>)((CRMspSelectCompanyPersons_Result item) => new SelectListItem
				{
					Text = ((!string.IsNullOrEmpty(item.prsLName)) ? item.prsLName : "") + ((!string.IsNullOrEmpty(item.prsFName)) ? (" | " + item.prsFName) : "") + ((!string.IsNullOrEmpty(item.prsTitle)) ? (" | " + item.prsTitle) : "") + ((!string.IsNullOrEmpty(item.prsJob)) ? (" | " + Labels.PrsJob + ": " + item.prsJob) : "") + ((!string.IsNullOrEmpty(item.prsDepartment)) ? (" | " + Labels.PrsDepartment + ": " + item.prsDepartment) : ""),
					Value = item.CompanyPersonID.ToString(),
					Selected = false
				})));
			}
			CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(prjId, lCID, result));
			if (cRMspSelectCrmProjectsById_Result != null)
			{
				List<CRMspSelectActiveConversationStatus_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatus_Result>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)_dbI.CRMspSelectActiveConversationStatus(cRMspSelectCrmProjectsById_Result.prjcnvsStatusGroupId, lCID, result));
				foreach (CRMspSelectActiveConversationStatus_Result item in list2)
				{
					if (item.StatusDesc == null)
					{
						item.StatusDesc = "";
					}
					conversationQuickViewModel.CnvsStatus.Add(new SelectListItem
					{
						Text = ((!string.IsNullOrEmpty(item.Status)) ? item.Status : "") + (item.ProgressPercent.HasValue ? (" |" + Labels.cnvsPercentStatus + ": " + item.ProgressPercent) : "") + ((!string.IsNullOrEmpty(item.StatusDesc)) ? (" |" + Labels.cnvsDescStatus + ": " + item.StatusDesc) : ""),
						Value = item.ConversationStatusID.ToString()
					});
				}
				if (list2 != null)
				{
					conversationQuickViewModel.CnvsStatusProgress = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)list2, (Func<CRMspSelectActiveConversationStatus_Result, SelectListItem>)((CRMspSelectActiveConversationStatus_Result item) => new SelectListItem
					{
						Text = item.ProgressPercent.GetValueOrDefault() + "|" + item.GroupId.GetValueOrDefault() + "|" + item.ProcessKindId.GetValueOrDefault() + "|" + item.SendInCnvsAllarmDate.GetValueOrDefault(),
						Value = item.ConversationStatusID.ToString(),
						Selected = false
					})));
				}
			}
			bool result2 = false;
			bool result3 = false;
			bool result4 = false;
			CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result2 = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(prjId, lCID, result));
			if (cRMspSelectCrmProjectsById_Result2 != null)
			{
				bool.TryParse(cRMspSelectCrmProjectsById_Result2.prjIsTicket.ToString(), out result2);
				bool.TryParse(cRMspSelectCrmProjectsById_Result2.prjFOCmpCanSee.ToString(), out result3);
				bool.TryParse(cRMspSelectCrmProjectsById_Result2.prjTicketStop.ToString(), out result4);
			}
			conversationQuickViewModel.CnvsTicket.prjTicketStop = result4;
			switch (mode)
			{
			case 1:
				if (result2)
				{
					conversationQuickViewModel.CnvsTicket.cnvsIsTicket = true;
					conversationQuickViewModel.CnvsTicket.cnvsFOCmpCanSee = true;
				}
				if (result3)
				{
					conversationQuickViewModel.CnvsTicket.prjFOCmpCanSee = true;
				}
				if (UserLogin.IsUserAccess("frmDefineConversation", "actDefSelectFOCmpCanSee", UserLogin.CurrentUser) && conversationQuickViewModel.CnvsTicket.prjFOCmpCanSee.GetValueOrDefault())
				{
					conversationQuickViewModel.CnvsTicket.cnvsFOCmpCanSee = true;
				}
				break;
			case 2:
				if (result3)
				{
					conversationQuickViewModel.CnvsTicket.prjFOCmpCanSee = true;
				}
				break;
			}
			CRMspSelectCompanyConversationFirstCnvsUser_Result cRMspSelectCompanyConversationFirstCnvsUser_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyConversationFirstCnvsUser_Result>((IEnumerable<CRMspSelectCompanyConversationFirstCnvsUser_Result>)_dbI.CRMspSelectCompanyConversationFirstCnvsUser(cmpId, prjId, lCID, result));
			if (cRMspSelectCompanyConversationFirstCnvsUser_Result != null && cRMspSelectCompanyConversationFirstCnvsUser_Result.cnvsUserId.HasValue)
			{
				conversationQuickViewModel.CnvsTicket.PrjFirstCnvsUserId = cRMspSelectCompanyConversationFirstCnvsUser_Result.cnvsUserId;
			}
			CRMspSelectCompanyConversationLastStatus_Result cRMspSelectCompanyConversationLastStatus_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyConversationLastStatus_Result>((IEnumerable<CRMspSelectCompanyConversationLastStatus_Result>)_db.CRMspSelectCompanyConversationLastStatus(cmpId, prjId, lCID, result));
			if (cRMspSelectCompanyConversationLastStatus_Result != null && cRMspSelectCompanyConversationLastStatus_Result.cnvsPersonId.HasValue)
			{
				conversationQuickViewModel.CnvsTicket.LastCnvsPersonId = cRMspSelectCompanyConversationLastStatus_Result.cnvsPersonId;
			}
			CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
			if (companyById != null)
			{
				conversationQuickViewModel.CnvsTicket.CmpReferUserId = companyById.cmpReferUserId;
				conversationQuickViewModel.CnvsTicket.CmpSuppUserId = companyById.cmpSuppUserId;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(conversationQuickViewModel, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
