using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Models;
using Mobile.Models.ViewModel.VerificationWorkFlow;
using Stimulsoft.Base.Json;

namespace Mobile.Classes.Helper;

public class DyForm
{
	public static bool IsChecked(int mValId)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			MobspDySelectFormFieldMasterValueWithId_Result mobspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(mValId, lCID, result2));
			if (mobspDySelectFormFieldMasterValueWithId_Result != null && mobspDySelectFormFieldMasterValueWithId_Result.IsChecked.HasValue && mobspDySelectFormFieldMasterValueWithId_Result.IsChecked.GetValueOrDefault())
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

	public static bool SubFormIsChecked(int mvdId)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (mvdId > 0)
			{
				MobspDySelectFormFieldMasterValueDetailWithId_Result mobspDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetailWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetailWithId(mvdId, lCID, result2));
				if (mobspDySelectFormFieldMasterValueDetailWithId_Result != null && mobspDySelectFormFieldMasterValueDetailWithId_Result.IsChecked.HasValue && mobspDySelectFormFieldMasterValueDetailWithId_Result.IsChecked.GetValueOrDefault())
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
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string GetFormName(int formId, int defLangID, int currLangID, int? cId = null)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			MobspDySelectForms_Result mobspDySelectForms_Result = Enumerable.FirstOrDefault<MobspDySelectForms_Result>((IEnumerable<MobspDySelectForms_Result>)cRMEntities.MobspDySelectForms(formId, 0, currLangID, defLangID, cId));
			if (mobspDySelectForms_Result != null)
			{
				result = mobspDySelectForms_Result.FormName ?? "";
			}
			cRMEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string GetWorkflowStepTitle(int workflowStepId, int defLangID, int currLangID, int? cId = null)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			MobspDySelectFormWorkflowStepWithId_Result mobspDySelectFormWorkflowStepWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepWithId_Result>((IEnumerable<MobspDySelectFormWorkflowStepWithId_Result>)cRMEntities.MobspDySelectFormWorkflowStepWithId(workflowStepId, currLangID, defLangID, cId));
			if (mobspDySelectFormWorkflowStepWithId_Result != null)
			{
				result = mobspDySelectFormWorkflowStepWithId_Result.WorkflowStepTitle ?? "";
			}
			cRMEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string GetMasterValueDetailFirstRegister(int mValId, int workflowId, int workflowStepId, int defLangID, int currLangID, int masterValueDetailId, int? cId = null)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			MobspDySelectFormFieldMasterValueDetailWithId_Result mobspDySelectFormFieldMasterValueDetailWithId_Result = new MobspDySelectFormFieldMasterValueDetailWithId_Result();
			if (masterValueDetailId > 0)
			{
				mobspDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetailWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetailWithId(masterValueDetailId, currLangID, defLangID));
			}
			else
			{
				MobspDySelectFormWorkflowStepsForMasterValue_Result mobspDySelectFormWorkflowStepsForMasterValue_Result = Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<MobspDySelectFormWorkflowStepsForMasterValue_Result>)cRMEntities.MobspDySelectFormWorkflowStepsForMasterValue(workflowId, mValId, currLangID, defLangID, cId), (Func<MobspDySelectFormWorkflowStepsForMasterValue_Result, bool>)((MobspDySelectFormWorkflowStepsForMasterValue_Result m) => m.FormWorkflowStepId == workflowStepId));
				if (mobspDySelectFormWorkflowStepsForMasterValue_Result != null)
				{
					mobspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDate = mobspDySelectFormWorkflowStepsForMasterValue_Result.FirstRegisterDate ?? DateTime.Now;
					mobspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser = mobspDySelectFormWorkflowStepsForMasterValue_Result.FirstRegisterUser;
				}
			}
			if (mobspDySelectFormFieldMasterValueDetailWithId_Result != null)
			{
				MobspDySelectFormFieldMasterValueDetailWithId_Result mobspDySelectFormFieldMasterValueDetailWithId_Result2 = mobspDySelectFormFieldMasterValueDetailWithId_Result;
				_ = mobspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDate;
				mobspDySelectFormFieldMasterValueDetailWithId_Result2.FirstRegisterDatePersian = mobspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				mobspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser = mobspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser + " " + mobspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDatePersian;
				result = mobspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser ?? "";
			}
			cRMEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string GetMasterValueDetailCheckerUser(int mValId, int workflowId, int workflowStepId, int defLangID, int currLangID, int masterValueDetailId, int? cId = null)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			MobspDySelectFormFieldMasterValueDetailWithId_Result mobspDySelectFormFieldMasterValueDetailWithId_Result = new MobspDySelectFormFieldMasterValueDetailWithId_Result();
			if (masterValueDetailId > 0)
			{
				mobspDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetailWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetailWithId(masterValueDetailId, currLangID, defLangID));
			}
			else
			{
				MobspDySelectFormWorkflowStepsForMasterValue_Result mobspDySelectFormWorkflowStepsForMasterValue_Result = Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<MobspDySelectFormWorkflowStepsForMasterValue_Result>)cRMEntities.MobspDySelectFormWorkflowStepsForMasterValue(workflowId, mValId, currLangID, defLangID, cId), (Func<MobspDySelectFormWorkflowStepsForMasterValue_Result, bool>)((MobspDySelectFormWorkflowStepsForMasterValue_Result m) => m.FormWorkflowStepId == workflowStepId));
				if (mobspDySelectFormWorkflowStepsForMasterValue_Result != null)
				{
					mobspDySelectFormFieldMasterValueDetailWithId_Result.CheckedDate = mobspDySelectFormWorkflowStepsForMasterValue_Result.CheckedDate;
					mobspDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser = mobspDySelectFormWorkflowStepsForMasterValue_Result.CheckerUser;
				}
			}
			if (mobspDySelectFormFieldMasterValueDetailWithId_Result != null)
			{
				mobspDySelectFormFieldMasterValueDetailWithId_Result.CheckedDatePersian = (mobspDySelectFormFieldMasterValueDetailWithId_Result.CheckedDate.HasValue ? mobspDySelectFormFieldMasterValueDetailWithId_Result.CheckedDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
				mobspDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser = mobspDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser + " " + mobspDySelectFormFieldMasterValueDetailWithId_Result.CheckedDatePersian;
				result = mobspDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser ?? "";
			}
			cRMEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string GetUsersForSendMsg(int formId, string userIds, int defLangID, int currLangID, string langCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string text = "";
		try
		{
			foreach (MobspDySelectUserForFormToMultilUser_Result item in Enumerable.ToList<MobspDySelectUserForFormToMultilUser_Result>((IEnumerable<MobspDySelectUserForFormToMultilUser_Result>)cRMEntities.MobspDySelectUserForFormToMultilUser(formId, userIds, currLangID, defLangID)))
			{
				string text2 = "";
				if (item.FrmAccess == -100)
				{
					text2 = string.Format(" ({0})", MyResource.GetResourceString("DyFrmUserNotAccess", langCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly));
				}
				text = text + item.UserName + text2 + ",";
			}
			text = ((!string.IsNullOrEmpty(text)) ? text.TrimEnd(new char[1] { ',' }) : "");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return text;
	}

	public static bool IsEditAfterFix(string editAfterFixInfoJs = "", int mvId = 0, int? mode = null, int userId = 0, int? ln = null)
	{
		bool result = false;
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			mode = mode.GetValueOrDefault(1);
			if (string.IsNullOrWhiteSpace(editAfterFixInfoJs) && mvId != 0)
			{
				MobspDySelectFormFieldMasterValueWithId_Result mobspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(mvId, lCID, result2));
				if (mobspDySelectFormFieldMasterValueWithId_Result != null)
				{
					editAfterFixInfoJs = mobspDySelectFormFieldMasterValueWithId_Result.EditAfterFixInfoJs;
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
}
