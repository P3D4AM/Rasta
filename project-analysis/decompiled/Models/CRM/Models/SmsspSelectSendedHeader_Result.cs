namespace CRM.Models;

public class SmsspSelectSendedHeader_Result
{
	public string SendDate { get; set; }

	public string SendDay { get; set; }

	public string SendTime { get; set; }

	public string SendTopic { get; set; }

	public int? NumberCount { get; set; }

	public int? smsBodyCount { get; set; }

	public decimal? UserCost { get; set; }

	public int? UserId { get; set; }

	public int ID { get; set; }

	public long? SID { get; set; }

	public string FromNumber { get; set; }

	public int SendType { get; set; }
}
