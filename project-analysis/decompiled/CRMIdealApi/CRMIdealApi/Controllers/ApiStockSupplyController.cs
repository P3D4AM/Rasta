using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using CRM.General.Security;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Common;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdealApi.Controllers;

public class ApiStockSupplyController : ApiController
{
	private DateTime registerDate = DateTime.Now;

	private string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());

	private string registerTime = DateTime.Now.ToString("HH:mm:ss");

	private short month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));

	private string appType = CRMIdealApi.Classes.Configuration.AppType;

	private ResourceManager RS = new ResourceManager();

	[HttpPost]
	public ServiceResult<IssueStockSupplyResultViewModel> Issue(IssueStockSupplyViewModel model)
	{
		string text = "";
		IssueStockSupplyResultViewModel issueStockSupplyResultViewModel = null;
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		ServiceResult<InsertStockSupplyResultViewModel> serviceResult = Insert(new InsertStockSupplyViewModel
		{
			UserName = model.UserName,
			Password = model.Password,
			UserId = model.UserId,
			LanguageId = model.LanguageId,
			ApiStsupReferUserId = model.ApiStsupReferUserId,
			ApiStsupNumber = model.ApiStsupNumber,
			ApiStsupDateTime = model.ApiStsupDateTime,
			ApiStsupCompanyId = model.ApiStsupCompanyId,
			ApiStsupCompanyPersonId = model.ApiStsupCompanyPersonId,
			ApiStsupProjectId = model.ApiStsupProjectId,
			ApiStsupIsFixed = model.ApiStsupIsFixed,
			ApiStsupIsCanceled = model.ApiStsupIsCanceled,
			ApiStsupIsVerified = model.ApiStsupIsVerified,
			ApiStsupVerifierRequestId = model.ApiStsupVerifierRequestId,
			ApiStsupVerifierId = model.ApiStsupVerifierId,
			ApiStsupVerifiedRegisterDate = model.ApiStsupVerifiedRegisterDate,
			ApiStsupVerificationWorkFlowId = model.ApiStsupVerificationWorkFlowId,
			ApiStsupPrintFormatId = model.ApiStsupPrintFormatId,
			ApiStsupNote = model.ApiStsupNote,
			ApiStsupItemCount = model.ApiStsupItemCount,
			ApiStsupItemsQty = model.ApiStsupItemsQty,
			ApiStsupPreOrderId = model.ApiStsupPreOrderId,
			CenterId = model.CenterId,
			CenterCode = model.CenterCode
		});
		if (serviceResult.Status == ServiceResultStatus.Success)
		{
			text = serviceResult.Message;
			issueStockSupplyResultViewModel = new IssueStockSupplyResultViewModel
			{
				ApiStockSupplyId = serviceResult.Data.ApiStockSupplyId,
				ApiStockSupplyNumber = serviceResult.Data.ApiStockSupplyNumber
			};
			serviceResultStatus = serviceResult.Status;
			if (!string.IsNullOrWhiteSpace(model.StockSupplyItemsJs))
			{
				List<InsertStockSupplyItemViewModel> list = JsonConvert.DeserializeObject<List<InsertStockSupplyItemViewModel>>(model.StockSupplyItemsJs);
				foreach (InsertStockSupplyItemViewModel item in list)
				{
					item.ApiStockSupplyId = serviceResult.Data.ApiStockSupplyId;
					item.UserName = model.UserName;
					item.Password = model.Password;
					item.UserId = model.UserId;
					item.LanguageId = model.LanguageId;
					ServiceResult<int?> serviceResult2 = InsertStockSupplyItem(item);
					if (serviceResult2.Status != ServiceResultStatus.Success)
					{
						serviceResultStatus = serviceResult2.Status;
						if (text != "")
						{
							text += "\n";
						}
						text += serviceResult2.Message;
					}
				}
			}
		}
		else
		{
			text = serviceResult.Message;
			issueStockSupplyResultViewModel = null;
			serviceResultStatus = serviceResult.Status;
		}
		return new ServiceResult<IssueStockSupplyResultViewModel>
		{
			Message = text,
			Data = issueStockSupplyResultViewModel,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public ServiceResult<InsertStockSupplyResultViewModel> Insert(InsertStockSupplyViewModel model)
	{
		CRMEntities cRMEntities = null;
		InsertStockSupplyResultViewModel insertStockSupplyResultViewModel = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				text = Messages.ErrorAccessAPILimited;
				insertStockSupplyResultViewModel = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
			else
			{
				cRMEntities = new CRMEntities();
				CommonClass commonClass = new CommonClass();
				ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
				if (apispSelectCrmsysSetting_Result == null)
				{
					text = Messages.ErrorInReadingSysSetting;
					insertStockSupplyResultViewModel = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
				else
				{
					int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					int.TryParse(model.LanguageId.ToString(), out var currLangId);
					if (currLangId <= 0)
					{
						currLangId = result;
					}
					List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
					string langCollation = "fa-IR";
					ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
					if (apispSelectLanguages_Result != null)
					{
						langCollation = apispSelectLanguages_Result.LanguageCollation;
					}
					if (!VersionBuyer.StockSupply)
					{
						return new ServiceResult<InsertStockSupplyResultViewModel>
						{
							Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("StockSupply", new CultureInfo(currLangId))),
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					if (!string.IsNullOrEmpty(model.Password))
					{
						model.Password = CodeDecode.DeCodding(model.Password);
					}
					if (!string.IsNullOrEmpty(model.UserName))
					{
						model.UserName = CodeDecode.DeCodding(model.UserName);
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
					int result2 = 0;
					int.TryParse(num.ToString(), out result2);
					if (result2 == 0)
					{
						text = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId);
						insertStockSupplyResultViewModel = null;
						serviceResultStatus = ServiceResultStatus.Error;
					}
					else
					{
						string text2 = "";
						_ = model.ApiStsupDateTime;
						text2 = model.ApiStsupDateTime.ToString("yyyyMMdd", new PersianCulture());
						string stsupVerifiedRegisterDatePersian = "";
						if (model.ApiStsupVerifiedRegisterDate.HasValue)
						{
							stsupVerifiedRegisterDatePersian = model.ApiStsupVerifiedRegisterDate?.ToString("yyyyMMdd", new PersianCulture());
						}
						int userId = model.UserId;
						DateTime now = DateTime.Now;
						DateTime value = now;
						string firstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						string text3 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
						string text4 = now.ToString("HH:mm:ss");
						short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						string text5 = CRMIdealApi.Classes.Configuration.AppType;
						ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
						ObjectParameter objectParameter2 = new ObjectParameter("StockSupplyId", 0);
						ObjectParameter objectParameter3 = new ObjectParameter("stsupNumber", 0);
						cRMEntities.ApispInsertStockSupply(1, model.ApiStsupReferUserId, model.ApiStsupDateTime, text2, model.ApiStsupCompanyId, model.ApiStsupCompanyPersonId, model.ApiStsupProjectId, model.ApiStsupIsFixed, model.ApiStsupIsCanceled, model.ApiStsupIsVerified, model.ApiStsupVerifierRequestId, model.ApiStsupVerifierId, model.ApiStsupVerifiedRegisterDate, stsupVerifiedRegisterDatePersian, model.ApiStsupVerificationWorkFlowId, model.ApiStsupPrintFormatId, model.ApiStsupNote, model.ApiStsupItemCount, model.ApiStsupItemsQty, model.ApiStsupPreOrderId, userId, value, firstRegisterDatePersian, userId, value, firstRegisterDatePersian, objectParameter2, objectParameter3, value2, text5, currLangId, result, objectParameter, model.CenterId, model.CenterCode);
						if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
						{
							text = GetMessageResult(objectParameter.Value.ToString(), langCollation);
							insertStockSupplyResultViewModel = null;
							serviceResultStatus = ServiceResultStatus.Fail;
						}
						else
						{
							text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
							insertStockSupplyResultViewModel = new InsertStockSupplyResultViewModel
							{
								ApiStockSupplyId = int.Parse(objectParameter2.Value.ToString()),
								ApiStockSupplyNumber = long.Parse(objectParameter3.Value.ToString())
							};
							serviceResultStatus = ServiceResultStatus.Success;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			string text6 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text6 = text6 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text6)) ? (" (" + text6 + ")") : "");
			insertStockSupplyResultViewModel = null;
			serviceResultStatus = ServiceResultStatus.Error;
			Public.InsExceptToElmah(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<InsertStockSupplyResultViewModel>
		{
			Message = text,
			Data = insertStockSupplyResultViewModel,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public ServiceResult<int?> InsertStockSupplyItem(InsertStockSupplyItemViewModel model)
	{
		CRMEntities cRMEntities = null;
		int? num = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				text = Messages.ErrorAccessAPILimited;
				num = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
			else
			{
				cRMEntities = new CRMEntities();
				CommonClass commonClass = new CommonClass();
				ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
				if (apispSelectCrmsysSetting_Result == null)
				{
					text = Messages.ErrorInReadingSysSetting;
					num = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
				else
				{
					int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					int.TryParse(model.LanguageId.ToString(), out var currLangId);
					if (currLangId <= 0)
					{
						currLangId = result;
					}
					List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
					string langCollation = "fa-IR";
					ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
					if (apispSelectLanguages_Result != null)
					{
						langCollation = apispSelectLanguages_Result.LanguageCollation;
					}
					if (!string.IsNullOrEmpty(model.Password))
					{
						model.Password = CodeDecode.DeCodding(model.Password);
					}
					if (!string.IsNullOrEmpty(model.UserName))
					{
						model.UserName = CodeDecode.DeCodding(model.UserName);
					}
					int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
					int result2 = 0;
					int.TryParse(num2.ToString(), out result2);
					if (result2 == 0)
					{
						text = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId);
						num = null;
						serviceResultStatus = ServiceResultStatus.Error;
					}
					else
					{
						int userId = model.UserId;
						DateTime now = DateTime.Now;
						DateTime value = now;
						string text2 = now.ToString("yyyyMMdd", new PersianCulture());
						string text3 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
						string text4 = now.ToString("HH:mm:ss");
						short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						string text5 = CRMIdealApi.Classes.Configuration.AppType;
						ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
						ObjectParameter objectParameter2 = new ObjectParameter("stockSupplyItemId", 0);
						Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertStockSupplyItem(model.ApiStockSupplyId, model.ApiStsupIPrdId, model.ApiStsupIQuantity, model.ApiStsupIDescription, model.ApiStsupIQuantityDesc, model.ApiStsupIPrdUnitId, model.ApiStsupIOrderView, model.ApiStsupIFCR, model.ApiStsupIFCRI, model.ApiStsupIWHId, model.ApiStsupITracing, model.ApiStsupIPrdUnitIdI, model.ApiStsupIPrdUnitIRateResult, model.ApiStsupIPrdColorId, model.ApiStsupIPrdNickname, model.ApiStsupIPreOrderId, model.ApiStsupIPreOrderItemId, model.ApiStsupIBuyOrderIds, model.ApiStsupIBuyOrderItemIds, objectParameter2, userId, value2, value, text2, text5, currLangId, result, objectParameter, model.CenterId, model.CenterCode));
						if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
						{
							text = GetMessageResult(objectParameter.Value.ToString(), langCollation);
							num = null;
							serviceResultStatus = ServiceResultStatus.Fail;
						}
						else
						{
							text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
							num = int.Parse(objectParameter2.Value.ToString());
							serviceResultStatus = ServiceResultStatus.Success;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			string text6 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text6 = text6 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text6)) ? (" (" + text6 + ")") : "");
			num = null;
			serviceResultStatus = ServiceResultStatus.Error;
			Public.InsExceptToElmah(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<int?>
		{
			Message = text,
			Data = num,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public ServiceResult<int?> Update(UpdateStockSupplyViewModel model)
	{
		CRMEntities cRMEntities = null;
		int? num = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				text = Messages.ErrorAccessAPILimited;
				num = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
			else
			{
				cRMEntities = new CRMEntities();
				CommonClass commonClass = new CommonClass();
				ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
				if (apispSelectCrmsysSetting_Result == null)
				{
					text = Messages.ErrorInReadingSysSetting;
					num = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
				else
				{
					int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					int.TryParse(model.LanguageId.ToString(), out var currLangId);
					if (currLangId <= 0)
					{
						currLangId = result;
					}
					List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
					string langCollation = "fa-IR";
					ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
					if (apispSelectLanguages_Result != null)
					{
						langCollation = apispSelectLanguages_Result.LanguageCollation;
					}
					if (!string.IsNullOrEmpty(model.Password))
					{
						model.Password = CodeDecode.DeCodding(model.Password);
					}
					if (!string.IsNullOrEmpty(model.UserName))
					{
						model.UserName = CodeDecode.DeCodding(model.UserName);
					}
					int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
					int result2 = 0;
					int.TryParse(num2.ToString(), out result2);
					if (result2 == 0)
					{
						text = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId);
						num = null;
						serviceResultStatus = ServiceResultStatus.Error;
					}
					else if (model.ApiStockSupplyId <= 0)
					{
						text = ResourceManager.GetMessage("ErrorNotFound", currLangId);
						num = null;
						serviceResultStatus = ServiceResultStatus.Fail;
					}
					else
					{
						int userId = model.UserId;
						DateTime now = DateTime.Now;
						DateTime value = now;
						string text2 = now.ToString("yyyyMMdd", new PersianCulture());
						string text3 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
						string text4 = now.ToString("HH:mm:ss");
						short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						string text5 = CRMIdealApi.Classes.Configuration.AppType;
						ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
						string text6 = "";
						_ = model.ApiStsupDateTime;
						text6 = model.ApiStsupDateTime.ToString("yyyyMMdd", new PersianCulture());
						string stsupVerifiedRegisterDatePersian = "";
						if (model.ApiStsupVerifiedRegisterDate.HasValue)
						{
							stsupVerifiedRegisterDatePersian = model.ApiStsupVerifiedRegisterDate?.ToString("yyyyMMdd", new PersianCulture());
						}
						int num3 = cRMEntities.ApispUpdateStockSupply(model.ApiStockSupplyId, 1, model.ApiStsupReferUserId, model.ApiStsupNumber, model.ApiStsupDateTime, text6, model.ApiStsupCompanyId, model.ApiStsupCompanyPersonId, model.ApiStsupProjectId, model.ApiStsupIsFixed, model.ApiStsupIsCanceled, model.ApiStsupIsVerified, model.ApiStsupVerifierRequestId, model.ApiStsupVerifierId, model.ApiStsupVerifiedRegisterDate, stsupVerifiedRegisterDatePersian, model.ApiStsupVerificationWorkFlowId, model.ApiStsupPrintFormatId, model.ApiStsupNote, model.ApiStsupItemCount, model.ApiStsupItemsQty, model.ApiStsupPreOrderId, userId, value, text2, value2, text5, currLangId, result, objectParameter, model.CenterId, model.CenterCode);
						if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
						{
							text = GetMessageResult(objectParameter.Value.ToString(), langCollation);
							num = null;
							serviceResultStatus = ServiceResultStatus.Fail;
						}
						else
						{
							text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
							num = 1;
							serviceResultStatus = ServiceResultStatus.Success;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			string text7 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text7 = text7 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text7)) ? (" (" + text7 + ")") : "");
			num = null;
			serviceResultStatus = ServiceResultStatus.Error;
			Public.InsExceptToElmah(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<int?>
		{
			Message = text,
			Data = num,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectStockSupply_Result>> Select(SelectStockSupplyViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectStockSupply_Result> list = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				text = Messages.ErrorAccessAPILimited;
				list = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
			else
			{
				cRMEntities = new CRMEntities();
				CommonClass commonClass = new CommonClass();
				ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
				if (apispSelectCrmsysSetting_Result == null)
				{
					text = Messages.ErrorInReadingSysSetting;
					list = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
				else
				{
					int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					int.TryParse(model.LanguageId.ToString(), out var currLangId);
					if (currLangId <= 0)
					{
						currLangId = result;
					}
					List<ApispSelectLanguages_Result> list2 = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
					string text2 = "fa-IR";
					ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list2, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
					if (apispSelectLanguages_Result != null)
					{
						text2 = apispSelectLanguages_Result.LanguageCollation;
					}
					if (!string.IsNullOrEmpty(model.Password))
					{
						model.Password = CodeDecode.DeCodding(model.Password);
					}
					if (!string.IsNullOrEmpty(model.UserName))
					{
						model.UserName = CodeDecode.DeCodding(model.UserName);
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
					int result2 = 0;
					int.TryParse(num.ToString(), out result2);
					if (result2 == 0)
					{
						text = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId);
						list = null;
						serviceResultStatus = ServiceResultStatus.Error;
					}
					else
					{
						List<ApispSelectStockSupply_Result> list3 = Enumerable.ToList<ApispSelectStockSupply_Result>((IEnumerable<ApispSelectStockSupply_Result>)cRMEntities.ApispSelectStockSupply(companyId: model.ApiCompanyId, fromDate: model.ApiFromDate, toDate: model.ApiToDate, stockSupplyId: model.ApiStockSupplyId, stockSupplyNumber: model.ApiStockSupplyNumber, languageID: currLangId, defaultLanguageID: result, centerId: model.CenterId, centerCode: model.CenterCode));
						if (list3 != null)
						{
							text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
							list = list3;
							serviceResultStatus = ServiceResultStatus.Success;
						}
						else
						{
							text = ResourceManager.GetMessage("ErrorNotFound", currLangId);
							list = null;
							serviceResultStatus = ServiceResultStatus.Fail;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			list = null;
			serviceResultStatus = ServiceResultStatus.Error;
			Public.InsExceptToElmah(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<List<ApispSelectStockSupply_Result>>
		{
			Message = text,
			Data = list,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteStockSupplyViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool flag = false;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				text = Messages.ErrorAccessAPILimited;
				flag = false;
				serviceResultStatus = ServiceResultStatus.Error;
			}
			else
			{
				cRMEntities = new CRMEntities();
				CommonClass commonClass = new CommonClass();
				ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
				if (apispSelectCrmsysSetting_Result == null)
				{
					text = Messages.ErrorInReadingSysSetting;
					flag = false;
					serviceResultStatus = ServiceResultStatus.Error;
				}
				else
				{
					int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					int.TryParse(model.LanguageId.ToString(), out var currLangId);
					if (currLangId <= 0)
					{
						currLangId = result;
					}
					List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
					string text2 = "fa-IR";
					ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
					if (apispSelectLanguages_Result != null)
					{
						text2 = apispSelectLanguages_Result.LanguageCollation;
					}
					if (!string.IsNullOrEmpty(model.Password))
					{
						model.Password = CodeDecode.DeCodding(model.Password);
					}
					if (!string.IsNullOrEmpty(model.UserName))
					{
						model.UserName = CodeDecode.DeCodding(model.UserName);
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
					int result2 = 0;
					int.TryParse(num.ToString(), out result2);
					if (result2 == 0)
					{
						text = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId);
						flag = false;
						serviceResultStatus = ServiceResultStatus.Error;
					}
					else if (model.ApiStockSupplyId > 0)
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteStockSupply(model.ApiStockSupplyId));
						if (mct_Result != null)
						{
							if (mct_Result.Result > 0)
							{
								flag = true;
								text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
								serviceResultStatus = ServiceResultStatus.Success;
							}
							else if (mct_Result.Result == -2)
							{
								flag = false;
								text = ResourceManager.GetMessage("ErrorOrdIsFixed", currLangId);
								serviceResultStatus = ServiceResultStatus.Fail;
							}
							else
							{
								flag = false;
								text = ResourceManager.GetMessage("RedundancyMessage", currLangId);
								serviceResultStatus = ServiceResultStatus.Fail;
							}
						}
						else
						{
							flag = false;
							text = ResourceManager.GetMessage("RedundancyMessage", currLangId);
							serviceResultStatus = ServiceResultStatus.Fail;
						}
					}
					else
					{
						flag = false;
						text = ResourceManager.GetMessage("ErrorNotFound", currLangId);
						serviceResultStatus = ServiceResultStatus.Fail;
					}
				}
			}
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			flag = false;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<bool>
		{
			Message = text,
			Data = flag,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public ServiceResult<int?> UpdateStockSupplyItem(UpdateStockSupplyItemViewModel model)
	{
		CRMEntities cRMEntities = null;
		int? num = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				text = Messages.ErrorAccessAPILimited;
				num = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
			else
			{
				cRMEntities = new CRMEntities();
				CommonClass commonClass = new CommonClass();
				ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
				if (apispSelectCrmsysSetting_Result == null)
				{
					text = Messages.ErrorInReadingSysSetting;
					num = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
				else
				{
					int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					int.TryParse(model.LanguageId.ToString(), out var currLangId);
					if (currLangId <= 0)
					{
						currLangId = result;
					}
					List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
					string langCollation = "fa-IR";
					ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
					if (apispSelectLanguages_Result != null)
					{
						langCollation = apispSelectLanguages_Result.LanguageCollation;
					}
					if (!string.IsNullOrEmpty(model.Password))
					{
						model.Password = CodeDecode.DeCodding(model.Password);
					}
					if (!string.IsNullOrEmpty(model.UserName))
					{
						model.UserName = CodeDecode.DeCodding(model.UserName);
					}
					int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
					int result2 = 0;
					int.TryParse(num2.ToString(), out result2);
					if (result2 == 0)
					{
						text = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId);
						num = null;
						serviceResultStatus = ServiceResultStatus.Error;
					}
					else if (model.ApiStockSupplyItemId <= 0)
					{
						text = ResourceManager.GetMessage("ErrorNotFound", currLangId);
						num = null;
						serviceResultStatus = ServiceResultStatus.Fail;
					}
					else
					{
						int userId = model.UserId;
						DateTime now = DateTime.Now;
						DateTime value = now;
						string text2 = now.ToString("yyyyMMdd", new PersianCulture());
						string text3 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
						string text4 = now.ToString("HH:mm:ss");
						short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						string text5 = CRMIdealApi.Classes.Configuration.AppType;
						ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
						cRMEntities.ApispUpdateStockSupplyItem(model.ApiStockSupplyItemId, model.ApiStockSupplyId, model.ApiStsupIPrdId, model.ApiStsupIQuantity, model.ApiStsupIDescription, model.ApiStsupIQuantityDesc, model.ApiStsupIPrdUnitId, model.ApiStsupIOrderView, model.ApiStsupIFCR, model.ApiStsupIFCRI, model.ApiStsupIWHId, model.ApiStsupITracing, model.ApiStsupIPrdUnitIdI, model.ApiStsupIPrdUnitIRateResult, model.ApiStsupIPrdColorId, model.ApiStsupIPrdNickname, model.ApiStsupIPreOrderId, model.ApiStsupIPreOrderItemId, model.ApiStsupIBuyOrderIds, model.ApiStsupIBuyOrderItemIds, userId, value2, value, text2, text5, currLangId, result, objectParameter, model.CenterId, model.CenterCode);
						if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
						{
							text = GetMessageResult(objectParameter.Value.ToString(), langCollation);
							num = null;
							serviceResultStatus = ServiceResultStatus.Fail;
						}
						else
						{
							text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
							num = 1;
							serviceResultStatus = ServiceResultStatus.Success;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			string text6 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text6 = text6 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text6)) ? (" (" + text6 + ")") : "");
			num = null;
			serviceResultStatus = ServiceResultStatus.Error;
			Public.InsExceptToElmah(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<int?>
		{
			Message = text,
			Data = num,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectStockSupplyItems_Result>> SelectStockSupplyItems(SelectStockSupplyItemViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectStockSupplyItems_Result> list = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				text = Messages.ErrorAccessAPILimited;
				list = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
			else
			{
				cRMEntities = new CRMEntities();
				CommonClass commonClass = new CommonClass();
				ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
				if (apispSelectCrmsysSetting_Result == null)
				{
					text = Messages.ErrorInReadingSysSetting;
					list = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
				else
				{
					int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					int.TryParse(model.LanguageId.ToString(), out var currLangId);
					if (currLangId <= 0)
					{
						currLangId = result;
					}
					List<ApispSelectLanguages_Result> list2 = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
					string text2 = "fa-IR";
					ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list2, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
					if (apispSelectLanguages_Result != null)
					{
						text2 = apispSelectLanguages_Result.LanguageCollation;
					}
					if (!string.IsNullOrEmpty(model.Password))
					{
						model.Password = CodeDecode.DeCodding(model.Password);
					}
					if (!string.IsNullOrEmpty(model.UserName))
					{
						model.UserName = CodeDecode.DeCodding(model.UserName);
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
					int result2 = 0;
					int.TryParse(num.ToString(), out result2);
					if (result2 == 0)
					{
						text = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId);
						list = null;
						serviceResultStatus = ServiceResultStatus.Error;
					}
					else
					{
						List<ApispSelectStockSupplyItems_Result> list3 = Enumerable.ToList<ApispSelectStockSupplyItems_Result>((IEnumerable<ApispSelectStockSupplyItems_Result>)cRMEntities.ApispSelectStockSupplyItems(model.ApiStockSupplyId, model.ApiStockSupplyItemId, currLangId, result, model.CenterId, model.CenterCode));
						if (list3 != null)
						{
							text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
							list = list3;
							serviceResultStatus = ServiceResultStatus.Success;
						}
						else
						{
							text = ResourceManager.GetMessage("ErrorNotFound", currLangId);
							list = null;
							serviceResultStatus = ServiceResultStatus.Fail;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			list = null;
			serviceResultStatus = ServiceResultStatus.Error;
			Public.InsExceptToElmah(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<List<ApispSelectStockSupplyItems_Result>>
		{
			Message = text,
			Data = list,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteStockSupplyItem(DeleteStockSupplyItemViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool flag = false;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				text = Messages.ErrorAccessAPILimited;
				flag = false;
				serviceResultStatus = ServiceResultStatus.Error;
			}
			else
			{
				cRMEntities = new CRMEntities();
				CommonClass commonClass = new CommonClass();
				ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
				if (apispSelectCrmsysSetting_Result == null)
				{
					text = Messages.ErrorInReadingSysSetting;
					flag = false;
					serviceResultStatus = ServiceResultStatus.Error;
				}
				else
				{
					int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					int.TryParse(model.LanguageId.ToString(), out var currLangId);
					if (currLangId <= 0)
					{
						currLangId = result;
					}
					List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
					string text2 = "fa-IR";
					ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
					if (apispSelectLanguages_Result != null)
					{
						text2 = apispSelectLanguages_Result.LanguageCollation;
					}
					if (!string.IsNullOrEmpty(model.Password))
					{
						model.Password = CodeDecode.DeCodding(model.Password);
					}
					if (!string.IsNullOrEmpty(model.UserName))
					{
						model.UserName = CodeDecode.DeCodding(model.UserName);
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
					int result2 = 0;
					int.TryParse(num.ToString(), out result2);
					if (result2 == 0)
					{
						text = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId);
						flag = false;
						serviceResultStatus = ServiceResultStatus.Error;
					}
					else if (model.ApiStockSupplyItemId > 0)
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteStockSupplyItem(model.ApiStockSupplyItemId));
						if (mct_Result != null)
						{
							if (mct_Result.Result > 0)
							{
								flag = true;
								text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
								serviceResultStatus = ServiceResultStatus.Success;
							}
							else if (mct_Result.Result == -2)
							{
								flag = false;
								text = ResourceManager.GetMessage("ErrorOrdIsFixed", currLangId);
								serviceResultStatus = ServiceResultStatus.Fail;
							}
							else
							{
								flag = false;
								text = ResourceManager.GetMessage("RedundancyMessage", currLangId);
								serviceResultStatus = ServiceResultStatus.Fail;
							}
						}
						else
						{
							flag = false;
							text = ResourceManager.GetMessage("RedundancyMessage", currLangId);
							serviceResultStatus = ServiceResultStatus.Fail;
						}
					}
					else
					{
						flag = false;
						text = ResourceManager.GetMessage("ErrorNotFound", currLangId);
						serviceResultStatus = ServiceResultStatus.Fail;
					}
				}
			}
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			flag = false;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<bool>
		{
			Message = text,
			Data = flag,
			Status = serviceResultStatus
		};
	}

	private string GetMessageResult(string errorMessage = "", string langCollation = "en-US", int langId = 1065)
	{
		string text = "";
		if (errorMessage.IndexOf("IsFixed|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("ErrorOrdIsFixed", langId);
		}
		if (errorMessage.IndexOf("No ReferUserId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += string.Format(ResourceManager.GetMessage("ErrorItemIsWrong", langId), ResourceManager.GetLabel("stsupReferUserId", langId));
		}
		if (errorMessage.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += string.Format(ResourceManager.GetMessage("ErrorItemIsWrong", langId), ResourceManager.GetLabel("stsupCompanyId", langId));
		}
		if (errorMessage.IndexOf("NO PrsId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += string.Format(ResourceManager.GetMessage("ErrorItemIsWrong", langId), ResourceManager.GetLabel("stsupCompanyPersonId", langId));
		}
		if (errorMessage.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += string.Format(ResourceManager.GetMessage("ErrorItemIsWrong", langId), ResourceManager.GetLabel("stsupProjectId", langId));
		}
		if (errorMessage.IndexOf("NO VerifyReqUserId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += string.Format(ResourceManager.GetMessage("ErrorItemIsWrong", langId), ResourceManager.GetLabel("stsupVerifierRequestId", langId));
		}
		if (errorMessage.IndexOf("NO VerifierUserId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("ErrorNotFoundVerifierUserId", langId);
		}
		if (errorMessage.IndexOf("NO WorkFlowId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("ErrorNotFoundWorkFlowId", langId);
		}
		if (errorMessage.IndexOf("NO PrintFormat|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("ErrorNotFoundPrintFormat", langId);
		}
		if (errorMessage.IndexOf("NO PreOrdId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("ErrorNotFoundPreOrdId", langId);
		}
		if (errorMessage.IndexOf("DupNumber|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("msgErrorStockSupplyNumberIsDuplicate", langId);
		}
		if (errorMessage.IndexOf("NO StockSupply|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("msgErrorStockSupplyNotFound", langId);
		}
		if (errorMessage.IndexOf("NO PrdId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("msgErrorPrdIdNotFound", langId);
		}
		if (errorMessage.IndexOf("NO UnitId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("msgErrorUnitIdNotFound", langId);
		}
		if (errorMessage.IndexOf("NO UnitIdI|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("msgErrorUnitIdNotFound", langId);
		}
		if (errorMessage.IndexOf("NO WhId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("msgErrorWHIdNotFound", langId);
		}
		if (errorMessage.IndexOf("NO ColorId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("msgErrorColorIdNotFound", langId);
		}
		if (errorMessage.IndexOf("NO Pord|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("msgErrorPordIdNotFound", langId);
		}
		if (errorMessage.IndexOf("NO PordI|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("msgErrorPordItemIdNotFound", langId);
		}
		if (errorMessage.IndexOf("NO BordId|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("msgErrorBordIdNotFound", langId);
		}
		if (errorMessage.IndexOf("NO BordI|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += ResourceManager.GetMessage("msgErrorBordItemIdNotFound", langId);
		}
		if (errorMessage.IndexOf("Error|", StringComparison.Ordinal) >= 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			text += errorMessage.Substring(errorMessage.IndexOf("Error|", StringComparison.Ordinal) + "Error|".Length);
		}
		return text;
	}
}
