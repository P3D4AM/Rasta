using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.General.Utilities;
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
using Microsoft.Win32;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Cms.Controllers;

public class NewsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int newsId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public CrmCmsNewsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__24;

		public Func<Languages, bool> _003C_003E9__66;

		public Func<Languages, bool> _003C_003E9__89;

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__24(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__66(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__87(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__88(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__89(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_1
	{
		public CrmCmsNews model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass13_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__58(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__60(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__61(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__62(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__63(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__64(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__65(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public int commentId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public int commentId;

		public int currLangID;

		internal bool _003CInsertEditComment_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditComment_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditComment_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEditComment_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditComment_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditComment_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEditComment_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditComment_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditComment_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public CrmCmsNewsCommentLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__9;

		public Func<Languages, bool> _003C_003E9__23;

		internal bool _003CInsertEditComment_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditComment_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditComment_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditComment_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditComment_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditComment_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditComment_003Eb__9(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEditComment_003Eb__23(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_1
	{
		public CrmCmsComments model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass25_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEditComment_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditComment_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditComment_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditComment_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditComment_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditComment_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditComment_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditComment_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditComment_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditComment_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditComment_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditComment_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public int fileId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int newsId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly int _ImageWidth = 500;

	private readonly int _ImageHeight = 333;

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsDefineNews")]
	public ActionResult Index()
	{
		GetCmsNewsGroup();
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsDefineNews")]
	public JsonResult GetNews(int newsCurrentId, string fromDate, string toDate, bool isNewsTop = false, int? newsGroupId = 0, int? newsId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
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
		CurrentNewsViewModel currentNewsViewModel = new CurrentNewsViewModel();
		if (!newsId.HasValue)
		{
			newsId = 0;
		}
		currentNewsViewModel.LikeCount = 0L;
		currentNewsViewModel.DislikeCount = 0L;
		currentNewsViewModel.CommentsCount = 0L;
		try
		{
			List<CRMspCmsSelectNews_Result> list = Enumerable.ToList<CRMspCmsSelectNews_Result>((IEnumerable<CRMspCmsSelectNews_Result>)_db.CRMspCmsSelectNews(newsId, newsGroupId, value, value2, isNewsTop, lCID, result));
			if (Enumerable.Any<CRMspCmsSelectNews_Result>((IEnumerable<CRMspCmsSelectNews_Result>)list))
			{
				currentNewsViewModel.IsFind = true;
				currentNewsViewModel.Message = "";
				currentNewsViewModel.FromDate = fromDate;
				currentNewsViewModel.ToDate = toDate;
				currentNewsViewModel.NewsNextId = -1;
				currentNewsViewModel.NewsPreviousId = -1;
				currentNewsViewModel.NewsFirstId = -1;
				currentNewsViewModel.NewsLastId = -1;
				if (list.Count == 1)
				{
					currentNewsViewModel.NewsFirstId = -1;
					currentNewsViewModel.NewsLastId = -1;
				}
				else
				{
					currentNewsViewModel.NewsFirstId = Enumerable.FirstOrDefault<CRMspCmsSelectNews_Result>((IEnumerable<CRMspCmsSelectNews_Result>)list).NewsId;
					currentNewsViewModel.NewsLastId = Enumerable.LastOrDefault<CRMspCmsSelectNews_Result>((IEnumerable<CRMspCmsSelectNews_Result>)list).NewsId;
				}
				CRMspCmsSelectNews_Result cRMspCmsSelectNews_Result = ((newsCurrentId <= 0) ? Enumerable.LastOrDefault<CRMspCmsSelectNews_Result>((IEnumerable<CRMspCmsSelectNews_Result>)list) : list.Find((CRMspCmsSelectNews_Result c) => c.NewsId == newsCurrentId));
				if (cRMspCmsSelectNews_Result != null)
				{
					_ = cRMspCmsSelectNews_Result.RegisterDate;
					cRMspCmsSelectNews_Result.RegisterDatePersian = cRMspCmsSelectNews_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					_ = cRMspCmsSelectNews_Result.FirstRegisterDate;
					cRMspCmsSelectNews_Result.FirstRegisterDatePersian = cRMspCmsSelectNews_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(cRMspCmsSelectNews_Result.AppType))
					{
						cRMspCmsSelectNews_Result.AppType = Configuration.AppType;
					}
					cRMspCmsSelectNews_Result.AppType = Configuration.GetAppType(cRMspCmsSelectNews_Result.AppType);
					cRMspCmsSelectNews_Result.EditUser = cRMspCmsSelectNews_Result.EditUser + "(" + Labels.AppType + ":" + cRMspCmsSelectNews_Result.AppType + ")";
					_ = cRMspCmsSelectNews_Result.PublishDateTime;
					cRMspCmsSelectNews_Result.AppType = cRMspCmsSelectNews_Result.PublishDateTime.ToString("yyyy/MM/dd HH:mm:ss");
					_ = cRMspCmsSelectNews_Result.PublishDateTime;
					currentNewsViewModel.PublishDate = cRMspCmsSelectNews_Result.PublishDateTime.ToString("yyyy/MM/dd - dddd - HH:mm:ss");
					cRMspCmsSelectNews_Result.VerifiedUser = cRMspCmsSelectNews_Result.VerifiedUser + "(" + (cRMspCmsSelectNews_Result.VerifiedDateTime.HasValue ? cRMspCmsSelectNews_Result.VerifiedDateTime.Value.ToString("yyyy/MM/dd") : "") + ")";
					currentNewsViewModel.ExpireDate = (cRMspCmsSelectNews_Result.ExpireDateTime.HasValue ? cRMspCmsSelectNews_Result.ExpireDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					if (cRMspCmsSelectNews_Result.LayoutType.HasValue)
					{
						int result2 = 0;
						int.TryParse(cRMspCmsSelectNews_Result.LayoutType.ToString(), out result2);
						switch (result2)
						{
						case 1:
							currentNewsViewModel.LayoutTypeName = Labels.CmsLayoutTypeFo;
							break;
						case 2:
							currentNewsViewModel.LayoutTypeName = Labels.CmsLayoutTypeShop;
							break;
						}
					}
					currentNewsViewModel.NewsPicture = "/Images/non-Image-100.jpg";
					CRMspCmsSelectNewsPicture_Result cRMspCmsSelectNewsPicture_Result = Enumerable.FirstOrDefault<CRMspCmsSelectNewsPicture_Result>((IEnumerable<CRMspCmsSelectNewsPicture_Result>)_dbI.CRMspCmsSelectNewsPicture(0, -110, cRMspCmsSelectNews_Result.NewsId, lCID, result));
					if (cRMspCmsSelectNewsPicture_Result != null)
					{
						_ = cRMspCmsSelectNewsPicture_Result.FileDirectoryID;
						if (!string.IsNullOrEmpty(cRMspCmsSelectNewsPicture_Result.FilePath))
						{
							cRMspCmsSelectNewsPicture_Result.FilePath = cRMspCmsSelectNewsPicture_Result.FilePath.Replace(Configuration.MainDirectoryPath, "/");
							string path = base.Server.MapPath(cRMspCmsSelectNewsPicture_Result.FilePath);
							if (!System.IO.File.Exists(path))
							{
								if (cRMspCmsSelectNewsPicture_Result.FileDirectoryID > 0)
								{
									int result3 = 0;
									int.TryParse(cRMspCmsSelectNewsPicture_Result.FileDirectoryID.ToString(), out result3);
									DownlaodNewsPic(result3);
									if (!System.IO.File.Exists(path))
									{
										cRMspCmsSelectNewsPicture_Result.FilePath = "/Images/non-Image-100.jpg";
									}
								}
								else
								{
									cRMspCmsSelectNewsPicture_Result.FilePath = "/Images/non-Image-100.jpg";
								}
							}
							currentNewsViewModel.NewsPicture = cRMspCmsSelectNewsPicture_Result.FilePath;
						}
					}
					currentNewsViewModel.News = cRMspCmsSelectNews_Result;
					currentNewsViewModel.NewsCurrentId = cRMspCmsSelectNews_Result.NewsId;
					if (list.Count == 1)
					{
						currentNewsViewModel.NewsNextId = -1;
						currentNewsViewModel.NewsPreviousId = -1;
					}
					else
					{
						CRMspCmsSelectNews_Result next = Lists.GetNext(list, cRMspCmsSelectNews_Result);
						if (next != null)
						{
							currentNewsViewModel.NewsNextId = next.NewsId;
						}
						CRMspCmsSelectNews_Result previous = Lists.GetPrevious(list, cRMspCmsSelectNews_Result);
						if (previous != null)
						{
							currentNewsViewModel.NewsPreviousId = previous.NewsId;
						}
					}
					CRMspCmsReturnLikesAndCommentsCount_Result cRMspCmsReturnLikesAndCommentsCount_Result = Enumerable.FirstOrDefault<CRMspCmsReturnLikesAndCommentsCount_Result>((IEnumerable<CRMspCmsReturnLikesAndCommentsCount_Result>)_db.CRMspCmsReturnLikesAndCommentsCount(1, cRMspCmsSelectNews_Result.NewsId));
					if (cRMspCmsReturnLikesAndCommentsCount_Result != null)
					{
						long result4 = 0L;
						long.TryParse(cRMspCmsReturnLikesAndCommentsCount_Result.LikeCount.ToString(), out result4);
						currentNewsViewModel.LikeCount = result4;
						long result5 = 0L;
						long.TryParse(cRMspCmsReturnLikesAndCommentsCount_Result.DislikeCount.ToString(), out result5);
						currentNewsViewModel.DislikeCount = result5;
						long result6 = 0L;
						long.TryParse(cRMspCmsReturnLikesAndCommentsCount_Result.CommentsCount.ToString(), out result6);
						currentNewsViewModel.CommentsCount = result6;
					}
				}
				else
				{
					currentNewsViewModel.IsFind = false;
					currentNewsViewModel.Message = Messages.ErrorNotFound;
					currentNewsViewModel.FromDate = fromDate;
					currentNewsViewModel.ToDate = toDate;
					currentNewsViewModel.News = null;
					currentNewsViewModel.NewsCurrentId = -1;
					currentNewsViewModel.NewsNextId = -1;
					currentNewsViewModel.NewsPreviousId = -1;
					currentNewsViewModel.NewsFirstId = -1;
					currentNewsViewModel.NewsLastId = -1;
				}
			}
			else
			{
				currentNewsViewModel.IsFind = false;
				currentNewsViewModel.Message = Messages.ErrorNotFound;
				currentNewsViewModel.FromDate = fromDate;
				currentNewsViewModel.ToDate = toDate;
				currentNewsViewModel.News = null;
				currentNewsViewModel.NewsCurrentId = -1;
				currentNewsViewModel.NewsNextId = -1;
				currentNewsViewModel.NewsPreviousId = -1;
				currentNewsViewModel.NewsFirstId = -1;
				currentNewsViewModel.NewsLastId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentNewsViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentNewsViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentNewsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCmsNewsGroup()
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
			List<CRMspCmsSelectNewsGroupsActive_Result> list2 = Enumerable.ToList<CRMspCmsSelectNewsGroupsActive_Result>((IEnumerable<CRMspCmsSelectNewsGroupsActive_Result>)_db.CRMspCmsSelectNewsGroupsActive(lCID, result));
			list.AddRange(Enumerable.Select<CRMspCmsSelectNewsGroupsActive_Result, SelectListItem>((IEnumerable<CRMspCmsSelectNewsGroupsActive_Result>)Enumerable.ToList<CRMspCmsSelectNewsGroupsActive_Result>((IEnumerable<CRMspCmsSelectNewsGroupsActive_Result>)list2), (Func<CRMspCmsSelectNewsGroupsActive_Result, SelectListItem>)((CRMspCmsSelectNewsGroupsActive_Result i) => new SelectListItem
			{
				Text = i.GroupName,
				Value = i.NewsGroupId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.NewsGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetLayoutType()
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
			SelectListItem item = new SelectListItem
			{
				Text = Labels.CmsLayoutTypeFo,
				Value = "1",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsLayoutTypeShop,
				Value = "2",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LayoutTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsDefineNews", ActionName = "actDelete")]
	public string DeleteNews(int newsId)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_.newsId = newsId;
		string result = "";
		try
		{
			DbSet<CrmCmsNews> crmCmsNews = _dbTbl.CrmCmsNews;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsNews), "c");
			if (Queryable.FirstOrDefault<CrmCmsNews>((IQueryable<CrmCmsNews>)crmCmsNews, Expression.Lambda<Func<CrmCmsNews, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteNews(_003C_003Ec__DisplayClass9_.newsId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsNews");
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	public ActionResult _PartialList(int newsCurrentId, string fromDate, string toDate, bool isNewsTop = false, int? newsGroupId = 0, int? newsId = 0)
	{
		NewsListViewModel newsListViewModel = new NewsListViewModel
		{
			newsCurrentId = newsCurrentId,
			fromDate = fromDate,
			toDate = toDate,
			isNewsTop = isNewsTop,
			newsGroupId = newsGroupId,
			newsId = newsId
		};
		base.ViewBag.NewsList = newsListViewModel;
		return PartialView();
	}

	public ActionResult _PartialList_Read([DataSourceRequest] DataSourceRequest request, int newsCurrentId, string fromDate, string toDate, bool isNewsTop = false, int? newsGroupId = 0, int? newsId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
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
		if (!newsId.HasValue)
		{
			newsId = 0;
		}
		List<CRMspCmsSelectNews_Result> list = Enumerable.ToList<CRMspCmsSelectNews_Result>((IEnumerable<CRMspCmsSelectNews_Result>)_db.CRMspCmsSelectNews(newsId, newsGroupId, value, value2, isNewsTop, lCID, result));
		foreach (CRMspCmsSelectNews_Result item in list)
		{
			_ = item.RegisterDate;
			item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			_ = item.FirstRegisterDate;
			item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(item.AppType))
			{
				item.AppType = Configuration.AppType;
			}
			item.AppType = Configuration.GetAppType(item.AppType);
			item.EditUser = item.EditUser + "(" + Labels.AppType + ":" + item.AppType + ")";
			_ = item.PublishDateTime;
			item.AppType = item.PublishDateTime.ToString("yyyy/MM/dd HH:mm:ss");
			item.VerifiedUser = item.VerifiedUser + "(" + (item.VerifiedDateTime.HasValue ? item.VerifiedDateTime.Value.ToString("yyyy/MM/dd") : "") + ")";
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmCmsDefineNews", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int newsId = 0, int newsGroupId = 0)
	{
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
		CS_0024_003C_003E8__locals0.newsId = newsId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmCmsNewsLanguageViewModel crmCmsNewsLanguageViewModel = new CrmCmsNewsLanguageViewModel();
		string text = "/Images/non-Image-100.jpg";
		int num = 0;
		if (CS_0024_003C_003E8__locals0.newsId > 0)
		{
			if (!UserLogin.IsUserAccess("frmCmsDefineNews", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			new BaseInfo();
			DbSet<CrmCmsNews_Lang> crmCmsNews_Lang = _dbTbl.CrmCmsNews_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsNews_Lang), "c");
			List<CrmCmsNews_Lang> list = Enumerable.ToList<CrmCmsNews_Lang>((IEnumerable<CrmCmsNews_Lang>)Queryable.Where<CrmCmsNews_Lang>((IQueryable<CrmCmsNews_Lang>)crmCmsNews_Lang, Expression.Lambda<Func<CrmCmsNews_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass12_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<CrmCmsNews> crmCmsNews = _dbTbl.CrmCmsNews;
			val = Expression.Parameter(typeof(CrmCmsNews), "c");
			CrmCmsNews crmCmsNews2 = Queryable.FirstOrDefault<CrmCmsNews>((IQueryable<CrmCmsNews>)crmCmsNews, Expression.Lambda<Func<CrmCmsNews, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass12_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCmsNews2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsNews_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsNews_Lang>)list, (Func<CrmCmsNews_Lang, CommonMultiLanguageViewModel>)((CrmCmsNews_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.HeadLine,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsNews2.HeadLine,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsNews_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsNews_Lang>)list, (Func<CrmCmsNews_Lang, CommonMultiLanguageViewModel>)((CrmCmsNews_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Title,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsNews2.Title,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsNews_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsNews_Lang>)list, (Func<CrmCmsNews_Lang, CommonMultiLanguageViewModel>)((CrmCmsNews_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.NewsSummery,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsNews2.NewsSummery,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsNews_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsNews_Lang>)list, (Func<CrmCmsNews_Lang, CommonMultiLanguageViewModel>)((CrmCmsNews_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.NewsBody,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsNews2.NewsBody,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsNews_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsNews_Lang>)list, (Func<CrmCmsNews_Lang, CommonMultiLanguageViewModel>)((CrmCmsNews_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.NewsSeoTitle,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsNews2.NewsSeoTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsNews_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsNews_Lang>)list, (Func<CrmCmsNews_Lang, CommonMultiLanguageViewModel>)((CrmCmsNews_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.NewsSeoDescription,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsNews2.NewsSeoDescription,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsNews_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsNews_Lang>)list, (Func<CrmCmsNews_Lang, CommonMultiLanguageViewModel>)((CrmCmsNews_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.NewsSeoKeywords,
				LanguageId = item.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsNews2.NewsSeoKeywords,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsNews_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsNews_Lang>)list, (Func<CrmCmsNews_Lang, CommonMultiLanguageViewModel>)((CrmCmsNews_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.NewsSeoFaq,
				LanguageId = item.LanguageID
			})));
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsNews2.NewsSeoFaq,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsNews_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsNews_Lang>)list, (Func<CrmCmsNews_Lang, CommonMultiLanguageViewModel>)((CrmCmsNews_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.NewsSeoAuthor,
				LanguageId = item.LanguageID
			})));
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsNews2.NewsSeoAuthor,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsNews_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsNews_Lang>)list, (Func<CrmCmsNews_Lang, CommonMultiLanguageViewModel>)((CrmCmsNews_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.NewsSeoCopyright,
				LanguageId = item.LanguageID
			})));
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsNews2.NewsSeoCopyright,
				LanguageId = result
			});
			CrmCmsNewsLanguageViewModel obj = new CrmCmsNewsLanguageViewModel
			{
				NewsId = crmCmsNews2.NewsId,
				NewsGroupId = crmCmsNews2.NewsGroupId,
				HeadLine = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				HeadLine_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				Title_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				NewsSummery = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				NewsSummery_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				PublishDateTime = crmCmsNews2.PublishDateTime
			};
			_ = crmCmsNews2.PublishDateTime;
			obj.PublishDate = crmCmsNews2.PublishDateTime.ToString("yyyy/MM/dd");
			_ = crmCmsNews2.PublishDateTime;
			obj.PublishTime = crmCmsNews2.PublishDateTime.ToString("HH:mm:ss");
			obj.NewsBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.NewsBody_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.IsVerified = crmCmsNews2.IsVerified;
			obj.VerifiedUserId = crmCmsNews2.VerifiedUserId;
			obj.VerifiedDateTime = crmCmsNews2.VerifiedDateTime;
			obj.CommentActive = crmCmsNews2.CommentActive;
			obj.LikeActive = crmCmsNews2.LikeActive;
			obj.OrderView = crmCmsNews2.OrderView;
			obj.IsTopNews = crmCmsNews2.IsTopNews;
			obj.FirstRegisterUserId = crmCmsNews2.FirstRegisterUserId;
			obj.FirstRegisterDate = crmCmsNews2.FirstRegisterDate;
			obj.FirstRegisterDatePersian = crmCmsNews2.FirstRegisterDatePersian;
			obj.UserId = crmCmsNews2.UserId;
			obj.Year1 = crmCmsNews2.Year1;
			obj.Month1 = crmCmsNews2.Month1;
			obj.RegisterDate = crmCmsNews2.RegisterDate;
			obj.RegisterDatePersian = crmCmsNews2.RegisterDatePersian;
			obj.GUId = crmCmsNews2.GUId;
			obj.AppType = crmCmsNews2.AppType;
			obj.LanguageID = crmCmsNews2.LanguageID;
			obj.ExpireDateTime = crmCmsNews2.ExpireDateTime;
			obj.ExpireDate = (crmCmsNews2.ExpireDateTime.HasValue ? crmCmsNews2.ExpireDateTime.Value.ToString("yyyy/MM/dd") : null);
			obj.ExpireTime = (crmCmsNews2.ExpireDateTime.HasValue ? crmCmsNews2.ExpireDateTime.Value.ToString("HH:mm:ss") : null);
			obj.NewsSystemPartIds = crmCmsNews2.NewsSystemPartIds;
			obj.LayoutType = crmCmsNews2.LayoutType;
			obj.NewsSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.NewsSeoTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.NewsSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.NewsSeoDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.NewsSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.NewsSeoKeywords_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.NewsSeoFaq = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.NewsSeoFaq_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.NewsSeoIsActive = crmCmsNews2.NewsSeoIsActive;
			obj.NewsSeoHttpEquiv = crmCmsNews2.NewsSeoHttpEquiv;
			obj.NewsSeoExpires = crmCmsNews2.NewsSeoExpires;
			obj.NewsSeoGoogleNotranslate = crmCmsNews2.NewsSeoGoogleNotranslate;
			obj.NewsSeoDistribution = crmCmsNews2.NewsSeoDistribution;
			obj.NewsSeoRobots = crmCmsNews2.NewsSeoRobots;
			obj.NewsSeoRating = crmCmsNews2.NewsSeoRating;
			obj.NewsSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.NewsSeoIsUseSocialNetwork = crmCmsNews2.NewsSeoIsUseSocialNetwork;
			obj.NewsSeoMobileOptimized = crmCmsNews2.NewsSeoMobileOptimized;
			obj.NewsSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.NewsSeoUseDefault = crmCmsNews2.NewsSeoUseDefault;
			obj.NewsSeoAuthor_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.NewsSeoCopyright_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			crmCmsNewsLanguageViewModel = obj;
			CRMspCmsSelectNewsPicture_Result cRMspCmsSelectNewsPicture_Result = Enumerable.FirstOrDefault<CRMspCmsSelectNewsPicture_Result>((IEnumerable<CRMspCmsSelectNewsPicture_Result>)_dbI.CRMspCmsSelectNewsPicture(0, -110, crmCmsNewsLanguageViewModel.NewsId, CS_0024_003C_003E8__locals0.currLangID, result));
			if (cRMspCmsSelectNewsPicture_Result != null)
			{
				num = cRMspCmsSelectNewsPicture_Result.FileDirectoryID;
				if (!string.IsNullOrEmpty(cRMspCmsSelectNewsPicture_Result.FilePath))
				{
					cRMspCmsSelectNewsPicture_Result.FilePath = cRMspCmsSelectNewsPicture_Result.FilePath.Replace(Configuration.MainDirectoryPath, "/");
					if (cRMspCmsSelectNewsPicture_Result.FilePath.IndexOf(".") > 0)
					{
						cRMspCmsSelectNewsPicture_Result.FilePath = cRMspCmsSelectNewsPicture_Result.FilePath.Insert(cRMspCmsSelectNewsPicture_Result.FilePath.IndexOf("."), "-Thumb");
					}
					string path = base.Server.MapPath(cRMspCmsSelectNewsPicture_Result.FilePath);
					if (!System.IO.File.Exists(path))
					{
						if (cRMspCmsSelectNewsPicture_Result.FileDirectoryID > 0)
						{
							int result2 = 0;
							int.TryParse(cRMspCmsSelectNewsPicture_Result.FileDirectoryID.ToString(), out result2);
							DownlaodNewsPic(result2);
							if (!System.IO.File.Exists(path))
							{
								cRMspCmsSelectNewsPicture_Result.FilePath = "/Images/non-Image-100.jpg";
							}
						}
						else
						{
							cRMspCmsSelectNewsPicture_Result.FilePath = "/Images/non-Image-100.jpg";
						}
					}
					text = cRMspCmsSelectNewsPicture_Result.FilePath;
				}
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmCmsDefineNews", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			crmCmsNewsLanguageViewModel = new CrmCmsNewsLanguageViewModel
			{
				NewsGroupId = newsGroupId,
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDate = now,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				Year1 = short.Parse(Financial.Get().Id.ToString()),
				Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
				AppType = "Insert",
				LanguageID = result,
				PublishDateTime = now,
				PublishDate = now.ToString("yyyy/MM/dd"),
				PublishTime = now.ToString("HH:mm:ss")
			};
			List<CRMspCmsSelectNewsOrderView_Result> list12 = Enumerable.ToList<CRMspCmsSelectNewsOrderView_Result>((IEnumerable<CRMspCmsSelectNewsOrderView_Result>)_dbI.CRMspCmsSelectNewsOrderView());
			if (!Enumerable.Any<CRMspCmsSelectNewsOrderView_Result>((IEnumerable<CRMspCmsSelectNewsOrderView_Result>)list12))
			{
				crmCmsNewsLanguageViewModel.OrderView = 10;
			}
			else
			{
				int result3 = 10;
				CRMspCmsSelectNewsOrderView_Result cRMspCmsSelectNewsOrderView_Result = Enumerable.LastOrDefault<CRMspCmsSelectNewsOrderView_Result>((IEnumerable<CRMspCmsSelectNewsOrderView_Result>)list12);
				if (cRMspCmsSelectNewsOrderView_Result != null)
				{
					int.TryParse(cRMspCmsSelectNewsOrderView_Result.OrderView.ToString(), out result3);
					result3 = ((result3 == 0) ? 10 : (result3 + 10));
				}
				crmCmsNewsLanguageViewModel.OrderView = result3;
			}
			base.ViewBag.IsBuying = VersionBuyer.FoCmsNews;
		}
		GetCmsNewsGroup();
		GetLayoutType();
		GetLanguagesList();
		base.ViewBag.FileId = num;
		base.ViewBag.NewsPic = text;
		return View(crmCmsNewsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCmsDefineNewsDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmCmsNewsLanguageViewModel vm)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "/Images/non-Image-100.jpg";
		int num = 0;
		int? num2 = null;
		if (UserLogin.CurrentUser != null)
		{
			num2 = UserLogin.CurrentUser.UserLastCId;
		}
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.HeadLine_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.HeadLine_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.HeadLine,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Title_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Title_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Title,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.NewsSummery_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.NewsSummery_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.NewsSummery,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.NewsBody_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.NewsBody_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.NewsBody,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
		{
			string resourceString = MyResource.GetResourceString("CmsNewsPic", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = resourceString,
				LanguageId = item.LanguageID
			});
		}
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.NewsSeoTitle_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.NewsSeoTitle_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.NewsSeoTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.NewsSeoDescription_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.NewsSeoDescription_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.NewsSeoDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.NewsSeoKeywords_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.NewsSeoKeywords_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.NewsSeoKeywords,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.NewsSeoFaq_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.NewsSeoFaq_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.NewsSeoFaq,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.NewsSeoAuthor_Lang))
		{
			list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.NewsSeoAuthor_Lang);
		}
		list10.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.NewsSeoAuthor,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.NewsSeoCopyright_Lang))
		{
			list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.NewsSeoCopyright_Lang);
		}
		list11.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.NewsSeoCopyright,
			LanguageId = lCID
		});
		GetCmsNewsGroup();
		GetLayoutType();
		GetLanguagesList();
		try
		{
			if (CS_0024_003C_003E8__locals0.vm.NewsId <= 0 && !VersionBuyer.FoCmsNews)
			{
				DbSet<CrmCmsNews> crmCmsNews = _dbTbl.CrmCmsNews;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsNews), "c");
				if (Queryable.Any<CrmCmsNews>((IQueryable<CrmCmsNews>)crmCmsNews, Expression.Lambda<Func<CrmCmsNews, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)1, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + string.Format(Messages.VersionBuyWithCount, "1");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			string text2 = "";
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass13_1 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_1();
				_ = CRMIdeal.Cache.Setting.Language.Get().Count;
				string text3 = "";
				int num3 = 0;
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.HeadLine))
				{
					text3 = text3 + string.Format(Messages.ErrorEmpty, Labels.CmsNewsHeadLine) + "<br/>";
					num3++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.HeadLine, list))
				{
					text3 = text3 + string.Format(Messages.CheckFieldInLang, Labels.CmsNewsHeadLine) + "<br>";
					num3++;
				}
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Title))
				{
					text3 = text3 + string.Format(Messages.ErrorEmpty, Labels.CmsNewsTitleI) + "<br/>";
					num3++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.Title, list2))
				{
					text3 = text3 + string.Format(Messages.CheckFieldInLang, Labels.CmsNewsTitleI) + "<br>";
					num3++;
				}
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.NewsSummery))
				{
					text3 = text3 + string.Format(Messages.ErrorEmpty, Labels.CmsNewsSummery) + "<br/>";
					num3++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.NewsSummery, list3))
				{
					text3 = text3 + string.Format(Messages.CheckFieldInLang, Labels.CmsNewsSummery) + "<br>";
					num3++;
				}
				if (num3 > 0)
				{
					base.ViewBag.Error = text3;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				DateTime dateTime = default(DateTime);
				string text4 = "";
				try
				{
					string text5 = "00:00:00";
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PublishTime))
					{
						text5 = CS_0024_003C_003E8__locals0.vm.PublishTime;
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PublishDate))
					{
						text4 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.PublishDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", ""));
						dateTime = lCID switch
						{
							1065 => DateTime.Parse(text4 + " " + text5, new PersianCulture()), 
							1025 => DateTime.Parse(text4 + " " + text5, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text4 + " " + text5, new CultureInfo("en-US")), 
						};
						CS_0024_003C_003E8__locals0.vm.PublishDateTime = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = Messages.WrongDateTime;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				dateTime = default(DateTime);
				text4 = "";
				try
				{
					string text6 = "00:00:00";
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ExpireTime))
					{
						text6 = CS_0024_003C_003E8__locals0.vm.ExpireTime;
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ExpireDate))
					{
						text4 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ExpireDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", ""));
						dateTime = lCID switch
						{
							1065 => DateTime.Parse(text4 + " " + text6, new PersianCulture()), 
							1025 => DateTime.Parse(text4 + " " + text6, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text4 + " " + text6, new CultureInfo("en-US")), 
						};
						CS_0024_003C_003E8__locals0.vm.ExpireDateTime = dateTime;
					}
					else
					{
						CS_0024_003C_003E8__locals0.vm.ExpireDateTime = null;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					base.ViewBag.Error = Messages.WrongDateTime;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				_003C_003Ec__DisplayClass13_.model = new CrmCmsNews();
				if (CS_0024_003C_003E8__locals0.vm.NewsId > 0)
				{
					DbSet<CrmCmsNews> crmCmsNews2 = _dbTbl.CrmCmsNews;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsNews), "c");
					_003C_003Ec__DisplayClass13_.model = Queryable.FirstOrDefault<CrmCmsNews>((IQueryable<CrmCmsNews>)crmCmsNews2, Expression.Lambda<Func<CrmCmsNews, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass13_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass13_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass13_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass13_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass13_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass13_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass13_.model.NewsGroupId = CS_0024_003C_003E8__locals0.vm.NewsGroupId;
				_003C_003Ec__DisplayClass13_.model.HeadLine = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass13_.model.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass13_.model.NewsSummery = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass13_.model.PublishDateTime = CS_0024_003C_003E8__locals0.vm.PublishDateTime;
				_003C_003Ec__DisplayClass13_.model.NewsBody = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass13_.model.CommentActive = CS_0024_003C_003E8__locals0.vm.CommentActive;
				_003C_003Ec__DisplayClass13_.model.LikeActive = CS_0024_003C_003E8__locals0.vm.LikeActive;
				_003C_003Ec__DisplayClass13_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				_003C_003Ec__DisplayClass13_.model.IsTopNews = CS_0024_003C_003E8__locals0.vm.IsTopNews;
				_003C_003Ec__DisplayClass13_.model.ExpireDateTime = CS_0024_003C_003E8__locals0.vm.ExpireDateTime;
				_003C_003Ec__DisplayClass13_.model.NewsSystemPartIds = CS_0024_003C_003E8__locals0.vm.NewsSystemPartIds;
				_003C_003Ec__DisplayClass13_.model.LayoutType = CS_0024_003C_003E8__locals0.vm.LayoutType;
				_003C_003Ec__DisplayClass13_.model.NewsSeoTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass13_.model.NewsSeoDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass13_.model.NewsSeoKeywords = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass13_.model.NewsSeoFaq = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass13_.model.NewsSeoIsActive = CS_0024_003C_003E8__locals0.vm.NewsSeoIsActive;
				_003C_003Ec__DisplayClass13_.model.NewsSeoHttpEquiv = CS_0024_003C_003E8__locals0.vm.NewsSeoHttpEquiv;
				_003C_003Ec__DisplayClass13_.model.NewsSeoExpires = CS_0024_003C_003E8__locals0.vm.NewsSeoExpires;
				_003C_003Ec__DisplayClass13_.model.NewsSeoGoogleNotranslate = CS_0024_003C_003E8__locals0.vm.NewsSeoGoogleNotranslate;
				_003C_003Ec__DisplayClass13_.model.NewsSeoDistribution = CS_0024_003C_003E8__locals0.vm.NewsSeoDistribution;
				_003C_003Ec__DisplayClass13_.model.NewsSeoRobots = CS_0024_003C_003E8__locals0.vm.NewsSeoRobots;
				_003C_003Ec__DisplayClass13_.model.NewsSeoRating = CS_0024_003C_003E8__locals0.vm.NewsSeoRating;
				_003C_003Ec__DisplayClass13_.model.NewsSeoAuthor = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass13_.model.NewsSeoIsUseSocialNetwork = CS_0024_003C_003E8__locals0.vm.NewsSeoIsUseSocialNetwork;
				_003C_003Ec__DisplayClass13_.model.NewsSeoMobileOptimized = CS_0024_003C_003E8__locals0.vm.NewsSeoMobileOptimized;
				_003C_003Ec__DisplayClass13_.model.NewsSeoCopyright = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass13_.model.NewsSeoUseDefault = CS_0024_003C_003E8__locals0.vm.NewsSeoUseDefault;
				if (_003C_003Ec__DisplayClass13_.model.NewsId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass13_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass13_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass13_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass13_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmCmsNews_Lang> crmCmsNews_Lang = _dbTbl.CrmCmsNews_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCmsNews_Lang), "c");
							CrmCmsNews_Lang crmCmsNews_Lang2 = Queryable.FirstOrDefault<CrmCmsNews_Lang>((IQueryable<CrmCmsNews_Lang>)crmCmsNews_Lang, Expression.Lambda<Func<CrmCmsNews_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass13_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass13_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCmsNews_Lang2 != null)
							{
								crmCmsNews_Lang2.HeadLine = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsNews_Lang2.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsNews_Lang2.NewsSummery = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsNews_Lang2.NewsBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsNews_Lang2.NewsSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsNews_Lang2.NewsSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsNews_Lang2.NewsSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsNews_Lang2.NewsSeoFaq = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsNews_Lang2.NewsSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsNews_Lang2.NewsSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCmsNews_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCmsNews_Lang2 = new CrmCmsNews_Lang();
							crmCmsNews_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmCmsNews_Lang2.NewsId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.NewsId;
							crmCmsNews_Lang2.HeadLine = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsNews_Lang2.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsNews_Lang2.NewsSummery = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsNews_Lang2.NewsBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsNews_Lang2.NewsSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsNews_Lang2.NewsSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsNews_Lang2.NewsSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsNews_Lang2.NewsSeoFaq = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsNews_Lang2.NewsSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsNews_Lang2.NewsSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmCmsNews_Lang.Add(crmCmsNews_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					text2 = Messages.frmFormBaseEditSuccessFulMessage;
					CRMspCmsSelectNewsPicture_Result cRMspCmsSelectNewsPicture_Result = Enumerable.FirstOrDefault<CRMspCmsSelectNewsPicture_Result>((IEnumerable<CRMspCmsSelectNewsPicture_Result>)_dbI.CRMspCmsSelectNewsPicture(0, -110, CS_0024_003C_003E8__locals0.vm.NewsId, lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (cRMspCmsSelectNewsPicture_Result != null)
					{
						num = cRMspCmsSelectNewsPicture_Result.FileDirectoryID;
						if (!string.IsNullOrEmpty(cRMspCmsSelectNewsPicture_Result.FilePath))
						{
							cRMspCmsSelectNewsPicture_Result.FilePath = cRMspCmsSelectNewsPicture_Result.FilePath.Replace(Configuration.MainDirectoryPath, "/");
							if (cRMspCmsSelectNewsPicture_Result.FilePath.IndexOf(".") > 0)
							{
								cRMspCmsSelectNewsPicture_Result.FilePath = cRMspCmsSelectNewsPicture_Result.FilePath.Insert(cRMspCmsSelectNewsPicture_Result.FilePath.IndexOf("."), "-Thumb");
							}
							string path = base.Server.MapPath(cRMspCmsSelectNewsPicture_Result.FilePath);
							if (!System.IO.File.Exists(path))
							{
								if (cRMspCmsSelectNewsPicture_Result.FileDirectoryID > 0)
								{
									int result = 0;
									int.TryParse(cRMspCmsSelectNewsPicture_Result.FileDirectoryID.ToString(), out result);
									DownlaodNewsPic(result);
									if (!System.IO.File.Exists(path))
									{
										cRMspCmsSelectNewsPicture_Result.FilePath = "/Images/non-Image-100.jpg";
									}
								}
								else
								{
									cRMspCmsSelectNewsPicture_Result.FilePath = "/Images/non-Image-100.jpg";
								}
							}
							text = cRMspCmsSelectNewsPicture_Result.FilePath;
						}
					}
				}
				else
				{
					if (!CS_0024_003C_003E8__locals0.vm.OrderView.HasValue)
					{
						List<CRMspCmsSelectNewsOrderView_Result> list12 = Enumerable.ToList<CRMspCmsSelectNewsOrderView_Result>((IEnumerable<CRMspCmsSelectNewsOrderView_Result>)_dbI.CRMspCmsSelectNewsOrderView());
						int num4 = (Enumerable.Any<CRMspCmsSelectNewsOrderView_Result>((IEnumerable<CRMspCmsSelectNewsOrderView_Result>)list12) ? Enumerable.Count<CRMspCmsSelectNewsOrderView_Result>((IEnumerable<CRMspCmsSelectNewsOrderView_Result>)list12) : 0);
						_003C_003Ec__DisplayClass13_.model.OrderView = num4 * 10 + 10;
						if (Enumerable.LastOrDefault<CRMspCmsSelectNewsOrderView_Result>((IEnumerable<CRMspCmsSelectNewsOrderView_Result>)list12) != null)
						{
							int valueOrDefault = Enumerable.LastOrDefault<CRMspCmsSelectNewsOrderView_Result>((IEnumerable<CRMspCmsSelectNewsOrderView_Result>)list12).OrderView.GetValueOrDefault();
							if (valueOrDefault > 0)
							{
								_003C_003Ec__DisplayClass13_.model.OrderView = valueOrDefault + 10;
							}
						}
					}
					else
					{
						_003C_003Ec__DisplayClass13_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
					}
					_003C_003Ec__DisplayClass13_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass13_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass13_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass13_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass13_.model.GUId = System.Guid.NewGuid();
					_dbTbl.CrmCmsNews.Add(_003C_003Ec__DisplayClass13_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang2 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmCmsNews_Lang crmCmsNews_Lang3 = new CrmCmsNews_Lang();
						crmCmsNews_Lang3.LanguageID = lang2.LanguageID;
						crmCmsNews_Lang3.NewsId = _003C_003Ec__DisplayClass13_.model.NewsId;
						crmCmsNews_Lang3.HeadLine = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
						crmCmsNews_Lang3.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
						crmCmsNews_Lang3.NewsSummery = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
						crmCmsNews_Lang3.NewsBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
						crmCmsNews_Lang3.NewsSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
						crmCmsNews_Lang3.NewsSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
						crmCmsNews_Lang3.NewsSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
						crmCmsNews_Lang3.NewsSeoFaq = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
						crmCmsNews_Lang3.NewsSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
						crmCmsNews_Lang3.NewsSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
						_dbTbl.CrmCmsNews_Lang.Add(crmCmsNews_Lang3);
						_dbTbl.SaveChanges();
					}
					text2 = Messages.frmFormBaseInsertSuccessFulMessage;
					CS_0024_003C_003E8__locals0.vm.AppType = "Insert";
				}
				CS_0024_003C_003E8__locals0.vm.NewsId = _003C_003Ec__DisplayClass13_.model.NewsId;
				string text7 = "";
				if (_003C_003Ec__DisplayClass13_.model.NewsId > 0 && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.PicPath) && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.PicTitle))
				{
					int? fileCId = null;
					if (num2.GetValueOrDefault() != 0)
					{
						fileCId = num2;
					}
					string text8 = base.Server.MapPath(CS_0024_003C_003E8__locals0.vm.PicPath);
					string arg = CS_0024_003C_003E8__locals0.vm.PicTitle ?? "";
					if (System.IO.File.Exists(text8))
					{
						bool flag = false;
						string value = "";
						string text9 = ((!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.PicTitle)) ? Path.GetExtension(CS_0024_003C_003E8__locals0.vm.PicTitle).ToLower() : "");
						RegistryKey val2 = Registry.ClassesRoot.OpenSubKey(text9);
						if (val2 != null && val2.GetValue("Content Type") != null)
						{
							value = val2.GetValue("Content Type").ToString();
						}
						if (string.IsNullOrWhiteSpace(value))
						{
							value = Files.GetMimeType(text9);
						}
						string text10 = ".gif,.jpeg,.png,.x-png,.jpg,.pjpeg";
						if (text10 != "*" && !string.IsNullOrEmpty(text10) && text10.IndexOf(text9, StringComparison.Ordinal) < 0)
						{
							text2 = text2 + "<br>" + Messages.msgErrorNotSavePic + "<br>" + string.Format(Messages.msgErrorMessageFileExtension, text10);
							flag = true;
						}
						string text11 = (text9 ?? "").ToLower();
						text11 = text11.Replace(".", "");
						if (Configuration.MaliciousFileExtensions.Contains(text11))
						{
							flag = true;
							text2 = text2 + "<br>" + Messages.msgErrorNotSavePic + "<br>" + string.Format(Messages.msgErrorNotUploadFileByDue, arg) + Messages.msgErrorFileIsExecuted + "<br>";
						}
						int num5 = 204800;
						long length = new FileInfo(text8).Length;
						if (length > num5)
						{
							string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(length);
							string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num5);
							string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
							base.ModelState.AddModelError("error", string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2));
							flag = true;
							text2 = text2 + "<br>" + Messages.msgErrorNotSavePic + "<br>" + string.Format(Messages.msgErrorNotUploadFileByDue, arg) + string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2) + "<br>";
						}
						if (!flag)
						{
							_ = _003C_003Ec__DisplayClass13_.model.NewsGroupId;
							int userId = UserLogin.CurrentUser.UserId;
							string text12 = now.ToString("yyyyMMdd", new PersianCulture());
							short month = short.Parse(now.ToString("MM", new PersianCulture()));
							string appType = Configuration.AppType;
							short year = short.Parse(Financial.Get().Id.ToString());
							string? fileName = Path.GetFileName(CS_0024_003C_003E8__locals0.vm.PicTitle);
							FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
							string text13 = "";
							text13 = Configuration.CmsNewsDirectoryPath + _003C_003Ec__DisplayClass13_.model.NewsId;
							_003C_003Ec__DisplayClass13_.model.NewsId.ToString();
							CrmFilesDirectory crmFilesDirectory = new CrmFilesDirectory
							{
								FirstRegisterUserId = userId,
								FirstRegisterDate = now,
								FirstRegisterDatePersian = text12,
								LanguageID = CS_0024_003C_003E8__locals0.defLangID,
								UserId = userId,
								Year1 = year,
								Month1 = month,
								GUId = System.Guid.NewGuid(),
								RegisterDate = now,
								RegisterDatePersian = text12,
								DocDateTime = now,
								DocDate = text12,
								DocTime = now.ToString("HH:mm:ss"),
								DocDay = PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(),
								AppType = appType,
								DetailId = null,
								FileDirectoryTypeId = -110,
								TypeOprObjectId = _003C_003Ec__DisplayClass13_.model.NewsId,
								FolderName = _003C_003Ec__DisplayClass13_.model.NewsId.ToString(),
								SubDetailId = null,
								MasterId = null,
								Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null),
								FileFOCmpCanSee = true,
								FileCId = fileCId
							};
							_dbTbl.CrmFilesDirectory.Add(crmFilesDirectory);
							_dbTbl.SaveChanges();
							num = crmFilesDirectory.FileDirectoryID;
							string pathFtp = Configuration.PathFtp;
							string userNameFtp = Configuration.UserNameFtp;
							string passwordFtp = Configuration.PasswordFtp;
							bool usePassiveFtp = Configuration.UsePassiveFtp;
							string[] array = fileName.Split(new char[1] { '.' });
							string text14 = Configuration.MainDirectoryPath + text13 + "/";
							string text15 = text14 + (text14.EndsWith("/") ? "" : "/");
							string text16 = text15.Split(new char[1] { '/' })[^2];
							string text17 = text15.Replace(text16 + "/", "");
							bool flag2 = false;
							flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.CmsNewsDirectoryPath, usePassiveFtp);
							if (!flag2)
							{
								flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.CmsNewsDirectoryPath, usePassiveFtp);
							}
							bool flag3 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text17, text16, usePassiveFtp);
							if (!flag3)
							{
								flag3 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text17, text16, usePassiveFtp);
							}
							bool flag4 = false;
							if (flag3 && flag2)
							{
								string text18 = Configuration.MainDirectoryPath + Configuration.CmsNewsDirectoryPath + text16;
								text18 = (text18.EndsWith("/") ? text18 : (text18 + "/"));
								string pictureDirectoryPath = Configuration.PictureDirectoryPath;
								pictureDirectoryPath += (pictureDirectoryPath.EndsWith("/") ? "" : "/");
								flag4 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text18, pictureDirectoryPath, Configuration.UsePassiveFtp);
								if (!flag4)
								{
									flag4 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text18, pictureDirectoryPath, Configuration.UsePassiveFtp);
								}
								text15 += pictureDirectoryPath;
							}
							if (flag3 && flag2 && flag4)
							{
								string text19 = "";
								text19 = crmFilesDirectory.TypeOprObjectId + "-" + crmFilesDirectory.FileDirectoryID + "." + array[^1];
								string text20 = "";
								if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text15 + text19, text8, usePassiveFtp))
								{
									text14 = pathFtp + text15 + text19;
									text20 = text19;
									text14 = text14.Trim().Replace(pathFtp, "");
									crmFilesDirectory.FilePath = text14;
									crmFilesDirectory.FileName = text20;
									crmFilesDirectory.UserId = userId;
									crmFilesDirectory.Year1 = year;
									crmFilesDirectory.Month1 = month;
									crmFilesDirectory.RegisterDate = now;
									crmFilesDirectory.RegisterDatePersian = text12;
									_dbTbl.Entry(crmFilesDirectory).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
									{
										CrmFilesDirectory_Lang crmFilesDirectory_Lang = new CrmFilesDirectory_Lang();
										crmFilesDirectory_Lang.LanguageID = lang.LanguageID;
										crmFilesDirectory_Lang.FileDirectoryID = crmFilesDirectory.FileDirectoryID;
										crmFilesDirectory_Lang.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
										_dbTbl.CrmFilesDirectory_Lang.Add(crmFilesDirectory_Lang);
										_dbTbl.SaveChanges();
									}
									if (System.IO.File.Exists(text8))
									{
										System.IO.File.Delete(text8);
									}
									if (!string.IsNullOrEmpty(crmFilesDirectory.FilePath) && !string.IsNullOrEmpty(crmFilesDirectory.FileName))
									{
										string text21 = crmFilesDirectory.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
										bool flag5 = false;
										string text22 = "/" + Configuration.CmsNewsDirectoryPath;
										string text23 = base.Server.MapPath(text22);
										if (!System.IO.Directory.Exists(text23))
										{
											System.IO.Directory.CreateDirectory(text23);
											CRM.General.IO.Directory.SetFullControlForEveryOne(text23);
										}
										FilesManager filesManager = new FilesManager();
										string text24 = text21;
										text24 = text24.Replace((Configuration.MainDirectoryPath + Configuration.CmsNewsDirectoryPath).ToLower(), "");
										if (!string.IsNullOrEmpty(text24))
										{
											string[] array2 = text24.Split(new char[1] { '/' });
											if (Enumerable.Any<string>((IEnumerable<string>)array2))
											{
												for (int i = 0; i < array2.Length - 1; i++)
												{
													if (!string.IsNullOrEmpty(array2[i]) && array2[i].IndexOf(".", StringComparison.Ordinal) <= 0)
													{
														text22 = text22 + array2[i] + "/";
													}
												}
											}
											flag5 = filesManager.CreateDirectory(text22);
										}
										if (flag5)
										{
											bool flag6 = true;
											string text25 = text22 + crmFilesDirectory.FileName;
											string text26 = HttpContext.Current.Server.MapPath(text25);
											if (!System.IO.File.Exists(text26))
											{
												flag6 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text26, text21, overwrite: true, usePassiveFtp);
											}
											if (flag6 && System.IO.File.Exists(text26) && crmFilesDirectory.FileName.IndexOf(".") > 0)
											{
												string fileName2 = crmFilesDirectory.FileName;
												fileName2 = fileName2.Insert(crmFilesDirectory.FileName.IndexOf("."), "-Thumb");
												string text27 = HttpContext.Current.Server.MapPath(text22 + fileName2);
												if (!System.IO.File.Exists(text27))
												{
													ImageFormat format = SetImageFormat(crmFilesDirectory.FileName);
													ResizeImage(text26, text27, format, _ImageWidth, _ImageHeight);
												}
												if (System.IO.File.Exists(text27))
												{
													string[] array3 = text27.Split(new string[1] { "CmsNews" }, StringSplitOptions.None);
													if (Enumerable.Any<string>((IEnumerable<string>)array3) && array3.Length >= 2)
													{
														CS_0024_003C_003E8__locals0.vm.PicPath = "\\" + Configuration.CmsNewsDirectoryPath + array3[1];
														text = CS_0024_003C_003E8__locals0.vm.PicPath;
													}
													string pathFtpFo = Configuration.PathFtpFo;
													string userNameFtpFo = Configuration.UserNameFtpFo;
													string passwordFtpFo = Configuration.PasswordFtpFo;
													_ = Configuration.UsePassiveFtpFo;
													if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
													{
														try
														{
															Files.UploadFileToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtp, text25);
															Files.UploadFileToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtp, text22 + fileName2);
														}
														catch (Exception e3)
														{
															ErrorSignal.FromCurrentContext().Raise(e3);
														}
													}
												}
											}
										}
									}
								}
								else
								{
									string text28 = Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text17 + " ,directoryName: " + text16;
									Exception e4 = new Exception(text28);
									ErrorSignal.FromCurrentContext().Raise(e4);
									base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
									try
									{
										Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteFiles(num));
									}
									catch (Exception e5)
									{
										ErrorSignal.FromCurrentContext().Raise(e5);
									}
									text7 = text7 + "<br>" + Messages.msgErrorNotSavePic + "<br>" + text28;
								}
							}
							else
							{
								string text29 = Messages.msgErrorCreateFolderInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text17 + " ,directoryName: " + text16;
								Exception e6 = new Exception(text29);
								ErrorSignal.FromCurrentContext().Raise(e6);
								base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
								try
								{
									Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteFiles(num));
								}
								catch (Exception e7)
								{
									ErrorSignal.FromCurrentContext().Raise(e7);
								}
								text7 = text7 + "<br>" + Messages.msgErrorNotSavePic + "<br>" + text29;
							}
						}
					}
					else
					{
						string msgErrorFileDoesNotExist = Messages.msgErrorFileDoesNotExist;
						text2 = text2 + "<br>" + Messages.msgErrorNotSavePic + "<br>" + string.Format(msgErrorFileDoesNotExist, arg);
					}
				}
				new FilesManager();
				new FacadeFTP(Configuration.FacadeFtpFo);
				string pathFtpFo2 = Configuration.PathFtpFo;
				string userNameFtpFo2 = Configuration.UserNameFtpFo;
				string passwordFtpFo2 = Configuration.PasswordFtpFo;
				bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
				if (!string.IsNullOrEmpty(pathFtpFo2) && !string.IsNullOrEmpty(userNameFtpFo2) && !string.IsNullOrEmpty(passwordFtpFo2))
				{
					try
					{
						if (list4 != null)
						{
							Files.UploadPicFromEditorToFtp(pathFtpFo2, userNameFtpFo2, passwordFtpFo2, usePassiveFtpFo, list4);
						}
					}
					catch (Exception e8)
					{
						ErrorSignal.FromCurrentContext().Raise(e8);
					}
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsNews");
				if (string.IsNullOrWhiteSpace(text7))
				{
					base.ViewBag.Successfull = text2;
				}
				else
				{
					base.ViewBag.Successfull = text2 + "<br>" + text7;
				}
			}
		}
		catch (DbEntityValidationException e9)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e9);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception e10)
		{
			ErrorSignal.FromCurrentContext().Raise(e10);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		base.ViewBag.NewsPic = text;
		base.ViewBag.FileId = num;
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	public List<CommonMultiLanguageViewModel> GetLanguagesList()
	{
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			foreach (Languages item in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages x) => x.LanguageID != currLangID))))
			{
				list.Add(new CommonMultiLanguageViewModel
				{
					LanguageId = item.LanguageID,
					Value = ""
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LangsListJs = JsonConvert.SerializeObject(list);
		return list;
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

	[AjaxOnly]
	public string VerifyNews(int newsId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmCmsDefineNews", "actVerifyNews", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (newsId > 0)
			{
				DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				return (_db.CRMspCmsNewsVerify(newsId, currentUser.UserId, DateTime.Now) > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string ExitFromIsFixNews(int newsId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmCmsDefineNews", "actExitFromIsFix", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (newsId > 0)
			{
				return (_db.CRMspCmsNewsVerifyExit(newsId, DateTime.Now) > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[DynamicAuthorize(ControllerName = "frmCmsDefineNews", ActionName = "actShowNewsDetails")]
	public ActionResult NewsDetails(int newsId = 0)
	{
		base.ViewBag.NewsId = newsId;
		return View();
	}

	[AjaxOnly]
	public JsonResult ReturnLikesAndCommentsCount(int newsId = 0)
	{
		CRMspCmsReturnLikesAndCommentsCount_Result cRMspCmsReturnLikesAndCommentsCount_Result = new CRMspCmsReturnLikesAndCommentsCount_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			cRMspCmsReturnLikesAndCommentsCount_Result = Enumerable.FirstOrDefault<CRMspCmsReturnLikesAndCommentsCount_Result>((IEnumerable<CRMspCmsReturnLikesAndCommentsCount_Result>)_db.CRMspCmsReturnLikesAndCommentsCount(1, newsId));
			if (cRMspCmsReturnLikesAndCommentsCount_Result != null)
			{
				long result2 = 0L;
				long.TryParse(cRMspCmsReturnLikesAndCommentsCount_Result.LikeCount.ToString(), out result2);
				cRMspCmsReturnLikesAndCommentsCount_Result.LikeCount = result2;
				long result3 = 0L;
				long.TryParse(cRMspCmsReturnLikesAndCommentsCount_Result.DislikeCount.ToString(), out result3);
				cRMspCmsReturnLikesAndCommentsCount_Result.DislikeCount = result3;
				long result4 = 0L;
				long.TryParse(cRMspCmsReturnLikesAndCommentsCount_Result.CommentsCount.ToString(), out result4);
				cRMspCmsReturnLikesAndCommentsCount_Result.CommentsCount = result4;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(cRMspCmsReturnLikesAndCommentsCount_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMspCmsSelectComments_Result> NewsCommentsLst(int newsId = 0, int pageNumber = 1)
	{
		List<CRMspCmsSelectComments_Result> list = new List<CRMspCmsSelectComments_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 10;
			list = Enumerable.ToList<CRMspCmsSelectComments_Result>((IEnumerable<CRMspCmsSelectComments_Result>)_db.CRMspCmsSelectComments(1, newsId, pageNumber, value, lCID, result));
			if (Enumerable.Any<CRMspCmsSelectComments_Result>((IEnumerable<CRMspCmsSelectComments_Result>)list) && list.Count > 0)
			{
				foreach (CRMspCmsSelectComments_Result item in list)
				{
					if (item.FirstRegisterDate.HasValue)
					{
						item.FirstRegisterDatePersian = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd - dddd - HH:mm:ss") : "");
					}
					item.AppType = Labels.FOLblUnknown;
					if (item.FirstRegisterUserId.HasValue)
					{
						if (item.FirstRegisterUserId.GetValueOrDefault() == -10)
						{
							if (item.CrmCompanyId.HasValue && !string.IsNullOrEmpty(item.CrmCompany))
							{
								if (item.CrmCompany == "شخص" || item.CrmCompany == Labels.lblPerson)
								{
									item.AppType = item.CrmCompany ?? "";
									item.AppType += ((!string.IsNullOrEmpty(item.CrmCompanyPersons)) ? ("(" + item.CrmCompanyPersons + ")") : "");
								}
								else
								{
									item.AppType = item.CrmCompany ?? "";
								}
							}
						}
						else if (item.FirstRegisterUserId > 0)
						{
							item.AppType = Labels.FOLblSystem;
						}
					}
					string text = ((!string.IsNullOrEmpty(item.FName)) ? (item.FName + " ") : "") + item.LName;
					item.AppType += ((!string.IsNullOrEmpty(text)) ? ("(" + text + ")") : "");
					if (item.IsVerified.HasValue && item.IsVerified.GetValueOrDefault())
					{
						string text2 = "";
						if (item.VerifiedDateTime.HasValue)
						{
							text2 = (item.VerifiedDateTime.HasValue ? item.VerifiedDateTime.Value.ToString("yyyy/MM/dd - HH:mm:ss") : "");
						}
						item.VerifiedUser = Labels.CmsNewsShowVerifiedUser + ": " + item.VerifiedUser + " (" + text2 + ")";
					}
					else
					{
						item.VerifiedUser = "";
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public PartialViewResult _PartialNewsComments(int newsId = 0, int pageNumber = 1)
	{
		List<CRMspCmsSelectComments_Result> model = NewsCommentsLst(newsId, pageNumber);
		return PartialView("_PartialNewsComments", model);
	}

	[AjaxOnly]
	public JsonResult MoreLoadComments(int newsId = 0, int pageNumber = 1)
	{
		bool error = false;
		List<CRMspCmsSelectComments_Result> list = NewsCommentsLst(newsId, pageNumber);
		if (!Enumerable.Any<CRMspCmsSelectComments_Result>((IEnumerable<CRMspCmsSelectComments_Result>)list))
		{
			error = true;
		}
		JsonResult jsonResult = Json(new
		{
			error = error,
			result = list
		}, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsShowNewsDetails", ActionName = "actDeleteComment")]
	public string DeleteComment(int commentId)
	{
		_003C_003Ec__DisplayClass23_0 _003C_003Ec__DisplayClass23_ = new _003C_003Ec__DisplayClass23_0();
		_003C_003Ec__DisplayClass23_.commentId = commentId;
		string result = "";
		try
		{
			DbSet<CrmCmsComments> crmCmsComments = _dbTbl.CrmCmsComments;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsComments), "c");
			if (Queryable.FirstOrDefault<CrmCmsComments>((IQueryable<CrmCmsComments>)crmCmsComments, Expression.Lambda<Func<CrmCmsComments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass23_, typeof(_003C_003Ec__DisplayClass23_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteComments(_003C_003Ec__DisplayClass23_.commentId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
					}
					else if (mct_Result != null && mct_Result.Result <= 0)
					{
						result = Messages.RedundancyMessage;
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmCmsShowNewsDetails", ActionName = "actVerifyComment,actReplyComment")]
	public ActionResult InsertEditComment(int commentId = 0, int parentId = 0)
	{
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass24_0();
		CS_0024_003C_003E8__locals0.commentId = commentId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmCmsNewsCommentLanguageViewModel crmCmsNewsCommentLanguageViewModel = new CrmCmsNewsCommentLanguageViewModel();
		if (CS_0024_003C_003E8__locals0.commentId > 0)
		{
			if (!UserLogin.IsUserAccess("frmCmsShowNewsDetails", "actVerifyComment"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<CrmCmsComments_Lang> crmCmsComments_Lang = _dbTbl.CrmCmsComments_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsComments_Lang), "c");
			List<CrmCmsComments_Lang> list = Enumerable.ToList<CrmCmsComments_Lang>((IEnumerable<CrmCmsComments_Lang>)Queryable.Where<CrmCmsComments_Lang>((IQueryable<CrmCmsComments_Lang>)crmCmsComments_Lang, Expression.Lambda<Func<CrmCmsComments_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass24_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<CrmCmsComments> crmCmsComments = _dbTbl.CrmCmsComments;
			val = Expression.Parameter(typeof(CrmCmsComments), "c");
			CrmCmsComments crmCmsComments2 = Queryable.FirstOrDefault<CrmCmsComments>((IQueryable<CrmCmsComments>)crmCmsComments, Expression.Lambda<Func<CrmCmsComments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass24_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCmsComments2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsComments_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsComments_Lang>)list, (Func<CrmCmsComments_Lang, CommonMultiLanguageViewModel>)((CrmCmsComments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FName,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsComments2.FName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsComments_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsComments_Lang>)list, (Func<CrmCmsComments_Lang, CommonMultiLanguageViewModel>)((CrmCmsComments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LName,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsComments2.LName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsComments_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsComments_Lang>)list, (Func<CrmCmsComments_Lang, CommonMultiLanguageViewModel>)((CrmCmsComments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Description,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsComments2.Description,
				LanguageId = result
			});
			crmCmsNewsCommentLanguageViewModel = new CrmCmsNewsCommentLanguageViewModel
			{
				CommentId = crmCmsComments2.CommentId,
				ObjectTypeId = crmCmsComments2.ObjectTypeId,
				ObjectId = crmCmsComments2.ObjectId,
				ParentId = crmCmsComments2.ParentId,
				CrmCompanyId = crmCmsComments2.CrmCompanyId,
				IPAddress = crmCmsComments2.IPAddress,
				FName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				LName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				LName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				Mobile = crmCmsComments2.Mobile,
				Tel = crmCmsComments2.Tel,
				Email = crmCmsComments2.Email,
				IsVerified = crmCmsComments2.IsVerified,
				VerifiedUserId = crmCmsComments2.VerifiedUserId,
				VerifiedDateTime = crmCmsComments2.VerifiedDateTime,
				FirstRegisterUserId = crmCmsComments2.FirstRegisterUserId,
				FirstRegisterDate = crmCmsComments2.FirstRegisterDate,
				FirstRegisterDatePersian = crmCmsComments2.FirstRegisterDatePersian,
				UserId = crmCmsComments2.UserId,
				Year1 = crmCmsComments2.Year1,
				Month1 = crmCmsComments2.Month1,
				RegisterDate = crmCmsComments2.RegisterDate,
				RegisterDatePersian = crmCmsComments2.RegisterDatePersian,
				GUId = crmCmsComments2.GUId,
				AppType = crmCmsComments2.AppType,
				LanguageID = crmCmsComments2.LanguageID
			};
			CRMspCmsSelectCommentWithId_Result cRMspCmsSelectCommentWithId_Result = Enumerable.FirstOrDefault<CRMspCmsSelectCommentWithId_Result>((IEnumerable<CRMspCmsSelectCommentWithId_Result>)_db.CRMspCmsSelectCommentWithId(CS_0024_003C_003E8__locals0.commentId, CS_0024_003C_003E8__locals0.currLangID, result));
			if (cRMspCmsSelectCommentWithId_Result != null)
			{
				CrmCmsNewsCommentLanguageViewModel crmCmsNewsCommentLanguageViewModel2 = crmCmsNewsCommentLanguageViewModel;
				string firstRegisterUser = cRMspCmsSelectCommentWithId_Result.FirstRegisterUser;
				_ = cRMspCmsSelectCommentWithId_Result.FirstRegisterDate;
				crmCmsNewsCommentLanguageViewModel2.FirstRegisterUser = string.Concat(firstRegisterUser, "(" + cRMspCmsSelectCommentWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss") + ")");
				if (string.IsNullOrEmpty(cRMspCmsSelectCommentWithId_Result.AppType))
				{
					cRMspCmsSelectCommentWithId_Result.AppType = Configuration.AppType;
				}
				cRMspCmsSelectCommentWithId_Result.AppType = Configuration.GetAppType(cRMspCmsSelectCommentWithId_Result.AppType);
				CrmCmsNewsCommentLanguageViewModel crmCmsNewsCommentLanguageViewModel3 = crmCmsNewsCommentLanguageViewModel;
				string[] obj = new string[7]
				{
					cRMspCmsSelectCommentWithId_Result.EditUser,
					"(",
					Labels.AppType,
					":",
					cRMspCmsSelectCommentWithId_Result.AppType,
					")",
					null
				};
				_ = cRMspCmsSelectCommentWithId_Result.RegisterDate;
				obj[6] = "(" + cRMspCmsSelectCommentWithId_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss") + ")";
				crmCmsNewsCommentLanguageViewModel3.EditUser = string.Concat(obj);
				crmCmsNewsCommentLanguageViewModel.VerifiedUser = cRMspCmsSelectCommentWithId_Result.VerifiedUser + (cRMspCmsSelectCommentWithId_Result.VerifiedDateTime.HasValue ? (" (" + cRMspCmsSelectCommentWithId_Result.VerifiedDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") + ")") : "");
				if (!string.IsNullOrEmpty(cRMspCmsSelectCommentWithId_Result.CrmCompany))
				{
					if (cRMspCmsSelectCommentWithId_Result.CrmCompany == "شخص" || cRMspCmsSelectCommentWithId_Result.CrmCompany == Labels.lblPerson)
					{
						crmCmsNewsCommentLanguageViewModel.CrmCompany = cRMspCmsSelectCommentWithId_Result.CrmCompany + ((!string.IsNullOrEmpty(cRMspCmsSelectCommentWithId_Result.CrmCompanyPersons)) ? (" (" + cRMspCmsSelectCommentWithId_Result.CrmCompanyPersons + ")") : "");
					}
					else
					{
						crmCmsNewsCommentLanguageViewModel.CrmCompany = cRMspCmsSelectCommentWithId_Result.CrmCompany ?? "";
					}
				}
				if (!cRMspCmsSelectCommentWithId_Result.CrmCompanyId.HasValue)
				{
					crmCmsNewsCommentLanguageViewModel.CrmCompany = Labels.CRMLblUnknown;
				}
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmCmsShowNewsDetails", "actReplyComment"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			crmCmsNewsCommentLanguageViewModel = new CrmCmsNewsCommentLanguageViewModel
			{
				ParentId = parentId,
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDate = now,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				Year1 = short.Parse(Financial.Get().Id.ToString()),
				Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
				AppType = Configuration.AppType,
				LanguageID = result,
				FName = UserLogin.CurrentUser.FName,
				LName = UserLogin.CurrentUser.LName
			};
			CRMspCmsSelectCommentWithId_Result cRMspCmsSelectCommentWithId_Result2 = Enumerable.FirstOrDefault<CRMspCmsSelectCommentWithId_Result>((IEnumerable<CRMspCmsSelectCommentWithId_Result>)_db.CRMspCmsSelectCommentWithId(parentId, CS_0024_003C_003E8__locals0.currLangID, result));
			if (cRMspCmsSelectCommentWithId_Result2 != null)
			{
				if (!string.IsNullOrEmpty(cRMspCmsSelectCommentWithId_Result2.CrmCompany))
				{
					if (cRMspCmsSelectCommentWithId_Result2.CrmCompany == "شخص" || cRMspCmsSelectCommentWithId_Result2.CrmCompany == Labels.lblPerson)
					{
						crmCmsNewsCommentLanguageViewModel.CrmCompany = cRMspCmsSelectCommentWithId_Result2.CrmCompany + ((!string.IsNullOrEmpty(cRMspCmsSelectCommentWithId_Result2.CrmCompanyPersons)) ? (" (" + cRMspCmsSelectCommentWithId_Result2.CrmCompanyPersons + ")") : "");
					}
					else
					{
						crmCmsNewsCommentLanguageViewModel.CrmCompany = cRMspCmsSelectCommentWithId_Result2.CrmCompany ?? "";
					}
				}
				crmCmsNewsCommentLanguageViewModel.ObjectId = cRMspCmsSelectCommentWithId_Result2.ObjectId;
				crmCmsNewsCommentLanguageViewModel.ObjectTypeId = cRMspCmsSelectCommentWithId_Result2.ObjectTypeId;
			}
		}
		return View(crmCmsNewsCommentLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCmsShowNewsDetails", ActionName = "actVerifyComment,actReplyComment")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEditComment(CrmCmsNewsCommentLanguageViewModel vm)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass25_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LName_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LName_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Description_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Description_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
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
				_003C_003Ec__DisplayClass25_1 _003C_003Ec__DisplayClass25_ = new _003C_003Ec__DisplayClass25_1();
				_ = CRMIdeal.Cache.Setting.Language.Get().Count;
				string text = "";
				int num = 0;
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LName))
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.CmsNewsCommentLName) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.LName, list2))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.CmsNewsCommentLName) + "<br>";
					num++;
				}
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Description))
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.CmsNewsCommentDesc) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.Description, list3))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.CmsNewsCommentDesc) + "<br>";
					num++;
				}
				if (num > 0)
				{
					base.ViewBag.Error = text;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				_003C_003Ec__DisplayClass25_.model = new CrmCmsComments();
				if (CS_0024_003C_003E8__locals0.vm.CommentId > 0)
				{
					DbSet<CrmCmsComments> crmCmsComments = _dbTbl.CrmCmsComments;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsComments), "c");
					_003C_003Ec__DisplayClass25_.model = Queryable.FirstOrDefault<CrmCmsComments>((IQueryable<CrmCmsComments>)crmCmsComments, Expression.Lambda<Func<CrmCmsComments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass25_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass25_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass25_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass25_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass25_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass25_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass25_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass25_.model.ObjectTypeId = CS_0024_003C_003E8__locals0.vm.ObjectTypeId;
				_003C_003Ec__DisplayClass25_.model.ObjectId = CS_0024_003C_003E8__locals0.vm.ObjectId;
				_003C_003Ec__DisplayClass25_.model.ParentId = CS_0024_003C_003E8__locals0.vm.ParentId;
				_003C_003Ec__DisplayClass25_.model.CrmCompanyId = CS_0024_003C_003E8__locals0.vm.CrmCompanyId;
				_003C_003Ec__DisplayClass25_.model.IPAddress = CS_0024_003C_003E8__locals0.vm.IPAddress;
				if (CS_0024_003C_003E8__locals0.vm.CommentId == 0)
				{
					_003C_003Ec__DisplayClass25_.model.FName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass25_.model.LName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass25_.model.Mobile = CS_0024_003C_003E8__locals0.vm.Mobile;
					_003C_003Ec__DisplayClass25_.model.Tel = CS_0024_003C_003E8__locals0.vm.Tel;
					_003C_003Ec__DisplayClass25_.model.Email = CS_0024_003C_003E8__locals0.vm.Email;
					_003C_003Ec__DisplayClass25_.model.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				}
				_003C_003Ec__DisplayClass25_.model.IsVerified = CS_0024_003C_003E8__locals0.vm.IsVerified;
				if (CS_0024_003C_003E8__locals0.vm.IsVerified.HasValue)
				{
					if (CS_0024_003C_003E8__locals0.vm.IsVerified.GetValueOrDefault() && !_003C_003Ec__DisplayClass25_.model.VerifiedUserId.HasValue)
					{
						_003C_003Ec__DisplayClass25_.model.VerifiedUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass25_.model.VerifiedDateTime = now;
					}
					else if (CS_0024_003C_003E8__locals0.vm.IsVerified == false)
					{
						_003C_003Ec__DisplayClass25_.model.VerifiedUserId = null;
						_003C_003Ec__DisplayClass25_.model.VerifiedDateTime = null;
					}
				}
				if (_003C_003Ec__DisplayClass25_.model.CommentId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass25_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass25_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass25_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass25_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmCmsComments_Lang> crmCmsComments_Lang = _dbTbl.CrmCmsComments_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCmsComments_Lang), "c");
							CrmCmsComments_Lang crmCmsComments_Lang2 = Queryable.FirstOrDefault<CrmCmsComments_Lang>((IQueryable<CrmCmsComments_Lang>)crmCmsComments_Lang, Expression.Lambda<Func<CrmCmsComments_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass25_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass25_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCmsComments_Lang2 != null)
							{
								crmCmsComments_Lang2.FName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsComments_Lang2.LName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsComments_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCmsComments_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCmsComments_Lang2 = new CrmCmsComments_Lang();
							crmCmsComments_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmCmsComments_Lang2.CommentId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.CommentId;
							crmCmsComments_Lang2.FName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsComments_Lang2.LName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsComments_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmCmsComments_Lang.Add(crmCmsComments_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass25_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass25_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass25_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass25_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass25_.model.GUId = System.Guid.NewGuid();
					_003C_003Ec__DisplayClass25_.model.IPAddress = base.Request.UserHostAddress;
					_dbTbl.CrmCmsComments.Add(_003C_003Ec__DisplayClass25_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmCmsComments_Lang crmCmsComments_Lang3 = new CrmCmsComments_Lang();
						crmCmsComments_Lang3.LanguageID = lang.LanguageID;
						crmCmsComments_Lang3.CommentId = _003C_003Ec__DisplayClass25_.model.CommentId;
						crmCmsComments_Lang3.FName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsComments_Lang3.LName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsComments_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmCmsComments_Lang.Add(crmCmsComments_Lang3);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.CommentId = _003C_003Ec__DisplayClass25_.model.CommentId;
				CRMspCmsSelectCommentWithId_Result cRMspCmsSelectCommentWithId_Result = Enumerable.FirstOrDefault<CRMspCmsSelectCommentWithId_Result>((IEnumerable<CRMspCmsSelectCommentWithId_Result>)_db.CRMspCmsSelectCommentWithId(CS_0024_003C_003E8__locals0.vm.CommentId, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspCmsSelectCommentWithId_Result != null)
				{
					CrmCmsNewsCommentLanguageViewModel vm2 = CS_0024_003C_003E8__locals0.vm;
					string firstRegisterUser = cRMspCmsSelectCommentWithId_Result.FirstRegisterUser;
					_ = cRMspCmsSelectCommentWithId_Result.FirstRegisterDate;
					vm2.FirstRegisterUser = string.Concat(firstRegisterUser, "(" + cRMspCmsSelectCommentWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss") + ")");
					if (string.IsNullOrEmpty(cRMspCmsSelectCommentWithId_Result.AppType))
					{
						cRMspCmsSelectCommentWithId_Result.AppType = Configuration.AppType;
					}
					cRMspCmsSelectCommentWithId_Result.AppType = Configuration.GetAppType(cRMspCmsSelectCommentWithId_Result.AppType);
					CrmCmsNewsCommentLanguageViewModel vm3 = CS_0024_003C_003E8__locals0.vm;
					string[] obj = new string[7]
					{
						cRMspCmsSelectCommentWithId_Result.EditUser,
						"(",
						Labels.AppType,
						":",
						cRMspCmsSelectCommentWithId_Result.AppType,
						")",
						null
					};
					_ = cRMspCmsSelectCommentWithId_Result.RegisterDate;
					obj[6] = "(" + cRMspCmsSelectCommentWithId_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss") + ")";
					vm3.EditUser = string.Concat(obj);
					CS_0024_003C_003E8__locals0.vm.VerifiedUser = cRMspCmsSelectCommentWithId_Result.VerifiedUser + (cRMspCmsSelectCommentWithId_Result.VerifiedDateTime.HasValue ? (" (" + cRMspCmsSelectCommentWithId_Result.VerifiedDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") + ")") : "");
					if (!string.IsNullOrEmpty(cRMspCmsSelectCommentWithId_Result.CrmCompany))
					{
						if (cRMspCmsSelectCommentWithId_Result.CrmCompany == "شخص" || cRMspCmsSelectCommentWithId_Result.CrmCompany == Labels.lblPerson)
						{
							CS_0024_003C_003E8__locals0.vm.CrmCompany = cRMspCmsSelectCommentWithId_Result.CrmCompany + ((!string.IsNullOrEmpty(cRMspCmsSelectCommentWithId_Result.CrmCompanyPersons)) ? (" (" + cRMspCmsSelectCommentWithId_Result.CrmCompanyPersons + ")") : "");
						}
						else
						{
							CS_0024_003C_003E8__locals0.vm.CrmCompany = cRMspCmsSelectCommentWithId_Result.CrmCompany ?? "";
						}
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsDefineNews", ActionName = "actDeleteAllComments")]
	public string DeleteAllComments(int newsId)
	{
		string result = "";
		try
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteCommentsAll(1, newsId));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					result = "";
				}
				else if (mct_Result != null && mct_Result.Result <= 0)
				{
					result = Messages.RedundancyMessage;
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsDefineNews", ActionName = "actDeleteAllLikesAndDislikes")]
	public string DeleteAllLikes(int newsId)
	{
		string result = "";
		try
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteLikesAll(1, newsId));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					result = "";
				}
				else if (mct_Result != null && mct_Result.Result <= 0)
				{
					result = Messages.RedundancyMessage;
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public ActionResult Likes_Read([DataSourceRequest] DataSourceRequest request, int objectId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspCmsSelectLikes_Result> list = new List<CRMspCmsSelectLikes_Result>();
		try
		{
			list = Enumerable.ToList<CRMspCmsSelectLikes_Result>((IEnumerable<CRMspCmsSelectLikes_Result>)_db.CRMspCmsSelectLikes(1, 1, objectId, lCID, result));
			foreach (CRMspCmsSelectLikes_Result item in list)
			{
				_ = item.FirstRegisterDate;
				item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (!string.IsNullOrEmpty(item.CrmCompany) && item.CrmCompanyId.HasValue)
				{
					if (item.CrmCompany == "شخص" || item.CrmCompany == Labels.lblPerson)
					{
						item.CrmCompany += ((!string.IsNullOrEmpty(item.CrmCompanyPersons)) ? (" (" + item.CrmCompanyPersons + ")") : "");
					}
					else
					{
						item.CrmCompany = item.CrmCompany ?? "";
					}
				}
				else
				{
					item.CrmCompany = Labels.CRMLblUnknown;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult Dislikes_Read([DataSourceRequest] DataSourceRequest request, int objectId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspCmsSelectLikes_Result> list = new List<CRMspCmsSelectLikes_Result>();
		try
		{
			list = Enumerable.ToList<CRMspCmsSelectLikes_Result>((IEnumerable<CRMspCmsSelectLikes_Result>)_db.CRMspCmsSelectLikes(-1, 1, objectId, lCID, result));
			foreach (CRMspCmsSelectLikes_Result item in list)
			{
				_ = item.FirstRegisterDate;
				item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (!string.IsNullOrEmpty(item.CrmCompany) && item.CrmCompanyId.HasValue)
				{
					if (item.CrmCompany == "شخص" || item.CrmCompany == Labels.lblPerson)
					{
						item.CrmCompany += ((!string.IsNullOrEmpty(item.CrmCompanyPersons)) ? (" (" + item.CrmCompanyPersons + ")") : "");
					}
					else
					{
						item.CrmCompany = item.CrmCompany ?? "";
					}
				}
				else
				{
					item.CrmCompany = Labels.CRMLblUnknown;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsShowNewsDetails", ActionName = "actDeleteLike,actDeleteDislike")]
	public string DeleteLike(int likeId)
	{
		string result = "";
		try
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteLikes(likeId));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					result = "";
				}
				else if (mct_Result != null && mct_Result.Result <= 0)
				{
					result = Messages.RedundancyMessage;
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsDefineNewsDataEntry", ActionName = "actDeletePicture")]
	public string DeleteNewsPicture(int fileId)
	{
		_003C_003Ec__DisplayClass31_0 _003C_003Ec__DisplayClass31_ = new _003C_003Ec__DisplayClass31_0();
		_003C_003Ec__DisplayClass31_.fileId = fileId;
		string result = "";
		if (!UserLogin.IsUserAccess("frmCmsDefineNewsDataEntry", "actDeletePicture", UserLogin.CurrentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspCmsSelectNewsPicture_Result cRMspCmsSelectNewsPicture_Result = Enumerable.FirstOrDefault<CRMspCmsSelectNewsPicture_Result>((IEnumerable<CRMspCmsSelectNewsPicture_Result>)_dbI.CRMspCmsSelectNewsPicture(_003C_003Ec__DisplayClass31_.fileId, 0, 0, lCID, result2));
		if (cRMspCmsSelectNewsPicture_Result != null)
		{
			try
			{
				string text = cRMspCmsSelectNewsPicture_Result.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
				FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
				string destination = text;
				if (facadeFTP.Delete(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, cRMspCmsSelectNewsPicture_Result.FileName, destination, Configuration.UsePassiveFtp))
				{
					if (_db.CRMspDeleteCrmFilesDirectory(_003C_003Ec__DisplayClass31_.fileId) > 0)
					{
						DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
						ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
						if (Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass31_, typeof(_003C_003Ec__DisplayClass31_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) == null)
						{
							result = "";
							if (!string.IsNullOrEmpty(cRMspCmsSelectNewsPicture_Result.FilePath) && !string.IsNullOrEmpty(cRMspCmsSelectNewsPicture_Result.FileName))
							{
								string text2 = cRMspCmsSelectNewsPicture_Result.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "").Replace(Configuration.MainDirectoryPath.ToLower(), "");
								string text3 = "/" + text2;
								string path = HttpContext.Current.Server.MapPath(text3);
								if (System.IO.File.Exists(path) && cRMspCmsSelectNewsPicture_Result.FileName.IndexOf(".") > 0)
								{
									System.IO.File.Delete(path);
									string text4 = text3;
									text4 = text4.Insert(text3.IndexOf("."), "-Thumb");
									string path2 = HttpContext.Current.Server.MapPath(text4);
									if (System.IO.File.Exists(path2))
									{
										System.IO.File.Delete(path2);
									}
								}
								DeleteOldNewsFromFtp(cRMspCmsSelectNewsPicture_Result.FilePath);
							}
						}
						else
						{
							result = Messages.RedundancyMessage;
						}
					}
					else
					{
						result = Messages.RedundancyMessage;
					}
				}
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			}
		}
		return result;
	}

	[ValidateAntiForgeryToken]
	public ActionResult ActAddFile(HttpPostedFileBase picUpload, int objectId)
	{
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short month = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short year = short.Parse(Financial.Get().Id.ToString());
			CRMspCmsSelectNews_Result cRMspCmsSelectNews_Result = Enumerable.FirstOrDefault<CRMspCmsSelectNews_Result>((IEnumerable<CRMspCmsSelectNews_Result>)_db.CRMspCmsSelectNews(objectId, 0, now, now, false, lCID, defLangID));
			int num = 0;
			if (cRMspCmsSelectNews_Result != null)
			{
				int newsGroupId = cRMspCmsSelectNews_Result.NewsGroupId;
				if (picUpload != null)
				{
					string text3 = ".gif,.jpeg,.png,.x-png,.jpg,.pjpeg";
					string text4 = picUpload.ContentType.ToLower();
					string text5 = ((picUpload.FileName != null) ? Path.GetExtension(picUpload.FileName).ToLower() : "");
					if (text3 != "*" && !string.IsNullOrEmpty(text3) && text3.IndexOf(text5, StringComparison.Ordinal) < 0)
					{
						text += string.Format(Messages.msgErrorMessageFileExtension, text3);
					}
					else if ((text4 != "application/vnd.openxmlformats-officedocument.wordprocessingml.document" && text4 != "application/msword" && text4 != "text/plain" && text4 != "application/x-rar-compressed" && text4 != "application/octet-stream" && text4 != "application/vnd.ms-powerpoint" && text4 != "application/pdf" && text4 != "application/zip" && text4 != "application/vnd.openxmlformats-officedocument.presentationml.presentation" && text4 != "application/vnd.ms-excel" && text4 != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" && text4 != "image/jpg" && text4 != "image/jpeg" && text4 != "image/pjpeg" && text4 != "image/gif" && text4 != "image/x-png" && text4 != "image/png" && text4 != "video/mp4" && text4 != "audio/wav" && text4 != "audio/mp4" && text4 != "video/avi" && text4 != "audio/mpeg" && text4 != "application/xml") || (text5 != ".docx" && text5 != ".doc" && text5 != ".txt" && text5 != ".rar" && text5 != ".zip" && text5 != ".ppt" && text5 != ".pdf" && text5 != ".pptx" && text5 != ".xls" && text5 != ".xlsx" && text5 != ".jpg" && text5 != ".png" && text5 != ".gif" && text5 != ".jpeg" && text5 != ".mp4" && text5 != ".avi" && text5 != ".mp3" && text5 != ".wav" && (text5 ?? "").ToLower() != ".config"))
					{
						text += Messages.msgErrorFileIsExecuted;
					}
					else
					{
						int num2 = 204800;
						if (picUpload.ContentLength > num2)
						{
							string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(picUpload.ContentLength);
							string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num2);
							string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
							text += string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2);
						}
						else
						{
							string fileName = Path.GetFileName(picUpload.FileName);
							FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
							string text6 = "";
							text6 = Configuration.CmsNewsDirectoryPath + newsGroupId;
							newsGroupId.ToString();
							CrmCmsFiles crmCmsFiles = new CrmCmsFiles
							{
								ObjectTypeId = 1,
								ObjectId = cRMspCmsSelectNews_Result.NewsId,
								FirstRegisterUserId = userId,
								FirstRegisterDate = now,
								FirstRegisterDatePersian = text2,
								UserId = userId,
								Year1 = year,
								Month1 = month,
								RegisterDate = now,
								RegisterDatePersian = text2,
								GUId = System.Guid.NewGuid(),
								AppType = appType,
								LanguageID = defLangID,
								Title = fileName,
								FileName = "news",
								FilePath = "path"
							};
							_dbTbl.CrmCmsFiles.Add(crmCmsFiles);
							_dbTbl.SaveChanges();
							num = crmCmsFiles.FileId;
							string pathFtp = Configuration.PathFtp;
							string userNameFtp = Configuration.UserNameFtp;
							string passwordFtp = Configuration.PasswordFtp;
							bool usePassiveFtp = Configuration.UsePassiveFtp;
							string[] array = fileName.Split(new char[1] { '.' });
							string text7 = Configuration.MainDirectoryPath + text6 + "/";
							string text8 = text7 + (text7.EndsWith("/") ? "" : "/");
							string text9 = text8.Split(new char[1] { '/' })[^2];
							string text10 = text8.Replace(text9 + "/", "");
							bool flag = false;
							flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.CmsNewsDirectoryPath, usePassiveFtp);
							if (!flag)
							{
								flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.CmsNewsDirectoryPath, usePassiveFtp);
							}
							bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, text9, usePassiveFtp);
							if (!flag2)
							{
								flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, text9, usePassiveFtp);
							}
							if (flag2 && flag)
							{
								string text11 = "";
								text11 = crmCmsFiles.ObjectId + "-" + crmCmsFiles.FileId + "." + array[^1];
								string text12 = "";
								if (facadeFTP.Upload(pathFtp, userNameFtp, passwordFtp, text8 + text11, picUpload, usePassiveFtp))
								{
									text7 = pathFtp + text8 + text11;
									text12 = text11;
									text7 = text7.Trim().Replace(pathFtp, "");
									crmCmsFiles.FilePath = text7;
									crmCmsFiles.FileName = text12;
									crmCmsFiles.UserId = UserLogin.CurrentUser.UserId;
									crmCmsFiles.Year1 = year;
									crmCmsFiles.Month1 = month;
									crmCmsFiles.RegisterDate = now;
									crmCmsFiles.RegisterDatePersian = text2;
									_dbTbl.Entry(crmCmsFiles).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									foreach (Languages item in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
									{
										CrmCmsFiles_Lang entity = new CrmCmsFiles_Lang
										{
											LanguageID = item.LanguageID,
											FileId = crmCmsFiles.FileId,
											Title = fileName
										};
										_dbTbl.CrmCmsFiles_Lang.Add(entity);
										_dbTbl.SaveChanges();
									}
									if (!string.IsNullOrEmpty(crmCmsFiles.FilePath) && !string.IsNullOrEmpty(crmCmsFiles.FileName))
									{
										string text13 = crmCmsFiles.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
										bool flag3 = false;
										string text14 = "/" + Configuration.CmsNewsDirectoryPath;
										string text15 = base.Server.MapPath(text14);
										if (!System.IO.Directory.Exists(text15))
										{
											System.IO.Directory.CreateDirectory(text15);
											CRM.General.IO.Directory.SetFullControlForEveryOne(text15);
										}
										FilesManager filesManager = new FilesManager();
										string text16 = text13;
										text16 = text16.Replace((Configuration.MainDirectoryPath + Configuration.CmsNewsDirectoryPath).ToLower(), "");
										if (!string.IsNullOrEmpty(text16))
										{
											string[] array2 = text16.Split(new char[1] { '/' });
											if (Enumerable.Any<string>((IEnumerable<string>)array2))
											{
												for (int i = 0; i < array2.Length - 1; i++)
												{
													if (!string.IsNullOrEmpty(array2[i]) && array2[i].IndexOf(".", StringComparison.Ordinal) <= 0)
													{
														text14 = text14 + array2[i] + "/";
													}
												}
											}
											flag3 = filesManager.CreateDirectory(text14);
										}
										if (flag3)
										{
											bool flag4 = true;
											string text17 = text14 + crmCmsFiles.FileName;
											string text18 = HttpContext.Current.Server.MapPath(text17);
											if (!System.IO.File.Exists(text18))
											{
												flag4 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text18, text13, overwrite: true, usePassiveFtp);
											}
											if (flag4 && System.IO.File.Exists(text18) && crmCmsFiles.FileName.IndexOf(".") > 0)
											{
												string fileName2 = crmCmsFiles.FileName;
												fileName2 = fileName2.Insert(crmCmsFiles.FileName.IndexOf("."), "-Thumb");
												string text19 = HttpContext.Current.Server.MapPath(text14 + fileName2);
												if (!System.IO.File.Exists(text19))
												{
													ImageFormat format = SetImageFormat(crmCmsFiles.FileName);
													ResizeImage(text18, text19, format, _ImageWidth, _ImageHeight);
												}
												if (System.IO.File.Exists(text19))
												{
													string[] array3 = text19.Split(new string[1] { "CmsNews" }, StringSplitOptions.None);
													if (Enumerable.Any<string>((IEnumerable<string>)array3) && array3.Length >= 2)
													{
														text = "\\" + Configuration.CmsNewsDirectoryPath + array3[1] + "||" + crmCmsFiles.FileId;
													}
													string pathFtpFo = Configuration.PathFtpFo;
													string userNameFtpFo = Configuration.UserNameFtpFo;
													string passwordFtpFo = Configuration.PasswordFtpFo;
													_ = Configuration.UsePassiveFtpFo;
													if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
													{
														try
														{
															Files.UploadFileToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtp, text17);
															Files.UploadFileToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtp, text14 + fileName2);
														}
														catch (Exception e)
														{
															ErrorSignal.FromCurrentContext().Raise(e);
														}
													}
												}
											}
										}
									}
								}
								else
								{
									Exception e2 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text10 + " ,directoryName: " + text9);
									ErrorSignal.FromCurrentContext().Raise(e2);
									base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
									try
									{
										Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteFiles(num));
									}
									catch (Exception e3)
									{
										ErrorSignal.FromCurrentContext().Raise(e3);
									}
								}
							}
							else
							{
								Exception e4 = new Exception(Messages.msgErrorCreateFolderInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text10 + " ,directoryName: " + text9);
								ErrorSignal.FromCurrentContext().Raise(e4);
								base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
								try
								{
									Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteFiles(num));
								}
								catch (Exception e5)
								{
									ErrorSignal.FromCurrentContext().Raise(e5);
								}
							}
						}
					}
				}
			}
		}
		catch (Exception e6)
		{
			ErrorSignal.FromCurrentContext().Raise(e6);
		}
		return Content(text);
	}

	[ValidateAntiForgeryToken]
	public ActionResult ActAddPic([DataSourceRequest] DataSourceRequest request, HttpPostedFileBase picUpload, int newsGroupId)
	{
		string text = "";
		string text2 = "";
		try
		{
			if (picUpload != null)
			{
				bool flag = false;
				string text3 = ".gif,.jpeg,.png,.x-png,.jpg,.pjpeg";
				picUpload.ContentType.ToLower();
				string text4 = ((picUpload.FileName != null) ? Path.GetExtension(picUpload.FileName).ToLower() : "");
				if (text3 != "*" && !string.IsNullOrEmpty(text3) && text3.IndexOf(text4, StringComparison.Ordinal) < 0)
				{
					text2 += string.Format(Messages.msgErrorMessageFileExtension, text3);
					flag = true;
				}
				string arg = picUpload.FileName ?? "";
				string text5 = (text4 ?? "").ToLower();
				text5 = text5.Replace(".", "");
				if (Configuration.MaliciousFileExtensions.Contains(text5))
				{
					flag = true;
					text2 = text2 + string.Format(Messages.msgErrorNotUploadFileByDue, arg) + Messages.msgErrorFileIsExecuted + "<br>";
				}
				int num = 1048576;
				if (picUpload.ContentLength > num)
				{
					string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(picUpload.ContentLength);
					string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num);
					string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
					flag = true;
					text2 = text2 + string.Format(Messages.msgErrorNotUploadFileByDue, arg) + string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2) + "<br>";
				}
				if (flag)
				{
					text2 = "-1|" + text2;
					return Json(((IEnumerable)new string[1] { text2 }).ToDataSourceResult(request));
				}
				string text6 = "/" + Configuration.CmsNewsDirectoryPath + newsGroupId;
				string text7 = base.Server.MapPath(text6);
				if (!System.IO.Directory.Exists(text7))
				{
					System.IO.Directory.CreateDirectory(text7);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
				}
				string text8 = Path.GetFileName(picUpload.FileName);
				string text9 = Path.Combine(text7, text8);
				if (System.IO.File.Exists(text9))
				{
					text8 = DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + text8;
					text9 = Path.Combine(text7, text8);
				}
				picUpload.SaveAs(text9);
				ImageManager.CompressFile(new ImageManager.ImageParam
				{
					FilePath = text9
				});
				if (System.IO.File.Exists(text9))
				{
					text = "/" + Configuration.CmsNewsDirectoryPath + newsGroupId + "/" + text8;
					text = text.Replace("~/", "/");
					text = (text.StartsWith("/") ? text : ("/" + text));
					text = text + "|" + text8;
				}
				else
				{
					text = "";
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text2 = "-1|" + ex.Message;
			return Json(((IEnumerable)new string[1] { text2 }).ToDataSourceResult(request));
		}
		return Json(((IEnumerable)new string[1] { text }).ToDataSourceResult(request));
	}

	public string ActRemovePic(string filePath)
	{
		string result = "-1";
		if (!string.IsNullOrWhiteSpace(filePath))
		{
			try
			{
				filePath = base.Server.MapPath(filePath);
				if (System.IO.File.Exists(filePath))
				{
					System.IO.File.Delete(filePath);
				}
				result = "1";
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		else
		{
			result = Messages.msgErrorNotFilePath;
		}
		return result;
	}

	public string DownlaodNewsPic(int fileId)
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
			FilesManager filesManager = new FilesManager();
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			CRMspCmsSelectNewsPicture_Result cRMspCmsSelectNewsPicture_Result = Enumerable.FirstOrDefault<CRMspCmsSelectNewsPicture_Result>((IEnumerable<CRMspCmsSelectNewsPicture_Result>)_dbI.CRMspCmsSelectNewsPicture(fileId, 0, 0, lCID, result2));
			if (cRMspCmsSelectNewsPicture_Result != null)
			{
				string text = "";
				if (!string.IsNullOrEmpty(cRMspCmsSelectNewsPicture_Result.FilePath) && !string.IsNullOrEmpty(cRMspCmsSelectNewsPicture_Result.FileName))
				{
					string text2 = cRMspCmsSelectNewsPicture_Result.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					bool flag = false;
					string text3 = "/" + Configuration.CmsNewsDirectoryPath;
					string text4 = text2;
					text4 = text4.Replace((Configuration.MainDirectoryPath + Configuration.CmsNewsDirectoryPath).ToLower(), "");
					if (!string.IsNullOrEmpty(text4))
					{
						string[] array = text4.Split(new char[1] { '/' });
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							for (int i = 0; i < array.Length - 1; i++)
							{
								if (!string.IsNullOrEmpty(array[i]) && array[i].IndexOf(".", StringComparison.Ordinal) <= 0)
								{
									text3 = text3 + array[i] + "/";
								}
							}
						}
						flag = filesManager.CreateDirectory(text3);
					}
					if (flag)
					{
						bool flag2 = true;
						string text5 = text3 + cRMspCmsSelectNewsPicture_Result.FileName;
						text = HttpContext.Current.Server.MapPath(text5);
						if (!System.IO.File.Exists(text))
						{
							flag2 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text, text2, overwrite: true, usePassiveFtp);
						}
						if (flag2 && System.IO.File.Exists(text) && cRMspCmsSelectNewsPicture_Result.FileName.IndexOf(".") > 0)
						{
							string fileName = cRMspCmsSelectNewsPicture_Result.FileName;
							fileName = fileName.Insert(cRMspCmsSelectNewsPicture_Result.FileName.IndexOf("."), "-Thumb");
							string text6 = HttpContext.Current.Server.MapPath(text3 + fileName);
							if (!System.IO.File.Exists(text6))
							{
								ImageFormat format = SetImageFormat(cRMspCmsSelectNewsPicture_Result.FileName);
								ResizeImage(text, text6, format, _ImageWidth, _ImageHeight);
							}
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.FOMsgErrorDoneOperation + "<br>" + ex.Message;
		}
		return result;
	}

	public ImageFormat SetImageFormat(string fileName)
	{
		ImageFormat result = ImageFormat.Png;
		if (string.IsNullOrEmpty(fileName))
		{
			return result;
		}
		string[] array = fileName.Split(new char[1] { '.' });
		if (Enumerable.Any<string>((IEnumerable<string>)array) && array.Length == 2)
		{
			switch (array[1].ToLower())
			{
			case "jpeg":
			case "jpg":
				result = ImageFormat.Jpeg;
				break;
			case "png":
				result = ImageFormat.Png;
				break;
			case "gif":
				result = ImageFormat.Gif;
				break;
			case "tiff":
				result = ImageFormat.Tiff;
				break;
			case "bmp":
				result = ImageFormat.Bmp;
				break;
			default:
				result = ImageFormat.Png;
				break;
			}
		}
		return result;
	}

	public static bool ResizeImage(string orgFile, string resizedFile, ImageFormat format, int width, int height)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Image val = Image.FromFile(orgFile);
			try
			{
				Bitmap val2 = new Bitmap(width, height, val.PixelFormat);
				Graphics obj = Graphics.FromImage((Image)val2);
				obj.CompositingQuality = (CompositingQuality)2;
				obj.SmoothingMode = (SmoothingMode)2;
				obj.InterpolationMode = (InterpolationMode)7;
				Rectangle val3 = default(Rectangle);
				((Rectangle)(ref val3))._002Ector(0, 0, width, height);
				obj.DrawImage(val, val3);
				((Image)val2).Save(resizedFile, format);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
	}

	public ActionResult NewsFile_Read([DataSourceRequest] DataSourceRequest request, int newsId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			list = Files.SelectFilesDirectory("", "", "", "90", newsId.ToString(), "0", "0", false);
			if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
			{
				foreach (CRMspSelectFilesDirectory_Result item in list)
				{
					DateTime now = DateTime.Now;
					if (item.DocDateTime.HasValue)
					{
						item.DocDate = DateTime.Parse(item.DocDateTime.ToString()).ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.DocDate))
					{
						item.DocDate = PersianDate.GetFormatetdDate(item.DocDate);
					}
					if (!string.IsNullOrEmpty(item.DocDay))
					{
						item.DocDay = DateTimeClass.ConvertNumToDayeOfWeek(int.Parse(item.DocDay));
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public void DeleteOldNewsFromFtp(string filePath)
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
