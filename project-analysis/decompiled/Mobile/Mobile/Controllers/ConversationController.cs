using System;
using System.Collections.Generic;
using System.Data.Objects;
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

public class ConversationController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectCompanyOperations_Result>> List(int cmpid, int prjid, int? cntsms = 10, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
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
		List<MobspSelectCompanyOperations_Result> data;
		string message;
		ServiceResultStatus status;
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspSelectCompanyOperations_Result>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			cRMSpEntities = new CRMSpEntities();
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					string buyOrderText = Labels.buyOrderText;
					data = Enumerable.ToList<MobspSelectCompanyOperations_Result>((IEnumerable<MobspSelectCompanyOperations_Result>)cRMSpEntities.MobspSelectCompanyOperations(cmpid, prjid, cntsms, token2.userId, result, result2, buyOrderText, false, false, null, false, pageNumber, pageSize, cId));
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
		return new ServiceResult<List<MobspSelectCompanyOperations_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<ConversationDetailViewModel> Detail(int cnvsid, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		ConversationDetailViewModel conversationDetailViewModel = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<ConversationDetailViewModel>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					MobspSelectConversationWithID_Result mobspSelectConversationWithID_Result = Enumerable.FirstOrDefault<MobspSelectConversationWithID_Result>((IEnumerable<MobspSelectConversationWithID_Result>)Enumerable.ToList<MobspSelectConversationWithID_Result>((IEnumerable<MobspSelectConversationWithID_Result>)cRMEntities.MobspSelectConversationWithID(cnvsid, result, result2)));
					if (mobspSelectConversationWithID_Result != null)
					{
						List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(mobspSelectConversationWithID_Result.cnvsCompanyId.ToString(), mobspSelectConversationWithID_Result.cnvsPersonId.ToString(), mobspSelectConversationWithID_Result.cnvsProjectId.ToString(), "2", mobspSelectConversationWithID_Result.ConversationID.ToString(), result, result2, false, cId));
						List<FileDirectoryViewModel> list2 = new List<FileDirectoryViewModel>();
						foreach (MobspSelectFilesDirectory_Result item2 in list)
						{
							FileDirectoryViewModel fileDirectoryViewModel = new FileDirectoryViewModel();
							fileDirectoryViewModel.FileDirectoryID = item2.FileDirectoryID;
							fileDirectoryViewModel.FileDirectoryTypeId = item2.FileDirectoryTypeId.GetValueOrDefault();
							fileDirectoryViewModel.MasterId = item2.MasterId.GetValueOrDefault();
							fileDirectoryViewModel.DetailId = item2.DetailId.GetValueOrDefault();
							fileDirectoryViewModel.SubDetailId = item2.SubDetailId.GetValueOrDefault();
							fileDirectoryViewModel.TypeOprObjectId = item2.TypeOprObjectId.GetValueOrDefault();
							fileDirectoryViewModel.Title = item2.Title ?? "";
							fileDirectoryViewModel.FileName = item2.FileName ?? "";
							int result3 = 0;
							int.TryParse(item2.FileDirectoryID.ToString(), out result3);
							fileDirectoryViewModel.FilePath = "";
							fileDirectoryViewModel.DocDate = (item2.DocDateTime ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
							fileDirectoryViewModel.DocDatePersian = DateTimeClass.ConvertDateWoSlashToSlash(item2.DocDate);
							fileDirectoryViewModel.DocDay = item2.DocDay ?? "";
							fileDirectoryViewModel.DocDayPersian = (item2.DocDateTime ?? DateTime.Now).ToString("dddd", new PersianCulture());
							fileDirectoryViewModel.DocTime = item2.DocTime ?? "";
							fileDirectoryViewModel.FileDirectoryType = item2.FileDirectoryType ?? "";
							fileDirectoryViewModel.ProjectTitle = item2.prjTitle ?? "";
							fileDirectoryViewModel.CompanyName = "";
							fileDirectoryViewModel.FileDirectoryTypeOprId = item2.FileDirectoryTypeOprId.GetValueOrDefault();
							fileDirectoryViewModel.FileDirectoryTypeOpr = item2.FileDirectoryTypeOpr ?? "";
							fileDirectoryViewModel.otherFields = null;
							fileDirectoryViewModel.otherFieldsHeader = null;
							list2.Add(fileDirectoryViewModel);
						}
						List<MobspSelectConversationCallHistory_Result> list3 = Enumerable.ToList<MobspSelectConversationCallHistory_Result>((IEnumerable<MobspSelectConversationCallHistory_Result>)cRMEntities.MobspSelectConversationCallHistory(cnvsid, result, result2));
						string text = null;
						string text2 = null;
						if (list3 != null && Enumerable.Any<MobspSelectConversationCallHistory_Result>((IEnumerable<MobspSelectConversationCallHistory_Result>)list3))
						{
							text = "";
							text2 = "";
							for (int i = 0; i < list3.Count; i++)
							{
								MobspSelectConversationCallHistory_Result mobspSelectConversationCallHistory_Result = list3[i];
								string text3 = mobspSelectConversationCallHistory_Result.CallType + " - " + ((!string.IsNullOrWhiteSpace(mobspSelectConversationCallHistory_Result.PhoneNumber)) ? ("(" + mobspSelectConversationCallHistory_Result.PhoneNumber + ")") : "") + " - " + ((!string.IsNullOrWhiteSpace(mobspSelectConversationCallHistory_Result.Duration)) ? ("(" + mobspSelectConversationCallHistory_Result.Duration + ")") : "") + " - " + (mobspSelectConversationCallHistory_Result.CallDateTime.HasValue ? mobspSelectConversationCallHistory_Result.CallDateTime.Value.ToString("yyyy/MM/dd hh:mm:dd") : "");
								if (i != list3.Count - 1)
								{
									text = text + mobspSelectConversationCallHistory_Result.CallHistoryID + "|";
									text2 = text2 + text3 + "|";
								}
								else
								{
									text += mobspSelectConversationCallHistory_Result.CallHistoryID;
									text2 += text3;
								}
							}
						}
						conversationDetailViewModel = new ConversationDetailViewModel
						{
							ConversationID = mobspSelectConversationWithID_Result.ConversationID,
							cnvsProjectId = mobspSelectConversationWithID_Result.cnvsProjectId,
							cnvsCompanyId = mobspSelectConversationWithID_Result.cnvsCompanyId,
							cnvsDate = mobspSelectConversationWithID_Result.cnvsDate,
							cnvsDay = mobspSelectConversationWithID_Result.cnvsDay,
							cnvsTime = mobspSelectConversationWithID_Result.cnvsTime,
							cnvsDateTime = mobspSelectConversationWithID_Result.cnvsDateTime,
							cnvsTopicId = mobspSelectConversationWithID_Result.cnvsTopicId,
							cnvsSubject = mobspSelectConversationWithID_Result.cnvsSubject,
							cnvsDesc = mobspSelectConversationWithID_Result.cnvsDesc,
							cnvsPersonId = mobspSelectConversationWithID_Result.cnvsPersonId,
							cnvsUserId = mobspSelectConversationWithID_Result.cnvsUserId,
							cnvsReferUserId = mobspSelectConversationWithID_Result.cnvsReferUserId,
							cnvsReferDesc = mobspSelectConversationWithID_Result.cnvsReferDesc,
							cnvsStatusId = mobspSelectConversationWithID_Result.cnvsStatusId,
							cnvsPriorityId = mobspSelectConversationWithID_Result.cnvsPriorityId,
							cnvsRemindDate = mobspSelectConversationWithID_Result.cnvsRemindDate,
							cnvsRemindTime = mobspSelectConversationWithID_Result.cnvsRemindTime,
							cnvsRemindDateTime = mobspSelectConversationWithID_Result.cnvsRemindDateTime,
							cnvsRemindOk = mobspSelectConversationWithID_Result.cnvsRemindOk.GetValueOrDefault(),
							cnvsIsBookMark = mobspSelectConversationWithID_Result.cnvsIsBookMark.GetValueOrDefault(),
							cnvsFirstRegisterUserId = mobspSelectConversationWithID_Result.cnvsFirstRegisterUserId,
							cnvsFirstRegisterDate = mobspSelectConversationWithID_Result.cnvsFirstRegisterDate,
							cnvsFirstRegisterDateTime = mobspSelectConversationWithID_Result.cnvsFirstRegisterDateTime,
							UserId = mobspSelectConversationWithID_Result.UserId,
							Year1 = mobspSelectConversationWithID_Result.Year1,
							Month1 = mobspSelectConversationWithID_Result.Month1,
							RegisterDate = mobspSelectConversationWithID_Result.RegisterDate,
							RegisterDatePersian = mobspSelectConversationWithID_Result.RegisterDatePersian,
							FirstRegisterDate = mobspSelectConversationWithID_Result.FirstRegisterDate,
							GUId = mobspSelectConversationWithID_Result.GUId,
							cnvsRemindDateForAllarm = mobspSelectConversationWithID_Result.cnvsRemindDateForAllarm,
							cnvsRemindDateTimeForAllarm = mobspSelectConversationWithID_Result.cnvsRemindDateTimeForAllarm,
							AppType = mobspSelectConversationWithID_Result.AppType,
							LanguageID = mobspSelectConversationWithID_Result.LanguageID.GetValueOrDefault(),
							FirstRegisterUserId = mobspSelectConversationWithID_Result.FirstRegisterUserId,
							FirstRegisterDatePersian = mobspSelectConversationWithID_Result.FirstRegisterDatePersian,
							ApiId = mobspSelectConversationWithID_Result.ApiId,
							cnvsFOCmpCanSee = mobspSelectConversationWithID_Result.cnvsFOCmpCanSee.GetValueOrDefault(),
							cnvsIsTicket = mobspSelectConversationWithID_Result.cnvsIsTicket.GetValueOrDefault(),
							cnvsCoordinateLatitude = mobspSelectConversationWithID_Result.cnvsCoordinateLatitude,
							cnvsCoordinateLongitude = mobspSelectConversationWithID_Result.cnvsCoordinateLongitude,
							cnvsCoordinateLastDate = mobspSelectConversationWithID_Result.cnvsCoordinateLastDate,
							cnvsCoordinateLastDatePersian = mobspSelectConversationWithID_Result.cnvsCoordinateLastDatePersian,
							cnvsProject = mobspSelectConversationWithID_Result.cnvsProject,
							cnvsCompany = mobspSelectConversationWithID_Result.cnvsCompany,
							cnvsTopic = mobspSelectConversationWithID_Result.cnvsTopic,
							cnvsPerson = mobspSelectConversationWithID_Result.cnvsPerson,
							cnvsUser = mobspSelectConversationWithID_Result.cnvsUser,
							cnvsReferUser = mobspSelectConversationWithID_Result.cnvsReferUser,
							cnvsStatus = mobspSelectConversationWithID_Result.cnvsStatus,
							cnvsPriority = mobspSelectConversationWithID_Result.cnvsPriority,
							cnvsFirstRegisterUser = mobspSelectConversationWithID_Result.cnvsFirstRegisterUser,
							RegisterUser = mobspSelectConversationWithID_Result.RegisterUser,
							FirstRegisterUser = mobspSelectConversationWithID_Result.FirstRegisterUser,
							CnvsFiles = list2,
							cnvsTicketIsRead = mobspSelectConversationWithID_Result.cnvsTicketIsRead.GetValueOrDefault(),
							cnvsDoingTime = mobspSelectConversationWithID_Result.cnvsDoingTime,
							cnvsIsCopy = mobspSelectConversationWithID_Result.cnvsIsCopy.GetValueOrDefault(),
							cnvsCallHistoryIds = text,
							cnvsCallHistories = text2,
							cnvsIsTicketNew = mobspSelectConversationWithID_Result.cnvsIsTicketNew.GetValueOrDefault(),
							cnvsDoingTimeSec = mobspSelectConversationWithID_Result.cnvsDoingTimeSec.GetValueOrDefault(),
							cnvsStatusProcessKindId = mobspSelectConversationWithID_Result.cnvsStatusProcessKindId.GetValueOrDefault(),
							cnvsStatusGroupId = mobspSelectConversationWithID_Result.cnvsStatusGroupId.GetValueOrDefault(),
							cnvsHappyVote = mobspSelectConversationWithID_Result.cnvsHappyVote,
							cnvsStatusResultId = mobspSelectConversationWithID_Result.cnvsStatusResultId,
							cnvsStatusResult = mobspSelectConversationWithID_Result.cnvsStatusResult,
							cnvsStatusResultDoingTimeEndDate = mobspSelectConversationWithID_Result.cnvsStatusResultDoingTimeEndDate,
							cnvsDoingTimeFrom = mobspSelectConversationWithID_Result.cnvsDoingTimeFrom,
							cnvsDoingTimeTo = mobspSelectConversationWithID_Result.cnvsDoingTimeTo,
							cnvsKnowledgeTankIds = mobspSelectConversationWithID_Result.cnvsKnowledgeTankIds
						};
						if (!string.IsNullOrWhiteSpace(mobspSelectConversationWithID_Result.cnvsKnowledgeTankIds))
						{
							List<DropDownItem> list4 = new List<DropDownItem>();
							List<MobspknlgSelectKnowledgeTankByIds_Result> list5 = Enumerable.ToList<MobspknlgSelectKnowledgeTankByIds_Result>((IEnumerable<MobspknlgSelectKnowledgeTankByIds_Result>)cRMEntities.MobspknlgSelectKnowledgeTankByIds(mobspSelectConversationWithID_Result.cnvsKnowledgeTankIds, token2.RollId, num, result2));
							if (list5 != null && Enumerable.Any<MobspknlgSelectKnowledgeTankByIds_Result>((IEnumerable<MobspknlgSelectKnowledgeTankByIds_Result>)list5))
							{
								foreach (MobspknlgSelectKnowledgeTankByIds_Result item3 in list5)
								{
									DropDownItem item = new DropDownItem
									{
										Id = item3.KnowledgeTankId,
										Title = (item3.knlgTitle ?? "")
									};
									list4.Add(item);
								}
							}
							if (list4 != null && Enumerable.Any<DropDownItem>((IEnumerable<DropDownItem>)list4))
							{
								conversationDetailViewModel.cnvsKnowledgeTankJson = JsonConvert.SerializeObject(Enumerable.ToList<DropDownItem>((IEnumerable<DropDownItem>)list4));
							}
						}
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorConversationNotFound;
						conversationDetailViewModel = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					conversationDetailViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				conversationDetailViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			conversationDetailViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<ConversationDetailViewModel>
		{
			Message = message,
			Data = conversationDetailViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<ConversationDetailViewModel> SelectLastCrmConversation(int cmpId, int prjId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		ConversationDetailViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			cRMEntities = new CRMEntities();
			MobspSelectLastCrmConversation_Result mobspSelectLastCrmConversation_Result = Enumerable.FirstOrDefault<MobspSelectLastCrmConversation_Result>((IEnumerable<MobspSelectLastCrmConversation_Result>)cRMEntities.MobspSelectLastCrmConversation(cmpId, prjId, result, result2));
			if (mobspSelectLastCrmConversation_Result != null)
			{
				List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(mobspSelectLastCrmConversation_Result.cnvsCompanyId.ToString(), mobspSelectLastCrmConversation_Result.cnvsPersonId.ToString(), mobspSelectLastCrmConversation_Result.cnvsProjectId.ToString(), "2", mobspSelectLastCrmConversation_Result.ConversationID.ToString(), result, result2, false, cId));
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
				data = new ConversationDetailViewModel
				{
					ConversationID = mobspSelectLastCrmConversation_Result.ConversationID,
					cnvsProjectId = mobspSelectLastCrmConversation_Result.cnvsProjectId,
					cnvsCompanyId = mobspSelectLastCrmConversation_Result.cnvsCompanyId,
					cnvsDate = mobspSelectLastCrmConversation_Result.cnvsDate,
					cnvsDay = mobspSelectLastCrmConversation_Result.cnvsDay,
					cnvsTime = mobspSelectLastCrmConversation_Result.cnvsTime,
					cnvsDateTime = mobspSelectLastCrmConversation_Result.cnvsDateTime,
					cnvsTopicId = mobspSelectLastCrmConversation_Result.cnvsTopicId,
					cnvsSubject = mobspSelectLastCrmConversation_Result.cnvsSubject,
					cnvsDesc = mobspSelectLastCrmConversation_Result.cnvsDesc,
					cnvsPersonId = mobspSelectLastCrmConversation_Result.cnvsPersonId,
					cnvsUserId = mobspSelectLastCrmConversation_Result.cnvsUserId,
					cnvsReferUserId = mobspSelectLastCrmConversation_Result.cnvsReferUserId,
					cnvsReferDesc = mobspSelectLastCrmConversation_Result.cnvsReferDesc,
					cnvsStatusId = mobspSelectLastCrmConversation_Result.cnvsStatusId,
					cnvsPriorityId = mobspSelectLastCrmConversation_Result.cnvsPriorityId,
					cnvsRemindDate = mobspSelectLastCrmConversation_Result.cnvsRemindDate,
					cnvsRemindTime = mobspSelectLastCrmConversation_Result.cnvsRemindTime,
					cnvsRemindDateTime = mobspSelectLastCrmConversation_Result.cnvsRemindDateTime,
					cnvsRemindOk = mobspSelectLastCrmConversation_Result.cnvsRemindOk,
					cnvsIsBookMark = mobspSelectLastCrmConversation_Result.cnvsIsBookMark,
					cnvsFirstRegisterUserId = mobspSelectLastCrmConversation_Result.cnvsFirstRegisterUserId,
					cnvsFirstRegisterDate = mobspSelectLastCrmConversation_Result.cnvsFirstRegisterDate,
					cnvsFirstRegisterDateTime = mobspSelectLastCrmConversation_Result.cnvsFirstRegisterDateTime,
					UserId = mobspSelectLastCrmConversation_Result.UserId,
					Year1 = mobspSelectLastCrmConversation_Result.Year1,
					Month1 = mobspSelectLastCrmConversation_Result.Month1,
					RegisterDate = mobspSelectLastCrmConversation_Result.RegisterDate,
					RegisterDatePersian = mobspSelectLastCrmConversation_Result.RegisterDatePersian,
					FirstRegisterDate = mobspSelectLastCrmConversation_Result.FirstRegisterDate,
					GUId = mobspSelectLastCrmConversation_Result.GUId,
					cnvsRemindDateForAllarm = mobspSelectLastCrmConversation_Result.cnvsRemindDateForAllarm,
					cnvsRemindDateTimeForAllarm = mobspSelectLastCrmConversation_Result.cnvsRemindDateTimeForAllarm,
					AppType = mobspSelectLastCrmConversation_Result.AppType,
					LanguageID = mobspSelectLastCrmConversation_Result.LanguageID,
					FirstRegisterUserId = mobspSelectLastCrmConversation_Result.FirstRegisterUserId,
					FirstRegisterDatePersian = mobspSelectLastCrmConversation_Result.FirstRegisterDatePersian,
					ApiId = mobspSelectLastCrmConversation_Result.ApiId,
					cnvsFOCmpCanSee = mobspSelectLastCrmConversation_Result.cnvsFOCmpCanSee,
					cnvsIsTicket = mobspSelectLastCrmConversation_Result.cnvsIsTicket,
					cnvsCoordinateLatitude = mobspSelectLastCrmConversation_Result.cnvsCoordinateLatitude,
					cnvsCoordinateLongitude = mobspSelectLastCrmConversation_Result.cnvsCoordinateLongitude,
					cnvsCoordinateLastDate = mobspSelectLastCrmConversation_Result.cnvsCoordinateLastDate,
					cnvsCoordinateLastDatePersian = mobspSelectLastCrmConversation_Result.cnvsCoordinateLastDatePersian,
					cnvsProject = mobspSelectLastCrmConversation_Result.cnvsProject,
					cnvsCompany = mobspSelectLastCrmConversation_Result.cnvsCompany,
					cnvsTopic = mobspSelectLastCrmConversation_Result.cnvsTopic,
					cnvsPerson = mobspSelectLastCrmConversation_Result.cnvsPerson,
					cnvsUser = mobspSelectLastCrmConversation_Result.cnvsUser,
					cnvsReferUser = mobspSelectLastCrmConversation_Result.cnvsReferUser,
					cnvsStatus = mobspSelectLastCrmConversation_Result.cnvsStatus,
					cnvsPriority = mobspSelectLastCrmConversation_Result.cnvsPriority,
					cnvsFirstRegisterUser = mobspSelectLastCrmConversation_Result.cnvsFirstRegisterUser,
					RegisterUser = mobspSelectLastCrmConversation_Result.RegisterUser,
					FirstRegisterUser = mobspSelectLastCrmConversation_Result.FirstRegisterUser,
					CnvsFiles = list2
				};
				message = "";
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = Messages.MobMsgErrorConversationNotFound;
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
		return new ServiceResult<ConversationDetailViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<ConversationCompanyAndProjetcInfoViewModel> SelectConversationCompanyAndProjetcInfo(int cmpId, int prjId, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		ConversationCompanyAndProjetcInfoViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmCompanyI", "actcnvsInsert", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<ConversationCompanyAndProjetcInfoViewModel>
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
					if (cmpId <= 0)
					{
						ServiceResult<ConversationCompanyAndProjetcInfoViewModel> result3 = new ServiceResult<ConversationCompanyAndProjetcInfoViewModel>
						{
							Message = Messages.MobMsgErrorCompanyNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					if (prjId <= 0)
					{
						ServiceResult<ConversationCompanyAndProjetcInfoViewModel> result4 = new ServiceResult<ConversationCompanyAndProjetcInfoViewModel>
						{
							Message = Messages.MobMsgErrorProjectNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					ConversationCompanyAndProjetcInfoViewModel conversationCompanyAndProjetcInfoViewModel = new ConversationCompanyAndProjetcInfoViewModel();
					mct_MobspSelectCompanyWithID_Result mct_MobspSelectCompanyWithID_Result = Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)cRMEntities.MobspSelectCompanyWithID(cmpId, token2.userId, result, result2, cId));
					if (mct_MobspSelectCompanyWithID_Result == null)
					{
						ServiceResult<ConversationCompanyAndProjetcInfoViewModel> result5 = new ServiceResult<ConversationCompanyAndProjetcInfoViewModel>
						{
							Message = Messages.MobMsgErrorCompanyNotFound,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result5;
					}
					conversationCompanyAndProjetcInfoViewModel.CompanyId = mct_MobspSelectCompanyWithID_Result.CompanyID;
					conversationCompanyAndProjetcInfoViewModel.CompanyName = mct_MobspSelectCompanyWithID_Result.CompanyName;
					MobspSelectProjectWithID_Result mobspSelectProjectWithID_Result = Enumerable.FirstOrDefault<MobspSelectProjectWithID_Result>((IEnumerable<MobspSelectProjectWithID_Result>)cRMEntities.MobspSelectProjectWithID(prjId, result, result2));
					if (mobspSelectProjectWithID_Result == null)
					{
						ServiceResult<ConversationCompanyAndProjetcInfoViewModel> result6 = new ServiceResult<ConversationCompanyAndProjetcInfoViewModel>
						{
							Message = Messages.MobMsgErrorProjectNotFound,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result6;
					}
					if (mct_MobspSelectCompanyWithID_Result.CompanyID != mobspSelectProjectWithID_Result.prjCompanyId)
					{
						ServiceResult<ConversationCompanyAndProjetcInfoViewModel> result7 = new ServiceResult<ConversationCompanyAndProjetcInfoViewModel>
						{
							Message = Messages.MobMsgErrorCompanyHaveNotThisProject,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result7;
					}
					conversationCompanyAndProjetcInfoViewModel.ProjectTitle = mobspSelectProjectWithID_Result.ProjectTitle;
					conversationCompanyAndProjetcInfoViewModel.ProjectId = mobspSelectProjectWithID_Result.ProjectID;
					conversationCompanyAndProjetcInfoViewModel.StatusGroupId = mobspSelectProjectWithID_Result.prjcnvsStatusGroupId;
					CRMspSelectCompanyConversationLastStatus_Result cRMspSelectCompanyConversationLastStatus_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyConversationLastStatus_Result>((IEnumerable<CRMspSelectCompanyConversationLastStatus_Result>)cRMEntities.CRMspSelectCompanyConversationLastStatus(projectId: mobspSelectProjectWithID_Result.ProjectID, companyId: mct_MobspSelectCompanyWithID_Result.CompanyID, languageID: result, defaultLanguageID: result2));
					if (cRMspSelectCompanyConversationLastStatus_Result != null)
					{
						conversationCompanyAndProjetcInfoViewModel.LastStatus = cRMspSelectCompanyConversationLastStatus_Result.Status ?? "";
						conversationCompanyAndProjetcInfoViewModel.LastCnvsUser = cRMspSelectCompanyConversationLastStatus_Result.cnvsUser ?? "";
						conversationCompanyAndProjetcInfoViewModel.LastCnvsReferUser = cRMspSelectCompanyConversationLastStatus_Result.cnvsReferUser ?? "";
						conversationCompanyAndProjetcInfoViewModel.LastCnvsReferUserId = cRMspSelectCompanyConversationLastStatus_Result.cnvsReferUserId.GetValueOrDefault();
					}
					else
					{
						conversationCompanyAndProjetcInfoViewModel.LastStatus = "";
						conversationCompanyAndProjetcInfoViewModel.LastCnvsUser = "";
						conversationCompanyAndProjetcInfoViewModel.LastCnvsReferUser = "";
						conversationCompanyAndProjetcInfoViewModel.LastCnvsReferUserId = 0;
					}
					conversationCompanyAndProjetcInfoViewModel.ActCanEditcnvsDate = UserLogin.IsUserAccess("frmDefineConversation", "actCanEditcnvsDate", UserLogin.CurrentUser, cId);
					conversationCompanyAndProjetcInfoViewModel.ActCanEditcnvsTime = UserLogin.IsUserAccess("frmDefineConversation", "actCanEditcnvsTime", UserLogin.CurrentUser, cId);
					conversationCompanyAndProjetcInfoViewModel.ActReferToMultilUser = UserLogin.IsUserAccess("frmDefineConversation", "actReferToMultilUser", UserLogin.CurrentUser, cId);
					conversationCompanyAndProjetcInfoViewModel.ActCanSetRemindOkInInsertMode = UserLogin.IsUserAccess("frmDefineConversation", "actCanSetRemindOkInInsertMode", UserLogin.CurrentUser, cId);
					conversationCompanyAndProjetcInfoViewModel.ActPost = UserLogin.IsUserAccess("frmDefineConversation", "actPost", UserLogin.CurrentUser, cId);
					MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
					conversationCompanyAndProjetcInfoViewModel.MustFullcnvsRemindDate = mobspSelectCrmsysSetting_Result != null && mobspSelectCrmsysSetting_Result.MustFullcnvsRemindDate.HasValue && mobspSelectCrmsysSetting_Result.MustFullcnvsRemindDate != false;
					conversationCompanyAndProjetcInfoViewModel.ActAddDefaultText = UserLogin.IsUserAccess("frmDefineConversation", "actAddDefaultText", UserLogin.CurrentUser, cId);
					conversationCompanyAndProjetcInfoViewModel.ActInsertWithMapLocationIsForced = UserLogin.IsUserAccess("frmDefineConversation", "actInsertWithMapLocationIsForced", UserLogin.CurrentUser, cId);
					data = conversationCompanyAndProjetcInfoViewModel;
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
		return new ServiceResult<ConversationCompanyAndProjetcInfoViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetCnvsEventPolicyInfo(int cnvsId, int cnvsstatusId, int prjId, int cmpId, int prsId, int? ln = null)
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					string text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)cRMEntities.MobspGetCnvsEventPolicyInfo(cnvsId, cnvsstatusId, prjId, cmpId, prsId));
					data = ((!string.IsNullOrEmpty(text)) ? text : "");
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectConversationForcedStatusBFCurr_Result>> SelectConversationForcedStatusBfCurr(int cnvsStatusId = 0, int prjId = 0, int cnvsId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectConversationForcedStatusBFCurr_Result> data = null;
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
					ObjectParameter conversationForcedStatus = new ObjectParameter("conversationForcedStatus", "");
					data = Enumerable.ToList<MobspSelectConversationForcedStatusBFCurr_Result>((IEnumerable<MobspSelectConversationForcedStatusBFCurr_Result>)cRMEntities.MobspSelectConversationForcedStatusBFCurr(cnvsStatusId, prjId, result, result2, conversationForcedStatus, cnvsId, 1));
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
		return new ServiceResult<List<MobspSelectConversationForcedStatusBFCurr_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectCompanyConversationsByProject_Result>> SelectCompanyConversationsByProject(int prjid, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
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
		List<MobspSelectCompanyConversationsByProject_Result> data;
		string message;
		ServiceResultStatus status;
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspSelectCompanyConversationsByProject_Result>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			cRMEntities = new CRMEntities();
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					_ = Labels.MobSendSmsLabel;
					_ = Labels.MobReceiveSmsLabel;
					_ = Labels.MobPreOrderLabel;
					CRMEntities cRMEntities2 = cRMEntities;
					int? projectId = prjid;
					int? userId = token2.userId;
					int? languageID = result;
					int? defaultLanguageID = result2;
					data = Enumerable.ToList<MobspSelectCompanyConversationsByProject_Result>((IEnumerable<MobspSelectCompanyConversationsByProject_Result>)cRMEntities2.MobspSelectCompanyConversationsByProject(projectId, userId, pageNumber, pageSize, languageID, defaultLanguageID, cId));
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
		return new ServiceResult<List<MobspSelectCompanyConversationsByProject_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> UpdateConversationRemindOk(int cnvsId, int? ln = null, int? cId = null)
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
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token = new Common().GetToken(token2);
				if (token != null)
				{
					cRMEntities = new CRMEntities();
					if (cnvsId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorConversationNotFound,
							Data = cnvsId,
							Status = ServiceResultStatus.Error
						};
					}
					if (Enumerable.FirstOrDefault<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token.userId, 9, result, result2, cId, true), (Func<MobspSelectUserForLinkedType_Result, bool>)((MobspSelectUserForLinkedType_Result m) => m.Id == token.userId)) == null)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorUserCanNotCnvsEditaion,
							Data = token.userId,
							Status = ServiceResultStatus.Fail
						};
					}
					MobspSelectConversationWithID_Result mobspSelectConversationWithID_Result = Enumerable.FirstOrDefault<MobspSelectConversationWithID_Result>((IEnumerable<MobspSelectConversationWithID_Result>)cRMEntities.MobspSelectConversationWithID(cnvsId, num, result2));
					if (mobspSelectConversationWithID_Result != null)
					{
						string text = Company.CheckCnvsRemindOkByPrjPrdHNotDone(mobspSelectConversationWithID_Result.cnvsProjectId.GetValueOrDefault(), num);
						if (!string.IsNullOrWhiteSpace(text))
						{
							return new ServiceResult<int>
							{
								Message = text,
								Data = 0,
								Status = ServiceResultStatus.Fail
							};
						}
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string appType = Mobile.Classes.Configuration.AppType;
					cRMEntities.MobspUpdateConversationRemindOk(cnvsId, token.userId, registerDatePersian, value, appType);
					data = cnvsId;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
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
	public ServiceResult<int> UpdateConversationNotRemindOk(int cnvsId, int? ln = null, int? cId = null)
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
				string token2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token = new Common().GetToken(token2);
				if (token != null)
				{
					cRMEntities = new CRMEntities();
					if (cnvsId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorConversationNotFound,
							Data = cnvsId,
							Status = ServiceResultStatus.Error
						};
					}
					if (Enumerable.FirstOrDefault<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token.userId, 9, result, result2, cId, true), (Func<MobspSelectUserForLinkedType_Result, bool>)((MobspSelectUserForLinkedType_Result m) => m.Id == token.userId)) == null)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorUserCanNotCnvsEditaion,
							Data = token.userId,
							Status = ServiceResultStatus.Fail
						};
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string appType = Mobile.Classes.Configuration.AppType;
					cRMEntities.MobspUpdateConversationNotRemindOk(cnvsId, token.userId, registerDatePersian, value, appType);
					data = cnvsId;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
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
	public ServiceResult<List<DropDownItemWithParentId>> ListCallHistories(int cmpId, int cnvsId, string cnvsDate, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					DateTime now2 = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(cnvsDate))
						{
							ServiceResult<List<DropDownItemWithParentId>> result3 = new ServiceResult<List<DropDownItemWithParentId>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						cnvsDate = cnvsDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(cnvsDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(cnvsDate) + " 00:00:00"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<DropDownItemWithParentId>> result4 = new ServiceResult<List<DropDownItemWithParentId>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					try
					{
						if (string.IsNullOrEmpty(cnvsDate))
						{
							ServiceResult<List<DropDownItemWithParentId>> result5 = new ServiceResult<List<DropDownItemWithParentId>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result5;
						}
						cnvsDate = cnvsDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now2 = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(cnvsDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(cnvsDate) + " 23:59:59"));
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<List<DropDownItemWithParentId>> result6 = new ServiceResult<List<DropDownItemWithParentId>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result6;
					}
					List<MobspSelectCallHistoryWithoutCnvsByCmpId_Result> list = Enumerable.ToList<MobspSelectCallHistoryWithoutCnvsByCmpId_Result>((IEnumerable<MobspSelectCallHistoryWithoutCnvsByCmpId_Result>)cRMEntities.MobspSelectCallHistoryWithoutCnvsByCmpId(now, now2, cmpId, result, result2, token2.userId, cId));
					List<MobspSelectConversationCallHistory_Result> list2 = Enumerable.ToList<MobspSelectConversationCallHistory_Result>((IEnumerable<MobspSelectConversationCallHistory_Result>)cRMEntities.MobspSelectConversationCallHistory(cnvsId, result, result2));
					string cnvsIncommingCall = Labels.CnvsIncommingCall;
					string cnvsOutGoingCall = Labels.CnvsOutGoingCall;
					if (list2 != null && Enumerable.Any<MobspSelectConversationCallHistory_Result>((IEnumerable<MobspSelectConversationCallHistory_Result>)list2))
					{
						foreach (MobspSelectConversationCallHistory_Result item2 in list2)
						{
							MobspSelectCallHistoryWithoutCnvsByCmpId_Result item = new MobspSelectCallHistoryWithoutCnvsByCmpId_Result
							{
								CallHistoryID = item2.CallHistoryID,
								CallTypeId = item2.CallTypeId,
								CallType = item2.CallType,
								PhoneNumber = item2.PhoneNumber,
								CompanyID = item2.CompanyID,
								CallDate = item2.CallDate,
								LineNumber = item2.LineNumber,
								CompanyPersonId = item2.CompanyPersonId,
								Duration = item2.Duration,
								CallDateTime = item2.CallDateTime,
								ConversationID = item2.ConversationID
							};
							list.Add(item);
						}
					}
					foreach (MobspSelectCallHistoryWithoutCnvsByCmpId_Result item3 in list)
					{
						_ = item3.CallTypeId;
						if (item3.CallTypeId == 1)
						{
							item3.CallType = cnvsOutGoingCall;
						}
						else if (item3.CallTypeId == 2)
						{
							item3.CallType = cnvsIncommingCall;
						}
					}
					List<DropDownItemWithParentId> list3 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCallHistoryWithoutCnvsByCmpId_Result item4 in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result7 = 0;
						int.TryParse(item4.CallHistoryID.ToString(), out result7);
						dropDownItemWithParentId.Id = result7;
						string title = item4.CallType + " - " + ((!string.IsNullOrWhiteSpace(item4.PhoneNumber)) ? ("(" + item4.PhoneNumber + ")") : "") + " - " + ((!string.IsNullOrWhiteSpace(item4.Duration)) ? ("(" + item4.Duration + ")") : "") + " - " + (item4.CallDateTime.HasValue ? item4.CallDateTime.Value.ToString("yyyy/MM/dd hh:mm:dd") : "");
						dropDownItemWithParentId.Title = title;
						int orderView = 0;
						dropDownItemWithParentId.OrderView = orderView;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list3.Add(dropDownItemWithParentId);
					}
					data = list3;
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
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> UpdateConversationHappyVote(int cnvsId, int cnvsHappyVote, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = "";
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
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					cRMEntities = new CRMEntities();
					ObjectParameter objectParameter = new ObjectParameter("ResultId", 0);
					CRMEntities cRMEntities2 = cRMEntities;
					int? conversationId = cnvsId;
					int? happyVote = ((cnvsHappyVote == 0) ? null : new int?(cnvsHappyVote));
					int? userId = token2.userId;
					short? year = value2;
					short? month = value3;
					DateTime? registerDate = value;
					int? languageID = result;
					cRMEntities2.MobspUpdateConversationHappyVote(conversationId, happyVote, userId, registerDate, registerDatePersian, year, month, appType, languageID, objectParameter);
					string text = "";
					if (objectParameter != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()) && int.Parse(objectParameter.Value.ToString()) == 0)
					{
						text += Messages.MobMsgErrorDoneOperation;
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
	public ServiceResult<MobspSelectCompanyConversationLastStatus_Result> SelectCompanyConversationLastStatus(int cmpId, int prjId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectCompanyConversationLastStatus_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			cRMEntities = new CRMEntities();
			ObjectParameter cnvsReferUserId = new ObjectParameter("CnvsReferUserId", 0);
			MobspSelectCompanyConversationLastStatus_Result mobspSelectCompanyConversationLastStatus_Result = Enumerable.FirstOrDefault<MobspSelectCompanyConversationLastStatus_Result>((IEnumerable<MobspSelectCompanyConversationLastStatus_Result>)cRMEntities.MobspSelectCompanyConversationLastStatus(cmpId, prjId, result, result2, cnvsReferUserId));
			if (mobspSelectCompanyConversationLastStatus_Result != null)
			{
				data = mobspSelectCompanyConversationLastStatus_Result;
				message = Messages.msgSuccessSendSms;
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = Messages.MobMsgErrorConversationNotFound;
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
		return new ServiceResult<MobspSelectCompanyConversationLastStatus_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> SendOTPCode(CrmConversationSendOTPCodeViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = "";
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					cRMEntities = new CRMEntities();
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					DateTime dateTime = default(DateTime);
					string text = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(model.cnvsRemindDate))
						{
							text = PersianDate.GetFormatetdDate(model.cnvsRemindDate.Replace("/", ""));
							switch (num)
							{
							case 1065:
								dateTime = DateTime.Parse(text + " 00:00:00", new PersianCulture());
								model.cnvsRemindDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA"));
								model.cnvsRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US"));
								model.cnvsRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							model.cnvsRemindDateTime = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<string> result3 = new ServiceResult<string>
						{
							Message = string.Format(Messages.MobErrorInFormat, Labels.MobCnvsRemindDate),
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					try
					{
						if (string.IsNullOrWhiteSpace(model.cnvsRemindTime))
						{
							model.cnvsRemindTime = DateTime.Now.ToString("HH:mm");
						}
						else
						{
							model.cnvsRemindTime = model.cnvsRemindTime.Trim();
						}
						if (!string.IsNullOrWhiteSpace(model.cnvsRemindDateForAllarm))
						{
							text = PersianDate.GetFormatetdDate(model.cnvsRemindDateForAllarm.Replace("/", ""));
							switch (num)
							{
							case 1065:
								dateTime = DateTime.Parse(text + " " + model.cnvsRemindTime, new PersianCulture());
								model.cnvsRemindDateForAllarm = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text + " " + model.cnvsRemindTime, new CultureInfo("ar-SA"));
								model.cnvsRemindDateForAllarm = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text + " " + model.cnvsRemindTime, new CultureInfo("en-US"));
								model.cnvsRemindDateForAllarm = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							model.cnvsRemindDateForAllarmTime = dateTime;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<string> result4 = new ServiceResult<string>
						{
							Message = string.Format(Messages.MobErrorInFormat, Labels.MobCnvsRemindDateForAllarm),
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					string text2 = "";
					text2 = new Random().Next(1000, 9999).ToString();
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					foreach (MobspSelectLanguages_Result item in list)
					{
						list2.Add(new CommonMultiLanguageViewModel
						{
							Value = model.cnvsDesc,
							LanguageId = item.LanguageID
						});
					}
					string cnvsDesc = "";
					if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
					{
						cnvsDesc = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2));
					}
					ObjectParameter objectParameter = new ObjectParameter("SendOTPCode", 0);
					cRMEntities.MobspSendCnvsOTPCode(model.cnvsStatusResultId, model.cnvsCompanyId, model.cnvsPersonId, model.cnvsProjectId, cnvsDesc, model.cnvsFirstRegisterUserId, model.cnvsUserId, model.cnvsReferUserId, model.CnvsMultiReferUserIds, model.cnvsRemindDateTime, model.cnvsRemindDateForAllarmTime, model.cnvsRemindTime, text2, token2.userId, value2, value3, value, registerDatePersian, appType, num, result2, objectParameter, model.prjPrdHisPrdNameJson, model.CmpKind, model.CmpReferUserId, model.CmpSuppUserId, model.CmpTitleId, model.CmpName, model.CmpPreTel, model.CmpTel, model.CmpAddress, model.CmpMobile, model.CmpEmail, model.PrsTitleId, model.PrsFName, model.PrsLName, model.PrsMobile, model.PrsEmail, model.PrjTitle, model.PrjGroupId, model.PrjGradeId, model.PrjPriorityId, model.PrjPostFix, model.PrjRemindDate, model.PrjTitleGroup, model.PrjNumRef, model.CenterId);
					int result5 = 0;
					if (objectParameter != null && objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result5);
					}
					if (result5 == 1)
					{
						new Sms().SendSMSTankByOtp(text2, model.CenterId);
						new EmailController().ActSendEmailByOtp(text2);
						data = text2;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorSendOTPCode;
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
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
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
	public ServiceResult<string> CheckCnvsRemindOkByPrjPrdHNotDone(int prjId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = "";
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
					if (prjId != 0)
					{
						data = Company.CheckCnvsRemindOkByPrjPrdHNotDone(prjId, result);
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
	public ServiceResult<MobspSelectCompanyConversationFirstCnvsUser_Result> CompanyConversationFirstCnvsUser(int cmpId, int prjId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		MobspSelectCompanyConversationFirstCnvsUser_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			cRMSpEntities = new CRMSpEntities();
			new ObjectParameter("CnvsReferUserId", 0);
			MobspSelectCompanyConversationFirstCnvsUser_Result mobspSelectCompanyConversationFirstCnvsUser_Result = Enumerable.FirstOrDefault<MobspSelectCompanyConversationFirstCnvsUser_Result>((IEnumerable<MobspSelectCompanyConversationFirstCnvsUser_Result>)cRMSpEntities.MobspSelectCompanyConversationFirstCnvsUser(cmpId, prjId, result, result2));
			if (mobspSelectCompanyConversationFirstCnvsUser_Result != null)
			{
				data = mobspSelectCompanyConversationFirstCnvsUser_Result;
				message = Messages.msgSuccessSendSms;
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = Messages.MobMsgErrorConversationNotFound;
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
		return new ServiceResult<MobspSelectCompanyConversationFirstCnvsUser_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
