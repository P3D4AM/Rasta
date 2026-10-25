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

public class LinkedProductsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public WSLinkedProductsViewModel vm;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int linkedProductId;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actLinkedProducts")]
	public ActionResult Index(int prdId)
	{
		base.ViewBag.prdId = prdId;
		base.ViewBag.PrdFirstGroups = GetPrdFirstGroupsTree();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actLinkedProducts")]
	[AjaxOnly]
	public ActionResult LinkedProducts_Read([DataSourceRequest] DataSourceRequest request, int prdId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectLinkedProducts_Result> enumerable = new List<WSspSelectLinkedProducts_Result>();
		try
		{
			enumerable = Enumerable.ToList<WSspSelectLinkedProducts_Result>((IEnumerable<WSspSelectLinkedProducts_Result>)_db.WSspSelectLinkedProducts(prdId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmLinkedProducts", ActionName = "actLinkedProductsDelete")]
	public string LinkedProductDelete(int prdId, int productIdForLoad)
	{
		string result = "";
		try
		{
			if (prdId != 0 && productIdForLoad != 0)
			{
				_db.WSspDeleteLinkedProduct(prdId, productIdForLoad);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSLinkedProducts");
			}
			else
			{
				result = Messages.msgNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmLinkedProducts", ActionName = "actLinkedProductAdd")]
	public string LinkedProductAdd(int prdId, int searchPrdId, float linkedPrdQuantity, bool linkedPrdNotInSum, bool linkedPrdNotVisible, bool linkedPrdAddQuantity, bool linkedPrdAddPrice, bool linkedPrdAddDiscount = false, bool linkedPrdIsSelect = false, int? orderView = null)
	{
		string result = "";
		try
		{
			if (prdId != 0 && searchPrdId != 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				string text = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int value2 = int.Parse(Financial.Get().Id.ToString());
				_db.WSspInsertLinkedProduct(prdId, searchPrdId, userId, value2, value, now, text, appType, result2, linkedPrdQuantity, linkedPrdNotInSum: linkedPrdNotInSum, linkedPrdNotVisible: linkedPrdNotVisible, linkedPrdAddQuantity: linkedPrdAddQuantity, linkedPrdAddPrice: linkedPrdAddPrice, linkedPrdAddDiscount: linkedPrdAddDiscount, linkedPrdIsSelect: linkedPrdIsSelect, orderView: orderView);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSLinkedProducts");
			}
			else
			{
				result = Messages.msgNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmLinkedProducts", ActionName = "actLinkedProductsDeleteAll")]
	public string LinkedProductsDeleteAll(int prdId)
	{
		string result = "";
		try
		{
			if (prdId != 0)
			{
				_db.WSspDeleteAllLinkedProducts(prdId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSLinkedProducts");
			}
			else
			{
				result = Messages.msgErrorNotSelectProduct;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	public void SetLinkedPrdRegisterInfo(WSLinkedProductsViewModel model, ref string firstRegInfo, ref string regInfo)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (model == null)
			{
				return;
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId);
			if (cRMspSelectUsersById_Result != null)
			{
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.LName)) ? cRMspSelectUsersById_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.FName)) ? (" " + cRMspSelectUsersById_Result.FName) : "");
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
			if (cRMspSelectUsersById_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.LName)) ? cRMspSelectUsersById_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.FName)) ? (" " + cRMspSelectUsersById_Result2.FName) : "");
				_ = model.RegisterDate;
				string text2 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(model.AppType))
				{
					model.AppType = Configuration.AppType;
				}
				string text3 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
				regInfo = regInfo + " (" + text3 + ")" + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[DynamicAuthorize(ControllerName = "frmLinkedProducts", ActionName = "actLinkedProductAdd,actLinkedProductEdit")]
	public ActionResult InsertEdit(int prdId, int linkedProductId)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_.linkedProductId = linkedProductId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WSLinkedProductsViewModel wSLinkedProductsViewModel = new WSLinkedProductsViewModel();
		if (_003C_003Ec__DisplayClass9_.linkedProductId > 0)
		{
			if (!UserLogin.IsUserAccess("frmLinkedProducts", "actLinkedProductEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<WSLinkedProducts> wSLinkedProducts = _dbTbl.WSLinkedProducts;
			ParameterExpression val = Expression.Parameter(typeof(WSLinkedProducts), "c");
			WSLinkedProducts wSLinkedProducts2 = Queryable.FirstOrDefault<WSLinkedProducts>((IQueryable<WSLinkedProducts>)wSLinkedProducts, Expression.Lambda<Func<WSLinkedProducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSLinkedProducts2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			wSLinkedProductsViewModel = new WSLinkedProductsViewModel
			{
				LinkedProductId = wSLinkedProducts2.LinkedProductId,
				PrdId = wSLinkedProducts2.PrdId,
				LinkedPrdId = wSLinkedProducts2.LinkedPrdId,
				LinkedPrdQuantity = wSLinkedProducts2.LinkedPrdQuantity,
				LinkedPrdNotVisible = wSLinkedProducts2.LinkedPrdNotVisible,
				LinkedPrdNotInSum = wSLinkedProducts2.LinkedPrdNotInSum,
				LinkedPrdAddQuantity = wSLinkedProducts2.LinkedPrdAddQuantity,
				LinkedPrdAddPrice = wSLinkedProducts2.LinkedPrdAddPrice,
				FirstRegisterUserId = wSLinkedProducts2.FirstRegisterUserId,
				FirstRegisterDate = wSLinkedProducts2.FirstRegisterDate,
				FirstRegisterDatePersian = wSLinkedProducts2.FirstRegisterDatePersian,
				UserId = wSLinkedProducts2.UserId,
				RegisterDate = wSLinkedProducts2.RegisterDate,
				RegisterDatePersian = wSLinkedProducts2.RegisterDatePersian,
				AppType = wSLinkedProducts2.AppType,
				LinkedPrdAddDiscount = wSLinkedProducts2.LinkedPrdAddDiscount,
				LinkedPrdIsSelect = wSLinkedProducts2.LinkedPrdIsSelect,
				OrderView = wSLinkedProducts2.OrderView
			};
			_ = wSLinkedProductsViewModel.LinkedPrdId;
			WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(wSLinkedProductsViewModel.LinkedPrdId, lCID, result));
			if (wSspSelectProductsWithId_Result != null)
			{
				wSLinkedProductsViewModel.LinkedPrdName = wSspSelectProductsWithId_Result.PrdName ?? "";
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmLinkedProducts", "actLinkedProductAdd"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			wSLinkedProductsViewModel = new WSLinkedProductsViewModel
			{
				PrdId = prdId,
				LinkedPrdQuantity = 1.0,
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDate = now,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				AppType = Configuration.AppType,
				LinkedPrdIsSelect = true
			};
			if (!Enumerable.Any<WSspSelectLinkedProducts_Result>((IEnumerable<WSspSelectLinkedProducts_Result>)Enumerable.ToList<WSspSelectLinkedProducts_Result>((IEnumerable<WSspSelectLinkedProducts_Result>)_db.WSspSelectLinkedProducts(prdId, lCID, result))))
			{
				wSLinkedProductsViewModel.OrderView = 10;
			}
		}
		_ = wSLinkedProductsViewModel.PrdId;
		WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result2 = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(wSLinkedProductsViewModel.PrdId, lCID, result));
		if (wSspSelectProductsWithId_Result2 != null)
		{
			wSLinkedProductsViewModel.PrdName = wSspSelectProductsWithId_Result2.PrdName ?? "";
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetLinkedPrdRegisterInfo(wSLinkedProductsViewModel, ref firstRegInfo, ref regInfo);
		wSLinkedProductsViewModel.FirstRegisterUser = firstRegInfo;
		wSLinkedProductsViewModel.EditUser = regInfo;
		return View(wSLinkedProductsViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmLinkedProducts", ActionName = "actLinkedProductAdd,actLinkedProductEdit")]
	public ActionResult InsertEdit(WSLinkedProductsViewModel vm)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid)
		{
			try
			{
				if (num == 0)
				{
					if (!base.ModelState.IsValid)
					{
						base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
					}
					else
					{
						WSLinkedProducts wSLinkedProducts = new WSLinkedProducts();
						if (_003C_003Ec__DisplayClass10_.vm.LinkedProductId > 0)
						{
							DbSet<WSLinkedProducts> wSLinkedProducts2 = _dbTbl.WSLinkedProducts;
							ParameterExpression val = Expression.Parameter(typeof(WSLinkedProducts), "c");
							wSLinkedProducts = Queryable.FirstOrDefault<WSLinkedProducts>((IQueryable<WSLinkedProducts>)wSLinkedProducts2, Expression.Lambda<Func<WSLinkedProducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						}
						wSLinkedProducts.UserId = UserLogin.CurrentUser.UserId;
						DateTime firstRegisterDate = (wSLinkedProducts.RegisterDate = DateTime.Now);
						wSLinkedProducts.RegisterDatePersian = firstRegisterDate.ToString("yyyyMMdd", new PersianCulture());
						wSLinkedProducts.Month1 = short.Parse(firstRegisterDate.ToString("MM", new PersianCulture()));
						wSLinkedProducts.AppType = Configuration.AppType;
						wSLinkedProducts.FPId = int.Parse(Financial.Get().Id.ToString());
						wSLinkedProducts.PrdId = _003C_003Ec__DisplayClass10_.vm.PrdId;
						wSLinkedProducts.LinkedPrdId = _003C_003Ec__DisplayClass10_.vm.LinkedPrdId;
						wSLinkedProducts.LinkedPrdQuantity = _003C_003Ec__DisplayClass10_.vm.LinkedPrdQuantity;
						wSLinkedProducts.LinkedPrdNotVisible = _003C_003Ec__DisplayClass10_.vm.LinkedPrdNotVisible;
						wSLinkedProducts.LinkedPrdNotInSum = _003C_003Ec__DisplayClass10_.vm.LinkedPrdNotInSum;
						wSLinkedProducts.LinkedPrdAddQuantity = _003C_003Ec__DisplayClass10_.vm.LinkedPrdAddQuantity;
						wSLinkedProducts.LinkedPrdAddPrice = _003C_003Ec__DisplayClass10_.vm.LinkedPrdAddPrice;
						wSLinkedProducts.LinkedPrdAddDiscount = _003C_003Ec__DisplayClass10_.vm.LinkedPrdAddDiscount;
						wSLinkedProducts.LinkedPrdIsSelect = _003C_003Ec__DisplayClass10_.vm.LinkedPrdIsSelect;
						wSLinkedProducts.OrderView = _003C_003Ec__DisplayClass10_.vm.OrderView;
						if (wSLinkedProducts.LinkedProductId > 0)
						{
							_dbTbl.Entry(wSLinkedProducts).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSLinkedProducts");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							if (!_003C_003Ec__DisplayClass10_.vm.OrderView.HasValue)
							{
								List<WSspSelectLinkedProducts_Result> list = Enumerable.ToList<WSspSelectLinkedProducts_Result>((IEnumerable<WSspSelectLinkedProducts_Result>)_db.WSspSelectLinkedProducts(wSLinkedProducts.PrdId, lCID, result));
								int num2 = (Enumerable.Any<WSspSelectLinkedProducts_Result>((IEnumerable<WSspSelectLinkedProducts_Result>)list) ? Enumerable.Count<WSspSelectLinkedProducts_Result>((IEnumerable<WSspSelectLinkedProducts_Result>)list) : 0);
								wSLinkedProducts.OrderView = num2 * 10 + 10;
								if (Enumerable.LastOrDefault<WSspSelectLinkedProducts_Result>((IEnumerable<WSspSelectLinkedProducts_Result>)list) != null)
								{
									int valueOrDefault = Enumerable.LastOrDefault<WSspSelectLinkedProducts_Result>((IEnumerable<WSspSelectLinkedProducts_Result>)list).OrderView.GetValueOrDefault();
									if (valueOrDefault > 0)
									{
										wSLinkedProducts.OrderView = valueOrDefault + 10;
									}
								}
							}
							else
							{
								wSLinkedProducts.OrderView = _003C_003Ec__DisplayClass10_.vm.OrderView;
							}
							wSLinkedProducts.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
							wSLinkedProducts.FirstRegisterDate = firstRegisterDate;
							wSLinkedProducts.FirstRegisterDatePersian = firstRegisterDate.ToString("yyyyMMdd", new PersianCulture());
							wSLinkedProducts.LanguageID = result;
							wSLinkedProducts.GUId = Guid.NewGuid();
							_dbTbl.WSLinkedProducts.Add(wSLinkedProducts);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSLinkedProducts");
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						_003C_003Ec__DisplayClass10_.vm.LinkedProductId = wSLinkedProducts.LinkedProductId;
						_003C_003Ec__DisplayClass10_.vm.UserId = wSLinkedProducts.UserId;
						_003C_003Ec__DisplayClass10_.vm.FirstRegisterUserId = wSLinkedProducts.FirstRegisterUserId;
						_003C_003Ec__DisplayClass10_.vm.RegisterDate = wSLinkedProducts.RegisterDate;
						_003C_003Ec__DisplayClass10_.vm.FirstRegisterDate = wSLinkedProducts.FirstRegisterDate;
						_003C_003Ec__DisplayClass10_.vm.AppType = wSLinkedProducts.AppType;
						string firstRegInfo = "";
						string regInfo = "";
						SetLinkedPrdRegisterInfo(_003C_003Ec__DisplayClass10_.vm, ref firstRegInfo, ref regInfo);
						_003C_003Ec__DisplayClass10_.vm.FirstRegisterUser = firstRegInfo;
						_003C_003Ec__DisplayClass10_.vm.EditUser = regInfo;
						_ = _003C_003Ec__DisplayClass10_.vm.LinkedPrdId;
						WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(_003C_003Ec__DisplayClass10_.vm.LinkedPrdId, lCID, result));
						if (wSspSelectProductsWithId_Result != null)
						{
							_003C_003Ec__DisplayClass10_.vm.LinkedPrdName = wSspSelectProductsWithId_Result.PrdName ?? "";
						}
					}
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
				text = Messages.msgErrorRunFunction + "<br/>" + ex.Message;
			}
		}
		base.ViewBag.Error = text;
		return View(_003C_003Ec__DisplayClass10_.vm);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrdFirstGroupsTree()
	{
		List<nTreeItemViewModel> list = new List<nTreeItemViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductFirstGroup_Result> list2 = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectProductFirstGroup_Result, nTreeItemViewModel>((IEnumerable<WSspSelectProductFirstGroup_Result>)list2, (Func<WSspSelectProductFirstGroup_Result, nTreeItemViewModel>)((WSspSelectProductFirstGroup_Result x) => new nTreeItemViewModel
				{
					KeyId = x.PrdFirstGroupID.ToString(),
					KeyName = x.FGName,
					ParentId = "0"
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrdSecondGroupsTree(int? fgId = 0)
	{
		List<nTreeItemViewModel> list = new List<nTreeItemViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductSecondGroup_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(fgId, lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectProductSecondGroup_Result, nTreeItemViewModel>((IEnumerable<WSspSelectProductSecondGroup_Result>)list2, (Func<WSspSelectProductSecondGroup_Result, nTreeItemViewModel>)((WSspSelectProductSecondGroup_Result x) => new nTreeItemViewModel
				{
					KeyId = x.PrdSecondGroupID.ToString(),
					KeyName = x.SGName,
					ParentId = x.FirstGroupId.ToString(),
					ChildsCnt = 0
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmLinkedProducts", ActionName = "actLinkedProductAddMulti")]
	public string InsertLinkedProductMulti(int prdId = 0, int? sgId = null, string selectedGroupsJson = "")
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			if (0 == 0 && UserLogin.CurrentUser != null)
			{
				UserLogin.CurrentUser.UserLastCId.GetValueOrDefault();
			}
			Enumerable.FirstOrDefault<WSspInsertLinkedProductMulti_Result>((IEnumerable<WSspInsertLinkedProductMulti_Result>)_dbII.WSspInsertLinkedProductMulti(prdId, sgId, selectedGroupsJson, userId, id, value2, value, registerDatePersian, appType, lCID));
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.MsgErrorDoneOperation;
		}
		return result;
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmLinkedProducts", ActionName = "actLinkedProductsDeleteByPrdGroup")]
	public string DeleteProductLinksByPrdGroup(int? sgId = 0)
	{
		string result = "";
		try
		{
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeleteLinkedProductByPrdGroup(sgId));
			if (mct_II_Result == null || mct_II_Result.Result == 0)
			{
				result = Messages.MsgErrorDoneOperation;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.MsgErrorDoneOperation;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
