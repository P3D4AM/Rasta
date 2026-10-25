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
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.DiscountStrategy.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public WSDiscountStrategyLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		public Func<Languages, bool> _003C_003E9__9;

		internal bool _003CInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public WSDiscountStrategy model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass10_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int disStId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int disStId;

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

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineDiscountStrategy")]
	public ActionResult Index()
	{
		return View();
	}

	public List<WSspSelectDiscountStrategy_Result> ListDiscountStrategy()
	{
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectDiscountStrategy_Result> list = new List<WSspSelectDiscountStrategy_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectDiscountStrategy_Result>((IEnumerable<WSspSelectDiscountStrategy_Result>)_dbII.WSspSelectDiscountStrategy(lCID, result));
			foreach (WSspSelectDiscountStrategy_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterUser = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.EditUser = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				item.DisStExpireDatePersian = (item.DisStExpireDate.HasValue ? item.DisStExpireDate.Value.ToString("yyyy/MM/dd") : "");
				if (string.IsNullOrWhiteSpace(item.DisStTypeValuesJson))
				{
					continue;
				}
				List<WSspSelectDiscountStrategyTypeValues_Result> list2 = new JavaScriptSerializer().Deserialize<List<WSspSelectDiscountStrategyTypeValues_Result>>(item.DisStTypeValuesJson);
				if (list2 == null || !Enumerable.Any<WSspSelectDiscountStrategyTypeValues_Result>((IEnumerable<WSspSelectDiscountStrategyTypeValues_Result>)list2))
				{
					continue;
				}
				foreach (WSspSelectDiscountStrategyTypeValues_Result item2 in list2)
				{
					item2.ExpDatePersian = (item2.ExpDate.HasValue ? item2.ExpDate.Value.ToString("yyyy/MM/dd") : "");
				}
				item.DisStTypeValuesJson = JsonConvert.SerializeObject(Enumerable.ToList<WSspSelectDiscountStrategyTypeValues_Result>((IEnumerable<WSspSelectDiscountStrategyTypeValues_Result>)list2));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult DiscountStrategy_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListDiscountStrategy()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDiscountStrategy", ActionName = "actDelete")]
	public string ActDelete(int disStId)
	{
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.disStId = disStId;
		string text = "";
		try
		{
			if (_003C_003Ec__DisplayClass7_.disStId > 0)
			{
				DbSet<WSDiscountStrategy> wSDiscountStrategy = _dbTbl.WSDiscountStrategy;
				ParameterExpression val = Expression.Parameter(typeof(WSDiscountStrategy), "m");
				if (Queryable.FirstOrDefault<WSDiscountStrategy>((IQueryable<WSDiscountStrategy>)wSDiscountStrategy, Expression.Lambda<Func<WSDiscountStrategy, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeleteDiscountStrategy(_003C_003Ec__DisplayClass7_.disStId));
						int result = 0;
						if (mct_II_Result != null)
						{
							int.TryParse(mct_II_Result.Result.ToString(), out result);
						}
						if (result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDiscountStrategy");
							return "1";
						}
						return Messages.RedundancyMessage;
					}
					catch (DbEntityValidationException e)
					{
						ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
						return Messages.msgErrorRunFunction;
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
					}
				}
				return Messages.ErrorNotFound;
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}

	[DynamicAuthorize(ControllerName = "frmDiscountStrategy", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int disStId = 0)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.disStId = disStId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		GetDiscountStrategyType();
		GetSystemParts();
		WSDiscountStrategyLanguageViewModel wSDiscountStrategyLanguageViewModel = new WSDiscountStrategyLanguageViewModel();
		try
		{
			WSDiscountStrategy wSDiscountStrategy = new WSDiscountStrategy();
			if (CS_0024_003C_003E8__locals0.disStId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDiscountStrategy", "actInsert", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				base.ViewBag.IsBuying = VersionBuyer.DiscountStrategy;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDiscountStrategy", "actEdit", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<WSDiscountStrategy> wSDiscountStrategy2 = _dbTbl.WSDiscountStrategy;
				ParameterExpression val = Expression.Parameter(typeof(WSDiscountStrategy), "m");
				wSDiscountStrategy = Queryable.FirstOrDefault<WSDiscountStrategy>((IQueryable<WSDiscountStrategy>)wSDiscountStrategy2, Expression.Lambda<Func<WSDiscountStrategy, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				DbSet<WSDiscountStrategy_Lang> wSDiscountStrategy_Lang = _dbTbl.WSDiscountStrategy_Lang;
				val = Expression.Parameter(typeof(WSDiscountStrategy_Lang), "c");
				List<WSDiscountStrategy_Lang> list = Enumerable.ToList<WSDiscountStrategy_Lang>((IEnumerable<WSDiscountStrategy_Lang>)Queryable.Where<WSDiscountStrategy_Lang>((IQueryable<WSDiscountStrategy_Lang>)wSDiscountStrategy_Lang, Expression.Lambda<Func<WSDiscountStrategy_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				if (wSDiscountStrategy != null)
				{
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDiscountStrategy_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDiscountStrategy_Lang>)list, (Func<WSDiscountStrategy_Lang, CommonMultiLanguageViewModel>)((WSDiscountStrategy_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.DisStTitle,
						LanguageId = item.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = wSDiscountStrategy.DisStTitle,
						LanguageId = result
					});
					wSDiscountStrategyLanguageViewModel = new WSDiscountStrategyLanguageViewModel
					{
						DiscountStrategyId = wSDiscountStrategy.DiscountStrategyId,
						DisStTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						DisStTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						DisStSystemPartId = wSDiscountStrategy.DisStSystemPartId,
						DisStDiscountStrategyTypeId = wSDiscountStrategy.DisStDiscountStrategyTypeId,
						DisStTypeValues = wSDiscountStrategy.DisStTypeValues,
						DisStExpireDate = wSDiscountStrategy.DisStExpireDate,
						DisStExpireDatePersian = (wSDiscountStrategy.DisStExpireDate.HasValue ? wSDiscountStrategy.DisStExpireDate.Value.ToString("yyyy/MM/dd") : "")
					};
					if (!string.IsNullOrWhiteSpace(wSDiscountStrategyLanguageViewModel.DisStTypeValues))
					{
						List<WSspSelectDiscountStrategyTypeValues_Result> list3 = Enumerable.ToList<WSspSelectDiscountStrategyTypeValues_Result>((IEnumerable<WSspSelectDiscountStrategyTypeValues_Result>)_dbII.WSspSelectDiscountStrategyTypeValues(wSDiscountStrategyLanguageViewModel.DiscountStrategyId, CS_0024_003C_003E8__locals0.currLangID, result));
						if (list3 != null && Enumerable.Any<WSspSelectDiscountStrategyTypeValues_Result>((IEnumerable<WSspSelectDiscountStrategyTypeValues_Result>)list3))
						{
							foreach (WSspSelectDiscountStrategyTypeValues_Result item in list3)
							{
								item.ExpDatePersian = (item.ExpDate.HasValue ? item.ExpDate.Value.ToString("yyyy/MM/dd") : "");
							}
							wSDiscountStrategyLanguageViewModel.DisStTypeValues = JsonConvert.SerializeObject(Enumerable.ToList<WSspSelectDiscountStrategyTypeValues_Result>((IEnumerable<WSspSelectDiscountStrategyTypeValues_Result>)list3));
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(wSDiscountStrategyLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDiscountStrategyDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(WSDiscountStrategyLanguageViewModel vm)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetDiscountStrategyType();
		GetSystemParts();
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.DisStTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.DisStTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.vm.DisStTitle,
					LanguageId = lCID
				});
				if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.DisStTitle))
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.OrderPaymentTypeTitle) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.DisStTitle, list))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.DisStTitle) + "<br>";
					num++;
				}
				if (CS_0024_003C_003E8__locals0.vm.DiscountStrategyId == 0 && !VersionBuyer.DiscountStrategy)
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuyWithoutCount;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				if (num == 0)
				{
					DateTime dateTime = default(DateTime);
					string text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.DisStExpireDatePersian))
						{
							text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.DisStExpireDatePersian.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
								CS_0024_003C_003E8__locals0.vm.DisStExpireDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
								CS_0024_003C_003E8__locals0.vm.DisStExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
								CS_0024_003C_003E8__locals0.vm.DisStExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							CS_0024_003C_003E8__locals0.vm.DisStExpireDate = dateTime;
						}
						else
						{
							CS_0024_003C_003E8__locals0.vm.DisStExpireDate = null;
							CS_0024_003C_003E8__locals0.vm.DisStExpireDatePersian = null;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.DisStExpireDatePersian);
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					try
					{
						_003C_003Ec__DisplayClass10_1 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_1();
						_003C_003Ec__DisplayClass10_.model = new WSDiscountStrategy();
						if (CS_0024_003C_003E8__locals0.vm.DiscountStrategyId > 0)
						{
							DbSet<WSDiscountStrategy> wSDiscountStrategy = _dbTbl.WSDiscountStrategy;
							ParameterExpression val = Expression.Parameter(typeof(WSDiscountStrategy), "m");
							_003C_003Ec__DisplayClass10_.model = Queryable.FirstOrDefault<WSDiscountStrategy>((IQueryable<WSDiscountStrategy>)wSDiscountStrategy, Expression.Lambda<Func<WSDiscountStrategy, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						}
						DateTime now = DateTime.Now;
						DateTime dateTime2 = now;
						string text3 = now.ToString("yyyyMMdd", new PersianCulture());
						short month = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType = Configuration.AppType;
						int id = Financial.Get().Id;
						int userId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass10_.model.UserId = userId;
						_003C_003Ec__DisplayClass10_.model.RegisterDate = dateTime2;
						_003C_003Ec__DisplayClass10_.model.RegisterDatePersian = text3;
						_003C_003Ec__DisplayClass10_.model.Month1 = month;
						_003C_003Ec__DisplayClass10_.model.FPId = id;
						_003C_003Ec__DisplayClass10_.model.AppType = appType;
						_003C_003Ec__DisplayClass10_.model.DisStTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						if (_003C_003Ec__DisplayClass10_.model.DiscountStrategyId == 0)
						{
							_003C_003Ec__DisplayClass10_.model.DisStSystemPartId = CS_0024_003C_003E8__locals0.vm.DisStSystemPartId;
							_003C_003Ec__DisplayClass10_.model.DisStDiscountStrategyTypeId = CS_0024_003C_003E8__locals0.vm.DisStDiscountStrategyTypeId;
						}
						_003C_003Ec__DisplayClass10_.model.DisStExpireDatePersian = CS_0024_003C_003E8__locals0.vm.DisStExpireDatePersian;
						_003C_003Ec__DisplayClass10_.model.DisStExpireDate = CS_0024_003C_003E8__locals0.vm.DisStExpireDate;
						CS_0024_003C_003E8__locals0.vm.DisStExpireDatePersian = (CS_0024_003C_003E8__locals0.vm.DisStExpireDate.HasValue ? CS_0024_003C_003E8__locals0.vm.DisStExpireDate.Value.ToString("yyyy/MM/dd") : "");
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.DisStTypeValues))
						{
							List<WSspSelectDiscountStrategyTypeValues_Result> list2 = new JavaScriptSerializer().Deserialize<List<WSspSelectDiscountStrategyTypeValues_Result>>(CS_0024_003C_003E8__locals0.vm.DisStTypeValues);
							if (list2 != null && Enumerable.Any<WSspSelectDiscountStrategyTypeValues_Result>((IEnumerable<WSspSelectDiscountStrategyTypeValues_Result>)list2))
							{
								List<WSDiscountStrategyTypeValuesViewModel> list3 = new List<WSDiscountStrategyTypeValuesViewModel>();
								foreach (WSspSelectDiscountStrategyTypeValues_Result item in list2)
								{
									WSDiscountStrategyTypeValuesViewModel wSDiscountStrategyTypeValuesViewModel = new WSDiscountStrategyTypeValuesViewModel
									{
										UserId = item.UserId,
										RollId = item.RollId,
										PrdId = item.PrdId,
										DisPer = item.DisPer,
										MnBgIsReturn = item.MnBgIsReturn,
										MnBgExpireDay = item.MnBgExpireDay
									};
									dateTime = default(DateTime);
									text2 = "";
									try
									{
										if (!string.IsNullOrWhiteSpace(item.ExpDatePersian))
										{
											text2 = PersianDate.GetFormatetdDate(item.ExpDatePersian.Replace("/", ""));
											item.ExpDate = lCID switch
											{
												1065 => DateTime.Parse(text2 + " 00:00:00", new PersianCulture()), 
												1025 => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA")), 
												_ => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US")), 
											};
										}
										else
										{
											item.ExpDate = null;
										}
									}
									catch (Exception e2)
									{
										ErrorSignal.FromCurrentContext().Raise(e2);
										base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.DisStExpireDatePersian);
										return View(CS_0024_003C_003E8__locals0.vm);
									}
									wSDiscountStrategyTypeValuesViewModel.ExpDate = item.ExpDate;
									list3.Add(wSDiscountStrategyTypeValuesViewModel);
								}
								if (list3 != null)
								{
									_003C_003Ec__DisplayClass10_.model.DisStTypeValues = JsonConvert.SerializeObject(Enumerable.ToList<WSDiscountStrategyTypeValuesViewModel>((IEnumerable<WSDiscountStrategyTypeValuesViewModel>)list3));
								}
							}
						}
						if (_003C_003Ec__DisplayClass10_.model.DiscountStrategyId > 0)
						{
							_dbTbl.Entry(_003C_003Ec__DisplayClass10_.model).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							if (_003C_003Ec__DisplayClass10_.model.DiscountStrategyId != 0)
							{
								using List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
								while (enumerator2.MoveNext())
								{
									_003C_003Ec__DisplayClass10_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass10_2();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass10_;
									CS_0024_003C_003E8__locals1.lang = enumerator2.Current;
									DbSet<WSDiscountStrategy_Lang> wSDiscountStrategy_Lang = _dbTbl.WSDiscountStrategy_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSDiscountStrategy_Lang), "c");
									WSDiscountStrategy_Lang wSDiscountStrategy_Lang2 = Queryable.FirstOrDefault<WSDiscountStrategy_Lang>((IQueryable<WSDiscountStrategy_Lang>)wSDiscountStrategy_Lang, Expression.Lambda<Func<WSDiscountStrategy_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (wSDiscountStrategy_Lang2 != null)
									{
										wSDiscountStrategy_Lang2.DisStTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(wSDiscountStrategy_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									wSDiscountStrategy_Lang2 = new WSDiscountStrategy_Lang
									{
										LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
										DiscountStrategyId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.DiscountStrategyId,
										DisStTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
									};
									_dbTbl.WSDiscountStrategy_Lang.Add(wSDiscountStrategy_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDiscountStrategy");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							_003C_003Ec__DisplayClass10_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
							_003C_003Ec__DisplayClass10_.model.FirstRegisterDate = dateTime2;
							_003C_003Ec__DisplayClass10_.model.FirstRegisterDatePersian = text3;
							_003C_003Ec__DisplayClass10_.model.FirstRegisterUserId = userId;
							_003C_003Ec__DisplayClass10_.model.GUId = Guid.NewGuid();
							_dbTbl.WSDiscountStrategy.Add(_003C_003Ec__DisplayClass10_.model);
							_dbTbl.SaveChanges();
							if (_003C_003Ec__DisplayClass10_.model.DiscountStrategyId > 0)
							{
								foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
								{
									WSDiscountStrategy_Lang entity = new WSDiscountStrategy_Lang
									{
										LanguageID = lang.LanguageID,
										DiscountStrategyId = _003C_003Ec__DisplayClass10_.model.DiscountStrategyId,
										DisStTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
									};
									_dbTbl.WSDiscountStrategy_Lang.Add(entity);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDiscountStrategy");
							CS_0024_003C_003E8__locals0.vm.DiscountStrategyId = _003C_003Ec__DisplayClass10_.model.DiscountStrategyId;
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass10_.model.DisStTypeValues))
						{
							List<WSspSelectDiscountStrategyTypeValues_Result> list4 = Enumerable.ToList<WSspSelectDiscountStrategyTypeValues_Result>((IEnumerable<WSspSelectDiscountStrategyTypeValues_Result>)_dbII.WSspSelectDiscountStrategyTypeValues(_003C_003Ec__DisplayClass10_.model.DiscountStrategyId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (list4 != null && Enumerable.Any<WSspSelectDiscountStrategyTypeValues_Result>((IEnumerable<WSspSelectDiscountStrategyTypeValues_Result>)list4))
							{
								foreach (WSspSelectDiscountStrategyTypeValues_Result item2 in list4)
								{
									item2.ExpDatePersian = (item2.ExpDate.HasValue ? item2.ExpDate.Value.ToString("yyyy/MM/dd") : "");
								}
								CS_0024_003C_003E8__locals0.vm.DisStTypeValues = JsonConvert.SerializeObject(Enumerable.ToList<WSspSelectDiscountStrategyTypeValues_Result>((IEnumerable<WSspSelectDiscountStrategyTypeValues_Result>)list4));
							}
						}
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
	public JsonResult GetDiscountStrategyType()
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
			List<WSspSelectDiscountStrategyType_Result> list2 = Enumerable.ToList<WSspSelectDiscountStrategyType_Result>((IEnumerable<WSspSelectDiscountStrategyType_Result>)_dbII.WSspSelectDiscountStrategyType(lCID, result));
			if (list2 != null && Enumerable.Any<WSspSelectDiscountStrategyType_Result>((IEnumerable<WSspSelectDiscountStrategyType_Result>)list2))
			{
				list.AddRange(Enumerable.Select<WSspSelectDiscountStrategyType_Result, SelectListItem>((IEnumerable<WSspSelectDiscountStrategyType_Result>)list2, (Func<WSspSelectDiscountStrategyType_Result, SelectListItem>)((WSspSelectDiscountStrategyType_Result item) => new SelectListItem
				{
					Text = item.DiscountStrategyTypeTitle,
					Value = item.DiscountStrategyTypeId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DiscountStrategyTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSystemParts()
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
			List<CRMspSelectActiveSystemParts_Result> list2 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_dbI.CRMspSelectActiveSystemParts(lCID, result, "20,30"));
			if (list2 != null && Enumerable.Any<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list2))
			{
				list.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, SelectListItem>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list2, (Func<CRMspSelectActiveSystemParts_Result, SelectListItem>)((CRMspSelectActiveSystemParts_Result item) => new SelectListItem
				{
					Text = item.PartTitle,
					Value = item.SystemPartId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SystemPartList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}
}
