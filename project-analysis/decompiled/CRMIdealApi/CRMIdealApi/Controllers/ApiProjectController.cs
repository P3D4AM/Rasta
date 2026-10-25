using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.General.Utilities;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;

namespace CRMIdealApi.Controllers;

public class ApiProjectController : ApiController
{
	[HttpPost]
	public ServiceResult<ApispReturnProjectId_Result> ReturnProjectId(ReturnProjectIdViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispReturnProjectId_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<ApispReturnProjectId_Result>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<ApispReturnProjectId_Result>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<ApispReturnProjectId_Result> serviceResult = new ServiceResult<ApispReturnProjectId_Result>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ApispReturnProjectId_Result apispReturnProjectId_Result = Enumerable.FirstOrDefault<ApispReturnProjectId_Result>((IEnumerable<ApispReturnProjectId_Result>)cRMEntities.ApispReturnProjectId(model.ApiCmpNumber, model.ApiCmpCode, model.ApiPrjTitle, model.ApiPrjPostFix));
			if (apispReturnProjectId_Result != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = apispReturnProjectId_Result;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<ApispReturnProjectId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> Insert(InsertProjectViewModel model)
	{
		CRMEntities cRMEntities = null;
		if (model.ApiCompanyId <= 0)
		{
			model.ApiCompanyId = null;
		}
		if (model.ApiPrjStarterUserId <= 0)
		{
			model.ApiPrjStarterUserId = null;
		}
		if (model.ApiPrjFinishedStatusId <= 0)
		{
			model.ApiPrjFinishedStatusId = null;
		}
		if (model.ApiPrjFinishedUserId <= 0)
		{
			model.ApiPrjFinishedUserId = null;
		}
		if (model.ApiPrjGradeId <= 0)
		{
			model.ApiPrjGradeId = null;
		}
		if (model.ApiPrjPriorityId <= 0)
		{
			model.ApiPrjPriorityId = null;
		}
		if (model.ApiPrjGroupId <= 0)
		{
			model.ApiPrjGroupId = null;
		}
		if (model.ApiPrjCnvsStatusGroupId <= 0)
		{
			model.ApiPrjCnvsStatusGroupId = null;
		}
		if (model.ApiPrjUserDepartmentId <= 0)
		{
			model.ApiPrjUserDepartmentId = null;
		}
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string text = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text = apispSelectLanguages_Result.LanguageCollation;
			}
			string prjStartDate = null;
			string prjStartDay = null;
			string prjStartTime = null;
			string prjFinishedDate = null;
			string prjFinishedDay = null;
			string prjFinishedTime = null;
			string prjRemindDate = null;
			try
			{
				if (model.ApiPrjStartDateTime.HasValue)
				{
					prjStartDate = (model.ApiPrjStartDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					prjStartDay = commonClass.ConvertNameToDayNum((model.ApiPrjStartDateTime ?? DateTime.Now).DayOfWeek.ToString());
					prjStartTime = (model.ApiPrjStartDateTime ?? DateTime.Now).ToString("HH:mm:ss");
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjStartDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPrjFinishedDateTime.HasValue)
				{
					prjFinishedDate = (model.ApiPrjFinishedDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					prjFinishedDay = commonClass.ConvertNameToDayNum((model.ApiPrjFinishedDateTime ?? DateTime.Now).DayOfWeek.ToString());
					prjFinishedTime = (model.ApiPrjFinishedDateTime ?? DateTime.Now).ToString("HH:mm:ss");
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjFinishedDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPrjRemindDateTime.HasValue)
				{
					prjRemindDate = (model.ApiPrjRemindDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjRemindDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrEmpty(model.ApiPrjTitle))
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjTitle", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.ApiPrjPostFix) && model.PrjPostFixNotDup.HasValue && model.PrjPostFixNotDup.GetValueOrDefault())
			{
				string text2 = Company.CantSaveDupPrjPostFix(model.ApiPrjPostFix, 0, result, currLangId, text);
				if (!string.IsNullOrEmpty(text2))
				{
					return new ServiceResult<int>
					{
						Message = text2,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrjDesc) && model.PrjDescNotDup.HasValue && model.PrjDescNotDup.GetValueOrDefault())
			{
				string text3 = Company.CantSaveDupPrjDesc(model.ApiPrjDesc, 0, result, currLangId, text);
				if (!string.IsNullOrEmpty(text3))
				{
					return new ServiceResult<int>
					{
						Message = text3,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			short num2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string registerDay = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string registerTime = now.ToString("HH:mm:ss");
			string person = Labels.Person;
			ObjectParameter objectParameter = new ObjectParameter("InsertedProjectId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertProjects(model.ApiCompanyId, model.ApiCmpNumber, model.ApiCmpCode, model.ApiPrjTitle, model.ApiPrjDesc, prjStartDate, prjStartDay, prjStartTime, model.ApiPrjStartDateTime, model.ApiPrjStarterUserId, model.ApiPrjFinishedStatusId, model.ApiPrjIsFinished, prjFinishedDate, prjFinishedDay, prjFinishedTime, model.ApiPrjFinishedDateTime, model.ApiPrjFinishedUserId, model.ApiPrjGradeId, model.ApiPrjPriorityId, model.ApiPrjGroupId, model.ApiPrjCnvsStatusGroupId, model.ApiPrjOrderView, model.ApiPrjPostFix, prjRemindDate, model.ApiPrjRemindDateTime, model.ApiPrjFOCmpCanSee, model.ApiPrjIsTicket, model.ApiPrjUserDepartmentId, model.ApiPrjInsertCrmProjectForbiddenFUFDPActive, model.ApiPrjInsertProjectInformationsDefualtFieldActive, userId, value2, value, registerDatePersian, registerTime, registerDay, appType, objectParameter, objectParameter2, model.ApiPrjCmpPresentationId, model.ApiPrjCmpCampaignIds, model.ApiPrjCmpCampaignName, model.ApiPrjTitleGroup, model.ApiPrjCategoryId, model.ApiPrjNumR, model.ApiPrjNumRef, model.CenterId, model.CenterCode));
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num3.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<int>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
			{
				string text4 = "";
				string text5 = "";
				string text6 = objectParameter2.Value.ToString();
				if (text6.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Company", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PrjStarterUserId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjStarterUser", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PrjFinishedStatusId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjFinishedStatus", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PrjFinishedUserId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjFinishedUser", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PrjGradeId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjGrade", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PrjPriorityId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjPriority", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PrjGroupId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjGroup", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PrjcnvsStatusGroupId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjcnvsStatusGroup", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PrjUserDepartmentId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjUserDepartment", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PrjCmpPresentationId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjCmpPresentation", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text6.IndexOf("No PrjCategoryId|", StringComparison.Ordinal) >= 0)
				{
					text5 = text5 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjCategory", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text5.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = (MyResource.GetResourceString("ErrorDoneOperation", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>" + resourceString).Replace("<br>", "\r\n");
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Fail;
					return serviceResult;
				}
				FullRegisterResultViewModel fullRegisterResultViewModel = new FullRegisterResultViewModel();
				data = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				message = MyResource.GetResourceString("SuccessDoneRegister", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex4)
		{
			string text7 = ((!string.IsNullOrEmpty(ex4.Message)) ? ex4.Message : "");
			if (ex4.InnerException != null && !string.IsNullOrEmpty(ex4.InnerException.Message))
			{
				text7 = text7 + " - " + ex4.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text7)) ? (" (" + text7 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex4);
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
	public ServiceResult<int> Update(UpdateProjectViewModel model)
	{
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string text = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text = apispSelectLanguages_Result.LanguageCollation;
			}
			string text2 = null;
			string text3 = null;
			string text4 = null;
			string text5 = null;
			string prjFinishedDay = null;
			string prjFinishedTime = null;
			string prjRemindDate = null;
			string prjSmsSendDatePersian = null;
			if (!string.IsNullOrEmpty(model.ApiPrjStartDate) && model.ApiPrjStartDate.ToLower() == "null")
			{
				text2 = model.ApiPrjStartDate;
				model.ApiPrjStartDateTime = null;
				text3 = "null";
				text4 = "null";
			}
			else
			{
				try
				{
					if (model.ApiPrjStartDateTime.HasValue)
					{
						text2 = (model.ApiPrjStartDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
						text3 = commonClass.ConvertNameToDayNum((model.ApiPrjStartDateTime ?? DateTime.Now).DayOfWeek.ToString());
						text4 = (model.ApiPrjStartDateTime ?? DateTime.Now).ToString("HH:mm:ss");
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjStartDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrjFinishedDate) && model.ApiPrjFinishedDate.ToLower() == "null")
			{
				text5 = model.ApiPrjFinishedDate;
				model.ApiPrjFinishedDateTime = null;
				prjFinishedDay = "null";
				prjFinishedTime = "null";
			}
			else
			{
				try
				{
					if (model.ApiPrjFinishedDateTime.HasValue)
					{
						text5 = (model.ApiPrjFinishedDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
						prjFinishedDay = commonClass.ConvertNameToDayNum((model.ApiPrjFinishedDateTime ?? DateTime.Now).DayOfWeek.ToString());
						prjFinishedTime = (model.ApiPrjFinishedDateTime ?? DateTime.Now).ToString("HH:mm:ss");
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjFinishedDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrjRemindDate) && model.ApiPrjRemindDate.ToLower() == "null")
			{
				prjRemindDate = model.ApiPrjRemindDate;
				model.ApiPrjRemindDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiPrjRemindDateTime.HasValue)
					{
						prjRemindDate = (model.ApiPrjRemindDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjRemindDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrjSmsSendDatePersian) && model.ApiPrjSmsSendDatePersian.ToLower() == "null")
			{
				prjSmsSendDatePersian = model.ApiPrjSmsSendDatePersian;
				model.ApiPrjSmsSendDate = null;
			}
			else
			{
				try
				{
					if (model.ApiPrjSmsSendDate.HasValue)
					{
						prjSmsSendDatePersian = (model.ApiPrjSmsSendDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjSmsSendDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiProjectId <= 0 || model.ApiCompanyId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.ApiPrjPostFix) && model.PrjPostFixNotDup.HasValue && model.PrjPostFixNotDup.GetValueOrDefault())
			{
				string text6 = Company.CantSaveDupPrjPostFix(model.ApiPrjPostFix, model.ApiProjectId, result, currLangId, text);
				if (!string.IsNullOrEmpty(text6))
				{
					return new ServiceResult<int>
					{
						Message = text6,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrjDesc) && model.PrjDescNotDup.HasValue && model.PrjDescNotDup.GetValueOrDefault())
			{
				string text7 = Company.CantSaveDupPrjDesc(model.ApiPrjDesc, model.ApiProjectId, result, currLangId, text);
				if (!string.IsNullOrEmpty(text7))
				{
					return new ServiceResult<int>
					{
						Message = text7,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			short num2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string text8 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text9 = now.ToString("HH:mm:ss");
			string person = Labels.Person;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			CRMEntities cRMEntities2 = cRMEntities;
			int? projectID = model.ApiProjectId;
			int? prjCompanyId = model.ApiCompanyId;
			string apiPrjTitle = model.ApiPrjTitle;
			string apiPrjDesc = model.ApiPrjDesc;
			string prjStartDate = text2;
			string prjStartDay = text3;
			string prjStartTime = text4;
			DateTime? apiPrjStartDateTime = model.ApiPrjStartDateTime;
			int? apiPrjStarterUserId = model.ApiPrjStarterUserId;
			int? apiPrjFinishedStatusId = model.ApiPrjFinishedStatusId;
			bool? apiPrjIsFinished = model.ApiPrjIsFinished;
			string prjFinishedDate = text5;
			int num3 = cRMEntities2.ApispUpdateProjects(projectID, prjCompanyId, apiPrjTitle, apiPrjDesc, prjStartDay, prjStartTime, prjStartDate, apiPrjStartDateTime, apiPrjStarterUserId, apiPrjFinishedStatusId, apiPrjIsFinished, prjFinishedDay, prjFinishedTime, prjFinishedDate, model.ApiPrjFinishedDateTime, model.ApiPrjFinishedUserId, model.ApiPrjGradeId, model.ApiPrjPriorityId, model.ApiPrjGroupId, model.ApiPrjCnvsStatusGroupId, model.ApiPrjOrderView, model.ApiPrjPostFix, prjRemindDate, model.ApiPrjRemindDateTime, model.ApiPrjFOCmpCanSee, model.ApiPrjIsTicket, model.ApiPrjUserDepartmentId, null, model.ApiPrjSmsPrsIds, model.ApiPrjSmsText, model.ApiPrjSmsSendDate, prjSmsSendDatePersian, userId, value, registerDatePersian, (short)1, value2, appType, currLangId, result, objectParameter, model.ApiPrjCmpPresentationId, model.ApiPrjCmpCampaignIds, model.ApiPrjCmpCampaignName, model.ApiPrjTitleGroup, model.ApiPrjCategoryId, model.ApiPrjNumR, model.ApiPrjNumRef);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num3.ToString(), out result3);
			if (result3 < 0 && objectParameter.Value == null)
			{
				return new ServiceResult<int>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
			{
				string text10 = "";
				string text11 = "";
				string text12 = objectParameter.Value.ToString();
				if (text12.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text10 = text10 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Company", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrjStarterUserId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjStarterUser", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrjFinishedStatusId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjFinishedStatus", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrjFinishedUserId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjFinishedUser", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrjGradeId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjGrade", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrjPriorityId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjPriority", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrjGroupId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjGroup", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrjcnvsStatusGroupId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjcnvsStatusGroup", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("Not Change PrjcnvsStatusGroupId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + MyResource.GetResourceString("ErrorNotChangePrjcnvsStatusGroupId", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrjUserDepartmentId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjUserDepartment", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrjCmpPresentationId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjCmpPresentation", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrjCategoryId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjCategory", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				FullRegisterResultViewModel fullRegisterResultViewModel = new FullRegisterResultViewModel();
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex5)
		{
			string text13 = ((!string.IsNullOrEmpty(ex5.Message)) ? ex5.Message : "");
			if (ex5.InnerException != null && !string.IsNullOrEmpty(ex5.InnerException.Message))
			{
				text13 = text13 + " - " + ex5.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text13)) ? (" (" + text13 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex5);
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
	public ServiceResult<List<ApispSelectProjects_Result>> Select(SelectProjectViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectProjects_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectProjects_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectProjects_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<List<ApispSelectProjects_Result>> serviceResult = new ServiceResult<List<ApispSelectProjects_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			try
			{
				if (!string.IsNullOrEmpty(model.FromRegisterDate))
				{
					model.FromRegisterDate = model.FromRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.FromRegisterDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.FromRegisterDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi = PersianDate.GetShamsi2Miladi(model.FromRegisterDate);
						value = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<List<ApispSelectProjects_Result>> serviceResult = new ServiceResult<List<ApispSelectProjects_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectProjects_Result>> result3 = serviceResult;
				cRMEntities?.Dispose();
				return result3;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ToRegisterDate))
				{
					model.ToRegisterDate = model.ToRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value2 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.ToRegisterDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.ToRegisterDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi2 = PersianDate.GetShamsi2Miladi(model.ToRegisterDate);
						value2 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi2) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<List<ApispSelectProjects_Result>> serviceResult = new ServiceResult<List<ApispSelectProjects_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectProjects_Result>> result4 = serviceResult;
				cRMEntities?.Dispose();
				return result4;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.FromFirstRegisterDate))
				{
					model.FromFirstRegisterDate = model.FromFirstRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value3 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.FromFirstRegisterDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.FromFirstRegisterDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi3 = PersianDate.GetShamsi2Miladi(model.FromFirstRegisterDate);
						value3 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi3) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				ServiceResult<List<ApispSelectProjects_Result>> serviceResult = new ServiceResult<List<ApispSelectProjects_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectProjects_Result>> result5 = serviceResult;
				cRMEntities?.Dispose();
				return result5;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ToFirstRegisterDate))
				{
					model.ToFirstRegisterDate = model.ToFirstRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value4 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.ToFirstRegisterDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.ToFirstRegisterDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi4 = PersianDate.GetShamsi2Miladi(model.ToFirstRegisterDate);
						value4 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi4) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				ServiceResult<List<ApispSelectProjects_Result>> serviceResult = new ServiceResult<List<ApispSelectProjects_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectProjects_Result>> result6 = serviceResult;
				cRMEntities?.Dispose();
				return result6;
			}
			model.PageSize = ((model.PageNumber.HasValue && model.PageNumber > 0 && (!model.PageSize.HasValue || model.PageSize == 0)) ? new int?(20) : model.PageSize);
			List<ApispSelectProjects_Result> list2 = Enumerable.ToList<ApispSelectProjects_Result>((IEnumerable<ApispSelectProjects_Result>)cRMEntities.ApispSelectProjects(model.ApiProjectId, model.ApiCompanyId, currLangId, result, (!string.IsNullOrEmpty(model.FromRegisterDate)) ? new DateTime?(value) : null, (!string.IsNullOrEmpty(model.ToRegisterDate)) ? new DateTime?(value2) : null, (!string.IsNullOrEmpty(model.FromFirstRegisterDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(model.ToFirstRegisterDate)) ? new DateTime?(value4) : null, model.PageNumber, model.PageSize));
			if (list2 != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectProjects_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteProjectViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<bool> serviceResult = new ServiceResult<bool>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiProjectId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteProject(model.ApiProjectId));
				if (mct_Result != null)
				{
					if (mct_Result.Result > 0)
					{
						data = true;
						message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = false;
						message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = false;
					message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				data = false;
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
