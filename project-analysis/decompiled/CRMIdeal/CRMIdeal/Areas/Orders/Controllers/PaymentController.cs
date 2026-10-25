using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Transactions;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.FormBase.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Orders.Controllers;

public class PaymentController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public WSOrderPaymentsLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CActRegisterpayBankDocNumber_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActRegisterpayBankDocNumber_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActRegisterpayBankDocNumber_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActRegisterpayBankDocNumber_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActRegisterpayBankDocNumber_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_1
	{
		public WSOrderPayments modelPay;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass29_1 CS_0024_003C_003E8__locals1;

		internal bool _003CActRegisterpayBankDocNumber_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActRegisterpayBankDocNumber_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActRegisterpayBankDocNumber_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActRegisterpayBankDocNumber_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActRegisterpayBankDocNumber_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActRegisterpayBankDocNumber_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActRegisterpayBankDocNumber_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActRegisterpayBankDocNumber_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int ordPayId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public WSOrderPaymentsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__21;

		public Func<Languages, bool> _003C_003E9__24;

		public Func<Languages, bool> _003C_003E9__27;

		public Func<Languages, bool> _003C_003E9__49;

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel m)
		{
			return m.LanguageId != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel m)
		{
			return m.LanguageId != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__24(Languages c)
		{
			return c.LanguageID != defLangID;
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

		internal bool _003CInsertEdit_003Eb__27(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__49(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_4
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals2;

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_5
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals3;

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int id;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[LoginAuthorize]
	public ActionResult InsertEdit(int ordPayId, int? ordId = null, bool modeVerify = false, string ordDate = "")
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.ordPayId = ordPayId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSOrderPaymentsLanguageViewModel wSOrderPaymentsLanguageViewModel = new WSOrderPaymentsLanguageViewModel();
		if (ordId.HasValue && ordId > 0)
		{
			wSOrderPaymentsLanguageViewModel = new WSOrderPaymentsLanguageViewModel();
			wSOrderPaymentsLanguageViewModel.ordpayOrderId = Convert.ToInt32(ordId);
		}
		else
		{
			DbSet<WSOrderPayments_Lang> wSOrderPayments_Lang = _dbTbl.WSOrderPayments_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderPayments_Lang), "c");
			List<WSOrderPayments_Lang> list = Enumerable.ToList<WSOrderPayments_Lang>((IEnumerable<WSOrderPayments_Lang>)Queryable.Where<WSOrderPayments_Lang>((IQueryable<WSOrderPayments_Lang>)wSOrderPayments_Lang, Expression.Lambda<Func<WSOrderPayments_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			WSOrderPayments wSOrderPayments = _dbTbl.WSOrderPayments.Find(CS_0024_003C_003E8__locals0.ordPayId) ?? new WSOrderPayments();
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderPayments_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderPayments_Lang>)list, (Func<WSOrderPayments_Lang, CommonMultiLanguageViewModel>)((WSOrderPayments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordpayDescription,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderPayments.ordpayDescription,
				LanguageId = result
			});
			string ordpayFileTypeJsonByName = "";
			string text = "";
			string payFilesJsonByName = "";
			if (CS_0024_003C_003E8__locals0.ordPayId != 0)
			{
				WSspSelectOrderPaymentsWithId_Result wSspSelectOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<WSspSelectOrderPaymentsWithId_Result>((IEnumerable<WSspSelectOrderPaymentsWithId_Result>)_dbI.WSspSelectOrderPaymentsWithId(CS_0024_003C_003E8__locals0.ordPayId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (wSspSelectOrderPaymentsWithId_Result != null)
				{
					ordpayFileTypeJsonByName = wSspSelectOrderPaymentsWithId_Result.ordpayFileTypeJsonByName ?? "";
					text = wSspSelectOrderPaymentsWithId_Result.ordpayVerifier ?? "";
					if (wSspSelectOrderPaymentsWithId_Result.ordpayVerifiedRegisterDate.HasValue)
					{
						text = text ?? "";
					}
					if (modeVerify)
					{
						int result2 = 0;
						int.TryParse(wSspSelectOrderPaymentsWithId_Result.ordpayOrderId.ToString(), out result2);
						int result3 = 0;
						int.TryParse(wSspSelectOrderPaymentsWithId_Result.OrderPaymentId.ToString(), out result3);
						if (result2 != 0 && result3 != 0)
						{
							List<CRMspSelectFilesDirectory_Result> list3 = Files.SelectFilesDirectory("", "", "", "20", result2.ToString(), result3.ToString(), "0", false);
							if (list3 != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list3))
							{
								List<CommonMultiAndIdLanguageViewModel> list4 = new List<CommonMultiAndIdLanguageViewModel>();
								foreach (CRMspSelectFilesDirectory_Result item3 in list3)
								{
									CommonMultiAndIdLanguageViewModel item2 = new CommonMultiAndIdLanguageViewModel
									{
										Id = item3.FileDirectoryID,
										Value = (item3.Title ?? "")
									};
									list4.Add(item2);
								}
								if (list4 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list4))
								{
									payFilesJsonByName = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list4));
								}
							}
						}
					}
				}
			}
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderPayments_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderPayments_Lang>)list, (Func<WSOrderPayments_Lang, CommonMultiLanguageViewModel>)((WSOrderPayments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordpayBankDocDesc,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderPayments.ordpayBankDocDesc,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderPayments_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderPayments_Lang>)list, (Func<WSOrderPayments_Lang, CommonMultiLanguageViewModel>)((WSOrderPayments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordpayBankDocDescI,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderPayments.ordpayBankDocDescI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderPayments_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderPayments_Lang>)list, (Func<WSOrderPayments_Lang, CommonMultiLanguageViewModel>)((WSOrderPayments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordpayBankName,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderPayments.ordpayBankName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderPayments_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderPayments_Lang>)list, (Func<WSOrderPayments_Lang, CommonMultiLanguageViewModel>)((WSOrderPayments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordpayBranchName,
				LanguageId = item.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderPayments.ordpayBranchName,
				LanguageId = result
			});
			WSOrderPaymentsLanguageViewModel obj = new WSOrderPaymentsLanguageViewModel
			{
				LanguageID = wSOrderPayments.LanguageID,
				UserId = wSOrderPayments.UserId,
				FirstRegisterUserId = wSOrderPayments.FirstRegisterUserId,
				AppType = wSOrderPayments.AppType,
				FirstRegisterDate = wSOrderPayments.FirstRegisterDate,
				FirstRegisterDatePersian = wSOrderPayments.FirstRegisterDatePersian,
				GUId = wSOrderPayments.GUId,
				RegisterDate = wSOrderPayments.RegisterDate,
				Month1 = wSOrderPayments.Month1
			};
			_ = wSOrderPayments.RegisterDate;
			obj.RegisterDatePersian = wSOrderPayments.RegisterDate.ToString("yyyyMMdd");
			obj.FPId = wSOrderPayments.FPId;
			obj.ImportDateTime = wSOrderPayments.ImportDateTime;
			obj.ImportDate = (wSOrderPayments.ImportDateTime.HasValue ? wSOrderPayments.ImportDateTime.Value.ToString("yyyyMMdd") : "");
			obj.PreOrderPaymentId = wSOrderPayments.PreOrderPaymentId;
			obj.ordpayAmount = wSOrderPayments.ordpayAmount;
			obj.ordpayDocAmount = wSOrderPayments.ordpayDocAmount;
			obj.ordpayDocDate = (wSOrderPayments.ordpayDocDateTime.HasValue ? wSOrderPayments.ordpayDocDateTime.Value.ToString("yyyyMMdd") : "");
			obj.ordpayDocDateTime = wSOrderPayments.ordpayDocDateTime;
			obj.ordpayDocDateTemp = (wSOrderPayments.ordpayDocDateTimeTemp.HasValue ? wSOrderPayments.ordpayDocDateTimeTemp.Value.ToString("yyyyMMdd") : "");
			obj.ordpayDocDateTimeTemp = wSOrderPayments.ordpayDocDateTimeTemp;
			obj.ordpayDocId = wSOrderPayments.ordpayDocId;
			obj.ordpayDocNumber = wSOrderPayments.ordpayDocNumber;
			obj.ordpayDocTypeId = wSOrderPayments.ordpayDocTypeId;
			obj.ordpayFirstRegisteDate = wSOrderPayments.ordpayFirstRegisteDate;
			obj.ordpayFirstRegisteDatePersian = wSOrderPayments.FirstRegisterDatePersian;
			obj.ordpayFirstRegisterUserId = wSOrderPayments.ordpayFirstRegisterUserId;
			obj.ordpayTypeId = wSOrderPayments.ordpayTypeId;
			obj.ordpayDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.ordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.OrderPaymentId = wSOrderPayments.OrderPaymentId;
			obj.ordpayOrderId = wSOrderPayments.ordpayOrderId;
			obj.ordpayBankDocNumber = wSOrderPayments.ordpayBankDocNumber;
			obj.ordpayCompanyMoneyBagId = wSOrderPayments.ordpayCompanyMoneyBagId;
			obj.ordpayDeActive = wSOrderPayments.ordpayDeActive;
			obj.ModeVirify = modeVerify;
			obj.ordpayAmountTemp = wSOrderPayments.ordpayAmountTemp;
			obj.ordpayIsVerified = wSOrderPayments.ordpayIsVerified;
			obj.ordpayVerifierId = wSOrderPayments.ordpayVerifierId;
			obj.ordpayVerifier = text;
			obj.ordpayVerifiedRegisterDate = wSOrderPayments.ordpayVerifiedRegisterDate;
			obj.ordpayVerifiedRegisterDatePersian = wSOrderPayments.ordpayVerifiedRegisterDatePersian;
			obj.ordpayFileTypeJson = wSOrderPayments.ordpayFileTypeJson;
			obj.ordpayFileTypeJsonByName = ordpayFileTypeJsonByName;
			obj.PayFilesJsonByName = payFilesJsonByName;
			obj.ordpayCardNumber = wSOrderPayments.ordpayCardNumber;
			obj.ordpayAccountNumber = wSOrderPayments.ordpayAccountNumber;
			obj.ordpayBankDocDate = wSOrderPayments.ordpayBankDocDate;
			obj.ordpayBankDocDatePersian = (wSOrderPayments.ordpayBankDocDate.HasValue ? wSOrderPayments.ordpayBankDocDate.Value.ToString("yyyyMMdd") : "");
			obj.ordpayBankDocAmount = wSOrderPayments.ordpayBankDocAmount;
			obj.ordpayBankDocDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.ordpayBankDocDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.ordpayBankDocDescI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.ordpayBankDocDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.ordpayBankDocRegisterUserId = wSOrderPayments.ordpayBankDocRegisterUserId;
			obj.ordpayBankDocRegisterDate = wSOrderPayments.ordpayBankDocRegisterDate;
			obj.ordpayBankDocRegisterDatePersian = (wSOrderPayments.ordpayBankDocRegisterDate.HasValue ? wSOrderPayments.ordpayBankDocRegisterDate.Value.ToString("yyyyMMdd") : "");
			obj.ordpayHeadingUpAmount = wSOrderPayments.ordpayHeadingUpAmount;
			obj.ordpayHeadingUpDay = wSOrderPayments.ordpayHeadingUpDay;
			obj.ordpayDocDayTemp = wSOrderPayments.ordpayDocDayTemp;
			obj.ordpayBankingBankID = wSOrderPayments.ordpayBankingBankID;
			obj.ordpayBankingBranchID = wSOrderPayments.ordpayBankingBranchID;
			obj.ordpayBankingAccountID = wSOrderPayments.ordpayBankingAccountID;
			obj.ordpayCashId = wSOrderPayments.ordpayCashId;
			obj.ordpayGroupIdI = wSOrderPayments.ordpayGroupIdI;
			obj.ordpayGroupIdII = wSOrderPayments.ordpayGroupIdII;
			obj.ordpayChqSayadNumber = wSOrderPayments.ordpayChqSayadNumber;
			obj.ordpayChqSerialNumber = wSOrderPayments.ordpayChqSerialNumber;
			obj.TspOrdPayIinn = wSOrderPayments.TspOrdPayIinn;
			obj.TspOrdPayAcn = wSOrderPayments.TspOrdPayAcn;
			obj.TspOrdPayTrmn = wSOrderPayments.TspOrdPayTrmn;
			obj.TspOrdPayPmt = wSOrderPayments.TspOrdPayPmt;
			obj.ordpayBankName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.ordpayBankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.ordpayBranchName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.ordpayBranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.ordpayBranchCode = wSOrderPayments.ordpayBranchCode;
			obj.ordpayBankingBankID_I = wSOrderPayments.ordpayBankingBankID;
			wSOrderPaymentsLanguageViewModel = obj;
		}
		if (!wSOrderPaymentsLanguageViewModel.ordDateTime.HasValue)
		{
			wSOrderPaymentsLanguageViewModel.ordDateTime = DateTime.Now;
		}
		FillDropdownOrdPay();
		SetRegisterInfo(wSOrderPaymentsLanguageViewModel);
		return View(wSOrderPaymentsLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[LoginAuthorize]
	public ActionResult InsertEdit(WSOrderPaymentsLanguageViewModel vm)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = null;
		if (UserLogin.CurrentUser != null)
		{
			centerId = UserLogin.CurrentUser.UserLastCId;
		}
		FillDropdownOrdPay();
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordpayDescription_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordpayDescription_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.ordpayDescription,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordpayBankDocDesc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordpayBankDocDesc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.ordpayBankDocDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordpayBankDocDescI_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordpayBankDocDescI_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.ordpayBankDocDescI,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordpayBankName_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordpayBankName_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.ordpayBankName,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordpayBranchName_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordpayBranchName_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.ordpayBranchName,
				LanguageId = lCID
			});
			try
			{
				CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
				DateTime now = DateTime.Now;
				if (CS_0024_003C_003E8__locals0.vm.OrderPaymentId > 0 && Order.PayIsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.vm.OrderPaymentId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				CS_0024_003C_003E8__locals0.vm.ImportDate = CS_0024_003C_003E8__locals0.vm.ImportDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				CS_0024_003C_003E8__locals0.vm.ordpayDocDate = (CS_0024_003C_003E8__locals0.vm.ordpayDocDate ?? "").Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp ?? "").Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				DateTime dateTime = default(DateTime);
				string text = "";
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ImportDate))
					{
						text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ImportDate.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.ImportDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.ImportDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.ImportDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.ImportDateTime = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = Messages.ErrorFormatDatePersian;
					CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayDocDate = (CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian = (CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordpayDocDate))
					{
						text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ordpayDocDate.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.ordpayDocDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.ordpayDocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.ordpayDocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime = dateTime;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					base.ViewBag.Error = Messages.ErrorFormatDatePersian;
					CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayDocDate = (CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian = (CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				try
				{
					if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp))
					{
						text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp = dateTime;
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					base.ViewBag.Error = Messages.ErrorFormatDatePersian;
					CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayDocDate = (CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian = (CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian))
					{
						CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian = CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
						text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate = dateTime;
					}
				}
				catch (Exception e4)
				{
					ErrorSignal.FromCurrentContext().Raise(e4);
					base.ViewBag.Error = Messages.ErrorFormatDatePersian;
					CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayDocDate = (CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian = (CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				WSOrderPayments wSOrderPayments = new WSOrderPayments();
				if (CS_0024_003C_003E8__locals0.vm.OrderPaymentId > 0)
				{
					DbSet<WSOrderPayments> wSOrderPayments2 = _dbTbl.WSOrderPayments;
					ParameterExpression val = Expression.Parameter(typeof(WSOrderPayments), "c");
					wSOrderPayments = Queryable.FirstOrDefault<WSOrderPayments>((IQueryable<WSOrderPayments>)wSOrderPayments2, Expression.Lambda<Func<WSOrderPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				CS_0024_003C_003E8__locals0.vm.RegisterDate = wSOrderPayments.RegisterDate;
				wSOrderPayments.AppType = Configuration.AppType;
				bool result = false;
				bool.TryParse(CS_0024_003C_003E8__locals0.vm.ModeVirify.ToString(), out result);
				if (!result)
				{
					wSOrderPayments.RegisterDate = now;
					CS_0024_003C_003E8__locals0.vm.RegisterDate = now;
					wSOrderPayments.UserId = currentUser.UserId;
					wSOrderPayments.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSOrderPayments.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					wSOrderPayments.ImportDateTime = CS_0024_003C_003E8__locals0.vm.ImportDateTime;
					wSOrderPayments.ImportDate = CS_0024_003C_003E8__locals0.vm.ImportDate;
					wSOrderPayments.PreOrderPaymentId = CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId;
					wSOrderPayments.OrderPaymentId = CS_0024_003C_003E8__locals0.vm.OrderPaymentId;
					wSOrderPayments.ordpayAmount = CS_0024_003C_003E8__locals0.vm.ordpayAmount;
					wSOrderPayments.ordpayDocAmount = CS_0024_003C_003E8__locals0.vm.ordpayDocAmount;
					wSOrderPayments.ordpayDocDate = CS_0024_003C_003E8__locals0.vm.ordpayDocDate;
					wSOrderPayments.ordpayDocDateTime = CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime;
					if (UserLogin.IsUserAccess("frmOrder", "actCanEditOrdPayDocDateTemp", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals0.vm.OrderPaymentId == 0)
					{
						wSOrderPayments.ordpayDocDateTemp = CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp;
						wSOrderPayments.ordpayDocDateTimeTemp = CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp;
						wSOrderPayments.ordpayDocDayTemp = CS_0024_003C_003E8__locals0.vm.ordpayDocDayTemp;
					}
					wSOrderPayments.ordpayDocId = CS_0024_003C_003E8__locals0.vm.ordpayDocId;
					wSOrderPayments.ordpayDocNumber = CS_0024_003C_003E8__locals0.vm.ordpayDocNumber;
					wSOrderPayments.ordpayDocTypeId = CS_0024_003C_003E8__locals0.vm.ordpayDocTypeId;
					wSOrderPayments.ordpayFirstRegisteDate = CS_0024_003C_003E8__locals0.vm.ordpayFirstRegisteDate;
					wSOrderPayments.ordpayFirstRegisteDatePersian = CS_0024_003C_003E8__locals0.vm.ordpayFirstRegisteDatePersian;
					wSOrderPayments.ordpayFirstRegisterUserId = CS_0024_003C_003E8__locals0.vm.ordpayFirstRegisterUserId;
					wSOrderPayments.ordpayOrderId = CS_0024_003C_003E8__locals0.vm.ordpayOrderId;
					int ordpayTypeId = wSOrderPayments.ordpayTypeId;
					if (!UserLogin.IsUserAccess("frmOrder", "actCanNotChangeOrdPayType", UserLogin.CurrentUser))
					{
						wSOrderPayments.ordpayTypeId = CS_0024_003C_003E8__locals0.vm.ordpayTypeId;
					}
					else if (wSOrderPayments.OrderPaymentId == 0)
					{
						wSOrderPayments.ordpayTypeId = CS_0024_003C_003E8__locals0.vm.ordpayTypeId;
					}
					wSOrderPayments.ordpayDeActive = CS_0024_003C_003E8__locals0.vm.ordpayDeActive;
					wSOrderPayments.ordpayCompanyMoneyBagId = CS_0024_003C_003E8__locals0.vm.ordpayCompanyMoneyBagId;
					int result2 = 0;
					int.TryParse(wSOrderPayments.ordpayCompanyMoneyBagId.ToString(), out result2);
					if (result2 == 0 && wSOrderPayments.ordpayTypeId == -10)
					{
						DateTime now2 = DateTime.Now;
						DateTime value = now2;
						string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
						short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType = Configuration.AppType;
						short value3 = short.Parse(Financial.Get().Id.ToString());
						int userId = UserLogin.CurrentUser.UserId;
						List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
						List<WSspSelectOrderPaymentTypesInLangsById_Result> list7 = Enumerable.ToList<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)_dbI.WSspSelectOrderPaymentTypesInLangsById(wSOrderPayments.ordpayTypeId));
						WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(wSOrderPayments.ordpayOrderId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						foreach (Languages lang3 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
						{
							string text2 = "";
							if (list7 != null && Enumerable.Any<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)list7))
							{
								WSspSelectOrderPaymentTypesInLangsById_Result wSspSelectOrderPaymentTypesInLangsById_Result = Enumerable.FirstOrDefault<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)list7, (Func<WSspSelectOrderPaymentTypesInLangsById_Result, bool>)((WSspSelectOrderPaymentTypesInLangsById_Result m) => m.LanguageID == lang3.LanguageID));
								if (wSspSelectOrderPaymentTypesInLangsById_Result != null)
								{
									text2 = wSspSelectOrderPaymentTypesInLangsById_Result.ordpayType ?? "";
								}
							}
							string text3 = "";
							string text4 = "";
							if (wSspSelectOrderById_Result != null)
							{
								text3 = wSspSelectOrderById_Result.ordNumber.ToString();
								if (wSspSelectOrderById_Result.ordDateTime.HasValue)
								{
									text4 = ((lang3.LanguageID != 1065) ? ((lang3.LanguageID != 1025) ? wSspSelectOrderById_Result.ordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : wSspSelectOrderById_Result.ordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"))) : wSspSelectOrderById_Result.ordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture()));
								}
							}
							CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
							commonMultiLanguageViewModel.LanguageId = lang3.LanguageID;
							commonMultiLanguageViewModel.Value = text2 + " - " + MyResource.GetResourceString("lblOrd", lang3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " - " + text3 + " - " + text4;
							CommonMultiLanguageViewModel item = commonMultiLanguageViewModel;
							list6.Add(item);
						}
						string cmpMnBgDesc = "";
						string cmpMnBgDesc_Lang = "";
						if (list6 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6))
						{
							cmpMnBgDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							if (list6 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6))
							{
								cmpMnBgDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
							}
						}
						ObjectParameter objectParameter = new ObjectParameter("insertedCompanyMoneyBagId", 0);
						Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspInsertCompanyMoneyBag(wSspSelectOrderById_Result.ordCompanyId, 30, wSOrderPayments.ordpayOrderId, wSOrderPayments.ImportDateTime, wSOrderPayments.ImportDate, wSOrderPayments.ordpayAmount * -1m, cmpMnBgDesc, cmpMnBgDesc_Lang, null, userId, value3, value2, value, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, objectParameter, null, null, centerId));
						result2 = 0;
						if (objectParameter.Value != null)
						{
							int.TryParse(objectParameter.Value.ToString(), out result2);
						}
						if (result2 > 0)
						{
							CS_0024_003C_003E8__locals0.vm.ordpayCompanyMoneyBagId = result2;
							wSOrderPayments.ordpayCompanyMoneyBagId = result2;
						}
					}
					else if (result2 != 0 && ordpayTypeId == -10 && ordpayTypeId != wSOrderPayments.ordpayTypeId)
					{
						wSOrderPayments.ordpayCompanyMoneyBagId = null;
						CS_0024_003C_003E8__locals0.vm.ordpayCompanyMoneyBagId = null;
						Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteCompanyMoneyBagFromPayment(result2, 2, wSOrderPayments.OrderPaymentId));
					}
					else if (result2 != 0 && wSOrderPayments.ordpayTypeId == -10)
					{
						DateTime now3 = DateTime.Now;
						DateTime value4 = now3;
						string registerDatePersian2 = now3.ToString("yyyyMMdd", new PersianCulture());
						short value5 = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType2 = Configuration.AppType;
						short value6 = short.Parse(Financial.Get().Id.ToString());
						int userId2 = UserLogin.CurrentUser.UserId;
						List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
						List<WSspSelectOrderPaymentTypesInLangsById_Result> list9 = Enumerable.ToList<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)_dbI.WSspSelectOrderPaymentTypesInLangsById(wSOrderPayments.ordpayTypeId));
						WSspSelectOrderById_Result wSspSelectOrderById_Result2 = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(wSOrderPayments.ordpayOrderId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						foreach (Languages lang2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
						{
							string text5 = "";
							if (list9 != null && Enumerable.Any<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)list9))
							{
								WSspSelectOrderPaymentTypesInLangsById_Result wSspSelectOrderPaymentTypesInLangsById_Result2 = Enumerable.FirstOrDefault<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)list9, (Func<WSspSelectOrderPaymentTypesInLangsById_Result, bool>)((WSspSelectOrderPaymentTypesInLangsById_Result m) => m.LanguageID == lang2.LanguageID));
								if (wSspSelectOrderPaymentTypesInLangsById_Result2 != null)
								{
									text5 = wSspSelectOrderPaymentTypesInLangsById_Result2.ordpayType ?? "";
								}
							}
							string text6 = "";
							string text7 = "";
							if (wSspSelectOrderById_Result2 != null)
							{
								text6 = wSspSelectOrderById_Result2.ordNumber.ToString();
								if (wSspSelectOrderById_Result2.ordDateTime.HasValue)
								{
									text7 = ((lang2.LanguageID != 1065) ? ((lang2.LanguageID != 1025) ? wSspSelectOrderById_Result2.ordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : wSspSelectOrderById_Result2.ordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"))) : wSspSelectOrderById_Result2.ordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture()));
								}
							}
							CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
							commonMultiLanguageViewModel.LanguageId = lang2.LanguageID;
							commonMultiLanguageViewModel.Value = text5 + " - " + MyResource.GetResourceString("lblOrd", lang2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " - " + text6 + " - " + text7;
							CommonMultiLanguageViewModel item2 = commonMultiLanguageViewModel;
							list8.Add(item2);
						}
						string cmpMnBgDesc2 = "";
						string cmpMnBgDesc_Lang2 = "";
						if (list8 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8))
						{
							cmpMnBgDesc2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							if (list8 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8))
							{
								cmpMnBgDesc_Lang2 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
							}
						}
						Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspUpdateCompanyMoneyBag(result2, wSOrderPayments.ImportDateTime, wSOrderPayments.ImportDate, wSOrderPayments.ordpayAmount * -1m, cmpMnBgDesc2, cmpMnBgDesc_Lang2, null, userId2, value5, value6, value4, registerDatePersian2, appType2, CS_0024_003C_003E8__locals0.defLangID, null, null));
					}
					wSOrderPayments.ordpayDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSOrderPayments.ordpayFileTypeJson = CS_0024_003C_003E8__locals0.vm.ordpayFileTypeJson;
					if ((wSOrderPayments.ordpayBankDocNumber ?? "") != (CS_0024_003C_003E8__locals0.vm.ordpayBankDocNumber ?? "") || (wSOrderPayments.ordpayBankDocDatePersian ?? "") != (CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian ?? "") || wSOrderPayments.ordpayBankDocAmount.GetValueOrDefault() != CS_0024_003C_003E8__locals0.vm.ordpayBankDocAmount.GetValueOrDefault() || (wSOrderPayments.ordpayBankDocDesc ?? "") != (CS_0024_003C_003E8__locals0.vm.ordpayBankDocDesc ?? "") || (wSOrderPayments.ordpayBankDocDescI ?? "") != (CS_0024_003C_003E8__locals0.vm.ordpayBankDocDescI ?? ""))
					{
						wSOrderPayments.ordpayBankDocRegisterUserId = currentUser.UserId;
						wSOrderPayments.ordpayBankDocRegisterDate = now;
						wSOrderPayments.ordpayBankDocRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					}
					if (list2 != null || list3 != null)
					{
						if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
						{
							List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2);
							if (list10 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10))
							{
								using List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass6_3 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass6_3();
									CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals3.lang = enumerator.Current;
									DbSet<WSOrderPayments_Lang> wSOrderPayments_Lang = _dbTbl.WSOrderPayments_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSOrderPayments_Lang), "c");
									WSOrderPayments_Lang wSOrderPayments_Lang2 = Queryable.FirstOrDefault<WSOrderPayments_Lang>((IQueryable<WSOrderPayments_Lang>)wSOrderPayments_Lang, Expression.Lambda<Func<WSOrderPayments_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals3, typeof(_003C_003Ec__DisplayClass6_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals3, typeof(_003C_003Ec__DisplayClass6_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									CommonMultiLanguageViewModel commonMultiLanguageViewModel2 = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID));
									if (commonMultiLanguageViewModel2 == null)
									{
										continue;
									}
									if (wSOrderPayments_Lang2 != null)
									{
										if ((wSOrderPayments_Lang2.ordpayBankDocDesc ?? "") != (commonMultiLanguageViewModel2.Value ?? ""))
										{
											wSOrderPayments.ordpayBankDocRegisterUserId = currentUser.UserId;
											wSOrderPayments.ordpayBankDocRegisterDate = now;
											wSOrderPayments.ordpayBankDocRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
										}
									}
									else if (!string.IsNullOrWhiteSpace(commonMultiLanguageViewModel2.Value))
									{
										wSOrderPayments.ordpayBankDocRegisterUserId = currentUser.UserId;
										wSOrderPayments.ordpayBankDocRegisterDate = now;
										wSOrderPayments.ordpayBankDocRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
									}
								}
							}
						}
						if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
						{
							List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3);
							if (list11 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11))
							{
								using List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass6_4 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass6_4();
									CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals4.lang = enumerator.Current;
									DbSet<WSOrderPayments_Lang> wSOrderPayments_Lang3 = _dbTbl.WSOrderPayments_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSOrderPayments_Lang), "c");
									WSOrderPayments_Lang wSOrderPayments_Lang4 = Queryable.FirstOrDefault<WSOrderPayments_Lang>((IQueryable<WSOrderPayments_Lang>)wSOrderPayments_Lang3, Expression.Lambda<Func<WSOrderPayments_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals4, typeof(_003C_003Ec__DisplayClass6_4)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals4, typeof(_003C_003Ec__DisplayClass6_4)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									CommonMultiLanguageViewModel commonMultiLanguageViewModel3 = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID));
									if (commonMultiLanguageViewModel3 == null)
									{
										continue;
									}
									if (wSOrderPayments_Lang4 != null)
									{
										if ((wSOrderPayments_Lang4.ordpayBankDocDescI ?? "") != (commonMultiLanguageViewModel3.Value ?? ""))
										{
											wSOrderPayments.ordpayBankDocRegisterUserId = currentUser.UserId;
											wSOrderPayments.ordpayBankDocRegisterDate = now;
											wSOrderPayments.ordpayBankDocRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
										}
									}
									else if (!string.IsNullOrWhiteSpace(commonMultiLanguageViewModel3.Value))
									{
										wSOrderPayments.ordpayBankDocRegisterUserId = currentUser.UserId;
										wSOrderPayments.ordpayBankDocRegisterDate = now;
										wSOrderPayments.ordpayBankDocRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
									}
								}
							}
						}
					}
					wSOrderPayments.ordpayBankDocDate = CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate;
					wSOrderPayments.ordpayBankDocDatePersian = CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian;
					wSOrderPayments.ordpayBankDocAmount = CS_0024_003C_003E8__locals0.vm.ordpayBankDocAmount;
					wSOrderPayments.ordpayBankDocDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSOrderPayments.ordpayBankDocDescI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSOrderPayments.ordpayBankDocNumber = CS_0024_003C_003E8__locals0.vm.ordpayBankDocNumber;
					wSOrderPayments.ordpayCardNumber = CS_0024_003C_003E8__locals0.vm.ordpayCardNumber;
					wSOrderPayments.ordpayGroupIdI = CS_0024_003C_003E8__locals0.vm.ordpayGroupIdI;
					wSOrderPayments.ordpayGroupIdII = CS_0024_003C_003E8__locals0.vm.ordpayGroupIdII;
					if (!UserLogin.IsUserAccess("frmOrder", "actCanNotChangePayBankInfoInEdit", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals0.vm.OrderPaymentId == 0)
					{
						wSOrderPayments.ordpayBankingBankID = CS_0024_003C_003E8__locals0.vm.ordpayBankingBankID;
						wSOrderPayments.ordpayBankingBranchID = CS_0024_003C_003E8__locals0.vm.ordpayBankingBranchID;
						wSOrderPayments.ordpayBankingAccountID = CS_0024_003C_003E8__locals0.vm.ordpayBankingAccountID;
						wSOrderPayments.ordpayCashId = CS_0024_003C_003E8__locals0.vm.ordpayCashId;
						wSOrderPayments.ordpayBankName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSOrderPayments.ordpayBranchName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSOrderPayments.ordpayBranchCode = CS_0024_003C_003E8__locals0.vm.ordpayBranchCode;
						wSOrderPayments.ordpayAccountNumber = CS_0024_003C_003E8__locals0.vm.ordpayAccountNumber;
						if (wSOrderPayments.ordpayBankingBankID.GetValueOrDefault() == 0)
						{
							wSOrderPayments.ordpayBankingBankID = null;
						}
						if (wSOrderPayments.ordpayBankingBranchID.GetValueOrDefault() == 0)
						{
							wSOrderPayments.ordpayBankingBranchID = null;
						}
						if (wSOrderPayments.ordpayBankingAccountID.GetValueOrDefault() == 0)
						{
							wSOrderPayments.ordpayBankingAccountID = null;
							wSOrderPayments.ordpayBankingBranchID = null;
						}
					}
					wSOrderPayments.ordpayChqSayadNumber = CS_0024_003C_003E8__locals0.vm.ordpayChqSayadNumber;
					wSOrderPayments.ordpayChqSerialNumber = CS_0024_003C_003E8__locals0.vm.ordpayChqSerialNumber;
					if (VersionBuyer.Tsp)
					{
						wSOrderPayments.TspOrdPayAcn = CS_0024_003C_003E8__locals0.vm.TspOrdPayAcn;
						wSOrderPayments.TspOrdPayIinn = CS_0024_003C_003E8__locals0.vm.TspOrdPayIinn;
						wSOrderPayments.TspOrdPayPmt = CS_0024_003C_003E8__locals0.vm.TspOrdPayPmt;
						wSOrderPayments.TspOrdPayTrmn = CS_0024_003C_003E8__locals0.vm.TspOrdPayTrmn;
					}
				}
				else
				{
					wSOrderPayments.ordpayAmount = CS_0024_003C_003E8__locals0.vm.ordpayAmount;
				}
				if (CS_0024_003C_003E8__locals0.vm.OrderPaymentId != 0)
				{
					if (UserLogin.IsUserAccess("frmOrder", "actCanChangeOrdPayAmountTempInVerify", UserLogin.CurrentUser) && result)
					{
						wSOrderPayments.ordpayAmountTemp = CS_0024_003C_003E8__locals0.vm.ordpayAmountTemp;
					}
					else if (!result)
					{
						wSOrderPayments.ordpayAmountTemp = CS_0024_003C_003E8__locals0.vm.ordpayAmountTemp;
					}
				}
				else
				{
					wSOrderPayments.ordpayAmountTemp = CS_0024_003C_003E8__locals0.vm.ordpayAmountTemp;
					if (UserLogin.IsUserAccess("frmOrder", "actPayNeedVerify", UserLogin.CurrentUser))
					{
						CS_0024_003C_003E8__locals0.vm.ordpayAmount = 0m;
						wSOrderPayments.ordpayAmount = 0m;
					}
				}
				wSOrderPayments.ordpayIsVerified = CS_0024_003C_003E8__locals0.vm.ordpayIsVerified;
				if (wSOrderPayments.ordpayIsVerified.HasValue && wSOrderPayments.ordpayIsVerified.GetValueOrDefault())
				{
					if (!wSOrderPayments.ordpayVerifiedRegisterDate.HasValue)
					{
						wSOrderPayments.ordpayVerifierId = UserLogin.CurrentUser.UserId;
						wSOrderPayments.ordpayVerifiedRegisterDate = now;
						wSOrderPayments.ordpayVerifiedRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						wSOrderPayments.ordpayAmount = wSOrderPayments.ordpayAmountTemp.GetValueOrDefault();
					}
				}
				else
				{
					wSOrderPayments.ordpayVerifierId = null;
					wSOrderPayments.ordpayVerifiedRegisterDate = null;
					wSOrderPayments.ordpayVerifiedRegisterDatePersian = null;
				}
				WSspSelectOrderById_Result wSspSelectOrderById_Result3 = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(wSOrderPayments.ordpayOrderId, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (wSspSelectOrderById_Result3 != null)
				{
					DateTime? dateTime2 = (wSOrderPayments.ordpayBankDocDate ?? wSOrderPayments.ordpayDocDateTime) ?? wSOrderPayments.ImportDateTime;
					if (wSspSelectOrderById_Result3.ordDateTime.HasValue && dateTime2.HasValue)
					{
						dateTime2 = DateTime.Parse(dateTime2.Value.ToString("yyyy/MM/dd"));
						DateTime dateTime3 = DateTime.Parse(wSspSelectOrderById_Result3.ordDateTime.Value.ToString("yyyy/MM/dd"));
						double totalDays = (dateTime2.Value - dateTime3).TotalDays;
						CS_0024_003C_003E8__locals0.vm.ordpayHeadingUpDay = int.Parse(System.Math.Round(totalDays).ToString());
						CS_0024_003C_003E8__locals0.vm.ordpayHeadingUpAmount = (decimal)CS_0024_003C_003E8__locals0.vm.ordpayHeadingUpDay.GetValueOrDefault() * wSOrderPayments.ordpayAmount;
					}
				}
				wSOrderPayments.ordpayHeadingUpDay = CS_0024_003C_003E8__locals0.vm.ordpayHeadingUpDay;
				wSOrderPayments.ordpayHeadingUpAmount = CS_0024_003C_003E8__locals0.vm.ordpayHeadingUpAmount;
				if (CS_0024_003C_003E8__locals0.vm.OrderPaymentId > 0)
				{
					_dbTbl.Entry(wSOrderPayments).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					Order.CalcAndSetOrderAmounts(wSOrderPayments.ordpayOrderId);
					if (!result)
					{
						using List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass6_5 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass6_5();
							CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals5.lang = enumerator.Current;
							DbSet<WSOrderPayments_Lang> wSOrderPayments_Lang5 = _dbTbl.WSOrderPayments_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSOrderPayments_Lang), "c");
							WSOrderPayments_Lang wSOrderPayments_Lang6 = Queryable.FirstOrDefault<WSOrderPayments_Lang>((IQueryable<WSOrderPayments_Lang>)wSOrderPayments_Lang5, Expression.Lambda<Func<WSOrderPayments_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals5, typeof(_003C_003Ec__DisplayClass6_5)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals5, typeof(_003C_003Ec__DisplayClass6_5)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSOrderPayments_Lang6 != null)
							{
								wSOrderPayments_Lang6.ordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
								wSOrderPayments_Lang6.ordpayBankDocDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
								wSOrderPayments_Lang6.ordpayBankDocDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
								if (!UserLogin.IsUserAccess("frmOrder", "actCanNotChangePayBankInfoInEdit", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.vm.OrderPaymentId == 0)
								{
									wSOrderPayments_Lang6.ordpayBankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
									wSOrderPayments_Lang6.ordpayBranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
								}
								_dbTbl.Entry(wSOrderPayments_Lang6).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSOrderPayments_Lang6 = new WSOrderPayments_Lang();
							wSOrderPayments_Lang6.LanguageID = CS_0024_003C_003E8__locals5.lang.LanguageID;
							wSOrderPayments_Lang6.OrderPaymentId = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.vm.OrderPaymentId;
							wSOrderPayments_Lang6.ordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
							wSOrderPayments_Lang6.ordpayBankDocDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
							wSOrderPayments_Lang6.ordpayBankDocDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
							if (!UserLogin.IsUserAccess("frmOrder", "actCanNotChangePayBankInfoInEdit", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals3.vm.OrderPaymentId == 0)
							{
								wSOrderPayments_Lang6.ordpayBankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
								wSOrderPayments_Lang6.ordpayBranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
							}
							_dbTbl.WSOrderPayments_Lang.Add(wSOrderPayments_Lang6);
							_dbTbl.SaveChanges();
						}
					}
					if (CS_0024_003C_003E8__locals0.vm.OrderPaymentId != 0)
					{
						WSspSelectOrderPaymentsWithId_Result wSspSelectOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<WSspSelectOrderPaymentsWithId_Result>((IEnumerable<WSspSelectOrderPaymentsWithId_Result>)_dbI.WSspSelectOrderPaymentsWithId(CS_0024_003C_003E8__locals0.vm.OrderPaymentId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						if (wSspSelectOrderPaymentsWithId_Result != null)
						{
							CS_0024_003C_003E8__locals0.vm.ordpayFileTypeJsonByName = wSspSelectOrderPaymentsWithId_Result.ordpayFileTypeJsonByName ?? "";
							CS_0024_003C_003E8__locals0.vm.ordpayVerifier = wSspSelectOrderPaymentsWithId_Result.ordpayVerifier ?? "";
							if (wSspSelectOrderPaymentsWithId_Result.ordpayVerifiedRegisterDate.HasValue)
							{
								CS_0024_003C_003E8__locals0.vm.ordpayVerifier = CS_0024_003C_003E8__locals0.vm.ordpayVerifier ?? "";
							}
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					wSOrderPayments.FPId = Financial.Get().Id;
					wSOrderPayments.ordpayFirstRegisterUserId = currentUser.UserId;
					wSOrderPayments.ordpayFirstRegisteDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSOrderPayments.ordpayFirstRegisteDate = now;
					wSOrderPayments.GUId = System.Guid.NewGuid();
					wSOrderPayments.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					wSOrderPayments.FirstRegisterDate = DateTime.Now;
					wSOrderPayments.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					wSOrderPayments.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					wSOrderPayments.ordpayCId = Order.GetOrdCId(wSOrderPayments.ordpayOrderId);
					_dbTbl.WSOrderPayments.Add(wSOrderPayments);
					_dbTbl.SaveChanges();
					Order.CalcAndSetOrderAmounts(wSOrderPayments.ordpayOrderId);
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSOrderPayments_Lang wSOrderPayments_Lang7 = new WSOrderPayments_Lang();
						wSOrderPayments_Lang7.LanguageID = lang.LanguageID;
						wSOrderPayments_Lang7.OrderPaymentId = wSOrderPayments.OrderPaymentId;
						wSOrderPayments_Lang7.ordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderPayments_Lang7.ordpayBankDocDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderPayments_Lang7.ordpayBankDocDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						if (!UserLogin.IsUserAccess("frmOrder", "actCanNotChangePayBankInfoInEdit", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals0.vm.OrderPaymentId == 0)
						{
							wSOrderPayments_Lang7.ordpayBankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSOrderPayments_Lang7.ordpayBranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						}
						_dbTbl.WSOrderPayments_Lang.Add(wSOrderPayments_Lang7);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.AppType = wSOrderPayments.AppType;
				CS_0024_003C_003E8__locals0.vm.UserId = wSOrderPayments.UserId;
				CS_0024_003C_003E8__locals0.vm.ordpayFirstRegisterUserId = wSOrderPayments.ordpayFirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.ordpayBankDocRegisterUserId = wSOrderPayments.ordpayBankDocRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.ordpayBankDocRegisterDate = wSOrderPayments.ordpayBankDocRegisterDate;
				CS_0024_003C_003E8__locals0.vm.ordpayBankDocRegisterDatePersian = wSOrderPayments.ordpayBankDocRegisterDatePersian;
				Order.UpdateOrderLinkAccConflictByPay(wSOrderPayments.ordpayOrderId);
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
		}
		SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
		CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.ordpayDocDate = (CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.ordpayBankDocDatePersian = (CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayBankDocDate.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.ordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.ordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	[LoginAuthorize]
	public string Delete(int id, int orderId)
	{
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.id = id;
		string result = "";
		try
		{
			DbSet<WSOrderPayments> wSOrderPayments = _dbTbl.WSOrderPayments;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderPayments), "c");
			WSOrderPayments wSOrderPayments2 = Queryable.FirstOrDefault<WSOrderPayments>((IQueryable<WSOrderPayments>)wSOrderPayments, Expression.Lambda<Func<WSOrderPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSOrderPayments2 != null)
			{
				try
				{
					if (Order.PayIsSentToLinkAccByAction(wSOrderPayments2.OrderPaymentId))
					{
						string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
						return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					}
					TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions
					{
						IsolationLevel = IsolationLevel.ReadUncommitted
					});
					using (transactionScope)
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSOrderPayments(_003C_003Ec__DisplayClass7_.id)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							Order.CalcAndSetOrderAmounts(orderId);
							result = "";
						}
						else if (mct_Result != null && mct_Result.Result == 0)
						{
							result = Messages.RedundancyMessage;
						}
						transactionScope.Complete();
					}
					Order.UpdateOrderLinkAccConflictByPay(orderId);
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
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			result = Messages.frmErrorMessage + " - " + ex2.Message;
		}
		return result;
	}

	private void FillDropdownOrdPay()
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
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectActiveOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PayTypeList = list;
	}

	[AjaxOnly]
	public JsonResult GetPayType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, CrmDroupDownItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value)), (Func<WSspSelectActiveOrderPaymentTypes_Result, CrmDroupDownItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new CrmDroupDownItem
			{
				text = item.ordpayType,
				value = item.OrderPaymentTypeId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string GetDateBefore(string date)
	{
		string result = "-1";
		try
		{
			result = PersianDate.GetInsertedDays2Date(date.Replace("-", "").Replace("/", ""), -3.0);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetBankDocRegisterUsers()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2)), (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.BankDocRegisterUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actordOrderPaymentIndicator")]
	public ActionResult Indicator(int position = 0, int cmpId = 0, string cmpName = "")
	{
		string text = "";
		string text2 = "";
		if (position == 0)
		{
			text = "frmMain";
			text2 = "actordOrderPaymentIndicator";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			OrderPaymentIndicatorViewModel model = new OrderPaymentIndicatorViewModel
			{
				OrdPayIndicatorCompanyId = cmpId.ToString(),
				OrdPayIndicatorCompanyName = cmpName,
				OrdPayIndicatorMonth = DateTime.Now.ToString("MM")
			};
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			int result = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
			}
			if (result == 1)
			{
				base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
			}
			FillDropdownOrdPayIndicator();
			GetOrderOpr();
			return View(model);
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	public JsonResult OrderPayIndicator(OrderPaymentIndicatorViewModel indicator)
	{
		JsonResult jsonResult = Json(OrderPayIndicatorItem(indicator), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public IndicatorPatmentOrderItem OrderPayIndicatorItem(OrderPaymentIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		IndicatorPatmentOrderItem indicatorPatmentOrderItem = new IndicatorPatmentOrderItem();
		List<mct_WSspSelectOrderPaymentIndicator_Result> items = new List<mct_WSspSelectOrderPaymentIndicator_Result>();
		mct_WSspSelectOrderPaymentIndicatorSum_Result itemFooter = new mct_WSspSelectOrderPaymentIndicatorSum_Result();
		indicatorPatmentOrderItem.Items = items;
		indicatorPatmentOrderItem.ItemFooter = itemFooter;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.OrdPayIndicatorMonth = ((indicator.OrdPayIndicatorMonth != null && indicator.OrdPayIndicatorMonth == "0") ? null : indicator.OrdPayIndicatorMonth);
				string text = "0";
				if (!string.IsNullOrEmpty(indicator.OrdPayIndicatorMonth) && indicator.OrdPayIndicatorMonth != "0")
				{
					text = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + indicator.OrdPayIndicatorMonth + "/01").ToString("yyyyMM", new CultureInfo("en-US"));
				}
				indicator.OrdPayIndicatorDate = ((!string.IsNullOrEmpty(indicator.OrdPayIndicatorDate)) ? indicator.OrdPayIndicatorDate.Replace("/", "") : "");
				indicator.OrdPayIndicatorFDate = ((!string.IsNullOrEmpty(indicator.OrdPayIndicatorFDate)) ? indicator.OrdPayIndicatorFDate.Replace("/", "") : "");
				indicator.OrdPayIndicatorTDate = ((!string.IsNullOrEmpty(indicator.OrdPayIndicatorTDate)) ? indicator.OrdPayIndicatorTDate.Replace("/", "") : "");
				indicator.OrdPayIndicatorMonth = (string.IsNullOrEmpty(indicator.OrdPayIndicatorMonth) ? "0" : ((lCID == 1025) ? text : (DateTime.Now.ToString("yyyy") + indicator.OrdPayIndicatorMonth)));
				indicator.OrdPayIndicatorOrderNumber = (string.IsNullOrEmpty(indicator.OrdPayIndicatorOrderNumber) ? "0" : indicator.OrdPayIndicatorOrderNumber);
				indicator.OrdPayIndicatorCompanyId = (string.IsNullOrEmpty(indicator.OrdPayIndicatorCompanyId) ? "0" : indicator.OrdPayIndicatorCompanyId);
				indicator.OrdPayIndicatorIsVerified = (string.IsNullOrEmpty(indicator.OrdPayIndicatorIsVerified) ? "0" : indicator.OrdPayIndicatorIsVerified);
				indicator.OrdPayIndicatorTypeId = (string.IsNullOrEmpty(indicator.OrdPayIndicatorTypeId) ? "0" : indicator.OrdPayIndicatorTypeId);
				if (!string.IsNullOrEmpty(indicator.OrdPayIndicatorTypeIdMulti) && indicator.OrdPayIndicatorTypeIdMulti != "0")
				{
					indicator.OrdPayIndicatorTypeId = indicator.OrdPayIndicatorTypeIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.OrdPayIndicatorFDocDate = ((!string.IsNullOrEmpty(indicator.OrdPayIndicatorFDocDate)) ? indicator.OrdPayIndicatorFDocDate.Replace("/", "") : "");
				indicator.OrdPayIndicatorTDocDate = ((!string.IsNullOrEmpty(indicator.OrdPayIndicatorTDocDate)) ? indicator.OrdPayIndicatorTDocDate.Replace("/", "") : "");
				indicator.OrdPayIndicatorDocNumber = (string.IsNullOrEmpty(indicator.OrdPayIndicatorDocNumber) ? "0" : indicator.OrdPayIndicatorDocNumber);
				indicator.OrdPayIndicatorDescription = (string.IsNullOrEmpty(indicator.OrdPayIndicatorDescription) ? "0" : indicator.OrdPayIndicatorDescription);
				indicator.OrdPayIndicatorUserId = (string.IsNullOrEmpty(indicator.OrdPayIndicatorUserId) ? "0" : indicator.OrdPayIndicatorUserId);
				indicator.OrdPayIndicatorFirstRegisterUserId = (string.IsNullOrEmpty(indicator.OrdPayIndicatorFirstRegisterUserId) ? "0" : indicator.OrdPayIndicatorFirstRegisterUserId);
				indicator.OrdPayIndicatorReferUserId = (string.IsNullOrEmpty(indicator.OrdPayIndicatorReferUserId) ? "0" : indicator.OrdPayIndicatorReferUserId);
				indicator.OrdPayIndicatorDeActive = (string.IsNullOrWhiteSpace(indicator.OrdPayIndicatorDeActive) ? "0" : indicator.OrdPayIndicatorDeActive);
				indicator.OrdPayIndicatorHaveLinkAcc = (string.IsNullOrWhiteSpace(indicator.OrdPayIndicatorHaveLinkAcc) ? "0" : indicator.OrdPayIndicatorHaveLinkAcc);
				indicator.OrdPayIndicatorIsVerified = (string.IsNullOrWhiteSpace(indicator.OrdPayIndicatorIsVerified) ? "0" : indicator.OrdPayIndicatorIsVerified);
				indicator.OrdPayIndicatorOrderOprId = (string.IsNullOrWhiteSpace(indicator.OrdPayIndicatorOrderOprId) ? "0" : indicator.OrdPayIndicatorOrderOprId);
				indicator.LinkAccSettingDBId = indicator.LinkAccSettingDBId.GetValueOrDefault();
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.OrdPayIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdPayIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdPayIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdPayIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdPayIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdPayIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdPayIndicatorFDocDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdPayIndicatorFDocDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdPayIndicatorTDocDate))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdPayIndicatorTDocDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				items = Enumerable.ToList<mct_WSspSelectOrderPaymentIndicator_Result>((IEnumerable<mct_WSspSelectOrderPaymentIndicator_Result>)_db.mfi_WSspSelectOrderPaymentIndicator(indicator.OrdPayIndicatorDate, indicator.OrdPayIndicatorFDate, indicator.OrdPayIndicatorTDate, indicator.OrdPayIndicatorMonth, indicator.OrdPayIndicatorCompanyId, indicator.OrdPayIndicatorOrderNumber, indicator.OrdPayIndicatorTypeId, indicator.OrdPayIndicatorAmount.ToString(), indicator.OrdPayIndicatorFDocDate, indicator.OrdPayIndicatorTDocDate, indicator.OrdPayIndicatorDocNumber, indicator.OrdPayIndicatorDocAmount.ToString(), indicator.OrdPayIndicatorDescription, indicator.OrdPayIndicatorFirstRegisterUserId, indicator.OrdPayIndicatorUserId, indicator.OrdPayIndicatorReferUserId, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DefineDayeOfWeekFa(dayOfWeek.ToString()), lCID, result, value, value2, value3, value4, value5, indicator.OrdPayIndicatorDeActive, haveLinkAcc: indicator.OrdPayIndicatorHaveLinkAcc, orderOprId: indicator.OrdPayIndicatorOrderOprId, linkAccSettingDBId: indicator.LinkAccSettingDBId, payIsVerified: indicator.OrdPayIndicatorIsVerified, centerId: result2));
				if (Enumerable.Any<mct_WSspSelectOrderPaymentIndicator_Result>((IEnumerable<mct_WSspSelectOrderPaymentIndicator_Result>)items))
				{
					CRMSpEntities db = _db;
					string ordPayIndicatorDate2 = indicator.OrdPayIndicatorDate;
					string ordPayIndicatorFDate2 = indicator.OrdPayIndicatorFDate;
					string ordPayIndicatorTDate2 = indicator.OrdPayIndicatorTDate;
					string ordPayIndicatorMonth2 = indicator.OrdPayIndicatorMonth;
					string ordPayIndicatorCompanyId2 = indicator.OrdPayIndicatorCompanyId;
					string ordPayIndicatorOrderNumber2 = indicator.OrdPayIndicatorOrderNumber;
					string ordPayIndicatorTypeId2 = indicator.OrdPayIndicatorTypeId;
					string payAmount2 = indicator.OrdPayIndicatorAmount.ToString();
					string ordPayIndicatorFDocDate2 = indicator.OrdPayIndicatorFDocDate;
					string ordPayIndicatorTDocDate2 = indicator.OrdPayIndicatorTDocDate;
					string ordPayIndicatorDocNumber2 = indicator.OrdPayIndicatorDocNumber;
					string docAmount2 = indicator.OrdPayIndicatorDocAmount.ToString();
					string ordPayIndicatorDescription2 = indicator.OrdPayIndicatorDescription;
					string ordPayIndicatorFirstRegisterUserId2 = indicator.OrdPayIndicatorFirstRegisterUserId;
					string ordPayIndicatorUserId2 = indicator.OrdPayIndicatorUserId;
					string ordPayIndicatorReferUserId2 = indicator.OrdPayIndicatorReferUserId;
					int? rptUserId2 = UserLogin.CurrentUser.UserId;
					string rptDate2 = DateTime.Now.ToString("yyyy/MM/dd");
					string rptDay2 = DefineDayeOfWeekFa(dayOfWeek.ToString());
					DateTime? dateTime2 = value;
					DateTime? dateTime3 = value2;
					DateTime? dateTime4 = value3;
					DateTime? dateTime5 = value4;
					DateTime? dateTime6 = value5;
					itemFooter = Enumerable.FirstOrDefault<mct_WSspSelectOrderPaymentIndicatorSum_Result>((IEnumerable<mct_WSspSelectOrderPaymentIndicatorSum_Result>)Enumerable.ToList<mct_WSspSelectOrderPaymentIndicatorSum_Result>((IEnumerable<mct_WSspSelectOrderPaymentIndicatorSum_Result>)db.mfi_WSspSelectOrderPaymentIndicatorSum(languageID: lCID, defaultLanguageID: result, dateTime: dateTime2, fDateTime: dateTime3, tDateTime: dateTime4, fDocDateTime: dateTime5, tDocDateTime: dateTime6, payDeActive: indicator.OrdPayIndicatorDeActive, haveLinkAcc: indicator.OrdPayIndicatorHaveLinkAcc, orderOprId: indicator.OrdPayIndicatorOrderOprId, linkAccSettingDBId: indicator.LinkAccSettingDBId, date: ordPayIndicatorDate2, fDate: ordPayIndicatorFDate2, tDate: ordPayIndicatorTDate2, month: ordPayIndicatorMonth2, companyID: ordPayIndicatorCompanyId2, orderNumber: ordPayIndicatorOrderNumber2, payTypeId: ordPayIndicatorTypeId2, payAmount: payAmount2, fDocDate: ordPayIndicatorFDocDate2, tDocDate: ordPayIndicatorTDocDate2, docNumber: ordPayIndicatorDocNumber2, docAmount: docAmount2, payDescription: ordPayIndicatorDescription2, firstRegisterUserId: ordPayIndicatorFirstRegisterUserId2, userId: ordPayIndicatorUserId2, ordReferUserId: ordPayIndicatorReferUserId2, rptUserId: rptUserId2, rptDate: rptDate2, rptDay: rptDay2, payIsVerified: indicator.OrdPayIndicatorIsVerified, centerId: result2)));
				}
				foreach (mct_WSspSelectOrderPaymentIndicator_Result item in items)
				{
					item.ImportDate = (item.ImportDateTime.HasValue ? item.ImportDateTime.Value.ToString("yyyyMMdd") : item.ImportDate);
					item.RegisterDatePersian = (item.RegisterDate.HasValue ? item.RegisterDate.Value.ToString("yyyyMMdd") : item.RegisterDatePersian);
					if (!string.IsNullOrEmpty(item.ordDate))
					{
						item.ordDate = PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "");
					}
					item.ordpayDocDate = (item.ordpayDocDateTime.HasValue ? item.ordpayDocDateTime.Value.ToString("yyyyMMdd") : item.ordpayDocDate);
					item.ordpayFirstRegisteDatePersian = (item.ordpayFirstRegisteDate.HasValue ? item.ordpayFirstRegisteDate.Value.ToString("yyyyMMdd") : item.ordpayFirstRegisteDatePersian);
					item.ordpayBankDocDatePersian = (item.ordpayBankDocDate.HasValue ? item.ordpayBankDocDate.Value.ToString("yyyyMMdd") : "");
					item.ordpayBankDocRegisterDatePersian = (item.ordpayBankDocRegisterDate.HasValue ? item.ordpayBankDocRegisterDate.Value.ToString("yyyyMMdd") : "");
					item.ordpayVerifiedRegisterDatePersian = (item.ordpayVerifiedRegisterDate.HasValue ? item.ordpayVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm;ss") : "");
					item.ordpayDocDateTemp = (item.ordpayDocDateTimeTemp.HasValue ? item.ordpayDocDateTimeTemp.Value.ToString("yyyyMMdd") : item.ordpayDocDateTemp);
				}
				indicatorPatmentOrderItem.Items = items;
				indicatorPatmentOrderItem.ItemFooter = itemFooter;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return indicatorPatmentOrderItem;
	}

	public string DefineDayeOfWeekFa(string day)
	{
		return day switch
		{
			"Saturday" => Labels.Saturday, 
			"Sunday" => Labels.Sunday, 
			"Monday" => Labels.Monday, 
			"Tuesday" => Labels.Tuesday, 
			"Wednesday" => Labels.Wednesday, 
			"Thursday" => Labels.Thursday, 
			"Friday" => Labels.Friday, 
			_ => day, 
		};
	}

	private void FillDropdownOrdPayIndicator()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectOrderReferUsers_Result> list = Enumerable.ToList<WSspSelectOrderReferUsers_Result>((IEnumerable<WSspSelectOrderReferUsers_Result>)_db.WSspSelectOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list2.AddRange(Enumerable.Select<WSspSelectOrderReferUsers_Result, SelectListItem>((IEnumerable<WSspSelectOrderReferUsers_Result>)list, (Func<WSspSelectOrderReferUsers_Result, SelectListItem>)((WSspSelectOrderReferUsers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
			base.ViewBag.UserList = list2;
			List<WSspSelectOrderPaymentTypes_Result> list3 = Enumerable.ToList<WSspSelectOrderPaymentTypes_Result>((IEnumerable<WSspSelectOrderPaymentTypes_Result>)_db.WSspSelectOrderPaymentTypes(lCID, result, value));
			List<SelectListItem> list4 = new List<SelectListItem>();
			list4.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list4.AddRange(Enumerable.Select<WSspSelectOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectOrderPaymentTypes_Result>)list3, (Func<WSspSelectOrderPaymentTypes_Result, SelectListItem>)((WSspSelectOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString(),
				Selected = false
			})));
			base.ViewBag.TypeList = list4;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	public JsonResult GetOrdPayCompany(string value = "")
	{
		List<WSspOrderPaymentIndicatorCmpSearch_Result> data = new List<WSspOrderPaymentIndicatorCmpSearch_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			data = Enumerable.ToList<WSspOrderPaymentIndicatorCmpSearch_Result>((IEnumerable<WSspOrderPaymentIndicatorCmpSearch_Result>)_db.WSspOrderPaymentIndicatorCmpSearch(value, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPayTypeIndicator()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectOrderPaymentTypes_Result>((IEnumerable<WSspSelectOrderPaymentTypes_Result>)_db.WSspSelectOrderPaymentTypes(lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectOrderPaymentTypes_Result, CrmDroupDownItem>((IEnumerable<WSspSelectOrderPaymentTypes_Result>)list2, (Func<WSspSelectOrderPaymentTypes_Result, CrmDroupDownItem>)((WSspSelectOrderPaymentTypes_Result item) => new CrmDroupDownItem
			{
				text = item.ordpayType,
				value = item.OrderPaymentTypeId.ToString()
			})));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		base.ViewBag.TypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		List<WSspSelectOrderReferUsers_Result> list = Enumerable.ToList<WSspSelectOrderReferUsers_Result>((IEnumerable<WSspSelectOrderReferUsers_Result>)_db.WSspSelectOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
		List<CrmDroupDownItem> list2 = new List<CrmDroupDownItem>();
		list2.AddRange(Enumerable.Select<WSspSelectOrderReferUsers_Result, CrmDroupDownItem>((IEnumerable<WSspSelectOrderReferUsers_Result>)list, (Func<WSspSelectOrderReferUsers_Result, CrmDroupDownItem>)((WSspSelectOrderReferUsers_Result item) => new CrmDroupDownItem
		{
			text = item.UserName,
			value = item.UserId.ToString()
		})));
		base.ViewBag.UserList = list2;
		return Json(list2, JsonRequestBehavior.AllowGet);
	}

	public ActionResult OrderPayIndicator_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		OrderPaymentIndicatorViewModel indicator2 = new JavaScriptSerializer().Deserialize<OrderPaymentIndicatorViewModel>(indicator);
		IndicatorPatmentOrderItem indicatorPatmentOrderItem = OrderPayIndicatorItem(indicator2);
		JsonResult jsonResult = Json(((IEnumerable)indicatorPatmentOrderItem.Items).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetOrderOpr()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public void SetRegisterInfo(WSOrderPaymentsLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (model.OrderPaymentId > 0)
			{
				List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(model.ordpayFirstRegisterUserId.GetValueOrDefault() + "," + model.UserId + "," + model.ordpayBankDocRegisterUserId.GetValueOrDefault());
				if (list != null)
				{
					if (model.ordpayFirstRegisterUserId == currentUser.UserId)
					{
						text = currentUser.FullName;
					}
					else
					{
						CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.ordpayFirstRegisterUserId));
						if (cRMspSelectUsersByIds_Result != null)
						{
							text = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
						}
					}
					if (model.UserId == currentUser.UserId)
					{
						text2 = currentUser.FullName;
					}
					else
					{
						CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
						if (cRMspSelectUsersByIds_Result2 != null)
						{
							text2 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
						}
					}
					if (model.ordpayBankDocRegisterUserId.GetValueOrDefault() != 0)
					{
						if (model.ordpayBankDocRegisterUserId.GetValueOrDefault() == currentUser.UserId)
						{
							text4 = currentUser.FullName;
						}
						else
						{
							CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result3 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.ordpayBankDocRegisterUserId.GetValueOrDefault()));
							if (cRMspSelectUsersByIds_Result3 != null)
							{
								text4 = ((cRMspSelectUsersByIds_Result3 != null) ? (cRMspSelectUsersByIds_Result3.LName + ((cRMspSelectUsersByIds_Result3.FName != null) ? (" " + cRMspSelectUsersByIds_Result3.FName) : "")) : "");
							}
						}
					}
				}
				if (string.IsNullOrEmpty(model.AppType))
				{
					model.AppType = Configuration.AppType;
				}
				text3 = Configuration.GetAppType(model.AppType);
			}
			else
			{
				text = currentUser.FullName;
				text2 = "";
				text3 = Configuration.GetAppType(Configuration.AppType);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.RegisterUser = text2;
		base.ViewBag.FirstRegisterUser = text;
		base.ViewBag.AppTypeHelp = text3;
		base.ViewBag.RegUserBankDocInfo = text4;
	}

	[AjaxOnly]
	public string GetCompanyMoneyBagRemain(int cmpId)
	{
		string result = "-1";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			result = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)_dbI.CRMspReturnCompanyMoneyBagRemain(cmpId, result2)).GetValueOrDefault().ToString();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetPayTypeInfo(int payTypeId = 0)
	{
		WSspSelectOrderPaymentTypesById_Result wSspSelectOrderPaymentTypesById_Result = new WSspSelectOrderPaymentTypesById_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			wSspSelectOrderPaymentTypesById_Result = Enumerable.FirstOrDefault<WSspSelectOrderPaymentTypesById_Result>((IEnumerable<WSspSelectOrderPaymentTypesById_Result>)_dbI.WSspSelectOrderPaymentTypesById(payTypeId, lCID, result));
			if (wSspSelectOrderPaymentTypesById_Result == null)
			{
				wSspSelectOrderPaymentTypesById_Result = new WSspSelectOrderPaymentTypesById_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		wSspSelectOrderPaymentTypesById_Result.ordPayTypePosPassword = ((!string.IsNullOrEmpty(wSspSelectOrderPaymentTypesById_Result.ordPayTypePosPassword)) ? XorCipher.DecryptByPrivateKey(wSspSelectOrderPaymentTypesById_Result.ordPayTypePosPassword) : null);
		JsonResult jsonResult = Json(wSspSelectOrderPaymentTypesById_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string PaymentVerify(int payId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmOrder", "actVerifyPayOrder", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_dbII.WSspOrderPaymentVerify(payId, userId, now, registerDatePersian);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string PaymentVerifyExit(int payId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmOrder", "actExitVerifyPayOrder", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbII.WSspOrderPaymentVerifyExit(payId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string PaymentCanceled(int payId, string regDate)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmOrder", "actCanceledPay", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = currentUser.UserId;
			string text = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			DateTime dateTime = default(DateTime);
			string text2 = "";
			DateTime value;
			try
			{
				if (string.IsNullOrWhiteSpace(regDate))
				{
					return string.Format(Messages.msgErrorIsNotEnteredItem, Labels.Date);
				}
				text2 = PersianDate.GetFormatetdDate(regDate.Replace("/", ""));
				value = lCID switch
				{
					1065 => DateTime.Parse(text2, new PersianCulture()), 
					1025 => DateTime.Parse(text2, new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(text2, new CultureInfo("en-US")), 
				};
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				return string.Format(Messages.ErrorInFormat, Labels.Date);
			}
			text = value.ToString("yyyyMMdd", new PersianCulture());
			_dbIII.WSspOrderPaymentDeActive(payId, userId, value, text);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string PaymentExitCanceled(int payId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmOrder", "actExitCanceledPay", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbIII.WSspOrderPaymentDeActiveExit(payId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[HttpPost]
	public JsonResult ActRegisterpayBankDocNumber(string parameters)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			if (!string.IsNullOrWhiteSpace(parameters))
			{
				_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass29_0();
				CS_0024_003C_003E8__locals1.model = new JavaScriptSerializer().Deserialize<WSOrderPaymentsLanguageViewModel>(parameters);
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals1.defLangID);
				if (CS_0024_003C_003E8__locals1.defLangID <= 0)
				{
					CS_0024_003C_003E8__locals1.defLangID = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string ordpayBankDocRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				now.ToString("HH:mm:ss");
				DateTime dateTime = default(DateTime);
				string text3 = "";
				string text4 = "";
				int num = 0;
				if (!UserLogin.IsUserAccess("frmOrderPaymentIndicator", "actRegisterpayBankDocNumber", UserLogin.CurrentUser))
				{
					text4 = text4 + Messages.ErrorNotAccess + "<br>";
					num++;
				}
				if (CS_0024_003C_003E8__locals1.model.OrderPaymentId == 0)
				{
					text4 = text4 + Messages.ErrorNotFound + "<br>";
					num++;
				}
				if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.model.ordpayBankDocNumber))
				{
					text4 = text4 + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.OrdPayIndicatorRegBankDocNumber) + "<br>";
					num++;
				}
				if (CS_0024_003C_003E8__locals1.model.ordpayBankDocAmount.GetValueOrDefault() == 0m)
				{
					text4 = text4 + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.OrdPayIndicatorRegBankDocAmount) + "<br>";
					num++;
				}
				if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.model.ordpayBankDocDatePersian))
				{
					text4 = text4 + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.OrdPayIndicatorRegBankDocDate) + "<br>";
					num++;
				}
				else
				{
					try
					{
						CS_0024_003C_003E8__locals1.model.ordpayBankDocDatePersian = CS_0024_003C_003E8__locals1.model.ordpayBankDocDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
						text3 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals1.model.ordpayBankDocDatePersian.Replace("/", ""));
						text3 = text3 + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text3, new PersianCulture());
							CS_0024_003C_003E8__locals1.model.ordpayBankDocDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text3, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals1.model.ordpayBankDocDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text3, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals1.model.ordpayBankDocDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals1.model.ordpayBankDocDate = dateTime;
					}
					catch (Exception)
					{
						text4 = text4 + string.Format(Messages.ErrorInFormat, Labels.OrdPayIndicatorRegBankDocDate) + "<br>";
						num++;
					}
				}
				if (num == 0)
				{
					_003C_003Ec__DisplayClass29_1 _003C_003Ec__DisplayClass29_ = new _003C_003Ec__DisplayClass29_1();
					List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.model.ordpayBankDocDesc_Lang))
					{
						list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals1.model.ordpayBankDocDesc_Lang);
					}
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals1.model.ordpayBankDocDesc,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.model.ordpayBankDocDescI_Lang))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals1.model.ordpayBankDocDescI_Lang);
					}
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals1.model.ordpayBankDocDescI,
						LanguageId = lCID
					});
					DbSet<WSOrderPayments> wSOrderPayments = _dbTbl.WSOrderPayments;
					ParameterExpression val = Expression.Parameter(typeof(WSOrderPayments), "c");
					_003C_003Ec__DisplayClass29_.modelPay = Queryable.FirstOrDefault<WSOrderPayments>((IQueryable<WSOrderPayments>)wSOrderPayments, Expression.Lambda<Func<WSOrderPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass29_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (_003C_003Ec__DisplayClass29_.modelPay != null)
					{
						_003C_003Ec__DisplayClass29_.modelPay.AppType = appType;
						_003C_003Ec__DisplayClass29_.modelPay.ordpayBankDocRegisterUserId = userId;
						_003C_003Ec__DisplayClass29_.modelPay.ordpayBankDocRegisterDate = value;
						_003C_003Ec__DisplayClass29_.modelPay.ordpayBankDocRegisterDatePersian = ordpayBankDocRegisterDatePersian;
						_003C_003Ec__DisplayClass29_.modelPay.ordpayBankDocNumber = CS_0024_003C_003E8__locals1.model.ordpayBankDocNumber;
						_003C_003Ec__DisplayClass29_.modelPay.ordpayBankDocDate = CS_0024_003C_003E8__locals1.model.ordpayBankDocDate;
						_003C_003Ec__DisplayClass29_.modelPay.ordpayBankDocDatePersian = CS_0024_003C_003E8__locals1.model.ordpayBankDocDatePersian;
						_003C_003Ec__DisplayClass29_.modelPay.ordpayBankDocAmount = CS_0024_003C_003E8__locals1.model.ordpayBankDocAmount;
						if (lCID == CS_0024_003C_003E8__locals1.defLangID)
						{
							_003C_003Ec__DisplayClass29_.modelPay.ordpayBankDocDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.defLangID)).Value : null);
							_003C_003Ec__DisplayClass29_.modelPay.ordpayBankDocDescI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.defLangID)).Value : null);
						}
						_dbTbl.Entry(_003C_003Ec__DisplayClass29_.modelPay).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						Order.CalcAndSetOrderAmounts(_003C_003Ec__DisplayClass29_.modelPay.ordpayOrderId);
						Order.UpdateOrderLinkAccConflictByPay(_003C_003Ec__DisplayClass29_.modelPay.ordpayOrderId);
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals1.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass29_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass29_2();
								CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass29_;
								CS_0024_003C_003E8__locals0.lang = enumerator.Current;
								if (lCID != CS_0024_003C_003E8__locals0.lang.LanguageID)
								{
									continue;
								}
								DbSet<WSOrderPayments_Lang> wSOrderPayments_Lang = _dbTbl.WSOrderPayments_Lang;
								val = Expression.Parameter(typeof(WSOrderPayments_Lang), "c");
								WSOrderPayments_Lang wSOrderPayments_Lang2 = Queryable.FirstOrDefault<WSOrderPayments_Lang>((IQueryable<WSOrderPayments_Lang>)wSOrderPayments_Lang, Expression.Lambda<Func<WSOrderPayments_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass29_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass29_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSOrderPayments_Lang2 != null)
								{
									wSOrderPayments_Lang2.ordpayBankDocDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null);
									wSOrderPayments_Lang2.ordpayBankDocDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSOrderPayments_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSOrderPayments_Lang2 = new WSOrderPayments_Lang();
								wSOrderPayments_Lang2.LanguageID = CS_0024_003C_003E8__locals0.lang.LanguageID;
								wSOrderPayments_Lang2.OrderPaymentId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modelPay.OrderPaymentId;
								wSOrderPayments_Lang2.ordpayBankDocDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null);
								wSOrderPayments_Lang2.ordpayBankDocDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null);
								_dbTbl.WSOrderPayments_Lang.Add(wSOrderPayments_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						text = "1";
						text2 = Messages.msgSuccessAction;
						commonResultStatusViewModel = CommonResultStatusViewModel.Success;
					}
					else
					{
						text = "";
						text2 = Messages.ErrorNotFound;
						commonResultStatusViewModel = CommonResultStatusViewModel.Error;
					}
				}
				else
				{
					text = "";
					text2 = text4;
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				text = "";
				text2 = Messages.ErrorNotFound;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string CalcPayDocDayTemp(DateTime? dt = null, string selectedDate = null, int inc = 0, int mode = 1)
	{
		new List<SelectListItem>();
		DateTime dt2 = dt ?? DateTime.Now;
		DateTime dtI = DateTimeClass.GetDateFromPersian(selectedDate) ?? DateTime.Now;
		try
		{
			switch (mode)
			{
			case 1:
				dtI = dt2.AddDays(inc);
				break;
			case 2:
				inc = (int)(dtI.Date - dt2.Date).TotalDays;
				break;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(new
		{
			dt = dt2,
			dtPer = dt2.ToString("yyyy/MM/dd"),
			dtI = dtI,
			dtIPer = dtI.ToString("yyyy/MM/dd"),
			inc = inc
		});
	}

	[AjaxOnly]
	public JsonResult GetTspPayments()
	{
		return new OrderPaymentTypeController().GetTspPmt();
	}

	[AjaxOnly]
	public JsonResult GetBankingBankLists()
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
			List<CRMspSelectBankingBanks_Result> list2 = Enumerable.ToList<CRMspSelectBankingBanks_Result>((IEnumerable<CRMspSelectBankingBanks_Result>)_dbI.CRMspSelectBankingBanks(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = ""
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<CRMspSelectBankingBanks_Result, SelectListItem>((IEnumerable<CRMspSelectBankingBanks_Result>)list2, (Func<CRMspSelectBankingBanks_Result, SelectListItem>)((CRMspSelectBankingBanks_Result item) => new SelectListItem
			{
				Text = (item.BankName ?? ""),
				Value = item.BankingBankID.ToString(),
				Selected = false
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

	[AjaxOnly]
	public JsonResult GetBankingBrancheLists(int bankId = 0)
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
			if (bankId != 0)
			{
				List<CRMspSelectBankingBranches_Result> list2 = Enumerable.ToList<CRMspSelectBankingBranches_Result>((IEnumerable<CRMspSelectBankingBranches_Result>)_dbI.CRMspSelectBankingBranches(bankId, lCID, result));
				SelectListItem item2 = new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = ""
				};
				list.Add(item2);
				list.AddRange(Enumerable.Select<CRMspSelectBankingBranches_Result, SelectListItem>((IEnumerable<CRMspSelectBankingBranches_Result>)list2, (Func<CRMspSelectBankingBranches_Result, SelectListItem>)((CRMspSelectBankingBranches_Result item) => new SelectListItem
				{
					Text = (item.BranchName ?? ""),
					Value = item.BankingBranchID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetBankingAccountLists(int branchId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectBankingAccountsByBranchAndUserId_Result> list = new List<CRMspSelectBankingAccountsByBranchAndUserId_Result>();
		try
		{
			List<CRMspSelectBankingAccountsByBranchAndUserId_Result> list2 = Enumerable.ToList<CRMspSelectBankingAccountsByBranchAndUserId_Result>((IEnumerable<CRMspSelectBankingAccountsByBranchAndUserId_Result>)_dbII.CRMspSelectBankingAccountsByBranchAndUserId(0, 0, lCID, result));
			CRMspSelectBankingAccountsByBranchAndUserId_Result item = new CRMspSelectBankingAccountsByBranchAndUserId_Result
			{
				AccountTitle = Labels.SelectedListDefValue,
				BankingAccountID = 0,
				BankName = "",
				BranchName = "",
				AccountDesc = ""
			};
			list.Add(item);
			if (list2 != null && Enumerable.Any<CRMspSelectBankingAccountsByBranchAndUserId_Result>((IEnumerable<CRMspSelectBankingAccountsByBranchAndUserId_Result>)list2))
			{
				foreach (CRMspSelectBankingAccountsByBranchAndUserId_Result item2 in list2)
				{
					item2.AccountDesc = ((!string.IsNullOrWhiteSpace(item2.AccountTitle)) ? item2.AccountTitle : "") + "/" + ((!string.IsNullOrWhiteSpace(item2.AccountTitle)) ? item2.BranchName : "") + "/" + ((!string.IsNullOrWhiteSpace(item2.AccountTitle)) ? item2.BankName : "");
				}
				list.AddRange(list2);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCashLists()
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
			List<CRMspSelectCashes_Result> list2 = Enumerable.ToList<CRMspSelectCashes_Result>((IEnumerable<CRMspSelectCashes_Result>)_dbII.CRMspSelectCashes(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = ""
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<CRMspSelectCashes_Result, SelectListItem>((IEnumerable<CRMspSelectCashes_Result>)list2, (Func<CRMspSelectCashes_Result, SelectListItem>)((CRMspSelectCashes_Result item) => new SelectListItem
			{
				Text = (item.CashTitle ?? ""),
				Value = item.CashId.ToString(),
				Selected = false
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

	[AjaxOnly]
	public JsonResult GetOrderPaymentGroupsILists()
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
			List<WSspSelectOrderPaymentGroupsI_Result> list2 = Enumerable.ToList<WSspSelectOrderPaymentGroupsI_Result>((IEnumerable<WSspSelectOrderPaymentGroupsI_Result>)_dbII.WSspSelectOrderPaymentGroupsI(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = ""
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<WSspSelectOrderPaymentGroupsI_Result, SelectListItem>((IEnumerable<WSspSelectOrderPaymentGroupsI_Result>)list2, (Func<WSspSelectOrderPaymentGroupsI_Result, SelectListItem>)((WSspSelectOrderPaymentGroupsI_Result item) => new SelectListItem
			{
				Text = (item.ordpayGroupIName ?? ""),
				Value = item.OrderPaymentGroupIId.ToString(),
				Selected = false
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

	[AjaxOnly]
	public JsonResult GetOrderPaymentGroupsIILists()
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
			List<WSspSelectOrderPaymentGroupsII_Result> list2 = Enumerable.ToList<WSspSelectOrderPaymentGroupsII_Result>((IEnumerable<WSspSelectOrderPaymentGroupsII_Result>)_dbII.WSspSelectOrderPaymentGroupsII(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = ""
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<WSspSelectOrderPaymentGroupsII_Result, SelectListItem>((IEnumerable<WSspSelectOrderPaymentGroupsII_Result>)list2, (Func<WSspSelectOrderPaymentGroupsII_Result, SelectListItem>)((WSspSelectOrderPaymentGroupsII_Result item) => new SelectListItem
			{
				Text = (item.ordpayGroupIIName ?? ""),
				Value = item.OrderPaymentGroupIIId.ToString(),
				Selected = false
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
		_dbI.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
