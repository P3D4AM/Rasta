using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Script.Serialization;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class DyForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public int mvId;
	}

	public static bool IsFixed(int mvId = 0, int? isEditAfterFixMode = null)
	{
		_003C_003Ec__DisplayClass0_0 _003C_003Ec__DisplayClass0_ = new _003C_003Ec__DisplayClass0_0();
		_003C_003Ec__DisplayClass0_.mvId = mvId;
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			DbSet<CrmDyFormFieldMasterValues> crmDyFormFieldMasterValues = cRMTabelEntities.CrmDyFormFieldMasterValues;
			ParameterExpression val = Expression.Parameter(typeof(CrmDyFormFieldMasterValues), "c");
			CrmDyFormFieldMasterValues crmDyFormFieldMasterValues2 = Queryable.FirstOrDefault<CrmDyFormFieldMasterValues>((IQueryable<CrmDyFormFieldMasterValues>)crmDyFormFieldMasterValues, Expression.Lambda<Func<CrmDyFormFieldMasterValues, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass0_, typeof(_003C_003Ec__DisplayClass0_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmDyFormFieldMasterValues2 != null && crmDyFormFieldMasterValues2.IsFixed.HasValue && crmDyFormFieldMasterValues2.IsFixed.GetValueOrDefault())
			{
				result = true;
			}
			if (IsEditAfterFix(crmDyFormFieldMasterValues2.EditAfterFixInfoJs, _003C_003Ec__DisplayClass0_.mvId, isEditAfterFixMode))
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
			cRMSpEntities.Dispose();
			cRMTabelEntities.Dispose();
		}
		return result;
	}

	public static bool IsEditAfterFix(string editAfterFixInfoJs = "", int mvId = 0, int? mode = null)
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
			int userId = UserLogin.CurrentUser.UserId;
			mode = mode.GetValueOrDefault(1);
			if (string.IsNullOrWhiteSpace(editAfterFixInfoJs) && mvId != 0)
			{
				CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)cRMSpEntities.CRMspDySelectFormFieldMasterValueWithId(mvId, lCID, result2));
				if (cRMspDySelectFormFieldMasterValueWithId_Result != null)
				{
					editAfterFixInfoJs = cRMspDySelectFormFieldMasterValueWithId_Result.EditAfterFixInfoJs;
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
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static List<CRMspDySelectFormsMenuWithSysPartId_Result> CreateMenu(int crmSysPart, int foSysPart)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspDySelectFormsMenuWithSysPartId_Result> result2 = new List<CRMspDySelectFormsMenuWithSysPartId_Result>();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			result2 = Enumerable.ToList<CRMspDySelectFormsMenuWithSysPartId_Result>((IEnumerable<CRMspDySelectFormsMenuWithSysPartId_Result>)cRMSpIEntities.CRMspDySelectFormsMenuWithSysPartId(crmSysPart, foSysPart, UserLogin.CurrentUser.UserId, lCID, result, result3));
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
		return result2;
	}

	public static string CreateMenuJs(int crmSysPart, int foSysPart)
	{
		return JsonConvert.SerializeObject(CreateMenu(crmSysPart, foSysPart));
	}

	public static bool IsChecked(int mValId)
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
			CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)cRMSpEntities.CRMspDySelectFormFieldMasterValueWithId(mValId, lCID, result2));
			if (cRMspDySelectFormFieldMasterValueWithId_Result != null && cRMspDySelectFormFieldMasterValueWithId_Result.IsChecked.HasValue && cRMspDySelectFormFieldMasterValueWithId_Result.IsChecked.GetValueOrDefault())
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

	public static bool SubFormIsChecked(int mvdId)
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
			if (mvdId > 0)
			{
				CRMspDySelectFormFieldMasterValueDetailWithId_Result cRMspDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetailWithId_Result>)cRMSpEntities.CRMspDySelectFormFieldMasterValueDetailWithId(mvdId, lCID, result2));
				if (cRMspDySelectFormFieldMasterValueDetailWithId_Result != null && cRMspDySelectFormFieldMasterValueDetailWithId_Result.IsChecked.HasValue && cRMspDySelectFormFieldMasterValueDetailWithId_Result.IsChecked.GetValueOrDefault())
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

	public static string GetFormName(int formId, int defLangID, int currLangID)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result = "";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)cRMSpEntities.CRMspDySelectForms(formId, 0, currLangID, defLangID, result2));
			if (cRMspDySelectForms_Result != null)
			{
				result = cRMspDySelectForms_Result.FormName ?? "";
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static string GetUsersForSendMsg(int formId, string userIds, int defLangID, int currLangID, string langCollation)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string text = "";
		try
		{
			foreach (CRMspDySelectUserForFormToMultilUser_Result item in Enumerable.ToList<CRMspDySelectUserForFormToMultilUser_Result>((IEnumerable<CRMspDySelectUserForFormToMultilUser_Result>)cRMSpEntities.CRMspDySelectUserForFormToMultilUser(formId, userIds, currLangID, defLangID)))
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
			cRMSpEntities.Dispose();
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return text;
	}

	public static string GetWorkflowStepTitle(int workflowStepId, int defLangID, int currLangID)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result = "";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMspDySelectFormWorkflowStepWithId_Result cRMspDySelectFormWorkflowStepWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepWithId_Result>((IEnumerable<CRMspDySelectFormWorkflowStepWithId_Result>)cRMSpEntities.CRMspDySelectFormWorkflowStepWithId(workflowStepId, currLangID, defLangID, result2));
			if (cRMspDySelectFormWorkflowStepWithId_Result != null)
			{
				result = cRMspDySelectFormWorkflowStepWithId_Result.WorkflowStepTitle ?? "";
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static string GetMasterValueDetailFirstRegister(int mValId, int workflowId, int workflowStepId, int defLangID, int currLangID, int masterValueDetailId)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result = "";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMspDySelectFormFieldMasterValueDetailWithId_Result cRMspDySelectFormFieldMasterValueDetailWithId_Result = new CRMspDySelectFormFieldMasterValueDetailWithId_Result();
			if (masterValueDetailId > 0)
			{
				cRMspDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetailWithId_Result>)cRMSpEntities.CRMspDySelectFormFieldMasterValueDetailWithId(masterValueDetailId, currLangID, defLangID));
			}
			else
			{
				CRMspDySelectFormWorkflowStepsForMasterValue_Result cRMspDySelectFormWorkflowStepsForMasterValue_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<CRMspDySelectFormWorkflowStepsForMasterValue_Result>)cRMSpEntities.CRMspDySelectFormWorkflowStepsForMasterValue(workflowId, mValId, currLangID, defLangID, result2), (Func<CRMspDySelectFormWorkflowStepsForMasterValue_Result, bool>)((CRMspDySelectFormWorkflowStepsForMasterValue_Result m) => m.FormWorkflowStepId == workflowStepId));
				if (cRMspDySelectFormWorkflowStepsForMasterValue_Result != null)
				{
					cRMspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDate = cRMspDySelectFormWorkflowStepsForMasterValue_Result.FirstRegisterDate ?? DateTime.Now;
					cRMspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser = cRMspDySelectFormWorkflowStepsForMasterValue_Result.FirstRegisterUser;
				}
			}
			if (cRMspDySelectFormFieldMasterValueDetailWithId_Result != null)
			{
				CRMspDySelectFormFieldMasterValueDetailWithId_Result cRMspDySelectFormFieldMasterValueDetailWithId_Result2 = cRMspDySelectFormFieldMasterValueDetailWithId_Result;
				_ = cRMspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDate;
				cRMspDySelectFormFieldMasterValueDetailWithId_Result2.FirstRegisterDatePersian = cRMspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser = cRMspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser + " " + cRMspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterDatePersian;
				result = cRMspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUser ?? "";
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static string GetMasterValueDetailCheckerUser(int mValId, int workflowId, int workflowStepId, int defLangID, int currLangID, int masterValueDetailId)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result = "";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMspDySelectFormFieldMasterValueDetailWithId_Result cRMspDySelectFormFieldMasterValueDetailWithId_Result = new CRMspDySelectFormFieldMasterValueDetailWithId_Result();
			if (masterValueDetailId > 0)
			{
				cRMspDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueDetailWithId_Result>)cRMSpEntities.CRMspDySelectFormFieldMasterValueDetailWithId(masterValueDetailId, currLangID, defLangID));
			}
			else
			{
				CRMspDySelectFormWorkflowStepsForMasterValue_Result cRMspDySelectFormWorkflowStepsForMasterValue_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<CRMspDySelectFormWorkflowStepsForMasterValue_Result>)cRMSpEntities.CRMspDySelectFormWorkflowStepsForMasterValue(workflowId, mValId, currLangID, defLangID, result2), (Func<CRMspDySelectFormWorkflowStepsForMasterValue_Result, bool>)((CRMspDySelectFormWorkflowStepsForMasterValue_Result m) => m.FormWorkflowStepId == workflowStepId));
				if (cRMspDySelectFormWorkflowStepsForMasterValue_Result != null)
				{
					cRMspDySelectFormFieldMasterValueDetailWithId_Result.CheckedDate = cRMspDySelectFormWorkflowStepsForMasterValue_Result.CheckedDate;
					cRMspDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser = cRMspDySelectFormWorkflowStepsForMasterValue_Result.CheckerUser;
				}
			}
			if (cRMspDySelectFormFieldMasterValueDetailWithId_Result != null)
			{
				cRMspDySelectFormFieldMasterValueDetailWithId_Result.CheckedDatePersian = (cRMspDySelectFormFieldMasterValueDetailWithId_Result.CheckedDate.HasValue ? cRMspDySelectFormFieldMasterValueDetailWithId_Result.CheckedDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
				cRMspDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser = cRMspDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser + " " + cRMspDySelectFormFieldMasterValueDetailWithId_Result.CheckedDatePersian;
				result = cRMspDySelectFormFieldMasterValueDetailWithId_Result.CheckerUser ?? "";
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static string GetFormCenterInfoJsByName(string centerInfo, string cIds)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			string[] array = new string[1];
			if (!string.IsNullOrWhiteSpace(cIds))
			{
				array = cIds.Split(new char[1] { ',' });
			}
			if (array == null || array.Length == 0)
			{
				array = new string[1] { result3.ToString() };
			}
			List<FormCenterInfoJsByNameViewModel> list = new List<FormCenterInfoJsByNameViewModel>();
			if (!string.IsNullOrWhiteSpace(centerInfo))
			{
				list = new JavaScriptSerializer().Deserialize<List<FormCenterInfoJsByNameViewModel>>(centerInfo);
			}
			if (list != null && array != null)
			{
				if (Enumerable.Any<FormCenterInfoJsByNameViewModel>((IEnumerable<FormCenterInfoJsByNameViewModel>)list))
				{
					for (int i = 0; i < array.Length; i++)
					{
						int cI = 0;
						int.TryParse(array[i], out cI);
						if (cI == 0)
						{
							continue;
						}
						bool flag = false;
						FormCenterInfoJsByNameViewModel formCenterInfoJsByNameViewModel = Enumerable.FirstOrDefault<FormCenterInfoJsByNameViewModel>((IEnumerable<FormCenterInfoJsByNameViewModel>)list, (Func<FormCenterInfoJsByNameViewModel, bool>)((FormCenterInfoJsByNameViewModel m) => m.CId == cI.ToString()));
						if (formCenterInfoJsByNameViewModel != null)
						{
							int result4 = 0;
							int.TryParse(formCenterInfoJsByNameViewModel.CId, out result4);
							if (result4 != 0)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							list.Add(new FormCenterInfoJsByNameViewModel
							{
								CId = cI.ToString(),
								PFId = "0"
							});
						}
					}
				}
				else
				{
					for (int j = 0; j < array.Length; j++)
					{
						int result5 = 0;
						int.TryParse(array[j], out result5);
						if (result5 != 0)
						{
							list.Add(new FormCenterInfoJsByNameViewModel
							{
								CId = result5.ToString(),
								PFId = "0"
							});
						}
					}
				}
			}
			if (list != null && Enumerable.Any<FormCenterInfoJsByNameViewModel>((IEnumerable<FormCenterInfoJsByNameViewModel>)list))
			{
				foreach (FormCenterInfoJsByNameViewModel item in list)
				{
					int result6 = 0;
					int.TryParse(item.CId, out result6);
					item.CenterName = Center.GetNames(result6.ToString());
					int result7 = 0;
					int.TryParse(item.PFId, out result7);
					item.PFTitle = PrintFormat.GetPrintFormatTitle(result7, lCID, result2);
				}
				result = JsonConvert.SerializeObject(Enumerable.ToList<FormCenterInfoJsByNameViewModel>((IEnumerable<FormCenterInfoJsByNameViewModel>)list));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string GetFormCenterInfoJs(string centerInfo, string oldCenterInfo, string cIds, int printFormatId = 0)
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
			int result3 = 0;
			if (UserLogin.CurrentUser != null && result3 == 0)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<FormCenterInfoJsViewModel> list = new List<FormCenterInfoJsViewModel>();
			List<FormCenterInfoJsViewModel> list2 = new List<FormCenterInfoJsViewModel>();
			if (!string.IsNullOrWhiteSpace(oldCenterInfo))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<FormCenterInfoJsViewModel>>(oldCenterInfo);
			}
			string[] array = new string[1];
			if (!string.IsNullOrWhiteSpace(cIds))
			{
				array = cIds.Split(new char[1] { ',' });
			}
			if (array == null || array.Length == 0)
			{
				array = new string[1] { result3.ToString() };
			}
			List<FormCenterInfoJsByNameViewModel> list3 = new List<FormCenterInfoJsByNameViewModel>();
			if (!string.IsNullOrWhiteSpace(centerInfo))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<FormCenterInfoJsByNameViewModel>>(centerInfo);
			}
			if (list3 != null && array != null)
			{
				if (Enumerable.Any<FormCenterInfoJsByNameViewModel>((IEnumerable<FormCenterInfoJsByNameViewModel>)list3))
				{
					for (int i = 0; i < array.Length; i++)
					{
						int cI = 0;
						int.TryParse(array[i], out cI);
						if (cI == 0)
						{
							continue;
						}
						bool flag = false;
						FormCenterInfoJsByNameViewModel formCenterInfoJsByNameViewModel = Enumerable.FirstOrDefault<FormCenterInfoJsByNameViewModel>((IEnumerable<FormCenterInfoJsByNameViewModel>)list3, (Func<FormCenterInfoJsByNameViewModel, bool>)((FormCenterInfoJsByNameViewModel m) => m.CId == cI.ToString()));
						if (formCenterInfoJsByNameViewModel != null)
						{
							int result4 = 0;
							int.TryParse(formCenterInfoJsByNameViewModel.CId, out result4);
							if (result4 != 0)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							list3.Add(new FormCenterInfoJsByNameViewModel
							{
								CId = cI.ToString(),
								PFId = "0"
							});
						}
					}
				}
				else
				{
					for (int j = 0; j < array.Length; j++)
					{
						int result5 = 0;
						int.TryParse(array[j], out result5);
						if (result5 != 0)
						{
							list3.Add(new FormCenterInfoJsByNameViewModel
							{
								CId = result5.ToString(),
								PFId = "0"
							});
						}
					}
				}
			}
			if (list3 != null && Enumerable.Any<FormCenterInfoJsByNameViewModel>((IEnumerable<FormCenterInfoJsByNameViewModel>)list3))
			{
				foreach (FormCenterInfoJsByNameViewModel item2 in list3)
				{
					int cId = 0;
					int.TryParse(item2.CId, out cId);
					if (cId == 0)
					{
						continue;
					}
					int result6 = 0;
					int.TryParse(item2.PFId, out result6);
					item2.PFId = result6.ToString();
					if (cId.ToString() == result3.ToString())
					{
						switch (printFormatId)
						{
						default:
							item2.PFId = printFormatId.ToString();
							break;
						case 0:
							item2.PFId = "0";
							break;
						case -1:
							break;
						}
					}
					FormCenterInfoJsViewModel formCenterInfoJsViewModel = new FormCenterInfoJsViewModel();
					if (list2 != null && Enumerable.Any<FormCenterInfoJsViewModel>((IEnumerable<FormCenterInfoJsViewModel>)list2))
					{
						formCenterInfoJsViewModel = Enumerable.FirstOrDefault<FormCenterInfoJsViewModel>((IEnumerable<FormCenterInfoJsViewModel>)list2, (Func<FormCenterInfoJsViewModel, bool>)((FormCenterInfoJsViewModel m) => m.CId == cId.ToString()));
					}
					if (formCenterInfoJsViewModel == null)
					{
						formCenterInfoJsViewModel = new FormCenterInfoJsViewModel
						{
							CId = cId.ToString(),
							PFId = printFormatId.ToString()
						};
					}
					FormCenterInfoJsViewModel item = new FormCenterInfoJsViewModel
					{
						CId = cId.ToString(),
						PFId = (item2.PFId ?? "0")
					};
					list.Add(item);
				}
			}
			if (list != null && Enumerable.Any<FormCenterInfoJsViewModel>((IEnumerable<FormCenterInfoJsViewModel>)list))
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<FormCenterInfoJsViewModel>((IEnumerable<FormCenterInfoJsViewModel>)list));
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

	public static void GetFormPrintFormatInCenter(int formId, ref int printFormatId, int userLastCId = 0)
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (UserLogin.CurrentUser != null && userLastCId == 0)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
			}
			CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)cRMSpEntities.CRMspDySelectForms(formId, 0, lCID, result, userLastCId));
			if (cRMspDySelectForms_Result == null)
			{
				return;
			}
			List<FormCenterInfoJsByNameViewModel> list = new List<FormCenterInfoJsByNameViewModel>();
			string formCenterInfoJsByName = GetFormCenterInfoJsByName(cRMspDySelectForms_Result.FormCenterInfoJs ?? "", cRMspDySelectForms_Result.FormCIds ?? "");
			if (string.IsNullOrWhiteSpace(formCenterInfoJsByName))
			{
				return;
			}
			list = new JavaScriptSerializer().Deserialize<List<FormCenterInfoJsByNameViewModel>>(formCenterInfoJsByName);
			if (list == null || !Enumerable.Any<FormCenterInfoJsByNameViewModel>((IEnumerable<FormCenterInfoJsByNameViewModel>)list))
			{
				return;
			}
			foreach (FormCenterInfoJsByNameViewModel item in list)
			{
				int result2 = 0;
				int.TryParse(item.CId, out result2);
				if (result2 != 0 && result2 == userLastCId)
				{
					int.TryParse(item.PFId, out printFormatId);
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
	}

	public static string GetFromCIds(int formId)
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)cRMSpEntities.CRMspDySelectForms(formId, 0, lCID, result2, result3));
			if (cRMspDySelectForms_Result != null)
			{
				result = cRMspDySelectForms_Result.FormCIds ?? "";
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

	public static string GetFormCenterInfoJsByFormId(int formId)
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)cRMSpEntities.CRMspDySelectForms(formId, 0, lCID, result2, result3));
			if (cRMspDySelectForms_Result != null)
			{
				string cIds = cRMspDySelectForms_Result.FormCIds ?? "";
				result = GetFormCenterInfoJsByName(cRMspDySelectForms_Result.FormCenterInfoJs ?? "", cIds);
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
