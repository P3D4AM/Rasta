using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CRM.General.Cache;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Leave.Controllers;
using CRMIdeal.Cache;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using CaptchaMvc.HtmlHelpers;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Controllers;

public class AccountController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public CRMspSelectSystemCrmProject_Result sysProject;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public CRMspLoadUserLoginInfo_Result user;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly string apiUri = "http://mob.karaafzar.net/";

	private const string _FormName_frmLogin = "frmLogin";

	private const int _LeaveTypeId_HourlyLeave = 1;

	private const int _LeaveTypeId_DailyLeave = 2;

	private const int _LeaveTypeId_HourlyMission = 3;

	private const int _LeaveTypeId_DailyMission = 4;

	public ActionResult Login(string ReturnUrl = "", bool fromOtherSystems = false)
	{
		base.ViewBag.FromAdmin = "0";
		base.ViewBag.MaxLoginCountExceeded = "";
		base.ViewBag.Message = "";
		base.ViewBag.ReturnUrl = ReturnUrl;
		LoginViewModel model = new LoginViewModel();
		GetLoginCustomHtml();
		if (fromOtherSystems)
		{
			model = base.TempData["loginOtherSystemData"] as LoginViewModel;
			return LoginI(model, ReturnUrl, base.HttpContext);
		}
		int num = int.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
		string value = ApplicationSettings.GetValue("yevNGNeetPc=");
		if (!string.IsNullOrEmpty(value))
		{
			try
			{
				value = CodeDecode.DeCodding(value);
				value = value.Trim().Replace("/", "").Replace("-", "")
					.Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				int num2 = int.Parse(value);
				if (num > num2)
				{
					base.ViewBag.ErrorExpDate = Messages.msgErrorExpDate;
					return View(model);
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		string value2 = ApplicationSettings.GetValue("RegisterCode");
		if (value2 != null)
		{
			string[] array = CodeDecode.RegDeCodding(value2).Split(new char[1] { '|' });
			if (array.Length >= 3)
			{
				string[] array2 = CodeDecode.RegDeCodding(array[2]).Split(new string[1] { "^@^" }, StringSplitOptions.None);
				string text = "";
				if (base.HttpContext.Request.Url != null)
				{
					text = base.HttpContext.Request.Url.Authority.ToLower().Replace("www.", "");
				}
				base.ViewBag.Url = "url:  " + text;
				if (Enumerable.Any<string>((IEnumerable<string>)array2))
				{
					bool flag = false;
					bool[] array3 = new bool[Enumerable.Count<string>((IEnumerable<string>)array2)];
					for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)array2); i++)
					{
						if (((!string.IsNullOrEmpty(array2[i])) ? array2[i].Trim().ToLower() : "") == text)
						{
							array3[i] = true;
						}
					}
					if (Enumerable.Any<bool>((IEnumerable<bool>)array3))
					{
						bool[] array4 = array3;
						for (int j = 0; j < array4.Length; j++)
						{
							if (array4[j])
							{
								flag = true;
							}
						}
					}
					if (!flag)
					{
						base.ViewBag.Error = Messages.msgErrorUnauthorized;
						return View(model);
					}
					if (array.Length >= 4)
					{
						int.TryParse(CodeDecode.RegDeCodding(array[3]), out var result);
						int num3 = Enumerable.Count<CRMspSelectLanguages_Result>((IEnumerable<CRMspSelectLanguages_Result>)_db.CRMspSelectLanguages(), (Func<CRMspSelectLanguages_Result, bool>)((CRMspSelectLanguages_Result c) => c.IsActive.GetValueOrDefault()));
						if (result < num3)
						{
							base.ViewBag.Error = Messages.msgErrorLanguageTable;
							return View(model);
						}
					}
					CheckClientValidation();
					try
					{
						CRMspSelectSystemCrmProject_Result cRMspSelectSystemCrmProject_Result = Enumerable.FirstOrDefault<CRMspSelectSystemCrmProject_Result>((IEnumerable<CRMspSelectSystemCrmProject_Result>)_db.CRMspSelectSystemCrmProject());
						if (cRMspSelectSystemCrmProject_Result != null)
						{
							base.ViewBag.VersionDb = cRMspSelectSystemCrmProject_Result.Version ?? "";
							string text2 = "";
							if (!string.IsNullOrWhiteSpace(cRMspSelectSystemCrmProject_Result.Description) && cRMspSelectSystemCrmProject_Result.Description == "ClientInActive")
							{
								text2 = "IIS need upgrade!";
							}
							base.ViewBag.ErrorCheckClientValidation = text2;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
					if (base.Request.IsAuthenticated && ReturnUrl == "")
					{
						return Redirect(FormsAuthentication.DefaultUrl);
					}
					if (ReturnUrl == "" && base.HttpContext.User.Identity.IsAuthenticated && !UserLogin.CurrentUser.FromLoginPage)
					{
						if (base.Request.Cookies[".ASPXAUTH"] != null)
						{
							FormsAuthentication.SignOut();
							CacheManager.ClearAll();
							base.Session.Clear();
						}
						base.Response.Redirect("/Account/Logout?xit=0", false);
					}
					return View(model);
				}
				base.ViewBag.Error = Messages.msgErrorUnauthorized + Messages.msgErrorNotDefineDomain;
				return View(model);
			}
			base.ViewBag.Error = Messages.msgErrorSysNotRegistered;
			return View(model);
		}
		base.ViewBag.Error = Messages.msgErrorSysNotRegistered;
		return View(model);
	}

	[HttpPost]
	[AllowAnonymous]
	[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
	public ActionResult Login(LoginViewModel login, string ReturnUrl)
	{
		return LoginI(login, ReturnUrl, base.HttpContext);
	}

	public ActionResult LoginI(LoginViewModel login, string ReturnUrl, HttpContextBase httpContext = null)
	{
		//IL_1d16: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3c: Expected O, but got Unknown
		//IL_1e45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e4c: Expected O, but got Unknown
		//IL_0823: Unknown result type (might be due to invalid IL or missing references)
		//IL_082a: Expected O, but got Unknown
		//IL_21f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_21fc: Expected O, but got Unknown
		//IL_20e0: Unknown result type (might be due to invalid IL or missing references)
		if (httpContext == null)
		{
			httpContext = base.HttpContext;
		}
		base.ViewBag.FromAdmin = "0";
		if (login.IsCheckCaptchaCode)
		{
			this.IsCaptchaValid(Messages.msgErrorMessageInvalidCaptchaReply);
		}
		login.IsCheckCaptchaCode = true;
		login.CaptchaCode = ((login.CaptchaCode == "1") ? "" : login.CaptchaCode);
		GetLoginCustomHtml();
		int num = int.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
		string value = ApplicationSettings.GetValue("yevNGNeetPc=");
		if (!string.IsNullOrEmpty(value))
		{
			try
			{
				value = CodeDecode.DeCodding(value);
				value = value.Trim().Replace("/", "").Replace("-", "")
					.Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				int num2 = int.Parse(value);
				if (num > num2)
				{
					base.ViewBag.ErrorExpDate = Messages.msgErrorExpDate;
					return View(login);
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		try
		{
			base.ViewBag.ReturnUrl = ReturnUrl;
			string value2 = ApplicationSettings.GetValue("RegisterCode");
			if (value2 == null)
			{
				base.ViewBag.Error = Messages.msgErrorSysNotRegistered;
				return View(login);
			}
			string[] array = CodeDecode.RegDeCodding(value2).Split(new char[1] { '|' });
			if (array.Length < 3)
			{
				base.ViewBag.Error = Messages.msgErrorSysNotRegistered;
				return View(login);
			}
			string[] array2 = CodeDecode.RegDeCodding(array[2]).Split(new string[1] { "^@^" }, StringSplitOptions.None);
			string text = "";
			if (httpContext.Request.Url != null)
			{
				text = httpContext.Request.Url.Authority.ToLower().Replace("www.", "");
			}
			base.ViewBag.Url = "url:  " + text;
			if (!Enumerable.Any<string>((IEnumerable<string>)array2))
			{
				base.ViewBag.Error = Messages.msgErrorUnauthorized + Messages.msgErrorNotDefineDomain;
				return View(login);
			}
			bool flag = false;
			bool[] array3 = new bool[Enumerable.Count<string>((IEnumerable<string>)array2)];
			for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)array2); i++)
			{
				if (((!string.IsNullOrEmpty(array2[i])) ? array2[i].Trim().ToLower() : "") == text)
				{
					array3[i] = true;
				}
			}
			if (Enumerable.Any<bool>((IEnumerable<bool>)array3))
			{
				bool[] array4 = array3;
				for (int j = 0; j < array4.Length; j++)
				{
					if (array4[j])
					{
						flag = true;
					}
				}
			}
			if (!flag)
			{
				base.ViewBag.Error = Messages.msgErrorUnauthorized;
				return View(login);
			}
			if (array.Length >= 4)
			{
				int.TryParse(CodeDecode.RegDeCodding(array[3]), out var result);
				int num3 = Enumerable.Count<CRMspSelectLanguages_Result>((IEnumerable<CRMspSelectLanguages_Result>)_db.CRMspSelectLanguages(), (Func<CRMspSelectLanguages_Result, bool>)((CRMspSelectLanguages_Result c) => c.IsActive.GetValueOrDefault()));
				if (result < num3)
				{
					base.ViewBag.Error = Messages.msgErrorLanguageTable;
					return View(login);
				}
			}
			if (base.ModelState.IsValid || login.LoginAuthType.GetValueOrDefault() == 3)
			{
				CRMspSelectSystemCrmProject_Result cRMspSelectSystemCrmProject_Result = Enumerable.FirstOrDefault<CRMspSelectSystemCrmProject_Result>((IEnumerable<CRMspSelectSystemCrmProject_Result>)_db.CRMspSelectSystemCrmProject());
				string text2 = "";
				string text3 = "";
				if (cRMspSelectSystemCrmProject_Result != null)
				{
					text2 = cRMspSelectSystemCrmProject_Result.Version ?? "";
					base.ViewBag.VersionDb = cRMspSelectSystemCrmProject_Result.Version ?? "";
					if (!string.IsNullOrWhiteSpace(cRMspSelectSystemCrmProject_Result.Description) && cRMspSelectSystemCrmProject_Result.Description == "ClientInActive")
					{
						text3 = "IIS need upgrade!";
					}
					base.ViewBag.ErrorCheckClientValidation = text3;
				}
				if (VersionConfig.CurrentVerWin == text2 && string.IsNullOrEmpty(text3))
				{
					_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
					BaseInfo baseInfo = new BaseInfo();
					string userPassword = "";
					if (login.LoginAuthType.GetValueOrDefault() != 3)
					{
						userPassword = baseInfo.ConvertMd5(login.Password).ToLower();
					}
					_003C_003Ec__DisplayClass7_.user = null;
					if (login.LoginAuthType.GetValueOrDefault() == 2)
					{
						string activeDirectoryDomain = SysSeting.Get().ActiveDirectoryDomain;
						string text4 = login.UserName + "@" + activeDirectoryDomain;
						try
						{
							PrincipalContext val = new PrincipalContext((ContextType)1, activeDirectoryDomain);
							try
							{
								if (!val.ValidateCredentials(text4, login.Password))
								{
									base.ViewBag.Error = Messages.msgErrorCheckUsernamePassword;
								}
								else
								{
									_003C_003Ec__DisplayClass7_.user = Enumerable.FirstOrDefault<CRMspLoadUserLoginInfo_Result>((IEnumerable<CRMspLoadUserLoginInfo_Result>)_db.CRMspLoadUserLoginInfo(0, login.UserName, login.Password, Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID, login.UserName));
								}
							}
							finally
							{
								((IDisposable)val)?.Dispose();
							}
						}
						catch
						{
							base.ViewBag.Error = Messages.msgErrorCheckUsernamePassword;
						}
					}
					else if (login.LoginAuthType.GetValueOrDefault() == 3)
					{
						CRMspLoadUserLoginInfo_Result cRMspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<CRMspLoadUserLoginInfo_Result>((IEnumerable<CRMspLoadUserLoginInfo_Result>)_db.CRMspLoadUserLoginInfo(0, login.UserName, login.Password, Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID, login.UserName));
						if (cRMspLoadUserLoginInfo_Result != null)
						{
							_003C_003Ec__DisplayClass7_.user = cRMspLoadUserLoginInfo_Result;
						}
					}
					else
					{
						_003C_003Ec__DisplayClass7_.user = Enumerable.FirstOrDefault<CRMspLoadUserLoginInfo_Result>((IEnumerable<CRMspLoadUserLoginInfo_Result>)_db.CRMspLoadUserLoginInfo(0, login.UserName, userPassword, Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID, null));
					}
					if (_003C_003Ec__DisplayClass7_.user != null)
					{
						login.FName = _003C_003Ec__DisplayClass7_.user.FName;
						login.LName = _003C_003Ec__DisplayClass7_.user.LName;
						if (_003C_003Ec__DisplayClass7_.user.ExpireDate.HasValue)
						{
							_003C_003Ec__DisplayClass7_.user.ExpireDatePersian = (_003C_003Ec__DisplayClass7_.user.ExpireDate.HasValue ? _003C_003Ec__DisplayClass7_.user.ExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
							long num4 = long.Parse(_003C_003Ec__DisplayClass7_.user.ExpireDatePersian);
							if (long.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture())) > num4)
							{
								base.ViewBag.Error = Messages.msgErrorUsernameExpired;
								base.ViewBag.ReturnUrl = ReturnUrl;
								return View(login);
							}
						}
						if (_003C_003Ec__DisplayClass7_.user.UserIsActiveInWebApp.GetValueOrDefault())
						{
							int userRollId = _003C_003Ec__DisplayClass7_.user.UserRollId;
							bool flag2 = _003C_003Ec__DisplayClass7_.user.IsActive.HasValue && _003C_003Ec__DisplayClass7_.user.IsActive != false;
							if (userRollId != 0 && flag2)
							{
								DbSet<Users> users = _dbTbl.Users;
								ParameterExpression val2 = Expression.Parameter(typeof(Users), "c");
								if (Queryable.Any<Users>((IQueryable<Users>)users, Expression.Lambda<Func<Users, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val2, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val2, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Constant((object)true, typeof(bool)), typeof(bool?)))), (ParameterExpression[])(object)new ParameterExpression[1] { val2 })) && login.SendFromAdmin.Trim() == "1")
								{
									Dictionary<int, int> dictionary = LoginCount.Get();
									bool flag3 = false;
									try
									{
										foreach (KeyValuePair<int, int> item in dictionary)
										{
											if (item.Value > 1 && item.Key != _003C_003Ec__DisplayClass7_.user.UserId)
											{
												LoginCount.Update(LoginCountType.Minus, item.Key);
												Manager.ClearAllUserCach(item.Key);
												flag3 = true;
												break;
											}
										}
									}
									catch (Exception e2)
									{
										ErrorSignal.FromCurrentContext().Raise(e2);
									}
									if (!flag3)
									{
										try
										{
											foreach (KeyValuePair<int, int> item2 in dictionary)
											{
												if (item2.Value > 0 && item2.Key != _003C_003Ec__DisplayClass7_.user.UserId)
												{
													LoginCount.Update(LoginCountType.Minus, item2.Key);
													Manager.ClearAllUserCach(item2.Key);
													flag3 = true;
													break;
												}
											}
										}
										catch (Exception e3)
										{
											ErrorSignal.FromCurrentContext().Raise(e3);
										}
									}
									if (!flag3)
									{
										try
										{
											foreach (KeyValuePair<int, int> item3 in dictionary)
											{
												LoginCount.Update(LoginCountType.Minus, item3.Key);
												Manager.ClearAllUserCach(item3.Key);
												flag3 = true;
											}
										}
										catch (Exception e4)
										{
											ErrorSignal.FromCurrentContext().Raise(e4);
										}
										Manager.ClearAllUserCach();
										LoginCount.Clear();
										Manager.ClearAllCach();
										base.ViewBag.Error = Messages.msgReleaseDone;
										base.ViewBag.ReturnUrl = ReturnUrl;
										return View(login);
									}
								}
								CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
								if (currentUser != null)
								{
									Info.Clear(currentUser.UserId);
									LoginActivity.Remove(_003C_003Ec__DisplayClass7_.user.UserId);
								}
								LoginActivity.RemoveExpiredLogins();
								int num5 = LoginCount.Count();
								int maxCountOfOnlineUser = Configuration.MaxCountOfOnlineUser;
								switch (maxCountOfOnlineUser)
								{
								case 0:
									base.ViewBag.Error = Messages.errorInReadingSetting;
									base.ViewBag.ReturnUrl = ReturnUrl;
									return View(login);
								case -1:
									base.ViewBag.Error = Messages.errorInSeriallock;
									base.ViewBag.ReturnUrl = ReturnUrl;
									return View(login);
								default:
								{
									if (num5 >= maxCountOfOnlineUser)
									{
										LoginActivity.Remove(_003C_003Ec__DisplayClass7_.user.UserId);
										num5 = LoginCount.Count();
									}
									DateTime now = DateTime.Now;
									string currIPAddress = (httpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? httpContext.Request.ServerVariables["REMOTE_ADDR"]).Split(new char[1] { ',' })[0].Trim();
									CRMspCheckUserLoginAllowedTimes_Result cRMspCheckUserLoginAllowedTimes_Result = Enumerable.FirstOrDefault<CRMspCheckUserLoginAllowedTimes_Result>((IEnumerable<CRMspCheckUserLoginAllowedTimes_Result>)Enumerable.ToList<CRMspCheckUserLoginAllowedTimes_Result>((IEnumerable<CRMspCheckUserLoginAllowedTimes_Result>)_db.CRMspCheckUserLoginAllowedTimes(_003C_003Ec__DisplayClass7_.user.UserId, now.ToString("yyyyMMdd", new PersianCulture()), PersianDate.GetCurrentNumberWeekOfDay, now.ToString("HH:mm"), currIPAddress)));
									if (cRMspCheckUserLoginAllowedTimes_Result != null && cRMspCheckUserLoginAllowedTimes_Result.AllowUserLogin.HasValue && cRMspCheckUserLoginAllowedTimes_Result.AllowUserLogin.GetValueOrDefault())
									{
										int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
										if (result2 <= 0)
										{
											result2 = 1065;
										}
										CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
										bool result3 = false;
										if (cRMspSelectCrmsysSetting_Result != null)
										{
											bool.TryParse(cRMspSelectCrmsysSetting_Result.SmartTimeAttendance.ToString(), out result3);
										}
										bool result4 = false;
										if (_003C_003Ec__DisplayClass7_.user != null)
										{
											bool.TryParse(_003C_003Ec__DisplayClass7_.user.DeActiveSmartTimeAttendance.ToString(), out result4);
										}
										bool result5 = false;
										if (_003C_003Ec__DisplayClass7_.user != null)
										{
											bool.TryParse(_003C_003Ec__DisplayClass7_.user.DeActiveLoginWithoutShift.ToString(), out result5);
										}
										bool result6 = false;
										bool.TryParse(login.InactiveSaveTimeAttendance.ToString(), out result6);
										bool result7 = false;
										bool.TryParse(login.CheckedTimeAttendance.ToString(), out result7);
										if (!result7 && login.LoginAuthType.GetValueOrDefault() != 3)
										{
											if (result5)
											{
												int num6 = 0;
												List<CRMspSelectTimeAttendanceNoExit_Result> list = Enumerable.ToList<CRMspSelectTimeAttendanceNoExit_Result>((IEnumerable<CRMspSelectTimeAttendanceNoExit_Result>)_dbII.CRMspSelectTimeAttendanceNoExit(_003C_003Ec__DisplayClass7_.user.UserId, DateTime.Now, result2, result2));
												if (list != null && list != null && list.Count > 0)
												{
													num6 += list.Count;
												}
												List<CRMspSelectShiftWorkingTimeByDate_Result> list2 = Enumerable.ToList<CRMspSelectShiftWorkingTimeByDate_Result>((IEnumerable<CRMspSelectShiftWorkingTimeByDate_Result>)_dbII.CRMspSelectShiftWorkingTimeByDate(_003C_003Ec__DisplayClass7_.user.UserId, DateTime.Now, _003C_003Ec__DisplayClass7_.user.ShiftWorkingId, 1, result2, result2));
												if (list2 != null && list2 != null && list2.Count > 0)
												{
													int? obj2;
													if (list2 == null)
													{
														obj2 = null;
													}
													else
													{
														IEnumerable<CRMspSelectShiftWorkingTimeByDate_Result> enumerable = Enumerable.Where<CRMspSelectShiftWorkingTimeByDate_Result>((IEnumerable<CRMspSelectShiftWorkingTimeByDate_Result>)list2, (Func<CRMspSelectShiftWorkingTimeByDate_Result, bool>)((CRMspSelectShiftWorkingTimeByDate_Result x) => x.ExitTimeMin > DateTime.Now.Hour * 60 + DateTime.Now.Minute));
														obj2 = ((enumerable != null) ? new int?(Enumerable.Count<CRMspSelectShiftWorkingTimeByDate_Result>(enumerable)) : null);
													}
													int? num7 = obj2;
													if (num7.GetValueOrDefault() > 0)
													{
														num6 += list2.Count;
													}
												}
												if (num6 <= 0)
												{
													base.ViewBag.Error = Messages.msgErrorDeActiveLoginWithoutShift;
													return View(login);
												}
											}
											if (!result6)
											{
												base.ViewBag.DeActiveSmartTimeAttendance = result4;
												if (result3)
												{
													bool flag4 = true;
													ObjectParameter objectParameter = new ObjectParameter("ShowLogin", true);
													Enumerable.FirstOrDefault<bool?>((IEnumerable<bool?>)_dbII.CRMspReturnUserDailyTimeAttendance(_003C_003Ec__DisplayClass7_.user.UserId, DateTime.Now, result2, result2, objectParameter));
													if (objectParameter != null && objectParameter.Value.ToString().ToLower().Trim() == "false")
													{
														flag4 = false;
													}
													if (flag4)
													{
														string text5 = new RandomText().CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
														Uri url = base.HttpContext.Request.Url;
														text5 = text5 + "|**|" + url.Scheme + "://" + url.Authority;
														UserLoginSmartTimeAttendance.Update(_003C_003Ec__DisplayClass7_.user.UserId, "", text5, "");
														string text6 = CRMIdeal.Classes.Helper.User.CodeQRBarcode(text5);
														base.ViewBag.QRCodeStr = text6;
														GetUserShiftWorkingTimeByDate(_003C_003Ec__DisplayClass7_.user.UserId);
														base.ViewBag.UserId = _003C_003Ec__DisplayClass7_.user.UserId.ToString();
														return View(login);
													}
												}
											}
										}
										LoginUserSmartTimeAttendanceViewModel loginUserSmartTimeAttendanceViewModel = UserLoginSmartTimeAttendance.Get(_003C_003Ec__DisplayClass7_.user.UserId);
										UserLoginSmartTimeAttendance.Clear(_003C_003Ec__DisplayClass7_.user.UserId);
										int num8 = 0;
										string tmEntryLat = null;
										string tmEntryLng = null;
										double? tmEntryZoom = null;
										string text7 = "";
										if (loginUserSmartTimeAttendanceViewModel != null)
										{
											string smartTimeAttendanceParamJson = loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceParamJson;
											string obj3 = loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceQRCode ?? "";
											string text8 = "";
											if (!string.IsNullOrWhiteSpace(smartTimeAttendanceParamJson))
											{
												ParamViewModel paramViewModel = JsonConvert.DeserializeObject<ParamViewModel>(smartTimeAttendanceParamJson);
												num8 = paramViewModel.Mode.GetValueOrDefault();
												text7 = paramViewModel.SDomain ?? "";
												text8 = paramViewModel.KeyValue ?? "";
												tmEntryLat = ((paramViewModel.Lat.GetValueOrDefault() > 0.0) ? paramViewModel.Lat.ToString() : null);
												tmEntryLng = ((paramViewModel.Lng.GetValueOrDefault() > 0.0) ? paramViewModel.Lng.ToString() : null);
												tmEntryZoom = paramViewModel.Zoom;
											}
											if (obj3 == text8)
											{
												bool flag5 = false;
												if (login.LeaveId.GetValueOrDefault() == 0)
												{
													flag5 = true;
												}
												else
												{
													CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(_003C_003Ec__DisplayClass7_.user.UserId, login.LeaveId, null, -1, null, null, null, result2, null, _003C_003Ec__DisplayClass7_.user.UserLastCId));
													if (cRMspSelectLeave_Result != null && (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 1 || cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 2))
													{
														flag5 = true;
													}
												}
												if (flag5 && text7 != "")
												{
													string text9 = SysSeting.Get().LoginAuthUrl ?? "";
													if (!string.IsNullOrWhiteSpace(text9) && !text9.Contains(text7))
													{
														base.ViewBag.Error = Messages.MobMsgErrorNotInLoginAuthUrl;
														base.ViewBag.ReturnUrl = ReturnUrl;
														login.InactiveSaveTimeAttendance = null;
														login.CheckedTimeAttendance = null;
														LoginActivity.Remove(_003C_003Ec__DisplayClass7_.user.UserId);
														base.ViewBag.LoginActivityJs = JsonConvert.SerializeObject(LoginActivity.Get());
														return View(login);
													}
												}
											}
										}
										if (_003C_003Ec__DisplayClass7_.user.UserLastCId.GetValueOrDefault() == 0)
										{
											CRMIdeal.Classes.Helper.User.UpdateUserLastCIdForFirst(_003C_003Ec__DisplayClass7_.user.UserId, _003C_003Ec__DisplayClass7_.user.UserCIds);
										}
										int num9 = (login.RememberMe ? Configuration.CacheDefaultTimeInMinutes : Configuration.MinimumTimeoutLoginInMin);
										FormsAuthenticationTicket val3 = new FormsAuthenticationTicket(_003C_003Ec__DisplayClass7_.user.UserId.ToString(), login.RememberMe, num9);
										Info.Update(_003C_003Ec__DisplayClass7_.user.UserId, true);
										Permissions.Update(_003C_003Ec__DisplayClass7_.user.UserId, _003C_003Ec__DisplayClass7_.user.UserLastCId);
										Alarms.Update(_003C_003Ec__DisplayClass7_.user.UserId, _003C_003Ec__DisplayClass7_.user.UserLastCId);
										CRMIdeal.Cache.User.Language.Update(_003C_003Ec__DisplayClass7_.user.UserId);
										UpdateModuleInSysSetting();
										Manager.UpdateAllSettingCach();
										LoginCount.Update(LoginCountType.Plus, _003C_003Ec__DisplayClass7_.user.UserId);
										string text10 = now.ToString("yyyyMMdd", new PersianCulture());
										short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
										short value4 = short.Parse(Financial.Get().Id.ToString());
										_db.CrmspInsertUsersNoteForFirstTime(_003C_003Ec__DisplayClass7_.user.UserId, value4, value3, text10, Configuration.AppType, result2);
										string text11 = FormsAuthentication.Encrypt(val3);
										HttpCookie val4 = new HttpCookie(FormsAuthentication.FormsCookieName, text11);
										val4.Expires = now.AddMinutes(num9);
										val4.HttpOnly = true;
										httpContext.Response.Cookies.Add(val4);
										if (!result6)
										{
											if (!result3)
											{
												_db.CRMspRegisterDailyTimeAttendance(1, text10, _003C_003Ec__DisplayClass7_.user.UserId, httpContext.Request.UserHostAddress, Configuration.AppType, result2);
											}
											else
											{
												bool flag6 = true;
												ObjectParameter objectParameter2 = new ObjectParameter("ShowLogin", true);
												Enumerable.FirstOrDefault<bool?>((IEnumerable<bool?>)_dbII.CRMspReturnUserDailyTimeAttendance(_003C_003Ec__DisplayClass7_.user.UserId, DateTime.Now, result2, result2, objectParameter2));
												if (objectParameter2 != null && objectParameter2.Value.ToString().ToLower().Trim() == "false")
												{
													flag6 = false;
												}
												if (flag6)
												{
													_dbII.CRMspTimeAttendanceEntry(login.ShiftWorkingTimeId, login.LeaveId, login.LeaveStepIds, httpContext.Request.UserHostAddress, _003C_003Ec__DisplayClass7_.user.UserId, now, text10, _003C_003Ec__DisplayClass7_.user.UserId, now, text10, value3, value4, Configuration.AppType, result2, result2, login.ClearTimeAttendanceIds, tmEntryLat, tmEntryLng, tmEntryZoom, (num8 == 0) ? null : new bool?(true));
												}
												_dbI.CRMspInsertTimeAttendanceLog(1, _003C_003Ec__DisplayClass7_.user.UserId, httpContext.Request.UserHostAddress, Configuration.AppType, result2);
											}
										}
										else
										{
											_dbI.CRMspInsertTimeAttendanceLog(1, _003C_003Ec__DisplayClass7_.user.UserId, httpContext.Request.UserHostAddress, Configuration.AppType, result2);
										}
										List<CRMspSelectUserLanguages_Result> list3 = CRMIdeal.Cache.User.Language.Get(_003C_003Ec__DisplayClass7_.user.UserId);
										string lang = "fa-IR";
										if (list3.Count <= 1)
										{
											CRMspSelectUserLanguages_Result cRMspSelectUserLanguages_Result = Enumerable.FirstOrDefault<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list3);
											if (cRMspSelectUserLanguages_Result != null)
											{
												lang = cRMspSelectUserLanguages_Result.LanguageCollation;
											}
											base.Session["Culture"] = new CultureInfo(lang);
											HttpCookie val5 = (HttpCookie)(((object)httpContext.Request.Cookies["CurrentLanguage"]) ?? ((object)new HttpCookie("CurrentLanguage")));
											val5.Value = lang;
											val5.Expires = DateTime.MaxValue;
											httpContext.Response.Cookies.Add(val5);
										}
										else if (httpContext.Request.Cookies["CurrentLanguage"] != null)
										{
											HttpCookie val6 = httpContext.Request.Cookies["CurrentLanguage"];
											lang = val6.Value;
											List<CRMspSelectUserLanguages_Result> list4 = CRMIdeal.Cache.User.Language.Get(_003C_003Ec__DisplayClass7_.user.UserId);
											if (!Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list4, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageCollation.ToLower() == lang.ToLower())))
											{
												val6.Value = Enumerable.FirstOrDefault<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list4).LanguageCollation;
												val6.Expires = DateTime.MaxValue;
												httpContext.Response.Cookies.Add(val6);
											}
										}
										System.Guid? currGuid = null;
										bool flag7 = LoginActivity.Update(_003C_003Ec__DisplayClass7_.user.UserId, autoAdd: true, out currGuid, generateNewGuid: true);
										if (currGuid.HasValue)
										{
											HttpCookie val7 = new HttpCookie("CrmIdealLoginAuth", currGuid.ToString());
											httpContext.Request.Cookies.Add(val7);
											httpContext.Response.Cookies.Add(val7);
										}
										else if (flag7)
										{
											_ = currGuid.HasValue;
										}
										DoneEvents(_003C_003Ec__DisplayClass7_.user.UserId, httpContext);
										if (_003C_003Ec__DisplayClass7_.user.UserId != 0)
										{
											DateTime now2 = DateTime.Now;
											new CRMIdeal.Areas.Leave.Controllers.HomeController().ActExecuteLeave(0, 0, _003C_003Ec__DisplayClass7_.user.UserId.ToString(), now2, now2, _003C_003Ec__DisplayClass7_.user.UserId);
										}
										if (!string.IsNullOrEmpty(ReturnUrl))
										{
											return Redirect(ReturnUrl);
										}
										return Redirect(FormsAuthentication.DefaultUrl);
									}
									string text12 = "";
									if (cRMspCheckUserLoginAllowedTimes_Result != null)
									{
										string[] array5 = cRMspCheckUserLoginAllowedTimes_Result.Reason.Split(new char[1] { ',' });
										foreach (string text13 in array5)
										{
											if (!(text13.Trim() != ""))
											{
												continue;
											}
											switch (text13.Trim().ToLower())
											{
											case "date":
												if (text12.Trim() != "")
												{
													text12 += "، ";
												}
												text12 += Messages.msgErrorNotPermissionLoginInDate;
												break;
											case "day":
												if (text12.Trim() != "")
												{
													text12 += "، ";
												}
												text12 += Messages.msgErrorNotPermissionLoginInDay;
												break;
											case "time":
												if (text12.Trim() != "")
												{
													text12 += "، ";
												}
												text12 += Messages.msgErrorNotPermissionLoginInTime;
												break;
											case "ipaddress":
												if (text12.Trim() != "")
												{
													text12 += "، ";
												}
												text12 += Messages.msgErrorNotPermissionLoginWithIP;
												break;
											}
										}
									}
									else
									{
										text12 = Messages.msgErrorNotPermissionLogin;
									}
									base.ViewBag.Error = text12;
									base.ViewBag.ReturnUrl = ReturnUrl;
									return View(login);
								}
								}
							}
							base.ViewBag.Error = Messages.msgErrorLoginNotDefineUserName;
							base.ViewBag.ReturnUrl = ReturnUrl;
							return View(login);
						}
						base.ViewBag.Error = Messages.msgErrorHaveNotAccessUseWebApp;
						base.ViewBag.ReturnUrl = ReturnUrl;
						return View(login);
					}
					base.ViewBag.Error = Messages.msgErrorCheckUsernamePassword;
				}
				else if (string.IsNullOrEmpty(text3))
				{
					base.ViewBag.Error = Messages.msgErrorContrastVersion + "<br/>" + Messages.msgErrorContrastVersion1 + "<br/>" + VersionConfig.CurrentVerWin + "&ne;" + text2;
				}
				else
				{
					base.ViewBag.Error = text3;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			string message = ex.Message;
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				message = ex.InnerException.Message;
			}
			base.ViewBag.Error = Labels.Error + ": " + message;
		}
		base.ModelState.AddModelError("", Messages.LoginNotSuccess);
		base.ViewBag.ReturnUrl = ReturnUrl;
		return View(login);
	}

	public void GetLoginCustomHtml()
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		string text5 = "";
		try
		{
			CRMspSelectsysFormHtmlWithFormName_Result cRMspSelectsysFormHtmlWithFormName_Result = Enumerable.FirstOrDefault<CRMspSelectsysFormHtmlWithFormName_Result>((IEnumerable<CRMspSelectsysFormHtmlWithFormName_Result>)_dbII.CRMspSelectsysFormHtmlWithFormName("frmLogin", 0, 0));
			if (cRMspSelectsysFormHtmlWithFormName_Result != null)
			{
				text = cRMspSelectsysFormHtmlWithFormName_Result.FormHTML;
				text2 = cRMspSelectsysFormHtmlWithFormName_Result.FormCSS;
				text3 = cRMspSelectsysFormHtmlWithFormName_Result.FormRep;
				text4 = cRMspSelectsysFormHtmlWithFormName_Result.FormJS;
				text5 = cRMspSelectsysFormHtmlWithFormName_Result.FormJSTop;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.HTML = text;
		base.ViewBag.CSS = text2;
		base.ViewBag.Rep = text3;
		base.ViewBag.JS = text4;
		base.ViewBag.JSTop = text5;
	}

	[HttpPost]
	public bool SetUserLogOut(int userId = 0)
	{
		bool flag = false;
		try
		{
			if (userId > 0)
			{
				flag = LoginActivity.Remove(userId);
				if (flag)
				{
					Manager.ClearAllUserCach(userId);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return flag;
	}

	public ActionResult SignOut()
	{
		return View();
	}

	public ActionResult Logout(int xit = 0)
	{
		base.ViewBag.Xit = xit;
		return View();
	}

	[HttpPost]
	public ActionResult LogOff(int xit = 0)
	{
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected O, but got Unknown
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int result2 = 0;
		if (base.Request.Cookies["LoginType"] != null)
		{
			int.TryParse(base.Request.Cookies["LoginType"].Value, out result2);
		}
		if (xit == 1)
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			bool result3 = false;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				bool.TryParse(cRMspSelectCrmsysSetting_Result.SmartTimeAttendance.ToString(), out result3);
			}
			if (!result3)
			{
				string tmDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				_db.CRMspRegisterDailyTimeAttendance(2, tmDatePersian, UserLogin.CurrentUser.UserId, base.Request.UserHostAddress, Configuration.AppType, result);
			}
		}
		else
		{
			_dbI.CRMspInsertTimeAttendanceLog(2, UserLogin.CurrentUser.UserId, base.Request.UserHostAddress, Configuration.AppType, result);
		}
		if (base.HttpContext.User != null)
		{
			base.Response.Cookies.Remove("CrmIdealLoginAuth");
			base.Request.Cookies.Remove("CrmIdealLoginAuth");
			LoginActivity.Remove();
			LoginCount.Update(LoginCountType.Minus);
			Manager.ClearAllUserCach();
		}
		base.Response.Cookies.Clear();
		FormsAuthentication.SignOut();
		base.HttpContext.User = (IPrincipal)new GenericPrincipal((IIdentity)new GenericIdentity(string.Empty), (string[])null);
		Thread.CurrentPrincipal = null;
		HttpCookie val = new HttpCookie(FormsAuthentication.FormsCookieName, "");
		val.Expires = DateTime.Now.AddYears(-1);
		base.Response.Cookies.Add(val);
		HttpCookie val2 = new HttpCookie("ASP.NET_SessionId", "");
		val2.Expires = DateTime.Now.AddYears(-1);
		base.Response.Cookies.Add(val2);
		Roles.DeleteCookie();
		base.Session.Clear();
		base.Session.Abandon();
		base.Response.Cache.SetExpires(DateTime.Now.AddYears(-1));
		base.Response.Cache.SetCacheability((HttpCacheability)1);
		FormsAuthentication.RedirectToLoginPage();
		if (result2 == 3)
		{
			HttpCookie val3 = new HttpCookie("LoginType");
			val3.Value = "";
			val3.Expires = DateTime.Now.AddYears(-1);
			base.Response.Cookies.Add(val3);
			return RedirectToAction("KaramadLogout", "OtherSystemsLogin");
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	public ActionResult LogOffI(int forceExit = 1)
	{
		try
		{
			string value = base.Request.Cookies.Get("CrmIdealLoginAuth").Value;
			string text = LoginActivity.GetCurrentUserActivity().CurrGuid.ToString();
			if (value == text)
			{
				return LogOff();
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}

	private bool TimeBetween(TimeSpan now, TimeSpan start, TimeSpan end)
	{
		if (start < end)
		{
			if (start <= now)
			{
				return now <= end;
			}
			return false;
		}
		if (end < now)
		{
			return !(now < start);
		}
		return true;
	}

	[AjaxOnly]
	public string UpdateCurrentUserCache()
	{
		string result = Messages.UpdateFaild;
		try
		{
			bool? fromLoginPage = true;
			Info.Update(null, fromLoginPage);
			Permissions.Update();
			Alarms.Update();
			CRMIdeal.Cache.User.Language.Update();
			Manager.UpdateAllSettingCach();
			result = "";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string GetAlaramQueryAfterUpdateCurrentUserCache()
	{
		string text = "";
		try
		{
			CultureInfo.CurrentCulture.ClearCachedData();
			foreach (CRMspLoadRemindingTask_Result item in Alarms.Get(UserLogin.CurrentUser.UserId))
			{
				if (text.Trim() != "")
				{
					text += "@";
				}
				text = text + item.Type + "|" + item.UserTaskId + "|" + item.UserTaskTitle + "|" + item.UserTaskTime + "|" + item.UserTaskDatePersian + "|" + item.UserTaskRemindTime + "|" + item.UserTaskRemindDate + "|" + item.Val1 + "|" + item.Val2 + "|" + item.Val3 + "|" + item.UserTaskDate.ToString() + "|" + item.UserTaskRemindDateTime.ToString() + "|" + ((item.IsRecurringTask != false) ? 1 : 0);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[LoginAuthorize]
	public ActionResult CheckLogin()
	{
		return View();
	}

	[HttpPost]
	[AllowAnonymous]
	[ValidateAntiForgeryToken]
	public ActionResult CheckLogin(LoginViewModel login)
	{
		try
		{
			if (UserLogin.CurrentUser == null)
			{
				base.ViewBag.Error = Messages.ErrorNotAccess;
				return View(login);
			}
			if (base.ModelState.IsValid)
			{
				string text = new BaseInfo().ConvertMd5(login.Password).ToLower();
				CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
				if (!(login.UserName == currentUser.UserName) || !(text == currentUser.Password))
				{
					base.ViewBag.Error = Messages.msgErrorPasswordIsWrong;
				}
				else
				{
					base.ViewBag.Successful = "True";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(login);
	}

	public bool CheckCompanyAppInfo()
	{
		bool flag = true;
		int num = 1;
		int num2 = 15;
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (!string.IsNullOrEmpty(value))
			{
				int num3 = int.Parse(DateTime.Now.ToString("dd", new PersianCulture()));
				if ((num3 == num || num3 == num2) && LoadValidationFile())
				{
					int date = 0;
					IsValidationFile(ref date);
					int num4 = int.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
					if (date != num4)
					{
						RemoveValidationFile();
					}
				}
				if ((num3 == num || num3 == num2) && !LoadValidationFile())
				{
					string url = "";
					if (base.HttpContext.Request.Url != null)
					{
						url = base.HttpContext.Request.Url.Authority.ToLower().Replace("www.", "");
					}
					HttpClient obj = new HttpClient
					{
						BaseAddress = new Uri(apiUri),
						DefaultRequestHeaders = 
						{
							Accept = 
							{
								new MediaTypeWithQualityHeaderValue("application/json")
							}
						}
					};
					StringContent content = new StringContent(JsonConvert.SerializeObject(new CheckCompanyAppInfoViewModel
					{
						RegisterCode = value,
						Url = url
					}), Encoding.UTF8, "application/json");
					HttpResponseMessage result = obj.PostAsync("api/WebSystem/CheckCompanyAppInfo", content).Result;
					if (result.IsSuccessStatusCode)
					{
						CommonReturnBoolResultApiViewModel commonReturnBoolResultApiViewModel = JsonConvert.DeserializeObject<CommonReturnBoolResultApiViewModel>(result.Content.ReadAsStringAsync().Result);
						if (commonReturnBoolResultApiViewModel.Status == "Success")
						{
							flag = commonReturnBoolResultApiViewModel.Data;
							SaveValidationFile(flag);
						}
					}
				}
				else
				{
					int date2 = 0;
					flag = IsValidationFile(ref date2);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return flag;
	}

	public void ResetValidationFile()
	{
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			string url = "";
			if (base.HttpContext.Request.Url != null)
			{
				url = base.HttpContext.Request.Url.Authority.ToLower().Replace("www.", "");
			}
			HttpClient obj = new HttpClient
			{
				BaseAddress = new Uri(apiUri),
				DefaultRequestHeaders = 
				{
					Accept = 
					{
						new MediaTypeWithQualityHeaderValue("application/json")
					}
				}
			};
			StringContent content = new StringContent(JsonConvert.SerializeObject(new CheckCompanyAppInfoViewModel
			{
				RegisterCode = value,
				Url = url
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage result = obj.PostAsync("api/WebSystem/CheckCompanyAppInfo", content).Result;
			if (result.IsSuccessStatusCode)
			{
				CommonReturnBoolResultApiViewModel commonReturnBoolResultApiViewModel = JsonConvert.DeserializeObject<CommonReturnBoolResultApiViewModel>(result.Content.ReadAsStringAsync().Result);
				if (commonReturnBoolResultApiViewModel.Status == "Success")
				{
					RemoveValidationFile();
					SaveValidationFile(commonReturnBoolResultApiViewModel.Data);
				}
			}
			else
			{
				SaveValidationFile(isValid: true);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public bool SaveValidationFile(bool isValid)
	{
		bool result = false;
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (!string.IsNullOrEmpty(value))
			{
				string getString = value.Substring(0, 5) + "CmpAppInfo" + value.Substring(value.Length - 5, 5);
				getString = CodeDecode.RegCodding(getString);
				string text = getString.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				string text2 = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\";
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				string path = text2 + text + ".dat";
				if (!System.IO.File.Exists(path))
				{
					using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
					{
						getString = getString + "-|-" + CodeDecode.RegCodding(isValid.ToString()) + "-|-" + CodeDecode.RegCodding(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
						getString = CodeDecode.RegCodding(getString);
						byte[] bytes = Encoding.Unicode.GetBytes(getString);
						fileStream.Write(bytes, 0, bytes.Length);
					}
					result = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public bool IsValidationFile(ref int date)
	{
		bool result = false;
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (!string.IsNullOrEmpty(value))
			{
				string getString = value.Substring(0, 5) + "CmpAppInfo" + value.Substring(value.Length - 5, 5);
				getString = CodeDecode.RegCodding(getString).Replace("/", "").Replace("-", "")
					.Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				string path = string.Concat(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\", getString, ".dat");
				if (System.IO.File.Exists(path))
				{
					string text = System.IO.File.ReadAllText(path);
					if (text != null && text != "")
					{
						text = text.Replace("\0", "");
						text = CodeDecode.RegDeCodding(text);
						string[] array = text.Split(new string[1] { "-|-" }, StringSplitOptions.None);
						if (array.Length == 3)
						{
							result = bool.Parse(CodeDecode.RegDeCodding(array[1]));
							string s = CodeDecode.RegDeCodding(array[2]);
							date = int.Parse(s);
						}
					}
				}
				else
				{
					result = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public bool LoadValidationFile()
	{
		bool result = false;
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (!string.IsNullOrEmpty(value))
			{
				string getString = value.Substring(0, 5) + "CmpAppInfo" + value.Substring(value.Length - 5, 5);
				getString = CodeDecode.RegCodding(getString).Replace("/", "").Replace("-", "")
					.Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				result = System.IO.File.Exists(string.Concat(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\", getString, ".dat"));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void RemoveValidationFile()
	{
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (!string.IsNullOrEmpty(value))
			{
				string getString = value.Substring(0, 5) + "CmpAppInfo" + value.Substring(value.Length - 5, 5);
				getString = CodeDecode.RegCodding(getString).Replace("/", "").Replace("-", "")
					.Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				string path = string.Concat(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\", getString, ".dat");
				if (System.IO.File.Exists(path))
				{
					System.IO.File.Delete(path);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public bool CheckValidateLockSerial(ref string date)
	{
		bool result = true;
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (value != null)
			{
				if (!string.IsNullOrEmpty(CodeDecode.RegDeCodding(CodeDecode.RegDeCodding(value).Split(new char[1] { '|' })[0].Split(new char[1] { '@' })[1])))
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					DateTime now = DateTime.Now;
					int.Parse(now.ToString("dd", new PersianCulture()));
					_ = DateTime.Now;
					_ = DateTime.Now;
					string text = now.AddDays(-10.0).ToString("yyyyMMdd");
					string text2 = now.ToString("yyyyMMdd");
					if (!string.IsNullOrEmpty(text))
					{
						DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " 00:00:00", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
					if (!string.IsNullOrEmpty(text2))
					{
						DateTime.Parse(PersianDate.GetFormatetdDate(text2.Replace("/", "")) + " 23:59:59", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
				}
				else
				{
					Exception e = new Exception("Different lock Serial in Security Code!");
					ErrorSignal.FromCurrentContext().Raise(e);
					result = false;
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	public bool ResetValidLockSerialFile()
	{
		bool result = true;
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (value != null)
			{
				if (!string.IsNullOrEmpty(CodeDecode.RegDeCodding(CodeDecode.RegDeCodding(value).Split(new char[1] { '|' })[0].Split(new char[1] { '@' })[1])))
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					DateTime now = DateTime.Now;
					_ = DateTime.Now;
					_ = DateTime.Now;
					string text = now.AddDays(-10.0).ToString("yyyyMMdd");
					string text2 = now.ToString("yyyyMMdd");
					if (!string.IsNullOrEmpty(text))
					{
						DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " 00:00:00", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
					if (!string.IsNullOrEmpty(text2))
					{
						DateTime.Parse(PersianDate.GetFormatetdDate(text2.Replace("/", "")) + " 23:59:59", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
				}
				else
				{
					Exception e = new Exception("Different lock Serial in Security Code!");
					ErrorSignal.FromCurrentContext().Raise(e);
					result = false;
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	public bool SaveInvalidLockSerialFile(bool isValid, DateTime date)
	{
		bool result = false;
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (!string.IsNullOrEmpty(value))
			{
				string getString = value.Substring(0, 5) + "CmpAppInfo" + value.Substring(value.Length - 5, 5);
				getString = CodeDecode.RegCodding(getString);
				string text = getString.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				string text2 = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\";
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				string path = text2 + text + ".dat";
				if (!System.IO.File.Exists(path))
				{
					using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
					{
						getString = getString + "-|-" + CodeDecode.RegCodding(isValid.ToString()) + "-|-" + CodeDecode.RegCodding(DateTime.Now.ToString("yyyyMMdd", new PersianCulture())) + "-|-" + CodeDecode.RegCodding(date.ToString("yyyy/MM/dd HH:mm:ss"));
						getString = CodeDecode.RegCodding(getString);
						byte[] bytes = Encoding.Unicode.GetBytes(getString);
						fileStream.Write(bytes, 0, bytes.Length);
					}
					result = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public bool LoadInvalidLockSerialFile(ref DateTime date)
	{
		bool flag = false;
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (!string.IsNullOrEmpty(value))
			{
				string getString = value.Substring(0, 5) + "CmpAppInfo" + value.Substring(value.Length - 5, 5);
				getString = CodeDecode.RegCodding(getString).Replace("/", "").Replace("-", "")
					.Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				string path = string.Concat(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\", getString, ".dat");
				flag = System.IO.File.Exists(path);
				if (flag)
				{
					string text = System.IO.File.ReadAllText(path);
					if (text != null && text != "")
					{
						text = text.Replace("\0", "");
						text = CodeDecode.RegDeCodding(text);
						string[] array = text.Split(new string[1] { "-|-" }, StringSplitOptions.None);
						if (array.Length == 4)
						{
							string text2 = CodeDecode.RegDeCodding(array[3]);
							if (!string.IsNullOrEmpty(text2))
							{
								try
								{
									date = DateTime.Parse(text2);
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
									date = DateTime.Now;
								}
							}
						}
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return flag;
	}

	public void RemoveInvalidLockSerialFile()
	{
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (!string.IsNullOrEmpty(value))
			{
				string getString = value.Substring(0, 5) + "CmpAppInfo" + value.Substring(value.Length - 5, 5);
				getString = CodeDecode.RegCodding(getString).Replace("/", "").Replace("-", "")
					.Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				string path = string.Concat(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\", getString, ".dat");
				if (System.IO.File.Exists(path))
				{
					System.IO.File.Delete(path);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void CheckClientValidation()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			string value2 = ApplicationSettings.GetValue("ClientValidationUrl");
			if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value2))
			{
				return;
			}
			if (int.Parse(DateTimeClass.DefineDayeOfWeekStartWith7(DateTime.Now.ToString("dddd", new CultureInfo("en-US")))) == 2)
			{
				if (LoadClientCalidationFile())
				{
					return;
				}
				string text = "";
				string text2 = "";
				ManagementObjectEnumerator enumerator = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ManagementBaseObject current = enumerator.Current;
						if ((bool)current["IPEnabled"])
						{
							text2 = current["MacAddress"].ToString();
							if (text2 != "::1")
							{
								break;
							}
						}
						current.Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				text = text2;
				string clientCoName = "";
				string clientLockSerial = "";
				string text3 = "";
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)_db.CRMspSelectCrmsysSetting(Thread.CurrentThread.CurrentCulture.LCID, 1065));
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					clientCoName = cRMspSelectCrmsysSetting_Result.CoName ?? "";
					clientLockSerial = cRMspSelectCrmsysSetting_Result.LockSerial ?? "";
				}
				text3 = VersionConfig.CurrentVerWeb;
				HttpClient obj = new HttpClient
				{
					BaseAddress = new Uri(value2),
					DefaultRequestHeaders = 
					{
						Accept = 
						{
							new MediaTypeWithQualityHeaderValue("application/json")
						}
					}
				};
				StringContent content = new StringContent(JsonConvert.SerializeObject(new ClientValidationViewModel
				{
					ClientCoName = clientCoName,
					ClientUrl = text,
					ClientLockSerial = clientLockSerial,
					ClientSoftVersion = text3,
					ClientRegisterCode = value
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage result = obj.PostAsync("api/WebSystem/ClientValidation", content).Result;
				if (result.IsSuccessStatusCode)
				{
					ClientValidationResultViewModel clientValidationResultViewModel = JsonConvert.DeserializeObject<ClientValidationResultViewModel>(result.Content.ReadAsStringAsync().Result);
					if (clientValidationResultViewModel != null)
					{
						if (!(clientValidationResultViewModel.Status == "Success"))
						{
							return;
						}
						if (clientValidationResultViewModel.Data != null)
						{
							if ((clientValidationResultViewModel.Data.ClientInActive.HasValue && clientValidationResultViewModel.Data.ClientInActive.GetValueOrDefault()) ? true : false)
							{
								_003C_003Ec__DisplayClass32_0 _003C_003Ec__DisplayClass32_ = new _003C_003Ec__DisplayClass32_0();
								_003C_003Ec__DisplayClass32_.sysProject = Enumerable.FirstOrDefault<CRMspSelectSystemCrmProject_Result>((IEnumerable<CRMspSelectSystemCrmProject_Result>)_db.CRMspSelectSystemCrmProject());
								if (_003C_003Ec__DisplayClass32_.sysProject != null)
								{
									DbSet<Projects> projects = _dbTbl.Projects;
									ParameterExpression val = Expression.Parameter(typeof(Projects), "c");
									Projects projects2 = Queryable.FirstOrDefault<Projects>((IQueryable<Projects>)projects, Expression.Lambda<Func<Projects, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass32_, typeof(_003C_003Ec__DisplayClass32_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (projects2 != null)
									{
										projects2.Description = "ClientInActive";
										_dbTbl.Entry(projects2).State = EntityState.Modified;
										_dbTbl.Configuration.ValidateOnSaveEnabled = false;
										_dbTbl.SaveChanges();
										_dbTbl.Configuration.ValidateOnSaveEnabled = true;
									}
								}
							}
							SaveClientCalidationFile();
						}
						else
						{
							Exception e = new Exception("error in get info from clientValidation");
							ErrorSignal.FromCurrentContext().Raise(e);
						}
					}
					else
					{
						Exception e2 = new Exception("error in get resultApi from clientValidation");
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
				}
				else
				{
					Exception e3 = new Exception("error in get response from clientValidation");
					ErrorSignal.FromCurrentContext().Raise(e3);
				}
			}
			else
			{
				RemoveClientCalidationFile();
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
		}
	}

	public bool SaveClientCalidationFile()
	{
		bool result = false;
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (!string.IsNullOrEmpty(value))
			{
				string getString = value.Substring(0, 5) + "CmpAppInfo" + value.Substring(value.Length - 5, 5);
				getString = CodeDecode.RegCodding(getString);
				string text = getString.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				string text2 = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\";
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				string path = text2 + text + ".dat";
				if (!System.IO.File.Exists(path))
				{
					using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
					{
						getString = getString + "checkClientValid in date: " + DateTime.Now;
						getString = CodeDecode.RegCodding(getString);
						byte[] bytes = Encoding.Unicode.GetBytes(getString);
						fileStream.Write(bytes, 0, bytes.Length);
					}
					result = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public bool LoadClientCalidationFile()
	{
		bool result = false;
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (!string.IsNullOrEmpty(value))
			{
				string getString = value.Substring(0, 5) + "CmpAppInfo" + value.Substring(value.Length - 5, 5);
				getString = CodeDecode.RegCodding(getString).Replace("/", "").Replace("-", "")
					.Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				result = System.IO.File.Exists(string.Concat(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\", getString, ".dat"));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void RemoveClientCalidationFile()
	{
		try
		{
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (!string.IsNullOrEmpty(value))
			{
				string getString = value.Substring(0, 5) + "CmpAppInfo" + value.Substring(value.Length - 5, 5);
				getString = CodeDecode.RegCodding(getString).Replace("/", "").Replace("-", "")
					.Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				string path = string.Concat(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\", getString, ".dat");
				if (System.IO.File.Exists(path))
				{
					System.IO.File.Delete(path);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public JsonResult CheckSmartTimeAttendance(int userId, string qrCode)
	{
		bool data = false;
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Fail;
		try
		{
			if (userId != 0 && !string.IsNullOrWhiteSpace(qrCode))
			{
				LoginUserSmartTimeAttendanceViewModel loginUserSmartTimeAttendanceViewModel = UserLoginSmartTimeAttendance.Get(userId);
				if (loginUserSmartTimeAttendanceViewModel != null)
				{
					qrCode = CRMIdeal.Classes.Helper.User.DecodeQRBarcode(qrCode);
					if (qrCode.Contains("|**|"))
					{
						_ = qrCode.Split(new string[1] { "|**|" }, StringSplitOptions.None)[1];
						qrCode = qrCode.Split(new string[1] { "|**|" }, StringSplitOptions.None)[0];
					}
					string text = loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceQRCode ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						if (text == qrCode)
						{
							data = true;
							message = Messages.msgSuccessAction;
							status = CommonResultStatusViewModel.Success;
						}
						else
						{
							UserLoginSmartTimeAttendance.Clear(userId);
							data = true;
							message = Messages.msgErrorInMatchBarcode;
							status = CommonResultStatusViewModel.Fail;
						}
					}
				}
			}
			else
			{
				message = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = false;
			status = CommonResultStatusViewModel.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		CommonResultViewModel<bool> data2 = new CommonResultViewModel<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	public JsonResult RefrechQRBarcode(int userId)
	{
		string data = "";
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Fail;
		try
		{
			if (userId != 0)
			{
				string text2 = new RandomText().CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
				Uri url = base.HttpContext.Request.Url;
				text2 = text2 + "|**|" + url.Scheme + "://" + url.Authority;
				UserLoginSmartTimeAttendance.Update(userId, "", text2, "");
				data = CRMIdeal.Classes.Helper.User.CodeQRBarcode(text2);
				text = Messages.msgSuccessAction;
				status = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
			data = "";
			status = CommonResultStatusViewModel.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		CommonResultViewModel<string> data2 = new CommonResultViewModel<string>
		{
			Message = text,
			Data = data,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ShowSmartTimeAttendanceWhenExit(int userId)
	{
		string data = "";
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Fail;
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (userId != 0 && currentUser != null)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				bool result = false;
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					bool.TryParse(cRMspSelectCrmsysSetting_Result.SmartTimeAttendance.ToString(), out result);
				}
				bool result2 = false;
				if (currentUser != null)
				{
					bool.TryParse(currentUser.DeActiveSmartTimeAttendance.ToString(), out result2);
				}
				string text2 = "";
				if (result)
				{
					bool flag = true;
					ObjectParameter objectParameter = new ObjectParameter("ShowLogin", true);
					Enumerable.FirstOrDefault<bool?>((IEnumerable<bool?>)_dbII.CRMspReturnUserDailyTimeAttendance(currentUser.UserId, DateTime.Now, null, null, objectParameter));
					if (objectParameter != null && objectParameter.Value.ToString().ToLower().Trim() == "false")
					{
						flag = false;
					}
					if (!flag)
					{
						text2 = new RandomText().CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
						Uri url = base.HttpContext.Request.Url;
						text2 = text2 + "|**|" + url.Scheme + "://" + url.Authority;
						UserLoginSmartTimeAttendance.Update(currentUser.UserId, "", text2, "");
					}
				}
				data = CRMIdeal.Classes.Helper.User.CodeQRBarcode(text2);
				text = Messages.msgSuccessAction;
				status = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
			data = "";
			status = CommonResultStatusViewModel.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		CommonResultViewModel<string> data2 = new CommonResultViewModel<string>
		{
			Message = text,
			Data = data,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	public void DoneEvents(int userId = 0, HttpContextBase httpContext = null)
	{
		try
		{
			if (httpContext == null)
			{
				httpContext = base.HttpContext;
			}
			List<WSspUpdateExpiredPreOrderStatus_Result> list = Enumerable.ToList<WSspUpdateExpiredPreOrderStatus_Result>((IEnumerable<WSspUpdateExpiredPreOrderStatus_Result>)_dbII.WSspUpdateExpiredPreOrderStatus());
			if (list != null && SysSeting.Get().LinkAccSystemId.GetValueOrDefault() == 21)
			{
				new OtherSystems.HamyarProvider(false).EbtalSefareshInHamyar(list);
			}
			_dbI.ScorespCalcAndUpdateIsExpired();
			UpdateSysSettingApiDomain(userId, httpContext);
			DeleteFilesInTemplateFolder(userId, httpContext);
			UpdateVoipCntInCISetting();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void UpdateVoipCntInCISetting()
	{
		try
		{
			CRMspSelectCrmsysCISetting_Result cRMspSelectCrmsysCISetting_Result = CISetting.Get();
			int result = 0;
			int result2 = 0;
			if (cRMspSelectCrmsysCISetting_Result != null)
			{
				string text = cRMspSelectCrmsysCISetting_Result.VoipCount ?? "";
				string text2 = cRMspSelectCrmsysCISetting_Result.VoipTrunkCount ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					text = CodeDecode.VoipDeCodding(text);
					int.TryParse(text, out result);
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					text2 = CodeDecode.VoipDeCodding(text2);
					int.TryParse(text2, out result2);
				}
			}
			int maxViopCount = Configuration.MaxViopCount;
			int maxViopTrunkCount = Configuration.MaxViopTrunkCount;
			bool flag = false;
			if (maxViopCount != result && maxViopCount > 0)
			{
				flag = true;
			}
			if (maxViopTrunkCount != result2 && maxViopTrunkCount > 0)
			{
				flag = true;
			}
			if (flag && cRMspSelectCrmsysCISetting_Result != null)
			{
				string voipCount = CodeDecode.VoipCodding(maxViopCount.ToString());
				string voipTrunkCount = CodeDecode.VoipCodding(maxViopTrunkCount.ToString());
				_dbII.CRMspUpdateSysCISettingVoipAndTrunkCount(cRMspSelectCrmsysCISetting_Result.Id, voipCount, voipTrunkCount, Configuration.AppType);
				CISetting.Update();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void UpdateModuleInSysSetting()
	{
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			bool result = false;
			bool result2 = false;
			bool result3 = false;
			bool result4 = false;
			bool result5 = false;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				bool.TryParse(cRMspSelectCrmsysSetting_Result.ServiceSIP.ToString(), out result);
				bool.TryParse(cRMspSelectCrmsysSetting_Result.ServiceSGIP.ToString(), out result2);
				bool.TryParse(cRMspSelectCrmsysSetting_Result.ServiceRIP.ToString(), out result3);
				bool.TryParse(cRMspSelectCrmsysSetting_Result.ServiceEmailIP.ToString(), out result4);
				bool.TryParse(cRMspSelectCrmsysSetting_Result.ServiceLetterIP.ToString(), out result5);
			}
			bool sMS = VersionBuyer.SMS;
			bool gSM = VersionBuyer.GSM;
			bool recorder = VersionBuyer.Recorder;
			bool emails = VersionBuyer.Emails;
			bool letters = VersionBuyer.Letters;
			bool flag = false;
			if (result != sMS)
			{
				flag = true;
			}
			if (result2 != gSM)
			{
				flag = true;
			}
			if (result3 != recorder)
			{
				flag = true;
			}
			if (result4 != emails)
			{
				flag = true;
			}
			if (result5 != letters)
			{
				flag = true;
			}
			if (flag)
			{
				CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
				if (crmsysSetting != null)
				{
					DateTime now = DateTime.Now;
					crmsysSetting.UserId = UserLogin.CurrentUser.UserId;
					crmsysSetting.RegisterDate = now;
					crmsysSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmsysSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					crmsysSetting.AppType = Configuration.AppType;
					crmsysSetting.ServiceSIP = sMS;
					crmsysSetting.ServiceSGIP = gSM;
					crmsysSetting.ServiceRIP = recorder;
					crmsysSetting.ServiceEmailIP = emails;
					crmsysSetting.ServiceLetterIP = letters;
					_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					SysSeting.Update();
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void UpdateSysSettingApiDomain(int userId, HttpContextBase httpContext = null)
	{
		if (httpContext == null)
		{
			httpContext = base.HttpContext;
		}
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			string value = "";
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				value = cRMspSelectCrmsysSetting_Result.ApiDomain ?? "";
			}
			DateTime now = DateTime.Now;
			DateTime value2 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value3 = short.Parse(Financial.Get().Id.ToString());
			short value4 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			string text = "";
			if (httpContext.Request.Url != null)
			{
				text = httpContext.Request.Url.Authority;
				string text2 = httpContext.Request.Url.Scheme.ToString();
				if (text.IndexOf(text2) < 0)
				{
					text2 = text2.Replace("://", "");
					text = text2 + "://" + text;
				}
			}
			if (!string.IsNullOrWhiteSpace(text) && userId != 0 && string.IsNullOrWhiteSpace(value))
			{
				_dbII.CRMspUpdateSysSettingApiDomain(text, userId, value2, registerDatePersian, value3, value4, appType);
				SysSeting.Update();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void DeleteFilesInTemplateFolder(int userId, HttpContextBase httpContext = null)
	{
		try
		{
			if (userId == 0)
			{
				return;
			}
			string text = Configuration.HostTempFilesPath + "/" + Configuration.DyFormFileTmpDirectoryPath + userId + "/";
			string path = httpContext.Server.MapPath(text);
			if (System.IO.Directory.Exists(path))
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				FileInfo[] files = directoryInfo.GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					files[i].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					directories[i].Delete(recursive: true);
				}
				System.IO.Directory.Delete(path);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[HttpPost]
	public string GetUserLeaves(int userId = 0, int timeAttendanceMode = 1)
	{
		List<CRMspSelectLeaveByDate_Result> value = new List<CRMspSelectLeaveByDate_Result>();
		try
		{
			if (userId != 0)
			{
				List<CRMspSelectLeaveByDate_Result> list = Enumerable.ToList<CRMspSelectLeaveByDate_Result>((IEnumerable<CRMspSelectLeaveByDate_Result>)Enumerable.OrderBy<CRMspSelectLeaveByDate_Result, string>((IEnumerable<CRMspSelectLeaveByDate_Result>)Enumerable.ToList<CRMspSelectLeaveByDate_Result>((IEnumerable<CRMspSelectLeaveByDate_Result>)_dbII.CRMspSelectLeaveByDate(userId: userId, date: DateTime.Now, timeAttendanceMode: timeAttendanceMode, languageID: Thread.CurrentThread.CurrentCulture.LCID, defaultLanguageID: SysSeting.Get().DefaultLanguageID)), (Func<CRMspSelectLeaveByDate_Result, string>)((CRMspSelectLeaveByDate_Result x) => x.FromTime)));
				if (list != null)
				{
					value = list;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[HttpPost]
	public string GetLeaveSteps(int leaveId = 0, int groupId = 0)
	{
		return JsonConvert.SerializeObject(new Leave().SelectLeaveStepsWithTimeAttendance(leaveId, groupId, DateTime.Now));
	}

	[HttpPost]
	public List<SelectListItem> GetUserShiftWorkingTimeByDate(int userId = 0, int? userShiftWorkingId = null, int timeAttendanceMode = 1)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectShiftWorkingTimeByDate_Result> list2 = Enumerable.ToList<CRMspSelectShiftWorkingTimeByDate_Result>((IEnumerable<CRMspSelectShiftWorkingTimeByDate_Result>)_dbII.CRMspSelectShiftWorkingTimeByDate(userId, DateTime.Now, userShiftWorkingId, 1, Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID));
			if (list2 != null)
			{
				bool flag = false;
				_ = DateTime.Now;
				string text = DateTime.Now.ToString("HH:mm");
				int num = int.Parse(text.Split(new char[1] { ':' })[0]) * 60 + int.Parse(text.Split(new char[1] { ':' })[1]);
				for (int i = 0; i < list2.Count; i++)
				{
					bool selected = false;
					if (!flag)
					{
						if (list2[i].EntryTimeMin != 0 && list2[i].ExitTimeMin != 0 && num >= list2[i].EntryTimeMin - 60 && num <= list2[i].ExitTimeMin + 60)
						{
							flag = true;
							selected = true;
						}
						else if (!(num >= list2[i].ExitTimeMin + list2[i].ExitTimeLateMin.GetValueOrDefault()))
						{
							flag = true;
							selected = true;
						}
					}
					list.Add(new SelectListItem
					{
						Text = list2[i].swtTitle + " - " + list2[i].EntryTime + " - " + list2[i].ExitTime,
						Value = list2[i].ShiftWorkingTimeId.ToString(),
						Selected = selected
					});
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.UserShiftWorkingTimes = list;
		return list;
	}

	[HttpPost]
	public List<CRMspSelectTimeAttendanceByLeaveDate_Result> SelectTimeAttendanceByLeaveDate(int userId = 0, string dtPersian = null)
	{
		List<CRMspSelectTimeAttendanceByLeaveDate_Result> result = new List<CRMspSelectTimeAttendanceByLeaveDate_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime? date = DateTimeClass.GetDateFromPersian(dtPersian);
			if (!date.HasValue)
			{
				date = DateTime.Now;
			}
			if (userId == 0 && UserLogin.CurrentUser != null)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			List<CRMspSelectTimeAttendanceByLeaveDate_Result> list = Enumerable.ToList<CRMspSelectTimeAttendanceByLeaveDate_Result>((IEnumerable<CRMspSelectTimeAttendanceByLeaveDate_Result>)_dbII.CRMspSelectTimeAttendanceByLeaveDate(date, userId, lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	public string SelectTimeAttendanceByLeaveDate_Json(int userId = 0, string dtPersian = null)
	{
		return JsonConvert.SerializeObject(SelectTimeAttendanceByLeaveDate(userId, dtPersian));
	}
}
