using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoSettingLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefaultGroupId")]
	public int? CmpDefaultGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefaultSubGroupId")]
	public int? CmpDefaultSubGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefaultGroupIdII")]
	public int? CmpDefaultGroupIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefaultGroupIdIII")]
	public int? CmpDefaultGroupIdIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefaultGroupIdIV")]
	public int? CmpDefaultGroupIdIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefaultTypeId")]
	public int? CmpDefaultTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefaultPresentationId")]
	public int? CmpDefaultPresentationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefaultReferUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int CmpDefaultReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrjDefaultTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrjDefaultTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrjDefaultStarterUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int PrjDefaultStarterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrjDefaultGradeId")]
	public int? PrjDefaultGradeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrjDefaultPriorityId")]
	public int? PrjDefaultPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrjDefaultGroupId")]
	public int? PrjDefaultGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrjDefaultCnvsStatusGroupId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int PrjDefaultCnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrjDefaultPostFix")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrjDefaultPostFix { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrjDefaultFOCmpCanSee")]
	public bool? PrjDefaultFOCmpCanSee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrjInsertCrmProjectsForbiddenFUFDPActive")]
	public bool? PrjInsertCrmProjectsForbiddenFUFDPActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrjInsertProjectInformationsDefualtFieldActive")]
	public bool? PrjInsertProjectInformationsDefualtFieldActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsDefaultTopicId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int CnvsDefaultTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsDefaultDesc")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CnvsDefaultDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsDefaultUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int CnvsDefaultUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsDefaultReferUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int CnvsDefaultReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsDefaultReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CnvsDefaultReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsDefaultStatusId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int CnvsDefaultStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsDefaultPriorityId")]
	public int? CnvsDefaultPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingEmailSendingIsActive")]
	public bool? EmailSendingIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingEmailSettingId")]
	public int? EmailSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingEmailUserInfoId")]
	public int? EmailUserInfoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingEmailSubjectPatternFormula")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailSubjectPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingEmailBodyPatternFormula")]
	[UIHint("RichText")]
	[AllowHtml]
	public string EmailBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsSendingIsActive")]
	public bool? SmsSendingIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsWebServiceUserName")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SmsWebServiceUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsWebServicePassword")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SmsWebServicePassword { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsWebServiceNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SmsWebServiceNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsWebServiceUrl")]
	public string SmsWebServiceUrl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsBodyPatternFormula")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SmsBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoLogEmailAdminI")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorInFormat")]
	public string FoLogEmailAdminI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoLogEmailAdminII")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorInFormat")]
	public string FoLogEmailAdminII { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsDescTooltip")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CnvsDescTooltip { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketDescTooltip")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TicketDescTooltip { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrdPriceVisible")]
	public bool? PrdPriceVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrdDisplayType")]
	public int? PrdDisplayType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketSubjSelectLoadDefaultContext")]
	public bool? TicketSubjSelectLoadDefaultContext { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketSubjectDefaultContext")]
	public string TicketSubjectDefaultContext { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketSubjectDefaultContext")]
	public string TicketSubjectDefaultContextExtra { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsSendByWeb")]
	public bool? SmsSendByWeb { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsSendByGSM")]
	public bool? SmsSendByGSM { get; set; }

	public string PrjDefaultTitle_Lang { get; set; }

	public string PrjDefaultPostFix_Lang { get; set; }

	public string CnvsDefaultDesc_Lang { get; set; }

	public string CnvsDefaultReferDesc_Lang { get; set; }

	public string CnvsDescTooltip_Lang { get; set; }

	public string TicketDescTooltip_Lang { get; set; }

	public string TicketSubjectDefaultContext_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefUsernameType")]
	public int? CmpDefUsernameType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefPasswordType")]
	public int? CmpDefPasswordType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingEmailSmtpUseDefaultCredentials")]
	public bool? EmailSmtpUseDefaultCredentials { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingEmailSmtpEnableSSL")]
	public bool? EmailSmtpEnableSSL { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingEmailSmtpPort")]
	public int? EmailSmtpPort { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsIsSendedVerification")]
	public bool? SmsIsSendedVerification { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsVerificationId")]
	public int? SmsVerificationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingEmailSubjectPatternFormulaSendFoInfo")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailSubjectPatternFormulaSendFoInfo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingEmailBodyPatternFormulaSendFoInfo")]
	[UIHint("RichText")]
	[AllowHtml]
	public string EmailBodyPatternFormulaSendFoInfo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsBodyPatternFormulaSendFoInfo")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SmsBodyPatternFormulaSendFoInfo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsBodyPatternFormulaForgetPassword")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SmsBodyPatternFormulaForgetPassword { get; set; }

	public int? CmpDefFOActiveType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSmsBodyPatternFormulaOTP")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SmsBodyPatternFormulaOTP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingAdminUsers")]
	public string FoAdminUserIds { get; set; }

	public string FoAdminUsers { get; set; }
}
