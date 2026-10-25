using System;

namespace CRM.Models;

public class WSspSelectOrderPaymentGroupsI_Result
{
	public int OrderPaymentGroupIId { get; set; }

	public string ordpayGroupIName { get; set; }

	public string ordpayGroupICode { get; set; }

	public string ordpayGroupILinkAccData { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
