namespace CRM.Models;

public class CurrentProductViewModel
{
	public WSspSelectProductByGroup_Result Product { get; set; }

	public int CurrentId { get; set; }

	public int NextId { get; set; }

	public int PreviousId { get; set; }

	public int SgId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int FirstId { get; set; }

	public int LastId { get; set; }

	public string PrdGName { get; set; }
}
