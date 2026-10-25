using System;

namespace Mobile.Models;

public class MobspSelectMobSetting_Result
{
	public int MobSettingId { get; set; }

	public string AppName { get; set; }

	public int? DefUserId { get; set; }

	public string DefPrjTitle { get; set; }

	public int? DefPrjCnvsStatusGroupId { get; set; }

	public int? DefCnvsTopicId { get; set; }

	public int? DefCnvsReferUserId { get; set; }

	public int? DefCnvsStatusId { get; set; }

	public string DefCnvsDesc { get; set; }

	public int? DefPordVerifierRequestId { get; set; }

	public int? LoginUserId { get; set; }

	public string LoginPrjTitle { get; set; }

	public int? LoginPrjCnvsStatusGroupId { get; set; }

	public int? LoginCnvsTopicId { get; set; }

	public int? LoginCnvsReferUserId { get; set; }

	public int? LoginCnvsStatusId { get; set; }

	public string CallPrjTitle { get; set; }

	public int? CallPrjCnvsStatusGroupId { get; set; }

	public int? CallCnvsTopicId { get; set; }

	public int? CallCnvsReferUserId { get; set; }

	public int? CallCnvsStatusId { get; set; }

	public string CallAfterSendMessage { get; set; }

	public string InstallPrjTitle { get; set; }

	public int? InstallPrjCnvsStatusGroupId { get; set; }

	public int? InstallCnvsTopicId { get; set; }

	public int? InstallCnvsReferUserId { get; set; }

	public int? InstallCnvsStatusId { get; set; }

	public string CheckPrjTitle { get; set; }

	public int? CheckPrjCnvsStatusGroupId { get; set; }

	public int? CheckCnvsTopicId { get; set; }

	public int? CheckCnvsReferUserId { get; set; }

	public int? CheckCnvsStatusId { get; set; }

	public string EdtReqPrjTitle { get; set; }

	public int? EdtReqPrjCnvsStatusGroupId { get; set; }

	public int? EdtReqCnvsTopicId { get; set; }

	public int? EdtReqCnvsReferUserId { get; set; }

	public int? EdtReqCnvsStatusId { get; set; }

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

	public string LoginCnvsDesc { get; set; }

	public string CallCnvsDesc { get; set; }

	public string InstallCnvsDesc { get; set; }

	public string CheckCnvsDesc { get; set; }

	public string EditReqCnvsDesc { get; set; }

	public string PordPrjTitle { get; set; }

	public int? PordPrjCnvsStatusGroupId { get; set; }

	public int? PordCnvsTopicId { get; set; }

	public int? PordCnvsReferUserId { get; set; }

	public int? PordCnvsStatusId { get; set; }

	public string PordCnvsDesc { get; set; }

	public string CmpNotifPrjTitle { get; set; }

	public int? CmpNotifPrjCnvsStatusGroupId { get; set; }

	public int? CmpNotifCnvsTopicId { get; set; }

	public int? CmpNotifCnvsReferUserId { get; set; }

	public int? CmpNotifCnvsStatusId { get; set; }

	public string CmpNotifCnvsDesc { get; set; }

	public int? DefPrdPriceGroupId { get; set; }

	public int? PordCreditDurationId { get; set; }

	public int? PordPrintFormatId { get; set; }

	public int? PordWHId { get; set; }

	public int? PordCurrencyUnitId { get; set; }

	public int? PordChangeCurrDesId { get; set; }

	public bool? PordSendSmsAfterVerify { get; set; }

	public string PordVerifierRequestMsg { get; set; }

	public bool? ShowTomanLabel { get; set; }

	public bool? ShowLastPrdPriceListDate { get; set; }
}
