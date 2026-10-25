using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class FOBasicInfoController : ApiController
{
	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FOMobspSelectUserBaseInfoLastUpdate_Result> SelectUserBaseInfoLastUpdate(int? ln = null)
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
		FOMobspSelectUserBaseInfoLastUpdate_Result data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<FOMobspSelectUserBaseInfoLastUpdate_Result>((IEnumerable<FOMobspSelectUserBaseInfoLastUpdate_Result>)cRMEntities.FOMobspSelectUserBaseInfoLastUpdate(-20));
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
		return new ServiceResult<FOMobspSelectUserBaseInfoLastUpdate_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FoDropDownItem>> SelectTicketProjectTitleAndTitleGroup(int? ln = null, int? foSettingId = null)
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
		List<FoDropDownItem> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					List<FOMobspSelectTicketProjectTitleAndTitleGroup_Result> list = Enumerable.ToList<FOMobspSelectTicketProjectTitleAndTitleGroup_Result>((IEnumerable<FOMobspSelectTicketProjectTitleAndTitleGroup_Result>)cRMEntities.FOMobspSelectTicketProjectTitleAndTitleGroup(result, result2, foSettingId));
					List<FoDropDownItem> list2 = new List<FoDropDownItem>();
					foreach (FOMobspSelectTicketProjectTitleAndTitleGroup_Result item in list)
					{
						FoDropDownItem foDropDownItem = new FoDropDownItem();
						int result3 = 0;
						int.TryParse(item.prjTitleGroupId.ToString(), out result3);
						foDropDownItem.Id = result3;
						foDropDownItem.Title = item.prjTitleGroup ?? "";
						foDropDownItem.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("ProjectTitleGroupDesc", item.ProjectTitleGroupDesc ?? "");
						dictionary.Add("ProjectTitleGroupAgreementActive", item.ProjectTitleGroupAgreementActive.GetValueOrDefault().ToString());
						dictionary.Add("ProjectTitleGroupAgreementDesc", item.ProjectTitleGroupAgreementDesc ?? "");
						dictionary.Add("prjTitle", item.prjTitle ?? "");
						dictionary.Add("prjcnvsStatusGroupId", item.prjcnvsStatusGroupId.GetValueOrDefault().ToString());
						dictionary.Add("prjUserDepartmentId", item.prjUserDepartmentId.GetValueOrDefault().ToString());
						dictionary.Add("prjUserDepartment", item.prjUserDepartment ?? "");
						dictionary.Add("ProjectTitleGroupSubjectDefaultContext", item.ProjectTitleGroupSubjectDefaultContext ?? "");
						foDropDownItem.ExtraField = dictionary;
						list2.Add(foDropDownItem);
					}
					data = list2;
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
		return new ServiceResult<List<FoDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FoDropDownItem>> SelectCompanyPersonsForTicket(int companyPersonId, int? ln = null, int? cId = null)
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
		List<FoDropDownItem> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					List<FOMobspSelectCompanyPersonsForTicket_Result> list = Enumerable.ToList<FOMobspSelectCompanyPersonsForTicket_Result>((IEnumerable<FOMobspSelectCompanyPersonsForTicket_Result>)cRMEntities.FOMobspSelectCompanyPersonsForTicket(token2.CompanyId, result, result2, companyPersonId, cId));
					List<FoDropDownItem> list2 = new List<FoDropDownItem>();
					foreach (FOMobspSelectCompanyPersonsForTicket_Result item in list)
					{
						FoDropDownItem foDropDownItem = new FoDropDownItem();
						int result3 = 0;
						int.TryParse(item.CompanyPersonID.ToString(), out result3);
						foDropDownItem.Id = result3;
						foDropDownItem.Title = item.PersonName ?? "";
						list2.Add(foDropDownItem);
					}
					data = list2;
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
		return new ServiceResult<List<FoDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FoDropDownItem>> SelectCompanyPersonsForCnvs(int companyPersonId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		List<FoDropDownItem> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					List<FOMobspSelectCompanyPersonsForCnvs_Result> list = Enumerable.ToList<FOMobspSelectCompanyPersonsForCnvs_Result>((IEnumerable<FOMobspSelectCompanyPersonsForCnvs_Result>)cRMSpEntities.FOMobspSelectCompanyPersonsForCnvs(token2.CompanyId, result, result2, companyPersonId, cId));
					List<FoDropDownItem> list2 = new List<FoDropDownItem>();
					foreach (FOMobspSelectCompanyPersonsForCnvs_Result item in list)
					{
						FoDropDownItem foDropDownItem = new FoDropDownItem();
						int result3 = 0;
						int.TryParse(item.CompanyPersonID.ToString(), out result3);
						foDropDownItem.Id = result3;
						foDropDownItem.Title = item.PersonName ?? "";
						list2.Add(foDropDownItem);
					}
					data = list2;
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
		return new ServiceResult<List<FoDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FoDropDownItem>> SelectConversationPriority(int? ln = null)
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
		List<FoDropDownItem> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					List<FOMobspSelectConversationPriority_Result> list = Enumerable.ToList<FOMobspSelectConversationPriority_Result>((IEnumerable<FOMobspSelectConversationPriority_Result>)cRMEntities.FOMobspSelectConversationPriority(result, result2));
					List<FoDropDownItem> list2 = new List<FoDropDownItem>();
					foreach (FOMobspSelectConversationPriority_Result item in list)
					{
						FoDropDownItem foDropDownItem = new FoDropDownItem();
						int result3 = 0;
						int.TryParse(item.ConversationPriorityID.ToString(), out result3);
						foDropDownItem.Id = result3;
						foDropDownItem.Title = item.Priority ?? "";
						list2.Add(foDropDownItem);
					}
					data = list2;
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
		return new ServiceResult<List<FoDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FoDropDownItem>> SelectTicketSubjectDefaultContext(int? ln = null, int? foSettingId = null)
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
		List<FoDropDownItem> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					List<string> list = Enumerable.ToList<string>((IEnumerable<string>)cRMEntities.FOMobspSelectTicketSubjectDefaultContext(Labels.FOTicketNewSubject, result, result2, foSettingId));
					List<FoDropDownItem> list2 = new List<FoDropDownItem>();
					foreach (string item in list)
					{
						FoDropDownItem foDropDownItem = new FoDropDownItem();
						foDropDownItem.Title = item ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("Value", (item != Labels.FOTicketNewSubject) ? item : "-1");
						foDropDownItem.ExtraField = dictionary;
						list2.Add(foDropDownItem);
					}
					data = list2;
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
		return new ServiceResult<List<FoDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FOMobspSelectCrmFoSetting_Result> GetCrmFoSetting(int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		FOMobspSelectCrmFoSetting_Result data = null;
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
					data = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(num, result2, cId, foSettingId));
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
		return new ServiceResult<FOMobspSelectCrmFoSetting_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<FOMobspSelectCrmFoSetting_Result> GetFoSetting(int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		FOMobspSelectCrmFoSetting_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string text = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (text != null && text == "CrmIdealMob")
				{
					if (!foSettingId.HasValue)
					{
						foSettingId = FoCenter.GetFoSettingShareInfo().FoSettingShareId;
					}
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(num, result2, cId, foSettingId));
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
		return new ServiceResult<FOMobspSelectCrmFoSetting_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspSelectOnlinePayBankInfo_Result>> SelectOnlinePayBankInfo(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<FOMobspSelectOnlinePayBankInfo_Result> data = null;
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
					data = Enumerable.ToList<FOMobspSelectOnlinePayBankInfo_Result>((IEnumerable<FOMobspSelectOnlinePayBankInfo_Result>)cRMSpEntities.FOMobspSelectOnlinePayBankInfo(num, result2));
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
		return new ServiceResult<List<FOMobspSelectOnlinePayBankInfo_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspSelectUserDepartments_Result>> SelectUserDepartments(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		List<FOMobspSelectUserDepartments_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<FOMobspSelectUserDepartments_Result>((IEnumerable<FOMobspSelectUserDepartments_Result>)cRMSpEntities.FOMobspSelectUserDepartments(ln, result2, cId));
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
		return new ServiceResult<List<FOMobspSelectUserDepartments_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
