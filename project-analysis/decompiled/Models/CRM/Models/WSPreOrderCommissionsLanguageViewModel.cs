using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSPreOrderCommissionsLanguageViewModel
{
	[Key]
	public int PreOrderCommissionId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommDatePersian")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string CommDatePersian { get; set; }

	public DateTime CommDateTime { get; set; }

	public int CommPreOrderId { get; set; }

	public int CommCmpId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int CommUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommBaseAmountDec")]
	public decimal? CommBaseAmountDec { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommBaseAmountDecDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CommBaseAmountDecDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommBaseAmount")]
	public decimal CommBaseAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommRate")]
	public double? CommRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommRateDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CommRateDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommAmount")]
	public decimal CommAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommAmountCurrUnId")]
	public int? CommAmountCurrUnId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommAmountCurrencyRate")]
	public double? CommAmountCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommEffectiveDate")]
	public string CommEffectiveDatePersian { get; set; }

	public DateTime? CommEffectiveDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommPayType")]
	public int? CommPayTypeId { get; set; }

	public int? CommStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordCommDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CommDesc { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string AppType { get; set; }

	public string FirstRegisterInfo { get; set; }

	public string RegisterInfo { get; set; }

	public string CommBaseAmountDecDesc_Lang { get; set; }

	public string CommRateDesc_Lang { get; set; }

	public string CommDesc_Lang { get; set; }
}
