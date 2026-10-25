using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Web.Http;
using CRM.General.IO.FTP;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class DeleteController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> Company(int cmpId, int? cId = null, int? ln = null)
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
					if (!UserLogin.IsUserAccess("frmCompanyI", "actDelete", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = cmpId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)cRMEntities.MobspSelectCompanyWithID(cmpId, token2.userId, result, result2, cId)) == null)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorIsNotCompany,
							Data = cmpId,
							Status = ServiceResultStatus.Error
						};
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteCrmCompany(cmpId));
					int result3 = 0;
					int.TryParse(num.ToString(), out result3);
					if (result3 == 1)
					{
						data = cmpId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = cmpId;
						message = Messages.MobMsgErrorRedundancy;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = cmpId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = cmpId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = cmpId;
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
	public ServiceResult<int> Person(int prsId, int? cId = null, int? ln = null)
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
					if (!UserLogin.IsUserAccess("frmCompanyI", "actprsDelete", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = prsId,
							Status = ServiceResultStatus.Fail
						};
					}
					MobspSelectPersonWithID_Result mobspSelectPersonWithID_Result = Enumerable.FirstOrDefault<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)cRMEntities.MobspSelectPersonWithID(prsId, result, result2));
					if (mobspSelectPersonWithID_Result == null)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorIsNotCompanyPerson,
							Data = prsId,
							Status = ServiceResultStatus.Error
						};
					}
					if (Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)cRMEntities.MobspSelectCompanyWithID(mobspSelectPersonWithID_Result.prsCompanyId, token2.userId, result, result2, cId)) == null)
					{
						return new ServiceResult<int>
						{
							Message = string.Format(Messages.MobMsgErrorrNotAccessToCompany, mobspSelectPersonWithID_Result.prsCompany),
							Data = prsId,
							Status = ServiceResultStatus.Error
						};
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteCrmCompanyPerson(prsId));
					int result3 = 0;
					int.TryParse(num.ToString(), out result3);
					if (result3 == 1)
					{
						data = prsId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = prsId;
						message = Messages.MobMsgErrorRedundancy;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = prsId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = prsId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = prsId;
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
	public ServiceResult<int> Project(int cmpId, int prjId, int prjCnvsStatusGroupId, int? cId = null, int? ln = null)
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
					if (!UserLogin.IsUserAccess("frmProjectPreview", "actDelete", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = prjId,
							Status = ServiceResultStatus.Fail
						};
					}
					MobspSelectProjectWithID_Result prj = Enumerable.FirstOrDefault<MobspSelectProjectWithID_Result>((IEnumerable<MobspSelectProjectWithID_Result>)cRMEntities.MobspSelectProjectWithID(prjId, result, result2));
					if (prj == null)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorIsNotProject,
							Data = prjId,
							Status = ServiceResultStatus.Error
						};
					}
					if (Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)cRMEntities.MobspSelectCompanyWithID(prj.prjCompanyId, token2.userId, result, result2, cId)) == null)
					{
						return new ServiceResult<int>
						{
							Message = string.Format(Messages.MobMsgErrorrNotAccessToCompany, prj.prjCompany),
							Data = prjId,
							Status = ServiceResultStatus.Error
						};
					}
					List<MobspSelectProjectsList_Result> list = Enumerable.ToList<MobspSelectProjectsList_Result>((IEnumerable<MobspSelectProjectsList_Result>)cRMEntities.MobspSelectProjectsList(prj.prjCompanyId, 0, token2.userId, result, result2, cId));
					if (list != null && Enumerable.FirstOrDefault<MobspSelectProjectsList_Result>((IEnumerable<MobspSelectProjectsList_Result>)list, (Func<MobspSelectProjectsList_Result, bool>)((MobspSelectProjectsList_Result m) => m.ProjectID == prj.ProjectID)) == null)
					{
						return new ServiceResult<int>
						{
							Message = string.Format(Messages.MobMsgErrorrNotAccessToProject, prj.ProjectTitle),
							Data = prjId,
							Status = ServiceResultStatus.Error
						};
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteCrmProject(prjId, cmpId, prjCnvsStatusGroupId));
					int result3 = 0;
					int.TryParse(num.ToString(), out result3);
					if (result3 == 1)
					{
						data = prjId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = prjId;
						message = Messages.MobMsgErrorRedundancy;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = prjId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = prjId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = prjId;
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
	public ServiceResult<int> Conversation(int cnvsId, int? cId = null, int? ln = null)
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
					if (!UserLogin.IsUserAccess("frmCompanyI", "actcnvsDelete", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = cnvsId,
							Status = ServiceResultStatus.Fail
						};
					}
					MobspSelectConversationWithID_Result cnvs = Enumerable.FirstOrDefault<MobspSelectConversationWithID_Result>((IEnumerable<MobspSelectConversationWithID_Result>)cRMEntities.MobspSelectConversationWithID(cnvsId, result, result2));
					if (cnvs == null)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorIsNotConversation,
							Data = cnvsId,
							Status = ServiceResultStatus.Error
						};
					}
					if (Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)cRMEntities.MobspSelectCompanyWithID(cnvs.cnvsCompanyId, token2.userId, result, result2, cId)) == null)
					{
						return new ServiceResult<int>
						{
							Message = string.Format(Messages.MobMsgErrorrNotAccessToCompany, cnvs.cnvsCompany),
							Data = cnvsId,
							Status = ServiceResultStatus.Error
						};
					}
					List<MobspSelectProjectsList_Result> list = Enumerable.ToList<MobspSelectProjectsList_Result>((IEnumerable<MobspSelectProjectsList_Result>)cRMEntities.MobspSelectProjectsList(cnvs.cnvsCompanyId, 0, token2.userId, result, result2, cId));
					if (list != null && Enumerable.FirstOrDefault<MobspSelectProjectsList_Result>((IEnumerable<MobspSelectProjectsList_Result>)list, (Func<MobspSelectProjectsList_Result, bool>)((MobspSelectProjectsList_Result m) => m.ProjectID == cnvs.cnvsProjectId)) == null)
					{
						return new ServiceResult<int>
						{
							Message = string.Format(Messages.MobMsgErrorrNotAccessToProject, cnvs.cnvsProject),
							Data = cnvsId,
							Status = ServiceResultStatus.Error
						};
					}
					if (cnvs.cnvsReferUserId != token2.userId && Enumerable.FirstOrDefault<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 10, result, result2, cId, true), (Func<MobspSelectUserForLinkedType_Result, bool>)((MobspSelectUserForLinkedType_Result m) => m.Id == cnvs.cnvsReferUserId)) == null)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorUserCanNotCnvsDelete,
							Data = cnvsId,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities.MobspDyDeleteFormFieldMasterValuesBySysPart(cnvsId, "cnvs");
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
					if (result3 <= 0)
					{
						result3 = 1065;
					}
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					if (cnvs != null)
					{
						List<MobspSelectFilesDirectory_Result> list2 = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(cnvs.cnvsCompanyId.ToString(), cnvs.cnvsPersonId.ToString(), cnvs.cnvsProjectId.ToString(), "2", cnvs.ConversationID.ToString(), lCID, result3, false, cId));
						if (list2 != null && Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list2))
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorItemHasFiles,
								Data = cnvsId,
								Status = ServiceResultStatus.Fail
							};
						}
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteCrmConversation(cnvsId));
					int result4 = 0;
					int.TryParse(num.ToString(), out result4);
					if (result4 == 1)
					{
						data = cnvsId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = cnvsId;
						message = Messages.MobMsgErrorRedundancy;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = cnvsId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = cnvsId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = cnvsId;
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
	public ServiceResult<int> File(int fileId, int? ln = null)
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (fileId > 0)
					{
						MobspSelectCrmFilesDirectory_Result mobspSelectCrmFilesDirectory_Result = Enumerable.FirstOrDefault<MobspSelectCrmFilesDirectory_Result>((IEnumerable<MobspSelectCrmFilesDirectory_Result>)cRMEntities.MobspSelectCrmFilesDirectory(fileId));
						if (mobspSelectCrmFilesDirectory_Result == null)
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorFileNotExist,
								Data = fileId,
								Status = ServiceResultStatus.Error
							};
						}
						string text = mobspSelectCrmFilesDirectory_Result.FilePath.ToLower().Replace(Mobile.Classes.Configuration.PathFtp.ToLower(), "");
						text = ((!text.Contains("/" + Mobile.Classes.Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Mobile.Classes.Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Mobile.Classes.Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "\\")) ? (Mobile.Classes.Configuration.MainDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.DyDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.KnlgTDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.IntmsgDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName));
						FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
						string destination = text;
						if (facadeFTP.Delete(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, mobspSelectCrmFilesDirectory_Result.FileName, destination, Mobile.Classes.Configuration.UsePassiveFtp))
						{
							int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteCrmFilesDirectory(fileId));
							int result3 = 0;
							int.TryParse(num.ToString(), out result3);
							if (result3 == 1)
							{
								data = fileId;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
							else
							{
								data = fileId;
								message = Messages.MobMsgErrorDoneOperation;
								status = ServiceResultStatus.Fail;
							}
						}
						else
						{
							data = fileId;
							message = Messages.MobMsgErrorInDeleteFileFromFtp;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErrorFileNotExist;
						data = fileId;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = fileId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = fileId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = fileId;
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
	public ServiceResult<int> PreOrder(int pordId, int? ln = null, int? cId = null)
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
					if (!UserLogin.IsUserAccess("frmPreOrder", "actDelete", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = pordId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, token2.userId, result, result2, cId)) == null)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorPreOrderNotFound,
							Data = pordId,
							Status = ServiceResultStatus.Error
						};
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteWSPreOrder(pordId));
					int result3 = 0;
					int.TryParse(num.ToString(), out result3);
					if (result3 == 1)
					{
						data = pordId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = pordId;
						message = Messages.MobMsgErrorRedundancy;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = pordId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = pordId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = pordId;
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
	public ServiceResult<int> Order(int ordId, int? ln = null, int? cId = null)
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
					if (!UserLogin.IsUserAccess("frmOrder", "actDelete", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = ordId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(ordId, token2.userId, result, result2, cId)) == null)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorPreOrderNotFound,
							Data = ordId,
							Status = ServiceResultStatus.Error
						};
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteWSOrder(ordId));
					int result3 = 0;
					int.TryParse(num.ToString(), out result3);
					if (result3 == 1)
					{
						data = ordId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = ordId;
						message = Messages.MobMsgErrorRedundancy;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = ordId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = ordId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = ordId;
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
	public ServiceResult<int> PreOrderItem(int pordItemId, int? ln = null, int? cId = null)
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (!UserLogin.IsUserAccess("frmPreOrder", "actRemoveProduct", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = pordItemId,
							Status = ServiceResultStatus.Fail
						};
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteWSPreOrderItems(pordItemId));
					int result3 = 0;
					int.TryParse(num.ToString(), out result3);
					switch (result3)
					{
					case 1:
						data = pordItemId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
						break;
					case -2:
						data = pordItemId;
						message = Messages.MobMsgErrorPreOrderItemNotFound;
						status = ServiceResultStatus.Fail;
						break;
					default:
						data = pordItemId;
						message = Messages.MobMsgErrorRedundancy;
						status = ServiceResultStatus.Fail;
						break;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = pordItemId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = pordItemId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = pordItemId;
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
	public ServiceResult<int> PreOrderPayment(int pordPaymentId, int? ln = null, int? cId = null)
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (!UserLogin.IsUserAccess("frmPreOrder", "actDeletePay", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = pordPaymentId,
							Status = ServiceResultStatus.Fail
						};
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteWSPreOrderPayments(pordPaymentId));
					int result3 = 0;
					int.TryParse(num.ToString(), out result3);
					switch (result3)
					{
					case 1:
						data = pordPaymentId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
						break;
					case -2:
						data = pordPaymentId;
						message = Messages.MobMsgErrorPreOrderPaymentNotFound;
						status = ServiceResultStatus.Fail;
						break;
					default:
						data = pordPaymentId;
						message = Messages.MobMsgErrorRedundancy;
						status = ServiceResultStatus.Fail;
						break;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = pordPaymentId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = pordPaymentId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = pordPaymentId;
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
	public ServiceResult<int> OrderItem(int ordItemId, int? ln = null, int? cId = null)
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (!UserLogin.IsUserAccess("frmOrder", "actRemoveProduct", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = ordItemId,
							Status = ServiceResultStatus.Fail
						};
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteWSOrderItems(ordItemId));
					int result3 = 0;
					int.TryParse(num.ToString(), out result3);
					switch (result3)
					{
					case 1:
						data = ordItemId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
						break;
					case -2:
						data = ordItemId;
						message = Messages.MobMsgErrorPreOrderItemNotFound;
						status = ServiceResultStatus.Fail;
						break;
					default:
						data = ordItemId;
						message = Messages.MobMsgErrorRedundancy;
						status = ServiceResultStatus.Fail;
						break;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = ordItemId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = ordItemId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = ordItemId;
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
	public ServiceResult<int> OrderPayment(int ordPaymentId, int? ln = null, int? cId = null)
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (!UserLogin.IsUserAccess("frmOrder", "actDeletePay", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = ordPaymentId,
							Status = ServiceResultStatus.Fail
						};
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteWSOrderPayments(ordPaymentId));
					int result3 = 0;
					int.TryParse(num.ToString(), out result3);
					switch (result3)
					{
					case 1:
						data = ordPaymentId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
						break;
					case -2:
						data = ordPaymentId;
						message = Messages.MobMsgErrorPreOrderPaymentNotFound;
						status = ServiceResultStatus.Fail;
						break;
					default:
						data = ordPaymentId;
						message = Messages.MobMsgErrorRedundancy;
						status = ServiceResultStatus.Fail;
						break;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = ordPaymentId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = ordPaymentId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = ordPaymentId;
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
	public ServiceResult<string> DeleteAllCmpWithDep(int cmpId, int? ln = null, int? cId = null)
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
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (!UserLogin.IsUserAccess("frmCompanyI", "actDeleteAllCmpWithDep", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					mct_Result_StrI mct_Result_StrI = Enumerable.FirstOrDefault<mct_Result_StrI>((IEnumerable<mct_Result_StrI>)cRMEntities.MobspDeleteAllCompanyWithDependencies(cmpId, cId));
					string text = "";
					if (mct_Result_StrI != null && !string.IsNullOrWhiteSpace(mct_Result_StrI.Result))
					{
						string[] array = mct_Result_StrI.Result.Split(new char[1] { '|' });
						if (array != null)
						{
							if (array[0] == "1")
							{
								List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(cmpId.ToString(), "0", "0", "1", "0", num, result2, true, cId));
								try
								{
									if ((list != null) & Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list))
									{
										foreach (MobspSelectFilesDirectory_Result item in list)
										{
											DeleteFileByPath(item.FilePath, item.FileName, item.FolderName);
										}
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
								}
								text = "";
							}
							else if (array[0] == "0")
							{
								text = Messages.msgErrorRunFunction;
							}
							else
							{
								if (mct_Result_StrI.Result.IndexOf("-1", StringComparison.Ordinal) >= 0)
								{
									text = text + "msgErrCmpHasOrd".OrderMessages() + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-2", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasBord + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-3", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasDoc + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-4", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasCtsh + "<br>";
								}
							}
						}
					}
					if (string.IsNullOrEmpty(text))
					{
						data = null;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						message = text;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DeleteAllCmpPersonsWithDep(int cmpId, int? ln = null, int? cId = null)
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
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (!UserLogin.IsUserAccess("frmCompanyI", "actDeleteAllCmpPersonsWithDep", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					mct_Result_StrI mct_Result_StrI = Enumerable.FirstOrDefault<mct_Result_StrI>((IEnumerable<mct_Result_StrI>)cRMEntities.MobspDeleteAllCompanyPersonsWithDependencies(cmpId, cId));
					string text = "";
					if (mct_Result_StrI != null && !string.IsNullOrWhiteSpace(mct_Result_StrI.Result))
					{
						string[] array = mct_Result_StrI.Result.Split(new char[1] { '|' });
						if (array != null)
						{
							if (array[0] == "1")
							{
								List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(cmpId.ToString(), "0", "0", "1", "0", num, result2, true, cId));
								try
								{
									if ((list != null) & Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list))
									{
										foreach (MobspSelectFilesDirectory_Result item in list)
										{
											DeleteFileByPath(item.FilePath, item.FileName, item.FolderName);
										}
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
								}
								text = "";
							}
							else if (array[0] == "0")
							{
								text = Messages.msgErrorRunFunction;
							}
							else
							{
								if (mct_Result_StrI.Result.IndexOf("-1", StringComparison.Ordinal) >= 0)
								{
									text = text + "msgErrCmpHasOrd".OrderMessages() + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-2", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasBord + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-3", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasDoc + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-4", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasCtsh + "<br>";
								}
							}
						}
					}
					if (string.IsNullOrEmpty(text))
					{
						data = null;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						message = text;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DeleteAllCmpOperationsWithDep(int cmpId, int prjId, int? ln = null, int? cId = null)
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
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (!UserLogin.IsUserAccess("frmCompanyI", "actDeleteAllCmpOperationsWithDep", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					mct_Result_StrI mct_Result_StrI = Enumerable.FirstOrDefault<mct_Result_StrI>((IEnumerable<mct_Result_StrI>)cRMEntities.MobspDeleteAllCompanyOperationsWithDependencies(cmpId, prjId));
					string text = "";
					if (mct_Result_StrI != null && !string.IsNullOrWhiteSpace(mct_Result_StrI.Result))
					{
						string[] array = mct_Result_StrI.Result.Split(new char[1] { '|' });
						if (array != null)
						{
							if (array[0] == "1")
							{
								List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(cmpId.ToString(), "0", prjId.ToString(), "1", "0", num, result2, true, cId));
								try
								{
									if ((list != null) & Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list))
									{
										foreach (MobspSelectFilesDirectory_Result item in list)
										{
											DeleteFileByPath(item.FilePath, item.FileName, item.FolderName);
										}
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
								}
								text = "";
							}
							else if (array[0] == "0")
							{
								text = Messages.msgErrorRunFunction;
							}
							else
							{
								if (mct_Result_StrI.Result.IndexOf("-1", StringComparison.Ordinal) >= 0)
								{
									text = text + "msgErrCmpHasOrd".OrderMessages() + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-2", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasBord + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-3", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasDoc + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-4", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasCtsh + "<br>";
								}
							}
						}
					}
					if (string.IsNullOrEmpty(text))
					{
						data = null;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						message = text;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DeleteAllCmpProjectsWithDep(int cmpId, int? ln = null, int? cId = null)
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
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (!UserLogin.IsUserAccess("frmProjectPreview", "actDeleteAllCmpProjectsWithDep", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					mct_Result_StrI mct_Result_StrI = Enumerable.FirstOrDefault<mct_Result_StrI>((IEnumerable<mct_Result_StrI>)cRMEntities.MobspDeleteAllCompanyProjectsWithDependencies(cmpId));
					string text = "";
					if (mct_Result_StrI != null && !string.IsNullOrWhiteSpace(mct_Result_StrI.Result))
					{
						string[] array = mct_Result_StrI.Result.Split(new char[1] { '|' });
						if (array != null)
						{
							if (array[0] == "1")
							{
								List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(cmpId.ToString(), "0", "0", "1", "0", num, result2, true, cId));
								try
								{
									if ((list != null) & Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list))
									{
										foreach (MobspSelectFilesDirectory_Result item in list)
										{
											DeleteFileByPath(item.FilePath, item.FileName, item.FolderName);
										}
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
								}
								text = "";
							}
							else if (array[0] == "0")
							{
								text = Messages.msgErrorRunFunction;
							}
							else
							{
								if (mct_Result_StrI.Result.IndexOf("-1", StringComparison.Ordinal) >= 0)
								{
									text = text + "msgErrCmpHasOrd".OrderMessages() + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-2", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasBord + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-3", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasDoc + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-4", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasCtsh + "<br>";
								}
							}
						}
					}
					if (string.IsNullOrEmpty(text))
					{
						data = null;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						message = text;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DeleteCmpProjectWithDep(int cmpId, int prjId, int? ln = null, int? cId = null)
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
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (!UserLogin.IsUserAccess("frmProjectPreview", "actDelete", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					mct_Result_StrI mct_Result_StrI = Enumerable.FirstOrDefault<mct_Result_StrI>((IEnumerable<mct_Result_StrI>)cRMEntities.MobspDeleteCompanyProjectWithDependencies(prjId));
					string text = "";
					if (mct_Result_StrI != null && !string.IsNullOrWhiteSpace(mct_Result_StrI.Result))
					{
						string[] array = mct_Result_StrI.Result.Split(new char[1] { '|' });
						if (array != null)
						{
							if (array[0] == "1")
							{
								List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(cmpId.ToString(), "0", prjId.ToString(), "1", "0", num, result2, true, cId));
								try
								{
									if ((list != null) & Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list))
									{
										foreach (MobspSelectFilesDirectory_Result item in list)
										{
											DeleteFileByPath(item.FilePath, item.FileName, item.FolderName);
										}
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
								}
								text = "";
							}
							else if (array[0] == "0")
							{
								text = Messages.msgErrorRunFunction;
							}
							else
							{
								if (mct_Result_StrI.Result.IndexOf("-1", StringComparison.Ordinal) >= 0)
								{
									text = text + "msgErrCmpHasOrd".OrderMessages() + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-2", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasBord + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-3", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasDoc + "<br>";
								}
								if (mct_Result_StrI.Result.IndexOf("-4", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrCmpHasCtsh + "<br>";
								}
							}
						}
					}
					if (string.IsNullOrEmpty(text))
					{
						data = null;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						message = text;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public bool DeleteFileByPath(string filePath, string fileName, string folderName)
	{
		bool result = false;
		if (!string.IsNullOrWhiteSpace(filePath) && !string.IsNullOrWhiteSpace(fileName) && !string.IsNullOrWhiteSpace(folderName))
		{
			try
			{
				string text = filePath.ToLower().Replace(Mobile.Classes.Configuration.PathFtp.ToLower(), "");
				text = ((!text.Contains("/" + Mobile.Classes.Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Mobile.Classes.Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Mobile.Classes.Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Mobile.Classes.Configuration.FundDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.FundDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Mobile.Classes.Configuration.UserDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.UserDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Mobile.Classes.Configuration.CmsNewsDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.CmsNewsDirectoryPath.ToLower().Replace("/", "") + "\\")) ? (Mobile.Classes.Configuration.MainDirectoryPath + folderName + "/" + fileName) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.CmsNewsDirectoryPath + folderName + "/" + Mobile.Classes.Configuration.FilesDirectoryPath + "/" + fileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.UserDirectoryPath + folderName + "/" + fileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.FundDirectoryPath + folderName + "/" + fileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.DyDirectoryPath + folderName + "/" + fileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.KnlgTDirectoryPath + folderName + "/" + fileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.IntmsgDirectoryPath + folderName + "/" + fileName));
				FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
				string destination = text;
				if (facadeFTP.Delete(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, fileName, destination, Mobile.Classes.Configuration.UsePassiveFtp))
				{
					result = true;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> Doc(int docId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(docId, num, result2));
					if (mobspSelectDocById_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspSelectDocById_Result.OprType.ToString(), out result3);
						bool flag = false;
						switch (result3)
						{
						case 1:
							flag = UserLogin.IsUserAccess("frmDoc", "actDeleteDoc", UserLogin.CurrentUser, cId);
							break;
						case 2:
							flag = UserLogin.IsUserAccess("frmDraft", "actDeleteDraft", UserLogin.CurrentUser, cId);
							break;
						case 3:
							flag = UserLogin.IsUserAccess("frmWareHouseMovement", "actDeleteDoc", UserLogin.CurrentUser, cId);
							break;
						}
						if (!flag)
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						if (Mobile.Classes.Helper.Doc.IsFixed(docId))
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorNotActiveDoc,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						switch (result3)
						{
						case 1:
							cRMEntities.MobspDyDeleteFormFieldMasterValuesBySysPart(docId, "whdoc");
							break;
						case 2:
							cRMEntities.MobspDyDeleteFormFieldMasterValuesBySysPart(docId, "whdraft");
							break;
						case 3:
							cRMEntities.MobspDyDeleteFormFieldMasterValuesBySysPart(docId, "whmovement");
							break;
						}
						mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)Enumerable.ToList<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.MobspDeleteWSDoc(docId)));
						if (mct_I_Result != null && mct_I_Result.Result > 0)
						{
							data = null;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else if (mct_I_Result != null && mct_I_Result.Result == 0)
						{
							data = null;
							message = Messages.MobMsgErrorRedundancy;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
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
		catch (DbEntityValidationException e)
		{
			message = Messages.MobMsgErrorRedundancy;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
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
	public ServiceResult<string> DocItem(int docItemId, int docId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(docId, num, result2));
					if (mobspSelectDocById_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspSelectDocById_Result.OprType.ToString(), out result3);
						bool flag = false;
						switch (result3)
						{
						case 1:
							flag = UserLogin.IsUserAccess("frmDoc", "actDeleteDocItem", UserLogin.CurrentUser, cId);
							break;
						case 2:
							flag = UserLogin.IsUserAccess("frmDraft", "actDeleteDraftItem", UserLogin.CurrentUser, cId);
							break;
						case 3:
							flag = UserLogin.IsUserAccess("frmWareHouseMovement", "actDeleteDocItem", UserLogin.CurrentUser, cId);
							break;
						}
						if (!flag)
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						if (Mobile.Classes.Helper.Doc.IsFixed(docId))
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorNotActiveDoc,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)Enumerable.ToList<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.MobspDeleteWSDocItems(docItemId)));
						if (mct_I_Result != null && mct_I_Result.Result > 0)
						{
							data = null;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else if (mct_I_Result != null && mct_I_Result.Result == 0)
						{
							data = null;
							message = Messages.MobMsgErrorRedundancy;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
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
		catch (DbEntityValidationException e)
		{
			message = Messages.MobMsgErrorRedundancy;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
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
	public ServiceResult<string> DocItemWithLinked(int docItemId, int docId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(docId, num, result2));
					if (mobspSelectDocById_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspSelectDocById_Result.OprType.ToString(), out result3);
						bool flag = false;
						switch (result3)
						{
						case 1:
							flag = UserLogin.IsUserAccess("frmDoc", "actDeleteDocItemWithLinked", UserLogin.CurrentUser, cId);
							break;
						case 2:
							flag = UserLogin.IsUserAccess("frmDraft", "actDeleteDraftItemWithLinked", UserLogin.CurrentUser, cId);
							break;
						case 3:
							flag = UserLogin.IsUserAccess("frmWareHouseMovement", "actDeleteDocItemWithLinked", UserLogin.CurrentUser, cId);
							break;
						}
						if (!flag)
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						if (Mobile.Classes.Helper.Doc.IsFixed(docId))
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorNotActiveDoc,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)Enumerable.ToList<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.MobspDeleteDocItemWithLinkedPrd(docId, docItemId)));
						if (mct_I_Result != null && mct_I_Result.Result > 0)
						{
							data = null;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else if (mct_I_Result != null && mct_I_Result.Result == 0)
						{
							data = null;
							message = Messages.MobMsgErrorRedundancy;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
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
		catch (DbEntityValidationException e)
		{
			message = Messages.MobMsgErrorRedundancy;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
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
	public ServiceResult<string> DocItemSerial(int docItemSerialId, int docId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(docId, num, result2));
					if (mobspSelectDocById_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspSelectDocById_Result.OprType.ToString(), out result3);
						bool flag = false;
						switch (result3)
						{
						case 1:
							flag = UserLogin.IsUserAccess("frmDoc", "actDeleteItemSerial", UserLogin.CurrentUser, cId);
							break;
						case 2:
							flag = UserLogin.IsUserAccess("frmDraft", "actDeleteItemSerial", UserLogin.CurrentUser, cId);
							break;
						case 3:
							flag = UserLogin.IsUserAccess("frmWareHouseMovement", "actDeleteItemSerial", UserLogin.CurrentUser, cId);
							break;
						}
						if (!flag)
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						if (Mobile.Classes.Helper.Doc.IsFixed(docId))
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorNotActiveDoc,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						if (!Enumerable.Any<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)cRMSpEntities.MobfnCheckOrderBeforeDeleteResidSerial(docItemSerialId))))
						{
							mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)Enumerable.ToList<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.MobspDeleteWSDocItemSerials(docItemSerialId)));
							if (mct_I_Result != null && mct_I_Result.Result > 0)
							{
								data = null;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
							else if (mct_I_Result != null && mct_I_Result.Result == 0)
							{
								data = null;
								message = Messages.MobMsgErrorRedundancy;
								status = ServiceResultStatus.Fail;
							}
						}
						else
						{
							data = null;
							message = Messages.msgErrorUnableToDeleteSerialInDoc;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
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
		catch (DbEntityValidationException e)
		{
			message = Messages.MobMsgErrorRedundancy;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
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
	public ServiceResult<string> DocAllItem(int docId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(docId, num, result2));
					if (mobspSelectDocById_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspSelectDocById_Result.OprType.ToString(), out result3);
						bool flag = false;
						switch (result3)
						{
						case 1:
							flag = UserLogin.IsUserAccess("frmDoc", "actDeleteDocItemAll", UserLogin.CurrentUser, cId);
							break;
						case 2:
							flag = UserLogin.IsUserAccess("frmDraft", "actDeleteDraftItemAll", UserLogin.CurrentUser, cId);
							break;
						case 3:
							flag = UserLogin.IsUserAccess("frmWareHouseMovement", "actDeleteDocItemAll", UserLogin.CurrentUser, cId);
							break;
						}
						if (!flag)
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						if (Mobile.Classes.Helper.Doc.IsFixed(docId))
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorNotActiveDoc,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.MobspDeleteDocItemsAll(docId));
						if (mct_I_Result != null && mct_I_Result.Result > 0)
						{
							data = null;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else if (mct_I_Result != null && mct_I_Result.Result == 0)
						{
							data = null;
							message = Messages.MobMsgErrorRedundancy;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
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
		catch (DbEntityValidationException e)
		{
			message = Messages.MobMsgErrorRedundancy;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
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
	public ServiceResult<string> DocAllItemSerial(int docItemId, int docId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(docId, num, result2));
					if (mobspSelectDocById_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspSelectDocById_Result.OprType.ToString(), out result3);
						bool flag = false;
						switch (result3)
						{
						case 1:
							flag = UserLogin.IsUserAccess("frmDoc", "actDeleteAllSerials", UserLogin.CurrentUser, cId);
							break;
						case 2:
							flag = UserLogin.IsUserAccess("frmDraft", "actDeleteAllSerials", UserLogin.CurrentUser, cId);
							break;
						case 3:
							flag = UserLogin.IsUserAccess("frmWareHouseMovement", "actDeleteAllSerials", UserLogin.CurrentUser, cId);
							break;
						}
						if (!flag)
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						if (Mobile.Classes.Helper.Doc.IsFixed(docId))
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorNotActiveDoc,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)Enumerable.ToList<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.MobspDeleteDocItemSerialsByDocItemId(docItemId)));
						if (mct_I_Result != null && mct_I_Result.Result > 0)
						{
							data = null;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else if (mct_I_Result != null && mct_I_Result.Result == 0)
						{
							data = null;
							message = Messages.MobMsgErrorRedundancy;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
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
		catch (DbEntityValidationException e)
		{
			message = Messages.MobMsgErrorRedundancy;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
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
	public ServiceResult<string> Letter(int letterId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspSelectLetterWithID_Result mobspSelectLetterWithID_Result = Enumerable.FirstOrDefault<MobspSelectLetterWithID_Result>((IEnumerable<MobspSelectLetterWithID_Result>)cRMEntities.MobspSelectLetterWithID(letterId, num, result2));
					if (mobspSelectLetterWithID_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspSelectLetterWithID_Result.LetterTypeId.ToString(), out result3);
						bool flag = false;
						switch (result3)
						{
						case 1:
							flag = UserLogin.IsUserAccess("frmSendLetters", "actDelete", UserLogin.CurrentUser, cId);
							break;
						case 2:
							flag = UserLogin.IsUserAccess("frmReceiveLetters", "actDelete", UserLogin.CurrentUser, cId);
							break;
						}
						if (!flag)
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						if (Mobile.Classes.Helper.Letter.IsVerifed(letterId))
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorNotActiveLetter,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						switch (result3)
						{
						case 1:
							cRMEntities.MobspDyDeleteFormFieldMasterValuesBySysPart(letterId, "ssec");
							break;
						case 2:
							cRMEntities.MobspDyDeleteFormFieldMasterValuesBySysPart(letterId, "rsec");
							break;
						}
						mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)Enumerable.ToList<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.MobspDeleteSecLetters(letterId)));
						if (mct_I_Result != null && mct_I_Result.Result > 0)
						{
							data = null;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else if (mct_I_Result != null && mct_I_Result.Result == 0)
						{
							data = null;
							message = Messages.MobMsgErrorRedundancy;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
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
		catch (DbEntityValidationException e)
		{
			message = Messages.MobMsgErrorRedundancy;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
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
	public ServiceResult<string> CompanyAddress(int cmpAddressId, int? ln = null, int? cId = null)
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
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					if (!UserLogin.IsUserAccess("frmCompanyAddress", "actDelete", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMSpEntities = new CRMSpEntities();
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.MobspDeleteCompanyAddress(cmpAddressId));
					if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						message = Messages.MobMsgSuccessAction;
						data = null;
						status = ServiceResultStatus.Success;
					}
					else if (mct_I_Result != null && mct_I_Result.Result == 0)
					{
						message = Messages.RedundancyMessage;
						data = null;
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
		catch (DbEntityValidationException e)
		{
			message = Messages.MobMsgErrorRedundancy;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
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
