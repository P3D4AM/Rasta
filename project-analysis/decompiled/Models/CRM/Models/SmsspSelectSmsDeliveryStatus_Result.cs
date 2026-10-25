using System;

namespace CRM.Models;

public class SmsspSelectSmsDeliveryStatus_Result
{
	public int ID { get; set; }

	public int WebServiceID { get; set; }

	public string DeliveryStatus { get; set; }

	public bool IsFinal { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
