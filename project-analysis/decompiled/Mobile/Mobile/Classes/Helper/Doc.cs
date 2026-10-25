using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Models;
using Mobile.Models.ViewModel.VerificationWorkFlow;
using Newtonsoft.Json;

namespace Mobile.Classes.Helper;

public class Doc
{
	public static bool IsFixed(int docId)
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
			MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(docId, lCID, result2));
			if (mobspSelectDocById_Result != null && mobspSelectDocById_Result.IsFix.HasValue && ((int?)mobspSelectDocById_Result.IsFix).GetValueOrDefault() == 1)
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
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static bool ReferDocToOrdReferUser(string docIds, int? centerId = null)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(docIds))
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
				List<CrmInternalMessage_Lang> list2 = new List<CrmInternalMessage_Lang>();
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				foreach (MobspSelectLanguages_Result item in list)
				{
					CrmInternalMessage_Lang crmInternalMessage_Lang = new CrmInternalMessage_Lang();
					crmInternalMessage_Lang.LanguageID = item.LanguageID;
					crmInternalMessage_Lang.msgSubject = MyResource.GetResourceString("docVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					crmInternalMessage_Lang.msgBody = string.Format(MyResource.GetResourceString("docVerifiedRequest", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly), "[#OprType#]") + "\n" + MyResource.GetResourceString("docVerifiedRequestDocOpr", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#Opr#]\n" + MyResource.GetResourceString("docVerifiedRequestDocNumber", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#DocNumber#]\n" + MyResource.GetResourceString("docVerifiedRequestDocDate", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#DocDate#]\n" + MyResource.GetResourceString("docVerifiedRequestCompanayName", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#CmpName#]\n" + MyResource.GetResourceString("docVerifiedRequestFirstRegister", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#FirstRegisterUser#]\n" + MyResource.GetResourceString("docVerifiedRequestVerifier", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#Verifier#]\n" + MyResource.GetResourceString("docVerifiedRequestDbClickOnOtherInfo", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + "\n";
					list2.Add(crmInternalMessage_Lang);
					CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel.Value = MyResource.GetResourceString("lblDoc", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					list3.Add(commonMultiLanguageViewModel);
					CommonMultiLanguageViewModel commonMultiLanguageViewModel2 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel2.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel2.Value = MyResource.GetResourceString("lblDraft", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					list4.Add(commonMultiLanguageViewModel2);
					CommonMultiLanguageViewModel commonMultiLanguageViewModel3 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel3.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel3.Value = MyResource.GetResourceString("lblMoveMent", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					list5.Add(commonMultiLanguageViewModel3);
				}
				string intMsgBody = "";
				string intMsgSubject = "";
				string intMsgLang = "";
				string docTxt = "";
				string docTxtLang = "";
				string draftTxt = "";
				string draftTxtLang = "";
				string movementTxt = "";
				string movementTxtLang = "";
				if (list2 != null && Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2))
				{
					intMsgSubject = (Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)).msgSubject : "");
					intMsgBody = (Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)).msgBody : "");
					intMsgLang = JsonConvert.SerializeObject(Enumerable.ToList<CrmInternalMessage_Lang>(Enumerable.Where<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list2, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID != defLangID))));
				}
				if (list3 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
				{
					docTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
					docTxtLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
				}
				if (list4 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
				{
					draftTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
					draftTxtLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
				}
				if (list5 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5))
				{
					movementTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
					movementTxtLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
				}
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.MobspReferDocToOrdReferUser(docIds, intMsgBody, intMsgSubject, intMsgLang, userId, value3, value2, value, registerDatePersian, appType, defLangID, docTxt, docTxtLang, draftTxt, draftTxtLang, movementTxt, movementTxtLang, centerId));
				int result2 = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result2);
				}
				result = result2 == 1;
				PushNotif.NewIntMsgNotify(withthread: true, centerId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static bool IsEditAfterFix(string editAfterFixInfoJs = "", int docId = 0, int? mode = null, int userId = 0, int? ln = null)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			mode = mode.GetValueOrDefault(1);
			if (string.IsNullOrWhiteSpace(editAfterFixInfoJs) && docId != 0)
			{
				MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(docId, lCID, result2));
				if (mobspSelectDocById_Result != null)
				{
					editAfterFixInfoJs = mobspSelectDocById_Result.EditAfterFixInfoJs;
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
}
