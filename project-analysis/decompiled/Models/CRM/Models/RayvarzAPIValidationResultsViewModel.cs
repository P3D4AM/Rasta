namespace CRM.Models;

public class RayvarzAPIValidationResultsViewModel
{
	public string id { get; set; }

	public string entity { get; set; }

	public string entityId { get; set; }

	public string entityType { get; set; }

	public long? errorCode { get; set; }

	public long? level { get; set; }

	public long? severity { get; set; }

	public bool? showInValidationSummary { get; set; }

	public bool? stopBussinessExecution { get; set; }

	public string toolTip { get; set; }

	public string systemId { get; set; }

	public string key { get; set; }

	public string message { get; set; }
}
