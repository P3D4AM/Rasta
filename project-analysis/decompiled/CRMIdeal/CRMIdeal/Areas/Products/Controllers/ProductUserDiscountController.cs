using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Products.Controllers;

public class ProductUserDiscountController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int pudId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int defLangID;

		public WSProductsUserDiscountLanguageViewModel vm;

		public Func<Languages, bool> _003C_003E9__4;

		public Func<Languages, bool> _003C_003E9__12;

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals1;

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

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actSetPrdUserDiscount")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult SelectProductsUserDiscountByPrdGroupId(int prdGroupId)
	{
		return Json(SelectProductsUserDiscountByPrdGroupIdItem(prdGroupId), JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectProductsUserDiscountByPrdGroupId_Result> SelectProductsUserDiscountByPrdGroupIdItem(int prdGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductsUserDiscountByPrdGroupId_Result> list = new List<WSspSelectProductsUserDiscountByPrdGroupId_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectProductsUserDiscountByPrdGroupId_Result>((IEnumerable<WSspSelectProductsUserDiscountByPrdGroupId_Result>)_db.WSspSelectProductsUserDiscountByPrdGroupId(prdGroupId, lCID, result));
			foreach (WSspSelectProductsUserDiscountByPrdGroupId_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				item.EditUser = item.EditUser + " (" + Labels.AppType + ":" + item.AppType + ")";
				_ = item.FirstRegisterDate;
				item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				_ = item.RegisterDate;
				item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult SelectProductsUserDiscountByPrdGroupId_Read([DataSourceRequest] DataSourceRequest request, int prdGroupId)
	{
		List<WSspSelectProductsUserDiscountByPrdGroupId_Result> enumerable = SelectProductsUserDiscountByPrdGroupIdItem(prdGroupId);
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmProductUserDiscount", ActionName = "actDelete")]
	[AjaxOnly]
	public string ProductUserDiscountDelete(int pudId)
	{
		string result = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmProductUserDiscount", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (pudId > 0)
			{
				if (_dbTbl.WSProductsUserDiscount.Find(pudId) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSProductsUserDiscount(pudId)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductsUserDiscount");
							result = "1";
						}
					}
					catch (DbEntityValidationException e)
					{
						ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
						result = Messages.RedundancyMessage;
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
					}
				}
				else
				{
					result = Messages.ErrorNotFound;
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmProductUserDiscount", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int prdGroupId, int pudId)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.pudId = pudId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSProductsUserDiscountLanguageViewModel wSProductsUserDiscountLanguageViewModel = new WSProductsUserDiscountLanguageViewModel();
		DateTime now = DateTime.Now;
		try
		{
			if (CS_0024_003C_003E8__locals0.pudId > 0)
			{
				if (!UserLogin.IsUserAccess("frmProductUserDiscount", "actEdit"))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<WSProductsUserDiscount_Lang> wSProductsUserDiscount_Lang = _dbTbl.WSProductsUserDiscount_Lang;
				ParameterExpression val = Expression.Parameter(typeof(WSProductsUserDiscount_Lang), "c");
				List<WSProductsUserDiscount_Lang> list = Enumerable.ToList<WSProductsUserDiscount_Lang>((IEnumerable<WSProductsUserDiscount_Lang>)Queryable.Where<WSProductsUserDiscount_Lang>((IQueryable<WSProductsUserDiscount_Lang>)wSProductsUserDiscount_Lang, Expression.Lambda<Func<WSProductsUserDiscount_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				WSProductsUserDiscount wSProductsUserDiscount = _dbTbl.WSProductsUserDiscount.Find(CS_0024_003C_003E8__locals0.pudId);
				if (wSProductsUserDiscount == null)
				{
					wSProductsUserDiscountLanguageViewModel = new WSProductsUserDiscountLanguageViewModel
					{
						ProductGroupId = prdGroupId,
						ProductsUserDiscountId = CS_0024_003C_003E8__locals0.pudId,
						ProductsUserDiscountDateTime = now,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDate = now,
						FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture())
					};
				}
				else
				{
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductsUserDiscount_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductsUserDiscount_Lang>)list, (Func<WSProductsUserDiscount_Lang, CommonMultiLanguageViewModel>)((WSProductsUserDiscount_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.Description,
						LanguageId = item.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = wSProductsUserDiscount.Description,
						LanguageId = result
					});
					wSProductsUserDiscountLanguageViewModel = new WSProductsUserDiscountLanguageViewModel
					{
						UserId = wSProductsUserDiscount.UserId,
						FirstRegisterUserId = wSProductsUserDiscount.FirstRegisterUserId,
						FirstRegisterDatePersian = wSProductsUserDiscount.FirstRegisterDatePersian,
						FirstRegisterDate = wSProductsUserDiscount.FirstRegisterDate,
						DiscountAllPrdInGroup = wSProductsUserDiscount.DiscountAllPrdInGroup,
						AppType = wSProductsUserDiscount.AppType,
						GUId = wSProductsUserDiscount.GUId,
						RegisterDate = wSProductsUserDiscount.RegisterDate,
						Month1 = wSProductsUserDiscount.Month1,
						DiscountAllUser = wSProductsUserDiscount.DiscountAllUser,
						DiscountPercent = wSProductsUserDiscount.DiscountPercent,
						DiscountProductId = wSProductsUserDiscount.DiscountProductId,
						DiscountUserId = wSProductsUserDiscount.DiscountUserId,
						FPId = wSProductsUserDiscount.FPId,
						ProductGroupId = wSProductsUserDiscount.ProductGroupId,
						ProductsUserDiscountDate = wSProductsUserDiscount.ProductsUserDiscountDate,
						ProductsUserDiscountDateTime = wSProductsUserDiscount.ProductsUserDiscountDateTime,
						ProductsUserDiscountId = wSProductsUserDiscount.ProductsUserDiscountId,
						RegisterDatePersian = wSProductsUserDiscount.RegisterDatePersian,
						Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
					};
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmProductUserDiscount", "actInsert"))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				wSProductsUserDiscountLanguageViewModel = new WSProductsUserDiscountLanguageViewModel
				{
					ProductGroupId = prdGroupId,
					ProductsUserDiscountDateTime = now,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture())
				};
			}
			wSProductsUserDiscountLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
			wSProductsUserDiscountLanguageViewModel.FPId = short.Parse(Financial.Get().Id.ToString());
			wSProductsUserDiscountLanguageViewModel.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
			wSProductsUserDiscountLanguageViewModel.RegisterDate = now;
			wSProductsUserDiscountLanguageViewModel.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			wSProductsUserDiscountLanguageViewModel.AppType = Configuration.AppType;
			GetUser();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(wSProductsUserDiscountLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductUserDiscountDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WSProductsUserDiscountLanguageViewModel vm)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Description_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Description_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Description,
			LanguageId = lCID
		});
		try
		{
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				CS_0024_003C_003E8__locals0.vm.ProductsUserDiscountDate = CS_0024_003C_003E8__locals0.vm.ProductsUserDiscountDateTime.ToString("yyyyMMdd", new PersianCulture());
				if (CS_0024_003C_003E8__locals0.vm.DiscountAllUser == false)
				{
					CS_0024_003C_003E8__locals0.vm.DiscountAllUser = null;
				}
				else if (CS_0024_003C_003E8__locals0.vm.DiscountAllUser.HasValue && CS_0024_003C_003E8__locals0.vm.DiscountAllUser.GetValueOrDefault())
				{
					CS_0024_003C_003E8__locals0.vm.DiscountUserId = null;
				}
				if (CS_0024_003C_003E8__locals0.vm.DiscountAllPrdInGroup == false)
				{
					CS_0024_003C_003E8__locals0.vm.DiscountAllPrdInGroup = null;
				}
				else if (CS_0024_003C_003E8__locals0.vm.DiscountAllPrdInGroup.HasValue && CS_0024_003C_003E8__locals0.vm.DiscountAllPrdInGroup.GetValueOrDefault())
				{
					CS_0024_003C_003E8__locals0.vm.DiscountProductId = null;
				}
				DateTime now = DateTime.Now;
				if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)_db.WSspCheckDuplicateUserPrdInProductsUserDiscount(CS_0024_003C_003E8__locals0.vm.ProductsUserDiscountId, CS_0024_003C_003E8__locals0.vm.ProductGroupId, CS_0024_003C_003E8__locals0.vm.DiscountAllUser.HasValue && CS_0024_003C_003E8__locals0.vm.DiscountAllUser != false, CS_0024_003C_003E8__locals0.vm.DiscountAllPrdInGroup.HasValue && CS_0024_003C_003E8__locals0.vm.DiscountAllPrdInGroup != false, CS_0024_003C_003E8__locals0.vm.UserId, CS_0024_003C_003E8__locals0.vm.DiscountProductId.GetValueOrDefault()))).HasValue)
				{
					base.ViewBag.Error = Messages.frmRecordDuplicate;
				}
				else if (CS_0024_003C_003E8__locals0.vm.ProductsUserDiscountId > 0)
				{
					WSProductsUserDiscount wSProductsUserDiscount = _dbTbl.WSProductsUserDiscount.Find(CS_0024_003C_003E8__locals0.vm.ProductsUserDiscountId);
					if (wSProductsUserDiscount != null)
					{
						wSProductsUserDiscount.UserId = UserLogin.CurrentUser.UserId;
						wSProductsUserDiscount.FPId = short.Parse(Financial.Get().Id.ToString());
						wSProductsUserDiscount.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						wSProductsUserDiscount.RegisterDate = now;
						wSProductsUserDiscount.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						wSProductsUserDiscount.AppType = Configuration.AppType;
						wSProductsUserDiscount.ProductGroupId = CS_0024_003C_003E8__locals0.vm.ProductGroupId;
						wSProductsUserDiscount.ProductsUserDiscountDate = CS_0024_003C_003E8__locals0.vm.ProductsUserDiscountDate;
						wSProductsUserDiscount.ProductsUserDiscountDateTime = CS_0024_003C_003E8__locals0.vm.ProductsUserDiscountDateTime;
						wSProductsUserDiscount.DiscountAllPrdInGroup = CS_0024_003C_003E8__locals0.vm.DiscountAllPrdInGroup;
						wSProductsUserDiscount.DiscountAllUser = CS_0024_003C_003E8__locals0.vm.DiscountAllUser;
						wSProductsUserDiscount.DiscountPercent = CS_0024_003C_003E8__locals0.vm.DiscountPercent;
						wSProductsUserDiscount.DiscountProductId = CS_0024_003C_003E8__locals0.vm.DiscountProductId;
						wSProductsUserDiscount.DiscountUserId = CS_0024_003C_003E8__locals0.vm.DiscountUserId;
						wSProductsUserDiscount.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						_dbTbl.Entry(wSProductsUserDiscount).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass9_1();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<WSProductsUserDiscount_Lang> wSProductsUserDiscount_Lang = _dbTbl.WSProductsUserDiscount_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSProductsUserDiscount_Lang), "c");
								WSProductsUserDiscount_Lang wSProductsUserDiscount_Lang2 = Queryable.FirstOrDefault<WSProductsUserDiscount_Lang>((IQueryable<WSProductsUserDiscount_Lang>)wSProductsUserDiscount_Lang, Expression.Lambda<Func<WSProductsUserDiscount_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSProductsUserDiscount_Lang2 != null)
								{
									wSProductsUserDiscount_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSProductsUserDiscount_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSProductsUserDiscount_Lang2 = new WSProductsUserDiscount_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									ProductsUserDiscountId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.vm.ProductsUserDiscountId,
									Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.WSProductsUserDiscount_Lang.Add(wSProductsUserDiscount_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductsUserDiscount");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
				}
				else
				{
					WSProductsUserDiscount wSProductsUserDiscount2 = new WSProductsUserDiscount
					{
						UserId = UserLogin.CurrentUser.UserId,
						FPId = short.Parse(Financial.Get().Id.ToString()),
						Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
						RegisterDate = now,
						RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						AppType = Configuration.AppType,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDate = now,
						FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						GUId = Guid.NewGuid(),
						ProductGroupId = CS_0024_003C_003E8__locals0.vm.ProductGroupId,
						ProductsUserDiscountDate = CS_0024_003C_003E8__locals0.vm.ProductsUserDiscountDate,
						ProductsUserDiscountDateTime = CS_0024_003C_003E8__locals0.vm.ProductsUserDiscountDateTime,
						LanguageID = CS_0024_003C_003E8__locals0.defLangID,
						DiscountAllPrdInGroup = CS_0024_003C_003E8__locals0.vm.DiscountAllPrdInGroup,
						DiscountAllUser = CS_0024_003C_003E8__locals0.vm.DiscountAllUser,
						DiscountPercent = CS_0024_003C_003E8__locals0.vm.DiscountPercent,
						DiscountProductId = CS_0024_003C_003E8__locals0.vm.DiscountProductId,
						DiscountUserId = CS_0024_003C_003E8__locals0.vm.DiscountUserId,
						Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null)
					};
					_dbTbl.WSProductsUserDiscount.Add(wSProductsUserDiscount2);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSProductsUserDiscount_Lang entity = new WSProductsUserDiscount_Lang
						{
							LanguageID = lang.LanguageID,
							ProductsUserDiscountId = wSProductsUserDiscount2.ProductsUserDiscountId,
							Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.WSProductsUserDiscount_Lang.Add(entity);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductsUserDiscount");
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ex2.Message;
		}
		GetUser();
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public JsonResult GetUser()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUsersForProductsUserDiscount_Result> list2 = Enumerable.ToList<CRMspSelectUsersForProductsUserDiscount_Result>((IEnumerable<CRMspSelectUsersForProductsUserDiscount_Result>)_db.CRMspSelectUsersForProductsUserDiscount(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUsersForProductsUserDiscount_Result, SelectListItem>((IEnumerable<CRMspSelectUsersForProductsUserDiscount_Result>)list2, (Func<CRMspSelectUsersForProductsUserDiscount_Result, SelectListItem>)((CRMspSelectUsersForProductsUserDiscount_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProducts(int prdGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		List<WSspSelectProductByGroup_Result> list = new List<WSspSelectProductByGroup_Result>();
		try
		{
			List<WSspSelectProductByGroup_Result> list2 = Enumerable.ToList<WSspSelectProductByGroup_Result>((IEnumerable<WSspSelectProductByGroup_Result>)_dbI.WSspSelectProductByGroup(prdGroupId, lCID, result, centerId));
			WSspSelectProductByGroup_Result wSspSelectProductByGroup_Result = new WSspSelectProductByGroup_Result();
			wSspSelectProductByGroup_Result.ProductID = 0;
			wSspSelectProductByGroup_Result.PrdName = Labels.SelectedListDefValue;
			list.Add(wSspSelectProductByGroup_Result);
			list.AddRange(Enumerable.Select<WSspSelectProductByGroup_Result, WSspSelectProductByGroup_Result>((IEnumerable<WSspSelectProductByGroup_Result>)list2, (Func<WSspSelectProductByGroup_Result, WSspSelectProductByGroup_Result>)((WSspSelectProductByGroup_Result item) => new WSspSelectProductByGroup_Result
			{
				ProductID = item.ProductID,
				PrdName = item.PrdName
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
