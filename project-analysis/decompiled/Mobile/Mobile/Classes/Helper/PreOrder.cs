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
using Mobile.Cache.User;
using Mobile.DataType;
using Mobile.Models;
using Mobile.Models.ViewModel.VerificationWorkFlow;
using Newtonsoft.Json;

namespace Mobile.Classes.Helper;

public class PreOrder
{
	public static bool IsFixed(int pordId, int langId, int userId, int? cId = null)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, userId, langId, result2, cId));
			if (mobspSelectPreOrderWithID_Result != null && mobspSelectPreOrderWithID_Result.pordIsFixed.HasValue && mobspSelectPreOrderWithID_Result.pordIsFixed.GetValueOrDefault())
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
			MobspSelectPreOrderPaymentsWithId_Result mobspSelectPreOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderPaymentsWithId_Result>((IEnumerable<MobspSelectPreOrderPaymentsWithId_Result>)cRMSpEntities.MobspSelectPreOrderPaymentsWithId(payId, langId, defLangId));
			if (mobspSelectPreOrderPaymentsWithId_Result != null)
			{
				int result2 = 0;
				int.TryParse(mobspSelectPreOrderPaymentsWithId_Result.pordpayCompanyMoneyBagId.ToString(), out result2);
				if (result2 == 0 && mobspSelectPreOrderPaymentsWithId_Result.pordpayTypeId == -10)
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
					List<MobspSelectOrderPaymentTypesInLangsById_Result> list3 = Enumerable.ToList<MobspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<MobspSelectOrderPaymentTypesInLangsById_Result>)cRMSpEntities.MobspSelectOrderPaymentTypesInLangsById(mobspSelectPreOrderPaymentsWithId_Result.pordpayTypeId));
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(mobspSelectPreOrderPaymentsWithId_Result.pordpayPreOrderId, userId, langId, defLangId, cId));
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
						if (mobspSelectPreOrderWithID_Result != null)
						{
							text2 = mobspSelectPreOrderWithID_Result.pordNumber.ToString();
							if (mobspSelectPreOrderWithID_Result.pordDateTime.HasValue)
							{
								text3 = ((lang2.LanguageID != 1065) ? ((lang2.LanguageID != 1025) ? mobspSelectPreOrderWithID_Result.pordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : mobspSelectPreOrderWithID_Result.pordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"))) : mobspSelectPreOrderWithID_Result.pordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture()));
							}
						}
						CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
						commonMultiLanguageViewModel.LanguageId = lang2.LanguageID;
						commonMultiLanguageViewModel.Value = text + " - " + MyResource.GetResourceString("lblPOrd", lang2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " - " + text2 + " - " + text3;
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
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspInsertCompanyMoneyBag(mobspSelectPreOrderWithID_Result.pordCompanyId, 20, mobspSelectPreOrderPaymentsWithId_Result.pordpayPreOrderId, mobspSelectPreOrderPaymentsWithId_Result.ImportDateTime, mobspSelectPreOrderPaymentsWithId_Result.ImportDate, mobspSelectPreOrderPaymentsWithId_Result.pordpayAmount * -1m, cmpMnBgDesc, cmpMnBgDesc_Lang, null, userId, value3, value2, value, registerDatePersian, appType, defLangId, objectParameter, cId));
					result2 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result2);
					}
					if (result2 > 0)
					{
						cRMSpEntities.MobspUpdateCompanyMoneyBagFromPayment(result2, 1, mobspSelectPreOrderPaymentsWithId_Result.PreOrderPaymentId);
					}
				}
				else if (result2 != 0 && oldPayTypeId == -10 && oldPayTypeId != mobspSelectPreOrderPaymentsWithId_Result.pordpayTypeId)
				{
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspDeleteCompanyMoneyBagFromPayment(result2, 1, mobspSelectPreOrderPaymentsWithId_Result.PreOrderPaymentId));
				}
				else if (result2 != 0 && mobspSelectPreOrderPaymentsWithId_Result.pordpayTypeId == -10)
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
					List<MobspSelectOrderPaymentTypesInLangsById_Result> list6 = Enumerable.ToList<MobspSelectOrderPaymentTypesInLangsById_Result>((IEnumerable<MobspSelectOrderPaymentTypesInLangsById_Result>)cRMSpEntities.MobspSelectOrderPaymentTypesInLangsById(mobspSelectPreOrderPaymentsWithId_Result.pordpayTypeId));
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result2 = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(mobspSelectPreOrderPaymentsWithId_Result.pordpayPreOrderId, userId2, langId, defLangId, cId));
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
						if (mobspSelectPreOrderWithID_Result2 != null)
						{
							text5 = mobspSelectPreOrderWithID_Result2.pordNumber.ToString();
							if (mobspSelectPreOrderWithID_Result2.pordDateTime.HasValue)
							{
								text6 = ((lang.LanguageID != 1065) ? ((lang.LanguageID != 1025) ? mobspSelectPreOrderWithID_Result2.pordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : mobspSelectPreOrderWithID_Result2.pordDateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"))) : mobspSelectPreOrderWithID_Result2.pordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture()));
							}
						}
						CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
						commonMultiLanguageViewModel.LanguageId = lang.LanguageID;
						commonMultiLanguageViewModel.Value = text4 + " - " + MyResource.GetResourceString("lblPOrd", lang.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " - " + text5 + " - " + text6;
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
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspUpdateCompanyMoneyBag(result2, mobspSelectPreOrderPaymentsWithId_Result.ImportDateTime, mobspSelectPreOrderPaymentsWithId_Result.ImportDate, mobspSelectPreOrderPaymentsWithId_Result.pordpayAmount * -1m, cmpMnBgDesc2, cmpMnBgDesc_Lang2, null, userId2, value5, value6, value4, registerDatePersian2, appType2, defLangId));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static bool AddUserMoneyBagFormPord(int pordId, int? cId)
	{
		bool result = false;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			if (pordId != 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
				long result2 = 0L;
				int result3 = 0;
				MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, languageID: lCID, defaultLanguageID: defLangID, userId: userId, centerId: cId));
				if (mobspSelectPreOrderWithID_Result != null)
				{
					long.TryParse(mobspSelectPreOrderWithID_Result.pordNumber.ToString(), out result2);
					int.TryParse(mobspSelectPreOrderWithID_Result.pordReferUserId.ToString(), out result3);
				}
				string uMnBgDesc = "";
				string uMnBgDesc_Lang = "";
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				foreach (MobspSelectLanguages_Result item in list)
				{
					CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel.Value = MyResource.GetResourceString("lblPOrd", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " (" + result2 + ")";
					list2.Add(commonMultiLanguageViewModel);
				}
				if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
				{
					uMnBgDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					uMnBgDesc_Lang = "";
					if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
					{
						uMnBgDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangID))));
					}
				}
				string uMnBgDescForUsage = "";
				string uMnBgDescForUsage_Lang = "";
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				foreach (MobspSelectLanguages_Result item2 in list)
				{
					CommonMultiLanguageViewModel commonMultiLanguageViewModel2 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel2.LanguageId = item2.LanguageID;
					string arg = MyResource.GetResourceString("lblPOrd", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " (" + result2 + ")";
					commonMultiLanguageViewModel2.Value = string.Format(MyResource.GetResourceString("UMnBgDescINUsageOtherPartSys", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly), arg);
					list3.Add(commonMultiLanguageViewModel2);
				}
				if (list3 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
				{
					uMnBgDescForUsage = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					uMnBgDescForUsage_Lang = "";
					if (list3 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
					{
						uMnBgDescForUsage_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangID))));
					}
				}
				int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspAddUserMoneyBagFromPreOrderDiscounts(pordId, value, text, uMnBgDesc, uMnBgDesc_Lang, userId, value3, value2, value, text, appType, defLangID, uMnBgDescForUsage, uMnBgDescForUsage_Lang, cId));
				int result4 = 0;
				if (num.HasValue)
				{
					int.TryParse(num.ToString(), out result4);
				}
				result = result4 == 1;
				if (result3 != 0)
				{
					Info.Update(result3, true);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static bool CheckCheckPreOrderHaveTax(int pordId)
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
			if (pordId != 0)
			{
				MobspCheckPreOrderHaveTax_Result mobspCheckPreOrderHaveTax_Result = Enumerable.FirstOrDefault<MobspCheckPreOrderHaveTax_Result>((IEnumerable<MobspCheckPreOrderHaveTax_Result>)cRMSpEntities.MobspCheckPreOrderHaveTax(pordId));
				decimal result3 = default(decimal);
				decimal result4 = default(decimal);
				if (mobspCheckPreOrderHaveTax_Result != null)
				{
					decimal.TryParse(mobspCheckPreOrderHaveTax_Result.pordTax.ToString(), out result3);
					decimal.TryParse(mobspCheckPreOrderHaveTax_Result.pordItemsTax.ToString(), out result4);
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

	public static ServiceResult<string> GetPordFOLink(int ordId = 0, int? cId = null)
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
				if (!UserLogin.IsUserAccess("frmPreOrder", "actGetPordFOLink", UserLogin.CurrentUser, cId))
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
							text2 = text2 + "?" + "Pord".ToLower() + "=" + text3;
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

	public static List<SelectListItem> GetPordExternalLinks(int pordId = 0, int? cId = null)
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
			if (pordId != 0)
			{
				MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
				string text = CodeDecode.CoddingUTF8(pordId.ToString());
				if (mobspSelectCrmsysSetting_Result != null)
				{
					if (!UserLogin.IsUserAccess("frmPreOrder", "actGetPordFOLink", UserLogin.CurrentUser, cId))
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
							list[1].Value = text2 + "?" + "Pord".ToLower() + "=" + text;
							list[2].Value = list[1].Value + "&nl=1";
						}
					}
					string text3 = (mobspSelectCrmsysSetting_Result.CrmIPStatic ?? "").TrimEnd(new char[1] { '/' });
					if (!string.IsNullOrWhiteSpace(text3))
					{
						list[3].Value = text3 + "/OnlinePayment/Home/ShowOprDetails?t=" + CodeDecode.CoddingUTF8("20|" + pordId);
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

	public static List<SelectListItem> GetPordFoShortLinks(int pordId = 0, int? cId = null)
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
		List<SelectListItem> pordExternalLinks = GetPordExternalLinks(pordId);
		List<SelectListItem> list = new List<SelectListItem>();
		CRMEntities cRMEntities = new CRMEntities();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(pordId, userId, lCID, result, cId));
			for (int i = 0; i < pordExternalLinks.Count; i++)
			{
				if (i == 0)
				{
					list.Add(new SelectListItem
					{
						Value = pordExternalLinks[i].Value,
						Text = pordExternalLinks[i].Text
					});
					continue;
				}
				ObjectParameter objectParameter = new ObjectParameter("ShortKey", typeof(string));
				cRMSpEntities.MobspInsertShortLink(pordExternalLinks[i].Value, 20, pordId, null, null, null, null, mobspSelectPreOrderWithID_Result.pordExpireDateTime, null, userId, now, registerDatePersian, appType, lCID, "", objectParameter);
				string text = objectParameter.Value?.ToString();
				Uri uri = new Uri(pordExternalLinks[i].Value);
				string text2 = uri.Scheme + "://" + uri.Authority;
				list.Add(new SelectListItem
				{
					Value = text2 + "/s/" + text + " ",
					Text = pordExternalLinks[i].Text
				});
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
		return list;
	}

	public static bool IsEditAfterFix(string editAfterFixInfoJs = "", int preordId = 0, int? mode = null, int userId = 0, int? ln = null, int? cId = null)
	{
		bool result = false;
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			int result2 = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result2);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			mode = mode.GetValueOrDefault(1);
			if (string.IsNullOrWhiteSpace(editAfterFixInfoJs) && preordId != 0)
			{
				MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(preordId, userId, result2, result3, cId));
				if (mobspSelectPreOrderWithID_Result != null)
				{
					editAfterFixInfoJs = mobspSelectPreOrderWithID_Result.pordEditAfterFixInfoJs;
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
			cRMEntities?.Dispose();
		}
		return result;
	}

	public static string GetPordFOLinkI(int pordId = 0)
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
			if (pordId != 0)
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
						string text2 = CodeDecode.CoddingUTF8(pordId.ToString());
						text = text + "?" + "Pord".ToLower() + "=" + text2;
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

	public static bool SendSmsFoSettingPordAfterVerify(int pordId, int? cId = null)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (pordId != 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = "mob";
				short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				string pordFOLinkI = GetPordFOLinkI(pordId);
				pordFOLinkI = pordFOLinkI ?? "";
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				cRMSpEntities.MobspSendSmsFoSettingPordAfterVerify(pordId, pordFOLinkI, userId, value3, value2, value, registerDatePersian, appType, lCID, result2, objectParameter, cId);
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
			if (cRMEntities != null)
			{
				cRMSpEntities.Dispose();
			}
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string CheckBeforeVerification(int pordId, int userId, int? cId = null, int? ln = null)
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
			CRMEntities cRMEntities2 = cRMEntities;
			int? userId2 = userId;
			int? centerId = cId;
			MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities2.MobspSelectPreOrderWithID(pordId, userId2, num, result3, centerId));
			string arg;
			decimal num2;
			MobfnReturnPreOrderSumFooter_Result mobfnReturnPreOrderSumFooter_Result;
			decimal obj;
			if (mobspSelectPreOrderWithID_Result != null)
			{
				arg = string.Format(Labels.lblPordByNum, mobspSelectPreOrderWithID_Result.pordNumber.ToString());
				if (UserLogin.IsUserAccess("frmPreOrder", "actMustPrdGroupSame", UserLogin.CurrentUser))
				{
					List<MobspCheckPrdGroupSameInPreOrder_Result> list = Enumerable.ToList<MobspCheckPrdGroupSameInPreOrder_Result>((IEnumerable<MobspCheckPrdGroupSameInPreOrder_Result>)cRMEntities.MobspCheckPrdGroupSameInPreOrder(pordId, num, result3));
					if (list != null && Enumerable.Any<MobspCheckPrdGroupSameInPreOrder_Result>((IEnumerable<MobspCheckPrdGroupSameInPreOrder_Result>)list))
					{
						result = string.Format(Messages.msgErrorNotVerifiedPordNoPrdGroupSameByParam, arg);
						return result;
					}
				}
				num2 = default(decimal);
				MobspReturnRollDiscountLimitation_Result mobspReturnRollDiscountLimitation_Result = Enumerable.FirstOrDefault<MobspReturnRollDiscountLimitation_Result>((IEnumerable<MobspReturnRollDiscountLimitation_Result>)Enumerable.ToList<MobspReturnRollDiscountLimitation_Result>((IEnumerable<MobspReturnRollDiscountLimitation_Result>)cRMSpEntities.MobspReturnRollDiscountLimitation(userLoginInfo.RollId)));
				if (mobspReturnRollDiscountLimitation_Result != null)
				{
					if (mobspReturnRollDiscountLimitation_Result.LimitPreOrderDiscountActive.HasValue && mobspReturnRollDiscountLimitation_Result.LimitPreOrderDiscountActive.GetValueOrDefault())
					{
						num2 = mobspReturnRollDiscountLimitation_Result.LimitPreOrderDiscountPercent.GetValueOrDefault();
					}
					mobfnReturnPreOrderSumFooter_Result = Queryable.FirstOrDefault<MobfnReturnPreOrderSumFooter_Result>(cRMEntities.MobfnReturnPreOrderSumFooter(pordId));
					if (num2 > 0m && mobfnReturnPreOrderSumFooter_Result != null)
					{
						if (mobfnReturnPreOrderSumFooter_Result.TotalPriceSumWithoutDiscount.HasValue)
						{
							decimal? totalPriceSumWithoutDiscount = mobfnReturnPreOrderSumFooter_Result.TotalPriceSumWithoutDiscount;
							if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
							{
								obj = Convert.ToDecimal(mobfnReturnPreOrderSumFooter_Result.TotalDiscountSum * (decimal?)100) / Convert.ToDecimal(mobfnReturnPreOrderSumFooter_Result.TotalPriceSumWithoutDiscount);
								goto IL_026c;
							}
						}
						obj = 0m;
						goto IL_026c;
					}
					goto IL_0486;
				}
				result = Messages.ErrorNotFoundSetting;
				return result;
			}
			goto end_IL_000a;
			IL_0486:
			if (mobfnReturnPreOrderSumFooter_Result != null)
			{
				decimal result4 = default(decimal);
				decimal.TryParse(mobfnReturnPreOrderSumFooter_Result.TotalDiscountSum.ToString(), out result4);
				decimal valueOrDefault = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)cRMSpEntities.MobspReturnPreOrderDiscountSumDisAmount(pordId)).GetValueOrDefault();
				if (valueOrDefault > 0m)
				{
					if (result4 == 0m)
					{
						result = string.Format(Messages.msgErrorNotVerifyBecauseNotAddDisStToItemDis, arg);
						return result;
					}
					if (result4 != valueOrDefault)
					{
						result = string.Format(Messages.msgErrorNotVerifyBecauseDifferentDisStWithItemDis, arg);
						return result;
					}
				}
			}
			goto end_IL_000a;
			IL_045a:
			decimal obj2;
			decimal num3 = (decimal)obj2;
			if (num3 > num2)
			{
				result = Messages.MaxDiscountPercentPreOrderInActivePreOrder + " " + num2;
				return result;
			}
			goto IL_0486;
			IL_026c:
			num3 = obj;
			if (num3 != 0m)
			{
				List<MobspSelectPreOrderItemsByNotInSum_Result> list2 = Enumerable.ToList<MobspSelectPreOrderItemsByNotInSum_Result>((IEnumerable<MobspSelectPreOrderItemsByNotInSum_Result>)cRMSpEntities.MobspSelectPreOrderItemsByNotInSum(pordId, false, num, result3));
				if (list2 != null && Enumerable.Any<MobspSelectPreOrderItemsByNotInSum_Result>((IEnumerable<MobspSelectPreOrderItemsByNotInSum_Result>)list2))
				{
					decimal num4 = default(decimal);
					int num5 = 0;
					foreach (MobspSelectPreOrderItemsByNotInSum_Result item in list2)
					{
						if (item.pordIDiscountPercent.GetValueOrDefault() != 0m)
						{
							num4 += item.pordIDiscountPercent.GetValueOrDefault();
							num5++;
						}
					}
					if (num4 > 0m && num5 > 0)
					{
						num3 = num4 / (decimal)num5;
					}
				}
			}
			if (mobfnReturnPreOrderSumFooter_Result.SumPriceAmount.HasValue)
			{
				if (num3 > num2)
				{
					result = Messages.MaxDiscountPercentInActivePreOrder + " " + num2;
					return result;
				}
				if (mobfnReturnPreOrderSumFooter_Result.SumPriceAmount.GetValueOrDefault() == 0m)
				{
					decimal? totalPriceSumWithoutDiscount = mobspSelectPreOrderWithID_Result.pordDiscount;
					if (!((totalPriceSumWithoutDiscount.GetValueOrDefault() == default(decimal)) & totalPriceSumWithoutDiscount.HasValue))
					{
						result = Messages.msgErrorDivisionByZero;
						return result;
					}
				}
				if (mobfnReturnPreOrderSumFooter_Result.SumPriceAmount.HasValue)
				{
					decimal? totalPriceSumWithoutDiscount = mobfnReturnPreOrderSumFooter_Result.SumPriceAmount;
					if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
					{
						obj2 = Convert.ToDecimal(mobspSelectPreOrderWithID_Result.pordDiscount.GetValueOrDefault() * 100m) / Convert.ToDecimal(mobfnReturnPreOrderSumFooter_Result.SumPriceAmount);
						goto IL_045a;
					}
				}
				obj2 = 0m;
				goto IL_045a;
			}
			goto IL_0486;
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
