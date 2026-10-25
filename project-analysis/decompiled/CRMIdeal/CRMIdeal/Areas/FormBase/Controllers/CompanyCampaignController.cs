using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
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
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class CompanyCampaignController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public CrmCompanyCampaignLanguageViewModel vm;

		public int defLangID;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int camId;

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

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefinecmpCampaign")]
	public ActionResult Index()
	{
		return View();
	}

	public List<TreeViewItemModel> GetCompanyCampaignNodeTree(List<CRMspSelectCompanyCampaignTree_Result> lstCategory, int? currCamId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectCompanyCampaignTree_Result> list2 = Enumerable.ToList<CRMspSelectCompanyCampaignTree_Result>(Enumerable.Where<CRMspSelectCompanyCampaignTree_Result>((IEnumerable<CRMspSelectCompanyCampaignTree_Result>)lstCategory, (Func<CRMspSelectCompanyCampaignTree_Result, bool>)((CRMspSelectCompanyCampaignTree_Result m) => m.ParentId == currCamId)));
			if (Enumerable.Any<CRMspSelectCompanyCampaignTree_Result>((IEnumerable<CRMspSelectCompanyCampaignTree_Result>)list2))
			{
				foreach (CRMspSelectCompanyCampaignTree_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.CompanyCampaignId.ToString()));
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("campaignFullName", item.CampaignFullName.ToString()));
					treeViewItemModel.Id = item.CompanyCampaignId.ToString();
					treeViewItemModel.Text = item.CampaignName + " (" + item.CompanyCampaignId + ")";
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> companyCampaignNodeTree = GetCompanyCampaignNodeTree(lstCategory, item.CompanyCampaignId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(companyCampaignNodeTree);
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<TreeViewItemModel> GetCompanyCampaignTree(int currCamId = -1)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyCampaignTree_Result> list2 = Enumerable.ToList<CRMspSelectCompanyCampaignTree_Result>((IEnumerable<CRMspSelectCompanyCampaignTree_Result>)_dbI.CRMspSelectCompanyCampaignTree(currCamId, lCID, result));
			if (Enumerable.Any<CRMspSelectCompanyCampaignTree_Result>((IEnumerable<CRMspSelectCompanyCampaignTree_Result>)list2))
			{
				List<CRMspSelectCompanyCampaignTree_Result> list3 = Enumerable.ToList<CRMspSelectCompanyCampaignTree_Result>(Enumerable.Where<CRMspSelectCompanyCampaignTree_Result>((IEnumerable<CRMspSelectCompanyCampaignTree_Result>)list2, (Func<CRMspSelectCompanyCampaignTree_Result, bool>)((CRMspSelectCompanyCampaignTree_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspSelectCompanyCampaignTree_Result>((IEnumerable<CRMspSelectCompanyCampaignTree_Result>)list3))
				{
					foreach (CRMspSelectCompanyCampaignTree_Result item in list3)
					{
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.CompanyCampaignId.ToString()));
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("campaignFullName", item.CampaignFullName.ToString()));
						treeViewItemModel.Id = item.CompanyCampaignId.ToString();
						treeViewItemModel.Text = item.CampaignName + " (" + item.CompanyCampaignId + ")";
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> companyCampaignNodeTree = GetCompanyCampaignNodeTree(list2, item.CompanyCampaignId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(companyCampaignNodeTree);
						list.Add(treeViewItemModel);
					}
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
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialCompanyCampaignTree(int currCamId = -1)
	{
		try
		{
			List<TreeViewItemModel> companyCampaignTree = GetCompanyCampaignTree(currCamId);
			base.ViewBag.cmpCampaignTree = companyCampaignTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetCompanyCampaignInfo(int camId)
	{
		CRMspSelectCompanyCampaignById_Result cRMspSelectCompanyCampaignById_Result = new CRMspSelectCompanyCampaignById_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMspSelectCompanyCampaignById_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyCampaignById_Result>((IEnumerable<CRMspSelectCompanyCampaignById_Result>)_dbI.CRMspSelectCompanyCampaignById(camId, lCID, result));
			if (cRMspSelectCompanyCampaignById_Result != null)
			{
				if (string.IsNullOrEmpty(cRMspSelectCompanyCampaignById_Result.AppType))
				{
					cRMspSelectCompanyCampaignById_Result.AppType = Configuration.AppType;
				}
				cRMspSelectCompanyCampaignById_Result.AppType = " (" + Labels.AppType + ":" + Configuration.GetAppType(cRMspSelectCompanyCampaignById_Result.AppType) + ")";
				CRMspSelectCompanyCampaignById_Result cRMspSelectCompanyCampaignById_Result2 = cRMspSelectCompanyCampaignById_Result;
				_ = cRMspSelectCompanyCampaignById_Result.FirstRegisterDate;
				cRMspSelectCompanyCampaignById_Result2.FirstRegisterDatePersian = cRMspSelectCompanyCampaignById_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspSelectCompanyCampaignById_Result.FirstRegisterUser = cRMspSelectCompanyCampaignById_Result.FirstRegisterUser + " (" + cRMspSelectCompanyCampaignById_Result.FirstRegisterDatePersian + ")";
				CRMspSelectCompanyCampaignById_Result cRMspSelectCompanyCampaignById_Result3 = cRMspSelectCompanyCampaignById_Result;
				_ = cRMspSelectCompanyCampaignById_Result.RegisterDate;
				cRMspSelectCompanyCampaignById_Result3.RegisterDatePersian = cRMspSelectCompanyCampaignById_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspSelectCompanyCampaignById_Result.EditUser = cRMspSelectCompanyCampaignById_Result.EditUser + cRMspSelectCompanyCampaignById_Result.AppType + " (" + cRMspSelectCompanyCampaignById_Result.RegisterDatePersian + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(cRMspSelectCompanyCampaignById_Result, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefinecmpCampaign", ActionName = "actDelete")]
	public string ActDeleteCompanyCampaign(int camId)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmDefinecmpCampaign", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (camId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteCompanyCampaign(camId));
					int result2 = 0;
					if (mct_I_Result != null)
					{
						int.TryParse(mct_I_Result.Result.ToString(), out result2);
					}
					if (result2 < 1)
					{
						text = result2 switch
						{
							-3 => Messages.msgErrorDeleteItemUsedInPrj, 
							-2 => Messages.msgErrorDeleteItemUsedInCmp, 
							-1 => Messages.msgErrorDeleteItemThatHaveChild, 
							_ => Messages.RedundancyMessage, 
						};
					}
					else
					{
						text = "1";
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyCampaign");
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					text = Messages.RedundancyMessage;
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmDefinecmpCampaign", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int camId = 0, int parentId = 0)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.camId = camId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmCompanyCampaignLanguageViewModel crmCompanyCampaignLanguageViewModel = new CrmCompanyCampaignLanguageViewModel();
		if (CS_0024_003C_003E8__locals0.camId > 0)
		{
			if (!UserLogin.IsUserAccess("frmDefinecmpCampaign", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<CrmCompanyCampaign_Lang> crmCompanyCampaign_Lang = _dbTbl.CrmCompanyCampaign_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmCompanyCampaign_Lang), "c");
			List<CrmCompanyCampaign_Lang> list = Enumerable.ToList<CrmCompanyCampaign_Lang>((IEnumerable<CrmCompanyCampaign_Lang>)Queryable.Where<CrmCompanyCampaign_Lang>((IQueryable<CrmCompanyCampaign_Lang>)crmCompanyCampaign_Lang, Expression.Lambda<Func<CrmCompanyCampaign_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<CrmCompanyCampaign> crmCompanyCampaign = _dbTbl.CrmCompanyCampaign;
			val = Expression.Parameter(typeof(CrmCompanyCampaign), "c");
			CrmCompanyCampaign crmCompanyCampaign2 = Queryable.FirstOrDefault<CrmCompanyCampaign>((IQueryable<CrmCompanyCampaign>)crmCompanyCampaign, Expression.Lambda<Func<CrmCompanyCampaign, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCompanyCampaign2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyCampaign_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyCampaign_Lang>)list, (Func<CrmCompanyCampaign_Lang, CommonMultiLanguageViewModel>)((CrmCompanyCampaign_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CampaignName,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCompanyCampaign2.CampaignName,
				LanguageId = result
			});
			crmCompanyCampaignLanguageViewModel = new CrmCompanyCampaignLanguageViewModel
			{
				CompanyCampaignId = crmCompanyCampaign2.CompanyCampaignId,
				CampaignName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				CampaignName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ParentId = crmCompanyCampaign2.ParentId,
				OrderView = crmCompanyCampaign2.OrderView
			};
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDefinecmpCampaign", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			_ = DateTime.Now;
			int num = 0;
			List<CRMspSelectCompanyCampaign_Result> list3 = Enumerable.ToList<CRMspSelectCompanyCampaign_Result>((IEnumerable<CRMspSelectCompanyCampaign_Result>)_dbI.CRMspSelectCompanyCampaign(CS_0024_003C_003E8__locals0.currLangID, result));
			if (!Enumerable.Any<CRMspSelectCompanyCampaign_Result>((IEnumerable<CRMspSelectCompanyCampaign_Result>)list3))
			{
				num = 10;
			}
			else
			{
				int result2 = 10;
				CRMspSelectCompanyCampaign_Result cRMspSelectCompanyCampaign_Result = Enumerable.LastOrDefault<CRMspSelectCompanyCampaign_Result>((IEnumerable<CRMspSelectCompanyCampaign_Result>)list3);
				if (cRMspSelectCompanyCampaign_Result != null)
				{
					int.TryParse(cRMspSelectCompanyCampaign_Result.OrderView.ToString(), out result2);
					result2 = ((result2 == 0) ? 10 : (result2 + 10));
				}
				num = result2;
			}
			crmCompanyCampaignLanguageViewModel = new CrmCompanyCampaignLanguageViewModel
			{
				ParentId = parentId,
				OrderView = num
			};
		}
		return View(crmCompanyCampaignLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefinecmpCampaignDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(CrmCompanyCampaignLanguageViewModel vm)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CampaignName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.CampaignName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.CampaignName,
			LanguageId = lCID
		});
		try
		{
			string text = "";
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CampaignName))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CompanyCampaignName) + "<br/>";
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.CampaignName, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CompanyCampaignName) + "<br>";
			}
			if (CS_0024_003C_003E8__locals0.vm.ParentId != 0 && Enumerable.FirstOrDefault<CRMspSelectCompanyCampaignById_Result>((IEnumerable<CRMspSelectCompanyCampaignById_Result>)_dbI.CRMspSelectCompanyCampaignById(CS_0024_003C_003E8__locals0.vm.ParentId, lCID, CS_0024_003C_003E8__locals0.defLangID)) == null)
			{
				text += string.Format(Messages.msgErrorIsNotFound, Labels.Parent);
			}
			if (text != "")
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				DateTime now = DateTime.Now;
				DateTime dateTime = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short num = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short num2 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				CrmCompanyCampaign crmCompanyCampaign = new CrmCompanyCampaign();
				if (CS_0024_003C_003E8__locals0.vm.CompanyCampaignId > 0)
				{
					DbSet<CrmCompanyCampaign> crmCompanyCampaign2 = _dbTbl.CrmCompanyCampaign;
					ParameterExpression val = Expression.Parameter(typeof(CrmCompanyCampaign), "c");
					crmCompanyCampaign = Queryable.FirstOrDefault<CrmCompanyCampaign>((IQueryable<CrmCompanyCampaign>)crmCompanyCampaign2, Expression.Lambda<Func<CrmCompanyCampaign, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				crmCompanyCampaign.CampaignName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyCampaign.ParentId = CS_0024_003C_003E8__locals0.vm.ParentId;
				crmCompanyCampaign.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				crmCompanyCampaign.UserId = userId;
				crmCompanyCampaign.Year1 = num2;
				crmCompanyCampaign.Month1 = num;
				crmCompanyCampaign.RegisterDate = dateTime;
				crmCompanyCampaign.RegisterDatePersian = registerDatePersian;
				crmCompanyCampaign.AppType = appType;
				string campaignLangJson = "";
				if (list != null)
				{
					campaignLangJson = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
				}
				if (crmCompanyCampaign.CompanyCampaignId > 0)
				{
					_dbI.CRMspUpdateCompanyCampaign(crmCompanyCampaign.CompanyCampaignId, crmCompanyCampaign.ParentId, crmCompanyCampaign.CampaignName, campaignLangJson, crmCompanyCampaign.OrderView, userId, dateTime, registerDatePersian, num2, num, appType, CS_0024_003C_003E8__locals0.defLangID);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyCampaign");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					if (!CS_0024_003C_003E8__locals0.vm.OrderView.HasValue)
					{
						List<CRMspSelectCompanyCampaign_Result> list2 = Enumerable.ToList<CRMspSelectCompanyCampaign_Result>((IEnumerable<CRMspSelectCompanyCampaign_Result>)_dbI.CRMspSelectCompanyCampaign(lCID, CS_0024_003C_003E8__locals0.defLangID));
						int num3 = (Enumerable.Any<CRMspSelectCompanyCampaign_Result>((IEnumerable<CRMspSelectCompanyCampaign_Result>)list2) ? Enumerable.Count<CRMspSelectCompanyCampaign_Result>((IEnumerable<CRMspSelectCompanyCampaign_Result>)list2) : 0);
						crmCompanyCampaign.OrderView = num3 * 10 + 10;
						if (Enumerable.LastOrDefault<CRMspSelectCompanyCampaign_Result>((IEnumerable<CRMspSelectCompanyCampaign_Result>)list2) != null)
						{
							int valueOrDefault = Enumerable.LastOrDefault<CRMspSelectCompanyCampaign_Result>((IEnumerable<CRMspSelectCompanyCampaign_Result>)list2).OrderView.GetValueOrDefault();
							if (valueOrDefault > 0)
							{
								crmCompanyCampaign.OrderView = valueOrDefault + 10;
							}
						}
					}
					else
					{
						crmCompanyCampaign.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
					}
					ObjectParameter objectParameter = new ObjectParameter("insertedId", 0);
					_dbI.CRMspInsertCompanyCampaign(crmCompanyCampaign.ParentId, crmCompanyCampaign.CampaignName, campaignLangJson, crmCompanyCampaign.OrderView, userId, dateTime, registerDatePersian, num2, num, appType, CS_0024_003C_003E8__locals0.defLangID, objectParameter);
					int result = 0;
					if (objectParameter != null && objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result);
					}
					if (result <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyCampaign");
						CS_0024_003C_003E8__locals0.vm.CompanyCampaignId = result;
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
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
		_dbI.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
