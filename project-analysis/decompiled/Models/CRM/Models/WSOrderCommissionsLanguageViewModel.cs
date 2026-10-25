using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSOrderCommissionsLanguageViewModel
{
	[Key]
	public int OrderCommissionId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommDatePersian")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string CommDatePersian { get; set; }

	public DateTime CommDateTime { get; set; }

	public int CommOrderId { get; set; }

	public int CommCmpId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommUserId")]
	public int? CommUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommBaseAmountDec")]
	public decimal? CommBaseAmountDec { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommBaseAmountDecDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CommBaseAmountDecDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommBaseAmount")]
	public decimal CommBaseAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommRate")]
	public double? CommRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommRateDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CommRateDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommAmount")]
	public decimal CommAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommEffectiveDate")]
	public string CommEffectiveDatePersian { get; set; }

	public DateTime? CommEffectiveDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommPayType")]
	public int? CommPayTypeId { get; set; }

	public int? CommStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommDesc")]
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

	[Display(ResourceType = typeof(Labels), Name = "OrdCommAmountCurrUnId")]
	public int? CommAmountCurrUnId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommAmountCurrencyRate")]
	public double? CommAmountCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommBaseAmountDecPercent")]
	public decimal? CommBaseAmountDecPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommKindId")]
	public int? CommKindId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommTypeId")]
	public int? CommTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommTypeCmpId")]
	public int? CommTypeCmpId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdCommTypePrsId")]
	public int? CommTypePrsId { get; set; }

	public string CommBaseAmountDecDesc_Lang { get; set; }

	public string CommRateDesc_Lang { get; set; }

	public string CommDesc_Lang { get; set; }
}
