using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Company.Controllers;

public class ActiveDemoUserController : Controller
{
	public class ActiveDemoUserApiResultViewModel<T>
	{
		public T Data { get; set; }

		public string Message { get; set; }

		public string Status { get; set; }
	}

	public class ActiveDemoUserApiSelectViewModel
	{
		public string UserName { get; set; }

		public string Password { get; set; }

		public string ApiUserName { get; set; }
	}

	public class ActiveDemoUserApiSelectResultViewModel
	{
		public int ApiUserId { get; set; }

		public int? ApiRow { get; set; }

		public string ApiFName { get; set; }

		public string ApiLName { get; set; }

		public string ApiFullName { get; set; }

		public string ApiPersCode { get; set; }

		public string ApiUserName { get; set; }

		public bool? ApiIsActive { get; set; }

		public string ApiDescription { get; set; }

		public int? ApiUserId1 { get; set; }

		public string ApiEditUser { get; set; }

		public DateTime? ApiRegisterDate { get; set; }

		public string ApiRegisterDatePersian { get; set; }

		public string ApiIPAddress { get; set; }

		public string ApiTel { get; set; }

		public string ApiTelDesc { get; set; }

		public int? ApiPositionId { get; set; }

		public string ApiPositionName { get; set; }

		public int? ApiSignatureId { get; set; }

		public int? ApiDepartmentId { get; set; }

		public string ApiDepartment { get; set; }

		public int? ApiResponsibleUserId { get; set; }

		public string ApiResponsibleUser { get; set; }

		public string ApiComputerName { get; set; }

		public bool? ApiCallreIdDeActive { get; set; }

		public string ApiCallreIdDeActiveLines { get; set; }

		public bool? ApiDisableInternalMessageAllarmVoice { get; set; }

		public bool? ApiDisableReceiveCNVSInfoAllarm { get; set; }

		public string ApiEmailAttachFileLocation { get; set; }

		public string ApiUserCIPatternFormulaPopUp { get; set; }

		public bool? ApiUseClientNameForNetworking { get; set; }

		public bool? ApiUserIsActiveInWinApp { get; set; }

		public bool? ApiUserIsActiveInWebApp { get; set; }

		public bool? ApiUserIsActiveInMobApp { get; set; }

		public bool? ApiAllowCopyOtherLanguage { get; set; }

		public int? ApiFirstRegisterUserId { get; set; }

		public string ApiFirstRegisterDatePersian { get; set; }

		public DateTime? ApiFirstRegisterDate { get; set; }

		public string ApiFirstRegisterUser { get; set; }

		public string ApiCoordinateLatitude { get; set; }

		public string ApiCoordinateLongitude { get; set; }

		public DateTime? ApiCoordinateLastDate { get; set; }

		public string ApiCoordinateLastDatePersian { get; set; }

		public bool? ApiUserIsActiveInFOSetting { get; set; }

		public int? ApiMaxNumberCmpDraft { get; set; }

		public string ApiMobile { get; set; }

		public string ApiMobileII { get; set; }

		public string ApiAddress { get; set; }

		public string ApiFatherName { get; set; }

		public string ApiNationalCode { get; set; }

		public string ApiIdentityNumber { get; set; }

		public string ApiInsuranceCode { get; set; }

		public DateTime? ApiStartDate { get; set; }

		public string ApiStartDatePersian { get; set; }

		public DateTime? ApiExpireDate { get; set; }

		public string ApiExpireDatePersian { get; set; }

		public int? ApiUserGroupId { get; set; }

		public string ApiUserGroup { get; set; }

		public string ApiUserExtensions { get; set; }

		public bool? ApiMobDeActiveAccessToLocation { get; set; }

		public string ApiLinkAccUserCode { get; set; }

		public string ApiLinkAccUserIdStr { get; set; }

		public string ApiNickname { get; set; }

		public bool? ApiDeActiveSmartTimeAttendance { get; set; }

		public string ApiMobImeiCode { get; set; }

		public bool? ApiUserIsActiveInHRM { get; set; }

		public string ApiMobHRMImeiCode { get; set; }

		public int? ApiUserRollId { get; set; }

		public string ApiUserRollName { get; set; }
	}

	public class ActiveDemoUserApiInsertUserViewModel
	{
		public string UserName { get; set; }

