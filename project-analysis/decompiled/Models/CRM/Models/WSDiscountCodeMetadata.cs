using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSDiscountCodeMetadata
{
	[Key]
	public int DiscountCodeId { get; set; }

	public string DisTitle { get; set; }

	public string DisCode { get; set; }

	public decimal? DisAmount { get; set; }

	public decimal? DisAmountPercent { get; set; }

	public DateTime DisExpDate { get; set; }

	public string DisExpDatePersian { get; set; }

	public int? DisCmpId { get; set; }

	public int? DisPrdId { get; set; }

	public int DisUseCnt { get; set; }

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
