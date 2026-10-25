using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDiscountCodeMetadata))]
public class WSDiscountCode
{
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

	public double? ScoreRate { get; set; }

	public int? DisUseCntPerCmp { get; set; }

	public int? DisSingleCmpScoreId { get; set; }

	public bool? DisCanChangeToScore { get; set; }

	public int? DisCodeRuleId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSDiscountCode_Lang> WSDiscountCode_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSDiscountCodeHistory> WSDiscountCodeHistory { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSDiscountCode()
	{
		WSDiscountCode_Lang = (ICollection<WSDiscountCode_Lang>)new HashSet<WSDiscountCode_Lang>();
		WSDiscountCodeHistory = (ICollection<WSDiscountCodeHistory>)new HashSet<WSDiscountCodeHistory>();
		WSPreOrderItems = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
	}
}
