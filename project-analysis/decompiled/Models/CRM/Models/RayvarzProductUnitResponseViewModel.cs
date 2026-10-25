namespace CRM.Models;

public class RayvarzProductUnitResponseViewModel
{
	public bool? isValidationsApplied { get; set; }

	public long? unitId { get; set; }

	public string name { get; set; }

	public string nameEN { get; set; }

	public string rayGuid { get; set; }

	public int? state { get; set; }

	public int? lastState { get; set; }

	public string rowVersion { get; set; }

	public bool? hasMetadata { get; set; }

	public bool? hasErrors { get; set; }

	public bool? disposing { get; set; }
}
