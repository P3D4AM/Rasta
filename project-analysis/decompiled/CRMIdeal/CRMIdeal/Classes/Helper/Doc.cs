using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Threading;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class Doc
{
	public static bool IsFixed(int docId, int? isEditAfterFixMode = null)
	{
		bool result = false;
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			WSDoc wSDoc = cRMTabelEntities.WSDoc.Find(docId);
			if (wSDoc != null && wSDoc.IsFix.HasValue && ((int?)wSDoc.IsFix).GetValueOrDefault() == 1)
			{
				result = true;
			}
			if (IsEditAfterFix(wSDoc.EditAfterFixInfoJs, docId, isEditAfterFixMode))
			{
				result = false;
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
			cRMTabelEntities.Dispose();
		}
		return result;
	}

	public static bool IsEditAfterFix(string editAfterFixInfoJs = "", int docId = 0, int? mode = null)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			mode = mode.GetValueOrDefault(1);
			if (string.IsNullOrWhiteSpace(editAfterFixInfoJs) && docId != 0)
			{
				WSspSelectDocById_Result wSspSelectDocById_Result = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)cRMSpIEntities.WSspSelectDocById(docId, lCID, result2));
				if (wSspSelectDocById_Result != null)
				{
					editAfterFixInfoJs = wSspSelectDocById_Result.EditAfterFixInfoJs;
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
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static bool ReferDocToOrdReferUser(string docIds, int? currUserId = 0)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (!string.IsNullOrWhiteSpace(docIds))
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				int value4 = 0;
				if (currUserId.GetValueOrDefault() == 0)
				{
					value4 = UserLogin.CurrentUser.UserId;
				}
				List<CrmInternalMessage_Lang> list = new List<CrmInternalMessage_Lang>();
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmInternalMessage_Lang crmInternalMessage_Lang = new CrmInternalMessage_Lang();
					crmInternalMessage_Lang.LanguageID = item.LanguageID;
					crmInternalMessage_Lang.msgSubject = MyResource.GetResourceString("docVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					crmInternalMessage_Lang.msgBody = string.Format(MyResource.GetResourceString("docVerifiedRequest", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly), "[#OprType#]") + "\n" + MyResource.GetResourceString("docVerifiedRequestDocOpr", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#Opr#]\n" + MyResource.GetResourceString("docVerifiedRequestDocNumber", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#DocNumber#]\n" + MyResource.GetResourceString("docVerifiedRequestDocDate", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#DocDate#]\n" + MyResource.GetResourceString("docVerifiedRequestCompanayName", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#CmpName#]\n" + MyResource.GetResourceString("docVerifiedRequestFirstRegister", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#FirstRegisterUser#]\n" + MyResource.GetResourceString("docVerifiedRequestVerifier", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#Verifier#]\n" + MyResource.GetResourceString("docVerifiedRequestDbClickOnOtherInfo", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + "\n";
					list.Add(crmInternalMessage_Lang);
					CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel.Value = MyResource.GetResourceString("lblDoc", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					list2.Add(commonMultiLanguageViewModel);
					CommonMultiLanguageViewModel commonMultiLanguageViewModel2 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel2.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel2.Value = MyResource.GetResourceString("lblDraft", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					list3.Add(commonMultiLanguageViewModel2);
					CommonMultiLanguageViewModel commonMultiLanguageViewModel3 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel3.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel3.Value = MyResource.GetResourceString("lblMoveMent", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					list4.Add(commonMultiLanguageViewModel3);
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
				if (list != null && Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list))
				{
					intMsgSubject = (Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)).msgSubject : "");
					intMsgBody = (Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)).msgBody : "");
					intMsgLang = JsonConvert.SerializeObject(Enumerable.ToList<CrmInternalMessage_Lang>(Enumerable.Where<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID != defLangID))));
				}
				if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
				{
					docTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
					docTxtLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
				}
				if (list3 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
				{
					draftTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
					draftTxtLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
				}
				if (list4 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4))
				{
					movementTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
					movementTxtLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
				}
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpIEntities.WSspReferDocToOrdReferUser(docIds, intMsgBody, intMsgSubject, intMsgLang, value4, value3, value2, value, registerDatePersian, appType, defLangID, docTxt, docTxtLang, draftTxt, draftTxtLang, movementTxt, movementTxtLang, centerId));
				int result2 = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result2);
				}
				result = result2 == 1;
				PushNotif.NewIntMsgNotify();
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
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static bool IsSentToLinkAcc(int docId)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectDocById_Result wSspSelectDocById_Result = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)cRMSpIEntities.WSspSelectDocById(docId, lCID, result2));
			if (wSspSelectDocById_Result != null)
			{
				bool.TryParse(wSspSelectDocById_Result.IsSentToLinkAcc.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static bool IsSentToLinkAccByAction(int docId)
	{
		bool result = false;
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmDoc", "actChangeAfterSendToLinkAcc", currentUser))
			{
				result = IsSentToLinkAcc(docId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static int? GetDocCId(int docId)
	{
		int? result = null;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectDocById_Result wSspSelectDocById_Result = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)cRMSpIEntities.WSspSelectDocById(docId, lCID, result2));
			if (wSspSelectDocById_Result != null)
			{
				result = wSspSelectDocById_Result.DocCId;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static int? GetDocItemCId(int docItemId)
	{
		int? result = null;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectDocItemsById_Result wSspSelectDocItemsById_Result = Enumerable.FirstOrDefault<WSspSelectDocItemsById_Result>((IEnumerable<WSspSelectDocItemsById_Result>)cRMSpIIEntities.WSspSelectDocItemsById(docItemId, lCID, result2));
			if (wSspSelectDocItemsById_Result != null)
			{
				result = wSspSelectDocItemsById_Result.DocICId;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static bool SendToLinkAccNeedVerify(int docId, ref string errorMessage)
	{
		bool result = true;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string linkAccSystemTitle = Setting.GetLinkAccSystemTitle();
			WSspSelectDocById_Result wSspSelectDocById_Result = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)cRMSpIEntities.WSspSelectDocById(docId, lCID, result2));
			int num = 0;
			if (wSspSelectDocById_Result != null)
			{
				num = wSspSelectDocById_Result.OprType.GetValueOrDefault();
			}
			string formName = "frmDoc";
			string actionName = "actSendToLinkAccNeedVerify";
			string arg = Labels.lblDoc;
			switch (num)
			{
			case 2:
				formName = "frmDraft";
				arg = Labels.lblDraft;
				break;
			case 3:
				formName = "frmWareHouseMovement";
				arg = Labels.lblMoveMent;
				break;
			}
			if (UserLogin.IsUserAccess(formName, actionName, UserLogin.CurrentUser) && wSspSelectDocById_Result != null && !wSspSelectDocById_Result.IsVerified.GetValueOrDefault())
			{
				result = false;
				errorMessage = string.Format(Messages.msgErrorSendToLinkAccNeedVerifyByNumber, arg, wSspSelectDocById_Result.DocNumber.ToString(), linkAccSystemTitle);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static bool IsVerified(int docId)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectDocById_Result wSspSelectDocById_Result = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)cRMSpIEntities.WSspSelectDocById(docId, lCID, result2));
			if (wSspSelectDocById_Result != null)
			{
				result = wSspSelectDocById_Result.IsVerified.GetValueOrDefault();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static List<WSspSelectDocOpr_Result> SelecDocOpr(int currLangId = 0, int defLangId = 0)
	{
		List<WSspSelectDocOpr_Result> result = new List<WSspSelectDocOpr_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			if (defLangId == 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out defLangId);
			}
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			if (currLangId == 0)
			{
				currLangId = Thread.CurrentThread.CurrentCulture.LCID;
			}
			result = Enumerable.ToList<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)cRMSpEntities.WSspSelectDocOpr(currLangId, defLangId));
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
