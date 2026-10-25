using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO.FTP;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Mobile.Models.ViewModel.VerificationWorkFlow;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class PreOrderController : ApiController
{
	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<PreOrderDetailViewModel> SelectPreOrderWithId(int pordId, int? ln = null, int? cId = null)
	{
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		PreOrderDetailViewModel preOrderDetailViewModel = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (!UserLogin.IsUserAccess("frmMain", "actPreOrder", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<PreOrderDetailViewModel>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, token2.userId, result, result2, cId));
					if (mobspSelectPreOrderWithID_Result != null)
					{
						preOrderDetailViewModel = new PreOrderDetailViewModel();
						preOrderDetailViewModel.PreOrder = new MobspSelectPreOrderWithID_Result();
						if (PreOrder.IsEditAfterFix(mobspSelectPreOrderWithID_Result.pordEditAfterFixInfoJs, mobspSelectPreOrderWithID_Result.PreOrderID, 1, token2.userId, result, cId))
						{
							mobspSelectPreOrderWithID_Result.pordIsFixed = false;
						}
						if (!string.IsNullOrWhiteSpace((mobspSelectPreOrderWithID_Result.pordEditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							List<EditAfterFixInfoViewModel> list = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectPreOrderWithID_Result.pordEditAfterFixInfoJs);
							if (list != null)
							{
								foreach (EditAfterFixInfoViewModel item in list)
								{
									MobspSelectUsersById_Result mobspSelectUsersById_Result = Enumerable.FirstOrDefault<MobspSelectUsersById_Result>((IEnumerable<MobspSelectUsersById_Result>)cRMEntities.MobspSelectUsersById(item.eafUserId, result, result2, cId));
									if (mobspSelectUsersById_Result != null)
									{
										item.eafUserName = mobspSelectUsersById_Result.FullName;
									}
									item.eafRequestDatePersian = item.eafRequestDate.ToString("yyyy/MM/dd HH:mm");
									item.eafEndDatePersian = item.eafEndDate?.ToString("yyyy/MM/dd HH:mm");
									item.eafDoneDatePersian = item.eafDoneDate?.ToString("yyyy/MM/dd HH:mm");
								}
								mobspSelectPreOrderWithID_Result.pordEditAfterFixInfoJs = JsonConvert.SerializeObject(list);
							}
						}
						preOrderDetailViewModel.PreOrder = mobspSelectPreOrderWithID_Result;
						preOrderDetailViewModel.PreOrderItems = new List<MobspSelectPreOrderItems_Result>();
						preOrderDetailViewModel.PreOrderItemsSpecification = new List<MobspSelectPreOrderItemSpecificationByItemId_Result>();
						preOrderDetailViewModel.PreOrderFiles = new List<MobspSelectFilesDirectory_Result>();
						List<MobspSelectPreOrderItems_Result> list2 = Enumerable.ToList<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)cRMEntities.MobspSelectPreOrderItems(pordId, result, result2));
						if (Enumerable.Any<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list2))
						{
							preOrderDetailViewModel.PreOrderItems = list2;
							foreach (MobspSelectPreOrderItems_Result item2 in list2)
							{
								List<MobspSelectPreOrderItemSpecificationByItemId_Result> list3 = Enumerable.ToList<MobspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<MobspSelectPreOrderItemSpecificationByItemId_Result>)cRMEntities.MobspSelectPreOrderItemSpecificationByItemId(item2.PreOrderItemID, result, result2));
								if (!Enumerable.Any<MobspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<MobspSelectPreOrderItemSpecificationByItemId_Result>)list3))
								{
									continue;
								}
								foreach (MobspSelectPreOrderItemSpecificationByItemId_Result item3 in list3)
								{
									preOrderDetailViewModel.PreOrderItemsSpecification.Add(item3);
								}
							}
						}
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						int num = 0;
						if (mobspSelectCrmsysSetting_Result != null)
						{
							if (mobspSelectCrmsysSetting_Result.CmpAccFromLink.HasValue)
							{
								mobspSelectCrmsysSetting_Result.CmpAccFromLink.GetValueOrDefault();
							}
							num = mobspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						mobspSelectPreOrderWithID_Result.pordLinkAccData = mobspSelectPreOrderWithID_Result.pordLinkAccData ?? "";
						if (num == 1)
						{
							List<MobspSelectLinkAccSettingDBIsActive_Result> list4 = Enumerable.ToList<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)cRMSpEntities.MobspSelectLinkAccSettingDBIsActive(num));
							List<PordLinkAccDataViewModel> list5 = new List<PordLinkAccDataViewModel>();
							if (!string.IsNullOrWhiteSpace(mobspSelectPreOrderWithID_Result.pordLinkAccData))
							{
								foreach (PordLinkAccDataViewModel item4 in new JavaScriptSerializer().Deserialize<List<PordLinkAccDataViewModel>>(mobspSelectPreOrderWithID_Result.pordLinkAccData))
								{
									int dbId = 0;
									int.TryParse(item4.DBId.ToString(), out dbId);
									if (dbId != 0 && list4 != null && Enumerable.Any<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)list4))
									{
										MobspSelectLinkAccSettingDBIsActive_Result mobspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)list4, (Func<MobspSelectLinkAccSettingDBIsActive_Result, bool>)((MobspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == dbId));
										if (mobspSelectLinkAccSettingDBIsActive_Result != null)
										{
											item4.DbName = mobspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
											item4.DbTitle = mobspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
											item4.NumberWithLbl = Labels.PordShowLinkAccPreOrderNumber + ": " + item4.Number;
											item4.IdWithLbl = Labels.PordShowLinkAccPreOrderIdStr + ": " + item4.Id;
											item4.FTDateWithLbl = Labels.lblLinkAccFirstTransferDate + ":" + (item4.FTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item4.FTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
											item4.LTDateWithLbl = Labels.lblLinkAccLastTransferDate + ":" + (item4.LTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item4.LTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
											list5.Add(item4);
										}
									}
								}
							}
							mobspSelectPreOrderWithID_Result.pordLinkAccData = "";
							if (list5 != null && Enumerable.Any<PordLinkAccDataViewModel>((IEnumerable<PordLinkAccDataViewModel>)list5))
							{
								mobspSelectPreOrderWithID_Result.pordLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<PordLinkAccDataViewModel>((IEnumerable<PordLinkAccDataViewModel>)list5));
							}
							if (mobspSelectPreOrderWithID_Result.pordLinkAccPreOrderId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectPreOrderWithID_Result.pordLinkAccPreOrderIdStr) || !string.IsNullOrWhiteSpace(mobspSelectPreOrderWithID_Result.pordLinkAccPreOrderNumber) || (!string.IsNullOrWhiteSpace(mobspSelectPreOrderWithID_Result.pordLinkAccData) && mobspSelectPreOrderWithID_Result.pordLinkAccData != "[]"))
							{
								mobspSelectPreOrderWithID_Result.IsSentToLinkAcc = true;
							}
						}
						preOrderDetailViewModel.PreOrderPayments = new List<MobspSelectPreOrderPayments_Result>();
						List<MobspSelectPreOrderPayments_Result> list6 = Enumerable.ToList<MobspSelectPreOrderPayments_Result>((IEnumerable<MobspSelectPreOrderPayments_Result>)cRMEntities.MobspSelectPreOrderPayments(pordId, result, result2));
						if (Enumerable.Any<MobspSelectPreOrderPayments_Result>((IEnumerable<MobspSelectPreOrderPayments_Result>)list6))
						{
							preOrderDetailViewModel.PreOrderPayments = list6;
						}
						List<MobspSelectFilesDirectory_Result> list7 = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory("", "", "", "10", pordId.ToString(), result, result2, false, cId));
						if (Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list7))
						{
							preOrderDetailViewModel.PreOrderFiles = list7;
						}
						preOrderDetailViewModel.SumPreOrderPay = new MobspReturnSumPreOrderPay_Result();
						MobspReturnSumPreOrderPay_Result mobspReturnSumPreOrderPay_Result = Enumerable.FirstOrDefault<MobspReturnSumPreOrderPay_Result>((IEnumerable<MobspReturnSumPreOrderPay_Result>)cRMEntities.MobspReturnSumPreOrderPay(pordId));
						if (mobspReturnSumPreOrderPay_Result != null)
						{
							preOrderDetailViewModel.SumPreOrderPay = mobspReturnSumPreOrderPay_Result;
						}
						preOrderDetailViewModel.CmpAccountingSummary = new MobspReturnCmpAccountingSummary_Result();
						MobspReturnCmpAccountingSummary_Result mobspReturnCmpAccountingSummary_Result = Enumerable.FirstOrDefault<MobspReturnCmpAccountingSummary_Result>((IEnumerable<MobspReturnCmpAccountingSummary_Result>)cRMEntities.MobspReturnCmpAccountingSummary(mobspSelectPreOrderWithID_Result.pordCompanyId));
						if (mobspReturnCmpAccountingSummary_Result != null)
						{
							preOrderDetailViewModel.CmpAccountingSummary = mobspReturnCmpAccountingSummary_Result;
						}
						preOrderDetailViewModel.PreOrderSumFooter = new MobfnReturnPreOrderSumFooter_Result();
						MobfnReturnPreOrderSumFooter_Result mobfnReturnPreOrderSumFooter_Result = Queryable.FirstOrDefault<MobfnReturnPreOrderSumFooter_Result>(cRMEntities.MobfnReturnPreOrderSumFooter(pordId));
						if (mobfnReturnPreOrderSumFooter_Result != null)
						{
							preOrderDetailViewModel.PreOrderSumFooter = mobfnReturnPreOrderSumFooter_Result;
						}
						preOrderDetailViewModel.OrderInfo = new MobspReturnOrderFromPreOrder_Result();
						preOrderDetailViewModel.OrderInfoList = new List<MobspReturnOrderFromPreOrder_Result>();
						List<MobspReturnOrderFromPreOrder_Result> list8 = Enumerable.ToList<MobspReturnOrderFromPreOrder_Result>((IEnumerable<MobspReturnOrderFromPreOrder_Result>)cRMEntities.MobspReturnOrderFromPreOrder(pordId, result, result2));
						if (list8 != null && Enumerable.Any<MobspReturnOrderFromPreOrder_Result>((IEnumerable<MobspReturnOrderFromPreOrder_Result>)list8))
						{
							preOrderDetailViewModel.OrderInfo = Enumerable.FirstOrDefault<MobspReturnOrderFromPreOrder_Result>((IEnumerable<MobspReturnOrderFromPreOrder_Result>)list8);
							preOrderDetailViewModel.OrderInfoList = list8;
						}
						decimal? num2 = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)cRMEntities.MobspReturnPreOrderINotInSumTotalPrice(pordId));
						if (num2.HasValue)
						{
							preOrderDetailViewModel.NotInSumTotalPrice = num2.GetValueOrDefault();
						}
						else
						{
							preOrderDetailViewModel.NotInSumTotalPrice = 0m;
						}
						preOrderDetailViewModel.InternalMsg = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list9 = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 5, pordId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list9))
						{
							preOrderDetailViewModel.InternalMsg = list9;
						}
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorPreOrderNotFound;
						preOrderDetailViewModel = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					preOrderDetailViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				preOrderDetailViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			preOrderDetailViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<PreOrderDetailViewModel>
		{
			Message = message,
			Data = preOrderDetailViewModel,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> PreOrderVerify(int pordId, string registerDate, string registerTime, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmPreOrder", "actVerifyPreOrder", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = pordId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (UserLogin.IsUserAccess("frmPreOrder", "actMustPrdGroupSame", UserLogin.CurrentUser, cId))
					{
						List<MobspCheckPrdGroupSameInPreOrder_Result> list = Enumerable.ToList<MobspCheckPrdGroupSameInPreOrder_Result>((IEnumerable<MobspCheckPrdGroupSameInPreOrder_Result>)cRMEntities.MobspCheckPrdGroupSameInPreOrder(pordId, result, result2));
						if (list != null && Enumerable.Any<MobspCheckPrdGroupSameInPreOrder_Result>((IEnumerable<MobspCheckPrdGroupSameInPreOrder_Result>)list))
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorNotVerifiedPordNoPrdGroupSame,
								Data = pordId,
								Status = ServiceResultStatus.Fail
							};
						}
					}
					if (pordId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorPreOrderNotFound,
							Data = pordId,
							Status = ServiceResultStatus.Error
						};
					}
					DateTime now = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(registerDate) || string.IsNullOrEmpty(registerTime))
						{
							ServiceResult<int> result3 = new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = pordId,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						registerDate = registerDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						string formatetdDate = PersianDate.GetFormatetdDate(registerDate.Replace("/", ""));
						if (result == 1065)
						{
							now = DateTime.Parse(formatetdDate + " " + registerTime, new PersianCulture());
							registerDate = now.ToString("yyyyMMdd");
						}
						else
						{
							now = DateTime.Parse(formatetdDate + " " + registerTime, new CultureInfo("en-US"));
							registerDate = now.ToString("yyyyMMdd", new PersianCulture());
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<int> result4 = new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = pordId,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					ObjectParameter objectParameter = new ObjectParameter("LimitPreOrderDiscountPercent", typeof(decimal));
					ObjectParameter objectParameter2 = new ObjectParameter("Result", 0);
					cRMEntities.MobspPreOrderVerifyWithPreChecks(pordId, token2.RollId, token2.userId, registerDate, now, objectParameter, objectParameter2);
					int num2 = 0;
					if (objectParameter2.Value != null)
					{
						num2 = (int)(objectParameter2.Value ?? ((object)0));
					}
					string arg = "";
					if (objectParameter.Value != null)
					{
						arg = ((objectParameter.Value != null) ? objectParameter.Value.ToString() : "");
					}
					switch (num2)
					{
					case 1:
					{
						short value = short.Parse(Financial.Get().Id.ToString());
						short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						DateTime now2 = DateTime.Now;
						string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
						string appType = Mobile.Classes.Configuration.AppType;
						bool? sendSMSPordFOLinkAfterVerify = SysSeting.Get().SendSMSPordFOLinkAfterVerify;
						int? sendSMSPordFOLinkAfterVerifyType = SysSeting.Get().SendSMSPordFOLinkAfterVerifyType;
						string text = "";
						string text2 = "";
						string text3 = "";
						string text4 = "";
						if (sendSMSPordFOLinkAfterVerify.GetValueOrDefault())
						{
							List<SelectListItem> pordFoShortLinks = PreOrder.GetPordFoShortLinks(pordId, cId);
							text2 = pordFoShortLinks[1].Value;
							text3 = pordFoShortLinks[2].Value;
							text4 = pordFoShortLinks[3].Value;
							if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 1)
							{
								text = text2;
							}
							else if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 2)
							{
								text = text3;
							}
							else if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 3)
							{
								text = text4;
							}
						}
						if (!string.IsNullOrWhiteSpace(text))
						{
							ObjectParameter result5 = new ObjectParameter("Result", 0);
							cRMSpEntities.MobspSendSmsPordFOLinkAfterVerify(pordId, text, text2, text3, text4, token2.userId, value, value2, registerDatePersian, appType, num, result2, result5, cId);
						}
						PreOrder.SendSmsFoSettingPordAfterVerify(pordId, cId);
						MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, token2.userId, result, result2, cId));
						int? pordCompanyId = mobspSelectPreOrderWithID_Result.pordCompanyId;
						CRMspSelectCompanyById_Result cRMspSelectCompanyById_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyById_Result>((IEnumerable<CRMspSelectCompanyById_Result>)cRMEntities.CRMspSelectCompanyById(pordCompanyId, result, result2));
						if (cRMspSelectCompanyById_Result != null && cRMspSelectCompanyById_Result.cmpCRMShopIsActive.GetValueOrDefault())
						{
							int retId = 0;
							new InternalMessage().SendInternalmsgSingle(token2.userId, 0, Labels.ShopVerifyPreOrderTitle, string.Format(Labels.ShopVerifyPreOrderMsg, mobspSelectPreOrderWithID_Result.pordNumber, now2.ToString("yyyy/MM/dd")).Replace("<br>", "\n"), 5, token2.userId, -20, now2.ToString("yyyyMMdd", new PersianCulture()), now2.ToString("HH:mm:ss"), 0, "", pordId, Messages.ConversationErjaShow, 0, out retId, result2, cId);
							if (pordCompanyId.HasValue && pordCompanyId > 0)
							{
								Dictionary<string, string> dictionary = new Dictionary<string, string>();
								dictionary.Add("Title", Labels.ShopVerifyPreOrderTitle);
								dictionary.Add("Message", string.Format(Labels.ShopVerifyPreOrderMsg, mobspSelectPreOrderWithID_Result.pordNumber, now2.ToString("yyyy/MM/dd")).Replace("<br>", "\n"));
								dictionary.Add("MessageType", "VerifyPreOrd");
								dictionary.Add("InternalMessageId", retId.ToString());
								dictionary.Add("preOrderID", pordId.ToString());
								PushNotif.NewIntMsgNotifyToCompany(int.Parse(pordCompanyId.ToString()), dictionary);
							}
						}
						data = pordId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
						break;
					}
					case -1:
						data = pordId;
						message = Messages.MobMsgErrorDivisionByZero;
						status = ServiceResultStatus.Fail;
						break;
					case -2:
						data = pordId;
						message = string.Format(Messages.MobMsgErrorMaxDiscountPercentInItemDiscount, arg);
						status = ServiceResultStatus.Fail;
						break;
					case -3:
						data = pordId;
						message = string.Format(Messages.MobMsgErrorMaxDiscountPercentInPordDiscount, arg);
						status = ServiceResultStatus.Fail;
						break;
					default:
						data = pordId;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
						break;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = pordId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = pordId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = pordId;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> PreOrderVerifyExit(int pordId, string registerDate, string registerTime, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					if (!UserLogin.IsUserAccess("frmPreOrder", "actExitFromIsFix", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = pordId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (pordId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorPreOrderNotFound,
							Data = pordId,
							Status = ServiceResultStatus.Error
						};
					}
					DateTime now = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(registerDate) || string.IsNullOrEmpty(registerTime))
						{
							ServiceResult<int> result3 = new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = pordId,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						registerDate = registerDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						string formatetdDate = PersianDate.GetFormatetdDate(registerDate.Replace("/", ""));
						if (result == 1065)
						{
							now = DateTime.Parse(formatetdDate + " " + registerTime, new PersianCulture());
							registerDate = now.ToString("yyyyMMdd");
						}
						else
						{
							now = DateTime.Parse(formatetdDate + " " + registerTime, new CultureInfo("en-US"));
							registerDate = now.ToString("yyyyMMdd", new PersianCulture());
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<int> result4 = new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = pordId,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					cRMEntities.MobspPreOrderVerifyExit(pordId, token2.userId, registerDate, now);
					data = pordId;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = pordId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = pordId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = pordId;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertPreOrderFullResultViewModel> InsertPreOrderFull(InsertPreOrderFullViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertPreOrderFullResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					bool value4 = UserLogin.IsUserAccess("frmPreOrderItemDataEntry", "actCanNotSelectWithNoStockInPord", UserLogin.CurrentUser, model.CenterId);
					bool value5 = UserLogin.IsUserAccess("frmPreOrderItemDataEntry", "actCanNotSelectWithNoReserveStockInPord", UserLogin.CurrentUser, model.CenterId);
					bool value6 = UserLogin.IsUserAccess("frmPreOrderItemDataEntry", "actCanNotSelectWithNoSoldStockInPord", UserLogin.CurrentUser, model.CenterId);
					if (0 == 0)
					{
						ObjectParameter objectParameter = new ObjectParameter("insertedPreOrderId", 0);
						ObjectParameter objectParameter2 = new ObjectParameter("insertedPordItemIds", "");
						ObjectParameter objectParameter3 = new ObjectParameter("insertedPordItemSpcfIds", "");
						ObjectParameter objectParameter4 = new ObjectParameter("insertedPordPaymentIds", "");
						ObjectParameter objectParameter5 = new ObjectParameter("errorMessage", "");
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertPreOrderFull(model.PreOrder, model.PordItemList, model.PordItemSpecificationList, model.PordPaymentList, token2.userId, value2, value2, value3, value, registerDatePersian, appType, result, result2, value4, objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, model.CenterId, model.haveLinkAccQtyCheck, value5, value6));
						InsertPreOrderFullResultViewModel insertPreOrderFullResultViewModel = new InsertPreOrderFullResultViewModel();
						if (objectParameter5.Value != null)
						{
							if (objectParameter5.Value.ToString() != "")
							{
								string text = objectParameter5.Value.ToString();
								text = text.Replace("|Msg=0", Messages.MobMsgErrorInsertPreOrder);
								text = text.Replace("|pordNumberIsDup", Messages.MobMsgPreOrderNumberIsRepeated);
								text = text.Replace("Msg=1", Messages.MobMsgErrorInconsistencyInPordSelection);
								text = text.Replace("Msg=5", Messages.MobMsgProductLackOfStock);
								text = text.Replace("Msg=6", "عدم موجودی در انبار رزرو");
								text = text.Replace("Msg=7", "عدم موجودی در سفارشات");
								text = text.Replace("Msg=2", Messages.MobMsgErrorInsertProduct);
								text = text.Replace("Msg=3", Messages.MobMsgErrorInsertProductSpcf);
								insertPreOrderFullResultViewModel.ErrorMessage = text;
							}
							else
							{
								insertPreOrderFullResultViewModel.ErrorMessage = "";
							}
						}
						if (objectParameter.Value != null)
						{
							insertPreOrderFullResultViewModel.PreOrder = objectParameter.Value.ToString() ?? "0";
							int.Parse(objectParameter.Value.ToString());
						}
						else
						{
							insertPreOrderFullResultViewModel.PreOrder = "0";
						}
						if (objectParameter2.Value != null)
						{
							insertPreOrderFullResultViewModel.PordItemList = objectParameter2.Value.ToString() ?? "0";
						}
						else
						{
							insertPreOrderFullResultViewModel.PordItemList = "0";
						}
						if (objectParameter3.Value != null)
						{
							insertPreOrderFullResultViewModel.PordItemSpecificationList = objectParameter3.Value.ToString() ?? "0";
						}
						else
						{
							insertPreOrderFullResultViewModel.PordItemSpecificationList = "0";
						}
						if (objectParameter4.Value != null)
						{
							insertPreOrderFullResultViewModel.PordPaymentList = objectParameter4.Value.ToString() ?? "0";
						}
						else
						{
							insertPreOrderFullResultViewModel.PordPaymentList = "0";
						}
						if (!num.HasValue || num >= 1)
						{
							if (insertPreOrderFullResultViewModel.ErrorMessage.IndexOf("=Dup", StringComparison.Ordinal) >= 0)
							{
								string text2 = "";
								string[] array = insertPreOrderFullResultViewModel.ErrorMessage.Split(new string[1] { "|^|" }, StringSplitOptions.None);
								foreach (string text3 in array)
								{
									if (!string.IsNullOrEmpty(text3))
									{
										string[] array2 = text3.Split(new char[1] { ',' });
										string text4 = "";
										if (array2[0] == "@pordNumRef=Dup")
										{
											text4 = array2[1].Replace("@DupPordNumber=", "") ?? "";
											text2 += string.Format(Messages.MobPreOrderNumRefIsRepeated, text4);
										}
									}
								}
								insertPreOrderFullResultViewModel.ErrorMessage = text2;
							}
							if (!string.IsNullOrEmpty(insertPreOrderFullResultViewModel.ErrorMessage))
							{
								data = insertPreOrderFullResultViewModel;
								message = insertPreOrderFullResultViewModel.ErrorMessage;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								string[] array = insertPreOrderFullResultViewModel.PordPaymentList.Split(new char[1] { '|' });
								foreach (string text5 in array)
								{
									if (string.IsNullOrEmpty(text5))
									{
										continue;
									}
									string[] array3 = text5.Split(new char[1] { ',' });
									if (array3.Length > 1)
									{
										int result3 = 0;
										int.TryParse(array3[1], out result3);
										if (result3 > 0)
										{
											PreOrder.PaymentMoneyBag(result3, 0, result, model.CenterId);
										}
									}
								}
								data = insertPreOrderFullResultViewModel;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = insertPreOrderFullResultViewModel;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
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
		return new ServiceResult<InsertPreOrderFullResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertPreOrderFullResultViewModel> InsertShopPreOrderFull(ShopIssueOrderViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		InsertPreOrderFullResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string text = now.ToString("yyyyMMdd", new PersianCulture());
					string text2 = now.ToString("HH:mm:ss");
					string text3 = DateTimeClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int id = Financial.Get().Id;
					UserLogin.IsUserAccess("frmPreOrderItemDataEntry", "actCanNotSelectWithNoStockInPord", UserLogin.CurrentUser, model.CenterId);
					if (0 == 0)
					{
						bool result3 = false;
						bool flag = true;
						MobspSelectCrmFoSetting_Result mobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmFoSetting_Result>((IEnumerable<MobspSelectCrmFoSetting_Result>)cRMEntities.MobspSelectCrmFoSetting(result, result2, model.CenterId, null));
						if (mobspSelectCrmFoSetting_Result != null)
						{
							bool.TryParse(mobspSelectCrmFoSetting_Result.ShpPrdDoneTimeScheduleActive.ToString(), out result3);
						}
						string prdSaleCenterDoneTimeJson = "";
						if (result3)
						{
							List<SHPMobspCheckSelectedPrdDoneTime_Result> list = new List<SHPMobspCheckSelectedPrdDoneTime_Result>();
							if (!string.IsNullOrWhiteSpace(model.PrdDoneTimeJs))
							{
								bool resultCheck = false;
								List<SHPMobspCheckSelectedPrdDoneTime_Result> list2 = Product.CheckSelectedDoneTimeAvailable(model.PrdDoneTimeJs, out resultCheck);
								if (list2 != null && list2.Count > 0)
								{
									if (Enumerable.FirstOrDefault<SHPMobspCheckSelectedPrdDoneTime_Result>((IEnumerable<SHPMobspCheckSelectedPrdDoneTime_Result>)list2, (Func<SHPMobspCheckSelectedPrdDoneTime_Result, bool>)((SHPMobspCheckSelectedPrdDoneTime_Result x) => !string.IsNullOrWhiteSpace(x.DetectedDoneTime))) == null)
									{
										list.AddRange(Enumerable.Select<SHPMobspCheckSelectedPrdDoneTime_Result, SHPMobspCheckSelectedPrdDoneTime_Result>((IEnumerable<SHPMobspCheckSelectedPrdDoneTime_Result>)list2, (Func<SHPMobspCheckSelectedPrdDoneTime_Result, SHPMobspCheckSelectedPrdDoneTime_Result>)((SHPMobspCheckSelectedPrdDoneTime_Result x) => new SHPMobspCheckSelectedPrdDoneTime_Result
										{
											PrdIds = x.PrdIds,
											PrdDate = x.PrdDate,
											PrdStartTime = x.PrdStartTime,
											PrdStartTimeMin = x.PrdStartTimeMin,
											PrdEndTime = x.PrdEndTime,
											PrdEndTimeMin = x.PrdEndTimeMin,
											TotalDoneTimeMin = x.TotalDoneTimeMin,
											DetectedDoneTime = x.DetectedDoneTime,
											PrdSaleCenterId = x.PrdSaleCenterId,
											PrdSaleCenterParentId = x.PrdSaleCenterParentId
										})));
									}
									else
									{
										message = Messages.FOMsgErrorPrdDoneTimeReservedBefore;
										status = ServiceResultStatus.Error;
										data = null;
										flag = false;
									}
								}
							}
							if (list != null && Enumerable.Any<SHPMobspCheckSelectedPrdDoneTime_Result>((IEnumerable<SHPMobspCheckSelectedPrdDoneTime_Result>)list))
							{
								prdSaleCenterDoneTimeJson = JsonConvert.SerializeObject(Enumerable.ToList<SHPMobspCheckSelectedPrdDoneTime_Result>((IEnumerable<SHPMobspCheckSelectedPrdDoneTime_Result>)list));
							}
						}
						if (flag)
						{
							ObjectParameter objectParameter = new ObjectParameter("error", "");
							ObjectParameter objectParameter2 = new ObjectParameter("preOrderId", 0);
							ObjectParameter objectParameter3 = new ObjectParameter("pordNumber", 0);
							CRMSpEntities cRMSpEntities2 = cRMSpEntities;
							int? companyId = model.CompanyId;
							string items = model.Items;
							DateTime? dateTime = value;
							string text4 = text;
							string text5 = text3;
							string text6 = text2;
							int? num2 = id;
							short? num3 = value2;
							string text7 = appType;
							int? num4 = num;
							int? num5 = result2;
							ObjectParameter objectParameter4 = objectParameter;
							ObjectParameter objectParameter5 = objectParameter2;
							ObjectParameter objectParameter6 = objectParameter3;
							int num6 = cRMSpEntities2.SHPMobspIssuePreOrder(transportation: model.Transportation, personId: model.PersonId, wHId: model.WHId, prjcnvsStatusGroupId: model.PrjcnvsStatusGroupId, currencyUnitId: model.OrdCurrencyUnitId, pordDeliveryEndDate: model.OrdDeliveryEndDate ?? "", pordDeliveryEndDateTime: (!string.IsNullOrEmpty(model.OrdDeliveryEndDate)) ? model.OrdDeliveryEndDateTime : null, pordDeliveryEndTime: model.OrdDeliveryEndTime, pordDeliveryDate: model.OrdDeliveryDate, pordDeliveryDateTime: (!string.IsNullOrEmpty(model.OrdDeliveryDate)) ? model.OrdDeliveryDateTime : null, pordDeliveryTime: model.OrdDeliveryTime, productDiscountJson: model.ProductDiscountJson, discountCodeId: model.DiscountCodeId, disCode: model.DisCode, disAmount: model.DisAmount, disAmountPercent: model.DisAmountPercent, pordDiscountTitle: model.OrdDiscountTitle, registerDate: dateTime, registerDatePersian: text4, registerTime: text6, registerDay: text5, fPId: num2, month1: num3, appType: text7, languageID: num4, defaultLanguageID: num5, error: objectParameter4, pordNumber: objectParameter6, preOrderId: objectParameter5, pordDescriptionI: model.OrdDescription, companyId: companyId, prjTitle: "فروشگاه آنلاین", products: items, pordVerifierRequestId: (model.OrdVerifierRequestId != 0) ? new int?(model.OrdVerifierRequestId) : null, pordExpireDay: model.PordExpireDay, pordDeliveryTermId: (model.DeliveryTermId != 0) ? new int?(model.DeliveryTermId) : null, prdSaleCenterDoneTimeJson: prdSaleCenterDoneTimeJson, foSettingId: model.FoSettingId, centerId: model.CenterId, shpCartPayTypeId: model.ShpCartPayTypeId, itemWeightToleranceJson: model.ItemWeightToleranceJson, pordSaleAreaId: model.SaleAreaId);
							InsertPreOrderFullResultViewModel insertPreOrderFullResultViewModel = new InsertPreOrderFullResultViewModel();
							if (objectParameter.Value != null)
							{
								if (objectParameter.Value.ToString() != "")
								{
									insertPreOrderFullResultViewModel.ErrorMessage = Messages.msgErrorRunFunction;
									if (objectParameter.Value.ToString().IndexOf("SaleCenter Reserve", StringComparison.Ordinal) >= 0)
									{
										insertPreOrderFullResultViewModel.ErrorMessage = Messages.FOMsgErrorPrdDoneTimeReservedBefore;
									}
								}
								else
								{
									insertPreOrderFullResultViewModel.ErrorMessage = "";
								}
							}
							if (objectParameter2.Value != null)
							{
								insertPreOrderFullResultViewModel.PreOrder = objectParameter2.Value.ToString() ?? "0";
								int.Parse(objectParameter2.Value.ToString());
							}
							if (objectParameter3.Value != null)
							{
								insertPreOrderFullResultViewModel.PorderNumber = objectParameter3.Value.ToString() ?? "0";
							}
							if (num6 >= 1)
							{
								if (insertPreOrderFullResultViewModel.ErrorMessage.IndexOf("=Dup", StringComparison.Ordinal) >= 0)
								{
									string text8 = "";
									string[] array = insertPreOrderFullResultViewModel.ErrorMessage.Split(new string[1] { "|^|" }, StringSplitOptions.None);
									foreach (string text9 in array)
									{
										if (!string.IsNullOrEmpty(text9))
										{
											string[] array2 = text9.Split(new char[1] { ',' });
											string text10 = "";
											if (array2[0] == "@pordNumRef=Dup")
											{
												text10 = array2[1].Replace("@DupPordNumber=", "") ?? "";
												text8 += string.Format(Messages.MobPreOrderNumRefIsRepeated, text10);
											}
										}
									}
									insertPreOrderFullResultViewModel.ErrorMessage = text8;
								}
								if (!string.IsNullOrEmpty(insertPreOrderFullResultViewModel.ErrorMessage))
								{
									data = insertPreOrderFullResultViewModel;
									message = insertPreOrderFullResultViewModel.ErrorMessage;
									status = ServiceResultStatus.Fail;
								}
								else
								{
									data = insertPreOrderFullResultViewModel;
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
							}
							else
							{
								data = insertPreOrderFullResultViewModel;
								message = Messages.MobMsgErrorDoneOperation;
								status = ServiceResultStatus.Fail;
							}
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<InsertPreOrderFullResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<PreOrderListAndIntMsgViewModel> GetPreOrderListAndIntMsg(int companyId, long pordNumber, string fromDate, string toDate, int? cId = null, int? pageNumber = 1, int? pageSize = 10, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		PreOrderListAndIntMsgViewModel preOrderListAndIntMsgViewModel = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<PreOrderListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					preOrderListAndIntMsgViewModel = new PreOrderListAndIntMsgViewModel();
					preOrderListAndIntMsgViewModel.PreOrders = new List<MobspSelectPreOrdersInMode_Result>();
					preOrderListAndIntMsgViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
					DateTime? fDateTime = null;
					DateTime? tDateTime = null;
					try
					{
						if (!string.IsNullOrEmpty(fromDate))
						{
							fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							fDateTime = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00")));
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<PreOrderListAndIntMsgViewModel> result3 = new ServiceResult<PreOrderListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					try
					{
						if (!string.IsNullOrEmpty(toDate))
						{
							toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							tDateTime = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59")));
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<PreOrderListAndIntMsgViewModel> result4 = new ServiceResult<PreOrderListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					PreOrderListAndIntMsgViewModel preOrderListAndIntMsgViewModel2 = preOrderListAndIntMsgViewModel;
					CRMEntities cRMEntities2 = cRMEntities;
					int? companyId2 = companyId;
					preOrderListAndIntMsgViewModel2.PreOrders = Enumerable.ToList<MobspSelectPreOrdersInMode_Result>((IEnumerable<MobspSelectPreOrdersInMode_Result>)cRMEntities2.MobspSelectPreOrdersInMode(token2.userId, companyId2, pordNumber, fDateTime, tDateTime, pageNumber, pageSize, result, result2, cId));
					if (!VersionBuyer.MobFinancial || !VersionBuyer.PreOrders)
					{
						preOrderListAndIntMsgViewModel.PreOrders = Enumerable.ToList<MobspSelectPreOrdersInMode_Result>(Enumerable.Take<MobspSelectPreOrdersInMode_Result>((IEnumerable<MobspSelectPreOrdersInMode_Result>)preOrderListAndIntMsgViewModel.PreOrders, 2));
					}
					foreach (MobspSelectPreOrdersInMode_Result preOrder in preOrderListAndIntMsgViewModel.PreOrders)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 5, preOrder.PreOrderId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							preOrderListAndIntMsgViewModel.InternalMessages.AddRange(list);
						}
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					preOrderListAndIntMsgViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				preOrderListAndIntMsgViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			preOrderListAndIntMsgViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<PreOrderListAndIntMsgViewModel>
		{
			Message = message,
			Data = preOrderListAndIntMsgViewModel,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<IssueOrderFromPreOrderResultViewModel> IssueOrderFromPreOrder(IssueOrderFromPreOrderViewModel model)
	{
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_066d: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		IssueOrderFromPreOrderResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					string text = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(Financial.Get().Id.ToString());
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					List<OrdIdKeyValueViewModel> list = new List<OrdIdKeyValueViewModel>();
					if (!string.IsNullOrEmpty(model.ValDetails))
					{
						list = new JavaScriptSerializer().Deserialize<List<OrdIdKeyValueViewModel>>(model.ValDetails);
					}
					List<OrdIdKeyValueViewModel> list2 = new List<OrdIdKeyValueViewModel>();
					if (Enumerable.Any<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list))
					{
						foreach (OrdIdKeyValueViewModel item3 in list)
						{
							int id = item3.Id;
							_ = item3.Type;
							string tag = item3.Tag;
							string valueStr = item3.ValueStr;
							int result2 = 0;
							int.TryParse(id.ToString(), out result2);
							double result3 = 0.0;
							string text2 = "";
							string text3 = "";
							decimal result4 = default(decimal);
							if (!(tag == "B"))
							{
								continue;
							}
							double.TryParse(valueStr.ToString(), out result3);
							OrdIdKeyValueViewModel ordIdKeyValueViewModel = Enumerable.FirstOrDefault<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list, (Func<OrdIdKeyValueViewModel, bool>)((OrdIdKeyValueViewModel m) => m.Id == id && m.Tag == "D"));
							if (ordIdKeyValueViewModel != null)
							{
								text2 = ordIdKeyValueViewModel.ValueStr;
							}
							OrdIdKeyValueViewModel ordIdKeyValueViewModel2 = Enumerable.FirstOrDefault<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list, (Func<OrdIdKeyValueViewModel, bool>)((OrdIdKeyValueViewModel m) => m.Id == id && m.Tag == "E"));
							if (ordIdKeyValueViewModel2 != null)
							{
								text3 = ordIdKeyValueViewModel2.ValueStr;
							}
							OrdIdKeyValueViewModel ordIdKeyValueViewModel3 = Enumerable.FirstOrDefault<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list, (Func<OrdIdKeyValueViewModel, bool>)((OrdIdKeyValueViewModel m) => m.Id == id && m.Tag == "F"));
							if (ordIdKeyValueViewModel3 != null)
							{
								decimal.TryParse(ordIdKeyValueViewModel3.ValueStr, out result4);
							}
							if (!(result3 > 0.0))
							{
								continue;
							}
							DateTime dateTime = default(DateTime);
							string text4 = "";
							DateTime? validityExpireDate = default(DateTime);
							try
							{
								if (!string.IsNullOrWhiteSpace(text2))
								{
									text4 = PersianDate.GetFormatetdDate(text2.Replace("/", ""));
									text4 = (string.IsNullOrEmpty(text3) ? (text4 + " 00:00:00") : (text4 + " " + text3.Trim()));
									switch (result)
									{
									case 1065:
										dateTime = DateTime.Parse(text4, new PersianCulture());
										text2 = dateTime.ToString("yyyyMMdd");
										break;
									case 1025:
										dateTime = DateTime.Parse(text4, new CultureInfo("ar-SA"));
										text2 = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									default:
										dateTime = DateTime.Parse(text4, new CultureInfo("en-US"));
										text2 = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									}
									validityExpireDate = dateTime;
								}
								else
								{
									validityExpireDate = null;
								}
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
							}
							if (text2 != null)
							{
								text2 = text2.Replace("/", "").Replace("-", "").Replace("_", "")
									.Replace(".", "")
									.Replace(",", "")
									.Replace("\\", "");
							}
							OrdIdKeyValueViewModel item = new OrdIdKeyValueViewModel
							{
								Id = result2,
								Value = result3,
								ValidityExpireDate = validityExpireDate,
								ValidityExpireDatePersian = text2,
								PrdAutoCalcRate = result4
							};
							list2.Add(item);
						}
					}
					int num2 = 0;
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(model.PreOrderId, token2.userId, num, defLangId, model.CenterId));
					if (mobspSelectPreOrderWithID_Result == null)
					{
						return new ServiceResult<IssueOrderFromPreOrderResultViewModel>
						{
							Message = Messages.MobMsgErrorNotFound,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					num2 = mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault();
					if (!VersionBuyer.Order || !VersionBuyer.MobFinancial)
					{
						Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspSelectMobOrderCnt(model.CenterId)).GetValueOrDefault();
						return new ServiceResult<IssueOrderFromPreOrderResultViewModel>
						{
							Message = Messages.VersionBuy,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (!PreOrder.IsFixed(model.PreOrderId, result, token2.userId, model.CenterId))
					{
						return new ServiceResult<IssueOrderFromPreOrderResultViewModel>
						{
							Message = Messages.MobMsgErrorToBeNotIssueOrder,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					bool flag = PreOrder.CheckCheckPreOrderHaveTax(model.PreOrderId);
					MobspSelectOrderOprById_Result mobspSelectOrderOprById_Result = Enumerable.FirstOrDefault<MobspSelectOrderOprById_Result>((IEnumerable<MobspSelectOrderOprById_Result>)cRMSpEntities.MobspSelectOrderOprById(model.OrdOprId, num, defLangId));
					if (mobspSelectOrderOprById_Result != null)
					{
						bool num3 = UserLogin.IsUserAccess("frmIssueOrderFromPreOrder", "actIssueTaxConflictInOrdOpr", UserLogin.CurrentUser, model.CenterId);
						bool result5 = false;
						bool.TryParse(mobspSelectOrderOprById_Result.Taxable.ToString(), out result5);
						if (!num3 && flag != result5)
						{
							return new ServiceResult<IssueOrderFromPreOrderResultViewModel>
							{
								Message = "msgErrorOrderOprNoTaxable".OrderMessages(),
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
					}
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					List<CrmProjectTitles_LangViewModel> list4 = new List<CrmProjectTitles_LangViewModel>();
					if (!string.IsNullOrWhiteSpace(model.AddPrdValidityPrjTitle))
					{
						MobspSelectProjectTitlesByVal_Result mobspSelectProjectTitlesByVal_Result = Enumerable.FirstOrDefault<MobspSelectProjectTitlesByVal_Result>((IEnumerable<MobspSelectProjectTitlesByVal_Result>)cRMEntities.MobspSelectProjectTitlesByVal(model.AddPrdValidityPrjTitle, num, defLangId));
						if (mobspSelectProjectTitlesByVal_Result != null)
						{
							if (!string.IsNullOrEmpty(mobspSelectProjectTitlesByVal_Result.ProjectTitles_Lang))
							{
								list4 = new JavaScriptSerializer().Deserialize<List<CrmProjectTitles_LangViewModel>>(mobspSelectProjectTitlesByVal_Result.ProjectTitles_Lang);
							}
							list4.Add(new CrmProjectTitles_LangViewModel
							{
								CrmProjectTitlesLangID = 0,
								ProjectTitleID = mobspSelectProjectTitlesByVal_Result.ProjectTitleID,
								LanguageID = num,
								ProjectTitle = mobspSelectProjectTitlesByVal_Result.ProjectTitle,
								ProjectTitleDesc = mobspSelectProjectTitlesByVal_Result.ProjectTitleDesc
							});
						}
					}
					if (list4 != null && Enumerable.Any<CrmProjectTitles_LangViewModel>((IEnumerable<CrmProjectTitles_LangViewModel>)list4))
					{
						foreach (CrmProjectTitles_LangViewModel item4 in list4)
						{
							list3.Add(new CommonMultiLanguageViewModel
							{
								Value = item4.ProjectTitle,
								LanguageId = item4.LanguageID
							});
						}
					}
					if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
					{
						model.AddPrdValidityPrjTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : "");
					}
					else
					{
						model.AddPrdValidityPrjTitle = "";
					}
					if (model.AddPrdValidity && string.IsNullOrWhiteSpace(model.AddPrdValidityPrjTitle))
					{
						return new ServiceResult<IssueOrderFromPreOrderResultViewModel>
						{
							Message = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.IssueOrdFromPordAddPrdValidityPrjTitle),
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (model.OrdIssueSettingByPrdId != 0 && num2 != 0)
					{
						MobspCheckHaveCmpProjectByOrdIssuePrdId_Result mobspCheckHaveCmpProjectByOrdIssuePrdId_Result = Enumerable.FirstOrDefault<MobspCheckHaveCmpProjectByOrdIssuePrdId_Result>((IEnumerable<MobspCheckHaveCmpProjectByOrdIssuePrdId_Result>)cRMSpEntities.MobspCheckHaveCmpProjectByOrdIssuePrdId(num2, model.OrdIssueSettingByPrdId, num, defLangId, model.CenterId));
						if (mobspCheckHaveCmpProjectByOrdIssuePrdId_Result != null)
						{
							int result6 = 0;
							int.TryParse(mobspCheckHaveCmpProjectByOrdIssuePrdId_Result.ProjectId.ToString(), out result6);
							if (result6 == -2)
							{
								string arg = mobspCheckHaveCmpProjectByOrdIssuePrdId_Result.PrdOrdIssuePrjTitleGroup + " " + mobspCheckHaveCmpProjectByOrdIssuePrdId_Result.PrdOrdIssuePrjTitle + " " + mobspCheckHaveCmpProjectByOrdIssuePrdId_Result.PrdOrdIssuePrjPostFix;
								return new ServiceResult<IssueOrderFromPreOrderResultViewModel>
								{
									Message = string.Format("msgErrorNotIssueOrderNoProject".OrderMessages(), arg),
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
						}
					}
					MobspReturnOrderFromPreOrder_Result mobspReturnOrderFromPreOrder_Result = new MobspReturnOrderFromPreOrder_Result();
					string text5 = "";
					List<MobspReturnOrderFromPreOrder_Result> list5 = Enumerable.ToList<MobspReturnOrderFromPreOrder_Result>((IEnumerable<MobspReturnOrderFromPreOrder_Result>)cRMEntities.MobspReturnOrderFromPreOrder(model.PreOrderId, num, defLangId));
					if (list5 != null && Enumerable.Any<MobspReturnOrderFromPreOrder_Result>((IEnumerable<MobspReturnOrderFromPreOrder_Result>)list5))
					{
						mobspReturnOrderFromPreOrder_Result = Enumerable.LastOrDefault<MobspReturnOrderFromPreOrder_Result>((IEnumerable<MobspReturnOrderFromPreOrder_Result>)list5);
						if (list5.Count > 1)
						{
							foreach (MobspReturnOrderFromPreOrder_Result item5 in list5)
							{
								text5 = text5 + item5.ordNumber + ",";
							}
							if (!string.IsNullOrEmpty(text5) && text5.EndsWith(","))
							{
								text5 = text5.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						mobspReturnOrderFromPreOrder_Result = null;
					}
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.MobspCheckPreOrderHaveOrder(model.PreOrderId));
					int result7 = 0;
					if (mct_Result != null)
					{
						int.TryParse(mct_Result.Result.ToString(), out result7);
						if (result7 == 0)
						{
							mobspReturnOrderFromPreOrder_Result = null;
						}
					}
					if (mobspReturnOrderFromPreOrder_Result != null && result7 == 1)
					{
						mobspReturnOrderFromPreOrder_Result.ordDate = ((!string.IsNullOrEmpty(mobspReturnOrderFromPreOrder_Result.ordDate) && result != 1065) ? PersianDate.GetShamsi2Miladi(mobspReturnOrderFromPreOrder_Result.ordDate.Replace("/", "")).Replace("/", "") : mobspReturnOrderFromPreOrder_Result.ordDate);
						MobspReturnOrderFromPreOrder_Result mobspReturnOrderFromPreOrder_Result2 = mobspReturnOrderFromPreOrder_Result;
						_ = mobspReturnOrderFromPreOrder_Result.RegisterDate;
						mobspReturnOrderFromPreOrder_Result2.RegisterDatePersian = mobspReturnOrderFromPreOrder_Result.RegisterDate.ToString("yyyyMMdd");
						if (string.IsNullOrEmpty(text5))
						{
							text5 = mobspReturnOrderFromPreOrder_Result.ordNumber.ToString();
						}
						string message2 = Labels.Error + " !\r\n" + Messages.msgIssueOrderFormPreOrderWithNumber + " " + text5 + "\r\n" + Messages.msgIssueOrderFormPreOrderDate + " " + PersianDate.GetFormatetdDate(mobspReturnOrderFromPreOrder_Result.ordDate) + "\r\n" + Messages.msgIssueOrderFormPreOrderInDate + " " + PersianDate.GetFormatetdDate(mobspReturnOrderFromPreOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueOrderFormPreOrderByUser + " " + mobspReturnOrderFromPreOrder_Result.UserName + "\r\n" + Messages.msgIssueOrderFormPreOrderBeenIssued;
						IssueOrderFromPreOrderResultViewModel issueOrderFromPreOrderResultViewModel = new IssueOrderFromPreOrderResultViewModel();
						issueOrderFromPreOrderResultViewModel.InsertedOrderID = mobspReturnOrderFromPreOrder_Result.OrderID;
						return new ServiceResult<IssueOrderFromPreOrderResultViewModel>
						{
							Message = message2,
							Data = issueOrderFromPreOrderResultViewModel,
							Status = ServiceResultStatus.Fail
						};
					}
					if (UserLogin.IsUserAccess("frmPreOrder", "actCanIssueOrderAfterPayFull", UserLogin.CurrentUser, model.CenterId))
					{
						decimal result8 = default(decimal);
						MobspReturnSumPreOrderPay_Result mobspReturnSumPreOrderPay_Result = Enumerable.FirstOrDefault<MobspReturnSumPreOrderPay_Result>((IEnumerable<MobspReturnSumPreOrderPay_Result>)cRMEntities.MobspReturnSumPreOrderPay(model.PreOrderId));
						if (mobspReturnSumPreOrderPay_Result != null)
						{
							decimal.TryParse(mobspReturnSumPreOrderPay_Result.RemainpordAmount.ToString(), out result8);
						}
						if (result8 > 0m)
						{
							return new ServiceResult<IssueOrderFromPreOrderResultViewModel>
							{
								Message = "msgErrorUnableIssueOrdFromPordNotBeenFullySettled".OrderMessages(),
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
					}
					if (UserLogin.IsUserAccess("frmIssueOrderFromPreOrder", "actCanNotIssueOrderWithNoStock", UserLogin.CurrentUser, model.CenterId))
					{
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						bool flag2 = false;
						int num4 = 0;
						bool flag3 = false;
						if (mobspSelectCrmsysSetting_Result != null)
						{
							flag2 = ((mobspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && mobspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
							num4 = mobspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						if (flag2 && num4 > 0)
						{
							List<MobspSelectPreOrderItems_Result> list6 = Enumerable.ToList<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)cRMEntities.MobspSelectPreOrderItems(model.PreOrderId, result, defLangId));
							List<MobspSelectPreOrderItems_Result> list7 = new List<MobspSelectPreOrderItems_Result>();
							if (list6 != null && Enumerable.Any<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list6) && list2 != null && Enumerable.Any<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list2))
							{
								foreach (OrdIdKeyValueViewModel item6 in list2)
								{
									int id2 = item6.Id;
									_ = item6.Type;
									_ = item6.Tag;
									double value3 = item6.Value;
									int objId = 0;
									int.TryParse(id2.ToString(), out objId);
									double result9 = 0.0;
									double.TryParse(value3.ToString(), out result9);
									MobspSelectPreOrderItems_Result linkAccitem = Enumerable.FirstOrDefault<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list6, (Func<MobspSelectPreOrderItems_Result, bool>)((MobspSelectPreOrderItems_Result m) => m.PreOrderItemID == objId));
									if (linkAccitem == null || result9 == 0.0)
									{
										continue;
									}
									int num5 = linkAccitem.PrdKind.GetValueOrDefault(1);
									if (num5 == 0)
									{
										num5 = 1;
									}
									if (num5 != 1)
									{
										continue;
									}
									bool flag4 = true;
									if (Enumerable.FirstOrDefault<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list7, (Func<MobspSelectPreOrderItems_Result, bool>)((MobspSelectPreOrderItems_Result m) => m.pordIPrdId == linkAccitem.pordIPrdId && m.pordIWHId == linkAccitem.pordIWHId && (m.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (m.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && m.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())) != null)
									{
										flag4 = false;
										foreach (MobspSelectPreOrderItems_Result item7 in list7)
										{
											if (item7.pordIPrdId == linkAccitem.pordIPrdId && item7.pordIWHId == linkAccitem.pordIWHId && (item7.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (item7.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && item7.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())
											{
												item7.pordIQuantity = item7.pordIQuantity.GetValueOrDefault() + result9;
											}
										}
									}
									if (flag4)
									{
										MobspSelectPreOrderItems_Result item2 = new MobspSelectPreOrderItems_Result
										{
											PreOrderItemID = linkAccitem.PreOrderItemID,
											pordIQuantity = result9,
											pordIPrice = linkAccitem.pordIPrice,
											pordIPrdPriceGroupID = linkAccitem.pordIPrdPriceGroupID,
											pordIPrdId = linkAccitem.pordIPrdId,
											pordIWHId = linkAccitem.pordIWHId,
											pordILinkAccWHIdStr = linkAccitem.pordILinkAccWHIdStr,
											pordITracing = linkAccitem.pordITracing,
											pordILinkAccSettingDBId = linkAccitem.pordILinkAccSettingDBId,
											pordIDescriptionI = linkAccitem.pordIDescriptionI,
											pordIPrdName = linkAccitem.pordIPrdName
										};
										list7.Add(item2);
									}
								}
							}
							if (list7 != null && Enumerable.Any<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list7))
							{
								foreach (MobspSelectPreOrderItems_Result item8 in list7)
								{
									if (item8 == null)
									{
										continue;
									}
									double valueOrDefault = item8.pordIQuantity.GetValueOrDefault();
									string text6 = "";
									string wcf = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.RequestUri.ToString().Split(new string[1] { "/api" }, StringSplitOptions.None));
									HttpRequestHeaders headers = base.Request.Headers;
									string prdIds = item8.pordIPrdId.ToString();
									int valueOrDefault2 = item8.pordIWHId.GetValueOrDefault();
									ServiceResult<string> prdQuantity = OtherSystems.GetPrdQuantity(headers, wcf, prdIds, num2, valueOrDefault2, num, num4.ToString(), item8.pordITracing ?? "");
									if (prdQuantity.Status == ServiceResultStatus.Success)
									{
										if (!string.IsNullOrEmpty(text6))
										{
											text6 = prdQuantity.Data;
										}
										double result10 = 0.0;
										if (string.IsNullOrEmpty(text6))
										{
											continue;
										}
										if (text6 == Labels.frmError)
										{
											text6 = "0";
										}
										if (text6 != Labels.frmError)
										{
											double.TryParse(text6, out result10);
											if (result10 < valueOrDefault)
											{
												flag3 = true;
												ServiceResult<IssueOrderFromPreOrderResultViewModel> serviceResult = new ServiceResult<IssueOrderFromPreOrderResultViewModel>();
												serviceResult.Message = Messages.msgIssueDraftFormPreOrderImpossibilityIssued + "\r\n" + Messages.msgIssueDraftFormPreOrderLackInventory + "\r\n" + item8.pordIPrdName;
												serviceResult.Data = null;
												serviceResult.Status = ServiceResultStatus.Error;
												return serviceResult;
											}
											flag3 = true;
										}
										continue;
									}
									return new ServiceResult<IssueOrderFromPreOrderResultViewModel>
									{
										Message = prdQuantity.Message,
										Data = null,
										Status = prdQuantity.Status
									};
								}
							}
						}
						if (!flag3)
						{
							MobspControlPreOrderItemsStock_Result mobspControlPreOrderItemsStock_Result = Enumerable.FirstOrDefault<MobspControlPreOrderItemsStock_Result>((IEnumerable<MobspControlPreOrderItemsStock_Result>)cRMEntities.MobspControlPreOrderItemsStock(model.PreOrderId, num, defLangId, model.PordItemListJson, model.CenterId));
							if (mobspControlPreOrderItemsStock_Result != null)
							{
								string message3 = Messages.msgErrorUnableIssueOrderFormPreOrder + "\r\n" + Messages.msgErrorIssueOrderFormPreOrderLackInventory + "\r\n" + mobspControlPreOrderItemsStock_Result.PrdName;
								return new ServiceResult<IssueOrderFromPreOrderResultViewModel>
								{
									Message = message3,
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
						}
					}
					ObjectParameter objectParameter = new ObjectParameter("insertedOrderID", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("insertedOrderNumber", 0);
					new ObjectParameter("errorMessage", "");
					int num6 = cRMSpEntities.MobspIssueOrderFromPreOrder(model.PreOrderId, model.OrdDate.Replace("/", ""), model.OrdOprId, model.OrdPrintFormatId, model.OrderReferUserId, token2.userId, value2, value, text, appType, model.OrdNote, model.OrdSettlementTypeId, model.OrdDefaultSettingId, objectParameter, objectParameter2, result, model.OrdNoteLang, model.OrdProjectId, model.PordItemListJson, isTransferFreeComm: model.IsTransferFreeComm, isTransferFreePay: model.IsTransferFreePay, ordCompanyPersonId: model.OrdCompanyPersonId, ordIssueSettingByPrdId: model.OrdIssueSettingByPrdId, ordIssueIndexedByPrdId: model.OrdIssueIndexedByPrdId, centerId: model.CenterId);
					string s = objectParameter.Value.ToString();
					objectParameter2.Value.ToString();
					if (num6 > 0)
					{
						IssueOrderFromPreOrderResultViewModel issueOrderFromPreOrderResultViewModel2 = new IssueOrderFromPreOrderResultViewModel();
						if (objectParameter.Value != null)
						{
							issueOrderFromPreOrderResultViewModel2.InsertedOrderID = (int)objectParameter.Value;
						}
						else
						{
							issueOrderFromPreOrderResultViewModel2.InsertedOrderID = 0;
						}
						if (objectParameter2.Value != null)
						{
							issueOrderFromPreOrderResultViewModel2.InsertedOrderNumber = (long)objectParameter2.Value;
						}
						else
						{
							issueOrderFromPreOrderResultViewModel2.InsertedOrderNumber = 0L;
						}
						issueOrderFromPreOrderResultViewModel2.PordOrders = Enumerable.ToList<MobspReturnOrderFromPreOrder_Result>((IEnumerable<MobspReturnOrderFromPreOrder_Result>)cRMEntities.MobspReturnOrderFromPreOrder(model.PreOrderId, result, defLangId));
						issueOrderFromPreOrderResultViewModel2.PreOrderItems = Enumerable.ToList<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)cRMEntities.MobspSelectPreOrderItems(model.PreOrderId, result, defLangId));
						string text7 = "";
						if (UserLogin.IsUserAccess("frmIssueOrderFromPreOrder", "actAutoReferOrderToWrhsUserAfterIssue", UserLogin.CurrentUser, model.CenterId))
						{
							Order.ReferOrderToWrhsUser(issueOrderFromPreOrderResultViewModel2.InsertedOrderID, model.CenterId);
						}
						if (model.TransferPreOrderFileToOrder.GetValueOrDefault() && model.PreOrderId > 0 && !string.IsNullOrWhiteSpace(model.SelectedFilesDirectoryTypes))
						{
							List<MobspSelectFilesDirectory_Result> list8 = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory("", "", "", "10", model.PreOrderId.ToString(), num, defLangId, false, model.CenterId));
							List<SelectListItem> list9 = new List<SelectListItem>();
							string[] array = model.SelectedFilesDirectoryTypes.Split(new char[1] { '|' });
							foreach (string text8 in array)
							{
								if (!string.IsNullOrWhiteSpace(text8))
								{
									string[] array2 = text8.Split(new char[1] { '=' });
									list9.Add(new SelectListItem
									{
										Text = array2[0],
										Value = array2[1]
									});
								}
							}
							if (list8 != null && list8.Count > 0)
							{
								foreach (MobspSelectFilesDirectory_Result itm in list8)
								{
									SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list9, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == itm.FileDirectoryID.ToString()));
									if (selectListItem != null && string.IsNullOrEmpty(text7))
									{
										text7 += ftpCopyPordFilesToOrd(itm, issueOrderFromPreOrderResultViewModel2.InsertedOrderID, model.PreOrderId, itm.FileDirectoryID, int.Parse(selectListItem.Value), model.CenterId);
									}
								}
							}
						}
						if (!string.IsNullOrEmpty(text7))
						{
							issueOrderFromPreOrderResultViewModel2.Message = Messages.MobMsgErrorTransferFile + "</br>" + text7;
							data = issueOrderFromPreOrderResultViewModel2;
							message = null;
							status = ServiceResultStatus.Success;
						}
						else
						{
							string text9 = "";
							MobspReturnOrderFromPreOrder_Result mobspReturnOrderFromPreOrder_Result3 = new MobspReturnOrderFromPreOrder_Result();
							List<MobspReturnOrderFromPreOrder_Result> list10 = Enumerable.ToList<MobspReturnOrderFromPreOrder_Result>((IEnumerable<MobspReturnOrderFromPreOrder_Result>)cRMEntities.MobspReturnOrderFromPreOrder(model.PreOrderId, num, defLangId));
							text5 = "";
							if (list10 != null && Enumerable.Any<MobspReturnOrderFromPreOrder_Result>((IEnumerable<MobspReturnOrderFromPreOrder_Result>)list10))
							{
								mobspReturnOrderFromPreOrder_Result3 = Enumerable.LastOrDefault<MobspReturnOrderFromPreOrder_Result>((IEnumerable<MobspReturnOrderFromPreOrder_Result>)list10);
								if (list10.Count > 1)
								{
									foreach (MobspReturnOrderFromPreOrder_Result item9 in list10)
									{
										text5 = text5 + item9.ordNumber + ",";
									}
									if (!string.IsNullOrEmpty(text5) && text5.EndsWith(","))
									{
										text5 = text5.TrimEnd(new char[1] { ',' });
									}
								}
							}
							else
							{
								mobspReturnOrderFromPreOrder_Result3 = null;
							}
							if (mobspReturnOrderFromPreOrder_Result3 != null)
							{
								if (string.IsNullOrEmpty(text5))
								{
									text5 = mobspReturnOrderFromPreOrder_Result3.ordNumber.ToString();
								}
								text9 = Messages.msgIssueOrderFormPreOrderWasSuccessful + "\r\n" + Messages.msgIssueOrderFormPreOrderOrdNumber + " " + text5;
								MobspSelectOrderWithID_Result mobspSelectOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(mobspReturnOrderFromPreOrder_Result3.OrderID, token2.userId, num, defLangId, model.CenterId));
								if (mobspSelectOrderWithID_Result != null)
								{
									issueOrderFromPreOrderResultViewModel2.InsertedOrderProjectID = mobspSelectOrderWithID_Result.ordProjectId.GetValueOrDefault();
								}
								if (model.AddPrdValidity && !string.IsNullOrWhiteSpace(model.AddPrdValidityPrjTitle))
								{
									int result11 = 0;
									int.TryParse(s, out result11);
									if (result11 > 0)
									{
										string msg = "";
										Order.AddProjectProductHistoryFromOrder(result11, model.AddPrdValidity, model.AddPrdValidityPrjTitle, ref msg);
										if (!string.IsNullOrWhiteSpace(msg))
										{
											text9 = text9 + "\r\n" + msg;
										}
									}
								}
							}
							else
							{
								text9 = Messages.msgIssueOrderFormPreOrderWasSuccessful + "\r\n" + Messages.msgIssueOrderFormPreOrderOrdNumber + " " + issueOrderFromPreOrderResultViewModel2.InsertedOrderNumber;
								MobspSelectOrderWithID_Result mobspSelectOrderWithID_Result2 = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(issueOrderFromPreOrderResultViewModel2.InsertedOrderID, token2.userId, num, defLangId, model.CenterId));
								if (mobspSelectOrderWithID_Result2 != null)
								{
									issueOrderFromPreOrderResultViewModel2.InsertedOrderProjectID = mobspSelectOrderWithID_Result2.ordProjectId.GetValueOrDefault();
								}
								if (model.AddPrdValidity && !string.IsNullOrWhiteSpace(model.AddPrdValidityPrjTitle))
								{
									int result12 = 0;
									int.TryParse(s, out result12);
									if (result12 > 0)
									{
										string msg2 = "";
										Order.AddProjectProductHistoryFromOrder(result12, model.AddPrdValidity, model.AddPrdValidityPrjTitle, ref msg2);
										if (!string.IsNullOrWhiteSpace(msg2))
										{
											text9 = text9 + "\r\n" + msg2;
										}
									}
								}
							}
							issueOrderFromPreOrderResultViewModel2.Message = text9;
							data = issueOrderFromPreOrderResultViewModel2;
							message = null;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<IssueOrderFromPreOrderResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public string ftpCopyPordFilesToOrd(MobspSelectFilesDirectory_Result PordFileDir, int orderId, int pordId, int currFileDirId, int selectedFileDirType, int? centerId = null)
	{
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime value = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		int id = Financial.Get().Id;
		short value2 = short.Parse(Financial.Get().Id.ToString());
		short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Mobile.Classes.Configuration.AppType;
		if (PordFileDir != null && PordFileDir.FileDirectoryID > 0 && pordId > 0 && VersionBuyer.AttachFiles)
		{
			CRMEntities cRMEntities = (cRMEntities = new CRMEntities());
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", -1);
			cRMEntities.MobspTransferPreOrderFileToOrderOneToOne(PordFileDir.TypeOprObjectId, orderId, currFileDirId, selectedFileDirType, userId, id, value2, value3, value, registerDatePersian, appType, lCID, objectParameter, centerId);
			FilesManager filesManager = new FilesManager();
			FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
			string pathFtp = Mobile.Classes.Configuration.PathFtp;
			string userNameFtp = Mobile.Classes.Configuration.UserNameFtp;
			string passwordFtp = Mobile.Classes.Configuration.PasswordFtp;
			bool usePassiveFtp = Mobile.Classes.Configuration.UsePassiveFtp;
			string text2 = "";
			string text3 = "";
			if (!string.IsNullOrEmpty(PordFileDir.FilePath) && !string.IsNullOrEmpty(PordFileDir.FileName))
			{
				string[] array = PordFileDir.FileName.Split(new char[1] { '.' });
				string text4 = PordFileDir.FilePath.Replace(PordFileDir.FileName, "");
				text4 += (text4.EndsWith("/") ? "" : "/");
				string text5 = text4.Split(new char[1] { '/' })[^2];
				string text6 = text4.Replace(text5 + "/", "");
				string text7 = PordFileDir.FilePath.ToLower().Replace(Mobile.Classes.Configuration.PathFtp.ToLower(), "");
				text7 = Mobile.Classes.Configuration.MainDirectoryPath + PordFileDir.FolderName + "/" + PordFileDir.FileName;
				if (text7 != "")
				{
					text2 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
					if (filesManager.CreateDirectory(text2))
					{
						text3 = HttpContext.Current.Server.MapPath(text2 + "/" + objectParameter.Value.ToString());
						if (!facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text3, text7, overwrite: true, usePassiveFtp))
						{
							if (!string.IsNullOrEmpty(text3))
							{
								text3 = HttpContext.Current.Server.MapPath(text2 + "/");
								if (Directory.Exists(text3))
								{
									DirectoryInfo directoryInfo = new DirectoryInfo(text3);
									FileInfo[] files = directoryInfo.GetFiles();
									for (int i = 0; i < files.Length; i++)
									{
										files[i].Delete();
									}
									DirectoryInfo[] directories = directoryInfo.GetDirectories();
									for (int i = 0; i < directories.Length; i++)
									{
										directories[i].Delete(recursive: true);
									}
									if (Directory.Exists(text3))
									{
										Directory.Delete(text3);
									}
								}
							}
							text3 = "";
							try
							{
								cRMEntities.MobspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
							}
						}
					}
				}
				if (!string.IsNullOrEmpty(text3))
				{
					bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text6, text5, usePassiveFtp);
					if (!flag)
					{
						flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text6, text5, usePassiveFtp);
					}
					if (flag)
					{
						string text8 = orderId + "-" + objectParameter.Value.ToString() + "." + array[^1];
						if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text4 + text8, text3, usePassiveFtp))
						{
							string text9 = Mobile.Classes.Configuration.PathFtp + text4 + text8;
							string fileName = text8;
							text9 = text9.Trim().Replace(Mobile.Classes.Configuration.PathFtp, "");
							List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
							string fileTitle_lang = "";
							List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
							string fileDesc_lang = "";
							List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
							foreach (MobspSelectLanguages_Result item in Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)list, (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result c) => c.LanguageID != defLangID))))
							{
								list2.Add(new CommonMultiLanguageViewModel
								{
									Value = PordFileDir.Title,
									LanguageId = item.LanguageID
								});
								list3.Add(new CommonMultiLanguageViewModel
								{
									Value = PordFileDir.FileDesc,
									LanguageId = item.LanguageID
								});
							}
							if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
							{
								fileTitle_lang = JsonConvert.SerializeObject(list2);
							}
							ObjectParameter insertedFileDirectoryId = new ObjectParameter("insertedFileDirectoryId", 0);
							ObjectParameter errorMessage = new ObjectParameter("errorMessage", "");
							Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertCrmFilesDirectory(PordFileDir.FileDirectoryID, PordFileDir.FileDirectoryTypeId, PordFileDir.MasterId, PordFileDir.DetailId, PordFileDir.SubDetailId, PordFileDir.Title, PordFileDir.FolderName, fileName, text9, PordFileDir.CopyFromPath, PordFileDir.DocDate, PordFileDir.DocDay, PordFileDir.DocTime, PordFileDir.TypeOprObjectId, PordFileDir.FileDirectoryNumRef, PordFileDir.FileFOCmpCanSee, PordFileDir.FirstRegisterUserId, PordFileDir.FirstRegisterDatePersian, PordFileDir.UserId, value2, value3, value, registerDatePersian, appType, lCID, defLangID, insertedFileDirectoryId, errorMessage, centerId, PordFileDir.FileDesc, fileTitle_lang, fileDesc_lang));
							if (!string.IsNullOrEmpty(text3))
							{
								text3 = HttpContext.Current.Server.MapPath(text2 + "/");
								if (Directory.Exists(text3))
								{
									DirectoryInfo directoryInfo2 = new DirectoryInfo(text3);
									FileInfo[] files = directoryInfo2.GetFiles();
									for (int i = 0; i < files.Length; i++)
									{
										files[i].Delete();
									}
									DirectoryInfo[] directories = directoryInfo2.GetDirectories();
									for (int i = 0; i < directories.Length; i++)
									{
										directories[i].Delete(recursive: true);
									}
									if (Directory.Exists(text3))
									{
										Directory.Delete(text3);
									}
								}
							}
						}
						else
						{
							Exception e2 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Mobile.Classes.Configuration.PathFtp + " ,username: " + Mobile.Classes.Configuration.UserNameFtp + " ,destination: " + text6 + " ,directoryName: " + text5);
							ErrorSignal.FromCurrentContext().Raise(e2);
							text = text + "|" + Messages.frmErrorInSendingFile;
							try
							{
								cRMEntities.MobspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							if (!string.IsNullOrEmpty(text3))
							{
								text3 = HttpContext.Current.Server.MapPath(text2 + "/");
								if (Directory.Exists(text3))
								{
									DirectoryInfo directoryInfo3 = new DirectoryInfo(text3);
									FileInfo[] files = directoryInfo3.GetFiles();
									for (int i = 0; i < files.Length; i++)
									{
										files[i].Delete();
									}
									DirectoryInfo[] directories = directoryInfo3.GetDirectories();
									for (int i = 0; i < directories.Length; i++)
									{
										directories[i].Delete(recursive: true);
									}
									if (Directory.Exists(text3))
									{
										Directory.Delete(text3);
									}
								}
							}
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.msgErrorUploadingFileInFtp + " -  hostname: " + Mobile.Classes.Configuration.PathFtp + " ,username: " + Mobile.Classes.Configuration.UserNameFtp + " ,destination: " + text6 + " ,directoryName: " + text5);
						ErrorSignal.FromCurrentContext().Raise(e4);
						text = text + "|" + Messages.frmErrorInSendingFile;
						try
						{
							cRMEntities.MobspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
						}
						catch (Exception e5)
						{
							ErrorSignal.FromCurrentContext().Raise(e5);
						}
						if (!string.IsNullOrEmpty(text3))
						{
							text3 = HttpContext.Current.Server.MapPath(text2 + "/");
							if (Directory.Exists(text3))
							{
								DirectoryInfo directoryInfo4 = new DirectoryInfo(text3);
								FileInfo[] files = directoryInfo4.GetFiles();
								for (int i = 0; i < files.Length; i++)
								{
									files[i].Delete();
								}
								DirectoryInfo[] directories = directoryInfo4.GetDirectories();
								for (int i = 0; i < directories.Length; i++)
								{
									directories[i].Delete(recursive: true);
								}
								if (Directory.Exists(text3))
								{
									Directory.Delete(text3);
								}
							}
						}
					}
				}
				else
				{
					try
					{
						cRMEntities.MobspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
					}
					catch (Exception e6)
					{
						ErrorSignal.FromCurrentContext().Raise(e6);
					}
					text = text + "|" + Messages.frmErrorInSendingFile;
				}
			}
		}
		return text;
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectDeliveryScheduleByDayNumberAndDate_Result>> SelectDeliveryScheduleByDayNumberAndDate(int dayNumber, string date, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectDeliveryScheduleByDayNumberAndDate_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					DateTime now = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(date))
						{
							ServiceResult<List<MobspSelectDeliveryScheduleByDayNumberAndDate_Result>> result3 = new ServiceResult<List<MobspSelectDeliveryScheduleByDayNumberAndDate_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						date = date.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspSelectDeliveryScheduleByDayNumberAndDate_Result>> result4 = new ServiceResult<List<MobspSelectDeliveryScheduleByDayNumberAndDate_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectDeliveryScheduleByDayNumberAndDate_Result>((IEnumerable<MobspSelectDeliveryScheduleByDayNumberAndDate_Result>)cRMEntities.MobspSelectDeliveryScheduleByDayNumberAndDate(dayNumber, now, num, result2));
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectDeliveryScheduleByDayNumberAndDate_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectDiscountCodeByDisCode_Result> SelectDiscountCodeByDisCode(string DisCode, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectDiscountCodeByDisCode_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<MobspSelectDiscountCodeByDisCode_Result>((IEnumerable<MobspSelectDiscountCodeByDisCode_Result>)cRMEntities.MobspSelectDiscountCodeByDisCode(DisCode, result, result2));
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
		return new ServiceResult<MobspSelectDiscountCodeByDisCode_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> InsertDiscountCodeHistory(int DiscountCodeId, string DisCode, int? DisCmpId, int? DisPrdId, int pordId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int value2 = int.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					ObjectParameter insertedId = new ObjectParameter("InsertedId", 0);
					cRMEntities.MobspInsertDiscountCodeHistory(DiscountCodeId, DisCode, DisCmpId, DisPrdId, pordId, token2.userId, value2, value3, value, registerDatePersian, appType, result, insertedId);
					data = true;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectVerifiedPreOrdersByCmpId_Result>> SelectVerifiedPreOrdersByCmpId(int companyId, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerifiedPreOrdersByCmpId_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectVerifiedPreOrdersByCmpId_Result>((IEnumerable<MobspSelectVerifiedPreOrdersByCmpId_Result>)cRMEntities.MobspSelectVerifiedPreOrdersByCmpId(companyId, pageNumber, pageSize, token2.userId, result, result2, cId));
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
		return new ServiceResult<List<MobspSelectVerifiedPreOrdersByCmpId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result>> SelectVerifiedPreOrdersWithoutOrderByCmpId(int companyId, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result>((IEnumerable<MobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result>)cRMEntities.MobspSelectVerifiedPreOrdersWithoutOrderByCmpId(companyId, pageNumber, pageSize, token2.userId, result, result2, cId));
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
		return new ServiceResult<List<MobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectNotVerifiedPreOrdersByCmpId_Result>> SelectNotVerifiedPreOrdersByCmpId(int companyId, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectNotVerifiedPreOrdersByCmpId_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectNotVerifiedPreOrdersByCmpId_Result>((IEnumerable<MobspSelectNotVerifiedPreOrdersByCmpId_Result>)cRMEntities.MobspSelectNotVerifiedPreOrdersByCmpId(companyId, pageNumber, pageSize, token2.userId, result, result2, cId));
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
		return new ServiceResult<List<MobspSelectNotVerifiedPreOrdersByCmpId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectPreOrderItems_Result>> SelectPreOrderItems(int pordId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectPreOrderItems_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)cRMEntities.MobspSelectPreOrderItems(pordId, result, result2));
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
		return new ServiceResult<List<MobspSelectPreOrderItems_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectPreOrderPayments_Result>> SelectPreOrderPayments(int pordId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectPreOrderPayments_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectPreOrderPayments_Result>((IEnumerable<MobspSelectPreOrderPayments_Result>)cRMEntities.MobspSelectPreOrderPayments(pordId, result, result2));
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
		return new ServiceResult<List<MobspSelectPreOrderPayments_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<IssueDuplicatePreOrderViewModel> IssueDuplicatePreOrder(int pordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		IssueDuplicatePreOrderViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					ObjectParameter objectParameter = new ObjectParameter("InsertedPreOrderId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedPordNumber", typeof(long));
					ObjectParameter objectParameter3 = new ObjectParameter("InsertedPordNumberRevision", typeof(long));
					ObjectParameter objectParameter4 = new ObjectParameter("ErrorMessage", "");
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspIssueDuplicatePreOrder(pordId, token2.userId, value2, value, registerDatePersian, appType, objectParameter, objectParameter2, objectParameter3, objectParameter4, cId));
					IssueDuplicatePreOrderViewModel issueDuplicatePreOrderViewModel = new IssueDuplicatePreOrderViewModel();
					if (objectParameter4.Value != null)
					{
						if (objectParameter4.Value.ToString() != "")
						{
							string text = objectParameter4.Value.ToString();
							text = text.Replace("|Msg=0", Messages.MobMsgErrorInsertPreOrder);
							text = text.Replace("|pordNumberIsDup", Messages.MobMsgPreOrderNumberIsRepeated);
							text = text.Replace("Msg=1", Messages.MobMsgErrorInconsistencyInPordSelection);
							text = text.Replace("Msg=5", Messages.MobMsgProductLackOfStock);
							text = text.Replace("Msg=2", Messages.MobMsgErrorInsertProduct);
							text = text.Replace("Msg=3", Messages.MobMsgErrorInsertProductSpcf);
							issueDuplicatePreOrderViewModel.ErrorMessage = text;
						}
						else
						{
							issueDuplicatePreOrderViewModel.ErrorMessage = "";
						}
					}
					if (objectParameter.Value != null)
					{
						issueDuplicatePreOrderViewModel.InsertedPreOrderId = (int)objectParameter.Value;
					}
					else
					{
						issueDuplicatePreOrderViewModel.InsertedPreOrderId = 0;
					}
					if (objectParameter2.Value != null)
					{
						issueDuplicatePreOrderViewModel.InsertedPordNumber = (long)objectParameter2.Value;
					}
					else
					{
						issueDuplicatePreOrderViewModel.InsertedPordNumber = 0L;
					}
					if (objectParameter3.Value != null)
					{
						issueDuplicatePreOrderViewModel.InsertedPordNumberRevision = (long)objectParameter3.Value;
					}
					else
					{
						issueDuplicatePreOrderViewModel.InsertedPordNumberRevision = 0L;
					}
					if (string.IsNullOrEmpty(issueDuplicatePreOrderViewModel.ErrorMessage) && issueDuplicatePreOrderViewModel.InsertedPreOrderId > 0)
					{
						if (issueDuplicatePreOrderViewModel.InsertedPreOrderId > 0 && VersionBuyer.AttachFiles)
						{
							FilesManager filesManager = new FilesManager();
							FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
							string pathFtp = Mobile.Classes.Configuration.PathFtp;
							string userNameFtp = Mobile.Classes.Configuration.UserNameFtp;
							string passwordFtp = Mobile.Classes.Configuration.PasswordFtp;
							bool usePassiveFtp = Mobile.Classes.Configuration.UsePassiveFtp;
							foreach (MobspSelectFilesDirectory_Result item in Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory("", "", "", "10", issueDuplicatePreOrderViewModel.InsertedPreOrderId.ToString(), result, result2, false, cId)))
							{
								string text2 = "";
								string text3 = "";
								if (string.IsNullOrEmpty(item.FilePath) || string.IsNullOrEmpty(item.FileName))
								{
									continue;
								}
								string[] array = item.FileName.Split(new char[1] { '.' });
								string text4 = item.FilePath.Replace(item.FileName, "");
								text4 += (text4.EndsWith("/") ? "" : "/");
								string text5 = text4.Split(new char[1] { '/' })[^2];
								string text6 = text4.Replace(text5 + "/", "");
								string text7 = item.FilePath.ToLower().Replace(Mobile.Classes.Configuration.PathFtp.ToLower(), "");
								text7 = Mobile.Classes.Configuration.MainDirectoryPath + item.FolderName + "/" + item.FileName;
								if (text7 != "")
								{
									text2 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
									if (filesManager.CreateDirectory(text2))
									{
										text3 = HttpContext.Current.Server.MapPath(text2 + "/" + item.FileName);
										if (!facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text3, text7, overwrite: true, usePassiveFtp))
										{
											if (!string.IsNullOrEmpty(text3))
											{
												text3 = HttpContext.Current.Server.MapPath(text2 + "/");
												if (Directory.Exists(text3))
												{
													DirectoryInfo directoryInfo = new DirectoryInfo(text3);
													FileInfo[] files = directoryInfo.GetFiles();
													for (int i = 0; i < files.Length; i++)
													{
														files[i].Delete();
													}
													DirectoryInfo[] directories = directoryInfo.GetDirectories();
													for (int i = 0; i < directories.Length; i++)
													{
														directories[i].Delete(recursive: true);
													}
													if (Directory.Exists(text3))
													{
														Directory.Delete(text3);
													}
												}
											}
											text3 = "";
											try
											{
												cRMEntities.MobspDeleteCrmFilesDirectory(item.FileDirectoryID);
											}
											catch (Exception e)
											{
												ErrorSignal.FromCurrentContext().Raise(e);
											}
										}
									}
								}
								if (!string.IsNullOrEmpty(text3))
								{
									bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text6, text5, usePassiveFtp);
									if (!flag)
									{
										flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text6, text5, usePassiveFtp);
									}
									if (flag)
									{
										string text8 = item.TypeOprObjectId + "-" + item.FileDirectoryID + "." + array[^1];
										if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text4 + text8, text3, usePassiveFtp))
										{
											string text9 = Mobile.Classes.Configuration.PathFtp + text4 + text8;
											string fileName = text8;
											MobspSelectCrmFilesDirectory_Result mobspSelectCrmFilesDirectory_Result = Enumerable.FirstOrDefault<MobspSelectCrmFilesDirectory_Result>((IEnumerable<MobspSelectCrmFilesDirectory_Result>)cRMEntities.MobspSelectCrmFilesDirectory(item.FileDirectoryID));
											if (mobspSelectCrmFilesDirectory_Result != null)
											{
												ObjectParameter updatedFileDirectoryId = new ObjectParameter("UpdatedFileDirectoryId", 0);
												ObjectParameter errorMessage = new ObjectParameter("ErrorMessage", "");
												text9 = text9.Trim().Replace(Mobile.Classes.Configuration.PathFtp, "");
												mobspSelectCrmFilesDirectory_Result.FilePath = text9;
												mobspSelectCrmFilesDirectory_Result.FileName = fileName;
												cRMEntities.MobspUpdateFileDirectory(mobspSelectCrmFilesDirectory_Result.FileDirectoryID, mobspSelectCrmFilesDirectory_Result.FileDirectoryTypeId, mobspSelectCrmFilesDirectory_Result.Title, mobspSelectCrmFilesDirectory_Result.UserId, mobspSelectCrmFilesDirectory_Result.Year1, mobspSelectCrmFilesDirectory_Result.Month1, mobspSelectCrmFilesDirectory_Result.RegisterDate, mobspSelectCrmFilesDirectory_Result.RegisterDatePersian, mobspSelectCrmFilesDirectory_Result.DocDate, mobspSelectCrmFilesDirectory_Result.DocDateTime, mobspSelectCrmFilesDirectory_Result.DocDay, mobspSelectCrmFilesDirectory_Result.DocTime, mobspSelectCrmFilesDirectory_Result.AppType, result2, updatedFileDirectoryId, errorMessage, mobspSelectCrmFilesDirectory_Result.FileDesc);
											}
											if (string.IsNullOrEmpty(text3))
											{
												continue;
											}
											text3 = HttpContext.Current.Server.MapPath(text2 + "/");
											if (Directory.Exists(text3))
											{
												DirectoryInfo directoryInfo2 = new DirectoryInfo(text3);
												FileInfo[] files = directoryInfo2.GetFiles();
												for (int i = 0; i < files.Length; i++)
												{
													files[i].Delete();
												}
												DirectoryInfo[] directories = directoryInfo2.GetDirectories();
												for (int i = 0; i < directories.Length; i++)
												{
													directories[i].Delete(recursive: true);
												}
												if (Directory.Exists(text3))
												{
													Directory.Delete(text3);
												}
											}
											continue;
										}
										Exception e2 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Mobile.Classes.Configuration.PathFtp + " ,username: " + Mobile.Classes.Configuration.UserNameFtp + " ,destination: " + text6 + " ,directoryName: " + text5);
										ErrorSignal.FromCurrentContext().Raise(e2);
										issueDuplicatePreOrderViewModel.ErrorMessage = Messages.frmErrorInSendingFile;
										try
										{
											cRMEntities.MobspDeleteCrmFilesDirectory(item.FileDirectoryID);
										}
										catch (Exception e3)
										{
											ErrorSignal.FromCurrentContext().Raise(e3);
										}
										if (string.IsNullOrEmpty(text3))
										{
											continue;
										}
										text3 = HttpContext.Current.Server.MapPath(text2 + "/");
										if (Directory.Exists(text3))
										{
											DirectoryInfo directoryInfo3 = new DirectoryInfo(text3);
											FileInfo[] files = directoryInfo3.GetFiles();
											for (int i = 0; i < files.Length; i++)
											{
												files[i].Delete();
											}
											DirectoryInfo[] directories = directoryInfo3.GetDirectories();
											for (int i = 0; i < directories.Length; i++)
											{
												directories[i].Delete(recursive: true);
											}
											if (Directory.Exists(text3))
											{
												Directory.Delete(text3);
											}
										}
										continue;
									}
									Exception e4 = new Exception(Messages.msgErrorUploadingFileInFtp + " -  hostname: " + Mobile.Classes.Configuration.PathFtp + " ,username: " + Mobile.Classes.Configuration.UserNameFtp + " ,destination: " + text6 + " ,directoryName: " + text5);
									ErrorSignal.FromCurrentContext().Raise(e4);
									issueDuplicatePreOrderViewModel.ErrorMessage = Messages.frmErrorInSendingFile;
									try
									{
										cRMEntities.MobspDeleteCrmFilesDirectory(item.FileDirectoryID);
									}
									catch (Exception e5)
									{
										ErrorSignal.FromCurrentContext().Raise(e5);
									}
									if (string.IsNullOrEmpty(text3))
									{
										continue;
									}
									text3 = HttpContext.Current.Server.MapPath(text2 + "/");
									if (Directory.Exists(text3))
									{
										DirectoryInfo directoryInfo4 = new DirectoryInfo(text3);
										FileInfo[] files = directoryInfo4.GetFiles();
										for (int i = 0; i < files.Length; i++)
										{
											files[i].Delete();
										}
										DirectoryInfo[] directories = directoryInfo4.GetDirectories();
										for (int i = 0; i < directories.Length; i++)
										{
											directories[i].Delete(recursive: true);
										}
										if (Directory.Exists(text3))
										{
											Directory.Delete(text3);
										}
									}
								}
								else
								{
									try
									{
										cRMEntities.MobspDeleteCrmFilesDirectory(item.FileDirectoryID);
									}
									catch (Exception e6)
									{
										ErrorSignal.FromCurrentContext().Raise(e6);
									}
									issueDuplicatePreOrderViewModel.ErrorMessage = Messages.frmErrorInSendingFile;
								}
							}
						}
						else if (issueDuplicatePreOrderViewModel.InsertedPreOrderId > 0 && !VersionBuyer.AttachFiles)
						{
							foreach (MobspSelectFilesDirectory_Result item2 in Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory("", "", "", "10", issueDuplicatePreOrderViewModel.InsertedPreOrderId.ToString(), result, result2, false, cId)))
							{
								try
								{
									cRMEntities.MobspDeleteCrmFilesDirectory(item2.FileDirectoryID);
								}
								catch (Exception e7)
								{
									ErrorSignal.FromCurrentContext().Raise(e7);
								}
							}
						}
					}
					if (num.HasValue)
					{
						if (!string.IsNullOrEmpty(issueDuplicatePreOrderViewModel.ErrorMessage))
						{
							data = issueDuplicatePreOrderViewModel;
							message = issueDuplicatePreOrderViewModel.ErrorMessage;
							status = ServiceResultStatus.Fail;
						}
						else
						{
							data = issueDuplicatePreOrderViewModel;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						data = issueDuplicatePreOrderViewModel;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
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
		catch (Exception e8)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e8);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<IssueDuplicatePreOrderViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> DistributeDiscountToPreOrderItems(DistributeDiscountViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int value2 = int.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					_ = Labels.MobLackOfShowText;
					ObjectParameter objectParameter = new ObjectParameter("Result", 0);
					cRMEntities.MobspDistributeDiscountToPreOrderItems(model.MasterId, model.ItemIds, model.Discount, model.DiscountPercent, token2.userId, value2, value3, value, registerDatePersian, appType, objectParameter, result, result2, model.AddToDiscount, model.DiscountCodeId, model.CenterId);
					if (int.Parse(objectParameter.Value.ToString()) > 0)
					{
						data = true;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = true;
						message = Messages.msgErrorRunFunction;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectPreOrderWithID_Result> SelectPreOrderWithID(int preOrderId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(preOrderId, token2.userId, result, result2, cId));
					if (mobspSelectPreOrderWithID_Result != null)
					{
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorCantFindPreOrder;
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					mobspSelectPreOrderWithID_Result = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				mobspSelectPreOrderWithID_Result = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			mobspSelectPreOrderWithID_Result = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<MobspSelectPreOrderWithID_Result>
		{
			Message = message,
			Data = mobspSelectPreOrderWithID_Result,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> SelectMobPreOrderCnt()
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspSelectMobPreOrderCnt()).GetValueOrDefault();
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> UpdatePreOrderExpireDate(int preOrderId, int? ln = null)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string pordExpireDate = now.ToString("yyyyMMdd", new PersianCulture());
					CRMEntities cRMEntities2 = cRMEntities;
					int? preOrderId2 = preOrderId;
					DateTime? pordExpireDateTime = value;
					cRMEntities2.MobspUpdatePreOrderExpireDate(preOrderId2, pordExpireDate, pordExpireDateTime, num, result);
					data = true;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectExpiredPreOrders_Result>> SelectExpiredPreOrders(int companyId, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		List<MobspSelectExpiredPreOrders_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					CRMEntities cRMEntities2 = cRMEntities;
					int? companyId2 = companyId;
					int? userId = token2.userId;
					data = Enumerable.ToList<MobspSelectExpiredPreOrders_Result>((IEnumerable<MobspSelectExpiredPreOrders_Result>)cRMEntities2.MobspSelectExpiredPreOrders(companyId2, pageNumber, pageSize, userId, num, result, cId));
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
		return new ServiceResult<List<MobspSelectExpiredPreOrders_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>> SelectNotVerifiedPreOrdersByCmpIdAndExpireDate(int companyId, string expireDate, string expireTime, int? pageNumber = 1, int? pageSize = 10, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					DateTime value;
					try
					{
						if (!string.IsNullOrEmpty(expireDate))
						{
							expireDate = expireDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							value = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(expireDate) + " " + expireTime, new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(expireDate) + " " + expireTime));
						}
						else
						{
							value = DateTime.Now;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>> result3 = new ServiceResult<List<MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>((IEnumerable<MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>)cRMEntities.MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate(companyId, value, pageNumber, pageSize, token2.userId, result, result2));
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> CheckPrdGroupMustExistInPreOrder(int projectId, int? ln = null)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					List<MobspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result> list = Enumerable.ToList<MobspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result>((IEnumerable<MobspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result>)cRMEntities.MobspCheckPrdGroupMustExistInPreOrderBycmpPrjId(projectId));
					if (Enumerable.Any<MobspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result>((IEnumerable<MobspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result>)list) && list.Count > 0)
					{
						data = 1;
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = -1;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = -1;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = -1;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> DistributeTaxToPreOrderItems(DistributeTaxViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int value2 = int.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					_ = Labels.MobLackOfShowText;
					ObjectParameter objectParameter = new ObjectParameter("Result", 0);
					cRMEntities.MobspDistributeTaxToPreOrderItems(model.MasterId, model.ItemIds, model.Tax, model.TaxIndex, token2.userId, value2, value3, value, registerDatePersian, appType, objectParameter, result, result2, model.AddToTax);
					if (int.Parse(objectParameter.Value.ToString()) > 0)
					{
						data = true;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = true;
						message = Messages.msgErrorRunFunction;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnOrderFromPreOrder_Result>> ReturnOrderFromPreOrder(int pordId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspReturnOrderFromPreOrder_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspReturnOrderFromPreOrder_Result>((IEnumerable<MobspReturnOrderFromPreOrder_Result>)cRMEntities.MobspReturnOrderFromPreOrder(pordId, result, result2));
					message = Messages.msgSuccessAction;
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
		return new ServiceResult<List<MobspReturnOrderFromPreOrder_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnOrderItemQuantityByPordItemId_Result> ReturnOrderItemQuantityByPordItemId(int pordItemId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspReturnOrderItemQuantityByPordItemId_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<MobspReturnOrderItemQuantityByPordItemId_Result>((IEnumerable<MobspReturnOrderItemQuantityByPordItemId_Result>)cRMEntities.MobspReturnOrderItemQuantityByPordItemId(pordItemId));
					message = Messages.msgSuccessAction;
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
		return new ServiceResult<MobspReturnOrderItemQuantityByPordItemId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> CheckPrdGroupSameInPreOrder(int pordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (UserLogin.IsUserAccess("frmPreOrder", "actMustPrdGroupSame", UserLogin.CurrentUser, cId))
					{
						List<MobspCheckPrdGroupSameInPreOrder_Result> list = Enumerable.ToList<MobspCheckPrdGroupSameInPreOrder_Result>((IEnumerable<MobspCheckPrdGroupSameInPreOrder_Result>)cRMEntities.MobspCheckPrdGroupSameInPreOrder(pordId, result, result2));
						if (list != null && Enumerable.Any<MobspCheckPrdGroupSameInPreOrder_Result>((IEnumerable<MobspCheckPrdGroupSameInPreOrder_Result>)list))
						{
							data = 1;
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> ChangePreOrderItemPrice(ChangePreOrderItemPriceViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (!UserLogin.IsUserAccess("frmPreOrder", "actChangePriceInPordItems", UserLogin.CurrentUser, model.CenterId))
					{
						return new ServiceResult<bool>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = false,
							Status = ServiceResultStatus.Fail
						};
					}
					if (PreOrder.IsFixed(model.PreOrderId, result, token2.userId, model.CenterId))
					{
						return new ServiceResult<bool>
						{
							Message = Messages.msgErrorNotActiveProd,
							Data = false,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int value2 = int.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					_ = Labels.MobLackOfShowText;
					int userId = token2.userId;
					ObjectParameter objectParameter = new ObjectParameter("Result", 0);
					cRMEntities.MobspChangePriceInPreOrderItems(model.PreOrderId, model.Mode, model.ItemIds, model.Amount, model.PricePercent, userId, value2, value3, value, registerDatePersian, appType, objectParameter);
					if (int.Parse(objectParameter.Value.ToString()) > 0)
					{
						data = true;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = true;
						message = Messages.msgErrorRunFunction;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectDiscountCodeByDisCode_Result> AddDiscountCode(string disCode, int pordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		MobspSelectDiscountCodeByDisCode_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, token2.userId, num, result2, cId));
					if (mobspSelectPreOrderWithID_Result != null)
					{
						ServiceResult<MobspSelectDiscountCodeByDisCode_Result> serviceResult = DiscountCode.CheckDiscountCodeToUse(disCode, mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault(), num, result2, cId);
						if (serviceResult.Status != ServiceResultStatus.Success)
						{
							status = serviceResult.Status;
							message = serviceResult.Message;
						}
						else
						{
							List<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result> list = Enumerable.ToList<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result>)cRMSpEntities.MobspSelectPreOrderItemsByNotInSumAndNoDis(pordId, false, false, num, result2));
							if (list == null || Enumerable.FirstOrDefault<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result>)list, (Func<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result, bool>)((MobspSelectPreOrderItemsByNotInSumAndNoDis_Result x) => x.pordIDiscountCodeId > 0)) != null)
							{
								status = ServiceResultStatus.Error;
								message = Messages.msgErrorCannotAddSecondDisCode;
							}
							else
							{
								_ = mobspSelectPreOrderWithID_Result.CompanyName;
								MobspSelectDiscountCodeByDisCode_Result data2 = serviceResult.Data;
								if (data2 == null)
								{
									status = ServiceResultStatus.Error;
									message = Messages.msgErrorDisCodeIncorrect;
								}
								else
								{
									string arg = data2.DisPrdName ?? "";
									int disPrdId = 0;
									int.TryParse(data2.DisPrdId.ToString(), out disPrdId);
									bool flag = true;
									if (disPrdId != 0 && Enumerable.FirstOrDefault<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result>)list, (Func<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result, bool>)((MobspSelectPreOrderItemsByNotInSumAndNoDis_Result m) => m.pordIPrdId == disPrdId)) == null)
									{
										flag = false;
									}
									if (flag)
									{
										data = data2;
										status = ServiceResultStatus.Success;
										message = "";
									}
									else
									{
										message = string.Format(Messages.msgErrorDisCodeItemNoPrd, arg, "lblOrd".OrderLabels());
									}
								}
							}
						}
					}
					else
					{
						message = Messages.ErrorNotFound;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<MobspSelectDiscountCodeByDisCode_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectDiscountCodeByDisCode_Result> AddDiscountCode_old(string disCode, int pordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		MobspSelectDiscountCodeByDisCode_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, token2.userId, num, result2, cId));
					if (mobspSelectPreOrderWithID_Result != null)
					{
						string arg = mobspSelectPreOrderWithID_Result.pordCompany ?? "";
						if (!string.IsNullOrWhiteSpace(disCode))
						{
							MobspSelectDiscountCodeByDisCode_Result mobspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<MobspSelectDiscountCodeByDisCode_Result>((IEnumerable<MobspSelectDiscountCodeByDisCode_Result>)cRMEntities.MobspSelectDiscountCodeByDisCode(disCode, num, result2));
							if (mobspSelectDiscountCodeByDisCode_Result != null)
							{
								string arg2 = mobspSelectDiscountCodeByDisCode_Result.DisPrdName ?? "";
								int valueOrDefault = mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault();
								int result3 = 0;
								int.TryParse(mobspSelectDiscountCodeByDisCode_Result.DisCmpId.ToString(), out result3);
								if (result3 == 0 || result3 == valueOrDefault)
								{
									_ = mobspSelectDiscountCodeByDisCode_Result.DisExpDate;
									string s = mobspSelectDiscountCodeByDisCode_Result.DisExpDate.ToString("yyyyMMdd");
									string s2 = DateTime.Now.ToString("yyyyMMdd");
									if (long.Parse(s) >= long.Parse(s2))
									{
										int result4 = 0;
										int.TryParse(mobspSelectDiscountCodeByDisCode_Result.DisUseCnt.ToString(), out result4);
										int result5 = 0;
										int.TryParse(mobspSelectDiscountCodeByDisCode_Result.UsedCount.ToString(), out result5);
										if (result4 > result5)
										{
											int disPrdId = 0;
											int.TryParse(mobspSelectDiscountCodeByDisCode_Result.DisPrdId.ToString(), out disPrdId);
											bool flag = true;
											if (disPrdId != 0)
											{
												List<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result> list = Enumerable.ToList<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result>)cRMSpEntities.MobspSelectPreOrderItemsByNotInSumAndNoDis(pordId, false, false, num, result2));
												if (list != null && Enumerable.FirstOrDefault<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result>)list, (Func<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result, bool>)((MobspSelectPreOrderItemsByNotInSumAndNoDis_Result m) => m.pordIPrdId == disPrdId)) == null)
												{
													flag = false;
												}
											}
											if (flag)
											{
												double result6 = 0.0;
												double.TryParse(mobspSelectDiscountCodeByDisCode_Result.ScoreRate.ToString(), out result6);
												bool flag2 = true;
												if (result6 != 0.0)
												{
													double result7 = 0.0;
													double result8 = 0.0;
													MobspReturnSumCompanyScores_Result mobspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<MobspReturnSumCompanyScores_Result>((IEnumerable<MobspReturnSumCompanyScores_Result>)cRMSpEntities.MobspReturnSumCompanyScores(valueOrDefault, cId));
													if (mobspReturnSumCompanyScores_Result != null)
													{
														double.TryParse(mobspReturnSumCompanyScores_Result.SumScores.ToString(), out result7);
														double.TryParse(mobspReturnSumCompanyScores_Result.SumUsableScores.ToString(), out result8);
													}
													if (result6 > result8)
													{
														flag2 = false;
													}
												}
												if (flag2)
												{
													data = mobspSelectDiscountCodeByDisCode_Result;
													message = "";
													status = ServiceResultStatus.Success;
												}
												else
												{
													message = string.Format(Messages.msgErrorDisCodeNoScoreMin, result6.ToString());
													status = ServiceResultStatus.Error;
												}
											}
											else
											{
												message = string.Format(Messages.msgErrorDisCodeItemNoPrd, arg2, Labels.lblPOrd);
												status = ServiceResultStatus.Error;
											}
										}
										else
										{
											message = Messages.msgErrorDisCodeUsedBefore;
											status = ServiceResultStatus.Error;
										}
									}
									else
									{
										message = Messages.msgErrorDisCodeExpired;
										status = ServiceResultStatus.Error;
									}
								}
								else
								{
									message = string.Format(Messages.msgErrorDisCodeUnUsableForCmp, arg);
									status = ServiceResultStatus.Error;
								}
							}
							else
							{
								message = Messages.msgErrorDisCodeIncorrect;
								status = ServiceResultStatus.Error;
							}
						}
						else
						{
							message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.DistributeDiscountCode);
							status = ServiceResultStatus.Error;
						}
					}
					else
					{
						message = Messages.ErrorNotFound;
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
		return new ServiceResult<MobspSelectDiscountCodeByDisCode_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> UpdateProjectFromIssueOrderFromPreOrder(UpdateProjectFromIssueOrderFromPreOrderViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					ObjectParameter objectParameter = new ObjectParameter("ResErrorMessage", "");
					cRMSpEntities.MobspUpdateProjectFromIssueOrderFromPreOrder(model.ProjectParams, token2.userId, value2, value, registerDatePersian, appType, num, result2, objectParameter);
					string text = "";
					if (objectParameter != null && objectParameter.Value != null)
					{
						text = objectParameter.Value.ToString();
					}
					if (string.IsNullOrEmpty(text))
					{
						data = 0;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = 0;
						message = text;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> AddPrdValidityToPrjPrdH(int ordId, string prjTitle, int? ln = null)
	{
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					if (ordId == 0)
					{
						return new ServiceResult<string>
						{
							Message = string.Format(Messages.msgErrorIsNotSpecified, "lblOrd".OrderLabels()),
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (string.IsNullOrWhiteSpace(prjTitle))
					{
						return new ServiceResult<string>
						{
							Message = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblOrdProject),
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					short.Parse(Financial.Get().Id.ToString());
					short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Mobile.Classes.Configuration.AppType;
					List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
					List<CrmProjectTitles_LangViewModel> list2 = new List<CrmProjectTitles_LangViewModel>();
					if (!string.IsNullOrWhiteSpace(prjTitle))
					{
						MobspSelectProjectTitlesByVal_Result mobspSelectProjectTitlesByVal_Result = Enumerable.FirstOrDefault<MobspSelectProjectTitlesByVal_Result>((IEnumerable<MobspSelectProjectTitlesByVal_Result>)cRMEntities.MobspSelectProjectTitlesByVal(prjTitle, num, defLangId));
						if (mobspSelectProjectTitlesByVal_Result != null)
						{
							if (!string.IsNullOrEmpty(mobspSelectProjectTitlesByVal_Result.ProjectTitles_Lang))
							{
								list2 = new JavaScriptSerializer().Deserialize<List<CrmProjectTitles_LangViewModel>>(mobspSelectProjectTitlesByVal_Result.ProjectTitles_Lang);
							}
							list2.Add(new CrmProjectTitles_LangViewModel
							{
								CrmProjectTitlesLangID = 0,
								ProjectTitleID = mobspSelectProjectTitlesByVal_Result.ProjectTitleID,
								LanguageID = num,
								ProjectTitle = mobspSelectProjectTitlesByVal_Result.ProjectTitle,
								ProjectTitleDesc = mobspSelectProjectTitlesByVal_Result.ProjectTitleDesc
							});
						}
					}
					if (list2 != null && Enumerable.Any<CrmProjectTitles_LangViewModel>((IEnumerable<CrmProjectTitles_LangViewModel>)list2))
					{
						foreach (CrmProjectTitles_LangViewModel item in list2)
						{
							list.Add(new CommonMultiLanguageViewModel
							{
								Value = item.ProjectTitle,
								LanguageId = item.LanguageID
							});
						}
					}
					string text = "";
					text = ((!Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list)) ? "" : ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : ""));
					if (string.IsNullOrWhiteSpace(text))
					{
						return new ServiceResult<string>
						{
							Message = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.IssueOrdFromPordAddPrdValidityPrjTitle),
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					string msg = "";
					Order.AddProjectProductHistoryFromOrder(ordId, addPrdValidity: true, text, ref msg);
					if (!string.IsNullOrWhiteSpace(msg))
					{
						message = msg;
						data = null;
						status = ServiceResultStatus.Fail;
					}
					else
					{
						message = Messages.MobMsgSuccessAction;
						data = null;
						status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DeliveryScheduleDayViewModel>> GetDeliveryScheduleForMultiDates(string dates, int prdId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		List<DeliveryScheduleDayViewModel> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					data = new List<DeliveryScheduleDayViewModel>();
					List<DeliveryScheduleDayViewModel> list = new List<DeliveryScheduleDayViewModel>();
					if (!string.IsNullOrEmpty(dates))
					{
						list = JsonConvert.DeserializeObject<List<DeliveryScheduleDayViewModel>>(dates);
					}
					foreach (DeliveryScheduleDayViewModel item in list)
					{
						if (prdId == 0)
						{
							item.DeliverySchedule = Enumerable.ToList<MobspSelectDeliveryScheduleByDayNumberAndDate_Result>((IEnumerable<MobspSelectDeliveryScheduleByDayNumberAndDate_Result>)cRMEntities.MobspSelectDeliveryScheduleByDayNumberAndDate(item.DayNumber, item.DayDateTime, num, result2));
						}
						else
						{
							item.DeliverySchedule = Enumerable.ToList<MobspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>((IEnumerable<MobspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>)cRMSpEntities.MobspSelectDeliveryScheduleByDayNumberAndDateForPrd(item.DayNumber, item.DayDateTime, prdId.ToString(), num, result2));
						}
					}
					data = list;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<DeliveryScheduleDayViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> CheckPordOrderHaveTax(int pordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, token2.userId, num, result2, cId));
					if (mobspSelectPreOrderWithID_Result != null)
					{
						int valueOrDefault = mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault();
						bool haveOrd = false;
						bool flag = Order.CheckLastCompanyOrderHaveTax(valueOrDefault, ref haveOrd);
						bool flag2 = PreOrder.CheckCheckPreOrderHaveTax(pordId);
						if (haveOrd && flag != flag2)
						{
							data = 1;
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrNotFound;
						data = 0;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> CheckLastCompanyOrderHaveTax(int cmpId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					bool haveOrd = false;
					data = Order.CheckLastCompanyOrderHaveTax(cmpId, ref haveOrd);
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> PreOrderIsFixed(int pordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmPreOrder", "actIsFixed", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = pordId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (pordId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorPreOrderNotFound,
							Data = pordId,
							Status = ServiceResultStatus.Error
						};
					}
					cRMSpEntities.MobspPreOrderIsFixed(pordId);
					data = pordId;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = pordId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = pordId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = pordId;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspSelectExpiredPreOrders_Result>> SelectShopExpiredPreOrders(int companyId, int? pageNumber = 1, int? pageSize = 10, int? cmpPersonId = null, int? cId = null, int? ln = null)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		List<SHPMobspSelectExpiredPreOrders_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? companyId2 = companyId;
					int? userId = token2.userId;
					data = Enumerable.ToList<SHPMobspSelectExpiredPreOrders_Result>((IEnumerable<SHPMobspSelectExpiredPreOrders_Result>)cRMSpEntities2.SHPMobspSelectExpiredPreOrders(companyId2, pageNumber, pageSize, userId, num, result, cmpPersonId, cId));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<SHPMobspSelectExpiredPreOrders_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>> SHPSelectNotVerifiedPreOrdersByCmpIdAndExpireDate(int companyId, string expireDate, string expireTime, int? pageNumber = 1, int? pageSize = 10, int? cmpPersonId = null, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					DateTime value;
					try
					{
						if (!string.IsNullOrEmpty(expireDate))
						{
							expireDate = expireDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							value = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(expireDate) + " " + expireTime, new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(expireDate) + " " + expireTime));
						}
						else
						{
							value = DateTime.Now;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>> result3 = new ServiceResult<List<SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMSpEntities?.Dispose();
						return result3;
					}
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>((IEnumerable<SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>)cRMSpEntities.SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate(companyId, value, pageNumber, pageSize, token2.userId, result, result2, cmpPersonId, cId));
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result>> SHPSelectVerifiedPreOrdersWithoutOrderByCmpId(int companyId, int? pageNumber = 1, int? pageSize = 10, int? cmpPersonId = null, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<SHPMobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<SHPMobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result>((IEnumerable<SHPMobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result>)cRMSpEntities.SHPMobspSelectVerifiedPreOrdersWithoutOrderByCmpId(companyId, pageNumber, pageSize, token2.userId, result, result2, cmpPersonId, cId));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<SHPMobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool?> CheckCmpShpIsActive(int pordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		bool? data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					data = false;
					cRMEntities = new CRMEntities();
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, token2.userId, num, result2, cId));
					if (mobspSelectPreOrderWithID_Result != null && !string.IsNullOrWhiteSpace(mobspSelectPreOrderWithID_Result.CmpShpIsActive) && (mobspSelectPreOrderWithID_Result.CmpShpIsActive ?? "0") == "1")
					{
						data = true;
					}
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
		return new ServiceResult<bool?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> ControlPreOrderItemsStock(int pordId, int mode, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					int valueOrDefault = cId.GetValueOrDefault();
					int id = Financial.Get().Id;
					_ = token2.userId;
					int cmpId = 0;
					string msgErrorCanNotVerifyNoStockFromWarehouse = Messages.msgErrorCanNotVerifyNoStockFromWarehouse;
					string text = "";
					string text2 = "";
					bool flag = false;
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, token2.userId, num, result2, cId));
					if (mobspSelectPreOrderWithID_Result != null)
					{
						cmpId = mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault();
						valueOrDefault = mobspSelectPreOrderWithID_Result.pordCId.GetValueOrDefault();
					}
					if (mode == 1)
					{
						msgErrorCanNotVerifyNoStockFromWarehouse = Messages.msgErrorCanNotVerifyNoStockFromWarehouse;
						text = "frmPreOrder";
						text2 = "actCanNotVerifyNoStockFromWarehouse";
					}
					if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
					{
						flag = true;
					}
					else if (UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser, cId))
					{
						flag = true;
					}
					if (flag)
					{
						List<MobspSelectPreOrderItems_Result> list = Enumerable.ToList<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)cRMEntities.MobspSelectPreOrderItems(pordId, num, result2));
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						bool flag2 = false;
						int num2 = 0;
						bool flag3 = false;
						if (mobspSelectCrmsysSetting_Result != null)
						{
							flag2 = ((mobspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && mobspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
							num2 = mobspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						if (flag2 && num2 > 0)
						{
							List<MobspSelectPreOrderItems_Result> list2 = new List<MobspSelectPreOrderItems_Result>();
							if (list != null && Enumerable.Any<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list))
							{
								foreach (MobspSelectPreOrderItems_Result linkAccitem in list)
								{
									int num3 = linkAccitem.PrdKind.GetValueOrDefault(1);
									if (num3 == 0)
									{
										num3 = 1;
									}
									if (num3 != 1)
									{
										continue;
									}
									bool flag4 = true;
									if (Enumerable.FirstOrDefault<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list2, (Func<MobspSelectPreOrderItems_Result, bool>)((MobspSelectPreOrderItems_Result m) => m.pordIPrdId == linkAccitem.pordIPrdId && m.pordIWHId == linkAccitem.pordIWHId && (m.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (m.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && m.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())) != null)
									{
										flag4 = false;
									}
									if (!flag4)
									{
										continue;
									}
									List<MobspSelectPreOrderItems_Result> list3 = Enumerable.ToList<MobspSelectPreOrderItems_Result>(Enumerable.Where<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list, (Func<MobspSelectPreOrderItems_Result, bool>)((MobspSelectPreOrderItems_Result m) => m.pordIPrdId == linkAccitem.pordIPrdId && m.pordIWHId == linkAccitem.pordIWHId && (m.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (m.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && m.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())));
									double num4 = 0.0;
									if (list3 != null && Enumerable.Any<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list3))
									{
										foreach (MobspSelectPreOrderItems_Result item2 in list3)
										{
											num4 += item2.pordIQuantity.GetValueOrDefault();
										}
									}
									MobspSelectPreOrderItems_Result item = new MobspSelectPreOrderItems_Result
									{
										PreOrderItemID = linkAccitem.PreOrderItemID,
										pordIQuantity = num4,
										pordIPrice = linkAccitem.pordIPrice,
										pordIPrdPriceGroupID = linkAccitem.pordIPrdPriceGroupID,
										pordIPrdId = linkAccitem.pordIPrdId,
										pordIWHId = linkAccitem.pordIWHId,
										pordILinkAccWHIdStr = linkAccitem.pordILinkAccWHIdStr,
										pordITracing = linkAccitem.pordITracing,
										pordILinkAccSettingDBId = linkAccitem.pordILinkAccSettingDBId,
										pordIDescriptionI = linkAccitem.pordIDescriptionI,
										pordIPrdName = linkAccitem.pordIPrdName
									};
									list2.Add(item);
								}
							}
							if (list2 != null && Enumerable.Any<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list2))
							{
								foreach (MobspSelectPreOrderItems_Result item3 in list2)
								{
									new OtherSystems();
									string text3 = "";
									string wcf = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.RequestUri.ToString().Split(new string[1] { "/api" }, StringSplitOptions.None));
									HttpRequestHeaders headers = base.Request.Headers;
									string prdIds = item3.pordIPrdId.ToString();
									int valueOrDefault2 = item3.pordIWHId.GetValueOrDefault();
									ServiceResult<string> prdQuantity = OtherSystems.GetPrdQuantity(headers, wcf, prdIds, cmpId, valueOrDefault2, num, item3.pordILinkAccWHIdStr ?? "", item3.pordITracing ?? "");
									if (prdQuantity.Status == ServiceResultStatus.Success)
									{
										text3 = prdQuantity.Data;
										double result3 = 0.0;
										double valueOrDefault3 = item3.pordIQuantity.GetValueOrDefault();
										if (string.IsNullOrEmpty(text3))
										{
											continue;
										}
										if (text3 == Labels.frmError)
										{
											text3 = "0";
										}
										if (text3 != Labels.frmError)
										{
											double.TryParse(text3, out result3);
											if (result3 < valueOrDefault3)
											{
												message = string.Format(msgErrorCanNotVerifyNoStockFromWarehouse, item3.pordIPrdName ?? "");
												data = "";
												status = ServiceResultStatus.Error;
												return new ServiceResult<string>
												{
													Message = message,
													Data = data,
													Status = status
												};
											}
											flag3 = true;
										}
										continue;
									}
									return new ServiceResult<string>
									{
										Message = prdQuantity.Message,
										Data = "",
										Status = prdQuantity.Status
									};
								}
							}
						}
						if (!flag3)
						{
							List<MobspControlPreOrderItemsFromWarehouse_Result> list4 = Enumerable.ToList<MobspControlPreOrderItemsFromWarehouse_Result>((IEnumerable<MobspControlPreOrderItemsFromWarehouse_Result>)cRMSpEntities.MobspControlPreOrderItemsFromWarehouse(pordId, valueOrDefault, 1, id, num, result2));
							if (list4 != null && Enumerable.Any<MobspControlPreOrderItemsFromWarehouse_Result>((IEnumerable<MobspControlPreOrderItemsFromWarehouse_Result>)list4))
							{
								foreach (MobspControlPreOrderItemsFromWarehouse_Result item4 in list4)
								{
									double valueOrDefault4 = item4.pordIQuantity.GetValueOrDefault();
									if (item4.QuantityRemain.GetValueOrDefault() < valueOrDefault4)
									{
										message = string.Format(msgErrorCanNotVerifyNoStockFromWarehouse, item4.PrdName ?? "");
										data = "";
										status = ServiceResultStatus.Error;
										return new ServiceResult<string>
										{
											Message = message,
											Data = data,
											Status = status
										};
									}
								}
							}
						}
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = "";
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = "";
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> ControlPreOrderItemsReserveStock(int pordId, int mode, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		CRMEntities cRMEntities = null;
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					cRMEntities = new CRMEntities();
					int id = Financial.Get().Id;
					_ = token2.userId;
					int cmpId = 0;
					string msgErrorCanNotVerifyNoStockFromReserve = Messages.msgErrorCanNotVerifyNoStockFromReserve;
					string text = "";
					string text2 = "";
					bool flag = false;
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, token2.userId, num, result2, cId));
					if (mobspSelectPreOrderWithID_Result != null)
					{
						cmpId = mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault();
						cId = mobspSelectPreOrderWithID_Result.pordCId.GetValueOrDefault();
					}
					if (mode == 1)
					{
						msgErrorCanNotVerifyNoStockFromReserve = Messages.msgErrorCanNotVerifyNoStockFromReserve;
						text = "frmPreOrder";
						text2 = "actCanNotVerifyNoStockFromReserve";
					}
					if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
					{
						flag = true;
					}
					else if (UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser, cId))
					{
						flag = true;
					}
					if (flag)
					{
						List<MobspControlPreOrderItemsReserveStock_Result> list = Enumerable.ToList<MobspControlPreOrderItemsReserveStock_Result>((IEnumerable<MobspControlPreOrderItemsReserveStock_Result>)cRMSpEntities.MobspControlPreOrderItemsReserveStock(pordId, cId, DateTime.Now, 1, id, num, result2));
						if (list != null && Enumerable.Any<MobspControlPreOrderItemsReserveStock_Result>((IEnumerable<MobspControlPreOrderItemsReserveStock_Result>)list))
						{
							MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
							bool flag2 = false;
							int num2 = 0;
							bool flag3 = false;
							if (mobspSelectCrmsysSetting_Result != null)
							{
								flag2 = ((mobspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && mobspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
								num2 = mobspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
							}
							foreach (MobspControlPreOrderItemsReserveStock_Result item in list)
							{
								string text3 = "";
								double result3 = 0.0;
								double valueOrDefault = item.pordIQuantity.GetValueOrDefault();
								double valueOrDefault2 = item.RemainCountAllWH.GetValueOrDefault();
								double valueOrDefault3 = item.ValidpordQuantity.GetValueOrDefault();
								if (flag2 && num2 > 0)
								{
									string wcf = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.RequestUri.ToString().Split(new string[1] { "/api" }, StringSplitOptions.None));
									HttpRequestHeaders headers = base.Request.Headers;
									string? prdIds = item.pordIPrdId.ToString();
									int valueOrDefault4 = item.pordIWHId.GetValueOrDefault();
									ServiceResult<string> prdQuantity = OtherSystems.GetPrdQuantity(headers, wcf, prdIds, cmpId, valueOrDefault4, num, item.pordILinkAccWHIdStr ?? "", item.pordITracing ?? "");
									if (prdQuantity.Status != ServiceResultStatus.Success)
									{
										return new ServiceResult<string>
										{
											Message = prdQuantity.Message,
											Data = "",
											Status = prdQuantity.Status
										};
									}
									if (!string.IsNullOrEmpty(text3))
									{
										if (text3 == Labels.frmError)
										{
											text3 = "0";
										}
										if (text3 != Labels.frmError)
										{
											double.TryParse(text3, out result3);
											result3 -= valueOrDefault3;
											if (result3 < valueOrDefault)
											{
												message = string.Format(msgErrorCanNotVerifyNoStockFromReserve, item.PrdName ?? "");
												return new ServiceResult<string>
												{
													Message = message,
													Data = "",
													Status = ServiceResultStatus.Error
												};
											}
											flag3 = true;
										}
									}
								}
								if (!flag3 && valueOrDefault2 - valueOrDefault3 < valueOrDefault)
								{
									message = string.Format(msgErrorCanNotVerifyNoStockFromReserve, item.PrdName ?? "");
									return new ServiceResult<string>
									{
										Message = message,
										Data = "",
										Status = ServiceResultStatus.Error
									};
								}
							}
						}
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = "";
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = "";
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = "";
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> ControlPreOrderItemsFromShop(int pordId, int mode, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					int valueOrDefault = cId.GetValueOrDefault();
					_ = UserLogin.CurrentUser.UserId;
					int cmpId = 0;
					string msgErrorCanNotVerifyNoStockFromShop = Messages.msgErrorCanNotVerifyNoStockFromShop;
					string text = "";
					string text2 = "";
					bool flag = false;
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, token2.userId, num, result2, cId));
					if (mobspSelectPreOrderWithID_Result != null)
					{
						cmpId = mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault();
						valueOrDefault = mobspSelectPreOrderWithID_Result.pordCId.GetValueOrDefault();
					}
					if (mode == 1)
					{
						msgErrorCanNotVerifyNoStockFromShop = Messages.msgErrorCanNotVerifyNoStockFromShop;
						text = "frmPreOrder";
						text2 = "actCanNotVerifyNoStockFromShop";
					}
					if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
					{
						flag = true;
					}
					else if (UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser, cId))
					{
						flag = true;
					}
					if (flag)
					{
						string text3 = "";
						List<CommonIdValueByParamViewModel<double>> list = new List<CommonIdValueByParamViewModel<double>>();
						List<MobspSelectPreOrderItems_Result> list2 = Enumerable.ToList<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)cRMEntities.MobspSelectPreOrderItems(pordId, num, result2));
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						bool flag2 = false;
						int num2 = 0;
						if (mobspSelectCrmsysSetting_Result != null)
						{
							flag2 = ((mobspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && mobspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
							num2 = mobspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						if (list2 != null && Enumerable.Any<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list2))
						{
							foreach (MobspSelectPreOrderItems_Result item2 in list2)
							{
								double result3 = 0.0;
								if (flag2 && num2 > 0)
								{
									string text4 = "";
									string wcf = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.RequestUri.ToString().Split(new string[1] { "/api" }, StringSplitOptions.None));
									HttpRequestHeaders headers = base.Request.Headers;
									string prdIds = item2.pordIPrdId.ToString();
									int valueOrDefault2 = item2.pordIWHId.GetValueOrDefault();
									ServiceResult<string> prdQuantity = OtherSystems.GetPrdQuantity(headers, wcf, prdIds, cmpId, valueOrDefault2, num, item2.pordILinkAccWHIdStr ?? "", item2.pordITracing ?? "");
									if (prdQuantity.Status != ServiceResultStatus.Success)
									{
										return new ServiceResult<string>
										{
											Message = prdQuantity.Message,
											Data = "",
											Status = prdQuantity.Status
										};
									}
									if (!string.IsNullOrEmpty(text4))
									{
										if (text4 == Labels.frmError)
										{
											text4 = "0";
										}
										if (text4 != Labels.frmError)
										{
											double.TryParse(text4, out result3);
										}
									}
								}
								CommonIdValueByParamViewModel<double> item = new CommonIdValueByParamViewModel<double>
								{
									Id = item2.pordIPrdId,
									Value = result3
								};
								list.Add(item);
							}
						}
						if (list != null && Enumerable.Any<CommonIdValueByParamViewModel<double>>((IEnumerable<CommonIdValueByParamViewModel<double>>)list))
						{
							text3 = JsonConvert.SerializeObject(Enumerable.ToList<CommonIdValueByParamViewModel<double>>((IEnumerable<CommonIdValueByParamViewModel<double>>)list));
							List<MobspControlPreOrderItemsFromShop_Result> list3 = Enumerable.ToList<MobspControlPreOrderItemsFromShop_Result>((IEnumerable<MobspControlPreOrderItemsFromShop_Result>)cRMSpEntities.MobspControlPreOrderItemsFromShop(pordId, text3, valueOrDefault, 1, num, result2));
							if (list3 != null && Enumerable.Any<MobspControlPreOrderItemsFromShop_Result>((IEnumerable<MobspControlPreOrderItemsFromShop_Result>)list3))
							{
								foreach (MobspControlPreOrderItemsFromShop_Result item3 in list3)
								{
									double valueOrDefault3 = item3.pordIQuantity.GetValueOrDefault();
									if (item3.QuantityRemain.GetValueOrDefault() < valueOrDefault3)
									{
										message = string.Format(msgErrorCanNotVerifyNoStockFromShop, item3.PrdName ?? "");
										data = "";
										status = ServiceResultStatus.Error;
										return new ServiceResult<string>
										{
											Message = message,
											Data = data,
											Status = status
										};
									}
								}
							}
						}
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = "";
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = "";
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool?> CheckTracingDuplicate(int MasterId, int PrdId, int WHId, int DetailId, string Tracing, string LinkAccWHIdStr, int? LinkAccSettingDBId, int? Ln = null, int? CId = null)
	{
		int result = 1065;
		if (Ln.HasValue)
		{
			int.TryParse(Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		bool? data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					data = false;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					if (UserLogin.IsUserAccess("frmPreOrder", "actCanNotVerifyNoStockFromShop", UserLogin.CurrentUser))
					{
						int cmpId = 0;
						MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(MasterId, token2.userId, result, result2, CId));
						if (mobspSelectPreOrderWithID_Result != null)
						{
							cmpId = mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault();
						}
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						bool flag = false;
						int num2 = 0;
						if (mobspSelectCrmsysSetting_Result != null)
						{
							flag = ((mobspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && mobspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
							num2 = mobspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						double result3 = 0.0;
						if (flag && num2 > 0)
						{
							string text = "";
							string wcf = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.RequestUri.ToString().Split(new string[1] { "/api" }, StringSplitOptions.None));
							HttpRequestHeaders headers = base.Request.Headers;
							string prdIds = PrdId.ToString();
							int whId = WHId;
							ServiceResult<string> prdQuantity = OtherSystems.GetPrdQuantity(headers, wcf, prdIds, cmpId, whId, num, LinkAccWHIdStr ?? "", Tracing);
							text = ((prdQuantity.Status != ServiceResultStatus.Success) ? Labels.frmError : prdQuantity.Data);
							if (!string.IsNullOrEmpty(text))
							{
								if (text == Labels.frmError)
								{
									text = "0";
								}
								if (text != Labels.frmError)
								{
									double.TryParse(text, out result3);
								}
							}
						}
						MobspCheckDuplicatePreOrderItemTracingFromShop_Result mobspCheckDuplicatePreOrderItemTracingFromShop_Result = Enumerable.FirstOrDefault<MobspCheckDuplicatePreOrderItemTracingFromShop_Result>((IEnumerable<MobspCheckDuplicatePreOrderItemTracingFromShop_Result>)cRMSpEntities.MobspCheckDuplicatePreOrderItemTracingFromShop(DetailId, PrdId, WHId, Tracing, result3, CId, result, result2));
						if (mobspCheckDuplicatePreOrderItemTracingFromShop_Result != null && mobspCheckDuplicatePreOrderItemTracingFromShop_Result.PreOrderItemID > 0)
						{
							string text2 = (mobspCheckDuplicatePreOrderItemTracingFromShop_Result.pordDateTime.HasValue ? mobspCheckDuplicatePreOrderItemTracingFromShop_Result.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
							message = string.Format(Messages.msgErrorNotSaveDupTracingByFoShop, Labels.lblPOrd, mobspCheckDuplicatePreOrderItemTracingFromShop_Result.pordNumber.GetValueOrDefault().ToString(), text2, Tracing);
							data = true;
						}
					}
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<int?>> GetPreOrderWearHouseCount(int PordId)
	{
		CRMSpEntities cRMSpEntities = null;
		List<int?> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<int?>((IEnumerable<int?>)cRMSpEntities.MobspReturnPreOrderItemsWareHouseCnt(PordId));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<int?>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectPreOrderItemsWithDocItemQuantity_Result>> GetPreOrderItemWithDocItemQuantity(int PordId, int? Ln = null)
	{
		int result = 1065;
		if (Ln.HasValue)
		{
			int.TryParse(Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectPreOrderItemsWithDocItemQuantity_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<MobspSelectPreOrderItemsWithDocItemQuantity_Result>((IEnumerable<MobspSelectPreOrderItemsWithDocItemQuantity_Result>)cRMSpEntities.MobspSelectPreOrderItemsWithDocItemQuantity(PordId, result, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectPreOrderItemsWithDocItemQuantity_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> DraftControl(int PordId, int? Ln = null)
	{
		int result = 1065;
		if (Ln.HasValue)
		{
			int.TryParse(Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					MobspReturnDocFromPreOrder_Result mobspReturnDocFromPreOrder_Result = new MobspReturnDocFromPreOrder_Result();
					string text = "";
					List<MobspReturnDocFromPreOrder_Result> list = Enumerable.ToList<MobspReturnDocFromPreOrder_Result>((IEnumerable<MobspReturnDocFromPreOrder_Result>)cRMSpEntities.MobspReturnDocFromPreOrder(PordId, num, result2));
					if (list != null && Enumerable.Any<MobspReturnDocFromPreOrder_Result>((IEnumerable<MobspReturnDocFromPreOrder_Result>)list))
					{
						mobspReturnDocFromPreOrder_Result = Enumerable.LastOrDefault<MobspReturnDocFromPreOrder_Result>((IEnumerable<MobspReturnDocFromPreOrder_Result>)list);
						if (list.Count > 1)
						{
							foreach (MobspReturnDocFromPreOrder_Result item in list)
							{
								text = text + item.DocNumber + ",";
							}
							if (!string.IsNullOrEmpty(text) && text.EndsWith(","))
							{
								text = text.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						mobspReturnDocFromPreOrder_Result = null;
					}
					if (mobspReturnDocFromPreOrder_Result != null)
					{
						data = true;
						mobspReturnDocFromPreOrder_Result.DocDate = (mobspReturnDocFromPreOrder_Result.DocDateTime.HasValue ? mobspReturnDocFromPreOrder_Result.DocDateTime.Value.ToString("yyyyMMdd") : mobspReturnDocFromPreOrder_Result.DocDate);
						MobspReturnDocFromPreOrder_Result mobspReturnDocFromPreOrder_Result2 = mobspReturnDocFromPreOrder_Result;
						_ = mobspReturnDocFromPreOrder_Result.RegisterDate;
						mobspReturnDocFromPreOrder_Result2.RegisterDatePersian = mobspReturnDocFromPreOrder_Result.RegisterDate.ToString("yyyyMMdd");
						if (string.IsNullOrEmpty(text))
						{
							text = mobspReturnDocFromPreOrder_Result.DocNumber.ToString();
						}
						message = Messages.msgIssueDraftFormPreOrderOfType + " " + mobspReturnDocFromPreOrder_Result.Opr + "\r\n" + Messages.msgIssueDraftFormPreOrderWithNumber + " " + text + "\r\n" + Messages.msgIssueDraftFormPreOrderDate + " " + PersianDate.GetFormatetdDate(mobspReturnDocFromPreOrder_Result.DocDate) + "\r\n" + Messages.msgIssueDraftFormPreOrderInDate + " " + PersianDate.GetFormatetdDate(mobspReturnDocFromPreOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueDraftFormPreOrderByUser + " " + mobspReturnDocFromPreOrder_Result.UserName + "\r\n" + Messages.msgIssueDraftFormPreOrderBeenIssued + "|" + mobspReturnDocFromPreOrder_Result.DocID + "|" + mobspReturnDocFromPreOrder_Result.OprType;
					}
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnDocFromPreOrder_Result>> GetDocInfo(int PordId, int? Ln = null)
	{
		int result = 1065;
		if (Ln.HasValue)
		{
			int.TryParse(Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspReturnDocFromPreOrder_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<MobspReturnDocFromPreOrder_Result>((IEnumerable<MobspReturnDocFromPreOrder_Result>)cRMSpEntities.MobspReturnDocFromPreOrder(PordId, num, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspReturnDocFromPreOrder_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<IssueDraftFromPreOrderViewModel> IssueDraftFromPreOrder(IssueDraftFromPreOrderModel model)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (model.Ln.HasValue)
		{
			int.TryParse(model.Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		IssueDraftFromPreOrderViewModel issueDraftFromPreOrderViewModel = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					List<DocIdKeyValueViewModel> list = new List<DocIdKeyValueViewModel>();
					if (!string.IsNullOrEmpty(model.ValDetails))
					{
						list = new JavaScriptSerializer().Deserialize<List<DocIdKeyValueViewModel>>(model.ValDetails);
					}
					string text = "";
					List<DocIdKeyValueDblViewModel> list2 = new List<DocIdKeyValueDblViewModel>();
					string pordItemList = "";
					if (Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list))
					{
						foreach (DocIdKeyValueViewModel item3 in list)
						{
							string id = item3.Id;
							_ = item3.Type;
							_ = item3.Tag;
							string value = item3.Value;
							int result3 = 0;
							int.TryParse(id, out result3);
							double result4 = 0.0;
							double.TryParse(value, out result4);
							if (result4 > 0.0)
							{
								text = text + result3 + "," + result4 + "|";
								DocIdKeyValueDblViewModel item = new DocIdKeyValueDblViewModel
								{
									Id = result3,
									Value = result4
								};
								list2.Add(item);
							}
						}
					}
					if (list2 != null && Enumerable.Any<DocIdKeyValueDblViewModel>((IEnumerable<DocIdKeyValueDblViewModel>)list2))
					{
						pordItemList = JsonConvert.SerializeObject(Enumerable.ToList<DocIdKeyValueDblViewModel>((IEnumerable<DocIdKeyValueDblViewModel>)list2));
					}
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(model.PordId, token2.userId, num, result2, model.CId));
					if (mobspSelectPreOrderWithID_Result != null)
					{
						int result5 = 0;
						int.TryParse(mobspSelectPreOrderWithID_Result.pordStatusId.ToString(), out result5);
						if (!UserLogin.IsUserAccess("frmPreOrder", "actCanIssueDraftFromExpirePord", UserLogin.CurrentUser) && (result5 == 4 || (mobspSelectPreOrderWithID_Result.pordExpireDateTime.HasValue && mobspSelectPreOrderWithID_Result.pordExpireDateTime < DateTime.Now)))
						{
							return new ServiceResult<IssueDraftFromPreOrderViewModel>
							{
								Message = Messages.msgErrorIssueDraftForCanceledPord,
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
					}
					message = Messages.msgErrorNotFindWarehouseDraftForPreOrder;
					MobspReturnDocFromPreOrder_Result mobspReturnDocFromPreOrder_Result = new MobspReturnDocFromPreOrder_Result();
					string text2 = "";
					List<MobspReturnDocFromPreOrder_Result> list3 = Enumerable.ToList<MobspReturnDocFromPreOrder_Result>((IEnumerable<MobspReturnDocFromPreOrder_Result>)cRMSpEntities.MobspReturnDocFromPreOrder(model.PordId, num, result2));
					if (list3 != null && Enumerable.Any<MobspReturnDocFromPreOrder_Result>((IEnumerable<MobspReturnDocFromPreOrder_Result>)list3))
					{
						mobspReturnDocFromPreOrder_Result = Enumerable.LastOrDefault<MobspReturnDocFromPreOrder_Result>((IEnumerable<MobspReturnDocFromPreOrder_Result>)list3);
						if (list3.Count > 1)
						{
							foreach (MobspReturnDocFromPreOrder_Result item4 in list3)
							{
								text2 = text2 + item4.DocNumber + ",";
							}
							if (!string.IsNullOrEmpty(text2) && text2.EndsWith(","))
							{
								text2 = text2.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						mobspReturnDocFromPreOrder_Result = null;
					}
					int result6 = 0;
					if (!UserLogin.IsUserAccess("frmIssueDraftFromPreOrder", "actIssueDraftWithDiffQty", UserLogin.CurrentUser))
					{
						int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspCheckPreOrderHaveDraft(model.PordId));
						if (num2.HasValue)
						{
							int.TryParse(num2.ToString(), out result6);
							if (result6 == 0)
							{
								mobspReturnDocFromPreOrder_Result = null;
							}
						}
					}
					if (mobspReturnDocFromPreOrder_Result != null && result6 == 1)
					{
						if (string.IsNullOrEmpty(text2))
						{
							text2 = mobspReturnDocFromPreOrder_Result.DocNumber.ToString();
						}
						message = Labels.Error + " !!\r\n" + Messages.msgIssueDraftFormPreOrderOfType + " " + mobspReturnDocFromPreOrder_Result.Opr + "\r\n" + Messages.msgIssueDraftFormPreOrderWithNumber + " " + text2 + "\r\n" + Messages.msgIssueDraftFormPreOrderDate + " " + PersianDate.GetFormatetdDate(mobspReturnDocFromPreOrder_Result.DocDate) + "\r\n" + Messages.msgIssueDraftFormPreOrderInDate + " " + PersianDate.GetFormatetdDate(mobspReturnDocFromPreOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueDraftFormPreOrderByUser + " " + mobspReturnDocFromPreOrder_Result.UserName + "\r\n" + Messages.msgIssueDraftFormPreOrderBeenIssued + "|" + mobspReturnDocFromPreOrder_Result.DocID + "|" + mobspReturnDocFromPreOrder_Result.OprType;
						issueDraftFromPreOrderViewModel = null;
						status = ServiceResultStatus.Error;
					}
					else
					{
						if (UserLogin.IsUserAccess("frmIssueDraftFromPreOrder", "actCanNotIssueDraftWithNoStock", UserLogin.CurrentUser))
						{
							MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
							bool flag = false;
							int num3 = 0;
							bool flag2 = false;
							if (mobspSelectCrmsysSetting_Result != null)
							{
								flag = ((mobspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && mobspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
								num3 = mobspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
							}
							if (flag && num3 > 0)
							{
								int cmpId = 0;
								if (mobspSelectPreOrderWithID_Result != null)
								{
									cmpId = mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault();
								}
								List<MobspSelectPreOrderItems_Result> list4 = Enumerable.ToList<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)cRMEntities.MobspSelectPreOrderItems(model.PordId, num, result2));
								List<MobspSelectPreOrderItems_Result> list5 = new List<MobspSelectPreOrderItems_Result>();
								if (list4 != null && Enumerable.Any<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list4) && list != null && Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list))
								{
									foreach (DocIdKeyValueViewModel item5 in list)
									{
										string id2 = item5.Id;
										_ = item5.Type;
										_ = item5.Tag;
										string value2 = item5.Value;
										int objId = 0;
										int.TryParse(id2, out objId);
										double result7 = 0.0;
										double.TryParse(value2, out result7);
										MobspSelectPreOrderItems_Result linkAccitem = Enumerable.FirstOrDefault<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list4, (Func<MobspSelectPreOrderItems_Result, bool>)((MobspSelectPreOrderItems_Result m) => m.PreOrderItemID == objId));
										if (linkAccitem == null || result7 == 0.0)
										{
											continue;
										}
										int num4 = linkAccitem.PrdKind.GetValueOrDefault(1);
										if (num4 == 0)
										{
											num4 = 1;
										}
										if (num4 != 1)
										{
											continue;
										}
										bool flag3 = true;
										if (Enumerable.FirstOrDefault<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list5, (Func<MobspSelectPreOrderItems_Result, bool>)((MobspSelectPreOrderItems_Result m) => m.pordIPrdId == linkAccitem.pordIPrdId && m.pordIWHId == linkAccitem.pordIWHId && (m.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (m.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && m.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())) != null)
										{
											flag3 = false;
											foreach (MobspSelectPreOrderItems_Result item6 in list5)
											{
												if (item6.pordIPrdId == linkAccitem.pordIPrdId && item6.pordIWHId == linkAccitem.pordIWHId && (item6.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (item6.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && item6.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())
												{
													item6.pordIQuantity = item6.pordIQuantity.GetValueOrDefault() + result7;
												}
											}
										}
										if (flag3)
										{
											MobspSelectPreOrderItems_Result item2 = new MobspSelectPreOrderItems_Result
											{
												PreOrderItemID = linkAccitem.PreOrderItemID,
												pordIQuantity = result7,
												pordIPrice = linkAccitem.pordIPrice,
												pordIPrdPriceGroupID = linkAccitem.pordIPrdPriceGroupID,
												pordIPrdId = linkAccitem.pordIPrdId,
												pordIWHId = linkAccitem.pordIWHId,
												pordILinkAccWHIdStr = linkAccitem.pordILinkAccWHIdStr,
												pordITracing = linkAccitem.pordITracing,
												pordILinkAccSettingDBId = linkAccitem.pordILinkAccSettingDBId,
												pordIDescriptionI = linkAccitem.pordIDescriptionI,
												pordIPrdName = linkAccitem.pordIPrdName
											};
											list5.Add(item2);
										}
									}
								}
								if (list5 != null && Enumerable.Any<MobspSelectPreOrderItems_Result>((IEnumerable<MobspSelectPreOrderItems_Result>)list5))
								{
									foreach (MobspSelectPreOrderItems_Result item7 in list5)
									{
										if (item7 == null)
										{
											continue;
										}
										double valueOrDefault = item7.pordIQuantity.GetValueOrDefault();
										string text3 = "";
										string wcf = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.RequestUri.ToString().Split(new string[1] { "/api" }, StringSplitOptions.None));
										HttpRequestHeaders headers = base.Request.Headers;
										string prdIds = item7.pordIPrdId.ToString();
										int valueOrDefault2 = item7.pordIWHId.GetValueOrDefault();
										ServiceResult<string> prdQuantity = OtherSystems.GetPrdQuantity(headers, wcf, prdIds, cmpId, valueOrDefault2, num, num3.ToString(), item7.pordITracing ?? "");
										if (prdQuantity.Status == ServiceResultStatus.Success)
										{
											if (!string.IsNullOrEmpty(text3))
											{
												text3 = prdQuantity.Data;
											}
											double result8 = 0.0;
											if (string.IsNullOrEmpty(text3))
											{
												continue;
											}
											if (text3 == Labels.frmError)
											{
												text3 = "0";
											}
											if (text3 != Labels.frmError)
											{
												double.TryParse(text3, out result8);
												if (result8 < valueOrDefault)
												{
													flag2 = true;
													ServiceResult<IssueDraftFromPreOrderViewModel> serviceResult = new ServiceResult<IssueDraftFromPreOrderViewModel>();
													serviceResult.Message = Messages.msgIssueDraftFormPreOrderImpossibilityIssued + "\r\n" + Messages.msgIssueDraftFormPreOrderLackInventory + "\r\n" + item7.pordIPrdName;
													serviceResult.Data = null;
													serviceResult.Status = ServiceResultStatus.Error;
													return serviceResult;
												}
												flag2 = true;
											}
											continue;
										}
										return new ServiceResult<IssueDraftFromPreOrderViewModel>
										{
											Message = prdQuantity.Message,
											Data = null,
											Status = prdQuantity.Status
										};
									}
								}
							}
							if (!flag2)
							{
								MobspControlPreOrderItemsStock_Result mobspControlPreOrderItemsStock_Result = Enumerable.FirstOrDefault<MobspControlPreOrderItemsStock_Result>((IEnumerable<MobspControlPreOrderItemsStock_Result>)cRMEntities.MobspControlPreOrderItemsStock(model.PordId, num, result2, pordItemList, model.CId));
								if (mobspControlPreOrderItemsStock_Result != null)
								{
									ServiceResult<IssueDraftFromPreOrderViewModel> serviceResult = new ServiceResult<IssueDraftFromPreOrderViewModel>();
									serviceResult.Message = Messages.msgIssueDraftFormPreOrderImpossibilityIssued + "\r\n" + Messages.msgIssueDraftFormPreOrderLackInventory + "\r\n" + mobspControlPreOrderItemsStock_Result.PrdName;
									serviceResult.Data = null;
									serviceResult.Status = ServiceResultStatus.Error;
									return serviceResult;
								}
							}
						}
						if (model.DateSelect != null)
						{
							model.DateSelect = model.DateSelect.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", "");
						}
						string docDate = "";
						DateTime value3 = default(DateTime);
						DateTime dateTime = default(DateTime);
						string text4 = "";
						try
						{
							if (!string.IsNullOrEmpty(model.DateSelect))
							{
								text4 = PersianDate.GetFormatetdDate(model.DateSelect.Replace("/", ""));
								switch (num)
								{
								case 1065:
									dateTime = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
									docDate = dateTime.ToString("yyyyMMdd");
									break;
								case 1025:
									dateTime = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
									docDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									dateTime = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
									docDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
								value3 = dateTime;
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							message = Messages.frmErrorMessage;
							issueDraftFromPreOrderViewModel = null;
							status = ServiceResultStatus.Error;
						}
						DateTime now = DateTime.Now;
						DateTime value4 = now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						short value5 = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType = Mobile.Classes.Configuration.AppType;
						short.Parse(now.ToString("yyyy", new PersianCulture()));
						int userId = UserLogin.CurrentUser.UserId;
						int id3 = Financial.Get().Id;
						ObjectParameter objectParameter = new ObjectParameter("InsertedDocId", 0);
						ObjectParameter objectParameter2 = new ObjectParameter("InsertedDocNumber", 0);
						int? num5 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspIssueDraftFromPreOrder(model.PordId, docOprId: model.DocOprId, docDate: docDate, docDateTime: value3, pordItemList: pordItemList, userId: userId, month1: value5, fPId: id3, registerDate: value4, registerDatePersian: registerDatePersian, appType: appType, defaultLanguageID: result2, insertedDocId: objectParameter, insertedDocNumber: objectParameter2, centerId: (model.CId != 0) ? model.CId : null));
						int result9 = 0;
						if (num5.HasValue)
						{
							int.TryParse(num5.ToString(), out result9);
						}
						int result10 = 0;
						if (objectParameter.Value != null)
						{
							int.TryParse(objectParameter.Value.ToString(), out result10);
						}
						int result11 = 0;
						if (objectParameter2.Value != null)
						{
							int.TryParse(objectParameter2.Value.ToString(), out result11);
						}
						if (result9 <= 0)
						{
							return new ServiceResult<IssueDraftFromPreOrderViewModel>
							{
								Message = Messages.msgErrorRunFunction,
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
						string text5 = "";
						MobspReturnDocFromPreOrder_Result mobspReturnDocFromPreOrder_Result2 = new MobspReturnDocFromPreOrder_Result();
						List<MobspReturnDocFromPreOrder_Result> list6 = Enumerable.ToList<MobspReturnDocFromPreOrder_Result>((IEnumerable<MobspReturnDocFromPreOrder_Result>)cRMSpEntities.MobspReturnDocFromPreOrder(model.PordId, num, result2));
						text2 = "";
						if (list6 != null && Enumerable.Any<MobspReturnDocFromPreOrder_Result>((IEnumerable<MobspReturnDocFromPreOrder_Result>)list6))
						{
							mobspReturnDocFromPreOrder_Result2 = Enumerable.LastOrDefault<MobspReturnDocFromPreOrder_Result>((IEnumerable<MobspReturnDocFromPreOrder_Result>)list6);
							if (list6.Count > 1)
							{
								foreach (MobspReturnDocFromPreOrder_Result item8 in list6)
								{
									text2 = text2 + item8.DocNumber + ",";
									text5 = text5 + item8.DocID + ",";
								}
								if (!string.IsNullOrEmpty(text2) && text2.EndsWith(","))
								{
									text2 = text2.TrimEnd(new char[1] { ',' });
								}
								if (!string.IsNullOrEmpty(text5) && text5.EndsWith(","))
								{
									text5 = text5.TrimEnd(new char[1] { ',' });
								}
							}
						}
						else
						{
							mobspReturnDocFromPreOrder_Result2 = null;
						}
						if (mobspReturnDocFromPreOrder_Result2 != null)
						{
							if (string.IsNullOrEmpty(text2))
							{
								text2 = mobspReturnDocFromPreOrder_Result2.DocNumber.ToString();
							}
							issueDraftFromPreOrderViewModel = new IssueDraftFromPreOrderViewModel();
							issueDraftFromPreOrderViewModel.DraftId = result10;
							issueDraftFromPreOrderViewModel.DocNumbers = text2;
							issueDraftFromPreOrderViewModel.OprTypeId = mobspReturnDocFromPreOrder_Result2.OprType;
							message = "";
							status = ServiceResultStatus.Success;
						}
						else
						{
							issueDraftFromPreOrderViewModel.DraftId = result10;
							issueDraftFromPreOrderViewModel.DraftNumber = result11;
							issueDraftFromPreOrderViewModel.OprTypeId = 1;
							message = "";
							status = ServiceResultStatus.Success;
						}
						if (VersionBuyer.MoneyBag && result10 != 0)
						{
							issueDraftFromPreOrderViewModel.UpdateMoneyBag = true;
							if (!PreOrder.AddUserMoneyBagFormPord(model.PordId, model.CId))
							{
								issueDraftFromPreOrderViewModel.UpdateMoneyBag = false;
							}
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					issueDraftFromPreOrderViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				issueDraftFromPreOrderViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			issueDraftFromPreOrderViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<IssueDraftFromPreOrderViewModel>
		{
			Message = message,
			Data = issueDraftFromPreOrderViewModel,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> CheckDiscountOnVerify(int pordId, int? cId = null, int? ln = null)
	{
		string text = "";
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Error;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					text2 = PreOrder.CheckBeforeVerification(pordId, token2.userId, cId, ln);
					text = null;
					serviceResultStatus = ServiceResultStatus.Success;
				}
				else
				{
					text = Messages.MobMsgErrorAccessingToken;
					text2 = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				text = Messages.MobMsgErrorAccessingToken;
				text2 = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.MobMsgErrorDoneOperation;
			text2 = null;
			serviceResultStatus = ServiceResultStatus.Error;
		}
		return new ServiceResult<string>
		{
			Message = text,
			Data = text2,
			Status = serviceResultStatus
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> ControlPreOrderItemsSoldStock(int pordId, int mode, string txt = "", string pordItemJson = "", int? cId = null, int? Ln = null)
	{
		int result = 1065;
		if (Ln.HasValue)
		{
			int.TryParse(Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		string data = "";
		ServiceResultStatus status = ServiceResultStatus.Error;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					int id = Financial.Get().Id;
					_ = UserLogin.CurrentUser.UserId;
					int cmpId = 0;
					string format = Messages.msgErrorCanNotVerifyNoStockFromSold;
					string text = "";
					string text2 = "";
					bool flag = false;
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, token2.userId, num, result2, cId));
					if (mobspSelectPreOrderWithID_Result != null)
					{
						cmpId = mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault();
						cId = mobspSelectPreOrderWithID_Result.pordCId.GetValueOrDefault();
					}
					switch (mode)
					{
					case 1:
						format = Messages.msgErrorCanNotVerifyNoStockFromSold;
						text = "frmPreOrder";
						text2 = "actCanNotVerifyNoStockFromSold";
						break;
					case 2:
						format = Messages.msgErrorCanNotVerifyNoStockFromSoldByParam;
						format = format.Replace("{1}", txt);
						text = "frmPreOrder";
						text2 = "actCanNotVerifyNoStockFromSold";
						break;
					case 3:
						format = Messages.msgErrorIssueOrderFormPreOrderLackSoldStock;
						text = "frmIssueOrderFromPreOrder";
						text2 = "actCanNotIssueOrderWithNoStockFromSold";
						break;
					case 4:
						format = Messages.msgIssueDraftFormPreOrderLackSoldStock;
						text = "frmIssueDraftFromPreOrder";
						text2 = "actCanNotIssueDraftWithNoStockFromSold";
						break;
					}
					if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
					{
						flag = true;
					}
					else if (UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
					{
						flag = true;
					}
					if (flag)
					{
						List<MobspControlPreOrderItemsSoldStock_Result> list = Enumerable.ToList<MobspControlPreOrderItemsSoldStock_Result>((IEnumerable<MobspControlPreOrderItemsSoldStock_Result>)cRMSpEntities.MobspControlPreOrderItemsSoldStock(pordId, pordItemJson, cId, 1, id, num, result2));
						if (list != null && Enumerable.Any<MobspControlPreOrderItemsSoldStock_Result>((IEnumerable<MobspControlPreOrderItemsSoldStock_Result>)list))
						{
							MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
							bool flag2 = false;
							int num2 = 0;
							bool flag3 = false;
							if (mobspSelectCrmsysSetting_Result != null)
							{
								flag2 = ((mobspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && mobspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
								num2 = mobspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
							}
							foreach (MobspControlPreOrderItemsSoldStock_Result item in list)
							{
								string text3 = "";
								double result3 = 0.0;
								double valueOrDefault = item.pordIQuantity.GetValueOrDefault();
								item.RemainCountAllWH.GetValueOrDefault();
								double valueOrDefault2 = item.SoldOrdQuantity.GetValueOrDefault();
								double valueOrDefault3 = item.TracingRemainCount.GetValueOrDefault();
								if (flag2 && num2 > 0)
								{
									string prdIds = item.pordIPrdId.GetValueOrDefault().ToString();
									string wcf = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.RequestUri.ToString().Split(new string[1] { "/api" }, StringSplitOptions.None));
									HttpRequestHeaders headers = base.Request.Headers;
									int valueOrDefault4 = item.pordIWHId.GetValueOrDefault();
									ServiceResult<string> prdQuantity = OtherSystems.GetPrdQuantity(headers, wcf, prdIds, cmpId, valueOrDefault4, num, num2.ToString(), item.pordITracing ?? "");
									if (prdQuantity.Status != ServiceResultStatus.Success)
									{
										return prdQuantity;
									}
									text3 = prdQuantity.Data;
									if (!string.IsNullOrEmpty(text3))
									{
										if (text3 == Labels.frmError)
										{
											text3 = "0";
										}
										if (text3 != Labels.frmError)
										{
											double.TryParse(text3, out result3);
											result3 -= valueOrDefault2;
											if (result3 < valueOrDefault)
											{
												return new ServiceResult<string>
												{
													Message = message,
													Data = string.Format(format, item.PrdName ?? ""),
													Status = ServiceResultStatus.Error
												};
											}
											flag3 = true;
										}
									}
								}
								if (!flag3 && valueOrDefault3 - valueOrDefault2 < valueOrDefault)
								{
									return new ServiceResult<string>
									{
										Message = string.Format(format, item.PrdName ?? ""),
										Data = null,
										Status = ServiceResultStatus.Error
									};
								}
							}
						}
					}
					message = null;
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
			ErrorSignal.FromCurrentContext().Raise(e);
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> PaymentVerify(int payId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		bool data = false;
		ServiceResultStatus status = ServiceResultStatus.Error;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmPreOrder", "actVerifyPayPreOrder", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<bool>
						{
							Message = Messages.DoNotHaveAccess,
							Data = false,
							Status = ServiceResultStatus.Error
						};
					}
					int userId = UserLogin.CurrentUser.UserId;
					DateTime now = DateTime.Now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					cRMSpEntities.MobspPreOrderPaymentVerify(payId, userId, now, registerDatePersian);
					message = null;
					data = true;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> PaymentVerifyExit(int payId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		bool data = false;
		ServiceResultStatus status = ServiceResultStatus.Error;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmPreOrder", "actExitVerifyPayPreOrder", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<bool>
						{
							Message = Messages.DoNotHaveAccess,
							Data = false,
							Status = ServiceResultStatus.Error
						};
					}
					cRMSpEntities.MobspPreOrderPaymentVerifyExit(payId);
					data = true;
					message = null;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> PaymentCanceled(int payId, string regDate, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		bool data = false;
		ServiceResultStatus status = ServiceResultStatus.Error;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmPreOrder", "actCanceledPay", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<bool>
						{
							Message = Messages.DoNotHaveAccess,
							Data = false,
							Status = ServiceResultStatus.Error
						};
					}
					int userId = UserLogin.CurrentUser.UserId;
					string text = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					DateTime dateTime = default(DateTime);
					string text2 = "";
					DateTime value;
					try
					{
						if (string.IsNullOrWhiteSpace(regDate))
						{
							return new ServiceResult<bool>
							{
								Message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.Date),
								Data = false,
								Status = ServiceResultStatus.Error
							};
						}
						text2 = PersianDate.GetFormatetdDate(regDate.Replace("/", ""));
						value = num switch
						{
							1065 => DateTime.Parse(text2, new PersianCulture()), 
							1025 => DateTime.Parse(text2, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text2, new CultureInfo("en-US")), 
						};
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						return new ServiceResult<bool>
						{
							Message = string.Format(Messages.ErrorInFormat, Labels.Date),
							Data = false,
							Status = ServiceResultStatus.Error
						};
					}
					text = value.ToString("yyyyMMdd", new PersianCulture());
					cRMSpEntities.MobspPreOrderPaymentDeActive(payId, userId, value, text);
					data = true;
					message = null;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> PaymentExitCanceled(int payId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		bool data = false;
		ServiceResultStatus status = ServiceResultStatus.Error;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmPreOrder", "actExitCanceledPay", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<bool>
						{
							Message = Messages.DoNotHaveAccess,
							Data = false,
							Status = ServiceResultStatus.Error
						};
					}
					cRMSpEntities.MobspPreOrderPaymentDeActiveExit(payId);
					data = true;
					message = null;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> GetSepPayIsCqh(int payId, int linkAccSettingDBId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		bool data = false;
		ServiceResultStatus status = ServiceResultStatus.Error;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					MobspLkSepWSSelectPreOrderPaymentsById_Result mobspLkSepWSSelectPreOrderPaymentsById_Result = Enumerable.FirstOrDefault<MobspLkSepWSSelectPreOrderPaymentsById_Result>((IEnumerable<MobspLkSepWSSelectPreOrderPaymentsById_Result>)cRMSpEntities.MobspLkSepWSSelectPreOrderPaymentsById(payId, num, result2, linkAccSettingDBId));
					if (mobspLkSepWSSelectPreOrderPaymentsById_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspLkSepWSSelectPreOrderPaymentsById_Result.SepDetailType.ToString(), out result3);
						data = result3 == 2;
					}
					message = null;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
