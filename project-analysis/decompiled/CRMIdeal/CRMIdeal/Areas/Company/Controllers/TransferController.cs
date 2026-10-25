using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Company.Controllers;

public class TransferController : Controller
{
	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index()
	{
		return View();
	}

	[LoginAuthorize]
	public ActionResult TransferToAnotherCompany(int cmpId = 0, int prjId = 0)
	{
		CRMspSelectCrmProjectsById_Result model = new CRMspSelectCrmProjectsById_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(prjId, lCID, result));
				if (cRMspSelectCrmProjectsById_Result != null)
				{
					model = cRMspSelectCrmProjectsById_Result;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return View(model);
	}

	[HttpPost]
	[LoginAuthorize]
	public string TransferToAnotherCompany(int fromCmpId = 0, int toCmpId = 0, bool? userAllowedToTransferWithoutNewFKeys = null)
	{
		string result = "";
		try
		{
			List<CRMspTransferCompanyOperationToAnotherCompany_Result> list = Enumerable.ToList<CRMspTransferCompanyOperationToAnotherCompany_Result>((IEnumerable<CRMspTransferCompanyOperationToAnotherCompany_Result>)_dbII.CRMspTransferCompanyOperationToAnotherCompany(fromCmpId, toCmpId, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), userAllowedToTransferWithoutNewFKeys));
			if (list != null)
			{
				if (list.Count > 0)
				{
					result = JsonConvert.SerializeObject(list);
				}
				else
				{
					new PendingOperations().StartPendingOperations();
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetTransferCompanyDetails(int fromCmpId = 0, int toCmpId = 0, int fromPrjId = 0)
	{
		TransferCompanyViewModel transferCompanyViewModel = new TransferCompanyViewModel();
		try
		{
			ObjectParameter objectParameter = new ObjectParameter("FoundedPrjId", 0);
			int result = 0;
			_dbII.CRMspTransferCompanySearchProject(fromCmpId, toCmpId, fromPrjId, objectParameter);
			int.TryParse(objectParameter.Value.ToString(), out result);
			if (result != 0)
			{
				transferCompanyViewModel.FromPrjInfo = GetProjectById(fromPrjId);
				transferCompanyViewModel.ToPrjInfo = GetProjectById(result);
				List<CRMspTransferCompanySearchPersons_Result> list = Enumerable.ToList<CRMspTransferCompanySearchPersons_Result>((IEnumerable<CRMspTransferCompanySearchPersons_Result>)_dbII.CRMspTransferCompanySearchPersons(fromCmpId, toCmpId));
				if (list != null)
				{
					foreach (CRMspTransferCompanySearchPersons_Result item in list)
					{
						TransferCompanyViewModel.PrsInfo prsInfo = new TransferCompanyViewModel.PrsInfo();
						prsInfo.FromPrsInfo = GetPersonById(item.FromPrsId);
						if (!string.IsNullOrWhiteSpace(item.ToPrsIds))
						{
							string[] array = item.ToPrsIds.Split(new char[1] { ',' });
							for (int i = 0; i < array.Length; i++)
							{
								if (!string.IsNullOrWhiteSpace(array[i]))
								{
									prsInfo.ToPrsInfo.Add(GetPersonById(int.Parse(array[i])));
								}
							}
						}
						transferCompanyViewModel.PrsList.Add(prsInfo);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(transferCompanyViewModel);
	}

	[HttpPost]
	[LoginAuthorize]
	public CRMspSelectCrmProjectsById_Result GetProjectById(int id = 0)
	{
		CRMspSelectCrmProjectsById_Result result = new CRMspSelectCrmProjectsById_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (id != 0)
			{
				CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(id, lCID, result2));
				if (cRMspSelectCrmProjectsById_Result != null)
				{
					result = cRMspSelectCrmProjectsById_Result;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public CRMspSelectCompanyPersonsByID_Result GetPersonById(int id = 0)
	{
		CRMspSelectCompanyPersonsByID_Result result = new CRMspSelectCompanyPersonsByID_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (id != 0)
			{
				CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(id, lCID, result2));
				if (cRMspSelectCompanyPersonsByID_Result != null)
				{
					result = cRMspSelectCompanyPersonsByID_Result;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SearchCompany(string val = "")
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
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspMainSearchWebSmart_Result> list = Enumerable.ToList<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)_dbI.CRMspMainSearchWebSmart(val, UserLogin.CurrentUser.UserId, 1, lCID, result2, "", result3));
			if (list != null)
			{
				foreach (CRMspMainSearchWebSmart_Result item in list)
				{
					item.cmpCoordinateLastDatePersian = item.cmpCoordinateLastDate?.ToString("yyyy/MM/dd HH:mm");
					item.cmpEffectiveDatePersian = item.cmpEffectiveDateTime?.ToString("yyyy/MM/dd HH:mm");
					item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
					item.ImportDate = item.ImportDateTime?.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				}
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}
}
