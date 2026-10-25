namespace CRMIdealApi.ApiModels;

public class SmsSendViewModel
{
	public string ApiUsername { get; set; }

	public string ApiPassword { get; set; }

	public int ApiUserId { get; set; }

	public int ApiLanguageId { get; set; }

	public string SmsSendTopic { get; set; }

	public string SmsSendBody { get; set; }

	public string SmsFromNumber { get; set; }

	public int SmsTypeUnicodeMessage { get; set; }

	public string SmsToNumber { get; set; }

	public int Cmessage { get; set; }

	public int TypeUnicodeMessage { get; set; }

	public string[] Body { get; set; }

	public string[] MobileNo { get; set; }

	public long[] GetId { get; set; }

	public string[] FromNymbers { get; set; }

	public string[] SchedulDate { get; set; }

	public bool SmsReadOnlyBody { get; set; }

	public int AllWnBodyCount { get; set; }

	public decimal AllWnBodyCost { get; set; }

	public int SmsMode { get; set; }

	public string SmsBodyPatern { get; set; }

	public int SmsBodyCount { get; set; }

	public int SmsbodyCost { get; set; }

	public string Numbers { get; set; }

	public int SendUserId { get; set; }

	public string CompaniesId { get; set; }

	public string CompanyPersonsId { get; set; }

	public string RefNumbers { get; set; }

	public double UserCost { get; set; }

	public string SmsBodyLangType { get; set; }

	public bool SendWithName { get; set; }

	public int AddedNumberCount { get; set; }

	public string FirstBodyTemp { get; set; }

	public int sendPriority { get; set; }

	public bool? HavePassword { get; set; }

	public string Password { get; set; }

	public bool? SmsNumberReadOnly { get; set; }
}
