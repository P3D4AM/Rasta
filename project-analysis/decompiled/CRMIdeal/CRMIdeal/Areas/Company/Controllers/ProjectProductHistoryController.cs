using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Company.Controllers;

public class ProjectProductHistoryController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[LoginAuthorize]
	public ActionResult Index(int companyId = 0, int projectId = 0, int position = 0)
	{
		bool flag = true;
		_ = 10;
		base.ViewBag.CanEdit = flag;
		base.ViewBag.FrmPosition = position;
		base.ViewBag.CompanyId = companyId;
		base.ViewBag.ProjectId = projectId;
		base.ViewBag.ProjectList = SelectProjectsWithCompanyIdSelectListItem(companyId);
		return View();
	}

	[LoginAuthorize]
	public ActionResult OrderItemAllPrds(int companyId = 0, int projectId = 0)
	{
		base.ViewBag.CompanyId = companyId;
		base.ViewBag.ProjectId = projectId;
		base.ViewBag.CompanyOrdersJs = SelectCompanyOrderItemsJs(companyId, projectId);
		return View();
	}

	[LoginAuthorize]
	public ActionResult OrderItemServicePrds(int companyId = 0, int projectId = 0)
	{
		base.ViewBag.CompanyId = companyId;
		base.ViewBag.ProjectId = projectId;
		base.ViewBag.CompanyOrdersJs = SelectCompanyOrderItemsByValidityCountingJs(companyId, projectId);
		return View();
	}

	[LoginAuthorize]
	public ActionResult SelectProjectProductHistoryItem(int companyId = 0, int projectId = 0)
	{
		base.ViewBag.CompanyId = companyId;
		base.ViewBag.ProjectId = projectId;
		base.ViewBag.GroupsListJs = SelectProductGroupsByPrdValidityCountingJs();
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialProjectProductHistoryDataEntity(int cmpId, int prjId, int position, bool ShowInsertPrjPrd = false)
	{
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.PrjId = prjId;
		base.ViewBag.Position = position;
		base.ViewBag.ShowInsertPrjPrd = ShowInsertPrjPrd;
		return PartialView();
	}

	public JsonResult GetProjectProductHistoryList(int cmpId, int prjId, int showMode = 0)
	{
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmProjectProductHistoryLanguageViewModel> list = new List<CrmProjectProductHistoryLanguageViewModel>();
		try
		{
			string txtIsDone = Labels.TxtIsDone;
			string txtIsNotDone = Labels.TxtIsNotDone;
			List<CRMspSelectProjectProductHistory_Result> list2 = Enumerable.ToList<CRMspSelectProjectProductHistory_Result>((IEnumerable<CRMspSelectProjectProductHistory_Result>)_dbI.CRMspSelectProjectProductHistory(cmpId, prjId, txtIsDone, txtIsNotDone, currLangID, result, showMode));
			if (list2 != null && Enumerable.Any<CRMspSelectProjectProductHistory_Result>((IEnumerable<CRMspSelectProjectProductHistory_Result>)list2))
			{
				int num = 1;
				foreach (CRMspSelectProjectProductHistory_Result item in list2)
				{
					CrmProjectProductHistoryLanguageViewModel crmProjectProductHistoryLanguageViewModel = new CrmProjectProductHistoryLanguageViewModel
					{
						ProjectProductHistoryId = item.ProjectProductHistoryId,
						PrjPrdHCompanyId = item.PrjPrdHCompanyId,
						PrjPrdHCompany = item.PrjPrdHCompany,
						PrjPrdHProjectId = item.PrjPrdHProjectId,
						PrjPrdHProject = item.PrjPrdHProject,
						PrjPrdHProductId = item.PrjPrdHProductId,
						PrjPrdHProduct = item.PrjPrdHProduct,
						PrjPrdHProductCode = item.PrjPrdHProductCode,
						PrjPrdHOrderId = item.PrjPrdHOrderId,
						PrjPrdHOrderItemId = item.PrjPrdHOrderItemId,
						PrjPrdHSetDate = item.PrjPrdHSetDate,
						PrjPrdHSetDatePersian = item.PrjPrdHSetDatePersian,
						PrjPrdHDoneStatus = item.PrjPrdHDoneStatus,
						PrjPrdHDoneStatusTitle = item.PrjPrdHDoneStatusTitle,
						PrjPrdHDoneStatusUserId = item.PrjPrdHDoneStatusUserId,
						PrjPrdHDoneStatusUser = item.PrjPrdHDoneStatusUser,
						PrjPrdHDoneStatusDate = item.PrjPrdHDoneStatusDate,
						PrjPrdHDoneStatusDatePersian = item.PrjPrdHDoneStatusDatePersian,
						PrjPrdHDesc = item.PrjPrdHDesc,
						PrjPrdHScore = item.PrjPrdHScore,
						PrjPrdHCount = item.PrjPrdHCount,
						PrjPrdHDurationMin = item.PrjPrdHDurationMin,
						PrjPrdHNoCalc = item.PrjPrdHNoCalc,
						OrderItemQuantity = item.OrderItemQuantity,
						PrdValidityCountingNum = item.PrdValidityCountingNum,
						PrdValidityCountingMin = item.PrdValidityCountingMin,
						PrdValidityCountingNumTotal = item.PrdValidityCountingNumTotal,
						PrdValidityCountingMinTotal = item.PrdValidityCountingMinTotal,
						PrjPrdHRemainCount = item.PrjPrdHRemainCount,
						PrjPrdHRemainDurationMin = item.PrjPrdHRemainDurationMin,
						FirstRegisterDate = item.FirstRegisterDate,
						FirstRegisterDatePersian = item.FirstRegisterDatePersian,
						RegisterDate = item.RegisterDate,
						RegisterDatePersian = item.RegisterDatePersian,
						PrdValidityCountingNumIsActive = item.PrdValidityCountingNumIsActive.GetValueOrDefault(),
						PrdValidityCountingNumNeedOrder = item.PrdValidityCountingNumNeedOrder.GetValueOrDefault(),
						PrdValidityCountingNumDefaultVal = item.PrdValidityCountingNumDefaultVal,
						PrdValidityCountingNumNoCheckRemain = item.PrdValidityCountingNumNoCheckRemain.GetValueOrDefault(),
						PrdValidityCountingMinIsActive = item.PrdValidityCountingMinIsActive.GetValueOrDefault(),
						PrdValidityCountingMinNeedOrder = item.PrdValidityCountingMinNeedOrder.GetValueOrDefault(),
						PrdValidityCountingMinDefaultVal = item.PrdValidityCountingMinDefaultVal,
						PrdValidityCountingMinNoCheckRemain = item.PrdValidityCountingMinNoCheckRemain.GetValueOrDefault(),
						FirstRegisterUserId = item.FirstRegisterUserId
					};
					if (item.OrderDateTime.HasValue)
					{
						item.OrderDate = (item.OrderDateTime.HasValue ? item.OrderDateTime.Value.ToString("yyyy/MM/dd") : "");
					}
					if (item.PrjPrdHSetDate.HasValue)
					{
						item.PrjPrdHSetDatePersian = (item.PrjPrdHSetDate.HasValue ? item.PrjPrdHSetDate.Value.ToString("yyyy/MM/dd") : "");
					}
					if (item.PrjPrdHDoneStatusDate.HasValue)
					{
						item.PrjPrdHDoneStatusDatePersian = (item.PrjPrdHDoneStatusDate.HasValue ? item.PrjPrdHDoneStatusDate.Value.ToString("yyyy/MM/dd") : "");
					}
					_ = item.FirstRegisterDate;
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd");
					_ = item.RegisterDate;
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
					crmProjectProductHistoryLanguageViewModel.PrjPrdHSetDate = item.PrjPrdHSetDate;
					crmProjectProductHistoryLanguageViewModel.PrjPrdHSetDatePersian = item.PrjPrdHSetDatePersian;
					crmProjectProductHistoryLanguageViewModel.PrjPrdHDoneStatusDate = item.PrjPrdHDoneStatusDate;
					crmProjectProductHistoryLanguageViewModel.PrjPrdHDoneStatusDatePersian = item.PrjPrdHDoneStatusDatePersian;
					crmProjectProductHistoryLanguageViewModel.FirstRegisterDate = item.FirstRegisterDate;
					crmProjectProductHistoryLanguageViewModel.FirstRegisterDatePersian = item.FirstRegisterDatePersian;
					crmProjectProductHistoryLanguageViewModel.RegisterDate = item.RegisterDate;
					crmProjectProductHistoryLanguageViewModel.RegisterDatePersian = item.RegisterDatePersian;
					if (item.PrjPrdHOrderId.HasValue)
					{
						crmProjectProductHistoryLanguageViewModel.PrjPrdHOrderOrderInfo = item.OrderOpr + "-" + item.OrderDate + "-" + item.OrderNumber.GetValueOrDefault();
					}
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(item.ProjectProductHistoryLang))
					{
						List<CrmProjectProductHistory_LangViewModel> list4 = new JavaScriptSerializer().Deserialize<List<CrmProjectProductHistory_LangViewModel>>(item.ProjectProductHistoryLang);
						if (list4 != null && Enumerable.Any<CrmProjectProductHistory_LangViewModel>((IEnumerable<CrmProjectProductHistory_LangViewModel>)list4))
						{
							foreach (CrmProjectProductHistory_LangViewModel item2 in list4)
							{
								list3.Add(new CommonMultiLanguageViewModel
								{
									Value = item2.PrjPrdHDesc,
									LanguageId = item2.LanguageID
								});
							}
						}
					}
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = item.PrjPrdHDesc,
						LanguageId = currLangID
					});
					crmProjectProductHistoryLanguageViewModel.PrjPrdHDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmProjectProductHistoryLanguageViewModel.PrjPrdHDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					crmProjectProductHistoryLanguageViewModel.RowId = num;
					list.Add(crmProjectProductHistoryLanguageViewModel);
					num++;
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
	public JsonResult GetActiveHDoneStatusUsers()
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)db.CRMspSelectActiveUsers(lCID, result, 0));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
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
	public string ActDeleteProjectProductHistory(int prjPrdHisId)
	{
		string text = "";
		try
		{
			if (prjPrdHisId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteProjectProductHistory(prjPrdHisId));
					int result = 0;
					if (mct_I_Result != null)
					{
						int.TryParse(mct_I_Result.Result.ToString(), out result);
					}
					if (result == 1)
					{
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	public string InsertEditProjectProductHistory(int cmpId, int prjId, string strJson)
	{
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0772: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!VersionBuyer.ProjectProductHistory)
			{
				return Messages.VersionBuyWithoutCount;
			}
			if (cmpId == 0)
			{
				text = Messages.msgErrorNotSelectCompany;
			}
			else if (prjId == 0)
			{
				text = Messages.msgErrorNotSelectCmpProject;
			}
			else if (string.IsNullOrWhiteSpace(strJson))
			{
				text = Messages.msgErrorNotSelectedItem;
			}
			else
			{
				DateTime now = DateTime.Now;
				DateTime dateTime = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value2 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				string projectProductHistoryJson = "[]";
				List<CrmProjectProductHistoryLanguageViewModel> list = new JavaScriptSerializer().Deserialize<List<CrmProjectProductHistoryLanguageViewModel>>(strJson);
				if (list != null && Enumerable.Any<CrmProjectProductHistoryLanguageViewModel>((IEnumerable<CrmProjectProductHistoryLanguageViewModel>)list))
				{
					foreach (CrmProjectProductHistoryLanguageViewModel item in list)
					{
						List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(item.PrjPrdHDesc_Lang))
						{
							list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.PrjPrdHDesc_Lang);
						}
						list2.Add(new CommonMultiLanguageViewModel
						{
							Value = item.PrjPrdHDesc,
							LanguageId = lCID
						});
						item.PrjPrdHDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						item.PrjPrdHDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
						DateTime dateTime2 = default(DateTime);
						string text3 = "";
						try
						{
							if (!string.IsNullOrWhiteSpace(item.PrjPrdHSetDatePersian))
							{
								text3 = PersianDate.GetFormatetdDate(item.PrjPrdHSetDatePersian.Replace("/", ""));
								switch (lCID)
								{
								case 1065:
									dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
									item.PrjPrdHSetDatePersian = dateTime2.ToString("yyyyMMdd");
									break;
								case 1025:
									dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
									item.PrjPrdHSetDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
									item.PrjPrdHSetDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
								item.PrjPrdHSetDate = dateTime2;
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							text = string.Format(Messages.ErrorInFormat, Labels.PrjPrdHisTblSetDate);
							return text;
						}
						try
						{
							if (!string.IsNullOrWhiteSpace(item.PrjPrdHDoneStatusDatePersian))
							{
								text3 = PersianDate.GetFormatetdDate(item.PrjPrdHDoneStatusDatePersian.Replace("/", ""));
								switch (lCID)
								{
								case 1065:
									dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
									item.PrjPrdHDoneStatusDatePersian = dateTime2.ToString("yyyyMMdd");
									break;
								case 1025:
									dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
									item.PrjPrdHDoneStatusDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
									item.PrjPrdHDoneStatusDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
								item.PrjPrdHDoneStatusDate = dateTime2;
							}
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
							text = string.Format(Messages.ErrorInFormat, Labels.PrjPrdHisTblDoneStatusDate);
							return text;
						}
						try
						{
							if (!string.IsNullOrWhiteSpace(item.FirstRegisterDatePersian))
							{
								text3 = PersianDate.GetFormatetdDate(item.FirstRegisterDatePersian.Replace("/", ""));
								switch (lCID)
								{
								case 1065:
									dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
									item.FirstRegisterDatePersian = dateTime2.ToString("yyyyMMdd");
									break;
								case 1025:
									dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
									item.FirstRegisterDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
									item.FirstRegisterDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
								item.FirstRegisterDate = dateTime2;
							}
							else
							{
								item.FirstRegisterDatePersian = text2;
								item.FirstRegisterDate = dateTime;
							}
						}
						catch (Exception e3)
						{
							ErrorSignal.FromCurrentContext().Raise(e3);
							text = string.Format(Messages.ErrorInFormat, Labels.PrjPrdHisTblFirstRegisterDate);
							return text;
						}
						if (item.PrjPrdHDoneStatusUserId.GetValueOrDefault() == 0)
						{
							item.PrjPrdHDoneStatusUserId = null;
						}
						if (item.PrjPrdHOrderId.GetValueOrDefault() == 0)
						{
							item.PrjPrdHOrderId = null;
						}
						if (item.PrjPrdHOrderItemId.GetValueOrDefault() == 0)
						{
							item.PrjPrdHOrderItemId = null;
						}
					}
					projectProductHistoryJson = JsonConvert.SerializeObject(Enumerable.ToList<CrmProjectProductHistoryLanguageViewModel>((IEnumerable<CrmProjectProductHistoryLanguageViewModel>)list));
				}
				ObjectParameter objectParameter = new ObjectParameter("ResultJson", "");
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspInsertUpdateProjectProductHistory(cmpId, prjId, projectProductHistoryJson, userId, value2, value, dateTime, text2, appType, lCID, defLangID, objectParameter));
				int result = 0;
				int.TryParse(mct_I_Result.Result.ToString(), out result);
				if (result == 1)
				{
					string text4 = "";
					if (objectParameter != null && objectParameter.Value != null)
					{
						text4 = objectParameter.Value.ToString();
					}
					if (!string.IsNullOrWhiteSpace(text4))
					{
						List<CrmProjectProductHistoryLanguageViewModel> list3 = new JavaScriptSerializer().Deserialize<List<CrmProjectProductHistoryLanguageViewModel>>(text4);
						if (list3 != null && Enumerable.Any<CrmProjectProductHistoryLanguageViewModel>((IEnumerable<CrmProjectProductHistoryLanguageViewModel>)list3))
						{
							foreach (CrmProjectProductHistoryLanguageViewModel item2 in list3)
							{
								string text5 = item2.ErrorType ?? "";
								string arg = item2.PrjPrdHProduct + ((!string.IsNullOrWhiteSpace(item2.PrjPrdHProductCode)) ? (" (" + item2.PrjPrdHProductCode + ")") : "");
								if (string.IsNullOrWhiteSpace(text5))
								{
									continue;
								}
								string[] array = text5.Split(new char[1] { ',' });
								foreach (string text6 in array)
								{
									if (string.IsNullOrWhiteSpace(text6))
									{
										continue;
									}
									if (text6 == "1")
									{
										string text7 = string.Format(Messages.msgErrorPrjPrdHRemainCountNoEnough, arg, item2.PrjPrdHRemainCount.ToString());
										if (!string.IsNullOrWhiteSpace(text))
										{
											text += "<br>";
										}
										text += text7;
									}
									else if (text6 == "2")
									{
										string text8 = string.Format(Messages.msgErrorPrjPrdHRemainDurationMinNoEnough, arg, item2.PrjPrdHRemainDurationMin.ToString());
										if (!string.IsNullOrWhiteSpace(text))
										{
											text += "<br>";
										}
										text += text8;
									}
								}
							}
						}
						else
						{
							text = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						text = "1";
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			text = Messages.frmErrorMessage;
		}
		return text;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectCompanyOrderItemsByValidityCounting_Result> SelectCompanyOrderItemsByValidityCounting(int companyId = 0, int projectId = 0)
	{
		List<CRMspSelectCompanyOrderItemsByValidityCounting_Result> result = new List<CRMspSelectCompanyOrderItemsByValidityCounting_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyOrderItemsByValidityCounting_Result> list = Enumerable.ToList<CRMspSelectCompanyOrderItemsByValidityCounting_Result>((IEnumerable<CRMspSelectCompanyOrderItemsByValidityCounting_Result>)_dbI.CRMspSelectCompanyOrderItemsByValidityCounting(companyId, projectId, lCID, result2));
			if (list != null)
			{
				foreach (CRMspSelectCompanyOrderItemsByValidityCounting_Result item in list)
				{
					item.ordDatePersian = (item.ordDate.HasValue ? item.ordDate?.ToString("yyyy/MM/dd") : "");
				}
				result = list;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectCompanyOrderItemsByValidityCountingJs(int companyId = 0, int projectId = 0)
	{
		return JsonConvert.SerializeObject(SelectCompanyOrderItemsByValidityCounting(companyId, projectId));
	}

	public List<CRMspSelectCompanyOrderItems_Result> SelectCompanyOrderItems(int companyId = 0, int projectId = 0)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		List<CRMspSelectCompanyOrderItems_Result> result = new List<CRMspSelectCompanyOrderItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (companyId > 0)
			{
				List<CRMspSelectCompanyOrderItems_Result> list = Enumerable.ToList<CRMspSelectCompanyOrderItems_Result>((IEnumerable<CRMspSelectCompanyOrderItems_Result>)_dbI.CRMspSelectCompanyOrderItems(companyId, projectId, currLangID, result2));
				if (list != null)
				{
					foreach (CRMspSelectCompanyOrderItems_Result item in list)
					{
						item.ordDatePersian = ((!item.ordDate.HasValue) ? "" : item.ordDate?.ToString("yyyy/MM/dd"));
						List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrWhiteSpace(item.ordIDescriptionI_Lang))
						{
							list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.ordIDescriptionI_Lang);
						}
						list2.Add(new CommonMultiLanguageViewModel
						{
							Value = item.ordIDescriptionI,
							LanguageId = currLangID
						});
						if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
						{
							item.ordIDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
							item.ordIDescriptionI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
						}
						List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrWhiteSpace(item.ordIDescription_Lang))
						{
							list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.ordIDescription_Lang);
						}
						list3.Add(new CommonMultiLanguageViewModel
						{
							Value = item.ordIDescription,
							LanguageId = currLangID
						});
						if (list3 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
						{
							item.ordIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
							item.ordIDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
						}
					}
					result = list;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string SelectCompanyOrderItemsJs(int companyId = 0, int projectId = 0)
	{
		return JsonConvert.SerializeObject(SelectCompanyOrderItems(companyId, projectId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectProductValidityByGroupId_Result> SelectProductValidityByGroupId(int prdGroupId = 0, string prdName = "")
	{
		List<WSspSelectProductValidityByGroupId_Result> result = new List<WSspSelectProductValidityByGroupId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductValidityByGroupId_Result> list = Enumerable.ToList<WSspSelectProductValidityByGroupId_Result>(Enumerable.Take<WSspSelectProductValidityByGroupId_Result>(Enumerable.Where<WSspSelectProductValidityByGroupId_Result>((IEnumerable<WSspSelectProductValidityByGroupId_Result>)Enumerable.ToList<WSspSelectProductValidityByGroupId_Result>((IEnumerable<WSspSelectProductValidityByGroupId_Result>)_dbI.WSspSelectProductValidityByGroupId(prdGroupId, lCID, result2)), (Func<WSspSelectProductValidityByGroupId_Result, bool>)((WSspSelectProductValidityByGroupId_Result x) => Normalize(x.PrdName).Contains(Normalize(prdName)))), 100));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string Normalize(string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return string.Empty;
		}
		return input.Replace(" ", "").Replace('ك', 'ک').Replace('ی', 'ي')
			.ToLower();
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectProductValidityByGroupIdJs(int prdGroupId = 0, string prdName = "")
	{
		return JsonConvert.SerializeObject(SelectProductValidityByGroupId(prdGroupId, prdName));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectProjectProductHistoryOrderVerifiedItems_Result> SelectProjectProductHistoryOrderVerifiedItems(int companyId = 0, int orderId = 0, string prdName = "")
	{
		List<CRMspSelectProjectProductHistoryOrderVerifiedItems_Result> list = new List<CRMspSelectProjectProductHistoryOrderVerifiedItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectProductHistoryOrderVerifiedItems_Result> list2 = Enumerable.ToList<CRMspSelectProjectProductHistoryOrderVerifiedItems_Result>((IEnumerable<CRMspSelectProjectProductHistoryOrderVerifiedItems_Result>)_dbI.CRMspSelectProjectProductHistoryOrderVerifiedItems(companyId, orderId, prdName, lCID, result));
			if (list2 != null)
			{
				list = list2;
				foreach (CRMspSelectProjectProductHistoryOrderVerifiedItems_Result item in list)
				{
					item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectProjectProductHistoryOrderVerifiedItemsJs(int companyId = 0, int orderId = 0, string prdName = "")
	{
		return JsonConvert.SerializeObject(SelectProjectProductHistoryOrderVerifiedItems(companyId, orderId, prdName));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectProductGroupsByPrdValidityCounting_Result> SelectProductGroupsByPrdValidityCounting()
	{
		List<WSspSelectProductGroupsByPrdValidityCounting_Result> result = new List<WSspSelectProductGroupsByPrdValidityCounting_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductGroupsByPrdValidityCounting_Result> list = Enumerable.ToList<WSspSelectProductGroupsByPrdValidityCounting_Result>((IEnumerable<WSspSelectProductGroupsByPrdValidityCounting_Result>)_dbI.WSspSelectProductGroupsByPrdValidityCounting(lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectProductGroupsByPrdValidityCountingJs()
	{
		return JsonConvert.SerializeObject(SelectProductGroupsByPrdValidityCounting());
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectOrderByCompanyId_Result> SelectOrderByCompanyId(int companyId = 0, int projectId = 0)
	{
		List<WSspSelectOrderByCompanyId_Result> result = new List<WSspSelectOrderByCompanyId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 0;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
				value = UserLogin.CurrentUser.UserId;
			}
			List<WSspSelectOrderByCompanyId_Result> list = Enumerable.ToList<WSspSelectOrderByCompanyId_Result>((IEnumerable<WSspSelectOrderByCompanyId_Result>)_dbI.WSspSelectOrderByCompanyId(companyId, projectId, lCID, result2, value, result3));
			if (list != null)
			{
				foreach (WSspSelectOrderByCompanyId_Result item in list)
				{
					item.ordDatePersian = (item.ordDateTime.HasValue ? item.ordDateTime?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				}
				result = list;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectOrderByCompanyIdJs(int companyId = 0, int projectId = 0)
	{
		return JsonConvert.SerializeObject(SelectOrderByCompanyId(companyId, projectId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectOrderItems_Result> SelectOrderItems(int ordId = 0)
	{
		List<WSspSelectOrderItems_Result> result = new List<WSspSelectOrderItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (ordId > 0)
			{
				List<WSspSelectOrderItems_Result> list = Enumerable.ToList<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)db.WSspSelectOrderItems(ordId, lCID, result2));
				if (list != null)
				{
					result = list;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectOrderItemsJs(int ordId = 0)
	{
		return JsonConvert.SerializeObject(SelectOrderItems(ordId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectProjectsWithCompanyId_Result> SelectProjectsWithCompanyId(int companyId = 0)
	{
		List<CRMspSelectProjectsWithCompanyId_Result> result = new List<CRMspSelectProjectsWithCompanyId_Result>();
		try
		{
			if (companyId > 0)
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
				List<CRMspSelectProjectsWithCompanyId_Result> list = Enumerable.ToList<CRMspSelectProjectsWithCompanyId_Result>((IEnumerable<CRMspSelectProjectsWithCompanyId_Result>)_dbI.CRMspSelectProjectsWithCompanyId(companyId, lCID, result2, UserLogin.CurrentUser.UserId, result3));
				if (list != null)
				{
					result = list;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> SelectProjectsWithCompanyIdSelectListItem(int companyId = 0, int selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectProjectsWithCompanyId_Result> list2 = SelectProjectsWithCompanyId(companyId);
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectProjectsWithCompanyId_Result, SelectListItem>((IEnumerable<CRMspSelectProjectsWithCompanyId_Result>)list2, (Func<CRMspSelectProjectsWithCompanyId_Result, SelectListItem>)((CRMspSelectProjectsWithCompanyId_Result x) => new SelectListItem
				{
					Text = x.FullTitle,
					Value = x.ProjectID.ToString(),
					Selected = (x.ProjectID == selectedId)
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult EditOrdItem(int ordItemId, string ordIDescriptionI, string ordIDescriptionI_Lang)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		int num = 0;
		try
		{
			string ordiDescriptionIJson = "";
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(ordIDescriptionI_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(ordIDescriptionI_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = ordIDescriptionI.Trim(),
				LanguageId = lCID
			});
			if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
			{
				ordiDescriptionIJson = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list));
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				now.ToString("HH:mm:ss");
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				_ = Financial.Get().Id;
				short.Parse(now.ToString("yyyy", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				_dbI.WSspUpdateOrderItemDescriptionI(ordItemId, ordiDescriptionIJson, appType, value2, userId, value, registerDatePersian, result);
				commonReturnResultViewModel.IsDone = true;
				commonReturnResultViewModel.Message = Messages.msgSuccessAction;
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
			}
		}
		catch (DbEntityValidationException e)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		catch (Exception e2)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e2);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
