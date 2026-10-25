using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class Draft
{
	public static bool IsFixed(int draftId, int? isEditAfterFixMode = null)
	{
		bool result = false;
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			WSDoc wSDoc = cRMTabelEntities.WSDoc.Find(draftId);
			if (wSDoc != null && wSDoc.IsFix.HasValue && ((int?)wSDoc.IsFix).GetValueOrDefault() == 1)
			{
				result = true;
			}
			if (IsEditAfterFix(wSDoc.EditAfterFixInfoJs, draftId, isEditAfterFixMode))
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
			if (!UserLogin.IsUserAccess("frmDraft", "actChangeAfterSendToLinkAcc", currentUser))
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
}
