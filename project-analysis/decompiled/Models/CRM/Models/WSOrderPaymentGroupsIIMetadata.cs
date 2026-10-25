using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSOrderPaymentGroupsIIMetadata
{
	[Key]
	public int OrderPaymentGroupIIId { get; set; }

	public string ordpayGroupIIName { get; set; }

	public string ordpayGroupIICode { get; set; }

	public string ordpayGroupIILinkAccData { get; set; }

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
}
