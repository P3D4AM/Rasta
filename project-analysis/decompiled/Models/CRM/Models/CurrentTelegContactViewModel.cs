namespace CRM.Models;

public class CurrentTelegContactViewModel
{
	public CRMspSelectTelegContact_Result TelegContact { get; set; }

	public int TelegContactCurrentId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }
}
