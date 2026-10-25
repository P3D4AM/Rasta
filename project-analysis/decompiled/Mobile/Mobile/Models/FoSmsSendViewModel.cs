namespace Mobile.Models;

public class FoSmsSendViewModel
{
	public int CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public string CmpPassword { get; set; }

	public string PrsMobile { get; set; }

	public string SmsText { get; set; }

	public string SmsBody { get; set; }

	public bool? SmsSendingIsActive { get; set; }

	public bool? SendSmsByGSM { get; set; }

	public int? SendSmsGsmSettingId { get; set; }

	public bool? SendSmsByWeb { get; set; }

	public int? SendSmsProviderId { get; set; }

	public string SendSmsFromNumber { get; set; }

	public int? sendSmsMode { get; set; }

	public string OTPCode { get; set; }

	public int? CId { get; set; }
}
