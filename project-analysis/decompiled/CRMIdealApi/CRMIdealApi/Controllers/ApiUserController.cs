using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CRM.General.Security;
using CRM.General.Utilities;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Common;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;

namespace CRMIdealApi.Controllers;

public class ApiUserController : ApiController
{
	[HttpPost]
	public ServiceResult<InsertUserResultViewModel> InsertUserWithLinked(InsertUserViewModel model)
	{
		CRMEntities cRMEntities = null;
		InsertUserResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<InsertUserResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			if (model.ApiPositionId == 0)
			{
				model.ApiPositionId = null;
			}
			if (model.ApiSignatureId == 0)
			{
				model.ApiSignatureId = null;
			}
			if (model.ApiDepartmentId == 0)
			{
				model.ApiDepartmentId = null;
			}
			if (model.ApiResponsibleUserId == 0)
			{
				model.ApiResponsibleUserId = null;
			}
			if (model.ApiUserGroupId == 0)
			{
				model.ApiUserGroupId = null;
			}
			if (model.ApiRollId == 0)
			{
				model.ApiRollId = null;
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<InsertUserResultViewModel>
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
				ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string coordinateLastDatePersian = null;
			string startDatePersian = null;
			string expireDatePersian = null;
			try
			{
				if (model.ApiCoordinateLastDate.HasValue)
				{
					coordinateLastDatePersian = (model.ApiCoordinateLastDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserCoordinateLastDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiStartDate.HasValue)
				{
					startDatePersian = (model.ApiStartDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserStartDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiExpireDate.HasValue)
				{
					expireDatePersian = (model.ApiExpireDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserExpireDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrEmpty(model.ApiUserName))
			{
				ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ApiUserName", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			bool result3 = false;
			bool.TryParse(model.ApiIsActive.ToString(), out result3);
			bool result4 = false;
			bool.TryParse(model.ApiUserIsActiveInWinApp.ToString(), out result4);
			bool result5 = false;
			bool.TryParse(model.ApiUserIsActiveInWebApp.ToString(), out result5);
			bool result6 = false;
			bool.TryParse(model.ApiUserIsActiveInMobApp.ToString(), out result6);
			bool result7 = false;
			bool.TryParse(model.ApiUserIsActiveInHRM.ToString(), out result7);
			if (!result3)
			{
				model.ApiUserIsActiveInWinApp = false;
				model.ApiUserIsActiveInWebApp = false;
				model.ApiUserIsActiveInMobApp = false;
				model.ApiUserIsActiveInHRM = false;
			}
			if (result4 || result5 || result6 || result7)
			{
				model.ApiIsActive = true;
			}
			try
			{
				int num2 = 0;
				int num3 = 0;
				num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispReturnActiveUsersCount()).GetValueOrDefault();
				num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispReturnActiveUsersInWebAppCount()).GetValueOrDefault();
				int num4 = 50;
				int num5 = CRMIdealApi.Classes.Common.Configuration.MaxCountOfOnlineUser + CRMIdealApi.Classes.Common.Configuration.MaxCountOfOnlineUserDeActive;
				if (VersionBuyer.Enterprise)
				{
					num4 = CRMIdealApi.Classes.Common.Configuration.MaxCountOfOnlineUser;
				}
				bool result8 = false;
				bool.TryParse(model.ApiIsActive.ToString(), out result8);
				bool result9 = false;
				bool.TryParse(model.ApiUserIsActiveInWebApp.ToString(), out result9);
				int maxCountOfOnlineUser = CRMIdealApi.Classes.Common.Configuration.MaxCountOfOnlineUser;
				if (result8)
				{
					if (num5 <= num2)
					{
						ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
						serviceResult.Message = MyResource.GetResourceString("msgErrorFinishingUserDefinitionCapacity", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = null;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
					if (result9 && maxCountOfOnlineUser <= num3)
					{
						ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
						serviceResult.Message = MyResource.GetResourceString("msgErrorFinishingUserDefinitionCapacity", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = null;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
					if (num4 <= num3)
					{
						ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
						serviceResult.Message = MyResource.GetResourceString("msgErrorFinishingUserDefinitionCapacity", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = null;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("InsertedUserId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			string userPassword = "";
			if (string.IsNullOrWhiteSpace(model.ApiPassword))
			{
				model.ApiPassword = model.ApiUserName;
			}
			if (!string.IsNullOrWhiteSpace(model.ApiPassword))
			{
				CommonClass commonClass2 = new CommonClass();
				userPassword = commonClass2.ConvertMd5(model.ApiPassword).ToLower();
			}
			int? num6 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertUserWithLinked(model.ApiFName, model.ApiLName, model.ApiPersCode, model.ApiUserName, model.ApiPassword, userPassword, model.ApiIsActive, model.ApiDescription, model.ApiIPAddress, model.ApiTel, model.ApiTelDesc, model.ApiPositionId, model.ApiSignatureId, model.ApiDepartmentId, model.ApiResponsibleUserId, model.ApiComputerName, model.ApiCallreIdDeActive, model.ApiCallreIdDeActiveLines, model.ApiDisableInternalMessageAllarmVoice, model.ApiDisableReceiveCNVSInfoAllarm, model.ApiEmailAttachFileLocation, model.ApiUserCIPatternFormulaPopUp, model.ApiUseClientNameForNetworking, model.ApiAllowCopyOtherLanguage, model.ApiUserIsActiveInWinApp, model.ApiUserIsActiveInWebApp, model.ApiUserIsActiveInMobApp, model.ApiCoordinateLatitude, model.ApiCoordinateLongitude, model.ApiCoordinateLastDate, coordinateLastDatePersian, model.ApiUserIsActiveInFOSetting, model.ApiUserAccessDailyChrtAllUsers, model.ApiUserAccessSaleChrtAllUsers, model.ApiMaxNumberCmpDraft, model.ApiMobile, model.ApiMobileII, model.ApiAddress, model.ApiFatherName, model.ApiNationalCode, model.ApiIdentityNumber, model.ApiInsuranceCode, model.ApiStartDate, startDatePersian, model.ApiExpireDate, expireDatePersian, model.ApiUserGroupId, model.ApiUserExtensions, model.ApiMobDeActiveAccessToLocation, model.ApiNickname, model.ApiDeActiveSmartTimeAttendance, model.ApiMobImeiCode, model.ApiUserIsActiveInHRM, model.ApiMobHRMImeiCode, model.ApiAccessAllLanguage, model.ApiAccessOtherUsersCmpInfo, model.ApiAccessOtherUsersPrsInfo, model.ApiAccessOtherUsersPrjInfo, model.ApiAccessOtherUsersCnvsInfo, model.ApiRollName, model.ApiRollId, userId, value2, value, registerDatePersian, appType, result, objectParameter, objectParameter2, null));
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result10 = 0;
			int.TryParse(num6.ToString(), out result10);
			if (result10 <= 0)
			{
				return new ServiceResult<InsertUserResultViewModel>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
			{
				string text3 = "";
				string text4 = objectParameter2.Value.ToString();
				if (text4.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No PositionId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserPosition", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No DepartmentId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserDepartment", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No ResponsibleUserId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ResponsibleUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No UserGroupId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserGroup", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No RollId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserRoll", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No UserName|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ApiUserName", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No DupUserName|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemDuplicate", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ApiUserName", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text3 += resourceString3;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text4));
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				InsertUserResultViewModel insertUserResultViewModel = new InsertUserResultViewModel();
				insertUserResultViewModel.UserId = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				insertUserResultViewModel.UserName = model.ApiUserName;
				data = insertUserResultViewModel;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text5 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text5 = text5 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text5)) ? (" (" + text5 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<InsertUserResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> Update(UpdateUserViewModel model)
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
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string coordinateLastDatePersian = null;
			string startDatePersian = null;
			string expireDatePersian = null;
			try
			{
				if (model.ApiCoordinateLastDate.HasValue)
				{
					coordinateLastDatePersian = (model.ApiCoordinateLastDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserCoordinateLastDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiStartDate.HasValue)
				{
					startDatePersian = (model.ApiStartDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserStartDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiExpireDate.HasValue)
				{
					expireDatePersian = (model.ApiExpireDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserExpireDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiUserId == 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			bool result3 = false;
			bool.TryParse(model.UsedInKaraAfzar.ToString(), out result3);
			if (!result3)
			{
				bool result4 = false;
				bool.TryParse(model.ApiIsActive.ToString(), out result4);
				bool result5 = false;
				bool.TryParse(model.ApiUserIsActiveInWinApp.ToString(), out result5);
				bool result6 = false;
				bool.TryParse(model.ApiUserIsActiveInWebApp.ToString(), out result6);
				bool result7 = false;
				bool.TryParse(model.ApiUserIsActiveInMobApp.ToString(), out result7);
				bool result8 = false;
				bool.TryParse(model.ApiUserIsActiveInHRM.ToString(), out result8);
				if (!result4)
				{
					model.ApiUserIsActiveInWinApp = false;
					model.ApiUserIsActiveInWebApp = false;
					model.ApiUserIsActiveInMobApp = false;
					model.ApiUserIsActiveInHRM = false;
				}
				if (result5 || result6 || result7 || result8)
				{
					model.ApiIsActive = true;
				}
				bool result9 = false;
				bool.TryParse(model.ApiIsActive.ToString(), out result9);
				bool result10 = false;
				bool result11 = false;
				ApispSelectUsersById_Result apispSelectUsersById_Result = Enumerable.FirstOrDefault<ApispSelectUsersById_Result>((IEnumerable<ApispSelectUsersById_Result>)cRMEntities.ApispSelectUsersById(model.ApiUserId, currLangId, result));
				if (apispSelectUsersById_Result != null)
				{
					bool.TryParse(apispSelectUsersById_Result.IsActive.ToString(), out result10);
					bool.TryParse(apispSelectUsersById_Result.UserIsActiveInWebApp.ToString(), out result11);
				}
				bool result12 = false;
				bool.TryParse(model.ApiUserIsActiveInWebApp.ToString(), out result12);
				int maxCountOfOnlineUser = CRMIdealApi.Classes.Common.Configuration.MaxCountOfOnlineUser;
				if (result9 && !result10)
				{
					try
					{
						int num2 = 0;
						int num3 = 0;
						num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispReturnActiveUsersCount()).GetValueOrDefault();
						num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispReturnActiveUsersInWebAppCount()).GetValueOrDefault();
						int num4 = 50;
						int num5 = CRMIdealApi.Classes.Common.Configuration.MaxCountOfOnlineUser + CRMIdealApi.Classes.Common.Configuration.MaxCountOfOnlineUserDeActive;
						if (VersionBuyer.Enterprise)
						{
							num4 = CRMIdealApi.Classes.Common.Configuration.MaxCountOfOnlineUser;
						}
						if (result9)
						{
							if (num5 <= num2)
							{
								ServiceResult<int> serviceResult = new ServiceResult<int>();
								serviceResult.Message = MyResource.GetResourceString("msgErrorFinishingUserDefinitionCapacity", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								serviceResult.Data = 0;
								serviceResult.Status = ServiceResultStatus.Error;
								return serviceResult;
							}
							if (result12 && !result11 && maxCountOfOnlineUser <= num3)
							{
								ServiceResult<int> serviceResult = new ServiceResult<int>();
								serviceResult.Message = MyResource.GetResourceString("msgErrorFinishingUserDefinitionCapacity", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								serviceResult.Data = 0;
								serviceResult.Status = ServiceResultStatus.Error;
								return serviceResult;
							}
							if (num4 <= num3)
							{
								ServiceResult<int> serviceResult = new ServiceResult<int>();
								serviceResult.Message = MyResource.GetResourceString("msgErrorFinishingUserDefinitionCapacity", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								serviceResult.Data = 0;
								serviceResult.Status = ServiceResultStatus.Error;
								return serviceResult;
							}
						}
					}
					catch (Exception e4)
					{
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
				}
				if (result12 && !result11)
				{
					int num6 = 0;
					num6 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispReturnActiveUsersInWebAppCount()).GetValueOrDefault();
					if (maxCountOfOnlineUser <= num6)
					{
						ServiceResult<int> serviceResult = new ServiceResult<int>();
						serviceResult.Message = MyResource.GetResourceString("msgErrorFinishingUserDefinitionCapacity", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = 0;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
				}
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			string userPassword = "";
			if (!string.IsNullOrWhiteSpace(model.ApiPassword))
			{
				CommonClass commonClass2 = new CommonClass();
				userPassword = commonClass2.ConvertMd5(model.ApiPassword).ToLower();
			}
			int num7 = cRMEntities.ApispUpdateUser(model.ApiUserId, model.ApiFName, model.ApiLName, model.ApiPersCode, model.ApiUserName, model.ApiPassword, userPassword, model.ApiIsActive, model.ApiDescription, model.ApiIPAddress, model.ApiTel, model.ApiTelDesc, model.ApiPositionId, model.ApiSignatureId, model.ApiDepartmentId, model.ApiResponsibleUserId, model.ApiComputerName, model.ApiCallreIdDeActive, model.ApiCallreIdDeActiveLines, model.ApiDisableInternalMessageAllarmVoice, model.ApiDisableReceiveCNVSInfoAllarm, model.ApiEmailAttachFileLocation, model.ApiUserCIPatternFormulaPopUp, model.ApiUseClientNameForNetworking, model.ApiAllowCopyOtherLanguage, model.ApiUserIsActiveInWinApp, model.ApiUserIsActiveInWebApp, model.ApiUserIsActiveInMobApp, model.ApiCoordinateLatitude, model.ApiCoordinateLongitude, model.ApiCoordinateLastDate, coordinateLastDatePersian, model.ApiUserIsActiveInFOSetting, model.ApiUserAccessDailyChrtAllUsers, model.ApiUserAccessSaleChrtAllUsers, model.ApiMaxNumberCmpDraft, model.ApiMobile, model.ApiMobileII, model.ApiAddress, model.ApiFatherName, model.ApiNationalCode, model.ApiIdentityNumber, model.ApiInsuranceCode, model.ApiStartDate, startDatePersian, model.ApiExpireDate, expireDatePersian, model.ApiUserGroupId, model.ApiUserExtensions, model.ApiMobDeActiveAccessToLocation, model.ApiNickname, model.ApiDeActiveSmartTimeAttendance, model.ApiMobImeiCode, model.ApiUserIsActiveInHRM, model.ApiMobHRMImeiCode, userId, value2, value, registerDatePersian, appType, currLangId, result, objectParameter, null);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result13 = 0;
			int.TryParse(num7.ToString(), out result13);
			if (result13 < 0 && objectParameter.Value == null)
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
				string text3 = "";
				string text4 = objectParameter.Value.ToString();
				if (text4.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No PositionId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserPosition", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No DepartmentId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserDepartment", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No ResponsibleUserId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ResponsibleUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No UserGroupId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserGroup", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No RollId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserRoll", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No UserName|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ApiUserName", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No DupUserName|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemDuplicate", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ApiUserName", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text3 += resourceString2;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text4));
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text5 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text5 = text5 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text5)) ? (" (" + text5 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
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
	public ServiceResult<List<ApispSelectUsersWithIdOrUserName_Result>> Select(SelectUserViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectUsersWithIdOrUserName_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectUsersWithIdOrUserName_Result>>
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
				return new ServiceResult<List<ApispSelectUsersWithIdOrUserName_Result>>
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
				ServiceResult<List<ApispSelectUsersWithIdOrUserName_Result>> serviceResult = new ServiceResult<List<ApispSelectUsersWithIdOrUserName_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectUsersWithIdOrUserName_Result> list2 = Enumerable.ToList<ApispSelectUsersWithIdOrUserName_Result>((IEnumerable<ApispSelectUsersWithIdOrUserName_Result>)cRMEntities.ApispSelectUsersWithIdOrUserName(model.ApiUserId, model.ApiUserName, currLangId, result));
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
		return new ServiceResult<List<ApispSelectUsersWithIdOrUserName_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<InsertUserResultViewModel> ActiveDemoUser(InsertUserViewModel model)
	{
		CRMEntities cRMEntities = null;
		InsertUserResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<InsertUserResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			if (model.ApiPositionId == 0)
			{
				model.ApiPositionId = null;
			}
			if (model.ApiSignatureId == 0)
			{
				model.ApiSignatureId = null;
			}
			if (model.ApiDepartmentId == 0)
			{
				model.ApiDepartmentId = null;
			}
			if (model.ApiResponsibleUserId == 0)
			{
				model.ApiResponsibleUserId = null;
			}
			if (model.ApiUserGroupId == 0)
			{
				model.ApiUserGroupId = null;
			}
			if (model.ApiRollId == 0)
			{
				model.ApiRollId = null;
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<InsertUserResultViewModel>
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
				ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string coordinateLastDatePersian = null;
			string startDatePersian = null;
			string expireDatePersian = null;
			try
			{
				if (model.ApiCoordinateLastDate.HasValue)
				{
					coordinateLastDatePersian = (model.ApiCoordinateLastDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserCoordinateLastDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiStartDate.HasValue)
				{
					startDatePersian = (model.ApiStartDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserStartDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiExpireDate.HasValue)
				{
					expireDatePersian = (model.ApiExpireDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserExpireDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrEmpty(model.ApiUserName))
			{
				ServiceResult<InsertUserResultViewModel> serviceResult = new ServiceResult<InsertUserResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ApiUserName", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string text = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("InsertedUserId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			string userPassword = "";
			if (string.IsNullOrWhiteSpace(model.ApiPassword))
			{
				model.ApiPassword = model.ApiUserName;
			}
			if (!string.IsNullOrWhiteSpace(model.ApiPassword))
			{
				CommonClass commonClass2 = new CommonClass();
				userPassword = commonClass2.ConvertMd5(model.ApiPassword).ToLower();
			}
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispActiveDemoUser(model.ApiFName, model.ApiLName, model.ApiPersCode, model.ApiUserName, model.ApiPassword, userPassword, model.ApiIsActive, model.ApiDescription, model.ApiIPAddress, model.ApiTel, model.ApiTelDesc, model.ApiPositionId, model.ApiSignatureId, model.ApiDepartmentId, model.ApiResponsibleUserId, model.ApiComputerName, model.ApiCallreIdDeActive, model.ApiCallreIdDeActiveLines, model.ApiDisableInternalMessageAllarmVoice, model.ApiDisableReceiveCNVSInfoAllarm, model.ApiEmailAttachFileLocation, model.ApiUserCIPatternFormulaPopUp, model.ApiUseClientNameForNetworking, model.ApiAllowCopyOtherLanguage, model.ApiUserIsActiveInWinApp, model.ApiUserIsActiveInWebApp, model.ApiUserIsActiveInMobApp, model.ApiCoordinateLatitude, model.ApiCoordinateLongitude, model.ApiCoordinateLastDate, coordinateLastDatePersian, model.ApiUserIsActiveInFOSetting, model.ApiUserAccessDailyChrtAllUsers, model.ApiUserAccessSaleChrtAllUsers, model.ApiMaxNumberCmpDraft, model.ApiMobile, model.ApiMobileII, model.ApiAddress, model.ApiFatherName, model.ApiNationalCode, model.ApiIdentityNumber, model.ApiInsuranceCode, model.ApiStartDate, startDatePersian, model.ApiExpireDate, expireDatePersian, model.ApiUserGroupId, model.ApiUserExtensions, model.ApiMobDeActiveAccessToLocation, model.ApiNickname, model.ApiDeActiveSmartTimeAttendance, model.ApiMobImeiCode, model.ApiUserIsActiveInHRM, model.ApiMobHRMImeiCode, model.ApiAccessAllLanguage, model.ApiAccessOtherUsersCmpInfo, model.ApiAccessOtherUsersPrsInfo, model.ApiAccessOtherUsersPrjInfo, model.ApiAccessOtherUsersCnvsInfo, model.ApiRollName, model.ApiRollId, userId, value2, value, registerDatePersian, appType, result, objectParameter, objectParameter2, null));
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<InsertUserResultViewModel>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
			{
				string text3 = "";
				string text4 = objectParameter2.Value.ToString();
				if (text4.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No PositionId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserPosition", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No DepartmentId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserDepartment", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No ResponsibleUserId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ResponsibleUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No UserGroupId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserGroup", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No RollId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("UserRoll", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No UserName|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ApiUserName", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No DupUserName|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemDuplicate", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ApiUserName", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text3 += resourceString3;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text4));
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					return new ServiceResult<InsertUserResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				InsertUserResultViewModel insertUserResultViewModel = new InsertUserResultViewModel();
				insertUserResultViewModel.UserId = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				insertUserResultViewModel.UserName = model.ApiUserName;
				data = insertUserResultViewModel;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text5 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text5 = text5 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text5)) ? (" (" + text5 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<InsertUserResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<ApispSelectUsersById_Result> SelectUserWithId(SelectUsersByIdViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispSelectUsersById_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<ApispSelectUsersById_Result>
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
				return new ServiceResult<ApispSelectUsersById_Result>
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
				ServiceResult<ApispSelectUsersById_Result> serviceResult = new ServiceResult<ApispSelectUsersById_Result>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ApispSelectUsersById_Result apispSelectUsersById_Result = Enumerable.FirstOrDefault<ApispSelectUsersById_Result>((IEnumerable<ApispSelectUsersById_Result>)cRMEntities.ApispSelectUsersById(model.UserId, currLangId, result));
			if (apispSelectUsersById_Result != null)
			{
				data = apispSelectUsersById_Result;
				message = "";
				status = ServiceResultStatus.Success;
			}
			else
			{
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
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<ApispSelectUsersById_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
