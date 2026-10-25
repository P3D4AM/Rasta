using System;

namespace Mobile.Models;

public class ShpMobspLoadCompanyLoginInfo_Result
{
	public int CompanyID { get; set; }

	public int? cmpNumber { get; set; }

	public string cmpName { get; set; }

	public string CompanyName { get; set; }

	public string cmpActivityType { get; set; }

	public string cmpEmail { get; set; }

	public string cmpUserName { get; set; }

	public string cmpPassword { get; set; }

	public int cmpReferUserId { get; set; }

	public string cmpReferUser { get; set; }

	public string cmpCode { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePerWithSlash { get; set; }

	public DateTime? cmpEffectiveDate { get; set; }

	public string cmpEffectiveDatePerWithSlash { get; set; }

	public byte[] CompanyLogo { get; set; }

	public DateTime? FirstOrderDate { get; set; }

	public string FirstOrderDatePerWithSlash { get; set; }

	public bool? cmpFOAccessLinkedCompany { get; set; }

	public string cmpMobile { get; set; }

	public string PrsNationalCode { get; set; }

	public string PrsMobile { get; set; }

	public int? cmpMainPersonId { get; set; }

	public string cmpMainPerson { get; set; }

	public string CompanyNameWithOutTitle { get; set; }

	public int? cmpShpSettlementTypeId { get; set; }

	public int? cmpShpSettlementCreditIssueType { get; set; }

	public decimal? cmpShpSettlementCreditPerBuy { get; set; }

	public decimal? cmpShpSettlementTotalCredit { get; set; }

	public bool? cmpShpSettlementCreditRemainShow { get; set; }

	public int? CompanyPersonID { get; set; }

	public string prsLName { get; set; }

	public string prsFName { get; set; }

	public string PersonTitle { get; set; }

	public string PersonName { get; set; }

	public string PersonNameWithOutTitle { get; set; }

	public string PersonMobile { get; set; }

	public string PersonEmail { get; set; }

	public string PersonNationalCode { get; set; }

	public int? LoginType { get; set; }

	public string cmpCIds { get; set; }

	public string cmpFOInfo { get; set; }

	public bool? cmpFOIsActive { get; set; }

	public bool? cmpShpIsActive { get; set; }

	public DateTime? cmpFOLoginExpireDate { get; set; }

	public DateTime? cmpShpLoginExpireDate { get; set; }

	public string prsCIds { get; set; }

	public string prsFOInfo { get; set; }

	public bool? prsFOIsActive { get; set; }

	public bool? prsShpIsActive { get; set; }

	public DateTime? prsFOLoginExpireDate { get; set; }

	public DateTime? prsShpLoginExpireDate { get; set; }

	public int? LastCId { get; set; }

	public string FoActiveCIds { get; set; }

	public string FoShpInfo { get; set; }

	public int? cmpKind { get; set; }
}
