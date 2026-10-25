using System.Collections.Generic;

namespace Mobile.Models;

public class LoadMasterValueDependencyResultViewModel
{
	public MobspDySelectFormFieldMasterValueDetails_Result MainFormDetails { get; set; }

	public List<MobspDySelectFormWorkflowStepsForMasterValue_Result> WorkflowSteps { get; set; }

	public List<MobspDySelectFormFieldValuesByMasterValueId_Result> FormFieldValues { get; set; }

	public List<MobspDySelectFilesDirectory_Result> FormFiles { get; set; }

	public List<MobspDySelectFormFieldMasterValues_Result> FormFieldMasterValues { get; set; }

	public MobspDySelectFormFieldMasterValues_Result SelectedFormFieldMasterValue { get; set; }

	public MobspSelectVerificationWorkFlowStepLast_Result LastVerificationStep { get; set; }
}
