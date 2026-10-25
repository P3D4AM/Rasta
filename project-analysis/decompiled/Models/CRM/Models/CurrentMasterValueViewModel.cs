using System.Collections.Generic;

namespace CRM.Models;

public class CurrentMasterValueViewModel
{
	public mct_CRMspDySelectFormFieldMasterValues_Result MasterValue { get; set; }

	public int MasterValueCurrentId { get; set; }

	public int MasterValueNextId { get; set; }

	public int MasterValuePreviousId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int MasterValueFirstId { get; set; }

	public int MasterValueLastId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int CheckerUserId { get; set; }

	public string CheckerUser { get; set; }

	public bool IsChecked { get; set; }

	public List<CRMspDySelectFormAndSubForms_Result> Forms { get; set; }

	public CRMspDySelectFormAndSubForms_Result MainForm { get; set; }

	public List<CRMspDySelectFormFieldsByParentFormId_Result> FormFields { get; set; }

	public List<CRMspDySelectFormWorkflowStepsForMasterValue_Result> WorkflowSteps { get; set; }

	public string PartTitle { get; set; }

	public string FormName { get; set; }

	public string ValueDetails { get; set; }

	public string ValueDetails_Lang { get; set; }

	public int WorkflowId { get; set; }

	public List<CrmFilesDirectoryViewModel> MainFormFiles { get; set; }

	public List<CrmFilesDirectoryViewModel> FormFiles { get; set; }

	public CRMspDySelectFormFieldMasterValueDetails_Result MainFormDetails { get; set; }

	public WSspSelectVerificationWorkFlowStepLast_Result LastVerificationStep { get; set; }

	public int? LastInsertedWorkflowStepId { get; set; }

	public string SystemPartInfo { get; set; }

	public List<CRMspSelectSysDBObjectsByIds_Result> SysDBObjects { get; set; }

	public List<FieldValueChangeHistoryViewModel> FieldValueChangeHistoryList { get; set; }

	public string SysPart_ValueDetails { get; set; }

	public string SysPart_ValueDetails_Lang { get; set; }
}
