using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Accounts.Controllers;

public class UserMoneyBagController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int umnBgId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int umnBgId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public UserMoneyBagLanguageViewModel vm;

		public int defLangID;

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel m)
		{
			return m.LanguageId != defLangID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineUserMoneyBag")]
	public ActionResult Index()
	{
		GetActiveUsers();
		GetUserMoneyBagChergeTypeAll();
		return View();
	}

	public List<CRMspSelectUserMoneyBag_Result> ListUserMoneyBag(int userId, string fromDate, string toDate, int uMnBgChergeTypeId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectUserMoneyBag_Result> list = new List<CRMspSelectUserMoneyBag_Result>();
		try
		{
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fromDate))
			{
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (!string.IsNullOrEmpty(toDate))
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			string uMnBgTextRemainderBefore = Labels.UMnBgTextRemainderBefore;
			_ = Labels.CmpMnBgTextManual;
			_ = Labels.CmpMnBgTextSystemic;
			list = Enumerable.ToList<CRMspSelectUserMoneyBag_Result>((IEnumerable<CRMspSelectUserMoneyBag_Result>)_dbII.CRMspSelectUserMoneyBag(userId, value, value2, uMnBgTextRemainderBefore, lCID, result, uMnBgChergeTypeId));
			foreach (CRMspSelectUserMoneyBag_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.FirstRegisterUser = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				string text4 = (item.RegisterDate.HasValue ? item.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.EditUser = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				item.UMnBgDatePersian = (item.UMnBgDate.HasValue ? item.UMnBgDate.Value.ToString("yyyy/MM/dd") : "");
				item.UMnBgExpireDatePersian = (item.UMnBgExpireDate.HasValue ? item.UMnBgExpireDate.Value.ToString("yyyy/MM/dd") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult UserMoneyBag_Read([DataSourceRequest] DataSourceRequest request, int userId, string fromDate, string toDate, int uMnBgChergeTypeId)
	{
		return Json(((IEnumerable)ListUserMoneyBag(userId, fromDate, toDate, uMnBgChergeTypeId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmUserMoneyBag", ActionName = "actDelete")]
	public string ActDelete(int umnBgId)
	{
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.umnBgId = umnBgId;
		string text = "";
		try
		{
			if (_003C_003Ec__DisplayClass7_.umnBgId > 0)
			{
				DbSet<UserMoneyBag> userMoneyBag = _dbTbl.UserMoneyBag;
				ParameterExpression val = Expression.Parameter(typeof(UserMoneyBag), "m");
				UserMoneyBag userMoneyBag2 = Queryable.FirstOrDefault<UserMoneyBag>((IQueryable<UserMoneyBag>)userMoneyBag, Expression.Lambda<Func<UserMoneyBag, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (userMoneyBag2 != null)
				{
					try
					{
						mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteUserMoneyBag(_003C_003Ec__DisplayClass7_.umnBgId));
						int result = 0;
						if (mct_II_Result != null)
						{
							int.TryParse(mct_II_Result.Result.ToString(), out result);
						}
						if (result > 0)
						{
							text = "1";
							if (userMoneyBag2.UMnBgUserId != 0)
							{
								Info.Update(userMoneyBag2.UMnBgUserId, true);
							}
						}
						else
						{
							text = Messages.RedundancyMessage;
						}
					}
					catch (DbEntityValidationException e)
					{
						ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
						text = Messages.msgErrorRunFunction;
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						text = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
				}
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmUserMoneyBag", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int uMnBgUserId, int umnBgId = 0)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.umnBgId = umnBgId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		UserMoneyBagLanguageViewModel model = new UserMoneyBagLanguageViewModel();
		try
		{
			UserMoneyBag userMoneyBag = new UserMoneyBag();
			if (CS_0024_003C_003E8__locals0.umnBgId == 0)
			{
				if (!UserLogin.IsUserAccess("frmUserMoneyBag", "actInsert", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DateTime now = DateTime.Now;
				long uMnBgNumber = Enumerable.FirstOrDefault<long>((IEnumerable<long>)Enumerable.ToList<long>(_dbI.Database.SqlQuery<long>($"Select dbo.CRMfnReturnUserMoneyBagNumber()", Array.Empty<object>())));
				model = new UserMoneyBagLanguageViewModel
				{
					UserMoneyBagId = userMoneyBag.UserMoneyBagId,
					UMnBgUserId = uMnBgUserId,
					UMnBgUserMoneyBagChergeTypeId = 1,
					UMnBgNumber = uMnBgNumber,
					UMnBgDate = now,
					UMnBgDatePersian = now.ToString("yyyyMMdd", new PersianCulture())
				};
				base.ViewBag.IsBuying = VersionBuyer.MoneyBag;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmUserMoneyBag", "actEdit", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<UserMoneyBag> userMoneyBag2 = _dbTbl.UserMoneyBag;
				ParameterExpression val = Expression.Parameter(typeof(UserMoneyBag), "m");
				userMoneyBag = Queryable.FirstOrDefault<UserMoneyBag>((IQueryable<UserMoneyBag>)userMoneyBag2, Expression.Lambda<Func<UserMoneyBag, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				DbSet<UserMoneyBag_Lang> userMoneyBag_Lang = _dbTbl.UserMoneyBag_Lang;
				val = Expression.Parameter(typeof(UserMoneyBag_Lang), "c");
				List<UserMoneyBag_Lang> list = Enumerable.ToList<UserMoneyBag_Lang>((IEnumerable<UserMoneyBag_Lang>)Queryable.Where<UserMoneyBag_Lang>((IQueryable<UserMoneyBag_Lang>)userMoneyBag_Lang, Expression.Lambda<Func<UserMoneyBag_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				if (userMoneyBag == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
				}
				else
				{
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<UserMoneyBag_Lang, CommonMultiLanguageViewModel>((IEnumerable<UserMoneyBag_Lang>)list, (Func<UserMoneyBag_Lang, CommonMultiLanguageViewModel>)((UserMoneyBag_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.UMnBgDesc,
						LanguageId = item.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = userMoneyBag.UMnBgDesc,
						LanguageId = result
					});
					UserMoneyBagLanguageViewModel obj = new UserMoneyBagLanguageViewModel
					{
						UserMoneyBagId = userMoneyBag.UserMoneyBagId,
						UMnBgUserId = userMoneyBag.UMnBgUserId,
						UMnBgUserMoneyBagChergeTypeId = userMoneyBag.UMnBgUserMoneyBagChergeTypeId,
						UMnBgNumber = userMoneyBag.UMnBgNumber,
						UMnBgDate = userMoneyBag.UMnBgDate
					};
					_ = userMoneyBag.UMnBgDate;
					obj.UMnBgDatePersian = userMoneyBag.UMnBgDate.ToString("yyyy/MM/dd");
					obj.UMnBgAmount = userMoneyBag.UMnBgAmount;
					obj.UMnBgExpireDate = userMoneyBag.UMnBgExpireDate;
					obj.UMnBgExpireDatePersian = (userMoneyBag.UMnBgExpireDate.HasValue ? userMoneyBag.UMnBgExpireDate.Value.ToString("yyyy/MM/dd") : "");
					obj.UMnBgDiscountStrategyId = userMoneyBag.UMnBgDiscountStrategyId;
					obj.UMnBgSystemPartId = userMoneyBag.UMnBgSystemPartId;
					obj.UMnBgSystemPartObjectId = userMoneyBag.UMnBgSystemPartObjectId;
					obj.UMnBgBankTransactionCode = userMoneyBag.UMnBgBankTransactionCode;
					obj.UMnBgDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					obj.UMnBgDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					model = obj;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetUserMoneyBagChergeType();
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmUserMoneyBagDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(UserMoneyBagLanguageViewModel vm)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetUserMoneyBagChergeType();
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.UMnBgDesc_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.UMnBgDesc_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.vm.UMnBgDesc,
					LanguageId = lCID
				});
				if (CS_0024_003C_003E8__locals0.vm.UserMoneyBagId <= 0 && !VersionBuyer.MoneyBag)
				{
					DbSet<UserMoneyBag> userMoneyBag = _dbTbl.UserMoneyBag;
					ParameterExpression val = Expression.Parameter(typeof(UserMoneyBag), "c");
					if (Queryable.Any<UserMoneyBag>((IQueryable<UserMoneyBag>)userMoneyBag, Expression.Lambda<Func<UserMoneyBag, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
					{
						base.ViewBag.Error = "BV|" + Messages.VersionBuy;
						return View(CS_0024_003C_003E8__locals0.vm);
					}
				}
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					DateTime dateTime = default(DateTime);
					string text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.UMnBgDatePersian))
						{
							text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.UMnBgDatePersian.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " " + now.ToString("HH:mm:ss"), new PersianCulture());
								CS_0024_003C_003E8__locals0.vm.UMnBgDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " " + now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								CS_0024_003C_003E8__locals0.vm.UMnBgDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " " + now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								CS_0024_003C_003E8__locals0.vm.UMnBgDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							CS_0024_003C_003E8__locals0.vm.UMnBgDate = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.UMnBgDate);
						UserMoneyBagLanguageViewModel vm2 = CS_0024_003C_003E8__locals0.vm;
						_ = CS_0024_003C_003E8__locals0.vm.UMnBgDate;
						vm2.UMnBgDatePersian = CS_0024_003C_003E8__locals0.vm.UMnBgDate.ToString("yyyy/MM/dd");
						CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian = (CS_0024_003C_003E8__locals0.vm.UMnBgExpireDate.HasValue ? CS_0024_003C_003E8__locals0.vm.UMnBgExpireDate.Value.ToString("yyyy/MM/dd") : "");
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					if (CS_0024_003C_003E8__locals0.vm.UMnBgDatePersian != null)
					{
						CS_0024_003C_003E8__locals0.vm.UMnBgDatePersian = CS_0024_003C_003E8__locals0.vm.UMnBgDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					dateTime = default(DateTime);
					text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian))
						{
							text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
								CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
								CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
								CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							CS_0024_003C_003E8__locals0.vm.UMnBgExpireDate = dateTime;
						}
						else
						{
							CS_0024_003C_003E8__locals0.vm.UMnBgExpireDate = null;
							CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian = null;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.UMnBgExpireDate);
						UserMoneyBagLanguageViewModel vm3 = CS_0024_003C_003E8__locals0.vm;
						_ = CS_0024_003C_003E8__locals0.vm.UMnBgDate;
						vm3.UMnBgDatePersian = CS_0024_003C_003E8__locals0.vm.UMnBgDate.ToString("yyyy/MM/dd");
						CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian = (CS_0024_003C_003E8__locals0.vm.UMnBgExpireDate.HasValue ? CS_0024_003C_003E8__locals0.vm.UMnBgExpireDate.Value.ToString("yyyy/MM/dd") : "");
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					if (CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian != null)
					{
						CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian = CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					try
					{
						UserMoneyBag userMoneyBag2 = new UserMoneyBag();
						if (CS_0024_003C_003E8__locals0.vm.UserMoneyBagId > 0)
						{
							DbSet<UserMoneyBag> userMoneyBag3 = _dbTbl.UserMoneyBag;
							ParameterExpression val = Expression.Parameter(typeof(UserMoneyBag), "m");
							userMoneyBag2 = Queryable.FirstOrDefault<UserMoneyBag>((IQueryable<UserMoneyBag>)userMoneyBag3, Expression.Lambda<Func<UserMoneyBag, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						}
						string uMnBgDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						string uMnBgDesc_Lang = "";
						if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
						{
							uMnBgDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
						}
						if (userMoneyBag2.UserMoneyBagId > 0)
						{
							ObjectParameter insertedUserMoneyBagId = new ObjectParameter("insertedUserMoneyBagId", 0);
							mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertUpdateUserMoneyBag(userMoneyBag2.UserMoneyBagId, userMoneyBag2.UMnBgUserId, CS_0024_003C_003E8__locals0.vm.UMnBgUserMoneyBagChergeTypeId, CS_0024_003C_003E8__locals0.vm.UMnBgDate, CS_0024_003C_003E8__locals0.vm.UMnBgDatePersian, CS_0024_003C_003E8__locals0.vm.UMnBgAmount, CS_0024_003C_003E8__locals0.vm.UMnBgExpireDate, CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian, CS_0024_003C_003E8__locals0.vm.UMnBgDiscountStrategyId, CS_0024_003C_003E8__locals0.vm.UMnBgSystemPartId, CS_0024_003C_003E8__locals0.vm.UMnBgSystemPartObjectId, CS_0024_003C_003E8__locals0.vm.UMnBgBankTransactionCode, uMnBgDesc, uMnBgDesc_Lang, userId, value3, value2, value, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, insertedUserMoneyBagId));
							int result = 0;
							if (mct_II_Result != null)
							{
								int.TryParse(mct_II_Result.Result.ToString(), out result);
							}
							if (result != 1)
							{
								base.ViewBag.Error = Messages.msgErrorRunFunction;
							}
							else
							{
								base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
								if (userMoneyBag2.UMnBgUserId != 0)
								{
									Info.Update(userMoneyBag2.UMnBgUserId, true);
								}
							}
						}
						else
						{
							ObjectParameter objectParameter = new ObjectParameter("insertedUserMoneyBagId", 0);
							Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertUpdateUserMoneyBag(0, CS_0024_003C_003E8__locals0.vm.UMnBgUserId, CS_0024_003C_003E8__locals0.vm.UMnBgUserMoneyBagChergeTypeId, CS_0024_003C_003E8__locals0.vm.UMnBgDate, CS_0024_003C_003E8__locals0.vm.UMnBgDatePersian, CS_0024_003C_003E8__locals0.vm.UMnBgAmount, CS_0024_003C_003E8__locals0.vm.UMnBgExpireDate, CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian, CS_0024_003C_003E8__locals0.vm.UMnBgDiscountStrategyId, CS_0024_003C_003E8__locals0.vm.UMnBgSystemPartId, CS_0024_003C_003E8__locals0.vm.UMnBgSystemPartObjectId, CS_0024_003C_003E8__locals0.vm.UMnBgBankTransactionCode, uMnBgDesc, uMnBgDesc_Lang, userId, value3, value2, value, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, objectParameter));
							int result2 = 0;
							if (objectParameter.Value != null)
							{
								int.TryParse(objectParameter.Value.ToString(), out result2);
							}
							CS_0024_003C_003E8__locals0.vm.UserMoneyBagId = result2;
							if (result2 <= 0)
							{
								base.ViewBag.Error = Messages.msgErrorRunFunction;
							}
							else
							{
								base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
								if (CS_0024_003C_003E8__locals0.vm.UMnBgUserId != 0)
								{
									Info.Update(CS_0024_003C_003E8__locals0.vm.UMnBgUserId, true);
								}
							}
						}
						UserMoneyBagLanguageViewModel vm4 = CS_0024_003C_003E8__locals0.vm;
						_ = CS_0024_003C_003E8__locals0.vm.UMnBgDate;
						vm4.UMnBgDatePersian = CS_0024_003C_003E8__locals0.vm.UMnBgDate.ToString("yyyy/MM/dd");
						CS_0024_003C_003E8__locals0.vm.UMnBgExpireDatePersian = (CS_0024_003C_003E8__locals0.vm.UMnBgExpireDate.HasValue ? CS_0024_003C_003E8__locals0.vm.UMnBgExpireDate.Value.ToString("yyyy/MM/dd") : "");
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
						text = Messages.msgErrorRunFunction;
					}
				}
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public JsonResult GetActiveUsers()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
			if (list2 != null && Enumerable.Any<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)list2))
			{
				list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
				{
					Text = (item.Name ?? ""),
					Value = item.UserId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ActiveUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetUserMoneyBagChergeType()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectUserMoneyBagChergeType_Result> list2 = Enumerable.ToList<CRMspSelectUserMoneyBagChergeType_Result>((IEnumerable<CRMspSelectUserMoneyBagChergeType_Result>)_dbII.CRMspSelectUserMoneyBagChergeType(lCID, result));
			if (list2 != null && Enumerable.Any<CRMspSelectUserMoneyBagChergeType_Result>((IEnumerable<CRMspSelectUserMoneyBagChergeType_Result>)list2))
			{
				list2 = Enumerable.ToList<CRMspSelectUserMoneyBagChergeType_Result>(Enumerable.Where<CRMspSelectUserMoneyBagChergeType_Result>((IEnumerable<CRMspSelectUserMoneyBagChergeType_Result>)list2, (Func<CRMspSelectUserMoneyBagChergeType_Result, bool>)((CRMspSelectUserMoneyBagChergeType_Result m) => m.UserMoneyBagChergeTypeId == 1 || m.UserMoneyBagChergeTypeId == 2)));
			}
			if (list2 != null && Enumerable.Any<CRMspSelectUserMoneyBagChergeType_Result>((IEnumerable<CRMspSelectUserMoneyBagChergeType_Result>)list2))
			{
				list.AddRange(Enumerable.Select<CRMspSelectUserMoneyBagChergeType_Result, SelectListItem>((IEnumerable<CRMspSelectUserMoneyBagChergeType_Result>)list2, (Func<CRMspSelectUserMoneyBagChergeType_Result, SelectListItem>)((CRMspSelectUserMoneyBagChergeType_Result item) => new SelectListItem
				{
					Text = item.UserMoneyBagChergeTypeName,
					Value = item.UserMoneyBagChergeTypeId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserMoneyBagChergeTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetUserMoneyBagChergeTypeAll()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectUserMoneyBagChergeType_Result> list2 = Enumerable.ToList<CRMspSelectUserMoneyBagChergeType_Result>((IEnumerable<CRMspSelectUserMoneyBagChergeType_Result>)_dbII.CRMspSelectUserMoneyBagChergeType(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.All,
				Value = "-1",
				Selected = false
			};
			list.Add(item2);
			if (list2 != null && Enumerable.Any<CRMspSelectUserMoneyBagChergeType_Result>((IEnumerable<CRMspSelectUserMoneyBagChergeType_Result>)list2))
			{
				list.AddRange(Enumerable.Select<CRMspSelectUserMoneyBagChergeType_Result, SelectListItem>((IEnumerable<CRMspSelectUserMoneyBagChergeType_Result>)list2, (Func<CRMspSelectUserMoneyBagChergeType_Result, SelectListItem>)((CRMspSelectUserMoneyBagChergeType_Result item) => new SelectListItem
				{
					Text = item.UserMoneyBagChergeTypeName,
					Value = item.UserMoneyBagChergeTypeId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserMoneyBagChergeTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public decimal ShowCurrentUserMoneyBagAmount()
	{
		decimal result = default(decimal);
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null)
			{
				decimal.TryParse(currentUser.SumUserMoneyBagAmount.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public decimal ReturnUserMoneyBagRemainByType(int userId, string fromDate, string toDate, int uMnBgChergeTypeId)
	{
		decimal result = default(decimal);
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fromDate))
			{
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (!string.IsNullOrEmpty(toDate))
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			decimal? num = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)_dbII.CRMspReturnUserMoneyBagSumFooter(userId, uMnBgChergeTypeId, value, value2));
			if (num.HasValue)
			{
				decimal.TryParse(num.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
