namespace Mobile.Models;

public class SendSMSModel
{
	public string MobileNumber { get; set; }

	public string SMSBody { get; set; }

	public string CompanyId { get; set; }

	public string PersonId { get; set; }

	public int UserId { get; set; }

	public int LangId { get; set; }
}
