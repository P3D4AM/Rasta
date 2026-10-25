using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Script.Serialization;
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
using Newtonsoft.Json;

namespace CRMIdealApi.Controllers;

public class ApiOrdersController : ApiController
{
	private ResourceManager RS = new ResourceManager();

	private DateTime registerDate = DateTime.Now;

	private string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());

	private string registerTime = DateTime.Now.ToString("HH:mm:ss");

	private short month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));

	private string appType = CRMIdealApi.Classes.Configuration.AppType;

	[HttpPost]
	public ServiceResult<IssueOrderResultViewModel> Issue(IssueOrderViewModel model)
	{
		//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d81: Unknown result type (might be due to invalid IL or missing references)
		//IL_108b: Unknown result type (might be due to invalid IL or missing references)
		//IL_136c: Unknown result type (might be due to invalid IL or missing references)
		CRMEntities cRMEntities = null;
		IssueOrderResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<IssueOrderResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			if (model.ApiOrderOprId <= 0)
			{
				model.ApiOrderOprId = null;
			}
			if (model.ApiPreOrderId <= 0)
			{
				model.ApiPreOrderId = null;
			}
			if (model.ApiPreOrderVerifierId <= 0)
			{
				model.ApiPreOrderVerifierId = null;
			}
			if (model.ApiOrdGuarantyId <= 0)
			{
				model.ApiOrdGuarantyId = null;
			}
			if (model.ApiOrdDescriptionId <= 0)
			{
				model.ApiOrdDescriptionId = null;
			}
			if (model.ApiOrdPrintFormatId <= 0)
			{
				model.ApiOrdPrintFormatId = null;
			}
			if (model.ApiOrdRLogoId <= 0)
			{
				model.ApiOrdRLogoId = null;
			}
			if (model.ApiOrdLLogoId <= 0)
			{
				model.ApiOrdLLogoId = null;
			}
			if (model.ApiOrdSignatureId <= 0)
			{
				model.ApiOrdSignatureId = null;
			}
			if (model.ApiOrdVerifierId <= 0)
			{
				model.ApiOrdVerifierId = null;
			}
			if (model.ApiOrdSettlementTypeId <= 0)
			{
				model.ApiOrdSettlementTypeId = null;
			}
			if (model.ApiOrdReferUserId <= 0)
			{
				model.ApiOrdReferUserId = null;
			}
			if (model.ApiOrdVerifierRequestId <= 0)
			{
				model.ApiOrdVerifierRequestId = null;
			}
			if (model.ApiOrdStatusId <= 0)
			{
				model.ApiOrdStatusId = null;
			}
			if (model.ApiCompanyId <= 0)
			{
				model.ApiCompanyId = null;
			}
			if (model.ApiCompanyPersonId <= 0)
			{
				model.ApiCompanyPersonId = null;
			}
			if (model.ApiProjectId <= 0)
			{
				model.ApiProjectId = null;
			}
			if (model.ApiWarehouseId <= 0)
			{
				model.ApiWarehouseId = null;
			}
			if (!model.ApiOrdTransportation.HasValue)
			{
				model.ApiOrdTransportation = default(decimal);
			}
			if (!model.ApiOrdRound.HasValue)
			{
				model.ApiOrdRound = default(decimal);
			}
			if (!model.ApiOrdTax.HasValue)
			{
				model.ApiOrdTax = default(decimal);
			}
			if (!model.ApiOrdDiscount.HasValue)
			{
				model.ApiOrdDiscount = default(decimal);
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<IssueOrderResultViewModel>
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
			if (!VersionBuyer.Order)
			{
				return new ServiceResult<IssueOrderResultViewModel>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("Order", new CultureInfo(currLangId))),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (!string.IsNullOrWhiteSpace(model.ApiCommissionInJsonFormat))
			{
				List<IssueOrderCommissionsViewModel> list2 = new JavaScriptSerializer().Deserialize<List<IssueOrderCommissionsViewModel>>(model.ApiCommissionInJsonFormat);
				if (list2 != null && Enumerable.Any<IssueOrderCommissionsViewModel>((IEnumerable<IssueOrderCommissionsViewModel>)list2) && !VersionBuyer.Commissions)
				{
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("lblCommission", new CultureInfo(currLangId))),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
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
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string text = null;
			string text2 = "";
			string text3 = "";
			string ordVerifiedRegisterDatePersian = null;
			string ordDeliveryEndDate = null;
			string ordDeliveryDate = null;
			string text4 = "00:00:00";
			try
			{
				if (!string.IsNullOrEmpty(model.ApiOrdDeliveryTime))
				{
					text4 = model.ApiOrdDeliveryTime;
					string s = DateTime.Now.ToString("yyyy/MM/dd") + " " + text4;
					DateTime dateTime = DateTime.Parse(s, new PersianCulture());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDeliveryTime", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!model.ApiOrdDate.HasValue)
				{
					ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				text = (model.ApiOrdDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				text2 = commonClass.ConvertNameToDayNum((model.ApiOrdDate ?? DateTime.Now).DayOfWeek.ToString());
				text3 = (model.ApiOrdDate ?? DateTime.Now).ToString("HH:mm:ss");
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiOrdVerifiedRegisterDate.HasValue)
				{
					ordVerifiedRegisterDatePersian = (model.ApiOrdVerifiedRegisterDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdVerifiedRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiOrdDeliveryDate.HasValue)
				{
					string s2 = (model.ApiOrdDeliveryDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + text4;
					model.ApiOrdDeliveryDate = DateTime.Parse(s2, new CultureInfo("en-US"));
					ordDeliveryDate = (model.ApiOrdDeliveryDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDeliveryDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiOrdDeliveryEndDateTime.HasValue)
				{
					ordDeliveryEndDate = (model.ApiOrdDeliveryEndDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDeliveryEndDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (string.IsNullOrEmpty(model.ApiProductsInJsonFormat))
				{
					ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				List<IssueOrderItemsViewModel> list3 = new List<IssueOrderItemsViewModel>();
				if (!string.IsNullOrEmpty(model.ApiProductsInJsonFormat))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<IssueOrderItemsViewModel>>(model.ApiProductsInJsonFormat);
					if (Enumerable.Any<IssueOrderItemsViewModel>((IEnumerable<IssueOrderItemsViewModel>)list3))
					{
						foreach (IssueOrderItemsViewModel item in list3)
						{
							int value = 0;
							string prdCode = "";
							if (item.OrdIPrdId.HasValue)
							{
								value = item.OrdIPrdId.GetValueOrDefault();
							}
							if (!string.IsNullOrEmpty(item.OrdIPrdCode))
							{
								prdCode = item.OrdIPrdCode;
							}
							ApispSelectProductsWithIdOrCode_Result apispSelectProductsWithIdOrCode_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithIdOrCode_Result>((IEnumerable<ApispSelectProductsWithIdOrCode_Result>)cRMEntities.ApispSelectProductsWithIdOrCode(value, prdCode, result, result));
							if (apispSelectProductsWithIdOrCode_Result == null)
							{
								string text5 = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								return new ServiceResult<IssueOrderResultViewModel>
								{
									Message = text5.Replace("<br>", "\r\n"),
									Data = null,
									Status = ServiceResultStatus.Error
								};
							}
							try
							{
								if (item.OrdIValidityExpireDate.HasValue)
								{
									string text6 = (item.OrdIValidityExpireDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
								}
							}
							catch (Exception e6)
							{
								ErrorSignal.FromCurrentContext().Raise(e6);
								ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
								serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdIValidityExpireDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
								serviceResult.Data = null;
								serviceResult.Status = ServiceResultStatus.Error;
								return serviceResult;
							}
						}
					}
				}
			}
			catch (Exception e7)
			{
				ErrorSignal.FromCurrentContext().Raise(e7);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ApiPaymentsInJsonFormat))
				{
					List<IssueOrderPaymentsViewModel> list4 = new List<IssueOrderPaymentsViewModel>();
					if (!string.IsNullOrEmpty(model.ApiPaymentsInJsonFormat))
					{
						list4 = new JavaScriptSerializer().Deserialize<List<IssueOrderPaymentsViewModel>>(model.ApiPaymentsInJsonFormat);
						if (Enumerable.Any<IssueOrderPaymentsViewModel>((IEnumerable<IssueOrderPaymentsViewModel>)list4))
						{
							foreach (IssueOrderPaymentsViewModel item2 in list4)
							{
								if (item2.OrdPayAmount.HasValue)
								{
									decimal? ordPayAmount = item2.OrdPayAmount;
									if (!((ordPayAmount.GetValueOrDefault() == default(decimal)) & ordPayAmount.HasValue))
									{
										if (!item2.OrdPayDocAmount.HasValue)
										{
											item2.OrdPayDocAmount = item2.OrdPayAmount;
										}
										try
										{
											if (item2.OrdPayDocDateTime.HasValue)
											{
												string text7 = (item2.OrdPayDocDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
											}
										}
										catch (Exception e8)
										{
											ErrorSignal.FromCurrentContext().Raise(e8);
											ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
											serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPayDocDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
											serviceResult.Data = null;
											serviceResult.Status = ServiceResultStatus.Error;
											return serviceResult;
										}
										continue;
									}
								}
								string text8 = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPayAmount", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								return new ServiceResult<IssueOrderResultViewModel>
								{
									Message = text8.Replace("<br>", "\r\n"),
									Data = null,
									Status = ServiceResultStatus.Error
								};
							}
						}
					}
				}
			}
			catch (Exception e9)
			{
				ErrorSignal.FromCurrentContext().Raise(e9);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Payments", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!string.IsNullOrWhiteSpace(model.ApiCommissionInJsonFormat))
				{
					List<IssueOrderCommissionsViewModel> list5 = new JavaScriptSerializer().Deserialize<List<IssueOrderCommissionsViewModel>>(model.ApiCommissionInJsonFormat);
					if (list5 != null && Enumerable.Any<IssueOrderCommissionsViewModel>((IEnumerable<IssueOrderCommissionsViewModel>)list5))
					{
						foreach (IssueOrderCommissionsViewModel item3 in list5)
						{
							string text9 = "";
							if (!item3.CommDateTime.HasValue)
							{
								if (!string.IsNullOrWhiteSpace(text9))
								{
									text9 += ", ";
								}
								text9 += string.Format(MyResource.GetResourceString("ErrorIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
							}
							else
							{
								try
								{
									if (item3.CommDateTime.HasValue)
									{
										item3.CommDatePersian = (item3.CommDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
									}
								}
								catch (Exception e10)
								{
									ErrorSignal.FromCurrentContext().Raise(e10);
									if (!string.IsNullOrWhiteSpace(text9))
									{
										text9 += ", ";
									}
									text9 += string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
								}
							}
							try
							{
								if (item3.CommEffectiveDateTime.HasValue)
								{
									item3.CommEffectiveDatePersian = (item3.CommEffectiveDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
								}
							}
							catch (Exception e11)
							{
								ErrorSignal.FromCurrentContext().Raise(e11);
								if (!string.IsNullOrWhiteSpace(text9))
								{
									text9 += ", ";
								}
								text9 += string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommEffectiveDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
							}
							try
							{
								if (item3.CommVerifiedDateTime.HasValue)
								{
									item3.CommVerifiedDatePersian = (item3.CommVerifiedDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
								}
							}
							catch (Exception e12)
							{
								ErrorSignal.FromCurrentContext().Raise(e12);
								if (!string.IsNullOrWhiteSpace(text9))
								{
									text9 += ", ";
								}
								text9 += string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommVerifiedDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
							}
							try
							{
								if (item3.CommIsPaidDateTime.HasValue)
								{
									item3.CommIsPaidDatePersian = (item3.CommIsPaidDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
								}
							}
							catch (Exception e13)
							{
								ErrorSignal.FromCurrentContext().Raise(e13);
								if (!string.IsNullOrWhiteSpace(text9))
								{
									text9 += ", ";
								}
								text9 += string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommIsPaidDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
							}
							if (!string.IsNullOrWhiteSpace(text9))
							{
								return new ServiceResult<IssueOrderResultViewModel>
								{
									Message = text9,
									Data = null,
									Status = ServiceResultStatus.Error
								};
							}
						}
						model.ApiCommissionInJsonFormat = JsonConvert.SerializeObject(Enumerable.ToList<IssueOrderCommissionsViewModel>((IEnumerable<IssueOrderCommissionsViewModel>)list5));
					}
				}
			}
			catch (Exception e14)
			{
				ErrorSignal.FromCurrentContext().Raise(e14);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Commissions", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value2 = now;
			string text10 = now.ToString("yyyyMMdd", new PersianCulture());
			string registerDay = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text11 = now.ToString("HH:mm:ss");
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string text12 = CRMIdealApi.Classes.Configuration.AppType;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("InsertedOrderId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedOrderNumber", 0);
			ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispIssueOrder(model.UserName, model.Password, model.ApiOrderOprId, model.ApiPreOrderId, model.ApiPreOrderVerifierId, model.ApiOrdTitle, model.ApiOrdNumber, text, model.ApiOrdDate, text2, text3, model.ApiOrdSubject, model.ApiOrdInstallAmount, model.ApiOrdDiscount, model.ApiOrdTax, model.ApiOrdTaxIndex, model.ApiOrdCalculateTax, model.ApiOrdIsVerified, model.ApiOrdVerifiedRegisterDate, ordVerifiedRegisterDatePersian, model.ApiOrdIsFixed, model.ApiOrdGuarantyId, model.ApiOrdSpecialWord, model.ApiOrdDescriptionI, model.ApiOrdDescriptionII, model.ApiOrdDescriptionId, model.ApiOrdPrintFormatId, model.ApiOrdRLogoId, model.ApiOrdLLogoId, model.ApiOrdSigningI, model.ApiOrdSigningII, model.ApiOrdSigningIII, model.ApiOrdAccountNumberI, model.ApiOrdAccountShabaNumberI, model.ApiOrdAccountNumberII, model.ApiOrdAccountShabaNumberII, model.ApiOrdSignatureId, model.ApiOrdVerifierId, model.ApiOrdSettlementTypeId, model.ApiOrdTransportation, model.ApiOrdReferUserId, model.ApiOrdDiscountPercent, model.ApiOrdDiscountTitle, model.ApiOrdRound, model.ApiOrdNote, model.ApiOrdCmpTitle, ordDeliveryDate, model.ApiOrdDeliveryDate, model.ApiOrdDeliveryTime, model.ApiOrdSerial, model.ApiOrdVerifierRequestId, model.ApiOrdStatusId, model.ApiCompanyId, model.ApiCmpNumber, model.ApiCmpCode, model.ApiCompanyPersonId, model.ApiProjectId, model.ApiPrjTitle, model.ApiProductsInJsonFormat, model.ApiPaymentsInJsonFormat, model.ApiWarehouseId, resourceString, userId, value3, value2, text10, registerDay, text11, text12, result, objectParameter, objectParameter2, objectParameter3, model.ApiAddLinkedPrd, model.ApiAppPrjPrdHis, model.ApiOrdCurrencyUnitId, model.ApiOrdDeliveryTermId, ordDeliveryEndDate, model.ApiOrdDeliveryEndDateTime, model.ApiOrdDeliveryEndTime, model.ApiOrdDeliveryDay, model.ApiOrdDeliveryEndDay, model.CenterId, model.CenterCode, model.ApiOrdLinkAccCodeId, model.ApiOrdLinkAccCode, model.ApiOrdLinkAccOrderId, model.ApiOrdLinkAccOrderNumber, model.ApiOrdLinkAccVoucherId, model.ApiOrdLinkAccVoucherNumber, model.ApiOrdLinkAccOrderIdStr, model.ApiOrdLinkAccTransferKey, model.ApiOrdLinkAccTransferResult, model.ApiOrdLinkAccConflict, model.ApiOrdLinkAccFirstTransferDate, model.ApiOrdLinkAccLastTransferDate, model.ApiOrdLinkAccData, model.ApiCommissionInJsonFormat));
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<IssueOrderResultViewModel>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
			{
				string text13 = "";
				string text14 = objectParameter3.Value.ToString();
				if (text14.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No WhId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Warehouse", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No OprId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdOprId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No PordId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No PordVerifyId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPreOrderVerifierId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No OrdGuarantyId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdGuaranty", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No OrdPrintFormatId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPrintFormat", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No OrdRLogoId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdRLogo", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No OrdLLogoId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdLLogo", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No OrdVerifyId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdVerify", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No OrdSettlementTypeId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdSettlementType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No OrdReferUserId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdReferUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No OrdVerifierRequestId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdVerifierRequest", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No OrdStatusId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdStatus", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdCompany", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdCompanyPerson", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdProject", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No ordCurrencyUnitId|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdICurrencyUnit", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("No Prd|", StringComparison.Ordinal) >= 0 || text14.IndexOf("Not Prd|", StringComparison.Ordinal) >= 0)
				{
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("DupOrdNumber=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text14.Split(new char[1] { '=' });
					string text15 = "";
					if (array != null && array.Length == 2)
					{
						text15 = array[1] ?? "";
					}
					text15 = ((!string.IsNullOrEmpty(text15)) ? text15.TrimEnd(new char[1] { '|' }) : "");
					text13 = text13 + string.Format(MyResource.GetResourceString("ErrorOrderNumberIsRepeated", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text15) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text13.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text14.IndexOf("ErrorInComm|", StringComparison.Ordinal) >= 0)
				{
					string text16 = "";
					if (text14.IndexOf("No OrdId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text16))
						{
							text16 += "\r\n";
						}
						text16 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Order", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					}
					if (text14.IndexOf("No CommTypeId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text16))
						{
							text16 += "\r\n";
						}
						text16 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					}
					if (text14.IndexOf("No CommKindId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text16))
						{
							text16 += "\r\n";
						}
						text16 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommKind", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					}
					if (text14.IndexOf("No CommUserId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text16))
						{
							text16 += "\r\n";
						}
						text16 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					}
					if (text14.IndexOf("No VerifierId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text16))
						{
							text16 += "\r\n";
						}
						text16 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommVerifierUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					}
					if (text14.IndexOf("No CommPayTypeId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text16))
						{
							text16 += "\r\n";
						}
						text16 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommPayType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					}
					if (text14.IndexOf("No PaidUserId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text16))
						{
							text16 += "\r\n";
						}
						text16 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommIsPaidUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					}
					if (text14.IndexOf("No CurrUnId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text16))
						{
							text16 += "\r\n";
						}
						text16 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommAmountCurrUn", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					}
					if (text14.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text16))
						{
							text16 += "\r\n";
						}
						text16 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommTypeCmp", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					}
					if (text14.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text16))
						{
							text16 += "\r\n";
						}
						text16 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommTypePrs", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					}
					if (text14.IndexOf("Error", StringComparison.Ordinal) >= 0)
					{
						text16 += resourceString3;
					}
					if (!string.IsNullOrWhiteSpace(text16))
					{
						if (text16.IndexOf(resourceString3, StringComparison.Ordinal) < 0)
						{
							text16 = text16 + "\r\n" + resourceString3;
						}
						ErrorSignal.FromCurrentContext().Raise(new Exception(text14));
						return new ServiceResult<IssueOrderResultViewModel>
						{
							Message = text16.Replace("<br>", "\r\n"),
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
				}
				if (text14.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text13 += resourceString3;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text14));
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				IssueOrderResultViewModel issueOrderResultViewModel = new IssueOrderResultViewModel();
				issueOrderResultViewModel.OrderId = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				issueOrderResultViewModel.OrderNumber = ((objectParameter2.Value != null) ? long.Parse(objectParameter2.Value.ToString() ?? "0") : 0);
				data = issueOrderResultViewModel;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text17 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text17 = text17 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text17)) ? (" (" + text17 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<IssueOrderResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<FullUpdateOrderResultViewModel> FullUpdateOrder(FullUpdateOrderViewModel model)
	{
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		FullUpdateOrderResultViewModel fullUpdateOrderResultViewModel = new FullUpdateOrderResultViewModel();
		fullUpdateOrderResultViewModel.OrderResult = new ServiceResult<int>();
		fullUpdateOrderResultViewModel.OrderItemResult = new List<FullUpdateOrderResultViewModel.FullUpdateOrderItemResultViewModel>();
		fullUpdateOrderResultViewModel.OrderPaymentResult = new List<FullUpdateOrderResultViewModel.FullUpdateOrderPaymentResultViewModel>();
		try
		{
			if (model.Order != null)
			{
				fullUpdateOrderResultViewModel.OrderResult = Update(model.Order);
				if (fullUpdateOrderResultViewModel.OrderResult.Status == ServiceResultStatus.Success)
				{
					status = ServiceResultStatus.Success;
				}
			}
			if (model.OrderItemsList != null && model.OrderItemsList.Count > 0)
			{
				for (int i = 0; i < model.OrderItemsList.Count; i++)
				{
					ServiceResult<int> serviceResult = UpdateOrderItem(model.OrderItemsList[i]);
					if (serviceResult.Status != ServiceResultStatus.Success)
					{
						status = ServiceResultStatus.Error;
						message = "";
						FullUpdateOrderResultViewModel.FullUpdateOrderItemResultViewModel fullUpdateOrderItemResultViewModel = new FullUpdateOrderResultViewModel.FullUpdateOrderItemResultViewModel();
						fullUpdateOrderItemResultViewModel.Index = i;
						fullUpdateOrderItemResultViewModel.OrderItemId = model.OrderItemsList[i].ApiOrderItemId;
						fullUpdateOrderItemResultViewModel.Result = serviceResult;
						fullUpdateOrderResultViewModel.OrderItemResult.Add(fullUpdateOrderItemResultViewModel);
					}
				}
			}
			if (model.OrderPaymentsList != null && model.OrderPaymentsList.Count > 0)
			{
				for (int j = 0; j < model.OrderPaymentsList.Count; j++)
				{
					ServiceResult<int> serviceResult2 = UpdateOrderPayment(model.OrderPaymentsList[j]);
					if (serviceResult2.Status != ServiceResultStatus.Success)
					{
						status = ServiceResultStatus.Error;
						message = "";
						FullUpdateOrderResultViewModel.FullUpdateOrderPaymentResultViewModel fullUpdateOrderPaymentResultViewModel = new FullUpdateOrderResultViewModel.FullUpdateOrderPaymentResultViewModel();
						fullUpdateOrderPaymentResultViewModel.Index = j;
						fullUpdateOrderPaymentResultViewModel.OrderPaymentId = model.OrderPaymentsList[j].ApiOrderPaymentId;
						fullUpdateOrderPaymentResultViewModel.Result = serviceResult2;
						fullUpdateOrderResultViewModel.OrderPaymentResult.Add(fullUpdateOrderPaymentResultViewModel);
					}
				}
			}
			if (model.OrderCommissionsList != null && model.OrderCommissionsList.Count > 0)
			{
				for (int k = 0; k < model.OrderCommissionsList.Count; k++)
				{
					ServiceResult<int> serviceResult3 = UpdateOrderCommission(model.OrderCommissionsList[k]);
					if (serviceResult3.Status != ServiceResultStatus.Success)
					{
						status = ServiceResultStatus.Error;
						message = "";
						FullUpdateOrderResultViewModel.FullUpdateOrderCommissionResultViewModel fullUpdateOrderCommissionResultViewModel = new FullUpdateOrderResultViewModel.FullUpdateOrderCommissionResultViewModel();
						fullUpdateOrderCommissionResultViewModel.Index = k;
						fullUpdateOrderCommissionResultViewModel.OrderCommissionId = model.OrderCommissionsList[k].ApiOrderCommissionId;
						fullUpdateOrderCommissionResultViewModel.Result = serviceResult3;
						fullUpdateOrderResultViewModel.OrderCommissionResult.Add(fullUpdateOrderCommissionResultViewModel);
					}
				}
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
			status = ServiceResultStatus.Error;
			fullUpdateOrderResultViewModel = null;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return new ServiceResult<FullUpdateOrderResultViewModel>
		{
			Message = message,
			Status = status,
			Data = fullUpdateOrderResultViewModel
		};
	}

	[HttpPost]
	public ServiceResult<IssueOrderResultViewModel> Insert(InsertOrderViewModel model)
	{
		CRMEntities cRMEntities = null;
		IssueOrderResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<IssueOrderResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			if (model.ApiOrderOprId <= 0)
			{
				model.ApiOrderOprId = null;
			}
			if (model.ApiPreOrderId <= 0)
			{
				model.ApiPreOrderId = null;
			}
			if (model.ApiPreOrderVerifierId <= 0)
			{
				model.ApiPreOrderVerifierId = null;
			}
			if (model.ApiOrdGuarantyId <= 0)
			{
				model.ApiOrdGuarantyId = null;
			}
			if (model.ApiOrdDescriptionId <= 0)
			{
				model.ApiOrdDescriptionId = null;
			}
			if (model.ApiOrdPrintFormatId <= 0)
			{
				model.ApiOrdPrintFormatId = null;
			}
			if (model.ApiOrdRLogoId <= 0)
			{
				model.ApiOrdRLogoId = null;
			}
			if (model.ApiOrdLLogoId <= 0)
			{
				model.ApiOrdLLogoId = null;
			}
			if (model.ApiOrdSignatureId <= 0)
			{
				model.ApiOrdSignatureId = null;
			}
			if (model.ApiOrdVerifierId <= 0)
			{
				model.ApiOrdVerifierId = null;
			}
			if (model.ApiOrdSettlementTypeId <= 0)
			{
				model.ApiOrdSettlementTypeId = null;
			}
			if (model.ApiOrdReferUserId <= 0)
			{
				model.ApiOrdReferUserId = null;
			}
			if (model.ApiOrdVerifierRequestId <= 0)
			{
				model.ApiOrdVerifierRequestId = null;
			}
			if (model.ApiOrdStatusId <= 0)
			{
				model.ApiOrdStatusId = null;
			}
			if (model.ApiCompanyId <= 0)
			{
				model.ApiCompanyId = null;
			}
			if (model.ApiCompanyPersonId <= 0)
			{
				model.ApiCompanyPersonId = null;
			}
			if (model.ApiProjectId <= 0)
			{
				model.ApiProjectId = null;
			}
			if (!model.ApiOrdTransportation.HasValue)
			{
				model.ApiOrdTransportation = default(decimal);
			}
			if (!model.ApiOrdRound.HasValue)
			{
				model.ApiOrdRound = default(decimal);
			}
			if (!model.ApiOrdTax.HasValue)
			{
				model.ApiOrdTax = default(decimal);
			}
			if (!model.ApiOrdDiscount.HasValue)
			{
				model.ApiOrdDiscount = default(decimal);
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<IssueOrderResultViewModel>
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
			if (!VersionBuyer.Order)
			{
				return new ServiceResult<IssueOrderResultViewModel>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("Order", new CultureInfo(currLangId))),
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
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string text = null;
			string text2 = "";
			string text3 = "";
			string ordVerifiedRegisterDatePersian = null;
			string ordDeliveryEndDate = null;
			string ordDeliveryDate = null;
			string text4 = "00:00:00";
			try
			{
				if (!string.IsNullOrEmpty(model.ApiOrdDeliveryTime))
				{
					text4 = model.ApiOrdDeliveryTime;
					string s = DateTime.Now.ToString("yyyy/MM/dd") + " " + text4;
					DateTime dateTime = DateTime.Parse(s, new PersianCulture());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDeliveryTime", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!model.ApiOrdDate.HasValue)
				{
					ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				text = (model.ApiOrdDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				text2 = commonClass.ConvertNameToDayNum((model.ApiOrdDate ?? DateTime.Now).DayOfWeek.ToString());
				text3 = (model.ApiOrdDate ?? DateTime.Now).ToString("HH:mm:ss");
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiOrdVerifiedRegisterDate.HasValue)
				{
					ordVerifiedRegisterDatePersian = (model.ApiOrdVerifiedRegisterDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdVerifiedRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiOrdDeliveryDate.HasValue)
				{
					string s2 = (model.ApiOrdDeliveryDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + text4;
					model.ApiOrdDeliveryDate = DateTime.Parse(s2, new CultureInfo("en-US"));
					ordDeliveryDate = (model.ApiOrdDeliveryDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDeliveryDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiOrdDeliveryEndDateTime.HasValue)
				{
					ordDeliveryEndDate = (model.ApiOrdDeliveryEndDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
				ServiceResult<IssueOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDeliveryEndDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text5 = now.ToString("yyyyMMdd", new PersianCulture());
			string registerDay = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text6 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string text7 = CRMIdealApi.Classes.Configuration.AppType;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("InsertedOrderId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedOrderNumber", 0);
			ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertOrder(model.ApiOrderOprId, model.ApiPreOrderId, model.ApiPreOrderVerifierId, model.ApiOrdTitle, model.ApiOrdNumber, text, model.ApiOrdDate, text2, text3, model.ApiOrdSubject, model.ApiOrdInstallAmount, model.ApiOrdDiscount, model.ApiOrdTax, model.ApiOrdTaxIndex, model.ApiOrdCalculateTax, model.ApiOrdIsVerified, model.ApiOrdVerifiedRegisterDate, ordVerifiedRegisterDatePersian, model.ApiOrdIsFixed, model.ApiOrdGuarantyId, model.ApiOrdSpecialWord, model.ApiOrdDescriptionI, model.ApiOrdDescriptionII, model.ApiOrdDescriptionId, model.ApiOrdPrintFormatId, model.ApiOrdRLogoId, model.ApiOrdLLogoId, model.ApiOrdSigningI, model.ApiOrdSigningII, model.ApiOrdSigningIII, model.ApiOrdAccountNumberI, model.ApiOrdAccountShabaNumberI, model.ApiOrdAccountNumberII, model.ApiOrdAccountShabaNumberII, model.ApiOrdSignatureId, model.ApiOrdVerifierId, model.ApiOrdSettlementTypeId, model.ApiOrdTransportation, model.ApiOrdReferUserId, model.ApiOrdDiscountPercent, model.ApiOrdDiscountTitle, model.ApiOrdRound, model.ApiOrdNote, model.ApiOrdCmpTitle, ordDeliveryDate, model.ApiOrdDeliveryDate, model.ApiOrdDeliveryTime, model.ApiOrdSerial, model.ApiOrdVerifierRequestId, model.ApiOrdStatusId, model.ApiCompanyId, model.ApiCmpNumber, model.ApiCmpCode, model.ApiCompanyPersonId, model.ApiProjectId, model.ApiPrjTitle, resourceString, userId, value2, value, text5, registerDay, text6, text7, result, objectParameter, objectParameter2, objectParameter3, model.ApiOrdDeliveryTermId, ordDeliveryEndDate, model.ApiOrdDeliveryEndDateTime, model.ApiOrdDeliveryEndTime, model.ApiOrdDeliveryDay, model.ApiOrdDeliveryEndDay, model.ApiOrdCurrencyUnitId, model.CenterId, model.CenterCode, model.ApiOrdLinkAccCodeId, model.ApiOrdLinkAccCode, model.ApiOrdLinkAccOrderId, model.ApiOrdLinkAccOrderNumber, model.ApiOrdLinkAccVoucherId, model.ApiOrdLinkAccVoucherNumber, model.ApiOrdLinkAccOrderIdStr, model.ApiOrdLinkAccTransferKey, model.ApiOrdLinkAccTransferResult, model.ApiOrdLinkAccConflict, model.ApiOrdLinkAccFirstTransferDate, model.ApiOrdLinkAccLastTransferDate, model.ApiOrdLinkAccData));
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<IssueOrderResultViewModel>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
			{
				string text8 = "";
				string text9 = objectParameter3.Value.ToString();
				if (text9.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OprId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdOprId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No PordId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No PordVerifyId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPreOrderVerifierId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdGuarantyId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdGuaranty", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdPrintFormatId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPrintFormat", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdRLogoId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdRLogo", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdLLogoId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdLLogo", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdVerifyId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdVerify", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdSettlementTypeId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdSettlementType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdReferUserId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdReferUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdVerifierRequestId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdVerifierRequest", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdStatusId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdStatus", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdCompany", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdCompanyPerson", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdProject", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No ordCurrencyUnitId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CurrencyUnit", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("DupOrdNumber=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text9.Split(new char[1] { '=' });
					string text10 = "";
					if (array != null && array.Length == 2)
					{
						text10 = array[1] ?? "";
					}
					text10 = ((!string.IsNullOrEmpty(text10)) ? text10.TrimEnd(new char[1] { '|' }) : "");
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorOrderNumberIsRepeated", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text10) + " " + resourceString3;
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text8 += resourceString3;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text9));
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					return new ServiceResult<IssueOrderResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				IssueOrderResultViewModel issueOrderResultViewModel = new IssueOrderResultViewModel();
				issueOrderResultViewModel.OrderId = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				issueOrderResultViewModel.OrderNumber = ((objectParameter2.Value != null) ? long.Parse(objectParameter2.Value.ToString() ?? "0") : 0);
				data = issueOrderResultViewModel;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text11 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text11 = text11 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text11)) ? (" (" + text11 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<IssueOrderResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> InsertOrderItem(InsertOrderItemViewModel model)
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
			CommonClass commonClass = new CommonClass();
			if (model.ApiOrderId <= 0)
			{
				model.ApiOrderId = null;
			}
			if (model.ApiOrdIPrdId <= 0)
			{
				model.ApiOrdIPrdId = null;
			}
			if (model.ApiOrdIPrdUnitId <= 0)
			{
				model.ApiOrdIPrdUnitId = null;
			}
			if (model.ApiOrdICurrencyUnitId <= 0)
			{
				model.ApiOrdICurrencyUnitId = null;
			}
			if (model.ApiOrdIWHId <= 0)
			{
				model.ApiOrdIWHId = null;
			}
			if (model.ApiOrdIPrdPriceGroupID <= 0)
			{
				model.ApiOrdIPrdPriceGroupID = null;
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
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiOrdIValidityExpireDate.HasValue)
				{
					string text = (model.ApiOrdIValidityExpireDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdIValidityExpireDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			string text3 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text4 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string text5 = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedOrderItemId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			CRMEntities cRMEntities2 = cRMEntities;
			int? apiOrderId = model.ApiOrderId;
			long? apiOrdNumber = model.ApiOrdNumber;
			int? apiOrdIPrdId = model.ApiOrdIPrdId;
			string apiOrdIPrdCode = model.ApiOrdIPrdCode;
			double? apiOrdIQuantity = model.ApiOrdIQuantity;
			decimal? apiOrdIPrice = model.ApiOrdIPrice;
			decimal? apiOrdITotalPrice = model.ApiOrdITotalPrice;
			string apiOrdIDescription = model.ApiOrdIDescription;
			string apiOrdIQuantityDesc = model.ApiOrdIQuantityDesc;
			decimal? apiOrdIDiscount = model.ApiOrdIDiscount;
			decimal? apiOrdIDiscountI = model.ApiOrdIDiscountI;
			decimal? apiOrdIDiscountPercent = model.ApiOrdIDiscountPercent;
			decimal? apiOrdIDiscountIPercent = model.ApiOrdIDiscountIPercent;
			int? apiOrdIPrdUnitId = model.ApiOrdIPrdUnitId;
			int? apiOrdICurrencyUnitId = model.ApiOrdICurrencyUnitId;
			int? apiOrdIOrderView = model.ApiOrdIOrderView;
			double? apiOrdIFCR = model.ApiOrdIFCR;
			decimal? apiOrdITax = model.ApiOrdITax;
			decimal? apiOrdITaxIndex = model.ApiOrdITaxIndex;
			bool? apiOrdICalculateTax = model.ApiOrdICalculateTax;
			bool? apiOrdINotVisible = model.ApiOrdINotVisible;
			double? apiOrdIFCRI = model.ApiOrdIFCRI;
			bool? apiOrdINotInSum = model.ApiOrdINotInSum;
			int? apiOrdIWHId = model.ApiOrdIWHId;
			decimal? apiOrdIRound = model.ApiOrdIRound;
			decimal? apiOrdIRoundPlus = model.ApiOrdIRoundPlus;
			double? apiOrdIPricePartRate = model.ApiOrdIPricePartRate;
			decimal? apiOrdIPricePartI = model.ApiOrdIPricePartI;
			decimal? apiOrdIPricePartII = model.ApiOrdIPricePartII;
			int? num2 = userId;
			short? num3 = value2;
			DateTime? dateTime = value;
			string text6 = text2;
			string text7 = text5;
			int? num4 = result;
			ObjectParameter objectParameter3 = objectParameter;
			ObjectParameter objectParameter4 = objectParameter2;
			int? num5 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.ApispInsertOrderItems(ordIPrdPriceGroupID: model.ApiOrdIPrdPriceGroupID, ordITracing: model.ApiOrdITracing, userId: num2, month1: num3, registerDate: dateTime, registerDatePersian: text6, appType: text7, languageID: num4, insertedOrderItemId: objectParameter3, errorMessage: objectParameter4, ordIValidityExpireDate: model.ApiOrdIValidityExpireDate, ordIValidityExpireDay: model.ApiOrdIValidityExpireDay, ordIValidityExpireHour: model.ApiOrdIValidityExpireHour, ordIValidityExpireMinute: model.ApiOrdIValidityExpireMinute, ordIPrdValidityCountingMin: model.ApiOrdIPrdValidityCountingMin, ordIPrdValidityCountingNum: model.ApiOrdIPrdValidityCountingNum, ordIDeliveryTermId: model.ApiOrdIDeliveryTermId, ordIDeliveryDate: model.ApiOrdIDeliveryDate, ordIDeliveryTime: model.ApiOrdIDeliveryTime, ordIDeliveryDay: model.ApiOrdIDeliveryDay, ordIDeliveryEndDate: model.ApiOrdIDeliveryEndDate, ordIDeliveryEndTime: model.ApiOrdIDeliveryEndTime, ordIDeliveryEndDay: model.ApiOrdIDeliveryEndDay, ordIDeliveryUserId: model.ApiOrdIDeliveryUserId, centerId: model.CenterId, centerCode: model.CenterCode, ordILinkAccItemId: model.ApiOrdILinkAccItemId, ordILinkAccItemIdStr: model.ApiOrdILinkAccItemIdStr, ordILinkAccWHIdStr: model.ApiOrdILinkAccWHIdStr, ordILinkAccFirstTransferDate: model.ApiOrdILinkAccFirstTransferDate, ordILinkAccLastTransferDate: model.ApiOrdILinkAccLastTransferDate, ordILinkAccData: model.ApiOrdILinkAccData, ordIDiscountSum: model.ApiOrdIDiscountSum, orderId: apiOrderId, ordNumber: apiOrdNumber, ordIPrdId: apiOrdIPrdId, ordIPrdCode: apiOrdIPrdCode, ordIQuantity: apiOrdIQuantity, ordIPrice: apiOrdIPrice, ordITotalPrice: apiOrdITotalPrice, ordIDescription: apiOrdIDescription, ordIQuantityDesc: apiOrdIQuantityDesc, ordIDiscountI: apiOrdIDiscountI, ordIDiscount: apiOrdIDiscount, ordIDiscountPercent: apiOrdIDiscountPercent, ordIDiscountIPercent: apiOrdIDiscountIPercent, ordIPrdUnitId: apiOrdIPrdUnitId, ordICurrencyUnitId: apiOrdICurrencyUnitId, ordIOrderView: apiOrdIOrderView, ordIFCR: apiOrdIFCR, ordITax: apiOrdITax, ordITaxIndex: apiOrdITaxIndex, ordICalculateTax: apiOrdICalculateTax, ordINotVisible: apiOrdINotVisible, ordIFCRI: apiOrdIFCRI, ordINotInSum: apiOrdINotInSum, ordIWHId: apiOrdIWHId, ordIRound: apiOrdIRound, ordIRoundPlus: apiOrdIRoundPlus, ordIPricePartRate: apiOrdIPricePartRate, ordIPricePartI: apiOrdIPricePartI, ordIPricePartII: apiOrdIPricePartII, ordIPriceSum: model.ApiOrdIPriceSum, ordITaxSum: model.ApiOrdITaxSum));
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num5.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<int>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
			{
				string text8 = "";
				string text9 = objectParameter2.Value.ToString();
				if (text9.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Order", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No PrdId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdIPrdUnitId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdIPrdUnit", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdICurrencyUnitId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdICurrencyUnit", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdIWHId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Warehouse", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdIPrdPriceGroupID|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdPriceGroupId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("IsFixed|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + MyResource.GetResourceString("ErrorOrdIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text8 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text9));
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
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
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Fail
					};
				}
				data = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text10 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text10 = text10 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text10)) ? (" (" + text10 + ")") : "");
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
	public ServiceResult<int> InsertOrderPayment(InsertOrderPaymentViewModel model)
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
			CommonClass commonClass = new CommonClass();
			if (model.ApiOrderId <= 0)
			{
				model.ApiOrderId = null;
			}
			if (model.ApiOrdPayTypeId <= 0)
			{
				model.ApiOrdPayTypeId = null;
			}
			if (model.ApiOrdPayDocId <= 0)
			{
				model.ApiOrdPayDocId = null;
			}
			if (model.ApiOrdPayDocTypeId <= 0)
			{
				model.ApiOrdPayDocTypeId = null;
			}
			if (model.ApiPreOrderPaymentId <= 0)
			{
				model.ApiPreOrderPaymentId = null;
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!model.ApiOrdPayAmount.HasValue)
			{
				goto IL_025b;
			}
			decimal? apiOrdPayAmount = model.ApiOrdPayAmount;
			if ((apiOrdPayAmount.GetValueOrDefault() == default(decimal)) & apiOrdPayAmount.HasValue)
			{
				goto IL_025b;
			}
			if (!model.ApiOrdPayDocAmount.HasValue)
			{
				model.ApiOrdPayDocAmount = model.ApiOrdPayAmount;
			}
			string text = null;
			try
			{
				if (model.ApiOrdPayDocDateTime.HasValue)
				{
					text = (model.ApiOrdPayDocDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPayDocDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
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
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			string text3 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text4 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string text5 = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedOrderPaymentId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			CRMEntities cRMEntities2 = cRMEntities;
			int? apiOrderId = model.ApiOrderId;
			long? apiOrdNumber = model.ApiOrdNumber;
			int? apiOrdPayTypeId = model.ApiOrdPayTypeId;
			int? apiOrdPayDocId = model.ApiOrdPayDocId;
			int? apiOrdPayDocTypeId = model.ApiOrdPayDocTypeId;
			decimal? apiOrdPayAmount2 = model.ApiOrdPayAmount;
			string apiOrdPayDocNumber = model.ApiOrdPayDocNumber;
			string ordpayDocDate = text;
			DateTime? apiOrdPayDocDateTime = model.ApiOrdPayDocDateTime;
			string apiOrdPayDescription = model.ApiOrdPayDescription;
			decimal? apiOrdPayDocAmount = model.ApiOrdPayDocAmount;
			int? apiPreOrderPaymentId = model.ApiPreOrderPaymentId;
			int? userId2 = userId;
			short? num2 = value2;
			DateTime? dateTime = value;
			string text6 = text2;
			string text7 = text5;
			int? languageID = result;
			ObjectParameter insertedOrderPaymentId = objectParameter;
			ObjectParameter errorMessage = objectParameter2;
			int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.ApispInsertOrderPayments(apiOrderId, apiOrdNumber, apiOrdPayTypeId, apiOrdPayDocId, apiOrdPayDocTypeId, apiOrdPayAmount2, apiOrdPayDocNumber, ordpayDocDate, apiOrdPayDocDateTime, apiOrdPayDescription, apiOrdPayDocAmount, apiPreOrderPaymentId, model.ApiOrdpayBankDocNumber, userId2, num2, dateTime, text6, text7, languageID, insertedOrderPaymentId, errorMessage, model.CenterId, model.CenterCode, model.ApiOrdpayLinkAccHeaderId, model.ApiOrdpayLinkAccHeaderNumber, model.ApiOrdpayLinkAccDetailId, model.ApiOrdpayLinkAccVoucherId, model.ApiOrdpayLinkAccVoucherNumber, model.ApiOrdpayLinkAccHeaderIdStr, model.ApiOrdpayLinkAccDetailIdStr, model.ApiOrdpayLinkAccVoucherIdStr, model.ApiOrdpayLinkAccPayType, model.ApiOrdpayLinkAccFirstTransferDate, model.ApiOrdpayLinkAccLastTransferDate, model.ApiOrdpayLinkAccData, model.ApiOrdpayBankingBankID, model.ApiOrdpayBankingBranchID, model.ApiOrdpayBankingAccountID, model.ApiOrdpayCashId, model.ApiOrdpayGroupIdI, model.ApiOrdpayGroupIdII, model.ApiOrdpayChqSayadNumber, model.ApiOrdpayChqSerialNumber, model.ApiTspOrdPayIinn, model.ApiTspOrdPayAcn, model.ApiTspOrdPayTrmn, model.ApiTspOrdPayPmt, model.ApiOrdpayDocDayTemp, model.ApiOrdpayBankName, model.ApiOrdpayBranchName, model.ApiOrdpayBranchCode));
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num3.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<int>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
			{
				string text8 = "";
				string text9 = objectParameter2.Value.ToString();
				if (text9.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Order", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayTypeId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPayType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayBankingBankID|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayBankingBankID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayBankingBranchID|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayBankingBranchID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayBankingAccountID|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayBankingAccountID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayCashId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayCashId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayGroupIId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayGroupIId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayGroupIIId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayGroupIIId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text8 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text9));
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
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
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Fail
					};
				}
				data = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			goto end_IL_000c;
			IL_025b:
			string text10 = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPayAmount", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			return new ServiceResult<int>
			{
				Message = text10.Replace("<br>", "\r\n"),
				Data = 0,
				Status = ServiceResultStatus.Error
			};
			end_IL_000c:;
		}
		catch (Exception ex)
		{
			string text11 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text11 = text11 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text11)) ? (" (" + text11 + ")") : "");
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
	public ServiceResult<int> Update(UpdateOrderViewModel model)
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
			CommonClass commonClass = new CommonClass();
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
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string text = null;
			string text2 = "";
			string text3 = "";
			string text4 = null;
			string text5 = null;
			string text6 = "00:00:00";
			if (!string.IsNullOrEmpty(model.ApiOrdDeliveryTime) && model.ApiOrdDeliveryTime.ToLower() == "null")
			{
				text6 = model.ApiOrdDeliveryTime;
			}
			else
			{
				try
				{
					if (!string.IsNullOrEmpty(model.ApiOrdDeliveryTime))
					{
						text6 = model.ApiOrdDeliveryTime;
						string s = DateTime.Now.ToString("yyyy/MM/dd") + " " + text6;
						DateTime dateTime = DateTime.Parse(s, new PersianCulture());
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					ErrorSignal.FromCurrentContext().Raise(e);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDeliveryTime", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiOrdDate) && model.ApiOrdDate.ToLower() == "null")
			{
				text = model.ApiOrdDate;
				model.ApiOrdDateTime = null;
				text2 = "null";
				text3 = "null";
			}
			else
			{
				try
				{
					if (model.ApiOrdDateTime.HasValue)
					{
						text = (model.ApiOrdDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
						text2 = commonClass.ConvertNameToDayNum((model.ApiOrdDateTime ?? DateTime.Now).DayOfWeek.ToString());
						text3 = (model.ApiOrdDateTime ?? DateTime.Now).ToString("HH:mm:ss");
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiOrdVerifiedRegisterDatePersian) && model.ApiOrdVerifiedRegisterDatePersian.ToLower() == "null")
			{
				text4 = model.ApiOrdVerifiedRegisterDatePersian;
				model.ApiOrdVerifiedRegisterDate = null;
			}
			else
			{
				try
				{
					if (model.ApiOrdVerifiedRegisterDate.HasValue)
					{
						text4 = (model.ApiOrdVerifiedRegisterDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdVerifiedRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiOrdDeliveryDatePersian) && model.ApiOrdDeliveryDatePersian.ToLower() == "null")
			{
				text5 = model.ApiOrdDeliveryDatePersian;
				model.ApiOrdDeliveryDate = null;
			}
			else
			{
				try
				{
					if (model.ApiOrdDeliveryDate.HasValue)
					{
						string s2 = (model.ApiOrdDeliveryDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + ((text6 != "null" && !string.IsNullOrEmpty(text6)) ? text6 : DateTime.Now.ToString("HH:mm:ss"));
						model.ApiOrdDeliveryDate = DateTime.Parse(s2, new CultureInfo("en-US"));
						text5 = (model.ApiOrdDeliveryDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e4)
				{
					ErrorSignal.FromCurrentContext().Raise(e4);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdDeliveryDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiOrderId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text7 = now.ToString("yyyyMMdd", new PersianCulture());
			string text8 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text9 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string text10 = CRMIdealApi.Classes.Configuration.AppType;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			CRMEntities cRMEntities2 = cRMEntities;
			int? orderID = model.ApiOrderId;
			int? apiOrdOprId = model.ApiOrdOprId;
			int? apiPreOrderId = model.ApiPreOrderId;
			int? apiPreOrderVerifierId = model.ApiPreOrderVerifierId;
			string apiOrdTitle = model.ApiOrdTitle;
			long? apiOrdNumber = model.ApiOrdNumber;
			string ordDate = text;
			DateTime? apiOrdDateTime = model.ApiOrdDateTime;
			string text11 = text2;
			string text12 = text3;
			string apiOrdSubject = model.ApiOrdSubject;
			int? num2 = null;
			decimal? num3 = null;
			decimal? apiOrdInstallAmount = model.ApiOrdInstallAmount;
			decimal? apiOrdDiscount = model.ApiOrdDiscount;
			decimal? num4 = null;
			decimal? apiOrdTax = model.ApiOrdTax;
			decimal? apiOrdTaxIndex = model.ApiOrdTaxIndex;
			bool? apiOrdCalculateTax = model.ApiOrdCalculateTax;
			decimal? num5 = null;
			bool? apiOrdIsVerified = model.ApiOrdIsVerified;
			DateTime? apiOrdVerifiedRegisterDate = model.ApiOrdVerifiedRegisterDate;
			string text13 = text4;
			bool? apiOrdIsFixed = model.ApiOrdIsFixed;
			int? apiOrdGuarantyId = model.ApiOrdGuarantyId;
			string apiOrdSpecialWord = model.ApiOrdSpecialWord;
			string apiOrdDescriptionI = model.ApiOrdDescriptionI;
			string apiOrdDescriptionII = model.ApiOrdDescriptionII;
			int? apiOrdDescriptionId = model.ApiOrdDescriptionId;
			int? apiOrdPrintFormatId = model.ApiOrdPrintFormatId;
			int? apiOrdRLogoId = model.ApiOrdRLogoId;
			int? apiOrdLLogoId = model.ApiOrdLLogoId;
			string apiOrdSigningI = model.ApiOrdSigningI;
			string apiOrdSigningII = model.ApiOrdSigningII;
			string apiOrdSigningIII = model.ApiOrdSigningIII;
			string apiOrdAccountNumberI = model.ApiOrdAccountNumberI;
			string apiOrdAccountShabaNumberI = model.ApiOrdAccountShabaNumberI;
			string apiOrdAccountNumberII = model.ApiOrdAccountNumberII;
			string apiOrdAccountShabaNumberII = model.ApiOrdAccountShabaNumberII;
			int? apiOrdSignatureId = model.ApiOrdSignatureId;
			int? apiOrdVerifierId = model.ApiOrdVerifierId;
			int? apiOrdSettlementTypeId = model.ApiOrdSettlementTypeId;
			decimal? apiOrdTransportation = model.ApiOrdTransportation;
			int? apiOrdReferUserId = model.ApiOrdReferUserId;
			decimal? apiOrdDiscountPercent = model.ApiOrdDiscountPercent;
			string apiOrdDiscountTitle = model.ApiOrdDiscountTitle;
			decimal? apiOrdRound = model.ApiOrdRound;
			string apiOrdNote = model.ApiOrdNote;
			string apiOrdCmpTitle = model.ApiOrdCmpTitle;
			string text14 = text5;
			DateTime? apiOrdDeliveryDate = model.ApiOrdDeliveryDate;
			string apiOrdDeliveryTime = model.ApiOrdDeliveryTime;
			string apiOrdSerial = model.ApiOrdSerial;
			int? apiOrdVerifierRequestId = model.ApiOrdVerifierRequestId;
			int? apiOrdVerificationWorkFlowId = model.ApiOrdVerificationWorkFlowId;
			int? apiOrdStatusId = model.ApiOrdStatusId;
			int num6 = cRMEntities2.ApispUpdateOrder(ordCompanyId: model.ApiCompanyId, ordCompanyPersonId: model.ApiCompanyPersonId, ordProjectId: model.ApiProjectId, ordSubject: apiOrdSubject, ordItemCount: num2, ordItemsAmount: num3, ordInstallAmount: apiOrdInstallAmount, ordDiscount: apiOrdDiscount, ordSumAmount: num4, ordTax: apiOrdTax, ordTaxIndex: apiOrdTaxIndex, ordCalculateTax: apiOrdCalculateTax, ordTotalAmount: num5, ordTotalAmountStr: null, ordIsVerified: apiOrdIsVerified, ordVerifiedRegisterDate: apiOrdVerifiedRegisterDate, ordVerifiedRegisterDatePersian: text13, ordStatusId: apiOrdStatusId, ordIsFixed: apiOrdIsFixed, ordGuarantyId: apiOrdGuarantyId, ordSpecialWord: apiOrdSpecialWord, ordDescriptionI: apiOrdDescriptionI, ordDescriptionII: apiOrdDescriptionII, ordDescriptionId: apiOrdDescriptionId, ordPrintFormatId: apiOrdPrintFormatId, ordRLogoId: apiOrdRLogoId, ordLLogoId: apiOrdLLogoId, ordSigningI: apiOrdSigningI, ordSigningII: apiOrdSigningII, ordSigningIII: apiOrdSigningIII, ordAccountNumberI: apiOrdAccountNumberI, ordAccountShabaNumberI: apiOrdAccountShabaNumberI, ordAccountNumberII: apiOrdAccountNumberII, ordAccountShabaNumberII: apiOrdAccountShabaNumberII, ordSignatureId: apiOrdSignatureId, ordVerifierId: apiOrdVerifierId, ordSettlementTypeId: apiOrdSettlementTypeId, ordDay: text11, ordTime: text12, ordTransportation: apiOrdTransportation, ordReferUserId: apiOrdReferUserId, ordDiscountPercent: apiOrdDiscountPercent, ordDiscountTitle: apiOrdDiscountTitle, ordRound: apiOrdRound, ordNote: apiOrdNote, ordcmpTitle: apiOrdCmpTitle, ordDeliveryDate: text14, ordDeliveryDateTime: apiOrdDeliveryDate, ordDeliveryTime: apiOrdDeliveryTime, ordSerial: apiOrdSerial, ordVerifierRequestId: apiOrdVerifierRequestId, ordVerificationWorkFlowId: apiOrdVerificationWorkFlowId, userId: userId, month1: value2, orderID: orderID, orderOprID: apiOrdOprId, preOrderId: apiPreOrderId, preOrderVerifierId: apiPreOrderVerifierId, ordTitle: apiOrdTitle, ordNumber: apiOrdNumber, ordDate: ordDate, ordDateTime: apiOrdDateTime, registerDate: value, registerDatePersian: text7, appType: text10, languageID: currLangId, defaultLanguageID: result, errorMessage: objectParameter, ordDeliveryTermId: model.ApiOrdDeliveryTermId, ordDeliveryEndDate: model.ApiOrdDeliveryEndDate, ordDeliveryEndDateTime: model.ApiOrdDeliveryEndDateTime, ordDeliveryEndTime: model.ApiOrdDeliveryEndTime, ordDeliveryDay: model.ApiOrdDeliveryDay, ordDeliveryEndDay: model.ApiOrdDeliveryEndDay, ordCurrencyUnitId: model.ApiOrdCurrencyUnitId, ordLinkAccCodeId: model.ApiOrdLinkAccCodeId, ordLinkAccCode: model.ApiOrdLinkAccCode, ordLinkAccOrderId: model.ApiOrdLinkAccOrderId, ordLinkAccOrderNumber: model.ApiOrdLinkAccOrderNumber, ordLinkAccVoucherId: model.ApiOrdLinkAccVoucherId, ordLinkAccVoucherNumber: model.ApiOrdLinkAccVoucherNumber, ordLinkAccOrderIdStr: model.ApiOrdLinkAccOrderIdStr, ordLinkAccTransferKey: model.ApiOrdLinkAccTransferKey, ordLinkAccTransferResult: model.ApiOrdLinkAccTransferResult, ordLinkAccConflict: model.ApiOrdLinkAccConflict, ordLinkAccFirstTransferDate: model.ApiOrdLinkAccFirstTransferDate, ordLinkAccLastTransferDate: model.ApiOrdLinkAccLastTransferDate, ordLinkAccData: model.ApiOrdLinkAccData, centerId: model.CenterId, centerCode: model.CenterCode);
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num6.ToString(), out result3);
			if (result3 < 0 && objectParameter.Value == null)
			{
				return new ServiceResult<int>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
			{
				string text15 = "";
				string text16 = objectParameter.Value.ToString();
				if (text16.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No OprId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdOprId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No PordId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No PordVerifyId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPreOrderVerifierId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No OrdGuarantyId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdGuaranty", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No OrdPrintFormatId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPrintFormat", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No OrdRLogoId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdRLogo", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No OrdLLogoId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdLLogo", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No OrdVerifyId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdVerify", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No OrdSettlementTypeId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdSettlementType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No OrdReferUserId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdReferUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No OrdVerifierRequestId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdVerifierRequest", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No OrdStatusId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdStatus", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdCompany", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdCompanyPerson", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdProject", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("No ordCurrencyUnitId|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CurrencyUnit", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("DupOrdNumber=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text16.Split(new char[1] { '=' });
					string text17 = "";
					if (array != null && array.Length == 2)
					{
						text17 = array[1] ?? "";
					}
					text17 = ((!string.IsNullOrEmpty(text17)) ? text17.TrimEnd(new char[1] { '|' }) : "");
					text15 = text15 + string.Format(MyResource.GetResourceString("ErrorOrderNumberIsRepeated", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text17) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("IsFixed|", StringComparison.Ordinal) >= 0)
				{
					text15 = text15 + MyResource.GetResourceString("ErrorOrdIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text15.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text16.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text15 += resourceString3;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text16));
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text18 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text18 = text18 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text18)) ? (" (" + text18 + ")") : "");
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
	public ServiceResult<List<ApispSelectOrder_Result>> Select(SelectOrderViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectOrder_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectOrder_Result>>
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
				return new ServiceResult<List<ApispSelectOrder_Result>>
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
				ServiceResult<List<ApispSelectOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectOrder_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			DateTime value5 = DateTime.Now;
			DateTime value6 = DateTime.Now;
			try
			{
				if (!string.IsNullOrEmpty(model.FromOrdDate))
				{
					model.FromOrdDate = model.FromOrdDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value5 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.FromOrdDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.FromOrdDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi = PersianDate.GetShamsi2Miladi(model.FromOrdDate);
						value5 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<List<ApispSelectOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectOrder_Result>> result3 = serviceResult;
				cRMEntities?.Dispose();
				return result3;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ToOrdDate))
				{
					model.ToOrdDate = model.ToOrdDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value6 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.ToOrdDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.ToOrdDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi2 = PersianDate.GetShamsi2Miladi(model.ToOrdDate);
						value6 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi2) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<List<ApispSelectOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectOrder_Result>> result4 = serviceResult;
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
				ServiceResult<List<ApispSelectOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectOrder_Result>> result5 = serviceResult;
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
				ServiceResult<List<ApispSelectOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectOrder_Result>> result6 = serviceResult;
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
				ServiceResult<List<ApispSelectOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectOrder_Result>> result7 = serviceResult;
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
				ServiceResult<List<ApispSelectOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectOrder_Result>> result8 = serviceResult;
				cRMEntities?.Dispose();
				return result8;
			}
			model.PageSize = ((model.PageNumber.HasValue && model.PageNumber > 0 && (!model.PageSize.HasValue || model.PageSize == 0)) ? new int?(20) : model.PageSize);
			List<ApispSelectOrder_Result> list2 = Enumerable.ToList<ApispSelectOrder_Result>((IEnumerable<ApispSelectOrder_Result>)cRMEntities.ApispSelectOrder(model.ApiOrderId, model.ApiOrdNumber, fromRegisterDate: (!string.IsNullOrEmpty(model.FromRegisterDate)) ? new DateTime?(value) : null, toRegisterDate: (!string.IsNullOrEmpty(model.ToRegisterDate)) ? new DateTime?(value2) : null, fromFirstRegisterDate: (!string.IsNullOrEmpty(model.FromFirstRegisterDate)) ? new DateTime?(value3) : null, toFirstRegisterDate: (!string.IsNullOrEmpty(model.ToFirstRegisterDate)) ? new DateTime?(value4) : null, fromOrderDate: (!string.IsNullOrEmpty(model.FromOrdDate)) ? new DateTime?(value5) : null, toOrderDate: (!string.IsNullOrEmpty(model.ToOrdDate)) ? new DateTime?(value6) : null, languageID: currLangId, defaultLanguageID: result, centerId: model.CenterId, centerCode: model.CenterCode, pageNumber: model.PageNumber, pageSize: model.PageSize));
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
		return new ServiceResult<List<ApispSelectOrder_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteOrderViewModel model)
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
			if (model.ApiOrderId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteOrder(model.ApiOrderId));
				if (mct_Result != null)
				{
					if (mct_Result.Result > 0)
					{
						data = true;
						message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Success;
					}
					else if (mct_Result.Result == -2)
					{
						data = false;
						message = MyResource.GetResourceString("ErrorOrdIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Fail;
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
	public ServiceResult<bool> Verify(VerifyOrderViewModel model)
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
				ServiceResult<bool> serviceResult = new ServiceResult<bool>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiOrderId > 0)
			{
				cRMEntities.ApispOrderVerify(model.ApiOrderId, model.ApiVerifierUserId, model.ApiVerifyDate, text);
				data = true;
				message = MyResource.GetResourceString("SuccessDoneRegister", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				data = false;
				message = MyResource.GetResourceString("ErrorNotFound", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
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
	public ServiceResult<bool> ExitVerify(ExitVerifyOrderViewModel model)
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
			if (model.ApiOrderId > 0)
			{
				cRMEntities.ApispOrderVerifyExit(model.ApiOrderId);
				data = true;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
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
	public ServiceResult<int> UpdateOrderItem(UpdateOrderItemsViewModel model)
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
			CommonClass commonClass = new CommonClass();
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
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiOrderItemId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			string ordIValidityExpireDatePersian = null;
			if (!string.IsNullOrEmpty(model.ApiOrdIValidityExpireDate) && model.ApiOrdIValidityExpireDate.ToLower() == "null")
			{
				ordIValidityExpireDatePersian = model.ApiOrdIValidityExpireDate;
				model.ApiOrdIValidityExpireDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiOrdIValidityExpireDateTime.HasValue)
					{
						ordIValidityExpireDatePersian = (model.ApiOrdIValidityExpireDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdIValidityExpireDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			string ordIDeliveryDatePersian = null;
			if (!string.IsNullOrEmpty(model.ApiOrdIDeliveryDatePersian) && model.ApiOrdIDeliveryDatePersian.ToLower() == "null")
			{
				ordIValidityExpireDatePersian = model.ApiOrdIDeliveryDatePersian;
				model.ApiOrdIDeliveryDate = null;
			}
			else
			{
				try
				{
					if (model.ApiOrdIDeliveryDate.HasValue)
					{
						ordIDeliveryDatePersian = (model.ApiOrdIDeliveryDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdIDeliveryDatePersian", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			string ordIDeliveryEndDatePersian = null;
			if (!string.IsNullOrEmpty(model.ApiOrdIDeliveryEndDatePersian) && model.ApiOrdIDeliveryEndDatePersian.ToLower() == "null")
			{
				ordIDeliveryEndDatePersian = model.ApiOrdIDeliveryEndDatePersian;
				model.ApiOrdIDeliveryEndDate = null;
			}
			else
			{
				try
				{
					if (model.ApiOrdIDeliveryEndDate.HasValue)
					{
						ordIDeliveryEndDatePersian = (model.ApiOrdIDeliveryEndDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("[rdIDeliveryEndDatePersian", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text3 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string text4 = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			CRMEntities cRMEntities2 = cRMEntities;
			int? orderItemID = model.ApiOrderItemId;
			int? apiOrderId = model.ApiOrderId;
			int? apiOrdIPrdId = model.ApiOrdIPrdId;
			double? apiOrdIQuantity = model.ApiOrdIQuantity;
			decimal? apiOrdIPrice = model.ApiOrdIPrice;
			decimal? apiOrdITotalPrice = model.ApiOrdITotalPrice;
			string apiOrdIDescription = model.ApiOrdIDescription;
			string apiOrdIQuantityDesc = model.ApiOrdIQuantityDesc;
			decimal? apiOrdIDiscount = model.ApiOrdIDiscount;
			decimal? apiOrdIDiscountI = model.ApiOrdIDiscountI;
			decimal? apiOrdIDiscountPercent = model.ApiOrdIDiscountPercent;
			decimal? apiOrdIDiscountIPercent = model.ApiOrdIDiscountIPercent;
			int? apiOrdIPrdUnitId = model.ApiOrdIPrdUnitId;
			int? apiOrdICurrencyUnitId = model.ApiOrdICurrencyUnitId;
			int? apiOrdIOrderView = model.ApiOrdIOrderView;
			double? apiOrdIFCR = model.ApiOrdIFCR;
			decimal? apiOrdITax = model.ApiOrdITax;
			decimal? apiOrdITaxIndex = model.ApiOrdITaxIndex;
			bool? apiOrdICalculateTax = model.ApiOrdICalculateTax;
			bool? apiOrdINotVisible = model.ApiOrdINotVisible;
			double? apiOrdIFCRI = model.ApiOrdIFCRI;
			bool? apiOrdINotInSum = model.ApiOrdINotInSum;
			int? apiOrdIWHId = model.ApiOrdIWHId;
			decimal? apiOrdIRound = model.ApiOrdIRound;
			decimal? apiOrdIRoundPlus = model.ApiOrdIRoundPlus;
			double? apiOrdIPricePartRate = model.ApiOrdIPricePartRate;
			decimal? apiOrdIPricePartI = model.ApiOrdIPricePartI;
			decimal? apiOrdIPricePartII = model.ApiOrdIPricePartII;
			int? apiOrdIPrdPriceGroupID = model.ApiOrdIPrdPriceGroupID;
			string apiOrdITracing = model.ApiOrdITracing;
			int? userId2 = userId;
			short? num2 = value2;
			DateTime? dateTime = value;
			string text5 = text;
			int num3 = cRMEntities2.ApispUpdateOrderItems(orderItemID, apiOrderId, apiOrdIPrdId, apiOrdIQuantity, apiOrdIPrice, apiOrdITotalPrice, apiOrdIDescription, apiOrdIQuantityDesc, apiOrdIDiscountI, apiOrdIDiscount, apiOrdIDiscountPercent, apiOrdIDiscountIPercent, apiOrdIPrdUnitId, apiOrdICurrencyUnitId, apiOrdIOrderView, apiOrdIFCR, apiOrdITax, apiOrdITaxIndex, apiOrdICalculateTax, apiOrdINotVisible, apiOrdIFCRI, apiOrdINotInSum, apiOrdIWHId, apiOrdIRound, apiOrdIRoundPlus, apiOrdIPricePartRate, apiOrdIPricePartI, apiOrdIPricePartII, apiOrdIPrdPriceGroupID, apiOrdITracing, text4, num2, userId2, dateTime, text5, currLangId, result, objectParameter, model.ApiOrdIValidityExpireDateTime, ordIValidityExpireDatePersian, model.ApiOrdIValidityExpireDay, model.ApiOrdIValidityExpireHour, model.ApiOrdIValidityExpireMinute, model.ApiOrdIPrdValidityCountingMin, model.ApiOrdIPrdValidityCountingNum, model.ApiOrdIDeliveryTermId, model.ApiOrdIDeliveryDate, ordIDeliveryDatePersian, model.ApiOrdIDeliveryTime, model.ApiOrdIDeliveryDay, model.ApiOrdIDeliveryEndDate, ordIDeliveryEndDatePersian, model.ApiOrdIDeliveryEndTime, model.ApiOrdIDeliveryEndDay, model.ApiOrdIDeliveryUserId, model.ApiOrdILinkAccItemId, model.ApiOrdILinkAccItemIdStr, model.ApiOrdILinkAccWHIdStr, model.ApiOrdILinkAccFirstTransferDate, model.ApiOrdILinkAccLastTransferDate, model.ApiOrdILinkAccData, model.ApiOrdIPriceSum, model.ApiOrdIDiscountSum, model.ApiOrdITaxSum);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num3.ToString(), out result3);
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
				string text6 = "";
				string text7 = objectParameter.Value.ToString();
				if (text7.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No OrdId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Order", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PrdId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No OrdIPrdUnitId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdIPrdUnit", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No OrdICurrencyUnitId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdICurrencyUnit", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No OrdIWHId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Warehouse", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No OrdIPrdPriceGroupID|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdPriceGroupId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("IsFixed|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + MyResource.GetResourceString("ErrorOrdIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text6 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text7));
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text8 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text8 = text8 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text8)) ? (" (" + text8 + ")") : "");
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
	public ServiceResult<List<ApispSelectOrderItems_Result>> SelectOrderItems(SelectOrderItemsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectOrderItems_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectOrderItems_Result>>
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
				return new ServiceResult<List<ApispSelectOrderItems_Result>>
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
				ServiceResult<List<ApispSelectOrderItems_Result>> serviceResult = new ServiceResult<List<ApispSelectOrderItems_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectOrderItems_Result> list2 = Enumerable.ToList<ApispSelectOrderItems_Result>((IEnumerable<ApispSelectOrderItems_Result>)cRMEntities.ApispSelectOrderItems(model.ApiOrderItemId, model.ApiOrderId, currLangId, result));
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
		return new ServiceResult<List<ApispSelectOrderItems_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteOrderItems(DeleteOrderItemsViewModel model)
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
			if (model.ApiOrderItemId > 0)
			{
				short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteOrderItems(model.ApiOrderItemId, value, currLangId, result));
				if (mct_Result != null)
				{
					if (mct_Result.Result > 0)
					{
						data = true;
						message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Success;
					}
					else if (mct_Result.Result == -2)
					{
						data = false;
						message = MyResource.GetResourceString("ErrorOrdIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Fail;
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
	public ServiceResult<int> UpdateOrderPayment(UpdateOrderPaymentsViewModel model)
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
			CommonClass commonClass = new CommonClass();
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (model.ApiOrderPaymentId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			string text = null;
			if (!string.IsNullOrEmpty(model.ApiOrdPayDocDate) && model.ApiOrdPayDocDate.ToLower() == "null")
			{
				text = model.ApiOrdPayDocDate;
				model.ApiOrdPayDocDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiOrdPayDocDateTime.HasValue)
					{
						text = (model.ApiOrdPayDocDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPayDocDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			string text2 = null;
			if (!string.IsNullOrEmpty(model.ApiImportDate) && model.ApiImportDate.ToLower() == "null")
			{
				text2 = model.ApiImportDate;
				model.ApiImportDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiImportDateTime.HasValue)
					{
						text2 = (model.ApiImportDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ImportDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
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
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text3 = now.ToString("yyyyMMdd", new PersianCulture());
			string text4 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text5 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string text6 = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			CRMEntities cRMEntities2 = cRMEntities;
			int? orderPaymentId = model.ApiOrderPaymentId;
			int? apiOrderId = model.ApiOrderId;
			string text7 = text2;
			DateTime? apiImportDateTime = model.ApiImportDateTime;
			int num2 = cRMEntities2.ApispUpdateOrderPayments(ordpayTypeId: model.ApiOrdPayTypeId, importDate: text7, importDateTime: apiImportDateTime, ordpayOrderId: apiOrderId, ordpayDocId: model.ApiOrdPayDocId, ordpayDocTypeId: model.ApiOrdPayDocTypeId, ordpayAmount: model.ApiOrdPayAmount, ordpayDocNumber: model.ApiOrdPayDocNumber, ordpayDocDate: text, ordpayDocDateTime: model.ApiOrdPayDocDateTime, ordpayDescription: model.ApiOrdPayDescription, ordpayDocAmount: model.ApiOrdPayDocAmount, preOrderPaymentId: model.ApiPreOrderPaymentId, ordpayBankDocNumber: model.ApiOrdpayBankDocNumber, userId: userId, orderPaymentId: orderPaymentId, month1: value2, registerDate: value, registerDatePersian: text3, appType: text6, languageID: currLangId, defaultLanguageID: result, errorMessage: objectParameter, ordpayLinkAccHeaderId: model.ApiOrdpayLinkAccHeaderId, ordpayLinkAccHeaderNumber: model.ApiOrdpayLinkAccHeaderNumber, ordpayLinkAccDetailId: model.ApiOrdpayLinkAccDetailId, ordpayLinkAccVoucherId: model.ApiOrdpayLinkAccVoucherId, ordpayLinkAccVoucherNumber: model.ApiOrdpayLinkAccVoucherNumber, ordpayLinkAccHeaderIdStr: model.ApiOrdpayLinkAccHeaderIdStr, ordpayLinkAccDetailIdStr: model.ApiOrdpayLinkAccDetailIdStr, ordpayLinkAccVoucherIdStr: model.ApiOrdpayLinkAccVoucherIdStr, ordpayLinkAccPayType: model.ApiOrdpayLinkAccPayType, ordpayLinkAccFirstTransferDate: model.ApiOrdpayLinkAccFirstTransferDate, ordpayLinkAccLastTransferDate: model.ApiOrdpayLinkAccLastTransferDate, ordpayLinkAccData: model.ApiOrdpayLinkAccData, ordpayBankingBankID: model.ApiOrdpayBankingBankID, ordpayBankingBranchID: model.ApiOrdpayBankingBranchID, ordpayBankingAccountID: model.ApiOrdpayBankingAccountID, ordpayCashId: model.ApiOrdpayCashId, ordpayGroupIdI: model.ApiOrdpayGroupIdI, ordpayGroupIdII: model.ApiOrdpayGroupIdII, ordpayChqSayadNumber: model.ApiOrdpayChqSayadNumber, ordpayChqSerialNumber: model.ApiOrdpayChqSerialNumber, tspOrdPayIinn: model.ApiTspOrdPayIinn, tspOrdPayAcn: model.ApiTspOrdPayAcn, tspOrdPayTrmn: model.ApiTspOrdPayTrmn, tspOrdPayPmt: model.ApiTspOrdPayPmt, ordpayDocDayTemp: model.ApiOrdpayDocDayTemp, ordpayBankName: model.ApiOrdpayBankName, ordpayBranchName: model.ApiOrdpayBranchName, ordpayBranchCode: model.ApiOrdpayBranchCode);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 <= 0 && objectParameter.Value == null)
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
				string text8 = "";
				string text9 = objectParameter.Value.ToString();
				if (text9.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Order", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayTypeId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdPayType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayBankingBankID|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayBankingBankID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayBankingBranchID|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayBankingBranchID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayBankingAccountID|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayBankingAccountID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayCashId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayCashId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayGroupIId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayGroupIId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("No OrdpayGroupIIId|", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrdpayGroupIIId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text9.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text8 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text9));
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text10 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text10 = text10 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text10)) ? (" (" + text10 + ")") : "");
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
	public ServiceResult<List<ApispSelectOrderPayments_Result>> SelectOrderPayments(SelectOrderPaymentsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectOrderPayments_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectOrderPayments_Result>>
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
				return new ServiceResult<List<ApispSelectOrderPayments_Result>>
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
				ServiceResult<List<ApispSelectOrderPayments_Result>> serviceResult = new ServiceResult<List<ApispSelectOrderPayments_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectOrderPayments_Result> list2 = Enumerable.ToList<ApispSelectOrderPayments_Result>((IEnumerable<ApispSelectOrderPayments_Result>)cRMEntities.ApispSelectOrderPayments(model.ApiOrderPaymentId, model.ApiOrderId, currLangId, result));
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
		return new ServiceResult<List<ApispSelectOrderPayments_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteOrderPayments(DeleteOrderPaymentsViewModel model)
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
			if (model.ApiOrderPaymentId > 0)
			{
				short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteOrderPayments(model.ApiOrderPaymentId, value, currLangId, result));
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
	public ServiceResult<string> ActiveOrder(VerifyOrderViewModel model)
	{
		CRMEntities cRMEntities = null;
		string text = "fa-IR";
		string data = "";
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		decimal num = default(decimal);
		DateTime now = DateTime.Now;
		DateTime value = now;
		string text3 = now.ToString("yyyyMMdd", new PersianCulture());
		short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = "",
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = "",
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
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num2.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = RS.Get("ErrorUsernamePasswordIncorrect", text, RS.TypeMsg) + "\r\n" + RS.Get("ErrorTryAgain", text, RS.TypeMsg),
					Data = "",
					Status = ServiceResultStatus.Error
				};
			}
			ApispSelectOrderById_Result apispSelectOrderById_Result = Enumerable.FirstOrDefault<ApispSelectOrderById_Result>((IEnumerable<ApispSelectOrderById_Result>)cRMEntities.ApispSelectOrderById(model.ApiOrderId, currLangId, result));
			ApispReturnOrderSumFooter_Result apispReturnOrderSumFooter_Result;
			decimal obj;
			if (apispSelectOrderById_Result != null)
			{
				ApispReturnRollDiscountLimitation_Result apispReturnRollDiscountLimitation_Result = Enumerable.FirstOrDefault<ApispReturnRollDiscountLimitation_Result>((IEnumerable<ApispReturnRollDiscountLimitation_Result>)Enumerable.ToList<ApispReturnRollDiscountLimitation_Result>((IEnumerable<ApispReturnRollDiscountLimitation_Result>)cRMEntities.ApispReturnRollDiscountLimitation(model.ApiRollId)));
				if (apispReturnRollDiscountLimitation_Result != null)
				{
					if (apispReturnRollDiscountLimitation_Result.LimitOrderDiscountActive.HasValue && apispReturnRollDiscountLimitation_Result.LimitOrderDiscountActive.GetValueOrDefault())
					{
						num = apispReturnRollDiscountLimitation_Result.LimitOrderDiscountPercent.GetValueOrDefault();
					}
				}
				else
				{
					text2 = RS.Get("ErrorNotFoundSetting", text, RS.TypeMsg);
				}
				if (num > 0m)
				{
					apispReturnOrderSumFooter_Result = Enumerable.FirstOrDefault<ApispReturnOrderSumFooter_Result>((IEnumerable<ApispReturnOrderSumFooter_Result>)Enumerable.ToList<ApispReturnOrderSumFooter_Result>((IEnumerable<ApispReturnOrderSumFooter_Result>)cRMEntities.ApispReturnOrderSumFooter(model.ApiOrderId)));
					if (apispReturnOrderSumFooter_Result != null)
					{
						if (apispReturnOrderSumFooter_Result.TotalPriceSumWithoutDiscount.HasValue)
						{
							decimal? totalPriceSumWithoutDiscount = apispReturnOrderSumFooter_Result.TotalPriceSumWithoutDiscount;
							if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
							{
								obj = Convert.ToDecimal(apispReturnOrderSumFooter_Result.TotalDiscountSum * (decimal?)100) / Convert.ToDecimal(apispReturnOrderSumFooter_Result.TotalPriceSumWithoutDiscount);
								goto IL_03bd;
							}
						}
						obj = 0m;
						goto IL_03bd;
					}
				}
				goto IL_059c;
			}
			text2 = RS.Get("ErrorNotFound", text, RS.TypeMsg);
			goto end_IL_0055;
			IL_059c:
			int num3 = cRMEntities.ApispOrderVerify(model.ApiOrderId, model.UserId, DateTime.Now, text);
			if (CRMIdealApi.Classes.Helper.User.IsUserAccess("frmOrder", "actAutoReferOrderToWrhsUserAfterVerify", model.UserId))
			{
				ReferOrderToWrhsUser(model.ApiOrderId, model.UserId, currLangId, model.CenterId, model.CenterCode);
			}
			string text4 = "";
			int num4 = 0;
			string text5 = "";
			if (CRMIdealApi.Classes.Helper.User.IsUserAccess("frmOrder", "actIssueDraftAuto", model.UserId) && model.ApiOrderId > 0 && VersionBuyer.WareHouse)
			{
				string refResult = "";
				ServiceResult<bool> serviceResult = IssueDraftAuto(model.ApiOrderId, model.UserId, ref refResult, currLangId, model.UserName, model.Password, model.CenterId, model.CenterCode);
				if (!string.IsNullOrWhiteSpace(refResult))
				{
					if (serviceResult.Data)
					{
						text5 = refResult;
					}
					else
					{
						text4 = refResult;
					}
				}
			}
			text2 = "1|" + model.UserId + "|" + CRMIdealApi.Classes.Helper.User.GetUserName(model.UserId, currLangId, result) + " (" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
			if (!string.IsNullOrWhiteSpace(text4))
			{
				text2 = text2 + "|doc-1^,^" + text4;
			}
			else if (!string.IsNullOrWhiteSpace(text5))
			{
				text2 = text2 + "|doc1^,^" + text5;
			}
			CRMEntities cRMEntities2 = cRMEntities;
			int? num5 = model.ApiOrderId;
			int? num6 = model.UserId;
			short? num7 = month1;
			DateTime? dateTime = value;
			string text6 = text3;
			string text7 = appType;
			int? num8 = result;
			int? num9 = currLangId;
			short? num10 = value2;
			ObjectResult<ApiScorespInsertAndCalcOrderScores_Result> objectResult = cRMEntities2.ApiScorespInsertAndCalcOrderScores(null, num5, model.ApiCompanyId, model.ApiFromDate, model.ApiToDate, model.ApiCalcAutoScoreInIssue, model.ApiCalcAutoScoreInVerify, DateTime.Now, num6, num10, num7, dateTime, text6, text7, num9, num8, updateCompanyGroups: model.ApiUpdateCompanyGroups, returnResult: false, centerId: model.CenterId, centerCode: model.CenterCode, calcAutoScoreInStatusCancelled: false);
			int apiOrderId = model.ApiOrderId;
			if (apiOrderId > 0)
			{
				string msg = "";
				AddProjectProductHistoryFromOrder(apiOrderId, addPrdValidity: false, "", ref msg, model.UserId, currLangId, result);
				if (!string.IsNullOrWhiteSpace(msg))
				{
					ErrorSignal.FromCurrentContext().Raise(new Exception(msg));
				}
			}
			goto end_IL_0055;
			IL_053a:
			decimal obj6;
			decimal num11 = (decimal)obj6;
			if (num11 > num)
			{
				return new ServiceResult<string>
				{
					Message = RS.Get("MaxDiscountPercentOrderInActiveOrder", text, RS.TypeMsg) + " " + num,
					Data = "",
					Status = ServiceResultStatus.Error
				};
			}
			goto IL_059c;
			IL_03bd:
			num11 = obj;
			if (apispReturnOrderSumFooter_Result.SumPriceAmount.HasValue)
			{
				decimal? totalPriceSumWithoutDiscount = apispReturnOrderSumFooter_Result.SumPriceAmount;
				if (!((totalPriceSumWithoutDiscount.GetValueOrDefault() == default(decimal)) & totalPriceSumWithoutDiscount.HasValue))
				{
					if (num11 > num)
					{
						return new ServiceResult<string>
						{
							Message = RS.Get("MaxDiscountPercentInActiveOrder", text, RS.TypeMsg) + " " + num,
							Data = "",
							Status = ServiceResultStatus.Error
						};
					}
					if (apispReturnOrderSumFooter_Result.SumPriceAmount.HasValue)
					{
						totalPriceSumWithoutDiscount = apispReturnOrderSumFooter_Result.SumPriceAmount;
						if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
						{
							obj6 = Convert.ToDecimal(apispSelectOrderById_Result.ordDiscount * (decimal?)100) / Convert.ToDecimal(apispReturnOrderSumFooter_Result.SumPriceAmount);
							goto IL_053a;
						}
					}
					obj6 = 0m;
					goto IL_053a;
				}
			}
			return new ServiceResult<string>
			{
				Message = RS.Get("msgErrorDivisionByZero", text, RS.TypeMsg),
				Data = "",
				Status = ServiceResultStatus.Error
			};
			end_IL_0055:;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text2 = RS.Get("frmErrorMessage", text, RS.TypeMsg);
		}
		return new ServiceResult<string>
		{
			Message = text2,
			Data = data,
			Status = (string.IsNullOrWhiteSpace(text2) ? ServiceResultStatus.Success : ServiceResultStatus.Fail)
		};
	}

	public ServiceResult<bool> IssueDraftAuto(int orderId, int userId, ref string refResult, int langId = 0, string username = "", string password = "", int? centerId = null, string centerCode = null, int linkAccSettingDBId = 0)
	{
		bool flag = false;
		string rsCollation = "fa-IR";
		CRMEntities cRMEntities = null;
		try
		{
			string text = "";
			int num = 0;
			string text2 = "";
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
			int.TryParse(langId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(password))
			{
				password = CodeDecode.DeCodding(password);
			}
			if (!string.IsNullOrEmpty(username))
			{
				username = CodeDecode.DeCodding(username);
			}
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num2.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<bool>
				{
					Message = RS.Get("ErrorUsernamePasswordIncorrect", rsCollation, RS.TypeMsg) + "\r\n" + RS.Get("ErrorTryAgain", rsCollation, RS.TypeMsg),
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			if (VersionBuyer.WareHouse && CRMIdealApi.Classes.Helper.User.IsUserAccess("frmOrder", "actIssueDraftAuto", userId))
			{
				ApispSelectOrderById_Result apispSelectOrderById_Result = Enumerable.FirstOrDefault<ApispSelectOrderById_Result>((IEnumerable<ApispSelectOrderById_Result>)cRMEntities.ApispSelectOrderById(orderId, currLangId, result));
				if (apispSelectOrderById_Result != null)
				{
					int result3 = 0;
					int.TryParse(apispSelectOrderById_Result.ordStatusId.ToString(), out result3);
					if (result3 == 4)
					{
						text = RS.Get("msgErrorIssueDraftForCanceledOrd", rsCollation, RS.TypeMsg);
						num++;
					}
					if (num == 0)
					{
						ApispReturnDraftFromOrder_Result apispReturnDraftFromOrder_Result = new ApispReturnDraftFromOrder_Result();
						string text3 = "";
						List<ApispReturnDraftFromOrder_Result> list2 = Enumerable.ToList<ApispReturnDraftFromOrder_Result>((IEnumerable<ApispReturnDraftFromOrder_Result>)cRMEntities.ApispReturnDraftFromOrder(orderId, currLangId, result));
						if (list2 != null && Enumerable.Any<ApispReturnDraftFromOrder_Result>((IEnumerable<ApispReturnDraftFromOrder_Result>)list2))
						{
							apispReturnDraftFromOrder_Result = Enumerable.LastOrDefault<ApispReturnDraftFromOrder_Result>((IEnumerable<ApispReturnDraftFromOrder_Result>)list2);
							if (list2.Count > 0)
							{
								foreach (ApispReturnDraftFromOrder_Result item2 in list2)
								{
									text3 = text3 + item2.DocNumber + ",";
								}
								if (!string.IsNullOrEmpty(text3) && text3.EndsWith(","))
								{
									text3 = text3.TrimEnd(new char[1] { ',' });
								}
								num++;
								text = RS.Get("Error", rsCollation, RS.TypeLbl) + " !!<br>" + RS.Get("msgIssueDraftFormOrderOfType", rsCollation, RS.TypeMsg) + " " + apispReturnDraftFromOrder_Result.Opr + "<br>" + RS.Get("msgIssueDraftFormOrderWithNumber", rsCollation, RS.TypeMsg) + " " + text3 + "<br>" + RS.Get("msgIssueDraftFormOrderDate", rsCollation, RS.TypeMsg) + PersianDate.GetFormatetdDate(apispReturnDraftFromOrder_Result.DocDate) + "<br>" + RS.Get("msgIssueDraftFormOrderInDate", rsCollation, RS.TypeMsg) + " " + PersianDate.GetFormatetdDate(apispReturnDraftFromOrder_Result.RegisterDatePersian) + "<br>" + RS.Get("msgIssueDraftFormOrderByUser", rsCollation, RS.TypeMsg) + " " + apispReturnDraftFromOrder_Result.UserName + "<br>" + RS.Get("msgIssueDraftFormOrderBeenIissued", rsCollation, RS.TypeMsg) + "|" + apispReturnDraftFromOrder_Result.DocID + "|" + apispReturnDraftFromOrder_Result.OprType;
							}
						}
					}
					List<ApispSelectOrderItems_Result> list3 = Enumerable.ToList<ApispSelectOrderItems_Result>((IEnumerable<ApispSelectOrderItems_Result>)cRMEntities.ApispSelectOrderItems(0, orderId, currLangId, result));
					List<DocIdKeyValueViewModel> list4 = new List<DocIdKeyValueViewModel>();
					string text4 = "";
					int result4 = 0;
					if (list3 != null && Enumerable.Any<ApispSelectOrderItems_Result>((IEnumerable<ApispSelectOrderItems_Result>)list3))
					{
						ApispSelectOrderItems_Result apispSelectOrderItems_Result = Enumerable.FirstOrDefault<ApispSelectOrderItems_Result>((IEnumerable<ApispSelectOrderItems_Result>)list3);
						if (apispSelectOrderItems_Result != null)
						{
							int.TryParse(apispSelectOrderItems_Result.ApiOrdIWHId.ToString(), out result4);
						}
						foreach (ApispSelectOrderItems_Result item3 in list3)
						{
							DocIdKeyValueViewModel item = new DocIdKeyValueViewModel
							{
								Id = item3.ApiOrderItemID.ToString(),
								Value = item3.ApiOrdIQuantity.GetValueOrDefault().ToString()
							};
							list4.Add(item);
						}
						if (Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list4))
						{
							foreach (DocIdKeyValueViewModel item4 in list4)
							{
								string id = item4.Id;
								int type = item4.Type;
								string tag = item4.Tag;
								string value = item4.Value;
								int result5 = 0;
								int.TryParse(id, out result5);
								double result6 = 0.0;
								double.TryParse(value, out result6);
								if (result6 > 0.0)
								{
									text4 = text4 + result5 + "," + result6 + "|";
								}
							}
						}
					}
					if (num == 0 && CRMIdealApi.Classes.Helper.User.IsUserAccess("frmIssueDraftFromOrder", "actCanNotIssueDraftWithNoStock", userId))
					{
						bool flag2 = false;
						int num3 = 0;
						bool flag3 = false;
						if (apispSelectCrmsysSetting_Result != null)
						{
							flag2 = ((apispSelectCrmsysSetting_Result.InvStockFromLink.HasValue && apispSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
							num3 = apispSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						if (flag2 && num3 > 0)
						{
							int num4 = 0;
							num4 = apispSelectOrderById_Result.ordCompanyId;
							if (list3 != null && Enumerable.Any<ApispSelectOrderItems_Result>((IEnumerable<ApispSelectOrderItems_Result>)list3) && list4 != null && Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list4))
							{
								foreach (DocIdKeyValueViewModel item5 in list4)
								{
									string id2 = item5.Id;
									int type2 = item5.Type;
									string tag2 = item5.Tag;
									string value2 = item5.Value;
									int objId = 0;
									int.TryParse(id2, out objId);
									double result7 = 0.0;
									double.TryParse(value2, out result7);
									ApispSelectOrderItems_Result apispSelectOrderItems_Result2 = Enumerable.FirstOrDefault<ApispSelectOrderItems_Result>((IEnumerable<ApispSelectOrderItems_Result>)list3, (Func<ApispSelectOrderItems_Result, bool>)((ApispSelectOrderItems_Result m) => m.ApiOrderItemID == objId));
									if (apispSelectOrderItems_Result2 == null || num != 0)
									{
										continue;
									}
									string text5 = OtherSystems.GetPrdQuantity(userId, apispSelectOrderItems_Result2.ApiOrdIPrdId, apispSelectOrderItems_Result2.ApiOrdIWHId.GetValueOrDefault(), apispSelectOrderItems_Result2.ApiOrdILinkAccWHIdStr ?? "", apispSelectOrderItems_Result2.ApiOrdITracing ?? "", num4, currLangId, result, "", linkAccSettingDBId);
									double result8 = 0.0;
									if (string.IsNullOrEmpty(text5))
									{
										continue;
									}
									if (text5 == RS.Get("frmError", rsCollation, RS.TypeLbl))
									{
										text5 = "0";
									}
									if (text5 != RS.Get("frmError", rsCollation, RS.TypeLbl))
									{
										double.TryParse(text5, out result8);
										if (result8 < result7)
										{
											flag3 = true;
											text = RS.Get("msgIssueDraftFormOrderImpossibilityIissued", rsCollation, RS.TypeMsg) + "\r\n" + RS.Get("msgIssueDraftFormOrderLackInventory", rsCollation, RS.TypeMsg) + "\r\n" + apispSelectOrderItems_Result2.ApiOrdIPrd;
											num++;
										}
										flag3 = true;
									}
								}
							}
						}
						if (!flag3)
						{
							ApispControlOrderItemsStock_Result apispControlOrderItemsStock_Result = Enumerable.FirstOrDefault<ApispControlOrderItemsStock_Result>((IEnumerable<ApispControlOrderItemsStock_Result>)cRMEntities.ApispControlOrderItemsStock(orderId, currLangId, result, text4, centerId, centerCode));
							if (apispControlOrderItemsStock_Result != null)
							{
								text = RS.Get("msgIssueDraftFormOrderImpossibilityIissued", rsCollation, RS.TypeMsg) + "\r\n" + RS.Get("msgIssueDraftFormOrderLackInventory", rsCollation, RS.TypeMsg) + "\r\n" + apispControlOrderItemsStock_Result.PrdName;
								num++;
							}
						}
					}
					if (num == 0)
					{
						DateTime now = DateTime.Now;
						string draftDate = now.ToString("yyyyMMdd", new PersianCulture());
						ObjectParameter objectParameter = new ObjectParameter("insertedDraftID", 0);
						ObjectParameter objectParameter2 = new ObjectParameter("insertedDraftNumber", 0);
						int num5 = cRMEntities.ApispIssueDraftFromOrder(orderId, draftDate, userId, short.Parse(now.ToString("MM", new PersianCulture())), result4, now.ToString("yyyyMMdd", new PersianCulture()), CRMIdealApi.Classes.Configuration.AppType, objectParameter, objectParameter2, result, text4, centerId, centerCode);
						int num6 = (int)objectParameter.Value;
						int num7 = (int)objectParameter2.Value;
						ApispReturnDraftFromOrder_Result apispReturnDraftFromOrder_Result2 = new ApispReturnDraftFromOrder_Result();
						List<ApispReturnDraftFromOrder_Result> list5 = Enumerable.ToList<ApispReturnDraftFromOrder_Result>((IEnumerable<ApispReturnDraftFromOrder_Result>)cRMEntities.ApispReturnDraftFromOrder(orderId, currLangId, result));
						string text6 = "";
						string text7 = "";
						if (list5 != null && Enumerable.Any<ApispReturnDraftFromOrder_Result>((IEnumerable<ApispReturnDraftFromOrder_Result>)list5))
						{
							apispReturnDraftFromOrder_Result2 = Enumerable.LastOrDefault<ApispReturnDraftFromOrder_Result>((IEnumerable<ApispReturnDraftFromOrder_Result>)list5);
							if (list5.Count > 1)
							{
								foreach (ApispReturnDraftFromOrder_Result item6 in list5)
								{
									text6 = text6 + item6.DocNumber + ",";
									text7 = text7 + item6.DocID + ",";
								}
								if (!string.IsNullOrEmpty(text6) && text6.EndsWith(","))
								{
									text6 = text6.TrimEnd(new char[1] { ',' });
								}
								if (!string.IsNullOrEmpty(text7) && text7.EndsWith(","))
								{
									text7 = text7.TrimEnd(new char[1] { ',' });
								}
							}
						}
						else
						{
							apispReturnDraftFromOrder_Result2 = null;
						}
						if (apispReturnDraftFromOrder_Result2 != null)
						{
							if (string.IsNullOrEmpty(text6))
							{
								text6 = apispReturnDraftFromOrder_Result2.DocNumber.ToString();
							}
							text2 = num6 + "," + text6 + "," + apispReturnDraftFromOrder_Result2.OprType;
							if (CRMIdealApi.Classes.Helper.User.IsUserAccess("frmIssueDraftFromOrder", "actAutoReferDocToOrdReferUserAfterIssue", userId))
							{
								ApiVerificationRequestController apiVerificationRequestController = new ApiVerificationRequestController();
								apiVerificationRequestController.ReferDocToOrdReferUser(text7, userId, langId, userId);
							}
						}
						else
						{
							text2 = num6 + "," + num7 + ",1";
						}
					}
				}
				else
				{
					text = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg);
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				flag = false;
				refResult = text;
			}
			else if (!string.IsNullOrWhiteSpace(text2))
			{
				flag = true;
				refResult = text2;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<bool>
		{
			Message = "",
			Data = flag,
			Status = (flag ? ServiceResultStatus.Success : ServiceResultStatus.Fail)
		};
	}

	public void AddProjectProductHistoryFromOrder(int orderId, bool addPrdValidity, string addPrdValidityPrjTitle, ref string msg, int userId, int currLangId, int defLangId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string rsCollation = "fa-IR";
		try
		{
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			if (orderId != 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispAddProjectProductHistoryFromOrder(orderId, addPrdValidity, addPrdValidityPrjTitle, userId, month1, registerDate, registerDatePersian, appType, currLangId, defLangId));
				int result = 0;
				if (mct_Result != null)
				{
					int.TryParse(mct_Result.Result.ToString(), out result);
				}
				switch (result)
				{
				case -100:
				case 0:
					msg = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg);
					break;
				case -1:
					msg = RS.Get("msgErrorNoSavePrjPrdHisByOrdNotVerified", rsCollation, RS.TypeMsg);
					break;
				case -2:
					msg = RS.Get("msgErrorNoSavePrjPrdHisNoSelectedPrj", rsCollation, RS.TypeMsg);
					break;
				case -3:
					msg = RS.Get("msgErrorNoSavePrjPrdHisNoDefaultPrjTitles", rsCollation, RS.TypeMsg);
					break;
				case -4:
					msg = RS.Get("msgErrorNoSavePrjPrdHisNoPrj", rsCollation, RS.TypeMsg);
					break;
				case 1:
					msg = "";
					break;
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
		finally
		{
			cRMEntities.Dispose();
		}
	}

	public ServiceResult<bool> ReferOrderToWrhsUser(int orderId, int userId, int langId, int? centerId = 0, string centerCode = "")
	{
		bool flag = false;
		CRMEntities cRMEntities = new CRMEntities();
		string rsCollation = "fa-IR";
		try
		{
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
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var defLangId);
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			int.TryParse(langId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = defLangId;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (orderId != 0)
			{
				List<InternalMessage_LangViewModel> list2 = new List<InternalMessage_LangViewModel>();
				foreach (ApispSelectLanguages_Result item in list)
				{
					InternalMessage_LangViewModel internalMessage_LangViewModel = new InternalMessage_LangViewModel();
					internalMessage_LangViewModel.LanguageID = item.LanguageID;
					internalMessage_LangViewModel.msgSubject = RS.Get("ordVerifiedRequestSubject", rsCollation, RS.TypeLbl);
					internalMessage_LangViewModel.msgBody = RS.Get("ordVerifiedRequest", rsCollation, RS.TypeLbl) + "-" + RS.Get("ordVerifiedRequestOrdAtach", rsCollation, RS.TypeLbl) + "\n" + RS.Get("ordVerifiedRequestOrdNumber", rsCollation, RS.TypeLbl) + ": [#ordNumber#]\n" + RS.Get("ordVerifiedRequestOrdDate", rsCollation, RS.TypeLbl) + ": [#ordDate#]\n" + RS.Get("ordVerifiedRequestCompanayName", rsCollation, RS.TypeLbl) + ": [#CmpName#]\n" + RS.Get("ordVerifiedRequestReferUserName", rsCollation, RS.TypeLbl) + ": [#ReferUser#]\n" + RS.Get("ordVerifiedRequestFirstRegisterUserName", rsCollation, RS.TypeLbl) + ": [#FirstRegisterUser#]\n" + RS.Get("ordVerifiedRequestOrdVerified", rsCollation, RS.TypeLbl) + ": [#Verifier#]\n" + RS.Get("ordVerifiedRequestDbClickOnOtherInfo", rsCollation, RS.TypeLbl) + "\n";
					list2.Add(internalMessage_LangViewModel);
				}
				string intMsgBody = "";
				string intMsgSubject = "";
				string intMsgLang = "";
				if (list2 != null && Enumerable.Any<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2))
				{
					intMsgSubject = (Enumerable.Any<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2, (Func<InternalMessage_LangViewModel, bool>)((InternalMessage_LangViewModel c) => c.LanguageID == defLangId)) ? Enumerable.FirstOrDefault<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2, (Func<InternalMessage_LangViewModel, bool>)((InternalMessage_LangViewModel c) => c.LanguageID == defLangId)).msgSubject : "");
					intMsgBody = (Enumerable.Any<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2, (Func<InternalMessage_LangViewModel, bool>)((InternalMessage_LangViewModel c) => c.LanguageID == defLangId)) ? Enumerable.FirstOrDefault<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2, (Func<InternalMessage_LangViewModel, bool>)((InternalMessage_LangViewModel c) => c.LanguageID == defLangId)).msgBody : "");
					intMsgLang = JsonConvert.SerializeObject(Enumerable.ToList<InternalMessage_LangViewModel>(Enumerable.Where<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2, (Func<InternalMessage_LangViewModel, bool>)((InternalMessage_LangViewModel c) => c.LanguageID != defLangId))));
				}
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispReferOrderToWrhsUser(orderId, intMsgBody, intMsgSubject, intMsgLang, userId, month1, registerDate, registerDatePersian, appType, defLangId, centerId, centerCode));
				int result = 0;
				if (mct_Result != null)
				{
					int.TryParse(mct_Result.Result.ToString(), out result);
				}
				flag = result == 1;
				PushNotif.NewIntMsgNotify(currLangId, defLangId);
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
		return new ServiceResult<bool>
		{
			Message = "",
			Data = flag,
			Status = (flag ? ServiceResultStatus.Success : ServiceResultStatus.Fail)
		};
	}

	[HttpPost]
	public ServiceResult<string> DeactiveOrder(ExitVerifyOrderViewModel model)
	{
		string text = "";
		string rsCollation = "fa-IR";
		int userId = model.UserId;
		if (!VersionBuyer.CRMApi)
		{
			return new ServiceResult<string>
			{
				Message = Messages.ErrorAccessAPILimited,
				Data = "",
				Status = ServiceResultStatus.Error
			};
		}
		CRMEntities cRMEntities = new CRMEntities();
		CommonClass commonClass = new CommonClass();
		ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
		if (apispSelectCrmsysSetting_Result == null)
		{
			return new ServiceResult<string>
			{
				Message = Messages.ErrorInReadingSysSetting,
				Data = "",
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
		ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
		if (apispSelectLanguages_Result != null)
		{
			rsCollation = apispSelectLanguages_Result.LanguageCollation;
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
			return new ServiceResult<string>
			{
				Message = RS.Get("ErrorUsernamePasswordIncorrect", rsCollation, RS.TypeMsg) + "\r\n" + RS.Get("ErrorTryAgain", rsCollation, RS.TypeMsg),
				Data = "",
				Status = ServiceResultStatus.Error
			};
		}
		if (!CRMIdealApi.Classes.Helper.User.IsUserAccess("frmOrder", "actExitFromIsFix", userId))
		{
			text = RS.Get("DoNotHaveAccess", rsCollation, RS.TypeMsg);
		}
		else
		{
			try
			{
				cRMEntities.ApispOrderVerifyExit(model.ApiOrderId);
				short value = short.Parse(DateTime.Now.ToString("yyyy", new PersianCulture()));
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApiScorespDeleteOrderScores(model.ApiOrderId, model.UserId, value, month1, registerDate, registerDatePersian, appType, result));
				if (mct_Result != null && mct_Result.Result == 0)
				{
					text = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg);
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = RS.Get("frmErrorMessage", rsCollation, RS.TypeMsg);
			}
		}
		return new ServiceResult<string>
		{
			Message = text,
			Data = "",
			Status = (string.IsNullOrWhiteSpace(text) ? ServiceResultStatus.Success : ServiceResultStatus.Fail)
		};
	}

	public ServiceResult<string> SendVerifyRequest(VerificationRequestVerifyViewModel model)
	{
		ApiVerificationRequestController apiVerificationRequestController = new ApiVerificationRequestController();
		return apiVerificationRequestController.VerificationRequestVerify(model, "ORD", 20);
	}

	[HttpPost]
	public ServiceResult<int> InsertOrderCommission(InsertOrderCommissionViewModel model)
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
			CommonClass commonClass = new CommonClass();
			if (model.ApiOrderId <= 0)
			{
				model.ApiOrderId = null;
			}
			if (model.ApiCommUserId == 0)
			{
				model.ApiCommUserId = null;
			}
			if (model.ApiCommPayTypeId == 0)
			{
				model.ApiCommPayTypeId = null;
			}
			if (model.ApiCommStatusId == 0)
			{
				model.ApiCommStatusId = null;
			}
			if (model.ApiCommVerifierUserId == 0)
			{
				model.ApiCommVerifierUserId = null;
			}
			if (model.ApiCommIsPaidUserId == 0)
			{
				model.ApiCommIsPaidUserId = null;
			}
			if (model.ApiCommIsPaidPayRollUserCycleId <= 0)
			{
				model.ApiCommIsPaidPayRollUserCycleId = null;
			}
			if (model.ApiCommIsPaidPayRollUserCycleItemValueId <= 0)
			{
				model.ApiCommIsPaidPayRollUserCycleItemValueId = null;
			}
			if (model.ApiCommAmountCurrUnId == 0)
			{
				model.ApiCommAmountCurrUnId = null;
			}
			if (model.ApiCommTypeCmpId == 0)
			{
				model.ApiCommTypeCmpId = null;
			}
			if (model.ApiCommTypePrsId == 0)
			{
				model.ApiCommTypePrsId = null;
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
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!VersionBuyer.Commissions)
			{
				return new ServiceResult<int>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("lblCommission", new CultureInfo(currLangId))),
					Data = 0,
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
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string text = "";
			string commDatePersian = "";
			string commEffectiveDatePersian = "";
			string commVerifiedDatePersian = "";
			string commIsPaidDatePersian = "";
			if (!model.ApiCommDate.HasValue)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					text += ", ";
				}
				text += string.Format(MyResource.GetResourceString("ErrorIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
			}
			else
			{
				try
				{
					if (model.ApiCommDate.HasValue)
					{
						commDatePersian = (model.ApiCommDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += ", ";
					}
					text += string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
			}
			try
			{
				if (model.ApiCommEffectiveDate.HasValue)
				{
					commEffectiveDatePersian = (model.ApiCommEffectiveDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				if (!string.IsNullOrWhiteSpace(text))
				{
					text += ", ";
				}
				text += string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommEffectiveDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
			}
			try
			{
				if (model.ApiCommVerifiedDate.HasValue)
				{
					commVerifiedDatePersian = (model.ApiCommVerifiedDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				if (!string.IsNullOrWhiteSpace(text))
				{
					text += ", ";
				}
				text += string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommVerifiedDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
			}
			try
			{
				if (model.ApiCommIsPaidDate.HasValue)
				{
					commIsPaidDatePersian = (model.ApiCommIsPaidDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				if (!string.IsNullOrWhiteSpace(text))
				{
					text += ", ";
				}
				text += string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommIsPaidDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new ServiceResult<int>
				{
					Message = text,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			string text3 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text4 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string text5 = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedOrderCommissionId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			int num2 = cRMEntities.ApispInsertOrderCommissions(model.ApiOrderId, model.ApiOrdNumber, model.ApiCommDate, commDatePersian, model.ApiCommUserId, model.ApiCommBaseAmountDec, model.ApiCommBaseAmountDecDesc, model.ApiCommBaseAmount, model.ApiCommRate, model.ApiCommRateDesc, model.ApiCommAmount, model.ApiCommEffectiveDate, commEffectiveDatePersian, model.ApiCommPayTypeId, model.ApiCommStatusId, model.ApiCommDesc, model.ApiCommIsVerified, model.ApiCommVerifierUserId, model.ApiCommVerifiedDate, commVerifiedDatePersian, model.ApiCommIsPaid, model.ApiCommIsPaidUserId, model.ApiCommIsPaidDate, commIsPaidDatePersian, model.ApiCommIsPaidPayRollUserCycleId, model.ApiCommIsPaidPayRollUserCycleItemValueId, model.ApiCommAmountCurrUnId, model.ApiCommAmountCurrencyRate, model.ApiCommBaseAmountDecPercent, model.ApiCommTypeId, model.ApiCommKindId, model.ApiCommTypeCmpId, model.ApiCommTypeCmpNumber, model.ApiCommTypeCmpCode, model.ApiCommTypePrsId, userId, value2, value, text2, text5, result, objectParameter, objectParameter2);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<int>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
			{
				string text6 = "";
				string text7 = objectParameter2.Value.ToString();
				if (text7.IndexOf("No OrdId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text6 += "\r\n";
					}
					text6 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Order", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text7.IndexOf("No CommTypeId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text6 += "\r\n";
					}
					text6 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text7.IndexOf("No CommKindId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text6 += "\r\n";
					}
					text6 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommKind", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text7.IndexOf("No CommUserId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text6 += "\r\n";
					}
					text6 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text7.IndexOf("No VerifierId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text6 += "\r\n";
					}
					text6 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommVerifierUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text7.IndexOf("No CommPayTypeId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text6 += "\r\n";
					}
					text6 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommPayType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text7.IndexOf("No PaidUserId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text6 += "\r\n";
					}
					text6 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommIsPaidUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text7.IndexOf("No CurrUnId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text6 += "\r\n";
					}
					text6 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommAmountCurrUn", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text7.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text6 += "\r\n";
					}
					text6 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommTypeCmp", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text7.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text6 += "\r\n";
					}
					text6 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommTypePrs", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text7.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text6 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text7));
				}
				if (!string.IsNullOrWhiteSpace(text6))
				{
					if (text6.IndexOf(resourceString2, StringComparison.Ordinal) < 0)
					{
						text6 = text6 + "\r\n" + resourceString2;
					}
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
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
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Fail
					};
				}
				data = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text8 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text8 = text8 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text8)) ? (" (" + text8 + ")") : "");
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
	public ServiceResult<int> UpdateOrderCommission(UpdateOrderCommissionViewModel model)
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
			CommonClass commonClass = new CommonClass();
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
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiOrderCommissionId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			string commDatePersian = null;
			if (!string.IsNullOrWhiteSpace(model.ApiCommDatePersian) && model.ApiCommDatePersian.ToLower() == "null")
			{
				commDatePersian = model.ApiCommDatePersian;
				model.ApiCommDate = null;
			}
			else
			{
				try
				{
					if (model.ApiCommDate.HasValue)
					{
						commDatePersian = (model.ApiCommDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			string commEffectiveDatePersian = null;
			if (!string.IsNullOrWhiteSpace(model.ApiCommEffectiveDatePersian) && model.ApiCommEffectiveDatePersian.ToLower() == "null")
			{
				commEffectiveDatePersian = model.ApiCommEffectiveDatePersian;
				model.ApiCommEffectiveDate = null;
			}
			else
			{
				try
				{
					if (model.ApiCommEffectiveDate.HasValue)
					{
						commEffectiveDatePersian = (model.ApiCommEffectiveDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommEffectiveDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			string commVerifiedDatePersian = null;
			if (!string.IsNullOrWhiteSpace(model.ApiCommVerifiedDatePersian) && model.ApiCommVerifiedDatePersian.ToLower() == "null")
			{
				commVerifiedDatePersian = model.ApiCommVerifiedDatePersian;
				model.ApiCommVerifiedDate = null;
			}
			else
			{
				try
				{
					if (model.ApiCommVerifiedDate.HasValue)
					{
						commVerifiedDatePersian = (model.ApiCommVerifiedDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommVerifiedDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			string commIsPaidDatePersian = null;
			if (!string.IsNullOrWhiteSpace(model.ApiCommIsPaidDatePersian) && model.ApiCommIsPaidDatePersian.ToLower() == "null")
			{
				commIsPaidDatePersian = model.ApiCommIsPaidDatePersian;
				model.ApiCommIsPaidDate = null;
			}
			else
			{
				try
				{
					if (model.ApiCommIsPaidDate.HasValue)
					{
						commIsPaidDatePersian = (model.ApiCommIsPaidDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e4)
				{
					ErrorSignal.FromCurrentContext().Raise(e4);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommIsPaidDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text3 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string text4 = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num2 = cRMEntities.ApispUpdateOrderCommissions(model.ApiOrderCommissionId, model.ApiOrderId, model.ApiCommDate, commDatePersian, model.ApiCommUserId, model.ApiCommBaseAmountDec, model.ApiCommBaseAmountDecDesc, model.ApiCommBaseAmount, model.ApiCommRate, model.ApiCommRateDesc, model.ApiCommAmount, model.ApiCommEffectiveDate, commEffectiveDatePersian, model.ApiCommPayTypeId, model.ApiCommStatusId, model.ApiCommDesc, model.ApiCommIsVerified, model.ApiCommVerifierUserId, model.ApiCommVerifiedDate, commVerifiedDatePersian, model.ApiCommIsPaid, model.ApiCommIsPaidUserId, model.ApiCommIsPaidDate, commIsPaidDatePersian, model.ApiCommIsPaidPayRollUserCycleId, model.ApiCommIsPaidPayRollUserCycleItemValueId, model.ApiCommAmountCurrUnId, model.ApiCommAmountCurrencyRate, model.ApiCommBaseAmountDecPercent, model.ApiCommTypeId, model.ApiCommKindId, model.ApiCommTypeCmpId, model.ApiCommTypePrsId, userId, value2, value, text, text4, currLangId, result, objectParameter);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
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
				string text5 = "";
				string text6 = objectParameter.Value.ToString();
				if (text6.IndexOf("No OrdId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 += "\r\n";
					}
					text5 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Order", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text6.IndexOf("No CommTypeId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 += "\r\n";
					}
					text5 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text6.IndexOf("No CommKindId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 += "\r\n";
					}
					text5 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommKind", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text6.IndexOf("No CommUserId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 += "\r\n";
					}
					text5 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text6.IndexOf("No VerifierId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 += "\r\n";
					}
					text5 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommVerifierUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text6.IndexOf("No CommPayTypeId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 += "\r\n";
					}
					text5 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommPayType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text6.IndexOf("No PaidUserId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 += "\r\n";
					}
					text5 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommIsPaidUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text6.IndexOf("No CurrUnId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 += "\r\n";
					}
					text5 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommAmountCurrUn", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text6.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 += "\r\n";
					}
					text5 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommTypeCmp", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text6.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 += "\r\n";
					}
					text5 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommTypePrs", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text6.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text5 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text6));
				}
				if (!string.IsNullOrWhiteSpace(text5))
				{
					if (text5.IndexOf(resourceString2, StringComparison.Ordinal) < 0)
					{
						text5 = text5 + "\r\n" + resourceString2;
					}
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text7 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text7 = text7 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text7)) ? (" (" + text7 + ")") : "");
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
	public ServiceResult<bool> DeleteOrderCommission(DeleteOrderCommissionViewModel model)
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
			if (model.ApiOrderCommissionId > 0)
			{
				short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteOrderCommission(model.ApiOrderCommissionId, value, currLangId, result));
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
	public ServiceResult<List<ApispSelectOrderCommissions_Result>> SelectOrderCommission(SelectOrderCommissionViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectOrderCommissions_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectOrderCommissions_Result>>
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
				return new ServiceResult<List<ApispSelectOrderCommissions_Result>>
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
				ServiceResult<List<ApispSelectOrderCommissions_Result>> serviceResult = new ServiceResult<List<ApispSelectOrderCommissions_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectOrderCommissions_Result> list2 = Enumerable.ToList<ApispSelectOrderCommissions_Result>((IEnumerable<ApispSelectOrderCommissions_Result>)cRMEntities.ApispSelectOrderCommissions(model.ApiOrderCommissionId, model.ApiOrderId, currLangId, result));
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
		return new ServiceResult<List<ApispSelectOrderCommissions_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<SelectOrderWithPrdTracingResultViewModel> SelectOrderWithPrdTracing(SelectOrderWithPrdTracingViewModel model)
	{
		CRMEntities cRMEntities = null;
		SelectOrderWithPrdTracingResultViewModel selectOrderWithPrdTracingResultViewModel = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<SelectOrderWithPrdTracingResultViewModel>
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
				return new ServiceResult<SelectOrderWithPrdTracingResultViewModel>
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
				ServiceResult<SelectOrderWithPrdTracingResultViewModel> serviceResult = new ServiceResult<SelectOrderWithPrdTracingResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrWhiteSpace(model.ApiTracing))
			{
				return new ServiceResult<SelectOrderWithPrdTracingResultViewModel>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorEmpty", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("prdTracing", new CultureInfo(currLangId))),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			DateTime? fromDate = null;
			if (!string.IsNullOrWhiteSpace(model.ApiFromDate))
			{
				if (!new RegularExpression(model.ApiFromDate).Validate_yyyy_MM_dd_WithSlash())
				{
					return new ServiceResult<SelectOrderWithPrdTracingResultViewModel>
					{
						Message = string.Format(Messages.ResourceManager.GetString("ErrorFormat", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("FromDate", new CultureInfo(currLangId))),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				fromDate = DateTimeClass.ParseGregorianDate(model.ApiFromDate);
			}
			DateTime? toDate = null;
			if (!string.IsNullOrWhiteSpace(model.ApiToDate))
			{
				if (!new RegularExpression(model.ApiToDate).Validate_yyyy_MM_dd_WithSlash())
				{
					return new ServiceResult<SelectOrderWithPrdTracingResultViewModel>
					{
						Message = string.Format(Messages.ResourceManager.GetString("ErrorFormat", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("ToDate", new CultureInfo(currLangId))),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				toDate = DateTimeClass.ParseGregorianDate(model.ApiToDate);
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text3 = now.ToString("HH:mm:ss");
			short num2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string text4 = CRMIdealApi.Classes.Configuration.AppType;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("TotalPages", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("TotalRows", 0);
			ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
			List<ApispSelectOrderWithPrdTracing_Result> apiOrdersList = Enumerable.ToList<ApispSelectOrderWithPrdTracing_Result>((IEnumerable<ApispSelectOrderWithPrdTracing_Result>)cRMEntities.ApispSelectOrderWithPrdTracing(model.ApiTracing, fromDate, toDate, model.CenterId, model.CenterCode, model.ApiPageSize, model.ApiPageNumber, objectParameter, objectParameter2, currLangId, result, objectParameter3));
			string @string = Messages.ResourceManager.GetString("ErrorDoneOperationTryAgain", new CultureInfo(currLangId));
			string string2 = Messages.ResourceManager.GetString("ErrorTryAgain", new CultureInfo(currLangId));
			if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
			{
				string text5 = "";
				string text6 = objectParameter3.Value.ToString();
				if (text6.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + string2;
					return new ServiceResult<SelectOrderWithPrdTracingResultViewModel>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				status = ServiceResultStatus.Success;
				selectOrderWithPrdTracingResultViewModel = new SelectOrderWithPrdTracingResultViewModel();
				selectOrderWithPrdTracingResultViewModel.ApiTotalPages = int.Parse(objectParameter.Value.ToString());
				selectOrderWithPrdTracingResultViewModel.ApiTotalRows = int.Parse(objectParameter2.Value.ToString());
				selectOrderWithPrdTracingResultViewModel.ApiPageNumber = model.ApiPageNumber;
				selectOrderWithPrdTracingResultViewModel.ApiPageSize = model.ApiPageSize;
				selectOrderWithPrdTracingResultViewModel.ApiOrdersList = apiOrdersList;
			}
		}
		catch (Exception ex)
		{
			string text7 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text7 = text7 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text7)) ? (" (" + text7 + ")") : "");
			selectOrderWithPrdTracingResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<SelectOrderWithPrdTracingResultViewModel>
		{
			Message = message,
			Data = selectOrderWithPrdTracingResultViewModel,
			Status = status
		};
	}

	public ServiceResult<int> DistributeDiscountToOrder(DistributeDiscountToOrderViewModel model)
	{
		CRMEntities cRMEntities = null;
		int num = 0;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
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
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num2.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiOrderId > 0 && !string.IsNullOrEmpty(model.ApiOrderItemIds) && model.ApiOrderItemIds != ",")
			{
				ApispSelectOrderById_Result apispSelectOrderById_Result = Enumerable.FirstOrDefault<ApispSelectOrderById_Result>((IEnumerable<ApispSelectOrderById_Result>)cRMEntities.ApispSelectOrderById(model.ApiOrderId, currLangId, result));
				if (apispSelectOrderById_Result.ordIsFixed.GetValueOrDefault())
				{
					return new ServiceResult<int>
					{
						Message = Messages.msgErrorNotActivePreOrder,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				WSspSelectDiscountCodeByDisCode_Result wSspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<WSspSelectDiscountCodeByDisCode_Result>((IEnumerable<WSspSelectDiscountCodeByDisCode_Result>)cRMEntities.WSspSelectDiscountCodeByDisCode(model.ApiDisCode, currLangId, result));
				ApispCheckDiscountCodeToUse_Result apispCheckDiscountCodeToUse_Result = Enumerable.FirstOrDefault<ApispCheckDiscountCodeToUse_Result>((IEnumerable<ApispCheckDiscountCodeToUse_Result>)cRMEntities.ApispCheckDiscountCodeToUse(model.ApiDisCode, apispSelectOrderById_Result.ordCompanyId, apispSelectOrderById_Result.OrderID, null, model.CenterId, model.CenterCode, DateTime.Now));
				string errorMessage = apispCheckDiscountCodeToUse_Result.ErrorMessage;
				if (!string.IsNullOrWhiteSpace(errorMessage))
				{
					string[] array = errorMessage.Trim(new char[1] { '|' }).Split(new char[1] { '|' });
					string[] array2 = array;
					int num3 = 0;
					if (num3 < array2.Length)
					{
						switch (array2[num3])
						{
						default:
						{
							ServiceResult<int> serviceResult = new ServiceResult<int>();
							serviceResult.Message = MyResource.GetResourceString("DiscountNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult.Data = 0;
							serviceResult.Status = ServiceResultStatus.Error;
							return serviceResult;
						}
						case "DiscountExpired":
						{
							ServiceResult<int> serviceResult = new ServiceResult<int>();
							serviceResult.Message = MyResource.GetResourceString("DiscountExpired", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult.Data = 0;
							serviceResult.Status = ServiceResultStatus.Error;
							return serviceResult;
						}
						case "DiscountUsageLimit":
						{
							ServiceResult<int> serviceResult = new ServiceResult<int>();
							serviceResult.Message = MyResource.GetResourceString("DiscountUsageLimit", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult.Data = 0;
							serviceResult.Status = ServiceResultStatus.Error;
							return serviceResult;
						}
						case "DiscountUsageLimitUser":
						{
							ServiceResult<int> serviceResult = new ServiceResult<int>();
							serviceResult.Message = MyResource.GetResourceString("DiscountUsageLimitUser", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult.Data = 0;
							serviceResult.Status = ServiceResultStatus.Error;
							return serviceResult;
						}
						case "DiscountNoScoreMin":
						{
							ServiceResult<int> serviceResult = new ServiceResult<int>();
							serviceResult.Message = MyResource.GetResourceString("DiscountNoScoreMin", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult.Data = 0;
							serviceResult.Status = ServiceResultStatus.Error;
							return serviceResult;
						}
						case "DiscountNotApplicable":
						{
							ServiceResult<int> serviceResult = new ServiceResult<int>();
							serviceResult.Message = MyResource.GetResourceString("DiscountNotApplicable", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult.Data = 0;
							serviceResult.Status = ServiceResultStatus.Error;
							return serviceResult;
						}
						}
					}
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				int userId = model.UserId;
				string text3 = CRMIdealApi.Classes.Configuration.AppType;
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				int num4 = cRMEntities.ApispDistributeDiscountToOrderItems(model.ApiOrderId, model.ApiOrderItemIds, wSspSelectDiscountCodeByDisCode_Result.DisAmount, wSspSelectDiscountCodeByDisCode_Result.DisAmountPercent, userId, null, value2, value, text2, text3, objectParameter, model.ApiAddToDiscount, wSspSelectDiscountCodeByDisCode_Result.DiscountCodeId, model.CenterId);
				int num5 = int.Parse(objectParameter.Value.ToString());
				if (num5 > 0)
				{
					cRMEntities.ApispCalcAndUpdateOrderAmounts(model.ApiOrderId, value2, currLangId, result);
					return new ServiceResult<int>
					{
						Message = Messages.SuccessDoneRegister,
						Data = 1,
						Status = ServiceResultStatus.Success
					};
				}
				return new ServiceResult<int>
				{
					Message = Messages.msgErrorRunFunction,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			return new ServiceResult<int>
			{
				Message = Messages.ErrorNotFound,
				Data = 0,
				Status = ServiceResultStatus.Error
			};
		}
		catch (Exception ex)
		{
			string text4 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text4 = text4 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text4)) ? (" (" + text4 + ")") : "");
			num = 0;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
			return new ServiceResult<int>
			{
				Message = text,
				Data = num,
				Status = serviceResultStatus
			};
		}
	}
}
