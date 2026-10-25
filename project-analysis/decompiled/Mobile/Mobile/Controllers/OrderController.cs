using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
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
using Mobile.Models.ViewModel.VerificationWorkFlow;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class OrderController : ApiController
{
	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<OrderDetailViewModel> SelectOrderWithId(int ordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		OrderDetailViewModel orderDetailViewModel = null;
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
					if (!UserLogin.IsUserAccess("frmMain", "actordSaleOrder", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<OrderDetailViewModel>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectOrderWithID_Result mobspSelectOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(ordId, token2.userId, result, result2, cId));
					if (mobspSelectOrderWithID_Result != null)
					{
						orderDetailViewModel = new OrderDetailViewModel();
						orderDetailViewModel.Order = new MobspSelectOrderWithID_Result();
						if (Order.IsEditAfterFix(mobspSelectOrderWithID_Result.ordEditAfterFixInfoJs, mobspSelectOrderWithID_Result.OrderID, 1, token2.userId))
						{
							mobspSelectOrderWithID_Result.ordIsFixed = false;
						}
						if (!string.IsNullOrWhiteSpace((mobspSelectOrderWithID_Result.ordEditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							List<EditAfterFixInfoViewModel> list = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectOrderWithID_Result.ordEditAfterFixInfoJs);
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
								mobspSelectOrderWithID_Result.ordEditAfterFixInfoJs = JsonConvert.SerializeObject(list);
							}
						}
						orderDetailViewModel.Order = mobspSelectOrderWithID_Result;
						mobspSelectOrderWithID_Result.IsSentToLinkAcc = false;
						if (mobspSelectOrderWithID_Result.ordLinkAccCodeId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectOrderWithID_Result.ordLinkAccCode) || mobspSelectOrderWithID_Result.ordLinkAccOrderId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectOrderWithID_Result.ordLinkAccOrderNumber) || mobspSelectOrderWithID_Result.ordLinkAccVoucherId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectOrderWithID_Result.ordLinkAccVoucherNumber) || !string.IsNullOrWhiteSpace(mobspSelectOrderWithID_Result.ordLinkAccOrderIdStr) || (!string.IsNullOrWhiteSpace(mobspSelectOrderWithID_Result.ordLinkAccData) && mobspSelectOrderWithID_Result.ordLinkAccData != "[]"))
						{
							mobspSelectOrderWithID_Result.IsSentToLinkAcc = true;
						}
						orderDetailViewModel.OrderItems = new List<MobspSelectOrderItems_Result>();
						orderDetailViewModel.OrderItemSerials = new List<MobspSelectOrderItemSerialsByOrderItemId_Result>();
						List<MobspSelectOrderItems_Result> list2 = Enumerable.ToList<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)cRMEntities.MobspSelectOrderItems(ordId, result, result2));
						if (Enumerable.Any<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)list2))
						{
							orderDetailViewModel.OrderItems = list2;
							foreach (MobspSelectOrderItems_Result item2 in list2)
							{
								List<MobspSelectOrderItemSerialsByOrderItemId_Result> list3 = Enumerable.ToList<MobspSelectOrderItemSerialsByOrderItemId_Result>((IEnumerable<MobspSelectOrderItemSerialsByOrderItemId_Result>)cRMEntities.MobspSelectOrderItemSerialsByOrderItemId(item2.OrderItemID, result, result2));
								if (!Enumerable.Any<MobspSelectOrderItemSerialsByOrderItemId_Result>((IEnumerable<MobspSelectOrderItemSerialsByOrderItemId_Result>)list3))
								{
									continue;
								}
								foreach (MobspSelectOrderItemSerialsByOrderItemId_Result item3 in list3)
								{
									orderDetailViewModel.OrderItemSerials.Add(item3);
								}
							}
						}
						orderDetailViewModel.OrderPayments = new List<MobspSelectOrderPayments_Result>();
						List<MobspSelectOrderPayments_Result> list4 = Enumerable.ToList<MobspSelectOrderPayments_Result>((IEnumerable<MobspSelectOrderPayments_Result>)cRMEntities.MobspSelectOrderPayments(ordId, result, result2));
						if (Enumerable.Any<MobspSelectOrderPayments_Result>((IEnumerable<MobspSelectOrderPayments_Result>)list4))
						{
							orderDetailViewModel.OrderPayments = list4;
						}
						orderDetailViewModel.OrderFiles = new List<MobspSelectFilesDirectory_Result>();
						List<MobspSelectFilesDirectory_Result> list5 = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(mobspSelectOrderWithID_Result.ordCompanyId.ToString(), "", mobspSelectOrderWithID_Result.ordProjectId.ToString(), "20", ordId.ToString(), result, result2, false, cId));
						if (Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list5))
						{
							orderDetailViewModel.OrderFiles = list5;
						}
						orderDetailViewModel.OrderSumFooter = new MobfnReturnOrderSumFooter_Result();
						MobfnReturnOrderSumFooter_Result mobfnReturnOrderSumFooter_Result = Queryable.FirstOrDefault<MobfnReturnOrderSumFooter_Result>(cRMEntities.MobfnReturnOrderSumFooter(ordId));
						if (mobfnReturnOrderSumFooter_Result != null)
						{
							orderDetailViewModel.OrderSumFooter = mobfnReturnOrderSumFooter_Result;
						}
						orderDetailViewModel.SumOrderPay = new MobspReturnSumOrderPay_Result();
						MobspReturnSumOrderPay_Result mobspReturnSumOrderPay_Result = Enumerable.FirstOrDefault<MobspReturnSumOrderPay_Result>((IEnumerable<MobspReturnSumOrderPay_Result>)cRMEntities.MobspReturnSumOrderPay(ordId));
						if (mobspReturnSumOrderPay_Result != null)
						{
							orderDetailViewModel.SumOrderPay = mobspReturnSumOrderPay_Result;
						}
						orderDetailViewModel.DocForSaleOrder = new MobspReturnDocForSaleOrder_Result();
						MobspReturnDocForSaleOrder_Result mobspReturnDocForSaleOrder_Result = Enumerable.FirstOrDefault<MobspReturnDocForSaleOrder_Result>((IEnumerable<MobspReturnDocForSaleOrder_Result>)cRMEntities.MobspReturnDocForSaleOrder(ordId, result, result2));
						if (mobspReturnDocForSaleOrder_Result != null)
						{
							orderDetailViewModel.DocForSaleOrder = mobspReturnDocForSaleOrder_Result;
						}
						orderDetailViewModel.WareHouseCount = 0;
						List<int?> list6 = Enumerable.ToList<int?>((IEnumerable<int?>)cRMEntities.MobfnReturnOrderItemsWareHouseCnt(ordId));
						if (list6 != null)
						{
							int result3 = 0;
							int.TryParse(list6.Count.ToString(), out result3);
							orderDetailViewModel.WareHouseCount = result3;
						}
						orderDetailViewModel.InternalMsg = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list7 = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 8, ordId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list7))
						{
							orderDetailViewModel.InternalMsg = list7;
						}
						orderDetailViewModel.BuyOrderList = new List<MobspReturnBuyOrderFromOrder_Result>();
						orderDetailViewModel.BuyOrderList = Enumerable.ToList<MobspReturnBuyOrderFromOrder_Result>((IEnumerable<MobspReturnBuyOrderFromOrder_Result>)cRMSpEntities.MobspReturnBuyOrderFromOrder(ordId, result, result2));
						if (orderDetailViewModel.BuyOrderList == null)
						{
							orderDetailViewModel.BuyOrderList = new List<MobspReturnBuyOrderFromOrder_Result>();
						}
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorOrderNotFound;
						orderDetailViewModel = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					orderDetailViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				orderDetailViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			orderDetailViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<OrderDetailViewModel>
		{
			Message = message,
			Data = orderDetailViewModel,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> OrderVerify(int ordId, int? cId = null, int? ln = null)
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
					if (!UserLogin.IsUserAccess("frmOrder", "actVerifyOrder", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = ordId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (ordId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorOrderNotFound,
							Data = ordId,
							Status = ServiceResultStatus.Error
						};
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					ObjectParameter objectParameter = new ObjectParameter("LimitOrderDiscountPercent", typeof(double));
					ObjectParameter objectParameter2 = new ObjectParameter("Result", 0);
					cRMEntities.MobspOrderVerifyWithPreChecks(ordId, token2.RollId, token2.userId, registerDatePersian, value, objectParameter, objectParameter2);
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
						if (UserLogin.IsUserAccess("frmOrder", "actAutoReferOrderToWrhsUserAfterVerify", UserLogin.CurrentUser, cId))
						{
							Order.ReferOrderToWrhsUser(ordId, cId);
						}
						short value2 = short.Parse(Financial.Get().Id.ToString());
						short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						_ = Messages.MobConversationErjaShow;
						string appType = Mobile.Classes.Configuration.AppType;
						cRMEntities.MobScorespInsertAndCalcOrderScores(null, ordId, null, null, null, null, true, DateTime.Now, token2.userId, value2, value3, value, registerDatePersian, appType, result, result2, null, true, cId, false);
						if (ordId > 0)
						{
							string msg = "";
							Order.AddProjectProductHistoryFromOrder(ordId, addPrdValidity: false, "", ref msg);
							if (!string.IsNullOrWhiteSpace(msg))
							{
								Common.InsTextToElmah(msg);
							}
						}
						bool? sendSMSOrdFOLinkAfterVerify = SysSeting.Get().SendSMSOrdFOLinkAfterVerify;
						int? sendSMSOrdFOLinkAfterVerifyType = SysSeting.Get().SendSMSOrdFOLinkAfterVerifyType;
						string text = "";
						string text2 = "";
						string text3 = "";
						string text4 = "";
						if (sendSMSOrdFOLinkAfterVerify.GetValueOrDefault())
						{
							List<SelectListItem> ordFoShortLinks = Order.GetOrdFoShortLinks(ordId);
							text2 = ordFoShortLinks[1].Value;
							text3 = ordFoShortLinks[2].Value;
							text4 = ordFoShortLinks[3].Value;
							if (sendSMSOrdFOLinkAfterVerifyType.GetValueOrDefault() == 1)
							{
								text = text2;
							}
							else if (sendSMSOrdFOLinkAfterVerifyType.GetValueOrDefault() == 2)
							{
								text = text3;
							}
							else if (sendSMSOrdFOLinkAfterVerifyType.GetValueOrDefault() == 3)
							{
								text = text4;
							}
						}
						if (!string.IsNullOrWhiteSpace(text))
						{
							ObjectParameter result3 = new ObjectParameter("Result", 0);
							CRMSpEntities cRMSpEntities2 = cRMSpEntities;
							int? orderId = ordId;
							string foLink = text;
							string foLinkWithLogin = text2;
							string foLinkWithoutLogin = text3;
							string crmLinkWithoutLogin = text4;
							cRMSpEntities2.MobspSendSmsOrdFOLinkAfterVerify(orderId, foLink, foLinkWithLogin, foLinkWithoutLogin, token2.userId, value2, value3, registerDatePersian, appType, num, result2, result3, crmLinkWithoutLogin, cId);
						}
						int ordCompanyId = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(ordId, token2.userId, result, result2, cId)).ordCompanyId;
						if (ordCompanyId > 0)
						{
							Dictionary<string, string> dictionary = new Dictionary<string, string>();
							dictionary.Add("Title", Labels.VerifyOrderNotificationTitle);
							dictionary.Add("Message", Messages.msgVerifyOrderNotification);
							dictionary.Add("MessageType", "VerifyOrd");
							PushNotif.NewIntMsgNotifyToCompany(int.Parse(ordCompanyId.ToString()), dictionary);
						}
						Order.SendSmsFoSettingOrdAfterVerify(ordId, cId);
						data = ordId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
						break;
					}
					case -1:
						data = ordId;
						message = Messages.MobMsgErrorDivisionByZero;
						status = ServiceResultStatus.Fail;
						break;
					case -2:
						data = ordId;
						message = string.Format(Messages.MobMsgErrorMaxDiscountPercentInItemDiscount, arg);
						status = ServiceResultStatus.Fail;
						break;
					case -3:
						data = ordId;
						message = string.Format(Messages.MobMsgErrorMaxDiscountPercentInOrdDiscount, arg);
						status = ServiceResultStatus.Fail;
						break;
					default:
						data = ordId;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
						break;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = ordId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = ordId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = ordId;
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
	public ServiceResult<int> OrderVerifyExit(int ordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		DateTime now = DateTime.Now;
		DateTime value = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
		string appType = Mobile.Classes.Configuration.AppType;
		short value3 = short.Parse(Financial.Get().Id.ToString());
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
					if (!UserLogin.IsUserAccess("frmOrder", "actExitFromIsFix", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = ordId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (ordId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorOrderNotFound,
							Data = ordId,
							Status = ServiceResultStatus.Error
						};
					}
					cRMEntities.MobspOrderVerifyExit(ordId, token2.userId, registerDatePersian, value);
					cRMEntities.MobScorespDeleteOrderScores(ordId, token2.userId, value3, value2, value, registerDatePersian, appType, result2, cId);
					data = ordId;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = ordId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = ordId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = ordId;
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
	public ServiceResult<List<MobspSelectOrdersByCmpId_Result>> SelectOrdersByCmpId(int companyId, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectOrdersByCmpId_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectOrdersByCmpId_Result>((IEnumerable<MobspSelectOrdersByCmpId_Result>)cRMEntities.MobspSelectOrdersByCmpId(companyId, pageNumber, pageSize, token2.userId, result, result2, cId));
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
		return new ServiceResult<List<MobspSelectOrdersByCmpId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectOrderWithID_Result> SelectOrderWithID(int orderId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectOrderWithID_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(orderId, token2.userId, result, result2, cId));
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
		return new ServiceResult<MobspSelectOrderWithID_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectOrderItems_Result>> SelectOrderItems(int orderId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectOrderItems_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)cRMEntities.MobspSelectOrderItems(orderId, result, result2));
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
		return new ServiceResult<List<MobspSelectOrderItems_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectOrderPayments_Result>> SelectOrderPayments(int orderId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectOrderPayments_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectOrderPayments_Result>((IEnumerable<MobspSelectOrderPayments_Result>)cRMEntities.MobspSelectOrderPayments(orderId, result, result2));
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
		return new ServiceResult<List<MobspSelectOrderPayments_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> ReturnOrderSerialNumber(int orderOprId)
	{
		CRMEntities cRMEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		int data;
		string message;
		ServiceResultStatus status;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					short num2 = short.Parse(Financial.Get().Id.ToString());
					data = Enumerable.FirstOrDefault<int>(cRMEntities.Database.SqlQuery<int>($"Select dbo.MobfnReturnOrderSerialNumber({num2}, {orderOprId})", Array.Empty<object>()));
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
	public ServiceResult<InsertOrderFullViewModel> InsertOrderFull(InsertOrderFullViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertOrderFullViewModel data = null;
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
					bool value4 = UserLogin.IsUserAccess("frmOrderItemDataEntry", "actCanNotSelectWithNoStockInOrd", UserLogin.CurrentUser, model.CenterId);
					bool value5 = UserLogin.IsUserAccess("frmOrderItemDataEntry", "actCanNotSelectWithNoReserveStockInOrd", UserLogin.CurrentUser, model.CenterId);
					bool value6 = UserLogin.IsUserAccess("frmOrderItemDataEntry", "actCanNotSelectWithNoSoldStockInOrd", UserLogin.CurrentUser, model.CenterId);
					if (0 == 0)
					{
						model.UserId = model.UserId ?? token2.userId;
						ObjectParameter objectParameter = new ObjectParameter("insertedOrderId", 0);
						ObjectParameter objectParameter2 = new ObjectParameter("insertedOrdItemIds", "");
						ObjectParameter objectParameter3 = new ObjectParameter("insertedOrdPaymentIds", "");
						ObjectParameter objectParameter4 = new ObjectParameter("errorMessage", "");
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertOrderFull(model.Order, model.OrdItemList, model.OrdPaymentList, model.UserId, value2, value2, value3, value, registerDatePersian, appType, result, result2, value4, objectParameter, objectParameter2, objectParameter3, objectParameter4, model.CenterId, model.OrderItemSerialList, model.haveLinkAccQtyCheck, value5, value6));
						InsertOrderFullViewModel insertOrderFullViewModel = new InsertOrderFullViewModel();
						if (objectParameter4.Value != null)
						{
							if (objectParameter4.Value.ToString() != "")
							{
								string text = objectParameter4.Value.ToString();
								text = text.Replace("|Msg=0", Messages.MobMsgErrorInsertOrder);
								text = text.Replace("Msg=1", Messages.MobMsgErrorInconsistencyInOrdSelection);
								text = text.Replace("Msg=5", Messages.MobMsgProductLackOfStock);
								text = text.Replace("Msg=6", Messages.MobMsgProductLackOfReserveStock);
								text = text.Replace("Msg=7", Messages.MobMsgProductLackOfSoldStock);
								text = text.Replace("|ordNumberIsDup", Messages.MobOrderNumberIsRepeated);
								insertOrderFullViewModel.ErrorMessage = text;
							}
							else
							{
								insertOrderFullViewModel.ErrorMessage = "";
							}
						}
						if (objectParameter.Value != null)
						{
							insertOrderFullViewModel.Order = objectParameter.Value.ToString() ?? "0";
							int.Parse(objectParameter.Value.ToString());
						}
						else
						{
							insertOrderFullViewModel.Order = "0";
						}
						if (objectParameter2.Value != null)
						{
							insertOrderFullViewModel.OrdItemList = objectParameter2.Value.ToString() ?? "0";
						}
						else
						{
							insertOrderFullViewModel.OrdItemList = "0";
						}
						if (objectParameter3.Value != null)
						{
							insertOrderFullViewModel.OrdPaymentList = objectParameter3.Value.ToString() ?? "0";
						}
						else
						{
							insertOrderFullViewModel.OrdPaymentList = "0";
						}
						if (!num.HasValue || num >= 1)
						{
							if (insertOrderFullViewModel.ErrorMessage.IndexOf("=Dup", StringComparison.Ordinal) >= 0)
							{
								string text2 = "";
								string[] array = insertOrderFullViewModel.ErrorMessage.Split(new string[1] { "|^|" }, StringSplitOptions.None);
								foreach (string text3 in array)
								{
									if (!string.IsNullOrEmpty(text3))
									{
										string[] array2 = text3.Split(new char[1] { ',' });
										string text4 = "";
										if (array2[0] == "@ordNumRef=Dup")
										{
											text4 = array2[1].Replace("@DupOrdNumber=", "") ?? "";
											text2 += string.Format(Messages.MobOrderNumRefIsRepeated, text4);
										}
									}
								}
								insertOrderFullViewModel.ErrorMessage = text2;
							}
							if (!string.IsNullOrEmpty(insertOrderFullViewModel.ErrorMessage))
							{
								data = insertOrderFullViewModel;
								message = insertOrderFullViewModel.ErrorMessage;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								string[] array = insertOrderFullViewModel.OrdPaymentList.Split(new char[1] { '|' });
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
											Order.PaymentMoneyBag(result3, 0, result, model.CenterId);
										}
									}
								}
								data = insertOrderFullViewModel;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = insertOrderFullViewModel;
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
		return new ServiceResult<InsertOrderFullViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertOrderFullViewModel> InsertShopOrderFull(ShopIssueOrderViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		InsertOrderFullViewModel data = null;
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
					UserLogin.IsUserAccess("frmOrderItemDataEntry", "actCanNotSelectWithNoStockInOrd", UserLogin.CurrentUser, model.CenterId);
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
							ObjectParameter objectParameter2 = new ObjectParameter("orderId", 0);
							ObjectParameter objectParameter3 = new ObjectParameter("ordNumber", 0);
							ObjectParameter objectParameter4 = new ObjectParameter("ordIssuedJson", "");
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
							ObjectParameter objectParameter5 = objectParameter;
							ObjectParameter objectParameter6 = objectParameter2;
							ObjectParameter objectParameter7 = objectParameter3;
							int num6 = cRMSpEntities2.SHPMobspIssueOrder(transportation: model.Transportation, personId: model.PersonId, wHId: model.WHId, prjcnvsStatusGroupId: model.PrjcnvsStatusGroupId, currencyUnitId: model.OrdCurrencyUnitId, ordDeliveryEndDate: model.OrdDeliveryEndDate ?? "", ordDeliveryEndDateTime: (!string.IsNullOrEmpty(model.OrdDeliveryEndDate)) ? model.OrdDeliveryEndDateTime : null, ordDeliveryEndTime: model.OrdDeliveryEndTime, ordDeliveryDate: model.OrdDeliveryDate, ordDeliveryDateTime: (!string.IsNullOrEmpty(model.OrdDeliveryDate)) ? model.OrdDeliveryDateTime : null, ordDeliveryTime: model.OrdDeliveryTime, productDiscountJson: model.ProductDiscountJson, discountCodeId: model.DiscountCodeId, disCode: model.DisCode, disAmount: model.DisAmount, disAmountPercent: model.DisAmountPercent, ordDiscountTitle: model.OrdDiscountTitle, registerDate: dateTime, registerDatePersian: text4, registerTime: text6, registerDay: text5, fPId: num2, month1: num3, appType: text7, languageID: num4, defaultLanguageID: num5, error: objectParameter5, ordNumber: objectParameter7, orderId: objectParameter6, ordDescriptionI: model.OrdDescription, companyId: companyId, prjTitle: "فروشگاه آنلاین", products: items, ordVerifierRequestId: (model.OrdVerifierRequestId != 0) ? new int?(model.OrdVerifierRequestId) : null, ordDeliveryTermId: (model.DeliveryTermId != 0) ? new int?(model.DeliveryTermId) : null, prdSaleCenterDoneTimeJson: prdSaleCenterDoneTimeJson, ordIssuedJson: objectParameter4, foSettingId: model.FoSettingId, centerId: model.CenterId, shpCartPayTypeId: model.ShpCartPayTypeId, ordSaleAreaId: model.SaleAreaId);
							InsertOrderFullViewModel insertOrderFullViewModel = new InsertOrderFullViewModel();
							if (objectParameter.Value != null)
							{
								if (objectParameter.Value.ToString() != "")
								{
									insertOrderFullViewModel.ErrorMessage = Messages.msgErrorRunFunction;
									if (objectParameter.Value.ToString().IndexOf("SaleCenter Reserve", StringComparison.Ordinal) >= 0)
									{
										insertOrderFullViewModel.ErrorMessage = Messages.FOMsgErrorPrdDoneTimeReservedBefore;
									}
								}
								else
								{
									insertOrderFullViewModel.ErrorMessage = "";
								}
							}
							if (objectParameter2.Value != null)
							{
								insertOrderFullViewModel.Order = objectParameter2.Value.ToString() ?? "0";
								int.Parse(objectParameter2.Value.ToString());
							}
							else
							{
								insertOrderFullViewModel.Order = "0";
							}
							if (objectParameter3.Value != null)
							{
								insertOrderFullViewModel.OrderNumber = objectParameter3.Value.ToString() ?? "0";
							}
							else
							{
								insertOrderFullViewModel.OrdItemList = "0";
							}
							if (objectParameter4 != null)
							{
								if (objectParameter4.Value != null && !string.IsNullOrWhiteSpace(objectParameter4.Value.ToString()))
								{
									insertOrderFullViewModel.ListOrdIssued = objectParameter4.Value.ToString();
								}
							}
							else
							{
								insertOrderFullViewModel.OrdPaymentList = "0";
							}
							if (num6 >= 1)
							{
								if (insertOrderFullViewModel.ErrorMessage.IndexOf("=Dup", StringComparison.Ordinal) >= 0)
								{
									string text8 = "";
									string[] array = insertOrderFullViewModel.ErrorMessage.Split(new string[1] { "|^|" }, StringSplitOptions.None);
									foreach (string text9 in array)
									{
										if (!string.IsNullOrEmpty(text9))
										{
											string[] array2 = text9.Split(new char[1] { ',' });
											string text10 = "";
											if (array2[0] == "@ordNumRef=Dup")
											{
												text10 = array2[1].Replace("@DupOrdNumber=", "") ?? "";
												text8 += string.Format(Messages.MobOrderNumRefIsRepeated, text10);
											}
										}
									}
									insertOrderFullViewModel.ErrorMessage = text8;
								}
								if (!string.IsNullOrEmpty(insertOrderFullViewModel.ErrorMessage))
								{
									data = insertOrderFullViewModel;
									message = insertOrderFullViewModel.ErrorMessage;
									status = ServiceResultStatus.Fail;
								}
								else
								{
									data = insertOrderFullViewModel;
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
							}
							else
							{
								data = insertOrderFullViewModel;
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
		return new ServiceResult<InsertOrderFullViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<OrderListAndIntMsgViewModel> GetOrderListAndIntMsg(long ordNumber, int companyId, string fromDate, string toDate, int? pageNumber = 1, int? pageSize = 10, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		OrderListAndIntMsgViewModel orderListAndIntMsgViewModel = null;
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
						return new ServiceResult<OrderListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					orderListAndIntMsgViewModel = new OrderListAndIntMsgViewModel();
					orderListAndIntMsgViewModel.Orders = new List<MobspSelectOrdersInMode_Result>();
					orderListAndIntMsgViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
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
						ServiceResult<OrderListAndIntMsgViewModel> result3 = new ServiceResult<OrderListAndIntMsgViewModel>
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
						ServiceResult<OrderListAndIntMsgViewModel> result4 = new ServiceResult<OrderListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					OrderListAndIntMsgViewModel orderListAndIntMsgViewModel2 = orderListAndIntMsgViewModel;
					CRMEntities cRMEntities2 = cRMEntities;
					int? companyId2 = companyId;
					orderListAndIntMsgViewModel2.Orders = Enumerable.ToList<MobspSelectOrdersInMode_Result>((IEnumerable<MobspSelectOrdersInMode_Result>)cRMEntities2.MobspSelectOrdersInMode(token2.userId, companyId2, ordNumber, fDateTime, tDateTime, pageNumber, pageSize, result, result2, cId));
					if (!VersionBuyer.MobFinancial || !VersionBuyer.Order)
					{
						orderListAndIntMsgViewModel.Orders = Enumerable.ToList<MobspSelectOrdersInMode_Result>(Enumerable.Take<MobspSelectOrdersInMode_Result>((IEnumerable<MobspSelectOrdersInMode_Result>)orderListAndIntMsgViewModel.Orders, 2));
					}
					foreach (MobspSelectOrdersInMode_Result order in orderListAndIntMsgViewModel.Orders)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 8, order.OrderID, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							orderListAndIntMsgViewModel.InternalMessages.AddRange(list);
						}
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					orderListAndIntMsgViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				orderListAndIntMsgViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			orderListAndIntMsgViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<OrderListAndIntMsgViewModel>
		{
			Message = message,
			Data = orderListAndIntMsgViewModel,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> DistributeDiscountToOrderItems(DistributeDiscountViewModel model)
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
					cRMEntities.MobspDistributeDiscountToOrderItems(model.MasterId, model.ItemIds, model.Discount, model.DiscountPercent, token2.userId, value2, value3, value, registerDatePersian, appType, objectParameter, result, result2, model.AddToDiscount, model.DiscountCodeId, model.CenterId);
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
	public ServiceResult<bool> DistributeTaxToOrderItems(DistributeTaxViewModel model)
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
					cRMEntities.MobspDistributeTaxToOrderItems(model.MasterId, model.ItemIds, model.Tax, model.TaxIndex, token2.userId, value2, value3, value, registerDatePersian, appType, objectParameter, result, result2, model.AddToTax);
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
	public ServiceResult<int> SelectMobOrderCnt(int? cId = null)
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
					data = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspSelectMobOrderCnt(cId)).GetValueOrDefault();
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
	public ServiceResult<int> ReturnOrderNumber(int orderOprId, int? cId = null)
	{
		CRMEntities cRMEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		int data;
		string message;
		ServiceResultStatus status;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					short num2 = short.Parse(Financial.Get().Id.ToString());
					data = (int)Enumerable.FirstOrDefault<long>(cRMEntities.Database.SqlQuery<long>($"Select dbo.MobfnReturnOrderNumber ({num2}, {orderOprId}, {cId})", Array.Empty<object>()));
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
	public ServiceResult<long> ReturnOrderDailyCounter(int orderOprId, string ordDate)
	{
		CRMEntities cRMEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		long data;
		string message;
		ServiceResultStatus status;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					DateTime? dateTime = null;
					try
					{
						if (!string.IsNullOrEmpty(ordDate))
						{
							ordDate = ordDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							dateTime = ((num != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(ordDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(ordDate) + " 00:00:00")));
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					DateTime now = DateTime.Now;
					string arg = dateTime.GetValueOrDefault(now).ToString("yyyy-MM-dd", new CultureInfo("en-US"));
					data = Enumerable.FirstOrDefault<long>(cRMEntities.Database.SqlQuery<long>($"Select dbo.MobfnReturnOrderDailyCounter({orderOprId},'{arg}')", Array.Empty<object>()));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0L;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0L;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0L;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<long>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> ChangeOrderItemPrice(ChangeOrderItemPriceViewModel model)
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
					if (!UserLogin.IsUserAccess("frmOrder", "actChangePriceInOrdItems", UserLogin.CurrentUser, model.CenterId))
					{
						return new ServiceResult<bool>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = false,
							Status = ServiceResultStatus.Fail
						};
					}
					if (Order.IsFixed(model.OrderId, result, token2.userId, model.CenterId))
					{
						return new ServiceResult<bool>
						{
							Message = "msgErrorNotActiveOrd".OrderMessages(),
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
					cRMEntities.MobspChangePriceInOrderItems(model.OrderId, model.Mode, model.ItemIds, model.Amount, model.PricePercent, userId, value2, value3, value, registerDatePersian, appType, objectParameter);
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
	public ServiceResult<List<MobspSelectOrderItemsValidity_Result>> SelectOrderItemsValidity(int orderId, int? ln = null)
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
		List<MobspSelectOrderItemsValidity_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectOrderItemsValidity_Result>((IEnumerable<MobspSelectOrderItemsValidity_Result>)cRMEntities.MobspSelectOrderItemsValidity(orderId, result, result2));
					message = Messages.MobMsgSuccessAction;
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
		return new ServiceResult<List<MobspSelectOrderItemsValidity_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectDiscountCodeByDisCode_Result> AddDiscountCode(string disCode, int ordId, int? ln = null, int? cId = null)
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
					MobspSelectOrderWithID_Result mobspSelectOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(userId: token2.userId, orderId: ordId, languageID: num, defaultLanguageID: result2, centerId: cId));
					if (mobspSelectOrderWithID_Result != null)
					{
						ServiceResult<MobspSelectDiscountCodeByDisCode_Result> serviceResult = DiscountCode.CheckDiscountCodeToUse(disCode, mobspSelectOrderWithID_Result.ordCompanyId, num, result2, cId);
						if (serviceResult.Status != ServiceResultStatus.Success)
						{
							status = serviceResult.Status;
							message = serviceResult.Message;
						}
						else
						{
							List<MobspSelectOrderItemsByNotInSumAndNoDis_Result> list = Enumerable.ToList<MobspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<MobspSelectOrderItemsByNotInSumAndNoDis_Result>)cRMSpEntities.MobspSelectOrderItemsByNotInSumAndNoDis(ordId, false, false, num, result2));
							if (list == null || Enumerable.FirstOrDefault<MobspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<MobspSelectOrderItemsByNotInSumAndNoDis_Result>)list, (Func<MobspSelectOrderItemsByNotInSumAndNoDis_Result, bool>)((MobspSelectOrderItemsByNotInSumAndNoDis_Result x) => x.ordIDiscountCodeId > 0)) != null)
							{
								status = ServiceResultStatus.Error;
								message = Messages.msgErrorCannotAddSecondDisCode;
							}
							else
							{
								_ = mobspSelectOrderWithID_Result.CompanyName;
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
									if (disPrdId != 0 && Enumerable.FirstOrDefault<MobspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<MobspSelectOrderItemsByNotInSumAndNoDis_Result>)list, (Func<MobspSelectOrderItemsByNotInSumAndNoDis_Result, bool>)((MobspSelectOrderItemsByNotInSumAndNoDis_Result m) => m.ordIPrdId == disPrdId)) == null)
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
	public ServiceResult<MobspSelectDiscountCodeByDisCode_Result> AddDiscountCode_old(string disCode, int ordId, int? ln = null, int? cId = null)
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
					MobspSelectOrderWithID_Result mobspSelectOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(userId: token2.userId, orderId: ordId, languageID: num, defaultLanguageID: result2, centerId: cId));
					if (mobspSelectOrderWithID_Result != null)
					{
						string arg = mobspSelectOrderWithID_Result.ordCompany ?? "";
						if (!string.IsNullOrWhiteSpace(disCode))
						{
							MobspSelectDiscountCodeByDisCode_Result mobspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<MobspSelectDiscountCodeByDisCode_Result>((IEnumerable<MobspSelectDiscountCodeByDisCode_Result>)cRMEntities.MobspSelectDiscountCodeByDisCode(disCode, num, result2));
							if (mobspSelectDiscountCodeByDisCode_Result != null)
							{
								string arg2 = mobspSelectDiscountCodeByDisCode_Result.DisPrdName ?? "";
								int ordCompanyId = mobspSelectOrderWithID_Result.ordCompanyId;
								int result3 = 0;
								int.TryParse(mobspSelectDiscountCodeByDisCode_Result.DisCmpId.ToString(), out result3);
								if (result3 == 0 || result3 == ordCompanyId)
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
												List<MobspSelectOrderItemsByNotInSumAndNoDis_Result> list = Enumerable.ToList<MobspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<MobspSelectOrderItemsByNotInSumAndNoDis_Result>)cRMSpEntities.MobspSelectOrderItemsByNotInSumAndNoDis(ordId, false, false, num, result2));
												if (list != null && Enumerable.FirstOrDefault<MobspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<MobspSelectOrderItemsByNotInSumAndNoDis_Result>)list, (Func<MobspSelectOrderItemsByNotInSumAndNoDis_Result, bool>)((MobspSelectOrderItemsByNotInSumAndNoDis_Result m) => m.ordIPrdId == disPrdId)) == null)
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
													MobspReturnSumCompanyScores_Result mobspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<MobspReturnSumCompanyScores_Result>((IEnumerable<MobspReturnSumCompanyScores_Result>)cRMSpEntities.MobspReturnSumCompanyScores(ordCompanyId, cId));
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
												message = string.Format(Messages.msgErrorDisCodeItemNoPrd, arg2, "lblOrd".OrderLabels());
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
	public ServiceResult<int> CheckOrderHaveTax(int ordId, int? ln = null)
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
					cRMSpEntities = new CRMSpEntities();
					MobspCheckOrderHaveTax_Result mobspCheckOrderHaveTax_Result = Enumerable.FirstOrDefault<MobspCheckOrderHaveTax_Result>((IEnumerable<MobspCheckOrderHaveTax_Result>)cRMSpEntities.MobspCheckOrderHaveTax(ordId));
					int num = 0;
					decimal result3 = default(decimal);
					decimal result4 = default(decimal);
					if (mobspCheckOrderHaveTax_Result != null)
					{
						decimal.TryParse(mobspCheckOrderHaveTax_Result.ordTax.ToString(), out result3);
						decimal.TryParse(mobspCheckOrderHaveTax_Result.ordItemsTax.ToString(), out result4);
						num = mobspCheckOrderHaveTax_Result.ordCompanyId;
						bool result5 = false;
						bool.TryParse(mobspCheckOrderHaveTax_Result.Taxable.ToString(), out result5);
						bool flag = false;
						if (result3 != 0m || result4 != 0m)
						{
							flag = true;
						}
						if (flag != result5)
						{
							data = 2;
						}
						else
						{
							bool haveOrd = false;
							bool flag2 = Order.CheckLastCompanyOrderHaveTax(num, ref haveOrd);
							if (haveOrd && flag2 != result5)
							{
								data = 1;
							}
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorNotFound;
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
	public ServiceResult<int> OrderIsFixed(int ordId, int? ln = null, int? cId = null)
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
					if (!UserLogin.IsUserAccess("frmOrder", "actIsFixed", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = ordId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (ordId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorOrderNotFound,
							Data = ordId,
							Status = ServiceResultStatus.Error
						};
					}
					cRMSpEntities.MobspOrderIsFixed(ordId);
					data = ordId;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = ordId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = ordId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = ordId;
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
	public ServiceResult<List<SHPMobspSelectOrdersByCmpId_Result>> SelectShopOrdersByCmpId(int companyId, int? pageNumber = 1, int? pageSize = 10, int? cmpPersonId = 0, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<SHPMobspSelectOrdersByCmpId_Result> data = null;
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
					data = Enumerable.ToList<SHPMobspSelectOrdersByCmpId_Result>((IEnumerable<SHPMobspSelectOrdersByCmpId_Result>)cRMSpEntities.SHPMobspSelectOrdersByCmpId(companyId, pageNumber, pageSize, token2.userId, result, result2, cmpPersonId, cId));
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
		return new ServiceResult<List<SHPMobspSelectOrdersByCmpId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspCheckOrderSaleCenterUnique_Result>> CheckOrderSaleCenterUnique(int orderId, int ordSaleCenterId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspCheckOrderSaleCenterUnique_Result> data = null;
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
					data = Enumerable.ToList<MobspCheckOrderSaleCenterUnique_Result>((IEnumerable<MobspCheckOrderSaleCenterUnique_Result>)cRMSpEntities.MobspCheckOrderSaleCenterUnique(orderId, ordSaleCenterId, result, result2));
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
		return new ServiceResult<List<MobspCheckOrderSaleCenterUnique_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int?> CheckOrderItemSaleCenterUnique(int ordId, int saleCenterId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		dynamic val = null;
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
					ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
					cRMSpEntities.MobspCheckOrderItemSaleCenterUnique(ordId, saleCenterId, objectParameter);
					if (objectParameter.Value != null)
					{
						int result3 = 0;
						int.TryParse(objectParameter.Value.ToString(), out result3);
						val = result3;
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					val = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				val = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			val = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int?>
		{
			Message = message,
			Data = val,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<SHPMobspSelectOrderWithID_Result> SHPSelectOrderWithID(int orderId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		SHPMobspSelectOrderWithID_Result data = null;
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
					data = Enumerable.FirstOrDefault<SHPMobspSelectOrderWithID_Result>((IEnumerable<SHPMobspSelectOrderWithID_Result>)cRMSpEntities.SHPMobspSelectOrderWithID(orderId, result, result2, cId));
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
		return new ServiceResult<SHPMobspSelectOrderWithID_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnOrderItemSerial_Result>> GetSerialListByItemId(int orderItemId = 0, int orderItemSerialId = 0, int whid = 0, string searchedValue = "", int pageSize = 10, int pageNumber = 1, int productId = 0, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspReturnOrderItemSerial_Result> data = new List<MobspReturnOrderItemSerial_Result>();
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
					data = Enumerable.ToList<MobspReturnOrderItemSerial_Result>((IEnumerable<MobspReturnOrderItemSerial_Result>)cRMSpEntities.MobspReturnOrderItemSerial(orderItemId, productId, orderItemSerialId, whid, result, result2, cId, searchedValue, pageSize, pageNumber));
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
		return new ServiceResult<List<MobspReturnOrderItemSerial_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> InsertEditOrderItemSerial(OrderItemSerialViewModel vm)
	{
		int result = 1065;
		if (vm.ln.HasValue)
		{
			int.TryParse(vm.ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		int result3 = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
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
					MobfnCheckDuplicateOrderSerial_Result mobfnCheckDuplicateOrderSerial_Result = Enumerable.FirstOrDefault<MobfnCheckDuplicateOrderSerial_Result>((IEnumerable<MobfnCheckDuplicateOrderSerial_Result>)Enumerable.ToList<MobfnCheckDuplicateOrderSerial_Result>((IEnumerable<MobfnCheckDuplicateOrderSerial_Result>)cRMSpEntities.MobfnCheckDuplicateOrderSerial(vm.OrderItemId, vm.SerialId, vm.FPId, vm.OrderItemSerialID)));
					if (mobfnCheckDuplicateOrderSerial_Result != null)
					{
						ServiceResult<int> serviceResult = new ServiceResult<int>();
						serviceResult.Data = 0;
						serviceResult.Message = Messages.MsgErrorOrderItemSerial1 + "<br/>" + Messages.MsgErrorOrderItemSerial2 + "<br/>" + mobfnCheckDuplicateOrderSerial_Result.ordNumber + "<br/>" + Messages.MsgErrorOrderItemSerial3;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					List<OrderItemSerialLangViewModel> list2 = new List<OrderItemSerialLangViewModel>();
					foreach (MobspSelectLanguages_Result item in list)
					{
						OrderItemSerialLangViewModel orderItemSerialLangViewModel = new OrderItemSerialLangViewModel();
						orderItemSerialLangViewModel.LanguageID = item.LanguageID;
						orderItemSerialLangViewModel.Description = vm.Description;
						list2.Add(orderItemSerialLangViewModel);
					}
					vm.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<OrderItemSerialLangViewModel>((IEnumerable<OrderItemSerialLangViewModel>)list2));
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime value = now;
					string text = now.ToString("yyyyMMdd", new PersianCulture());
					int value2 = int.Parse(Financial.Get().Id.ToString());
					Guid.NewGuid();
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					_ = Labels.MobLackOfShowText;
					int userId = token2.userId;
					_ = token2.userId;
					DateTime value4 = now;
					string text2 = now.ToString("yyyyMMdd", new PersianCulture());
					ObjectParameter objectParameter = new ObjectParameter("Result", 0);
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? orderItemSerialID = vm.OrderItemSerialID;
					DateTime? registerDate = value;
					string registerDatePersian = text;
					int? userId2 = userId;
					int? month = value3;
					int? wHId = vm.WHId;
					int? orderItemId = vm.OrderItemId;
					int? serialId = vm.SerialId;
					string description = vm.Description;
					string description_Lang = vm.Description_Lang;
					int? fPId = value2;
					DateTime? firstRegisterDate = value4;
					string firstRegisterDatePersian = text2;
					cRMSpEntities2.MobspInsertUpdateOrdItemSerial(orderItemSerialID, registerDate, userId2, registerDatePersian, month, appType, wHId, orderItemId, serialId, description, description_Lang, fPId, userId, firstRegisterDate, firstRegisterDatePersian, result, result2, vm.CenterId, objectParameter);
					int.TryParse(objectParameter.Value.ToString(), out result3);
					if (result3 > 0)
					{
						message = "";
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					result3 = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				result3 = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			result3 = 0;
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
			Data = result3,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectOrderItemSerialsByOrderItemId_Result>> GetOrderItemSerials(int orderItemId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectOrderItemSerialsByOrderItemId_Result> data = new List<MobspSelectOrderItemSerialsByOrderItemId_Result>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectOrderItemSerialsByOrderItemId_Result>((IEnumerable<MobspSelectOrderItemSerialsByOrderItemId_Result>)cRMEntities.MobspSelectOrderItemSerialsByOrderItemId(orderItemId, result, result2));
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
		return new ServiceResult<List<MobspSelectOrderItemSerialsByOrderItemId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> DeleteAllOrderSerial(int ordItemId, int ordId)
	{
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
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
					if (ordItemId > 0)
					{
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)cRMSpEntities.MobspDeleteOrderItemSerialsByOrderItemId(ordItemId)));
						if (num.HasValue && num > 0)
						{
							data = true;
							message = "";
							status = ServiceResultStatus.Success;
						}
						else if (num.HasValue && num == 0)
						{
							data = false;
							message = Messages.RedundancyMessage;
							status = ServiceResultStatus.Fail;
						}
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
	public ServiceResult<bool> DeleteOrderSerial(int orderItemSerialId, int ordId)
	{
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
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
					if (orderItemSerialId > 0)
					{
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)cRMSpEntities.MobspDeleteWSOrderItemSerials(orderItemSerialId)));
						if (num.HasValue && num > 0)
						{
							data = true;
							message = "";
							status = ServiceResultStatus.Success;
						}
						else if (num.HasValue && num == 0)
						{
							data = false;
							message = Messages.RedundancyMessage;
							status = ServiceResultStatus.Fail;
						}
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
	public ServiceResult<string> InsertAutoOrderItemSerial(int orderItemId, int ordId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = "1";
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
					cRMSpEntities = new CRMSpEntities();
					MobspSelectOrderItems_Result mobspSelectOrderItems_Result = Enumerable.FirstOrDefault<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)Enumerable.ToList<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)cRMEntities.MobspSelectOrderItems(ordId, result, result2)), (Func<MobspSelectOrderItems_Result, bool>)((MobspSelectOrderItems_Result c) => c.OrderItemID == orderItemId));
					cRMSpEntities.MobspInsertAutoOrderItemSerial(orderItemId, UserLogin.CurrentUser.UserId, int.Parse(DateTime.Now.ToString("MM", new PersianCulture())), Financial.Get().Id, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), mobspSelectOrderItems_Result.ordIWHId, Mobile.Classes.Configuration.AppType, result2);
					data = "1";
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
	public ServiceResult<List<int?>> GetOrderWearHouseCount(int OrdId)
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
					data = Enumerable.ToList<int?>((IEnumerable<int?>)cRMSpEntities.MobspReturnOrderItemsWareHouseCnt(OrdId));
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
	public ServiceResult<List<MobspSelectOrderItemsWithDocItemQuantity_Result>> GetOrderItemWithDocItemQuantity(int OrdId, int? Ln = null)
	{
		int result = 1065;
		if (Ln.HasValue)
		{
			int.TryParse(Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectOrderItemsWithDocItemQuantity_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectOrderItemsWithDocItemQuantity_Result>((IEnumerable<MobspSelectOrderItemsWithDocItemQuantity_Result>)cRMSpEntities.MobspSelectOrderItemsWithDocItemQuantity(OrdId, result, result2));
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
		return new ServiceResult<List<MobspSelectOrderItemsWithDocItemQuantity_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> DraftControl(int OrdId, int? Ln = null)
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
					message = Messages.msgErrorNotFindWarehouseDraftForOrder;
					MobspReturnDraftFromOrder_Result mobspReturnDraftFromOrder_Result = new MobspReturnDraftFromOrder_Result();
					string text = "";
					List<MobspReturnDraftFromOrder_Result> list = Enumerable.ToList<MobspReturnDraftFromOrder_Result>((IEnumerable<MobspReturnDraftFromOrder_Result>)cRMSpEntities.MobspReturnDraftFromOrder(OrdId, num, result2));
					if (list != null && Enumerable.Any<MobspReturnDraftFromOrder_Result>((IEnumerable<MobspReturnDraftFromOrder_Result>)list))
					{
						mobspReturnDraftFromOrder_Result = Enumerable.LastOrDefault<MobspReturnDraftFromOrder_Result>((IEnumerable<MobspReturnDraftFromOrder_Result>)list);
						if (list.Count > 1)
						{
							foreach (MobspReturnDraftFromOrder_Result item in list)
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
						mobspReturnDraftFromOrder_Result = null;
					}
					if (mobspReturnDraftFromOrder_Result != null)
					{
						data = true;
						mobspReturnDraftFromOrder_Result.DocDate = (mobspReturnDraftFromOrder_Result.DocDateTime.HasValue ? mobspReturnDraftFromOrder_Result.DocDateTime.Value.ToString("yyyyMMdd") : mobspReturnDraftFromOrder_Result.DocDate);
						MobspReturnDraftFromOrder_Result mobspReturnDraftFromOrder_Result2 = mobspReturnDraftFromOrder_Result;
						_ = mobspReturnDraftFromOrder_Result.RegisterDate;
						mobspReturnDraftFromOrder_Result2.RegisterDatePersian = mobspReturnDraftFromOrder_Result.RegisterDate.ToString("yyyyMMdd");
						if (string.IsNullOrEmpty(text))
						{
							text = mobspReturnDraftFromOrder_Result.DocNumber.ToString();
						}
						message = Messages.msgIssueDraftFormOrderOfType + " " + mobspReturnDraftFromOrder_Result.Opr + "\r\n" + Messages.msgIssueDraftFormOrderWithNumber + " " + text + "\r\n" + Messages.msgIssueDraftFormOrderDate + " " + PersianDate.GetFormatetdDate(mobspReturnDraftFromOrder_Result.DocDate) + "\r\n" + Messages.msgIssueDraftFormOrderInDate + " " + PersianDate.GetFormatetdDate(mobspReturnDraftFromOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueDraftFormOrderByUser + " " + mobspReturnDraftFromOrder_Result.UserName + "\r\n" + Messages.msgIssueDraftFormOrderBeenIissued + "|" + mobspReturnDraftFromOrder_Result.DocID + "|" + mobspReturnDraftFromOrder_Result.OprType;
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
	public ServiceResult<List<MobspReturnDocForSaleOrder_Result>> GetDocInfo(int OrdId, int? Ln = null)
	{
		int result = 1065;
		if (Ln.HasValue)
		{
			int.TryParse(Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspReturnDocForSaleOrder_Result> data = null;
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
					data = Enumerable.ToList<MobspReturnDocForSaleOrder_Result>((IEnumerable<MobspReturnDocForSaleOrder_Result>)cRMEntities.MobspReturnDocForSaleOrder(OrdId, num, result2));
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
		return new ServiceResult<List<MobspReturnDocForSaleOrder_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<IssueDraftFromOrderViewModel> IssueDraftFromOrder(IssueDraftFromOrderModel model)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (model.Ln.HasValue)
		{
			int.TryParse(model.Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		IssueDraftFromOrderViewModel issueDraftFromOrderViewModel = null;
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
					string appType = Mobile.Classes.Configuration.AppType;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					List<DocIdKeyValueViewModel> list = new List<DocIdKeyValueViewModel>();
					if (!string.IsNullOrEmpty(model.ValDetails))
					{
						list = new JavaScriptSerializer().Deserialize<List<DocIdKeyValueViewModel>>(model.ValDetails);
					}
					string text = "";
					if (Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list))
					{
						foreach (DocIdKeyValueViewModel item2 in list)
						{
							string id = item2.Id;
							_ = item2.Type;
							_ = item2.Tag;
							string value = item2.Value;
							int result3 = 0;
							int.TryParse(id, out result3);
							double result4 = 0.0;
							double.TryParse(value, out result4);
							if (result4 > 0.0)
							{
								text = text + result3 + "," + result4 + "|";
							}
						}
					}
					MobspSelectOrderById_Result mobspSelectOrderById_Result = Enumerable.FirstOrDefault<MobspSelectOrderById_Result>((IEnumerable<MobspSelectOrderById_Result>)cRMSpEntities.MobspSelectOrderById(model.OrdId, result, result2));
					if (mobspSelectOrderById_Result != null)
					{
						int result5 = 0;
						int.TryParse(mobspSelectOrderById_Result.ordStatusId.ToString(), out result5);
						if (result5 == 4)
						{
							return new ServiceResult<IssueDraftFromOrderViewModel>
							{
								Message = Messages.msgErrorIssueDraftForCanceledOrd,
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
					}
					message = Messages.msgErrorNotFindWarehouseDraftForOrder;
					MobspReturnDraftFromOrder_Result mobspReturnDraftFromOrder_Result = new MobspReturnDraftFromOrder_Result();
					string text2 = "";
					List<MobspReturnDraftFromOrder_Result> list2 = Enumerable.ToList<MobspReturnDraftFromOrder_Result>((IEnumerable<MobspReturnDraftFromOrder_Result>)cRMSpEntities.MobspReturnDraftFromOrder(model.OrdId, defaultLanguageID: result2, languageID: result));
					if (list2 != null && Enumerable.Any<MobspReturnDraftFromOrder_Result>((IEnumerable<MobspReturnDraftFromOrder_Result>)list2))
					{
						mobspReturnDraftFromOrder_Result = Enumerable.LastOrDefault<MobspReturnDraftFromOrder_Result>((IEnumerable<MobspReturnDraftFromOrder_Result>)list2);
						if (list2.Count > 1)
						{
							foreach (MobspReturnDraftFromOrder_Result item3 in list2)
							{
								text2 = text2 + item3.DocNumber + ",";
							}
							if (!string.IsNullOrEmpty(text2) && text2.EndsWith(","))
							{
								text2 = text2.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						mobspReturnDraftFromOrder_Result = null;
					}
					int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspCheckOrderHaveDraft(model.OrdId));
					int result6 = 0;
					if (num2.HasValue)
					{
						int.TryParse(num2.GetValueOrDefault().ToString(), out result6);
						if (result6 == 0)
						{
							mobspReturnDraftFromOrder_Result = null;
						}
					}
					if (mobspReturnDraftFromOrder_Result != null && result6 == 1)
					{
						if (string.IsNullOrEmpty(text2))
						{
							text2 = mobspReturnDraftFromOrder_Result.DocNumber.ToString();
						}
						message = "1|" + Labels.Error + " !!\r\n" + Messages.msgIssueDraftFormOrderOfType + " " + mobspReturnDraftFromOrder_Result.Opr + "\r\n" + Messages.msgIssueDraftFormOrderWithNumber + " " + text2 + "\r\n" + Messages.msgIssueDraftFormOrderDate + " " + PersianDate.GetFormatetdDate(mobspReturnDraftFromOrder_Result.DocDate) + "\r\n" + Messages.msgIssueDraftFormOrderInDate + " " + PersianDate.GetFormatetdDate(mobspReturnDraftFromOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueDraftFormOrderByUser + " " + mobspReturnDraftFromOrder_Result.UserName + "\r\n" + Messages.msgIssueDraftFormOrderBeenIissued + "|" + mobspReturnDraftFromOrder_Result.DocID + "|" + mobspReturnDraftFromOrder_Result.OprType;
						issueDraftFromOrderViewModel = null;
						status = ServiceResultStatus.Error;
					}
					else
					{
						if (UserLogin.IsUserAccess("frmIssueDraftFromOrder", "actCanNotIssueDraftWithNoStock", UserLogin.CurrentUser))
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
								MobspSelectOrderById_Result mobspSelectOrderById_Result2 = Enumerable.FirstOrDefault<MobspSelectOrderById_Result>((IEnumerable<MobspSelectOrderById_Result>)cRMSpEntities.MobspSelectOrderById(model.OrdId, num, result2));
								if (mobspSelectOrderById_Result2 != null)
								{
									cmpId = mobspSelectOrderById_Result2.ordCompanyId;
								}
								List<MobspSelectOrderItems_Result> list3 = Enumerable.ToList<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)cRMEntities.MobspSelectOrderItems(model.OrdId, num, result2));
								List<MobspSelectOrderItems_Result> list4 = new List<MobspSelectOrderItems_Result>();
								if (list3 != null && Enumerable.Any<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)list3) && list != null && Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list))
								{
									foreach (DocIdKeyValueViewModel item4 in list)
									{
										string id2 = item4.Id;
										_ = item4.Type;
										_ = item4.Tag;
										string value2 = item4.Value;
										int objId = 0;
										int.TryParse(id2, out objId);
										double result7 = 0.0;
										double.TryParse(value2, out result7);
										MobspSelectOrderItems_Result linkAccitem = Enumerable.FirstOrDefault<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)list3, (Func<MobspSelectOrderItems_Result, bool>)((MobspSelectOrderItems_Result m) => m.OrderItemID == objId));
										if (linkAccitem == null || result7 == 0.0)
										{
											continue;
										}
										bool flag3 = true;
										if (Enumerable.FirstOrDefault<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)list4, (Func<MobspSelectOrderItems_Result, bool>)((MobspSelectOrderItems_Result m) => m.ordIPrdId == linkAccitem.ordIPrdId && m.ordIWHId == linkAccitem.ordIWHId && (m.ordILinkAccWHIdStr ?? "") == (linkAccitem.ordILinkAccWHIdStr ?? "") && (m.ordITracing ?? "") == (linkAccitem.ordITracing ?? "") && m.ordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.ordILinkAccSettingDBId.GetValueOrDefault())) != null)
										{
											flag3 = false;
											foreach (MobspSelectOrderItems_Result item5 in list4)
											{
												if (item5.ordIPrdId == linkAccitem.ordIPrdId && item5.ordIWHId == linkAccitem.ordIWHId && (item5.ordILinkAccWHIdStr ?? "") == (linkAccitem.ordILinkAccWHIdStr ?? "") && (item5.ordITracing ?? "") == (linkAccitem.ordITracing ?? "") && item5.ordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.ordILinkAccSettingDBId.GetValueOrDefault())
												{
													item5.ordIQuantity = item5.ordIQuantity.GetValueOrDefault() + result7;
												}
											}
										}
										if (flag3)
										{
											MobspSelectOrderItems_Result item = new MobspSelectOrderItems_Result
											{
												OrderItemID = linkAccitem.OrderItemID,
												ordIQuantity = result7,
												ordIPrice = linkAccitem.ordIPrice,
												ordIPrdPriceGroupID = linkAccitem.ordIPrdPriceGroupID,
												ordIPrdId = linkAccitem.ordIPrdId,
												ordIWHId = linkAccitem.ordIWHId,
												ordILinkAccWHIdStr = linkAccitem.ordILinkAccWHIdStr,
												ordITracing = linkAccitem.ordITracing,
												ordILinkAccSettingDBId = linkAccitem.ordILinkAccSettingDBId,
												ordIDescriptionI = linkAccitem.ordIDescriptionI,
												ordIPrdName = linkAccitem.ordIPrdName
											};
											list4.Add(item);
										}
									}
								}
								if (list4 != null && Enumerable.Any<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)list4))
								{
									foreach (MobspSelectOrderItems_Result item6 in list4)
									{
										if (item6 == null)
										{
											continue;
										}
										double valueOrDefault = item6.ordIQuantity.GetValueOrDefault();
										string text3 = "";
										string wcf = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.RequestUri.ToString().Split(new string[1] { "/api" }, StringSplitOptions.None));
										HttpRequestHeaders headers = base.Request.Headers;
										string prdIds = item6.ordIPrdId.ToString();
										int valueOrDefault2 = item6.ordIWHId.GetValueOrDefault();
										ServiceResult<string> prdQuantity = OtherSystems.GetPrdQuantity(headers, wcf, prdIds, cmpId, valueOrDefault2, num, num3.ToString(), item6.ordITracing ?? "");
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
													message = Messages.msgIssueDraftFormOrderImpossibilityIissued + "\r\n" + Messages.msgIssueDraftFormOrderLackInventory + "\r\n" + item6.ordIPrdName;
													return new ServiceResult<IssueDraftFromOrderViewModel>
													{
														Message = message,
														Data = null,
														Status = ServiceResultStatus.Error
													};
												}
												flag2 = true;
											}
											continue;
										}
										return new ServiceResult<IssueDraftFromOrderViewModel>
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
								MobspControlOrderItemsStock_Result mobspControlOrderItemsStock_Result = Enumerable.FirstOrDefault<MobspControlOrderItemsStock_Result>((IEnumerable<MobspControlOrderItemsStock_Result>)cRMSpEntities.MobspControlOrderItemsStock(model.OrdId, result, result2, text, model.CId));
								if (mobspControlOrderItemsStock_Result != null)
								{
									message = Messages.msgIssueDraftFormOrderImpossibilityIissued + "\r\n" + Messages.msgIssueDraftFormOrderLackInventory + "\r\n" + mobspControlOrderItemsStock_Result.PrdName;
									return new ServiceResult<IssueDraftFromOrderViewModel>
									{
										Message = message,
										Data = null,
										Status = ServiceResultStatus.Error
									};
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
									model.DateSelect = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd");
									break;
								case 1025:
									model.DateSelect = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									model.DateSelect = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture());
									break;
								}
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							message = "-1";
						}
						DateTime now = DateTime.Now;
						ObjectParameter objectParameter = new ObjectParameter("insertedDraftID", 0);
						ObjectParameter objectParameter2 = new ObjectParameter("insertedDraftNumber", 0);
						cRMSpEntities.MobspIssueDraftFromOrder(model.OrdId, model.DateSelect, UserLogin.CurrentUser.UserId, short.Parse(now.ToString("MM", new PersianCulture())), Financial.Get().Id, model.WhId, now.ToString("yyyyMMdd", new PersianCulture()), appType, objectParameter, objectParameter2, result2, text, (model.CId != 0) ? model.CId : null);
						int draftId = (int)objectParameter.Value;
						int value3 = (int)objectParameter2.Value;
						string text5 = "";
						MobspReturnDraftFromOrder_Result mobspReturnDraftFromOrder_Result2 = new MobspReturnDraftFromOrder_Result();
						List<MobspReturnDraftFromOrder_Result> list5 = Enumerable.ToList<MobspReturnDraftFromOrder_Result>((IEnumerable<MobspReturnDraftFromOrder_Result>)cRMSpEntities.MobspReturnDraftFromOrder(model.OrdId, num, result2));
						text2 = "";
						if (list5 != null && Enumerable.Any<MobspReturnDraftFromOrder_Result>((IEnumerable<MobspReturnDraftFromOrder_Result>)list5))
						{
							mobspReturnDraftFromOrder_Result2 = Enumerable.LastOrDefault<MobspReturnDraftFromOrder_Result>((IEnumerable<MobspReturnDraftFromOrder_Result>)list5);
							if (list5.Count > 1)
							{
								foreach (MobspReturnDraftFromOrder_Result item7 in list5)
								{
									text2 = text2 + item7.DocNumber + ",";
									text5 = text5 + item7.DocID + ",";
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
							mobspReturnDraftFromOrder_Result2 = null;
						}
						if (mobspReturnDraftFromOrder_Result2 != null)
						{
							if (string.IsNullOrEmpty(text2))
							{
								text2 = mobspReturnDraftFromOrder_Result2.DocNumber.ToString();
							}
							if (UserLogin.IsUserAccess("frmIssueDraftFromOrder", "actAutoReferDocToOrdReferUserAfterIssue", UserLogin.CurrentUser))
							{
								Doc.ReferDocToOrdReferUser(text5);
							}
							issueDraftFromOrderViewModel = new IssueDraftFromOrderViewModel();
							issueDraftFromOrderViewModel.DraftId = draftId;
							issueDraftFromOrderViewModel.DocNumbers = text2;
							issueDraftFromOrderViewModel.OprTypeId = mobspReturnDraftFromOrder_Result2.OprType;
							message = "";
							status = ServiceResultStatus.Success;
						}
						else
						{
							issueDraftFromOrderViewModel.DraftId = draftId;
							issueDraftFromOrderViewModel.DraftNumber = value3;
							issueDraftFromOrderViewModel.OprTypeId = 1;
							message = "";
							status = ServiceResultStatus.Success;
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					issueDraftFromOrderViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				issueDraftFromOrderViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			issueDraftFromOrderViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<IssueDraftFromOrderViewModel>
		{
			Message = message,
			Data = issueDraftFromOrderViewModel,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<DocLinkOrdViewModel> GetDocLinkOrd(int ordId, int? ln)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		DocLinkOrdViewModel docLinkOrdViewModel = new DocLinkOrdViewModel();
		docLinkOrdViewModel.OrderInfo = new MobspSelectOrderById_Result();
		docLinkOrdViewModel.OrderItems = new List<MobspSelectOrderItems_Result>();
		docLinkOrdViewModel.Docs = new List<MobspReturnDocForSaleOrder_Result>();
		docLinkOrdViewModel.DocItems = new List<MobspReturnDocItemsForSaleOrderItems_Result>();
		docLinkOrdViewModel.IsFind = false;
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
					_ = Mobile.Classes.Configuration.AppType;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					if (ordId != 0)
					{
						docLinkOrdViewModel.OrderInfo = Enumerable.FirstOrDefault<MobspSelectOrderById_Result>((IEnumerable<MobspSelectOrderById_Result>)cRMSpEntities.MobspSelectOrderById(ordId, num, result2));
						if (docLinkOrdViewModel.OrderInfo != null)
						{
							docLinkOrdViewModel.IsFind = true;
							docLinkOrdViewModel.OrderInfo.ordDate = (docLinkOrdViewModel.OrderInfo.ordDateTime.HasValue ? docLinkOrdViewModel.OrderInfo.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
							docLinkOrdViewModel.OrderInfo.AppType = ((!string.IsNullOrWhiteSpace(docLinkOrdViewModel.OrderInfo.OrderOpr)) ? docLinkOrdViewModel.OrderInfo.OrderOpr : Labels.lblOrd) + " (" + docLinkOrdViewModel.OrderInfo.ordNumber + ")";
							docLinkOrdViewModel.OrderInfo.ordCurrencyUnitIsDecimal = docLinkOrdViewModel.OrderInfo.ordCurrencyUnitIsDecimal.GetValueOrDefault();
							docLinkOrdViewModel.OrderItems = Enumerable.ToList<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)cRMEntities.MobspSelectOrderItems(ordId, num, result2));
							if (docLinkOrdViewModel.OrderItems == null)
							{
								docLinkOrdViewModel.OrderItems = new List<MobspSelectOrderItems_Result>();
							}
							docLinkOrdViewModel.Docs = Enumerable.ToList<MobspReturnDocForSaleOrder_Result>((IEnumerable<MobspReturnDocForSaleOrder_Result>)cRMEntities.MobspReturnDocForSaleOrder(ordId, num, result2));
							if (docLinkOrdViewModel.Docs != null)
							{
								if (Enumerable.Any<MobspReturnDocForSaleOrder_Result>((IEnumerable<MobspReturnDocForSaleOrder_Result>)docLinkOrdViewModel.Docs))
								{
									foreach (MobspReturnDocForSaleOrder_Result doc in docLinkOrdViewModel.Docs)
									{
										doc.DocDate = (doc.DocDateTime.HasValue ? doc.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
										doc.DocOpr = doc.DocNumber + " - " + ((!string.IsNullOrWhiteSpace(doc.DocOpr)) ? doc.DocOpr : Labels.lblWarehouseSheet) + " (" + doc.DocDate + ")";
									}
								}
							}
							else
							{
								docLinkOrdViewModel.Docs = new List<MobspReturnDocForSaleOrder_Result>();
							}
							docLinkOrdViewModel.DocItems = Enumerable.ToList<MobspReturnDocItemsForSaleOrderItems_Result>((IEnumerable<MobspReturnDocItemsForSaleOrderItems_Result>)cRMSpEntities.MobspReturnDocItemsForSaleOrderItems(ordId, num, result2));
							if (docLinkOrdViewModel.DocItems != null)
							{
								if (Enumerable.Any<MobspReturnDocItemsForSaleOrderItems_Result>((IEnumerable<MobspReturnDocItemsForSaleOrderItems_Result>)docLinkOrdViewModel.DocItems))
								{
									foreach (MobspReturnDocItemsForSaleOrderItems_Result docItem in docLinkOrdViewModel.DocItems)
									{
										docItem.DocDate = (docItem.DocDateTime.HasValue ? docItem.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
										docItem.OprName = docItem.DocNumber + " - " + ((!string.IsNullOrWhiteSpace(docItem.OprName)) ? docItem.OprName : Labels.lblWarehouseSheet) + " (" + docItem.DocDate + ")";
									}
								}
							}
							else
							{
								docLinkOrdViewModel.DocItems = new List<MobspReturnDocItemsForSaleOrderItems_Result>();
							}
							status = ServiceResultStatus.Success;
							message = "";
						}
						else
						{
							docLinkOrdViewModel.Message = Messages.ErrorNotFound;
						}
					}
					else
					{
						docLinkOrdViewModel.Message = Messages.msgErrorNotSelectedItem;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					docLinkOrdViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				docLinkOrdViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			docLinkOrdViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<DocLinkOrdViewModel>
		{
			Message = message,
			Data = docLinkOrdViewModel,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> DeleteDocLinkOrd(int position, int ordId, int docId, int ordItemId, int docItemId, int? ln)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
		string text = "";
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
					string appType = Mobile.Classes.Configuration.AppType;
					cRMSpEntities = new CRMSpEntities();
					int value = 1;
					string actionName = "";
					switch (position)
					{
					case 1:
						actionName = "actDeleteDocLink";
						value = 1;
						break;
					case 2:
						value = 2;
						actionName = "actDeleteDocLinkAll";
						break;
					case 3:
						actionName = "actDeleteDocItemLink";
						value = 1;
						break;
					case 4:
						actionName = "actDeleteDocItemLinkAll";
						value = 2;
						break;
					}
					if (!UserLogin.IsUserAccess("frmShowDocLinkOrd", actionName, UserLogin.CurrentUser))
					{
						data = false;
						text = Messages.ErrorNotAccess;
						status = ServiceResultStatus.Error;
						return new ServiceResult<bool>
						{
							Message = text,
							Data = data,
							Status = status
						};
					}
					if (ordId > 0)
					{
						DateTime now = DateTime.Now;
						DateTime value2 = now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
						short.Parse(Financial.Get().Id.ToString());
						_ = Financial.Get().Id;
						int userId = token2.userId;
						new ObjectParameter("ErrorMessage", "");
						int? num = null;
						switch (position)
						{
						case 1:
						case 2:
							num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspDeleteDocLinkOrder(value, ordId, docId, userId, value3, value2, registerDatePersian, appType));
							break;
						case 3:
						case 4:
							num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspDeleteDocItemLinkOrderItem(value, ordItemId, docItemId, userId, value3, value2, registerDatePersian, appType));
							break;
						}
						int result3 = 0;
						if (num.HasValue)
						{
							int.TryParse(num.ToString(), out result3);
						}
						text = ((result3 <= 0) ? Messages.msgErrorRunFunction : "");
					}
					else
					{
						data = false;
						text = Messages.ErrorNotFound;
						status = ServiceResultStatus.Error;
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						data = false;
						status = ServiceResultStatus.Error;
					}
					else
					{
						data = true;
						text = "";
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					text = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				text = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
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
			Message = text,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<string> CheckDiscountOnVerify(int ordId, int? cId = null, int? ln = null)
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
					text2 = Order.CheckBeforeVerification(ordId, token2.userId, cId, ln);
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
	public ServiceResult<string> ControlOrderItemsSoldStock(int ordId, int mode, string ordItemJson = "", string ordItemListStr = "", int? cId = null, int? Ln = null)
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
					int userId = token2.userId;
					UserLoginInfo currentUser = UserLogin.CurrentUser;
					int cmpId = 0;
					string format = Messages.msgErrorCanNotVerifyNoStockFromSold;
					string text = "";
					string text2 = "";
					bool flag = false;
					MobspSelectOrderById_Result mobspSelectOrderById_Result = Enumerable.FirstOrDefault<MobspSelectOrderById_Result>((IEnumerable<MobspSelectOrderById_Result>)cRMSpEntities.MobspSelectOrderById(ordId, num, result2));
					if (mobspSelectOrderById_Result != null)
					{
						cmpId = mobspSelectOrderById_Result.ordCompanyId;
						cId = mobspSelectOrderById_Result.ordCId.GetValueOrDefault();
					}
					if (mode == 1)
					{
						format = Messages.msgIssueDraftFormOrderLackSoldStock;
						text = "frmIssueDraftFromOrder";
						text2 = "actCanNotIssueDraftWithNoStockFromSold";
					}
					if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
					{
						flag = true;
					}
					else if (currentUser != null)
					{
						if (UserLogin.IsUserAccess(text, text2, currentUser, cId))
						{
							flag = true;
						}
					}
					else if (UserLogin.IsUserAccessByUserId(text, text2, userId, cId.GetValueOrDefault()))
					{
						flag = true;
					}
					if (flag)
					{
						List<MobspControlOrderItemsSoldStock_Result> list = Enumerable.ToList<MobspControlOrderItemsSoldStock_Result>((IEnumerable<MobspControlOrderItemsSoldStock_Result>)cRMSpEntities.MobspControlOrderItemsSoldStock(ordId, ordItemJson, ordItemListStr, cId, 1, id, num, result2));
						if (list != null && Enumerable.Any<MobspControlOrderItemsSoldStock_Result>((IEnumerable<MobspControlOrderItemsSoldStock_Result>)list))
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
							foreach (MobspControlOrderItemsSoldStock_Result item in list)
							{
								string text3 = "";
								double result3 = 0.0;
								double valueOrDefault = item.ordIQuantity.GetValueOrDefault();
								item.RemainCountAllWH.GetValueOrDefault();
								double valueOrDefault2 = item.SoldOrdQuantity.GetValueOrDefault();
								double valueOrDefault3 = item.TracingRemainCount.GetValueOrDefault();
								if (flag2 && num2 > 0)
								{
									string prdIds = item.ordIPrdId.GetValueOrDefault().ToString();
									string wcf = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.RequestUri.ToString().Split(new string[1] { "/api" }, StringSplitOptions.None));
									HttpRequestHeaders headers = base.Request.Headers;
									int valueOrDefault4 = item.ordIWHId.GetValueOrDefault();
									ServiceResult<string> prdQuantity = OtherSystems.GetPrdQuantity(headers, wcf, prdIds, cmpId, valueOrDefault4, num, num2.ToString(), item.ordITracing ?? "");
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
					if (!UserLogin.IsUserAccess("frmOrder", "actVerifyPayOrder", UserLogin.CurrentUser, cId))
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
					cRMSpEntities.MobspOrderPaymentVerify(payId, userId, now, registerDatePersian);
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
					if (!UserLogin.IsUserAccess("frmOrder", "actExitVerifyPayOrder", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<bool>
						{
							Message = Messages.DoNotHaveAccess,
							Data = false,
							Status = ServiceResultStatus.Error
						};
					}
					cRMSpEntities.MobspOrderPaymentVerifyExit(payId);
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
					cRMSpEntities.MobspOrderPaymentDeActive(payId, userId, value, text);
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
					if (!UserLogin.IsUserAccess("frmOrder", "actExitCanceledPay", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<bool>
						{
							Message = Messages.DoNotHaveAccess,
							Data = false,
							Status = ServiceResultStatus.Error
						};
					}
					cRMSpEntities.MobspOrderPaymentDeActiveExit(payId);
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
	public ServiceResult<bool> GetOrdSepPayIsCqh(int payId, int linkAccSettingDBId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int num = ((result > 0) ? result : result2);
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					if (payId != 0)
					{
						MobspLkSepWSSelectOrderPaymentsById_Result mobspLkSepWSSelectOrderPaymentsById_Result = Enumerable.FirstOrDefault<MobspLkSepWSSelectOrderPaymentsById_Result>((IEnumerable<MobspLkSepWSSelectOrderPaymentsById_Result>)new CRMSpEntities().MobspLkSepWSSelectOrderPaymentsById(payId, num, result2, linkAccSettingDBId));
						if (mobspLkSepWSSelectOrderPaymentsById_Result != null)
						{
							int result3 = 0;
							int.TryParse(mobspLkSepWSSelectOrderPaymentsById_Result.SepDetailType.ToString(), out result3);
							data = result3 == 2;
						}
						message = null;
						status = ServiceResultStatus.Success;
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
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
