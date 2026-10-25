using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderDefaultSettingMetadata))]
public class WSBuyOrderDefaultSetting
{
	public int BuyOrderDefaultSettingId { get; set; }

	public int ReferUserId { get; set; }

	public string SettingTitle { get; set; }

	public int? BuyOrderOprId { get; set; }

	public string Title { get; set; }

	public string Subject { get; set; }

	public decimal? TaxIndex { get; set; }

	public bool? CalculateTax { get; set; }

	public decimal? TaxIndexItem { get; set; }

	public bool? CalculateTaxItem { get; set; }

	public int? PrintFormatId { get; set; }

	public string Note { get; set; }

	public int? CurrencyUnitId { get; set; }

	public string DeliveryTerm { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public bool? IsPublic { get; set; }

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

	public int? CurrencyUnitIdI { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting_Lang> WSBuyOrderDefaultSetting_Lang { get; set; }

	public virtual WSBuyOrderOpr WSBuyOrderOpr { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits1 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public WSBuyOrderDefaultSetting()
	{
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrderDefaultSetting_Lang = (ICollection<WSBuyOrderDefaultSetting_Lang>)new HashSet<WSBuyOrderDefaultSetting_Lang>();
	}
}
