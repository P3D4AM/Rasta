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
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.General.Utilities;
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

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class PaymentController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int pordPayId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public WSPreOrderPaymentsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__17;

		public Func<Languages, bool> _003C_003E9__31;

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel m)
		{
			return m.LanguageId != defLangID;
		}

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

		internal bool _003CInsertEdit_003Eb__17(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__31(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

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
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	public ActionResult _PartialPrePaid(int preOrderId)
	{
		base.ViewBag.preOrderId = preOrderId;
		return PartialView();
	}

	public ActionResult _PartialPrePaid_Read([DataSourceRequest] DataSourceRequest request, int preOrderId)
	{
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectPreOrderPayments_Result> list = Enumerable.ToList<WSspSelectPreOrderPayments_Result>((IEnumerable<WSspSelectPreOrderPayments_Result>)_db.WSspSelectPreOrderPayments(preOrderId, lCID, result));
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int num = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
		}
		List<CRMspSelectLinkAccSettingDBIsActive_Result> list2 = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
		if (num == 1)
		{
			list2 = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
		}
		foreach (WSspSelectPreOrderPayments_Result item in list)
		{
			DateTime now = DateTime.Now;
			if (item.ImportDateTime.HasValue)
			{
				item.ImportDate = DateTime.Parse(item.ImportDateTime.ToString()).ToString("yyyy/MM/dd");
			}
			else if (!string.IsNullOrEmpty(item.ImportDate))
			{
				item.ImportDate = PersianDate.GetFormatetdDate(item.ImportDate);
			}
			if (item.pordpayDocDateTime.HasValue)
			{
				item.pordpayDocDate = DateTime.Parse(item.pordpayDocDateTime.ToString()).ToString("yyyy/MM/dd");
			}
			else if (!string.IsNullOrEmpty(item.pordpayDocDate))
			{
				item.pordpayDocDate = PersianDate.GetFormatetdDate(item.pordpayDocDate);
			}
			if (item.pordpayLinkAccHeaderId.HasValue || item.pordpayLinkAccDetailId.HasValue || !string.IsNullOrWhiteSpace(item.pordpayLinkAccHeaderNumber) || !string.IsNullOrWhiteSpace(item.pordpayLinkAccVoucherNumber))
			{
				string text = "";
				if (!string.IsNullOrWhiteSpace(item.pordpayLinkAccHeaderNumber))
				{
					text += string.Format(Labels.PordPayListAccLinkHeaderNumber, item.pordpayLinkAccHeaderNumber);
				}
				if (!string.IsNullOrWhiteSpace(item.pordpayLinkAccVoucherNumber))
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += ", ";
					}
					text += string.Format(Labels.PordPayListAccLinkVoucherNumber, item.pordpayLinkAccVoucherNumber);
				}
				if (item.pordpayLinkAccDetailId.HasValue)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += ", ";
					}
					text += string.Format(Labels.PordPayListAccLinkDetailId, item.pordpayLinkAccDetailId.ToString());
				}
				if (!string.IsNullOrWhiteSpace(item.pordpayLinkAccPayType) && item.pordpayLinkAccPayType == "ord")
				{
					text = text + " (" + "lblOrd".OrderLabels() + ")";
				}
				item.pordpayLinkAccHeaderNumber = text;
			}
			bool result2 = false;
			bool.TryParse(item.pordpayIsVerified.ToString(), out result2);
			if (result2)
			{
				item.pordpayVerifier += (item.pordpayVerifiedRegisterDate.HasValue ? (" (<span class='dt-verify'>" + item.pordpayVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>)") : "");
				if (!string.IsNullOrWhiteSpace(item.pordpayVerifier))
				{
					item.pordpayVerifier = Labels.lblPayVerified + "(" + item.pordpayVerifier + ")";
				}
			}
			item.pordpayDocDateTemp = (item.pordpayDocDateTimeTemp.HasValue ? item.pordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
			item.pordpayDeActiveDatePersian = (item.pordpayDeActiveDate.HasValue ? item.pordpayDeActiveDate.Value.ToString("yyyy/MM/dd") : "");
			bool result3 = false;
			bool.TryParse(item.pordpayDeActive.ToString(), out result3);
			if (result3)
			{
				item.pordpayDeActiveUser += (item.pordpayDeActiveDate.HasValue ? (" (<span class='dt-deactive'>" + item.pordpayDeActiveDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>)") : "");
				if (!string.IsNullOrWhiteSpace(item.pordpayDeActiveUser))
				{
					item.pordpayDeActiveUser = Labels.lblPayDeActive + "(" + item.pordpayDeActiveUser + ")";
				}
			}
			if (num != 1)
			{
				continue;
			}
			List<PayLinkAccDataViewModel> list3 = new List<PayLinkAccDataViewModel>();
			if (!string.IsNullOrWhiteSpace(item.pordpayLinkAccData))
			{
				foreach (PayLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item.pordpayLinkAccData))
				{
					int dbId = 0;
					int.TryParse(item2.DBId.ToString(), out dbId);
					if (dbId == 0 || list2 == null || !Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list2))
					{
						continue;
					}
					CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list2, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == dbId));
					if (cRMspSelectLinkAccSettingDBIsActive_Result == null)
					{
						continue;
					}
					item2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
					item2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
					string text2 = "";
					if (!string.IsNullOrWhiteSpace(item2.Number) && (item2.Number ?? "0") != "0")
					{
						text2 += string.Format(Labels.PordPayListAccLinkHeaderNumber, item2.Number);
					}
					if (!string.IsNullOrWhiteSpace(item2.VoucherNumber) && (item2.VoucherNumber ?? "0") != "0")
					{
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 += ", ";
						}
						text2 += string.Format(Labels.PordPayListAccLinkVoucherNumber, item2.VoucherNumber);
					}
					if (!string.IsNullOrWhiteSpace(item2.DetailId) && (item2.DetailId ?? "0") != "0")
					{
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 += ", ";
						}
						text2 += string.Format(Labels.PordPayListAccLinkDetailId, item2.DetailId);
					}
					if (!string.IsNullOrWhiteSpace(item2.RefundNum) && (item2.RefundNum ?? "0") != "0")
					{
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 += ", ";
						}
						text2 += string.Format(Labels.PordPayListAccLinkRefundNum, item2.RefundNum);
					}
					if (!string.IsNullOrWhiteSpace(item2.RefundVoucherNum) && (item2.RefundVoucherNum ?? "0") != "0")
					{
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 += ", ";
						}
						text2 += string.Format(Labels.PordPayListAccLinkRefundVoucherNum, item2.RefundVoucherNum);
					}
					if (!string.IsNullOrWhiteSpace(item2.Type) && item2.Type == "ord")
					{
						text2 = text2 + " (" + "lblOrd".OrderLabels() + ")";
					}
					if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(item2.DbTitle))
					{
						text2 = text2 + " (" + item2.DbTitle + ")";
					}
					item2.PayInfoWithLbl = text2;
					list3.Add(item2);
				}
			}
			item.pordpayLinkAccData = "";
			if (list3 != null && Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list3))
			{
				item.pordpayLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list3));
			}
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[LoginAuthorize]
	public ActionResult InsertEdit(int pordPayId, int? pordId = null, bool modeVerify = false, string pordDate = "")
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.pordPayId = pordPayId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSPreOrderPaymentsLanguageViewModel wSPreOrderPaymentsLanguageViewModel = new WSPreOrderPaymentsLanguageViewModel();
		if (pordId.HasValue && pordId > 0)
		{
			wSPreOrderPaymentsLanguageViewModel = new WSPreOrderPaymentsLanguageViewModel();
			wSPreOrderPaymentsLanguageViewModel.pordpayPreOrderId = Convert.ToInt32(pordId);
		}
		else
		{
			DbSet<WSPreOrderPayments_Lang> wSPreOrderPayments_Lang = _dbTbl.WSPreOrderPayments_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrderPayments_Lang), "c");
			List<WSPreOrderPayments_Lang> list = Enumerable.ToList<WSPreOrderPayments_Lang>((IEnumerable<WSPreOrderPayments_Lang>)Queryable.Where<WSPreOrderPayments_Lang>((IQueryable<WSPreOrderPayments_Lang>)wSPreOrderPayments_Lang, Expression.Lambda<Func<WSPreOrderPayments_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			WSPreOrderPayments wSPreOrderPayments = _dbTbl.WSPreOrderPayments.Find(CS_0024_003C_003E8__locals0.pordPayId) ?? new WSPreOrderPayments();
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderPayments_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderPayments_Lang>)list, (Func<WSPreOrderPayments_Lang, CommonMultiLanguageViewModel>)((WSPreOrderPayments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordpayDescription,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderPayments.pordpayDescription,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderPayments_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderPayments_Lang>)list, (Func<WSPreOrderPayments_Lang, CommonMultiLanguageViewModel>)((WSPreOrderPayments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordpayBankName,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderPayments.pordpayBankName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderPayments_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderPayments_Lang>)list, (Func<WSPreOrderPayments_Lang, CommonMultiLanguageViewModel>)((WSPreOrderPayments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordpayBranchName,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderPayments.pordpayBranchName,
				LanguageId = result
			});
			string pordpayFileTypeJsonByName = "";
			string text = "";
			string payFilesJsonByName = "";
			if (CS_0024_003C_003E8__locals0.pordPayId != 0)
			{
				WSspSelectPreOrderPaymentsWithId_Result wSspSelectPreOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderPaymentsWithId_Result>((IEnumerable<WSspSelectPreOrderPaymentsWithId_Result>)_dbI.WSspSelectPreOrderPaymentsWithId(CS_0024_003C_003E8__locals0.pordPayId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (wSspSelectPreOrderPaymentsWithId_Result != null)
				{
					pordpayFileTypeJsonByName = wSspSelectPreOrderPaymentsWithId_Result.pordpayFileTypeJsonByName ?? "";
					text = wSspSelectPreOrderPaymentsWithId_Result.pordpayVerifier ?? "";
					if (wSspSelectPreOrderPaymentsWithId_Result.pordpayVerifiedRegisterDate.HasValue)
					{
						text = text ?? "";
					}
					if (modeVerify)
					{
						int result2 = 0;
						int.TryParse(wSspSelectPreOrderPaymentsWithId_Result.pordpayPreOrderId.ToString(), out result2);
						int result3 = 0;
						int.TryParse(wSspSelectPreOrderPaymentsWithId_Result.PreOrderPaymentId.ToString(), out result3);
						if (result2 != 0 && result3 != 0)
						{
							List<CRMspSelectFilesDirectory_Result> list5 = Files.SelectFilesDirectory("", "", "", "10", result2.ToString(), result3.ToString(), "0", false);
							if (list5 != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list5))
							{
								List<CommonMultiAndIdLanguageViewModel> list6 = new List<CommonMultiAndIdLanguageViewModel>();
								foreach (CRMspSelectFilesDirectory_Result item3 in list5)
								{
									CommonMultiAndIdLanguageViewModel item2 = new CommonMultiAndIdLanguageViewModel
									{
										Id = item3.FileDirectoryID,
										Value = (item3.Title ?? "")
									};
									list6.Add(item2);
								}
								if (list6 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list6))
								{
									payFilesJsonByName = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list6));
								}
							}
						}
					}
				}
			}
			WSPreOrderPaymentsLanguageViewModel obj = new WSPreOrderPaymentsLanguageViewModel
			{
				LanguageID = wSPreOrderPayments.LanguageID,
				UserId = wSPreOrderPayments.UserId,
				FirstRegisterUserId = wSPreOrderPayments.FirstRegisterUserId,
				AppType = wSPreOrderPayments.AppType,
				FirstRegisterDate = wSPreOrderPayments.FirstRegisterDate,
				FirstRegisterDatePersian = wSPreOrderPayments.FirstRegisterDatePersian,
				GUId = wSPreOrderPayments.GUId,
				RegisterDate = wSPreOrderPayments.RegisterDate,
				Month1 = wSPreOrderPayments.Month1
			};
			_ = wSPreOrderPayments.RegisterDate;
			obj.RegisterDatePersian = wSPreOrderPayments.RegisterDate.ToString("yyyyMMdd");
			obj.FPId = wSPreOrderPayments.FPId;
			obj.ImportDateTime = wSPreOrderPayments.ImportDateTime;
			obj.ImportDate = (wSPreOrderPayments.ImportDateTime.HasValue ? wSPreOrderPayments.ImportDateTime.Value.ToString("yyyyMMdd") : "");
			obj.PreOrderPaymentId = wSPreOrderPayments.PreOrderPaymentId;
			obj.pordpayAmount = wSPreOrderPayments.pordpayAmount;
			obj.pordpayDocAmount = wSPreOrderPayments.pordpayDocAmount;
			obj.pordpayDocDate = (wSPreOrderPayments.pordpayDocDateTime.HasValue ? wSPreOrderPayments.pordpayDocDateTime.Value.ToString("yyyyMMdd") : "");
			obj.pordpayDocDateTime = wSPreOrderPayments.pordpayDocDateTime;
			obj.pordpayDocDateTemp = (wSPreOrderPayments.pordpayDocDateTimeTemp.HasValue ? wSPreOrderPayments.pordpayDocDateTimeTemp.Value.ToString("yyyyMMdd") : "");
			obj.pordpayDocDateTimeTemp = wSPreOrderPayments.pordpayDocDateTimeTemp;
			obj.pordpayDocId = wSPreOrderPayments.pordpayDocId;
			obj.pordpayDocNumber = wSPreOrderPayments.pordpayDocNumber;
			obj.pordpayDocTypeId = wSPreOrderPayments.pordpayDocTypeId;
			obj.pordpayFirstRegisteDate = wSPreOrderPayments.pordpayFirstRegisteDate;
			obj.pordpayFirstRegisteDatePersian = wSPreOrderPayments.FirstRegisterDatePersian;
			obj.pordpayFirstRegisterUserId = wSPreOrderPayments.pordpayFirstRegisterUserId;
			obj.pordpayPreOrderId = wSPreOrderPayments.pordpayPreOrderId;
			obj.pordpayTypeId = wSPreOrderPayments.pordpayTypeId;
			obj.pordpayDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.pordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.pordpayCompanyMoneyBagId = wSPreOrderPayments.pordpayCompanyMoneyBagId;
			obj.pordpayDeActive = wSPreOrderPayments.pordpayDeActive;
			obj.ModeVirify = modeVerify;
			obj.pordpayAmountTemp = wSPreOrderPayments.pordpayAmountTemp;
			obj.pordpayIsVerified = wSPreOrderPayments.pordpayIsVerified;
			obj.pordpayVerifierId = wSPreOrderPayments.pordpayVerifierId;
			obj.pordpayVerifier = text;
			obj.pordpayVerifiedRegisterDate = wSPreOrderPayments.pordpayVerifiedRegisterDate;
			obj.pordpayVerifiedRegisterDatePersian = wSPreOrderPayments.pordpayVerifiedRegisterDatePersian;
			obj.pordpayFileTypeJson = wSPreOrderPayments.pordpayFileTypeJson;
			obj.pordpayFileTypeJsonByName = pordpayFileTypeJsonByName;
			obj.PayFilesJsonByName = payFilesJsonByName;
			obj.pordpayAccountNumber = wSPreOrderPayments.pordpayAccountNumber;
			obj.pordpayBankingBankID = wSPreOrderPayments.pordpayBankingBankID;
			obj.pordpayBankingBranchID = wSPreOrderPayments.pordpayBankingBranchID;
			obj.pordpayBankingAccountID = wSPreOrderPayments.pordpayBankingAccountID;
			obj.pordpayCashId = wSPreOrderPayments.pordpayCashId;
			obj.pordpayGroupIdI = wSPreOrderPayments.pordpayGroupIdI;
			obj.pordpayGroupIdII = wSPreOrderPayments.pordpayGroupIdII;
			obj.pordpayChqSayadNumber = wSPreOrderPayments.pordpayChqSayadNumber;
			obj.pordpayChqSerialNumber = wSPreOrderPayments.pordpayChqSerialNumber;
			obj.pordpayDocDayTemp = wSPreOrderPayments.pordpayDocDayTemp;
			obj.pordpayBankName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.pordpayBankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.pordpayBranchName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.pordpayBranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.pordpayBranchCode = wSPreOrderPayments.pordpayBranchCode;
			obj.pordpayBankingBankID_I = wSPreOrderPayments.pordpayBankingBankID;
			wSPreOrderPaymentsLanguageViewModel = obj;
		}
		if (!wSPreOrderPaymentsLanguageViewModel.pordDateTime.HasValue)
		{
			wSPreOrderPaymentsLanguageViewModel.pordDateTime = DateTime.Now;
		}
		FillDropdownPordPay();
		SetRegisterInfo(wSPreOrderPaymentsLanguageViewModel);
		return View(wSPreOrderPaymentsLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[LoginAuthorize]
	public ActionResult InsertEdit(WSPreOrderPaymentsLanguageViewModel vm)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
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
		FillDropdownPordPay();
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordpayDescription_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordpayDescription_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.pordpayDescription,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordpayBankName_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordpayBankName_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.pordpayBankName,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordpayBranchName_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordpayBranchName_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.pordpayBranchName,
				LanguageId = lCID
			});
			try
			{
				CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
				if (CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId > 0 && PreOrder.PayIsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				if (CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId <= 0)
				{
					WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(CS_0024_003C_003E8__locals0.vm.pordpayPreOrderId, lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (wSspSelectPreOrderWithId_Result != null)
					{
						int result = 0;
						int.TryParse(wSspSelectPreOrderWithId_Result.pordStatusId.ToString(), out result);
						if (!UserLogin.IsUserAccess("frmPreOrder", "actCanInsertPayForExpirePord", UserLogin.CurrentUser) && (result == 4 || (wSspSelectPreOrderWithId_Result.pordExpireDateTime.HasValue && wSspSelectPreOrderWithId_Result.pordExpireDateTime < DateTime.Now)))
						{
							base.ViewBag.Error = Messages.msgErrorCanNotInsertPayForExpirePord;
							return View(CS_0024_003C_003E8__locals0.vm);
						}
					}
				}
				CS_0024_003C_003E8__locals0.vm.ImportDate = CS_0024_003C_003E8__locals0.vm.ImportDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				CS_0024_003C_003E8__locals0.vm.pordpayDocDate = (CS_0024_003C_003E8__locals0.vm.pordpayDocDate ?? "").Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp ?? "").Replace("/", "").Replace("-", "").Replace("_", "")
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
					CS_0024_003C_003E8__locals0.vm.pordpayDocDate = (CS_0024_003C_003E8__locals0.vm.pordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.pordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.pordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordpayDocDate))
					{
						text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.pordpayDocDate.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.pordpayDocDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.pordpayDocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.pordpayDocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.pordpayDocDateTime = dateTime;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					base.ViewBag.Error = Messages.ErrorFormatDatePersian;
					CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.pordpayDocDate = (CS_0024_003C_003E8__locals0.vm.pordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.pordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.pordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				try
				{
					if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp))
					{
						text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.pordpayDocDateTimeTemp = dateTime;
					}
					else
					{
						CS_0024_003C_003E8__locals0.vm.pordpayDocDateTimeTemp = null;
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					base.ViewBag.Error = Messages.ErrorFormatDatePersian;
					CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.pordpayDocDate = (CS_0024_003C_003E8__locals0.vm.pordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.pordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.pordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				WSPreOrderPayments wSPreOrderPayments = new WSPreOrderPayments();
				if (CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId > 0)
				{
					DbSet<WSPreOrderPayments> wSPreOrderPayments2 = _dbTbl.WSPreOrderPayments;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrderPayments), "c");
					wSPreOrderPayments = Queryable.FirstOrDefault<WSPreOrderPayments>((IQueryable<WSPreOrderPayments>)wSPreOrderPayments2, Expression.Lambda<Func<WSPreOrderPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				DateTime now = DateTime.Now;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = wSPreOrderPayments.RegisterDate;
				wSPreOrderPayments.AppType = Configuration.AppType;
				bool result2 = false;
				bool.TryParse(CS_0024_003C_003E8__locals0.vm.ModeVirify.ToString(), out result2);
				if (!result2)
				{
					wSPreOrderPayments.RegisterDate = now;
					CS_0024_003C_003E8__locals0.vm.RegisterDate = now;
					wSPreOrderPayments.UserId = currentUser.UserId;
					wSPreOrderPayments.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSPreOrderPayments.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					wSPreOrderPayments.ImportDateTime = CS_0024_003C_003E8__locals0.vm.ImportDateTime;
					wSPreOrderPayments.ImportDate = CS_0024_003C_003E8__locals0.vm.ImportDate;
					wSPreOrderPayments.PreOrderPaymentId = CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId;
					wSPreOrderPayments.pordpayAmount = CS_0024_003C_003E8__locals0.vm.pordpayAmount;
					wSPreOrderPayments.pordpayDocAmount = CS_0024_003C_003E8__locals0.vm.pordpayDocAmount;
					wSPreOrderPayments.pordpayDocDate = CS_0024_003C_003E8__locals0.vm.pordpayDocDate;
					wSPreOrderPayments.pordpayDocDateTime = CS_0024_003C_003E8__locals0.vm.pordpayDocDateTime;
					if (UserLogin.IsUserAccess("frmPreOrder", "actCanEditPordPayDocDateTemp", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId == 0)
					{
						wSPreOrderPayments.pordpayDocDateTemp = CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp;
						wSPreOrderPayments.pordpayDocDateTimeTemp = CS_0024_003C_003E8__locals0.vm.pordpayDocDateTimeTemp;
						wSPreOrderPayments.pordpayDocDayTemp = CS_0024_003C_003E8__locals0.vm.pordpayDocDayTemp;
					}
					wSPreOrderPayments.pordpayDocId = CS_0024_003C_003E8__locals0.vm.pordpayDocId;
					wSPreOrderPayments.pordpayDocNumber = CS_0024_003C_003E8__locals0.vm.pordpayDocNumber;
					wSPreOrderPayments.pordpayDocTypeId = CS_0024_003C_003E8__locals0.vm.pordpayDocTypeId;
					wSPreOrderPayments.pordpayFirstRegisteDate = CS_0024_003C_003E8__locals0.vm.pordpayFirstRegisteDate;
					wSPreOrderPayments.pordpayFirstRegisteDatePersian = CS_0024_003C_003E8__locals0.vm.pordpayFirstRegisteDatePersian;
					wSPreOrderPayments.pordpayFirstRegisterUserId = CS_0024_003C_003E8__locals0.vm.pordpayFirstRegisterUserId;
					wSPreOrderPayments.pordpayPreOrderId = CS_0024_003C_003E8__locals0.vm.pordpayPreOrderId;
					int pordpayTypeId = wSPreOrderPayments.pordpayTypeId;
					if (!UserLogin.IsUserAccess("frmPreOrder", "actCanNotChangePordPayType", UserLogin.CurrentUser))
					{
						wSPreOrderPayments.pordpayTypeId = CS_0024_003C_003E8__locals0.vm.pordpayTypeId;
					}
					else if (wSPreOrderPayments.PreOrderPaymentId == 0)
					{
						wSPreOrderPayments.pordpayTypeId = CS_0024_003C_003E8__locals0.vm.pordpayTypeId;
					}
					wSPreOrderPayments.pordpayDeActive = CS_0024_003C_003E8__locals0.vm.pordpayDeActive;
					wSPreOrderPayments.pordpayCompanyMoneyBagId = CS_0024_003C_003E8__locals0.vm.pordpayCompanyMoneyBagId;
					int result3 = 0;
					int.TryParse(wSPreOrderPayments.pordpayCompanyMoneyBagId.ToString(), out result3);
					if (result3 == 0 && wSPreOrderPayments.pordpayTypeId == -10)
					{
						DateTime now2 = DateTime.Now;
						DateTime value = now2;
						string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
						short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType = Configuration.AppType;
						short value3 = short.Parse(Financial.Get().Id.ToString());
						int userId = UserLogin.CurrentUser.UserId;
						List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
						List<WSspSelectOrderPaymentTypesInLangsById_Result> list5 = Enumerable.ToList<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)_dbI.WSspSelectOrderPaymentTypesInLangsById(wSPreOrderPayments.pordpayTypeId));
						WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result2 = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(wSPreOrderPayments.pordpayPreOrderId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						foreach (Languages lang3 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
						{
							string text2 = "";
							if (list5 != null && Enumerable.Any<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)list5))
							{
								WSspSelectOrderPaymentTypesInLangsById_Result wSspSelectOrderPaymentTypesInLangsById_Result = Enumerable.FirstOrDefault<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)list5, (Func<WSspSelectOrderPaymentTypesInLangsById_Result, bool>)((WSspSelectOrderPaymentTypesInLangsById_Result m) => m.LanguageID == lang3.LanguageID));
								if (wSspSelectOrderPaymentTypesInLangsById_Result != null)
								{
									text2 = wSspSelectOrderPaymentTypesInLangsById_Result.ordpayType ?? "";
								}
							}
							string text3 = "";
							string text4 = "";
							if (wSspSelectPreOrderWithId_Result2 != null)
							{
								text3 = wSspSelectPreOrderWithId_Result2.pordNumber.ToString();
								if (wSspSelectPreOrderWithId_Result2.pordDateTime.HasValue)
								{
									text4 = ((lang3.LanguageID != 1065) ? ((lang3.LanguageID != 1025) ? wSspSelectPreOrderWithId_Result2.pordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : wSspSelectPreOrderWithId_Result2.pordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"))) : wSspSelectPreOrderWithId_Result2.pordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture()));
								}
							}
							CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
							commonMultiLanguageViewModel.LanguageId = lang3.LanguageID;
							commonMultiLanguageViewModel.Value = text2 + " - " + MyResource.GetResourceString("lblPOrd", lang3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " - " + text3 + " - " + text4;
							CommonMultiLanguageViewModel item = commonMultiLanguageViewModel;
							list4.Add(item);
						}
						string cmpMnBgDesc = "";
						string cmpMnBgDesc_Lang = "";
						if (list4 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4))
						{
							cmpMnBgDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							if (list4 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4))
							{
								cmpMnBgDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
							}
						}
						ObjectParameter objectParameter = new ObjectParameter("insertedCompanyMoneyBagId", 0);
						Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspInsertCompanyMoneyBag(wSspSelectPreOrderWithId_Result2.pordCompanyId, 20, wSPreOrderPayments.pordpayPreOrderId, wSPreOrderPayments.ImportDateTime, wSPreOrderPayments.ImportDate, wSPreOrderPayments.pordpayAmount * -1m, cmpMnBgDesc, cmpMnBgDesc_Lang, null, userId, value3, value2, value, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, objectParameter, null, null, centerId));
						result3 = 0;
						if (objectParameter.Value != null)
						{
							int.TryParse(objectParameter.Value.ToString(), out result3);
						}
						if (result3 > 0)
						{
							CS_0024_003C_003E8__locals0.vm.pordpayCompanyMoneyBagId = result3;
							wSPreOrderPayments.pordpayCompanyMoneyBagId = result3;
						}
					}
					else if (result3 != 0 && pordpayTypeId == -10 && pordpayTypeId != wSPreOrderPayments.pordpayTypeId)
					{
						wSPreOrderPayments.pordpayCompanyMoneyBagId = null;
						CS_0024_003C_003E8__locals0.vm.pordpayCompanyMoneyBagId = null;
						Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteCompanyMoneyBagFromPayment(result3, 1, wSPreOrderPayments.PreOrderPaymentId));
					}
					else if (result3 != 0 && wSPreOrderPayments.pordpayTypeId == -10)
					{
						DateTime now3 = DateTime.Now;
						DateTime value4 = now3;
						string registerDatePersian2 = now3.ToString("yyyyMMdd", new PersianCulture());
						short value5 = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType2 = Configuration.AppType;
						short value6 = short.Parse(Financial.Get().Id.ToString());
						int userId2 = UserLogin.CurrentUser.UserId;
						List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
						List<WSspSelectOrderPaymentTypesInLangsById_Result> list7 = Enumerable.ToList<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)_dbI.WSspSelectOrderPaymentTypesInLangsById(wSPreOrderPayments.pordpayTypeId));
						WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result3 = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(wSPreOrderPayments.pordpayPreOrderId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						foreach (Languages lang2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
						{
							string text5 = "";
							if (list7 != null && Enumerable.Any<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)list7))
							{
								WSspSelectOrderPaymentTypesInLangsById_Result wSspSelectOrderPaymentTypesInLangsById_Result2 = Enumerable.FirstOrDefault<WSspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<WSspSelectOrderPaymentTypesInLangsById_Result>)list7, (Func<WSspSelectOrderPaymentTypesInLangsById_Result, bool>)((WSspSelectOrderPaymentTypesInLangsById_Result m) => m.LanguageID == lang2.LanguageID));
								if (wSspSelectOrderPaymentTypesInLangsById_Result2 != null)
								{
									text5 = wSspSelectOrderPaymentTypesInLangsById_Result2.ordpayType ?? "";
								}
							}
							string text6 = "";
							string text7 = "";
							if (wSspSelectPreOrderWithId_Result3 != null)
							{
								text6 = wSspSelectPreOrderWithId_Result3.pordNumber.ToString();
								if (wSspSelectPreOrderWithId_Result3.pordDateTime.HasValue)
								{
									text7 = ((lang2.LanguageID != 1065) ? ((lang2.LanguageID != 1025) ? wSspSelectPreOrderWithId_Result3.pordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : wSspSelectPreOrderWithId_Result3.pordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"))) : wSspSelectPreOrderWithId_Result3.pordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture()));
								}
							}
							CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
							commonMultiLanguageViewModel.LanguageId = lang2.LanguageID;
							commonMultiLanguageViewModel.Value = text5 + " - " + MyResource.GetResourceString("lblPOrd", lang2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " - " + text6 + " - " + text7;
							CommonMultiLanguageViewModel item2 = commonMultiLanguageViewModel;
							list6.Add(item2);
						}
						string cmpMnBgDesc2 = "";
						string cmpMnBgDesc_Lang2 = "";
						if (list6 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6))
						{
							cmpMnBgDesc2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							if (list6 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6))
							{
								cmpMnBgDesc_Lang2 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
							}
						}
						Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspUpdateCompanyMoneyBag(result3, wSPreOrderPayments.ImportDateTime, wSPreOrderPayments.ImportDate, wSPreOrderPayments.pordpayAmount * -1m, cmpMnBgDesc2, cmpMnBgDesc_Lang2, null, userId2, value5, value6, value4, registerDatePersian2, appType2, CS_0024_003C_003E8__locals0.defLangID, null, null));
					}
					wSPreOrderPayments.pordpayDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSPreOrderPayments.pordpayFileTypeJson = CS_0024_003C_003E8__locals0.vm.pordpayFileTypeJson;
					wSPreOrderPayments.pordpayGroupIdI = CS_0024_003C_003E8__locals0.vm.pordpayGroupIdI;
					wSPreOrderPayments.pordpayGroupIdII = CS_0024_003C_003E8__locals0.vm.pordpayGroupIdII;
					if (!UserLogin.IsUserAccess("frmPreOrder", "actCanNotChangePayBankInfoInEdit", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId == 0)
					{
						wSPreOrderPayments.pordpayBankingBankID = CS_0024_003C_003E8__locals0.vm.pordpayBankingBankID;
						wSPreOrderPayments.pordpayBankingBranchID = CS_0024_003C_003E8__locals0.vm.pordpayBankingBranchID;
						wSPreOrderPayments.pordpayBankingAccountID = CS_0024_003C_003E8__locals0.vm.pordpayBankingAccountID;
						wSPreOrderPayments.pordpayCashId = CS_0024_003C_003E8__locals0.vm.pordpayCashId;
						wSPreOrderPayments.pordpayBankName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSPreOrderPayments.pordpayBranchName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSPreOrderPayments.pordpayBranchCode = CS_0024_003C_003E8__locals0.vm.pordpayBranchCode;
						wSPreOrderPayments.pordpayAccountNumber = CS_0024_003C_003E8__locals0.vm.pordpayAccountNumber;
						if (wSPreOrderPayments.pordpayBankingBankID.GetValueOrDefault() == 0)
						{
							wSPreOrderPayments.pordpayBankingBankID = null;
						}
						if (wSPreOrderPayments.pordpayBankingBranchID.GetValueOrDefault() == 0)
						{
							wSPreOrderPayments.pordpayBankingBranchID = null;
						}
						if (wSPreOrderPayments.pordpayBankingAccountID.GetValueOrDefault() == 0)
						{
							wSPreOrderPayments.pordpayBankingAccountID = null;
							wSPreOrderPayments.pordpayBankingBranchID = null;
						}
					}
					wSPreOrderPayments.pordpayChqSayadNumber = CS_0024_003C_003E8__locals0.vm.pordpayChqSayadNumber;
					wSPreOrderPayments.pordpayChqSerialNumber = CS_0024_003C_003E8__locals0.vm.pordpayChqSerialNumber;
				}
				else
				{
					wSPreOrderPayments.pordpayAmount = CS_0024_003C_003E8__locals0.vm.pordpayAmount;
				}
				if (CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId != 0)
				{
					if (UserLogin.IsUserAccess("frmPreOrder", "actCanChangePordPayAmountTempInVerify", UserLogin.CurrentUser) && result2)
					{
						wSPreOrderPayments.pordpayAmountTemp = CS_0024_003C_003E8__locals0.vm.pordpayAmountTemp;
					}
					else if (!result2)
					{
						wSPreOrderPayments.pordpayAmountTemp = CS_0024_003C_003E8__locals0.vm.pordpayAmountTemp;
					}
				}
				else
				{
					wSPreOrderPayments.pordpayAmountTemp = CS_0024_003C_003E8__locals0.vm.pordpayAmountTemp;
					if (UserLogin.IsUserAccess("frmPreOrder", "actPayNeedVerify", UserLogin.CurrentUser))
					{
						CS_0024_003C_003E8__locals0.vm.pordpayAmount = 0m;
						wSPreOrderPayments.pordpayAmount = 0m;
					}
				}
				wSPreOrderPayments.pordpayIsVerified = CS_0024_003C_003E8__locals0.vm.pordpayIsVerified;
				if (wSPreOrderPayments.pordpayIsVerified.HasValue && wSPreOrderPayments.pordpayIsVerified.GetValueOrDefault())
				{
					if (!wSPreOrderPayments.pordpayVerifiedRegisterDate.HasValue)
					{
						wSPreOrderPayments.pordpayVerifierId = UserLogin.CurrentUser.UserId;
						wSPreOrderPayments.pordpayVerifiedRegisterDate = now;
						wSPreOrderPayments.pordpayVerifiedRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						wSPreOrderPayments.pordpayAmount = wSPreOrderPayments.pordpayAmountTemp.GetValueOrDefault();
					}
				}
				else
				{
					wSPreOrderPayments.pordpayVerifierId = null;
					wSPreOrderPayments.pordpayVerifiedRegisterDate = null;
					wSPreOrderPayments.pordpayVerifiedRegisterDatePersian = null;
				}
				if (CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId > 0)
				{
					_dbTbl.Entry(wSPreOrderPayments).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					PreOrder.CalcAndSetPreOrderAmounts(wSPreOrderPayments.pordpayPreOrderId);
					if (!result2)
					{
						using List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass8_3 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass8_3();
							CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals3.lang = enumerator.Current;
							DbSet<WSPreOrderPayments_Lang> wSPreOrderPayments_Lang = _dbTbl.WSPreOrderPayments_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSPreOrderPayments_Lang), "c");
							WSPreOrderPayments_Lang wSPreOrderPayments_Lang2 = Queryable.FirstOrDefault<WSPreOrderPayments_Lang>((IQueryable<WSPreOrderPayments_Lang>)wSPreOrderPayments_Lang, Expression.Lambda<Func<WSPreOrderPayments_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals3, typeof(_003C_003Ec__DisplayClass8_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals3, typeof(_003C_003Ec__DisplayClass8_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSPreOrderPayments_Lang2 != null)
							{
								wSPreOrderPayments_Lang2.pordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								if (!UserLogin.IsUserAccess("frmPreOrder", "actCanNotChangePayBankInfoInEdit", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.vm.PreOrderPaymentId == 0)
								{
									wSPreOrderPayments_Lang2.pordpayBankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
									wSPreOrderPayments_Lang2.pordpayBranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								}
								_dbTbl.Entry(wSPreOrderPayments_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSPreOrderPayments_Lang2 = new WSPreOrderPayments_Lang();
							wSPreOrderPayments_Lang2.LanguageID = CS_0024_003C_003E8__locals3.lang.LanguageID;
							wSPreOrderPayments_Lang2.PreOrderPaymentId = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.vm.PreOrderPaymentId;
							wSPreOrderPayments_Lang2.pordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							if (!UserLogin.IsUserAccess("frmPreOrder", "actCanNotChangePayBankInfoInEdit", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.vm.PreOrderPaymentId == 0)
							{
								wSPreOrderPayments_Lang2.pordpayBankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								wSPreOrderPayments_Lang2.pordpayBranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							}
							_dbTbl.WSPreOrderPayments_Lang.Add(wSPreOrderPayments_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					if (CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId != 0)
					{
						WSspSelectPreOrderPaymentsWithId_Result wSspSelectPreOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderPaymentsWithId_Result>((IEnumerable<WSspSelectPreOrderPaymentsWithId_Result>)_dbI.WSspSelectPreOrderPaymentsWithId(CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						if (wSspSelectPreOrderPaymentsWithId_Result != null)
						{
							CS_0024_003C_003E8__locals0.vm.pordpayFileTypeJsonByName = wSspSelectPreOrderPaymentsWithId_Result.pordpayFileTypeJsonByName ?? "";
							CS_0024_003C_003E8__locals0.vm.pordpayVerifier = wSspSelectPreOrderPaymentsWithId_Result.pordpayVerifier ?? "";
							if (wSspSelectPreOrderPaymentsWithId_Result.pordpayVerifiedRegisterDate.HasValue)
							{
								CS_0024_003C_003E8__locals0.vm.pordpayVerifier = CS_0024_003C_003E8__locals0.vm.pordpayVerifier ?? "";
							}
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					wSPreOrderPayments.FPId = Financial.Get().Id;
					wSPreOrderPayments.pordpayFirstRegisterUserId = currentUser.UserId;
					wSPreOrderPayments.pordpayFirstRegisteDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSPreOrderPayments.pordpayFirstRegisteDate = now;
					wSPreOrderPayments.GUId = System.Guid.NewGuid();
					wSPreOrderPayments.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					wSPreOrderPayments.FirstRegisterDate = now;
					wSPreOrderPayments.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSPreOrderPayments.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					wSPreOrderPayments.pordpayCId = PreOrder.GetPordCId(wSPreOrderPayments.pordpayPreOrderId);
					_dbTbl.WSPreOrderPayments.Add(wSPreOrderPayments);
					_dbTbl.SaveChanges();
					PreOrder.CalcAndSetPreOrderAmounts(wSPreOrderPayments.pordpayPreOrderId);
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSPreOrderPayments_Lang wSPreOrderPayments_Lang3 = new WSPreOrderPayments_Lang();
						wSPreOrderPayments_Lang3.LanguageID = lang.LanguageID;
						wSPreOrderPayments_Lang3.PreOrderPaymentId = wSPreOrderPayments.PreOrderPaymentId;
						wSPreOrderPayments_Lang3.pordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						if (!UserLogin.IsUserAccess("frmPreOrder", "actCanNotChangePayBankInfoInEdit", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals0.vm.PreOrderPaymentId == 0)
						{
							wSPreOrderPayments_Lang3.pordpayBankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSPreOrderPayments_Lang3.pordpayBranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						}
						_dbTbl.WSPreOrderPayments_Lang.Add(wSPreOrderPayments_Lang3);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.AppType = wSPreOrderPayments.AppType;
				CS_0024_003C_003E8__locals0.vm.UserId = wSPreOrderPayments.UserId;
				CS_0024_003C_003E8__locals0.vm.pordpayFirstRegisterUserId = wSPreOrderPayments.pordpayFirstRegisterUserId;
			}
			catch (DbEntityValidationException e4)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e4);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
		CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.pordpayDocDate = (CS_0024_003C_003E8__locals0.vm.pordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.pordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.pordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.pordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	[LoginAuthorize]
	public string Delete(int id, int preOrderId)
	{
		string result = "";
		try
		{
			WSPreOrderPayments wSPreOrderPayments = _dbTbl.WSPreOrderPayments.Find(id);
			if (wSPreOrderPayments != null)
			{
				try
				{
					if (PreOrder.PayIsSentToLinkAccByAction(wSPreOrderPayments.PreOrderPaymentId))
					{
						string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
						return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					}
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSPreOrderPayments(id)));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						PreOrder.CalcAndSetPreOrderAmounts(preOrderId);
						result = "";
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
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			result = Messages.frmErrorMessage + " - " + ex2.Message;
		}
		return result;
	}

	[AjaxOnly]
	[LoginAuthorize]
	public string TransferPreOrderPaymentToOrderOneToOne(int id, int ordId)
	{
		string result = "";
		try
		{
			DateTime now = DateTime.Now;
			_db.WSspTransferPreOrderPaymentToOrderOneToOne(id, UserLogin.CurrentUser.UserId, Financial.Get().Id, short.Parse(now.ToString("MM", new PersianCulture())), now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, ordId);
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			result = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	[LoginAuthorize]
	public string TransferPreOrderPaymentToOrderAll(int id, int ordId)
	{
		string result = "";
		try
		{
			DateTime now = DateTime.Now;
			_db.WSspTransferPreOrderPaymentToOrderAll(id, UserLogin.CurrentUser.UserId, Financial.Get().Id, short.Parse(now.ToString("MM", new PersianCulture())), now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, ordId);
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			result = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	private void FillDropdownPordPay()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectActiveOrderPaymentTypes_Result> list = Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString(),
				Selected = false
			})));
			base.ViewBag.PayTypeList = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
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
			base.ViewBag.PayTypeList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
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

	public void SetRegisterInfo(WSPreOrderPaymentsLanguageViewModel model)
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
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (model.PreOrderPaymentId > 0)
			{
				if (model.pordpayFirstRegisterUserId == currentUser.UserId)
				{
					text = currentUser.FullName;
				}
				else
				{
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.pordpayFirstRegisterUserId.GetValueOrDefault());
					text = ((cRMspSelectUsersById_Result != null) ? (cRMspSelectUsersById_Result.LName + ((cRMspSelectUsersById_Result.FName != null) ? (" " + cRMspSelectUsersById_Result.FName) : "")) : "");
				}
				if (model.UserId == currentUser.UserId)
				{
					text2 = currentUser.FullName;
				}
				else
				{
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
					text2 = ((cRMspSelectUsersById_Result2 != null) ? (cRMspSelectUsersById_Result2.LName + ((cRMspSelectUsersById_Result2.FName != null) ? (" " + cRMspSelectUsersById_Result2.FName) : "")) : "");
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
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actpordPreOrderPaymentIndicator")]
	public ActionResult Indicator(int position = 0, int cmpId = 0, string cmpName = "")
	{
		string text = "";
		string text2 = "";
		if (position == 0)
		{
			text = "frmMain";
			text2 = "actpordPreOrderPaymentIndicator";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			PreOrderPaymentIndicatorViewModel model = new PreOrderPaymentIndicatorViewModel
			{
				PordPayIndicatorCompanyId = cmpId.ToString(),
				PordPayIndicatorCompanyName = cmpName,
				PordPayIndicatorMonth = DateTime.Now.ToString("MM")
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
			FillDropdownPordIndicator();
			return View(model);
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
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

	public ActionResult AddPaymentType()
	{
		return View();
	}

	public ActionResult PaymentType_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSOrderPaymentTypes> enumerable = new List<WSOrderPaymentTypes>();
		try
		{
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			enumerable = Enumerable.ToList<WSOrderPaymentTypes>(Enumerable.Select<WSspSelectOrderPaymentTypes_Result, WSOrderPaymentTypes>(Enumerable.Where<WSspSelectOrderPaymentTypes_Result>((IEnumerable<WSspSelectOrderPaymentTypes_Result>)Enumerable.ToList<WSspSelectOrderPaymentTypes_Result>((IEnumerable<WSspSelectOrderPaymentTypes_Result>)_db.WSspSelectOrderPaymentTypes(lCID, result, value)), (Func<WSspSelectOrderPaymentTypes_Result, bool>)((WSspSelectOrderPaymentTypes_Result item) => item.OrderPaymentTypeId != 0 && item.OrderPaymentTypeId != -1 && item.OrderPaymentTypeId != -100)), (Func<WSspSelectOrderPaymentTypes_Result, WSOrderPaymentTypes>)((WSspSelectOrderPaymentTypes_Result item) => new WSOrderPaymentTypes
			{
				OrderPaymentTypeId = item.OrderPaymentTypeId,
				ordpayType = item.ordpayType
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
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	private void FillDropdownPordIndicator()
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
			List<WSspSelectPreOrderReferUsers_Result> list = Enumerable.ToList<WSspSelectPreOrderReferUsers_Result>((IEnumerable<WSspSelectPreOrderReferUsers_Result>)_db.WSspSelectPreOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list2.AddRange(Enumerable.Select<WSspSelectPreOrderReferUsers_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderReferUsers_Result>)list, (Func<WSspSelectPreOrderReferUsers_Result, SelectListItem>)((WSspSelectPreOrderReferUsers_Result item) => new SelectListItem
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
	public JsonResult GetPordPayCompany(string value = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspPreOrderPaymentsIndicatorSearchCompany_Result> data = new List<WSspPreOrderPaymentsIndicatorSearchCompany_Result>();
		try
		{
			data = Enumerable.ToList<WSspPreOrderPaymentsIndicatorSearchCompany_Result>((IEnumerable<WSspPreOrderPaymentsIndicatorSearchCompany_Result>)_db.WSspPreOrderPaymentsIndicatorSearchCompany(value, lCID, result));
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
		List<WSspSelectPreOrderReferUsers_Result> list = Enumerable.ToList<WSspSelectPreOrderReferUsers_Result>((IEnumerable<WSspSelectPreOrderReferUsers_Result>)_db.WSspSelectPreOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
		List<SelectListItem> list2 = new List<SelectListItem>();
		list2.Add(new SelectListItem
		{
			Text = Labels.SelectedListDefValue,
			Value = "0",
			Selected = false
		});
		list2.AddRange(Enumerable.Select<WSspSelectPreOrderReferUsers_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderReferUsers_Result>)list, (Func<WSspSelectPreOrderReferUsers_Result, SelectListItem>)((WSspSelectPreOrderReferUsers_Result item) => new SelectListItem
		{
			Text = item.UserName,
			Value = item.UserId.ToString(),
			Selected = false
		})));
		base.ViewBag.UserList = list2;
		return Json(list2, JsonRequestBehavior.AllowGet);
	}

	public List<mct_WSspSelectPreOrderPaymentIndicator_Result> ListPreOrderIndicator(PreOrderPaymentIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<mct_WSspSelectPreOrderPaymentIndicator_Result> list = new List<mct_WSspSelectPreOrderPaymentIndicator_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.PordPayIndicatorMonth = ((indicator.PordPayIndicatorMonth != null && indicator.PordPayIndicatorMonth == "0") ? null : indicator.PordPayIndicatorMonth);
				string text = "0";
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorMonth) && indicator.PordPayIndicatorMonth != "0")
				{
					text = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + indicator.PordPayIndicatorMonth + "/01").ToString("yyyyMM", new CultureInfo("en-US"));
				}
				indicator.PordPayIndicatorDate = ((!string.IsNullOrEmpty(indicator.PordPayIndicatorDate)) ? indicator.PordPayIndicatorDate.Replace("/", "") : "");
				indicator.PordPayIndicatorFDate = ((!string.IsNullOrEmpty(indicator.PordPayIndicatorFDate)) ? indicator.PordPayIndicatorFDate.Replace("/", "") : "");
				indicator.PordPayIndicatorTDate = ((!string.IsNullOrEmpty(indicator.PordPayIndicatorTDate)) ? indicator.PordPayIndicatorTDate.Replace("/", "") : "");
				indicator.PordPayIndicatorMonth = (string.IsNullOrEmpty(indicator.PordPayIndicatorMonth) ? "0" : ((lCID == 1025) ? text : (DateTime.Now.ToString("yyyy") + indicator.PordPayIndicatorMonth)));
				indicator.PordPayIndicatorPreOrderNumber = (string.IsNullOrEmpty(indicator.PordPayIndicatorPreOrderNumber) ? "0" : indicator.PordPayIndicatorPreOrderNumber);
				indicator.PordPayIndicatorCompanyId = (string.IsNullOrEmpty(indicator.PordPayIndicatorCompanyId) ? "0" : indicator.PordPayIndicatorCompanyId);
				indicator.PordPayIndicatorTypeId = (string.IsNullOrEmpty(indicator.PordPayIndicatorTypeId) ? "0" : indicator.PordPayIndicatorTypeId);
				indicator.PordPayIndicatorFDocDate = ((!string.IsNullOrEmpty(indicator.PordPayIndicatorFDocDate)) ? indicator.PordPayIndicatorFDocDate.Replace("/", "") : "");
				indicator.PordPayIndicatorTDocDate = ((!string.IsNullOrEmpty(indicator.PordPayIndicatorTDocDate)) ? indicator.PordPayIndicatorTDocDate.Replace("/", "") : "");
				indicator.PordPayIndicatorDocNumber = (string.IsNullOrEmpty(indicator.PordPayIndicatorDocNumber) ? "0" : indicator.PordPayIndicatorDocNumber);
				indicator.PordPayIndicatorDescription = (string.IsNullOrEmpty(indicator.PordPayIndicatorDescription) ? "0" : indicator.PordPayIndicatorDescription);
				indicator.PordPayIndicatorUserId = (string.IsNullOrEmpty(indicator.PordPayIndicatorUserId) ? "0" : indicator.PordPayIndicatorUserId);
				indicator.PordPayIndicatorFirstRegisterUserId = (string.IsNullOrEmpty(indicator.PordPayIndicatorFirstRegisterUserId) ? "0" : indicator.PordPayIndicatorFirstRegisterUserId);
				indicator.PordPayIndicatorReferUserId = (string.IsNullOrEmpty(indicator.PordPayIndicatorReferUserId) ? "0" : indicator.PordPayIndicatorReferUserId);
				indicator.PordPayIndicatorDeActive = (string.IsNullOrWhiteSpace(indicator.PordPayIndicatorDeActive) ? "0" : indicator.PordPayIndicatorDeActive);
				indicator.PordPayIndicatorHaveLinkAcc = (string.IsNullOrWhiteSpace(indicator.PordPayIndicatorHaveLinkAcc) ? "0" : indicator.PordPayIndicatorHaveLinkAcc);
				indicator.PordPayIndicatorIsVerified = (string.IsNullOrWhiteSpace(indicator.PordPayIndicatorIsVerified) ? "0" : indicator.PordPayIndicatorIsVerified);
				indicator.LinkAccSettingDBId = indicator.LinkAccSettingDBId.GetValueOrDefault();
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordPayIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordPayIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordPayIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorFDocDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordPayIndicatorFDocDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorTDocDate))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordPayIndicatorTDocDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				list = Enumerable.ToList<mct_WSspSelectPreOrderPaymentIndicator_Result>((IEnumerable<mct_WSspSelectPreOrderPaymentIndicator_Result>)_db.mfi_WSspSelectPreOrderPaymentIndicator(indicator.PordPayIndicatorDate, indicator.PordPayIndicatorFDate, indicator.PordPayIndicatorTDate, indicator.PordPayIndicatorMonth, indicator.PordPayIndicatorCompanyId, indicator.PordPayIndicatorPreOrderNumber, indicator.PordPayIndicatorTypeId, indicator.PordPayIndicatorAmount.ToString(), indicator.PordPayIndicatorFDocDate, indicator.PordPayIndicatorTDocDate, indicator.PordPayIndicatorDocNumber, indicator.PordPayIndicatorDocAmount.ToString(), indicator.PordPayIndicatorDescription, indicator.PordPayIndicatorFirstRegisterUserId, indicator.PordPayIndicatorUserId, indicator.PordPayIndicatorReferUserId, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DefineDayeOfWeekFa(dayOfWeek.ToString()), lCID, result, value, value2, value3, value4, value5, indicator.PordPayIndicatorDeActive, haveLinkAcc: indicator.PordPayIndicatorHaveLinkAcc, linkAccSettingDBId: indicator.LinkAccSettingDBId, payIsVerified: indicator.PordPayIndicatorIsVerified, centerId: result2));
			}
			foreach (mct_WSspSelectPreOrderPaymentIndicator_Result item in list)
			{
				item.ImportDate = (item.ImportDateTime.HasValue ? item.ImportDateTime.Value.ToString("yyyyMMdd") : item.ImportDate);
				item.RegisterDatePersian = (item.RegisterDate.HasValue ? item.RegisterDate.Value.ToString("yyyyMMdd") : item.RegisterDatePersian);
				if (!string.IsNullOrEmpty(item.pordDate))
				{
					item.pordDate = PersianDate.GetShamsi2Miladi(item.pordDate.Replace("/", "")).Replace("/", "");
				}
				item.pordpayDocDate = (item.pordpayDocDateTime.HasValue ? item.pordpayDocDateTime.Value.ToString("yyyyMMdd") : item.pordpayDocDate);
				item.pordpayFirstRegisteDatePersian = (item.pordpayFirstRegisteDate.HasValue ? item.pordpayFirstRegisteDate.Value.ToString("yyyyMMdd") : item.pordpayFirstRegisteDatePersian);
				item.pordpayVerifiedRegisterDatePersian = (item.pordpayVerifiedRegisterDate.HasValue ? item.pordpayVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm;ss") : "");
				item.pordpayDocDateTemp = (item.pordpayDocDateTimeTemp.HasValue ? item.pordpayDocDateTimeTemp.Value.ToString("yyyyMMdd") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult PreOrderPayIndicator_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		PreOrderPaymentIndicatorViewModel indicator2 = new JavaScriptSerializer().Deserialize<PreOrderPaymentIndicatorViewModel>(indicator);
		JsonResult jsonResult = Json(((IEnumerable)ListPreOrderIndicator(indicator2)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult FirstLoadPreOrderPayIndicator(string cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<mct_WSspSelectPreOrderPaymentIndicator_Result> list = new List<mct_WSspSelectPreOrderPaymentIndicator_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (cmpId != "0" && cmpId != "" && cmpId != null)
			{
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				list = Enumerable.ToList<mct_WSspSelectPreOrderPaymentIndicator_Result>((IEnumerable<mct_WSspSelectPreOrderPaymentIndicator_Result>)_db.mfi_WSspSelectPreOrderPaymentIndicator("", "", "", "0", cmpId, "0", "0", "0", "", "", "0", "0", "0", "0", "0", "0", UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyyMMdd"), dayOfWeek.ToString(), lCID, result, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "0", "0", "0", 0, result2));
			}
			foreach (mct_WSspSelectPreOrderPaymentIndicator_Result item in list)
			{
				item.ImportDate = (item.ImportDateTime.HasValue ? item.ImportDateTime.Value.ToString("yyyyMMdd") : item.ImportDate);
				item.RegisterDatePersian = (item.RegisterDate.HasValue ? item.RegisterDate.Value.ToString("yyyyMMdd") : item.RegisterDatePersian);
				if (!string.IsNullOrEmpty(item.pordDate))
				{
					item.pordDate = PersianDate.GetShamsi2Miladi(item.pordDate.Replace("/", "")).Replace("/", "");
				}
				item.pordpayDocDate = (item.pordpayDocDateTime.HasValue ? item.pordpayDocDateTime.Value.ToString("yyyyMMdd") : item.pordpayDocDate);
				item.pordpayFirstRegisteDatePersian = (item.pordpayFirstRegisteDate.HasValue ? item.pordpayFirstRegisteDate.Value.ToString("yyyyMMdd") : item.pordpayFirstRegisteDatePersian);
				item.pordpayVerifiedRegisterDatePersian = (item.pordpayVerifiedRegisterDate.HasValue ? item.pordpayVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm;ss") : "");
				item.pordpayDocDateTemp = (item.pordpayDocDateTimeTemp.HasValue ? item.pordpayDocDateTimeTemp.Value.ToString("yyyyMMdd") : "");
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
	public JsonResult PreOrderPayIndicator(PreOrderPaymentIndicatorViewModel indicator)
	{
		JsonResult jsonResult = Json(ListPreOrderIndicator(indicator), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult IndicatorUpdateFooter(PreOrderPaymentIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		mct_WSspSelectPreOrderPaymentIndicatorSum_Result data = new mct_WSspSelectPreOrderPaymentIndicatorSum_Result();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.PordPayIndicatorMonth = ((indicator.PordPayIndicatorMonth != null && indicator.PordPayIndicatorMonth == "0") ? null : indicator.PordPayIndicatorMonth);
				string text = "0";
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorMonth) && indicator.PordPayIndicatorMonth != "0")
				{
					text = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + indicator.PordPayIndicatorMonth + "/01").ToString("yyyyMM", new CultureInfo("en-US"));
				}
				indicator.PordPayIndicatorDate = ((!string.IsNullOrEmpty(indicator.PordPayIndicatorDate)) ? indicator.PordPayIndicatorDate.Replace("/", "") : "");
				indicator.PordPayIndicatorFDate = ((!string.IsNullOrEmpty(indicator.PordPayIndicatorFDate)) ? indicator.PordPayIndicatorFDate.Replace("/", "") : "");
				indicator.PordPayIndicatorTDate = ((!string.IsNullOrEmpty(indicator.PordPayIndicatorTDate)) ? indicator.PordPayIndicatorTDate.Replace("/", "") : "");
				indicator.PordPayIndicatorMonth = (string.IsNullOrEmpty(indicator.PordPayIndicatorMonth) ? "0" : ((lCID == 1025) ? text : (DateTime.Now.ToString("yyyy") + indicator.PordPayIndicatorMonth)));
				indicator.PordPayIndicatorPreOrderNumber = (string.IsNullOrEmpty(indicator.PordPayIndicatorPreOrderNumber) ? "0" : indicator.PordPayIndicatorPreOrderNumber);
				indicator.PordPayIndicatorCompanyId = (string.IsNullOrEmpty(indicator.PordPayIndicatorCompanyId) ? "0" : indicator.PordPayIndicatorCompanyId);
				indicator.PordPayIndicatorTypeId = (string.IsNullOrEmpty(indicator.PordPayIndicatorTypeId) ? "0" : indicator.PordPayIndicatorTypeId);
				indicator.PordPayIndicatorFDocDate = ((!string.IsNullOrEmpty(indicator.PordPayIndicatorFDocDate)) ? indicator.PordPayIndicatorFDocDate.Replace("/", "") : "");
				indicator.PordPayIndicatorTDocDate = ((!string.IsNullOrEmpty(indicator.PordPayIndicatorTDocDate)) ? indicator.PordPayIndicatorTDocDate.Replace("/", "") : "");
				indicator.PordPayIndicatorDocNumber = (string.IsNullOrEmpty(indicator.PordPayIndicatorDocNumber) ? "0" : indicator.PordPayIndicatorDocNumber);
				indicator.PordPayIndicatorDescription = (string.IsNullOrEmpty(indicator.PordPayIndicatorDescription) ? "0" : indicator.PordPayIndicatorDescription);
				indicator.PordPayIndicatorUserId = (string.IsNullOrEmpty(indicator.PordPayIndicatorUserId) ? "0" : indicator.PordPayIndicatorUserId);
				indicator.PordPayIndicatorFirstRegisterUserId = (string.IsNullOrEmpty(indicator.PordPayIndicatorFirstRegisterUserId) ? "0" : indicator.PordPayIndicatorFirstRegisterUserId);
				indicator.PordPayIndicatorReferUserId = (string.IsNullOrEmpty(indicator.PordPayIndicatorReferUserId) ? "0" : indicator.PordPayIndicatorReferUserId);
				indicator.PordPayIndicatorDeActive = (string.IsNullOrWhiteSpace(indicator.PordPayIndicatorDeActive) ? "0" : indicator.PordPayIndicatorDeActive);
				indicator.PordPayIndicatorHaveLinkAcc = (string.IsNullOrWhiteSpace(indicator.PordPayIndicatorHaveLinkAcc) ? "0" : indicator.PordPayIndicatorHaveLinkAcc);
				indicator.PordPayIndicatorIsVerified = (string.IsNullOrWhiteSpace(indicator.PordPayIndicatorIsVerified) ? "0" : indicator.PordPayIndicatorIsVerified);
				indicator.LinkAccSettingDBId = indicator.LinkAccSettingDBId.GetValueOrDefault();
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordPayIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordPayIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordPayIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorFDocDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordPayIndicatorFDocDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordPayIndicatorTDocDate))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordPayIndicatorTDocDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				data = Enumerable.FirstOrDefault<mct_WSspSelectPreOrderPaymentIndicatorSum_Result>((IEnumerable<mct_WSspSelectPreOrderPaymentIndicatorSum_Result>)_db.mfi_WSspSelectPreOrderPaymentIndicatorSum(indicator.PordPayIndicatorDate, indicator.PordPayIndicatorFDate, indicator.PordPayIndicatorTDate, indicator.PordPayIndicatorMonth, indicator.PordPayIndicatorCompanyId, indicator.PordPayIndicatorPreOrderNumber, indicator.PordPayIndicatorTypeId, indicator.PordPayIndicatorAmount.ToString(), indicator.PordPayIndicatorFDocDate, indicator.PordPayIndicatorTDocDate, indicator.PordPayIndicatorDocNumber, indicator.PordPayIndicatorDocAmount.ToString(), indicator.PordPayIndicatorDescription, indicator.PordPayIndicatorFirstRegisterUserId, indicator.PordPayIndicatorUserId, indicator.PordPayIndicatorReferUserId, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DefineDayeOfWeekFa(dayOfWeek.ToString()), value, value2, value3, lCID, result, value4, value5, indicator.PordPayIndicatorDeActive, indicator.PordPayIndicatorIsVerified, indicator.PordPayIndicatorHaveLinkAcc, indicator.LinkAccSettingDBId, result2));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
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

	[AjaxOnly]
	public string PaymentVerify(int payId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPreOrder", "actVerifyPayPreOrder", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_dbIII.WSspPreOrderPaymentVerify(payId, userId, now, registerDatePersian);
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
		if (!UserLogin.IsUserAccess("frmPreOrder", "actExitVerifyPayPreOrder", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbIII.WSspPreOrderPaymentVerifyExit(payId);
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
		if (!UserLogin.IsUserAccess("frmPreOrder", "actCanceledPay", currentUser))
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
			_dbIII.WSspPreOrderPaymentDeActive(payId, userId, value, text);
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
		if (!UserLogin.IsUserAccess("frmPreOrder", "actExitCanceledPay", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbIII.WSspPreOrderPaymentDeActiveExit(payId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
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
