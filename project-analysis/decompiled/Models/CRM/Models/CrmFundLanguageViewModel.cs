using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFundLanguageViewModel
{
	[Key]
	public int FundId { get; set; }

	public int CrmUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FundGroup")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int FundGroupId { get; set; }

	public DateTime FundDate { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "FundDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string FundDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FundNumber")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public long FundNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FundCredit")]
	public decimal? FundCredit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FundDebit")]
	public decimal? FundDebit { get; set; }

	public decimal? FundRemain { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FundDesc")]
	public string FundDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FundOrderView")]
	public int? FundOrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int? FundVerificationWorkFlowId { get; set; }

	public int? FundVerifierId { get; set; }

	public string VerifierUser { get; set; }

	public bool? FundIsVerified { get; set; }

	public int? FundVerifierRequestId { get; set; }

	public DateTime? FundVerifiedRegisterDate { get; set; }

	public string FundDesc_Lang { get; set; }
}