		public string Password { get; set; }

		public int UserId { get; set; }

		public string ApiFName { get; set; }

		public string ApiLName { get; set; }

		public string ApiUserName { get; set; }

		public string ApiPassword { get; set; }

		public bool? ApiIsActive { get; set; }

		public bool? ApiUserIsActiveInWebApp { get; set; }

		public bool? ApiUserIsActiveInMobApp { get; set; }

		public bool? ApiAllowCopyOtherLanguage { get; set; }

		public DateTime? ApiExpireDate { get; set; }

		public bool? ApiAccessAllLanguage { get; set; }

		public string ApiRollName { get; set; }
	}

	public class ActiveDemoUserApiInsertUserResultViewModel
	{
		public int UserId { get; set; }

		public string UserName { get; set; }
	}

	public class ActiveDemoUserApiUpdateUserViewModel
	{
		public string UserName { get; set; }

		public string Password { get; set; }

		public int UserId { get; set; }

		public int ApiUserId { get; set; }

		public bool? ApiIsActive { get; set; }

		public bool? ApiUserIsActiveInWebApp { get; set; }

		public bool? ApiUserIsActiveInMobApp { get; set; }

		public DateTime? ApiExpireDate { get; set; }

		public bool? UsedInKaraAfzar { get; set; }
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actActiveDemoUser")]
	public ActionResult Index(int cmpId, int cmpNumber, string demoUrl, string uName, string upass)
	{
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.DemoUrl = demoUrl;
		base.ViewBag.UName = uName;
		if (!string.IsNullOrWhiteSpace(upass))
		{
			upass = upass.Replace(" ", "+");
		}
		base.ViewBag.UPass = upass;
		GetCmpPersons(cmpId);
		int result = 0;
		string text = "";
		bool flag = false;
		if (!string.IsNullOrWhiteSpace(demoUrl ?? "") && !string.IsNullOrWhiteSpace(uName) && !string.IsNullOrWhiteSpace(upass))
		{
			if (!demoUrl.EndsWith("/"))
			{
				demoUrl += "/";
			}
			HttpClient obj = new HttpClient
			{
				BaseAddress = new Uri(demoUrl),
				DefaultRequestHeaders = 
				{
					Accept = 
					{
						new MediaTypeWithQualityHeaderValue("application/json")
					}
				}
			};
			string text2 = "ApiUser/Select";
			HttpResponseMessage result2 = obj.PostAsync(content: new StringContent(JsonConvert.SerializeObject(new ActiveDemoUserApiSelectViewModel
			{
				UserName = uName,
				Password = upass,
				ApiUserName = cmpNumber.ToString()
			}), Encoding.UTF8, "application/json"), requestUri: "api/" + text2).Result;
			if (result2.IsSuccessStatusCode)
			{
				ActiveDemoUserApiResultViewModel<List<ActiveDemoUserApiSelectResultViewModel>> activeDemoUserApiResultViewModel = JsonConvert.DeserializeObject<ActiveDemoUserApiResultViewModel<List<ActiveDemoUserApiSelectResultViewModel>>>(result2.Content.ReadAsStringAsync().Result);
				if (activeDemoUserApiResultViewModel.Status == "Success" && activeDemoUserApiResultViewModel.Data != null)
				{
					ActiveDemoUserApiSelectResultViewModel activeDemoUserApiSelectResultViewModel = new ActiveDemoUserApiSelectResultViewModel();
					if (Enumerable.Any<ActiveDemoUserApiSelectResultViewModel>((IEnumerable<ActiveDemoUserApiSelectResultViewModel>)activeDemoUserApiResultViewModel.Data))
					{
						activeDemoUserApiSelectResultViewModel = Enumerable.FirstOrDefault<ActiveDemoUserApiSelectResultViewModel>((IEnumerable<ActiveDemoUserApiSelectResultViewModel>)activeDemoUserApiResultViewModel.Data);
					}
					if (activeDemoUserApiSelectResultViewModel != null)
					{
						int.TryParse(activeDemoUserApiSelectResultViewModel.ApiUserId.ToString(), out result);
						text = (activeDemoUserApiSelectResultViewModel.ApiExpireDate.HasValue ? activeDemoUserApiSelectResultViewModel.ApiExpireDate.Value.ToString("yyyy/MM/dd") : "");
						if (activeDemoUserApiSelectResultViewModel.ApiExpireDate.HasValue)
						{
							DateTime dateTime = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd 23:59:59"));
							bool result3 = false;
							bool.TryParse(activeDemoUserApiSelectResultViewModel.ApiIsActive.ToString(), out result3);
							DateTime value = dateTime;
							DateTime? apiExpireDate = activeDemoUserApiSelectResultViewModel.ApiExpireDate;
							if (value > apiExpireDate)
							{
								flag = true;
							}
							else if (!result3)
							{
								flag = true;
							}
						}
					}
				}
			}
		}
		base.ViewBag.ApiUserId = result;
		base.ViewBag.ApiExpireDate = text;
		base.ViewBag.IsExpire = flag;
		return View();
	}

