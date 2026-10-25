using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectBuyOrderPaymentTypes_Result
{
	public int BuyOrderPaymentTypeId { get; set; }

	public string bordpayType { get; set; }

	public string bordpayTypeDescription { get; set; }

	public int UserId { get; set; }

	public int? FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
