using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Component.Controllers;

public class CompanyPersonController : Controller
{
	public ActionResult Sample()
	{
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CrmCompanyPersonViewModel> GetCompanyPersonsList(int cmpId = 0, int pageSize = 50, int lastRowNumber = 0, string prsIds = "", string val = "", bool? prsWorkingOut = null)
	{
		List<CrmCompanyPersonViewModel> list = new List<CrmCompanyPersonViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int userId = 0;
			if (UserLogin.CurrentUser != null)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			list.AddRange(Enumerable.ToList<CrmCompanyPersonViewModel>(Enumerable.Select<CRMspSelectCompanyPersonsWithPaging_Result, CrmCompanyPersonViewModel>((IEnumerable<CRMspSelectCompanyPersonsWithPaging_Result>)CRMIdeal.Classes.Helper.Company.SelectCompanyPersonsWithPaging(cmpId, userId, prsWorkingOut, pageSize, lastRowNumber, val), (Func<CRMspSelectCompanyPersonsWithPaging_Result, CrmCompanyPersonViewModel>)((CRMspSelectCompanyPersonsWithPaging_Result x) => new CrmCompanyPersonViewModel
			{
				RowNumber = x.RowNumber,
				CompanyPersonID = x.CompanyPersonID,
				prsCompanyId = x.prsCompanyId,
				prsLName = x.prsLName,
				prsFName = x.prsFName,
				prsTitleId = x.prsTitleId,
				prsTitleIdStr = x.prsTitle,
				prsJobId = x.prsJobId,
				prsJobIdStr = x.prsJob,
				prsDepartmentId = x.prsDepartmentId,
				prsDepartmentIdStr = x.prsDepartment,
				prsMobile = x.prsMobile,
				prsPreTel = x.prsPreTel,
				prsTel = x.prsTel,
				prsTelUpTo = x.prsTelUpTo,
				prsTelDesc = x.prsTelDesc,
				prsTelII = x.prsTelII,
				prsFax = x.prsFax,
				prsFaxDesc = x.prsFaxDesc,
				prsEmail = x.prsEmail,
				prsDescription = x.prsDescription,
				prsAddress = x.prsAddress,
				prsAddressDesc = x.prsAddressDesc,
				prsEmailII = x.prsEmailII,
				ImportDate = x.ImportDate,
				prsFirstRegisterUserId = x.prsFirstRegisterUserId,
				prsWorkingOut = x.prsWorkingOut,
				prsOrderView = x.prsOrderView,
				UserId = x.UserId,
				Year1 = x.Year1,
				Month1 = x.Month1,
				RegisterDate = x.RegisterDate,
				RegisterDatePersian = x.RegisterDatePersian,
				AddType = x.AddType,
				CompanyPersonTemplateID = x.CompanyPersonTemplateID,
				prsTypeId = x.prsTypeId,
				prsTypeIdStr = x.prsType,
				prsGroupId = x.prsGroupId,
				prsGroupIdStr = x.prsGroup,
				prsSexId = x.prsSexId,
				prsSexIdStr = x.prsSex,
				prsEducationId = x.prsEducationId,
				prsEducationIdStr = x.prsEducation,
				prsWebSite = x.prsWebSite,
				prsCountryId = x.prsCountryId,
				prsCountryIdStr = x.prsCountry,
				prsProvinceId = x.prsProvinceId,
				prsProvinceIdStr = x.prsProvince,
				prsCityId = x.prsCityId,
				prsCityIdStr = x.prsCity,
				prsZipCode = x.prsZipCode,
				prsPostBox = x.prsPostBox,
				prsNationalCode = x.prsNationalCode,
				prsIdentityNumber = x.prsIdentityNumber,
				prsFatherName = x.prsFatherName,
				prsBirthDate = x.prsBirthDate,
				prsBirthPlace = x.prsBirthPlace,
				prsIsMarried = x.prsIsMarried,
				prsMarriageDate = x.prsMarriageDate,
				prsEducationField = x.prsEducationField,
				prsSkill = x.prsSkill,
				prsStudyField = x.prsStudyField,
				prsInteresting = x.prsInteresting,
				prsSpecialPoint = x.prsSpecialPoint,
				prsStopSendSms = x.prsStopSendSms,
				prsFirstRegisterUserIdStr = x.FirstRegisterUser,
				UserIdStr = x.EditUser,
				AppType = x.AppType,
				prsUserName = x.prsUserName,
				prsPassword = x.prsPassword,
				prsFOIsActive = x.prsFOIsActive,
				prsFOActiveDate = x.prsFOActiveDate,
				prsFOActiveDatePersian = x.prsFOActiveDatePersian,
				prsFOActiveUserId = x.prsFOActiveUserId,
				prsFOActiveUser = x.prsFOActiveUser,
				prsFOLoginExpireDate = x.prsFOLoginExpireDate,
				prsFOLoginExpireDatePersian = x.prsFOLoginExpireDatePersian,
				prsFOLoginExpireUserId = x.prsFOLoginExpireUserId,
				prsFOLoginExpireUser = x.prsFOLoginExpireUser,
				prsCIds = x.prsCIds,
				prsFOInfo = x.prsFOInfo,
				prsFOInfoExtra = CRMIdeal.Classes.Helper.Company.GetFoInfoJsonByName(x.prsFOInfo, x.prsCIds)
			}))));
			if (!string.IsNullOrWhiteSpace(prsIds))
			{
				List<string> arr = Enumerable.ToList<string>((IEnumerable<string>)prsIds.Split(new char[1] { ',' }));
				int a;
				for (a = 0; a < arr.Count; a++)
				{
					if (Enumerable.FirstOrDefault<CrmCompanyPersonViewModel>((IEnumerable<CrmCompanyPersonViewModel>)list, (Func<CrmCompanyPersonViewModel, bool>)((CrmCompanyPersonViewModel x) => arr[a].ToString() == x.CompanyPersonID.ToString())) == null)
					{
						List<CrmCompanyPersonViewModel> companyPersonsByIds = GetCompanyPersonsByIds(0, arr[a], prsWorkingOut);
						if (companyPersonsByIds != null)
						{
							list.AddRange(companyPersonsByIds);
						}
					}
				}
			}
			foreach (CrmCompanyPersonViewModel item in list)
			{
				if (item.prsIsMarried.HasValue)
				{
					if (item.prsIsMarried.GetValueOrDefault())
					{
						item.prsIsMarriedStr = Labels.prsMarried;
					}
					else
					{
						item.prsIsMarriedStr = Labels.prsSingle;
					}
				}
				else
				{
					item.prsIsMarriedStr = "";
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCompanyPersons(int cmpId = 0, int pageSize = 50, int lastRowNumber = 0, string prsIds = "", string val = "", bool? prsWorkingOut = null)
	{
		return JsonConvert.SerializeObject(GetCompanyPersonsList(cmpId, pageSize, lastRowNumber, prsIds, val, prsWorkingOut));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CrmCompanyPersonViewModel> GetCompanyPersonsByIds(int cmpId = 0, string prsIds = "", bool? prsWorkingOut = null)
	{
		List<CrmCompanyPersonViewModel> list = null;
		try
		{
			List<CRMspSelectCompanyPersonsByIds_Result> list2 = CRMIdeal.Classes.Helper.Company.SelectCompanyPersonsByIds(cmpId, prsIds, ",", prsWorkingOut);
			if (list2 != null)
			{
				list = new List<CrmCompanyPersonViewModel>();
				list.AddRange(Enumerable.Select<CRMspSelectCompanyPersonsByIds_Result, CrmCompanyPersonViewModel>((IEnumerable<CRMspSelectCompanyPersonsByIds_Result>)list2, (Func<CRMspSelectCompanyPersonsByIds_Result, CrmCompanyPersonViewModel>)((CRMspSelectCompanyPersonsByIds_Result x) => new CrmCompanyPersonViewModel
				{
					RowNumber = -1L,
					CompanyPersonID = x.CompanyPersonID,
					prsCompanyId = x.prsCompanyId,
					prsLName = x.prsLName,
					prsFName = x.prsFName,
					prsTitleId = x.prsTitleId,
					prsTitleIdStr = x.prsTitle,
					prsJobId = x.prsJobId,
					prsJobIdStr = x.prsJob,
					prsDepartmentId = x.prsDepartmentId,
					prsDepartmentIdStr = x.prsDepartment,
					prsMobile = x.prsMobile,
					prsPreTel = x.prsPreTel,
					prsTel = x.prsTel,
					prsTelUpTo = x.prsTelUpTo,
					prsTelDesc = x.prsTelDesc,
					prsTelII = x.prsTelII,
					prsFax = x.prsFax,
					prsFaxDesc = x.prsFaxDesc,
					prsEmail = x.prsEmail,
					prsDescription = x.prsDescription,
					prsAddress = x.prsAddress,
					prsAddressDesc = x.prsAddressDesc,
					prsEmailII = x.prsEmailII,
					ImportDate = x.ImportDate,
					prsFirstRegisterUserId = x.prsFirstRegisterUserId,
					prsWorkingOut = x.prsWorkingOut,
					prsOrderView = x.prsOrderView,
					UserId = x.UserId,
					Year1 = x.Year1,
					Month1 = x.Month1,
					RegisterDate = x.RegisterDate,
					RegisterDatePersian = x.RegisterDatePersian,
					AddType = x.AddType,
					CompanyPersonTemplateID = x.CompanyPersonTemplateID,
					prsTypeId = x.prsTypeId,
					prsTypeIdStr = x.prsType,
					prsGroupId = x.prsGroupId,
					prsGroupIdStr = x.prsGroup,
					prsSexId = x.prsSexId,
					prsSexIdStr = x.prsSex,
					prsEducationId = x.prsEducationId,
					prsEducationIdStr = x.prsEducation,
					prsWebSite = x.prsWebSite,
					prsCountryId = x.prsCountryId,
					prsCountryIdStr = x.prsCountry,
					prsProvinceId = x.prsProvinceId,
					prsProvinceIdStr = x.prsProvince,
					prsCityId = x.prsCityId,
					prsCityIdStr = x.prsCity,
					prsZipCode = x.prsZipCode,
					prsPostBox = x.prsPostBox,
					prsNationalCode = x.prsNationalCode,
					prsIdentityNumber = x.prsIdentityNumber,
					prsFatherName = x.prsFatherName,
					prsBirthDate = x.prsBirthDate,
					prsBirthPlace = x.prsBirthPlace,
					prsIsMarried = x.prsIsMarried,
					prsMarriageDate = x.prsMarriageDate,
					prsEducationField = x.prsEducationField,
					prsSkill = x.prsSkill,
					prsStudyField = x.prsStudyField,
					prsInteresting = x.prsInteresting,
					prsSpecialPoint = x.prsSpecialPoint,
					prsStopSendSms = x.prsStopSendSms,
					prsFirstRegisterUserIdStr = x.FirstRegisterUser,
					UserIdStr = x.EditUser,
					AppType = x.AppType,
					prsUserName = x.prsUserName,
					prsPassword = x.prsPassword,
					prsFOIsActive = x.prsFOIsActive,
					prsFOActiveDate = x.prsFOActiveDate,
					prsFOActiveDatePersian = x.prsFOActiveDatePersian,
					prsFOActiveUserId = x.prsFOActiveUserId,
					prsFOActiveUser = x.prsFOActiveUser,
					prsFOLoginExpireDate = x.prsFOLoginExpireDate,
					prsFOLoginExpireDatePersian = x.prsFOLoginExpireDatePersian,
					prsFOLoginExpireUserId = x.prsFOLoginExpireUserId,
					prsFOLoginExpireUser = x.prsFOLoginExpireUser,
					prsCIds = x.prsCIds,
					prsFOInfo = x.prsFOInfo,
					prsFOInfoExtra = CRMIdeal.Classes.Helper.Company.GetFoInfoJsonByName(x.prsFOInfo, x.prsCIds)
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCompanyPersonsById_Json(int cmpId = 0, string prsIds = "", bool? prsWorkingOut = null)
	{
		return JsonConvert.SerializeObject(GetCompanyPersonsByIds(cmpId, prsIds, prsWorkingOut));
	}
}
