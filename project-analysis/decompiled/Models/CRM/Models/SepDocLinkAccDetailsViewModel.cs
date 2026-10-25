using System.Collections.Generic;

namespace CRM.Models;

public class SepDocLinkAccDetailsViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public CRMspLkSepWSSelectDocByDocId_Result DocInfo { get; set; }

	public List<CRMspLkSepWSSelectDocItemsByDocId_Result> DocItems { get; set; }
}
