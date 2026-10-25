using System;

namespace CRM.Models;

public class CRMspSelectCenterWithAccLinkField_Result
{
	public int CenterID { get; set; }

	public string CenterName { get; set; }

	public string CenterCode { get; set; }

	public bool? CenterInActive { get; set; }

	public int? ParentId { get; set; }

	public int? OrderView { get; set; }

	public string LinkAccCenterIdStr { get; set; }

	public string LinkAccCenterCode { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }
}
