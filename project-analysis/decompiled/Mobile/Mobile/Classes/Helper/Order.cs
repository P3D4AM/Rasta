using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.DataType;
using Mobile.Models;
using Mobile.Models.ViewModel.VerificationWorkFlow;
using Newtonsoft.Json;

namespace Mobile.Classes.Helper;

public class Order
{
	public static bool ReferOrderToWrhsUser(int orderId, int? cId = null)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
			if (orderId != 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				List<CrmInternalMessage_Lang> list2 = new List<CrmInternalMessage_Lang>();
				foreach (MobspSelectLanguages_Result item in list)
				{
					CrmInternalMessage_Lang crmInternalMessage_Lang = new CrmInternalMessage_Lang();
					crmInternalMessage_Lang.LanguageID = item.LanguageID;
					crmInternalMessage_Lang.msgSubject = MyResource.GetResourceString("ordVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					crmInternalMessage_Lang.msgBody = MyResource.GetResourceString("ordVerifiedRequest", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + "-" + MyResource.GetResourceString("ordVerifiedRequestOrdAtach", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + "\n" + MyResource.GetResourceString("ordVerifiedRequestOrdNumber", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#ordNumber#]\n" + MyResource.GetResourceString("ordVerifiedRequestOrdDate", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#ordDate#]\n" + MyResource.GetResourceString("ordVerifiedRequestCompanayName", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#CmpName#]\n" + MyResource.GetResourceString("ordVerifiedRequestReferUserName", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#ReferUser#]\n" + MyResource.GetResourceString("ordVerifiedRequestFirstRegisterUserName", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#FirstRegisterUser#]\n" + MyResource.GetResourceString("ordVerifiedRequestOrdVerified", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#Verifier#]\n" + MyResource.GetResourceString("ordVerifiedRequestDbClickOnOtherInfo", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + "\n";
					list2.Add(crmInternalMessage_Lang);
				}
				string intMsgBody = "";
				string intMsgSubject = "";
				string intMsgLang = "";
				if (list2 != null && Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2))
				{
					intMsgSubject = (Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)).msgSubject : "");
					intMsgBody = (Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)).msgBody : "");
					intMsgLang = JsonConvert.SerializeObject(Enumerable.ToList<CrmInternalMessage_Lang>(Enumerable.Where<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID != defLangID))));
				}
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.MobspReferOrderToWrhsUser(orderId, intMsgBody, intMsgSubject, intMsgLang, userId, value3, value2, value, registerDatePersian, appType, defLangID, cId));
				int result2 = 0;
				if (mct_Result != null)
				{
					int.TryParse(mct_Result.Result.ToString(), out result2);
				}
				result = result2 == 1;
				PushNotif.NewIntMsgNotify(withthread: true, cId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static void AddProjectProductHistoryFromOrder(int orderId, bool addPrdValidity, string addPrdValidityPrjTitle, ref string msg)
	{
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (orderId != 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.MobspAddProjectProductHistoryFromOrder(orderId, addPrdValidity, addPrdValidityPrjTitle, userId, value3, value2, value, registerDatePersian, appType, lCID, result));
				int result2 = 0;
				if (mct_Result != null)
				{
					int.TryParse(mct_Result.Result.ToString(), out result2);
				}
				switch (result2)
				{
				case -100:
				case 0:
					msg = Messages.msgErrorRunFunction;
					break;
				case -1:
					msg = "msgErrorNoSavePrjPrdHisByOrdNotVerified".OrderMessages();
					break;
				case -2:
					msg = "msgErrorNoSavePrjPrdHisNoSelectedPrj".OrderMessages();
					break;
				case -3:
					msg = "msgErrorNoSavePrjPrdHisNoDefaultPrjTitles".OrderMessages();
					break;
				case -4:
					msg = "msgErrorNoSavePrjPrdHisNoPrj".OrderMessages();
					break;
				case 1:
					msg = "";
					break;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
	}

	public static bool IsFixed(int ordId, int langId, int userId, int? centerId = null)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			MobspSelectOrderWithID_Result mobspSelectOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(ordId, userId, langId, result2, centerId));
			if (mobspSelectOrderWithID_Result != null && mobspSelectOrderWithID_Result.ordIsFixed.HasValue && mobspSelectOrderWithID_Result.ordIsFixed.GetValueOrDefault())
			{
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static bool PaymentMoneyBag(int payId, int oldPayTypeId, int langId, int? cId)
	{
		bool result = false;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			MobspSelectOrderPaymentsWithId_Result mobspSelectOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<MobspSelectOrderPaymentsWithId_Result>((IEnumerable<MobspSelectOrderPaymentsWithId_Result>)cRMSpEntities.MobspSelectOrderPaymentsWithId(payId, langId, defLangId));
			if (mobspSelectOrderPaymentsWithId_Result != null)
			{
				int result2 = 0;
				int.TryParse(mobspSelectOrderPaymentsWithId_Result.ordpayCompanyMoneyBagId.ToString(), out result2);
				if (result2 == 0 && mobspSelectOrderPaymentsWithId_Result.ordpayTypeId == -10)
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					List<MobspSelectOrderPaymentTypesInLangsById_Result> list3 = Enumerable.ToList<MobspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<MobspSelectOrderPaymentTypesInLangsById_Result>)cRMSpEntities.MobspSelectOrderPaymentTypesInLangsById(mobspSelectOrderPaymentsWithId_Result.ordpayTypeId));
					MobspSelectOrderWithID_Result mobspSelectOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(mobspSelectOrderPaymentsWithId_Result.ordpayOrderId, userId, langId, defLangId, cId));
					foreach (MobspSelectLanguages_Result lang2 in list)
					{
						string text = "";
						if (list3 != null && Enumerable.Any<MobspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<MobspSelectOrderPaymentTypesInLangsById_Result>)list3))
						{
							MobspSelectOrderPaymentTypesInLangsById_Result mobspSelectOrderPaymentTypesInLangsById_Result = Enumerable.FirstOrDefault<MobspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<MobspSelectOrderPaymentTypesInLangsById_Result>)list3, (Func<MobspSelectOrderPaymentTypesInLangsById_Result, bool>)((MobspSelectOrderPaymentTypesInLangsById_Result m) => m.LanguageID == lang2.LanguageID));
							if (mobspSelectOrderPaymentTypesInLangsById_Result != null)
							{
								text = mobspSelectOrderPaymentTypesInLangsById_Result.ordpayType ?? "";
							}
						}
						string text2 = "";
						string text3 = "";
						if (mobspSelectOrderWithID_Result != null)
						{
							text2 = mobspSelectOrderWithID_Result.ordNumber.ToString();
							if (mobspSelectOrderWithID_Result.ordDateTime.HasValue)
							{
								text3 = ((lang2.LanguageID != 1065) ? ((lang2.LanguageID != 1025) ? mobspSelectOrderWithID_Result.ordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : mobspSelectOrderWithID_Result.ordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"))) : mobspSelectOrderWithID_Result.ordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture()));
							}
						}
						CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
						commonMultiLanguageViewModel.LanguageId = lang2.LanguageID;
						commonMultiLanguageViewModel.Value = text + " - " + MyResource.GetResourceString("lblOrd", lang2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " - " + text2 + " - " + text3;
						CommonMultiLanguageViewModel item = commonMultiLanguageViewModel;
						list2.Add(item);
					}
					string cmpMnBgDesc = "";
					string cmpMnBgDesc_Lang = "";
					if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
					{
						cmpMnBgDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
						{
							cmpMnBgDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId))));
						}
					}
					ObjectParameter objectParameter = new ObjectParameter("insertedCompanyMoneyBagId", 0);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspInsertCompanyMoneyBag(mobspSelectOrderWithID_Result.ordCompanyId, 30, mobspSelectOrderPaymentsWithId_Result.ordpayOrderId, mobspSelectOrderPaymentsWithId_Result.ImportDateTime, mobspSelectOrderPaymentsWithId_Result.ImportDate, mobspSelectOrderPaymentsWithId_Result.ordpayAmount * -1m, cmpMnBgDesc, cmpMnBgDesc_Lang, null, userId, value3, value2, value, registerDatePersian, appType, defLangId, objectParameter, cId));
					result2 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result2);
					}
					if (result2 > 0)
					{
						cRMSpEntities.MobspUpdateCompanyMoneyBagFromPayment(result2, 2, mobspSelectOrderPaymentsWithId_Result.OrderPaymentId);
					}
				}
				else if (result2 != 0 && oldPayTypeId == -10 && oldPayTypeId != mobspSelectOrderPaymentsWithId_Result.ordpayTypeId)
				{
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspDeleteCompanyMoneyBagFromPayment(result2, 2, mobspSelectOrderPaymentsWithId_Result.OrderPaymentId));
				}
				else if (result2 != 0 && mobspSelectOrderPaymentsWithId_Result.ordpayTypeId == -10)
				{
					DateTime now2 = DateTime.Now;
					DateTime value4 = now2;
					string registerDatePersian2 = now2.ToString("yyyyMMdd", new PersianCulture());
					short value5 = short.Parse(now2.ToString("MM", new PersianCulture()));
					string appType2 = Configuration.AppType;
					short value6 = short.Parse(Financial.Get().Id.ToString());
					int userId2 = UserLogin.CurrentUser.UserId;
					List<MobspSelectLanguages_Result> list4 = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
					List<MobspSelectOrderPaymentTypesInLangsById_Result> list6 = Enumerable.ToList<MobspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<MobspSelectOrderPaymentTypesInLangsById_Result>)cRMSpEntities.MobspSelectOrderPaymentTypesInLangsById(mobspSelectOrderPaymentsWithId_Result.ordpayTypeId));
					MobspSelectOrderWithID_Result mobspSelectOrderWithID_Result2 = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(mobspSelectOrderPaymentsWithId_Result.ordpayOrderId, userId2, langId, defLangId, cId));
					foreach (MobspSelectLanguages_Result lang in list4)
					{
						string text4 = "";
						if (list6 != null && Enumerable.Any<MobspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<MobspSelectOrderPaymentTypesInLangsById_Result>)list6))
						{
							MobspSelectOrderPaymentTypesInLangsById_Result mobspSelectOrderPaymentTypesInLangsById_Result2 = Enumerable.FirstOrDefault<MobspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<MobspSelectOrderPaymentTypesInLangsById_Result>)list6, (Func<MobspSelectOrderPaymentTypesInLangsById_Result, bool>)((MobspSelectOrderPaymentTypesInLangsById_Result m) => m.LanguageID == lang.LanguageID));
							if (mobspSelectOrderPaymentTypesInLangsById_Result2 != null)
							{
								text4 = mobspSelectOrderPaymentTypesInLangsById_Result2.ordpayType ?? "";
							}
						}
						string text5 = "";
						string text6 = "";
						if (mobspSelectOrderWithID_Result2 != null)
						{
							text5 = mobspSelectOrderWithID_Result2.ordNumber.ToString();
							if (mobspSelectOrderWithID_Result2.ordDateTime.HasValue)
							{
								text6 = ((lang.LanguageID != 1065) ? ((lang.LanguageID != 1025) ? mobspSelectOrderWithID_Result2.ordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : mobspSelectOrderWithID_Result2.ordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"))) : mobspSelectOrderWithID_Result2.ordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture()));
							}
						}
						CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
						commonMultiLanguageViewModel.LanguageId = lang.LanguageID;
						commonMultiLanguageViewModel.Value = text4 + " - " + MyResource.GetResourceString("lblOrd", lang.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " - " + text5 + " - " + text6;
						CommonMultiLanguageViewModel item2 = commonMultiLanguageViewModel;
						list5.Add(item2);
					}
					string cmpMnBgDesc2 = "";
					string cmpMnBgDesc_Lang2 = "";
					if (list5 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5))
					{
						cmpMnBgDesc2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						if (list5 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5))
						{
							cmpMnBgDesc_Lang2 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId))));
						}
					}
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspUpdateCompanyMoneyBag(result2, mobspSelectOrderPaymentsWithId_Result.ImportDateTime, mobspSelectOrderPaymentsWithId_Result.ImportDate, mobspSelectOrderPaymentsWithId_Result.ordpayAmount * -1m, cmpMnBgDesc2, cmpMnBgDesc_Lang2, null, userId2, value5, value6, value4, registerDatePersian2, appType2, defLangId));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static bool CheckLastCompanyOrderHaveTax(int cmpId, ref bool haveOrd)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId != 0)
			{
				MobspCheckLastCompanyOrderHaveTax_Result mobspCheckLastCompanyOrderHaveTax_Result = Enumerable.FirstOrDefault<MobspCheckLastCompanyOrderHaveTax_Result>((IEnumerable<MobspCheckLastCompanyOrderHaveTax_Result>)cRMSpEntities.MobspCheckLastCompanyOrderHaveTax(cmpId));
				decimal result3 = default(decimal);
				decimal result4 = default(decimal);
				if (mobspCheckLastCompanyOrderHaveTax_Result != null)
				{
					decimal.TryParse(mobspCheckLastCompanyOrderHaveTax_Result.ordTax.ToString(), out result3);
					decimal.TryParse(mobspCheckLastCompanyOrderHaveTax_Result.ordItemsTax.ToString(), out result4);
					haveOrd = true;
				}
				else
				{
					haveOrd = false;
				}
				if (result3 != 0m || result4 != 0m)
				{
					result = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static bool UpdateOrderLinkAccControl(int ordId)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			if (ordId != 0)
			{
				cRMSpEntities.MobspUpdateOrderLinkAccControl(ordId);
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static ServiceResult<string> GetOrdFOLink(int ordId = 0, int? cId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string data = "";
		string text = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new ServiceResult<string>();
		try
		{
			if (ordId != 0)
			{
				if (!UserLogin.IsUserAccess("frmOrder", "actGetOrdFOLink", UserLogin.CurrentUser, cId))
				{
					text = Messages.ErrorNotAccess;
				}
				else
				{
					MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
					if (mobspSelectCrmsysSetting_Result != null)
					{
						string text2 = mobspSelectCrmsysSetting_Result.FOUrl ?? "";
						text2 = text2.Trim();
						if (!string.IsNullOrWhiteSpace(text2))
						{
							if (!text2.StartsWith("http"))
							{
								text2 = "http://" + text2;
							}
							if (text2.EndsWith("/"))
							{
								text2 = text2.Substring(0, text2.Length - 1);
							}
							string text3 = CodeDecode.CoddingUTF8(ordId.ToString());
							text2 = text2 + "?" + "Ord".ToLower() + "=" + text3;
							data = text2;
							text = Messages.msgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							text = Messages.errorInReadingSetting;
						}
					}
					else
					{
						text = Messages.errorInReadingSetting;
					}
				}
			}
			else
			{
				text = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblPOrd);
				data = null;
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
			data = "";
			status = ServiceResultStatus.Error;
		}
		return new ServiceResult<string>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	public static List<SelectListItem> GetOrdExternalLinks(int ordId = 0, int? cId = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		list.Add(new SelectListItem());
		list.Add(new SelectListItem
		{
			Text = string.Format(Labels.lblFolinkWithLogin, Labels.lblOrd)
		});
		list.Add(new SelectListItem
		{
			Text = string.Format(Labels.lblFolinkWithoutLogin, Labels.lblOrd)
		});
		list.Add(new SelectListItem
		{
			Text = string.Format(Labels.lbllinkWithoutLogin, Labels.lblOrd)
		});
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (ordId != 0)
			{
				MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
				string text = CodeDecode.CoddingUTF8(ordId.ToString());
				if (mobspSelectCrmsysSetting_Result != null)
				{
					if (!UserLogin.IsUserAccess("frmOrder", "actGetOrdFOLink", UserLogin.CurrentUser, cId))
					{
						list[0].Value = Messages.ErrorNotAccess;
					}
					else
					{
						string text2 = (mobspSelectCrmsysSetting_Result.FOUrl ?? "").Trim();
						if (!string.IsNullOrWhiteSpace(text2))
						{
							if (!text2.StartsWith("http"))
							{
								text2 = "http://" + text2;
							}
							text2 = text2.TrimEnd(new char[1] { '/' });
							list[1].Value = text2 + "?" + "Ord".ToLower() + "=" + text;
							list[2].Value = list[1].Value + "&nl=1";
						}
					}
					string text3 = (mobspSelectCrmsysSetting_Result.CrmIPStatic ?? "").TrimEnd(new char[1] { '/' });
					if (!string.IsNullOrWhiteSpace(text3))
					{
						list[3].Value = text3 + "/OnlinePayment/Home/ShowOprDetails?t=" + CodeDecode.CoddingUTF8("30|" + ordId);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			list[0].Value = Messages.msgErrorRunFunction;
			list = null;
		}
		return list;
	}

	public static List<SelectListItem> GetOrdFoShortLinks(int ordId = 0)
	{
		DateTime now = DateTime.Now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short.Parse(now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		short.Parse(Financial.Get().Id.ToString());
		int userId = UserLogin.CurrentUser.UserId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> ordExternalLinks = GetOrdExternalLinks(ordId);
		List<SelectListItem> list = new List<SelectListItem>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			for (int i = 0; i < ordExternalLinks.Count; i++)
			{
				if (i == 0)
				{
					list.Add(new SelectListItem
					{
						Value = ordExternalLinks[i].Value,
						Text = ordExternalLinks[i].Text
					});
				}
				else if (!string.IsNullOrWhiteSpace(ordExternalLinks[i].Value))
				{
					Uri uri = new Uri(ordExternalLinks[i].Value);
					string text = uri.Scheme + "://" + uri.Authority;
					ObjectParameter objectParameter = new ObjectParameter("ShortKey", typeof(string));
					cRMSpEntities.MobspInsertShortLink(ordExternalLinks[i].Value, 30, ordId, null, null, null, null, null, null, userId, now, registerDatePersian, appType, lCID, text, objectParameter);
					string text2 = objectParameter.Value?.ToString();
					list.Add(new SelectListItem
					{
						Value = text + "/s/" + text2 + " ",
						Text = ordExternalLinks[i].Text
					});
				}
				else
				{
					list.Add(new SelectListItem
					{
						Value = (ordExternalLinks[i].Value ?? ""),
						Text = (ordExternalLinks[i].Text ?? "")
					});
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return list;
	}

	public static bool IsEditAfterFix(string editAfterFixInfoJs = "", int ordId = 0, int? mode = null, int userId = 0, int? ln = null)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			int result2 = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result2);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			mode = mode.GetValueOrDefault(1);
			if (string.IsNullOrWhiteSpace(editAfterFixInfoJs) && ordId != 0)
			{
				MobspSelectOrderById_Result mobspSelectOrderById_Result = Enumerable.FirstOrDefault<MobspSelectOrderById_Result>((IEnumerable<MobspSelectOrderById_Result>)cRMSpEntities.MobspSelectOrderById(ordId, result2, result3));
				if (mobspSelectOrderById_Result != null)
				{
					editAfterFixInfoJs = mobspSelectOrderById_Result.ordEditAfterFixInfoJs;
				}
			}
			List<EditAfterFixInfoViewModel> list = new List<EditAfterFixInfoViewModel>();
			if (!string.IsNullOrWhiteSpace((editAfterFixInfoJs ?? "").Replace("[]", "")))
			{
				bool flag = false;
				list = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(editAfterFixInfoJs);
				if (list != null)
				{
					EditAfterFixInfoViewModel editAfterFixInfoViewModel = Enumerable.FirstOrDefault<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => x.eafModeId == mode && x.eafUserId == userId && !x.eafIsDone.GetValueOrDefault()));
					if (editAfterFixInfoViewModel != null)
					{
						if (editAfterFixInfoViewModel.eafEndDate.HasValue)
						{
							if (editAfterFixInfoViewModel.eafEndDate >= DateTime.Now)
							{
								flag = true;
							}
						}
						else
						{
							flag = true;
						}
					}
					if (flag)
					{
						result = true;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string GetOrdFOLinkI(int ordId = 0)
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
			if (ordId != 0)
			{
				MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
				if (mobspSelectCrmsysSetting_Result != null)
				{
					string text = mobspSelectCrmsysSetting_Result.FOUrl ?? "";
					text = text.Trim();
					if (!string.IsNullOrWhiteSpace(text))
					{
						if (!text.StartsWith("http"))
						{
							text = "http://" + text;
						}
						if (text.EndsWith("/"))
						{
							text = text.Substring(0, text.Length - 1);
						}
						string text2 = CodeDecode.CoddingUTF8(ordId.ToString());
						text = text + "?" + "Ord".ToLower() + "=" + text2;
						result2 = text;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public static bool SendSmsFoSettingOrdAfterVerify(int ordId, int? cId = null)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (ordId != 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = "mob";
				short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				string ordFOLinkI = GetOrdFOLinkI(ordId);
				ordFOLinkI = ordFOLinkI ?? "";
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				cRMSpEntities.MobspSendSmsFoSettingOrdAfterVerify(ordId, ordFOLinkI, userId, value3, value2, value, registerDatePersian, appType, lCID, result2, objectParameter, cId);
				if (objectParameter != null && objectParameter.Value != null)
				{
					int result3 = 0;
					int.TryParse(objectParameter.Value.ToString(), out result3);
					if (result3 == 1)
					{
						result = true;
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
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static MobspSelectOrderWithID_Result GetOrdeerWithId(int ordId, int userId, int? ln = null, int? cId = null)
	{
		CRMEntities cRMEntities = null;
		MobspSelectOrderWithID_Result result = null;
		try
		{
			int result2 = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result2);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			cRMEntities = new CRMEntities();
			result = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(ordId, userId, result2, result3, cId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}

	public static bool CalcOrderCancleed(int ordId)
	{
		bool result = false;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
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
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int? centerId = null;
			int? userId = null;
			UserLoginInfo currentUser = UserLogin.CurrentUser;
			if (currentUser != null)
			{
				centerId = currentUser.UserLastCId;
				userId = currentUser.UserId;
			}
			int result3 = 0;
			MobspSelectOrderById_Result mobspSelectOrderById_Result = Enumerable.FirstOrDefault<MobspSelectOrderById_Result>((IEnumerable<MobspSelectOrderById_Result>)cRMSpEntities.MobspSelectOrderById(ordId, lCID, result2));
			if (mobspSelectOrderById_Result != null)
			{
				int.TryParse(mobspSelectOrderById_Result.ordStatusId.ToString(), out result3);
			}
			if (result3 == 4)
			{
				ObjectParameter objectParameter = new ObjectParameter("result", typeof(int));
				cRMSpEntities.MobScorespInsertAndCalcOrderCancelledScores(ordId, value, true, userId, value3, value2, value, registerDatePersian, appType, lCID, result2, centerId, objectParameter);
				if (objectParameter != null)
				{
					int result4 = 0;
					int.TryParse(objectParameter.Value.ToString(), out result4);
					if (result4 > 0)
					{
						result = true;
					}
				}
			}
			else
			{
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string CheckBeforeVerification(int ordId, int userId, int? cId = null, int? ln = null)
	{
		string result = "";
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			int result2 = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result2);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			BaseInfo baseInfo = new BaseInfo();
			int num = ((result2 > 0) ? result2 : result3);
			baseInfo.SetCulture(num);
			UserLoginInfo userLoginInfo = UserLogin.User(userId);
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			MobspSelectOrderById_Result mobspSelectOrderById_Result = Enumerable.FirstOrDefault<MobspSelectOrderById_Result>((IEnumerable<MobspSelectOrderById_Result>)cRMSpEntities.MobspSelectOrderById(ordId, num, result3));
			decimal num2 = default(decimal);
			MobspReturnRollDiscountLimitation_Result mobspReturnRollDiscountLimitation_Result = Enumerable.FirstOrDefault<MobspReturnRollDiscountLimitation_Result>((IEnumerable<MobspReturnRollDiscountLimitation_Result>)Enumerable.ToList<MobspReturnRollDiscountLimitation_Result>((IEnumerable<MobspReturnRollDiscountLimitation_Result>)cRMSpEntities.MobspReturnRollDiscountLimitation(userLoginInfo.RollId)));
			if (mobspReturnRollDiscountLimitation_Result == null)
			{
				result = Messages.ErrorNotFoundSetting;
				return result;
			}
			if (mobspReturnRollDiscountLimitation_Result.LimitOrderDiscountActive.HasValue && mobspReturnRollDiscountLimitation_Result.LimitOrderDiscountActive.GetValueOrDefault())
			{
				num2 = mobspReturnRollDiscountLimitation_Result.LimitOrderDiscountPercent.GetValueOrDefault();
			}
			MobfnReturnOrderSumFooter_Result mobfnReturnOrderSumFooter_Result;
			decimal obj;
			if (num2 > 0m)
			{
				mobfnReturnOrderSumFooter_Result = Enumerable.FirstOrDefault<MobfnReturnOrderSumFooter_Result>((IEnumerable<MobfnReturnOrderSumFooter_Result>)Enumerable.ToList<MobfnReturnOrderSumFooter_Result>((IEnumerable<MobfnReturnOrderSumFooter_Result>)cRMEntities.MobfnReturnOrderSumFooter(ordId)));
				if (mobfnReturnOrderSumFooter_Result != null)
				{
					if (mobfnReturnOrderSumFooter_Result.TotalPriceSumWithoutDiscount.HasValue)
					{
						decimal? totalPriceSumWithoutDiscount = mobfnReturnOrderSumFooter_Result.TotalPriceSumWithoutDiscount;
						if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
						{
							obj = Convert.ToDecimal(mobfnReturnOrderSumFooter_Result.TotalDiscountSum * (decimal?)100) / Convert.ToDecimal(mobfnReturnOrderSumFooter_Result.TotalPriceSumWithoutDiscount);
							goto IL_01dc;
						}
					}
					obj = 0m;
					goto IL_01dc;
				}
			}
			goto end_IL_000a;
			IL_03bd:
			decimal obj2;
			decimal num3 = (decimal)obj2;
			if (num3 > num2)
			{
				result = "MaxDiscountPercentOrderInActiveOrder".OrderMessages() + " " + num2;
				return result;
			}
			goto end_IL_000a;
			IL_01dc:
			num3 = obj;
			if (num3 != 0m)
			{
				List<MobspSelectOrderItemsByNotInSum_Result> list = Enumerable.ToList<MobspSelectOrderItemsByNotInSum_Result>((IEnumerable<MobspSelectOrderItemsByNotInSum_Result>)cRMSpEntities.MobspSelectOrderItemsByNotInSum(ordId, false, num, result3));
				if (list != null && Enumerable.Any<MobspSelectOrderItemsByNotInSum_Result>((IEnumerable<MobspSelectOrderItemsByNotInSum_Result>)list))
				{
					decimal num4 = default(decimal);
					int num5 = 0;
					foreach (MobspSelectOrderItemsByNotInSum_Result item in list)
					{
						if (item.ordIDiscountPercent.GetValueOrDefault() != 0m)
						{
							num4 += item.ordIDiscountPercent.GetValueOrDefault();
							num5++;
						}
					}
					if (num4 > 0m && num5 > 0)
					{
						num3 = num4 / (decimal)num5;
					}
				}
			}
			if (mobfnReturnOrderSumFooter_Result.SumPriceAmount.HasValue)
			{
				if (num3 > num2)
				{
					result = Messages.MaxDiscountPercentInActiveOrder + " " + num2;
					return result;
				}
				if (mobfnReturnOrderSumFooter_Result.SumPriceAmount.GetValueOrDefault() == 0m && mobspSelectOrderById_Result.ordDiscount.GetValueOrDefault() != 0m)
				{
					result = Messages.msgErrorDivisionByZero;
					return result;
				}
				if (mobfnReturnOrderSumFooter_Result.SumPriceAmount.HasValue)
				{
					decimal? totalPriceSumWithoutDiscount = mobfnReturnOrderSumFooter_Result.SumPriceAmount;
					if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
					{
						obj2 = Convert.ToDecimal(mobspSelectOrderById_Result.ordDiscount.GetValueOrDefault() * 100m) / Convert.ToDecimal(mobfnReturnOrderSumFooter_Result.SumPriceAmount);
						goto IL_03bd;
					}
				}
				obj2 = 0m;
				goto IL_03bd;
			}
			end_IL_000a:;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.MobMsgErrorDoneOperation;
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return result;
	}
}
