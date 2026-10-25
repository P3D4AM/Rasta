using System;

namespace CRM.Models;

public class CRMspSelectMobSetting_Result
{
	public int MobSettingId { get; set; }

	public string AppName { get; set; }

	public int? DefUserId { get; set; }

	public string DefUser { get; set; }

	public string DefPrjTitle { get; set; }

	public int? DefPrjCnvsStatusGroupId { get; set; }

	public string DefPrjCnvsStatusGroup { get; set; }

	public int? DefCnvsTopicId { get; set; }

	public string DefCnvsTopic { get; set; }

	public int? DefCnvsReferUserId { get; set; }

	public string DefCnvsReferUser { get; set; }

	public int? DefCnvsStatusId { get; set; }

	public string DefCnvsStatus { get; set; }

	public string DefCnvsDesc { get; set; }

	public int? DefPordVerifierRequestId { get; set; }

	public string DefPordVerifierRequest { get; set; }

	public int? DefPrdPriceGroupId { get; set; }

	public int? LoginUserId { get; set; }

	public string LoginUser { get; set; }

	public string LoginPrjTitle { get; set; }

	public int? LoginPrjCnvsStatusGroupId { get; set; }

	public string LoginPrjCnvsStatusGroup { get; set; }

	public int? LoginCnvsTopicId { get; set; }

	public string LoginCnvsTopic { get; set; }

	public int? LoginCnvsReferUserId { get; set; }

	public string LoginCnvsReferUser { get; set; }

	public int? LoginCnvsStatusId { get; set; }

	public string LoginCnvsStatus { get; set; }

	public string LoginCnvsDesc { get; set; }

	public string CallPrjTitle { get; set; }

	public int? CallPrjCnvsStatusGroupId { get; set; }

	public string CallPrjCnvsStatusGroup { get; set; }

	public int? CallCnvsTopicId { get; set; }

	public string CallCnvsTopic { get; set; }

	public int? CallCnvsReferUserId { get; set; }

	public string CallCnvsReferUser { get; set; }

	public int? CallCnvsStatusId { get; set; }

	public string CallCnvsStatus { get; set; }

	public string CallAfterSendMessage { get; set; }

	public string CallCnvsDesc { get; set; }

	public string InstallPrjTitle { get; set; }

	public int? InstallPrjCnvsStatusGroupId { get; set; }

	public string InstallPrjCnvsStatusGroup { get; set; }

	public int? InstallCnvsTopicId { get; set; }

	public string InstallCnvsTopic { get; set; }

	public int? InstallCnvsReferUserId { get; set; }

	public string InstallCnvsReferUser { get; set; }

	public int? InstallCnvsStatusId { get; set; }

	public string InstallCnvsStatus { get; set; }

	public string InstallCnvsDesc { get; set; }

	public string CheckPrjTitle { get; set; }

	public int? CheckPrjCnvsStatusGroupId { get; set; }

	public string CheckPrjCnvsStatusGroup { get; set; }

	public int? CheckCnvsTopicId { get; set; }

	public string CheckCnvsTopic { get; set; }

	public int? CheckCnvsReferUserId { get; set; }

	public string CheckCnvsReferUser { get; set; }

	public int? CheckCnvsStatusId { get; set; }

	public string CheckCnvsStatus { get; set; }

	public string CheckCnvsDesc { get; set; }

	public string EdtReqPrjTitle { get; set; }

	public int? EdtReqPrjCnvsStatusGroupId { get; set; }

	public string EdtReqPrjCnvsStatusGroup { get; set; }

	public int? EdtReqCnvsTopicId { get; set; }

	public string EdtReqCnvsTopic { get; set; }

	public int? EdtReqCnvsReferUserId { get; set; }

	public int? EdtReqCnvsStatusId { get; set; }

	public string EdtReqCnvsStatus { get; set; }

	public string EditReqCnvsDesc { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string User { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string PordPrjTitle { get; set; }

	public int? PordPrjCnvsStatusGroupId { get; set; }

	public string PordPrjCnvsStatusGroup { get; set; }

	public int? PordCnvsTopicId { get; set; }

	public string PordCnvsTopic { get; set; }

	public int? PordCnvsReferUserId { get; set; }

	public string PordCnvsReferUser { get; set; }

	public int? PordCnvsStatusId { get; set; }

	public string PordCnvsStatus { get; set; }

	public string PordCnvsDesc { get; set; }

	public int? PordCreditDurationId { get; set; }

	public int? PordPrintFormatId { get; set; }

	public string PordPrintFormat { get; set; }

	public int? PordWHId { get; set; }

	public string PordWHName { get; set; }

	public int? PordCurrencyUnitId { get; set; }

	public string PordCurrencyUnit { get; set; }

	public int? PordChangeCurrDesId { get; set; }

	public string PordChangeCurrDes { get; set; }

	public string CmpNotifPrjTitle { get; set; }

	public int? CmpNotifPrjCnvsStatusGroupId { get; set; }

	public string CmpNotifPrjCnvsStatusGroup { get; set; }

	public int? CmpNotifCnvsTopicId { get; set; }

	public string CmpNotifCnvsTopic { get; set; }

	public int? CmpNotifCnvsReferUserId { get; set; }

	public string CmpNotifCnvsReferUser { get; set; }

	public int? CmpNotifCnvsStatusId { get; set; }

	public string CmpNotifCnvsStatus { get; set; }

	public string CmpNotifCnvsDesc { get; set; }

	public string EdtReqCnvsReferUser { get; set; }

	public string PordCreditDuration { get; set; }

	public string DefPrdPriceGroup { get; set; }

	public string PordVerifierRequestMsg { get; set; }

	public bool? PordSendSmsAfterVerify { get; set; }

	public bool? PordIssueOrdAfterOnLinePay { get; set; }

	public int? PordPayTypeId { get; set; }

	public int? PordIssueOrdOprId { get; set; }

	public int? PordIssueOrdPrintFormId { get; set; }

	public string PordPayType { get; set; }

	public string PordIssueOrdOpr { get; set; }

	public string PordIssueOrdPrintForm { get; set; }

	public bool? ShowTomanLabel { get; set; }

	public bool? ShowLastPrdPriceListDate { get; set; }
}
