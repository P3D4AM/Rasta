using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class ProjectProductHistoryController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProjectProductHistoryOrderVerifiedItems_Result>> SelectProjectProductHistoryOrderVerifiedItems(int companyId, int orderId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		List<MobspSelectProjectProductHistoryOrderVerifiedItems_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectProjectProductHistoryOrderVerifiedItems_Result>((IEnumerable<MobspSelectProjectProductHistoryOrderVerifiedItems_Result>)cRMEntities.MobspSelectProjectProductHistoryOrderVerifiedItems(companyId, orderId, result, result2));
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectProjectProductHistoryOrderVerifiedItems_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<CrmProjectProductHistoryLanguageViewModel>> SelectProjectProductHistory(int companyId, int projectId, int? ln = null)
	{
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int currLangId = ((result > 0) ? result : result2);
		baseInfo.SetCulture(currLangId);
		List<CrmProjectProductHistoryLanguageViewModel> list;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					string txtIsDone = Labels.TxtIsDone;
					string txtIsNotDone = Labels.TxtIsNotDone;
					list = new List<CrmProjectProductHistoryLanguageViewModel>();
					List<MobspSelectProjectProductHistory_Result> list2 = Enumerable.ToList<MobspSelectProjectProductHistory_Result>((IEnumerable<MobspSelectProjectProductHistory_Result>)cRMEntities.MobspSelectProjectProductHistory(companyId, projectId, txtIsDone, txtIsNotDone, result, result2));
					if (list2 != null && Enumerable.Any<MobspSelectProjectProductHistory_Result>((IEnumerable<MobspSelectProjectProductHistory_Result>)list2))
					{
						int num = 1;
						foreach (MobspSelectProjectProductHistory_Result item in list2)
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
								OrderNumber = item.OrderNumber,
								OrderDate = item.OrderDate,
								OrderDateTime = item.OrderDateTime,
								OrderOpr = item.OrderOpr,
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
								PrdValidityCountingNumIsActive = item.PrdValidityCountingNumIsActive,
								PrdValidityCountingNumNeedOrder = item.PrdValidityCountingNumNeedOrder,
								PrdValidityCountingNumDefaultVal = item.PrdValidityCountingNumDefaultVal,
								PrdValidityCountingNumNoCheckRemain = item.PrdValidityCountingNumNoCheckRemain,
								PrdValidityCountingMinIsActive = item.PrdValidityCountingMinIsActive,
								PrdValidityCountingMinNeedOrder = item.PrdValidityCountingMinNeedOrder,
								PrdValidityCountingMinDefaultVal = item.PrdValidityCountingMinDefaultVal,
								PrdValidityCountingMinNoCheckRemain = item.PrdValidityCountingMinNoCheckRemain,
								FirstRegisterUserId = item.FirstRegisterUserId,
								FirstRegisterUser = item.FirstRegisterUser
							};
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
								LanguageId = currLangId
							});
							crmProjectProductHistoryLanguageViewModel.PrjPrdHDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangId)).Value : "");
							crmProjectProductHistoryLanguageViewModel.RowId = num;
							list.Add(crmProjectProductHistoryLanguageViewModel);
							num++;
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<CrmProjectProductHistoryLanguageViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DeleteProjectProductHistory(int prjPrdHisId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		string data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					if (prjPrdHisId > 0)
					{
						cRMEntities = new CRMEntities();
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.MobspDeleteProjectProductHistory(prjPrdHisId));
						int result3 = 0;
						if (mct_Result != null)
						{
							int.TryParse(mct_Result.Result.ToString(), out result3);
						}
						if (result3 == 1)
						{
							message = Messages.MobMsgSuccessAction;
							data = null;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.RedundancyMessage;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
					else
					{
						message = Messages.MobMsgErorrNotFound;
						data = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> InsertEditProjectProductHistory(int cmpId, int prjId, string strJson, int? ln = null)
	{
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0853: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		string text = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(num);
		string data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (cmpId == 0)
					{
						return new ServiceResult<string>
						{
							Message = Messages.msgErrorNotSelectCompany,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (prjId == 0)
					{
						return new ServiceResult<string>
						{
							Message = Messages.msgErrorNotSelectCmpProject,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (string.IsNullOrWhiteSpace(strJson))
					{
						return new ServiceResult<string>
						{
							Message = Messages.msgErrorNotSelectedItem,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime dateTime = now;
					string text2 = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(Financial.Get().Id.ToString());
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					int userId = token2.userId;
					cRMEntities = new CRMEntities();
					string projectProductHistoryJson = "[]";
					List<CrmProjectProductHistoryLanguageViewModel> list = new JavaScriptSerializer().Deserialize<List<CrmProjectProductHistoryLanguageViewModel>>(strJson);
					if (list != null && Enumerable.Any<CrmProjectProductHistoryLanguageViewModel>((IEnumerable<CrmProjectProductHistoryLanguageViewModel>)list))
					{
						foreach (CrmProjectProductHistoryLanguageViewModel item in list)
						{
							List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
							list2.Add(new CommonMultiLanguageViewModel
							{
								Value = item.PrjPrdHDesc,
								LanguageId = num
							});
							item.PrjPrdHDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
							item.PrjPrdHDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangId))));
							DateTime dateTime2 = default(DateTime);
							string text3 = "";
							try
							{
								if (!string.IsNullOrWhiteSpace(item.PrjPrdHSetDatePersian))
								{
									text3 = PersianDate.GetFormatetdDate(item.PrjPrdHSetDatePersian.Replace("/", ""));
									switch (num)
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
								return new ServiceResult<string>
								{
									Message = string.Format(Messages.ErrorInFormat, Labels.PrjPrdHisTblSetDate),
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
							try
							{
								if (!string.IsNullOrWhiteSpace(item.PrjPrdHDoneStatusDatePersian))
								{
									text3 = PersianDate.GetFormatetdDate(item.PrjPrdHDoneStatusDatePersian.Replace("/", ""));
									switch (num)
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
								new ServiceResult<string>
								{
									Message = string.Format(Messages.ErrorInFormat, Labels.PrjPrdHisTblDoneStatusDate),
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
							try
							{
								if (!string.IsNullOrWhiteSpace(item.FirstRegisterDatePersian))
								{
									text3 = PersianDate.GetFormatetdDate(item.FirstRegisterDatePersian.Replace("/", ""));
									switch (num)
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
								new ServiceResult<string>
								{
									Message = string.Format(Messages.ErrorInFormat, Labels.PrjPrdHisTblFirstRegisterDate),
									Data = null,
									Status = ServiceResultStatus.Fail
								};
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
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.MobspInsertUpdateProjectProductHistory(cmpId, prjId, projectProductHistoryJson, userId, value, value2, dateTime, text2, appType, num, defLangId, objectParameter));
					int result2 = 0;
					int.TryParse(mct_Result.Result.ToString(), out result2);
					if (result2 == 1)
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
					}
					else
					{
						text = Messages.msgErrorRunFunction;
					}
					if (string.IsNullOrEmpty(text))
					{
						data = null;
						text = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					text = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				text = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e4)
		{
			text = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e4);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}
}
