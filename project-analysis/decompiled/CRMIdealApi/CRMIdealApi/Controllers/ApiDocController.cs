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
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;

namespace CRMIdealApi.Controllers;

public class ApiDocController : ApiController
{
	private ResourceManager RS = new ResourceManager();

	[HttpPost]
	public ServiceResult<IssueDocResultViewModel> Issue(IssueDocViewModel model)
	{
		//IL_070c: Unknown result type (might be due to invalid IL or missing references)
		//IL_093c: Unknown result type (might be due to invalid IL or missing references)
		CRMEntities cRMEntities = null;
		IssueDocResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<IssueDocResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			if (model.ApiDocOprId <= 0)
			{
				model.ApiDocOprId = null;
			}
			if (model.ApiDocNumber <= 0)
			{
				model.ApiDocNumber = null;
			}
			if (model.ApiDocSenderId <= 0)
			{
				model.ApiDocSenderId = null;
			}
			if (model.ApiDocWHId <= 0)
			{
				model.ApiDocWHId = null;
			}
			if (model.ApiDocOrderId <= 0)
			{
				model.ApiDocOrderId = null;
			}
			if (model.ApiDocBuyOrderId <= 0)
			{
				model.ApiDocBuyOrderId = null;
			}
			if (model.ApiDocWHIdI <= 0)
			{
				model.ApiDocWHIdI = null;
			}
			if (model.ApiDocDocLinkAccCodeId <= 0)
			{
				model.ApiDocDocLinkAccCodeId = null;
			}
			if (model.ApiDocDocLinkAccDocId <= 0)
			{
				model.ApiDocDocLinkAccDocId = null;
			}
			if (model.ApiDocDocLinkAccVoucherId <= 0)
			{
				model.ApiDocDocLinkAccVoucherId = null;
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
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<IssueDocResultViewModel>
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
			if (!VersionBuyer.WareHouse)
			{
				return new ServiceResult<IssueDocResultViewModel>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("Warehouse", new CultureInfo(currLangId))),
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
				ServiceResult<IssueDocResultViewModel> serviceResult = new ServiceResult<IssueDocResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string text = null;
			try
			{
				if (!model.ApiDocDateTime.HasValue)
				{
					ServiceResult<IssueDocResultViewModel> serviceResult = new ServiceResult<IssueDocResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("DocDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				text = (model.ApiDocDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<IssueDocResultViewModel> serviceResult = new ServiceResult<IssueDocResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("DocDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (string.IsNullOrEmpty(model.ApiDocItemsInJsonFormat))
				{
					ServiceResult<IssueDocResultViewModel> serviceResult = new ServiceResult<IssueDocResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				List<IssueDocItemsViewModel> list2 = new List<IssueDocItemsViewModel>();
				if (!string.IsNullOrEmpty(model.ApiDocItemsInJsonFormat))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<IssueDocItemsViewModel>>(model.ApiDocItemsInJsonFormat);
					if (Enumerable.Any<IssueDocItemsViewModel>((IEnumerable<IssueDocItemsViewModel>)list2))
					{
						foreach (IssueDocItemsViewModel item in list2)
						{
							int value = 0;
							string prdCode = "";
							if (item.PrdId.HasValue)
							{
								value = item.PrdId.GetValueOrDefault();
							}
							if (!string.IsNullOrEmpty(item.PrdCode))
							{
								prdCode = item.PrdCode;
							}
							ApispSelectProductsWithIdOrCode_Result apispSelectProductsWithIdOrCode_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithIdOrCode_Result>((IEnumerable<ApispSelectProductsWithIdOrCode_Result>)cRMEntities.ApispSelectProductsWithIdOrCode(value, prdCode, result, result));
							if (apispSelectProductsWithIdOrCode_Result == null)
							{
								string text2 = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								return new ServiceResult<IssueDocResultViewModel>
								{
									Message = text2.Replace("<br>", "\r\n"),
									Data = null,
									Status = ServiceResultStatus.Error
								};
							}
						}
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<IssueDocResultViewModel> serviceResult = new ServiceResult<IssueDocResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ApiDocItemSerialsInJsonFormat))
				{
					List<IssueDocItemSerialsViewModel> list3 = new List<IssueDocItemSerialsViewModel>();
					if (!string.IsNullOrEmpty(model.ApiDocItemSerialsInJsonFormat))
					{
						list3 = new JavaScriptSerializer().Deserialize<List<IssueDocItemSerialsViewModel>>(model.ApiDocItemSerialsInJsonFormat);
						if (Enumerable.Any<IssueDocItemSerialsViewModel>((IEnumerable<IssueDocItemSerialsViewModel>)list3))
						{
							foreach (IssueDocItemSerialsViewModel item2 in list3)
							{
								try
								{
									if (item2.ExpDate.HasValue)
									{
										string text3 = (item2.ExpDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
									}
								}
								catch (Exception e3)
								{
									ErrorSignal.FromCurrentContext().Raise(e3);
									ServiceResult<IssueDocResultViewModel> serviceResult = new ServiceResult<IssueDocResultViewModel>();
									serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("DocExpDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
									serviceResult.Data = null;
									serviceResult.Status = ServiceResultStatus.Error;
									return serviceResult;
								}
							}
						}
					}
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				ServiceResult<IssueDocResultViewModel> serviceResult = new ServiceResult<IssueDocResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Serials", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
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
			ObjectParameter objectParameter = new ObjectParameter("InsertedDocId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedDocNumber", 0);
			ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
			CRMEntities cRMEntities2 = cRMEntities;
			int? apiDocOprId = model.ApiDocOprId;
			int? apiDocNumber = model.ApiDocNumber;
			string docDate = text;
			DateTime? apiDocDateTime = model.ApiDocDateTime;
			int? apiDocSenderId = model.ApiDocSenderId;
			string apiDocSenderName = model.ApiDocSenderName;
			string apiDocFactorNumber = model.ApiDocFactorNumber;
			string apiDocDescription = model.ApiDocDescription;
			short? apiDocIsFix = model.ApiDocIsFix;
			int? apiDocWHId = model.ApiDocWHId;
			int? apiDocOrderId = model.ApiDocOrderId;
			int? apiDocBuyOrderId = model.ApiDocBuyOrderId;
			string apiDocSendAddress = model.ApiDocSendAddress;
			string apiDocDriverName = model.ApiDocDriverName;
			string apiDocDriverTel = model.ApiDocDriverTel;
			string apiDocFreightName = model.ApiDocFreightName;
			string apiDocBijakNumber = model.ApiDocBijakNumber;
			string apiDocCarNumber = model.ApiDocCarNumber;
			int? apiDocWHIdI = model.ApiDocWHIdI;
			string apiDocCmpTitle = model.ApiDocCmpTitle;
			int? apiDocDocLinkAccCodeId = model.ApiDocDocLinkAccCodeId;
			string apiDocDocLinkAccCode = model.ApiDocDocLinkAccCode;
			int? apiDocDocLinkAccDocId = model.ApiDocDocLinkAccDocId;
			string apiDocDocLinkAccDocNumber = model.ApiDocDocLinkAccDocNumber;
			int? apiDocDocLinkAccVoucherId = model.ApiDocDocLinkAccVoucherId;
			string apiDocDocLinkAccVoucherNumber = model.ApiDocDocLinkAccVoucherNumber;
			int? apiCompanyId = model.ApiCompanyId;
			int? apiCompanyNumber = model.ApiCompanyNumber;
			string apiCompanyCode = model.ApiCompanyCode;
			int? apiCompanyPersonId = model.ApiCompanyPersonId;
			int? apiProjectId = model.ApiProjectId;
			int? companyNumber = apiCompanyNumber;
			string apiProjectTitle = model.ApiProjectTitle;
			string apiDocItemsInJsonFormat = model.ApiDocItemsInJsonFormat;
			string apiDocItemSerialsInJsonFormat = model.ApiDocItemSerialsInJsonFormat;
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.ApispIssueDoc(defualtProjectTitle: resourceString, docItemsJson: apiDocItemsInJsonFormat, docItemSerialsJson: apiDocItemSerialsInJsonFormat, userId: userId, oprId: apiDocOprId, docNumber: apiDocNumber, docDate: docDate, docDateTime: apiDocDateTime, senderId: apiDocSenderId, senderName: apiDocSenderName, factorNumber: apiDocFactorNumber, description: apiDocDescription, isFix: apiDocIsFix, wHId: apiDocWHId, orderId: apiDocOrderId, buyOrderId: apiDocBuyOrderId, sendAddress: apiDocSendAddress, driverName: apiDocDriverName, driverTel: apiDocDriverTel, freightName: apiDocFreightName, bijakNumber: apiDocBijakNumber, carNumber: apiDocCarNumber, wHIdI: apiDocWHIdI, cmpTitle: apiDocCmpTitle, docLinkAccCodeId: apiDocDocLinkAccCodeId, docLinkAccCode: apiDocDocLinkAccCode, docLinkAccDocId: apiDocDocLinkAccDocId, docLinkAccDocNumber: apiDocDocLinkAccDocNumber, docLinkAccVoucherId: apiDocDocLinkAccVoucherId, docLinkAccVoucherNumber: apiDocDocLinkAccVoucherNumber, companyId: apiCompanyId, companyPersonId: apiCompanyPersonId, projectId: apiProjectId, companyNumber: companyNumber, companyCode: apiCompanyCode, projectTitle: apiProjectTitle, month1: value3, registerDate: value2, registerDatePersian: registerDatePersian, registerDay: registerDay, registerTime: registerTime, appType: appType, languageID: currLangId, defaultLanguageID: result, insertedDocId: objectParameter, insertedDocNumber: objectParameter2, errorMessage: objectParameter3, centerId: model.CenterId, centerCode: model.CenterCode, docLinkAccDocIdStr: model.ApiDocLinkAccDocIdStr, docLinkAccDocType: model.ApiDocLinkAccDocType, docLinkAccFirstTransferDate: model.ApiDocLinkAccFirstTransferDate, docLinkAccLastTransferDate: model.ApiDocLinkAccLastTransferDate, docLinkAccData: model.ApiDocLinkAccData));
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<IssueDocResultViewModel>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
			{
				string text4 = "";
				string text5 = objectParameter3.Value.ToString();
				if (text5.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No WhId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("DestinationWarehouse", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No WHIdI|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("SourceWarehouse", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No DocOprID|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("DocOprId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No OrderId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Order", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No BuyOrderId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("BuyOrder", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CompanyI", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CompanyPerson", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ProjectI", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrdUnitId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrdUnitId", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No Prd|", StringComparison.Ordinal) >= 0 || text5.IndexOf("Not Prd|", StringComparison.Ordinal) >= 0 || text5.IndexOf("No PrdId|", StringComparison.Ordinal) >= 0 || text5.IndexOf("Not Prd|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("DupDocNumber=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text5.Split(new char[1] { '=' });
					string text6 = "";
					if (array != null && array.Length == 2)
					{
						text6 = array[1] ?? "";
					}
					text6 = ((!string.IsNullOrEmpty(text6)) ? text6.TrimEnd(new char[1] { '|' }) : "");
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorNumberIsRepeated", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text6) + " " + resourceString3;
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text4 += resourceString3;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text5));
					return new ServiceResult<IssueDocResultViewModel>
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
					return new ServiceResult<IssueDocResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				IssueDocResultViewModel issueDocResultViewModel = new IssueDocResultViewModel();
				issueDocResultViewModel.ApiDocId = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				issueDocResultViewModel.ApiDocNumber = ((objectParameter2.Value != null) ? int.Parse(objectParameter2.Value.ToString() ?? "0") : 0);
				data = issueDocResultViewModel;
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
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<IssueDocResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectDoc_Result>> Select(SelectDocViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectDoc_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectDoc_Result>>
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
				return new ServiceResult<List<ApispSelectDoc_Result>>
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
				ServiceResult<List<ApispSelectDoc_Result>> serviceResult = new ServiceResult<List<ApispSelectDoc_Result>>();
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
				if (!string.IsNullOrEmpty(model.FromDocDate))
				{
					model.FromDocDate = model.FromDocDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value5 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDocDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDocDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi = PersianDate.GetShamsi2Miladi(model.FromDocDate);
						value5 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<List<ApispSelectDoc_Result>> serviceResult = new ServiceResult<List<ApispSelectDoc_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectDoc_Result>> result3 = serviceResult;
				cRMEntities?.Dispose();
				return result3;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ToDocDate))
				{
					model.ToDocDate = model.ToDocDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value6 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDocDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDocDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi2 = PersianDate.GetShamsi2Miladi(model.ToDocDate);
						value6 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi2) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<List<ApispSelectDoc_Result>> serviceResult = new ServiceResult<List<ApispSelectDoc_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectDoc_Result>> result4 = serviceResult;
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
				ServiceResult<List<ApispSelectDoc_Result>> serviceResult = new ServiceResult<List<ApispSelectDoc_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectDoc_Result>> result5 = serviceResult;
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
				ServiceResult<List<ApispSelectDoc_Result>> serviceResult = new ServiceResult<List<ApispSelectDoc_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectDoc_Result>> result6 = serviceResult;
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
				ServiceResult<List<ApispSelectDoc_Result>> serviceResult = new ServiceResult<List<ApispSelectDoc_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectDoc_Result>> result7 = serviceResult;
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
				ServiceResult<List<ApispSelectDoc_Result>> serviceResult = new ServiceResult<List<ApispSelectDoc_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectDoc_Result>> result8 = serviceResult;
				cRMEntities?.Dispose();
				return result8;
			}
			model.PageSize = ((model.PageNumber.HasValue && model.PageNumber > 0 && (!model.PageSize.HasValue || model.PageSize == 0)) ? new int?(20) : model.PageSize);
			List<ApispSelectDoc_Result> list2 = Enumerable.ToList<ApispSelectDoc_Result>((IEnumerable<ApispSelectDoc_Result>)cRMEntities.ApispSelectDoc(model.ApiDocId, model.ApiDocNumber, model.ApiDocOprId, fromRegisterDate: (!string.IsNullOrEmpty(model.FromRegisterDate)) ? new DateTime?(value) : null, toRegisterDate: (!string.IsNullOrEmpty(model.ToRegisterDate)) ? new DateTime?(value2) : null, fromFirstRegisterDate: (!string.IsNullOrEmpty(model.FromFirstRegisterDate)) ? new DateTime?(value3) : null, toFirstRegisterDate: (!string.IsNullOrEmpty(model.ToFirstRegisterDate)) ? new DateTime?(value4) : null, fromDocDate: (!string.IsNullOrEmpty(model.FromDocDate)) ? new DateTime?(value5) : null, toDocDate: (!string.IsNullOrEmpty(model.ToDocDate)) ? new DateTime?(value6) : null, languageID: currLangId, defaultLanguageID: result, centerId: model.CenterId, centerCode: model.CenterCode, pageNumber: model.PageNumber, pageSize: model.PageSize));
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
		return new ServiceResult<List<ApispSelectDoc_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteDocViewModel model)
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
			if (model.ApiDocId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteDoc(model.ApiDocId));
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
						message = MyResource.GetResourceString("ErrorDocIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
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
	public ServiceResult<bool> Verify(VerifyDocViewModel model)
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
			if (model.ApiDocId > 0)
			{
				cRMEntities.ApispDocVerify(model.ApiDocId, model.ApiVerifierUserId, model.ApiVerifyDate, text);
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
	public ServiceResult<bool> ExitVerify(ExitVerifyDocViewModel model)
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
			if (model.ApiDocId > 0)
			{
				cRMEntities.ApispDocVerifyExit(model.ApiDocId);
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
	public ServiceResult<List<ApispSelectDocItems_Result>> SelectDocItems(SelectDocItemsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectDocItems_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectDocItems_Result>>
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
				return new ServiceResult<List<ApispSelectDocItems_Result>>
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
				ServiceResult<List<ApispSelectDocItems_Result>> serviceResult = new ServiceResult<List<ApispSelectDocItems_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectDocItems_Result> list2 = Enumerable.ToList<ApispSelectDocItems_Result>((IEnumerable<ApispSelectDocItems_Result>)cRMEntities.ApispSelectDocItems(model.ApiDocItemId, model.ApiDocId, currLangId, result));
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
		return new ServiceResult<List<ApispSelectDocItems_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteDocItems(DeleteDocItemsViewModel model)
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
			if (model.ApiDocItemId > 0)
			{
				short num2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteDocItems(model.ApiDocItemId));
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
						message = MyResource.GetResourceString("ErrorDocIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
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
	public ServiceResult<List<ApispSelectDocItemSerials_Result>> SelectDocItemSerials(SelectDocItemSerialsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectDocItemSerials_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectDocItemSerials_Result>>
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
				return new ServiceResult<List<ApispSelectDocItemSerials_Result>>
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
				ServiceResult<List<ApispSelectDocItemSerials_Result>> serviceResult = new ServiceResult<List<ApispSelectDocItemSerials_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectDocItemSerials_Result> list2 = Enumerable.ToList<ApispSelectDocItemSerials_Result>((IEnumerable<ApispSelectDocItemSerials_Result>)cRMEntities.ApispSelectDocItemSerials(model.ApiDocItemSerialsId, model.ApiDocItemId, currLangId, result));
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
		return new ServiceResult<List<ApispSelectDocItemSerials_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteDocItemSerials(DeleteDocItemSerialsViewModel model)
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
			if (model.ApiDocItemSerialsId > 0)
			{
				short num2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteDocItemSerials(model.ApiDocItemSerialsId));
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
						message = MyResource.GetResourceString("ErrorDocIsFixed", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
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
	public ServiceResult<List<ApispRpt_WareHouseStock_Result>> Rpt_WareHouseStock(Rpt_WareHouseStockViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispRpt_WareHouseStock_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispRpt_WareHouseStock_Result>>
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
				return new ServiceResult<List<ApispRpt_WareHouseStock_Result>>
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
				ServiceResult<List<ApispRpt_WareHouseStock_Result>> serviceResult = new ServiceResult<List<ApispRpt_WareHouseStock_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime now2 = DateTime.Now;
			List<ApispRpt_WareHouseStock_Result> list2 = Enumerable.ToList<ApispRpt_WareHouseStock_Result>((IEnumerable<ApispRpt_WareHouseStock_Result>)cRMEntities.ApispRpt_WareHouseStock(model.ApiMode, model.ApiFPId.GetValueOrDefault(), model.ApiWHID.GetValueOrDefault(), model.ApiFGId.GetValueOrDefault(), model.ApiSGId.GetValueOrDefault(), model.ApiPrdId.GetValueOrDefault(), model.ApiMaxStkVal.GetValueOrDefault(), model.ApiMinStkVal.GetValueOrDefault(), model.ApiEqualStkVal.GetValueOrDefault(), userId, DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("dddd"), model.ApiPrdModel, currLangId, result, model.ApiTracing, model.FromRegisterDate.HasValue ? model.FromRegisterDate : null, model.ToRegisterDate.HasValue ? model.ToRegisterDate : null));
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
		return new ServiceResult<List<ApispRpt_WareHouseStock_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispRpt_WareHouseStockWithPrice_Result>> Rpt_WareHouseStockWithPrice(Rpt_WareHouseStockWithPriceViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispRpt_WareHouseStockWithPrice_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispRpt_WareHouseStockWithPrice_Result>>
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
				return new ServiceResult<List<ApispRpt_WareHouseStockWithPrice_Result>>
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
				ServiceResult<List<ApispRpt_WareHouseStockWithPrice_Result>> serviceResult = new ServiceResult<List<ApispRpt_WareHouseStockWithPrice_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime now2 = DateTime.Now;
			List<ApispRpt_WareHouseStockWithPrice_Result> list2 = Enumerable.ToList<ApispRpt_WareHouseStockWithPrice_Result>((IEnumerable<ApispRpt_WareHouseStockWithPrice_Result>)cRMEntities.ApispRpt_WareHouseStockWithPrice(model.ApiMode, model.ApiFPId.GetValueOrDefault(), model.ApiWHID.GetValueOrDefault(), model.ApiFGId.GetValueOrDefault(), model.ApiSGId.GetValueOrDefault(), model.ApiPrdId.GetValueOrDefault(), model.ApiMaxStkVal.GetValueOrDefault(), model.ApiMinStkVal.GetValueOrDefault(), model.ApiEqualStkVal.GetValueOrDefault(), userId, DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("dddd"), model.ApiPrdModel, currLangId, result, model.ApiTracing, model.FromRegisterDate.HasValue ? model.FromRegisterDate : null, model.ToRegisterDate.HasValue ? model.ToRegisterDate : null, model.ApiProductPriceGroupId));
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
		return new ServiceResult<List<ApispRpt_WareHouseStockWithPrice_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<string> SendDocVerifyRequest(VerificationRequestVerifyViewModel model)
	{
		ApiVerificationRequestController apiVerificationRequestController = new ApiVerificationRequestController();
		return apiVerificationRequestController.VerificationRequestVerify(model, "DOC", 60);
	}

	public ServiceResult<string> SendDraftVerifyRequest(VerificationRequestVerifyViewModel model)
	{
		ApiVerificationRequestController apiVerificationRequestController = new ApiVerificationRequestController();
		return apiVerificationRequestController.VerificationRequestVerify(model, "DRAFT", 60);
	}

	public ServiceResult<string> SendMovementVerifyRequest(VerificationRequestVerifyViewModel model)
	{
		ApiVerificationRequestController apiVerificationRequestController = new ApiVerificationRequestController();
		return apiVerificationRequestController.VerificationRequestVerify(model, "MOVEMENTWRHS", 60);
	}
}
