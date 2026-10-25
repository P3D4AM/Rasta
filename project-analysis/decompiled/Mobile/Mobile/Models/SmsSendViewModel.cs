namespace Mobile.Models;

public class SmsSendViewModel
{
	public int UserId { get; set; }

	public string SmsSendTopic { get; set; }

	public string SmsSendBody { get; set; }

	public int SmsNumberCount { get; set; }

	public int SendType { get; set; }

	public string SmsToNumber { get; set; }

	public int Cmessage { get; set; }

	public int TypeUnicodeMessage { get; set; }

	public string Numbers { get; set; }

	public string CompaniesId { get; set; }

	public string CompanyPersonsId { get; set; }

	public int Sid { get; set; }

	public int SmsbodyCost { get; set; }

	public int SmsBodyCount { get; set; }

	public string SmsBodyLangType { get; set; }

	public int sendPriority { get; set; }

	public double UserCost { get; set; }

	public int? LangId { get; set; }

	public bool? HavePassword { get; set; }

	public string Password { get; set; }

	public int? CenterId { get; set; }
}
