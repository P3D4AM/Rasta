using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web;
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
using Mobile.Models.Product;

namespace Mobile.Controllers;

public class ProductController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProducts_Result>> SelectProducts(string lastDateUpdate, int? ln = null, int? LastPrdId = 0)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectProducts_Result> data = null;
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
					DateTime value;
					try
					{
						if (string.IsNullOrEmpty(lastDateUpdate))
						{
							ServiceResult<List<MobspSelectProducts_Result>> result3 = new ServiceResult<List<MobspSelectProducts_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						lastDateUpdate = lastDateUpdate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						value = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " 00:00:00"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspSelectProducts_Result>> result4 = new ServiceResult<List<MobspSelectProducts_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					data = Enumerable.ToList<MobspSelectProducts_Result>((IEnumerable<MobspSelectProducts_Result>)cRMEntities.MobspSelectProducts(value, result, result2, LastPrdId));
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
		return new ServiceResult<List<MobspSelectProducts_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProductSpecification_Result>> SelectProductSpecification(int? ln = null, string lastDateUpdate = null, string lastTimeUpdate = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectProductSpecification_Result> data = null;
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
					DateTime? registerDate = null;
					try
					{
						if (!string.IsNullOrEmpty(lastDateUpdate))
						{
							lastDateUpdate = lastDateUpdate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							if (string.IsNullOrEmpty(lastTimeUpdate))
							{
								lastTimeUpdate = "00:00:00";
							}
							registerDate = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate, new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate)));
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspSelectProductSpecification_Result>> result3 = new ServiceResult<List<MobspSelectProductSpecification_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					data = Enumerable.ToList<MobspSelectProductSpecification_Result>((IEnumerable<MobspSelectProductSpecification_Result>)cRMEntities.MobspSelectProductSpecification(registerDate, result, result2));
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
		return new ServiceResult<List<MobspSelectProductSpecification_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspCmpPrdBuyCostNearHistory_Result> CmpPrdBuyCostNearHistory(int companyId, int productId)
	{
		CRMEntities cRMEntities = null;
		MobspCmpPrdBuyCostNearHistory_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspCmpPrdBuyCostNearHistory_Result>((IEnumerable<MobspCmpPrdBuyCostNearHistory_Result>)cRMEntities.MobspCmpPrdBuyCostNearHistory(companyId, productId));
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
		return new ServiceResult<MobspCmpPrdBuyCostNearHistory_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<ProductValidQuantity> ReturnPrdQuantityAndValidCount(int prdId, int WHId, int currId, int currPordId, DateTime currDate, int? ln = null, float? FCR = null, float? FCRI = null, string tracing = null, int? cId = null, int currOrdItemId = 0)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		ProductValidQuantity productValidQuantity = null;
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
					short value = short.Parse(Financial.Get().Id.ToString());
					cRMEntities = new CRMEntities();
					CRMSpEntities cRMSpEntities = new CRMSpEntities();
					MobspReturnPrdQuantityAndValidCount_Result mobspReturnPrdQuantityAndValidCount_Result = Enumerable.FirstOrDefault<MobspReturnPrdQuantityAndValidCount_Result>((IEnumerable<MobspReturnPrdQuantityAndValidCount_Result>)cRMEntities.MobspReturnPrdQuantityAndValidCount(prdId, value, WHId, currId, currPordId, currDate, result, result2, FCR, FCRI, tracing, cId));
					productValidQuantity = new ProductValidQuantity
					{
						QuantityRemain = mobspReturnPrdQuantityAndValidCount_Result.QuantityRemain,
						QuantityIn = mobspReturnPrdQuantityAndValidCount_Result.QuantityIn,
						QuantityOut = mobspReturnPrdQuantityAndValidCount_Result.QuantityOut,
						PrdId = mobspReturnPrdQuantityAndValidCount_Result.PrdId,
						PrdName = mobspReturnPrdQuantityAndValidCount_Result.PrdName,
						RemainCount = mobspReturnPrdQuantityAndValidCount_Result.RemainCount,
						NetPreOrderCount = mobspReturnPrdQuantityAndValidCount_Result.NetPreOrderCount,
						RemainCountAllWH = mobspReturnPrdQuantityAndValidCount_Result.RemainCountAllWH,
						RemainCurrAndAll = mobspReturnPrdQuantityAndValidCount_Result.RemainCurrAndAll,
						ValidpordQuantity = mobspReturnPrdQuantityAndValidCount_Result.ValidpordQuantity,
						TracingRemainCount = mobspReturnPrdQuantityAndValidCount_Result.TracingRemainCount,
						ValidpordQuantityTotal = mobspReturnPrdQuantityAndValidCount_Result.ValidpordQuantityTotal
					};
					double result3 = 0.0;
					double result4 = 0.0;
					double result5 = 0.0;
					MobspReturnSoldOrdPrdCount_Result mobspReturnSoldOrdPrdCount_Result = Enumerable.FirstOrDefault<MobspReturnSoldOrdPrdCount_Result>((IEnumerable<MobspReturnSoldOrdPrdCount_Result>)cRMSpEntities.MobspReturnSoldOrdPrdCount(prdId, currOrdItemId, FCR, FCRI, WHId, tracing, cId));
					if (mobspReturnSoldOrdPrdCount_Result != null)
					{
						double.TryParse(mobspReturnSoldOrdPrdCount_Result.RemainOrdQty.ToString(), out result3);
						double.TryParse(mobspReturnSoldOrdPrdCount_Result.RemainOrdQtyTotal.ToString(), out result4);
					}
					productValidQuantity.SoldOrdPrdQuantity = result3;
					productValidQuantity.SoldOrdPrdQuantityTotal = result3 + "/" + result4;
					if (productValidQuantity.TracingRemainCount.HasValue)
					{
						double.TryParse(productValidQuantity.TracingRemainCount.ToString(), out result5);
					}
					productValidQuantity.RemainSoldOrdPrdQuantity = result5 - result3;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					productValidQuantity = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				productValidQuantity = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			productValidQuantity = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<ProductValidQuantity>
		{
			Message = message,
			Data = productValidQuantity,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<ProductTracingViewModel>> ReturnProductTracing(int prdId, int WHId, string masterFormName, int? cId = null, int currentItemId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		List<ProductTracingViewModel> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					short.Parse(Financial.Get().Id.ToString());
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					List<ProductTracingViewModel> list = new List<ProductTracingViewModel>();
					if ((masterFormName ?? "").ToLower() == "preorder" && UserLogin.IsUserAccess("frmPreOrder", "actCanNotVerifyNoStockFromShop", UserLogin.CurrentUser, cId))
					{
						List<MobspReturnProductTracingFromShop_Result> list2 = Enumerable.ToList<MobspReturnProductTracingFromShop_Result>((IEnumerable<MobspReturnProductTracingFromShop_Result>)cRMSpEntities.MobspReturnProductTracingFromShop(WHId, prdId, 0, currentItemId, 0, 0, cId, result, result2));
						if (list2 != null)
						{
							foreach (MobspReturnProductTracingFromShop_Result item in list2)
							{
								ProductTracingViewModel productTracingViewModel = new ProductTracingViewModel();
								productTracingViewModel.Tracing = item.Tracing;
								productTracingViewModel.PrdSHPRealStock = item.PrdSHPRealStock;
								list.Add(productTracingViewModel);
							}
						}
						data = list;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						foreach (MobspReturnProductTracing_Result item2 in Enumerable.ToList<MobspReturnProductTracing_Result>((IEnumerable<MobspReturnProductTracing_Result>)cRMEntities.MobspReturnProductTracing(prdId: prdId, wHId: WHId, centerId: cId)))
						{
							ProductTracingViewModel productTracingViewModel2 = new ProductTracingViewModel();
							productTracingViewModel2.Tracing = item2.Tracing;
							list.Add(productTracingViewModel2);
						}
						data = list;
						message = "";
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
		return new ServiceResult<List<ProductTracingViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspCmpPrdSalePriceHistory_Result>> CmpPrdSalePriceHistory(int companyId, int prdId, int mode)
	{
		CRMEntities cRMEntities = null;
		List<MobspCmpPrdSalePriceHistory_Result> data = null;
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
					data = Enumerable.ToList<MobspCmpPrdSalePriceHistory_Result>((IEnumerable<MobspCmpPrdSalePriceHistory_Result>)cRMEntities.MobspCmpPrdSalePriceHistory(companyId, prdId, mode));
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
		return new ServiceResult<List<MobspCmpPrdSalePriceHistory_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspPrdSalePriceHistory_Result> PrdSalePriceHistory(int prdId, int mode, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspPrdSalePriceHistory_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspPrdSalePriceHistory_Result>((IEnumerable<MobspPrdSalePriceHistory_Result>)cRMEntities.MobspPrdSalePriceHistory(prdId, mode, result, result2));
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
		return new ServiceResult<MobspPrdSalePriceHistory_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProductSecondGroup_Result>> SelectProductSecondGroup(int ShowMode, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectProductSecondGroup_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectProductSecondGroup_Result>((IEnumerable<MobspSelectProductSecondGroup_Result>)cRMEntities.MobspSelectProductSecondGroup(ShowMode, result, result2));
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
		return new ServiceResult<List<MobspSelectProductSecondGroup_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProductFirstGroup_Result>> SelectProductFirstGroup(int ShowMode, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectProductFirstGroup_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectProductFirstGroup_Result>((IEnumerable<MobspSelectProductFirstGroup_Result>)cRMEntities.MobspSelectProductFirstGroup(ShowMode, result, result2));
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
		return new ServiceResult<List<MobspSelectProductFirstGroup_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProductWithPriceByGroupId_Result>> SelectProductWithPriceByGroupId(int PrdGroupId, int firstGroupId, int prdPriceGroupId, string val, int PrdKind, int ShowMode, int CompanyId, int ProjectId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectProductWithPriceByGroupId_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectProductWithPriceByGroupId_Result>((IEnumerable<MobspSelectProductWithPriceByGroupId_Result>)cRMEntities.MobspSelectProductWithPriceByGroupId(PrdGroupId, firstGroupId, val, prdPriceGroupId, PrdKind, ShowMode, CompanyId, ProjectId, result, result2));
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
		return new ServiceResult<List<MobspSelectProductWithPriceByGroupId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectUserFavproductItemsWithPriceByUserId_Result>> SelectUserFavproductItemsWithPriceByUserId(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectUserFavproductItemsWithPriceByUserId_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectUserFavproductItemsWithPriceByUserId_Result>((IEnumerable<MobspSelectUserFavproductItemsWithPriceByUserId_Result>)cRMEntities.MobspSelectUserFavproductItemsWithPriceByUserId(token2.userId, result, result2));
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
		return new ServiceResult<List<MobspSelectUserFavproductItemsWithPriceByUserId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectProductWithPriceByPrdId_Result> SelectProductWithPriceByPrdId(int prdId, int prdPriceGroupId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectProductWithPriceByPrdId_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspSelectProductWithPriceByPrdId_Result>((IEnumerable<MobspSelectProductWithPriceByPrdId_Result>)cRMEntities.MobspSelectProductWithPriceByPrdId(prdId, prdPriceGroupId, result, result2));
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
		return new ServiceResult<MobspSelectProductWithPriceByPrdId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<SHPMobspSelectProductWithPriceByPrdId_Result> SHPSelectProductWithPriceByPrdId(int prdId, int? prdPriceGroupId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		SHPMobspSelectProductWithPriceByPrdId_Result data = null;
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
					data = Enumerable.FirstOrDefault<SHPMobspSelectProductWithPriceByPrdId_Result>((IEnumerable<SHPMobspSelectProductWithPriceByPrdId_Result>)cRMSpEntities.SHPMobspSelectProductWithPriceByPrdId(prdId, prdPriceGroupId, result, result2));
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
		return new ServiceResult<SHPMobspSelectProductWithPriceByPrdId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnProductPrice_Result> ReturnProductPrice(int prdId, int prdPriceGroupId, int destCurrencyUnitId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspReturnProductPrice_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspReturnProductPrice_Result>((IEnumerable<MobspReturnProductPrice_Result>)cRMEntities.MobspReturnProductPrice(prdId, prdPriceGroupId, destCurrencyUnitId: destCurrencyUnitId, languageID: result, defaultLanguageID: result2, centerId: cId));
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
		return new ServiceResult<MobspReturnProductPrice_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProductWithPrice_Result>> SelectProductWithPrice(string val, int PriceGroupId, int PrdKind, int ShowMode, int CompanyId, int ProjectId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectProductWithPrice_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectProductWithPrice_Result>((IEnumerable<MobspSelectProductWithPrice_Result>)cRMEntities.MobspSelectProductWithPrice(val, PriceGroupId, PrdKind, ShowMode, CompanyId, ProjectId, result, result2));
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
		return new ServiceResult<List<MobspSelectProductWithPrice_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnCurrencyUnitRate_Result> ReturnCurrencyUnitRate(int srcUnitId, int destUnitId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspReturnCurrencyUnitRate_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspReturnCurrencyUnitRate_Result>((IEnumerable<MobspReturnCurrencyUnitRate_Result>)cRMEntities.MobspReturnCurrencyUnitRate(srcUnitId, destUnitId));
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
		return new ServiceResult<MobspReturnCurrencyUnitRate_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnDraftItemQuantityByOrdItemId_Result> ReturnDraftItemQuantityByOrdItemId(int ordItemId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspReturnDraftItemQuantityByOrdItemId_Result data = null;
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
					short.Parse(Financial.Get().Id.ToString());
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<MobspReturnDraftItemQuantityByOrdItemId_Result>((IEnumerable<MobspReturnDraftItemQuantityByOrdItemId_Result>)cRMEntities.MobspReturnDraftItemQuantityByOrdItemId(ordItemId));
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
		return new ServiceResult<MobspReturnDraftItemQuantityByOrdItemId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnDocItemQuantityByBordItemId_Result> ReturnDocItemQuantityByBordItemId(int bordItemId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspReturnDocItemQuantityByBordItemId_Result data = null;
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
					short.Parse(Financial.Get().Id.ToString());
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<MobspReturnDocItemQuantityByBordItemId_Result>((IEnumerable<MobspReturnDocItemQuantityByBordItemId_Result>)cRMEntities.MobspReturnDocItemQuantityByBordItemId(bordItemId));
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
		return new ServiceResult<MobspReturnDocItemQuantityByBordItemId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnDraftItemQuantityByPordItemId_Result> ReturnDraftItemQuantityByPordItemId(int pordItemId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspReturnDraftItemQuantityByPordItemId_Result data = null;
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
					short.Parse(Financial.Get().Id.ToString());
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<MobspReturnDraftItemQuantityByPordItemId_Result>((IEnumerable<MobspReturnDraftItemQuantityByPordItemId_Result>)cRMEntities.MobspReturnDraftItemQuantityByPordItemId(pordItemId));
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
		return new ServiceResult<MobspReturnDraftItemQuantityByPordItemId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnBuyOrderItemQuantityByOrdItemId_Result> ReturnBuyOrderItemQuantityByOrdItemId(int orderItemId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		MobspReturnBuyOrderItemQuantityByOrdItemId_Result data = null;
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
					short.Parse(Financial.Get().Id.ToString());
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.FirstOrDefault<MobspReturnBuyOrderItemQuantityByOrdItemId_Result>((IEnumerable<MobspReturnBuyOrderItemQuantityByOrdItemId_Result>)cRMSpEntities.MobspReturnBuyOrderItemQuantityByOrdItemId(orderItemId));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<MobspReturnBuyOrderItemQuantityByOrdItemId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProductIssueOrdFromIndexedByPordId_Result>> GetProductIssueOrdFromIndexedByPordId(int pordId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectProductIssueOrdFromIndexedByPordId_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectProductIssueOrdFromIndexedByPordId_Result>((IEnumerable<MobspSelectProductIssueOrdFromIndexedByPordId_Result>)cRMSpEntities.MobspSelectProductIssueOrdFromIndexedByPordId(pordId, num, result2));
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
		return new ServiceResult<List<MobspSelectProductIssueOrdFromIndexedByPordId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProductOrdIssueByPordId_Result>> GetProductOrdIssueByPordId(int pordId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectProductOrdIssueByPordId_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectProductOrdIssueByPordId_Result>((IEnumerable<MobspSelectProductOrdIssueByPordId_Result>)cRMSpEntities.MobspSelectProductOrdIssueByPordId(pordId, num, result2));
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
		return new ServiceResult<List<MobspSelectProductOrdIssueByPordId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProductPriceGroupByPrdId_Result>> GetProductPriceGroupByPrdId(int prdId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectProductPriceGroupByPrdId_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectProductPriceGroupByPrdId_Result>((IEnumerable<MobspSelectProductPriceGroupByPrdId_Result>)cRMSpEntities.MobspSelectProductPriceGroupByPrdId(prdId, num, result2, cId));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectProductPriceGroupByPrdId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnProductCostByPrdId_Result> ReturnProductCostByPrdId(int prdId, int prdCostGroupId, int destCurrencyUnitId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		MobspReturnProductCostByPrdId_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspReturnProductCostByPrdId_Result>((IEnumerable<MobspReturnProductCostByPrdId_Result>)cRMSpEntities.MobspReturnProductCostByPrdId(prdId, prdCostGroupId, destCurrencyUnitId: destCurrencyUnitId, languageID: result, defaultLanguageID: result2));
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
		return new ServiceResult<MobspReturnProductCostByPrdId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspReturnPrdQuantityByIds_Result>> GetProductQuantityByIds(string prdId, int cmpId, int? ln = null, int? cId = null, int? foSettingId = null, bool? fromAllCenter = true)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		CRMEntities cRMEntities = null;
		List<SHPMobspReturnPrdQuantityByIds_Result> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					bool result3 = false;
					int result4 = 0;
					MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)cRMEntities.MobspSelectCrmsysSetting(defaultLanguageID: result2, languageID: result));
					if (mobspSelectCrmsysSetting_Result != null)
					{
						bool.TryParse(mobspSelectCrmsysSetting_Result.InvStockFromLink.ToString(), out result3);
						int.TryParse(mobspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result4);
					}
					List<SHPMobspReturnPrdQuantityByIds_Result> list = Enumerable.ToList<SHPMobspReturnPrdQuantityByIds_Result>((IEnumerable<SHPMobspReturnPrdQuantityByIds_Result>)cRMSpEntities.SHPMobspReturnPrdQuantityByIds(prdId, null, result3, null, result, result2, cId, foSettingId, fromAllCenter));
					if (list != null)
					{
						data = list;
						message = "";
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
			cRMSpEntities?.Dispose();
			if (cRMEntities != null)
			{
				Dispose();
			}
		}
		return new ServiceResult<List<SHPMobspReturnPrdQuantityByIds_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectSaleCentersWithIds_Result>> GetSaleCentersWithPrdIds(string ids = "", int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		CRMEntities cRMEntities = null;
		List<MobspSelectSaleCentersWithIds_Result> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					List<MobspSelectProductsWithIds_Result> list = Enumerable.ToList<MobspSelectProductsWithIds_Result>((IEnumerable<MobspSelectProductsWithIds_Result>)cRMSpEntities.MobspSelectProductsWithIds(ids, ",", result, result2));
					if (list != null)
					{
						string text = "";
						foreach (MobspSelectProductsWithIds_Result item in list)
						{
							if (!string.IsNullOrWhiteSpace(item.PrdSaleCenterIds))
							{
								if (text != "")
								{
									text += ",";
								}
								text += item.PrdSaleCenterIds;
							}
						}
						List<MobspSelectSaleCentersWithIds_Result> list2 = Enumerable.ToList<MobspSelectSaleCentersWithIds_Result>((IEnumerable<MobspSelectSaleCentersWithIds_Result>)cRMSpEntities.MobspSelectSaleCentersWithIds(text, result, result2));
						if (list2 != null)
						{
							data = list2;
							message = "";
							status = ServiceResultStatus.Success;
						}
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
			cRMSpEntities?.Dispose();
			if (cRMEntities != null)
			{
				Dispose();
			}
		}
		return new ServiceResult<List<MobspSelectSaleCentersWithIds_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int?> GetOrdDoneTimeSum(int id, int detailId)
	{
		CRMSpEntities cRMSpEntities = null;
		int? data = null;
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
					MobspReturnOrderItemsDoneTimeSum_Result mobspReturnOrderItemsDoneTimeSum_Result = Enumerable.FirstOrDefault<MobspReturnOrderItemsDoneTimeSum_Result>((IEnumerable<MobspReturnOrderItemsDoneTimeSum_Result>)cRMSpEntities.MobspReturnOrderItemsDoneTimeSum(id, detailId));
					if (mobspReturnOrderItemsDoneTimeSum_Result != null)
					{
						data = mobspReturnOrderItemsDoneTimeSum_Result.DoneTimeMinSum;
						message = "";
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectOrderItemsSaleCenterDelivery_Result>> GetOrderItemsSaleCenterDelivery(string dt = "", int? orderId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var _);
		CRMSpEntities cRMSpEntities = null;
		CRMEntities cRMEntities = null;
		List<MobspSelectOrderItemsSaleCenterDelivery_Result> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					dt = HttpUtility.UrlDecode(dt);
					DateTime value = default(DateTime);
					string text = "";
					try
					{
						text = PersianDate.GetFormatetdDate(dt.Replace("/", ""));
						switch (result)
						{
						case 1065:
							value = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							dt = value.ToString("yyyyMMdd");
							break;
						case 1025:
							value = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							dt = value.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							value = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							dt = value.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						message = Messages.WrongDateTime;
						data = null;
						status = ServiceResultStatus.Error;
					}
					List<MobspSelectOrderItemsSaleCenterDelivery_Result> list = Enumerable.ToList<MobspSelectOrderItemsSaleCenterDelivery_Result>((IEnumerable<MobspSelectOrderItemsSaleCenterDelivery_Result>)cRMSpEntities.MobspSelectOrderItemsSaleCenterDelivery(value, orderId));
					if (list != null)
					{
						data = list;
						message = "";
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
			if (cRMEntities != null)
			{
				Dispose();
			}
		}
		return new ServiceResult<List<MobspSelectOrderItemsSaleCenterDelivery_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspSelectSaleCentersWithIds_Result>> GetShopSaleCentersWithPrdIds(string ids = "", int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		CRMEntities cRMEntities = null;
		List<SHPMobspSelectSaleCentersWithIds_Result> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					List<SHPMobspSelectProductsWithIds_Result> list = Enumerable.ToList<SHPMobspSelectProductsWithIds_Result>((IEnumerable<SHPMobspSelectProductsWithIds_Result>)cRMSpEntities.SHPMobspSelectProductsWithIds(ids, ",", result, result2));
					if (list != null)
					{
						string text = "";
						foreach (SHPMobspSelectProductsWithIds_Result item in list)
						{
							if (!string.IsNullOrWhiteSpace(item.PrdSaleCenterIds))
							{
								if (text != "")
								{
									text += ",";
								}
								text += item.PrdSaleCenterIds;
							}
							item.PrdSGroupName = item.SGSHPName ?? item.PrdSGroupName;
							item.PrdFGroupName = item.FGSHPName ?? item.PrdFGroupName;
						}
						List<SHPMobspSelectSaleCentersWithIds_Result> list2 = Enumerable.ToList<SHPMobspSelectSaleCentersWithIds_Result>((IEnumerable<SHPMobspSelectSaleCentersWithIds_Result>)cRMSpEntities.SHPMobspSelectSaleCentersWithIds(text, result, result2));
						if (list2 != null)
						{
							data = list2;
							message = "";
							status = ServiceResultStatus.Success;
						}
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
			cRMSpEntities?.Dispose();
			if (cRMEntities != null)
			{
				Dispose();
			}
		}
		return new ServiceResult<List<SHPMobspSelectSaleCentersWithIds_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspSelectOrderItemsSaleCenterDelivery_Result>> GetShopOrderItemsSaleCenterDelivery(string dt = "", int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var _);
		CRMSpEntities cRMSpEntities = null;
		CRMEntities cRMEntities = null;
		List<SHPMobspSelectOrderItemsSaleCenterDelivery_Result> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					dt = HttpUtility.UrlDecode(dt);
					DateTime value = default(DateTime);
					string text = "";
					try
					{
						text = PersianDate.GetFormatetdDate(dt.Replace("/", ""));
						switch (result)
						{
						case 1065:
							value = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							dt = value.ToString("yyyyMMdd");
							break;
						case 1025:
							value = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							dt = value.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							value = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							dt = value.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						message = Messages.WrongDateTime;
						data = null;
						status = ServiceResultStatus.Error;
					}
					List<SHPMobspSelectOrderItemsSaleCenterDelivery_Result> list = Enumerable.ToList<SHPMobspSelectOrderItemsSaleCenterDelivery_Result>((IEnumerable<SHPMobspSelectOrderItemsSaleCenterDelivery_Result>)cRMSpEntities.SHPMobspSelectOrderItemsSaleCenterDelivery(value));
					if (list != null)
					{
						data = list;
						message = "";
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
			if (cRMEntities != null)
			{
				Dispose();
			}
		}
		return new ServiceResult<List<SHPMobspSelectOrderItemsSaleCenterDelivery_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<decimal?> AutoCalcProductPrice(int masterId, int type, int prdId)
	{
		CRMSpEntities cRMSpEntities = null;
		decimal? data = null;
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
					ObjectParameter objectParameter = new ObjectParameter("price", typeof(decimal));
					decimal result = default(decimal);
					switch (type)
					{
					case 1:
						cRMSpEntities.MobspAutoCalcPreOrderItemPrice(masterId, prdId, objectParameter);
						break;
					case 2:
						cRMSpEntities.MobspAutoCalcOrderItemPrice(masterId, prdId, objectParameter);
						break;
					}
					if (objectParameter != null && objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
					{
						decimal.TryParse(objectParameter.Value.ToString(), out result);
					}
					data = result;
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
		return new ServiceResult<decimal?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSearchProducts_Result>> SearchProDucts(ProductSearchViewModel model)
	{
		int result = 1065;
		if (model.Ln.HasValue)
		{
			int.TryParse(model.Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSearchProducts_Result> data = null;
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
					data = Enumerable.ToList<MobspSearchProducts_Result>(Enumerable.Take<MobspSearchProducts_Result>((IEnumerable<MobspSearchProducts_Result>)cRMSpEntities.MobspSearchProducts(model.FGId, model.SGId, model.BarCode, model.Val, model.PrdId, model.ShowMode, num, result2, model.PrdKind, model.PrdInActive, model.CompanyId, model.ProjectId, prdManufacturerName: model.PrdManufacturerName, prdSpecificationsJs: model.PrdSpecificationsJs, sGName: model.SGName), 100));
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
		return new ServiceResult<List<MobspSearchProducts_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectLinkAccSettingDB_Result>> GetLinkAccSettingDBIdList(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectLinkAccSettingDB_Result> data = null;
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
					int result3 = 0;
					if (SysSeting.Get() != null)
					{
						int.TryParse(SysSeting.Get().LinkAccSystemId.ToString(), out result3);
					}
					if (result3 == 4)
					{
						data = Enumerable.ToList<MobspSelectLinkAccSettingDB_Result>((IEnumerable<MobspSelectLinkAccSettingDB_Result>)cRMSpEntities.MobspSelectLinkAccSettingDB(4, 0, 0, 0));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectLinkAccSettingDB_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> CopyTmpProducts(string Type, int masterId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		DateTime now = DateTime.Now;
		string firstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short.Parse(now.ToString("MM", new PersianCulture()));
		short.Parse(Financial.Get().Id.ToString());
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				cRMSpEntities = new CRMSpEntities();
				data = ((cRMSpEntities.MobspTmpUserItemCopy(Type, masterId, UserLogin.CurrentUser.UserId, Mobile.Classes.Configuration.AppType, result2, firstRegisterDatePersian) > 0) ? "1" : Messages.msgErrorRunFunction);
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspTmpUserItemPast_Result>> PastTmpProducts(string Type, int masterId, int? cId = null, int? prdCurrencyId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspTmpUserItemPast_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		DateTime now = DateTime.Now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short value = short.Parse(now.ToString("MM", new PersianCulture()));
		short value2 = short.Parse(Financial.Get().Id.ToString());
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				cRMSpEntities = new CRMSpEntities();
				data = Enumerable.ToList<MobspTmpUserItemPast_Result>((IEnumerable<MobspTmpUserItemPast_Result>)cRMSpEntities.MobspTmpUserItemPast(Type, masterId, UserLogin.CurrentUser.UserId, value2, value, registerDatePersian, Mobile.Classes.Configuration.AppType, result2, cId, prdCurrencyId));
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
		return new ServiceResult<List<MobspTmpUserItemPast_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobSpSelectProductPriceByIds_Result>> GetProductPriceByIds(string prdIds, string seprator, int? cId = null, int? cmpId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobSpSelectProductPriceByIds_Result> data = null;
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
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? languageID = result;
					int? defaultLanguageID = result2;
					data = Enumerable.ToList<MobSpSelectProductPriceByIds_Result>((IEnumerable<MobSpSelectProductPriceByIds_Result>)cRMSpEntities2.MobSpSelectProductPriceByIds(prdIds, seprator, cmpId, languageID, defaultLanguageID, cId));
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
		return new ServiceResult<List<MobSpSelectProductPriceByIds_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspReturnPrdQuantity_Result>> GetShpLinkAccProductQuantityByIds(string prdIds, int whId, int cmpId, string linkAccWhId = "", string tracing = "", int? cId = null, int? foSettingId = null, bool? fromAllCenter = true, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		CRMSpEntities cRMSpEntities = null;
		List<SHPMobspReturnPrdQuantity_Result> list = null;
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
					list = new List<SHPMobspReturnPrdQuantity_Result>();
					foreach (string item in Enumerable.ToList<string>((IEnumerable<string>)prdIds.Split(new char[1] { ',' })))
					{
						int result3 = 0;
						int.TryParse(item, out result3);
						string text = "";
						string wcf = Enumerable.FirstOrDefault<string>((IEnumerable<string>)base.Request.RequestUri.ToString().Split(new string[1] { "/api" }, StringSplitOptions.None));
						ServiceResult<string> prdQuantityById = OtherSystems.GetPrdQuantityById(base.Request.Headers, wcf, item, cmpId, whId, num, linkAccWhId, tracing);
						if (prdQuantityById.Status == ServiceResultStatus.Success)
						{
							if (!string.IsNullOrEmpty(text))
							{
								text = prdQuantityById.Data;
							}
							double result4 = 0.0;
							if (!string.IsNullOrEmpty(text))
							{
								if (text == Labels.frmError)
								{
									text = "0";
								}
								if (text != Labels.frmError)
								{
									double.TryParse(text, out result4);
								}
							}
							SHPMobspReturnPrdQuantity_Result sHPMobspReturnPrdQuantity_Result = Enumerable.FirstOrDefault<SHPMobspReturnPrdQuantity_Result>((IEnumerable<SHPMobspReturnPrdQuantity_Result>)cRMSpEntities.SHPMobspReturnPrdQuantity(result3, result4, result, result2, cId, foSettingId, whId, tracing));
							if (sHPMobspReturnPrdQuantity_Result != null)
							{
								list.Add(sHPMobspReturnPrdQuantity_Result);
								continue;
							}
							return new ServiceResult<List<SHPMobspReturnPrdQuantity_Result>>
							{
								Message = Messages.MobMsgErrorDoneOperation,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						return new ServiceResult<List<SHPMobspReturnPrdQuantity_Result>>
						{
							Message = prdQuantityById.Message,
							Data = null,
							Status = prdQuantityById.Status
						};
					}
					message = null;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<SHPMobspReturnPrdQuantity_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnSoldOrdPrdCount_Result> ReturnSoldOrdPrdCount(int prdId, int WhId, double? fcr = null, double? fcrI = null, string Tracing = null, int CurrOrdItemId = 0, int? centerId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		CRMSpEntities cRMSpEntities = null;
		MobspReturnSoldOrdPrdCount_Result data = null;
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
					data = new MobspReturnSoldOrdPrdCount_Result();
					data = Enumerable.FirstOrDefault<MobspReturnSoldOrdPrdCount_Result>((IEnumerable<MobspReturnSoldOrdPrdCount_Result>)cRMSpEntities.MobspReturnSoldOrdPrdCount(prdId, CurrOrdItemId, fcr, fcrI, WhId, Tracing, centerId));
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
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<MobspReturnSoldOrdPrdCount_Result>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}
}
