namespace CRM.Models;

public class CurrentDyFormViewModel
{
	public CRMspDySelectForms_Result DyForm { get; set; }

	public int DyFormCurrentId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }
}
