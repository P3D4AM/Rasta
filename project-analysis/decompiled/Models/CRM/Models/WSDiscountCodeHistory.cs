using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDiscountCodeHistoryMetadata))]
public class WSDiscountCodeHistory
{
	public int DiscountCodeHistoryId { get; set; }

	public int DiscountCodeId { get; set; }

	public string DisCode { get; set; }

	public int? DisCmpId { get; set; }

	public int? DisPrdId { get; set; }

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

	public int? PreOrderId { get; set; }

	public int? OrderId { get; set; }

	public int? SysPartId { get; set; }

	public int? ObjectId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDiscountCode WSDiscountCode { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSPreOrder WSPreOrder { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
