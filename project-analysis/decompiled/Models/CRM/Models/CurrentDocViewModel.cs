using System.Collections.Generic;

namespace CRM.Models;

public class CurrentDocViewModel
{
	public WSspSelectDocs_Result Doc { get; set; }

	public int CurrentId { get; set; }

	public int NextId { get; set; }

	public int PreviousId { get; set; }

	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public int CompanyId { get; set; }

	public long DocNumber { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int FirstId { get; set; }

	public int LastId { get; set; }

	public List<WSspSelectDocItems_Result> ItemsList { get; set; }

	public List<WSspSelectDocItemSerials_Result> SerialList { get; set; }

	public double QuantityRemain { get; set; }

	public double TracingRemainCount { get; set; }

	public string DocLinkAccDocNumber { get; set; }

	public string DocLinkAccVoucherNumber { get; set; }

	public string DocLinkAccDocIdStr { get; set; }

	public string DocLinkAccFirstTransferDateStr { get; set; }

	public string DocLinkAccLastTransferDateStr { get; set; }

	public WSspSelectVerificationWorkFlowStepLast_Result LastVerificationStep { get; set; }

	public string DocLinkAccData { get; set; }

	public bool IsSentToLinkAcc { get; set; }

	public List<WSspReturnOrderFromDoc_Result> OrdList { get; set; }
}
