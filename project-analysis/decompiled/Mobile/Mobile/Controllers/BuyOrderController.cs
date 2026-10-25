using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class BuyOrderController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<BuyOrderDetailViewModel> SelectBuyOrderWithId(int bordId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		BuyOrderDetailViewModel buyOrderDetailViewModel = null;
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
					if (!UserLogin.IsUserAccess("frmMain", "actbordBuyOrder", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<BuyOrderDetailViewModel>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					MobspSelectBuyOrderWithID_Result mobspSelectBuyOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectBuyOrderWithID_Result>((IEnumerable<MobspSelectBuyOrderWithID_Result>)cRMEntities.MobspSelectBuyOrderWithID(bordId, token2.userId, result, result2));
					if (mobspSelectBuyOrderWithID_Result != null)
					{
						buyOrderDetailViewModel = new BuyOrderDetailViewModel();
						buyOrderDetailViewModel.BuyOrder = new MobspSelectBuyOrderWithID_Result();
						buyOrderDetailViewModel.BuyOrder = mobspSelectBuyOrderWithID_Result;
						buyOrderDetailViewModel.BuyOrderItems = new List<MobspSelectBuyOrderItems_Result>();
						buyOrderDetailViewModel.BuyOrderItemSerials = new List<MobspSelectBuyOrderItemSerials_Result>();
						List<MobspSelectBuyOrderItems_Result> list = Enumerable.ToList<MobspSelectBuyOrderItems_Result>((IEnumerable<MobspSelectBuyOrderItems_Result>)cRMEntities.MobspSelectBuyOrderItems(bordId, result, result2));
						if (Enumerable.Any<MobspSelectBuyOrderItems_Result>((IEnumerable<MobspSelectBuyOrderItems_Result>)list))
						{
							buyOrderDetailViewModel.BuyOrderItems = list;
							foreach (MobspSelectBuyOrderItems_Result item in list)
							{
								List<MobspSelectBuyOrderItemSerials_Result> list2 = Enumerable.ToList<MobspSelectBuyOrderItemSerials_Result>((IEnumerable<MobspSelectBuyOrderItemSerials_Result>)cRMEntities.MobspSelectBuyOrderItemSerials(item.BuyOrderItemId, result, result2));
								if (!Enumerable.Any<MobspSelectBuyOrderItemSerials_Result>((IEnumerable<MobspSelectBuyOrderItemSerials_Result>)list2))
								{
									continue;
								}
								foreach (MobspSelectBuyOrderItemSerials_Result item2 in list2)
								{
									buyOrderDetailViewModel.BuyOrderItemSerials.Add(item2);
								}
							}
						}
						buyOrderDetailViewModel.BuyOrderPayments = new List<MobspSelectBuyOrderPayments_Result>();
						List<MobspSelectBuyOrderPayments_Result> list3 = Enumerable.ToList<MobspSelectBuyOrderPayments_Result>((IEnumerable<MobspSelectBuyOrderPayments_Result>)cRMEntities.MobspSelectBuyOrderPayments(bordId, result, result2));
						if (Enumerable.Any<MobspSelectBuyOrderPayments_Result>((IEnumerable<MobspSelectBuyOrderPayments_Result>)list3))
						{
							buyOrderDetailViewModel.BuyOrderPayments = list3;
						}
						List<MobspSelectFilesDirectory_Result> list4 = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(mobspSelectBuyOrderWithID_Result.bordCompanyId.ToString(), "", mobspSelectBuyOrderWithID_Result.bordProjectId.ToString(), "30", bordId.ToString(), result, result2, false, cId));
						List<FileDirectoryViewModel> list5 = new List<FileDirectoryViewModel>();
						foreach (MobspSelectFilesDirectory_Result item3 in list4)
						{
							FileDirectoryViewModel fileDirectoryViewModel = new FileDirectoryViewModel();
							fileDirectoryViewModel.FileDirectoryID = item3.FileDirectoryID;
							fileDirectoryViewModel.FileDirectoryTypeId = item3.FileDirectoryTypeId.GetValueOrDefault();
							fileDirectoryViewModel.MasterId = item3.MasterId.GetValueOrDefault();
							fileDirectoryViewModel.DetailId = item3.DetailId.GetValueOrDefault();
							fileDirectoryViewModel.SubDetailId = item3.SubDetailId.GetValueOrDefault();
							fileDirectoryViewModel.TypeOprObjectId = item3.TypeOprObjectId.GetValueOrDefault();
							fileDirectoryViewModel.Title = item3.Title ?? "";
							fileDirectoryViewModel.FileName = item3.FileName ?? "";
							int result3 = 0;
							int.TryParse(item3.FileDirectoryID.ToString(), out result3);
							fileDirectoryViewModel.FilePath = "";
							fileDirectoryViewModel.DocDate = (item3.DocDateTime ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
							fileDirectoryViewModel.DocDatePersian = DateTimeClass.ConvertDateWoSlashToSlash(item3.DocDate);
							fileDirectoryViewModel.DocDay = item3.DocDay ?? "";
							fileDirectoryViewModel.DocDayPersian = (item3.DocDateTime ?? DateTime.Now).ToString("dddd", new PersianCulture());
							fileDirectoryViewModel.DocTime = item3.DocTime ?? "";
							fileDirectoryViewModel.FileDirectoryType = item3.FileDirectoryType ?? "";
							fileDirectoryViewModel.ProjectTitle = item3.prjTitle ?? "";
							fileDirectoryViewModel.CompanyName = "";
							fileDirectoryViewModel.FileDirectoryTypeOprId = item3.FileDirectoryTypeOprId.GetValueOrDefault();
							fileDirectoryViewModel.FileDirectoryTypeOpr = item3.FileDirectoryTypeOpr ?? "";
							fileDirectoryViewModel.otherFields = null;
							fileDirectoryViewModel.otherFieldsHeader = null;
							list5.Add(fileDirectoryViewModel);
						}
						buyOrderDetailViewModel.BuyOrderFiles = new List<FileDirectoryViewModel>();
						if (Enumerable.Any<FileDirectoryViewModel>((IEnumerable<FileDirectoryViewModel>)list5))
						{
							buyOrderDetailViewModel.BuyOrderFiles = list5;
						}
						buyOrderDetailViewModel.BuyOrderSumFooter = new MobfnReturnBuyOrderSumFooter_Result();
						MobfnReturnBuyOrderSumFooter_Result mobfnReturnBuyOrderSumFooter_Result = Queryable.FirstOrDefault<MobfnReturnBuyOrderSumFooter_Result>(cRMEntities.MobfnReturnBuyOrderSumFooter(bordId));
						if (mobfnReturnBuyOrderSumFooter_Result != null)
						{
							buyOrderDetailViewModel.BuyOrderSumFooter = mobfnReturnBuyOrderSumFooter_Result;
						}
						buyOrderDetailViewModel.SumBuyOrderPay = new MobspReturnSumBuyOrderPay_Result();
						MobspReturnSumBuyOrderPay_Result mobspReturnSumBuyOrderPay_Result = Enumerable.FirstOrDefault<MobspReturnSumBuyOrderPay_Result>((IEnumerable<MobspReturnSumBuyOrderPay_Result>)cRMEntities.MobspReturnSumBuyOrderPay(bordId));
						if (mobspReturnSumBuyOrderPay_Result != null)
						{
							buyOrderDetailViewModel.SumBuyOrderPay = mobspReturnSumBuyOrderPay_Result;
						}
						buyOrderDetailViewModel.DocForBuyOrder = new MobspReturnDocForBuyOrder_Result();
						MobspReturnDocForBuyOrder_Result mobspReturnDocForBuyOrder_Result = Enumerable.FirstOrDefault<MobspReturnDocForBuyOrder_Result>((IEnumerable<MobspReturnDocForBuyOrder_Result>)cRMEntities.MobspReturnDocForBuyOrder(bordId, result, result2));
						if (mobspReturnDocForBuyOrder_Result != null)
						{
							buyOrderDetailViewModel.DocForBuyOrder = mobspReturnDocForBuyOrder_Result;
						}
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorBuyOrderNotFound;
						buyOrderDetailViewModel = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					buyOrderDetailViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				buyOrderDetailViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			buyOrderDetailViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<BuyOrderDetailViewModel>
		{
			Message = message,
			Data = buyOrderDetailViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> BuyOrderVerify(int bordId, string registerDate, string registerTime, int? ln = null, int? cId = null)
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
					if (!UserLogin.IsUserAccess("frmBuyOrder", "actVerifyOrder", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = bordId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (bordId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorBuyOrderNotFound,
							Data = bordId,
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
								Data = bordId,
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
							Data = bordId,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					cRMEntities.MobspBuyOrderVerify(bordId, token2.userId, registerDate, now);
					data = bordId;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = bordId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = bordId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = bordId;
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

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> BuyOrderVerifyExit(int bordId, string registerDate, string registerTime, int? ln = null, int? cId = null)
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
					if (!UserLogin.IsUserAccess("frmBuyOrder", "actExitFromIsFix", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = bordId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (bordId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorBuyOrderNotFound,
							Data = bordId,
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
								Data = bordId,
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
							Data = bordId,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					cRMEntities.MobspBuyOrderVerifyExit(bordId, token2.userId, registerDate, now);
					data = bordId;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = bordId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = bordId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = bordId;
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
}
