using System;

namespace CRM.Models;

public class WSspSelectWareHouse_Result
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

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? WrhsDeActive { get; set; }

	public int? OrderView { get; set; }

	public int? WrhsLinkAccWhId { get; set; }

	public string WrhsLinkAccWhCode { get; set; }

	public string WrhsLinkAccWhIdStr { get; set; }

	public string WrhsLinkAccWareHouses { get; set; }

	public int? WrhsUserId { get; set; }

	public string WrhsUser { get; set; }
}
