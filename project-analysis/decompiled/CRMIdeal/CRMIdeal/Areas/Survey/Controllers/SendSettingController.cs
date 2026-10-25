using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Survey.Controllers;

public class SendSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public CRMspSelectSurveySendSettingWithId_Result sp;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public CrmSurveySendSetting findedRecord;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSurveySendSetting")]
	public ActionResult Index()
	{
		return View();
	}

	public ActionResult SurveySendSetting_Read([DataSourceRequest] DataSourceRequest request)
	{
		JsonResult jsonResult = Json(((IEnumerable)SelectSurveySendSetting()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurveySendSetting", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int sendSettingId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		SurveySendSettingViewModel surveySendSettingViewModel = new SurveySendSettingViewModel();
		if (sendSettingId > 0)
		{
			_003C_003Ec__DisplayClass4_1 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_1();
			_003C_003Ec__DisplayClass4_.sp = Enumerable.FirstOrDefault<CRMspSelectSurveySendSettingWithId_Result>((IEnumerable<CRMspSelectSurveySendSettingWithId_Result>)_db.CRMspSelectSurveySendSettingWithId(sendSettingId, result, result));
			if (_003C_003Ec__DisplayClass4_.sp != null)
			{
				DbSet<CrmSurveySendSetting_Lang> crmSurveySendSetting_Lang = _dbTbl.CrmSurveySendSetting_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmSurveySendSetting_Lang), "c");
				List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmSurveySendSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmSurveySendSetting_Lang>)Enumerable.ToList<CrmSurveySendSetting_Lang>((IEnumerable<CrmSurveySendSetting_Lang>)Queryable.Where<CrmSurveySendSetting_Lang>((IQueryable<CrmSurveySendSetting_Lang>)crmSurveySendSetting_Lang, Expression.Lambda<Func<CrmSurveySendSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<CrmSurveySendSetting_Lang, CommonMultiLanguageViewModel>)((CrmSurveySendSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.surssTitle,
					LanguageId = item.LanguageID
				})));
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass4_.sp.surssTitle,
					LanguageId = result
				});
				surveySendSettingViewModel.SurveySendSettingId = _003C_003Ec__DisplayClass4_.sp.SurveySendSettingId;
				surveySendSettingViewModel.surssTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				surveySendSettingViewModel.surssTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				surveySendSettingViewModel.surssSmsSendByWeb = _003C_003Ec__DisplayClass4_.sp.surssSmsSendByWeb;
				surveySendSettingViewModel.surssSmsProviderId = _003C_003Ec__DisplayClass4_.sp.surssSmsProviderId;
				surveySendSettingViewModel.surssSmsSendNumber = _003C_003Ec__DisplayClass4_.sp.surssSmsSendNumber;
				surveySendSettingViewModel.surssSmsSendByGSM = _003C_003Ec__DisplayClass4_.sp.surssSmsSendByGSM;
				surveySendSettingViewModel.surssSmsSendGSMNmber = _003C_003Ec__DisplayClass4_.sp.surssSmsSendGSMNmber;
				surveySendSettingViewModel.surssSendByEmail = _003C_003Ec__DisplayClass4_.sp.surssSendByEmail;
				surveySendSettingViewModel.surssEmailSendUserInfoId = _003C_003Ec__DisplayClass4_.sp.surssEmailSendUserInfoId;
				surveySendSettingViewModel.surssEmailSendUserInfo = _003C_003Ec__DisplayClass4_.sp.surssEmailSendUserInfo;
				if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass4_.sp.surssSendStartDatePersian))
				{
					surveySendSettingViewModel.surssSendStartDate = _003C_003Ec__DisplayClass4_.sp.surssSendStartDate;
					surveySendSettingViewModel.surssSendStartDatePersian = (_003C_003Ec__DisplayClass4_.sp.surssSendStartDate ?? DateTime.Now).ToString("hh:mm:ss", new PersianCulture());
				}
				else
				{
					surveySendSettingViewModel.surssSendStartDate = null;
					surveySendSettingViewModel.surssSendStartDatePersian = null;
				}
				if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass4_.sp.surssSendEndDatePersian))
				{
					surveySendSettingViewModel.surssSendEndDate = _003C_003Ec__DisplayClass4_.sp.surssSendEndDate;
					surveySendSettingViewModel.surssSendEndDatePersian = (_003C_003Ec__DisplayClass4_.sp.surssSendEndDate ?? DateTime.Now).ToString("hh:mm:ss", new PersianCulture());
				}
				else
				{
					surveySendSettingViewModel.surssSendEndDate = null;
					surveySendSettingViewModel.surssSendEndDatePersian = null;
				}
				surveySendSettingViewModel.FirstRegisterUserId = _003C_003Ec__DisplayClass4_.sp.FirstRegisterUserId;
				surveySendSettingViewModel.FirstRegisterUser = _003C_003Ec__DisplayClass4_.sp.FirstRegisterUser;
				surveySendSettingViewModel.FirstRegisterDate = _003C_003Ec__DisplayClass4_.sp.FirstRegisterDate;
				surveySendSettingViewModel.FirstRegisterDatePersian = "";
				if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass4_.sp.FirstRegisterDatePersian))
				{
					surveySendSettingViewModel.FirstRegisterDatePersian = _003C_003Ec__DisplayClass4_.sp.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				}
				surveySendSettingViewModel.UserId = _003C_003Ec__DisplayClass4_.sp.UserId;
				surveySendSettingViewModel.EditUser = _003C_003Ec__DisplayClass4_.sp.EditUser;
				surveySendSettingViewModel.RegisterDate = _003C_003Ec__DisplayClass4_.sp.RegisterDate;
				surveySendSettingViewModel.RegisterDatePersian = "";
				if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass4_.sp.RegisterDatePersian))
				{
					surveySendSettingViewModel.RegisterDatePersian = _003C_003Ec__DisplayClass4_.sp.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				}
				surveySendSettingViewModel.OrderView = _003C_003Ec__DisplayClass4_.sp.OrderView;
			}
		}
		if (!surveySendSettingViewModel.OrderView.HasValue || surveySendSettingViewModel.OrderView <= 0)
		{
			List<CRMspSelectSurveySendSetting_Result> list2 = Enumerable.ToList<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)_db.CRMspSelectSurveySendSetting(currLangID, result));
			_ = Enumerable.FirstOrDefault<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)Enumerable.OrderByDescending<CRMspSelectSurveySendSetting_Result, int?>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list2, (Func<CRMspSelectSurveySendSetting_Result, int?>)((CRMspSelectSurveySendSetting_Result m) => m.OrderView)))?.OrderView;
			int num = (Enumerable.Any<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list2) ? Enumerable.Count<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list2) : 0);
			surveySendSettingViewModel.OrderView = num + 10 + num * 9 - 5;
		}
		base.ViewBag.lstProviders = SelectActiveProviders();
		return View(surveySendSettingViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmSurDefineSurveySendSettingDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(SurveySendSettingViewModel vm)
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string text = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		short year = short.Parse(Financial.Get().Id.ToString());
		short month = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			string text2 = "";
			if (!string.IsNullOrEmpty(vm.surssTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.surssTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.surssTitle,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(vm.surssTitle))
			{
				text2 = text2 + string.Format(Messages.ErrorEmpty, Labels.SurveySendSettingTitle) + "<br/>";
			}
			else if (!checkMultiLanguage(vm.surssTitle, list))
			{
				text2 = text2 + string.Format(Messages.CheckFieldInLang, Labels.SurveySendSettingTitle) + "<br>";
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
				base.ViewBag.lstProviders = SelectActiveProviders();
				return View(vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_1();
				_003C_003Ec__DisplayClass5_.findedRecord = _dbTbl.CrmSurveySendSetting.Find(vm.SurveySendSettingId);
				DateTime dateTime2 = default(DateTime);
				string text3 = "";
				if (_003C_003Ec__DisplayClass5_.findedRecord != null)
				{
					_003C_003Ec__DisplayClass5_.findedRecord.surssTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					_003C_003Ec__DisplayClass5_.findedRecord.surssSmsSendByWeb = vm.surssSmsSendByWeb;
					_003C_003Ec__DisplayClass5_.findedRecord.surssSmsProviderId = vm.surssSmsProviderId;
					_003C_003Ec__DisplayClass5_.findedRecord.surssSmsSendNumber = vm.surssSmsSendNumber;
					_003C_003Ec__DisplayClass5_.findedRecord.surssSmsSendByGSM = vm.surssSmsSendByGSM;
					_003C_003Ec__DisplayClass5_.findedRecord.surssSmsSendGSMNmber = vm.surssSmsSendGSMNmber;
					_003C_003Ec__DisplayClass5_.findedRecord.surssSendByEmail = vm.surssSendByEmail;
					_003C_003Ec__DisplayClass5_.findedRecord.surssEmailSendUserInfoId = vm.surssEmailSendUserInfoId;
					try
					{
						if (!string.IsNullOrEmpty(vm.surssSendStartDatePersian))
						{
							text3 = PersianDate.GetFormatetdDate("13000101");
							switch (lCID)
							{
							case 1065:
								dateTime2 = DateTime.Parse(text3 + " " + vm.surssSendStartDatePersian, new PersianCulture());
								vm.surssSendStartDatePersian = dateTime2.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime2 = DateTime.Parse(text3 + " " + vm.surssSendStartDatePersian, new CultureInfo("ar-SA"));
								vm.surssSendStartDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime2 = DateTime.Parse(text3 + " " + vm.surssSendStartDatePersian, new CultureInfo("en-US"));
								vm.surssSendStartDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							vm.surssSendStartDate = dateTime2;
						}
						else
						{
							vm.surssSendStartDate = null;
							vm.surssSendStartDatePersian = null;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						base.ViewBag.Error = Messages.WrongDateTime;
						return View(vm);
					}
					if (vm.surssSendStartDatePersian != null)
					{
						vm.surssSendStartDatePersian = vm.surssSendStartDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					_003C_003Ec__DisplayClass5_.findedRecord.surssSendStartDate = vm.surssSendStartDate;
					_003C_003Ec__DisplayClass5_.findedRecord.surssSendStartDatePersian = vm.surssSendStartDatePersian;
					try
					{
						if (!string.IsNullOrEmpty(vm.surssSendEndDatePersian))
						{
							text3 = PersianDate.GetFormatetdDate("15000101");
							switch (lCID)
							{
							case 1065:
								dateTime2 = DateTime.Parse(text3 + " " + vm.surssSendEndDatePersian, new PersianCulture());
								vm.surssSendEndDatePersian = dateTime2.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime2 = DateTime.Parse(text3 + " " + vm.surssSendEndDatePersian, new CultureInfo("ar-SA"));
								vm.surssSendEndDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime2 = DateTime.Parse(text3 + " " + vm.surssSendEndDatePersian, new CultureInfo("en-US"));
								vm.surssSendEndDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							vm.surssSendEndDate = dateTime2;
						}
						else
						{
							vm.surssSendEndDate = null;
							vm.surssSendEndDatePersian = null;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						base.ViewBag.Error = Messages.WrongDateTime;
						return View(vm);
					}
					if (vm.surssSendEndDatePersian != null)
					{
						vm.surssSendEndDatePersian = vm.surssSendEndDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					_003C_003Ec__DisplayClass5_.findedRecord.surssSendEndDate = vm.surssSendEndDate;
					_003C_003Ec__DisplayClass5_.findedRecord.surssSendEndDatePersian = vm.surssSendEndDatePersian;
					if (!_003C_003Ec__DisplayClass5_.findedRecord.OrderView.HasValue || _003C_003Ec__DisplayClass5_.findedRecord.OrderView <= 0)
					{
						List<CRMspSelectSurveySendSetting_Result> list2 = Enumerable.ToList<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)_db.CRMspSelectSurveySendSetting(lCID, defLangID));
						_ = Enumerable.FirstOrDefault<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)Enumerable.OrderByDescending<CRMspSelectSurveySendSetting_Result, int?>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list2, (Func<CRMspSelectSurveySendSetting_Result, int?>)((CRMspSelectSurveySendSetting_Result m) => m.OrderView)))?.OrderView;
						int num = (Enumerable.Any<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list2) ? Enumerable.Count<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list2) : 0);
						_003C_003Ec__DisplayClass5_.findedRecord.OrderView = num + 10 + num * 9 - 5;
					}
					else if (vm.OrderView > 0)
					{
						_003C_003Ec__DisplayClass5_.findedRecord.OrderView = vm.OrderView;
					}
					_003C_003Ec__DisplayClass5_.findedRecord.Month1 = month;
					_003C_003Ec__DisplayClass5_.findedRecord.UserId = userId;
					_003C_003Ec__DisplayClass5_.findedRecord.RegisterDate = dateTime;
					_003C_003Ec__DisplayClass5_.findedRecord.RegisterDatePersian = text;
					_003C_003Ec__DisplayClass5_.findedRecord.AppType = appType;
					_dbTbl.Entry(_003C_003Ec__DisplayClass5_.findedRecord).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass5_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass5_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass5_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmSurveySendSetting_Lang> crmSurveySendSetting_Lang = _dbTbl.CrmSurveySendSetting_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmSurveySendSetting_Lang), "c");
							CrmSurveySendSetting_Lang crmSurveySendSetting_Lang2 = Queryable.FirstOrDefault<CrmSurveySendSetting_Lang>((IQueryable<CrmSurveySendSetting_Lang>)crmSurveySendSetting_Lang, Expression.Lambda<Func<CrmSurveySendSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmSurveySendSetting_Lang2 != null)
							{
								crmSurveySendSetting_Lang2.surssTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmSurveySendSetting_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmSurveySendSetting_Lang2 = new CrmSurveySendSetting_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								SurveySendSettingId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.findedRecord.SurveySendSettingId,
								surssTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmSurveySendSetting_Lang.Add(crmSurveySendSetting_Lang2);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					try
					{
						if (!string.IsNullOrEmpty(vm.surssSendStartDatePersian))
						{
							text3 = PersianDate.GetFormatetdDate("13000101");
							switch (lCID)
							{
							case 1065:
								dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								vm.surssSendStartDatePersian = dateTime2.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								vm.surssSendStartDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								vm.surssSendStartDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							vm.surssSendStartDate = dateTime2;
						}
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
						base.ViewBag.Error = Messages.WrongDateTime;
						return View(vm);
					}
					if (vm.surssSendStartDatePersian != null)
					{
						vm.surssSendStartDatePersian = vm.surssSendStartDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					try
					{
						if (!string.IsNullOrEmpty(vm.surssSendEndDatePersian))
						{
							text3 = PersianDate.GetFormatetdDate("15000101");
							switch (lCID)
							{
							case 1065:
								dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								vm.surssSendEndDatePersian = dateTime2.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								vm.surssSendEndDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								vm.surssSendEndDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							vm.surssSendEndDate = dateTime2;
						}
					}
					catch (Exception e4)
					{
						ErrorSignal.FromCurrentContext().Raise(e4);
						base.ViewBag.Error = Messages.WrongDateTime;
						return View(vm);
					}
					if (vm.surssSendEndDatePersian != null)
					{
						vm.surssSendEndDatePersian = vm.surssSendEndDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					if (!vm.OrderView.HasValue || vm.OrderView <= 0)
					{
						List<CRMspSelectSurveySendSetting_Result> list3 = Enumerable.ToList<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)_db.CRMspSelectSurveySendSetting(lCID, defLangID));
						_ = Enumerable.FirstOrDefault<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)Enumerable.OrderByDescending<CRMspSelectSurveySendSetting_Result, int?>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list3, (Func<CRMspSelectSurveySendSetting_Result, int?>)((CRMspSelectSurveySendSetting_Result m) => m.OrderView)))?.OrderView;
						int num2 = (Enumerable.Any<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list3) ? Enumerable.Count<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list3) : 0);
						vm.OrderView = num2 + 10 + num2 * 9 - 5;
					}
					CrmSurveySendSetting crmSurveySendSetting = new CrmSurveySendSetting
					{
						SurveySendSettingId = vm.SurveySendSettingId,
						surssTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						surssSmsSendByWeb = vm.surssSmsSendByWeb,
						surssSmsProviderId = vm.surssSmsProviderId,
						surssSmsSendNumber = vm.surssSmsSendNumber,
						surssSmsSendByGSM = vm.surssSmsSendByGSM,
						surssSmsSendGSMNmber = vm.surssSmsSendGSMNmber,
						surssSendByEmail = vm.surssSendByEmail,
						surssEmailSendUserInfoId = vm.surssEmailSendUserInfoId,
						surssSendStartDate = vm.surssSendStartDate,
						surssSendStartDatePersian = vm.surssSendStartDatePersian,
						surssSendEndDate = vm.surssSendEndDate,
						surssSendEndDatePersian = vm.surssSendEndDatePersian,
						OrderView = vm.OrderView,
						GUId = Guid.NewGuid(),
						FirstRegisterUserId = userId,
						FirstRegisterDate = dateTime,
						FirstRegisterDatePersian = text,
						Year1 = year,
						Month1 = month,
						UserId = userId,
						RegisterDate = dateTime,
						RegisterDatePersian = text,
						AppType = appType,
						LanguageID = defLangID
					};
					_dbTbl.CrmSurveySendSetting.Add(crmSurveySendSetting);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmSurveySendSetting_Lang entity = new CrmSurveySendSetting_Lang
						{
							LanguageID = lang.LanguageID,
							SurveySendSettingId = crmSurveySendSetting.SurveySendSettingId,
							surssTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmSurveySendSetting_Lang.Add(entity);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
		base.ViewBag.lstProviders = SelectActiveProviders();
		return View(vm);
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurveySendSetting", ActionName = "actDelete")]
	[AjaxOnly]
	public string DeleteSendSetting(int sendSettingId = 0)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmSurDefineSurveySendSetting", "actDelete", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (sendSettingId != 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteSurveySendSetting(sendSettingId));
				result = ((mct_Result == null || mct_Result.Result <= 0) ? "-2" : Messages.frmDeleteSuccessMessage);
			}
			else
			{
				result = "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<CRMspSelectSurveySendSetting_Result> SelectSurveySendSetting()
	{
		List<CRMspSelectSurveySendSetting_Result> list = new List<CRMspSelectSurveySendSetting_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)_db.CRMspSelectSurveySendSetting(lCID, result));
			if (list != null)
			{
				foreach (CRMspSelectSurveySendSetting_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.surssSendStartDatePersian))
					{
						item.surssSendStartDatePersian = (item.surssSendStartDate ?? DateTime.Now).ToString("hh:mm:ss");
					}
					if (!string.IsNullOrWhiteSpace(item.surssSendEndDatePersian))
					{
						item.surssSendEndDatePersian = (item.surssSendEndDate ?? DateTime.Now).ToString("hh:mm:ss");
					}
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public CRMspSelectSurveySendSettingWithId_Result SelectSurveySendSettingWithId(int sendSettingId = 0)
	{
		CRMspSelectSurveySendSettingWithId_Result result = new CRMspSelectSurveySendSettingWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.FirstOrDefault<CRMspSelectSurveySendSettingWithId_Result>((IEnumerable<CRMspSelectSurveySendSettingWithId_Result>)_db.CRMspSelectSurveySendSettingWithId(sendSettingId, lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectActiveProviders()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<SmsspSelectActiveProviders_Result> list2 = Enumerable.ToList<SmsspSelectActiveProviders_Result>((IEnumerable<SmsspSelectActiveProviders_Result>)_db.SmsspSelectActiveProviders());
			if (list2 != null)
			{
				foreach (SmsspSelectActiveProviders_Result item2 in list2)
				{
					SelectListItem item = new SelectListItem
					{
						Text = item2.ProviderName,
						Value = item2.Id.ToString(),
						Selected = false
					};
					list.Add(item);
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
	public JsonResult GetEmailUsersInfo(int? id = null, string emailAddress = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			EmailspSelectEmailInfo_Result emailspSelectEmailInfo_Result = Enumerable.FirstOrDefault<EmailspSelectEmailInfo_Result>((IEnumerable<EmailspSelectEmailInfo_Result>)new CRMSpIEntities().EmailspSelectEmailInfo(id, emailAddress));
			if (emailspSelectEmailInfo_Result != null)
			{
				SelectListItem item = new SelectListItem
				{
					Text = emailspSelectEmailInfo_Result.euNikeName + "  [ " + emailspSelectEmailInfo_Result.euNikeEmail + " ]",
					Value = emailspSelectEmailInfo_Result.EmailUsersInfoId.ToString(),
					Selected = false
				};
				list.Add(item);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
