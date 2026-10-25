using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;
using TaxCollectData.Library.Business;
using TaxCollectData.Library.Dto;
using TaxCollectData.Library.Dto.Config;
using TaxCollectData.Library.Dto.Content;
using TaxCollectData.Library.Dto.Properties;
using TaxCollectData.Library.Dto.Transfer;
using TaxCollectData.Library.Enums;

namespace CRMIdeal.Classes.Helper.Tsp;

public class TspTax
{
	public static string UrlTsp = "https://tp.tax.gov.ir/req/api/";

	public static string _TspTokenErrMessage = "";

	public static string CreateTspOrdMessage(string tspOrdMessage, string errorCode, string errorDetail, bool isError)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			DateTime now = DateTime.Now;
			string msgDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			List<TspOrdMessageViewModel> list = new List<TspOrdMessageViewModel>();
			tspOrdMessage = "";
			if (!string.IsNullOrWhiteSpace(tspOrdMessage))
			{
				list = new JavaScriptSerializer().Deserialize<List<TspOrdMessageViewModel>>(tspOrdMessage);
			}
			if (list == null)
			{
				list = new List<TspOrdMessageViewModel>();
			}
			TspOrdMessageViewModel item = new TspOrdMessageViewModel
			{
				ErrorCode = errorCode,
				Message = errorDetail,
				IsError = isError,
				MsgDate = now,
				MsgDatePersian = msgDatePersian
			};
			list.Add(item);
			if (list != null)
			{
				tspOrdMessage = JsonConvert.SerializeObject(Enumerable.ToList<TspOrdMessageViewModel>((IEnumerable<TspOrdMessageViewModel>)list));
			}
			result = tspOrdMessage;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static void UpdateOrder(int ordId, string tspOrdIdentify, string tspOrdInno, int? tspOrdIns, DateTime? tspOrdSendDate, string tspOrdSendDatePersian, DateTime? tspOrdLastEditDate, string tspOrdLastEditDatePersian, string tspOrdUID, string tspOrdReferenceNumber, string tspOrdStatus, string tspOrdMessage, string tspOrdIrtaxid, int tspOrdSendTypeId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			if (ordId != 0)
			{
				cRMSpIEntities.TSPspUpdateOrder(ordId, tspOrdIdentify, tspOrdInno, tspOrdIns, tspOrdSendDate, tspOrdSendDatePersian, tspOrdLastEditDate, tspOrdLastEditDatePersian, tspOrdUID, tspOrdReferenceNumber, tspOrdStatus, tspOrdMessage, appType, tspOrdIrtaxid, tspOrdSendTypeId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
	}

	public static void InsertOrder(int ordId, int orderOprId, string tspOrdIdentify, string tspOrdInno, int? tspOrdIns, DateTime? tspOrdSendDate, string tspOrdSendDatePersian, DateTime? tspOrdLastEditDate, string tspOrdLastEditDatePersian, string tspOrdUID, string tspOrdReferenceNumber, string tspOrdStatus, string tspOrdMessage)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int num = 0;
			int? centerId = null;
			if (currentUser != null)
			{
				centerId = currentUser.UserLastCId;
				num = currentUser.UserId;
			}
			if (ordId != 0 && num != 0)
			{
				ObjectParameter objectParameter = new ObjectParameter("insertedOrderId", typeof(int));
				cRMSpIIEntities.TSPspInsertOrder(ordId, orderOprId, tspOrdIdentify, tspOrdInno, tspOrdIns, tspOrdSendDate, tspOrdSendDatePersian, tspOrdLastEditDate, tspOrdLastEditDatePersian, tspOrdUID, tspOrdReferenceNumber, tspOrdStatus, tspOrdMessage, centerId, num, value2, id, value, registerDatePersian, appType, result, objectParameter);
				int result2 = 0;
				if (objectParameter != null && objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
				{
					int.TryParse(objectParameter.Value.ToString(), out result2);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities.Dispose();
		}
	}

	private static string CleanPrivateKey(string privateKey)
	{
		try
		{
			if (!string.IsNullOrWhiteSpace(privateKey))
			{
				privateKey = privateKey.Replace("-----BEGIN PRIVATE KEY-----\r\n", "").Replace("\r\n-----END PRIVATE KEY-----", "");
				privateKey = privateKey.Replace("-----BEGIN PRIVATE KEY-----\n", "").Replace("\n-----END PRIVATE KEY-----", "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return privateKey;
	}

	public static CommonResultViewModel<int> SendOrder(int ordId, DateTime sendDateTime, int tspSendType = 1)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			DateTime now = DateTime.Now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			_ = now.Ticks;
			if (ordId != 0)
			{
				int num = 0;
				TSPspSelectOrderById_Result tSPspSelectOrderById_Result = Enumerable.FirstOrDefault<TSPspSelectOrderById_Result>((IEnumerable<TSPspSelectOrderById_Result>)cRMSpIEntities.TSPspSelectOrderById(ordId, lCID, result));
				if (tSPspSelectOrderById_Result != null)
				{
					int result2 = 0;
					int.TryParse(tSPspSelectOrderById_Result.ordTspSettingId.ToString(), out result2);
					int result3 = 0;
					int.TryParse(tSPspSelectOrderById_Result.TspOrdStatusResultNum.ToString(), out result3);
					if ((tSPspSelectOrderById_Result.TspOrdStatusResult ?? "") == "رد شده" && tspSendType == 3)
					{
						result3 = 0;
					}
					else if (result3 == 1 && tspSendType == 3)
					{
						return new CommonResultViewModel<int>
						{
							Data = data,
							Message = text,
							Status = status
						};
					}
					int num2 = 0;
					int tspOrdSendTypeId = 0;
					switch (tspSendType)
					{
					case 1:
						tspOrdSendTypeId = 1;
						break;
					case 11:
						tspOrdSendTypeId = 2;
						break;
					case 5:
						tspOrdSendTypeId = 3;
						num2 = 1;
						break;
					}
					if (result2 != 0)
					{
						TSPspSelectSettingById_Result tSPspSelectSettingById_Result = Enumerable.FirstOrDefault<TSPspSelectSettingById_Result>((IEnumerable<TSPspSelectSettingById_Result>)cRMSpIEntities.TSPspSelectSettingById(result2, lCID, result));
						if (tSPspSelectSettingById_Result != null)
						{
							string text3 = CleanPrivateKey(tSPspSelectSettingById_Result.TspPrivateKey);
							TaxApiService.Instance.Init(tSPspSelectSettingById_Result.TspIdentify, new SignatoryConfig(text3, null), new NormalProperties(ClientType.SELF_TSP), UrlTsp);
							TaxApiService.Instance.TaxApis.GetServerInformation();
							if (TaxApiService.Instance.TaxApis.RequestToken() != null)
							{
								if (tSPspSelectOrderById_Result != null)
								{
									string text4 = string.Format(Labels.lbItemByNumber, tSPspSelectOrderById_Result.OrderOpr ?? Labels.lblOrd, tSPspSelectOrderById_Result.ordNumber.ToString());
									bool result4 = false;
									bool.TryParse(tSPspSelectOrderById_Result.ordIsVerified.ToString(), out result4);
									if (!result4)
									{
										num++;
										text = text + string.Format(Messages.msgErrorItemNotVerified, text4) + "<br>";
									}
									if (string.IsNullOrWhiteSpace(tSPspSelectSettingById_Result.TspEconomicCode))
									{
										num++;
										text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspEconomic) + "<br>";
									}
									string text5 = "";
									string text6 = "";
									string text7 = "";
									string text8 = "";
									if (tspSendType == 3)
									{
										text5 = tSPspSelectOrderById_Result.TspOrdIdentify ?? "";
										text6 = tSPspSelectOrderById_Result.TspOrdInno ?? "";
										text7 = tSPspSelectOrderById_Result.TspOrdUID ?? "";
										text8 = tSPspSelectOrderById_Result.TspOrdReferenceNumber ?? "";
									}
									string text9 = "";
									string text10 = "";
									string text11 = "";
									string text12 = "";
									if (tspSendType == 4)
									{
										text9 = tSPspSelectOrderById_Result.TspOrdIdentify ?? "";
										text10 = tSPspSelectOrderById_Result.TspOrdInno ?? "";
										text11 = tSPspSelectOrderById_Result.TspOrdUID ?? "";
										text12 = tSPspSelectOrderById_Result.TspOrdReferenceNumber ?? "";
									}
									tSPspSelectOrderById_Result.FirstRegisterDate = tSPspSelectOrderById_Result.ordDateTime;
									int result5 = 0;
									int.TryParse(tSPspSelectSettingById_Result.TspSendDateType.ToString(), out result5);
									if (tspSendType == 11 || tspSendType == 3)
									{
										tSPspSelectOrderById_Result.ordDateTime = sendDateTime;
										tSPspSelectOrderById_Result.FirstRegisterDate = sendDateTime;
									}
									bool result6 = false;
									bool.TryParse(tSPspSelectSettingById_Result.TspSendPay.ToString(), out result6);
									int result7 = 1;
									CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
									if (cRMspSelectCrmsysSetting_Result != null)
									{
										int.TryParse(cRMspSelectCrmsysSetting_Result.TspPrdSendMethod.ToString(), out result7);
									}
									if (result7 == 0)
									{
										result7 = 1;
									}
									bool result8 = false;
									bool.TryParse(tSPspSelectOrderById_Result.TspSendOrdWithoutDisc.ToString(), out result8);
									List<TSPspSelectOrderItems_Result> list = new List<TSPspSelectOrderItems_Result>();
									List<TSPspSelectOrderItems_Result> list2 = Enumerable.ToList<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)cRMSpIEntities.TSPspSelectOrderItems(ordId, false, lCID, result));
									if (list2 == null || !Enumerable.Any<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list2))
									{
										num++;
										text = text + string.Format(Messages.msgErrorItemNotDefinedPrd, text4) + "<br>";
									}
									else
									{
										if (result8)
										{
											foreach (TSPspSelectOrderItems_Result item4 in list2)
											{
												if (item4.ordIPrice.GetValueOrDefault() != 0m)
												{
													item4.ordIPrice = item4.ordIPrice.GetValueOrDefault() - item4.ordIDiscount.GetValueOrDefault();
												}
												item4.ordIDiscountI = null;
												item4.ordIDiscount = null;
												item4.ordIDiscountPercent = null;
												item4.ordIDiscountIPercent = null;
												item4.ordIDiscountISum = null;
												item4.ordIDiscountSum = null;
												item4.ordIDiscountDesc = null;
											}
										}
										switch (result7)
										{
										case 1:
											foreach (TSPspSelectOrderItems_Result item5 in list2)
											{
												string fgIdentify = item5.TspFGIndentify;
												if (string.IsNullOrWhiteSpace(fgIdentify))
												{
													continue;
												}
												if (list != null && Enumerable.Any<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list))
												{
													if (Enumerable.FirstOrDefault<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list, (Func<TSPspSelectOrderItems_Result, bool>)((TSPspSelectOrderItems_Result m) => m.TspFGIndentify == fgIdentify)) != null)
													{
														foreach (TSPspSelectOrderItems_Result item6 in list)
														{
															if (!string.IsNullOrWhiteSpace(item6.TspFGIndentify) && item6.TspFGIndentify == fgIdentify)
															{
																item6.ordIQuantityTotal = null;
																item6.ordIQuantity = 1.0;
																item6.ordIFCR = 1.0;
																item6.ordIFCRI = 1.0;
																item6.ordIPrice = item6.ordIPrice.GetValueOrDefault() + item5.ordIPrice.GetValueOrDefault();
																item6.ordITotalPrice = item6.ordITotalPrice.GetValueOrDefault() + item5.ordITotalPrice.GetValueOrDefault();
																item6.ordIDiscountI = item6.ordIDiscountI.GetValueOrDefault() + item5.ordIDiscountI.GetValueOrDefault();
																item6.ordIDiscount = item6.ordIDiscount.GetValueOrDefault() + item5.ordIDiscount.GetValueOrDefault();
																item6.ordITax = item6.ordITax.GetValueOrDefault() + item5.ordITax.GetValueOrDefault();
																if (item6.ordITax.GetValueOrDefault() > 0m)
																{
																	item6.ordITaxIndex = item6.ordITaxIndex.GetValueOrDefault(9m);
																}
																item6.ordIRound = item6.ordIRound.GetValueOrDefault() + item5.ordIRound.GetValueOrDefault();
																item6.ordIRoundPlus = item6.ordIRoundPlus.GetValueOrDefault() + item5.ordIRoundPlus.GetValueOrDefault();
																item6.ordIPriceSum = item6.ordIPriceSum.GetValueOrDefault() + item5.ordIPriceSum.GetValueOrDefault();
																item6.ordIDiscountISum = item6.ordIDiscountISum.GetValueOrDefault() + item5.ordIDiscountISum.GetValueOrDefault();
																item6.ordIDiscountSum = item6.ordIDiscountSum.GetValueOrDefault() + item5.ordIDiscountSum.GetValueOrDefault();
																item6.ordITaxSum = item6.ordITaxSum.GetValueOrDefault() + item5.ordITaxSum.GetValueOrDefault();
																item6.TspOrdICfee = item6.TspOrdICfee.GetValueOrDefault() + item5.TspOrdICfee.GetValueOrDefault();
																item6.TspOrdIExr = item6.TspOrdIExr.GetValueOrDefault() + item5.TspOrdIExr.GetValueOrDefault();
																item6.TspOrdIOdr = item6.TspOrdIOdr.GetValueOrDefault() + item5.TspOrdIOdr.GetValueOrDefault();
																item6.TspOrdIOdam = item6.TspOrdIOdam.GetValueOrDefault() + item5.TspOrdIOdam.GetValueOrDefault();
																item6.TspOrdIOlr = item6.TspOrdIOlr.GetValueOrDefault() + item5.TspOrdIOlr.GetValueOrDefault();
																item6.TspOrdIOlam = item6.TspOrdIOlam.GetValueOrDefault() + item5.TspOrdIOlam.GetValueOrDefault();
																item6.TspOrdIConsfee = item6.TspOrdIConsfee.GetValueOrDefault() + item5.TspOrdIConsfee.GetValueOrDefault();
																item6.TspOrdISpro = item6.TspOrdISpro.GetValueOrDefault() + item5.TspOrdISpro.GetValueOrDefault();
																item6.TspOrdIBros = item6.TspOrdIBros.GetValueOrDefault() + item5.TspOrdIBros.GetValueOrDefault();
																item6.TspOrdICop = item6.TspOrdICop.GetValueOrDefault() + item5.TspOrdICop.GetValueOrDefault();
																item6.TspOrdIVop = item6.TspOrdIVop.GetValueOrDefault() + item5.TspOrdIVop.GetValueOrDefault();
																item6.TspOrdISscv = item6.TspOrdISscv.GetValueOrDefault() + item5.TspOrdISscv.GetValueOrDefault();
																item6.TspOrdISsrv = item6.TspOrdISsrv.GetValueOrDefault() + item5.TspOrdISsrv.GetValueOrDefault();
																item6.TspOrdIPspd = item6.TspOrdIPspd.GetValueOrDefault() + item5.TspOrdIPspd.GetValueOrDefault();
																item6.TspOrdICui = item6.TspOrdICui.GetValueOrDefault() + item5.TspOrdICui.GetValueOrDefault();
															}
														}
													}
													else
													{
														item5.TspPrdIndentify = item5.TspFGIndentify;
														item5.TspPrdName = item5.TspFGName;
														list.Add(item5);
													}
												}
												else
												{
													item5.TspPrdIndentify = item5.TspFGIndentify;
													item5.TspPrdName = item5.TspFGName;
													list.Add(item5);
												}
											}
											break;
										case 3:
											foreach (TSPspSelectOrderItems_Result item7 in list2)
											{
												string sgIdentify = item7.TspSGIndentify;
												if (string.IsNullOrWhiteSpace(sgIdentify))
												{
													continue;
												}
												if (list != null && Enumerable.Any<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list))
												{
													if (Enumerable.FirstOrDefault<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list, (Func<TSPspSelectOrderItems_Result, bool>)((TSPspSelectOrderItems_Result m) => m.TspSGIndentify == sgIdentify)) != null)
													{
														foreach (TSPspSelectOrderItems_Result item8 in list)
														{
															if (!string.IsNullOrWhiteSpace(item8.TspSGIndentify) && item8.TspSGIndentify == sgIdentify)
															{
																item8.ordIQuantityTotal = null;
																item8.ordIQuantity = 1.0;
																item8.ordIFCR = 1.0;
																item8.ordIFCRI = 1.0;
																item8.ordIPrice = item8.ordIPrice.GetValueOrDefault() + item7.ordIPrice.GetValueOrDefault();
																item8.ordITotalPrice = item8.ordITotalPrice.GetValueOrDefault() + item7.ordITotalPrice.GetValueOrDefault();
																item8.ordIDiscountI = item8.ordIDiscountI.GetValueOrDefault() + item7.ordIDiscountI.GetValueOrDefault();
																item8.ordIDiscount = item8.ordIDiscount.GetValueOrDefault() + item7.ordIDiscount.GetValueOrDefault();
																item8.ordITax = item8.ordITax.GetValueOrDefault() + item7.ordITax.GetValueOrDefault();
																if (item8.ordITax.GetValueOrDefault() > 0m)
																{
																	item8.ordITaxIndex = item8.ordITaxIndex.GetValueOrDefault(9m);
																}
																item8.ordIRound = item8.ordIRound.GetValueOrDefault() + item7.ordIRound.GetValueOrDefault();
																item8.ordIRoundPlus = item8.ordIRoundPlus.GetValueOrDefault() + item7.ordIRoundPlus.GetValueOrDefault();
																item8.ordIPriceSum = item8.ordIPriceSum.GetValueOrDefault() + item7.ordIPriceSum.GetValueOrDefault();
																item8.ordIDiscountISum = item8.ordIDiscountISum.GetValueOrDefault() + item7.ordIDiscountISum.GetValueOrDefault();
																item8.ordIDiscountSum = item8.ordIDiscountSum.GetValueOrDefault() + item7.ordIDiscountSum.GetValueOrDefault();
																item8.ordITaxSum = item8.ordITaxSum.GetValueOrDefault() + item7.ordITaxSum.GetValueOrDefault();
																item8.TspOrdICfee = item8.TspOrdICfee.GetValueOrDefault() + item7.TspOrdICfee.GetValueOrDefault();
																item8.TspOrdIExr = item8.TspOrdIExr.GetValueOrDefault() + item7.TspOrdIExr.GetValueOrDefault();
																item8.TspOrdIOdr = item8.TspOrdIOdr.GetValueOrDefault() + item7.TspOrdIOdr.GetValueOrDefault();
																item8.TspOrdIOdam = item8.TspOrdIOdam.GetValueOrDefault() + item7.TspOrdIOdam.GetValueOrDefault();
																item8.TspOrdIOlr = item8.TspOrdIOlr.GetValueOrDefault() + item7.TspOrdIOlr.GetValueOrDefault();
																item8.TspOrdIOlam = item8.TspOrdIOlam.GetValueOrDefault() + item7.TspOrdIOlam.GetValueOrDefault();
																item8.TspOrdIConsfee = item8.TspOrdIConsfee.GetValueOrDefault() + item7.TspOrdIConsfee.GetValueOrDefault();
																item8.TspOrdISpro = item8.TspOrdISpro.GetValueOrDefault() + item7.TspOrdISpro.GetValueOrDefault();
																item8.TspOrdIBros = item8.TspOrdIBros.GetValueOrDefault() + item7.TspOrdIBros.GetValueOrDefault();
																item8.TspOrdICop = item8.TspOrdICop.GetValueOrDefault() + item7.TspOrdICop.GetValueOrDefault();
																item8.TspOrdIVop = item8.TspOrdIVop.GetValueOrDefault() + item7.TspOrdIVop.GetValueOrDefault();
																item8.TspOrdISscv = item8.TspOrdISscv.GetValueOrDefault() + item7.TspOrdISscv.GetValueOrDefault();
																item8.TspOrdISsrv = item8.TspOrdISsrv.GetValueOrDefault() + item7.TspOrdISsrv.GetValueOrDefault();
																item8.TspOrdIPspd = item8.TspOrdIPspd.GetValueOrDefault() + item7.TspOrdIPspd.GetValueOrDefault();
																item8.TspOrdICui = item8.TspOrdICui.GetValueOrDefault() + item7.TspOrdICui.GetValueOrDefault();
															}
														}
													}
													else
													{
														item7.TspPrdIndentify = item7.TspSGIndentify;
														item7.TspPrdName = item7.TspSGName;
														list.Add(item7);
													}
												}
												else
												{
													item7.TspPrdIndentify = item7.TspSGIndentify;
													item7.TspPrdName = item7.TspSGName;
													list.Add(item7);
												}
											}
											break;
										case 2:
											foreach (TSPspSelectOrderItems_Result item9 in list2)
											{
												if (!string.IsNullOrWhiteSpace(item9.TspPrdIndentify))
												{
													list.Add(item9);
												}
											}
											break;
										}
									}
									if (list == null || !Enumerable.Any<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list))
									{
										num++;
										text = text + string.Format(Messages.msgErrorItemNotDefinedPrdByTspIndentify, text4) + "<br>";
									}
									else
									{
										foreach (TSPspSelectOrderItems_Result item10 in list)
										{
											if (string.IsNullOrWhiteSpace(item10.TspPrdIndentify))
											{
												num++;
												text = text + string.Format(Messages.msgErrorPrdNoSetTspTaxId, item10.PrdName ?? "", item10.PrdCode ?? "", text4) + "<br>";
											}
										}
									}
									List<TSPspSelectOrderPayments_Result> list3 = Enumerable.ToList<TSPspSelectOrderPayments_Result>((IEnumerable<TSPspSelectOrderPayments_Result>)cRMSpIEntities.TSPspSelectOrderPayments(ordId, lCID, result));
									string text13 = tSPspSelectOrderById_Result.TspOrdIdentify ?? "";
									string text14 = tSPspSelectOrderById_Result.TspOrdInno ?? "";
									switch (tspSendType)
									{
									case 3:
										text13 = "";
										text14 = "";
										break;
									case 4:
										text13 = "";
										text14 = "";
										break;
									default:
										if (string.IsNullOrWhiteSpace(text13) && !string.IsNullOrWhiteSpace(text14))
										{
											text14 = "";
										}
										break;
									}
									if (string.IsNullOrWhiteSpace(text14))
									{
										TSPspReturnOrderInno_Result tSPspReturnOrderInno_Result = Enumerable.FirstOrDefault<TSPspReturnOrderInno_Result>((IEnumerable<TSPspReturnOrderInno_Result>)cRMSpIEntities.TSPspReturnOrderInno(ordId));
										if (tSPspReturnOrderInno_Result != null)
										{
											text14 = tSPspReturnOrderInno_Result.TspOrdInnoDecimal ?? "";
											if (!string.IsNullOrWhiteSpace(text14) && text14.Length < 10)
											{
												int length = text14.Length;
												for (int i = 0; i < 10 - length; i++)
												{
													text14 = "0" + text14;
												}
											}
										}
									}
									if (string.IsNullOrWhiteSpace(text13))
									{
										long serial = long.Parse(text14);
										text13 = TaxApiService.Instance.TaxIdGenerator.GenerateTaxId(tSPspSelectSettingById_Result.TspIdentify, serial, tSPspSelectOrderById_Result.ordDateTime.GetValueOrDefault(now));
									}
									if (string.IsNullOrWhiteSpace(text13))
									{
										num++;
										text = text + Messages.msgErrorCreateOrdTaxId + "<br>";
									}
									if (string.IsNullOrWhiteSpace(text14))
									{
										num++;
										text = text + Messages.msgErrorCreateTspOrdInno + "<br>";
									}
									int result9 = 0;
									int.TryParse(tSPspSelectOrderById_Result.OrderOprType.ToString(), out result9);
									int result10 = 0;
									int.TryParse(tSPspSelectOrderById_Result.ordStatusId.ToString(), out result10);
									int result11 = 0;
									int.TryParse(tSPspSelectOrderById_Result.TspCmpTob.ToString(), out result11);
									if (result11 != 2)
									{
										tSPspSelectOrderById_Result.TspInty = tSPspSelectOrderById_Result.TspIntyI;
										tSPspSelectOrderById_Result.TspIns = tSPspSelectOrderById_Result.TspInsI;
										tSPspSelectOrderById_Result.TspInp = tSPspSelectOrderById_Result.TspInpI;
									}
									int result12 = 0;
									int result13 = 0;
									int result14 = 0;
									int.TryParse(tSPspSelectOrderById_Result.ExceptTspInty.ToString(), out result12);
									int.TryParse(tSPspSelectOrderById_Result.ExceptTspInp.ToString(), out result13);
									int.TryParse(tSPspSelectOrderById_Result.ExceptTspIns.ToString(), out result14);
									if (result12 != 0)
									{
										tSPspSelectOrderById_Result.TspInty = tSPspSelectOrderById_Result.ExceptTspInty;
										tSPspSelectOrderById_Result.TspIns = tSPspSelectOrderById_Result.ExceptTspIns;
										tSPspSelectOrderById_Result.TspInp = tSPspSelectOrderById_Result.ExceptTspInp;
									}
									int result15 = 0;
									int.TryParse(tSPspSelectOrderById_Result.TspInty.ToString(), out result15);
									if (result15 == 0)
									{
										num++;
										text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspInty) + "<br>";
									}
									int result16 = 0;
									int.TryParse(tSPspSelectOrderById_Result.TspInp.ToString(), out result16);
									if (result16 == 0 && result15 != 3)
									{
										num++;
										text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspInp) + "<br>";
									}
									int result17 = 0;
									int.TryParse(tSPspSelectOrderById_Result.TspIns.ToString(), out result17);
									int result18 = 0;
									int.TryParse(tSPspSelectOrderById_Result.TspOrdIns.ToString(), out result18);
									result18 = result17;
									if (result10 == 4)
									{
										result18 = 3;
									}
									if (tspSendType == 3)
									{
										result18 = 3;
									}
									if (tspSendType == 4)
									{
										result18 = 2;
									}
									if (result18 == 0)
									{
										num++;
										text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspOrdIns) + "<br>";
									}
									int result19 = 0;
									int.TryParse(tSPspSelectOrderById_Result.TspCmpTob.ToString(), out result19);
									_ = tSPspSelectOrderById_Result.TspCmpBbc;
									string cmpEconomicCode = tSPspSelectOrderById_Result.cmpEconomicCode;
									cmpEconomicCode = tSPspSelectOrderById_Result.cmpNationalCode;
									if (result19 != 2)
									{
										cmpEconomicCode = "";
									}
									if (result12 != 0)
									{
										cmpEconomicCode = tSPspSelectOrderById_Result.cmpEconomicCode;
									}
									string cmpNationalCode = tSPspSelectOrderById_Result.cmpNationalCode;
									string text15 = cmpNationalCode;
									string tspOrdSbc = tSPspSelectOrderById_Result.TspOrdSbc;
									string tspOrdScln = tSPspSelectOrderById_Result.TspOrdScln;
									string tspOrdScc = tSPspSelectOrderById_Result.TspOrdScc;
									string tspOrdCrn = tSPspSelectOrderById_Result.TspOrdCrn;
									string cmpOfficialZipCode = tSPspSelectOrderById_Result.cmpOfficialZipCode;
									string tspCmpBbc = tSPspSelectOrderById_Result.TspCmpBbc;
									string tspCmpBpn = tSPspSelectOrderById_Result.TspCmpBpn;
									int? tspOrdFt = tSPspSelectOrderById_Result.TspOrdFt;
									string tspOrdBillid = tSPspSelectOrderById_Result.TspOrdBillid;
									if (!string.IsNullOrWhiteSpace(text15) && !string.IsNullOrWhiteSpace(tSPspSelectSettingById_Result.TspNationalCode) && text15 == tSPspSelectSettingById_Result.TspNationalCode)
									{
										num++;
										text = text + Messages.msgErrorNationalCodeSellerAndBuyerIsSame + "<br>";
									}
									int? num3 = tSPspSelectOrderById_Result.TspOrdSetm.GetValueOrDefault(1);
									decimal num4 = default(decimal);
									decimal num5 = default(decimal);
									decimal? tspOrdTax = tSPspSelectOrderById_Result.TspOrdTax17;
									string text16 = tSPspSelectOrderById_Result.TspOrdIrtaxid;
									if (tspSendType == 3)
									{
										text16 = text5 ?? "";
									}
									if (tspSendType == 4)
									{
										text16 = text9 ?? "";
									}
									string text17 = tSPspSelectSettingById_Result.TspEconomicCode;
									if (!string.IsNullOrWhiteSpace(tSPspSelectSettingById_Result.TspNationalCode))
									{
										text17 = tSPspSelectSettingById_Result.TspNationalCode;
									}
									switch (result15)
									{
									case 1:
										if (string.IsNullOrWhiteSpace(text16) && result18 != 1)
										{
											num++;
											text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspOrdIrtaxid) + "<br>";
										}
										if (result19 == 0)
										{
											num++;
											text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspCmpTob) + "<br>";
										}
										switch (result16)
										{
										case 1:
											if (num3.GetValueOrDefault() == 0)
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspSetm) + "<br>";
											}
											break;
										case 2:
											if (string.IsNullOrWhiteSpace(tspOrdScln))
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.ordTspOrdScln) + "<br>";
											}
											if (string.IsNullOrWhiteSpace(tspOrdScc))
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.ordTspOrdScc) + "<br>";
											}
											foreach (TSPspSelectOrderItems_Result item11 in list)
											{
												if (item11.TspOrdICfee.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspCfee, item11.PrdName ?? "", item11.PrdCode ?? "")) + "<br>";
												}
												if (string.IsNullOrWhiteSpace(item11.TspOrdICut))
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspCut, item11.PrdName ?? "", item11.PrdCode ?? "")) + "<br>";
												}
												if (item11.TspOrdIExr.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspExr, item11.PrdName ?? "", item11.PrdCode ?? "")) + "<br>";
												}
												if (item11.TspOrdIPspd.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspPspd, item11.PrdName ?? "", item11.PrdCode ?? "")) + "<br>";
												}
											}
											if (num3.GetValueOrDefault() == 0)
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspSetm) + "<br>";
											}
											break;
										case 3:
											foreach (TSPspSelectOrderItems_Result item12 in list)
											{
												if (item12.TspOrdIConsfee.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspConsfee, item12.PrdName ?? "", item12.PrdCode ?? "")) + "<br>";
												}
												if (item12.TspOrdISpro.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspSpro, item12.PrdName ?? "", item12.PrdCode ?? "")) + "<br>";
												}
												if (item12.TspOrdIBros.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspBros, item12.PrdName ?? "", item12.PrdCode ?? "")) + "<br>";
												}
											}
											if (num3.GetValueOrDefault() == 0)
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspSetm) + "<br>";
											}
											break;
										case 4:
											if (string.IsNullOrWhiteSpace(tspOrdCrn))
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.ordTspOrdCrn) + "<br>";
											}
											if (num3.GetValueOrDefault() == 0)
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspSetm) + "<br>";
											}
											break;
										case 5:
											if (string.IsNullOrWhiteSpace(tspOrdBillid))
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspBillid) + "<br>";
											}
											foreach (TSPspSelectOrderItems_Result item13 in list)
											{
												if (string.IsNullOrWhiteSpace(item13.TspOrdIOlt))
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspOlt, item13.PrdName ?? "", item13.PrdCode ?? "")) + "<br>";
												}
												if (item13.TspOrdIOdr.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspOdr, item13.PrdName ?? "", item13.PrdCode ?? "")) + "<br>";
												}
												if (item13.TspOrdIOdam.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspOdam, item13.PrdName ?? "", item13.PrdCode ?? "")) + "<br>";
												}
											}
											break;
										case 6:
											if (string.IsNullOrWhiteSpace(tspCmpBpn))
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspBpn) + "<br>";
											}
											if (tspOrdFt.GetValueOrDefault() == 0)
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspFt) + "<br>";
											}
											break;
										case 7:
											foreach (TSPspSelectOrderItems_Result item14 in list)
											{
												if (item14.TspOrdICfee.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspCfee, item14.PrdName ?? "", item14.PrdCode ?? "")) + "<br>";
												}
												if (string.IsNullOrWhiteSpace(item14.TspOrdICut))
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspCut, item14.PrdName ?? "", item14.PrdCode ?? "")) + "<br>";
												}
												if (item14.TspOrdIExr.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspExr, item14.PrdName ?? "", item14.PrdCode ?? "")) + "<br>";
												}
												if (item14.TspOrdISscv.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspSscv, item14.PrdName ?? "", item14.PrdCode ?? "")) + "<br>";
												}
												if (item14.TspOrdISsrv.GetValueOrDefault() == 0m)
												{
													num++;
													text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspSsrv, item14.PrdName ?? "", item14.PrdCode ?? "")) + "<br>";
												}
											}
											break;
										}
										break;
									case 2:
										if (string.IsNullOrWhiteSpace(tSPspSelectOrderById_Result.TspOrdIrtaxid) && result18 == 4)
										{
											num++;
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspOrdIrtaxid);
										}
										if (result16 != 3)
										{
											break;
										}
										foreach (TSPspSelectOrderItems_Result item15 in list)
										{
											if (item15.TspOrdIConsfee.GetValueOrDefault() == 0m)
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspConsfee, item15.PrdName ?? "", item15.PrdCode ?? "")) + "<br>";
											}
											if (item15.TspOrdISpro.GetValueOrDefault() == 0m)
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspSpro, item15.PrdName ?? "", item15.PrdCode ?? "")) + "<br>";
											}
											if (item15.TspOrdIBros.GetValueOrDefault() == 0m)
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspBros, item15.PrdName ?? "", item15.PrdCode ?? "")) + "<br>";
											}
										}
										if (num3.GetValueOrDefault() == 0)
										{
											num++;
											text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspSetm) + "<br>";
										}
										break;
									case 3:
										if (string.IsNullOrWhiteSpace(cmpNationalCode))
										{
											num++;
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspPid);
										}
										if (list3 == null || !Enumerable.Any<TSPspSelectOrderPayments_Result>((IEnumerable<TSPspSelectOrderPayments_Result>)list3))
										{
											num++;
											text = text + string.Format(Messages.msgErrorItemNotDefinedPay, text4) + "<br>";
											break;
										}
										foreach (TSPspSelectOrderPayments_Result item16 in list3)
										{
											string arg = item16.OrdpayType + " - " + (item16.ImportDateTime.HasValue ? item16.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
											int result20 = 0;
											int.TryParse(item16.TspOrdPayPmt.ToString(), out result20);
											if (result20 == 0)
											{
												int.TryParse(item16.TspOrdpayTypePmt.ToString(), out result20);
											}
											string value = item16.TspOrdPayIinn ?? "";
											if (string.IsNullOrWhiteSpace(value))
											{
												value = item16.TspOrdpayTypeIinn ?? "";
											}
											string value2 = item16.TspOrdPayAcn ?? "";
											if (string.IsNullOrWhiteSpace(value2))
											{
												value2 = item16.TspOrdpayTypeAcn ?? "";
											}
											string value3 = item16.TspOrdPayTrmn ?? "";
											if (string.IsNullOrWhiteSpace(value3))
											{
												value3 = item16.TspOrdpayTypeTrmn ?? "";
											}
											if (result20 == 0)
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspPmt, arg)) + "<br>";
											}
											if (item16.ordpayAmount == 0m)
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspPayAmount, arg)) + "<br>";
											}
											if (string.IsNullOrWhiteSpace(value))
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspIinn, arg)) + "<br>";
											}
											if (string.IsNullOrWhiteSpace(value2))
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspAcn, arg)) + "<br>";
											}
											if (string.IsNullOrWhiteSpace(value3))
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspTrmn, arg)) + "<br>";
											}
											item16.ordpayBankDocNumber = item16.ordpayBankDocNumber ?? item16.ordpayDocNumber;
											if (!string.IsNullOrWhiteSpace(item16.ordpayBankDocNumber))
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspTrn, arg)) + "<br>";
											}
											if (!string.IsNullOrWhiteSpace(item16.ordpayCardNumber))
											{
												num++;
												text = text + string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspPcn, arg)) + "<br>";
											}
										}
										break;
									}
									InvoiceHeaderDto invoiceHeaderDto = new InvoiceHeaderDto();
									List<InvoiceBodyDto> list4 = new List<InvoiceBodyDto>();
									List<PaymentDto> list5 = new List<PaymentDto>();
									if (num == 0)
									{
										decimal num6 = default(decimal);
										decimal num7 = default(decimal);
										decimal num8 = default(decimal);
										decimal num9 = default(decimal);
										decimal num10 = default(decimal);
										decimal num11 = default(decimal);
										decimal num12 = default(decimal);
										decimal num13 = default(decimal);
										decimal num14 = default(decimal);
										decimal num15 = default(decimal);
										num4 = default(decimal);
										num5 = default(decimal);
										foreach (TSPspSelectOrderItems_Result item17 in list)
										{
											string tspPrdIndentify = item17.TspPrdIndentify;
											string tspPrdName = item17.TspPrdName;
											string tspUnitCode = item17.TspUnitCode;
											decimal num16 = default(decimal);
											decimal num17 = default(decimal);
											decimal num18 = default(decimal);
											string text18 = null;
											decimal num19 = default(decimal);
											decimal num20 = default(decimal);
											decimal num21 = default(decimal);
											decimal num22 = default(decimal);
											decimal num23 = default(decimal);
											decimal num24 = default(decimal);
											string text19 = null;
											decimal num25 = default(decimal);
											decimal num26 = default(decimal);
											string text20 = null;
											decimal num27 = default(decimal);
											decimal num28 = default(decimal);
											decimal num29 = default(decimal);
											decimal num30 = default(decimal);
											decimal num31 = default(decimal);
											decimal num32 = default(decimal);
											decimal num33 = default(decimal);
											decimal num34 = default(decimal);
											decimal num35 = default(decimal);
											decimal num36 = default(decimal);
											decimal num37 = default(decimal);
											decimal num38 = default(decimal);
											decimal num39 = default(decimal);
											decimal num40 = default(decimal);
											if (item17.ordIFCRI == 0.0)
											{
												item17.ordIFCRI = 1.0;
											}
											if (item17.ordIFCR == 0.0)
											{
												item17.ordIFCR = 1.0;
											}
											num40 = ((!item17.ordIQuantityTotal.HasValue) ? ((decimal)(item17.ordIQuantity.GetValueOrDefault(1.0) * item17.ordIFCR.GetValueOrDefault(1.0) * item17.ordIFCRI.GetValueOrDefault(1.0))) : ((decimal)item17.ordIQuantityTotal.GetValueOrDefault()));
											num16 = num40;
											num17 = item17.ordIPrice.GetValueOrDefault() + item17.ordIRoundPlus.GetValueOrDefault() - item17.ordIRound.GetValueOrDefault();
											switch (result7)
											{
											case 1:
												num16 = 1m;
												num17 = item17.ordIPriceSum.GetValueOrDefault() + item17.ordIDiscountSum.GetValueOrDefault();
												break;
											case 3:
												num16 = 1m;
												num17 = item17.ordIPriceSum.GetValueOrDefault() + item17.ordIDiscountSum.GetValueOrDefault();
												break;
											}
											num18 = item17.TspOrdICfee.GetValueOrDefault();
											text18 = item17.TspOrdICut;
											num19 = item17.TspOrdIExr.GetValueOrDefault();
											num20 = item17.ordIPriceSum.GetValueOrDefault() + item17.ordIDiscountSum.GetValueOrDefault();
											num6 += num20;
											num21 = item17.ordIDiscountSum.GetValueOrDefault();
											num7 += num21;
											num22 = num20 - num21;
											if (result16 == 3)
											{
												num22 = num20 + (item17.TspOrdIConsfee.GetValueOrDefault() + item17.TspOrdISpro.GetValueOrDefault() + item17.TspOrdIBros.GetValueOrDefault()) - num21;
											}
											num8 += num22;
											num23 = item17.ordITaxIndex.GetValueOrDefault();
											num24 = item17.ordITaxSum.GetValueOrDefault();
											num9 += num24;
											text19 = item17.TspOrdIOdt;
											num25 = item17.TspOrdIOdr.GetValueOrDefault();
											num26 = item17.TspOrdIOdam.GetValueOrDefault();
											num10 += num26;
											text20 = item17.TspOrdIOlt;
											num27 = item17.TspOrdIOlr.GetValueOrDefault();
											num28 = item17.TspOrdIOlam.GetValueOrDefault();
											num10 += num28;
											num29 = item17.TspOrdIConsfee.GetValueOrDefault();
											num30 = item17.TspOrdISpro.GetValueOrDefault();
											num31 = item17.TspOrdIBros.GetValueOrDefault();
											num32 = num29 + num30 + num31;
											num33 = item17.TspOrdICop.GetValueOrDefault();
											num34 = item17.TspOrdIVop.GetValueOrDefault();
											num12 += num34;
											num36 = (decimal)item17.TspOrdINw.GetValueOrDefault();
											num13 += num36;
											num37 = item17.TspOrdISsrv.GetValueOrDefault();
											num14 += num37;
											num38 = item17.TspOrdISscv.GetValueOrDefault();
											num15 += num38;
											item17.TspOrdIPspd.GetValueOrDefault();
											num39 = item17.TspOrdICui.GetValueOrDefault();
											num35 = num24 + num22 + num26 + num28;
											num11 += num35;
											string tspOrdIBsrn = item17.TspOrdIBsrn;
											InvoiceBodyDto item = new InvoiceBodyDto
											{
												Sstid = ((!string.IsNullOrWhiteSpace(tspPrdIndentify)) ? tspPrdIndentify : null),
												Sstt = ((!string.IsNullOrWhiteSpace(tspPrdName)) ? tspPrdName : null),
												Mu = ((!string.IsNullOrWhiteSpace(tspUnitCode)) ? tspUnitCode : null),
												Am = ((num16 != 0m) ? new decimal?(num16) : null),
												Fee = ((num17 != 0m) ? new decimal?(num17) : null),
												Cfee = ((num18 != 0m) ? new decimal?(num18) : null),
												Cut = ((!string.IsNullOrWhiteSpace(text18)) ? text18 : null),
												Exr = ((num19 != 0m) ? new decimal?(num19) : null),
												Prdis = ((num20 != 0m) ? new decimal?(num20) : null),
												Dis = num21,
												Adis = ((num22 != 0m) ? new decimal?(num22) : null),
												Vra = ((num23 != 0m || result16 == 7) ? num23 : 0m),
												Vam = ((num24 != 0m || result16 == 7) ? num24 : 0m),
												Odt = ((!string.IsNullOrWhiteSpace(text19)) ? text19 : null),
												Odr = ((num25 != 0m) ? new decimal?(num25) : null),
												Odam = ((num26 != 0m) ? new decimal?(num26) : null),
												Olt = ((!string.IsNullOrWhiteSpace(text20)) ? text20 : null),
												Olr = ((num27 != 0m) ? new decimal?(num27) : null),
												Olam = ((num28 != 0m) ? new decimal?(num28) : null),
												Consfee = ((num29 != 0m) ? new decimal?(num29) : null),
												Spro = ((num30 != 0m) ? new decimal?(num30) : null),
												Bros = ((num31 != 0m) ? new decimal?(num31) : null),
												Tcpbs = ((num32 != 0m) ? new decimal?(num32) : null),
												Cop = ((num33 != 0m) ? new decimal?(num33) : null),
												Vop = ((num34 != 0m) ? new decimal?(num34) : null),
												Bsrn = ((!string.IsNullOrWhiteSpace(tspOrdIBsrn)) ? tspOrdIBsrn : null),
												Tsstam = ((num35 != 0m) ? new decimal?(num35) : null),
												Nw = ((num36 != 0m) ? new decimal?(num36) : null),
												Ssrv = ((num37 != 0m) ? new decimal?(num37) : null),
												Sscv = ((num38 != 0m) ? new decimal?(num38) : null),
												Cui = ((num39 != 0m) ? new decimal?(num39) : null)
											};
											list4.Add(item);
										}
										long num41 = new DateTimeOffset(tSPspSelectOrderById_Result.ordDateTime.GetValueOrDefault(now)).ToUnixTimeMilliseconds();
										long num42 = new DateTimeOffset(tSPspSelectOrderById_Result.FirstRegisterDate.GetValueOrDefault(now)).ToUnixTimeMilliseconds();
										string text21 = "";
										DateTime valueOrDefault = tSPspSelectOrderById_Result.TspOrdCdcd.GetValueOrDefault(now);
										DateTime value4 = new DateTime(1970, 1, 1);
										DateTime dateTime = valueOrDefault;
										int value5 = (int)dateTime.Subtract(value4).TotalDays;
										if (result16 == 7)
										{
											num11 = num14 + num9 + num10;
										}
										num5 = tSPspSelectOrderById_Result.TspOrdInsp.GetValueOrDefault();
										if (num4 == 0m && num5 == 0m && num3 == 0)
										{
											num4 = num11 - num10 - num9 - num5;
											if (num3 == 0)
											{
												num3 = 1;
											}
										}
										if (num4 == 0m && num3.GetValueOrDefault() == 1)
										{
											num4 = num11 - num10 - num9 - num5;
										}
										if (num3.GetValueOrDefault() == 2)
										{
											num5 = num11 - num10 - num9 - num4;
										}
										else if (num3.GetValueOrDefault() == 3 && num4 == 0m)
										{
											num4 = num11 - num10 - num9 - num5;
										}
										InvoiceHeaderDto obj = new InvoiceHeaderDto
										{
											Taxid = ((!string.IsNullOrWhiteSpace(text13)) ? text13 : null),
											Indatim = ((num41 != 0L) ? new long?(num41) : null),
											Indati2m = ((num42 != 0L) ? new long?(num42) : null),
											Inty = ((result15 != 0) ? new int?(result15) : null),
											Inno = ((!string.IsNullOrWhiteSpace(text14)) ? text14 : null),
											Irtaxid = ((!string.IsNullOrWhiteSpace(text16)) ? text16 : null),
											Inp = ((result16 != 0) ? new int?(result16) : null),
											Ins = ((result18 != 0) ? new int?(result18) : null),
											Tins = (text17 ?? ""),
											Tob = ((result19 != 0) ? new int?(result19) : null),
											Bid = ((!string.IsNullOrWhiteSpace(text15)) ? text15 : null),
											Tinb = ((!string.IsNullOrWhiteSpace(cmpEconomicCode)) ? cmpEconomicCode : null),
											Sbc = ((!string.IsNullOrWhiteSpace(tspOrdSbc)) ? tspOrdSbc : null),
											Bpc = ((!string.IsNullOrWhiteSpace(cmpOfficialZipCode)) ? cmpOfficialZipCode : null),
											Bbc = ((!string.IsNullOrWhiteSpace(tspCmpBbc)) ? tspCmpBbc : null),
											Ft = ((tspOrdFt != 0) ? tspOrdFt : null),
											Bpn = ((!string.IsNullOrWhiteSpace(tspCmpBpn)) ? tspCmpBpn : null),
											Scln = ((!string.IsNullOrWhiteSpace(tspOrdScln)) ? tspOrdScln : null),
											Scc = ((!string.IsNullOrWhiteSpace(tspOrdScc)) ? tspOrdScc : null),
											Crn = ((!string.IsNullOrWhiteSpace(tspOrdCrn)) ? tspOrdCrn : null),
											Billid = ((!string.IsNullOrWhiteSpace(tspOrdBillid)) ? tspOrdBillid : null),
											Tprdis = ((num6 != 0m) ? new decimal?(num6) : null),
											Tdis = ((num7 != 0m) ? new decimal?(num7) : null),
											Tadis = ((num8 != 0m) ? new decimal?(num8) : null),
											Tvam = ((num9 != 0m || result16 == 7) ? num9 : 0m),
											Todam = num10,
											Tbill = ((num11 != 0m) ? new decimal?(num11) : null),
											Setm = ((num3 != 0) ? num3 : null),
											Cap = ((num4 != 0m) ? new decimal?(num4) : null),
											Insp = ((num5 != 0m) ? new decimal?(num5) : null),
											Tvop = ((num12 != 0m) ? new decimal?(num12) : null)
										};
										decimal? num43 = tspOrdTax;
										obj.Tax17 = ((!((num43.GetValueOrDefault() == default(decimal)) & num43.HasValue)) ? tspOrdTax : null);
										obj.Cdcn = ((!string.IsNullOrWhiteSpace(text21)) ? text21 : null);
										obj.Cdcd = (tSPspSelectOrderById_Result.TspOrdCdcd.HasValue ? new int?(value5) : null);
										obj.Tonw = ((num13 != 0m) ? new decimal?(num13) : null);
										obj.Torv = ((num14 != 0m) ? new decimal?(num14) : null);
										obj.Tocv = ((num15 != 0m) ? new decimal?(num15) : null);
										obj.Insr = ((num2 != 0) ? new int?(num2) : null);
										invoiceHeaderDto = obj;
										if (result6)
										{
											foreach (TSPspSelectOrderPayments_Result item18 in list3)
											{
												int result21 = 0;
												int.TryParse(item18.TspOrdPayPmt.ToString(), out result21);
												if (result21 == 0)
												{
													int.TryParse(item18.TspOrdpayTypePmt.ToString(), out result21);
												}
												string text22 = item18.TspOrdPayIinn ?? "";
												if (string.IsNullOrWhiteSpace(text22))
												{
													text22 = item18.TspOrdpayTypeIinn ?? "";
												}
												string text23 = item18.TspOrdPayAcn ?? "";
												if (string.IsNullOrWhiteSpace(text23))
												{
													text23 = item18.TspOrdpayTypeAcn ?? "";
												}
												string text24 = item18.TspOrdPayTrmn ?? "";
												if (string.IsNullOrWhiteSpace(text24))
												{
													text24 = item18.TspOrdpayTypeTrmn ?? "";
												}
												string text25 = text22 ?? "";
												string text26 = text23 ?? "";
												string text27 = text24 ?? "";
												int num44 = ((result21 == 0) ? 3 : result21);
												string text28 = "";
												long num45 = long.Parse($"{item18.ordpayAmount:N0}".Replace(",", ""));
												item18.ordpayBankDocNumber = item18.ordpayBankDocNumber ?? item18.ordpayDocNumber;
												if (!string.IsNullOrWhiteSpace(item18.ordpayBankDocNumber))
												{
													text28 = item18.ordpayBankDocNumber;
												}
												string text29 = item18.ordpayCardNumber ?? "";
												string text30 = cmpNationalCode;
												long num46 = 0L;
												value4 = new DateTime(1970, 1, 1);
												dateTime = item18.ImportDateTime.GetValueOrDefault(now);
												num46 = (long)dateTime.Subtract(value4).TotalDays;
												value4 = new DateTime(1278, 11, 1);
												num46 = (long)DateTime.Parse(dateTime.ToString("yyyy/MM/dd hh:mm:ss", new PersianCulture())).Subtract(value4).TotalDays;
												PaymentDto item2 = new PaymentDto
												{
													Iinn = ((!string.IsNullOrWhiteSpace(text25)) ? text25 : null),
													Acn = ((!string.IsNullOrWhiteSpace(text26)) ? text26 : null),
													Trmn = ((!string.IsNullOrWhiteSpace(text27)) ? text27 : null),
													Trn = ((!string.IsNullOrWhiteSpace(text28)) ? text28 : null),
													Pcn = ((!string.IsNullOrWhiteSpace(text29)) ? text29 : null),
													Pid = ((!string.IsNullOrWhiteSpace(text30)) ? text30 : null),
													Pdt = ((num46 != 0L) ? new long?(num46) : null),
													Pmt = ((num44 != 0) ? new int?(num44) : null),
													Pv = ((num45 != 0L) ? new long?(num45) : null)
												};
												list5.Add(item2);
											}
										}
										InvoiceDto item3 = new InvoiceDto
										{
											Header = invoiceHeaderDto,
											Body = list4,
											Payments = list5
										};
										List<InvoiceDto> invoices = new List<InvoiceDto> { item3 };
										HttpResponse<AsyncResponseModel> httpResponse = TaxApiService.Instance.TaxApis.SendInvoices(invoices, null);
										string tspOrdMessage = "";
										string text31 = "";
										string text32 = "";
										string text33 = "";
										if (httpResponse.Status == 200)
										{
											if (httpResponse.Body != null)
											{
												AsyncResponseModel body = httpResponse.Body;
												PacketResponse packetResponse = (((object)body != null) ? Enumerable.FirstOrDefault<PacketResponse>((IEnumerable<PacketResponse>)body.Result) : null);
												string tspOrdUID = packetResponse.Uid ?? "";
												string text34 = packetResponse.ReferenceNumber ?? "";
												text31 = packetResponse.ErrorCode ?? "";
												text32 = packetResponse.ErrorDetail ?? "";
												text33 = "";
												if (!string.IsNullOrWhiteSpace(text31) && !string.IsNullOrWhiteSpace(text32))
												{
													tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, text31, text32, isError: true);
													text33 = "Error";
												}
												else if (!string.IsNullOrWhiteSpace(text34))
												{
													tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, "", Messages.msgOperationCompleted, isError: false);
													text33 = "PENDING";
												}
												switch (tspSendType)
												{
												case 3:
												{
													string errorDetail2 = string.Format(Messages.msgTspOrdCancellation, "TspOrdIdentify".OrderLabels() + "=  (" + text5 + ") ", "TspOrdInno".OrderLabels() + "=  (" + text6 + ") ", "TspOrdUID".OrderLabels() + "=  (" + text7 + ") ", "TspOrdReferenceNumber".OrderLabels() + "=  (" + text8 + ") ");
													tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, "", errorDetail2, isError: false);
													UpdateOrder(tSPspSelectOrderById_Result.OrderID, text5, text6, result18, now, text2, now, text2, text7, text8, text33, tspOrdMessage, text5, tspOrdSendTypeId);
													InsertOrder(tSPspSelectOrderById_Result.OrderID, -10, text13, text14, result18, now, text2, now, text2, tspOrdUID, text34, text33, tspOrdMessage);
													tSPspSelectOrderById_Result.TspOrdMessage = tspOrdMessage;
													break;
												}
												case 4:
												{
													string errorDetail = string.Format(Messages.msgTspOrdEdited, "TspOrdIdentify".OrderLabels() + "=  (" + text9 + ") ", "TspOrdInno".OrderLabels() + "=  (" + text10 + ") ", "TspOrdUID".OrderLabels() + "=  (" + text11 + ") ", "TspOrdReferenceNumber".OrderLabels() + "=  (" + text12 + ") ");
													tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, "", errorDetail, isError: false);
													UpdateOrder(tSPspSelectOrderById_Result.OrderID, text9, text10, result18, now, text2, now, text2, text7, text12, text33, tspOrdMessage, text9, tspOrdSendTypeId);
													InsertOrder(tSPspSelectOrderById_Result.OrderID, -20, text13, text14, result18, now, text2, now, text2, tspOrdUID, text34, text33, tspOrdMessage);
													tSPspSelectOrderById_Result.TspOrdMessage = tspOrdMessage;
													break;
												}
												default:
													UpdateOrder(tSPspSelectOrderById_Result.OrderID, text13, text14, result18, now, text2, now, text2, tspOrdUID, text34, text33, tspOrdMessage, null, tspOrdSendTypeId);
													break;
												}
												TaxApiService.Instance.TaxApis.GetFiscalInformation(text3);
												List<string> list6 = new List<string>();
												list6.Add(packetResponse.ReferenceNumber);
												List<InquiryResultModel> list7 = TaxApiService.Instance.TaxApis.InquiryByReferenceId(list6);
												if (list7 != null)
												{
													if (Enumerable.FirstOrDefault<InquiryResultModel>((IEnumerable<InquiryResultModel>)list7).Data != null)
													{
														string? value6 = Enumerable.FirstOrDefault<InquiryResultModel>((IEnumerable<InquiryResultModel>)list7).Data.ToString();
														CreateInvoiceResponse createInvoiceResponse = JsonConvert.DeserializeObject<CreateInvoiceResponse>(value6);
														bool flag = false;
														TspCreateInvoiceResponse_I tspCreateInvoiceResponse_I = JsonConvert.DeserializeObject<TspCreateInvoiceResponse_I>(value6);
														if (tspCreateInvoiceResponse_I != null && tspCreateInvoiceResponse_I.Error != null && Enumerable.Any<TspInvoiceErrorModel_I>((IEnumerable<TspInvoiceErrorModel_I>)tspCreateInvoiceResponse_I.Error))
														{
															foreach (TspInvoiceErrorModel_I item19 in tspCreateInvoiceResponse_I.Error)
															{
																text31 = item19.Code ?? "";
																text32 = item19.Msg ?? item19.Message ?? "";
																if (string.IsNullOrWhiteSpace(text32) && !string.IsNullOrWhiteSpace(text31))
																{
																	text32 = "Error code=" + text31;
																}
																if (!string.IsNullOrWhiteSpace(text31) && !string.IsNullOrWhiteSpace(text32))
																{
																	tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, text31, text32, isError: true);
																	text33 = "Error";
																	text = text + " <br>" + text32;
																	flag = true;
																}
															}
															UpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, now, text2, null, null, null, tspOrdMessage, null, tspOrdSendTypeId);
														}
														text33 = Enumerable.FirstOrDefault<InquiryResultModel>((IEnumerable<InquiryResultModel>)list7).Status;
														if (!string.IsNullOrWhiteSpace(text33))
														{
															UpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, now, text2, null, null, text33, null, null, tspOrdSendTypeId);
														}
														if (createInvoiceResponse != null && !flag && createInvoiceResponse.Error != null && Enumerable.Any<InvoiceErrorModel>((IEnumerable<InvoiceErrorModel>)createInvoiceResponse.Error))
														{
															foreach (InvoiceErrorModel item20 in createInvoiceResponse.Error)
															{
																text31 = item20.Code ?? "";
																text32 = item20.Msg ?? "";
																if (string.IsNullOrWhiteSpace(text32) && !string.IsNullOrWhiteSpace(text31))
																{
																	text32 = "Error code=" + text31;
																}
																if (!string.IsNullOrWhiteSpace(text31) || !string.IsNullOrWhiteSpace(text32))
																{
																	tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, text31, text32, isError: true);
																	text33 = "Error";
																	text = text + " <br>" + text32;
																}
																else
																{
																	text32 = Messages.msgErrorSendInfo;
																	tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, text31, text32, isError: true);
																	text33 = "Error";
																	text = text + " <br>" + text32;
																}
															}
															switch (tspSendType)
															{
															case 3:
																UpdateOrder(tSPspSelectOrderById_Result.OrderID, text5, text6, result18, now, text2, now, text2, text7, text8, text33, tspOrdMessage, null, tspOrdSendTypeId);
																break;
															case 4:
																UpdateOrder(tSPspSelectOrderById_Result.OrderID, text9, text10, result18, now, text2, now, text2, text11, text12, text33, tspOrdMessage, null, tspOrdSendTypeId);
																break;
															default:
																UpdateOrder(tSPspSelectOrderById_Result.OrderID, text13, text14, result18, now, text2, now, text2, tspOrdUID, text34, text33, tspOrdMessage, null, tspOrdSendTypeId);
																break;
															}
														}
													}
													else
													{
														text33 = Enumerable.FirstOrDefault<InquiryResultModel>((IEnumerable<InquiryResultModel>)list7).Status;
														if (!string.IsNullOrWhiteSpace(text33))
														{
															UpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, now, text2, null, null, text33, null, null, tspOrdSendTypeId);
														}
													}
												}
											}
											else
											{
												tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, "-1", Messages.msgErrorSendInfo, isError: true);
												text = text + " <br>" + Messages.msgErrorSendInfo;
												cRMSpIEntities.TSPspUpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage, appType, null, null);
											}
										}
										else if (httpResponse.Body != null && httpResponse.Body.Errors != null && Enumerable.Any<ErrorModel>((IEnumerable<ErrorModel>)httpResponse.Body.Errors))
										{
											text31 = httpResponse.Body.Errors[0].ErrorCode;
											text32 = httpResponse.Body.Errors[0].Detail;
											if (!string.IsNullOrWhiteSpace(text31) && !string.IsNullOrWhiteSpace(text32))
											{
												tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, text31, text32, isError: true);
												text33 = "Error";
											}
											text = text + " <br>" + text32;
											cRMSpIEntities.TSPspUpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage, appType, null, null);
										}
										else if (httpResponse.Body != null)
										{
											text32 = JsonConvert.SerializeObject(httpResponse.Body);
											tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, "-1", text32, isError: true);
											text = text + " <br>" + Messages.msgErrorSendInfo;
											cRMSpIEntities.TSPspUpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage, appType, null, null);
										}
									}
								}
								else
								{
									text = Messages.ErrorNotFound;
									string tspOrdMessage2 = CreateTspOrdMessage("", "-1", text, isError: true);
									cRMSpIEntities.TSPspUpdateOrder(ordId, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage2, appType, null, null);
								}
							}
							else
							{
								text = Messages.msgErrorReceivingToken;
								num++;
								string tspOrdMessage3 = CreateTspOrdMessage("", "-1", text, isError: true);
								cRMSpIEntities.TSPspUpdateOrder(ordId, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage3, appType, null, null);
							}
						}
						else
						{
							text = Messages.errorInReadingSetting;
							string tspOrdMessage4 = CreateTspOrdMessage("", "-1", text, isError: true);
							cRMSpIEntities.TSPspUpdateOrder(ordId, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage4, appType, null, null);
						}
					}
					else
					{
						text = Messages.errorInReadingSetting;
						string tspOrdMessage5 = CreateTspOrdMessage("", "-1", text, isError: true);
						cRMSpIEntities.TSPspUpdateOrder(ordId, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage5, appType, null, null);
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
					string tspOrdMessage6 = CreateTspOrdMessage("", "-1", text, isError: true);
					cRMSpIEntities.TSPspUpdateOrder(ordId, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage6, appType, null, null);
				}
			}
			else
			{
				text = Messages.ErrorNotFound;
				string tspOrdMessage7 = CreateTspOrdMessage("", "-1", text, isError: true);
				cRMSpIEntities.TSPspUpdateOrder(ordId, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage7, appType, null, null);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				data = 0;
				string tspOrdMessage8 = CreateTspOrdMessage("", "-1", text, isError: true);
				cRMSpIEntities.TSPspUpdateOrder(ordId, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage8, appType, null, null);
				return new CommonResultViewModel<int>
				{
					Data = data,
					Message = "",
					Status = CommonResultStatusViewModel.Success
				};
			}
			data = 1;
			text = "";
			status = CommonResultStatusViewModel.Success;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			data = 0;
			text = Messages.msgErrorRunFunction + " (" + ex.Message + ")";
			string appType2 = Configuration.AppType;
			string tspOrdMessage9 = CreateTspOrdMessage("", "-1", text, isError: true);
			cRMSpIEntities.TSPspUpdateOrder(ordId, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage9, appType2, null, null);
			return new CommonResultViewModel<int>
			{
				Data = data,
				Message = "",
				Status = CommonResultStatusViewModel.Success
			};
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMSpIEntities.Dispose();
		}
		return new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = status
		};
	}

	public static CommonResultViewModel<int> InquiryOrder(int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			DateTime now = DateTime.Now;
			string tspOrdLastEditDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			_ = now.Ticks;
			if (ordId != 0)
			{
				int num = 0;
				TSPspSelectOrderById_Result tSPspSelectOrderById_Result = Enumerable.FirstOrDefault<TSPspSelectOrderById_Result>((IEnumerable<TSPspSelectOrderById_Result>)cRMSpIEntities.TSPspSelectOrderById(ordId, lCID, result));
				if (tSPspSelectOrderById_Result != null)
				{
					int result2 = 0;
					int.TryParse(tSPspSelectOrderById_Result.ordTspSettingId.ToString(), out result2);
					if (result2 != 0)
					{
						TSPspSelectSettingById_Result tSPspSelectSettingById_Result = Enumerable.FirstOrDefault<TSPspSelectSettingById_Result>((IEnumerable<TSPspSelectSettingById_Result>)cRMSpIEntities.TSPspSelectSettingById(result2, lCID, result));
						if (tSPspSelectSettingById_Result != null)
						{
							string text2 = CleanPrivateKey(tSPspSelectSettingById_Result.TspPrivateKey);
							TaxApiService.Instance.Init(tSPspSelectSettingById_Result.TspIdentify, new SignatoryConfig(text2, null), new NormalProperties(ClientType.SELF_TSP), UrlTsp);
							TaxApiService.Instance.TaxApis.GetServerInformation();
							if (TaxApiService.Instance.TaxApis.RequestToken() != null)
							{
								if (tSPspSelectOrderById_Result != null)
								{
									string.Format(Labels.lbItemByNumber, tSPspSelectOrderById_Result.OrderOpr ?? Labels.lblOrd, tSPspSelectOrderById_Result.ordNumber.ToString());
									string tspOrdReferenceNumber = tSPspSelectOrderById_Result.TspOrdReferenceNumber;
									if (string.IsNullOrWhiteSpace(tspOrdReferenceNumber))
									{
										num++;
										text = text + string.Format(Messages.msgErrorItemNoValue, Labels.TspTransferListOrdReferenceNumber) + "<br>";
									}
									if (num == 0)
									{
										string tspOrdMessage = "";
										string text3 = "";
										string text4 = "";
										string text5 = "";
										TaxApiService.Instance.TaxApis.GetFiscalInformation(text2);
										List<string> list = new List<string>();
										list.Add(tspOrdReferenceNumber);
										List<InquiryResultModel> list2 = TaxApiService.Instance.TaxApis.InquiryByReferenceId(list);
										if (list2 != null)
										{
											if (Enumerable.FirstOrDefault<InquiryResultModel>((IEnumerable<InquiryResultModel>)list2).Data != null)
											{
												string? value = Enumerable.FirstOrDefault<InquiryResultModel>((IEnumerable<InquiryResultModel>)list2).Data.ToString();
												CreateInvoiceResponse createInvoiceResponse = JsonConvert.DeserializeObject<CreateInvoiceResponse>(value);
												bool flag = false;
												TspCreateInvoiceResponse_I tspCreateInvoiceResponse_I = JsonConvert.DeserializeObject<TspCreateInvoiceResponse_I>(value);
												if (tspCreateInvoiceResponse_I != null && tspCreateInvoiceResponse_I.Error != null && Enumerable.Any<TspInvoiceErrorModel_I>((IEnumerable<TspInvoiceErrorModel_I>)tspCreateInvoiceResponse_I.Error))
												{
													foreach (TspInvoiceErrorModel_I item in tspCreateInvoiceResponse_I.Error)
													{
														text3 = item.Code ?? "";
														text4 = item.Msg ?? item.Message ?? "";
														if (string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text3))
														{
															text4 = "Error code=" + text3;
														}
														if (!string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
														{
															tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, text3, text4, isError: true);
															text5 = "Error";
															text = text + " <br>" + text4;
															flag = true;
														}
													}
													UpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, now, tspOrdLastEditDatePersian, null, null, null, tspOrdMessage, null);
												}
												text5 = Enumerable.FirstOrDefault<InquiryResultModel>((IEnumerable<InquiryResultModel>)list2).Status;
												if (!string.IsNullOrWhiteSpace(text5))
												{
													UpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, now, tspOrdLastEditDatePersian, null, null, text5, null, null);
												}
												if (createInvoiceResponse != null && !flag && createInvoiceResponse.Error != null && Enumerable.Any<InvoiceErrorModel>((IEnumerable<InvoiceErrorModel>)createInvoiceResponse.Error))
												{
													foreach (InvoiceErrorModel item2 in createInvoiceResponse.Error)
													{
														text3 = item2.Code ?? "";
														text4 = item2.Msg ?? "";
														if (string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text3))
														{
															text4 = "Error code=" + text3;
														}
														if (!string.IsNullOrWhiteSpace(text3) || !string.IsNullOrWhiteSpace(text4))
														{
															tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, text3, text4, isError: true);
															text5 = "Error";
															text = text + " <br>" + text4;
														}
														else
														{
															text4 = Messages.msgErrorSendInfo;
															tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, text3, text4, isError: true);
															text5 = "Error";
															text = text + " <br>" + text4;
														}
													}
													UpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, now, tspOrdLastEditDatePersian, null, null, text5, tspOrdMessage, null);
												}
											}
											else
											{
												text5 = Enumerable.FirstOrDefault<InquiryResultModel>((IEnumerable<InquiryResultModel>)list2).Status;
												if (!string.IsNullOrWhiteSpace(text5))
												{
													UpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, now, tspOrdLastEditDatePersian, null, null, text5, null, null);
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
									text = Messages.ErrorNotFound;
								}
							}
							else
							{
								text = Messages.msgErrorReceivingToken;
								num++;
							}
						}
						else
						{
							text = Messages.errorInReadingSetting;
						}
					}
					else
					{
						text = Messages.errorInReadingSetting;
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
				}
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				data = 0;
				string tspOrdMessage2 = CreateTspOrdMessage("", "-1", text, isError: true);
				cRMSpIEntities.TSPspUpdateOrder(ordId, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage2, appType, null, null);
				return new CommonResultViewModel<int>
				{
					Data = data,
					Message = "",
					Status = CommonResultStatusViewModel.Success
				};
			}
			data = 1;
			text = "";
			status = CommonResultStatusViewModel.Success;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			data = 0;
			text = Messages.msgErrorRunFunction + " (" + ex.Message + ")";
			string appType2 = Configuration.AppType;
			string tspOrdMessage3 = CreateTspOrdMessage("", "-1", text, isError: true);
			cRMSpIEntities.TSPspUpdateOrder(ordId, null, null, null, null, null, null, null, null, null, "Error", tspOrdMessage3, appType2, null, null);
			return new CommonResultViewModel<int>
			{
				Data = data,
				Message = "",
				Status = CommonResultStatusViewModel.Success
			};
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMSpIEntities.Dispose();
		}
		return new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = status
		};
	}

	public static List<TSPRowErrorViewModel> CheckOrderBeforeSendTsp(int ordId, DateTime sendDateTime, int tspSendType = 1)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<TSPRowErrorViewModel> list = new List<TSPRowErrorViewModel>();
		TSPRowErrorViewModel tSPRowErrorViewModel = new TSPRowErrorViewModel();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		int value = 0;
		long value2 = 0L;
		string ordDate = "";
		DateTime value3 = default(DateTime);
		string orderOpr = "";
		string companyName = "";
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			if (ordId != 0)
			{
				TSPspSelectOrderById_Result tSPspSelectOrderById_Result = Enumerable.FirstOrDefault<TSPspSelectOrderById_Result>((IEnumerable<TSPspSelectOrderById_Result>)cRMSpIEntities.TSPspSelectOrderById(ordId, lCID, result));
				if (tSPspSelectOrderById_Result != null)
				{
					int result2 = 0;
					int.TryParse(tSPspSelectOrderById_Result.ordTspSettingId.ToString(), out result2);
					value = tSPspSelectOrderById_Result.OrderID;
					value2 = tSPspSelectOrderById_Result.ordNumber;
					ordDate = tSPspSelectOrderById_Result.ordDate;
					value3 = tSPspSelectOrderById_Result.ordDateTime ?? DateTime.Now;
					orderOpr = tSPspSelectOrderById_Result.OrderOpr;
					companyName = tSPspSelectOrderById_Result.CompanyName;
					text = "";
					int result3 = 0;
					int.TryParse(tSPspSelectOrderById_Result.TspOrdStatusResultNum.ToString(), out result3);
					if ((tSPspSelectOrderById_Result.TspOrdStatusResult ?? "") == "رد شده" && tspSendType == 3)
					{
						result3 = 0;
					}
					else if (result3 == 1 && tspSendType == 3)
					{
						return list;
					}
					if (result2 != 0)
					{
						TSPspSelectSettingById_Result tSPspSelectSettingById_Result = Enumerable.FirstOrDefault<TSPspSelectSettingById_Result>((IEnumerable<TSPspSelectSettingById_Result>)cRMSpIEntities.TSPspSelectSettingById(result2, lCID, result));
						if (tSPspSelectSettingById_Result != null)
						{
							if (tSPspSelectOrderById_Result != null)
							{
								string text2 = string.Format(Labels.lbItemByNumber, tSPspSelectOrderById_Result.OrderOpr ?? Labels.lblOrd, tSPspSelectOrderById_Result.ordNumber.ToString());
								bool result4 = false;
								bool.TryParse(tSPspSelectOrderById_Result.ordIsVerified.ToString(), out result4);
								if (!result4)
								{
									text = string.Format(Messages.msgErrorItemNotVerified, text2);
									tSPRowErrorViewModel = new TSPRowErrorViewModel
									{
										OrderID = value,
										ordNumber = value2,
										ordDate = ordDate,
										ordDateTime = value3,
										OrderOpr = orderOpr,
										CompanyName = companyName,
										ErrorMessage = text
									};
									list.Add(tSPRowErrorViewModel);
								}
								if (string.IsNullOrWhiteSpace(tSPspSelectSettingById_Result.TspEconomicCode))
								{
									text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspEconomic);
									tSPRowErrorViewModel = new TSPRowErrorViewModel
									{
										OrderID = value,
										ordNumber = value2,
										ordDate = ordDate,
										ordDateTime = value3,
										OrderOpr = orderOpr,
										CompanyName = companyName,
										ErrorMessage = text
									};
									list.Add(tSPRowErrorViewModel);
								}
								string text3 = "";
								if (tspSendType == 3)
								{
									text3 = tSPspSelectOrderById_Result.TspOrdIdentify ?? "";
									_ = tSPspSelectOrderById_Result.TspOrdInno;
									_ = tSPspSelectOrderById_Result.TspOrdUID;
									_ = tSPspSelectOrderById_Result.TspOrdReferenceNumber;
								}
								string text4 = "";
								if (tspSendType == 4)
								{
									text4 = tSPspSelectOrderById_Result.TspOrdIdentify ?? "";
									_ = tSPspSelectOrderById_Result.TspOrdInno;
									_ = tSPspSelectOrderById_Result.TspOrdUID;
									_ = tSPspSelectOrderById_Result.TspOrdReferenceNumber;
								}
								tSPspSelectOrderById_Result.FirstRegisterDate = tSPspSelectOrderById_Result.ordDateTime;
								int result5 = 0;
								int.TryParse(tSPspSelectSettingById_Result.TspSendDateType.ToString(), out result5);
								if (tspSendType == 11 || tspSendType == 3)
								{
									tSPspSelectOrderById_Result.ordDateTime = sendDateTime;
									tSPspSelectOrderById_Result.FirstRegisterDate = sendDateTime;
								}
								bool result6 = false;
								bool.TryParse(tSPspSelectSettingById_Result.TspSendPay.ToString(), out result6);
								int result7 = 1;
								CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
								if (cRMspSelectCrmsysSetting_Result != null)
								{
									int.TryParse(cRMspSelectCrmsysSetting_Result.TspPrdSendMethod.ToString(), out result7);
								}
								if (result7 == 0)
								{
									result7 = 1;
								}
								bool result8 = false;
								bool.TryParse(tSPspSelectOrderById_Result.TspSendOrdWithoutDisc.ToString(), out result8);
								List<TSPspSelectOrderItems_Result> list2 = new List<TSPspSelectOrderItems_Result>();
								List<TSPspSelectOrderItems_Result> list3 = Enumerable.ToList<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)cRMSpIEntities.TSPspSelectOrderItems(ordId, false, lCID, result));
								if (list3 == null || !Enumerable.Any<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list3))
								{
									text = string.Format(Messages.msgErrorItemNotDefinedPrd, text2);
									tSPRowErrorViewModel = new TSPRowErrorViewModel
									{
										OrderID = value,
										ordNumber = value2,
										ordDate = ordDate,
										ordDateTime = value3,
										OrderOpr = orderOpr,
										CompanyName = companyName,
										ErrorMessage = text
									};
									list.Add(tSPRowErrorViewModel);
								}
								else
								{
									if (result8)
									{
										foreach (TSPspSelectOrderItems_Result item in list3)
										{
											if (item.ordIPrice.GetValueOrDefault() != 0m)
											{
												item.ordIPrice = item.ordIPrice.GetValueOrDefault() - item.ordIDiscount.GetValueOrDefault();
											}
											item.ordIDiscountI = null;
											item.ordIDiscount = null;
											item.ordIDiscountPercent = null;
											item.ordIDiscountIPercent = null;
											item.ordIDiscountISum = null;
											item.ordIDiscountSum = null;
											item.ordIDiscountDesc = null;
										}
									}
									switch (result7)
									{
									case 1:
										foreach (TSPspSelectOrderItems_Result item2 in list3)
										{
											string fgIdentify = item2.TspFGIndentify;
											if (string.IsNullOrWhiteSpace(fgIdentify))
											{
												continue;
											}
											if (list2 != null && Enumerable.Any<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list2))
											{
												if (Enumerable.FirstOrDefault<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list2, (Func<TSPspSelectOrderItems_Result, bool>)((TSPspSelectOrderItems_Result m) => m.TspFGIndentify == fgIdentify)) != null)
												{
													foreach (TSPspSelectOrderItems_Result item3 in list2)
													{
														if (!string.IsNullOrWhiteSpace(item3.TspFGIndentify) && item3.TspFGIndentify == fgIdentify)
														{
															item3.ordIQuantityTotal = null;
															item3.ordIQuantity = 1.0;
															item3.ordIFCR = 1.0;
															item3.ordIFCRI = 1.0;
															item3.ordIPrice = item3.ordIPrice.GetValueOrDefault() + item2.ordIPrice.GetValueOrDefault();
															item3.ordITotalPrice = item3.ordITotalPrice.GetValueOrDefault() + item2.ordITotalPrice.GetValueOrDefault();
															item3.ordIDiscountI = item3.ordIDiscountI.GetValueOrDefault() + item2.ordIDiscountI.GetValueOrDefault();
															item3.ordIDiscount = item3.ordIDiscount.GetValueOrDefault() + item2.ordIDiscount.GetValueOrDefault();
															item3.ordITax = item3.ordITax.GetValueOrDefault() + item2.ordITax.GetValueOrDefault();
															if (item3.ordITax.GetValueOrDefault() > 0m)
															{
																item3.ordITaxIndex = item3.ordITaxIndex.GetValueOrDefault(9m);
															}
															item3.ordIRound = item3.ordIRound.GetValueOrDefault() + item2.ordIRound.GetValueOrDefault();
															item3.ordIRoundPlus = item3.ordIRoundPlus.GetValueOrDefault() + item2.ordIRoundPlus.GetValueOrDefault();
															item3.ordIPriceSum = item3.ordIPriceSum.GetValueOrDefault() + item2.ordIPriceSum.GetValueOrDefault();
															item3.ordIDiscountISum = item3.ordIDiscountISum.GetValueOrDefault() + item2.ordIDiscountISum.GetValueOrDefault();
															item3.ordIDiscountSum = item3.ordIDiscountSum.GetValueOrDefault() + item2.ordIDiscountSum.GetValueOrDefault();
															item3.ordITaxSum = item3.ordITaxSum.GetValueOrDefault() + item2.ordITaxSum.GetValueOrDefault();
															item3.TspOrdICfee = item3.TspOrdICfee.GetValueOrDefault() + item2.TspOrdICfee.GetValueOrDefault();
															item3.TspOrdIExr = item3.TspOrdIExr.GetValueOrDefault() + item2.TspOrdIExr.GetValueOrDefault();
															item3.TspOrdIOdr = item3.TspOrdIOdr.GetValueOrDefault() + item2.TspOrdIOdr.GetValueOrDefault();
															item3.TspOrdIOdam = item3.TspOrdIOdam.GetValueOrDefault() + item2.TspOrdIOdam.GetValueOrDefault();
															item3.TspOrdIOlr = item3.TspOrdIOlr.GetValueOrDefault() + item2.TspOrdIOlr.GetValueOrDefault();
															item3.TspOrdIOlam = item3.TspOrdIOlam.GetValueOrDefault() + item2.TspOrdIOlam.GetValueOrDefault();
															item3.TspOrdIConsfee = item3.TspOrdIConsfee.GetValueOrDefault() + item2.TspOrdIConsfee.GetValueOrDefault();
															item3.TspOrdISpro = item3.TspOrdISpro.GetValueOrDefault() + item2.TspOrdISpro.GetValueOrDefault();
															item3.TspOrdIBros = item3.TspOrdIBros.GetValueOrDefault() + item2.TspOrdIBros.GetValueOrDefault();
															item3.TspOrdICop = item3.TspOrdICop.GetValueOrDefault() + item2.TspOrdICop.GetValueOrDefault();
															item3.TspOrdIVop = item3.TspOrdIVop.GetValueOrDefault() + item2.TspOrdIVop.GetValueOrDefault();
															item3.TspOrdISscv = item3.TspOrdISscv.GetValueOrDefault() + item2.TspOrdISscv.GetValueOrDefault();
															item3.TspOrdISsrv = item3.TspOrdISsrv.GetValueOrDefault() + item2.TspOrdISsrv.GetValueOrDefault();
															item3.TspOrdIPspd = item3.TspOrdIPspd.GetValueOrDefault() + item2.TspOrdIPspd.GetValueOrDefault();
															item3.TspOrdICui = item3.TspOrdICui.GetValueOrDefault() + item2.TspOrdICui.GetValueOrDefault();
														}
													}
												}
												else
												{
													item2.TspPrdIndentify = item2.TspFGIndentify;
													item2.TspPrdName = item2.TspFGName;
													list2.Add(item2);
												}
											}
											else
											{
												item2.TspPrdIndentify = item2.TspFGIndentify;
												item2.TspPrdName = item2.TspFGName;
												list2.Add(item2);
											}
										}
										break;
									case 3:
										foreach (TSPspSelectOrderItems_Result item4 in list3)
										{
											string sgIdentify = item4.TspSGIndentify;
											if (string.IsNullOrWhiteSpace(sgIdentify))
											{
												continue;
											}
											if (list2 != null && Enumerable.Any<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list2))
											{
												if (Enumerable.FirstOrDefault<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list2, (Func<TSPspSelectOrderItems_Result, bool>)((TSPspSelectOrderItems_Result m) => m.TspSGIndentify == sgIdentify)) != null)
												{
													foreach (TSPspSelectOrderItems_Result item5 in list2)
													{
														if (!string.IsNullOrWhiteSpace(item5.TspSGIndentify) && item5.TspSGIndentify == sgIdentify)
														{
															item5.ordIQuantityTotal = null;
															item5.ordIQuantity = 1.0;
															item5.ordIFCR = 1.0;
															item5.ordIFCRI = 1.0;
															item5.ordIPrice = item5.ordIPrice.GetValueOrDefault() + item4.ordIPrice.GetValueOrDefault();
															item5.ordITotalPrice = item5.ordITotalPrice.GetValueOrDefault() + item4.ordITotalPrice.GetValueOrDefault();
															item5.ordIDiscountI = item5.ordIDiscountI.GetValueOrDefault() + item4.ordIDiscountI.GetValueOrDefault();
															item5.ordIDiscount = item5.ordIDiscount.GetValueOrDefault() + item4.ordIDiscount.GetValueOrDefault();
															item5.ordITax = item5.ordITax.GetValueOrDefault() + item4.ordITax.GetValueOrDefault();
															if (item5.ordITax.GetValueOrDefault() > 0m)
															{
																item5.ordITaxIndex = item5.ordITaxIndex.GetValueOrDefault(9m);
															}
															item5.ordIRound = item5.ordIRound.GetValueOrDefault() + item4.ordIRound.GetValueOrDefault();
															item5.ordIRoundPlus = item5.ordIRoundPlus.GetValueOrDefault() + item4.ordIRoundPlus.GetValueOrDefault();
															item5.ordIPriceSum = item5.ordIPriceSum.GetValueOrDefault() + item4.ordIPriceSum.GetValueOrDefault();
															item5.ordIDiscountISum = item5.ordIDiscountISum.GetValueOrDefault() + item4.ordIDiscountISum.GetValueOrDefault();
															item5.ordIDiscountSum = item5.ordIDiscountSum.GetValueOrDefault() + item4.ordIDiscountSum.GetValueOrDefault();
															item5.ordITaxSum = item5.ordITaxSum.GetValueOrDefault() + item4.ordITaxSum.GetValueOrDefault();
															item5.TspOrdICfee = item5.TspOrdICfee.GetValueOrDefault() + item4.TspOrdICfee.GetValueOrDefault();
															item5.TspOrdIExr = item5.TspOrdIExr.GetValueOrDefault() + item4.TspOrdIExr.GetValueOrDefault();
															item5.TspOrdIOdr = item5.TspOrdIOdr.GetValueOrDefault() + item4.TspOrdIOdr.GetValueOrDefault();
															item5.TspOrdIOdam = item5.TspOrdIOdam.GetValueOrDefault() + item4.TspOrdIOdam.GetValueOrDefault();
															item5.TspOrdIOlr = item5.TspOrdIOlr.GetValueOrDefault() + item4.TspOrdIOlr.GetValueOrDefault();
															item5.TspOrdIOlam = item5.TspOrdIOlam.GetValueOrDefault() + item4.TspOrdIOlam.GetValueOrDefault();
															item5.TspOrdIConsfee = item5.TspOrdIConsfee.GetValueOrDefault() + item4.TspOrdIConsfee.GetValueOrDefault();
															item5.TspOrdISpro = item5.TspOrdISpro.GetValueOrDefault() + item4.TspOrdISpro.GetValueOrDefault();
															item5.TspOrdIBros = item5.TspOrdIBros.GetValueOrDefault() + item4.TspOrdIBros.GetValueOrDefault();
															item5.TspOrdICop = item5.TspOrdICop.GetValueOrDefault() + item4.TspOrdICop.GetValueOrDefault();
															item5.TspOrdIVop = item5.TspOrdIVop.GetValueOrDefault() + item4.TspOrdIVop.GetValueOrDefault();
															item5.TspOrdISscv = item5.TspOrdISscv.GetValueOrDefault() + item4.TspOrdISscv.GetValueOrDefault();
															item5.TspOrdISsrv = item5.TspOrdISsrv.GetValueOrDefault() + item4.TspOrdISsrv.GetValueOrDefault();
															item5.TspOrdIPspd = item5.TspOrdIPspd.GetValueOrDefault() + item4.TspOrdIPspd.GetValueOrDefault();
															item5.TspOrdICui = item5.TspOrdICui.GetValueOrDefault() + item4.TspOrdICui.GetValueOrDefault();
														}
													}
												}
												else
												{
													item4.TspPrdIndentify = item4.TspSGIndentify;
													item4.TspPrdName = item4.TspSGName;
													list2.Add(item4);
												}
											}
											else
											{
												item4.TspPrdIndentify = item4.TspSGIndentify;
												item4.TspPrdName = item4.TspSGName;
												list2.Add(item4);
											}
										}
										break;
									case 2:
										foreach (TSPspSelectOrderItems_Result item6 in list3)
										{
											if (!string.IsNullOrWhiteSpace(item6.TspPrdIndentify))
											{
												list2.Add(item6);
											}
										}
										break;
									}
								}
								if (list2 == null || !Enumerable.Any<TSPspSelectOrderItems_Result>((IEnumerable<TSPspSelectOrderItems_Result>)list2))
								{
									text = string.Format(Messages.msgErrorItemNotDefinedPrdByTspIndentify, text2);
									tSPRowErrorViewModel = new TSPRowErrorViewModel
									{
										OrderID = value,
										ordNumber = value2,
										ordDate = ordDate,
										ordDateTime = value3,
										OrderOpr = orderOpr,
										CompanyName = companyName,
										ErrorMessage = text
									};
									list.Add(tSPRowErrorViewModel);
								}
								else
								{
									foreach (TSPspSelectOrderItems_Result item7 in list2)
									{
										if (string.IsNullOrWhiteSpace(item7.TspPrdIndentify))
										{
											switch (result7)
											{
											case 1:
												text = string.Format(Messages.msgErrorPrdFGNoSetTspTaxId, item7.PrdFGName ?? "", item7.PrdFGCode ?? "", text2);
												break;
											case 3:
												text = string.Format(Messages.msgErrorPrdSGNoSetTspTaxId, item7.PrdSGName ?? "", item7.PrdSGCode ?? "", text2);
												break;
											case 2:
												text = string.Format(Messages.msgErrorPrdNoSetTspTaxId, item7.PrdName ?? "", item7.PrdCode ?? "", text2);
												break;
											}
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
											continue;
										}
										bool flag = false;
										int num = 13;
										try
										{
											if (item7.TspPrdIndentify.Length != num)
											{
												flag = true;
											}
											long.Parse(item7.TspPrdIndentify);
										}
										catch (Exception)
										{
											flag = true;
										}
										if (flag)
										{
											switch (result7)
											{
											case 1:
												text = string.Format(Messages.msgErrorFormatPrdFGTspTaxId, item7.PrdFGName ?? "", item7.PrdFGCode ?? "", num.ToString());
												break;
											case 3:
												text = string.Format(Messages.msgErrorFormatPrdSGTspTaxId, item7.PrdSGName ?? "", item7.PrdSGCode ?? "", num.ToString());
												break;
											case 2:
												text = string.Format(Messages.msgErrorFormatPrdTspTaxId, item7.PrdName ?? "", item7.PrdCode ?? "", num.ToString());
												break;
											}
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
									}
								}
								List<TSPspSelectOrderPayments_Result> list4 = Enumerable.ToList<TSPspSelectOrderPayments_Result>((IEnumerable<TSPspSelectOrderPayments_Result>)cRMSpIEntities.TSPspSelectOrderPayments(ordId, lCID, result));
								int result9 = 0;
								int.TryParse(tSPspSelectOrderById_Result.OrderOprType.ToString(), out result9);
								int result10 = 0;
								int.TryParse(tSPspSelectOrderById_Result.ordStatusId.ToString(), out result10);
								int result11 = 0;
								int.TryParse(tSPspSelectOrderById_Result.TspCmpTob.ToString(), out result11);
								if (result11 != 2)
								{
									tSPspSelectOrderById_Result.TspInty = tSPspSelectOrderById_Result.TspIntyI;
									tSPspSelectOrderById_Result.TspIns = tSPspSelectOrderById_Result.TspInsI;
									tSPspSelectOrderById_Result.TspInp = tSPspSelectOrderById_Result.TspInpI;
								}
								int result12 = 0;
								int result13 = 0;
								int result14 = 0;
								int.TryParse(tSPspSelectOrderById_Result.ExceptTspInty.ToString(), out result12);
								int.TryParse(tSPspSelectOrderById_Result.ExceptTspInp.ToString(), out result13);
								int.TryParse(tSPspSelectOrderById_Result.ExceptTspIns.ToString(), out result14);
								if (result12 != 0)
								{
									tSPspSelectOrderById_Result.TspInty = tSPspSelectOrderById_Result.ExceptTspInty;
									tSPspSelectOrderById_Result.TspIns = tSPspSelectOrderById_Result.ExceptTspIns;
									tSPspSelectOrderById_Result.TspInp = tSPspSelectOrderById_Result.ExceptTspInp;
								}
								int result15 = 0;
								int.TryParse(tSPspSelectOrderById_Result.TspInty.ToString(), out result15);
								if (result15 == 0)
								{
									text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspInty);
									tSPRowErrorViewModel = new TSPRowErrorViewModel
									{
										OrderID = value,
										ordNumber = value2,
										ordDate = ordDate,
										ordDateTime = value3,
										OrderOpr = orderOpr,
										CompanyName = companyName,
										ErrorMessage = text
									};
									list.Add(tSPRowErrorViewModel);
								}
								int result16 = 0;
								int.TryParse(tSPspSelectOrderById_Result.TspInp.ToString(), out result16);
								if (result16 == 0 && result15 != 3)
								{
									text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspInp);
									tSPRowErrorViewModel = new TSPRowErrorViewModel
									{
										OrderID = value,
										ordNumber = value2,
										ordDate = ordDate,
										ordDateTime = value3,
										OrderOpr = orderOpr,
										CompanyName = companyName,
										ErrorMessage = text
									};
									list.Add(tSPRowErrorViewModel);
								}
								int result17 = 0;
								int.TryParse(tSPspSelectOrderById_Result.TspIns.ToString(), out result17);
								int result18 = 0;
								int.TryParse(tSPspSelectOrderById_Result.TspOrdIns.ToString(), out result18);
								result18 = result17;
								if (result10 == 4)
								{
									result18 = 3;
								}
								if (tspSendType == 3)
								{
									result18 = 3;
								}
								if (tspSendType == 4)
								{
									result18 = 2;
								}
								if (result18 == 0)
								{
									text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspOrdIns);
									tSPRowErrorViewModel = new TSPRowErrorViewModel
									{
										OrderID = value,
										ordNumber = value2,
										ordDate = ordDate,
										ordDateTime = value3,
										OrderOpr = orderOpr,
										CompanyName = companyName,
										ErrorMessage = text
									};
									list.Add(tSPRowErrorViewModel);
								}
								int result19 = 0;
								int.TryParse(tSPspSelectOrderById_Result.TspCmpTob.ToString(), out result19);
								_ = tSPspSelectOrderById_Result.TspCmpBbc;
								string cmpEconomicCode = tSPspSelectOrderById_Result.cmpEconomicCode;
								cmpEconomicCode = tSPspSelectOrderById_Result.cmpNationalCode;
								if (result19 != 2)
								{
									cmpEconomicCode = "";
								}
								if (result12 != 0)
								{
									cmpEconomicCode = tSPspSelectOrderById_Result.cmpEconomicCode;
								}
								string cmpNationalCode = tSPspSelectOrderById_Result.cmpNationalCode;
								string text5 = cmpNationalCode;
								_ = tSPspSelectOrderById_Result.TspOrdSbc;
								string tspOrdScln = tSPspSelectOrderById_Result.TspOrdScln;
								string tspOrdScc = tSPspSelectOrderById_Result.TspOrdScc;
								string tspOrdCrn = tSPspSelectOrderById_Result.TspOrdCrn;
								_ = tSPspSelectOrderById_Result.cmpOfficialZipCode;
								string tspCmpBbc = tSPspSelectOrderById_Result.TspCmpBbc;
								string tspCmpBpn = tSPspSelectOrderById_Result.TspCmpBpn;
								int? tspOrdFt = tSPspSelectOrderById_Result.TspOrdFt;
								string tspOrdBillid = tSPspSelectOrderById_Result.TspOrdBillid;
								if (!string.IsNullOrWhiteSpace(text5) && !string.IsNullOrWhiteSpace(tSPspSelectSettingById_Result.TspNationalCode) && text5 == tSPspSelectSettingById_Result.TspNationalCode)
								{
									text = Messages.msgErrorNationalCodeSellerAndBuyerIsSame;
									tSPRowErrorViewModel = new TSPRowErrorViewModel
									{
										OrderID = value,
										ordNumber = value2,
										ordDate = ordDate,
										ordDateTime = value3,
										OrderOpr = orderOpr,
										CompanyName = companyName,
										ErrorMessage = text
									};
									list.Add(tSPRowErrorViewModel);
								}
								int? num2 = tSPspSelectOrderById_Result.TspOrdSetm.GetValueOrDefault(1);
								_ = tSPspSelectOrderById_Result.TspOrdTax17;
								string value4 = tSPspSelectOrderById_Result.TspOrdIrtaxid;
								if (tspSendType == 3)
								{
									value4 = text3 ?? "";
								}
								if (tspSendType == 4)
								{
									value4 = text4 ?? "";
								}
								_ = tSPspSelectSettingById_Result.TspEconomicCode;
								if (!string.IsNullOrWhiteSpace(tSPspSelectSettingById_Result.TspNationalCode))
								{
									_ = tSPspSelectSettingById_Result.TspNationalCode;
								}
								switch (result15)
								{
								case 1:
									if (string.IsNullOrWhiteSpace(value4) && result18 != 1)
									{
										text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspOrdIrtaxid);
										tSPRowErrorViewModel = new TSPRowErrorViewModel
										{
											OrderID = value,
											ordNumber = value2,
											ordDate = ordDate,
											ordDateTime = value3,
											OrderOpr = orderOpr,
											CompanyName = companyName,
											ErrorMessage = text
										};
										list.Add(tSPRowErrorViewModel);
									}
									if (result19 == 0)
									{
										text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspCmpTob);
										tSPRowErrorViewModel = new TSPRowErrorViewModel
										{
											OrderID = value,
											ordNumber = value2,
											ordDate = ordDate,
											ordDateTime = value3,
											OrderOpr = orderOpr,
											CompanyName = companyName,
											ErrorMessage = text
										};
										list.Add(tSPRowErrorViewModel);
									}
									switch (result16)
									{
									case 1:
										if (num2.GetValueOrDefault() == 0)
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspSetm);
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										break;
									case 2:
										if (string.IsNullOrWhiteSpace(tspOrdScln))
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.ordTspOrdScln);
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										if (string.IsNullOrWhiteSpace(tspOrdScc))
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.ordTspOrdScc);
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										foreach (TSPspSelectOrderItems_Result item8 in list2)
										{
											if (item8.TspOrdICfee.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspCfee, item8.PrdName ?? "", item8.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
											if (string.IsNullOrWhiteSpace(item8.TspOrdICut))
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspCut, item8.PrdName ?? "", item8.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
											if (item8.TspOrdIExr.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspExr, item8.PrdName ?? "", item8.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
											if (item8.TspOrdIPspd.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspPspd, item8.PrdName ?? "", item8.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
										}
										if (num2.GetValueOrDefault() == 0)
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspSetm);
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										break;
									case 3:
										foreach (TSPspSelectOrderItems_Result item9 in list2)
										{
											if (item9.TspOrdIConsfee.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspConsfee, item9.PrdName ?? "", item9.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
											if (item9.TspOrdISpro.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspSpro, item9.PrdName ?? "", item9.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
											if (item9.TspOrdIBros.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspBros, item9.PrdName ?? "", item9.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
										}
										if (num2.GetValueOrDefault() == 0)
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspSetm);
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										break;
									case 4:
										if (string.IsNullOrWhiteSpace(tspOrdCrn))
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.ordTspOrdCrn);
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										if (num2.GetValueOrDefault() == 0)
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspSetm);
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										break;
									case 5:
										if (string.IsNullOrWhiteSpace(tspOrdBillid))
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspBillid);
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										foreach (TSPspSelectOrderItems_Result item10 in list2)
										{
											if (string.IsNullOrWhiteSpace(item10.TspOrdIOlt))
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspOlt, item10.PrdName ?? "", item10.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
											if (item10.TspOrdIOdr.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspOdr, item10.PrdName ?? "", item10.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
											if (item10.TspOrdIOdam.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspOdam, item10.PrdName ?? "", item10.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
										}
										break;
									case 6:
										if (string.IsNullOrWhiteSpace(tspCmpBpn))
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspBpn);
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										if (tspOrdFt.GetValueOrDefault() == 0)
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspFt);
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										break;
									case 7:
										foreach (TSPspSelectOrderItems_Result item11 in list2)
										{
											if (item11.TspOrdICfee.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspCfee, item11.PrdName ?? "", item11.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
											if (string.IsNullOrWhiteSpace(item11.TspOrdICut))
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspCut, item11.PrdName ?? "", item11.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
											if (item11.TspOrdIExr.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspExr, item11.PrdName ?? "", item11.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
											if (item11.TspOrdISscv.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspSscv, item11.PrdName ?? "", item11.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
											if (item11.TspOrdISsrv.GetValueOrDefault() == 0m)
											{
												text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspSsrv, item11.PrdName ?? "", item11.PrdCode ?? ""));
												tSPRowErrorViewModel = new TSPRowErrorViewModel
												{
													OrderID = value,
													ordNumber = value2,
													ordDate = ordDate,
													ordDateTime = value3,
													OrderOpr = orderOpr,
													CompanyName = companyName,
													ErrorMessage = text
												};
												list.Add(tSPRowErrorViewModel);
											}
										}
										break;
									}
									break;
								case 2:
									if (string.IsNullOrWhiteSpace(tSPspSelectOrderById_Result.TspOrdIrtaxid) && result18 == 4)
									{
										text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspOrdIrtaxid);
										tSPRowErrorViewModel = new TSPRowErrorViewModel
										{
											OrderID = value,
											ordNumber = value2,
											ordDate = ordDate,
											ordDateTime = value3,
											OrderOpr = orderOpr,
											CompanyName = companyName,
											ErrorMessage = text
										};
										list.Add(tSPRowErrorViewModel);
									}
									if (result16 != 3)
									{
										break;
									}
									foreach (TSPspSelectOrderItems_Result item12 in list2)
									{
										if (item12.TspOrdIConsfee.GetValueOrDefault() == 0m)
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspConsfee, item12.PrdName ?? "", item12.PrdCode ?? ""));
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										if (item12.TspOrdISpro.GetValueOrDefault() == 0m)
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspSpro, item12.PrdName ?? "", item12.PrdCode ?? ""));
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										if (item12.TspOrdIBros.GetValueOrDefault() == 0m)
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspBros, item12.PrdName ?? "", item12.PrdCode ?? ""));
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
									}
									if (num2.GetValueOrDefault() == 0)
									{
										text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspSetm);
										tSPRowErrorViewModel = new TSPRowErrorViewModel
										{
											OrderID = value,
											ordNumber = value2,
											ordDate = ordDate,
											ordDateTime = value3,
											OrderOpr = orderOpr,
											CompanyName = companyName,
											ErrorMessage = text
										};
										list.Add(tSPRowErrorViewModel);
									}
									break;
								case 3:
									if (string.IsNullOrWhiteSpace(cmpNationalCode))
									{
										text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspPid);
										tSPRowErrorViewModel = new TSPRowErrorViewModel
										{
											OrderID = value,
											ordNumber = value2,
											ordDate = ordDate,
											ordDateTime = value3,
											OrderOpr = orderOpr,
											CompanyName = companyName,
											ErrorMessage = text
										};
										list.Add(tSPRowErrorViewModel);
									}
									if (list4 == null || !Enumerable.Any<TSPspSelectOrderPayments_Result>((IEnumerable<TSPspSelectOrderPayments_Result>)list4))
									{
										text = string.Format(Messages.msgErrorItemNotDefinedPay, text2);
										tSPRowErrorViewModel = new TSPRowErrorViewModel
										{
											OrderID = value,
											ordNumber = value2,
											ordDate = ordDate,
											ordDateTime = value3,
											OrderOpr = orderOpr,
											CompanyName = companyName,
											ErrorMessage = text
										};
										list.Add(tSPRowErrorViewModel);
										break;
									}
									foreach (TSPspSelectOrderPayments_Result item13 in list4)
									{
										string arg = item13.OrdpayType + " - " + (item13.ImportDateTime.HasValue ? item13.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
										int result20 = 0;
										int.TryParse(item13.TspOrdPayPmt.ToString(), out result20);
										if (result20 == 0)
										{
											int.TryParse(item13.TspOrdpayTypePmt.ToString(), out result20);
										}
										string value5 = item13.TspOrdPayIinn ?? "";
										if (string.IsNullOrWhiteSpace(value5))
										{
											value5 = item13.TspOrdpayTypeIinn ?? "";
										}
										string value6 = item13.TspOrdPayAcn ?? "";
										if (string.IsNullOrWhiteSpace(value6))
										{
											value6 = item13.TspOrdpayTypeAcn ?? "";
										}
										string value7 = item13.TspOrdPayTrmn ?? "";
										if (string.IsNullOrWhiteSpace(value7))
										{
											value7 = item13.TspOrdpayTypeTrmn ?? "";
										}
										if (result20 == 0)
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspPmt, arg));
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										if (item13.ordpayAmount == 0m)
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspPayAmount, arg));
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										if (string.IsNullOrWhiteSpace(value5))
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspIinn, arg));
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										if (string.IsNullOrWhiteSpace(value6))
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspAcn, arg));
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										if (string.IsNullOrWhiteSpace(value7))
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspTrmn, arg));
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										item13.ordpayBankDocNumber = item13.ordpayBankDocNumber ?? item13.ordpayDocNumber;
										if (!string.IsNullOrWhiteSpace(item13.ordpayBankDocNumber))
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspTrn, arg));
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
										if (!string.IsNullOrWhiteSpace(item13.ordpayCardNumber))
										{
											text = string.Format(Messages.msgErrorIsNotEnteredItem, string.Format(Labels.TspPcn, arg));
											tSPRowErrorViewModel = new TSPRowErrorViewModel
											{
												OrderID = value,
												ordNumber = value2,
												ordDate = ordDate,
												ordDateTime = value3,
												OrderOpr = orderOpr,
												CompanyName = companyName,
												ErrorMessage = text
											};
											list.Add(tSPRowErrorViewModel);
										}
									}
									break;
								}
								DateTime valueOrDefault = tSPspSelectOrderById_Result.ordDateTime.GetValueOrDefault(now);
								new DateTimeOffset(valueOrDefault).ToUnixTimeMilliseconds();
								new DateTimeOffset(tSPspSelectOrderById_Result.FirstRegisterDate.GetValueOrDefault(now)).ToUnixTimeMilliseconds();
								if (valueOrDefault > DateTime.Now)
								{
									text = string.Format(Messages.msgErrorItemDateNoMoreThanCurrDate, Labels.ordDate);
									tSPRowErrorViewModel = new TSPRowErrorViewModel
									{
										OrderID = value,
										ordNumber = value2,
										ordDate = ordDate,
										ordDateTime = value3,
										OrderOpr = orderOpr,
										CompanyName = companyName,
										ErrorMessage = text
									};
									list.Add(tSPRowErrorViewModel);
								}
								if (!string.IsNullOrWhiteSpace(tspCmpBbc))
								{
									bool flag2 = false;
									int num3 = 4;
									try
									{
										if (tspCmpBbc.Length != num3)
										{
											flag2 = true;
										}
										long.Parse(tspCmpBbc);
									}
									catch (Exception)
									{
										flag2 = true;
									}
									if (flag2)
									{
										text = string.Format(Messages.msgErrorFormatTspItem, Labels.cmpTspCmpBbc, Labels.lblCmp, num3.ToString());
										tSPRowErrorViewModel = new TSPRowErrorViewModel
										{
											OrderID = value,
											ordNumber = value2,
											ordDate = ordDate,
											ordDateTime = value3,
											OrderOpr = orderOpr,
											CompanyName = companyName,
											ErrorMessage = text
										};
										list.Add(tSPRowErrorViewModel);
									}
								}
								if (result15 == 1 && result16 == 1 && result19 == 1 && string.IsNullOrWhiteSpace(cmpEconomicCode))
								{
									text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.cmpEconomicCode + " (" + Labels.lblCmp + ")");
									tSPRowErrorViewModel = new TSPRowErrorViewModel
									{
										OrderID = value,
										ordNumber = value2,
										ordDate = ordDate,
										ordDateTime = value3,
										OrderOpr = orderOpr,
										CompanyName = companyName,
										ErrorMessage = text
									};
									list.Add(tSPRowErrorViewModel);
								}
								if (string.IsNullOrWhiteSpace(text5))
								{
									if (result19 == 2)
									{
										text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.cmpNationalCode + " (" + Labels.lblCmp + ")");
										tSPRowErrorViewModel = new TSPRowErrorViewModel
										{
											OrderID = value,
											ordNumber = value2,
											ordDate = ordDate,
											ordDateTime = value3,
											OrderOpr = orderOpr,
											CompanyName = companyName,
											ErrorMessage = text
										};
										list.Add(tSPRowErrorViewModel);
									}
									else if (result15 == 1 && result16 == 1 && (result19 == 1 || result19 == 3))
									{
										text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.cmpNationalCode + " (" + Labels.lblCmp + ")");
										tSPRowErrorViewModel = new TSPRowErrorViewModel
										{
											OrderID = value,
											ordNumber = value2,
											ordDate = ordDate,
											ordDateTime = value3,
											OrderOpr = orderOpr,
											CompanyName = companyName,
											ErrorMessage = text
										};
										list.Add(tSPRowErrorViewModel);
									}
								}
								else
								{
									bool flag3 = false;
									int num4 = 0;
									switch (result19)
									{
									case 1:
										num4 = 10;
										break;
									case 2:
									case 3:
										num4 = 11;
										break;
									case 4:
										num4 = 12;
										break;
									}
									try
									{
										if (text5.Length != num4 && num4 > 0)
										{
											flag3 = true;
										}
										long.Parse(text5);
									}
									catch (Exception)
									{
										flag3 = true;
									}
									if (flag3)
									{
										text = string.Format(Messages.msgErrorFormatTspItem, Labels.cmpNationalCode, Labels.lblCmp, num4.ToString());
										tSPRowErrorViewModel = new TSPRowErrorViewModel
										{
											OrderID = value,
											ordNumber = value2,
											ordDate = ordDate,
											ordDateTime = value3,
											OrderOpr = orderOpr,
											CompanyName = companyName,
											ErrorMessage = text
										};
										list.Add(tSPRowErrorViewModel);
									}
								}
							}
							else
							{
								text = Messages.ErrorNotFound;
								tSPRowErrorViewModel = new TSPRowErrorViewModel
								{
									OrderID = value,
									ordNumber = value2,
									ordDate = ordDate,
									ordDateTime = value3,
									OrderOpr = orderOpr,
									CompanyName = companyName,
									ErrorMessage = text
								};
								list.Add(tSPRowErrorViewModel);
							}
						}
						else
						{
							text = Messages.errorInReadingSetting;
							tSPRowErrorViewModel = new TSPRowErrorViewModel
							{
								OrderID = value,
								ordNumber = value2,
								ordDate = ordDate,
								ordDateTime = value3,
								OrderOpr = orderOpr,
								CompanyName = companyName,
								ErrorMessage = text
							};
							list.Add(tSPRowErrorViewModel);
						}
					}
					else
					{
						text = Messages.errorInReadingSetting;
						tSPRowErrorViewModel = new TSPRowErrorViewModel
						{
							OrderID = value,
							ordNumber = value2,
							ordDate = ordDate,
							ordDateTime = value3,
							OrderOpr = orderOpr,
							CompanyName = companyName,
							ErrorMessage = text
						};
						list.Add(tSPRowErrorViewModel);
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
					tSPRowErrorViewModel = new TSPRowErrorViewModel
					{
						OrderID = value,
						ordNumber = value2,
						ordDate = ordDate,
						ordDateTime = value3,
						OrderOpr = orderOpr,
						CompanyName = companyName,
						ErrorMessage = text
					};
					list.Add(tSPRowErrorViewModel);
				}
			}
			else
			{
				text = Messages.ErrorNotFound;
				tSPRowErrorViewModel = new TSPRowErrorViewModel
				{
					OrderID = value,
					ordNumber = value2,
					ordDate = ordDate,
					ordDateTime = value3,
					OrderOpr = orderOpr,
					CompanyName = companyName,
					ErrorMessage = text
				};
				list.Add(tSPRowErrorViewModel);
			}
		}
		catch (Exception ex4)
		{
			ErrorSignal.FromCurrentContext().Raise(ex4);
			text = Messages.msgErrorRunFunction + " (" + ex4.Message + ")";
			tSPRowErrorViewModel = new TSPRowErrorViewModel
			{
				OrderID = value,
				ordNumber = value2,
				ordDate = ordDate,
				ordDateTime = value3,
				OrderOpr = orderOpr,
				CompanyName = companyName,
				ErrorMessage = text
			};
			list.Add(tSPRowErrorViewModel);
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMSpIEntities.Dispose();
		}
		return list;
	}

	public static CommonResultViewModel<int> TestToken(int tspSettingId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			_ = now.Ticks;
			string text2 = "";
			if (tspSettingId != 0)
			{
				TSPspSelectSettingById_Result tSPspSelectSettingById_Result = Enumerable.FirstOrDefault<TSPspSelectSettingById_Result>((IEnumerable<TSPspSelectSettingById_Result>)cRMSpIEntities.TSPspSelectSettingById(tspSettingId, lCID, result));
				if (tSPspSelectSettingById_Result != null)
				{
					string privateKey = CleanPrivateKey(tSPspSelectSettingById_Result.TspPrivateKey);
					TaxApiService.Instance.Init(tSPspSelectSettingById_Result.TspIdentify, new SignatoryConfig(privateKey, null), new NormalProperties(ClientType.SELF_TSP), UrlTsp);
					TaxApiService.Instance.TaxApis.GetServerInformation();
					TokenModel tokenModel = TaxApiService.Instance.TaxApis.RequestToken();
					if (tokenModel == null)
					{
						text = Messages.msgErrorReceivingToken;
					}
					else
					{
						text2 = tokenModel.Token ?? "";
					}
				}
				else
				{
					text = Messages.errorInReadingSetting;
				}
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				data = 0;
				return new CommonResultViewModel<int>
				{
					Data = data,
					Message = text,
					Status = CommonResultStatusViewModel.Fail
				};
			}
			data = 1;
			text = text2;
			status = CommonResultStatusViewModel.Success;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			return new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMSpIEntities.Dispose();
		}
		return new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = status
		};
	}
}
