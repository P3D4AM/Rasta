using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoSettingFoTabLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoCmpInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoLinkedCmpInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoLinkedCmpInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpPrjInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoCmpPrjInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoShowCmpPrjInfoTab")]
	public bool? FoShowCmpPrjInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoLinkedCmpPrjInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoLinkedCmpPrjInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoLinkedCmpPrjInfoTabTitle")]
	public bool? FoShowLinkedCmpPrjInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpPordInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoCmpPordInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpPordInfoTabTitle")]
	public bool? FoShowCmpPordInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoLinkedCmpPordInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoLinkedCmpPordInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoLinkedCmpPordInfoTabTitle")]
	public bool? FoShowLinkedCmpPordInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpOrdInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoCmpOrdInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpOrdInfoTabTitle")]
	public bool? FoShowCmpOrdInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoLinkedCmpOrdInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoLinkedCmpOrdInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoLinkedCmpOrdInfoTabTitle")]
	public bool? FoShowLinkedCmpOrdInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpDraftInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoCmpDraftInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpDraftInfoTabTitle")]
	public bool? FoShowCmpDraftInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoLinkedCmpDraftInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoLinkedCmpDraftInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoLinkedCmpDraftInfoTabTitle")]
	public bool? FoShowLinkedCmpDraftInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpTicketInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoCmpTicketInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpTicketInfoTabTitle")]
	public bool? FoShowCmpTicketInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoDyFormInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoDyFormInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoDyFormInfoTabTitle")]
	public bool? FoShowDyFormInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpLinkedInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoCmpLinkedInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpLinkedInfoTabTitle")]
	public bool? FoShowCmpLinkedInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpLetterInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoCmpLetterInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoShowCmpLetterInfoTab")]
	public bool? FoShowCmpLetterInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpFileInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoCmpFileInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoShowCmpFileInfoTab")]
	public bool? FoShowCmpFileInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoSurveyInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoSurveyInfoTabTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoShowSurveyInfoTab")]
	public bool? FoShowSurveyInfoTab { get; set; }

	public string FoCmpInfoTabTitle_Lang { get; set; }

	public string FoLinkedCmpInfoTabTitle_Lang { get; set; }

	public string FoCmpPrjInfoTabTitle_Lang { get; set; }

	public string FoLinkedCmpPrjInfoTabTitle_Lang { get; set; }

	public string FoCmpPordInfoTabTitle_Lang { get; set; }

	public string FoLinkedCmpPordInfoTabTitle_Lang { get; set; }

	public string FoCmpOrdInfoTabTitle_Lang { get; set; }

	public string FoLinkedCmpOrdInfoTabTitle_Lang { get; set; }

	public string FoCmpDraftInfoTabTitle_Lang { get; set; }

	public string FoLinkedCmpDraftInfoTabTitle_Lang { get; set; }

	public string FoCmpTicketInfoTabTitle_Lang { get; set; }

	public string FoDyFormInfoTabTitle_Lang { get; set; }

	public string FoCmpLinkedInfoTabTitle_Lang { get; set; }

	public string FoCmpLetterInfoTabTitle_Lang { get; set; }

	public string FoCmpFileInfoTabTitle_Lang { get; set; }

	public string FoSurveyInfoTabTitle_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoDiscountCodeInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoDiscountCodeInfoTabTitle { get; set; }

	public string FoDiscountCodeInfoTabTitle_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoShowDiscountCodeInfoTab")]
	public bool? FoShowDiscountCodeInfoTab { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCmpMnBgInfoTabTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoCmpMnBgInfoTabTitle { get; set; }

	public string FoCmpMnBgInfoTabTitle_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoShowCmpMnBgInfoTab")]
	public bool? FoShowCmpMnBgInfoTab { get; set; }
}
