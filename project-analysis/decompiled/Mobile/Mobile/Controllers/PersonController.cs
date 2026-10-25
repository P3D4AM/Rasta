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

public class PersonController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectPersonList_Result>> List(int cmpid, bool? isPrsWorkingOut, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		List<MobspSelectPersonList_Result> data;
		string message;
		ServiceResultStatus status;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<List<MobspSelectPersonList_Result>>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectPersonList_Result>((IEnumerable<MobspSelectPersonList_Result>)cRMEntities.MobspSelectPersonList(cmpid, token2.userId, result, result2, isPrsWorkingOut, cId));
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
		return new ServiceResult<List<MobspSelectPersonList_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectPersonWithID_Result> Detail(int prsid, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectPersonWithID_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<MobspSelectPersonWithID_Result>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			cRMEntities = new CRMEntities();
			MobspSelectPersonWithID_Result mobspSelectPersonWithID_Result = Enumerable.FirstOrDefault<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)Enumerable.ToList<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)cRMEntities.MobspSelectPersonWithID(prsid, result, result2)));
			if (mobspSelectPersonWithID_Result != null)
			{
				data = mobspSelectPersonWithID_Result;
				message = "";
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = Messages.MobMsgErrorPersonNotFound;
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
		return new ServiceResult<MobspSelectPersonWithID_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<PersonViewModel> MoreInfo(int prsid, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		PersonViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmCompanyI", "actDefineCompanyPerson", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<PersonViewModel>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			cRMEntities = new CRMEntities();
			MobspSelectPersonMoreInfo_Result mobspSelectPersonMoreInfo_Result = Enumerable.FirstOrDefault<MobspSelectPersonMoreInfo_Result>((IEnumerable<MobspSelectPersonMoreInfo_Result>)Enumerable.ToList<MobspSelectPersonMoreInfo_Result>((IEnumerable<MobspSelectPersonMoreInfo_Result>)cRMEntities.MobspSelectPersonMoreInfo(prsid, result, result2)));
			if (mobspSelectPersonMoreInfo_Result != null)
			{
				Dictionary<string, object> otherFields = Enumerable.ToDictionary<string[], string, object>(Enumerable.Select<string, string[]>((IEnumerable<string>)mobspSelectPersonMoreInfo_Result.otherFields.Split(new string[1] { "@|$|@" }, StringSplitOptions.None), (Func<string, string[]>)((string oi) => oi.Split(new string[1] { "@^$|@" }, StringSplitOptions.None))), (Func<string[], string>)((string[] arrOi) => arrOi[0]), (Func<string[], object>)((string[] arrOi) => arrOi[1]));
				Dictionary<string, object> otherFieldsHeader = Enumerable.ToDictionary<string[], string, object>(Enumerable.Select<string, string[]>((IEnumerable<string>)mobspSelectPersonMoreInfo_Result.otherFieldsHeader.Split(new string[1] { "@|$|@" }, StringSplitOptions.None), (Func<string, string[]>)((string oi) => oi.Split(new string[1] { "@^$|@" }, StringSplitOptions.None))), (Func<string[], string>)((string[] arrOi) => arrOi[0]), (Func<string[], object>)((string[] arrOi) => arrOi[1]));
				data = new PersonViewModel
				{
					CompanyPersonID = mobspSelectPersonMoreInfo_Result.CompanyPersonID,
					prsCompanyId = mobspSelectPersonMoreInfo_Result.prsCompanyId,
					prsFullName = mobspSelectPersonMoreInfo_Result.prsFullName,
					prsFullJob = mobspSelectPersonMoreInfo_Result.prsFullJob,
					prsFullTelMob = mobspSelectPersonMoreInfo_Result.prsFullTelMob,
					otherFields = otherFields,
					otherFieldsHeader = otherFieldsHeader
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
		return new ServiceResult<PersonViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<MobspSelectPersonWithID_Result> DetailWithOutAccess(int prsid, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectPersonWithID_Result data = null;
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
				MobspSelectPersonWithID_Result mobspSelectPersonWithID_Result = Enumerable.FirstOrDefault<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)Enumerable.ToList<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)cRMEntities.MobspSelectPersonWithID(prsid, result, result2)));
				if (mobspSelectPersonWithID_Result != null)
				{
					data = mobspSelectPersonWithID_Result;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorPersonNotFound;
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
		return new ServiceResult<MobspSelectPersonWithID_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<DuplicateNationalCodeViewModel> PrsDuplicateCheck(string prsNCode, int companyId, int cId, int? ln = null)
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
					MobspCheckDuplicatePrsNationalCode_Result mobspCheckDuplicatePrsNationalCode_Result = Enumerable.FirstOrDefault<MobspCheckDuplicatePrsNationalCode_Result>((IEnumerable<MobspCheckDuplicatePrsNationalCode_Result>)cRMSpEntities.MobspCheckDuplicatePrsNationalCode(prsNCode, 0, num, result2));
					if (mobspCheckDuplicatePrsNationalCode_Result != null)
					{
						DuplicateNationalCodeViewModel duplicateNationalCodeViewModel = new DuplicateNationalCodeViewModel();
						duplicateNationalCodeViewModel.PrsId = mobspCheckDuplicatePrsNationalCode_Result.CompanyPersonID;
						duplicateNationalCodeViewModel.CIds = mobspCheckDuplicatePrsNationalCode_Result.prsCIds;
						duplicateNationalCodeViewModel.CmpId = mobspCheckDuplicatePrsNationalCode_Result.prsCompanyId;
						string message = string.Format(Messages.CheckDuplicateCmpNationalCode, mobspCheckDuplicatePrsNationalCode_Result.cmpNumber.ToString(), mobspCheckDuplicatePrsNationalCode_Result.CompanyName ?? "");
						if (Enumerable.FirstOrDefault<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)mobspCheckDuplicatePrsNationalCode_Result.prsCIds.Split(new char[1] { ',' })), (Func<string, bool>)((string x) => x == cId.ToString())) != null || !Center.HaveModule || Center.TotalCnt == 1)
						{
							duplicateNationalCodeViewModel.Message = message;
							duplicateNationalCodeViewModel.Mode = 1;
							data = duplicateNationalCodeViewModel;
							message2 = "";
							status = ServiceResultStatus.Success;
						}
						else
						{
							string text = Mobile.Classes.Helper.User.AccessUserToCIds(mobspCheckDuplicatePrsNationalCode_Result.prsCIds, UserLogin.CurrentUser);
							string text2 = "";
							text2 = (string.IsNullOrWhiteSpace(text) ? ((companyId == 0) ? string.Format(Messages.msgMobFoundPersonInOtherCenterAskToAddUserNoAccess, Center.GetNames(cId.ToString())) : Messages.msgFoundPersonInOtherCenterUserNoAccess) : ((companyId == 0) ? string.Format(Messages.msgMobFoundPersonInOtherCenterAskToAdd, Center.GetNames(text), Center.GetNames(cId.ToString())) : string.Format(Messages.msgFoundPersonInOtherCenter, Center.GetNames(text))));
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
						message2 = "";
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
	public ServiceResult<string> UpdateCompanyPersonCIds(int cmpId, int prsId, int? ln = null)
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
					cRMSpEntities.MobspUpdateCompanyPersonCIds(UserLogin.CurrentUser.UserLastCId, cmpId, prsId);
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
}
