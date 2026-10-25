using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFoSetting_LangMetadata))]
public class CrmFoSetting_Lang
{
	public int CrmFoSettingLandID { get; set; }

	public int? FoSettingId { get; set; }

	public string PrjDefaultTitle { get; set; }

	public string PrjDefaultPostFix { get; set; }

	public string CnvsDefaultDesc { get; set; }

	public string CnvsDefaultReferDesc { get; set; }

	public int LanguageID { get; set; }

	public string CnvsDescTooltip { get; set; }

	public string TicketDescTooltip { get; set; }

	public string TicketSubjectDefaultContext { get; set; }

	public string LoginTitle { get; set; }

	public string LoginFormTitle { get; set; }

	public string LoginRegLinkTitle { get; set; }

	public string RegTitle { get; set; }

	public string RegFormTitle { get; set; }

	public string RegLoginLinkTitle { get; set; }

	public string ShpHomePrdPartTitle { get; set; }

	public string ShpDefPordVerifierRequestMsg { get; set; }

	public string ShpDefPordCnvsDesc { get; set; }

	public string ShpDefOrdVerifierRequestMsg { get; set; }

	public string ShpDefOrdCnvsDesc { get; set; }

	public string FoCmpInfoTabTitle { get; set; }

	public string FoLinkedCmpInfoTabTitle { get; set; }

	public string FoCmpPrjInfoTabTitle { get; set; }

	public string FoLinkedCmpPrjInfoTabTitle { get; set; }

	public string FoCmpPordInfoTabTitle { get; set; }

	public string FoLinkedCmpPordInfoTabTitle { get; set; }

	public string FoCmpOrdInfoTabTitle { get; set; }

	public string FoLinkedCmpOrdInfoTabTitle { get; set; }

	public string FoCmpDraftInfoTabTitle { get; set; }

	public string FoLinkedCmpDraftInfoTabTitle { get; set; }

	public string FoCmpTicketInfoTabTitle { get; set; }

	public string FoDyFormInfoTabTitle { get; set; }

	public string FoCmpLinkedInfoTabTitle { get; set; }

	public string FoSalesOrderLbl { get; set; }

	public string FoSalesReturnOrderLbl { get; set; }

	public string ShpCartDescriptionLbl { get; set; }

	public string ShpCartDescriptionPlaceholder { get; set; }

	public string ShpDefPrjTitle { get; set; }

	public string FoCmpLetterInfoTabTitle { get; set; }

	public string FoCmpFileInfoTabTitle { get; set; }

	public string FoSurveyInfoTabTitle { get; set; }

	public string TicketAutoReplyAfterSetDoingTimeDesc { get; set; }

	public string FoMobLogoTitle { get; set; }

	public string TicketDelayAllarmMessage { get; set; }

	public string TicketBusyAllarmMessage { get; set; }

	public string TicketUnhappyAllarmMessage { get; set; }

	public string FoDiscountCodeInfoTabTitle { get; set; }

	public string ShpHomeTopHeaderContent { get; set; }

	public string ShpLinkedPrdLbl { get; set; }

	public string FoCmpMnBgInfoTabTitle { get; set; }

	public string ShpHomeSeoTitle { get; set; }

	public string ShpHomeSeoDescription { get; set; }

	public string ShpHomeSeoAuthor { get; set; }

	public string ShpHomeSeoCopyright { get; set; }

	public string ShpHomeSeoKeywords { get; set; }

	public string ShpHomeSeoFAQ { get; set; }

	public virtual CrmFoSetting CrmFoSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
