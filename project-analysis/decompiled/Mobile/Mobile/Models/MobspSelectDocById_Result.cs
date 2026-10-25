using System;

namespace Mobile.Models;

public class MobspSelectDocById_Result
{
	public int DocID { get; set; }

	public int OprId { get; set; }

	public string Opr { get; set; }

	public int DocNumber { get; set; }

	public string DocDate { get; set; }

	public int? SenderId { get; set; }

	public string SenderName { get; set; }

	public string FactorNumber { get; set; }

	public string Description { get; set; }

	public short? IsFix { get; set; }

	public int WHId { get; set; }

	public string WH { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? OrderId { get; set; }

	public int? BuyOrderId { get; set; }

	public string SendAddress { get; set; }

	public string DriverName { get; set; }

	public string DriverTel { get; set; }

	public string FreightName { get; set; }

	public string BijakNumber { get; set; }

	public string CarNumber { get; set; }

	public DateTime? DocDateTime { get; set; }

	public int? WHIdI { get; set; }

	public string WHI { get; set; }

	public int? CompanyId { get; set; }

	public string Company { get; set; }

	public int? CompanyPersonId { get; set; }

	public string CompanyPerson { get; set; }

	public int? ProjectId { get; set; }

	public string Project { get; set; }

	public string cmpTitle { get; set; }

	public string AppType { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? LanguageID { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? DocLinkAccCodeId { get; set; }

	public string DocLinkAccCode { get; set; }

	public int? DocLinkAccDocId { get; set; }

	public string DocLinkAccDocNumber { get; set; }

	public int? DocLinkAccVoucherId { get; set; }

	public string DocLinkAccVoucherNumber { get; set; }

	public string DocNumRef { get; set; }

	public Guid? GUId { get; set; }

	public int? OprType { get; set; }

	public bool? IsVerified { get; set; }

	public string EditAfterFixInfoJs { get; set; }

	public string OrderIds { get; set; }
}
