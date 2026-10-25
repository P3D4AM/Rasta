using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Drawing;
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
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.BuyOrders.Controllers;

public class SerialsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int borderItemSerialId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public WSBuyOrderItemSerialsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__15;

		public Func<Languages, bool> _003C_003E9__30;

		internal bool _003CInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

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

		internal bool _003CInsertEdit_003Eb__15(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__30(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

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
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public const string SerialImportExcel_EXCEL_SHEET_NAME = "KaraAfzarIdeal";

	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actInsertItemSerial,actEditItemSerial")]
	public ActionResult InsertEdit(int borderItemId, int borderItemSerialId)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.borderItemSerialId = borderItemSerialId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSBuyOrderItemSerialsLanguageViewModel wSBuyOrderItemSerialsLanguageViewModel = new WSBuyOrderItemSerialsLanguageViewModel();
		bool flag = false;
		WSBuyOrderItems wSBuyOrderItems = _dbTbl.WSBuyOrderItems.Find(borderItemId);
		if (CS_0024_003C_003E8__locals0.borderItemSerialId > 0)
		{
			DbSet<WSBuyOrderItemSerials_Lang> wSBuyOrderItemSerials_Lang = _dbTbl.WSBuyOrderItemSerials_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderItemSerials_Lang), "c");
			List<WSBuyOrderItemSerials_Lang> list = Enumerable.ToList<WSBuyOrderItemSerials_Lang>((IEnumerable<WSBuyOrderItemSerials_Lang>)Queryable.Where<WSBuyOrderItemSerials_Lang>((IQueryable<WSBuyOrderItemSerials_Lang>)wSBuyOrderItemSerials_Lang, Expression.Lambda<Func<WSBuyOrderItemSerials_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSBuyOrderItemSerials> wSBuyOrderItemSerials = _dbTbl.WSBuyOrderItemSerials;
			val = Expression.Parameter(typeof(WSBuyOrderItemSerials), "c");
			WSBuyOrderItemSerials wSBuyOrderItemSerials2 = Queryable.FirstOrDefault<WSBuyOrderItemSerials>((IQueryable<WSBuyOrderItemSerials>)wSBuyOrderItemSerials, Expression.Lambda<Func<WSBuyOrderItemSerials, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSBuyOrderItemSerials2 != null)
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItemSerials_Lang>)list, (Func<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItemSerials_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Description,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderItemSerials2.Description,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItemSerials_Lang>)list, (Func<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItemSerials_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.InfoI,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderItemSerials2.InfoI,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItemSerials_Lang>)list, (Func<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItemSerials_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.InfoII,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderItemSerials2.InfoII,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItemSerials_Lang>)list, (Func<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItemSerials_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.InfoIII,
					LanguageId = item.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderItemSerials2.InfoIII,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItemSerials_Lang>)list, (Func<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItemSerials_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.InfoIV,
					LanguageId = item.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderItemSerials2.InfoIV,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItemSerials_Lang>)list, (Func<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItemSerials_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.InfoV,
					LanguageId = item.LanguageID
				})));
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderItemSerials2.InfoV,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItemSerials_Lang>)list, (Func<WSBuyOrderItemSerials_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItemSerials_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.InfoVI,
					LanguageId = item.LanguageID
				})));
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderItemSerials2.InfoVI,
					LanguageId = result
				});
				wSBuyOrderItemSerialsLanguageViewModel = new WSBuyOrderItemSerialsLanguageViewModel
				{
					LanguageID = wSBuyOrderItemSerials2.LanguageID,
					UserId = wSBuyOrderItemSerials2.UserId,
					FirstRegisterUserId = wSBuyOrderItemSerials2.FirstRegisterUserId,
					AppType = wSBuyOrderItemSerials2.AppType,
					FirstRegisterDate = wSBuyOrderItemSerials2.FirstRegisterDate,
					FirstRegisterDatePersian = wSBuyOrderItemSerials2.FirstRegisterDatePersian,
					GUId = wSBuyOrderItemSerials2.GUId,
					RegisterDate = wSBuyOrderItemSerials2.RegisterDate,
					Month1 = wSBuyOrderItemSerials2.Month1,
					RegisterDatePersian = wSBuyOrderItemSerials2.RegisterDatePersian,
					FPId = wSBuyOrderItemSerials2.FPId,
					WHId = wSBuyOrderItemSerials2.WHId,
					BuyOrderItemSerialID = wSBuyOrderItemSerials2.BuyOrderItemSerialID,
					BuyOrderItemId = wSBuyOrderItemSerials2.BuyOrderItemId,
					Serial = wSBuyOrderItemSerials2.Serial,
					StatusId = wSBuyOrderItemSerials2.StatusId,
					IsFix = wSBuyOrderItemSerials2.IsFix,
					SerialId = wSBuyOrderItemSerials2.SerialId,
					IsAutoBarcode = wSBuyOrderItemSerials2.IsAutoBarcode,
					tblTmpBarcodeId = wSBuyOrderItemSerials2.tblTmpBarcodeId,
					ExpDate = wSBuyOrderItemSerials2.ExpDate,
					ExpDatePersian = wSBuyOrderItemSerials2.ExpDatePersian,
					Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					InfoI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					InfoI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					InfoII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					InfoII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					InfoIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					InfoIII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					InfoIV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					InfoIV_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					InfoV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					InfoV_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					InfoVI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					InfoVI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					AppTypeHelp = wSBuyOrderItemSerials2.AppType
				};
			}
			flag = false;
		}
		else
		{
			wSBuyOrderItemSerialsLanguageViewModel = new WSBuyOrderItemSerialsLanguageViewModel();
			wSBuyOrderItemSerialsLanguageViewModel.BuyOrderItemId = borderItemId;
			wSBuyOrderItemSerialsLanguageViewModel.BuyOrderItemSerialID = CS_0024_003C_003E8__locals0.borderItemSerialId;
			wSBuyOrderItemSerialsLanguageViewModel.WHId = wSBuyOrderItems.bordIWHId;
			flag = true;
			DateTime now = DateTime.Now;
			wSBuyOrderItemSerialsLanguageViewModel.AppTypeHelp = Configuration.AppType;
			wSBuyOrderItemSerialsLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
			wSBuyOrderItemSerialsLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			wSBuyOrderItemSerialsLanguageViewModel.FirstRegisterDate = now;
			wSBuyOrderItemSerialsLanguageViewModel.RegisterDate = now;
		}
		base.ViewBag.FromNew = flag;
		SetRegisterInfo(wSBuyOrderItemSerialsLanguageViewModel);
		return View(wSBuyOrderItemSerialsLanguageViewModel);
	}

	[HttpPost]
	[LoginAuthorize]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WSBuyOrderItemSerialsLanguageViewModel vm)
	{
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		bool flag = CS_0024_003C_003E8__locals0.vm.BuyOrderItemSerialID <= 0;
		int result = 0;
		string[] array = CS_0024_003C_003E8__locals0.vm.AppType.Split(new char[1] { '|' });
		string text = array[0];
		int.TryParse(array[1], out result);
		DateTime dateTime = default(DateTime);
		string text2 = "";
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ExpDatePersian))
		{
			try
			{
				if (!string.IsNullOrEmpty(text))
				{
					text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ExpDatePersian.Replace("/", ""));
					if (lCID == 1065)
					{
						dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.ExpDatePersian = dateTime.ToString("yyyyMMdd");
					}
					else
					{
						dateTime = DateTime.Parse(PersianDate.GetShamsi2Miladi(text2.Replace("/", "")));
						CS_0024_003C_003E8__locals0.vm.ExpDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
					}
					CS_0024_003C_003E8__locals0.vm.ExpDate = dateTime;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.ErrorFormatDatePersian;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
		}
		else if (!string.IsNullOrEmpty(text))
		{
			text2 = PersianDate.GetFormatetdDate(text.Replace("/", ""));
			dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
			CS_0024_003C_003E8__locals0.vm.ExpDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
			CS_0024_003C_003E8__locals0.vm.ExpDate = dateTime;
		}
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		else
		{
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
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.InfoI_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.InfoI_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.InfoI,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.InfoII_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.InfoII_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.InfoII,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.InfoIII_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.InfoIII_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.InfoIII,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.InfoIV_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.InfoIV_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.InfoIV,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.InfoV_Lang))
			{
				list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.InfoV_Lang);
			}
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.InfoV,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.InfoVI_Lang))
			{
				list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.InfoVI_Lang);
			}
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.InfoVI,
				LanguageId = lCID
			});
			try
			{
				CS_0024_003C_003E8__locals0.vm.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = now;
				CS_0024_003C_003E8__locals0.vm.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				CS_0024_003C_003E8__locals0.vm.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				CS_0024_003C_003E8__locals0.vm.AppType = Configuration.AppType;
				CS_0024_003C_003E8__locals0.vm.FPId = Financial.Get().Id;
				WSfnCheckDuplicateBuyOrderPrdSerial_Result wSfnCheckDuplicateBuyOrderPrdSerial_Result = Enumerable.FirstOrDefault<WSfnCheckDuplicateBuyOrderPrdSerial_Result>((IEnumerable<WSfnCheckDuplicateBuyOrderPrdSerial_Result>)Enumerable.ToList<WSfnCheckDuplicateBuyOrderPrdSerial_Result>((IEnumerable<WSfnCheckDuplicateBuyOrderPrdSerial_Result>)_db.WSfnCheckDuplicateBuyOrderPrdSerial(result, CS_0024_003C_003E8__locals0.vm.Serial, CS_0024_003C_003E8__locals0.vm.BuyOrderItemSerialID, CS_0024_003C_003E8__locals0.vm.WHId)));
				if (wSfnCheckDuplicateBuyOrderPrdSerial_Result != null)
				{
					base.ViewBag.Error = Messages.msgErrorDuplicateSerialNumberInBuyOrder + wSfnCheckDuplicateBuyOrderPrdSerial_Result.bordNumber + Messages.msgErrorDuplicateSerialNumberInBuyOrder1;
				}
				else
				{
					if (CS_0024_003C_003E8__locals0.vm.ExpDatePersian != null)
					{
						CS_0024_003C_003E8__locals0.vm.ExpDatePersian = CS_0024_003C_003E8__locals0.vm.ExpDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					WSBuyOrderItemSerials wSBuyOrderItemSerials = new WSBuyOrderItemSerials();
					if (CS_0024_003C_003E8__locals0.vm.BuyOrderItemSerialID > 0)
					{
						DbSet<WSBuyOrderItemSerials> wSBuyOrderItemSerials2 = _dbTbl.WSBuyOrderItemSerials;
						ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderItemSerials), "c");
						wSBuyOrderItemSerials = Queryable.FirstOrDefault<WSBuyOrderItemSerials>((IQueryable<WSBuyOrderItemSerials>)wSBuyOrderItemSerials2, Expression.Lambda<Func<WSBuyOrderItemSerials, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) ?? new WSBuyOrderItemSerials();
					}
					CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
					wSBuyOrderItemSerials.RegisterDate = now;
					wSBuyOrderItemSerials.UserId = currentUser.UserId;
					wSBuyOrderItemSerials.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSBuyOrderItemSerials.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					wSBuyOrderItemSerials.AppType = Configuration.AppType;
					wSBuyOrderItemSerials.WHId = CS_0024_003C_003E8__locals0.vm.WHId;
					wSBuyOrderItemSerials.BuyOrderItemId = CS_0024_003C_003E8__locals0.vm.BuyOrderItemId;
					wSBuyOrderItemSerials.SerialId = CS_0024_003C_003E8__locals0.vm.SerialId;
					wSBuyOrderItemSerials.Serial = CS_0024_003C_003E8__locals0.vm.Serial;
					wSBuyOrderItemSerials.StatusId = CS_0024_003C_003E8__locals0.vm.StatusId;
					wSBuyOrderItemSerials.IsFix = CS_0024_003C_003E8__locals0.vm.IsFix;
					wSBuyOrderItemSerials.IsAutoBarcode = CS_0024_003C_003E8__locals0.vm.IsAutoBarcode;
					wSBuyOrderItemSerials.tblTmpBarcodeId = CS_0024_003C_003E8__locals0.vm.tblTmpBarcodeId;
					wSBuyOrderItemSerials.ExpDate = CS_0024_003C_003E8__locals0.vm.ExpDate;
					wSBuyOrderItemSerials.ExpDatePersian = CS_0024_003C_003E8__locals0.vm.ExpDatePersian;
					wSBuyOrderItemSerials.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSBuyOrderItemSerials.InfoI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSBuyOrderItemSerials.InfoII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSBuyOrderItemSerials.InfoIII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSBuyOrderItemSerials.InfoIV = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSBuyOrderItemSerials.InfoV = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSBuyOrderItemSerials.InfoVI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					if (wSBuyOrderItemSerials.BuyOrderItemSerialID <= 0)
					{
						wSBuyOrderItemSerials.FPId = Financial.Get().Id;
						wSBuyOrderItemSerials.GUId = Guid.NewGuid();
						wSBuyOrderItemSerials.FirstRegisterUserId = currentUser.UserId;
						wSBuyOrderItemSerials.FirstRegisterDate = now;
						wSBuyOrderItemSerials.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						wSBuyOrderItemSerials.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						wSBuyOrderItemSerials.CId = BuyOrder.GetBordItemCId(wSBuyOrderItemSerials.BuyOrderItemId);
						_dbTbl.WSBuyOrderItemSerials.Add(wSBuyOrderItemSerials);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							WSBuyOrderItemSerials_Lang wSBuyOrderItemSerials_Lang = new WSBuyOrderItemSerials_Lang();
							wSBuyOrderItemSerials_Lang.LanguageID = lang.LanguageID;
							wSBuyOrderItemSerials_Lang.BuyOrderItemSerialID = wSBuyOrderItemSerials.BuyOrderItemSerialID;
							wSBuyOrderItemSerials_Lang.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSBuyOrderItemSerials_Lang.InfoI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSBuyOrderItemSerials_Lang.InfoII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSBuyOrderItemSerials_Lang.InfoIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSBuyOrderItemSerials_Lang.InfoIV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSBuyOrderItemSerials_Lang.InfoV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSBuyOrderItemSerials_Lang.InfoVI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.WSBuyOrderItemSerials_Lang.Add(wSBuyOrderItemSerials_Lang);
							_dbTbl.SaveChanges();
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					else
					{
						_dbTbl.Entry(wSBuyOrderItemSerials).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass4_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass4_2();
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
								CS_0024_003C_003E8__locals2.lang = enumerator.Current;
								DbSet<WSBuyOrderItemSerials_Lang> wSBuyOrderItemSerials_Lang2 = _dbTbl.WSBuyOrderItemSerials_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderItemSerials_Lang), "c");
								WSBuyOrderItemSerials_Lang wSBuyOrderItemSerials_Lang3 = Queryable.FirstOrDefault<WSBuyOrderItemSerials_Lang>((IQueryable<WSBuyOrderItemSerials_Lang>)wSBuyOrderItemSerials_Lang2, Expression.Lambda<Func<WSBuyOrderItemSerials_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSBuyOrderItemSerials_Lang3 != null)
								{
									wSBuyOrderItemSerials_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSBuyOrderItemSerials_Lang3.InfoI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSBuyOrderItemSerials_Lang3.InfoII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSBuyOrderItemSerials_Lang3.InfoIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSBuyOrderItemSerials_Lang3.InfoIV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSBuyOrderItemSerials_Lang3.InfoV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSBuyOrderItemSerials_Lang3.InfoVI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSBuyOrderItemSerials_Lang3).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSBuyOrderItemSerials_Lang3 = new WSBuyOrderItemSerials_Lang();
								wSBuyOrderItemSerials_Lang3.LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID;
								wSBuyOrderItemSerials_Lang3.BuyOrderItemSerialID = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.vm.BuyOrderItemSerialID;
								wSBuyOrderItemSerials_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSBuyOrderItemSerials_Lang3.InfoI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSBuyOrderItemSerials_Lang3.InfoII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSBuyOrderItemSerials_Lang3.InfoIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSBuyOrderItemSerials_Lang3.InfoIV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSBuyOrderItemSerials_Lang3.InfoV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSBuyOrderItemSerials_Lang3.InfoVI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								_dbTbl.WSBuyOrderItemSerials_Lang.Add(wSBuyOrderItemSerials_Lang3);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					CS_0024_003C_003E8__locals0.vm.AppTypeHelp = wSBuyOrderItemSerials.AppType;
					CS_0024_003C_003E8__locals0.vm.UserId = wSBuyOrderItemSerials.UserId;
					CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = wSBuyOrderItemSerials.FirstRegisterUserId;
					CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = wSBuyOrderItemSerials.FirstRegisterDate;
					CS_0024_003C_003E8__locals0.vm.RegisterDate = wSBuyOrderItemSerials.RegisterDate;
				}
			}
			catch (DbEntityValidationException e2)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		base.ViewBag.FromNew = flag;
		CS_0024_003C_003E8__locals0.vm.AppType = text;
		SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public string ConvertDate(string dt, string typ)
	{
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result = "-1";
		try
		{
			if (typ == "fa")
			{
				result = DateTime.Parse(dt + " 00:00:00", new CultureInfo("en-US")).ToString("yyyy/MM/dd", new PersianCulture());
			}
			else if (typ == "en")
			{
				result = DateTime.Parse(PersianDate.GetShamsi2Miladi(dt.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void SetRegisterInfo(WSBuyOrderItemSerialsLanguageViewModel model)
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
				WSBuyOrderItemSerialsLanguageViewModel wSBuyOrderItemSerialsLanguageViewModel = model;
				_ = model.UserId;
				wSBuyOrderItemSerialsLanguageViewModel.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppTypeHelp))
			{
				model.AppTypeHelp = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppTypeHelp);
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

	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actSerialImportExcel")]
	public ActionResult SerialImportExcel(int borderItemId)
	{
		return View();
	}

	public ActionResult SerialImportExcelGenerateExcelFields()
	{
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ExcelPackage excelPackage = new ExcelPackage();
			ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("KaraAfzarIdeal");
			int num = 0;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.BordSerialImportExcelSerial;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.BordSerialImportExcelExpDate;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.BordSerialImportExcelExpDatePersian;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.BordSerialImportExcelDesc;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.BordSerialImportExcelInfoI;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.BordSerialImportExcelInfoII;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.BordSerialImportExcelInfoIII;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.BordSerialImportExcelInfoIV;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.BordSerialImportExcelInfoV;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.BordSerialImportExcelInfoVI;
			using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
			{
				excelRange.Style.Font.Bold = true;
				excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
				excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
				excelRange.Style.Font.Color.SetColor(Color.White);
			}
			excelPackage.Workbook.Properties.Title = Labels.CmpImportExcelPropertiesTitle;
			excelPackage.Workbook.Properties.Company = Labels.CmpImportExcelPropertiesCompany;
			excelPackage.SaveAs(base.Response.OutputStream);
			base.Response.Buffer = true;
			base.Response.AddHeader("content-disposition", "attachment; filename=CRM-Ideal.xls");
			base.Response.ContentType = "application/ms-excel";
			base.Response.Charset = "";
			base.Response.Flush();
			base.Response.End();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	public ActionResult UploadFile([DataSourceRequest] DataSourceRequest request, HttpPostedFileBase attachFileUrlUpload, int bordIPrdId, int whId)
	{
		string filePath = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSBuyOrderSerialImportExcelViewModel> list = new List<WSBuyOrderSerialImportExcelViewModel>();
		try
		{
			_ = DateTime.Now;
			object[,] array = null;
			int num = 0;
			int num2 = 0;
			byte[] buffer = new byte[base.Request.ContentLength];
			base.Request.InputStream.Read(buffer, 0, Convert.ToInt32(base.Request.ContentLength));
			using (ExcelPackage excelPackage = new ExcelPackage(base.Request.InputStream))
			{
				ExcelWorksheet excelWorksheet = Enumerable.First<ExcelWorksheet>((IEnumerable<ExcelWorksheet>)excelPackage.Workbook.Worksheets);
				num = excelWorksheet.Dimension.End.Column;
				num2 = excelWorksheet.Dimension.End.Row;
				array = new object[num2, num];
				array = (object[,])excelWorksheet.Cells.Value;
			}
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int num3 = 10;
				object[] array2 = new object[num3];
				int num4 = 1;
				for (int i = 1; i < num2; i++)
				{
					int num5 = 0;
					string text = "";
					string text2 = "";
					string text3 = "";
					string text4 = "";
					string text5 = "";
					string text6 = "";
					string text7 = "";
					string text8 = "";
					bool hasConflict = false;
					string text9 = "";
					string text10 = "";
					string text11 = "";
					for (num5 = 0; num5 < num; num5++)
					{
						if (num5 >= num3)
						{
							continue;
						}
						string text12 = "";
						array2[num5] = array[i, num5];
						if (array[0, num5] != null)
						{
							array[0, num5].ToString();
						}
						text12 = ((array2[num5] == null) ? "" : array2[num5].ToString());
						DateTime dateTime = default(DateTime);
						string text13 = "";
						if (num5 == 1 && !string.IsNullOrWhiteSpace(text12))
						{
							try
							{
								text13 = PersianDate.GetFormatetdDate(text12.Replace("/", ""));
								text10 = lCID switch
								{
									1065 => DateTime.Parse(text13 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo("en-US")), 
									1025 => DateTime.Parse(text13 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo("en-US")), 
									_ => DateTime.Parse(text13 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyy/MM/dd"), 
								};
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								base.ViewBag.Error = Messages.WrongDateTime;
								hasConflict = true;
								text9 = Messages.WrongDateTime + "|";
							}
							continue;
						}
						if (num5 == 2 && !string.IsNullOrWhiteSpace(text12))
						{
							try
							{
								text13 = PersianDate.GetFormatetdDate(text12.Replace("/", ""));
								text11 = lCID switch
								{
									1065 => DateTime.Parse(text13 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd"), 
									1025 => DateTime.Parse(text13 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd", new PersianCulture()), 
									_ => DateTime.Parse(text13 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd", new PersianCulture()), 
								};
							}
							catch (Exception e2)
							{
								ErrorSignal.FromCurrentContext().Raise(e2);
								hasConflict = true;
								text9 = text9 + Messages.WrongDateTime + "|";
							}
							continue;
						}
						if (num5 == 0 && string.IsNullOrWhiteSpace(text12))
						{
							hasConflict = true;
							text9 = text9 + string.Format(Messages.msgErrorEmptyBordSerialImportExcel, Labels.BordSerialImportExcelSerial) + "|";
						}
						else if (num5 == 0 && text12.Length > 50)
						{
							hasConflict = true;
							text9 = text9 + string.Format(Messages.msgErrorFieldLength, Labels.BordSerialImportExcelSerial, "50") + "|";
						}
						else if (num5 == 0)
						{
							text = text12;
							continue;
						}
						if (num5 == 3 && text12.Length > 300)
						{
							hasConflict = true;
							text9 = text9 + string.Format(Messages.msgErrorFieldLength, Labels.BordSerialImportExcelDesc, "300") + "|";
							continue;
						}
						switch (num5)
						{
						case 3:
							text2 = text12;
							continue;
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
							if (text12.Length > 200)
							{
								hasConflict = true;
								switch (num5)
								{
								case 4:
									text9 = text9 + string.Format(Messages.msgErrorFieldLength, Labels.BordSerialImportExcelInfoI, "200") + "|";
									break;
								case 5:
									text9 = text9 + string.Format(Messages.msgErrorFieldLength, Labels.BordSerialImportExcelInfoII, "200") + "|";
									break;
								case 6:
									text9 = text9 + string.Format(Messages.msgErrorFieldLength, Labels.BordSerialImportExcelInfoIII, "200") + "|";
									break;
								case 7:
									text9 = text9 + string.Format(Messages.msgErrorFieldLength, Labels.BordSerialImportExcelInfoIV, "200") + "|";
									break;
								case 8:
									text9 = text9 + string.Format(Messages.msgErrorFieldLength, Labels.BordSerialImportExcelInfoV, "200") + "|";
									break;
								case 9:
									text9 = text9 + string.Format(Messages.msgErrorFieldLength, Labels.BordSerialImportExcelInfoVI, "200") + "|";
									break;
								}
								continue;
							}
							break;
						}
						switch (num5)
						{
						case 4:
							text3 = text12;
							break;
						case 5:
							text4 = text12;
							break;
						case 6:
							text5 = text12;
							break;
						case 7:
							text6 = text12;
							break;
						case 8:
							text7 = text12;
							break;
						case 9:
							text8 = text12;
							break;
						}
					}
					DateTime dateTime2 = default(DateTime);
					DateTime dateTime3 = default(DateTime);
					string text14 = "";
					if (!string.IsNullOrWhiteSpace(text11) && !string.IsNullOrWhiteSpace(text10))
					{
						try
						{
							text14 = PersianDate.GetFormatetdDate(text10.Replace("/", ""));
							dateTime2 = lCID switch
							{
								1065 => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
								1025 => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
								_ => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
							};
						}
						catch (Exception e3)
						{
							ErrorSignal.FromCurrentContext().Raise(e3);
							base.ViewBag.Error = Messages.WrongDateTime;
							hasConflict = true;
							text9 = Messages.WrongDateTime + "|";
						}
						try
						{
							text14 = PersianDate.GetFormatetdDate(text11.Replace("/", ""));
							dateTime3 = lCID switch
							{
								1065 => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
								1025 => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
								_ => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
							};
						}
						catch (Exception e4)
						{
							ErrorSignal.FromCurrentContext().Raise(e4);
							hasConflict = true;
							text9 = text9 + Messages.WrongDateTime + "|";
						}
						if (dateTime2.ToString("yyyy/MM/dd") != dateTime3.ToString("yyyy/MM/dd"))
						{
							hasConflict = true;
							text9 = text9 + Messages.WrongDateTimeCompare + "|";
						}
					}
					else if (!string.IsNullOrWhiteSpace(text10))
					{
						try
						{
							text14 = PersianDate.GetFormatetdDate(text10.Replace("/", ""));
							text11 = lCID switch
							{
								1065 => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyy/MM/dd"), 
								1025 => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyy/MM/dd", new PersianCulture()), 
								_ => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyy/MM/dd", new PersianCulture()), 
							};
						}
						catch (Exception e5)
						{
							ErrorSignal.FromCurrentContext().Raise(e5);
							base.ViewBag.Error = Messages.WrongDateTime;
							hasConflict = true;
							text9 = Messages.WrongDateTime + "|";
						}
					}
					else if (!string.IsNullOrWhiteSpace(text11))
					{
						try
						{
							text14 = PersianDate.GetFormatetdDate(text11.Replace("/", ""));
							text10 = lCID switch
							{
								1065 => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd", new CultureInfo("en-US")), 
								1025 => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd", new CultureInfo("en-US")), 
								_ => DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd"), 
							};
						}
						catch (Exception e6)
						{
							ErrorSignal.FromCurrentContext().Raise(e6);
							hasConflict = true;
							text9 = text9 + Messages.WrongDateTime + "|";
						}
					}
					if (Enumerable.FirstOrDefault<WSfnCheckDuplicateBuyOrderPrdSerial_Result>((IEnumerable<WSfnCheckDuplicateBuyOrderPrdSerial_Result>)Enumerable.ToList<WSfnCheckDuplicateBuyOrderPrdSerial_Result>((IEnumerable<WSfnCheckDuplicateBuyOrderPrdSerial_Result>)_db.WSfnCheckDuplicateBuyOrderPrdSerial(bordIPrdId, text, 0, whId))) != null)
					{
						hasConflict = true;
						text9 = text9 + string.Format(Messages.msgErrorItemDuplicate, "") + "|";
					}
					list.Add(new WSBuyOrderSerialImportExcelViewModel
					{
						RowNumber = num4,
						Serial = (text ?? ""),
						ExpDate = text10,
						ExpDatePersian = text11,
						Desc = (text2 ?? ""),
						InfoI = (text3 ?? ""),
						InfoII = (text4 ?? ""),
						InfoIII = (text5 ?? ""),
						InfoIV = (text6 ?? ""),
						InfoV = (text7 ?? ""),
						InfoVI = (text8 ?? ""),
						HasConflict = hasConflict,
						ConflictDesc = (text9 ?? "")
					});
					num4++;
				}
			}
			catch (Exception e7)
			{
				ErrorSignal.FromCurrentContext().Raise(e7);
				FinishXlsJob(filePath);
			}
			FinishXlsJob(filePath);
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			FinishXlsJob(filePath);
		}
		return Json(((IEnumerable)new List<WSBuyOrderSerialImportExcelViewModel>[1] { list }).ToDataSourceResult(request));
	}

	private void FinishXlsJob(string FilePath = "")
	{
		try
		{
			if (System.IO.File.Exists(FilePath))
			{
				System.IO.File.Delete(FilePath);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public string SerialImportExcelFinalImport(string records, int whId, int buyOrderItemId, int bordISerialAvailable)
	{
		string text = "";
		if (!string.IsNullOrWhiteSpace(records))
		{
			List<WSBuyOrderSerialImportExcelViewModel> list = JsonConvert.DeserializeObject<List<WSBuyOrderSerialImportExcelViewModel>>(records);
			if (list != null && list.Count > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				int userId = UserLogin.CurrentUser.UserId;
				short.Parse(Financial.Get().Id.ToString());
				int id = Financial.Get().Id;
				short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				if (!VersionBuyer.WareHouseUserPermission)
				{
					int num = 1000;
					List<WSspSelectBuyOrderItemSerials_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderItemSerials_Result>((IEnumerable<WSspSelectBuyOrderItemSerials_Result>)_db.WSspSelectBuyOrderItemSerials(buyOrderItemId, lCID, result));
					int num2 = 0;
					if (list2 != null && Enumerable.Any<WSspSelectBuyOrderItemSerials_Result>((IEnumerable<WSspSelectBuyOrderItemSerials_Result>)list2))
					{
						num2 = Enumerable.Count<WSspSelectBuyOrderItemSerials_Result>((IEnumerable<WSspSelectBuyOrderItemSerials_Result>)list2);
					}
					int count = list.Count;
					if (num2 + count > num)
					{
						return string.Format(Messages.msgErrorInsertSeiralMoreThanNumberInBord, num);
					}
				}
				ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
				foreach (WSBuyOrderSerialImportExcelViewModel item in list)
				{
					if (item.HasConflict)
					{
						continue;
					}
					if (bordISerialAvailable <= 0)
					{
						break;
					}
					bordISerialAvailable--;
					DateTime? dateTime = default(DateTime);
					string expDatePersian = "";
					string text3 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(item.ExpDate) && !string.IsNullOrWhiteSpace(item.ExpDatePersian))
						{
							text3 = PersianDate.GetFormatetdDate(item.ExpDate.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text3, new CultureInfo("en-US"));
								expDatePersian = dateTime?.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text3, new CultureInfo("en-US"));
								expDatePersian = dateTime?.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text3);
								expDatePersian = dateTime?.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
						}
						else
						{
							dateTime = null;
							expDatePersian = "";
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						base.ViewBag.Error = Messages.WrongDateTime;
					}
					_dbI.WSspInsertBuyOrderItemSerial(whId, buyOrderItemId, item.Serial, dateTime, expDatePersian, item.Desc, item.InfoI, item.InfoII, item.InfoIII, item.InfoIV, item.InfoV, item.InfoVI, userId, value2, id, value, text2, userId, value, text2, appType, result, objectParameter);
					int result2 = 0;
					int.TryParse(objectParameter.Value.ToString(), out result2);
					if (result2 <= 0)
					{
						text = text + string.Format(Messages.msgErrorInsertRecord, item.RowNumber.ToString()) + "|";
					}
				}
			}
			else
			{
				text = Messages.ErrorNotFindRecord;
			}
		}
		else
		{
			text = Messages.ErrorNotFindRecord;
		}
		return text;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
