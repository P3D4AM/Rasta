using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using Mobile.Cache;
using Mobile.Cache.Setting;
using Mobile.Cache.User;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class PermissionController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<PermissionViewModel>> GetPermissions(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<PermissionViewModel> data = null;
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
					Info.Update(token2.userId, true);
					Permissions.Update(token2.userId);
					Manager.UpdateAllSettingCach();
					List<PermissionViewModel> list = new List<PermissionViewModel>();
					PermissionViewModel permissionViewModel = new PermissionViewModel();
					Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
					MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
					dictionary = Enumerable.ToDictionary<MobspSelectUserRollPermission_Result, string, bool>(Enumerable.Where<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)Permissions.Get(token2.userId, cId), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result c) => c.FormName == "frmCompanyI")), (Func<MobspSelectUserRollPermission_Result, string>)((MobspSelectUserRollPermission_Result item) => item.ActionName), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result item) => true));
					dictionary.Add("CantSaveDupPrsMob", mobspSelectCrmsysSetting_Result != null && mobspSelectCrmsysSetting_Result.CantSaveDupPrsMob.HasValue && mobspSelectCrmsysSetting_Result.CantSaveDupPrsMob != false);
					dictionary.Add("CantSaveDupPrsEmail", mobspSelectCrmsysSetting_Result != null && mobspSelectCrmsysSetting_Result.CantSaveDupPrsEmail.HasValue && mobspSelectCrmsysSetting_Result.CantSaveDupPrsEmail != false);
					dictionary.Add("DisablefrmcmpSearchOnType", mobspSelectCrmsysSetting_Result != null && mobspSelectCrmsysSetting_Result.DisablefrmcmpSearchOnType.HasValue && mobspSelectCrmsysSetting_Result.DisablefrmcmpSearchOnType != false);
					permissionViewModel = new PermissionViewModel
					{
						FormName = "frmCompanyI",
						ActionName = dictionary
					};
					list.Add(permissionViewModel);
					dictionary = Enumerable.ToDictionary<MobspSelectUserRollPermission_Result, string, bool>(Enumerable.Where<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)Permissions.Get(token2.userId, cId), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result c) => c.FormName == "frmDefineCompany")), (Func<MobspSelectUserRollPermission_Result, string>)((MobspSelectUserRollPermission_Result item) => item.ActionName), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result item) => true));
					permissionViewModel = new PermissionViewModel
					{
						FormName = "frmDefineCompany",
						ActionName = dictionary
					};
					list.Add(permissionViewModel);
					dictionary = Enumerable.ToDictionary<MobspSelectUserRollPermission_Result, string, bool>(Enumerable.Where<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)Permissions.Get(token2.userId, cId), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result c) => c.FormName == "frmDefineCompanyPerson")), (Func<MobspSelectUserRollPermission_Result, string>)((MobspSelectUserRollPermission_Result item) => item.ActionName), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result item) => true));
					permissionViewModel = new PermissionViewModel
					{
						FormName = "frmDefineCompanyPerson",
						ActionName = dictionary
					};
					list.Add(permissionViewModel);
					dictionary = Enumerable.ToDictionary<MobspSelectUserRollPermission_Result, string, bool>(Enumerable.Where<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)Permissions.Get(token2.userId, cId), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result c) => c.FormName == "frmDefineProjects")), (Func<MobspSelectUserRollPermission_Result, string>)((MobspSelectUserRollPermission_Result item) => item.ActionName), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result item) => true));
					permissionViewModel = new PermissionViewModel
					{
						FormName = "frmDefineProjects",
						ActionName = dictionary
					};
					list.Add(permissionViewModel);
					dictionary = Enumerable.ToDictionary<MobspSelectUserRollPermission_Result, string, bool>(Enumerable.Where<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)Permissions.Get(token2.userId, cId), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result c) => c.FormName == "frmDefineConversation")), (Func<MobspSelectUserRollPermission_Result, string>)((MobspSelectUserRollPermission_Result item) => item.ActionName), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result item) => true));
					dictionary.Add("MustFullCnvsRemindDate", mobspSelectCrmsysSetting_Result != null && mobspSelectCrmsysSetting_Result.MustFullcnvsRemindDate.HasValue && mobspSelectCrmsysSetting_Result.MustFullcnvsRemindDate != false);
					permissionViewModel = new PermissionViewModel
					{
						FormName = "frmDefineConversation",
						ActionName = dictionary
					};
					list.Add(permissionViewModel);
					dictionary = Enumerable.ToDictionary<MobspSelectUserRollPermission_Result, string, bool>(Enumerable.Where<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)Permissions.Get(token2.userId, cId), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result c) => c.FormName == "frmMain")), (Func<MobspSelectUserRollPermission_Result, string>)((MobspSelectUserRollPermission_Result item) => item.ActionName), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result item) => true));
					permissionViewModel = new PermissionViewModel
					{
						FormName = "frmMain",
						ActionName = dictionary
					};
					list.Add(permissionViewModel);
					dictionary = Enumerable.ToDictionary<MobspSelectUserRollPermission_Result, string, bool>(Enumerable.Where<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)Permissions.Get(token2.userId, cId), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result c) => c.FormName == "frmInternalMessageNew")), (Func<MobspSelectUserRollPermission_Result, string>)((MobspSelectUserRollPermission_Result item) => item.ActionName), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result item) => true));
					permissionViewModel = new PermissionViewModel
					{
						FormName = "frmInternalMessageNew",
						ActionName = dictionary
					};
					list.Add(permissionViewModel);
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
		return new ServiceResult<List<PermissionViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<PermissionViewModel>> GetPermissionsByFormName(string formName, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<PermissionViewModel> data = null;
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
					if (!string.IsNullOrEmpty(formName))
					{
						Info.Update(token2.userId, true);
						Permissions.Update(token2.userId);
						Manager.UpdateAllSettingCach();
						List<PermissionViewModel> list = new List<PermissionViewModel>();
						PermissionViewModel permissionViewModel = new PermissionViewModel();
						Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
						dictionary = Enumerable.ToDictionary<MobspSelectUserRollPermission_Result, string, bool>(Enumerable.Where<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)Permissions.Get(token2.userId, cId), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result c) => c.FormName == formName)), (Func<MobspSelectUserRollPermission_Result, string>)((MobspSelectUserRollPermission_Result item) => item.ActionName), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result item) => true));
						permissionViewModel = new PermissionViewModel
						{
							FormName = formName,
							ActionName = dictionary
						};
						list.Add(permissionViewModel);
						data = list;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorParamHaveNotCorrectlyInitialized;
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
		return new ServiceResult<List<PermissionViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DbObjectFieldViewModel>> SelectSysDbObjectsNotNull(string objectName = "", int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DbObjectFieldViewModel> data = null;
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
					objectName = ((!string.IsNullOrEmpty(objectName)) ? objectName : "CrmCompany");
					List<MobspSelectsysDBObjects_Result> list = Enumerable.ToList<MobspSelectsysDBObjects_Result>((IEnumerable<MobspSelectsysDBObjects_Result>)cRMEntities.MobspSelectsysDBObjects(result, result2));
					List<DbObjectFieldViewModel> list2 = new List<DbObjectFieldViewModel>();
					Dictionary<string, bool> fieldName = Enumerable.ToDictionary<MobspSelectsysDBObjects_Result, string, bool>(Enumerable.Where<MobspSelectsysDBObjects_Result>((IEnumerable<MobspSelectsysDBObjects_Result>)list, (Func<MobspSelectsysDBObjects_Result, bool>)((MobspSelectsysDBObjects_Result item) => objectName == item.ObjectName)), (Func<MobspSelectsysDBObjects_Result, string>)((MobspSelectsysDBObjects_Result item) => item.Title), (Func<MobspSelectsysDBObjects_Result, bool>)((MobspSelectsysDBObjects_Result item) => item.NotNull.HasValue && item.NotNull != false));
					DbObjectFieldViewModel item2 = new DbObjectFieldViewModel
					{
						ObjectName = objectName,
						FieldName = fieldName
					};
					list2.Add(item2);
					data = list2;
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
		return new ServiceResult<List<DbObjectFieldViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectCrmsysSetting_Result>> GetCrmsysSetting(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectCrmsysSetting_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)cRMEntities.MobspSelectCrmsysSetting(result, result2));
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
		return new ServiceResult<List<MobspSelectCrmsysSetting_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<Dictionary<string, bool>> GetSysSettingSmartTimeAttendance(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		Dictionary<string, bool> dictionary = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			string text = "";
			if (base.Request.Headers.Contains("extra"))
			{
				text = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
			}
			if (new Common().CheckExtra(text))
			{
				if (base.Request.Headers.Contains("token"))
				{
					if (Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token")) == text)
					{
						cRMEntities = new CRMEntities();
						dictionary = new Dictionary<string, bool>();
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)cRMEntities.MobspSelectCrmsysSetting(result, result2));
						if (mobspSelectCrmsysSetting_Result != null)
						{
							dictionary.Add("SmartTimeAttendance", mobspSelectCrmsysSetting_Result.SmartTimeAttendance.HasValue && mobspSelectCrmsysSetting_Result.SmartTimeAttendance != false);
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorAccessingToken;
						dictionary = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					dictionary = null;
					status = ServiceResultStatus.Error;
				}
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			dictionary = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<Dictionary<string, bool>>
		{
			Message = message,
			Data = dictionary,
			Status = status
		};
	}
}
