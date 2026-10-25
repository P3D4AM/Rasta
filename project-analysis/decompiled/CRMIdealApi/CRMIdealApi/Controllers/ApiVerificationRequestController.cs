using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CRM.General.PushNotif;
using CRM.General.Security;
using CRM.General.Utilities;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdealApi.Controllers;

public class ApiVerificationRequestController : ApiController
{
	private ResourceManager RS = new ResourceManager();

	private CommonClass comClass = new CommonClass();

	private DateTime registerDate = DateTime.Now;

	private string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());

	private string registerTime = DateTime.Now.ToString("HH:mm:ss");

	private short month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));

	private string appType = CRMIdealApi.Classes.Configuration.AppType;

	[HttpPost]
	public ServiceResult<SelectVerificationRequestResultViewModel> Select(SelectVerificationRequestViewModel model)
	{
		CRMEntities cRMEntities = null;
		SelectVerificationRequestResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<SelectVerificationRequestResultViewModel>
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
				return new ServiceResult<SelectVerificationRequestResultViewModel>
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
				ServiceResult<SelectVerificationRequestResultViewModel> serviceResult = new ServiceResult<SelectVerificationRequestResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiObjectType == 0)
			{
				ServiceResult<SelectVerificationRequestResultViewModel> serviceResult = new ServiceResult<SelectVerificationRequestResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("VerificationRequestObjectType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectVerificationRequests_Result> list2 = Enumerable.ToList<ApispSelectVerificationRequests_Result>((IEnumerable<ApispSelectVerificationRequests_Result>)cRMEntities.ApispSelectVerificationRequests(model.ApiObjectType, model.ApiVerificationRequestId, model.ApiObjectId, model.ApiObjectNumber, model.ApiDyFormId, currLangId, result));
			SelectVerificationRequestResultViewModel selectVerificationRequestResultViewModel = new SelectVerificationRequestResultViewModel();
			selectVerificationRequestResultViewModel.VerificationRequests = new List<SelectVerificationRequestsViewModel>();
			if (list2 != null && Enumerable.Any<ApispSelectVerificationRequests_Result>((IEnumerable<ApispSelectVerificationRequests_Result>)list2))
			{
				foreach (ApispSelectVerificationRequests_Result item in list2)
				{
					SelectVerificationRequestsViewModel selectVerificationRequestsViewModel = new SelectVerificationRequestsViewModel();
					selectVerificationRequestsViewModel.VerificationRequest = new ApispSelectVerificationRequests_Result();
					selectVerificationRequestsViewModel.VerificationRequestDetails = new List<ApispSelectVerificationRequestDetails_Result>();
					selectVerificationRequestsViewModel.VerificationRequest = item;
					selectVerificationRequestsViewModel.VerificationRequestDetails = Enumerable.ToList<ApispSelectVerificationRequestDetails_Result>((IEnumerable<ApispSelectVerificationRequestDetails_Result>)cRMEntities.ApispSelectVerificationRequestDetails(0, item.ApiVerificationRequestId, item.ApiVerificationWorkFlowId, currLangId, result));
					if (selectVerificationRequestsViewModel.VerificationRequestDetails == null || !Enumerable.Any<ApispSelectVerificationRequestDetails_Result>((IEnumerable<ApispSelectVerificationRequestDetails_Result>)selectVerificationRequestsViewModel.VerificationRequestDetails))
					{
						selectVerificationRequestsViewModel.VerificationRequestDetails = new List<ApispSelectVerificationRequestDetails_Result>();
					}
					selectVerificationRequestResultViewModel.VerificationRequests.Add(selectVerificationRequestsViewModel);
				}
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = selectVerificationRequestResultViewModel;
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
		return new ServiceResult<SelectVerificationRequestResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<SelectVerificationWorkFlowResultViewModel> SelectVerificationWorkFlowWithId(SelectVerificationWorkFlowViewModel model)
	{
		CRMEntities cRMEntities = null;
		SelectVerificationWorkFlowResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<SelectVerificationWorkFlowResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<SelectVerificationWorkFlowResultViewModel>
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
				ServiceResult<SelectVerificationWorkFlowResultViewModel> serviceResult = new ServiceResult<SelectVerificationWorkFlowResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ApispSelectVerificationWorkFlowWithId_Result apispSelectVerificationWorkFlowWithId_Result = Enumerable.FirstOrDefault<ApispSelectVerificationWorkFlowWithId_Result>((IEnumerable<ApispSelectVerificationWorkFlowWithId_Result>)cRMEntities.ApispSelectVerificationWorkFlowWithId(model.ApiVerificationWorkFlowId, currLangId, result));
			SelectVerificationWorkFlowResultViewModel selectVerificationWorkFlowResultViewModel = new SelectVerificationWorkFlowResultViewModel();
			if (apispSelectVerificationWorkFlowWithId_Result != null)
			{
				selectVerificationWorkFlowResultViewModel.VerificationWorkFlowId = apispSelectVerificationWorkFlowWithId_Result.VerificationWorkFlowId;
				selectVerificationWorkFlowResultViewModel.ObjectType = apispSelectVerificationWorkFlowWithId_Result.ObjectType;
				selectVerificationWorkFlowResultViewModel.VerificationWorkFlowTitle = apispSelectVerificationWorkFlowWithId_Result.VerificationWorkFlowTitle;
				selectVerificationWorkFlowResultViewModel.VerifyRequestText = apispSelectVerificationWorkFlowWithId_Result.VerifyRequestText;
				selectVerificationWorkFlowResultViewModel.SequenceObservation = apispSelectVerificationWorkFlowWithId_Result.SequenceObservation;
				selectVerificationWorkFlowResultViewModel.IsActive = apispSelectVerificationWorkFlowWithId_Result.IsActive;
				selectVerificationWorkFlowResultViewModel.FirstRegisterDate = apispSelectVerificationWorkFlowWithId_Result.FirstRegisterDate;
				selectVerificationWorkFlowResultViewModel.LanguageId = apispSelectVerificationWorkFlowWithId_Result.LanguageID;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = selectVerificationWorkFlowResultViewModel;
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
		return new ServiceResult<SelectVerificationWorkFlowResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<ApispSelectVerificationRequestDetails_Result> SelectVerificationRequestDetails(SelectVerificationRequestDetailsViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispSelectVerificationRequestDetails_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<ApispSelectVerificationRequestDetails_Result>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<ApispSelectVerificationRequestDetails_Result>
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
				ServiceResult<ApispSelectVerificationRequestDetails_Result> serviceResult = new ServiceResult<ApispSelectVerificationRequestDetails_Result>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ApispSelectVerificationRequestDetails_Result apispSelectVerificationRequestDetails_Result = Enumerable.FirstOrDefault<ApispSelectVerificationRequestDetails_Result>((IEnumerable<ApispSelectVerificationRequestDetails_Result>)cRMEntities.ApispSelectVerificationRequestDetails(model.ApiVerificationRequestDetailId, model.ApiVerificationRequestId, model.ApiVerificationWorkFlowId, currLangId, result));
			ApispSelectVerificationRequestDetails_Result apispSelectVerificationRequestDetails_Result2 = new ApispSelectVerificationRequestDetails_Result();
			if (apispSelectVerificationRequestDetails_Result != null)
			{
				apispSelectVerificationRequestDetails_Result2 = apispSelectVerificationRequestDetails_Result;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = apispSelectVerificationRequestDetails_Result2;
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
		return new ServiceResult<ApispSelectVerificationRequestDetails_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<ApispSelectVerificationWorkFlowSteps_Result> SelectVerificationWorkFlowSteps(SelectVerificationWorkFlowStepsViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispSelectVerificationWorkFlowSteps_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<ApispSelectVerificationWorkFlowSteps_Result>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<ApispSelectVerificationWorkFlowSteps_Result>
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
				ServiceResult<ApispSelectVerificationWorkFlowSteps_Result> serviceResult = new ServiceResult<ApispSelectVerificationWorkFlowSteps_Result>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ApispSelectVerificationWorkFlowSteps_Result apispSelectVerificationWorkFlowSteps_Result = Enumerable.FirstOrDefault<ApispSelectVerificationWorkFlowSteps_Result>((IEnumerable<ApispSelectVerificationWorkFlowSteps_Result>)cRMEntities.ApispSelectVerificationWorkFlowSteps(model.ApiVerificationWorkFlowId, currLangId, result));
			ApispSelectVerificationWorkFlowSteps_Result apispSelectVerificationWorkFlowSteps_Result2 = new ApispSelectVerificationWorkFlowSteps_Result();
			if (apispSelectVerificationWorkFlowSteps_Result != null)
			{
				apispSelectVerificationWorkFlowSteps_Result2 = apispSelectVerificationWorkFlowSteps_Result;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = apispSelectVerificationWorkFlowSteps_Result2;
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
		return new ServiceResult<ApispSelectVerificationWorkFlowSteps_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<ApispSelectVerificationRequestObjectInfo_Result> SelectVerificationRequestObjectInfo(SelectVerificationRequestObjectInfoViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispSelectVerificationRequestObjectInfo_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<ApispSelectVerificationRequestObjectInfo_Result>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<ApispSelectVerificationRequestObjectInfo_Result>
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
				ServiceResult<ApispSelectVerificationRequestObjectInfo_Result> serviceResult = new ServiceResult<ApispSelectVerificationRequestObjectInfo_Result>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ApispSelectVerificationRequestObjectInfo_Result apispSelectVerificationRequestObjectInfo_Result = Enumerable.FirstOrDefault<ApispSelectVerificationRequestObjectInfo_Result>((IEnumerable<ApispSelectVerificationRequestObjectInfo_Result>)cRMEntities.ApispSelectVerificationRequestObjectInfo(model.ApiObjectId, model.ApiObjectType, currLangId, result, model.CenterId, model.CenterCode));
			ApispSelectVerificationRequestObjectInfo_Result apispSelectVerificationRequestObjectInfo_Result2 = new ApispSelectVerificationRequestObjectInfo_Result();
			if (apispSelectVerificationRequestObjectInfo_Result != null)
			{
				apispSelectVerificationRequestObjectInfo_Result2 = apispSelectVerificationRequestObjectInfo_Result;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = apispSelectVerificationRequestObjectInfo_Result2;
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
		return new ServiceResult<ApispSelectVerificationRequestObjectInfo_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<ApispSelectVerificationWorkFlowWithObjectType_Result> SelectVerificationWorkFlowWithObjectType(SelectVerificationWorkFlowWithObjectTypeViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispSelectVerificationWorkFlowWithObjectType_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<ApispSelectVerificationWorkFlowWithObjectType_Result>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<ApispSelectVerificationWorkFlowWithObjectType_Result>
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
				ServiceResult<ApispSelectVerificationWorkFlowWithObjectType_Result> serviceResult = new ServiceResult<ApispSelectVerificationWorkFlowWithObjectType_Result>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ApispSelectVerificationWorkFlowWithObjectType_Result apispSelectVerificationWorkFlowWithObjectType_Result = Enumerable.FirstOrDefault<ApispSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<ApispSelectVerificationWorkFlowWithObjectType_Result>)cRMEntities.ApispSelectVerificationWorkFlowWithObjectType(model.ApiObjectType, currLangId, result));
			ApispSelectVerificationWorkFlowWithObjectType_Result apispSelectVerificationWorkFlowWithObjectType_Result2 = new ApispSelectVerificationWorkFlowWithObjectType_Result();
			if (apispSelectVerificationWorkFlowWithObjectType_Result != null)
			{
				apispSelectVerificationWorkFlowWithObjectType_Result2 = apispSelectVerificationWorkFlowWithObjectType_Result;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = apispSelectVerificationWorkFlowWithObjectType_Result2;
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
		return new ServiceResult<ApispSelectVerificationWorkFlowWithObjectType_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> VerificationRequestVerify(VerificationRequestVerifyViewModel model, string formName, int objectType)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string data = null;
		string text = "";
		ServiceResultStatus status = ServiceResultStatus.Success;
		if (!VersionBuyer.CRMApi)
		{
			return new ServiceResult<string>
			{
				Message = Messages.ErrorAccessAPILimited,
				Data = null,
				Status = ServiceResultStatus.Error
			};
		}
		ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
		if (apispSelectCrmsysSetting_Result == null)
		{
			return new ServiceResult<string>
			{
				Message = Messages.ErrorInReadingSysSetting,
				Data = null,
				Status = ServiceResultStatus.Error
			};
		}
		int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var defLangId);
		if (defLangId <= 0)
		{
			defLangId = 1065;
		}
		List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
		int.TryParse(model.LanguageId.ToString(), out var currLangId);
		if (currLangId <= 0)
		{
			currLangId = defLangId;
		}
		string text2 = "fa-IR";
		ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
		if (apispSelectLanguages_Result != null)
		{
			text2 = apispSelectLanguages_Result.LanguageCollation;
		}
		string text3 = "";
		int num = 0;
		DateTime now = DateTime.Now;
		DateTime value = now;
		string text4 = now.ToString("yyyyMMdd", new PersianCulture());
		short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
		if (base.ModelState.IsValid)
		{
			int msgTypeId = 0;
			if (!string.IsNullOrEmpty(formName))
			{
				switch (formName)
				{
				case "PORD":
					msgTypeId = 5;
					break;
				case "ORD":
					msgTypeId = 8;
					break;
				case "DyFrm":
					msgTypeId = 16;
					break;
				case "DOC":
				case "DRAFT":
				case "MOVEMENTWRHS":
					msgTypeId = 20;
					break;
				case "LEAVE":
					msgTypeId = 6;
					break;
				case "MISSION":
					msgTypeId = 7;
					break;
				}
			}
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.VerifyText,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = model.VerifyRequestText,
				LanguageId = currLangId
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ReasonCancellation,
				LanguageId = currLangId
			});
			if (model.CenterId.GetValueOrDefault() == 0 && string.IsNullOrWhiteSpace(model.CenterCode))
			{
				model.CenterId = Center.GetTop1().CenterID;
			}
			else if (model.CenterId.GetValueOrDefault() != 0 && !Center.Exists(model.CenterId))
			{
				model.CenterId = null;
			}
			else if (string.IsNullOrWhiteSpace(model.CenterCode) && !Center.Exists(model.CenterCode))
			{
				model.CenterId = null;
			}
			if (model.CenterId.GetValueOrDefault() == 0)
			{
				text3 = text3 + RS.Get("msgErrorCenterNotFound", text2, RS.TypeMsg) + "<br/>";
				status = ServiceResultStatus.Fail;
				num++;
			}
			if (model.VerificationWorkFlowId == 0)
			{
				text3 = text3 + RS.GetII("ErrorEmpty", text2, RS.TypeMsg, "PordVerificationReqWorkflowId", null, RS.TypeLbl) + "<br/>";
				status = ServiceResultStatus.Fail;
				num++;
			}
			if (model.VerifyUserId.HasValue && model.VerifyUserId.GetValueOrDefault() == -101)
			{
				text3 = text3 + RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepResponsibleUser", null, RS.TypeLbl) + "<br/>";
				status = ServiceResultStatus.Fail;
				num++;
			}
			else if (model.VerifyUserId.HasValue && model.VerifyUserId.GetValueOrDefault() == -102)
			{
				text3 = text3 + RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepCmpReferUser", null, RS.TypeLbl) + "<br/>";
				status = ServiceResultStatus.Fail;
				num++;
			}
			else if (model.VerifyUserId.HasValue && model.VerifyUserId.GetValueOrDefault() == -103)
			{
				text3 = text3 + RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepCmpSuppUser", null, RS.TypeLbl) + "<br/>";
				status = ServiceResultStatus.Fail;
				num++;
			}
			if (model.Mode == 1 || model.Mode == 2)
			{
				if (model.VerifyRequestText == null)
				{
					text3 = text3 + RS.GetII("ErrorEmpty", text2, RS.TypeMsg, "PordVerificationReqVerifyText", null, RS.TypeLbl) + "<br/>";
					status = ServiceResultStatus.Fail;
					num++;
				}
			}
			else if (model.Mode == 3 || model.Mode == 4 || model.Mode == 5)
			{
				if (model.VerifyText == null)
				{
					text3 = text3 + RS.GetII("ErrorEmpty", text2, RS.TypeMsg, "PordVerificationReqStepVerifyText", null, RS.TypeLbl) + "<br/>";
					status = ServiceResultStatus.Fail;
					num++;
				}
				if (model.Mode == 3 && (!model.VerifyUserId.HasValue || model.VerifyUserId == 0))
				{
					text3 = text3 + RS.GetII("ErrorEmpty", text2, RS.TypeMsg, "PordVerificationReqVerifyUserId", null, RS.TypeLbl) + "<br/>";
					status = ServiceResultStatus.Fail;
					num++;
				}
				if (model.Mode == 5 && (!model.AlternateVerifyUserId.HasValue || model.AlternateVerifyUserId == 0))
				{
					text3 = text3 + RS.Get("ErrorHaveNotAlternateVerifyUser", text2, RS.TypeMsg) + "<br/>";
					status = ServiceResultStatus.Fail;
					num++;
				}
			}
			else if (model.Mode == 6)
			{
				if (model.ReasonCancellation == null)
				{
					text3 = text3 + RS.GetII("ErrorEmpty", text2, RS.TypeMsg, "PordVerificationReqReasonCancellation", null, RS.TypeLbl) + "<br/>";
					status = ServiceResultStatus.Fail;
					num++;
				}
				if (!model.VerificationRequestId.HasValue || model.VerificationRequestId == 0)
				{
					text3 = text3 + RS.GetII("ErrorEmpty", text2, RS.TypeMsg, "PordVerificationReqVerification", null, RS.TypeLbl) + "<br/>";
					status = ServiceResultStatus.Fail;
					num++;
				}
			}
			if (num == 0)
			{
				DateTime now2 = DateTime.Now;
				int result = 0;
				int.TryParse(model.ApiObjectId.ToString(), out result);
				try
				{
					if (model.Mode == 1)
					{
						text3 = "";
						string verificationReqText = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						string msgSubject = RS.Get("VerifiedRequestSubject", RS.Per_Collation, RS.TypeLbl);
						string text5 = "";
						foreach (ApispSelectLanguages_Result lang5 in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID != defLangId))))
						{
							string text6 = "";
							string text7 = "";
							text6 = RS.Get("VerifiedRequestSubject", lang5.LanguageCollation, RS.TypeLbl);
							text7 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)).Value : "");
							text5 = text5 + "[LangId=" + lang5.LanguageID + "|,|Txt=" + text7 + "|,|Subj=" + text6 + "|,|]@";
						}
						if (model.VerificationReqUserId.GetValueOrDefault() == 0)
						{
							model.VerificationReqUserId = model.UserId;
						}
						ObjectParameter objectParameter = new ObjectParameter("result", 0);
						int num2 = cRMEntities.ApispSendVerificationRequest(model.VerificationWorkFlowId, model.ApiObjectId, verificationReqText, text5, msgSubject, now2, text4, model.UserId, month1, appType, defLangId, objectParameter, model.VerificationReqUserId, null, null);
						if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							switch (objectParameter.Value.ToString())
							{
							case "-2":
								text3 += RS.Get("ErrorErrorSendingMessages", text2, RS.TypeMsg);
								status = ServiceResultStatus.Fail;
								break;
							case "-1":
								text3 += RS.Get("ErrorRunFunction", text2, RS.TypeMsg);
								status = ServiceResultStatus.Fail;
								break;
							case "-101":
								text3 += RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepResponsibleUser", text2, RS.TypeLbl);
								status = ServiceResultStatus.Fail;
								break;
							case "-102":
								text3 += RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepCmpReferUser", text2, RS.TypeLbl);
								status = ServiceResultStatus.Fail;
								break;
							case "-103":
								text3 += RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepCmpSuppUser", text2, RS.TypeLbl);
								status = ServiceResultStatus.Fail;
								break;
							case "-106":
								text3 += RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepSellerUser", text2, RS.TypeLbl);
								status = ServiceResultStatus.Fail;
								break;
							case "-109":
								text3 += RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepSaleCenterReferUser", text2, RS.TypeLbl);
								status = ServiceResultStatus.Fail;
								break;
							}
						}
					}
					else if (model.Mode == 2)
					{
						text3 = "";
						string verificationReqText2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						string msgSubject2 = RS.Get("VerifiedRequestSubject", RS.Per_Collation, RS.TypeLbl);
						string text8 = "";
						foreach (ApispSelectLanguages_Result lang4 in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID != defLangId))))
						{
							string text9 = "";
							string text10 = "";
							text9 = RS.Get("VerifiedRequestSubject", text2, RS.TypeLbl);
							text10 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)).Value : "");
							text8 = text8 + "[LangId=" + lang4.LanguageID + "|,|Txt=" + text10 + "|,|Subj=" + text9 + "|,|]@";
						}
						if (model.VerificationReqUserId.GetValueOrDefault() == 0)
						{
							model.VerificationReqUserId = model.UserId;
						}
						ObjectParameter objectParameter2 = new ObjectParameter("result", 0);
						int num3 = cRMEntities.ApispSendVerificationRequestToAlternateUser(model.VerificationWorkFlowId, model.ApiObjectId, verificationReqText2, text8, msgSubject2, now2, text4, model.UserId, month1, appType, defLangId, objectParameter2, model.VerificationReqUserId, null, null);
						if (objectParameter2.Value != null && !string.IsNullOrEmpty(objectParameter2.Value.ToString()))
						{
							switch (objectParameter2.Value.ToString())
							{
							case "-3":
								text3 += RS.Get("ErrorHaveNotAlternateVerifyUser", text2, RS.TypeMsg);
								status = ServiceResultStatus.Fail;
								break;
							case "-2":
								text3 += RS.Get("ErrorErrorSendingMessages", text2, RS.TypeMsg);
								status = ServiceResultStatus.Fail;
								break;
							case "-1":
								text3 += RS.Get("ErrorRunFunction", text2, RS.TypeMsg);
								status = ServiceResultStatus.Fail;
								break;
							}
						}
					}
					else if (model.Mode == 3)
					{
						text3 = "";
						string verifyText = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						string msgSubject3 = RS.Get("VerifiedRequestSubject", RS.Per_Collation, RS.TypeLbl);
						string text11 = "";
						string verifiedMsgSubject = RS.Get("VerifiedRequestVerify", RS.Per_Collation, RS.TypeLbl);
						foreach (ApispSelectLanguages_Result lang3 in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID != defLangId))))
						{
							string text12 = "";
							string text13 = "";
							string text14 = "";
							text12 = RS.Get("VerifiedRequestSubject", text2, RS.TypeLbl);
							text12 = RS.Get("VerifiedRequestSubject", text2, RS.TypeLbl);
							text14 = RS.Get("VerifiedRequestVerify", text2, RS.TypeLbl);
							text13 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)).Value : "");
							text11 = text11 + "[LangId=" + lang3.LanguageID + "|,|Txt=" + text13 + "|,|Subj=" + text12 + "|,|VerifiedSubj=" + text14 + "|,|]@";
						}
						ObjectParameter objectParameter3 = new ObjectParameter("result", "");
						ObjectParameter objectParameter4 = new ObjectParameter("maxDiscountPercent", typeof(decimal));
						int num4 = cRMEntities.ApispVerificationRequestVerify(model.VerificationWorkFlowId, model.ApiObjectId, model.VerificationRequestId, model.VerificationWorkFlowStepId, verifyText, text11, msgSubject3, verifiedMsgSubject, model.ApiRollId, now2, text4, model.UserId, month1, appType, currLangId, defLangId, objectParameter4, objectParameter3, null, null);
						string text15 = "";
						if (objectParameter4.Value != null && !string.IsNullOrEmpty(objectParameter4.Value.ToString()))
						{
							text15 = objectParameter4.Value.ToString();
						}
						if (objectParameter3.Value != null && !string.IsNullOrEmpty(objectParameter3.Value.ToString()))
						{
							string text16 = objectParameter3.Value.ToString();
							if (text16 == "-6")
							{
								List<ApispDySelectFormWorkflowStepsNotCheckedForMasterValue_Result> list5 = Enumerable.ToList<ApispDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>((IEnumerable<ApispDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>)cRMEntities.ApispDySelectFormWorkflowStepsNotCheckedForMasterValue(model.ApiObjectId, currLangId, defLangId));
								if (list5 != null && Enumerable.Any<ApispDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>((IEnumerable<ApispDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>)list5))
								{
									string text17 = "";
									foreach (ApispDySelectFormWorkflowStepsNotCheckedForMasterValue_Result item2 in list5)
									{
										if (!string.IsNullOrWhiteSpace(item2.WorkflowStepTitle))
										{
											text17 = text17 + item2.WorkflowStepTitle + "<br>";
										}
									}
									text3 = text3 + RS.Get("ErrorDyFrmNotConfirmSteps", text2, RS.TypeMsg) + "<br>" + text17;
									status = ServiceResultStatus.Fail;
								}
							}
							else if (text16 == "-5")
							{
								text3 += RS.Get("ErrorRunFunction", text2, RS.TypeMsg);
								status = ServiceResultStatus.Fail;
							}
							else if (text16.IndexOf("-4|", StringComparison.Ordinal) >= 0)
							{
								text3 = text3 + string.Format(RS.Get("ErrorCheckVerificationWorkflowStepBFCurr", text2, RS.TypeMsg), text16.Replace("-4|", "") ?? "") + "<br>";
								status = ServiceResultStatus.Fail;
							}
							else
							{
								switch (text16)
								{
								case "-3":
									if (!string.IsNullOrEmpty(formName))
									{
										if (formName == "PORD")
										{
											text3 = text3 + RS.Get("MaxDiscountPercentPreOrderInActivePreOrder", text2, RS.TypeMsg) + " " + text15;
											status = ServiceResultStatus.Fail;
										}
										else if (formName == "ORD")
										{
											text3 = text3 + RS.Get("MaxDiscountPercentOrderInActiveOrder", text2, RS.TypeMsg) + " " + text15;
											status = ServiceResultStatus.Fail;
										}
									}
									break;
								case "-2":
									if (!string.IsNullOrEmpty(formName))
									{
										if (formName == "PORD")
										{
											text3 = text3 + RS.Get("MaxDiscountPercentInActivePreOrder", text2, RS.TypeMsg) + " " + text15;
											status = ServiceResultStatus.Fail;
										}
										else if (formName == "ORD")
										{
											text3 = text3 + RS.Get("MaxDiscountPercentInActiveOrder", text2, RS.TypeMsg) + " " + text15;
											status = ServiceResultStatus.Fail;
										}
									}
									break;
								case "-1":
									text3 += RS.Get("ErrorDivisionByZero", text2, RS.TypeMsg);
									status = ServiceResultStatus.Fail;
									break;
								case "-101":
									text3 += RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepResponsibleUser", null, RS.TypeLbl);
									status = ServiceResultStatus.Fail;
									break;
								case "-102":
									text3 += RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepCmpReferUser", null, RS.TypeLbl);
									status = ServiceResultStatus.Fail;
									break;
								case "-103":
									text3 += RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepCmpSuppUser", null, RS.TypeLbl);
									status = ServiceResultStatus.Fail;
									break;
								case "-106":
									text3 += RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepSellerUser", text2, RS.TypeLbl);
									status = ServiceResultStatus.Fail;
									break;
								case "-109":
									text3 += RS.GetII("ErrorIsNotSpecified", text2, RS.TypeMsg, "VerificationWorkFlowStepSaleCenterReferUser", text2, RS.TypeLbl);
									status = ServiceResultStatus.Fail;
									break;
								}
							}
						}
					}
					else if (model.Mode == 4)
					{
						text3 = "";
						string messageText = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : "");
						string msgSubject4 = RS.Get("IsNotVerifiedSubject", RS.Per_Collation, RS.TypeMsg);
						string text18 = "";
						foreach (ApispSelectLanguages_Result lang2 in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID != defLangId))))
						{
							string text19 = "";
							string text20 = "";
							string text21 = "";
							text19 = RS.Get("VerifiedRequestSubject", text2, RS.TypeLbl);
							text21 = RS.Get("IsNotVerifiedSubject", text2, RS.TypeLbl);
							text20 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : "");
							text18 = text18 + "[LangId=" + lang2.LanguageID + "|,|Txt=" + text20 + "|,|Subj=" + text19 + "|,|VerifiedSubj=" + text21 + "|,|]@";
						}
						ObjectParameter objectParameter5 = new ObjectParameter("result", "");
						int num5 = cRMEntities.ApispVerificationRequestExpired(model.VerificationRequestId, model.VerificationWorkFlowId, model.ApiObjectId, messageText, text18, msgSubject4, now2, text4, model.UserId, month1, appType, currLangId, defLangId, objectParameter5, model.CancellationStepId, model.ReasonCancellation, null, null);
						if (objectParameter5.Value != null && !string.IsNullOrEmpty(objectParameter5.Value.ToString()))
						{
							string text22 = objectParameter5.Value.ToString();
							if (text22 != "1")
							{
								text3 += RS.Get("ErrorRunFunction", text2, RS.TypeMsg);
								status = ServiceResultStatus.Fail;
							}
						}
					}
					else if (model.Mode == 5)
					{
						text3 = "";
						string message = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						string subject = RS.Get("VerifiedRequestSubject", RS.Per_Collation, RS.TypeLbl);
						List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
						foreach (ApispSelectLanguages_Result item3 in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID != defLangId))))
						{
							string text23 = "";
							string text24 = "";
							string text25 = "";
							text23 = RS.Get("VerifiedRequestSubject", text2, RS.TypeLbl);
							CommonMultiLanguageViewModel item = new CommonMultiLanguageViewModel
							{
								Value = text23,
								LanguageId = item3.LanguageID
							};
							list6.Add(item);
						}
						int result2 = 0;
						int.TryParse(model.VerificationReqUserId.ToString(), out result2);
						int result3 = 0;
						int.TryParse(model.AlternateVerifyUserId.ToString(), out result3);
						if (result3 > 0 && result2 > 0)
						{
							ServiceResult<string> serviceResult = SendMessage(result2, result3, msgTypeId, subject, message, list2, result, model.VerificationWorkFlowStepId, list6, model.UserId, model.CenterId);
						}
						else
						{
							text3 += RS.Get("ErrorHaveNotAlternateVerifyUser", text2, RS.TypeMsg);
							status = ServiceResultStatus.Fail;
						}
					}
					else if (model.Mode == 6)
					{
						string messageText2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : "");
						string msgSubject5 = RS.Get("IsNotVerifiedSubject", RS.Per_Collation, RS.TypeMsg);
						string text26 = "";
						foreach (ApispSelectLanguages_Result lang in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID != defLangId))))
						{
							string text27 = "";
							string text28 = "";
							string text29 = "";
							text27 = RS.Get("VerifiedRequestSubject", text2, RS.TypeLbl);
							text29 = RS.Get("IsNotVerifiedSubject", text2, RS.TypeMsg);
							text28 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
							text26 = text26 + "[LangId=" + lang.LanguageID + "|,|Txt=" + text28 + "|,|Subj=" + text27 + "|,|VerifiedSubj=" + text29 + "|,|]@";
						}
						ObjectParameter objectParameter6 = new ObjectParameter("result", "");
						int num6 = cRMEntities.ApispVerificationRequestExpired(model.VerificationRequestId, model.VerificationWorkFlowId, model.ApiObjectId, messageText2, text26, msgSubject5, now2, text4, model.UserId, month1, appType, currLangId, defLangId, objectParameter6, model.CancellationStepId, model.ReasonCancellation, null, null);
						if (objectParameter6.Value != null && !string.IsNullOrEmpty(objectParameter6.Value.ToString()))
						{
							string text30 = objectParameter6.Value.ToString();
							if (text30 != "1")
							{
								text3 += RS.Get("ErrorRunFunction", text2, RS.TypeMsg);
								status = ServiceResultStatus.Fail;
							}
						}
					}
					if (string.IsNullOrWhiteSpace(text3))
					{
						if (objectType == 20)
						{
							ApispSelectOrderById_Result apispSelectOrderById_Result = Enumerable.FirstOrDefault<ApispSelectOrderById_Result>((IEnumerable<ApispSelectOrderById_Result>)cRMEntities.ApispSelectOrderById(model.ApiObjectId, currLangId, defLangId));
							if (apispSelectOrderById_Result != null)
							{
								bool result4 = false;
								bool.TryParse(apispSelectOrderById_Result.ordIsVerified.ToString(), out result4);
								if (result4)
								{
									int? orderId = model.ApiObjectId;
									bool? calcAutoScoreInIssue = false;
									bool? calcAutoScoreInVerify = true;
									ObjectResult<ApiScorespInsertAndCalcOrderScores_Result> objectResult = cRMEntities.ApiScorespInsertAndCalcOrderScores(null, orderId, null, null, null, calcAutoScoreInIssue, calcAutoScoreInVerify, DateTime.Now, model.UserId, value2, month1, value, text4, appType, currLangId, defLangId, null, true, model.CenterId, model.CenterCode, false);
									int apiObjectId = model.ApiObjectId;
									if (apiObjectId > 0)
									{
										string msg = "";
										AddProjectProductHistoryFromOrder(apiObjectId, addPrdValidity: false, "", currLangId, defLangId, model.UserId, ref msg);
										if (!string.IsNullOrWhiteSpace(msg))
										{
											Exception e = new Exception(msg);
											ErrorSignal.FromCurrentContext().Raise(e);
										}
									}
								}
								else
								{
									mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApiScorespDeleteOrderScores(model.ApiObjectId, model.UserId, value2, month1, value, text4, appType, defLangId));
									if (mct_Result != null && mct_Result.Result == 0)
									{
										text3 = RS.Get("ErrorRunFunction", text2, RS.TypeMsg);
										status = ServiceResultStatus.Fail;
									}
								}
							}
						}
						if (objectType == 60)
						{
							ApispSelectDocById_Result apispSelectDocById_Result = Enumerable.FirstOrDefault<ApispSelectDocById_Result>((IEnumerable<ApispSelectDocById_Result>)cRMEntities.ApispSelectDocById(model.ApiObjectId, currLangId, defLangId));
							if (apispSelectDocById_Result != null)
							{
								bool result5 = false;
								bool.TryParse(apispSelectDocById_Result.IsVerified.ToString(), out result5);
								int result6 = 0;
								int.TryParse(apispSelectDocById_Result.OprType.ToString(), out result6);
								if (result5 && false)
								{
									string text31 = model.ApiObjectId.ToString();
									ReferDocToOrdReferUser(text31, userId: model.UserId, currUserId: 0);
								}
							}
						}
					}
					NewIntMsgNotify();
					if (string.IsNullOrEmpty(text3) && model.MsgId.GetValueOrDefault() > 0)
					{
						SetMessageRead(model.MsgId.GetValueOrDefault(), msgTypeId, model.UserId);
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					text3 = RS.Get("ErrorRunFunction", text2, RS.TypeMsg);
					status = ServiceResultStatus.Fail;
				}
			}
		}
		return new ServiceResult<string>
		{
			Message = text3,
			Data = data,
			Status = status
		};
	}

	private ServiceResult<string> SendMessage(int fromUserId, int toUserId, int msgTypeId, string subject, string message, List<CommonMultiLanguageViewModel> msglist, int objectId, int? workflowStepId = null, List<CommonMultiLanguageViewModel> sublist = null, int userId = 0, int? centerId = null)
	{
		string text = "";
		try
		{
			CRMEntities cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var defLangId);
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			int currLangId = defLangId;
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedID", 0);
			int num = cRMEntities.ApispInternalMessageSendSingle(null, subject, message, msgTypeId, fromUserId, toUserId, registerDatePersian, registerTime, registerDate, null, null, objectId, null, null, userId, month1, registerDate, registerDatePersian, appType, objectParameter, defLangId, workflowStepId, null, null, centerId);
			int num2 = (int)objectParameter.Value;
			List<InternalMessage_LangViewModel> list2 = new List<InternalMessage_LangViewModel>();
			foreach (ApispSelectLanguages_Result lang in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result c) => c.LanguageID != defLangId))))
			{
				string msgBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)msglist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)msglist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				string msgSubject = subject;
				if (sublist != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist))
				{
					msgSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : subject);
				}
				list2.Add(new InternalMessage_LangViewModel
				{
					InternalMessageID = num2,
					LanguageID = lang.LanguageID,
					msgSubject = msgSubject,
					msgBody = msgBody
				});
			}
			cRMEntities.ApispInternalMessageSendSingle_Lang(JsonConvert.SerializeObject(list2));
			if (num2 <= 0)
			{
				text = RS.Get("SuccessDoneRegister", rsCollation, RS.TypeMsg);
			}
			NewIntMsgNotify();
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = ex.Message;
		}
		return new ServiceResult<string>
		{
			Message = text,
			Data = null,
			Status = (string.IsNullOrWhiteSpace(text) ? ServiceResultStatus.Success : ServiceResultStatus.Error)
		};
	}

	public bool SetMessageRead(int msgId, int msgTypeId, int userId)
	{
		try
		{
			CRMEntities cRMEntities = new CRMEntities();
			string date = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string time = DateTime.Now.ToString("HH:mm:ss");
			cRMEntities.ApispInternalMessageUpdate("Read", msgId, userId, msgTypeId, time, date, CRMIdealApi.Classes.Configuration.AppType);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
		return true;
	}

	public void NewIntMsgNotify(int langId = 1065)
	{
		CRMEntities cRMEntities = null;
		try
		{
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return;
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			int currLangId = langId;
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			cRMEntities = new CRMEntities();
			List<ApispSelectUserPushNotifTankWithDeviceInfo_Result> list2 = Enumerable.ToList<ApispSelectUserPushNotifTankWithDeviceInfo_Result>((IEnumerable<ApispSelectUserPushNotifTankWithDeviceInfo_Result>)cRMEntities.ApispSelectUserPushNotifTankWithDeviceInfo(1, null));
			foreach (ApispSelectUserPushNotifTankWithDeviceInfo_Result item in list2)
			{
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				List<MobAppDevSettingViewModel> list5 = new List<MobAppDevSettingViewModel>();
				if (!string.IsNullOrEmpty(item.MobAppDevSetting))
				{
					list5 = JsonConvert.DeserializeObject<List<MobAppDevSettingViewModel>>(item.MobAppDevSetting);
				}
				List<UserAppDeviceInfoViewModel> list6 = new List<UserAppDeviceInfoViewModel>();
				if (!string.IsNullOrEmpty(item.DeviceInfo))
				{
					list6 = JsonConvert.DeserializeObject<List<UserAppDeviceInfoViewModel>>(item.DeviceInfo);
				}
				foreach (UserAppDeviceInfoViewModel info in list6)
				{
					MobAppDevSettingViewModel mobAppDevSettingViewModel = Enumerable.FirstOrDefault<MobAppDevSettingViewModel>(Enumerable.Where<MobAppDevSettingViewModel>((IEnumerable<MobAppDevSettingViewModel>)list5, (Func<MobAppDevSettingViewModel, bool>)((MobAppDevSettingViewModel e) => e.dType == info.DeviceType)));
					if (mobAppDevSettingViewModel == null)
					{
						continue;
					}
					bool flag = false;
					bool flag2 = false;
					if (info.DeviceType == 1 || info.DeviceType == 3)
					{
						if (mobAppDevSettingViewModel.intMsgNotifOnOpenActive.GetValueOrDefault())
						{
							flag = true;
						}
						if (mobAppDevSettingViewModel.intMsgNotifOnBgActive.GetValueOrDefault() && mobAppDevSettingViewModel.intMsgNotifOnCloseActive.GetValueOrDefault())
						{
							flag2 = true;
							flag = false;
						}
					}
					else if (info.DeviceType == 2)
					{
						if (mobAppDevSettingViewModel.intMsgNotifOnOpenActive.GetValueOrDefault())
						{
							flag = true;
						}
						if (mobAppDevSettingViewModel.intMsgNotifOnBgActive.GetValueOrDefault())
						{
							flag = true;
						}
						if (mobAppDevSettingViewModel.intMsgNotifOnCloseActive.GetValueOrDefault())
						{
							flag2 = true;
							flag = false;
						}
					}
					if (!string.IsNullOrEmpty(info.DeviceId))
					{
						if (flag)
						{
							list3.Add(info.DeviceId);
						}
						else if (flag2)
						{
							list4.Add(info.DeviceId);
						}
					}
				}
				if (list3.Count > 0 || list4.Count > 0)
				{
					FirebaseCloudMessaging firebaseCloudMessaging = new FirebaseCloudMessaging();
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					if (!string.IsNullOrEmpty(item.upExtraData))
					{
						dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.upExtraData);
					}
					string text = "";
					int.TryParse(dictionary["msgdFromUserId"], out var result2);
					if (result2 > 0)
					{
						string userName = CRMIdealApi.Classes.Helper.User.GetUserName(result2, currLangId, result);
						text = string.Format(RS.Get("MsgNewInternalMsgFrom", rsCollation, RS.TypeMsg), userName);
					}
					else
					{
						text = RS.Get("lblNewIntMsg", rsCollation, RS.TypeMsg);
					}
					int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispIntMsgGetUnReadMessgeCnt(item.upUserId)).GetValueOrDefault();
					dictionary.Add("MessageType", "NewIntMsgNotif");
					dictionary.Add("UnReadCnt", valueOrDefault.ToString());
					dictionary.Add("Title", text);
					dictionary.Add("Message", item.upTitle ?? "");
					Exception ex = null;
					if (list3.Count > 0)
					{
						firebaseCloudMessaging.SendTokenMessage(list3, dictionary, ref ex);
					}
					if (list4.Count > 0)
					{
						firebaseCloudMessaging.SendNewIntMsgNotificationMessage(list4, dictionary, ref ex);
					}
					if (ex != null)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
				}
			}
			cRMEntities.ApispDeleteUserPushNotifTankByTypeId(1);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
	}

	public bool ReferDocToOrdReferUser(string docIds, int? currUserId = 0, int langId = 1065, int userId = 0)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return false;
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var defLangId);
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			int currLangId = langId;
			if (currLangId <= 0)
			{
				currLangId = defLangId;
			}
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrWhiteSpace(docIds))
			{
				if (currUserId.GetValueOrDefault() == 0)
				{
					userId = userId;
				}
				List<InternalMessage_LangViewModel> list2 = new List<InternalMessage_LangViewModel>();
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				foreach (ApispSelectLanguages_Result item in list)
				{
					InternalMessage_LangViewModel internalMessage_LangViewModel = new InternalMessage_LangViewModel();
					internalMessage_LangViewModel.LanguageID = item.LanguageID;
					internalMessage_LangViewModel.msgSubject = RS.Get("docVerifiedRequestSubject", rsCollation, RS.TypeLbl);
					internalMessage_LangViewModel.msgBody = internalMessage_LangViewModel.msgBody + string.Format(RS.Get("docVerifiedRequest", item.LanguageCollation, RS.TypeLbl), "[#OprType#]") + "\n";
					internalMessage_LangViewModel.msgBody = internalMessage_LangViewModel.msgBody + RS.Get("docVerifiedRequestDocOpr", item.LanguageCollation, RS.TypeLbl) + ": [#Opr#]\n";
					internalMessage_LangViewModel.msgBody = internalMessage_LangViewModel.msgBody + RS.Get("docVerifiedRequestDocNumber", item.LanguageCollation, RS.TypeLbl) + ": [#DocNumber#]\n";
					internalMessage_LangViewModel.msgBody = internalMessage_LangViewModel.msgBody + RS.Get("docVerifiedRequestDocDate", item.LanguageCollation, RS.TypeLbl) + ": [#DocDate#]\n";
					internalMessage_LangViewModel.msgBody = internalMessage_LangViewModel.msgBody + RS.Get("docVerifiedRequestCompanayName", item.LanguageCollation, RS.TypeLbl) + ": [#CmpName#]\n";
					internalMessage_LangViewModel.msgBody = internalMessage_LangViewModel.msgBody + RS.Get("docVerifiedRequestFirstRegister", item.LanguageCollation, RS.TypeLbl) + ": [#FirstRegisterUser#]\n";
					internalMessage_LangViewModel.msgBody = internalMessage_LangViewModel.msgBody + RS.Get("docVerifiedRequestVerifier", item.LanguageCollation, RS.TypeLbl) + ": [#Verifier#]\n";
					internalMessage_LangViewModel.msgBody = internalMessage_LangViewModel.msgBody + RS.Get("docVerifiedRequestDbClickOnOtherInfo", item.LanguageCollation, RS.TypeLbl) + "\n";
					list2.Add(internalMessage_LangViewModel);
					CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel.Value = RS.Get("lblDoc", item.LanguageCollation, RS.TypeLbl);
					list3.Add(commonMultiLanguageViewModel);
					CommonMultiLanguageViewModel commonMultiLanguageViewModel2 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel2.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel2.Value = RS.Get("lblDraft", item.LanguageCollation, RS.TypeLbl);
					list4.Add(commonMultiLanguageViewModel2);
					CommonMultiLanguageViewModel commonMultiLanguageViewModel3 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel3.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel3.Value = RS.Get("lblMoveMent", item.LanguageCollation, RS.TypeLbl);
					list5.Add(commonMultiLanguageViewModel3);
				}
				string intMsgBody = "";
				string intMsgSubject = "";
				string intMsgLang = "";
				string docTxt = "";
				string docTxtLang = "";
				string draftTxt = "";
				string draftTxtLang = "";
				string movementTxt = "";
				string movementTxtLang = "";
				if (list2 != null && Enumerable.Any<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2))
				{
					intMsgSubject = (Enumerable.Any<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2, (Func<InternalMessage_LangViewModel, bool>)((InternalMessage_LangViewModel c) => c.LanguageID == defLangId)) ? Enumerable.FirstOrDefault<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2, (Func<InternalMessage_LangViewModel, bool>)((InternalMessage_LangViewModel c) => c.LanguageID == defLangId)).msgSubject : "");
					intMsgBody = (Enumerable.Any<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2, (Func<InternalMessage_LangViewModel, bool>)((InternalMessage_LangViewModel c) => c.LanguageID == defLangId)) ? Enumerable.FirstOrDefault<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2, (Func<InternalMessage_LangViewModel, bool>)((InternalMessage_LangViewModel c) => c.LanguageID == defLangId)).msgBody : "");
					intMsgLang = JsonConvert.SerializeObject(Enumerable.ToList<InternalMessage_LangViewModel>(Enumerable.Where<InternalMessage_LangViewModel>((IEnumerable<InternalMessage_LangViewModel>)list2, (Func<InternalMessage_LangViewModel, bool>)((InternalMessage_LangViewModel c) => c.LanguageID != defLangId))));
				}
				if (list3 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
				{
					docTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : "");
					docTxtLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangId))));
				}
				if (list4 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
				{
					draftTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : "");
					draftTxtLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangId))));
				}
				if (list5 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5))
				{
					movementTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : "");
					movementTxtLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangId))));
				}
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispReferDocToOrdReferUser(docIds, intMsgBody, intMsgSubject, intMsgLang, userId, month1, registerDate, registerDatePersian, appType, defLangId, docTxt, docTxtLang, draftTxt, draftTxtLang, movementTxt, movementTxtLang, null, null));
				int result2 = 0;
				if (mct_Result != null)
				{
					int.TryParse(mct_Result.Result.ToString(), out result2);
				}
				result = result2 == 1;
				NewIntMsgNotify();
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public void AddProjectProductHistoryFromOrder(int orderId, bool addPrdValidity, string addPrdValidityPrjTitle, int currLangId, int defLangId, int userId, ref string msg)
	{
		try
		{
			CRMEntities cRMEntities = new CRMEntities();
			ResourceManager resourceManager = new ResourceManager();
			if (orderId != 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispAddProjectProductHistoryFromOrder(orderId, addPrdValidity, addPrdValidityPrjTitle, userId, month1, registerDate, registerDatePersian, appType, currLangId, defLangId));
				int result = 0;
				if (mct_Result != null)
				{
					int.TryParse(mct_Result.Result.ToString(), out result);
				}
				switch (result)
				{
				case -100:
				case 0:
					msg = resourceManager.Get("ErrorRunFunction", resourceManager.Def_Collation, resourceManager.TypeMsg);
					break;
				case -1:
					msg = resourceManager.Get("msgErrorNoSavePrjPrdHisByOrdNotVerified", resourceManager.Def_Collation, resourceManager.TypeMsg);
					break;
				case -2:
					msg = resourceManager.Get("msgErrorNoSavePrjPrdHisNoSelectedPrj", resourceManager.Def_Collation, resourceManager.TypeMsg);
					break;
				case -3:
					msg = resourceManager.Get("msgErrorNoSavePrjPrdHisNoDefaultPrjTitles", resourceManager.Def_Collation, resourceManager.TypeMsg);
					break;
				case -4:
					msg = resourceManager.Get("msgErrorNoSavePrjPrdHisNoPrj", resourceManager.Def_Collation, resourceManager.TypeMsg);
					break;
				case 1:
					msg = "";
					break;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
	}
}
