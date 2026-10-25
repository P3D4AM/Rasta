using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Accounts.Controllers;

public class UserLoginAllowedController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public UserLoginAllowedTimesViewModel viewmodel;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public UsersPermission user;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public Users usr;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int crmUserId;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actLoginAllowedTimes")]
	public ActionResult Index()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectActiveUsers_Result> list = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
		List<SelectListItem> list2 = new List<SelectListItem>();
		list2.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
		{
			Text = item.Name,
			Value = item.UserId.ToString(),
			Selected = false
		})));
		base.ViewBag.UserList = list2;
		return View();
	}

	public void SetUserNameDateForLoginAllowed(UserLoginAllowedTimesViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds((model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId) + "," + (model.RegisterUserId.HasValue ? model.RegisterUserId : new int?(UserLogin.CurrentUser.UserId)));
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.RegisterUserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text5 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text6 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text7 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text5 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text7 + ") (" + text6 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actLoginAllowedTimes")]
	public ActionResult InsertEdit(int crmUserId = 0, int userLoginAllowedTimeId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		UserLoginAllowedTimesViewModel userLoginAllowedTimesViewModel = new UserLoginAllowedTimesViewModel();
		if (userLoginAllowedTimeId == 0)
		{
			DateTime now = DateTime.Now;
			userLoginAllowedTimesViewModel.crmUserId = crmUserId;
			userLoginAllowedTimesViewModel.UserLoginAllowedTimeId = 0;
			userLoginAllowedTimesViewModel.RegisterUserId = UserLogin.CurrentUser.UserId;
			userLoginAllowedTimesViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			userLoginAllowedTimesViewModel.RegisterDate = now;
			userLoginAllowedTimesViewModel.AppType = Configuration.AppType;
			userLoginAllowedTimesViewModel.FirstRegisterDate = now;
		}
		else
		{
			UserLoginAllowedTimes userLoginAllowedTimes = _dbTbl.UserLoginAllowedTimes.Find(userLoginAllowedTimeId);
			if (userLoginAllowedTimes != null)
			{
				DateTime dateTime = default(DateTime);
				string text = "";
				string text2 = "";
				string text3 = "";
				try
				{
					if (!string.IsNullOrEmpty(userLoginAllowedTimes.FDatePersian))
					{
						text = PersianDate.GetFormatetdDate(userLoginAllowedTimes.FDatePersian.Replace("/", ""));
						if (lCID == 1065)
						{
							text2 = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd", new PersianCulture());
						}
						else
						{
							text = PersianDate.GetShamsi2Miladi(text.Replace("/", "")).Replace("/", "");
							text = PersianDate.GetFormatetdDate(text.Replace("/", ""));
							text2 = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = Messages.WrongDateTime;
					return View(userLoginAllowedTimesViewModel);
				}
				try
				{
					if (!string.IsNullOrEmpty(userLoginAllowedTimes.TDatePersian))
					{
						text = PersianDate.GetFormatetdDate(userLoginAllowedTimes.TDatePersian.Replace("/", ""));
						if (lCID == 1065)
						{
							text3 = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd", new PersianCulture());
						}
						else
						{
							text = PersianDate.GetShamsi2Miladi(text.Replace("/", "")).Replace("/", "");
							text = PersianDate.GetFormatetdDate(text.Replace("/", ""));
							text3 = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					base.ViewBag.Error = Messages.WrongDateTime;
					return View(userLoginAllowedTimesViewModel);
				}
				userLoginAllowedTimesViewModel = new UserLoginAllowedTimesViewModel();
				userLoginAllowedTimesViewModel.UserLoginAllowedTimeId = userLoginAllowedTimes.UserLoginAllowedTimeId;
				userLoginAllowedTimesViewModel.Mode = 1;
				userLoginAllowedTimesViewModel.crmUserId = userLoginAllowedTimes.crmUserId;
				userLoginAllowedTimesViewModel.crmRollId = null;
				userLoginAllowedTimesViewModel.DayNumber = userLoginAllowedTimes.DayNumber.ToString();
				userLoginAllowedTimesViewModel.FTime = userLoginAllowedTimes.FTime;
				userLoginAllowedTimesViewModel.TTime = userLoginAllowedTimes.TTime;
				userLoginAllowedTimesViewModel.IPAddress = userLoginAllowedTimes.IPAddress;
				userLoginAllowedTimesViewModel.FDatePersian = ((!string.IsNullOrEmpty(userLoginAllowedTimes.FDatePersian)) ? text2 : userLoginAllowedTimes.FDatePersian);
				userLoginAllowedTimesViewModel.TDatePersian = ((!string.IsNullOrEmpty(userLoginAllowedTimes.TDatePersian)) ? text3 : userLoginAllowedTimes.TDatePersian);
				userLoginAllowedTimesViewModel.RegisterUserId = userLoginAllowedTimes.UserId;
				userLoginAllowedTimesViewModel.FirstRegisterUserId = userLoginAllowedTimes.FirstRegisterUserId;
				userLoginAllowedTimesViewModel.RegisterDate = userLoginAllowedTimes.RegisterDate;
				userLoginAllowedTimesViewModel.AppType = userLoginAllowedTimes.AppType;
				userLoginAllowedTimesViewModel.FirstRegisterDate = userLoginAllowedTimes.FirstRegisterDate;
			}
		}
		FillDropdownUserLoginAllowed();
		SetUserNameDateForLoginAllowed(userLoginAllowedTimesViewModel);
		return View(userLoginAllowedTimesViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actLoginAllowedTimes")]
	public ActionResult InsertEdit(UserLoginAllowedTimesViewModel viewmodel)
	{
		_003C_003Ec__DisplayClass5_0 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_0();
		_003C_003Ec__DisplayClass5_.viewmodel = viewmodel;
		string text = "";
		if (base.ModelState.IsValid)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime dateTime = default(DateTime);
				string text2 = "";
				string text3 = "";
				string text4 = "";
				DateTime value = default(DateTime);
				DateTime value2 = default(DateTime);
				try
				{
					if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian))
					{
						text2 = PersianDate.GetFormatetdDate(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							text3 = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							text3 = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							text3 = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						value = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = Messages.WrongDateTime;
					return View(_003C_003Ec__DisplayClass5_.viewmodel);
				}
				try
				{
					if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian))
					{
						text2 = PersianDate.GetFormatetdDate(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							text4 = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							text4 = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							text4 = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						value2 = dateTime;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					base.ViewBag.Error = Messages.WrongDateTime;
					return View(_003C_003Ec__DisplayClass5_.viewmodel);
				}
				if (_003C_003Ec__DisplayClass5_.viewmodel.UserLoginAllowedTimeId > 0)
				{
					UserLoginAllowedTimes userLoginAllowedTimes = _dbTbl.UserLoginAllowedTimes.Find(_003C_003Ec__DisplayClass5_.viewmodel.UserLoginAllowedTimeId);
					if (userLoginAllowedTimes != null)
					{
						userLoginAllowedTimes.UserId = UserLogin.CurrentUser.UserId;
						DateTime dateTime2 = (userLoginAllowedTimes.RegisterDate = DateTime.Now);
						userLoginAllowedTimes.RegisterDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
						userLoginAllowedTimes.AppType = Configuration.AppType;
						userLoginAllowedTimes.Month1 = short.Parse(dateTime2.ToString("MM", new PersianCulture()));
						userLoginAllowedTimes.Year1 = short.Parse(Financial.Get().Id.ToString());
						int result2 = 0;
						int.TryParse(_003C_003Ec__DisplayClass5_.viewmodel.DayNumber, out result2);
						userLoginAllowedTimes.DayNumber = ((result2 != 0) ? new int?(result2) : null);
						userLoginAllowedTimes.FTime = _003C_003Ec__DisplayClass5_.viewmodel.FTime;
						userLoginAllowedTimes.TTime = _003C_003Ec__DisplayClass5_.viewmodel.TTime;
						userLoginAllowedTimes.IPAddress = _003C_003Ec__DisplayClass5_.viewmodel.IPAddress;
						userLoginAllowedTimes.FDatePersian = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian)) ? text3 : null);
						userLoginAllowedTimes.FDatetime = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian)) ? new DateTime?(value) : null);
						userLoginAllowedTimes.TDatePersian = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian)) ? text4 : null);
						userLoginAllowedTimes.TDatetime = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian)) ? new DateTime?(value2) : null);
						_dbTbl.Entry(userLoginAllowedTimes).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						_003C_003Ec__DisplayClass5_.viewmodel.RegisterUserId = userLoginAllowedTimes.UserId;
						_003C_003Ec__DisplayClass5_.viewmodel.FirstRegisterUserId = userLoginAllowedTimes.FirstRegisterUserId;
						_003C_003Ec__DisplayClass5_.viewmodel.RegisterDate = userLoginAllowedTimes.RegisterDate;
						_003C_003Ec__DisplayClass5_.viewmodel.AppType = userLoginAllowedTimes.AppType;
						_003C_003Ec__DisplayClass5_.viewmodel.FirstRegisterDate = userLoginAllowedTimes.FirstRegisterDate;
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
				else
				{
					string[] array = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.DayNumber)) ? _003C_003Ec__DisplayClass5_.viewmodel.DayNumber.Split(new char[1] { '|' }) : null);
					if (_003C_003Ec__DisplayClass5_.viewmodel.Mode == 0)
					{
						if (_003C_003Ec__DisplayClass5_.viewmodel.crmRollId.HasValue && _003C_003Ec__DisplayClass5_.viewmodel.crmRollId > 0)
						{
							DbSet<UsersPermission> usersPermission = _dbTbl.UsersPermission;
							ParameterExpression val = Expression.Parameter(typeof(UsersPermission), "m");
							List<UsersPermission> list = Enumerable.ToList<UsersPermission>((IEnumerable<UsersPermission>)Queryable.Where<UsersPermission>((IQueryable<UsersPermission>)usersPermission, Expression.Lambda<Func<UsersPermission, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
							if (list.Count > 0)
							{
								using List<UsersPermission>.Enumerator enumerator = list.GetEnumerator();
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_2 = new _003C_003Ec__DisplayClass5_1();
									_003C_003Ec__DisplayClass5_2.user = enumerator.Current;
									DbSet<Users> users = _dbTbl.Users;
									val = Expression.Parameter(typeof(Users), "m");
									Users users2 = Queryable.FirstOrDefault<Users>((IQueryable<Users>)users, Expression.Lambda<Func<Users, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_2, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Constant((object)true, typeof(bool)), typeof(bool?)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (users2 != null)
									{
										if (array != null)
										{
											foreach (string item in Enumerable.Where<string>((IEnumerable<string>)array, (Func<string, bool>)((string day) => int.Parse(day) != 0)))
											{
												UserLoginAllowedTimes userLoginAllowedTimes2 = new UserLoginAllowedTimes();
												userLoginAllowedTimes2.UserId = UserLogin.CurrentUser.UserId;
												DateTime firstRegisterDate = (userLoginAllowedTimes2.RegisterDate = DateTime.Now);
												userLoginAllowedTimes2.RegisterDatePersian = firstRegisterDate.ToString("yyyyMMdd", new PersianCulture());
												userLoginAllowedTimes2.FirstUserId = UserLogin.CurrentUser.UserId;
												userLoginAllowedTimes2.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
												userLoginAllowedTimes2.FirstRegisterDate = firstRegisterDate;
												userLoginAllowedTimes2.FirstRegisterDatePersian = firstRegisterDate.ToString("yyyyMMdd", new PersianCulture());
												userLoginAllowedTimes2.AppType = Configuration.AppType;
												userLoginAllowedTimes2.GUId = Guid.NewGuid();
												userLoginAllowedTimes2.Month1 = short.Parse(firstRegisterDate.ToString("MM", new PersianCulture()));
												userLoginAllowedTimes2.Year1 = short.Parse(Financial.Get().Id.ToString());
												userLoginAllowedTimes2.crmUserId = users2.UserId;
												userLoginAllowedTimes2.DayNumber = int.Parse(item);
												userLoginAllowedTimes2.FTime = _003C_003Ec__DisplayClass5_.viewmodel.FTime;
												userLoginAllowedTimes2.TTime = _003C_003Ec__DisplayClass5_.viewmodel.TTime;
												userLoginAllowedTimes2.IPAddress = _003C_003Ec__DisplayClass5_.viewmodel.IPAddress;
												userLoginAllowedTimes2.FDatePersian = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian)) ? text3 : null);
												userLoginAllowedTimes2.FDatetime = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian)) ? new DateTime?(value) : null);
												userLoginAllowedTimes2.TDatePersian = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian)) ? text4 : null);
												userLoginAllowedTimes2.TDatetime = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian)) ? new DateTime?(value2) : null);
												userLoginAllowedTimes2.LanguageID = result;
												_dbTbl.UserLoginAllowedTimes.Add(userLoginAllowedTimes2);
											}
										}
										else
										{
											UserLoginAllowedTimes userLoginAllowedTimes3 = new UserLoginAllowedTimes();
											userLoginAllowedTimes3.UserId = UserLogin.CurrentUser.UserId;
											DateTime firstRegisterDate2 = (userLoginAllowedTimes3.RegisterDate = DateTime.Now);
											userLoginAllowedTimes3.RegisterDatePersian = firstRegisterDate2.ToString("yyyyMMdd", new PersianCulture());
											userLoginAllowedTimes3.FirstUserId = UserLogin.CurrentUser.UserId;
											userLoginAllowedTimes3.FirstRegisterDate = firstRegisterDate2;
											userLoginAllowedTimes3.FirstRegisterDatePersian = firstRegisterDate2.ToString("yyyyMMdd", new PersianCulture());
											userLoginAllowedTimes3.AppType = Configuration.AppType;
											userLoginAllowedTimes3.GUId = Guid.NewGuid();
											userLoginAllowedTimes3.Month1 = short.Parse(firstRegisterDate2.ToString("MM", new PersianCulture()));
											userLoginAllowedTimes3.Year1 = short.Parse(Financial.Get().Id.ToString());
											userLoginAllowedTimes3.crmUserId = users2.UserId;
											userLoginAllowedTimes3.DayNumber = null;
											userLoginAllowedTimes3.FTime = _003C_003Ec__DisplayClass5_.viewmodel.FTime;
											userLoginAllowedTimes3.TTime = _003C_003Ec__DisplayClass5_.viewmodel.TTime;
											userLoginAllowedTimes3.IPAddress = _003C_003Ec__DisplayClass5_.viewmodel.IPAddress;
											userLoginAllowedTimes3.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
											userLoginAllowedTimes3.FDatePersian = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian)) ? text3 : null);
											userLoginAllowedTimes3.FDatetime = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian)) ? new DateTime?(value) : null);
											userLoginAllowedTimes3.TDatePersian = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian)) ? text4 : null);
											userLoginAllowedTimes3.TDatetime = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian)) ? new DateTime?(value2) : null);
											userLoginAllowedTimes3.LanguageID = result;
											_dbTbl.UserLoginAllowedTimes.Add(userLoginAllowedTimes3);
										}
									}
									_dbTbl.SaveChanges();
									base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
								}
							}
							else
							{
								text = Messages.msgErrorNotDefineThisRollForAnyUser;
							}
						}
						else
						{
							text = Messages.msgErrorNotSelectedRoll;
						}
					}
					else if (_003C_003Ec__DisplayClass5_.viewmodel.crmUserId.HasValue && _003C_003Ec__DisplayClass5_.viewmodel.crmUserId > 0)
					{
						Users users3 = _dbTbl.Users.Find(_003C_003Ec__DisplayClass5_.viewmodel.crmUserId);
						if (users3 != null)
						{
							if (array != null)
							{
								foreach (string item2 in Enumerable.Where<string>((IEnumerable<string>)array, (Func<string, bool>)((string day) => int.Parse(day) != 0)))
								{
									UserLoginAllowedTimes userLoginAllowedTimes4 = new UserLoginAllowedTimes();
									userLoginAllowedTimes4.UserId = UserLogin.CurrentUser.UserId;
									DateTime firstRegisterDate3 = (userLoginAllowedTimes4.RegisterDate = DateTime.Now);
									userLoginAllowedTimes4.RegisterDatePersian = firstRegisterDate3.ToString("yyyyMMdd", new PersianCulture());
									userLoginAllowedTimes4.FirstUserId = UserLogin.CurrentUser.UserId;
									userLoginAllowedTimes4.FirstRegisterDate = firstRegisterDate3;
									userLoginAllowedTimes4.FirstRegisterDatePersian = firstRegisterDate3.ToString("yyyyMMdd", new PersianCulture());
									userLoginAllowedTimes4.AppType = Configuration.AppType;
									userLoginAllowedTimes4.GUId = Guid.NewGuid();
									userLoginAllowedTimes4.Month1 = short.Parse(firstRegisterDate3.ToString("MM", new PersianCulture()));
									userLoginAllowedTimes4.Year1 = short.Parse(Financial.Get().Id.ToString());
									userLoginAllowedTimes4.crmUserId = users3.UserId;
									userLoginAllowedTimes4.DayNumber = int.Parse(item2);
									userLoginAllowedTimes4.FTime = _003C_003Ec__DisplayClass5_.viewmodel.FTime;
									userLoginAllowedTimes4.TTime = _003C_003Ec__DisplayClass5_.viewmodel.TTime;
									userLoginAllowedTimes4.IPAddress = _003C_003Ec__DisplayClass5_.viewmodel.IPAddress;
									userLoginAllowedTimes4.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
									userLoginAllowedTimes4.FDatePersian = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian)) ? text3 : null);
									userLoginAllowedTimes4.FDatetime = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian)) ? new DateTime?(value) : null);
									userLoginAllowedTimes4.TDatePersian = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian)) ? text4 : null);
									userLoginAllowedTimes4.TDatetime = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian)) ? new DateTime?(value2) : null);
									userLoginAllowedTimes4.LanguageID = result;
									_dbTbl.UserLoginAllowedTimes.Add(userLoginAllowedTimes4);
								}
							}
							else
							{
								UserLoginAllowedTimes userLoginAllowedTimes5 = new UserLoginAllowedTimes();
								userLoginAllowedTimes5.UserId = UserLogin.CurrentUser.UserId;
								DateTime firstRegisterDate4 = (userLoginAllowedTimes5.RegisterDate = DateTime.Now);
								userLoginAllowedTimes5.RegisterDatePersian = firstRegisterDate4.ToString("yyyyMMdd", new PersianCulture());
								userLoginAllowedTimes5.FirstUserId = UserLogin.CurrentUser.UserId;
								userLoginAllowedTimes5.FirstRegisterDate = firstRegisterDate4;
								userLoginAllowedTimes5.FirstRegisterDatePersian = firstRegisterDate4.ToString("yyyyMMdd", new PersianCulture());
								userLoginAllowedTimes5.AppType = Configuration.AppType;
								userLoginAllowedTimes5.GUId = Guid.NewGuid();
								userLoginAllowedTimes5.Month1 = short.Parse(firstRegisterDate4.ToString("MM"));
								userLoginAllowedTimes5.Year1 = short.Parse(Financial.Get().Id.ToString());
								userLoginAllowedTimes5.crmUserId = users3.UserId;
								userLoginAllowedTimes5.DayNumber = null;
								userLoginAllowedTimes5.FTime = _003C_003Ec__DisplayClass5_.viewmodel.FTime;
								userLoginAllowedTimes5.TTime = _003C_003Ec__DisplayClass5_.viewmodel.TTime;
								userLoginAllowedTimes5.IPAddress = _003C_003Ec__DisplayClass5_.viewmodel.IPAddress;
								userLoginAllowedTimes5.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
								userLoginAllowedTimes5.FDatePersian = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian)) ? text3 : null);
								userLoginAllowedTimes5.FDatetime = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.FDatePersian)) ? new DateTime?(value) : null);
								userLoginAllowedTimes5.TDatePersian = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian)) ? text4 : null);
								userLoginAllowedTimes5.TDatetime = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass5_.viewmodel.TDatePersian)) ? new DateTime?(value2) : null);
								userLoginAllowedTimes5.LanguageID = result;
								_dbTbl.UserLoginAllowedTimes.Add(userLoginAllowedTimes5);
							}
							_dbTbl.SaveChanges();
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						else
						{
							text = Messages.msgErrorNotSelectedUser;
						}
					}
					else
					{
						text = Messages.msgErrorNotSelectedUser;
					}
					DateTime now6 = DateTime.Now;
					_003C_003Ec__DisplayClass5_.viewmodel.RegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass5_.viewmodel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass5_.viewmodel.RegisterDate = now6;
					_003C_003Ec__DisplayClass5_.viewmodel.AppType = Configuration.AppType;
					_003C_003Ec__DisplayClass5_.viewmodel.FirstRegisterDate = now6;
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				text = Messages.msgErrorRunFunction;
			}
		}
		base.ViewBag.Error = text;
		FillDropdownUserLoginAllowed();
		SetUserNameDateForLoginAllowed(_003C_003Ec__DisplayClass5_.viewmodel);
		return View(_003C_003Ec__DisplayClass5_.viewmodel);
	}

	[AjaxOnly]
	public string AllRemoveUserLoginAllowedTimes(int crmUserId)
	{
		string text = "";
		try
		{
			if (crmUserId > 0)
			{
				_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_0();
				_003C_003Ec__DisplayClass6_.usr = _dbTbl.Users.Find(crmUserId);
				if (_003C_003Ec__DisplayClass6_.usr != null)
				{
					try
					{
						DbSet<UserLoginAllowedTimes> userLoginAllowedTimes = _dbTbl.UserLoginAllowedTimes;
						ParameterExpression val = Expression.Parameter(typeof(UserLoginAllowedTimes), "m");
						List<UserLoginAllowedTimes> list = Enumerable.ToList<UserLoginAllowedTimes>((IEnumerable<UserLoginAllowedTimes>)Queryable.Where<UserLoginAllowedTimes>((IQueryable<UserLoginAllowedTimes>)userLoginAllowedTimes, Expression.Lambda<Func<UserLoginAllowedTimes, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass6_, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						if (Enumerable.Any<UserLoginAllowedTimes>((IEnumerable<UserLoginAllowedTimes>)list))
						{
							foreach (UserLoginAllowedTimes item in list)
							{
								_dbTbl.UserLoginAllowedTimes.Remove(item);
								_dbTbl.SaveChanges();
							}
							return "1";
						}
						return Messages.msgErrorNotDefineLoginAllowedTimeForUser;
					}
					catch (DbEntityValidationException e)
					{
						ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
						return Messages.RedundancyMessage;
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
					}
				}
				return Messages.ErrorNotFound;
			}
			return Messages.msgErrorNotSelectedUser;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	public List<UserLoginAllowedTimesViewModel> ListUserLoginAllowedTimes(int crmUserId)
	{
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.crmUserId = crmUserId;
		List<UserLoginAllowedTimesViewModel> list = new List<UserLoginAllowedTimesViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass7_.crmUserId > 0)
			{
				DbSet<UserLoginAllowedTimes> userLoginAllowedTimes = _dbTbl.UserLoginAllowedTimes;
				ParameterExpression val = Expression.Parameter(typeof(UserLoginAllowedTimes), "m");
				IQueryable<UserLoginAllowedTimes> obj = Queryable.Where<UserLoginAllowedTimes>((IQueryable<UserLoginAllowedTimes>)userLoginAllowedTimes, Expression.Lambda<Func<UserLoginAllowedTimes, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				val = Expression.Parameter(typeof(UserLoginAllowedTimes), "m");
				List<UserLoginAllowedTimes> list2 = Enumerable.ToList<UserLoginAllowedTimes>((IEnumerable<UserLoginAllowedTimes>)Queryable.OrderBy<UserLoginAllowedTimes, int?>(obj, Expression.Lambda<Func<UserLoginAllowedTimes, int?>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				list.AddRange(Enumerable.Select<UserLoginAllowedTimes, UserLoginAllowedTimesViewModel>((IEnumerable<UserLoginAllowedTimes>)list2, (Func<UserLoginAllowedTimes, UserLoginAllowedTimesViewModel>)((UserLoginAllowedTimes item) => new UserLoginAllowedTimesViewModel
				{
					UserLoginAllowedTimeId = item.UserLoginAllowedTimeId,
					DayNumber = item.DayNumber.ToString(),
					FTime = item.FTime,
					TTime = item.TTime,
					IPAddress = item.IPAddress,
					FDatePersian = item.FDatePersian,
					TDatePersian = item.TDatePersian,
					OrderView = ((item.DayNumber.HasValue && item.DayNumber.GetValueOrDefault() == 7) ? new int?(0) : item.DayNumber)
				})));
				foreach (UserLoginAllowedTimesViewModel item in list)
				{
					item.FDatePersian = ((!string.IsNullOrEmpty(item.FDatePersian) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.FDatePersian.Replace("/", "")).Replace("/", "") : item.FDatePersian);
					item.TDatePersian = ((!string.IsNullOrEmpty(item.TDatePersian) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.TDatePersian.Replace("/", "")).Replace("/", "") : item.TDatePersian);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Enumerable.ToList<UserLoginAllowedTimesViewModel>((IEnumerable<UserLoginAllowedTimesViewModel>)Enumerable.OrderBy<UserLoginAllowedTimesViewModel, int?>((IEnumerable<UserLoginAllowedTimesViewModel>)list, (Func<UserLoginAllowedTimesViewModel, int?>)((UserLoginAllowedTimesViewModel m) => m.OrderView)));
	}

	[AjaxOnly]
	public ActionResult UserLoginAllowedTimes_Read([DataSourceRequest] DataSourceRequest request, int crmUserId)
	{
		return Json(((IEnumerable)ListUserLoginAllowedTimes(crmUserId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult UserLoginAllowedTime(int crmUserId)
	{
		return Json(ListUserLoginAllowedTimes(crmUserId), JsonRequestBehavior.AllowGet);
	}

	private void FillDropdownUserLoginAllowed()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<CRMspSelectsysRolls_Result> list = Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)_db.CRMspSelectsysRolls(lCID, result));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.AddRange(Enumerable.Select<CRMspSelectsysRolls_Result, SelectListItem>((IEnumerable<CRMspSelectsysRolls_Result>)list, (Func<CRMspSelectsysRolls_Result, SelectListItem>)((CRMspSelectsysRolls_Result item) => new SelectListItem
			{
				Text = item.RollName,
				Value = item.ID.ToString(),
				Selected = false
			})));
			base.ViewBag.RollList = list2;
			List<CRMspSelectActiveUsers_Result> list3 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
			List<SelectListItem> list4 = new List<SelectListItem>();
			list4.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list3, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserId.ToString(),
				Selected = false
			})));
			base.ViewBag.UserList = list4;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actLoginAllowedTimes")]
	public string UserLoginAllowedTimesDelete(int userLoginAllowedTimeId)
	{
		string text = "";
		try
		{
			if (userLoginAllowedTimeId > 0)
			{
				UserLoginAllowedTimes userLoginAllowedTimes = _dbTbl.UserLoginAllowedTimes.Find(userLoginAllowedTimeId);
				if (userLoginAllowedTimes != null)
				{
					_dbTbl.UserLoginAllowedTimes.Remove(userLoginAllowedTimes);
					_dbTbl.SaveChanges();
					return "1";
				}
				return Messages.ErrorNotFound;
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
