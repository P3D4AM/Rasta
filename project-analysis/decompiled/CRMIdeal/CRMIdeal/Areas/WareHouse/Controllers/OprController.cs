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
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class OprController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public WSDocOprLanguageViewModel model;

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
		public WSDocOpr opr;
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
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public int oprId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int oprId;

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

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actwhDocOpr")]
	public ActionResult Index()
	{
		return View();
	}

	public List<WSspSelectDocOpr_Result> ListOprs()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectDocOpr_Result> list = new List<WSspSelectDocOpr_Result>();
		try
		{
			list = Doc.SelecDocOpr(lCID, result);
			if (list == null)
			{
				list = new List<WSspSelectDocOpr_Result>();
			}
			if (list != null && Enumerable.Any<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)list))
			{
				foreach (WSspSelectDocOpr_Result item in list)
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
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult ListOprs_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListOprs()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GetListOprs()
	{
		return Json(ListOprs(), JsonRequestBehavior.AllowGet);
	}

	public ActionResult InsertEdit(int oprId = 0)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.oprId = oprId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSDocOprLanguageViewModel wSDocOprLanguageViewModel = new WSDocOprLanguageViewModel();
		try
		{
			DbSet<WSDocOpr_Lang> wSDocOpr_Lang = _dbTbl.WSDocOpr_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSDocOpr_Lang), "c");
			List<WSDocOpr_Lang> list = Enumerable.ToList<WSDocOpr_Lang>((IEnumerable<WSDocOpr_Lang>)Queryable.Where<WSDocOpr_Lang>((IQueryable<WSDocOpr_Lang>)wSDocOpr_Lang, Expression.Lambda<Func<WSDocOpr_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			WSDocOpr wSDocOpr = new WSDocOpr();
			if (CS_0024_003C_003E8__locals0.oprId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineDocOpr", "actInsert", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				wSDocOpr = new WSDocOpr();
				wSDocOprLanguageViewModel.DocOprID = 0;
				wSDocOprLanguageViewModel.OprType = 1;
				List<WSspSelectDocOpr_Result> list2 = Doc.SelecDocOpr();
				if (!Enumerable.Any<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)list2))
				{
					wSDocOprLanguageViewModel.OrderView = 10;
				}
				else
				{
					int num = (Enumerable.Any<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)list2) ? Enumerable.Count<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)list2) : 0);
					wSDocOprLanguageViewModel.OrderView = num * 10 + 10;
					if (Enumerable.LastOrDefault<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)list2) != null)
					{
						int valueOrDefault = Enumerable.LastOrDefault<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)list2).OrderView.GetValueOrDefault();
						if (valueOrDefault > 0)
						{
							wSDocOprLanguageViewModel.OrderView = valueOrDefault + 10;
						}
					}
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDefineDocOpr", "actEdit", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<WSDocOpr> wSDocOpr2 = _dbTbl.WSDocOpr;
				val = Expression.Parameter(typeof(WSDocOpr), "m");
				wSDocOpr = Queryable.FirstOrDefault<WSDocOpr>((IQueryable<WSDocOpr>)wSDocOpr2, Expression.Lambda<Func<WSDocOpr, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSDocOpr == null)
				{
					wSDocOpr = new WSDocOpr();
					wSDocOprLanguageViewModel.DocOprID = 0;
					wSDocOprLanguageViewModel.OprType = 1;
				}
				else
				{
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDocOpr_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDocOpr_Lang>)list, (Func<WSDocOpr_Lang, CommonMultiLanguageViewModel>)((WSDocOpr_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.Name,
						LanguageId = item.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = wSDocOpr.Name,
						LanguageId = result
					});
					wSDocOprLanguageViewModel = new WSDocOprLanguageViewModel
					{
						DocOprID = wSDocOpr.DocOprID,
						Name = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						Name_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						OprType = wSDocOpr.OprType,
						OrderView = wSDocOpr.OrderView
					};
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(wSDocOprLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineDocOpr", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(WSDocOprLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Name_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Name_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.Name,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.Name))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.DocOprName) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.Name, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.DocOprName) + "<br>";
				num++;
			}
			if (num == 0)
			{
				try
				{
					_003C_003Ec__DisplayClass10_1 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_1();
					_003C_003Ec__DisplayClass10_.opr = new WSDocOpr();
					if (CS_0024_003C_003E8__locals0.model.DocOprID > 0)
					{
						DbSet<WSDocOpr> wSDocOpr = _dbTbl.WSDocOpr;
						ParameterExpression val = Expression.Parameter(typeof(WSDocOpr), "m");
						_003C_003Ec__DisplayClass10_.opr = Queryable.FirstOrDefault<WSDocOpr>((IQueryable<WSDocOpr>)wSDocOpr, Expression.Lambda<Func<WSDocOpr, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string text2 = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					int id = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass10_.opr.UserId = userId;
					_003C_003Ec__DisplayClass10_.opr.RegisterDate = value;
					_003C_003Ec__DisplayClass10_.opr.RegisterDatePersian = text2;
					_003C_003Ec__DisplayClass10_.opr.Month1 = value2;
					_003C_003Ec__DisplayClass10_.opr.AppType = appType;
					_003C_003Ec__DisplayClass10_.opr.OrderView = CS_0024_003C_003E8__locals0.model.OrderView;
					_003C_003Ec__DisplayClass10_.opr.Name = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass10_.opr.OprType = CS_0024_003C_003E8__locals0.model.OprType;
					if (CS_0024_003C_003E8__locals0.model.DocOprID > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass10_.opr).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass10_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass10_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass10_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<WSDocOpr_Lang> wSDocOpr_Lang = _dbTbl.WSDocOpr_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSDocOpr_Lang), "c");
								WSDocOpr_Lang wSDocOpr_Lang2 = Queryable.FirstOrDefault<WSDocOpr_Lang>((IQueryable<WSDocOpr_Lang>)wSDocOpr_Lang, Expression.Lambda<Func<WSDocOpr_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSDocOpr_Lang2 != null)
								{
									wSDocOpr_Lang2.Name = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSDocOpr_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSDocOpr_Lang2 = new WSDocOpr_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									DocOprID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.opr.DocOprID,
									Name = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.WSDocOpr_Lang.Add(wSDocOpr_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDocOpr");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass10_.opr.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass10_.opr.FirstRegisterUserId = userId;
						_003C_003Ec__DisplayClass10_.opr.FirstRegisterDate = value;
						_003C_003Ec__DisplayClass10_.opr.FirstRegisterDatePersian = text2;
						_003C_003Ec__DisplayClass10_.opr.FPId = id;
						_003C_003Ec__DisplayClass10_.opr.GUId = Guid.NewGuid();
						List<WSspSelectDocOpr_Result> list2 = Doc.SelecDocOpr();
						if (!_003C_003Ec__DisplayClass10_.opr.OrderView.HasValue)
						{
							if (!Enumerable.Any<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)list2))
							{
								_003C_003Ec__DisplayClass10_.opr.OrderView = 10;
							}
							else
							{
								int num2 = (Enumerable.Any<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)list2) ? Enumerable.Count<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)list2) : 0);
								_003C_003Ec__DisplayClass10_.opr.OrderView = num2 * 10 + 10;
								if (Enumerable.LastOrDefault<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)list2) != null)
								{
									int valueOrDefault = Enumerable.LastOrDefault<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)list2).OrderView.GetValueOrDefault();
									if (valueOrDefault > 0)
									{
										_003C_003Ec__DisplayClass10_.opr.OrderView = valueOrDefault + 10;
									}
								}
							}
						}
						_dbTbl.WSDocOpr.Add(_003C_003Ec__DisplayClass10_.opr);
						_dbTbl.SaveChanges();
						if (_003C_003Ec__DisplayClass10_.opr.DocOprID > 0)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								WSDocOpr_Lang entity = new WSDocOpr_Lang
								{
									LanguageID = lang.LanguageID,
									DocOprID = _003C_003Ec__DisplayClass10_.opr.DocOprID,
									Name = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
								};
								_dbTbl.WSDocOpr_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDocOpr");
						CS_0024_003C_003E8__locals0.model.DocOprID = _003C_003Ec__DisplayClass10_.opr.DocOprID;
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineDocOpr", ActionName = "actDelete")]
	public string ActDelete(int oprId)
	{
		_003C_003Ec__DisplayClass11_0 _003C_003Ec__DisplayClass11_ = new _003C_003Ec__DisplayClass11_0();
		_003C_003Ec__DisplayClass11_.oprId = oprId;
		string text = "";
		try
		{
			if (_003C_003Ec__DisplayClass11_.oprId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				DbSet<WSDocOpr> wSDocOpr = _dbTbl.WSDocOpr;
				ParameterExpression val = Expression.Parameter(typeof(WSDocOpr), "m");
				if (Queryable.FirstOrDefault<WSDocOpr>((IQueryable<WSDocOpr>)wSDocOpr, Expression.Lambda<Func<WSDocOpr, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass11_, typeof(_003C_003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSDocOpr(_003C_003Ec__DisplayClass11_.oprId));
						int result2 = 0;
						if (mct_Result != null)
						{
							int.TryParse(mct_Result.Result.ToString(), out result2);
						}
						if (result2 > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDocOpr");
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
