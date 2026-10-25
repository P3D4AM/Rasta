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
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.DiscountPolicy.Controllers;

public class HomeController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index(int partId = 0)
	{
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		string text = "";
		string text2 = "";
		switch (partId)
		{
		case 20:
			text = "frmMain";
			text2 = "actpordDefineDiscountPolicy";
			break;
		case 30:
			text = "frmMain";
			text2 = "actordDefineDiscountPolicy";
			break;
		}
		if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
		{
			if (!UserLogin.IsUserAccess(text, text2, currentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			base.ViewBag.SystemPartId = partId;
			base.ViewBag.SystemPartTitle = CRMIdeal.Classes.Helper.Setting.ReturnSystemPartTitle(partId);
			return View();
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	public JsonResult GetListDiscountPolicy(int sysPartId, int topVal = 50, long lastRowNumber = 0L)
	{
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectDiscountPolicyWithPaging_Result> list = new List<WSspSelectDiscountPolicyWithPaging_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectDiscountPolicyWithPaging_Result>((IEnumerable<WSspSelectDiscountPolicyWithPaging_Result>)_dbII.WSspSelectDiscountPolicyWithPaging(sysPartId, topVal, lastRowNumber, lCID, result));
			if (list != null)
			{
				if (Enumerable.Any<WSspSelectDiscountPolicyWithPaging_Result>((IEnumerable<WSspSelectDiscountPolicyWithPaging_Result>)list))
				{
					List<WSDiscountPolicyCriteriaViewModel> discountPolicyCriteria = GetDiscountPolicyCriteria();
					List<WSDiscountPolicyOperatorViewModel> discountPolicyOperators = GetDiscountPolicyOperators();
					foreach (WSspSelectDiscountPolicyWithPaging_Result item in list)
					{
						if (string.IsNullOrEmpty(item.AppType))
						{
							item.AppType = Configuration.AppType;
						}
						item.AppType = Configuration.GetAppType(item.AppType);
						string text = item.FirstRegisterUser ?? "";
						_ = item.FirstRegisterDate;
						string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						item.FirstRegisterUser = text + " (" + text2 + ")";
						string text3 = item.EditUser ?? "";
						_ = item.RegisterDate;
						string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						item.EditUser = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
						item.DPExpireDatePersian = (item.DPExpireDate.HasValue ? item.DPExpireDate.Value.ToString("yyyy/MM/dd") : "");
						string dPFormulaJson = "";
						if (!string.IsNullOrWhiteSpace(item.DPFormulaJson))
						{
							List<WSDiscountPolicyFormulaByTypeNameViewModel> list2 = new List<WSDiscountPolicyFormulaByTypeNameViewModel>();
							List<WSDiscountPolicyFormulaViewModel> list3 = new JavaScriptSerializer().Deserialize<List<WSDiscountPolicyFormulaViewModel>>(item.DPFormulaJson);
							if (list3 != null && Enumerable.Any<WSDiscountPolicyFormulaViewModel>((IEnumerable<WSDiscountPolicyFormulaViewModel>)list3))
							{
								foreach (WSDiscountPolicyFormulaViewModel item2 in list3)
								{
									WSDiscountPolicyFormulaByTypeNameViewModel newformula = new WSDiscountPolicyFormulaByTypeNameViewModel
									{
										FVType = item2.FVType,
										FVals = item2.FVals,
										FVal = item2.FVal,
										TVal = item2.TVal,
										Day = item2.Day,
										FDate = item2.FDate,
										TDate = item2.TDate,
										Opr = item2.Opr
									};
									if (!string.IsNullOrWhiteSpace(newformula.FDate))
									{
										DateTime dateTime = default(DateTime);
										try
										{
											dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(newformula.FDate.Replace("/", "").Replace("-", "")) + " 00:00:00", new CultureInfo("en-US"));
											newformula.FDate = dateTime.ToString("yyyy/MM/dd");
										}
										catch (Exception e)
										{
											ErrorSignal.FromCurrentContext().Raise(e);
										}
									}
									if (!string.IsNullOrWhiteSpace(newformula.TDate))
									{
										DateTime dateTime2 = default(DateTime);
										try
										{
											dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(newformula.TDate.Replace("/", "").Replace("-", "")) + " 00:00:00", new CultureInfo("en-US"));
											newformula.TDate = dateTime2.ToString("yyyy/MM/dd");
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
										}
									}
									if (discountPolicyCriteria != null && Enumerable.Any<WSDiscountPolicyCriteriaViewModel>((IEnumerable<WSDiscountPolicyCriteriaViewModel>)discountPolicyCriteria))
									{
										WSDiscountPolicyCriteriaViewModel wSDiscountPolicyCriteriaViewModel = Enumerable.FirstOrDefault<WSDiscountPolicyCriteriaViewModel>((IEnumerable<WSDiscountPolicyCriteriaViewModel>)discountPolicyCriteria, (Func<WSDiscountPolicyCriteriaViewModel, bool>)((WSDiscountPolicyCriteriaViewModel m) => m.TypeId == newformula.FVType));
										if (wSDiscountPolicyCriteriaViewModel != null)
										{
											newformula.FVTypeTitle = wSDiscountPolicyCriteriaViewModel.TypeTitle ?? "";
										}
									}
									int oprId = 1;
									if (newformula.Opr.ToLower() == "or")
									{
										oprId = 2;
									}
									if (discountPolicyOperators != null && Enumerable.Any<WSDiscountPolicyOperatorViewModel>((IEnumerable<WSDiscountPolicyOperatorViewModel>)discountPolicyOperators))
									{
										WSDiscountPolicyOperatorViewModel wSDiscountPolicyOperatorViewModel = Enumerable.FirstOrDefault<WSDiscountPolicyOperatorViewModel>((IEnumerable<WSDiscountPolicyOperatorViewModel>)discountPolicyOperators, (Func<WSDiscountPolicyOperatorViewModel, bool>)((WSDiscountPolicyOperatorViewModel m) => m.OprId == oprId));
										if (wSDiscountPolicyOperatorViewModel != null)
										{
											newformula.OprTitle = wSDiscountPolicyOperatorViewModel.OprTitle ?? "";
										}
									}
									list2.Add(newformula);
								}
							}
							if (list2 != null && Enumerable.Any<WSDiscountPolicyFormulaByTypeNameViewModel>((IEnumerable<WSDiscountPolicyFormulaByTypeNameViewModel>)list2))
							{
								dPFormulaJson = JsonConvert.SerializeObject(Enumerable.ToList<WSDiscountPolicyFormulaByTypeNameViewModel>((IEnumerable<WSDiscountPolicyFormulaByTypeNameViewModel>)list2));
							}
						}
						item.DPFormulaJson = dPFormulaJson;
					}
				}
			}
			else
			{
				list = new List<WSspSelectDiscountPolicyWithPaging_Result>();
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmDiscountPolicy", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int sysPartId, int dpId = 0)
	{
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.DPCriteriaJson = GetDiscountPolicyCriteriaJson();
		base.ViewBag.DPOperatorsJson = GetDiscountPolicyOperatorsJson();
		WSDiscountPolicyLanguageViewModel wSDiscountPolicyLanguageViewModel = new WSDiscountPolicyLanguageViewModel();
		try
		{
			WSspSelectDiscountPolicyById_Result wSspSelectDiscountPolicyById_Result = new WSspSelectDiscountPolicyById_Result();
			if (dpId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDiscountPolicy", "actInsert", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				int result2 = 0;
				ObjectParameter objectParameter = new ObjectParameter("orderView", typeof(int));
				_dbII.WSspReturnDiscountPolicyOrderView(sysPartId, objectParameter);
				if (objectParameter != null && objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result2);
				}
				wSDiscountPolicyLanguageViewModel = new WSDiscountPolicyLanguageViewModel
				{
					DPSystemPartId = sysPartId,
					DPIsActive = true,
					DPOrderView = result2
				};
				base.ViewBag.IsBuying = VersionBuyer.DiscountPolicy;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDiscountPolicy", "actEdit", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				wSspSelectDiscountPolicyById_Result = Enumerable.FirstOrDefault<WSspSelectDiscountPolicyById_Result>((IEnumerable<WSspSelectDiscountPolicyById_Result>)_dbII.WSspSelectDiscountPolicyById(dpId, result, result));
				List<WSspSelectDiscountPolicyLangById_Result> list = Enumerable.ToList<WSspSelectDiscountPolicyLangById_Result>((IEnumerable<WSspSelectDiscountPolicyLangById_Result>)_dbII.WSspSelectDiscountPolicyLangById(dpId));
				if (wSspSelectDiscountPolicyById_Result != null)
				{
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (list != null)
					{
						list2.AddRange(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSspSelectDiscountPolicyLangById_Result, CommonMultiLanguageViewModel>((IEnumerable<WSspSelectDiscountPolicyLangById_Result>)list, (Func<WSspSelectDiscountPolicyLangById_Result, CommonMultiLanguageViewModel>)((WSspSelectDiscountPolicyLangById_Result item) => new CommonMultiLanguageViewModel
						{
							Value = item.DPTitle,
							LanguageId = item.LanguageID
						}))));
					}
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = wSspSelectDiscountPolicyById_Result.DPTitle,
						LanguageId = result
					});
					wSDiscountPolicyLanguageViewModel = new WSDiscountPolicyLanguageViewModel
					{
						DiscountPolicyId = wSspSelectDiscountPolicyById_Result.DiscountPolicyId,
						DPTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
						DPTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
						DPSystemPartId = wSspSelectDiscountPolicyById_Result.DPSystemPartId,
						DPDiscountPercent = wSspSelectDiscountPolicyById_Result.DPDiscountPercent,
						DPExpireDate = wSspSelectDiscountPolicyById_Result.DPExpireDate,
						DPExpireDatePersian = (wSspSelectDiscountPolicyById_Result.DPExpireDate.HasValue ? wSspSelectDiscountPolicyById_Result.DPExpireDate.Value.ToString("yyyy/MM/dd") : ""),
						DPIsActive = wSspSelectDiscountPolicyById_Result.DPIsActive,
						DPOrderView = wSspSelectDiscountPolicyById_Result.DPOrderView,
						DPFormulaJson = wSspSelectDiscountPolicyById_Result.DPFormulaJson,
						DPFormulaJsonByName = wSspSelectDiscountPolicyById_Result.DPFormulaJsonByName,
						DPPrdExceptionJson = wSspSelectDiscountPolicyById_Result.DPPrdExceptionJson,
						DPPrdExceptionJsonByName = wSspSelectDiscountPolicyById_Result.DPPrdExceptionJsonByName
					};
					if (!string.IsNullOrWhiteSpace(wSDiscountPolicyLanguageViewModel.DPFormulaJson))
					{
						List<WSDiscountPolicyFormulaViewModel> list3 = new JavaScriptSerializer().Deserialize<List<WSDiscountPolicyFormulaViewModel>>(wSDiscountPolicyLanguageViewModel.DPFormulaJson);
						if (list3 != null && Enumerable.Any<WSDiscountPolicyFormulaViewModel>((IEnumerable<WSDiscountPolicyFormulaViewModel>)list3))
						{
							foreach (WSDiscountPolicyFormulaViewModel item in list3)
							{
								if (!string.IsNullOrWhiteSpace(item.FDate))
								{
									DateTime dateTime = default(DateTime);
									try
									{
										item.FDate = DateTime.Parse(PersianDate.GetFormatetdDate(item.FDate.Replace("/", "").Replace("-", "")) + " 00:00:00", new CultureInfo("en-US")).ToString("yyyy/MM/dd");
									}
									catch (Exception e)
									{
										ErrorSignal.FromCurrentContext().Raise(e);
									}
								}
								if (!string.IsNullOrWhiteSpace(item.TDate))
								{
									DateTime dateTime2 = default(DateTime);
									try
									{
										item.TDate = DateTime.Parse(PersianDate.GetFormatetdDate(item.TDate.Replace("/", "").Replace("-", "")) + " 00:00:00", new CultureInfo("en-US")).ToString("yyyy/MM/dd");
									}
									catch (Exception e2)
									{
										ErrorSignal.FromCurrentContext().Raise(e2);
									}
								}
							}
						}
						wSDiscountPolicyLanguageViewModel.DPFormulaJson = JsonConvert.SerializeObject(Enumerable.ToList<WSDiscountPolicyFormulaViewModel>((IEnumerable<WSDiscountPolicyFormulaViewModel>)list3));
					}
				}
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return View(wSDiscountPolicyLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDiscountPolicyDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(WSDiscountPolicyLanguageViewModel vm)
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		base.ViewBag.DPCriteriaJson = GetDiscountPolicyCriteriaJson();
		base.ViewBag.DPOperatorsJson = GetDiscountPolicyOperatorsJson();
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrWhiteSpace(vm.DPTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.DPTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = vm.DPTitle,
					LanguageId = lCID
				});
				if (string.IsNullOrWhiteSpace(vm.DPTitle))
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.DPTitle) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(vm.DPTitle, list))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.DPTitle) + "<br>";
					num++;
				}
				if (vm.DiscountPolicyId == 0 && !VersionBuyer.DiscountPolicy)
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuyWithoutCount;
					return View(vm);
				}
				if (num == 0)
				{
					DateTime dateTime = default(DateTime);
					string text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(vm.DPExpireDatePersian))
						{
							text2 = PersianDate.GetFormatetdDate(vm.DPExpireDatePersian.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
								vm.DPExpireDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
								vm.DPExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
								vm.DPExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							vm.DPExpireDate = dateTime;
						}
						else
						{
							vm.DPExpireDate = null;
							vm.DPExpireDatePersian = null;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.DPExpireDate);
						return View(vm);
					}
					string dPFormulaJson = "";
					if (!string.IsNullOrWhiteSpace(vm.DPFormulaJson))
					{
						List<WSDiscountPolicyFormulaViewModel> list2 = new JavaScriptSerializer().Deserialize<List<WSDiscountPolicyFormulaViewModel>>(vm.DPFormulaJson);
						if (list2 != null && Enumerable.Any<WSDiscountPolicyFormulaViewModel>((IEnumerable<WSDiscountPolicyFormulaViewModel>)list2))
						{
							foreach (WSDiscountPolicyFormulaViewModel item in list2)
							{
								if (!string.IsNullOrWhiteSpace(item.FDate))
								{
									text2 = "";
									try
									{
										text2 = PersianDate.GetFormatetdDate(item.FDate.Replace("/", ""));
										item.FDate = (lCID switch
										{
											1065 => DateTime.Parse(text2 + " 00:00:00", new PersianCulture()), 
											1025 => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA")), 
											_ => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US")), 
										}).ToString("yyyy-MM-dd", new CultureInfo("en-US"));
									}
									catch (Exception e2)
									{
										ErrorSignal.FromCurrentContext().Raise(e2);
										base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.DPAmountPreviousPurchaseRecordsRange);
										return View(vm);
									}
								}
								else
								{
									item.FDate = "";
								}
								if (!string.IsNullOrWhiteSpace(item.TDate))
								{
									text2 = "";
									try
									{
										text2 = PersianDate.GetFormatetdDate(item.TDate.Replace("/", ""));
										item.TDate = (lCID switch
										{
											1065 => DateTime.Parse(text2 + " 00:00:00", new PersianCulture()), 
											1025 => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA")), 
											_ => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US")), 
										}).ToString("yyyy-MM-dd", new CultureInfo("en-US"));
									}
									catch (Exception e3)
									{
										ErrorSignal.FromCurrentContext().Raise(e3);
										base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.DPAmountPreviousPurchaseRecordsRange);
										return View(vm);
									}
								}
								else
								{
									item.TDate = "";
								}
							}
						}
						dPFormulaJson = JsonConvert.SerializeObject(Enumerable.ToList<WSDiscountPolicyFormulaViewModel>((IEnumerable<WSDiscountPolicyFormulaViewModel>)list2));
					}
					try
					{
						DateTime now = DateTime.Now;
						DateTime value = now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType = Configuration.AppType;
						int id = Financial.Get().Id;
						int userId = UserLogin.CurrentUser.UserId;
						string dPTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						string dPTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
						int result = 0;
						ObjectParameter objectParameter = new ObjectParameter("disPolId", typeof(int));
						mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspInsertUpdateDiscountPolicy(vm.DiscountPolicyId, vm.DPSystemPartId, dPTitle, dPTitle_Lang, vm.DPDiscountPercent, vm.DPExpireDate, vm.DPExpireDatePersian, vm.DPIsActive, dPFormulaJson, vm.DPPrdExceptionJson, vm.DPOrderView, userId, id, value2, value, registerDatePersian, appType, defLangID, objectParameter));
						if (objectParameter != null && objectParameter.Value != null)
						{
							int.TryParse(objectParameter.Value.ToString(), out result);
						}
						int result2 = 0;
						if (mct_II_Result != null)
						{
							int.TryParse(mct_II_Result.Result.ToString(), out result2);
						}
						if (result2 == 0)
						{
							text = Messages.msgErrorRunFunction;
						}
						else
						{
							if (vm.DiscountPolicyId > 0)
							{
								base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
							}
							else
							{
								vm.DiscountPolicyId = result;
								base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDiscountPolicy");
						}
					}
					catch (Exception e4)
					{
						ErrorSignal.FromCurrentContext().Raise(e4);
						text = Messages.msgErrorRunFunction;
					}
				}
			}
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
		vm.DPExpireDatePersian = (vm.DPExpireDate.HasValue ? vm.DPExpireDate.Value.ToString("yyyy/MM/dd") : "");
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(vm);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDiscountPolicy", ActionName = "actDelete")]
	public string ActDelete(int dpId)
	{
		string text = "";
		try
		{
			if (dpId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				if (Enumerable.FirstOrDefault<WSspSelectDiscountPolicyById_Result>((IEnumerable<WSspSelectDiscountPolicyById_Result>)_dbII.WSspSelectDiscountPolicyById(dpId, result, result)) != null)
				{
					try
					{
						mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeleteDiscountPolicy(dpId));
						int result2 = 0;
						if (mct_II_Result != null)
						{
							int.TryParse(mct_II_Result.Result.ToString(), out result2);
						}
						if (result2 > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDiscountPolicy");
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

	public List<WSDiscountPolicyCriteriaViewModel> GetDiscountPolicyCriteria()
	{
		List<WSDiscountPolicyCriteriaViewModel> list = new List<WSDiscountPolicyCriteriaViewModel>();
		try
		{
			WSDiscountPolicyCriteriaViewModel item = new WSDiscountPolicyCriteriaViewModel
			{
				TypeId = 1,
				TypeTitle = Labels.DPCmpGroup,
				CatId = 1
			};
			list.Add(item);
			item = new WSDiscountPolicyCriteriaViewModel
			{
				TypeId = 2,
				TypeTitle = Labels.DPCmpSubGroup,
				CatId = 1
			};
			list.Add(item);
			item = new WSDiscountPolicyCriteriaViewModel
			{
				TypeId = 3,
				TypeTitle = Labels.DPCmpGroupII,
				CatId = 1
			};
			list.Add(item);
			item = new WSDiscountPolicyCriteriaViewModel
			{
				TypeId = 4,
				TypeTitle = Labels.DPCmpGroupIII,
				CatId = 1
			};
			list.Add(item);
			item = new WSDiscountPolicyCriteriaViewModel
			{
				TypeId = 5,
				TypeTitle = Labels.DPCmpGroupIV,
				CatId = 1
			};
			list.Add(item);
			item = new WSDiscountPolicyCriteriaViewModel
			{
				TypeId = 6,
				TypeTitle = Labels.DPCmpType,
				CatId = 1
			};
			list.Add(item);
			item = new WSDiscountPolicyCriteriaViewModel
			{
				TypeId = 7,
				TypeTitle = Labels.DPCmpPresentation,
				CatId = 1
			};
			list.Add(item);
			item = new WSDiscountPolicyCriteriaViewModel
			{
				TypeId = 8,
				TypeTitle = Labels.DPPrdGroup,
				CatId = 2
			};
			list.Add(item);
			item = new WSDiscountPolicyCriteriaViewModel
			{
				TypeId = 9,
				TypeTitle = Labels.DPPrd,
				CatId = 2
			};
			list.Add(item);
			item = new WSDiscountPolicyCriteriaViewModel
			{
				TypeId = 10,
				TypeTitle = Labels.DPFinancialTotalAmount,
				CatId = 3
			};
			list.Add(item);
			item = new WSDiscountPolicyCriteriaViewModel
			{
				TypeId = 11,
				TypeTitle = Labels.DPAmountPreviousPurchaseRecords,
				CatId = 3
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public string GetDiscountPolicyCriteriaJson()
	{
		string result = "";
		try
		{
			result = JsonConvert.SerializeObject(GetDiscountPolicyCriteria());
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<WSDiscountPolicyOperatorViewModel> GetDiscountPolicyOperators()
	{
		List<WSDiscountPolicyOperatorViewModel> list = new List<WSDiscountPolicyOperatorViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string oprTitle = "AND (" + Labels.lblAnd + ")";
			string oprTitle2 = "OR (" + Labels.lblOR + ")";
			if (lCID != 1065 && lCID != 1025)
			{
				oprTitle = "AND";
				oprTitle2 = "OR";
			}
			WSDiscountPolicyOperatorViewModel item = new WSDiscountPolicyOperatorViewModel
			{
				OprId = 1,
				OprTitle = oprTitle
			};
			list.Add(item);
			item = new WSDiscountPolicyOperatorViewModel
			{
				OprId = 2,
				OprTitle = oprTitle2
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public string GetDiscountPolicyOperatorsJson()
	{
		string result = "";
		try
		{
			result = JsonConvert.SerializeObject(GetDiscountPolicyOperators());
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
