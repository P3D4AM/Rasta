using System;

namespace CRM.Models;

public class CRMspLkWSSelectDocById_Result
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

	public string DocLinkAccDocIdStr { get; set; }

	public string DocLinkAccDocType { get; set; }

	public int? VerifierId { get; set; }

	public string VerifierName { get; set; }

	public DateTime? VerifiedRegisterDate { get; set; }

	public string VerifiedRegisterDatePersian { get; set; }

	public int? VerifierRequestId { get; set; }

	public string VerifierRequestName { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public int? PreOrderId { get; set; }

	public DateTime? DocLinkAccFirstTransferDate { get; set; }

	public DateTime? DocLinkAccLastTransferDate { get; set; }

	public string DocLinkAccData { get; set; }

	public int? WrhsLinkAccWhId { get; set; }

	public string WrhsLinkAccWhCode { get; set; }

	public string WrhsLinkAccWhIdStr { get; set; }

	public string WrhsLinkAccWhName { get; set; }

	public string WrhsLinkAccWareHouses { get; set; }

	public int? WrhsLinkAccWhIdI { get; set; }

	public string WrhsLinkAccWhCodeI { get; set; }

	public string WrhsLinkAccWhIdStrI { get; set; }

	public string WrhsLinkAccWhNameI { get; set; }

	public string WrhsLinkAccWareHousesI { get; set; }
}
