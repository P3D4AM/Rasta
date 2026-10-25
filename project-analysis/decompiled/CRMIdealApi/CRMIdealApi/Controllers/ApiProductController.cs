using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.General.Utilities;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Common;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;

namespace CRMIdealApi.Controllers;

public class ApiProductController : ApiController
{
	private CRMEntities _db;

	[HttpPost]
	public ServiceResult<InsertProductResultViewModel> Insert(InsertProductViewModel model)
	{
		CRMEntities cRMEntities = _db;
		InsertProductResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<InsertProductResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (!string.IsNullOrWhiteSpace(model.ApiPrdSpecificationValues) && !VersionBuyer.PrdSpec)
			{
				return new ServiceResult<InsertProductResultViewModel>
				{
					Message = Messages.msgErrorNotHavePrdSpecModule,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (cRMEntities == null)
			{
				cRMEntities = new CRMEntities();
			}
			if (model.ApiPrdColorId <= 0)
			{
				model.ApiPrdColorId = null;
			}
			if (model.ApiPrdUnitId <= 0)
			{
				model.ApiPrdUnitId = null;
			}
			if (model.ApiPrdBarCodeTypeId <= 0)
			{
				model.ApiPrdBarCodeTypeId = null;
			}
			if (model.ApiPrdAutoNumBarCodeTypeId <= 0)
			{
				model.ApiPrdAutoNumBarCodeTypeId = null;
			}
			if (model.ApiPrdAutoCharBarCodeTypeId <= 0)
			{
				model.ApiPrdAutoCharBarCodeTypeId = null;
			}
			if (model.ApiPrdSHPStockManageTypeId <= 0)
			{
				model.ApiPrdSHPStockManageTypeId = null;
			}
			if (model.ApiPrdSHPOtherSupplierId <= 0)
			{
				model.ApiPrdSHPOtherSupplierId = null;
			}
			if (model.ApiPrdFirstGroupId <= 0)
			{
				model.ApiPrdFirstGroupId = null;
			}
			if (model.ApiPrdSecondGroupId <= 0)
			{
				model.ApiPrdSecondGroupId = null;
			}
			if (!model.FlagInsertDupPrdCode.HasValue)
			{
				model.FlagInsertDupPrdCode = false;
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<InsertProductResultViewModel>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string text = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!VersionBuyer.Products)
			{
				return new ServiceResult<InsertProductResultViewModel>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("Product", new CultureInfo(currLangId))),
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
				ServiceResult<InsertProductResultViewModel> serviceResult = new ServiceResult<InsertProductResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrEmpty(model.ApiPrdName))
			{
				ServiceResult<InsertProductResultViewModel> serviceResult = new ServiceResult<InsertProductResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdName", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.ApiPrdRowColor))
			{
				if (!model.ApiPrdRowColor.StartsWith("#") || (model.ApiPrdRowColor ?? "").Length != 7)
				{
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = string.Format(Messages.ResourceManager.GetString("ErrorFormat", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("ApiPrdRowColor", new CultureInfo(currLangId))) + Labels.ResourceManager.GetString("Sample", new CultureInfo(currLangId)) + ": #cacaca",
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				model.ApiPrdRowColor = Public.HexToColor(model.ApiPrdRowColor);
			}
			if (!string.IsNullOrEmpty(model.ApiPrdSHPDescription))
			{
				model.ApiPrdSHPDescription = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div>" + model.ApiPrdSHPDescription + "</div>";
			}
			if (!string.IsNullOrEmpty(model.ApiPrdSHPDescriptionII))
			{
				model.ApiPrdSHPDescriptionII = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div>" + model.ApiPrdSHPDescriptionII + "</div>";
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedProdcutId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedProductCode", "");
			ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertProducts(model.UserName, model.Password, model.ApiPrdCode, model.ApiPrdName, model.ApiPrdLatinName, model.ApiPrdType, model.ApiPrdDesign, model.ApiPrdSize, model.ApiPrdColorId, model.ApiPrdUnitId, model.ApiPrdMinQty, model.ApiPrdMaxQty, model.ApiPrdSleepDay, model.ApiPrdFirstSerial, model.ApiPrdSecondSerial, model.ApiPrdThirdSerial, model.ApiPrdFirstBarcode, model.ApiPrdSecondBarcode, model.ApiPrdThirdBarcode, model.ApiPrdDescription, model.ApiPrdBarCode, model.ApiPrdBarCodeTypeId, model.ApiPrdAutoNumBarcode, model.ApiPrdAutoNumBarCodeTypeId, model.ApiPrdAutoCharBarcode, model.ApiPrdAutoCharBarCodeTypeId, model.ApiPrdModel, model.ApiPrdInactiveInSale, model.ApiPrdInactiveInBuy, model.ApiPrdSHPIsActive, model.ApiPrdSHPTitle, model.ApiPrdSHPCode, model.ApiPrdSHPModel, model.ApiPrdSHPDescription, model.ApiPrdSHPDescriptionII, model.ApiPrdSHPStockManageTypeId, model.ApiPrdSHPStockManualyCount, model.ApiPrdSHPHiddenPriceInNoStock, model.ApiPrdSHPSelfSupplier, model.ApiPrdSHPOtherSupplierId, model.ApiPrdFirstGroupId, model.ApiPrdFirstGroupCode, model.ApiPrdSecondGroupId, model.ApiPrdSecondGroupCode, model.FlagInsertDupPrdCode, userId, value2, value, registerDatePersian, appType, result, objectParameter, objectParameter2, objectParameter3, model.ApiprdValidity, model.ApiprdValidityDay, model.ApiprdValidityTime, model.ApiprdValidityCounting, model.ApiprdValidityCountingNum, model.ApiprdValidityCountingMin, model.ApiprdValidityCountingNumIsActive, model.ApiprdValidityCountingNumNeedOrder, model.ApiprdValidityCountingNumDefaultVal, model.ApiprdValidityCountingNumNoCheckRemain, model.ApiprdValidityCountingMinIsActive, model.ApiprdValidityCountingMinNeedOrder, model.ApiprdValidityCountingMinDefaultVal, model.ApiprdValidityCountingMinNoCheckRemain, model.ApiprdValidityUpdatePrjRemindDateAfterIssueOrd, model.ApiprdValidityControlFOPrjTitleGroup, model.ApiprdValidityControlFOPrjTitleGroupIds, model.ApiprdValidityControlFODeActivePrjTitleGroupDesc, model.ApiPrdLinkAccPrdId, model.ApiPrdLinkAccPrdCode, model.ApiPrdLinkAccPrdIdStr, model.ApiPrdLinkAccPrdGroupIdStr, model.ApiPrdLinkAccFirstTransferDate, model.ApiPrdLinkAccLastTransferDate, model.ApiPrdLinkAccData, model.ApiPrdDoneTimeMin, model.ApiPrdLocation, model.ApiPrdRowColor, model.ApiPrdWeight, model.ApiPrdSHPQtyFromTracing, model.ApiPrdSHPShowLinkedPrd, model.ApiPrdSpecificationValues, model.ApiPrdCommissionDisable, model.ApiPrdCommissionPercentRate, model.ApiPrdIsDefault, model.ApiPrdInActive, model.ApiPrdKind, model.ApiPrdDefQuantity, model.ApiPrdJustDefQuantity, model.ApiPrdMinQuantity, model.ApiPrdMaxQuantity, model.ApiPrdManufacturerName, model.ApiPrdManufacturerCode, model.ApiPrdIVRLink, model.ApiPrdIVRLinkRule, model.ApiPrdIVRLinkDesc, model.ApiPrdUnitIdI, model.ApiPrdUnitIRate, model.ApiPrdUnitIRateCalcAuto, model.ApiPrdQtyNoFCR, model.ApiPrdMustFullTracingCode, model.ApiPrdSingleItem, model.ApiPrdScore, model.ApiPrdNickname, model.ApiPrdNoDiscount, model.ApiPrdDiscountMax, model.ApiPrdTaxable, model.ApiPrdTaxableIndex, model.ApiPrdCashBack, model.ApiPrdCashBackIndex, model.ApiPrdModuleName, model.ApiTspPrdIndentify, model.ApiTspPrdName, model.ApiPrdAutoCalcIndexed, model.ApiPrdAutoCalcPordPrdId, model.ApiPrdAutoCalcPriceFromOrdItemRate, model.ApiPrdAutoCalcDisabled, model.ApiPrdAutoCalcPriceFromOrdItemPrdGroups, model.ApiPrdAutoCalcDynamicRate, model.ApiPrdAutoCalcInflationLastDurationRate, model.ApiPrdAutoCalcIndexedPrdId, model.ApiPrdAutoCalcPordVerifyAfterIssue, model.ApiPrdAutoCalcPordReferUser, model.ApiPrdAutoCalcPordExpireDynamicRate, model.ApiPrdAutoCalcPordExpireDay, model.ApiPrdAutoCalcPordItemDesc, model.ApiPrdAutoCalcPordTaxDetectFromLastOrd, model.ApiPrdAutoCalcPordTaxDefSettingId, model.ApiPrdAutoCalcPordNoTaxDefSettingId, model.ApiPrdAutoCalcPordPrjTitleGroupId, model.ApiPrdAutoCalcPordPrjTitleId, model.ApiPrdAutoCalcPordPrjPostFix, model.ApiPrdAutoCalcPordPrjCnvsStatusGroupId, model.ApiPrdAutoCalcPordPrjFOCmpCanSee, model.ApiPrdAutoCalcPordPrjIsTicket, model.ApiPrdAutoCalcPordPrjUsedType, model.ApiPrdAutoCalcPordAddCnvs, model.ApiPrdAutoCalcPordCnvsTopicId, model.ApiPrdAutoCalcPordCnvsDesc, model.ApiPrdAutoCalcPordCnvsReferUser, model.ApiPrdAutoCalcPordCnvsStatusId, model.ApiPrdAutoCalcPordCnvsStatusResultId, model.ApiPrdAutoCalcPordCnvsRemindDay, model.ApiPrdAutoCalcIssueOrdFromIndexed, model.ApiPrdAutoCalcIssueOrdFromIndexedOprId, model.ApiPrdOrdIssueSetSetting, model.ApiPrdOrdIssuePrjTitleGroupId, model.ApiPrdOrdIssuePrjTitleId, model.ApiPrdOrdIssuePrjPostFix, model.ApiPrdOrdIssuePrjCnvsStatusGroupId, model.ApiPrdOrdIssuePrjRemindDay, model.ApiPrdOrdIssuePrjFOCmpCanSee, model.ApiPrdOrdIssuePrjIsTicket, model.ApiPrdOrdIssuePrjUsedType, model.ApiPrdOrdIssueUpdateCmpTypeId, model.ApiPrdOrdIssueUpdateCmpGroupII, model.ApiPrdOrdIssueUpdateTaxCmpGroupIdII, model.ApiPrdOrdIssueUpdateNoTaxCmpGroupIdII, model.ApiPrdOrdIssueDateToCmpEffectiveDate, model.ApiPrdAutoCalcIndexBreakDay, model.ApiPrdAutoCalcDynamicRateJustCompleteDuration, model.ApiPrdAutoCalcInflationLastYearNumChange, model.ApiPrdAutoCalcPriceFromOrdItemInBreak, model.ApiPrdAutoCalcPriceFromIndex, model.ApiPrdAutoCalcInflationLastDuration, model.ApiPrdAutoCalcInflationLastYearNumChangeRate, model.ApiPrdAutoCalcPriceFromIndexRate, model.ApiPrdAutoCalcPriceFromOrdItem, model.ApiPrdAutoCalcPriceFromOrdItemAfterBreak, model.ApiPrdCanChangePrice, model.ApiPrdSaleCenterIds, model.ApiPrdUnitIdII, model.ApiPrdUnitIIRate, model.ApiPrdUnitIIRateCalcAuto));
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<InsertProductResultViewModel>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
			{
				string text2 = "";
				string text3 = objectParameter3.Value.ToString();
				if (text3.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not FG|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdFirstGroup", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not SG|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdSecondGroup", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Conflict SFG", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + MyResource.GetResourceString("ErrorInConsistencyPrdFSGroup", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("DupPrdCode=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text3.Split(new char[1] { '=' });
					string text4 = "";
					if (array != null && array.Length == 2)
					{
						text4 = array[1] ?? "";
					}
					text4 = ((!string.IsNullOrEmpty(text4)) ? text4.TrimEnd(new char[1] { '|' }) : "");
					text2 = text2 + string.Format(MyResource.GetResourceString("ErrorPrdCodeIsDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text4) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdUnitIdI|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdUnitIdI", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdAutoCalcPordPrdId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordPrdId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdAutoCalcIndexedPrdId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcIndexedPrdId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdAutoCalcPordTaxDefSettingId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordTaxDefSettingId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdAutoCalcPordNoTaxDefSettingId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordNoTaxDefSettingId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdAutoCalcPordPrjTitleGroupId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordPrjTitleGroupId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdAutoCalcPordPrjTitleId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordPrjTitleId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdAutoCalcPordPrjCnvsStatusGroupId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordPrjCnvsStatusGroupId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdAutoCalcPordCnvsTopicId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordCnvsTopicId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdAutoCalcPordCnvsStatusResultId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordCnvsStatusResultId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdAutoCalcIssueOrdFromIndexedOprId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcIssueOrdFromIndexedOprId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdOrdIssuePrjTitleGroupId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssuePrjTitleGroupId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdOrdIssuePrjTitleId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssuePrjTitleId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdOrdIssuePrjCnvsStatusGroupId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssuePrjCnvsStatusGroupId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdOrdIssueUpdateCmpTypeId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssueUpdateCmpTypeId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdOrdIssueUpdateTaxCmpGroupIdII|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssueUpdateTaxCmpGroupIdII", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdOrdIssueUpdateNoTaxCmpGroupIdII|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssueUpdateNoTaxCmpGroupIdII", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdSaleCenterIds|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdSaleCenterIds", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not PrdUnitIdII|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdUnitIdII", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text2 += resourceString2;
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3 == "SpecErrJson")
				{
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = Messages.SpecificationJsonErrorFormat,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = text3,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (objectParameter2 == null || objectParameter2.Value.ToString() == "0")
				{
					return new ServiceResult<InsertProductResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				InsertProductResultViewModel insertProductResultViewModel = new InsertProductResultViewModel();
				insertProductResultViewModel.ProductId = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				insertProductResultViewModel.ProductCode = ((objectParameter2.Value != null && !string.IsNullOrEmpty(objectParameter2.Value.ToString())) ? objectParameter2.Value.ToString() : "");
				data = insertProductResultViewModel;
				message = MyResource.GetResourceString("SuccessDoneRegister", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text5 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text5 = text5 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text5)) ? (" (" + text5 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			if (cRMEntities != null && _db == null)
			{
				cRMEntities.Dispose();
			}
		}
		return new ServiceResult<InsertProductResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> Update(UpdateProductViewModel model)
	{
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			if (!model.FlagUpdateDupPrdCode.HasValue)
			{
				model.FlagUpdateDupPrdCode = false;
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
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
			string text = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiProductId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.ApiPrdRowColor))
			{
				if (!model.ApiPrdRowColor.StartsWith("#") || (model.ApiPrdRowColor ?? "").Length != 7)
				{
					return new ServiceResult<int>
					{
						Message = string.Format(Messages.ResourceManager.GetString("ErrorFormat", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("ApiPrdRowColor", new CultureInfo(currLangId))) + Labels.ResourceManager.GetString("Sample", new CultureInfo(currLangId)) + ": #cacaca",
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				model.ApiPrdRowColor = Public.HexToColor(model.ApiPrdRowColor);
			}
			if (!string.IsNullOrEmpty(model.ApiPrdSHPDescription))
			{
				model.ApiPrdSHPDescription = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div>" + model.ApiPrdSHPDescription + "</div>";
			}
			if (!string.IsNullOrEmpty(model.ApiPrdSHPDescriptionII))
			{
				model.ApiPrdSHPDescriptionII = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div>" + model.ApiPrdSHPDescriptionII + "</div>";
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num2 = cRMEntities.ApispUpdateProducts(model.ApiProductId, model.ApiPrdGroupId, model.ApiPrdCode, model.ApiPrdName, model.ApiPrdLatinName, model.ApiPrdType, model.ApiPrdDesign, model.ApiPrdSize, model.ApiPrdColorId, model.ApiPrdUnitId, model.ApiPrdMinQty, model.ApiPrdMaxQty, model.ApiPrdSleepDay, model.ApiPrdFirstSerial, model.ApiPrdSecondSerial, model.ApiPrdThirdSerial, model.ApiPrdFirstBarcode, model.ApiPrdSecondBarcode, model.ApiPrdThirdBarcode, model.ApiPrdDescription, prdBarCode: model.ApiPrdBarCode, prdBarCodeTypeId: model.ApiPrdBarCodeTypeId, prdAutoNumBarcode: model.ApiPrdAutoNumBarcode, prdAutoNumBarCodeTypeId: model.ApiPrdAutoNumBarCodeTypeId, prdAutoCharBarcode: model.ApiPrdAutoCharBarcode, prdAutoCharBarCodeTypeId: model.ApiPrdAutoCharBarCodeTypeId, prdModel: model.ApiPrdModel, prdInactiveInSale: model.ApiPrdInactiveInSale, prdInactiveInBuy: model.ApiPrdInactiveInBuy, prdCommissionDisable: model.ApiPrdCommissionDisable, prdCommissionPercentRate: model.ApiPrdCommissionPercentRate, prdSHPIsActive: model.ApiPrdSHPIsActive, prdSHPTitle: model.ApiPrdSHPTitle, prdSHPCode: model.ApiPrdSHPCode, prdSHPModel: model.ApiPrdSHPModel, prdSHPDescription: model.ApiPrdSHPDescription, prdSHPDescriptionII: model.ApiPrdSHPDescriptionII, prdSHPStockManageTypeId: model.ApiPrdSHPStockManageTypeId, prdSHPStockManualyCount: model.ApiPrdSHPStockManualyCount, prdSHPHiddenPriceInNoStock: model.ApiPrdSHPHiddenPriceInNoStock, prdSHPSelfSupplier: model.ApiPrdSHPSelfSupplier, prdSHPOtherSupplierId: model.ApiPrdSHPOtherSupplierId, orderView: model.ApiPrdOrderView, flagUpdateDupPrdCode: model.FlagUpdateDupPrdCode, userId: userId, fPId: 1, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: currLangId, defaultLanguageID: result, errorMessage: objectParameter, prdValidity: model.ApiprdValidity, prdValidityDay: model.ApiprdValidityDay, prdValidityTime: model.ApiprdValidityTime, prdValidityCounting: model.ApiprdValidityCounting, prdValidityCountingNum: model.ApiprdValidityCountingNum, prdValidityCountingMin: model.ApiprdValidityCountingMin, prdValidityCountingNumIsActive: model.ApiprdValidityCountingNumIsActive, prdValidityCountingNumNeedOrder: model.ApiprdValidityCountingNumNeedOrder, prdValidityCountingNumDefaultVal: model.ApiprdValidityCountingNumDefaultVal, prdValidityCountingNumNoCheckRemain: model.ApiprdValidityCountingNumNoCheckRemain, prdValidityCountingMinIsActive: model.ApiprdValidityCountingMinIsActive, prdValidityCountingMinNeedOrder: model.ApiprdValidityCountingMinNeedOrder, prdValidityCountingMinDefaultVal: model.ApiprdValidityCountingMinDefaultVal, prdValidityCountingMinNoCheckRemain: model.ApiprdValidityCountingMinNoCheckRemain, prdValidityUpdatePrjRemindDateAfterIssueOrd: model.ApiprdValidityUpdatePrjRemindDateAfterIssueOrd, prdValidityControlFOPrjTitleGroup: model.ApiprdValidityControlFOPrjTitleGroup, prdValidityControlFOPrjTitleGroupIds: model.ApiprdValidityControlFOPrjTitleGroupIds, prdValidityControlFODeActivePrjTitleGroupDesc: model.ApiprdValidityControlFODeActivePrjTitleGroupDesc, prdLinkAccPrdId: model.ApiPrdLinkAccPrdId, prdLinkAccPrdCode: model.ApiPrdLinkAccPrdCode, prdLinkAccPrdIdStr: model.ApiPrdLinkAccPrdIdStr, prdLinkAccPrdGroupIdStr: model.ApiPrdLinkAccPrdGroupIdStr, prdLinkAccFirstTransferDate: model.ApiPrdLinkAccFirstTransferDate, prdLinkAccLastTransferDate: model.ApiPrdLinkAccLastTransferDate, prdLinkAccData: model.ApiPrdLinkAccData, prdDoneTimeMin: model.ApiPrdDoneTimeMin, prdLocation: model.ApiPrdLocation, prdRowColor: model.ApiPrdRowColor, prdWeight: model.ApiPrdWeight, prdSHPQtyFromTracing: model.ApiPrdSHPQtyFromTracing, prdSHPShowLinkedPrd: model.ApiPrdSHPShowLinkedPrd, prdSpecificationValues: model.ApiPrdSpecificationValues, prdIsDefault: model.ApiPrdIsDefault, prdInActive: model.ApiPrdInActive, prdKind: model.ApiPrdKind, prdDefQuantity: model.ApiPrdDefQuantity, prdJustDefQuantity: model.ApiPrdJustDefQuantity, prdMinQuantity: model.ApiPrdMinQuantity, prdMaxQuantity: model.ApiPrdMaxQuantity, prdManufacturerName: model.ApiPrdManufacturerName, prdManufacturerCode: model.ApiPrdManufacturerCode, prdIVRLink: model.ApiPrdIVRLink, prdIVRLinkRule: model.ApiPrdIVRLinkRule, prdIVRLinkDesc: model.ApiPrdIVRLinkDesc, prdUnitIdI: model.ApiPrdUnitIdI, prdUnitIRate: model.ApiPrdUnitIRate, prdUnitIRateCalcAuto: model.ApiPrdUnitIRateCalcAuto, prdQtyNoFCR: model.ApiPrdQtyNoFCR, prdMustFullTracingCode: model.ApiPrdMustFullTracingCode, prdSingleItem: model.ApiPrdSingleItem, prdNickname: model.ApiPrdNickname, prdNoDiscount: model.ApiPrdNoDiscount, prdDiscountMax: model.ApiPrdDiscountMax, prdTaxable: model.ApiPrdTaxable, prdTaxableIndex: model.ApiPrdTaxableIndex, prdCashBack: model.ApiPrdCashBack, prdCashBackIndex: model.ApiPrdCashBackIndex, prdModuleName: model.ApiPrdModuleName, tspPrdIndentify: model.ApiTspPrdIndentify, tspPrdName: model.ApiTspPrdName, prdAutoCalcIndexed: model.ApiPrdAutoCalcIndexed, prdAutoCalcPordPrdId: model.ApiPrdAutoCalcPordPrdId, prdAutoCalcPriceFromOrdItemRate: model.ApiPrdAutoCalcPriceFromOrdItemRate, prdAutoCalcDisabled: model.ApiPrdAutoCalcDisabled, prdAutoCalcPriceFromOrdItemPrdGroups: model.ApiPrdAutoCalcPriceFromOrdItemPrdGroups, prdAutoCalcDynamicRate: model.ApiPrdAutoCalcDynamicRate, prdAutoCalcInflationLastDurationRate: model.ApiPrdAutoCalcInflationLastDurationRate, prdAutoCalcIndexedPrdId: model.ApiPrdAutoCalcIndexedPrdId, prdAutoCalcPordVerifyAfterIssue: model.ApiPrdAutoCalcPordVerifyAfterIssue, prdAutoCalcPordReferUser: model.ApiPrdAutoCalcPordReferUser, prdAutoCalcPordExpireDynamicRate: model.ApiPrdAutoCalcPordExpireDynamicRate, prdAutoCalcPordExpireDay: model.ApiPrdAutoCalcPordExpireDay, prdAutoCalcPordItemDesc: model.ApiPrdAutoCalcPordItemDesc, prdAutoCalcPordTaxDetectFromLastOrd: model.ApiPrdAutoCalcPordTaxDetectFromLastOrd, prdAutoCalcPordTaxDefSettingId: model.ApiPrdAutoCalcPordTaxDefSettingId, prdAutoCalcPordNoTaxDefSettingId: model.ApiPrdAutoCalcPordNoTaxDefSettingId, prdAutoCalcPordPrjTitleGroupId: model.ApiPrdAutoCalcPordPrjTitleGroupId, prdAutoCalcPordPrjTitleId: model.ApiPrdAutoCalcPordPrjTitleId, prdAutoCalcPordPrjPostFix: model.ApiPrdAutoCalcPordPrjPostFix, prdAutoCalcPordPrjCnvsStatusGroupId: model.ApiPrdAutoCalcPordPrjCnvsStatusGroupId, prdAutoCalcPordPrjFOCmpCanSee: model.ApiPrdAutoCalcPordPrjFOCmpCanSee, prdAutoCalcPordPrjIsTicket: model.ApiPrdAutoCalcPordPrjIsTicket, prdAutoCalcPordPrjUsedType: model.ApiPrdAutoCalcPordPrjUsedType, prdAutoCalcPordAddCnvs: model.ApiPrdAutoCalcPordAddCnvs, prdAutoCalcPordCnvsTopicId: model.ApiPrdAutoCalcPordCnvsTopicId, prdAutoCalcPordCnvsDesc: model.ApiPrdAutoCalcPordCnvsDesc, prdAutoCalcPordCnvsReferUser: model.ApiPrdAutoCalcPordCnvsReferUser, prdAutoCalcPordCnvsStatusId: model.ApiPrdAutoCalcPordCnvsStatusId, prdAutoCalcPordCnvsStatusResultId: model.ApiPrdAutoCalcPordCnvsStatusResultId, prdAutoCalcPordCnvsRemindDay: model.ApiPrdAutoCalcPordCnvsRemindDay, prdAutoCalcIssueOrdFromIndexed: model.ApiPrdAutoCalcIssueOrdFromIndexed, prdAutoCalcIssueOrdFromIndexedOprId: model.ApiPrdAutoCalcIssueOrdFromIndexedOprId, prdOrdIssueSetSetting: model.ApiPrdOrdIssueSetSetting, prdOrdIssuePrjTitleGroupId: model.ApiPrdOrdIssuePrjTitleGroupId, prdOrdIssuePrjTitleId: model.ApiPrdOrdIssuePrjTitleId, prdOrdIssuePrjPostFix: model.ApiPrdOrdIssuePrjPostFix, prdOrdIssuePrjCnvsStatusGroupId: model.ApiPrdOrdIssuePrjCnvsStatusGroupId, prdOrdIssuePrjRemindDay: model.ApiPrdOrdIssuePrjRemindDay, prdOrdIssuePrjFOCmpCanSee: model.ApiPrdOrdIssuePrjFOCmpCanSee, prdOrdIssuePrjIsTicket: model.ApiPrdOrdIssuePrjIsTicket, prdOrdIssuePrjUsedType: model.ApiPrdOrdIssuePrjUsedType, prdOrdIssueUpdateCmpTypeId: model.ApiPrdOrdIssueUpdateCmpTypeId, prdOrdIssueUpdateCmpGroupII: model.ApiPrdOrdIssueUpdateCmpGroupII, prdOrdIssueUpdateTaxCmpGroupIdII: model.ApiPrdOrdIssueUpdateTaxCmpGroupIdII, prdOrdIssueUpdateNoTaxCmpGroupIdII: model.ApiPrdOrdIssueUpdateNoTaxCmpGroupIdII, prdOrdIssueDateToCmpEffectiveDate: model.ApiPrdOrdIssueDateToCmpEffectiveDate, prdAutoCalcIndexBreakDay: model.ApiPrdAutoCalcIndexBreakDay, prdAutoCalcDynamicRateJustCompleteDuration: model.ApiPrdAutoCalcDynamicRateJustCompleteDuration, prdAutoCalcInflationLastYearNumChange: model.ApiPrdAutoCalcInflationLastYearNumChange, prdAutoCalcPriceFromOrdItemInBreak: model.ApiPrdAutoCalcPriceFromOrdItemInBreak, prdAutoCalcPriceFromIndex: model.ApiPrdAutoCalcPriceFromIndex, prdAutoCalcInflationLastDuration: model.ApiPrdAutoCalcInflationLastDuration, prdAutoCalcInflationLastYearNumChangeRate: model.ApiPrdAutoCalcInflationLastYearNumChangeRate, prdAutoCalcPriceFromIndexRate: model.ApiPrdAutoCalcPriceFromIndexRate, prdAutoCalcPriceFromOrdItem: model.ApiPrdAutoCalcPriceFromOrdItem, prdAutoCalcPriceFromOrdItemAfterBreak: model.ApiPrdAutoCalcPriceFromOrdItemAfterBreak, prdCanChangePrice: model.ApiPrdCanChangePrice, prdSaleCenterIds: model.ApiPrdSaleCenterIds, prdUnitIdII: model.ApiPrdUnitIdII, prdUnitIIRate: model.ApiPrdUnitIIRate, prdUnitIIRateCalcAuto: model.ApiPrdUnitIIRateCalcAuto);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 < 0 && objectParameter.Value == null)
			{
				return new ServiceResult<int>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
			{
				string text2 = "";
				string text3 = objectParameter.Value.ToString();
				if (text3.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not FG|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdFirstGroup", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Not SG|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdSecondGroup", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Conflict SFG", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + MyResource.GetResourceString("ErrorInConsistencyPrdFSGroup", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("DupPrdCode=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text3.Split(new char[1] { '=' });
					string text4 = "";
					if (array != null && array.Length == 2)
					{
						text4 = array[1] ?? "";
					}
					text4 = ((!string.IsNullOrEmpty(text4)) ? text4.TrimEnd(new char[1] { '|' }) : "");
					text2 = text2 + string.Format(MyResource.GetResourceString("ErrorPrdCodeIsDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text4) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdGroupID|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdSecondGroup", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdColorId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdColor", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdUnitId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdUnit", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdSHPOtherSupplierId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdSHPOtherSupplier", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdUnitIdI|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdUnitIdI", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdAutoCalcPordPrdId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordPrdId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdAutoCalcIndexedPrdId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcIndexedPrdId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdAutoCalcPordTaxDefSettingId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordTaxDefSettingId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdAutoCalcPordNoTaxDefSettingId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordNoTaxDefSettingId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdAutoCalcPordPrjTitleGroupId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordPrjTitleGroupId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdAutoCalcPordPrjTitleId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordPrjTitleId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdAutoCalcPordPrjCnvsStatusGroupId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordPrjCnvsStatusGroupId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdAutoCalcPordCnvsTopicId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordCnvsTopicId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdAutoCalcPordCnvsStatusResultId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcPordCnvsStatusResultId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdAutoCalcIssueOrdFromIndexedOprId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdAutoCalcIssueOrdFromIndexedOprId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdOrdIssuePrjTitleGroupId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssuePrjTitleGroupId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdOrdIssuePrjTitleId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssuePrjTitleId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdOrdIssuePrjCnvsStatusGroupId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssuePrjCnvsStatusGroupId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdOrdIssueUpdateCmpTypeId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssueUpdateCmpTypeId", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdOrdIssueUpdateTaxCmpGroupIdII|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssueUpdateTaxCmpGroupIdII", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdOrdIssueUpdateNoTaxCmpGroupIdII|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdOrdIssueUpdateNoTaxCmpGroupIdII", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdSaleCenterIds|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdSaleCenterIds", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No PrdUnitIdII|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsWrong", new CultureInfo(text)), Labels.ResourceManager.GetString("PrdUnitIdII", new CultureInfo(text))) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text2 += resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3 == "SpecErrJson")
				{
					return new ServiceResult<int>
					{
						Message = Messages.SpecificationJsonErrorFormat,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					return new ServiceResult<int>
					{
						Message = text3,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text5 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text5 = text5 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text5)) ? (" (" + text5 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<List<ApispSelectProducts_Result>> Select(SelectProductViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectProducts_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectProducts_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectProducts_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<List<ApispSelectProducts_Result>> serviceResult = new ServiceResult<List<ApispSelectProducts_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			try
			{
				if (!string.IsNullOrEmpty(model.FromRegisterDate))
				{
					model.FromRegisterDate = model.FromRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.FromRegisterDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.FromRegisterDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi = PersianDate.GetShamsi2Miladi(model.FromRegisterDate);
						value = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<List<ApispSelectProducts_Result>> serviceResult = new ServiceResult<List<ApispSelectProducts_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectProducts_Result>> result3 = serviceResult;
				cRMEntities?.Dispose();
				return result3;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ToRegisterDate))
				{
					model.ToRegisterDate = model.ToRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value2 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.ToRegisterDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.ToRegisterDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi2 = PersianDate.GetShamsi2Miladi(model.ToRegisterDate);
						value2 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi2) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<List<ApispSelectProducts_Result>> serviceResult = new ServiceResult<List<ApispSelectProducts_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectProducts_Result>> result4 = serviceResult;
				cRMEntities?.Dispose();
				return result4;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.FromFirstRegisterDate))
				{
					model.FromFirstRegisterDate = model.FromFirstRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value3 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.FromFirstRegisterDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.FromFirstRegisterDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi3 = PersianDate.GetShamsi2Miladi(model.FromFirstRegisterDate);
						value3 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi3) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				ServiceResult<List<ApispSelectProducts_Result>> serviceResult = new ServiceResult<List<ApispSelectProducts_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectProducts_Result>> result5 = serviceResult;
				cRMEntities?.Dispose();
				return result5;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ToFirstRegisterDate))
				{
					model.ToFirstRegisterDate = model.ToFirstRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value4 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.ToFirstRegisterDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.ToFirstRegisterDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi4 = PersianDate.GetShamsi2Miladi(model.ToFirstRegisterDate);
						value4 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi4) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				ServiceResult<List<ApispSelectProducts_Result>> serviceResult = new ServiceResult<List<ApispSelectProducts_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectProducts_Result>> result6 = serviceResult;
				cRMEntities?.Dispose();
				return result6;
			}
			model.PageSize = ((model.PageNumber.HasValue && model.PageNumber > 0 && (!model.PageSize.HasValue || model.PageSize == 0)) ? new int?(20) : model.PageSize);
			List<ApispSelectProducts_Result> list2 = Enumerable.ToList<ApispSelectProducts_Result>((IEnumerable<ApispSelectProducts_Result>)cRMEntities.ApispSelectProducts(model.ApiProductId, model.ApiPrdGroupId, model.ApiPrdCode, (!string.IsNullOrEmpty(model.FromRegisterDate)) ? new DateTime?(value) : null, (!string.IsNullOrEmpty(model.ToRegisterDate)) ? new DateTime?(value2) : null, (!string.IsNullOrEmpty(model.FromFirstRegisterDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(model.ToFirstRegisterDate)) ? new DateTime?(value4) : null, currLangId, result, model.PageNumber, model.PageSize));
			if (list2 != null && list2.Count > 0)
			{
				foreach (ApispSelectProducts_Result item in list2)
				{
					if (!string.IsNullOrWhiteSpace(item.ApiPrdRowColor))
					{
						item.ApiPrdRowColor = Public.TColorToHex(item.ApiPrdRowColor);
					}
				}
			}
			if (list2 != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectProducts_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteProductViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<bool> serviceResult = new ServiceResult<bool>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiProductId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteProduct(model.ApiProductId));
				if (mct_Result != null)
				{
					if (mct_Result.Result > 0)
					{
						data = true;
						message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = false;
						message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = false;
					message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				data = false;
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectProductFirstGroup_Result>> SelectProductFirstGroup(SelectProductFirstGroupViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectProductFirstGroup_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectProductFirstGroup_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectProductFirstGroup_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<List<ApispSelectProductFirstGroup_Result>> serviceResult = new ServiceResult<List<ApispSelectProductFirstGroup_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectProductFirstGroup_Result> list2 = Enumerable.ToList<ApispSelectProductFirstGroup_Result>((IEnumerable<ApispSelectProductFirstGroup_Result>)cRMEntities.ApispSelectProductFirstGroup(model.ApiFirstGroupId, model.ApiFirstGroupCode, currLangId, result));
			if (list2 != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectProductFirstGroup_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> InsertProductFirstGroup(InsertProductFirstGroupViewModel model)
	{
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertProductFirstGroup(model.ApiFGCode, model.ApiFGName, model.ApiFGDescription, model.ApiFGNameEn, model.ApiFGInactiveInSale, model.ApiFGInactiveInBuy, model.ApiPrdGroupMustExistInPreOrder, model.ApiFGOrderView, model.ApiFGSHPIsActive, model.ApiFGSHPName, value2, appType, model.LanguageId, userId, value, registerDatePersian, objectParameter, objectParameter2, model.ApiFGLinkAccGroupId, model.ApiFGLinkAccGroupCode, model.ApiFGLinkAccGroupIdStr, model.ApiFGLinkAccGroupName, model.ApiFGLinkAccFirstTransferDate, model.ApiFGLinkAccLastTransferDate, model.ApiFGLinkAccData, model.ApiTspFGIndentify, model.ApiTspFGName));
			string @string = Messages.ResourceManager.GetString("ErrorDoneOperationTryAgain", new CultureInfo(name));
			string string2 = Messages.ResourceManager.GetString("ErrorTryAgain", new CultureInfo(name));
			int result2 = 0;
			int.TryParse(objectParameter.Value.ToString(), out result2);
			if (result2 <= 0)
			{
				return new ServiceResult<int>
				{
					Message = @string.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
			{
				string text = "";
				string text2 = objectParameter2.Value.ToString();
				if (text2.IndexOf("NO FGName|", StringComparison.Ordinal) >= 0)
				{
					text = text + string.Format(Messages.ResourceManager.GetString("ErrorItemIsNotEntered", new CultureInfo(name)), Labels.ResourceManager.GetString("PrdFirstGroup", new CultureInfo(name))) + string2;
					return new ServiceResult<int>
					{
						Message = text.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text2.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text += string2;
					return new ServiceResult<int>
					{
						Message = string2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					return new ServiceResult<int>
					{
						Message = @string.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				data = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				message = Messages.ResourceManager.GetString("SuccessDoneRegister", new CultureInfo(name));
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> UpdateProductFirstGroup(UpdateProductFirstGroupViewModel model)
	{
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			if (model.ApiPrdFirstGroupID <= 0)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ResourceManager.GetString("ErrorNotFound", new CultureInfo(name)),
					Data = 0,
					Status = ServiceResultStatus.Fail
				};
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num = cRMEntities.ApispUpdateProductFirstGroup(model.ApiPrdFirstGroupID, model.ApiFGCode, model.ApiFGName, model.ApiFGDescription, model.ApiFGNameEn, model.ApiFGInactiveInSale, model.ApiFGInactiveInBuy, model.ApiPrdGroupMustExistInPreOrder, model.ApiFGOrderView, model.ApiFGSHPIsActive, model.ApiFGSHPName, model.UserId, value, registerDatePersian, value2, appType, model.LanguageId, result, objectParameter, model.ApiFGLinkAccGroupId, model.ApiFGLinkAccGroupCode, model.ApiFGLinkAccGroupIdStr, model.ApiFGLinkAccGroupName, model.ApiFGLinkAccFirstTransferDate, model.ApiFGLinkAccLastTransferDate, model.ApiFGLinkAccData, model.ApiTspFGIndentify, model.ApiTspFGName);
			string @string = Messages.ResourceManager.GetString("ErrorDoneOperationTryAgain", new CultureInfo(name));
			string string2 = Messages.ResourceManager.GetString("ErrorTryAgain", new CultureInfo(name));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 < 0 && objectParameter.Value == null)
			{
				return new ServiceResult<int>
				{
					Message = @string.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
			{
				string text = "";
				string text2 = objectParameter.Value.ToString();
				if (text2.IndexOf("NO FGName|", StringComparison.Ordinal) >= 0)
				{
					text = text + string.Format(Messages.ResourceManager.GetString("ErrorItemIsNotEntered", new CultureInfo(name)), Messages.ResourceManager.GetString("PrdFirstGroup", new CultureInfo(name))) + string2;
					return new ServiceResult<int>
					{
						Message = text.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text2.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text += string2;
					return new ServiceResult<int>
					{
						Message = string2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = Messages.ResourceManager.GetString("SuccessDoneRegister", new CultureInfo(name));
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteProductFirstGroup(DeleteProductFirstGroupViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			if (model.ApiPrdFirstGroupID > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteProductFirstGroup(model.ApiPrdFirstGroupID));
				if (mct_Result != null)
				{
					if (mct_Result.Result > 0)
					{
						data = true;
						message = Messages.ResourceManager.GetString("SuccessDoneRegister", new CultureInfo(name));
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = false;
						message = Messages.ResourceManager.GetString("RedundancyMessage", new CultureInfo(name));
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = false;
					message = Messages.ResourceManager.GetString("RedundancyMessage", new CultureInfo(name));
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				data = false;
				message = Messages.ResourceManager.GetString("ErrorNotFound", new CultureInfo(name));
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectProductSecondGroup_Result>> ProductSecondGroup(SelectProductSecondGroupViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectProductSecondGroup_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectProductSecondGroup_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectProductSecondGroup_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<List<ApispSelectProductSecondGroup_Result>> serviceResult = new ServiceResult<List<ApispSelectProductSecondGroup_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectProductSecondGroup_Result> list2 = Enumerable.ToList<ApispSelectProductSecondGroup_Result>((IEnumerable<ApispSelectProductSecondGroup_Result>)cRMEntities.ApispSelectProductSecondGroup(model.ApiSecondGroupId, model.ApiSecondGroupCode, model.ApiFirstGroupId, model.ApiFirstGroupCode, currLangId, result));
			if (list2 != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectProductSecondGroup_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> InsertProductSecondGroup(InsertProductSecondGroupViewModel model)
	{
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertProductSecondGroup(model.ApiFirstGroupId, model.ApiSGCode, model.ApiSGName, model.ApiSGDescription, model.ApiSGNameEn, model.ApiSGInactiveInSale, model.ApiSGInactiveInBuy, model.ApiSGOrderView, model.ApiSGSHPIsActive, model.ApiSGCompanyGroupIIRateJson, model.ApiSGSHPName, value2, appType, userId, value, registerDatePersian, currLangId, objectParameter, objectParameter2, model.ApiSGLinkAccGroupId, model.ApiSGLinkAccGroupCode, model.ApiSGLinkAccGroupIdStr, model.ApiSGLinkAccGroupName, model.ApiSGLinkAccGroups, model.ApiSGLinkAccFirstTransferDate, model.ApiSGLinkAccLastTransferDate, model.ApiSGLinkAccData, model.ApiFirstGroupCode, model.ApiTspSGIndentify, model.ApiTspSGName));
			string @string = Messages.ResourceManager.GetString("ErrorDoneOperationTryAgain", new CultureInfo(name));
			string string2 = Messages.ResourceManager.GetString("ErrorTryAgain", new CultureInfo(name));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 <= 0)
			{
				return new ServiceResult<int>
				{
					Message = @string.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
			{
				string text = "";
				string text2 = objectParameter2.Value.ToString();
				if (text2.IndexOf("NO SGName|", StringComparison.Ordinal) >= 0)
				{
					text = text + string.Format(Messages.ResourceManager.GetString("ErrorItemIsNotEntered", new CultureInfo(name)), Labels.ResourceManager.GetString("PrdSecondGroup", new CultureInfo(name))) + string2;
					return new ServiceResult<int>
					{
						Message = text.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text2.IndexOf("NO FGId|", StringComparison.Ordinal) >= 0)
				{
					text = text + string.Format(Messages.ResourceManager.GetString("ErrorItemIsNotEntered", new CultureInfo(name)), Labels.ResourceManager.GetString("PrdFirstGroup", new CultureInfo(name))) + string2;
					return new ServiceResult<int>
					{
						Message = text.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text2.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text += string2;
					return new ServiceResult<int>
					{
						Message = string2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					return new ServiceResult<int>
					{
						Message = @string.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				data = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				message = Messages.ResourceManager.GetString("SuccessDoneRegister", new CultureInfo(name));
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> UpdateProductSecondGroup(UpdateProductSecondGroupViewModel model)
	{
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
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
			string text = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text = apispSelectLanguages_Result.LanguageCollation;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num = cRMEntities.ApispUpdateProductSecondGroup(model.ApiPrdSecondGroupID, model.ApiFirstGroupId, model.ApiSGCode, model.ApiSGName, model.ApiSGDescription, model.ApiSGNameEn, model.ApiSGInactiveInSale, model.ApiSGInactiveInBuy, model.ApiSGOrderView, model.ApiSGSHPIsActive, model.ApiSGCompanyGroupIIRateJson, model.ApiSGSHPName, userId, value2, appType, currLangId, result, value, registerDatePersian, objectParameter, model.ApiSGLinkAccGroupId, model.ApiSGLinkAccGroupCode, model.ApiSGLinkAccGroupIdStr, model.ApiSGLinkAccGroupName, model.ApiSGLinkAccGroups, model.ApiSGLinkAccFirstTransferDate, model.ApiSGLinkAccLastTransferDate, model.ApiSGLinkAccData, model.ApiFirstGroupCode, model.ApiTspSGIndentify, model.ApiTspSGName);
			string @string = Messages.ResourceManager.GetString("ErrorDoneOperationTryAgain", new CultureInfo(text));
			string string2 = Messages.ResourceManager.GetString("ErrorTryAgain", new CultureInfo(text));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 < 0 && objectParameter.Value == null)
			{
				return new ServiceResult<int>
				{
					Message = @string.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
			{
				string text2 = "";
				string text3 = objectParameter.Value.ToString();
				if (text3.IndexOf("NO SGName|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsNotEntered", new CultureInfo(text)), Messages.ResourceManager.GetString("PrdSecondGroup", new CultureInfo(text))) + string2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("NO FGId|", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + string.Format(Messages.ResourceManager.GetString("ErrorItemIsNotEntered", new CultureInfo(text)), Messages.ResourceManager.GetString("PrdFirstGroup", new CultureInfo(text))) + string2;
					return new ServiceResult<int>
					{
						Message = text2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text2 += string2;
					return new ServiceResult<int>
					{
						Message = string2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text4 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text4 = text4 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text4)) ? (" (" + text4 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteProductSecondGroup(DeleteProductSecondGroupViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			if (model.ApiPrdSecondGroupID > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteProductSecondGroup(model.ApiPrdSecondGroupID));
				if (mct_Result != null)
				{
					if (mct_Result.Result > 0)
					{
						data = true;
						message = Messages.ResourceManager.GetString("SuccessDoneRegister", new CultureInfo(name));
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = false;
						message = Messages.ResourceManager.GetString("RedundancyMessage", new CultureInfo(name));
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = false;
					message = Messages.ResourceManager.GetString("RedundancyMessage", new CultureInfo(name));
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				data = false;
				message = Messages.ResourceManager.GetString("ErrorNotFound", new CultureInfo(name));
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSearchProducts_Result>> Search(SearchProductViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSearchProducts_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSearchProducts_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSearchProducts_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<List<ApispSearchProducts_Result>> serviceResult = new ServiceResult<List<ApispSearchProducts_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!model.ApiShowMode.HasValue)
			{
				model.ApiShowMode = 0;
			}
			List<ApispSearchProducts_Result> list2 = Enumerable.ToList<ApispSearchProducts_Result>((IEnumerable<ApispSearchProducts_Result>)cRMEntities.ApispSearchProducts(model.ApiPrdFGId, model.ApiPrdSGId, model.ApiPrdBarcode, prdId: model.ApiPrdId, val: model.ApiVal, showMode: model.ApiShowMode, languageID: currLangId, defaultLanguageID: result));
			if (list2 != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSearchProducts_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispReturnPrdQuantity_Result>> ReturnPrdQuantity(ReturnPrdQuantityViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispReturnPrdQuantity_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispReturnPrdQuantity_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispReturnPrdQuantity_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<List<ApispReturnPrdQuantity_Result>> serviceResult = new ServiceResult<List<ApispReturnPrdQuantity_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			CRMEntities cRMEntities2 = cRMEntities;
			int? num2 = 1;
			List<ApispReturnPrdQuantity_Result> list2 = Enumerable.ToList<ApispReturnPrdQuantity_Result>((IEnumerable<ApispReturnPrdQuantity_Result>)cRMEntities2.ApispReturnPrdQuantity(model.ApiPrdId, num2, model.ApiWHId, model.ApiPrdCurrId, fCR: model.ApiPrdFCR, fCRI: model.ApiPrdFCRI, tracing: model.ApiPrdTracing, languageID: currLangId, defaultLanguageID: result, centerId: model.CenterId, centerCode: model.CenterCode));
			if (list2 != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispReturnPrdQuantity_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispReturnProductTracing_Result>> ReturnPrdTracing(ReturnPrdTracingViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispReturnProductTracing_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispReturnProductTracing_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispReturnProductTracing_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<List<ApispReturnProductTracing_Result>> serviceResult = new ServiceResult<List<ApispReturnProductTracing_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispReturnProductTracing_Result> list2 = Enumerable.ToList<ApispReturnProductTracing_Result>((IEnumerable<ApispReturnProductTracing_Result>)cRMEntities.ApispReturnProductTracing(prdId: model.ApiPrdId, wHId: model.ApiWHId));
			if (list2 != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispReturnProductTracing_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectProductSpecifications_Result>> SelectProductSpecifications(SelectProductSpecificationsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectProductSpecifications_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectProductSpecifications_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectProductSpecifications_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			List<ApispSelectProductSpecifications_Result> list2 = Enumerable.ToList<ApispSelectProductSpecifications_Result>((IEnumerable<ApispSelectProductSpecifications_Result>)cRMEntities.ApispSelectProductSpecifications(model.ApiProductID, currLangId, result));
			if (list2 != null)
			{
				message = Messages.ResourceManager.GetString("SuccessDoneRegister", new CultureInfo(name));
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = Messages.ResourceManager.GetString("ErrorNotFound", new CultureInfo(name));
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectProductSpecifications_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> AddProductSpecificationValue(AddProductSpecificationValueViewModel model)
	{
		CRMEntities cRMEntities = _db;
		bool data = false;
		string text = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			if (!string.IsNullOrWhiteSpace(model.ApiSpecificValues) && !VersionBuyer.PrdSpec)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.msgErrorNotHavePrdSpecModule,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			if (cRMEntities == null)
			{
				cRMEntities = new CRMEntities();
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			List<ApispAddProductSpecificationValues_Result> list2 = Enumerable.ToList<ApispAddProductSpecificationValues_Result>((IEnumerable<ApispAddProductSpecificationValues_Result>)cRMEntities.ApispAddProductSpecificationValues(model.ApiProductId, model.ApiSpecificValues, value2, appType, userId, value, registerDatePersian, currLangId));
			data = true;
			text = Messages.ResourceManager.GetString("SuccessDoneRegister", new CultureInfo(name));
			status = ServiceResultStatus.Success;
			if (list2 != null && Enumerable.Count<ApispAddProductSpecificationValues_Result>((IEnumerable<ApispAddProductSpecificationValues_Result>)list2) > 0)
			{
				data = false;
				status = ServiceResultStatus.Error;
				foreach (ApispAddProductSpecificationValues_Result item in list2)
				{
					string text2 = "";
					if (item.Msg == "NotFound")
					{
						item.Msg = string.Format(Messages.ResourceManager.GetString("NotFoundEx", new CultureInfo(name)), item.FieldName + " [" + item.FieldValue + "]");
						text2 = item.Msg;
					}
					if (text != "")
					{
						text += "|";
					}
					text += text2;
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
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			if (cRMEntities != null && _db == null)
			{
				cRMEntities.Dispose();
			}
		}
		return new ServiceResult<bool>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> RemoveProductSpecificationValue(RemoveProductSpecificationValueViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			cRMEntities.ApispRemoveProductSpecificationValues(model.ApiProductId, model.ApiSpecificValues, value2, appType, userId, value, registerDatePersian, currLangId);
			data = true;
			message = Messages.ResourceManager.GetString("SuccessDoneRegister", new CultureInfo(name));
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectProductSpecificationFieldGroups_Result>> SelectProductSpecificationFieldGroups(SelectProductSpecificationFieldGroupsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectProductSpecificationFieldGroups_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectProductSpecificationFieldGroups_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectProductSpecificationFieldGroups_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			List<ApispSelectProductSpecificationFieldGroups_Result> list2 = Enumerable.ToList<ApispSelectProductSpecificationFieldGroups_Result>((IEnumerable<ApispSelectProductSpecificationFieldGroups_Result>)cRMEntities.ApispSelectProductSpecificationFieldGroups(0, currLangId, result));
			if (list2 != null)
			{
				message = Messages.ResourceManager.GetString("SuccessDoneRegister", new CultureInfo(name));
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = Messages.ResourceManager.GetString("ErrorNotFound", new CultureInfo(name));
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectProductSpecificationFieldGroups_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectProductSpecificationFieldsByGroupId_Result>> SelectProductSpecificationFieldsByGroupId(SelectProductSpecificationFieldsByGroupIdViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectProductSpecificationFieldsByGroupId_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectProductSpecificationFieldsByGroupId_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectProductSpecificationFieldsByGroupId_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			List<ApispSelectProductSpecificationFieldsByGroupId_Result> list2 = Enumerable.ToList<ApispSelectProductSpecificationFieldsByGroupId_Result>((IEnumerable<ApispSelectProductSpecificationFieldsByGroupId_Result>)cRMEntities.ApispSelectProductSpecificationFieldsByGroupId(0, model.ApiGroupId, currLangId, result));
			if (list2 != null)
			{
				message = Messages.ResourceManager.GetString("SuccessDoneRegister", new CultureInfo(name));
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = Messages.ResourceManager.GetString("ErrorNotFound", new CultureInfo(name));
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectProductSpecificationFieldsByGroupId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectLinkedProducts_Result>> SelectLinkedProducts(SelectLinkedProductsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectLinkedProducts_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectLinkedProducts_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectLinkedProducts_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<List<ApispSelectLinkedProducts_Result>> serviceResult = new ServiceResult<List<ApispSelectLinkedProducts_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectLinkedProducts_Result> list2 = Enumerable.ToList<ApispSelectLinkedProducts_Result>((IEnumerable<ApispSelectLinkedProducts_Result>)cRMEntities.ApispSelectLinkedProducts(model.ApiPrdId, model.ApiPrdCode, currLangId, result));
			if (list2 != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectLinkedProducts_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> InsertLinkedProduct(InsertLinkedProductViewModel model)
	{
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
			cRMEntities.ApispInsertLinkedProducts(model.ApiPrdId, model.ApiLinkedPrdId, model.ApiLinkedPrdCode, model.ApiOrderView, model.ApiLinkedPrdQuantity, model.ApiLinkedPrdNotVisible, model.ApiLinkedPrdNotInSum, model.ApiLinkedPrdAddQuantity, model.ApiLinkedPrdAddPrice, model.ApiLinkedPrdAddDiscount, model.ApiLinkedPrdIsSelect, userId, value, registerDatePersian, 1, value2, appType, currLangId, objectParameter);
			string @string = Messages.ResourceManager.GetString("ErrorDoneOperationTryAgain", new CultureInfo(name));
			string string2 = Messages.ResourceManager.GetString("ErrorTryAgain", new CultureInfo(name));
			int result2 = 0;
			int.TryParse(objectParameter.Value.ToString(), out result2);
			if (result2 == -1)
			{
				return new ServiceResult<int>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorItemDuplicate", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("Product", new CultureInfo(currLangId))),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (result2 == -2)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ResourceManager.GetString("msgErrorPrdIdNotFound", new CultureInfo(currLangId)).Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (result2 == -3)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ResourceManager.GetString("msgErrorLinkedPrdIdNotFound", new CultureInfo(currLangId)).Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (result2 <= 0)
			{
				return new ServiceResult<int>
				{
					Message = @string.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			data = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
			message = Messages.ResourceManager.GetString("SuccessDoneRegister", new CultureInfo(name));
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> InsertLinkedProductMulti(List<InsertLinkedProductViewModel> model)
	{
		string text = "";
		if (model.Count > 0)
		{
			for (int i = 0; i < model.Count; i++)
			{
				ServiceResult<int> serviceResult = InsertLinkedProduct(model[i]);
				if (serviceResult.Status != ServiceResultStatus.Success)
				{
					text = text + serviceResult.Message + "\n";
				}
			}
		}
		return new ServiceResult<bool>
		{
			Message = text,
			Data = (text == ""),
			Status = ((text == "") ? ServiceResultStatus.Success : ServiceResultStatus.Fail)
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteLinkedProduct(DeleteLinkedProductViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<bool> serviceResult = new ServiceResult<bool>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiLinkedProductId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteLinkedProduct(model.ApiLinkedProductId));
				if (mct_Result != null)
				{
					if (mct_Result.Result > 0)
					{
						data = true;
						message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = false;
						message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = false;
					message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				data = false;
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteAllLinkedProducts(DeleteAllLinkedProductViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<bool> serviceResult = new ServiceResult<bool>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiProductId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteAllLinkedProduct(model.ApiProductId));
				if (mct_Result != null)
				{
					if (mct_Result.Result > 0)
					{
						data = true;
						message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = false;
						message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = false;
					message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				data = false;
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectCenterProducts_Result>> SelectCenterProducts(SelectCenterProductsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectCenterProducts_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectCenterProducts_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectCenterProducts_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			ObjectParameter errorMessage = new ObjectParameter("ErrorMessage", "");
			List<ApispSelectCenterProducts_Result> list2 = Enumerable.ToList<ApispSelectCenterProducts_Result>((IEnumerable<ApispSelectCenterProducts_Result>)cRMEntities.ApispSelectCenterProducts(model.ApiPrdId, model.ApiPrdCode, model.ApiCenterId, model.ApiCenterCode, currLangId, result, errorMessage));
			if (list2 != null)
			{
				status = ServiceResultStatus.Success;
				data = list2;
			}
			else
			{
				message = Messages.ResourceManager.GetString("ErrorNotFound", new CultureInfo(name));
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectCenterProducts_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> InsertUpdateCenterProducts(InsertUpdateCenterProductsViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
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
			string name = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				name = apispSelectLanguages_Result.LanguageCollation;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			List<int?> list2 = Enumerable.ToList<int?>((IEnumerable<int?>)cRMEntities.ApispInsertUpdateCenterProduct(model.ApiPrdId, model.ApiPrdCode, model.ApiCenterId, model.ApiCenterCode, model.ApiIsActive, model.ApiShpShowAfterLogin, model.UserId, value, registerDatePersian, null, value2, appType, currLangId, objectParameter));
			if (objectParameter != null)
			{
				switch (objectParameter.Value.ToString())
				{
				case "":
					status = ServiceResultStatus.Success;
					data = true;
					message = "";
					break;
				case "PrdNotFound":
					message = Messages.ResourceManager.GetString("msgErrorPrdIdNotFound", new CultureInfo(name));
					break;
				case "CenterNotFound":
					message = Messages.ResourceManager.GetString("msgErrorCenterNotFound", new CultureInfo(name));
					break;
				default:
					message = Messages.ResourceManager.GetString("ErrorDoneOperation", new CultureInfo(name));
					break;
				}
			}
			else
			{
				message = Messages.ResourceManager.GetString("ErrorDoneOperation", new CultureInfo(name));
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public List<ServiceResult<bool>> InsertUpdateCenterProductsMulti(InsertUpdateCenterProductsMultiViewModel model)
	{
		List<ServiceResult<bool>> list = new List<ServiceResult<bool>>();
		for (int i = 0; i < model.CenterProductsList.Count; i++)
		{
			model.CenterProductsList[i].UserName = model.UserName;
			model.CenterProductsList[i].Password = model.Password;
			model.CenterProductsList[i].UserId = model.UserId;
			model.CenterProductsList[i].LanguageId = model.LanguageId;
			list.Add(InsertUpdateCenterProducts(model.CenterProductsList[i]));
		}
		return list;
	}

	[HttpPost]
	public ServiceResult<bool> DeleteCenterProduct(DeleteCenterProductViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
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
			string text = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text = apispSelectLanguages_Result.LanguageCollation;
			}
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short num = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			cRMEntities.ApispDeleteCenterProduct(model.ApiCenterProductID, model.ApiPrdId, model.ApiCenterId);
			status = ServiceResultStatus.Success;
			data = true;
			message = "";
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