	[AjaxOnly]
	public string SendSMSVerificationCode(int cmpId, int prsId, string prsMobile, string webServiceUserName, string webServicePassword, string webServiceNumber)
	{
		string errorMessage = "";
		_ = UserLogin.CurrentUser.UserId;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			_ = Configuration.AppType;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actActiveDemoUser", UserLogin.CurrentUser))
			{
				errorMessage = Messages.ErrorNotAccess;
			}
			else
			{
				if (cmpId == 0)
				{
					return Messages.msgErrorNotSelectCompany;
				}
				if (prsId == 0)
				{
					return string.Format(Messages.msgErrorIsNotEntered, Labels.ActiveDemoUserMobile);
				}
				if (string.IsNullOrWhiteSpace(prsMobile))
				{
					return string.Format(Messages.msgErrorIsNotEntered, Labels.ActiveDemoUserMobile);
				}
				string text = "";
				text = new Random().Next(1000, 9999).ToString();
				SmsSendViewModel smsItem = new SmsSendViewModel
				{
					SmsSendBody = Labels.ActiveDemoUserVerifyCodeDesc + ": " + text,
					FirstBodyTemp = "کد تایید ارسال شد.",
					SmsToNumber = prsMobile,
					Numbers = prsMobile,
					CompaniesId = cmpId.ToString(),
					CompanyPersonsId = prsId.ToString()
				};
				if (new CRMIdeal.Classes.Helper.Sms().SendSmsActiveDemoUser(smsItem, webServiceUserName, webServicePassword, webServiceNumber, isSendVerificationCode: true, ref errorMessage))
				{
					errorMessage = "1|" + text;
				}
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			errorMessage = Messages.msgErrorRunFunction + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			errorMessage = Messages.msgErrorRunFunction + "<br />" + ex2.Message;
		}
		return errorMessage;
	}

