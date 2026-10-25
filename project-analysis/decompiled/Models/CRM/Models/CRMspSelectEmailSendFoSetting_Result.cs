namespace CRM.Models;

public class CRMspSelectEmailSendFoSetting_Result
{
	public int FoSettingId { get; set; }

	public bool? EmailSendingIsActive { get; set; }

	public int? EmailSettingId { get; set; }

	public int? EmailUserInfoId { get; set; }

	public string euNikeName { get; set; }

	public string euNikeEmail { get; set; }

	public string euSMTPServer { get; set; }

	public string euUserName { get; set; }

	public string euPassword { get; set; }

	public bool? euSMTPUseDefCredentials { get; set; }

	public bool? euSMTPUseSsl { get; set; }

	public int? euSMTPPort { get; set; }

	public string EmailSubjectPatternFormula { get; set; }

	public string EmailBodyPatternFormula { get; set; }

	public bool? EmailSmtpUseDefaultCredentials { get; set; }

	public bool? EmailSmtpEnableSSL { get; set; }

	public int? EmailSmtpPort { get; set; }

	public string EmailSubjectPatternFormulaSendFoInfo { get; set; }

	public string EmailBodyPatternFormulaSendFoInfo { get; set; }
}
