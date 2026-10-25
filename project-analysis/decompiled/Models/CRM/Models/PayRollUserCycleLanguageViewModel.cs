using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class PayRollUserCycleLanguageViewModel
{
	[Key]
	public int PayRollUserCycleId { get; set; }

	public int CrmUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollUserCycleTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CycleTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollUserCycleDuration")]
	public int? CycleDuration { get; set; }

	public DateTime CycleDate { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "PayRollUserCycleDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string CycleDatePersian { get; set; }

	public bool? CycleIsVerified { get; set; }

	public int? CycleVerifierUserId { get; set; }

	public DateTime? CycleVerifiedDate { get; set; }

	public string CycleVerifiedDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollUserCyclePrintFormat")]
	public int? CyclePrintFormatId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollUserCycleDefBankingAccount")]
	public int? CycleDefBankingAccountId { get; set; }

	public decimal? CycleNetSalary { get; set; }

	public int? CycleMonth { get; set; }

	public int? CycleYear { get; set; }

	public string CycleTitle_Lang { get; set; }
}
