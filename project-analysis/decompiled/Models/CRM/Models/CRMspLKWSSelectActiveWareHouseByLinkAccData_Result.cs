using System;

namespace CRM.Models;

public class CRMspLKWSSelectActiveWareHouseByLinkAccData_Result
{
	public int WareHouseID { get; set; }

	public string WrhsName { get; set; }

	public string WrhsCode { get; set; }

	public string WrhsAddress { get; set; }

	public string WrhsPreTel { get; set; }

	public string WrhsTel { get; set; }

	public string WrhsTelSecond { get; set; }

	public string WrhsTelThird { get; set; }

	public string WrhsFax { get; set; }

	public string WrhsFaxSecond { get; set; }

	public string WrhsArea { get; set; }

	public string WrhsPerson { get; set; }

	public string WrhsDescription { get; set; }

	public short? IsFix { get; set; }

	public bool? WrhsDeActive { get; set; }

	public int? OrderView { get; set; }

	public int? WrhsLinkAccWhId { get; set; }

	public string WrhsLinkAccWhCode { get; set; }

	public string WrhsLinkAccWhIdStr { get; set; }

	public string WrhsLinkAccWhName { get; set; }

	public string WrhsLinkAccWareHouses { get; set; }

	public int? WrhsUserId { get; set; }

	public DateTime? WrhsLinkAccFirstTransferDate { get; set; }

	public DateTime? WrhsLinkAccLastTransferDate { get; set; }

	public string WrhsLinkAccData { get; set; }

	public int? WrhsCId { get; set; }
}
