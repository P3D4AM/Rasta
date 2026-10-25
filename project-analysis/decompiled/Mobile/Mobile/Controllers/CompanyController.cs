using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
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

public class CompanyController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspMainSearchSmart_Result>> SearchSmart(string value, int? pageNumber = 1, int? pageSize = 10, int? cId = null, int? ln = null, int searchType = 1, string searchConditionMode = "")
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspMainSearchSmart_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			_ = Labels.MobPersonLabel;
			if (!UserLogin.IsUserAccess("frmMain", "actcSerach", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspMainSearchSmart_Result>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<List<MobspMainSearchSmart_Result>>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMSpEntities = new CRMSpEntities();
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? userID = token2.userId;
					int? searchType2 = searchType;
					int? languageID = result;
					int? defaultLanguageID = result2;
					int? pageNumber2 = pageNumber;
					data = Enumerable.ToList<MobspMainSearchSmart_Result>((IEnumerable<MobspMainSearchSmart_Result>)cRMSpEntities2.MobspMainSearchSmart(value, userID, searchType2, languageID, defaultLanguageID, searchConditionMode, cId, pageNumber2, pageSize));
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
		return new ServiceResult<List<MobspMainSearchSmart_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<mct_MobspSearchCompany_Result>> Search(string type, string value, int? pageNumber = 1, int? pageSize = 10, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<mct_MobspSearchCompany_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			string mobPersonLabel = Labels.MobPersonLabel;
			if (!UserLogin.IsUserAccess("frmMain", "actcSerach", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<mct_MobspSearchCompany_Result>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<List<mct_MobspSearchCompany_Result>>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					type = type.ToLower();
					List<mct_MobspSearchCompany_Result> list = new List<mct_MobspSearchCompany_Result>();
					if (!(type == "name"))
					{
						if (type == "multi")
						{
							CRMEntities cRMEntities2 = cRMEntities;
							string text = value;
							int? userId = token2.userId;
							string val = text;
							int? languageID = result;
							int? defaultLanguageID = result2;
							int? pageNumber2 = pageNumber;
							int? pageSize2 = pageSize;
							list = Enumerable.ToList<mct_MobspSearchCompany_Result>((IEnumerable<mct_MobspSearchCompany_Result>)cRMEntities2.MobspSearchCompany(userId, val, languageID, defaultLanguageID, mobPersonLabel, pageNumber2, pageSize2, cId));
						}
					}
					else
					{
						CRMEntities cRMEntities3 = cRMEntities;
						string text = value;
						int? userId2 = token2.userId;
						string name = text;
						int? languageID2 = result;
						int? defaultLanguageID2 = result2;
						int? pageSize2 = pageNumber;
						int? pageNumber2 = pageSize;
						list = Enumerable.ToList<mct_MobspSearchCompany_Result>((IEnumerable<mct_MobspSearchCompany_Result>)cRMEntities3.MobspSearchCompanyWithName(userId2, name, languageID2, defaultLanguageID2, mobPersonLabel, pageSize2, pageNumber2, cId));
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
		}
		return new ServiceResult<List<mct_MobspSearchCompany_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SearchCompanyQuickViewModel>> SearchCompanyQuick(string value, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<SearchCompanyQuickViewModel> data = null;
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
					data = Enumerable.ToList<SearchCompanyQuickViewModel>(Enumerable.Select<mct_MobspSearchCompanyQuick_Result, SearchCompanyQuickViewModel>((IEnumerable<mct_MobspSearchCompanyQuick_Result>)Enumerable.ToList<mct_MobspSearchCompanyQuick_Result>((IEnumerable<mct_MobspSearchCompanyQuick_Result>)cRMEntities.MobspSearchCompanyQuick(value, token2.userId, result, result2, cId)), (Func<mct_MobspSearchCompanyQuick_Result, SearchCompanyQuickViewModel>)((mct_MobspSearchCompanyQuick_Result item) => new SearchCompanyQuickViewModel
					{
						Company = (item.CompanyPerson ?? ""),
						CompanyId = item.CompanyID.GetValueOrDefault(),
						CompanyName = (item.CompanyName ?? ""),
						CompanyPersonID = item.CompanyPersonID,
						cmpGroupIdII = item.cmpGroupIdII,
						cmpReferUserId = item.cmpReferUserId,
						cmpReferUser = item.cmpReferUser
					})));
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
		return new ServiceResult<List<SearchCompanyQuickViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SearchQuickCompanyViewModel>> SearchQuickCompany(string value, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<SearchQuickCompanyViewModel> data = null;
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
					data = Enumerable.ToList<SearchQuickCompanyViewModel>(Enumerable.Select<mct_MobspSearchQuickCompany_Result, SearchQuickCompanyViewModel>((IEnumerable<mct_MobspSearchQuickCompany_Result>)Enumerable.ToList<mct_MobspSearchQuickCompany_Result>((IEnumerable<mct_MobspSearchQuickCompany_Result>)cRMEntities.mfi_MobspSearchQuickCompany(value, token2.userId, result, result2, cId)), (Func<mct_MobspSearchQuickCompany_Result, SearchQuickCompanyViewModel>)((mct_MobspSearchQuickCompany_Result item) => new SearchQuickCompanyViewModel
					{
						CompanyId = item.CompanyID.GetValueOrDefault(),
						CompanyName = (item.cmpName ?? ""),
						CompanyPerson = (item.CompanyPerson ?? ""),
						CompanyGroupIIRate = item.CompanyGroupIIRate,
						CompanyAddress = (item.cmpAddress ?? "")
					})));
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
		return new ServiceResult<List<SearchQuickCompanyViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<mct_MobspSelectCompanyWithID_Result> Detail(int cmpid, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		mct_MobspSelectCompanyWithID_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<mct_MobspSelectCompanyWithID_Result>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<mct_MobspSelectCompanyWithID_Result>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					mct_MobspSelectCompanyWithID_Result mct_MobspSelectCompanyWithID_Result = Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)Enumerable.ToList<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)cRMEntities.MobspSelectCompanyWithID(cmpid, token2.userId, result, result2, cId)));
					if (mct_MobspSelectCompanyWithID_Result != null)
					{
						if (UserLogin.IsUserAccess("frmCompanyI", "actCanChangeReferUser", UserLogin.CurrentUser))
						{
							mct_MobspSelectCompanyWithID_Result.cmpReferUserId.GetValueOrDefault();
						}
						bool haveEroroFoCnt = false;
						mct_MobspSelectCompanyWithID_Result.cmpfoInfo = Company.GetFoInfoJson(mct_MobspSelectCompanyWithID_Result.cmpfoInfo ?? "", mct_MobspSelectCompanyWithID_Result.cmpfoInfo ?? "", mct_MobspSelectCompanyWithID_Result.cmpCIds ?? "", ref haveEroroFoCnt, 0, 0, isCmp: true, 0, mct_MobspSelectCompanyWithID_Result.cmpSuppUserId.GetValueOrDefault(), mct_MobspSelectCompanyWithID_Result.cmpReferUserId);
						if (haveEroroFoCnt)
						{
							int maxFOCount = Mobile.Classes.Configuration.MaxFOCount;
							message = string.Format(Messages.msgErrorSaveCmpFOIsActiveMoreThanMaxCount, maxFOCount.ToString()) + "<br>";
							data = null;
							status = ServiceResultStatus.Error;
						}
						data = mct_MobspSelectCompanyWithID_Result;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorCompanyNotFound;
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
		return new ServiceResult<mct_MobspSelectCompanyWithID_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<CompanyFullDetailsViewModel> FullDetails(int cmpId, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CompanyFullDetailsViewModel companyFullDetailsViewModel = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<CompanyFullDetailsViewModel>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<CompanyFullDetailsViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					companyFullDetailsViewModel = new CompanyFullDetailsViewModel();
					mct_MobspSelectCompanyWithID_Result mct_MobspSelectCompanyWithID_Result = Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)cRMEntities.MobspSelectCompanyWithID(cmpId, token2.userId, result, result2, cId));
					if (mct_MobspSelectCompanyWithID_Result != null)
					{
						if (UserLogin.IsUserAccess("frmCompanyI", "actCanChangeReferUser", UserLogin.CurrentUser))
						{
							mct_MobspSelectCompanyWithID_Result.cmpReferUserId.GetValueOrDefault();
						}
						bool haveEroroFoCnt = false;
						mct_MobspSelectCompanyWithID_Result.cmpfoInfo = Company.GetFoInfoJson(mct_MobspSelectCompanyWithID_Result.cmpfoInfo ?? "", mct_MobspSelectCompanyWithID_Result.cmpfoInfo ?? "", mct_MobspSelectCompanyWithID_Result.cmpCIds ?? "", ref haveEroroFoCnt, 0, 0, isCmp: true, 0, mct_MobspSelectCompanyWithID_Result.cmpSuppUserId.GetValueOrDefault(), mct_MobspSelectCompanyWithID_Result.cmpReferUserId);
						if (haveEroroFoCnt)
						{
							int maxFOCount = Mobile.Classes.Configuration.MaxFOCount;
							message = string.Format(Messages.msgErrorSaveCmpFOIsActiveMoreThanMaxCount, maxFOCount.ToString()) + "<br>";
							companyFullDetailsViewModel = null;
							status = ServiceResultStatus.Error;
						}
						companyFullDetailsViewModel.Company = mct_MobspSelectCompanyWithID_Result;
						companyFullDetailsViewModel.CompanyPersonList = new List<MobspSelectPersonList_Result>();
						companyFullDetailsViewModel.ProjectList = new List<MobspSelectProjectsList_Result>();
						companyFullDetailsViewModel.FileList = new List<MobspSelectFilesDirectory_Result>();
						List<MobspSelectPersonList_Result> list = Enumerable.ToList<MobspSelectPersonList_Result>((IEnumerable<MobspSelectPersonList_Result>)cRMEntities.MobspSelectPersonList(cmpId, token2.userId, result, result2, null, cId));
						if (Enumerable.Any<MobspSelectPersonList_Result>((IEnumerable<MobspSelectPersonList_Result>)list))
						{
							companyFullDetailsViewModel.CompanyPersonList = list;
						}
						List<MobspSelectProjectsList_Result> list2 = Enumerable.ToList<MobspSelectProjectsList_Result>((IEnumerable<MobspSelectProjectsList_Result>)cRMEntities.MobspSelectProjectsList(cmpId, 0, token2.userId, result, result2, cId));
						if (Enumerable.Any<MobspSelectProjectsList_Result>((IEnumerable<MobspSelectProjectsList_Result>)list2))
						{
							companyFullDetailsViewModel.ProjectList = list2;
						}
						List<MobspSelectFilesDirectory_Result> list3 = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)Enumerable.OrderBy<MobspSelectFilesDirectory_Result, int>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(cmpId.ToString(), "0", "0", "1", "0", result, result2, false, cId), (Func<MobspSelectFilesDirectory_Result, int>)((MobspSelectFilesDirectory_Result c) => c.FileDirectoryID)));
						if (Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list3))
						{
							companyFullDetailsViewModel.FileList = list3;
						}
						MobspReturnCmpAccountingSummary_Result mobspReturnCmpAccountingSummary_Result = Enumerable.FirstOrDefault<MobspReturnCmpAccountingSummary_Result>((IEnumerable<MobspReturnCmpAccountingSummary_Result>)cRMEntities.MobspReturnCmpAccountingSummary(cmpId));
						if (mobspReturnCmpAccountingSummary_Result != null)
						{
							CompanyAccountingSummaryViewModel companyAccountingSummaryViewModel = new CompanyAccountingSummaryViewModel();
							if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpBOrdAmnt", UserLogin.CurrentUser, cId))
							{
								if (mobspReturnCmpAccountingSummary_Result.AllBuyOrder.GetValueOrDefault() != 0m)
								{
									companyAccountingSummaryViewModel.AllBuyOrder = mobspReturnCmpAccountingSummary_Result.AllBuyOrdercnt + " " + Labels.MobCmpAccSummaryBuyOrder + " " + $"{mobspReturnCmpAccountingSummary_Result.AllBuyOrder:###,###,###,###}";
								}
								else
								{
									companyAccountingSummaryViewModel.AllBuyOrder = Labels.MobCmpAccSummaryBuyOrderNull;
								}
							}
							else
							{
								companyAccountingSummaryViewModel.AllBuyOrder = Labels.MobCmpAccSummaryBuyOrderNull;
							}
							if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpPreOrds", UserLogin.CurrentUser, cId))
							{
								if (mobspReturnCmpAccountingSummary_Result.AllPreOrdercnt.GetValueOrDefault() != 0)
								{
									companyAccountingSummaryViewModel.AllPreOrdercnt = mobspReturnCmpAccountingSummary_Result.AllPreOrdercnt + " " + Labels.MobCmpAccSummaryPreOrder + " " + $"{mobspReturnCmpAccountingSummary_Result.AllPreOrder:###,###,###,###}";
								}
								else
								{
									companyAccountingSummaryViewModel.AllPreOrdercnt = Labels.MobCmpAccSummaryPreOrderNull;
								}
							}
							else
							{
								companyAccountingSummaryViewModel.AllPreOrdercnt = Labels.MobCmpAccSummaryPreOrderNull1;
							}
							if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpOrdAmnt", UserLogin.CurrentUser, cId))
							{
								if (mobspReturnCmpAccountingSummary_Result.AllSaleOrdercnt.GetValueOrDefault() != 0)
								{
									companyAccountingSummaryViewModel.AllSaleOrder = mobspReturnCmpAccountingSummary_Result.AllSaleOrdercnt + " " + Labels.MobCmpAccSummaryOrder + " " + $"{mobspReturnCmpAccountingSummary_Result.AllSaleOrder:###,###,###,###}";
								}
								else
								{
									companyAccountingSummaryViewModel.AllSaleOrder = Labels.MobCmpAccSummaryOrderNull;
								}
							}
							else
							{
								companyAccountingSummaryViewModel.AllSaleOrder = Labels.MobCmpAccSummaryOrderNull;
							}
							if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpRetOrdAmnt", UserLogin.CurrentUser, cId))
							{
								if (mobspReturnCmpAccountingSummary_Result.AllRetOrdercnt.GetValueOrDefault() != 0)
								{
									companyAccountingSummaryViewModel.AllRetOrder = mobspReturnCmpAccountingSummary_Result.AllRetOrdercnt + " " + Labels.MobCmpAccSummaryRetOrder + " " + $"{mobspReturnCmpAccountingSummary_Result.AllRetOrder:###,###,###,###}";
								}
								else
								{
									companyAccountingSummaryViewModel.AllRetOrder = Labels.MobCmpAccSummaryRetOrderNull;
								}
							}
							else
							{
								companyAccountingSummaryViewModel.AllRetOrder = Labels.MobCmpAccSummaryRetOrderNull;
							}
							if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpOrdAmntPay", UserLogin.CurrentUser, cId))
							{
								if (mobspReturnCmpAccountingSummary_Result.AllSumPay.GetValueOrDefault() != 0m)
								{
									companyAccountingSummaryViewModel.AllSumPay = Labels.MobCmpAccSummaryPayment + " " + $"{mobspReturnCmpAccountingSummary_Result.AllSumPay:###,###,###,###}";
								}
								else
								{
									companyAccountingSummaryViewModel.AllSumPay = Labels.MobCmpAccSummaryPaymentNull;
								}
							}
							else
							{
								companyAccountingSummaryViewModel.AllSumPay = Labels.MobCmpAccSummaryPaymentNull;
							}
							if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpOrdRemain", UserLogin.CurrentUser, cId))
							{
								if (mobspReturnCmpAccountingSummary_Result.AllPayRemain.GetValueOrDefault() != 0m)
								{
									companyAccountingSummaryViewModel.AllPayRemain = Labels.MobCmpAccSummaryRemain + " " + $"{mobspReturnCmpAccountingSummary_Result.AllPayRemain:###,###,###,###}";
								}
								else
								{
									companyAccountingSummaryViewModel.AllPayRemain = Labels.MobCmpAccSummaryRemainNull;
								}
							}
							else
							{
								companyAccountingSummaryViewModel.AllPayRemain = Labels.MobCmpAccSummaryRemainNull;
							}
							companyFullDetailsViewModel.Financial = companyAccountingSummaryViewModel;
						}
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorCompanyNotFound;
						companyFullDetailsViewModel = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					companyFullDetailsViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				companyFullDetailsViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			companyFullDetailsViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<CompanyFullDetailsViewModel>
		{
			Message = message,
			Data = companyFullDetailsViewModel,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<MobspSelectCompanyByIdWithOutAccess_Result> DetailWithOutAccess(int cmpid, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectCompanyByIdWithOutAccess_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				cRMEntities = new CRMEntities();
				MobspSelectCompanyByIdWithOutAccess_Result mobspSelectCompanyByIdWithOutAccess_Result = Enumerable.FirstOrDefault<MobspSelectCompanyByIdWithOutAccess_Result>((IEnumerable<MobspSelectCompanyByIdWithOutAccess_Result>)Enumerable.ToList<MobspSelectCompanyByIdWithOutAccess_Result>((IEnumerable<MobspSelectCompanyByIdWithOutAccess_Result>)cRMEntities.MobspSelectCompanyByIdWithOutAccess(cmpid, result, result2, cId)));
				if (mobspSelectCompanyByIdWithOutAccess_Result != null)
				{
					data = mobspSelectCompanyByIdWithOutAccess_Result;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorCompanyNotFound;
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
		return new ServiceResult<MobspSelectCompanyByIdWithOutAccess_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<CompanyAccountingSummaryViewModel> ReturnCmpAccountingSummary(int cmpid, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CompanyAccountingSummaryViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<CompanyAccountingSummaryViewModel>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					MobspReturnCmpAccountingSummary_Result mobspReturnCmpAccountingSummary_Result = Enumerable.FirstOrDefault<MobspReturnCmpAccountingSummary_Result>((IEnumerable<MobspReturnCmpAccountingSummary_Result>)cRMEntities.MobspReturnCmpAccountingSummary(cmpid));
					if (mobspReturnCmpAccountingSummary_Result != null)
					{
						CompanyAccountingSummaryViewModel companyAccountingSummaryViewModel = new CompanyAccountingSummaryViewModel();
						if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpBOrdAmnt", UserLogin.CurrentUser, cId))
						{
							if (mobspReturnCmpAccountingSummary_Result.AllBuyOrder.GetValueOrDefault() != 0m)
							{
								companyAccountingSummaryViewModel.AllBuyOrder = mobspReturnCmpAccountingSummary_Result.AllBuyOrdercnt + " " + Labels.MobCmpAccSummaryBuyOrder + " " + $"{mobspReturnCmpAccountingSummary_Result.AllBuyOrder:###,###,###,###}";
							}
							else
							{
								companyAccountingSummaryViewModel.AllBuyOrder = Labels.MobCmpAccSummaryBuyOrderNull;
							}
						}
						else
						{
							companyAccountingSummaryViewModel.AllBuyOrder = Labels.MobCmpAccSummaryBuyOrderNull;
						}
						if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpPreOrds", UserLogin.CurrentUser, cId))
						{
							if (mobspReturnCmpAccountingSummary_Result.AllPreOrdercnt.GetValueOrDefault() != 0)
							{
								companyAccountingSummaryViewModel.AllPreOrdercnt = mobspReturnCmpAccountingSummary_Result.AllPreOrdercnt + " " + Labels.MobCmpAccSummaryPreOrder + " " + mobspReturnCmpAccountingSummary_Result.AllPreOrdercnt;
							}
							else
							{
								companyAccountingSummaryViewModel.AllPreOrdercnt = Labels.MobCmpAccSummaryPreOrderNull;
							}
						}
						else
						{
							companyAccountingSummaryViewModel.AllPreOrdercnt = Labels.MobCmpAccSummaryPreOrderNull1;
						}
						if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpOrdAmnt", UserLogin.CurrentUser, cId))
						{
							if (mobspReturnCmpAccountingSummary_Result.AllSaleOrdercnt.GetValueOrDefault() != 0)
							{
								companyAccountingSummaryViewModel.AllSaleOrder = mobspReturnCmpAccountingSummary_Result.AllSaleOrdercnt + " " + Labels.MobCmpAccSummaryOrder + " " + $"{mobspReturnCmpAccountingSummary_Result.AllSaleOrder:###,###,###,###}";
							}
							else
							{
								companyAccountingSummaryViewModel.AllSaleOrder = Labels.MobCmpAccSummaryOrderNull;
							}
						}
						else
						{
							companyAccountingSummaryViewModel.AllSaleOrder = Labels.MobCmpAccSummaryOrderNull;
						}
						if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpRetOrdAmnt", UserLogin.CurrentUser, cId))
						{
							if (mobspReturnCmpAccountingSummary_Result.AllRetOrdercnt.GetValueOrDefault() != 0)
							{
								companyAccountingSummaryViewModel.AllRetOrder = mobspReturnCmpAccountingSummary_Result.AllRetOrdercnt + " " + Labels.MobCmpAccSummaryRetOrder + " " + $"{mobspReturnCmpAccountingSummary_Result.AllRetOrder:###,###,###,###}";
							}
							else
							{
								companyAccountingSummaryViewModel.AllRetOrder = Labels.MobCmpAccSummaryRetOrderNull;
							}
						}
						else
						{
							companyAccountingSummaryViewModel.AllRetOrder = Labels.MobCmpAccSummaryRetOrderNull;
						}
						if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpOrdAmntPay", UserLogin.CurrentUser, cId))
						{
							if (mobspReturnCmpAccountingSummary_Result.AllSumPay.GetValueOrDefault() != 0m)
							{
								companyAccountingSummaryViewModel.AllSumPay = Labels.MobCmpAccSummaryPayment + " " + $"{mobspReturnCmpAccountingSummary_Result.AllSumPay:###,###,###,###}";
							}
							else
							{
								companyAccountingSummaryViewModel.AllSumPay = Labels.MobCmpAccSummaryPaymentNull;
							}
						}
						else
						{
							companyAccountingSummaryViewModel.AllSumPay = Labels.MobCmpAccSummaryPaymentNull;
						}
						if (!UserLogin.IsUserAccess("frmCompanyI", "actNotShowcmpOrdRemain", UserLogin.CurrentUser, cId))
						{
							if (mobspReturnCmpAccountingSummary_Result.AllPayRemain.GetValueOrDefault() != 0m)
							{
								companyAccountingSummaryViewModel.AllPayRemain = Labels.MobCmpAccSummaryRemain + " " + $"{mobspReturnCmpAccountingSummary_Result.AllPayRemain:###,###,###,###}";
							}
							else
							{
								companyAccountingSummaryViewModel.AllPayRemain = Labels.MobCmpAccSummaryRemainNull;
							}
						}
						else
						{
							companyAccountingSummaryViewModel.AllPayRemain = Labels.MobCmpAccSummaryRemainNull;
						}
						data = companyAccountingSummaryViewModel;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrNotFound;
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
		return new ServiceResult<CompanyAccountingSummaryViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnCmpAccountingSummary_Result> ReturnRawCmpAccountingSummary(int cmpid, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspReturnCmpAccountingSummary_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<MobspReturnCmpAccountingSummary_Result>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<MobspReturnCmpAccountingSummary_Result>((IEnumerable<MobspReturnCmpAccountingSummary_Result>)cRMEntities.MobspReturnCmpAccountingSummary(cmpid));
					status = ServiceResultStatus.Success;
					message = Messages.MobMsgSuccessAction;
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
		return new ServiceResult<MobspReturnCmpAccountingSummary_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<CompanyViewModel> MoreInfo(int cmpid, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int num = 1065;
		CRMEntities cRMEntities = null;
		CompanyViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmCompanyI", "actDefineCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<CompanyViewModel>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					MobspSelectCompanyMoreInfo_Result mobspSelectCompanyMoreInfo_Result = Enumerable.FirstOrDefault<MobspSelectCompanyMoreInfo_Result>((IEnumerable<MobspSelectCompanyMoreInfo_Result>)Enumerable.ToList<MobspSelectCompanyMoreInfo_Result>((IEnumerable<MobspSelectCompanyMoreInfo_Result>)cRMEntities.MobspSelectCompanyMoreInfo(cmpid, token2.userId, result, num, cId)));
					if (mobspSelectCompanyMoreInfo_Result != null)
					{
						Dictionary<string, object> otherFields = Enumerable.ToDictionary<string[], string, object>(Enumerable.Select<string, string[]>((IEnumerable<string>)mobspSelectCompanyMoreInfo_Result.otherFields.Split(new string[1] { "@|$|@" }, StringSplitOptions.None), (Func<string, string[]>)((string oi) => oi.Split(new string[1] { "@^$|@" }, StringSplitOptions.None))), (Func<string[], string>)((string[] arrOi) => arrOi[0]), (Func<string[], object>)((string[] arrOi) => arrOi[1]));
						Dictionary<string, object> otherFieldsHeader = Enumerable.ToDictionary<string[], string, object>(Enumerable.Select<string, string[]>((IEnumerable<string>)mobspSelectCompanyMoreInfo_Result.otherFieldsHeader.Split(new string[1] { "@|$|@" }, StringSplitOptions.None), (Func<string, string[]>)((string oi) => oi.Split(new string[1] { "@^$|@" }, StringSplitOptions.None))), (Func<string[], string>)((string[] arrOi) => arrOi[0]), (Func<string[], object>)((string[] arrOi) => arrOi[1]));
						data = new CompanyViewModel
						{
							CompanyID = mobspSelectCompanyMoreInfo_Result.CompanyID,
							cmpNameFull = mobspSelectCompanyMoreInfo_Result.cmpNameFull,
							cmpNumber = mobspSelectCompanyMoreInfo_Result.cmpNumber,
							cmpReferUser = mobspSelectCompanyMoreInfo_Result.cmpReferUser,
							cmpTelFull = mobspSelectCompanyMoreInfo_Result.cmpTelFull,
							otherFields = otherFields,
							otherFieldsHeader = otherFieldsHeader,
							cmpCoordinateLatitude = "",
							cmpCoordinateLongitude = "",
							cmpCoordinateLastDate = "",
							cmpCoordinateLastTime = "",
							cmpCoordinateLastDatePersian = "",
							cmpCoordinateZoomLevel = 0,
							CountPage = 0
						};
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
		return new ServiceResult<CompanyViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<CompanyViewModel> Groups(int cmpid, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CompanyViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<CompanyViewModel>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			cRMEntities = new CRMEntities();
			MobspSelectCompanyWithIDForGroup_Result mobspSelectCompanyWithIDForGroup_Result = Enumerable.FirstOrDefault<MobspSelectCompanyWithIDForGroup_Result>((IEnumerable<MobspSelectCompanyWithIDForGroup_Result>)Enumerable.ToList<MobspSelectCompanyWithIDForGroup_Result>((IEnumerable<MobspSelectCompanyWithIDForGroup_Result>)cRMEntities.MobspSelectCompanyWithIDForGroup(cmpid, result, result2)));
			if (mobspSelectCompanyWithIDForGroup_Result != null)
			{
				List<CRMspSelectCompanyGroupsMulti_Result> list = Enumerable.ToList<CRMspSelectCompanyGroupsMulti_Result>((IEnumerable<CRMspSelectCompanyGroupsMulti_Result>)cRMEntities.CRMspSelectCompanyGroupsMulti(ln, ln));
				List<MultiGroupItem> list2 = new List<MultiGroupItem>();
				foreach (CRMspSelectCompanyGroupsMulti_Result item in list)
				{
					MultiGroupItem multiGroupItem = new MultiGroupItem
					{
						title = item.CompanyGroupsMultiName,
						ischeck = false
					};
					if (Enumerable.FirstOrDefault<CRMspCompanyCheckHaveMultiGroup_Result>((IEnumerable<CRMspCompanyCheckHaveMultiGroup_Result>)Enumerable.ToList<CRMspCompanyCheckHaveMultiGroup_Result>((IEnumerable<CRMspCompanyCheckHaveMultiGroup_Result>)cRMEntities.CRMspCompanyCheckHaveMultiGroup(cmpid, item.CompanyGroupsMultiID))) != null)
					{
						multiGroupItem.ischeck = true;
					}
					list2.Add(multiGroupItem);
				}
				Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
				foreach (MultiGroupItem item2 in list2)
				{
					if (!dictionary.ContainsKey(item2.title))
					{
						dictionary.Add(item2.title, item2.ischeck);
					}
				}
				Dictionary<string, object> dictionary2 = Enumerable.ToDictionary<string[], string, object>(Enumerable.Select<string, string[]>((IEnumerable<string>)mobspSelectCompanyWithIDForGroup_Result.otherFields.Split(new string[1] { "@|$|@" }, StringSplitOptions.None), (Func<string, string[]>)((string oi) => oi.Split(new string[1] { "@^$|@" }, StringSplitOptions.None))), (Func<string[], string>)((string[] arrOi) => arrOi[0]), (Func<string[], object>)((string[] arrOi) => arrOi[1]));
				dictionary2.Add("<40>" + Labels.MobGroupIdMultiTitle, dictionary);
				Dictionary<string, object> dictionary3 = Enumerable.ToDictionary<string[], string, object>(Enumerable.Select<string, string[]>((IEnumerable<string>)mobspSelectCompanyWithIDForGroup_Result.otherFieldsHeader.Split(new string[1] { "@|$|@" }, StringSplitOptions.None), (Func<string, string[]>)((string oi) => oi.Split(new string[1] { "@^$|@" }, StringSplitOptions.None))), (Func<string[], string>)((string[] arrOi) => arrOi[0]), (Func<string[], object>)((string[] arrOi) => arrOi[1]));
				dictionary3.Add("<40>" + Labels.MobGroupIdMultiTitle, dictionary);
				data = new CompanyViewModel
				{
					CompanyID = mobspSelectCompanyWithIDForGroup_Result.CompanyID,
					cmpNameFull = mobspSelectCompanyWithIDForGroup_Result.cmpNameFull,
					cmpNumber = mobspSelectCompanyWithIDForGroup_Result.cmpNumber,
					cmpReferUser = mobspSelectCompanyWithIDForGroup_Result.cmpReferUser,
					cmpTelFull = mobspSelectCompanyWithIDForGroup_Result.cmpTelFull,
					otherFields = dictionary2,
					otherFieldsHeader = dictionary3,
					cmpCoordinateLatitude = "",
					cmpCoordinateLongitude = "",
					cmpCoordinateLastDate = "",
					cmpCoordinateLastTime = "",
					cmpCoordinateLastDatePersian = "",
					cmpCoordinateZoomLevel = 0,
					CountPage = 0
				};
			}
			message = "";
			status = ServiceResultStatus.Success;
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
		return new ServiceResult<CompanyViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<UsersLocationAroundCompanyViewModel> SelectUsersCoordinateAroundCompany(int cmpid, int lastHours, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		UsersLocationAroundCompanyViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmCompanyI", "actShowUserLocationToCmpLocation", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<UsersLocationAroundCompanyViewModel>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (cmpid == 0)
			{
				ServiceResult<UsersLocationAroundCompanyViewModel> result3 = new ServiceResult<UsersLocationAroundCompanyViewModel>
				{
					Message = Messages.MobMsgErrorCompanyNotSelected,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
				cRMEntities?.Dispose();
				return result3;
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					mct_MobspSelectCompanyWithID_Result mct_MobspSelectCompanyWithID_Result = Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)Enumerable.ToList<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)cRMEntities.MobspSelectCompanyWithID(cmpid, token2.userId, result, result2, cId)));
					if (mct_MobspSelectCompanyWithID_Result != null)
					{
						List<MobspSelectUsersCoordinateAroundCompany_Result> usersCoordinate = Enumerable.ToList<MobspSelectUsersCoordinateAroundCompany_Result>((IEnumerable<MobspSelectUsersCoordinateAroundCompany_Result>)cRMEntities.MobspSelectUsersCoordinateAroundCompany(result, result2, lastHours, token2.userId, 7, cmpid, cId));
						data = new UsersLocationAroundCompanyViewModel
						{
							CompanyId = mct_MobspSelectCompanyWithID_Result.CompanyID,
							CompanyName = mct_MobspSelectCompanyWithID_Result.CompanyName,
							cmpCoordinateLatitude = mct_MobspSelectCompanyWithID_Result.cmpCoordinateLatitude,
							cmpCoordinateLongitude = mct_MobspSelectCompanyWithID_Result.cmpCoordinateLongitude,
							cmpCoordinateLastDate = mct_MobspSelectCompanyWithID_Result.cmpCoordinateLastDate,
							cmpCoordinateLastDatePersian = mct_MobspSelectCompanyWithID_Result.cmpCoordinateLastDatePersian,
							cmpCoordinateZoomLevel = mct_MobspSelectCompanyWithID_Result.cmpCoordinateZoomLevel.GetValueOrDefault(),
							UsersCoordinate = usersCoordinate
						};
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.CompanyNotFound;
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
		return new ServiceResult<UsersLocationAroundCompanyViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectFilesDirectory_Result>> ShowFiles(int cmpId, int prjId, bool isShowAllCmpFile, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectFilesDirectory_Result> data = null;
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
					if (cmpId > 0)
					{
						List<MobspSelectFilesDirectory_Result> list = new List<MobspSelectFilesDirectory_Result>();
						list = ((prjId <= 0) ? Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)Enumerable.OrderBy<MobspSelectFilesDirectory_Result, int>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(cmpId.ToString(), "0", "0", "1", "0", result, result2, isShowAllCmpFile, cId), (Func<MobspSelectFilesDirectory_Result, int>)((MobspSelectFilesDirectory_Result c) => c.FileDirectoryID))) : Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)Enumerable.OrderBy<MobspSelectFilesDirectory_Result, int>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(cmpId.ToString(), "0", prjId.ToString(), "1", "0", result, result2, false, cId), (Func<MobspSelectFilesDirectory_Result, int>)((MobspSelectFilesDirectory_Result c) => c.FileDirectoryID))));
						List<FileDirectoryViewModel> list2 = new List<FileDirectoryViewModel>();
						foreach (MobspSelectFilesDirectory_Result item in list)
						{
							FileDirectoryViewModel fileDirectoryViewModel = new FileDirectoryViewModel();
							fileDirectoryViewModel.FileDirectoryID = item.FileDirectoryID;
							fileDirectoryViewModel.FileDirectoryTypeId = item.FileDirectoryTypeId.GetValueOrDefault();
							fileDirectoryViewModel.MasterId = item.MasterId.GetValueOrDefault();
							fileDirectoryViewModel.DetailId = item.DetailId.GetValueOrDefault();
							fileDirectoryViewModel.SubDetailId = item.SubDetailId.GetValueOrDefault();
							fileDirectoryViewModel.TypeOprObjectId = item.TypeOprObjectId.GetValueOrDefault();
							fileDirectoryViewModel.Title = item.Title ?? "";
							fileDirectoryViewModel.FileName = item.FileName ?? "";
							int result3 = 0;
							int.TryParse(item.FileDirectoryID.ToString(), out result3);
							fileDirectoryViewModel.FilePath = "";
							fileDirectoryViewModel.DocDate = (item.DocDateTime ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
							fileDirectoryViewModel.DocDatePersian = DateTimeClass.ConvertDateWoSlashToSlash(item.DocDate);
							fileDirectoryViewModel.DocDay = item.DocDay ?? "";
							fileDirectoryViewModel.DocDayPersian = (item.DocDateTime ?? DateTime.Now).ToString("dddd", new PersianCulture());
							fileDirectoryViewModel.DocTime = item.DocTime ?? "";
							fileDirectoryViewModel.FileDirectoryType = item.FileDirectoryType ?? "";
							fileDirectoryViewModel.ProjectTitle = item.prjTitle ?? "";
							fileDirectoryViewModel.CompanyName = "";
							fileDirectoryViewModel.FileDirectoryTypeOprId = item.FileDirectoryTypeOprId.GetValueOrDefault();
							fileDirectoryViewModel.FileDirectoryTypeOpr = item.FileDirectoryTypeOpr ?? "";
							fileDirectoryViewModel.otherFields = null;
							fileDirectoryViewModel.otherFieldsHeader = null;
							list2.Add(fileDirectoryViewModel);
						}
						data = list;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorCompanyNotFound;
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
		return new ServiceResult<List<MobspSelectFilesDirectory_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> DraftCount(int userId)
	{
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		int data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspReturnCmpDraftCount(userId));
					if (num.HasValue)
					{
						data = num.GetValueOrDefault();
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorCompanyNotFound;
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

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspGetNotExistCompany_Result>> GetNotExistCompany(string allIds)
	{
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		List<MobspGetNotExistCompany_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					List<MobspGetNotExistCompany_Result> list = Enumerable.ToList<MobspGetNotExistCompany_Result>((IEnumerable<MobspGetNotExistCompany_Result>)cRMEntities.MobspGetNotExistCompany(allIds));
					if (list != null)
					{
						data = list;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorCompanyNotFound;
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
		return new ServiceResult<List<MobspGetNotExistCompany_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSearchCompanyWithAllFields_Result> SearchCompanyWithAllFields(string FieldName, string Value, int? cId = null)
	{
		CRMEntities cRMEntities = null;
		MobspSearchCompanyWithAllFields_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspSearchCompanyWithAllFields_Result>((IEnumerable<MobspSearchCompanyWithAllFields_Result>)cRMEntities.MobspSearchCompanyWithAllFields(FieldName, Value, cId));
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
		return new ServiceResult<MobspSearchCompanyWithAllFields_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel> InsertLinkCompanyByCmpNumber(int CompanyId, int LinkedCompanyId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertQuickCmpPrsPrjCnvsResultViewModel data = null;
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
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					_ = Labels.MobLackOfShowText;
					cRMEntities.MobspInsertLinkCompanyByCmpNumber(CompanyId, LinkedCompanyId, token2.userId, value2, value3, value, registerDatePersian, appType, result);
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
		return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnCmpAccountingDetails_Result>> ReturnCmpAccountingDetails(int cmpId, int? pageNumber = 1, int? pageSize = 10, int? cmpPersonId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspReturnCmpAccountingDetails_Result> data = null;
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
					string rptOrderTitle = Labels.RptOrderTitle;
					string rptPaymentTitle = Labels.RptPaymentTitle;
					string rptWastedTitle = Labels.RptWastedTitle;
					string rptBuyOrderTitle = Labels.RptBuyOrderTitle;
					string rptPreOrderTitle = Labels.RptPreOrderTitle;
					string rptSaleOrderTitle = Labels.RptSaleOrderTitle;
					int userId = UserLogin.CurrentUser.UserId;
					DateTime now = DateTime.Now;
					string rptDate = now.ToString("yyyy/MM/dd");
					string rptDay = now.ToString("dddd");
					cRMEntities = new CRMEntities();
					List<MobspReturnCmpAccountingDetails_Result> list = Enumerable.ToList<MobspReturnCmpAccountingDetails_Result>((IEnumerable<MobspReturnCmpAccountingDetails_Result>)cRMEntities.MobspReturnCmpAccountingDetails(cmpId, num, result2, rptOrderTitle, rptPaymentTitle, rptWastedTitle, rptBuyOrderTitle, rptPreOrderTitle, rptSaleOrderTitle, now, now, userId, rptDate, rptDay, pageNumber, pageSize, cmpPersonId));
					if (list != null)
					{
						data = list;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorCompanyNotFound;
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
		return new ServiceResult<List<MobspReturnCmpAccountingDetails_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspCheckDuplicateCompany_Result>> CheckDuplicateCompany(int type, int cmpId, string val, int titleId, int cityId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspCheckDuplicateCompany_Result> data = null;
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
					data = Enumerable.ToList<MobspCheckDuplicateCompany_Result>((IEnumerable<MobspCheckDuplicateCompany_Result>)cRMEntities.MobspCheckDuplicateCompany(type, cmpId, val, titleId, cityId, token2.userId, null, result, result2));
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
		return new ServiceResult<List<MobspCheckDuplicateCompany_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> CopyMainPersonDataToCmp(int cmpId, int prsId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
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
					if (!UserLogin.IsUserAccess("frmCompanyI", "actCopyMainPersonDataToCmp", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					MobspSelectPersonWithID_Result mobspSelectPersonWithID_Result = Enumerable.FirstOrDefault<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)Enumerable.ToList<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)cRMEntities.MobspSelectPersonWithID(prsId, result, result2)));
					if (mobspSelectPersonWithID_Result != null)
					{
						string text = mobspSelectPersonWithID_Result.prsMobile ?? "";
						if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrEmpty(text))
						{
							if (Thread.CurrentThread.CurrentCulture.LCID == 1065)
							{
								if (text.Length < 11)
								{
									return new ServiceResult<string>
									{
										Message = Messages.MobCheckLengthMobile,
										Data = null,
										Status = ServiceResultStatus.Fail
									};
								}
								if (!Regex.IsMatch(text, "09([0-9])\\d{8}"))
								{
									return new ServiceResult<string>
									{
										Message = string.Format(Messages.MobErrorInFormat, Labels.prsMobile),
										Data = null,
										Status = ServiceResultStatus.Fail
									};
								}
							}
							string text2 = CantSaveDupCmpMobile(text, cmpId);
							if (!string.IsNullOrEmpty(text2))
							{
								return new ServiceResult<string>
								{
									Message = text2,
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
						}
						string text3 = mobspSelectPersonWithID_Result.prsEmail ?? "";
						if (string.IsNullOrWhiteSpace(text3))
						{
							text3 = mobspSelectPersonWithID_Result.prsEmailII ?? "";
						}
						if (!string.IsNullOrWhiteSpace(text3))
						{
							if (!Regex.IsMatch(text3, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"))
							{
								return new ServiceResult<string>
								{
									Message = string.Format(Messages.MobErrorInFormat, Labels.prsEmail),
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
							string text4 = CantSaveDupCmpEmail(text3, cmpId);
							if (!string.IsNullOrEmpty(text4))
							{
								return new ServiceResult<string>
								{
									Message = text4,
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
						}
						if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text3))
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorCmpMainPersonNotMobOrEmailInTrasferMobAndEmail,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						DateTime now = DateTime.Now;
						DateTime value = now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						short value2 = short.Parse(Financial.Get().Id.ToString());
						short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						_ = Messages.MobConversationErjaShow;
						string appType = Mobile.Classes.Configuration.AppType;
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspCopyCompanyPersonDataToCmp(cmpId, prsId, token2.userId, value, registerDatePersian, value3, value2, appType));
						if (num.HasValue)
						{
							int result3 = 0;
							int.TryParse(num.ToString(), out result3);
							string text5 = "";
							switch (result3)
							{
							case -1:
								text5 = Messages.MobMsgErrorDupCmpMainPersonMobInTrasferMobAndEmail;
								break;
							case -2:
								text5 = Messages.MobMsgErrorDupCmpMainPersonEmailInTrasferMobAndEmail;
								break;
							case -3:
								text5 = Messages.MobMsgErrorDupCmpMainPersonEmailAndMobInTrasferMobAndEmail;
								break;
							}
							if (!string.IsNullOrWhiteSpace(text5))
							{
								data = null;
								message = text5;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								data = null;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
					}
					else
					{
						message = Messages.MobMsgErrorPersonNotFound;
						data = null;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public string CantSaveDupCmpEmail(string cmpEmail, int currentId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrEmpty(cmpEmail))
			{
				MobspCheckDuplicateCmpEmail_Result mobspCheckDuplicateCmpEmail_Result = Enumerable.FirstOrDefault<MobspCheckDuplicateCmpEmail_Result>((IEnumerable<MobspCheckDuplicateCmpEmail_Result>)new CRMEntities().MobspCheckDuplicateCmpEmail(cmpEmail, currentId, lCID, result2));
				if (mobspCheckDuplicateCmpEmail_Result != null)
				{
					result = string.Format(Messages.CheckDuplicateCmpEmail, mobspCheckDuplicateCmpEmail_Result.cmpNumber.ToString(), mobspCheckDuplicateCmpEmail_Result.CompanyName ?? "");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string CantSaveDupCmpMobile(string cmpMobile, int currentId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrEmpty(cmpMobile))
			{
				MobspCheckDuplicateCmpMobile_Result mobspCheckDuplicateCmpMobile_Result = Enumerable.FirstOrDefault<MobspCheckDuplicateCmpMobile_Result>((IEnumerable<MobspCheckDuplicateCmpMobile_Result>)new CRMEntities().MobspCheckDuplicateCmpMobile(cmpMobile, currentId, lCID, result2));
				if (mobspCheckDuplicateCmpMobile_Result != null)
				{
					result = string.Format(Messages.CheckDuplicateCmpMobile, mobspCheckDuplicateCmpMobile_Result.cmpNumber.ToString(), mobspCheckDuplicateCmpMobile_Result.CompanyName ?? "");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> InsertCompanyAppDeviceInfo(InsertCompanyAppDeviceInfoViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		string data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string firstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					cRMEntities = new CRMEntities();
					cRMEntities.MobspDeleteCompanyAppDeviceInfo(model.DeviceId, model.DeviceType);
					cRMEntities.MobspInsertCompanyAppDeviceInfo(model.CompanyId, model.DeviceId, model.DeviceType, value, firstRegisterDatePersian);
					data = null;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DeleteCompanyAppDeviceInfo(DeleteCompanyAppDeviceInfo model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		string data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					cRMEntities = new CRMEntities();
					cRMEntities.MobspDeleteCompanyAppDeviceInfo(model.DeviceId, model.DeviceType);
					data = null;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectCompanyInsidePolygon_Result>> SelectCompanyInsidePolygon(string polygon, int? cId = null, int? ln = null)
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
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		List<MobspSelectCompanyInsidePolygon_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectCompanyInsidePolygon_Result>((IEnumerable<MobspSelectCompanyInsidePolygon_Result>)cRMEntities.MobspSelectCompanyInsidePolygon(token2.userId, polygon, result, result2, cId));
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
		return new ServiceResult<List<MobspSelectCompanyInsidePolygon_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<mct_MobspSearchCompanyQuick_Result>> NewSearchCompanyQuick(string value, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<mct_MobspSearchCompanyQuick_Result> data = null;
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
					data = Enumerable.ToList<mct_MobspSearchCompanyQuick_Result>((IEnumerable<mct_MobspSearchCompanyQuick_Result>)cRMEntities.MobspSearchCompanyQuick(value, token2.userId, result, result2, cId));
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
		return new ServiceResult<List<mct_MobspSearchCompanyQuick_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<decimal> ReturnCompanyMoneyBagRemain(int companyId)
	{
		CRMEntities cRMEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		decimal data = default(decimal);
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
					data = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)cRMEntities.MobspReturnCompanyMoneyBagRemain(companyId)).GetValueOrDefault();
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = default(decimal);
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = default(decimal);
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = default(decimal);
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<decimal>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSearchCompanyQuickI_Result>> SearchCompanyQuickI(string value, int? cId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSearchCompanyQuickI_Result> data = null;
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
					data = Enumerable.ToList<MobspSearchCompanyQuickI_Result>((IEnumerable<MobspSearchCompanyQuickI_Result>)cRMSpEntities.MobspSearchCompanyQuickI(value, token2.userId, result, result2, cId));
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
		return new ServiceResult<List<MobspSearchCompanyQuickI_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool?> CheckHaveOrderOprExceptTspCmp(int cmpid, int? ln = null)
	{
		int result = 1056;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		bool? data = null;
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
					List<MobspCheckHaveOrderOprExceptTspCmp_Result> list = Enumerable.ToList<MobspCheckHaveOrderOprExceptTspCmp_Result>((IEnumerable<MobspCheckHaveOrderOprExceptTspCmp_Result>)cRMSpEntities.MobspCheckHaveOrderOprExceptTspCmp(cmpid, ln, result2));
					if (list != null && Enumerable.Any<MobspCheckHaveOrderOprExceptTspCmp_Result>((IEnumerable<MobspCheckHaveOrderOprExceptTspCmp_Result>)list))
					{
						data = true;
					}
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
		return new ServiceResult<bool?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<CRMspSelectLinkAccSettingDBIsActive_Result>> GetAccLinkSettingDB(int LinkAccSystemId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<CRMspSelectLinkAccSettingDBIsActive_Result> data = null;
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
					List<CRMspSelectLinkAccSettingDBIsActive_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)cRMSpEntities.CRMspSelectLinkAccSettingDBIsActive(LinkAccSystemId));
					if (list != null && Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list))
					{
						data = list;
					}
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
		return new ServiceResult<List<CRMspSelectLinkAccSettingDBIsActive_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<DuplicateNationalCodeViewModel> CmpDuplicateNCodeCheck(string cmpNCode, int companyId, int cId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		DuplicateNationalCodeViewModel data;
		string message2;
		ServiceResultStatus status;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					MobspCheckDuplicateCmpNationalCode_Result mobspCheckDuplicateCmpNationalCode_Result = Enumerable.FirstOrDefault<MobspCheckDuplicateCmpNationalCode_Result>((IEnumerable<MobspCheckDuplicateCmpNationalCode_Result>)cRMSpEntities.MobspCheckDuplicateCmpNationalCode(cmpNCode, companyId, num, result2));
					if (mobspCheckDuplicateCmpNationalCode_Result != null)
					{
						DuplicateNationalCodeViewModel duplicateNationalCodeViewModel = new DuplicateNationalCodeViewModel();
						duplicateNationalCodeViewModel.CIds = mobspCheckDuplicateCmpNationalCode_Result.cmpCIds;
						duplicateNationalCodeViewModel.CmpId = mobspCheckDuplicateCmpNationalCode_Result.CompanyId;
						string message = string.Format(Messages.CheckDuplicateCmpNationalCode, mobspCheckDuplicateCmpNationalCode_Result.cmpNumber.ToString(), mobspCheckDuplicateCmpNationalCode_Result.CompanyName ?? "");
						if (Enumerable.FirstOrDefault<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)mobspCheckDuplicateCmpNationalCode_Result.cmpCIds.Split(new char[1] { ',' })), (Func<string, bool>)((string x) => x == cId.ToString())) != null || !Center.HaveModule || Center.TotalCnt == 1)
						{
							duplicateNationalCodeViewModel.Message = message;
							duplicateNationalCodeViewModel.Mode = 1;
							data = duplicateNationalCodeViewModel;
							message2 = "";
							status = ServiceResultStatus.Success;
						}
						else
						{
							string text = Mobile.Classes.Helper.User.AccessUserToCIds(mobspCheckDuplicateCmpNationalCode_Result.cmpCIds, UserLogin.CurrentUser);
							string text2 = "";
							text2 = (string.IsNullOrWhiteSpace(text) ? ((companyId == 0) ? string.Format(Messages.msgMobFoundCompanyInOtherCenterAskToAddUserNoAccess, Center.GetNames(cId.ToString())) : Messages.msgFoundCompanyInOtherCenterUserNoAccess) : ((companyId == 0) ? string.Format(Messages.msgMobFoundCompanyInOtherCenterAskToAdd, Center.GetNames(text), Center.GetNames(cId.ToString())) : string.Format(Messages.msgFoundCompanyInOtherCenter, Center.GetNames(text))));
							duplicateNationalCodeViewModel.Message = text2;
							duplicateNationalCodeViewModel.Mode = 2;
							data = duplicateNationalCodeViewModel;
							message2 = "";
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						data = null;
						message2 = null;
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message2 = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message2 = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message2 = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<DuplicateNationalCodeViewModel>
		{
			Message = message2,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> UpdateCompanyCIds(int cmpId, int? ln = null, int prsId = 0)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		string data;
		string message;
		ServiceResultStatus status;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					cRMSpEntities.MobspUpdateCompanyCIds(UserLogin.CurrentUser.UserLastCId, cmpId);
					if (prsId != 0)
					{
						Company.UpdateCompanyPersonCIds(cmpId, prsId, ln);
					}
					data = "";
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> InsertEditeCmpPrsAddress(ShpPersonAddress vm)
	{
		int result = 1065;
		if (vm.Ln.HasValue)
		{
			int.TryParse(vm.Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		string message;
		string data;
		ServiceResultStatus status;
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
					string text = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					DateTime dateTime = default(DateTime);
					string text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(vm.prsBirthDate))
						{
							text2 = PersianDate.GetFormatetdDate(vm.prsBirthDate.Replace("/", ""));
							switch (num)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("00:00:00"), new PersianCulture());
								vm.prsBirthDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("00:00:00"), new CultureInfo("ar-SA"));
								vm.prsBirthDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("00:00:00"), new CultureInfo("en-US"));
								vm.prsBirthDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							vm.prsBirthDateTime = dateTime;
							vm.prsBirthDate = vm.prsBirthDate.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", "");
						}
						else
						{
							vm.prsBirthDateTime = null;
							vm.prsBirthDate = null;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						message = string.Format(Messages.ErrorInFormat, Labels.FOPrsBirthDate);
						vm.prsBirthDate = (vm.prsBirthDateTime.HasValue ? vm.prsBirthDateTime.Value.ToString("yyyy/MM/dd") : "");
						data = null;
						status = ServiceResultStatus.Error;
						return new ServiceResult<string>
						{
							Message = message,
							Data = data,
							Status = status
						};
					}
					if (vm.CompanyPersonID > 0)
					{
						CRMSpEntities cRMSpEntities2 = cRMSpEntities;
						int? companyPersonID = vm.CompanyPersonID;
						string prsLName = vm.prsLName;
						string prsFName = vm.prsFName;
						string prsMobile = vm.prsMobile;
						string prsEmail = vm.prsEmail;
						string prsAddress = vm.prsAddress;
						string prsZipCode = vm.prsZipCode;
						int? prsCountryId = vm.prsCountryId;
						int? prsProvinceId = vm.prsProvinceId;
						int? prsCityId = vm.prsCityId;
						string prsCoordinateLatitude = vm.prsCoordinateLatitude;
						string prsCoordinateLongitude = vm.prsCoordinateLongitude;
						DateTime? prsCoordinateLastDate = ((!string.IsNullOrEmpty(vm.prsCoordinateLatitude)) ? new DateTime?(value) : null);
						string prsCoordinateLastDatePersian = ((!string.IsNullOrEmpty(vm.prsCoordinateLatitude)) ? text : null);
						int? num2 = token2.userId;
						cRMSpEntities2.SHPMobspUpdateCompanyPerson(prsCoordinateZoomLevel: vm.prsCoordinateZoomLevel, prsCoordinateLastUserId: num2, userId: token2.userId, registerDate: value, registerDatePersian: text, languageID: num, defaultLanguageID: result2, companyPersonID: companyPersonID, prsLName: prsLName, prsFName: prsFName, prsMobile: prsMobile, prsEmail: prsEmail, prsAddress: prsAddress, prsZipCode: prsZipCode, prsCountryId: prsCountryId, prsProvinceId: prsProvinceId, prsCityId: prsCityId, prsCoordinateLatitude: prsCoordinateLatitude, prsCoordinateLongitude: prsCoordinateLongitude, prsCoordinateLastDate: prsCoordinateLastDate, prsCoordinateLastDatePersian: prsCoordinateLastDatePersian, month1: value2, year1: value3, appType: appType, prsBirthDate: vm.prsBirthDate, prsBirthDateTime: vm.prsBirthDateTime);
						data = "";
						message = Messages.FOMsgInfoRegSuccess;
						status = ServiceResultStatus.Success;
					}
					else
					{
						cRMSpEntities.SHPMobspInsertCompanyPerson(vm.prsCompanyId, vm.prsLName, vm.prsFName, null, null, null, null, vm.prsMobile, null, vm.prsEmail, vm.prsAddress, vm.prsZipCode, null, vm.prsCountryId, vm.prsProvinceId, vm.prsCityId, vm.prsCoordinateLatitude, vm.prsCoordinateLongitude, (!string.IsNullOrEmpty(vm.prsCoordinateLatitude)) ? new DateTime?(value) : null, (!string.IsNullOrEmpty(vm.prsCoordinateLatitude)) ? text : null, vm.prsCoordinateZoomLevel, token2.userId, null, null, null, value3, value2, token2.userId, value, text, appType, num, result2, vm.prsBirthDate, vm.prsBirthDateTime, vm.CId);
						data = "";
						message = Messages.FOMsgInfoRegSuccess;
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
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
