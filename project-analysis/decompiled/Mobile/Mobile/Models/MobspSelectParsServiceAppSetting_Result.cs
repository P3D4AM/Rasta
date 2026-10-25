using System;

namespace Mobile.Models;

public class MobspSelectParsServiceAppSetting_Result
{
	public int ParsServiceAppSettingId { get; set; }

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

	public string EdtInfPrjTitle { get; set; }

	public int? EdtInfPrjCnvsStatusGroupId { get; set; }

	public int? EdtInfCnvsTopicId { get; set; }

	public int? EdtInfCnvsReferUserId { get; set; }

	public int? EdtInfCnvsStatusId { get; set; }

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
}
