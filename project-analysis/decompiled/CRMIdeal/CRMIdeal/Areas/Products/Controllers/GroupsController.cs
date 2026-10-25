using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.IO;
using CRM.General.IO.FTP;
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

namespace CRMIdeal.Areas.Products.Controllers;

public class GroupsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public int id;

		public int currLangID;

		internal bool _003CEditFirstGroup_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFirstGroup_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_1
	{
		public WSProductFirstGroup item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass12_1 CS_0024_003C_003E8__locals1;

		internal bool _003CEditFirstGroup_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFirstGroup_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public int id;

		public int currLangID;

		internal bool _003CEditSecondGroup_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditSecondGroup_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_1
	{
		public WSProductSecondGroup item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass19_1 CS_0024_003C_003E8__locals1;

		internal bool _003CEditSecondGroup_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditSecondGroup_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public int productGroupPictureId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public int prdGroupPictureId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int id;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actProductGroup")]
	public ActionResult Index()
	{
		bool flag = false;
		try
		{
			List<WSspSelectProductGroupPicture_Result> list = Enumerable.ToList<WSspSelectProductGroupPicture_Result>((IEnumerable<WSspSelectProductGroupPicture_Result>)_dbII.WSspSelectProductGroupPicture());
			if (list != null && Enumerable.Any<WSspSelectProductGroupPicture_Result>((IEnumerable<WSspSelectProductGroupPicture_Result>)list))
			{
				list = Enumerable.ToList<WSspSelectProductGroupPicture_Result>(Enumerable.Where<WSspSelectProductGroupPicture_Result>((IEnumerable<WSspSelectProductGroupPicture_Result>)list, (Func<WSspSelectProductGroupPicture_Result, bool>)((WSspSelectProductGroupPicture_Result m) => string.IsNullOrWhiteSpace(m.FilePath))));
				if (list != null && Enumerable.Any<WSspSelectProductGroupPicture_Result>((IEnumerable<WSspSelectProductGroupPicture_Result>)list))
				{
					flag = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UpdateAndUploadPrgGroup = flag;
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}

	public void SetUserNameDateForProductGroup(ProductGroupViewModel model)
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
			string text5 = (model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				ProductGroupViewModel productGroupViewModel = model;
				_ = model.UserId;
				productGroupViewModel.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[AjaxOnly]
	public ActionResult _PartialFirstGroup()
	{
		WSProductFirstGroup wSProductFirstGroup = Queryable.FirstOrDefault<WSProductFirstGroup>((IQueryable<WSProductFirstGroup>)_dbTbl.WSProductFirstGroup);
		base.ViewBag.FirstGropId = wSProductFirstGroup?.PrdFirstGroupID ?? 0;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult ProductsGroupsFirst_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductFirstGroup_Result> list = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result));
		List<ProductGroupViewModel> list2 = new List<ProductGroupViewModel>();
		foreach (WSspSelectProductFirstGroup_Result item in list)
		{
			list2.Add(new ProductGroupViewModel
			{
				PrdGroupID = item.PrdFirstGroupID,
				FGCode = item.FGCode,
				FGDescription = item.FGDescription,
				FGInactiveInBuy = item.FGInactiveInBuy.GetValueOrDefault(),
				FGInactiveInSale = item.FGInactiveInSale.GetValueOrDefault(),
				FGName = item.FGName,
				FGNameEn = item.FGNameEn,
				PrdGroupMustExistInPreOrder = (item.PrdGroupMustExistInPreOrder.HasValue && item.PrdGroupMustExistInPreOrder != false),
				FGOrderView = item.FGOrderView,
				FGSHPIsActive = (item.FGSHPIsActive.HasValue && item.FGSHPIsActive != false),
				FGSHPName = item.FGSHPName
			});
		}
		return Json(((IEnumerable)list2).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actDeleteFG")]
	public string DeleteFirstGroup(int id)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.id = id;
		try
		{
			DbSet<WSProductSecondGroup> wSProductSecondGroup = _dbTbl.WSProductSecondGroup;
			ParameterExpression val = Expression.Parameter(typeof(WSProductSecondGroup), "c");
			if (Queryable.Any<WSProductSecondGroup>((IQueryable<WSProductSecondGroup>)wSProductSecondGroup, Expression.Lambda<Func<WSProductSecondGroup, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
			{
				return Messages.RedundancyMessage;
			}
			DbSet<WSProductFirstGroup> wSProductFirstGroup = _dbTbl.WSProductFirstGroup;
			val = Expression.Parameter(typeof(WSProductFirstGroup), "c");
			if (Queryable.FirstOrDefault<WSProductFirstGroup>((IQueryable<WSProductFirstGroup>)wSProductFirstGroup, Expression.Lambda<Func<WSProductFirstGroup, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSProductFirstGroup(_003C_003Ec__DisplayClass8_.id)));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
						return "";
					}
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
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actInsertFG")]
	public ActionResult InsertFirstGroup()
	{
		DateTime now = DateTime.Now;
		ProductGroupViewModel productGroupViewModel = new ProductGroupViewModel
		{
			UserId = UserLogin.CurrentUser.UserId,
			RegisterDate = now,
			AppType = Configuration.AppType,
			FirstRegisterUserId = UserLogin.CurrentUser.UserId,
			FirstRegisterDate = now,
			FGSHPIsActive = false
		};
		SetUserNameDateForProductGroup(productGroupViewModel);
		return View(productGroupViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductGroupsDataEntry", ActionName = "actPost")]
	public ActionResult InsertFirstGroup(ProductGroupViewModel model)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.FGName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.FGName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = model.FGName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.FGDescription_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.FGDescription_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = model.FGDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.FGSHPName_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.FGSHPName_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = model.FGSHPName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoTitle_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoTitle_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoDescription_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoDescription_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoAuthor_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoAuthor_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoAuthor,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoCopyright_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoCopyright_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoCopyright,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoKeywords_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoKeywords_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoKeywords,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoFAQ_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoFAQ_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoFAQ,
			LanguageId = lCID
		});
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			try
			{
				string text = "";
				if (model.FGName == null && model.FGName == "")
				{
					text = text + Messages.CheckFGName + "<br/>";
				}
				else if (!checkMultiLanguage(model.FGName, list))
				{
					text = text + Messages.CheckFGNameLang + "<br>";
				}
				if (text != "")
				{
					base.ViewBag.Error = text;
				}
				else
				{
					DateTime now = DateTime.Now;
					WSProductFirstGroup wSProductFirstGroup = new WSProductFirstGroup();
					wSProductFirstGroup.FGCode = model.FGCode;
					wSProductFirstGroup.FGDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductFirstGroup.FGName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductFirstGroup.FPId = Financial.Get().Id;
					wSProductFirstGroup.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					wSProductFirstGroup.UserId = UserLogin.CurrentUser.UserId;
					wSProductFirstGroup.RegisterDate = now;
					wSProductFirstGroup.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSProductFirstGroup.FGNameEn = model.FGNameEn;
					wSProductFirstGroup.GUId = Guid.NewGuid();
					if (model.FGInactiveInSale)
					{
						wSProductFirstGroup.FGInactiveInSale = model.FGInactiveInSale;
					}
					if (model.FGInactiveInBuy)
					{
						wSProductFirstGroup.FGInactiveInBuy = model.FGInactiveInBuy;
					}
					wSProductFirstGroup.AppType = Configuration.AppType;
					wSProductFirstGroup.PrdGroupMustExistInPreOrder = model.PrdGroupMustExistInPreOrder;
					wSProductFirstGroup.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					wSProductFirstGroup.FirstRegisterDate = now;
					wSProductFirstGroup.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSProductFirstGroup.LanguageID = defLangID;
					wSProductFirstGroup.FGOrderView = model.FGOrderView;
					wSProductFirstGroup.FGSHPIsActive = model.FGSHPIsActive;
					wSProductFirstGroup.TspFGIndentify = model.TspFGIndentify;
					wSProductFirstGroup.TspFGName = model.TspFGName;
					wSProductFirstGroup.FGSHPName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductFirstGroup.FGSeoIsActive = model.SeoIsActive;
					wSProductFirstGroup.FGSeoTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductFirstGroup.FGSeoDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductFirstGroup.FGSeoHttpEquiv = model.SeoHttpEquiv;
					wSProductFirstGroup.FGSeoExpires = model.SeoExpires;
					wSProductFirstGroup.FGSeoGoogleNotranslate = model.SeoGoogleNotranslate;
					wSProductFirstGroup.FGSeoDistribution = model.SeoDistribution;
					wSProductFirstGroup.FGSeoRobots = model.SeoRobots;
					wSProductFirstGroup.FGSeoRating = model.SeoRating;
					wSProductFirstGroup.FGSeoAuthor = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductFirstGroup.FGSeoIsUseSocialNetwork = model.SeoIsUseSocialNetwork;
					wSProductFirstGroup.FGSeoMobileOptimized = model.SeoMobileOptimized;
					wSProductFirstGroup.FGSeoCopyright = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductFirstGroup.FGSeoUseDefault = model.SeoUseDefault;
					wSProductFirstGroup.FGSeoKeywords = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductFirstGroup.FGSeoFAQ = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					_dbTbl.WSProductFirstGroup.Add(wSProductFirstGroup);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						WSProductFirstGroup_Lang entity = new WSProductFirstGroup_Lang
						{
							LanguageID = lang.LanguageID,
							PrdFirstGroupID = wSProductFirstGroup.PrdFirstGroupID,
							FGDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							FGName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							FGSHPName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							FGSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							FGSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							FGSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							FGSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							FGSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							FGSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.WSProductFirstGroup_Lang.Add(entity);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					model.UserId = wSProductFirstGroup.UserId;
					model.RegisterDate = wSProductFirstGroup.RegisterDate;
					model.AppType = wSProductFirstGroup.AppType;
					model.FirstRegisterUserId = wSProductFirstGroup.FirstRegisterUserId;
					model.FirstRegisterDate = wSProductFirstGroup.FirstRegisterDate;
					model.PrdGroupID = wSProductFirstGroup.PrdFirstGroupID;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		SetUserNameDateForProductGroup(model);
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actEditFG")]
	public ActionResult EditFirstGroup(int id)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSProductFirstGroup_Lang> wSProductFirstGroup_Lang = _dbTbl.WSProductFirstGroup_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSProductFirstGroup_Lang), "c");
		List<WSProductFirstGroup_Lang> list = Enumerable.ToList<WSProductFirstGroup_Lang>((IEnumerable<WSProductFirstGroup_Lang>)Queryable.Where<WSProductFirstGroup_Lang>((IQueryable<WSProductFirstGroup_Lang>)wSProductFirstGroup_Lang, Expression.Lambda<Func<WSProductFirstGroup_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		ProductGroupViewModel productGroupViewModel = new ProductGroupViewModel();
		try
		{
			DbSet<WSProductFirstGroup> wSProductFirstGroup = _dbTbl.WSProductFirstGroup;
			val = Expression.Parameter(typeof(WSProductFirstGroup), "c");
			WSProductFirstGroup wSProductFirstGroup2 = Queryable.FirstOrDefault<WSProductFirstGroup>((IQueryable<WSProductFirstGroup>)wSProductFirstGroup, Expression.Lambda<Func<WSProductFirstGroup, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSProductFirstGroup2 != null)
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductFirstGroup_Lang>)list, (Func<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>)((WSProductFirstGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FGName,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductFirstGroup2.FGName,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductFirstGroup_Lang>)list, (Func<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>)((WSProductFirstGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FGDescription,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductFirstGroup2.FGDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductFirstGroup_Lang>)list, (Func<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>)((WSProductFirstGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FGSHPName,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductFirstGroup2.FGSHPName,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductFirstGroup_Lang>)list, (Func<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>)((WSProductFirstGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FGSeoTitle,
					LanguageId = item.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductFirstGroup2.FGSeoTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductFirstGroup_Lang>)list, (Func<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>)((WSProductFirstGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FGSeoDescription,
					LanguageId = item.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductFirstGroup2.FGSeoDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductFirstGroup_Lang>)list, (Func<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>)((WSProductFirstGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FGSeoAuthor,
					LanguageId = item.LanguageID
				})));
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductFirstGroup2.FGSeoAuthor,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductFirstGroup_Lang>)list, (Func<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>)((WSProductFirstGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FGSeoCopyright,
					LanguageId = item.LanguageID
				})));
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductFirstGroup2.FGSeoCopyright,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductFirstGroup_Lang>)list, (Func<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>)((WSProductFirstGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FGSeoKeywords,
					LanguageId = item.LanguageID
				})));
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductFirstGroup2.FGSeoKeywords,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductFirstGroup_Lang>)list, (Func<WSProductFirstGroup_Lang, CommonMultiLanguageViewModel>)((WSProductFirstGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FGSeoFAQ,
					LanguageId = item.LanguageID
				})));
				list10.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductFirstGroup2.FGSeoFAQ,
					LanguageId = result
				});
				productGroupViewModel.FGName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				productGroupViewModel.FGCode = wSProductFirstGroup2.FGCode;
				productGroupViewModel.FGDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				productGroupViewModel.FGInactiveInBuy = wSProductFirstGroup2.FGInactiveInBuy.GetValueOrDefault();
				productGroupViewModel.FGInactiveInSale = wSProductFirstGroup2.FGInactiveInSale.GetValueOrDefault();
				productGroupViewModel.FGNameEn = wSProductFirstGroup2.FGNameEn;
				productGroupViewModel.PrdGroupID = wSProductFirstGroup2.PrdFirstGroupID;
				productGroupViewModel.FGSubName = "0";
				productGroupViewModel.PrdGroupMustExistInPreOrder = wSProductFirstGroup2.PrdGroupMustExistInPreOrder.HasValue && wSProductFirstGroup2.PrdGroupMustExistInPreOrder != false;
				productGroupViewModel.FGName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				productGroupViewModel.FGDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				productGroupViewModel.UserId = wSProductFirstGroup2.UserId;
				productGroupViewModel.FirstRegisterUserId = wSProductFirstGroup2.FirstRegisterUserId;
				productGroupViewModel.FirstRegisterDate = wSProductFirstGroup2.FirstRegisterDate;
				productGroupViewModel.RegisterDate = wSProductFirstGroup2.RegisterDate;
				productGroupViewModel.AppType = wSProductFirstGroup2.AppType;
				productGroupViewModel.FGOrderView = wSProductFirstGroup2.FGOrderView;
				productGroupViewModel.FGSHPIsActive = wSProductFirstGroup2.FGSHPIsActive.HasValue && wSProductFirstGroup2.FGSHPIsActive != false;
				productGroupViewModel.TspFGIndentify = wSProductFirstGroup2.TspFGIndentify;
				productGroupViewModel.TspFGName = wSProductFirstGroup2.TspFGName;
				productGroupViewModel.FGSHPName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				productGroupViewModel.FGSHPName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				productGroupViewModel.SeoIsActive = wSProductFirstGroup2.FGSeoIsActive;
				productGroupViewModel.SeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				productGroupViewModel.SeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				productGroupViewModel.SeoHttpEquiv = wSProductFirstGroup2.FGSeoHttpEquiv;
				productGroupViewModel.SeoExpires = wSProductFirstGroup2.FGSeoExpires;
				productGroupViewModel.SeoGoogleNotranslate = wSProductFirstGroup2.FGSeoGoogleNotranslate;
				productGroupViewModel.SeoDistribution = wSProductFirstGroup2.FGSeoDistribution;
				productGroupViewModel.SeoRobots = wSProductFirstGroup2.FGSeoRobots;
				productGroupViewModel.SeoRating = wSProductFirstGroup2.FGSeoRating;
				productGroupViewModel.SeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				productGroupViewModel.SeoIsUseSocialNetwork = wSProductFirstGroup2.FGSeoIsUseSocialNetwork;
				productGroupViewModel.SeoMobileOptimized = wSProductFirstGroup2.FGSeoMobileOptimized;
				productGroupViewModel.SeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				productGroupViewModel.SeoUseDefault = wSProductFirstGroup2.FGSeoUseDefault;
				productGroupViewModel.SeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				productGroupViewModel.SeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				productGroupViewModel.SeoTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				productGroupViewModel.SeoDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				productGroupViewModel.SeoAuthor_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				productGroupViewModel.SeoCopyright_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				productGroupViewModel.SeoKeywords_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				productGroupViewModel.SeoFAQ_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			}
			else
			{
				DateTime now = DateTime.Now;
				productGroupViewModel.UserId = UserLogin.CurrentUser.UserId;
				productGroupViewModel.RegisterDate = now;
				productGroupViewModel.AppType = Configuration.AppType;
				productGroupViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				productGroupViewModel.FirstRegisterDate = now;
				base.ViewBag.Error = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		SetUserNameDateForProductGroup(productGroupViewModel);
		return View(productGroupViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductGroupsDataEntry", ActionName = "actPost")]
	public ActionResult EditFirstGroup(ProductGroupViewModel model)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.FGName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.FGName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = model.FGName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.FGDescription_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.FGDescription_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = model.FGDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.FGSHPName_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.FGSHPName_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = model.FGSHPName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoTitle_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoTitle_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoDescription_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoDescription_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoAuthor_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoAuthor_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoAuthor,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoCopyright_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoCopyright_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoCopyright,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoKeywords_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoKeywords_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoKeywords,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoFAQ_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoFAQ_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoFAQ,
			LanguageId = lCID
		});
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			try
			{
				string text = "";
				if (model.FGName == null && model.FGName == "")
				{
					text = text + Messages.CheckFGName + "<br/>";
				}
				else if (!checkMultiLanguage(model.FGName, list))
				{
					text = text + Messages.CheckFGNameLang + "<br>";
				}
				if (text != "")
				{
					base.ViewBag.Error = text;
				}
				else
				{
					_003C_003Ec__DisplayClass12_1 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_1();
					DateTime now = DateTime.Now;
					_003C_003Ec__DisplayClass12_.item = _dbTbl.WSProductFirstGroup.Find(model.PrdGroupID);
					if (_003C_003Ec__DisplayClass12_.item == null)
					{
						base.ViewBag.Error = Messages.ErrorNotFound;
					}
					else
					{
						_003C_003Ec__DisplayClass12_.item.FGName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass12_.item.FGCode = model.FGCode;
						_003C_003Ec__DisplayClass12_.item.FGDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass12_.item.FGInactiveInBuy = model.FGInactiveInBuy;
						_003C_003Ec__DisplayClass12_.item.FGInactiveInSale = model.FGInactiveInSale;
						_003C_003Ec__DisplayClass12_.item.FGNameEn = model.FGNameEn;
						_003C_003Ec__DisplayClass12_.item.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						_003C_003Ec__DisplayClass12_.item.UserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass12_.item.RegisterDate = now;
						_003C_003Ec__DisplayClass12_.item.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass12_.item.FPId = Financial.Get().Id;
						_003C_003Ec__DisplayClass12_.item.AppType = Configuration.AppType;
						_003C_003Ec__DisplayClass12_.item.PrdGroupMustExistInPreOrder = model.PrdGroupMustExistInPreOrder;
						_003C_003Ec__DisplayClass12_.item.FGOrderView = model.FGOrderView;
						_003C_003Ec__DisplayClass12_.item.FGSHPIsActive = model.FGSHPIsActive;
						_003C_003Ec__DisplayClass12_.item.TspFGIndentify = model.TspFGIndentify;
						_003C_003Ec__DisplayClass12_.item.TspFGName = model.TspFGName;
						_003C_003Ec__DisplayClass12_.item.FGSHPName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass12_.item.FGSeoIsActive = model.SeoIsActive;
						_003C_003Ec__DisplayClass12_.item.FGSeoTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass12_.item.FGSeoDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass12_.item.FGSeoHttpEquiv = model.SeoHttpEquiv;
						_003C_003Ec__DisplayClass12_.item.FGSeoExpires = model.SeoExpires;
						_003C_003Ec__DisplayClass12_.item.FGSeoGoogleNotranslate = model.SeoGoogleNotranslate;
						_003C_003Ec__DisplayClass12_.item.FGSeoDistribution = model.SeoDistribution;
						_003C_003Ec__DisplayClass12_.item.FGSeoRobots = model.SeoRobots;
						_003C_003Ec__DisplayClass12_.item.FGSeoRating = model.SeoRating;
						_003C_003Ec__DisplayClass12_.item.FGSeoAuthor = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass12_.item.FGSeoIsUseSocialNetwork = model.SeoIsUseSocialNetwork;
						_003C_003Ec__DisplayClass12_.item.FGSeoMobileOptimized = model.SeoMobileOptimized;
						_003C_003Ec__DisplayClass12_.item.FGSeoCopyright = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass12_.item.FGSeoUseDefault = model.SeoUseDefault;
						_003C_003Ec__DisplayClass12_.item.FGSeoKeywords = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass12_.item.FGSeoFAQ = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_dbTbl.Entry(_003C_003Ec__DisplayClass12_.item).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass12_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass12_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass12_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<WSProductFirstGroup_Lang> wSProductFirstGroup_Lang = _dbTbl.WSProductFirstGroup_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSProductFirstGroup_Lang), "c");
								WSProductFirstGroup_Lang wSProductFirstGroup_Lang2 = Queryable.FirstOrDefault<WSProductFirstGroup_Lang>((IQueryable<WSProductFirstGroup_Lang>)wSProductFirstGroup_Lang, Expression.Lambda<Func<WSProductFirstGroup_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass12_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass12_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSProductFirstGroup_Lang2 != null)
								{
									wSProductFirstGroup_Lang2.FGDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSProductFirstGroup_Lang2.FGName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSProductFirstGroup_Lang2.FGSHPName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSProductFirstGroup_Lang2.FGSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSProductFirstGroup_Lang2.FGSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSProductFirstGroup_Lang2.FGSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSProductFirstGroup_Lang2.FGSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSProductFirstGroup_Lang2.FGSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSProductFirstGroup_Lang2.FGSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSProductFirstGroup_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSProductFirstGroup_Lang2 = new WSProductFirstGroup_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									PrdFirstGroupID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.item.PrdFirstGroupID,
									FGDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									FGName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									FGSHPName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									FGSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									FGSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									FGSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									FGSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									FGSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									FGSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.WSProductFirstGroup_Lang.Add(wSProductFirstGroup_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						model.UserId = _003C_003Ec__DisplayClass12_.item.UserId;
						model.RegisterDate = _003C_003Ec__DisplayClass12_.item.RegisterDate;
						model.AppType = _003C_003Ec__DisplayClass12_.item.AppType;
						model.FirstRegisterUserId = _003C_003Ec__DisplayClass12_.item.FirstRegisterUserId;
						model.FirstRegisterDate = _003C_003Ec__DisplayClass12_.item.FirstRegisterDate;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		SetUserNameDateForProductGroup(model);
		return View(model);
	}

	[AjaxOnly]
	public ActionResult _PartialSecondGroup(int id)
	{
		base.ViewBag.ParentId = id;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult ProductsGroupsSecond_Read([DataSourceRequest] DataSourceRequest request, int id)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectWSProductSecondGroup_Result> list = Enumerable.ToList<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)_db.WSspSelectWSProductSecondGroup(lCID, result, id));
		List<ProductGroupViewModel> list2 = new List<ProductGroupViewModel>();
		foreach (WSspSelectWSProductSecondGroup_Result item in list)
		{
			list2.Add(new ProductGroupViewModel
			{
				PrdGroupID = item.PrdSecondGroupID,
				FGCode = item.SGCode,
				FGDescription = item.SGDescription,
				FGInactiveInBuy = item.SGInactiveInBuy.GetValueOrDefault(),
				FGInactiveInSale = item.SGInactiveInSale.GetValueOrDefault(),
				FGSubName = item.SGName,
				FGNameEn = item.SGNameEn,
				FGOrderView = item.SGOrderView,
				FGSHPIsActive = (item.SGSHPIsActive.HasValue && item.SGSHPIsActive != false),
				SGSHPName = item.SGSHPName
			});
		}
		return Json(((IEnumerable)list2).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actDeleteSG")]
	public string DeleteSecondGroup(int id)
	{
		_003C_003Ec__DisplayClass15_0 _003C_003Ec__DisplayClass15_ = new _003C_003Ec__DisplayClass15_0();
		_003C_003Ec__DisplayClass15_.id = id;
		try
		{
			DbSet<WSProductSecondGroup> wSProductSecondGroup = _dbTbl.WSProductSecondGroup;
			ParameterExpression val = Expression.Parameter(typeof(WSProductSecondGroup), "c");
			if (Queryable.FirstOrDefault<WSProductSecondGroup>((IQueryable<WSProductSecondGroup>)wSProductSecondGroup, Expression.Lambda<Func<WSProductSecondGroup, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass15_, typeof(_003C_003Ec__DisplayClass15_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSProductSecondGroup(_003C_003Ec__DisplayClass15_.id)));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
					return "";
				}
				return Messages.RedundancyMessage;
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
		}
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actInsertSG")]
	public ActionResult InsertSecondGroup(int? firstId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetCompanyGroupsII();
		string text = "";
		try
		{
			if (!firstId.HasValue)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
			}
			else
			{
				WSspSelectProductFirstGroup_Result wSspSelectProductFirstGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result)), (Func<WSspSelectProductFirstGroup_Result, bool>)((WSspSelectProductFirstGroup_Result c) => c.PrdFirstGroupID == firstId));
				if (wSspSelectProductFirstGroup_Result == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
				}
				else
				{
					text = wSspSelectProductFirstGroup_Result.FGName;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		base.ViewBag.FirstId = firstId;
		base.ViewBag.FirstName = text;
		DateTime now = DateTime.Now;
		ProductGroupViewModel productGroupViewModel = new ProductGroupViewModel
		{
			UserId = UserLogin.CurrentUser.UserId,
			RegisterDate = now,
			AppType = Configuration.AppType,
			FirstRegisterUserId = UserLogin.CurrentUser.UserId,
			FirstRegisterDate = now,
			FGSHPIsActive = false
		};
		SetUserNameDateForProductGroup(productGroupViewModel);
		return View(productGroupViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductGroupsDataEntry", ActionName = "actPost")]
	public ActionResult InsertSecondGroup(ProductGroupViewModel model)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetCompanyGroupsII();
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.FGName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.FGName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = model.FGName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.FGDescription_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.FGDescription_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = model.FGDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SGSHPName_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SGSHPName_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SGSHPName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoTitle_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoTitle_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoDescription_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoDescription_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoAuthor_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoAuthor_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoAuthor,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoCopyright_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoCopyright_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoCopyright,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoKeywords_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoKeywords_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoKeywords,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoFAQ_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoFAQ_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoFAQ,
			LanguageId = lCID
		});
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			try
			{
				string text = "";
				if (model.FGName == null && model.FGName == "")
				{
					text = text + Messages.CheckFGName + "<br/>";
				}
				else if (!checkMultiLanguage(model.FGName, list))
				{
					text = text + Messages.CheckFGNameLang + "<br>";
				}
				if (text != "")
				{
					base.ViewBag.Error = text;
				}
				else
				{
					DateTime now = DateTime.Now;
					WSProductSecondGroup wSProductSecondGroup = new WSProductSecondGroup();
					wSProductSecondGroup.SGCode = model.FGCode;
					wSProductSecondGroup.SGDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductSecondGroup.SGName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductSecondGroup.FPId = Financial.Get().Id;
					wSProductSecondGroup.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					wSProductSecondGroup.UserId = UserLogin.CurrentUser.UserId;
					wSProductSecondGroup.RegisterDate = now;
					wSProductSecondGroup.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSProductSecondGroup.SGNameEn = model.FGNameEn;
					wSProductSecondGroup.GUId = Guid.NewGuid();
					if (model.FGInactiveInSale)
					{
						wSProductSecondGroup.SGInactiveInSale = model.FGInactiveInSale;
					}
					if (model.FGInactiveInBuy)
					{
						wSProductSecondGroup.SGInactiveInBuy = model.FGInactiveInBuy;
					}
					wSProductSecondGroup.FirstGroupId = model.PrdGroupID;
					wSProductSecondGroup.AppType = Configuration.AppType;
					wSProductSecondGroup.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					wSProductSecondGroup.FirstRegisterDate = now;
					wSProductSecondGroup.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSProductSecondGroup.LanguageID = defLangID;
					wSProductSecondGroup.SGOrderView = model.FGOrderView;
					wSProductSecondGroup.SGSHPIsActive = model.FGSHPIsActive;
					wSProductSecondGroup.TspSGIndentify = model.TspSGIndentify;
					wSProductSecondGroup.TspSGName = model.TspSGName;
					wSProductSecondGroup.SGCompanyGroupIIRateJson = model.SGCompanyGroupIIRateJson;
					wSProductSecondGroup.SGSHPName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductSecondGroup.SGSeoIsActive = model.SeoIsActive;
					wSProductSecondGroup.SGSeoTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductSecondGroup.SGSeoDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductSecondGroup.SGSeoHttpEquiv = model.SeoHttpEquiv;
					wSProductSecondGroup.SGSeoExpires = model.SeoExpires;
					wSProductSecondGroup.SGSeoGoogleNotranslate = model.SeoGoogleNotranslate;
					wSProductSecondGroup.SGSeoDistribution = model.SeoDistribution;
					wSProductSecondGroup.SGSeoRobots = model.SeoRobots;
					wSProductSecondGroup.SGSeoRating = model.SeoRating;
					wSProductSecondGroup.SGSeoAuthor = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductSecondGroup.SGSeoIsUseSocialNetwork = model.SeoIsUseSocialNetwork;
					wSProductSecondGroup.SGSeoMobileOptimized = model.SeoMobileOptimized;
					wSProductSecondGroup.SGSeoCopyright = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductSecondGroup.SGSeoUseDefault = model.SeoUseDefault;
					wSProductSecondGroup.SGSeoKeywords = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					wSProductSecondGroup.SGSeoFAQ = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					_dbTbl.WSProductSecondGroup.Add(wSProductSecondGroup);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						WSProductSecondGroup_Lang entity = new WSProductSecondGroup_Lang
						{
							LanguageID = lang.LanguageID,
							PrdSecondGroupID = wSProductSecondGroup.PrdSecondGroupID,
							SGDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							SGName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							SGSHPName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							SGSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							SGSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							SGSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							SGSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							SGSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							SGSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.WSProductSecondGroup_Lang.Add(entity);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					model.UserId = wSProductSecondGroup.UserId;
					model.RegisterDate = wSProductSecondGroup.RegisterDate;
					model.AppType = wSProductSecondGroup.AppType;
					model.FirstRegisterUserId = wSProductSecondGroup.FirstRegisterUserId;
					model.FirstRegisterDate = wSProductSecondGroup.FirstRegisterDate;
					model.PrdGroupID = wSProductSecondGroup.PrdSecondGroupID;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		base.ViewBag.FirstId = model.PrdGroupID;
		base.ViewBag.FirstName = model.FGSubName;
		SetUserNameDateForProductGroup(model);
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actEditSG")]
	public ActionResult EditSecondGroup(int id)
	{
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSProductSecondGroup_Lang> wSProductSecondGroup_Lang = _dbTbl.WSProductSecondGroup_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSProductSecondGroup_Lang), "c");
		List<WSProductSecondGroup_Lang> list = Enumerable.ToList<WSProductSecondGroup_Lang>((IEnumerable<WSProductSecondGroup_Lang>)Queryable.Where<WSProductSecondGroup_Lang>((IQueryable<WSProductSecondGroup_Lang>)wSProductSecondGroup_Lang, Expression.Lambda<Func<WSProductSecondGroup_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass18_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		GetCompanyGroupsII();
		ProductGroupViewModel productGroupViewModel = new ProductGroupViewModel();
		string text = "";
		try
		{
			DbSet<WSProductSecondGroup> wSProductSecondGroup = _dbTbl.WSProductSecondGroup;
			val = Expression.Parameter(typeof(WSProductSecondGroup), "c");
			WSProductSecondGroup itemSG = Queryable.FirstOrDefault<WSProductSecondGroup>((IQueryable<WSProductSecondGroup>)wSProductSecondGroup, Expression.Lambda<Func<WSProductSecondGroup, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass18_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (itemSG == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
			}
			else
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSecondGroup_Lang>)list, (Func<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>)((WSProductSecondGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SGName,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = itemSG.SGName,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSecondGroup_Lang>)list, (Func<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>)((WSProductSecondGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SGDescription,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = itemSG.SGDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSecondGroup_Lang>)list, (Func<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>)((WSProductSecondGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SGSHPName,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = itemSG.SGSHPName,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSecondGroup_Lang>)list, (Func<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>)((WSProductSecondGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SGSeoTitle,
					LanguageId = item.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = itemSG.SGSeoTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSecondGroup_Lang>)list, (Func<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>)((WSProductSecondGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SGSeoDescription,
					LanguageId = item.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = itemSG.SGSeoDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSecondGroup_Lang>)list, (Func<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>)((WSProductSecondGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SGSeoAuthor,
					LanguageId = item.LanguageID
				})));
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = itemSG.SGSeoAuthor,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSecondGroup_Lang>)list, (Func<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>)((WSProductSecondGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SGSeoCopyright,
					LanguageId = item.LanguageID
				})));
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = itemSG.SGSeoCopyright,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSecondGroup_Lang>)list, (Func<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>)((WSProductSecondGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SGSeoKeywords,
					LanguageId = item.LanguageID
				})));
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = itemSG.SGSeoKeywords,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSecondGroup_Lang>)list, (Func<WSProductSecondGroup_Lang, CommonMultiLanguageViewModel>)((WSProductSecondGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SGSeoFAQ,
					LanguageId = item.LanguageID
				})));
				list10.Add(new CommonMultiLanguageViewModel
				{
					Value = itemSG.SGSeoFAQ,
					LanguageId = result
				});
				WSspSelectProductFirstGroup_Result wSspSelectProductFirstGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(CS_0024_003C_003E8__locals0.currLangID, result)), (Func<WSspSelectProductFirstGroup_Result, bool>)((WSspSelectProductFirstGroup_Result c) => c.PrdFirstGroupID == itemSG.FirstGroupId));
				if (wSspSelectProductFirstGroup_Result != null)
				{
					productGroupViewModel.FGSubName = itemSG.FirstGroupId.ToString();
					text = wSspSelectProductFirstGroup_Result.FGName;
					productGroupViewModel.FGName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					productGroupViewModel.FGCode = itemSG.SGCode;
					productGroupViewModel.FGDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					productGroupViewModel.FGInactiveInBuy = itemSG.SGInactiveInBuy.GetValueOrDefault();
					productGroupViewModel.FGInactiveInSale = itemSG.SGInactiveInSale.GetValueOrDefault();
					productGroupViewModel.FGNameEn = itemSG.SGNameEn;
					productGroupViewModel.PrdGroupID = itemSG.PrdSecondGroupID;
					productGroupViewModel.FGName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					productGroupViewModel.FGDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					productGroupViewModel.UserId = itemSG.UserId;
					productGroupViewModel.FirstRegisterUserId = itemSG.FirstRegisterUserId;
					productGroupViewModel.FirstRegisterDate = itemSG.FirstRegisterDate;
					productGroupViewModel.RegisterDate = itemSG.RegisterDate;
					productGroupViewModel.AppType = itemSG.AppType;
					productGroupViewModel.FGOrderView = itemSG.SGOrderView;
					productGroupViewModel.FGSHPIsActive = itemSG.SGSHPIsActive.HasValue && itemSG.SGSHPIsActive != false;
					productGroupViewModel.TspSGIndentify = itemSG.TspSGIndentify;
					productGroupViewModel.TspSGName = itemSG.TspSGName;
					productGroupViewModel.SGCompanyGroupIIRateJson = itemSG.SGCompanyGroupIIRateJson;
					productGroupViewModel.SGSHPName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					productGroupViewModel.SGSHPName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					productGroupViewModel.SeoIsActive = itemSG.SGSeoIsActive;
					productGroupViewModel.SeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					productGroupViewModel.SeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					productGroupViewModel.SeoHttpEquiv = itemSG.SGSeoHttpEquiv;
					productGroupViewModel.SeoExpires = itemSG.SGSeoExpires;
					productGroupViewModel.SeoGoogleNotranslate = itemSG.SGSeoGoogleNotranslate;
					productGroupViewModel.SeoDistribution = itemSG.SGSeoDistribution;
					productGroupViewModel.SeoRobots = itemSG.SGSeoRobots;
					productGroupViewModel.SeoRating = itemSG.SGSeoRating;
					productGroupViewModel.SeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					productGroupViewModel.SeoIsUseSocialNetwork = itemSG.SGSeoIsUseSocialNetwork;
					productGroupViewModel.SeoMobileOptimized = itemSG.SGSeoMobileOptimized;
					productGroupViewModel.SeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					productGroupViewModel.SeoUseDefault = itemSG.SGSeoUseDefault;
					productGroupViewModel.SeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					productGroupViewModel.SeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					productGroupViewModel.SeoTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					productGroupViewModel.SeoDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					productGroupViewModel.SeoAuthor_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					productGroupViewModel.SeoCopyright_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					productGroupViewModel.SeoKeywords_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					productGroupViewModel.SeoFAQ_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				}
				else
				{
					DateTime now = DateTime.Now;
					productGroupViewModel.UserId = UserLogin.CurrentUser.UserId;
					productGroupViewModel.RegisterDate = now;
					productGroupViewModel.AppType = Configuration.AppType;
					productGroupViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					productGroupViewModel.FirstRegisterDate = now;
					base.ViewBag.Error = Messages.ErrorNotFound;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		base.ViewBag.FirstName = text;
		SetUserNameDateForProductGroup(productGroupViewModel);
		return View(productGroupViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductGroupsDataEntry", ActionName = "actPost")]
	public ActionResult EditSecondGroup(ProductGroupViewModel model)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetCompanyGroupsII();
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.FGName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.FGName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = model.FGName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.FGDescription_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.FGDescription_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = model.FGDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SGSHPName_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SGSHPName_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SGSHPName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoTitle_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoTitle_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoDescription_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoDescription_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoAuthor_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoAuthor_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoAuthor,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoCopyright_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoCopyright_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoCopyright,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoKeywords_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoKeywords_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoKeywords,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SeoFAQ_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SeoFAQ_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SeoFAQ,
			LanguageId = lCID
		});
		string text = "";
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			try
			{
				string text2 = "";
				if (model.FGName == null && model.FGName == "")
				{
					text2 = text2 + Messages.CheckFGName + "<br/>";
				}
				else if (!checkMultiLanguage(model.FGName, list))
				{
					text2 = text2 + Messages.CheckFGNameLang + "<br>";
				}
				if (text2 != "")
				{
					base.ViewBag.Error = text2;
				}
				else
				{
					_003C_003Ec__DisplayClass19_1 _003C_003Ec__DisplayClass19_ = new _003C_003Ec__DisplayClass19_1();
					DateTime now = DateTime.Now;
					_003C_003Ec__DisplayClass19_.item = _dbTbl.WSProductSecondGroup.Find(model.PrdGroupID);
					if (_003C_003Ec__DisplayClass19_.item == null)
					{
						base.ViewBag.Error = Messages.ErrorNotFound;
					}
					else
					{
						WSProductFirstGroup wSProductFirstGroup = _dbTbl.WSProductFirstGroup.Find(_003C_003Ec__DisplayClass19_.item.FirstGroupId);
						if (wSProductFirstGroup == null)
						{
							base.ViewBag.Error = Messages.ErrorNotFound;
						}
						else
						{
							text = wSProductFirstGroup.FGName;
							model.FGSubName = _003C_003Ec__DisplayClass19_.item.FirstGroupId.ToString();
							_003C_003Ec__DisplayClass19_.item.SGName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass19_.item.SGCode = model.FGCode;
							_003C_003Ec__DisplayClass19_.item.SGDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass19_.item.SGInactiveInBuy = model.FGInactiveInBuy;
							_003C_003Ec__DisplayClass19_.item.SGInactiveInSale = model.FGInactiveInSale;
							_003C_003Ec__DisplayClass19_.item.SGNameEn = model.FGNameEn;
							_003C_003Ec__DisplayClass19_.item.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							_003C_003Ec__DisplayClass19_.item.UserId = UserLogin.CurrentUser.UserId;
							_003C_003Ec__DisplayClass19_.item.RegisterDate = now;
							_003C_003Ec__DisplayClass19_.item.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							_003C_003Ec__DisplayClass19_.item.FPId = Financial.Get().Id;
							_003C_003Ec__DisplayClass19_.item.AppType = Configuration.AppType;
							_003C_003Ec__DisplayClass19_.item.SGOrderView = model.FGOrderView;
							_003C_003Ec__DisplayClass19_.item.SGSHPIsActive = model.FGSHPIsActive;
							_003C_003Ec__DisplayClass19_.item.TspSGIndentify = model.TspSGIndentify;
							_003C_003Ec__DisplayClass19_.item.TspSGName = model.TspSGName;
							_003C_003Ec__DisplayClass19_.item.SGCompanyGroupIIRateJson = model.SGCompanyGroupIIRateJson;
							_003C_003Ec__DisplayClass19_.item.SGSHPName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass19_.item.SGSeoIsActive = model.SeoIsActive;
							_003C_003Ec__DisplayClass19_.item.SGSeoTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass19_.item.SGSeoDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass19_.item.SGSeoHttpEquiv = model.SeoHttpEquiv;
							_003C_003Ec__DisplayClass19_.item.SGSeoExpires = model.SeoExpires;
							_003C_003Ec__DisplayClass19_.item.SGSeoGoogleNotranslate = model.SeoGoogleNotranslate;
							_003C_003Ec__DisplayClass19_.item.SGSeoDistribution = model.SeoDistribution;
							_003C_003Ec__DisplayClass19_.item.SGSeoRobots = model.SeoRobots;
							_003C_003Ec__DisplayClass19_.item.SGSeoRating = model.SeoRating;
							_003C_003Ec__DisplayClass19_.item.SGSeoAuthor = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass19_.item.SGSeoIsUseSocialNetwork = model.SeoIsUseSocialNetwork;
							_003C_003Ec__DisplayClass19_.item.SGSeoMobileOptimized = model.SeoMobileOptimized;
							_003C_003Ec__DisplayClass19_.item.SGSeoCopyright = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass19_.item.SGSeoUseDefault = model.SeoUseDefault;
							_003C_003Ec__DisplayClass19_.item.SGSeoKeywords = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass19_.item.SGSeoFAQ = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_dbTbl.Entry(_003C_003Ec__DisplayClass19_.item).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass19_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass19_2();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass19_;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<WSProductSecondGroup_Lang> wSProductSecondGroup_Lang = _dbTbl.WSProductSecondGroup_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSProductSecondGroup_Lang), "c");
									WSProductSecondGroup_Lang wSProductSecondGroup_Lang2 = Queryable.FirstOrDefault<WSProductSecondGroup_Lang>((IQueryable<WSProductSecondGroup_Lang>)wSProductSecondGroup_Lang, Expression.Lambda<Func<WSProductSecondGroup_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass19_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass19_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (wSProductSecondGroup_Lang2 != null)
									{
										wSProductSecondGroup_Lang2.SGDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSProductSecondGroup_Lang2.SGName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSProductSecondGroup_Lang2.SGSHPName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSProductSecondGroup_Lang2.SGSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSProductSecondGroup_Lang2.SGSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSProductSecondGroup_Lang2.SGSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSProductSecondGroup_Lang2.SGSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSProductSecondGroup_Lang2.SGSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSProductSecondGroup_Lang2.SGSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(wSProductSecondGroup_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									wSProductSecondGroup_Lang2 = new WSProductSecondGroup_Lang
									{
										LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
										PrdSecondGroupID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.item.PrdSecondGroupID,
										SGDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										SGName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										SGSHPName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										SGSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										SGSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										SGSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										SGSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										SGSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										SGSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
									};
									_dbTbl.WSProductSecondGroup_Lang.Add(wSProductSecondGroup_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
							model.UserId = _003C_003Ec__DisplayClass19_.item.UserId;
							model.RegisterDate = _003C_003Ec__DisplayClass19_.item.RegisterDate;
							model.AppType = _003C_003Ec__DisplayClass19_.item.AppType;
							model.FirstRegisterUserId = _003C_003Ec__DisplayClass19_.item.FirstRegisterUserId;
							model.FirstRegisterDate = _003C_003Ec__DisplayClass19_.item.FirstRegisterDate;
						}
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		base.ViewBag.FirstName = text;
		SetUserNameDateForProductGroup(model);
		return View(model);
	}

	public void SetRegisterInfoForPrdGroupPic(WSProductGroupPictureViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string firstRegisterInfo = "";
		string editInfo = "";
		try
		{
			string text = "";
			string text2 = "";
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId);
			if (cRMspSelectUsersById_Result != null)
			{
				text = cRMspSelectUsersById_Result.LName + ((cRMspSelectUsersById_Result.FName != null) ? (" " + cRMspSelectUsersById_Result.FName) : "");
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
			if (cRMspSelectUsersById_Result2 != null)
			{
				text2 = cRMspSelectUsersById_Result2.LName + ((cRMspSelectUsersById_Result2.FName != null) ? (" " + cRMspSelectUsersById_Result2.FName) : "");
			}
			_ = model.FirstRegisterDate;
			string text3 = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			_ = model.RegisterDate;
			string text4 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text5 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			if (model.AppType != "new")
			{
				firstRegisterInfo = Labels.frmFirstRegisterUser + ": " + text + " (" + text3 + ")";
				editInfo = Labels.frmRegisterUser + ": " + text2 + " (" + text5 + ") (" + text4 + ")";
			}
			else
			{
				firstRegisterInfo = Labels.frmFirstRegisterUser + ": ";
				editInfo = Labels.frmRegisterUser + ": ";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		model.FirstRegisterInfo = firstRegisterInfo;
		model.EditInfo = editInfo;
	}

	[LoginAuthorize]
	public ActionResult PrdGroupPicture(int type, int prdGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		WSProductGroupPictureViewModel wSProductGroupPictureViewModel = new WSProductGroupPictureViewModel
		{
			PrdGroupId = prdGroupId,
			Type = type
		};
		try
		{
			WSspSelectProductGroupPictureByPrdGroupId_Result model = Enumerable.FirstOrDefault<WSspSelectProductGroupPictureByPrdGroupId_Result>((IEnumerable<WSspSelectProductGroupPictureByPrdGroupId_Result>)_db.WSspSelectProductGroupPictureByPrdGroupId(prdGroupId, type));
			if (model != null)
			{
				UpdatePrdGroupPicturePath(ref model);
				wSProductGroupPictureViewModel.ProductGroupPictureId = model.ProductGroupPictureId;
				wSProductGroupPictureViewModel.FirstRegisterUserId = model.FirstRegisterUserId;
				wSProductGroupPictureViewModel.FirstRegisterDate = model.FirstRegisterDate;
				wSProductGroupPictureViewModel.UserId = model.UserId;
				wSProductGroupPictureViewModel.RegisterDate = model.RegisterDate;
				wSProductGroupPictureViewModel.AppType = model.AppType;
				wSProductGroupPictureViewModel.FolderName = model.FolderName;
				wSProductGroupPictureViewModel.FileName = model.FileName;
				wSProductGroupPictureViewModel.FilePath = model.FilePath;
				wSProductGroupPictureViewModel.FirstGroupId = model.FirstGroupId;
			}
			else
			{
				int firstRegisterUserId = (wSProductGroupPictureViewModel.UserId = UserLogin.CurrentUser.UserId);
				wSProductGroupPictureViewModel.FirstRegisterUserId = firstRegisterUserId;
				wSProductGroupPictureViewModel.RegisterDate = now;
				wSProductGroupPictureViewModel.FirstRegisterDate = now;
				wSProductGroupPictureViewModel.AppType = "new";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Update = false;
		SetRegisterInfoForPrdGroupPic(wSProductGroupPictureViewModel);
		return View(wSProductGroupPictureViewModel);
	}

	public void UpdatePrdGroupPicturePath(ref WSspSelectProductGroupPictureByPrdGroupId_Result model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			if (string.IsNullOrWhiteSpace(model.FilePath))
			{
				_003C_003Ec__DisplayClass22_0 _003C_003Ec__DisplayClass22_ = new _003C_003Ec__DisplayClass22_0();
				int result2 = 0;
				int.TryParse(model.FirstGroupId.ToString(), out result2);
				_003C_003Ec__DisplayClass22_.productGroupPictureId = 0;
				int.TryParse(model.ProductGroupPictureId.ToString(), out _003C_003Ec__DisplayClass22_.productGroupPictureId);
				if (result2 != 0)
				{
					model.FolderName = result2.ToString();
				}
				else if (model.Type.GetValueOrDefault() == 1)
				{
					model.FolderName = model.PrdGroupId.ToString();
					result2 = model.PrdGroupId;
				}
				byte[] array = null;
				if (model.PrdGroupPic != null)
				{
					array = model.PrdGroupPic;
					MemoryStream memoryStream = new MemoryStream(array, writable: false);
					Image.FromStream((Stream)memoryStream);
					memoryStream.Dispose();
					memoryStream.Close();
				}
				model.FileName = model.PrdGroupId + "-" + model.ProductGroupPictureId + ".jpg";
				if (array == null)
				{
					return;
				}
				string fileName = model.FileName;
				string text = Configuration.MainDirectoryPath;
				string prdGroupDirectoryPath = Configuration.PrdGroupDirectoryPath;
				prdGroupDirectoryPath = (prdGroupDirectoryPath.EndsWith("/") ? prdGroupDirectoryPath.TrimEnd(new char[1] { '/' }) : prdGroupDirectoryPath);
				bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text, prdGroupDirectoryPath, usePassiveFtp);
				if (!flag)
				{
					flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, prdGroupDirectoryPath, usePassiveFtp);
				}
				bool flag2 = true;
				if (result2 != 0)
				{
					text = Configuration.MainDirectoryPath + Configuration.PrdGroupDirectoryPath;
					flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text, result2.ToString(), usePassiveFtp);
					if (!flag2)
					{
						flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text, result2.ToString(), usePassiveFtp);
					}
				}
				if (flag && flag2)
				{
					text = Configuration.MainDirectoryPath + Configuration.PrdGroupDirectoryPath;
					if (result2 != 0)
					{
						text = text + result2 + "/";
					}
					byte[] bytes = ImageManager.CompressByte(new ImageManager.ImageParam
					{
						Bytes = array,
						FileExtension = "jpg"
					});
					string text2 = ImageManager.SaveFromByte(new ImageManager.ImageParam
					{
						Bytes = bytes
					});
					if (!facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text + fileName, text2, usePassiveFtp))
					{
						return;
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ImageManager.DeleteFile(new ImageManager.ImageParam
						{
							FilePath = text2
						});
					}
					DbSet<WSProductGroupPicture> wSProductGroupPicture = _dbTbl.WSProductGroupPicture;
					ParameterExpression val = Expression.Parameter(typeof(WSProductGroupPicture), "m");
					WSProductGroupPicture wSProductGroupPicture2 = Queryable.FirstOrDefault<WSProductGroupPicture>((IQueryable<WSProductGroupPicture>)wSProductGroupPicture, Expression.Lambda<Func<WSProductGroupPicture, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass22_, typeof(_003C_003Ec__DisplayClass22_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					wSProductGroupPicture2.FolderName = model.FolderName;
					wSProductGroupPicture2.FileName = fileName;
					wSProductGroupPicture2.FilePath = text + fileName;
					_dbTbl.Entry(wSProductGroupPicture2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					model.FileName = fileName;
					model.FilePath = text + fileName;
					string pathFtpFo = Configuration.PathFtpFo;
					string userNameFtpFo = Configuration.UserNameFtpFo;
					string passwordFtpFo = Configuration.PasswordFtpFo;
					_ = Configuration.UsePassiveFtpFo;
					if (string.IsNullOrEmpty(pathFtpFo) || string.IsNullOrEmpty(userNameFtpFo) || string.IsNullOrEmpty(passwordFtpFo))
					{
						return;
					}
					try
					{
						string text3 = "/" + Configuration.PrdGroupDirectoryPath;
						if (result2 != 0)
						{
							text3 += result2;
						}
						string text4 = base.Server.MapPath(text3);
						if (!System.IO.Directory.Exists(text4))
						{
							System.IO.Directory.CreateDirectory(text4);
							CRM.General.IO.Directory.SetFullControlForEveryOne(text4);
						}
						text4 = text4 + "\\" + fileName;
						string source = model.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
						bool flag3 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text4, source, overwrite: true, usePassiveFtp);
						if (!(System.IO.File.Exists(text4) && flag3) || fileName.IndexOf(".") <= 0)
						{
							return;
						}
						string text5 = fileName;
						text5 = text5.Insert(fileName.IndexOf("."), "-Thumb");
						string text6 = HttpContext.Current.Server.MapPath(text3 + "\\" + text5);
						if (!System.IO.File.Exists(text6))
						{
							ImageManager.CompressFile(new ImageManager.ImageParam
							{
								FilePath = text4,
								DestPath = text6,
								CustomHeight = 300,
								CustomWidth = 300,
								FileExtension = Path.GetExtension(text4)
							});
						}
						if (System.IO.File.Exists(text6))
						{
							try
							{
								Files.UploadFileToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtp, text3 + "/" + fileName);
								Files.UploadFileToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtp, text3 + "/" + text5);
								return;
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								return;
							}
						}
						return;
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						return;
					}
				}
				Exception e3 = new Exception("خطا در ایجاد فولدر ftp,   -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text);
				ErrorSignal.FromCurrentContext().Raise(e3);
				return;
			}
			try
			{
				string fileName2 = model.FileName;
				string text7 = model.FilePath.Replace(Configuration.MainDirectoryPath, "");
				text7 = text7.Replace("/" + fileName2, "");
				if (!text7.StartsWith("/"))
				{
					text7 = "/" + text7;
				}
				string text8 = base.Server.MapPath(text7);
				if (!System.IO.Directory.Exists(text8))
				{
					System.IO.Directory.CreateDirectory(text8);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
				}
				text8 = text8 + "\\" + fileName2;
				bool flag4 = true;
				if (!System.IO.File.Exists(text8))
				{
					string source2 = model.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					flag4 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text8, source2, overwrite: true, usePassiveFtp);
				}
				if (System.IO.File.Exists(text8) && flag4)
				{
					model.FilePath = text7 + "\\" + fileName2;
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
			}
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
	}

	public ActionResult ActSetPrdGroupPicture(HttpPostedFileBase picUrlUpload, int type, int prdGroupId)
	{
		string content = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			short month = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime dateTime = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			int id = Financial.Get().Id;
			string appType = Configuration.AppType;
			switch (type)
			{
			case 1:
				if (!UserLogin.IsUserAccess("frmProductGroup", "actInsertFGPicture", UserLogin.CurrentUser))
				{
					return Content(Messages.ErrorNotAccess);
				}
				break;
			case 2:
				if (!UserLogin.IsUserAccess("frmProductGroup", "actInsertSGPicture", UserLogin.CurrentUser))
				{
					return Content(Messages.ErrorNotAccess);
				}
				break;
			default:
				return Content(Messages.ErrorNotAccess);
			}
			if (picUrlUpload == null)
			{
				content = Messages.frmErrorNotFileSelected;
				return Content(content);
			}
			string text2 = picUrlUpload.ContentType.ToLower();
			string extension = Path.GetExtension(picUrlUpload.FileName);
			if (extension == null)
			{
				content = Messages.frmErrorNotImageFile;
				return Content(content);
			}
			string text3 = extension.ToLower();
			if ((text2 != "image/jpg" && text2 != "image/jpeg" && text2 != "image/pjpeg" && text2 != "image/gif" && text2 != "image/x-png" && text2 != "image/png") || (text3 != ".jpg" && text3 != ".png" && text3 != ".gif" && text3 != ".jpeg"))
			{
				content = Messages.frmErrorNotImageFile;
				return Content(content);
			}
			int num = picUrlUpload.ContentLength / 1024;
			int maxImageSizeForUploadKb = Configuration.MaxImageSizeForUploadKb;
			if (num > maxImageSizeForUploadKb)
			{
				content = string.Format(Messages.frmErrorMaxImageSizeForUpload, maxImageSizeForUploadKb);
				return Content(content);
			}
			WSspSelectProductGroupPictureByPrdGroupId_Result wSspSelectProductGroupPictureByPrdGroupId_Result = Enumerable.FirstOrDefault<WSspSelectProductGroupPictureByPrdGroupId_Result>((IEnumerable<WSspSelectProductGroupPictureByPrdGroupId_Result>)_db.WSspSelectProductGroupPictureByPrdGroupId(prdGroupId, type));
			bool flag = false;
			if (wSspSelectProductGroupPictureByPrdGroupId_Result == null)
			{
				wSspSelectProductGroupPictureByPrdGroupId_Result = new WSspSelectProductGroupPictureByPrdGroupId_Result();
				flag = true;
				wSspSelectProductGroupPictureByPrdGroupId_Result.PrdGroupId = prdGroupId;
				wSspSelectProductGroupPictureByPrdGroupId_Result.Type = type;
				wSspSelectProductGroupPictureByPrdGroupId_Result.GUId = Guid.NewGuid();
			}
			int result2 = 0;
			int.TryParse(wSspSelectProductGroupPictureByPrdGroupId_Result.FirstGroupId.ToString(), out result2);
			if (result2 != 0)
			{
				wSspSelectProductGroupPictureByPrdGroupId_Result.FolderName = result2.ToString();
			}
			else if (type == 1)
			{
				wSspSelectProductGroupPictureByPrdGroupId_Result.FolderName = prdGroupId.ToString();
				result2 = prdGroupId;
			}
			WSProductGroupPicture wSProductGroupPicture = new WSProductGroupPicture();
			wSProductGroupPicture.ProductGroupPictureId = wSspSelectProductGroupPictureByPrdGroupId_Result.ProductGroupPictureId;
			wSProductGroupPicture.PrdGroupId = wSspSelectProductGroupPictureByPrdGroupId_Result.PrdGroupId;
			wSProductGroupPicture.PrdGroupPic = wSspSelectProductGroupPictureByPrdGroupId_Result.PrdGroupPic;
			wSProductGroupPicture.Type = wSspSelectProductGroupPictureByPrdGroupId_Result.Type;
			wSProductGroupPicture.UserId = userId;
			wSProductGroupPicture.FPId = id;
			wSProductGroupPicture.Month1 = month;
			wSProductGroupPicture.RegisterDate = dateTime;
			wSProductGroupPicture.RegisterDatePersian = text;
			wSProductGroupPicture.AppType = appType;
			wSProductGroupPicture.FirstRegisterDate = wSspSelectProductGroupPictureByPrdGroupId_Result.FirstRegisterDate;
			wSProductGroupPicture.FirstRegisterDatePersian = wSspSelectProductGroupPictureByPrdGroupId_Result.FirstRegisterDatePersian;
			wSProductGroupPicture.FirstRegisterUserId = wSspSelectProductGroupPictureByPrdGroupId_Result.FirstRegisterUserId;
			wSProductGroupPicture.LanguageID = wSspSelectProductGroupPictureByPrdGroupId_Result.LanguageID;
			wSProductGroupPicture.GUId = wSspSelectProductGroupPictureByPrdGroupId_Result.GUId;
			wSspSelectProductGroupPictureByPrdGroupId_Result.FileName = wSspSelectProductGroupPictureByPrdGroupId_Result.PrdGroupId + "-" + wSspSelectProductGroupPictureByPrdGroupId_Result.ProductGroupPictureId + ".jpg";
			wSspSelectProductGroupPictureByPrdGroupId_Result.FilePath = wSspSelectProductGroupPictureByPrdGroupId_Result.FilePath;
			if (flag)
			{
				wSProductGroupPicture.PrdGroupId = prdGroupId;
				wSProductGroupPicture.Type = type;
				wSProductGroupPicture.FirstRegisterDate = dateTime;
				wSProductGroupPicture.FirstRegisterDatePersian = text;
				wSProductGroupPicture.FirstRegisterUserId = userId;
				wSProductGroupPicture.LanguageID = result;
				wSProductGroupPicture.GUId = Guid.NewGuid();
				_dbTbl.WSProductGroupPicture.Add(wSProductGroupPicture);
				_dbTbl.Configuration.ValidateOnSaveEnabled = false;
				_dbTbl.SaveChanges();
				_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				wSspSelectProductGroupPictureByPrdGroupId_Result = Enumerable.FirstOrDefault<WSspSelectProductGroupPictureByPrdGroupId_Result>((IEnumerable<WSspSelectProductGroupPictureByPrdGroupId_Result>)_db.WSspSelectProductGroupPictureByPrdGroupId(prdGroupId, type));
			}
			if (wSProductGroupPicture.ProductGroupPictureId > 0)
			{
				int.TryParse(wSspSelectProductGroupPictureByPrdGroupId_Result.FirstGroupId.ToString(), out result2);
				if (result2 != 0)
				{
					wSspSelectProductGroupPictureByPrdGroupId_Result.FolderName = result2.ToString();
				}
				else if (type == 1)
				{
					wSspSelectProductGroupPictureByPrdGroupId_Result.FolderName = prdGroupId.ToString();
					result2 = prdGroupId;
				}
				wSspSelectProductGroupPictureByPrdGroupId_Result.FileName = wSspSelectProductGroupPictureByPrdGroupId_Result.PrdGroupId + "-" + wSspSelectProductGroupPictureByPrdGroupId_Result.ProductGroupPictureId;
				if (picUrlUpload != null)
				{
					string[] array = picUrlUpload.FileName.Split(new char[1] { '.' });
					string text4 = wSspSelectProductGroupPictureByPrdGroupId_Result.FileName + "." + array[^1];
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					string pathFtp = Configuration.PathFtp;
					string userNameFtp = Configuration.UserNameFtp;
					string passwordFtp = Configuration.PasswordFtp;
					bool usePassiveFtp = Configuration.UsePassiveFtp;
					string text5 = Configuration.MainDirectoryPath;
					string prdGroupDirectoryPath = Configuration.PrdGroupDirectoryPath;
					prdGroupDirectoryPath = (prdGroupDirectoryPath.EndsWith("/") ? prdGroupDirectoryPath.TrimEnd(new char[1] { '/' }) : prdGroupDirectoryPath);
					bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text5, prdGroupDirectoryPath, usePassiveFtp);
					if (!flag2)
					{
						flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, prdGroupDirectoryPath, usePassiveFtp);
					}
					bool flag3 = true;
					if (result2 != 0)
					{
						text5 = Configuration.MainDirectoryPath + Configuration.PrdGroupDirectoryPath;
						flag3 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text5, result2.ToString(), usePassiveFtp);
						if (!flag3)
						{
							flag3 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text5, result2.ToString(), usePassiveFtp);
						}
					}
					if (flag2 && flag3)
					{
						text5 = Configuration.MainDirectoryPath + Configuration.PrdGroupDirectoryPath;
						if (result2 != 0)
						{
							text5 = text5 + result2 + "/";
						}
						byte[] bytes = ImageManager.CompressHttpPostedFileBase(new ImageManager.ImageParam
						{
							HttpPostedFileBase_Var = picUrlUpload
						});
						string text6 = ImageManager.SaveFromByte(new ImageManager.ImageParam
						{
							Bytes = bytes
						});
						if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text5 + text4, text6, usePassiveFtp))
						{
							if (!string.IsNullOrWhiteSpace(text6))
							{
								ImageManager.DeleteFile(new ImageManager.ImageParam
								{
									FilePath = text6
								});
							}
							wSProductGroupPicture.PrdGroupPic = null;
							wSProductGroupPicture.FolderName = wSspSelectProductGroupPictureByPrdGroupId_Result.FolderName;
							wSProductGroupPicture.FileName = text4;
							wSProductGroupPicture.FilePath = text5 + text4;
							_dbTbl.Entry(wSProductGroupPicture).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							content = wSProductGroupPicture.ProductGroupPictureId.ToString();
							string pathFtpFo = Configuration.PathFtpFo;
							string userNameFtpFo = Configuration.UserNameFtpFo;
							string passwordFtpFo = Configuration.PasswordFtpFo;
							_ = Configuration.UsePassiveFtpFo;
							if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
							{
								try
								{
									string text7 = "/" + Configuration.PrdGroupDirectoryPath;
									if (result2 != 0)
									{
										text7 += result2;
									}
									string text8 = base.Server.MapPath(text7);
									if (!System.IO.Directory.Exists(text8))
									{
										System.IO.Directory.CreateDirectory(text8);
										CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
									}
									text8 = text8 + "\\" + text4;
									string source = wSProductGroupPicture.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
									bool flag4 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text8, source, overwrite: true, usePassiveFtp);
									if (System.IO.File.Exists(text8) && flag4 && text4.IndexOf(".") > 0)
									{
										string text9 = text4;
										text9 = text9.Insert(text4.IndexOf("."), "-Thumb");
										string text10 = HttpContext.Current.Server.MapPath(text7 + "\\" + text9);
										if (!System.IO.File.Exists(text10))
										{
											ImageManager.CompressFile(new ImageManager.ImageParam
											{
												FilePath = text8,
												DestPath = text10,
												CustomHeight = 300,
												CustomWidth = 300,
												FileExtension = Path.GetExtension(text8)
											});
										}
										if (System.IO.File.Exists(text10))
										{
											try
											{
												Files.UploadFileToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtp, text7 + "/" + text4);
												Files.UploadFileToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtp, text7 + "/" + text9);
											}
											catch (Exception e)
											{
												ErrorSignal.FromCurrentContext().Raise(e);
											}
										}
									}
								}
								catch (Exception e2)
								{
									ErrorSignal.FromCurrentContext().Raise(e2);
								}
							}
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						else
						{
							if (!string.IsNullOrWhiteSpace(text6))
							{
								ImageManager.DeleteFile(new ImageManager.ImageParam
								{
									FilePath = text6
								});
							}
							Exception e3 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text5 + text4);
							ErrorSignal.FromCurrentContext().Raise(e3);
							content = Messages.frmErrorInSendingFile;
						}
					}
					else
					{
						Exception e4 = new Exception("خطا در ایجاد فولدر ftp,   -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text5);
						ErrorSignal.FromCurrentContext().Raise(e4);
						content = Messages.frmErrorInSendingFile;
					}
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductGroupPicture");
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
		return Content(content);
	}

	public string GetPrdGroupPicture(int type, int prdGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		try
		{
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			WSspSelectProductGroupPictureByPrdGroupId_Result wSspSelectProductGroupPictureByPrdGroupId_Result = Enumerable.FirstOrDefault<WSspSelectProductGroupPictureByPrdGroupId_Result>((IEnumerable<WSspSelectProductGroupPictureByPrdGroupId_Result>)_db.WSspSelectProductGroupPictureByPrdGroupId(prdGroupId, type));
			if (wSspSelectProductGroupPictureByPrdGroupId_Result != null)
			{
				string fileName = wSspSelectProductGroupPictureByPrdGroupId_Result.FileName;
				string text = wSspSelectProductGroupPictureByPrdGroupId_Result.FilePath.Replace(Configuration.MainDirectoryPath, "");
				text = text.Replace("/" + fileName, "");
				if (!text.StartsWith("/"))
				{
					text = "/" + text;
				}
				string text2 = base.Server.MapPath(text);
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				text2 = text2 + "\\" + fileName;
				bool flag = true;
				if (!System.IO.File.Exists(text2))
				{
					string source = wSspSelectProductGroupPictureByPrdGroupId_Result.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					flag = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text2, source, overwrite: true, usePassiveFtp);
				}
				if (System.IO.File.Exists(text2) && flag)
				{
					result2 = text + "\\" + fileName;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public FileResult GetPrdGroupPicture_old(int type, int prdGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			byte[] array = null;
			WSspSelectProductGroupPictureByPrdGroupId_Result wSspSelectProductGroupPictureByPrdGroupId_Result = Enumerable.FirstOrDefault<WSspSelectProductGroupPictureByPrdGroupId_Result>((IEnumerable<WSspSelectProductGroupPictureByPrdGroupId_Result>)_db.WSspSelectProductGroupPictureByPrdGroupId(prdGroupId, type));
			if (wSspSelectProductGroupPictureByPrdGroupId_Result != null)
			{
				array = wSspSelectProductGroupPictureByPrdGroupId_Result.PrdGroupPic;
				MemoryStream memoryStream = new MemoryStream(array, writable: false);
				Image.FromStream((Stream)memoryStream);
				memoryStream.Dispose();
				memoryStream.Close();
			}
			return File(array, "image/png");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return null;
		}
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actDeleteFGPicture,actDeleteSGPicture")]
	public string PrdGroupPicDelete(int prdGroupPictureId, int type)
	{
		_003C_003Ec__DisplayClass26_0 _003C_003Ec__DisplayClass26_ = new _003C_003Ec__DisplayClass26_0();
		_003C_003Ec__DisplayClass26_.prdGroupPictureId = prdGroupPictureId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "0";
		try
		{
			switch (type)
			{
			case 1:
				if (!UserLogin.IsUserAccess("frmProductGroup", "actDeleteFGPicture", UserLogin.CurrentUser))
				{
					return Messages.ErrorNotAccess;
				}
				break;
			case 2:
				if (!UserLogin.IsUserAccess("frmProductGroup", "actDeleteSGPicture", UserLogin.CurrentUser))
				{
					return Messages.ErrorNotAccess;
				}
				break;
			default:
				return Messages.ErrorNotAccess;
			}
			DbSet<WSProductGroupPicture> wSProductGroupPicture = _dbTbl.WSProductGroupPicture;
			ParameterExpression val = Expression.Parameter(typeof(WSProductGroupPicture), "c");
			WSProductGroupPicture wSProductGroupPicture2 = Queryable.FirstOrDefault<WSProductGroupPicture>((IQueryable<WSProductGroupPicture>)wSProductGroupPicture, Expression.Lambda<Func<WSProductGroupPicture, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass26_, typeof(_003C_003Ec__DisplayClass26_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSProductGroupPicture2 != null)
			{
				try
				{
					string text = wSProductGroupPicture2.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					text = Configuration.MainDirectoryPath + Configuration.PrdGroupDirectoryPath + wSProductGroupPicture2.FolderName + "/" + wSProductGroupPicture2.FileName;
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					string text2 = text;
					if (facadeFTP.Delete(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, wSProductGroupPicture2.FileName, text2, Configuration.UsePassiveFtp))
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteProductGroupPicture(_003C_003Ec__DisplayClass26_.prdGroupPictureId));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							DeleteOldPrdGroupFromFtp(text2);
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductGroupPicture");
							result2 = "1";
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result2;
	}

	[LoginAuthorize]
	public string UploadAndUpadtePrdGroupPictures()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "0";
		try
		{
			List<WSspSelectProductGroupPicture_Result> list = Enumerable.ToList<WSspSelectProductGroupPicture_Result>((IEnumerable<WSspSelectProductGroupPicture_Result>)_dbII.WSspSelectProductGroupPicture());
			if (list != null && Enumerable.Any<WSspSelectProductGroupPicture_Result>((IEnumerable<WSspSelectProductGroupPicture_Result>)list))
			{
				foreach (WSspSelectProductGroupPicture_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.FilePath))
					{
						WSspSelectProductGroupPictureByPrdGroupId_Result model = new WSspSelectProductGroupPictureByPrdGroupId_Result
						{
							ProductGroupPictureId = item.ProductGroupPictureId,
							PrdGroupId = item.PrdGroupId,
							PrdGroupPic = item.PrdGroupPic,
							Type = item.Type,
							FirstRegisterUserId = item.FirstRegisterUserId,
							FirstRegisterDate = item.FirstRegisterDate,
							FirstRegisterDatePersian = item.FirstRegisterDatePersian,
							UserId = item.UserId,
							FPId = item.FPId,
							Month1 = item.Month1,
							RegisterDate = item.RegisterDate,
							RegisterDatePersian = item.RegisterDatePersian,
							GUId = item.GUId,
							AppType = item.AppType,
							LanguageID = item.LanguageID,
							FolderName = item.FolderName,
							FileName = item.FileName,
							FilePath = item.FilePath,
							FirstGroupId = item.FirstGroupId
						};
						UpdatePrdGroupPicturePath(ref model);
					}
				}
			}
			result2 = "1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public void DeleteOldPrdGroupFromFtp(string filePath)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			new FilesManager();
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			_ = Configuration.UsePassiveFtp;
			bool flag = !string.IsNullOrEmpty(pathFtp) && !string.IsNullOrEmpty(userNameFtp) && !string.IsNullOrEmpty(passwordFtp);
			string pathFtpFo = Configuration.PathFtpFo;
			string userNameFtpFo = Configuration.UserNameFtpFo;
			string passwordFtpFo = Configuration.PasswordFtpFo;
			bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
			bool flag2 = !string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo);
			string text = "";
			string[] array = filePath.Split(new char[1] { '/' });
			if (array != null && array.Length != 0)
			{
				text = array[^1];
			}
			if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			if (flag)
			{
				new FacadeFTP(Configuration.FacadeFtp);
				filePath.ToLower();
				string text2 = filePath.ToLower().Replace(pathFtp.ToLower(), "");
				text2 = text2.Replace(Configuration.MainDirectoryPath.ToLower(), "/");
				text2 = text2;
				text2 = base.Server.MapPath(text2);
				if (System.IO.File.Exists(text2))
				{
					System.IO.File.Delete(text2);
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					string text3 = "";
					string[] array2 = text.Split(new char[1] { '.' });
					if (array2 != null && array2.Length != 0)
					{
						text3 = text.Replace("." + array2[^1], "");
						text3 = text3 + "-Thumb." + array2[^1];
					}
					if (!string.IsNullOrWhiteSpace(text3))
					{
						string text4 = text2;
						text4 = text4.Replace(text, text3);
						if (System.IO.File.Exists(text4))
						{
							System.IO.File.Delete(text4);
						}
					}
				}
			}
			if (!flag2)
			{
				return;
			}
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtpFo);
			string text5 = filePath.ToLower().Replace(pathFtp.ToLower(), "");
			text5 = text5.Replace(Configuration.MainDirectoryPath.ToLower(), "/");
			text5 = text5;
			text5 = text5.Replace("~", "").ToLower();
			facadeFTP.Delete(pathFtpFo, userNameFtpFo, passwordFtpFo, text, text5, usePassiveFtpFo);
			if (!string.IsNullOrWhiteSpace(text))
			{
				string text6 = "";
				string[] array3 = text.Split(new char[1] { '.' });
				if (array3 != null && array3.Length != 0)
				{
					text6 = text.Replace("." + array3[^1], "");
					text6 = text6 + "-Thumb." + array3[^1];
				}
				if (!string.IsNullOrWhiteSpace(text6))
				{
					string text7 = text5;
					text7 = text7.Replace(text, text6);
					facadeFTP.Delete(pathFtpFo, userNameFtpFo, passwordFtpFo, text6, text7, usePassiveFtpFo);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	public JsonResult GetCompanyGroupsII()
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
			List<CRMspSelectCompanyGroupsII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)list2, (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = item.GroupIIName,
				Value = item.CompanyGroupIIID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpGroupsIIList = list;
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
