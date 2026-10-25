using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.General.Text;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.BankMellat;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.Classes.Helper.ParsianPGWConfirmPaymentServices;
using CRMIdeal.Classes.Helper.ParsianPGWSalePaymentServices;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.ZarinPal;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.OnlinePayment.Controllers;

public class HomeController : Controller
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static RemoteCertificateValidationCallback _003C_003E9__25_0;

		internal bool _003CMobPayment_003Eb__25_0(object o, X509Certificate xc, X509Chain xch, SslPolicyErrors sslP)
		{
			return true;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private const string SaleLoginAccountSessionKey = "SaleLoginAccount";

	private const string ConfirmAfterPaymentSessionKey = "ConfirmAfterPayment";

	private const string ConfirmServiceUrlSessionKey = "ConfirmServiceUrl";

	private const string ReversalServiceUrlSessionKey = "ReversalServiceUrl";

	private ParsianPaymentCallbackViewModel _parsianPaymentCallbackViewModel;

	private PasargadV2CallBackViewModel _pasargadCallBackViewModel;

	private MellatCallBackViewModel _mellatCallBackViewModel;

	private ZarinPalCallBackViewModel _zarinPalCallBackViewModel;

	private SamanBankCallBackViewModelI _samanBankCallBackViewModel;

	private BinaPaySharifCallBackViewModel _binaPaySharifCallBackViewModel;

	public string GetMellatRequestResult(string val = "")
	{
		string text = "";
		return val switch
		{
			"11" => "شماره کارت نا معتبر", 
			"12" => "موجودی کافي نيست", 
			"13" => "رمز نادرست است", 
			"14" => "تعداد دفعات وارد کردن رمز بيش از حد مجاز است", 
			"15" => "کارت نامعتبر است", 
			"16" => "دفعات برداشت وجه بيش از حد مجاز است", 
			"17" => "کاربر از انجام تراکنش منصرف شده است", 
			"18" => "تاريخ انقضای کارت گذشته است", 
			"19" => "مبلغ برداشت وجه بيش از حد مجاز است", 
			"21" => "پذيرنده نامعتبر است", 
			"23" => "خطای امنيتي رخ داده است", 
			"24" => "اطالعات کاربری پذيرنده نامعتبر است", 
			"25" => "مبلغ نامعتبر است", 
			"31" => "پاسخ نامعتبر است", 
			"32" => "فرمت اطالعات وارد شده صحيح نمي باشد", 
			"33" => "حساب نامعتبر است", 
			"34" => "خطای سيستمي", 
			"35" => "تاريخ نامعتبر است", 
			"41" => "شماره درخواست تکراری است", 
			"42" => "تراکنش Sale يافت نشد", 
			"43" => "قبال درخواست Verify داده شده است", 
			"44" => "درخواست Verfiy يافت نشد", 
			"45" => "تراکنش Settle شده است", 
			"46" => "تراکنش Settle نشده است", 
			"47" => "تراکنش Settle يافت نشد", 
			"48" => "تراکنش Reverse شده است", 
			"51" => "تراکنش تکراری است", 
			"54" => "تراکنش مرجع موجود نيست", 
			"55" => "تراکنش نامعتبر است", 
			"61" => "خطا در واريز", 
			"62" => "مسير بازگشت به سايت در دامنه ثبت شده برای پذيرنده قرار ندارد.", 
			"98" => "سقف استفاده از رمز ايستا به پايان رسيده است.", 
			"111" => "صادر کننده کارت نامعتبر است", 
			"112" => "خطای سوييچ صادر کننده کارت", 
			"113" => "پاسخي از صادر کننده کارت دريافت نشد", 
			"114" => "دارنده کارت مجاز به انجام اين تراکنش نيست", 
			"412" => "شناسه قبض نادرست است", 
			"413" => "شناسه پرداخت نادرست است", 
			"414" => "سازمان صادر کننده قبض نامعتبر است", 
			"415" => "زمان جلسه کاری به پايان رسيده است", 
			"416" => "خطا در ثبت اطالعات", 
			"417" => "شناسه پرداخت کننده نامعتبر است", 
			"418" => "اشکال در تعريف اطالعات مشتری", 
			"419" => "تعداد دفعات ورود اطالعات از حد مجاز گذشته است", 
			"421" => "IP نامعتبر است", 
			_ => "", 
		};
	}

	public void InsertPayment(decimal payAmount, string payDocNumber, string payDescription, int bankOrdPayTypeId = 0, int bankPordPayTypeId = 0, int? cId = null, int? foSettingId = null)
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0833: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			string registerTime = now.ToString("HH:mm:ss");
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string text2 = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
			string appType = "mob";
			int id = Financial.Get().Id;
			int result = -20;
			int result2 = 0;
			int result3 = 0;
			int result4 = 0;
			int result5 = 0;
			new HttpCookie("ShopOnlinePaymentOpr");
			if (base.Request.Cookies["ShopOnlinePaymentOpr"] != null)
			{
				string value3 = base.Request.Cookies["ShopOnlinePaymentOpr"].Value;
				if (!string.IsNullOrWhiteSpace(value3))
				{
					string[] array = value3.Split(new char[1] { '|' });
					if (array != null && array.Length >= 4)
					{
						int.TryParse(array[0], out result3);
						int.TryParse(array[1], out result2);
						int.TryParse(array[2], out result4);
						int.TryParse(array[3], out result5);
					}
				}
			}
			int result6 = 0;
			long result7 = 0L;
			new HttpCookie("ShpOrdeId");
			if (base.Request.Cookies["ShpOrdeId"] != null)
			{
				string value4 = base.Request.Cookies["ShpOrdeId"].Value;
				if (!string.IsNullOrWhiteSpace(value4))
				{
					string[] array2 = value4.Split(new char[1] { '|' });
					if (array2 != null && array2.Length >= 2)
					{
						int.TryParse(array2[0], out result6);
						long.TryParse(array2[1], out result7);
					}
				}
			}
			int result8 = 0;
			long result9 = 0L;
			new HttpCookie("ShpPreOrdeId");
			if (base.Request.Cookies["ShpPreOrdeId"] != null)
			{
				string value5 = base.Request.Cookies["ShpPreOrdeId"].Value;
				if (!string.IsNullOrWhiteSpace(value5))
				{
					string[] array3 = value5.Split(new char[1] { '|' });
					if (array3 != null && array3.Length >= 2)
					{
						int.TryParse(array3[0], out result8);
						long.TryParse(array3[1], out result9);
					}
				}
			}
			if (base.Request.Cookies["ShopOnlinePaymentUserId"] != null)
			{
				new HttpCookie("ShopOnlinePaymentUserId");
				int.TryParse(base.Request.Cookies["ShopOnlinePaymentUserId"].Value ?? "-20", out result);
			}
			string text3 = "";
			new HttpCookie("ShopOrderListOrdIssued");
			if (base.Request.Cookies["ShopOrderListOrdIssued"] != null)
			{
				HttpCookie obj = base.Request.Cookies["ShopOrderListOrdIssued"];
				text3 = obj.Value;
				base.Response.Cookies.Remove("ShopOrderListOrdIssued");
				obj.Expires = DateTime.Now.AddYears(-1);
			}
			string text4 = "";
			string text5 = "";
			List<CommonMultiLanguageViewModel> list = CRMIdeal.Classes.Helper.OnlinePayment.CreatePayDescWhenToBank();
			if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
			{
				text4 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == defLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == defLangId)).Value : "");
				text5 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId))));
			}
			bool result10 = false;
			bool result11 = false;
			bool result12 = false;
			int result13 = 0;
			int result14 = 0;
			int result15 = 0;
			int num = 0;
			int result16 = 0;
			int result17 = 0;
			CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
			if (foSetting != null)
			{
				bool.TryParse(foSetting.ShpPrdDoneTimeScheduleActive.ToString(), out result10);
				bool.TryParse(foSetting.ShpCartIssuePordAfterPayOnLine.ToString(), out result11);
				bool.TryParse(foSetting.ShpCartIssueOrdAfterPayOnLine.ToString(), out result12);
				int.TryParse(foSetting.ShpDefPordVerifierRequestId.ToString(), out result17);
				int.TryParse(foSetting.ShpDefOrdVerifierRequestId.ToString(), out result16);
				int.TryParse(foSetting.ShpDefOrderOprId.ToString(), out result13);
				int.TryParse(foSetting.ShpDefOrdpayTypeId.ToString(), out result14);
				int.TryParse(foSetting.ShpDefPordPayTypeId.ToString(), out result15);
			}
			if (bankPordPayTypeId != 0)
			{
				result15 = bankPordPayTypeId;
			}
			if (bankOrdPayTypeId != 0)
			{
				result14 = bankOrdPayTypeId;
			}
			switch (result3)
			{
			case 1:
			case 10:
				num = result15;
				break;
			case 2:
			case 20:
				num = result14;
				break;
			}
			if (!result10)
			{
				if (result2 <= 0 || num <= 0)
				{
					return;
				}
				int num2 = result4;
				if (num2 != 0)
				{
					_dbII.WSspUpdatePreOrderPayment(result2, num2, payAmount, payDocNumber, payDescription, text, payAmount, value, result, value, text, id, value2, appType, lCID, defLangId, text4, text5);
				}
				int preOrderId = result2;
				int num3 = 0;
				long preOrderNumber = 0L;
				List<WSspReturnOrderFromPreOrder_Result> list2 = Enumerable.ToList<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)_db.WSspReturnOrderFromPreOrder(result2, lCID, defLangId));
				if (list2 != null && Enumerable.Any<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)list2))
				{
					WSspReturnOrderFromPreOrder_Result wSspReturnOrderFromPreOrder_Result = Enumerable.FirstOrDefault<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)list2);
					if (wSspReturnOrderFromPreOrder_Result != null)
					{
						num3 = wSspReturnOrderFromPreOrder_Result.OrderID;
					}
				}
				if (num3 != 0)
				{
					_dbII.WSspUpdateOrderPayment(num3, num2, payAmount, payDocNumber, payDescription, text, payAmount, value, result, value, text, id, value2, appType, lCID, defLangId, text4, text5);
				}
				RunEventAfterPayment(payAmount, payDocNumber, payDescription, num2, ref preOrderId, ref preOrderNumber, result, num3, bankPordPayTypeId);
				return;
			}
			if (result11)
			{
				RunEventPreOrder(result8, result15, payAmount, payDocNumber, payDescription);
			}
			if (!result12)
			{
				return;
			}
			bool addPay = false;
			if (result6 == 0 && result2 > 0 && result13 > 0)
			{
				ObjectParameter objectParameter = new ObjectParameter("error", "");
				ObjectParameter objectParameter2 = new ObjectParameter("orderId", typeof(int));
				ObjectParameter objectParameter3 = new ObjectParameter("ordNumber", typeof(long));
				ObjectParameter objectParameter4 = new ObjectParameter("ordIssuedJson", "");
				CRMSpIIEntities dbII = _dbII;
				int? preOrderId2 = result2;
				int? orderOprId = result13;
				decimal? ordpayAmount = payAmount;
				int? ordpayTypeId = result14;
				DateTime? registerDate = value;
				string registerDay = text2;
				int? fPId = id;
				short? month = value2;
				int? languageID = lCID;
				int? defaultLanguageID = defLangId;
				ObjectParameter orderId = objectParameter2;
				dbII.CRMSHPMobspIssueOrderFromPreOrder(preOrderId2, orderOprId, ordpayAmount, ordpayTypeId, payDocNumber, payDescription, registerDate, text, registerTime, registerDay, fPId, month, appType, languageID, defaultLanguageID, objectParameter, objectParameter3, orderId, (result16 != 0) ? new int?(result16) : null, objectParameter4, cId, foSettingId);
				if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
				{
					Exception e = new Exception(Messages.FOMsgErrorInIssueOrder + " (" + objectParameter.Value.ToString() + ")");
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (objectParameter2.Value != null)
				{
					int.TryParse(objectParameter2.Value.ToString(), out result6);
				}
				if (objectParameter3.Value != null)
				{
					long.TryParse(objectParameter3.Value.ToString(), out result7);
				}
				if (objectParameter4 != null && objectParameter4.Value != null && !string.IsNullOrWhiteSpace(objectParameter4.Value.ToString()))
				{
					text3 = objectParameter4.Value.ToString();
				}
			}
			else if (result6 > 0 && bankPordPayTypeId != 0 && payAmount > 0m)
			{
				addPay = true;
			}
			bool flag = false;
			if (!string.IsNullOrWhiteSpace(text3))
			{
				List<OrderJsonViewModel> list3 = new JavaScriptSerializer().Deserialize<List<OrderJsonViewModel>>(text3);
				if (list3 != null && Enumerable.Any<OrderJsonViewModel>((IEnumerable<OrderJsonViewModel>)list3))
				{
					foreach (OrderJsonViewModel item in list3)
					{
						int result18 = 0;
						int.TryParse(item.OrderId.ToString(), out result18);
						if (result18 != 0)
						{
							RunEventOrder(result18, result14, payAmount, payDocNumber, payDescription, addPay, text3);
							if (!flag)
							{
								flag = true;
							}
						}
					}
				}
			}
			if (result6 > 0 && !flag)
			{
				RunEventOrder(result6, result14, payAmount, payDocNumber, payDescription, addPay, text3);
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
	}

	public bool RunEventAfterPayment(decimal payAmount, string payDocNumber, string payDescription, int oldPordPayId, ref int preOrderId, ref long preOrderNumber, int userId, int orderId, int bankPordPayTypeId = 0, int pordRefUserId = 0)
	{
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			now.ToString("HH:mm:ss");
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Financial.Get().Id;
			CRMspSelectMobSetting_Result cRMspSelectMobSetting_Result = Enumerable.FirstOrDefault<CRMspSelectMobSetting_Result>((IEnumerable<CRMspSelectMobSetting_Result>)_dbII.CRMspSelectMobSetting(lCID, result2));
			int num = preOrderId;
			long num2 = 0L;
			int num3 = 0;
			num3 = oldPordPayId;
			int result3 = 0;
			bool flag = false;
			if (cRMspSelectMobSetting_Result != null)
			{
				flag = cRMspSelectMobSetting_Result.PordIssueOrdAfterOnLinePay.GetValueOrDefault();
				int.TryParse(cRMspSelectMobSetting_Result.DefPordVerifierRequestId.ToString(), out result3);
			}
			bool result4 = false;
			bool result5 = false;
			int result6 = 0;
			CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
			if (foSetting != null)
			{
				bool.TryParse(foSetting.ShpCartIssuePordAfterPayOnLine.ToString(), out result4);
				bool.TryParse(foSetting.ShpCartIssueOrdAfterPayOnLine.ToString(), out result5);
				int.TryParse(foSetting.ShpDefOrdVerifierRequestId.ToString(), out result6);
			}
			flag = result5;
			if (num > 0)
			{
				SHPspSelectPreOrderWithId_Result sHPspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<SHPspSelectPreOrderWithId_Result>((IEnumerable<SHPspSelectPreOrderWithId_Result>)_db.SHPspSelectPreOrderWithId(num, lCID, result2));
				if (sHPspSelectPreOrderWithId_Result != null)
				{
					sHPspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
					sHPspSelectPreOrderWithId_Result.pordCompanyPersonId.GetValueOrDefault();
					sHPspSelectPreOrderWithId_Result.pordProjectId.GetValueOrDefault();
					num2 = sHPspSelectPreOrderWithId_Result.pordNumber;
					pordRefUserId = sHPspSelectPreOrderWithId_Result.pordReferUserId.GetValueOrDefault();
				}
			}
			if (num > 0)
			{
				if (bankPordPayTypeId != 0 && payAmount > 0m && oldPordPayId == 0)
				{
					RunEventInsertPayment(num, bankPordPayTypeId, payAmount, payDocNumber, payDescription, userId, ref num3);
				}
				if (flag && orderId == 0)
				{
					InsertOrderFromPreOrder(num, userId, pordRefUserId);
				}
				new InternalMessage().SendInternalMessage(0, Labels.ShopSuccessPaymentTitle, Labels.ShopSuccessPaymentMsg.Replace("{1}", num2.ToString()), 5, userId, result3, now.ToString("yyyyMMdd", new PersianCulture()), now.ToString("HH:mm:ss"), 0, "", null, Messages.ConversationErjaShow, 0, result2, "", "", userId);
				preOrderId = num;
				preOrderNumber = num2;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void RunEventInsertPayment(int objectId, int payTypeId, decimal payAmount, string payDocNumber, string payDescription, int loginUserId, ref int pordPayId)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			now.ToString("HH:mm:ss");
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = "mob";
			int id = Financial.Get().Id;
			int result2 = loginUserId;
			if (base.Request.Cookies["ShopOnlinePaymentUserId"] != null)
			{
				new HttpCookie("ShopOnlinePaymentUserId");
				int.TryParse(base.Request.Cookies["ShopOnlinePaymentUserId"].Value ?? "-20", out result2);
			}
			if (objectId > 0 && payTypeId > 0)
			{
				ObjectParameter objectParameter = new ObjectParameter("InsertedId", typeof(int));
				_dbII.WSspInsertPreOrderPayment(objectId, payTypeId, payAmount, payDocNumber, payDescription, result2, value, registerDatePersian, id, value2, appType, lCID, result, objectParameter, payAmount, null);
				if (objectParameter != null && objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out pordPayId);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public bool InsertOrderFromPreOrder(int preOrderId, int loginUserId, int referUser)
	{
		DateTime now = DateTime.Now;
		string text = now.ToString("yyyyMMdd", new PersianCulture());
		now.ToString("yyyyMMdd", new PersianCulture());
		short.Parse(now.ToString("MM", new PersianCulture()));
		short.Parse(Financial.Get().Id.ToString());
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		ObjectParameter objectParameter = new ObjectParameter("InsertedOrderID", typeof(int));
		ObjectParameter objectParameter2 = new ObjectParameter("insertedOrderNumber", typeof(long));
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
		if (foSetting != null)
		{
			int result3 = 0;
			int result4 = 0;
			bool result5 = false;
			int.TryParse(foSetting.ShpDefOrderOprId.ToString(), out result3);
			int.TryParse(foSetting.ShpDefOrdPrintFormatId.ToString(), out result4);
			bool.TryParse(foSetting.ShpCartIssueOrdAfterPayOnLine.ToString(), out result5);
			if (result5)
			{
				_db.WSspIssueOrderFromPreOrder(preOrderId, text.ToString(), result3, result4, referUser, loginUserId, short.Parse(now.ToString("MM", new PersianCulture())), Financial.Get().Id, now.ToString("yyyyMMdd", new PersianCulture()), "mob", null, null, 0, objectParameter, objectParameter2, result, null, null, null, null, null, null, null, null, (result2 != 0) ? new int?(result2) : null);
				int num = int.Parse(objectParameter.Value.ToString());
				int num2 = int.Parse(objectParameter2.Value.ToString());
				if (num > 0 && num2 > 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private string GetLoginAccount()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		int result = 0;
		if (base.Request.Cookies["ShopOnlinePayBankInfoId"] != null)
		{
			new HttpCookie("ShopOnlinePayBankInfoId");
			int.TryParse(base.Request.Cookies["ShopOnlinePayBankInfoId"].Value, out result);
		}
		CRMspSelectOnlinePayBankInfoByName_Result cRMspSelectOnlinePayBankInfoByName_Result = new CRMspSelectOnlinePayBankInfoByName_Result();
		cRMspSelectOnlinePayBankInfoByName_Result = ((result == 0) ? null : CRMIdeal.Classes.Helper.OnlinePayment.GetOnlinePayBankInfo(result, ""));
		if (cRMspSelectOnlinePayBankInfoByName_Result == null)
		{
			cRMspSelectOnlinePayBankInfoByName_Result = CRMIdeal.Classes.Helper.OnlinePayment.GetOnlinePayBankInfo(0, "بانک پارسیان");
		}
		if (cRMspSelectOnlinePayBankInfoByName_Result != null)
		{
			text = cRMspSelectOnlinePayBankInfoByName_Result.BankLoginAccount ?? "";
		}
		string text2 = text;
		base.Session["SaleLoginAccount"] = text2;
		return base.Session["SaleLoginAccount"].ToString();
	}

	public bool RunEventPreOrder(int pordId, int bankPayTypeId = 0, decimal payAmount = 0m, string payDocNumber = "", string payDescription = "", bool addCmpMonyBag = false)
	{
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			now.ToString("HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = Financial.Get().Id;
			CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
			if (foSetting != null)
			{
				long num = 0L;
				_ = foSetting.FoSettingId;
				int result3 = 0;
				int.TryParse(foSetting.ShpDefWHId.ToString(), out result3);
				int result4 = 0;
				int.TryParse(foSetting.ShpDefPrjcnvsStatusGroupId.ToString(), out result4);
				int result5 = 0;
				int.TryParse(foSetting.ShpDefCurrencyUnitId.ToString(), out result5);
				int result6 = 0;
				int.TryParse(foSetting.ShpDefPordExpireDay.ToString(), out result6);
				int result7 = 0;
				int.TryParse(foSetting.ShpDefPordVerifierRequestId.ToString(), out result7);
				bool result8 = false;
				bool.TryParse(foSetting.ShpCartIssuePordAfterPayOnLine.ToString(), out result8);
				int result9 = 0;
				int.TryParse(foSetting.ShpDefPordPayTypeId.ToString(), out result9);
				int result10 = 0;
				int.TryParse(foSetting.ShpDefPordVerifyWorkFlowId.ToString(), out result10);
				bool result11 = false;
				bool.TryParse(foSetting.ShpPordVerifyWorkFlowStartAfterIssue.ToString(), out result11);
				bool result12 = false;
				bool.TryParse(foSetting.ShpPordSendSmsAfterIssue.ToString(), out result12);
				bool result13 = false;
				bool.TryParse(foSetting.ShpPordSendSmsAfterIssueGSM.ToString(), out result13);
				int result14 = 0;
				int.TryParse(foSetting.ShpDefPordSendSmsAfterIssueGSMSetId.ToString(), out result14);
				bool result15 = false;
				bool.TryParse(foSetting.ShpPordSendSmsAfterIssueWeb.ToString(), out result15);
				int result16 = 0;
				int.TryParse(foSetting.ShpDefPordSendSmsAfterIssueProviderId.ToString(), out result16);
				_ = foSetting.ShpDefPordSendSmsAfterIssueNumber;
				_ = foSetting.ShpDefPordSendSmsAfterIssueBodyPatternFormula;
				bool result17 = false;
				bool.TryParse(foSetting.ShpPordSendEmailAfterIssue.ToString(), out result17);
				int result18 = 0;
				int.TryParse(foSetting.ShpDefPordSendEmailAfterIssueSettingId.ToString(), out result18);
				int result19 = 0;
				int.TryParse(foSetting.ShpDefPordSendEmailAfterIssueUserInfoId.ToString(), out result19);
				_ = foSetting.ShpDefPordSendEmailAfterIssueSubjectPatternFormula;
				_ = foSetting.ShpDefPordSendEmailAfterIssueBodyPatternFormula;
				if (bankPayTypeId != 0)
				{
					result9 = bankPayTypeId;
				}
				WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result2));
				if (wSspSelectPreOrderWithId_Result != null)
				{
					wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
					wSspSelectPreOrderWithId_Result.pordCompanyPersonId.GetValueOrDefault();
					wSspSelectPreOrderWithId_Result.pordProjectId.GetValueOrDefault();
					num = wSspSelectPreOrderWithId_Result.pordNumber;
				}
				if (pordId > 0)
				{
					if (result9 != 0 && payAmount > 0m)
					{
						InsertPaymentWithTiming(pordId, 10, result9, payAmount, payDocNumber, payDescription, "", addCmpMonyBag);
					}
					new InternalMessage().SendInternalMessage(0, Labels.ShopSuccessPaymentTitle, Labels.ShopSuccessPaymentMsg.Replace("{1}", num.ToString()), 5, -20, result7, now.ToString("yyyyMMdd", new PersianCulture()), now.ToString("HH:mm:ss"), 0, "", null, Messages.ConversationErjaShow, 0, result2, "", "", -20);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public bool RunEventOrder(int ordId, int bankPayTypeId = 0, decimal payAmount = 0m, string payDocNumber = "", string payDescription = "", bool addPay = false, string listOrdIssued = "", bool addCmpMonyBag = false)
	{
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			now.ToString("HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = Financial.Get().Id;
			CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
			if (foSetting != null)
			{
				_ = foSetting.FoSettingId;
				int result3 = 0;
				int.TryParse(foSetting.ShpDefWHId.ToString(), out result3);
				int result4 = 0;
				int.TryParse(foSetting.ShpDefPrjcnvsStatusGroupId.ToString(), out result4);
				int result5 = 0;
				int.TryParse(foSetting.ShpDefCurrencyUnitId.ToString(), out result5);
				bool result6 = false;
				bool.TryParse(foSetting.ShpCartIssueOrdAfterPayOnLine.ToString(), out result6);
				int result7 = 0;
				int.TryParse(foSetting.ShpDefOrderOprId.ToString(), out result7);
				int result8 = 0;
				int.TryParse(foSetting.ShpDefOrdpayTypeId.ToString(), out result8);
				int result9 = 0;
				int.TryParse(foSetting.ShpDefOrdVerifierRequestId.ToString(), out result9);
				int result10 = 0;
				int.TryParse(foSetting.ShpDefOrdReferUserId.ToString(), out result10);
				int result11 = 0;
				int.TryParse(foSetting.ShpDefOrdVerifyWorkFlowId.ToString(), out result11);
				bool result12 = false;
				bool.TryParse(foSetting.ShpOrdVerifyWorkFlowStartAfterIssue.ToString(), out result12);
				bool result13 = false;
				bool.TryParse(foSetting.ShpOrdSendSmsAfterIssue.ToString(), out result13);
				bool result14 = false;
				bool.TryParse(foSetting.ShpOrdSendSmsAfterIssueGSM.ToString(), out result14);
				int result15 = 0;
				int.TryParse(foSetting.ShpDefOrdSendSmsAfterIssueGSMSetId.ToString(), out result15);
				bool result16 = false;
				bool.TryParse(foSetting.ShpOrdSendSmsAfterIssueWeb.ToString(), out result16);
				int result17 = 0;
				int.TryParse(foSetting.ShpDefOrdSendSmsAfterIssueProviderId.ToString(), out result17);
				_ = foSetting.ShpDefOrdSendSmsAfterIssueNumber;
				_ = foSetting.ShpDefOrdSendSmsAfterIssueBodyPatternFormula;
				bool result18 = false;
				bool.TryParse(foSetting.ShpOrdSendEmailAfterIssue.ToString(), out result18);
				int result19 = 0;
				int.TryParse(foSetting.ShpDefOrdSendEmailAfterIssueSettingId.ToString(), out result19);
				int result20 = 0;
				int.TryParse(foSetting.ShpDefOrdSendEmailAfterIssueUserInfoId.ToString(), out result20);
				_ = foSetting.ShpDefOrdSendEmailAfterIssueSubjectPatternFormula;
				_ = foSetting.ShpDefOrdSendEmailAfterIssueBodyPatternFormula;
				bool result21 = false;
				bool.TryParse(foSetting.ShpOrdSendLinkAccAfterIssue.ToString(), out result21);
				if (bankPayTypeId != 0)
				{
					result8 = bankPayTypeId;
				}
				WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(ordId, lCID, result2));
				if (wSspSelectOrderById_Result != null)
				{
					_ = wSspSelectOrderById_Result.ordCompanyId;
					wSspSelectOrderById_Result.ordCompanyPersonId.GetValueOrDefault();
					wSspSelectOrderById_Result.ordProjectId.GetValueOrDefault();
					_ = wSspSelectOrderById_Result.ordNumber;
				}
				if (ordId > 0 && addPay && result8 != 0 && payAmount > 0m)
				{
					InsertPaymentWithTiming(ordId, 20, result8, payAmount, payDocNumber, payDescription, listOrdIssued, addCmpMonyBag);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void InsertPaymentWithTiming(int objectId, int objectType, int payTypeId, decimal payAmount, string payDocNumber, string payDescription, string listOrdIssued = "", bool addCmpMonyBag = false)
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			now.ToString("HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = "mob";
			int id = Financial.Get().Id;
			int value3 = -20;
			short.Parse(id.ToString());
			int result = 0;
			int result2 = 0;
			int result3 = 0;
			int result4 = 0;
			new HttpCookie("ShopOnlinePaymentOpr");
			if (base.Request.Cookies["ShopOnlinePaymentOpr"] != null)
			{
				string value4 = base.Request.Cookies["ShopOnlinePaymentOpr"].Value;
				if (!string.IsNullOrWhiteSpace(value4))
				{
					string[] array = value4.Split(new char[1] { '|' });
					if (array != null && array.Length >= 4)
					{
						int.TryParse(array[0], out result2);
						int.TryParse(array[1], out result);
						int.TryParse(array[2], out result3);
						int.TryParse(array[3], out result4);
					}
				}
			}
			string text2 = "";
			string text3 = "";
			List<CommonMultiLanguageViewModel> list = CRMIdeal.Classes.Helper.OnlinePayment.CreatePayDescWhenToBank();
			if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
			{
				text2 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == defLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == defLangId)).Value : "");
				text3 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId))));
			}
			if (objectId <= 0 || payTypeId == 0)
			{
				return;
			}
			switch (objectType)
			{
			case 10:
			{
				if (result3 > 0)
				{
					_dbII.WSspUpdatePreOrderPayment(objectId, result3, payAmount, payDocNumber, payDescription, text, payAmount, value, value3, value, text, id, value2, appType, lCID, defLangId, text2, text3);
					break;
				}
				ObjectParameter insertedId2 = new ObjectParameter("InsertedId", typeof(int));
				_dbII.WSspInsertPreOrderPayment(objectId, payTypeId, payAmount, payDocNumber, payDescription, value3, value, text, id, value2, appType, lCID, defLangId, insertedId2, payAmount, null);
				break;
			}
			case 20:
				if (result3 > 0)
				{
					if (!string.IsNullOrWhiteSpace(listOrdIssued))
					{
						ObjectParameter result5 = new ObjectParameter("Result", typeof(int));
						_dbII.CRMSHPMobspDistributePaymentToOrders(listOrdIssued, text, value, payTypeId, null, null, payDocNumber, text, value, payDescription, payAmount, payAmount, null, addCmpMonyBag, result3, value3, id, value2, value, text, appType, defLangId, result5);
					}
					else
					{
						_dbII.WSspUpdateOrderPayment(objectId, result3, payAmount, payDocNumber, payDescription, text, payAmount, value, value3, value, text, id, value2, appType, lCID, defLangId, text2, text3);
					}
				}
				else if (!string.IsNullOrWhiteSpace(listOrdIssued))
				{
					ObjectParameter result6 = new ObjectParameter("Result", typeof(int));
					_dbII.CRMSHPMobspDistributePaymentToOrders(listOrdIssued, text, value, payTypeId, null, null, payDocNumber, text, value, payDescription, payAmount, payAmount, null, addCmpMonyBag, result3, value3, id, value2, value, text, appType, defLangId, result6);
				}
				else
				{
					ObjectParameter insertedId = new ObjectParameter("InsertedId", typeof(int));
					_dbII.WSspInsertOrderPayment(objectId, payTypeId, payAmount, payDocNumber, payDescription, value3, value, text, id, value2, appType, lCID, defLangId, null, payAmount, insertedId, null, null);
				}
				break;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public bool DeleteOrderOrPreOrder(int pordId, int ordId, string listOrdIssued = "")
	{
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (pordId > 0)
			{
				DeletePreOrder(pordId);
			}
			if (ordId > 0)
			{
				DeleteOrder(ordId, listOrdIssued);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public bool DeletePreOrder(int pordId)
	{
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (pordId > 0)
			{
				Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMSHPMobspDeletePreOrderWithItemAndPay(pordId));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public bool DeleteOrder(int ordId, string listOrdIssued = "")
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			bool flag = true;
			if (!string.IsNullOrWhiteSpace(listOrdIssued))
			{
				List<OrderJsonViewModel> list = new JavaScriptSerializer().Deserialize<List<OrderJsonViewModel>>(listOrdIssued);
				if (list != null && Enumerable.Any<OrderJsonViewModel>((IEnumerable<OrderJsonViewModel>)list))
				{
					string text = "";
					foreach (OrderJsonViewModel item in list)
					{
						int result3 = 0;
						int.TryParse(item.OrderId.ToString(), out result3);
						if (result3 != 0)
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += ",";
							}
							text += result3;
						}
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMSHPMobspDeleteOrderWithItemAndPayByOrdIds(text));
						flag = false;
					}
				}
			}
			if (ordId > 0 && flag)
			{
				Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMSHPMobspDeleteOrderWithItemAndPay(ordId));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public ActionResult MobPayment(int companyId, int oprType, int oprId, decimal payAmount, int payGatewayId, int userId, int payId = 0, int devType = 0, int ln = 1065, int ordId = 0, int pordId = 0, long ordNumber = 0L, long pordNumber = 0L, string listOrdIssued = "", int mode = 0)
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Expected O, but got Unknown
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Expected O, but got Unknown
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Expected O, but got Unknown
		//IL_08b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bc: Expected O, but got Unknown
		//IL_1275: Unknown result type (might be due to invalid IL or missing references)
		//IL_127c: Expected O, but got Unknown
		//IL_12ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f1: Expected O, but got Unknown
		int result = 1065;
		int.TryParse(ln.ToString(), out result);
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var _);
		_ = 0;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		string text = "";
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			text = cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
			if (!string.IsNullOrWhiteSpace(text) && text.EndsWith("/"))
			{
				text = text.TrimEnd(new char[1] { '/' });
			}
		}
		HttpCookie val = base.Request.Cookies["ShopOnlinePaymentOpr"];
		if (val != null)
		{
			base.Response.Cookies.Remove("ShopOnlinePaymentOpr");
			val.Expires = DateTime.Now.AddYears(-1);
		}
		HttpCookie val2 = new HttpCookie("ShopOnlinePaymentOpr");
		val2.Value = oprType + "|" + oprId + "|" + payId + "|" + mode;
		val2.Expires = DateTime.MaxValue;
		base.Response.Cookies.Add(val2);
		HttpCookie val3 = base.Request.Cookies["ShpOrdeId"];
		if (val3 != null)
		{
			base.Response.Cookies.Remove("ShpOrdeId");
			val3.Expires = DateTime.Now.AddYears(-1);
		}
		HttpCookie val4 = new HttpCookie("ShpOrdeId");
		val4.Value = ordId + "|" + ordNumber;
		val4.Expires = DateTime.MaxValue;
		base.Response.Cookies.Add(val4);
		HttpCookie val5 = base.Request.Cookies["ShpPreOrdeId"];
		if (val5 != null)
		{
			base.Response.Cookies.Remove("ShpPreOrdeId");
			val5.Expires = DateTime.Now.AddYears(-1);
		}
		HttpCookie val6 = new HttpCookie("ShpPreOrdeId");
		val6.Value = pordId + "|" + pordNumber;
		val6.Expires = DateTime.MaxValue;
		base.Response.Cookies.Add(val6);
		HttpCookie val7 = base.Request.Cookies["ShopOrderListOrdIssued"];
		if (val7 != null)
		{
			base.Request.Cookies.Remove("ShopOrderListOrdIssued");
			val7.Expires = DateTime.Now.AddYears(-1);
		}
		HttpCookie val8 = new HttpCookie("ShopOrderListOrdIssued");
		val8.Value = listOrdIssued.ToString();
		val8.Expires = DateTime.MaxValue;
		base.Response.Cookies.Add(val8);
		HttpCookie val9 = base.Request.Cookies["ShopOnlinePaymentOprAmount"];
		if (val9 != null)
		{
			base.Response.Cookies.Remove("ShopOnlinePaymentOprAmount");
			val9.Expires = DateTime.Now.AddYears(-1);
		}
		HttpCookie val10 = new HttpCookie("ShopOnlinePaymentOprAmount");
		val10.Value = payAmount.ToString();
		val10.Expires = DateTime.MaxValue;
		base.Response.Cookies.Add(val10);
		HttpCookie val11 = base.Request.Cookies["ShopOnlineMobPayDevType"];
		if (val11 != null)
		{
			base.Response.Cookies.Remove("ShopOnlineMobPayDevType");
			val11.Expires = DateTime.Now.AddYears(-1);
		}
		HttpCookie val12 = new HttpCookie("ShopOnlineMobPayDevType");
		val12.Value = devType.ToString();
		val12.Expires = DateTime.MaxValue;
		base.Response.Cookies.Add(val12);
		HttpCookie val13 = base.Request.Cookies["ShopOnlinePaymentUserId"];
		if (val13 != null)
		{
			base.Response.Cookies.Remove("ShopOnlinePaymentUserId");
			val13.Expires = DateTime.Now.AddYears(-1);
		}
		HttpCookie val14 = new HttpCookie("ShopOnlinePaymentUserId");
		val14.Value = userId.ToString();
		val14.Expires = DateTime.MaxValue;
		base.Response.Cookies.Add(val14);
		string text2 = "1";
		string text3 = "";
		string text4 = "";
		string text5 = "";
		string text6 = "";
		string text7 = "";
		string text8 = "";
		string text9 = "";
		string text10 = "";
		string text11 = "";
		CRMspSelectOnlinePayBankInfoByName_Result onlinePayBankInfo = CRMIdeal.Classes.Helper.OnlinePayment.GetOnlinePayBankInfo(payGatewayId, "");
		int num = 0;
		if (onlinePayBankInfo != null)
		{
			HttpCookie val15 = base.Request.Cookies["ShopOnlinePayBankInfoId"];
			if (val15 != null)
			{
				base.Response.Cookies.Remove("ShopOnlinePayBankInfoId");
				val15.Expires = DateTime.Now.AddYears(-1);
			}
			HttpCookie val16 = new HttpCookie("ShopOnlinePayBankInfoId");
			val16.Value = onlinePayBankInfo.OnlinePayBankInfoId.ToString();
			val16.Expires = DateTime.MaxValue;
			base.Response.Cookies.Add(val16);
			text2 = (onlinePayBankInfo.BankCurrencyRate.HasValue ? onlinePayBankInfo.BankCurrencyRate.ToString() : "1");
			text3 = onlinePayBankInfo.BankLoginAccount ?? "";
			text4 = onlinePayBankInfo.BankAdditionalData ?? "";
			text5 = onlinePayBankInfo.BankIPGPageUrl ?? "";
			text6 = onlinePayBankInfo.BankPGWSaleServiceUrl ?? "";
			text7 = onlinePayBankInfo.BankPGWConfirmServiceUrl ?? "";
			text8 = onlinePayBankInfo.BankReversalServiceUrl ?? "";
			text9 = onlinePayBankInfo.BankSalePaymentCallback ?? "";
			onlinePayBankInfo.BankingBankID.GetValueOrDefault();
			if (string.IsNullOrWhiteSpace(onlinePayBankInfo.BankingBank ?? ""))
			{
				_ = onlinePayBankInfo.BankName;
			}
			text10 = ((!string.IsNullOrEmpty(onlinePayBankInfo.BankLoginPassword)) ? XorCipher.DecryptByPrivateKey(onlinePayBankInfo.BankLoginPassword) : "");
			text11 = onlinePayBankInfo.BankTerminalCode ?? "";
			_ = onlinePayBankInfo.BankAcceptorCode;
			_ = onlinePayBankInfo.BankSignKey;
			string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
			if (!string.IsNullOrWhiteSpace(text))
			{
				array = text.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
			}
			text9 = array[0] + onlinePayBankInfo.BankSalePaymentCallback;
			num = onlinePayBankInfo.BankOnlinePayType.GetValueOrDefault();
			if (num == 0)
			{
				base.ViewBag.Error = Messages.msgErrorRunFunction;
				return View();
			}
			string s = payAmount.ToString().Replace(".00", "").Replace(".0", "");
			long amount = long.Parse(s) * long.Parse(text2);
			string text12 = "";
			int num2 = oprId;
			switch (num)
			{
			case 1:
			{
				string[] array6 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				if (!string.IsNullOrWhiteSpace(text))
				{
					array6 = text.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				}
				text9 = array6[0] + "/OnlinePayment/Home/ParsianMobPaymentCallBack";
				if (onlinePayBankInfo != null && !string.IsNullOrEmpty(text3) && !string.IsNullOrEmpty(text5) && !string.IsNullOrEmpty(text6) && !string.IsNullOrEmpty(text7) && !string.IsNullOrEmpty(text9))
				{
					long num4 = 0L;
					short num5 = short.MinValue;
					ClientPaymentResponseDataBase clientPaymentResponseDataBase = null;
					SaleService saleService = new SaleService();
					try
					{
						object obj = _003C_003Ec._003C_003E9__25_0;
						if (obj == null)
						{
							RemoteCertificateValidationCallback val19 = (object o, X509Certificate xc, X509Chain xch, SslPolicyErrors sslP) => true;
							_003C_003Ec._003C_003E9__25_0 = val19;
							obj = (object)val19;
						}
						ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback?)obj;
						saleService.Url = text6;
						ClientSaleRequestData clientSaleRequestData = new ClientSaleRequestData();
						string text38 = text3;
						if (string.IsNullOrWhiteSpace(text38))
						{
							text38 = text3;
						}
						if (string.IsNullOrWhiteSpace(text38))
						{
							base.ModelState.AddModelError("LoginAccount", "please fill either Login Account or customLoginAccount");
							base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>LoginAccount: please fill either Login Account or customLoginAccount";
							return View();
						}
						base.Session["ConfirmAfterPayment"] = true;
						base.Session["ConfirmServiceUrl"] = text7;
						base.Session["ReversalServiceUrl"] = text8;
						clientSaleRequestData.LoginAccount = text38;
						base.Session["SaleLoginAccount"] = text38;
						clientSaleRequestData.CallBackUrl = text9;
						clientSaleRequestData.Amount = amount;
						clientSaleRequestData.AdditionalData = text4;
						clientSaleRequestData.Originator = text12;
						long orderId2 = long.Parse(num2 + DateTime.Now.ToString("yyyyMMddhhmmss", new CultureInfo("en-US")));
						clientSaleRequestData.OrderId = orderId2;
						clientSaleRequestData.OrderId = DateTime.Now.Ticks;
						clientPaymentResponseDataBase = saleService.SalePaymentRequest(clientSaleRequestData);
						num5 = clientPaymentResponseDataBase.Status;
						if (clientPaymentResponseDataBase.Status == 0)
						{
							num4 = clientPaymentResponseDataBase.Token;
							base.Session["Token"] = num4;
						}
						else
						{
							Exception e = new Exception($"Parsian PGW service call status code : {clientPaymentResponseDataBase.Status}");
							ErrorSignal.FromCurrentContext().Raise(e);
							if (payId == 0 && mode == 1)
							{
								switch (oprType)
								{
								case 1:
								case 10:
									DeleteOrderOrPreOrder(pordId, 0);
									break;
								case 2:
								case 20:
									DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
									break;
								}
							}
						}
					}
					finally
					{
						((IDisposable)saleService)?.Dispose();
					}
					if (num5 == 0 && num4 > 0)
					{
						string text39 = string.Format(text5, clientPaymentResponseDataBase.Token);
						base.Response.Redirect(text39);
						break;
					}
					base.ViewBag.Error = "Error connecting to pay service";
					Exception e2 = new Exception("Error connecting to pay service");
					ErrorSignal.FromCurrentContext().Raise(e2);
					ParsianPaymentRequestResponseViewModel model = new ParsianPaymentRequestResponseViewModel
					{
						Message = clientPaymentResponseDataBase?.Message,
						Status = clientPaymentResponseDataBase?.Status,
						Token = clientPaymentResponseDataBase?.Token
					};
					return View("ParsianPaymentRequestResults", model);
				}
				base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + Messages.FOMsgErrorPayGatewaySettingNotSet;
				if (payId == 0 && mode == 1)
				{
					switch (oprType)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(pordId, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
						break;
					}
				}
				break;
			}
			case 2:
			{
				string[] array5 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				if (!string.IsNullOrWhiteSpace(text))
				{
					array5 = text.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				}
				text9 = array5[0] + "/OnlinePayment/Home/PasargadMobPaymentCallback";
				if (onlinePayBankInfo != null && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text10) && !string.IsNullOrWhiteSpace(text5) && !string.IsNullOrWhiteSpace(text11))
				{
					string content2 = "{ \"username\": \"" + text3 + "\", \"password\":\"" + text10 + "\"}";
					if (text5.EndsWith("/"))
					{
						text5 = text5.TrimEnd(new char[1] { '/' });
					}
					string text26 = text5 + "/token/getToken";
					HttpClient httpClient2 = new HttpClient();
					string text27 = text26;
					httpClient2.BaseAddress = new Uri(text27);
					httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					StringContent content3 = new StringContent(content2, Encoding.UTF8, "application/x-www-form-urlencoded");
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
					HttpResponseMessage result4 = httpClient2.PostAsync(text27, content3).Result;
					if (result4.IsSuccessStatusCode)
					{
						string text28 = result4.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(text28))
						{
							text28 = text28.Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}");
							text28 = text28.ClearHiddenCharacters();
						}
						PasargadTokenResponseViewModel pasargadTokenResponseViewModel = JsonConvert.DeserializeObject<PasargadTokenResponseViewModel>(text28);
						if (pasargadTokenResponseViewModel != null)
						{
							string text29 = "";
							if (!string.IsNullOrWhiteSpace(pasargadTokenResponseViewModel.resultMsg) && (pasargadTokenResponseViewModel.resultMsg.ToLower() == "Successful".ToLower() || !string.IsNullOrWhiteSpace(pasargadTokenResponseViewModel.token) || pasargadTokenResponseViewModel.resultCode.GetValueOrDefault() == 0))
							{
								text29 = pasargadTokenResponseViewModel.token ?? "";
							}
							if (!string.IsNullOrWhiteSpace(text29))
							{
								CRMspSelectCompanyById_Result companyById2 = CRMIdeal.Classes.Helper.Company.GetCompanyById(companyId);
								string text30 = "";
								string text31 = "";
								string text32 = "";
								string text33 = "";
								string text34 = "";
								string text35 = "";
								if (companyById2 != null)
								{
									int valueOrDefault2 = companyById2.cmpKind.GetValueOrDefault();
									text32 = companyById2.cmpMobile ?? "";
									text33 = companyById2.cmpEmail ?? "";
									if (string.IsNullOrWhiteSpace(companyById2.cmpPreTel + companyById2.cmpTel))
									{
										_ = companyById2.cmpPreTelII + companyById2.cmpTelII;
									}
									if (valueOrDefault2 == 0)
									{
										text30 = companyById2.cmpTitle ?? "";
										text31 = companyById2.cmpName ?? "";
										text35 = companyById2.cmpNationalCode ?? "";
									}
									else
									{
										text30 = companyById2.cmpMainPersonFName ?? "";
										text31 = companyById2.cmpMainPersonLName ?? "";
										text35 = companyById2.cmpMainPersonNationalCode ?? "";
									}
									text34 = ((!string.IsNullOrWhiteSpace(text30)) ? (text30 + " ") : "") + text31;
								}
								text29 = "Bearer " + text29;
								string text36 = DateTime.Now.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + num2;
								content2 = "{ \"amount\":  " + amount + ",\"callbackApi\":\"" + text9 + "\",\"description\": \"\",\"invoice\": \"" + text36 + "\", \"invoiceDate\": \"" + DateTime.Now.ToString("yyyy/MM/dd", new CultureInfo("fa-IR")) + "\",\"mobileNumber\": \"" + text32 + "\", \"payerMail\": \"" + text33 + "\", \"payerName\": \"" + text34 + "\", \"serviceCode\": 8, \"serviceType\":\"PURCHASE\", \"terminalNumber\": " + text11 + ", \"nationalCode\": \"" + text35 + "\", \"pans\":\"\"}";
								text26 = text5 + "/api/payment/purchase";
								HttpClient httpClient3 = new HttpClient();
								text27 = text26;
								httpClient3.BaseAddress = new Uri(text27);
								httpClient3.DefaultRequestHeaders.Add("Authorization", text29);
								httpClient3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
								content3 = new StringContent(content2, Encoding.UTF8, "application/x-www-form-urlencoded");
								ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
								result4 = httpClient3.PostAsync(text27, content3).Result;
								if (result4.IsSuccessStatusCode)
								{
									text28 = result4.Content.ReadAsStringAsync().Result;
									if (!string.IsNullOrWhiteSpace(text28))
									{
										text28 = text28.Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}");
										text28 = text28.ClearHiddenCharacters();
									}
									PasargadPurchaseResponseViewModel pasargadPurchaseResponseViewModel = JsonConvert.DeserializeObject<PasargadPurchaseResponseViewModel>(text28);
									if (pasargadPurchaseResponseViewModel != null)
									{
										string text37 = "";
										string value = "";
										if (pasargadPurchaseResponseViewModel.resultCode.GetValueOrDefault() == 0 && pasargadPurchaseResponseViewModel.data != null)
										{
											text37 = pasargadPurchaseResponseViewModel.data.url ?? "";
											value = pasargadPurchaseResponseViewModel.data.urlId ?? "";
										}
										if (!string.IsNullOrWhiteSpace(text37) && !string.IsNullOrWhiteSpace(value))
										{
											HttpCookie val17 = new HttpCookie("PasargadToken_I");
											if (base.Request.Cookies["PasargadToken_I"] != null)
											{
												base.Response.Cookies.Remove("PasargadToken_I");
												val17.Expires = DateTime.Now.AddYears(-1);
											}
											val17.Value = text29;
											val17.Expires = DateTime.MaxValue;
											base.Response.Cookies.Add(val17);
											HttpCookie val18 = new HttpCookie("PasargadUrlId_I");
											if (base.Request.Cookies["PasargadUrlId_I"] != null)
											{
												base.Response.Cookies.Remove("PasargadUrlId_I");
												val18.Expires = DateTime.Now.AddYears(-1);
											}
											val18.Value = value;
											val18.Expires = DateTime.MaxValue;
											base.Response.Cookies.Add(val18);
											return Redirect(text37);
										}
										base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + pasargadPurchaseResponseViewModel.resultMsg;
										if (payId == 0 && mode == 1)
										{
											switch (oprType)
											{
											case 1:
											case 10:
												DeleteOrderOrPreOrder(pordId, 0);
												break;
											case 2:
											case 20:
												DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
												break;
											}
										}
										break;
									}
									base.ViewBag.Error = Messages.msgErrorRunFunction;
									if (payId == 0 && mode == 1)
									{
										switch (oprType)
										{
										case 1:
										case 10:
											DeleteOrderOrPreOrder(pordId, 0);
											break;
										case 2:
										case 20:
											DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
											break;
										}
									}
									break;
								}
								base.ViewBag.Error = Messages.msgErrorRunFunction;
								if (payId == 0 && mode == 1)
								{
									switch (oprType)
									{
									case 1:
									case 10:
										DeleteOrderOrPreOrder(pordId, 0);
										break;
									case 2:
									case 20:
										DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
										break;
									}
								}
								break;
							}
							base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorReceivingToken + "<br>" + pasargadTokenResponseViewModel.resultMsg;
							if (payId == 0 && mode == 1)
							{
								switch (oprType)
								{
								case 1:
								case 10:
									DeleteOrderOrPreOrder(pordId, 0);
									break;
								case 2:
								case 20:
									DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
									break;
								}
							}
							break;
						}
						base.ViewBag.Error = Messages.msgErrorRunFunction;
						if (payId == 0 && mode == 1)
						{
							switch (oprType)
							{
							case 1:
							case 10:
								DeleteOrderOrPreOrder(pordId, 0);
								break;
							case 2:
							case 20:
								DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
								break;
							}
						}
						break;
					}
					base.ViewBag.Error = Messages.msgErrorRunFunction;
					if (payId == 0 && mode == 1)
					{
						switch (oprType)
						{
						case 1:
						case 10:
							DeleteOrderOrPreOrder(pordId, 0);
							break;
						case 2:
						case 20:
							DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
							break;
						}
					}
					break;
				}
				base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + Messages.FOMsgErrorPayGatewaySettingNotSet;
				if (payId == 0 && mode == 1)
				{
					switch (oprType)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(pordId, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
						break;
					}
				}
				break;
			}
			case 3:
			{
				string[] array4 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				if (!string.IsNullOrWhiteSpace(text))
				{
					array4 = text.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				}
				text9 = array4[0] + "/OnlinePayment/Home/MellatMobPaymentCallBack";
				PaymentGatewayClient paymentGatewayClient = new PaymentGatewayClient();
				string text25 = "";
				text25 = paymentGatewayClient.bpPayRequest(orderId: long.Parse(num2 + DateTime.Now.ToString("yyyyMMddhhmmss", new CultureInfo("en-US"))), terminalId: long.Parse(text11), userName: text3, userPassword: text10, amount: amount, localDate: DateTime.Now.ToString("yyyyMMdd"), localTime: DateTime.Now.ToString("hhmmss"), additionalData: "", callBackUrl: text9, payerId: "0", mobileNo: "", encPan: "", panHiddenMode: "0", cartItem: "", enc: "");
				if (string.IsNullOrWhiteSpace(text25))
				{
					base.ViewBag.Error = Messages.msgErrorRunFunction;
					if (payId == 0 && mode == 1)
					{
						switch (oprType)
						{
						case 1:
						case 10:
							DeleteOrderOrPreOrder(pordId, 0);
							break;
						case 2:
						case 20:
							DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
							break;
						}
					}
					break;
				}
				string mellatRequestResult = GetMellatRequestResult(text25);
				if (string.IsNullOrWhiteSpace(mellatRequestResult))
				{
					base.ViewBag.jscode = "<script>postRefId('" + text25.Split(new char[1] { ',' })[1] + "');</script>";
					base.ViewBag.MellatGatewayPayRefId = text25.Split(new char[1] { ',' })[1];
					base.ViewBag.MellatGatewayPayLink = text6;
					return View();
				}
				base.ViewBag.Error = mellatRequestResult;
				if (payId == 0 && mode == 1)
				{
					switch (oprType)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(pordId, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
						break;
					}
				}
				break;
			}
			case 4:
			{
				string[] array3 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				if (!string.IsNullOrWhiteSpace(text))
				{
					array3 = text.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				}
				text9 = array3[0] + "/OnlinePayment/Home/ZarinPalMobPaymentCallback";
				ServicePointManager.Expect100Continue = false;
				PaymentGatewayImplementationServicePortTypeClient paymentGatewayImplementationServicePortTypeClient = new PaymentGatewayImplementationServicePortTypeClient();
				int amount2 = int.Parse((long.Parse(s) / long.Parse(text2)).ToString());
				string text23 = text9;
				if (text23.EndsWith("/"))
				{
					text23 = text23.TrimEnd(new char[1] { '/' });
				}
				text23 = text23 + "?id=" + num2;
				if (string.IsNullOrWhiteSpace(text4))
				{
					text4 = "درگاه زرین پال";
				}
				string Authority;
				int num3 = paymentGatewayImplementationServicePortTypeClient.PaymentRequest(text3, amount2, text4, "", "", text9, out Authority);
				if (num3 == 100)
				{
					base.Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);
					break;
				}
				string text24 = "";
				switch (num3)
				{
				case -1:
					text24 = Messages.msgErrorZarinPalStatus_1;
					break;
				case -2:
					text24 = Messages.msgErrorZarinPalStatus_2;
					break;
				case -3:
					text24 = Messages.msgErrorZarinPalStatus_3;
					break;
				case -4:
					text24 = Messages.msgErrorZarinPalStatus_4;
					break;
				case -11:
					text24 = Messages.msgErrorZarinPalStatus_11;
					break;
				case -12:
					text24 = Messages.msgErrorZarinPalStatus_12;
					break;
				case -21:
					text24 = Messages.msgErrorZarinPalStatus_21;
					break;
				case -22:
					text24 = Messages.msgErrorZarinPalStatus_22;
					break;
				case -33:
					text24 = Messages.msgErrorZarinPalStatus_33;
					break;
				case -34:
					text24 = Messages.msgErrorZarinPalStatus_34;
					break;
				case -40:
					text24 = Messages.msgErrorZarinPalStatus_40;
					break;
				case -41:
					text24 = Messages.msgErrorZarinPalStatus_41;
					break;
				case -42:
					text24 = Messages.msgErrorZarinPalStatus_42;
					break;
				case -54:
					text24 = Messages.msgErrorZarinPalStatus_54;
					break;
				case 101:
					text24 = Messages.msgErrorZarinPalStatus_101;
					break;
				}
				base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + text24;
				if (payId == 0 && mode == 1)
				{
					switch (oprType)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(pordId, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
						break;
					}
				}
				break;
			}
			case 5:
			{
				string[] array7 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				if (!string.IsNullOrWhiteSpace(text))
				{
					array7 = text.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				}
				text9 = array7[0] + "/OnlinePayment/SamanMobPaymentCallBack";
				if (onlinePayBankInfo != null && !string.IsNullOrWhiteSpace(text11) && !string.IsNullOrWhiteSpace(text3))
				{
					string text40 = num2 + DateTime.Now.ToString("yyyyMMddhhmmss", new CultureInfo("en-US"));
					int num6 = int.Parse(amount.ToString());
					StringContent content4 = new StringContent("{ \"action\": \"token\", \"TerminalId\": " + text11 + ", \"Amount\": " + num6 + ",\"ResNum\": \"" + text40 + "\", \"RedirectUrl\":\"" + text9 + "\", \"InvoiceDate\":\"" + DateTime.Now.ToString("yyyy/MM/dd", new CultureInfo("fa-IR")) + "\",\"TerminalCode\": \"" + text11 + "\", \"CellNumber\": \"" + text12 + "\"}", Encoding.UTF8, "application/json");
					HttpRequestMessage request = new HttpRequestMessage
					{
						RequestUri = new Uri("https://sep.shaparak.ir/onlinepg/onlinepg"),
						Method = HttpMethod.Post,
						Content = content4
					};
					HttpResponseMessage result5 = new HttpClient
					{
						DefaultRequestHeaders = 
						{
							Accept = 
							{
								new MediaTypeWithQualityHeaderValue("application/json")
							}
						}
					}.SendAsync(request).Result;
					if (result5.IsSuccessStatusCode)
					{
						SamanBankGetTokenViewModel samanBankGetTokenViewModel = JsonConvert.DeserializeObject<SamanBankGetTokenViewModel>(result5.Content.ReadAsStringAsync().Result);
						if (samanBankGetTokenViewModel != null)
						{
							if (samanBankGetTokenViewModel.status.GetValueOrDefault() == 1)
							{
								return Redirect(string.Format(text5, samanBankGetTokenViewModel.token ?? ""));
							}
							_ = samanBankGetTokenViewModel.errorCode;
							base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + samanBankGetTokenViewModel.errorDesc;
							if (payId == 0 && mode == 1)
							{
								switch (oprType)
								{
								case 1:
								case 10:
									DeleteOrderOrPreOrder(pordId, 0);
									break;
								case 2:
								case 20:
									DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
									break;
								}
							}
							break;
						}
						base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorReceivingToken;
						if (payId == 0 && mode == 1)
						{
							switch (oprType)
							{
							case 1:
							case 10:
								DeleteOrderOrPreOrder(pordId, 0);
								break;
							case 2:
							case 20:
								DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
								break;
							}
						}
						break;
					}
					base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorReceivingToken;
					if (payId == 0 && mode == 1)
					{
						switch (oprType)
						{
						case 1:
						case 10:
							DeleteOrderOrPreOrder(pordId, 0);
							break;
						case 2:
						case 20:
							DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
							break;
						}
					}
					break;
				}
				base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + Messages.FOMsgErrorPayGatewaySettingNotSet;
				if (payId == 0 && mode == 1)
				{
					switch (oprType)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(pordId, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
						break;
					}
				}
				break;
			}
			case 6:
			{
				string[] array2 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				if (!string.IsNullOrWhiteSpace(text))
				{
					array2 = text.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
				}
				text9 = array2[0] + "/OnlinePayment/Home/BinaPayMobPaymentCallBack?opId=" + oprId;
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(companyId);
				string text13 = "";
				string text14 = "";
				string text15 = "";
				string text16 = "";
				string text17 = "";
				string text18 = "";
				if (companyById != null)
				{
					int valueOrDefault = companyById.cmpKind.GetValueOrDefault();
					text15 = companyById.cmpMobile ?? "";
					text16 = companyById.cmpEmail ?? "";
					text18 = companyById.cmpPreTel + companyById.cmpTel;
					if (string.IsNullOrWhiteSpace(text18))
					{
						text18 = companyById.cmpPreTelII + companyById.cmpTelII;
					}
					if (valueOrDefault == 0)
					{
						text13 = companyById.cmpTitle ?? "";
						text14 = companyById.cmpName ?? "";
						text17 = companyById.cmpNationalCode ?? "";
					}
					else
					{
						text13 = companyById.cmpMainPersonFName ?? "";
						text14 = companyById.cmpMainPersonLName ?? "";
						text17 = companyById.cmpMainPersonNationalCode ?? "";
					}
				}
				char[] special = new char[1] { ' ' };
				if (!string.IsNullOrWhiteSpace(text13))
				{
					text13 = CRM.General.Text.String.FilterString(text13, keepNumber: false, keepEnglishAlpha: false, keepPersianbAlpha: true, special);
					if (!string.IsNullOrWhiteSpace(text13) && text13.Length > 30)
					{
						text13 = text13.Substring(0, 30);
					}
				}
				if (!string.IsNullOrWhiteSpace(text14))
				{
					text14 = CRM.General.Text.String.FilterString(text14, keepNumber: false, keepEnglishAlpha: false, keepPersianbAlpha: true, special);
					if (!string.IsNullOrWhiteSpace(text14) && text14.Length > 30)
					{
						text14 = text14.Substring(0, 30);
					}
				}
				if (onlinePayBankInfo != null && !string.IsNullOrWhiteSpace(text5) && !string.IsNullOrWhiteSpace(text11) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text10))
				{
					if (!text5.EndsWith("/"))
					{
						text5 = text5 + text5 + "/";
					}
					string text19 = text5;
					text19 += "api/API";
					string text20 = num2 + DateTime.Now.ToString("yyyyMMddhhmmss", new CultureInfo("en-US"));
					string arg = "{\"FN\": \"Request\", \"TerminalID\": " + text11 + ", \"Username\": \"" + text3 + "\", \"Password\": \"" + text10 + "\", \"CallbackURL\":\"" + text9 + "\", \"ID2\": \"" + text20 + "\", \"NC\": \"" + text17 + "\", \"Name\": \"" + text13 + "\", \"Family\": \"" + text14 + "\", \"Tel\": \"" + text18 + "\", \"Mobile\": \"" + text15 + "\", \"EMail\": \"" + text16 + "\", \"Amount\": " + amount + "}";
					HttpClient httpClient = new HttpClient();
					string text21 = text19;
					httpClient.BaseAddress = new Uri(text21);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					StringContent content = new StringContent($"INPUT={arg}", Encoding.UTF8, "application/x-www-form-urlencoded");
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
					HttpResponseMessage result3 = httpClient.PostAsync(text21, content).Result;
					if (result3.IsSuccessStatusCode)
					{
						string text22 = result3.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(text22))
						{
							text22 = text22.Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}");
							text22 = text22.ClearHiddenCharacters();
						}
						BinaPaySharifFirstStepResultViewModel binaPaySharifFirstStepResultViewModel = JsonConvert.DeserializeObject<BinaPaySharifFirstStepResultViewModel>(text22);
						if (binaPaySharifFirstStepResultViewModel != null)
						{
							if (binaPaySharifFirstStepResultViewModel.Result == 0 && binaPaySharifFirstStepResultViewModel.OrderID > 0 && !string.IsNullOrWhiteSpace(binaPaySharifFirstStepResultViewModel.OrderGUID))
							{
								string format = text5 + "submit2/{0}/{1}";
								return Redirect(string.Format(format, binaPaySharifFirstStepResultViewModel.OrderID.ToString(), binaPaySharifFirstStepResultViewModel.OrderGUID));
							}
							base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + binaPaySharifFirstStepResultViewModel.Message;
							if (payId == 0 && mode == 1)
							{
								switch (oprType)
								{
								case 1:
								case 10:
									DeleteOrderOrPreOrder(pordId, 0);
									break;
								case 2:
								case 20:
									DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
									break;
								}
							}
							break;
						}
						base.ViewBag.Error = Messages.msgErrorRunFunction;
						if (payId == 0 && mode == 1)
						{
							switch (oprType)
							{
							case 1:
							case 10:
								DeleteOrderOrPreOrder(pordId, 0);
								break;
							case 2:
							case 20:
								DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
								break;
							}
						}
						break;
					}
					base.ViewBag.Error = Messages.msgErrorRunFunction;
					if (payId == 0 && mode == 1)
					{
						switch (oprType)
						{
						case 1:
						case 10:
							DeleteOrderOrPreOrder(pordId, 0);
							break;
						case 2:
						case 20:
							DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
							break;
						}
					}
					break;
				}
				base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + Messages.FOMsgErrorPayGatewaySettingNotSet;
				if (payId == 0 && mode == 1)
				{
					switch (oprType)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(pordId, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, ordId, listOrdIssued);
						break;
					}
				}
				break;
			}
			}
			return View();
		}
		base.ViewBag.Error = Messages.msgErrorRunFunction;
		return View();
	}

	public void ParsianMobPaymentCallBack(ParsianPaymentCallbackViewModel model)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		int result = -20;
		HttpCookie val = base.Request.Cookies["MobPayCallBackErr"];
		if (val != null)
		{
			base.Response.Cookies.Remove("MobPayCallBackErr");
			val.Expires = DateTime.Now.AddYears(-1);
			base.Response.Cookies.Add(val);
		}
		if (base.Request.Cookies["ShopOnlinePaymentUserId"] != null)
		{
			new HttpCookie("ShopOnlinePaymentUserId");
			int.TryParse(base.Request.Cookies["ShopOnlinePaymentUserId"].Value ?? "-20", out result);
		}
		if (model != null)
		{
			ParsianPaymentCallbackViewModel parsianPaymentCallbackViewModel = (_parsianPaymentCallbackViewModel = new ParsianPaymentCallbackViewModel
			{
				Amount = model.Amount,
				HashCardNumber = model.HashCardNumber,
				OrderId = model.OrderId,
				RRN = model.RRN,
				status = model.status,
				TerminalNo = model.TerminalNo,
				Token = model.Token,
				TspToken = model.TspToken
			});
			BankCallBackEventHendler(1);
			base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback?trackingNumber=" + parsianPaymentCallbackViewModel.OrderId, false);
		}
		else
		{
			HttpCookie val2 = new HttpCookie("MobPayCallBackErr");
			val2.Value = Messages.FOMsgErrorCallBack;
			val2.Expires = DateTime.MaxValue;
			base.Response.Cookies.Add(val2);
			base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback", false);
		}
	}

	public void PasargadMobPaymentCallback(string status = "", string invoiceId = "", string referenceNumber = "", string trackId = "")
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		HttpCookie val = base.Request.Cookies["MobPayCallBackErr"];
		if (val != null)
		{
			base.Response.Cookies.Remove("MobPayCallBackErr");
			val.Expires = DateTime.Now.AddYears(-1);
			base.Response.Cookies.Add(val);
		}
		_pasargadCallBackViewModel = new PasargadV2CallBackViewModel
		{
			Status = status,
			InvoiceId = invoiceId,
			ReferenceNumber = referenceNumber,
			TrackId = trackId
		};
		BankCallBackViewModel bankCallBackViewModel = BankCallBackEventHendler(2);
		if (bankCallBackViewModel.ErrorMessage == null)
		{
			base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback?trackingNumber=" + bankCallBackViewModel.ShaparakRefNumber, false);
			return;
		}
		HttpCookie val2 = new HttpCookie("MobPayCallBackErr");
		val2.Value = bankCallBackViewModel.ErrorMessage.Replace("<br>", "#br#");
		val2.Expires = DateTime.MaxValue;
		base.Response.Cookies.Add(val2);
		base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback", false);
	}

	public void MellatMobPaymentCallBack(string RefId = "", string ResCode = "", long SaleOrderId = 0L, long SaleReferenceId = 0L, string CardHolderPan = "", string CreditCardSaleResponseDetail = "", long FinalAmount = 0L)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		HttpCookie val = base.Request.Cookies["MobPayCallBackErr"];
		if (val != null)
		{
			base.Response.Cookies.Remove("MobPayCallBackErr");
			val.Expires = DateTime.Now.AddYears(-1);
			base.Response.Cookies.Add(val);
		}
		_mellatCallBackViewModel = new MellatCallBackViewModel
		{
			RefId = RefId,
			ResCode = ResCode,
			SaleOrderId = SaleOrderId,
			SaleReferenceId = SaleReferenceId,
			FinalAmount = FinalAmount
		};
		BankCallBackViewModel bankCallBackViewModel = BankCallBackEventHendler(3);
		if (bankCallBackViewModel.ErrorMessage != null)
		{
			HttpCookie val2 = new HttpCookie("MobPayCallBackErr");
			val2.Value = bankCallBackViewModel.ErrorMessage.Replace("<br>", "#br#");
			val2.Expires = DateTime.MaxValue;
			base.Response.Cookies.Add(val2);
			base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback", false);
		}
		if (bankCallBackViewModel.ShenasehNumber != null)
		{
			base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback?trackingNumber=" + bankCallBackViewModel.ShenasehNumber, false);
		}
	}

	public void ZarinPalMobPaymentCallback(int? id)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		HttpCookie val = base.Request.Cookies["MobPayCallBackErr"];
		if (val != null)
		{
			base.Response.Cookies.Remove("MobPayCallBackErr");
			val.Expires = DateTime.Now.AddYears(-1);
			base.Response.Cookies.Add(val);
		}
		_zarinPalCallBackViewModel = new ZarinPalCallBackViewModel
		{
			Id = id
		};
		BankCallBackViewModel bankCallBackViewModel = BankCallBackEventHendler(4);
		if (bankCallBackViewModel.ErrorMessage != null)
		{
			HttpCookie val2 = new HttpCookie("MobPayCallBackErr");
			val2.Value = bankCallBackViewModel.ErrorMessage.Replace("<br>", "#br#");
			val2.Expires = DateTime.MaxValue;
			base.Response.Cookies.Add(val2);
			base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback", false);
		}
		else
		{
			base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback?trackingNumber=" + bankCallBackViewModel.RefId, false);
		}
	}

	public void SamanMobPaymentCallBack(string MID = "", string State = "", int Status = 0, string RRN = "", string RefNum = "", string ResNum = "", string TerminalId = "", string TraceNo = "", int Amount = 0)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		HttpCookie val = base.Request.Cookies["MobPayCallBackErr"];
		if (val != null)
		{
			base.Response.Cookies.Remove("MobPayCallBackErr");
			val.Expires = DateTime.Now.AddYears(-1);
			base.Response.Cookies.Add(val);
		}
		_samanBankCallBackViewModel = new SamanBankCallBackViewModelI
		{
			TransactionReferenceID = RefNum,
			Status = Status
		};
		BankCallBackViewModel bankCallBackViewModel = BankCallBackEventHendler(5);
		if (bankCallBackViewModel.ErrorMessage != null)
		{
			HttpCookie val2 = new HttpCookie("MobPayCallBackErr");
			val2.Value = bankCallBackViewModel.ErrorMessage.Replace("<br>", "#br#");
			val2.Expires = DateTime.MaxValue;
			base.Response.Cookies.Add(val2);
			base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback", false);
		}
		else
		{
			base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback?trackingNumber=" + bankCallBackViewModel.RefNumber, false);
		}
	}

	public void BinaPayMobPaymentCallBack(int opId = 0, string id2 = "", int result = 0, long orderid = 0L, string OrderGUID = "")
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		HttpCookie val = base.Request.Cookies["MobPayCallBackErr"];
		if (val != null)
		{
			base.Response.Cookies.Remove("MobPayCallBackErr");
			val.Expires = DateTime.Now.AddYears(-1);
			base.Response.Cookies.Add(val);
		}
		_binaPaySharifCallBackViewModel = new BinaPaySharifCallBackViewModel
		{
			Result = result,
			ID2 = id2,
			OrderID = orderid,
			OrderGUID = OrderGUID
		};
		BankCallBackViewModel bankCallBackViewModel = BankCallBackEventHendler(6);
		if (bankCallBackViewModel.ErrorMessage != null)
		{
			HttpCookie val2 = new HttpCookie("MobPayCallBackErr");
			val2.Value = bankCallBackViewModel.ErrorMessage.Replace("<br>", "#br#");
			val2.Expires = DateTime.MaxValue;
			base.Response.Cookies.Add(val2);
			base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback", false);
		}
		else
		{
			base.Response.Redirect("/OnlinePayment/Home/MobPaymentCallback?trackingNumber=" + bankCallBackViewModel.RefNumber, false);
		}
	}

	public ActionResult MobPaymentCallback(string trackingNumber = "")
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		new HttpCookie("MobPayCallBackErr");
		if (base.Request.Cookies["MobPayCallBackErr"] != null)
		{
			string value = base.Request.Cookies["MobPayCallBackErr"].Value;
			if (!string.IsNullOrWhiteSpace(value))
			{
				text = value;
			}
		}
		text = text.Replace("#br#", "<br>");
		BankMobCallbackViewModel model = new BankMobCallbackViewModel
		{
			TrackingNumber = trackingNumber,
			ErrorMessage = text
		};
		return View(model);
	}

	public BankCallBackViewModel BankCallBackEventHendler(int mode = 0)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_125e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_226e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		BankCallBackViewModel bankCallBackViewModel = new BankCallBackViewModel();
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			string text = "";
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				text = cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
				if (!string.IsNullOrWhiteSpace(text) && text.EndsWith("/"))
				{
					text = text.TrimEnd(new char[1] { '/' });
				}
			}
			int result = 0;
			if (base.Request.Cookies["ShopOnlinePayBankInfoId"] != null)
			{
				new HttpCookie("ShopOnlinePayBankInfoId");
				int.TryParse(base.Request.Cookies["ShopOnlinePayBankInfoId"].Value, out result);
			}
			CRMspSelectOnlinePayBankInfoByName_Result cRMspSelectOnlinePayBankInfoByName_Result = new CRMspSelectOnlinePayBankInfoByName_Result();
			cRMspSelectOnlinePayBankInfoByName_Result = ((result == 0) ? null : CRMIdeal.Classes.Helper.OnlinePayment.GetOnlinePayBankInfo(result, ""));
			int result2 = 0;
			int result3 = 0;
			int result4 = 0;
			int result5 = 0;
			new HttpCookie("ShopOnlinePaymentOpr");
			if (base.Request.Cookies["ShopOnlinePaymentOpr"] != null)
			{
				string value = base.Request.Cookies["ShopOnlinePaymentOpr"].Value;
				if (!string.IsNullOrWhiteSpace(value))
				{
					string[] array = value.Split(new char[1] { '|' });
					if (array != null && array.Length >= 4)
					{
						int.TryParse(array[0], out result3);
						int.TryParse(array[1], out result2);
						int.TryParse(array[2], out result4);
						int.TryParse(array[3], out result5);
					}
				}
			}
			int result6 = 0;
			long result7 = 0L;
			new HttpCookie("ShpOrdeId");
			if (base.Request.Cookies["ShpOrdeId"] != null)
			{
				string value2 = base.Request.Cookies["ShpOrdeId"].Value;
				if (!string.IsNullOrWhiteSpace(value2))
				{
					string[] array2 = value2.Split(new char[1] { '|' });
					if (array2 != null && array2.Length >= 2)
					{
						int.TryParse(array2[0], out result6);
						long.TryParse(array2[1], out result7);
					}
				}
			}
			int result8 = 0;
			long result9 = 0L;
			new HttpCookie("ShpPreOrdeId");
			if (base.Request.Cookies["ShpPreOrdeId"] != null)
			{
				string value3 = base.Request.Cookies["ShpPreOrdeId"].Value;
				if (!string.IsNullOrWhiteSpace(value3))
				{
					string[] array3 = value3.Split(new char[1] { '|' });
					if (array3 != null && array3.Length >= 2)
					{
						int.TryParse(array3[0], out result8);
						long.TryParse(array3[1], out result9);
					}
				}
			}
			string listOrdIssued = "";
			new HttpCookie("ShopOrderListOrdIssued");
			if (base.Request.Cookies["ShopOrderListOrdIssued"] != null)
			{
				listOrdIssued = base.Request.Cookies["ShopOrderListOrdIssued"].Value;
			}
			int result10 = 0;
			int result11 = 0;
			switch (mode)
			{
			case 1:
			{
				ParsianPaymentCallbackViewModel parsianPaymentCallbackViewModel = _parsianPaymentCallbackViewModel;
				if (parsianPaymentCallbackViewModel.status == 0 && parsianPaymentCallbackViewModel.Token.GetValueOrDefault() > 0)
				{
					base.Session["ConfirmAfterPayment"] = true;
					bool num2 = (bool)base.Session["ConfirmAfterPayment"];
					string text22 = "";
					if (cRMspSelectOnlinePayBankInfoByName_Result == null)
					{
						cRMspSelectOnlinePayBankInfoByName_Result = CRMIdeal.Classes.Helper.OnlinePayment.GetOnlinePayBankInfo(0, "بانک پارسیان");
					}
					if (cRMspSelectOnlinePayBankInfoByName_Result != null)
					{
						text22 = cRMspSelectOnlinePayBankInfoByName_Result.BankPGWConfirmServiceUrl ?? "";
						int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankOrdPayTypeId.ToString(), out result10);
						int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankPordPayTypeId.ToString(), out result11);
					}
					if (!num2)
					{
						break;
					}
					ConfirmService confirmService = new ConfirmService();
					try
					{
						base.Session["ConfirmServiceUrl"] = text22;
						confirmService.Url = (string)base.Session["ConfirmServiceUrl"];
						ClientConfirmRequestData clientConfirmRequestData = new ClientConfirmRequestData();
						clientConfirmRequestData.LoginAccount = GetLoginAccount();
						clientConfirmRequestData.Token = parsianPaymentCallbackViewModel.Token.GetValueOrDefault(-1L);
						ClientConfirmResponseData clientConfirmResponseData = confirmService.ConfirmPayment(clientConfirmRequestData);
						parsianPaymentCallbackViewModel.ConfirmResponseStatus = clientConfirmResponseData.Status;
						if (clientConfirmResponseData.Status == 0)
						{
							string s2 = "1";
							if (cRMspSelectOnlinePayBankInfoByName_Result != null)
							{
								s2 = (cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.HasValue ? cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.ToString() : "1");
							}
							long.TryParse(parsianPaymentCallbackViewModel.Amount, NumberStyles.Any, CultureInfo.CurrentCulture, out var result22);
							result22 /= long.Parse(s2);
							decimal result23 = default(decimal);
							decimal.TryParse(result22.ToString(), out result23);
							string text23 = parsianPaymentCallbackViewModel.RRN.ToString() ?? "";
							string payDescription5 = parsianPaymentCallbackViewModel.HashCardNumber ?? "";
							bankCallBackViewModel.IsSuccess = true;
							bankCallBackViewModel.Amount = result23;
							bankCallBackViewModel.ShaparakRefNumber = text23;
							bankCallBackViewModel.Message = "";
							bankCallBackViewModel.HashedCardNumber = parsianPaymentCallbackViewModel.HashCardNumber ?? "";
							InsertPayment(result23, text23, payDescription5, result10, result11);
						}
					}
					finally
					{
						((IDisposable)confirmService)?.Dispose();
					}
				}
				else if (result4 == 0 && result5 == 1)
				{
					switch (result3)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(result8, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, result6, listOrdIssued);
						break;
					}
				}
				break;
			}
			case 2:
			{
				PasargadV2CallBackViewModel pasargadCallBackViewModel = _pasargadCallBackViewModel;
				if (pasargadCallBackViewModel != null)
				{
					string text9 = pasargadCallBackViewModel.Status ?? "";
					if (!string.IsNullOrWhiteSpace(text9))
					{
						text9 = text9.ToLower();
					}
					if (text9 == "success" && !string.IsNullOrWhiteSpace(pasargadCallBackViewModel.InvoiceId) && !string.IsNullOrWhiteSpace(pasargadCallBackViewModel.ReferenceNumber))
					{
						string value4 = "";
						if (base.Request.Cookies["PasargadToken_I"] != null)
						{
							new HttpCookie("PasargadToken_I");
							value4 = base.Request.Cookies["PasargadToken_I"].Value ?? "";
						}
						string text10 = "";
						if (base.Request.Cookies["PasargadUrlId_I"] != null)
						{
							new HttpCookie("PasargadUrlId_I");
							text10 = base.Request.Cookies["PasargadUrlId_I"].Value ?? "";
						}
						string invoiceId = pasargadCallBackViewModel.InvoiceId;
						_ = pasargadCallBackViewModel.ReferenceNumber;
						string text11 = "1";
						string text12 = "";
						if (cRMspSelectOnlinePayBankInfoByName_Result == null)
						{
							cRMspSelectOnlinePayBankInfoByName_Result = CRMIdeal.Classes.Helper.OnlinePayment.GetOnlinePayBankInfo(0, "پاسارگاد");
						}
						if (cRMspSelectOnlinePayBankInfoByName_Result != null)
						{
							text11 = (cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.HasValue ? cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.ToString() : "1");
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankLoginAccount;
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankAdditionalData;
							text12 = cRMspSelectOnlinePayBankInfoByName_Result.BankIPGPageUrl ?? "";
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankPGWSaleServiceUrl;
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankPGWConfirmServiceUrl;
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankReversalServiceUrl;
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankSalePaymentCallback;
							cRMspSelectOnlinePayBankInfoByName_Result.BankingBankID.GetValueOrDefault();
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankingBank;
							if (!string.IsNullOrEmpty(cRMspSelectOnlinePayBankInfoByName_Result.BankLoginPassword))
							{
								XorCipher.DecryptByPrivateKey(cRMspSelectOnlinePayBankInfoByName_Result.BankLoginPassword);
							}
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankTerminalCode;
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankAcceptorCode;
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankSignKey;
							string[] array4 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
							if (!string.IsNullOrWhiteSpace(text))
							{
								array4 = text.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
							}
							_ = array4[0] + "/OnlinePayment/Home/PasargadPaymentCallback";
							int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankOrdPayTypeId.ToString(), out result10);
							int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankPordPayTypeId.ToString(), out result11);
						}
						if (!string.IsNullOrWhiteSpace(value4) && !string.IsNullOrWhiteSpace(text10))
						{
							string content2 = "{ \"invoice\": \"" + invoiceId + "\", \"urlId\":\"" + text10 + "\"}";
							if (text12.EndsWith("/"))
							{
								text12 = text12.TrimEnd(new char[1] { '/' });
							}
							string text13 = text12 + "/api/payment/verify-payment";
							HttpClient httpClient2 = new HttpClient();
							string text14 = text13;
							httpClient2.BaseAddress = new Uri(text14);
							httpClient2.DefaultRequestHeaders.Add("Authorization", value4);
							httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
							StringContent content3 = new StringContent(content2, Encoding.UTF8, "application/x-www-form-urlencoded");
							ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
							HttpResponseMessage result14 = httpClient2.PostAsync(text14, content3).Result;
							if (result14.IsSuccessStatusCode)
							{
								string text15 = result14.Content.ReadAsStringAsync().Result;
								if (!string.IsNullOrWhiteSpace(text15))
								{
									text15 = text15.Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}");
									text15 = text15.ClearHiddenCharacters();
								}
								PasargadVerifyPaymentResponseViewModel pasargadVerifyPaymentResponseViewModel = JsonConvert.DeserializeObject<PasargadVerifyPaymentResponseViewModel>(text15);
								if (pasargadVerifyPaymentResponseViewModel != null)
								{
									if (pasargadVerifyPaymentResponseViewModel.resultCode.GetValueOrDefault() == 0)
									{
										if (pasargadVerifyPaymentResponseViewModel.data != null)
										{
											text11 = "1";
											long.TryParse(pasargadVerifyPaymentResponseViewModel.data.amount.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out var result15);
											if (cRMspSelectOnlinePayBankInfoByName_Result != null)
											{
												text11 = (cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.HasValue ? cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.ToString() : "1");
											}
											result15 /= long.Parse(text11);
											decimal result16 = default(decimal);
											decimal.TryParse(result15.ToString(), out result16);
											string text16 = pasargadVerifyPaymentResponseViewModel.data.referenceNumber ?? "";
											string payDescription2 = "";
											InsertPayment(result16, text16, payDescription2, result10, result11);
											bankCallBackViewModel.IsSuccess = true;
											bankCallBackViewModel.Amount = result16;
											bankCallBackViewModel.ShaparakRefNumber = text16;
											bankCallBackViewModel.Message = "";
											bankCallBackViewModel.MaskedCardNumber = pasargadVerifyPaymentResponseViewModel.data.maskedCardNumber ?? "";
											bankCallBackViewModel.HashedCardNumber = pasargadVerifyPaymentResponseViewModel.data.hashedCardNumber ?? "";
											bankCallBackViewModel.ShaparakRefNumber = pasargadVerifyPaymentResponseViewModel.data.referenceNumber ?? "";
											base.ViewBag.Error = "";
										}
										else
										{
											base.ViewBag.Error = pasargadVerifyPaymentResponseViewModel.resultMsg;
											bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction + "<br>" + pasargadVerifyPaymentResponseViewModel.resultMsg;
										}
									}
									else
									{
										base.ViewBag.Error = pasargadVerifyPaymentResponseViewModel.resultMsg;
										bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction + "<br>" + pasargadVerifyPaymentResponseViewModel.resultMsg;
									}
								}
								else
								{
									bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction;
								}
							}
							else
							{
								bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction;
							}
						}
						else
						{
							bankCallBackViewModel.ErrorMessage = Messages.msgErrorReceivingToken;
						}
						break;
					}
					string errorMessage = Messages.FOMsgErrorCallBack;
					if (!string.IsNullOrWhiteSpace(text9))
					{
						errorMessage = Messages.msgErrorPayNotMade;
					}
					bankCallBackViewModel.ErrorMessage = errorMessage;
					if (result4 == 0 && result5 == 1)
					{
						switch (result3)
						{
						case 1:
						case 10:
							DeleteOrderOrPreOrder(result8, 0);
							break;
						case 2:
						case 20:
							DeleteOrderOrPreOrder(0, result6, listOrdIssued);
							break;
						}
					}
					break;
				}
				bankCallBackViewModel.ErrorMessage = Messages.FOMsgErrorCallBack;
				if (result4 == 0 && result5 == 1)
				{
					switch (result3)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(result8, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, result6, listOrdIssued);
						break;
					}
				}
				break;
			}
			case 3:
			{
				MellatCallBackViewModel mellatCallBackViewModel = _mellatCallBackViewModel;
				if (!string.IsNullOrWhiteSpace(mellatCallBackViewModel.RefId) && !string.IsNullOrWhiteSpace(mellatCallBackViewModel.ResCode) && mellatCallBackViewModel.SaleOrderId > 0 && mellatCallBackViewModel.SaleReferenceId > 0)
				{
					string mellatRequestResult = GetMellatRequestResult(mellatCallBackViewModel.ResCode);
					if (!string.IsNullOrWhiteSpace(mellatRequestResult))
					{
						bankCallBackViewModel.ErrorMessage = mellatRequestResult;
						return bankCallBackViewModel;
					}
					string text20 = "1";
					string userName = "";
					string userPassword = "";
					string s = "";
					if (cRMspSelectOnlinePayBankInfoByName_Result == null)
					{
						cRMspSelectOnlinePayBankInfoByName_Result = CRMIdeal.Classes.Helper.OnlinePayment.GetOnlinePayBankInfo(0, "ملت");
					}
					if (cRMspSelectOnlinePayBankInfoByName_Result != null)
					{
						text20 = (cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.HasValue ? cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.ToString() : "1");
						userName = cRMspSelectOnlinePayBankInfoByName_Result.BankLoginAccount ?? "";
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankAdditionalData;
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankIPGPageUrl;
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankPGWSaleServiceUrl;
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankPGWConfirmServiceUrl;
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankReversalServiceUrl;
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankSalePaymentCallback;
						cRMspSelectOnlinePayBankInfoByName_Result.BankingBankID.GetValueOrDefault();
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankingBank;
						userPassword = ((!string.IsNullOrEmpty(cRMspSelectOnlinePayBankInfoByName_Result.BankLoginPassword)) ? XorCipher.DecryptByPrivateKey(cRMspSelectOnlinePayBankInfoByName_Result.BankLoginPassword) : "");
						s = cRMspSelectOnlinePayBankInfoByName_Result.BankTerminalCode ?? "";
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankAcceptorCode;
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankSignKey;
						string[] array6 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
						if (!string.IsNullOrWhiteSpace(text))
						{
							array6 = text.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
						}
						_ = array6[0] + "/OnlinePayment/Home/MellatPaymentCallBack";
						int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankOrdPayTypeId.ToString(), out result10);
						int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankPordPayTypeId.ToString(), out result11);
					}
					PaymentGatewayClient paymentGatewayClient = new PaymentGatewayClient();
					if (cRMspSelectOnlinePayBankInfoByName_Result == null)
					{
						bankCallBackViewModel.ErrorMessage = Messages.msgErrorOperationFailed;
						if (result4 == 0 && result5 == 1)
						{
							switch (result3)
							{
							case 1:
							case 10:
								DeleteOrderOrPreOrder(result8, 0);
								break;
							case 2:
							case 20:
								DeleteOrderOrPreOrder(0, result6, listOrdIssued);
								break;
							}
						}
						return bankCallBackViewModel;
					}
					if (mellatCallBackViewModel.ResCode == "0")
					{
						if (paymentGatewayClient.bpVerifyRequest(long.Parse(s), userName, userPassword, mellatCallBackViewModel.SaleOrderId, mellatCallBackViewModel.SaleOrderId, mellatCallBackViewModel.SaleReferenceId) == "0")
						{
							text20 = "1";
							if (cRMspSelectOnlinePayBankInfoByName_Result != null)
							{
								text20 = (cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.HasValue ? cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.ToString() : "1");
							}
							long.TryParse(mellatCallBackViewModel.FinalAmount.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out var result20);
							result20 /= long.Parse(text20);
							decimal result21 = default(decimal);
							decimal.TryParse(result20.ToString(), out result21);
							string text21 = mellatCallBackViewModel.SaleReferenceId.ToString() ?? "";
							string payDescription4 = "";
							InsertPayment(result21, text21, payDescription4, result10, result11);
							bankCallBackViewModel.ShenasehNumber = text21;
							bankCallBackViewModel.Amount = result21;
							bankCallBackViewModel.IsSuccess = true;
							bankCallBackViewModel.Message = "";
							bankCallBackViewModel.ShaparakRefNumber = text21;
							break;
						}
						bankCallBackViewModel.ErrorMessage = Messages.msgErrorOperationFailed;
						if (result4 == 0 && result5 == 1)
						{
							switch (result3)
							{
							case 1:
							case 10:
								DeleteOrderOrPreOrder(result8, 0);
								break;
							case 2:
							case 20:
								DeleteOrderOrPreOrder(0, result6, listOrdIssued);
								break;
							}
						}
						break;
					}
					bankCallBackViewModel.ErrorMessage = Messages.msgErrorOperationFailed;
					if (result4 == 0 && result5 == 1)
					{
						switch (result3)
						{
						case 1:
						case 10:
							DeleteOrderOrPreOrder(result8, 0);
							break;
						case 2:
						case 20:
							DeleteOrderOrPreOrder(0, result6, listOrdIssued);
							break;
						}
					}
					break;
				}
				string mellatRequestResult2 = GetMellatRequestResult(mellatCallBackViewModel.ResCode);
				if (string.IsNullOrWhiteSpace(mellatRequestResult2))
				{
					bankCallBackViewModel.ErrorMessage = Messages.FOMsgErrorCallBack;
				}
				else
				{
					bankCallBackViewModel.ErrorMessage = mellatRequestResult2;
				}
				if (result4 == 0 && result5 == 1)
				{
					switch (result3)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(result8, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, result6, listOrdIssued);
						break;
					}
				}
				break;
			}
			case 4:
			{
				_ = _zarinPalCallBackViewModel;
				decimal result24 = default(decimal);
				if (base.Request.Cookies["ShopOnlinePaymentOprAmount"] != null)
				{
					new HttpCookie("ShopOnlinePaymentOprAmount");
					decimal.TryParse(base.Request.Cookies["ShopOnlinePaymentOprAmount"].Value, out result24);
				}
				if (result2 > 0)
				{
					if (base.Request.QueryString["Status"] != "" && base.Request.QueryString["Status"] != null && base.Request.QueryString["Authority"] != "" && base.Request.QueryString["Authority"] != null)
					{
						if (base.Request.QueryString["Status"].ToString().Equals("OK"))
						{
							if (cRMspSelectOnlinePayBankInfoByName_Result == null)
							{
								cRMspSelectOnlinePayBankInfoByName_Result = CRMIdeal.Classes.Helper.OnlinePayment.GetOnlinePayBankInfo(0, "زرین پال");
							}
							if (cRMspSelectOnlinePayBankInfoByName_Result != null)
							{
								string s3 = (cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.HasValue ? cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.ToString() : "1");
								string merchantID = cRMspSelectOnlinePayBankInfoByName_Result.BankLoginAccount ?? "";
								_ = cRMspSelectOnlinePayBankInfoByName_Result.BankAdditionalData;
								int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankOrdPayTypeId.ToString(), out result10);
								int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankPordPayTypeId.ToString(), out result11);
								int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result25);
								if (result25 <= 0)
								{
									result25 = 1065;
								}
								_ = Thread.CurrentThread.CurrentCulture.LCID;
								long num3 = long.Parse(result24.ToString().Replace(".00", "").Replace(".0", "")) / long.Parse(s3);
								int amount = int.Parse(num3.ToString());
								string authority = base.Request.QueryString["Authority"].ToString();
								ServicePointManager.Expect100Continue = false;
								long RefID;
								int num4 = new PaymentGatewayImplementationServicePortTypeClient().PaymentVerification(merchantID, authority, amount, out RefID);
								if (num4 == 100)
								{
									s3 = "1";
									if (cRMspSelectOnlinePayBankInfoByName_Result != null)
									{
										s3 = (cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.HasValue ? cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.ToString() : "1");
									}
									num3 *= long.Parse(s3);
									decimal result26 = default(decimal);
									decimal.TryParse(num3.ToString(), out result26);
									string payDocNumber3 = ((RefID != 0L) ? RefID.ToString() : "");
									string payDescription6 = "";
									InsertPayment(result26, payDocNumber3, payDescription6, result10, result11);
									bankCallBackViewModel.RefId = RefID;
									bankCallBackViewModel.Amount = num3;
									break;
								}
								string text24 = "";
								switch (num4)
								{
								case -1:
									text24 = Messages.msgErrorZarinPalStatus_1;
									break;
								case -2:
									text24 = Messages.msgErrorZarinPalStatus_2;
									break;
								case -3:
									text24 = Messages.msgErrorZarinPalStatus_3;
									break;
								case -4:
									text24 = Messages.msgErrorZarinPalStatus_4;
									break;
								case -11:
									text24 = Messages.msgErrorZarinPalStatus_11;
									break;
								case -12:
									text24 = Messages.msgErrorZarinPalStatus_12;
									break;
								case -21:
									text24 = Messages.msgErrorZarinPalStatus_21;
									break;
								case -22:
									text24 = Messages.msgErrorZarinPalStatus_22;
									break;
								case -33:
									text24 = Messages.msgErrorZarinPalStatus_33;
									break;
								case -34:
									text24 = Messages.msgErrorZarinPalStatus_34;
									break;
								case -40:
									text24 = Messages.msgErrorZarinPalStatus_40;
									break;
								case -41:
									text24 = Messages.msgErrorZarinPalStatus_41;
									break;
								case -42:
									text24 = Messages.msgErrorZarinPalStatus_42;
									break;
								case -54:
									text24 = Messages.msgErrorZarinPalStatus_54;
									break;
								case 101:
									text24 = Messages.msgErrorZarinPalStatus_101;
									break;
								}
								bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction + "<br>" + text24;
								if (result4 == 0 && result5 == 1)
								{
									switch (result3)
									{
									case 1:
									case 10:
										DeleteOrderOrPreOrder(result8, 0);
										break;
									case 2:
									case 20:
										DeleteOrderOrPreOrder(0, result6, listOrdIssued);
										break;
									}
								}
								break;
							}
							bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction + "<br>" + Messages.FOMsgErrorPayGatewaySettingNotSet;
							if (result4 == 0 && result5 == 1)
							{
								switch (result3)
								{
								case 1:
								case 10:
									DeleteOrderOrPreOrder(result8, 0);
									break;
								case 2:
								case 20:
									DeleteOrderOrPreOrder(0, result6, listOrdIssued);
									break;
								}
							}
							break;
						}
						bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction + "<br>Error! Authority: " + base.Request.QueryString["Authority"].ToString() + "<br> Status: " + base.Request.QueryString["Status"].ToString();
						if (result4 == 0 && result5 == 1)
						{
							switch (result3)
							{
							case 1:
							case 10:
								DeleteOrderOrPreOrder(result8, 0);
								break;
							case 2:
							case 20:
								DeleteOrderOrPreOrder(0, result6, listOrdIssued);
								break;
							}
						}
						break;
					}
					bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorNotResponseFromPayGateway;
					if (result4 == 0 && result5 == 1)
					{
						switch (result3)
						{
						case 1:
						case 10:
							DeleteOrderOrPreOrder(result8, 0);
							break;
						case 2:
						case 20:
							DeleteOrderOrPreOrder(0, result6, listOrdIssued);
							break;
						}
					}
					break;
				}
				bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction + "<br>" + Messages.FOMsgErrorCallBack + "<br>" + Messages.msgErrorNotResponseFromPayGateway;
				if (result4 == 0 && result5 == 1)
				{
					switch (result3)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(result8, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, result6, listOrdIssued);
						break;
					}
				}
				break;
			}
			case 5:
			{
				SamanBankCallBackViewModelI samanBankCallBackViewModel = _samanBankCallBackViewModel;
				if (!string.IsNullOrWhiteSpace(samanBankCallBackViewModel.TransactionReferenceID) || samanBankCallBackViewModel.Status != 0)
				{
					if (samanBankCallBackViewModel.Status == 2)
					{
						string text17 = "1";
						string uriString = "";
						string text18 = "";
						if (cRMspSelectOnlinePayBankInfoByName_Result == null)
						{
							cRMspSelectOnlinePayBankInfoByName_Result = CRMIdeal.Classes.Helper.OnlinePayment.GetOnlinePayBankInfo(0, "سامان");
						}
						if (cRMspSelectOnlinePayBankInfoByName_Result != null)
						{
							text17 = (cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.HasValue ? cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.ToString() : "1");
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankLoginAccount;
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankAdditionalData;
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankIPGPageUrl;
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankPGWSaleServiceUrl;
							uriString = cRMspSelectOnlinePayBankInfoByName_Result.BankPGWConfirmServiceUrl ?? "";
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankReversalServiceUrl;
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankSalePaymentCallback;
							cRMspSelectOnlinePayBankInfoByName_Result.BankingBankID.GetValueOrDefault();
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankingBank;
							if (!string.IsNullOrEmpty(cRMspSelectOnlinePayBankInfoByName_Result.BankLoginPassword))
							{
								XorCipher.DecryptByPrivateKey(cRMspSelectOnlinePayBankInfoByName_Result.BankLoginPassword);
							}
							text18 = cRMspSelectOnlinePayBankInfoByName_Result.BankTerminalCode ?? "";
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankAcceptorCode;
							_ = cRMspSelectOnlinePayBankInfoByName_Result.BankSignKey;
							string[] array5 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
							if (!string.IsNullOrWhiteSpace(text))
							{
								array5 = text.Split(new string[1] { "/OnlinePayment/" }, StringSplitOptions.None);
							}
							_ = array5[0] + "/OnlinePayment/Home/SamanPaymentCallBack";
							int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankOrdPayTypeId.ToString(), out result10);
							int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankPordPayTypeId.ToString(), out result11);
						}
						StringContent content4 = new StringContent("{\"RefNum\": \"" + samanBankCallBackViewModel.TransactionReferenceID + "\", \"TerminalNumber\": " + text18 + "}", Encoding.UTF8, "application/json");
						HttpRequestMessage request = new HttpRequestMessage
						{
							RequestUri = new Uri(uriString),
							Method = HttpMethod.Post,
							Content = content4
						};
						HttpResponseMessage result17 = new HttpClient
						{
							DefaultRequestHeaders = 
							{
								Accept = 
								{
									new MediaTypeWithQualityHeaderValue("application/json")
								}
							}
						}.SendAsync(request).Result;
						if (result17.IsSuccessStatusCode)
						{
							SamanBankCallBackViewModel samanBankCallBackViewModel2 = JsonConvert.DeserializeObject<SamanBankCallBackViewModel>(result17.Content.ReadAsStringAsync().Result);
							if (samanBankCallBackViewModel2 != null)
							{
								bool valueOrDefault = samanBankCallBackViewModel2.Success.GetValueOrDefault();
								int valueOrDefault2 = samanBankCallBackViewModel2.ResultCode.GetValueOrDefault();
								long num = 0L;
								if (samanBankCallBackViewModel2.TransactionDetail != null)
								{
									bankCallBackViewModel.ReceiptDigital = samanBankCallBackViewModel2.TransactionDetail.RefNum ?? "";
									bankCallBackViewModel.RefNumber = samanBankCallBackViewModel2.TransactionDetail.StraceNo ?? "";
									bankCallBackViewModel.MaskedCardNumber = samanBankCallBackViewModel2.TransactionDetail.MaskedPan ?? "";
									bankCallBackViewModel.HashedCardNumber = samanBankCallBackViewModel2.TransactionDetail.HashedPan ?? "";
									num = samanBankCallBackViewModel2.TransactionDetail.OrginalAmount.GetValueOrDefault();
								}
								if (valueOrDefault && valueOrDefault2 == 0)
								{
									bankCallBackViewModel.IsSuccess = true;
									text17 = "1";
									long.TryParse(num.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out var result18);
									if (cRMspSelectOnlinePayBankInfoByName_Result != null)
									{
										text17 = (cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.HasValue ? cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.ToString() : "1");
									}
									result18 /= long.Parse(text17);
									decimal result19 = default(decimal);
									decimal.TryParse(result18.ToString(), out result19);
									string payDocNumber2 = bankCallBackViewModel.RefNumber ?? "";
									string payDescription3 = Labels.FOPaymentCallbackReceiptDigital + " = " + bankCallBackViewModel.ReceiptDigital;
									InsertPayment(result19, payDocNumber2, payDescription3, result10, result11);
									bankCallBackViewModel.Amount = num;
									break;
								}
								base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + samanBankCallBackViewModel2.ResultDescription + " (Code= " + valueOrDefault2 + ")";
								if (result4 == 0 && result5 == 1)
								{
									switch (result3)
									{
									case 1:
									case 10:
										DeleteOrderOrPreOrder(result8, 0);
										break;
									case 2:
									case 20:
										DeleteOrderOrPreOrder(0, result6, listOrdIssued);
										break;
									}
								}
								break;
							}
							base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorReceivingToken;
							if (result4 == 0 && result5 == 1)
							{
								switch (result3)
								{
								case 1:
								case 10:
									DeleteOrderOrPreOrder(result8, 0);
									break;
								case 2:
								case 20:
									DeleteOrderOrPreOrder(0, result6, listOrdIssued);
									break;
								}
							}
							break;
						}
						base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorReceivingToken;
						if (result4 == 0 && result5 == 1)
						{
							switch (result3)
							{
							case 1:
							case 10:
								DeleteOrderOrPreOrder(result8, 0);
								break;
							case 2:
							case 20:
								DeleteOrderOrPreOrder(0, result6, listOrdIssued);
								break;
							}
						}
						break;
					}
					string text19 = "";
					switch (samanBankCallBackViewModel.Status)
					{
					case 1:
						text19 = Messages.msgErrorSamanBankStatus_1;
						break;
					case 3:
						text19 = Messages.msgErrorSamanBankStatus_3;
						break;
					case 4:
						text19 = Messages.msgErrorSamanBankStatus_4;
						break;
					case 5:
						text19 = Messages.msgErrorSamanBankStatus_5;
						break;
					case 8:
						text19 = Messages.msgErrorSamanBankStatus_8;
						break;
					case 10:
						text19 = Messages.msgErrorSamanBankStatus_10;
						break;
					case 11:
						text19 = Messages.msgErrorSamanBankStatus_11;
						break;
					case 12:
						text19 = Messages.msgErrorSamanBankStatus_12;
						break;
					}
					bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction + "<br>" + text19 + " (Code = " + samanBankCallBackViewModel.Status + ")";
					if (result4 == 0 && result5 == 1)
					{
						switch (result3)
						{
						case 1:
						case 10:
							DeleteOrderOrPreOrder(result8, 0);
							break;
						case 2:
						case 20:
							DeleteOrderOrPreOrder(0, result6, listOrdIssued);
							break;
						}
					}
					break;
				}
				bankCallBackViewModel.ErrorMessage = Messages.FOMsgErrorCallBack;
				if (result4 == 0 && result5 == 1)
				{
					switch (result3)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(result8, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, result6, listOrdIssued);
						break;
					}
				}
				break;
			}
			case 6:
			{
				BinaPaySharifCallBackViewModel binaPaySharifCallBackViewModel = _binaPaySharifCallBackViewModel;
				if (!string.IsNullOrWhiteSpace(binaPaySharifCallBackViewModel.OrderGUID) || binaPaySharifCallBackViewModel.OrderID != 0L)
				{
					string text2 = "";
					string text3 = "";
					string text4 = "";
					string text5 = "";
					if (cRMspSelectOnlinePayBankInfoByName_Result == null)
					{
						cRMspSelectOnlinePayBankInfoByName_Result = CRMIdeal.Classes.Helper.OnlinePayment.GetOnlinePayBankInfo(0, "بیناپی");
					}
					if (cRMspSelectOnlinePayBankInfoByName_Result != null)
					{
						if (cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.HasValue)
						{
							cRMspSelectOnlinePayBankInfoByName_Result.BankCurrencyRate.ToString();
						}
						text2 = cRMspSelectOnlinePayBankInfoByName_Result.BankLoginAccount ?? "";
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankAdditionalData;
						text3 = cRMspSelectOnlinePayBankInfoByName_Result.BankIPGPageUrl ?? "";
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankPGWSaleServiceUrl;
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankPGWConfirmServiceUrl;
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankReversalServiceUrl;
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankSalePaymentCallback;
						cRMspSelectOnlinePayBankInfoByName_Result.BankingBankID.GetValueOrDefault();
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankingBank;
						text4 = ((!string.IsNullOrEmpty(cRMspSelectOnlinePayBankInfoByName_Result.BankLoginPassword)) ? XorCipher.DecryptByPrivateKey(cRMspSelectOnlinePayBankInfoByName_Result.BankLoginPassword) : "");
						text5 = cRMspSelectOnlinePayBankInfoByName_Result.BankTerminalCode ?? "";
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankAcceptorCode;
						_ = cRMspSelectOnlinePayBankInfoByName_Result.BankSignKey;
						int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankOrdPayTypeId.ToString(), out result10);
						int.TryParse(cRMspSelectOnlinePayBankInfoByName_Result.BankPordPayTypeId.ToString(), out result11);
					}
					decimal result12 = default(decimal);
					if (base.Request.Cookies["ShopOnlinePaymentOprAmount"] != null)
					{
						new HttpCookie("ShopOnlinePaymentOprAmount");
						decimal.TryParse(base.Request.Cookies["ShopOnlinePaymentOprAmount"].Value, out result12);
					}
					if (!text3.EndsWith("/"))
					{
						text3 = text3 + text3 + "/";
					}
					string text6 = text3;
					text6 += "api/API";
					string arg = "{\"FN\": \"Status2\", \"TerminalID\": " + text5 + ", \"Username\": \"" + text2 + "\", \"Password\": \"" + text4 + "\", \"OrderID\":" + binaPaySharifCallBackViewModel.OrderID + ", \"OrderGUID\": \"" + binaPaySharifCallBackViewModel.OrderGUID + "\" }";
					HttpClient httpClient = new HttpClient();
					string text7 = text6;
					httpClient.BaseAddress = new Uri(text7);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					StringContent content = new StringContent($"INPUT={arg}", Encoding.UTF8, "application/x-www-form-urlencoded");
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
					HttpResponseMessage result13 = httpClient.PostAsync(text7, content).Result;
					if (result13.IsSuccessStatusCode)
					{
						string text8 = result13.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(text8))
						{
							text8 = text8.Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}");
							text8 = text8.ClearHiddenCharacters();
						}
						BinaPaySharifFourthStepResultViewModel binaPaySharifFourthStepResultViewModel = JsonConvert.DeserializeObject<BinaPaySharifFourthStepResultViewModel>(text8);
						if (binaPaySharifFourthStepResultViewModel != null)
						{
							if (binaPaySharifFourthStepResultViewModel.Result == 0)
							{
								bankCallBackViewModel.IsSuccess = true;
								bankCallBackViewModel.RefNumber = binaPaySharifFourthStepResultViewModel.ReferenceID.ToString();
								decimal payAmount = result12;
								string payDocNumber = bankCallBackViewModel.RefNumber ?? "";
								string payDescription = "";
								InsertPayment(payAmount, payDocNumber, payDescription, result10, result11);
								bankCallBackViewModel.Amount = result12;
								break;
							}
							bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction + "<br>" + binaPaySharifFourthStepResultViewModel.Message;
							if (result4 == 0 && result5 == 1)
							{
								switch (result3)
								{
								case 1:
								case 10:
									DeleteOrderOrPreOrder(result8, 0);
									break;
								case 2:
								case 20:
									DeleteOrderOrPreOrder(0, result6, listOrdIssued);
									break;
								}
							}
							break;
						}
						bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction;
						if (result4 == 0 && result5 == 1)
						{
							switch (result3)
							{
							case 1:
							case 10:
								DeleteOrderOrPreOrder(result8, 0);
								break;
							case 2:
							case 20:
								DeleteOrderOrPreOrder(0, result6, listOrdIssued);
								break;
							}
						}
						break;
					}
					bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction;
					if (result4 == 0 && result5 == 1)
					{
						switch (result3)
						{
						case 1:
						case 10:
							DeleteOrderOrPreOrder(result8, 0);
							break;
						case 2:
						case 20:
							DeleteOrderOrPreOrder(0, result6, listOrdIssued);
							break;
						}
					}
					break;
				}
				bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction;
				if (result4 == 0 && result5 == 1)
				{
					switch (result3)
					{
					case 1:
					case 10:
						DeleteOrderOrPreOrder(result8, 0);
						break;
					case 2:
					case 20:
						DeleteOrderOrPreOrder(0, result6, listOrdIssued);
						break;
					}
				}
				break;
			}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			bankCallBackViewModel.ErrorMessage = Messages.msgErrorRunFunction;
		}
		return bankCallBackViewModel;
	}

	public ActionResult ShowOprDetails(string t)
	{
		int typeId = 0;
		string message = "";
		try
		{
			if (string.IsNullOrWhiteSpace(t))
			{
				message = Messages.ErrorNotFound;
			}
			else
			{
				t = CodeDecode.DeCoddingUTF8(t);
				string[] array = t.Split(new char[1] { '|' });
				if (array.Length <= 1)
				{
					message = Messages.ErrorNotFound;
				}
				else
				{
					if (int.Parse(array[0]) == 30)
					{
						return RedirectToAction("ShowOrder", (object)new
						{
							i = CodeDecode.CoddingUTF8(array[1])
						});
					}
					if (int.Parse(array[0]) == 20)
					{
						return RedirectToAction("ShowPreOrder", (object)new
						{
							i = CodeDecode.CoddingUTF8(array[1])
						});
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			message = Messages.ErrorNotFound;
		}
		return RedirectToAction("ShowError", (object)new { typeId, message });
	}

	public ActionResult ShowOrder(string i = "")
	{
		int result = 0;
		try
		{
			if (!string.IsNullOrWhiteSpace(i))
			{
				int.TryParse(CodeDecode.DeCoddingUTF8(i), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdId = result;
		return View();
	}

	[HttpPost]
	public JsonResult GetOrder(int ordId)
	{
		OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel();
		orderDetailsViewModel.Order = new WSspSelectOrderById_Result();
		orderDetailsViewModel.OrderItems = new List<WSspSelectOrderItems_Result>();
		orderDetailsViewModel.Message = "";
		orderDetailsViewModel.IsFind = false;
		orderDetailsViewModel.OrderPayments = new List<WSspSelectOrderPayments_Result>();
		orderDetailsViewModel.AllPayRemain = default(decimal);
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(ordId, lCID, result));
			if (wSspSelectOrderById_Result != null)
			{
				bool result2 = false;
				bool.TryParse(wSspSelectOrderById_Result.ordIsVerified.ToString(), out result2);
				if (!result2)
				{
					orderDetailsViewModel.IsFind = false;
					orderDetailsViewModel.Message = Messages.ErrorNotFound;
				}
				else
				{
					wSspSelectOrderById_Result.ordDate = (wSspSelectOrderById_Result.ordDateTime.HasValue ? wSspSelectOrderById_Result.ordDateTime.Value.ToString("yyyy/MM/dd") : null);
					wSspSelectOrderById_Result.ordDeliveryDate = (wSspSelectOrderById_Result.ordDeliveryDateTime.HasValue ? (wSspSelectOrderById_Result.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd HH:mm") + ((!string.IsNullOrEmpty(wSspSelectOrderById_Result.ordDeliveryEndTime)) ? (" - " + wSspSelectOrderById_Result.ordDeliveryEndTime) : "")) : null);
					int ordCompanyId = wSspSelectOrderById_Result.ordCompanyId;
					wSspSelectOrderById_Result.CompanyName += ((!string.IsNullOrWhiteSpace(wSspSelectOrderById_Result.CompanyPerson)) ? (" (" + wSspSelectOrderById_Result.CompanyPerson + ")") : "");
					orderDetailsViewModel.Order = wSspSelectOrderById_Result;
					orderDetailsViewModel.IsFind = true;
					List<WSspSelectOrderItems_Result> list2 = (orderDetailsViewModel.OrderItems = Enumerable.ToList<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(ordId, lCID, result)));
					bool result3 = false;
					CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
					if (foSetting != null)
					{
						bool.TryParse(foSetting.FoShowOrdByTspMethod.ToString(), out result3);
					}
					if (VersionBuyer.Tsp && result3 && list2 != null && Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list2))
					{
						CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
						int result4 = 1;
						if (cRMspSelectCrmsysSetting_Result != null)
						{
							int.TryParse(cRMspSelectCrmsysSetting_Result.TspPrdSendMethod.ToString(), out result4);
						}
						if (result4 == 0)
						{
							result4 = 1;
						}
						List<WSspSelectOrderItems_Result> list3 = new List<WSspSelectOrderItems_Result>();
						switch (result4)
						{
						case 1:
							foreach (WSspSelectOrderItems_Result item in list2)
							{
								string fgIdentify = item.TspFGIndentify;
								if (!string.IsNullOrWhiteSpace(fgIdentify))
								{
									if (list3 != null && Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list3))
									{
										if (Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list3, (Func<WSspSelectOrderItems_Result, bool>)((WSspSelectOrderItems_Result m) => m.TspFGIndentify == fgIdentify)) != null)
										{
											foreach (WSspSelectOrderItems_Result item2 in list3)
											{
												if (!string.IsNullOrWhiteSpace(item2.TspFGIndentify) && item2.TspFGIndentify == fgIdentify)
												{
													item2.ordIQuantity = 1.0;
													item2.ordIFCR = 1.0;
													item2.ordIFCRI = 1.0;
													item2.ordIPrice = item2.ordIPrice.GetValueOrDefault() + item.ordIPrice.GetValueOrDefault();
													item2.ordITotalPrice = item2.ordITotalPrice.GetValueOrDefault() + item.ordITotalPrice.GetValueOrDefault();
													item2.ordIDiscountI = item2.ordIDiscountI.GetValueOrDefault() + item.ordIDiscountI.GetValueOrDefault();
													item2.ordIDiscount = item2.ordIDiscount.GetValueOrDefault() + item.ordIDiscount.GetValueOrDefault();
													item2.ordITax = item2.ordITax.GetValueOrDefault() + item.ordITax.GetValueOrDefault();
													item2.ordITaxIndex = item2.ordITaxIndex.GetValueOrDefault();
													item2.ordIRound = item2.ordIRound.GetValueOrDefault() + item.ordIRound.GetValueOrDefault();
													item2.ordIRoundPlus = item2.ordIRoundPlus.GetValueOrDefault() + item.ordIRoundPlus.GetValueOrDefault();
													item2.ordIPriceSum = item2.ordIPriceSum.GetValueOrDefault() + item.ordIPriceSum.GetValueOrDefault();
													item2.ordIDiscountISum = item2.ordIDiscountISum.GetValueOrDefault() + item.ordIDiscountISum.GetValueOrDefault();
													item2.ordIDiscountSum = item2.ordIDiscountSum.GetValueOrDefault() + item.ordIDiscountSum.GetValueOrDefault();
													item2.ordITaxSum = item2.ordITaxSum.GetValueOrDefault() + item.ordITaxSum.GetValueOrDefault();
													item2.ordIPriceSumWithoutDiscount = item2.ordIPriceSumWithoutDiscount.GetValueOrDefault() + item.ordIPriceSumWithoutDiscount.GetValueOrDefault();
													item2.ordIPrice = item2.ordIPriceSumWithoutDiscount;
												}
											}
										}
										else
										{
											item.TspPrdIndentify = item.TspFGIndentify;
											item.TspPrdName = item.TspFGName;
											item.PrdName = item.TspFGName;
											list3.Add(item);
										}
									}
									else
									{
										item.TspPrdIndentify = item.TspFGIndentify;
										item.TspPrdName = item.TspFGName;
										item.PrdName = item.TspFGName;
										list3.Add(item);
									}
								}
								else
								{
									list3.Add(item);
								}
							}
							break;
						case 2:
							foreach (WSspSelectOrderItems_Result item3 in list2)
							{
								if (!string.IsNullOrWhiteSpace(item3.TspPrdIndentify))
								{
									item3.PrdName = item3.TspPrdName;
									list3.Add(item3);
								}
								else
								{
									list3.Add(item3);
								}
							}
							break;
						case 3:
							foreach (WSspSelectOrderItems_Result item4 in list2)
							{
								string sgIdentify = item4.TspSGIndentify;
								if (!string.IsNullOrWhiteSpace(sgIdentify))
								{
									if (list3 != null && Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list3))
									{
										if (Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list3, (Func<WSspSelectOrderItems_Result, bool>)((WSspSelectOrderItems_Result m) => m.TspSGIndentify == sgIdentify)) != null)
										{
											foreach (WSspSelectOrderItems_Result item5 in list3)
											{
												if (!string.IsNullOrWhiteSpace(item5.TspSGIndentify) && item5.TspSGIndentify == sgIdentify)
												{
													item5.ordIQuantity = 1.0;
													item5.ordIFCR = 1.0;
													item5.ordIFCRI = 1.0;
													item5.ordIPrice = item5.ordIPrice.GetValueOrDefault() + item4.ordIPrice.GetValueOrDefault();
													item5.ordITotalPrice = item5.ordITotalPrice.GetValueOrDefault() + item4.ordITotalPrice.GetValueOrDefault();
													item5.ordIDiscountI = item5.ordIDiscountI.GetValueOrDefault() + item4.ordIDiscountI.GetValueOrDefault();
													item5.ordIDiscount = item5.ordIDiscount.GetValueOrDefault() + item4.ordIDiscount.GetValueOrDefault();
													item5.ordITax = item5.ordITax.GetValueOrDefault() + item4.ordITax.GetValueOrDefault();
													item5.ordITaxIndex = item5.ordITaxIndex.GetValueOrDefault();
													item5.ordIRound = item5.ordIRound.GetValueOrDefault() + item4.ordIRound.GetValueOrDefault();
													item5.ordIRoundPlus = item5.ordIRoundPlus.GetValueOrDefault() + item4.ordIRoundPlus.GetValueOrDefault();
													item5.ordIPriceSum = item5.ordIPriceSum.GetValueOrDefault() + item4.ordIPriceSum.GetValueOrDefault();
													item5.ordIDiscountISum = item5.ordIDiscountISum.GetValueOrDefault() + item4.ordIDiscountISum.GetValueOrDefault();
													item5.ordIDiscountSum = item5.ordIDiscountSum.GetValueOrDefault() + item4.ordIDiscountSum.GetValueOrDefault();
													item5.ordITaxSum = item5.ordITaxSum.GetValueOrDefault() + item4.ordITaxSum.GetValueOrDefault();
													item5.ordIPriceSumWithoutDiscount = item5.ordIPriceSumWithoutDiscount.GetValueOrDefault() + item4.ordIPriceSumWithoutDiscount.GetValueOrDefault();
													item5.ordIPrice = item5.ordIPriceSumWithoutDiscount;
												}
											}
										}
										else
										{
											item4.TspPrdIndentify = item4.TspSGIndentify;
											item4.TspPrdName = item4.TspSGName;
											item4.PrdName = item4.TspSGName;
											list3.Add(item4);
										}
									}
									else
									{
										item4.TspPrdIndentify = item4.TspSGIndentify;
										item4.TspPrdName = item4.TspSGName;
										item4.PrdName = item4.TspSGName;
										list3.Add(item4);
									}
								}
								else
								{
									list3.Add(item4);
								}
							}
							break;
						}
						if (list3 != null && Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list3))
						{
							orderDetailsViewModel.OrderItems = list3;
						}
					}
					orderDetailsViewModel.OrderPayments = Enumerable.ToList<WSspSelectOrderPayments_Result>((IEnumerable<WSspSelectOrderPayments_Result>)_db.WSspSelectOrderPayments(ordId, lCID, result));
					if (orderDetailsViewModel.OrderPayments != null && Enumerable.Any<WSspSelectOrderPayments_Result>((IEnumerable<WSspSelectOrderPayments_Result>)orderDetailsViewModel.OrderPayments))
					{
						foreach (WSspSelectOrderPayments_Result orderPayment in orderDetailsViewModel.OrderPayments)
						{
							orderPayment.ImportDate = (orderPayment.ImportDateTime.HasValue ? orderPayment.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
							orderPayment.ordpayDocDate = (orderPayment.ordpayDocDateTime.HasValue ? orderPayment.ordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
						}
					}
					if (ordId != 0)
					{
						PrintLog.InsertPrintLog(ordId, 2, 2, ordCompanyId);
					}
					orderDetailsViewModel.AllPayRemain = CRMIdeal.Classes.Helper.Company.GetCompanyAllPayRemain(ordCompanyId);
					if (orderDetailsViewModel.AllPayRemain.GetValueOrDefault() == -1.11m)
					{
						orderDetailsViewModel.AllPayRemain = default(decimal);
					}
				}
			}
			else
			{
				orderDetailsViewModel.IsFind = false;
				orderDetailsViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			orderDetailsViewModel.IsFind = false;
			orderDetailsViewModel.Message = Messages.FOMsgErrorDoneOperation;
		}
		orderDetailsViewModel.PrintFormatFileName = ReturnPrintFormatFileNameById(orderDetailsViewModel.Order.ordPrintFormatId);
		JsonResult jsonResult = Json(orderDetailsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult ShowPreOrder(string i = "")
	{
		int result = 0;
		try
		{
			if (!string.IsNullOrWhiteSpace(i))
			{
				int.TryParse(CodeDecode.DeCoddingUTF8(i), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordId = result;
		return View();
	}

	[HttpPost]
	public JsonResult GetPreOrder(int pordId)
	{
		PreOrderDetailsViewModel preOrderDetailsViewModel = new PreOrderDetailsViewModel();
		preOrderDetailsViewModel.PreOrder = new WSspSelectPreOrderWithId_Result();
		preOrderDetailsViewModel.PreOrderItems = new List<WSspSelectPreOrderItems_Result>();
		preOrderDetailsViewModel.Message = "";
		preOrderDetailsViewModel.IsFind = false;
		preOrderDetailsViewModel.PreOrderPayments = new List<WSspSelectPreOrderPayments_Result>();
		preOrderDetailsViewModel.AllPayRemain = default(decimal);
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				bool result2 = false;
				bool.TryParse(wSspSelectPreOrderWithId_Result.pordIsVerified.ToString(), out result2);
				if (!result2)
				{
					pordId = 0;
				}
				else if (wSspSelectPreOrderWithId_Result.pordExpireDateTime < DateTime.Now)
				{
					pordId = 0;
				}
				else
				{
					wSspSelectPreOrderWithId_Result.pordDate = (wSspSelectPreOrderWithId_Result.pordDateTime.HasValue ? wSspSelectPreOrderWithId_Result.pordDateTime.Value.ToString("yyyy/MM/dd") : null);
					wSspSelectPreOrderWithId_Result.pordDeliveryDate = (wSspSelectPreOrderWithId_Result.pordDeliveryDateTime.HasValue ? (wSspSelectPreOrderWithId_Result.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd HH:mm") + ((!string.IsNullOrEmpty(wSspSelectPreOrderWithId_Result.pordDeliveryEndTime)) ? (" - " + wSspSelectPreOrderWithId_Result.pordDeliveryEndTime) : "")) : null);
					int valueOrDefault = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
					wSspSelectPreOrderWithId_Result.CompanyName += ((!string.IsNullOrWhiteSpace(wSspSelectPreOrderWithId_Result.CompanyPerson)) ? (" (" + wSspSelectPreOrderWithId_Result.CompanyPerson + ")") : "");
					wSspSelectPreOrderWithId_Result.pordTotalAmountStr = wSspSelectPreOrderWithId_Result.pordTotalAmountStr + " " + wSspSelectPreOrderWithId_Result.pordCurrencyUnit;
					preOrderDetailsViewModel.PreOrder = wSspSelectPreOrderWithId_Result;
					preOrderDetailsViewModel.IsFind = true;
					List<WSspSelectPreOrderItems_Result> list2 = (preOrderDetailsViewModel.PreOrderItems = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(pordId, lCID, result)));
					bool result3 = false;
					CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
					if (foSetting != null)
					{
						bool.TryParse(foSetting.FoShowPordByTspMethod.ToString(), out result3);
					}
					if (VersionBuyer.Tsp && result3 && list2 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list2))
					{
						CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
						int result4 = 1;
						if (cRMspSelectCrmsysSetting_Result != null)
						{
							int.TryParse(cRMspSelectCrmsysSetting_Result.TspPrdSendMethod.ToString(), out result4);
						}
						if (result4 == 0)
						{
							result4 = 1;
						}
						List<WSspSelectPreOrderItems_Result> list3 = new List<WSspSelectPreOrderItems_Result>();
						switch (result4)
						{
						case 1:
							foreach (WSspSelectPreOrderItems_Result item in list2)
							{
								string fgIdentify = item.TspFGIndentify;
								if (!string.IsNullOrWhiteSpace(fgIdentify))
								{
									if (list3 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list3))
									{
										if (Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list3, (Func<WSspSelectPreOrderItems_Result, bool>)((WSspSelectPreOrderItems_Result m) => m.TspFGIndentify == fgIdentify)) != null)
										{
											foreach (WSspSelectPreOrderItems_Result item2 in list3)
											{
												if (!string.IsNullOrWhiteSpace(item2.TspFGIndentify) && item2.TspFGIndentify == fgIdentify)
												{
													item2.pordIQuantity = 1.0;
													item2.pordIFCR = 1.0;
													item2.pordIFCRI = 1.0;
													item2.pordIPrice = item2.pordIPrice.GetValueOrDefault() + item.pordIPrice.GetValueOrDefault();
													item2.pordITotalPrice = item2.pordITotalPrice.GetValueOrDefault() + item.pordITotalPrice.GetValueOrDefault();
													item2.pordIDiscountI = item2.pordIDiscountI.GetValueOrDefault() + item.pordIDiscountI.GetValueOrDefault();
													item2.pordIDiscount = item2.pordIDiscount.GetValueOrDefault() + item.pordIDiscount.GetValueOrDefault();
													item2.pordITax = item2.pordITax.GetValueOrDefault() + item.pordITax.GetValueOrDefault();
													item2.pordITaxIndex = item2.pordITaxIndex.GetValueOrDefault();
													item2.pordIRound = item2.pordIRound.GetValueOrDefault() + item.pordIRound.GetValueOrDefault();
													item2.pordIRoundPlus = item2.pordIRoundPlus.GetValueOrDefault() + item.pordIRoundPlus.GetValueOrDefault();
													item2.pordIPriceSum = item2.pordIPriceSum.GetValueOrDefault() + item.pordIPriceSum.GetValueOrDefault();
													item2.pordIDiscountISum = item2.pordIDiscountISum.GetValueOrDefault() + item.pordIDiscountISum.GetValueOrDefault();
													item2.pordIDiscountSum = item2.pordIDiscountSum.GetValueOrDefault() + item.pordIDiscountSum.GetValueOrDefault();
													item2.pordITaxSum = item2.pordITaxSum.GetValueOrDefault() + item.pordITaxSum.GetValueOrDefault();
													item2.pordIPriceSumWithoutDiscount = item2.pordIPriceSumWithoutDiscount.GetValueOrDefault() + item.pordIPriceSumWithoutDiscount.GetValueOrDefault();
													item2.pordIPrice = item2.pordIPriceSumWithoutDiscount;
												}
											}
										}
										else
										{
											item.TspPrdIndentify = item.TspFGIndentify;
											item.TspPrdName = item.TspFGName;
											item.PrdName = item.TspFGName;
											list3.Add(item);
										}
									}
									else
									{
										item.TspPrdIndentify = item.TspFGIndentify;
										item.TspPrdName = item.TspFGName;
										item.PrdName = item.TspFGName;
										list3.Add(item);
									}
								}
								else
								{
									list3.Add(item);
								}
							}
							break;
						case 2:
							foreach (WSspSelectPreOrderItems_Result item3 in list2)
							{
								if (!string.IsNullOrWhiteSpace(item3.TspPrdIndentify))
								{
									item3.PrdName = item3.TspPrdName;
									list3.Add(item3);
								}
								else
								{
									list3.Add(item3);
								}
							}
							break;
						case 3:
							foreach (WSspSelectPreOrderItems_Result item4 in list2)
							{
								string sgIdentify = item4.TspSGIndentify;
								if (!string.IsNullOrWhiteSpace(sgIdentify))
								{
									if (list3 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list3))
									{
										if (Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list3, (Func<WSspSelectPreOrderItems_Result, bool>)((WSspSelectPreOrderItems_Result m) => m.TspSGIndentify == sgIdentify)) != null)
										{
											foreach (WSspSelectPreOrderItems_Result item5 in list3)
											{
												if (!string.IsNullOrWhiteSpace(item5.TspSGIndentify) && item5.TspSGIndentify == sgIdentify)
												{
													item5.pordIQuantity = 1.0;
													item5.pordIFCR = 1.0;
													item5.pordIFCRI = 1.0;
													item5.pordIPrice = item5.pordIPrice.GetValueOrDefault() + item4.pordIPrice.GetValueOrDefault();
													item5.pordITotalPrice = item5.pordITotalPrice.GetValueOrDefault() + item4.pordITotalPrice.GetValueOrDefault();
													item5.pordIDiscountI = item5.pordIDiscountI.GetValueOrDefault() + item4.pordIDiscountI.GetValueOrDefault();
													item5.pordIDiscount = item5.pordIDiscount.GetValueOrDefault() + item4.pordIDiscount.GetValueOrDefault();
													item5.pordITax = item5.pordITax.GetValueOrDefault() + item4.pordITax.GetValueOrDefault();
													item5.pordITaxIndex = item5.pordITaxIndex.GetValueOrDefault();
													item5.pordIRound = item5.pordIRound.GetValueOrDefault() + item4.pordIRound.GetValueOrDefault();
													item5.pordIRoundPlus = item5.pordIRoundPlus.GetValueOrDefault() + item4.pordIRoundPlus.GetValueOrDefault();
													item5.pordIPriceSum = item5.pordIPriceSum.GetValueOrDefault() + item4.pordIPriceSum.GetValueOrDefault();
													item5.pordIDiscountISum = item5.pordIDiscountISum.GetValueOrDefault() + item4.pordIDiscountISum.GetValueOrDefault();
													item5.pordIDiscountSum = item5.pordIDiscountSum.GetValueOrDefault() + item4.pordIDiscountSum.GetValueOrDefault();
													item5.pordITaxSum = item5.pordITaxSum.GetValueOrDefault() + item4.pordITaxSum.GetValueOrDefault();
													item5.pordIPriceSumWithoutDiscount = item5.pordIPriceSumWithoutDiscount.GetValueOrDefault() + item4.pordIPriceSumWithoutDiscount.GetValueOrDefault();
													item5.pordIPrice = item5.pordIPriceSumWithoutDiscount;
												}
											}
										}
										else
										{
											item4.TspPrdIndentify = item4.TspSGIndentify;
											item4.TspPrdName = item4.TspSGName;
											item4.PrdName = item4.TspSGName;
											list3.Add(item4);
										}
									}
									else
									{
										item4.TspPrdIndentify = item4.TspSGIndentify;
										item4.TspPrdName = item4.TspSGName;
										item4.PrdName = item4.TspSGName;
										list3.Add(item4);
									}
								}
								else
								{
									list3.Add(item4);
								}
							}
							break;
						}
						if (list3 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list3))
						{
							preOrderDetailsViewModel.PreOrderItems = list3;
						}
					}
					preOrderDetailsViewModel.PreOrderPayments = Enumerable.ToList<WSspSelectPreOrderPayments_Result>((IEnumerable<WSspSelectPreOrderPayments_Result>)_db.WSspSelectPreOrderPayments(pordId, lCID, result));
					if (preOrderDetailsViewModel.PreOrderPayments != null && Enumerable.Any<WSspSelectPreOrderPayments_Result>((IEnumerable<WSspSelectPreOrderPayments_Result>)preOrderDetailsViewModel.PreOrderPayments))
					{
						foreach (WSspSelectPreOrderPayments_Result preOrderPayment in preOrderDetailsViewModel.PreOrderPayments)
						{
							preOrderPayment.ImportDate = (preOrderPayment.ImportDateTime.HasValue ? preOrderPayment.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
							preOrderPayment.pordpayDocDate = (preOrderPayment.pordpayDocDateTime.HasValue ? preOrderPayment.pordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
						}
					}
					if (pordId != 0)
					{
						PrintLog.InsertPrintLog(pordId, 1, 2, valueOrDefault);
					}
					preOrderDetailsViewModel.AllPayRemain = CRMIdeal.Classes.Helper.Company.GetCompanyAllPayRemain(valueOrDefault);
					if (preOrderDetailsViewModel.AllPayRemain.GetValueOrDefault() == -1.11m)
					{
						preOrderDetailsViewModel.AllPayRemain = default(decimal);
					}
				}
			}
			else
			{
				preOrderDetailsViewModel.IsFind = false;
				preOrderDetailsViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			preOrderDetailsViewModel.IsFind = false;
			preOrderDetailsViewModel.Message = Messages.FOMsgErrorDoneOperation;
		}
		preOrderDetailsViewModel.PrintFormatFileName = ReturnPrintFormatFileNameById(preOrderDetailsViewModel.PreOrder.pordPrintFormatId);
		JsonResult jsonResult = Json(preOrderDetailsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult ShowError(int typeId = 0, string message = "")
	{
		base.ViewBag.TypeId = typeId;
		base.ViewBag.Message = message;
		return View();
	}

	public string ReturnPrintFormatFileNameById(int? pFormatId = 0)
	{
		string text = "";
		try
		{
			WSspReturnPrintFormatFileNameById_Result wSspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)Enumerable.ToList<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)_db.WSspReturnPrintFormatFileNameById(pFormatId)));
			if (wSspReturnPrintFormatFileNameById_Result != null)
			{
				text = wSspReturnPrintFormatFileNameById_Result.FileNameWeb;
				if (!string.IsNullOrWhiteSpace(text) && !text.ToLower().EndsWith(".mrt"))
				{
					text += ".mrt";
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return text;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
