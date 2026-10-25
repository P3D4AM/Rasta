using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class FOOnlinePaymentController : ApiController
{
	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FoPreOrderDetailsViewModel> GetPreOrderDetails(int pordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		FoPreOrderDetailsViewModel foPreOrderDetailsViewModel = null;
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					SHPMobspSelectPreOrderWithId_Result sHPMobspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<SHPMobspSelectPreOrderWithId_Result>((IEnumerable<SHPMobspSelectPreOrderWithId_Result>)cRMSpEntities.SHPMobspSelectPreOrderWithId(pordId, num, result2, cId));
					if (sHPMobspSelectPreOrderWithId_Result != null)
					{
						foPreOrderDetailsViewModel = new FoPreOrderDetailsViewModel();
						foPreOrderDetailsViewModel.PreOrder = sHPMobspSelectPreOrderWithId_Result;
						foPreOrderDetailsViewModel.PreOrderItems = new List<SHPMobspSelectPreOrderItems_Result>();
						foPreOrderDetailsViewModel.PreOrderPayments = new List<SHPMobspSelectPreOrderPayments_Result>();
						List<SHPMobspSelectPreOrderItems_Result> list = Enumerable.ToList<SHPMobspSelectPreOrderItems_Result>((IEnumerable<SHPMobspSelectPreOrderItems_Result>)cRMSpEntities.SHPMobspSelectPreOrderItems(pordId, num, result2));
						if (list != null && Enumerable.Any<SHPMobspSelectPreOrderItems_Result>((IEnumerable<SHPMobspSelectPreOrderItems_Result>)list))
						{
							foPreOrderDetailsViewModel.PreOrderItems = list;
						}
						List<SHPMobspSelectPreOrderPayments_Result> list2 = Enumerable.ToList<SHPMobspSelectPreOrderPayments_Result>((IEnumerable<SHPMobspSelectPreOrderPayments_Result>)cRMSpEntities.SHPMobspSelectPreOrderPayments(pordId, num, result2, cId));
						if (list2 != null && Enumerable.Any<SHPMobspSelectPreOrderPayments_Result>((IEnumerable<SHPMobspSelectPreOrderPayments_Result>)list2))
						{
							foPreOrderDetailsViewModel.PreOrderPayments = list2;
						}
						if (pordId != 0)
						{
							FoPrintLog.InsertPrintLog(token2.CompanyId, pordId, 1, 2);
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorPreOrderNotFound;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					foPreOrderDetailsViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				foPreOrderDetailsViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			foPreOrderDetailsViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<FoPreOrderDetailsViewModel>
		{
			Message = message,
			Data = foPreOrderDetailsViewModel,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FoOrderDetailsViewModel> GetOrderDetails(int ordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		FoOrderDetailsViewModel foOrderDetailsViewModel = null;
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					FOMobspSelectOrderWithId_Result fOMobspSelectOrderWithId_Result = Enumerable.FirstOrDefault<FOMobspSelectOrderWithId_Result>((IEnumerable<FOMobspSelectOrderWithId_Result>)cRMSpEntities.FOMobspSelectOrderWithId(ordId, num, result2, cId));
					if (fOMobspSelectOrderWithId_Result != null)
					{
						foOrderDetailsViewModel = new FoOrderDetailsViewModel();
						foOrderDetailsViewModel.Order = fOMobspSelectOrderWithId_Result;
						foOrderDetailsViewModel.OrderItems = new List<FOMobspSelectOrderItems_Result>();
						foOrderDetailsViewModel.OrderPayments = new List<FOMobspSelectOrderPayments_Result>();
						List<FOMobspSelectOrderItems_Result> list = Enumerable.ToList<FOMobspSelectOrderItems_Result>((IEnumerable<FOMobspSelectOrderItems_Result>)cRMSpEntities.FOMobspSelectOrderItems(ordId, num, result2));
						if (list != null && Enumerable.Any<FOMobspSelectOrderItems_Result>((IEnumerable<FOMobspSelectOrderItems_Result>)list))
						{
							foOrderDetailsViewModel.OrderItems = list;
						}
						List<FOMobspSelectOrderPayments_Result> list2 = Enumerable.ToList<FOMobspSelectOrderPayments_Result>((IEnumerable<FOMobspSelectOrderPayments_Result>)cRMSpEntities.FOMobspSelectOrderPayments(ordId, num, result2, cId));
						if (list2 != null && Enumerable.Any<FOMobspSelectOrderPayments_Result>((IEnumerable<FOMobspSelectOrderPayments_Result>)list2))
						{
							foOrderDetailsViewModel.OrderPayments = list2;
						}
						if (ordId != 0)
						{
							FoPrintLog.InsertPrintLog(token2.CompanyId, ordId, 2, 2);
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorOrderNotFound;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					foOrderDetailsViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				foOrderDetailsViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			foOrderDetailsViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<FoOrderDetailsViewModel>
		{
			Message = message,
			Data = foOrderDetailsViewModel,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<bool> AddDiscountCodeToPord(string disCode, int pordId, int? ln = null, int? cId = null)
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
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					if (Enumerable.FirstOrDefault<SHPMobspSelectPreOrderWithId_Result>((IEnumerable<SHPMobspSelectPreOrderWithId_Result>)cRMSpEntities.SHPMobspSelectPreOrderWithId(pordId, num, result2, cId)) != null)
					{
						FOMobspSelectDiscountCodeByDisCode_Result fOMobspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<FOMobspSelectDiscountCodeByDisCode_Result>((IEnumerable<FOMobspSelectDiscountCodeByDisCode_Result>)cRMSpEntities.FOMobspSelectDiscountCodeByDisCode(disCode, num, result2));
						if (fOMobspSelectDiscountCodeByDisCode_Result != null)
						{
							string arg = fOMobspSelectDiscountCodeByDisCode_Result.DisPrdName ?? "";
							int result3 = 0;
							int.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DisCmpId.ToString(), out result3);
							if (result3 == 0 || result3 == token2.CompanyId)
							{
								_ = fOMobspSelectDiscountCodeByDisCode_Result.DisExpDate;
								string s = fOMobspSelectDiscountCodeByDisCode_Result.DisExpDate.ToString("yyyyMMdd");
								string s2 = DateTime.Now.ToString("yyyyMMdd");
								string text = "";
								List<FOMobspSelectPreOrderItemsByNotInSumAndNoDis_Result> list = Enumerable.ToList<FOMobspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<FOMobspSelectPreOrderItemsByNotInSumAndNoDis_Result>)cRMSpEntities.FOMobspSelectPreOrderItemsByNotInSumAndNoDis(pordId, false, false, num, result2));
								if (list != null)
								{
									foreach (FOMobspSelectPreOrderItemsByNotInSumAndNoDis_Result item in list)
									{
										if (!string.IsNullOrWhiteSpace(text))
										{
											text += ",";
										}
										text += item.PreOrderItemID;
									}
								}
								if (long.Parse(s) >= long.Parse(s2))
								{
									int result4 = 0;
									int.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DisUseCnt.ToString(), out result4);
									int result5 = 0;
									int.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.UsedCount.ToString(), out result5);
									if (result4 > result5)
									{
										int disPrdId = 0;
										int.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DisPrdId.ToString(), out disPrdId);
										bool flag = true;
										if (disPrdId != 0 && list != null && Enumerable.FirstOrDefault<FOMobspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<FOMobspSelectPreOrderItemsByNotInSumAndNoDis_Result>)list, (Func<FOMobspSelectPreOrderItemsByNotInSumAndNoDis_Result, bool>)((FOMobspSelectPreOrderItemsByNotInSumAndNoDis_Result m) => m.pordIPrdId == disPrdId)) == null)
										{
											flag = false;
										}
										if (flag)
										{
											double result6 = 0.0;
											double.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.ScoreRate.ToString(), out result6);
											bool flag2 = true;
											if (result6 != 0.0)
											{
												double result7 = 0.0;
												double result8 = 0.0;
												FOMobspReturnSumCompanyScores_Result fOMobspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<FOMobspReturnSumCompanyScores_Result>((IEnumerable<FOMobspReturnSumCompanyScores_Result>)cRMSpEntities.FOMobspReturnSumCompanyScores(token2.CompanyId, cId));
												if (fOMobspReturnSumCompanyScores_Result != null)
												{
													double.TryParse(fOMobspReturnSumCompanyScores_Result.SumScores.ToString(), out result7);
													double.TryParse(fOMobspReturnSumCompanyScores_Result.SumUsableScores.ToString(), out result8);
												}
												if (result6 > result8)
												{
													flag2 = false;
												}
											}
											if (flag2)
											{
												DateTime now = DateTime.Now;
												DateTime value = now;
												string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
												short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
												string appType = Mobile.Classes.Configuration.AppType;
												int id = Financial.Get().Id;
												int value3 = -20;
												ObjectParameter objectParameter = new ObjectParameter("Result", 0);
												decimal result9 = default(decimal);
												decimal.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DisAmount.ToString(), out result9);
												decimal result10 = default(decimal);
												decimal.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DisAmountPercent.ToString(), out result10);
												int result11 = 0;
												int.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DiscountCodeId.ToString(), out result11);
												cRMSpEntities.FOMobspDistributeDiscountToPreOrderItems(pordId, text, result9, result10, value3, id, value2, value, registerDatePersian, appType, objectParameter, true, result11, cId);
												if (int.Parse(objectParameter.Value.ToString()) > 0)
												{
													data = true;
													message = Messages.MobMsgSuccessAction;
													status = ServiceResultStatus.Success;
												}
												else
												{
													message = Messages.FOMsgErrorDoneOperation;
													status = ServiceResultStatus.Fail;
												}
											}
											else
											{
												message = string.Format(Messages.FOMsgErrorDisCodeNoScoreMin, result6.ToString());
												status = ServiceResultStatus.Fail;
											}
										}
										else
										{
											message = string.Format(Messages.FOMsgErrorDisCodeItemNoPrd, arg, Labels.lblPOrd);
											status = ServiceResultStatus.Fail;
										}
									}
									else
									{
										message = Messages.FOMsgErrorDisCodeUsedBefore;
										status = ServiceResultStatus.Fail;
									}
								}
								else
								{
									message = Messages.FOMsgErrorDisCodeExpired;
									status = ServiceResultStatus.Fail;
								}
							}
							else
							{
								message = Messages.FOMsgErrorDisCodeUnUsableForYou;
								status = ServiceResultStatus.Fail;
							}
						}
						else
						{
							message = Messages.FOMsgErrorDisCodeIncorrect;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErrorPreOrderNotFound;
						status = ServiceResultStatus.Fail;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<bool> AddDiscountCodeToOrd(string disCode, int ordId, int? ln = null, int? cId = null)
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
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					FOMobspSelectOrderWithId_Result fOMobspSelectOrderWithId_Result = Enumerable.FirstOrDefault<FOMobspSelectOrderWithId_Result>((IEnumerable<FOMobspSelectOrderWithId_Result>)cRMSpEntities.FOMobspSelectOrderWithId(ordId, num, result2, cId));
					if (fOMobspSelectOrderWithId_Result != null)
					{
						string text = "";
						List<FOMobspSelectOrderItemsByNotInSumAndNoDis_Result> list = Enumerable.ToList<FOMobspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<FOMobspSelectOrderItemsByNotInSumAndNoDis_Result>)cRMSpEntities.FOMobspSelectOrderItemsByNotInSumAndNoDis(ordId, false, false, num, result2));
						if (list != null)
						{
							foreach (FOMobspSelectOrderItemsByNotInSumAndNoDis_Result item in list)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									text += ",";
								}
								text += item.OrderItemID;
							}
						}
						_ = fOMobspSelectOrderWithId_Result.Company;
						if (!string.IsNullOrEmpty(disCode))
						{
							FOMobspSelectDiscountCodeByDisCode_Result fOMobspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<FOMobspSelectDiscountCodeByDisCode_Result>((IEnumerable<FOMobspSelectDiscountCodeByDisCode_Result>)cRMSpEntities.FOMobspSelectDiscountCodeByDisCode(disCode, num, result2));
							if (fOMobspSelectDiscountCodeByDisCode_Result != null)
							{
								string arg = fOMobspSelectDiscountCodeByDisCode_Result.DisPrdName ?? "";
								int result3 = 0;
								int.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DisCmpId.ToString(), out result3);
								if (result3 == 0 || result3 == token2.CompanyId)
								{
									_ = fOMobspSelectDiscountCodeByDisCode_Result.DisExpDate;
									string s = fOMobspSelectDiscountCodeByDisCode_Result.DisExpDate.ToString("yyyyMMdd");
									string s2 = DateTime.Now.ToString("yyyyMMdd");
									if (long.Parse(s) >= long.Parse(s2))
									{
										int result4 = 0;
										int.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DisUseCnt.ToString(), out result4);
										int result5 = 0;
										int.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.UsedCount.ToString(), out result5);
										if (result4 > result5)
										{
											int disPrdId = 0;
											int.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DisPrdId.ToString(), out disPrdId);
											bool flag = true;
											if (disPrdId != 0 && list != null && Enumerable.FirstOrDefault<FOMobspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<FOMobspSelectOrderItemsByNotInSumAndNoDis_Result>)list, (Func<FOMobspSelectOrderItemsByNotInSumAndNoDis_Result, bool>)((FOMobspSelectOrderItemsByNotInSumAndNoDis_Result m) => m.ordIPrdId == disPrdId)) == null)
											{
												flag = false;
											}
											if (flag)
											{
												double result6 = 0.0;
												double.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.ScoreRate.ToString(), out result6);
												bool flag2 = true;
												if (result6 != 0.0)
												{
													double result7 = 0.0;
													double result8 = 0.0;
													FOMobspReturnSumCompanyScores_Result fOMobspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<FOMobspReturnSumCompanyScores_Result>((IEnumerable<FOMobspReturnSumCompanyScores_Result>)cRMSpEntities.FOMobspReturnSumCompanyScores(token2.CompanyId, cId));
													if (fOMobspReturnSumCompanyScores_Result != null)
													{
														double.TryParse(fOMobspReturnSumCompanyScores_Result.SumScores.ToString(), out result7);
														double.TryParse(fOMobspReturnSumCompanyScores_Result.SumUsableScores.ToString(), out result8);
													}
													if (result6 > result8)
													{
														flag2 = false;
													}
												}
												if (flag2)
												{
													DateTime now = DateTime.Now;
													DateTime value = now;
													string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
													short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
													string appType = Mobile.Classes.Configuration.AppType;
													int id = Financial.Get().Id;
													int value3 = -20;
													ObjectParameter objectParameter = new ObjectParameter("Result", 0);
													decimal result9 = default(decimal);
													decimal.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DisAmount.ToString(), out result9);
													decimal result10 = default(decimal);
													decimal.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DisAmountPercent.ToString(), out result10);
													int result11 = 0;
													int.TryParse(fOMobspSelectDiscountCodeByDisCode_Result.DiscountCodeId.ToString(), out result11);
													cRMSpEntities.FOMobspDistributeDiscountToOrderItems(ordId, text, result9, result10, value3, id, value2, value, registerDatePersian, appType, objectParameter, true, result11, cId);
													if (int.Parse(objectParameter.Value.ToString()) > 0)
													{
														data = true;
														message = Messages.MobMsgSuccessAction;
														status = ServiceResultStatus.Success;
													}
													else
													{
														message = Messages.FOMsgErrorDoneOperation;
														status = ServiceResultStatus.Fail;
													}
												}
												else
												{
													message = string.Format(Messages.FOMsgErrorDisCodeNoScoreMin, result6.ToString());
													status = ServiceResultStatus.Fail;
												}
											}
											else
											{
												message = string.Format(Messages.FOMsgErrorDisCodeItemNoPrd, arg, Labels.lblOrd);
												status = ServiceResultStatus.Fail;
											}
										}
										else
										{
											message = Messages.FOMsgErrorDisCodeUsedBefore;
											status = ServiceResultStatus.Fail;
										}
									}
									else
									{
										message = Messages.FOMsgErrorDisCodeExpired;
										status = ServiceResultStatus.Fail;
									}
								}
								else
								{
									message = Messages.FOMsgErrorDisCodeUnUsableForYou;
									status = ServiceResultStatus.Fail;
								}
							}
							else
							{
								message = Messages.FOMsgErrorDisCodeIncorrect;
								status = ServiceResultStatus.Fail;
							}
						}
						else
						{
							message = string.Format(Messages.FOMsgErrorIsNotEnteredItem, Labels.FOShpCartDisCode);
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErrorOrderNotFound;
						status = ServiceResultStatus.Fail;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> UpdatePordPayment(FoUpdatePreOrderPaymentViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					now.ToString("HH:mm:ss");
					DateTimeClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int id = Financial.Get().Id;
					int num2 = -20;
					List<FOMobspSelectLanguages_Result> list = Enumerable.ToList<FOMobspSelectLanguages_Result>((IEnumerable<FOMobspSelectLanguages_Result>)cRMEntities.FOMobspSelectLanguages());
					DateTime dateTime = default(DateTime);
					DateTime value3 = default(DateTime);
					string text = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(model.DocDate))
						{
							text = PersianDate.GetFormatetdDate(model.DocDate.Replace("/", ""));
							switch (num)
							{
							case 1065:
								dateTime = DateTime.Parse(text + " 00:00:00", new PersianCulture());
								model.DocDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA"));
								model.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US"));
								model.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							value3 = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						return new ServiceResult<bool>
						{
							Message = Messages.FOMsgErrorDoneOperation + "<br>" + string.Format(Messages.ErrorInFormat, Labels.FoPayAddFilePayDocDate),
							Data = false,
							Status = ServiceResultStatus.Fail
						};
					}
					SHPMobspSelectPreOrderWithId_Result sHPMobspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<SHPMobspSelectPreOrderWithId_Result>((IEnumerable<SHPMobspSelectPreOrderWithId_Result>)cRMSpEntities.SHPMobspSelectPreOrderWithId(model.PreOrderId, num, defLangId, model.CenterId));
					if (sHPMobspSelectPreOrderWithId_Result != null)
					{
						int result2 = 0;
						_ = sHPMobspSelectPreOrderWithId_Result.pordNumber;
						_ = sHPMobspSelectPreOrderWithId_Result.pordCurrencyUnit;
						int.TryParse(sHPMobspSelectPreOrderWithId_Result.pordReferUserId.ToString(), out result2);
						if (cRMSpEntities.FOMobspUpdatePreOrderPayment(model.PreOrderId, model.PayId, model.PayAmount, model.DocNumber, "", model.DocDate, model.PayAmount, string.IsNullOrWhiteSpace(model.DocDate) ? null : new DateTime?(value3), num2, value, registerDatePersian, id, value2, appType, num, defLangId) > 0)
						{
							string resourceString = MyResource.GetResourceString("FOVerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							string resourceString2 = MyResource.GetResourceString("FOPaymentMessageForPord", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							List<FoCommonIMultiLanguageViewModel> list2 = new List<FoCommonIMultiLanguageViewModel>();
							List<FOMobspSelectLanguages_Result> list3 = Enumerable.ToList<FOMobspSelectLanguages_Result>(Enumerable.Where<FOMobspSelectLanguages_Result>((IEnumerable<FOMobspSelectLanguages_Result>)list, (Func<FOMobspSelectLanguages_Result, bool>)((FOMobspSelectLanguages_Result m) => m.LanguageID != defLangId)));
							if (list3 != null)
							{
								foreach (FOMobspSelectLanguages_Result item2 in list3)
								{
									_ = Enumerable.FirstOrDefault<SHPMobspSelectPreOrderWithId_Result>((IEnumerable<SHPMobspSelectPreOrderWithId_Result>)cRMSpEntities.SHPMobspSelectPreOrderWithId(model.PreOrderId, item2.LanguageID, defLangId, model.CenterId))?.pordCurrencyUnit;
									string resourceString3 = MyResource.GetResourceString("FOVerifiedRequestSubject", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
									string resourceString4 = MyResource.GetResourceString("FOPaymentMessageForPord", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
									FoCommonIMultiLanguageViewModel item = new FoCommonIMultiLanguageViewModel
									{
										Value = resourceString4,
										ValueI = (resourceString3 ?? resourceString),
										LanguageId = item2.LanguageID
									};
									list2.Add(item);
								}
							}
							if (result2 != 0)
							{
								string msgBody = ((!string.IsNullOrWhiteSpace(resourceString2)) ? resourceString2 : resourceString);
								SendInternalMessage(resourceString, msgBody, 5, num2, result2, model.PreOrderId, list2, model.CenterId);
							}
							message = Messages.MobMsgSuccessAction;
							data = true;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.FOMsgErrorDoneOperation;
							data = false;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErrorPreOrderNotFound;
						data = false;
						status = ServiceResultStatus.Fail;
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
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

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<bool> UpdateOrdPayment(FoUpdateOrderPaymentViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					now.ToString("HH:mm:ss");
					DateTimeClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int id = Financial.Get().Id;
					int num2 = -20;
					List<FOMobspSelectLanguages_Result> list = Enumerable.ToList<FOMobspSelectLanguages_Result>((IEnumerable<FOMobspSelectLanguages_Result>)cRMEntities.FOMobspSelectLanguages());
					DateTime dateTime = default(DateTime);
					DateTime value3 = default(DateTime);
					string text = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(model.DocDate))
						{
							text = PersianDate.GetFormatetdDate(model.DocDate.Replace("/", ""));
							switch (num)
							{
							case 1065:
								dateTime = DateTime.Parse(text + " 00:00:00", new PersianCulture());
								model.DocDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA"));
								model.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US"));
								model.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							value3 = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						return new ServiceResult<bool>
						{
							Message = Messages.FOMsgErrorDoneOperation + "<br>" + string.Format(Messages.ErrorInFormat, Labels.FoPayAddFilePayDocDate),
							Data = false,
							Status = ServiceResultStatus.Fail
						};
					}
					FOMobspSelectOrderWithId_Result fOMobspSelectOrderWithId_Result = Enumerable.FirstOrDefault<FOMobspSelectOrderWithId_Result>((IEnumerable<FOMobspSelectOrderWithId_Result>)cRMSpEntities.FOMobspSelectOrderWithId(model.OrderId, num, defLangId, model.CenterId));
					if (fOMobspSelectOrderWithId_Result != null)
					{
						int result2 = 0;
						_ = fOMobspSelectOrderWithId_Result.ordNumber;
						_ = fOMobspSelectOrderWithId_Result.ordCurrencyUnit;
						int.TryParse(fOMobspSelectOrderWithId_Result.ordReferUserId.ToString(), out result2);
						if (cRMSpEntities.FOMobspUpdateOrderPayment(model.OrderId, model.PayId, model.PayAmount, model.DocNumber, "", model.DocDate, model.PayAmount, string.IsNullOrWhiteSpace(model.DocDate) ? null : new DateTime?(value3), num2, value, registerDatePersian, id, value2, appType, num, defLangId) > 0)
						{
							string resourceString = MyResource.GetResourceString("FOVerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							string resourceString2 = MyResource.GetResourceString("FOPaymentMessageForOrd", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							List<FoCommonIMultiLanguageViewModel> list2 = new List<FoCommonIMultiLanguageViewModel>();
							List<FOMobspSelectLanguages_Result> list3 = Enumerable.ToList<FOMobspSelectLanguages_Result>(Enumerable.Where<FOMobspSelectLanguages_Result>((IEnumerable<FOMobspSelectLanguages_Result>)list, (Func<FOMobspSelectLanguages_Result, bool>)((FOMobspSelectLanguages_Result m) => m.LanguageID != defLangId)));
							if (list3 != null)
							{
								foreach (FOMobspSelectLanguages_Result item2 in list3)
								{
									_ = Enumerable.FirstOrDefault<FOMobspSelectOrderWithId_Result>((IEnumerable<FOMobspSelectOrderWithId_Result>)cRMSpEntities.FOMobspSelectOrderWithId(model.OrderId, item2.LanguageID, defLangId, model.CenterId))?.ordCurrencyUnit;
									string resourceString3 = MyResource.GetResourceString("FOVerifiedRequestSubject", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
									string resourceString4 = MyResource.GetResourceString("FOPaymentMessageForOrd", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
									FoCommonIMultiLanguageViewModel item = new FoCommonIMultiLanguageViewModel
									{
										Value = resourceString4,
										ValueI = (resourceString3 ?? resourceString),
										LanguageId = item2.LanguageID
									};
									list2.Add(item);
								}
							}
							if (result2 != 0)
							{
								string msgBody = ((!string.IsNullOrWhiteSpace(resourceString2)) ? resourceString2 : resourceString);
								SendInternalMessage(resourceString, msgBody, 8, num2, result2, model.OrderId, list2, model.CenterId);
							}
							message = Messages.MobMsgSuccessAction;
							data = true;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.FOMsgErrorDoneOperation;
							data = false;
							status = ServiceResultStatus.Error;
						}
					}
					else
					{
						message = Messages.FOMsgErrorNotFound;
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
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
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

	public void SendInternalMessage(string msgSubject, string msgBody, int msgdTypeId, int msgdFromUserId, int msgdToUserId, int msgdAttachRecId, List<FoCommonIMultiLanguageViewModel> lstMsg = null, int? cId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		new CRMEntities();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			now.AddSeconds(-7.0);
			_ = Messages.FOCnvsErjaShowText;
			string appType = Mobile.Classes.Configuration.AppType;
			short.Parse(now.ToString("yyyy", new PersianCulture()));
			DateTimeClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string msgdSendTime = now.ToString("HH:mm:ss");
			int value4 = -20;
			ObjectParameter objectParameter = new ObjectParameter("InternalMessageID", 0);
			if (msgBody.Length > 2000)
			{
				msgBody = msgBody.Substring(0, 2000);
			}
			cRMSpEntities.FOMobspInternalMessageSendSingle(null, msgSubject, msgBody, msgdTypeId, msgdFromUserId, msgdToUserId, text, msgdSendTime, value, null, null, msgdAttachRecId, null, null, value4, value2, value3, value, text, appType, objectParameter, result, null, null, cId);
			int num = 0;
			if (objectParameter.Value != null)
			{
				num = (int)objectParameter.Value;
			}
			if (num > 0)
			{
				if (lstMsg != null)
				{
					foreach (FoCommonIMultiLanguageViewModel item in lstMsg)
					{
						cRMSpEntities.FOMobspInsertInternalMessageLangByLangId(num, item.ValueI, item.Value ?? "", item.LanguageId);
					}
				}
				else
				{
					cRMSpEntities.FOMobspInsertInternalMessageLang(num, msgSubject, msgBody, result);
				}
			}
			PushNotif.NewIntMsgNotify();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}
}
