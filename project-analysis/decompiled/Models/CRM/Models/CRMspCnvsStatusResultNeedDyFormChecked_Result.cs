namespace CRM.Models;

public class CRMspCnvsStatusResultNeedDyFormChecked_Result
{
	public int FormFieldMasterValueId { get; set; }

	public int FormId { get; set; }

	public string FormName { get; set; }

	public string FormTitle { get; set; }

	public bool? IsChecked { get; set; }

	public long? DyFormNumber { get; set; }
}
