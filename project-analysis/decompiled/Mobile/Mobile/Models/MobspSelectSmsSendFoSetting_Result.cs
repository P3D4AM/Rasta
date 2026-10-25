namespace Mobile.Models;

public class MobspSelectSmsSendFoSetting_Result
{
	public int FoSettingId { get; set; }

	public bool? SmsSendingIsActive { get; set; }

	public string SmsWebServiceUserName { get; set; }

	public string SmsWebServicePassword { get; set; }

	public string SmsWebServiceNumber { get; set; }

	public string SmsWebServiceUrl { get; set; }

	public string SmsBodyPatternFormula { get; set; }

	public bool? SmsSendByWeb { get; set; }

	public bool? SmsSendByGSM { get; set; }

	public bool? SmsIsSendedVerification { get; set; }

	public int? SmsVerificationId { get; set; }

	public string SmsBodyPatternFormulaSendFoInfo { get; set; }
}