	[AjaxOnly]
	public JsonResult GetCmpPersons(int cmpId)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyPersons_Result> list2 = CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpId);
			if (list2 != null && Enumerable.Any<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list2))
			{
				foreach (CRMspSelectCompanyPersons_Result item2 in list2)
				{
					string text = item2.prsMobile ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						SelectListItem item = new SelectListItem
						{
							Text = item2.PersonName + " (" + text + ")",
							Value = text + "|" + item2.CompanyPersonID,
							Selected = false
						};
						list.Add(item);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpPersonList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string CreateAndActiveDemoUser(int cmpId, int prsId, string prsMobile, string webServiceUserName, string webServicePassword, string webServiceNumber, string demoUrl, string demoUName, string demoUpass)
	{
		string errorMessage = "";
		_ = UserLogin.CurrentUser.UserId;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string appType = Configuration.AppType;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actActiveDemoUser", UserLogin.CurrentUser))
			{
				errorMessage = Messages.ErrorNotAccess;
			}
			else
			{
				if (cmpId == 0)
				{
					return Messages.msgErrorNotSelectCompany;
				}
				if (prsId == 0)
				{
					return string.Format(Messages.msgErrorIsNotEntered, Labels.ActiveDemoUserMobile);
				}
				if (string.IsNullOrWhiteSpace(prsMobile))
				{
					return string.Format(Messages.msgErrorIsNotEntered, Labels.ActiveDemoUserMobile);
				}
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById == null)
				{
					return Messages.msgErrorNotSelectCompany;
				}
				if (string.IsNullOrWhiteSpace(demoUrl ?? "") || string.IsNullOrWhiteSpace(demoUName) || string.IsNullOrWhiteSpace(demoUpass))
				{
					return Messages.msgErrorCommunicateWithServer + "<br>اطلاعات سروس بطور درستی وارد نگردیده است.";
				}
				if (!demoUrl.EndsWith("/"))
				{
					demoUrl += "/";
				}
				if (!string.IsNullOrWhiteSpace(demoUpass))
				{
					demoUpass = demoUpass.Replace(" ", "+");
				}
				HttpClient obj = new HttpClient
				{
					BaseAddress = new Uri(demoUrl),
					DefaultRequestHeaders = 
					{
						Accept = 
						{
							new MediaTypeWithQualityHeaderValue("application/json")
						}
					}
				};
				string text = "ApiUser/ActiveDemoUser";
				ActiveDemoUserApiInsertUserViewModel activeDemoUserApiInsertUserViewModel = new ActiveDemoUserApiInsertUserViewModel
				{
					UserName = demoUName,
					Password = demoUpass,
					UserId = -10,
					ApiFName = (companyById.cmpTitle ?? ""),
					ApiLName = (companyById.cmpName ?? ""),
					ApiUserName = companyById.cmpNumber.ToString(),
					ApiPassword = companyById.cmpNumber.ToString()
				};
				new BaseInfo().ConvertMd5(activeDemoUserApiInsertUserViewModel.ApiPassword).ToLower();
				activeDemoUserApiInsertUserViewModel.ApiIsActive = true;
				activeDemoUserApiInsertUserViewModel.ApiUserIsActiveInWebApp = true;
				activeDemoUserApiInsertUserViewModel.ApiUserIsActiveInMobApp = true;
				activeDemoUserApiInsertUserViewModel.ApiAllowCopyOtherLanguage = true;
				activeDemoUserApiInsertUserViewModel.ApiExpireDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00")).AddDays(10.0);
				activeDemoUserApiInsertUserViewModel.ApiAccessAllLanguage = true;
				activeDemoUserApiInsertUserViewModel.ApiRollName = "کاربر دمو";
				HttpResponseMessage result2 = obj.PostAsync(content: new StringContent(JsonConvert.SerializeObject(activeDemoUserApiInsertUserViewModel), Encoding.UTF8, "application/json"), requestUri: "api/" + text).Result;
				if (!result2.IsSuccessStatusCode)
				{
					return Messages.msgErrorCommunicateWithServer;
				}
				ActiveDemoUserApiResultViewModel<ActiveDemoUserApiInsertUserResultViewModel> activeDemoUserApiResultViewModel = JsonConvert.DeserializeObject<ActiveDemoUserApiResultViewModel<ActiveDemoUserApiInsertUserResultViewModel>>(result2.Content.ReadAsStringAsync().Result);
				if (activeDemoUserApiResultViewModel.Status == "Success" && activeDemoUserApiResultViewModel.Data != null)
				{
					int result3 = 0;
					int.TryParse(activeDemoUserApiResultViewModel.Data.UserId.ToString(), out result3);
					if (result3 == 0)
					{
						return Messages.msgErrorRunFunction + "<br>نسخه دمو فعال نگردیده است!";
					}
					int userId = UserLogin.CurrentUser.UserId;
					DateTime now = DateTime.Now;
					DateTime value = now;
					string text2 = now.ToString("yyyyMMdd", new PersianCulture());
					string cnvsDay = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
					string cnvsTime = now.ToString("HH:mm:ss");
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					short value3 = short.Parse(Financial.Get().Id.ToString());
					string cnvsDesc = "نسخه دمو فعال شد.\nکاربری و رمز عبور دمو:\n" + companyById.cmpNumber;
					ObjectParameter objectParameter = new ObjectParameter("InsertedConversationId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
					int num = _dbI.CRMspInsertConversationForActiveDemoUser(cmpId, prsId, text2, cnvsDay, cnvsTime, value, cnvsDesc, userId, userId, userId, value2, value3, value, text2, appType, result, objectParameter, objectParameter2, centerId);
					int result4 = 0;
					int.TryParse(num.ToString(), out result4);
					if (result4 <= 0)
					{
						if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
						{
							string text3 = "";
							string? text4 = objectParameter2.Value.ToString();
							if (text4.IndexOf("No Prj", StringComparison.Ordinal) >= 0)
							{
								text3 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsProjectId) + "<br>";
							}
							if (text4.IndexOf("No Topic", StringComparison.Ordinal) >= 0)
							{
								text3 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsTopicId) + "<br>";
							}
							if (text4.IndexOf("No Status", StringComparison.Ordinal) >= 0)
							{
								text3 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsStatusId) + "<br>";
							}
							return Messages.msgErrorRunFunction + "<br>" + text3;
						}
						if (objectParameter == null || objectParameter.Value.ToString() == "0")
						{
							return Messages.msgErrorRunFunction + "<br>مذاکره ای درج نگردیده است!";
						}
						return Messages.msgErrorRunFunction;
					}
					if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
					{
						string text5 = "";
						string? text6 = objectParameter2.Value.ToString();
						if (text6.IndexOf("No Prj", StringComparison.Ordinal) >= 0)
						{
							text5 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsProjectId) + "<br>";
						}
						if (text6.IndexOf("No Topic", StringComparison.Ordinal) >= 0)
						{
							text5 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsTopicId) + "<br>";
						}
						if (text6.IndexOf("No Status", StringComparison.Ordinal) >= 0)
						{
							text5 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsStatusId) + "<br>";
						}
						return Messages.msgErrorRunFunction + "<br>" + text5;
					}
					if (objectParameter == null || objectParameter.Value.ToString() == "0")
					{
						return Messages.msgErrorRunFunction + "<br>مذاکره ای درج نگردیده است!";
					}
					int result5 = 0;
					int.TryParse(objectParameter.Value.ToString(), out result5);
					string smsSendBody = "*CRMایده آل*\nنام کاربری و رمزعبور نسخه دمو :\n" + companyById.cmpNumber;
					SmsSendViewModel smsItem = new SmsSendViewModel
					{
						SmsSendBody = smsSendBody,
						SmsToNumber = prsMobile,
						Numbers = prsMobile,
						CompaniesId = cmpId.ToString(),
						CompanyPersonsId = prsId.ToString()
					};
					bool flag = new CRMIdeal.Classes.Helper.Sms().SendSmsActiveDemoUser(smsItem, webServiceUserName, webServicePassword, webServiceNumber, isSendVerificationCode: false, ref errorMessage);
					if (flag && result5 > 0)
					{
						errorMessage = "";
					}
					else
					{
						if (!flag)
						{
							return Messages.msgErrorRunFunction + "<br>پیامک حاوی نام کاربری و رمز عبور ارسال نگردیده است";
						}
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + "<br>مذاکره ای درج نگردیده است!";
						}
					}
				}
				else
				{
					string text7 = ((activeDemoUserApiResultViewModel != null) ? (activeDemoUserApiResultViewModel.Message ?? "") : "");
					errorMessage = Messages.msgErrorRunFunction + "<br>" + text7 + "<br>نسخه دمو فعال نگردیده است!";
				}
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			errorMessage = Messages.msgErrorRunFunction + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			errorMessage = Messages.msgErrorRunFunction + "<br />" + ex2.Message;
		}
		return errorMessage;
	}

	[AjaxOnly]
	public string ActiveOrDeActiveDemoUser(int cmpId, int mode, string webServiceUserName, string webServicePassword, string webServiceNumber, string demoUrl, string demoUName, string demoUpass)
	{
		string result = "";
		_ = UserLogin.CurrentUser.UserId;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string appType = Configuration.AppType;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actActiveDemoUser", UserLogin.CurrentUser))
			{
				result = Messages.ErrorNotAccess;
			}
			else
			{
				if (cmpId == 0)
				{
					return Messages.msgErrorNotSelectCompany;
				}
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById == null)
				{
					return Messages.msgErrorNotSelectCompany;
				}
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				int result3 = 0;
				int.TryParse(companyById.cmpMainPersonId.ToString(), out result3);
				if (result3 == 0)
				{
					return string.Format(Messages.msgErrorIsNotEntered, Labels.ActiveDemoUserMobile);
				}
				if (string.IsNullOrWhiteSpace(demoUrl ?? "") || string.IsNullOrWhiteSpace(demoUName) || string.IsNullOrWhiteSpace(demoUpass))
				{
					return Messages.msgErrorCommunicateWithServer + "<br>اطلاعات سروس بطور درستی وارد نگردیده است.";
				}
				if (!demoUrl.EndsWith("/"))
				{
					demoUrl += "/";
				}
				if (!string.IsNullOrWhiteSpace(demoUpass))
				{
					demoUpass = demoUpass.Replace(" ", "+");
				}
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(demoUrl);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				int result4 = 0;
				string text = "ApiUser/Select";
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new ActiveDemoUserApiSelectViewModel
				{
					UserName = demoUName,
					Password = demoUpass,
					ApiUserName = companyById.cmpNumber.ToString()
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage result5 = httpClient.PostAsync("api/" + text, content).Result;
				if (!result5.IsSuccessStatusCode)
				{
					return Messages.msgErrorCommunicateWithServer;
				}
				ActiveDemoUserApiResultViewModel<List<ActiveDemoUserApiSelectResultViewModel>> activeDemoUserApiResultViewModel = JsonConvert.DeserializeObject<ActiveDemoUserApiResultViewModel<List<ActiveDemoUserApiSelectResultViewModel>>>(result5.Content.ReadAsStringAsync().Result);
				if (!(activeDemoUserApiResultViewModel.Status == "Success") || activeDemoUserApiResultViewModel.Data == null)
				{
					return Messages.msgErrorRunFunction + "<br>نسخه دمو فعال نگردیده است!";
				}
				ActiveDemoUserApiSelectResultViewModel activeDemoUserApiSelectResultViewModel = new ActiveDemoUserApiSelectResultViewModel();
				if (Enumerable.Any<ActiveDemoUserApiSelectResultViewModel>((IEnumerable<ActiveDemoUserApiSelectResultViewModel>)activeDemoUserApiResultViewModel.Data))
				{
					activeDemoUserApiSelectResultViewModel = Enumerable.FirstOrDefault<ActiveDemoUserApiSelectResultViewModel>((IEnumerable<ActiveDemoUserApiSelectResultViewModel>)activeDemoUserApiResultViewModel.Data);
				}
				if (activeDemoUserApiSelectResultViewModel != null)
				{
					int.TryParse(activeDemoUserApiSelectResultViewModel.ApiUserId.ToString(), out result4);
					_ = activeDemoUserApiSelectResultViewModel.ApiExpireDate;
				}
				if (result4 == 0)
				{
					return Messages.msgErrorRunFunction + "<br>کاربری در نسخه دمو یافت نشد!";
				}
				text = "ApiUser/Update";
				ActiveDemoUserApiUpdateUserViewModel activeDemoUserApiUpdateUserViewModel = new ActiveDemoUserApiUpdateUserViewModel();
				activeDemoUserApiUpdateUserViewModel.UserName = demoUName;
				activeDemoUserApiUpdateUserViewModel.Password = demoUpass;
				activeDemoUserApiUpdateUserViewModel.UserId = -10;
				activeDemoUserApiUpdateUserViewModel.ApiUserId = result4;
				activeDemoUserApiUpdateUserViewModel.UsedInKaraAfzar = true;
				switch (mode)
				{
				case 1:
					activeDemoUserApiUpdateUserViewModel.ApiIsActive = false;
					activeDemoUserApiUpdateUserViewModel.ApiUserIsActiveInWebApp = false;
					activeDemoUserApiUpdateUserViewModel.ApiUserIsActiveInMobApp = false;
					break;
				case 2:
					activeDemoUserApiUpdateUserViewModel.ApiIsActive = true;
					activeDemoUserApiUpdateUserViewModel.ApiUserIsActiveInWebApp = true;
					activeDemoUserApiUpdateUserViewModel.ApiUserIsActiveInMobApp = true;
					activeDemoUserApiUpdateUserViewModel.ApiExpireDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00")).AddDays(10.0);
					break;
				}
				content = new StringContent(JsonConvert.SerializeObject(activeDemoUserApiUpdateUserViewModel), Encoding.UTF8, "application/json");
				result5 = httpClient.PostAsync("api/" + text, content).Result;
				if (!result5.IsSuccessStatusCode)
				{
					return Messages.msgErrorCommunicateWithServer;
				}
				ActiveDemoUserApiResultViewModel<int> activeDemoUserApiResultViewModel2 = JsonConvert.DeserializeObject<ActiveDemoUserApiResultViewModel<int>>(result5.Content.ReadAsStringAsync().Result);
				if (!(activeDemoUserApiResultViewModel2.Status == "Success"))
				{
					string text2 = ((activeDemoUserApiResultViewModel2 != null) ? (activeDemoUserApiResultViewModel2.Message ?? "") : "");
					return Messages.msgErrorRunFunction + "<br>" + text2;
				}
				int result6 = 0;
				int.TryParse(activeDemoUserApiResultViewModel2.Data.ToString(), out result6);
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text3 = now.ToString("yyyyMMdd", new PersianCulture());
				string cnvsDay = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				string cnvsTime = now.ToString("HH:mm:ss");
				short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				short value3 = short.Parse(Financial.Get().Id.ToString());
				string cnvsDesc = "";
				switch (mode)
				{
				case 1:
					cnvsDesc = "نسخه دمو غیر فعال شد.";
					break;
				case 2:
				{
					string text4 = (activeDemoUserApiUpdateUserViewModel.ApiExpireDate.HasValue ? activeDemoUserApiUpdateUserViewModel.ApiExpireDate.Value.ToString("yyyy/MM/dd") : "");
					cnvsDesc = "نسخه دمو تا تاریخ " + text4 + " تمدید شد.";
					break;
				}
				}
				ObjectParameter objectParameter = new ObjectParameter("InsertedConversationId", 0);
				ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
				int num = _dbI.CRMspInsertConversationForActiveDemoUser(cmpId, result3, text3, cnvsDay, cnvsTime, value, cnvsDesc, userId, userId, userId, value2, value3, value, text3, appType, result2, objectParameter, objectParameter2, centerId);
				int result7 = 0;
				int.TryParse(num.ToString(), out result7);
				if (result7 <= 0)
				{
					if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
					{
						string text5 = "";
						string? text6 = objectParameter2.Value.ToString();
						if (text6.IndexOf("No Prj", StringComparison.Ordinal) >= 0)
						{
							text5 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsProjectId) + "<br>";
						}
						if (text6.IndexOf("No Topic", StringComparison.Ordinal) >= 0)
						{
							text5 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsTopicId) + "<br>";
						}
						if (text6.IndexOf("No Status", StringComparison.Ordinal) >= 0)
						{
							text5 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsStatusId) + "<br>";
						}
						return Messages.msgErrorRunFunction + "<br>" + text5;
					}
					if (objectParameter == null || objectParameter.Value.ToString() == "0")
					{
						return Messages.msgErrorRunFunction + "<br>مذاکره ای درج نگردیده است!";
					}
					int result8 = 0;
					int.TryParse(objectParameter.Value.ToString(), out result8);
					if (result8 > 0)
					{
						result = "";
					}
					else if (result8 == 0)
					{
						return Messages.msgErrorRunFunction + "<br>مذاکره ای درج نگردیده است!";
					}
					return Messages.msgErrorRunFunction;
				}
				if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
				{
					string text7 = "";
					string? text8 = objectParameter2.Value.ToString();
					if (text8.IndexOf("No Prj", StringComparison.Ordinal) >= 0)
					{
						text7 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsProjectId) + "<br>";
					}
					if (text8.IndexOf("No Topic", StringComparison.Ordinal) >= 0)
					{
						text7 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsTopicId) + "<br>";
					}
					if (text8.IndexOf("No Status", StringComparison.Ordinal) >= 0)
					{
						text7 = string.Format(Messages.msgErrorIsNotSpecified, Labels.cnvsStatusId) + "<br>";
					}
					return Messages.msgErrorRunFunction + "<br>" + text7;
				}
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					return Messages.msgErrorRunFunction + "<br>مذاکره ای درج نگردیده است!";
				}
				int result9 = 0;
				int.TryParse(objectParameter.Value.ToString(), out result9);
				if (result9 > 0)
				{
					result = "";
				}
				else if (result9 == 0)
				{
					return Messages.msgErrorRunFunction + "<br>مذاکره ای درج نگردیده است!";
				}
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			result = Messages.msgErrorRunFunction + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			result = Messages.msgErrorRunFunction + "<br />" + ex2.Message;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
