using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdealApi.Controllers;

public class ApiBuyOrderController : ApiController
{
	[HttpPost]
	public ServiceResult<IssueBuyOrderResultViewModel> Issue(IssueBuyOrderViewModel model)
	{
		//IL_2aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1300: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c25: Unknown result type (might be due to invalid IL or missing references)
		//IL_137d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ffd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ca2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1477: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0733: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		//IL_090e: Unknown result type (might be due to invalid IL or missing references)
		//IL_096d: Unknown result type (might be due to invalid IL or missing references)
		CRMEntities cRMEntities = null;
		IssueBuyOrderResultViewModel data = null;
		string text = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<IssueBuyOrderResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<IssueBuyOrderResultViewModel>
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
			string text3 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text3 = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!VersionBuyer.BuyOrders)
			{
				return new ServiceResult<IssueBuyOrderResultViewModel>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("BuyOrder", new CultureInfo(currLangId))),
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
				return new ServiceResult<IssueBuyOrderResultViewModel>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBuyOrderOprId <= 0)
			{
				model.ApiBuyOrderOprId = null;
			}
			if (model.ApiBordCompanyPersonId <= 0)
			{
				model.ApiBordCompanyPersonId = null;
			}
			if (model.ApiBordProjectId <= 0)
			{
				model.ApiBordProjectId = null;
			}
			if (model.ApiBordStatusId <= 0)
			{
				model.ApiBordStatusId = null;
			}
			if (model.ApiBordPrintFormatId <= 0)
			{
				model.ApiBordPrintFormatId = null;
			}
			if (model.ApiBordVerifierId <= 0)
			{
				model.ApiBordVerifierId = null;
			}
			if (model.ApiBordReferUserId.GetValueOrDefault() <= 0)
			{
				model.ApiBordReferUserId = model.UserId;
			}
			if (model.ApiBordCurrencyUnitId <= 0)
			{
				model.ApiBordCurrencyUnitId = null;
			}
			if (model.ApiBordFacilityCmpId <= 0)
			{
				model.ApiBordFacilityCmpId = null;
			}
			if (model.ApiBordFacilityPrsId <= 0)
			{
				model.ApiBordFacilityPrsId = null;
			}
			if (model.ApiBordFacilityPrjId <= 0)
			{
				model.ApiBordFacilityPrjId = null;
			}
			if (model.ApiBordReqCmpId <= 0)
			{
				model.ApiBordReqCmpId = null;
			}
			if (model.ApiBordReqPrsId <= 0)
			{
				model.ApiBordReqPrsId = null;
			}
			if (model.ApiBordReqPrjId <= 0)
			{
				model.ApiBordReqPrjId = null;
			}
			if (model.ApiBordFreightCurrUnId <= 0)
			{
				model.ApiBordFreightCurrUnId = null;
			}
			if (model.ApiBordCustomsCurrUnId <= 0)
			{
				model.ApiBordCustomsCurrUnId = null;
			}
			if (model.ApiBordCommissionCurrUnId <= 0)
			{
				model.ApiBordCommissionCurrUnId = null;
			}
			if (model.ApiBordCostSheetId <= 0)
			{
				model.ApiBordCostSheetId = null;
			}
			if (model.ApiBordDefaultSettingId <= 0)
			{
				model.ApiBordDefaultSettingId = null;
			}
			if (model.ApiBordVerificationWorkFlowId <= 0)
			{
				model.ApiBordVerificationWorkFlowId = null;
			}
			if (model.ApiBordCurrencyUnitIdI <= 0)
			{
				model.ApiBordCurrencyUnitIdI = null;
			}
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordTitle_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordTitle_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordTitle,
				LanguageId = currLangId
			});
			model.ApiBordTitle = JsonConvert.SerializeObject(list2);
			model.ApiBordTitle_Lang = null;
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordSubject_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordSubject_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordSubject,
				LanguageId = currLangId
			});
			model.ApiBordSubject = JsonConvert.SerializeObject(list3);
			model.ApiBordSubject_Lang = null;
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordNote_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordNote_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordNote,
				LanguageId = currLangId
			});
			model.ApiBordNote = JsonConvert.SerializeObject(list4);
			model.ApiBordNote_Lang = null;
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordCmpTitle_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordCmpTitle_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordCmpTitle,
				LanguageId = currLangId
			});
			model.ApiBordCmpTitle = JsonConvert.SerializeObject(list5);
			model.ApiBordCmpTitle_Lang = null;
			List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordDiscountTitle_Lang))
			{
				list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordDiscountTitle_Lang);
			}
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordDiscountTitle,
				LanguageId = currLangId
			});
			model.ApiBordDiscountTitle = JsonConvert.SerializeObject(list6);
			model.ApiBordDiscountTitle_Lang = null;
			List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordDeliveryTerm_Lang))
			{
				list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordDeliveryTerm_Lang);
			}
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordDeliveryTerm,
				LanguageId = currLangId
			});
			model.ApiBordDeliveryTerm = JsonConvert.SerializeObject(list7);
			model.ApiBordDeliveryTerm_Lang = null;
			List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordForwarderName_Lang))
			{
				list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordForwarderName_Lang);
			}
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordForwarderName,
				LanguageId = currLangId
			});
			model.ApiBordForwarderName = JsonConvert.SerializeObject(list8);
			model.ApiBordForwarderName_Lang = null;
			List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordCustomsPart_Lang))
			{
				list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordCustomsPart_Lang);
			}
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordCustomsPart,
				LanguageId = currLangId
			});
			model.ApiBordCustomsPart = JsonConvert.SerializeObject(list9);
			model.ApiBordCustomsPart_Lang = null;
			string text4 = "";
			if (model.ApiBordOrderDateTime.HasValue)
			{
				text4 = model.ApiBordOrderDateTime?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text5 = "";
			if (model.ApiBordDateTime.HasValue)
			{
				text5 = model.ApiBordDateTime?.ToString("yyyyMMdd", new PersianCulture());
			}
			if (text5 == "")
			{
				return new ServiceResult<IssueBuyOrderResultViewModel>
				{
					Message = ResourceManager.GetMessage("WrongBordDateTime", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			string text6 = "";
			if (model.ApiBordVerifiedRegisterDate.HasValue)
			{
				text6 = model.ApiBordVerifiedRegisterDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text7 = "";
			if (model.ApiBordTaxClearedDate.HasValue)
			{
				text7 = model.ApiBordTaxClearedDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text8 = "";
			if (model.ApiBordDeliveryDate.HasValue)
			{
				text8 = model.ApiBordDeliveryDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text9 = "";
			if (model.ApiBordSupplierDeliveryDate.HasValue)
			{
				text9 = model.ApiBordSupplierDeliveryDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text10 = "";
			if (model.ApiBordFinalDeliveryDate.HasValue)
			{
				text10 = model.ApiBordFinalDeliveryDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			model.ApiBordTransportation = model.ApiBordTransportation.GetValueOrDefault();
			model.ApiBordRound = model.ApiBordRound.GetValueOrDefault();
			model.ApiBordDiscount = model.ApiBordDiscount.GetValueOrDefault();
			model.ApiBordCompanyPersonId = ((model.ApiBordCompanyPersonId <= 0) ? null : model.ApiBordCompanyPersonId);
			model.ApiBordFacilityCost = model.ApiBordFacilityCost.GetValueOrDefault();
			decimal? apiBordFacilityCostPercent = model.ApiBordFacilityCostPercent;
			model.ApiBordFacilityCostPercent = (((apiBordFacilityCostPercent.GetValueOrDefault() == default(decimal)) & apiBordFacilityCostPercent.HasValue) ? null : model.ApiBordFacilityCostPercent);
			model.ApiBordFreightCost = model.ApiBordFreightCost.GetValueOrDefault();
			model.ApiBordFinalFreightCost = model.ApiBordFinalFreightCost.GetValueOrDefault();
			model.ApiBordCustomsFee = model.ApiBordCustomsFee.GetValueOrDefault();
			model.ApiBordFinalCustomsFee = model.ApiBordFinalCustomsFee.GetValueOrDefault();
			model.ApiBordCommission = model.ApiBordCommission.GetValueOrDefault();
			model.ApiBordFinalCommission = model.ApiBordFinalCommission.GetValueOrDefault();
			decimal valueOrDefault = model.ApiBordFacilityCost.GetValueOrDefault();
			decimal valueOrDefault2 = model.ApiBordFreightCost.GetValueOrDefault();
			float valueOrDefault3 = model.ApiBordFreightCurrencyRate.GetValueOrDefault(1f);
			decimal num2 = valueOrDefault2 * (decimal)valueOrDefault3;
			decimal valueOrDefault4 = model.ApiBordCustomsFee.GetValueOrDefault();
			float valueOrDefault5 = model.ApiBordCustomsCurrencyRate.GetValueOrDefault(1f);
			decimal num3 = valueOrDefault4 * (decimal)valueOrDefault5;
			decimal valueOrDefault6 = model.ApiBordCommission.GetValueOrDefault();
			float valueOrDefault7 = model.ApiBordCommissionCurrencyRate.GetValueOrDefault(1f);
			decimal num4 = valueOrDefault6 * (decimal)valueOrDefault7;
			decimal value3 = valueOrDefault + num2 + num3 + num4;
			model.ApiBordFacilityCost = valueOrDefault;
			model.ApiBordFreightCost = valueOrDefault2;
			model.ApiBordFreightCurrencyRate = valueOrDefault3;
			model.ApiBordFinalFreightCost = num2;
			model.ApiBordCustomsFee = valueOrDefault4;
			model.ApiBordCustomsCurrencyRate = valueOrDefault5;
			model.ApiBordFinalCustomsFee = num3;
			model.ApiBordCommission = valueOrDefault6;
			model.ApiBordCommissionCurrencyRate = valueOrDefault7;
			model.ApiBordFinalCommission = num4;
			model.ApiBordTotalFinalCost = value3;
			if (model.ApiBordNumber == 0L)
			{
				long apiBordNumber = Enumerable.FirstOrDefault<long>((IEnumerable<long>)Enumerable.ToList<long>(cRMEntities.Database.SqlQuery<long>(string.Format("Select dbo.ApifnReturnBuyOrderNumber({0},{1},'{2}')", model.ApiBuyOrderOprId, model.CenterId.GetValueOrDefault(), model.CenterCode ?? ""), Array.Empty<object>())));
				model.ApiBordNumber = apiBordNumber;
			}
			long result3 = 0L;
			long.TryParse(model.ApiBordNumber.ToString(), out result3);
			long num5 = CheckDuplicateBuyOrderNumber(result3, 0, model.ApiBuyOrderOprId, model.CenterId, model.CenterCode);
			if (num5 > 0)
			{
				return new ServiceResult<IssueBuyOrderResultViewModel>
				{
					Message = ResourceManager.GetMessage("BuyOrderNumberIsRepeated", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<SelectListItemI> list10 = new List<SelectListItemI>();
			List<IssueBuyOrderItemsViewModel> list11 = null;
			if (string.IsNullOrWhiteSpace(model.ApiProductsJson))
			{
				return new ServiceResult<IssueBuyOrderResultViewModel>
				{
					Message = ResourceManager.GetMessage("PaymentJsonErrorFormat", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			list11 = JsonConvert.DeserializeObject<List<IssueBuyOrderItemsViewModel>>(model.ApiProductsJson);
			foreach (IssueBuyOrderItemsViewModel i in list11)
			{
				if (i.ApiBordIPrdId.GetValueOrDefault() == 0 && !string.IsNullOrWhiteSpace(i.ApiBordIPrdCode))
				{
					ApispSelectProductsWithIdOrCode_Result apispSelectProductsWithIdOrCode_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithIdOrCode_Result>((IEnumerable<ApispSelectProductsWithIdOrCode_Result>)cRMEntities.ApispSelectProductsWithIdOrCode(0, i.ApiBordIPrdCode, currLangId, result));
					if (apispSelectProductsWithIdOrCode_Result != null)
					{
						i.ApiBordIPrdId = apispSelectProductsWithIdOrCode_Result.ProductID;
						i.ApiBordIPrdCode = null;
					}
				}
				if (i.ApiBordIPrdId > 0)
				{
					try
					{
						bool result4 = false;
						bool result5 = false;
						bool result6 = false;
						ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)cRMEntities.ApispSelectProductsWithId(i.ApiBordIPrdId, currLangId, result));
						if (apispSelectProductsWithId_Result != null)
						{
							bool.TryParse(apispSelectProductsWithId_Result.PrdQtyNoFCR.ToString(), out result4);
							bool.TryParse(apispSelectProductsWithId_Result.PrdMustFullTracingCode.ToString(), out result5);
							bool.TryParse(apispSelectProductsWithId_Result.PrdSingleItem.ToString(), out result6);
						}
						if (result6)
						{
							return new ServiceResult<IssueBuyOrderResultViewModel>
							{
								Message = ResourceManager.GetMessage("msgErrorNoRegisterPrdSingleItemInBord", currLangId),
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
						if (i.ApiBordIQuantity.GetValueOrDefault() == 0f)
						{
							return new ServiceResult<IssueBuyOrderResultViewModel>
							{
								Message = string.Format(ResourceManager.GetMessage("ErrorIsNotEntered", currLangId), ResourceManager.GetLabel("Quantity", currLangId)),
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
						bool flag = false;
						ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result2 = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
						if (apispSelectCrmsysSetting_Result2 != null)
						{
							flag = apispSelectCrmsysSetting_Result2.MustFullTracingCode.HasValue && apispSelectCrmsysSetting_Result2.MustFullTracingCode != false;
						}
						if (flag)
						{
							if (string.IsNullOrWhiteSpace(i.ApiBordITracing))
							{
								return new ServiceResult<IssueBuyOrderResultViewModel>
								{
									Message = string.Format(ResourceManager.GetMessage("msgErrorIsNotSpecified", currLangId), ResourceManager.GetMessage("prdTracing", currLangId)),
									Data = null,
									Status = ServiceResultStatus.Error
								};
							}
						}
						else if (result5 && string.IsNullOrWhiteSpace(i.ApiBordITracing))
						{
							return new ServiceResult<IssueBuyOrderResultViewModel>
							{
								Message = string.Format(ResourceManager.GetMessage("msgErrorIsNotSpecified", currLangId), ResourceManager.GetMessage("prdTracing", currLangId)),
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
						List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(i.ApiBordIQuantityDesc_Lang))
						{
							list12 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(i.ApiBordIQuantityDesc_Lang);
						}
						list12.Add(new CommonMultiLanguageViewModel
						{
							Value = i.ApiBordIQuantityDesc,
							LanguageId = currLangId
						});
						i.ApiBordIQuantityDesc = JsonConvert.SerializeObject(list12);
						i.ApiBordIQuantityDesc_Lang = null;
						List<CommonMultiLanguageViewModel> list13 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(i.ApiBordIDescription_Lang))
						{
							list13 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(i.ApiBordIDescription_Lang);
						}
						list13.Add(new CommonMultiLanguageViewModel
						{
							Value = i.ApiBordIDescription,
							LanguageId = currLangId
						});
						i.ApiBordIDescription = JsonConvert.SerializeObject(list13);
						i.ApiBordIDescription_Lang = null;
						List<CommonMultiLanguageViewModel> list14 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(i.ApiBordIForwarderName_Lang))
						{
							list14 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(i.ApiBordIForwarderName_Lang);
						}
						list14.Add(new CommonMultiLanguageViewModel
						{
							Value = i.ApiBordIForwarderName,
							LanguageId = currLangId
						});
						i.ApiBordIForwarderName = JsonConvert.SerializeObject(list14);
						i.ApiBordIForwarderName_Lang = null;
						List<CommonMultiLanguageViewModel> list15 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(i.ApiBordICustomsPart_Lang))
						{
							list15 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(i.ApiBordICustomsPart_Lang);
						}
						list15.Add(new CommonMultiLanguageViewModel
						{
							Value = i.ApiBordICustomsPart,
							LanguageId = currLangId
						});
						i.ApiBordICustomsPart = JsonConvert.SerializeObject(list15);
						i.ApiBordICustomsPart_Lang = null;
						List<CommonMultiLanguageViewModel> list16 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(i.ApiBordIPrdNickname_Lang))
						{
							list16 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(i.ApiBordIPrdNickname_Lang);
						}
						list16.Add(new CommonMultiLanguageViewModel
						{
							Value = i.ApiBordIPrdNickname,
							LanguageId = currLangId
						});
						i.ApiBordIPrdNickname = JsonConvert.SerializeObject(list16);
						i.ApiBordIPrdNickname_Lang = null;
						double result7 = 1.0;
						double result8 = 1.0;
						if (result4)
						{
							result7 = 1.0;
							result8 = 1.0;
						}
						else
						{
							if (i.ApiBordIFCR.GetValueOrDefault() != 0f)
							{
								double.TryParse(i.ApiBordIFCR.ToString(), out result7);
							}
							if (i.ApiBordIFCRI.GetValueOrDefault() != 0f)
							{
								double.TryParse(i.ApiBordIFCRI.ToString(), out result8);
							}
						}
						double result9 = 0.0;
						double.TryParse(i.ApiBordIQuantityTotal.ToString(), out result9);
						decimal num6 = i.ApiBordIDiscount.GetValueOrDefault();
						decimal valueOrDefault8 = i.ApiBordICost.GetValueOrDefault();
						decimal valueOrDefault9 = i.ApiBordIRound.GetValueOrDefault();
						decimal valueOrDefault10 = i.ApiBordIRoundPlus.GetValueOrDefault();
						decimal valueOrDefault11 = i.ApiBordITax.GetValueOrDefault();
						decimal num7 = default(decimal);
						num7 = ((!(result9 > 0.0)) ? ((decimal)((double?)i.ApiBordIQuantity * result7 * result8).Value) : ((decimal)(result9 * result8)));
						if (i.ApiBordIDiscountSum.HasValue && num6 == 0m)
						{
							num6 = i.ApiBordIDiscountSum.GetValueOrDefault() / num7;
							i.ApiBordIDiscount = num6;
						}
						if (!i.ApiBordIDiscountSum.HasValue)
						{
							i.ApiBordIDiscountSum = num7 * num6;
						}
						decimal num8 = valueOrDefault8 - num6 - valueOrDefault9 + valueOrDefault10;
						decimal valueOrDefault12 = i.ApiBordIDiscountSum.GetValueOrDefault();
						decimal num9 = (valueOrDefault8 - valueOrDefault9 + valueOrDefault10) * num7 - valueOrDefault12;
						decimal.TryParse(i.ApiBordITaxIndex.ToString(), out var result10);
						if (result10 != 0m)
						{
							i.ApiBordITaxSum = num9 * result10 / 100m;
						}
						else
						{
							i.ApiBordITaxSum = num7 * valueOrDefault11;
						}
						if (i.ApiBordITaxSum.GetValueOrDefault() != 0m && i.ApiBordITax.GetValueOrDefault() == 0m)
						{
							i.ApiBordITax = i.ApiBordITaxSum / (decimal?)num7;
						}
						else if (i.ApiBordITaxSum.GetValueOrDefault() != 0m && i.ApiBordITaxIndex.GetValueOrDefault() == 0m)
						{
							i.ApiBordITaxIndex = i.ApiBordITaxSum * (decimal?)100 / (decimal?)num9;
						}
						if (i.ApiBordITax.GetValueOrDefault() != 0m && i.ApiBordITaxIndex.GetValueOrDefault() != 0m && i.ApiBordITaxSum.GetValueOrDefault() != 0m)
						{
							i.ApiBordICalculateTax = true;
						}
						else
						{
							i.ApiBordICalculateTax = false;
						}
						i.ApiBordICostSum = num9;
						i.ApiBordITotalCost = i.ApiBordICostSum + i.ApiBordITaxSum;
						decimal num10 = i.ApiBordIFacilityCost.GetValueOrDefault();
						decimal valueOrDefault13 = i.ApiBordITotalCost.GetValueOrDefault();
						decimal num11 = i.ApiBordIFacilityCostPercent.GetValueOrDefault();
						if (i.ApiBordIFacilityCostPercent.HasValue)
						{
							if (num11 > 0m)
							{
								num10 = Convert.ToDecimal(valueOrDefault13 * num11) / 100m;
							}
						}
						else if (num10 > 0m && valueOrDefault13 > 0m)
						{
							num11 = Convert.ToDecimal(Convert.ToDecimal(num10 * 100m) / valueOrDefault13);
						}
						decimal valueOrDefault14 = i.ApiBordIFreightCost.GetValueOrDefault();
						float valueOrDefault15 = i.ApiBordIFreightCurrencyRate.GetValueOrDefault(1f);
						decimal num12 = valueOrDefault14 * (decimal)valueOrDefault15;
						decimal valueOrDefault16 = i.ApiBordICustomsFee.GetValueOrDefault();
						float valueOrDefault17 = i.ApiBordICustomsCurrencyRate.GetValueOrDefault(1f);
						decimal num13 = valueOrDefault16 * (decimal)valueOrDefault17;
						decimal valueOrDefault18 = i.ApiBordICommission.GetValueOrDefault();
						float valueOrDefault19 = i.ApiBordICommissionCurrencyRate.GetValueOrDefault(1f);
						decimal num14 = valueOrDefault18 * (decimal)valueOrDefault19;
						decimal value4 = valueOrDefault13 + num10 + num12 + num13 + num14;
						i.ApiBordIFacilityCost = num10;
						i.ApiBordIFacilityCostPercent = num11;
						i.ApiBordIFreightCost = valueOrDefault14;
						i.ApiBordIFreightCurrencyRate = valueOrDefault15;
						i.ApiBordIFinalFreightCost = num12;
						i.ApiBordICustomsFee = valueOrDefault16;
						i.ApiBordICustomsCurrencyRate = valueOrDefault17;
						i.ApiBordIFinalCustomsFee = num13;
						i.ApiBordICommission = valueOrDefault18;
						i.ApiBordICommissionCurrencyRate = valueOrDefault19;
						i.ApiBordIFinalCommission = num14;
						bool result11 = false;
						ApispSelectCurrencyUnitsWithId_Result apispSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<ApispSelectCurrencyUnitsWithId_Result>((IEnumerable<ApispSelectCurrencyUnitsWithId_Result>)cRMEntities.ApispSelectCurrencyUnitsWithId(i.ApiBordICurrencyUnitId, currLangId, result));
						if (apispSelectCurrencyUnitsWithId_Result != null)
						{
							bool.TryParse(apispSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result11);
						}
						if (!result11)
						{
							if (i.ApiBordIDiscount.HasValue)
							{
								i.ApiBordIDiscount = RoundCalculation.RoundNumber(i.ApiBordIDiscount.GetValueOrDefault());
							}
							if (i.ApiBordITax.HasValue)
							{
								i.ApiBordITax = RoundCalculation.RoundNumber(i.ApiBordITax.GetValueOrDefault());
							}
							if (i.ApiBordITaxSum.HasValue)
							{
								i.ApiBordITaxSum = RoundCalculation.RoundNumber(i.ApiBordITaxSum.GetValueOrDefault());
							}
							if (i.ApiBordIDiscountSum.HasValue)
							{
								i.ApiBordIDiscountSum = RoundCalculation.RoundNumber(i.ApiBordIDiscountSum.GetValueOrDefault());
							}
						}
						string text11 = "";
						if (i.ApiBordITaxClearedDate.HasValue)
						{
							text11 = i.ApiBordITaxClearedDate?.ToString("yyyyMMdd", new PersianCulture());
						}
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel = i;
						decimal? apiBordICost = i.ApiBordICost;
						issueBuyOrderItemsViewModel.ApiBordICost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordICost);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel2 = i;
						apiBordICost = i.ApiBordIDiscountPercent;
						issueBuyOrderItemsViewModel2.ApiBordIDiscountPercent = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordIDiscountPercent);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel3 = i;
						apiBordICost = i.ApiBordIDiscount;
						issueBuyOrderItemsViewModel3.ApiBordIDiscount = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordIDiscount);
						i.ApiBordIFCR = ((i.ApiBordIFCR == 0f) ? null : i.ApiBordIFCR);
						i.ApiBordIFCRI = ((i.ApiBordIFCRI == 0f) ? null : i.ApiBordIFCRI);
						i.ApiBordIQuantityTotal = ((i.ApiBordIQuantityTotal == 0f) ? null : i.ApiBordIQuantityTotal);
						i.ApiBordICalculateTax = ((i.ApiBordICalculateTax == false) ? null : i.ApiBordICalculateTax);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel4 = i;
						apiBordICost = i.ApiBordITaxIndex;
						issueBuyOrderItemsViewModel4.ApiBordITaxIndex = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordITaxIndex);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel5 = i;
						apiBordICost = i.ApiBordITax;
						issueBuyOrderItemsViewModel5.ApiBordITax = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordITax);
						i.ApiBordIPrdUnitId = ((i.ApiBordIPrdUnitId == 0) ? null : i.ApiBordIPrdUnitId);
						i.ApiBordICurrencyUnitId = ((i.ApiBordICurrencyUnitId == 0) ? null : i.ApiBordICurrencyUnitId);
						if (CanUpdateBuyOrderItemTracing(i.ApiBordIWHId, i.ApiBordIPrdId.GetValueOrDefault(), i.ApiBordITracing) == 1)
						{
							i.ApiBordITracing = ((!string.IsNullOrWhiteSpace(i.ApiBordITracing)) ? i.ApiBordITracing : null);
						}
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel6 = i;
						apiBordICost = i.ApiBordITaxSum;
						issueBuyOrderItemsViewModel6.ApiBordITaxSum = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordITaxSum);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel7 = i;
						apiBordICost = i.ApiBordIDiscountSum;
						issueBuyOrderItemsViewModel7.ApiBordIDiscountSum = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordIDiscountSum);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel8 = i;
						apiBordICost = i.ApiBordICostSum;
						issueBuyOrderItemsViewModel8.ApiBordICostSum = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordICostSum);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel9 = i;
						apiBordICost = i.ApiBordIFacilityCost;
						issueBuyOrderItemsViewModel9.ApiBordIFacilityCost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordIFacilityCost);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel10 = i;
						apiBordICost = i.ApiBordIFacilityCostPercent;
						issueBuyOrderItemsViewModel10.ApiBordIFacilityCostPercent = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordIFacilityCostPercent);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel11 = i;
						apiBordICost = i.ApiBordIFreightCost;
						issueBuyOrderItemsViewModel11.ApiBordIFreightCost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordIFreightCost);
						i.ApiBordIFreightCurrencyRate = ((i.ApiBordIFreightCurrencyRate == 0f) ? null : i.ApiBordIFreightCurrencyRate);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel12 = i;
						apiBordICost = i.ApiBordIFinalFreightCost;
						issueBuyOrderItemsViewModel12.ApiBordIFinalFreightCost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordIFinalFreightCost);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel13 = i;
						apiBordICost = i.ApiBordICustomsFee;
						issueBuyOrderItemsViewModel13.ApiBordICustomsFee = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordICustomsFee);
						i.ApiBordICustomsCurrencyRate = ((i.ApiBordICustomsCurrencyRate == 0f) ? null : i.ApiBordICustomsCurrencyRate);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel14 = i;
						apiBordICost = i.ApiBordIFinalCustomsFee;
						issueBuyOrderItemsViewModel14.ApiBordIFinalCustomsFee = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordIFinalCustomsFee);
						i.ApiBordITotalFinalCost = value4;
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel15 = i;
						apiBordICost = i.ApiBordICommission;
						issueBuyOrderItemsViewModel15.ApiBordICommission = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordICommission);
						i.ApiBordICommissionCurrencyRate = ((i.ApiBordICommissionCurrencyRate == 0f) ? null : i.ApiBordICommissionCurrencyRate);
						IssueBuyOrderItemsViewModel issueBuyOrderItemsViewModel16 = i;
						apiBordICost = i.ApiBordIFinalCommission;
						issueBuyOrderItemsViewModel16.ApiBordIFinalCommission = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : i.ApiBordIFinalCommission);
						int count = list11.Count;
						if (i.ApiBordIOrderView.GetValueOrDefault() == 0)
						{
							i.ApiBordIOrderView = count + 1 + count * 4 - 1;
						}
					}
					catch (Exception ex)
					{
						string text12 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
						if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
						{
							text12 = text12 + " - " + ex.InnerException.Message;
						}
						text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text12)) ? (" (" + text12 + ")") : "");
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
				}
				else
				{
					text = Messages.msgErrorNotSelectProduct;
					data = null;
					status = ServiceResultStatus.Error;
				}
				if (i.Serials == null)
				{
					continue;
				}
				foreach (IssueBuyOrderItemSerialsViewModel s in i.Serials)
				{
					if (string.IsNullOrWhiteSpace(s.ApiSerial))
					{
						return new ServiceResult<IssueBuyOrderResultViewModel>
						{
							Message = ResourceManager.GetMessage("EmptyBuyOrder", currLangId),
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					ApifnCheckDuplicateBuyOrderPrdSerial_Result apifnCheckDuplicateBuyOrderPrdSerial_Result = Enumerable.FirstOrDefault<ApifnCheckDuplicateBuyOrderPrdSerial_Result>((IEnumerable<ApifnCheckDuplicateBuyOrderPrdSerial_Result>)Enumerable.ToList<ApifnCheckDuplicateBuyOrderPrdSerial_Result>((IEnumerable<ApifnCheckDuplicateBuyOrderPrdSerial_Result>)cRMEntities.ApifnCheckDuplicateBuyOrderPrdSerial(i.ApiBordIPrdId, s.ApiSerial, 0, i.ApiBordIWHId)));
					if (apifnCheckDuplicateBuyOrderPrdSerial_Result != null)
					{
						ServiceResult<IssueBuyOrderResultViewModel> serviceResult = new ServiceResult<IssueBuyOrderResultViewModel>
						{
							Message = ResourceManager.GetMessage("msgErrorDuplicateSerialNumberInBuyOrder", currLangId) + apifnCheckDuplicateBuyOrderPrdSerial_Result.bordNumber + ResourceManager.GetMessage("msgErrorDuplicateSerialNumberInBuyOrder1", currLangId),
							Data = null,
							Status = ServiceResultStatus.Error
						};
						serviceResult.Message = serviceResult.Message.Replace("<br>", "\r\n").Replace("</br>", "\r\n").Replace("<br/>", "\r\n");
						return serviceResult;
					}
					List<SelectListItemI> list17 = Enumerable.ToList<SelectListItemI>(Enumerable.Where<SelectListItemI>((IEnumerable<SelectListItemI>)list10, (Func<SelectListItemI, bool>)((SelectListItemI x) => x.Value == s.ApiSerial && x.ValueI == i.ApiBordIWHId && x.ValueII == i.ApiBordIPrdId)));
					if (list17 != null && list17.Count > 0)
					{
						return new ServiceResult<IssueBuyOrderResultViewModel>
						{
							Message = "Serial: " + string.Format(ResourceManager.GetMessage("ErrorItemDuplicate", currLangId), s.ApiSerial),
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					list10.Add(new SelectListItemI
					{
						Value = s.ApiSerial,
						ValueI = i.ApiBordIWHId.GetValueOrDefault(),
						ValueII = i.ApiBordIPrdId.GetValueOrDefault()
					});
					List<CommonMultiLanguageViewModel> list18 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(s.ApiDescription_Lang))
					{
						list18 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(s.ApiDescription_Lang);
					}
					list18.Add(new CommonMultiLanguageViewModel
					{
						Value = s.ApiDescription,
						LanguageId = currLangId
					});
					s.ApiDescription = JsonConvert.SerializeObject(list18);
					s.ApiDescription_Lang = null;
					List<CommonMultiLanguageViewModel> list19 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(s.ApiInfoI_Lang))
					{
						list19 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(s.ApiInfoI_Lang);
					}
					list19.Add(new CommonMultiLanguageViewModel
					{
						Value = s.ApiInfoI,
						LanguageId = currLangId
					});
					s.ApiInfoI = JsonConvert.SerializeObject(list19);
					s.ApiInfoI_Lang = null;
					List<CommonMultiLanguageViewModel> list20 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(s.ApiInfoII_Lang))
					{
						list20 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(s.ApiInfoII_Lang);
					}
					list20.Add(new CommonMultiLanguageViewModel
					{
						Value = s.ApiInfoII,
						LanguageId = currLangId
					});
					s.ApiInfoII = JsonConvert.SerializeObject(list20);
					s.ApiInfoII_Lang = null;
					List<CommonMultiLanguageViewModel> list21 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(s.ApiInfoIII_Lang))
					{
						list21 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(s.ApiInfoIII_Lang);
					}
					list21.Add(new CommonMultiLanguageViewModel
					{
						Value = s.ApiInfoIII,
						LanguageId = currLangId
					});
					s.ApiInfoIII = JsonConvert.SerializeObject(list21);
					s.ApiInfoIII_Lang = null;
					List<CommonMultiLanguageViewModel> list22 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(s.ApiInfoIV_Lang))
					{
						list22 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(s.ApiInfoIV_Lang);
					}
					list22.Add(new CommonMultiLanguageViewModel
					{
						Value = s.ApiInfoIV,
						LanguageId = currLangId
					});
					s.ApiInfoIV = JsonConvert.SerializeObject(list22);
					s.ApiInfoIV_Lang = null;
					List<CommonMultiLanguageViewModel> list23 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(s.ApiInfoV_Lang))
					{
						list23 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(s.ApiInfoV_Lang);
					}
					list23.Add(new CommonMultiLanguageViewModel
					{
						Value = s.ApiInfoV,
						LanguageId = currLangId
					});
					s.ApiInfoV = JsonConvert.SerializeObject(list23);
					s.ApiInfoV_Lang = null;
					List<CommonMultiLanguageViewModel> list24 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(s.ApiInfoVI_Lang))
					{
						list24 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(s.ApiInfoVI_Lang);
					}
					list24.Add(new CommonMultiLanguageViewModel
					{
						Value = s.ApiInfoVI,
						LanguageId = currLangId
					});
					s.ApiInfoVI = JsonConvert.SerializeObject(list24);
					s.ApiInfoVI_Lang = null;
				}
			}
			List<IssueBuyOrderPaymentsViewModel> list25 = null;
			if (!string.IsNullOrWhiteSpace(model.ApiPaymentsJson))
			{
				list25 = JsonConvert.DeserializeObject<List<IssueBuyOrderPaymentsViewModel>>(model.ApiPaymentsJson);
				foreach (IssueBuyOrderPaymentsViewModel item in list25)
				{
					if (!item.ApiImportDateTime.HasValue)
					{
						return new ServiceResult<IssueBuyOrderResultViewModel>
						{
							Message = ResourceManager.GetMessage("EmptyBordPaymentImportDate", currLangId),
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					if (item.ApiBordpayTypeId <= 0)
					{
						return new ServiceResult<IssueBuyOrderResultViewModel>
						{
							Message = ResourceManager.GetMessage("EmptyBordPaymentTypeId", currLangId),
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					decimal? apiBordICost = item.ApiBordpayAmount;
					if ((apiBordICost.GetValueOrDefault() <= default(decimal)) & apiBordICost.HasValue)
					{
						return new ServiceResult<IssueBuyOrderResultViewModel>
						{
							Message = ResourceManager.GetMessage("EmptyBordPaymentAmount", currLangId),
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					if (!item.ApiBordpayDocDateTime.HasValue)
					{
						return new ServiceResult<IssueBuyOrderResultViewModel>
						{
							Message = ResourceManager.GetMessage("EmptyBordPaymentDocDate", currLangId),
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					List<CommonMultiLanguageViewModel> list26 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(item.ApiBordpayDescription_Lang))
					{
						list26 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.ApiBordpayDescription_Lang);
					}
					list26.Add(new CommonMultiLanguageViewModel
					{
						Value = item.ApiBordpayDescription,
						LanguageId = currLangId
					});
					item.ApiBordpayDescription = JsonConvert.SerializeObject(list26);
					item.ApiBordpayDescription_Lang = null;
				}
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				ObjectParameter objectParameter = new ObjectParameter("ApiBordNumber", model.ApiBordNumber);
				ObjectParameter objectParameter2 = new ObjectParameter("InsertedBuyOrderId", 0);
				CRMEntities cRMEntities2 = cRMEntities;
				int? apiBuyOrderOprId = model.ApiBuyOrderOprId;
				string apiBordTitle = model.ApiBordTitle;
				string apiBordOrderNumber = model.ApiBordOrderNumber;
				DateTime? apiBordDateTime = model.ApiBordDateTime;
				DateTime? apiBordOrderDateTime = model.ApiBordOrderDateTime;
				int? apiBordCompanyId = model.ApiBordCompanyId;
				int? apiBordCompanyNumber = model.ApiBordCompanyNumber;
				string apiBordCompanyCode = model.ApiBordCompanyCode;
				int? apiBordCompanyPersonId = model.ApiBordCompanyPersonId;
				int? apiBordProjectId = model.ApiBordProjectId;
				string apiBordProjectTitle = model.ApiBordProjectTitle;
				string label = ResourceManager.GetLabel("DefualtPrjTitle", currLangId);
				string apiBordSubject = model.ApiBordSubject;
				decimal? apiBordDiscount = model.ApiBordDiscount;
				decimal? apiBordTaxIndex = model.ApiBordTaxIndex;
				bool? apiBordCalculateTax = model.ApiBordCalculateTax;
				bool? apiBordIsVerified = model.ApiBordIsVerified;
				int? apiBordStatusId = model.ApiBordStatusId;
				bool? apiBordIsFixed = model.ApiBordIsFixed;
				int? apiBordPrintFormatId = model.ApiBordPrintFormatId;
				int? apiBordVerifierId = model.ApiBordVerifierId;
				DateTime? apiBordVerifiedRegisterDate = model.ApiBordVerifiedRegisterDate;
				int? apiBordSettlementTypeId = model.ApiBordSettlementTypeId;
				string apiBordTime = model.ApiBordDateTime?.ToString("HH:mm:ss", new PersianCulture());
				decimal? apiBordTransportation = model.ApiBordTransportation;
				int? apiBordReferUserId = model.ApiBordReferUserId;
				decimal? apiBordRound = model.ApiBordRound;
				string apiBordDiscountTitle = model.ApiBordDiscountTitle;
				string apiBordNote = model.ApiBordNote;
				DateTime? apiBordImportDateTime = value;
				string apiBordCmpTitle = model.ApiBordCmpTitle;
				int? apiBordCurrencyUnitId = model.ApiBordCurrencyUnitId;
				int? apiBordFacilityCmpId = model.ApiBordFacilityCmpId;
				int? apiBordFacilityCmpNumber = model.ApiBordFacilityCmpNumber;
				string apiBordFacilityCmpCode = model.ApiBordFacilityCmpCode;
				int? apiBordFacilityPrsId = model.ApiBordFacilityPrsId;
				int? apiBordFacilityPrjId = model.ApiBordFacilityPrjId;
				string apiBordFacilityProjectTitle = model.ApiBordFacilityProjectTitle;
				int? apiBordReqCmpId = model.ApiBordReqCmpId;
				int? apiBordReqCmpNumber = model.ApiBordReqCmpNumber;
				string apiBordReqCmpCode = model.ApiBordReqCmpCode;
				int? apiBordReqPrsId = model.ApiBordReqPrsId;
				int? apiBordReqPrjId = model.ApiBordReqPrjId;
				string apiBordReqProjectTitle = model.ApiBordReqProjectTitle;
				string apiBordDeliveryTerm = model.ApiBordDeliveryTerm;
				DateTime? apiBordDeliveryDate = model.ApiBordDeliveryDate;
				bool? apiBordTaxCleared = model.ApiBordTaxCleared;
				DateTime? apiBordTaxClearedDate = model.ApiBordTaxClearedDate;
				decimal? apiBordFacilityCost = model.ApiBordFacilityCost;
				decimal? apiBordFacilityCostPercent2 = model.ApiBordFacilityCostPercent;
				DateTime? apiBordSupplierDeliveryDate = model.ApiBordSupplierDeliveryDate;
				string apiBordForwarderName = model.ApiBordForwarderName;
				decimal? apiBordFreightCost = model.ApiBordFreightCost;
				int? apiBordFreightCurrUnId = model.ApiBordFreightCurrUnId;
				double? apiBordFreightCurrencyRate = model.ApiBordFreightCurrencyRate;
				decimal? apiBordFinalFreightCost = model.ApiBordFinalFreightCost;
				string apiBordCustomsPart = model.ApiBordCustomsPart;
				decimal? apiBordCustomsFee = model.ApiBordCustomsFee;
				int? apiBordCustomsCurrUnId = model.ApiBordCustomsCurrUnId;
				double? apiBordCustomsCurrencyRate = model.ApiBordCustomsCurrencyRate;
				decimal? apiBordFinalCustomsFee = model.ApiBordFinalCustomsFee;
				DateTime? apiBordFinalDeliveryDate = model.ApiBordFinalDeliveryDate;
				decimal? apiBordTotalFinalCost = model.ApiBordTotalFinalCost;
				decimal? apiBordCommission = model.ApiBordCommission;
				int? apiBordCommissionCurrUnId = model.ApiBordCommissionCurrUnId;
				double? apiBordCommissionCurrencyRate = model.ApiBordCommissionCurrencyRate;
				decimal? apiBordFinalCommission = model.ApiBordFinalCommission;
				int? apiBordCostSheetId = model.ApiBordCostSheetId;
				string apiBordNumRef = model.ApiBordNumRef;
				int? apiBordDefaultSettingId = model.ApiBordDefaultSettingId;
				int? apiBordVerificationWorkFlowId = model.ApiBordVerificationWorkFlowId;
				DateTime? apiBordLinkAccFirstTransferDate = model.ApiBordLinkAccFirstTransferDate;
				DateTime? apiBordLinkAccLastTransferDate = model.ApiBordLinkAccLastTransferDate;
				int? apiBordCurrencyUnitIdI = model.ApiBordCurrencyUnitIdI;
				double? apiBordCurrencyUnitIRate = model.ApiBordCurrencyUnitIRate;
				string productsJs = JsonConvert.SerializeObject(list11);
				string paymentsJs = JsonConvert.SerializeObject(list25);
				int? userId2 = model.UserId;
				short? month = value2;
				string appType2 = appType;
				List<ApispIssueBuyOrder_Result> list27 = Enumerable.ToList<ApispIssueBuyOrder_Result>((IEnumerable<ApispIssueBuyOrder_Result>)cRMEntities2.ApispIssueBuyOrder(apiBuyOrderOprId, apiBordTitle, objectParameter, apiBordOrderNumber, apiBordDateTime, apiBordOrderDateTime, apiBordCompanyId, apiBordCompanyNumber, apiBordCompanyCode, apiBordCompanyPersonId, apiBordProjectId, apiBordProjectTitle, label, apiBordSubject, apiBordDiscount, apiBordTaxIndex, apiBordCalculateTax, apiBordIsVerified, apiBordStatusId, apiBordIsFixed, apiBordPrintFormatId, apiBordVerifierId, apiBordVerifiedRegisterDate, apiBordSettlementTypeId, apiBordTime, apiBordTransportation, apiBordReferUserId, apiBordRound, apiBordDiscountTitle, apiBordNote, apiBordImportDateTime, apiBordCmpTitle, apiBordCurrencyUnitId, apiBordFacilityCmpId, apiBordFacilityCmpNumber, apiBordFacilityCmpCode, apiBordFacilityPrsId, apiBordFacilityPrjId, apiBordFacilityProjectTitle, apiBordReqCmpId, apiBordReqCmpNumber, apiBordReqCmpCode, apiBordReqPrsId, apiBordReqPrjId, apiBordReqProjectTitle, apiBordDeliveryTerm, apiBordDeliveryDate, apiBordTaxCleared, apiBordTaxClearedDate, apiBordFacilityCost, apiBordFacilityCostPercent2, apiBordSupplierDeliveryDate, apiBordForwarderName, apiBordFreightCost, apiBordFreightCurrUnId, apiBordFreightCurrencyRate, apiBordFinalFreightCost, apiBordCustomsPart, apiBordCustomsFee, apiBordCustomsCurrUnId, apiBordCustomsCurrencyRate, apiBordFinalCustomsFee, apiBordFinalDeliveryDate, apiBordTotalFinalCost, apiBordCommission, apiBordCommissionCurrUnId, apiBordCommissionCurrencyRate, apiBordFinalCommission, apiBordCostSheetId, apiBordNumRef, apiBordDefaultSettingId, apiBordVerificationWorkFlowId, apiBordLinkAccFirstTransferDate, apiBordLinkAccLastTransferDate, apiBordCurrencyUnitIdI, apiBordCurrencyUnitIRate, productsJs, paymentsJs, objectParameter2, userId2, month, value, registerDatePersian, appType2, model.LanguageId, result, model.CenterId, model.CenterCode));
				List<SelectListItem> list28 = new List<SelectListItem>();
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBuyOrderOprId",
					Value = ResourceManager.GetMessage("NotExistsBuyOrderOprId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordCompanyId",
					Value = ResourceManager.GetMessage("NotExistsBordCompanyId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "RequiredBordCompanyId",
					Value = ResourceManager.GetMessage("RequiredBordCompanyId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordCompanyPersonId",
					Value = ResourceManager.GetMessage("NotExistsBordCompanyPersonId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsProject",
					Value = ResourceManager.GetMessage("NotExistsProject", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordStatusId",
					Value = ResourceManager.GetMessage("NotExistsBordStatusId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordPrintFormatId",
					Value = ResourceManager.GetMessage("NotExistsBordPrintFormatId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordVerifierId",
					Value = ResourceManager.GetMessage("NotExistsBordVerifierId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordReferUserId",
					Value = ResourceManager.GetMessage("NotExistsBordReferUserId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordCurrencyUnitId",
					Value = ResourceManager.GetMessage("NotExistsBordCurrencyUnitId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordFacilityCmpId",
					Value = ResourceManager.GetMessage("NotExistsBordFacilityCmpId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordFacilityPrsId",
					Value = ResourceManager.GetMessage("NotExistsBordFacilityPrsId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordFacilityPrjId",
					Value = ResourceManager.GetMessage("NotExistsBordFacilityPrjId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordReqCmpId",
					Value = ResourceManager.GetMessage("NotExistsBordReqCmpId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordReqPrsId",
					Value = ResourceManager.GetMessage("NotExistsBordReqPrsId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordReqPrjId",
					Value = ResourceManager.GetMessage("NotExistsBordReqPrjId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordFreightCurrUnId",
					Value = ResourceManager.GetMessage("NotExistsBordFreightCurrUnId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordICommissionCurrUnId",
					Value = ResourceManager.GetMessage("NotExistsBordICommissionCurrUnId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordCommissionCurrUnId",
					Value = ResourceManager.GetMessage("NotExistsBordCommissionCurrUnId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordCostSheetId",
					Value = ResourceManager.GetMessage("NotExistsBordCostSheetId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordDefaultSettingId",
					Value = ResourceManager.GetMessage("NotExistsBordDefaultSettingId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordVerificationWorkFlowId",
					Value = ResourceManager.GetMessage("NotExistsBordVerificationWorkFlowId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordCurrencyUnitIdI",
					Value = ResourceManager.GetMessage("NotExistsBordCurrencyUnitIdI", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "PaymentJsonErrorFormat",
					Value = ResourceManager.GetMessage("PaymentJsonErrorFormat", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordIPrdId",
					Value = ResourceManager.GetMessage("NotExistsBordIPrdId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "msgErrorNotSelectProduct",
					Value = ResourceManager.GetMessage("msgErrorNotSelectProduct", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "ErrorIsNotEnteredQuantity",
					Value = ResourceManager.GetMessage("ErrorIsNotEnteredQuantity", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordIPrdUnitId",
					Value = ResourceManager.GetMessage("NotExistsBordIPrdUnitId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordIPrdUnitIdI",
					Value = ResourceManager.GetMessage("NotExistsBordIPrdUnitIdI", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordICurrencyUnitId",
					Value = ResourceManager.GetMessage("NotExistsBordICurrencyUnitId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordIWHId",
					Value = ResourceManager.GetMessage("NotExistsBordIWHId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordIFreightCurrUnId",
					Value = ResourceManager.GetMessage("NotExistsBordIFreightCurrUnId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordICustomsCurrUnId",
					Value = ResourceManager.GetMessage("NotExistsBordICustomsCurrUnId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordICommissionCurrUnId",
					Value = ResourceManager.GetMessage("NotExistsBordICommissionCurrUnId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordICostSheetItemId",
					Value = ResourceManager.GetMessage("NotExistsBordICostSheetItemId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordIPrdColorId",
					Value = ResourceManager.GetMessage("NotExistsBordIPrdColorId", currLangId)
				});
				list28.Add(new SelectListItem
				{
					Text = "NotExistsBordpayTypeId",
					Value = ResourceManager.GetMessage("NotExistsBordpayTypeId", currLangId)
				});
				if (list27 != null)
				{
					if (list27.Count > 0)
					{
						foreach (ApispIssueBuyOrder_Result msg in list27)
						{
							if (!string.IsNullOrWhiteSpace(msg.Msg))
							{
								if (text != "")
								{
									text += "\r\n";
								}
								text = text + "Error '" + msg.Msg + "'";
								continue;
							}
							SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list28, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == msg.RsMessage));
							if (selectListItem != null)
							{
								if (text != "")
								{
									text += "\r\n";
								}
								text += selectListItem.Value;
							}
						}
					}
					else
					{
						data = new IssueBuyOrderResultViewModel
						{
							BuyOrderId = int.Parse(objectParameter2.Value.ToString()),
							BuyOrderNumber = objectParameter.Value.ToString()
						};
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					text = ResourceManager.GetMessage("ErrorDoneOperation", currLangId);
				}
			}
		}
		catch (DbEntityValidationException ex2)
		{
			string text13 = ((!string.IsNullOrEmpty(((Exception)(object)ex2).Message)) ? ((Exception)(object)ex2).Message : "");
			if (((Exception)(object)ex2).InnerException != null && !string.IsNullOrEmpty(((Exception)(object)ex2).InnerException.Message))
			{
				text13 = text13 + " - " + ((Exception)(object)ex2).InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text13)) ? (" (" + text13 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex2);
		}
		catch (Exception ex3)
		{
			string text14 = ((!string.IsNullOrEmpty(ex3.Message)) ? ex3.Message : "");
			if (ex3.InnerException != null && !string.IsNullOrEmpty(ex3.InnerException.Message))
			{
				text14 = text14 + " - " + ex3.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text14)) ? (" (" + text14 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<IssueBuyOrderResultViewModel>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<IssueBuyOrderResultViewModel> Insert(InsertBuyOrderViewModel model)
	{
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_071f: Unknown result type (might be due to invalid IL or missing references)
		//IL_076a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Unknown result type (might be due to invalid IL or missing references)
		//IL_084b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Unknown result type (might be due to invalid IL or missing references)
		CRMEntities cRMEntities = null;
		IssueBuyOrderResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<IssueBuyOrderResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<IssueBuyOrderResultViewModel>
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
			string text3 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text3 = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!VersionBuyer.BuyOrders)
			{
				return new ServiceResult<IssueBuyOrderResultViewModel>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("BuyOrder", new CultureInfo(currLangId))),
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
				return new ServiceResult<IssueBuyOrderResultViewModel>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBuyOrderOprId <= 0)
			{
				model.ApiBuyOrderOprId = null;
			}
			if (model.ApiBordCompanyPersonId <= 0)
			{
				model.ApiBordCompanyPersonId = null;
			}
			if (model.ApiBordProjectId <= 0)
			{
				model.ApiBordProjectId = null;
			}
			if (model.ApiBordStatusId <= 0)
			{
				model.ApiBordStatusId = null;
			}
			if (model.ApiBordPrintFormatId <= 0)
			{
				model.ApiBordPrintFormatId = null;
			}
			if (model.ApiBordVerifierId <= 0)
			{
				model.ApiBordVerifierId = null;
			}
			if (model.ApiBordReferUserId.GetValueOrDefault() <= 0)
			{
				model.ApiBordReferUserId = model.UserId;
			}
			if (model.ApiBordCurrencyUnitId <= 0)
			{
				model.ApiBordCurrencyUnitId = null;
			}
			if (model.ApiBordFacilityCmpId <= 0)
			{
				model.ApiBordFacilityCmpId = null;
			}
			if (model.ApiBordFacilityPrsId <= 0)
			{
				model.ApiBordFacilityPrsId = null;
			}
			if (model.ApiBordFacilityPrjId <= 0)
			{
				model.ApiBordFacilityPrjId = null;
			}
			if (model.ApiBordReqCmpId <= 0)
			{
				model.ApiBordReqCmpId = null;
			}
			if (model.ApiBordReqPrsId <= 0)
			{
				model.ApiBordReqPrsId = null;
			}
			if (model.ApiBordReqPrjId <= 0)
			{
				model.ApiBordReqPrjId = null;
			}
			if (model.ApiBordFreightCurrUnId <= 0)
			{
				model.ApiBordFreightCurrUnId = null;
			}
			if (model.ApiBordCustomsCurrUnId <= 0)
			{
				model.ApiBordCustomsCurrUnId = null;
			}
			if (model.ApiBordCommissionCurrUnId <= 0)
			{
				model.ApiBordCommissionCurrUnId = null;
			}
			if (model.ApiBordCostSheetId <= 0)
			{
				model.ApiBordCostSheetId = null;
			}
			if (model.ApiBordDefaultSettingId <= 0)
			{
				model.ApiBordDefaultSettingId = null;
			}
			if (model.ApiBordVerificationWorkFlowId <= 0)
			{
				model.ApiBordVerificationWorkFlowId = null;
			}
			if (model.ApiBordCurrencyUnitIdI <= 0)
			{
				model.ApiBordCurrencyUnitIdI = null;
			}
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordTitle_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordTitle_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordTitle,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordSubject_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordSubject_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordSubject,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordNote_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordNote_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordNote,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordCmpTitle_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordCmpTitle_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordCmpTitle,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordDiscountTitle_Lang))
			{
				list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordDiscountTitle_Lang);
			}
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordDiscountTitle,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordDeliveryTerm_Lang))
			{
				list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordDeliveryTerm_Lang);
			}
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordDeliveryTerm,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordForwarderName_Lang))
			{
				list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordForwarderName_Lang);
			}
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordForwarderName,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordCustomsPart_Lang))
			{
				list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordCustomsPart_Lang);
			}
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordCustomsPart,
				LanguageId = currLangId
			});
			string text4 = "";
			if (model.ApiBordOrderDateTime.HasValue)
			{
				text4 = model.ApiBordOrderDateTime?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text5 = "";
			if (model.ApiBordDateTime.HasValue)
			{
				text5 = model.ApiBordDateTime?.ToString("yyyyMMdd", new PersianCulture());
			}
			if (text5 == "")
			{
				return new ServiceResult<IssueBuyOrderResultViewModel>
				{
					Message = ResourceManager.GetMessage("WrongBordDateTime", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			string text6 = "";
			if (model.ApiBordVerifiedRegisterDate.HasValue)
			{
				text6 = model.ApiBordVerifiedRegisterDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text7 = "";
			if (model.ApiBordTaxClearedDate.HasValue)
			{
				text7 = model.ApiBordTaxClearedDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text8 = "";
			if (model.ApiBordDeliveryDate.HasValue)
			{
				text8 = model.ApiBordDeliveryDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text9 = "";
			if (model.ApiBordSupplierDeliveryDate.HasValue)
			{
				text9 = model.ApiBordSupplierDeliveryDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text10 = "";
			if (model.ApiBordFinalDeliveryDate.HasValue)
			{
				text10 = model.ApiBordFinalDeliveryDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			model.ApiBordTransportation = model.ApiBordTransportation.GetValueOrDefault();
			model.ApiBordRound = model.ApiBordRound.GetValueOrDefault();
			model.ApiBordDiscount = model.ApiBordDiscount.GetValueOrDefault();
			model.ApiBordCompanyPersonId = ((model.ApiBordCompanyPersonId <= 0) ? null : model.ApiBordCompanyPersonId);
			model.ApiBordFacilityCost = model.ApiBordFacilityCost.GetValueOrDefault();
			decimal? apiBordFacilityCostPercent = model.ApiBordFacilityCostPercent;
			model.ApiBordFacilityCostPercent = (((apiBordFacilityCostPercent.GetValueOrDefault() == default(decimal)) & apiBordFacilityCostPercent.HasValue) ? null : model.ApiBordFacilityCostPercent);
			model.ApiBordFreightCost = model.ApiBordFreightCost.GetValueOrDefault();
			model.ApiBordFinalFreightCost = model.ApiBordFinalFreightCost.GetValueOrDefault();
			model.ApiBordCustomsFee = model.ApiBordCustomsFee.GetValueOrDefault();
			model.ApiBordFinalCustomsFee = model.ApiBordFinalCustomsFee.GetValueOrDefault();
			model.ApiBordCommission = model.ApiBordCommission.GetValueOrDefault();
			model.ApiBordFinalCommission = model.ApiBordFinalCommission.GetValueOrDefault();
			decimal valueOrDefault = model.ApiBordFacilityCost.GetValueOrDefault();
			decimal valueOrDefault2 = model.ApiBordFreightCost.GetValueOrDefault();
			float valueOrDefault3 = model.ApiBordFreightCurrencyRate.GetValueOrDefault(1f);
			decimal num2 = valueOrDefault2 * (decimal)valueOrDefault3;
			decimal valueOrDefault4 = model.ApiBordCustomsFee.GetValueOrDefault();
			float valueOrDefault5 = model.ApiBordCustomsCurrencyRate.GetValueOrDefault(1f);
			decimal num3 = valueOrDefault4 * (decimal)valueOrDefault5;
			decimal valueOrDefault6 = model.ApiBordCommission.GetValueOrDefault();
			float valueOrDefault7 = model.ApiBordCommissionCurrencyRate.GetValueOrDefault(1f);
			decimal num4 = valueOrDefault6 * (decimal)valueOrDefault7;
			decimal value3 = valueOrDefault + num2 + num3 + num4;
			model.ApiBordFacilityCost = valueOrDefault;
			model.ApiBordFreightCost = valueOrDefault2;
			model.ApiBordFreightCurrencyRate = valueOrDefault3;
			model.ApiBordFinalFreightCost = num2;
			model.ApiBordCustomsFee = valueOrDefault4;
			model.ApiBordCustomsCurrencyRate = valueOrDefault5;
			model.ApiBordFinalCustomsFee = num3;
			model.ApiBordCommission = valueOrDefault6;
			model.ApiBordCommissionCurrencyRate = valueOrDefault7;
			model.ApiBordFinalCommission = num4;
			model.ApiBordTotalFinalCost = value3;
			if (model.ApiBordNumber == 0L)
			{
				long apiBordNumber = Enumerable.FirstOrDefault<long>((IEnumerable<long>)Enumerable.ToList<long>(cRMEntities.Database.SqlQuery<long>(string.Format("Select dbo.ApifnReturnBuyOrderNumber({0},{1},'{2}')", model.ApiBuyOrderOprId, model.CenterId.GetValueOrDefault(), model.CenterCode ?? ""), Array.Empty<object>())));
				model.ApiBordNumber = apiBordNumber;
			}
			long result3 = 0L;
			long.TryParse(model.ApiBordNumber.ToString(), out result3);
			long num5 = CheckDuplicateBuyOrderNumber(result3, 0, model.ApiBuyOrderOprId, model.CenterId, model.CenterCode);
			if (num5 > 0)
			{
				return new ServiceResult<IssueBuyOrderResultViewModel>
				{
					Message = ResourceManager.GetMessage("BuyOrderNumberIsRepeated", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ApiBordNumber", model.ApiBordNumber);
			CRMEntities cRMEntities2 = cRMEntities;
			int? apiBuyOrderOprId = model.ApiBuyOrderOprId;
			string apiBordTitle = JsonConvert.SerializeObject(list2);
			string apiBordOrderNumber = model.ApiBordOrderNumber;
			string apiBordDate = text5;
			string apiBordOrderDate = text4;
			DateTime? apiBordOrderDateTime = model.ApiBordOrderDateTime;
			int? apiBordCompanyId = model.ApiBordCompanyId;
			int? apiBordCompanyNumber = model.ApiBordCompanyNumber;
			string apiBordCompanyCode = model.ApiBordCompanyCode;
			int? apiBordCompanyPersonId = model.ApiBordCompanyPersonId;
			int? apiBordProjectId = model.ApiBordProjectId;
			string apiBordSubject = JsonConvert.SerializeObject(list3);
			decimal? apiBordDiscount = model.ApiBordDiscount;
			decimal? apiBordTaxIndex = model.ApiBordTaxIndex;
			bool? apiBordCalculateTax = model.ApiBordCalculateTax;
			bool? apiBordIsVerified = model.ApiBordIsVerified;
			int? apiBordStatusId = model.ApiBordStatusId;
			bool? apiBordIsFixed = model.ApiBordIsFixed;
			int? apiBordPrintFormatId = model.ApiBordPrintFormatId;
			int? apiBordVerifierId = model.ApiBordVerifierId;
			DateTime? apiBordVerifiedRegisterDate = model.ApiBordVerifiedRegisterDate;
			string apiBordVerifiedRegisterDatePersian = text6;
			int? apiBordSettlementTypeId = model.ApiBordSettlementTypeId;
			string apiBordTime = model.ApiBordDateTime?.ToString("HH:mm:ss", new PersianCulture());
			decimal? apiBordTransportation = model.ApiBordTransportation;
			int? apiBordReferUserId = model.ApiBordReferUserId;
			decimal? apiBordRound = model.ApiBordRound;
			string apiBordDiscountTitle = JsonConvert.SerializeObject(list6);
			string apiBordNote = JsonConvert.SerializeObject(list4);
			DateTime? apiBordDateTime = model.ApiBordDateTime;
			DateTime? apiBordImportDateTime = value;
			string apiBordCmpTitle = JsonConvert.SerializeObject(list5);
			int? apiBordCurrencyUnitId = model.ApiBordCurrencyUnitId;
			int? apiBordFacilityCmpId = model.ApiBordFacilityCmpId;
			int? apiBordFacilityCmpNumber = model.ApiBordFacilityCmpNumber;
			string apiBordFacilityCmpCode = model.ApiBordFacilityCmpCode;
			int? apiBordFacilityPrsId = model.ApiBordFacilityPrsId;
			int? apiBordFacilityPrjId = model.ApiBordFacilityPrjId;
			int? apiBordReqCmpId = model.ApiBordReqCmpId;
			int? apiBordReqCmpNumber = model.ApiBordReqCmpNumber;
			string apiBordReqCmpCode = model.ApiBordReqCmpCode;
			int? apiBordReqPrsId = model.ApiBordReqPrsId;
			int? apiBordReqPrjId = model.ApiBordReqPrjId;
			string apiBordDeliveryTerm = JsonConvert.SerializeObject(list7);
			DateTime? apiBordDeliveryDate = model.ApiBordDeliveryDate;
			string apiBordDeliveryDatePersian = text8;
			bool? apiBordTaxCleared = model.ApiBordTaxCleared;
			DateTime? apiBordTaxClearedDate = model.ApiBordTaxClearedDate;
			string apiBordTaxClearedDatePersian = text7;
			decimal? apiBordFacilityCost = model.ApiBordFacilityCost;
			decimal? apiBordFacilityCostPercent2 = model.ApiBordFacilityCostPercent;
			DateTime? apiBordSupplierDeliveryDate = model.ApiBordSupplierDeliveryDate;
			string apiBordSupplierDeliveryDatePersian = text9;
			string apiBordForwarderName = JsonConvert.SerializeObject(list8);
			decimal? apiBordFreightCost = model.ApiBordFreightCost;
			int? apiBordFreightCurrUnId = model.ApiBordFreightCurrUnId;
			double? apiBordFreightCurrencyRate = model.ApiBordFreightCurrencyRate;
			decimal? apiBordFinalFreightCost = model.ApiBordFinalFreightCost;
			string apiBordCustomsPart = JsonConvert.SerializeObject(list9);
			decimal? apiBordCustomsFee = model.ApiBordCustomsFee;
			int? apiBordCustomsCurrUnId = model.ApiBordCustomsCurrUnId;
			double? apiBordCustomsCurrencyRate = model.ApiBordCustomsCurrencyRate;
			decimal? apiBordFinalCustomsFee = model.ApiBordFinalCustomsFee;
			DateTime? apiBordFinalDeliveryDate = model.ApiBordFinalDeliveryDate;
			string apiBordFinalDeliveryDatePersian = text10;
			decimal? apiBordTotalFinalCost = model.ApiBordTotalFinalCost;
			decimal? apiBordCommission = model.ApiBordCommission;
			int? apiBordCommissionCurrUnId = model.ApiBordCommissionCurrUnId;
			double? apiBordCommissionCurrencyRate = model.ApiBordCommissionCurrencyRate;
			decimal? apiBordFinalCommission = model.ApiBordFinalCommission;
			int? apiBordCostSheetId = model.ApiBordCostSheetId;
			string apiBordNumRef = model.ApiBordNumRef;
			int? apiBordDefaultSettingId = model.ApiBordDefaultSettingId;
			int? apiBordVerificationWorkFlowId = model.ApiBordVerificationWorkFlowId;
			DateTime? apiBordLinkAccFirstTransferDate = model.ApiBordLinkAccFirstTransferDate;
			DateTime? apiBordLinkAccLastTransferDate = model.ApiBordLinkAccLastTransferDate;
			int? apiBordCurrencyUnitIdI = model.ApiBordCurrencyUnitIdI;
			double? apiBordCurrencyUnitIRate = model.ApiBordCurrencyUnitIRate;
			int? userId2 = model.UserId;
			int? fPId = 0;
			short? month = value2;
			DateTime? registerDate = value;
			int? firstRegisterUserId = model.UserId;
			string firstRegisterDatePersian = text;
			cRMEntities2.ApispInsertBuyOrder(apiBuyOrderOprId, apiBordTitle, objectParameter2, apiBordOrderNumber, apiBordDate, apiBordOrderDate, apiBordOrderDateTime, apiBordCompanyId, apiBordCompanyNumber, apiBordCompanyCode, apiBordCompanyPersonId, apiBordProjectId, apiBordSubject, apiBordDiscount, apiBordTaxIndex, apiBordCalculateTax, apiBordIsVerified, apiBordStatusId, apiBordIsFixed, apiBordPrintFormatId, text, apiBordVerifierId, apiBordVerifiedRegisterDate, apiBordVerifiedRegisterDatePersian, apiBordSettlementTypeId, apiBordTime, apiBordTransportation, apiBordReferUserId, apiBordRound, apiBordDiscountTitle, apiBordNote, apiBordDateTime, apiBordImportDateTime, apiBordCmpTitle, apiBordCurrencyUnitId, apiBordFacilityCmpId, apiBordFacilityCmpNumber, apiBordFacilityCmpCode, apiBordFacilityPrsId, apiBordFacilityPrjId, apiBordReqCmpId, apiBordReqCmpNumber, apiBordReqCmpCode, apiBordReqPrsId, apiBordReqPrjId, apiBordDeliveryTerm, apiBordDeliveryDate, apiBordDeliveryDatePersian, apiBordTaxCleared, apiBordTaxClearedDate, apiBordTaxClearedDatePersian, apiBordFacilityCost, apiBordFacilityCostPercent2, apiBordSupplierDeliveryDate, apiBordSupplierDeliveryDatePersian, apiBordForwarderName, apiBordFreightCost, apiBordFreightCurrUnId, apiBordFreightCurrencyRate, apiBordFinalFreightCost, apiBordCustomsPart, apiBordCustomsFee, apiBordCustomsCurrUnId, apiBordCustomsCurrencyRate, apiBordFinalCustomsFee, apiBordFinalDeliveryDate, apiBordFinalDeliveryDatePersian, apiBordTotalFinalCost, apiBordCommission, apiBordCommissionCurrUnId, apiBordCommissionCurrencyRate, apiBordFinalCommission, apiBordCostSheetId, apiBordNumRef, apiBordDefaultSettingId, apiBordVerificationWorkFlowId, apiBordLinkAccFirstTransferDate, apiBordLinkAccLastTransferDate, apiBordCurrencyUnitIdI, apiBordCurrencyUnitIRate, userId2, fPId, month, registerDate, text, appType, firstRegisterUserId, value, firstRegisterDatePersian, currLangId, result, objectParameter, model.CenterId, model.CenterCode);
			if (objectParameter == null)
			{
				message = ResourceManager.GetMessage("ErrorDoneOperation", currLangId);
				data = null;
				status = ServiceResultStatus.Error;
			}
			else
			{
				int result4 = 0;
				int.TryParse(objectParameter.Value.ToString(), out result4);
				if (result4 > 0)
				{
					message = null;
					data = new IssueBuyOrderResultViewModel
					{
						BuyOrderId = result4,
						BuyOrderNumber = objectParameter2.Value.ToString()
					};
					status = ServiceResultStatus.Success;
				}
				else
				{
					switch (result4)
					{
					case -1:
						message = ResourceManager.GetMessage("msgErrorInsertToSqlTableCheckValues", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -10:
						message = ResourceManager.GetMessage("WrongBordDateTime", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -20:
						message = ResourceManager.GetMessage("NotExistsBuyOrderOprId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -30:
						message = ResourceManager.GetMessage("RequiredBordCompanyId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -40:
						message = ResourceManager.GetMessage("NotExistsBordCompanyId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -50:
						message = ResourceManager.GetMessage("RequiredBordCompanyPersonId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -60:
						message = ResourceManager.GetMessage("NotExistsBordCompanyPersonId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -70:
						message = ResourceManager.GetMessage("RequiredBordProjectId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -80:
						message = ResourceManager.GetMessage("NotExistsBordProjectId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -90:
						message = ResourceManager.GetMessage("NotExistsBordStatusId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -100:
						message = ResourceManager.GetMessage("NotExistsBordVerifierId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -110:
						message = ResourceManager.GetMessage("NotExistsBordReferUserId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -120:
						message = ResourceManager.GetMessage("RequiredBordCurrencyUnitId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -125:
						message = ResourceManager.GetMessage("NotExistsBordCurrencyUnitId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -130:
						message = ResourceManager.GetMessage("NotExistsBordFacilityCmpId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -140:
						message = ResourceManager.GetMessage("NotExistsBordFacilityPrsId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -150:
						message = ResourceManager.GetMessage("NotExistsBordFacilityPrjId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -160:
						message = ResourceManager.GetMessage("NotExistsBordReqCmpId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -170:
						message = ResourceManager.GetMessage("NotExistsBordReqPrsId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -180:
						message = ResourceManager.GetMessage("NotExistsBordReqPrjId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -190:
						message = ResourceManager.GetMessage("NotExistsBordFreightCurrUnId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -200:
						message = ResourceManager.GetMessage("NotExistsBordCustomsCurrUnId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -210:
						message = ResourceManager.GetMessage("NotExistsBordCommissionCurrUnId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -220:
						message = ResourceManager.GetMessage("NotExistsBordCostSheetId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -230:
						message = ResourceManager.GetMessage("NotExistsBordDefaultSettingId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -240:
						message = ResourceManager.GetMessage("NotExistsBordVerificationWorkFlowId", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					case -250:
						message = ResourceManager.GetMessage("NotExistsBordCurrencyUnitIdI", currLangId);
						data = null;
						status = ServiceResultStatus.Error;
						break;
					}
				}
			}
		}
		catch (DbEntityValidationException ex)
		{
			string text11 = ((!string.IsNullOrEmpty(((Exception)(object)ex).Message)) ? ((Exception)(object)ex).Message : "");
			if (((Exception)(object)ex).InnerException != null && !string.IsNullOrEmpty(((Exception)(object)ex).InnerException.Message))
			{
				text11 = text11 + " - " + ((Exception)(object)ex).InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text11)) ? (" (" + text11 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
		}
		catch (Exception ex2)
		{
			string text12 = ((!string.IsNullOrEmpty(ex2.Message)) ? ex2.Message : "");
			if (ex2.InnerException != null && !string.IsNullOrEmpty(ex2.InnerException.Message))
			{
				text12 = text12 + " - " + ex2.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text12)) ? (" (" + text12 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<IssueBuyOrderResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> InsertItem(InsertBuyOrderItemViewModel model)
	{
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0597: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
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
			CommonClass commonClass = new CommonClass();
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
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
			string text3 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text3 = apispSelectLanguages_Result.LanguageCollation;
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
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBordIPrdId == 0 && !string.IsNullOrWhiteSpace(model.ApiBordIPrdCode))
			{
				ApispSelectProductsWithIdOrCode_Result apispSelectProductsWithIdOrCode_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithIdOrCode_Result>((IEnumerable<ApispSelectProductsWithIdOrCode_Result>)cRMEntities.ApispSelectProductsWithIdOrCode(0, model.ApiBordIPrdCode, currLangId, result));
				if (apispSelectProductsWithIdOrCode_Result != null)
				{
					model.ApiBordIPrdId = apispSelectProductsWithIdOrCode_Result.ProductID;
				}
			}
			if (model.ApiBordIPrdId > 0)
			{
				try
				{
					bool result3 = false;
					bool result4 = false;
					bool result5 = false;
					ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)cRMEntities.ApispSelectProductsWithId(model.ApiBordIPrdId, currLangId, result));
					if (apispSelectProductsWithId_Result != null)
					{
						bool.TryParse(apispSelectProductsWithId_Result.PrdQtyNoFCR.ToString(), out result3);
						bool.TryParse(apispSelectProductsWithId_Result.PrdMustFullTracingCode.ToString(), out result4);
						bool.TryParse(apispSelectProductsWithId_Result.PrdSingleItem.ToString(), out result5);
					}
					List<ApispCheckUsedPrdSingleItemInBuyOrder_Result> list2 = Enumerable.ToList<ApispCheckUsedPrdSingleItemInBuyOrder_Result>((IEnumerable<ApispCheckUsedPrdSingleItemInBuyOrder_Result>)cRMEntities.ApispCheckUsedPrdSingleItemInBuyOrder(model.ApiBuyOrderId, 0, model.ApiBordIPrdId));
					if (list2 != null && Enumerable.Any<ApispCheckUsedPrdSingleItemInBuyOrder_Result>((IEnumerable<ApispCheckUsedPrdSingleItemInBuyOrder_Result>)list2))
					{
						if (result5)
						{
							return new ServiceResult<int>
							{
								Message = ResourceManager.GetMessage("msgErrorNoRegisterPrdSingleItemInBord", currLangId),
								Data = 0,
								Status = ServiceResultStatus.Error
							};
						}
						return new ServiceResult<int>
						{
							Message = ResourceManager.GetMessage("msgErrorNoRegisterPrdInBordWithSingleItem", currLangId),
							Data = 0,
							Status = ServiceResultStatus.Error
						};
					}
					if (model.ApiBordIQuantity.GetValueOrDefault() == 0f)
					{
						return new ServiceResult<int>
						{
							Message = string.Format(ResourceManager.GetMessage("ErrorIsNotEntered", currLangId), ResourceManager.GetLabel("Quantity", currLangId)),
							Data = 0,
							Status = ServiceResultStatus.Error
						};
					}
					bool flag = false;
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result2 = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result2 != null)
					{
						flag = apispSelectCrmsysSetting_Result2.MustFullTracingCode.HasValue && apispSelectCrmsysSetting_Result2.MustFullTracingCode != false;
					}
					if (flag)
					{
						if (string.IsNullOrWhiteSpace(model.ApiBordITracing))
						{
							return new ServiceResult<int>
							{
								Message = string.Format(ResourceManager.GetMessage("msgErrorIsNotSpecified", currLangId), ResourceManager.GetMessage("prdTracing", currLangId)),
								Data = 0,
								Status = ServiceResultStatus.Error
							};
						}
					}
					else if (result4 && string.IsNullOrWhiteSpace(model.ApiBordITracing))
					{
						return new ServiceResult<int>
						{
							Message = string.Format(ResourceManager.GetMessage("msgErrorIsNotSpecified", currLangId), ResourceManager.GetMessage("prdTracing", currLangId)),
							Data = 0,
							Status = ServiceResultStatus.Error
						};
					}
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.ApiBordIQuantityDesc_Lang))
					{
						list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordIQuantityDesc_Lang);
					}
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = model.ApiBordIQuantityDesc,
						LanguageId = currLangId
					});
					List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.ApiBordIDescription_Lang))
					{
						list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordIDescription_Lang);
					}
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = model.ApiBordIDescription,
						LanguageId = currLangId
					});
					List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.ApiBordIForwarderName_Lang))
					{
						list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordIForwarderName_Lang);
					}
					list5.Add(new CommonMultiLanguageViewModel
					{
						Value = model.ApiBordIForwarderName,
						LanguageId = currLangId
					});
					List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.ApiBordICustomsPart_Lang))
					{
						list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordICustomsPart_Lang);
					}
					list6.Add(new CommonMultiLanguageViewModel
					{
						Value = model.ApiBordICustomsPart,
						LanguageId = currLangId
					});
					List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.ApiBordIPrdNickname_Lang))
					{
						list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordIPrdNickname_Lang);
					}
					list7.Add(new CommonMultiLanguageViewModel
					{
						Value = model.ApiBordIPrdNickname,
						LanguageId = currLangId
					});
					double result6 = 1.0;
					double result7 = 1.0;
					if (result3)
					{
						result6 = 1.0;
						result7 = 1.0;
					}
					else
					{
						if (model.ApiBordIFCR.GetValueOrDefault() != 0f)
						{
							double.TryParse(model.ApiBordIFCR.ToString(), out result6);
						}
						if (model.ApiBordIFCRI.GetValueOrDefault() != 0f)
						{
							double.TryParse(model.ApiBordIFCRI.ToString(), out result7);
						}
					}
					double result8 = 0.0;
					double.TryParse(model.ApiBordIQuantityTotal.ToString(), out result8);
					decimal num2 = model.ApiBordIDiscount.GetValueOrDefault();
					decimal valueOrDefault = model.ApiBordICost.GetValueOrDefault();
					decimal valueOrDefault2 = model.ApiBordIRound.GetValueOrDefault();
					decimal valueOrDefault3 = model.ApiBordIRoundPlus.GetValueOrDefault();
					decimal valueOrDefault4 = model.ApiBordITax.GetValueOrDefault();
					decimal num3 = default(decimal);
					num3 = ((!(result8 > 0.0)) ? ((decimal)((double?)model.ApiBordIQuantity * result6 * result7).Value) : ((decimal)(result8 * result7)));
					if (model.ApiBordIDiscountSum.HasValue && num2 == 0m)
					{
						num2 = model.ApiBordIDiscountSum.GetValueOrDefault() / num3;
						model.ApiBordIDiscount = num2;
					}
					if (!model.ApiBordIDiscountSum.HasValue)
					{
						model.ApiBordIDiscountSum = num3 * num2;
					}
					decimal num4 = valueOrDefault - num2 - valueOrDefault2 + valueOrDefault3;
					decimal valueOrDefault5 = model.ApiBordIDiscountSum.GetValueOrDefault();
					decimal num5 = (valueOrDefault - valueOrDefault2 + valueOrDefault3) * num3 - valueOrDefault5;
					decimal.TryParse(model.ApiBordITaxIndex.ToString(), out var result9);
					if (result9 != 0m)
					{
						model.ApiBordITaxSum = num5 * result9 / 100m;
					}
					else
					{
						model.ApiBordITaxSum = num3 * valueOrDefault4;
					}
					if (model.ApiBordITaxSum.GetValueOrDefault() != 0m && model.ApiBordITax.GetValueOrDefault() == 0m)
					{
						model.ApiBordITax = model.ApiBordITaxSum / (decimal?)num3;
					}
					else if (model.ApiBordITaxSum.GetValueOrDefault() != 0m && model.ApiBordITaxIndex.GetValueOrDefault() == 0m)
					{
						model.ApiBordITaxIndex = model.ApiBordITaxSum * (decimal?)100 / (decimal?)num5;
					}
					if (model.ApiBordITax.GetValueOrDefault() != 0m && model.ApiBordITaxIndex.GetValueOrDefault() != 0m && model.ApiBordITaxSum.GetValueOrDefault() != 0m)
					{
						model.ApiBordICalculateTax = true;
					}
					else
					{
						model.ApiBordICalculateTax = false;
					}
					model.ApiBordICostSum = num5;
					model.ApiBordITotalCost = model.ApiBordICostSum + model.ApiBordITaxSum;
					decimal num6 = model.ApiBordIFacilityCost.GetValueOrDefault();
					decimal valueOrDefault6 = model.ApiBordITotalCost.GetValueOrDefault();
					decimal num7 = model.ApiBordIFacilityCostPercent.GetValueOrDefault();
					if (model.ApiBordIFacilityCostPercent.HasValue)
					{
						if (num7 > 0m)
						{
							num6 = Convert.ToDecimal(valueOrDefault6 * num7) / 100m;
						}
					}
					else if (num6 > 0m && valueOrDefault6 > 0m)
					{
						num7 = Convert.ToDecimal(Convert.ToDecimal(num6 * 100m) / valueOrDefault6);
					}
					decimal valueOrDefault7 = model.ApiBordIFreightCost.GetValueOrDefault();
					float valueOrDefault8 = model.ApiBordIFreightCurrencyRate.GetValueOrDefault(1f);
					decimal num8 = valueOrDefault7 * (decimal)valueOrDefault8;
					decimal valueOrDefault9 = model.ApiBordICustomsFee.GetValueOrDefault();
					float valueOrDefault10 = model.ApiBordICustomsCurrencyRate.GetValueOrDefault(1f);
					decimal num9 = valueOrDefault9 * (decimal)valueOrDefault10;
					decimal valueOrDefault11 = model.ApiBordICommission.GetValueOrDefault();
					float valueOrDefault12 = model.ApiBordICommissionCurrencyRate.GetValueOrDefault(1f);
					decimal num10 = valueOrDefault11 * (decimal)valueOrDefault12;
					decimal value3 = valueOrDefault6 + num6 + num8 + num9 + num10;
					model.ApiBordIFacilityCost = num6;
					model.ApiBordIFacilityCostPercent = num7;
					model.ApiBordIFreightCost = valueOrDefault7;
					model.ApiBordIFreightCurrencyRate = valueOrDefault8;
					model.ApiBordIFinalFreightCost = num8;
					model.ApiBordICustomsFee = valueOrDefault9;
					model.ApiBordICustomsCurrencyRate = valueOrDefault10;
					model.ApiBordIFinalCustomsFee = num9;
					model.ApiBordICommission = valueOrDefault11;
					model.ApiBordICommissionCurrencyRate = valueOrDefault12;
					model.ApiBordIFinalCommission = num10;
					bool result10 = false;
					ApispSelectCurrencyUnitsWithId_Result apispSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<ApispSelectCurrencyUnitsWithId_Result>((IEnumerable<ApispSelectCurrencyUnitsWithId_Result>)cRMEntities.ApispSelectCurrencyUnitsWithId(model.ApiBordICurrencyUnitId, currLangId, result));
					if (apispSelectCurrencyUnitsWithId_Result != null)
					{
						bool.TryParse(apispSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result10);
					}
					if (!result10)
					{
						if (model.ApiBordIDiscount.HasValue)
						{
							model.ApiBordIDiscount = RoundCalculation.RoundNumber(model.ApiBordIDiscount.GetValueOrDefault());
						}
						if (model.ApiBordITax.HasValue)
						{
							model.ApiBordITax = RoundCalculation.RoundNumber(model.ApiBordITax.GetValueOrDefault());
						}
						if (model.ApiBordITaxSum.HasValue)
						{
							model.ApiBordITaxSum = RoundCalculation.RoundNumber(model.ApiBordITaxSum.GetValueOrDefault());
						}
						if (model.ApiBordIDiscountSum.HasValue)
						{
							model.ApiBordIDiscountSum = RoundCalculation.RoundNumber(model.ApiBordIDiscountSum.GetValueOrDefault());
						}
					}
					string text4 = "";
					if (model.ApiBordITaxClearedDate.HasValue)
					{
						text4 = model.ApiBordITaxClearedDate?.ToString("yyyyMMdd", new PersianCulture());
					}
					if (IsFixed(model.ApiBuyOrderId))
					{
						return new ServiceResult<int>
						{
							Message = ResourceManager.GetMessage("msgErrorNotActiveBOrd", currLangId),
							Data = 0,
							Status = ServiceResultStatus.Error
						};
					}
					decimal? apiBordICost = model.ApiBordICost;
					model.ApiBordICost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordICost);
					apiBordICost = model.ApiBordIDiscountPercent;
					model.ApiBordIDiscountPercent = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIDiscountPercent);
					apiBordICost = model.ApiBordIDiscount;
					model.ApiBordIDiscount = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIDiscount);
					model.ApiBordIFCR = ((model.ApiBordIFCR == 0f) ? null : model.ApiBordIFCR);
					model.ApiBordIFCRI = ((model.ApiBordIFCRI == 0f) ? null : model.ApiBordIFCRI);
					model.ApiBordIQuantityTotal = ((model.ApiBordIQuantityTotal == 0f) ? null : model.ApiBordIQuantityTotal);
					model.ApiBordICalculateTax = ((model.ApiBordICalculateTax == false) ? null : model.ApiBordICalculateTax);
					apiBordICost = model.ApiBordITaxIndex;
					model.ApiBordITaxIndex = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordITaxIndex);
					apiBordICost = model.ApiBordITax;
					model.ApiBordITax = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordITax);
					model.ApiBordIPrdUnitId = ((model.ApiBordIPrdUnitId == 0) ? null : model.ApiBordIPrdUnitId);
					model.ApiBordICurrencyUnitId = ((model.ApiBordICurrencyUnitId == 0) ? null : model.ApiBordICurrencyUnitId);
					if (CanUpdateBuyOrderItemTracing(model.ApiBordIWHId, model.ApiBordIPrdId, model.ApiBordITracing) == 1)
					{
						model.ApiBordITracing = ((!string.IsNullOrWhiteSpace(model.ApiBordITracing)) ? model.ApiBordITracing : null);
					}
					apiBordICost = model.ApiBordITaxSum;
					model.ApiBordITaxSum = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordITaxSum);
					apiBordICost = model.ApiBordIDiscountSum;
					model.ApiBordIDiscountSum = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIDiscountSum);
					apiBordICost = model.ApiBordICostSum;
					model.ApiBordICostSum = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordICostSum);
					apiBordICost = model.ApiBordIFacilityCost;
					model.ApiBordIFacilityCost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFacilityCost);
					apiBordICost = model.ApiBordIFacilityCostPercent;
					model.ApiBordIFacilityCostPercent = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFacilityCostPercent);
					apiBordICost = model.ApiBordIFreightCost;
					model.ApiBordIFreightCost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFreightCost);
					model.ApiBordIFreightCurrencyRate = ((model.ApiBordIFreightCurrencyRate == 0f) ? null : model.ApiBordIFreightCurrencyRate);
					apiBordICost = model.ApiBordIFinalFreightCost;
					model.ApiBordIFinalFreightCost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFinalFreightCost);
					apiBordICost = model.ApiBordICustomsFee;
					model.ApiBordICustomsFee = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordICustomsFee);
					model.ApiBordICustomsCurrencyRate = ((model.ApiBordICustomsCurrencyRate == 0f) ? null : model.ApiBordICustomsCurrencyRate);
					apiBordICost = model.ApiBordIFinalCustomsFee;
					model.ApiBordIFinalCustomsFee = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFinalCustomsFee);
					model.ApiBordITotalFinalCost = value3;
					apiBordICost = model.ApiBordICommission;
					model.ApiBordICommission = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordICommission);
					model.ApiBordICommissionCurrencyRate = ((model.ApiBordICommissionCurrencyRate == 0f) ? null : model.ApiBordICommissionCurrencyRate);
					apiBordICost = model.ApiBordIFinalCommission;
					model.ApiBordIFinalCommission = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFinalCommission);
					List<ApispSelectBuyOrderItems_Result> list8 = Enumerable.ToList<ApispSelectBuyOrderItems_Result>((IEnumerable<ApispSelectBuyOrderItems_Result>)cRMEntities.ApispSelectBuyOrderItems(0, model.ApiBuyOrderId, currLangId, result, null, null));
					int num11 = (Enumerable.Any<ApispSelectBuyOrderItems_Result>((IEnumerable<ApispSelectBuyOrderItems_Result>)list8) ? Enumerable.Count<ApispSelectBuyOrderItems_Result>((IEnumerable<ApispSelectBuyOrderItems_Result>)list8) : 0);
					if (model.ApiBordIOrderView.GetValueOrDefault() == 0)
					{
						model.ApiBordIOrderView = num11 + 1 + num11 * 4 - 1;
					}
					ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
					CRMEntities cRMEntities2 = cRMEntities;
					int? apiBuyOrderItemId = 0;
					int? apiBuyOrderId = model.ApiBuyOrderId;
					int? apiBordIPrdId = model.ApiBordIPrdId;
					string apiBordIPrdCode = model.ApiBordIPrdCode;
					double? apiBordIQuantity = model.ApiBordIQuantity;
					decimal? apiBordICost2 = model.ApiBordICost;
					decimal? apiBordITotalCost = model.ApiBordITotalCost;
					string apiBordIDescription = JsonConvert.SerializeObject(list4);
					string apiBordIQuantityDesc = JsonConvert.SerializeObject(list3);
					decimal? apiBordIDiscount = model.ApiBordIDiscount;
					decimal? apiBordIDiscountPercent = model.ApiBordIDiscountPercent;
					int? apiBordIPrdUnitId = model.ApiBordIPrdUnitId;
					int? apiBordICurrencyUnitId = model.ApiBordICurrencyUnitId;
					int? apiBordIOrderView = model.ApiBordIOrderView;
					double? apiBordIFCR = model.ApiBordIFCR;
					decimal? apiBordITax = model.ApiBordITax;
					decimal? apiBordITaxIndex = model.ApiBordITaxIndex;
					bool? apiBordICalculateTax = model.ApiBordICalculateTax;
					bool? apiBordINotVisible = model.ApiBordINotVisible;
					double? apiBordIFCRI = model.ApiBordIFCRI;
					bool? apiBordINotInSum = model.ApiBordINotInSum;
					int? apiBordIWHId = model.ApiBordIWHId;
					int? apiBordIPrdCostGroupID = model.ApiBordIPrdCostGroupID;
					string apiBordITracing = model.ApiBordITracing;
					decimal? apiBordICostSum = model.ApiBordICostSum;
					decimal? apiBordIDiscountSum = model.ApiBordIDiscountSum;
					decimal? apiBordITaxSum = model.ApiBordITaxSum;
					bool? apiBordITaxCleared = model.ApiBordITaxCleared;
					DateTime? apiBordITaxClearedDate = model.ApiBordITaxClearedDate;
					string apiBordITaxClearedDatePersian = text4;
					decimal? apiBordIFacilityCost = model.ApiBordIFacilityCost;
					decimal? apiBordIFacilityCostPercent = model.ApiBordIFacilityCostPercent;
					string apiBordIForwarderName = JsonConvert.SerializeObject(list5);
					decimal? apiBordIFreightCost = model.ApiBordIFreightCost;
					int? apiBordIFreightCurrUnId = model.ApiBordIFreightCurrUnId;
					double? apiBordIFreightCurrencyRate = model.ApiBordIFreightCurrencyRate;
					decimal? apiBordIFinalFreightCost = model.ApiBordIFinalFreightCost;
					string apiBordICustomsPart = JsonConvert.SerializeObject(list6);
					decimal? apiBordICustomsFee = model.ApiBordICustomsFee;
					int? apiBordICustomsCurrUnId = model.ApiBordICustomsCurrUnId;
					double? apiBordICustomsCurrencyRate = model.ApiBordICustomsCurrencyRate;
					decimal? apiBordIFinalCustomsFee = model.ApiBordIFinalCustomsFee;
					decimal? apiBordITotalFinalCost = model.ApiBordITotalFinalCost;
					decimal? apiBordICommission = model.ApiBordICommission;
					int? apiBordICommissionCurrUnId = model.ApiBordICommissionCurrUnId;
					double? apiBordICommissionCurrencyRate = model.ApiBordICommissionCurrencyRate;
					decimal? apiBordIFinalCommission = model.ApiBordIFinalCommission;
					int? apiBordICostSheetItemId = model.ApiBordICostSheetItemId;
					double? apiBordIQuantityTotal = model.ApiBordIQuantityTotal;
					int? apiBordIPrdUnitIdI = model.ApiBordIPrdUnitIdI;
					double? apiBordIPrdUnitIRateResult = model.ApiBordIPrdUnitIRateResult;
					int? apiBordIPrdColorId = model.ApiBordIPrdColorId;
					string apiBordIPrdNickname = JsonConvert.SerializeObject(list7);
					DateTime? apiBordILinkAccFirstTransferDate = model.ApiBordILinkAccFirstTransferDate;
					DateTime? apiBordILinkAccLastTransferDate = model.ApiBordILinkAccLastTransferDate;
					int? firstRegisterUserId = model.UserId;
					DateTime? firstRegisterDate = value;
					int num12 = cRMEntities2.ApispInsertBuyOrderItem(apiBuyOrderItemId, apiBuyOrderId, apiBordIPrdId, apiBordIPrdCode, apiBordIQuantity, apiBordICost2, apiBordITotalCost, apiBordIDescription, apiBordIQuantityDesc, apiBordIDiscount, apiBordIDiscountPercent, apiBordIPrdUnitId, apiBordICurrencyUnitId, apiBordIOrderView, apiBordIFCR, apiBordITax, apiBordITaxIndex, apiBordICalculateTax, apiBordINotVisible, apiBordIFCRI, apiBordINotInSum, apiBordIWHId, apiBordIPrdCostGroupID, apiBordITracing, apiBordICostSum, apiBordIDiscountSum, apiBordITaxSum, apiBordITaxCleared, apiBordITaxClearedDate, apiBordITaxClearedDatePersian, apiBordIFacilityCost, apiBordIFacilityCostPercent, apiBordIForwarderName, apiBordIFreightCost, apiBordIFreightCurrUnId, apiBordIFreightCurrencyRate, apiBordIFinalFreightCost, apiBordICustomsPart, apiBordICustomsFee, apiBordICustomsCurrUnId, apiBordICustomsCurrencyRate, apiBordIFinalCustomsFee, apiBordITotalFinalCost, apiBordICommission, apiBordICommissionCurrUnId, apiBordICommissionCurrencyRate, apiBordIFinalCommission, apiBordICostSheetItemId, apiBordIQuantityTotal, apiBordIPrdUnitIdI, apiBordIPrdUnitIRateResult, apiBordIPrdColorId, apiBordIPrdNickname, apiBordILinkAccFirstTransferDate, apiBordILinkAccLastTransferDate, firstRegisterUserId, text, firstRegisterDate, model.UserId, 0, value2, value, text, appType, currLangId, result, objectParameter, model.CenterId, model.CenterCode);
					int result11 = 0;
					int.TryParse(objectParameter.Value.ToString(), out result11);
					if (result11 > 0)
					{
						try
						{
							if (model.ApiAddLinkedPrd.HasValue && model.ApiAddLinkedPrd.GetValueOrDefault() && !result5)
							{
								DateTime now2 = DateTime.Now;
								string text5 = now2.ToString("yyyyMMdd", new PersianCulture());
								short value4 = short.Parse(now2.ToString("MM", new PersianCulture()));
								mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispInsertBuyOrderItemFromLinkedPrd(model.ApiBordIPrdId, model.ApiBuyOrderId, model.ApiBordIPrdCostGroupID, model.ApiBordIWHId, model.UserId, 0, value4, now2, text5, appType, result, "", centerId: model.CenterId, buyOrderItemId: result11));
								if (mct_Result != null && mct_Result.Result == 0)
								{
									message = ResourceManager.GetMessage("msgErrorInAddLinkedPrd", currLangId);
									data = 0;
									status = ServiceResultStatus.Error;
								}
							}
							else
							{
								message = null;
								data = result11;
								status = ServiceResultStatus.Success;
							}
						}
						catch (Exception)
						{
							message = ResourceManager.GetMessage("msgErrorInCalculation", currLangId);
							data = 0;
							status = ServiceResultStatus.Error;
						}
					}
					else
					{
						switch (result11)
						{
						case -1:
							message = ResourceManager.GetMessage("msgErrorInsertToSqlTableCheckValues", currLangId);
							data = 0;
							status = ServiceResultStatus.Error;
							break;
						case -2:
							message = ResourceManager.GetMessage("msgErrorInCalculation", currLangId);
							data = 0;
							status = ServiceResultStatus.Error;
							break;
						}
					}
				}
				catch (Exception ex2)
				{
					string text6 = ((!string.IsNullOrEmpty(ex2.Message)) ? ex2.Message : "");
					if (ex2.InnerException != null && !string.IsNullOrEmpty(ex2.InnerException.Message))
					{
						text6 = text6 + " - " + ex2.InnerException.Message;
					}
					message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text6)) ? (" (" + text6 + ")") : "");
					data = 0;
					status = ServiceResultStatus.Error;
					ErrorSignal.FromCurrentContext().Raise(ex2);
				}
			}
			else
			{
				message = Messages.msgErrorNotSelectProduct;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex3)
		{
			string text7 = ((!string.IsNullOrEmpty(ex3.Message)) ? ex3.Message : "");
			if (ex3.InnerException != null && !string.IsNullOrEmpty(ex3.InnerException.Message))
			{
				text7 = text7 + " - " + ex3.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text7)) ? (" (" + text7 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex3);
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
	public ServiceResult<int> InsertPayment(InsertBuyOrderPaymentViewModel model)
	{
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
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
			CommonClass commonClass = new CommonClass();
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
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
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (!model.ApiImportDateTime.HasValue)
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("EmptyBordPaymentImportDate", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBordpayTypeId <= 0)
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("EmptyBordPaymentTypeId", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBordpayAmount <= 0m)
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("EmptyBordPaymentAmount", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (!model.ApiBordpayDocDateTime.HasValue)
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("EmptyBordPaymentDocDate", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			try
			{
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiBordpayDescription_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordpayDescription_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiBordpayDescription,
					LanguageId = currLangId
				});
				ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
				int num2 = cRMEntities.ApispInsertBuyOrderPayments(model.ApiImportDateTime?.ToString("yyyyMMdd", new PersianCulture()), model.ApiImportDateTime, model.ApiBordpayTypeId, model.ApiBordpayOrderId, null, null, model.ApiBordpayAmount, model.ApiBordpayDocNumber, model.ApiBordpayDocDateTime?.ToString("yyyyMMdd", new PersianCulture()), apiBordpayDescription: JsonConvert.SerializeObject(list2), apiBordpayDocDateTime: model.ApiBordpayDocDateTime, apiBordpayDocAmount: model.ApiBordpayDocAmount, apiBordpayDeActive: model.ApiBordpayDeActive, apiBordpayAccountNumber: model.ApiBordpayAccountNumber, apiBordpayAmountTemp: model.ApiBordpayAmountTemp, apiBordpayDocDateTemp: model.ApiBordpayDocDateTimeTemp?.ToString("yyyyMMdd", new PersianCulture()), apiBordpayDocDateTimeTemp: model.ApiBordpayDocDateTimeTemp, userId: model.UserId, fPId: 0, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: currLangId, defaultLanguageID: result, insertedId: objectParameter, centerId: model.CenterId, centerCode: model.CenterCode);
				if (objectParameter == null)
				{
					return new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("ErrorDoneOperation", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				int num3 = int.Parse(objectParameter.Value?.ToString());
				if (num3 > 0)
				{
					return new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("msgSuccessAction", currLangId),
						Data = num3,
						Status = ServiceResultStatus.Success
					};
				}
				return num3 switch
				{
					-1 => new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("msgErrorInsertToSqlTableCheckValues", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Fail
					}, 
					-2 => new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("NotExistsBordPaymentTypeId", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Fail
					}, 
					_ => new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("ErrorDoneOperation", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Error
					}, 
				};
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
		}
		catch (Exception ex2)
		{
			string text4 = ((!string.IsNullOrEmpty(ex2.Message)) ? ex2.Message : "");
			if (ex2.InnerException != null && !string.IsNullOrEmpty(ex2.InnerException.Message))
			{
				text4 = text4 + " - " + ex2.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text4)) ? (" (" + text4 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
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
	public ServiceResult<int> InsertItemSerial(InsertBuyOrderItemSerialViewModel model)
	{
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
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
			CommonClass commonClass = new CommonClass();
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
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
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (string.IsNullOrWhiteSpace(model.ApiSerial))
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("EmptyBuyOrder", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			ApispSelectBuyOrderItems_Result apispSelectBuyOrderItems_Result = Enumerable.FirstOrDefault<ApispSelectBuyOrderItems_Result>((IEnumerable<ApispSelectBuyOrderItems_Result>)cRMEntities.ApispSelectBuyOrderItems(model.ApiBuyOrderItemId, 0, currLangId, result, model.CenterId, model.CenterCode));
			if (apispSelectBuyOrderItems_Result != null)
			{
				ApifnCheckDuplicateBuyOrderPrdSerial_Result apifnCheckDuplicateBuyOrderPrdSerial_Result = Enumerable.FirstOrDefault<ApifnCheckDuplicateBuyOrderPrdSerial_Result>((IEnumerable<ApifnCheckDuplicateBuyOrderPrdSerial_Result>)Enumerable.ToList<ApifnCheckDuplicateBuyOrderPrdSerial_Result>((IEnumerable<ApifnCheckDuplicateBuyOrderPrdSerial_Result>)cRMEntities.ApifnCheckDuplicateBuyOrderPrdSerial(apispSelectBuyOrderItems_Result.ApiBordIPrdId, model.ApiSerial, 0, apispSelectBuyOrderItems_Result.ApiBordIWHId)));
				if (apifnCheckDuplicateBuyOrderPrdSerial_Result != null)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("msgErrorDuplicateSerialNumberInBuyOrder", currLangId) + apifnCheckDuplicateBuyOrderPrdSerial_Result.bordNumber + ResourceManager.GetMessage("msgErrorDuplicateSerialNumberInBuyOrder1", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
					serviceResult.Message = serviceResult.Message.Replace("<br>", "\r\n").Replace("</br>", "\r\n").Replace("<br/>", "\r\n");
					return serviceResult;
				}
			}
			try
			{
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiDescription_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiDescription_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiDescription,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoI_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoI_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoI,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoII_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoII_Lang);
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoII,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoIII_Lang))
				{
					list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoIII_Lang);
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoIII,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoIV_Lang))
				{
					list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoIV_Lang);
				}
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoIV,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoV_Lang))
				{
					list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoV_Lang);
				}
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoV,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoVI_Lang))
				{
					list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoVI_Lang);
				}
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoVI,
					LanguageId = currLangId
				});
				ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
				int num2 = cRMEntities.ApispInsertBuyOrderItemSerials(model.ApiBuyOrderItemId, model.ApiSerial, JsonConvert.SerializeObject(list2), model.ApiExpDate, model.ApiExpDate?.ToString("yyyyMMdd", new PersianCulture()), JsonConvert.SerializeObject(list3), JsonConvert.SerializeObject(list4), JsonConvert.SerializeObject(list5), JsonConvert.SerializeObject(list6), JsonConvert.SerializeObject(list7), JsonConvert.SerializeObject(list8), model.UserId, 0, value2, value, registerDatePersian, appType, currLangId, result, objectParameter, model.CenterId, model.CenterCode);
				if (objectParameter == null)
				{
					return new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("ErrorDoneOperation", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				int num3 = int.Parse(objectParameter.Value?.ToString());
				if (num3 > 0)
				{
					return new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("msgSuccessAction", currLangId),
						Data = num3,
						Status = ServiceResultStatus.Success
					};
				}
				return num3 switch
				{
					-1 => new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("msgErrorInsertToSqlTableCheckValues", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Fail
					}, 
					-2 => new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("NotExistsBordItem", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Fail
					}, 
					-3 => new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("ErrorBordIsFixed", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Fail
					}, 
					_ => new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("ErrorDoneOperation", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Error
					}, 
				};
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
		}
		catch (Exception ex2)
		{
			string text4 = ((!string.IsNullOrEmpty(ex2.Message)) ? ex2.Message : "");
			if (ex2.InnerException != null && !string.IsNullOrEmpty(ex2.InnerException.Message))
			{
				text4 = text4 + " - " + ex2.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text4)) ? (" (" + text4 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
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
	public ServiceResult<List<ApispSelectBuyOrder_Result>> Select(SelectBuyOrderViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectBuyOrder_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectBuyOrder_Result>>
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
				return new ServiceResult<List<ApispSelectBuyOrder_Result>>
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
				return new ServiceResult<List<ApispSelectBuyOrder_Result>>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			DateTime value5 = DateTime.Now;
			DateTime value6 = DateTime.Now;
			try
			{
				if (!string.IsNullOrEmpty(model.FromDate))
				{
					model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value5 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi = PersianDate.GetShamsi2Miladi(model.FromDate);
						value5 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<List<ApispSelectBuyOrder_Result>> result3 = new ServiceResult<List<ApispSelectBuyOrder_Result>>
				{
					Message = string.Format(ResourceManager.GetMessage("ErrorFormat", currLangId), ResourceManager.GetLabel("FromDate", currLangId)) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
				cRMEntities?.Dispose();
				return result3;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ToDate))
				{
					model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value6 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi2 = PersianDate.GetShamsi2Miladi(model.ToDate);
						value6 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi2) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<List<ApispSelectBuyOrder_Result>> result4 = new ServiceResult<List<ApispSelectBuyOrder_Result>>
				{
					Message = string.Format(ResourceManager.GetMessage("ErrorFormat", currLangId), ResourceManager.GetLabel("ToDate", currLangId)) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
				cRMEntities?.Dispose();
				return result4;
			}
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
						string shamsi2Miladi3 = PersianDate.GetShamsi2Miladi(model.FromRegisterDate);
						value = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi3) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				ServiceResult<List<ApispSelectBuyOrder_Result>> result5 = new ServiceResult<List<ApispSelectBuyOrder_Result>>
				{
					Message = string.Format(ResourceManager.GetMessage("ErrorFormat", currLangId), ResourceManager.GetLabel("FromRegisterDate", currLangId)) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
				cRMEntities?.Dispose();
				return result5;
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
						string shamsi2Miladi4 = PersianDate.GetShamsi2Miladi(model.ToRegisterDate);
						value2 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi4) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				ServiceResult<List<ApispSelectBuyOrder_Result>> result6 = new ServiceResult<List<ApispSelectBuyOrder_Result>>
				{
					Message = string.Format(ResourceManager.GetMessage("ErrorFormat", currLangId), ResourceManager.GetLabel("ToRegisterDate", currLangId)) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
				cRMEntities?.Dispose();
				return result6;
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
						string shamsi2Miladi5 = PersianDate.GetShamsi2Miladi(model.FromFirstRegisterDate);
						value3 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi5) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
				ServiceResult<List<ApispSelectBuyOrder_Result>> result7 = new ServiceResult<List<ApispSelectBuyOrder_Result>>
				{
					Message = string.Format(ResourceManager.GetMessage("ErrorFormat", currLangId), ResourceManager.GetLabel("FromFirstRegisterDate", currLangId)) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
				cRMEntities?.Dispose();
				return result7;
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
						string shamsi2Miladi6 = PersianDate.GetShamsi2Miladi(model.ToFirstRegisterDate);
						value4 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi6) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e6)
			{
				ErrorSignal.FromCurrentContext().Raise(e6);
				ServiceResult<List<ApispSelectBuyOrder_Result>> result8 = new ServiceResult<List<ApispSelectBuyOrder_Result>>
				{
					Message = string.Format(ResourceManager.GetMessage("ErrorFormat", currLangId), ResourceManager.GetLabel("ToFirstRegisterDate", currLangId)) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
				cRMEntities?.Dispose();
				return result8;
			}
			List<ApispSelectBuyOrder_Result> list2 = Enumerable.ToList<ApispSelectBuyOrder_Result>((IEnumerable<ApispSelectBuyOrder_Result>)cRMEntities.ApispSelectBuyOrder(model.BuyOrdId, model.BuyOrdNumber, fromRegisterDate: (!string.IsNullOrEmpty(model.FromRegisterDate)) ? new DateTime?(value) : null, toRegisterDate: (!string.IsNullOrEmpty(model.ToRegisterDate)) ? new DateTime?(value2) : null, fromFirstRegisterDate: (!string.IsNullOrEmpty(model.FromFirstRegisterDate)) ? new DateTime?(value3) : null, toFirstRegisterDate: (!string.IsNullOrEmpty(model.ToFirstRegisterDate)) ? new DateTime?(value4) : null, fromDate: (!string.IsNullOrEmpty(model.FromDate)) ? new DateTime?(value5) : null, toDate: (!string.IsNullOrEmpty(model.ToDate)) ? new DateTime?(value6) : null, languageID: currLangId, defaultLanguageID: result, centerId: model.CenterId, centerCode: model.CenterCode));
			if (list2 != null)
			{
				message = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = ResourceManager.GetMessage("ErrorNotFound", currLangId);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectBuyOrder_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> Update(UpdateBuyOrderViewModel model)
	{
		//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0819: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		CRMEntities cRMEntities = null;
		int data = 0;
		string text = "";
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
			CommonClass commonClass = new CommonClass();
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
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
			string text3 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text3 = apispSelectLanguages_Result.LanguageCollation;
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
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBuyOrderOprId <= 0)
			{
				model.ApiBuyOrderOprId = null;
			}
			if (model.ApiBordNumber <= 0)
			{
				model.ApiBordNumber = null;
			}
			if (model.ApiBordCompanyPersonId <= 0)
			{
				model.ApiBordCompanyPersonId = null;
			}
			if (model.ApiBordProjectId <= 0)
			{
				model.ApiBordProjectId = null;
			}
			if (model.ApiBordStatusId <= 0)
			{
				model.ApiBordStatusId = null;
			}
			if (model.ApiBordPrintFormatId <= 0)
			{
				model.ApiBordPrintFormatId = null;
			}
			if (model.ApiBordVerifierId <= 0)
			{
				model.ApiBordVerifierId = null;
			}
			if (model.ApiBordReferUserId.GetValueOrDefault() <= 0)
			{
				model.ApiBordReferUserId = model.UserId;
			}
			if (model.ApiBordCurrencyUnitId <= 0)
			{
				model.ApiBordCurrencyUnitId = null;
			}
			if (model.ApiBordFacilityCmpId <= 0)
			{
				model.ApiBordFacilityCmpId = null;
			}
			if (model.ApiBordFacilityPrsId <= 0)
			{
				model.ApiBordFacilityPrsId = null;
			}
			if (model.ApiBordFacilityPrjId <= 0)
			{
				model.ApiBordFacilityPrjId = null;
			}
			if (model.ApiBordReqCmpId <= 0)
			{
				model.ApiBordReqCmpId = null;
			}
			if (model.ApiBordReqPrsId <= 0)
			{
				model.ApiBordReqPrsId = null;
			}
			if (model.ApiBordReqPrjId <= 0)
			{
				model.ApiBordReqPrjId = null;
			}
			if (model.ApiBordFreightCurrUnId <= 0)
			{
				model.ApiBordFreightCurrUnId = null;
			}
			if (model.ApiBordCustomsCurrUnId <= 0)
			{
				model.ApiBordCustomsCurrUnId = null;
			}
			if (model.ApiBordCommissionCurrUnId <= 0)
			{
				model.ApiBordCommissionCurrUnId = null;
			}
			if (model.ApiBordCostSheetId <= 0)
			{
				model.ApiBordCostSheetId = null;
			}
			if (model.ApiBordDefaultSettingId <= 0)
			{
				model.ApiBordDefaultSettingId = null;
			}
			if (model.ApiBordVerificationWorkFlowId <= 0)
			{
				model.ApiBordVerificationWorkFlowId = null;
			}
			if (model.ApiBordCurrencyUnitIdI <= 0)
			{
				model.ApiBordCurrencyUnitIdI = null;
			}
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordTitle_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordTitle_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordTitle,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordSubject_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordSubject_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordSubject,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordNote_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordNote_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordNote,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordCmpTitle_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordCmpTitle_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordCmpTitle,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordDiscountTitle_Lang))
			{
				list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordDiscountTitle_Lang);
			}
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordDiscountTitle,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordDeliveryTerm_Lang))
			{
				list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordDeliveryTerm_Lang);
			}
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordDeliveryTerm,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordForwarderName_Lang))
			{
				list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordForwarderName_Lang);
			}
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordForwarderName,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiBordCustomsPart_Lang))
			{
				list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordCustomsPart_Lang);
			}
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ApiBordCustomsPart,
				LanguageId = currLangId
			});
			string text4 = "";
			if (model.ApiBordOrderDateTime.HasValue)
			{
				text4 = model.ApiBordOrderDateTime?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text5 = "";
			if (model.ApiBordDateTime.HasValue)
			{
				text5 = model.ApiBordDateTime?.ToString("yyyyMMdd", new PersianCulture());
			}
			if (text5 == "")
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("WrongBordDateTime", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			string text6 = "";
			if (model.ApiBordVerifiedRegisterDate.HasValue)
			{
				text6 = model.ApiBordVerifiedRegisterDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text7 = "";
			if (model.ApiBordTaxClearedDate.HasValue)
			{
				text7 = model.ApiBordTaxClearedDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text8 = "";
			if (model.ApiBordDeliveryDate.HasValue)
			{
				text8 = model.ApiBordDeliveryDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text9 = "";
			if (model.ApiBordSupplierDeliveryDate.HasValue)
			{
				text9 = model.ApiBordSupplierDeliveryDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			string text10 = "";
			if (model.ApiBordFinalDeliveryDate.HasValue)
			{
				text10 = model.ApiBordFinalDeliveryDate?.ToString("yyyyMMdd", new PersianCulture());
			}
			model.ApiBordTransportation = model.ApiBordTransportation.GetValueOrDefault();
			model.ApiBordRound = model.ApiBordRound.GetValueOrDefault();
			model.ApiBordDiscount = model.ApiBordDiscount.GetValueOrDefault();
			model.ApiBordCompanyPersonId = ((model.ApiBordCompanyPersonId <= 0) ? null : model.ApiBordCompanyPersonId);
			model.ApiBordFacilityCost = model.ApiBordFacilityCost.GetValueOrDefault();
			decimal? apiBordFacilityCostPercent = model.ApiBordFacilityCostPercent;
			model.ApiBordFacilityCostPercent = (((apiBordFacilityCostPercent.GetValueOrDefault() == default(decimal)) & apiBordFacilityCostPercent.HasValue) ? null : model.ApiBordFacilityCostPercent);
			model.ApiBordFreightCost = model.ApiBordFreightCost.GetValueOrDefault();
			model.ApiBordFinalFreightCost = model.ApiBordFinalFreightCost.GetValueOrDefault();
			model.ApiBordCustomsFee = model.ApiBordCustomsFee.GetValueOrDefault();
			model.ApiBordFinalCustomsFee = model.ApiBordFinalCustomsFee.GetValueOrDefault();
			model.ApiBordCommission = model.ApiBordCommission.GetValueOrDefault();
			model.ApiBordFinalCommission = model.ApiBordFinalCommission.GetValueOrDefault();
			decimal valueOrDefault = model.ApiBordFacilityCost.GetValueOrDefault();
			decimal valueOrDefault2 = model.ApiBordFreightCost.GetValueOrDefault();
			float valueOrDefault3 = model.ApiBordFreightCurrencyRate.GetValueOrDefault(1f);
			decimal num2 = valueOrDefault2 * (decimal)valueOrDefault3;
			decimal valueOrDefault4 = model.ApiBordCustomsFee.GetValueOrDefault();
			float valueOrDefault5 = model.ApiBordCustomsCurrencyRate.GetValueOrDefault(1f);
			decimal num3 = valueOrDefault4 * (decimal)valueOrDefault5;
			decimal valueOrDefault6 = model.ApiBordCommission.GetValueOrDefault();
			float valueOrDefault7 = model.ApiBordCommissionCurrencyRate.GetValueOrDefault(1f);
			decimal num4 = valueOrDefault6 * (decimal)valueOrDefault7;
			decimal value3 = valueOrDefault + num2 + num3 + num4;
			model.ApiBordFacilityCost = valueOrDefault;
			model.ApiBordFreightCost = valueOrDefault2;
			model.ApiBordFreightCurrencyRate = valueOrDefault3;
			model.ApiBordFinalFreightCost = num2;
			model.ApiBordCustomsFee = valueOrDefault4;
			model.ApiBordCustomsCurrencyRate = valueOrDefault5;
			model.ApiBordFinalCustomsFee = num3;
			model.ApiBordCommission = valueOrDefault6;
			model.ApiBordCommissionCurrencyRate = valueOrDefault7;
			model.ApiBordFinalCommission = num4;
			model.ApiBordTotalFinalCost = value3;
			if (model.ApiBordNumber.HasValue)
			{
				long result3 = 0L;
				long.TryParse(model.ApiBordNumber.ToString(), out result3);
				long num5 = CheckDuplicateBuyOrderNumber(result3, model.ApiBuyOrderId, model.ApiBuyOrderOprId, model.CenterId, model.CenterCode);
				if (num5 > 0)
				{
					return new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("BuyOrderNumberIsRepeated", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num6 = cRMEntities.ApispUpdateBuyOrder(model.ApiBuyOrderId, model.ApiBuyOrderOprId, JsonConvert.SerializeObject(list2), model.ApiBordNumber, model.ApiBordOrderNumber, model.ApiBordDateTime.ToString(), model.ApiBordOrderDateTime?.ToString(), model.ApiBordCompanyId, model.ApiBordCompanyPersonId, model.ApiBordProjectId, JsonConvert.SerializeObject(list3), model.ApiBordDiscount, model.ApiBordTaxIndex, model.ApiBordCalculateTax, model.ApiBordIsVerified, model.ApiBordStatusId, model.ApiBordIsFixed, model.ApiBordPrintFormatId, value.ToString(), model.ApiBordVerifierId, model.ApiBordVerifiedRegisterDate?.ToString(), model.ApiBordSettlementTypeId, model.ApiBordDateTime?.ToString("HH:mm:ss", new PersianCulture()), model.ApiBordTransportation, model.ApiBordReferUserId, model.ApiBordRound, JsonConvert.SerializeObject(list6), JsonConvert.SerializeObject(list4), JsonConvert.SerializeObject(list5), model.ApiBordCurrencyUnitId, model.ApiBordFacilityCmpId, model.ApiBordFacilityPrsId, model.ApiBordFacilityPrjId, model.ApiBordReqCmpId, model.ApiBordReqPrsId, model.ApiBordReqPrjId, JsonConvert.SerializeObject(list7), model.ApiBordDeliveryDate?.ToString(), model.ApiBordTaxCleared, model.ApiBordTaxClearedDate?.ToString(), model.ApiBordFacilityCost, model.ApiBordFacilityCostPercent, model.ApiBordSupplierDeliveryDate?.ToString(), JsonConvert.SerializeObject(list8), model.ApiBordFreightCost, model.ApiBordFreightCurrUnId, model.ApiBordFreightCurrencyRate, model.ApiBordFinalFreightCost, JsonConvert.SerializeObject(list9), model.ApiBordCustomsFee, model.ApiBordCustomsCurrUnId, model.ApiBordCustomsCurrencyRate, model.ApiBordFinalCustomsFee, model.ApiBordFinalDeliveryDate?.ToString(), model.ApiBordTotalFinalCost, model.ApiBordCommission, model.ApiBordCommissionCurrUnId, model.ApiBordCommissionCurrencyRate, model.ApiBordFinalCommission, model.ApiBordCostSheetId, model.ApiBordNumRef, model.ApiBordDefaultSettingId, model.ApiBordVerificationWorkFlowId, model.ApiBordLinkAccFirstTransferDate, model.ApiBordLinkAccLastTransferDate, model.ApiBordCurrencyUnitIdI, model.ApiBordCurrencyUnitIRate, model.UserId, value2, value, registerDatePersian, appType, currLangId, result, objectParameter, model.CenterId, model.CenterCode);
			int result4 = 0;
			int.TryParse(num6.ToString(), out result4);
			if (result4 < 0 && objectParameter.Value == null)
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("ErrorDoneOperationTryAgain", currLangId).Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter != null && !string.IsNullOrWhiteSpace((string)objectParameter.Value))
			{
				List<SelectListItem> list10 = new List<SelectListItem>();
				list10.Add(new SelectListItem
				{
					Text = "Emp BordDateTime",
					Value = ResourceManager.GetMessage("WrongBordDateTime", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "IsFixed",
					Value = ResourceManager.GetMessage("ErrorBordIsFixed", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BuyOrderOprId",
					Value = ResourceManager.GetMessage("NotExistsBuyOrderOprId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "Emp BordCompanyId",
					Value = ResourceManager.GetMessage("RequiredBordCompanyId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordCompanyId",
					Value = ResourceManager.GetMessage("NotExistsBordCompanyId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordCompanyPersonId",
					Value = ResourceManager.GetMessage("NotExistsBordCompanyPersonId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordProjectId",
					Value = ResourceManager.GetMessage("NotExistsBordProjectId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordStatusId",
					Value = ResourceManager.GetMessage("NotExistsBordStatusId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordPrintFormatId",
					Value = ResourceManager.GetMessage("NotExistsBordPrintFormatId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordVerifierId",
					Value = ResourceManager.GetMessage("NotExistsBordVerifierId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordReferUserId",
					Value = ResourceManager.GetMessage("NotExistsBordReferUserId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordCurrencyUnitId",
					Value = ResourceManager.GetMessage("NotExistsBordCurrencyUnitId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordFacilityCmpId",
					Value = ResourceManager.GetMessage("NotExistsBordFacilityCmpId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordFacilityPrsId",
					Value = ResourceManager.GetMessage("NotExistsBordFacilityPrsId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordFacilityPrjId",
					Value = ResourceManager.GetMessage("NotExistsBordFacilityPrjId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordReqCmpId",
					Value = ResourceManager.GetMessage("NotExistsBordReqCmpId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordReqPrsId",
					Value = ResourceManager.GetMessage("NotExistsBordReqPrsId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordReqPrjId",
					Value = ResourceManager.GetMessage("NotExistsBordReqPrjId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordFreightCurrUnId",
					Value = ResourceManager.GetMessage("NotExistsBordFreightCurrUnId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordCustomsCurrUnId",
					Value = ResourceManager.GetMessage("NotExistsBordCustomsCurrUnId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordCommissionCurrUnId",
					Value = ResourceManager.GetMessage("NotExistsBordCommissionCurrUnId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordCostSheetId",
					Value = ResourceManager.GetMessage("NotExistsBordCostSheetId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordDefaultSettingId",
					Value = ResourceManager.GetMessage("NotExistsBordDefaultSettingId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordVerificationWorkFlowId",
					Value = ResourceManager.GetMessage("NotExistsBordVerificationWorkFlowId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "Emp BordCurrencyUnitId",
					Value = ResourceManager.GetMessage("RequiredBordCurrencyUnitId", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No BordCurrencyUnitIdI",
					Value = ResourceManager.GetMessage("NotExistsBordCurrencyUnitIdI", currLangId)
				});
				list10.Add(new SelectListItem
				{
					Text = "No Center",
					Value = ResourceManager.GetMessage("msgErrorCenterNotFound", currLangId)
				});
				string[] array = ((string)objectParameter.Value).Split(new char[1] { '|' });
				string[] array2 = array;
				foreach (string i in array2)
				{
					if (text != "")
					{
						text += "\r\n";
					}
					SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list10, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == i));
					if (selectListItem != null && !string.IsNullOrWhiteSpace(selectListItem.Value))
					{
						text += selectListItem.Value.Replace("<br>", "\r\n");
					}
				}
				data = 0;
				status = ServiceResultStatus.Error;
			}
			else
			{
				int result5 = 0;
				int.TryParse(model.ApiBordCurrencyUnitId.ToString(), out result5);
				if (result5 != 0)
				{
					cRMEntities.ApispUpdateBuyOrderItemCurrencyUnitId(model.ApiBuyOrderId, result5, userId, short.Parse(now.ToString("MM", new PersianCulture())), now, now.ToString("yyyyMMdd", new PersianCulture()), appType);
				}
				data = 1;
				text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
				status = ServiceResultStatus.Success;
			}
		}
		catch (DbEntityValidationException ex)
		{
			string text11 = ((!string.IsNullOrEmpty(((Exception)(object)ex).Message)) ? ((Exception)(object)ex).Message : "");
			if (((Exception)(object)ex).InnerException != null && !string.IsNullOrEmpty(((Exception)(object)ex).InnerException.Message))
			{
				text11 = text11 + " - " + ((Exception)(object)ex).InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text11)) ? (" (" + text11 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
		}
		catch (Exception ex2)
		{
			string text12 = ((!string.IsNullOrEmpty(ex2.Message)) ? ex2.Message : "");
			if (ex2.InnerException != null && !string.IsNullOrEmpty(ex2.InnerException.Message))
			{
				text12 = text12 + " - " + ex2.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text12)) ? (" (" + text12 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteBuyOrderViewModel model)
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
				return new ServiceResult<bool>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBuyOrderId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteBuyOrder(model.ApiBuyOrderId));
				if (mct_Result != null)
				{
					if (mct_Result.Result == 1)
					{
						data = true;
						message = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
						status = ServiceResultStatus.Success;
					}
					else if (mct_Result.Result == 0)
					{
						data = false;
						message = ResourceManager.GetMessage("RedundancyMessage", currLangId);
						status = ServiceResultStatus.Error;
					}
					else if (mct_Result.Result == -1)
					{
						data = false;
						message = ResourceManager.GetMessage("ErrorNotFound", currLangId);
						status = ServiceResultStatus.Fail;
					}
					else if (mct_Result.Result == -2)
					{
						data = false;
						message = ResourceManager.GetMessage("ErrorBordIsFixed", currLangId);
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = false;
					message = ResourceManager.GetMessage("ErrorDoneOperation", currLangId);
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = false;
				message = ResourceManager.GetMessage("ErrorNotFound", currLangId);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
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
	public ServiceResult<List<ApispSelectBuyOrderItems_Result>> SelectItems(SelectBuyOrderItemsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectBuyOrderItems_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectBuyOrderItems_Result>>
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
				return new ServiceResult<List<ApispSelectBuyOrderItems_Result>>
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
				return new ServiceResult<List<ApispSelectBuyOrderItems_Result>>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.BuyOrderItemId.GetValueOrDefault() == 0 && model.BuyOrderId.GetValueOrDefault() == 0)
			{
				return new ServiceResult<List<ApispSelectBuyOrderItems_Result>>
				{
					Message = Messages.EmptyParameters,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispSelectBuyOrderItems_Result> list2 = Enumerable.ToList<ApispSelectBuyOrderItems_Result>((IEnumerable<ApispSelectBuyOrderItems_Result>)cRMEntities.ApispSelectBuyOrderItems(model.BuyOrderItemId, model.BuyOrderId, currLangId, result, model.CenterId, model.CenterCode));
			if (list2 != null)
			{
				message = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = ResourceManager.GetMessage("ErrorNotFound", currLangId);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectBuyOrderItems_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> UpdateItem(UpdateBuyOrderItemViewModel model)
	{
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		CRMEntities cRMEntities = null;
		int data = 0;
		string text = "";
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
			CommonClass commonClass = new CommonClass();
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
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
			string text3 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text3 = apispSelectLanguages_Result.LanguageCollation;
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
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBordIPrdId > 0)
			{
				try
				{
					bool result3 = false;
					bool result4 = false;
					bool result5 = false;
					ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)cRMEntities.ApispSelectProductsWithId(model.ApiBordIPrdId, currLangId, result));
					if (apispSelectProductsWithId_Result != null)
					{
						bool.TryParse(apispSelectProductsWithId_Result.PrdQtyNoFCR.ToString(), out result3);
						bool.TryParse(apispSelectProductsWithId_Result.PrdMustFullTracingCode.ToString(), out result4);
						bool.TryParse(apispSelectProductsWithId_Result.PrdSingleItem.ToString(), out result5);
					}
					List<ApispCheckUsedPrdSingleItemInBuyOrder_Result> list2 = Enumerable.ToList<ApispCheckUsedPrdSingleItemInBuyOrder_Result>((IEnumerable<ApispCheckUsedPrdSingleItemInBuyOrder_Result>)cRMEntities.ApispCheckUsedPrdSingleItemInBuyOrder(model.ApiBuyOrderId, 0, model.ApiBordIPrdId));
					if (list2 != null && Enumerable.Any<ApispCheckUsedPrdSingleItemInBuyOrder_Result>((IEnumerable<ApispCheckUsedPrdSingleItemInBuyOrder_Result>)list2))
					{
						if (result5)
						{
							return new ServiceResult<int>
							{
								Message = ResourceManager.GetMessage("msgErrorNoRegisterPrdSingleItemInBord", currLangId),
								Data = 0,
								Status = ServiceResultStatus.Error
							};
						}
						return new ServiceResult<int>
						{
							Message = ResourceManager.GetMessage("msgErrorNoRegisterPrdInBordWithSingleItem", currLangId),
							Data = 0,
							Status = ServiceResultStatus.Error
						};
					}
					if (model.ApiBordIQuantity.GetValueOrDefault() == 0f)
					{
						return new ServiceResult<int>
						{
							Message = string.Format(ResourceManager.GetMessage("ErrorIsNotEntered", currLangId), ResourceManager.GetLabel("Quantity", currLangId)),
							Data = 0,
							Status = ServiceResultStatus.Error
						};
					}
					bool flag = false;
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result2 = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result2 != null)
					{
						flag = apispSelectCrmsysSetting_Result2.MustFullTracingCode.HasValue && apispSelectCrmsysSetting_Result2.MustFullTracingCode != false;
					}
					if (flag)
					{
						if (string.IsNullOrWhiteSpace(model.ApiBordITracing))
						{
							return new ServiceResult<int>
							{
								Message = string.Format(ResourceManager.GetMessage("msgErrorIsNotSpecified", currLangId), ResourceManager.GetMessage("prdTracing", currLangId)),
								Data = 0,
								Status = ServiceResultStatus.Error
							};
						}
					}
					else if (result4 && string.IsNullOrWhiteSpace(model.ApiBordITracing))
					{
						return new ServiceResult<int>
						{
							Message = string.Format(ResourceManager.GetMessage("msgErrorIsNotSpecified", currLangId), ResourceManager.GetMessage("prdTracing", currLangId)),
							Data = 0,
							Status = ServiceResultStatus.Error
						};
					}
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.ApiBordIQuantityDesc_Lang))
					{
						list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordIQuantityDesc_Lang);
					}
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = model.ApiBordIQuantityDesc,
						LanguageId = currLangId
					});
					List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.ApiBordIDescription_Lang))
					{
						list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordIDescription_Lang);
					}
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = model.ApiBordIDescription,
						LanguageId = currLangId
					});
					List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.ApiBordIForwarderName_Lang))
					{
						list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordIForwarderName_Lang);
					}
					list5.Add(new CommonMultiLanguageViewModel
					{
						Value = model.ApiBordIForwarderName,
						LanguageId = currLangId
					});
					List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.ApiBordICustomsPart_Lang))
					{
						list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordICustomsPart_Lang);
					}
					list6.Add(new CommonMultiLanguageViewModel
					{
						Value = model.ApiBordICustomsPart,
						LanguageId = currLangId
					});
					List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.ApiBordIPrdNickname_Lang))
					{
						list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordIPrdNickname_Lang);
					}
					list7.Add(new CommonMultiLanguageViewModel
					{
						Value = model.ApiBordIPrdNickname,
						LanguageId = currLangId
					});
					double result6 = 1.0;
					double result7 = 1.0;
					if (result3)
					{
						result6 = 1.0;
						result7 = 1.0;
					}
					else
					{
						if (model.ApiBordIFCR.GetValueOrDefault() != 0f)
						{
							double.TryParse(model.ApiBordIFCR.ToString(), out result6);
						}
						if (model.ApiBordIFCRI.GetValueOrDefault() != 0f)
						{
							double.TryParse(model.ApiBordIFCRI.ToString(), out result7);
						}
					}
					double result8 = 0.0;
					double.TryParse(model.ApiBordIQuantityTotal.ToString(), out result8);
					decimal num2 = model.ApiBordIDiscount.GetValueOrDefault();
					decimal valueOrDefault = model.ApiBordICost.GetValueOrDefault();
					decimal valueOrDefault2 = model.ApiBordIRound.GetValueOrDefault();
					decimal valueOrDefault3 = model.ApiBordIRoundPlus.GetValueOrDefault();
					decimal valueOrDefault4 = model.ApiBordITax.GetValueOrDefault();
					decimal num3 = default(decimal);
					num3 = ((!(result8 > 0.0)) ? ((decimal)((double?)model.ApiBordIQuantity * result6 * result7).Value) : ((decimal)(result8 * result7)));
					if (model.ApiBordIDiscountSum.HasValue && num2 == 0m)
					{
						num2 = model.ApiBordIDiscountSum.GetValueOrDefault() / num3;
						model.ApiBordIDiscount = num2;
					}
					if (!model.ApiBordIDiscountSum.HasValue)
					{
						decimal? apiBordIDiscountSum = model.ApiBordIDiscountSum;
						if ((apiBordIDiscountSum.GetValueOrDefault() == default(decimal)) & apiBordIDiscountSum.HasValue)
						{
							model.ApiBordIDiscountSum = num3 * num2;
						}
					}
					decimal num4 = valueOrDefault - num2 - valueOrDefault2 + valueOrDefault3;
					decimal valueOrDefault5 = model.ApiBordIDiscountSum.GetValueOrDefault();
					decimal num5 = (valueOrDefault - valueOrDefault2 + valueOrDefault3) * num3 - valueOrDefault5;
					decimal.TryParse(model.ApiBordITaxIndex.ToString(), out var result9);
					if (result9 != 0m)
					{
						model.ApiBordITaxSum = num5 * result9 / 100m;
					}
					else
					{
						model.ApiBordITaxSum = num3 * valueOrDefault4;
					}
					if (model.ApiBordITaxSum.GetValueOrDefault() != 0m && model.ApiBordITax.GetValueOrDefault() == 0m)
					{
						model.ApiBordITax = model.ApiBordITaxSum / (decimal?)num3;
					}
					else if (model.ApiBordITaxSum.GetValueOrDefault() != 0m && model.ApiBordITaxIndex.GetValueOrDefault() == 0m)
					{
						model.ApiBordITaxIndex = model.ApiBordITaxSum * (decimal?)100 / (decimal?)num5;
					}
					if (model.ApiBordITax.GetValueOrDefault() != 0m && model.ApiBordITaxIndex.GetValueOrDefault() != 0m && model.ApiBordITaxSum.GetValueOrDefault() != 0m)
					{
						model.ApiBordICalculateTax = true;
					}
					else
					{
						model.ApiBordICalculateTax = false;
					}
					model.ApiBordICostSum = num5;
					model.ApiBordITotalCost = model.ApiBordICostSum + model.ApiBordITaxSum;
					decimal num6 = model.ApiBordIFacilityCost.GetValueOrDefault();
					decimal valueOrDefault6 = model.ApiBordITotalCost.GetValueOrDefault();
					decimal num7 = model.ApiBordIFacilityCostPercent.GetValueOrDefault();
					if (model.ApiBordIFacilityCostPercent.HasValue)
					{
						if (num7 > 0m)
						{
							num6 = Convert.ToDecimal(valueOrDefault6 * num7) / 100m;
						}
					}
					else if (num6 > 0m && valueOrDefault6 > 0m)
					{
						num7 = Convert.ToDecimal(Convert.ToDecimal(num6 * 100m) / valueOrDefault6);
					}
					decimal valueOrDefault7 = model.ApiBordIFreightCost.GetValueOrDefault();
					float valueOrDefault8 = model.ApiBordIFreightCurrencyRate.GetValueOrDefault(1f);
					decimal num8 = valueOrDefault7 * (decimal)valueOrDefault8;
					decimal valueOrDefault9 = model.ApiBordICustomsFee.GetValueOrDefault();
					float valueOrDefault10 = model.ApiBordICustomsCurrencyRate.GetValueOrDefault(1f);
					decimal num9 = valueOrDefault9 * (decimal)valueOrDefault10;
					decimal valueOrDefault11 = model.ApiBordICommission.GetValueOrDefault();
					float valueOrDefault12 = model.ApiBordICommissionCurrencyRate.GetValueOrDefault(1f);
					decimal num10 = valueOrDefault11 * (decimal)valueOrDefault12;
					decimal value3 = valueOrDefault6 + num6 + num8 + num9 + num10;
					model.ApiBordIFacilityCost = num6;
					model.ApiBordIFacilityCostPercent = num7;
					model.ApiBordIFreightCost = valueOrDefault7;
					model.ApiBordIFreightCurrencyRate = valueOrDefault8;
					model.ApiBordIFinalFreightCost = num8;
					model.ApiBordICustomsFee = valueOrDefault9;
					model.ApiBordICustomsCurrencyRate = valueOrDefault10;
					model.ApiBordIFinalCustomsFee = num9;
					model.ApiBordICommission = valueOrDefault11;
					model.ApiBordICommissionCurrencyRate = valueOrDefault12;
					model.ApiBordIFinalCommission = num10;
					bool result10 = false;
					ApispSelectCurrencyUnitsWithId_Result apispSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<ApispSelectCurrencyUnitsWithId_Result>((IEnumerable<ApispSelectCurrencyUnitsWithId_Result>)cRMEntities.ApispSelectCurrencyUnitsWithId(model.ApiBordICurrencyUnitId, currLangId, result));
					if (apispSelectCurrencyUnitsWithId_Result != null)
					{
						bool.TryParse(apispSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result10);
					}
					if (!result10)
					{
						if (model.ApiBordIDiscount.HasValue)
						{
							model.ApiBordIDiscount = RoundCalculation.RoundNumber(model.ApiBordIDiscount.GetValueOrDefault());
						}
						if (model.ApiBordITax.HasValue)
						{
							model.ApiBordITax = RoundCalculation.RoundNumber(model.ApiBordITax.GetValueOrDefault());
						}
						if (model.ApiBordITaxSum.HasValue)
						{
							model.ApiBordITaxSum = RoundCalculation.RoundNumber(model.ApiBordITaxSum.GetValueOrDefault());
						}
						if (model.ApiBordIDiscountSum.HasValue)
						{
							model.ApiBordIDiscountSum = RoundCalculation.RoundNumber(model.ApiBordIDiscountSum.GetValueOrDefault());
						}
					}
					string text4 = "";
					if (model.ApiBordITaxClearedDate.HasValue)
					{
						text4 = model.ApiBordITaxClearedDate?.ToString("yyyyMMdd", new PersianCulture());
					}
					if (IsFixed(model.ApiBuyOrderId))
					{
						return new ServiceResult<int>
						{
							Message = ResourceManager.GetMessage("msgErrorNotActiveBOrd", currLangId),
							Data = 0,
							Status = ServiceResultStatus.Error
						};
					}
					decimal? apiBordICost = model.ApiBordICost;
					model.ApiBordICost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordICost);
					apiBordICost = model.ApiBordIDiscountPercent;
					model.ApiBordIDiscountPercent = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIDiscountPercent);
					apiBordICost = model.ApiBordIDiscount;
					model.ApiBordIDiscount = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIDiscount);
					model.ApiBordIFCR = ((model.ApiBordIFCR == 0f) ? null : model.ApiBordIFCR);
					model.ApiBordIFCRI = ((model.ApiBordIFCRI == 0f) ? null : model.ApiBordIFCRI);
					model.ApiBordIQuantityTotal = ((model.ApiBordIQuantityTotal == 0f) ? null : model.ApiBordIQuantityTotal);
					model.ApiBordICalculateTax = ((model.ApiBordICalculateTax == false) ? null : model.ApiBordICalculateTax);
					apiBordICost = model.ApiBordITaxIndex;
					model.ApiBordITaxIndex = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordITaxIndex);
					apiBordICost = model.ApiBordITax;
					model.ApiBordITax = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordITax);
					model.ApiBordIPrdUnitId = ((model.ApiBordIPrdUnitId == 0) ? null : model.ApiBordIPrdUnitId);
					model.ApiBordICurrencyUnitId = ((model.ApiBordICurrencyUnitId == 0) ? null : model.ApiBordICurrencyUnitId);
					if (CanUpdateBuyOrderItemTracing(model.ApiBordIWHId, model.ApiBordIPrdId, model.ApiBordITracing) == 1)
					{
						model.ApiBordITracing = ((!string.IsNullOrWhiteSpace(model.ApiBordITracing)) ? model.ApiBordITracing : null);
					}
					apiBordICost = model.ApiBordITaxSum;
					model.ApiBordITaxSum = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordITaxSum);
					apiBordICost = model.ApiBordIDiscountSum;
					model.ApiBordIDiscountSum = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIDiscountSum);
					apiBordICost = model.ApiBordICostSum;
					model.ApiBordICostSum = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordICostSum);
					apiBordICost = model.ApiBordIFacilityCost;
					model.ApiBordIFacilityCost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFacilityCost);
					apiBordICost = model.ApiBordIFacilityCostPercent;
					model.ApiBordIFacilityCostPercent = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFacilityCostPercent);
					apiBordICost = model.ApiBordIFreightCost;
					model.ApiBordIFreightCost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFreightCost);
					model.ApiBordIFreightCurrencyRate = ((model.ApiBordIFreightCurrencyRate == 0f) ? null : model.ApiBordIFreightCurrencyRate);
					apiBordICost = model.ApiBordIFinalFreightCost;
					model.ApiBordIFinalFreightCost = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFinalFreightCost);
					apiBordICost = model.ApiBordICustomsFee;
					model.ApiBordICustomsFee = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordICustomsFee);
					model.ApiBordICustomsCurrencyRate = ((model.ApiBordICustomsCurrencyRate == 0f) ? null : model.ApiBordICustomsCurrencyRate);
					apiBordICost = model.ApiBordIFinalCustomsFee;
					model.ApiBordIFinalCustomsFee = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFinalCustomsFee);
					model.ApiBordITotalFinalCost = value3;
					apiBordICost = model.ApiBordICommission;
					model.ApiBordICommission = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordICommission);
					model.ApiBordICommissionCurrencyRate = ((model.ApiBordICommissionCurrencyRate == 0f) ? null : model.ApiBordICommissionCurrencyRate);
					apiBordICost = model.ApiBordIFinalCommission;
					model.ApiBordIFinalCommission = (((apiBordICost.GetValueOrDefault() == default(decimal)) & apiBordICost.HasValue) ? null : model.ApiBordIFinalCommission);
					List<ApispSelectBuyOrderItems_Result> list8 = Enumerable.ToList<ApispSelectBuyOrderItems_Result>((IEnumerable<ApispSelectBuyOrderItems_Result>)cRMEntities.ApispSelectBuyOrderItems(0, model.ApiBuyOrderId, currLangId, result, null, null));
					int num11 = (Enumerable.Any<ApispSelectBuyOrderItems_Result>((IEnumerable<ApispSelectBuyOrderItems_Result>)list8) ? Enumerable.Count<ApispSelectBuyOrderItems_Result>((IEnumerable<ApispSelectBuyOrderItems_Result>)list8) : 0);
					if (model.ApiBordIOrderView.GetValueOrDefault() != 0)
					{
						model.ApiBordIOrderView = num11 + 1 + num11 * 4 - 1;
					}
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					int num12 = cRMEntities.ApispUpdateBuyOrderItems(model.ApiBuyOrderItemId, model.ApiBuyOrderId, model.ApiBordIPrdId, model.ApiBordIQuantity, model.ApiBordICost, model.ApiBordITotalCost, JsonConvert.SerializeObject(list4), JsonConvert.SerializeObject(list3), model.ApiBordIDiscount, model.ApiBordIDiscountPercent, model.ApiBordIPrdUnitId, model.ApiBordICurrencyUnitId, model.ApiBordIOrderView, model.ApiBordIFCR, model.ApiBordITax, model.ApiBordITaxIndex, model.ApiBordICalculateTax, model.ApiBordINotVisible, model.ApiBordIFCRI, model.ApiBordINotInSum, model.ApiBordIWHId, model.ApiBordIPrdCostGroupID, model.ApiBordITracing, model.ApiBordICostSum, model.ApiBordIDiscountSum, model.ApiBordITaxSum, model.ApiBordITaxCleared, model.ApiBordITaxClearedDate?.ToString(), model.ApiBordIFacilityCost, model.ApiBordIFacilityCostPercent, JsonConvert.SerializeObject(list5), model.ApiBordIFreightCost, model.ApiBordIFreightCurrUnId, model.ApiBordIFreightCurrencyRate, model.ApiBordIFinalFreightCost, JsonConvert.SerializeObject(list6), model.ApiBordICustomsFee, model.ApiBordICustomsCurrUnId, model.ApiBordICustomsCurrencyRate, model.ApiBordIFinalCustomsFee, model.ApiBordITotalFinalCost, model.ApiBordICommission, model.ApiBordICommissionCurrUnId, model.ApiBordICommissionCurrencyRate, model.ApiBordIFinalCommission, model.ApiBordICostSheetItemId, model.ApiBordIQuantityTotal, model.ApiBordIPrdUnitIdI, model.ApiBordIPrdUnitIRateResult, model.ApiBordIPrdColorId, JsonConvert.SerializeObject(list7), model.ApiBordILinkAccFirstTransferDate, model.ApiBordILinkAccLastTransferDate, model.UserId, value2, value, registerDatePersian, appType, currLangId, result, objectParameter, model.CenterId, model.CenterCode);
					int result11 = 0;
					int.TryParse(num12.ToString(), out result11);
					if (result11 < 0 && objectParameter.Value == null)
					{
						return new ServiceResult<int>
						{
							Message = ResourceManager.GetMessage("ErrorDoneOperationTryAgain", currLangId).Replace("<br>", "\r\n"),
							Data = 0,
							Status = ServiceResultStatus.Error
						};
					}
					if (objectParameter != null && !string.IsNullOrWhiteSpace((string)objectParameter.Value))
					{
						List<SelectListItem> list9 = new List<SelectListItem>();
						list9.Add(new SelectListItem
						{
							Text = "IsFixed",
							Value = ResourceManager.GetMessage("ErrorBordIsFixed", currLangId)
						});
						list9.Add(new SelectListItem
						{
							Text = "NO BordIPrdId",
							Value = ResourceManager.GetMessage("NotExistsBordIPrdId", currLangId)
						});
						list9.Add(new SelectListItem
						{
							Text = "NO BordIPrdUnitId",
							Value = ResourceManager.GetMessage("NotExistsBordIPrdUnitId", currLangId)
						});
						list9.Add(new SelectListItem
						{
							Text = "NO BordICurrencyUnitId",
							Value = ResourceManager.GetMessage("NotExistsBordICurrencyUnitId", currLangId)
						});
						list9.Add(new SelectListItem
						{
							Text = "NO BordIWHId",
							Value = ResourceManager.GetMessage("NotExistsBordIWHId", currLangId)
						});
						list9.Add(new SelectListItem
						{
							Text = "NO BordIFreightCurrUnId",
							Value = ResourceManager.GetMessage("NotExistsBordIFreightCurrUnId", currLangId)
						});
						list9.Add(new SelectListItem
						{
							Text = "NO BordICustomsCurrUnId",
							Value = ResourceManager.GetMessage("NotExistsBordICustomsCurrUnId", currLangId)
						});
						list9.Add(new SelectListItem
						{
							Text = "NO BordICommissionCurrUnId",
							Value = ResourceManager.GetMessage("NotExistsBordICommissionCurrUnId", currLangId)
						});
						list9.Add(new SelectListItem
						{
							Text = "NO BordICostSheetItemId",
							Value = ResourceManager.GetMessage("NotExistsBordICostSheetItemId", currLangId)
						});
						list9.Add(new SelectListItem
						{
							Text = "NO BordIPrdColorId",
							Value = ResourceManager.GetMessage("NotExistsBordIPrdColorId", currLangId)
						});
						list9.Add(new SelectListItem
						{
							Text = "NO Center",
							Value = ResourceManager.GetMessage("msgErrorCenterNotFound", currLangId)
						});
						list9.Add(new SelectListItem
						{
							Text = "No Center",
							Value = ResourceManager.GetMessage("msgErrorCenterNotFound", currLangId)
						});
						string[] array = ((string)objectParameter.Value).Split(new char[1] { '|' });
						string[] array2 = array;
						foreach (string i in array2)
						{
							if (text != "")
							{
								text += "\r\n";
							}
							SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list9, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == i));
							if (selectListItem != null && !string.IsNullOrWhiteSpace(selectListItem.Value))
							{
								text += selectListItem.Value.Replace("<br>", "\r\n");
							}
						}
						data = 0;
						status = ServiceResultStatus.Error;
					}
					else
					{
						data = 1;
						text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
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
					text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text5)) ? (" (" + text5 + ")") : "");
					data = 0;
					status = ServiceResultStatus.Error;
					ErrorSignal.FromCurrentContext().Raise(ex);
				}
			}
			else
			{
				text = Messages.msgErrorNotSelectProduct;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex2)
		{
			string text6 = ((!string.IsNullOrEmpty(ex2.Message)) ? ex2.Message : "");
			if (ex2.InnerException != null && !string.IsNullOrEmpty(ex2.InnerException.Message))
			{
				text6 = text6 + " - " + ex2.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text6)) ? (" (" + text6 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteItem(DeleteBuyOrderItemsViewModel model)
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
				return new ServiceResult<bool>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBuyOrderItemId > 0)
			{
				short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteBuyOrderItems(model.ApiBuyOrderItemId, value, currLangId, result));
				if (mct_Result != null)
				{
					if (mct_Result.Result == 1)
					{
						data = true;
						message = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
						status = ServiceResultStatus.Success;
					}
					else if (mct_Result.Result == 0)
					{
						data = false;
						message = ResourceManager.GetMessage("RedundancyMessage", currLangId);
						status = ServiceResultStatus.Error;
					}
					else if (mct_Result.Result == -1)
					{
						data = false;
						message = ResourceManager.GetMessage("ErrorNotFound", currLangId);
						status = ServiceResultStatus.Fail;
					}
					else if (mct_Result.Result == -2)
					{
						data = false;
						message = ResourceManager.GetMessage("ErrorBordIsFixed", currLangId);
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = false;
					message = ResourceManager.GetMessage("ErrorDoneOperation", currLangId);
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = false;
				message = ResourceManager.GetMessage("ErrorNotFound", currLangId);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
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
	public ServiceResult<List<ApispSelectBuyOrderPayments_Result>> SelectPayment(SelectBuyOrderPaymentViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectBuyOrderPayments_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectBuyOrderPayments_Result>>
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
				return new ServiceResult<List<ApispSelectBuyOrderPayments_Result>>
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
				return new ServiceResult<List<ApispSelectBuyOrderPayments_Result>>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.BuyOrderId.GetValueOrDefault() == 0)
			{
				return new ServiceResult<List<ApispSelectBuyOrderPayments_Result>>
				{
					Message = Messages.EmptyParameters,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispSelectBuyOrderPayments_Result> list2 = Enumerable.ToList<ApispSelectBuyOrderPayments_Result>((IEnumerable<ApispSelectBuyOrderPayments_Result>)cRMEntities.ApispSelectBuyOrderPayments(model.BuyOrderId, currLangId, result, model.CenterId, model.CenterCode));
			if (list2 != null)
			{
				message = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = ResourceManager.GetMessage("ErrorNotFound", currLangId);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectBuyOrderPayments_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> UpdatePayment(UpdateBuyOrderPaymentViewModel model)
	{
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		CRMEntities cRMEntities = null;
		int data = 0;
		string text = "";
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
			CommonClass commonClass = new CommonClass();
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
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
			string text3 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text3 = apispSelectLanguages_Result.LanguageCollation;
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
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (!model.ApiImportDateTime.HasValue)
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("EmptyBordPaymentImportDate", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBordpayTypeId <= 0)
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("EmptyBordPaymentTypeId", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			decimal? apiBordpayAmount = model.ApiBordpayAmount;
			if ((apiBordpayAmount.GetValueOrDefault() <= default(decimal)) & apiBordpayAmount.HasValue)
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("EmptyBordPaymentAmount", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (!model.ApiBordpayDocDateTime.HasValue)
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("EmptyBordPaymentDocDate", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			try
			{
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiBordpayDescription_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiBordpayDescription_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiBordpayDescription,
					LanguageId = currLangId
				});
				ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
				int num2 = cRMEntities.ApispUpdateBuyOrderPayments(model.ApiBuyOrderPaymentId, model.ApiImportDateTime?.ToString("yyyyMMdd", new PersianCulture()), model.ApiImportDateTime, model.ApiBordpayTypeId, model.ApiBordpayOrderId, null, null, model.ApiBordpayAmount, model.ApiBordpayDocNumber, model.ApiBordpayDocDateTime?.ToString("yyyyMMdd", new PersianCulture()), apiBordpayDescription: JsonConvert.SerializeObject(list2), apiBordpayDocDateTime: model.ApiBordpayDocDateTime, apiBordpayDocAmount: model.ApiBordpayDocAmount, apiBordpayDeActive: model.ApiBordpayDeActive, apiBordpayAccountNumber: model.ApiBordpayAccountNumber, apiBordpayAmountTemp: model.ApiBordpayAmountTemp, apiBordpayDocDateTemp: model.ApiBordpayDocDateTimeTemp?.ToString("yyyyMMdd", new PersianCulture()), apiBordpayDocDateTimeTemp: model.ApiBordpayDocDateTimeTemp, userId: model.UserId, fPId: 0, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: currLangId, defaultLanguageID: result, errorMessage: objectParameter, centerId: model.CenterId, centerCode: model.CenterCode);
				int result3 = 0;
				int.TryParse(num2.ToString(), out result3);
				if (result3 < 0 && objectParameter.Value == null)
				{
					return new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("ErrorDoneOperationTryAgain", currLangId).Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (objectParameter != null && !string.IsNullOrWhiteSpace((string)objectParameter.Value))
				{
					List<SelectListItem> list3 = new List<SelectListItem>();
					list3.Add(new SelectListItem
					{
						Text = "IsFixed",
						Value = ResourceManager.GetMessage("ErrorBordIsFixed", currLangId)
					});
					list3.Add(new SelectListItem
					{
						Text = "No Center",
						Value = ResourceManager.GetMessage("msgErrorCenterNotFound", currLangId)
					});
					string[] array = ((string)objectParameter.Value).Split(new char[1] { '|' });
					string[] array2 = array;
					foreach (string i in array2)
					{
						if (text != "")
						{
							text += "\r\n";
						}
						SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == i));
						if (selectListItem != null && !string.IsNullOrWhiteSpace(selectListItem.Value))
						{
							text += selectListItem.Value.Replace("<br>", "\r\n");
						}
					}
					data = 0;
					status = ServiceResultStatus.Error;
				}
				else
				{
					data = 1;
					text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
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
				text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text4)) ? (" (" + text4 + ")") : "");
				data = 0;
				status = ServiceResultStatus.Error;
				ErrorSignal.FromCurrentContext().Raise(ex);
			}
		}
		catch (Exception ex2)
		{
			string text5 = ((!string.IsNullOrEmpty(ex2.Message)) ? ex2.Message : "");
			if (ex2.InnerException != null && !string.IsNullOrEmpty(ex2.InnerException.Message))
			{
				text5 = text5 + " - " + ex2.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text5)) ? (" (" + text5 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeletePayment(DeleteBuyOrderPaymentViewModel model)
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
				return new ServiceResult<bool>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBuyOrderPaymentId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteBuyOrderPayments(model.ApiBuyOrderPaymentId));
				if (mct_Result != null)
				{
					if (mct_Result.Result == 1)
					{
						data = true;
						message = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
						status = ServiceResultStatus.Success;
					}
					else if (mct_Result.Result == 0)
					{
						data = false;
						message = ResourceManager.GetMessage("RedundancyMessage", currLangId);
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					data = false;
					message = ResourceManager.GetMessage("ErrorDoneOperation", currLangId);
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = false;
				message = ResourceManager.GetMessage("ErrorNotFound", currLangId);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
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
	public ServiceResult<List<ApispSelectBuyOrderItemSerials_Result>> SelectSerials(SelectBuyOrderItemSerialsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectBuyOrderItemSerials_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectBuyOrderItemSerials_Result>>
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
				return new ServiceResult<List<ApispSelectBuyOrderItemSerials_Result>>
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
				return new ServiceResult<List<ApispSelectBuyOrderItemSerials_Result>>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBuyOrderItemId == 0)
			{
				return new ServiceResult<List<ApispSelectBuyOrderItemSerials_Result>>
				{
					Message = Messages.EmptyParameters,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispSelectBuyOrderItemSerials_Result> list2 = Enumerable.ToList<ApispSelectBuyOrderItemSerials_Result>((IEnumerable<ApispSelectBuyOrderItemSerials_Result>)cRMEntities.ApispSelectBuyOrderItemSerials(model.ApiBuyOrderItemId, currLangId, result, model.CenterId, model.CenterCode));
			if (list2 != null)
			{
				foreach (ApispSelectBuyOrderItemSerials_Result item in list2)
				{
					item.ApiExpDatePersian = item.ApiExpDate?.ToString("yyyy/MM/dd", new CultureInfo(currLangId));
					item.ApiFirstRegisterDatePersian = item.ApiFirstRegisterDate?.ToString("yyyy/MM/dd", new CultureInfo(currLangId));
					item.ApiRegisterDatePersian = item.ApiRegisterDate.ToString("yyyy/MM/dd", new CultureInfo(currLangId));
				}
				message = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = ResourceManager.GetMessage("ErrorNotFound", currLangId);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectBuyOrderItemSerials_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> UpdateItemSerial(UpdateBuyOrderItemSerialViewModel model)
	{
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		CRMEntities cRMEntities = null;
		int data = 0;
		string text = "";
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
			CommonClass commonClass = new CommonClass();
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
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
			string text3 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text3 = apispSelectLanguages_Result.LanguageCollation;
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
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (string.IsNullOrWhiteSpace(model.ApiSerial))
			{
				return new ServiceResult<int>
				{
					Message = ResourceManager.GetMessage("EmptyBuyOrder", currLangId),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			ApispSelectBuyOrderItems_Result apispSelectBuyOrderItems_Result = Enumerable.FirstOrDefault<ApispSelectBuyOrderItems_Result>((IEnumerable<ApispSelectBuyOrderItems_Result>)cRMEntities.ApispSelectBuyOrderItems(model.ApiBuyOrderItemId, 0, currLangId, result, null, null));
			if (apispSelectBuyOrderItems_Result != null)
			{
				ApifnCheckDuplicateBuyOrderPrdSerial_Result apifnCheckDuplicateBuyOrderPrdSerial_Result = Enumerable.FirstOrDefault<ApifnCheckDuplicateBuyOrderPrdSerial_Result>((IEnumerable<ApifnCheckDuplicateBuyOrderPrdSerial_Result>)Enumerable.ToList<ApifnCheckDuplicateBuyOrderPrdSerial_Result>((IEnumerable<ApifnCheckDuplicateBuyOrderPrdSerial_Result>)cRMEntities.ApifnCheckDuplicateBuyOrderPrdSerial(apispSelectBuyOrderItems_Result.ApiBordIPrdId, model.ApiSerial, model.ApiBuyOrderItemSerialId, apispSelectBuyOrderItems_Result.ApiBordIWHId)));
				if (apifnCheckDuplicateBuyOrderPrdSerial_Result != null)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("msgErrorDuplicateSerialNumberInBuyOrder", currLangId) + apifnCheckDuplicateBuyOrderPrdSerial_Result.bordNumber + ResourceManager.GetMessage("msgErrorDuplicateSerialNumberInBuyOrder1", currLangId),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
					serviceResult.Message = serviceResult.Message.Replace("<br>", "\r\n").Replace("</br>", "\r\n").Replace("<br/>", "\r\n");
					return serviceResult;
				}
			}
			try
			{
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiDescription_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiDescription_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiDescription,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoI_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoI_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoI,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoII_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoII_Lang);
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoII,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoIII_Lang))
				{
					list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoIII_Lang);
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoIII,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoIV_Lang))
				{
					list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoIV_Lang);
				}
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoIV,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoV_Lang))
				{
					list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoV_Lang);
				}
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoV,
					LanguageId = currLangId
				});
				List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.ApiInfoVI_Lang))
				{
					list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ApiInfoVI_Lang);
				}
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ApiInfoVI,
					LanguageId = currLangId
				});
				ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
				int num2 = cRMEntities.ApispUpdateBuyOrderItemSerials(model.ApiBuyOrderItemSerialId, model.ApiBuyOrderItemId, model.ApiSerial, JsonConvert.SerializeObject(list2), model.ApiExpDate, model.ApiExpDate?.ToString("yyyyMMdd", new PersianCulture()), JsonConvert.SerializeObject(list3), JsonConvert.SerializeObject(list4), JsonConvert.SerializeObject(list5), JsonConvert.SerializeObject(list6), JsonConvert.SerializeObject(list7), JsonConvert.SerializeObject(list8), model.UserId, 0, value2, value, registerDatePersian, appType, currLangId, result, objectParameter, model.CenterId, model.CenterCode);
				int result3 = 0;
				int.TryParse(num2.ToString(), out result3);
				if (result3 < 0 && objectParameter.Value == null)
				{
					return new ServiceResult<int>
					{
						Message = ResourceManager.GetMessage("ErrorDoneOperationTryAgain", currLangId).Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (objectParameter != null && !string.IsNullOrWhiteSpace((string)objectParameter.Value))
				{
					List<SelectListItem> list9 = new List<SelectListItem>();
					list9.Add(new SelectListItem
					{
						Text = "IsFixed",
						Value = ResourceManager.GetMessage("ErrorBordIsFixed", currLangId)
					});
					list9.Add(new SelectListItem
					{
						Text = "No Center",
						Value = ResourceManager.GetMessage("msgErrorCenterNotFound", currLangId)
					});
					string[] array = ((string)objectParameter.Value).Split(new char[1] { '|' });
					string[] array2 = array;
					foreach (string i in array2)
					{
						if (text != "")
						{
							text += "\r\n";
						}
						SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list9, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == i));
						if (selectListItem != null && !string.IsNullOrWhiteSpace(selectListItem.Value))
						{
							text += selectListItem.Value.Replace("<br>", "\r\n");
						}
					}
					data = 0;
					status = ServiceResultStatus.Error;
				}
				else
				{
					data = 1;
					text = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
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
				text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text4)) ? (" (" + text4 + ")") : "");
				data = 0;
				status = ServiceResultStatus.Error;
				ErrorSignal.FromCurrentContext().Raise(ex);
			}
		}
		catch (Exception ex2)
		{
			string text5 = ((!string.IsNullOrEmpty(ex2.Message)) ? ex2.Message : "");
			if (ex2.InnerException != null && !string.IsNullOrEmpty(ex2.InnerException.Message))
			{
				text5 = text5 + " - " + ex2.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text5)) ? (" (" + text5 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteItemSerial(DeleteBuyOrderItemSerialViewModel model)
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
				return new ServiceResult<bool>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBuyOrderItemSerialId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteBuyOrderItemSerials(model.ApiBuyOrderItemSerialId));
				if (mct_Result != null)
				{
					if (mct_Result.Result == 1)
					{
						data = true;
						message = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
						status = ServiceResultStatus.Success;
					}
					else if (mct_Result.Result == 0)
					{
						data = false;
						message = ResourceManager.GetMessage("RedundancyMessage", currLangId);
						status = ServiceResultStatus.Error;
					}
					else if (mct_Result.Result == -1)
					{
						data = false;
						message = ResourceManager.GetMessage("ErrorBordIsFixed", currLangId);
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					data = false;
					message = ResourceManager.GetMessage("ErrorDoneOperation", currLangId);
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = false;
				message = ResourceManager.GetMessage("ErrorNotFound", currLangId);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
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
	public ServiceResult<bool> DeleteItemSerialByItemId(DeleteBuyOrderItemSerialByItemIdViewModel model)
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
				return new ServiceResult<bool>
				{
					Message = ResourceManager.GetMessage("ErrorUsernamePasswordIncorrect", currLangId) + "\r\n" + ResourceManager.GetMessage("ErrorTryAgain", currLangId),
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiBuyOrderItemId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteBuyOrderItemSerialsByBuyOrderItemId(model.ApiBuyOrderItemId));
				if (mct_Result != null)
				{
					if (mct_Result.Result == 1)
					{
						data = true;
						message = ResourceManager.GetMessage("SuccessDoneRegister", currLangId);
						status = ServiceResultStatus.Success;
					}
					else if (mct_Result.Result == 0)
					{
						data = false;
						message = ResourceManager.GetMessage("RedundancyMessage", currLangId);
						status = ServiceResultStatus.Error;
					}
					else if (mct_Result.Result == -1)
					{
						data = false;
						message = ResourceManager.GetMessage("ErrorBordIsFixed", currLangId);
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					data = false;
					message = ResourceManager.GetMessage("ErrorDoneOperation", currLangId);
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = false;
				message = ResourceManager.GetMessage("ErrorNotFound", currLangId);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
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

	private long CheckDuplicateBuyOrderNumber(long borderNumber, int borderId, int? oprId, int? centerId, string centerCode)
	{
		CRMEntities cRMEntities = null;
		long result = 0L;
		if (!oprId.HasValue)
		{
			oprId = 0;
		}
		try
		{
			cRMEntities = new CRMEntities();
			long? num = Enumerable.FirstOrDefault<long?>((IEnumerable<long?>)Enumerable.ToList<long?>((IEnumerable<long?>)cRMEntities.ApifnCheckDuplicateBuyOrderNumber(borderNumber, borderId, oprId, centerId, centerCode)));
			if (num.HasValue)
			{
				result = num.Value;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			result = -1L;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = -1L;
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}

	private bool IsFixed(int orderId)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			ApispSelectBuyOrderById_Result apispSelectBuyOrderById_Result = Enumerable.FirstOrDefault<ApispSelectBuyOrderById_Result>((IEnumerable<ApispSelectBuyOrderById_Result>)cRMEntities.ApispSelectBuyOrderById(orderId, 0, 0));
			if (apispSelectBuyOrderById_Result != null && apispSelectBuyOrderById_Result.bordIsFixed.HasValue && apispSelectBuyOrderById_Result.bordIsFixed.GetValueOrDefault())
			{
				result = true;
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
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	private int CanUpdateBuyOrderItemTracing(int? whId = 0, int prdId = 0, string tracing = null)
	{
		int result = 0;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return result;
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int value = result2;
			ApispCheckCanUpdateBuyOrderItemTracing_Result apispCheckCanUpdateBuyOrderItemTracing_Result = Enumerable.FirstOrDefault<ApispCheckCanUpdateBuyOrderItemTracing_Result>((IEnumerable<ApispCheckCanUpdateBuyOrderItemTracing_Result>)cRMEntities.ApispCheckCanUpdateBuyOrderItemTracing(prdId, whId, tracing, value, result2));
			if (apispCheckCanUpdateBuyOrderItemTracing_Result == null)
			{
				result = 1;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}
}
