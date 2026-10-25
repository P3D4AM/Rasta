using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using CRMIdealApi.ApiModels;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdealApi.Classes.Helper;

public class DyForm
{
	public static List<ApispDySelectFormsMenuWithSysPartId_Result> CreateMenu(int crmUserId, int crmSysPart, int foSysPart, int currLangID, int defLangID)
	{
		List<ApispDySelectFormsMenuWithSysPartId_Result> result = new List<ApispDySelectFormsMenuWithSysPartId_Result>();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			result = Enumerable.ToList<ApispDySelectFormsMenuWithSysPartId_Result>((IEnumerable<ApispDySelectFormsMenuWithSysPartId_Result>)cRMEntities.ApispDySelectFormsMenuWithSysPartId(crmSysPart, foSysPart, crmUserId, currLangID, defLangID));
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
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CreateMenuJs(int crmUserId, int crmSysPart, int foSysPart, int currLangID, int defLangID)
	{
		return JsonConvert.SerializeObject(CreateMenu(crmUserId, crmSysPart, foSysPart, currLangID, defLangID));
	}

	public static bool IsChecked(int mValId, int currLangID, int defLangID)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			ApispDySelectFormFieldMasterValueWithId_Result apispDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<ApispDySelectFormFieldMasterValueWithId_Result>((IEnumerable<ApispDySelectFormFieldMasterValueWithId_Result>)cRMEntities.ApispDySelectFormFieldMasterValueWithId(mValId, currLangID, defLangID));
			if (apispDySelectFormFieldMasterValueWithId_Result != null && apispDySelectFormFieldMasterValueWithId_Result.IsChecked.HasValue && apispDySelectFormFieldMasterValueWithId_Result.IsChecked.GetValueOrDefault())
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

	public static bool SubFormIsChecked(int mvdId, int currLangID, int defLangID)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			if (mvdId > 0)
			{
				ApispDySelectFormFieldMasterValueDetailWithId_Result apispDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<ApispDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<ApispDySelectFormFieldMasterValueDetailWithId_Result>)cRMEntities.ApispDySelectFormFieldMasterValueDetailWithId(mvdId, currLangID, defLangID));
				if (apispDySelectFormFieldMasterValueDetailWithId_Result != null && apispDySelectFormFieldMasterValueDetailWithId_Result.IsChecked.HasValue && apispDySelectFormFieldMasterValueDetailWithId_Result.IsChecked.GetValueOrDefault())
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

