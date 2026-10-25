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
using System.Transactions;
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

namespace CRMIdeal.Areas.BuyOrders.Controllers;

public class PaymentController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int bordPayId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public WSBuyOrderPaymentsLanguageViewModel vm;

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
	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

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
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int id;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actInsertPay,actEdtitPay")]
	public ActionResult InsertEdit(int bordPayId, int? bordId = null, bool modeVerify = false)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.bordPayId = bordPayId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSBuyOrderPaymentsLanguageViewModel wSBuyOrderPaymentsLanguageViewModel = new WSBuyOrderPaymentsLanguageViewModel();
		if (bordId.HasValue && bordId > 0)
		{
			wSBuyOrderPaymentsLanguageViewModel = new WSBuyOrderPaymentsLanguageViewModel();
			wSBuyOrderPaymentsLanguageViewModel.bordpayOrderId = Convert.ToInt32(bordId);
		}
		else
		{
			DbSet<WSBuyOrderPayments_Lang> wSBuyOrderPayments_Lang = _dbTbl.WSBuyOrderPayments_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderPayments_Lang), "c");
			List<WSBuyOrderPayments_Lang> list = Enumerable.ToList<WSBuyOrderPayments_Lang>((IEnumerable<WSBuyOrderPayments_Lang>)Queryable.Where<WSBuyOrderPayments_Lang>((IQueryable<WSBuyOrderPayments_Lang>)wSBuyOrderPayments_Lang, Expression.Lambda<Func<WSBuyOrderPayments_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			WSBuyOrderPayments wSBuyOrderPayments = _dbTbl.WSBuyOrderPayments.Find(CS_0024_003C_003E8__locals0.bordPayId) ?? new WSBuyOrderPayments();
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderPayments_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderPayments_Lang>)list, (Func<WSBuyOrderPayments_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderPayments_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.bordpayDescription,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSBuyOrderPayments.bordpayDescription,
				LanguageId = result
			});
			string text = "";
			if (CS_0024_003C_003E8__locals0.bordPayId != 0)
			{
				WSspSelectBuyOrderPaymentsWithId_Result wSspSelectBuyOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderPaymentsWithId_Result>((IEnumerable<WSspSelectBuyOrderPaymentsWithId_Result>)_dbII.WSspSelectBuyOrderPaymentsWithId(CS_0024_003C_003E8__locals0.bordPayId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (wSspSelectBuyOrderPaymentsWithId_Result != null)
				{
					text = wSspSelectBuyOrderPaymentsWithId_Result.bordpayVerifier ?? "";
					if (wSspSelectBuyOrderPaymentsWithId_Result.bordpayVerifiedRegisterDate.HasValue)
					{
						text = text ?? "";
					}
				}
			}
			WSBuyOrderPaymentsLanguageViewModel obj = new WSBuyOrderPaymentsLanguageViewModel
			{
				LanguageID = wSBuyOrderPayments.LanguageID,
				UserId = wSBuyOrderPayments.UserId,
				FirstRegisterUserId = wSBuyOrderPayments.FirstRegisterUserId,
				AppType = wSBuyOrderPayments.AppType,
				FirstRegisterDate = wSBuyOrderPayments.FirstRegisterDate,
				FirstRegisterDatePersian = wSBuyOrderPayments.FirstRegisterDatePersian,
				GUId = wSBuyOrderPayments.GUId,
				RegisterDate = wSBuyOrderPayments.RegisterDate,
				Month1 = wSBuyOrderPayments.Month1
			};
			_ = wSBuyOrderPayments.RegisterDate;
			obj.RegisterDatePersian = wSBuyOrderPayments.RegisterDate.ToString("yyyyMMdd");
			obj.FPId = wSBuyOrderPayments.FPId;
			obj.ImportDateTime = wSBuyOrderPayments.ImportDateTime;
			obj.ImportDate = (wSBuyOrderPayments.ImportDateTime.HasValue ? wSBuyOrderPayments.ImportDateTime.Value.ToString("yyyyMMdd") : "");
			obj.BuyOrderPaymentId = wSBuyOrderPayments.BuyOrderPaymentId;
			obj.bordpayTypeId = wSBuyOrderPayments.bordpayTypeId;
			obj.bordpayOrderId = wSBuyOrderPayments.bordpayOrderId;
			obj.bordpayDocId = wSBuyOrderPayments.bordpayDocId;
			obj.bordpayDocTypeId = wSBuyOrderPayments.bordpayDocTypeId;
			obj.bordpayAmount = wSBuyOrderPayments.bordpayAmount;
			obj.bordpayDocNumber = wSBuyOrderPayments.bordpayDocNumber;
			obj.bordpayDocDate = (wSBuyOrderPayments.bordpayDocDateTime.HasValue ? wSBuyOrderPayments.bordpayDocDateTime.Value.ToString("yyyyMMdd") : "");
			obj.bordpayDocDateTime = wSBuyOrderPayments.bordpayDocDateTime;
			obj.bordpayDocDateTemp = (wSBuyOrderPayments.bordpayDocDateTimeTemp.HasValue ? wSBuyOrderPayments.bordpayDocDateTimeTemp.Value.ToString("yyyyMMdd") : "");
			obj.bordpayDocDateTimeTemp = wSBuyOrderPayments.bordpayDocDateTimeTemp;
			obj.bordpayAmountTemp = wSBuyOrderPayments.bordpayAmountTemp;
			obj.bordpayDocAmount = wSBuyOrderPayments.bordpayDocAmount;
			obj.bordpayFirstRegisterUserId = wSBuyOrderPayments.bordpayFirstRegisterUserId;
			obj.bordpayFirstRegisteDatePersian = wSBuyOrderPayments.bordpayFirstRegisteDatePersian;
			obj.bordpayFirstRegisteDate = wSBuyOrderPayments.bordpayFirstRegisteDate;
			obj.bordpayDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.bordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.bordpayDeActive = wSBuyOrderPayments.bordpayDeActive;
			obj.bordpayAccountNumber = wSBuyOrderPayments.bordpayAccountNumber;
			obj.bordpayHeadingUpAmount = wSBuyOrderPayments.bordpayHeadingUpAmount;
			obj.bordpayHeadingUpDay = wSBuyOrderPayments.bordpayHeadingUpDay;
			obj.ModeVirify = modeVerify;
			obj.bordpayIsVerified = wSBuyOrderPayments.bordpayIsVerified;
			obj.bordpayVerifierId = wSBuyOrderPayments.bordpayVerifierId;
			obj.bordpayVerifier = text;
			obj.bordpayVerifiedRegisterDate = wSBuyOrderPayments.bordpayVerifiedRegisterDate;
			obj.bordpayVerifiedRegisterDatePersian = wSBuyOrderPayments.bordpayVerifiedRegisterDatePersian;
			wSBuyOrderPaymentsLanguageViewModel = obj;
		}
		GetBordPaymentType();
		SetRegisterInfo(wSBuyOrderPaymentsLanguageViewModel);
		return View(wSBuyOrderPaymentsLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[LoginAuthorize]
	public ActionResult InsertEdit(WSBuyOrderPaymentsLanguageViewModel vm)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetBordPaymentType();
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordpayDescription_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.bordpayDescription_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.bordpayDescription,
				LanguageId = lCID
			});
			try
			{
				if (CS_0024_003C_003E8__locals0.vm.BuyOrderPaymentId > 0 && BuyOrder.PayIsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.vm.BuyOrderPaymentId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordpayDocDate = (CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordpayFirstRegisteDate = DateTime.Now;
					CS_0024_003C_003E8__locals0.vm.RegisterDate = DateTime.Now;
					SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
				CS_0024_003C_003E8__locals0.vm.UserId = currentUser.UserId;
				DateTime now = DateTime.Now;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = now;
				CS_0024_003C_003E8__locals0.vm.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				CS_0024_003C_003E8__locals0.vm.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				CS_0024_003C_003E8__locals0.vm.AppType = Configuration.AppType;
				CS_0024_003C_003E8__locals0.vm.ImportDate = CS_0024_003C_003E8__locals0.vm.ImportDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				CS_0024_003C_003E8__locals0.vm.bordpayDocDate = CS_0024_003C_003E8__locals0.vm.bordpayDocDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp ?? "").Replace("/", "").Replace("-", "").Replace("_", "")
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
					CS_0024_003C_003E8__locals0.vm.bordpayDocDate = (CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordpayDocDate))
					{
						text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.bordpayDocDate.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.bordpayDocDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.bordpayDocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.bordpayDocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime = dateTime;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					base.ViewBag.Error = Messages.ErrorFormatDatePersian;
					CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordpayDocDate = (CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				try
				{
					if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp))
					{
						text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp = dateTime;
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					base.ViewBag.Error = Messages.ErrorFormatDatePersian;
					CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordpayDocDate = (CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				WSBuyOrderPayments wSBuyOrderPayments = new WSBuyOrderPayments();
				if (CS_0024_003C_003E8__locals0.vm.BuyOrderPaymentId > 0)
				{
					DbSet<WSBuyOrderPayments> wSBuyOrderPayments2 = _dbTbl.WSBuyOrderPayments;
					ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderPayments), "c");
					wSBuyOrderPayments = Queryable.FirstOrDefault<WSBuyOrderPayments>((IQueryable<WSBuyOrderPayments>)wSBuyOrderPayments2, Expression.Lambda<Func<WSBuyOrderPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				CS_0024_003C_003E8__locals0.vm.RegisterDate = now;
				wSBuyOrderPayments.AppType = Configuration.AppType;
				bool result = false;
				bool.TryParse(CS_0024_003C_003E8__locals0.vm.ModeVirify.ToString(), out result);
				if (!result)
				{
					wSBuyOrderPayments.RegisterDate = now;
					CS_0024_003C_003E8__locals0.vm.RegisterDate = now;
					wSBuyOrderPayments.UserId = currentUser.UserId;
					wSBuyOrderPayments.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSBuyOrderPayments.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					wSBuyOrderPayments.ImportDateTime = CS_0024_003C_003E8__locals0.vm.ImportDateTime;
					wSBuyOrderPayments.ImportDate = CS_0024_003C_003E8__locals0.vm.ImportDate;
					wSBuyOrderPayments.BuyOrderPaymentId = CS_0024_003C_003E8__locals0.vm.BuyOrderPaymentId;
					wSBuyOrderPayments.bordpayTypeId = CS_0024_003C_003E8__locals0.vm.bordpayTypeId;
					wSBuyOrderPayments.bordpayOrderId = CS_0024_003C_003E8__locals0.vm.bordpayOrderId;
					wSBuyOrderPayments.bordpayDocId = CS_0024_003C_003E8__locals0.vm.bordpayDocId;
					wSBuyOrderPayments.bordpayDocTypeId = CS_0024_003C_003E8__locals0.vm.bordpayDocTypeId;
					wSBuyOrderPayments.bordpayAmount = CS_0024_003C_003E8__locals0.vm.bordpayAmount;
					wSBuyOrderPayments.bordpayDocNumber = CS_0024_003C_003E8__locals0.vm.bordpayDocNumber;
					wSBuyOrderPayments.bordpayDocDate = CS_0024_003C_003E8__locals0.vm.bordpayDocDate;
					wSBuyOrderPayments.bordpayDocDateTime = CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime;
					wSBuyOrderPayments.bordpayAmountTemp = CS_0024_003C_003E8__locals0.vm.bordpayAmountTemp;
					if (UserLogin.IsUserAccess("frmBuyOrder", "actCanEditBordPayDocDateTemp", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals0.vm.BuyOrderPaymentId == 0)
					{
						wSBuyOrderPayments.bordpayDocDateTemp = CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp;
						wSBuyOrderPayments.bordpayDocDateTimeTemp = CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp;
					}
					wSBuyOrderPayments.bordpayFirstRegisterUserId = CS_0024_003C_003E8__locals0.vm.bordpayFirstRegisterUserId;
					wSBuyOrderPayments.bordpayFirstRegisteDatePersian = CS_0024_003C_003E8__locals0.vm.bordpayFirstRegisteDatePersian;
					wSBuyOrderPayments.bordpayFirstRegisteDate = CS_0024_003C_003E8__locals0.vm.bordpayFirstRegisteDate;
					wSBuyOrderPayments.bordpayDocAmount = CS_0024_003C_003E8__locals0.vm.bordpayDocAmount;
					wSBuyOrderPayments.bordpayDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSBuyOrderPayments.bordpayDeActive = CS_0024_003C_003E8__locals0.vm.bordpayDeActive;
					wSBuyOrderPayments.bordpayAccountNumber = CS_0024_003C_003E8__locals0.vm.bordpayAccountNumber;
				}
				else
				{
					wSBuyOrderPayments.bordpayAmount = CS_0024_003C_003E8__locals0.vm.bordpayAmount;
				}
				if (CS_0024_003C_003E8__locals0.vm.BuyOrderPaymentId != 0)
				{
					if (UserLogin.IsUserAccess("frmBuyOrder", "actCanChangeBordPayAmountTempInVerify", UserLogin.CurrentUser) && result)
					{
						wSBuyOrderPayments.bordpayAmountTemp = CS_0024_003C_003E8__locals0.vm.bordpayAmountTemp;
					}
					else if (!result)
					{
						wSBuyOrderPayments.bordpayAmountTemp = CS_0024_003C_003E8__locals0.vm.bordpayAmountTemp;
					}
				}
				else
				{
					wSBuyOrderPayments.bordpayAmountTemp = CS_0024_003C_003E8__locals0.vm.bordpayAmountTemp;
					if (UserLogin.IsUserAccess("frmBuyOrder", "actPayNeedVerify", UserLogin.CurrentUser))
					{
						CS_0024_003C_003E8__locals0.vm.bordpayAmount = 0m;
						wSBuyOrderPayments.bordpayAmount = 0m;
					}
				}
				wSBuyOrderPayments.bordpayIsVerified = CS_0024_003C_003E8__locals0.vm.bordpayIsVerified;
				if (wSBuyOrderPayments.bordpayIsVerified.HasValue && wSBuyOrderPayments.bordpayIsVerified.GetValueOrDefault())
				{
					if (!wSBuyOrderPayments.bordpayVerifiedRegisterDate.HasValue)
					{
						wSBuyOrderPayments.bordpayVerifierId = UserLogin.CurrentUser.UserId;
						wSBuyOrderPayments.bordpayVerifiedRegisterDate = now;
						wSBuyOrderPayments.bordpayVerifiedRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						wSBuyOrderPayments.bordpayAmount = wSBuyOrderPayments.bordpayAmountTemp.GetValueOrDefault();
					}
				}
				else
				{
					wSBuyOrderPayments.bordpayVerifierId = null;
					wSBuyOrderPayments.bordpayVerifiedRegisterDate = null;
					wSBuyOrderPayments.bordpayVerifiedRegisterDatePersian = null;
				}
				WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)_dbII.WSspSelectBuyOrderById(wSBuyOrderPayments.bordpayOrderId, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (wSspSelectBuyOrderById_Result != null)
				{
					DateTime? dateTime2 = wSBuyOrderPayments.bordpayDocDateTime ?? wSBuyOrderPayments.ImportDateTime;
					if (wSspSelectBuyOrderById_Result.bordDateTime.HasValue && dateTime2.HasValue)
					{
						dateTime2 = DateTime.Parse(dateTime2.Value.ToString("yyyy/MM/dd"));
						DateTime dateTime3 = DateTime.Parse(wSspSelectBuyOrderById_Result.bordDateTime.Value.ToString("yyyy/MM/dd"));
						double totalDays = (dateTime2.Value - dateTime3).TotalDays;
						CS_0024_003C_003E8__locals0.vm.bordpayHeadingUpDay = int.Parse(Math.Round(totalDays).ToString());
						CS_0024_003C_003E8__locals0.vm.bordpayHeadingUpAmount = (decimal)CS_0024_003C_003E8__locals0.vm.bordpayHeadingUpDay.GetValueOrDefault() * wSBuyOrderPayments.bordpayAmount;
					}
				}
				wSBuyOrderPayments.bordpayHeadingUpDay = CS_0024_003C_003E8__locals0.vm.bordpayHeadingUpDay;
				wSBuyOrderPayments.bordpayHeadingUpAmount = CS_0024_003C_003E8__locals0.vm.bordpayHeadingUpAmount;
				if (CS_0024_003C_003E8__locals0.vm.BuyOrderPaymentId > 0)
				{
					_dbTbl.Entry(wSBuyOrderPayments).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					BuyOrder.CalcAndSetOrderAmounts(wSBuyOrderPayments.bordpayOrderId);
					if (!result)
					{
						using List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass6_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSBuyOrderPayments_Lang> wSBuyOrderPayments_Lang = _dbTbl.WSBuyOrderPayments_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderPayments_Lang), "c");
							WSBuyOrderPayments_Lang wSBuyOrderPayments_Lang2 = Queryable.FirstOrDefault<WSBuyOrderPayments_Lang>((IQueryable<WSBuyOrderPayments_Lang>)wSBuyOrderPayments_Lang, Expression.Lambda<Func<WSBuyOrderPayments_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass6_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass6_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSBuyOrderPayments_Lang2 != null)
							{
								wSBuyOrderPayments_Lang2.bordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSBuyOrderPayments_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSBuyOrderPayments_Lang2 = new WSBuyOrderPayments_Lang();
							wSBuyOrderPayments_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							wSBuyOrderPayments_Lang2.BuyOrderPaymentId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.vm.BuyOrderPaymentId;
							wSBuyOrderPayments_Lang2.bordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.WSBuyOrderPayments_Lang.Add(wSBuyOrderPayments_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					if (CS_0024_003C_003E8__locals0.vm.BuyOrderPaymentId != 0)
					{
						WSspSelectBuyOrderPaymentsWithId_Result wSspSelectBuyOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderPaymentsWithId_Result>((IEnumerable<WSspSelectBuyOrderPaymentsWithId_Result>)_dbII.WSspSelectBuyOrderPaymentsWithId(CS_0024_003C_003E8__locals0.vm.BuyOrderPaymentId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						if (wSspSelectBuyOrderPaymentsWithId_Result != null)
						{
							CS_0024_003C_003E8__locals0.vm.bordpayVerifier = wSspSelectBuyOrderPaymentsWithId_Result.bordpayVerifier ?? "";
							if (wSspSelectBuyOrderPaymentsWithId_Result.bordpayVerifiedRegisterDate.HasValue)
							{
								CS_0024_003C_003E8__locals0.vm.bordpayVerifier = CS_0024_003C_003E8__locals0.vm.bordpayVerifier ?? "";
							}
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					wSBuyOrderPayments.FPId = Financial.Get().Id;
					wSBuyOrderPayments.bordpayFirstRegisterUserId = currentUser.UserId;
					wSBuyOrderPayments.bordpayFirstRegisteDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSBuyOrderPayments.bordpayFirstRegisteDate = now;
					wSBuyOrderPayments.GUId = Guid.NewGuid();
					wSBuyOrderPayments.GUId = Guid.NewGuid();
					wSBuyOrderPayments.FirstRegisterUserId = currentUser.UserId;
					wSBuyOrderPayments.FirstRegisterDate = now;
					wSBuyOrderPayments.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSBuyOrderPayments.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					wSBuyOrderPayments.bordpayCId = BuyOrder.GetBordCId(wSBuyOrderPayments.bordpayOrderId);
					_dbTbl.WSBuyOrderPayments.Add(wSBuyOrderPayments);
					_dbTbl.SaveChanges();
					BuyOrder.CalcAndSetOrderAmounts(wSBuyOrderPayments.bordpayOrderId);
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSBuyOrderPayments_Lang wSBuyOrderPayments_Lang3 = new WSBuyOrderPayments_Lang();
						wSBuyOrderPayments_Lang3.LanguageID = lang.LanguageID;
						wSBuyOrderPayments_Lang3.BuyOrderPaymentId = wSBuyOrderPayments.BuyOrderPaymentId;
						wSBuyOrderPayments_Lang3.bordpayDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSBuyOrderPayments_Lang.Add(wSBuyOrderPayments_Lang3);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.AppType = wSBuyOrderPayments.AppType;
				CS_0024_003C_003E8__locals0.vm.UserId = wSBuyOrderPayments.UserId;
				CS_0024_003C_003E8__locals0.vm.bordpayFirstRegisteDate = wSBuyOrderPayments.bordpayFirstRegisteDate;
				CS_0024_003C_003E8__locals0.vm.bordpayFirstRegisterUserId = wSBuyOrderPayments.bordpayFirstRegisterUserId;
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
		else
		{
			string text2 = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + text2;
		}
		SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
		CS_0024_003C_003E8__locals0.vm.ImportDate = (CS_0024_003C_003E8__locals0.vm.ImportDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.bordpayDocDate = (CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.bordpayDocDateTemp = (CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp.HasValue ? CS_0024_003C_003E8__locals0.vm.bordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
		return View(CS_0024_003C_003E8__locals0.vm);
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
	[LoginAuthorize]
	public string Delete(int id, int borderId)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.id = id;
		string result = "";
		try
		{
			DbSet<WSBuyOrderPayments> wSBuyOrderPayments = _dbTbl.WSBuyOrderPayments;
			ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderPayments), "c");
			WSBuyOrderPayments wSBuyOrderPayments2 = Queryable.FirstOrDefault<WSBuyOrderPayments>((IQueryable<WSBuyOrderPayments>)wSBuyOrderPayments, Expression.Lambda<Func<WSBuyOrderPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSBuyOrderPayments2 != null)
			{
				try
				{
					if (BuyOrder.PayIsSentToLinkAccByAction(wSBuyOrderPayments2.BuyOrderPaymentId))
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
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSBuyOrderPayments(_003C_003Ec__DisplayClass8_.id)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							BuyOrder.CalcAndSetOrderAmounts(borderId);
							result = "";
						}
						else if (mct_Result != null && mct_Result.Result == 0)
						{
							result = Messages.RedundancyMessage;
						}
						transactionScope.Complete();
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
	public JsonResult GetBordPaymentType()
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
			List<WSspSelectBuyOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderPaymentTypes_Result>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)_db.WSspSelectBuyOrderPaymentTypes(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)list2, (Func<WSspSelectBuyOrderPaymentTypes_Result, SelectListItem>)((WSspSelectBuyOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.bordpayType,
				Value = item.BuyOrderPaymentTypeId.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public void SetRegisterInfo(WSBuyOrderPaymentsLanguageViewModel model)
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
			if (model.BuyOrderPaymentId > 0)
			{
				string text4 = (model.bordpayFirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
				_ = model.UserId;
				List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text4 + "," + model.UserId);
				if (model.bordpayFirstRegisterUserId == currentUser.UserId)
				{
					text = currentUser.FullName;
				}
				else if (list != null && Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
				{
					CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.bordpayFirstRegisterUserId));
					text = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				}
				if (model.UserId == currentUser.UserId)
				{
					text2 = currentUser.FullName;
				}
				else if (list != null && Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
				{
					CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
					text2 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actbordBuyOrderPaymentIndicator")]
	public ActionResult Indicator(int position = 0, int cmpId = 0, string cmpName = "")
	{
		string text = "";
		string text2 = "";
		if (position == 0)
		{
			text = "frmMain";
			text2 = "actbordBuyOrderPaymentIndicator";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			BuyOrderPaymentIndicatorViewModel model = new BuyOrderPaymentIndicatorViewModel
			{
				BordPayIndicatorCompanyId = cmpId.ToString(),
				BordPayIndicatorCompanyName = cmpName,
				BordPayIndicatorMonth = DateTime.Now.ToString("MM")
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
			FillDropdownBordPayIndicator();
			return View(model);
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	public JsonResult BuyOrderPayIndicator(BuyOrderPaymentIndicatorViewModel indicator)
	{
		JsonResult jsonResult = Json(BuyOrderPayIndicatorItem(indicator), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public IndicatorPatmentBuyOrderItem BuyOrderPayIndicatorItem(BuyOrderPaymentIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		IndicatorPatmentBuyOrderItem indicatorPatmentBuyOrderItem = new IndicatorPatmentBuyOrderItem();
		List<WSspSelectBuyOrderPaymentIndicator_Result> items = new List<WSspSelectBuyOrderPaymentIndicator_Result>();
		WSspSelectBuyOrderPaymentIndicatorSum_Result itemFooter = new WSspSelectBuyOrderPaymentIndicatorSum_Result();
		indicatorPatmentBuyOrderItem.Items = items;
		indicatorPatmentBuyOrderItem.ItemFooter = itemFooter;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.BordPayIndicatorMonth = ((indicator.BordPayIndicatorMonth != null && indicator.BordPayIndicatorMonth == "0") ? null : indicator.BordPayIndicatorMonth);
				string text = "0";
				if (!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorMonth) && indicator.BordPayIndicatorMonth != "0")
				{
					text = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + indicator.BordPayIndicatorMonth + "/01").ToString("yyyyMM", new CultureInfo("en-US"));
				}
				indicator.BordPayIndicatorDate = ((!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorDate)) ? indicator.BordPayIndicatorDate.Replace("/", "") : "");
				indicator.BordPayIndicatorFDate = ((!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorFDate)) ? indicator.BordPayIndicatorFDate.Replace("/", "") : "");
				indicator.BordPayIndicatorTDate = ((!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorTDate)) ? indicator.BordPayIndicatorTDate.Replace("/", "") : "");
				indicator.BordPayIndicatorMonth = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorMonth) ? "0" : ((lCID == 1025) ? text : (DateTime.Now.ToString("yyyy") + indicator.BordPayIndicatorMonth)));
				indicator.BordPayIndicatorBuyOrderNumber = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorBuyOrderNumber) ? "0" : indicator.BordPayIndicatorBuyOrderNumber);
				indicator.BordPayIndicatorCompanyId = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorCompanyId) ? "0" : indicator.BordPayIndicatorCompanyId);
				indicator.BordPayIndicatorTypeId = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorTypeId) ? "0" : indicator.BordPayIndicatorTypeId);
				if (!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorTypeIdMulti) && indicator.BordPayIndicatorTypeIdMulti != "0")
				{
					indicator.BordPayIndicatorTypeId = indicator.BordPayIndicatorTypeIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.BordPayIndicatorFDocDate = ((!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorFDocDate)) ? indicator.BordPayIndicatorFDocDate.Replace("/", "") : "");
				indicator.BordPayIndicatorTDocDate = ((!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorTDocDate)) ? indicator.BordPayIndicatorTDocDate.Replace("/", "") : "");
				indicator.BordPayIndicatorDocNumber = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorDocNumber) ? "0" : indicator.BordPayIndicatorDocNumber);
				indicator.BordPayIndicatorDescription = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorDescription) ? "0" : indicator.BordPayIndicatorDescription);
				indicator.BordPayIndicatorUserId = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorUserId) ? "0" : indicator.BordPayIndicatorUserId);
				indicator.BordPayIndicatorFirstRegisterUserId = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorFirstRegisterUserId) ? "0" : indicator.BordPayIndicatorFirstRegisterUserId);
				indicator.BordPayIndicatorReferUserId = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorReferUserId) ? "0" : indicator.BordPayIndicatorReferUserId);
				indicator.BordPayIndicatorDeActive = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorDeActive) ? "0" : indicator.BordPayIndicatorDeActive);
				indicator.BordPayIndicatorHaveLinkAcc = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorHaveLinkAcc) ? "0" : indicator.BordPayIndicatorHaveLinkAcc);
				indicator.BordPayIndicatorIsVerified = (string.IsNullOrWhiteSpace(indicator.BordPayIndicatorIsVerified) ? "0" : indicator.BordPayIndicatorIsVerified);
				indicator.LinkAccSettingDBId = indicator.LinkAccSettingDBId.GetValueOrDefault();
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				if (!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordPayIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordPayIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordPayIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorFDocDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordPayIndicatorFDocDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.BordPayIndicatorTDocDate))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordPayIndicatorTDocDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				items = Enumerable.ToList<WSspSelectBuyOrderPaymentIndicator_Result>((IEnumerable<WSspSelectBuyOrderPaymentIndicator_Result>)_dbI.WSspSelectBuyOrderPaymentIndicator(indicator.BordPayIndicatorDate, value, indicator.BordPayIndicatorFDate, indicator.BordPayIndicatorTDate, value2, value3, indicator.BordPayIndicatorMonth, indicator.BordPayIndicatorCompanyId, indicator.BordPayIndicatorBuyOrderNumber, indicator.BordPayIndicatorTypeId, indicator.BordPayIndicatorAmount.ToString(), indicator.BordPayIndicatorFDocDate, indicator.BordPayIndicatorTDocDate, value4, value5, indicator.BordPayIndicatorDocNumber, indicator.BordPayIndicatorDocAmount.ToString(), indicator.BordPayIndicatorDescription, indicator.BordPayIndicatorFirstRegisterUserId, indicator.BordPayIndicatorUserId, indicator.BordPayIndicatorReferUserId, indicator.BordPayIndicatorDeActive, payIsVerified: indicator.BordPayIndicatorIsVerified, haveLinkAcc: indicator.BordPayIndicatorHaveLinkAcc, rptUserId: UserLogin.CurrentUser.UserId, rptDate: DateTime.Now.ToString("yyyy/MM/dd"), rptDay: DefineDayeOfWeekFa(dayOfWeek.ToString()), languageID: lCID, defaultLanguageID: result, linkAccSettingDBId: indicator.LinkAccSettingDBId, centerId: result2));
				if (Enumerable.Any<WSspSelectBuyOrderPaymentIndicator_Result>((IEnumerable<WSspSelectBuyOrderPaymentIndicator_Result>)items))
				{
					itemFooter = Enumerable.FirstOrDefault<WSspSelectBuyOrderPaymentIndicatorSum_Result>((IEnumerable<WSspSelectBuyOrderPaymentIndicatorSum_Result>)_dbI.WSspSelectBuyOrderPaymentIndicatorSum(indicator.BordPayIndicatorDate, value, indicator.BordPayIndicatorFDate, indicator.BordPayIndicatorTDate, value2, value3, indicator.BordPayIndicatorMonth, indicator.BordPayIndicatorCompanyId, indicator.BordPayIndicatorBuyOrderNumber, indicator.BordPayIndicatorTypeId, indicator.BordPayIndicatorAmount.ToString(), indicator.BordPayIndicatorFDocDate, indicator.BordPayIndicatorTDocDate, value4, value5, indicator.BordPayIndicatorDocNumber, indicator.BordPayIndicatorDocAmount.ToString(), indicator.BordPayIndicatorDescription, indicator.BordPayIndicatorFirstRegisterUserId, indicator.BordPayIndicatorUserId, indicator.BordPayIndicatorReferUserId, indicator.BordPayIndicatorDeActive, indicator.BordPayIndicatorIsVerified, indicator.BordPayIndicatorHaveLinkAcc, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DefineDayeOfWeekFa(dayOfWeek.ToString()), lCID, result, indicator.LinkAccSettingDBId, result2));
				}
				foreach (WSspSelectBuyOrderPaymentIndicator_Result item in items)
				{
					item.ImportDate = (item.ImportDateTime.HasValue ? item.ImportDateTime.Value.ToString("yyyyMMdd") : item.ImportDate);
					_ = item.RegisterDate;
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyyMMdd");
					item.bordDate = (item.bordDateTime.HasValue ? item.bordDateTime.Value.ToString("yyyyMMdd") : item.bordDate);
					item.bordpayDocDate = (item.bordpayDocDateTime.HasValue ? item.bordpayDocDateTime.Value.ToString("yyyyMMdd") : item.bordpayDocDate);
					item.bordpayFirstRegisteDatePersian = (item.bordpayFirstRegisteDate.HasValue ? item.bordpayFirstRegisteDate.Value.ToString("yyyyMMdd") : item.bordpayFirstRegisteDatePersian);
					item.bordpayDocDateTemp = (item.bordpayDocDateTimeTemp.HasValue ? item.bordpayDocDateTimeTemp.Value.ToString("yyyyMMdd") : item.bordpayDocDateTemp);
					item.bordpayVerifiedRegisterDatePersian = (item.bordpayVerifiedRegisterDate.HasValue ? item.bordpayVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm;ss") : "");
				}
				indicatorPatmentBuyOrderItem.Items = items;
				indicatorPatmentBuyOrderItem.ItemFooter = itemFooter;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return indicatorPatmentBuyOrderItem;
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

	private void FillDropdownBordPayIndicator()
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
			List<WSspSelectBuyOrderReferUsers_Result> list = Enumerable.ToList<WSspSelectBuyOrderReferUsers_Result>((IEnumerable<WSspSelectBuyOrderReferUsers_Result>)_db.WSspSelectBuyOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list2.AddRange(Enumerable.Select<WSspSelectBuyOrderReferUsers_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderReferUsers_Result>)list, (Func<WSspSelectBuyOrderReferUsers_Result, SelectListItem>)((WSspSelectBuyOrderReferUsers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
			base.ViewBag.UserList = list2;
			List<WSspSelectBuyOrderPaymentTypes_Result> list3 = Enumerable.ToList<WSspSelectBuyOrderPaymentTypes_Result>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)_db.WSspSelectBuyOrderPaymentTypes(lCID, result));
			List<SelectListItem> list4 = new List<SelectListItem>();
			list4.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list4.AddRange(Enumerable.Select<WSspSelectBuyOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)list3, (Func<WSspSelectBuyOrderPaymentTypes_Result, SelectListItem>)((WSspSelectBuyOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.bordpayType,
				Value = item.BuyOrderPaymentTypeId.ToString(),
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
	public JsonResult GetBordPayCompany(string value = "")
	{
		List<WSspBuyOrderPaymentIndicatorCmpSearch_Result> list = new List<WSspBuyOrderPaymentIndicatorCmpSearch_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspBuyOrderPaymentIndicatorCmpSearch_Result>((IEnumerable<WSspBuyOrderPaymentIndicatorCmpSearch_Result>)_dbI.WSspBuyOrderPaymentIndicatorCmpSearch(value, lCID, result));
			if (list == null)
			{
				list = new List<WSspBuyOrderPaymentIndicatorCmpSearch_Result>();
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
			List<WSspSelectBuyOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderPaymentTypes_Result>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)_db.WSspSelectBuyOrderPaymentTypes(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderPaymentTypes_Result, CrmDroupDownItem>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)list2, (Func<WSspSelectBuyOrderPaymentTypes_Result, CrmDroupDownItem>)((WSspSelectBuyOrderPaymentTypes_Result item) => new CrmDroupDownItem
			{
				text = item.bordpayType,
				value = item.BuyOrderPaymentTypeId.ToString()
			})));
			if (list == null)
			{
				list = new List<CrmDroupDownItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
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
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<WSspSelectBuyOrderReferUsers_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderReferUsers_Result>((IEnumerable<WSspSelectBuyOrderReferUsers_Result>)_db.WSspSelectBuyOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderReferUsers_Result, CrmDroupDownItem>((IEnumerable<WSspSelectBuyOrderReferUsers_Result>)list2, (Func<WSspSelectBuyOrderReferUsers_Result, CrmDroupDownItem>)((WSspSelectBuyOrderReferUsers_Result item) => new CrmDroupDownItem
			{
				text = item.UserName,
				value = item.UserId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public ActionResult BuyOrderPayIndicator_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		BuyOrderPaymentIndicatorViewModel indicator2 = new JavaScriptSerializer().Deserialize<BuyOrderPaymentIndicatorViewModel>(indicator);
		IndicatorPatmentBuyOrderItem indicatorPatmentBuyOrderItem = BuyOrderPayIndicatorItem(indicator2);
		JsonResult jsonResult = Json(((IEnumerable)indicatorPatmentBuyOrderItem.Items).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string PaymentVerify(int payId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmBuyOrder", "actVerifyPayBuyOrder", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_dbIII.WSspBuyOrderPaymentVerify(payId, userId, now, registerDatePersian);
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
		if (!UserLogin.IsUserAccess("frmBuyOrder", "actExitVerifyPayBuyOrder", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbIII.WSspBuyOrderPaymentVerifyExit(payId);
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
		if (!UserLogin.IsUserAccess("frmBuyOrder", "actCanceledPay", currentUser))
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
			_dbIII.WSspBuyOrderPaymentDeActive(payId, userId, value, text);
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
		if (!UserLogin.IsUserAccess("frmBuyOrder", "actExitCanceledPay", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbIII.WSspBuyOrderPaymentDeActiveExit(payId);
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
