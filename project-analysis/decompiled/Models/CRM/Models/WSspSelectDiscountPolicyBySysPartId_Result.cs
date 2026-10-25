using System;

namespace CRM.Models;

public class WSspSelectDiscountPolicyBySysPartId_Result
{
	public int DiscountPolicyId { get; set; }

	public int DPSystemPartId { get; set; }

	public string DPSystemPartTitle { get; set; }

	public string DPTitle { get; set; }

	public decimal DPDiscountPercent { get; set; }

	public DateTime? DPExpireDate { get; set; }

	public string DPExpireDatePersian { get; set; }

	public bool? DPIsActive { get; set; }

	public string DPFormulaJson { get; set; }

	public string DPPrdExceptionJson { get; set; }

	public int? DPOrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string DPFormulaJsonByName { get; set; }

	public string DPPrdExceptionJsonByName { get; set; }
}
