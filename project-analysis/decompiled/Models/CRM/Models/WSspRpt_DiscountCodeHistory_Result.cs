using System;

namespace CRM.Models;

public class WSspRpt_DiscountCodeHistory_Result
{
	public int DiscountCodeHistoryId { get; set; }

	public int DiscountCodeId { get; set; }

	public string DisCode { get; set; }

	public int? DisCmpId { get; set; }

	public string DisCmp { get; set; }

	public int? DisPrdId { get; set; }

	public string DisPrd { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

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

	public int? PreOrderId { get; set; }

	public long? PreOrderNumber { get; set; }

	public int? OrderId { get; set; }

	public string OrderOpr { get; set; }

	public string DisTitle { get; set; }
}
