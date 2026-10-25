using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Http;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO.FTP;
using CRM.General.Text;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class DyFormsController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspDySelectFormsMenuWithSysPartId_Result>> SelectFormsMenuWithSysPartId(int sysPartId, int foSysPartId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspDySelectFormsMenuWithSysPartId_Result> list = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					list = Enumerable.ToList<MobspDySelectFormsMenuWithSysPartId_Result>((IEnumerable<MobspDySelectFormsMenuWithSysPartId_Result>)cRMEntities.MobspDySelectFormsMenuWithSysPartId(sysPartId, foSysPartId, token2.userId, result, result2, cId));
					if (!VersionBuyer.MobDyForm)
					{
						list = Enumerable.ToList<MobspDySelectFormsMenuWithSysPartId_Result>(Enumerable.Take<MobspDySelectFormsMenuWithSysPartId_Result>((IEnumerable<MobspDySelectFormsMenuWithSysPartId_Result>)list, 2));
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspDySelectFormsMenuWithSysPartId_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspDySelectCompanyMasterValues_Result>> SelectCompanyMasterValues(int cmpId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspDySelectCompanyMasterValues_Result> list = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					list = Enumerable.ToList<MobspDySelectCompanyMasterValues_Result>((IEnumerable<MobspDySelectCompanyMasterValues_Result>)cRMEntities.MobspDySelectCompanyMasterValues(cmpId, token2.userId, result, result2, cId));
					if (!VersionBuyer.MobDyForm)
					{
						list = Enumerable.ToList<MobspDySelectCompanyMasterValues_Result>(Enumerable.Take<MobspDySelectCompanyMasterValues_Result>((IEnumerable<MobspDySelectCompanyMasterValues_Result>)list, 2));
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspDySelectCompanyMasterValues_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<LoadFullFormFieldValuesResultViewModel> LoadFullFormFieldValues(LoadFullFormFieldValuesViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		LoadFullFormFieldValuesResultViewModel loadFullFormFieldValuesResultViewModel = new LoadFullFormFieldValuesResultViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					List<MobspDySelectFormUserAccess_Result> list = Enumerable.ToList<MobspDySelectFormUserAccess_Result>((IEnumerable<MobspDySelectFormUserAccess_Result>)cRMEntities.MobspDySelectFormUserAccess(token2.userId, num, result2, model.CenterId));
					bool flag = true;
					if (Enumerable.Any<MobspDySelectFormUserAccess_Result>((IEnumerable<MobspDySelectFormUserAccess_Result>)list))
					{
						if (Enumerable.FirstOrDefault<MobspDySelectFormUserAccess_Result>((IEnumerable<MobspDySelectFormUserAccess_Result>)list, (Func<MobspDySelectFormUserAccess_Result, bool>)((MobspDySelectFormUserAccess_Result m) => m.FormId == model.FormId)) == null)
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
					if (!flag)
					{
						return new ServiceResult<LoadFullFormFieldValuesResultViewModel>
						{
							Message = Messages.NotAccessToPage,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					loadFullFormFieldValuesResultViewModel.Forms = new List<MobspDySelectFormAndSubForms_Result>();
					loadFullFormFieldValuesResultViewModel.FormFields = new List<MobspDySelectFormFieldsByParentFormId_Result>();
					loadFullFormFieldValuesResultViewModel.WorkflowSteps = new List<MobspDySelectFormWorkflowStepsForMasterValue_Result>();
					loadFullFormFieldValuesResultViewModel.FormFieldValues = new List<MobspDySelectFormFieldValuesByMasterValueId_Result>();
					loadFullFormFieldValuesResultViewModel.FormFiles = new List<MobspDySelectFilesDirectory_Result>();
					loadFullFormFieldValuesResultViewModel.FormFieldMasterValues = new List<MobspDySelectFormFieldMasterValues_Result>();
					List<MobspDySelectFormAndSubForms_Result> list2 = Enumerable.ToList<MobspDySelectFormAndSubForms_Result>((IEnumerable<MobspDySelectFormAndSubForms_Result>)cRMEntities.MobspDySelectFormAndSubForms(model.FormId, token2.userId, num, result2, model.CenterId));
					if (list2 != null && Enumerable.Any<MobspDySelectFormAndSubForms_Result>((IEnumerable<MobspDySelectFormAndSubForms_Result>)list2))
					{
						int result3 = 0;
						MobspDySelectFormAndSubForms_Result mobspDySelectFormAndSubForms_Result = Enumerable.FirstOrDefault<MobspDySelectFormAndSubForms_Result>((IEnumerable<MobspDySelectFormAndSubForms_Result>)list2, (Func<MobspDySelectFormAndSubForms_Result, bool>)((MobspDySelectFormAndSubForms_Result m) => m.ParentFormId == 0));
						if (mobspDySelectFormAndSubForms_Result != null)
						{
							int.TryParse(mobspDySelectFormAndSubForms_Result.WorkflowId.ToString(), out result3);
						}
						loadFullFormFieldValuesResultViewModel.MainForm = mobspDySelectFormAndSubForms_Result;
						loadFullFormFieldValuesResultViewModel.Forms = list2;
						List<MobspDySelectFormFieldsByParentFormId_Result> list3 = Enumerable.ToList<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)cRMEntities.MobspDySelectFormFieldsByParentFormId(model.FormId, num, result2));
						if (list3 != null && Enumerable.Any<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)list3))
						{
							loadFullFormFieldValuesResultViewModel.FormFields = list3;
						}
						MobspDySelectFormFieldMasterValueDetails_Result mobspDySelectFormFieldMasterValueDetails_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetails_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetails_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetails(model.FormId, model.CmpId, model.PrsId, model.PrjId, model.CnvsId, model.MObjId, model.DObjId, model.SubObjId, num, result2));
						if (mobspDySelectFormFieldMasterValueDetails_Result != null)
						{
							loadFullFormFieldValuesResultViewModel.MainFormDetails = mobspDySelectFormFieldMasterValueDetails_Result;
							loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsDate = (loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsDateTime.HasValue ? loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
							loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsDesc = "(" + loadFullFormFieldValuesResultViewModel.MainFormDetails.ConversationId + " - " + loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsTopic + " - " + loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsDate + ")";
							loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectDate = (loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectDateTime.HasValue ? loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectDateTime.Value.ToString("yyyy/MM/dd") : "");
							if (!string.IsNullOrEmpty(loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectDate))
							{
								loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectInfo = "(" + loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectInfo + " - " + loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectDate + ")";
							}
							else
							{
								loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectInfo = loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectInfo ?? "";
							}
						}
						else
						{
							loadFullFormFieldValuesResultViewModel.MainFormDetails = new MobspDySelectFormFieldMasterValueDetails_Result();
						}
						List<MobspDySelectFormFieldMasterValues_Result> list4 = Enumerable.ToList<MobspDySelectFormFieldMasterValues_Result>((IEnumerable<MobspDySelectFormFieldMasterValues_Result>)cRMEntities.MobspDySelectFormFieldMasterValues(model.FormId, (model.CmpId == 0) ? null : new int?(model.CmpId), (model.PrsId == 0) ? null : new int?(model.PrsId), (model.PrjId == 0) ? null : new int?(model.PrjId), (model.CnvsId == 0) ? null : new int?(model.CnvsId), (model.MObjId == 0) ? null : new int?(model.MObjId), (model.DObjId == 0) ? null : new int?(model.DObjId), (model.SubObjId == 0) ? null : new int?(model.SubObjId), num, result2, token2.userId, model.CenterId));
						if (list4 != null && Enumerable.Any<MobspDySelectFormFieldMasterValues_Result>((IEnumerable<MobspDySelectFormFieldMasterValues_Result>)list4))
						{
							if (!VersionBuyer.MobDyForm)
							{
								list4 = Enumerable.ToList<MobspDySelectFormFieldMasterValues_Result>(Enumerable.Take<MobspDySelectFormFieldMasterValues_Result>((IEnumerable<MobspDySelectFormFieldMasterValues_Result>)list4, 2));
							}
							loadFullFormFieldValuesResultViewModel.FormFieldMasterValues = list4;
							MobspDySelectFormFieldMasterValues_Result mobspDySelectFormFieldMasterValues_Result = ((model.MasterValueId <= 0) ? Enumerable.LastOrDefault<MobspDySelectFormFieldMasterValues_Result>((IEnumerable<MobspDySelectFormFieldMasterValues_Result>)list4) : list4.Find((MobspDySelectFormFieldMasterValues_Result c) => c.FormFieldMasterValueId == model.MasterValueId));
							int num2 = 0;
							if (mobspDySelectFormFieldMasterValues_Result != null)
							{
								num2 = mobspDySelectFormFieldMasterValues_Result.FormFieldMasterValueId;
							}
							if (DyForm.IsEditAfterFix(mobspDySelectFormFieldMasterValues_Result.EditAfterFixInfoJs, mobspDySelectFormFieldMasterValues_Result.FormFieldMasterValueId, 1, token2.userId))
							{
								mobspDySelectFormFieldMasterValues_Result.IsFixed = false;
							}
							loadFullFormFieldValuesResultViewModel.SelectedFormFieldMasterValue = mobspDySelectFormFieldMasterValues_Result;
							List<MobspDySelectFormWorkflowStepsForMasterValue_Result> list5 = Enumerable.ToList<MobspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<MobspDySelectFormWorkflowStepsForMasterValue_Result>)cRMEntities.MobspDySelectFormWorkflowStepsForMasterValue(result3, num2, num, result2, model.CenterId));
							if (list5 != null && Enumerable.Any<MobspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<MobspDySelectFormWorkflowStepsForMasterValue_Result>)list5))
							{
								loadFullFormFieldValuesResultViewModel.WorkflowSteps = list5;
							}
							if (num2 > 0)
							{
								List<MobspDySelectFormFieldValuesByMasterValueId_Result> list6 = Enumerable.ToList<MobspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<MobspDySelectFormFieldValuesByMasterValueId_Result>)cRMEntities.MobspDySelectFormFieldValuesByMasterValueId(num2, num, result2));
								if (list6 != null && Enumerable.Any<MobspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<MobspDySelectFormFieldValuesByMasterValueId_Result>)list6))
								{
									foreach (MobspDySelectFormFieldValuesByMasterValueId_Result item in list6)
									{
										if (item.FieldTypeId.GetValueOrDefault() == 13 && !string.IsNullOrWhiteSpace(item.Value))
										{
											byte[] array = BaseInfo.HexToByteArray(item.Value);
											item.ValueTitle = array.ToString();
										}
										item.Value = item.Value.Replace("''", "'");
									}
									loadFullFormFieldValuesResultViewModel.FormFieldValues = list6;
								}
							}
							if (num2 > 0)
							{
								List<MobspDySelectFilesDirectory_Result> list7 = Enumerable.ToList<MobspDySelectFilesDirectory_Result>((IEnumerable<MobspDySelectFilesDirectory_Result>)cRMEntities.MobspDySelectFilesDirectory(model.CmpId.ToString(), model.PrsId.ToString(), model.PrjId.ToString(), "60", num2.ToString(), "0", "", num, result2));
								if (list7 != null && Enumerable.Any<MobspDySelectFilesDirectory_Result>((IEnumerable<MobspDySelectFilesDirectory_Result>)list7))
								{
									loadFullFormFieldValuesResultViewModel.FormFiles = list7;
								}
							}
							if (mobspDySelectFormFieldMasterValues_Result != null)
							{
								loadFullFormFieldValuesResultViewModel.MainFormDetails = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetails_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetails_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetails(model.FormId, mobspDySelectFormFieldMasterValues_Result.CompanyId.GetValueOrDefault(), mobspDySelectFormFieldMasterValues_Result.CompanyPersonId.GetValueOrDefault(), mobspDySelectFormFieldMasterValues_Result.ProjectId.GetValueOrDefault(), mobspDySelectFormFieldMasterValues_Result.ConversationId.GetValueOrDefault(), mobspDySelectFormFieldMasterValues_Result.MasterObjectId.GetValueOrDefault(), mobspDySelectFormFieldMasterValues_Result.DetailObjectId.GetValueOrDefault(), mobspDySelectFormFieldMasterValues_Result.SubDetailObjectId.GetValueOrDefault(), num, result2));
								if (loadFullFormFieldValuesResultViewModel.MainFormDetails != null)
								{
									loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsDate = (loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsDateTime.HasValue ? loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
									loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsDesc = "(" + loadFullFormFieldValuesResultViewModel.MainFormDetails.ConversationId + " - " + loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsTopic + " - " + loadFullFormFieldValuesResultViewModel.MainFormDetails.cnvsDate + ")";
									loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectDate = (loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectDateTime.HasValue ? loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectDateTime.Value.ToString("yyyy/MM/dd") : "");
									if (!string.IsNullOrEmpty(loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectDate))
									{
										loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectInfo = "(" + loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectInfo + " - " + loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectDate + ")";
									}
									else
									{
										loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectInfo = loadFullFormFieldValuesResultViewModel.MainFormDetails.MasterObjectInfo ?? "";
									}
								}
								else
								{
									loadFullFormFieldValuesResultViewModel.MainFormDetails = new MobspDySelectFormFieldMasterValueDetails_Result();
								}
								if (mobspDySelectFormFieldMasterValues_Result.VerificationWorkFlowId.HasValue)
								{
									loadFullFormFieldValuesResultViewModel.LastVerificationStep = Enumerable.FirstOrDefault<MobspSelectVerificationWorkFlowStepLast_Result>((IEnumerable<MobspSelectVerificationWorkFlowStepLast_Result>)cRMEntities.MobspSelectVerificationWorkFlowStepLast(mobspDySelectFormFieldMasterValues_Result.FormFieldMasterValueId, 80, mobspDySelectFormFieldMasterValues_Result.VerificationWorkFlowId, 0, num, result2));
								}
							}
						}
						else
						{
							List<MobspDySelectFormWorkflowStepsForMasterValue_Result> list8 = Enumerable.ToList<MobspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<MobspDySelectFormWorkflowStepsForMasterValue_Result>)cRMEntities.MobspDySelectFormWorkflowStepsForMasterValue(result3, 0, num, result2, model.CenterId));
							if (list8 != null && Enumerable.Any<MobspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<MobspDySelectFormWorkflowStepsForMasterValue_Result>)list8))
							{
								loadFullFormFieldValuesResultViewModel.WorkflowSteps = list8;
							}
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					loadFullFormFieldValuesResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				loadFullFormFieldValuesResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			loadFullFormFieldValuesResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<LoadFullFormFieldValuesResultViewModel>
		{
			Message = message,
			Data = loadFullFormFieldValuesResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<LoadMasterValueDependencyResultViewModel> LoadMasterValueDependency(LoadMasterValueDependencyViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		LoadMasterValueDependencyResultViewModel loadMasterValueDependencyResultViewModel = new LoadMasterValueDependencyResultViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					loadMasterValueDependencyResultViewModel.WorkflowSteps = new List<MobspDySelectFormWorkflowStepsForMasterValue_Result>();
					loadMasterValueDependencyResultViewModel.FormFieldValues = new List<MobspDySelectFormFieldValuesByMasterValueId_Result>();
					loadMasterValueDependencyResultViewModel.FormFiles = new List<MobspDySelectFilesDirectory_Result>();
					loadMasterValueDependencyResultViewModel.FormFieldMasterValues = new List<MobspDySelectFormFieldMasterValues_Result>();
					List<MobspDySelectFormAndSubForms_Result> list = Enumerable.ToList<MobspDySelectFormAndSubForms_Result>((IEnumerable<MobspDySelectFormAndSubForms_Result>)cRMEntities.MobspDySelectFormAndSubForms(model.FormId, token2.userId, num, result2, model.CenterId));
					if (list != null && Enumerable.Any<MobspDySelectFormAndSubForms_Result>((IEnumerable<MobspDySelectFormAndSubForms_Result>)list))
					{
						MobspDySelectFormFieldMasterValueDetails_Result mobspDySelectFormFieldMasterValueDetails_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetails_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetails_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetails(model.FormId, model.CmpId, model.PrsId, model.PrjId, model.CnvsId, model.MObjId, model.DObjId, model.SubObjId, num, result2));
						if (mobspDySelectFormFieldMasterValueDetails_Result != null)
						{
							loadMasterValueDependencyResultViewModel.MainFormDetails = mobspDySelectFormFieldMasterValueDetails_Result;
							loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsDate = (loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsDateTime.HasValue ? loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
							loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsDesc = "(" + loadMasterValueDependencyResultViewModel.MainFormDetails.ConversationId + " - " + loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsTopic + " - " + loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsDate + ")";
							loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectDate = (loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectDateTime.HasValue ? loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectDateTime.Value.ToString("yyyy/MM/dd") : "");
							if (!string.IsNullOrEmpty(loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectDate))
							{
								loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectInfo = "(" + loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectInfo + " - " + loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectDate + ")";
							}
							else
							{
								loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectInfo = loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectInfo ?? "";
							}
						}
						else
						{
							loadMasterValueDependencyResultViewModel.MainFormDetails = new MobspDySelectFormFieldMasterValueDetails_Result();
						}
						List<MobspDySelectFormFieldMasterValues_Result> list2 = Enumerable.ToList<MobspDySelectFormFieldMasterValues_Result>((IEnumerable<MobspDySelectFormFieldMasterValues_Result>)cRMEntities.MobspDySelectFormFieldMasterValues(model.FormId, (model.CmpId == 0) ? null : new int?(model.CmpId), (model.PrsId == 0) ? null : new int?(model.PrsId), (model.PrjId == 0) ? null : new int?(model.PrjId), (model.CnvsId == 0) ? null : new int?(model.CnvsId), (model.MObjId == 0) ? null : new int?(model.MObjId), (model.DObjId == 0) ? null : new int?(model.DObjId), (model.SubObjId == 0) ? null : new int?(model.SubObjId), num, result2, token2.userId, model.CenterId));
						if (list2 != null && Enumerable.Any<MobspDySelectFormFieldMasterValues_Result>((IEnumerable<MobspDySelectFormFieldMasterValues_Result>)list2))
						{
							loadMasterValueDependencyResultViewModel.FormFieldMasterValues = list2;
							MobspDySelectFormFieldMasterValues_Result mobspDySelectFormFieldMasterValues_Result = new MobspDySelectFormFieldMasterValues_Result();
							mobspDySelectFormFieldMasterValues_Result = ((model.MasterValueId <= 0) ? Enumerable.LastOrDefault<MobspDySelectFormFieldMasterValues_Result>((IEnumerable<MobspDySelectFormFieldMasterValues_Result>)list2) : Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValues_Result>(Enumerable.Where<MobspDySelectFormFieldMasterValues_Result>((IEnumerable<MobspDySelectFormFieldMasterValues_Result>)list2, (Func<MobspDySelectFormFieldMasterValues_Result, bool>)((MobspDySelectFormFieldMasterValues_Result x) => x.FormFieldMasterValueId == model.MasterValueId))));
							if (DyForm.IsEditAfterFix(mobspDySelectFormFieldMasterValues_Result.EditAfterFixInfoJs, mobspDySelectFormFieldMasterValues_Result.FormFieldMasterValueId, 1, token2.userId))
							{
								mobspDySelectFormFieldMasterValues_Result.IsFixed = false;
							}
							loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue = mobspDySelectFormFieldMasterValues_Result;
							if (loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue != null)
							{
								int formFieldMasterValueId = loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue.FormFieldMasterValueId;
								int result3 = 0;
								MobspDySelectFormAndSubForms_Result mobspDySelectFormAndSubForms_Result = Enumerable.FirstOrDefault<MobspDySelectFormAndSubForms_Result>((IEnumerable<MobspDySelectFormAndSubForms_Result>)list, (Func<MobspDySelectFormAndSubForms_Result, bool>)((MobspDySelectFormAndSubForms_Result m) => m.ParentFormId == 0));
								if (mobspDySelectFormAndSubForms_Result != null)
								{
									int.TryParse(mobspDySelectFormAndSubForms_Result.WorkflowId.ToString(), out result3);
								}
								List<MobspDySelectFormWorkflowStepsForMasterValue_Result> list3 = Enumerable.ToList<MobspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<MobspDySelectFormWorkflowStepsForMasterValue_Result>)cRMEntities.MobspDySelectFormWorkflowStepsForMasterValue(result3, formFieldMasterValueId, num, result2, model.CenterId));
								if (list3 != null && Enumerable.Any<MobspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<MobspDySelectFormWorkflowStepsForMasterValue_Result>)list3))
								{
									loadMasterValueDependencyResultViewModel.WorkflowSteps = list3;
								}
								List<MobspDySelectFormFieldValuesByMasterValueId_Result> list4 = Enumerable.ToList<MobspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<MobspDySelectFormFieldValuesByMasterValueId_Result>)cRMEntities.MobspDySelectFormFieldValuesByMasterValueId(formFieldMasterValueId, num, result2));
								if (list4 != null && Enumerable.Any<MobspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<MobspDySelectFormFieldValuesByMasterValueId_Result>)list4))
								{
									loadMasterValueDependencyResultViewModel.FormFieldValues = list4;
								}
								List<MobspDySelectFilesDirectory_Result> list5 = Enumerable.ToList<MobspDySelectFilesDirectory_Result>((IEnumerable<MobspDySelectFilesDirectory_Result>)cRMEntities.MobspDySelectFilesDirectory(model.CmpId.ToString(), model.PrsId.ToString(), model.PrjId.ToString(), "60", formFieldMasterValueId.ToString(), "0", "", num, result2));
								if (list5 != null && Enumerable.Any<MobspDySelectFilesDirectory_Result>((IEnumerable<MobspDySelectFilesDirectory_Result>)list5))
								{
									loadMasterValueDependencyResultViewModel.FormFiles = list5;
								}
								loadMasterValueDependencyResultViewModel.MainFormDetails = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetails_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetails_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetails(model.FormId, loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue.CompanyId.GetValueOrDefault(), loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue.CompanyPersonId.GetValueOrDefault(), loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue.ProjectId.GetValueOrDefault(), loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue.ConversationId.GetValueOrDefault(), loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue.MasterObjectId.GetValueOrDefault(), loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue.DetailObjectId.GetValueOrDefault(), loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue.SubDetailObjectId.GetValueOrDefault(), num, result2));
								if (loadMasterValueDependencyResultViewModel.MainFormDetails != null)
								{
									loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsDate = (loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsDateTime.HasValue ? loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
									loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsDesc = "(" + loadMasterValueDependencyResultViewModel.MainFormDetails.ConversationId + " - " + loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsTopic + " - " + loadMasterValueDependencyResultViewModel.MainFormDetails.cnvsDate + ")";
									loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectDate = (loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectDateTime.HasValue ? loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectDateTime.Value.ToString("yyyy/MM/dd") : "");
									if (!string.IsNullOrEmpty(loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectDate))
									{
										loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectInfo = "(" + loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectInfo + " - " + loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectDate + ")";
									}
									else
									{
										loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectInfo = loadMasterValueDependencyResultViewModel.MainFormDetails.MasterObjectInfo ?? "";
									}
								}
								else
								{
									loadMasterValueDependencyResultViewModel.MainFormDetails = new MobspDySelectFormFieldMasterValueDetails_Result();
								}
								if (loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue.VerificationWorkFlowId.HasValue)
								{
									loadMasterValueDependencyResultViewModel.LastVerificationStep = Enumerable.FirstOrDefault<MobspSelectVerificationWorkFlowStepLast_Result>((IEnumerable<MobspSelectVerificationWorkFlowStepLast_Result>)cRMEntities.MobspSelectVerificationWorkFlowStepLast(loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue.FormFieldMasterValueId, 80, loadMasterValueDependencyResultViewModel.SelectedFormFieldMasterValue.VerificationWorkFlowId, 0, num, result2));
								}
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
							else
							{
								message = Messages.ErrorNotFound;
								loadMasterValueDependencyResultViewModel = null;
								status = ServiceResultStatus.Error;
							}
						}
						else if (model.MasterValueId > 0)
						{
							message = Messages.ErrorNotFound;
							loadMasterValueDependencyResultViewModel = null;
							status = ServiceResultStatus.Error;
						}
						else
						{
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						message = Messages.ErrorNotFound;
						loadMasterValueDependencyResultViewModel = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					loadMasterValueDependencyResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				loadMasterValueDependencyResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			loadMasterValueDependencyResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<LoadMasterValueDependencyResultViewModel>
		{
			Message = message,
			Data = loadMasterValueDependencyResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DySearchItemViewModel>> SearchUsers(string value, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DySearchItemViewModel> list = new List<DySearchItemViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					foreach (MobspDySearchUsers_Result item in Enumerable.ToList<MobspDySearchUsers_Result>((IEnumerable<MobspDySearchUsers_Result>)cRMEntities.MobspDySearchUsers(value ?? "", result, result2, cId)))
					{
						DySearchItemViewModel dySearchItemViewModel = new DySearchItemViewModel();
						int result3 = 0;
						int.TryParse(item.UserId.ToString(), out result3);
						dySearchItemViewModel.Id = result3;
						dySearchItemViewModel.Title = item.FullName ?? "";
						list.Add(dySearchItemViewModel);
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DySearchItemViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> InsertEditDyForm(InsertEditDyFormViewModel model)
	{
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_22e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_281e: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		string text = "";
		bool flag = false;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int currLangId = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(currLangId);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					string text2 = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(Financial.Get().Id.ToString());
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					int userId = token2.userId;
					int rollId = token2.RollId;
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					List<MobspDySelectFormFieldsByParentFormId_Result> list2 = new List<MobspDySelectFormFieldsByParentFormId_Result>();
					List<MobspDySelectFormAndSubForms_Result> list3 = new List<MobspDySelectFormAndSubForms_Result>();
					int result2 = 0;
					if (model.MasterValueId <= 0 && (!VersionBuyer.MobDyForm || !VersionBuyer.DyForm) && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspSelectFormFieldMasterValuesCnt(model.CenterId)).GetValueOrDefault() > 10)
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgSimpleVersionBuy,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					list3 = Enumerable.ToList<MobspDySelectFormAndSubForms_Result>((IEnumerable<MobspDySelectFormAndSubForms_Result>)cRMEntities.MobspDySelectFormAndSubForms(model.FormId, userId, currLangId, defLangId, model.CenterId));
					MobspDySelectFormAndSubForms_Result mobspDySelectFormAndSubForms_Result = new MobspDySelectFormAndSubForms_Result();
					if (list3 == null || !Enumerable.Any<MobspDySelectFormAndSubForms_Result>((IEnumerable<MobspDySelectFormAndSubForms_Result>)list3))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MsgFormNotDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					mobspDySelectFormAndSubForms_Result = Enumerable.FirstOrDefault<MobspDySelectFormAndSubForms_Result>((IEnumerable<MobspDySelectFormAndSubForms_Result>)list3, (Func<MobspDySelectFormAndSubForms_Result, bool>)((MobspDySelectFormAndSubForms_Result m) => m.FormId == model.FormId));
					if (mobspDySelectFormAndSubForms_Result == null)
					{
						return new ServiceResult<string>
						{
							Message = Messages.MsgFormNotDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					int.TryParse(mobspDySelectFormAndSubForms_Result.WorkflowId.ToString(), out result2);
					if (!string.IsNullOrEmpty(mobspDySelectFormAndSubForms_Result.FormName))
					{
						_ = mobspDySelectFormAndSubForms_Result.FormName;
					}
					if (mobspDySelectFormAndSubForms_Result.CrmSysPartId.GetValueOrDefault() == 1)
					{
						_ = 1;
					}
					else
						_ = mobspDySelectFormAndSubForms_Result.FOSysPartId.GetValueOrDefault() == 100;
					list2 = Enumerable.ToList<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)cRMEntities.MobspDySelectFormFieldsByParentFormId(model.FormId, currLangId, defLangId));
					List<IdKeyValueItemViewModel> list4 = new List<IdKeyValueItemViewModel>();
					new List<IdKeyValueItemViewModel>();
					if (!string.IsNullOrWhiteSpace(model.ValueDetails))
					{
						list4 = new JavaScriptSerializer().Deserialize<List<IdKeyValueItemViewModel>>(model.ValueDetails);
					}
					if (!string.IsNullOrWhiteSpace(model.ValueDetails_Lang))
					{
						new JavaScriptSerializer().Deserialize<List<IdKeyValueItemViewModel>>(model.ValueDetails_Lang);
					}
					if (DyForm.IsChecked(model.MasterValueId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.msgFormIsChecked,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (model.MasterValueId > 0 && model.MasterValueDetailId > 0)
					{
						int result3 = 0;
						int.TryParse(model.MasterValueDetailId.ToString(), out result3);
						if (DyForm.SubFormIsChecked(result3))
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgFormIsChecked,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
					}
					if (model.WdSubFormId > 0 && model.WorkflowStepId > 0)
					{
						MobspDySelectFormWorkflowStepWithId_Result mobspDySelectFormWorkflowStepWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepWithId_Result>((IEnumerable<MobspDySelectFormWorkflowStepWithId_Result>)cRMEntities.MobspDySelectFormWorkflowStepWithId(model.WorkflowStepId, currLangId, defLangId, model.CenterId));
						if (mobspDySelectFormWorkflowStepWithId_Result != null)
						{
							string text3 = mobspDySelectFormWorkflowStepWithId_Result.ReferUserIds ?? "";
							if (!string.IsNullOrEmpty(text3))
							{
								bool flag2 = false;
								string[] array = text3.Split(new char[1] { '|' });
								if (array != null)
								{
									string[] array2 = array;
									foreach (string text4 in array2)
									{
										if (!string.IsNullOrEmpty(text4) && int.Parse(text4) == userId)
										{
											flag2 = true;
											break;
										}
									}
								}
								if (!flag2 && !UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser, model.CenterId))
								{
									return new ServiceResult<string>
									{
										Message = string.Format(Messages.msgErrorYouNotDyFormReferUsers, mobspDySelectFormWorkflowStepWithId_Result.SubForm),
										Data = null,
										Status = ServiceResultStatus.Fail
									};
								}
							}
						}
					}
					else if (result2 > 0 && mobspDySelectFormAndSubForms_Result != null)
					{
						bool flag3 = false;
						int? enableForRollId = mobspDySelectFormAndSubForms_Result.EnableForRollId;
						string text5 = mobspDySelectFormAndSubForms_Result.EnableForUsersId ?? "";
						if (enableForRollId.HasValue)
						{
							flag3 = enableForRollId == rollId;
						}
						else if (!string.IsNullOrEmpty(text5))
						{
							string[] array3 = text5.Split(new char[1] { '|' });
							if (array3 != null)
							{
								string[] array2 = array3;
								foreach (string text6 in array2)
								{
									if (!string.IsNullOrEmpty(text6) && int.Parse(text6) == userId)
									{
										flag3 = true;
										break;
									}
								}
							}
						}
						else
						{
							flag3 = true;
						}
						if (!flag3 && !UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser, model.CenterId))
						{
							return new ServiceResult<string>
							{
								Message = string.Format(Messages.msgErrorYouNotDyFormReferUsers, mobspDySelectFormAndSubForms_Result.FormName ?? ""),
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
					}
					int result4 = 0;
					MobspDySelectFormFieldMasterValueWithId_Result mobspDySelectFormFieldMasterValueWithId_Result = new MobspDySelectFormFieldMasterValueWithId_Result();
					bool flag4 = false;
					if (model.MasterValueId > 0)
					{
						mobspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(model.MasterValueId, currLangId, defLangId));
					}
					if (!UserLogin.IsUserAccess("frmDyForm", "actCanEditDyFormNumber", UserLogin.CurrentUser, model.CenterId))
					{
						model.DyFormNumber = null;
					}
					if (mobspDySelectFormFieldMasterValueWithId_Result.FormFieldMasterValueId > 0)
					{
						if (model.DyFormNumber.HasValue && Enumerable.FirstOrDefault<MobspDyCheckDuplicateDyFormNumber_Result>((IEnumerable<MobspDyCheckDuplicateDyFormNumber_Result>)cRMEntities.MobspDyCheckDuplicateDyFormNumber(model.DyFormNumber.GetValueOrDefault(), mobspDySelectFormFieldMasterValueWithId_Result.FormFieldMasterValueId, model.FormId, model.CenterId)) != null)
						{
							return new ServiceResult<string>
							{
								Message = Messages.DyFormNumberIsRepeated,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						result4 = mobspDySelectFormFieldMasterValueWithId_Result.FormFieldMasterValueId;
						if (!model.WdSubFormId.HasValue && !model.WorkflowStepId.HasValue)
						{
							cRMEntities.MobspDyUpdateFormFieldMasterValues(result4, model.DyFormNumber, userId, now, text2, value, value2, appType);
						}
						if (result2 == 0)
						{
							cRMEntities.MobspDyInsertUpdateFormFieldMasterValueDetails(2, result4, model.FormId, userId, now, text2, value, value2, appType, defLangId, model.CenterId);
						}
					}
					else
					{
						flag4 = true;
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.MobspDyInsertFormFieldMasterValues(model.FormId, model.CompanyId, model.CompanyPersonId, model.ProjectId, model.ConversationId, model.MasterObjectId, model.DetailObjectId, model.SubDetailObjectId, (result2 > 0) ? new int?(result2) : null, model.WorkflowStepId, userId, now, text2, value, value2, appType, defLangId, VersionConfig.CurrentDyFormFieldMasterValuesTableVersion, model.CenterId));
						if (mct_Result != null)
						{
							int.TryParse(mct_Result.Result.ToString(), out result4);
						}
						if (result2 == 0 && result4 > 0)
						{
							cRMEntities.MobspDyInsertUpdateFormFieldMasterValueDetails(1, result4, model.FormId, userId, now, text2, value, value2, appType, defLangId, model.CenterId);
						}
					}
					List<MobspDySelectFormFieldValuesByMasterValueId_Result> list5 = new List<MobspDySelectFormFieldValuesByMasterValueId_Result>();
					if (result4 > 0)
					{
						list5 = Enumerable.ToList<MobspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<MobspDySelectFormFieldValuesByMasterValueId_Result>)cRMEntities.MobspDySelectFormFieldValuesByMasterValueId(result4, currLangId, defLangId));
					}
					if (list2 != null && Enumerable.Any<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)list2))
					{
						string text7 = "";
						int num = 0;
						List<MobspDySelectFormFieldsByParentFormId_Result> list6 = new List<MobspDySelectFormFieldsByParentFormId_Result>();
						if (!(model.WdSubFormId > 0) || !(model.WorkflowStepId > 0))
						{
							list6 = ((result2 <= 0) ? Enumerable.ToList<MobspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)list2, (Func<MobspDySelectFormFieldsByParentFormId_Result, bool>)((MobspDySelectFormFieldsByParentFormId_Result m) => m.IsRequired.GetValueOrDefault()))) : Enumerable.ToList<MobspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)list2, (Func<MobspDySelectFormFieldsByParentFormId_Result, bool>)((MobspDySelectFormFieldsByParentFormId_Result m) => m.FormId == model.FormId && m.IsRequired.GetValueOrDefault()))));
						}
						else
						{
							MobspDySelectFormWorkflowStepBFCurr_Result wdetail = Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepBFCurr_Result>((IEnumerable<MobspDySelectFormWorkflowStepBFCurr_Result>)cRMEntities.MobspDySelectFormWorkflowStepBFCurr(result2, model.WorkflowStepId, result4, model.WdSubFormId, currLangId, defLangId));
							list6 = ((wdetail == null) ? Enumerable.ToList<MobspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)list2, (Func<MobspDySelectFormFieldsByParentFormId_Result, bool>)((MobspDySelectFormFieldsByParentFormId_Result m) => m.FormId == model.WdSubFormId && m.IsRequired.GetValueOrDefault()))) : Enumerable.ToList<MobspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)list2, (Func<MobspDySelectFormFieldsByParentFormId_Result, bool>)((MobspDySelectFormFieldsByParentFormId_Result m) => m.FormId == wdetail.SubFormId && m.IsRequired.GetValueOrDefault()))));
						}
						if (list6 != null && Enumerable.Any<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)list6))
						{
							foreach (IdKeyValueItemViewModel item3 in list4)
							{
								string text8 = item3.Id ?? "";
								int formId2 = 0;
								int fieldId2 = 0;
								if (text8 != "")
								{
									text8 = text8.Replace("_Rep", "");
									string[] array4 = text8.Split(new char[1] { '_' });
									if (array4 != null)
									{
										formId2 = int.Parse(array4[0]);
										fieldId2 = int.Parse(array4[1]);
										if (array4.Length > 2)
										{
											long.Parse(array4[2]);
										}
									}
								}
								MobspDySelectFormFieldsByParentFormId_Result mobspDySelectFormFieldsByParentFormId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)list6, (Func<MobspDySelectFormFieldsByParentFormId_Result, bool>)((MobspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == fieldId2));
								if (mobspDySelectFormFieldsByParentFormId_Result == null)
								{
									continue;
								}
								if (result2 == 0)
								{
									MobspDySelectFormAndSubForms_Result mobspDySelectFormAndSubForms_Result2 = Enumerable.FirstOrDefault<MobspDySelectFormAndSubForms_Result>((IEnumerable<MobspDySelectFormAndSubForms_Result>)list3, (Func<MobspDySelectFormAndSubForms_Result, bool>)((MobspDySelectFormAndSubForms_Result m) => m.FormId == formId2));
									if (mobspDySelectFormAndSubForms_Result2 != null)
									{
										bool flag5 = true;
										bool flag6 = false;
										if (mobspDySelectFormAndSubForms_Result2.EnableForRollId.HasValue)
										{
											flag5 = mobspDySelectFormAndSubForms_Result2.EnableForRollId == rollId || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser, model.CenterId);
										}
										else if (!string.IsNullOrEmpty(mobspDySelectFormAndSubForms_Result2.EnableForUsersId))
										{
											string[] array5 = mobspDySelectFormAndSubForms_Result2.EnableForUsersId.Split(new char[1] { '|' });
											if (Enumerable.Any<string>((IEnumerable<string>)array5))
											{
												foreach (string item4 in Enumerable.Where<string>((IEnumerable<string>)array5, (Func<string, bool>)((string usr) => !string.IsNullOrEmpty(usr))))
												{
													if (!flag6)
													{
														if (item4 == userId.ToString() || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser, model.CenterId))
														{
															flag5 = true;
															flag6 = true;
														}
														else
														{
															flag5 = false;
														}
													}
												}
											}
										}
										if (!flag5)
										{
											continue;
										}
									}
								}
								MobspDySelectFormFieldsByParentFormId_Result mobspDySelectFormFieldsByParentFormId_Result2 = Enumerable.FirstOrDefault<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)list2, (Func<MobspDySelectFormFieldsByParentFormId_Result, bool>)((MobspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == fieldId2));
								if (mobspDySelectFormFieldsByParentFormId_Result2 != null && !string.IsNullOrWhiteSpace(item3.Value) && mobspDySelectFormFieldsByParentFormId_Result2.FieldTypeId.GetValueOrDefault() == 4)
								{
									item3.Value = item3.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
										.Replace(" ", "")
										.Replace("_", "");
									string formatetdDate = PersianDate.GetFormatetdDate(item3.Value.Replace("/", ""));
									if (currLangId == 1065)
									{
										item3.Value = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd");
									}
									else if (currLangId == 1025)
									{
										item3.Value = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture());
									}
									else
									{
										item3.Value = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture());
									}
								}
								List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
								foreach (MobspSelectLanguages_Result item5 in Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)list, (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result c) => c.LanguageID != currLangId))))
								{
									string text9 = "";
									if (mobspDySelectFormFieldsByParentFormId_Result2 != null)
									{
										text9 = item3.Value;
										list7.Add(new CommonMultiLanguageViewModel
										{
											Value = text9,
											LanguageId = item5.LanguageID
										});
									}
								}
								list7.Add(new CommonMultiLanguageViewModel
								{
									Value = item3.Value,
									LanguageId = currLangId
								});
								if (string.IsNullOrEmpty((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangId)).Value : null))
								{
									text7 = text7 + string.Format(Messages.ErrorEmpty, mobspDySelectFormFieldsByParentFormId_Result.FieldTitle ?? "") + "<br/>";
									num++;
								}
							}
							if (num > 0)
							{
								if (flag4)
								{
									try
									{
										Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDyDeleteFormFieldMasterValue(result4));
									}
									catch (Exception e)
									{
										ErrorSignal.FromCurrentContext().Raise(e);
									}
								}
								return new ServiceResult<string>
								{
									Message = text7,
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
						}
					}
					bool flag7 = false;
					int num2 = 0;
					string mainFormReferUserIs = "";
					if (result4 > 0 && result2 > 0)
					{
						bool flag8 = false;
						MobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result mobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result = new MobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result();
						mobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId(model.FormId, result4));
						if (mobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result != null)
						{
							if (!model.WdSubFormId.HasValue && !model.WorkflowStepId.HasValue)
							{
								cRMEntities.MobspDyUpdateFormFieldMasterValueDetails(mobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result.FormFieldMasterValueDetailId, userId, now, text2, value, value2, appType);
							}
						}
						else
						{
							flag8 = true;
							mct_Result mct_Result2 = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.MobspDyInsertFormFieldMasterValueDetails(result4, model.FormId, userId, now, text2, value, value2, appType, defLangId));
							if (mct_Result2 != null)
							{
								int result5 = 0;
								int.TryParse(mct_Result2.Result.ToString(), out result5);
							}
							MobspDySelectFormWorkflowStepsForMasterValue_Result mobspDySelectFormWorkflowStepsForMasterValue_Result = Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<MobspDySelectFormWorkflowStepsForMasterValue_Result>)cRMEntities.MobspDySelectFormWorkflowStepsForMasterValue(result2, result4, currLangId, defLangId, model.CenterId));
							if (mobspDySelectFormWorkflowStepsForMasterValue_Result != null)
							{
								num2 = mobspDySelectFormWorkflowStepsForMasterValue_Result.FormWorkflowStepId;
							}
							mainFormReferUserIs = mobspDySelectFormAndSubForms_Result.ReferUserIds ?? "";
						}
						if (model.WdSubFormId > 0 && model.WorkflowStepId > 0)
						{
							MobspDySelectFormWorkflowStepBFCurr_Result mobspDySelectFormWorkflowStepBFCurr_Result = Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepBFCurr_Result>((IEnumerable<MobspDySelectFormWorkflowStepBFCurr_Result>)cRMEntities.MobspDySelectFormWorkflowStepBFCurr(result2, model.WorkflowStepId, result4, model.WdSubFormId, currLangId, defLangId));
							if (mobspDySelectFormWorkflowStepBFCurr_Result != null)
							{
								if (flag8)
								{
									try
									{
										cRMEntities.MobspDyDeleteFormFieldMasterValue(result4);
									}
									catch (Exception e2)
									{
										ErrorSignal.FromCurrentContext().Raise(e2);
									}
								}
								return new ServiceResult<string>
								{
									Message = string.Format(Messages.msgErrorCheckFormWorkflowDetailBFCurr, mobspDySelectFormWorkflowStepBFCurr_Result.WorkflowStepTitle ?? "") + "<br>",
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
							MobspDySelectFormFieldMasterValueDetailWithId_Result mobspDySelectFormFieldMasterValueDetailWithId_Result = new MobspDySelectFormFieldMasterValueDetailWithId_Result();
							mobspDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetailWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetailWithId(model.MasterValueDetailId, currLangId, defLangId));
							if (mobspDySelectFormFieldMasterValueDetailWithId_Result != null)
							{
								cRMEntities.MobspDyUpdateFormFieldMasterValueDetails(mobspDySelectFormFieldMasterValueDetailWithId_Result.FormFieldMasterValueDetailId, userId, now, text2, value, value2, appType);
							}
							else
							{
								flag7 = true;
								mct_Result mct_Result3 = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.MobspDyInsertFormFieldMasterValueDetails(result4, model.WdSubFormId.GetValueOrDefault(), userId, now, text2, value, value2, appType, defLangId));
								if (mct_Result3 == null)
								{
									return new ServiceResult<string>
									{
										Message = Messages.msgErrorRunFunction,
										Data = null,
										Status = ServiceResultStatus.Fail
									};
								}
								int result6 = 0;
								int.TryParse(mct_Result3.Result.ToString(), out result6);
								model.MasterValueDetailId = result6;
							}
						}
					}
					List<MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result> list8 = Enumerable.ToList<MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>((IEnumerable<MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>)cRMEntities.MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs(3, userId, -65, null, model.FormId, null));
					List<FieldValueViewModel> list9 = new List<FieldValueViewModel>();
					List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
					foreach (IdKeyValueItemViewModel item6 in list4)
					{
						string text10 = item6.Id ?? "";
						int formId = 0;
						int fieldId = 0;
						long fieldRepeatId = 0L;
						if (text10 != "")
						{
							text10 = text10.Replace("_Rep", "");
							string[] array6 = text10.Split(new char[1] { '_' });
							if (array6 != null)
							{
								formId = int.Parse(array6[0]);
								fieldId = int.Parse(array6[1]);
								if (array6.Length > 2)
								{
									fieldRepeatId = long.Parse(array6[2]);
								}
							}
						}
						MobspDySelectFormFieldsByParentFormId_Result mobspDySelectFormFieldsByParentFormId_Result3 = Enumerable.FirstOrDefault<MobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<MobspDySelectFormFieldsByParentFormId_Result>)list2, (Func<MobspDySelectFormFieldsByParentFormId_Result, bool>)((MobspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == fieldId));
						if (mobspDySelectFormFieldsByParentFormId_Result3 != null && !string.IsNullOrEmpty(item6.Value) && mobspDySelectFormFieldsByParentFormId_Result3.FieldTypeId.GetValueOrDefault() == 4)
						{
							item6.Value = item6.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							string formatetdDate2 = PersianDate.GetFormatetdDate(item6.Value.Replace("/", ""));
							if (currLangId == 1065)
							{
								item6.Value = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd");
							}
							else if (currLangId == 1025)
							{
								item6.Value = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture());
							}
							else
							{
								item6.Value = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture());
							}
						}
						if (mobspDySelectFormFieldsByParentFormId_Result3 != null && list8 != null && Enumerable.Any<MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>((IEnumerable<MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>)list8) && !string.IsNullOrWhiteSpace(item6.Value) && mobspDySelectFormFieldsByParentFormId_Result3.FieldTypeId.GetValueOrDefault() == 12)
						{
							int fileDirectoryTemplateId = 0;
							int.TryParse(item6.Value, out fileDirectoryTemplateId);
							MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result mobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result = Enumerable.FirstOrDefault<MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>((IEnumerable<MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>)list8, (Func<MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result, bool>)((MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result m) => m.FileDirectoryTemplateID == fileDirectoryTemplateId));
							if (mobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result != null)
							{
								string docTime = now.ToString("HH:mm:ss");
								int result7 = 0;
								FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
								string text11 = "";
								text11 = (model.CompanyId.HasValue ? model.CompanyId.ToString() : (Mobile.Classes.Configuration.DyDirectoryPath + model.FormId));
								string folderName = (model.CompanyId.HasValue ? model.CompanyId.ToString() : model.FormId.ToString());
								string title = mobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result.Title;
								string title_Lang = "";
								List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
								foreach (MobspSelectLanguages_Result item7 in Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)list, (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result c) => c.LanguageID != defLangId))))
								{
									list11.Add(new CommonMultiLanguageViewModel
									{
										Value = title,
										LanguageId = item7.LanguageID
									});
								}
								if (list11 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11))
								{
									title_Lang = JsonConvert.SerializeObject(list11);
								}
								MobspInsertFilesDirectory_Result mobspInsertFilesDirectory_Result = Enumerable.FirstOrDefault<MobspInsertFilesDirectory_Result>((IEnumerable<MobspInsertFilesDirectory_Result>)cRMEntities.MobspInsertFilesDirectory(0, -65, model.CompanyId, model.CompanyPersonId, model.ProjectId, title, title_Lang, folderName, "", "", "", userId, value, value2, now, text2, now, text2, PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime, result4, appType, defLangId, null, formId, fieldId, "", null, null, model.CenterId));
								if (mobspInsertFilesDirectory_Result != null)
								{
									int.TryParse(mobspInsertFilesDirectory_Result.FileId.ToString(), out result7);
								}
								if (result7 > 0)
								{
									string pathFtp = Mobile.Classes.Configuration.PathFtp;
									string userNameFtp = Mobile.Classes.Configuration.UserNameFtp;
									string passwordFtp = Mobile.Classes.Configuration.PasswordFtp;
									bool usePassiveFtp = Mobile.Classes.Configuration.UsePassiveFtp;
									string[] array7 = title.Split(new char[1] { '.' });
									string text12 = Mobile.Classes.Configuration.MainDirectoryPath + text11 + "/";
									string text13 = text12 + (text12.EndsWith("/") ? "" : "/");
									string text14 = text13.Split(new char[1] { '/' })[^2];
									string destination = text13.Replace(text14 + "/", "");
									bool flag9 = false;
									if (!model.CompanyId.HasValue)
									{
										flag9 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Mobile.Classes.Configuration.MainDirectoryPath, Mobile.Classes.Configuration.DyDirectoryPath, usePassiveFtp);
										if (!flag9)
										{
											flag9 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Mobile.Classes.Configuration.MainDirectoryPath, Mobile.Classes.Configuration.DyDirectoryPath, usePassiveFtp);
										}
									}
									else
									{
										flag9 = true;
									}
									bool flag10 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, destination, text14, usePassiveFtp);
									if (!flag10)
									{
										flag10 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, destination, text14, usePassiveFtp);
									}
									if (flag10 && flag9)
									{
										string text15 = "";
										int num3 = result4;
										text15 = num3 + "-" + result7 + "." + array7[^1];
										string text16 = "";
										string copyFromPath = mobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result.CopyFromPath;
										text = mobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result.CopyFromPath;
										if (!string.IsNullOrWhiteSpace(copyFromPath))
										{
											facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text13 + text15, copyFromPath, usePassiveFtp);
											text12 = pathFtp + text13 + text15;
											text16 = text15;
											text12 = text12.Trim().Replace(pathFtp, "");
											Enumerable.FirstOrDefault<MobspInsertFilesDirectory_Result>((IEnumerable<MobspInsertFilesDirectory_Result>)cRMEntities.MobspInsertFilesDirectory(result7, -65, model.CompanyId, model.CompanyPersonId, model.ProjectId, title, title_Lang, folderName, text16, text12, "", userId, value, value2, now, text2, now, text2, PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime, result4, appType, defLangId, null, formId, fieldId, "", null, null, model.CenterId));
											item6.Value = result7.ToString();
											flag = true;
											int result8 = 0;
											int.TryParse(mobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result.FileDirectoryTemplateID.ToString(), out result8);
											cRMSpEntities.MobspDeleteFilesDirectoryTemplate(result8);
										}
										else
										{
											try
											{
												cRMEntities.MobspDeleteCrmFilesDirectory(result7);
											}
											catch (Exception e3)
											{
												ErrorSignal.FromCurrentContext().Raise(e3);
											}
											item6.Value = "";
										}
									}
									else
									{
										try
										{
											cRMEntities.MobspDeleteCrmFilesDirectory(result7);
										}
										catch (Exception e4)
										{
											ErrorSignal.FromCurrentContext().Raise(e4);
										}
										item6.Value = "";
									}
								}
								else
								{
									item6.Value = "";
								}
							}
						}
						List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
						foreach (MobspSelectLanguages_Result item8 in Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)list, (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result c) => c.LanguageID != currLangId))))
						{
							string text17 = "";
							if (mobspDySelectFormFieldsByParentFormId_Result3 != null)
							{
								text17 = item6.Value;
								list12.Add(new CommonMultiLanguageViewModel
								{
									Value = text17,
									LanguageId = item8.LanguageID
								});
							}
						}
						list12.Add(new CommonMultiLanguageViewModel
						{
							Value = item6.Value,
							LanguageId = currLangId
						});
						if (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangId)) != null)
						{
							_ = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangId)).Value;
						}
						if (result4 <= 0)
						{
							continue;
						}
						string value3 = "";
						if (list5 != null && list5.Count > 0)
						{
							MobspDySelectFormFieldValuesByMasterValueId_Result val = Enumerable.FirstOrDefault<MobspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<MobspDySelectFormFieldValuesByMasterValueId_Result>)list5, (Func<MobspDySelectFormFieldValuesByMasterValueId_Result, bool>)((MobspDySelectFormFieldValuesByMasterValueId_Result m) => m.FormId == formId && m.FieldId == fieldId && m.FieldRepeatId.GetValueOrDefault() == fieldRepeatId));
							if (val != null)
							{
								MobspDySelectFormAndSubForms_Result mobspDySelectFormAndSubForms_Result3 = Enumerable.FirstOrDefault<MobspDySelectFormAndSubForms_Result>((IEnumerable<MobspDySelectFormAndSubForms_Result>)list3, (Func<MobspDySelectFormAndSubForms_Result, bool>)((MobspDySelectFormAndSubForms_Result m) => m.FormId == val.FormId));
								if (mobspDySelectFormAndSubForms_Result3 != null)
								{
									bool flag11 = true;
									bool flag12 = false;
									if (result2 == 0 || (model.WorkflowStepId.GetValueOrDefault() == 0 && model.WdSubFormId.GetValueOrDefault() == 0 && model.FormId == mobspDySelectFormAndSubForms_Result3.FormId))
									{
										if (mobspDySelectFormAndSubForms_Result3.EnableForRollId.HasValue)
										{
											flag11 = mobspDySelectFormAndSubForms_Result3.EnableForRollId == rollId || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser, model.CenterId);
										}
										else if (!string.IsNullOrWhiteSpace(mobspDySelectFormAndSubForms_Result3.EnableForUsersId))
										{
											string[] array8 = mobspDySelectFormAndSubForms_Result3.EnableForUsersId.Split(new char[1] { '|' });
											if (Enumerable.Any<string>((IEnumerable<string>)array8))
											{
												foreach (string item9 in Enumerable.Where<string>((IEnumerable<string>)array8, (Func<string, bool>)((string usr) => !string.IsNullOrEmpty(usr))))
												{
													if (!flag12)
													{
														if (item9 == UserLogin.CurrentUser.UserId.ToString() || UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser, model.CenterId))
														{
															flag11 = true;
															flag12 = true;
														}
														else
														{
															flag11 = false;
														}
													}
												}
											}
										}
									}
									else if (model.WorkflowStepId > 0 && model.WdSubFormId > 0 && model.WdSubFormId == mobspDySelectFormAndSubForms_Result3.FormId)
									{
										MobspDySelectFormWorkflowStepWithId_Result mobspDySelectFormWorkflowStepWithId_Result2 = Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepWithId_Result>((IEnumerable<MobspDySelectFormWorkflowStepWithId_Result>)cRMEntities.MobspDySelectFormWorkflowStepWithId(model.WorkflowStepId, currLangId, defLangId, model.CenterId));
										if (mobspDySelectFormWorkflowStepWithId_Result2 != null)
										{
											string text18 = mobspDySelectFormWorkflowStepWithId_Result2.ReferUserIds ?? "";
											if (!string.IsNullOrEmpty(text18))
											{
												bool flag13 = false;
												string[] array9 = text18.Split(new char[1] { '|' });
												if (array9 != null)
												{
													string[] array2 = array9;
													foreach (string text19 in array2)
													{
														if (!string.IsNullOrEmpty(text19) && int.Parse(text19) == userId)
														{
															flag13 = true;
															break;
														}
													}
												}
												if (!flag13 && !UserLogin.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", UserLogin.CurrentUser, model.CenterId))
												{
													flag11 = false;
												}
											}
										}
									}
									else
									{
										flag11 = false;
									}
									if (!flag11)
									{
										List<CommonMultiLanguageViewModel> list13 = new List<CommonMultiLanguageViewModel>();
										list13.Add(new CommonMultiLanguageViewModel
										{
											Value = (val.Value ?? ""),
											LanguageId = currLangId
										});
										if (!string.IsNullOrWhiteSpace(val.Value_Lang))
										{
											List<CommonMultiLanguageViewModel> collection = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(val.Value_Lang);
											list13.AddRange(collection);
										}
										List<CommonMultiLanguageViewModel> list14 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId)));
										if (list14 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14))
										{
											JsonConvert.SerializeObject(list14);
										}
										value3 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
									}
									else
									{
										List<CommonMultiLanguageViewModel> list15 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId)));
										if (list15 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15))
										{
											JsonConvert.SerializeObject(list15);
										}
										value3 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
									}
								}
							}
							else
							{
								List<CommonMultiLanguageViewModel> list16 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId)));
								if (list16 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16))
								{
									JsonConvert.SerializeObject(list16);
								}
								value3 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
							}
						}
						else
						{
							List<CommonMultiLanguageViewModel> list17 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId)));
							if (list17 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17))
							{
								JsonConvert.SerializeObject(list17);
							}
							value3 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						}
						FieldValueViewModel item = new FieldValueViewModel
						{
							FormId = formId,
							FieldId = fieldId,
							FieldRepeatId = fieldRepeatId,
							Value = CRM.General.Text.String.CleanString(value3, allTrue: true)
						};
						list9.Add(item);
						new List<CommonMultiLanguageViewModel>();
						if (list12 == null || !Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12))
						{
							continue;
						}
						foreach (MobspSelectLanguages_Result lang2 in Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)list, (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result c) => c.LanguageID != defLangId))))
						{
							CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
							commonMultiLanguageViewModel.LanguageId = lang2.LanguageID;
							FieldValueViewModel value4 = new FieldValueViewModel
							{
								FormId = formId,
								FieldId = fieldId,
								FieldRepeatId = fieldRepeatId,
								Value = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) != null) ? CRM.General.Text.String.CleanString(Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value, allTrue: true) : "")
							};
							commonMultiLanguageViewModel.Value = JsonConvert.SerializeObject(value4);
							list10.Add(commonMultiLanguageViewModel);
						}
					}
					string value5 = "";
					string valueLang = "";
					if (list9 != null && Enumerable.Any<FieldValueViewModel>((IEnumerable<FieldValueViewModel>)list9))
					{
						value5 = JsonConvert.SerializeObject(Enumerable.ToList<FieldValueViewModel>((IEnumerable<FieldValueViewModel>)list9));
					}
					if (list10 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10))
					{
						List<CommonMultiLanguageViewModel> list18 = new List<CommonMultiLanguageViewModel>();
						foreach (MobspSelectLanguages_Result lang in Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)list, (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result c) => c.LanguageID != defLangId))))
						{
							CommonMultiLanguageViewModel commonMultiLanguageViewModel2 = new CommonMultiLanguageViewModel();
							commonMultiLanguageViewModel2.LanguageId = lang.LanguageID;
							List<FieldValueViewModel> list19 = new List<FieldValueViewModel>();
							List<CommonMultiLanguageViewModel> list20 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == lang.LanguageID)));
							if (list20 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list20))
							{
								foreach (CommonMultiLanguageViewModel item10 in list20)
								{
									if (!string.IsNullOrWhiteSpace(item10.Value))
									{
										FieldValueViewModel fieldValueViewModel = new JavaScriptSerializer().Deserialize<FieldValueViewModel>(item10.Value);
										if (fieldValueViewModel != null)
										{
											FieldValueViewModel item2 = new FieldValueViewModel
											{
												FormId = fieldValueViewModel.FormId,
												FieldId = fieldValueViewModel.FieldId,
												FieldRepeatId = fieldValueViewModel.FieldRepeatId,
												Value = fieldValueViewModel.Value
											};
											list19.Add(item2);
										}
									}
								}
							}
							commonMultiLanguageViewModel2.Value = JsonConvert.SerializeObject(Enumerable.ToList<FieldValueViewModel>((IEnumerable<FieldValueViewModel>)list19));
							list18.Add(commonMultiLanguageViewModel2);
						}
						valueLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18));
					}
					if (list5 != null && Enumerable.Any<MobspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<MobspDySelectFormFieldValuesByMasterValueId_Result>)list5))
					{
						int result9 = 0;
						MobspDySelectFormFieldValuesByMasterValueId_Result mobspDySelectFormFieldValuesByMasterValueId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<MobspDySelectFormFieldValuesByMasterValueId_Result>)list5);
						if (mobspDySelectFormFieldValuesByMasterValueId_Result != null)
						{
							int.TryParse(mobspDySelectFormFieldValuesByMasterValueId_Result.FormFieldValueId.ToString(), out result9);
						}
						mct_Result mct_Result4 = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.MobspDyUpdateFormFieldValues(result9, value5, valueLang, userId, now, text2, value, value2, appType, defLangId));
						int result10 = 0;
						if (mct_Result4 != null)
						{
							int.TryParse(mct_Result4.Result.ToString(), out result10);
						}
						if (result10 <= 0)
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorInSaveInfo,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
					}
					else
					{
						mct_Result mct_Result5 = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.MobspDyInsertFormFieldValues(result4, model.FormId, null, model.CompanyId, model.CompanyPersonId, model.ProjectId, model.ConversationId, model.MasterObjectId, model.DetailObjectId, model.SubDetailObjectId, value5, valueLang, userId, now, text2, value, value2, appType, defLangId));
						int result11 = 0;
						if (mct_Result5 != null)
						{
							int.TryParse(mct_Result5.Result.ToString(), out result11);
						}
						if (result11 <= 0)
						{
							cRMEntities.MobspDyDeleteFormFieldMasterValue(result4);
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorInSaveInfo,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
					}
					message = ((list5 == null || list5.Count <= 0 || result4 <= 0) ? Messages.frmFormBaseInsertSuccessFulMessage : Messages.frmFormBaseEditSuccessFulMessage);
					model.MasterValueId = result4;
					data = result4.ToString();
					status = ServiceResultStatus.Success;
					if (flag7 || num2 > 0)
					{
						MobspDySelectFormWorkflowStepWithId_Result mobspDySelectFormWorkflowStepWithId_Result3 = new MobspDySelectFormWorkflowStepWithId_Result();
						mobspDySelectFormWorkflowStepWithId_Result3 = ((num2 <= 0) ? Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepWithId_Result>((IEnumerable<MobspDySelectFormWorkflowStepWithId_Result>)cRMEntities.MobspDySelectFormWorkflowStepWithId(model.WorkflowStepId, currLangId, defLangId, model.CenterId)) : Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepWithId_Result>((IEnumerable<MobspDySelectFormWorkflowStepWithId_Result>)cRMEntities.MobspDySelectFormWorkflowStepWithId(num2, currLangId, defLangId, model.CenterId)));
						if (mobspDySelectFormWorkflowStepWithId_Result3 != null)
						{
							string referUserIds = mobspDySelectFormWorkflowStepWithId_Result3.ReferUserIds ?? "";
							string multiReferUserIds = mobspDySelectFormWorkflowStepWithId_Result3.MultiReferUserIds ?? "";
							string checkerUserIds = mobspDySelectFormWorkflowStepWithId_Result3.CheckerUserIds ?? "";
							SendIntMsg(model.FormId, result4, result2, mobspDySelectFormWorkflowStepWithId_Result3.FormWorkflowStepId, referUserIds, multiReferUserIds, checkerUserIds, model.SendIntMsgForMultiReferUsers, model.SendIntMsgForCheckerUsers, model.MasterValueDetailId.GetValueOrDefault(), num2, mainFormReferUserIs, model.CenterId);
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
			if (!string.IsNullOrEmpty(text))
			{
				string text20 = "";
				string[] array10 = text.Split(new string[1] { "\\" }, StringSplitOptions.None);
				for (int j = 0; j < array10.Length - 1; j++)
				{
					text20 = text20 + array10[j] + "\\";
				}
				if (flag && Directory.Exists(text20))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text20);
					FileInfo[] files = directoryInfo.GetFiles();
					for (int i = 0; i < files.Length; i++)
					{
						files[i].Delete();
					}
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					for (int i = 0; i < directories.Length; i++)
					{
						directories[i].Delete(recursive: true);
					}
					if (Directory.Exists(text20))
					{
						Directory.Delete(text20);
					}
				}
			}
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<string> SendIntMsg(int formId, int mValId, int workflowId, int workflowStepId, string referUserIds, string multiReferUserIds, string checkerUserIds, bool sendAutoMsgToMultiReferUsers, bool sendAutoMsgToCheckerUsers, int masterValueDetailId = 0, int firstWorkflowStepId = 0, string mainFormReferUserIs = "", int? cId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = null;
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Mobile.Classes.Configuration.AppType;
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string registerTime = now.ToString("HH:mm:ss");
			string formName = DyForm.GetFormName(formId, result, result, cId);
			string workflowStepTitle = DyForm.GetWorkflowStepTitle(workflowStepId, result, result, cId);
			List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
			bool flag = true;
			bool flag2 = true;
			bool flag3 = true;
			bool flag4 = true;
			bool flag5 = true;
			MobspDySelectFormFieldMasterValueWithId_Result mobspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(mValId, lCID, result));
			if (mobspDySelectFormFieldMasterValueWithId_Result != null)
			{
				if (mobspDySelectFormFieldMasterValueWithId_Result.DyFormNumber.HasValue)
				{
					mobspDySelectFormFieldMasterValueWithId_Result.DyFormNumber.ToString();
				}
				else
				{
					mValId.ToString();
				}
			}
			else
			{
				mValId.ToString();
			}
			bool flag6 = false;
			if (!string.IsNullOrEmpty(mainFormReferUserIs) && firstWorkflowStepId > 0 && flag6)
			{
				if (!string.IsNullOrEmpty(mainFormReferUserIs))
				{
					string[] array = mainFormReferUserIs.Split(new char[1] { '|' });
					if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						string text3 = "";
						string[] array2 = array;
						foreach (string text4 in array2)
						{
							if (!string.IsNullOrEmpty(text4) && int.Parse(text4) != userId)
							{
								text3 = text3 + text4 + "|";
							}
						}
						mainFormReferUserIs = text3;
					}
				}
				if (!string.IsNullOrEmpty(mainFormReferUserIs))
				{
					string text5 = "";
					string text6 = "";
					string text7 = "";
					foreach (MobspSelectLanguages_Result item in list)
					{
						string formName2 = DyForm.GetFormName(formId, result, item.LanguageID, cId);
						DyForm.GetWorkflowStepTitle(workflowStepId, result, item.LanguageID, cId);
						text5 = "";
						text6 = "";
						text5 = string.Format(MyResource.GetResourceString("DyFrmRefreUsersMsgSub", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName2);
						text6 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmErjaAttentionForMainForm", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName2) + "<BR>";
						string[] array3 = mainFormReferUserIs.TrimEnd(new char[1] { '|' }).Split(new char[1] { '|' });
						if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) > 1)
						{
							text6 = text6 + "<BR>" + MyResource.GetResourceString("DyFrmErjaMultiUser", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + DyForm.GetUsersForSendMsg(formId, mainFormReferUserIs, result, item.LanguageID, item.LanguageCollation);
						}
						text6 = text6 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text7 = text7 + "MsgSubj=" + text5 + "|@#@|MsgBody=" + text6 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
					}
					ObjectParameter objectParameter = new ObjectParameter("InsertedIntMsgId", 0);
					cRMEntities.MobspDySendFormInternalMessages(mValId, firstWorkflowStepId, mainFormReferUserIs, text7, formName, workflowStepTitle, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter, cId);
					flag = objectParameter.Value != null && (objectParameter.Value.ToString() ?? "0") != "-1";
				}
			}
			if (!string.IsNullOrEmpty(referUserIds))
			{
				string[] array4 = referUserIds.Split(new char[1] { '|' });
				if (Enumerable.Any<string>((IEnumerable<string>)array4))
				{
					string text8 = "";
					string[] array2 = array4;
					foreach (string text9 in array2)
					{
						if (!string.IsNullOrEmpty(text9) && int.Parse(text9) != userId)
						{
							text8 = text8 + text9 + "|";
						}
					}
					referUserIds = text8;
				}
			}
			if (!string.IsNullOrEmpty(referUserIds) && flag6)
			{
				string text10 = "";
				string text11 = "";
				string text12 = "";
				foreach (MobspSelectLanguages_Result item2 in list)
				{
					string formName3 = DyForm.GetFormName(formId, result, item2.LanguageID, cId);
					string workflowStepTitle2 = DyForm.GetWorkflowStepTitle(workflowStepId, result, item2.LanguageID, cId);
					text10 = "";
					text11 = "";
					text10 = string.Format(MyResource.GetResourceString("DyFrmRefreUsersMsgSub", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName3);
					text11 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmErjaAttention", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), workflowStepTitle2, formName3) + "<BR>";
					string[] array5 = referUserIds.TrimEnd(new char[1] { '|' }).Split(new char[1] { '|' });
					if (array5 != null && Enumerable.Count<string>((IEnumerable<string>)array5) > 1)
					{
						text11 = text11 + "<BR>" + MyResource.GetResourceString("DyFrmErjaMultiUser", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + DyForm.GetUsersForSendMsg(formId, referUserIds, result, item2.LanguageID, item2.LanguageCollation);
					}
					text11 = text11 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text12 = text12 + "MsgSubj=" + text10 + "|@#@|MsgBody=" + text11 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
				}
				ObjectParameter objectParameter2 = new ObjectParameter("InsertedIntMsgId", 0);
				cRMEntities.MobspDySendFormInternalMessages(mValId, workflowStepId, referUserIds, text12, formName, workflowStepTitle, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter2, cId);
				flag2 = objectParameter2.Value != null && (objectParameter2.Value.ToString() ?? "0") != "-1";
			}
			if (!string.IsNullOrEmpty(multiReferUserIds) && sendAutoMsgToMultiReferUsers)
			{
				string text13 = "";
				string text14 = "";
				string text15 = "";
				foreach (MobspSelectLanguages_Result item3 in list)
				{
					string formName4 = DyForm.GetFormName(formId, result, item3.LanguageID, cId);
					text13 = "";
					text14 = "";
					text13 = string.Format(MyResource.GetResourceString("DyFrmErjaRonevesht", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName4) + " " + Common.GetUserName(userId, result, item3.LanguageID, cId);
					text14 = MyResource.GetResourceString("DyFrmErjaFrom", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":" + formName4;
					text14 = text14 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text15 = text15 + "MsgSubj=" + text13 + "|@#@|MsgBody=" + text14 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
				}
				ObjectParameter objectParameter3 = new ObjectParameter("InsertedIntMsgId", 0);
				cRMEntities.MobspDySendFormInternalMessages(mValId, workflowStepId, multiReferUserIds, text15, formName, workflowStepTitle, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter3, cId);
				flag3 = objectParameter3.Value != null && (objectParameter3.Value.ToString() ?? "0") != "-1";
			}
			if (firstWorkflowStepId == 0)
			{
				if (!string.IsNullOrEmpty(checkerUserIds) && sendAutoMsgToCheckerUsers)
				{
					string text16 = "";
					string text17 = "";
					string text18 = "";
					foreach (MobspSelectLanguages_Result item4 in list)
					{
						string formName5 = DyForm.GetFormName(formId, result, item4.LanguageID, cId);
						text16 = "";
						text17 = "";
						text16 = string.Format(MyResource.GetResourceString("DyfrmCheckRequestSubject", item4.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly), formName5);
						text17 = MyResource.GetResourceString("DyFrmReqCheckByName", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":" + formName5;
						text17 = text17 + "<BR><BR>" + MyResource.GetResourceString("DyfrmCheckRequestDbClickOnOtherInfo", item4.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						text18 = text18 + "MsgSubj=" + text16 + "|@#@|MsgBody=" + text17 + "|@#@|LangId=" + item4.LanguageID + "|@#@||^#^|";
					}
					ObjectParameter objectParameter4 = new ObjectParameter("InsertedIntMsgId", 0);
					cRMEntities.MobspDySendFormInternalMessages(mValId, workflowStepId, checkerUserIds, text18, formName, workflowStepTitle, 16, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter4, cId);
					flag4 = objectParameter4.Value != null && (objectParameter4.Value.ToString() ?? "0") != "-1";
				}
				if (string.IsNullOrEmpty(checkerUserIds) && flag6)
				{
					MobspDySelectFormWorkflowStepNext_Result mobspDySelectFormWorkflowStepNext_Result = Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepNext_Result>((IEnumerable<MobspDySelectFormWorkflowStepNext_Result>)cRMEntities.MobspDySelectFormWorkflowStepNext(workflowId, workflowStepId, lCID, result, cId));
					if (mobspDySelectFormWorkflowStepNext_Result != null)
					{
						if (!string.IsNullOrEmpty(mobspDySelectFormWorkflowStepNext_Result.ReferUserIds) && flag6)
						{
							string text19 = "";
							string text20 = "";
							string text21 = "";
							foreach (MobspSelectLanguages_Result item5 in list)
							{
								string workflowStepTitle3 = DyForm.GetWorkflowStepTitle(workflowStepId, result, item5.LanguageID, cId);
								string formName6 = DyForm.GetFormName(formId, result, item5.LanguageID, cId);
								text19 = "";
								text20 = "";
								text19 = string.Format(MyResource.GetResourceString("DyFrmNextStepRefreUsersMsgSub", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), workflowStepTitle3, formName6);
								text20 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmNextStepErjaAttention", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), DyForm.GetWorkflowStepTitle(mobspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, result, item5.LanguageID, cId), formName6, workflowStepTitle3) + "<BR>";
								string[] array6 = mobspDySelectFormWorkflowStepNext_Result.ReferUserIds.TrimEnd(new char[1] { '|' }).Split(new char[1] { '|' });
								if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) > 1)
								{
									text20 = text20 + "<BR>" + MyResource.GetResourceString("DyFrmErjaMultiUser", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + DyForm.GetUsersForSendMsg(formId, mobspDySelectFormWorkflowStepNext_Result.ReferUserIds, result, item5.LanguageID, item5.LanguageCollation);
								}
								text20 = text20 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								text21 = text21 + "MsgSubj=" + text19 + "|@#@|MsgBody=" + text20 + "|@#@|LangId=" + item5.LanguageID + "|@#@||^#^|";
							}
							string workflowStepTitle4 = DyForm.GetWorkflowStepTitle(mobspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, result, result, cId);
							ObjectParameter objectParameter5 = new ObjectParameter("InsertedIntMsgId", 0);
							cRMEntities.MobspDySendFormInternalMessages(mValId, mobspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, mobspDySelectFormWorkflowStepNext_Result.ReferUserIds, text21, formName, workflowStepTitle4, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter5, cId);
							flag5 = objectParameter5.Value != null && (objectParameter5.Value.ToString() ?? "0") != "-1";
						}
					}
					else
					{
						MobspDySelectFormFieldMasterValueWithId_Result mobspDySelectFormFieldMasterValueWithId_Result2 = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(mValId, lCID, result));
						if (mobspDySelectFormFieldMasterValueWithId_Result2.FirstRegisterUserId > 0)
						{
							string text22 = "";
							string text23 = "";
							string text24 = "";
							foreach (MobspSelectLanguages_Result item6 in list)
							{
								string formName7 = DyForm.GetFormName(mobspDySelectFormFieldMasterValueWithId_Result2.FormId, result, item6.LanguageID, cId);
								string workflowStepTitle5 = DyForm.GetWorkflowStepTitle(workflowStepId, result, item6.LanguageID, cId);
								text22 = "";
								text23 = "";
								text22 = string.Format(MyResource.GetResourceString("DyFrmNextStepRefreUsersMsgSub", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), workflowStepTitle5, formName7);
								text23 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmFirstStepErjaAttention", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName7, workflowStepTitle5, formName7) + "<BR>";
								text23 = text23 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								text24 = text24 + "MsgSubj=" + text22 + "|@#@|MsgBody=" + text23 + "|@#@|LangId=" + item6.LanguageID + "|@#@||^#^|";
							}
							ObjectParameter objectParameter6 = new ObjectParameter("InsertedIntMsgId", 0);
							cRMEntities.MobspDySendFormInternalMessages(mValId, workflowStepId, mobspDySelectFormFieldMasterValueWithId_Result2.FirstRegisterUserId.ToString(), text24, formName, workflowStepTitle, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter6, cId);
							flag5 = objectParameter6.Value != null && (objectParameter6.Value.ToString() ?? "0") != "-1";
						}
					}
				}
			}
			if (flag2 && flag3 && flag4 && flag5 && flag)
			{
				PushNotif.NewIntMsgNotify(withthread: true, cId);
				text2 = Messages.MobMsgSuccessAction;
				text = null;
				serviceResultStatus = ServiceResultStatus.Success;
			}
			else
			{
				text2 = Messages.msgErrorErrorSendingMessages;
				text = null;
				serviceResultStatus = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text2 = Messages.msgErrorRunFunction + "<br />" + ex.Message;
			serviceResultStatus = ServiceResultStatus.Error;
			text = null;
		}
		return new ServiceResult<string>
		{
			Message = text2,
			Data = text,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DeleteValue(int mValId, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					DateTime now = DateTime.Now;
					string deletedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					cRMEntities = new CRMEntities();
					MobspDySelectFormFieldMasterValueWithId_Result mobspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(mValId, num, result2));
					if (mobspDySelectFormFieldMasterValueWithId_Result != null)
					{
						if (DyForm.IsChecked(mValId))
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgFormIsChecked,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(mobspDySelectFormFieldMasterValueWithId_Result.CompanyId.HasValue ? mobspDySelectFormFieldMasterValueWithId_Result.CompanyId.ToString() : "0", mobspDySelectFormFieldMasterValueWithId_Result.CompanyPersonId.HasValue ? mobspDySelectFormFieldMasterValueWithId_Result.CompanyPersonId.ToString() : "0", mobspDySelectFormFieldMasterValueWithId_Result.ProjectId.HasValue ? mobspDySelectFormFieldMasterValueWithId_Result.ProjectId.ToString() : "0", "60", mValId.ToString(), num, result2, false, cId));
						if (list != null && Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list))
						{
							return new ServiceResult<string>
							{
								Message = Messages.RedundancyMessage,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.MobspDyUpdateToDeleteFormFieldMasterValue(mValId, token2.userId, now, deletedDatePersian));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							message = Messages.MobMsgSuccessAction;
							data = null;
							status = ServiceResultStatus.Success;
						}
						else if (mct_Result != null && mct_Result.Result == 0)
						{
							message = Messages.RedundancyMessage;
							data = null;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.ErrorNotFound;
						data = null;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> CheckDyForm(int mValId, int mode, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					DateTime now = DateTime.Now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					if (!UserLogin.IsUserAccess("frmDyForm", "actCheckDyForm", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					if (Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(mValId, num, result2)) != null)
					{
						cRMEntities.MobspDyFormCheck(mValId, token2.userId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), mode);
						cRMSpEntities.MobScorespInsertAndCalcDyFormScores(null, mValId, null, null, token2.userId, value2, value, now, registerDatePersian, appType, num, result2, true, null, cId, true);
						message = Messages.MobMsgSuccessAction;
						data = null;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.ErrorNotFound;
						data = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> ExitCheckDyForm(int mValId, int mode, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					if (!UserLogin.IsUserAccess("frmDyForm", "actExitFromIsChecked", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					if (Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(mValId, num, result2)) != null)
					{
						cRMEntities.MobspDyFormCheckExit(mValId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), mode);
						message = Messages.MobMsgSuccessAction;
						data = null;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.ErrorNotFound;
						data = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspDySelectFormFieldMasterValueWithId_Result> SelectFormFieldMasterValueWithId(int mValId, int? ln = 1065)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspDySelectFormFieldMasterValueWithId_Result mobspDySelectFormFieldMasterValueWithId_Result = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					mobspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(mValId, num, result2));
					if (mobspDySelectFormFieldMasterValueWithId_Result != null)
					{
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.ErrorNotFound;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					mobspDySelectFormFieldMasterValueWithId_Result = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				mobspDySelectFormFieldMasterValueWithId_Result = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			mobspDySelectFormFieldMasterValueWithId_Result = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<MobspDySelectFormFieldMasterValueWithId_Result>
		{
			Message = message,
			Data = mobspDySelectFormFieldMasterValueWithId_Result,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> SendIntMsgToChecker(int formId, int mValId, int workflowStepId, string checkerUserIds, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					int userId = UserLogin.CurrentUser.UserId;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					string registerTime = now.ToString("HH:mm:ss");
					string formName = DyForm.GetFormName(formId, result2, result2, cId);
					string msgAttachRecDescI = "";
					if (workflowStepId != 0)
					{
						msgAttachRecDescI = DyForm.GetWorkflowStepTitle(workflowStepId, result2, result2, cId);
					}
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					bool flag = false;
					if (!string.IsNullOrEmpty(checkerUserIds))
					{
						string text = "";
						string text2 = "";
						string text3 = "";
						foreach (MobspSelectLanguages_Result item in list)
						{
							string formName2 = DyForm.GetFormName(formId, result2, item.LanguageID, cId);
							text = "";
							text2 = "";
							text = string.Format(MyResource.GetResourceString("DyfrmCheckRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly), formName2);
							text2 = MyResource.GetResourceString("DyFrmReqCheckByName", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":" + formName2;
							text2 = text2 + "<BR><BR>" + MyResource.GetResourceString("DyfrmCheckRequestDbClickOnOtherInfo", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							text3 = text3 + "MsgSubj=" + text + "|@#@|MsgBody=" + text2 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
						}
						ObjectParameter objectParameter = new ObjectParameter("InsertedIntMsgId", 0);
						cRMEntities.MobspDySendFormInternalMessages(mValId, workflowStepId, checkerUserIds, text3, formName, msgAttachRecDescI, 16, userId, now, registerDatePersian, registerTime, value2, value, appType, result2, objectParameter, cId);
						flag = objectParameter.Value != null && (objectParameter.Value.ToString() ?? "0") != "-1";
					}
					if (flag)
					{
						PushNotif.NewIntMsgNotify(withthread: true, cId);
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.msgErrorErrorSendingMessages;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspDySelectFormFieldMasterValues_Result>> SelectFormFieldMasterValues(SelectFormFieldMasterValuesViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		List<MobspDySelectFormFieldMasterValues_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspDySelectFormFieldMasterValues_Result>((IEnumerable<MobspDySelectFormFieldMasterValues_Result>)cRMEntities.MobspDySelectFormFieldMasterValues(model.FormId, (model.CmpId == 0) ? null : new int?(model.CmpId), (model.PrsId == 0) ? null : new int?(model.PrsId), (model.PrjId == 0) ? null : new int?(model.PrjId), (model.CnvsId == 0) ? null : new int?(model.CnvsId), (model.MObjId == 0) ? null : new int?(model.MObjId), (model.DObjId == 0) ? null : new int?(model.DObjId), (model.SubObjId == 0) ? null : new int?(model.SubObjId), num, result2, token2.userId, model.CenterId));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspDySelectFormFieldMasterValues_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspDyReturnFormIdAndUserAccessFromMasterValueId_Result> ReturnFormIdAndUserAccessFromMasterValueId(int masterValueId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspDyReturnFormIdAndUserAccessFromMasterValueId_Result data = new MobspDyReturnFormIdAndUserAccessFromMasterValueId_Result();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					MobspDyReturnFormIdAndUserAccessFromMasterValueId_Result mobspDyReturnFormIdAndUserAccessFromMasterValueId_Result = Enumerable.FirstOrDefault<MobspDyReturnFormIdAndUserAccessFromMasterValueId_Result>((IEnumerable<MobspDyReturnFormIdAndUserAccessFromMasterValueId_Result>)cRMEntities.MobspDyReturnFormIdAndUserAccessFromMasterValueId(masterValueId, token2.userId));
					if (mobspDyReturnFormIdAndUserAccessFromMasterValueId_Result != null)
					{
						data = mobspDyReturnFormIdAndUserAccessFromMasterValueId_Result;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.ErrorNotFound;
						data = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<MobspDyReturnFormIdAndUserAccessFromMasterValueId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DySearchItemViewModel>> SearchCompanyPersons(int companyId, string value, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DySearchItemViewModel> list = new List<DySearchItemViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (companyId == 0)
					{
						return new ServiceResult<List<DySearchItemViewModel>>
						{
							Message = Messages.MobMsgSendParameterNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					foreach (MobspDySearchCompanyPersons_Result item in Enumerable.ToList<MobspDySearchCompanyPersons_Result>(Enumerable.Take<MobspDySearchCompanyPersons_Result>((IEnumerable<MobspDySearchCompanyPersons_Result>)cRMEntities.MobspDySearchCompanyPersons(companyId, value ?? "", token2.userId, result, result2, cId), 800)))
					{
						DySearchItemViewModel dySearchItemViewModel = new DySearchItemViewModel();
						int result3 = 0;
						int.TryParse(item.CompanyPersonID.ToString(), out result3);
						dySearchItemViewModel.Id = result3;
						dySearchItemViewModel.Title = item.PersonName ?? "";
						list.Add(dySearchItemViewModel);
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DySearchItemViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DySearchItemViewModel>> SearchCompanyProjects(int companyId, string value, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DySearchItemViewModel> list = new List<DySearchItemViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (companyId == 0)
					{
						return new ServiceResult<List<DySearchItemViewModel>>
						{
							Message = Messages.MobMsgSendParameterNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					foreach (MobspDySearchCompanyProjects_Result item in Enumerable.ToList<MobspDySearchCompanyProjects_Result>(Enumerable.Take<MobspDySearchCompanyProjects_Result>((IEnumerable<MobspDySearchCompanyProjects_Result>)cRMEntities.MobspDySearchCompanyProjects(companyId, 0, value ?? "", token2.userId, result, result2, cId), 800)))
					{
						DySearchItemViewModel dySearchItemViewModel = new DySearchItemViewModel();
						int result3 = 0;
						int.TryParse(item.ProjectID.ToString(), out result3);
						dySearchItemViewModel.Id = result3;
						dySearchItemViewModel.Title = item.ProjectTitle ?? "";
						list.Add(dySearchItemViewModel);
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DySearchItemViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DySearchItemViewModel>> SearchCompanyConversations(int companyId, int projectId, string value, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DySearchItemViewModel> list = new List<DySearchItemViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (companyId == 0 || projectId == 0)
					{
						return new ServiceResult<List<DySearchItemViewModel>>
						{
							Message = Messages.MobMsgSendParameterNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					foreach (MobspDySearchCompanyConversations_Result item in Enumerable.ToList<MobspDySearchCompanyConversations_Result>(Enumerable.Take<MobspDySearchCompanyConversations_Result>((IEnumerable<MobspDySearchCompanyConversations_Result>)cRMEntities.MobspDySearchCompanyConversations(companyId, projectId, value ?? "", token2.userId, result, result2, cId), 800)))
					{
						item.TxtHelp = item.cnvsDesc + "|" + item.ConversationId + "|";
						item.cnvsDate = (item.cnvsDateTime.HasValue ? item.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
						item.cnvsDesc = "(" + item.ConversationId + " - " + item.cnvsTopic + " - " + item.cnvsDate + ")";
						DySearchItemViewModel dySearchItemViewModel = new DySearchItemViewModel();
						int result3 = 0;
						int.TryParse(item.ConversationId.ToString(), out result3);
						dySearchItemViewModel.Id = result3;
						dySearchItemViewModel.Title = item.cnvsDesc ?? "";
						list.Add(dySearchItemViewModel);
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DySearchItemViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DySearchItemViewModel>> SearchPreOrders(int companyId, string value, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DySearchItemViewModel> list = new List<DySearchItemViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (companyId == 0)
					{
						return new ServiceResult<List<DySearchItemViewModel>>
						{
							Message = Messages.MobMsgSendParameterNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					foreach (MobspDySearchPreOrders_Result item in Enumerable.ToList<MobspDySearchPreOrders_Result>(Enumerable.Take<MobspDySearchPreOrders_Result>((IEnumerable<MobspDySearchPreOrders_Result>)cRMEntities.MobspDySearchPreOrders(companyId, value ?? "", token2.userId, result, result2, cId), 800)))
					{
						item.TxtHelp = item.pordNumber + "|" + item.pordLinkAccPreOrderNumber + "|";
						item.pordDate = (item.pordDateTime.HasValue ? item.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
						item.PordInfo = "(" + item.PordInfo + " - " + item.pordDate + ")";
						DySearchItemViewModel dySearchItemViewModel = new DySearchItemViewModel();
						int result3 = 0;
						int.TryParse(item.PreOrderID.ToString(), out result3);
						dySearchItemViewModel.Id = result3;
						dySearchItemViewModel.Title = item.PordInfo ?? "";
						list.Add(dySearchItemViewModel);
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DySearchItemViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DySearchItemViewModel>> SearchOrders(int companyId, string value, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DySearchItemViewModel> list = new List<DySearchItemViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (companyId == 0)
					{
						return new ServiceResult<List<DySearchItemViewModel>>
						{
							Message = Messages.MobMsgSendParameterNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					foreach (MobspDySearchOrders_Result item in Enumerable.ToList<MobspDySearchOrders_Result>(Enumerable.Take<MobspDySearchOrders_Result>((IEnumerable<MobspDySearchOrders_Result>)cRMEntities.MobspDySearchOrders(companyId, value ?? "", token2.userId, result, result2, cId), 800)))
					{
						item.TxtHelp = item.ordNumber + "|" + item.ordLinkAccOrderNumber + "|";
						item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
						item.OrdInfo = "(" + item.OrdInfo + " - " + item.ordDate + ")";
						DySearchItemViewModel dySearchItemViewModel = new DySearchItemViewModel();
						int result3 = 0;
						int.TryParse(item.OrderID.ToString(), out result3);
						dySearchItemViewModel.Id = result3;
						dySearchItemViewModel.Title = item.OrdInfo ?? "";
						list.Add(dySearchItemViewModel);
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DySearchItemViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DySearchItemViewModel>> SearchBuyOrders(int companyId, string value, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DySearchItemViewModel> list = new List<DySearchItemViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (companyId == 0)
					{
						return new ServiceResult<List<DySearchItemViewModel>>
						{
							Message = Messages.MobMsgSendParameterNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					foreach (MobspDySearchBuyOrders_Result item in Enumerable.ToList<MobspDySearchBuyOrders_Result>(Enumerable.Take<MobspDySearchBuyOrders_Result>((IEnumerable<MobspDySearchBuyOrders_Result>)cRMEntities.MobspDySearchBuyOrders(companyId, value ?? "", token2.userId, result, result2, cId), 800)))
					{
						item.TxtHelp = item.bordNumber + "|" + item.bordLinkAccBuyOrderNumber + "|";
						item.bordDate = (item.bordDateTime.HasValue ? item.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
						item.BordInfo = "(" + item.BordInfo + " - " + item.bordDate + ")";
						DySearchItemViewModel dySearchItemViewModel = new DySearchItemViewModel();
						int result3 = 0;
						int.TryParse(item.BuyOrderID.ToString(), out result3);
						dySearchItemViewModel.Id = result3;
						dySearchItemViewModel.Title = item.BordInfo ?? "";
						list.Add(dySearchItemViewModel);
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DySearchItemViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DySearchItemViewModel>> SearchDocs(int companyId, int oprType, string value, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DySearchItemViewModel> list = new List<DySearchItemViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					foreach (MobspDySearchDocsByType_Result item in Enumerable.ToList<MobspDySearchDocsByType_Result>(Enumerable.Take<MobspDySearchDocsByType_Result>((IEnumerable<MobspDySearchDocsByType_Result>)cRMEntities.MobspDySearchDocsByType(companyId, oprType, value ?? "", token2.userId, result, result2, cId), 800)))
					{
						item.TxtHelp = item.DocNumber + "|" + item.DocLinkAccDocNumber + "|";
						item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
						item.DocInfo = "(" + item.DocInfo + " - " + item.DocDate + ")";
						DySearchItemViewModel dySearchItemViewModel = new DySearchItemViewModel();
						int result3 = 0;
						int.TryParse(item.DocID.ToString(), out result3);
						dySearchItemViewModel.Id = result3;
						dySearchItemViewModel.Title = item.DocInfo ?? "";
						list.Add(dySearchItemViewModel);
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DySearchItemViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DySearchItemViewModel>> SearchLetters(int companyId, int letterTypeId, string value, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DySearchItemViewModel> list = new List<DySearchItemViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (companyId == 0)
					{
						return new ServiceResult<List<DySearchItemViewModel>>
						{
							Message = Messages.MobMsgSendParameterNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					foreach (MobspDySearchLettersByType_Result item in Enumerable.ToList<MobspDySearchLettersByType_Result>(Enumerable.Take<MobspDySearchLettersByType_Result>((IEnumerable<MobspDySearchLettersByType_Result>)cRMEntities.MobspDySearchLettersByType(companyId, letterTypeId, value ?? "", token2.userId, result, result2, cId), 800)))
					{
						_ = item.LetterNumber;
						item.TxtHelp = item.LetterNumber + "|" + (item.LetterNumberII.HasValue ? item.LetterNumberII.GetValueOrDefault().ToString() : "") + "|";
						_ = item.LetterDateTime;
						item.LetterDate = item.LetterDateTime.ToString("yyyy/MM/dd");
						item.LetterInfo = "(" + item.LetterInfo + " - " + item.LetterDate + ")";
						DySearchItemViewModel dySearchItemViewModel = new DySearchItemViewModel();
						int result3 = 0;
						int.TryParse(item.LetterId.ToString(), out result3);
						dySearchItemViewModel.Id = result3;
						dySearchItemViewModel.Title = item.LetterInfo ?? "";
						list.Add(dySearchItemViewModel);
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DySearchItemViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DySearchItemViewModel>> SearchCmsPages(string value, int? ln = 1065)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DySearchItemViewModel> list = new List<DySearchItemViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					foreach (MobspDySearchCmsPages_Result item in Enumerable.ToList<MobspDySearchCmsPages_Result>(Enumerable.Take<MobspDySearchCmsPages_Result>((IEnumerable<MobspDySearchCmsPages_Result>)cRMEntities.MobspDySearchCmsPages(value ?? "", result, result2), 800)))
					{
						item.TxtHelp = item.PageName + "|" + item.PageTitle + "|";
						DySearchItemViewModel dySearchItemViewModel = new DySearchItemViewModel();
						int result3 = 0;
						int.TryParse(item.PageId.ToString(), out result3);
						dySearchItemViewModel.Id = result3;
						dySearchItemViewModel.Title = item.PageName ?? "";
						list.Add(dySearchItemViewModel);
					}
					message = Messages.MobMsgErrorCompanyNotFound;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DySearchItemViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> SelectFormFieldMasterValuesCnt(int? cId = null)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspSelectFormFieldMasterValuesCnt(cId)).GetValueOrDefault();
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspDySelectFormFieldMasterValueSysPartInfo_Result> GetDyFormFieldMasterValuesSysInfo(int masterValuesId, int? ln = 0)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMSpEntities cRMSpEntities = null;
		MobspDySelectFormFieldMasterValueSysPartInfo_Result data = new MobspDySelectFormFieldMasterValueSysPartInfo_Result();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					MobspDySelectFormFieldMasterValueSysPartInfo_Result mobspDySelectFormFieldMasterValueSysPartInfo_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueSysPartInfo_Result>((IEnumerable<MobspDySelectFormFieldMasterValueSysPartInfo_Result>)cRMSpEntities.MobspDySelectFormFieldMasterValueSysPartInfo(masterValuesId, num, result));
					if (mobspDySelectFormFieldMasterValueSysPartInfo_Result != null)
					{
						data = mobspDySelectFormFieldMasterValueSysPartInfo_Result;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<MobspDySelectFormFieldMasterValueSysPartInfo_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectFilesDirectoryTemplateById_Result> GetTempFileDownload(int TempFileId)
	{
		CRMSpEntities cRMSpEntities = null;
		MobspSelectFilesDirectoryTemplateById_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					MobspSelectFilesDirectoryTemplateById_Result mobspSelectFilesDirectoryTemplateById_Result = Enumerable.FirstOrDefault<MobspSelectFilesDirectoryTemplateById_Result>((IEnumerable<MobspSelectFilesDirectoryTemplateById_Result>)cRMSpEntities.MobspSelectFilesDirectoryTemplateById(TempFileId));
					if (mobspSelectFilesDirectoryTemplateById_Result != null)
					{
						data = mobspSelectFilesDirectoryTemplateById_Result;
						message = "";
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<MobspSelectFilesDirectoryTemplateById_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> DeleteTemplateFile(int TempFileId)
	{
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					cRMSpEntities.MobspDeleteFilesDirectoryTemplate(TempFileId);
					data = true;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> ResendAutoIntMessage(ResendDyFormAutoIntMsg Model)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					ServiceResult<string> serviceResult = SendIntMsg(Model.formId, Model.mValId, Model.workflowId, Model.workflowStepId, Model.referUserIds, Model.multiReferUserIds, Model.checkerUserIds, Model.sendAutoMsgToMultiReferUsers, Model.sendAutoMsgToCheckerUsers, Model.masterValueDetailId.GetValueOrDefault(), Model.firstWorkflowStepId.GetValueOrDefault(), Model.mainFormReferUserIs ?? "", Model.cId);
					if (serviceResult != null)
					{
						return serviceResult;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = "";
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = "";
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = "";
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> CheckSubForm(int mValId, int mvdId, int workflowStepId, int? cId, int? ln = null)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num2 = ((num > 0) ? num : result);
		baseInfo.SetCulture(num2);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (!UserLogin.IsUserAccess("frmDyForm", "actCheckDyForm", UserLogin.CurrentUser, cId))
					{
						message = Messages.DoNotHaveAccess;
						data = false;
						status = ServiceResultStatus.Error;
						return new ServiceResult<bool>
						{
							Message = message,
							Data = data,
							Status = status
						};
					}
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					MobspDySelectFormFieldMasterValueWithId_Result mobspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(mValId, num2, result));
					if (Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetailWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetailWithId(mvdId, num2, result)) == null || mobspDySelectFormFieldMasterValueWithId_Result == null)
					{
						message = Messages.ErrorNotFound;
						data = false;
						status = ServiceResultStatus.Error;
						return new ServiceResult<bool>
						{
							Message = message,
							Data = data,
							Status = status
						};
					}
					if (cRMSpEntities.MobspDySubFormCheck(mValId, mvdId, workflowStepId, token2.userId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture())) > 0)
					{
						DateTime now = DateTime.Now;
						int userId = UserLogin.CurrentUser.UserId;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						short value = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType = Mobile.Classes.Configuration.AppType;
						short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
						string registerTime = now.ToString("HH:mm:ss");
						string formName = DyForm.GetFormName(mobspDySelectFormFieldMasterValueWithId_Result.FormId, result, result);
						string workflowStepTitle = DyForm.GetWorkflowStepTitle(workflowStepId, result, result);
						List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
						bool flag = true;
						MobspDySelectFormWorkflowStepNext_Result mobspDySelectFormWorkflowStepNext_Result = Enumerable.FirstOrDefault<MobspDySelectFormWorkflowStepNext_Result>((IEnumerable<MobspDySelectFormWorkflowStepNext_Result>)cRMEntities.MobspDySelectFormWorkflowStepNext(mobspDySelectFormFieldMasterValueWithId_Result.WorkflowId, workflowStepId, num2, result, cId));
						if (mobspDySelectFormWorkflowStepNext_Result != null)
						{
							if (!string.IsNullOrEmpty(mobspDySelectFormWorkflowStepNext_Result.ReferUserIds))
							{
								string text = "";
								string text2 = "";
								string text3 = "";
								foreach (MobspSelectLanguages_Result item in list)
								{
									string formName2 = DyForm.GetFormName(mobspDySelectFormFieldMasterValueWithId_Result.FormId, result, item.LanguageID);
									string workflowStepTitle2 = DyForm.GetWorkflowStepTitle(workflowStepId, result, item.LanguageID);
									text = "";
									text2 = "";
									text = string.Format(MyResource.GetResourceString("DyFrmVerifyNextStepRefreUsersMsgSub", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName2);
									text2 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmVerifyNextStepErjaAttention", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), DyForm.GetWorkflowStepTitle(mobspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, result, item.LanguageID), formName2, workflowStepTitle2) + "<BR>";
									string[] array = mobspDySelectFormWorkflowStepNext_Result.ReferUserIds.TrimEnd(new char[1] { '|' }).Split(new char[1] { '|' });
									if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) > 1)
									{
										text2 = text2 + "<BR>" + MyResource.GetResourceString("DyFrmErjaMultiUser", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + DyForm.GetUsersForSendMsg(mobspDySelectFormFieldMasterValueWithId_Result.FormId, mobspDySelectFormWorkflowStepNext_Result.ReferUserIds, result, item.LanguageID, item.LanguageCollation);
									}
									text2 = text2 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
									text3 = text3 + "MsgSubj=" + text + "|@#@|MsgBody=" + text2 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
								}
								string workflowStepTitle3 = DyForm.GetWorkflowStepTitle(mobspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, result, result);
								ObjectParameter objectParameter = new ObjectParameter("InsertedIntMsgId", 0);
								cRMEntities.MobspDySendFormInternalMessages(mValId, mobspDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, mobspDySelectFormWorkflowStepNext_Result.ReferUserIds, text3, formName, workflowStepTitle3, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter, cId);
								flag = objectParameter.Value != null && (objectParameter.Value.ToString() ?? "0") != "-1";
							}
						}
						else if (mobspDySelectFormFieldMasterValueWithId_Result.FirstRegisterUserId > 0)
						{
							string text4 = "";
							string text5 = "";
							string text6 = "";
							foreach (MobspSelectLanguages_Result item2 in list)
							{
								string formName3 = DyForm.GetFormName(mobspDySelectFormFieldMasterValueWithId_Result.FormId, result, item2.LanguageID);
								DyForm.GetWorkflowStepTitle(workflowStepId, result, item2.LanguageID);
								text4 = "";
								text5 = "";
								text4 = string.Format(MyResource.GetResourceString("DyFrmVerifyNextStepRefreUsersMsgSub", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName3);
								text5 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmVerifyFirstStepErjaAttention", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName3) + "<BR>";
								text5 = text5 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								text6 = text6 + "MsgSubj=" + text4 + "|@#@|MsgBody=" + text5 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
							}
							ObjectParameter objectParameter2 = new ObjectParameter("InsertedIntMsgId", 0);
							cRMEntities.MobspDySendFormInternalMessages(mValId, workflowStepId, mobspDySelectFormFieldMasterValueWithId_Result.FirstRegisterUserId.ToString(), text6, formName, workflowStepTitle, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, objectParameter2, cId);
							flag = objectParameter2.Value != null && (objectParameter2.Value.ToString() ?? "0") != "-1";
						}
						if (!flag)
						{
							message = Messages.msgErrorErrorSendingMessages;
							data = false;
							status = ServiceResultStatus.Error;
						}
						MobspDySelectFormFieldMasterValueDetailWithId_Result mobspDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetailWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetailWithId(mvdId, num2, result));
						if (mobspDySelectFormFieldMasterValueDetailWithId_Result != null)
						{
							string text7 = "";
							string text8 = "";
							string text9 = "";
							foreach (MobspSelectLanguages_Result item3 in list)
							{
								string formName4 = DyForm.GetFormName(mobspDySelectFormFieldMasterValueDetailWithId_Result.FormId, result, item3.LanguageID);
								string workflowStepTitle4 = DyForm.GetWorkflowStepTitle(workflowStepId, result, item3.LanguageID);
								text7 = "";
								text8 = "";
								text7 = string.Format(MyResource.GetResourceString("DyFrmVerifyNextStepRefreUsersMsgSub", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), formName4);
								text8 = "**" + MyResource.GetResourceString("DyFrmErjaAutomatically", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + string.Format(MyResource.GetResourceString("DyFrmVerifyCurrentStepErjaAttention", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), DyForm.GetWorkflowStepTitle(mobspDySelectFormFieldMasterValueDetailWithId_Result.WorkflowStepId.GetValueOrDefault(), result, item3.LanguageID), formName4, workflowStepTitle4) + "<BR>";
								text8 = text8 + "<BR><BR>" + MyResource.GetResourceString("DyFrmErjaDetails", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								text9 = text9 + "MsgSubj=" + text7 + "|@#@|MsgBody=" + text8 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
							}
							string workflowStepTitle5 = DyForm.GetWorkflowStepTitle(mobspDySelectFormFieldMasterValueDetailWithId_Result.WorkflowStepId.GetValueOrDefault(), result, result);
							ObjectParameter insertedIntMsgId = new ObjectParameter("InsertedIntMsgId", 0);
							cRMEntities.MobspDySendFormInternalMessages(mValId, mobspDySelectFormFieldMasterValueDetailWithId_Result.WorkflowStepId, mobspDySelectFormFieldMasterValueDetailWithId_Result.FirstRegisterUserId.ToString(), text9, formName, workflowStepTitle5, 17, userId, now, registerDatePersian, registerTime, value2, value, appType, result, insertedIntMsgId, cId);
						}
						PushNotif.NewIntMsgNotify();
					}
					message = "";
					data = true;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> ExitSubFormFromIsChecked(int mvdId, int? cId, int? ln = null)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num2 = ((num > 0) ? num : result);
		baseInfo.SetCulture(num2);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					if (!UserLogin.IsUserAccess("frmDyForm", "actExitFromIsCheckedSubform", UserLogin.CurrentUser, cId))
					{
						message = Messages.DoNotHaveAccess;
						data = false;
						status = ServiceResultStatus.Error;
						return new ServiceResult<bool>
						{
							Message = message,
							Data = data,
							Status = status
						};
					}
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					if (Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueDetailWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueDetailWithId(mvdId, num2, result)) != null)
					{
						cRMSpEntities.MobspDySubFormCheckExit(mvdId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
						data = true;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.ErrorNotFound;
						data = false;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
