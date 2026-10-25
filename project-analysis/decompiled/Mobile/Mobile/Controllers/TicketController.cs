using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class TicketController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspResultsTicketCartable_Result>> ResultsTicketCartable(TicketCartableViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspResultsTicketCartable_Result> data = null;
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
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspResultsTicketCartable_Result>((IEnumerable<MobspResultsTicketCartable_Result>)cRMEntities.MobspResultsTicketCartable(model.Mode, prjTitleGroup: model.PrjTitleGroup, crmUserId: model.CrmUserId, lastRowNumber: model.LastRowNumber, pageSize: model.PageSize, currDateTime: DateTime.Now, closedTicketDate: model.FromDateTime, closedTicketDateTo: model.ToDateTime, userId: token2.userId, languageID: num, defaultLanguageID: result2, prjTitleGroupId: model.PrjTitleGroupId, cnvsStatusGroupId: model.CnvsStatusGroupId, cnvsStatusId: model.CnvsStatusId, priorityId: model.CnvsPriorityId, centerId: model.CenterId));
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
		return new ServiceResult<List<MobspResultsTicketCartable_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> SetProjectToDoTime(SetProjectToDoTimeViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					cRMEntities = new CRMEntities();
					MobspSelectConversationWithID_Result mobspSelectConversationWithID_Result = Enumerable.FirstOrDefault<MobspSelectConversationWithID_Result>((IEnumerable<MobspSelectConversationWithID_Result>)cRMEntities.MobspSelectConversationWithID(model.ConversationId, result, result2));
					if (mobspSelectConversationWithID_Result != null && mobspSelectConversationWithID_Result.cnvsReferUserId > 0 && !UserLogin.IsUserAccess("frmMain", "actcTicketSetToDoTimeAgain", UserLogin.CurrentUser, model.CenterId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgTicketIsTaken,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (model.ToDoYear > 0 || model.ToDoMonth > 0 || model.ToDoDay > 0 || model.ToDoHour > 0 || model.ToDoMinute > 0)
					{
						_ = DateTime.Now;
					}
					else if (UserLogin.IsUserAccess("frmMain", "actcTicketToDoTimeNotNull", UserLogin.CurrentUser, model.CenterId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					string text = string.Format(Messages.TicketMsgCnvsReferDesc, DateTime.Now.ToString("yyyy/MM/dd"), UserLogin.CurrentUser.FullName);
					if (!string.IsNullOrWhiteSpace(model.CnvsReferUserDesc))
					{
						model.CnvsReferUserDesc = text + "\n" + model.CnvsReferUserDesc;
					}
					else
					{
						model.CnvsReferUserDesc = text;
					}
					string text2 = "";
					MobspSelectCrmFoSetting_Result mobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmFoSetting_Result>((IEnumerable<MobspSelectCrmFoSetting_Result>)cRMEntities.MobspSelectCrmFoSetting(result, result2, model.CenterId, null));
					int result3 = 0;
					if (mobspSelectCrmFoSetting_Result != null && mobspSelectCrmFoSetting_Result.TicketAutoReplyAfterSetDoingTime.GetValueOrDefault())
					{
						MobspSelectProjectWithID_Result mobspSelectProjectWithID_Result = Enumerable.FirstOrDefault<MobspSelectProjectWithID_Result>((IEnumerable<MobspSelectProjectWithID_Result>)cRMEntities.MobspSelectProjectWithID(model.ProjectId, num, result2));
						if (mobspSelectProjectWithID_Result != null && mobspSelectProjectWithID_Result.prjIsTicketNew.GetValueOrDefault())
						{
							string text3 = "";
							if (model.ToDoYear > 0)
							{
								text3 = text3 + model.ToDoYear + " " + Labels.Year + " ";
							}
							if (model.ToDoMonth > 0)
							{
								text3 = text3 + model.ToDoMonth + " " + Labels.Month + " ";
							}
							if (model.ToDoDay > 0)
							{
								text3 = text3 + model.ToDoDay + " " + Labels.Day + " ";
							}
							if (model.ToDoHour > 0)
							{
								text3 = text3 + model.ToDoHour + " " + Labels.Hour + " ";
							}
							if (model.ToDoMinute > 0)
							{
								text3 = text3 + model.ToDoMinute + " " + Labels.Minute + " ";
							}
							text3 = text3.Trim();
							ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
							ObjectParameter objectParameter2 = new ObjectParameter("ConversationId", 0);
							cRMEntities.MobspInsertConversationAutoReplyAfterSetDoingTimeTicket(mobspSelectProjectWithID_Result.prjCompanyId, mobspSelectProjectWithID_Result.ProjectID, null, model.ConversationId, null, token2.userId, model.CnvsReferUserId, value, registerDatePersian, ((int)value.DayOfWeek).ToString(), value.ToString("HH:mm:ss"), 0, value3, value2, appType, num, result2, text3, objectParameter, objectParameter2, model.CenterId);
							if (objectParameter != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
							{
								foreach (string item in Enumerable.ToList<string>((IEnumerable<string>)objectParameter.Value.ToString().Split(new char[1] { '|' })))
								{
									if (item == "NotCnvsStatus")
									{
										text2 = text2 + Messages.MobMsgErrorTicketAutoReplyConversationStatusNotConfiged + "<br>";
									}
									if (item == "EmpPerson")
									{
										text2 = text2 + Messages.MobMsgErrorTicketAutoReplyCompanyPersonNotConfiged + "<br>";
									}
									else if (item.Contains("NotSendedSMS"))
									{
										text2 = text2 + string.Format(Messages.MobMsgErrorSendSmsTo, item.Replace("NotSendedSMS[", "").Replace("]", "")) + "<br>";
									}
									else if (item.Contains("NotSendedEmail"))
									{
										text2 = text2 + string.Format(Messages.MobMsgErrorSendEmailTo, item.Replace("NotSendedEmail[", "").Replace("]", "")) + "<br>";
									}
								}
							}
							if (objectParameter2 != null)
							{
								int.TryParse(objectParameter2.Value.ToString(), out result3);
							}
						}
					}
					if (string.IsNullOrWhiteSpace(text2))
					{
						ObjectParameter result4 = new ObjectParameter("Result", 0);
						cRMEntities.MobspUpdateProjectToDoTime(model.ProjectId, model.ToDoYear, model.ToDoMonth, model.ToDoDay, model.ToDoHour, model.ToDoMinute, DateTime.Now, null, token2.userId, value2, value, registerDatePersian, appType, true, model.ConversationId, token2.userId, model.CnvsReferUserId, model.CnvsReferUserDesc, model.CnvsPriorityId, result4, result3);
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = text2;
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
	public ServiceResult<List<TicketHistoryResult>> GetTicketHistory(int projectId, int pageNumber, int? pageSize = 10, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<TicketHistoryResult> list = null;
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
					List<MobspSelectTicketConversationHistoryWithProjectId_Result> list2 = Enumerable.ToList<MobspSelectTicketConversationHistoryWithProjectId_Result>((IEnumerable<MobspSelectTicketConversationHistoryWithProjectId_Result>)cRMEntities.MobspSelectTicketConversationHistoryWithProjectId(projectId, result, result2, pageNumber, pageSize));
					list = new List<TicketHistoryResult>();
					foreach (MobspSelectTicketConversationHistoryWithProjectId_Result item in list2)
					{
						TicketHistoryResult ticketHistoryResult = new TicketHistoryResult();
						ticketHistoryResult.Ticket = item;
						List<MobspSelectFilesDirectory_Result> list3 = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(item.cnvsCompanyId.ToString(), item.cnvsPersonId.ToString(), item.cnvsProjectId.ToString(), "2", item.ConversationID.ToString(), result, result2, false, cId));
						List<FileDirectoryViewModel> list4 = new List<FileDirectoryViewModel>();
						foreach (MobspSelectFilesDirectory_Result item2 in list3)
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
							list4.Add(fileDirectoryViewModel);
						}
						ticketHistoryResult.FileList = list4;
						list.Add(ticketHistoryResult);
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
		return new ServiceResult<List<TicketHistoryResult>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSearchTicketWithProjectId_Result> SearchTicketWithProjectId(int projectId, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSearchTicketWithProjectId_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspSearchTicketWithProjectId_Result>((IEnumerable<MobspSearchTicketWithProjectId_Result>)cRMEntities.MobspSearchTicketWithProjectId(projectId, token2.userId, DateTime.Now, result, result2, cId));
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
		return new ServiceResult<MobspSearchTicketWithProjectId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspCalculateProjectToDoTimes_Result> CalculateProjectToDoTimes(int projectId, int? ln = 1065)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspCalculateProjectToDoTimes_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspCalculateProjectToDoTimes_Result>((IEnumerable<MobspCalculateProjectToDoTimes_Result>)cRMEntities.MobspCalculateProjectToDoTimes(projectId, DateTime.Now));
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
		return new ServiceResult<MobspCalculateProjectToDoTimes_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectTicketNotFinished_Result>> SelectTicketNotFinished(TicketCartableViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectTicketNotFinished_Result> data = null;
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
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectTicketNotFinished_Result>((IEnumerable<MobspSelectTicketNotFinished_Result>)cRMEntities.MobspSelectTicketNotFinished(prjTitleGroup: model.PrjTitleGroup, crmUserId: model.CrmUserId, lastRowNumber: model.LastRowNumber, pageSize: model.PageSize, currDateTime: DateTime.Now, userId: token2.userId, languageID: num, defaultLanguageID: result2, prjTitleGroupId: model.PrjTitleGroupId, cnvsStatusGroupId: model.CnvsStatusGroupId, cnvsStatusId: model.CnvsStatusId, priorityId: model.CnvsPriorityId, centerId: model.CenterId));
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
		return new ServiceResult<List<MobspSelectTicketNotFinished_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspCalculateProjectToDoTimes_Result> SetTicketTitleGroup(int projectId, string prjTitleGroup, int? ln = 1065)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspCalculateProjectToDoTimes_Result data = null;
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
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					cRMEntities.MobspUpdateProjectTitleGroup(projectId, prjTitleGroup, "", token2.userId, value2, value3, value, registerDatePersian, appType, result);
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
		return new ServiceResult<MobspCalculateProjectToDoTimes_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<DateTime?> GetTicketFirstDoingInfo(int projectId, int? ln = 1065)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		DateTime? data = null;
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
					data = Enumerable.FirstOrDefault<DateTime?>((IEnumerable<DateTime?>)cRMEntities.MobspGetTicketFirstDoingInfo(projectId));
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
		return new ServiceResult<DateTime?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectTicketDaily_Result>> SelectTicketDaily(TicketCartableViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectTicketDaily_Result> data = null;
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
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectTicketDaily_Result>((IEnumerable<MobspSelectTicketDaily_Result>)cRMEntities.MobspSelectTicketDaily(model.FromDateTime, model.ToDateTime, token2.userId, model.LastRowNumber, model.PageSize, model.PrjTitleGroup, DateTime.Now, num, result2, model.PrjTitleGroupId, model.CnvsStatusGroupId, model.CnvsStatusId, crmUserId: model.CrmUserId, priorityId: model.CnvsPriorityId, centerId: model.CenterId));
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
		return new ServiceResult<List<MobspSelectTicketDaily_Result>>
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
	public ServiceResult<List<MobspSelectTicketNotFinishedCount_Result>> SelectTicketNotFinishedCount(TicketCartableViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectTicketNotFinishedCount_Result> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					string prjTitleGroup = model.PrjTitleGroup;
					data = Enumerable.ToList<MobspSelectTicketNotFinishedCount_Result>((IEnumerable<MobspSelectTicketNotFinishedCount_Result>)cRMSpEntities2.MobspSelectTicketNotFinishedCount(crmUserId: model.CrmUserId, userId: token2.userId, prjTitleGroup: prjTitleGroup, languageID: num, defaultLanguageID: result2, prjTitleGroupId: model.PrjTitleGroupId, cnvsStatusGroupId: model.CnvsStatusGroupId, cnvsStatusId: model.CnvsStatusId, priorityId: model.CnvsPriorityId, centerId: model.CenterId));
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
		return new ServiceResult<List<MobspSelectTicketNotFinishedCount_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
