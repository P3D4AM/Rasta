using System;

namespace CRM.Models;

public class WSspSelectBuyOrderDefaultSettingById_Result
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

	public string BuyOrderDefaultSetting_Lang { get; set; }
}
