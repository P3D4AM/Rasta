using System.Collections.Generic;

namespace CRM.Models;

public class DyFormsInReportsViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public List<CRMspDySelectFormAndSubForms_Result> Forms { get; set; }

	public CRMspDySelectFormAndSubForms_Result MainForm { get; set; }

	public List<CRMspDySelectFormFieldsByParentFormId_Result> FormFields { get; set; }
}
