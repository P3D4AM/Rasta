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
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class FOHomeController : ApiController
{
	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FoGetHomeGallery>> GetHomeGallery(int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<FoGetHomeGallery> list = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					list = new List<FoGetHomeGallery>();
					FOMobspSelectHomePageSetting_Result fOMobspSelectHomePageSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectHomePageSetting_Result>((IEnumerable<FOMobspSelectHomePageSetting_Result>)cRMEntities.FOMobspSelectHomePageSetting(cId, foSettingId));
					if (fOMobspSelectHomePageSetting_Result != null && fOMobspSelectHomePageSetting_Result.MobFoHomeGalleryId.HasValue)
					{
						FoGetHomeGallery gallery = CmsGallery.GetGallery(fOMobspSelectHomePageSetting_Result.MobFoHomeGalleryId.GetValueOrDefault());
						list.Add(gallery);
					}
					message = Messages.MobMsgSuccessAction;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<FoGetHomeGallery>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspSelectCompanyProjectsFoCanSee_Result>> GetProjectList(int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		List<FOMobspSelectCompanyProjectsFoCanSee_Result> data = null;
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
					data = new List<FOMobspSelectCompanyProjectsFoCanSee_Result>();
					List<FOMobspSelectCompanyProjectsFoCanSee_Result> list = Enumerable.ToList<FOMobspSelectCompanyProjectsFoCanSee_Result>((IEnumerable<FOMobspSelectCompanyProjectsFoCanSee_Result>)cRMSpEntities.FOMobspSelectCompanyProjectsFoCanSee(token2.CompanyId, 0, num, result2, cId));
					bool result3 = false;
					FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(num, result2, cId, foSettingId));
					if (fOMobspSelectCrmFoSetting_Result != null)
					{
						bool.TryParse(fOMobspSelectCrmFoSetting_Result.FoCanInsCnvs.ToString(), out result3);
					}
					if (list != null && Enumerable.Any<FOMobspSelectCompanyProjectsFoCanSee_Result>((IEnumerable<FOMobspSelectCompanyProjectsFoCanSee_Result>)list))
					{
						foreach (FOMobspSelectCompanyProjectsFoCanSee_Result item in list)
						{
							bool result4 = false;
							bool result5 = false;
							bool.TryParse(item.prjFOCmpCanInsCnvs.ToString(), out result4);
							bool.TryParse(item.prjFOCmpCanNotInsCnvs.ToString(), out result5);
							if (result4)
							{
								item.prjFOCmpCanInsCnvs = true;
							}
							else if (result3 && result5)
							{
								item.prjFOCmpCanInsCnvs = false;
							}
							else if (result3)
							{
								item.prjFOCmpCanInsCnvs = true;
							}
							else
							{
								item.prjFOCmpCanInsCnvs = false;
							}
							data = list;
						}
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
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<FOMobspSelectCompanyProjectsFoCanSee_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FoGetConversationListViewModel> GetConversationList(int prjId, int? companyPersonId, int pageNumber = 1, int pageSize = 10, int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		FoGetConversationListViewModel foGetConversationListViewModel = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					foGetConversationListViewModel = new FoGetConversationListViewModel();
					foGetConversationListViewModel.ListConversation = new List<FOMobspSelectPrjConversationAndFiles_Result>();
					foGetConversationListViewModel.ListConversationFiles = new List<FOMobspSelectFilesDirectory_Result>();
					foGetConversationListViewModel.ListConversationKnowledgeTank = new List<FOMobspknlgSelectKnowledgeTankByIds_Result>();
					FOMobspSelectCompanyProjectById_Result fOMobspSelectCompanyProjectById_Result = Enumerable.FirstOrDefault<FOMobspSelectCompanyProjectById_Result>((IEnumerable<FOMobspSelectCompanyProjectById_Result>)cRMSpEntities.FOMobspSelectCompanyProjectById(prjId, num, result2));
					if (fOMobspSelectCompanyProjectById_Result != null)
					{
						bool result3 = false;
						FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(num, result2, cId, foSettingId));
						if (fOMobspSelectCrmFoSetting_Result != null)
						{
							bool.TryParse(fOMobspSelectCrmFoSetting_Result.FoCanInsCnvs.ToString(), out result3);
						}
						bool result4 = false;
						bool result5 = false;
						bool.TryParse(fOMobspSelectCompanyProjectById_Result.prjFOCmpCanInsCnvs.ToString(), out result4);
						bool.TryParse(fOMobspSelectCompanyProjectById_Result.prjFOCmpCanNotInsCnvs.ToString(), out result5);
						if (result4)
						{
							fOMobspSelectCompanyProjectById_Result.prjFOCmpCanInsCnvs = true;
						}
						else if (result3 && result5)
						{
							fOMobspSelectCompanyProjectById_Result.prjFOCmpCanInsCnvs = false;
						}
						else if (result3)
						{
							fOMobspSelectCompanyProjectById_Result.prjFOCmpCanInsCnvs = true;
						}
						else
						{
							fOMobspSelectCompanyProjectById_Result.prjFOCmpCanInsCnvs = false;
						}
						foGetConversationListViewModel.Project = fOMobspSelectCompanyProjectById_Result;
						List<FOMobspSelectPrjConversationAndFiles_Result> list = Enumerable.ToList<FOMobspSelectPrjConversationAndFiles_Result>((IEnumerable<FOMobspSelectPrjConversationAndFiles_Result>)cRMSpEntities.FOMobspSelectPrjConversationAndFiles(prjId, pageNumber, pageSize, num, result2, companyPersonId, cId));
						if (list != null && Enumerable.Any<FOMobspSelectPrjConversationAndFiles_Result>((IEnumerable<FOMobspSelectPrjConversationAndFiles_Result>)list))
						{
							foGetConversationListViewModel.ListConversation = list;
							foreach (FOMobspSelectPrjConversationAndFiles_Result item in list)
							{
								List<FOMobspSelectFilesDirectory_Result> list2 = Enumerable.ToList<FOMobspSelectFilesDirectory_Result>((IEnumerable<FOMobspSelectFilesDirectory_Result>)cRMEntities.FOMobspSelectFilesDirectory(item.cnvsCompanyId.ToString(), item.cnvsPersonId.ToString(), item.cnvsProjectId.ToString(), "2", item.ConversationID.ToString(), num, result2, true, cId));
								if (list2 != null && Enumerable.Any<FOMobspSelectFilesDirectory_Result>((IEnumerable<FOMobspSelectFilesDirectory_Result>)list2))
								{
									foGetConversationListViewModel.ListConversationFiles.AddRange(list2);
								}
								if (!string.IsNullOrWhiteSpace(item.cnvsKnowledgeTankIds))
								{
									List<FOMobspknlgSelectKnowledgeTankByIds_Result> list3 = Enumerable.ToList<FOMobspknlgSelectKnowledgeTankByIds_Result>((IEnumerable<FOMobspknlgSelectKnowledgeTankByIds_Result>)cRMSpEntities.FOMobspknlgSelectKnowledgeTankByIds(item.cnvsKnowledgeTankIds, num, result2));
									if (list3 != null && Enumerable.Any<FOMobspknlgSelectKnowledgeTankByIds_Result>((IEnumerable<FOMobspknlgSelectKnowledgeTankByIds_Result>)list3))
									{
										foGetConversationListViewModel.ListConversationKnowledgeTank.AddRange(list3);
									}
								}
							}
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorProjectNotFound;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					foGetConversationListViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				foGetConversationListViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			foGetConversationListViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<FoGetConversationListViewModel>
		{
			Message = message,
			Data = foGetConversationListViewModel,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspSelectCompanyPreOrders_Result>> GetPreOrderList(int cmpPersonId, int pageNumber = 1, int pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<FOMobspSelectCompanyPreOrders_Result> data = null;
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
					data = Enumerable.ToList<FOMobspSelectCompanyPreOrders_Result>((IEnumerable<FOMobspSelectCompanyPreOrders_Result>)cRMSpEntities.FOMobspSelectCompanyPreOrders(token2.CompanyId, pageNumber, pageSize, num, result2, DateTime.Now, cmpPersonId, cId));
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
		return new ServiceResult<List<FOMobspSelectCompanyPreOrders_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspSelectCompanyOrders_Result>> GetOrderList(long ordNumber, int cmpPersonId, int pageNumber = 1, int pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<FOMobspSelectCompanyOrders_Result> data = null;
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
					data = Enumerable.ToList<FOMobspSelectCompanyOrders_Result>((IEnumerable<FOMobspSelectCompanyOrders_Result>)cRMSpEntities.FOMobspSelectCompanyOrders(token2.CompanyId, pageNumber, pageSize, num, result2, ordNumber, cmpPersonId, cId));
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
		return new ServiceResult<List<FOMobspSelectCompanyOrders_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspSelectCompanyItemsDetail_Result>> GetSummaryDetail(int companyId, int companyPersonId, int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<FOMobspSelectCompanyItemsDetail_Result> data = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<FOMobspSelectCompanyItemsDetail_Result>((IEnumerable<FOMobspSelectCompanyItemsDetail_Result>)cRMEntities.FOMobspSelectCompanyItemsDetail(companyId, num, result2, companyPersonId, cId, foSettingId));
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
		return new ServiceResult<List<FOMobspSelectCompanyItemsDetail_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FOMobspReturnSumCompanyScores_Result> GetScore(int cmpId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		FOMobspReturnSumCompanyScores_Result data = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.FirstOrDefault<FOMobspReturnSumCompanyScores_Result>((IEnumerable<FOMobspReturnSumCompanyScores_Result>)cRMSpEntities.FOMobspReturnSumCompanyScores(cmpId, cId));
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
		return new ServiceResult<FOMobspReturnSumCompanyScores_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspSelectCompanyScores_Result>> GetCompanyScore(int cmpId, string fromDate, string toDate, int pageNumber = 1, int pageSize = 100, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<FOMobspSelectCompanyScores_Result> data = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime value = DateTime.Now;
					DateTime value2 = DateTime.Now;
					try
					{
						if (!string.IsNullOrEmpty(fromDate))
						{
							fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							value = DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00");
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						text = string.Format(Messages.ErrorInFormat, Labels.FOCompanyScoreFromDate);
						data = null;
						status = ServiceResultStatus.Error;
					}
					try
					{
						if (!string.IsNullOrEmpty(toDate))
						{
							toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							value2 = DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59");
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						text = string.Format(Messages.ErrorInFormat, Labels.FOCompanyScoreToDate);
						data = null;
						status = ServiceResultStatus.Error;
					}
					if (string.IsNullOrEmpty(text))
					{
						string textRemaindScoreBefore = Labels.TextRemaindScoreBefore;
						string textEarningScore = Labels.TextEarningScore;
						string textSpendScore = Labels.TextSpendScore;
						data = Enumerable.ToList<FOMobspSelectCompanyScores_Result>((IEnumerable<FOMobspSelectCompanyScores_Result>)cRMSpEntities.FOMobspSelectCompanyScores(cmpId, value, value2, textRemaindScoreBefore, textEarningScore, textSpendScore, pageNumber, pageSize, result, result2, cId));
						text = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					text = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				text = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			text = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<FOMobspSelectCompanyScores_Result>>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspSelectDiscountCodeRules_Result>> DiscountCodeRules(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<FOMobspSelectDiscountCodeRules_Result> data = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<FOMobspSelectDiscountCodeRules_Result>((IEnumerable<FOMobspSelectDiscountCodeRules_Result>)cRMSpEntities.FOMobspSelectDiscountCodeRules(DateTime.Now, num, result2));
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
		return new ServiceResult<List<FOMobspSelectDiscountCodeRules_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FOMobspInsertDiscountCodeFromDisCodeRule_Result> SendRequestDiscountCode(int cmpId, int ruleId, int? ln = null, int? cId = null)
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
		int id = Financial.Get().Id;
		short value2 = short.Parse(Financial.Get().Id.ToString());
		short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		CRMSpEntities cRMSpEntities = null;
		FOMobspInsertDiscountCodeFromDisCodeRule_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			cRMSpEntities = new CRMSpEntities();
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					double num2 = 0.0;
					FOMobspReturnSumCompanyScores_Result fOMobspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<FOMobspReturnSumCompanyScores_Result>((IEnumerable<FOMobspReturnSumCompanyScores_Result>)cRMSpEntities.FOMobspReturnSumCompanyScores(cmpId, cId));
					if (fOMobspReturnSumCompanyScores_Result != null)
					{
						num2 = fOMobspReturnSumCompanyScores_Result.SumUsableScores;
					}
					FOMobspSelectDiscountCodeRuleWithId_Result fOMobspSelectDiscountCodeRuleWithId_Result = Enumerable.FirstOrDefault<FOMobspSelectDiscountCodeRuleWithId_Result>((IEnumerable<FOMobspSelectDiscountCodeRuleWithId_Result>)cRMSpEntities.FOMobspSelectDiscountCodeRuleWithId(ruleId, result, result2));
					if (fOMobspSelectDiscountCodeRuleWithId_Result != null)
					{
						if (fOMobspSelectDiscountCodeRuleWithId_Result.DisRScoreRate.GetValueOrDefault() != 0.0 && fOMobspSelectDiscountCodeRuleWithId_Result.DisRScoreRate > num2)
						{
							data = null;
							message = Messages.FOMsgErrorDiscCodeRuleYourScoreIsNotEnough;
							status = ServiceResultStatus.Error;
						}
						else
						{
							DateTime? dateTime = null;
							if (fOMobspSelectDiscountCodeRuleWithId_Result.DisRExpDay.GetValueOrDefault() != 0)
							{
								dateTime = DateTime.Now.AddDays(fOMobspSelectDiscountCodeRuleWithId_Result.DisRExpDay.GetValueOrDefault());
							}
							else if (fOMobspSelectDiscountCodeRuleWithId_Result.DisRExpDate.HasValue)
							{
								dateTime = fOMobspSelectDiscountCodeRuleWithId_Result.DisRExpDate;
							}
							List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
							foreach (FOMobspSelectLanguages_Result language in Language.GetLanguageList())
							{
								list.Add(new CommonMultiLanguageViewModel
								{
									LanguageId = language.LanguageID,
									Value = Labels.ResourceManager.GetString("GenerateDiscountCodeFromDisCodeRuleTitle", new CultureInfo(language.LanguageID))
								});
							}
							double? num3 = fOMobspSelectDiscountCodeRuleWithId_Result.DisRScoreRate;
							if (num3 == 0.0)
							{
								num3 = null;
							}
							else if (num3 > 0.0)
							{
								num3 = -1.0 * num3;
							}
							FOMobspInsertDiscountCodeFromDisCodeRule_Result fOMobspInsertDiscountCodeFromDisCodeRule_Result = Enumerable.FirstOrDefault<FOMobspInsertDiscountCodeFromDisCodeRule_Result>((IEnumerable<FOMobspInsertDiscountCodeFromDisCodeRule_Result>)cRMSpEntities.FOMobspInsertDiscountCodeFromDisCodeRule(ruleId, JsonConvert.SerializeObject(list), fOMobspSelectDiscountCodeRuleWithId_Result.DisRAmount, fOMobspSelectDiscountCodeRuleWithId_Result.DisRAmountPercent, dateTime, dateTime?.ToString("yyyyMMdd", new PersianCulture()), cmpId, fOMobspSelectDiscountCodeRuleWithId_Result.DisRUseCnt, num, result2, num3, fOMobspSelectDiscountCodeRuleWithId_Result.DisRCanChangeToScore, fOMobspSelectDiscountCodeRuleWithId_Result.DisRPreCode, -10, id, value2, value3, value, registerDatePersian, "mob", cId));
							if (fOMobspInsertDiscountCodeFromDisCodeRule_Result != null)
							{
								data = fOMobspInsertDiscountCodeFromDisCodeRule_Result;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
					}
					else
					{
						message = Messages.FOMsgErrorDiscCodeRuleNotFound;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<FOMobspInsertDiscountCodeFromDisCodeRule_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspSelectTickets_Result>> GetTicketIsNotRead(int cmpPersonId, int pageNumber = 1, int pageSize = 100, int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		_ = Financial.Get().Id;
		short.Parse(Financial.Get().Id.ToString());
		short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		CRMEntities cRMEntities = null;
		List<FOMobspSelectTickets_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			cRMEntities = new CRMEntities();
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					List<FOMobspSelectTickets_Result> list = Enumerable.ToList<FOMobspSelectTickets_Result>((IEnumerable<FOMobspSelectTickets_Result>)cRMEntities.FOMobspSelectTickets(token2.CompanyId, 0, 0, null, null, pageNumber, pageSize, num, result2, false, null, cmpPersonId, cId, foSettingId));
					if (list != null)
					{
						data = list;
						message = Messages.MobMsgSuccessAction;
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
		}
		return new ServiceResult<List<FOMobspSelectTickets_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<decimal> GetCompanyMoneyBagRemind(int cmpId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		_ = Financial.Get().Id;
		short.Parse(Financial.Get().Id.ToString());
		short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		CRMSpEntities cRMSpEntities = null;
		decimal data = default(decimal);
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			cRMSpEntities = new CRMSpEntities();
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					data = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)cRMSpEntities.FOMobspReturnCompanyMoneyBagRemain(token2.CompanyId, cId)).GetValueOrDefault();
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<decimal>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
