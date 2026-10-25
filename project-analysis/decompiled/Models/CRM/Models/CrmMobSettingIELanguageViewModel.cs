using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmMobSettingIELanguageViewModel
{
	[Key]
	public int MobSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingAppName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AppName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingDefUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? DefUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingDefPrjTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DefPrjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingDefPrjCnvsStatusGroupId")]
	public int? DefPrjCnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingDefCnvsTopicId")]
	public int? DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingDefCnvsReferUserId")]
	public int? DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingDefCnvsStatusId")]
	public int? DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingDefCnvsDesc")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DefCnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingDefPordVerifierRequestId")]
	public int? DefPordVerifierRequestId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingDefPrdPriceGroupId")]
	public int? DefPrdPriceGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingLoginCnvsDesc")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginCnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingLoginUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? LoginUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingLoginPrjTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginPrjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingLoginPrjCnvsStatusGroupId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? LoginPrjCnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingLoginCnvsTopicId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? LoginCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingLoginCnvsReferUserId")]
	public int? LoginCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingLoginCnvsStatusId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? LoginCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCallPrjTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CallPrjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobsettingCallPrjCnvsStatusGroupId")]
	public int? CallPrjCnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCallCnvsTopicId")]
	public int? CallCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCallCnvsReferUserId")]
	public int? CallCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCallCnvsStatusId")]
	public int? CallCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCallAfterSendMessage")]
	public string CallAfterSendMessage { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCallCnvsDesc")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CallCnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingInstallPrjTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InstallPrjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingInstallPrjCnvsStatusGroupId")]
	public int? InstallPrjCnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingInstallCnvsTopicId")]
	public int? InstallCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingInstallCnvsReferUserId")]
	public int? InstallCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingInstallCnvsStatusId")]
	public int? InstallCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingInstallCnvsDesc")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InstallCnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCheckPrjTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CheckPrjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCheckPrjCnvsStatusGroupId")]
	public int? CheckPrjCnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCheckCnvsTopicId")]
	public int? CheckCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCheckCnvsReferUserId")]
	public int? CheckCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCheckCnvsStatusId")]
	public int? CheckCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCheckCnvsDesc")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CheckCnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingEdtReqPrjTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EdtReqPrjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingEdtReqPrjCnvsStatusGroupId")]
	public int? EdtReqPrjCnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingEdtReqCnvsTopicId")]
	public int? EdtReqCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingEdtReqCnvsReferUserId")]
	public int? EdtReqCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingEdtReqCnvsStatusId")]
	public int? EdtReqCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingEditReqCnvsDesc")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EditReqCnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordPrjTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PordPrjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordPrjCnvsStatusGroupId")]
	public int? PordPrjCnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordCnvsTopicId")]
	public int? PordCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordCnvsReferUserId")]
	public int? PordCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordCnvsStatusId")]
	public int? PordCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordCnvsDesc")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PordCnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordCreditDurationId")]
	public int? PordCreditDurationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordPrintFormatId")]
	public int? PordPrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordWHId")]
	public int? PordWHId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordCurrencyUnitId")]
	public int? PordCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordChangeCurrDesId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? PordChangeCurrDesId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordVerifierRequestMsg")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PordVerifierRequestMsg { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordSendSmsAfterVerify")]
	public bool PordSendSmsAfterVerify { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordIssueOrdAfterPayOnLine")]
	public bool PordIssueOrdAfterOnLinePay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordPayType")]
	public int? PordPayTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordIssueOrdOpr")]
	public int? PordIssueOrdOprId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingPordIssueOrdPrintForm")]
	public int? PordIssueOrdPrintFormId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCmpNotifPrjTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CmpNotifPrjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCmpNotifPrjCnvsStatusGroupId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? CmpNotifPrjCnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCmpNotifCnvsTopicId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? CmpNotifCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCmpNotifCnvsReferUserId")]
	public int? CmpNotifCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCmpNotifCnvsStatusId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? CmpNotifCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingCmpNotifCnvsDesc")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CmpNotifCnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingShowLastPrdPriceListDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public bool ShowLastPrdPriceListDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobSettingShowTomanLabel")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public bool ShowTomanLabel { get; set; }
}
