using System;
using System.Collections.Generic;
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

public class ApiPreOrdersController : ApiController
{
	private ResourceManager RS = new ResourceManager();

	[HttpPost]
	public ServiceResult<IssuePreOrderResultViewModel> Issue(IssuePreOrderViewModel model)
	{
		//IL_0684: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f91: Unknown result type (might be due to invalid IL or missing references)
		//IL_11bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1287: Unknown result type (might be due to invalid IL or missing references)
		//IL_1568: Unknown result type (might be due to invalid IL or missing references)
		CRMEntities cRMEntities = null;
		IssuePreOrderResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<IssuePreOrderResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			if (model.ApiPordNumber <= 0)
			{
				model.ApiPordNumber = null;
			}
			if (model.ApiPordVerifierId <= 0)
			{
				model.ApiPordVerifierId = null;
			}
			if (model.ApiPordVerifierRequestId <= 0)
			{
				model.ApiPordVerifierRequestId = null;
			}
			if (model.ApiPordStatusId <= 0)
			{
				model.ApiPordStatusId = null;
			}
			if (model.ApiPordGuarantyId <= 0)
			{
				model.ApiPordGuarantyId = null;
			}
			if (model.ApiPordPayConditionId <= 0)
			{
				model.ApiPordPayConditionId = null;
			}
			if (model.ApiPordDeliveryTimeId <= 0)
			{
				model.ApiPordDeliveryTimeId = null;
			}
			if (model.ApiPordCreditDurationId <= 0)
			{
				model.ApiPordCreditDurationId = null;
			}
			if (model.ApiPordDescriptionId <= 0)
			{
				model.ApiPordDescriptionId = null;
			}
			if (model.ApiPordPrintFormatId <= 0)
			{
				model.ApiPordPrintFormatId = null;
			}
			if (model.ApiPordRLogoId <= 0)
			{
				model.ApiPordRLogoId = null;
			}
			if (model.ApiPordLLogoId <= 0)
			{
				model.ApiPordLLogoId = null;
			}
			if (model.ApiPordSignatureId <= 0)
			{
				model.ApiPordSignatureId = null;
			}
			if (model.ApiPordReferUserId <= 0)
			{
				model.ApiPordReferUserId = null;
			}
			if (model.ApiPordOprId <= 0)
			{
				model.ApiPordOprId = null;
			}
			if (model.ApiPordVerificationWorkFlowId <= 0)
			{
				model.ApiPordVerificationWorkFlowId = null;
			}
			if (model.ApiCompanyId <= 0)
			{
				model.ApiCompanyId = null;
			}
			if (model.ApiCmpNumber <= 0)
			{
				model.ApiCmpNumber = null;
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
			if (!model.ApiPordInstallAmount.HasValue)
			{
				model.ApiPordInstallAmount = default(decimal);
			}
			if (!model.ApiPordDiscount.HasValue)
			{
				model.ApiPordDiscount = default(decimal);
			}
			if (!model.ApiPordTax.HasValue)
			{
				model.ApiPordTax = default(decimal);
			}
			if (!model.ApiPordTransportation.HasValue)
			{
				model.ApiPordTransportation = default(decimal);
			}
			if (!model.ApiPordRound.HasValue)
			{
				model.ApiPordRound = default(decimal);
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<IssuePreOrderResultViewModel>
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
			if (!VersionBuyer.PreOrders)
			{
				return new ServiceResult<IssuePreOrderResultViewModel>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("PreOrder", new CultureInfo(currLangId))),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (!string.IsNullOrWhiteSpace(model.ApiCommissionInJsonFormat))
			{
				List<IssuePreOrderCommissionsViewModel> list2 = new JavaScriptSerializer().Deserialize<List<IssuePreOrderCommissionsViewModel>>(model.ApiCommissionInJsonFormat);
				if (list2 != null && Enumerable.Any<IssuePreOrderCommissionsViewModel>((IEnumerable<IssuePreOrderCommissionsViewModel>)list2) && !VersionBuyer.Commissions)
				{
					return new ServiceResult<IssuePreOrderResultViewModel>
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
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string text = null;
			string text2 = "";
			string text3 = "";
			string pordVerifiedRegisterDatePersian = null;
			string pordDeliveryDate = null;
			string text4 = "00:00:00";
			string pordExpireDate = null;
			string text5 = "00:00:00";
			try
			{
				if (!model.ApiPordDate.HasValue)
				{
					ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				text = (model.ApiPordDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				text2 = commonClass.ConvertNameToDayNum((model.ApiPordDate ?? DateTime.Now).DayOfWeek.ToString());
				text3 = (model.ApiPordDate ?? DateTime.Now).ToString("HH:mm:ss");
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPordVerifiedRegisterDate.HasValue)
				{
					pordVerifiedRegisterDatePersian = (model.ApiPordVerifiedRegisterDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerifiedRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ApiPordDeliveryTime))
				{
					text4 = model.ApiPordDeliveryTime;
					string s = DateTime.Now.ToString("yyyy/MM/dd") + " " + text4;
					DateTime dateTime = DateTime.Parse(s, new PersianCulture());
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				ErrorSignal.FromCurrentContext().Raise(e3);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDeliveryTime", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPordDeliveryDate.HasValue)
				{
					string s2 = (model.ApiPordDeliveryDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + text4;
					model.ApiPordDeliveryDate = DateTime.Parse(s2, new CultureInfo("en-US"));
					pordDeliveryDate = (model.ApiPordDeliveryDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDeliveryDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ApiPordExpireTime))
				{
					text5 = model.ApiPordExpireTime;
					string s3 = DateTime.Now.ToString("yyyy/MM/dd") + " " + text5;
					DateTime dateTime2 = DateTime.Parse(s3, new PersianCulture());
				}
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
				ErrorSignal.FromCurrentContext().Raise(e5);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordExpireTime", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPordExpireDate.HasValue)
				{
					string s4 = (model.ApiPordExpireDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + text5;
					model.ApiPordExpireDate = DateTime.Parse(s4, new CultureInfo("en-US"));
					pordExpireDate = (model.ApiPordExpireDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e6)
			{
				ErrorSignal.FromCurrentContext().Raise(e6);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordExpireDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (string.IsNullOrEmpty(model.ApiProductsInJsonFormat))
				{
					ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				List<IssuePreOrderItemsViewModel> list3 = new List<IssuePreOrderItemsViewModel>();
				if (!string.IsNullOrEmpty(model.ApiProductsInJsonFormat))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<IssuePreOrderItemsViewModel>>(model.ApiProductsInJsonFormat);
					if (Enumerable.Any<IssuePreOrderItemsViewModel>((IEnumerable<IssuePreOrderItemsViewModel>)list3))
					{
						foreach (IssuePreOrderItemsViewModel item in list3)
						{
							int value = 0;
							string prdCode = "";
							if (item.PordIPrdId.HasValue)
							{
								value = item.PordIPrdId.GetValueOrDefault();
							}
							if (!string.IsNullOrEmpty(item.PordIPrdCode))
							{
								prdCode = item.PordIPrdCode;
							}
							ApispSelectProductsWithIdOrCode_Result apispSelectProductsWithIdOrCode_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithIdOrCode_Result>((IEnumerable<ApispSelectProductsWithIdOrCode_Result>)cRMEntities.ApispSelectProductsWithIdOrCode(value, prdCode, result, result));
							if (apispSelectProductsWithIdOrCode_Result == null)
							{
								string text6 = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								return new ServiceResult<IssuePreOrderResultViewModel>
								{
									Message = text6.Replace("<br>", "\r\n"),
									Data = null,
									Status = ServiceResultStatus.Error
								};
							}
						}
					}
				}
			}
			catch (Exception e7)
			{
				ErrorSignal.FromCurrentContext().Raise(e7);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ApiProductSpecificationInJsonFormat))
				{
					List<IssuePreOrderItemSpecificatuionViewModel> list4 = new List<IssuePreOrderItemSpecificatuionViewModel>();
					if (!string.IsNullOrEmpty(model.ApiProductSpecificationInJsonFormat))
					{
						list4 = new JavaScriptSerializer().Deserialize<List<IssuePreOrderItemSpecificatuionViewModel>>(model.ApiProductSpecificationInJsonFormat);
					}
				}
			}
			catch (Exception e8)
			{
				ErrorSignal.FromCurrentContext().Raise(e8);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Specificatuion", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ApiPaymentsInJsonFormat))
				{
					List<IssuePreOrderPaymentsViewModel> list5 = new List<IssuePreOrderPaymentsViewModel>();
					if (!string.IsNullOrEmpty(model.ApiPaymentsInJsonFormat))
					{
						list5 = new JavaScriptSerializer().Deserialize<List<IssuePreOrderPaymentsViewModel>>(model.ApiPaymentsInJsonFormat);
						if (Enumerable.Any<IssuePreOrderPaymentsViewModel>((IEnumerable<IssuePreOrderPaymentsViewModel>)list5))
						{
							foreach (IssuePreOrderPaymentsViewModel item2 in list5)
							{
								if (item2.PordpayAmount.HasValue)
								{
									decimal? pordpayAmount = item2.PordpayAmount;
									if (!((pordpayAmount.GetValueOrDefault() == default(decimal)) & pordpayAmount.HasValue))
									{
										if (!item2.PordpayDocAmount.HasValue)
										{
											item2.PordpayDocAmount = item2.PordpayAmount;
										}
										try
										{
											if (item2.PordpayDocDateTime.HasValue)
											{
												string text7 = (item2.PordpayDocDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
											}
										}
										catch (Exception e9)
										{
											ErrorSignal.FromCurrentContext().Raise(e9);
											ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
											serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordPayDocDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
											serviceResult.Data = null;
											serviceResult.Status = ServiceResultStatus.Error;
											return serviceResult;
										}
										continue;
									}
								}
								string text8 = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordPayAmount", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								return new ServiceResult<IssuePreOrderResultViewModel>
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
			catch (Exception e10)
			{
				ErrorSignal.FromCurrentContext().Raise(e10);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Payments", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!string.IsNullOrWhiteSpace(model.ApiCommissionInJsonFormat))
				{
					List<IssuePreOrderCommissionsViewModel> list6 = new JavaScriptSerializer().Deserialize<List<IssuePreOrderCommissionsViewModel>>(model.ApiCommissionInJsonFormat);
					if (list6 != null && Enumerable.Any<IssuePreOrderCommissionsViewModel>((IEnumerable<IssuePreOrderCommissionsViewModel>)list6))
					{
						foreach (IssuePreOrderCommissionsViewModel item3 in list6)
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
								catch (Exception e11)
								{
									ErrorSignal.FromCurrentContext().Raise(e11);
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
							catch (Exception e12)
							{
								ErrorSignal.FromCurrentContext().Raise(e12);
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
							catch (Exception e13)
							{
								ErrorSignal.FromCurrentContext().Raise(e13);
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
							catch (Exception e14)
							{
								ErrorSignal.FromCurrentContext().Raise(e14);
								if (!string.IsNullOrWhiteSpace(text9))
								{
									text9 += ", ";
								}
								text9 += string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommIsPaidDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
							}
							if (!string.IsNullOrWhiteSpace(text9))
							{
								return new ServiceResult<IssuePreOrderResultViewModel>
								{
									Message = text9,
									Data = null,
									Status = ServiceResultStatus.Error
								};
							}
						}
						model.ApiCommissionInJsonFormat = JsonConvert.SerializeObject(Enumerable.ToList<IssuePreOrderCommissionsViewModel>((IEnumerable<IssuePreOrderCommissionsViewModel>)list6));
					}
				}
			}
			catch (Exception e15)
			{
				ErrorSignal.FromCurrentContext().Raise(e15);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Commissions", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value2 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string registerDay = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string registerTime = now.ToString("HH:mm:ss");
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("InsertedPreOrderId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedPreOrderNumber", 0);
			ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispIssuePreOrder(model.UserName, model.Password, model.ApiPordTitle, model.ApiPordNumber, text, model.ApiPordDate, text2, text3, model.ApiPordSubject, model.ApiPordInstallAmount, model.ApiPordDiscount, model.ApiPordTax, model.ApiPordTaxIndex, model.ApiPordCalculateTax, model.ApiPordIsVerified, model.ApiPordVerifierId, model.ApiPordVerifierRequestId, model.ApiPordVerifiedRegisterDate, pordVerifiedRegisterDatePersian, model.ApiPordStatusId, model.ApiPordIsFixed, model.ApiPordGuarantyId, model.ApiPordPayConditionId, model.ApiPordDeliveryTimeId, model.ApiPordCreditDurationId, model.ApiPordSpecialWord, model.ApiPordDescriptionI, model.ApiPordDescriptionII, model.ApiPordDescriptionId, model.ApiPordPrintFormatId, model.ApiPordRLogoId, model.ApiPordLLogoId, model.ApiPordSigningI, model.ApiPordSigningII, model.ApiPordSigningIII, model.ApiPordAccountNumberI, model.ApiPordAccountShabaNumberI, model.ApiPordAccountNumberII, model.ApiPordAccountShabaNumberII, model.ApiPordAddress, model.ApiPordTelephone, model.ApiPordFax, model.ApiPordWebSite, model.ApiPordEmail, model.ApiPordSignatureId, model.ApiPordDiscountTitle, model.ApiPordDiscountPercent, model.ApiPordTransportation, model.ApiPordReferUserId, model.ApiPordRound, model.ApiPordcmpTitle, pordDeliveryDate, model.ApiPordDeliveryDate, text4, model.ApiPordOprId, model.ApiPordVerificationWorkFlowId, pordExpireDate, text5, model.ApiPordExpireDate, model.ApiCompanyId, model.ApiCmpNumber, model.ApiCmpCode, model.ApiCompanyPersonId, model.ApiProjectId, model.ApiPrjTitle, model.ApiProductsInJsonFormat, model.ApiProductSpecificationInJsonFormat, model.ApiPaymentsInJsonFormat, model.ApiWarehouseId, resourceString, userId, value3, value2, registerDatePersian, registerDay, registerTime, appType, result, objectParameter, objectParameter2, objectParameter3, model.ApiPordDeliveryTermId, model.ApiPordDeliveryEndDate, model.ApiPordDeliveryEndDateTime, model.ApiPordDeliveryEndTime, model.ApiPordDeliveryDay, model.ApiPordDeliveryEndDay, model.ApiPordCurrencyUnitId, model.CenterId, model.CenterCode, model.ApiPordLinkAccPreOrderId, model.ApiPordLinkAccPreOrderNumber, model.ApiPordLinkAccPreOrderIdStr, model.ApiPordLinkAccFirstTransferDate, model.ApiPordLinkAccLastTransferDate, model.ApiPordLinkAccData, model.ApiCommissionInJsonFormat));
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<IssuePreOrderResultViewModel>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
			{
				string text10 = "";
				string text11 = objectParameter3.Value.ToString();
				if (text11.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No WhId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Warehouse", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordVerifierId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerifierId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordVerifierRequestId||", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerifierRequestId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordStatusId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordStatusId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordGuarantyId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordGuarantyId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordPayConditionId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordPayConditionId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordDeliveryTimeId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDeliveryTimeId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordCreditDurationId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordCreditDurationId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordPrintFormatId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordPrintFormatId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordRLogoId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordRLogoId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordLLogoId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordLLogoId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordSignatureId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordSignatureId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordReferUserId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordReferUserId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PreOrderOprId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrderOprId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordVerificationWorkFlowId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerificationWorkFlowId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordCompany", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordCompanyPerson", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordProject", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PrdId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordIPrdUnitId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordIPrdUnitId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordICurrencyUnitId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordICurrencyUnitId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordIWHId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Warehouse", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordIPrdPriceGroupId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdPriceGroupId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordItemId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordpayTypeId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayTypeId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No pordCurrencyUnitId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CurrencyUnit", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No Prd|", StringComparison.Ordinal) >= 0 || text11.IndexOf("Not Prd|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("DupPordNumber=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text11.Split(new char[1] { '=' });
					string text12 = "";
					if (array != null && array.Length == 2)
					{
						text12 = array[1] ?? "";
					}
					text12 = ((!string.IsNullOrEmpty(text12)) ? text12.TrimEnd(new char[1] { '|' }) : "");
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorPreOrderNumberIsRepeated", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text12) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordpayBankingBankID|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayBankingBankID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordpayBankingBranchID|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayBankingBranchID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordpayBankingAccountID|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayBankingAccountID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordpayCashId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayCashId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordpayGroupIId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayGroupIId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("No PordpayGroupIIId|", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayGroupIIId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text10.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text11.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text10 += resourceString3;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text11));
					return new ServiceResult<IssuePreOrderResultViewModel>
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
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				IssuePreOrderResultViewModel issuePreOrderResultViewModel = new IssuePreOrderResultViewModel();
				issuePreOrderResultViewModel.PreOrderId = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				issuePreOrderResultViewModel.PreOrderNumber = ((objectParameter2.Value != null) ? long.Parse(objectParameter2.Value.ToString() ?? "0") : 0);
				data = issuePreOrderResultViewModel;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text13 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text13 = text13 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text13)) ? (" (" + text13 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<IssuePreOrderResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<FullUpdatePreOrderResultViewModel> FullUpdatePreOrder(FullUpdatePreOrderViewModel model)
	{
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		FullUpdatePreOrderResultViewModel fullUpdatePreOrderResultViewModel = new FullUpdatePreOrderResultViewModel();
		fullUpdatePreOrderResultViewModel.PreOrderResult = new ServiceResult<int>();
		fullUpdatePreOrderResultViewModel.PreOrderItemResult = new List<FullUpdatePreOrderResultViewModel.FullUpdatePreOrderItemResultViewModel>();
		fullUpdatePreOrderResultViewModel.PreOrderPaymentResult = new List<FullUpdatePreOrderResultViewModel.FullUpdatePreOrderPaymentResultViewModel>();
		try
		{
			if (model.PreOrder != null)
			{
				fullUpdatePreOrderResultViewModel.PreOrderResult = Update(model.PreOrder);
				if (fullUpdatePreOrderResultViewModel.PreOrderResult.Status == ServiceResultStatus.Success)
				{
					status = ServiceResultStatus.Success;
				}
			}
			if (model.PreOrderItemsList != null && model.PreOrderItemsList.Count > 0)
			{
				for (int i = 0; i < model.PreOrderItemsList.Count; i++)
				{
					ServiceResult<int> serviceResult = UpdatePreOrderItem(model.PreOrderItemsList[i]);
					if (serviceResult.Status != ServiceResultStatus.Success)
					{
						status = ServiceResultStatus.Error;
						message = "";
						FullUpdatePreOrderResultViewModel.FullUpdatePreOrderItemResultViewModel fullUpdatePreOrderItemResultViewModel = new FullUpdatePreOrderResultViewModel.FullUpdatePreOrderItemResultViewModel();
						fullUpdatePreOrderItemResultViewModel.Index = i;
						fullUpdatePreOrderItemResultViewModel.PreOrderItemId = model.PreOrderItemsList[i].ApiPreOrderItemId;
						fullUpdatePreOrderItemResultViewModel.Result = serviceResult;
						fullUpdatePreOrderResultViewModel.PreOrderItemResult.Add(fullUpdatePreOrderItemResultViewModel);
					}
				}
			}
			if (model.PreOrderPaymentsList != null && model.PreOrderPaymentsList.Count > 0)
			{
				for (int j = 0; j < model.PreOrderPaymentsList.Count; j++)
				{
					ServiceResult<int> serviceResult2 = UpdatePreOrderPayment(model.PreOrderPaymentsList[j]);
					if (serviceResult2.Status != ServiceResultStatus.Success)
					{
						status = ServiceResultStatus.Error;
						message = "";
						FullUpdatePreOrderResultViewModel.FullUpdatePreOrderPaymentResultViewModel fullUpdatePreOrderPaymentResultViewModel = new FullUpdatePreOrderResultViewModel.FullUpdatePreOrderPaymentResultViewModel();
						fullUpdatePreOrderPaymentResultViewModel.Index = j;
						fullUpdatePreOrderPaymentResultViewModel.PreOrderPaymentId = model.PreOrderPaymentsList[j].ApiPreOrderPaymentId;
						fullUpdatePreOrderPaymentResultViewModel.Result = serviceResult2;
						fullUpdatePreOrderResultViewModel.PreOrderPaymentResult.Add(fullUpdatePreOrderPaymentResultViewModel);
					}
				}
			}
			if (model.PreOrderCommissionsList != null && model.PreOrderCommissionsList.Count > 0)
			{
				for (int k = 0; k < model.PreOrderCommissionsList.Count; k++)
				{
					ServiceResult<int> serviceResult3 = UpdatePreOrderCommission(model.PreOrderCommissionsList[k]);
					if (serviceResult3.Status != ServiceResultStatus.Success)
					{
						status = ServiceResultStatus.Error;
						message = "";
						FullUpdatePreOrderResultViewModel.FullUpdatePreOrderCommisionResultViewModel fullUpdatePreOrderCommisionResultViewModel = new FullUpdatePreOrderResultViewModel.FullUpdatePreOrderCommisionResultViewModel();
						fullUpdatePreOrderCommisionResultViewModel.Index = k;
						fullUpdatePreOrderCommisionResultViewModel.PreOrderCommissionId = model.PreOrderCommissionsList[k].ApiPreOrderCommissionId;
						fullUpdatePreOrderCommisionResultViewModel.Result = serviceResult3;
						fullUpdatePreOrderResultViewModel.PreOrderCommissionResult.Add(fullUpdatePreOrderCommisionResultViewModel);
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
			fullUpdatePreOrderResultViewModel = null;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return new ServiceResult<FullUpdatePreOrderResultViewModel>
		{
			Message = message,
			Status = status,
			Data = fullUpdatePreOrderResultViewModel
		};
	}

	[HttpPost]
	public ServiceResult<IssuePreOrderResultViewModel> Insert(InsertPreOrderViewModel model)
	{
		CRMEntities cRMEntities = null;
		IssuePreOrderResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<IssuePreOrderResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			if (model.ApiPordNumber <= 0)
			{
				model.ApiPordNumber = null;
			}
			if (model.ApiPordVerifierId <= 0)
			{
				model.ApiPordVerifierId = null;
			}
			if (model.ApiPordVerifierRequestId <= 0)
			{
				model.ApiPordVerifierRequestId = null;
			}
			if (model.ApiPordStatusId <= 0)
			{
				model.ApiPordStatusId = null;
			}
			if (model.ApiPordGuarantyId <= 0)
			{
				model.ApiPordGuarantyId = null;
			}
			if (model.ApiPordPayConditionId <= 0)
			{
				model.ApiPordPayConditionId = null;
			}
			if (model.ApiPordDeliveryTimeId <= 0)
			{
				model.ApiPordDeliveryTimeId = null;
			}
			if (model.ApiPordCreditDurationId <= 0)
			{
				model.ApiPordCreditDurationId = null;
			}
			if (model.ApiPordDescriptionId <= 0)
			{
				model.ApiPordDescriptionId = null;
			}
			if (model.ApiPordPrintFormatId <= 0)
			{
				model.ApiPordPrintFormatId = null;
			}
			if (model.ApiPordRLogoId <= 0)
			{
				model.ApiPordRLogoId = null;
			}
			if (model.ApiPordLLogoId <= 0)
			{
				model.ApiPordLLogoId = null;
			}
			if (model.ApiPordSignatureId <= 0)
			{
				model.ApiPordSignatureId = null;
			}
			if (model.ApiPordReferUserId <= 0)
			{
				model.ApiPordReferUserId = null;
			}
			if (model.ApiPordOprId <= 0)
			{
				model.ApiPordOprId = null;
			}
			if (model.ApiPordVerificationWorkFlowId <= 0)
			{
				model.ApiPordVerificationWorkFlowId = null;
			}
			if (model.ApiCompanyId <= 0)
			{
				model.ApiCompanyId = null;
			}
			if (model.ApiCmpNumber <= 0)
			{
				model.ApiCmpNumber = null;
			}
			if (model.ApiCompanyPersonId <= 0)
			{
				model.ApiCompanyPersonId = null;
			}
			if (model.ApiProjectId <= 0)
			{
				model.ApiProjectId = null;
			}
			if (!model.ApiPordInstallAmount.HasValue)
			{
				model.ApiPordInstallAmount = default(decimal);
			}
			if (!model.ApiPordDiscount.HasValue)
			{
				model.ApiPordDiscount = default(decimal);
			}
			if (!model.ApiPordTax.HasValue)
			{
				model.ApiPordTax = default(decimal);
			}
			if (!model.ApiPordTransportation.HasValue)
			{
				model.ApiPordTransportation = default(decimal);
			}
			if (!model.ApiPordRound.HasValue)
			{
				model.ApiPordRound = default(decimal);
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<IssuePreOrderResultViewModel>
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
			if (!VersionBuyer.PreOrders)
			{
				return new ServiceResult<IssuePreOrderResultViewModel>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("PreOrder", new CultureInfo(currLangId))),
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
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string text = null;
			string text2 = "";
			string text3 = "";
			string pordVerifiedRegisterDatePersian = null;
			string pordDeliveryDate = null;
			string text4 = "00:00:00";
			string pordExpireDate = null;
			string text5 = "00:00:00";
			try
			{
				if (!model.ApiPordDate.HasValue)
				{
					ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				text = (model.ApiPordDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				text2 = commonClass.ConvertNameToDayNum((model.ApiPordDate ?? DateTime.Now).DayOfWeek.ToString());
				text3 = (model.ApiPordDate ?? DateTime.Now).ToString("HH:mm:ss");
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPordVerifiedRegisterDate.HasValue)
				{
					pordVerifiedRegisterDatePersian = (model.ApiPordVerifiedRegisterDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerifiedRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ApiPordDeliveryTime))
				{
					text4 = model.ApiPordDeliveryTime;
					string s = DateTime.Now.ToString("yyyy/MM/dd") + " " + text4;
					DateTime dateTime = DateTime.Parse(s, new PersianCulture());
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				ErrorSignal.FromCurrentContext().Raise(e3);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDeliveryTime", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPordDeliveryDate.HasValue)
				{
					string s2 = (model.ApiPordDeliveryDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + text4;
					model.ApiPordDeliveryDate = DateTime.Parse(s2, new CultureInfo("en-US"));
					pordDeliveryDate = (model.ApiPordDeliveryDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDeliveryDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ApiPordExpireTime))
				{
					text5 = model.ApiPordExpireTime;
					string s3 = DateTime.Now.ToString("yyyy/MM/dd") + " " + text5;
					DateTime dateTime2 = DateTime.Parse(s3, new PersianCulture());
				}
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
				ErrorSignal.FromCurrentContext().Raise(e5);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordExpireTime", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPordExpireDate.HasValue)
				{
					string s4 = (model.ApiPordExpireDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + text5;
					model.ApiPordExpireDate = DateTime.Parse(s4, new CultureInfo("en-US"));
					pordExpireDate = (model.ApiPordExpireDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e6)
			{
				ErrorSignal.FromCurrentContext().Raise(e6);
				ServiceResult<IssuePreOrderResultViewModel> serviceResult = new ServiceResult<IssuePreOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordExpireDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string registerDay = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string registerTime = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("InsertedPreOrderId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedPreOrderNumber", 0);
			ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertPreOrder(model.ApiPordTitle, model.ApiPordNumber, text, model.ApiPordDate, text2, text3, model.ApiPordSubject, model.ApiPordInstallAmount, model.ApiPordDiscount, model.ApiPordTax, model.ApiPordTaxIndex, model.ApiPordCalculateTax, model.ApiPordIsVerified, model.ApiPordVerifierId, model.ApiPordVerifierRequestId, model.ApiPordVerifiedRegisterDate, pordVerifiedRegisterDatePersian, model.ApiPordStatusId, model.ApiPordIsFixed, model.ApiPordGuarantyId, model.ApiPordPayConditionId, model.ApiPordDeliveryTimeId, model.ApiPordCreditDurationId, model.ApiPordSpecialWord, model.ApiPordDescriptionI, model.ApiPordDescriptionII, model.ApiPordDescriptionId, model.ApiPordPrintFormatId, model.ApiPordRLogoId, model.ApiPordLLogoId, model.ApiPordSigningI, model.ApiPordSigningII, model.ApiPordSigningIII, model.ApiPordAccountNumberI, model.ApiPordAccountShabaNumberI, model.ApiPordAccountNumberII, model.ApiPordAccountShabaNumberII, model.ApiPordAddress, model.ApiPordTelephone, model.ApiPordFax, model.ApiPordWebSite, model.ApiPordEmail, model.ApiPordSignatureId, model.ApiPordDiscountTitle, model.ApiPordDiscountPercent, model.ApiPordTransportation, model.ApiPordReferUserId, model.ApiPordRound, model.ApiPordcmpTitle, pordDeliveryDate, model.ApiPordDeliveryDate, text4, model.ApiPordOprId, model.ApiPordVerificationWorkFlowId, pordExpireDate, text5, model.ApiPordExpireDate, model.ApiCompanyId, model.ApiCmpNumber, model.ApiCmpCode, model.ApiCompanyPersonId, model.ApiProjectId, model.ApiPrjTitle, resourceString, userId, value2, value, registerDatePersian, registerDay, registerTime, appType, result, objectParameter, objectParameter2, objectParameter3, model.ApiPordDeliveryTermId, model.ApiPordDeliveryEndDate, model.ApiPordDeliveryEndDateTime, model.ApiPordDeliveryEndTime, model.ApiPordDeliveryDay, model.ApiPordDeliveryEndDay, model.ApiPordCurrencyUnitId, model.CenterId, model.CenterCode, model.ApiPordLinkAccPreOrderId, model.ApiPordLinkAccPreOrderNumber, model.ApiPordLinkAccPreOrderIdStr, model.ApiPordLinkAccFirstTransferDate, model.ApiPordLinkAccLastTransferDate, model.ApiPordLinkAccData));
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<IssuePreOrderResultViewModel>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
			{
				string text6 = "";
				string text7 = objectParameter3.Value.ToString();
				if (text7.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordVerifierId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerifierId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordVerifierRequestId||", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerifierRequestId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordStatusId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordStatusId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordGuarantyId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordGuarantyId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordPayConditionId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordPayConditionId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordDeliveryTimeId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDeliveryTimeId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordCreditDurationId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordCreditDurationId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordPrintFormatId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordPrintFormatId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordRLogoId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordRLogoId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordLLogoId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordLLogoId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordSignatureId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordSignatureId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordReferUserId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordReferUserId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PreOrderOprId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrderOprId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordVerificationWorkFlowId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerificationWorkFlowId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordCompany", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordCompanyPerson", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordProject", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No pordCurrencyUnitId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CurrencyUnit", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("DupPordNumber=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text7.Split(new char[1] { '=' });
					string text8 = "";
					if (array != null && array.Length == 2)
					{
						text8 = array[1] ?? "";
					}
					text8 = ((!string.IsNullOrEmpty(text8)) ? text8.TrimEnd(new char[1] { '|' }) : "");
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorPreOrderNumberIsRepeated", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text8) + " " + resourceString3;
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text6 += resourceString3;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text7));
					return new ServiceResult<IssuePreOrderResultViewModel>
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
					return new ServiceResult<IssuePreOrderResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				IssuePreOrderResultViewModel issuePreOrderResultViewModel = new IssuePreOrderResultViewModel();
				issuePreOrderResultViewModel.PreOrderId = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				issuePreOrderResultViewModel.PreOrderNumber = ((objectParameter2.Value != null) ? long.Parse(objectParameter2.Value.ToString() ?? "0") : 0);
				data = issuePreOrderResultViewModel;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text9 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text9 = text9 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text9)) ? (" (" + text9 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<IssuePreOrderResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> InsertPreOrderItem(InsertPreOrderItemViewModel model)
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
			if (model.ApiPreOrderId <= 0)
			{
				model.ApiPreOrderId = null;
			}
			if (model.ApiPordNumber <= 0)
			{
				model.ApiPordNumber = null;
			}
			if (model.ApiPordIPrdId <= 0)
			{
				model.ApiPordIPrdId = null;
			}
			if (model.ApiPordIPrdUnitId <= 0)
			{
				model.ApiPordIPrdUnitId = null;
			}
			if (model.ApiPordICurrencyUnitId <= 0)
			{
				model.ApiPordICurrencyUnitId = null;
			}
			if (model.ApiPordIWHId <= 0)
			{
				model.ApiPordIWHId = null;
			}
			if (model.ApiPordIPrdPriceGroupId <= 0)
			{
				model.ApiPordIPrdPriceGroupId = null;
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
			string text = null;
			if (!string.IsNullOrEmpty(model.ApiPordIValidityExpireDatePersian) && model.ApiPordIValidityExpireDatePersian.ToLower() == "null")
			{
				text = model.ApiPordIValidityExpireDatePersian;
				model.ApiPordIValidityExpireDate = null;
			}
			else
			{
				try
				{
					if (model.ApiPordIValidityExpireDate.HasValue)
					{
						string s = (model.ApiPordIValidityExpireDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + ((text != "null" && !string.IsNullOrEmpty(text)) ? text : DateTime.Now.ToString("HH:mm:ss"));
						model.ApiPordIValidityExpireDate = DateTime.Parse(s, new CultureInfo("en-US"));
						text = (model.ApiPordIValidityExpireDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordIValidityExpireDatePersian", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			string text2 = null;
			if (!string.IsNullOrEmpty(model.ApiPordIDeliveryDatePersian) && model.ApiPordIDeliveryDatePersian.ToLower() == "null")
			{
				text2 = model.ApiPordIDeliveryDatePersian;
				model.ApiPordIDeliveryDatePersian = null;
			}
			else
			{
				try
				{
					if (model.ApiPordIDeliveryDate.HasValue)
					{
						string s2 = (model.ApiPordIDeliveryDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + ((text2 != "null" && !string.IsNullOrEmpty(text2)) ? text2 : DateTime.Now.ToString("HH:mm:ss"));
						model.ApiPordIDeliveryDate = DateTime.Parse(s2, new CultureInfo("en-US"));
						text2 = (model.ApiPordIDeliveryDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordIDeliveryDatePersian", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			string text3 = null;
			if (!string.IsNullOrEmpty(model.ApiPordIDeliveryEndDatePersian) && model.ApiPordIDeliveryEndDatePersian.ToLower() == "null")
			{
				text3 = model.ApiPordIDeliveryEndDatePersian;
				model.ApiPordIDeliveryEndDatePersian = null;
			}
			else
			{
				try
				{
					if (model.ApiPordIDeliveryEndDate.HasValue)
					{
						string s3 = (model.ApiPordIDeliveryEndDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + ((text3 != "null" && !string.IsNullOrEmpty(text3)) ? text3 : DateTime.Now.ToString("HH:mm:ss"));
						model.ApiPordIDeliveryEndDate = DateTime.Parse(s3, new CultureInfo("en-US"));
						text3 = (model.ApiPordIDeliveryEndDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordIDeliveryEndDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text4 = now.ToString("yyyyMMdd", new PersianCulture());
			string text5 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text6 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedPreOrderItemId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			CRMEntities cRMEntities2 = cRMEntities;
			int? apiPreOrderId = model.ApiPreOrderId;
			long? apiPordNumber = model.ApiPordNumber;
			int? apiPordIPrdId = model.ApiPordIPrdId;
			string apiPordIPrdCode = model.ApiPordIPrdCode;
			double? apiPordIQuantity = model.ApiPordIQuantity;
			decimal? apiPordIPrice = model.ApiPordIPrice;
			decimal? apiPordITotalPrice = model.ApiPordITotalPrice;
			string apiPordIDescription = model.ApiPordIDescription;
			string apiPordIQuantityDesc = model.ApiPordIQuantityDesc;
			decimal? apiPordIDiscount = model.ApiPordIDiscount;
			decimal? apiPordIDiscountI = model.ApiPordIDiscountI;
			decimal? apiPordIDiscountPercent = model.ApiPordIDiscountPercent;
			decimal? apiPordIDiscountIPercent = model.ApiPordIDiscountIPercent;
			int? apiPordIPrdUnitId = model.ApiPordIPrdUnitId;
			int? apiPordICurrencyUnitId = model.ApiPordICurrencyUnitId;
			int? apiPordIOrderView = model.ApiPordIOrderView;
			double? apiPordIFCR = model.ApiPordIFCR;
			decimal? apiPordITax = model.ApiPordITax;
			decimal? apiPordITaxIndex = model.ApiPordITaxIndex;
			bool? apiPordICalculateTax = model.ApiPordICalculateTax;
			bool? apiPordINotVisible = model.ApiPordINotVisible;
			double? apiPordIFCRI = model.ApiPordIFCRI;
			bool? apiPordINotInSum = model.ApiPordINotInSum;
			int? apiPordIWHId = model.ApiPordIWHId;
			decimal? apiPordIRound = model.ApiPordIRound;
			decimal? apiPordIRoundPlus = model.ApiPordIRoundPlus;
			int? apiPordIPrdPriceGroupId = model.ApiPordIPrdPriceGroupId;
			int? userId2 = userId;
			short? month = value2;
			DateTime? registerDate = value;
			string registerDatePersian = text4;
			string appType2 = appType;
			int? languageID = result;
			ObjectParameter insertedPreOrderItemId = objectParameter;
			ObjectParameter errorMessage = objectParameter2;
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.ApispInsertPreOrderItems(apiPreOrderId, apiPordNumber, apiPordIPrdId, apiPordIPrdCode, apiPordIQuantity, apiPordIPrice, apiPordITotalPrice, apiPordIDescription, apiPordIQuantityDesc, apiPordIDiscount, apiPordIDiscountI, apiPordIDiscountPercent, apiPordIDiscountIPercent, apiPordIPrdUnitId, apiPordICurrencyUnitId, apiPordIOrderView, apiPordIFCR, apiPordITax, apiPordITaxIndex, apiPordICalculateTax, apiPordINotVisible, apiPordIFCRI, apiPordINotInSum, apiPordIWHId, apiPordIRound, apiPordIRoundPlus, apiPordIPrdPriceGroupId, model.ApiPordITracing, userId2, month, registerDate, registerDatePersian, appType2, languageID, insertedPreOrderItemId, errorMessage, model.ApiPordIValidityExpireDate, text, model.ApiPordIDeliveryTermId, model.ApiPordIDeliveryDate, text2, model.ApiPordIDeliveryTime, model.ApiPordIDeliveryDay, model.ApiPordIDeliveryEndDate, text3, model.ApiPordIDeliveryEndTime, model.ApiPordIDeliveryEndDay, model.CenterId, model.CenterCode, model.ApiPordILinkAccItemId, model.ApiPordILinkAccItemIdStr, model.ApiPordILinkAccWHIdStr, model.ApiPordILinkAccFirstTransferDate, model.ApiPordILinkAccLastTransferDate, model.ApiPordILinkAccData, model.ApiPordIPriceSum, model.ApiPordIDiscountSum, model.ApiPordITaxSum));
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
				string text7 = "";
				string text8 = objectParameter2.Value.ToString();
				if (text8.IndexOf("No PordId|", StringComparison.Ordinal) >= 0)
				{
					text7 = text7 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text7.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text8.IndexOf("No PrdId|", StringComparison.Ordinal) >= 0)
				{
					text7 = text7 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text7.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text8.IndexOf("No PordIPrdUnitId|", StringComparison.Ordinal) >= 0)
				{
					text7 = text7 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordIPrdUnitId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text7.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text8.IndexOf("No PordICurrencyUnitId|", StringComparison.Ordinal) >= 0)
				{
					text7 = text7 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordICurrencyUnitId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text7.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text8.IndexOf("No PordIWHId|", StringComparison.Ordinal) >= 0)
				{
					text7 = text7 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Warehouse", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text7.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text8.IndexOf("No PordIPrdPriceGroupId|", StringComparison.Ordinal) >= 0)
				{
					text7 = text7 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdPriceGroupId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text7.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text8.IndexOf("IsFixed|", StringComparison.Ordinal) >= 0)
				{
					text7 = text7 + MyResource.GetResourceString("ErrorPordIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text7.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text8.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text7 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text8));
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
			string text9 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text9 = text9 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text9)) ? (" (" + text9 + ")") : "");
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
	public ServiceResult<int> InsertPreOrderItemSpecification(InsertPreOrderItemSpecificationViewModel model)
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
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedPreOrderItemSpcflId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertPreOrderItemSpecification(model.ApiPreOrderItemId, model.ApiSpecification, model.ApiSpecificationI, model.ApiSpecificationII, userId, value2, value, registerDatePersian, appType, result, objectParameter, objectParameter2, model.CenterId, model.CenterCode));
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
				string text3 = "";
				string text4 = objectParameter2.Value.ToString();
				if (text4.IndexOf("No PordItemId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("IsFixed|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + MyResource.GetResourceString("ErrorPordIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text3 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text4));
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

	[HttpPost]
	public ServiceResult<int> InsertPreOrderPayment(InsertPreOrderPaymentViewModel model)
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
			if (model.ApiPreOrderId <= 0)
			{
				model.ApiPreOrderId = null;
			}
			if (model.ApiPordNumber <= 0)
			{
				model.ApiPordNumber = null;
			}
			if (model.ApiPordPayTypeId <= 0)
			{
				model.ApiPordPayTypeId = null;
			}
			if (model.ApiPordPayDocId <= 0)
			{
				model.ApiPordPayDocId = null;
			}
			if (model.ApiPordPayDocTypeId <= 0)
			{
				model.ApiPordPayDocTypeId = null;
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
			if (!model.ApiPordPayAmount.HasValue)
			{
				goto IL_025c;
			}
			decimal? apiPordPayAmount = model.ApiPordPayAmount;
			if ((apiPordPayAmount.GetValueOrDefault() == default(decimal)) & apiPordPayAmount.HasValue)
			{
				goto IL_025c;
			}
			if (!model.ApiPordPayDocAmount.HasValue)
			{
				model.ApiPordPayDocAmount = model.ApiPordPayAmount;
			}
			string text = null;
			try
			{
				if (model.ApiPordPayDocDateTime.HasValue)
				{
					text = (model.ApiPordPayDocDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordPayDocDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
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
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text3 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedPreOrderPaymentId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertPreOrderPayments(model.ApiPreOrderId, model.ApiPordNumber, model.ApiPordPayTypeId, model.ApiPordPayDocId, model.ApiPordPayDocTypeId, model.ApiPordPayAmount, model.ApiPordPayDocNumber, text, model.ApiPordPayDocDateTime, pordpayDescription: model.ApiPordPayDescription, pordpayDocAmount: model.ApiPordPayDocAmount, userId: userId, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: result, insertedPreOrderPaymentId: objectParameter, errorMessage: objectParameter2, centerId: model.CenterId, centerCode: model.CenterCode, pordpayLinkAccHeaderId: model.ApiPordpayLinkAccHeaderId, pordpayLinkAccHeaderNumber: model.ApiPordpayLinkAccHeaderNumber, pordpayLinkAccDetailId: model.ApiPordpayLinkAccDetailId, pordpayLinkAccVoucherId: model.ApiPordpayLinkAccVoucherId, pordpayLinkAccVoucherNumber: model.ApiPordpayLinkAccVoucherNumber, pordpayLinkAccHeaderIdStr: model.ApiPordpayLinkAccHeaderIdStr, pordpayLinkAccDetailIdStr: model.ApiPordpayLinkAccDetailIdStr, pordpayLinkAccVoucherIdStr: model.ApiPordpayLinkAccVoucherIdStr, pordpayLinkAccPayType: model.ApiPordpayLinkAccPayType, pordpayLinkAccFirstTransferDate: model.ApiPordpayLinkAccFirstTransferDate, pordpayLinkAccLastTransferDate: model.ApiPordpayLinkAccLastTransferDate, pordpayLinkAccData: model.ApiPordpayLinkAccData, pordpayBankingBankID: model.ApiPordpayBankingBankID, pordpayBankingBranchID: model.ApiPordpayBankingBranchID, pordpayBankingAccountID: model.ApiPordpayBankingAccountID, pordpayCashId: model.ApiPordpayCashId, pordpayGroupIdI: model.ApiPordpayGroupIdI, pordpayGroupIdII: model.ApiPordpayGroupIdII, pordpayChqSayadNumber: model.ApiPordpayChqSayadNumber, pordpayChqSerialNumber: model.ApiPordpayChqSerialNumber, pordpayDocDayTemp: model.ApiPordpayDocDayTemp, pordpayBankName: model.ApiPordpayBankName, pordpayBranchName: model.ApiPordpayBranchName, pordpayBranchCode: model.ApiPordpayBranchCode));
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
				string text4 = "";
				string text5 = objectParameter2.Value.ToString();
				if (text5.IndexOf("No PordId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PordpayTypeId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayTypeId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PordpayBankingBankID|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayBankingBankID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PordpayBankingBranchID|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayBankingBranchID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PordpayBankingAccountID|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayBankingAccountID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PordpayCashId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayCashId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PordpayGroupIId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayGroupIId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PordpayGroupIIId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayGroupIIId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text4 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text5));
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
			IL_025c:
			string text6 = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordPayAmount", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			return new ServiceResult<int>
			{
				Message = text6.Replace("<br>", "\r\n"),
				Data = 0,
				Status = ServiceResultStatus.Error
			};
			end_IL_000c:;
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
	public ServiceResult<int> Update(UpdatePreOrderViewModel model)
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
			string text7 = null;
			string text8 = "00:00:00";
			if (!string.IsNullOrEmpty(model.ApiPordDate) && model.ApiPordDate.ToLower() == "null")
			{
				text = model.ApiPordDate;
				model.ApiPordDateTime = null;
				text2 = "null";
				text3 = "null";
			}
			else
			{
				try
				{
					if (model.ApiPordDateTime.HasValue)
					{
						text = (model.ApiPordDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
						text2 = commonClass.ConvertNameToDayNum((model.ApiPordDateTime ?? DateTime.Now).DayOfWeek.ToString());
						text3 = (model.ApiPordDateTime ?? DateTime.Now).ToString("HH:mm:ss");
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPordVerifiedRegisterDatePersian) && model.ApiPordVerifiedRegisterDatePersian.ToLower() == "null")
			{
				text4 = model.ApiPordVerifiedRegisterDatePersian;
				model.ApiPordVerifiedRegisterDate = null;
			}
			else
			{
				try
				{
					if (model.ApiPordVerifiedRegisterDate.HasValue)
					{
						text4 = (model.ApiPordVerifiedRegisterDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerifiedRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPordDeliveryTime) && model.ApiPordDeliveryTime.ToLower() == "null")
			{
				text6 = model.ApiPordDeliveryTime;
			}
			else
			{
				try
				{
					if (!string.IsNullOrEmpty(model.ApiPordDeliveryTime))
					{
						text6 = model.ApiPordDeliveryTime;
						string s = DateTime.Now.ToString("yyyy/MM/dd") + " " + text6;
						DateTime dateTime = DateTime.Parse(s, new PersianCulture());
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					ErrorSignal.FromCurrentContext().Raise(e3);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDeliveryTime", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPordDeliveryDate) && model.ApiPordDeliveryDate.ToLower() == "null")
			{
				text5 = model.ApiPordDeliveryDate;
				model.ApiPordDeliveryDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiPordDeliveryDateTime.HasValue)
					{
						string s2 = (model.ApiPordDeliveryDateTime ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + ((text6 != "null" && !string.IsNullOrEmpty(text6)) ? text6 : DateTime.Now.ToString("HH:mm:ss"));
						model.ApiPordDeliveryDateTime = DateTime.Parse(s2, new CultureInfo("en-US"));
						text5 = (model.ApiPordDeliveryDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e4)
				{
					ErrorSignal.FromCurrentContext().Raise(e4);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDeliveryDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPordExpireTime) && model.ApiPordExpireTime.ToLower() == "null")
			{
				text8 = model.ApiPordExpireTime;
			}
			else
			{
				try
				{
					if (!string.IsNullOrEmpty(model.ApiPordExpireTime))
					{
						text8 = model.ApiPordExpireTime;
						string s3 = DateTime.Now.ToString("yyyy/MM/dd") + " " + text8;
						DateTime dateTime2 = DateTime.Parse(s3, new PersianCulture());
					}
				}
				catch (Exception e5)
				{
					ErrorSignal.FromCurrentContext().Raise(e5);
					ErrorSignal.FromCurrentContext().Raise(e5);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordExpireTime", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPordExpireDate) && model.ApiPordExpireDate.ToLower() == "null")
			{
				text7 = model.ApiPordExpireDate;
				model.ApiPordExpireDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiPordExpireDateTime.HasValue)
					{
						string s4 = (model.ApiPordExpireDateTime ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + ((text8 != "null" && !string.IsNullOrEmpty(text8)) ? text8 : DateTime.Now.ToString("HH:mm:ss"));
						model.ApiPordExpireDateTime = DateTime.Parse(s4, new CultureInfo("en-US"));
						text7 = (model.ApiPordExpireDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e6)
				{
					ErrorSignal.FromCurrentContext().Raise(e6);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordExpireDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiPreOrderId <= 0)
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
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text9 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text10 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num2 = cRMEntities.ApispUpdatePreOrder(model.ApiPreOrderId, model.ApiPordTitle, model.ApiPordNumber, text, model.ApiPordDateTime, pordDay: text2, pordTime: text3, pordSubject: model.ApiPordSubject, pordInstallAmount: model.ApiPordInstallAmount, pordDiscount: model.ApiPordDiscount, pordTax: model.ApiPordTax, pordTaxIndex: model.ApiPordTaxIndex, pordCalculateTax: model.ApiPordCalculateTax, pordIsVerified: model.ApiPordIsVerified, pordVerifierId: model.ApiPordVerifierId, pordVerifierRequestId: model.ApiPordVerifierRequestId, pordVerifiedRegisterDate: model.ApiPordVerifiedRegisterDate, pordVerifiedRegisterDatePersian: text4, pordStatusId: model.ApiPordStatusId, pordIsFixed: model.ApiPordIsFixed, pordGuarantyId: model.ApiPordGuarantyId, pordPayConditionId: model.ApiPordPayConditionId, pordDeliveryTimeId: model.ApiPordDeliveryTimeId, pordCreditDurationId: model.ApiPordCreditDurationId, pordSpecialWord: model.ApiPordSpecialWord, pordDescriptionI: model.ApiPordDescriptionI, pordDescriptionII: model.ApiPordDescriptionII, pordDescriptionId: model.ApiPordDescriptionId, pordPrintFormatId: model.ApiPordPrintFormatId, pordRLogoId: model.ApiPordRLogoId, pordLLogoId: model.ApiPordLLogoId, pordSigningI: model.ApiPordSigningI, pordSigningII: model.ApiPordSigningII, pordSigningIII: model.ApiPordSigningIII, pordAccountNumberI: model.ApiPordAccountNumberI, pordAccountShabaNumberI: model.ApiPordAccountShabaNumberI, pordAccountNumberII: model.ApiPordAccountNumberII, pordAccountShabaNumberII: model.ApiPordAccountShabaNumberII, pordAddress: model.ApiPordAddress, pordTelephone: model.ApiPordTelephone, pordFax: model.ApiPordFax, pordWebSite: model.ApiPordWebSite, pordEmail: model.ApiPordEmail, pordSignatureId: model.ApiPordSignatureId, pordDiscountTitle: model.ApiPordDiscountTitle, pordDiscountPercent: model.ApiPordDiscountPercent, pordTransportation: model.ApiPordTransportation, pordReferUserId: model.ApiPordReferUserId, pordRound: model.ApiPordRound, pordcmpTitle: model.ApiPordcmpTitle, pordDeliveryDate: text5, pordDeliveryDateTime: model.ApiPordDeliveryDateTime, pordDeliveryTime: text6, preOrderOprID: model.ApiPordOprId, pordVerificationWorkFlowId: model.ApiPordVerificationWorkFlowId, pordExpireDate: text7, pordExpireDateTime: model.ApiPordExpireDateTime, pordCompanyId: model.ApiCompanyId, pordCompanyPersonId: model.ApiCompanyPersonId, pordProjectId: model.ApiProjectId, pordItemCount: null, pordItemsAmount: null, pordSumAmount: null, pordTotalAmount: null, pordTotalAmountStr: null, userId: userId, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: currLangId, defaultLanguageID: result, errorMessage: objectParameter, pordDeliveryTermId: model.ApiPordDeliveryTermId, pordDeliveryEndDate: model.ApiPordDeliveryEndDate, pordDeliveryEndDateTime: model.ApiPordDeliveryEndDateTime, pordDeliveryEndTime: model.ApiPordDeliveryEndTime, pordDeliveryDay: model.ApiPordDeliveryDay, pordDeliveryEndDay: model.ApiPordDeliveryEndDay, pordCurrencyUnitId: model.ApiPordCurrencyUnitId, pordLinkAccPreOrderId: model.ApiPordLinkAccPreOrderId, pordLinkAccPreOrderNumber: model.ApiPordLinkAccPreOrderNumber, pordLinkAccPreOrderIdStr: model.ApiPordLinkAccPreOrderIdStr, pordLinkAccFirstTransferDate: model.ApiPordLinkAccFirstTransferDate, pordLinkAccLastTransferDate: model.ApiPordLinkAccLastTransferDate, pordLinkAccData: model.ApiPordLinkAccData, centerId: model.CenterId, centerCode: model.CenterCode);
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
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
				string text11 = "";
				string text12 = objectParameter.Value.ToString();
				if (text12.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordVerifierId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerifierId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordVerifierRequestId||", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerifierRequestId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordStatusId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordStatusId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordGuarantyId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordGuarantyId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordPayConditionId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordPayConditionId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordDeliveryTimeId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordDeliveryTimeId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordCreditDurationId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordCreditDurationId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordPrintFormatId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordPrintFormatId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordRLogoId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordRLogoId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordLLogoId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordLLogoId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordSignatureId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordSignatureId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordReferUserId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordReferUserId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PreOrderOprId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrderOprId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PordVerificationWorkFlowId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordVerificationWorkFlowId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordCompany", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordCompanyPerson", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordProject", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No pordCurrencyUnitId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CurrencyUnit", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("IsFixed|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + MyResource.GetResourceString("ErrorPordIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("DupPordNumber=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text12.Split(new char[1] { '=' });
					string text13 = "";
					if (array != null && array.Length == 2)
					{
						text13 = array[1] ?? "";
					}
					text13 = ((!string.IsNullOrEmpty(text13)) ? text13.TrimEnd(new char[1] { '|' }) : "");
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorPreOrderNumberIsRepeated", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text13) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text11 += resourceString3;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text12));
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
			string text14 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text14 = text14 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text14)) ? (" (" + text14 + ")") : "");
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
	public ServiceResult<List<ApispSelectPreOrder_Result>> Select(SelectPreOrderViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectPreOrder_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectPreOrder_Result>>
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
				return new ServiceResult<List<ApispSelectPreOrder_Result>>
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
				ServiceResult<List<ApispSelectPreOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectPreOrder_Result>>();
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
				if (!string.IsNullOrEmpty(model.FromPordDate))
				{
					model.FromPordDate = model.FromPordDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value5 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.FromPordDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.FromPordDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi = PersianDate.GetShamsi2Miladi(model.FromPordDate);
						value5 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<List<ApispSelectPreOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectPreOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectPreOrder_Result>> result3 = serviceResult;
				cRMEntities?.Dispose();
				return result3;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ToPordDate))
				{
					model.ToPordDate = model.ToPordDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value6 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.ToPordDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.ToPordDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi2 = PersianDate.GetShamsi2Miladi(model.ToPordDate);
						value6 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi2) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<List<ApispSelectPreOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectPreOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectPreOrder_Result>> result4 = serviceResult;
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
				ServiceResult<List<ApispSelectPreOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectPreOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectPreOrder_Result>> result5 = serviceResult;
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
				ServiceResult<List<ApispSelectPreOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectPreOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectPreOrder_Result>> result6 = serviceResult;
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
				ServiceResult<List<ApispSelectPreOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectPreOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectPreOrder_Result>> result7 = serviceResult;
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
				ServiceResult<List<ApispSelectPreOrder_Result>> serviceResult = new ServiceResult<List<ApispSelectPreOrder_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectPreOrder_Result>> result8 = serviceResult;
				cRMEntities?.Dispose();
				return result8;
			}
			model.PageSize = ((model.PageNumber.HasValue && model.PageNumber > 0 && (!model.PageSize.HasValue || model.PageSize == 0)) ? new int?(20) : model.PageSize);
			List<ApispSelectPreOrder_Result> list2 = Enumerable.ToList<ApispSelectPreOrder_Result>((IEnumerable<ApispSelectPreOrder_Result>)cRMEntities.ApispSelectPreOrder(model.ApiPreOrderId, model.ApiPordNumber, fromRegisterDate: (!string.IsNullOrEmpty(model.FromRegisterDate)) ? new DateTime?(value) : null, toRegisterDate: (!string.IsNullOrEmpty(model.ToRegisterDate)) ? new DateTime?(value2) : null, fromFirstRegisterDate: (!string.IsNullOrEmpty(model.FromFirstRegisterDate)) ? new DateTime?(value3) : null, toFirstRegisterDate: (!string.IsNullOrEmpty(model.ToFirstRegisterDate)) ? new DateTime?(value4) : null, fromPreOrderDate: (!string.IsNullOrEmpty(model.FromPordDate)) ? new DateTime?(value5) : null, toPreOrderDate: (!string.IsNullOrEmpty(model.ToPordDate)) ? new DateTime?(value6) : null, languageID: currLangId, defaultLanguageID: result, centerId: model.CenterId, centerCode: model.CenterCode, pageNumber: model.PageNumber, pageSize: model.PageSize));
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
		return new ServiceResult<List<ApispSelectPreOrder_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeletePreOrderViewModel model)
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
			if (model.ApiPreOrderId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeletePreOrder(model.ApiPreOrderId));
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
						message = MyResource.GetResourceString("ErrorPordIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
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
	public ServiceResult<bool> Verify(VerifyPreOrderViewModel model)
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
			if (model.ApiPreOrderId > 0)
			{
				cRMEntities.ApispPreOrderVerify(model.ApiPreOrderId, model.ApiVerifierUserId, model.ApiVerifyDate, text);
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
	public ServiceResult<bool> ExitVerify(ExitVerifyPreOrderViewModel model)
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
			if (model.ApiPreOrderId > 0)
			{
				cRMEntities.ApispPreOrderVerifyExit(model.ApiPreOrderId);
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
	public ServiceResult<int> UpdatePreOrderItem(UpdatePreOrderItemsViewModel model)
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
			if (model.ApiPreOrderItemId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			string text = null;
			if (!string.IsNullOrEmpty(model.ApiPordIValidityExpireDatePersian) && model.ApiPordIValidityExpireDatePersian.ToLower() == "null")
			{
				text = model.ApiPordIValidityExpireDatePersian;
				model.ApiPordIValidityExpireDate = null;
			}
			else
			{
				try
				{
					if (model.ApiPordIValidityExpireDate.HasValue)
					{
						string s = (model.ApiPordIValidityExpireDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + ((text != "null" && !string.IsNullOrEmpty(text)) ? text : DateTime.Now.ToString("HH:mm:ss"));
						model.ApiPordIValidityExpireDate = DateTime.Parse(s, new CultureInfo("en-US"));
						text = (model.ApiPordIValidityExpireDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordIValidityExpireDatePersian", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			string text2 = null;
			if (!string.IsNullOrEmpty(model.ApiPordIDeliveryDatePersian) && model.ApiPordIDeliveryDatePersian.ToLower() == "null")
			{
				text2 = model.ApiPordIDeliveryDatePersian;
				model.ApiPordIDeliveryDatePersian = null;
			}
			else
			{
				try
				{
					if (model.ApiPordIDeliveryDate.HasValue)
					{
						string s2 = (model.ApiPordIDeliveryDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + ((text2 != "null" && !string.IsNullOrEmpty(text2)) ? text2 : DateTime.Now.ToString("HH:mm:ss"));
						model.ApiPordIDeliveryDate = DateTime.Parse(s2, new CultureInfo("en-US"));
						text2 = (model.ApiPordIDeliveryDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordIDeliveryDatePersian", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			string text3 = null;
			if (!string.IsNullOrEmpty(model.ApiPordIDeliveryEndDatePersian) && model.ApiPordIDeliveryEndDatePersian.ToLower() == "null")
			{
				text3 = model.ApiPordIDeliveryEndDatePersian;
				model.ApiPordIDeliveryEndDatePersian = null;
			}
			else
			{
				try
				{
					if (model.ApiPordIDeliveryEndDate.HasValue)
					{
						string s3 = (model.ApiPordIDeliveryEndDate ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + ((text3 != "null" && !string.IsNullOrEmpty(text3)) ? text3 : DateTime.Now.ToString("HH:mm:ss"));
						model.ApiPordIDeliveryEndDate = DateTime.Parse(s3, new CultureInfo("en-US"));
						text3 = (model.ApiPordIDeliveryEndDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordIDeliveryEndDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text4 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text5 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num2 = cRMEntities.ApispUpdatePreOrderItems(model.ApiPreOrderItemId, model.ApiPreOrderId, model.ApiPordIPrdId, model.ApiPordIQuantity, model.ApiPordIPrice, model.ApiPordITotalPrice, model.ApiPordIDescription, pordIQuantityDesc: model.ApiPordIQuantityDesc, pordIDiscount: model.ApiPordIDiscount, pordIDiscountI: model.ApiPordIDiscountI, pordIDiscountPercent: model.ApiPordIDiscountPercent, pordIDiscountIPercent: model.ApiPordIDiscountIPercent, pordIPrdUnitId: model.ApiPordIPrdUnitId, pordICurrencyUnitId: model.ApiPordICurrencyUnitId, pordIOrderView: model.ApiPordIOrderView, pordIFCR: model.ApiPordIFCR, pordITax: model.ApiPordITax, pordITaxIndex: model.ApiPordITaxIndex, pordICalculateTax: model.ApiPordICalculateTax, pordINotVisible: model.ApiPordINotVisible, pordIFCRI: model.ApiPordIFCRI, pordINotInSum: model.ApiPordINotInSum, pordIWHId: model.ApiPordIWHId, pordIRound: model.ApiPordIRound, pordIRoundPlus: model.ApiPordIRoundPlus, pordIPrdPriceGroupID: model.ApiPordIPrdPriceGroupId, pordITracing: model.ApiPordITracing, fPId: 1, userId: userId, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: currLangId, defaultLanguageID: result, errorMessage: objectParameter, pordIValidityExpireDate: model.ApiPordIValidityExpireDate, pordIValidityExpireDatePersian: text, pordIDeliveryTermId: model.ApiPordIDeliveryTermId, pordIDeliveryDate: model.ApiPordIDeliveryDate, pordIDeliveryDatePersian: text2, pordIDeliveryTime: model.ApiPordIDeliveryTime, pordIDeliveryDay: model.ApiPordIDeliveryDay, pordIDeliveryEndDate: model.ApiPordIDeliveryEndDate, pordIDeliveryEndDatePersian: text3, pordIDeliveryEndTime: model.ApiPordIDeliveryEndTime, pordIDeliveryEndDay: model.ApiPordIDeliveryEndDay, pordILinkAccItemId: model.ApiPordILinkAccItemId, pordILinkAccItemIdStr: model.ApiPordILinkAccItemIdStr, pordILinkAccWHIdStr: model.ApiPordILinkAccWHIdStr, pordILinkAccFirstTransferDate: model.ApiPordILinkAccFirstTransferDate, pordILinkAccLastTransferDate: model.ApiPordILinkAccLastTransferDate, pordILinkAccData: model.ApiPordILinkAccData, pordIPriceSum: model.ApiPordIPriceSum, pordIDiscountSum: model.ApiPordIDiscountSum, pordITaxSum: model.ApiPordITaxSum);
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
				string text6 = "";
				string text7 = objectParameter.Value.ToString();
				if (text7.IndexOf("No PordId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
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
				if (text7.IndexOf("No PordIPrdUnitId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordIPrdUnitId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordICurrencyUnitId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordICurrencyUnitId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordIWHId|", StringComparison.Ordinal) >= 0)
				{
					text6 = text6 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Warehouse", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text6.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text7.IndexOf("No PordIPrdPriceGroupId|", StringComparison.Ordinal) >= 0)
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
					text6 = text6 + MyResource.GetResourceString("ErrorPordIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + resourceString2;
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
	public ServiceResult<List<ApispSelectPreOrderItems_Result>> SelectPreOrderItems(SelectPreOrderItemsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectPreOrderItems_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectPreOrderItems_Result>>
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
				return new ServiceResult<List<ApispSelectPreOrderItems_Result>>
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
				ServiceResult<List<ApispSelectPreOrderItems_Result>> serviceResult = new ServiceResult<List<ApispSelectPreOrderItems_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectPreOrderItems_Result> list2 = Enumerable.ToList<ApispSelectPreOrderItems_Result>((IEnumerable<ApispSelectPreOrderItems_Result>)cRMEntities.ApispSelectPreOrderItems(model.ApiPreOrderItemId, model.ApiPreOrderId, currLangId, result));
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
		return new ServiceResult<List<ApispSelectPreOrderItems_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeletePreOrderItems(DeletePreOrderItemsViewModel model)
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
			if (model.ApiPreOrderItemId > 0)
			{
				short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeletePreOrderItems(model.ApiPreOrderItemId, value, currLangId, result));
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
						message = MyResource.GetResourceString("ErrorPordIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
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
	public ServiceResult<int> UpdatePreOrderPayment(UpdatePreOrderPaymentsViewModel model)
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
			if (model.ApiPreOrderPaymentId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			string text = null;
			if (!string.IsNullOrEmpty(model.ApiPordPayDocDate) && model.ApiPordPayDocDate.ToLower() == "null")
			{
				text = model.ApiPordPayDocDate;
				model.ApiPordPayDocDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiPordPayDocDateTime.HasValue)
					{
						text = (model.ApiPordPayDocDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordPayDocDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
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
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text3 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text4 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			CRMEntities cRMEntities2 = cRMEntities;
			int? preOrderPaymentId = model.ApiPreOrderPaymentId;
			int? apiPreOrderId = model.ApiPreOrderId;
			string importDate = text2;
			DateTime? apiImportDateTime = model.ApiImportDateTime;
			int? apiPordPayTypeId = model.ApiPordPayTypeId;
			int? pordpayPreOrderId = apiPreOrderId;
			int? apiPordPayDocId = model.ApiPordPayDocId;
			int? apiPordPayDocTypeId = model.ApiPordPayDocTypeId;
			decimal? apiPordPayAmount = model.ApiPordPayAmount;
			string apiPordPayDocNumber = model.ApiPordPayDocNumber;
			string pordpayDocDate = text;
			DateTime? apiPordPayDocDateTime = model.ApiPordPayDocDateTime;
			string apiPordPayDescription = model.ApiPordPayDescription;
			int num2 = cRMEntities2.ApispUpdatePreOrderPayments(pordpayDocAmount: model.ApiPordPayDocAmount, pordpayDescription: apiPordPayDescription, pordpayDocDateTime: apiPordPayDocDateTime, userId: userId, preOrderPaymentId: preOrderPaymentId, importDate: importDate, importDateTime: apiImportDateTime, pordpayTypeId: apiPordPayTypeId, pordpayPreOrderId: pordpayPreOrderId, pordpayDocId: apiPordPayDocId, pordpayDocTypeId: apiPordPayDocTypeId, pordpayAmount: apiPordPayAmount, pordpayDocNumber: apiPordPayDocNumber, pordpayDocDate: pordpayDocDate, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: currLangId, defaultLanguageID: result, errorMessage: objectParameter, pordpayLinkAccHeaderId: model.ApiPordpayLinkAccHeaderId, pordpayLinkAccHeaderNumber: model.ApiPordpayLinkAccHeaderNumber, pordpayLinkAccDetailId: model.ApiPordpayLinkAccDetailId, pordpayLinkAccVoucherId: model.ApiPordpayLinkAccVoucherId, pordpayLinkAccVoucherNumber: model.ApiPordpayLinkAccVoucherNumber, pordpayLinkAccHeaderIdStr: model.ApiPordpayLinkAccHeaderIdStr, pordpayLinkAccDetailIdStr: model.ApiPordpayLinkAccDetailIdStr, pordpayLinkAccVoucherIdStr: model.ApiPordpayLinkAccVoucherIdStr, pordpayLinkAccPayType: model.ApiPordpayLinkAccPayType, pordpayLinkAccFirstTransferDate: model.ApiPordpayLinkAccFirstTransferDate, pordpayLinkAccLastTransferDate: model.ApiPordpayLinkAccLastTransferDate, pordpayLinkAccData: model.ApiPordpayLinkAccData, pordpayBankingBankID: model.ApiPordpayBankingBankID, pordpayBankingBranchID: model.ApiPordpayBankingBranchID, pordpayBankingAccountID: model.ApiPordpayBankingAccountID, pordpayCashId: model.ApiPordpayCashId, pordpayGroupIdI: model.ApiPordpayGroupIdI, pordpayGroupIdII: model.ApiPordpayGroupIdII, pordpayChqSayadNumber: model.ApiPordpayChqSayadNumber, pordpayChqSerialNumber: model.ApiPordpayChqSerialNumber, pordpayDocDayTemp: model.ApiPordpayDocDayTemp, pordpayBankName: model.ApiPordpayBankName, pordpayBranchName: model.ApiPordpayBranchName, pordpayBranchCode: model.ApiPordpayBranchCode);
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
				if (text6.IndexOf("No PordId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PordpayTypeId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayTypeId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("IsFixed|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + MyResource.GetResourceString("ErrorPordIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PordpayBankingBankID|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayBankingBankID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PordpayBankingBranchID|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayBankingBranchID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PordpayBankingAccountID|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayBankingAccountID", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PordpayCashId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayCashId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PordpayGroupIId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayGroupIId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PordpayGroupIIId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PordpayGroupIIId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text5 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text6));
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
	public ServiceResult<List<ApispSelectPreOrderPayments_Result>> SelectPreOrderPayments(SelectPreOrderPaymentsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectPreOrderPayments_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectPreOrderPayments_Result>>
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
				return new ServiceResult<List<ApispSelectPreOrderPayments_Result>>
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
				ServiceResult<List<ApispSelectPreOrderPayments_Result>> serviceResult = new ServiceResult<List<ApispSelectPreOrderPayments_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectPreOrderPayments_Result> list2 = Enumerable.ToList<ApispSelectPreOrderPayments_Result>((IEnumerable<ApispSelectPreOrderPayments_Result>)cRMEntities.ApispSelectPreOrderPayments(model.ApiPreOrderPaymentId, model.ApiPreOrderId, currLangId, result));
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
		return new ServiceResult<List<ApispSelectPreOrderPayments_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeletePreOrderPayments(DeletePreOrderPaymentsViewModel model)
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
			if (model.ApiPreOrderPaymentId > 0)
			{
				short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeletePreOrderPayments(model.ApiPreOrderPaymentId, value, currLangId, result));
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
	public ServiceResult<string> ActivePreOrder(PreOrderVerificationViewModel model)
	{
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		string text2 = "fa-IR";
		if (!CRMIdealApi.Classes.Helper.User.IsUserAccess("frmPreOrder", "actVerifyPreOrder", model.UserId))
		{
			return new ServiceResult<string>
			{
				Message = RS.Get("DoNotHaveAccess", text2, RS.TypeMsg),
				Data = "",
				Status = ServiceResultStatus.Fail
			};
		}
		decimal num = default(decimal);
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
			int.TryParse(model.UserId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
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
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num2.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = RS.Get("ErrorUsernamePasswordIncorrect", text2, RS.TypeMsg) + "\r\n" + RS.Get("ErrorTryAgain", text2, RS.TypeMsg),
					Data = "",
					Status = ServiceResultStatus.Error
				};
			}
			ApispSelectPreOrderWithId_Result apispSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<ApispSelectPreOrderWithId_Result>((IEnumerable<ApispSelectPreOrderWithId_Result>)cRMEntities.ApispSelectPreOrderWithId(model.ApiPreOrderId, currLangId, result));
			ApispReturnPreOrderSumFooter_Result apispReturnPreOrderSumFooter_Result;
			decimal obj;
			if (apispSelectPreOrderWithId_Result != null)
			{
				if (CRMIdealApi.Classes.Helper.User.IsUserAccess("frmPreOrder", "actMustPrdGroupSame", model.UserId))
				{
					List<ApispCheckPrdGroupSameInPreOrder_Result> list2 = Enumerable.ToList<ApispCheckPrdGroupSameInPreOrder_Result>((IEnumerable<ApispCheckPrdGroupSameInPreOrder_Result>)cRMEntities.ApispCheckPrdGroupSameInPreOrder(apispSelectPreOrderWithId_Result.PreOrderID, currLangId, result));
					if (list2 != null && Enumerable.Any<ApispCheckPrdGroupSameInPreOrder_Result>((IEnumerable<ApispCheckPrdGroupSameInPreOrder_Result>)list2))
					{
						return new ServiceResult<string>
						{
							Message = RS.Get("msgErrorNotVerifiedPordNoPrdGroupSame", text2, RS.TypeMsg),
							Data = "",
							Status = ServiceResultStatus.Fail
						};
					}
				}
				ApispReturnRollDiscountLimitation_Result apispReturnRollDiscountLimitation_Result = Enumerable.FirstOrDefault<ApispReturnRollDiscountLimitation_Result>((IEnumerable<ApispReturnRollDiscountLimitation_Result>)Enumerable.ToList<ApispReturnRollDiscountLimitation_Result>((IEnumerable<ApispReturnRollDiscountLimitation_Result>)cRMEntities.ApispReturnRollDiscountLimitation(model.ApiRollId)));
				if (apispReturnRollDiscountLimitation_Result != null)
				{
					if (apispReturnRollDiscountLimitation_Result.LimitPreOrderDiscountActive.HasValue && apispReturnRollDiscountLimitation_Result.LimitPreOrderDiscountActive.GetValueOrDefault())
					{
						num = apispReturnRollDiscountLimitation_Result.LimitPreOrderDiscountPercent.GetValueOrDefault();
					}
					if (num > 0m)
					{
						apispReturnPreOrderSumFooter_Result = Enumerable.FirstOrDefault<ApispReturnPreOrderSumFooter_Result>((IEnumerable<ApispReturnPreOrderSumFooter_Result>)Enumerable.ToList<ApispReturnPreOrderSumFooter_Result>((IEnumerable<ApispReturnPreOrderSumFooter_Result>)cRMEntities.ApispReturnPreOrderSumFooter(model.ApiPreOrderId)));
						if (apispReturnPreOrderSumFooter_Result != null)
						{
							if (apispReturnPreOrderSumFooter_Result.TotalPriceSumWithoutDiscount.HasValue)
							{
								decimal? totalPriceSumWithoutDiscount = apispReturnPreOrderSumFooter_Result.TotalPriceSumWithoutDiscount;
								if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
								{
									obj = Convert.ToDecimal(apispReturnPreOrderSumFooter_Result.TotalDiscountSum * (decimal?)100) / Convert.ToDecimal(apispReturnPreOrderSumFooter_Result.TotalPriceSumWithoutDiscount);
									goto IL_0484;
								}
							}
							obj = 0m;
							goto IL_0484;
						}
					}
					goto IL_0655;
				}
				text = RS.Get("ErrorNotFoundSetting", text2, RS.TypeMsg);
				return new ServiceResult<string>
				{
					Message = text,
					Data = "",
					Status = ServiceResultStatus.Fail
				};
			}
			text = RS.Get("ErrorNotFound", text2, RS.TypeMsg);
			serviceResultStatus = ServiceResultStatus.Fail;
			goto end_IL_0067;
			IL_05f8:
			decimal obj2;
			decimal num3 = (decimal)obj2;
			if (num3 > num)
			{
				return new ServiceResult<string>
				{
					Message = RS.Get("MaxDiscountPercentPreOrderInActivePreOrder", text2, RS.TypeMsg) + " " + num,
					Data = "",
					Status = ServiceResultStatus.Fail
				};
			}
			goto IL_0655;
			IL_0655:
			cRMEntities.ApispPreOrderVerify(model.ApiPreOrderId, model.UserId, DateTime.Now, text2);
			string text3 = "";
			ApispSelectUsersById_Result apispSelectUsersById_Result = Enumerable.FirstOrDefault<ApispSelectUsersById_Result>((IEnumerable<ApispSelectUsersById_Result>)cRMEntities.ApispSelectUsersById(model.UserId, model.LanguageId, result));
			if (apispSelectUsersById_Result != null)
			{
				text3 = apispSelectUsersById_Result.FullName;
			}
			text = "1|" + model.UserId + "|" + text3 + " (" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
			serviceResultStatus = ServiceResultStatus.Success;
			goto end_IL_0067;
			IL_0484:
			num3 = obj;
			if (apispReturnPreOrderSumFooter_Result.SumPriceAmount.HasValue)
			{
				decimal? totalPriceSumWithoutDiscount = apispReturnPreOrderSumFooter_Result.SumPriceAmount;
				if (!((totalPriceSumWithoutDiscount.GetValueOrDefault() == default(decimal)) & totalPriceSumWithoutDiscount.HasValue))
				{
					if (num3 > num)
					{
						return new ServiceResult<string>
						{
							Message = RS.Get("MaxDiscountPercentInActivePreOrder", text2, RS.TypeMsg) + " " + num,
							Data = "",
							Status = ServiceResultStatus.Fail
						};
					}
					if (apispReturnPreOrderSumFooter_Result.SumPriceAmount.HasValue)
					{
						totalPriceSumWithoutDiscount = apispReturnPreOrderSumFooter_Result.SumPriceAmount;
						if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
						{
							obj2 = Convert.ToDecimal(apispSelectPreOrderWithId_Result.pordDiscount * (decimal?)100) / Convert.ToDecimal(apispReturnPreOrderSumFooter_Result.SumPriceAmount);
							goto IL_05f8;
						}
					}
					obj2 = 0m;
					goto IL_05f8;
				}
			}
			return new ServiceResult<string>
			{
				Message = RS.Get("msgErrorDivisionByZero", text2, RS.TypeMsg),
				Data = "",
				Status = ServiceResultStatus.Fail
			};
			end_IL_0067:;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = RS.Get("frmErrorMessage", text2, RS.TypeMsg);
			serviceResultStatus = ServiceResultStatus.Fail;
		}
		return new ServiceResult<string>
		{
			Message = text,
			Data = "",
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public ServiceResult<string> DeactivePreOrder(ExitVerifyPreOrderViewModel model)
	{
		string text = "";
		string rsCollation = "fa-IR";
		if (!VersionBuyer.CRMApi)
		{
			return new ServiceResult<string>
			{
				Message = RS.Get("ErrorAccessAPILimited", rsCollation, RS.TypeMsg),
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
				Message = RS.Get("ErrorInReadingSysSetting", rsCollation, RS.TypeMsg),
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
		if (!CRMIdealApi.Classes.Helper.User.IsUserAccess("frmPreOrder", "actExitFromIsFix", model.UserId))
		{
			return new ServiceResult<string>
			{
				Message = RS.Get("DoNotHaveAccess", rsCollation, RS.TypeMsg),
				Data = "",
				Status = ServiceResultStatus.Fail
			};
		}
		try
		{
			cRMEntities.ApispPreOrderVerifyExit(model.ApiPreOrderId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = RS.Get("frmErrorMessage", rsCollation, RS.TypeMsg);
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
		return apiVerificationRequestController.VerificationRequestVerify(model, "PORD", 10);
	}

	public ServiceResult<SelectPreOrderWithPrdTracingResultViewModel> SelectPreOrderWithPrdTracing(SelectPreOrderWithPrdTracingViewModel model)
	{
		CRMEntities cRMEntities = null;
		SelectPreOrderWithPrdTracingResultViewModel selectPreOrderWithPrdTracingResultViewModel = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<SelectPreOrderWithPrdTracingResultViewModel>
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
				return new ServiceResult<SelectPreOrderWithPrdTracingResultViewModel>
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
				ServiceResult<SelectPreOrderWithPrdTracingResultViewModel> serviceResult = new ServiceResult<SelectPreOrderWithPrdTracingResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrWhiteSpace(model.ApiTracing))
			{
				return new ServiceResult<SelectPreOrderWithPrdTracingResultViewModel>
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
					return new ServiceResult<SelectPreOrderWithPrdTracingResultViewModel>
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
					return new ServiceResult<SelectPreOrderWithPrdTracingResultViewModel>
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
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("TotalPages", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("TotalRows", 0);
			ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
			List<ApispSelectPreOrderWithPrdTracing_Result> apiPreOrdersList = Enumerable.ToList<ApispSelectPreOrderWithPrdTracing_Result>((IEnumerable<ApispSelectPreOrderWithPrdTracing_Result>)cRMEntities.ApispSelectPreOrderWithPrdTracing(model.ApiTracing, fromDate, toDate, model.CenterId, model.CenterCode, model.ApiPageSize, model.ApiPageNumber, objectParameter, objectParameter2, currLangId, result, objectParameter3));
			string @string = Messages.ResourceManager.GetString("ErrorDoneOperationTryAgain", new CultureInfo(currLangId));
			string string2 = Messages.ResourceManager.GetString("ErrorTryAgain", new CultureInfo(currLangId));
			if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
			{
				string text4 = "";
				string text5 = objectParameter3.Value.ToString();
				if (text5.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + string2;
					return new ServiceResult<SelectPreOrderWithPrdTracingResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				status = ServiceResultStatus.Success;
				selectPreOrderWithPrdTracingResultViewModel = new SelectPreOrderWithPrdTracingResultViewModel();
				selectPreOrderWithPrdTracingResultViewModel.ApiTotalPages = int.Parse(objectParameter.Value.ToString());
				selectPreOrderWithPrdTracingResultViewModel.ApiTotalRows = int.Parse(objectParameter2.Value.ToString());
				selectPreOrderWithPrdTracingResultViewModel.ApiPageNumber = model.ApiPageNumber;
				selectPreOrderWithPrdTracingResultViewModel.ApiPageSize = model.ApiPageSize;
				selectPreOrderWithPrdTracingResultViewModel.ApiPreOrdersList = apiPreOrdersList;
			}
		}
		catch (Exception ex)
		{
			string text6 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text6 = text6 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text6)) ? (" (" + text6 + ")") : "");
			selectPreOrderWithPrdTracingResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<SelectPreOrderWithPrdTracingResultViewModel>
		{
			Message = message,
			Data = selectPreOrderWithPrdTracingResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> InsertPreOrderCommission(InsertPreOrderCommissionViewModel model)
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
			if (model.ApiPreOrderId <= 0)
			{
				model.ApiPreOrderId = null;
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
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
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
						text2 = (model.ApiCommDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
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
					text3 = (model.ApiCommEffectiveDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
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
					text4 = (model.ApiCommVerifiedDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
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
					text5 = (model.ApiCommIsPaidDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
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
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text6 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text7 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedPreOrderCommissionId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			int num2 = cRMEntities.ApispInsertPreOrderCommissions(model.ApiPreOrderId, model.ApiPordNumber, model.ApiCommDate, text2, model.ApiCommUserId, model.ApiCommBaseAmountDec, model.ApiCommBaseAmountDecDesc, model.ApiCommBaseAmount, model.ApiCommRate, model.ApiCommRateDesc, model.ApiCommAmount, commEffectiveDateTime: model.ApiCommEffectiveDate, commEffectiveDatePersian: text3, commPayTypeId: model.ApiCommPayTypeId, commStatusId: model.ApiCommStatusId, commDesc: model.ApiCommDesc, commIsVerified: model.ApiCommIsVerified, commVerifierUserId: model.ApiCommVerifierUserId, commVerifiedDateTime: model.ApiCommVerifiedDate, commVerifiedDatePersian: text4, commIsPaid: model.ApiCommIsPaid, commIsPaidUserId: model.ApiCommIsPaidUserId, commIsPaidDateTime: model.ApiCommIsPaidDate, commIsPaidDatePersian: text5, commIsPaidPayRollUserCycleId: model.ApiCommIsPaidPayRollUserCycleId, commAmountCurrUnId: model.ApiCommAmountCurrUnId, commAmountCurrencyRate: model.ApiCommAmountCurrencyRate, userId: userId, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: result, insertedPreOrderCommissionId: objectParameter, errorMessage: objectParameter2);
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
				string text8 = "";
				string text9 = objectParameter2.Value.ToString();
				if (text9.IndexOf("No OrdId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text8))
					{
						text8 += "\r\n";
					}
					text8 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text9.IndexOf("No CommTypeId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text8))
					{
						text8 += "\r\n";
					}
					text8 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text9.IndexOf("No CommKindId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text8))
					{
						text8 += "\r\n";
					}
					text8 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommKind", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text9.IndexOf("No CommUserId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text8))
					{
						text8 += "\r\n";
					}
					text8 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text9.IndexOf("No VerifierId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text8))
					{
						text8 += "\r\n";
					}
					text8 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommVerifierUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text9.IndexOf("No CommPayTypeId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text8))
					{
						text8 += "\r\n";
					}
					text8 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommPayType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text9.IndexOf("No PaidUserId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text8))
					{
						text8 += "\r\n";
					}
					text8 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommIsPaidUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text9.IndexOf("No CurrUnId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text8))
					{
						text8 += "\r\n";
					}
					text8 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommAmountCurrUn", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text9.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text8))
					{
						text8 += "\r\n";
					}
					text8 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommTypeCmp", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text9.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text8))
					{
						text8 += "\r\n";
					}
					text8 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommTypePrs", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text9.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text8 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text9));
				}
				if (!string.IsNullOrWhiteSpace(text8))
				{
					if (text8.IndexOf(resourceString2, StringComparison.Ordinal) < 0)
					{
						text8 = text8 + "\r\n" + resourceString2;
					}
					return new ServiceResult<int>
					{
						Message = text8.Replace("<br>", "\r\n"),
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
	public ServiceResult<int> UpdatePreOrderCommission(UpdatePreOrderCommissionViewModel model)
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
			if (model.ApiPreOrderCommissionId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			string text = null;
			if (!string.IsNullOrWhiteSpace(model.ApiCommDatePersian) && model.ApiCommDatePersian.ToLower() == "null")
			{
				text = model.ApiCommDatePersian;
				model.ApiCommDate = null;
			}
			else
			{
				try
				{
					if (model.ApiCommDate.HasValue)
					{
						text = (model.ApiCommDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
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
			string text2 = null;
			if (!string.IsNullOrWhiteSpace(model.ApiCommEffectiveDatePersian) && model.ApiCommEffectiveDatePersian.ToLower() == "null")
			{
				text2 = model.ApiCommEffectiveDatePersian;
				model.ApiCommEffectiveDate = null;
			}
			else
			{
				try
				{
					if (model.ApiCommEffectiveDate.HasValue)
					{
						text2 = (model.ApiCommEffectiveDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
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
			string text3 = null;
			if (!string.IsNullOrWhiteSpace(model.ApiCommVerifiedDatePersian) && model.ApiCommVerifiedDatePersian.ToLower() == "null")
			{
				text3 = model.ApiCommVerifiedDatePersian;
				model.ApiCommVerifiedDate = null;
			}
			else
			{
				try
				{
					if (model.ApiCommVerifiedDate.HasValue)
					{
						text3 = (model.ApiCommVerifiedDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
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
			string text4 = null;
			if (!string.IsNullOrWhiteSpace(model.ApiCommIsPaidDatePersian) && model.ApiCommIsPaidDatePersian.ToLower() == "null")
			{
				text4 = model.ApiCommIsPaidDatePersian;
				model.ApiCommIsPaidDate = null;
			}
			else
			{
				try
				{
					if (model.ApiCommIsPaidDate.HasValue)
					{
						text4 = (model.ApiCommIsPaidDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
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
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text5 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text6 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num2 = cRMEntities.ApispUpdatePreOrderCommissions(model.ApiPreOrderCommissionId, model.ApiPreOrderId, model.ApiCommDate, text, model.ApiCommUserId, model.ApiCommBaseAmountDec, model.ApiCommBaseAmountDecDesc, model.ApiCommBaseAmount, model.ApiCommRate, model.ApiCommRateDesc, model.ApiCommAmount, commEffectiveDateTime: model.ApiCommEffectiveDate, commEffectiveDatePersian: text2, commPayTypeId: model.ApiCommPayTypeId, commStatusId: model.ApiCommStatusId, commDesc: model.ApiCommDesc, commIsVerified: model.ApiCommIsVerified, commVerifierUserId: model.ApiCommVerifierUserId, commVerifiedDateTime: model.ApiCommVerifiedDate, commVerifiedDatePersian: text3, commIsPaid: model.ApiCommIsPaid, commIsPaidUserId: model.ApiCommIsPaidUserId, commIsPaidDateTime: model.ApiCommIsPaidDate, commIsPaidDatePersian: text4, commIsPaidPayRollUserCycleId: model.ApiCommIsPaidPayRollUserCycleId, commAmountCurrUnId: model.ApiCommAmountCurrUnId, commAmountCurrencyRate: model.ApiCommAmountCurrencyRate, userId: userId, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: currLangId, defaultLanguageID: result, errorMessage: objectParameter);
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
				string text7 = "";
				string text8 = objectParameter.Value.ToString();
				if (text8.IndexOf("No OrdId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text7 += "\r\n";
					}
					text7 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PreOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text8.IndexOf("No CommTypeId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text7 += "\r\n";
					}
					text7 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text8.IndexOf("No CommKindId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text7 += "\r\n";
					}
					text7 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommKind", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text8.IndexOf("No CommUserId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text7 += "\r\n";
					}
					text7 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text8.IndexOf("No VerifierId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text7 += "\r\n";
					}
					text7 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommVerifierUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text8.IndexOf("No CommPayTypeId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text7 += "\r\n";
					}
					text7 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommPayType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text8.IndexOf("No PaidUserId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text7 += "\r\n";
					}
					text7 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommIsPaidUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text8.IndexOf("No CurrUnId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text7 += "\r\n";
					}
					text7 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommAmountCurrUn", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text8.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text7 += "\r\n";
					}
					text7 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommTypeCmp", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text8.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text7 += "\r\n";
					}
					text7 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CommTypePrs", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (text8.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text7 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text8));
				}
				if (!string.IsNullOrWhiteSpace(text7))
				{
					if (text7.IndexOf(resourceString2, StringComparison.Ordinal) < 0)
					{
						text7 = text7 + "\r\n" + resourceString2;
					}
					return new ServiceResult<int>
					{
						Message = text7.Replace("<br>", "\r\n"),
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
			string text9 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text9 = text9 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text9)) ? (" (" + text9 + ")") : "");
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
	public ServiceResult<bool> DeletePreOrderCommission(DeletePreOrderCommissionViewModel model)
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
			if (model.ApiPreOrderCommissionId > 0)
			{
				short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeletePreOrderCommission(model.ApiPreOrderCommissionId, value, currLangId, result));
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
	public ServiceResult<List<ApispSelectPreOrderCommissions_Result>> SelectPreOrderCommission(SelectPreOrderCommissionViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectPreOrderCommissions_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectPreOrderCommissions_Result>>
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
				return new ServiceResult<List<ApispSelectPreOrderCommissions_Result>>
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
				ServiceResult<List<ApispSelectPreOrderCommissions_Result>> serviceResult = new ServiceResult<List<ApispSelectPreOrderCommissions_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectPreOrderCommissions_Result> list2 = Enumerable.ToList<ApispSelectPreOrderCommissions_Result>((IEnumerable<ApispSelectPreOrderCommissions_Result>)cRMEntities.ApispSelectPreOrderCommissions(model.ApiPreOrderCommissionId, model.ApiPreOrderId, currLangId, result));
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
		return new ServiceResult<List<ApispSelectPreOrderCommissions_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<int> DistributeDiscountToPreOrder(DistributeDiscountToPreOrderViewModel model)
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
			if (model.ApiPreOrderId > 0 && !string.IsNullOrEmpty(model.ApiPreOrderItemIds) && model.ApiPreOrderItemIds != ",")
			{
				ApispSelectPreOrderWithId_Result apispSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<ApispSelectPreOrderWithId_Result>((IEnumerable<ApispSelectPreOrderWithId_Result>)cRMEntities.ApispSelectPreOrderWithId(model.ApiPreOrderId, currLangId, result));
				if (apispSelectPreOrderWithId_Result.pordIsFixed.GetValueOrDefault())
				{
					return new ServiceResult<int>
					{
						Message = Messages.msgErrorNotActivePreOrder,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				WSspSelectDiscountCodeByDisCode_Result wSspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<WSspSelectDiscountCodeByDisCode_Result>((IEnumerable<WSspSelectDiscountCodeByDisCode_Result>)cRMEntities.WSspSelectDiscountCodeByDisCode(model.ApiDisCode, currLangId, result));
				ApispCheckDiscountCodeToUse_Result apispCheckDiscountCodeToUse_Result = Enumerable.FirstOrDefault<ApispCheckDiscountCodeToUse_Result>((IEnumerable<ApispCheckDiscountCodeToUse_Result>)cRMEntities.ApispCheckDiscountCodeToUse(model.ApiDisCode, apispSelectPreOrderWithId_Result.pordCompanyId, null, model.ApiPreOrderId, model.CenterId, model.CenterCode, DateTime.Now));
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
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				int userId = model.UserId;
				string appType = CRMIdealApi.Classes.Configuration.AppType;
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				int num4 = cRMEntities.ApispDistributeDiscountToPreOrderItems(model.ApiPreOrderId, model.ApiPreOrderItemIds, wSspSelectDiscountCodeByDisCode_Result.DisAmount, wSspSelectDiscountCodeByDisCode_Result.DisAmountPercent, userId, null, value2, value, registerDatePersian, appType, objectParameter, model.ApiAddToDiscount, wSspSelectDiscountCodeByDisCode_Result.DiscountCodeId, model.CenterId);
				int num5 = int.Parse(objectParameter.Value.ToString());
				if (num5 > 0)
				{
					cRMEntities.ApispCalcAndUpdatePreOrderAmounts(model.ApiPreOrderId, value2, currLangId, result);
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
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
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
