using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SmsSendViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "SmsSendTopic")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SmsSendTopic { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSendBody")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SmsSendBody { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsFromNumber")]
	public string SmsFromNumber { get; set; }

	public int SmsTypeUnicodeMessage { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsNumberCount")]
	public int SmsNumberCount { get; set; }

	public int SendType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsToNumber")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("09([0-9])\\d{8}", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string SmsToNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsCmessage")]
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

	public int Sid { get; set; }

	public string SmsBodyLangType { get; set; }

	public bool SendWithName { get; set; }

	public int AddedNumberCount { get; set; }

	public string FirstBodyTemp { get; set; }

	public int sendPriority { get; set; }

	public bool? HavePassword { get; set; }

	public string Password { get; set; }

	public int FromPage { get; set; }

	public bool? SmsNumberReadOnly { get; set; }
}
