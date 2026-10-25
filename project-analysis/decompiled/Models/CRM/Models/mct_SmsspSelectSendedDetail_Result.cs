namespace CRM.Models;

public class mct_SmsspSelectSendedDetail_Result
{
	public string Body { get; set; }

	public string RefID { get; set; }

	public string DeliveryStatus { get; set; }

	public string CompanyName { get; set; }

	public string PersonName { get; set; }

	public int? ID { get; set; }

	public long? SID { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? UserId { get; set; }

	public int? StatusId { get; set; }

	public string StatusChange { get; set; }

	public string SendDateTime { get; set; }

	public int? BodyCount { get; set; }

	public string BodyLangType { get; set; }

	public decimal? BodyCost { get; set; }

	public string Number { get; set; }
}