	public static string GetFormName(int formId, int defLangID, int currLangID)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispDySelectForms_Result apispDySelectForms_Result = Enumerable.FirstOrDefault<ApispDySelectForms_Result>((IEnumerable<ApispDySelectForms_Result>)cRMEntities.ApispDySelectForms(formId, 0, currLangID, defLangID, 0, ""));
			if (apispDySelectForms_Result != null)
			{
				result = apispDySelectForms_Result.ApiFormName ?? "";
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
		ResourceManager resourceManager = new ResourceManager();
		try
		{
			List<ApispDySelectUserForFormToMultilUser_Result> list = Enumerable.ToList<ApispDySelectUserForFormToMultilUser_Result>((IEnumerable<ApispDySelectUserForFormToMultilUser_Result>)cRMEntities.ApispDySelectUserForFormToMultilUser(formId, userIds, currLangID, defLangID));
			foreach (ApispDySelectUserForFormToMultilUser_Result item in list)
			{
				string text2 = "";
				if (item.FrmAccess == -100)
				{
					text2 = string.Format(" ({0})", resourceManager.Get("DyFrmUserNotAccess", new CultureInfo(currLangID).Name, resourceManager.TypeMsg));
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

	public static string GetWorkflowStepTitle(int workflowStepId, int defLangID, int currLangID)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispDySelectFormWorkflowStepWithId_Result apispDySelectFormWorkflowStepWithId_Result = Enumerable.FirstOrDefault<ApispDySelectFormWorkflowStepWithId_Result>((IEnumerable<ApispDySelectFormWorkflowStepWithId_Result>)cRMEntities.ApispDySelectFormWorkflowStepWithId(workflowStepId, currLangID, defLangID));
			if (apispDySelectFormWorkflowStepWithId_Result != null)
			{
				result = apispDySelectFormWorkflowStepWithId_Result.WorkflowStepTitle ?? "";
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

	public static string GetMasterValueDetailFirstRegister(int mValId, int workflowId, int workflowStepId, int defLangID, int currLangID, int masterValueDetailId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispDySelectFormFieldMasterValueDetailWithId_Result apispDySelectFormFieldMasterValueDetailWithId_Result = new ApispDySelectFormFieldMasterValueDetailWithId_Result();
			if (masterValueDetailId > 0)
			{
				apispDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<ApispDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<ApispDySelectFormFieldMasterValueDetailWithId_Result>)cRMEntities.ApispDySelectFormFieldMasterValueDetailWithId(masterValueDetailId, currLangID, defLangID));
			}
			else
			{
				ApispDySelectFormWorkflowStepsForMasterValue_Result apispDySelectFormWorkflowStepsForMasterValue_Result = Enumerable.FirstOrDefault<ApispDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<ApispDySelectFormWorkflowStepsForMasterValue_Result>)cRMEntities.ApispDySelectFormWorkflowStepsForMasterValue(workflowId, mValId, currLangID, defLangID), (Func<ApispDySelectFormWorkflowStepsForMasterValue_Result, bool>)((ApispDySelectFormWorkflowStepsForMasterValue_Result m) => m.FormWorkflowStepId == workflowStepId));
				if (apispDySelectFormWorkflowStepsForMasterValue_Result != null)
				{
					apispDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDate = apispDySelectFormWorkflowStepsForMasterValue_Result.FirstRegisterDate ?? DateTime.Now;
					apispDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser = apispDySelectFormWorkflowStepsForMasterValue_Result.FirstRegisterUser;
				}
			}
			if (apispDySelectFormFieldMasterValueDetailWithId_Result != null)
			{
				ApispDySelectFormFieldMasterValueDetailWithId_Result apispDySelectFormFieldMasterValueDetailWithId_Result2 = apispDySelectFormFieldMasterValueDetailWithId_Result;
				_ = apispDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDate;
				apispDySelectFormFieldMasterValueDetailWithId_Result2.FirstRegisterDatePersian = apispDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				apispDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser = apispDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser + " " + apispDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDatePersian;
				result = apispDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser ?? "";
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

	public static string GetMasterValueDetailCheckerUser(int mValId, int workflowId, int workflowStepId, int defLangID, int currLangID, int masterValueDetailId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispDySelectFormFieldMasterValueDetailWithId_Result apispDySelectFormFieldMasterValueDetailWithId_Result = new ApispDySelectFormFieldMasterValueDetailWithId_Result();
			if (masterValueDetailId > 0)
			{
				apispDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<ApispDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<ApispDySelectFormFieldMasterValueDetailWithId_Result>)cRMEntities.ApispDySelectFormFieldMasterValueDetailWithId(masterValueDetailId, currLangID, defLangID));
			}
			else
			{
				ApispDySelectFormWorkflowStepsForMasterValue_Result apispDySelectFormWorkflowStepsForMasterValue_Result = Enumerable.FirstOrDefault<ApispDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<ApispDySelectFormWorkflowStepsForMasterValue_Result>)cRMEntities.ApispDySelectFormWorkflowStepsForMasterValue(workflowId, mValId, currLangID, defLangID), (Func<ApispDySelectFormWorkflowStepsForMasterValue_Result, bool>)((ApispDySelectFormWorkflowStepsForMasterValue_Result m) => m.FormWorkflowStepId == workflowStepId));
				if (apispDySelectFormWorkflowStepsForMasterValue_Result != null)
				{
					apispDySelectFormFieldMasterValueDetailWithId_Result.CheckedDate = apispDySelectFormWorkflowStepsForMasterValue_Result.CheckedDate;
					apispDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser = apispDySelectFormWorkflowStepsForMasterValue_Result.CheckerUser;
				}
			}
			if (apispDySelectFormFieldMasterValueDetailWithId_Result != null)
			{
				apispDySelectFormFieldMasterValueDetailWithId_Result.CheckedDatePersian = (apispDySelectFormFieldMasterValueDetailWithId_Result.CheckedDate.HasValue ? apispDySelectFormFieldMasterValueDetailWithId_Result.CheckedDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
				apispDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser = apispDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser + " " + apispDySelectFormFieldMasterValueDetailWithId_Result.CheckedDatePersian;
				result = apispDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser ?? "";
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
}
